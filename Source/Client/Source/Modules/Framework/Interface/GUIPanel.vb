Public Class GUIPanel
    Inherits GUIObject

    Public ControlBox As Boolean
    Public Caption As String
    Public Children As List(Of GUIObject)

    Public Sub New()
        Children = New List(Of GUIObject)
    End Sub

    Public Overrides Sub Render()
        Throw New NotImplementedException()
    End Sub
End Class
