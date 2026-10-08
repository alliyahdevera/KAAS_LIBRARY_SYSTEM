Imports MySql.Data.MySqlClient

Public Class frmStudentPenalty

    Private Sub frmStudentPenalty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With dgvpenalty
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        UiHelpers.FillHeader(Me)          ' name, position, today
        RefreshPenalties()
    End Sub

    Private Sub frmStudentPenalty_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            UiHelpers.FillHeader(Me)
            RefreshPenalties()
        End If
    End Sub

    ' True if the Penalty table has a payment_date column.
    Private Function HasPaymentDateColumn(conn As MySqlConnection) As Boolean
        Using chk As New MySqlCommand(
            "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS " &
            "WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'Penalty' AND COLUMN_NAME = 'payment_date'", conn)
            Return Convert.ToInt32(chk.ExecuteScalar()) > 0
        End Using
    End Function

    Public Sub RefreshPenalties()
        dgvpenalty.Rows.Clear()
        Dim unpaid As Decimal = 0D, paid As Decimal = 0D
        If Not AppSession.MemberId.HasValue Then Exit Sub

        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()

                ' Payment date: the stored payment_date; if a Paid record has none
                ' (older records), fall back to the date the book was returned so a date is always shown.
                Dim payExpr As String = If(HasPaymentDateColumn(conn),
                                           "COALESCE(p.payment_date, t.return_date, t.due_date)",
                                           "COALESCE(t.return_date, t.due_date)")

                Using cmd As New MySqlCommand(
                    "SELECT b.isbn, b.title, b.edition, p.penalty_reason, t.return_condition, p.penalty_amount, p.penalty_status, " &
                    payExpr & " AS pay_date " &
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

                            Dim row As DataGridViewRow = dgvpenalty.Rows(dgvpenalty.Rows.Add())
                            row.Cells("ISBN").Value = r("isbn").ToString()
                            row.Cells("BookTitle").Value = r("title").ToString()
                            row.Cells("Edition").Value = If(IsDBNull(r("edition")), "", r("edition").ToString())
                            row.Cells("Reason").Value = r("penalty_reason").ToString().Replace(",", " + ")
                            row.Cells("BookCondition").Value = If(IsDBNull(r("return_condition")), "Pending", r("return_condition").ToString())
                            row.Cells("Amount").Value = ChrW(&H20B1) & amount.ToString("N2")
                            row.Cells("PenaltyStatus").Value = status

                            ' Paid -> always show a payment date; not paid -> blank
                            If status = "Paid" AndAlso Not IsDBNull(r("pay_date")) Then
                                row.Cells("PaymentDate").Value = Convert.ToDateTime(r("pay_date")).ToString("MM/dd/yyyy")
                            Else
                                row.Cells("PaymentDate").Value = ""
                            End If
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
        dgvpenalty.ClearSelection()
    End Sub
End Class