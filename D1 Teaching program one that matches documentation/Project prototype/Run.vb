Public Class Run

    Dim weightings() As Integer = {5, 9, 6, 3, 4, 8, 5, 10, 6, 2, 9, 3} 'This is the 1-dimensional array of arc weightings'
    Dim done() As Boolean = {False, False, False, False, False, False, False, False, False, False, False, False} 'This is the 1-dimensional array that tells the program whether an arc can be selected to be in the minimum connector. Initially they are all set to false which indicates that none of them are initially in the minimum connector.
    Dim lowest, high, position, arcschosen As Integer 'lowest = the lowest number in the array that the program has come across during an iteration. high = the highest number in the array. Position = the position of the arc weight in the array. arcschosen = The number of arcs chosen by the program to go into the minimum connector.
    Dim listboxdisplayed As Boolean 'This variable indicates whether the listbox is being displayed at the present time.'

    Private Sub Run_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main_Menu.Hide() 'This hides Main_Menu'
        Label2.Text = "A" 'The Label initialising below is so that the form looks as it should and that the vertices have been given their letters and the arcs have been given their arc weights.'
        Label3.Text = "B"
        Label4.Text = "C"
        Label5.Text = "D"
        Label6.Text = "E"
        Label7.Text = "F"
        Label8.Text = "G"
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
        Label21.Text = "Find the minimum connector for this network using Kruskal's algorithm. Draw the minimum connector."
        Label22.Text = "If you have the D1 revision guide then turn to page 23 where the example allows you to follow the use of the algorithm in this run."
        Label23.Text = ""
        Label24.Text = ""
        listboxdisplayed = False 'This variable has been set to false because the listbox is not displayed when the form is loaded.'
        ListBox1.Hide() 'This hides the listbox'
        arcschosen = 0 'These two variables have both been set to 0 so that they don't affect the running of the algorithm until the variable values have been changed by the algorithm.'
        position = 0
    End Sub

    Private Sub Label25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label25.Click
        'This code below shows listbox 1 when the listbox is not currently displayed and hides it when the listbox 1 is currently displayed. This code is only displayed when the user clicks on label 25.
        If listboxdisplayed = False Then
            ListBox1.Show()
            listboxdisplayed = True

        ElseIf listboxdisplayed = True Then
            ListBox1.Hide()
            listboxdisplayed = False

        End If
    End Sub
    Private Sub btnquit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnquit.Click 'This declares the quit button'
        Main_Menu.ComboBox1.Text = "Kruskal's algorithm" 'This piece of code is used so that when the user uses the quit button the combo box 1 on Main_Menu will have "Kruskal's algorithm" written in it every time.'
        Main_Menu.Show() 'This shows Main_Menu'
        Me.Close() 'This closes this form'

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Hide()
        Do Until arcschosen = 6

            high = highest(weightings)
            lowest = high 'This is so that the lowest value in the array is set to the highest value in the array of weightings so that the lowest value in the array can be found each time the algorithm is run.'

            For i = LBound(weightings) To UBound(weightings) 'The program checks the code for the lowest value in the array by checking all of the values from the begining of the array to the end.'
                If lowest >= weightings(i) Then
                    If done(i) = False Then 'This is so that the lowest = weightings(i) only when the value in the weightings array hasn't already been chosen as being in the minimum connector.'
                        lowest = weightings(i)
                        position = i + 1 'The position in the array is equal to i + 1 because i starts at 0 and position starts at 1.'
                    End If
                End If
            Next

            If TrueorFalse() Then 'This is so that if a cycle has been formed by this arc being in the minimum connector then the corressponding arc won't be coloured.'
                Colouring() 'Colours arcs and vertices'
                Me.Show() 'The code below is used so that the user must press OK on the message box for the algorithm to move onto the next stage.'
                MsgBox("Go to next stage", MsgBoxStyle.OkOnly, "D1 Teaching project")
            End If

        Loop
        Label21.Text = ""
        Label22.Text = ""
        Label23.Text = "You have completed a run of Kruskal's algorithm and you have found the minimum connector of the network." 'Tells the user that they are done'
        Label24.Text = "However for the exam you will have to draw the minimum connector separately from the network given." 'Help for user'
    End Sub

    Function highest(ByVal arr() As Integer) As Integer 'This function is used to find the highest number in the weightings array'
        Dim high As Integer = arr(0) 'This sets the variable high to the value in the weightings array at i = 0, so that if a value in the array is larger than this then the value of high will be the highest value in the array.'
        For i = 1 To UBound(arr)
            If arr(i) > high Then high = arr(i)
        Next
        Return high 'This returns high to the place where highest was called in the code above so that the program can find the lowest value in the array during each iteration of the algorithm.

    End Function

    Dim cycles(30) As Boolean 'This is to stop the algorithm from recognising the same cycle twice so that when the cycle has been recognised and the appropriate action has been taken by the algorithm the cycle at a certain point in the array will be set to true so that the program will not recognise it again.'

    Function TrueorFalse() As Boolean 'This function is used to change the arc chosen value to True in the done() array so that the program knows not to use the same arc again in the rest of the iterations.'
        Dim i As Integer = 0
        done(position - 1) = True 'Sets the value in the position-1 of the array to True'

        If arcschosen >= 3 Then 'This is so that the algorithm only looks for cycles when the number of arcs in the minimum connector is more than or equal to 3.' 
            If position = 1 Or position = 5 Or position = 4 Then 'From here down are the possible cycles that could be formed in the network.'
                If cycles(i) = False Then 'This is so that if the program sets cycle(i) to true meaning that it has been prevented before then it won't try to be prevented again.'
                    If done(0) = True And done(4) = True And done(3) = True Then 'If all these three values in the done array are true then this means that a cycle will occur and therefore needs to be prevented.'
                        cycles(i) = True
                        Return False 'This prevents a cycle from forming.'
                    Else : i = i + 1 'This causes the program to read the next block of code for another cycle because more than one cycle may be formed by one arc being chosen and therefore need to be prevented and stoped from happening again.'
                    End If
                Else : i = i + 1 'This causes the program to read the next block of code for another cycle because more than one cycle may be formed by one arc being chosen and therefore need to be prevented and stoped from happening again.'
                End If
            Else : i = i + 1 'This causes the program to read the next block of code for another cycle because more than one cycle may be formed by one arc being chosen and therefore need to be prevented and stoped from happening again.'
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

    Sub Colouring()
        If position = 1 Then
            LineShape9.BorderColor = Color.Red 'These are specific aspects of my program that need to be changed when position equals 1. This line of code causes the line shape that position 1 is connected to to change colour to red so that it tells the user that this arc has already been chosen.'
            OvalShape2.BackColor = Color.Blue 'The vertices that are joined to the arc that is connected position = 1 are changed colour to blue so that the user knows that these vertices have been connected.
            OvalShape3.BackColor = Color.Blue
            arcschosen = arcschosen + 1 'This increases the arcschosen value by 1 because one more arc has just been chosen to go into the minimum connector. 
        End If
        If position = 2 Then
            LineShape1.BorderColor = Color.Red
            OvalShape1.BackColor = Color.Blue
            OvalShape3.BackColor = Color.Blue
            arcschosen = arcschosen + 1
        End If
        If position = 3 Then
            LineShape7.BorderColor = Color.Red
            OvalShape1.BackColor = Color.Blue
            OvalShape10.BackColor = Color.Blue
            arcschosen = arcschosen + 1
        End If
        If position = 4 Then
            LineShape3.BorderColor = Color.Red
            OvalShape2.BackColor = Color.Blue
            OvalShape11.BackColor = Color.Blue
            arcschosen = arcschosen + 1
        End If
        If position = 5 Then
            LineShape6.BorderColor = Color.Red
            OvalShape3.BackColor = Color.Blue
            OvalShape11.BackColor = Color.Blue
            arcschosen = arcschosen + 1
        End If
        If position = 6 Then
            LineShape2.BorderColor = Color.Red
            OvalShape1.BackColor = Color.Blue
            OvalShape11.BackColor = Color.Blue
            arcschosen = arcschosen + 1
        End If
        If position = 7 Then
            LineShape12.BorderColor = Color.Red
            OvalShape1.BackColor = Color.Blue
            OvalShape8.BackColor = Color.Blue
            arcschosen = arcschosen + 1
        End If
        If position = 8 Then
            LineShape8.BorderColor = Color.Red
            OvalShape1.BackColor = Color.Blue
            OvalShape9.BackColor = Color.Blue
            arcschosen = arcschosen + 1
        End If
        If position = 9 Then
            LineShape10.BorderColor = Color.Red
            OvalShape2.BackColor = Color.Blue
            OvalShape8.BackColor = Color.Blue
            arcschosen = arcschosen + 1
        End If
        If position = 10 Then
            LineShape13.BorderColor = Color.Red
            OvalShape8.BackColor = Color.Blue
            OvalShape11.BackColor = Color.Blue
            arcschosen = arcschosen + 1
        End If
        If position = 11 Then
            LineShape4.BorderColor = Color.Red
            OvalShape8.BackColor = Color.Blue
            OvalShape9.BackColor = Color.Blue
            arcschosen = arcschosen + 1
        End If
        If position = 12 Then
            LineShape5.BorderColor = Color.Red
            OvalShape9.BackColor = Color.Blue
            OvalShape10.BackColor = Color.Blue
            arcschosen = arcschosen + 1
        End If
    End Sub
End Class