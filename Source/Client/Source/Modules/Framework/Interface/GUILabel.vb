Imports System.Xml.Serialization

Public Class GUILabel
    Inherits GUIObject
    <XmlAttribute("Text")>
    Public Text As String

    Public Overrides Sub Render()
        Throw New NotImplementedException()
    End Sub
End Class
