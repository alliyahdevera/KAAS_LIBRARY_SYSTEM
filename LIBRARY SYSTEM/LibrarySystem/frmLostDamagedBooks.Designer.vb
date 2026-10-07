<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLostDamagedBooks
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvIncidents = New System.Windows.Forms.DataGridView()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.pnlFilter = New System.Windows.Forms.Panel()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblType = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.lblDateFrom = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblDateTo = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.chkRecovered = New System.Windows.Forms.CheckBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnRecover = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.colReportNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBookNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccession = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIsbn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBookTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBookAuthor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIncidentType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDateReported = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBorrower = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPenalty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCopyStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecovered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvIncidents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButtons.SuspendLayout()
        Me.pnlFilter.SuspendLayout()
        Me.pnlTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvIncidents
        '
        Me.dgvIncidents.AllowUserToAddRows = False
        Me.dgvIncidents.AllowUserToDeleteRows = False
        Me.dgvIncidents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvIncidents.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIncidents.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvIncidents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIncidents.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colReportNo, Me.colBookNo, Me.colAccession, Me.colIsbn, Me.colBookTitle, Me.colBookAuthor, Me.colIncidentType, Me.colDateReported, Me.colBorrower, Me.colPenalty, Me.colCopyStatus, Me.colRecovered, Me.colRemarks})
        Me.dgvIncidents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIncidents.EnableHeadersVisualStyles = False
        Me.dgvIncidents.Location = New System.Drawing.Point(0, 182)
        Me.dgvIncidents.MultiSelect = False
        Me.dgvIncidents.Name = "dgvIncidents"
        Me.dgvIncidents.ReadOnly = True
        Me.dgvIncidents.RowHeadersVisible = False
        Me.dgvIncidents.RowHeadersWidth = 51
        Me.dgvIncidents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIncidents.Size = New System.Drawing.Size(1700, 718)
        Me.dgvIncidents.TabIndex = 3
        '
        'pnlButtons
        '
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButtons.Location = New System.Drawing.Point(0, 128)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(1700, 54)
        Me.pnlButtons.TabIndex = 2
        Me.pnlButtons.Controls.Add(Me.btnFilter)
        Me.pnlButtons.Controls.Add(Me.btnReset)
        Me.pnlButtons.Controls.Add(Me.btnRecover)
        Me.pnlButtons.Controls.Add(Me.btnExport)
        '
        'pnlFilter
        '
        Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilter.Location = New System.Drawing.Point(0, 64)
        Me.pnlFilter.Name = "pnlFilter"
        Me.pnlFilter.Size = New System.Drawing.Size(1700, 64)
        Me.pnlFilter.TabIndex = 1
        Me.pnlFilter.Controls.Add(Me.lblSearch)
        Me.pnlFilter.Controls.Add(Me.txtSearch)
        Me.pnlFilter.Controls.Add(Me.lblType)
        Me.pnlFilter.Controls.Add(Me.cboType)
        Me.pnlFilter.Controls.Add(Me.lblDateFrom)
        Me.pnlFilter.Controls.Add(Me.dtpFrom)
        Me.pnlFilter.Controls.Add(Me.lblDateTo)
        Me.pnlFilter.Controls.Add(Me.dtpTo)
        Me.pnlFilter.Controls.Add(Me.chkRecovered)
        '
        'pnlTop
        '
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(1700, 64)
        Me.pnlTop.TabIndex = 0
        Me.pnlTop.Controls.Add(Me.lblTitle)
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(16, 14)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(299, 32)
        Me.lblTitle.Text = "Lost and Damaged Books"
        Me.lblTitle.TabIndex = 0
        '
        'lblSearch
        '
        Me.lblSearch.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(16, 4)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(253, 17)
        Me.lblSearch.Text = "Search (ISBN, title, book no., student)"
        Me.lblSearch.TabIndex = 0
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(16, 26)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(330, 27)
        Me.txtSearch.TabIndex = 1
        '
        'lblType
        '
        Me.lblType.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(358, 4)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(34, 17)
        Me.lblType.Text = "Type"
        Me.lblType.TabIndex = 2
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"All", "Lost", "Damaged"})
        Me.cboType.Location = New System.Drawing.Point(358, 26)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(140, 28)
        Me.cboType.TabIndex = 3
        '
        'lblDateFrom
        '
        Me.lblDateFrom.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateFrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblDateFrom.AutoSize = True
        Me.lblDateFrom.Location = New System.Drawing.Point(510, 4)
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(63, 17)
        Me.lblDateFrom.Text = "Date From"
        Me.lblDateFrom.TabIndex = 4
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFrom.Location = New System.Drawing.Point(510, 26)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(140, 27)
        Me.dtpFrom.TabIndex = 5
        '
        'lblDateTo
        '
        Me.lblDateTo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblDateTo.AutoSize = True
        Me.lblDateTo.Location = New System.Drawing.Point(662, 4)
        Me.lblDateTo.Name = "lblDateTo"
        Me.lblDateTo.Size = New System.Drawing.Size(50, 17)
        Me.lblDateTo.Text = "Date To"
        Me.lblDateTo.TabIndex = 6
        '
        'dtpTo
        '
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpTo.Location = New System.Drawing.Point(662, 26)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(140, 27)
        Me.dtpTo.TabIndex = 7
        '
        'chkRecovered
        '
        Me.chkRecovered.AutoSize = True
        Me.chkRecovered.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.chkRecovered.Location = New System.Drawing.Point(814, 30)
        Me.chkRecovered.Name = "chkRecovered"
        Me.chkRecovered.Size = New System.Drawing.Size(215, 23)
        Me.chkRecovered.Text = "Include recovered / repaired"
        Me.chkRecovered.UseVisualStyleBackColor = True
        Me.chkRecovered.TabIndex = 8
        '
        'btnFilter
        '
        Me.btnFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFilter.FlatAppearance.BorderSize = 0
        Me.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFilter.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.ForeColor = System.Drawing.Color.White
        Me.btnFilter.Location = New System.Drawing.Point(16, 6)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(160, 38)
        Me.btnFilter.Text = "Filter by Date"
        Me.btnFilter.UseVisualStyleBackColor = False
        Me.btnFilter.TabIndex = 0
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnReset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReset.FlatAppearance.BorderSize = 0
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReset.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.ForeColor = System.Drawing.Color.White
        Me.btnReset.Location = New System.Drawing.Point(186, 6)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(160, 38)
        Me.btnReset.Text = "Show All Dates"
        Me.btnReset.UseVisualStyleBackColor = False
        Me.btnReset.TabIndex = 1
        '
        'btnRecover
        '
        Me.btnRecover.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnRecover.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRecover.FlatAppearance.BorderSize = 0
        Me.btnRecover.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRecover.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecover.ForeColor = System.Drawing.Color.White
        Me.btnRecover.Location = New System.Drawing.Point(356, 6)
        Me.btnRecover.Name = "btnRecover"
        Me.btnRecover.Size = New System.Drawing.Size(160, 38)
        Me.btnRecover.Text = "Mark Recovered"
        Me.btnRecover.UseVisualStyleBackColor = False
        Me.btnRecover.TabIndex = 2
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExport.FlatAppearance.BorderSize = 0
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.ForeColor = System.Drawing.Color.White
        Me.btnExport.Location = New System.Drawing.Point(526, 6)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(160, 38)
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = False
        Me.btnExport.TabIndex = 3
        '
        'colReportNo
        '
        Me.colReportNo.FillWeight = 60.0!
        Me.colReportNo.HeaderText = "Report No."
        Me.colReportNo.MinimumWidth = 6
        Me.colReportNo.Name = "ReportNo"
        Me.colReportNo.ReadOnly = True
        '
        'colBookNo
        '
        Me.colBookNo.FillWeight = 60.0!
        Me.colBookNo.HeaderText = "Book No."
        Me.colBookNo.MinimumWidth = 6
        Me.colBookNo.Name = "BookNo"
        Me.colBookNo.ReadOnly = True
        '
        'colAccession
        '
        Me.colAccession.HeaderText = "Accession No."
        Me.colAccession.MinimumWidth = 6
        Me.colAccession.Name = "Accession"
        Me.colAccession.ReadOnly = True
        '
        'colIsbn
        '
        Me.colIsbn.HeaderText = "ISBN"
        Me.colIsbn.MinimumWidth = 6
        Me.colIsbn.Name = "ISBN"
        Me.colIsbn.ReadOnly = True
        '
        'colBookTitle
        '
        Me.colBookTitle.FillWeight = 200.0!
        Me.colBookTitle.HeaderText = "Book Title"
        Me.colBookTitle.MinimumWidth = 6
        Me.colBookTitle.Name = "BookTitle"
        Me.colBookTitle.ReadOnly = True
        '
        'colBookAuthor
        '
        Me.colBookAuthor.HeaderText = "Author"
        Me.colBookAuthor.MinimumWidth = 6
        Me.colBookAuthor.Name = "BookAuthor"
        Me.colBookAuthor.ReadOnly = True
        '
        'colIncidentType
        '
        Me.colIncidentType.HeaderText = "Type"
        Me.colIncidentType.MinimumWidth = 6
        Me.colIncidentType.Name = "IncidentType"
        Me.colIncidentType.ReadOnly = True
        '
        'colDateReported
        '
        Me.colDateReported.HeaderText = "Date Reported"
        Me.colDateReported.MinimumWidth = 6
        Me.colDateReported.Name = "DateReported"
        Me.colDateReported.ReadOnly = True
        '
        'colBorrower
        '
        Me.colBorrower.HeaderText = "Reported By (Student)"
        Me.colBorrower.MinimumWidth = 6
        Me.colBorrower.Name = "Borrower"
        Me.colBorrower.ReadOnly = True
        '
        'colPenalty
        '
        Me.colPenalty.HeaderText = "Penalty"
        Me.colPenalty.MinimumWidth = 6
        Me.colPenalty.Name = "Penalty"
        Me.colPenalty.ReadOnly = True
        '
        'colCopyStatus
        '
        Me.colCopyStatus.HeaderText = "Copy Status"
        Me.colCopyStatus.MinimumWidth = 6
        Me.colCopyStatus.Name = "CopyStatus"
        Me.colCopyStatus.ReadOnly = True
        '
        'colRecovered
        '
        Me.colRecovered.HeaderText = "Recovered / Repaired"
        Me.colRecovered.MinimumWidth = 6
        Me.colRecovered.Name = "Recovered"
        Me.colRecovered.ReadOnly = True
        '
        'colRemarks
        '
        Me.colRemarks.FillWeight = 160.0!
        Me.colRemarks.HeaderText = "Remarks"
        Me.colRemarks.MinimumWidth = 6
        Me.colRemarks.Name = "Remarks"
        Me.colRemarks.ReadOnly = True
        '
        'frmLostDamagedBooks
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1700, 900)
        Me.Controls.Add(Me.dgvIncidents)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.pnlFilter)
        Me.Controls.Add(Me.pnlTop)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmLostDamagedBooks"
        Me.Text = "frmLostDamagedBooks"
        CType(Me.dgvIncidents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlFilter.ResumeLayout(False)
        Me.pnlFilter.PerformLayout()
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlButtons.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvIncidents As System.Windows.Forms.DataGridView
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents lblDateFrom As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDateTo As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkRecovered As System.Windows.Forms.CheckBox
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnRecover As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents colReportNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBookNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAccession As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIsbn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBookTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBookAuthor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIncidentType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDateReported As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBorrower As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPenalty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCopyStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecovered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
