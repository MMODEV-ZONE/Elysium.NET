Imports System.IO
Imports ASFW
Imports ASFW.IO

Module S_NetworkReceive

    Friend Sub PacketRouter()
        Socket.PacketId(ClientPackets.CCheckPing) = AddressOf Packet_Ping
        Socket.PacketId(ClientPackets.CNewAccount) = AddressOf Packet_NewAccount
        Socket.PacketId(ClientPackets.CDelAccount) = AddressOf Packet_DeleteAccount
        Socket.PacketId(ClientPackets.CLogin) = AddressOf Packet_Login
        Socket.PacketId(ClientPackets.CAddChar) = AddressOf Packet_AddChar
        Socket.PacketId(ClientPackets.CUseChar) = AddressOf Packet_UseChar
        Socket.PacketId(ClientPackets.CDelChar) = AddressOf Packet_DeleteChar
        Socket.PacketId(ClientPackets.CSayMsg) = AddressOf Packet_SayMessage
        Socket.PacketId(ClientPackets.CBroadcastMsg) = AddressOf Packet_BroadCastMsg
        Socket.PacketId(ClientPackets.CPlayerMsg) = AddressOf Packet_PlayerMsg
        Socket.PacketId(ClientPackets.CPlayerMove) = AddressOf Packet_PlayerMove
        Socket.PacketId(ClientPackets.CPlayerDir) = AddressOf Packet_PlayerDirection
        Socket.PacketId(ClientPackets.CUseItem) = AddressOf Packet_UseItem
        Socket.PacketId(ClientPackets.CAttack) = AddressOf Packet_Attack
        Socket.PacketId(ClientPackets.CPlayerInfoRequest) = AddressOf Packet_PlayerInfo
        Socket.PacketId(ClientPackets.CWarpMeTo) = AddressOf Packet_WarpMeTo
        Socket.PacketId(ClientPackets.CWarpToMe) = AddressOf Packet_WarpToMe
        Socket.PacketId(ClientPackets.CWarpTo) = AddressOf Packet_WarpTo
        Socket.PacketId(ClientPackets.CSetSprite) = AddressOf Packet_SetSprite
        Socket.PacketId(ClientPackets.CGetStats) = AddressOf Packet_GetStats
        Socket.PacketId(ClientPackets.CRequestNewMap) = AddressOf Packet_RequestNewMap
        Socket.PacketId(ClientPackets.CSaveMap) = AddressOf Packet_MapData
        Socket.PacketId(ClientPackets.CNeedMap) = AddressOf Packet_NeedMap
        Socket.PacketId(ClientPackets.CMapGetItem) = AddressOf Packet_GetItem
        Socket.PacketId(ClientPackets.CMapDropItem) = AddressOf Packet_DropItem
        Socket.PacketId(ClientPackets.CMapRespawn) = AddressOf Packet_RespawnMap
        Socket.PacketId(ClientPackets.CMapReport) = AddressOf Packet_MapReport 'Mapreport
        Socket.PacketId(ClientPackets.CKickPlayer) = AddressOf Packet_KickPlayer
        Socket.PacketId(ClientPackets.CBanList) = AddressOf Packet_Banlist
        Socket.PacketId(ClientPackets.CBanDestroy) = AddressOf Packet_DestroyBans
        Socket.PacketId(ClientPackets.CBanPlayer) = AddressOf Packet_BanPlayer

        Socket.PacketId(ClientPackets.CRequestEditMap) = AddressOf Packet_EditMapRequest

        Socket.PacketId(ClientPackets.CSetAccess) = AddressOf Packet_SetAccess
        Socket.PacketId(ClientPackets.CWhosOnline) = AddressOf Packet_WhosOnline
        Socket.PacketId(ClientPackets.CSetMotd) = AddressOf Packet_SetMotd
        Socket.PacketId(ClientPackets.CSearch) = AddressOf Packet_PlayerSearch
        Socket.PacketId(ClientPackets.CSkills) = AddressOf Packet_Skills
        Socket.PacketId(ClientPackets.CCast) = AddressOf Packet_Cast
        Socket.PacketId(ClientPackets.CQuit) = AddressOf Packet_QuitGame
        Socket.PacketId(ClientPackets.CSwapInvSlots) = AddressOf Packet_SwapInvSlots

        Socket.PacketId(ClientPackets.CCheckPing) = AddressOf Packet_CheckPing
        Socket.PacketId(ClientPackets.CUnequip) = AddressOf Packet_Unequip
        Socket.PacketId(ClientPackets.CRequestPlayerData) = AddressOf Packet_RequestPlayerData
        Socket.PacketId(ClientPackets.CRequestItems) = AddressOf Packet_RequestItems
        Socket.PacketId(ClientPackets.CRequestNPCS) = AddressOf Packet_RequestNpcs
        Socket.PacketId(ClientPackets.CRequestResources) = AddressOf Packet_RequestResources
        Socket.PacketId(ClientPackets.CSpawnItem) = AddressOf Packet_SpawnItem
        Socket.PacketId(ClientPackets.CTrainStat) = AddressOf Packet_TrainStat

        Socket.PacketId(ClientPackets.CRequestAnimations) = AddressOf Packet_RequestAnimations
        Socket.PacketId(ClientPackets.CRequestSkills) = AddressOf Packet_RequestSkills
        Socket.PacketId(ClientPackets.CRequestShops) = AddressOf Packet_RequestShops
        Socket.PacketId(ClientPackets.CRequestLevelUp) = AddressOf Packet_RequestLevelUp
        Socket.PacketId(ClientPackets.CForgetSkill) = AddressOf Packet_ForgetSkill
        Socket.PacketId(ClientPackets.CCloseShop) = AddressOf Packet_CloseShop
        Socket.PacketId(ClientPackets.CBuyItem) = AddressOf Packet_BuyItem
        Socket.PacketId(ClientPackets.CSellItem) = AddressOf Packet_SellItem
        Socket.PacketId(ClientPackets.CChangeBankSlots) = AddressOf Packet_ChangeBankSlots
        Socket.PacketId(ClientPackets.CDepositItem) = AddressOf Packet_DepositItem
        Socket.PacketId(ClientPackets.CWithdrawItem) = AddressOf Packet_WithdrawItem
        Socket.PacketId(ClientPackets.CCloseBank) = AddressOf Packet_CloseBank
        Socket.PacketId(ClientPackets.CAdminWarp) = AddressOf Packet_AdminWarp

        Socket.PacketId(ClientPackets.CTradeInvite) = AddressOf Packet_TradeInvite
        Socket.PacketId(ClientPackets.CTradeInviteAccept) = AddressOf Packet_TradeInviteAccept
        Socket.PacketId(ClientPackets.CAcceptTrade) = AddressOf Packet_AcceptTrade
        Socket.PacketId(ClientPackets.CDeclineTrade) = AddressOf Packet_DeclineTrade
        Socket.PacketId(ClientPackets.CTradeItem) = AddressOf Packet_TradeItem
        Socket.PacketId(ClientPackets.CUntradeItem) = AddressOf Packet_UntradeItem

        Socket.PacketId(ClientPackets.CAdmin) = AddressOf Packet_Admin

        'quests
        Socket.PacketId(ClientPackets.CRequestQuests) = AddressOf Packet_RequestQuests
        Socket.PacketId(ClientPackets.CQuestLogUpdate) = AddressOf Packet_QuestLogUpdate
        Socket.PacketId(ClientPackets.CPlayerHandleQuest) = AddressOf Packet_PlayerHandleQuest
        Socket.PacketId(ClientPackets.CQuestReset) = AddressOf Packet_QuestReset

        'Casas
        Socket.PacketId(ClientPackets.CBuyHouse) = AddressOf Packet_BuyHouse
        Socket.PacketId(ClientPackets.CVisit) = AddressOf Packet_InviteToHouse
        Socket.PacketId(ClientPackets.CAcceptVisit) = AddressOf Packet_AcceptInvite
        Socket.PacketId(ClientPackets.CPlaceFurniture) = AddressOf Packet_PlaceFurniture

        Socket.PacketId(ClientPackets.CSellHouse) = AddressOf Packet_SellHouse

        'hotbar
        Socket.PacketId(ClientPackets.CSetHotbarSlot) = AddressOf Packet_SetHotBarSlot
        Socket.PacketId(ClientPackets.CDeleteHotbarSlot) = AddressOf Packet_DeleteHotBarSlot
        Socket.PacketId(ClientPackets.CUseHotbarSlot) = AddressOf Packet_UseHotBarSlot

        'Eventos
        Socket.PacketId(ClientPackets.CEventChatReply) = AddressOf Packet_EventChatReply
        Socket.PacketId(ClientPackets.CEvent) = AddressOf Packet_Event
        Socket.PacketId(ClientPackets.CRequestSwitchesAndVariables) = AddressOf Packet_RequestSwitchesAndVariables
        Socket.PacketId(ClientPackets.CSwitchesAndVariables) = AddressOf Packet_SwitchesAndVariables

        'Projeteis

        Socket.PacketId(ClientPackets.CRequestProjectiles) = AddressOf HandleRequestProjectiles
        Socket.PacketId(ClientPackets.CClearProjectile) = AddressOf HandleClearProjectile

        'Artesanato
        Socket.PacketId(ClientPackets.CRequestRecipes) = AddressOf Packet_RequestRecipes

        Socket.PacketId(ClientPackets.CCloseCraft) = AddressOf Packet_CloseCraft
        Socket.PacketId(ClientPackets.CStartCraft) = AddressOf Packet_StartCraft

        Socket.PacketId(ClientPackets.CRequestClasses) = AddressOf Packet_RequestClasses

        'Emotes
        Socket.PacketId(ClientPackets.CEmote) = AddressOf Packet_Emote

        'Times
        Socket.PacketId(ClientPackets.CRequestParty) = AddressOf Packet_PartyRquest
        Socket.PacketId(ClientPackets.CAcceptParty) = AddressOf Packet_AcceptParty
        Socket.PacketId(ClientPackets.CDeclineParty) = AddressOf Packet_DeclineParty
        Socket.PacketId(ClientPackets.CLeaveParty) = AddressOf Packet_LeaveParty
        Socket.PacketId(ClientPackets.CPartyChatMsg) = AddressOf Packet_PartyChatMsg

        'pets
        Socket.PacketId(ClientPackets.CRequestPets) = AddressOf Packet_RequestPets
        Socket.PacketId(ClientPackets.CSummonPet) = AddressOf Packet_SummonPet
        Socket.PacketId(ClientPackets.CPetMove) = AddressOf Packet_PetMove
        Socket.PacketId(ClientPackets.CSetBehaviour) = AddressOf Packet_SetPetBehaviour
        Socket.PacketId(ClientPackets.CReleasePet) = AddressOf Packet_ReleasePet
        Socket.PacketId(ClientPackets.CPetSkill) = AddressOf Packet_PetSkill
        Socket.PacketId(ClientPackets.CPetUseStatPoint) = AddressOf Packet_UsePetStatPoint

        'Edtiores
        Socket.PacketId(ClientPackets.CRequestEditItem) = AddressOf Packet_EditItem
        Socket.PacketId(ClientPackets.CSaveItem) = AddressOf Packet_SaveItem
        Socket.PacketId(ClientPackets.CRequestEditNpc) = AddressOf Packet_EditNpc
        Socket.PacketId(ClientPackets.CSaveNpc) = AddressOf Packet_SaveNPC
        Socket.PacketId(ClientPackets.CRequestEditShop) = AddressOf Packet_EditShop
        Socket.PacketId(ClientPackets.CSaveShop) = AddressOf Packet_SaveShop
        Socket.PacketId(ClientPackets.CRequestEditSkill) = AddressOf Packet_EditSkill
        Socket.PacketId(ClientPackets.CSaveSkill) = AddressOf Packet_SaveSkill
        Socket.PacketId(ClientPackets.CRequestEditResource) = AddressOf Packet_EditResource
        Socket.PacketId(ClientPackets.CSaveResource) = AddressOf Packet_SaveResource
        Socket.PacketId(ClientPackets.CRequestEditAnimation) = AddressOf Packet_EditAnimation
        Socket.PacketId(ClientPackets.CSaveAnimation) = AddressOf Packet_SaveAnimation
        Socket.PacketId(ClientPackets.CRequestEditQuest) = AddressOf Packet_RequestEditQuest
        Socket.PacketId(ClientPackets.CSaveQuest) = AddressOf Packet_SaveQuest
        Socket.PacketId(ClientPackets.CRequestEditHouse) = AddressOf Packet_RequestEditHouse
        Socket.PacketId(ClientPackets.CSaveHouses) = AddressOf Packet_SaveHouses
        Socket.PacketId(ClientPackets.CRequestEditProjectiles) = AddressOf HandleRequestEditProjectiles
        Socket.PacketId(ClientPackets.CSaveProjectile) = AddressOf HandleSaveProjectile
        Socket.PacketId(ClientPackets.CRequestEditRecipes) = AddressOf Packet_RequestEditRecipes
        Socket.PacketId(ClientPackets.CSaveRecipe) = AddressOf Packet_SaveRecipe
        Socket.PacketId(ClientPackets.CRequestEditClasses) = AddressOf Packet_RequestEditClasses
        Socket.PacketId(ClientPackets.CSaveClasses) = AddressOf Packet_SaveClasses
        Socket.PacketId(ClientPackets.CRequestAutoMap) = AddressOf Packet_RequestAutoMap
        Socket.PacketId(ClientPackets.CSaveAutoMap) = AddressOf Packet_SaveAutoMap

        'Pets
        Socket.PacketId(ClientPackets.CRequestEditPet) = AddressOf Packet_RequestEditPet
        Socket.PacketId(ClientPackets.CSavePet) = AddressOf Packet_SavePet

    End Sub

    Private Sub Packet_Ping(index As Integer, ByRef data() As Byte)
        TempPlayer(index).DataPackets = TempPlayer(index).DataPackets + 1
    End Sub

    Private Sub Packet_NewAccount(index As Integer, ByRef data() As Byte)
        Dim username As String, password As String
        Dim i As Integer, n As Integer, IP As String
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CNewAccount")
#End If
        If Not IsPlaying(index) AndAlso Not IsLoggedIn(index) Then
            'Pegar os dados
            username = EKeyPair.DecryptString(buffer.ReadString)
            password = EKeyPair.DecryptString(buffer.ReadString)
            ' Prevenir hacking
            If Len(username.Trim) < 3 OrElse Len(password.Trim) < 3 Then
                AlertMsg(index, "Seu nome de usuário e senha devem possuir pelo menos três caracteres.")
                Exit Sub
            End If

            ' Prevenir hacking
            For i = 1 To Len(username)
                n = AscW(Mid$(username, i, 1))

                If Not IsNameLegal(n) Then
                    AlertMsg(index, "Nome de usuário inválido: apenas letras, números, espaços e _ são aceitos.")
                    Exit Sub
                End If
            Next

            'IP banido?

            ' Cortar a última parte do IP
            IP = Socket.ClientIp(index)

            For i = Len(IP) To 1 Step -1

                If Mid$(IP, i, 1) = "." Then
                    Exit For
                End If

            Next

            IP = Mid$(IP, 1, i)
            If IsBanned(IP) Then
                AlertMsg(index, "Você está banido!", True)
            End If

            ' Ver se a conta já não existe
            If Not AccountExist(username) Then
                AddAccount(index, username, password)

                Console.WriteLine("Conta " & username & " foi criada.")
                Addlog("Conta " & username & " foi criada.", PLAYER_LOG)

                ' Carregar o jogador
                LoadPlayer(index, username)

                ' Checar se o dado do personagem já foi criado 
                If Len(Trim$(Player(index).Character(TempPlayer(index).CurChar).Name)) > 0 Then
                    ' Personagem criado!
                    HandleUseChar(index)
                Else
                    ' Mandar as infos de novo personagem
                    If Not IsPlaying(index) Then
                        SendNewCharClasses(index)
                    End If
                End If

                ' Mostrar que o novo jogador está online 
                Addlog(GetPlayerLogin(index) & " logou a partir do IP " & Socket.ClientIp(index) & ".", PLAYER_LOG)
                Console.WriteLine(GetPlayerLogin(index) & " logou a partir do IP " & Socket.ClientIp(index) & ".")
            Else
                AlertMsg(index, "Desculpe, essa conta já foi pega!")
            End If

            buffer.Dispose()
        End If
    End Sub

    Private Sub Packet_DeleteAccount(index As Integer, ByRef data() As Byte)
        Dim Name As String
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CDelChar")
#End If
        ' Get the data
        Name = buffer.ReadString

        If GetPlayerLogin(index) = Trim$(Name) Then
            PlayerMsg(index, "Você não pode excluir sua própria conta enquanto estiver online!", ColorType.BrightRed)
            Exit Sub
        End If

        For i = 1 To GetPlayersOnline()
            If IsPlaying(i) Then
                If Trim$(Player(i).Login) = Trim$(Name) Then
                    AlertMsg(i, "Sua conta foi removida por um administrador!", True)
                    ClearPlayer(i)
                End If
            End If
        Next
    End Sub

    Private Sub Packet_Login(index As Integer, ByRef data() As Byte)
        Dim Name As String, IP As String
        Dim Password As String, i As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CLogin")
