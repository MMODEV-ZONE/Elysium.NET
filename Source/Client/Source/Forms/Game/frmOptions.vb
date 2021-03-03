Friend Class FrmOptions

#Region "Options"

    Private Sub scrlVolume_ValueChanged(sender As Object, e As EventArgs) Handles scrlVolume.ValueChanged
        Settings.Volume = scrlVolume.Value

        lblVolume.Text = "Volume: " & Settings.Volume

        If Not MusicPlayer Is Nothing Then MusicPlayer.Volume() = Settings.Volume

    End Sub

    Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        'musica
        If optMOn.Checked = True Then
            Settings.Music = True
            ' começar a toca rmúsicar
            PlayMusic(Trim$(Map.Music))
        Else
            Settings.Music = False
            ' parar de tocar música
            StopMusic()
            CurMusic = ""
        End If

        'som
        If optSOn.Checked = True Then
            Settings.Sound = True
        Else
            Settings.Sound = False
            StopSound()
        End If

        'resolução de tela
        Settings.ScreenSize = cmbScreenSize.SelectedIndex

        If chkHighEnd.Checked Then
            Settings.HighEnd = 1
        Else
            Settings.HighEnd = 0
        End If

        If chkNpcBars.Checked Then
            Settings.ShowNpcBar = 1
        Else
            Settings.ShowNpcBar = 0
        End If

        ' salvar ao config.ini
        SaveSettings()

        RePositionGui()

        Me.Visible = False
    End Sub

    Private Sub FrmOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

#End Region

End Class