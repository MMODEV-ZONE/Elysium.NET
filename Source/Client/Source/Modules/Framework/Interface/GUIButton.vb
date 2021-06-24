Imports System.Xml.Serialization
Imports SFML.Graphics

Public Class GUIButton
    Inherits GUIObject
    <XmlAttribute("OnClick")>
    Public OnClick As String
    <XmlAttribute("Background")>
    Public Background As String = "botão"
    <XmlAttribute("BackgroundRed")>
    Public BackgroundRed As Byte
    <XmlAttribute("BackgroundGreen")>
    Public BackgroundGreen As Byte
    <XmlAttribute("BackgroundBlue")>
    Public BackgroundBlue As Byte
    <XmlAttribute("Caption")>
    Public Caption As String
    <XmlAttribute("Height")>
    Public Height As Integer = 16
    <XmlAttribute("Width")>
    Public Width As Integer = 48

    Public Overrides Sub Render(window As RenderWindow)
        LoadComponentTexture(Background)

        Dim sRECT As Rectangle
        Dim dRECT As Rectangle

        With sRECT
            .Y = 0
            .Height = ComponentGfxInfo.Height
            .X = 0
            .Width = ComponentGfxInfo.Width / 3
        End With

        With dRECT
            .Y = Me.Y
            .Height = Me.Height
            .X = Me.X
            .Width = Me.Width
        End With

        RenderTextures(ComponentTexture, window, dRECT.X, dRECT.Y, sRECT.X, sRECT.Y, dRECT.Width, dRECT.Height, sRECT.Width, sRECT.Height, New Color(BackgroundRed, BackgroundGreen, BackgroundBlue))

        If Not String.IsNullOrEmpty(Caption) Then
            DrawText(Me.X + (Me.Width \ 2) - (GetTextWidth(Me.Caption) \ 2), Me.Y + (Me.Height \ 2) - 9, Me.Caption, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, window)
        End If
    End Sub
End Class
