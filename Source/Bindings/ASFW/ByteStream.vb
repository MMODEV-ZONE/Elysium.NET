Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Text
Imports System.Reflection

Namespace ASFW
    ''' <summary>
    ''' Um objeto no buffer feito de vetor de bytes. 
    ''' </summary>
    Public Structure ByteStream
        Implements IDisposable

        ''' <summary>
        ''' O vetor de bytes interno.
        ''' </summary>
        Public Data As Byte()
        ''' <summary>
        ''' O cabeçalho de leitura/escrita. This moves on read AND write code so keep track of this
        ''' if attempting to read and write at the same time.
        ''' </summary>
        Public Head As Integer


#Region "General"

        Public Sub New(ByVal Optional initialSize As Integer = 4)
            Data = New Byte(initialSize - 1) {}
            Head = 0
        End Sub

        Public Sub New(ByVal bytes As Byte())
            Data = bytes
            Head = 0
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Data = Nothing
            Head = 0
        End Sub

        Public Function ToArray() As Byte()
            Dim ret = New Byte(Head - 1) {}
            Buffer.BlockCopy(Data, 0, ret, 0, Head)
            Return ret
        End Function


        ''' <summary>
        ''' Para uso com a networking desta biblioteca.
        ''' Faz o pacote do vetor de dados com 4 valores extra no cabeçalho.
        ''' </summary>
        ''' <returns></returns>
        Public Function ToPacket() As Byte()
            Dim ret = New Byte(4 + Head - 1) {}
            Dim size = BitConverter.GetBytes(Head)
            Buffer.BlockCopy(size, 0, ret, 0, 4)
            Buffer.BlockCopy(Data, 0, ret, 4, Head)
            Return ret
        End Function

        Private Sub CheckSize(ByVal length As Integer)
            Dim len = Data.Length
            If length + Head < len Then Return
            If len < 4 Then len = 4
            len *= 2

            While length + Head >= len
                len *= 2
            End While

            Dim buf = New Byte(len - 1) {}
            Buffer.BlockCopy(Data, 0, buf, 0, Head)
            Data = buf
        End Sub


#End Region

#Region "Read"
        ''' <summary>
        ''' Lê um vetor de bytes do stream sem ler por um tamanho predefinido.
        ''' </summary>
        Public Function ReadBlock(ByVal size As Integer) As Byte()
            If size <= 0 OrElse Head + size > Data.Length Then Return New Byte(-1) {}
            Dim ret = New Byte(size - 1) {}
            Buffer.BlockCopy(Data, Head, ret, 0, size)
            Head += size
            Return ret
        End Function


        ''' <summary>
        ''' Lê um objeto serializável do stream.
        ''' </summary>
        Public Function ReadObject() As Object
            Dim value = ReadBytes()
            If value.Length <= 0 Then Return Nothing

            Using ms = New MemoryStream(value)
                Dim bf = New BinaryFormatter()
                bf.Binder = New ASFWBinder()
                Return bf.Deserialize(ms)
            End Using
        End Function


        ''' <summary>
        ''' Lê um vetor de bytes e seu tamanho dos stream.
        ''' </summary>
        Public Function ReadBytes() As Byte()
            If Head + 4 > Data.Length Then Return New Byte(-1) {}
            Dim len = BitConverter.ToInt32(Data, Head)
            Head += 4
            If len <= 0 OrElse Head + len > Data.Length Then Return New Byte(-1) {}
            Dim ret = New Byte(len - 1) {}
            Buffer.BlockCopy(Data, Head, ret, 0, len)
            Head += len
            Return ret
        End Function


        ''' <summary>
        ''' Lê uma string regular do fluxo.
        ''' </summary>
        Public Function ReadString() As String
            If Head + 4 > Data.Length Then Return ""
            Dim len = BitConverter.ToInt32(Data, Head)
            Head += 4
            If len <= 0 OrElse Head + len > Data.Length Then Return ""
            Dim ret = Encoding.UTF8.GetString(Data, Head, len)
            Head += len
            Return ret
        End Function


        ''' <summary>
        ''' Lê um caractere do fluxo.
        ''' </summary>
        Public Function ReadChar() As Char
            If Head + 2 > Data.Length Then Return Char.MinValue
            Dim ret = BitConverter.ToChar(Data, Head)
            Head += 2
            Return ret
        End Function


        ''' <summary>
        ''' Lê um byte do fluxo.
        ''' </summary>
        Public Function ReadByte() As Byte
            If Head + 1 > Data.Length Then Return 0
            Dim ret = Data(Head)
            Head += 1
            Return ret
        End Function


        ''' <summary>
        ''' Lê um booleano do fluxo.
        ''' </summary>
        Public Function ReadBoolean() As Boolean
            If Head + 1 > Data.Length Then Return False
            Dim ret = BitConverter.ToBoolean(Data, Head)
            Head += 1
            Return ret
        End Function


        ''' <summary>
        ''' Lê um short do fluxo.
        ''' </summary>
        Public Function ReadInt16() As Short
            If Head + 2 > Data.Length Then Return 0
            Dim ret = BitConverter.ToInt16(Data, Head)
            Head += 2
            Return ret
        End Function


        ''' <summary>
        ''' Lê um unsigned short do fluxo.
        ''' </summary>
        Public Function ReadUInt16() As UShort
            If Head + 2 > Data.Length Then Return 0
            Dim ret = BitConverter.ToUInt16(Data, Head)
            Head += 2
            Return ret
        End Function


        ''' <summary>
        ''' Lê um integer do fluxo/stream.
        ''' </summary>
        Public Function ReadInt32() As Integer
            If Head + 4 > Data.Length Then Return 0
            Dim ret = BitConverter.ToInt32(Data, Head)
            Head += 4
            Return ret
        End Function


        ''' <summary>
        ''' Lê um unsigned integer do fluxo.
        ''' </summary>
        Public Function ReadUInt32() As UInteger
            If Head + 4 > Data.Length Then Return 0
            Dim ret = BitConverter.ToUInt32(Data, Head)
            Head += 4
            Return ret
        End Function


        ''' <summary>
        ''' Lê um ponto flutuante de precisão simples do fluxo.
        ''' </summary>
        Public Function ReadSingle() As Single
            If Head + 4 > Data.Length Then Return 0.0F
            Dim ret = BitConverter.ToSingle(Data, Head)
            Head += 4
            Return ret
        End Function


        ''' <summary>
        ''' Lê um long do fluxo.
        ''' </summary>
        Public Function ReadInt64() As Long
            If Head + 8 > Data.Length Then Return 0
            Dim ret = BitConverter.ToInt64(Data, Head)
            Head += 8
            Return ret
        End Function


        ''' <summary>
        ''' Lê um unsigned long do fluxo.
        ''' </summary>
        Public Function ReadUInt64() As ULong
            If Head + 8 > Data.Length Then Return 0
            Dim ret = BitConverter.ToUInt64(Data, Head)
            Head += 8
            Return ret
        End Function


        ''' <summary>
        ''' Lê um ponto flutuante de precisão dupla do fluxo.
        ''' </summary>
        Public Function ReadDouble() As Double
            If Head + 8 > Data.Length Then Return 0.0
            Dim ret = BitConverter.ToDouble(Data, Head)
            Head += 8
            Return ret
        End Function

