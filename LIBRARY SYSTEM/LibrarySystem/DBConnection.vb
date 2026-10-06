Imports MySql.Data.MySqlClient

Module DBConnection

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
                    "INSERT INTO ActivityLogs (user_id, action, description, log_time) " &
                    "VALUES (@uid, @a, @d, NOW())", conn)
                    cmd.Parameters.AddWithValue("@uid",
                        If(AppSession.UserId > 0, CObj(AppSession.UserId), DBNull.Value))
                    cmd.Parameters.AddWithValue("@a", action)
                    cmd.Parameters.AddWithValue("@d", description)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' A failed log must never block the real action
        End Try
    End Sub
End Module