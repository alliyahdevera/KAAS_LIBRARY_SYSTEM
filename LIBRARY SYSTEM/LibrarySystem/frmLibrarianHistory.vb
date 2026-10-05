Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmLibrarianHistory

    ' Extra per-row data the ListView can't hold directly — needed to
    ' automatically recompute the overdue penalty when a record is verified.
    Private Class RecordInfo
        Public Property TransactionId As Integer
        Public Property DueDate As DateTime
        Public Property ReturnDate As DateTime?
        Public Property BookPrice As Decimal
    End Class

    Private Sub frmLibrarianHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        ComboBox2.Enabled = False ' Borrow Status is derived from Book Condition, never typed directly
        RefreshHistory()
    End Sub

    Public Sub RefreshHistory()
        lstBorrowed.Items.Clear()

        Using conn = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New MySqlCommand(
                "SELECT t.transaction_id, a.username, a.account_type, " &
                "b.isbn, b.title, b.author, b.price, " &
                "t.borrow_date, t.due_date, t.return_date, " &
                "t.condition_status, t.penalty_amount, t.penalty_status " &
                "FROM tbl_transaction t " &
                "JOIN tbl_account a ON a.account_id = t.account_id " &
                "JOIN tbl_book b ON b.book_id = t.book_id " &
                "ORDER BY t.borrow_date DESC", conn)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim dueDate As DateTime = Convert.ToDateTime(reader("due_date"))
                    Dim isReturned As Boolean = Not IsDBNull(reader("return_date"))
                    Dim returnDate As DateTime? = If(isReturned, CType(Convert.ToDateTime(reader("return_date")), DateTime?), Nothing)

                    Dim conditionStatus As String = reader("condition_status").ToString()
                    If String.IsNullOrWhiteSpace(conditionStatus) Then conditionStatus = "Pending"

                    ' Borrow status is fully automatic — it just reflects where the
                    ' record sits in the borrow/return/verify flow.
                    Dim borrowStatusText As String
                    If Not isReturned Then
                        borrowStatusText = "Borrowed"
                    ElseIf conditionStatus = "Pending" Then
                        borrowStatusText = "Pending"
                    ElseIf conditionStatus = "Good" Then
                        borrowStatusText = "Returned"
                    Else ' Damaged or Lost
                        borrowStatusText = "Penalty"
                    End If

                    Dim penaltyAmt As Decimal = Convert.ToDecimal(reader("penalty_amount"))
                    Dim penaltyText As String = If(penaltyAmt > 0,
                        "₱" & penaltyAmt.ToString("N2") & " (" & reader("penalty_status").ToString() & ")",
                        "None")

                    Dim item As New ListViewItem(reader("username").ToString())
                    item.SubItems.Add(reader("account_type").ToString())     ' Type
                    item.SubItems.Add(borrowStatusText)                     ' Borrow Status
                    item.SubItems.Add(reader("isbn").ToString())            ' Book_ISBN
                    item.SubItems.Add(reader("title").ToString())           ' Book_title
                    item.SubItems.Add(reader("author").ToString())          ' Author
                    item.SubItems.Add(Convert.ToDateTime(reader("borrow_date")).ToString("MM/dd/yyyy"))
                    item.SubItems.Add(dueDate.ToString("MM/dd/yyyy"))
                    item.SubItems.Add(If(isReturned, returnDate.Value.ToString("MM/dd/yyyy"), ""))
                    item.SubItems.Add(conditionStatus)                      ' Book Condition
                    item.SubItems.Add(penaltyText)                          ' Penalty

                    item.Tag = New RecordInfo With {
                        .TransactionId = Convert.ToInt32(reader("transaction_id")),
                        .DueDate = dueDate,
                        .ReturnDate = returnDate,
                        .BookPrice = Convert.ToDecimal(reader("price"))
                    }

                    lstBorrowed.Items.Add(item)
                End While
            End Using
        End Using
    End Sub

    Private Sub lstBorrowed_SelectedIndexChanged(sender As Object, e As EventArgs)
        If lstBorrowed.SelectedItems.Count = 0 Then Exit Sub
        Dim selected As ListViewItem = lstBorrowed.SelectedItems(0)

        ComboBox1.Text = selected.SubItems(9).Text ' Book Condition
        ComboBox2.Text = selected.SubItems(2).Text ' Borrow Status (display only)
    End Sub

    ' Live preview: as soon as the librarian picks a condition, show what the
    ' Borrow Status will become. This box stays disabled — it's informational.
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.Text
            Case "Good"
                ComboBox2.Text = "Returned"
            Case "Damaged", "Lost"
                ComboBox2.Text = "Penalty"
            Case Else
                ComboBox2.Text = "Pending"
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If lstBorrowed.SelectedItems.Count = 0 Then
            MsgBox("Select a record from the list first.", vbExclamation, "Verify Record")
            Exit Sub
        End If

        Dim selected As ListViewItem = lstBorrowed.SelectedItems(0)
        Dim info As RecordInfo = CType(selected.Tag, RecordInfo)

        If info.ReturnDate Is Nothing Then
            MsgBox("This book hasn't been returned yet — there's nothing to verify.", vbExclamation, "Verify Record")
            Exit Sub
        End If

        If ComboBox1.Text <> "Good" AndAlso ComboBox1.Text <> "Damaged" AndAlso ComboBox1.Text <> "Lost" Then
            MsgBox("Please select the book's actual condition (Good, Damaged, or Lost).", vbExclamation, "Verify Record")
            Exit Sub
        End If

        Dim newCondition As String = ComboBox1.Text

        ' Overdue is calculated automatically from the dates — never entered manually.
        Dim overdueDays As Integer = Math.Max(0, CInt((info.ReturnDate.Value - info.DueDate).TotalDays))
        Dim overduePenalty As Decimal = overdueDays * DBConnection.PenaltyRatePerDay
        Dim conditionPenalty As Decimal = If(newCondition = "Damaged" OrElse newCondition = "Lost", info.BookPrice, 0D)
        Dim totalPenalty As Decimal = overduePenalty + conditionPenalty
        Dim penaltyStatus As String = If(totalPenalty > 0, "Unpaid", "None")

        Using conn = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New MySqlCommand(
                "UPDATE tbl_transaction SET condition_status=@cs, penalty_amount=@pa, penalty_status=@ps " &
                "WHERE transaction_id=@tid", conn)
            cmd.Parameters.AddWithValue("@cs", newCondition)
            cmd.Parameters.AddWithValue("@pa", totalPenalty)
            cmd.Parameters.AddWithValue("@ps", penaltyStatus)
            cmd.Parameters.AddWithValue("@tid", info.TransactionId)
            cmd.ExecuteNonQuery()
        End Using

        DBConnection.LogActivity("Verify Record",
            $"Verified transaction #{info.TransactionId} as {newCondition}" &
            If(totalPenalty > 0, $" — penalty ₱{totalPenalty:N2}", " — no penalty"))

        MsgBox("Record updated.", vbInformation, "Verify Record")
        ClearPanel()
        RefreshHistory()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ClearPanel()
    End Sub

    Private Sub ClearPanel()
        ComboBox1.SelectedIndex = -1
        ComboBox1.Text = ""
        ComboBox2.SelectedIndex = -1
        ComboBox2.Text = ""
        lstBorrowed.SelectedIndices.Clear()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) 
        frmLibrarianMenu.Show()
        Me.Hide()
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        If lstBorrowed.Items.Count = 0 Then
            MsgBox("No borrow records available to export.", vbExclamation, "Export Failed")
            Exit Sub
        End If

        Using sfd As New SaveFileDialog()
            sfd.Filter = "CSV File (*.csv)|*.csv"
            sfd.FileName = $"All_Borrow_Records_{DateTime.Now:yyyyMMdd_HHmmss}.csv"

            If sfd.ShowDialog() = DialogResult.OK Then
                Try
                    Using sw As New StreamWriter(sfd.FileName, False, System.Text.Encoding.UTF8)
                        Dim headers As New List(Of String)
                        For Each col As ColumnHeader In lstBorrowed.Columns
                            headers.Add($"""{col.Text}""")
                        Next
                        sw.WriteLine(String.Join(",", headers))

                        For Each item As ListViewItem In lstBorrowed.Items
                            Dim rowValues As New List(Of String)
                            For Each subItem As ListViewItem.ListViewSubItem In item.SubItems
                                rowValues.Add($"""{subItem.Text.Replace("""", """""")}""")
                            Next
                            sw.WriteLine(String.Join(",", rowValues))
                        Next
                    End Using

                    MsgBox("Records exported successfully!", vbInformation, "Export Complete")
                Catch ex As Exception
                    MsgBox("An error occurred while exporting: " & ex.Message, vbCritical, "Export Error")
                End Try
            End If
        End Using
    End Sub
    Private Sub frmLibrarianHistory_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            ClearPanel()
            RefreshHistory()
        End If
    End Sub
End Class