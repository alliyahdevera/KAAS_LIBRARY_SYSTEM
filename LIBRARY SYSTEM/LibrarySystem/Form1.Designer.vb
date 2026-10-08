<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim PictureBox1 As System.Windows.Forms.PictureBox
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PWPanel = New System.Windows.Forms.Panel()
        Me.PW = New System.Windows.Forms.PictureBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnViewPassword = New System.Windows.Forms.Button()
        Me.UserPanel = New System.Windows.Forms.Panel()
        Me.User = New System.Windows.Forms.PictureBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblAttempts = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblRegister = New System.Windows.Forms.LinkLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.lnklblForgotPass = New System.Windows.Forms.LinkLabel()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.PWPanel.SuspendLayout()
        CType(Me.PW, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UserPanel.SuspendLayout()
        CType(Me.User, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        PictureBox1.Image = Global.LibrarySystem.My.Resources.Resources.BOOK_LOGO_
        PictureBox1.Location = New System.Drawing.Point(199, 59)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New System.Drawing.Size(89, 98)
        PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 37
        PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BackgroundImage = Global.LibrarySystem.My.Resources.Resources.LOGIN_BORDER
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.PWPanel)
        Me.Panel2.Controls.Add(Me.UserPanel)
        Me.Panel2.Controls.Add(Me.lblAttempts)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(PictureBox1)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.lblRegister)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.btnLogin)
        Me.Panel2.Controls.Add(Me.lnklblForgotPass)
        Me.Panel2.Location = New System.Drawing.Point(613, 90)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(478, 573)
        Me.Panel2.TabIndex = 1
        '
        'PWPanel
        '
        Me.PWPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PWPanel.Controls.Add(Me.PW)
        Me.PWPanel.Controls.Add(Me.txtPassword)
        Me.PWPanel.Controls.Add(Me.btnViewPassword)
        Me.PWPanel.Location = New System.Drawing.Point(99, 331)
        Me.PWPanel.Name = "PWPanel"
        Me.PWPanel.Size = New System.Drawing.Size(296, 37)
        Me.PWPanel.TabIndex = 19
        '
        'PW
        '
        Me.PW.BackgroundImage = CType(resources.GetObject("PW.BackgroundImage"), System.Drawing.Image)
        Me.PW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PW.Location = New System.Drawing.Point(8, 8)
        Me.PW.Name = "PW"
        Me.PW.Size = New System.Drawing.Size(20, 20)
        Me.PW.TabIndex = 11
        Me.PW.TabStop = False
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(35, 7)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(225, 20)
        Me.txtPassword.TabIndex = 5
        '
        'btnViewPassword
        '
        Me.btnViewPassword.BackColor = System.Drawing.Color.Transparent
        Me.btnViewPassword.BackgroundImage = Global.LibrarySystem.My.Resources.Resources.eye2
        Me.btnViewPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnViewPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewPassword.ForeColor = System.Drawing.Color.Transparent
        Me.btnViewPassword.Location = New System.Drawing.Point(266, 7)
        Me.btnViewPassword.Name = "btnViewPassword"
        Me.btnViewPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnViewPassword.Size = New System.Drawing.Size(23, 23)
        Me.btnViewPassword.TabIndex = 40
        Me.btnViewPassword.UseVisualStyleBackColor = False
        '
        'UserPanel
        '
        Me.UserPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UserPanel.Controls.Add(Me.User)
        Me.UserPanel.Controls.Add(Me.txtUsername)
        Me.UserPanel.Location = New System.Drawing.Point(99, 254)
        Me.UserPanel.Name = "UserPanel"
        Me.UserPanel.Size = New System.Drawing.Size(296, 37)
        Me.UserPanel.TabIndex = 43
        '
        'User
        '
        Me.User.BackgroundImage = CType(resources.GetObject("User.BackgroundImage"), System.Drawing.Image)
        Me.User.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.User.Location = New System.Drawing.Point(8, 8)
        Me.User.Name = "User"
        Me.User.Size = New System.Drawing.Size(20, 20)
        Me.User.TabIndex = 11
        Me.User.TabStop = False
        '
        'txtUsername
        '
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(34, 7)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(254, 20)
        Me.txtUsername.TabIndex = 3
        '
        'lblAttempts
        '
        Me.lblAttempts.AutoSize = True
        Me.lblAttempts.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAttempts.Location = New System.Drawing.Point(97, 376)
        Me.lblAttempts.Name = "lblAttempts"
        Me.lblAttempts.Size = New System.Drawing.Size(76, 15)
        Me.lblAttempts.TabIndex = 41
        Me.lblAttempts.Text = "Attempts left"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Light", 13.0!)
        Me.Label4.Location = New System.Drawing.Point(193, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 25)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "THE K.A.A.S."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(166, 176)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(160, 36)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "LIBRARY"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(510, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(31, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "X"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblRegister
        '
        Me.lblRegister.AutoSize = True
        Me.lblRegister.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegister.Location = New System.Drawing.Point(280, 479)
        Me.lblRegister.Name = "lblRegister"
        Me.lblRegister.Size = New System.Drawing.Size(58, 19)
        Me.lblRegister.TabIndex = 10
        Me.lblRegister.TabStop = True
        Me.lblRegister.Text = "Register"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(156, 479)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 19)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Need an account?"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(95, 309)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 20)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Password"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(96, 232)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 20)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Username"
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Location = New System.Drawing.Point(100, 429)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(296, 29)
        Me.btnLogin.TabIndex = 6
        Me.btnLogin.Text = "Log in"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'lnklblForgotPass
        '
        Me.lnklblForgotPass.AutoSize = True
        Me.lnklblForgotPass.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnklblForgotPass.Location = New System.Drawing.Point(280, 372)
        Me.lnklblForgotPass.Name = "lnklblForgotPass"
        Me.lnklblForgotPass.Size = New System.Drawing.Size(118, 19)
        Me.lnklblForgotPass.TabIndex = 42
        Me.lnklblForgotPass.TabStop = True
        Me.lnklblForgotPass.Text = "Forgot Password?"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Red
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.Snow
        Me.btnExit.Location = New System.Drawing.Point(1126, 13)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(25, 25)
        Me.btnExit.TabIndex = 14
        Me.btnExit.Text = "X"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(145, 145)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(376, 146)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "The world's " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "knowledge,"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.LibrarySystem.My.Resources.Resources.CLICK2
        Me.PictureBox2.Location = New System.Drawing.Point(450, 344)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(45, 40)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Label2.Location = New System.Drawing.Point(153, 333)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(233, 30)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "just a single click away!"
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.BackgroundImage = Global.LibrarySystem.My.Resources.Resources.LIB_BG
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1163, 750)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnExit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PWPanel.ResumeLayout(False)
        Me.PWPanel.PerformLayout()
        CType(Me.PW, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UserPanel.ResumeLayout(False)
        Me.UserPanel.PerformLayout()
        CType(Me.User, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents lblRegister As LinkLabel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnLogin As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents btnViewPassword As Button
    Friend WithEvents lblAttempts As Label
    Friend WithEvents lnklblForgotPass As LinkLabel
    Friend WithEvents PWPanel As Panel
    Friend WithEvents PW As PictureBox
    Friend WithEvents UserPanel As Panel
    Friend WithEvents User As PictureBox
End Class
