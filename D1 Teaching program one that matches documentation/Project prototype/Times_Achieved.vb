Public Class Times_achieved

    Public list(99) As Forename_Entry.timerecords
    Dim buffer As Forename_Entry.timerecords

    Private Sub btnquit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnquit.Click
        Main_Menu.ComboBox1.Text = "Kruskal's algorithm"
        Main_Menu.Show()
        Me.Close()

    End Sub

    Private Sub Times_Achieved_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim i As Integer = 0
        FileOpen(1, "Leaderboard.dat", OpenMode.Random, , , Len(buffer))

        While Not EOF(1)
            FileGet(1, buffer)
            list(i) = buffer
            i = i + 1
        End While

        FileClose(1)
        bubblesort(list)
        i = 0

        While list(i).forename > ""
            ListBox1.Items.Add(i + 1 & vbTab & list(i).forename & vbTab & list(i).time1min & ":" & list(i).time1sec & ":" & list(i).time1millisec)
            i = i + 1
        End While
    End Sub

    Sub bubblesort(ByRef times() As Forename_Entry.timerecords)
        Dim flag As Boolean = True
        Dim swapforbidden As Boolean
        Dim count As Integer
        Do Until flag = False
            flag = False
            For count = 0 To UBound(times) - 1
                swapforbidden = False
                If times(count + 1).time1min > 0 Or times(count + 1).time1sec > 0 Or times(count + 1).time1millisec > 0 Then
                    If times(count).time1min > times(count + 1).time1min Then
                        swap(times(count), times(count + 1), flag)
                        swapforbidden = True

                    ElseIf times(count).time1min < times(count + 1).time1min Then
                        swapforbidden = True
                    End If
                    If swapforbidden = False Then
                        If times(count).time1sec > times(count + 1).time1sec And times(count).time1min <= times(count + 1).time1min Then
                            swap(times(count), times(count + 1), flag)
                            swapforbidden = True

                        ElseIf times(count).time1sec < times(count + 1).time1sec Then
                            swapforbidden = True
                        End If
                    End If
                    If swapforbidden = False Then
                        If times(count).time1millisec > times(count + 1).time1millisec Then
                            swap(times(count), times(count + 1), flag)
                            swapforbidden = True
                        End If
                    End If
                End If
            Next
        Loop
    End Sub
    Sub swap(ByRef i As Forename_Entry.timerecords, ByRef j As Forename_Entry.timerecords, ByRef f As Boolean)
        Dim temp As Forename_Entry.timerecords
        temp = i
        i = j
        j = temp
        f = True
    End Sub
End Class