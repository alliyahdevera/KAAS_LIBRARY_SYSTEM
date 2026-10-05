Imports MySql.Data.MySqlClient

Public Class Form1
    Public Shared CurrentAccountId As Integer
    Public Shared CurrentUsername As String
    Public Shared CurrentAccountType As String

    Private Const MaxLoginAttempts As Integer = 3
    Private Const LockoutSeconds As Integer = 5

    Private failedAttempts As Integer = 0
    Private isLockedOut As Boolean = False
    Private lockoutSecondsRemaining As Integer = 0
    Private WithEvents lockoutTimer As New Timer()
    Private isPasswordVisible As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        lockoutTimer.Interval = 1000
        lblAttempts.Text = ""
    End Sub

    Private Sub Form1_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            ' Only restore the lockout state if locked out
            RestoreLockoutState()
        End If
    End Sub

    Private Sub RestoreLockoutState()
        If isLockedOut Then
            btnLogin.Enabled = False
            txtUsername.Enabled = False
            txtPassword.Enabled = False
            lblAttempts.ForeColor = Color.Red

            lblAttempts.Text = $"Too many failed attempts. Locked for {lockoutSecondsRemaining}s"
            lockoutTimer.Start()
        Else
            lblAttempts.Text = ""
            txtPassword.Clear()
        End If
    End Sub

    Private Sub ResetLoginState()
        lockoutTimer.Stop()
        failedAttempts = 0
        isLockedOut = False
        lockoutSecondsRemaining = 0

        btnLogin.Enabled = True
        txtUsername.Enabled = True
        txtPassword.Enabled = True

        lblAttempts.Text = ""
        txtUsername.Clear()
        txtPassword.Clear()
    End Sub

    Private Sub lblRegister_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblRegister.LinkClicked
        frmRegister.Show()
        Me.Hide()
    End Sub

    Private Sub LogAttempt(attemptedUsername As String, status As String, Optional accountId As Integer? = Nothing)
        Try
            Using conn As MySqlConnection = DBConnection.GetConnection()
                conn.Open()
                Dim cmd As New MySqlCommand(
                    "INSERT INTO tbl_login_logs (account_id, username, status, attempt_time) VALUES (@aid, @u, @s, NOW())", conn)
                cmd.Parameters.AddWithValue("@aid", If(accountId.HasValue, CObj(accountId.Value), DBNull.Value))
                cmd.Parameters.AddWithValue("@u", attemptedUsername)
                cmd.Parameters.AddWithValue("@s", status)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            ' Don't let logging failures block the login flow itself.
        End Try
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If isLockedOut Then Exit Sub

        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MsgBox("Please enter both username and password.", vbExclamation, "Login Required")
            Exit Sub
        End If

        Using conn As MySqlConnection = DBConnection.GetConnection()
            conn.Open()
            ' Select by username to verify credentials and check existing attempts
            Dim cmd As New MySqlCommand(
                "SELECT account_id, username, password, account_type, account_status, attempts FROM tbl_account " &
                "WHERE username = @u", conn)
            cmd.Parameters.AddWithValue("@u", txtUsername.Text)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    Dim id As Integer = reader.GetInt32("account_id")
                    Dim uname As String = reader.GetString("username")
                    Dim dbPassword As String = reader.GetString("password")
                    Dim atype As String = reader.GetString("account_type")
                    Dim status As String = reader("account_status").ToString()
                    Dim dbAttempts As Integer = If(IsDBNull(reader("attempts")), 0, Convert.ToInt32(reader("attempts")))
                    reader.Close()

                    If Not status.Equals("Active", StringComparison.OrdinalIgnoreCase) Then
                        txtPassword.Clear()
                        LogAttempt(uname, "Inactive", id)
                        MsgBox("This account is inactive. Please contact the administrator.", vbExclamation, "ACCOUNT INACTIVE")
                        Exit Sub
                    End If

                    ' Check database-level lock
                    If dbAttempts <= 0 Then
                        LogAttempt(uname, "Locked Out", id)
                        MsgBox("This account is locked due to too many failed login attempts. Please contact an administrator.", vbCritical, "ACCOUNT LOCKED")
                        Exit Sub
                    End If

                    ' Validate password
                    If dbPassword = txtPassword.Text Then
                        ' SUCCESS: Reset attempts back to full (3)
                        Dim resetCmd As New MySqlCommand("UPDATE tbl_account SET attempts = @max WHERE account_id = @aid", conn)
                        resetCmd.Parameters.AddWithValue("@max", MaxLoginAttempts)
                        resetCmd.Parameters.AddWithValue("@aid", id)
                        resetCmd.ExecuteNonQuery()

                        LogAttempt(uname, "Success", id)
                        ResetLoginState()
                        LoginSucceeded(id, uname, atype)
                    Else
                        ' FAILURE: Decrement attempts remaining
                        Dim newAttempts As Integer = dbAttempts - 1
                        Dim failCmd As New MySqlCommand("UPDATE tbl_account SET attempts = @att WHERE account_id = @aid", conn)
                        failCmd.Parameters.AddWithValue("@att", newAttempts)
                        failCmd.Parameters.AddWithValue("@aid", id)
                        failCmd.ExecuteNonQuery()

                        LogAttempt(uname, "Failed", id)
                        RegisterFailedAttempt(newAttempts)
                    End If
                Else
                    reader.Close()
                    LogAttempt(txtUsername.Text, "Failed")
                    RegisterFailedAttempt()
                End If
            End Using
        End Using
    End Sub

    Private Sub LoginSucceeded(accountId As Integer, username As String, accountType As String)
        CurrentAccountId = accountId
        CurrentUsername = username
        CurrentAccountType = accountType

        MsgBox("Login Successful!", vbInformation, "WELCOME")
        txtUsername.Clear()
        txtPassword.Clear()

        If accountType.Equals("Admin", StringComparison.OrdinalIgnoreCase) Then
            frmAdminMenu.lblc_name.Text = username
            frmAdminMenu.Show()
        ElseIf accountType.Equals("Librarian", StringComparison.OrdinalIgnoreCase) Then
            frmlibrarianmenu.lblName.Text = $"Welcome, {username}!"
            frmLibrarianMenu.Show()
            frmLibrarianMenu.lblc_name.Text = username
        Else
            frmStudentMenu.lblName.Text = $"Welcome, {username}!"
            frmStudentMenu.Show()
        End If

        Me.Hide()
    End Sub

    Private Sub RegisterFailedAttempt(Optional currentDbAttempts As Integer? = Nothing)
        Dim attemptsLeft As Integer
        If currentDbAttempts.HasValue Then
            attemptsLeft = currentDbAttempts.Value
        Else
            failedAttempts += 1
            attemptsLeft = MaxLoginAttempts - failedAttempts
        End If

        txtPassword.Clear()
        txtUsername.Focus()

        If attemptsLeft <= 0 Then
            StartLockout()
        Else
            MsgBox("Wrong Username or Password!", vbExclamation, "FAILED LOGIN")
            lblAttempts.ForeColor = Color.Red
            lblAttempts.Text = $"Attempts left: {attemptsLeft}"
        End If
    End Sub

    Private Sub StartLockout()
        isLockedOut = True
        failedAttempts = 0
        lockoutSecondsRemaining = LockoutSeconds

        btnLogin.Enabled = False
        txtUsername.Enabled = False
        txtPassword.Enabled = False

        lblAttempts.ForeColor = Color.Red
        lblAttempts.Text = $"Too many failed attempts. Locked for {lockoutSecondsRemaining}s"

        lockoutTimer.Start()
    End Sub

    Private Sub lockoutTimer_Tick(sender As Object, e As EventArgs) Handles lockoutTimer.Tick
        lockoutSecondsRemaining -= 1

        If lockoutSecondsRemaining <= 0 Then
            lockoutTimer.Stop()
            isLockedOut = False
            btnLogin.Enabled = True
            txtUsername.Enabled = True
            txtPassword.Enabled = True
            lblAttempts.Text = ""
            txtUsername.Clear()
            txtPassword.Clear()
            txtUsername.Focus()
        Else
            lblAttempts.Text = $"Too many failed attempts. Locked for {lockoutSecondsRemaining}s"
        End If
    End Sub

    Private Sub btnViewPassword_Click(sender As Object, e As EventArgs) Handles btnViewPassword.Click
        isPasswordVisible = Not isPasswordVisible
        If isPasswordVisible Then
            txtPassword.PasswordChar = Chr(0)
            btnViewPassword.BackgroundImage = Global.LibrarySystem.My.Resources.Resources.eye
        Else
            txtPassword.PasswordChar = Chr(42)
            btnViewPassword.BackgroundImage = Global.LibrarySystem.My.Resources.Resources.eye2
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If MsgBox("Are you sure you want to exit system?", vbQuestion + vbYesNo, "EXIT") = vbYes Then
            MsgBox("Thank you for using Library System!", vbInformation, "The KASS Library System")
            End
        End If
    End Sub

    Private Sub lnklblForgotPass_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblForgotPass.LinkClicked
        If MsgBox("Do you want to change your password?", vbQuestion + vbYesNo, "The KASS Library System") = vbYes Then
            MsgBox("Please contact the Admin to change your password!", vbInformation, "The KASS Library System")
        End If
    End Sub
End Class