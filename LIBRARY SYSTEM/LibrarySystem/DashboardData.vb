Imports System.Data
Imports System.Windows.Forms.DataVisualization.Charting
Imports MySql.Data.MySqlClient

Module DashboardData

    ' Recent transactions list (used by the admin and librarian dashboards)
    Public Const RecentTxSql As String =
        "SELECT u.username, b.title, t.borrow_date, t.due_date, " & BorrowData.StatusSql & " AS status " &
        "FROM BorrowTransaction t " &
        "JOIN Members m ON m.member_id = t.member_id JOIN Users u ON u.user_id = m.user_id " &
        "JOIN BookCopies c ON c.copy_id = t.copy_id JOIN BookInfo b ON b.book_id = c.book_id " &
        "ORDER BY t.transaction_id DESC LIMIT 10"

    ' Top 5 most borrowed titles
    Public Const TopBooksSql As String =
        "SELECT b.title, COUNT(*) AS n FROM BorrowTransaction t " &
        "JOIN BookCopies c ON c.copy_id = t.copy_id JOIN BookInfo b ON b.book_id = c.book_id " &
        "GROUP BY b.book_id, b.title ORDER BY n DESC, b.title LIMIT 5"

    ' Shared by Admin History and Reports
    Public Const RecordsSelect As String =
        "SELECT t.transaction_id, u.username, m.member_type, " & BorrowData.StatusSql & " AS status, " &
        "v.isbn, v.title, v.authors, t.borrow_date, t.due_date, t.return_date, t.return_condition, " &
        "p.penalty_amount, p.penalty_status "

    Public Const RecordsFrom As String =
        "FROM BorrowTransaction t " &
        "JOIN Members m ON m.member_id = t.member_id " &
        "JOIN Users u ON u.user_id = m.user_id " &
        "JOIN BookCopies c ON c.copy_id = t.copy_id " &
        "JOIN vw_BookCatalog v ON v.book_id = c.book_id " &
        "LEFT JOIN Penalty p ON p.transaction_id = t.transaction_id "

    Private Sub AddParams(cmd As MySqlCommand, args() As Object)
        If args Is Nothing Then Exit Sub
        For i As Integer = 0 To args.Length - 2 Step 2
            cmd.Parameters.AddWithValue(args(i).ToString(), args(i + 1))
        Next
    End Sub

    ' args = name1, value1, name2, value2 ...   (throws on error; callers catch)
    Public Function Scalar(sql As String, ParamArray args() As Object) As Decimal
        Using conn = DBConnection.GetConnection()
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
                AddParams(cmd, args)
                Dim o As Object = cmd.ExecuteScalar()
                If o Is Nothing OrElse IsDBNull(o) Then Return 0D
                Return Convert.ToDecimal(o)
            End Using
        End Using
    End Function

    Public Function Table(sql As String, ParamArray args() As Object) As DataTable
        Dim dt As New DataTable()
        Using conn = DBConnection.GetConnection()
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
                AddParams(cmd, args)
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ' dt: column 0 = label, column 1 = number
    Public Sub FillChart(ch As Chart, dt As DataTable, chartType As SeriesChartType, showLegend As Boolean)
        Dim s As Series = ch.Series(0)
        s.Points.Clear()
        s.ChartType = chartType
        s.IsValueShownAsLabel = True
        If ch.Legends.Count > 0 Then ch.Legends(0).Enabled = showLegend
        Dim round As Boolean = (chartType = SeriesChartType.Pie OrElse chartType = SeriesChartType.Doughnut)
        For Each r As DataRow In dt.Rows
            Dim v As Double = Convert.ToDouble(r(1))
            If round AndAlso v <= 0 Then Continue For
            Dim label As String = r(0).ToString()
            If label.Length > 28 Then label = label.Substring(0, 25) & "..."
            s.Points.AddXY(label, v)
        Next
        If ch.ChartAreas.Count > 0 Then ch.ChartAreas(0).AxisX.Interval = 1
    End Sub

    Public Sub FillList(lv As ListView, dt As DataTable)
        lv.BeginUpdate()
        lv.Items.Clear()
        For Each r As DataRow In dt.Rows
            Dim item As New ListViewItem(Cell(r(0)))
            For i As Integer = 1 To dt.Columns.Count - 1
                item.SubItems.Add(Cell(r(i)))
            Next
            For Each si As ListViewItem.ListViewSubItem In item.SubItems
                If si.Text = "Overdue" OrElse si.Text = "Unpaid" Then item.ForeColor = Color.Firebrick
            Next
            lv.Items.Add(item)
        Next
        lv.EndUpdate()
    End Sub

    Private Function Cell(o As Object) As String
        If o Is Nothing OrElse IsDBNull(o) Then Return ""
        If TypeOf o Is Date Then Return CDate(o).ToString("MM/dd/yyyy")
        Return o.ToString()
    End Function

    ' Adds one borrow-record row to a grid (Admin History / Reports)
    Public Sub AddRecordRow(grid As DataGridView, r As MySqlDataReader)
        Dim isReturned As Boolean = Not IsDBNull(r("return_date"))
        Dim cond As String = If(IsDBNull(r("return_condition")), If(isReturned, "Pending", "-"), r("return_condition").ToString())
        Dim pen As String = "None"
        If Not IsDBNull(r("penalty_amount")) Then
            pen = ChrW(&H20B1) & Convert.ToDecimal(r("penalty_amount")).ToString("N2") & " (" & r("penalty_status").ToString() & ")"
        End If
        Dim row As DataGridViewRow = grid.Rows(grid.Rows.Add())
        If grid.Columns.Contains("TransactionID") Then row.Cells("TransactionID").Value = r("transaction_id").ToString()
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
        row.Cells("Penalty").Value = pen
    End Sub

    Public Sub SetupReadOnlyGrid(g As DataGridView)
        g.ReadOnly = True
        g.AllowUserToAddRows = False
        g.AllowUserToDeleteRows = False
        g.MultiSelect = False
        g.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub
End Module