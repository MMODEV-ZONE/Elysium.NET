Imports System.Net
Imports ASFW.Network

Friend Module S_NetworkConfig
    Friend WithEvents Socket As Server

    Friend Sub InitNetwork()
        If Not Socket Is Nothing Then Return
        ' Estabelecer algumas regras
        Socket = New Server(ClientPackets.Count, 4096, MAX_PLAYERS) With {
            .BufferLimit = 2048000, ' <- 2mb de armazenamento máximo
            .MinimumIndex = 1, ' <- Previne que a rede nos dê 0 de índice
            .PacketAcceptLimit = 100, ' Não sei qual seria um limite razoável agora, entao por que não?
            .PacketDisconnectCount = 150 ' Se a outra coisa era pelo menos razoável, então este é certamente o contador de spam!
            }

        PacketRouter() ' Precisa dos packets Ids!
    End Sub

    Friend Sub DestroyNetwork()
        Socket.Dispose()
    End Sub

    Friend Function GetIP() As String
        Dim request = HttpWebRequest.Create(New Uri("http://ascensiongamedev.com/resources/myip.php"))
        request.Method = WebRequestMethods.Http.Get

        Try
            Dim reader As New IO.StreamReader(request.GetResponse().GetResponseStream())
            Return reader.ReadToEnd()
        Catch e As Exception
            Return "127.0.0.1"
        End Try
    End Function

    Function IsLoggedIn(index As Integer) As Boolean
        Return Len(Trim$(Player(index).Login)) > 0
    End Function

    Function IsPlaying(index As Integer) As Boolean
        Return TempPlayer(index).InGame
    End Function

    Function IsMultiAccounts(Login As String) As Boolean
        ' Isso estava quebrado antes
        For i As Integer = 1 To GetPlayersOnline()
            If Player(i).Login.Trim.ToLower() = Login.Trim.ToLower() Then Return True
        Next
        Return False
    End Function

    Friend Sub SendDataToAll(ByRef data() As Byte, head As Integer)
        For i As Integer = 1 To GetPlayersOnline()
            If IsPlaying(i) Then
                Socket.SendDataTo(i, data, head)
            End If
        Next
    End Sub

    Sub SendDataToAllBut(index As Integer, ByRef data() As Byte, head As Integer)
        For i As Integer = 1 To GetPlayersOnline()
            If IsPlaying(i) AndAlso i <> index Then
                Socket.SendDataTo(i, data, head)
            End If
        Next
    End Sub

    Sub SendDataToMapBut(index As Integer, mapNum As Integer, ByRef data() As Byte, head As Integer)
        For i As Integer = 1 To GetPlayersOnline()
            If IsPlaying(i) AndAlso GetPlayerMap(i) = mapNum AndAlso i <> index Then
                Socket.SendDataTo(i, data, head)
            End If
        Next
    End Sub

    Sub SendDataToMap(mapNum As Integer, ByRef data() As Byte, head As Integer)
        Dim i As Integer

        For i = 1 To GetPlayersOnline()

            If IsPlaying(i) Then
                If GetPlayerMap(i) = mapNum Then
                    Socket.SendDataTo(i, data, head)
                End If
            End If

        Next

    End Sub

#Region " Events "

    Friend Sub Socket_ConnectionReceived(index As Integer) Handles Socket.ConnectionReceived
        Console.WriteLine("Conexão recebida no índice[" & index & "] - IP[" & Socket.ClientIp(index) & "]")
        SendKeyPair(index)
        SendNews(index)
    End Sub

    Friend Sub Socket_ConnectionLost(index As Integer) Handles Socket.ConnectionLost
        Console.WriteLine("Conexão recebida no índice[" & index & "] - IP[" & Socket.ClientIp(index) & "]")
        LeftGame(index)
    End Sub

    Friend Sub Socket_CrashReport(index As Integer, err As String) Handles Socket.CrashReport
        Console.WriteLine("Houve um erro de rede -> Índice[" & index & "]")
        Console.WriteLine("Relatório: " & err)
        LeftGame(index)
    End Sub

    Private Sub Socket_TrafficReceived(size As Integer, ByRef data() As Byte) Handles Socket.TrafficReceived
        If DebugTxt = True Then
            Console.WriteLine("Tráfego Recebido : [Tamanho: " & size & "]")
        End If

        Dim tmpData = data
        Dim BreakPointDummy As Integer = 0
    End Sub

    Private Sub Socket_PacketReceived(size As Integer, header As Integer, ByRef data() As Byte) Handles Socket.PacketReceived
        If DebugTxt = True Then
            Console.WriteLine("Packet Recebido : [Tamanho: " & size & "| Packet: " & CType(header, ClientPackets).ToString() & "]")
        End If

        Dim tmpData = data
        Dim BreakPointDummy As Integer = 0
    End Sub

#End Region

End Module