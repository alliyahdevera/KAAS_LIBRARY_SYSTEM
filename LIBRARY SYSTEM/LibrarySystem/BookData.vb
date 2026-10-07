Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Module BookData

    ' Splits "A & B" or "Fiction, History" into a clean, de-duplicated list
    Public Function ParseNames(text As String, separators As Char()) As List(Of String)
        Dim result As New List(Of String)
        If String.IsNullOrWhiteSpace(text) Then Return result
        For Each part As String In text.Split(separators)
            Dim n As String = Regex.Replace(part, "\s+", " ").Trim()
            If n <> "" AndAlso Not result.Exists(Function(x) x.Equals(n, StringComparison.OrdinalIgnoreCase)) Then
                result.Add(n)
            End If
        Next
        Return result
    End Function

    Private Function GetOrCreateId(conn As MySqlConnection, tx As MySqlTransaction,
                                   table As String, idCol As String, nameCol As String,
                                   name As String) As Integer
        Using sel As New MySqlCommand($"SELECT {idCol} FROM {table} WHERE {nameCol} = @n", conn, tx)
            sel.Parameters.AddWithValue("@n", name)
            Dim o As Object = sel.ExecuteScalar()
            If o IsNot Nothing AndAlso Not IsDBNull(o) Then Return Convert.ToInt32(o)
        End Using
        Using ins As New MySqlCommand($"INSERT INTO {table} ({nameCol}) VALUES (@n)", conn, tx)
            ins.Parameters.AddWithValue("@n", name)
            ins.ExecuteNonQuery()
            Return Convert.ToInt32(ins.LastInsertedId)
        End Using
    End Function

    Public Function PublisherIdOrNull(conn As MySqlConnection, tx As MySqlTransaction, name As String) As Object
        If String.IsNullOrWhiteSpace(name) Then Return DBNull.Value
        Return GetOrCreateId(conn, tx, "Publishers", "publisher_id", "publisher_name", name.Trim())
    End Function

    Public Function FindBookIdByIsbn(conn As MySqlConnection, tx As MySqlTransaction, isbn As String) As Integer
        Using cmd As New MySqlCommand("SELECT book_id FROM BookInfo WHERE isbn = @i", conn, tx)
            cmd.Parameters.AddWithValue("@i", isbn)
            Dim o As Object = cmd.ExecuteScalar()
            If o Is Nothing OrElse IsDBNull(o) Then Return 0
            Return Convert.ToInt32(o)
        End Using
    End Function

    ' Replaces the authors of a book (1 or 2; the database trigger blocks a third)
    Public Sub SetAuthors(conn As MySqlConnection, tx As MySqlTransaction, bookId As Integer, authors As List(Of String))
        Using del As New MySqlCommand("DELETE FROM BookAuthors WHERE book_id = @b", conn, tx)
            del.Parameters.AddWithValue("@b", bookId)
            del.ExecuteNonQuery()
        End Using
        For i As Integer = 0 To authors.Count - 1
            Dim aid As Integer = GetOrCreateId(conn, tx, "Authors", "author_id", "author_name", authors(i))
            Using ins As New MySqlCommand(
                "INSERT INTO BookAuthors (book_id, author_id, author_order) VALUES (@b, @a, @o)", conn, tx)
                ins.Parameters.AddWithValue("@b", bookId)
                ins.Parameters.AddWithValue("@a", aid)
                ins.Parameters.AddWithValue("@o", i + 1)
                ins.ExecuteNonQuery()
            End Using
        Next
    End Sub

    ' Replaces the categories of a book (1 or more)
    Public Sub SetCategories(conn As MySqlConnection, tx As MySqlTransaction, bookId As Integer, categories As List(Of String))
        Using del As New MySqlCommand("DELETE FROM BookCategories WHERE book_id = @b", conn, tx)
            del.Parameters.AddWithValue("@b", bookId)
            del.ExecuteNonQuery()
        End Using
        For Each c As String In categories
            Dim cid As Integer = GetOrCreateId(conn, tx, "Categories", "category_id", "category_name", c)
            Using ins As New MySqlCommand(
                "INSERT INTO BookCategories (book_id, category_id) VALUES (@b, @c)", conn, tx)
                ins.Parameters.AddWithValue("@b", bookId)
                ins.Parameters.AddWithValue("@c", cid)
                ins.ExecuteNonQuery()
            End Using
        Next
    End Sub

    ' Adds physical copies with accession numbers ACC-00075, ACC-00076, ...
    Public Sub AddCopies(conn As MySqlConnection, tx As MySqlTransaction, bookId As Integer, count As Integer,
                         Optional condition As String = "Good")
        For i As Integer = 1 To count
            Dim newId As Integer
            Using ins As New MySqlCommand(
                "INSERT INTO BookCopies (book_id, accession_no, copy_status, book_condition) VALUES (@b, @tmp, 'Available', @cond)", conn, tx)
                ins.Parameters.AddWithValue("@b", bookId)
                ins.Parameters.AddWithValue("@tmp", "TMP-" & Guid.NewGuid().ToString("N").Substring(0, 20))
                ins.Parameters.AddWithValue("@cond", condition)
                ins.ExecuteNonQuery()
                newId = Convert.ToInt32(ins.LastInsertedId)
            End Using
            Using upd As New MySqlCommand(
                "UPDATE BookCopies SET accession_no = CONCAT('ACC-', LPAD(copy_id, 5, '0')) WHERE copy_id = @id", conn, tx)
                upd.Parameters.AddWithValue("@id", newId)
                upd.ExecuteNonQuery()
            End Using
        Next
    End Sub

    ' One search clause used by every book list (needs a parameter named @kw).
    ' Matches ISBN, title, author, publisher, category, edition and year published.
    Public Function BookSearchSql(Optional tableAlias As String = "") As String
        Dim p As String = If(tableAlias = "", "", tableAlias & ".")
        Dim like1 As String = " LIKE CONCAT('%',@kw,'%')"
        Return "(@kw = '' OR " &
               p & "isbn" & like1 & " OR " &
               p & "title" & like1 & " OR " &
               p & "authors" & like1 & " OR " &
               p & "publisher_name" & like1 & " OR " &
               p & "categories" & like1 & " OR " &
               p & "edition" & like1 & " OR " &
               "CAST(" & p & "year_published AS CHAR)" & like1 & ")"
    End Function