#End If
        If Not IsPlaying(index) Then
            If Not IsLoggedIn(index) Then

                'Checar se está banido
                ' Cortar a última parte do IP
                IP = Socket.ClientIp(index)

                For i = Len(IP) To 1 Step -1

                    If Mid$(IP, i, 1) = "." Then
                        Exit For
                    End If

                Next

                IP = Mid$(IP, 1, i)
                If IsBanned(IP) Then
                    AlertMsg(index, "Você está banido!", True)
                End If

                ' Pegar os dados
                Name = EKeyPair.DecryptString(buffer.ReadString())
                Password = EKeyPair.DecryptString(buffer.ReadString())

                ' Checar versões
                If EKeyPair.DecryptString(buffer.ReadString()) <> Application.ProductVersion Then
                    AlertMsg(index, "Versão desatualizada, visite " & Settings.Website, True)
                    Exit Sub
                End If

                If Len(Trim$(Name)) < 3 OrElse Len(Trim$(Password)) < 3 Then
                    AlertMsg(index, "Seu nome e senha devem possuir ao menos três caracteres de tamanho.")
                    Exit Sub
                End If

                If Not AccountExist(Name) Then
                    AlertMsg(index, "Esse nome de conta não existe.")
                    Exit Sub
                End If

                If Not PasswordOK(Name, Password) Then
                    AlertMsg(index, "Senha incorreta.")
                    Exit Sub
                End If

                If IsMultiAccounts(Name) Then
                    AlertMsg(index, "Logins múltiplos não são permitidos.")
                    Exit Sub
                End If

                ' Carregar o jogador
                LoadPlayer(index, Name)
                ClearBank(index)
                LoadBank(index, Name)

                buffer.Dispose()
                buffer = New ByteStream(4)
                buffer.WriteInt32(ServerPackets.SLoginOk)
                buffer.WriteInt32(MAX_CHARS)
#If DEBUG Then
                AddDebug("Enviada SMSG: SLoginOk")
#End If
                For i = 1 To MAX_CHARS
                    If Player(index).Character(i).Classes <= 0 Then
                        buffer.WriteString("")
                        buffer.WriteInt32(Player(index).Character(i).Sprite)
                        buffer.WriteInt32(Player(index).Character(i).Level)
                        buffer.WriteString("")
                        buffer.WriteInt32(0)
                    Else
                        buffer.WriteString(Trim$(Player(index).Character(i).Name))
                        buffer.WriteInt32(Player(index).Character(i).Sprite)
                        buffer.WriteInt32(Player(index).Character(i).Level)
                        buffer.WriteString(Trim$(Classes(Player(index).Character(i).Classes).Name))
                        buffer.WriteInt32(Player(index).Character(i).Sex)
                    End If

                Next

                Socket.SendDataTo(index, buffer.Data, buffer.Head)

                ' Mostrar que o jogador está online nos status das sockets
                Addlog(GetPlayerLogin(index) & " logou a partir do IP " & Socket.ClientIp(index) & ".", PLAYER_LOG)
                Console.WriteLine(GetPlayerLogin(index) & " logou a partir do IP " & Socket.ClientIp(index) & ".")

                '' Verificar se os dados do personagem foram criados
                'If Len(Trim$(Player(index).Character(TempPlayer(index).CurChar).Name)) > 0 Then
                '    ' Temos um personagem!
                '    'HandleUseChar(index)
                'Else
                '    ' Enviar informação
                '    If Not IsPlaying(index) Then
                '        SendNewCharClasses(index)
                '    End If
                'End If

                buffer.Dispose()
            End If
        End If
    End Sub

    Private Sub Packet_UseChar(index As Integer, ByRef data() As Byte)
        Dim slot As Byte
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CUseChar")
#End If
        If Not IsPlaying(index) Then
            If IsLoggedIn(index) Then

                slot = buffer.ReadInt32

                ' Verificar se o personagem foi criado
                If Len(Trim$(Player(index).Character(slot).Name)) > 0 Then
                    ' Temos um personagem!
                    TempPlayer(index).CurChar = slot
                    HandleUseChar(index)
                    ClearBank(index)
                    LoadBank(index, Trim$(Player(index).Login))
                Else
                    '  Enviar informações do novo personagem
                    If Not IsPlaying(index) Then
                        SendNewCharClasses(index)
                        TempPlayer(index).CurChar = slot
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub Packet_AddChar(index As Integer, ByRef data() As Byte)
        Dim Name As String, slot As Byte
        Dim Sex As Integer
        Dim Classes As Integer
        Dim Sprite As Integer
        Dim i As Integer
        Dim n As Integer

        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CAddChar")
#End If
        If Not IsPlaying(index) Then
            slot = buffer.ReadInt32
            Name = buffer.ReadString
            Sex = buffer.ReadInt32
            Classes = buffer.ReadInt32
            Sprite = buffer.ReadInt32

            ' Prevenir hacking
            If Len(Name.Trim) < 3 Then
                AlertMsg(index, "O nome do personagem deve possuir ao menos três caracteres de tamanho.")
                Exit Sub
            End If

            For i = 1 To Len(Name)
                n = AscW(Mid$(Name, i, 1))

                If Not IsNameLegal(n) Then
                    AlertMsg(index, "Nome inválido: apenas letras, números, espaços e _ são aceitos.")
                    Exit Sub
                End If

            Next

            If (Sex < modEnumerators.SexType.Male) OrElse (Sex > modEnumerators.SexType.Female) Then Exit Sub

            If Classes < 1 OrElse Classes > Max_Classes Then Exit Sub

            ' Ver se já existe personagem nesse slot
            If CharExist(index, slot) Then
                AlertMsg(index, "Personagem já existe!")
                Exit Sub
            End If

            ' Ver se o nome já está em uso
            If FindChar(Name) Then
                AlertMsg(index, "Desculpe, mas este nome já está em uso!")
                Exit Sub
            End If

            ' Tudo foi bem, adicionar o personagem
            TempPlayer(index).CurChar = slot
            AddChar(index, slot, Name, Sex, Classes, Sprite)
            Addlog("Personagem " & Name & " adicionado ã conta de " & GetPlayerLogin(index) & ".", PLAYER_LOG)

            ' Logar!!
            HandleUseChar(index)

            buffer.Dispose()
        End If

    End Sub

    Private Sub Packet_DeleteChar(index As Integer, ByRef data() As Byte)
        Dim slot As Byte
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CDelChar")
#End If

        If Not IsPlaying(index) Then
            If IsLoggedIn(index) Then

                slot = buffer.ReadInt32

                ' Verificar se os dados do personagem foi criado
                If Len(Trim$(Player(index).Character(slot).Name)) > 0 Then
                    DeleteName(Trim$(Player(index).Character(slot).Name))
                    ClearCharacter(index, slot)
                    SaveCharacter(index, slot)

                    buffer.Dispose()
                    buffer = New ByteStream(4)
                    buffer.WriteInt32(ServerPackets.SLoginOk)
                    buffer.WriteInt32(MAX_CHARS)
#If DEBUG Then
                    AddDebug("Enviada SMSG: SLoginOk")
#End If
                    For i = 1 To MAX_CHARS
                        If Player(index).Character(i).Classes <= 0 Then
                            buffer.WriteString((Trim$(Player(index).Character(i).Name)))
                            buffer.WriteInt32(Player(index).Character(i).Sprite)
                            buffer.WriteInt32(Player(index).Character(i).Level)
                            buffer.WriteString((""))
                            buffer.WriteInt32(0)
                        Else
                            buffer.WriteString((Trim$(Player(index).Character(i).Name)))
                            buffer.WriteInt32(Player(index).Character(i).Sprite)
                            buffer.WriteInt32(Player(index).Character(i).Level)
                            buffer.WriteString((Trim$(Classes(Player(index).Character(i).Classes).Name)))
                            buffer.WriteInt32(Player(index).Character(i).Sex)
                        End If

                    Next

                    Socket.SendDataTo(index, buffer.Data, buffer.Head)
                End If
            End If
        End If

    End Sub

    Private Sub Packet_SayMessage(index As Integer, ByRef data() As Byte)
        Dim msg As String
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CSayMsg")
#End If
        'msg = Buffer.ReadString
        msg = buffer.ReadString

        Addlog("Mapa #" & GetPlayerMap(index) & " - " & GetPlayerName(index) & " diz: '" & msg & "'", PLAYER_LOG)

        SayMsg_Map(GetPlayerMap(index), index, msg, ColorType.White)
        SendChatBubble(GetPlayerMap(index), index, TargetType.Player, msg, ColorType.White)

        buffer.Dispose()
    End Sub

    Private Sub Packet_BroadCastMsg(index As Integer, ByRef data() As Byte)
        Dim msg As String
        Dim s As String
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CBroadcastMsg")
#End If
        'msg = Buffer.ReadString
        msg = buffer.ReadString

        s = "[Global]" & GetPlayerName(index) & ": " & msg
        SayMsg_Global(index, msg, ColorType.White)
        Addlog(s, PLAYER_LOG)
        Console.WriteLine(s)

        buffer.Dispose()
    End Sub

    Friend Sub Packet_PlayerMsg(index As Integer, ByRef data() As Byte)
        Dim OtherPlayer As String, Msg As String, OtherPlayerindex As Integer
        Dim buffer As New ByteStream(data)

