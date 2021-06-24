Imports System.Xml.Serialization
Imports SFML.Graphics

Public Class GUITextBox
    Inherits GUIObject
    <XmlAttribute("Text")>
    Public Text As String
    <XmlAttribute("MaskedText")>
    Public MaskedText As Boolean

    Public Overrides Sub Render(window As RenderWindow)
        Throw New NotImplementedException()
    End Sub
End Class
