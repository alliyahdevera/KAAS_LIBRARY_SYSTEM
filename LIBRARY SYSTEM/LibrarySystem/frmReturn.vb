Imports MySql.Data.MySqlClient

Public Class frmReturn

    Private Class RowInfo
        Public Property TransactionId As Integer
        Public Property BorrowDate As Date
    End Class

    Private Sub frmReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UiHelpers.FillHeader(Me)
        SetupGrid()
        lblReturn.Text = Date.Today.ToString("MM/dd/yyyy")
        LoadBorrowedBooks()
    End Sub

    Private Sub frmReturn_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            lblReturn.Text = Date.Today.ToString("MM/dd/yyyy")
            LoadBorrowedBooks()
        End If
    End Sub

    Private Sub SetupGrid()
        With dgvBorrowedBooks
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = False
            For Each c As DataGridViewColumn In .Columns
                c.ReadOnly = (c.Name <> "colSelect")
            Next
            ' The condition is decided by the librarian after the return, not by the student
            If .Columns.Contains("colCondition") Then .Columns("colCondition").Visible = False
        End With
    End Sub

    Private Sub dgvBorrowedBooks_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvBorrowedBooks.DataError
        e.ThrowException = False
    End Sub

    Public Sub LoadBorrowedBooks()
        dgvBorrowedBooks.Rows.Clear()
        If Not AppSession.MemberId.HasValue Then Exit Sub

        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT t.transaction_id, v.isbn, v.title, v.authors, v.publisher_name, v.categories, v.year_published, " &
                    "       t.borrow_date, t.due_date " &
                    "FROM BorrowTransaction t " &
                    "JOIN BookCopies c ON c.copy_id = t.copy_id " &
                    "JOIN vw_BookCatalog v ON v.book_id = c.book_id " &
                    "WHERE t.member_id = @m AND t.transaction_status = 'Borrowed' ORDER BY t.due_date", conn)
                    cmd.Parameters.AddWithValue("@m", AppSession.MemberId.Value)
                    Using r As MySqlDataReader = cmd.ExecuteReader()
                        While r.Read()
                            Dim borrowDate As Date = Convert.ToDateTime(r("borrow_date")).Date
                            Dim dueDate As Date = Convert.ToDateTime(r("due_date")).Date
                            Dim row As DataGridViewRow = dgvBorrowedBooks.Rows(dgvBorrowedBooks.Rows.Add())
                            row.Cells("colSelect").Value = False
                            row.Cells("colIsbn").Value = r("isbn").ToString()
                            row.Cells("colTitle").Value = r("title").ToString()
                            row.Cells("colAuthor").Value = If(IsDBNull(r("authors")), "", r("authors").ToString())
                            row.Cells("colPublisher").Value = If(IsDBNull(r("publisher_name")), "", r("publisher_name").ToString())
                            row.Cells("colCategory").Value = If(IsDBNull(r("categories")), "", r("categories").ToString())
                            row.Cells("colYear").Value = If(IsDBNull(r("year_published")), "", r("year_published").ToString())
                            row.Cells("colBorrowDate").Value = borrowDate.ToString("MM/dd/yyyy")
                            row.Cells("colDueDate").Value = dueDate.ToString("MM/dd/yyyy")
                            If dueDate < Date.Today Then row.Cells("colDueDate").Style.ForeColor = Color.Firebrick
                            row.Tag = New RowInfo With {.TransactionId = Convert.ToInt32(r("transaction_id")), .BorrowDate = borrowDate}
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not load your borrowed books: " & ex.Message, vbCritical, "Return Books")
        End Try
        dgvBorrowedBooks.ClearSelection()
        UpdateSelectedCount()
        UpdateBorrowDateDisplay()
    End Sub

    Private Function CheckedRows() As List(Of DataGridViewRow)
        Dim list As New List(Of DataGridViewRow)
        For Each row As DataGridViewRow In dgvBorrowedBooks.Rows
            If Convert.ToBoolean(row.Cells("colSelect").Value) Then list.Add(row)
        Next
        Return list
    End Function

    Private Sub dgvBorrowedBooks_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBorrowedBooks.CellContentClick
        If e.RowIndex < 0 OrElse dgvBorrowedBooks.Columns(e.ColumnIndex).Name <> "colSelect" Then Exit Sub
        dgvBorrowedBooks.EndEdit()
        UpdateSelectedCount()
        UpdateBorrowDateDisplay()
    End Sub

    Private Sub UpdateSelectedCount()
        lblSelectedCount.Text = CheckedRows().Count & "/" & dgvBorrowedBooks.Rows.Count
    End Sub

    Private Sub UpdateBorrowDateDisplay()
        Dim checked = CheckedRows()
        Select Case checked.Count
            Case 0
                lbldate.Text = "-"
            Case 1
                lbldate.Text = CType(checked(0).Tag, RowInfo).BorrowDate.ToString("MM/dd/yyyy")
            Case Else
                lbldate.Text = "Multiple Borrow Dates"
        End Select
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Dim ids As New List(Of Integer)
        For Each row In CheckedRows()
            ids.Add(CType(row.Tag, RowInfo).TransactionId)
        Next
        If ids.Count = 0 Then
            MsgBox("Please select at least one book to return.", vbExclamation, "Return Books")
            Exit Sub
        End If

        Try
            Dim outcome = BorrowData.ReturnBooks(ids)
            DBConnection.LogActivity("Return", AppSession.Username & " returned " & outcome.Returned & " book(s).")
            Dim msg As String = "Selected book(s) returned successfully!" & vbCrLf &
                                "The librarian will check the condition of the book(s)."
            If outcome.PenaltyTotal > 0 Then
                msg &= vbCrLf & vbCrLf & "Late return penalty: " & ChrW(&H20B1) & outcome.PenaltyTotal.ToString("N2") &
                       vbCrLf & "See 'My Penalties' for details."
            End If
            MsgBox(msg, vbInformation, "Return Books")
        Catch ex As Exception
            MsgBox("Returning failed: " & ex.Message, vbCritical, "Return Books")
        End Try
        LoadBorrowedBooks()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If CheckedRows().Count = 0 Then Exit Sub
        If MsgBox("Are you sure you want to unselect all checked books?", vbQuestion + vbYesNo, "Clear Selection") <> vbYes Then Exit Sub
        For Each row As DataGridViewRow In dgvBorrowedBooks.Rows
            row.Cells("colSelect").Value = False
        Next
        UpdateSelectedCount()
        UpdateBorrowDateDisplay()
    End Sub
End Class