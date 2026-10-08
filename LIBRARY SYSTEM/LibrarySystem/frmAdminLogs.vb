Imports MySql.Data.MySqlClient

Public Class frmAdminLogs

    Private pager As GridPager
    Private isReady As Boolean = False

    Private Sub frmAdminLogs_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Not Me.Visible Then Exit Sub
        UiHelpers.FillHeader(Me)
        DashboardData.SetupReadOnlyGrid(DataGridView1)

        If pager Is Nothing Then pager = PagerHelper.Create(DataGridView1)

        If Not isReady Then
            cbodate.DropDownStyle = ComboBoxStyle.DropDownList
            cbodate.Items.Clear()
            cbodate.Items.Add("All Time")
            cbodate.Items.Add("This Week")
            cbodate.SelectedIndex = 0
            isReady = True
        End If
        LoadLogs(txtSearch.Text)
    End Sub

    Public Sub LoadLogs(Optional keyword As String = "")
        DataGridView1.Rows.Clear()
        Dim kw As String = If(keyword, "").Trim()
        Dim weekOnly As Integer = If(cbodate.Text = "This Week", 1, 0)
        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT l.log_id, l.user_id, u.username, l.action, l.description, l.log_time " &
                    "FROM ActivityLogs l LEFT JOIN Users u ON u.user_id = l.user_id " &
                    "WHERE (@kw = '' OR u.username LIKE CONCAT('%',@kw,'%') OR l.action LIKE CONCAT('%',@kw,'%') " &
                    " OR l.description LIKE CONCAT('%',@kw,'%')) " &
                    "AND (@wk = 0 OR YEARWEEK(l.log_time, 1) = YEARWEEK(CURDATE(), 1)) " &
                    "ORDER BY l.log_id DESC LIMIT 5000", conn)
                    cmd.Parameters.AddWithValue("@kw", kw)
                    cmd.Parameters.AddWithValue("@wk", weekOnly)
                    Using r As MySqlDataReader = cmd.ExecuteReader()
                        While r.Read()
                            Dim row As DataGridViewRow = DataGridView1.Rows(DataGridView1.Rows.Add())
                            row.Cells("LogID").Value = r("log_id").ToString()
                            row.Cells("AccountID").Value = If(IsDBNull(r("user_id")), "-",
                                If(IsDBNull(r("username")), "", r("username").ToString()) & " (#" & r("user_id").ToString() & ")")
                            row.Cells("nAction").Value = If(IsDBNull(r("action")), "", r("action").ToString())
                            row.Cells("dDescription").Value = If(IsDBNull(r("description")), "", r("description").ToString())
                            row.Cells("DateTime").Value = If(IsDBNull(r("log_time")), "",
                                Convert.ToDateTime(r("log_time")).ToString("MM/dd/yyyy hh:mm:ss tt"))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not load the activity logs: " & ex.Message, vbCritical, "Activity Logs")
        End Try
        DataGridView1.ClearSelection()
        If pager IsNot Nothing Then pager.Apply()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadLogs(txtSearch.Text)
    End Sub

    Private Sub cbodate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbodate.SelectedIndexChanged
        If Not isReady Then Exit Sub
        LoadLogs(txtSearch.Text)
    End Sub
End Class