Imports System.IO
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.FileIO
Imports MySql.Data.MySqlClient

Public Class frmBookManagement

    Private Sub frmBookManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        listviewBookManagement.View = View.Details
        listviewBookManagement.FullRowSelect = True
        listviewBookManagement.GridLines = True

        If listviewBookManagement.Columns.Count = 0 Then
            listviewBookManagement.Columns.Add("ISBN", 120)
            listviewBookManagement.Columns.Add("Title", 180)
            listviewBookManagement.Columns.Add("Author", 150)
            listviewBookManagement.Columns.Add("Copies", 80)
        End If

        LoadBooks()
    End Sub

    Public Sub LoadBooks(Optional keyword As String = "")
        listviewBookManagement.Items.Clear()
        Dim kw As String = If(keyword, "").Trim()

        Using conn = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New MySqlCommand(
        "SELECT book_id, isbn, title, author, publisher, category, edition, year_published, price, MAX(date_added) AS date_added, COUNT(book_id) AS copies FROM tbl_book " &
        "WHERE @kw = '' OR book_id LIKE CONCAT('%',@kw,'%') OR isbn LIKE CONCAT('%',@kw,'%') OR title LIKE CONCAT('%',@kw,'%') OR author LIKE CONCAT('%',@kw,'%') OR publisher LIKE CONCAT('%',@kw,'%') OR category LIKE CONCAT('%',@kw,'%') OR edition LIKE CONCAT('%',@kw,'%') OR year_published LIKE CONCAT('%',@kw,'%') OR price LIKE CONCAT('%',@kw,'%') " &
        "GROUP BY book_id, isbn, title, author, publisher, category, edition, year_published, price", conn)
            cmd.Parameters.AddWithValue("@kw", kw)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim item As New ListViewItem(reader("book_id").ToString())
                    item.SubItems.Add(reader("isbn").ToString())
                    item.SubItems.Add(reader("title").ToString())
                    item.SubItems.Add(reader("author").ToString())
                    item.SubItems.Add(reader("publisher").ToString())
                    item.SubItems.Add(reader("category").ToString())
                    item.SubItems.Add(reader("edition").ToString())
                    item.SubItems.Add(reader("year_published").ToString())
                    item.SubItems.Add(reader("price").ToString())
                    If Not IsDBNull(reader("date_added")) Then
                        item.SubItems.Add(Convert.ToDateTime(reader("date_added")).ToString("MM/dd/yyyy"))
                    Else
                        item.SubItems.Add("")
                    End If
                    listviewBookManagement.Items.Add(item)
                End While
            End Using
        End Using
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadBooks(txtSearch.Text)
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoadBooks(txtSearch.Text)
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrWhiteSpace(txtISBN.Text) OrElse
           String.IsNullOrWhiteSpace(txtTitle.Text) OrElse
           String.IsNullOrWhiteSpace(txtAuthor.Text) OrElse
           String.IsNullOrWhiteSpace(txtPublisher.Text) OrElse
           String.IsNullOrWhiteSpace(cboCategory.Text) OrElse
           String.IsNullOrWhiteSpace(txtEdition.Text) OrElse
           String.IsNullOrWhiteSpace(txtYearPublished.Text) OrElse
           String.IsNullOrWhiteSpace(txtPrice.Text) Then
            MsgBox("Please fill in all fields.", vbExclamation, "Book Management")
            Exit Sub
        End If

        If txtISBN.Text.Length <> 13 OrElse Not txtISBN.Text.StartsWith("978") OrElse Not IsNumeric(txtISBN.Text) Then
            MsgBox("ISBN must be exactly 13 digits and start with 978.", vbExclamation, "Book Management")
            Exit Sub
        End If

        If Not Regex.IsMatch(txtAuthor.Text, "^[a-zA-Z\s\.\-]+$") Then
            MsgBox("Author name contains invalid characters.", vbExclamation, "Book Management")
            Exit Sub
        End If

        Dim yearPublished As Integer
        If Not Integer.TryParse(txtYearPublished.Text, yearPublished) OrElse yearPublished < 1450 OrElse yearPublished > DateTime.Now.Year Then
            MsgBox("Year Published must be between 1450 and " & DateTime.Now.Year & ".", vbExclamation, "Book Management")
            Exit Sub
        End If

        Dim price As Decimal
        If Not Decimal.TryParse(txtPrice.Text, price) OrElse price <= 0 Then
            MsgBox("Price must be greater than zero.", vbExclamation, "Book Management")
            Exit Sub
        End If

        Using conn = DBConnection.GetConnection()
            conn.Open()

            Dim insertCmd As New MySqlCommand("INSERT INTO tbl_book (ISBN, Title, Author, Publisher, Category, Edition, Year_Published, Price, Date_Added) VALUES (@isbn, @title, @author, @publisher, @category, @edition, @yearPublished, @price, @dateAdded)", conn)

            insertCmd.Parameters.AddWithValue("@isbn", txtISBN.Text)
            insertCmd.Parameters.AddWithValue("@title", txtTitle.Text)
            insertCmd.Parameters.AddWithValue("@author", txtAuthor.Text)
            insertCmd.Parameters.AddWithValue("@publisher", txtPublisher.Text)
            insertCmd.Parameters.AddWithValue("@category", cboCategory.Text)
            insertCmd.Parameters.AddWithValue("@edition", txtEdition.Text)
            insertCmd.Parameters.AddWithValue("@yearPublished", yearPublished)
            insertCmd.Parameters.AddWithValue("@price", price)
            insertCmd.Parameters.AddWithValue("@dateAdded", DateTime.Now)
            insertCmd.ExecuteNonQuery()
            DBConnection.LogActivity("Add Book", "Added '" & txtTitle.Text & "' (ISBN " & txtISBN.Text & ")")
        End Using

        MsgBox("New book copy added successfully!", vbInformation, "Book Management")
        LoadBooks()
        ClearFields()
    End Sub

    Private Sub lvBooks_SelectedIndexChanged(sender As Object, e As EventArgs)
        If listviewBookManagement.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = listviewBookManagement.SelectedItems(0)

            ' 0 = book_id, 1 = isbn, 2 = title, 3 = author, 4 = publisher, 5 = category, 6 = edition, 7 = year_published, 8 = price
            txtISBN.Text = selectedItem.SubItems(1).Text
            txtTitle.Text = selectedItem.SubItems(2).Text
            txtAuthor.Text = selectedItem.SubItems(3).Text
            txtPublisher.Text = selectedItem.SubItems(4).Text
            cboCategory.Text = selectedItem.SubItems(5).Text
            txtEdition.Text = selectedItem.SubItems(6).Text
            txtYearPublished.Text = selectedItem.SubItems(7).Text
            txtPrice.Text = selectedItem.SubItems(8).Text
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If listviewBookManagement.SelectedItems.Count = 0 Then
            MsgBox("Please select a book to update.", vbExclamation, "Book Management")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtISBN.Text) OrElse
           String.IsNullOrWhiteSpace(txtTitle.Text) OrElse
           String.IsNullOrWhiteSpace(txtAuthor.Text) OrElse
           String.IsNullOrWhiteSpace(txtPublisher.Text) OrElse
           String.IsNullOrWhiteSpace(cboCategory.Text) OrElse
           String.IsNullOrWhiteSpace(txtEdition.Text) OrElse
           String.IsNullOrWhiteSpace(txtYearPublished.Text) OrElse
           String.IsNullOrWhiteSpace(txtPrice.Text) Then
            MsgBox("Please fill in all fields.", vbExclamation, "Book Management")
            Exit Sub
        End If

        If txtISBN.Text.Length <> 13 OrElse Not txtISBN.Text.StartsWith("978") OrElse Not IsNumeric(txtISBN.Text) Then
            MsgBox("ISBN must be exactly 13 digits and start with 978.", vbExclamation, "Book Management")
            Exit Sub
        End If

        If Not Regex.IsMatch(txtAuthor.Text, "^[a-zA-Z\s\.\-]+$") Then
            MsgBox("Author name contains invalid characters.", vbExclamation, "Book Management")
            Exit Sub
        End If

        Dim yearPublished As Integer
        If Not Integer.TryParse(txtYearPublished.Text, yearPublished) OrElse yearPublished < 1450 OrElse yearPublished > DateTime.Now.Year Then
            MsgBox("Year Published must be between 1450 and " & DateTime.Now.Year & ".", vbExclamation, "Book Management")
            Exit Sub
        End If

        Dim price As Decimal
        If Not Decimal.TryParse(txtPrice.Text, price) OrElse price <= 0 Then
            MsgBox("Price must be greater than zero.", vbExclamation, "Book Management")
            Exit Sub
        End If

        Dim selectedBookId As String = listviewBookManagement.SelectedItems(0).SubItems(0).Text

        Using conn = DBConnection.GetConnection()
            conn.Open()

            Dim updCmd As New MySqlCommand("UPDATE tbl_book SET ISBN=@isbn, Title=@title, Author=@author, Publisher=@publisher, Category=@category, Edition=@edition, Year_Published=@yearPublished, Price=@price WHERE book_id=@bookId", conn)
            updCmd.Parameters.AddWithValue("@isbn", txtISBN.Text)
            updCmd.Parameters.AddWithValue("@title", txtTitle.Text)
            updCmd.Parameters.AddWithValue("@author", txtAuthor.Text)
            updCmd.Parameters.AddWithValue("@publisher", txtPublisher.Text)
            updCmd.Parameters.AddWithValue("@category", cboCategory.Text)
            updCmd.Parameters.AddWithValue("@edition", txtEdition.Text)
            updCmd.Parameters.AddWithValue("@yearPublished", yearPublished)
            updCmd.Parameters.AddWithValue("@price", price)
            updCmd.Parameters.AddWithValue("@bookId", selectedBookId)
            updCmd.ExecuteNonQuery()
            DBConnection.LogActivity("Update Book", "Updated '" & txtTitle.Text & "' (ISBN " & txtISBN.Text & ")")
        End Using

        MsgBox("Book updated successfully!", vbInformation, "Book Management")
        LoadBooks()
        ClearFields()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If listviewBookManagement.SelectedItems.Count = 0 Then
            MsgBox("Please select a book to delete.", vbExclamation, "Book Management")
            Exit Sub
        End If

        Dim selectedISBN As String = listviewBookManagement.SelectedItems(0).SubItems(1).Text
        Dim selectedTitle As String = listviewBookManagement.SelectedItems(0).SubItems(2).Text

        Using conn = DBConnection.GetConnection()
            conn.Open()
            Dim checkCmd As New MySqlCommand(
            "SELECT COUNT(*) FROM tbl_transaction t JOIN tbl_book b ON b.book_id = t.book_id " &
            "WHERE b.isbn = @isbn AND t.return_date IS NULL", conn)
            checkCmd.Parameters.AddWithValue("@isbn", selectedISBN)
            If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                MsgBox("This book cannot be deleted because one or more copies are currently borrowed.", vbExclamation, "Book Management")
                Exit Sub
            End If

            If MsgBox("Are you sure you want to delete '" & selectedTitle & "'?", vbQuestion + vbYesNo, "Confirm Delete") = vbNo Then Exit Sub

            Dim delCmd As New MySqlCommand("DELETE FROM tbl_book WHERE isbn = @isbn", conn)
            delCmd.Parameters.AddWithValue("@isbn", selectedISBN)
            delCmd.ExecuteNonQuery()
            DBConnection.LogActivity("Delete Book", "Deleted '" & selectedTitle & "' (ISBN " & selectedISBN & ")")
        End Using

        MsgBox("Book deleted successfully!", vbInformation, "Book Management")
        LoadBooks()
        ClearFields()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If MsgBox("Are you sure you want to clear all fields?", vbQuestion + vbYesNo, "Book Management") = vbYes Then
            ClearFields()
        End If
    End Sub

    Private Sub ClearFields()
        txtISBN.Clear()
        txtTitle.Clear()
        txtAuthor.Clear()
        txtPublisher.Clear()
        cboCategory.ResetText()
        txtEdition.Clear()
        txtYearPublished.Clear()
        txtPrice.Clear()

        txtISBN.Focus()
    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs)
        If MsgBox("Are you sure you want to exit system?", vbQuestion + vbYesNo, "EXIT") = vbYes Then
            MsgBox("Thank you for using Library System!", vbInformation, "The KASS Library System")
            End
        End If
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        Me.Hide()
        If Form1.CurrentAccountType.Equals("Librarian", StringComparison.OrdinalIgnoreCase) Then
            frmLibrarianMenu.Show()
        Else
            frmAdminMenu.Show()
        End If
    End Sub
    Private Sub btnImportExcel_Click(sender As Object, e As EventArgs)
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Excel Files|*.xlsx"
            openFileDialog.Title = "Select Excel File to Import Books"

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filePath As String = openFileDialog.FileName

                Try
                    Dim rows = ExcelImporter.ReadXlsxRows(filePath)
                    If rows.Count < 2 Then
                        MsgBox("The file has no data to import.", vbExclamation, "Import")
                        Exit Sub
                    End If

                    Dim headers = rows(0)
                    Dim colISBN = ExcelImporter.FindColumn(headers, "isbn")
                    Dim colTitle = ExcelImporter.FindColumn(headers, "title")
                    Dim colAuthor = ExcelImporter.FindColumn(headers, "author")
                    Dim colPublisher = ExcelImporter.FindColumn(headers, "publisher")
                    Dim colEdition = ExcelImporter.FindColumn(headers, "edition")
                    Dim colYear = ExcelImporter.FindColumn(headers, "year published")
                    If colYear = -1 Then colYear = ExcelImporter.FindColumn(headers, "year_published")
                    Dim colCategory = ExcelImporter.FindColumn(headers, "category")
                    Dim colPrice = ExcelImporter.FindColumn(headers, "price")

                    If colISBN = -1 OrElse colTitle = -1 Then
                        MsgBox("The file must at least contain ISBN and Title columns.", vbExclamation, "Import")
                        Exit Sub
                    End If

                    Dim importedCount As Integer = 0

                    Using conn = DBConnection.GetConnection()
                        conn.Open()

                        For i As Integer = 1 To rows.Count - 1
                            Dim row = rows(i)

                            Dim isbn = ExcelImporter.GetCell(row, colISBN).Trim()
                            Dim title = ExcelImporter.GetCell(row, colTitle).Trim()
                            If String.IsNullOrWhiteSpace(isbn) OrElse String.IsNullOrWhiteSpace(title) Then Continue For

                            Dim author = ExcelImporter.GetCell(row, colAuthor).Trim()
                            Dim publisher = ExcelImporter.GetCell(row, colPublisher).Trim()
                            Dim edition = ExcelImporter.GetCell(row, colEdition).Trim()
                            Dim category = ExcelImporter.GetCell(row, colCategory).Trim()

                            Dim yearPublished As Integer
                            Integer.TryParse(ExcelImporter.GetCell(row, colYear).Trim(), yearPublished)

                            Dim price As Decimal
                            Decimal.TryParse(ExcelImporter.GetCell(row, colPrice).Trim(), price)

                            Using insertCmd As New MySqlCommand(
                                "INSERT INTO tbl_book (isbn, title, author, publisher, edition, year_published, category, price, date_added) " &
                                "VALUES (@isbn, @title, @author, @publisher, @edition, @year, @category, @price, @dateAdded)", conn)
                                insertCmd.Parameters.AddWithValue("@isbn", isbn)
                                insertCmd.Parameters.AddWithValue("@title", title)
                                insertCmd.Parameters.AddWithValue("@author", author)
                                insertCmd.Parameters.AddWithValue("@publisher", publisher)
                                insertCmd.Parameters.AddWithValue("@edition", edition)
                                insertCmd.Parameters.AddWithValue("@year", yearPublished)
                                insertCmd.Parameters.AddWithValue("@category", category)
                                insertCmd.Parameters.AddWithValue("@price", price)
                                insertCmd.Parameters.AddWithValue("@dateAdded", DateTime.Now)
                                insertCmd.ExecuteNonQuery()
                            End Using

                            importedCount += 1
                        Next
                    End Using

                    DBConnection.LogActivity("Import Books", importedCount & " book record(s) imported from Excel file.")
                    MsgBox("Successfully imported " & importedCount & " books from file!", vbInformation, "Import Success")
                    LoadBooks()

                Catch ex As Exception
                    MsgBox("Error importing file: " & ex.Message, vbCritical, "Import Error")
                End Try
            End If
        End Using
    End Sub

End Class