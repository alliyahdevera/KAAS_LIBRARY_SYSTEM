Imports MySql.Data.MySqlClient

Public Class frmAdminLogs

    Private Sub frmAdminLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        SetupColumns()
        LoadLogs()
    End Sub

    Private Sub frmAdminLogs_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            LoadLogs()
        End If
    End Sub

    Private Sub SetupColumns()
        Dim lv As ListView = GetListViewControl()
        If lv Is Nothing Then Exit Sub

        lv.View = View.Details
        lv.FullRowSelect = True
        lv.GridLines = True
        lv.Columns.Clear()

        lv.Columns.Add("Log ID", 110)
        lv.Columns.Add("Account ID", 110)
        lv.Columns.Add("Action", 180)
        lv.Columns.Add("Description", 300)
        lv.Columns.Add("Date and Time", 180)
    End Sub

    Public Sub LoadLogs()
        Dim lv As ListView = GetListViewControl()
        If lv Is Nothing Then Exit Sub

        lv.Items.Clear()

        Using conn = DBConnection.GetConnection()
            conn.Open()
            Dim query As String = "SELECT log_id, account_id, action, description, data_time FROM tblactivitylogs ORDER BY data_time DESC"
            Dim cmd As New MySqlCommand(query, conn)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim item As New ListViewItem(reader("log_id").ToString())

                    If Not IsDBNull(reader("account_id")) Then
                        item.SubItems.Add(reader("account_id").ToString())
                    Else
                        item.SubItems.Add("")
                    End If

                    item.SubItems.Add(reader("action").ToString())
                    item.SubItems.Add(reader("description").ToString())

                    If Not IsDBNull(reader("data_time")) Then
                        item.SubItems.Add(Convert.ToDateTime(reader("data_time")).ToString("MM/dd/yyyy hh:mm:ss tt"))
                    Else
                        item.SubItems.Add("")
                    End If

                    lv.Items.Add(item)
                End While
            End Using
        End Using
    End Sub

    Private Function GetListViewControl() As ListView
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is ListView Then
                Return DirectCast(ctrl, ListView)
            End If
        Next
        Return Nothing
    End Function

    Private Sub btnExit_Click(sender As Object, e As EventArgs) 
        frmAdminMenu.Show()
        Me.Hide()
    End Sub

End Class