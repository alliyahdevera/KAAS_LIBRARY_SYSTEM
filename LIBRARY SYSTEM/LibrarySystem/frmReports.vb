Imports MySql.Data.MySqlClient

Public Class frmReports

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DashboardData.SetupReadOnlyGrid(DataGridView1)
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker2.Format = DateTimePickerFormat.Short
        DateTimePicker1.Value = New Date(Date.Today.Year, Date.Today.Month, 1)
        DateTimePicker2.Value = Date.Today
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnGenerateReport.PerformClick()
        End If
    End Sub

    Private Sub btnGenerateReport_Click(sender As Object, e As EventArgs) Handles btnGenerateReport.Click
        Dim fromDate As Date = DateTimePicker1.Value.Date
        Dim toDate As Date = DateTimePicker2.Value.Date
        If fromDate > toDate Then
            MsgBox("'Date From' cannot be later than 'To'.", vbExclamation, "Reports")
            Exit Sub
        End If

        DataGridView1.Rows.Clear()
        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    DashboardData.RecordsSelect & DashboardData.RecordsFrom &
                    "WHERE t.borrow_date BETWEEN @f AND @t " &
                    "AND (@kw = '' OR v.isbn LIKE CONCAT('%',@kw,'%') OR v.title LIKE CONCAT('%',@kw,'%')) " &
                    "ORDER BY t.borrow_date, t.transaction_id", conn)
                    cmd.Parameters.AddWithValue("@f", fromDate)
                    cmd.Parameters.AddWithValue("@t", toDate)
                    cmd.Parameters.AddWithValue("@kw", TextBox1.Text.Trim())
                    Using r As MySqlDataReader = cmd.ExecuteReader()
                        While r.Read()
                            DashboardData.AddRecordRow(DataGridView1, r)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not generate the report: " & ex.Message, vbCritical, "Reports")
            Exit Sub
        End Try
        DataGridView1.ClearSelection()

        DBConnection.LogActivity("Generate Report", "Report " & fromDate.ToString("MM/dd/yyyy") & " to " & toDate.ToString("MM/dd/yyyy") &
                                 " (" & DataGridView1.Rows.Count & " records)")

        If DataGridView1.Rows.Count = 0 Then
            MsgBox("No records found for that date range.", vbInformation, "Reports")
        ElseIf MsgBox(DataGridView1.Rows.Count & " record(s) found. Export to CSV (opens in Excel)?",
                      vbQuestion + vbYesNo, "Reports") = vbYes Then
            BorrowData.ExportGridToCsv(DataGridView1, "Borrow_Report")
        End If
    End Sub
End Class