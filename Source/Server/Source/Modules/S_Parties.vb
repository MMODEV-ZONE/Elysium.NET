Imports ASFW

Module S_Parties

#Region "Types and Globals"

    Friend Party(MAX_PARTIES) As PartyRec

    Friend Structure PartyRec
        Dim Leader As Integer
        Dim Member() As Integer
        Dim MemberCount As Integer
    End Structure

#End Region

#Region "Outgoing Packets"

    Sub SendDataToParty(partyNum As Integer, ByRef data() As Byte)
        Dim i As Integer

        For i = 1 To Party(partyNum).MemberCount
            If Party(partyNum).Member(i) > 0 Then
                Socket.SendDataTo(Party(partyNum).Member(i), data, data.Length)
            End If
        Next
    End Sub

    Sub SendPartyInvite(index As Integer, target As Integer)
        Dim buffer As New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SPartyInvite)
#If DEBUG Then
        Addlog("Enviada SMSG: SPartyInvite", PACKET_LOG)
        Console.WriteLine("Enviada SMSG: SPartyInvite")
#End If
        buffer.WriteString((Trim$(Player(target).Character(TempPlayer(target).CurChar).Name)))

        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendPartyUpdate(partyNum As Integer)
        Dim buffer As New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SPartyUpdate)
#If DEBUG Then
        Addlog("Enviada SMSG: SPartyUpdate", PACKET_LOG)
        Console.WriteLine("Enviada SMSG: SPartyUpdate")
#End If
        buffer.WriteInt32(1)
        buffer.WriteInt32(Party(partyNum).Leader)
        For i = 1 To MAX_PARTY_MEMBERS
            buffer.WriteInt32(Party(partyNum).Member(i))
        Next
        buffer.WriteInt32(Party(partyNum).MemberCount)

        SendDataToParty(partyNum, buffer.ToArray())
        buffer.Dispose()
    End Sub

    Sub SendPartyUpdateTo(index As Integer)
        Dim buffer As New ByteStream(4), i As Integer, partyNum As Integer

        buffer.WriteInt32(ServerPackets.SPartyUpdate)
#If DEBUG Then
        Addlog("Enviada SMSG: SPartyUpdate To Players", PACKET_LOG)
        Console.WriteLine("Enviada SMSG: SPartyUpdate To Players")
#End If
        ' ver se estamos em uma equipe
        partyNum = TempPlayer(index).InParty
        If partyNum > 0 Then
            ' enviar dados da equipe
            buffer.WriteInt32(1)
            buffer.WriteInt32(Party(partyNum).Leader)
            For i = 1 To MAX_PARTY_MEMBERS
                buffer.WriteInt32(Party(partyNum).Member(i))
            Next
            buffer.WriteInt32(Party(partyNum).MemberCount)
        Else
            ' enviar comando de limpar
            buffer.WriteInt32(0)
        End If

        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendPartyVitals(partyNum As Integer, index As Integer)
        Dim buffer As ByteStream, i As Integer

        buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SPartyVitals)
        buffer.WriteInt32(index)
#If DEBUG Then
        Addlog("Enviada SMSG: SPartyVitals", PACKET_LOG)
        Console.WriteLine("Enviada SMSG: SPartyVitals")
#End If
        For i = 1 To VitalType.Count - 1
            buffer.WriteInt32(GetPlayerMaxVital(index, i))
            buffer.WriteInt32(Player(index).Character(TempPlayer(index).CurChar).Vital(i))
        Next

        SendDataToParty(partyNum, buffer.ToArray)
        buffer.Dispose()
    End Sub

#End Region

