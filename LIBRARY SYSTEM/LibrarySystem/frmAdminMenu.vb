Public Class frmAdminMenu
    Private loggingOut As Boolean = False

    Private Sub frmAdminMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        lblc_name.Text = AppSession.FullName
        tmrDateTime.Interval = 1000
        tmrDateTime.Enabled = True
        UpdateClock()
        For Each b As Button In UiHelpers.AllButtons(Me)
            AddHandler b.Click, AddressOf MenuButton_Click
        Next
        FormHost.LoadInto(Panel3, frmAdminDashboard)
    End Sub

    Private Sub MenuButton_Click(sender As Object, e As EventArgs)
        Dim caption As String = DirectCast(sender, Button).Text.Trim()
        Select Case caption
            Case "Dashboard" : FormHost.LoadInto(Panel3, frmAdminDashboard)
            Case "Book Management" : FormHost.LoadInto(Panel3, frmBookManagement)
            Case "Account Management" : FormHost.LoadInto(Panel3, frmStudentManagement)
            Case "Borrow History Records" : FormHost.LoadInto(Panel3, frmAdminHistory)
            Case "Report" : FormHost.LoadInto(Panel3, frmReports)
            Case "Activity Logs" : FormHost.LoadInto(Panel3, frmAdminLogs)
            Case "Logout" : DoLogout()
        End Select
    End Sub

    Private Sub UpdateClock()
        Dim stamp As String = Date.Now.ToString("MMMM dd, yyyy | hh:mm:ss tt")
        lbldatetime.Text = stamp
        lbl_dT.Text = stamp
    End Sub

    Private Sub tmrDateTime_Tick(sender As Object, e As EventArgs) Handles tmrDateTime.Tick
        UpdateClock()
    End Sub

    Private Sub DoLogout()
        If MsgBox("Are you sure you want to log out?", vbQuestion + vbYesNo, "LOGOUT") = vbYes Then
            DBConnection.LogActivity("Logout", AppSession.Username & " logged out.")
            loggingOut = True
            AppSession.SignOut()
            Form1.Show()
            Me.Close()
        End If
    End Sub

    Private Sub frmAdminMenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Not loggingOut Then Application.Exit()
    End Sub
End Class