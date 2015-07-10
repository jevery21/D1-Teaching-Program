Public Class Update_Kruskal

    Public list(99) As Forename_Entry.timerecords
    Dim i As Integer = 0
    Dim buffer As Forename_Entry.timerecords

    Private Sub Update_Kruskal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub btnquit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnquit.Click
        Teacher_Menu.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgBox("Delete this record?", MsgBoxStyle.YesNo, "D1 Teaching project") = vbYes Then

            If ListBox1.SelectedIndex > -1 Then
                list(ListBox1.SelectedIndex).forename = ""
                ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            End If

        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FileOpen(1, "Kept records.dat", OpenMode.Random, , , Len(buffer))
        If MsgBox("Save Changes?", MsgBoxStyle.YesNo, "D1 Teaching project") = vbYes Then
            For i As Integer = 0 To UBound(list)
                If list(i).forename <> "" Then
                    FilePut(1, list(i))
                End If
            Next
            FileClose(1)
            My.Computer.FileSystem.DeleteFile("Leaderboard.dat")
            FileSystem.Rename("Kept records.dat", "Leaderboard.dat")

        End If
    End Sub
End Class