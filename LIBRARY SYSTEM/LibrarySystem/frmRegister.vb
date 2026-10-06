Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class frmRegister

    Private Sub frmRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        DateTimePicker1.MaxDate = DateTime.Now.Date
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click

        If String.IsNullOrWhiteSpace(txtFirstName.Text) Then
            MsgBox("Please fill in your first name (cannot be blank).", vbExclamation, "Registration")
            txtFirstName.Focus() : Exit Sub
        End If
        If String.IsNullOrWhiteSpace(txtLastName.Text) Then
            MsgBox("Please fill in your last name (cannot be blank).", vbExclamation, "Registration")
            txtLastName.Focus() : Exit Sub
        End If
        If cboCourse.SelectedIndex = -1 Then
            MsgBox("Please select your Course.", vbExclamation, "Registration")
            cboCourse.Focus() : Exit Sub
        End If
        If cboYear.SelectedIndex = -1 Then
            MsgBox("Please select your Year level.", vbExclamation, "Registration")
            cboYear.Focus() : Exit Sub
        End If
        If Not Regex.IsMatch(txtUserID.Text.Trim(), "^\d{6}$") Then
            MsgBox("Student ID must be exactly 6 digits (numbers only).", vbExclamation, "Registration")
            txtUserID.Focus() : Exit Sub
        End If
        If cboGender.Text <> "Male" AndAlso cboGender.Text <> "Female" AndAlso cboGender.Text <> "Prefer not to say" Then
            MsgBox("Please select Male, Female, or Prefer not to say.", vbExclamation, "Registration")
            cboGender.Focus() : Exit Sub
        End If

        Dim birthdate As Date = DateTimePicker1.Value.Date
        Dim age As Integer = DateTime.Now.Year - birthdate.Year
        If birthdate > DateTime.Now.AddYears(-age) Then age -= 1
        If birthdate > DateTime.Now.Date OrElse age < 5 OrElse age > 100 Then
            MsgBox("Please enter a valid birthdate.", vbExclamation, "Registration")
            DateTimePicker1.Focus() : Exit Sub
        End If

        If Not Regex.IsMatch(txtContactNum.Text.Trim(), "^\d{11}$") Then
            MsgBox("Contact Number must be exactly 11 digits (numbers only).", vbExclamation, "Registration")
            txtContactNum.Focus() : Exit Sub
        End If
        If Not Regex.IsMatch(txtEmail.Text.Trim(), "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then
            MsgBox("Please enter a valid email address.", vbExclamation, "Registration")
            txtEmail.Focus() : Exit Sub
        End If
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MsgBox("Please fill in your username.", vbExclamation, "Registration")
            txtUsername.Focus() : Exit Sub
        End If
        If txtPassword.Text.Length < 8 OrElse txtPassword.Text.Length > 12 Then
            MsgBox("Password must be between 8 and 12 characters long.", vbExclamation, "Registration")
            txtPassword.Focus() : Exit Sub
        End If

        Dim yearLevel As Integer = cboYear.SelectedIndex + 1   ' 1st..4th year

        Try
            Using conn As MySqlConnection = DBConnection.GetConnection()
                conn.Open()

                Using chk As New MySqlCommand("SELECT COUNT(*) FROM Users WHERE school_id = @sid", conn)
                    chk.Parameters.AddWithValue("@sid", txtUserID.Text.Trim())
                    If Convert.ToInt32(chk.ExecuteScalar()) > 0 Then
                        MsgBox("This Student ID is already registered. Please contact the library admin if you believe this is an error.", vbExclamation, "Registration")
                        Exit Sub
                    End If
                End Using

                Using chk As New MySqlCommand("SELECT COUNT(*) FROM Users WHERE username = @u", conn)
                    chk.Parameters.AddWithValue("@u", txtUsername.Text.Trim())
                    If Convert.ToInt32(chk.ExecuteScalar()) > 0 Then
                        MsgBox("Username already exists. Please choose a different username.", vbExclamation, "Registration")
                        Exit Sub
                    End If
                End Using

                ' Users row + Members row must both succeed or neither
                Using tx As MySqlTransaction = conn.BeginTransaction()
                    Try
                        Dim newUserId As Integer
                        Using ins As New MySqlCommand(
                            "INSERT INTO Users (school_id, username, password, first_name, middle_name, last_name, suffix, " &
                            "gender, birthdate, contact_num, email, role, account_status, attempts) " &
                            "VALUES (@sid, @u, @p, @fn, @mn, @ln, @sf, @g, @bd, @cn, @em, 'Member', 'Active', 3)", conn, tx)
                            ins.Parameters.AddWithValue("@sid", txtUserID.Text.Trim())
                            ins.Parameters.AddWithValue("@u", txtUsername.Text.Trim())
                            ins.Parameters.AddWithValue("@p", Security.HashPassword(txtPassword.Text))
                            ins.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim())
                            ins.Parameters.AddWithValue("@mn", If(String.IsNullOrWhiteSpace(txtMiddleName.Text), DBNull.Value, CObj(txtMiddleName.Text.Trim())))
                            ins.Parameters.AddWithValue("@ln", txtLastName.Text.Trim())
                            ins.Parameters.AddWithValue("@sf", If(String.IsNullOrWhiteSpace(txtSuffix.Text), DBNull.Value, CObj(txtSuffix.Text.Trim())))
                            ins.Parameters.AddWithValue("@g", cboGender.Text)
                            ins.Parameters.AddWithValue("@bd", birthdate)
                            ins.Parameters.AddWithValue("@cn", txtContactNum.Text.Trim())
                            ins.Parameters.AddWithValue("@em", txtEmail.Text.Trim())
                            ins.ExecuteNonQuery()
                            newUserId = Convert.ToInt32(ins.LastInsertedId)
                        End Using

                        Using insM As New MySqlCommand(
                            "INSERT INTO Members (user_id, member_type, course, year_level) " &
                            "VALUES (@uid, 'Student', @course, @yr)", conn, tx)
                            insM.Parameters.AddWithValue("@uid", newUserId)
                            insM.Parameters.AddWithValue("@course", cboCourse.Text)
                            insM.Parameters.AddWithValue("@yr", yearLevel)
                            insM.ExecuteNonQuery()
                        End Using

                        tx.Commit()
                    Catch
                        tx.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Registration failed: " & ex.Message, vbCritical, "Registration")
            Exit Sub
        End Try

        MsgBox("Successfully registered. You can now log in.", vbInformation, "USER REGISTRATION")

        txtFirstName.Clear() : txtMiddleName.Clear() : txtLastName.Clear() : txtSuffix.Clear()
        txtUserID.Clear() : cboCourse.SelectedIndex = -1 : cboYear.SelectedIndex = -1
        txtContactNum.Clear() : txtEmail.Clear() : cboGender.SelectedIndex = -1
        txtUsername.Clear() : txtPassword.Clear()

        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub btnAccount_Click(sender As Object, e As EventArgs) Handles btnAccount.Click
        Form1.Show()
        Me.Hide()
    End Sub
End Class