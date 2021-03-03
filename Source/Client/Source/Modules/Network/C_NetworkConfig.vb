Imports ASFW.Network

Friend Module C_NetworkConfig
    Friend WithEvents Socket As Client

    Friend Sub InitNetwork()
        If Not Socket Is Nothing Then Return
        Socket = New Client(ServerPackets.COUNT, 4096)
        PacketRouter()
    End Sub

    Friend Sub Connect()
        Socket.Connect(Settings.Ip, Settings.Port)
    End Sub

    Friend Sub DestroyNetwork()
        ' Chamar uma desconexão não é necessário quando usa o destroy network, já que
        ' o Dispose já chama e ainda limpa a memória internamente.
        Socket.Dispose()
    End Sub

#Region " Events "

    Private Sub Socket_ConnectionSuccess() Handles Socket.ConnectionSuccess

    End Sub

    Private Sub Socket_ConnectionFailed() Handles Socket.ConnectionFailed

    End Sub

    Private Sub Socket_ConnectionLost() Handles Socket.ConnectionLost
        MsgBox("A conexão foi terminada!")
        DestroyNetwork()
        DestroyGame()
    End Sub

    Private Sub Socket_CrashReport(err As String) Handles Socket.CrashReport
        MsgBox("Houve um erro de rede -> Relatório: " & err)
        DestroyNetwork()
        DestroyGame()
    End Sub

#If DEBUG Then

    Private Sub Socket_TrafficReceived(size As Integer, ByRef data() As Byte) Handles Socket.TrafficReceived
        Console.WriteLine("Tráfego Recebido : [Tamanho: " & size & "]")

        Dim tmpData = data
#Disable Warning BC42024 ' Variável local não usada
        Dim breakPointDummy As Integer
#Enable Warning BC42024 ' Variável local não usada
        'Colocar quebra de linha no BreakPointDummy para olhar o que está contido nos dados do logger do VStudio em tempo de execução.
    End Sub

    Private Sub Socket_PacketReceived(size As Integer, header As Integer, ByRef data() As Byte) Handles Socket.PacketReceived
        Console.WriteLine("Pacote Recebido : [Tamanho: " & size & "| Packet: " & CType(header, ServerPackets).ToString() & "]")
        Dim tmpData = data
#Disable Warning BC42024 ' Variável local não usada
        Dim breakPointDummy As Integer
#Enable Warning BC42024 ' Variável local não usada
        'Colocar quebra de linha no BreakPointDummy para olhar o que está contido nos dados do logger do VStudio em tempo de execução.
    End Sub

#End If

#End Region

End Module