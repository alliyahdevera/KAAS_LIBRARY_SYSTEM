<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStudentDashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStudentDashboard))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.chartb_mborrowed = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.lblPenalty = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.lblb_Borrowed = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.lblb_return = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblBooksDue = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartb_mborrowed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel4.Location = New System.Drawing.Point(31, 316)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(501, 408)
        Me.Panel4.TabIndex = 72
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(27, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(427, 280)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = resources.GetString("Label7.Text")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(26, 32)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(236, 25)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "📢 Library Announcement"
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.PictureBox7)
        Me.Panel10.Controls.Add(Me.chartb_mborrowed)
        Me.Panel10.Controls.Add(Me.Label20)
        Me.Panel10.Location = New System.Drawing.Point(565, 316)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(651, 408)
        Me.Panel10.TabIndex = 73
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox7.Image = Global.LibrarySystem.My.Resources.Resources.tbook1
        Me.PictureBox7.Location = New System.Drawing.Point(31, 26)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox7.TabIndex = 55
        Me.PictureBox7.TabStop = False
        '
        'chartb_mborrowed
        '
        Me.chartb_mborrowed.BackColor = System.Drawing.Color.Transparent
        ChartArea1.Name = "ChartArea1"
        Me.chartb_mborrowed.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.chartb_mborrowed.Legends.Add(Legend1)
        Me.chartb_mborrowed.Location = New System.Drawing.Point(31, 89)
        Me.chartb_mborrowed.Name = "chartb_mborrowed"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.chartb_mborrowed.Series.Add(Series1)
        Me.chartb_mborrowed.Size = New System.Drawing.Size(592, 286)
        Me.chartb_mborrowed.TabIndex = 54
        Me.chartb_mborrowed.Text = "Chart2"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(77, 32)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(142, 25)
        Me.Label20.TabIndex = 53
        Me.Label20.Text = "Trending Books"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.PictureBox4)
        Me.Panel5.Controls.Add(Me.lblPenalty)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel5.Location = New System.Drawing.Point(641, 166)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(270, 130)
        Me.Panel5.TabIndex = 68
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 25.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(18, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 46)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "₱"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.LibrarySystem.My.Resources.Resources.icons__9_
        Me.PictureBox4.InitialImage = Global.LibrarySystem.My.Resources.Resources.tbook
        Me.PictureBox4.Location = New System.Drawing.Point(26, 18)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 48
        Me.PictureBox4.TabStop = False
        '
        'lblPenalty
        '
        Me.lblPenalty.AutoSize = True
        Me.lblPenalty.BackColor = System.Drawing.Color.Transparent
        Me.lblPenalty.Font = New System.Drawing.Font("Segoe UI", 25.0!, System.Drawing.FontStyle.Bold)
        Me.lblPenalty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblPenalty.Location = New System.Drawing.Point(52, 66)
        Me.lblPenalty.Name = "lblPenalty"
        Me.lblPenalty.Size = New System.Drawing.Size(40, 46)
        Me.lblPenalty.TabIndex = 19
        Me.lblPenalty.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(72, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(145, 25)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Current Penalty"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.Panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.PictureBox6)
        Me.Panel7.Controls.Add(Me.lblb_Borrowed)
        Me.Panel7.Controls.Add(Me.Label14)
        Me.Panel7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel7.Location = New System.Drawing.Point(31, 166)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(270, 130)
        Me.Panel7.TabIndex = 71
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.Image = Global.LibrarySystem.My.Resources.Resources.icons__16_2
        Me.PictureBox6.Location = New System.Drawing.Point(24, 18)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 49
        Me.PictureBox6.TabStop = False
        '
        'lblb_Borrowed
        '
        Me.lblb_Borrowed.AutoSize = True
        Me.lblb_Borrowed.BackColor = System.Drawing.Color.Transparent
        Me.lblb_Borrowed.Font = New System.Drawing.Font("Segoe UI", 25.0!, System.Drawing.FontStyle.Bold)
        Me.lblb_Borrowed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblb_Borrowed.Location = New System.Drawing.Point(24, 69)
        Me.lblb_Borrowed.Name = "lblb_Borrowed"
        Me.lblb_Borrowed.Size = New System.Drawing.Size(40, 46)
        Me.lblb_Borrowed.TabIndex = 45
        Me.lblb_Borrowed.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(65, 28)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(150, 25)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Books Borrowed"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.Panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.PictureBox5)
        Me.Panel6.Controls.Add(Me.lblb_return)
        Me.Panel6.Controls.Add(Me.Label10)
        Me.Panel6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel6.Location = New System.Drawing.Point(946, 166)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(270, 130)
        Me.Panel6.TabIndex = 70
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = Global.LibrarySystem.My.Resources.Resources.icons__1_1
        Me.PictureBox5.Location = New System.Drawing.Point(26, 18)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 49
        Me.PictureBox5.TabStop = False
        '
        'lblb_return
        '
        Me.lblb_return.AutoSize = True
        Me.lblb_return.BackColor = System.Drawing.Color.Transparent
        Me.lblb_return.Font = New System.Drawing.Font("Segoe UI", 25.0!, System.Drawing.FontStyle.Bold)
        Me.lblb_return.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblb_return.Location = New System.Drawing.Point(26, 66)
        Me.lblb_return.Name = "lblb_return"
        Me.lblb_return.Size = New System.Drawing.Size(40, 46)
        Me.lblb_return.TabIndex = 45
        Me.lblb_return.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(70, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(146, 25)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Books Returned"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Controls.Add(Me.lblBooksDue)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel3.Location = New System.Drawing.Point(336, 166)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(270, 130)
        Me.Panel3.TabIndex = 69
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.LibrarySystem.My.Resources.Resources.icons__15_2
        Me.PictureBox1.Location = New System.Drawing.Point(32, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 49
        Me.PictureBox1.TabStop = False
        '
        'lblBooksDue
        '
        Me.lblBooksDue.AutoSize = True
        Me.lblBooksDue.BackColor = System.Drawing.Color.Transparent
        Me.lblBooksDue.Font = New System.Drawing.Font("Segoe UI", 25.0!, System.Drawing.FontStyle.Bold)
        Me.lblBooksDue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblBooksDue.Location = New System.Drawing.Point(32, 61)
        Me.lblBooksDue.Name = "lblBooksDue"
        Me.lblBooksDue.Size = New System.Drawing.Size(40, 46)
        Me.lblBooksDue.TabIndex = 45
        Me.lblBooksDue.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(75, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 25)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Books Due Soon"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 24.0!)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(26, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(460, 45)
        Me.Label5.TabIndex = 65
        Me.Label5.Text = "WELCOME TO DASHBOARD OF"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(25, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(280, 50)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "KAAS LIBRARY"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(29, 100)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(111, 25)
        Me.Label13.TabIndex = 66
        Me.Label13.Text = "─────────"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semilight", 11.0!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(28, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(309, 20)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "The world's knowledge, just a single click away."
        '
        'frmStudentDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1245, 778)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmStudentDashboard"
        Me.Text = "frmStudentDashboard"
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartb_mborrowed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents chartb_mborrowed As DataVisualization.Charting.Chart
    Friend WithEvents Label20 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents lblPenalty As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents lblb_Borrowed As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents lblb_return As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblBooksDue As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label1 As Label
End Class
