<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLibrarianMainMenu
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
        Dim PictureBox2 As System.Windows.Forms.PictureBox
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnlogout = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_dT = New System.Windows.Forms.Label()
        Me.lblt_datetime = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.frmPenaltyman = New System.Windows.Forms.Button()
        Me.btnBookMan = New System.Windows.Forms.Button()
        Me.btnRecords = New System.Windows.Forms.Button()
        PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(223, 77)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1245, 778)
        Me.Panel3.TabIndex = 60
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.Panel2.Controls.Add(Me.frmPenaltyman)
        Me.Panel2.Controls.Add(Me.btnBookMan)
        Me.Panel2.Controls.Add(Me.btnRecords)
        Me.Panel2.Controls.Add(Me.btnlogout)
        Me.Panel2.Controls.Add(Me.Panel8)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 77)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(223, 778)
        Me.Panel2.TabIndex = 59
        '
        'btnlogout
        '
        Me.btnlogout.BackColor = System.Drawing.Color.IndianRed
        Me.btnlogout.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnlogout.FlatAppearance.BorderSize = 0
        Me.btnlogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlogout.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlogout.ForeColor = System.Drawing.Color.White
        Me.btnlogout.Location = New System.Drawing.Point(0, 728)
        Me.btnlogout.Name = "btnlogout"
        Me.btnlogout.Size = New System.Drawing.Size(223, 50)
        Me.btnlogout.TabIndex = 59
        Me.btnlogout.Text = "Logout"
        Me.btnlogout.UseVisualStyleBackColor = False
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
        Me.Panel1.Controls.Add(Me.lbl_dT)
        Me.Panel1.Controls.Add(Me.lblt_datetime)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(PictureBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1468, 77)
        Me.Panel1.TabIndex = 58
        '
        'lbl_dT
        '
        Me.lbl_dT.AutoSize = True
        Me.lbl_dT.BackColor = System.Drawing.Color.Transparent
        Me.lbl_dT.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_dT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lbl_dT.Location = New System.Drawing.Point(1135, 35)
        Me.lbl_dT.Name = "lbl_dT"
        Me.lbl_dT.Size = New System.Drawing.Size(0, 21)
        Me.lbl_dT.TabIndex = 58
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
        'frmPenaltyman
        '
        Me.frmPenaltyman.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.frmPenaltyman.Dock = System.Windows.Forms.DockStyle.Top
        Me.frmPenaltyman.FlatAppearance.BorderSize = 0
        Me.frmPenaltyman.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.frmPenaltyman.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmPenaltyman.ForeColor = System.Drawing.Color.White
        Me.frmPenaltyman.Location = New System.Drawing.Point(0, 100)
        Me.frmPenaltyman.Name = "frmPenaltyman"
        Me.frmPenaltyman.Size = New System.Drawing.Size(223, 50)
        Me.frmPenaltyman.TabIndex = 63
        Me.frmPenaltyman.Text = "Penalty Management"
        Me.frmPenaltyman.UseVisualStyleBackColor = False
        '
        'btnBookMan
        '
        Me.btnBookMan.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnBookMan.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnBookMan.FlatAppearance.BorderSize = 0
        Me.btnBookMan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBookMan.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBookMan.ForeColor = System.Drawing.Color.White
        Me.btnBookMan.Location = New System.Drawing.Point(0, 50)
        Me.btnBookMan.Name = "btnBookMan"
        Me.btnBookMan.Size = New System.Drawing.Size(223, 50)
        Me.btnBookMan.TabIndex = 60
        Me.btnBookMan.Text = "Book Management"
        Me.btnBookMan.UseVisualStyleBackColor = False
        '
        'btnRecords
        '
        Me.btnRecords.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnRecords.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnRecords.FlatAppearance.BorderSize = 0
        Me.btnRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRecords.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecords.ForeColor = System.Drawing.Color.White
        Me.btnRecords.Location = New System.Drawing.Point(0, 0)
        Me.btnRecords.Name = "btnRecords"
        Me.btnRecords.Size = New System.Drawing.Size(223, 50)
        Me.btnRecords.TabIndex = 61
        Me.btnRecords.Text = "Borrow Records Management"
        Me.btnRecords.UseVisualStyleBackColor = False
        '
        'frmLibrarianMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1468, 855)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmLibrarianMainMenu"
        Me.Text = "frmLibrarianMainMenu"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnlogout As Button
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbl_dT As Label
    Friend WithEvents lblt_datetime As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents frmPenaltyman As Button
    Friend WithEvents btnBookMan As Button
    Friend WithEvents btnRecords As Button
End Class
