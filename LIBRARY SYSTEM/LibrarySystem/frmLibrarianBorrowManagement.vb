Imports MySql.Data.MySqlClient

Public Class frmLibrarianBorrowManagement

    Private pager As GridPager
    Private useDateRange As Boolean = False      ' CHANGED: return-date filter on/off

    Private Sub frmLibrarianHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UiHelpers.FillHeader(Me)
        With DataGridView1
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        ComboBox2.Enabled = False
        RefreshHistory()
    End Sub

    Private Sub frmLibrarianHistory_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        UiHelpers.FillHeader(Me)
        If Me.Visible Then
            useDateRange = False                                            ' CHANGED
            DateTimePicker1.Value = New Date(Date.Today.Year, Date.Today.Month, 1)
            DateTimePicker2.Value = Date.Today
            ClearPanel()
            RefreshHistory(txtSearch.Text)
        End If
    End Sub

    Public Sub RefreshHistory(Optional keyword As String = "")
        If pager Is Nothing Then pager = PagerHelper.Create(DataGridView1)
        DataGridView1.Rows.Clear()
        Dim kw As String = If(keyword, "").Trim()

        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT t.transaction_id, u.username, m.member_type, " & BorrowData.StatusSql & " AS status, " &
                    "       v.isbn, v.title, v.authors, t.borrow_date, t.due_date, t.return_date, t.return_condition, " &
                    "       p.penalty_amount, p.penalty_status " &
                    "FROM BorrowTransaction t " &
                    "JOIN Members m ON m.member_id = t.member_id " &
                    "JOIN Users u ON u.user_id = m.user_id " &
                    "JOIN BookCopies c ON c.copy_id = t.copy_id " &
                    "JOIN vw_BookCatalog v ON v.book_id = c.book_id " &
                    "LEFT JOIN Penalty p ON p.transaction_id = t.transaction_id " &
                    "WHERE (@kw = '' OR u.username LIKE CONCAT('%',@kw,'%') OR v.isbn LIKE CONCAT('%',@kw,'%') " &
                    "   OR v.title LIKE CONCAT('%',@kw,'%') OR v.authors LIKE CONCAT('%',@kw,'%') " &
                    "   OR m.member_type LIKE CONCAT('%',@kw,'%') OR (" & BorrowData.StatusSql & ") LIKE CONCAT('%',@kw,'%')) " &
                    "AND (@useDates = 0 OR t.return_date BETWEEN @f AND @t) " &      ' CHANGED: RETURN DATE based
                    "ORDER BY t.borrow_date DESC, t.transaction_id DESC", conn)
                    cmd.Parameters.AddWithValue("@kw", kw)
                    cmd.Parameters.AddWithValue("@useDates", If(useDateRange, 1, 0))
                    cmd.Parameters.AddWithValue("@f", DateTimePicker1.Value.Date)
                    cmd.Parameters.AddWithValue("@t", DateTimePicker2.Value.Date)
                    Using r As MySqlDataReader = cmd.ExecuteReader()
                        While r.Read()
                            Dim isReturned As Boolean = Not IsDBNull(r("return_date"))
                            Dim cond As String = If(IsDBNull(r("return_condition")), If(isReturned, "Pending", "-"), r("return_condition").ToString())
                            Dim penaltyText As String = "None"
                            If Not IsDBNull(r("penalty_amount")) Then
                                penaltyText = ChrW(&H20B1) & Convert.ToDecimal(r("penalty_amount")).ToString("N2") & " (" & r("penalty_status").ToString() & ")"
                            End If

                            Dim row As DataGridViewRow = DataGridView1.Rows(DataGridView1.Rows.Add())
                            row.Cells("Username").Value = r("username").ToString()
                            row.Cells("Type").Value = r("member_type").ToString()
                            row.Cells("BorrowStatus").Value = r("status").ToString()
                            row.Cells("ISBN").Value = r("isbn").ToString()
                            row.Cells("BookTitle").Value = r("title").ToString()
                            row.Cells("BookAuthor").Value = If(IsDBNull(r("authors")), "", r("authors").ToString())
                            row.Cells("BorrowDate").Value = Convert.ToDateTime(r("borrow_date")).ToString("MM/dd/yyyy")
                            row.Cells("DueDate").Value = Convert.ToDateTime(r("due_date")).ToString("MM/dd/yyyy")
                            row.Cells("ReturnDate").Value = If(isReturned, Convert.ToDateTime(r("return_date")).ToString("MM/dd/yyyy"), "")
                            row.Cells("BookCondition").Value = cond
                            row.Cells("Penalty").Value = penaltyText
                            row.Tag = Convert.ToInt32(r("transaction_id"))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not load records: " & ex.Message, vbCritical, "Borrow Records")
        End Try
        DataGridView1.ClearSelection()
        pager.Apply()
    End Sub

    ' CHANGED: the "Filter Data" button now works
    Private Sub btnloaddata_Click(sender As Object, e As EventArgs) Handles btnloaddata.Click
        If DateTimePicker1.Value.Date > DateTimePicker2.Value.Date Then
            MsgBox("'Return Date From' cannot be later than 'To'.", vbExclamation, "Filter Data")
            Exit Sub
        End If
        useDateRange = True
        RefreshHistory(txtSearch.Text)
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("No records with a return date between " & DateTimePicker1.Value.ToString("MM/dd/yyyy") &
                   " and " & DateTimePicker2.Value.ToString("MM/dd/yyyy") & ".", vbInformation, "Filter Data")
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        RefreshHistory(txtSearch.Text)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        Dim cond As String = Convert.ToString(row.Cells("BookCondition").Value)
        ComboBox1.Text = If(cond = "-", "", cond)
        ComboBox2.Text = Convert.ToString(row.Cells("BorrowStatus").Value)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.Text
            Case "Good" : ComboBox2.Text = "Returned"
            Case "Damaged", "Lost" : ComboBox2.Text = "Penalty"
            Case Else : ComboBox2.Text = "Pending"
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.CurrentRow Is Nothing OrElse DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Select a record from the list first.", vbExclamation, "Verify Record")
            Exit Sub
        End If

        Dim row As DataGridViewRow = DataGridView1.SelectedRows(0)
        If Convert.ToString(row.Cells("ReturnDate").Value) = "" Then
            MsgBox("This book hasn't been returned yet - there's nothing to verify.", vbExclamation, "Verify Record")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(ComboBox1.Text) Then
            MsgBox("Please select a valid return condition (Good, Damaged, or Lost).", vbExclamation, "Verify Record")
            Exit Sub
        End If

        If Not UiHelpers.Confirm("update", "this record condition", "Verify Record") Then Exit Sub

        Dim tid As Integer = Convert.ToInt32(row.Tag)
        Try
            Dim total As Decimal = BorrowData.ApplyVerification(tid, ComboBox1.Text)
            DBConnection.LogActivity("Verify Record",
                "Verified transaction #" & tid & " as " & ComboBox1.Text &
                If(total > 0, " - penalty " & ChrW(&H20B1) & total.ToString("N2"), " - no penalty"))
            MsgBox("Record updated successfully.", vbInformation, "Verify Record")
        Catch ex As InvalidOperationException
            MsgBox(ex.Message, vbExclamation, "Verify Record")
            Exit Sub
        Catch ex As Exception
            MsgBox("Could not update the record: " & ex.Message, vbCritical, "Verify Record")
            Exit Sub
        End Try

        ClearPanel()
        RefreshHistory(txtSearch.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ClearPanel()
        If useDateRange Then               ' CHANGED: Clear also removes the date filter
            useDateRange = False
            RefreshHistory(txtSearch.Text)
        End If
    End Sub

    Private Sub ClearPanel()
        ComboBox1.SelectedIndex = -1
        ComboBox1.Text = ""
        ComboBox2.SelectedIndex = -1
        ComboBox2.Text = ""
        DataGridView1.ClearSelection()
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        BorrowData.ExportGridToCsv(DataGridView1, "All_Borrow_Records")
    End Sub
End Class