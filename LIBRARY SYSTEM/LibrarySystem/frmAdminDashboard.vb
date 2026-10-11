Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmAdminDashboard

    Private Sub frmAdminDashboard_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Not Me.Visible Then Exit Sub
        UiHelpers.FillHeader(Me)
        RefreshDashboard()
    End Sub

    Private Sub RefreshDashboard()
        Try
            lblTotalBooks.Text = DashboardData.Scalar("SELECT IFNULL(SUM(total_copies),0) FROM vw_BookCatalog").ToString("N0")
            lblb_avail.Text = DashboardData.Scalar("SELECT IFNULL(SUM(available_copies),0) FROM vw_BookCatalog").ToString("N0")
            lblBooksBorrowed.Text = DashboardData.Scalar("SELECT COUNT(*) FROM BorrowTransaction WHERE transaction_status = 'Borrowed'").ToString("N0")
            lblb_return.Text = DashboardData.Scalar("SELECT COUNT(*) FROM BorrowTransaction WHERE transaction_status = 'Borrowed' AND due_date < CURDATE()").ToString("N0")   ' Overdue Books

            DashboardData.FillChart(chartb_overview, DashboardData.Table(
                "SELECT copy_status, COUNT(*) FROM BookCopies WHERE copy_status <> 'Archived' GROUP BY copy_status"),
                SeriesChartType.Doughnut, True)

            DashboardData.FillChart(chartb_categories, DashboardData.Table(
                "SELECT c.category_name, SUM(v.total_copies) " &
                "FROM BookCategories bc " &
                "JOIN Categories c ON c.category_id = bc.category_id " &
                "JOIN vw_BookCatalog v ON v.book_id = bc.book_id " &
                "GROUP BY c.category_id, c.category_name " &
                "ORDER BY SUM(v.total_copies) DESC LIMIT 6"),
                SeriesChartType.Column, False)

            DashboardData.FillChart(chartb_mborrowed, DashboardData.Table(DashboardData.TopBooksSql),
                SeriesChartType.Bar, False)

            ' Library Activity - last 7 days (DataGridView)
            DashboardData.FillGrid(DataGridView1, DashboardData.Table(DashboardData.Recent7DaysSql))

        Catch ex As Exception
            MsgBox("Could not load the dashboard: " & ex.Message, vbCritical, "Dashboard")
        End Try
    End Sub

End Class