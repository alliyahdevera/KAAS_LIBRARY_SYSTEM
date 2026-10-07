Imports MySql.Data.MySqlClient

' ---------------------------------------------------------------
' Adds a sidebar button that looks like an existing one,
' placed directly under it. Call BEFORE the menu attaches its click handlers.
' ---------------------------------------------------------------
Module MenuBuilder
    Public Function AddMenuButton(menu As Form, afterButtonName As String, caption As String) As Button
        Dim found() As Control = menu.Controls.Find(afterButtonName, True)
        If found.Length = 0 OrElse Not TypeOf found(0) Is Button Then Return Nothing
        Dim tpl As Button = DirectCast(found(0), Button)

        Dim nb As New Button()
        nb.Name = "btn" & caption.Replace(" ", "")
        nb.Text = "     " & caption
        nb.Dock = tpl.Dock
        nb.Size = tpl.Size
        nb.Margin = tpl.Margin
        nb.FlatStyle = tpl.FlatStyle
        nb.FlatAppearance.BorderSize = 0
        nb.BackColor = tpl.BackColor
        nb.ForeColor = tpl.ForeColor
        nb.Font = tpl.Font
        nb.Image = tpl.Image
        nb.TextAlign = tpl.TextAlign
        nb.TextImageRelation = tpl.TextImageRelation
        nb.UseVisualStyleBackColor = False

        Dim host As Control = tpl.Parent
        host.Controls.Add(nb)
        host.Controls.SetChildIndex(nb, host.Controls.GetChildIndex(tpl))
        Return nb
    End Function
End Module

' ---------------------------------------------------------------
' Book copy helpers
' ---------------------------------------------------------------
Module CopyData
    Public ReadOnly AllConditions() As String = {"New", "Good", "Fair", "Poor", "Damaged", "Lost"}
    Public ReadOnly AddConditions() As String = {"New", "Good", "Fair", "Poor"}

    ' Keeps the lost/damaged log in step with a verified return (call inside a transaction).
    ' Any older report for the same transaction is replaced, so re-verifying never duplicates.
    Public Sub LogReturnIncident(conn As MySqlConnection, tx As MySqlTransaction,
                                 transactionId As Integer, condition As String)
        Using del As New MySqlCommand("DELETE FROM LostDamagedBooks WHERE transaction_id = @t", conn, tx)
            del.Parameters.AddWithValue("@t", transactionId)
            del.ExecuteNonQuery()
        End Using

        If condition <> "Damaged" AndAlso condition <> "Lost" Then Exit Sub

        Using ins As New MySqlCommand(
            "INSERT INTO LostDamagedBooks (copy_id, transaction_id, member_id, incident_type, incident_date, reported_by, remarks) " &
            "SELECT t.copy_id, t.transaction_id, t.member_id, @type, IFNULL(t.return_date, CURDATE()), @u, " &
            "       'Reported when the book was returned' " &
            "FROM BorrowTransaction t WHERE t.transaction_id = @t", conn, tx)
            ins.Parameters.AddWithValue("@type", condition)
            ins.Parameters.AddWithValue("@u", If(AppSession.UserId > 0, CObj(AppSession.UserId), DBNull.Value))
            ins.Parameters.AddWithValue("@t", transactionId)
            ins.ExecuteNonQuery()
        End Using
    End Sub
End Module