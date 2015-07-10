Public Class Teacher_Menu
    Private Sub btnquit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnquit.Click
        Main_Menu.Show()
        Me.Close()
    End Sub

    Private Sub btnk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnk.Click
        Update_Kruskal.Show()
        Me.Hide()
    End Sub

    Private Sub Teacher_Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class