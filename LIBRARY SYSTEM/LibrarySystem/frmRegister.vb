Imports MySql.Data.MySqlClient

Public Class frmRegister

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click

        If String.IsNullOrWhiteSpace(txtFirstName.Text) Then
            MsgBox("Please fill in your first name (cannot be blank).", vbExclamation, "Registration")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtLastName.Text) Then
            MsgBox("Please fill in your last name (cannot be blank).", vbExclamation, "Registration")
            Exit Sub
        End If

        If cboCourse.SelectedIndex = -1 Then
            MsgBox("Please select your Course.", vbExclamation, "Registration")
            cboCourse.Focus()
            Exit Sub
        End If

        If cboYear.SelectedIndex = -1 Then
            MsgBox("Please select your Year level.", vbExclamation, "Registration")
            cboYear.Focus()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtUserID.Text) Then
            MsgBox("Please fill in your student ID", vbExclamation, "Registration")
            Exit Sub
        End If

        If txtUserID.Text.Length <> 6 Then
            MsgBox("Student ID must be exactly 6 digits long.", vbExclamation, "Registration")
            Exit Sub
        End If

        If Not IsNumeric(txtUserID.Text) Then
            MsgBox("Student ID must contain only numbers.", vbExclamation, "Registration")
            Exit Sub
        End If

        Using conn As MySqlConnection = DBConnection.GetConnection()
            conn.Open()

            Dim checkId As New MySqlCommand("SELECT COUNT(*) FROM tbl_account WHERE user_id = @sid", conn)
            checkId.Parameters.AddWithValue("@sid", txtUserID.Text)
            If Convert.ToInt32(checkId.ExecuteScalar()) > 0 Then
                MsgBox("This Student ID is already registered. Please contact the library admin if you believe this is an error.", vbExclamation, "Registration")
                Exit Sub
            End If

            If cboGender.Text <> "Male" And cboGender.Text <> "Female" And cboGender.Text <> "Prefer not to say" Then
                MsgBox("Please select the following (Male, Female, or Prefer not to say).", vbExclamation, "Registration")
                cboGender.Focus()
                Exit Sub
            End If

            Dim birthdate As Date = DateTimePicker1.Value.Date

            If birthdate > DateTime.Now.Date Then
                MsgBox("Birthdate cannot be in the future.", vbExclamation, "Registration")
                DateTimePicker1.Focus()
                Exit Sub
            End If

            Dim age As Integer = DateTime.Now.Year - birthdate.Year
            If birthdate.Date > DateTime.Now.AddYears(-age) Then age -= 1

            If age < 5 OrElse age > 100 Then
                MsgBox("Please enter a valid birthdate.", vbExclamation, "Registration")
                DateTimePicker1.Focus()
                Exit Sub
            End If

            If txtContactNum.Text.Length <> 11 OrElse Not IsNumeric(txtContactNum.Text) Then
                MsgBox("Contact Number must be exactly 11 digits long and numeric.", vbExclamation, "Registration")
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtEmail.Text) Then
                MsgBox("Please fill in your email.", vbExclamation, "Registration")
                Exit Sub
            End If

            If txtPassword.Text.Length < 8 OrElse txtPassword.Text.Length > 12 Then
                MsgBox("Password must be between 8 and 12 characters long.", vbExclamation, "Registration")
                txtPassword.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtUsername.Text) Then
                MsgBox("Please fill in your username.", vbExclamation, "Registration")
                Exit Sub
            End If

            Dim checkUser As New MySqlCommand("SELECT COUNT(*) FROM tbl_account WHERE username = @u", conn)
            checkUser.Parameters.AddWithValue("@u", txtUsername.Text)
            If Convert.ToInt32(checkUser.ExecuteScalar()) > 0 Then
                MsgBox("Username already exists. Please choose a different username.", vbExclamation, "Registration")
                Exit Sub
            End If



            Dim insertCmd As New MySqlCommand("INSERT INTO tbl_account (user_id, username, password, first_name, middle_name, last_name, suffix,course, year_level,gender, birthdate, contact_num, email,account_type, account_status, attempts)
            VALUES (@sid, @u, @p, @fname, @mname, @lname, @suf, @course, @year, @g, @bd, @cn, @em,'Student', 'Active', 3)", conn)
            insertCmd.Parameters.AddWithValue("@sid", txtUserID.Text)
            insertCmd.Parameters.AddWithValue("@u", txtUsername.Text)
            insertCmd.Parameters.AddWithValue("@p", txtPassword.Text)
            insertCmd.Parameters.AddWithValue("@fname", txtFirstName.Text.Trim())
            insertCmd.Parameters.AddWithValue("@mname", If(String.IsNullOrWhiteSpace(txtMiddleName.Text), DBNull.Value, txtMiddleName.Text.Trim()))
            insertCmd.Parameters.AddWithValue("@lname", txtLastName.Text.Trim())
            insertCmd.Parameters.AddWithValue("@suf", If(String.IsNullOrWhiteSpace(txtSuffix.Text), DBNull.Value, txtSuffix.Text.Trim()))
            insertCmd.Parameters.AddWithValue("@course", cboCourse.Text)
            insertCmd.Parameters.AddWithValue("@year", cboYear.Text)
            insertCmd.Parameters.AddWithValue("@g", cboGender.Text)
            insertCmd.Parameters.AddWithValue("@bd", DateTimePicker1.Value)
            insertCmd.Parameters.AddWithValue("@cn", txtContactNum.Text)
            insertCmd.Parameters.AddWithValue("@em", txtEmail.Text)
            insertCmd.ExecuteNonQuery()
        End Using

        MsgBox("Successfully Registered, you can now log in", vbInformation, "USER REGISTRATION")

        txtFirstName.Clear() : txtMiddleName.Clear() : txtLastName.Clear() : txtSuffix.Clear()
        txtUserID.Clear() : cboCourse.ResetText() : cboYear.ResetText()
        txtContactNum.Clear() : txtEmail.Clear() : cboGender.ResetText()
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

    Private Sub frmRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        DateTimePicker1.MaxDate = DateTime.Now.Date
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub
End Class