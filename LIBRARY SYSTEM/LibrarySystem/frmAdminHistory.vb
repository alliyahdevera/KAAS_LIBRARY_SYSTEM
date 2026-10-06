Imports MySql.Data.MySqlClient

Public Class frmAdminHistory

    Private useDateRange As Boolean = False

    Private Sub frmAdminHistory_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Not Me.Visible Then Exit Sub
        UiHelpers.FillHeader(Me)
        DashboardData.SetupReadOnlyGrid(DataGridView1)

        useDateRange = False                                   ' every visit starts with all records
        DateTimePicker1.Value = New Date(Date.Today.Year, Date.Today.Month, 1)   ' 1st of this month
        DateTimePicker2.Value = Date.Today

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
                    "AND (@useDates = 0 OR t.borrow_date BETWEEN @fromDate AND @toDate) " &
                    "ORDER BY t.borrow_date DESC, t.transaction_id DESC", conn)
                    cmd.Parameters.AddWithValue("@kw", kw)
                    cmd.Parameters.AddWithValue("@useDates", If(useDateRange, 1, 0))
                    cmd.Parameters.AddWithValue("@fromDate", DateTimePicker1.Value.Date)
                    cmd.Parameters.AddWithValue("@toDate", DateTimePicker2.Value.Date)
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

    Private Sub btnGenerateReport_Click(sender As Object, e As EventArgs) Handles btnGenerateReport.Click
        If DateTimePicker1.Value.Date > DateTimePicker2.Value.Date Then
            MsgBox("'Date From' cannot be later than 'To'.", vbExclamation, "Borrow History Records")
            Exit Sub
        End If

        useDateRange = True
        LoadRecords(txtSearch.Text)

        If DataGridView1.Rows.Count = 0 Then
            MsgBox("No borrow records found between " & DateTimePicker1.Value.ToString("MM/dd/yyyy") &
                   " and " & DateTimePicker2.Value.ToString("MM/dd/yyyy") & ".",
                   vbInformation, "Borrow History Records")
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadRecords(txtSearch.Text)
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        Dim name As String = "All_Borrow_History"
        If useDateRange Then
            name &= "_" & DateTimePicker1.Value.ToString("yyyyMMdd") & "_to_" & DateTimePicker2.Value.ToString("yyyyMMdd")
        End If
        BorrowData.ExportGridToCsv(DataGridView1, name)
    End Sub
End Class