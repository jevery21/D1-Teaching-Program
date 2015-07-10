Public Class Main_Menu

    Private Sub btnquit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnquit.Click 'Declares quit button'
        End 'This is used so that when the user presses the quit button the debugging of the solution ends and exits the program'
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "Run" Then 'If the user presses the drop down button on the combobox and selects the "Run" option then the program will take the user to form 2 and hide this form'
            Run.Show()
            Me.Hide()
        End If
        If ComboBox1.SelectedItem = "Timed Run" Then 'If the user presses the drop down button on the combobox and selects the "Timed Run" option then the program will take the user to form 3 and hide this form'
            Timed_Run.Show()
            Me.Hide()
        End If
        If ComboBox1.SelectedItem = "Times Achieved" Then 'If the user presses the drop down button on the combobox and selects the "Times Achieved" option then the program will take the user to form 4 and hide this form'
            Times_achieved.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnt.Click 'Declares "Teacher's Section" button'
        Teacher_Login.Show() 'When the user clicks the "Teacher's Section" button the program will take the user to Form 5 and hide this form'
        Me.Hide()
    End Sub

End Class


