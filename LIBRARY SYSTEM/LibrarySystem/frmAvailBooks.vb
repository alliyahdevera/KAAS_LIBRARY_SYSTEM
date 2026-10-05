Imports System.Data
Imports MySql.Data.MySqlClient

Public Class frmAvailBooks

    Private Sub frmAvailBooks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        lvAvailBooks.View = View.Details
        lvAvailBooks.FullRowSelect = True
        lvAvailBooks.GridLines = True

        If lvAvailBooks.Columns.Count = 0 Then
            lvAvailBooks.Columns.Add("ISBN", 100)
            lvAvailBooks.Columns.Add("Title", 160)
            lvAvailBooks.Columns.Add("Author", 130)
            lvAvailBooks.Columns.Add("Publisher", 120)
            lvAvailBooks.Columns.Add("Category", 110)
            lvAvailBooks.Columns.Add("Edition", 80)
            lvAvailBooks.Columns.Add("Year Published", 100)
            lvAvailBooks.Columns.Add("Price", 80)
            lvAvailBooks.Columns.Add("Copies", 70)
        End If

        LoadAvailableBooks()
    End Sub

    Private Sub frmAvailBooks_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            LoadAvailableBooks()
        End If
    End Sub

    Public Sub LoadAvailableBooks(Optional keyword As String = "")
        lvAvailBooks.Items.Clear()
        Dim kw As String = If(keyword, "").Trim()

        Using conn = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New MySqlCommand(
                "SELECT b.isbn, b.title, b.author, b.publisher, b.category, b.edition, b.year_published, b.price, " &
                "COUNT(b.book_id) AS copies " &
                "FROM tbl_book b " &
                "WHERE b.book_id NOT IN (SELECT book_id FROM tbl_transaction WHERE return_date IS NULL) " &
                "AND (@kw = '' OR b.isbn LIKE CONCAT('%',@kw,'%') OR b.title LIKE CONCAT('%',@kw,'%') " &
                "     OR b.author LIKE CONCAT('%',@kw,'%') OR b.publisher LIKE CONCAT('%',@kw,'%') OR b.category LIKE CONCAT('%',@kw,'%')) " &
                "GROUP BY b.isbn, b.title, b.author, b.publisher, b.category, b.edition, b.year_published, b.price " &
                "HAVING copies > 0", conn)
            cmd.Parameters.AddWithValue("@kw", kw)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim item As New ListViewItem(reader("isbn").ToString())
                    item.SubItems.Add(reader("title").ToString())
                    item.SubItems.Add(reader("author").ToString())
                    item.SubItems.Add(reader("publisher").ToString())
                    item.SubItems.Add(reader("category").ToString())
                    item.SubItems.Add(reader("edition").ToString())
                    item.SubItems.Add(reader("year_published").ToString())
                    item.SubItems.Add(reader("price").ToString())
                    item.SubItems.Add(reader("copies").ToString())
                    lvAvailBooks.Items.Add(item)
                End While
            End Using
        End Using
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs)
        LoadAvailableBooks(txtSearch.Text)
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs)
        LoadAvailableBooks(txtSearch.Text)
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            LoadAvailableBooks(txtSearch.Text)
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub lvAvailBooks_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Handle selection if needed
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) 
        frmStudentMenu.Show()
        Me.Hide()
    End Sub

End Class