End Module

' ---------------------------------------------------------------
' Small UI helpers shared by all forms
' ---------------------------------------------------------------
Module UiHelpers

    ' Yes/No confirmation used before add, update, delete and export actions
    Public Function Confirm(action As String, subject As String, caption As String) As Boolean
        Return MsgBox("Are you sure you want to " & action & " " & subject & "?",
                      vbQuestion + vbYesNo + vbDefaultButton2, caption) = vbYes
    End Function

    ' Fills lblname / lblposition / lbldatetime in a form's header, if it has them
    Public Sub FillHeader(f As Form)
        Dim pos As String
        Select Case AppSession.Role
            Case "Admin" : pos = "Administrator"
            Case "Librarian" : pos = "Librarian"
            Case Else : pos = AppSession.MemberType
        End Select
        SetText(f, "lblname", AppSession.FullName)
        SetText(f, "lblposition", pos)
        SetText(f, "lbldatetime", Date.Now.ToString("MMMM dd, yyyy"))
    End Sub

    Private Sub SetText(f As Form, name As String, text As String)
        Dim found() As Control = f.Controls.Find(name, True)
        If found.Length > 0 Then found(0).Text = text
    End Sub

    Public Function AllButtons(root As Control) As List(Of Button)
        Dim list As New List(Of Button)
        For Each c As Control In root.Controls
            If TypeOf c Is Button Then list.Add(DirectCast(c, Button))
            list.AddRange(AllButtons(c))
        Next
        Return list
    End Function

    Public Sub ComingSoon(caption As String)
        MsgBox($"'{caption}' is being rebuilt for the new design and will be connected in the next phase.",
               vbInformation, "Coming soon")
    End Sub
End Module