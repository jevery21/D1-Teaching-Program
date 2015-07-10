Public Class Forename_Entry

    Structure timerecords
        <VBFixedString(50)> Dim forename As String
        Dim time1min As Integer
        Dim time1sec As Integer
        Dim time1millisec As Integer
    End Structure

    Dim namelength As Integer
    Dim buffer As timerecords
    Dim recno As Integer

    Private Sub Forename_Entry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        buffer.time1millisec = Timed_Run.millisec
        buffer.time1sec = Timed_Run.sec
        buffer.time1min = Timed_Run.min
        Label5.Text = buffer.time1min & ":" & buffer.time1sec & ":" & buffer.time1millisec
        recno = 0
        FileOpen(1, "Leaderboard.dat", OpenMode.Random, , , Len(buffer))

        While Not EOF(1) And recno <= 99
            FileGet(1, buffer)
            recno = recno + 1
        End While

        If recno > 99 Then
            MsgBox("Data not saved because the maximum of 100 records has been reached; contact Andy Bradley", MsgBoxStyle.OkOnly, "D1 Teaching project")
            FileClose(1)
            Timed_Run.Close()
            Main_Menu.Show()
            Me.Hide()
        End If
        FileClose(1)
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        namelength = TextBox1.TextLength
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If namelength > 50 Or TextBox1.Text = "" Then
            MsgBox("This is an invalid forename because it either contains no characters or it contains over 50 characters. Can you please enter your forename again?", MsgBoxStyle.OkOnly, "D1 Teaching project")
        Else : buffer.forename = TextBox1.Text

            buffer.time1millisec = Timed_Run.millisec
            buffer.time1sec = Timed_Run.sec
            buffer.time1min = Timed_Run.min
            Label5.Text = buffer.time1min & ":" & buffer.time1sec & ":" & buffer.time1millisec
            FileOpen(1, "Leaderboard.dat", OpenMode.Random, , , Len(buffer))
            FilePut(1, buffer, recno + 1)
            FileClose(1)
            recno = recno + 1
            MsgBox("Your forename and the time you acheived have been saved to the leader board.", MsgBoxStyle.OkOnly, "D1 Teaching project")
            Timed_Run.Close()
            Main_Menu.ComboBox1.Text = "Kruskal's algorithm"
            Main_Menu.Show()
            Me.Close()
        End If
    End Sub
End Class