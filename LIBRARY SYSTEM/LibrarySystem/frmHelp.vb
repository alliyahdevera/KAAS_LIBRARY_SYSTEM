Public Class frmHelp

    Private Sub frmHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UiHelpers.FillHeader(Me)

        RoundPanel(pnlb)
        RoundPanel(pnlbh)
        RoundPanel(pnlbr)
        RoundPanel(pnlfaq)
        RoundPanel(pnlh)
        RoundPanel(pnlp)
        RoundPanel(pnlrb)
    End Sub

    Private Sub frmHelp_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then UiHelpers.FillHeader(Me)
    End Sub

    Private Sub frmHelp_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        ' Draw shadows behind target panels
        UIHelper.DrawPanelShadow(e.Graphics, pnlb, shadowSize:=5)
        UIHelper.DrawPanelShadow(e.Graphics, pnlbh, shadowSize:=5)
        UIHelper.DrawPanelShadow(e.Graphics, pnlbr, shadowSize:=5)
        UIHelper.DrawPanelShadow(e.Graphics, pnlfaq, shadowSize:=5)
        UIHelper.DrawPanelShadow(e.Graphics, pnlh, shadowSize:=5)
        UIHelper.DrawPanelShadow(e.Graphics, pnlp, shadowSize:=5)
        UIHelper.DrawPanelShadow(e.Graphics, pnlrb, shadowSize:=5)
    End Sub

End Class