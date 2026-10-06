Public Class frmStudentMainMenu
    Private loggingOut As Boolean = False

    Private Sub frmStudentMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        For Each b As Button In UiHelpers.AllButtons(Me)
            AddHandler b.Click, AddressOf MenuButton_Click
        Next
        FormHost.LoadInto(Panel3, frmStudentDashboard)
    End Sub

    Private Sub MenuButton_Click(sender As Object, e As EventArgs)
        Dim caption As String = DirectCast(sender, Button).Text.Trim().ToLowerInvariant()
        Select Case caption
            Case "dashboard" : FormHost.LoadInto(Panel3, frmStudentDashboard)
            Case "borrow books" : FormHost.LoadInto(Panel3, frmBorrow)
            Case "return books" : FormHost.LoadInto(Panel3, frmReturn)
            Case "available books" : FormHost.LoadInto(Panel3, frmAvailBooks)
            Case "borrow history" : FormHost.LoadInto(Panel3, frmStudentHistory)
            Case "my penalties" : FormHost.LoadInto(Panel3, frmStudentPenalty)
            Case "need help?" : FormHost.LoadInto(Panel3, frmHelp)
            Case "logout" : DoLogout()
        End Select
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

    Private Sub frmStudentMainMenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Not loggingOut Then Application.Exit()
    End Sub
End Class