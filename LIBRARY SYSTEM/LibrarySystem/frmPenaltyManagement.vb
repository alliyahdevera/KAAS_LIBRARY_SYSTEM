Imports MySql.Data.MySqlClient

Public Class frmPenaltyManagement
    Private selectedTransactionId As Integer = 0

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
        RefreshPenaltyData()
    End Sub

    Private Sub frmPenaltyManagement_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        UiHelpers.FillHeader(Me)
        If Me.Visible Then RefreshPenaltyData(txtSearch.Text)
    End Sub

    Public Sub RefreshPenaltyData(Optional keyword As String = "")
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
                    "WHERE (@kw = '' OR u.username LIKE CONCAT('%',@kw,'%') OR v.title LIKE CONCAT('%',@kw,'%') " &
                    "   OR v.isbn LIKE CONCAT('%',@kw,'%') OR p.receipt_number LIKE CONCAT('%',@kw,'%') " &
                    "   OR p.penalty_status LIKE CONCAT('%',@kw,'%')) " &
                    "ORDER BY p.transaction_id DESC", conn)
                    cmd.Parameters.AddWithValue("@kw", kw)
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
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        RefreshPenaltyData(txtSearch.Text)
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

    ' "Mark as Paid" button = save condition, penalty status and receipt number
    Private Sub btnMarkAsPaid_Click(sender As Object, e As EventArgs) Handles btnMarkAsPaid.Click
        If selectedTransactionId = 0 Then
            MsgBox("Select a penalty record from the list first.", vbExclamation, "Update Penalty")
            Exit Sub
        End If
        If ComboBox3.Text <> "None" AndAlso ComboBox3.Text <> "Unpaid" AndAlso ComboBox3.Text <> "Paid" Then
            MsgBox("Please select a valid Penalty Status (None, Unpaid, or Paid).", vbExclamation, "Update Penalty")
            Exit Sub
        End If

        Try
            Dim total As Decimal = BorrowData.ApplyVerification(selectedTransactionId, ComboBox1.Text, ComboBox3.Text, txtUserID.Text)
            DBConnection.LogActivity("Update Penalty",
                "Updated transaction #" & selectedTransactionId & " - condition " & ComboBox1.Text &
                ", amount " & ChrW(&H20B1) & total.ToString("N2") & ", status " & If(total = 0, "None", ComboBox3.Text))
            MsgBox("Penalty record updated.", vbInformation, "Update Penalty")
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