#Region "Incoming Packets"

    Friend Sub Packet_PartyRquest(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        Addlog("Recebida CMSG: CRequestParty", PACKET_LOG)
        Console.WriteLine("Recebida CMSG: CRequestParty")
#End If
        ' Prevenir fazer euqipe com si próprio
        If TempPlayer(index).Target = index Then Exit Sub
        ' ter certeza que é um alvo válido
        If TempPlayer(index).TargetType <> TargetType.Player Then Exit Sub

        ' ter certeza que estão conectado e no mesmo mapa
        If Not Socket.IsConnected(TempPlayer(index).Target) OrElse Not IsPlaying(TempPlayer(index).Target) Then Exit Sub
        If GetPlayerMap(TempPlayer(index).Target) <> GetPlayerMap(index) Then Exit Sub

        ' iniciar o pedido
        Party_Invite(index, TempPlayer(index).Target)
    End Sub

    Friend Sub Packet_AcceptParty(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        Addlog("Recebida CMSG: CAcceptParty", PACKET_LOG)
        Console.WriteLine("Recebida CMSG: CAcceptParty")
#End If
        Party_InviteAccept(TempPlayer(index).PartyInvite, index)
    End Sub

    Friend Sub Packet_DeclineParty(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        Addlog("Recebida CMSG: CDeclineParty", PACKET_LOG)
        Console.WriteLine("Recebida CMSG: CDeclineParty")
#End If
        Party_InviteDecline(TempPlayer(index).PartyInvite, index)
    End Sub

    Friend Sub Packet_LeaveParty(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        Addlog("Recebida CMSG: CLeaveParty", PACKET_LOG)
        Console.WriteLine("Recebida CMSG: CLeaveParty")
#End If
        Party_PlayerLeave(index)
    End Sub

    Friend Sub Packet_PartyChatMsg(index As Integer, ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        Addlog("Recebida CMSG: CPartyChatMsg", PACKET_LOG)
        Console.WriteLine("Recebida CMSG: CPartyChatMsg")
#End If

        PartyMsg(index, buffer.ReadString)

        buffer.Dispose()
    End Sub

#End Region

    Sub ClearParties()
        Dim i As Integer

        For i = 1 To MAX_PARTIES
            ClearParty(i)
        Next

    End Sub

    Sub ClearParty(partyNum As Integer)
        Party(partyNum) = Nothing
        Party(partyNum).Leader = 0
        Party(partyNum).MemberCount = 0
        ReDim Party(partyNum).Member(MAX_PARTY_MEMBERS)
    End Sub

    Friend Sub PartyMsg(partyNum As Integer, msg As String)
        Dim i As Integer

        ' enviar mensagem para todas as pessoas
        For i = 1 To MAX_PARTY_MEMBERS
            ' existe?
            If Party(partyNum).Member(i) > 0 Then
                ' ter certeza que estao logados
                If Socket.IsConnected(Party(partyNum).Member(i)) AndAlso IsPlaying(Party(partyNum).Member(i)) Then
                    PlayerMsg(Party(partyNum).Member(i), msg, ColorType.BrightBlue)
                End If
            End If
        Next
    End Sub

    Private Sub Party_RemoveFromParty(index As Integer, partyNum As Integer)
        For i = 1 To MAX_PARTY_MEMBERS
            If Party(partyNum).Member(i) = index Then
                Party(partyNum).Member(i) = 0
                TempPlayer(index).InParty = 0
                TempPlayer(index).PartyInvite = 0
                Exit For
            End If
        Next
        Party_CountMembers(partyNum)
        SendPartyUpdate(partyNum)
        SendPartyUpdateTo(index)
    End Sub

    Friend Sub Party_PlayerLeave(index As Integer)
        Dim partyNum As Integer, i As Integer

        partyNum = TempPlayer(index).InParty

        If partyNum > 0 Then
            ' descobrir quantos membros temos
            Party_CountMembers(partyNum)
            ' ter certeza que tem mais que duas pesosoas
            If Party(partyNum).MemberCount > 2 Then

                ' ver se é líder
                If Party(partyNum).Leader = index Then
                    ' colocar a próxima pessoa como lider
                    For i = 1 To MAX_PARTY_MEMBERS
                        If Party(partyNum).Member(i) > 0 AndAlso Party(partyNum).Member(i) <> index Then
                            Party(partyNum).Leader = Party(partyNum).Member(i)
                            PartyMsg(partyNum, String.Format("{0} agora é o líder da equipe.", GetPlayerName(i)))
                            Exit For
                        End If
                    Next
                    ' sair da equipe
                    PartyMsg(partyNum, String.Format("{0} saiu da equipe.", GetPlayerName(index)))
                    Party_RemoveFromParty(index, partyNum)
                Else
                    ' não é o líder, apenas sair
                    PartyMsg(partyNum, String.Format("{0} saiu da euqipe.", GetPlayerName(index)))
                    Party_RemoveFromParty(index, partyNum)
                End If
            Else
                ' descobrir quantos membros temos
                Party_CountMembers(partyNum)
                ' apenas 2 pessoas, desfazer equipe
                PartyMsg(partyNum, "A equipe foi desfeita.")

                ' limpar a equipe de todo mundo
                For i = 1 To MAX_PARTY_MEMBERS
                    index = Party(partyNum).Member(i)
                    ' jogador existe?
                    If index > 0 Then
                        Party_RemoveFromParty(index, partyNum)
                    End If
                Next
                ' limpar a equipe em si
                ClearParty(partyNum)
            End If
        End If
    End Sub

    Friend Sub Party_Invite(index As Integer, target As Integer)
        Dim partyNum As Integer, i As Integer

        ' ver se pessoa é alvo válido
        If Not Socket.IsConnected(target) OrElse Not IsPlaying(target) Then Exit Sub

        ' ter certeza que não está ocupado
        If TempPlayer(target).PartyInvite > 0 OrElse TempPlayer(target).TradeRequest > 0 Then
            ' já tem um pedido para troca/equipe
            PlayerMsg(index, "Esse jogador está ocupado.", ColorType.BrightRed)
            ' sair mais cedo
            Exit Sub
        End If
        ' Ter certeza que não está já em uma equipe
        If TempPlayer(target).InParty > 0 Then
            ' Ele já está em uma
            PlayerMsg(index, "Esse jogador já está em uma equipe.", ColorType.BrightRed)
            'sair mais cedo
            Exit Sub
        End If

        ' ver se estamos em uma equipe
        If TempPlayer(index).InParty > 0 Then
            partyNum = TempPlayer(index).InParty
            ' ter certeza que somos o lider
            If Party(partyNum).Leader = index Then
                ' tem espaço livre?
                For i = 1 To MAX_PARTY_MEMBERS
                    If Party(partyNum).Member(i) = 0 Then
                        ' enviar o convite
                        SendPartyInvite(target, index)
                        ' setar o alvo do convite
                        TempPlayer(target).PartyInvite = index
                        ' deixar que saibam
                        PlayerMsg(index, "Convite enviado.", ColorType.Yellow)
                        Exit Sub
                    End If
                Next
                ' sem espaço
                PlayerMsg(index, "Party is full.", ColorType.BrightRed)
                Exit Sub
            Else
                ' não é o líder
                PlayerMsg(index, "Você não é o líder da equipe.", ColorType.BrightRed)
                Exit Sub
            End If
        Else
            ' não está em uma equipe - não importa!
            SendPartyInvite(target, index)
            ' setar o alvo do convite
            TempPlayer(target).PartyInvite = index
            ' deixar saber
            PlayerMsg(index, "Convite enviado.", ColorType.Yellow)
            Exit Sub
        End If
    End Sub

    Friend Sub Party_InviteAccept(index As Integer, target As Integer)
        Dim partyNum As Integer, i As Integer

        ' ver se já está em uma equipe
        If TempPlayer(index).InParty > 0 Then
            ' pegar o número da equipe
            partyNum = TempPlayer(index).InParty
            ' tem espaço vazio?
            For i = 1 To MAX_PARTY_MEMBERS
                If Party(partyNum).Member(i) = 0 Then
                    'adicionar equipe
                    Party(partyNum).Member(i) = target
                    ' recontar equipe
                    Party_CountMembers(partyNum)
                    ' atualizar para todos - inclusive o novo jogador
                    SendPartyUpdate(partyNum)
                    SendPartyVitals(partyNum, target)
                    ' deixar todo saber que alguem entrou
                    PartyMsg(partyNum, String.Format("{0} entrou na equipe.", GetPlayerName(target)))
                    ' adicionar
                    TempPlayer(target).InParty = partyNum
                    Exit Sub
                End If
            Next
            ' não há espaço vazios - deixar saber
            PlayerMsg(index, "A equipe está cheia.", ColorType.BrightRed)
            PlayerMsg(target, "A equipe está cheia.", ColorType.BrightRed)
            Exit Sub
        Else
            ' não está em uma equipe. criar uma nova com uma pessoa.
            For i = 1 To MAX_PARTIES
                ' encontrar uma equipe vazia
                If Not Party(i).Leader > 0 Then
                    partyNum = i
                    Exit For
                End If
            Next
            ' criar a equipe
            Party(partyNum).MemberCount = 2
            Party(partyNum).Leader = index
            Party(partyNum).Member(1) = index
            Party(partyNum).Member(2) = target
            SendPartyUpdate(partyNum)
            SendPartyVitals(partyNum, index)
            SendPartyVitals(partyNum, target)

            ' deixem saber que a equipe foi criada
            PartyMsg(partyNum, "Equipe criada.")
            PartyMsg(partyNum, String.Format("{0} entrou na equipe.", GetPlayerName(index)))

            ' Limpar convites
            TempPlayer(target).PartyInvite = 0

            ' adiciona-los a equipe
            TempPlayer(index).InParty = partyNum
            TempPlayer(target).InParty = partyNum
            Exit Sub
        End If
    End Sub

    Friend Sub Party_InviteDecline(index As Integer, target As Integer)
        PlayerMsg(index, String.Format("{0} não quis entrar na sua equipe.", GetPlayerName(target)), ColorType.BrightRed)
        PlayerMsg(target, "Você não quis entrar na equipe.", ColorType.Yellow)
        ' limpar o convite
        TempPlayer(target).PartyInvite = 0
    End Sub

    Friend Sub Party_CountMembers(partyNum As Integer)
        Dim i As Integer, highindex As Integer, x As Integer

        ' encontrar o índice mais alto
        For i = MAX_PARTY_MEMBERS To 1 Step -1
            If Party(partyNum).Member(i) > 0 Then
                highindex = i
                Exit For
            End If
        Next
        ' contar os membros
        For i = 1 To MAX_PARTY_MEMBERS
            ' temos um membro em branco
            If Party(partyNum).Member(i) = 0 Then
                ' é menor que o maior índice?
                If i < highindex Then
                    ' mover todo mundo para baixo
                    For x = i To MAX_PARTY_MEMBERS - 1
                        Party(partyNum).Member(x) = Party(partyNum).Member(x + 1)
                        Party(partyNum).Member(x + 1) = 0
                    Next
                Else
                    ' não é mais baixo - highindex is count
                    Party(partyNum).MemberCount = highindex
                    Exit Sub
                End If
            End If
            ' ver se atingimos o máximo
            If i = MAX_PARTY_MEMBERS Then
                If highindex = i Then
                    Party(partyNum).MemberCount = MAX_PARTY_MEMBERS
                    Exit Sub
                End If
            End If
        Next
        ' se estamos aqui significa que temos que recontar
        Party_CountMembers(partyNum)
    End Sub

    Friend Sub Party_ShareExp(partyNum As Integer, exp As Integer, index As Integer, mapNum As Integer)
        Dim expShare As Integer, leftOver As Integer, i As Integer, tmpindex As Integer, loseMemberCount As Byte

        ' ver se vale a pena compartilhar
        If Not exp >= Party(partyNum).MemberCount Then
            ' sem equipe - manter tudo para si
            GivePlayerExp(index, exp)
            Exit Sub
        End If

        ' ver membros em outros mapas
        For i = 1 To MAX_PARTY_MEMBERS
            tmpindex = Party(partyNum).Member(i)
            If tmpindex > 0 Then
                If Socket.IsConnected(tmpindex) AndAlso IsPlaying(tmpindex) Then
                    If GetPlayerMap(tmpindex) <> mapNum Then
                        loseMemberCount = loseMemberCount + 1
                    End If
                End If
            End If
        Next

        ' descobrir a fatia igual
        expShare = exp \ (Party(partyNum).MemberCount - loseMemberCount)
        leftOver = exp Mod (Party(partyNum).MemberCount - loseMemberCount)

        ' passar por todos e distribuir a experiencia
        For i = 1 To MAX_PARTY_MEMBERS
            tmpindex = Party(partyNum).Member(i)
            ' membro existente?
            If tmpindex > 0 Then
                ' jogando?
                If Socket.IsConnected(tmpindex) AndAlso IsPlaying(tmpindex) Then
                    If GetPlayerMap(tmpindex) = mapNum Then
                        ' dar o pedaço da exp
                        GivePlayerExp(tmpindex, expShare)
                    End If
                End If
            End If
        Next

        '  dar o remanescente para um membro aleatório
        If Not leftOver = 0 Then
            tmpindex = Party(partyNum).Member(Random(1, Party(partyNum).MemberCount))
            ' dar a exp
            GivePlayerExp(tmpindex, leftOver)
        End If

    End Sub

    Sub PartyWarp(index As Integer, mapNum As Integer, x As Integer, y As Integer)
        Dim i As Integer

        If TempPlayer(index).InParty Then
            If Party(TempPlayer(index).InParty).Leader Then
                For i = 1 To Party(TempPlayer(index).InParty).MemberCount
                    PlayerWarp(Party(TempPlayer(index).InParty).Member(i), mapNum, x, y)
                Next
            End If
        End If

    End Sub

    Friend Function IsPlayerInParty(index As Integer) As Boolean
        If index < 0 OrElse index > MAX_PLAYERS OrElse Not TempPlayer(index).InGame Then Exit Function
        If TempPlayer(index).InParty > 0 Then IsPlayerInParty = True
    End Function

    Friend Function GetPlayerParty(index As Integer) As Integer
        If index < 0 OrElse index > MAX_PLAYERS OrElse Not TempPlayer(index).InGame Then Exit Function
        GetPlayerParty = TempPlayer(index).InParty
    End Function

End Module