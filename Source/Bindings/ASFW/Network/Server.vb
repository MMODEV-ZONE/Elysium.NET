Imports System
Imports System.Collections.Generic
Imports System.Net
Imports System.Net.Sockets

Namespace ASFW.Network
    Public NotInheritable Class Server
        Implements IDisposable


        ''' <summary>
        ''' Retorna verdadeiro se o listener estiver ativo e pode receber pedidos de conexões.
        ''' </summary>

        ''' <summary>
        ''' Retorna o maior índice usado pelos clientes ativos.
        ''' </summary>
        Private _IsListening As Boolean, _HighIndex As Integer

        Friend Structure ReceiveState
            Implements IDisposable

            Friend Index As Integer
            Friend PacketCount As Integer
            Friend Buffer As Byte()
            Friend RingBuffer As Byte()

            Friend Sub New(ByVal index As Integer, ByVal packetSize As Integer)
                Me.Index = index
                PacketCount = 0
                Buffer = New Byte(packetSize - 1) {}
                RingBuffer = Nothing
            End Sub

            Public Sub Dispose() Implements IDisposable.Dispose
                Buffer = Nothing
                RingBuffer = Nothing
            End Sub
        End Structure

        Private _socket As Dictionary(Of Integer, Socket)
        Private _unsignedIndex As List(Of Integer)
        Private _listener As Socket
        Private _pendingAccept As IAsyncResult
        Private _packetCount As Integer
        Private _packetSize As Integer

        ''' <summary>
        ''' Limitação do tamanho de tamanhos de packets a serem recebidos. 0 = sem limites.
        ''' </summary>
        Public Property BufferLimit As Integer = 0

        ''' <summary>
        ''' Retorna o limite de clientes setado na inicialização.
        ''' </summary>
        Public ReadOnly Property ClientLimit As Integer

        Public Property IsListening As Boolean
            Get
                Return _IsListening
            End Get
            Private Set(ByVal value As Boolean)
                _IsListening = value
            End Set
        End Property

        Public Property HighIndex As Integer
            Get
                Return _HighIndex
            End Get
            Private Set(ByVal value As Integer)
                _HighIndex = value
            End Set
        End Property


        ''' <summary>
        ''' Seta o indice mínimo que o listener começa.
        ''' </summary>
        Public Property MinimumIndex As Integer = 0

        ''' <summary>
        ''' O limite de quantas packets podem ser guardadas no buffer de uma vez.
        ''' 0 para sem limites.
        ''' </summary>
        Public Property PacketAcceptLimit As Integer = 0

        ''' <summary>
        ''' Se as packets esperadas nunca chegarem a esse número (EX - Um spam de conexões)
        ''' então desconectar automaticamente. É quase uma ferrametna de prevenção a DDoS.
        ''' 0 para nunca desconectar.
        ''' </summary>
        Public Property PacketDisconnectCount As Integer = 0
        Public Delegate Sub AccessArgs(ByVal index As Integer, ByVal packetid As Integer)
        Public Delegate Sub ConnectionArgs(ByVal index As Integer)
        Public Delegate Sub DataArgs(ByVal index As Integer, ByRef data As Byte())
        Public Delegate Sub CrashReportArgs(ByVal index As Integer, ByVal reason As String)
        Public Delegate Sub PacketInfoArgs(ByVal size As Integer, ByVal header As Integer, ByRef data As Byte())
        Public Delegate Sub TrafficInfoArgs(ByVal size As Integer, ByRef data As Byte())
        Public Delegate Sub NullArgs()
        Public Event AccessCheck As AccessArgs
        Public Event ConnectionReceived As ConnectionArgs
        Public Event ConnectionLost As ConnectionArgs
        Public Event CrashReport As CrashReportArgs
        Public Event PacketReceived As PacketInfoArgs
        Public Event TrafficReceived As TrafficInfoArgs
        Public PacketId As DataArgs()


        ''' <summary> Se o clientLimit é deixado em zero, então novas conexões não serão recusadas. </summary>
        ''' <paramname="packetCount">Tamanho constante do contador de cabeçalho da packet.</param>
        ''' <paramname="packetSize">Tamanho constante do buffer da packet.</param>
        Public Sub New(ByVal packetCount As Integer, ByVal Optional packetSize As Integer = 8192, ByVal Optional clientLimit As Integer = 0)
            If _listener IsNot Nothing OrElse _socket IsNot Nothing Then Return
            If packetSize <= 0 Then packetSize = 8192
            _socket = New Dictionary(Of Integer, Socket)()
            _unsignedIndex = New List(Of Integer)()
            Me.ClientLimit = clientLimit
            _packetCount = packetCount
            _packetSize = packetSize
            PacketId = New DataArgs(packetCount - 1) {}
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            StopListening()

            For Each index As Integer In _socket.Keys
                Disconnect(index)
            Next

            _socket.Clear()
            _socket = Nothing
            PacketId = Nothing
            _unsignedIndex.Clear()
            _unsignedIndex = Nothing
            AccessCheckEvent = Nothing
            ConnectionReceivedEvent = Nothing
            ConnectionLostEvent = Nothing
            CrashReportEvent = Nothing
            PacketReceivedEvent = Nothing
            TrafficReceivedEvent = Nothing
            PacketId = Nothing
        End Sub


        ''' <summary>
        ''' Retorna verdadeiro se uma conexão existe. Pode retornar falso positivo se
        ''' a conexão foi terminada incorretamente (EX: outro lado caiu e nunca pediu desconexão).
        ''' </summary>
        Public Function IsConnected(ByVal index As Integer) As Boolean
            If Not _socket.ContainsKey(index) Then Return False
            If _socket(index).Connected Then Return True
            Disconnect(index)
            Return False
        End Function


        ''' <summary>
        ''' Retorna a IP de conexão de área local ou o IPv4 do servidor.
        ''' </summary>
        Public Function GetIPv4() As String
            Return Dns.GetHostEntry(Dns.GetHostName()).AddressList(0).ToString()
        End Function


        ''' <summary>
        ''' Retorna ip salvo no index 
        ''' </summary>
        ''' <paramname="index"></param>
        ''' <returns></returns>
        Public Function ClientIp(ByVal index As Integer) As String
            If IsConnected(index) Then Return CType(_socket(index).RemoteEndPoint, IPEndPoint).Address.ToString()
            Return "[Nulo]"
        End Function


        ''' <summary>
        ''' Sinaliza término de conexão para o outro lado se conectado a alguém.
        ''' </summary>
        Public Sub Disconnect(ByVal index As Integer)
            If Not _socket.ContainsKey(index) Then Return
            Dim socket = _socket(index)

            If socket Is Nothing Then
                _socket.Remove(index)
                _unsignedIndex.Add(index)
                Return
            End If

            socket.BeginDisconnect(False, AddressOf DoDisconnect, index)
            ListenManager()
        End Sub

        Private Sub DoDisconnect(ByVal ar As IAsyncResult)
            Dim index = CInt(ar.AsyncState)

            Try
                _socket(index).EndDisconnect(ar)
            Catch
            End Try

            If Not _socket.ContainsKey(index) Then Return ' Bugged?
            _socket(index).Dispose()
            Me._socket(index) = Nothing
            _socket.Remove(index)
            _unsignedIndex.Add(index)
            RaiseEvent ConnectionLost(index)
        End Sub

        Private Function FindEmptySlot(ByVal startIndex As Integer) As Integer
            For b As Integer = _unsignedIndex.Count - 1 To 0 Step -1

                If HighIndex = _unsignedIndex(b) Then
                    HighIndex -= 1
                Else
                    Exit For
                End If
            Next

            If _unsignedIndex.Count > 0 Then

                For Each index As Integer In _unsignedIndex
                    If HighIndex < index Then HighIndex = index
                    _unsignedIndex.Remove(index)
                    Return index
                Next

                If HighIndex < startIndex Then HighIndex = startIndex
                Return startIndex
            End If

            If HighIndex < startIndex Then
                Dim index As Integer = startIndex

                While _socket.ContainsKey(index)
                    index += 1
                End While

                HighIndex = index
                If HighIndex > ClientLimit Then HighIndex = ClientLimit
                Return index
            End If

            While _socket.ContainsKey(HighIndex)
                HighIndex += 1
                If HighIndex > ClientLimit Then HighIndex = ClientLimit
            End While

            Return HighIndex
        End Function


        ''' <summary>
        ''' Ativa listener se já não estiver ativo.
        ''' </summary>
        Public Sub StartListening(ByVal port As Integer, ByVal backlog As Integer)
            If _socket Is Nothing OrElse IsListening OrElse _listener IsNot Nothing Then Return
            _listener = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            _listener.Bind(New IPEndPoint(IPAddress.Any, port))
            IsListening = True
            _listener.Listen(backlog)
            ListenManager()
        End Sub


        ''' <summary>
        ''' Desativa listener se estiver ativo.
        ''' </summary>
        Public Sub StopListening()
            If Not IsListening OrElse _socket Is Nothing Then Return
            IsListening = False
            If _listener Is Nothing Then Return
            _listener.Close()
            _listener.Dispose()
            _listener = Nothing
        End Sub

        Private Sub DoAcceptClient(ByVal ar As IAsyncResult)
            Dim socket = EndAccept(ar)

            If socket IsNot Nothing Then
                Dim index = FindEmptySlot(MinimumIndex)
                _socket.Add(index, socket)
                _socket(index).ReceiveBufferSize = _packetSize
                _socket(index).SendBufferSize = _packetSize
                BeginReceiveData(index)
                RaiseEvent ConnectionReceived(index)
            End If

            ListenManager()
        End Sub

        Private Function EndAccept(ByVal Optional ar As IAsyncResult = Nothing) As Socket
            Dim pendingAccept = If(ar, _pendingAccept)

            If pendingAccept Is Nothing OrElse _listener Is Nothing Then
                Return Nothing
            End If

            _pendingAccept = Nothing
            Return _listener.EndAccept(pendingAccept)
        End Function

        Private Sub ListenManager()
            If Not IsListening OrElse _listener Is Nothing OrElse _pendingAccept IsNot Nothing Then
                Return
            End If

            If ClientLimit > 0 AndAlso ClientLimit < _socket.Count Then
                Return
            End If

            _pendingAccept = _listener.BeginAccept(AddressOf DoAcceptClient, Nothing)
        End Sub

        Private Sub BeginReceiveData(ByVal index As Integer)
            Dim so = New ReceiveState(index, _packetSize)

            Try
                _socket(index).BeginReceive(so.Buffer, 0, _packetSize, SocketFlags.None, AddressOf DoReceive, so)
            Catch
            End Try
        End Sub

        Private Sub DoReceive(ByVal ar As IAsyncResult)
            Dim so = CType(ar.AsyncState, ReceiveState)
            Dim size = 0

            Try
                size = _socket(so.Index).EndReceive(ar)
            Catch
                RaiseEvent CrashReport(so.Index, "ConnectionForciblyClosedException")
                Disconnect(so.Index)
                so.Dispose()
                Return
            End Try

            If size < 1 Then

                If Not _socket.ContainsKey(so.Index) Then
                    so.Dispose()
                    Return
                End If

                If _socket(so.Index) Is Nothing Then
                    so.Dispose()
                    Return
                End If

                RaiseEvent CrashReport(so.Index, "BufferUnderflowException")
                Disconnect(so.Index)
                so.Dispose()
                Return
            End If

            RaiseEvent TrafficReceived(size, so.Buffer)
            so.PacketCount += 1

            If PacketDisconnectCount > 0 AndAlso so.PacketCount >= PacketDisconnectCount Then
                RaiseEvent CrashReport(so.Index, "Packet Spamming/DDOS")
                Disconnect(so.Index)
                so.Dispose()
                Return
            End If

            If PacketAcceptLimit = 0 OrElse PacketAcceptLimit > so.PacketCount Then

                If so.RingBuffer Is Nothing Then
                    so.RingBuffer = New Byte(size - 1) {}
                    Buffer.BlockCopy(so.Buffer, 0, so.RingBuffer, 0, size)
                Else
                    Dim len = so.RingBuffer.Length
                    Dim data = New Byte(len + size - 1) {}
                    Buffer.BlockCopy(so.RingBuffer, 0, data, 0, len)
                    Buffer.BlockCopy(so.Buffer, 0, data, len, size)
                    so.RingBuffer = data
                End If

                If BufferLimit > 0 AndAlso so.RingBuffer.Length > BufferLimit Then
                    Disconnect(so.Index)
                    so.Dispose()
                    Return
                End If
            End If

            If Not _socket.ContainsKey(so.Index) Then
                so.Dispose()
                Return
            End If

            If _socket(so.Index) Is Nothing OrElse Not _socket(so.Index).Connected Then
                Disconnect(so.Index)
                so.Dispose()
                Return
            End If

            PacketHandler(so)
            so.Buffer = New Byte(_packetSize - 1) {}

            If Not _socket.ContainsKey(so.Index) Then
                so.Dispose()
                Return
            End If

            Try
                _socket(so.Index).BeginReceive(so.Buffer, 0, _packetSize, SocketFlags.None, AddressOf DoReceive, so)
            Catch
            End Try
        End Sub

        Private Sub PacketHandler(ByRef so As ReceiveState)
            Dim connectionID = so.Index
            Dim len = so.RingBuffer.Length
            Dim pos = 0
            Dim count = 0
            Dim size = 0
            Dim index = 0
            Dim didHandle = False
            Dim data As Byte()

            While True
                count = len - pos

                If count >= 4 Then
                    size = BitConverter.ToInt32(so.RingBuffer, pos)

                    If size >= 4 Then

                        If size <= count Then
                            pos += 4
                            index = BitConverter.ToInt32(so.RingBuffer, pos)

                            If index >= 0 AndAlso index < _packetCount Then

                                If PacketId(index) IsNot Nothing Then

                                    If AccessCheckEvent IsNot Nothing Then
                                        RaiseEvent AccessCheck(connectionID, index)

                                        If Not _socket.ContainsKey(connectionID) Then
                                            so.Dispose()
                                            Return
                                        End If
                                    End If

                                    Dim pSize = size - 4
                                    data = New Byte(pSize - 1) {}
                                    If pSize > 0 Then Buffer.BlockCopy(so.RingBuffer, pos + 4, data, 0, pSize)
                                    RaiseEvent PacketReceived(pSize, index, data)
                                    PacketId(index)(connectionID, data)
                                    pos += size
                                    so.PacketCount -= 1
                                    didHandle = True
                                Else

                                    If Not _socket.ContainsKey(connectionID) Then
                                        so.Dispose()
                                        Return
                                    End If

                                    RaiseEvent CrashReport(connectionID, "NullReferenceException")
                                    Disconnect(connectionID)
                                    so.Dispose()
                                    Return
                                End If
                            Else

                                If Not _socket.ContainsKey(connectionID) Then
                                    so.Dispose()
                                    Return
                                End If

                                RaiseEvent CrashReport(connectionID, "IndexOutOfRangeException")
                                Disconnect(connectionID)
                                so.Dispose()
                                Return
                            End If
                        Else
                            Exit While
                        End If
                    Else

                        If Not _socket.ContainsKey(connectionID) Then
                            so.Dispose()
                            Return
                        End If

                        RaiseEvent CrashReport(connectionID, "BrokenPacketException")
                        Disconnect(connectionID)
                        so.Dispose()
                        Return
                    End If
                Else
                    Exit While
                End If
            End While

            If count = 0 Then
                so.RingBuffer = Nothing
                so.PacketCount = 0
            Else
                Dim buffer = New Byte(count - 1) {}
                System.Buffer.BlockCopy(so.RingBuffer, pos, buffer, 0, count)
                so.RingBuffer = buffer
                If didHandle Then so.PacketCount = 1
            End If
        End Sub


        ''' <summary>
        ''' Envia vetor de bytes pela rede para o ponto-fim contado.
        ''' [Usado internamente, mas pode ser usado externamente como forma de reduzir overhead.]
        ''' 
        ''' NOTA: Requer os primeiros 4 valores do dado expresse o tamanho. 
        ''' NOTE 2: Se usando o ByetStream, usar o método ToPacket().
        ''' </summary>
        Public Sub SendDataTo(ByVal index As Integer, ByVal data As Byte())
            If Not _socket.ContainsKey(index) Then Return

            If _socket(index) Is Nothing OrElse Not _socket(index).Connected Then
                Disconnect(index)
                Return
            End If

            _socket(index).BeginSend(data, 0, data.Length, SocketFlags.None, AddressOf DoSend, index)
        End Sub


        ''' <summary>
        '''  Envia o vetor de bytes pela rede para um conectado específico.
        ''' </summary>
        Public Sub SendDataTo(ByVal index As Integer, ByVal data As Byte(), ByVal head As Integer)
            If Not _socket.ContainsKey(index) Then Return

            If _socket(index) Is Nothing OrElse Not _socket(index).Connected Then
                Disconnect(index)
                Return
            End If

            Dim buffer = New Byte(head + 4 - 1) {}
            System.Buffer.BlockCopy(BitConverter.GetBytes(head), 0, buffer, 0, 4)
            System.Buffer.BlockCopy(data, 0, buffer, 4, head)
            _socket(index).BeginSend(buffer, 0, head + 4, SocketFlags.None, AddressOf DoSend, index)
        End Sub


        ''' <summary>
        '''  Envia o vetor de bytes pela rede para todos os conectados.
        ''' </summary>
        Public Sub SendDataToAll(ByVal data As Byte(), ByVal head As Integer)
            Dim buffer = New Byte(head + 4 - 1) {}
            System.Buffer.BlockCopy(BitConverter.GetBytes(head), 0, buffer, 0, 4)
            System.Buffer.BlockCopy(data, 0, buffer, 4, head)

            For i As Integer = 0 To HighIndex
                If _socket.ContainsKey(i) Then SendDataTo(i, buffer)
            Next
        End Sub


        ''' <summary>
        ''' Envia o vetor de bytes pela rede para todos os conectados, excluindo o índice específico.
        ''' </summary>
        Public Sub SendDataToAllBut(ByVal index As Integer, ByVal data As Byte(), ByVal head As Integer)
            Dim buffer = New Byte(head + 4 - 1) {}
            System.Buffer.BlockCopy(BitConverter.GetBytes(head), 0, buffer, 0, 4)
            System.Buffer.BlockCopy(data, 0, buffer, 4, head)

            For i As Integer = 0 To HighIndex

                If _socket.ContainsKey(i) Then
                    If i <> index Then SendDataTo(i, buffer)
                End If
            Next
        End Sub

        Private Sub DoSend(ByVal ar As IAsyncResult)
            Dim index = CInt(ar.AsyncState)

            Try
                _socket(index).EndSend(ar)
            Catch
                RaiseEvent CrashReport(index, "ConnectionForciblyClosedException")
                Disconnect(index)
            End Try
        End Sub
    End Class
End Namespace