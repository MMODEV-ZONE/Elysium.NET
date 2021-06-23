Imports System.Xml.Serialization

Public Class GUITextBox
    Inherits GUIObject
    <XmlAttribute("Text")>
    Public Text As String
    <XmlAttribute("MaskedText")>
    Public MaskedText As Boolean

    Public Overrides Sub Render()
        Throw New NotImplementedException()
    End Sub
End Class
