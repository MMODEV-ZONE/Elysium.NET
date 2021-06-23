Imports System.Xml.Serialization

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

    Public MustOverride Sub Render()
End Class
