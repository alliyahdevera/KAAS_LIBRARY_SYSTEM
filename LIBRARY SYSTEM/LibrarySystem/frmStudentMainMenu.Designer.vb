<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStudentMainMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStudentMainMenu))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btndashb = New System.Windows.Forms.Button()
        Me.btnlogout = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.btnBorrow = New System.Windows.Forms.Button()
        Me.btnPenalty = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnViewHistory = New System.Windows.Forms.Button()
        Me.btnAvailBooks = New System.Windows.Forms.Button()
        Me.btnReturn = New System.Windows.Forms.Button()
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
        PictureBox2.Location = New System.Drawing.Point(13, 14)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New System.Drawing.Size(50, 50)
        PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 37
        PictureBox2.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(223, 77)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1245, 778)
        Me.Panel3.TabIndex = 57
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btndashb)
        Me.Panel2.Controls.Add(Me.btnlogout)
        Me.Panel2.Controls.Add(Me.Panel8)
        Me.Panel2.Controls.Add(Me.btnBorrow)
        Me.Panel2.Controls.Add(Me.btnPenalty)
        Me.Panel2.Controls.Add(Me.btnHelp)
        Me.Panel2.Controls.Add(Me.btnViewHistory)
        Me.Panel2.Controls.Add(Me.btnAvailBooks)
        Me.Panel2.Controls.Add(Me.btnReturn)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 77)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(223, 778)
        Me.Panel2.TabIndex = 56
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
        Me.btndashb.Location = New System.Drawing.Point(0, 330)
        Me.btndashb.Name = "btndashb"
        Me.btndashb.Size = New System.Drawing.Size(223, 55)
        Me.btndashb.TabIndex = 60
        Me.btndashb.Text = "     Need help?"
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
        Me.btnlogout.Location = New System.Drawing.Point(0, 721)
        Me.btnlogout.Name = "btnlogout"
        Me.btnlogout.Size = New System.Drawing.Size(223, 57)
        Me.btnlogout.TabIndex = 59
        Me.btnlogout.Text = "     Logout"
        Me.btnlogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
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
        'btnBorrow
        '
        Me.btnBorrow.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnBorrow.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnBorrow.FlatAppearance.BorderSize = 0
        Me.btnBorrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBorrow.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrow.ForeColor = System.Drawing.Color.White
        Me.btnBorrow.Image = CType(resources.GetObject("btnBorrow.Image"), System.Drawing.Image)
        Me.btnBorrow.Location = New System.Drawing.Point(0, 275)
        Me.btnBorrow.Name = "btnBorrow"
        Me.btnBorrow.Size = New System.Drawing.Size(223, 55)
        Me.btnBorrow.TabIndex = 54
        Me.btnBorrow.Text = "     My Penalties"
        Me.btnBorrow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBorrow.UseVisualStyleBackColor = False
        '
        'btnPenalty
        '
        Me.btnPenalty.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnPenalty.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnPenalty.FlatAppearance.BorderSize = 0
        Me.btnPenalty.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPenalty.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPenalty.ForeColor = System.Drawing.Color.White
        Me.btnPenalty.Image = CType(resources.GetObject("btnPenalty.Image"), System.Drawing.Image)
        Me.btnPenalty.Location = New System.Drawing.Point(0, 220)
        Me.btnPenalty.Name = "btnPenalty"
        Me.btnPenalty.Size = New System.Drawing.Size(223, 55)
        Me.btnPenalty.TabIndex = 58
        Me.btnPenalty.Text = "     Borrow History"
        Me.btnPenalty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPenalty.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPenalty.UseVisualStyleBackColor = False
        '
        'btnHelp
        '
        Me.btnHelp.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnHelp.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnHelp.FlatAppearance.BorderSize = 0
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelp.ForeColor = System.Drawing.Color.White
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.Location = New System.Drawing.Point(0, 165)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(223, 55)
        Me.btnHelp.TabIndex = 57
        Me.btnHelp.Text = "     Return Books"
        Me.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnHelp.UseVisualStyleBackColor = False
        '
        'btnViewHistory
        '
        Me.btnViewHistory.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnViewHistory.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnViewHistory.FlatAppearance.BorderSize = 0
        Me.btnViewHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewHistory.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewHistory.ForeColor = System.Drawing.Color.White
        Me.btnViewHistory.Image = CType(resources.GetObject("btnViewHistory.Image"), System.Drawing.Image)
        Me.btnViewHistory.Location = New System.Drawing.Point(0, 110)
        Me.btnViewHistory.Name = "btnViewHistory"
        Me.btnViewHistory.Size = New System.Drawing.Size(223, 55)
        Me.btnViewHistory.TabIndex = 56
        Me.btnViewHistory.Text = "     Borrow Books"
        Me.btnViewHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnViewHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnViewHistory.UseVisualStyleBackColor = False
        '
        'btnAvailBooks
        '
        Me.btnAvailBooks.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnAvailBooks.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnAvailBooks.FlatAppearance.BorderSize = 0
        Me.btnAvailBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAvailBooks.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAvailBooks.ForeColor = System.Drawing.Color.White
        Me.btnAvailBooks.Image = CType(resources.GetObject("btnAvailBooks.Image"), System.Drawing.Image)
        Me.btnAvailBooks.Location = New System.Drawing.Point(0, 55)
        Me.btnAvailBooks.Name = "btnAvailBooks"
        Me.btnAvailBooks.Size = New System.Drawing.Size(223, 55)
        Me.btnAvailBooks.TabIndex = 53
        Me.btnAvailBooks.Text = "     Available Books"
        Me.btnAvailBooks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAvailBooks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAvailBooks.UseVisualStyleBackColor = False
        '
        'btnReturn
        '
        Me.btnReturn.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnReturn.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnReturn.FlatAppearance.BorderSize = 0
        Me.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReturn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReturn.ForeColor = System.Drawing.Color.White
        Me.btnReturn.Image = CType(resources.GetObject("btnReturn.Image"), System.Drawing.Image)
        Me.btnReturn.Location = New System.Drawing.Point(0, 0)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(223, 55)
        Me.btnReturn.TabIndex = 55
        Me.btnReturn.Text = "     Dashboard"
        Me.btnReturn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReturn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnReturn.UseVisualStyleBackColor = False
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
        Me.Panel1.Size = New System.Drawing.Size(1468, 77)
        Me.Panel1.TabIndex = 55
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(-4, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1539, 20)
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
        'frmStudentMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1468, 855)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmStudentMainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmStudentMainMenu"
        CType(PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbl_dT As Label
    Friend WithEvents lblt_datetime As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents btnlogout As Button
    Friend WithEvents btnPenalty As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnViewHistory As Button
    Friend WithEvents btnAvailBooks As Button
    Friend WithEvents btnReturn As Button
    Friend WithEvents btnBorrow As Button
    Friend WithEvents btndashb As Button
    Friend WithEvents Label1 As Label
End Class
