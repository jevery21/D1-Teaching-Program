Public Class Timed_Run

    Dim weightings(11) As Integer
    Dim done() As Boolean = {False, False, False, False, False, False, False, False, False, False, False, False}
    Dim lowest, high, position, position1, position2, position3, position4, position5, position6, arcschosen, arcscoloured, userchoice As Integer
    Dim listboxdisplayed, started As Boolean
    Public min, sec, millisec As Integer

    Private Sub Timed_Run_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Randomize()
        Getweightings()
        Label1.Text = "A"
        Label3.Text = "B"
        Label4.Text = "C"
        Label5.Text = "D"
        Label6.Text = "E"
        Label7.Text = "F"
        Label8.Text = "G"
        Label9.Text = ""
        Label10.Text = ""
        Label11.Text = ""
        Label12.Text = ""
        Label13.Text = ""
        Label14.Text = ""
        Label15.Text = ""
        Label16.Text = ""
        Label17.Text = ""
        Label18.Text = ""
        Label19.Text = ""
        Label20.Text = ""
        Label23.Text = "0:0:0"
        Label24.Text = ""
        Label25.Text = ""
        ListBox1.Hide()
        listboxdisplayed = False
        userchoice = 0
        arcschosen = 0
        position = 0
        position1 = 0
        position2 = 0
        position3 = 0
        position4 = 0
        position5 = 0
        position6 = 0
    End Sub

    Private Sub Getweightings()
        For i = 0 To 11
            weightings(i) = Math.Ceiling(Rnd() * 20)
        Next
    End Sub

    Private Sub Label29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label29.Click

        If listboxdisplayed = False Then
            ListBox1.Show()
            listboxdisplayed = True

        ElseIf listboxdisplayed = True Then
            ListBox1.Hide()
            listboxdisplayed = False

        End If
    End Sub

    Private Sub btnquit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnquit.Click
        Main_Menu.ComboBox1.Text = "Kruskal's algorithm"
        Main_Menu.Show()
        Me.Close()

    End Sub

    Private Sub btnstart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnstart.Click
        started = True
        btnstart.Hide()
        Label9.Text = weightings(0)
        Label10.Text = weightings(1)
        Label11.Text = weightings(2)
        Label12.Text = weightings(3)
        Label13.Text = weightings(4)
        Label14.Text = weightings(5)
        Label15.Text = weightings(6)
        Label16.Text = weightings(7)
        Label17.Text = weightings(8)
        Label18.Text = weightings(9)
        Label19.Text = weightings(10)
        Label20.Text = weightings(11)

        Do Until arcschosen = 6

            high = highest(weightings)
            lowest = high

            For i = LBound(weightings) To UBound(weightings)
                If lowest >= weightings(i) Then
                    If done(i) = False Then
                        lowest = weightings(i)
                        position = i + 1

                    End If
                End If
            Next

            If TrueorFalse() Then
                arcschosen = arcschosen + 1
                If arcschosen = 1 Then
                    position1 = position
                End If
                If arcschosen = 2 Then
                    position2 = position
                End If
                If arcschosen = 3 Then
                    position3 = position
                End If
                If arcschosen = 4 Then
                    position4 = position
                End If
                If arcschosen = 5 Then
                    position5 = position
                End If
                If arcschosen = 6 Then
                    position6 = position
                End If
            End If

        Loop
        Timer1.Enabled = True
    End Sub

    Function highest(ByVal arr() As Integer) As Integer
        Dim high As Integer = arr(0)
        For i = 1 To UBound(arr)
            If arr(i) > high Then high = arr(i)
        Next
        Return high

    End Function

    Dim cycles(30) As Boolean

    Function TrueorFalse() As Boolean
        Dim i As Integer = 0
        done(position - 1) = True

        If arcschosen >= 3 Then
            If position = 1 Or position = 5 Or position = 4 Then
                If cycles(i) = False Then
                    If done(0) = True And done(4) = True And done(3) = True Then
                        cycles(i) = True
                        Return False
                    Else : i = i + 1
                    End If
                Else : i = i + 1
                End If
            Else : i = i + 1
            End If

            If position = 4 Or position = 10 Or position = 9 Then
                If cycles(i) = False Then
                    If done(3) = True And done(9) = True And done(8) = True Then
                        cycles(i) = True
                        Return False
                    Else : i = i + 1
                    End If
                Else : i = i + 1
                End If
            Else : i = i + 1
            End If

            If position = 5 Or position = 6 Or position = 2 Then
                If cycles(i) = False Then
                    If done(4) = True And done(5) = True And done(1) = True Then
                        cycles(i) = True
                        Return False
                    Else : i = i + 1
                    End If
                Else : i = i + 1
                End If
            Else : i = i + 1
            End If

            If position = 10 Or position = 7 Or position = 6 Then
                If cycles(i) = False Then
                    If done(9) = True And done(6) = True And done(5) = True Then
                        cycles(i) = True
                        Return False
                    Else : i = i + 1
                    End If
                Else : i = i + 1
                End If
            Else : i = i + 1
            End If

            If position = 7 Or position = 8 Or position = 11 Then
                If cycles(i) = False Then
                    If done(6) = True And done(7) = True And done(10) = True Then
                        cycles(i) = True
                        Return False
                    Else : i = i + 1
                    End If
                Else : i = i + 1
                End If
            Else : i = i + 1
            End If

            If position = 10 Or position = 11 Or position = 8 Or position = 6 Then
                If cycles(i) = False Then
                    If done(9) = True And done(10) = True And done(7) = True And done(5) = True Then
                        cycles(i) = True
                        Return False
                    Else : i = i + 1
                    End If
                Else : i = i + 1
                End If
            Else : i = i + 1
            End If

            If position = 1 Or position = 2 Or position = 8 Or position = 11 Then
                If cycles(i) = False Then
                    If done(0) = True And done(1) = True And done(7) = True And done(10) = True Then
                        cycles(i) = True
                        Return False
                    Else : i = i + 1
                    End If
                Else : i = i + 1
                End If
            Else : i = i + 1
            End If

            If position = 1 Or position = 5 Or position = 10 Or position = 9 Then
                If cycles(i) = False Then
                    If done(0) = True And done(4) = True And done(9) = True And done(8) = True Then
                        cycles(i) = True
                        Return False
                    Else : i = i + 1
                    End If
                Else : i = i + 1
                End If
            Else : i = i + 1
            End If

            If position = 5 Or position = 10 Or position = 11 Or position = 8 Or position = 2 Then
                If cycles(i) = False Then
                    If done(4) = True And done(9) = True And done(10) = True And done(7) = True And done(1) = True Then
                        cycles(i) = True
                        Return False
                    Else : i = i + 1
                    End If
                Else : i = i + 1
                End If
            Else : i = i + 1
            End If

            If position = 5 Or position = 10 Or position = 7 Or position = 2 Then
                If cycles(i) = False Then
                    If done(4) = True And done(9) = True And done(6) = True And done(1) = True Then
                        cycles(i) = True
                        Return False
                    Else : i = i + 1
                    End If
                Else : i = i + 1
                End If
            Else : i = i + 1
            End If

            If position = 8 Or position = 12 Or position = 3 Then
                If cycles(i) = False Then
                    If done(7) = True And done(11) = True And done(2) = True Then
                        cycles(i) = True
                        Return False
                    Else : i = i + 1
                    End If
                Else : i = i + 1
                End If
            Else : i = i + 1
            End If

            If position = 5 Or position = 10 Or position = 11 Or position = 12 Or position = 3 Or position = 2 Then
                If cycles(i) = False Then
                    If done(4) = True And done(9) = True And done(10) = True And done(11) = True And done(2) = True And done(1) = True Then
                        cycles(i) = True
                        Return False
                    Else : i = i + 1
                    End If
                Else : i = i + 1
                End If
            Else : i = i + 1
            End If

            If position = 1 Or position = 2 Or position = 3 Or position = 12 Or position = 11 Or position = 9 Then
                If cycles(i) = False Then
                    If done(0) = True And done(1) = True And done(2) = True And done(11) = True And done(10) = True And done(8) = True Then
                        cycles(i) = True
                        Return False
                    Else : i = i + 1
                    End If
                Else : i = i + 1
                End If
            Else : i = i + 1
            End If

            If position = 7 Or position = 3 Or position = 12 Or position = 11 Then
                If cycles(i) = False Then
                    If done(6) = True And done(2) = True And done(11) = True And done(10) = True Then
                        cycles(i) = True
                        Return False
                    Else : i = i + 1
                    End If
                Else : i = i + 1
                End If
            Else : i = i + 1
            End If

            If position = 1 Or position = 2 Or position = 7 Or position = 9 Then
                If cycles(i) = False Then
                    If done(0) = True And done(1) = True And done(6) = True And done(8) = True Then
                        cycles(i) = True
                        Return False
                    Else : i = i + 1
                    End If
                Else : i = i + 1
                End If
            Else : i = i + 1
            End If

            If position = 1 Or position = 2 Or position = 6 Or position = 4 Then
                If cycles(i) = False Then
                    If done(0) = True And done(1) = True And done(5) = True And done(3) = True Then
                        cycles(i) = True
                        Return False
                    Else : i = i + 1
                    End If
                Else : i = i + 1
                End If
            Else : i = i + 1
            End If

            If position = 4 Or position = 6 Or position = 7 Or position = 9 Then
                If cycles(i) = False Then
                    If done(3) = True And done(5) = True And done(6) = True And done(8) = True Then
                        cycles(i) = True
                        Return False
                    Else : i = i + 1
                    End If
                Else : i = i + 1
                End If
            Else : i = i + 1
            End If

        End If
        Return True
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        millisec = millisec + 1
        stopwatch()
        Label23.Text = min & ":" & sec & ":" & millisec
    End Sub

    Sub stopwatch()
        If millisec = 100 Then
            sec = sec + 1
            millisec = 0
        End If
        If sec = 60 Then
            min = min + 1
            sec = 0
        End If
        If min = 10 And sec = 0 And millisec = 0 Then
            Timer1.Enabled = False
            MsgBox("You have failed to complete a timed run of Kruskal's algorithm in the time limit. You will now be taken back to the main menu", MsgBoxStyle.OkOnly, "D1 Teaching project")
            Main_Menu.ComboBox1.Text = "Kruskal's algorithm"
            Main_Menu.Show()
            Me.Close()
        End If

    End Sub

    Private Sub LineShape7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineShape7.Click
        If started = True Then
            userchoice = 3
            If arcscoloured = 0 Then
                position = position1
            End If
            If arcscoloured = 1 Then
                position = position2
            End If
            If arcscoloured = 2 Then
                position = position3
            End If
            If arcscoloured = 3 Then
                position = position4
            End If
            If arcscoloured = 4 Then
                position = position5
            End If
            If arcscoloured = 5 Then
                position = position6
            End If
            If userchoice <> position Then
                Label24.Text = ""
                Label25.Text = "The arc you chose was incorrect; please choose another"

            Else : userchoice = position
                Colouring()
            End If
        End If
    End Sub

    Private Sub LineShape5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineShape5.Click
        If started = True Then
            userchoice = 12
            If arcscoloured = 0 Then
                position = position1
            End If
            If arcscoloured = 1 Then
                position = position2
            End If
            If arcscoloured = 2 Then
                position = position3
            End If
            If arcscoloured = 3 Then
                position = position4
            End If
            If arcscoloured = 4 Then
                position = position5
            End If
            If arcscoloured = 5 Then
                position = position6
            End If
            If userchoice <> position Then
                Label24.Text = ""
                Label25.Text = "The arc you chose was incorrect; please choose another"

            Else : userchoice = position
                Colouring()
            End If
        End If
    End Sub

    Private Sub LineShape8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineShape8.Click
        If started = True Then
            userchoice = 8
            If arcscoloured = 0 Then
                position = position1
            End If
            If arcscoloured = 1 Then
                position = position2
            End If
            If arcscoloured = 2 Then
                position = position3
            End If
            If arcscoloured = 3 Then
                position = position4
            End If
            If arcscoloured = 4 Then
                position = position5
            End If
            If arcscoloured = 5 Then
                position = position6
            End If
            If userchoice <> position Then
                Label24.Text = ""
                Label25.Text = "The arc you chose was incorrect; please choose another"

            Else : userchoice = position
                Colouring()
            End If
        End If
    End Sub

    Private Sub LineShape12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineShape12.Click
        If started = True Then
            userchoice = 7
            If arcscoloured = 0 Then
                position = position1
            End If
            If arcscoloured = 1 Then
                position = position2
            End If
            If arcscoloured = 2 Then
                position = position3
            End If
            If arcscoloured = 3 Then
                position = position4
            End If
            If arcscoloured = 4 Then
                position = position5
            End If
            If arcscoloured = 5 Then
                position = position6
            End If
            If userchoice <> position Then
                Label24.Text = ""
                Label25.Text = "The arc you chose was incorrect; please choose another"

            Else : userchoice = position
                Colouring()
            End If
        End If
    End Sub

    Private Sub LineShape2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineShape2.Click
        If started = True Then
            userchoice = 6
            If arcscoloured = 0 Then
                position = position1
            End If
            If arcscoloured = 1 Then
                position = position2
            End If
            If arcscoloured = 2 Then
                position = position3
            End If
            If arcscoloured = 3 Then
                position = position4
            End If
            If arcscoloured = 4 Then
                position = position5
            End If
            If arcscoloured = 5 Then
                position = position6
            End If
            If userchoice <> position Then
                Label24.Text = ""
                Label25.Text = "The arc you chose was incorrect; please choose another"

            Else : userchoice = position
                Colouring()
            End If
        End If
    End Sub

    Private Sub LineShape1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineShape1.Click
        If started = True Then
            userchoice = 2
            If arcscoloured = 0 Then
                position = position1
            End If
            If arcscoloured = 1 Then
                position = position2
            End If
            If arcscoloured = 2 Then
                position = position3
            End If
            If arcscoloured = 3 Then
                position = position4
            End If
            If arcscoloured = 4 Then
                position = position5
            End If
            If arcscoloured = 5 Then
                position = position6
            End If
            If userchoice <> position Then
                Label24.Text = ""
                Label25.Text = "The arc you chose was incorrect; please choose another"

            Else : userchoice = position
                Colouring()
            End If
        End If
    End Sub

    Private Sub LineShape4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineShape4.Click
        If started = True Then
            userchoice = 11
            If arcscoloured = 0 Then
                position = position1
            End If
            If arcscoloured = 1 Then
                position = position2
            End If
            If arcscoloured = 2 Then
                position = position3
            End If
            If arcscoloured = 3 Then
                position = position4
            End If
            If arcscoloured = 4 Then
                position = position5
            End If
            If arcscoloured = 5 Then
                position = position6
            End If
            If userchoice <> position Then
                Label24.Text = ""
                Label25.Text = "The arc you chose was incorrect; please choose another"

            Else : userchoice = position
                Colouring()
            End If
        End If
    End Sub

    Private Sub LineShape6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineShape6.Click
        If started = True Then
            userchoice = 5
            If arcscoloured = 0 Then
                position = position1
            End If
            If arcscoloured = 1 Then
                position = position2
            End If
            If arcscoloured = 2 Then
                position = position3
            End If
            If arcscoloured = 3 Then
                position = position4
            End If
            If arcscoloured = 4 Then
                position = position5
            End If
            If arcscoloured = 5 Then
                position = position6
            End If
            If userchoice <> position Then
                Label24.Text = ""
                Label25.Text = "The arc you chose was incorrect; please choose another"

            Else : userchoice = position
                Colouring()
            End If
        End If
    End Sub

    Private Sub LineShape13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineShape13.Click
        If started = True Then
            userchoice = 10
            If arcscoloured = 0 Then
                position = position1
            End If
            If arcscoloured = 1 Then
                position = position2
            End If
            If arcscoloured = 2 Then
                position = position3
            End If
            If arcscoloured = 3 Then
                position = position4
            End If
            If arcscoloured = 4 Then
                position = position5
            End If
            If arcscoloured = 5 Then
                position = position6
            End If
            If userchoice <> position Then
                Label24.Text = ""
                Label25.Text = "The arc you chose was incorrect; please choose another"

            Else : userchoice = position
                Colouring()
            End If
        End If
    End Sub

    Private Sub LineShape3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineShape3.Click
        If started = True Then
            userchoice = 4
            If arcscoloured = 0 Then
                position = position1
            End If
            If arcscoloured = 1 Then
                position = position2
            End If
            If arcscoloured = 2 Then
                position = position3
            End If
            If arcscoloured = 3 Then
                position = position4
            End If
            If arcscoloured = 4 Then
                position = position5
            End If
            If arcscoloured = 5 Then
                position = position6
            End If
            If userchoice <> position Then
                Label24.Text = ""
                Label25.Text = "The arc you chose was incorrect; please choose another"

            Else : userchoice = position
                Colouring()
            End If
        End If
    End Sub

    Private Sub LineShape9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineShape9.Click
        If started = True Then
            userchoice = 1
            If arcscoloured = 0 Then
                position = position1
            End If
            If arcscoloured = 1 Then
                position = position2
            End If
            If arcscoloured = 2 Then
                position = position3
            End If
            If arcscoloured = 3 Then
                position = position4
            End If
            If arcscoloured = 4 Then
                position = position5
            End If
            If arcscoloured = 5 Then
                position = position6
            End If
            If userchoice <> position Then
                Label24.Text = ""
                Label25.Text = "The arc you chose was incorrect; please choose another"

            Else : userchoice = position
                Colouring()
            End If
        End If
    End Sub

    Private Sub LineShape10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineShape10.Click
        If started = True Then
            userchoice = 9
            If arcscoloured = 0 Then
                position = position1
            End If
            If arcscoloured = 1 Then
                position = position2
            End If
            If arcscoloured = 2 Then
                position = position3
            End If
            If arcscoloured = 3 Then
                position = position4
            End If
            If arcscoloured = 4 Then
                position = position5
            End If
            If arcscoloured = 5 Then
                position = position6
            End If
            If userchoice <> position Then
                Label24.Text = ""
                Label25.Text = "The arc you chose was incorrect; please choose another."

            Else : userchoice = position
                Colouring()
            End If
        End If
    End Sub

    Sub Colouring()
        If arcscoloured < 6 Then
            If position = 1 Then
                LineShape9.BorderColor = Color.Red
                arcscoloured = arcscoloured + 1
                OvalShape2.BackColor = Color.Blue
                OvalShape3.BackColor = Color.Blue
                Label25.Text = ""
                Label24.Text = "The arc you clicked was correct. Click on the next arc that you think is in the minimum connector."

            End If
            If position = 2 Then
                LineShape1.BorderColor = Color.Red
                arcscoloured = arcscoloured + 1
                OvalShape1.BackColor = Color.Blue
                OvalShape3.BackColor = Color.Blue
                Label25.Text = ""
                Label24.Text = "The arc you clicked was correct. Click on the next arc that you think is in the minimum connector."

            End If
            If position = 3 Then
                LineShape7.BorderColor = Color.Red
                arcscoloured = arcscoloured + 1
                OvalShape1.BackColor = Color.Blue
                OvalShape10.BackColor = Color.Blue
                Label25.Text = ""
                Label24.Text = "The arc you clicked was correct. Click on the next arc that you think is in the minimum connector."

            End If
            If position = 4 Then
                LineShape3.BorderColor = Color.Red
                arcscoloured = arcscoloured + 1
                OvalShape2.BackColor = Color.Blue
                OvalShape11.BackColor = Color.Blue
                Label25.Text = ""
                Label24.Text = "The arc you clicked was correct. Click on the next arc that you think is in the minimum connector."

            End If
            If position = 5 Then
                LineShape6.BorderColor = Color.Red
                arcscoloured = arcscoloured + 1
                OvalShape3.BackColor = Color.Blue
                OvalShape11.BackColor = Color.Blue
                Label25.Text = ""
                Label24.Text = "The arc you clicked was correct. Click on the next arc that you think is in the minimum connector."

            End If
            If position = 6 Then
                LineShape2.BorderColor = Color.Red
                arcscoloured = arcscoloured + 1
                OvalShape1.BackColor = Color.Blue
                OvalShape11.BackColor = Color.Blue
                Label25.Text = ""
                Label24.Text = "The arc you clicked was correct. Click on the next arc that you think is in the minimum connector."
            End If
            If position = 7 Then
                LineShape12.BorderColor = Color.Red
                arcscoloured = arcscoloured + 1
                OvalShape1.BackColor = Color.Blue
                OvalShape8.BackColor = Color.Blue
                Label25.Text = ""
                Label24.Text = "The arc you clicked was correct. Click on the next arc that you think is in the minimum connector."
            End If
            If position = 8 Then
                LineShape8.BorderColor = Color.Red
                arcscoloured = arcscoloured + 1
                OvalShape1.BackColor = Color.Blue
                OvalShape9.BackColor = Color.Blue
                Label25.Text = ""
                Label24.Text = "The arc you clicked was correct. Click on the next arc that you think is in the minimum connector."
            End If
            If position = 9 Then
                LineShape10.BorderColor = Color.Red
                arcscoloured = arcscoloured + 1
                OvalShape2.BackColor = Color.Blue
                OvalShape8.BackColor = Color.Blue
                Label25.Text = ""
                Label24.Text = "The arc you clicked was correct. Click on the next arc that you think is in the minimum connector."
            End If
            If position = 10 Then
                LineShape13.BorderColor = Color.Red
                arcscoloured = arcscoloured + 1
                OvalShape8.BackColor = Color.Blue
                OvalShape11.BackColor = Color.Blue
                Label25.Text = ""
                Label24.Text = "The arc you clicked was correct. Click on the next arc that you think is in the minimum connector."
            End If
            If position = 11 Then
                LineShape4.BorderColor = Color.Red
                arcscoloured = arcscoloured + 1
                OvalShape8.BackColor = Color.Blue
                OvalShape9.BackColor = Color.Blue
                Label25.Text = ""
                Label24.Text = "The arc you clicked was correct. Click on the next arc that you think is in the minimum connector."
            End If
            If position = 12 Then
                LineShape5.BorderColor = Color.Red
                arcscoloured = arcscoloured + 1
                OvalShape9.BackColor = Color.Blue
                OvalShape10.BackColor = Color.Blue
                Label25.Text = ""
                Label24.Text = "The arc you clicked was correct. Click on the next arc that you think is in the minimum connector."
            End If
        End If
        If arcscoloured = 6 Then
            Label24.Text = ""
            Timer1.Enabled = False
            MsgBox("You have completed a timed run of Kruskal's algorithm and you have found the minimum connector of the network. Press the Enter key to go to the forename entry page", MsgBoxStyle.OkOnly, "D1 Teaching project")
            Forename_Entry.Show()
            Me.Hide()
        End If
    End Sub
End Class


