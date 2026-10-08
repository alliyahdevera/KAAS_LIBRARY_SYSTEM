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
        Me.ReportNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BookNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Accession = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ISBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BookTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BookAuthor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IncidentType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateReported = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Borrower = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Penalty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CopyStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Recovered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnRecover = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.pnlFilter = New System.Windows.Forms.Panel()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblType = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.lblDateFrom = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblDateTo = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.chkRecovered = New System.Windows.Forms.CheckBox()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        CType(Me.dgvIncidents, System.ComponentModel.ISupportInitialize).BeginInit()
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
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIncidents.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvIncidents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIncidents.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReportNo, Me.BookNo, Me.Accession, Me.ISBN, Me.BookTitle, Me.BookAuthor, Me.IncidentType, Me.DateReported, Me.Borrower, Me.Penalty, Me.CopyStatus, Me.Recovered, Me.Remarks})
        Me.dgvIncidents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIncidents.EnableHeadersVisualStyles = False
        Me.dgvIncidents.Location = New System.Drawing.Point(0, 122)
        Me.dgvIncidents.MultiSelect = False
        Me.dgvIncidents.Name = "dgvIncidents"
        Me.dgvIncidents.ReadOnly = True
        Me.dgvIncidents.RowHeadersVisible = False
        Me.dgvIncidents.RowHeadersWidth = 51
        Me.dgvIncidents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIncidents.Size = New System.Drawing.Size(1700, 778)
        Me.dgvIncidents.TabIndex = 3
        '
        'ReportNo
        '
        Me.ReportNo.FillWeight = 60.0!
        Me.ReportNo.HeaderText = "Report No."
        Me.ReportNo.MinimumWidth = 6
        Me.ReportNo.Name = "ReportNo"
        Me.ReportNo.ReadOnly = True
        '
        'BookNo
        '
        Me.BookNo.FillWeight = 60.0!
        Me.BookNo.HeaderText = "Book No."
        Me.BookNo.MinimumWidth = 6
        Me.BookNo.Name = "BookNo"
        Me.BookNo.ReadOnly = True
        '
        'Accession
        '
        Me.Accession.HeaderText = "Accession No."
        Me.Accession.MinimumWidth = 6
        Me.Accession.Name = "Accession"
        Me.Accession.ReadOnly = True
        '
        'ISBN
        '
        Me.ISBN.HeaderText = "ISBN"
        Me.ISBN.MinimumWidth = 6
        Me.ISBN.Name = "ISBN"
        Me.ISBN.ReadOnly = True
        '
        'BookTitle
        '
        Me.BookTitle.FillWeight = 200.0!
        Me.BookTitle.HeaderText = "Book Title"
        Me.BookTitle.MinimumWidth = 6
        Me.BookTitle.Name = "BookTitle"
        Me.BookTitle.ReadOnly = True
        '
        'BookAuthor
        '
        Me.BookAuthor.HeaderText = "Author"
        Me.BookAuthor.MinimumWidth = 6
        Me.BookAuthor.Name = "BookAuthor"
        Me.BookAuthor.ReadOnly = True
        '
        'IncidentType
        '
        Me.IncidentType.HeaderText = "Type"
        Me.IncidentType.MinimumWidth = 6
        Me.IncidentType.Name = "IncidentType"
        Me.IncidentType.ReadOnly = True
        '
        'DateReported
        '
        Me.DateReported.HeaderText = "Date Reported"
        Me.DateReported.MinimumWidth = 6
        Me.DateReported.Name = "DateReported"
        Me.DateReported.ReadOnly = True
        '
        'Borrower
        '
        Me.Borrower.HeaderText = "Reported By (Student)"
        Me.Borrower.MinimumWidth = 6
        Me.Borrower.Name = "Borrower"
        Me.Borrower.ReadOnly = True
        '
        'Penalty
        '
        Me.Penalty.HeaderText = "Penalty"
        Me.Penalty.MinimumWidth = 6
        Me.Penalty.Name = "Penalty"
        Me.Penalty.ReadOnly = True
        '
        'CopyStatus
        '
        Me.CopyStatus.HeaderText = "Copy Status"
        Me.CopyStatus.MinimumWidth = 6
        Me.CopyStatus.Name = "CopyStatus"
        Me.CopyStatus.ReadOnly = True
        '
        'Recovered
        '
        Me.Recovered.HeaderText = "Recovered / Repaired"
        Me.Recovered.MinimumWidth = 6
        Me.Recovered.Name = "Recovered"
        Me.Recovered.ReadOnly = True
        '
        'Remarks
        '
        Me.Remarks.FillWeight = 160.0!
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.MinimumWidth = 6
        Me.Remarks.Name = "Remarks"
        Me.Remarks.ReadOnly = True
        '
        'btnFilter
        '
        Me.btnFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFilter.FlatAppearance.BorderSize = 0
        Me.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFilter.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.ForeColor = System.Drawing.Color.White
        Me.btnFilter.Location = New System.Drawing.Point(1018, 10)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(160, 38)
        Me.btnFilter.TabIndex = 0
        Me.btnFilter.Text = "Filter by Date"
        Me.btnFilter.UseVisualStyleBackColor = False
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnReset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReset.FlatAppearance.BorderSize = 0
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReset.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.ForeColor = System.Drawing.Color.White
        Me.btnReset.Location = New System.Drawing.Point(1188, 10)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(160, 38)
        Me.btnReset.TabIndex = 1
        Me.btnReset.Text = "Show All Dates"
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'btnRecover
        '
        Me.btnRecover.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnRecover.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRecover.FlatAppearance.BorderSize = 0
        Me.btnRecover.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRecover.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecover.ForeColor = System.Drawing.Color.White
        Me.btnRecover.Location = New System.Drawing.Point(1358, 10)
        Me.btnRecover.Name = "btnRecover"
        Me.btnRecover.Size = New System.Drawing.Size(160, 38)
        Me.btnRecover.TabIndex = 2
        Me.btnRecover.Text = "Mark Recovered"
        Me.btnRecover.UseVisualStyleBackColor = False
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExport.FlatAppearance.BorderSize = 0
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.ForeColor = System.Drawing.Color.White
        Me.btnExport.Location = New System.Drawing.Point(1528, 10)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(160, 38)
        Me.btnExport.TabIndex = 3
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'pnlFilter
        '
        Me.pnlFilter.BackColor = System.Drawing.Color.White
        Me.pnlFilter.Controls.Add(Me.lblSearch)
        Me.pnlFilter.Controls.Add(Me.txtSearch)
        Me.pnlFilter.Controls.Add(Me.lblType)
        Me.pnlFilter.Controls.Add(Me.cboType)
        Me.pnlFilter.Controls.Add(Me.lblDateFrom)
        Me.pnlFilter.Controls.Add(Me.dtpFrom)
        Me.pnlFilter.Controls.Add(Me.lblDateTo)
        Me.pnlFilter.Controls.Add(Me.dtpTo)
        Me.pnlFilter.Controls.Add(Me.chkRecovered)
        Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilter.Location = New System.Drawing.Point(0, 58)
        Me.pnlFilter.Name = "pnlFilter"
        Me.pnlFilter.Size = New System.Drawing.Size(1700, 64)
        Me.pnlFilter.TabIndex = 1
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblSearch.Location = New System.Drawing.Point(15, 10)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(234, 17)
        Me.lblSearch.TabIndex = 0
        Me.lblSearch.Text = "Search (ISBN, title, book no., student)"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(15, 32)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(330, 25)
        Me.txtSearch.TabIndex = 1
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblType.Location = New System.Drawing.Point(357, 10)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(36, 17)
        Me.lblType.TabIndex = 2
        Me.lblType.Text = "Type"
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"All", "Lost", "Damaged"})
        Me.cboType.Location = New System.Drawing.Point(357, 32)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(140, 25)
        Me.cboType.TabIndex = 3
        '
        'lblDateFrom
        '
        Me.lblDateFrom.AutoSize = True
        Me.lblDateFrom.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateFrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblDateFrom.Location = New System.Drawing.Point(509, 10)
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(72, 17)
        Me.lblDateFrom.TabIndex = 4
        Me.lblDateFrom.Text = "Date From"
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(509, 32)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(140, 25)
        Me.dtpFrom.TabIndex = 5
        '
        'lblDateTo
        '
        Me.lblDateTo.AutoSize = True
        Me.lblDateTo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblDateTo.Location = New System.Drawing.Point(661, 10)
        Me.lblDateTo.Name = "lblDateTo"
        Me.lblDateTo.Size = New System.Drawing.Size(54, 17)
        Me.lblDateTo.TabIndex = 6
        Me.lblDateTo.Text = "Date To"
        '
        'dtpTo
        '
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(661, 32)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(140, 25)
        Me.dtpTo.TabIndex = 7
        '
        'chkRecovered
        '
        Me.chkRecovered.AutoSize = True
        Me.chkRecovered.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.chkRecovered.Location = New System.Drawing.Point(813, 36)
        Me.chkRecovered.Name = "chkRecovered"
        Me.chkRecovered.Size = New System.Drawing.Size(199, 23)
        Me.chkRecovered.TabIndex = 8
        Me.chkRecovered.Text = "Include recovered / repaired"
        Me.chkRecovered.UseVisualStyleBackColor = True
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.White
        Me.pnlTop.Controls.Add(Me.btnFilter)
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Controls.Add(Me.btnReset)
        Me.pnlTop.Controls.Add(Me.btnExport)
        Me.pnlTop.Controls.Add(Me.btnRecover)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(1700, 58)
        Me.pnlTop.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(11, 14)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(292, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Lost and Damaged Books"
        '
        'frmLostDamagedBooks
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1700, 900)
        Me.Controls.Add(Me.dgvIncidents)
        Me.Controls.Add(Me.pnlFilter)
        Me.Controls.Add(Me.pnlTop)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmLostDamagedBooks"
        Me.Text = "frmLostDamagedBooks"
        CType(Me.dgvIncidents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFilter.ResumeLayout(False)
        Me.pnlFilter.PerformLayout()
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvIncidents As System.Windows.Forms.DataGridView
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
    Friend WithEvents ReportNo As DataGridViewTextBoxColumn
    Friend WithEvents BookNo As DataGridViewTextBoxColumn
    Friend WithEvents Accession As DataGridViewTextBoxColumn
    Friend WithEvents ISBN As DataGridViewTextBoxColumn
    Friend WithEvents BookTitle As DataGridViewTextBoxColumn
    Friend WithEvents BookAuthor As DataGridViewTextBoxColumn
    Friend WithEvents IncidentType As DataGridViewTextBoxColumn
    Friend WithEvents DateReported As DataGridViewTextBoxColumn
    Friend WithEvents Borrower As DataGridViewTextBoxColumn
    Friend WithEvents Penalty As DataGridViewTextBoxColumn
    Friend WithEvents CopyStatus As DataGridViewTextBoxColumn
    Friend WithEvents Recovered As DataGridViewTextBoxColumn
    Friend WithEvents Remarks As DataGridViewTextBoxColumn
End Class
