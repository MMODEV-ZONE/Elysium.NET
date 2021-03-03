Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization

Namespace ASFW.IO
    Public Module Serialization
        ''' <summary>
        ''' Salva um objeto de classe serializável como XML em um arquivo específico.
        ''' </summary>
        Public Sub SaveXml(Of T)(ByVal path As String, ByVal obj As Object)
            Dim serializer As XmlSerializer = New XmlSerializer(GetType(T))

            Using streamWriter As StreamWriter = New StreamWriter(path)
                serializer.Serialize(streamWriter, obj)
            End Using
        End Sub

        ''' <summary>
        ''' Carrega o arquivo XML como objeto serializável.
        ''' </summary>
        Public Function LoadXml(Of T)(ByVal path As String) As Object
            Dim serializer As XmlSerializer = New XmlSerializer(GetType(T))

            Using streamReader As StreamReader = New StreamReader(path)
                Return serializer.Deserialize(streamReader)
            End Using
        End Function


        ''' <summary>
        ''' Returns a byte array from a serializable class object.
        ''' </summary>
        Public Function FromObject(ByVal [Object] As Object) As Byte()
            Using ms = New MemoryStream()
                Call New BinaryFormatter().Serialize(ms, [Object])
                Return ms.GetBuffer()
            End Using
        End Function


        ''' <summary>
        ''' Retorna um objeto de um vetor de bytes.
        ''' </summary>
        Public Function ToObject(ByVal bytes As Byte()) As Object
            Using ms = New MemoryStream(bytes)
                Return New BinaryFormatter().Deserialize(ms)
            End Using
        End Function
    End Module
End Namespace