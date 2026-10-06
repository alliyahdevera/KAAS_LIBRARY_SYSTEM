Imports MySql.Data.MySqlClient

Public Class frmStudentHistory

    Private Sub frmStudentHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UiHelpers.FillHeader(Me)
        SetupGrid()
        LoadHistory()
    End Sub

    Private Sub frmStudentHistory_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then LoadHistory(txtSearch.Text)
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

    Public Sub LoadHistory(Optional keyword As String = "")
        DataGridView1.Rows.Clear()
        If Not AppSession.MemberId.HasValue Then Exit Sub
        Dim kw As String = If(keyword, "").Trim()

        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT v.isbn, v.title, v.authors, v.publisher_name, v.edition, t.borrow_date, t.due_date, t.return_date, " &
                    BorrowData.StatusSql & " AS status, t.return_condition, IFNULL(p.penalty_status, 'None') AS pen " &
                    "FROM BorrowTransaction t " &
                    "JOIN BookCopies c ON c.copy_id = t.copy_id " &
                    "JOIN vw_BookCatalog v ON v.book_id = c.book_id " &
                    "LEFT JOIN Penalty p ON p.transaction_id = t.transaction_id " &
                    "WHERE t.member_id = @m AND (@kw = '' OR v.isbn LIKE CONCAT('%',@kw,'%') OR v.title LIKE CONCAT('%',@kw,'%') " &
                    "   OR v.authors LIKE CONCAT('%',@kw,'%') OR (" & BorrowData.StatusSql & ") LIKE CONCAT('%',@kw,'%')) " &
                    "ORDER BY t.borrow_date DESC, t.transaction_id DESC", conn)
                    cmd.Parameters.AddWithValue("@m", AppSession.MemberId.Value)
                    cmd.Parameters.AddWithValue("@kw", kw)
                    Using r As MySqlDataReader = cmd.ExecuteReader()
                        While r.Read()
                            Dim isReturned As Boolean = Not IsDBNull(r("return_date"))
                            Dim cond As String
                            If Not IsDBNull(r("return_condition")) Then
                                cond = r("return_condition").ToString()
                            ElseIf isReturned Then
                                cond = "Pending"
                            Else
                                cond = "-"
                            End If

                            Dim row As DataGridViewRow = DataGridView1.Rows(DataGridView1.Rows.Add())
                            row.Cells("DataGridViewTextBoxColumn1").Value = r("isbn").ToString()
                            row.Cells("BookTitle").Value = r("title").ToString()
                            row.Cells("BookAuthor").Value = If(IsDBNull(r("authors")), "", r("authors").ToString())
                            row.Cells("DataGridViewTextBoxColumn2").Value = If(IsDBNull(r("publisher_name")), "", r("publisher_name").ToString())
                            row.Cells("DataGridViewTextBoxColumn3").Value = If(IsDBNull(r("edition")), "", r("edition").ToString())
                            row.Cells("BorrowDate").Value = Convert.ToDateTime(r("borrow_date")).ToString("MM/dd/yyyy")
                            row.Cells("hDueDate").Value = Convert.ToDateTime(r("due_date")).ToString("MM/dd/yyyy")
                            row.Cells("hReturnDate").Value = If(isReturned, Convert.ToDateTime(r("return_date")).ToString("MM/dd/yyyy"), "")
                            row.Cells("hBorrowStatus").Value = r("status").ToString()
                            row.Cells("hBookCondition").Value = cond
                            row.Cells("hPenaltyStatus").Value = r("pen").ToString()
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not load your history: " & ex.Message, vbCritical, "Borrow History")
        End Try
        DataGridView1.ClearSelection()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadHistory(txtSearch.Text)
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        BorrowData.ExportGridToCsv(DataGridView1, "My_Borrow_History")
    End Sub
End Class