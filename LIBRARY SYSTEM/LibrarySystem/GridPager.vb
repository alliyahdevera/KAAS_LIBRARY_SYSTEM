Imports System.Drawing
Imports System.Windows.Forms

' Reusable pagination bar for any DataGridView.
' Usage in a form:
'     Private pager As GridPager
'     If pager Is Nothing Then pager = New GridPager(MyGrid)   ' once, when the form is shown
'     ... fill the grid as usual ...
'     pager.Apply()                                             ' after every load/refresh
Public Class GridPager
    Private ReadOnly grid As DataGridView
    Private ReadOnly bar As New FlowLayoutPanel()
    Private ReadOnly btnFirst As New Button()
    Private ReadOnly btnPrev As New Button()
    Private ReadOnly btnNext As New Button()
    Private ReadOnly btnLast As New Button()
    Private ReadOnly lblInfo As New Label()
    Private ReadOnly lblSize As New Label()
    Private ReadOnly cboSize As New ComboBox()
    Private page As Integer = 1
    Private pageSize As Integer = 20

    Public Sub New(g As DataGridView, Optional rowsPerPage As Integer = 20)
        grid = g
        pageSize = rowsPerPage

        Dim brown As Color = Color.FromArgb(88, 47, 25)
        btnFirst.Text = "<<" : btnPrev.Text = "<" : btnNext.Text = ">" : btnLast.Text = ">>"
        For Each b As Button In {btnFirst, btnPrev, btnNext, btnLast}
            b.FlatStyle = FlatStyle.Flat
            b.FlatAppearance.BorderSize = 0
            b.BackColor = brown
            b.ForeColor = Color.White
            b.Size = New Size(36, 28)
            b.Margin = New Padding(3, 4, 3, 4)
        Next

        lblInfo.AutoSize = False
        lblInfo.Size = New Size(260, 28)
        lblInfo.TextAlign = ContentAlignment.MiddleCenter
        lblInfo.Margin = New Padding(3, 4, 3, 4)

        lblSize.Text = "Rows per page:"
        lblSize.AutoSize = False
        lblSize.Size = New Size(95, 28)
        lblSize.TextAlign = ContentAlignment.MiddleRight
        lblSize.Margin = New Padding(15, 4, 3, 4)

        cboSize.DropDownStyle = ComboBoxStyle.DropDownList
        cboSize.Width = 60
        cboSize.Margin = New Padding(3, 7, 3, 4)
        cboSize.Items.AddRange(New Object() {"10", "20", "50", "100"})
        If Not cboSize.Items.Contains(pageSize.ToString()) Then cboSize.Items.Add(pageSize.ToString())
        cboSize.SelectedItem = pageSize.ToString()

        bar.Dock = DockStyle.Bottom
        bar.Height = 38
        bar.WrapContents = False
        bar.FlowDirection = FlowDirection.LeftToRight
        bar.Padding = New Padding(6, 0, 0, 0)
        bar.Controls.AddRange(New Control() {btnFirst, btnPrev, lblInfo, btnNext, btnLast, lblSize, cboSize})

        ' put the bar under the grid, above any "name / position" footer panel
        Dim host As Control = grid.Parent
        host.Controls.Add(bar)
        grid.Dock = DockStyle.Fill
        host.Controls.SetChildIndex(bar, 0)
        grid.BringToFront()

        AddHandler btnFirst.Click, Sub() GoTo1(1)
        AddHandler btnPrev.Click, Sub() GoTo1(page - 1)
        AddHandler btnNext.Click, Sub() GoTo1(page + 1)
        AddHandler btnLast.Click, Sub() GoTo1(Integer.MaxValue)
        AddHandler cboSize.SelectedIndexChanged,
            Sub()
                pageSize = CInt(cboSize.Text)
                Apply()
            End Sub
    End Sub

    Private Sub GoTo1(target As Integer)
        page = target
        Apply(True)
    End Sub

    ' Call after the grid has been (re)filled. keepPage = True stays on the current page.
    Public Sub Apply(Optional keepPage As Boolean = False)
        Dim total As Integer = grid.Rows.Count
        Dim pages As Integer = Math.Max(1, CInt(Math.Ceiling(total / pageSize)))
        If Not keepPage Then page = 1
        If page > pages Then page = pages
        If page < 1 Then page = 1

        Dim firstIdx As Integer = (page - 1) * pageSize
        Dim lastIdx As Integer = firstIdx + pageSize - 1

        grid.CurrentCell = Nothing        ' a row cannot be hidden while it holds the current cell
        For i As Integer = 0 To total - 1
            grid.Rows(i).Visible = (i >= firstIdx AndAlso i <= lastIdx)
        Next
        grid.ClearSelection()

        If total = 0 Then
            lblInfo.Text = "No records"
        Else
            lblInfo.Text = $"Page {page} of {pages}   ({firstIdx + 1}-{Math.Min(total, lastIdx + 1)} of {total})"
        End If
        btnFirst.Enabled = (page > 1)
        btnPrev.Enabled = (page > 1)
        btnNext.Enabled = (page < pages)
        btnLast.Enabled = (page < pages)
    End Sub
End Class