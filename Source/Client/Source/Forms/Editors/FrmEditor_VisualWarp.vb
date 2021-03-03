Imports System.Drawing
Imports System.IO

Friend Class frmEditor_VisualWarp

    Private Sub LstMaps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMaps.SelectedIndexChanged
        DrawMap()
        EditorWarpMap = lstMaps.SelectedIndex + 1
    End Sub

    Private Sub PicPreview_Click(sender As Object, e As MouseEventArgs) Handles picPreview.Click
        EditorWarpX = e.Location.X \ PicX
        EditorWarpY = e.Location.Y \ PicY

        lblSelX.Text = "X Selecionado: " & EditorWarpX
        lblSelY.Text = "Y Selecionado: " & EditorWarpY
    End Sub

    Private Sub BtnWarpOK_Click(sender As Object, e As EventArgs) Handles btnWarpOK.Click
        Visible = False
    End Sub

    Private Overloads Sub PicPreview_Paint(sender As Object, e As PaintEventArgs)
        'Aqui [e onde temos certeza que a caixa não tenta se pintar...
        Exit Sub
    End Sub

    Private Sub DrawMap()
        Dim g As Graphics, x As Integer, y As Integer
        Dim srcRect As Rectangle
        Dim destRect As Rectangle

        If lstMaps.SelectedIndex < 0 Then Exit Sub

        If File.Exists(Application.StartupPath & "\Dados\Cache\Map" & lstMaps.SelectedIndex + 1 & ".png") Then
            g = picPreview.CreateGraphics

            Dim mapsprite As Bitmap = New Bitmap(Application.StartupPath & "\Dados\Cache\Map" & lstMaps.SelectedIndex + 1 & ".png")

            picPreview.Width = mapsprite.Width
            picPreview.Height = mapsprite.Height

            srcRect = New Rectangle(0, 0, mapsprite.Width, mapsprite.Height)
            destRect = New Rectangle(0, 0, mapsprite.Width, mapsprite.Height)

            picPreview.Refresh()
            g.DrawImage(mapsprite, destRect, srcRect, GraphicsUnit.Pixel)

            For x = 0 To (mapsprite.Width \ PicX)
                For y = 0 To (mapsprite.Height \ PicY)
                    g.DrawRectangle(Pens.Red, New Rectangle(x * PicX, y * PicY, PicX, PicY))
                Next
            Next

            g.Dispose()
        Else
            MsgBox("Este mapa não está no cache; por favor salve o mapa de destino primeiro!")
        End If
    End Sub

    Private Sub PnlPreview_Paint(sender As Object, e As PaintEventArgs) Handles pnlPreview.Paint
        'nada
    End Sub

    Private Sub PnlPreview_Scroll(sender As Object, e As ScrollEventArgs) Handles pnlPreview.Scroll
        DrawMap()
    End Sub

    Private Sub FrmVisualWarp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class