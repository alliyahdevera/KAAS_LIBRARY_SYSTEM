Imports System.IO
Imports System.Linq
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Module BorrowData

    ' Borrow status shown everywhere (Borrowed / Overdue / Pending / Returned / Penalty). Uses alias t = BorrowTransaction.
    Public Const StatusSql As String =
        "CASE WHEN t.transaction_status = 'Borrowed' THEN IF(CURDATE() > t.due_date, 'Overdue', 'Borrowed') " &
        "WHEN t.return_condition IS NULL THEN 'Pending' " &
        "WHEN t.return_condition = 'Good' THEN 'Returned' ELSE 'Penalty' END"

    Public Class BorrowOutcome
        Public Borrowed As Integer
        Public DueDate As Date
        Public Problems As New List(Of String)
    End Class

    Public Class ReturnOutcome
        Public Returned As Integer
        Public PenaltyTotal As Decimal
    End Class

    ' Loan period; a due date on Saturday/Sunday moves to Monday (library is closed)
    Public Function CalcDueDate(fromDate As Date, memberType As String) As Date
        Dim result As Date = fromDate.AddDays(LibraryRules.LoanDays(memberType))
        Select Case result.DayOfWeek
            Case DayOfWeek.Saturday : result = result.AddDays(2)
            Case DayOfWeek.Sunday : result = result.AddDays(1)
        End Select
        Return result
    End Function

    Public Function ActiveLoanCount(conn As MySqlConnection, memberId As Integer, Optional tx As MySqlTransaction = Nothing) As Integer
        Using cmd As New MySqlCommand(
            "SELECT COUNT(*) FROM BorrowTransaction WHERE member_id = @m AND transaction_status = 'Borrowed'", conn, tx)
            cmd.Parameters.AddWithValue("@m", memberId)
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

    ' ---------------------------------------------------------------- BORROW
    Public Function BorrowBooks(memberId As Integer, memberType As String, isbns As List(Of String)) As BorrowOutcome
        Dim outcome As New BorrowOutcome()
        Dim borrowDate As Date = Date.Today
        outcome.DueDate = CalcDueDate(borrowDate, memberType)
        Dim maxLoans As Integer = LibraryRules.MaxActiveLoans(memberType)

        Using conn = DBConnection.GetConnection()
            conn.Open()
            Using tx As MySqlTransaction = conn.BeginTransaction()
                Try
                    Dim active As Integer = ActiveLoanCount(conn, memberId, tx)
                    If active + isbns.Count > maxLoans Then
                        outcome.Problems.Add("You can only have " & maxLoans & " books borrowed at once (you currently have " & active & ").")
                        tx.Rollback()
                        Return outcome
                    End If

                    For Each isbn As String In isbns
                        Dim copyId As Integer = 0
                        Using find As New MySqlCommand(
                            "SELECT c.copy_id FROM BookCopies c JOIN BookInfo b ON b.book_id = c.book_id " &
                            "WHERE b.isbn = @i AND c.copy_status = 'Available' ORDER BY c.copy_id LIMIT 1 FOR UPDATE", conn, tx)
                            find.Parameters.AddWithValue("@i", isbn)
                            Dim o As Object = find.ExecuteScalar()
                            If o IsNot Nothing AndAlso Not IsDBNull(o) Then copyId = Convert.ToInt32(o)
                        End Using

                        If copyId = 0 Then
                            outcome.Problems.Add("No copy left for ISBN " & isbn & " - someone may have just borrowed it.")
                            Continue For
                        End If

                        Using ins As New MySqlCommand(
                            "INSERT INTO BorrowTransaction (member_id, copy_id, borrow_date, due_date, transaction_status) " &
                            "VALUES (@m, @c, @bd, @dd, 'Borrowed')", conn, tx)
                            ins.Parameters.AddWithValue("@m", memberId)
                            ins.Parameters.AddWithValue("@c", copyId)
                            ins.Parameters.AddWithValue("@bd", borrowDate)
                            ins.Parameters.AddWithValue("@dd", outcome.DueDate)
                            ins.ExecuteNonQuery()
                        End Using
                        Using upd As New MySqlCommand("UPDATE BookCopies SET copy_status = 'Borrowed' WHERE copy_id = @c", conn, tx)
                            upd.Parameters.AddWithValue("@c", copyId)
                            upd.ExecuteNonQuery()
                        End Using
                        outcome.Borrowed += 1
                    Next
                    tx.Commit()
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
        Return outcome
    End Function

    ' ---------------------------------------------------------------- RETURN
    ' The student only hands the book back. Condition stays "Pending" until a librarian verifies it.
    Public Function ReturnBooks(transactionIds As List(Of Integer)) As ReturnOutcome
        Dim outcome As New ReturnOutcome()
        Dim today As Date = Date.Today

        Using conn = DBConnection.GetConnection()
            conn.Open()
            Using tx As MySqlTransaction = conn.BeginTransaction()
                Try
                    For Each tid As Integer In transactionIds
                        Dim dueDate As Date, copyId As Integer, memberType As String = ""
                        Using cmd As New MySqlCommand(
                            "SELECT t.due_date, t.copy_id, m.member_type FROM BorrowTransaction t " &
                            "JOIN Members m ON m.member_id = t.member_id " &
                            "WHERE t.transaction_id = @t AND t.transaction_status = 'Borrowed' FOR UPDATE", conn, tx)
                            cmd.Parameters.AddWithValue("@t", tid)
                            Using r As MySqlDataReader = cmd.ExecuteReader()
                                If Not r.Read() Then Continue For
                                dueDate = Convert.ToDateTime(r("due_date")).Date
                                copyId = Convert.ToInt32(r("copy_id"))
                                memberType = r("member_type").ToString()
                            End Using
                        End Using

                        Dim overdueDays As Integer = Math.Max(0, (today - dueDate).Days)
                        Dim amount As Decimal = LibraryRules.LatePenalty(overdueDays, memberType)      ' CHANGED (grace period + P20/day)

                        Using upd As New MySqlCommand(
                            "UPDATE BorrowTransaction SET return_date = @rd, transaction_status = 'Returned', return_condition = NULL " &
                            "WHERE transaction_id = @t", conn, tx)
                            upd.Parameters.AddWithValue("@rd", today)
                            upd.Parameters.AddWithValue("@t", tid)
                            upd.ExecuteNonQuery()
                        End Using
                        Using upd As New MySqlCommand(
                            "UPDATE BookCopies SET copy_status = 'Available' WHERE copy_id = @c AND copy_status = 'Borrowed'", conn, tx)
                            upd.Parameters.AddWithValue("@c", copyId)
                            upd.ExecuteNonQuery()
                        End Using

                        If amount > 0 Then
                            Using ins As New MySqlCommand(
                                "INSERT INTO Penalty (transaction_id, penalty_reason, days_overdue, penalty_amount, penalty_status) " &
                                "VALUES (@t, 'Overdue', @d, @a, 'Unpaid')", conn, tx)
                                ins.Parameters.AddWithValue("@t", tid)
                                ins.Parameters.AddWithValue("@d", overdueDays)
                                ins.Parameters.AddWithValue("@a", amount)
                                ins.ExecuteNonQuery()
                            End Using
                            outcome.PenaltyTotal += amount
                        End If
                        outcome.Returned += 1
                    Next
                    tx.Commit()
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
        Return outcome
    End Function

    ' ---------------------------------------------------------------- VERIFY (librarian)
    ' Sets the real condition, recomputes the whole penalty (overdue + Damaged/Lost = book price)
    ' and keeps BookCopies in sync.
    ' newStatus = Nothing  -> keep the current status (or Unpaid if the amount changed)
    ' newStatus = None/Unpaid/Paid -> set it explicitly (Paid needs a 6-digit receipt number)
    ' Returns the new total penalty. Throws InvalidOperationException with a user-friendly message.
    Public Function ApplyVerification(transactionId As Integer, newCondition As String,
                                      Optional newStatus As String = Nothing,
                                      Optional receipt As String = Nothing) As Decimal
        If newCondition <> "Good" AndAlso newCondition <> "Damaged" AndAlso newCondition <> "Lost" Then
            Throw New InvalidOperationException("Please select the book's actual condition (Good, Damaged, or Lost).")
        End If

        Dim cleanReceipt As String = If(receipt, "").Trim()
        If cleanReceipt <> "" AndAlso Not Regex.IsMatch(cleanReceipt, "^\d{6}$") Then
            Throw New InvalidOperationException("Receipt number must be exactly 6 digits (numbers only).")
        End If
        If newStatus = "Paid" AndAlso cleanReceipt = "" Then
            Throw New InvalidOperationException("A valid 6-digit receipt number is required before marking this record as Paid.")
        End If

        Using conn = DBConnection.GetConnection()
            conn.Open()
            Using tx As MySqlTransaction = conn.BeginTransaction()
                Try
                    Dim dueDate As Date, returnDate As Date, copyId As Integer
                    Dim memberType As String = "", price As Decimal = 0D
                    Using cmd As New MySqlCommand(
                        "SELECT t.due_date, t.return_date, t.copy_id, m.member_type, IFNULL(b.price, 0) AS price " &
                        "FROM BorrowTransaction t JOIN Members m ON m.member_id = t.member_id " &
                        "JOIN BookCopies c ON c.copy_id = t.copy_id JOIN BookInfo b ON b.book_id = c.book_id " &
                        "WHERE t.transaction_id = @t AND t.return_date IS NOT NULL FOR UPDATE", conn, tx)
                        cmd.Parameters.AddWithValue("@t", transactionId)
                        Using r As MySqlDataReader = cmd.ExecuteReader()
                            If Not r.Read() Then
                                Throw New InvalidOperationException("This book hasn't been returned yet - there's nothing to verify.")
                            End If
                            dueDate = Convert.ToDateTime(r("due_date")).Date
                            returnDate = Convert.ToDateTime(r("return_date")).Date
                            copyId = Convert.ToInt32(r("copy_id"))
                            memberType = r("member_type").ToString()
                            price = Convert.ToDecimal(r("price"))
                        End Using
                    End Using

                    Dim hasExisting As Boolean = False
                    Dim existingAmount As Decimal = 0D, existingStatus As String = "Unpaid", existingReceipt As String = ""
                    Using cmd As New MySqlCommand(
                        "SELECT penalty_amount, penalty_status, IFNULL(receipt_number, '') AS rc FROM Penalty WHERE transaction_id = @t", conn, tx)
                        cmd.Parameters.AddWithValue("@t", transactionId)
                        Using r As MySqlDataReader = cmd.ExecuteReader()
                            If r.Read() Then
                                hasExisting = True
                                existingAmount = Convert.ToDecimal(r("penalty_amount"))
                                existingStatus = r("penalty_status").ToString()
                                existingReceipt = r("rc").ToString()
                            End If
                        End Using
                    End Using

                    Dim overdueDays As Integer = Math.Max(0, (returnDate - dueDate).Days)
                    Dim overdueAmount As Decimal = LibraryRules.LatePenalty(overdueDays, memberType)   ' CHANGED (grace period + P20/day)
                    Dim conditionAmount As Decimal = If(newCondition = "Good", 0D, price)
                    Dim total As Decimal = overdueAmount + conditionAmount

                    If total > 0 AndAlso newStatus = "None" Then
                        Throw New InvalidOperationException("This record still has an amount due - choose Unpaid or Paid instead of None.")
                    End If

                    ' 1. condition + who received it
                    Using upd As New MySqlCommand(
                        "UPDATE BorrowTransaction SET return_condition = @c, received_by = COALESCE(received_by, @u) " &
                        "WHERE transaction_id = @t", conn, tx)
                        upd.Parameters.AddWithValue("@c", newCondition)
                        upd.Parameters.AddWithValue("@u", If(AppSession.UserId > 0, CObj(AppSession.UserId), DBNull.Value))
                        upd.Parameters.AddWithValue("@t", transactionId)
                        upd.ExecuteNonQuery()
                    End Using

                    ' 2. the physical copy (status + condition)
                    ' A "Good" verification never puts a copy back on the shelf while it still has an
                    ' unrecovered Lost/Damaged report from another return - only "Mark Recovered" does that.
                    Using upd As New MySqlCommand(
                        "UPDATE BookCopies SET copy_status = @s, " &
                        "book_condition = CASE WHEN @s = 'Available' " &
                        "  THEN IF(book_condition IN ('Damaged','Lost'), 'Good', book_condition) ELSE @s END " &
                        "WHERE copy_id = @c AND copy_status <> 'Borrowed' " &
                        "AND (@s <> 'Available' OR NOT EXISTS (SELECT 1 FROM LostDamagedBooks i " &
                        "     WHERE i.copy_id = @c AND i.is_resolved = 0 AND IFNULL(i.transaction_id, 0) <> @t))", conn, tx)
                        upd.Parameters.AddWithValue("@s", If(newCondition = "Good", "Available", newCondition))
                        upd.Parameters.AddWithValue("@c", copyId)
                        upd.Parameters.AddWithValue("@t", transactionId)
                        upd.ExecuteNonQuery()
                    End Using

                    ' 2b. lost / damaged log
                    CopyData.LogReturnIncident(conn, tx, transactionId, newCondition)

                    ' 3. the penalty row
                    If total > 0 Then
                        Dim reasons As New List(Of String)
                        If overdueAmount > 0 Then reasons.Add("Overdue")                                ' CHANGED (only when a fine applies)
                        If newCondition <> "Good" Then reasons.Add(newCondition)

                        Dim status As String
                        Dim rcptValue As Object
                        If newStatus IsNot Nothing Then
                            status = newStatus
                            rcptValue = If(cleanReceipt = "", CObj(DBNull.Value), cleanReceipt)
                        Else
                            Dim unchanged As Boolean = hasExisting AndAlso existingAmount = total
                            status = If(unchanged, existingStatus, "Unpaid")
                            rcptValue = If(unchanged AndAlso existingReceipt <> "", CObj(existingReceipt), DBNull.Value)
                        End If

                        Using up As New MySqlCommand(
                            "INSERT INTO Penalty (transaction_id, penalty_reason, days_overdue, penalty_amount, penalty_status, " &
                            "receipt_number, verified_by, verification_date) " &
                            "VALUES (@t, @reason, @d, @a, @s, @rc, @u, NOW()) " &
                            "ON DUPLICATE KEY UPDATE penalty_reason = VALUES(penalty_reason), days_overdue = VALUES(days_overdue), " &
                            "penalty_amount = VALUES(penalty_amount), penalty_status = VALUES(penalty_status), " &
                            "receipt_number = VALUES(receipt_number), verified_by = VALUES(verified_by), verification_date = NOW()", conn, tx)
                            up.Parameters.AddWithValue("@t", transactionId)
                            up.Parameters.AddWithValue("@reason", String.Join(",", reasons))
                            up.Parameters.AddWithValue("@d", overdueDays)
                            up.Parameters.AddWithValue("@a", total)
                            up.Parameters.AddWithValue("@s", status)
                            up.Parameters.AddWithValue("@rc", rcptValue)
                            up.Parameters.AddWithValue("@u", If(AppSession.UserId > 0, CObj(AppSession.UserId), DBNull.Value))
                            up.ExecuteNonQuery()
                        End Using
                    ElseIf hasExisting Then
                        Using del As New MySqlCommand("DELETE FROM Penalty WHERE transaction_id = @t", conn, tx)
                            del.Parameters.AddWithValue("@t", transactionId)
                            del.ExecuteNonQuery()
                        End Using
                    End If

                    tx.Commit()
                    Return total
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Function

    ' ---------------------------------------------------------------- EXPORT
    ' askFirst = True shows a Yes/No confirmation before the save dialog.
    Public Sub ExportGridToCsv(grid As DataGridView, baseName As String, Optional askFirst As Boolean = True)
        If grid.Rows.Count = 0 Then
            MsgBox("No records available to export.", vbExclamation, "Export Failed")
            Exit Sub
        End If
        If askFirst AndAlso Not UiHelpers.Confirm("export", "these records to Excel (CSV)", "Export") Then Exit Sub

        Using sfd As New SaveFileDialog()
            sfd.Filter = "CSV File (*.csv)|*.csv"
            sfd.FileName = $"{baseName}_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            If sfd.ShowDialog() <> DialogResult.OK Then Exit Sub
            Try
                Dim cols As List(Of DataGridViewColumn) =
                    grid.Columns.Cast(Of DataGridViewColumn)().Where(Function(c) c.Visible).OrderBy(Function(c) c.DisplayIndex).ToList()
                Using sw As New StreamWriter(sfd.FileName, False, New System.Text.UTF8Encoding(True))
                    sw.WriteLine(String.Join(",", cols.Select(Function(c) Quote(c.HeaderText))))
                    For Each row As DataGridViewRow In grid.Rows
                        sw.WriteLine(String.Join(",", cols.Select(Function(c) Quote(Convert.ToString(row.Cells(c.Index).Value)))))
                    Next
                End Using
                MsgBox("Records exported successfully!", vbInformation, "Export Complete")
            Catch ex As Exception
                MsgBox("An error occurred while exporting: " & ex.Message, vbCritical, "Export Error")
            End Try
        End Using
    End Sub

    Private Function Quote(s As String) As String
        Return """" & If(s, "").Replace("""", """""") & """"
    End Function

End Module