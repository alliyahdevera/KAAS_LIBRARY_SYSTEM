<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAdminBookInventory
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvCopies = New System.Windows.Forms.DataGridView()
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
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.pnlForm = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
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
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.lblname = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lblposition = New System.Windows.Forms.Label()
        CType(Me.dgvCopies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlForm.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.numCopies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTop.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvCopies
        '
        Me.dgvCopies.AllowUserToAddRows = False
        Me.dgvCopies.AllowUserToDeleteRows = False
        Me.dgvCopies.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCopies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCopies.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCopies.BackgroundColor = System.Drawing.Color.White
        Me.dgvCopies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCopies.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Accession, Me.ISBN, Me.BookTitle, Me.BookAuthor, Me.Publisher, Me.Edition, Me.YearPublished, Me.BookCondition, Me.CopyStatus, Me.DateAdded})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCopies.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCopies.GridColor = System.Drawing.Color.Black
        Me.dgvCopies.Location = New System.Drawing.Point(0, 337)
        Me.dgvCopies.MultiSelect = False
        Me.dgvCopies.Name = "dgvCopies"
        Me.dgvCopies.ReadOnly = True
        Me.dgvCopies.RowHeadersVisible = False
        Me.dgvCopies.RowHeadersWidth = 51
        Me.dgvCopies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCopies.Size = New System.Drawing.Size(1231, 338)
        Me.dgvCopies.TabIndex = 3
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
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(874, 42)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(146, 28)
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
        Me.btnUpdate.Location = New System.Drawing.Point(874, 81)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(146, 33)
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
        Me.btnDelete.Location = New System.Drawing.Point(874, 129)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(146, 33)
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
        Me.btnClear.Location = New System.Drawing.Point(874, 177)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(146, 35)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'pnlForm
        '
        Me.pnlForm.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.pnlForm.Controls.Add(Me.Panel1)
        Me.pnlForm.Controls.Add(Me.btnAdd)
        Me.pnlForm.Controls.Add(Me.btnDelete)
        Me.pnlForm.Controls.Add(Me.btnUpdate)
        Me.pnlForm.Controls.Add(Me.btnClear)
        Me.pnlForm.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlForm.Location = New System.Drawing.Point(0, 51)
        Me.pnlForm.Name = "pnlForm"
        Me.pnlForm.Size = New System.Drawing.Size(1231, 240)
        Me.pnlForm.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.lblAccession)
        Me.Panel1.Controls.Add(Me.txtAccession)
        Me.Panel1.Controls.Add(Me.lblIsbn)
        Me.Panel1.Controls.Add(Me.txtIsbn)
        Me.Panel1.Controls.Add(Me.lblTitleCaption)
        Me.Panel1.Controls.Add(Me.txtTitle)
        Me.Panel1.Controls.Add(Me.lblCondition)
        Me.Panel1.Controls.Add(Me.cboCondition)
        Me.Panel1.Controls.Add(Me.lblStatusCaption)
        Me.Panel1.Controls.Add(Me.txtStatus)
        Me.Panel1.Controls.Add(Me.lblCopies)
        Me.Panel1.Controls.Add(Me.numCopies)
        Me.Panel1.Location = New System.Drawing.Point(21, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(750, 208)
        Me.Panel1.TabIndex = 14
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(750, 38)
        Me.Panel2.TabIndex = 14
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(7, 3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(206, 32)
        Me.Label15.TabIndex = 71
        Me.Label15.Text = "Book Information"
        '
        'lblAccession
        '
        Me.lblAccession.AutoSize = True
        Me.lblAccession.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccession.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblAccession.Location = New System.Drawing.Point(26, 63)
        Me.lblAccession.Name = "lblAccession"
        Me.lblAccession.Size = New System.Drawing.Size(113, 21)
        Me.lblAccession.TabIndex = 2
        Me.lblAccession.Text = "Accession No."
        '
        'txtAccession
        '
        Me.txtAccession.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccession.Location = New System.Drawing.Point(145, 60)
        Me.txtAccession.Name = "txtAccession"
        Me.txtAccession.ReadOnly = True
        Me.txtAccession.Size = New System.Drawing.Size(229, 30)
        Me.txtAccession.TabIndex = 3
        '
        'lblIsbn
        '
        Me.lblIsbn.AutoSize = True
        Me.lblIsbn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIsbn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblIsbn.Location = New System.Drawing.Point(26, 110)
        Me.lblIsbn.Name = "lblIsbn"
        Me.lblIsbn.Size = New System.Drawing.Size(46, 21)
        Me.lblIsbn.TabIndex = 4
        Me.lblIsbn.Text = "ISBN"
        '
        'txtIsbn
        '
        Me.txtIsbn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIsbn.Location = New System.Drawing.Point(145, 107)
        Me.txtIsbn.MaxLength = 13
        Me.txtIsbn.Name = "txtIsbn"
        Me.txtIsbn.Size = New System.Drawing.Size(229, 30)
        Me.txtIsbn.TabIndex = 5
        '
        'lblTitleCaption
        '
        Me.lblTitleCaption.AutoSize = True
        Me.lblTitleCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitleCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblTitleCaption.Location = New System.Drawing.Point(26, 158)
        Me.lblTitleCaption.Name = "lblTitleCaption"
        Me.lblTitleCaption.Size = New System.Drawing.Size(84, 21)
        Me.lblTitleCaption.TabIndex = 6
        Me.lblTitleCaption.Text = "Book Title"
        '
        'txtTitle
        '
        Me.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTitle.Location = New System.Drawing.Point(145, 155)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.ReadOnly = True
        Me.txtTitle.Size = New System.Drawing.Size(229, 30)
        Me.txtTitle.TabIndex = 7
        '
        'lblCondition
        '
        Me.lblCondition.AutoSize = True
        Me.lblCondition.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCondition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblCondition.Location = New System.Drawing.Point(394, 62)
        Me.lblCondition.Name = "lblCondition"
        Me.lblCondition.Size = New System.Drawing.Size(82, 21)
        Me.lblCondition.TabIndex = 8
        Me.lblCondition.Text = "Condition"
        '
        'cboCondition
        '
        Me.cboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondition.FormattingEnabled = True
        Me.cboCondition.Location = New System.Drawing.Point(523, 59)
        Me.cboCondition.Name = "cboCondition"
        Me.cboCondition.Size = New System.Drawing.Size(186, 31)
        Me.cboCondition.TabIndex = 9
        '
        'lblStatusCaption
        '
        Me.lblStatusCaption.AutoSize = True
        Me.lblStatusCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblStatusCaption.Location = New System.Drawing.Point(394, 108)
        Me.lblStatusCaption.Name = "lblStatusCaption"
        Me.lblStatusCaption.Size = New System.Drawing.Size(55, 21)
        Me.lblStatusCaption.TabIndex = 10
        Me.lblStatusCaption.Text = "Status"
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(523, 105)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(186, 30)
        Me.txtStatus.TabIndex = 11
        '
        'lblCopies
        '
        Me.lblCopies.AutoSize = True
        Me.lblCopies.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopies.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblCopies.Location = New System.Drawing.Point(394, 156)
        Me.lblCopies.Name = "lblCopies"
        Me.lblCopies.Size = New System.Drawing.Size(112, 21)
        Me.lblCopies.TabIndex = 12
        Me.lblCopies.Text = "Copies to add"
        '
        'numCopies
        '
        Me.numCopies.Location = New System.Drawing.Point(523, 154)
        Me.numCopies.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numCopies.Name = "numCopies"
        Me.numCopies.Size = New System.Drawing.Size(186, 30)
        Me.numCopies.TabIndex = 13
        Me.numCopies.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(1231, 51)
        Me.pnlTop.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(17, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(235, 41)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Book Inventory"
        '
        'lblSearch
        '
        Me.lblSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblSearch.Location = New System.Drawing.Point(19, 301)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(66, 23)
        Me.lblSearch.TabIndex = 1
        Me.lblSearch.Text = "Search "
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Location = New System.Drawing.Point(83, 299)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(176, 30)
        Me.txtSearch.TabIndex = 2
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(972, 304)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(61, 23)
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
        Me.cboFilter.Location = New System.Drawing.Point(1033, 300)
        Me.cboFilter.Name = "cboFilter"
        Me.cboFilter.Size = New System.Drawing.Size(186, 31)
        Me.cboFilter.TabIndex = 4
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.White
        Me.Panel13.Controls.Add(Me.lblname)
        Me.Panel13.Controls.Add(Me.Label29)
        Me.Panel13.Controls.Add(Me.Label28)
        Me.Panel13.Controls.Add(Me.lblposition)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel13.Location = New System.Drawing.Point(0, 675)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(1231, 27)
        Me.Panel13.TabIndex = 157
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.BackColor = System.Drawing.Color.Transparent
        Me.lblname.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblname.Location = New System.Drawing.Point(54, 3)
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
        Me.Label29.Location = New System.Drawing.Point(4, 3)
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
        Me.Label28.Location = New System.Drawing.Point(249, 3)
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
        Me.lblposition.Location = New System.Drawing.Point(315, 3)
        Me.lblposition.Name = "lblposition"
        Me.lblposition.Size = New System.Drawing.Size(100, 28)
        Me.lblposition.TabIndex = 66
        Me.lblposition.Text = "NPosition"
        '
        'frmAdminBookInventory
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1231, 702)
        Me.Controls.Add(Me.dgvCopies)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.cboFilter)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.pnlForm)
        Me.Controls.Add(Me.pnlTop)
        Me.Controls.Add(Me.Panel13)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAdminBookInventory"
        Me.Text = "frmAdminBookInventory"
        CType(Me.dgvCopies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlForm.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.numCopies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvCopies As System.Windows.Forms.DataGridView
    Friend WithEvents pnlForm As System.Windows.Forms.Panel
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cboFilter As System.Windows.Forms.ComboBox
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
    Friend WithEvents Panel13 As Panel
    Friend WithEvents lblname As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents lblposition As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label15 As Label
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
