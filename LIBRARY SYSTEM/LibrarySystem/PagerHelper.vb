Imports System.Linq
Imports System.Windows.Forms

Public Module PagerHelper

    ''' Creates the GridPager and keeps its bar ABOVE the Name / Position strip at the bottom of the form.
    Public Function Create(grid As DataGridView) As GridPager
        Dim host As Control = grid.Parent
        host.PerformLayout()

        ' build the pager and find the bar it added
        Dim before As New HashSet(Of Control)(host.Controls.Cast(Of Control)())
        Dim pg As New GridPager(grid)
        Dim bar As Control = host.Controls.Cast(Of Control)().FirstOrDefault(Function(c) Not before.Contains(c))
        If bar Is Nothing Then Return pg

        host.PerformLayout()
        grid.Dock = DockStyle.None
        bar.Dock = DockStyle.None
        grid.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        bar.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        Dim place As Action =
            Sub()
                ' top of the Name / Position strip (small controls in the lower half of the form)
                Dim footerTop As Integer = host.ClientSize.Height
                For Each c As Control In host.Controls
                    If c Is grid OrElse c Is bar OrElse Not c.Visible Then Continue For
                    If c.Top > grid.Top AndAlso c.Top >= host.ClientSize.Height \ 2 AndAlso c.Height <= 100 Then
                        footerTop = Math.Min(footerTop, c.Top)
                    End If
                Next
                bar.SetBounds(grid.Left, footerTop - bar.Height, grid.Width, bar.Height)
                grid.Height = Math.Max(60, bar.Top - grid.Top)
                bar.BringToFront()
            End Sub

        place()
        AddHandler host.Resize, Sub() If host.IsHandleCreated Then host.BeginInvoke(place)
        Return pg
    End Function
End Module