Imports MySql.Data.MySqlClient

Public Class frmManageSY
    Private selectedSY As SchoolYearInfo = Nothing

    Private Sub frmManageSY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With dgvsy
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        txtStudentID.MaxLength = 20
        AddHandler SchoolYearContext.Changed, AddressOf OnViewingChanged
        ClearForm()
        LoadList()
    End Sub

    Private Sub frmManageSY_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        RemoveHandler SchoolYearContext.Changed, AddressOf OnViewingChanged
    End Sub

    Private Sub frmManageSY_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then LoadList()
    End Sub

    Private Sub OnViewingChanged()
        If Me.IsDisposed Then Exit Sub
        LoadList()
    End Sub

    ' ------------------------------------------------------------ list
    Private Sub LoadList()
        dgvsy.Rows.Clear()
        Label13.Text = "Currently Viewing: " & SchoolYearContext.Selected.Name
        Try
            For Each s As SchoolYearInfo In SchoolYearContext.GetAll()
                Dim row As DataGridViewRow = dgvsy.Rows(dgvsy.Rows.Add())
                row.Cells("SYName").Value = s.Name
                row.Cells("StartDate").Value = s.StartDate.ToString("MM/dd/yyyy")
                row.Cells("EndDate").Value = s.EndDate.ToString("MM/dd/yyyy")
                row.Tag = s
                If s.Id = SchoolYearContext.Selected.Id Then row.DefaultCellStyle.Font = New Font(dgvsy.Font, FontStyle.Bold)
            Next
        Catch ex As Exception
            MsgBox("Could not load the school years: " & ex.Message & vbCrLf &
                   "Did you run the SchoolYear SQL script?", vbCritical, "Manage School Year")
        End Try
        dgvsy.ClearSelection()
    End Sub

    Private Sub dgvsy_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsy.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim s As SchoolYearInfo = TryCast(dgvsy.Rows(e.RowIndex).Tag, SchoolYearInfo)
        If s Is Nothing Then Exit Sub
        selectedSY = s
        txtStudentID.Text = s.Name
        DateTimePicker1.Value = s.StartDate
        DateTimePicker2.Value = s.EndDate
    End Sub

    Private Sub ClearForm()
        selectedSY = Nothing
        txtStudentID.Clear()
        DateTimePicker1.Value = Date.Today
        DateTimePicker2.Value = Date.Today.AddYears(1).AddDays(-1)
        dgvsy.ClearSelection()
    End Sub

    ' ------------------------------------------------------------ validation
    Private Function InputsAreValid(excludeId As Integer) As Boolean
        Dim name As String = txtStudentID.Text.Trim()
        If name = "" Then
            MsgBox("Please enter the school year name (for example 2026-2027).", vbExclamation, "Manage School Year")
            txtStudentID.Focus()
            Return False
        End If
        If DateTimePicker1.Value.Date >= DateTimePicker2.Value.Date Then
            MsgBox("The End Date must be after the Start Date.", vbExclamation, "Manage School Year")
            Return False
        End If

        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT sy_name FROM SchoolYear WHERE sy_id <> @id " &
                    "AND (sy_name = @n OR (start_date <= @e AND end_date >= @s)) LIMIT 1", conn)
                    cmd.Parameters.AddWithValue("@id", excludeId)
                    cmd.Parameters.AddWithValue("@n", name)
                    cmd.Parameters.AddWithValue("@s", DateTimePicker1.Value.Date)
                    cmd.Parameters.AddWithValue("@e", DateTimePicker2.Value.Date)
                    Dim clash As Object = cmd.ExecuteScalar()
                    If clash IsNot Nothing Then
                        MsgBox("This clashes with school year '" & clash.ToString() & "' (same name or overlapping dates).",
                               vbExclamation, "Manage School Year")
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not check the school year: " & ex.Message, vbCritical, "Manage School Year")
            Return False
        End Try
        Return True
    End Function

    ' ------------------------------------------------------------ add
    Private Sub btnsavereq_Click(sender As Object, e As EventArgs) Handles btnsavereq.Click
        If Not InputsAreValid(0) Then Exit Sub
        If Not UiHelpers.Confirm("add", "this school year", "Manage School Year") Then Exit Sub
        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("INSERT INTO SchoolYear (sy_name, start_date, end_date) VALUES (@n, @s, @e)", conn)
                    cmd.Parameters.AddWithValue("@n", txtStudentID.Text.Trim())
                    cmd.Parameters.AddWithValue("@s", DateTimePicker1.Value.Date)
                    cmd.Parameters.AddWithValue("@e", DateTimePicker2.Value.Date)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not add the school year: " & ex.Message, vbCritical, "Manage School Year")
            Exit Sub
        End Try
        DBConnection.LogActivity("Add School Year", "Created school year '" & txtStudentID.Text.Trim() & "'.")
        MsgBox("School year added.", vbInformation, "Manage School Year")
        ClearForm()
        SchoolYearContext.NotifyListChanged()
    End Sub

    ' ------------------------------------------------------------ edit
    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click      ' Edit button
        If selectedSY Is Nothing Then
            MsgBox("Select a school year from the list first.", vbExclamation, "Manage School Year")
            Exit Sub
        End If
        If Not InputsAreValid(selectedSY.Id) Then Exit Sub
        If Not UiHelpers.Confirm("update", "this school year", "Manage School Year") Then Exit Sub
        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE SchoolYear SET sy_name=@n, start_date=@s, end_date=@e WHERE sy_id=@id", conn)
                    cmd.Parameters.AddWithValue("@n", txtStudentID.Text.Trim())
                    cmd.Parameters.AddWithValue("@s", DateTimePicker1.Value.Date)
                    cmd.Parameters.AddWithValue("@e", DateTimePicker2.Value.Date)
                    cmd.Parameters.AddWithValue("@id", selectedSY.Id)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not update the school year: " & ex.Message, vbCritical, "Manage School Year")
            Exit Sub
        End Try
        DBConnection.LogActivity("Update School Year", "Updated school year '" & txtStudentID.Text.Trim() & "'.")
        MsgBox("School year updated.", vbInformation, "Manage School Year")
        ClearForm()
        SchoolYearContext.NotifyListChanged()
    End Sub

    ' ------------------------------------------------------------ delete
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click        ' Delete button
        If selectedSY Is Nothing Then
            MsgBox("Select a school year from the list first.", vbExclamation, "Manage School Year")
            Exit Sub
        End If
        Dim name As String = selectedSY.Name
        If MsgBox("Delete school year '" & name & "'?" & vbCrLf &
                  "Borrow records are NOT deleted - only this school year is removed from the list.",
                  vbQuestion + vbYesNo, "Delete School Year") <> vbYes Then Exit Sub
        Try
            Using conn = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("DELETE FROM SchoolYear WHERE sy_id = @id", conn)
                    cmd.Parameters.AddWithValue("@id", selectedSY.Id)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Could not delete the school year: " & ex.Message, vbCritical, "Manage School Year")
            Exit Sub
        End Try
        DBConnection.LogActivity("Delete School Year", "Deleted school year '" & name & "'.")
        MsgBox("School year deleted.", vbInformation, "Manage School Year")
        ClearForm()
        SchoolYearContext.NotifyListChanged()
    End Sub

    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        ClearForm()
    End Sub

    ' ------------------------------------------------------------ change the school year being viewed
    Private Sub btnupd_Click(sender As Object, e As EventArgs) Handles btnupd.Click           ' Change S.Y.
        If selectedSY Is Nothing Then
            MsgBox("Select a school year from the list first.", vbExclamation, "Manage School Year")
            Exit Sub
        End If
        SchoolYearContext.Selected = selectedSY
        MsgBox("Now viewing S.Y. " & selectedSY.Name & ".", vbInformation, "Manage School Year")
    End Sub
End Class