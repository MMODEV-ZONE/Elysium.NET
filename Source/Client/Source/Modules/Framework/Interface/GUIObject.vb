Public MustInherit Class GUIObject
    Public Name As String
    Public X As Integer
    Public Y As Integer
    Public Enabled As Boolean

    Public MustOverride Sub Render()
End Class
