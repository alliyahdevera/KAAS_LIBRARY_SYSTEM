Imports MySql.Data.MySqlClient

Public Class frmAvailBooks

    Private Sub frmAvailBooks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupGrid()
        UiHelpers.FillHeader(Me)
        LoadAvailableBooks()
    End Sub

    Private Sub frmAvailBooks_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then LoadAvailableBooks(TextBox1.Text)
    End Sub

    Private Sub SetupGrid()
        With DataGridView1
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub

    Public Sub LoadAvailableBooks(Optional keyword As String = "")
        SetupGrid()
        DataGridView1.Rows.Clear()
        Dim kw As String = If(keyword, "").Trim()

        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT isbn, title, authors, publisher_name, categories, edition, year_published, price, available_copies " &
                    "FROM vw_BookCatalog " &
                    "WHERE available_copies > 0 " &
                    "AND " & BookData.BookSearchSql() & " " &
                    "ORDER BY title", conn)
                    cmd.Parameters.AddWithValue("@kw", kw)

                    Using r As MySqlDataReader = cmd.ExecuteReader()
                        While r.Read()
                            Dim i As Integer = DataGridView1.Rows.Add()
                            Dim row As DataGridViewRow = DataGridView1.Rows(i)
                            row.Cells("ISBN").Value = r("isbn").ToString()
                            row.Cells("BookTitle").Value = r("title").ToString()
                            row.Cells("BookAuthor").Value = If(IsDBNull(r("authors")), "", r("authors").ToString())
                            row.Cells("Publisher").Value = If(IsDBNull(r("publisher_name")), "", r("publisher_name").ToString())
                            row.Cells("Category").Value = If(IsDBNull(r("categories")), "", r("categories").ToString())
                            row.Cells("Edition").Value = If(IsDBNull(r("edition")), "", r("edition").ToString())
                            row.Cells("YearPublished").Value = If(IsDBNull(r("year_published")), "", r("year_published").ToString())
                            row.Cells("Price").Value = If(IsDBNull(r("price")), "", Convert.ToDecimal(r("price")).ToString("0.00"))
                            row.Cells("Copies").Value = r("available_copies").ToString()
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not load books: " & ex.Message, vbCritical, "Available Books")
        End Try
        DataGridView1.ClearSelection()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        LoadAvailableBooks(TextBox1.Text)
    End Sub
End Class