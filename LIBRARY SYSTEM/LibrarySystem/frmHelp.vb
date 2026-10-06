Public Class frmHelp

    Private Sub frmHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UiHelpers.FillHeader(Me)          ' name, position, today
    End Sub

    Private Sub frmHelp_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then UiHelpers.FillHeader(Me)
    End Sub

End Class