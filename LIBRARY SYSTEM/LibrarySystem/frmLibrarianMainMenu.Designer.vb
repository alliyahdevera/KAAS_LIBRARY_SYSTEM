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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLibrarianMainMenu))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnpenaltyman = New System.Windows.Forms.Button()
        Me.btnbookman = New System.Windows.Forms.Button()
        Me.btnborrowman = New System.Windows.Forms.Button()
        Me.btndashb = New System.Windows.Forms.Button()
        Me.btnlogout = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_dT = New System.Windows.Forms.Label()
        Me.lblt_datetime = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox2
        '
        PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        PictureBox2.Image = Global.LibrarySystem.My.Resources.Resources.BOOK_LOGO_
        PictureBox2.Location = New System.Drawing.Point(17, 17)
        PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New System.Drawing.Size(67, 62)
        PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 37
        PictureBox2.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(297, 95)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1627, 957)
        Me.Panel3.TabIndex = 60
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnpenaltyman)
        Me.Panel2.Controls.Add(Me.btnbookman)
        Me.Panel2.Controls.Add(Me.btnborrowman)
        Me.Panel2.Controls.Add(Me.btndashb)
        Me.Panel2.Controls.Add(Me.btnlogout)
        Me.Panel2.Controls.Add(Me.Panel8)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 95)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(297, 957)
        Me.Panel2.TabIndex = 59
        '
        'btnpenaltyman
        '
        Me.btnpenaltyman.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnpenaltyman.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnpenaltyman.FlatAppearance.BorderSize = 0
        Me.btnpenaltyman.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpenaltyman.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpenaltyman.ForeColor = System.Drawing.Color.White
        Me.btnpenaltyman.Image = CType(resources.GetObject("btnpenaltyman.Image"), System.Drawing.Image)
        Me.btnpenaltyman.Location = New System.Drawing.Point(0, 186)
        Me.btnpenaltyman.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnpenaltyman.Name = "btnpenaltyman"
        Me.btnpenaltyman.Size = New System.Drawing.Size(297, 62)
        Me.btnpenaltyman.TabIndex = 64
        Me.btnpenaltyman.Text = "     Penalty Management"
        Me.btnpenaltyman.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnpenaltyman.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnpenaltyman.UseVisualStyleBackColor = False
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
        Me.btnbookman.Location = New System.Drawing.Point(0, 124)
        Me.btnbookman.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnbookman.Name = "btnbookman"
        Me.btnbookman.Size = New System.Drawing.Size(297, 62)
        Me.btnbookman.TabIndex = 63
        Me.btnbookman.Text = "     Book Management "
        Me.btnbookman.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnbookman.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnbookman.UseVisualStyleBackColor = False
        '
        'btnborrowman
        '
        Me.btnborrowman.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnborrowman.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnborrowman.FlatAppearance.BorderSize = 0
        Me.btnborrowman.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnborrowman.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnborrowman.ForeColor = System.Drawing.Color.White
        Me.btnborrowman.Image = CType(resources.GetObject("btnborrowman.Image"), System.Drawing.Image)
        Me.btnborrowman.Location = New System.Drawing.Point(0, 62)
        Me.btnborrowman.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnborrowman.Name = "btnborrowman"
        Me.btnborrowman.Size = New System.Drawing.Size(297, 62)
        Me.btnborrowman.TabIndex = 60
        Me.btnborrowman.Text = "     Borrow Management "
        Me.btnborrowman.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnborrowman.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnborrowman.UseVisualStyleBackColor = False
        '
        'btndashb
        '
        Me.btndashb.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btndashb.Dock = System.Windows.Forms.DockStyle.Top
        Me.btndashb.FlatAppearance.BorderSize = 0
        Me.btndashb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndashb.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndashb.ForeColor = System.Drawing.Color.White
        Me.btndashb.Image = CType(resources.GetObject("btndashb.Image"), System.Drawing.Image)
        Me.btndashb.Location = New System.Drawing.Point(0, 0)
        Me.btndashb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btndashb.Name = "btndashb"
        Me.btndashb.Size = New System.Drawing.Size(297, 62)
        Me.btndashb.TabIndex = 61
        Me.btndashb.Text = "        Dashboard"
        Me.btndashb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btndashb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btndashb.UseVisualStyleBackColor = False
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
        Me.btnlogout.Location = New System.Drawing.Point(0, 895)
        Me.btnlogout.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnlogout.Name = "btnlogout"
        Me.btnlogout.Size = New System.Drawing.Size(297, 62)
        Me.btnlogout.TabIndex = 59
        Me.btnlogout.Text = "     Logout"
        Me.btnlogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnlogout.UseVisualStyleBackColor = False
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.White
        Me.Panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel8.Location = New System.Drawing.Point(359, 1127)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(373, 42)
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
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1924, 95)
        Me.Panel1.TabIndex = 58
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(-5, 79)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1950, 25)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "—————————————————————————————————————————————————————————————————————————————————" &
    "—————————————————————"
        '
        'lbl_dT
        '
        Me.lbl_dT.AutoSize = True
        Me.lbl_dT.BackColor = System.Drawing.Color.Transparent
        Me.lbl_dT.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_dT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lbl_dT.Location = New System.Drawing.Point(1513, 43)
        Me.lbl_dT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_dT.Name = "lbl_dT"
        Me.lbl_dT.Size = New System.Drawing.Size(0, 28)
        Me.lbl_dT.TabIndex = 58
        '
        'lblt_datetime
        '
        Me.lblt_datetime.AutoSize = True
        Me.lblt_datetime.BackColor = System.Drawing.Color.Transparent
        Me.lblt_datetime.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblt_datetime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblt_datetime.Location = New System.Drawing.Point(2141, 43)
        Me.lblt_datetime.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblt_datetime.Name = "lblt_datetime"
        Me.lblt_datetime.Size = New System.Drawing.Size(0, 28)
        Me.lblt_datetime.TabIndex = 57
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(89, 57)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(168, 20)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "MANAGEMENT SYSTEM"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(85, 15)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(188, 42)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "LIBRARY"
        '
        'frmLibrarianMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1052)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmLibrarianMainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmLibrarianMainMenu"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
    Friend WithEvents btnbookman As Button
    Friend WithEvents btnborrowman As Button
    Friend WithEvents btndashb As Button
    Friend WithEvents btnpenaltyman As Button
    Friend WithEvents Label1 As Label
End Class
