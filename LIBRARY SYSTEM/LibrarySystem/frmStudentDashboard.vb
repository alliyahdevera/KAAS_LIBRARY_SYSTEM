Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmStudentDashboard

    Private Sub frmStudentDashboard_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Not Me.Visible Then Exit Sub
        UiHelpers.FillHeader(Me)
        RefreshDashboard()
    End Sub

    Private Sub RefreshDashboard()
        Try
            DashboardData.FillChart(chartb_mborrowed, DashboardData.Table(DashboardData.TopBooksSql),
                SeriesChartType.Bar, False)

            If Not AppSession.MemberId.HasValue Then Exit Sub
            Dim m As Integer = AppSession.MemberId.Value

            lblb_Borrowed.Text = DashboardData.Scalar(
                "SELECT COUNT(*) FROM BorrowTransaction WHERE member_id = @m AND transaction_status = 'Borrowed'", "@m", m).ToString("N0")
            lblb_return.Text = DashboardData.Scalar(
                "SELECT COUNT(*) FROM BorrowTransaction WHERE member_id = @m AND transaction_status = 'Returned'", "@m", m).ToString("N0")
            lblBooksDue.Text = DashboardData.Scalar(
                "SELECT COUNT(*) FROM BorrowTransaction WHERE member_id = @m AND transaction_status = 'Borrowed' " &
                "AND due_date >= CURDATE() AND due_date <= DATE_ADD(CURDATE(), INTERVAL 1 DAY)", "@m", m).ToString("N0")

            ' Recorded penalties that are still unpaid
            Dim unpaid As Decimal = DashboardData.Scalar(
                "SELECT IFNULL(SUM(p.penalty_amount),0) FROM Penalty p " &
                "JOIN BorrowTransaction t ON t.transaction_id = p.transaction_id " &
                "WHERE t.member_id = @m AND p.penalty_status IN ('Unpaid','Pending')", "@m", m)

            ' Penalty still building up on books that are late right now (after the grace period)   ' CHANGED
            Dim chargeableDays As Decimal = DashboardData.Scalar(
                "SELECT IFNULL(SUM(GREATEST(0, DATEDIFF(CURDATE(), due_date) - @g)),0) FROM BorrowTransaction " &
                "WHERE member_id = @m AND transaction_status = 'Borrowed'",
                "@m", m, "@g", LibraryRules.PenaltyGraceDays)

            lblPenalty.Text = (unpaid + chargeableDays * LibraryRules.PenaltyPerDay(AppSession.MemberType)).ToString("N2")
        Catch ex As Exception
            MsgBox("Could not load the dashboard: " & ex.Message, vbCritical, "Dashboard")
        End Try
    End Sub

End Class