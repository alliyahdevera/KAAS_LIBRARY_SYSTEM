Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class SchoolYearInfo
    Public Property Id As Integer
    Public Property Name As String
    Public Property StartDate As Date
    Public Property EndDate As Date

    Public Overrides Function ToString() As String
        Return Name                       ' what the combo box displays
    End Function
End Class

Public NotInheritable Class SchoolYearContext
    Private Sub New()
    End Sub

    Public Shared ReadOnly AllTime As New SchoolYearInfo With {.Id = 0, .Name = "All Time"}
    Private Shared _selected As SchoolYearInfo = AllTime

    Public Shared Event Changed()         ' the school year being viewed changed
    Public Shared Event ListChanged()     ' a school year was added / edited / deleted

    ' School year the admin is viewing
    Public Shared Property Selected As SchoolYearInfo
        Get
            Return _selected
        End Get
        Set(value As SchoolYearInfo)
            Dim v As SchoolYearInfo = If(value, AllTime)
            If v.Id = _selected.Id Then Exit Property
            _selected = v
            RaiseEvent Changed()
        End Set
    End Property

    Public Shared Function GetAll() As List(Of SchoolYearInfo)
        Dim list As New List(Of SchoolYearInfo)
        Using conn = DBConnection.GetConnection()
            conn.Open()
            Using cmd As New MySqlCommand("SELECT sy_id, sy_name, start_date, end_date FROM SchoolYear ORDER BY start_date DESC", conn)
                Using r As MySqlDataReader = cmd.ExecuteReader()
                    While r.Read()
                        list.Add(New SchoolYearInfo With {
                            .Id = Convert.ToInt32(r("sy_id")),
                            .Name = r("sy_name").ToString(),
                            .StartDate = Convert.ToDateTime(r("start_date")),
                            .EndDate = Convert.ToDateTime(r("end_date"))})
                    End While
                End Using
            End Using
        End Using
        Return list
    End Function

    ' The school year that contains today (Nothing if there is none)
    Public Shared Function Current() As SchoolYearInfo
        Try
            For Each s As SchoolYearInfo In GetAll()
                If Date.Today >= s.StartDate.Date AndAlso Date.Today <= s.EndDate.Date Then Return s
            Next
        Catch
        End Try
        Return Nothing
    End Function

    ' Called when the admin logs in
    Public Shared Sub ResetToCurrent()
        _selected = If(Current(), AllTime)
    End Sub

    ' Called after Manage S.Y. adds / edits / deletes a school year
    Public Shared Sub NotifyListChanged()
        Dim fresh As SchoolYearInfo = Nothing
        Try
            fresh = GetAll().FirstOrDefault(Function(s) s.Id = _selected.Id)
        Catch
        End Try
        _selected = If(fresh, AllTime)
        RaiseEvent ListChanged()
        RaiseEvent Changed()
    End Sub

    ' Only the ADMIN works by school year (to look back and generate reports).
    ' Librarian, student and teacher always see live data (All Time), so an old penalty or loan never disappears.
    Public Shared Function Scope() As SchoolYearInfo
        If AppSession.Role = "Admin" Then Return _selected
        Return AllTime
    End Function

    ' SQL condition for a date column, e.g. "(t.borrow_date BETWEEN '2026-06-01' AND '2027-05-31')", or "1 = 1" for All Time.
    ' Pass isDateTime:=True for DATETIME columns (like ActivityLogs.log_time) so the whole last day is included.
    ' The dates come from the app (Date values), never from typed text.
    Public Shared Function Between(column As String, Optional isDateTime As Boolean = False) As String
        Dim s As SchoolYearInfo = Scope()
        If s.Id = 0 Then Return "1 = 1"
        Dim startTxt As String = s.StartDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
        If isDateTime Then
            Dim nextTxt As String = s.EndDate.Date.AddDays(1).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
            Return "(" & column & " >= '" & startTxt & "' AND " & column & " < '" & nextTxt & "')"
        End If
        Return "(" & column & " BETWEEN '" & startTxt & "' AND '" &
               s.EndDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) & "')"
    End Function

    ' Text for the "Showing" label on the admin forms
    Public Shared Function ShowingText() As String
        If _selected.Id = 0 Then Return "Showing: All Time"
        Return "Showing: S.Y. " & _selected.Name
    End Function

    ' Added to export file names, e.g. "_2026-2027" or "_All_Time" (empty for non-admin roles)
    Public Shared Function FileTag() As String
        If AppSession.Role <> "Admin" Then Return ""
        Dim n As String = If(_selected.Id = 0, "All_Time", _selected.Name)
        For Each ch As Char In Path.GetInvalidFileNameChars()
            n = n.Replace(ch, "_"c)
        Next
        Return "_" & n.Replace(" ", "_")
    End Function
End Class

' ---------------------------------------------------------------
' "Showing: S.Y. 2026-2027" label on the admin forms.
' If the form already has a Label named lblSyShowing (drawn in the designer) it is used;
' otherwise one is created to the right of the title label (titleName) or at x, y.
' It is hidden for every role except Admin.
' ---------------------------------------------------------------
Public Module SchoolYearBanner
    Private Const BannerName As String = "lblSyShowing"

    Public Sub Apply(f As Form, Optional titleName As String = "", Optional x As Integer = 36, Optional y As Integer = 5)
        Dim isAdmin As Boolean = (AppSession.Role = "Admin")
        Dim lbl As Label = Nothing
        Dim found() As Control = f.Controls.Find(BannerName, True)
        If found.Length > 0 Then lbl = TryCast(found(0), Label)

        If lbl Is Nothing Then
            If Not isAdmin Then Exit Sub
            lbl = New Label()
            lbl.Name = BannerName
            lbl.AutoSize = True
            lbl.BackColor = Color.Transparent
            lbl.ForeColor = Color.FromArgb(90, 50, 60)
            lbl.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
            lbl.Text = SchoolYearContext.ShowingText()

            Dim host As Control = f
            Dim loc As New Point(x, y)
            If titleName <> "" Then
                Dim t() As Control = f.Controls.Find(titleName, True)
                If t.Length > 0 Then
                    host = t(0).Parent
                    loc = New Point(t(0).Right + 16, t(0).Top + (t(0).Height - lbl.PreferredHeight) \ 2)
                End If
            End If
            lbl.Location = loc
            host.Controls.Add(lbl)
            lbl.BringToFront()
        End If

        lbl.Visible = isAdmin
        lbl.Text = SchoolYearContext.ShowingText()
    End Sub
End Module