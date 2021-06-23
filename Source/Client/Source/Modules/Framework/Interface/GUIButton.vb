Imports System.Xml.Serialization

Public Class GUIButton
    Inherits GUIObject
    <XmlAttribute("OnClick")>
    Public OnClick As String

    Public Overrides Sub Render()
        Throw New NotImplementedException()
    End Sub
End Class
