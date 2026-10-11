Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmLibrarianDashboard

    Private Sub frmLibraryDashboard_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Not Me.Visible Then Exit Sub
        UiHelpers.FillHeader(Me)
        RefreshDashboard()
    End Sub

    Private Sub RefreshDashboard()
        Try
            lblissuedtoday.Text = DashboardData.Scalar("SELECT COUNT(*) FROM BorrowTransaction WHERE borrow_date = CURDATE()").ToString("N0")
            lblreturnedtoday.Text = DashboardData.Scalar("SELECT COUNT(*) FROM BorrowTransaction WHERE return_date = CURDATE()").ToString("N0")
            lbloverduebooks.Text = DashboardData.Scalar("SELECT COUNT(*) FROM BorrowTransaction WHERE transaction_status = 'Borrowed' AND due_date < CURDATE()").ToString("N0")
            ' "Books For Return" = books currently out on loan
            lblPendingReceipts.Text = DashboardData.Scalar("SELECT COUNT(*) FROM BorrowTransaction WHERE transaction_status = 'Borrowed'").ToString("N0")

            ' Unpaid vs Paid penalty - shown in pesos (all penalties, no school year filter)
            DashboardData.FillChart(Chart1, DashboardData.Table(
                "SELECT 'Unpaid', IFNULL(SUM(penalty_amount),0) FROM Penalty WHERE penalty_status IN ('Unpaid','Pending') " &
                "UNION ALL SELECT 'Paid', IFNULL(SUM(penalty_amount),0) FROM Penalty WHERE penalty_status = 'Paid'"),
                SeriesChartType.Doughnut, True, True)

            ' Recent Penalty (DataGridView)
            DashboardData.FillGrid(dgvpenalty, DashboardData.Table(DashboardData.RecentPenaltySql))
            DashboardData.FillGrid(DataGridView1, DashboardData.Table(DashboardData.Recent7DaysSql))

            DashboardData.FillChart(chartb_overview, DashboardData.Table(
                "SELECT copy_status, COUNT(*) FROM BookCopies WHERE copy_status <> 'Archived' GROUP BY copy_status"),
                SeriesChartType.Doughnut, True)
        Catch ex As Exception
            MsgBox("Could not load the dashboard: " & ex.Message, vbCritical, "Dashboard")
        End Try
    End Sub
End Class