Public Class Form1

    Public Property computer As Boolean
    Public Property size4 As Boolean
    Public Property jugador1 As String
    Public Property jugador2 As String

    Public Function isWinner(ByVal key As Char)
        Return (
            (Button1.Text = Button2.Text And Button2.Text = Button3.Text And Button3.Text = key) Or
            (Button4.Text = Button5.Text And Button5.Text = Button6.Text And Button6.Text = key) Or
            (Button7.Text = Button8.Text And Button8.Text = Button9.Text And Button9.Text = key) Or
            (Button1.Text = Button5.Text And Button5.Text = Button9.Text And Button9.Text = key) Or
            (Button3.Text = Button5.Text And Button5.Text = Button7.Text And Button7.Text = key) Or
            (Button1.Text = Button4.Text And Button4.Text = Button7.Text And Button7.Text = key) Or
            (Button2.Text = Button5.Text And Button5.Text = Button8.Text And Button8.Text = key) Or
            (Button3.Text = Button6.Text And Button6.Text = Button9.Text And Button9.Text = key)
            )


    End Function


    Public Function ComputerInput()
        'cargamos los botones
        Dim btns As Button() = {Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9}
        Dim btns2 As Button() = {Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9, Button12, Button13, Button14, Button15, Button16, Button17, Button18}

        Dim possInput As List(Of Button) = New List(Of Button)
        'Los añadimos a la lista
        For j As Integer = 0 To btns.Length - 1
            If (btns(j).Text = "") Then
                possInput.Add(btns(j))
            End If
        Next
        'Caracteres
        Dim chs() As Char = {"X", "O"}

        For Each ch As Char In chs
            For Each btn As Button In possInput
                btn.Text = ch
                If isWinner(ch) Then
                    btn.Text = "O"
                    btn.Enabled = False
                    Return (True)
                End If
                btn.Text = ""
            Next
        Next

        'esquinas
        Dim cornerBtn As List(Of Button) = New List(Of Button)

        For Each btn As Button In possInput
            If (btn Is Button1 Or btn Is Button3 Or btn Is Button7 Or btn Is Button9) Then
                cornerBtn.Add(btn)
            End If
        Next

        'selecciona una esquina
        Dim tempBtn As Button

        If cornerBtn.Count > 0 Then
            tempBtn = cornerBtn(New Random().Next(0, cornerBtn.Count - 1))
            tempBtn.Text = "O"
            tempBtn.Enabled = False
            Return (True)
        End If

        'Selecciona el centro
        If possInput.Contains(Button5) Then
            Button5.Text = "O"
            Button5.Enabled = False
            Return (True)
        End If
        'no centro
        Dim edgeBtn As List(Of Button) = New List(Of Button)
        For Each btn As Button In possInput
            If (btn Is Button2 Or btn Is Button4 Or btn Is Button6 Or btn Is Button8) Then
                edgeBtn.Add(btn)
            End If
        Next
        'Selecciona alguno si esta disponible
        If edgeBtn.Count > 0 Then
            tempBtn = edgeBtn(New Random().Next(0, edgeBtn.Count - 1))
            tempBtn.Text = "O"
            tempBtn.Enabled = False
            Return (True)
        End If

        Return (False)
    End Function

    Public Sub reset()
        Dim btns As Button() = {Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9, Button12, Button13, Button14, Button15, Button16, Button17, Button18}
        For Each btn As Button In btns
            btn.Text = ""
            btn.Enabled = True
            btn.BackColor = DefaultBackColor

        Next
    End Sub

    Public Function checkTheWinner(ByVal key As Char)
        If (Button1.Text = Button2.Text And Button2.Text = Button3.Text And Button3.Text = key) Then
            Button1.BackColor = Color.GreenYellow
            Button2.BackColor = Color.GreenYellow
            Button3.BackColor = Color.GreenYellow
        ElseIf (Button4.Text = Button5.Text And Button5.Text = Button6.Text And Button6.Text = key) Then
            Button4.BackColor = Color.GreenYellow
            Button5.BackColor = Color.GreenYellow
            Button6.BackColor = Color.GreenYellow
        ElseIf (Button7.Text = Button8.Text And Button8.Text = Button9.Text And Button9.Text = key) Then
            Button7.BackColor = Color.GreenYellow
            Button8.BackColor = Color.GreenYellow
            Button9.BackColor = Color.GreenYellow
        ElseIf (Button1.Text = Button5.Text And Button5.Text = Button9.Text And Button9.Text = key) Then
            Button1.BackColor = Color.GreenYellow
            Button5.BackColor = Color.GreenYellow
            Button9.BackColor = Color.GreenYellow
        ElseIf (Button3.Text = Button5.Text And Button5.Text = Button7.Text And Button7.Text = key) Then
            Button3.BackColor = Color.GreenYellow
            Button5.BackColor = Color.GreenYellow
            Button7.BackColor = Color.GreenYellow
        ElseIf (Button1.Text = Button4.Text And Button4.Text = Button7.Text And Button7.Text = key) Then
            Button1.BackColor = Color.GreenYellow
            Button4.BackColor = Color.GreenYellow
            Button7.BackColor = Color.GreenYellow
        ElseIf (Button2.Text = Button5.Text And Button5.Text = Button8.Text And Button8.Text = key) Then
            Button2.BackColor = Color.GreenYellow
            Button5.BackColor = Color.GreenYellow
            Button8.BackColor = Color.GreenYellow
        ElseIf (Button3.Text = Button6.Text And Button6.Text = Button9.Text And Button9.Text = key) Then
            Button3.BackColor = Color.GreenYellow
            Button6.BackColor = Color.GreenYellow
            Button9.BackColor = Color.GreenYellow
        Else
            Return (False)
        End If
        Return (True)
    End Function
    Public Sub check()
        If checkTheWinner("X") Then
            Button11.Text = "Ganaste!!"
            Button11.BackColor = Color.GreenYellow
            Button11.Enabled = False
            Button10.Enabled = True
        ElseIf checkTheWinner("O") Then
            Button11.Text = "Perdiste!!!"
            Button11.BackColor = Color.Red
            Button11.Enabled = False
            Button10.Enabled = True
        Else
            Dim btns As Button() = {Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9}
            Dim possInput As List(Of Button) = New List(Of Button)

            For j As Integer = 0 To btns.Length - 1
                If (btns(j).Text = "") Then
                    possInput.Add(btns(j))
                End If
            Next
            If possInput.Count = 0 Then
                Button11.Text = "Empate!"
                Button11.BackColor = Color.Yellow
                Button11.Enabled = False
                Button10.Enabled = True
            End If
        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If computer Then
            Button1.Text = "X"
            Button1.Enabled = False
            ComputerInput()
            check()
        Else
            If Label4.Visible = True Then
                Button1.Text = "0"
                Label4.Visible = False
                Label5.Visible = True
                comprobar()
            ElseIf Label5.Visible = True Then
                Button1.Text = "X"
                Label4.Visible = True
                Label5.Visible = False
                comprobar()
            End If
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If computer Then
            Button2.Text = "X"
            Button2.Enabled = False
            ComputerInput()
            check()
        Else
            If Label4.Visible = True Then
                Button2.Text = "0"
                Label4.Visible = False
                Label5.Visible = True
                comprobar()
            ElseIf Label5.Visible = True Then
                Button2.Text = "X"
                Label4.Visible = True
                Label5.Visible = False
                comprobar()
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If computer Then
            Button3.Text = "X"
            Button3.Enabled = False
            ComputerInput()
            check()
        Else
            If Label4.Visible = True Then
                Button3.Text = "0"
                Label4.Visible = False
                Label5.Visible = True
                comprobar()
            ElseIf Label5.Visible = True Then
                Button3.Text = "X"
                Label4.Visible = True
                Label5.Visible = False
                comprobar()
            End If
        End If
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If computer Then
            Button4.Text = "X"
            Button4.Enabled = False
            ComputerInput()
            check()
        Else
            If Label4.Visible = True Then
                Button4.Text = "0"
                Label4.Visible = False
                Label5.Visible = True
                comprobar()
            ElseIf Label5.Visible = True Then
                Button4.Text = "X"
                Label4.Visible = True
                Label5.Visible = False
                comprobar()
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If computer Then
            Button5.Text = "X"
            Button5.Enabled = False
            ComputerInput()
            check()
        Else
            If Label4.Visible = True Then
                Button5.Text = "0"
                Label4.Visible = False
                Label5.Visible = True
                comprobar()
            ElseIf Label5.Visible = True Then
                Button5.Text = "X"
                Label4.Visible = True
                Label5.Visible = False
                comprobar()
            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If computer Then
            Button6.Text = "X"
            Button6.Enabled = False
            ComputerInput()
            check()
        Else
            If Label4.Visible = True Then
                Button6.Text = "0"
                Label4.Visible = False
                Label5.Visible = True
                comprobar()
            ElseIf Label5.Visible = True Then
                Button6.Text = "X"
                Label4.Visible = True
                Label5.Visible = False
                comprobar()
            End If
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If computer Then
            Button7.Text = "X"
            Button7.Enabled = False
            ComputerInput()
            check()
        Else
            If Label4.Visible = True Then
                Button7.Text = "0"
                Label4.Visible = False
                Label5.Visible = True
                comprobar()
            ElseIf Label5.Visible = True Then
                Button7.Text = "X"
                Label4.Visible = True
                Label5.Visible = False
                comprobar()
            End If
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If computer Then
            Button8.Text = "X"
            Button8.Enabled = False
            ComputerInput()
            check()
        Else
            If Label4.Visible = True Then
                Button8.Text = "0"
                Label4.Visible = False
                Label5.Visible = True
                comprobar()
            ElseIf Label5.Visible = True Then
                Button8.Text = "X"
                Label4.Visible = True
                Label5.Visible = False
                comprobar()
            End If
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If computer Then
            Button9.Text = "X"
            Button9.Enabled = False
            ComputerInput()
            check()
        Else
            If Label4.Visible = True Then
                Button9.Text = "0"
                Label4.Visible = False
                Label5.Visible = True
                comprobar()
            ElseIf Label5.Visible = True Then
                Button9.Text = "X"
                Label4.Visible = True
                Label5.Visible = False
                comprobar()
            End If
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        reset()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        reset()
        Button11.Text = "Reset"
        Button11.BackColor = DefaultBackColor
        Button11.Enabled = True
        Button10.Enabled = False
    End Sub

    Private Sub ConfiguracionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfiguracionToolStripMenuItem.Click
        Dim frm As New Form2()
        frm.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = "Puntuacion de : " + jugador1
        Label3.Text = "Puntuacion de : " + jugador2
        If computer Then
            Label4.Text = ""
            Label5.Text = ""
        Else
            Label4.Text = "turno: " + jugador1
            Label5.Text = "turno: " + jugador2
        End If
    End Sub


    Private Sub comprobar()
        'jugador2 gana'
        If Button1.Text = "X" And Button4.Text = "X" And Button7.Text = "X" Then
            Label1.Text = jugador2 + "  2 gana"
            Button10.Visible = True
            Label7.Text = Label7.Text + 1
        ElseIf Button1.Text = "X" And Button2.Text = "X" And Button3.Text = "X" Then
            Label1.Text = jugador2 + "  2 gana"
            Button10.Visible = True
            Label7.Text = Label7.Text + 1
        ElseIf Button1.Text = "X" And Button5.Text = "X" And Button9.Text = "X" Then
            Label1.Text = jugador2 + "  2 gana"
            Button10.Visible = True
            Label7.Text = Label7.Text + 1
        ElseIf Button7.Text = "X" And Button8.Text = "X" And Button9.Text = "X" Then
            Label1.Text = jugador2 + "  2 gana"
            Button10.Visible = True
            Label7.Text = Label7.Text + 1
        ElseIf Button3.Text = "X" And Button6.Text = "X" And Button9.Text = "X" Then
            Label1.Text = jugador2 + "  2 gana"
            Button10.Visible = True
            Label7.Text = Label7.Text + 1
        ElseIf Button2.Text = "X" And Button5.Text = "X" And Button8.Text = "X" Then
            Label1.Text = jugador2 + "  2 gana"
            Button10.Visible = True
            Label7.Text = Label7.Text + 1
        ElseIf Button3.Text = "X" And Button5.Text = "X" And Button7.Text = "X" Then
            Label1.Text = jugador2 + "  2 gana"
            Button10.Visible = True
            Label7.Text = Label7.Text + 1
        ElseIf Button4.Text = "X" And Button5.Text = "X" And Button6.Text = "X" Then
            Label1.Text = jugador2 + "  2 gana"
            Button10.Visible = True
            Label7.Text = Label7.Text + 1
        End If
        'jugador1 gana'
        If Button1.Text = "0" And Button4.Text = "0" And Button7.Text = "0" Then
            Label1.Text = jugador1 + "  2 gana"
            Button10.Visible = True
            Label6.Text = Label6.Text + 1
        ElseIf Button1.Text = "0" And Button2.Text = "0" And Button3.Text = "0" Then
            Label1.Text = jugador1 + "  2 gana"
            Button10.Visible = True
            Label6.Text = Label6.Text + 1
        ElseIf Button1.Text = "0" And Button5.Text = "0" And Button9.Text = "0" Then
            Label1.Text = jugador1 + "  2 gana"
            Button10.Visible = True
            Label6.Text = Label6.Text + 1
        ElseIf Button7.Text = "0" And Button8.Text = "0" And Button9.Text = "0" Then
            Label1.Text = jugador1 + "  2 gana"
            Button10.Visible = True
            Label6.Text = Label6.Text + 1
        ElseIf Button3.Text = "0" And Button6.Text = "0" And Button9.Text = "0" Then
            Label1.Text = jugador1 + "  2 gana"
            Button10.Visible = True
            Label6.Text = Label6.Text + 1
        ElseIf Button2.Text = "0" And Button5.Text = "0" And Button8.Text = "0" Then
            Label1.Text = jugador1 + "  2 gana"
            Button10.Visible = True
            Label6.Text = Label6.Text + 1
        ElseIf Button3.Text = "0" And Button5.Text = "0" And Button7.Text = "0" Then
            Label1.Text = jugador1 + "  2 gana"
            Button10.Visible = True
            Label6.Text = Label6.Text + 1
        ElseIf Button4.Text = "0" And Button5.Text = "0" And Button6.Text = "0" Then
            Label1.Text = jugador1 + "  2 gana"
            Button10.Visible = True
            Label6.Text = Label6.Text + 1
        End If
    End Sub
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If computer Then
            Button12.Text = "X"
            Button12.Enabled = False
            ComputerInput()
            check()
        Else
            If Label4.Visible = True Then
                Button12.Text = "0"
                Label4.Visible = False
                Label5.Visible = True
                comprobar()
            ElseIf Label5.Visible = True Then
                Button12.Text = "X"
                Label4.Visible = True
                Label5.Visible = False
                comprobar()
            End If
        End If
    End Sub
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If computer Then
            Button13.Text = "X"
            Button13.Enabled = False
            ComputerInput()
            check()
        Else
            If Label4.Visible = True Then
                Button13.Text = "0"
                Label4.Visible = False
                Label5.Visible = True
                comprobar()
            ElseIf Label5.Visible = True Then
                Button13.Text = "X"
                Label4.Visible = True
                Label5.Visible = False
                comprobar()
            End If
        End If
    End Sub
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If computer Then
            Button14.Text = "X"
            Button14.Enabled = False
            ComputerInput()
            check()
        Else
            If Label4.Visible = True Then
                Button14.Text = "0"
                Label4.Visible = False
                Label5.Visible = True
                comprobar()
            ElseIf Label5.Visible = True Then
                Button14.Text = "X"
                Label4.Visible = True
                Label5.Visible = False
                comprobar()
            End If
        End If
    End Sub
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        If computer Then
            Button15.Text = "X"
            Button15.Enabled = False
            ComputerInput()
            check()
        Else
            If Label4.Visible = True Then
                Button15.Text = "0"
                Label4.Visible = False
                Label5.Visible = True
                comprobar()
            ElseIf Label5.Visible = True Then
                Button15.Text = "X"
                Label4.Visible = True
                Label5.Visible = False
                comprobar()
            End If
        End If
    End Sub
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        If computer Then
            Button16.Text = "X"
            Button16.Enabled = False
            ComputerInput()
            check()
        Else
            If Label4.Visible = True Then
                Button13.Text = "0"
                Label4.Visible = False
                Label5.Visible = True
                comprobar()
            ElseIf Label5.Visible = True Then
                Button16.Text = "X"
                Label4.Visible = True
                Label5.Visible = False
                comprobar()
            End If
        End If
    End Sub
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        If computer Then
            Button17.Text = "X"
            Button17.Enabled = False
            ComputerInput()
            check()
        Else
            If Label4.Visible = True Then
                Button17.Text = "0"
                Label4.Visible = False
                Label5.Visible = True
                comprobar()
            ElseIf Label5.Visible = True Then
                Button17.Text = "X"
                Label4.Visible = True
                Label5.Visible = False
                comprobar()
            End If
        End If
    End Sub
    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        If computer Then
            Button18.Text = "X"
            Button18.Enabled = False
            ComputerInput()
            check()
        Else
            If Label4.Visible = True Then
                Button18.Text = "0"
                Label4.Visible = False
                Label5.Visible = True
                comprobar()
            ElseIf Label5.Visible = True Then
                Button18.Text = "X"
                Label4.Visible = True
                Label5.Visible = False
                comprobar()
            End If
        End If
    End Sub

End Class
