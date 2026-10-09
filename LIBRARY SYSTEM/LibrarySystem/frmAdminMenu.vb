Public Class frmAdminMenu
    Private loggingOut As Boolean = False

    Private Sub frmAdminMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ScreenFit.Apply(Me, 1924, 1052)      ' Task 3: delete this line if you have not added the ScreenFit module
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
        Select Case True
            Case sender Is btndash : FormHost.LoadInto(Panel3, frmAdminDashboard)
            Case sender Is btnaccman : FormHost.LoadInto(Panel3, frmAccManagement)
            Case sender Is btnborrowh : FormHost.LoadInto(Panel3, frmAdminHistory)
            Case sender Is btnbookinventory : FormHost.LoadInto(Panel3, frmAdminBookInventory)
            Case sender Is btnLostDamaged : FormHost.LoadInto(Panel3, frmLostDamagedBooks)
            Case sender Is btnactlog : FormHost.LoadInto(Panel3, frmAdminLogs)
            Case sender Is btnlogout : DoLogout()
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