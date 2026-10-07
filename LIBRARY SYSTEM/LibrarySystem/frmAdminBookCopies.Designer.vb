<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminBookCopies
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
        Me.dgvCopies = New System.Windows.Forms.DataGridView()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.pnlForm = New System.Windows.Forms.Panel()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cboFilter = New System.Windows.Forms.ComboBox()
        Me.lblBookNo = New System.Windows.Forms.Label()
        Me.txtBookNo = New System.Windows.Forms.TextBox()
        Me.lblAccession = New System.Windows.Forms.Label()
        Me.txtAccession = New System.Windows.Forms.TextBox()
        Me.lblIsbn = New System.Windows.Forms.Label()
        Me.txtIsbn = New System.Windows.Forms.TextBox()
        Me.lblTitleCaption = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.lblCondition = New System.Windows.Forms.Label()
        Me.cboCondition = New System.Windows.Forms.ComboBox()
        Me.lblStatusCaption = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.lblCopies = New System.Windows.Forms.Label()
        Me.numCopies = New System.Windows.Forms.NumericUpDown()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.colBookNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccession = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIsbn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBookTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBookAuthor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPublisher = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEdition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colYearPublished = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBookCondition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCopyStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDateAdded = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvCopies, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCopies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButtons.SuspendLayout()
        Me.pnlForm.SuspendLayout()
        Me.pnlTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvCopies
        '
        Me.dgvCopies.AllowUserToAddRows = False
        Me.dgvCopies.AllowUserToDeleteRows = False
        Me.dgvCopies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCopies.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCopies.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCopies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCopies.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBookNo, Me.colAccession, Me.colIsbn, Me.colBookTitle, Me.colBookAuthor, Me.colPublisher, Me.colEdition, Me.colYearPublished, Me.colBookCondition, Me.colCopyStatus, Me.colDateAdded})
        Me.dgvCopies.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCopies.EnableHeadersVisualStyles = False
        Me.dgvCopies.Location = New System.Drawing.Point(0, 182)
        Me.dgvCopies.MultiSelect = False
        Me.dgvCopies.Name = "dgvCopies"
        Me.dgvCopies.ReadOnly = True
        Me.dgvCopies.RowHeadersVisible = False
        Me.dgvCopies.RowHeadersWidth = 51
        Me.dgvCopies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCopies.Size = New System.Drawing.Size(1700, 718)
        Me.dgvCopies.TabIndex = 3
        '
        'pnlButtons
        '
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButtons.Location = New System.Drawing.Point(0, 128)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(1700, 54)
        Me.pnlButtons.TabIndex = 2
        Me.pnlButtons.Controls.Add(Me.btnAdd)
        Me.pnlButtons.Controls.Add(Me.btnUpdate)
        Me.pnlButtons.Controls.Add(Me.btnDelete)
        Me.pnlButtons.Controls.Add(Me.btnClear)
        Me.pnlButtons.Controls.Add(Me.btnExport)
        '
        'pnlForm
        '
        Me.pnlForm.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlForm.Location = New System.Drawing.Point(0, 64)
        Me.pnlForm.Name = "pnlForm"
        Me.pnlForm.Size = New System.Drawing.Size(1700, 64)
        Me.pnlForm.TabIndex = 1
        Me.pnlForm.Controls.Add(Me.lblBookNo)
        Me.pnlForm.Controls.Add(Me.txtBookNo)
        Me.pnlForm.Controls.Add(Me.lblAccession)
        Me.pnlForm.Controls.Add(Me.txtAccession)
        Me.pnlForm.Controls.Add(Me.lblIsbn)
        Me.pnlForm.Controls.Add(Me.txtIsbn)
        Me.pnlForm.Controls.Add(Me.lblTitleCaption)
        Me.pnlForm.Controls.Add(Me.txtTitle)
        Me.pnlForm.Controls.Add(Me.lblCondition)
        Me.pnlForm.Controls.Add(Me.cboCondition)
        Me.pnlForm.Controls.Add(Me.lblStatusCaption)
        Me.pnlForm.Controls.Add(Me.txtStatus)
        Me.pnlForm.Controls.Add(Me.lblCopies)
        Me.pnlForm.Controls.Add(Me.numCopies)
        '
        'pnlTop
        '
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(1700, 64)
        Me.pnlTop.TabIndex = 0
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Controls.Add(Me.lblSearch)
        Me.pnlTop.Controls.Add(Me.txtSearch)
        Me.pnlTop.Controls.Add(Me.lblStatus)
        Me.pnlTop.Controls.Add(Me.cboFilter)
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(16, 14)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(158, 32)
        Me.lblTitle.Text = "Book Copies"
        Me.lblTitle.TabIndex = 0
        '
        'lblSearch
        '
        Me.lblSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSearch.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(1083, 18)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(55, 19)
        Me.lblSearch.Text = "Search:"
        Me.lblSearch.TabIndex = 1
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Location = New System.Drawing.Point(1147, 14)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(320, 27)
        Me.txtSearch.TabIndex = 2
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(1489, 18)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(52, 19)
        Me.lblStatus.Text = "Status:"
        Me.lblStatus.TabIndex = 3
        '
        'cboFilter
        '
        Me.cboFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilter.FormattingEnabled = True
        Me.cboFilter.Items.AddRange(New Object() {"All", "Available", "Borrowed", "Lost", "Damaged"})
        Me.cboFilter.Location = New System.Drawing.Point(1550, 14)
        Me.cboFilter.Name = "cboFilter"
        Me.cboFilter.Size = New System.Drawing.Size(130, 28)
        Me.cboFilter.TabIndex = 4
        '
        'lblBookNo
        '
        Me.lblBookNo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBookNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblBookNo.AutoSize = True
        Me.lblBookNo.Location = New System.Drawing.Point(16, 4)
        Me.lblBookNo.Name = "lblBookNo"
        Me.lblBookNo.Size = New System.Drawing.Size(62, 17)
        Me.lblBookNo.Text = "Book No."
        Me.lblBookNo.TabIndex = 0
        '
        'txtBookNo
        '
        Me.txtBookNo.Location = New System.Drawing.Point(16, 26)
        Me.txtBookNo.Name = "txtBookNo"
        Me.txtBookNo.ReadOnly = True
        Me.txtBookNo.Size = New System.Drawing.Size(100, 27)
        Me.txtBookNo.TabIndex = 1
        '
        'lblAccession
        '
        Me.lblAccession.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccession.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblAccession.AutoSize = True
        Me.lblAccession.Location = New System.Drawing.Point(128, 4)
        Me.lblAccession.Name = "lblAccession"
        Me.lblAccession.Size = New System.Drawing.Size(90, 17)
        Me.lblAccession.Text = "Accession No."
        Me.lblAccession.TabIndex = 2
        '
        'txtAccession
        '
        Me.txtAccession.Location = New System.Drawing.Point(128, 26)
        Me.txtAccession.Name = "txtAccession"
        Me.txtAccession.ReadOnly = True
        Me.txtAccession.Size = New System.Drawing.Size(130, 27)
        Me.txtAccession.TabIndex = 3
        '
        'lblIsbn
        '
        Me.lblIsbn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIsbn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblIsbn.AutoSize = True
        Me.lblIsbn.Location = New System.Drawing.Point(270, 4)
        Me.lblIsbn.Name = "lblIsbn"
        Me.lblIsbn.Size = New System.Drawing.Size(32, 17)
        Me.lblIsbn.Text = "ISBN"
        Me.lblIsbn.TabIndex = 4
        '
        'txtIsbn
        '
        Me.txtIsbn.Location = New System.Drawing.Point(270, 26)
        Me.txtIsbn.MaxLength = 13
        Me.txtIsbn.Name = "txtIsbn"
        Me.txtIsbn.Size = New System.Drawing.Size(170, 27)
        Me.txtIsbn.TabIndex = 5
        '
        'lblTitleCaption
        '
        Me.lblTitleCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitleCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblTitleCaption.AutoSize = True
        Me.lblTitleCaption.Location = New System.Drawing.Point(452, 4)
        Me.lblTitleCaption.Name = "lblTitleCaption"
        Me.lblTitleCaption.Size = New System.Drawing.Size(63, 17)
        Me.lblTitleCaption.Text = "Book Title"
        Me.lblTitleCaption.TabIndex = 6
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(452, 26)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.ReadOnly = True
        Me.txtTitle.Size = New System.Drawing.Size(330, 27)
        Me.txtTitle.TabIndex = 7
        '
        'lblCondition
        '
        Me.lblCondition.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCondition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblCondition.AutoSize = True
        Me.lblCondition.Location = New System.Drawing.Point(794, 4)
        Me.lblCondition.Name = "lblCondition"
        Me.lblCondition.Size = New System.Drawing.Size(56, 17)
        Me.lblCondition.Text = "Condition"
        Me.lblCondition.TabIndex = 8
        '
        'cboCondition
        '
        Me.cboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondition.FormattingEnabled = True
        Me.cboCondition.Location = New System.Drawing.Point(794, 26)
        Me.cboCondition.Name = "cboCondition"
        Me.cboCondition.Size = New System.Drawing.Size(140, 28)
        Me.cboCondition.TabIndex = 9
        '
        'lblStatusCaption
        '
        Me.lblStatusCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblStatusCaption.AutoSize = True
        Me.lblStatusCaption.Location = New System.Drawing.Point(946, 4)
        Me.lblStatusCaption.Name = "lblStatusCaption"
        Me.lblStatusCaption.Size = New System.Drawing.Size(41, 17)
        Me.lblStatusCaption.Text = "Status"
        Me.lblStatusCaption.TabIndex = 10
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(946, 26)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(110, 27)
        Me.txtStatus.TabIndex = 11
        '
        'lblCopies
        '
        Me.lblCopies.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopies.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblCopies.AutoSize = True
        Me.lblCopies.Location = New System.Drawing.Point(1068, 4)
        Me.lblCopies.Name = "lblCopies"
        Me.lblCopies.Size = New System.Drawing.Size(87, 17)
        Me.lblCopies.Text = "Copies to add"
        Me.lblCopies.TabIndex = 12
        '
        'numCopies
        '
        Me.numCopies.Location = New System.Drawing.Point(1068, 26)
        Me.numCopies.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numCopies.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numCopies.Name = "numCopies"
        Me.numCopies.Size = New System.Drawing.Size(120, 27)
        Me.numCopies.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numCopies.TabIndex = 13
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(16, 6)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(160, 38)
        Me.btnAdd.Text = "Add Copy"
        Me.btnAdd.UseVisualStyleBackColor = False
        Me.btnAdd.TabIndex = 0
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(186, 6)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(160, 38)
        Me.btnUpdate.Text = "Update Condition"
        Me.btnUpdate.UseVisualStyleBackColor = False
        Me.btnUpdate.TabIndex = 1
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(356, 6)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(160, 38)
        Me.btnDelete.Text = "Delete Copy"
        Me.btnDelete.UseVisualStyleBackColor = False
        Me.btnDelete.TabIndex = 2
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(526, 6)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(160, 38)
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        Me.btnClear.TabIndex = 3
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExport.FlatAppearance.BorderSize = 0
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.ForeColor = System.Drawing.Color.White
        Me.btnExport.Location = New System.Drawing.Point(696, 6)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(160, 38)
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = False
        Me.btnExport.TabIndex = 4
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
        Me.colBookTitle.FillWeight = 220.0!
        Me.colBookTitle.HeaderText = "Book Title"
        Me.colBookTitle.MinimumWidth = 6
        Me.colBookTitle.Name = "BookTitle"
        Me.colBookTitle.ReadOnly = True
        '
        'colBookAuthor
        '
        Me.colBookAuthor.FillWeight = 140.0!
        Me.colBookAuthor.HeaderText = "Author"
        Me.colBookAuthor.MinimumWidth = 6
        Me.colBookAuthor.Name = "BookAuthor"
        Me.colBookAuthor.ReadOnly = True
        '
        'colPublisher
        '
        Me.colPublisher.HeaderText = "Publisher"
        Me.colPublisher.MinimumWidth = 6
        Me.colPublisher.Name = "Publisher"
        Me.colPublisher.ReadOnly = True
        '
        'colEdition
        '
        Me.colEdition.HeaderText = "Edition"
        Me.colEdition.MinimumWidth = 6
        Me.colEdition.Name = "Edition"
        Me.colEdition.ReadOnly = True
        '
        'colYearPublished
        '
        Me.colYearPublished.FillWeight = 60.0!
        Me.colYearPublished.HeaderText = "Year"
        Me.colYearPublished.MinimumWidth = 6
        Me.colYearPublished.Name = "YearPublished"
        Me.colYearPublished.ReadOnly = True
        '
        'colBookCondition
        '
        Me.colBookCondition.HeaderText = "Condition"
        Me.colBookCondition.MinimumWidth = 6
        Me.colBookCondition.Name = "BookCondition"
        Me.colBookCondition.ReadOnly = True
        '
        'colCopyStatus
        '
        Me.colCopyStatus.HeaderText = "Status"
        Me.colCopyStatus.MinimumWidth = 6
        Me.colCopyStatus.Name = "CopyStatus"
        Me.colCopyStatus.ReadOnly = True
        '
        'colDateAdded
        '
        Me.colDateAdded.HeaderText = "Date Added"
        Me.colDateAdded.MinimumWidth = 6
        Me.colDateAdded.Name = "DateAdded"
        Me.colDateAdded.ReadOnly = True
        '
        'frmAdminBookCopies
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1700, 900)
        Me.Controls.Add(Me.dgvCopies)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.pnlForm)
        Me.Controls.Add(Me.pnlTop)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAdminBookCopies"
        Me.Text = "frmAdminBookCopies"
        CType(Me.dgvCopies, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCopies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlForm.ResumeLayout(False)
        Me.pnlForm.PerformLayout()
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlButtons.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvCopies As System.Windows.Forms.DataGridView
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents pnlForm As System.Windows.Forms.Panel
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cboFilter As System.Windows.Forms.ComboBox
    Friend WithEvents lblBookNo As System.Windows.Forms.Label
    Friend WithEvents txtBookNo As System.Windows.Forms.TextBox
    Friend WithEvents lblAccession As System.Windows.Forms.Label
    Friend WithEvents txtAccession As System.Windows.Forms.TextBox
    Friend WithEvents lblIsbn As System.Windows.Forms.Label
    Friend WithEvents txtIsbn As System.Windows.Forms.TextBox
    Friend WithEvents lblTitleCaption As System.Windows.Forms.Label
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents lblCondition As System.Windows.Forms.Label
    Friend WithEvents cboCondition As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatusCaption As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents lblCopies As System.Windows.Forms.Label
    Friend WithEvents numCopies As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents colBookNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAccession As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIsbn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBookTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBookAuthor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPublisher As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEdition As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colYearPublished As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBookCondition As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCopyStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDateAdded As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
