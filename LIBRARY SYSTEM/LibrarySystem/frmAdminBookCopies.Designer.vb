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
        Me.BookNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Accession = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ISBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BookTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BookAuthor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Publisher = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Edition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.YearPublished = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BookCondition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CopyStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateAdded = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.pnlForm = New System.Windows.Forms.Panel()
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
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cboFilter = New System.Windows.Forms.ComboBox()
        CType(Me.dgvCopies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButtons.SuspendLayout()
        Me.pnlForm.SuspendLayout()
        CType(Me.numCopies, System.ComponentModel.ISupportInitialize).BeginInit()
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
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCopies.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCopies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCopies.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BookNo, Me.Accession, Me.ISBN, Me.BookTitle, Me.BookAuthor, Me.Publisher, Me.Edition, Me.YearPublished, Me.BookCondition, Me.CopyStatus, Me.DateAdded})
        Me.dgvCopies.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCopies.EnableHeadersVisualStyles = False
        Me.dgvCopies.Location = New System.Drawing.Point(0, 169)
        Me.dgvCopies.MultiSelect = False
        Me.dgvCopies.Name = "dgvCopies"
        Me.dgvCopies.ReadOnly = True
        Me.dgvCopies.RowHeadersVisible = False
        Me.dgvCopies.RowHeadersWidth = 51
        Me.dgvCopies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCopies.Size = New System.Drawing.Size(1700, 731)
        Me.dgvCopies.TabIndex = 3
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
        Me.BookTitle.FillWeight = 220.0!
        Me.BookTitle.HeaderText = "Book Title"
        Me.BookTitle.MinimumWidth = 6
        Me.BookTitle.Name = "BookTitle"
        Me.BookTitle.ReadOnly = True
        '
        'BookAuthor
        '
        Me.BookAuthor.FillWeight = 140.0!
        Me.BookAuthor.HeaderText = "Author"
        Me.BookAuthor.MinimumWidth = 6
        Me.BookAuthor.Name = "BookAuthor"
        Me.BookAuthor.ReadOnly = True
        '
        'Publisher
        '
        Me.Publisher.HeaderText = "Publisher"
        Me.Publisher.MinimumWidth = 6
        Me.Publisher.Name = "Publisher"
        Me.Publisher.ReadOnly = True
        '
        'Edition
        '
        Me.Edition.HeaderText = "Edition"
        Me.Edition.MinimumWidth = 6
        Me.Edition.Name = "Edition"
        Me.Edition.ReadOnly = True
        '
        'YearPublished
        '
        Me.YearPublished.FillWeight = 60.0!
        Me.YearPublished.HeaderText = "Year"
        Me.YearPublished.MinimumWidth = 6
        Me.YearPublished.Name = "YearPublished"
        Me.YearPublished.ReadOnly = True
        '
        'BookCondition
        '
        Me.BookCondition.HeaderText = "Condition"
        Me.BookCondition.MinimumWidth = 6
        Me.BookCondition.Name = "BookCondition"
        Me.BookCondition.ReadOnly = True
        '
        'CopyStatus
        '
        Me.CopyStatus.HeaderText = "Status"
        Me.CopyStatus.MinimumWidth = 6
        Me.CopyStatus.Name = "CopyStatus"
        Me.CopyStatus.ReadOnly = True
        '
        'DateAdded
        '
        Me.DateAdded.HeaderText = "Date Added"
        Me.DateAdded.MinimumWidth = 6
        Me.DateAdded.Name = "DateAdded"
        Me.DateAdded.ReadOnly = True
        '
        'pnlButtons
        '
        Me.pnlButtons.BackColor = System.Drawing.Color.White
        Me.pnlButtons.Controls.Add(Me.btnAdd)
        Me.pnlButtons.Controls.Add(Me.btnUpdate)
        Me.pnlButtons.Controls.Add(Me.btnDelete)
        Me.pnlButtons.Controls.Add(Me.btnClear)
        Me.pnlButtons.Controls.Add(Me.btnExport)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButtons.Location = New System.Drawing.Point(0, 115)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(1700, 54)
        Me.pnlButtons.TabIndex = 2
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
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add Copy"
        Me.btnAdd.UseVisualStyleBackColor = False
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
        Me.btnUpdate.TabIndex = 1
        Me.btnUpdate.Text = "Update Condition"
        Me.btnUpdate.UseVisualStyleBackColor = False
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
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete Copy"
        Me.btnDelete.UseVisualStyleBackColor = False
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
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
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
        Me.btnExport.TabIndex = 4
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'pnlForm
        '
        Me.pnlForm.BackColor = System.Drawing.Color.White
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
        Me.pnlForm.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlForm.Location = New System.Drawing.Point(0, 51)
        Me.pnlForm.Name = "pnlForm"
        Me.pnlForm.Size = New System.Drawing.Size(1700, 64)
        Me.pnlForm.TabIndex = 1
        '
        'lblBookNo
        '
        Me.lblBookNo.AutoSize = True
        Me.lblBookNo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBookNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblBookNo.Location = New System.Drawing.Point(16, 4)
        Me.lblBookNo.Name = "lblBookNo"
        Me.lblBookNo.Size = New System.Drawing.Size(64, 17)
        Me.lblBookNo.TabIndex = 0
        Me.lblBookNo.Text = "Book No."
        '
        'txtBookNo
        '
        Me.txtBookNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBookNo.Location = New System.Drawing.Point(16, 26)
        Me.txtBookNo.Name = "txtBookNo"
        Me.txtBookNo.ReadOnly = True
        Me.txtBookNo.Size = New System.Drawing.Size(100, 25)
        Me.txtBookNo.TabIndex = 1
        '
        'lblAccession
        '
        Me.lblAccession.AutoSize = True
        Me.lblAccession.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccession.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblAccession.Location = New System.Drawing.Point(128, 4)
        Me.lblAccession.Name = "lblAccession"
        Me.lblAccession.Size = New System.Drawing.Size(92, 17)
        Me.lblAccession.TabIndex = 2
        Me.lblAccession.Text = "Accession No."
        '
        'txtAccession
        '
        Me.txtAccession.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccession.Location = New System.Drawing.Point(128, 26)
        Me.txtAccession.Name = "txtAccession"
        Me.txtAccession.ReadOnly = True
        Me.txtAccession.Size = New System.Drawing.Size(130, 25)
        Me.txtAccession.TabIndex = 3
        '
        'lblIsbn
        '
        Me.lblIsbn.AutoSize = True
        Me.lblIsbn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIsbn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblIsbn.Location = New System.Drawing.Point(270, 4)
        Me.lblIsbn.Name = "lblIsbn"
        Me.lblIsbn.Size = New System.Drawing.Size(37, 17)
        Me.lblIsbn.TabIndex = 4
        Me.lblIsbn.Text = "ISBN"
        '
        'txtIsbn
        '
        Me.txtIsbn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIsbn.Location = New System.Drawing.Point(270, 26)
        Me.txtIsbn.MaxLength = 13
        Me.txtIsbn.Name = "txtIsbn"
        Me.txtIsbn.Size = New System.Drawing.Size(170, 25)
        Me.txtIsbn.TabIndex = 5
        '
        'lblTitleCaption
        '
        Me.lblTitleCaption.AutoSize = True
        Me.lblTitleCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitleCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblTitleCaption.Location = New System.Drawing.Point(452, 4)
        Me.lblTitleCaption.Name = "lblTitleCaption"
        Me.lblTitleCaption.Size = New System.Drawing.Size(68, 17)
        Me.lblTitleCaption.TabIndex = 6
        Me.lblTitleCaption.Text = "Book Title"
        '
        'txtTitle
        '
        Me.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTitle.Location = New System.Drawing.Point(452, 26)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.ReadOnly = True
        Me.txtTitle.Size = New System.Drawing.Size(330, 25)
        Me.txtTitle.TabIndex = 7
        '
        'lblCondition
        '
        Me.lblCondition.AutoSize = True
        Me.lblCondition.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCondition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblCondition.Location = New System.Drawing.Point(794, 4)
        Me.lblCondition.Name = "lblCondition"
        Me.lblCondition.Size = New System.Drawing.Size(67, 17)
        Me.lblCondition.TabIndex = 8
        Me.lblCondition.Text = "Condition"
        '
        'cboCondition
        '
        Me.cboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondition.FormattingEnabled = True
        Me.cboCondition.Location = New System.Drawing.Point(794, 26)
        Me.cboCondition.Name = "cboCondition"
        Me.cboCondition.Size = New System.Drawing.Size(140, 25)
        Me.cboCondition.TabIndex = 9
        '
        'lblStatusCaption
        '
        Me.lblStatusCaption.AutoSize = True
        Me.lblStatusCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblStatusCaption.Location = New System.Drawing.Point(946, 4)
        Me.lblStatusCaption.Name = "lblStatusCaption"
        Me.lblStatusCaption.Size = New System.Drawing.Size(46, 17)
        Me.lblStatusCaption.TabIndex = 10
        Me.lblStatusCaption.Text = "Status"
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(946, 26)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(110, 25)
        Me.txtStatus.TabIndex = 11
        '
        'lblCopies
        '
        Me.lblCopies.AutoSize = True
        Me.lblCopies.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopies.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblCopies.Location = New System.Drawing.Point(1068, 4)
        Me.lblCopies.Name = "lblCopies"
        Me.lblCopies.Size = New System.Drawing.Size(92, 17)
        Me.lblCopies.TabIndex = 12
        Me.lblCopies.Text = "Copies to add"
        '
        'numCopies
        '
        Me.numCopies.Location = New System.Drawing.Point(1068, 26)
        Me.numCopies.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numCopies.Name = "numCopies"
        Me.numCopies.Size = New System.Drawing.Size(120, 25)
        Me.numCopies.TabIndex = 13
        Me.numCopies.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.White
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Controls.Add(Me.lblSearch)
        Me.pnlTop.Controls.Add(Me.txtSearch)
        Me.pnlTop.Controls.Add(Me.lblStatus)
        Me.pnlTop.Controls.Add(Me.cboFilter)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(1700, 51)
        Me.pnlTop.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(13, 10)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(149, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Book Copies"
        '
        'lblSearch
        '
        Me.lblSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblSearch.Location = New System.Drawing.Point(1082, 17)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(54, 19)
        Me.lblSearch.TabIndex = 1
        Me.lblSearch.Text = "Search:"
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Location = New System.Drawing.Point(1146, 13)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(245, 25)
        Me.txtSearch.TabIndex = 2
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(1415, 18)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(51, 19)
        Me.lblStatus.TabIndex = 3
        Me.lblStatus.Text = "Status:"
        '
        'cboFilter
        '
        Me.cboFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilter.DropDownWidth = 200
        Me.cboFilter.FormattingEnabled = True
        Me.cboFilter.Items.AddRange(New Object() {"All", "Available", "Borrowed", "Lost", "Damaged"})
        Me.cboFilter.Location = New System.Drawing.Point(1476, 14)
        Me.cboFilter.Name = "cboFilter"
        Me.cboFilter.Size = New System.Drawing.Size(186, 25)
        Me.cboFilter.TabIndex = 4
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
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlForm.ResumeLayout(False)
        Me.pnlForm.PerformLayout()
        CType(Me.numCopies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
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
    Friend WithEvents BookNo As DataGridViewTextBoxColumn
    Friend WithEvents Accession As DataGridViewTextBoxColumn
    Friend WithEvents ISBN As DataGridViewTextBoxColumn
    Friend WithEvents BookTitle As DataGridViewTextBoxColumn
    Friend WithEvents BookAuthor As DataGridViewTextBoxColumn
    Friend WithEvents Publisher As DataGridViewTextBoxColumn
    Friend WithEvents Edition As DataGridViewTextBoxColumn
    Friend WithEvents YearPublished As DataGridViewTextBoxColumn
    Friend WithEvents BookCondition As DataGridViewTextBoxColumn
    Friend WithEvents CopyStatus As DataGridViewTextBoxColumn
    Friend WithEvents DateAdded As DataGridViewTextBoxColumn
End Class