#End Region

#Region "Write"
        ''' <summary>
        ''' Escreve um vetor de bytes para o fluxo sem preescrever seu tamanho.
        ''' </summary>
        Public Sub WriteBlock(ByVal bytes As Byte())
            CheckSize(bytes.Length)
            Buffer.BlockCopy(bytes, 0, Data, Head, bytes.Length)
            Head += bytes.Length
        End Sub


        ''' <summary>
        ''' Escreve um vetor de bytes para o fluxo sem preescrever seu tamanho.
        ''' </summary>
        Public Sub WriteBlock(ByVal bytes As Byte(), ByVal offset As Integer, ByVal size As Integer)
            CheckSize(size)
            Buffer.BlockCopy(bytes, offset, Data, Head, size)
            Head += size
        End Sub


        ''' <summary>
        ''' Escreve um objeto serializável no fluxo..
        ''' </summary>
        Public Sub WriteObject(ByVal value As Object)
            Using ms = New MemoryStream()
                Call New BinaryFormatter().Serialize(ms, value)
                WriteBytes(ms.GetBuffer())
            End Using
        End Sub


        ''' <summary>
        ''' Escreve um vetor de bytes e seu tamanho no fluxo.
        ''' </summary>
        Public Sub WriteBytes(ByVal value As Byte(), ByVal offset As Integer, ByVal size As Integer)
            WriteBlock(BitConverter.GetBytes(size))
            WriteBlock(value, offset, size)
        End Sub


        ''' <summary>
        ''' Escreve um vetor de bytes e seu tamanho no fluxo..
        ''' </summary>
        Public Sub WriteBytes(ByVal value As Byte())
            WriteBlock(BitConverter.GetBytes(value.Length))
            WriteBlock(value)
        End Sub


        ''' <summary>
        ''' Escreve uma string comum no fluxo.
        ''' </summary>
        Public Sub WriteString(ByVal value As String)
            If Equals(value, Nothing) Then
                WriteBlock(BitConverter.GetBytes(0))
                Return
            End If

            Dim bytes = Encoding.UTF8.GetBytes(value)
            WriteBlock(BitConverter.GetBytes(bytes.Length))
            WriteBlock(bytes)
        End Sub


        ''' <summary>
        ''' Escreve um caractere no fluxo.
        ''' </summary>
        Public Sub WriteChar(ByVal value As Char)
            WriteBlock(BitConverter.GetBytes(value))
        End Sub

        ''' <summary>
        ''' Escreve um byte no fluxo.
        ''' </summary>
        Public Sub WriteByte(ByVal value As Byte)
            CheckSize(1)
            Data(Head) = value
            Head += 1
        End Sub

        ''' <summary>
        ''' Escreve um booleano no fluxo.
        ''' </summary>
        Public Sub WriteBoolean(ByVal value As Boolean)
            WriteBlock(BitConverter.GetBytes(value))
        End Sub

        ''' <summary>
        ''' Escreve um short no fluxo.
        ''' </summary>
        Public Sub WriteInt16(ByVal value As Short)
            WriteBlock(BitConverter.GetBytes(value))
        End Sub

        ''' <summary>
        ''' Escreve um unsigned short no fluxo.
        ''' </summary>
        Public Sub WriteUInt16(ByVal value As UShort)
            WriteBlock(BitConverter.GetBytes(value))
        End Sub

        ''' <summary>
        ''' Escreve um integer no fluxo.
        ''' </summary>
        Public Sub WriteInt32(ByVal value As Integer)
            WriteBlock(BitConverter.GetBytes(value))
        End Sub

        ''' <summary>
        ''' Escreve um unsigned integer no fluxo.
        ''' </summary>
        Public Sub WriteUInt32(ByVal value As UInteger)
            WriteBlock(BitConverter.GetBytes(value))
        End Sub

        ''' <summary>
        ''' Escreve um ponto flutuante de precisão simples do fluxo.
        ''' </summary>
        Public Sub WriteSingle(ByVal value As Single)
            WriteBlock(BitConverter.GetBytes(value))
        End Sub

        ''' <summary>
        ''' Escreve um long no fluxo.
        ''' </summary>
        Public Sub WriteInt64(ByVal value As Long)
            WriteBlock(BitConverter.GetBytes(value))
        End Sub

        ''' <summary>
        ''' Escreve um unsigned long no fluxo.
        ''' </summary>
        Public Sub WriteUInt64(ByVal value As ULong)
            WriteBlock(BitConverter.GetBytes(value))
        End Sub

        ''' <summary>
        ''' Escreve um ponto flutuante de precisão duplo do fluxo.
        ''' </summary>
        Public Sub WriteDouble(ByVal value As Double)
            WriteBlock(BitConverter.GetBytes(value))
        End Sub

#End Region

        ''' <summary> Binder de uso interno. </summary>
        Private Class ASFWBinder
            Inherits SerializationBinder

            Public Overrides Function BindToType(ByVal assemblyName As String, ByVal typeName As String) As Type
                assemblyName = Assembly.GetEntryAssembly().FullName
                Return Type.GetType(typeName & ", " & assemblyName)
            End Function
        End Class
    End Structure
End Namespace
