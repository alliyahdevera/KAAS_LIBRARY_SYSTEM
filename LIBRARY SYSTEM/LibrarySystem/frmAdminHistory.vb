Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmAdminHistory

    Private Sub frmAdminHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        RefreshHistory()
    End Sub

    Public Sub RefreshHistory()
        lstBorrowed.Items.Clear()

        Using conn = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New MySqlCommand(
                "SELECT a.username, a.account_type, t.transaction_id, " &
                "b.isbn, b.title, b.author, t.borrow_date, t.due_date, t.return_date, " &
                "t.condition_status, t.penalty_status, " &
                "CASE WHEN t.return_date IS NOT NULL AND t.penalty_status = 'Unpaid' THEN 'Penalty' " &
                "     WHEN t.return_date IS NOT NULL THEN 'Returned' " &
                "     WHEN t.due_date < CURDATE() THEN 'Overdue' " &
                "     ELSE 'Borrowed' END AS status " &
                "FROM tbl_transaction t " &
                "JOIN tbl_account a ON a.account_id = t.account_id " &
                "JOIN tbl_book b ON b.book_id = t.book_id " &
                "ORDER BY t.borrow_date DESC", conn)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim item As New ListViewItem(reader("username").ToString())
                    item.SubItems.Add(reader("account_type").ToString())
                    item.SubItems.Add(reader("status").ToString())
                    item.SubItems.Add(reader("isbn").ToString())
                    item.SubItems.Add(reader("title").ToString())
                    item.SubItems.Add(reader("author").ToString())
                    item.SubItems.Add(Convert.ToDateTime(reader("borrow_date")).ToString("MM/dd/yyyy"))
                    item.SubItems.Add(Convert.ToDateTime(reader("due_date")).ToString("MM/dd/yyyy"))
                    item.SubItems.Add(If(IsDBNull(reader("return_date")), "", Convert.ToDateTime(reader("return_date")).ToString("MM/dd/yyyy")))
                    item.SubItems.Add(reader("condition_status").ToString())
                    item.SubItems.Add(reader("penalty_status").ToString())
                    item.Tag = Convert.ToInt32(reader("transaction_id"))
                    lstBorrowed.Items.Add(item)
                End While
            End Using
        End Using
    End Sub

    Private Sub btnMarkPaid_Click(sender As Object, e As EventArgs)
        If lstBorrowed.SelectedItems.Count = 0 Then
            MsgBox("Please select a borrow record first.", vbExclamation, "Mark Penalty as Paid")
            Exit Sub
        End If

        Dim transactionId As Integer = CInt(lstBorrowed.SelectedItems(0).Tag)

        If MsgBox("Confirm this penalty has been paid and the receipt verified?",
                   vbQuestion + vbYesNo, "Confirm Penalty Payment") = vbYes Then

            Using conn = DBConnection.GetConnection()
                conn.Open()
                Dim cmd As New MySqlCommand(
                    "UPDATE tbl_transaction SET penalty_status = 'Paid' WHERE transaction_id = @tid", conn)
                cmd.Parameters.AddWithValue("@tid", transactionId)
                cmd.ExecuteNonQuery()
            End Using

            RefreshHistory()
            MsgBox("Penalty marked as paid.", vbInformation, "Mark Penalty as Paid")
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs)
        Me.Hide()

        frmAdminMenu.Show()

    End Sub
    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        If lstBorrowed.Items.Count = 0 Then
            MsgBox("No borrow history records available to export.", vbExclamation, "Export Failed")
            Exit Sub
        End If

        Using sfd As New SaveFileDialog()
            sfd.Filter = "CSV File (*.csv)|*.csv"
            sfd.FileName = $"Borrow_History_{DateTime.Now:yyyyMMdd_HHmmss}.csv"

            If sfd.ShowDialog() = DialogResult.OK Then
                Try
                    Using sw As New StreamWriter(sfd.FileName, False, System.Text.Encoding.UTF8)
                        ' 1. Export Column Headers from the ListView
                        Dim headers As New List(Of String)
                        For Each col As ColumnHeader In lstBorrowed.Columns
                            headers.Add($"""{col.Text}""")
                        Next
                        sw.WriteLine(String.Join(",", headers))

                        ' 2. Export Row Data
                        For Each item As ListViewItem In lstBorrowed.Items
                            Dim rowValues As New List(Of String)
                            For Each subItem As ListViewItem.ListViewSubItem In item.SubItems
                                rowValues.Add($"""{subItem.Text.Replace("""", """""")}""")
                            Next
                            sw.WriteLine(String.Join(",", rowValues))
                        Next
                    End Using

                    MsgBox("Borrow history exported successfully!", vbInformation, "Export Complete")
                Catch ex As Exception
                    MsgBox("An error occurred while exporting history: " & ex.Message, vbCritical, "Export Error")
                End Try
            End If
        End Using
    End Sub
End Class