Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class frmPenaltyManagement

    Private Class RecordInfo
        Public Property TransactionId As Integer
        Public Property DueDate As DateTime
        Public Property ReturnDate As DateTime?
        Public Property BookPrice As Decimal
    End Class

    Private isLoadingRecord As Boolean = False

    Private Sub frmPenaltyManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        ComboBox2.Enabled = False ' Borrow Status is derived from Book Condition, never typed directly
        RefreshPenaltyData()
    End Sub

    ' Default-instance forms only fire Load once per app session. Without this,
    ' re-opening the form via .Show() after a librarian verifies a book elsewhere
    ' (frmLibrarianHistory) would keep showing stale data.
    Private Sub frmPenaltyManagement_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then RefreshPenaltyData()
    End Sub

    Public Sub RefreshPenaltyData()
        Using conn = DBConnection.GetConnection()
            conn.Open()
            LoadPenaltyRecords(conn)
        End Using
    End Sub

    Private Sub LoadPenaltyRecords(conn As MySqlConnection)
        ListViewPenaltyRecords.Items.Clear()

        Dim query As String =
        "SELECT t.transaction_id, t.receipt_number, a.username, t.book_id, b.title, b.price, " &
        "       t.due_date, t.return_date, t.condition_status, " &
        "       t.penalty_amount, t.penalty_status " &
        "FROM tbl_transaction t " &
        "JOIN tbl_account a ON a.account_id = t.account_id " &
        "JOIN tbl_book b ON b.book_id = t.book_id " &
        "WHERE t.penalty_amount > 0 " &
        "ORDER BY t.transaction_id DESC"

        Using cmd As New MySqlCommand(query, conn)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim receiptNo As String = If(IsDBNull(reader("receipt_number")), "N/A", reader("receipt_number").ToString())
                    Dim amount As Decimal = Convert.ToDecimal(reader("penalty_amount"))
                    Dim dueDate As DateTime = Convert.ToDateTime(reader("due_date"))
                    Dim isReturned As Boolean = Not IsDBNull(reader("return_date"))
                    Dim returnDate As DateTime? = If(isReturned, CType(Convert.ToDateTime(reader("return_date")), DateTime?), Nothing)
                    Dim condition As String = reader("condition_status").ToString()

                    ' Reason combines Overdue (dates) with Damaged/Lost (condition) —
                    ' a record can be both at once.
                    Dim isOverdue As Boolean = isReturned AndAlso returnDate.Value > dueDate
                    Dim reasonParts As New List(Of String)
                    If isOverdue Then reasonParts.Add("Overdue")
                    If condition = "Damaged" OrElse condition = "Lost" Then reasonParts.Add("Book Condition")
                    Dim reason As String = If(reasonParts.Count > 0, String.Join(" + ", reasonParts), "Overdue")

                    Dim item As New ListViewItem(receiptNo)
                    item.SubItems.Add(reader("username").ToString())          ' User
                    item.SubItems.Add(reader("book_id").ToString())           ' Book ID
                    item.SubItems.Add(reader("title").ToString())             ' Book Title
                    item.SubItems.Add(reason)                                 ' Reason
                    item.SubItems.Add(condition)                              ' Book Condition
                    item.SubItems.Add(amount.ToString("₱0.00"))               ' Amount
                    item.SubItems.Add(reader("penalty_status").ToString())    ' Status
                    item.SubItems.Add(dueDate.ToString("MM/dd/yyyy"))         ' Penalty Date

                    item.Tag = New RecordInfo With {
                        .TransactionId = Convert.ToInt32(reader("transaction_id")),
                        .DueDate = dueDate,
                        .ReturnDate = returnDate,
                        .BookPrice = Convert.ToDecimal(reader("price"))
                    }

                    ListViewPenaltyRecords.Items.Add(item)
                End While
            End Using
        End Using
    End Sub

    Private Sub ListViewPenaltyRecords_SelectedIndexChanged(sender As Object, e As EventArgs)
        If ListViewPenaltyRecords.SelectedItems.Count = 0 Then Exit Sub
        Dim selected As ListViewItem = ListViewPenaltyRecords.SelectedItems(0)

        isLoadingRecord = True
        txtUserID.Text = If(selected.SubItems(0).Text = "N/A", "", selected.SubItems(0).Text) ' Receipt No.
        ComboBox1.Text = selected.SubItems(5).Text  ' Book Condition
        ComboBox3.Text = selected.SubItems(7).Text  ' Status (Penalty Status)
        isLoadingRecord = False

        UpdateBorrowStatusPreview()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        UpdateBorrowStatusPreview()
    End Sub

    ' Prevents "Paid" from ever being selected unless a valid 6-digit receipt number
    ' is already in txtUserID. Skipped while a row is being loaded from the list,
    ' since that shouldn't trigger a validation popup just from clicking a record.
    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If isLoadingRecord Then Exit Sub

        If ComboBox3.Text = "Paid" Then
            Dim receiptNoCheck As String = txtUserID.Text.Trim()
            If Not Regex.IsMatch(receiptNoCheck, "^\d{6}$") Then
                MsgBox("Enter a valid 6-digit receipt number before marking this record as Paid.", vbExclamation, "Update Penalty")
                ComboBox3.SelectedIndex = -1
                ComboBox3.Text = ""
                Exit Sub
            End If
        End If
    End Sub

    Private Sub UpdateBorrowStatusPreview()
        Select Case ComboBox1.Text
            Case "Good"
                ComboBox2.Text = "Returned"
            Case "Damaged", "Lost"
                ComboBox2.Text = "Penalty"
            Case Else
                ComboBox2.Text = "Pending"
        End Select
    End Sub

    Private Sub btnMarkAsPaid_Click(sender As Object, e As EventArgs) Handles btnMarkAsPaid.Click
        If ListViewPenaltyRecords.SelectedItems.Count = 0 Then
            MsgBox("Select a penalty record from the list first.", vbExclamation, "Update Penalty")
            Exit Sub
        End If

        ' Receipt number must be exactly 6 digits (numbers only) — empty is allowed (not yet paid)
        Dim receiptNoCheck As String = txtUserID.Text.Trim()
        If receiptNoCheck <> "" AndAlso Not Regex.IsMatch(receiptNoCheck, "^\d{6}$") Then
            MsgBox("Receipt number must be exactly 6 digits (numbers only).", vbExclamation, "Update Penalty")
            txtUserID.Focus()
            Exit Sub
        End If

        ' Backstop: Paid status can never be saved without a valid 6-digit receipt number
        If ComboBox3.Text = "Paid" AndAlso Not Regex.IsMatch(receiptNoCheck, "^\d{6}$") Then
            MsgBox("A valid 6-digit receipt number is required before marking this record as Paid.", vbExclamation, "Update Penalty")
            txtUserID.Focus()
            Exit Sub
        End If

        If ComboBox1.Text <> "Good" AndAlso ComboBox1.Text <> "Damaged" AndAlso ComboBox1.Text <> "Lost" Then
            MsgBox("Please select a valid Book Condition (Good, Damaged, or Lost).", vbExclamation, "Update Penalty")
            Exit Sub
        End If

        If ComboBox3.Text <> "None" AndAlso ComboBox3.Text <> "Unpaid" AndAlso ComboBox3.Text <> "Paid" Then
            MsgBox("Please select a valid Penalty Status (None, Unpaid, or Paid).", vbExclamation, "Update Penalty")
            Exit Sub
        End If

        Dim selected As ListViewItem = ListViewPenaltyRecords.SelectedItems(0)
        Dim info As RecordInfo = CType(selected.Tag, RecordInfo)
        Dim newCondition As String = ComboBox1.Text

        ' Overdue is still automatic — recalculated from the stored dates, not typed.
        Dim overdueDays As Integer = If(info.ReturnDate.HasValue, Math.Max(0, CInt((info.ReturnDate.Value - info.DueDate).TotalDays)), 0)
        Dim overduePenalty As Decimal = overdueDays * DBConnection.PenaltyRatePerDay
        Dim conditionPenalty As Decimal = If(newCondition = "Damaged" OrElse newCondition = "Lost", info.BookPrice, 0D)
        Dim totalPenalty As Decimal = overduePenalty + conditionPenalty

        Dim newPenaltyStatus As String = ComboBox3.Text
        If totalPenalty = 0 Then
            newPenaltyStatus = "None" ' nothing owed, status can't say otherwise
        ElseIf newPenaltyStatus = "None" Then
            MsgBox("This record still has an amount due — choose Unpaid or Paid instead of None.", vbExclamation, "Update Penalty")
            Exit Sub
        End If

        Dim receiptNo As String = txtUserID.Text.Trim()

        Using conn = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New MySqlCommand(
                "UPDATE tbl_transaction SET receipt_number=@rn, condition_status=@cs, " &
                "penalty_amount=@pa, penalty_status=@ps WHERE transaction_id=@tid", conn)
            cmd.Parameters.AddWithValue("@rn", If(receiptNo = "", DBNull.Value, receiptNo))
            cmd.Parameters.AddWithValue("@cs", newCondition)
            cmd.Parameters.AddWithValue("@pa", totalPenalty)
            cmd.Parameters.AddWithValue("@ps", newPenaltyStatus)
            cmd.Parameters.AddWithValue("@tid", info.TransactionId)
            cmd.ExecuteNonQuery()
        End Using

        DBConnection.LogActivity("Update Penalty",
            $"Updated transaction #{info.TransactionId} — condition {newCondition}, amount ₱{totalPenalty:N2}, status {newPenaltyStatus}")

        MsgBox("Penalty record updated.", vbInformation, "Update Penalty")
        ClearPanel()
        RefreshPenaltyData()
    End Sub

    Private Sub txtUserID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUserID.KeyPress
        ' Allow control keys (backspace, etc.) and digits only
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
        ' Block further typing once 6 digits are already entered
        If txtUserID.Text.Length >= 6 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnMarkAsNotPaid_Click(sender As Object, e As EventArgs) Handles btnMarkAsNotPaid.Click
        ClearPanel()
    End Sub

    Private Sub ClearPanel()
        txtUserID.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox1.Text = ""
        ComboBox2.SelectedIndex = -1
        ComboBox2.Text = ""
        ComboBox3.SelectedIndex = -1
        ComboBox3.Text = ""
        ListViewPenaltyRecords.SelectedIndices.Clear()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        frmLibrarianMenu.Show()
        Me.Hide()
    End Sub

End Class