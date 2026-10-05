Public Class frmHelp
    Private Sub frmHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) 
        frmStudentMenu.Show()
        Me.Hide()

    End Sub
End Class