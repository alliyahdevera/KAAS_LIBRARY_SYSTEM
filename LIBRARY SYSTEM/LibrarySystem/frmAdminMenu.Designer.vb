<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAdminMenu
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdminMenu))
        Dim PictureBox2 As System.Windows.Forms.PictureBox
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_dT = New System.Windows.Forms.Label()
        Me.lblt_datetime = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.lbldatetime = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblc_name = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tmrDateTime = New System.Windows.Forms.Timer(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnactlog = New System.Windows.Forms.Button()
        Me.btnlogout = New System.Windows.Forms.Button()
        Me.btnbookman = New System.Windows.Forms.Button()
        Me.btnborrowh = New System.Windows.Forms.Button()
        Me.btnaccman = New System.Windows.Forms.Button()
        Me.btndash = New System.Windows.Forms.Button()
        PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel9.SuspendLayout()
        CType(PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnactlog)
        Me.Panel2.Controls.Add(Me.btnlogout)
        Me.Panel2.Controls.Add(Me.Panel8)
        Me.Panel2.Controls.Add(Me.btnbookman)
        Me.Panel2.Controls.Add(Me.btnborrowh)
        Me.Panel2.Controls.Add(Me.btnaccman)
        Me.Panel2.Controls.Add(Me.btndash)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 77)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(223, 778)
        Me.Panel2.TabIndex = 17
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.White
        Me.Panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel8.Location = New System.Drawing.Point(269, 916)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(280, 34)
        Me.Panel8.TabIndex = 52
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lbl_dT)
        Me.Panel1.Controls.Add(Me.lblt_datetime)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(PictureBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1443, 77)
        Me.Panel1.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(-5, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1539, 20)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "—————————————————————————————————————————————————————————————————————————————————" &
    "—————————————————————"
        '
        'lbl_dT
        '
        Me.lbl_dT.AutoSize = True
        Me.lbl_dT.BackColor = System.Drawing.Color.Transparent
        Me.lbl_dT.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_dT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lbl_dT.Location = New System.Drawing.Point(1113, 28)
        Me.lbl_dT.Name = "lbl_dT"
        Me.lbl_dT.Size = New System.Drawing.Size(83, 21)
        Me.lbl_dT.TabIndex = 58
        Me.lbl_dT.Text = "time/date"
        Me.lbl_dT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblt_datetime
        '
        Me.lblt_datetime.AutoSize = True
        Me.lblt_datetime.BackColor = System.Drawing.Color.Transparent
        Me.lblt_datetime.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblt_datetime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblt_datetime.Location = New System.Drawing.Point(1606, 35)
        Me.lblt_datetime.Name = "lblt_datetime"
        Me.lblt_datetime.Size = New System.Drawing.Size(0, 21)
        Me.lblt_datetime.TabIndex = 57
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(67, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 15)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "MANAGEMENT SYSTEM"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(64, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(145, 32)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "LIBRARY"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.White
        Me.Panel9.Controls.Add(Me.lbldatetime)
        Me.Panel9.Controls.Add(Me.Label19)
        Me.Panel9.Controls.Add(Me.Label16)
        Me.Panel9.Controls.Add(Me.Label17)
        Me.Panel9.Controls.Add(Me.lblc_name)
        Me.Panel9.Controls.Add(Me.Label15)
        Me.Panel9.Location = New System.Drawing.Point(266, 1154)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(1203, 32)
        Me.Panel9.TabIndex = 53
        '
        'lbldatetime
        '
        Me.lbldatetime.AutoSize = True
        Me.lbldatetime.BackColor = System.Drawing.Color.Transparent
        Me.lbldatetime.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldatetime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lbldatetime.Location = New System.Drawing.Point(471, 6)
        Me.lbldatetime.Name = "lbldatetime"
        Me.lbldatetime.Size = New System.Drawing.Size(16, 21)
        Me.lbldatetime.TabIndex = 56
        Me.lbldatetime.Text = "-"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(399, 6)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 21)
        Me.Label19.TabIndex = 55
        Me.Label19.Text = "Today is"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(317, 6)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(58, 21)
        Me.Label16.TabIndex = 54
        Me.Label16.Text = "Admin"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(251, 6)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 21)
        Me.Label17.TabIndex = 53
        Me.Label17.Text = "Position:"
        '
        'lblc_name
        '
        Me.lblc_name.AutoSize = True
        Me.lblc_name.BackColor = System.Drawing.Color.Transparent
        Me.lblc_name.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblc_name.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblc_name.Location = New System.Drawing.Point(56, 6)
        Me.lblc_name.Name = "lblc_name"
        Me.lblc_name.Size = New System.Drawing.Size(53, 21)
        Me.lblc_name.TabIndex = 52
        Me.lblc_name.Text = "Name"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(6, 6)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 21)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "Name:"
        '
        'tmrDateTime
        '
        Me.tmrDateTime.Enabled = True
        Me.tmrDateTime.Interval = 1000
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(223, 77)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1220, 778)
        Me.Panel3.TabIndex = 54
        '
        'btnactlog
        '
        Me.btnactlog.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnactlog.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnactlog.FlatAppearance.BorderSize = 0
        Me.btnactlog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnactlog.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnactlog.ForeColor = System.Drawing.Color.White
        Me.btnactlog.Image = CType(resources.GetObject("btnactlog.Image"), System.Drawing.Image)
        Me.btnactlog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnactlog.Location = New System.Drawing.Point(0, 200)
        Me.btnactlog.Name = "btnactlog"
        Me.btnactlog.Size = New System.Drawing.Size(223, 50)
        Me.btnactlog.TabIndex = 54
        Me.btnactlog.Text = "     Activity Logs"
        Me.btnactlog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnactlog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnactlog.UseVisualStyleBackColor = False
        '
        'btnlogout
        '
        Me.btnlogout.BackColor = System.Drawing.Color.IndianRed
        Me.btnlogout.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnlogout.FlatAppearance.BorderSize = 0
        Me.btnlogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlogout.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlogout.ForeColor = System.Drawing.Color.White
        Me.btnlogout.Image = CType(resources.GetObject("btnlogout.Image"), System.Drawing.Image)
        Me.btnlogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlogout.Location = New System.Drawing.Point(0, 728)
        Me.btnlogout.Name = "btnlogout"
        Me.btnlogout.Size = New System.Drawing.Size(223, 50)
        Me.btnlogout.TabIndex = 53
        Me.btnlogout.Text = "     Logout"
        Me.btnlogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnlogout.UseVisualStyleBackColor = False
        '
        'btnbookman
        '
        Me.btnbookman.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnbookman.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnbookman.FlatAppearance.BorderSize = 0
        Me.btnbookman.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnbookman.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnbookman.ForeColor = System.Drawing.Color.White
        Me.btnbookman.Image = CType(resources.GetObject("btnbookman.Image"), System.Drawing.Image)
        Me.btnbookman.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnbookman.Location = New System.Drawing.Point(0, 150)
        Me.btnbookman.Name = "btnbookman"
        Me.btnbookman.Size = New System.Drawing.Size(223, 50)
        Me.btnbookman.TabIndex = 7
        Me.btnbookman.Text = "     Book Inventory"
        Me.btnbookman.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnbookman.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnbookman.UseVisualStyleBackColor = False
        '
        'btnborrowh
        '
        Me.btnborrowh.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnborrowh.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnborrowh.FlatAppearance.BorderSize = 0
        Me.btnborrowh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnborrowh.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnborrowh.ForeColor = System.Drawing.Color.White
        Me.btnborrowh.Image = CType(resources.GetObject("btnborrowh.Image"), System.Drawing.Image)
        Me.btnborrowh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnborrowh.Location = New System.Drawing.Point(0, 100)
        Me.btnborrowh.Name = "btnborrowh"
        Me.btnborrowh.Size = New System.Drawing.Size(223, 50)
        Me.btnborrowh.TabIndex = 1
        Me.btnborrowh.Text = "     Borrow History Records "
        Me.btnborrowh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnborrowh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnborrowh.UseVisualStyleBackColor = False
        '
        'btnaccman
        '
        Me.btnaccman.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnaccman.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnaccman.FlatAppearance.BorderSize = 0
        Me.btnaccman.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnaccman.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnaccman.ForeColor = System.Drawing.Color.White
        Me.btnaccman.Image = CType(resources.GetObject("btnaccman.Image"), System.Drawing.Image)
        Me.btnaccman.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnaccman.Location = New System.Drawing.Point(0, 50)
        Me.btnaccman.Name = "btnaccman"
        Me.btnaccman.Size = New System.Drawing.Size(223, 50)
        Me.btnaccman.TabIndex = 3
        Me.btnaccman.Text = "     Account Management "
        Me.btnaccman.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnaccman.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnaccman.UseVisualStyleBackColor = False
        '
        'btndash
        '
        Me.btndash.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btndash.Dock = System.Windows.Forms.DockStyle.Top
        Me.btndash.FlatAppearance.BorderSize = 0
        Me.btndash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndash.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndash.ForeColor = System.Drawing.Color.White
        Me.btndash.Image = CType(resources.GetObject("btndash.Image"), System.Drawing.Image)
        Me.btndash.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btndash.Location = New System.Drawing.Point(0, 0)
        Me.btndash.Name = "btndash"
        Me.btndash.Size = New System.Drawing.Size(223, 50)
        Me.btndash.TabIndex = 2
        Me.btndash.Text = "     Dashboard"
        Me.btndash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btndash.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btndash.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        PictureBox2.Image = Global.LibrarySystem.My.Resources.Resources.BOOK_LOGO_
        PictureBox2.Location = New System.Drawing.Point(13, 14)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New System.Drawing.Size(50, 50)
        PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 37
        PictureBox2.TabStop = False
        '
        'frmAdminMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1443, 855)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmAdminMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAdmin"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        CType(PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnaccman As Button
    Friend WithEvents btndash As Button
    Friend WithEvents btnborrowh As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents btnbookman As Button
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents lblc_name As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lbldatetime As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents tmrDateTime As Timer
    Friend WithEvents lblt_datetime As Label
    Friend WithEvents lbl_dT As Label
    Friend WithEvents btnlogout As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnactlog As Button
    Friend WithEvents Label1 As Label
End Class
