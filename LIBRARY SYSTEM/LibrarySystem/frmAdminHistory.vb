Imports MySql.Data.MySqlClient

Public Class frmAdminHistory

    Private Sub frmAdminHistory_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Not Me.Visible Then Exit Sub
        UiHelpers.FillHeader(Me)
        DashboardData.SetupReadOnlyGrid(DataGridView1)
        LoadRecords(txtSearch.Text)
    End Sub

    Public Sub LoadRecords(Optional keyword As String = "")
        DataGridView1.Rows.Clear()
        Dim kw As String = If(keyword, "").Trim()
        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    DashboardData.RecordsSelect & DashboardData.RecordsFrom &
                    "WHERE (@kw = '' OR v.isbn LIKE CONCAT('%',@kw,'%') OR v.title LIKE CONCAT('%',@kw,'%') " &
                    " OR v.authors LIKE CONCAT('%',@kw,'%') OR u.username LIKE CONCAT('%',@kw,'%') " &
                    " OR m.member_type LIKE CONCAT('%',@kw,'%') OR (" & BorrowData.StatusSql & ") LIKE CONCAT('%',@kw,'%')) " &
                    "ORDER BY t.borrow_date DESC, t.transaction_id DESC", conn)
                    cmd.Parameters.AddWithValue("@kw", kw)
                    Using r As MySqlDataReader = cmd.ExecuteReader()
                        While r.Read()
                            DashboardData.AddRecordRow(DataGridView1, r)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not load records: " & ex.Message, vbCritical, "Borrow History Records")
        End Try
        DataGridView1.ClearSelection()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadRecords(txtSearch.Text)
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        BorrowData.ExportGridToCsv(DataGridView1, "All_Borrow_History")
    End Sub
End Class