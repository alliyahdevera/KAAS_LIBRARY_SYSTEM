Imports MySql.Data.MySqlClient

Public Class frmStudentPenalty

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        frmStudentMenu.Show()
        Me.Hide()
    End Sub

    Private Sub frmStudentPenalty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        RefreshPenalties()
    End Sub

    Private Sub frmStudentPenalty_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then RefreshPenalties()
    End Sub

    Public Sub RefreshPenalties()
        Using conn = DBConnection.GetConnection()
            conn.Open()
            LoadPenaltyDetails(conn)
            LoadSummary(conn)
        End Using
    End Sub

    Private Sub LoadPenaltyDetails(conn As MySqlConnection)
        ListView1.Items.Clear()
        Dim cmd As New MySqlCommand(
            "SELECT t.transaction_id, b.isbn, b.title, b.edition, t.due_date, t.return_date, " &
            "t.condition_status, t.penalty_amount, t.penalty_status " &
            "FROM tbl_transaction t JOIN tbl_book b ON b.book_id = t.book_id " &
            "WHERE t.account_id = @aid AND t.penalty_amount > 0 ORDER BY t.transaction_id DESC", conn)
        cmd.Parameters.AddWithValue("@aid", Form1.CurrentAccountId)

        Using reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                Dim condition As String = reader("condition_status").ToString()
                If String.IsNullOrWhiteSpace(condition) Then condition = "Pending"

                Dim isOverdue As Boolean = Not IsDBNull(reader("return_date")) AndAlso
                    Convert.ToDateTime(reader("return_date")) > Convert.ToDateTime(reader("due_date"))

                Dim reasonParts As New List(Of String)
                If isOverdue Then reasonParts.Add("Overdue")
                If condition = "Damaged" OrElse condition = "Lost" Then reasonParts.Add("Book Condition")
                Dim reason As String = If(reasonParts.Count > 0, String.Join(" + ", reasonParts), "Overdue")

                Dim item As New ListViewItem(reader("isbn").ToString())
                item.SubItems.Add(reader("title").ToString())
                item.SubItems.Add(reader("edition").ToString())
                item.SubItems.Add(reason)
                item.SubItems.Add(condition)
                item.SubItems.Add(Convert.ToDecimal(reader("penalty_amount")).ToString("₱0.00"))
                item.SubItems.Add(reader("penalty_status").ToString())
                item.Tag = Convert.ToInt32(reader("transaction_id"))
                ListView1.Items.Add(item)
            End While
        End Using
    End Sub

    Private Sub LoadSummary(conn As MySqlConnection)
        Dim dueCmd As New MySqlCommand(
            "SELECT COALESCE(SUM(penalty_amount),0) FROM tbl_transaction WHERE account_id=@aid AND penalty_status='Unpaid'", conn)
        dueCmd.Parameters.AddWithValue("@aid", Form1.CurrentAccountId)
        lblt_due.Text = Convert.ToDecimal(dueCmd.ExecuteScalar()).ToString("0.00")

        Dim paidCmd As New MySqlCommand(
            "SELECT COALESCE(SUM(penalty_amount),0) FROM tbl_transaction WHERE account_id=@aid AND penalty_status='Paid'", conn)
        paidCmd.Parameters.AddWithValue("@aid", Form1.CurrentAccountId)
        lblp_penalty.Text = Convert.ToDecimal(paidCmd.ExecuteScalar()).ToString("0.00")

        ' Penalty Status no longer has a "Pending" state now that upload/verify-by-photo
        ' is gone — this always resolves to 0.00, kept for the summary box you already have.
        lbl_pend_penalty.Text = Val(lblt_due.Text) + Val(lblp_penalty.Text)
    End Sub

End Class