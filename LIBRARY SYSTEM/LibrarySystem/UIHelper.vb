Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Module UIHelper


    Public Sub RoundPanel(panel As Panel, Optional radius As Integer = 20)
        If panel Is Nothing OrElse panel.Width <= 0 OrElse panel.Height <= 0 Then Exit Sub

        Using path As GraphicsPath = GetRoundedPath(panel.ClientRectangle, radius)
            panel.Region = New Region(path)
        End Using
    End Sub

    Public Sub DrawPanelShadow(g As Graphics, panel As Panel, Optional shadowSize As Integer = 6, Optional radius As Integer = 20)
        If panel Is Nothing OrElse Not panel.Visible OrElse panel.Width <= 0 OrElse panel.Height <= 0 Then Exit Sub


        Dim shadowRect As New Rectangle(
            panel.Left - 1,
            panel.Top + 2,
            panel.Width + (shadowSize \ 2),
            panel.Height + (shadowSize \ 2)
        )

        g.SmoothingMode = SmoothingMode.AntiAlias

        For i As Integer = shadowSize To 1 Step -1
            Dim alpha As Integer = CInt(20 * (1.0 - (i / shadowSize)))
            Using pen As New Pen(Color.FromArgb(alpha, 0, 0, 0), CSng(i * 1.5F))
                pen.LineJoin = LineJoin.Round
                Using path As GraphicsPath = GetRoundedPath(shadowRect, radius)
                    g.DrawPath(pen, path)
                End Using
            End Using
        Next
    End Sub


    Private Function GetRoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()

        Dim maxRadius As Integer = Math.Min(rect.Width \ 2, rect.Height \ 2)
        If radius > maxRadius Then radius = maxRadius
        If radius <= 0 Then radius = 1

        Dim d As Integer = radius * 2

        path.AddArc(rect.X, rect.Y, d, d, 180, 90)
        path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90)
        path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90)
        path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90)
        path.CloseFigure()

        Return path
    End Function

End Module