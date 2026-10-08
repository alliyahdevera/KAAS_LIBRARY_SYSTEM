Public Class frmLibrarianMainMenu
    Private loggingOut As Boolean = False

    Private Sub frmLibrarianMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ScreenFit.Apply(Me, 1924, 1052)      ' Task 3: delete this line if you have not added the ScreenFit module
        Me.CenterToScreen()

        ' new sidebar button: must be created BEFORE the click handlers below are attached
        MenuBuilder.AddMenuButton(Me, "btnpenaltyman", "Lost and Damaged")

        For Each b As Button In UiHelpers.AllButtons(Me)
            AddHandler b.Click, AddressOf MenuButton_Click
        Next
        FormHost.LoadInto(Panel3, frmLibraryDashboard)
    End Sub

    Private Sub MenuButton_Click(sender As Object, e As EventArgs)
        Dim caption As String = DirectCast(sender, Button).Text.Trim()
        Select Case caption
            Case "Dashboard" : FormHost.LoadInto(Panel3, frmLibraryDashboard)
            Case "Book Management" : FormHost.LoadInto(Panel3, frmBookManagement)
            Case "Borrow Management" : FormHost.LoadInto(Panel3, frmLibrarianBorrowManagement)
            Case "Penalty Management" : FormHost.LoadInto(Panel3, frmPenaltyManagement)
            Case "Lost and Damaged" : FormHost.LoadInto(Panel3, frmLostDamagedBooks)
            Case "Logout" : DoLogout()
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

    Private Sub frmLibrarianMainMenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Not loggingOut Then Application.Exit()
    End Sub
End Class