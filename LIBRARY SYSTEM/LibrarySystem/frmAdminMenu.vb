Public Class frmAdminMenu
    Private loggingOut As Boolean = False
    Private syLoading As Boolean = False
    Private btnReports As Button

    Private Sub frmAdminMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        lblc_name.Text = AppSession.FullName
        tmrDateTime.Interval = 1000
        tmrDateTime.Enabled = True
        UpdateClock()

        ' School year selector (admin only)
        SchoolYearContext.ResetToCurrent()
        Label1.Text = "School Year:"
        cboSchoolYear.DropDownStyle = ComboBoxStyle.DropDownList
        LoadSchoolYears()
        AddHandler SchoolYearContext.ListChanged, AddressOf OnSchoolYearListChanged
        AddHandler SchoolYearContext.Changed, AddressOf OnSchoolYearViewChanged

        ' "Reports" button, placed under Activity Logs
        btnReports = MenuBuilder.AddMenuButton(Me, "btnactlog", "Reports")

        For Each b As Button In UiHelpers.AllButtons(Me)
            AddHandler b.Click, AddressOf MenuButton_Click
        Next
        FormHost.LoadInto(Panel3, frmAdminDashboard)
    End Sub

    Private Sub MenuButton_Click(sender As Object, e As EventArgs)
        Select Case True
            Case sender Is btndash : FormHost.LoadInto(Panel3, frmAdminDashboard)
            Case sender Is btnaccman : FormHost.LoadInto(Panel3, frmAccManagement)
            Case sender Is btnborrowh : FormHost.LoadInto(Panel3, frmAdminBorrowHistory)
            Case sender Is btnbookinventory : FormHost.LoadInto(Panel3, frmAdminBookInventory)
            Case sender Is btnLostDamaged : FormHost.LoadInto(Panel3, frmLostDamagedBooks)
            Case sender Is btnactlog : FormHost.LoadInto(Panel3, frmAdminLogs)
            Case sender Is btnReports : FormHost.LoadInto(Panel3, frmReports)
            Case sender Is Button1 : FormHost.LoadInto(Panel3, frmManageSY)           ' Manage S.Y.
            Case sender Is btnlogout : DoLogout()
        End Select
    End Sub

    ' ------------------------------------------------------------ school year combo box
    Private Sub LoadSchoolYears()
        syLoading = True
        Try
            cboSchoolYear.Items.Clear()
            cboSchoolYear.Items.Add(SchoolYearContext.AllTime)
            Try
                For Each s As SchoolYearInfo In SchoolYearContext.GetAll()
                    cboSchoolYear.Items.Add(s)
                Next
            Catch ex As Exception
                MsgBox("Could not load the school years: " & ex.Message & vbCrLf &
                       "Did you run the SchoolYear SQL script?", vbExclamation, "School Year")
            End Try
            ShowSelectedSchoolYear()
        Finally
            syLoading = False
        End Try
    End Sub

    Private Sub ShowSelectedSchoolYear()
        For i As Integer = 0 To cboSchoolYear.Items.Count - 1
            If DirectCast(cboSchoolYear.Items(i), SchoolYearInfo).Id = SchoolYearContext.Selected.Id Then
                cboSchoolYear.SelectedIndex = i
                Exit Sub
            End If
        Next
        cboSchoolYear.SelectedIndex = 0
    End Sub

    Private Sub cboSchoolYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSchoolYear.SelectedIndexChanged
        If syLoading Then Exit Sub
        Dim s As SchoolYearInfo = TryCast(cboSchoolYear.SelectedItem, SchoolYearInfo)
        If s IsNot Nothing Then SchoolYearContext.Selected = s          ' the dashboard refreshes itself
    End Sub

    Private Sub OnSchoolYearListChanged()
        If Me.IsDisposed Then Exit Sub
        LoadSchoolYears()
    End Sub

    Private Sub OnSchoolYearViewChanged()          ' e.g. "Change S.Y." was pressed in Manage S.Y.
        If Me.IsDisposed Then Exit Sub
        syLoading = True
        Try
            ShowSelectedSchoolYear()
        Finally
            syLoading = False
        End Try
    End Sub

    ' ------------------------------------------------------------ clock / logout
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
            frmLogin.Show()
            Me.Close()
        End If
    End Sub

    Private Sub frmAdminMenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        RemoveHandler SchoolYearContext.ListChanged, AddressOf OnSchoolYearListChanged
        RemoveHandler SchoolYearContext.Changed, AddressOf OnSchoolYearViewChanged
        If Not loggingOut Then Application.Exit()
    End Sub

    Private Sub btnLostDamaged_Click(sender As Object, e As EventArgs) Handles btnLostDamaged.Click

    End Sub
End Class