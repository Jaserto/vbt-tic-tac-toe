Public Class Form2

    Public Shared jugador1, jugador2 As String
    Dim form1 As New Form1()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then

            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)

        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If OpenFileDialog2.ShowDialog = DialogResult.OK Then

            PictureBox2.Image = Image.FromFile(OpenFileDialog2.FileName)


        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click



        If TextBox1.Text = "" Then
            jugador1 = "jugador1"
        Else
            jugador1 = TextBox1.Text
        End If

        If CheckBox3.Checked Then


            form1.computer = True
            jugador2 = "AI"
        Else
            If TextBox2.Text = "" Then
                jugador2 = "jugador 2"
                form1.computer = False
            Else
                form1.computer = False
                jugador2 = TextBox2.Text

            End If
        End If

        form1.jugador1 = jugador1
        form1.jugador2 = jugador2
        If Not PictureBox1.Image Is Nothing Then

            form1.PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
        If Not PictureBox2.Image Is Nothing Then
            form1.PictureBox2.Image = Image.FromFile(OpenFileDialog2.FileName)
        End If

        If RadioButton2.Checked Then
            form1.size4 = True

            form1.Button12.Visible = True
            form1.Button13.Visible = True
            form1.Button14.Visible = True
            form1.Button15.Visible = True
            form1.Button16.Visible = True
            form1.Button17.Visible = True
            form1.Button18.Visible = True
        Else
            form1.Button12.Visible = False
            form1.Button13.Visible = False
            form1.Button14.Visible = False
            form1.Button15.Visible = False
            form1.Button16.Visible = False
            form1.Button17.Visible = False
            form1.Button18.Visible = False
        End If

        Me.Hide()
        form1.Show()






    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()

    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        form1.computer = True
        RadioButton2.Enabled = False

    End Sub

End Class