Imports System.Drawing
Imports System.Windows.Forms

Public Module PagerHelper

    ''' Creates the pager and lays the form out as:  grid  >  pager bar  >  Name/Position strip
    Public Function Create(grid As DataGridView) As GridPager
        Dim host As Control = grid.Parent
        Dim pg As New GridPager(grid)
        Dim bar As Control = pg.BarControl

        ' remember how the designer placed the grid
        Dim wasManual As Boolean = (grid.Dock = DockStyle.None)
        Dim rightGap As Integer = Math.Max(0, grid.Left)

        host.SuspendLayout()

        ' 1. find (or build) the Name / Position strip
        Dim form As Control = If(host.FindForm(), host)
        Dim footer As Control = FindFooter(host)
        If footer Is Nothing AndAlso form IsNot host Then footer = Nothing   ' strip lives on the form, outside host
        Dim outer As Control = Nothing
        If footer Is Nothing Then outer = FindFooter(form)
        If footer Is Nothing AndAlso outer Is Nothing AndAlso form.Controls.Find("lblname", True).Length = 0 Then
            footer = BuildFooter(host)
        End If

        ' 2. docking order: the control sent to the back is docked first (very bottom)
        bar.Dock = DockStyle.Bottom
        host.Controls.Add(bar)
        If footer IsNot Nothing Then
            footer.Dock = DockStyle.Bottom
            footer.SendToBack()
        End If
        If outer IsNot Nothing Then
            outer.Dock = DockStyle.Bottom
            outer.SendToBack()
        End If

        ' 3. the grid
        If wasManual Then
            grid.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        Else
            grid.Dock = DockStyle.Fill
            grid.BringToFront()
        End If

        host.ResumeLayout(True)

        ' grids placed by hand in the designer: stretch them down to the top of the pager bar
        Dim fit As Action =
            Sub()
                If Not wasManual Then Exit Sub
                Dim h As Integer = bar.Top - grid.Top
                Dim w As Integer = host.ClientSize.Width - grid.Left - rightGap
                If h < 60 OrElse w < 100 Then Exit Sub
                If grid.Height <> h OrElse grid.Width <> w Then grid.SetBounds(grid.Left, grid.Top, w, h)
            End Sub

        AddHandler host.Layout, Sub(s As Object, e As LayoutEventArgs) fit()
        host.PerformLayout()
        fit()

        Dim f As Form = host.FindForm()
        If f IsNot Nothing Then UiHelpers.FillHeader(f)
        Return pg
    End Function

    Private Function FindFooter(container As Control) As Control
        For Each c As Control In container.Controls
            If c.Dock = DockStyle.Bottom AndAlso c.Controls.Find("lblname", True).Length > 0 Then Return c
        Next
        Return Nothing
    End Function

    ' Same look as the Name / Position panel on the other forms
    Private Function BuildFooter(host As Control) As Control
        Dim brown As Color = Color.FromArgb(88, 47, 25)
        Dim captionFont As New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point)
        Dim valueFont As New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)

        Dim strip As New FlowLayoutPanel()
        strip.Name = "pnlNamePosition"
        strip.BackColor = Color.White
        strip.Dock = DockStyle.Bottom
        strip.WrapContents = False
        strip.FlowDirection = FlowDirection.LeftToRight
        strip.Padding = New Padding(4, 2, 0, 0)
        strip.Height = valueFont.Height + 8

        strip.Controls.Add(MakeLabel("Name:", "", captionFont, brown, 2))
        strip.Controls.Add(MakeLabel("Name", "lblname", valueFont, brown, 40))
        strip.Controls.Add(MakeLabel("Position:", "", captionFont, brown, 2))
        strip.Controls.Add(MakeLabel("Position", "lblposition", valueFont, brown, 0))

        host.Controls.Add(strip)
        Return strip
    End Function

    Private Function MakeLabel(text As String, name As String, f As Font, c As Color, gapRight As Integer) As Label
        Dim lb As New Label()
        lb.AutoSize = True
        lb.Text = text
        lb.Font = f
        lb.ForeColor = c
        lb.BackColor = Color.Transparent
        lb.Margin = New Padding(0, 0, gapRight, 0)
        If name <> "" Then lb.Name = name
        Return lb
    End Function
End Module