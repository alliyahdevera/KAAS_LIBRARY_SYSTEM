Public Class frmStudentMainMenu
    Private loggingOut As Boolean = False
    Private WithEvents tmrNotif As New Timer() With {.Interval = 60000}
    Private pnlNotif As Panel
    Private lblNotif As Label
    Private hasNotice As Boolean = False
    Private currentPage As String = "dashboard"

    Private Sub frmStudentMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ScreenFit.Apply(Me, 1924, 1052)
        Me.CenterToScreen()

        lbl_dT.Visible = False              ' date/time removed
        lblt_datetime.Visible = False

        For Each b As Button In UiHelpers.AllButtons(Me)
            AddHandler b.Click, AddressOf MenuButton_Click
        Next

        BuildNoticeBanner()
        FormHost.LoadInto(Panel3, frmStudentDashboard)

        RefreshNotice()
        tmrNotif.Start()
    End Sub

    Private Sub MenuButton_Click(sender As Object, e As EventArgs)
        Dim caption As String = DirectCast(sender, Button).Text.Trim().ToLowerInvariant()
        If caption = "logout" Then
            DoLogout()
            Exit Sub
        End If

        currentPage = caption
        Select Case caption
            Case "dashboard" : FormHost.LoadInto(Panel3, frmStudentDashboard)
            Case "borrow books" : FormHost.LoadInto(Panel3, frmBorrow)
            Case "return books" : FormHost.LoadInto(Panel3, frmReturn)
            Case "available books" : FormHost.LoadInto(Panel3, frmAvailBooks)
            Case "borrow history" : FormHost.LoadInto(Panel3, frmStudentHistory)
            Case "my penalties" : FormHost.LoadInto(Panel3, frmStudentPenalty)
            Case "need help?" : FormHost.LoadInto(Panel3, frmHelp)
        End Select

        If caption = "dashboard" Then RefreshNotice() Else ShowBanner()
    End Sub

    ' ------------------------------------------------------------ notification
    Private Sub BuildNoticeBanner()
        pnlNotif = New Panel With {
            .Size = New Size(400, 72),
            .BackColor = Color.FromArgb(255, 235, 235),
            .BorderStyle = BorderStyle.FixedSingle,
            .Cursor = Cursors.Hand,
            .Visible = False
        }
        lblNotif = New Label With {
            .Dock = DockStyle.Fill,
            .ForeColor = Color.Firebrick,
            .Font = New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold),
            .TextAlign = ContentAlignment.MiddleLeft,
            .Padding = New Padding(8, 0, 8, 0),
            .Cursor = Cursors.Hand
        }
        pnlNotif.Controls.Add(lblNotif)
        AddHandler pnlNotif.Click, AddressOf Banner_Click
        AddHandler lblNotif.Click, AddressOf Banner_Click
        Panel3.Controls.Add(pnlNotif)
    End Sub

    Private Sub Banner_Click(sender As Object, e As EventArgs)
        currentPage = "my penalties"
        FormHost.LoadInto(Panel3, frmStudentPenalty)
        ShowBanner()
    End Sub

    Private Sub ShowBanner()
        pnlNotif.Visible = hasNotice AndAlso currentPage = "dashboard"
        PositionBanner()
        pnlNotif.BringToFront()          ' FormHost.LoadInto brings the page to the front, so put the banner back on top
    End Sub

    Private Sub PositionBanner()
        If pnlNotif Is Nothing Then Exit Sub
        pnlNotif.Location = New Point(Math.Max(0, Panel3.ClientSize.Width - pnlNotif.Width - 30), 18)
    End Sub

    Private Sub Panel3_Resize(sender As Object, e As EventArgs) Handles Panel3.Resize
        PositionBanner()
    End Sub

    Private Sub tmrNotif_Tick(sender As Object, e As EventArgs) Handles tmrNotif.Tick
        RefreshNotice()
    End Sub

    Private Sub RefreshNotice()
        Dim banner As String = BuildNotice()
        hasNotice = (banner <> "")
        lblNotif.Text = banner
        ShowBanner()
    End Sub

    ' Returns the banner text ("" = nothing to report)
    Private Function BuildNotice() As String
        If Not AppSession.MemberId.HasValue Then Return ""
        Dim m As Integer = AppSession.MemberId.Value
        Dim peso As String = ChrW(&H20B1)
        Dim lines As New List(Of String)

        Try
            Dim overdueCnt As Integer = CInt(DashboardData.Scalar(
                "SELECT COUNT(*) FROM BorrowTransaction WHERE member_id = @m " &
                "AND transaction_status = 'Borrowed' AND CURDATE() > due_date", "@m", m))

            Dim lateDays As Decimal = DashboardData.Scalar(
                "SELECT IFNULL(SUM(GREATEST(0, DATEDIFF(CURDATE(), due_date) - @g)),0) FROM BorrowTransaction " &
                "WHERE member_id = @m AND transaction_status = 'Borrowed'", "@m", m, "@g", LibraryRules.PenaltyGraceDays)
            Dim accruing As Decimal = lateDays * LibraryRules.PenaltyPerDay(AppSession.MemberType)

            Dim unpaid As Decimal = DashboardData.Scalar(
                "SELECT IFNULL(SUM(p.penalty_amount),0) FROM Penalty p " &
                "JOIN BorrowTransaction t ON t.transaction_id = p.transaction_id " &
                "WHERE t.member_id = @m AND p.penalty_status IN ('Unpaid','Pending')", "@m", m)

            Dim dueSoon As Integer = CInt(DashboardData.Scalar(
                "SELECT COUNT(*) FROM BorrowTransaction WHERE member_id = @m AND transaction_status = 'Borrowed' " &
                "AND due_date >= CURDATE() AND due_date <= DATE_ADD(CURDATE(), INTERVAL 1 DAY)", "@m", m))

            If overdueCnt > 0 Then
                lines.Add(overdueCnt & " overdue book(s). Fine so far: " & peso & accruing.ToString("N2"))
            End If
            If unpaid > 0 Then
                lines.Add("Unpaid penalty: " & peso & unpaid.ToString("N2") & " - pay at the cashier.")
            End If
            If dueSoon > 0 Then
                lines.Add(dueSoon & " book(s) due within 1 day - please return on time.")
            End If
        Catch
            Return ""                 ' a notification must never block the menu
        End Try

        Return String.Join(vbCrLf, lines)
    End Function

    ' ------------------------------------------------------------ logout
    Private Sub DoLogout()
        If MsgBox("Are you sure you want to log out?", vbQuestion + vbYesNo, "LOGOUT") = vbYes Then
            tmrNotif.Stop()
            DBConnection.LogActivity("Logout", AppSession.Username & " logged out.")
            loggingOut = True
            AppSession.SignOut()
            frmLogin.Show()
            Me.Close()
        End If
    End Sub

    Private Sub frmStudentMainMenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Not loggingOut Then Application.Exit()
    End Sub
End Class