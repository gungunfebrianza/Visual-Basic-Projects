Public Class Form1


    Private Sub ListBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        AxWindowsMediaPlayer1.URL = ListBox1.SelectedItem
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub ClsButtonOrange1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClsButtonOrange1.Click
        Try
            AxWindowsMediaPlayer1.Ctlcontrols.stop()
            ListBox1.SelectedIndex = Me.ListBox1.SelectedIndex + 1
            AxWindowsMediaPlayer1.URL = ListBox1.SelectedItem
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClsButtonPurple1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClsButtonPurple1.Click
        Try
            AxWindowsMediaPlayer1.Ctlcontrols.stop()
            ListBox1.SelectedIndex = Me.ListBox1.SelectedIndex - 1
            AxWindowsMediaPlayer1.URL = ListBox1.SelectedItem
        Catch
        End Try
    End Sub

    Private Sub ClsButtonGrey1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClsButtonGrey1.Click
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
    End Sub

    Private Sub ClsButtonGreen1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClsButtonGreen1.Click
        AxWindowsMediaPlayer1.Ctlcontrols.pause()
    End Sub

    Private Sub ClsButtonBlue1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClsButtonBlue1.Click
        AxWindowsMediaPlayer1.URL = ListBox1.SelectedItem
    End Sub

    Private Sub OpenFileDialog1_FileOk_1(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        For Each track As String In OpenFileDialog1.FileNames
            ListBox1.Items.Add(track)
            ListBox1.Refresh()
        Next
    End Sub

    Private Sub AddMusicToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddMusicToolStripMenuItem.Click
        Button6.PerformClick()
    End Sub

    Private Sub HideInTrayIconToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideInTrayIconToolStripMenuItem.Click
        Me.Visible = False
        NotifyIcon1.BalloonTipText = ("HTC MP3 Player - Hide In Tray")
        NotifyIcon1.ShowBalloonTip(2)
    End Sub

    Private Sub OpenGUIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenGUIToolStripMenuItem.Click
        Me.Visible = True
    End Sub

    Private Sub RemoveSelectedItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveSelectedItemToolStripMenuItem.Click
        For i As Integer = 0 To ListBox1.SelectedIndices.Count - 1
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
        Next
    End Sub

    Private Sub RemoveAllItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveAllItemsToolStripMenuItem.Click
        ListBox1.Items.Clear()
    End Sub

    Private Sub PlaySelectedItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlaySelectedItemsToolStripMenuItem.Click
        AxWindowsMediaPlayer1.URL = ListBox1.SelectedItem
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub LoadPlaylistToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadPlaylistToolStripMenuItem.Click
        If OpenFileDialog2.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            'Tulisan pada listbox menjadi warna merah
            ListBox1.ForeColor = Color.Blue
            'memuat logs history
            Dim r As IO.StreamReader
            Try
                r = New IO.StreamReader(OpenFileDialog2.FileName)
                While (r.Peek() > -1)
                    ListBox1.Items.Add(r.ReadLine)
                End While
                r.Close()
            Catch ex As Exception
                'tidak melakukan apa apa
            End Try
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            AxWindowsMediaPlayer1.settings.setMode("Loop", True)
        Else
            AxWindowsMediaPlayer1.settings.setMode("Loop", False)
        End If
    End Sub
    Private Sub SavePlaylisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavePlaylisToolStripMenuItem.Click
        If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                'Menyimpan informasi logs history
                Using WWW As New SaveFileDialog
                    Using saef As New System.IO.StreamWriter(SaveFileDialog1.FileName)
                        For Each item As String In ListBox1.Items
                            saef.WriteLine(item)
                        Next
                        saef.Close()
                    End Using
                End Using

            Catch ex As Exception
                'tidak melakukan apa apa
            End Try
        End If
    End Sub

    Private Sub LoadFromSavedPlaylistToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadFromSavedPlaylistToolStripMenuItem.Click
        If OpenFileDialog2.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            'Tulisan pada listbox menjadi warna merah
            ListBox1.ForeColor = Color.Blue
            'memuat logs history
            Dim r As IO.StreamReader
            Try
                r = New IO.StreamReader(OpenFileDialog2.FileName)
                While (r.Peek() > -1)
                    ListBox1.Items.Add(r.ReadLine)
                End While
                r.Close()
            Catch ex As Exception
                'tidak melakukan apa apa
            End Try
        End If
    End Sub

    Private Sub HasanuddinCyberTeamToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HasanuddinCyberTeamToolStripMenuItem.Click
        MessageBox.Show("Created By Gun Gun Febrianza" + vbNewLine + "Gelar Munajat" + vbNewLine + "Lutfi" + vbNewLine + "Wahyu", "HCT MP3 Player", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
