Imports System.Xml.Serialization
Imports SFML.Graphics

Public Class GUILabel
    Inherits GUIObject
    <XmlAttribute("Text")>
    Public Text As String

    Public Overrides Sub Render(window As RenderWindow)
        Throw New NotImplementedException()
    End Sub
End Class
