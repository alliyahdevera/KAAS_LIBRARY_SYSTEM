Imports MySql.Data.MySqlClient

Public Class frmUserManagement

    Private Sub frmAccountManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        DateTimePicker1.MaxDate = DateTime.Now.Date
        RefreshList()
        ClearInputs()
    End Sub

    Private Sub frmAccountManagement_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            RefreshList()
            ClearInputs()
        End If
    End Sub

    Public Sub RefreshList(Optional keyword As String = "")
        listviewAccountManagement.Items.Clear() ' clear ROWS only, never Columns
        Dim kw As String = If(keyword, "").Trim()

        Using conn = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New MySqlCommand(
                "SELECT account_id, user_id, username, password, first_name, middle_name, last_name, suffix, " &
                "gender, birthdate, contact_num, email, course, year_level, account_type, account_status, attempts, date_registered " &
                "FROM tbl_account " &
                "WHERE @kw = '' OR username LIKE CONCAT('%',@kw,'%') OR first_name LIKE CONCAT('%',@kw,'%') " &
                "OR last_name LIKE CONCAT('%',@kw,'%') OR user_id LIKE CONCAT('%',@kw,'%') OR email LIKE CONCAT('%',@kw,'%')", conn)
            cmd.Parameters.AddWithValue("@kw", kw)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim item As New ListViewItem(reader("account_id").ToString())
                    item.SubItems.Add(reader("user_id").ToString())
                    item.SubItems.Add(reader("username").ToString())
                    item.SubItems.Add(reader("password").ToString())
                    Dim fullName As String = String.Join(" ",
                    {reader("first_name").ToString(),
                     reader("middle_name").ToString(),
                     reader("last_name").ToString(),
                     reader("suffix").ToString()}.Where(Function(s) Not String.IsNullOrWhiteSpace(s)))
                    item.SubItems.Add(fullName)
                    item.SubItems.Add(reader("gender").ToString())
                    item.SubItems.Add(reader("birthdate").ToString())
                    item.SubItems.Add(reader("contact_num").ToString())
                    item.SubItems.Add(reader("email").ToString())
                    item.SubItems.Add(reader("course").ToString())
                    item.SubItems.Add(reader("year_level").ToString())
                    item.SubItems.Add(reader("account_type").ToString())

                    ' Format account_status to properly capitalize first letter (e.g. active -> Active)
                    Dim rawStatus As String = reader("account_status").ToString()
                    Dim formattedStatus As String = If(String.IsNullOrEmpty(rawStatus), "", Char.ToUpper(rawStatus(0)) & rawStatus.Substring(1).ToLower())
                    item.SubItems.Add(formattedStatus)

                    item.SubItems.Add(reader("attempts").ToString())
                    If Not IsDBNull(reader("date_registered")) Then
                        item.SubItems.Add(Convert.ToDateTime(reader("date_registered")).ToString("MM/dd/yyyy"))
                    Else
                        item.SubItems.Add("")
                    End If
                    listviewAccountManagement.Items.Add(item)
                End While
            End Using
        End Using
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        RefreshList(txtSearch.Text)
    End Sub

    Private Sub ClearInputs()
        txtUsername.Clear()
        txtPassword.Clear()
        txtFirstName.Clear()
        txtMiddleName.Clear()
        txtLastName.Clear()
        txtSuffix.Clear()
        cboCourse.ResetText()
        cboYear_Level.ResetText()
        cboGender.ResetText()
        cboa_type.ResetText()
        txtContactNum.Clear()
        txtEmail.Clear()
        txtUserID.Clear()
        txtaccountstatus.Text = "Active"
        listviewAccountManagement.SelectedItems.Clear()
    End Sub

    Private Function GetSelectedUsername() As String
        If listviewAccountManagement.SelectedItems.Count = 0 Then Return Nothing
        Return listviewAccountManagement.SelectedItems(0).SubItems(2).Text
    End Function

    Private Sub LoadSelectedToInputs()
        Dim username = GetSelectedUsername()
        If username Is Nothing Then Exit Sub

        Using conn = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT * FROM tbl_account WHERE username = @u", conn)
            cmd.Parameters.AddWithValue("@u", username)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    txtUsername.Text = reader("username").ToString()
                    txtPassword.Text = reader("password").ToString()
                    txtFirstName.Text = reader("first_name").ToString()
                    txtMiddleName.Text = reader("middle_name").ToString()
                    txtLastName.Text = reader("last_name").ToString()
                    txtSuffix.Text = reader("suffix").ToString()
                    cboCourse.Text = reader("course").ToString()
                    cboYear_Level.Text = reader("year_level").ToString()
                    txtUserID.Text = reader("user_id").ToString()
                    cboGender.Text = reader("gender").ToString()
                    cboa_type.Text = reader("account_type").ToString()

                    If Not IsDBNull(reader("birthdate")) Then
                        DateTimePicker1.Value = Convert.ToDateTime(reader("birthdate"))
                    Else
                        DateTimePicker1.Value = DateTime.Now
                    End If

                    txtContactNum.Text = reader("contact_num").ToString()
                    txtEmail.Text = reader("email").ToString()

                    If Not IsDBNull(reader("account_status")) Then
                        txtaccountstatus.Text = StrConv(reader("account_status").ToString(), VbStrConv.ProperCase)
                    Else
                        txtaccountstatus.Text = "Active"
                    End If
                End If
            End Using
        End Using
    End Sub

    Private Sub lvStudents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listviewAccountManagement.SelectedIndexChanged
        LoadSelectedToInputs()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim username = GetSelectedUsername()
        If username Is Nothing Then
            MsgBox("Select a student first.", vbExclamation, "Account Management")
            Exit Sub
        End If

        If txtPassword.Text.Length < 8 Then
            MsgBox("Password must be at least 8 characters long.", vbExclamation, "Account Management")
            Exit Sub
        End If

        If txtFirstName.Text = "" Or txtLastName.Text = "" Or txtUserID.Text = "" Or cboGender.Text = "" Then
            MsgBox("First Name, Last Name, User ID, and Gender are required.", vbExclamation, "Account Management")
            Exit Sub
        End If

        If cboa_type.Text <> "Student" AndAlso cboa_type.Text <> "Teacher" AndAlso
           cboa_type.Text <> "Librarian" AndAlso cboa_type.Text <> "Admin" Then
            MsgBox("Please select a valid Account Type (Student, Teacher, Librarian, or Admin).", vbExclamation, "Account Management")
            Exit Sub
        End If

        ' Course and Year Level only matter for Student accounts
        If cboa_type.Text = "Student" Then
            If String.IsNullOrWhiteSpace(cboCourse.Text) OrElse String.IsNullOrWhiteSpace(cboYear_Level.Text) Then
                MsgBox("Course and Year Level are required for Student accounts.", vbExclamation, "Account Management")
                Exit Sub
            End If
        End If

        Dim birthdate As Date = DateTimePicker1.Value.Date
        If birthdate > DateTime.Now.Date Then
            MsgBox("Birthdate cannot be in the future.", vbExclamation, "Account Management")
            DateTimePicker1.Focus()
            Exit Sub
        End If

        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()

                Dim checkUser As New MySqlCommand(
                    "SELECT COUNT(*) FROM tbl_account WHERE username = @u AND username <> @old", conn)
                checkUser.Parameters.AddWithValue("@u", txtUsername.Text)
                checkUser.Parameters.AddWithValue("@old", username)
                If Convert.ToInt32(checkUser.ExecuteScalar()) > 0 Then
                    MsgBox("Username already exists. Please choose a different username.", vbExclamation, "Account Management")
                    Exit Sub
                End If

                Dim checkUid As New MySqlCommand(
                    "SELECT COUNT(*) FROM tbl_account WHERE user_id = @uid AND username <> @old", conn)
                checkUid.Parameters.AddWithValue("@uid", txtUserID.Text)
                checkUid.Parameters.AddWithValue("@old", username)
                If Convert.ToInt32(checkUid.ExecuteScalar()) > 0 Then
                    MsgBox("User ID already exists. Please choose a different User ID.", vbExclamation, "Account Management")
                    Exit Sub
                End If

                Dim cmd As New MySqlCommand(
                    "UPDATE tbl_account SET username=@u, password=@p, first_name=@fn, middle_name=@mn, last_name=@ln, suffix=@sf, " &
                    "course=@course, year_level=@yl, user_id=@uid, gender=@g, birthdate=@bd, contact_num=@cn, email=@em, account_type=@at, account_status=@st, attempts=3 " &
                    "WHERE username=@old", conn)
                cmd.Parameters.AddWithValue("@u", txtUsername.Text)
                cmd.Parameters.AddWithValue("@p", txtPassword.Text)
                cmd.Parameters.AddWithValue("@fn", txtFirstName.Text)
                cmd.Parameters.AddWithValue("@mn", If(txtMiddleName.Text = "", DBNull.Value, txtMiddleName.Text))
                cmd.Parameters.AddWithValue("@ln", txtLastName.Text)
                cmd.Parameters.AddWithValue("@sf", If(txtSuffix.Text = "", DBNull.Value, txtSuffix.Text))
                cmd.Parameters.AddWithValue("@course", If(cboa_type.Text = "Student", cboCourse.Text, If(String.IsNullOrWhiteSpace(cboCourse.Text), CType(DBNull.Value, Object), cboCourse.Text)))
                cmd.Parameters.AddWithValue("@yl", If(cboa_type.Text = "Student", cboYear_Level.Text, If(String.IsNullOrWhiteSpace(cboYear_Level.Text), CType(DBNull.Value, Object), cboYear_Level.Text)))
                cmd.Parameters.AddWithValue("@uid", txtUserID.Text)
                cmd.Parameters.AddWithValue("@g", cboGender.Text)
                cmd.Parameters.AddWithValue("@bd", birthdate)
                cmd.Parameters.AddWithValue("@cn", txtContactNum.Text)
                cmd.Parameters.AddWithValue("@em", txtEmail.Text)
                cmd.Parameters.AddWithValue("@at", cboa_type.Text)
                cmd.Parameters.AddWithValue("@st", If(txtaccountstatus.Text = "", "Active", txtaccountstatus.Text))
                cmd.Parameters.AddWithValue("@old", username)
                cmd.ExecuteNonQuery()
            End Using

            RefreshList()
            MsgBox("Account updated.", vbInformation, "Account Management")

        Catch ex As Exception
            MsgBox("Update failed: " & ex.Message, vbCritical, "Account Management")
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse txtPassword.Text.Length < 8 Then
            MsgBox("Username and a password of at least 8 characters are required.", vbExclamation, "Account Management")
            Exit Sub
        End If

        If txtFirstName.Text = "" Or txtLastName.Text = "" Or txtUserID.Text = "" Or cboGender.Text = "" Then
            MsgBox("First Name, Last Name, User ID, and Gender are required.", vbExclamation, "Account Management")
            Exit Sub
        End If

        If cboa_type.Text <> "Student" AndAlso cboa_type.Text <> "Teacher" AndAlso
           cboa_type.Text <> "Librarian" AndAlso cboa_type.Text <> "Admin" Then
            MsgBox("Please select a valid Account Type (Student, Teacher, Librarian, or Admin).", vbExclamation, "Account Management")
            Exit Sub
        End If

        ' Course and Year Level only matter for Student accounts
        If cboa_type.Text = "Student" Then
            If String.IsNullOrWhiteSpace(cboCourse.Text) OrElse String.IsNullOrWhiteSpace(cboYear_Level.Text) Then
                MsgBox("Course and Year Level are required for Student accounts.", vbExclamation, "Account Management")
                Exit Sub
            End If
        End If

        Dim birthdate As Date = DateTimePicker1.Value.Date
        If birthdate > DateTime.Now.Date Then
            MsgBox("Birthdate cannot be in the future.", vbExclamation, "Account Management")
            DateTimePicker1.Focus()
            Exit Sub
        End If

        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Dim checkCmd As New MySqlCommand(
                    "SELECT COUNT(*) FROM tbl_account WHERE username=@u OR user_id=@uid", conn)
                checkCmd.Parameters.AddWithValue("@u", txtUsername.Text)
                checkCmd.Parameters.AddWithValue("@uid", txtUserID.Text)
                If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                    MsgBox("Username or User ID already exists.", vbExclamation, "Account Management")
                    Exit Sub
                End If

                Dim cmd As New MySqlCommand(
                    "INSERT INTO tbl_account (user_id, username, password, first_name, middle_name, last_name, suffix, course, year_level, gender, birthdate, contact_num, email, account_type, account_status, attempts) " &
                    "VALUES (@uid, @u, @p, @fn, @mn, @ln, @sf, @course, @yl, @g, @bd, @cn, @em, @at, @st, 3)", conn)
                cmd.Parameters.AddWithValue("@uid", txtUserID.Text)
                cmd.Parameters.AddWithValue("@u", txtUsername.Text)
                cmd.Parameters.AddWithValue("@p", txtPassword.Text)
                cmd.Parameters.AddWithValue("@fn", txtFirstName.Text)
                cmd.Parameters.AddWithValue("@mn", If(txtMiddleName.Text = "", DBNull.Value, txtMiddleName.Text))
                cmd.Parameters.AddWithValue("@ln", txtLastName.Text)
                cmd.Parameters.AddWithValue("@sf", If(txtSuffix.Text = "", DBNull.Value, txtSuffix.Text))
                cmd.Parameters.AddWithValue("@course", If(cboa_type.Text = "Student", cboCourse.Text, If(String.IsNullOrWhiteSpace(cboCourse.Text), CType(DBNull.Value, Object), cboCourse.Text)))
                cmd.Parameters.AddWithValue("@yl", If(cboa_type.Text = "Student", cboYear_Level.Text, If(String.IsNullOrWhiteSpace(cboYear_Level.Text), CType(DBNull.Value, Object), cboYear_Level.Text)))
                cmd.Parameters.AddWithValue("@g", cboGender.Text)
                cmd.Parameters.AddWithValue("@bd", birthdate)
                cmd.Parameters.AddWithValue("@cn", txtContactNum.Text)
                cmd.Parameters.AddWithValue("@em", txtEmail.Text)
                cmd.Parameters.AddWithValue("@at", cboa_type.Text)
                cmd.Parameters.AddWithValue("@st", If(txtaccountstatus.Text = "", "Active", txtaccountstatus.Text))
                cmd.ExecuteNonQuery()
            End Using

            MsgBox("Account added.", vbInformation, "Account Management")
            RefreshList()
            ClearInputs()

        Catch ex As Exception
            MsgBox("Add failed: " & ex.Message, vbCritical, "Account Management")
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim username = GetSelectedUsername()
        If username Is Nothing Then
            MsgBox("Select a student first.", vbExclamation, "Account Management")
            Exit Sub
        End If

        If MsgBox("Delete this student account?", vbQuestion + vbYesNo, "CONFIRMATION") = vbNo Then Exit Sub

        Using conn = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New MySqlCommand("DELETE FROM tbl_account WHERE username=@u", conn)
            cmd.Parameters.AddWithValue("@u", username)
            cmd.ExecuteNonQuery()
        End Using

        RefreshList()
        ClearInputs()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmAdminMenu.Show()
        Me.Hide()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If MsgBox("Are you sure you want to clear all fields?", vbQuestion + vbYesNo, "Book Management") = vbYes Then
            txtUserID.Clear()
            txtUsername.Clear()
            txtPassword.Clear()
            txtEmail.Clear()
            txtaccountstatus.Text = "Active"

            txtFirstName.Clear()
            txtMiddleName.Clear()
            txtLastName.Clear()
            txtSuffix.Clear()

            DateTimePicker1.Value = DateTime.Now.Date
            txtContactNum.Clear()
            cboCourse.ResetText()
            cboYear_Level.ResetText()
            cboGender.ResetText()
            cboa_type.ResetText()

            listviewAccountManagement.SelectedItems.Clear()
        End If
    End Sub

End Class