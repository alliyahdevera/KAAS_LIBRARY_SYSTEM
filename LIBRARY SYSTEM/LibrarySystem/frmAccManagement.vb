Imports System.Linq
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class frmAccManagement

    Private Class AccountInfo
        Public UserId As Integer
        Public SchoolId As String
        Public Uname As String
        Public First As String
        Public Middle As String
        Public Last As String
        Public Suffix As String
        Public GenderText As String
        Public Birth As Date?
        Public Contact As String
        Public EmailText As String
        Public Role As String
        Public MemberType As String
        Public CourseText As String
        Public YearLevel As Integer
        Public Dept As String
        Public StatusText As String
    End Class

    Private schoolBox As TextBox
    Private typeBox As ComboBox
    Private borrowerBox As CheckBox
    Private selectedUserId As Integer = 0
    Private Const LibraryDept As String = "Library"     ' every librarian belongs to the Library department
    Private pageLoaded As Boolean = False

    Private Sub frmAccManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UiHelpers.FillHeader(Me)
        BuildExtraControls()
        SetupGrid()
        txtpassword.UseSystemPasswordChar = True
        txtconfirmpassword.UseSystemPasswordChar = True
        DateTimePicker1.MaxDate = Date.Today
        cboGender.DropDownStyle = ComboBoxStyle.DropDownList
        cboYear_Level.DropDownStyle = ComboBoxStyle.DropDownList
        cboCourse.DropDownStyle = ComboBoxStyle.DropDown        ' students pick a course, others type a department
        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatus.Items.Clear()
        cboStatus.Items.AddRange(New Object() {"Active", "Inactive", "Locked"})
        ClearForm()
        LoadAccounts()
        pageLoaded = True
    End Sub

    Private Sub frmAccManagement_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible AndAlso pageLoaded Then LoadAccounts(txtSearch.Text)
    End Sub

    Private Sub BuildExtraControls()
        Dim everything As List(Of Control) = AllControls(Me)

        ' Controls that already have a known job; whatever is left over is the new one.
        Dim knownBoxes As String() = {"txtFirstName", "txtMiddleName", "txtLastName", "txtSuffix",
                                      "txtContactNum", "txtEmail", "txtusername", "txtpassword",
                                      "txtconfirmpassword", "txtSearch"}
        Dim knownCombos As String() = {"cboStatus", "cboGender", "cboCourse", "cboYear_Level"}

        schoolBox = everything.OfType(Of TextBox)().FirstOrDefault(Function(t) t.Name = "txtSchoolID")
        If schoolBox Is Nothing Then
            schoolBox = everything.OfType(Of TextBox)().FirstOrDefault(
                Function(t) Not knownBoxes.Contains(t.Name, StringComparer.OrdinalIgnoreCase))
        End If

        typeBox = everything.OfType(Of ComboBox)().FirstOrDefault(Function(c) c.Name = "cboMemberType")
        If typeBox Is Nothing Then
            typeBox = everything.OfType(Of ComboBox)().FirstOrDefault(
                Function(c) Not knownCombos.Contains(c.Name, StringComparer.OrdinalIgnoreCase))
        End If

        borrowerBox = everything.OfType(Of CheckBox)().FirstOrDefault()

        If schoolBox Is Nothing OrElse typeBox Is Nothing OrElse borrowerBox Is Nothing Then
            MsgBox("Account Management could not find the ID No., Account Type or 'Also a borrower?' control." & vbCrLf &
                   "In the designer, name them txtSchoolID, cboMemberType and chkBorrower.",
                   vbCritical, "Account Management")
            Me.Enabled = False
            Throw New InvalidOperationException("Account Management controls are missing.")
        End If

        schoolBox.MaxLength = 20

        typeBox.DropDownStyle = ComboBoxStyle.DropDownList
        typeBox.Items.Clear()
        typeBox.Items.AddRange(New Object() {"Student", "Teacher", "Staff", "Librarian"})
        AddHandler typeBox.SelectedIndexChanged, AddressOf TypeChanged

        borrowerBox.Text = "Also a borrower?"
        borrowerBox.Enabled = False          ' only a Librarian can choose this (see TypeChanged)
    End Sub

    Private Function AllControls(parent As Control) As List(Of Control)
        Dim result As New List(Of Control)
        For Each c As Control In parent.Controls
            result.Add(c)
            result.AddRange(AllControls(c))
        Next
        Return result
    End Function

    Private Sub SetupGrid()
        With DataGridView1
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            If Not .Columns.Contains("colSchoolId") Then
                .Columns.Insert(0, New DataGridViewTextBoxColumn With {.Name = "colSchoolId", .HeaderText = "School ID"})
                .Columns.Insert(1, New DataGridViewTextBoxColumn With {.Name = "colType", .HeaderText = "Type"})
                .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colStatus", .HeaderText = "Status"})
            End If
            .Columns("Password").Visible = False          ' passwords are hashed now, nothing to show
            .Columns("Course").HeaderText = "Course / Dept."
        End With
    End Sub

    Private Sub TypeChanged(sender As Object, e As EventArgs)
        Dim t As String = typeBox.Text
        Dim isStudent As Boolean = (t = "Student")
        cboYear_Level.Enabled = isStudent
        If Not isStudent Then cboYear_Level.SelectedIndex = -1
        borrowerBox.Enabled = (t = "Librarian")
        If t <> "Librarian" Then borrowerBox.Checked = False
        Label6.Text = If(isStudent, "Course", "Department")

        If t = "Librarian" Then
            cboCourse.SelectedIndex = -1
            cboCourse.Text = LibraryDept
            cboCourse.Enabled = False
        Else
            cboCourse.Enabled = True
            If cboCourse.Text = LibraryDept Then cboCourse.Text = ""
        End If
    End Sub

    ' ------------------------------------------------------------ list
    Public Sub LoadAccounts(Optional keyword As String = "")
        DataGridView1.Rows.Clear()
        Dim kw As String = If(keyword, "").Trim()
        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT u.user_id, u.school_id, u.username, u.first_name, u.middle_name, u.last_name, u.suffix, " &
                    " u.gender, u.birthdate, u.contact_num, u.email, u.role, u.account_status, u.attempts, " &
                    " m.member_type, m.course, m.year_level, m.department " &
                    "FROM Users u LEFT JOIN Members m ON m.user_id = u.user_id " &
                    "WHERE u.role <> 'Admin' AND (@kw = '' OR u.username LIKE CONCAT('%',@kw,'%') " &
                    " OR u.last_name LIKE CONCAT('%',@kw,'%') OR u.first_name LIKE CONCAT('%',@kw,'%') " &
                    " OR u.school_id LIKE CONCAT('%',@kw,'%')) " &
                    "ORDER BY u.last_name, u.first_name", conn)
                    cmd.Parameters.AddWithValue("@kw", kw)
                    Using r As MySqlDataReader = cmd.ExecuteReader()
                        While r.Read()
                            Dim info As New AccountInfo With {
                                .UserId = Convert.ToInt32(r("user_id")),
                                .SchoolId = r("school_id").ToString(),
                                .Uname = r("username").ToString(),
                                .First = r("first_name").ToString(),
                                .Middle = If(IsDBNull(r("middle_name")), "", r("middle_name").ToString()),
                                .Last = r("last_name").ToString(),
                                .Suffix = If(IsDBNull(r("suffix")), "", r("suffix").ToString()),
                                .GenderText = r("gender").ToString(),
                                .Contact = r("contact_num").ToString(),
                                .EmailText = r("email").ToString(),
                                .Role = r("role").ToString(),
                                .MemberType = If(IsDBNull(r("member_type")), "", r("member_type").ToString()),
                                .CourseText = If(IsDBNull(r("course")), "", r("course").ToString()),
                                .YearLevel = If(IsDBNull(r("year_level")), 0, Convert.ToInt32(r("year_level"))),
                                .Dept = If(IsDBNull(r("department")), "", r("department").ToString())
                            }
                            If Not IsDBNull(r("birthdate")) Then info.Birth = Convert.ToDateTime(r("birthdate")).Date
                            Dim attempts As Integer = If(IsDBNull(r("attempts")), 3, Convert.ToInt32(r("attempts")))
                            info.StatusText = If(attempts <= 0, "Locked", r("account_status").ToString())

                            Dim typeText As String = info.MemberType
                            If info.Role = "Librarian" Then typeText = "Librarian" & If(info.MemberType <> "", " + Borrower", "")

                            Dim fullName As String = info.First & If(info.Middle <> "", " " & info.Middle.Substring(0, 1) & ".", "") &
                                                     " " & info.Last & If(info.Suffix <> "", " " & info.Suffix, "")

                            Dim row As DataGridViewRow = DataGridView1.Rows(DataGridView1.Rows.Add())
                            row.Cells("colSchoolId").Value = info.SchoolId
                            row.Cells("colType").Value = typeText
                            row.Cells("Username").Value = info.Uname
                            row.Cells("FullName").Value = fullName
                            row.Cells("Gender").Value = info.GenderText
                            row.Cells("Birthdate").Value = If(info.Birth.HasValue, info.Birth.Value.ToString("MM/dd/yyyy"), "")
                            row.Cells("ContactNo").Value = info.Contact
                            row.Cells("Email").Value = info.EmailText
                            row.Cells("Course").Value = If(info.Role = "Librarian", LibraryDept, If(info.MemberType = "Student", info.CourseText, info.Dept))
                            row.Cells("Year").Value = If(info.YearLevel >= 1 AndAlso info.YearLevel <= 4, cboYear_Level.Items(info.YearLevel - 1).ToString(), "")
                            row.Cells("colStatus").Value = info.StatusText
                            If info.StatusText <> "Active" Then row.DefaultCellStyle.ForeColor = Color.Firebrick
                            row.Tag = info
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not load accounts: " & ex.Message, vbCritical, "Account Management")
        End Try
        DataGridView1.ClearSelection()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadAccounts(txtSearch.Text)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim info As AccountInfo = TryCast(DataGridView1.Rows(e.RowIndex).Tag, AccountInfo)
        If info Is Nothing Then Exit Sub
        selectedUserId = info.UserId
        schoolBox.Text = info.SchoolId
        SelectItem(typeBox, If(info.Role = "Librarian", "Librarian", If(info.MemberType = "", "Student", info.MemberType)))
        borrowerBox.Checked = (info.Role = "Librarian" AndAlso info.MemberType <> "")
        txtFirstName.Text = info.First
        txtMiddleName.Text = info.Middle
        txtLastName.Text = info.Last
        txtSuffix.Text = info.Suffix
        SelectItem(cboGender, info.GenderText)
        If info.Birth.HasValue AndAlso info.Birth.Value >= DateTimePicker1.MinDate AndAlso info.Birth.Value <= DateTimePicker1.MaxDate Then
            DateTimePicker1.Value = info.Birth.Value
        Else
            DateTimePicker1.Value = Date.Today
        End If
        txtContactNum.Text = info.Contact
        txtEmail.Text = info.EmailText
        cboCourse.Text = If(info.Role = "Librarian", LibraryDept, If(info.MemberType = "Student", info.CourseText, info.Dept))
        If info.YearLevel >= 1 AndAlso info.YearLevel <= 4 Then cboYear_Level.SelectedIndex = info.YearLevel - 1 Else cboYear_Level.SelectedIndex = -1
        txtusername.Text = info.Uname
        txtpassword.Clear()
        txtconfirmpassword.Clear()
        SelectItem(cboStatus, info.StatusText)
    End Sub

    ' ------------------------------------------------------------ helpers
    Private Sub SelectItem(cbo As ComboBox, text As String)
        cbo.SelectedIndex = cbo.Items.IndexOf(text)
    End Sub

    Private Sub ClearForm()
        selectedUserId = 0
        schoolBox.Clear()
        typeBox.SelectedIndex = -1
        borrowerBox.Checked = False
        txtFirstName.Clear() : txtMiddleName.Clear() : txtLastName.Clear() : txtSuffix.Clear()
        cboGender.SelectedIndex = -1
        DateTimePicker1.Value = Date.Today
        txtContactNum.Clear() : txtEmail.Clear()
        cboCourse.SelectedIndex = -1 : cboCourse.Text = ""
        cboYear_Level.SelectedIndex = -1
        txtusername.Clear() : txtpassword.Clear() : txtconfirmpassword.Clear()
        cboStatus.SelectedIndex = -1
        Label6.Text = "Course"
        DataGridView1.ClearSelection()
    End Sub

    Private Function Opt(s As String) As Object
        If String.IsNullOrWhiteSpace(s) Then Return DBNull.Value
        Return s.Trim()
    End Function

    Private Function Taken(conn As MySqlConnection, tx As MySqlTransaction, column As String, value As String, excludeId As Integer) As Boolean
        Using cmd As New MySqlCommand("SELECT COUNT(*) FROM Users WHERE " & column & " = @v AND user_id <> @id", conn, tx)
            cmd.Parameters.AddWithValue("@v", value)
            cmd.Parameters.AddWithValue("@id", excludeId)
            Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
        End Using
    End Function

    ' Shows a message and returns False when something is wrong
    Private Function InputsAreValid(isNew As Boolean) As Boolean
        Dim t As String = typeBox.Text
        If t = "" Then Return Fail("Please choose the Account Type.", typeBox)
        If String.IsNullOrWhiteSpace(txtFirstName.Text) Then Return Fail("Please fill in the first name.", txtFirstName)
        If String.IsNullOrWhiteSpace(txtLastName.Text) Then Return Fail("Please fill in the last name.", txtLastName)

        Dim sid As String = schoolBox.Text.Trim()
        If t = "Student" Then
            If Not Regex.IsMatch(sid, "^\d{6}$") Then Return Fail("Student ID must be exactly 6 digits (numbers only).", schoolBox)
        Else
            If Not Regex.IsMatch(sid, "^[A-Za-z0-9\-]{3,20}$") Then Return Fail("School/Employee ID must be 3 to 20 letters, numbers or dashes.", schoolBox)
        End If

        If cboGender.SelectedIndex = -1 Then Return Fail("Please select a gender.", cboGender)

        Dim bd As Date = DateTimePicker1.Value.Date
        Dim age As Integer = Date.Today.Year - bd.Year
        If bd > Date.Today.AddYears(-age) Then age -= 1
        If age < 5 OrElse age > 100 Then Return Fail("Please enter a valid birthdate.", DateTimePicker1)

        If Not Regex.IsMatch(txtContactNum.Text.Trim(), "^\d{11}$") Then Return Fail("Contact Number must be exactly 11 digits.", txtContactNum)
        If Not Regex.IsMatch(txtEmail.Text.Trim(), "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then Return Fail("Please enter a valid email address.", txtEmail)

        If t = "Student" Then
            If cboCourse.Items.IndexOf(cboCourse.Text) = -1 Then Return Fail("Please pick a Course from the list.", cboCourse)
            If cboYear_Level.SelectedIndex = -1 Then Return Fail("Please select the Year level.", cboYear_Level)
        ElseIf t <> "Librarian" Then          ' librarians are fixed to the Library department
            If String.IsNullOrWhiteSpace(cboCourse.Text) Then Return Fail("Please enter the Department.", cboCourse)
        End If

        If String.IsNullOrWhiteSpace(txtusername.Text) OrElse txtusername.Text.Trim().Contains(" ") Then
            Return Fail("Please enter a username (no spaces).", txtusername)
        End If

        If isNew OrElse txtpassword.Text <> "" OrElse txtconfirmpassword.Text <> "" Then
            If txtpassword.Text.Length < 8 OrElse txtpassword.Text.Length > 12 Then Return Fail("Password must be between 8 and 12 characters long.", txtpassword)
            If txtpassword.Text <> txtconfirmpassword.Text Then Return Fail("Password and Confirm Password do not match.", txtconfirmpassword)
        End If

        If isNew AndAlso cboStatus.Text = "Locked" Then Return Fail("A new account cannot be created as Locked.", cboStatus)
        If Not isNew AndAlso cboStatus.SelectedIndex = -1 Then Return Fail("Please choose the account Status.", cboStatus)
        Return True
    End Function

    Private Function Fail(msg As String, focusOn As Control) As Boolean
        MsgBox(msg, vbExclamation, "Account Management")
        focusOn.Focus()
        Return False
    End Function

    Private Function RoleValue() As String
        Return If(typeBox.Text = "Librarian", "Librarian", "Member")
    End Function

    Private Function WantsBorrowerProfile() As Boolean
        Return typeBox.Text <> "Librarian" OrElse borrowerBox.Checked
    End Function

    Private Function BorrowerType() As String
        Return If(typeBox.Text = "Librarian", "Staff", typeBox.Text)
    End Function

    Private Sub BindMemberFields(cmd As MySqlCommand)
        Dim isStudent As Boolean = (BorrowerType() = "Student")
        cmd.Parameters.AddWithValue("@mt", BorrowerType())
        cmd.Parameters.AddWithValue("@course", If(isStudent, CObj(cboCourse.Text.Trim()), DBNull.Value))
        cmd.Parameters.AddWithValue("@yr", If(isStudent, CObj(cboYear_Level.SelectedIndex + 1), DBNull.Value))
        cmd.Parameters.AddWithValue("@dept", If(isStudent, DBNull.Value, CObj(If(typeBox.Text = "Librarian", LibraryDept, cboCourse.Text.Trim()))))
    End Sub

    ' ------------------------------------------------------------ add
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click      ' Add Account
        If Not InputsAreValid(True) Then Exit Sub
        Dim inactive As Boolean = (cboStatus.Text = "Inactive")
        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using tx As MySqlTransaction = conn.BeginTransaction()
                    Try
                        If Taken(conn, tx, "school_id", schoolBox.Text.Trim(), 0) Then
                            MsgBox("This ID is already registered.", vbExclamation, "Account Management") : tx.Rollback() : Exit Sub
                        End If
                        If Taken(conn, tx, "username", txtusername.Text.Trim(), 0) Then
                            MsgBox("Username already exists. Please choose a different one.", vbExclamation, "Account Management") : tx.Rollback() : Exit Sub
                        End If

                        Dim newId As Integer
                        Using ins As New MySqlCommand(
                            "INSERT INTO Users (school_id, username, password, first_name, middle_name, last_name, suffix, gender, birthdate, " &
                            "contact_num, email, role, account_status, attempts) " &
                            "VALUES (@sid, @u, @p, @fn, @mn, @ln, @sf, @g, @bd, @cn, @em, @role, @st, 3)", conn, tx)
                            ins.Parameters.AddWithValue("@sid", schoolBox.Text.Trim())
                            ins.Parameters.AddWithValue("@u", txtusername.Text.Trim())
                            ins.Parameters.AddWithValue("@p", Security.HashPassword(txtpassword.Text))
                            ins.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim())
                            ins.Parameters.AddWithValue("@mn", Opt(txtMiddleName.Text))
                            ins.Parameters.AddWithValue("@ln", txtLastName.Text.Trim())
                            ins.Parameters.AddWithValue("@sf", Opt(txtSuffix.Text))
                            ins.Parameters.AddWithValue("@g", cboGender.Text)
                            ins.Parameters.AddWithValue("@bd", DateTimePicker1.Value.Date)
                            ins.Parameters.AddWithValue("@cn", txtContactNum.Text.Trim())
                            ins.Parameters.AddWithValue("@em", txtEmail.Text.Trim())
                            ins.Parameters.AddWithValue("@role", RoleValue())
                            ins.Parameters.AddWithValue("@st", If(inactive, "Inactive", "Active"))
                            ins.ExecuteNonQuery()
                            newId = Convert.ToInt32(ins.LastInsertedId)
                        End Using

                        If WantsBorrowerProfile() Then
                            Using insM As New MySqlCommand(
                                "INSERT INTO Members (user_id, member_type, course, year_level, department) VALUES (@uid, @mt, @course, @yr, @dept)", conn, tx)
                                insM.Parameters.AddWithValue("@uid", newId)
                                BindMemberFields(insM)
                                insM.ExecuteNonQuery()
                            End Using
                        End If
                        tx.Commit()
                    Catch
                        tx.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not add the account: " & ex.Message, vbCritical, "Account Management")
            Exit Sub
        End Try

        DBConnection.LogActivity("Add Account", "Created " & typeBox.Text & " account '" & txtusername.Text.Trim() & "'.")
        MsgBox("Account added.", vbInformation, "Account Management")
        ClearForm()
        LoadAccounts(txtSearch.Text)
    End Sub

    ' ------------------------------------------------------------ update (also unlock)
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedUserId = 0 Then
            MsgBox("Select an account from the list first.", vbExclamation, "Account Management")
            Exit Sub
        End If
        If Not InputsAreValid(False) Then Exit Sub

        ' Active unlocks (attempts back to 3), Locked sets attempts to 0, Inactive keeps the attempts as they are
        Dim accStatus As String = If(cboStatus.Text = "Inactive", "Inactive", "Active")
        Dim attemptsValue As Object = DBNull.Value
        If cboStatus.Text = "Active" Then attemptsValue = 3
        If cboStatus.Text = "Locked" Then attemptsValue = 0

        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using tx As MySqlTransaction = conn.BeginTransaction()
                    Try
                        If Taken(conn, tx, "school_id", schoolBox.Text.Trim(), selectedUserId) Then
                            MsgBox("This ID belongs to another account.", vbExclamation, "Account Management") : tx.Rollback() : Exit Sub
                        End If
                        If Taken(conn, tx, "username", txtusername.Text.Trim(), selectedUserId) Then
                            MsgBox("That username belongs to another account.", vbExclamation, "Account Management") : tx.Rollback() : Exit Sub
                        End If

                        Dim changePwd As Boolean = (txtpassword.Text <> "")
                        Using upd As New MySqlCommand(
                            "UPDATE Users SET school_id=@sid, username=@u, first_name=@fn, middle_name=@mn, last_name=@ln, suffix=@sf, " &
                            "gender=@g, birthdate=@bd, contact_num=@cn, email=@em, role=@role, account_status=@st, " &
                            "attempts = IFNULL(@att, attempts)" & If(changePwd, ", password=@p", "") & " WHERE user_id=@id", conn, tx)
                            upd.Parameters.AddWithValue("@sid", schoolBox.Text.Trim())
                            upd.Parameters.AddWithValue("@u", txtusername.Text.Trim())
                            upd.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim())
                            upd.Parameters.AddWithValue("@mn", Opt(txtMiddleName.Text))
                            upd.Parameters.AddWithValue("@ln", txtLastName.Text.Trim())
                            upd.Parameters.AddWithValue("@sf", Opt(txtSuffix.Text))
                            upd.Parameters.AddWithValue("@g", cboGender.Text)
                            upd.Parameters.AddWithValue("@bd", DateTimePicker1.Value.Date)
                            upd.Parameters.AddWithValue("@cn", txtContactNum.Text.Trim())
                            upd.Parameters.AddWithValue("@em", txtEmail.Text.Trim())
                            upd.Parameters.AddWithValue("@role", RoleValue())
                            upd.Parameters.AddWithValue("@st", accStatus)
                            upd.Parameters.AddWithValue("@att", attemptsValue)
                            If changePwd Then upd.Parameters.AddWithValue("@p", Security.HashPassword(txtpassword.Text))
                            upd.Parameters.AddWithValue("@id", selectedUserId)
                            upd.ExecuteNonQuery()
                        End Using

                        ' borrower profile (Members row)
                        Dim memberId As Integer = 0
                        Using q As New MySqlCommand("SELECT member_id FROM Members WHERE user_id = @id FOR UPDATE", conn, tx)
                            q.Parameters.AddWithValue("@id", selectedUserId)
                            Dim o As Object = q.ExecuteScalar()
                            If o IsNot Nothing AndAlso Not IsDBNull(o) Then memberId = Convert.ToInt32(o)
                        End Using

                        If WantsBorrowerProfile() Then
                            Dim sql As String = If(memberId > 0,
                                "UPDATE Members SET member_type=@mt, course=@course, year_level=@yr, department=@dept WHERE user_id=@uid",
                                "INSERT INTO Members (user_id, member_type, course, year_level, department) VALUES (@uid, @mt, @course, @yr, @dept)")
                            Using m As New MySqlCommand(sql, conn, tx)
                                m.Parameters.AddWithValue("@uid", selectedUserId)
                                BindMemberFields(m)
                                m.ExecuteNonQuery()
                            End Using
                        ElseIf memberId > 0 Then
                            Using c As New MySqlCommand("SELECT COUNT(*) FROM BorrowTransaction WHERE member_id = @m", conn, tx)
                                c.Parameters.AddWithValue("@m", memberId)
                                If Convert.ToInt32(c.ExecuteScalar()) > 0 Then
                                    Throw New InvalidOperationException("This person already has borrowing history, so the borrower profile can't be removed. Keep 'Also a borrower' ticked.")
                                End If
                            End Using
                            Using d As New MySqlCommand("DELETE FROM Members WHERE member_id = @m", conn, tx)
                                d.Parameters.AddWithValue("@m", memberId)
                                d.ExecuteNonQuery()
                            End Using
                        End If
                        tx.Commit()
                    Catch
                        tx.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As InvalidOperationException
            MsgBox(ex.Message, vbExclamation, "Account Management")
            Exit Sub
        Catch ex As Exception
            MsgBox("Could not update the account: " & ex.Message, vbCritical, "Account Management")
            Exit Sub
        End Try

        DBConnection.LogActivity("Update Account", "Updated account '" & txtusername.Text.Trim() & "' (status " & cboStatus.Text & ").")
        MsgBox("Account updated.", vbInformation, "Account Management")
        ClearForm()
        LoadAccounts(txtSearch.Text)
    End Sub

    ' ------------------------------------------------------------ delete
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedUserId = 0 Then
            MsgBox("Select an account from the list first.", vbExclamation, "Account Management")
            Exit Sub
        End If
        If selectedUserId = AppSession.UserId Then
            MsgBox("You can't delete the account you are logged in with.", vbExclamation, "Account Management")
            Exit Sub
        End If
        Dim uname As String = txtusername.Text.Trim()
        If MsgBox("Delete the account '" & uname & "'? This cannot be undone.", vbQuestion + vbYesNo, "Delete Account") <> vbYes Then Exit Sub

        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Dim history As Integer
                Using c As New MySqlCommand(
                    "SELECT COUNT(*) FROM BorrowTransaction t JOIN Members m ON m.member_id = t.member_id WHERE m.user_id = @id", conn)
                    c.Parameters.AddWithValue("@id", selectedUserId)
                    history = Convert.ToInt32(c.ExecuteScalar())
                End Using

                If history > 0 Then
                    If MsgBox("This account has borrowing history, so it can't be deleted without losing records." & vbCrLf &
                              "Set it to Inactive instead?", vbQuestion + vbYesNo, "Delete Account") = vbYes Then
                        Using u As New MySqlCommand("UPDATE Users SET account_status = 'Inactive' WHERE user_id = @id", conn)
                            u.Parameters.AddWithValue("@id", selectedUserId)
                            u.ExecuteNonQuery()
                        End Using
                        DBConnection.LogActivity("Deactivate Account", "Set account '" & uname & "' to Inactive.")
                        MsgBox("Account set to Inactive.", vbInformation, "Account Management")
                    End If
                Else
                    Using d As New MySqlCommand("DELETE FROM Users WHERE user_id = @id", conn)
                        d.Parameters.AddWithValue("@id", selectedUserId)
                        d.ExecuteNonQuery()
                    End Using
                    DBConnection.LogActivity("Delete Account", "Deleted account '" & uname & "'.")
                    MsgBox("Account deleted.", vbInformation, "Account Management")
                End If
            End Using
        Catch ex As Exception
            MsgBox("Could not delete the account: " & ex.Message, vbCritical, "Account Management")
            Exit Sub
        End Try
        ClearForm()
        LoadAccounts(txtSearch.Text)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub
End Class