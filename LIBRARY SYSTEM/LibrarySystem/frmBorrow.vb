Imports MySql.Data.MySqlClient

Public Class frmBorrow
    Private ReadOnly selectedIsbns As New HashSet(Of String)()
    Private borrowDate As Date
    Private dueDate As Date
    Private allowedNow As Integer = 0

    Private Sub frmBorrow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UiHelpers.FillHeader(Me)
        SetupGrid()
        RefreshPage()
    End Sub

    Private Sub frmBorrow_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then RefreshPage()
    End Sub

    Private Sub SetupGrid()
        With dgvAvailableBooks
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = False
            For Each c As DataGridViewColumn In .Columns
                c.ReadOnly = (c.Name <> "colSelect")
            Next
        End With
    End Sub

    Private Sub RefreshPage()
        If Not AppSession.MemberId.HasValue Then
            MsgBox("Your account is not registered as a borrower. Please contact the librarian.", vbExclamation, "Borrow Books")
            Exit Sub
        End If

        borrowDate = Date.Today
        dueDate = BorrowData.CalcDueDate(borrowDate, AppSession.MemberType)
        lblBorrowDate.Text = borrowDate.ToString("MM/dd/yyyy")
        lblDueDate.Text = dueDate.ToString("MM/dd/yyyy")

        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                allowedNow = Math.Max(0, LibraryRules.MaxActiveLoans(AppSession.MemberType) -
                                         BorrowData.ActiveLoanCount(conn, AppSession.MemberId.Value))
            End Using
        Catch ex As Exception
            MsgBox("Could not check your current loans: " & ex.Message, vbCritical, "Borrow Books")
            Exit Sub
        End Try

        selectedIsbns.Clear()
        LoadAvailableBooks(txtSearch.Text)
    End Sub

    Public Sub LoadAvailableBooks(Optional keyword As String = "")
        dgvAvailableBooks.Rows.Clear()
        Dim kw As String = If(keyword, "").Trim()

        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT isbn, title, authors, publisher_name, categories, edition, year_published, available_copies " &
                    "FROM vw_BookCatalog WHERE available_copies > 0 " &
                    "AND " & BookData.BookSearchSql() & " ORDER BY title", conn)
                    cmd.Parameters.AddWithValue("@kw", kw)
                    Using r As MySqlDataReader = cmd.ExecuteReader()
                        While r.Read()
                            Dim row As DataGridViewRow = dgvAvailableBooks.Rows(dgvAvailableBooks.Rows.Add())
                            Dim isbn As String = r("isbn").ToString()
                            row.Cells("colSelect").Value = selectedIsbns.Contains(isbn)
                            row.Cells("colIsbn").Value = isbn
                            row.Cells("colTitle").Value = r("title").ToString()
                            row.Cells("colAuthor").Value = If(IsDBNull(r("authors")), "", r("authors").ToString())
                            row.Cells("colPublisher").Value = If(IsDBNull(r("publisher_name")), "", r("publisher_name").ToString())
                            row.Cells("colCategory").Value = If(IsDBNull(r("categories")), "", r("categories").ToString())
                            row.Cells("colEdition").Value = If(IsDBNull(r("edition")), "", r("edition").ToString())
                            row.Cells("colYear").Value = If(IsDBNull(r("year_published")), "", r("year_published").ToString())
                            row.Cells("colCopies").Value = r("available_copies").ToString()
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not load books: " & ex.Message, vbCritical, "Borrow Books")
        End Try
        dgvAvailableBooks.ClearSelection()
        UpdateSelectedCount()
    End Sub

    Private Sub dgvAvailableBooks_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAvailableBooks.CellContentClick
        If e.RowIndex < 0 OrElse dgvAvailableBooks.Columns(e.ColumnIndex).Name <> "colSelect" Then Exit Sub
        dgvAvailableBooks.EndEdit()

        Dim row As DataGridViewRow = dgvAvailableBooks.Rows(e.RowIndex)
        Dim isbn As String = Convert.ToString(row.Cells("colIsbn").Value)
        Dim isChecked As Boolean = Convert.ToBoolean(row.Cells("colSelect").Value)

        If isChecked Then
            If selectedIsbns.Count >= allowedNow Then
                row.Cells("colSelect").Value = False
                If allowedNow = 0 Then
                    MsgBox("You already have the maximum number of borrowed books. Please return one first.", vbExclamation, "Borrow Books")
                Else
                    MsgBox("You can only borrow " & allowedNow & " more book(s) right now.", vbExclamation, "Borrow Books")
                End If
            Else
                selectedIsbns.Add(isbn)
            End If
        Else
            selectedIsbns.Remove(isbn)
        End If
        UpdateSelectedCount()
    End Sub

    Private Sub UpdateSelectedCount()
        lblSelectedCount.Text = selectedIsbns.Count & "/" & allowedNow
    End Sub

    Private Sub btnBorrow_Click(sender As Object, e As EventArgs) Handles btnBorrow.Click
        If Not AppSession.MemberId.HasValue Then Exit Sub
        If selectedIsbns.Count = 0 Then
            MsgBox("Please select at least one book to borrow.", vbExclamation, "Borrow Books")
            Exit Sub
        End If

        Try
            Dim outcome = BorrowData.BorrowBooks(AppSession.MemberId.Value, AppSession.MemberType, selectedIsbns.ToList())
            Dim msg As String = ""
            If outcome.Borrowed > 0 Then
                msg = "Borrow successful! " & outcome.Borrowed & " book(s). Due date: " & outcome.DueDate.ToString("MM/dd/yyyy")
                DBConnection.LogActivity("Borrow", AppSession.Username & " borrowed " & outcome.Borrowed & " book(s).")
            End If
            If outcome.Problems.Count > 0 Then
                msg &= If(msg = "", "", vbCrLf & vbCrLf) & String.Join(vbCrLf, outcome.Problems)
            End If
            MsgBox(msg, If(outcome.Borrowed > 0, vbInformation, vbExclamation), "Borrow Books")
        Catch ex As Exception
            MsgBox("Borrowing failed: " & ex.Message, vbCritical, "Borrow Books")
        End Try
        RefreshPage()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If selectedIsbns.Count = 0 Then Exit Sub
        If MsgBox("Are you sure you want to unselect all checked books?", vbQuestion + vbYesNo, "Clear Selection") <> vbYes Then Exit Sub
        selectedIsbns.Clear()
        For Each row As DataGridViewRow In dgvAvailableBooks.Rows
            row.Cells("colSelect").Value = False
        Next
        UpdateSelectedCount()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadAvailableBooks(txtSearch.Text)
    End Sub
End Class