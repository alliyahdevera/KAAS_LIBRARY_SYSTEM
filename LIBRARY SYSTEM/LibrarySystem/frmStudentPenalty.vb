Imports MySql.Data.MySqlClient

Public Class frmStudentPenalty

    Private Sub frmStudentPenalty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With DataGridView1
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        RefreshPenalties()
    End Sub

    Private Sub frmStudentPenalty_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then RefreshPenalties()
    End Sub

    Public Sub RefreshPenalties()
        DataGridView1.Rows.Clear()
        Dim unpaid As Decimal = 0D, paid As Decimal = 0D
        If Not AppSession.MemberId.HasValue Then Exit Sub

        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT b.isbn, b.title, b.edition, p.penalty_reason, t.return_condition, p.penalty_amount, p.penalty_status " &
                    "FROM Penalty p " &
                    "JOIN BorrowTransaction t ON t.transaction_id = p.transaction_id " &
                    "JOIN BookCopies c ON c.copy_id = t.copy_id " &
                    "JOIN BookInfo b ON b.book_id = c.book_id " &
                    "WHERE t.member_id = @m ORDER BY p.penalty_id DESC", conn)
                    cmd.Parameters.AddWithValue("@m", AppSession.MemberId.Value)
                    Using r As MySqlDataReader = cmd.ExecuteReader()
                        While r.Read()
                            Dim amount As Decimal = Convert.ToDecimal(r("penalty_amount"))
                            Dim status As String = r("penalty_status").ToString()
                            If status = "Paid" Then
                                paid += amount
                            ElseIf status = "Unpaid" OrElse status = "Pending" Then
                                unpaid += amount
                            End If

                            Dim row As DataGridViewRow = DataGridView1.Rows(DataGridView1.Rows.Add())
                            row.Cells("ISBN").Value = r("isbn").ToString()
                            row.Cells("BookTitle").Value = r("title").ToString()
                            row.Cells("Edition").Value = If(IsDBNull(r("edition")), "", r("edition").ToString())
                            row.Cells("Reason").Value = r("penalty_reason").ToString().Replace(",", " + ")
                            row.Cells("BookCondition").Value = If(IsDBNull(r("return_condition")), "Pending", r("return_condition").ToString())
                            row.Cells("Amount").Value = ChrW(&H20B1) & amount.ToString("N2")
                            row.Cells("PenaltyStatus").Value = status
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not load your penalties: " & ex.Message, vbCritical, "My Penalties")
        End Try

        lblt_due.Text = ChrW(&H20B1) & unpaid.ToString("N2")              ' Pending Penalty (unpaid)
        lblp_penalty.Text = ChrW(&H20B1) & paid.ToString("N2")            ' Total Paid
        lbl_pend_penalty.Text = ChrW(&H20B1) & (unpaid + paid).ToString("N2") ' Total Penalty
        DataGridView1.ClearSelection()
    End Sub
End Class