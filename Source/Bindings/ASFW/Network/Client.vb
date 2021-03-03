Imports System
Imports System.Net
Imports System.Net.Sockets

Namespace ASFW.Network

    Public Class Client
        Implements IDisposable


        Private _socket As Socket
        Private _receiveBuffer As Byte()
        Private _packetRing As Byte()
        Private _packetCount As Integer
        Private _packetSize As Integer
        Private _connecting As Boolean
        Public Delegate Sub ConnectionArgs()
        Public Delegate Sub DataArgs(ByRef data As Byte())
        Public Delegate Sub CrashReportArgs(ByVal reason As String)
        Public Delegate Sub PacketInfoArgs(ByVal size As Integer, ByVal header As Integer, ByRef data As Byte())
        Public Delegate Sub TrafficInfoArgs(ByVal size As Integer, ByRef data As Byte())
        Public Event ConnectionSuccess As ConnectionArgs
        Public Event ConnectionFailed As ConnectionArgs
        Public Event ConnectionLost As ConnectionArgs
        Public Event CrashReport As CrashReportArgs
        Public Event PacketReceived As PacketInfoArgs
        Public Event TrafficReceived As TrafficInfoArgs
        Public PacketId As DataArgs()


        ''' <summary> </summary>
        ''' <paramname="packetCount">Tamanho constante do max packet header count.</param>
        Public Sub New(ByVal packetCount As Integer, ByVal Optional packetSize As Integer = 8192)
            If _socket IsNot Nothing Then Return
            If packetSize <= 0 Then packetSize = 8192
            _socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            _packetCount = packetCount
            _packetSize = packetSize
            PacketId = New DataArgs(packetCount - 1) {}
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Disconnect()
            If Not _socket Is Nothing Then
                _socket.Close()
                _socket.Dispose()
            End If
            _socket = Nothing
            PacketId = Nothing
            ConnectionSuccessEvent = Nothing
            ConnectionFailedEvent = Nothing
            ConnectionLostEvent = Nothing
            CrashReportEvent = Nothing
            PacketReceivedEvent = Nothing
            TrafficReceivedEvent = Nothing
            PacketId = Nothing
        End Sub


        ''' <summary>
        ''' Conecta ao ponto-fim específico.
        ''' Invoca um evento se a conexão teve sucesso ou falhou.
        ''' </summary>
        Public Sub Connect(ByVal ip As String, ByVal port As Integer)
            If _socket Is Nothing OrElse _socket.Connected OrElse _connecting Then Return

            If Equals(ip.ToLower(), "localhost") Then
                _socket.BeginConnect(New IPEndPoint(IPAddress.Parse("127.0.0.1"), port), AddressOf DoConnect, Nothing)
                Return
            End If

            _connecting = True
            _socket.BeginConnect(New IPEndPoint(IPAddress.Parse(ip), port), AddressOf DoConnect, Nothing)
        End Sub

        Private Sub DoConnect(ByVal ar As IAsyncResult)
            If Not Socket Is Nothing Then
                Try
                    _socket.EndConnect(ar)
                Catch
                    RaiseEvent ConnectionFailed()
                    _connecting = False
                    Return
                End Try

                If Not _socket.Connected Then
                    RaiseEvent ConnectionFailed()
                    _connecting = False
                    Return
                End If

                _connecting = False
                RaiseEvent ConnectionSuccess()
                _socket.ReceiveBufferSize = _packetSize
                _socket.SendBufferSize = _packetSize
                BeginReceiveData()
            End If
        End Sub


        ''' <summary>
        ''' Retorna verdadeiro se a conexão existir. Pode retornar falso positivo se a conexão foi terminada incorretamente.
        ''' (EX: Outro lado caiu ou nunca pediu desconexão)
        ''' </summary>
        Public ReadOnly Property IsConnected As Boolean
            Get
                Return _socket IsNot Nothing AndAlso _socket.Connected
            End Get
        End Property


        ''' <summary>
        ''' Sinaliza terminação da conexão para o outro lado se conectado a alguém.
        ''' </summary>
        Public Sub Disconnect()
            If _socket Is Nothing OrElse Not _socket.Connected Then Return
            _socket.BeginDisconnect(False, AddressOf DoDisconnect, Nothing)
        End Sub

        Private Sub DoDisconnect(ByVal ar As IAsyncResult)
            If Not _socket Is Nothing Then
                Try
                    _socket.EndDisconnect(ar)
                Catch
                End Try
            End If

            RaiseEvent ConnectionLost()
        End Sub

        Private Sub BeginReceiveData()
            _receiveBuffer = New Byte(_packetSize - 1) {}
            _socket.BeginReceive(_receiveBuffer, 0, _packetSize, SocketFlags.None, AddressOf DoReceive, Nothing)
        End Sub

        Private Sub DoReceive(ByVal ar As IAsyncResult)
            Dim size = 0

            If Not _socket Is Nothing Then

                Try
                    size = _socket.EndReceive(ar)
                Catch
                    RaiseEvent CrashReport("ConnectionForciblyClosedException")
                    Disconnect()
                    Return
                End Try

                If size < 1 Then
                    If _socket Is Nothing Then Return
                    RaiseEvent CrashReport("BufferUnderflowException")
                    Disconnect()
                    Return
                End If

                RaiseEvent TrafficReceived(size, _receiveBuffer)

                If _packetRing Is Nothing Then
                    _packetRing = New Byte(size - 1) {}
                    Buffer.BlockCopy(_receiveBuffer, 0, _packetRing, 0, size)
                Else
                    Dim len = _packetRing.Length
                    Dim data = New Byte(len + size - 1) {}
                    Buffer.BlockCopy(_packetRing, 0, data, 0, len)
                    Buffer.BlockCopy(_receiveBuffer, 0, data, len, size)
                    _packetRing = data
                End If

                PacketHandler()
                _receiveBuffer = New Byte(_packetSize - 1) {}
                _socket.BeginReceive(_receiveBuffer, 0, _packetSize, SocketFlags.None, AddressOf DoReceive, Nothing)
            End If
        End Sub

        Private Sub PacketHandler()
            Dim len = _packetRing.Length
            Dim pos = 0
            Dim count = 0
            Dim size = 0
            Dim index = 0
            Dim data As Byte()

            While True
                count = len - pos

                If count >= 4 Then
                    size = BitConverter.ToInt32(_packetRing, pos)

                    If size >= 4 Then

                        If size <= count Then
                            pos += 4
                            index = BitConverter.ToInt32(_packetRing, pos)

                            If index >= 0 AndAlso index < _packetCount Then

                                If PacketId(index) IsNot Nothing Then
                                    Dim pSize = size - 4
                                    data = New Byte(pSize - 1) {}
                                    If pSize > 0 Then Buffer.BlockCopy(_packetRing, pos + 4, data, 0, pSize)
                                    RaiseEvent PacketReceived(pSize, index, data)
                                    PacketId(index)(data)
                                    pos += size
                                Else
                                    RaiseEvent CrashReport("NullReferenceException")
                                    Disconnect()
                                    Return
                                End If
                            Else
                                RaiseEvent CrashReport("IndexOutOfRangeException")
                                Disconnect()
                                Return
                            End If
                        Else
                            Exit While
                        End If
                    Else
                        RaiseEvent CrashReport("BrokenPacketException")
                        Disconnect()
                        Return
                    End If
                Else
                    Exit While
                End If
            End While

            If count = 0 Then
                _packetRing = Nothing
            Else
                Dim bt() As Byte
                bt = New Byte(count - 1) {}
                Buffer.BlockCopy(_packetRing, pos, bt, 0, count)
                _packetRing = bt
            End If
        End Sub


        ''' <summary>
        ''' Envia vetor de bytes pela rede para o ponto-fim conectado
        ''' [Usado internamente, mas pode ser usado externamente para reduzir possiveis overheads.]
        ''' 
        ''' NOTA: Os primeiros 4 valores/bytes expressam tamanho do dado.
        ''' 
        ''' NOTA 2: Se usando ByteStream, usar o método ToPacket().
        ''' </summary>
        Public Sub SendData(ByVal data As Byte())
            If Not _socket.Connected Then Return
            _socket?.BeginSend(data, 0, data.Length, SocketFlags.None, AddressOf DoSend, Nothing)
        End Sub


        ''' <summary>
        ''' Envia vetor de bytes pela rede para o ponto-fim conectado.
        ''' </summary>
        Public Sub SendData(ByVal data As Byte(), ByVal head As Integer)
            If Not _socket.Connected Then Return
            Dim bt As Byte()
            bt = New Byte(head + 4 - 1) {}
            Buffer.BlockCopy(BitConverter.GetBytes(head), 0, bt, 0, 4)
            Buffer.BlockCopy(data, 0, bt, 4, head)
            _socket?.BeginSend(bt, 0, head + 4, SocketFlags.None, AddressOf DoSend, Nothing)
        End Sub

        Private Sub DoSend(ByVal ar As IAsyncResult)
            Try
                _socket.EndSend(ar)
            Catch
                RaiseEvent CrashReport("ConnectionForciblyClosedException")
                Disconnect()
            End Try
        End Sub
    End Class
End Namespace
