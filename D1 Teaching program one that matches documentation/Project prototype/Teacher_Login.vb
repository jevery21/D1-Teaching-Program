Public Class Teacher_Login

    Private Sub btnquit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnquit.Click
        Main_Menu.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "Euler" Then
            Teacher_Menu.Show()
            Me.Close()
        Else
            MsgBox("The password you entered was incorrect. Please enter a different password to gain access to the teacher page.", MsgBoxStyle.OkOnly, "D1 Teaching project")
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub Teacher_Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class