Imports MySql.Data.MySqlClient

Public Class frmBorrow

    Private borrowDate As DateTime
    Private dueDate As DateTime

    Private Sub frmBorrow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        borrowDate = DateTime.Now.Date
        dueDate = CalculateDueDate(borrowDate)
        lblBorrowDate.Text = borrowDate.ToString("MM/dd/yyyy")
        lblDueDate.Text = dueDate.ToString("MM/dd/yyyy")

        If Me.Visible Then
            LoadAvailableBooks()
        End If
    End Sub

    ' Standard loan period is 2 days. If that lands on a weekend
    ' (Thursday -> Saturday, or Friday -> Sunday), push the due date
    ' forward to the following Monday since the library is closed weekends.
    Private Function CalculateDueDate(fromDate As DateTime) As DateTime
        Dim result As DateTime = fromDate.AddDays(2)
        Select Case result.DayOfWeek
            Case DayOfWeek.Saturday
                result = result.AddDays(2) ' Sat -> Mon
            Case DayOfWeek.Sunday
                result = result.AddDays(1) ' Sun -> Mon
        End Select
        Return result
    End Function

    Public Sub LoadAvailableBooks()
        dgvAvailableBooks.Rows.Clear()

        Using conn = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New MySqlCommand(
                "SELECT b.isbn, b.title, b.author, b.publisher, b.category, b.edition, b.year_published, " &
                "COUNT(b.book_id) AS copies " &
                "FROM tbl_book b " &
                "WHERE b.book_id NOT IN (SELECT book_id FROM tbl_transaction WHERE return_date IS NULL) " &
                "GROUP BY b.isbn, b.title, b.author, b.publisher, b.category, b.edition, b.year_published " &
                "HAVING copies > 0", conn)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    dgvAvailableBooks.Rows.Add(
                        False,
                        reader("isbn").ToString(),
                        reader("title").ToString(),
                        reader("author").ToString(),
                        reader("publisher").ToString(),
                        reader("category").ToString(),
                        reader("edition").ToString(),
                        reader("year_published").ToString(),
                        reader("copies").ToString()
                    )
                End While
            End Using
        End Using

        UpdateSelectedCount()
    End Sub

    Private Sub dgvAvailableBooks_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAvailableBooks.CellContentClick
        If e.RowIndex < 0 Then Exit Sub
        If dgvAvailableBooks.Columns(e.ColumnIndex).Name <> "colSelect" Then Exit Sub

        dgvAvailableBooks.EndEdit() ' commit the checkbox click immediately

        Dim checkedCount As Integer = CountChecked()
        Dim thisRow = dgvAvailableBooks.Rows(e.RowIndex)
        Dim isChecked As Boolean = Convert.ToBoolean(thisRow.Cells("colSelect").Value)

        If isChecked AndAlso checkedCount > 3 Then
            thisRow.Cells("colSelect").Value = False
            MsgBox("You can only select a maximum of 3 books.", vbExclamation, "Book Borrow")
        End If

        UpdateSelectedCount()
    End Sub

    Private Function CountChecked() As Integer
        Dim count As Integer = 0
        For Each row As DataGridViewRow In dgvAvailableBooks.Rows
            If row.Cells("colSelect").Value IsNot Nothing AndAlso Convert.ToBoolean(row.Cells("colSelect").Value) Then
                count += 1
            End If
        Next
        Return count
    End Function

    Private Sub UpdateSelectedCount()
        lblSelectedCount.Text = $"{CountChecked()}/3"
    End Sub

    Private Sub btnBorrow_Click(sender As Object, e As EventArgs) Handles btnBorrow.Click
        Dim checkedIsbns As New List(Of String)
        For Each row As DataGridViewRow In dgvAvailableBooks.Rows
            If row.Cells("colSelect").Value IsNot Nothing AndAlso Convert.ToBoolean(row.Cells("colSelect").Value) Then
                checkedIsbns.Add(row.Cells("colIsbn").Value.ToString())
            End If
        Next

        If checkedIsbns.Count = 0 Then
            MsgBox("Please select at least one book to borrow.", vbExclamation, "Book Borrow")
            Exit Sub
        End If

        Using conn = DBConnection.GetConnection()
            conn.Open()

            Dim activeCmd As New MySqlCommand(
                "SELECT COUNT(*) FROM tbl_transaction WHERE account_id=@aid AND return_date IS NULL", conn)
            activeCmd.Parameters.AddWithValue("@aid", Form1.CurrentAccountId)
            Dim activeCount As Integer = Convert.ToInt32(activeCmd.ExecuteScalar())

            If activeCount + checkedIsbns.Count > 3 Then
                MsgBox("You can only have a maximum of 3 books borrowed at once.", vbExclamation, "Book Borrow")
                Exit Sub
            End If

            For Each isbn As String In checkedIsbns
                Dim findCmd As New MySqlCommand(
                    "SELECT book_id FROM tbl_book WHERE isbn=@isbn " &
                    "AND book_id NOT IN (SELECT book_id FROM tbl_transaction WHERE return_date IS NULL) LIMIT 1", conn)
                findCmd.Parameters.AddWithValue("@isbn", isbn)
                Dim bookIdObj As Object = findCmd.ExecuteScalar()

                If bookIdObj Is Nothing Then
                    MsgBox($"No available copy left for ISBN {isbn} — it may have just been borrowed by someone else.", vbExclamation, "Book Borrow")
                    Continue For
                End If

                Dim insCmd As New MySqlCommand(
                    "INSERT INTO tbl_transaction (account_id, book_id, borrow_date, due_date, condition_status, penalty_status) " &
                    "VALUES (@aid, @bid, @bd, @dd, 'Good', 'None')", conn)
                insCmd.Parameters.AddWithValue("@aid", Form1.CurrentAccountId)
                insCmd.Parameters.AddWithValue("@bid", Convert.ToInt32(bookIdObj))
                insCmd.Parameters.AddWithValue("@bd", borrowDate)
                insCmd.Parameters.AddWithValue("@dd", dueDate)
                insCmd.ExecuteNonQuery()
            Next
        End Using

        MsgBox("Borrow successful!", vbInformation, "Book Borrow")
        LoadAvailableBooks()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If CountChecked() = 0 Then Exit Sub

        Dim confirm As MsgBoxResult = MsgBox(
            "Are you sure you want to unselect all checked books?",
            vbQuestion + vbYesNo, "Clear Selection")

        If confirm <> vbYes Then Exit Sub

        For Each row As DataGridViewRow In dgvAvailableBooks.Rows
            row.Cells("colSelect").Value = False
        Next
        UpdateSelectedCount()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        frmStudentMenu.Show()
        Me.Hide()
    End Sub


End Class