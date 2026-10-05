Imports MySql.Data.MySqlClient

Module DBConnection
    Public Const PenaltyRatePerDay As Decimal = 150
    Private ReadOnly ConnString As String =
        "Server=localhost;Port=3306;Database=library_system;Uid=root;Pwd=;"

    Public Function GetConnection() As MySqlConnection
        Return New MySqlConnection(ConnString)
    End Function

    Public Sub LogActivity(action As String, description As String)
        Try
            Using conn = GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    "INSERT INTO tblactivitylogs (account_id, action, description, data_time) " &
                    "VALUES (@accountId, @action, @description, @dataTime)", conn)
                    cmd.Parameters.AddWithValue("@accountId", Form1.CurrentAccountId)
                    cmd.Parameters.AddWithValue("@action", action)
                    cmd.Parameters.AddWithValue("@description", description)
                    cmd.Parameters.AddWithValue("@dataTime", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' Swallow logging errors so a failed log never blocks the actual action
        End Try
    End Sub
End Module