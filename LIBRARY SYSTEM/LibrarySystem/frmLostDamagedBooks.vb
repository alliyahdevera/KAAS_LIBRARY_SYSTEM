Imports MySql.Data.MySqlClient

Public Class frmLostDamagedBooks

    Private useDateRange As Boolean = False
    Private isReady As Boolean = False

    Private Sub frmLostDamagedBooks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboType.SelectedIndex = 0
        isReady = True
    End Sub
    Private Sub OnVisible(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.DesignMode OrElse Not Me.Visible Then Exit Sub
        useDateRange = False
        dtpFrom.Value = New Date(Date.Today.Year, Date.Today.Month, 1)
        dtpTo.Value = Date.Today
        LoadIncidents()
    End Sub

    Private Sub Filter_Changed(sender As Object, e As EventArgs) _
            Handles txtSearch.TextChanged, cboType.SelectedIndexChanged, chkRecovered.CheckedChanged
        If Not isReady Then Exit Sub
        LoadIncidents()
    End Sub

    Private Sub LoadIncidents()
        dgvIncidents.Rows.Clear()
        Dim kw As String = txtSearch.Text.Trim()
        Dim typ As String = If(cboType.Text = "All", "", cboType.Text)
        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT i.incident_id, c.copy_id, c.accession_no, v.isbn, v.title, v.authors, i.incident_type, " &
                    "       i.incident_date, IFNULL(u.username, '-') AS borrower, pn.penalty_amount, pn.penalty_status, " &
                    "       c.copy_status, i.is_resolved, IFNULL(i.remarks, '') AS remarks " &
                    "FROM LostDamagedBooks i " &
                    "JOIN BookCopies c ON c.copy_id = i.copy_id " &
                    "JOIN vw_BookCatalog v ON v.book_id = c.book_id " &
                    "LEFT JOIN Members m ON m.member_id = i.member_id " &
                    "LEFT JOIN Users u ON u.user_id = m.user_id " &
                    "LEFT JOIN Penalty pn ON pn.transaction_id = i.transaction_id " &
                    "WHERE (@kw = '' OR v.isbn LIKE CONCAT('%',@kw,'%') OR v.title LIKE CONCAT('%',@kw,'%') " &
                    "       OR c.accession_no LIKE CONCAT('%',@kw,'%') OR CAST(c.copy_id AS CHAR) = @kw " &
                    "       OR u.username LIKE CONCAT('%',@kw,'%')) " &
                    "AND (@typ = '' OR i.incident_type = @typ) " &
                    "AND (@inclRes = 1 OR i.is_resolved = 0) " &
                    "AND (@useDates = 0 OR i.incident_date BETWEEN @f AND @t) " &
                    "ORDER BY i.incident_date DESC, i.incident_id DESC", conn)
                    cmd.Parameters.AddWithValue("@kw", kw)
                    cmd.Parameters.AddWithValue("@typ", typ)
                    cmd.Parameters.AddWithValue("@inclRes", If(chkRecovered.Checked, 1, 0))
                    cmd.Parameters.AddWithValue("@useDates", If(useDateRange, 1, 0))
                    cmd.Parameters.AddWithValue("@f", dtpFrom.Value.Date)
                    cmd.Parameters.AddWithValue("@t", dtpTo.Value.Date)
                    Using r As MySqlDataReader = cmd.ExecuteReader()
                        While r.Read()
                            Dim row As DataGridViewRow = dgvIncidents.Rows(dgvIncidents.Rows.Add())
                            row.Cells("ReportNo").Value = r("incident_id").ToString()
                            row.Cells("BookNo").Value = r("copy_id").ToString()
                            row.Cells("Accession").Value = r("accession_no").ToString()
                            row.Cells("ISBN").Value = r("isbn").ToString()
                            row.Cells("BookTitle").Value = r("title").ToString()
                            row.Cells("BookAuthor").Value = If(IsDBNull(r("authors")), "", r("authors").ToString())
                            row.Cells("IncidentType").Value = r("incident_type").ToString()
                            row.Cells("DateReported").Value = Convert.ToDateTime(r("incident_date")).ToString("MM/dd/yyyy")
                            row.Cells("Borrower").Value = r("borrower").ToString()
                            row.Cells("Penalty").Value = If(IsDBNull(r("penalty_amount")), "None",
                                ChrW(&H20B1) & Convert.ToDecimal(r("penalty_amount")).ToString("N2") & " (" & r("penalty_status").ToString() & ")")
                            row.Cells("CopyStatus").Value = r("copy_status").ToString()
                            row.Cells("Recovered").Value = If(Convert.ToInt32(r("is_resolved")) = 1, "Yes", "No")
                            row.Cells("Remarks").Value = r("remarks").ToString()
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not load the lost and damaged books: " & ex.Message, vbCritical, "Lost and Damaged Books")
        End Try
        dgvIncidents.ClearSelection()
    End Sub

    ' ------------------------------------------------------------ buttons
    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        If dtpFrom.Value.Date > dtpTo.Value.Date Then
            MsgBox("'Date From' cannot be later than 'Date To'.", vbExclamation, "Lost and Damaged Books")
            Exit Sub
        End If
        useDateRange = True
        LoadIncidents()
        If dgvIncidents.Rows.Count = 0 Then
            MsgBox("No records found between " & dtpFrom.Value.ToString("MM/dd/yyyy") &
                   " and " & dtpTo.Value.ToString("MM/dd/yyyy") & ".", vbInformation, "Lost and Damaged Books")
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        useDateRange = False
        LoadIncidents()
    End Sub
    Private Sub btnRecover_Click(sender As Object, e As EventArgs) Handles btnRecover.Click
        If dgvIncidents.SelectedRows.Count = 0 Then
            MsgBox("Select a record from the list first.", vbExclamation, "Lost and Damaged Books")
            Exit Sub
        End If
        Dim row As DataGridViewRow = dgvIncidents.SelectedRows(0)
        If Convert.ToString(row.Cells("Recovered").Value) = "Yes" Then
            MsgBox("This book was already marked as recovered / repaired.", vbInformation, "Lost and Damaged Books")
            Exit Sub
        End If

        Dim copyId As Integer = Convert.ToInt32(row.Cells("BookNo").Value)
        If Not UiHelpers.Confirm("mark", "book no. " & copyId & " as recovered / repaired and return it to the library", "Lost and Damaged Books") Then Exit Sub

        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using tx As MySqlTransaction = conn.BeginTransaction()
                    Try
                        Using cmd As New MySqlCommand(
                            "UPDATE LostDamagedBooks SET is_resolved = 1, resolved_date = CURDATE() " &
                            "WHERE copy_id = @c AND is_resolved = 0", conn, tx)
                            cmd.Parameters.AddWithValue("@c", copyId)
                            cmd.ExecuteNonQuery()
                        End Using
                        Using cmd As New MySqlCommand(
                            "UPDATE BookCopies SET copy_status = 'Available', book_condition = 'Good' " &
                            "WHERE copy_id = @c AND copy_status IN ('Lost','Damaged')", conn, tx)
                            cmd.Parameters.AddWithValue("@c", copyId)
                            cmd.ExecuteNonQuery()
                        End Using
                        tx.Commit()
                    Catch
                        tx.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not update the record: " & ex.Message, vbCritical, "Lost and Damaged Books")
            Exit Sub
        End Try

        DBConnection.LogActivity("Recovered Book", "Book no. " & copyId & " marked as recovered / repaired")
        MsgBox("Book marked as recovered / repaired.", vbInformation, "Lost and Damaged Books")
        LoadIncidents()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim name As String = "Lost_Damaged_Books"
        If useDateRange Then
            name &= "_" & dtpFrom.Value.ToString("yyyyMMdd") & "_to_" & dtpTo.Value.ToString("yyyyMMdd")
        End If
        BorrowData.ExportGridToCsv(dgvIncidents, name)
    End Sub
End Class