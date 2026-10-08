Imports MySql.Data.MySqlClient

' The LAYOUT of this form lives in frmAdminBookInventory.Designer.vb -- open the form in the
' Visual Studio designer to move, resize or restyle anything. This file only holds behaviour.
Public Class frmAdminBookInventory

    Private selectedCopyId As Integer = 0
    Private pager As GridPager

    Private isReady As Boolean = False      ' stays False until Load finishes, so setting up the filters runs no query

    Private Sub frmAdminBookInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboCondition.Items.AddRange(CopyData.AllConditions)   ' single source of truth for the condition list
        cboFilter.SelectedIndex = 0
        isReady = True
    End Sub

    ' ------------------------------------------------------------ list
    Private Sub OnVisible(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Not Me.DesignMode AndAlso Me.Visible Then LoadCopies()
    End Sub

    Private Sub Filter_Changed(sender As Object, e As EventArgs) _
            Handles txtSearch.TextChanged, cboFilter.SelectedIndexChanged
        If Not isReady Then Exit Sub
        LoadCopies()
    End Sub

    Private Sub LoadCopies()
        If pager Is Nothing Then pager = PagerHelper.Create(dgvCopies)
        dgvCopies.Rows.Clear()
        Dim kw As String = txtSearch.Text.Trim()
        Dim st As String = If(cboFilter.Text = "All", "", cboFilter.Text)
        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT c.copy_id, c.accession_no, v.isbn, v.title, v.authors, v.publisher_name, v.edition, " &
                    "       v.year_published, c.book_condition, c.copy_status, c.date_added " &
                    "FROM BookCopies c JOIN vw_BookCatalog v ON v.book_id = c.book_id " &
                    "WHERE c.copy_status <> 'Archived' " &
                    "AND (" & BookData.BookSearchSql("v") &
                    "     OR c.accession_no LIKE CONCAT('%',@kw,'%') OR CAST(c.copy_id AS CHAR) = @kw) " &
                    "AND (@st = '' OR c.copy_status = @st) " &
                    "ORDER BY v.title, c.copy_id", conn)
                    cmd.Parameters.AddWithValue("@kw", kw)
                    cmd.Parameters.AddWithValue("@st", st)
                    Using r As MySqlDataReader = cmd.ExecuteReader()
                        While r.Read()
                            Dim row As DataGridViewRow = dgvCopies.Rows(dgvCopies.Rows.Add())
                            row.Cells("BookNo").Value = r("copy_id").ToString()
                            row.Cells("Accession").Value = r("accession_no").ToString()
                            row.Cells("ISBN").Value = r("isbn").ToString()
                            row.Cells("BookTitle").Value = r("title").ToString()
                            row.Cells("BookAuthor").Value = If(IsDBNull(r("authors")), "", r("authors").ToString())
                            row.Cells("Publisher").Value = If(IsDBNull(r("publisher_name")), "", r("publisher_name").ToString())
                            row.Cells("Edition").Value = If(IsDBNull(r("edition")), "", r("edition").ToString())
                            row.Cells("YearPublished").Value = If(IsDBNull(r("year_published")), "", r("year_published").ToString())
                            row.Cells("BookCondition").Value = r("book_condition").ToString()
                            row.Cells("CopyStatus").Value = r("copy_status").ToString()
                            row.Cells("DateAdded").Value = Convert.ToDateTime(r("date_added")).ToString("MM/dd/yyyy")
                            Dim s As String = r("copy_status").ToString()
                            If s = "Lost" OrElse s = "Damaged" Then row.DefaultCellStyle.ForeColor = Color.Firebrick
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not load the book copies: " & ex.Message, vbCritical, "Book Inventory")
        End Try
        dgvCopies.ClearSelection()
        pager.Apply()
    End Sub

    Private Sub dgvCopies_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCopies.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim r As DataGridViewRow = dgvCopies.Rows(e.RowIndex)
        selectedCopyId = Convert.ToInt32(r.Cells("BookNo").Value)
        txtBookNo.Text = Convert.ToString(r.Cells("BookNo").Value)
        txtAccession.Text = Convert.ToString(r.Cells("Accession").Value)
        txtIsbn.Text = Convert.ToString(r.Cells("ISBN").Value)
        txtTitle.Text = Convert.ToString(r.Cells("BookTitle").Value)
        cboCondition.Text = Convert.ToString(r.Cells("BookCondition").Value)
        txtStatus.Text = Convert.ToString(r.Cells("CopyStatus").Value)
    End Sub

    ' Shows the title when a full ISBN is typed (used when adding copies)
    Private Sub txtIsbn_TextChanged(sender As Object, e As EventArgs) Handles txtIsbn.TextChanged
        If txtIsbn.Text.Trim().Length <> 13 Then
            txtTitle.Clear()
            Exit Sub
        End If
        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("SELECT title FROM BookInfo WHERE isbn = @i", conn)
                    cmd.Parameters.AddWithValue("@i", txtIsbn.Text.Trim())
                    Dim o As Object = cmd.ExecuteScalar()
                    txtTitle.Text = If(o Is Nothing OrElse IsDBNull(o), "(ISBN is not in the catalog)", o.ToString())
                End Using
            End Using
        Catch
            txtTitle.Clear()
        End Try
    End Sub

    ' ------------------------------------------------------------ add
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim isbn As String = txtIsbn.Text.Trim()
        If isbn = "" Then
            MsgBox("Enter the ISBN of the book you are adding copies to (or click a row to use its ISBN).", vbExclamation, "Book Inventory")
            Exit Sub
        End If
        If cboCondition.SelectedIndex = -1 Then
            MsgBox("Select the condition of the new copies.", vbExclamation, "Book Inventory")
            Exit Sub
        End If
        If Array.IndexOf(CopyData.AddConditions, cboCondition.Text) < 0 Then
            MsgBox("New copies can only be New, Good, Fair or Poor." & vbCrLf &
                   "Damaged and Lost are recorded when a borrowed book is returned, or by updating an existing copy.",
                   vbExclamation, "Book Inventory")
            Exit Sub
        End If

        Dim n As Integer = CInt(numCopies.Value)
        If Not UiHelpers.Confirm("add", n & If(n = 1, " copy", " copies") & " of ISBN " & isbn, "Book Inventory") Then Exit Sub

        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using tx As MySqlTransaction = conn.BeginTransaction()
                    Try
                        Dim bookId As Integer = BookData.FindBookIdByIsbn(conn, tx, isbn)
                        If bookId = 0 Then
                            MsgBox("That ISBN is not in the catalog. Add the book first in Book Management.", vbExclamation, "Book Inventory")
                            tx.Rollback()
                            Exit Sub
                        End If
                        BookData.AddCopies(conn, tx, bookId, n, cboCondition.Text)
                        tx.Commit()
                    Catch
                        tx.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not add the copies: " & ex.Message, vbCritical, "Book Inventory")
            Exit Sub
        End Try

        DBConnection.LogActivity("Add Book Copy", "Added " & n & " copy/copies (" & cboCondition.Text & ") to ISBN " & isbn)
        MsgBox("Saved successfully!", vbInformation, "Book Inventory")
        LoadCopies()
        ClearFields()
    End Sub

    ' ------------------------------------------------------------ update condition
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedCopyId = 0 Then
            MsgBox("Select a copy from the list first.", vbExclamation, "Book Inventory")
            Exit Sub
        End If
        If cboCondition.SelectedIndex = -1 Then
            MsgBox("Select the new condition.", vbExclamation, "Book Inventory")
            Exit Sub
        End If
        If Not UiHelpers.Confirm("update", "the condition of book no. " & selectedCopyId, "Book Inventory") Then Exit Sub

        Dim newCond As String = cboCondition.Text
        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using tx As MySqlTransaction = conn.BeginTransaction()
                    Try
                        Dim oldStatus As String = Nothing
                        Using cmd As New MySqlCommand("SELECT copy_status FROM BookCopies WHERE copy_id = @c FOR UPDATE", conn, tx)
                            cmd.Parameters.AddWithValue("@c", selectedCopyId)
                            Dim o As Object = cmd.ExecuteScalar()
                            If o IsNot Nothing AndAlso Not IsDBNull(o) Then oldStatus = o.ToString()
                        End Using
                        If oldStatus Is Nothing Then
                            MsgBox("That copy no longer exists.", vbExclamation, "Book Inventory")
                            tx.Rollback()
                            Exit Sub
                        End If
                        If oldStatus = "Borrowed" AndAlso (newCond = "Damaged" OrElse newCond = "Lost") Then
                            MsgBox("This copy is currently borrowed. Damaged or Lost is recorded by the librarian when it is returned.",
                                   vbExclamation, "Book Inventory")
                            tx.Rollback()
                            Exit Sub
                        End If

                        Dim newStatus As String = oldStatus
                        If newCond = "Damaged" OrElse newCond = "Lost" Then
                            newStatus = newCond
                        ElseIf oldStatus = "Lost" OrElse oldStatus = "Damaged" Then
                            newStatus = "Available"
                        End If

                        Using upd As New MySqlCommand(
                            "UPDATE BookCopies SET book_condition = @cond, copy_status = @st WHERE copy_id = @c", conn, tx)
                            upd.Parameters.AddWithValue("@cond", newCond)
                            upd.Parameters.AddWithValue("@st", newStatus)
                            upd.Parameters.AddWithValue("@c", selectedCopyId)
                            upd.ExecuteNonQuery()
                        End Using

                        If newStatus <> oldStatus Then
                            ' close any open report, then open a new one if the copy is now lost/damaged
                            Using res As New MySqlCommand(
                                "UPDATE LostDamagedBooks SET is_resolved = 1, resolved_date = CURDATE() " &
                                "WHERE copy_id = @c AND is_resolved = 0", conn, tx)
                                res.Parameters.AddWithValue("@c", selectedCopyId)
                                res.ExecuteNonQuery()
                            End Using
                            If newStatus = "Lost" OrElse newStatus = "Damaged" Then
                                Using ins As New MySqlCommand(
                                    "INSERT INTO LostDamagedBooks (copy_id, incident_type, incident_date, reported_by, remarks) " &
                                    "VALUES (@c, @t, CURDATE(), @u, 'Recorded by the admin in Book Inventory')", conn, tx)
                                    ins.Parameters.AddWithValue("@c", selectedCopyId)
                                    ins.Parameters.AddWithValue("@t", newStatus)
                                    ins.Parameters.AddWithValue("@u", If(AppSession.UserId > 0, CObj(AppSession.UserId), DBNull.Value))
                                    ins.ExecuteNonQuery()
                                End Using
                            End If
                        End If
                        tx.Commit()
                    Catch
                        tx.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not update the copy: " & ex.Message, vbCritical, "Book Inventory")
            Exit Sub
        End Try

        DBConnection.LogActivity("Update Book Copy", "Book no. " & selectedCopyId & " condition set to " & newCond)
        MsgBox("Copy updated successfully!", vbInformation, "Book Inventory")
        LoadCopies()
        ClearFields()
    End Sub

    ' ------------------------------------------------------------ delete / archive
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedCopyId = 0 Then
            MsgBox("Select a copy from the list first.", vbExclamation, "Book Inventory")
            Exit Sub
        End If

        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Dim status As String = ""
                Dim history As Integer = 0
                Using cmd As New MySqlCommand(
                    "SELECT copy_status, (SELECT COUNT(*) FROM BorrowTransaction WHERE copy_id = @c) " &
                    "FROM BookCopies WHERE copy_id = @c", conn)
                    cmd.Parameters.AddWithValue("@c", selectedCopyId)
                    Using r As MySqlDataReader = cmd.ExecuteReader()
                        If Not r.Read() Then
                            MsgBox("That copy no longer exists.", vbExclamation, "Book Inventory")
                            Exit Sub
                        End If
                        status = r.GetString(0)
                        history = Convert.ToInt32(r.GetValue(1))
                    End Using
                End Using

                If status = "Borrowed" Then
                    MsgBox("This copy is currently borrowed and cannot be removed.", vbExclamation, "Book Inventory")
                    Exit Sub
                End If

                If history > 0 Then
                    If Not UiHelpers.Confirm("archive", "book no. " & selectedCopyId &
                                             " (it has borrow history, so it is hidden and the history is kept)", "Book Inventory") Then Exit Sub
                    Using cmd As New MySqlCommand("UPDATE BookCopies SET copy_status = 'Archived' WHERE copy_id = @c", conn)
                        cmd.Parameters.AddWithValue("@c", selectedCopyId)
                        cmd.ExecuteNonQuery()
                    End Using
                    DBConnection.LogActivity("Archive Book Copy", "Archived book no. " & selectedCopyId)
                Else
                    If Not UiHelpers.Confirm("delete", "book no. " & selectedCopyId, "Book Inventory") Then Exit Sub
                    Using cmd As New MySqlCommand("DELETE FROM BookCopies WHERE copy_id = @c", conn)
                        cmd.Parameters.AddWithValue("@c", selectedCopyId)
                        cmd.ExecuteNonQuery()
                    End Using
                    DBConnection.LogActivity("Delete Book Copy", "Deleted book no. " & selectedCopyId)
                End If
            End Using
        Catch ex As Exception
            MsgBox("Could not remove the copy: " & ex.Message, vbCritical, "Book Inventory")
            Exit Sub
        End Try

        MsgBox("Done.", vbInformation, "Book Inventory")
        LoadCopies()
        ClearFields()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If UiHelpers.Confirm("clear", "all fields", "Book Inventory") Then ClearFields()
    End Sub

    Private Sub ClearFields()
        selectedCopyId = 0
        txtBookNo.Clear()
        txtAccession.Clear()
        txtIsbn.Clear()
        txtTitle.Clear()
        txtStatus.Clear()
        cboCondition.SelectedIndex = -1
        numCopies.Value = 1
        dgvCopies.ClearSelection()
        txtIsbn.Focus()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        BorrowData.ExportGridToCsv(dgvCopies, "Book_Inventory")
    End Sub
End Class