<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLibrarianDashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLibrarianDashboard))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.lblb_issued = New System.Windows.Forms.Panel()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.dgvpenalty = New System.Windows.Forms.DataGridView()
        Me.User = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BookTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Reason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BookCondition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lblissuedtoday = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.lblPendingReceipts = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.lbloverduebooks = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblreturnedtoday = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblname = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lblposition = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BorrowDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DueDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.chartb_overview = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblb_issued.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        CType(Me.dgvpenalty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel13.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel11.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartb_overview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblb_issued
        '
        Me.lblb_issued.BackColor = System.Drawing.Color.White
        Me.lblb_issued.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblb_issued.Controls.Add(Me.PictureBox7)
        Me.lblb_issued.Controls.Add(Me.Chart1)
        Me.lblb_issued.Controls.Add(Me.Label2)
        Me.lblb_issued.Location = New System.Drawing.Point(851, 212)
        Me.lblb_issued.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lblb_issued.Name = "lblb_issued"
        Me.lblb_issued.Size = New System.Drawing.Size(755, 331)
        Me.lblb_issued.TabIndex = 82
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(19, 17)
        Me.PictureBox7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(33, 31)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox7.TabIndex = 56
        Me.PictureBox7.TabStop = False
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(19, 55)
        Me.Chart1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(715, 256)
        Me.Chart1.TabIndex = 76
        Me.Chart1.Text = "Chart1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(57, 20)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(218, 28)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Unpaid vs Paid Penalty"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.dgvpenalty)
        Me.Panel7.Controls.Add(Me.PictureBox6)
        Me.Panel7.Controls.Add(Me.Label5)
        Me.Panel7.Location = New System.Drawing.Point(45, 212)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(761, 332)
        Me.Panel7.TabIndex = 83
        '
        'dgvpenalty
        '
        Me.dgvpenalty.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvpenalty.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvpenalty.BackgroundColor = System.Drawing.Color.White
        Me.dgvpenalty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvpenalty.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.User, Me.BookTitle, Me.Reason, Me.BookCondition, Me.Status})
        Me.dgvpenalty.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvpenalty.Location = New System.Drawing.Point(0, 56)
        Me.dgvpenalty.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvpenalty.Name = "dgvpenalty"
        Me.dgvpenalty.RowHeadersVisible = False
        Me.dgvpenalty.RowHeadersWidth = 51
        Me.dgvpenalty.Size = New System.Drawing.Size(759, 274)
        Me.dgvpenalty.TabIndex = 159
        '
        'User
        '
        Me.User.HeaderText = "User"
        Me.User.MinimumWidth = 6
        Me.User.Name = "User"
        '
        'BookTitle
        '
        Me.BookTitle.HeaderText = "Book Title"
        Me.BookTitle.MinimumWidth = 6
        Me.BookTitle.Name = "BookTitle"
        '
        'Reason
        '
        Me.Reason.HeaderText = "Reason"
        Me.Reason.MinimumWidth = 6
        Me.Reason.Name = "Reason"
        '
        'BookCondition
        '
        Me.BookCondition.HeaderText = "Book Condition"
        Me.BookCondition.MinimumWidth = 6
        Me.BookCondition.Name = "BookCondition"
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.MinimumWidth = 6
        Me.Status.Name = "Status"
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(16, 16)
        Me.PictureBox6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(33, 31)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 56
        Me.PictureBox6.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(55, 18)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(145, 28)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Recent Penalty"
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.White
        Me.Panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.Label8)
        Me.Panel10.Controls.Add(Me.PictureBox3)
        Me.Panel10.Controls.Add(Me.lblissuedtoday)
        Me.Panel10.Location = New System.Drawing.Point(45, 32)
        Me.Panel10.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(359, 151)
        Me.Panel10.TabIndex = 84
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(57, 108)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(221, 28)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "Books Borrowed Today"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(55, 43)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(40, 37)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 51
        Me.PictureBox3.TabStop = False
        '
        'lblissuedtoday
        '
        Me.lblissuedtoday.AutoSize = True
        Me.lblissuedtoday.Font = New System.Drawing.Font("Segoe UI", 25.0!, System.Drawing.FontStyle.Bold)
        Me.lblissuedtoday.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblissuedtoday.Location = New System.Drawing.Point(103, 32)
        Me.lblissuedtoday.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblissuedtoday.Name = "lblissuedtoday"
        Me.lblissuedtoday.Size = New System.Drawing.Size(49, 57)
        Me.lblissuedtoday.TabIndex = 42
        Me.lblissuedtoday.Text = "0"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.PictureBox4)
        Me.Panel5.Controls.Add(Me.lblPendingReceipts)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel5.Location = New System.Drawing.Point(851, 32)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(359, 151)
        Me.Panel5.TabIndex = 78
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.InitialImage = Global.LibrarySystem.My.Resources.Resources.tbook
        Me.PictureBox4.Location = New System.Drawing.Point(55, 43)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(40, 37)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 48
        Me.PictureBox4.TabStop = False
        '
        'lblPendingReceipts
        '
        Me.lblPendingReceipts.AutoSize = True
        Me.lblPendingReceipts.BackColor = System.Drawing.Color.Transparent
        Me.lblPendingReceipts.Font = New System.Drawing.Font("Segoe UI", 25.0!, System.Drawing.FontStyle.Bold)
        Me.lblPendingReceipts.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblPendingReceipts.Location = New System.Drawing.Point(103, 32)
        Me.lblPendingReceipts.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPendingReceipts.Name = "lblPendingReceipts"
        Me.lblPendingReceipts.Size = New System.Drawing.Size(49, 57)
        Me.lblPendingReceipts.TabIndex = 19
        Me.lblPendingReceipts.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(91, 108)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(169, 28)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Books For Return"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.PictureBox5)
        Me.Panel6.Controls.Add(Me.lbloverduebooks)
        Me.Panel6.Controls.Add(Me.Label10)
        Me.Panel6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel6.Location = New System.Drawing.Point(1247, 32)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(359, 151)
        Me.Panel6.TabIndex = 80
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(53, 43)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(40, 37)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 49
        Me.PictureBox5.TabStop = False
        '
        'lbloverduebooks
        '
        Me.lbloverduebooks.AutoSize = True
        Me.lbloverduebooks.BackColor = System.Drawing.Color.Transparent
        Me.lbloverduebooks.Font = New System.Drawing.Font("Segoe UI", 25.0!, System.Drawing.FontStyle.Bold)
        Me.lbloverduebooks.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lbloverduebooks.Location = New System.Drawing.Point(101, 32)
        Me.lbloverduebooks.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbloverduebooks.Name = "lbloverduebooks"
        Me.lbloverduebooks.Size = New System.Drawing.Size(49, 57)
        Me.lbloverduebooks.TabIndex = 45
        Me.lbloverduebooks.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(105, 108)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(152, 28)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Overdue Books"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Controls.Add(Me.lblreturnedtoday)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel3.Location = New System.Drawing.Point(447, 32)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(359, 151)
        Me.Panel3.TabIndex = 79
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(41, 43)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 49
        Me.PictureBox1.TabStop = False
        '
        'lblreturnedtoday
        '
        Me.lblreturnedtoday.AutoSize = True
        Me.lblreturnedtoday.BackColor = System.Drawing.Color.Transparent
        Me.lblreturnedtoday.Font = New System.Drawing.Font("Segoe UI", 25.0!, System.Drawing.FontStyle.Bold)
        Me.lblreturnedtoday.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblreturnedtoday.Location = New System.Drawing.Point(89, 32)
        Me.lblreturnedtoday.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblreturnedtoday.Name = "lblreturnedtoday"
        Me.lblreturnedtoday.Size = New System.Drawing.Size(49, 57)
        Me.lblreturnedtoday.TabIndex = 45
        Me.lblreturnedtoday.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(63, 108)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 28)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Books Returned Today"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lblname)
        Me.Panel1.Controls.Add(Me.Label29)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.lblposition)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 947)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1643, 33)
        Me.Panel1.TabIndex = 158
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
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 925)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1643, 22)
        Me.Panel2.TabIndex = 159
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.White
        Me.Panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel13.Controls.Add(Me.DataGridView1)
        Me.Panel13.Controls.Add(Me.PictureBox10)
        Me.Panel13.Controls.Add(Me.Label22)
        Me.Panel13.Location = New System.Drawing.Point(45, 580)
        Me.Panel13.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(761, 345)
        Me.Panel13.TabIndex = 160
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.BorrowDate, Me.DueDate, Me.DataGridViewTextBoxColumn3})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DataGridView1.Location = New System.Drawing.Point(0, 50)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(759, 293)
        Me.DataGridView1.TabIndex = 158
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "User"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Book Title"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'BorrowDate
        '
        Me.BorrowDate.HeaderText = "Book Date"
        Me.BorrowDate.MinimumWidth = 6
        Me.BorrowDate.Name = "BorrowDate"
        '
        'DueDate
        '
        Me.DueDate.HeaderText = "Due Date"
        Me.DueDate.MinimumWidth = 6
        Me.DueDate.Name = "DueDate"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Status"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'PictureBox10
        '
        Me.PictureBox10.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(16, 12)
        Me.PictureBox10.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(33, 31)
        Me.PictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox10.TabIndex = 56
        Me.PictureBox10.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(55, 15)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(213, 28)
        Me.Label22.TabIndex = 53
        Me.Label22.Text = "Recent Library Activity"
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.White
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.PictureBox8)
        Me.Panel11.Controls.Add(Me.chartb_overview)
        Me.Panel11.Controls.Add(Me.Label18)
        Me.Panel11.Location = New System.Drawing.Point(851, 580)
        Me.Panel11.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(755, 345)
        Me.Panel11.TabIndex = 161
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(15, 12)
        Me.PictureBox8.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(33, 31)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox8.TabIndex = 53
        Me.PictureBox8.TabStop = False
        '
        'chartb_overview
        '
        Me.chartb_overview.BackColor = System.Drawing.Color.Transparent
        Me.chartb_overview.BorderlineColor = System.Drawing.Color.Transparent
        ChartArea2.Name = "ChartArea1"
        Me.chartb_overview.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.chartb_overview.Legends.Add(Legend2)
        Me.chartb_overview.Location = New System.Drawing.Point(15, 50)
        Me.chartb_overview.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chartb_overview.Name = "chartb_overview"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.chartb_overview.Series.Add(Series2)
        Me.chartb_overview.Size = New System.Drawing.Size(719, 287)
        Me.chartb_overview.TabIndex = 52
        Me.chartb_overview.Text = "Chart1"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(52, 16)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(150, 28)
        Me.Label18.TabIndex = 51
        Me.Label18.Text = "Book Overview"
        '
        'frmLibrarianDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1664, 842)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.Panel13)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblb_issued)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmLibrarianDashboard"
        Me.Text = "frmLibraryDashboard"
        Me.lblb_issued.ResumeLayout(False)
        Me.lblb_issued.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.dgvpenalty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartb_overview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblb_issued As Panel
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents lblissuedtoday As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents lblPendingReceipts As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents lbloverduebooks As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblreturnedtoday As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblname As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents lblposition As Label
    Friend WithEvents dgvpenalty As DataGridView
    Friend WithEvents User As DataGridViewTextBoxColumn
    Friend WithEvents BookTitle As DataGridViewTextBoxColumn
    Friend WithEvents Reason As DataGridViewTextBoxColumn
    Friend WithEvents BookCondition As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents BorrowDate As DataGridViewTextBoxColumn
    Friend WithEvents DueDate As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents PictureBox10 As PictureBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents chartb_overview As DataVisualization.Charting.Chart
    Friend WithEvents Label18 As Label
End Class
