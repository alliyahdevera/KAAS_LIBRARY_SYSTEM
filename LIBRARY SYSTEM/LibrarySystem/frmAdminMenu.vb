Imports MySql.Data.MySqlClient

Public Class frmAdminMenu
    Private Sub btnLogout_Click(sender As Object, e As EventArgs)
        If MsgBox("Are you sure you want to logout?", vbQuestion + vbYesNo, "LOGOUT") = vbYes Then
            MsgBox("Thank you for using Library System!", vbInformation, "GOODBYE")
            Me.Hide()
            Form1.Show()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnBookMan_Click(sender As Object, e As EventArgs) Handles btnborrowh.Click
        frmBookManagement.Show()
        Me.Hide()

    End Sub

    Private Sub btnAccMan_Click(sender As Object, e As EventArgs) Handles btndash.Click
        If Form1.CurrentAccountType IsNot Nothing AndAlso
           Form1.CurrentAccountType.Equals("Librarian", StringComparison.OrdinalIgnoreCase) Then
            MsgBox("Librarians do not have access to Account Management.", vbExclamation, "Access Denied")
            Exit Sub
        End If
        frmAccountManagement.Show()
        Me.Hide()
    End Sub

    Private Sub btnRecords_Click(sender As Object, e As EventArgs) Handles btnaccman.Click
        frmAdminHistory.RefreshHistory()
        frmAdminHistory.Show()
        Me.Hide()
    End Sub

    Public Sub RefreshDashboard()
        Using conn = DBConnection.GetConnection()
            conn.Open()

            Dim totalBooks As Integer = 0
            Using cmd As New MySqlCommand("SELECT COUNT(*) FROM tbl_book", conn)
                totalBooks = Convert.ToInt32(cmd.ExecuteScalar())
            End Using
            lblTotalBooks.Text = totalBooks.ToString()

            Dim borrowedCount As Integer = 0
            Using cmd As New MySqlCommand("SELECT COUNT(*) FROM tbl_transaction WHERE return_date IS NULL AND due_date >= CURDATE()", conn)
                borrowedCount = Convert.ToInt32(cmd.ExecuteScalar())
            End Using
            lblBooksBorrowed.Text = borrowedCount.ToString()

            Dim overdueCount As Integer = 0
            Using cmd As New MySqlCommand("SELECT COUNT(*) FROM tbl_transaction WHERE return_date IS NULL AND due_date < CURDATE()", conn)
                overdueCount = Convert.ToInt32(cmd.ExecuteScalar())
            End Using
            lblb_return.Text = overdueCount.ToString()

            Dim studentCount As Integer = 0
            Using cmd As New MySqlCommand("SELECT COUNT(*) FROM tbl_account WHERE account_type = 'Student'", conn)
                studentCount = Convert.ToInt32(cmd.ExecuteScalar())
            End Using
            lblt_students.Text = studentCount.ToString()

            Dim availableCount As Integer = Math.Max(0, totalBooks - borrowedCount - overdueCount)
            lblb_avail.Text = availableCount.ToString()

            ' NEW: damaged and lost counts
            Dim damagedCount As Integer = 0
            Using cmd As New MySqlCommand("SELECT COUNT(*) FROM tbl_transaction WHERE condition_status = 'Damaged'", conn)
                damagedCount = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            Dim lostCount As Integer = 0
            Using cmd As New MySqlCommand("SELECT COUNT(*) FROM tbl_transaction WHERE condition_status = 'Lost'", conn)
                lostCount = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            LoadOverviewChart(borrowedCount, overdueCount, availableCount, damagedCount, lostCount)
            LoadCategoriesChart(conn)
            LoadMostBorrowedChart(conn)
            LoadLibraryActivity(conn)
        End Using
    End Sub

    Private Sub LoadOverviewChart(borrowed As Integer, overdue As Integer, available As Integer, damaged As Integer, lost As Integer)
        Dim series = chartb_overview.Series("Series1")

        series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut
        series.Points.Clear()

        series.Points.AddXY("Borrowed", borrowed)
        series.Points.AddXY("Overdue", overdue)
        series.Points.AddXY("Available", available)
        series.Points.AddXY("Damaged", damaged)
        series.Points.AddXY("Lost", lost)

        For Each pt In series.Points
            pt.Label = "#VAL"
            pt.LegendText = "#VALX"
        Next
    End Sub

    Private Sub LoadCategoriesChart(conn As MySqlConnection)
        Dim series = chartb_categories.Series("Series1")
        chartb_categories.Legends(0).Enabled = False
        series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
        series.Points.Clear()

        Using cmd As New MySqlCommand(
        "SELECT category, COUNT(*) AS total FROM tbl_book " &
        "WHERE category IS NOT NULL AND category <> '' GROUP BY category ORDER BY total DESC", conn)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    series.Points.AddXY(reader("category").ToString(), Convert.ToInt32(reader("total")))
                End While
            End Using
        End Using
    End Sub

    Private Sub LoadMostBorrowedChart(conn As MySqlConnection)
        Dim series = chartb_mborrowed.Series("Series1")
        chartb_mborrowed.Legends(0).Enabled = False
        series.Points.Clear()

        Using cmd As New MySqlCommand(
        "SELECT b.title, COUNT(*) AS total FROM tbl_transaction t " &
        "JOIN tbl_book b ON b.book_id = t.book_id " &
        "GROUP BY b.title ORDER BY total DESC LIMIT 5", conn)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    series.Points.AddXY(reader("title").ToString(), Convert.ToInt32(reader("total")))
                End While
            End Using
        End Using
    End Sub

    Private Sub LoadLibraryActivity(conn As MySqlConnection)
        ListView1.Items.Clear()

        Using cmd As New MySqlCommand(
            "SELECT a.username, b.title, t.borrow_date, t.due_date, " &
            "CASE WHEN t.return_date IS NOT NULL AND t.penalty_status = 'Unpaid' THEN 'Penalty' " &
            "     WHEN t.return_date IS NOT NULL THEN 'Returned' " &
            "     WHEN t.due_date < CURDATE() THEN 'Overdue' " &
            "     ELSE 'Borrowed' END AS status " &
            "FROM tbl_transaction t " &
            "JOIN tbl_account a ON a.account_id = t.account_id " &
            "JOIN tbl_book b ON b.book_id = t.book_id " &
            "ORDER BY t.borrow_date DESC LIMIT 10", conn)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim item As New ListViewItem(reader("username").ToString())
                    item.SubItems.Add(reader("title").ToString())
                    item.SubItems.Add(Convert.ToDateTime(reader("borrow_date")).ToString("MM/dd/yyyy"))
                    item.SubItems.Add(Convert.ToDateTime(reader("due_date")).ToString("MM/dd/yyyy"))
                    item.SubItems.Add(reader("status").ToString())
                    ListView1.Items.Add(item)
                End While
            End Using
        End Using
    End Sub

    Private Sub frmAdminMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        RefreshDashboard()
    End Sub

    Private Sub frmAdminMenu_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        RefreshDashboard()
    End Sub

    Private Sub tmrDateTime_Tick(sender As Object, e As EventArgs) Handles tmrDateTime.Tick
        lbldatetime.Text = Date.Now.ToString("📅 MMMM dd, yyyy | ⏱️ hh:mm:ss tt")
        lbl_dT.Text = Date.Now.ToString("📅 MMMM dd, yyyy | ⏱️ hh:mm:ss tt")
    End Sub

    Private Sub btnadl_Click(sender As Object, e As EventArgs) Handles btnbookman.Click
        frmAdminLogs.Show()
        Me.Hide()
    End Sub


End Class