Imports MySql.Data.MySqlClient

Public Class frmPenaltyManagement
    Private selectedTransactionId As Integer = 0
    Private pager As GridPager

    ' Date range pickers and the Generate Report button are located by type/text, so the
    ' designer control names do not matter (left picker = From, right picker = To).
    Private dtpFrom As DateTimePicker
    Private dtpTo As DateTimePicker
    Private btnReport As Button

    ' The date filter is only applied after "Generate Report" is clicked.
    Private dateFilterOn As Boolean = False
    Private filterFrom As Date
    Private filterTo As Date
    Private ready As Boolean = False

    ' ------------------------------------------------------------ setup
    Private Sub frmPenaltyManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UiHelpers.FillHeader(Me)          ' name, position, today
        With DataGridView1
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        ComboBox2.Enabled = False        ' derived from the condition

        BindReportControls()
        ready = True
        RefreshPenaltyData()
    End Sub

    Private Sub frmPenaltyManagement_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        UiHelpers.FillHeader(Me)
        If Me.Visible AndAlso ready Then RefreshPenaltyData(txtSearch.Text)
    End Sub

    Private Sub CollectControls(parent As Control, list As List(Of Control))
        For Each c As Control In parent.Controls
            list.Add(c)
            CollectControls(c, list)
        Next
    End Sub

    Private Sub BindReportControls()
        Dim all As New List(Of Control)()
        CollectControls(Me, all)

        Dim pickers = all.OfType(Of DateTimePicker)().OrderBy(Function(p) p.PointToScreen(Point.Empty).X).ToList()
        If pickers.Count >= 2 Then
            dtpFrom = pickers(0)
            dtpTo = pickers(1)
        End If

        btnReport = all.OfType(Of Button)().FirstOrDefault(
            Function(b) b.Text.IndexOf("generate", StringComparison.OrdinalIgnoreCase) >= 0)
        If btnReport IsNot Nothing Then AddHandler btnReport.Click, AddressOf btnGenerateReport_Click
    End Sub

    ' ------------------------------------------------------------ generate report (date filter)
    Private Sub btnGenerateReport_Click(sender As Object, e As EventArgs)
        If dtpFrom Is Nothing OrElse dtpTo Is Nothing Then
            MsgBox("Date pickers were not found on this form.", vbExclamation, "Generate Report")
            Exit Sub
        End If

        If dtpFrom.Value.Date > dtpTo.Value.Date Then
            MsgBox("'Date From' cannot be later than 'To'.", vbExclamation, "Generate Report")
            Exit Sub
        End If

        filterFrom = dtpFrom.Value.Date
        filterTo = dtpTo.Value.Date
        dateFilterOn = True
        RefreshPenaltyData(txtSearch.Text)

        If DataGridView1.Rows.Count = 0 Then
            MsgBox("No penalty records found from " & filterFrom.ToString("MM/dd/yyyy") &
                   " to " & filterTo.ToString("MM/dd/yyyy") & ".", vbInformation, "Generate Report")
        End If
    End Sub

    ' ------------------------------------------------------------ list
    ' Search matches the username only. If Generate Report was clicked, the grid is
    ' also limited to the chosen date range (Penalty Date column).
    Public Sub RefreshPenaltyData(Optional keyword As String = "")
        If pager Is Nothing Then pager = PagerHelper.Create(DataGridView1)
        DataGridView1.Rows.Clear()
        Dim kw As String = If(keyword, "").Trim()

        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT p.transaction_id, u.username, p.receipt_number, v.book_id, v.isbn, v.title, v.authors, " &
                    "       p.penalty_reason, t.return_condition, p.penalty_amount, p.penalty_status, t.due_date " &
                    "FROM Penalty p " &
                    "JOIN BorrowTransaction t ON t.transaction_id = p.transaction_id " &
                    "JOIN Members m ON m.member_id = t.member_id " &
                    "JOIN Users u ON u.user_id = m.user_id " &
                    "JOIN BookCopies c ON c.copy_id = t.copy_id " &
                    "JOIN vw_BookCatalog v ON v.book_id = c.book_id " &
                    "WHERE (@kw = '' OR u.username LIKE CONCAT('%',@kw,'%')) " &
                    "AND (@useDates = 0 OR DATE(t.due_date) BETWEEN @df AND @dt) " &
                    "ORDER BY p.transaction_id DESC", conn)
                    cmd.Parameters.AddWithValue("@kw", kw)
                    cmd.Parameters.AddWithValue("@useDates", If(dateFilterOn, 1, 0))
                    cmd.Parameters.AddWithValue("@df", If(dateFilterOn, filterFrom, New Date(1900, 1, 1)))
                    cmd.Parameters.AddWithValue("@dt", If(dateFilterOn, filterTo, New Date(9999, 12, 31)))
                    Using r As MySqlDataReader = cmd.ExecuteReader()
                        While r.Read()
                            Dim row As DataGridViewRow = DataGridView1.Rows(DataGridView1.Rows.Add())
                            row.Cells("Username").Value = r("username").ToString()
                            row.Cells("ReceiptNo").Value = If(IsDBNull(r("receipt_number")), "N/A", r("receipt_number").ToString())
                            row.Cells("BookID").Value = r("book_id").ToString()
                            row.Cells("ISBN").Value = r("isbn").ToString()
                            row.Cells("BookTitle").Value = r("title").ToString()
                            row.Cells("BookAuthor").Value = If(IsDBNull(r("authors")), "", r("authors").ToString())
                            row.Cells("Reason").Value = r("penalty_reason").ToString().Replace(",", " + ")
                            row.Cells("BookCondition").Value = If(IsDBNull(r("return_condition")), "Pending", r("return_condition").ToString())
                            row.Cells("Amount").Value = ChrW(&H20B1) & Convert.ToDecimal(r("penalty_amount")).ToString("N2")
                            row.Cells("PenaltyStatus").Value = r("penalty_status").ToString()
                            row.Cells("PenaltyDate").Value = Convert.ToDateTime(r("due_date")).ToString("MM/dd/yyyy")
                            row.Tag = Convert.ToInt32(r("transaction_id"))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not load penalties: " & ex.Message, vbCritical, "Penalty Management")
        End Try
        DataGridView1.ClearSelection()
        pager.Apply()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If ready Then RefreshPenaltyData(txtSearch.Text)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        selectedTransactionId = Convert.ToInt32(row.Tag)
        Dim receipt As String = Convert.ToString(row.Cells("ReceiptNo").Value)
        txtUserID.Text = If(receipt = "N/A", "", receipt)
        ComboBox1.Text = Convert.ToString(row.Cells("BookCondition").Value)
        ComboBox3.Text = Convert.ToString(row.Cells("PenaltyStatus").Value)
        UpdateBorrowStatusPreview()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        UpdateBorrowStatusPreview()
    End Sub

    Private Sub UpdateBorrowStatusPreview()
        Select Case ComboBox1.Text
            Case "Good" : ComboBox2.Text = "Returned"
            Case "Damaged", "Lost" : ComboBox2.Text = "Penalty"
            Case Else : ComboBox2.Text = "Pending"
        End Select
    End Sub

    Private Sub txtUserID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUserID.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If txtUserID.Text.Length >= 6 AndAlso Not Char.IsControl(e.KeyChar) Then e.Handled = True
    End Sub

    ' ------------------------------------------------------------ update penalty
    ' "Update Penalty" button = save condition, penalty status and receipt number
    Private Sub btnMarkAsPaid_Click(sender As Object, e As EventArgs) Handles btnMarkAsPaid.Click
        If selectedTransactionId = 0 Then
            MsgBox("Select a penalty record from the list first.", vbExclamation, "Update Penalty")
            Exit Sub
        End If
        If ComboBox3.Text <> "None" AndAlso ComboBox3.Text <> "Unpaid" AndAlso ComboBox3.Text <> "Paid" Then
            MsgBox("Please select a valid Penalty Status (None, Unpaid, or Paid).", vbExclamation, "Update Penalty")
            Exit Sub
        End If

        ' A penalty can only be marked Paid when a receipt number is provided.
        If ComboBox3.Text = "Paid" Then
            Dim receipt As String = txtUserID.Text.Trim()
            If receipt = "" Then
                MsgBox("A Receipt No. is required to mark this penalty as Paid.", vbExclamation, "Update Penalty")
                txtUserID.Focus()
                Exit Sub
            End If
            If receipt.Length <> 6 OrElse Not receipt.All(AddressOf Char.IsDigit) Then
                MsgBox("Receipt No. must be exactly 6 digits.", vbExclamation, "Update Penalty")
                txtUserID.Focus()
                Exit Sub
            End If
        End If

        If Not UiHelpers.Confirm("update", "this penalty record", "Update Penalty") Then Exit Sub

        Try
            Dim total As Decimal = BorrowData.ApplyVerification(selectedTransactionId, ComboBox1.Text, ComboBox3.Text, txtUserID.Text.Trim())
            DBConnection.LogActivity("Update Penalty",
                "Updated transaction #" & selectedTransactionId & " - condition " & ComboBox1.Text &
                ", amount " & ChrW(&H20B1) & total.ToString("N2") & ", status " & If(total = 0, "None", ComboBox3.Text))
            MsgBox("Penalty record updated successfully.", vbInformation, "Update Penalty")
        Catch ex As InvalidOperationException
            MsgBox(ex.Message, vbExclamation, "Update Penalty")
            Exit Sub
        Catch ex As Exception
            MsgBox("Could not update the penalty: " & ex.Message, vbCritical, "Update Penalty")
            Exit Sub
        End Try
        ClearPanel()
        RefreshPenaltyData(txtSearch.Text)
    End Sub

    Private Sub btnMarkAsNotPaid_Click(sender As Object, e As EventArgs) Handles btnMarkAsNotPaid.Click
        ClearPanel()
    End Sub

    Private Sub ClearPanel()
        selectedTransactionId = 0
        txtUserID.Clear()
        ComboBox1.SelectedIndex = -1 : ComboBox1.Text = ""
        ComboBox2.SelectedIndex = -1 : ComboBox2.Text = ""
        ComboBox3.SelectedIndex = -1 : ComboBox3.Text = ""
        DataGridView1.ClearSelection()
    End Sub
End Class