#If DEBUG Then
        AddDebug("Recebida CMSG: CPlayerMsg")
#End If
        OtherPlayer = buffer.ReadString
        'Msg = buffer.ReadString
        Msg = buffer.ReadString
        buffer.Dispose()

        OtherPlayerindex = FindPlayer(OtherPlayer)
        If OtherPlayerindex <> index Then
            If OtherPlayerindex > 0 Then
                Addlog(GetPlayerName(index) & " fala para " & GetPlayerName(index) & ", '" & Msg & "'", PLAYER_LOG)
                PlayerMsg(OtherPlayerindex, GetPlayerName(index) & " te fala: '" & Msg & "'", ColorType.Pink)
                PlayerMsg(index, "Você diz para " & GetPlayerName(OtherPlayerindex) & ": '" & Msg & "'", ColorType.Pink)
            Else
                PlayerMsg(index, "Jogador não está online.", ColorType.BrightRed)
            End If
        Else
            PlayerMsg(index, "Você não pode mandar mensagem para si próprio!", ColorType.BrightRed)
        End If
    End Sub

    Private Sub Packet_PlayerMove(index As Integer, ByRef data() As Byte)
        Dim Dir As Integer
        Dim movement As Integer
        Dim tmpX As Integer, tmpY As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CPlayerMove")
#End If
        If TempPlayer(index).GettingMap = True Then Exit Sub

        Dir = buffer.ReadInt32
        movement = buffer.ReadInt32
        tmpX = buffer.ReadInt32
        tmpY = buffer.ReadInt32
        buffer.Dispose()

        ' Prevenir hacking
        If Dir < DirectionType.Up OrElse Dir > DirectionType.Right Then Exit Sub

        If movement < 1 OrElse movement > 2 Then Exit Sub

        ' Prevenir jogador de mover se ele gerou uma habilidade
        If TempPlayer(index).SkillBuffer > 0 Then
            SendPlayerXY(index)
            Exit Sub
        End If

        'Não mover se estiver no banco!
        If TempPlayer(index).InBank Then
            SendPlayerXY(index)
            Exit Sub
        End If

        ' Se estuporado, não mover
        If TempPlayer(index).StunDuration > 0 Then
            SendPlayerXY(index)
            Exit Sub
        End If

        ' Prevenir jogador de mover se estiver na loja
        If TempPlayer(index).InShop > 0 Then
            SendPlayerXY(index)
            Exit Sub
        End If

        ' Desincronizado
        If GetPlayerX(index) <> tmpX Then
            SendPlayerXY(index)
            Exit Sub
        End If

        If GetPlayerY(index) <> tmpY Then
            SendPlayerXY(index)
            Exit Sub
        End If

        PlayerMove(index, Dir, movement, False)
#If DEBUG Then
        AddDebug(" Jogador: " & GetPlayerName(index) & " : " & " X: " & tmpX & " Y: " & tmpY & " Dir: " & Dir & " Movimento: " & movement)
#End If
        buffer.Dispose()
    End Sub

    Sub Packet_PlayerDirection(index As Integer, ByRef data() As Byte)
        Dim dir As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CPlayerDir")
#End If
        If TempPlayer(index).GettingMap = True Then Exit Sub

        dir = buffer.ReadInt32
        buffer.Dispose()

        ' Prevenir hacking
        If dir < DirectionType.Up OrElse dir > DirectionType.Right Then Exit Sub

        SetPlayerDir(index, dir)

        buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SPlayerDir)
        buffer.WriteInt32(index)
        buffer.WriteInt32(GetPlayerDir(index))
        SendDataToMapBut(index, GetPlayerMap(index), buffer.Data, buffer.Head)
#If DEBUG Then
        AddDebug("Enviada SMSG: SPlayerDir")
#End If
        buffer.Dispose()

    End Sub

    Sub Packet_UseItem(index As Integer, ByRef data() As Byte)
        Dim invnum As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Enviada CMSG: CUseItem")
#End If
        invnum = buffer.ReadInt32
        buffer.Dispose()

        UseItem(index, invnum)
    End Sub

    Sub Packet_Attack(index As Integer, ByRef data() As Byte)
        Dim i As Integer
        Dim Tempindex As Integer
        Dim x As Integer, y As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Enviada CMSG: CAttack")
#End If
        ' Não pode atacar enquanto conjurando
        If TempPlayer(index).SkillBuffer > 0 Then Exit Sub

        ' Não pode atacar enquanto estuporado
        If TempPlayer(index).StunDuration > 0 Then Exit Sub

        ' Mandar esta packet para que veja a pessoa atacando
        buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SAttack)
        buffer.WriteInt32(index)
        SendDataToMap(GetPlayerMap(index), buffer.Data, buffer.Head)
        buffer.Dispose()

        ' Verificar projetil
        If GetPlayerEquipment(index, EquipmentType.Weapon) > 0 Then
            If Item(GetPlayerEquipment(index, EquipmentType.Weapon)).Projectile > 0 Then 'Item tem um projetil
                If Item(GetPlayerEquipment(index, EquipmentType.Weapon)).Ammo > 0 Then
                    If HasItem(index, Item(GetPlayerEquipment(index, EquipmentType.Weapon)).Ammo) Then
                        TakeInvItem(index, Item(GetPlayerEquipment(index, EquipmentType.Weapon)).Ammo, 1)
                        PlayerFireProjectile(index)
                        Exit Sub
                    Else
                        PlayerMsg(index, "Não há mais " & Item(Item(GetPlayerEquipment(index, EquipmentType.Weapon)).Ammo).Name & " !", ColorType.BrightRed)
                        Exit Sub
                    End If
                Else
                    PlayerFireProjectile(index)
                    Exit Sub
                End If
            End If
        End If

        ' Tentar atacar um jogador
        For i = 1 To GetPlayersOnline()
            Tempindex = i

            ' Ter certeza que não estamos nos atacando
            If Tempindex <> index Then
                If IsPlaying(Tempindex) Then
                    TryPlayerAttackPlayer(index, i)
                End If
            End If
        Next

        ' Tentar atacar um NPC
        For i = 1 To MAX_MAP_NPCS
            TryPlayerAttackNpc(index, i)
        Next

        ' Checar tradeskills
        Select Case GetPlayerDir(index)
            Case DirectionType.Up

                If GetPlayerY(index) = 0 Then Exit Sub
                x = GetPlayerX(index)
                y = GetPlayerY(index) - 1
            Case DirectionType.Down

                If GetPlayerY(index) = Map(GetPlayerMap(index)).MaxY Then Exit Sub
                x = GetPlayerX(index)
                y = GetPlayerY(index) + 1
            Case DirectionType.Left

                If GetPlayerX(index) = 0 Then Exit Sub
                x = GetPlayerX(index) - 1
                y = GetPlayerY(index)
            Case DirectionType.Right

                If GetPlayerX(index) = Map(GetPlayerMap(index)).MaxX Then Exit Sub
                x = GetPlayerX(index) + 1
                y = GetPlayerY(index)
        End Select

        CheckResource(index, x, y)

        buffer.Dispose()
    End Sub

    Sub Packet_PlayerInfo(index As Integer, ByRef data() As Byte)
        Dim i As Integer, n As Integer
        Dim name As String
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CPlayerInfoRequest")
#End If
        name = buffer.ReadString
        i = FindPlayer(name)

        If i > 0 Then
            PlayerMsg(index, "Conta:  " & Trim$(Player(i).Login) & ", Nome: " & GetPlayerName(i), ColorType.Yellow)

            If GetPlayerAccess(index) > AdminType.Monitor Then
                PlayerMsg(index, "-=- Atributos de " & GetPlayerName(i) & " -=-", ColorType.Yellow)
                PlayerMsg(index, "Nível: " & GetPlayerLevel(i) & "  Exp: " & GetPlayerExp(i) & "/" & GetPlayerNextLevel(i), ColorType.Yellow)
                PlayerMsg(index, "HP: " & GetPlayerVital(i, VitalType.HP) & "/" & GetPlayerMaxVital(i, VitalType.HP) & "  MP: " & GetPlayerVital(i, VitalType.MP) & "/" & GetPlayerMaxVital(i, VitalType.MP) & "  SP: " & GetPlayerVital(i, VitalType.SP) & "/" & GetPlayerMaxVital(i, VitalType.SP), ColorType.Yellow)
                PlayerMsg(index, "Força: " & GetPlayerStat(i, StatType.Strength) & "  Defesa: " & GetPlayerStat(i, StatType.Endurance) & "  Magia: " & GetPlayerStat(i, StatType.Intelligence) & "  Vel.: " & GetPlayerStat(i, StatType.Spirit), ColorType.Yellow)
                n = (GetPlayerStat(i, StatType.Strength) \ 2) + (GetPlayerLevel(i) \ 2)
                i = (GetPlayerStat(i, StatType.Endurance) \ 2) + (GetPlayerLevel(i) \ 2)

                If n > 100 Then n = 100
                If i > 100 Then i = 100
                PlayerMsg(index, "Chance de Acerto Crítico: " & n & "%, Chance de Bloqueio: " & i & "%", ColorType.Yellow)
            End If
        Else
            PlayerMsg(index, "Jogador não está online.", ColorType.BrightRed)
        End If

        buffer.Dispose()
    End Sub

    Sub Packet_WarpMeTo(index As Integer, ByRef data() As Byte)
        Dim n As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CWarpMeTo")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then Exit Sub

        ' O jogador
        n = FindPlayer(buffer.ReadString)
        buffer.Dispose()

        If n <> index Then
            If n > 0 Then
                PlayerWarp(index, GetPlayerMap(n), GetPlayerX(n), GetPlayerY(n))
                PlayerMsg(n, GetPlayerName(index) & " foi teleportado à você.", ColorType.Yellow)
                PlayerMsg(index, "Você foi teleportado para " & GetPlayerName(n) & ".", ColorType.Yellow)
                Addlog(GetPlayerName(index) & " foi teleportado para " & GetPlayerName(n) & ", mapa #" & GetPlayerMap(n) & ".", ADMIN_LOG)
            Else
                PlayerMsg(index, "O jogador não está online.", ColorType.BrightRed)
            End If
        Else
            PlayerMsg(index, "Você não pode se teleportar!", ColorType.BrightRed)
        End If

    End Sub

    Sub Packet_WarpToMe(index As Integer, ByRef data() As Byte)
        Dim n As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CWarpToMe")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then Exit Sub

        ' O jogador
        n = FindPlayer(buffer.ReadString)
        buffer.Dispose()

        If n <> index Then
            If n > 0 Then
                PlayerWarp(n, GetPlayerMap(index), GetPlayerX(index), GetPlayerY(index))
                PlayerMsg(n, "Você foi convocado por " & GetPlayerName(index) & ".", ColorType.Yellow)
                PlayerMsg(index, GetPlayerName(n) & " foi convocado.", ColorType.Yellow)
                Addlog(GetPlayerName(index) & " teleportou " & GetPlayerName(n) & " para si, mapa #" & GetPlayerMap(index) & ".", ADMIN_LOG)
            Else
                PlayerMsg(index, "O jogador não está online.", ColorType.BrightRed)
            End If
        Else
            PlayerMsg(index, "Você não pode se autoteleportar!", ColorType.BrightRed)
        End If

    End Sub

    Sub Packet_WarpTo(index As Integer, ByRef data() As Byte)
        Dim n As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CWarpTo")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then Exit Sub

        ' O mapa
        n = buffer.ReadInt32
        buffer.Dispose()

        ' Prevenir hacking
        If n < 0 OrElse n > MAX_CACHED_MAPS Then Exit Sub

        PlayerWarp(index, n, GetPlayerX(index), GetPlayerY(index))
        PlayerMsg(index, "Você foi teleportado para o mapa #" & n, ColorType.Yellow)
        Addlog(GetPlayerName(index) & " teleportou para o mapa #" & n & ".", ADMIN_LOG)

    End Sub

    Sub Packet_SetSprite(index As Integer, ByRef data() As Byte)
        Dim n As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CSetSprite")
#End If

        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then Exit Sub

        ' A sprite
        n = buffer.ReadInt32
        buffer.Dispose()

        SetPlayerSprite(index, n)
        SendPlayerData(index)

    End Sub

    Sub Packet_GetStats(index As Integer, ByRef data() As Byte)
        Dim i As Integer
        Dim n As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CGetStats")
