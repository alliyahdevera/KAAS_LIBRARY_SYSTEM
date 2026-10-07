Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class Form1
    Private Const MaxLoginAttempts As Integer = 3
    Private Const LockoutSeconds As Integer = 5

    Private failedAttempts As Integer = 0
    Private isLockedOut As Boolean = False
    Private lockoutSecondsRemaining As Integer = 0
    Private WithEvents lockoutTimer As New Timer()
    Private isPasswordVisible As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ScreenFit.Apply(Me, 1163, 750)
        Me.CenterToScreen()
        lockoutTimer.Interval = 1000
        lblAttempts.Text = ""
    End Sub

    Private Sub Form1_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then RestoreLockoutState()
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

    Private Sub LogAttempt(attemptedUsername As String, status As String, Optional userId As Integer? = Nothing)
        Try
            Using conn As MySqlConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    "INSERT INTO LoginLogs (user_id, username, status, attempt_time) " &
                    "VALUES (@uid, @u, @s, NOW())", conn)
                    cmd.Parameters.AddWithValue("@uid", If(userId.HasValue, CObj(userId.Value), DBNull.Value))
                    cmd.Parameters.AddWithValue("@u", attemptedUsername)
                    cmd.Parameters.AddWithValue("@s", status)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' Logging must never block login
        End Try
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If isLockedOut Then Exit Sub

        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MsgBox("Please enter both username and password.", vbExclamation, "Login Required")
            Exit Sub
        End If

        Dim found As Boolean = False
        Dim userId As Integer, dbAttempts As Integer
        Dim uname, dbPassword, role, status, schoolId, fullName, memberType As String
        uname = "" : dbPassword = "" : role = "" : status = "" : schoolId = "" : fullName = "" : memberType = ""
        Dim memberId As Integer? = Nothing

        Using conn As MySqlConnection = DBConnection.GetConnection()
            conn.Open()

            Using cmd As New MySqlCommand(
                "SELECT u.user_id, u.school_id, u.username, u.password, u.role, u.account_status, u.attempts, " &
                "       CONCAT(u.first_name, ' ', u.last_name) AS full_name, m.member_id, m.member_type " &
                "FROM Users u LEFT JOIN Members m ON m.user_id = u.user_id " &
                "WHERE u.username = @u", conn)
                cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim())

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        found = True
                        userId = Convert.ToInt32(reader("user_id"))
                        schoolId = reader("school_id").ToString()
                        uname = reader("username").ToString()
                        dbPassword = reader("password").ToString()
                        role = reader("role").ToString()
                        status = reader("account_status").ToString()
                        dbAttempts = If(IsDBNull(reader("attempts")), 0, Convert.ToInt32(reader("attempts")))
                        fullName = reader("full_name").ToString()
                        If Not IsDBNull(reader("member_id")) Then
                            memberId = Convert.ToInt32(reader("member_id"))
                            memberType = reader("member_type").ToString()
                        End If
                    End If
                End Using
            End Using

            If Not found Then
                LogAttempt(txtUsername.Text, "Failed")
                RegisterFailedAttempt()
                Exit Sub
            End If

            If Not status.Equals("Active", StringComparison.OrdinalIgnoreCase) Then
                txtPassword.Clear()
                LogAttempt(uname, "Inactive", userId)
                MsgBox("This account is inactive. Please contact the administrator.", vbExclamation, "ACCOUNT INACTIVE")
                Exit Sub
            End If

            If dbAttempts <= 0 Then
                LogAttempt(uname, "Locked Out", userId)
                MsgBox("This account is locked due to too many failed login attempts. Please contact an administrator.", vbCritical, "ACCOUNT LOCKED")
                Exit Sub
            End If

            If Security.VerifyPassword(txtPassword.Text, dbPassword) Then
                ' Reset attempts and, if the stored password is still plain text, upgrade it to a hash
                Dim sql As String = "UPDATE Users SET attempts = @max"
                Dim upgrade As Boolean = Not Security.IsHashed(dbPassword)
                If upgrade Then sql &= ", password = @pw"
                sql &= " WHERE user_id = @uid"
                Using upd As New MySqlCommand(sql, conn)
                    upd.Parameters.AddWithValue("@max", MaxLoginAttempts)
                    If upgrade Then upd.Parameters.AddWithValue("@pw", Security.HashPassword(txtPassword.Text))
                    upd.Parameters.AddWithValue("@uid", userId)
                    upd.ExecuteNonQuery()
                End Using

                LogAttempt(uname, "Success", userId)
                ResetLoginState()
                LoginSucceeded(userId, schoolId, uname, fullName, role, memberId, memberType)
            Else
                Dim newAttempts As Integer = dbAttempts - 1
                Using upd As New MySqlCommand("UPDATE Users SET attempts = @att WHERE user_id = @uid", conn)
                    upd.Parameters.AddWithValue("@att", newAttempts)
                    upd.Parameters.AddWithValue("@uid", userId)
                    upd.ExecuteNonQuery()
                End Using
                LogAttempt(uname, "Failed", userId)
                RegisterFailedAttempt(newAttempts)
            End If
        End Using
    End Sub

    Private Sub LoginSucceeded(userId As Integer, schoolId As String, uname As String, fullName As String,
                               role As String, memberId As Integer?, memberType As String)
        AppSession.SignIn(userId, schoolId, uname, fullName, role, memberId, memberType)

        MsgBox("Login Successful!", vbInformation, "WELCOME")

        ' A librarian/admin who is also registered as a borrower (Staff) can choose their view
        Dim openBorrower As Boolean = False
        If (role = "Admin" OrElse role = "Librarian") AndAlso memberId.HasValue Then
            openBorrower = (MsgBox("Open your Borrower menu (borrow / return your own books)?" & vbCrLf &
                                   "Yes = Borrower menu    No = " & role & " menu",
                                   vbQuestion + vbYesNo, "Choose view") = vbYes)
        End If

        If role = "Member" OrElse openBorrower Then
            If Not memberId.HasValue Then
                MsgBox("This account has no borrower profile. Please contact the administrator.", vbExclamation, "LOGIN")
                AppSession.SignOut()
                Exit Sub
            End If
            frmStudentMainMenu.Show()
        ElseIf role = "Librarian" Then
            frmLibrarianMainMenu.Show()
        Else
            frmAdminMenu.Show()      ' Admin shell is reworked in Phase 5
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
            MsgBox("Thank you for using Library System!", vbInformation, "The KAAS Library System")
            Application.Exit()
        End If
    End Sub

    Private Sub lnklblForgotPass_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblForgotPass.LinkClicked
        If MsgBox("Do you want to change your password?", vbQuestion + vbYesNo, "The KAAS Library System") = vbYes Then
            MsgBox("Please contact the Admin to change your password!", vbInformation, "The KAAS Library System")
        End If
    End Sub
End Class