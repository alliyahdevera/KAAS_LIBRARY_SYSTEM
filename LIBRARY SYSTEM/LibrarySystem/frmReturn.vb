Imports MySql.Data.MySqlClient

Public Class frmReturn

    Private Class RowInfo
        Public Property TransactionId As Integer
        Public Property BorrowDate As DateTime
    End Class

    Private Sub frmReturn_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            LoadBorrowedBooks()
        End If
    End Sub

    Public Sub LoadBorrowedBooks()
        dgvBorrowedBooks.Rows.Clear()

        Using conn = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New MySqlCommand(
                "SELECT t.transaction_id, b.isbn, b.title, b.author, b.publisher, b.category, b.year_published, " &
                "t.borrow_date, t.due_date " &
                "FROM tbl_transaction t JOIN tbl_book b ON b.book_id = t.book_id " &
                "WHERE t.account_id = @aid AND t.return_date IS NULL", conn)
            cmd.Parameters.AddWithValue("@aid", Form1.CurrentAccountId)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim borrowDate As DateTime = Convert.ToDateTime(reader("borrow_date"))
                    Dim dueDate As DateTime = Convert.ToDateTime(reader("due_date"))

                    Dim rowIndex As Integer = dgvBorrowedBooks.Rows.Add(
                        False,
                        reader("isbn").ToString(),
                        reader("title").ToString(),
                        reader("author").ToString(),
                        reader("publisher").ToString(),
                        reader("category").ToString(),
                        reader("year_published").ToString(),
                        borrowDate.ToString("MM/dd/yyyy"),
                        dueDate.ToString("MM/dd/yyyy")
                    )

                    dgvBorrowedBooks.Rows(rowIndex).Tag = New RowInfo With {
                        .TransactionId = Convert.ToInt32(reader("transaction_id")),
                        .BorrowDate = borrowDate
                    }
                End While
            End Using
        End Using

        UpdateSelectedCount()
        UpdateBorrowDateDisplay()
    End Sub

    Private Sub dgvBorrowedBooks_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBorrowedBooks.CellContentClick
        If e.RowIndex < 0 Then Exit Sub
        If dgvBorrowedBooks.Columns(e.ColumnIndex).Name <> "colSelect" Then Exit Sub
        dgvBorrowedBooks.EndEdit()

        Dim checkedCount As Integer = CountChecked()
        If checkedCount > 3 Then
            dgvBorrowedBooks.Rows(e.RowIndex).Cells("colSelect").Value = False
            MsgBox("You can only select a maximum of 3 books.", vbExclamation, "Return Book")
        End If

        UpdateSelectedCount()
        UpdateBorrowDateDisplay()
    End Sub

    Private Function CountChecked() As Integer
        Dim count As Integer = 0
        For Each row As DataGridViewRow In dgvBorrowedBooks.Rows
            If row.Cells("colSelect").Value IsNot Nothing AndAlso Convert.ToBoolean(row.Cells("colSelect").Value) Then
                count += 1
            End If
        Next
        Return count
    End Function

    Private Sub UpdateSelectedCount()
        lblSelectedCount.Text = $"{CountChecked()}/3"
    End Sub

    Private Sub UpdateBorrowDateDisplay()
        Dim checkedRows As New List(Of DataGridViewRow)
        For Each row As DataGridViewRow In dgvBorrowedBooks.Rows
            If row.Cells("colSelect").Value IsNot Nothing AndAlso Convert.ToBoolean(row.Cells("colSelect").Value) Then
                checkedRows.Add(row)
            End If
        Next

        Select Case checkedRows.Count
            Case 0
                lbldate.Text = "-"
            Case 1
                Dim info As RowInfo = CType(checkedRows(0).Tag, RowInfo)
                lbldate.Text = info.BorrowDate.ToString("MM/dd/yyyy")
            Case Else
                lbldate.Font = New Font(lbldate.Font.FontFamily, 14.0F, lbldate.Font.Style)
                lbldate.Text = "Multiple Borrow Dates"
        End Select
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Dim returnDate As DateTime = DateTime.Now.Date
        Dim anyReturned As Boolean = False

        Using conn = DBConnection.GetConnection()
            conn.Open()

            For Each row As DataGridViewRow In dgvBorrowedBooks.Rows
                If row.Cells("colSelect").Value Is Nothing OrElse Not Convert.ToBoolean(row.Cells("colSelect").Value) Then
                    Continue For
                End If

                Dim info As RowInfo = CType(row.Tag, RowInfo)
                Dim transactionId As Integer = info.TransactionId

                ' Condition is no longer self-reported by the student. It always comes
                ' back as Pending — the librarian inspects the physical book afterward
                ' and updates it to Good / Damaged / Lost.
                Dim conditionValue As String = "Pending"

                Dim dueCmd As New MySqlCommand("SELECT due_date FROM tbl_transaction WHERE transaction_id=@tid", conn)
                dueCmd.Parameters.AddWithValue("@tid", transactionId)
                Dim dueDate As DateTime = Convert.ToDateTime(dueCmd.ExecuteScalar())
                Dim overdueDays As Integer = Math.Max(0, CInt((returnDate - dueDate).TotalDays))

                ' Only the overdue portion is known at return time. Any damaged/lost
                ' penalty gets added on top of this once the librarian verifies the
                ' condition (see Step 4 below if you want that librarian-side piece too).
                Dim penaltyAmount As Decimal = overdueDays * DBConnection.PenaltyRatePerDay
                Dim penaltyStatus As String = If(penaltyAmount > 0, "Unpaid", "None")

                Dim updCmd As New MySqlCommand(
                    "UPDATE tbl_transaction SET return_date=@rd, condition_status=@cs, " &
                    "penalty_amount=@pa, penalty_status=@ps " &
                    "WHERE transaction_id=@tid", conn)
                updCmd.Parameters.AddWithValue("@rd", returnDate)
                updCmd.Parameters.AddWithValue("@cs", conditionValue)
                updCmd.Parameters.AddWithValue("@pa", penaltyAmount)
                updCmd.Parameters.AddWithValue("@ps", penaltyStatus)
                updCmd.Parameters.AddWithValue("@tid", transactionId)
                updCmd.ExecuteNonQuery()

                anyReturned = True
            Next
        End Using

        If anyReturned Then
            MsgBox("Selected book(s) returned successfully!", vbInformation, "Return Book")
            LoadBorrowedBooks()
        Else
            MsgBox("Please select at least one book to return.", vbExclamation, "Return Book")
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If CountChecked() = 0 Then Exit Sub

        Dim confirm As MsgBoxResult = MsgBox(
            "Are you sure you want to unselect all checked books?",
            vbQuestion + vbYesNo, "Clear Selection")

        If confirm <> vbYes Then Exit Sub

        For Each row As DataGridViewRow In dgvBorrowedBooks.Rows
            row.Cells("colSelect").Value = False
        Next
        UpdateSelectedCount()
        UpdateBorrowDateDisplay()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) 
        frmStudentMenu.Show()
        Me.Hide()
    End Sub

    Private Sub frmReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblReturn.Text = DateTime.Now.Date.ToString("MM/dd/yyyy")
    End Sub
End Class