#End If
        PlayerMsg(index, "-=- Atributos de " & GetPlayerName(index) & " -=-", ColorType.Yellow)
        PlayerMsg(index, "Nível: " & GetPlayerLevel(index) & "  Exp: " & GetPlayerExp(index) & "/" & GetPlayerNextLevel(index), ColorType.Yellow)
        PlayerMsg(index, "HP: " & GetPlayerVital(index, VitalType.HP) & "/" & GetPlayerMaxVital(index, VitalType.HP) & "  MP: " & GetPlayerVital(index, VitalType.MP) & "/" & GetPlayerMaxVital(index, VitalType.MP) & "  SP: " & GetPlayerVital(index, VitalType.SP) & "/" & GetPlayerMaxVital(index, VitalType.SP), ColorType.Yellow)
        PlayerMsg(index, "FOR: " & GetPlayerStat(index, StatType.Strength) & "  DEF: " & GetPlayerStat(index, StatType.Endurance) & "  MAGI: " & GetPlayerStat(index, StatType.Intelligence) & "  VEL: " & GetPlayerStat(index, StatType.Spirit), ColorType.Yellow)
        n = (GetPlayerStat(index, StatType.Strength) \ 2) + (GetPlayerLevel(index) \ 2)
        i = (GetPlayerStat(index, StatType.Endurance) \ 2) + (GetPlayerLevel(index) \ 2)

        If n > 100 Then n = 100
        If i > 100 Then i = 100
        PlayerMsg(index, "Chance de Acerto Crítico: " & n & "%, Chance de Bloqueio: " & i & "%", ColorType.Yellow)
        buffer.Dispose()
    End Sub

    Sub Packet_RequestNewMap(index As Integer, ByRef data() As Byte)
        Dim dir As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CRequestNewMap")
#End If
        dir = buffer.ReadInt32
        buffer.Dispose()

        ' Prevenir hacking
        If dir < DirectionType.Up OrElse dir > DirectionType.Right Then Exit Sub

        PlayerMove(index, dir, 1, True)
    End Sub

    Sub Packet_MapData(index As Integer, ByRef data() As Byte)
        Dim i As Integer
        Dim mapNum As Integer
        Dim x As Integer
        Dim y As Integer
#If DEBUG Then
        AddDebug("Recebida CMSG: CSaveMap")
