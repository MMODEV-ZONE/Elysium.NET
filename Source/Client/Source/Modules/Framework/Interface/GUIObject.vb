Imports System.Xml.Serialization
Imports SFML.Graphics

<XmlInclude(GetType(GUILabel)),
    XmlInclude(GetType(GUITextBox)),
    XmlInclude(GetType(GUIPanel)),
    XmlInclude(GetType(GUIButton))>
Public MustInherit Class GUIObject
    <XmlAttribute("Name")>
    Public Name As String
    <XmlAttribute("X")>
    Public X As Integer
    <XmlAttribute("Y")>
    Public Y As Integer
    <XmlAttribute("Enabled")>
    Public Enabled As Boolean

    <XmlIgnore>
    Friend ComponentTexture As Texture
    <XmlIgnore>
    Friend ComponentSprite As Sprite
    <XmlIgnore>
    Friend ComponentGfxInfo As GraphicInfo

    Public MustOverride Sub Render(window As RenderWindow)

    Protected Sub LoadComponentTexture(background As String)
        Dim backgroundPath = Path.Gui & Settings.GUI & "\Componentes\" & background & GuiExt

        If ComponentGfxInfo.IsLoaded = False Or ComponentGfxInfo.TextureTimer < GetTickCount() Then
            ComponentTexture = New Texture(backgroundPath)
            ComponentSprite = New Sprite(ComponentTexture)

            With ComponentGfxInfo
                .Width = ComponentTexture.Size.X
                .Height = ComponentTexture.Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With
        End If
    End Sub
End Class
