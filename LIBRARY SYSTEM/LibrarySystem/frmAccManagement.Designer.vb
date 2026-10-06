<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccManagement
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.cboCourse = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboYear_Level = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtContactNum = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboGender = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtMiddleName = New System.Windows.Forms.TextBox()
        Me.txtSuffix = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.lblname = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lblposition = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Username = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Password = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Birthdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Course = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Year = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtconfirmpassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtusername = New System.Windows.Forms.TextBox()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cboacctype = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtidno = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Panel4.SuspendLayout()
        Me.Panel13.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Controls.Add(Me.Label20)
        Me.Panel4.Controls.Add(Me.txtidno)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.txtEmail)
        Me.Panel4.Controls.Add(Me.cboCourse)
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Controls.Add(Me.cboYear_Level)
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Controls.Add(Me.txtLastName)
        Me.Panel4.Controls.Add(Me.DateTimePicker1)
        Me.Panel4.Controls.Add(Me.txtFirstName)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.txtContactNum)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.cboGender)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.txtMiddleName)
        Me.Panel4.Controls.Add(Me.txtSuffix)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Location = New System.Drawing.Point(489, 87)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(842, 324)
        Me.Panel4.TabIndex = 66
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(541, 183)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 23)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "Email"
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(541, 206)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(263, 29)
        Me.txtEmail.TabIndex = 68
        '
        'cboCourse
        '
        Me.cboCourse.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCourse.FormattingEnabled = True
        Me.cboCourse.Items.AddRange(New Object() {"BS Psychology", "BS Accountancy", "BS Customs Administration", "BS Business Administration", "BS Computer Science", "BS Information Technology", "BS Criminology", "Bachelor of Elementary Education", "Bachelor of Secondary Education", "Bachelor of Technical Vocational Teacher Education", "BS Computer Engineering", "BS Industrial Engineering", "Juris Doctor", "BS Real Estate Management", "BS Hospitality Management", "BS Tourism Management"})
        Me.cboCourse.Location = New System.Drawing.Point(264, 206)
        Me.cboCourse.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboCourse.Name = "cboCourse"
        Me.cboCourse.Size = New System.Drawing.Size(255, 29)
        Me.cboCourse.TabIndex = 67
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(264, 250)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 23)
        Me.Label19.TabIndex = 66
        Me.Label19.Text = "Year"
        '
        'cboYear_Level
        '
        Me.cboYear_Level.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboYear_Level.FormattingEnabled = True
        Me.cboYear_Level.Items.AddRange(New Object() {"1st year", "2nd year", "3rd year", "4th year"})
        Me.cboYear_Level.Location = New System.Drawing.Point(264, 273)
        Me.cboYear_Level.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboYear_Level.Name = "cboYear_Level"
        Me.cboYear_Level.Size = New System.Drawing.Size(255, 29)
        Me.cboYear_Level.TabIndex = 65
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(11, 11)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(257, 32)
        Me.Label18.TabIndex = 64
        Me.Label18.Text = "Personal Information"
        '
        'txtLastName
        '
        Me.txtLastName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(15, 206)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(228, 29)
        Me.txtLastName.TabIndex = 56
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(541, 76)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(263, 32)
        Me.DateTimePicker1.TabIndex = 61
        '
        'txtFirstName
        '
        Me.txtFirstName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Location = New System.Drawing.Point(17, 83)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(228, 29)
        Me.txtFirstName.TabIndex = 38
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(264, 182)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 23)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Course"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(541, 116)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(138, 23)
        Me.Label10.TabIndex = 44
        Me.Label10.Text = "Contact Number"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 58)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 23)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "First Name"
        '
        'txtContactNum
        '
        Me.txtContactNum.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactNum.Location = New System.Drawing.Point(541, 139)
        Me.txtContactNum.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtContactNum.Name = "txtContactNum"
        Me.txtContactNum.Size = New System.Drawing.Size(263, 29)
        Me.txtContactNum.TabIndex = 43
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(260, 58)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 23)
        Me.Label15.TabIndex = 59
        Me.Label15.Text = "Suffix"
        '
        'cboGender
        '
        Me.cboGender.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGender.FormattingEnabled = True
        Me.cboGender.Items.AddRange(New Object() {"Female", "Male", "Prefer not to say"})
        Me.cboGender.Location = New System.Drawing.Point(264, 143)
        Me.cboGender.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboGender.Name = "cboGender"
        Me.cboGender.Size = New System.Drawing.Size(255, 29)
        Me.cboGender.TabIndex = 47
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(541, 49)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 23)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Birthdate"
        '
        'txtMiddleName
        '
        Me.txtMiddleName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMiddleName.Location = New System.Drawing.Point(17, 143)
        Me.txtMiddleName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(228, 29)
        Me.txtMiddleName.TabIndex = 54
        '
        'txtSuffix
        '
        Me.txtSuffix.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSuffix.Location = New System.Drawing.Point(263, 82)
        Me.txtSuffix.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSuffix.Name = "txtSuffix"
        Me.txtSuffix.Size = New System.Drawing.Size(256, 29)
        Me.txtSuffix.TabIndex = 58
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(17, 119)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(113, 23)
        Me.Label12.TabIndex = 55
        Me.Label12.Text = "Middle Name"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(15, 182)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 23)
        Me.Label13.TabIndex = 57
        Me.Label13.Text = "Last Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(260, 118)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 23)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Gender"
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.White
        Me.Panel13.Controls.Add(Me.lblname)
        Me.Panel13.Controls.Add(Me.Label29)
        Me.Panel13.Controls.Add(Me.Label28)
        Me.Panel13.Controls.Add(Me.lblposition)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel13.Location = New System.Drawing.Point(0, 925)
        Me.Panel13.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(1628, 33)
        Me.Panel13.TabIndex = 158
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.BackColor = System.Drawing.Color.Transparent
        Me.lblname.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblname.Location = New System.Drawing.Point(72, 4)
        Me.lblname.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(66, 28)
        Me.lblname.TabIndex = 64
        Me.lblname.Text = "Name"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.Label29.Location = New System.Drawing.Point(5, 4)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(68, 28)
        Me.Label29.TabIndex = 63
        Me.Label29.Text = "Name:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(332, 4)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(86, 28)
        Me.Label28.TabIndex = 65
        Me.Label28.Text = "Position:"
        '
        'lblposition
        '
        Me.lblposition.AutoSize = True
        Me.lblposition.BackColor = System.Drawing.Color.Transparent
        Me.lblposition.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblposition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblposition.Location = New System.Drawing.Point(420, 4)
        Me.lblposition.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblposition.Name = "lblposition"
        Me.lblposition.Size = New System.Drawing.Size(100, 28)
        Me.lblposition.TabIndex = 66
        Me.lblposition.Text = "NPosition"
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Username, Me.Password, Me.FullName, Me.Gender, Me.Birthdate, Me.ContactNo, Me.Email, Me.Course, Me.Year})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Location = New System.Drawing.Point(25, 480)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(1583, 414)
        Me.DataGridView1.TabIndex = 159
        '
        'Username
        '
        Me.Username.HeaderText = "Username"
        Me.Username.MinimumWidth = 6
        Me.Username.Name = "Username"
        '
        'Password
        '
        Me.Password.HeaderText = "Password"
        Me.Password.MinimumWidth = 6
        Me.Password.Name = "Password"
        '
        'FullName
        '
        Me.FullName.HeaderText = "Full Name"
        Me.FullName.MinimumWidth = 6
        Me.FullName.Name = "FullName"
        '
        'Gender
        '
        Me.Gender.HeaderText = "Gender"
        Me.Gender.MinimumWidth = 6
        Me.Gender.Name = "Gender"
        '
        'Birthdate
        '
        Me.Birthdate.HeaderText = "Birthdate"
        Me.Birthdate.MinimumWidth = 6
        Me.Birthdate.Name = "Birthdate"
        '
        'ContactNo
        '
        Me.ContactNo.HeaderText = "Contact No."
        Me.ContactNo.MinimumWidth = 6
        Me.ContactNo.Name = "ContactNo"
        '
        'Email
        '
        Me.Email.HeaderText = "Email"
        Me.Email.MinimumWidth = 6
        Me.Email.Name = "Email"
        '
        'Course
        '
        Me.Course.HeaderText = "Course"
        Me.Course.MinimumWidth = 6
        Me.Course.Name = "Course"
        '
        'Year
        '
        Me.Year.HeaderText = "Year"
        Me.Year.MinimumWidth = 6
        Me.Year.Name = "Year"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(19, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(427, 45)
        Me.Label1.TabIndex = 160
        Me.Label1.Text = "ACCOUNT MANAGEMENT"
        '
        'txtconfirmpassword
        '
        Me.txtconfirmpassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtconfirmpassword.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtconfirmpassword.Location = New System.Drawing.Point(194, 146)
        Me.txtconfirmpassword.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtconfirmpassword.Name = "txtconfirmpassword"
        Me.txtconfirmpassword.Size = New System.Drawing.Size(203, 29)
        Me.txtconfirmpassword.TabIndex = 165
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 149)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(149, 23)
        Me.Label3.TabIndex = 166
        Me.Label3.Text = "Confirm Password"
        '
        'txtusername
        '
        Me.txtusername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtusername.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusername.Location = New System.Drawing.Point(194, 57)
        Me.txtusername.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(203, 29)
        Me.txtusername.TabIndex = 161
        '
        'txtpassword
        '
        Me.txtpassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpassword.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpassword.Location = New System.Drawing.Point(194, 99)
        Me.txtpassword.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.Size = New System.Drawing.Size(203, 29)
        Me.txtpassword.TabIndex = 162
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 59)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 23)
        Me.Label4.TabIndex = 163
        Me.Label4.Text = "Username"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 103)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 23)
        Me.Label5.TabIndex = 164
        Me.Label5.Text = "Password"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.cboacctype)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.cboStatus)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtconfirmpassword)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtusername)
        Me.Panel1.Controls.Add(Me.txtpassword)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(27, 87)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(437, 324)
        Me.Panel1.TabIndex = 167
        '
        'cboStatus
        '
        Me.cboStatus.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(194, 186)
        Me.cboStatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(203, 29)
        Me.cboStatus.TabIndex = 172
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(20, 186)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(57, 23)
        Me.Label16.TabIndex = 171
        Me.Label16.Text = "Status"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(16, 13)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(210, 32)
        Me.Label11.TabIndex = 70
        Me.Label11.Text = "User Information"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(27, 436)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(329, 23)
        Me.Label14.TabIndex = 168
        Me.Label14.Text = "SEARCH BY USERNAME OR LAST NAME"
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtSearch.Location = New System.Drawing.Point(371, 428)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(362, 34)
        Me.txtSearch.TabIndex = 169
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.White
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(1364, 293)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(224, 49)
        Me.btnClear.TabIndex = 72
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(103, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(1364, 228)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(224, 42)
        Me.btnDelete.TabIndex = 71
        Me.btnDelete.Text = "Delete Account"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(1364, 161)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(224, 42)
        Me.btnUpdate.TabIndex = 70
        Me.btnUpdate.Text = "Update Account"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(541, 263)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(263, 42)
        Me.Button1.TabIndex = 170
        Me.Button1.Text = "Add Account"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cboacctype
        '
        Me.cboacctype.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboacctype.FormattingEnabled = True
        Me.cboacctype.Location = New System.Drawing.Point(194, 227)
        Me.cboacctype.Margin = New System.Windows.Forms.Padding(4)
        Me.cboacctype.Name = "cboacctype"
        Me.cboacctype.Size = New System.Drawing.Size(203, 29)
        Me.cboacctype.TabIndex = 174
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(20, 231)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(114, 23)
        Me.Label17.TabIndex = 173
        Me.Label17.Text = "Account Type"
        '
        'txtidno
        '
        Me.txtidno.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtidno.Location = New System.Drawing.Point(19, 275)
        Me.txtidno.Margin = New System.Windows.Forms.Padding(4)
        Me.txtidno.Name = "txtidno"
        Me.txtidno.Size = New System.Drawing.Size(224, 29)
        Me.txtidno.TabIndex = 70
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(15, 248)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(59, 23)
        Me.Label20.TabIndex = 71
        Me.Label20.Text = "ID No."
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(193, 273)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(130, 20)
        Me.CheckBox1.TabIndex = 175
        Me.CheckBox1.Text = "Also a borrower?"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'frmAccManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1628, 958)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel13)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmAccManagement"
        Me.Text = "frmStudentManagement"
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel4 As Panel
    Friend WithEvents cboCourse As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents cboYear_Level As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtContactNum As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cboGender As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents txtSuffix As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents lblname As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents lblposition As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Username As DataGridViewTextBoxColumn
    Friend WithEvents Password As DataGridViewTextBoxColumn
    Friend WithEvents FullName As DataGridViewTextBoxColumn
    Friend WithEvents Gender As DataGridViewTextBoxColumn
    Friend WithEvents Birthdate As DataGridViewTextBoxColumn
    Friend WithEvents ContactNo As DataGridViewTextBoxColumn
    Friend WithEvents Email As DataGridViewTextBoxColumn
    Friend WithEvents Course As DataGridViewTextBoxColumn
    Friend WithEvents Year As DataGridViewTextBoxColumn
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtconfirmpassword As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtusername As TextBox
    Friend WithEvents txtpassword As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnClear As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txtidno As TextBox
    Friend WithEvents cboacctype As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents CheckBox1 As CheckBox
End Class
