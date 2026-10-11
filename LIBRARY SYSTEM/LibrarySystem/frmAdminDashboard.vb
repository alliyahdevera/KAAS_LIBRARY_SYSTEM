Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmAdminDashboard

    Private Sub frmAdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler SchoolYearContext.Changed, AddressOf OnSchoolYearChanged
    End Sub

    Private Sub frmAdminDashboard_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        RemoveHandler SchoolYearContext.Changed, AddressOf OnSchoolYearChanged
    End Sub

    Private Sub OnSchoolYearChanged()
        If Me.IsDisposed OrElse Not Me.Visible Then Exit Sub
        RefreshDashboard()
    End Sub

    Private Sub frmAdminDashboard_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Not Me.Visible Then Exit Sub
        UiHelpers.FillHeader(Me)
        RefreshDashboard()
    End Sub

    Private Sub RefreshDashboard()
        Try
            SchoolYearBanner.Apply(Me)                                         ' "Showing: S.Y. ..." label
            Dim sy As String = SchoolYearContext.Between("t.borrow_date")      ' selected school year (or All Time)

            ' Inventory (current stock - not school year based)
            lblTotalBooks.Text = DashboardData.Scalar("SELECT IFNULL(SUM(total_copies),0) FROM vw_BookCatalog").ToString("N0")
            lblb_avail.Text = DashboardData.Scalar("SELECT IFNULL(SUM(available_copies),0) FROM vw_BookCatalog").ToString("N0")

            ' Per school year
            lblBooksBorrowed.Text = DashboardData.Scalar(
                "SELECT COUNT(*) FROM BorrowTransaction t WHERE " & sy).ToString("N0")
            lblb_return.Text = DashboardData.Scalar(                              ' Overdue Books
                "SELECT COUNT(*) FROM BorrowTransaction t WHERE t.transaction_status = 'Borrowed' " &
                "AND t.due_date < CURDATE() AND " & sy).ToString("N0")

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

            DashboardData.FillChart(chartb_mborrowed, DashboardData.Table(DashboardData.TopBooksSqlFor(sy)),
                SeriesChartType.Bar, False)

            ' Library Activity - always the last 7 days
            DataGridView1.DefaultCellStyle.ForeColor = Color.Black
            DashboardData.FillGrid(DataGridView1, DashboardData.Table(DashboardData.Recent7DaysSql))
            ' Library Activity - always the last 7 days
            DashboardData.FillGrid(DataGridView1, DashboardData.Table(DashboardData.Recent7DaysSql))

        Catch ex As Exception
            MsgBox("Could not load the dashboard: " & ex.Message, vbCritical, "Dashboard")
        End Try
    End Sub

End Class