Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class frmBookManagement

    Private ReadOnly authorSeps() As Char = {"&"c, ";"c}
    Private ReadOnly categorySeps() As Char = {","c, ";"c}
    Private selectedBookId As Integer = 0
    Private pager As GridPager

    Private Class BookInput
        Public Isbn As String
        Public Title As String
        Public Publisher As String
        Public Edition As String
        Public Authors As List(Of String)
        Public Categories As List(Of String)
        Public Year As Integer
        Public Price As Decimal
    End Class

    Private Sub frmBookManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupGrid()
        UiHelpers.FillHeader(Me)

        ' Optional "Import Excel" button, wired if the designer added one named btnImport
        Dim found() As Control = Me.Controls.Find("btnImport", True)
        If found.Length > 0 Then AddHandler found(0).Click, AddressOf btnImport_Click

        LoadBooks()
    End Sub

    Private Sub frmBookManagement_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then LoadBooks(txtSearch.Text)
    End Sub

    Private Sub SetupGrid()
        With DataGridView1
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            If Not .Columns.Contains("Copies") Then .Columns.Add("Copies", "Copies")
            If Not .Columns.Contains("Available") Then .Columns.Add("Available", "Available")
        End With
    End Sub

    ' ------------------------------------------------------------ list
    ' Search matches ISBN, title, author, publisher, category, edition and year published.
    Public Sub LoadBooks(Optional keyword As String = "")
        SetupGrid()
        If pager Is Nothing Then pager = PagerHelper.Create(DataGridView1)
        DataGridView1.Rows.Clear()
        Dim kw As String = If(keyword, "").Trim()

        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT v.book_id, v.isbn, v.title, v.authors, v.publisher_name, v.categories, v.edition, " &
                    "       v.year_published, v.price, b.date_added, v.total_copies, v.available_copies " &
                    "FROM vw_BookCatalog v JOIN BookInfo b ON b.book_id = v.book_id " &
                    "WHERE " & BookData.BookSearchSql("v") & " " &
                    "AND (EXISTS (SELECT 1 FROM BookCopies c WHERE c.book_id = v.book_id AND c.copy_status <> 'Archived') " &
                    "     OR NOT EXISTS (SELECT 1 FROM BookCopies c WHERE c.book_id = v.book_id)) " &
                    "ORDER BY v.title", conn)
                    cmd.Parameters.AddWithValue("@kw", kw)

                    Using r As MySqlDataReader = cmd.ExecuteReader()
                        While r.Read()
                            Dim i As Integer = DataGridView1.Rows.Add()
                            Dim row As DataGridViewRow = DataGridView1.Rows(i)
                            row.Cells("BookID").Value = r("book_id").ToString()
                            row.Cells("ISBN").Value = r("isbn").ToString()
                            row.Cells("BookTitle").Value = r("title").ToString()
                            row.Cells("BookAuthor").Value = If(IsDBNull(r("authors")), "", r("authors").ToString())
                            row.Cells("Publisher").Value = If(IsDBNull(r("publisher_name")), "", r("publisher_name").ToString())
                            row.Cells("Category").Value = If(IsDBNull(r("categories")), "", r("categories").ToString())
                            row.Cells("Edition").Value = If(IsDBNull(r("edition")), "", r("edition").ToString())
                            row.Cells("YearPublished").Value = If(IsDBNull(r("year_published")), "", r("year_published").ToString())
                            row.Cells("Price").Value = If(IsDBNull(r("price")), "", Convert.ToDecimal(r("price")).ToString("0.00"))
                            row.Cells("DateAdded").Value = If(IsDBNull(r("date_added")), "", Convert.ToDateTime(r("date_added")).ToString("MM/dd/yyyy"))
                            row.Cells("Copies").Value = r("total_copies").ToString()
                            row.Cells("Available").Value = r("available_copies").ToString()
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not load books: " & ex.Message, vbCritical, "Book Management")
        End Try
        DataGridView1.ClearSelection()
        pager.Apply()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadBooks(txtSearch.Text)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        selectedBookId = Convert.ToInt32(row.Cells("BookID").Value)
        txtISBN.Text = Convert.ToString(row.Cells("ISBN").Value)
        txtTitle.Text = Convert.ToString(row.Cells("BookTitle").Value)
        txtAuthor.Text = Convert.ToString(row.Cells("BookAuthor").Value)
        txtPublisher.Text = Convert.ToString(row.Cells("Publisher").Value)
        cboCategory.Text = Convert.ToString(row.Cells("Category").Value)
        txtEdition.Text = Convert.ToString(row.Cells("Edition").Value)
        txtYearPublished.Text = Convert.ToString(row.Cells("YearPublished").Value)
        txtPrice.Text = Convert.ToString(row.Cells("Price").Value)
    End Sub

    ' ------------------------------------------------------------ validation
    Private Function ReadInput() As BookInput
        If String.IsNullOrWhiteSpace(txtISBN.Text) OrElse String.IsNullOrWhiteSpace(txtTitle.Text) OrElse
           String.IsNullOrWhiteSpace(txtAuthor.Text) OrElse String.IsNullOrWhiteSpace(txtPublisher.Text) OrElse
           String.IsNullOrWhiteSpace(cboCategory.Text) OrElse String.IsNullOrWhiteSpace(txtEdition.Text) OrElse
           String.IsNullOrWhiteSpace(txtYearPublished.Text) OrElse String.IsNullOrWhiteSpace(txtPrice.Text) Then
            MsgBox("Please fill in all fields.", vbExclamation, "Book Management")
            Return Nothing
        End If

        If Not Regex.IsMatch(txtISBN.Text.Trim(), "^978\d{10}$") Then
            MsgBox("ISBN must be exactly 13 digits and start with 978.", vbExclamation, "Book Management")
            Return Nothing
        End If

        Dim authors = BookData.ParseNames(txtAuthor.Text, authorSeps)
        If authors.Count < 1 OrElse authors.Count > 2 Then
            MsgBox("A book can have 1 or 2 authors. Separate two authors with & (example: Kurose & Ross).", vbExclamation, "Book Management")
            Return Nothing
        End If
        For Each a As String In authors
            If Not Regex.IsMatch(a, "^[\p{L}\s\.\-']+$") OrElse a.Length > 150 Then
                MsgBox("Author name '" & a & "' contains invalid characters.", vbExclamation, "Book Management")
                Return Nothing
            End If
        Next

        Dim cats = BookData.ParseNames(cboCategory.Text, categorySeps)
        If cats.Count < 1 Then
            MsgBox("Please enter at least one category (separate several with commas).", vbExclamation, "Book Management")
            Return Nothing
        End If

        Dim yr As Integer
        If Not Integer.TryParse(txtYearPublished.Text.Trim(), yr) OrElse yr < 1901 OrElse yr > DateTime.Now.Year Then
            MsgBox("Year Published must be between 1901 and " & DateTime.Now.Year & ".", vbExclamation, "Book Management")
            Return Nothing
        End If

        Dim pr As Decimal
        If Not Decimal.TryParse(txtPrice.Text.Trim(), pr) OrElse pr <= 0 Then
            MsgBox("Price must be greater than zero.", vbExclamation, "Book Management")
            Return Nothing
        End If

        If txtTitle.Text.Trim().Length > 255 OrElse txtPublisher.Text.Trim().Length > 150 OrElse txtEdition.Text.Trim().Length > 50 Then
            MsgBox("Title (255), Publisher (150) or Edition (50) is too long.", vbExclamation, "Book Management")
            Return Nothing
        End If

        Dim inp As New BookInput()
        inp.Isbn = txtISBN.Text.Trim()
        inp.Title = txtTitle.Text.Trim()
        inp.Publisher = txtPublisher.Text.Trim()
        inp.Edition = txtEdition.Text.Trim()
        inp.Authors = authors
        inp.Categories = cats
        inp.Year = yr
        inp.Price = pr
        Return inp
    End Function

    ' ------------------------------------------------------------ add
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim inp As BookInput = ReadInput()
        If inp Is Nothing Then Exit Sub
        If Not UiHelpers.Confirm("add", "this book", "Book Management") Then Exit Sub

        Dim copyText As String = InputBox("How many physical copies are you adding?", "Book Management", "1")
        If copyText = "" Then Exit Sub
        Dim copies As Integer
        If Not Integer.TryParse(copyText, copies) OrElse copies < 1 OrElse copies > 100 Then
            MsgBox("Enter a number of copies from 1 to 100.", vbExclamation, "Book Management")
            Exit Sub
        End If

        Dim addedToExisting As Boolean = False
        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using tx As MySqlTransaction = conn.BeginTransaction()
                    Try
                        Dim bookId As Integer = BookData.FindBookIdByIsbn(conn, tx, inp.Isbn)

                        If bookId > 0 Then
                            If MsgBox("ISBN " & inp.Isbn & " is already in the catalog." & vbCrLf &
                                      "Add " & copies & " more copy/copies to it?",
                                      vbQuestion + vbYesNo, "Book Management") = vbNo Then
                                tx.Rollback()
                                Exit Sub
                            End If
                            addedToExisting = True
                        Else
                            Using ins As New MySqlCommand(
                                "INSERT INTO BookInfo (isbn, title, publisher_id, edition, year_published, price) " &
                                "VALUES (@i, @t, @p, @e, @y, @pr)", conn, tx)
                                ins.Parameters.AddWithValue("@i", inp.Isbn)
                                ins.Parameters.AddWithValue("@t", inp.Title)
                                ins.Parameters.AddWithValue("@p", BookData.PublisherIdOrNull(conn, tx, inp.Publisher))
                                ins.Parameters.AddWithValue("@e", inp.Edition)
                                ins.Parameters.AddWithValue("@y", inp.Year)
                                ins.Parameters.AddWithValue("@pr", inp.Price)
                                ins.ExecuteNonQuery()
                                bookId = Convert.ToInt32(ins.LastInsertedId)
                            End Using
                            BookData.SetAuthors(conn, tx, bookId, inp.Authors)
                            BookData.SetCategories(conn, tx, bookId, inp.Categories)
                        End If

                        BookData.AddCopies(conn, tx, bookId, copies)
                        tx.Commit()
                    Catch
                        tx.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not add the book: " & ex.Message, vbCritical, "Book Management")
            Exit Sub
        End Try

        DBConnection.LogActivity("Add Book", If(addedToExisting, "Added " & copies & " copy/copies to '", "Added '") &
                                   inp.Title & "' (ISBN " & inp.Isbn & ")" & If(addedToExisting, "", " with " & copies & " copy/copies"))
        MsgBox("Saved successfully!", vbInformation, "Book Management")
        LoadBooks()
        ClearFields()
    End Sub

    ' ------------------------------------------------------------ update
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedBookId = 0 Then
            MsgBox("Please select a book to update.", vbExclamation, "Book Management")
            Exit Sub
        End If
        Dim inp As BookInput = ReadInput()
        If inp Is Nothing Then Exit Sub
        If Not UiHelpers.Confirm("update", "this book", "Book Management") Then Exit Sub

        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using tx As MySqlTransaction = conn.BeginTransaction()
                    Try
                        Using chk As New MySqlCommand("SELECT COUNT(*) FROM BookInfo WHERE isbn = @i AND book_id <> @b", conn, tx)
                            chk.Parameters.AddWithValue("@i", inp.Isbn)
                            chk.Parameters.AddWithValue("@b", selectedBookId)
                            If Convert.ToInt32(chk.ExecuteScalar()) > 0 Then
                                MsgBox("Another book already uses this ISBN.", vbExclamation, "Book Management")
                                tx.Rollback()
                                Exit Sub
                            End If
                        End Using

                        Using upd As New MySqlCommand(
                            "UPDATE BookInfo SET isbn=@i, title=@t, publisher_id=@p, edition=@e, year_published=@y, price=@pr " &
                            "WHERE book_id=@b", conn, tx)
                            upd.Parameters.AddWithValue("@i", inp.Isbn)
                            upd.Parameters.AddWithValue("@t", inp.Title)
                            upd.Parameters.AddWithValue("@p", BookData.PublisherIdOrNull(conn, tx, inp.Publisher))
                            upd.Parameters.AddWithValue("@e", inp.Edition)
                            upd.Parameters.AddWithValue("@y", inp.Year)
                            upd.Parameters.AddWithValue("@pr", inp.Price)
                            upd.Parameters.AddWithValue("@b", selectedBookId)
                            upd.ExecuteNonQuery()
                        End Using
                        BookData.SetAuthors(conn, tx, selectedBookId, inp.Authors)
                        BookData.SetCategories(conn, tx, selectedBookId, inp.Categories)
                        tx.Commit()
                    Catch
                        tx.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not update the book: " & ex.Message, vbCritical, "Book Management")
            Exit Sub
        End Try

        DBConnection.LogActivity("Update Book", "Updated '" & inp.Title & "' (ISBN " & inp.Isbn & ")")
        MsgBox("Book updated successfully!", vbInformation, "Book Management")
        LoadBooks()
        ClearFields()
    End Sub

    ' ------------------------------------------------------------ delete / archive
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedBookId = 0 Then
            MsgBox("Please select a book to delete.", vbExclamation, "Book Management")
            Exit Sub
        End If
        Dim title As String = txtTitle.Text

        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()

                Dim borrowedNow As Integer, history As Integer
                Using cmd As New MySqlCommand(
                    "SELECT COUNT(*) FROM BorrowTransaction t JOIN BookCopies c ON c.copy_id = t.copy_id " &
                    "WHERE c.book_id = @b AND t.transaction_status = 'Borrowed'", conn)
                    cmd.Parameters.AddWithValue("@b", selectedBookId)
                    borrowedNow = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
                If borrowedNow > 0 Then
                    MsgBox("This book cannot be removed because one or more copies are currently borrowed.", vbExclamation, "Book Management")
                    Exit Sub
                End If

                Using cmd As New MySqlCommand(
                    "SELECT COUNT(*) FROM BorrowTransaction t JOIN BookCopies c ON c.copy_id = t.copy_id " &
                    "WHERE c.book_id = @b", conn)
                    cmd.Parameters.AddWithValue("@b", selectedBookId)
                    history = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                If history > 0 Then
                    If MsgBox("'" & title & "' has borrow history, so it will be ARCHIVED (hidden from the catalog; history is kept)." &
                              vbCrLf & "Continue?", vbQuestion + vbYesNo, "Confirm Archive") = vbNo Then Exit Sub
                    Using cmd As New MySqlCommand("UPDATE BookCopies SET copy_status = 'Archived' WHERE book_id = @b", conn)
                        cmd.Parameters.AddWithValue("@b", selectedBookId)
                        cmd.ExecuteNonQuery()
                    End Using
                    DBConnection.LogActivity("Archive Book", "Archived '" & title & "'")
                Else
                    If MsgBox("Are you sure you want to delete '" & title & "'?", vbQuestion + vbYesNo, "Confirm Delete") = vbNo Then Exit Sub
                    Using cmd As New MySqlCommand("DELETE FROM BookInfo WHERE book_id = @b", conn)
                        cmd.Parameters.AddWithValue("@b", selectedBookId)
                        cmd.ExecuteNonQuery()
                    End Using
                    DBConnection.LogActivity("Delete Book", "Deleted '" & title & "'")
                End If
            End Using
        Catch ex As Exception
            MsgBox("Could not remove the book: " & ex.Message, vbCritical, "Book Management")
            Exit Sub
        End Try

        MsgBox("Done.", vbInformation, "Book Management")
        LoadBooks()
        ClearFields()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If MsgBox("Are you sure you want to clear all fields?", vbQuestion + vbYesNo, "Book Management") = vbYes Then
            ClearFields()
        End If
    End Sub

    Private Sub ClearFields()
        selectedBookId = 0
        txtISBN.Clear()
        txtTitle.Clear()
        txtAuthor.Clear()
        txtPublisher.Clear()
        cboCategory.Text = ""
        cboCategory.SelectedIndex = -1
        txtEdition.Clear()
        txtYearPublished.Clear()
        txtPrice.Clear()
        DataGridView1.ClearSelection()
        txtISBN.Focus()
    End Sub

    ' ------------------------------------------------------------ Excel import
    Private Sub btnImport_Click(sender As Object, e As EventArgs)
        Using dlg As New OpenFileDialog()
            dlg.Filter = "Excel Files|*.xlsx"
            dlg.Title = "Select Excel File to Import Books"
            If dlg.ShowDialog() <> DialogResult.OK Then Exit Sub

            Try
                Dim rows = ExcelImporter.ReadXlsxRows(dlg.FileName)
                If rows.Count < 2 Then
                    MsgBox("The file has no data to import.", vbExclamation, "Import")
                    Exit Sub
                End If

                Dim h = rows(0)
                Dim cIsbn = ExcelImporter.FindColumn(h, "isbn")
                Dim cTitle = ExcelImporter.FindColumn(h, "title")
                Dim cAuthor = ExcelImporter.FindColumn(h, "author")
                Dim cPub = ExcelImporter.FindColumn(h, "publisher")
                Dim cEdition = ExcelImporter.FindColumn(h, "edition")
                Dim cYear = ExcelImporter.FindColumn(h, "year published")
                If cYear = -1 Then cYear = ExcelImporter.FindColumn(h, "year_published")
                Dim cCat = ExcelImporter.FindColumn(h, "category")
                Dim cPrice = ExcelImporter.FindColumn(h, "price")
                Dim cCopies = ExcelImporter.FindColumn(h, "copies")

                If cIsbn = -1 OrElse cTitle = -1 Then
                    MsgBox("The file must at least contain ISBN and Title columns.", vbExclamation, "Import")
                    Exit Sub
                End If

                Dim newBooks As Integer = 0, copiesAdded As Integer = 0, skippedExisting As Integer = 0, invalidRows As Integer = 0

                Using conn = DBConnection.GetConnection()
                    conn.Open()
                    Using tx As MySqlTransaction = conn.BeginTransaction()
                        Try
                            For i As Integer = 1 To rows.Count - 1
                                Dim row = rows(i)
                                Dim isbn As String = Cell(row, cIsbn)
                                Dim title As String = Cell(row, cTitle)
                                If isbn = "" AndAlso title = "" Then Continue For
                                If Not Regex.IsMatch(isbn, "^\d{13}$") OrElse title = "" Then
                                    invalidRows += 1
                                    Continue For
                                End If

                                Dim copies As Integer = 1
                                If cCopies <> -1 Then
                                    If Not Integer.TryParse(Cell(row, cCopies), copies) OrElse copies < 0 OrElse copies > 100 Then copies = 1
                                End If

                                Dim bookId As Integer = BookData.FindBookIdByIsbn(conn, tx, isbn)
                                If bookId > 0 Then
                                    If cCopies <> -1 AndAlso copies > 0 Then
                                        BookData.AddCopies(conn, tx, bookId, copies)
                                        copiesAdded += copies
                                    Else
                                        skippedExisting += 1
                                    End If
                                    Continue For
                                End If

                                Dim authors = BookData.ParseNames(Cell(row, cAuthor), authorSeps)
                                If authors.Count > 2 Then authors = authors.GetRange(0, 2)
                                Dim cats = BookData.ParseNames(Cell(row, cCat), categorySeps)

                                Dim yr As Integer
                                Dim yearObj As Object = DBNull.Value
                                If Integer.TryParse(Cell(row, cYear), yr) AndAlso yr >= 1901 AndAlso yr <= DateTime.Now.Year Then yearObj = yr
                                Dim pr As Decimal
                                Dim priceObj As Object = DBNull.Value
                                If Decimal.TryParse(Cell(row, cPrice), pr) AndAlso pr > 0 Then priceObj = pr

                                Using ins As New MySqlCommand(
                                    "INSERT INTO BookInfo (isbn, title, publisher_id, edition, year_published, price) " &
                                    "VALUES (@i, @t, @p, @e, @y, @pr)", conn, tx)
                                    ins.Parameters.AddWithValue("@i", isbn)
                                    ins.Parameters.AddWithValue("@t", title)
                                    ins.Parameters.AddWithValue("@p", BookData.PublisherIdOrNull(conn, tx, Cell(row, cPub)))
                                    ins.Parameters.AddWithValue("@e", Cell(row, cEdition))
                                    ins.Parameters.AddWithValue("@y", yearObj)
                                    ins.Parameters.AddWithValue("@pr", priceObj)
                                    ins.ExecuteNonQuery()
                                    bookId = Convert.ToInt32(ins.LastInsertedId)
                                End Using
                                If authors.Count > 0 Then BookData.SetAuthors(conn, tx, bookId, authors)
                                If cats.Count > 0 Then BookData.SetCategories(conn, tx, bookId, cats)
                                BookData.AddCopies(conn, tx, bookId, Math.Max(copies, 1))
                                newBooks += 1
                                copiesAdded += Math.Max(copies, 1)
                            Next
                            tx.Commit()
                        Catch
                            tx.Rollback()
                            Throw
                        End Try
                    End Using
                End Using

                DBConnection.LogActivity("Import Books", newBooks & " new book(s), " & copiesAdded & " copy/copies imported from Excel.")
                MsgBox("Import finished." & vbCrLf &
                       "New books: " & newBooks & vbCrLf &
                       "Copies added: " & copiesAdded & vbCrLf &
                       "Existing ISBNs skipped: " & skippedExisting & vbCrLf &
                       "Invalid rows skipped: " & invalidRows, vbInformation, "Import")
                LoadBooks()
            Catch ex As Exception
                MsgBox("Error importing file: " & ex.Message, vbCritical, "Import Error")
            End Try
        End Using
    End Sub

    Private Function Cell(row As List(Of String), index As Integer) As String
        If index < 0 Then Return ""
        Return If(ExcelImporter.GetCell(row, index), "").Trim()
    End Function
End Class