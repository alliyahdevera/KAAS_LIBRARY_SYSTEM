Imports MySql.Data.MySqlClient

Public Class frmAdminLogs

    Private Sub frmAdminLogs_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Not Me.Visible Then Exit Sub
        UiHelpers.FillHeader(Me)
        DashboardData.SetupReadOnlyGrid(DataGridView1)
        Label14.Text = "SEARCH BY USER, ACTION OR DESCRIPTION"
        AccountID.HeaderText = "Account"
        LoadLogs(txtSearch.Text)
    End Sub

    Public Sub LoadLogs(Optional keyword As String = "")
        DataGridView1.Rows.Clear()
        Dim kw As String = If(keyword, "").Trim()
        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT l.log_id, l.user_id, u.username, l.action, l.description, l.log_time " &
                    "FROM ActivityLogs l LEFT JOIN Users u ON u.user_id = l.user_id " &
                    "WHERE (@kw = '' OR u.username LIKE CONCAT('%',@kw,'%') OR l.action LIKE CONCAT('%',@kw,'%') " &
                    " OR l.description LIKE CONCAT('%',@kw,'%')) " &
                    "ORDER BY l.log_id DESC LIMIT 1000", conn)
                    cmd.Parameters.AddWithValue("@kw", kw)
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
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadLogs(txtSearch.Text)
    End Sub
End Class