
Module S_Serialization
    Function Serialize(ByVal Entity As Object) As Byte()
        Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Using ms = New System.IO.MemoryStream()
            formatter.Serialize(ms, Entity)
            Return ms.GetBuffer()
        End Using
    End Function

    Public Sub Deserialize(ByRef Entity As Object, data As Byte())
        Dim formatter = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Using ms = New System.IO.MemoryStream(data)
            formatter.Binder = New S_Binder()
            Entity = formatter.Deserialize(ms)
        End Using
    End Sub

    Function SerializeData(Element As Object) As Byte()
        Dim buffer As New ASFW.ByteStream(4)
        Dim SerializedData As Byte() = Serialize(Element)
        buffer.WriteInt32(SerializedData.Length)
        buffer.WriteBlock(SerializedData)
        Return buffer.ToArray
    End Function

    Function DeserializeData(ByRef buffer As ASFW.ByteStream) As Object
        Dim byteCount As Integer = buffer.ReadInt32
        Dim element As Object = Nothing
        Deserialize(element, buffer.ReadBlock(byteCount))
        Return element
    End Function
End Module
