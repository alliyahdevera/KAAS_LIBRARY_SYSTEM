Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmStudentHistory

    Private Sub frmStudentHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        RefreshHistory()
    End Sub

    Public Sub RefreshHistory()
        lstBorrowed.Items.Clear()

        If Form1.CurrentUsername <> "" AndAlso Form1.CurrentUsername IsNot Nothing Then
            lblTitle.Text = $"{Form1.CurrentUsername.ToUpper()}'S BORROW HISTORY"
        End If

        Using conn = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New MySqlCommand(
                "SELECT b.isbn, b.title, b.author, b.publisher, b.edition, " &
                "t.borrow_date, t.due_date, t.return_date, " &
                "t.condition_status, t.penalty_amount, t.penalty_status " &
                "FROM tbl_transaction t JOIN tbl_book b ON b.book_id = t.book_id " &
                "WHERE t.account_id = @aid ORDER BY t.borrow_date DESC", conn)
            cmd.Parameters.AddWithValue("@aid", Form1.CurrentAccountId)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim penaltyAmt As Decimal = Convert.ToDecimal(reader("penalty_amount"))
                    Dim penaltyText As String = If(penaltyAmt > 0,
                        "₱" & penaltyAmt.ToString("N2") & " (" & reader("penalty_status").ToString() & ")",
                        "None")

                    ' Treat blank/NULL condition_status the same as Pending so it
                    ' never shows up empty (covers old rows and manual DB edits).
                    Dim conditionStatus As String = reader("condition_status").ToString()
                    If String.IsNullOrWhiteSpace(conditionStatus) Then conditionStatus = "Pending"

                    Dim isReturned As Boolean = Not IsDBNull(reader("return_date"))

                    ' Borrow status: still with the student, waiting on the librarian's
                    ' check, or fully closed out once the condition is confirmed.
                    Dim borrowStatusText As String
                    If Not isReturned Then
                        borrowStatusText = "Borrowed"
                    ElseIf conditionStatus = "Pending" Then
                        borrowStatusText = "Pending"
                    Else
                        borrowStatusText = "Returned"
                    End If

                    Dim item As New ListViewItem(reader("isbn").ToString())
                    item.SubItems.Add(reader("title").ToString())
                    item.SubItems.Add(reader("author").ToString())
                    item.SubItems.Add(reader("publisher").ToString())
                    item.SubItems.Add(reader("edition").ToString())
                    item.SubItems.Add(Convert.ToDateTime(reader("borrow_date")).ToString("MM/dd/yyyy"))
                    item.SubItems.Add(Convert.ToDateTime(reader("due_date")).ToString("MM/dd/yyyy"))
                    item.SubItems.Add(If(isReturned, Convert.ToDateTime(reader("return_date")).ToString("MM/dd/yyyy"), ""))
                    item.SubItems.Add(borrowStatusText)
                    item.SubItems.Add(conditionStatus)
                    item.SubItems.Add(penaltyText)
                    lstBorrowed.Items.Add(item)
                End While
            End Using
        End Using
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs)
        frmStudentMenu.Show()
        Me.Hide()
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) 
        If lstBorrowed.Items.Count = 0 Then
            MsgBox("No borrow history available to export.", vbExclamation, "Export Failed")
            Exit Sub
        End If

        Using sfd As New SaveFileDialog()
            sfd.Filter = "CSV File (*.csv)|*.csv"
            sfd.FileName = $"{Form1.CurrentUsername}_Borrow_History_{DateTime.Now:yyyyMMdd}.csv"

            If sfd.ShowDialog() = DialogResult.OK Then
                Try
                    Using sw As New StreamWriter(sfd.FileName, False, System.Text.Encoding.UTF8)
                        Dim headers As New List(Of String)
                        For Each col As ColumnHeader In lstBorrowed.Columns
                            headers.Add($"""{col.Text}""")
                        Next
                        sw.WriteLine(String.Join(",", headers))

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
                    MsgBox("An error occurred while exporting: " & ex.Message, vbCritical, "Export Error")
                End Try
            End If
        End Using
    End Sub

End Class