#End If
        Dim buffer As New ByteStream(Compression.DecompressBytes(data))

        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then Exit Sub

        Gettingmap = True

        mapNum = GetPlayerMap(index)

        i = Map(mapNum).Revision + 1
        ClearMap(mapNum)

        Map(mapNum).Name = buffer.ReadString
        Map(mapNum).Music = buffer.ReadString
        Map(mapNum).Revision = i
        Map(mapNum).Moral = buffer.ReadInt32
        Map(mapNum).Tileset = buffer.ReadInt32
        Map(mapNum).Up = buffer.ReadInt32
        Map(mapNum).Down = buffer.ReadInt32
        Map(mapNum).Left = buffer.ReadInt32
        Map(mapNum).Right = buffer.ReadInt32
        Map(mapNum).BootMap = buffer.ReadInt32
        Map(mapNum).BootX = buffer.ReadInt32
        Map(mapNum).BootY = buffer.ReadInt32
        Map(mapNum).MaxX = buffer.ReadInt32
        Map(mapNum).MaxY = buffer.ReadInt32
        Map(mapNum).WeatherType = buffer.ReadInt32
        Map(mapNum).Fogindex = buffer.ReadInt32
        Map(mapNum).WeatherIntensity = buffer.ReadInt32
        Map(mapNum).FogAlpha = buffer.ReadInt32
        Map(mapNum).FogSpeed = buffer.ReadInt32
        Map(mapNum).HasMapTint = buffer.ReadInt32
        Map(mapNum).MapTintR = buffer.ReadInt32
        Map(mapNum).MapTintG = buffer.ReadInt32
        Map(mapNum).MapTintB = buffer.ReadInt32
        Map(mapNum).MapTintA = buffer.ReadInt32

        Map(mapNum).Instanced = buffer.ReadInt32
        Map(mapNum).Panorama = buffer.ReadInt32
        Map(mapNum).Parallax = buffer.ReadInt32

        ReDim Map(mapNum).Tile(Map(mapNum).MaxX, Map(mapNum).MaxY)

        For x = 1 To MAX_MAP_NPCS
            ClearMapNpc(x, mapNum)
            Map(mapNum).Npc(x) = buffer.ReadInt32
        Next

        With Map(mapNum)
            For x = 0 To .MaxX
                For y = 0 To .MaxY
                    .Tile(x, y).Data1 = buffer.ReadInt32
                    .Tile(x, y).Data2 = buffer.ReadInt32
                    .Tile(x, y).Data3 = buffer.ReadInt32
                    .Tile(x, y).DirBlock = buffer.ReadInt32
                    ReDim .Tile(x, y).Layer(LayerType.Count - 1)
                    For i = 0 To LayerType.Count - 1
                        .Tile(x, y).Layer(i).Tileset = buffer.ReadInt32
                        .Tile(x, y).Layer(i).X = buffer.ReadInt32
                        .Tile(x, y).Layer(i).Y = buffer.ReadInt32
                        .Tile(x, y).Layer(i).AutoTile = buffer.ReadInt32
                    Next
                    .Tile(x, y).Type = buffer.ReadInt32
                Next
            Next

        End With

        'Dados de Eventos!
        Map(mapNum).EventCount = buffer.ReadInt32

        If Map(mapNum).EventCount > 0 Then
            ReDim Map(mapNum).Events(Map(mapNum).EventCount)
            For i = 1 To Map(mapNum).EventCount
                With Map(mapNum).Events(i)
                    .Name = buffer.ReadString
                    .Globals = buffer.ReadInt32
                    .X = buffer.ReadInt32
                    .Y = buffer.ReadInt32
                    .PageCount = buffer.ReadInt32
                End With
                If Map(mapNum).Events(i).PageCount > 0 Then
                    ReDim Map(mapNum).Events(i).Pages(Map(mapNum).Events(i).PageCount)
                    ReDim TempPlayer(i).EventMap.EventPages(Map(mapNum).Events(i).PageCount)
                    For x = 1 To Map(mapNum).Events(i).PageCount
                        With Map(mapNum).Events(i).Pages(x)
                            .ChkVariable = buffer.ReadInt32
                            .Variableindex = buffer.ReadInt32
                            .VariableCondition = buffer.ReadInt32
                            .VariableCompare = buffer.ReadInt32

                            Map(mapNum).Events(i).Pages(x).ChkSwitch = buffer.ReadInt32
                            Map(mapNum).Events(i).Pages(x).Switchindex = buffer.ReadInt32
                            .SwitchCompare = buffer.ReadInt32

                            .ChkHasItem = buffer.ReadInt32
                            .HasItemindex = buffer.ReadInt32
                            .HasItemAmount = buffer.ReadInt32

                            .ChkSelfSwitch = buffer.ReadInt32
                            .SelfSwitchindex = buffer.ReadInt32
                            .SelfSwitchCompare = buffer.ReadInt32

                            .GraphicType = buffer.ReadInt32
                            .Graphic = buffer.ReadInt32
                            .GraphicX = buffer.ReadInt32
                            .GraphicY = buffer.ReadInt32
                            .GraphicX2 = buffer.ReadInt32
                            .GraphicY2 = buffer.ReadInt32

                            .MoveType = buffer.ReadInt32
                            .MoveSpeed = buffer.ReadInt32
                            .MoveFreq = buffer.ReadInt32

                            .MoveRouteCount = buffer.ReadInt32

                            .IgnoreMoveRoute = buffer.ReadInt32
                            .RepeatMoveRoute = buffer.ReadInt32

                            If .MoveRouteCount > 0 Then
                                ReDim Map(mapNum).Events(i).Pages(x).MoveRoute(.MoveRouteCount)
                                For y = 1 To .MoveRouteCount
                                    .MoveRoute(y).Index = buffer.ReadInt32
                                    .MoveRoute(y).Data1 = buffer.ReadInt32
                                    .MoveRoute(y).Data2 = buffer.ReadInt32
                                    .MoveRoute(y).Data3 = buffer.ReadInt32
                                    .MoveRoute(y).Data4 = buffer.ReadInt32
                                    .MoveRoute(y).Data5 = buffer.ReadInt32
                                    .MoveRoute(y).Data6 = buffer.ReadInt32
                                Next
                            End If

                            .WalkAnim = buffer.ReadInt32
                            .DirFix = buffer.ReadInt32
                            .WalkThrough = buffer.ReadInt32
                            .ShowName = buffer.ReadInt32
                            .Trigger = buffer.ReadInt32
                            .CommandListCount = buffer.ReadInt32

                            .Position = buffer.ReadInt32
                            .QuestNum = buffer.ReadInt32

                            .ChkPlayerGender = buffer.ReadInt32
                        End With

                        If Map(mapNum).Events(i).Pages(x).CommandListCount > 0 Then
                            ReDim Map(mapNum).Events(i).Pages(x).CommandList(Map(mapNum).Events(i).Pages(x).CommandListCount)
                            For y = 1 To Map(mapNum).Events(i).Pages(x).CommandListCount
                                Map(mapNum).Events(i).Pages(x).CommandList(y).CommandCount = buffer.ReadInt32
                                Map(mapNum).Events(i).Pages(x).CommandList(y).ParentList = buffer.ReadInt32
                                If Map(mapNum).Events(i).Pages(x).CommandList(y).CommandCount > 0 Then
                                    ReDim Map(mapNum).Events(i).Pages(x).CommandList(y).Commands(Map(mapNum).Events(i).Pages(x).CommandList(y).CommandCount)
                                    For z = 1 To Map(mapNum).Events(i).Pages(x).CommandList(y).CommandCount
                                        With Map(mapNum).Events(i).Pages(x).CommandList(y).Commands(z)
                                            .Index = buffer.ReadInt32
                                            .Text1 = buffer.ReadString
                                            .Text2 = buffer.ReadString
                                            .Text3 = buffer.ReadString
                                            .Text4 = buffer.ReadString
                                            .Text5 = buffer.ReadString
                                            .Data1 = buffer.ReadInt32
                                            .Data2 = buffer.ReadInt32
                                            .Data3 = buffer.ReadInt32
                                            .Data4 = buffer.ReadInt32
                                            .Data5 = buffer.ReadInt32
                                            .Data6 = buffer.ReadInt32
                                            .ConditionalBranch.CommandList = buffer.ReadInt32
                                            .ConditionalBranch.Condition = buffer.ReadInt32
                                            .ConditionalBranch.Data1 = buffer.ReadInt32
                                            .ConditionalBranch.Data2 = buffer.ReadInt32
                                            .ConditionalBranch.Data3 = buffer.ReadInt32
                                            .ConditionalBranch.ElseCommandList = buffer.ReadInt32
                                            .MoveRouteCount = buffer.ReadInt32
                                            Dim tmpcount As Integer = .MoveRouteCount
                                            If tmpcount > 0 Then
                                                ReDim Preserve .MoveRoute(tmpcount)
                                                For w = 1 To tmpcount
                                                    .MoveRoute(w).Index = buffer.ReadInt32
                                                    .MoveRoute(w).Data1 = buffer.ReadInt32
                                                    .MoveRoute(w).Data2 = buffer.ReadInt32
                                                    .MoveRoute(w).Data3 = buffer.ReadInt32
                                                    .MoveRoute(w).Data4 = buffer.ReadInt32
                                                    .MoveRoute(w).Data5 = buffer.ReadInt32
                                                    .MoveRoute(w).Data6 = buffer.ReadInt32
                                                Next
                                            End If
                                        End With
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        End If
        'Fim dos Dados de Eventos

        ' Salvar o mapa
        SaveMap(mapNum)
        SaveMapEvent(mapNum)

        Gettingmap = False

        SendMapNpcsToMap(mapNum)
        SpawnMapNpcs(mapNum)
        SpawnGlobalEvents(mapNum)

        For i = 1 To GetPlayersOnline()
            If IsPlaying(i) Then
                If Player(i).Character(TempPlayer(i).CurChar).Map = mapNum Then
                    SpawnMapEventsFor(i, mapNum)
                End If
            End If
        Next

        ' Limpar tudo
        For i = 1 To MAX_MAP_ITEMS
            SpawnItemSlot(i, 0, 0, GetPlayerMap(index), MapItem(GetPlayerMap(index), i).X, MapItem(GetPlayerMap(index), i).Y)
            ClearMapItem(i, GetPlayerMap(index))
        Next

        ' Respawn
        SpawnMapItems(GetPlayerMap(index))

        ClearTempTile(mapNum)
        CacheResources(mapNum)

        ' Atualizar mapa para todos online
        For i = 1 To GetPlayersOnline()
            If IsPlaying(i) AndAlso GetPlayerMap(i) = mapNum Then
                PlayerWarp(i, mapNum, GetPlayerX(i), GetPlayerY(i))
                ' Enviar mapa
                SendMapData(i, mapNum, True)
            End If
        Next

        buffer.Dispose()
    End Sub

    Private Sub Packet_NeedMap(index As Integer, ByRef data() As Byte)
        Dim s As String
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CNeedMap")
#End If
        ' Pegar valor sim/nao
        s = buffer.ReadInt32
        buffer.Dispose()

        ' Ver se é necessário mandar as infos do mapa
        If s = 1 Then
            SendMapData(index, GetPlayerMap(index), True)
        Else
            SendMapData(index, GetPlayerMap(index), False)
        End If

        SpawnMapEventsFor(index, GetPlayerMap(index))
        SendJoinMap(index)
        TempPlayer(index).GettingMap = False
    End Sub

    Sub Packet_RespawnMap(index As Integer, ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CMapRespawn")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then Exit Sub

        ' Limpar tudo
        For i = 1 To MAX_MAP_ITEMS
            SpawnItemSlot(i, 0, 0, GetPlayerMap(index), MapItem(GetPlayerMap(index), i).X, MapItem(GetPlayerMap(index), i).Y)
            ClearMapItem(i, GetPlayerMap(index))
        Next

        ' Respawn
        SpawnMapItems(GetPlayerMap(index))

        ' Respawn nos NPCS
        For i = 1 To MAX_MAP_NPCS
            SpawnNpc(i, GetPlayerMap(index))
        Next

        CacheResources(GetPlayerMap(index))
        PlayerMsg(index, "O mapa foi re-gerado.", ColorType.BrightGreen)
        Addlog(GetPlayerName(index) & " re-gerou o mapa #" & GetPlayerMap(index), ADMIN_LOG)

        buffer.Dispose()
    End Sub

    Sub Packet_KickPlayer(index As Integer, ByRef data() As Byte)
        Dim n As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CKickPlayer")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) <= 0 Then
            Exit Sub
        End If

        ' Índice do jogador
        n = FindPlayer(buffer.ReadString)
        buffer.Dispose()

        If n <> index Then
            If n > 0 Then
                If GetPlayerAccess(n) < GetPlayerAccess(index) Then
                    GlobalMsg(GetPlayerName(n) & " foi chutado do " & Settings.GameName & " por " & GetPlayerName(index) & "!")
                    Addlog(GetPlayerName(index) & " chutou " & GetPlayerName(n) & ".", ADMIN_LOG)
                    AlertMsg(n, "Você foi chutado por " & GetPlayerName(index) & "!", True)
                Else
                    PlayerMsg(index, "Esse é alguém de acesso igual ou maior que o seu!", ColorType.BrightRed)
                End If
            Else
                PlayerMsg(index, "O jogador não está online.", ColorType.BrightRed)
            End If
        Else
            PlayerMsg(index, "Você não pode se chutar!", ColorType.BrightRed)
        End If
    End Sub

    Sub Packet_Banlist(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida CMSG: CBanList")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then
            Exit Sub
        End If

        PlayerMsg(index, "Comando /banlist ainda não está disponível.", ColorType.Yellow)
    End Sub

    Sub Packet_DestroyBans(index As Integer, ByRef data() As Byte)
        Dim filename As String
#If DEBUG Then
        AddDebug("Recebida CMSG: CBanDestory")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Creator Then Exit Sub

        filename = Application.StartupPath & "\Dados\banlist.txt"

        If File.Exists(filename) Then Kill(filename)

        PlayerMsg(index, "Lista de bans destruída.", ColorType.BrightGreen)
    End Sub

    Sub Packet_BanPlayer(index As Integer, ByRef data() As Byte)
        Dim n As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CBanPlayer")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then Exit Sub

        ' Índice do jogador
        n = FindPlayer(buffer.ReadString)
        buffer.Dispose()

        If n <> index Then
            If n > 0 Then
                If GetPlayerAccess(n) < GetPlayerAccess(index) Then
                    BanIndex(n, index)
                Else
                    PlayerMsg(index, "Esse é alguém de acesso igual ou maior que o seu!", ColorType.BrightRed)
                End If
            Else
                PlayerMsg(index, "O jogador não está online.", ColorType.BrightRed)
            End If
        Else
            PlayerMsg(index, "Você não pode se banir!", ColorType.BrightRed)
        End If

    End Sub

    Private Sub Packet_EditMapRequest(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida CMSG: CRequestEditMap")
#End If
        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then Exit Sub

        If GetPlayerMap(index) > MAX_MAPS Then
            PlayerMsg(index, "Não dá pra editar mapas instanciados!", ColorType.BrightRed)
            Exit Sub
        End If

        SendMapEventData(index)

        Dim Buffer As New ByteStream(4)
        Buffer.WriteInt32(ServerPackets.SEditMap)
        Socket.SendDataTo(index, Buffer.Data, Buffer.Head)
        Buffer.Dispose()
    End Sub

    Sub Packet_EditShop(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida EMSG: RequestEditShop")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub

        Dim Buffer = New ByteStream(4)
        Buffer.WriteInt32(ServerPackets.SShopEditor)
        Socket.SendDataTo(index, Buffer.Data, Buffer.Head)
#If DEBUG Then
        AddDebug("Enviada SMSG: SShopEditor")
#End If
        Buffer.Dispose()
    End Sub

    Sub Packet_SaveShop(index As Integer, ByRef data() As Byte)
        Dim ShopNum As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida EMSG: SaveShop")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub

        ShopNum = buffer.ReadInt32

        ' Prevenir hacking
        If ShopNum < 0 OrElse ShopNum > MAX_SHOPS Then Exit Sub

        Shop(ShopNum) = DeserializeData(buffer)

        If Shop(ShopNum).Name Is Nothing Then Shop(ShopNum).Name = ""

        buffer.Dispose()

        ' Salvar
        SendUpdateShopToAll(ShopNum)
        SaveShop(ShopNum)
        Addlog(GetPlayerLogin(index) & " salvando loja #" & ShopNum & ".", ADMIN_LOG)
    End Sub

    Sub Packet_EditSkill(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida EMSG: RequestEditSkill")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub

        Dim Buffer = New ByteStream(4)
        Buffer.WriteInt32(ServerPackets.SSkillEditor)
        Socket.SendDataTo(index, Buffer.Data, Buffer.Head)
#If DEBUG Then
        AddDebug("Enviada SMSG: SSkillEditor")
#End If
        Buffer.Dispose()
    End Sub

    Sub Packet_SaveSkill(index As Integer, ByRef data() As Byte)
        Dim skillnum As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida EMSG: SaveSkill")
#End If
        skillnum = buffer.ReadInt32

        ' Prevenir hacking
        If skillnum < 0 OrElse skillnum > MAX_SKILLS Then Exit Sub

        Skill(skillnum) = DeserializeData(buffer)

        ' Salvar
        SendUpdateSkillToAll(skillnum)
        SaveSkill(skillnum)
        Addlog(GetPlayerLogin(index) & " salvou Habilidade #" & skillnum & ".", ADMIN_LOG)

        buffer.Dispose()
    End Sub

    Sub Packet_SetAccess(index As Integer, ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        Dim n As Integer
        Dim i As Integer
#If DEBUG Then
        AddDebug("Recebida CMSG: CSetAccess")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Creator Then Exit Sub

        ' O índice
        n = FindPlayer(buffer.ReadString)
        ' O acesso
        i = buffer.ReadInt32

        ' Verificar se o acesso é inválido
        If i >= 0 OrElse i <= 3 Then

            ' Ver se o jogador está online
            If n > 0 Then
                'Checar para ver se o mesmo acesso está tentando mudar outro acesso de mesmo nível
                If GetPlayerAccess(n) = GetPlayerAccess(index) Then
                    PlayerMsg(index, "Nível de acesso inválido.", ColorType.BrightRed)
                    Exit Sub
                End If

                If GetPlayerAccess(n) <= 0 Then
                    GlobalMsg(GetPlayerName(n) & " foi abençoado com acesso administrativo.")
                End If

                SetPlayerAccess(n, i)
                SendPlayerData(n)
                Addlog(GetPlayerName(index) & " modificou o acesso e " & GetPlayerName(n) & ".", ADMIN_LOG)
            Else
                PlayerMsg(index, "O jogador não está online.", ColorType.BrightRed)
            End If
        Else
            PlayerMsg(index, "Nível de acesso inválido.", ColorType.BrightRed)
        End If

        buffer.Dispose()
    End Sub

    Sub Packet_WhosOnline(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida CMSG: CWhosOnline")
#End If
        SendWhosOnline(index)
    End Sub

    Sub Packet_SetMotd(index As Integer, ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CSetMotd")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then Exit Sub

        Settings.Welcome = Trim$(buffer.ReadString)
        SaveSettings()

        GlobalMsg("Mensagem de boas-vindas alterada para: " & Settings.Welcome)
        Addlog(GetPlayerName(index) & " mudou as boas-vindas para: " & Settings.Welcome, ADMIN_LOG)

        buffer.Dispose()
    End Sub

    Sub Packet_PlayerSearch(index As Integer, ByRef data() As Byte)
        Dim TargetFound As Byte, rclick As Byte
        Dim x As Integer, y As Integer, i As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CSearch")
#End If
        x = buffer.ReadInt32
        y = buffer.ReadInt32
        rclick = buffer.ReadInt32

        ' Prevenir subscript out of range
        If x < 0 OrElse x > Map(GetPlayerMap(index)).MaxX OrElse y < 0 OrElse y > Map(GetPlayerMap(index)).MaxY Then Exit Sub

        ' Verificar o jogador
        For i = 1 To GetPlayersOnline()

            If IsPlaying(i) Then
                If GetPlayerMap(index) = GetPlayerMap(i) Then
                    If GetPlayerX(i) = x Then
                        If GetPlayerY(i) = y Then

                            ' Considerar o jogador
                            If i <> index Then
                                If GetPlayerLevel(i) >= GetPlayerLevel(index) + 5 Then
                                    PlayerMsg(index, "Você não teria chance.", ColorType.BrightRed)
                                Else

                                    If GetPlayerLevel(i) > GetPlayerLevel(index) Then
                                        PlayerMsg(index, "Esse parece ter uma vantagem sobre você.", ColorType.Yellow)
                                    Else

                                        If GetPlayerLevel(i) = GetPlayerLevel(index) Then
                                            PlayerMsg(index, "Esta seria uma luta de igual pra igual.", ColorType.White)
                                        Else

                                            If GetPlayerLevel(index) >= GetPlayerLevel(i) + 5 Then
                                                PlayerMsg(index, "Você poderia assasinar aquele jogador.", ColorType.BrightBlue)
                                            Else

                                                If GetPlayerLevel(index) > GetPlayerLevel(i) Then
                                                    PlayerMsg(index, "Você teria uma vantagem sobre aquele jogador.", ColorType.BrightCyan)
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If

                            ' Alterar alvo
                            TempPlayer(index).Target = i
                            TempPlayer(index).TargetType = TargetType.Player
                            PlayerMsg(index, "Seu alvo agora é " & GetPlayerName(i) & ".", ColorType.Yellow)
                            SendTarget(index, TempPlayer(index).Target, TempPlayer(index).TargetType)
                            TargetFound = 1
                            If rclick = 1 Then SendRightClick(index)
                            Exit Sub
                        End If
                    End If
                End If
            End If

        Next

        ' Verificar item
        For i = 1 To MAX_MAP_ITEMS

            If MapItem(GetPlayerMap(index), i).Num > 0 Then
                If MapItem(GetPlayerMap(index), i).X = x Then
                    If MapItem(GetPlayerMap(index), i).Y = y Then
                        PlayerMsg(index, "Você vê um(a) " & CheckGrammar(Trim$(Item(MapItem(GetPlayerMap(index), i).Num).Name)) & ".", ColorType.White)
                        Exit Sub
                    End If
                End If
            End If

        Next

        ' Verificar npc
        For i = 1 To MAX_MAP_NPCS

            If MapNpc(GetPlayerMap(index)).Npc(i).Num > 0 Then
                If MapNpc(GetPlayerMap(index)).Npc(i).X = x Then
                    If MapNpc(GetPlayerMap(index)).Npc(i).Y = y Then
                        ' Alterar alvo
                        TempPlayer(index).Target = i
                        TempPlayer(index).TargetType = TargetType.Npc
                        PlayerMsg(index, "Seu alvo agora é " & CheckGrammar(Trim$(Npc(MapNpc(GetPlayerMap(index)).Npc(i).Num).Name)) & ".", ColorType.Yellow)
                        SendTarget(index, TempPlayer(index).Target, TempPlayer(index).TargetType)
                        TargetFound = 1
                        Exit Sub
                    End If
                End If
            End If

        Next

        'Casa
        If Player(index).Character(TempPlayer(index).CurChar).InHouse > 0 Then
            If Player(index).Character(TempPlayer(index).CurChar).InHouse = index Then
                If Player(index).Character(TempPlayer(index).CurChar).House.Houseindex > 0 Then
                    If Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount > 0 Then
                        For i = 1 To Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount
                            If x >= Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).X AndAlso x <= Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).X + Item(Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).ItemNum).FurnitureWidth - 1 Then
                                If y <= Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).Y AndAlso y >= Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).Y - Item(Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).ItemNum).FurnitureHeight + 1 Then
                                    'Encontrou um item, pegar o index e catar o item!
                                    x = FindOpenInvSlot(index, Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).ItemNum)
                                    If x > 0 Then
                                        GiveInvItem(index, Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).ItemNum, 0, True)
                                        Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount = Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount - 1
                                        For x = i + 1 To Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount + 1
                                            Player(index).Character(TempPlayer(index).CurChar).House.Furniture(x - 1) = Player(index).Character(TempPlayer(index).CurChar).House.Furniture(x)
                                        Next
                                        ReDim Preserve Player(index).Character(TempPlayer(index).CurChar).House.Furniture(Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount)
                                        SendFurnitureToHouse(index)
                                        Exit Sub
                                    Else
                                        PlayerMsg(index, "Inventário cheio!", ColorType.BrightRed)
                                    End If
                                    Exit Sub
                                End If
                            End If
                        Next
                    End If
                End If
            End If
        End If

        If TargetFound = 0 Then
            SendTarget(index, 0, 0)
        End If

        buffer.Dispose()
    End Sub

    Sub Packet_Skills(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Enviada CMSG: CSkills")
#End If

        SendPlayerSkills(index)
    End Sub

    Sub Packet_Cast(index As Integer, ByRef data() As Byte)
        Dim n As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Enviada CMSG: CCast")
#End If
        ' Espaço de Habilidades
        n = buffer.ReadInt32
        buffer.Dispose()

        ' Setr o buffer da habilidade antes de conjurar
        BufferSkill(index, n)

        buffer.Dispose()
    End Sub

    Sub Packet_QuitGame(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Enviada CMSG: CQuit")
#End If
        SendLeftGame(index)
        LeftGame(index)
    End Sub

    Sub Packet_SwapInvSlots(index As Integer, ByRef data() As Byte)
        Dim oldSlot As Integer, newSlot As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CSwapInvSlots")
#End If
        If TempPlayer(index).InTrade > 0 OrElse TempPlayer(index).InBank OrElse TempPlayer(index).InShop Then Exit Sub

        ' Slot antigo
        oldSlot = buffer.ReadInt32
        newSlot = buffer.ReadInt32
        buffer.Dispose()

        PlayerSwitchInvSlots(index, oldSlot, newSlot)

        buffer.Dispose()
    End Sub

    Sub Packet_CheckPing(index As Integer, ByRef data() As Byte)
        Dim buffer As ByteStream
        buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SSendPing)
        Socket.SendDataTo(index, buffer.Data, buffer.Head)
#If DEBUG Then
        AddDebug("Enviada SMSG: SSendPing")
#End If
        buffer.Dispose()
    End Sub

    Sub Packet_Unequip(index As Integer, ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CUnequip")
#End If
        PlayerUnequipItem(index, buffer.ReadInt32)

        buffer.Dispose()
    End Sub

    Sub Packet_RequestPlayerData(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida CMSG: CRequestPlayerData")
#End If
        SendPlayerData(index)
    End Sub

    Sub Packet_RequestNpcs(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida CMSG: CRequestNPCS")
#End If
        SendNpcs(index)
    End Sub

    Sub Packet_SpawnItem(index As Integer, ByRef data() As Byte)
        Dim tmpItem As Integer
        Dim tmpAmount As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CSpawnItem")
#End If
        ' item
        tmpItem = buffer.ReadInt32
        tmpAmount = buffer.ReadInt32

        If GetPlayerAccess(index) < AdminType.Creator Then Exit Sub

        SpawnItem(tmpItem, tmpAmount, GetPlayerMap(index), GetPlayerX(index), GetPlayerY(index))
        buffer.Dispose()
    End Sub

    Sub Packet_TrainStat(index As Integer, ByRef data() As Byte)
        Dim tmpstat As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CTrainStat")
#End If
        ' Checar pontos
        If GetPlayerPOINTS(index) = 0 Then Exit Sub

        ' atributos
        tmpstat = buffer.ReadInt32

        ' incrementar atriutos
        SetPlayerStat(index, tmpstat, GetPlayerRawStat(index, tmpstat) + 1)

        ' decrementar pontos
        SetPlayerPOINTS(index, GetPlayerPOINTS(index) - 1)

        ' enviar novos dados do jogador
        SendPlayerData(index)
        buffer.Dispose()
    End Sub

    Sub Packet_RequestSkills(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida CMSG: CRequestSkills")
#End If
        SendSkills(index)
    End Sub

    Sub Packet_RequestShops(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida CMSG: CRequestShops")
#End If
        SendShops(index)
    End Sub

    Sub Packet_RequestLevelUp(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida CMSG: CRequestLevelUp")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Creator Then Exit Sub

        SetPlayerExp(index, GetPlayerNextLevel(index))
        CheckPlayerLevelUp(index)
    End Sub

    Sub Packet_ForgetSkill(index As Integer, ByRef data() As Byte)
        Dim skillslot As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CForgetSkill")
#End If
        skillslot = buffer.ReadInt32

        ' Check for subscript out of range
        If skillslot < 1 OrElse skillslot > MAX_PLAYER_SKILLS Then Exit Sub

        ' dont let them forget a skill which is in CD
        If TempPlayer(index).SkillCd(skillslot) > 0 Then
            PlayerMsg(index, "Não se pode esquecer uma habilidade que está recarregando!", ColorType.BrightRed)
            Exit Sub
        End If

        ' dont let them forget a skill which is buffered
        If TempPlayer(index).SkillBuffer = skillslot Then
            PlayerMsg(index, "Não dá pra esquecer uma habilidade que você está usando!", ColorType.BrightRed)
            Exit Sub
        End If

        Player(index).Character(TempPlayer(index).CurChar).Skill(skillslot) = 0
        SendPlayerSkills(index)

        buffer.Dispose()
    End Sub

    Sub Packet_CloseShop(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida CMSG: CCloseShop")
#End If
        TempPlayer(index).InShop = 0
    End Sub

    Sub Packet_BuyItem(index As Integer, ByRef data() As Byte)
        Dim shopslot As Integer, shopnum As Integer, itemamount As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CBuyItem")
#End If
        shopslot = buffer.ReadInt32

        ' Não está na loja, sair
        shopnum = TempPlayer(index).InShop
        If shopnum < 1 OrElse shopnum > MAX_SHOPS Then Exit Sub

        With Shop(shopnum).TradeItem(shopslot)
            ' Verificar se a troca existe
            If .Item < 1 Then Exit Sub

            ' Ver se tem o valor do item
            itemamount = HasItem(index, .CostItem)
            If itemamount = 0 OrElse itemamount < .CostValue Then
                PlayerMsg(index, "Você não tem o suficiente para comprar este item.", ColorType.BrightRed)
                ResetShopAction(index)
                Exit Sub
            End If

            ' Está tudo bem, sigamos em frente
            TakeInvItem(index, .CostItem, .CostValue)
            GiveInvItem(index, .Item, .ItemValue)
        End With

        ' Enviar mensagem de confirmação e resetar a ação de loja
        PlayerMsg(index, "Troca realizada com sucesso..", ColorType.BrightGreen)
        ResetShopAction(index)

        buffer.Dispose()
    End Sub

    Sub Packet_SellItem(index As Integer, ByRef data() As Byte)
        Dim invSlot As Integer
        Dim itemNum As Integer
        Dim price As Integer
        Dim multiplier As Double
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CSellItem")
#End If
        invSlot = buffer.ReadInt32

        ' se inválido, sair
        If invSlot < 1 OrElse invSlot > MAX_INV Then Exit Sub

        ' tem item?
        If GetPlayerInvItemNum(index, invSlot) < 1 OrElse GetPlayerInvItemNum(index, invSlot) > MAX_ITEMS Then Exit Sub

        ' parece ser válido
        itemNum = GetPlayerInvItemNum(index, invSlot)

        ' trabalhar no preço
        multiplier = Shop(TempPlayer(index).InShop).BuyRate / 100
        price = Item(itemNum).Price * multiplier

        ' item tem custo?
        If price <= 0 Then
            PlayerMsg(index, "A loja não quer esse item.", ColorType.Yellow)
            ResetShopAction(index)
            Exit Sub
        End If

        ' pegar o item e dar dinheiro
        TakeInvItem(index, itemNum, 1)
        GiveInvItem(index, 1, price)

        ' enviar mensagem de confirmação e resetar ação da loja
        PlayerMsg(index, "Vendeu o(a) " & Trim(Item(GetPlayerInvItemNum(index, invSlot)).Name) & " !", ColorType.BrightGreen)
        ResetShopAction(index)

        buffer.Dispose()
    End Sub

    Sub Packet_ChangeBankSlots(index As Integer, ByRef data() As Byte)
        Dim oldslot As Integer, newslot As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CChangeBankSlots")
#End If
        oldslot = buffer.ReadInt32
        newslot = buffer.ReadInt32

        PlayerSwitchBankSlots(index, oldslot, newslot)

        buffer.Dispose()
    End Sub

    Sub Packet_DepositItem(index As Integer, ByRef data() As Byte)
        Dim invslot As Integer, amount As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CDepositItem")
#End If
        invslot = buffer.ReadInt32
        amount = buffer.ReadInt32

        GiveBankItem(index, invslot, amount)

        buffer.Dispose()
    End Sub

    Sub Packet_WithdrawItem(index As Integer, ByRef data() As Byte)
        Dim bankslot As Integer, amount As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CWithdrawItem")
#End If
        bankslot = buffer.ReadInt32
        amount = buffer.ReadInt32

        TakeBankItem(index, bankslot, amount)

        buffer.Dispose()
    End Sub

    Sub Packet_CloseBank(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida CMSG: CCloseBank")
#End If
        SaveBank(index)
        SavePlayer(index)

        TempPlayer(index).InBank = False
    End Sub

    Sub Packet_AdminWarp(index As Integer, ByRef data() As Byte)
        Dim x As Integer, y As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CAdminWarp")
#End If
        x = buffer.ReadInt32
        y = buffer.ReadInt32

        If GetPlayerAccess(index) >= AdminType.Mapper Then
            'Setar a informação
            SetPlayerX(index, x)
            SetPlayerY(index, y)

            'enviar as coisas
            SendPlayerXY(index)
        End If

        buffer.Dispose()
    End Sub

    Sub Packet_TradeInvite(index As Integer, ByRef data() As Byte)
        Dim Name As String, tradetarget As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CTradeInvite")
#End If
        Name = buffer.ReadString

        buffer.Dispose()

        ' Checar por um jogador

        tradetarget = FindPlayer(Name)

        ' Ter certeza que não erramos
        If tradetarget <= 0 OrElse tradetarget > MAX_PLAYERS Then Exit Sub

        ' Não podemos trocar com nós mesmos..
        If tradetarget = index Then
            PlayerMsg(index, "Você não pode trocar consigo próprio.", ColorType.BrightRed)
            Exit Sub
        End If

        ' enviar o pedido de troca
        TempPlayer(index).TradeRequest = tradetarget
        TempPlayer(tradetarget).TradeRequest = index

        PlayerMsg(tradetarget, Trim$(GetPlayerName(index)) & " te convidou para um troca.", ColorType.Yellow)
        PlayerMsg(index, "Você convidou " & Trim$(GetPlayerName(tradetarget)) & " para troca.", ColorType.BrightGreen)
        SendClearTradeTimer(index)

        SendTradeInvite(tradetarget, index)
    End Sub

    Sub Packet_TradeInviteAccept(index As Integer, ByRef data() As Byte)
        Dim tradetarget As Integer, status As Byte
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CTradeInviteAccept")
#End If
        status = buffer.ReadInt32

        buffer.Dispose()

        If status = 0 Then Exit Sub

        tradetarget = TempPlayer(index).TradeRequest

        ' Deixem-nos trocar!
        If TempPlayer(tradetarget).TradeRequest = index Then
            ' Deixe eles saberem que estão trocando
            PlayerMsg(index, "Você aceitou o pedido de troca de " & Trim$(GetPlayerName(tradetarget)) & ".", ColorType.Yellow)
            PlayerMsg(tradetarget, Trim$(GetPlayerName(index)) & " aceitou seu pedido de troca.", ColorType.BrightGreen)
            ' Limpar o timeout do client
            SendClearTradeTimer(index)

            ' Limpar a requisição de troca no servidor
            TempPlayer(index).TradeRequest = 0
            TempPlayer(tradetarget).TradeRequest = 0

            ' Setar que estão trocando entre si 
            TempPlayer(index).InTrade = tradetarget
            TempPlayer(tradetarget).InTrade = index

            ' Limpar as ofertas de troca
            ReDim TempPlayer(index).TradeOffer(MAX_INV)
            ReDim TempPlayer(tradetarget).TradeOffer(MAX_INV)
            For i = 1 To MAX_INV
                TempPlayer(index).TradeOffer(i).Num = 0
                TempPlayer(index).TradeOffer(i).Value = 0
                TempPlayer(tradetarget).TradeOffer(i).Num = 0
                TempPlayer(tradetarget).TradeOffer(i).Value = 0
            Next
            ' Usado para iniciar a janela de troca no cliente
            SendTrade(index, tradetarget)
            SendTrade(tradetarget, index)

            ' Enviar os dados da troca - Usado para limpar o cliente
            SendTradeUpdate(index, 0)
            SendTradeUpdate(index, 1)
            SendTradeUpdate(tradetarget, 0)
            SendTradeUpdate(tradetarget, 1)
            Exit Sub
        End If
    End Sub

    Sub Packet_AcceptTrade(index As Integer, ByRef data() As Byte)
        Dim itemNum As Integer
        Dim tradeTarget As Integer, i As Integer
        Dim tmpTradeItem(MAX_INV) As PlayerInvStruct
        Dim tmpTradeItem2(MAX_INV) As PlayerInvStruct
#If DEBUG Then
        AddDebug("Recebida CMSG: CAcceptTrade")
#End If
        TempPlayer(index).AcceptTrade = True

        tradeTarget = TempPlayer(index).InTrade

        ' Se ambos não aceitarem, sair
        If Not TempPlayer(tradeTarget).AcceptTrade Then
            SendTradeStatus(index, 2)
            SendTradeStatus(tradeTarget, 1)
            Exit Sub
        End If

        ' pegar itens deles
        For i = 1 To MAX_INV
            ' jogador
            If TempPlayer(index).TradeOffer(i).Num > 0 Then
                itemNum = Player(index).Character(TempPlayer(index).CurChar).Inv(TempPlayer(index).TradeOffer(i).Num).Num
                If itemNum > 0 Then
                    ' guardar temporariamente
                    tmpTradeItem(i).Num = itemNum
                    tmpTradeItem(i).Value = TempPlayer(index).TradeOffer(i).Value
                    ' pegar item
                    TakeInvSlot(index, TempPlayer(index).TradeOffer(i).Num, tmpTradeItem(i).Value)
                End If
            End If
            ' alvo
            If TempPlayer(tradeTarget).TradeOffer(i).Num > 0 Then
                itemNum = GetPlayerInvItemNum(tradeTarget, TempPlayer(tradeTarget).TradeOffer(i).Num)
                If itemNum > 0 Then
                    ' guardar temporariamente
                    tmpTradeItem2(i).Num = itemNum
                    tmpTradeItem2(i).Value = TempPlayer(tradeTarget).TradeOffer(i).Value
                    ' pegar item
                    TakeInvSlot(tradeTarget, TempPlayer(tradeTarget).TradeOffer(i).Num, tmpTradeItem2(i).Value)
                End If
            End If
        Next

        ' todos itens pegos, agora não podem pegar itens porque não há espaço no inventário
        For i = 1 To MAX_INV
            ' jogador
            If tmpTradeItem2(i).Num > 0 Then
                ' dar!
                GiveInvItem(index, tmpTradeItem2(i).Num, tmpTradeItem2(i).Value, False)
            End If
            ' alvo
            If tmpTradeItem(i).Num > 0 Then
                ' dar!
                GiveInvItem(tradeTarget, tmpTradeItem(i).Num, tmpTradeItem(i).Value, False)
            End If
        Next

        SendInventory(index)
        SendInventory(tradeTarget)

        ' agora tem todos os itens. limpar valores + sair da troca.
        For i = 1 To MAX_INV
            TempPlayer(index).TradeOffer(i).Num = 0
            TempPlayer(index).TradeOffer(i).Value = 0
            TempPlayer(tradeTarget).TradeOffer(i).Num = 0
            TempPlayer(tradeTarget).TradeOffer(i).Value = 0
        Next

        TempPlayer(index).InTrade = 0
        TempPlayer(tradeTarget).InTrade = 0

        PlayerMsg(index, "Troca completa.", ColorType.BrightGreen)
        PlayerMsg(tradeTarget, "Troca completa.", ColorType.BrightGreen)

        SendCloseTrade(index)
        SendCloseTrade(tradeTarget)
    End Sub

    Sub Packet_DeclineTrade(index As Integer, ByRef data() As Byte)
        Dim tradeTarget As Integer
#If DEBUG Then
        AddDebug("Recebida CMSG: CDeclineTrade")
#End If
        tradeTarget = TempPlayer(index).InTrade

        For i = 1 To MAX_INV
            TempPlayer(index).TradeOffer(i).Num = 0
            TempPlayer(index).TradeOffer(i).Value = 0
            TempPlayer(tradeTarget).TradeOffer(i).Num = 0
            TempPlayer(tradeTarget).TradeOffer(i).Value = 0
        Next

        TempPlayer(index).InTrade = 0
        TempPlayer(tradeTarget).InTrade = 0

        PlayerMsg(index, "Você recusou a troca.", ColorType.Yellow)
        PlayerMsg(tradeTarget, GetPlayerName(index) & " recusou trocar com você.", ColorType.BrightRed)

        SendCloseTrade(index)
        SendCloseTrade(tradeTarget)
    End Sub

    Sub Packet_TradeItem(index As Integer, ByRef data() As Byte)
        Dim itemnum As Integer
        Dim invslot As Integer, amount As Integer, emptyslot As Integer, i As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CTradeItem")
#End If
        invslot = buffer.ReadInt32
        amount = buffer.ReadInt32

        buffer.Dispose()

        If invslot <= 0 OrElse invslot > MAX_INV Then Exit Sub

        itemnum = GetPlayerInvItemNum(index, invslot)

        If itemnum <= 0 OrElse itemnum > MAX_ITEMS Then Exit Sub

        ' ter certeza que eles tem a quantidade que oferecem
        If amount < 0 OrElse amount > GetPlayerInvItemValue(index, invslot) Then Exit Sub

        If Item(itemnum).Type = ItemType.Currency OrElse Item(itemnum).Stackable = 1 Then

            ' verificar se já não estão oferecendo o mesmo item
            For i = 1 To MAX_INV

                If TempPlayer(index).TradeOffer(i).Num = invslot Then
                    ' adicionar quantidade
                    TempPlayer(index).TradeOffer(i).Value = TempPlayer(index).TradeOffer(i).Value + amount

                    ' limites
                    If TempPlayer(index).TradeOffer(i).Value > GetPlayerInvItemValue(index, invslot) Then
                        TempPlayer(index).TradeOffer(i).Value = GetPlayerInvItemValue(index, invslot)
                    End If

                    ' cancelar qualquer acordo de troca
                    TempPlayer(index).AcceptTrade = False
                    TempPlayer(TempPlayer(index).InTrade).AcceptTrade = False

                    SendTradeStatus(index, 0)
                    SendTradeStatus(TempPlayer(index).InTrade, 0)

                    SendTradeUpdate(index, 0)
                    SendTradeUpdate(TempPlayer(index).InTrade, 1)
                    ' sair cedo
                    Exit Sub
                End If
            Next
        Else
            ' ter certeza que já não estão oferecendo o item
            For i = 1 To MAX_INV
                If TempPlayer(index).TradeOffer(i).Num = invslot Then
                    PlayerMsg(index, "Voce já ofereceu este item.", ColorType.BrightRed)
                    Exit Sub
                End If
            Next
        End If

        ' não ofereceu - encontrar o primeiro espaço vazio 
        For i = 1 To MAX_INV
            If TempPlayer(index).TradeOffer(i).Num = 0 Then
                emptyslot = i
                Exit For
            End If
        Next
        TempPlayer(index).TradeOffer(emptyslot).Num = invslot
        TempPlayer(index).TradeOffer(emptyslot).Value = amount

        ' cancelar acordo de troca e mandar novo dado
        TempPlayer(index).AcceptTrade = False
        TempPlayer(TempPlayer(index).InTrade).AcceptTrade = False

        SendTradeStatus(index, 0)
        SendTradeStatus(TempPlayer(index).InTrade, 0)

        SendTradeUpdate(index, 0)
        SendTradeUpdate(TempPlayer(index).InTrade, 1)
    End Sub

    Sub Packet_UntradeItem(index As Integer, ByRef data() As Byte)
        Dim tradeslot As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CUntradeItem")
#End If
        tradeslot = buffer.ReadInt32

        buffer.Dispose()

        If tradeslot <= 0 OrElse tradeslot > MAX_INV Then Exit Sub
        If TempPlayer(index).TradeOffer(tradeslot).Num <= 0 Then Exit Sub

        TempPlayer(index).TradeOffer(tradeslot).Num = 0
        TempPlayer(index).TradeOffer(tradeslot).Value = 0

        If TempPlayer(index).AcceptTrade Then TempPlayer(index).AcceptTrade = False
        If TempPlayer(TempPlayer(index).InTrade).AcceptTrade Then TempPlayer(TempPlayer(index).InTrade).AcceptTrade = False

        SendTradeStatus(index, 0)
        SendTradeStatus(TempPlayer(index).InTrade, 0)

        SendTradeUpdate(index, 0)
        SendTradeUpdate(TempPlayer(index).InTrade, 1)
    End Sub

    Sub HackingAttempt(index As Integer, Reason As String)

        If index > 0 AndAlso IsPlaying(index) Then
            GlobalMsg(GetPlayerLogin(index) & "/" & GetPlayerName(index) & " foi desconectado por (" & Reason & ")")

            AlertMsg(index, "Você perdeu sua conexão com " & Settings.GameName & ".", True)
        End If

    End Sub

    'Mapreport
    Sub Packet_MapReport(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida CMSG: CMapReport")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then Exit Sub

        SendMapReport(index)
    End Sub

    Sub Packet_Admin(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida CMSG: CAdmin")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then Exit Sub

        SendAdminPanel(index)
    End Sub

    Sub Packet_SetHotBarSlot(index As Integer, ByRef data() As Byte)
        Dim slot As Integer, skill As Integer, type As Byte
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CSetHotbarSlot")
#End If
        slot = buffer.ReadInt32
        skill = buffer.ReadInt32
        type = buffer.ReadInt32

        Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).Slot = skill
        Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).SlotType = type

        SendHotbar(index)

        buffer.Dispose()
    End Sub

    Sub Packet_DeleteHotBarSlot(index As Integer, ByRef data() As Byte)
        Dim slot As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CDeleteHotbarSlot")
#End If
        slot = buffer.ReadInt32

        Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).Slot = 0
        Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).SlotType = 0

        SendHotbar(index)

        buffer.Dispose()
    End Sub

    Sub Packet_UseHotBarSlot(index As Integer, ByRef data() As Byte)
        Dim slot As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CUseHotbarSlot")
#End If
        slot = buffer.ReadInt32
        buffer.Dispose()

        If Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).Slot > 0 Then
            If Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).SlotType = 1 Then 'habilidade
                BufferSkill(index, Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).Slot)
            ElseIf Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).SlotType = 2 Then 'item
                UseItem(index, Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).Slot)
            End If
        End If

        SendHotbar(index)

    End Sub

    Sub Packet_RequestClasses(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida CMSG: CRequestClasses")
#End If
        SendClasses(index)
    End Sub

    Sub Packet_RequestEditClasses(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida EMSG: RequestEditClasses")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub

        SendClasses(index)

        SendClassEditor(index)
    End Sub

    Sub Packet_SaveClasses(index As Integer, ByRef data() As Byte)
        Dim i As Integer, z As Integer, x As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida EMSG: SaveClasses")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub

        For i = 0 To Max_Classes
            ReDim Classes(i).Stat(StatType.Count - 1)
        Next

        For i = 1 To Max_Classes

            With Classes(i)
                .Name = buffer.ReadString
                .Desc = buffer.ReadString

                ' Pegar tamanho do vetor
                z = buffer.ReadInt32

                ' Redim vetor
                ReDim .MaleSprite(z)
                ' loop-receive data
                For x = 0 To z
                    .MaleSprite(x) = buffer.ReadInt32
                Next

                ' Pegar tamanho do vetor
                z = buffer.ReadInt32
                ' Redim Vetor
                ReDim .FemaleSprite(z)
                ' loop-receive data
                For x = 0 To z
                    .FemaleSprite(x) = buffer.ReadInt32
                Next

                .Stat(StatType.Strength) = buffer.ReadInt32
                .Stat(StatType.Endurance) = buffer.ReadInt32
                .Stat(StatType.Vitality) = buffer.ReadInt32
                .Stat(StatType.Intelligence) = buffer.ReadInt32
                .Stat(StatType.Luck) = buffer.ReadInt32
                .Stat(StatType.Spirit) = buffer.ReadInt32

                ReDim .StartItem(5)
                ReDim .StartValue(5)
                For q = 1 To 5
                    .StartItem(q) = buffer.ReadInt32
                    .StartValue(q) = buffer.ReadInt32
                Next

                .StartMap = buffer.ReadInt32
                .StartX = buffer.ReadInt32
                .StartY = buffer.ReadInt32

                .BaseExp = buffer.ReadInt32
            End With

        Next

        buffer.Dispose()

        SaveClasses()

        LoadClasses()

        SendClassesToAll()
    End Sub

    Private Sub Packet_EditorLogin(index As Integer, ByRef data() As Byte)
        Dim Name As String, Password As String, Version As String
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida EMSG: EditorLogin")
#End If
        If Not IsLoggedIn(index) Then

            ' Pegar o dado
            Name = EKeyPair.DecryptString(buffer.ReadString)
            Password = EKeyPair.DecryptString(buffer.ReadString)
            Version = EKeyPair.DecryptString(buffer.ReadString)

            ' Checar versões
            If Version <> Application.ProductVersion Then
                AlertMsg(index, "Versão desatualizada, visite " & Settings.Website, True)
                Exit Sub
            End If

            If Len(Trim$(Name)) < 3 OrElse Len(Trim$(Password)) < 3 Then
                AlertMsg(index, "Seu nome e seha devem ter pelo menos três caracteres de tamanho")
                Exit Sub
            End If

            If Not AccountExist(Name) Then
                AlertMsg(index, "Esse nome de conta não existe.")
                Exit Sub
            End If

            If Not PasswordOK(Name, Password) Then
                AlertMsg(index, "Senha incorreta.")
                Exit Sub
            End If

            If IsMultiAccounts(Name) Then
                AlertMsg(index, "Múltiplos logins de conta não autorizado.")
                Exit Sub
            End If

            ' Carregar o jogador
            LoadPlayer(index, Name)

            If GetPlayerAccess(index) > AdminType.Player Then
                SendEditorLoadOk(index)
                'SendMapData(index, 1, True)
                SendGameData(index)
                SendMapNames(index)
                SendProjectiles(index)
                SendQuests(index)
                SendRecipes(index)
                SendHouseConfigs(index)
                SendPets(index)
            Else
                AlertMsg(index, "Não autorizado.", True)
                Exit Sub
            End If

            ' Show the player up on the socket status
            Addlog(GetPlayerLogin(index) & " fez o login a partir do IP " & Socket.ClientIp(index) & ".", PLAYER_LOG)

            Console.WriteLine(GetPlayerLogin(index) & " fez o login a partir do IP " & Socket.ClientIp(index) & ".")

        End If

        buffer.Dispose()
    End Sub

    Private Sub Packet_EditorRequestMap(index As Integer, ByRef data() As Byte)
        Dim mapNum As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida EMSG: EditorRequestMap")
#End If
        mapNum = buffer.ReadInt32

        buffer.Dispose()

        If GetPlayerAccess(index) > AdminType.Player Then
            SendMapData(index, mapNum, True)
            SendMapNames(index)

            buffer = New ByteStream(4)
            buffer.WriteInt32(ServerPackets.SEditMap)
            Socket.SendDataTo(index, buffer.Data, buffer.Head)
#If DEBUG Then
            AddDebug("Enviada SMSG: SEditMap")
#End If
            buffer.Dispose()
        Else
            AlertMsg(index, "Não permitido!", True)
        End If

    End Sub

    Sub Packet_EditorMapData(index As Integer, ByRef data() As Byte)
        Dim i As Integer
        Dim mapNum As Integer
        Dim x As Integer
        Dim y As Integer
#If DEBUG Then
        AddDebug("Recebida EMSG: EditorSaveMap")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then Exit Sub

        Dim buffer As New ByteStream(Compression.DecompressBytes(data))

        Gettingmap = True

        mapNum = buffer.ReadInt32

        i = Map(mapNum).Revision + 1
        ClearMap(mapNum)

        Map(mapNum).Name = buffer.ReadString
        Map(mapNum).Music = buffer.ReadString
        Map(mapNum).Revision = i
        Map(mapNum).Moral = buffer.ReadInt32
        Map(mapNum).Tileset = buffer.ReadInt32
        Map(mapNum).Up = buffer.ReadInt32
        Map(mapNum).Down = buffer.ReadInt32
        Map(mapNum).Left = buffer.ReadInt32
        Map(mapNum).Right = buffer.ReadInt32
        Map(mapNum).BootMap = buffer.ReadInt32
        Map(mapNum).BootX = buffer.ReadInt32
        Map(mapNum).BootY = buffer.ReadInt32
        Map(mapNum).MaxX = buffer.ReadInt32
        Map(mapNum).MaxY = buffer.ReadInt32
        Map(mapNum).WeatherType = buffer.ReadInt32
        Map(mapNum).Fogindex = buffer.ReadInt32
        Map(mapNum).WeatherIntensity = buffer.ReadInt32
        Map(mapNum).FogAlpha = buffer.ReadInt32
        Map(mapNum).FogSpeed = buffer.ReadInt32
        Map(mapNum).HasMapTint = buffer.ReadInt32
        Map(mapNum).MapTintR = buffer.ReadInt32
        Map(mapNum).MapTintG = buffer.ReadInt32
        Map(mapNum).MapTintB = buffer.ReadInt32
        Map(mapNum).MapTintA = buffer.ReadInt32

        Map(mapNum).Instanced = buffer.ReadInt32
        Map(mapNum).Panorama = buffer.ReadInt32
        Map(mapNum).Parallax = buffer.ReadInt32

        ReDim Map(mapNum).Tile(Map(mapNum).MaxX, Map(mapNum).MaxY)

        For x = 1 To MAX_MAP_NPCS
            ClearMapNpc(x, mapNum)
            Map(mapNum).Npc(x) = buffer.ReadInt32
        Next

        With Map(mapNum)
            For x = 0 To .MaxX
                For y = 0 To .MaxY
                    .Tile(x, y).Data1 = buffer.ReadInt32
                    .Tile(x, y).Data2 = buffer.ReadInt32
                    .Tile(x, y).Data3 = buffer.ReadInt32
                    .Tile(x, y).DirBlock = buffer.ReadInt32
                    ReDim .Tile(x, y).Layer(LayerType.Count - 1)
                    For i = 0 To LayerType.Count - 1
                        .Tile(x, y).Layer(i).Tileset = buffer.ReadInt32
                        .Tile(x, y).Layer(i).X = buffer.ReadInt32
                        .Tile(x, y).Layer(i).Y = buffer.ReadInt32
                        .Tile(x, y).Layer(i).AutoTile = buffer.ReadInt32
                    Next
                    .Tile(x, y).Type = buffer.ReadInt32
                Next
            Next

        End With

        'Dados de Eventos!
        Map(mapNum).EventCount = buffer.ReadInt32

        If Map(mapNum).EventCount > 0 Then
            ReDim Map(mapNum).Events(Map(mapNum).EventCount)
            For i = 1 To Map(mapNum).EventCount
                With Map(mapNum).Events(i)
                    .Name = buffer.ReadString
                    .Globals = buffer.ReadInt32
                    .X = buffer.ReadInt32
                    .Y = buffer.ReadInt32
                    .PageCount = buffer.ReadInt32
                End With
                If Map(mapNum).Events(i).PageCount > 0 Then
                    ReDim Map(mapNum).Events(i).Pages(Map(mapNum).Events(i).PageCount)
                    ReDim TempPlayer(i).EventMap.EventPages(Map(mapNum).Events(i).PageCount)
                    For x = 1 To Map(mapNum).Events(i).PageCount
                        With Map(mapNum).Events(i).Pages(x)
                            .ChkVariable = buffer.ReadInt32
                            .Variableindex = buffer.ReadInt32
                            .VariableCondition = buffer.ReadInt32
                            .VariableCompare = buffer.ReadInt32

                            Map(mapNum).Events(i).Pages(x).ChkSwitch = buffer.ReadInt32
                            Map(mapNum).Events(i).Pages(x).Switchindex = buffer.ReadInt32
                            .SwitchCompare = buffer.ReadInt32

                            .ChkHasItem = buffer.ReadInt32
                            .HasItemindex = buffer.ReadInt32
                            .HasItemAmount = buffer.ReadInt32

                            .ChkSelfSwitch = buffer.ReadInt32
                            .SelfSwitchindex = buffer.ReadInt32
                            .SelfSwitchCompare = buffer.ReadInt32

                            .GraphicType = buffer.ReadInt32
                            .Graphic = buffer.ReadInt32
                            .GraphicX = buffer.ReadInt32
                            .GraphicY = buffer.ReadInt32
                            .GraphicX2 = buffer.ReadInt32
                            .GraphicY2 = buffer.ReadInt32

                            .MoveType = buffer.ReadInt32
                            .MoveSpeed = buffer.ReadInt32
                            .MoveFreq = buffer.ReadInt32

                            .MoveRouteCount = buffer.ReadInt32

                            .IgnoreMoveRoute = buffer.ReadInt32
                            .RepeatMoveRoute = buffer.ReadInt32

                            If .MoveRouteCount > 0 Then
                                ReDim Map(mapNum).Events(i).Pages(x).MoveRoute(.MoveRouteCount)
                                For y = 1 To .MoveRouteCount
                                    .MoveRoute(y).Index = buffer.ReadInt32
                                    .MoveRoute(y).Data1 = buffer.ReadInt32
                                    .MoveRoute(y).Data2 = buffer.ReadInt32
                                    .MoveRoute(y).Data3 = buffer.ReadInt32
                                    .MoveRoute(y).Data4 = buffer.ReadInt32
                                    .MoveRoute(y).Data5 = buffer.ReadInt32
                                    .MoveRoute(y).Data6 = buffer.ReadInt32
                                Next
                            End If

                            .WalkAnim = buffer.ReadInt32
                            .DirFix = buffer.ReadInt32
                            .WalkThrough = buffer.ReadInt32
                            .ShowName = buffer.ReadInt32
                            .Trigger = buffer.ReadInt32
                            .CommandListCount = buffer.ReadInt32

                            .Position = buffer.ReadInt32
                            .QuestNum = buffer.ReadInt32

                            .ChkPlayerGender = buffer.ReadInt32
                        End With

                        If Map(mapNum).Events(i).Pages(x).CommandListCount > 0 Then
                            ReDim Map(mapNum).Events(i).Pages(x).CommandList(Map(mapNum).Events(i).Pages(x).CommandListCount)
                            For y = 1 To Map(mapNum).Events(i).Pages(x).CommandListCount
                                Map(mapNum).Events(i).Pages(x).CommandList(y).CommandCount = buffer.ReadInt32
                                Map(mapNum).Events(i).Pages(x).CommandList(y).ParentList = buffer.ReadInt32
                                If Map(mapNum).Events(i).Pages(x).CommandList(y).CommandCount > 0 Then
                                    ReDim Map(mapNum).Events(i).Pages(x).CommandList(y).Commands(Map(mapNum).Events(i).Pages(x).CommandList(y).CommandCount)
                                    For z = 1 To Map(mapNum).Events(i).Pages(x).CommandList(y).CommandCount
                                        With Map(mapNum).Events(i).Pages(x).CommandList(y).Commands(z)
                                            .Index = buffer.ReadInt32
                                            .Text1 = buffer.ReadString
                                            .Text2 = buffer.ReadString
                                            .Text3 = buffer.ReadString
                                            .Text4 = buffer.ReadString
                                            .Text5 = buffer.ReadString
                                            .Data1 = buffer.ReadInt32
                                            .Data2 = buffer.ReadInt32
                                            .Data3 = buffer.ReadInt32
                                            .Data4 = buffer.ReadInt32
                                            .Data5 = buffer.ReadInt32
                                            .Data6 = buffer.ReadInt32
                                            .ConditionalBranch.CommandList = buffer.ReadInt32
                                            .ConditionalBranch.Condition = buffer.ReadInt32
                                            .ConditionalBranch.Data1 = buffer.ReadInt32
                                            .ConditionalBranch.Data2 = buffer.ReadInt32
                                            .ConditionalBranch.Data3 = buffer.ReadInt32
                                            .ConditionalBranch.ElseCommandList = buffer.ReadInt32
                                            .MoveRouteCount = buffer.ReadInt32
                                            Dim tmpcount As Integer = .MoveRouteCount
                                            If tmpcount > 0 Then
                                                ReDim Preserve .MoveRoute(tmpcount)
                                                For w = 1 To tmpcount
                                                    .MoveRoute(w).Index = buffer.ReadInt32
                                                    .MoveRoute(w).Data1 = buffer.ReadInt32
                                                    .MoveRoute(w).Data2 = buffer.ReadInt32
                                                    .MoveRoute(w).Data3 = buffer.ReadInt32
                                                    .MoveRoute(w).Data4 = buffer.ReadInt32
                                                    .MoveRoute(w).Data5 = buffer.ReadInt32
                                                    .MoveRoute(w).Data6 = buffer.ReadInt32
                                                Next
                                            End If
                                        End With
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        End If
        'Fim dos Dados de Evntos

        ' Salvar o mapa
        SaveMap(mapNum)

        SaveMapEvent(mapNum)

        Gettingmap = False

        SendMapNpcsToMap(mapNum)
        SpawnMapNpcs(mapNum)
        SpawnGlobalEvents(mapNum)

        For i = 1 To GetPlayersOnline()
            If IsPlaying(i) Then
                If Player(i).Character(TempPlayer(i).CurChar).Map = mapNum Then
                    SpawnMapEventsFor(i, mapNum)
                End If
            End If
        Next

        ' Clear out it all
        For i = 1 To MAX_MAP_ITEMS
            SpawnItemSlot(i, 0, 0, GetPlayerMap(index), MapItem(GetPlayerMap(index), i).X, MapItem(GetPlayerMap(index), i).Y)
            ClearMapItem(i, GetPlayerMap(index))
        Next

        ' Respawn
        SpawnMapItems(mapNum)

        ClearTempTile(mapNum)
        CacheResources(mapNum)

        ' Atualizar mapa para todos online
        For i = 1 To GetPlayersOnline()
            If IsPlaying(i) AndAlso GetPlayerMap(i) = mapNum Then
                PlayerWarp(i, mapNum, GetPlayerX(i), GetPlayerY(i))
                ' Enviar
                SendMapData(i, mapNum, True)
            End If
        Next

        SendMapData(index, mapNum, True)
        SendMapNames(index)

        buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SEditMap)
        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Private Sub Packet_Emote(index As Integer, ByRef data() As Byte)
        Dim Emote As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CEmote")
#End If
        Emote = buffer.ReadInt32

        SendEmote(index, Emote)

        buffer.Dispose()
    End Sub

End Module