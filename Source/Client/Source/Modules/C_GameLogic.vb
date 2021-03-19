﻿Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms
Imports ASFW

Module C_GameLogic
    Friend GameRand As New Random()

    Sub GameLoop()
        Dim i As Integer
        Dim dest As Point = New Point(FrmGame.PointToScreen(FrmGame.picscreen.Location))
        Dim g As Graphics = FrmGame.picscreen.CreateGraphics
        Dim starttime As Integer, tick As Integer, fogtmr As Integer
        Dim tmpfps As Integer, tmplps As Integer, walkTimer As Integer, frameTime As Integer
        Dim tmr10000 As Integer, tmr1000 As Integer, tmrweather As Integer
        Dim tmr100 As Integer, tmr500 As Integer, tmrconnect As Integer
        Dim rendercount As Integer, fadetmr As Integer

        starttime = GetTickCount()
        FrmMenu.lblNextChar.Left = Lblnextcharleft

        Do
            If GameDestroyed Then End

            DirDown = VbKeyDown
            DirUp = VbKeyUp
            DirLeft = VbKeyLeft
            DirRight = VbKeyRight

            If Frmmenuvisible = True Then
                If tmrconnect < GetTickCount() Then
                    If Socket.IsConnected() = True Then
                        FrmMenu.lblServerStatus.ForeColor = Color.LightGreen
                        FrmMenu.lblServerStatus.Text = Language.MainMenu.ServerOnline
                    Else
                        i = i + 1
                        If i = 5 Then
                            Connect()
                            FrmMenu.lblServerStatus.Text = Language.MainMenu.ServerReconnect
                            FrmMenu.lblServerStatus.ForeColor = Color.Orange
                            i = 0
                        Else
                            FrmMenu.lblServerStatus.Text = Language.MainMenu.ServerOffline
                            FrmMenu.lblServerStatus.ForeColor = Color.Red
                        End If
                    End If
                    tmrconnect = GetTickCount() + 500
                End If
            End If

            'Atualizar a UI
            UpdateUi()

            If GameStarted() = True Then
                tick = GetTickCount()
                ElapsedTime = tick - frameTime ' Setar a diferença de tempo para movimentos baseados em tempo

                frameTime = tick
                Frmmaingamevisible = True

                'Calcular FPS
                If starttime < tick Then
                    Fps = tmpfps
                    Lps = tmplps
                    tmpfps = 0
                    tmplps = 0
                    starttime = tick + 1000
                End If
                tmplps = tmplps + 1
                tmpfps = tmpfps + 1

                ' Atualizar animação de inventário
                If NumItems > 0 Then
                    If tmr100 < tick Then

                        If InBank Then DrawBank()
                        If InShop Then DrawShop()
                        If InTrade Then DrawTrade()

                        tmr100 = tick + 100
                    End If
                End If

                If ShowAnimTimer < tick Then
                    ShowAnimLayers = Not ShowAnimLayers
                    ShowAnimTimer = tick + 500
                End If

                For i = 1 To Byte.MaxValue
                    CheckAnimInstance(i)
                Next

                If tick > EventChatTimer Then
                    If EventText = "" Then
                        If EventChat = True Then
                            EventChat = False
                            PnlEventChatVisible = False
                        End If
                    End If
                End If

                If tmr10000 < tick Then
                    If Settings.HighEnd = 0 Then
                        'limpar qualquer gráfico nao usado
                        ClearGfx()
                    End If

                    GetPing()
                    DrawPing()

                    tmr10000 = tick + 10000
                End If

                If tmr1000 < tick Then
                    Time.Instance.Tick()

                    tmr1000 = tick + 1000
                End If

                'temporizador de artesanato
                If CraftTimerEnabled Then
                    If CraftTimer < tick Then
                        CraftProgressValue = CraftProgressValue + (100 / Recipe(GetRecipeIndex(RecipeNames(SelectedRecipe))).CreateTime)

                        If CraftProgressValue >= 100 Then
                            CraftTimerEnabled = False
                        End If
                        CraftTimer = tick + 1000
                    End If
                End If

                'temporizador de chacoalhaento d tela
                If ShakeTimerEnabled Then
                    If ShakeTimer < tick Then
                        If ShakeCount < 10 Then
                            If LastDir = 0 Then
                                FrmGame.picscreen.Location = New Point(FrmGame.picscreen.Location.X + 20, FrmGame.picscreen.Location.Y)
                                LastDir = 1
                            Else
                                FrmGame.picscreen.Location = New Point(FrmGame.picscreen.Location.X - 20, FrmGame.picscreen.Location.Y)
                                LastDir = 0
                            End If
                        Else
                            FrmGame.picscreen.Location = New Point(0, 0)
                            ShakeCount = 0
                            ShakeTimerEnabled = False
                        End If

                        ShakeCount += 1

                        ShakeTimer = tick + 50
                    End If
                End If

                ' ver se a troca deu timeout
                If TradeRequest = True Then
                    If TradeTimer < tick Then
                        AddText(Language.Trade.Timeout, ColorType.Yellow)
                        TradeRequest = False
                        TradeTimer = 0
                    End If
                End If

                ' ver se precisamos encerrar o ícone de CD
                If NumSkillIcons > 0 Then
                    For i = 1 To MAX_PLAYER_SKILLS
                        If PlayerSkills(i) > 0 Then
                            If SkillCd(i) > 0 Then
                                If SkillCd(i) + (Skill(PlayerSkills(i)).CdTime * 1000) < tick Then
                                    SkillCd(i) = 0
                                    DrawPlayerSkills()
                                End If
                            End If
                        End If
                    Next
                End If

                ' ver se precisamso destravar as restrições de habilidades do jogador 
                If SkillBuffer > 0 Then
                    If SkillBufferTimer + (Skill(PlayerSkills(SkillBuffer)).CastTime * 1000) < tick Then
                        SkillBuffer = 0
                        SkillBufferTimer = 0
                    End If
                End If
                ' ver se precisamso destravar as restrições de habilidades do pet 
                If PetSkillBuffer > 0 Then
                    If PetSkillBufferTimer + (Skill(Pet(Player(Myindex).Pet.Num).Skill(PetSkillBuffer)).CastTime * 1000) < tick Then
                        PetSkillBuffer = 0
                        PetSkillBufferTimer = 0
                    End If
                End If

                SyncLock MapLock
                    If CanMoveNow Then
                        CheckMovement() ' Ver se o jogador está tentando mover
                        CheckAttack()   ' Ver se o jogador está tentando atacar
                    End If

                    ' Processar entradas antes de renderizar
                    If walkTimer < tick Then

                        For i = 1 To TotalOnline 'MAX_PLAYERS
                            If IsPlaying(i) Then
                                ProcessMovement(i)
                                If PetAlive(i) Then
                                    ProcessPetMovement(i)
                                End If
                            End If
                        Next

                        ' Processar movimentos dos NPCs (move-los, na verdade)
                        For i = 1 To MAX_MAP_NPCS
                            If Map.Npc(i) > 0 Then
                                ProcessNpcMovement(i)
                            End If
                        Next i

                        If Map.CurrentEvents > 0 Then
                            For i = 1 To Map.CurrentEvents
                                ProcessEventMovement(i)
                            Next i
                        End If

                        walkTimer = tick + 30 ' editar este valor para alterar WalkTimer
                    End If

                    ' scroolling de nevoa
                    If fogtmr < tick Then
                        If CurrentFogSpeed > 0 Then
                            ' mover
                            FogOffsetX = FogOffsetX - 1
                            FogOffsetY = FogOffsetY - 1
                            ' resetar
                            If FogOffsetX < -255 Then FogOffsetX = 1
                            If FogOffsetY < -255 Then FogOffsetY = 1
                            fogtmr = tick + 255 - CurrentFogSpeed
                        End If
                    End If

                    If tmr500 < tick Then
                        ' animar cachoeiras
                        Select Case WaterfallFrame
                            Case 0
                                WaterfallFrame = 1
                            Case 1
                                WaterfallFrame = 2
                            Case 2
                                WaterfallFrame = 0
                        End Select
                        ' animar autotiles
                        Select Case AutoTileFrame
                            Case 0
                                AutoTileFrame = 1
                            Case 1
                                AutoTileFrame = 2
                            Case 2
                                AutoTileFrame = 0
                        End Select

                        tmr500 = tick + 500
                    End If

                    If FadeInSwitch = True Then
                        FadeIn()
                    End If

                    If FadeOutSwitch = True Then
                        FadeOut()
                    End If

                    If InMapEditor Then FrmEditor_MapEditor.EditorMap_DrawTileset()

                    Application.DoEvents()

                    If GettingMap Then
                        Dim font As New Font(Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\" + FontName, FontSize)
                        g.DrawString(Language.Game.MapReceive, font, Brushes.DarkCyan, FrmGame.picscreen.Width - 130, 5)
                    End If

                End SyncLock
            End If

            If tmrweather < tick Then
                ProcessWeather()
                tmrweather = tick + 50
            End If

            If fadetmr < tick Then
                If FadeType <> 2 Then
                    If FadeType = 1 Then
                        If FadeAmount = 255 Then
                        Else
                            FadeAmount = FadeAmount + 5
                        End If
                    ElseIf FadeType = 0 Then
                        If FadeAmount = 0 Then
                            UseFade = False
                        Else
                            FadeAmount = FadeAmount - 5
                        End If
                    End If
                End If
                fadetmr = tick + 30
            End If

            If rendercount < tick Then
                'Coisas do GameLoop
                Render_Graphics()
                tmplps = tmplps + 1
                rendercount = tick + 16
            End If

            Application.DoEvents()

            If Settings.HighEnd = 1 Then
                Thread.Yield()
            Else
                Thread.Sleep(1)
            End If

        Loop
    End Sub

    Sub ClearTempTile()
        Dim x As Integer
        Dim y As Integer
        ReDim TempTile(Map.MaxX, Map.MaxY)

        For x = 0 To Map.MaxX
            For y = 0 To Map.MaxY
                TempTile(x, y).DoorOpen = 0
            Next
        Next

    End Sub

    Sub ProcessNpcMovement(mapNpcNum As Integer)

        ' Ver se o NPC está andando, e se sim processar o movimento 
        If MapNpc(mapNpcNum).Moving = MovementType.Walking Then

            Select Case MapNpc(mapNpcNum).Dir
                Case DirectionType.Up
                    MapNpc(mapNpcNum).YOffset = MapNpc(mapNpcNum).YOffset - ((ElapsedTime / 1000) * (WalkSpeed * SizeX))
                    If MapNpc(mapNpcNum).YOffset < 0 Then MapNpc(mapNpcNum).YOffset = 0

                Case DirectionType.Down
                    MapNpc(mapNpcNum).YOffset = MapNpc(mapNpcNum).YOffset + ((ElapsedTime / 1000) * (WalkSpeed * SizeX))
                    If MapNpc(mapNpcNum).YOffset > 0 Then MapNpc(mapNpcNum).YOffset = 0

                Case DirectionType.Left
                    MapNpc(mapNpcNum).XOffset = MapNpc(mapNpcNum).XOffset - ((ElapsedTime / 1000) * (WalkSpeed * SizeX))
                    If MapNpc(mapNpcNum).XOffset < 0 Then MapNpc(mapNpcNum).XOffset = 0

                Case DirectionType.Right
                    MapNpc(mapNpcNum).XOffset = MapNpc(mapNpcNum).XOffset + ((ElapsedTime / 1000) * (WalkSpeed * SizeX))
                    If MapNpc(mapNpcNum).XOffset > 0 Then MapNpc(mapNpcNum).XOffset = 0

            End Select

            ' Ver se terminou de andar para a próxima tile
            If MapNpc(mapNpcNum).Moving > 0 Then
                If MapNpc(mapNpcNum).Dir = DirectionType.Right OrElse MapNpc(mapNpcNum).Dir = DirectionType.Down Then
                    If (MapNpc(mapNpcNum).XOffset >= 0) AndAlso (MapNpc(mapNpcNum).YOffset >= 0) Then
                        MapNpc(mapNpcNum).Moving = 0
                        If MapNpc(mapNpcNum).Steps = 1 Then
                            MapNpc(mapNpcNum).Steps = 3
                        Else
                            MapNpc(mapNpcNum).Steps = 1
                        End If
                    End If
                Else
                    If (MapNpc(mapNpcNum).XOffset <= 0) AndAlso (MapNpc(mapNpcNum).YOffset <= 0) Then
                        MapNpc(mapNpcNum).Moving = 0
                        If MapNpc(mapNpcNum).Steps = 1 Then
                            MapNpc(mapNpcNum).Steps = 3
                        Else
                            MapNpc(mapNpcNum).Steps = 1
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Sub DrawPing()

        PingToDraw = Ping

        Select Case Ping
            Case -1
                PingToDraw = Language.Game.PingSync
            Case 0 To 5
                PingToDraw = Language.Game.PingLocal
        End Select

    End Sub

    Friend Function IsInBounds()
        IsInBounds = False

        If (CurX >= 0) AndAlso (CurX <= Map.MaxX) Then
            If (CurY >= 0) AndAlso (CurY <= Map.MaxY) Then
                IsInBounds = True
            End If
        End If

    End Function

    Function GameStarted() As Boolean
        GameStarted = False
        If InGame = False Then Exit Function
        If MapData = False Then Exit Function
        If PlayerData = False Then Exit Function
        GameStarted = True
        Pnlloadvisible = False
    End Function

    Friend Sub CreateActionMsg(message As String, color As Integer, msgType As Byte, x As Integer, y As Integer)

        ActionMsgIndex = ActionMsgIndex + 1
        If ActionMsgIndex >= Byte.MaxValue Then ActionMsgIndex = 1

        With ActionMsg(ActionMsgIndex)
            .Message = message
            .Color = color
            .Type = msgType
            .Created = GetTickCount()
            .Scroll = 1
            .X = x
            .Y = y
        End With

        If ActionMsg(ActionMsgIndex).Type = ActionMsgType.Scroll Then
            ActionMsg(ActionMsgIndex).Y = ActionMsg(ActionMsgIndex).Y + Rand(-2, 6)
            ActionMsg(ActionMsgIndex).X = ActionMsg(ActionMsgIndex).X + Rand(-8, 8)
        End If

    End Sub

    Friend Function Rand(maxNumber As Integer, Optional minNumber As Integer = 0) As Integer
        If minNumber > maxNumber Then
            Dim t As Integer = minNumber
            minNumber = maxNumber
            maxNumber = t
        End If

        Return GameRand.Next(minNumber, maxNumber)
    End Function

    ' Operadores BitWise para bloqueamento direcional
    Friend Sub SetDirBlock(ByRef blockvar As Byte, ByRef dir As Byte, block As Boolean)
        If block Then
            blockvar = blockvar Or (2 ^ dir)
        Else
            blockvar = blockvar And Not (2 ^ dir)
        End If
    End Sub

    Friend Function IsDirBlocked(ByRef blockvar As Byte, ByRef dir As Byte) As Boolean
        Return Not (Not blockvar AndAlso (2 ^ dir))
    End Function

    Friend Function ConvertCurrency(amount As Integer) As String

        If Int(amount) < 10000 Then
            ConvertCurrency = amount
        ElseIf Int(amount) < 999999 Then
            ConvertCurrency = Int(amount / 1000) & "k"
        ElseIf Int(amount) < 999999999 Then
            ConvertCurrency = Int(amount / 1000000) & "m"
        Else
            ConvertCurrency = Int(amount / 1000000000) & "b"
        End If

    End Function

    Sub HandlePressEnter()
        Dim chatText As String
        Dim name As String
        Dim i As Integer
        Dim n As Integer
        Dim command() As String
        Dim buffer As ByteStream
        chatText = Trim$(ChatInput.CurrentMessage)
        name = ""

        If Len(chatText) = 0 Then Exit Sub
        ChatInput.CurrentMessage = LCase$(chatText)

        If EventChat = True Then
            If EventChatType = 0 Then
                buffer = New ByteStream(4)
                buffer.WriteInt32(ClientPackets.CEventChatReply)
                buffer.WriteInt32(EventReplyId)
                buffer.WriteInt32(EventReplyPage)
                buffer.WriteInt32(0)
                Socket.SendData(buffer.Data, buffer.Head)
                buffer.Dispose()
                ClearEventChat()
                InEvent = False
                Exit Sub
            End If
        End If

        ' Mandar mensagem
        If Left$(chatText, 1) = "'" Then
            chatText = Mid$(chatText, 2, Len(chatText) - 1)

            If Len(chatText) > 0 Then
                BroadcastMsg(chatText)
            End If

            ChatInput.CurrentMessage = ""
            Exit Sub
        End If

        ' mensagem de equipe
        If Left$(chatText, 1) = "-" Then
            ChatInput.CurrentMessage = Mid$(chatText, 2, Len(chatText) - 1)

            If Len(chatText) > 0 Then
                SendPartyChatMsg(ChatInput.CurrentMessage)
            End If

            ChatInput.CurrentMessage = ""
            Exit Sub
        End If

        ' Mensagem do jogador
        If Left$(chatText, 1) = "!" Then
            chatText = Mid$(chatText, 2, Len(chatText) - 1)
            name = ""

            ' Pegar o jogador desejado a partir do texto 
            For i = 1 To Len(chatText)

                If Mid$(chatText, i, 1) <> Space(1) Then
                    name = name & Mid$(chatText, i, 1)
                Else
                    Exit For
                End If

            Next

            ChatInput.CurrentMessage = Trim$(Mid$(chatText, i, Len(chatText) - 1))

            ' Ter certeza que estao enviando algo
            If Len(ChatInput.CurrentMessage) > 0 Then
                ' Enviar a mensagem ao jogador
                PlayerMsg(ChatInput.CurrentMessage, name)
            Else
                AddText(Language.Chat.PlayerMsg, ColorType.Yellow)
            End If

            GoTo Continue1
        End If

        If Left$(ChatInput.CurrentMessage, 1) = "/" Then
            command = Split(ChatInput.CurrentMessage, Space(1))

            Select Case command(0)
                Case "/emote"
                    ' Ver se temos mais que uma string no vetor
                    If UBound(command) < 1 OrElse Not IsNumeric(command(1)) Then
                        AddText(Language.Chat.Emote, ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendUseEmote(command(1))

                Case "/ajuda"
                    AddText(Language.Chat.Help1, ColorType.Yellow)
                    AddText(Language.Chat.Help2, ColorType.Yellow)
                    AddText(Language.Chat.Help3, ColorType.Yellow)
                    AddText(Language.Chat.Help4, ColorType.Yellow)
                    AddText(Language.Chat.Help5, ColorType.Yellow)

                Case "/convidarmoradia"

                    ' Ter certeza que tem mais de uma string no vetor
                    If UBound(command) < 1 OrElse IsNumeric(command(1)) Then
                        AddText(Language.Chat.HouseInvite, ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendInvite(command(1))

                Case "/vendermoradia"
                    buffer = New ByteStream(4)
                    buffer.WriteInt32(ClientPackets.CSellHouse)
                    Socket.SendData(buffer.Data, buffer.Head)
                    buffer.Dispose()
                Case "/info"

                    ' Ter certeza que temos mais de uma string no vetor
                    If UBound(command) < 1 OrElse IsNumeric(command(1)) Then
                        AddText(Language.Chat.Info, ColorType.Yellow)
                        GoTo Continue1
                    End If

                    buffer = New ByteStream(4)
                    buffer.WriteInt32(ClientPackets.CPlayerInfoRequest)
                    buffer.WriteString((command(1)))
                    Socket.SendData(buffer.Data, buffer.Head)
                    buffer.Dispose()
                ' Quem está online
                Case "/quem"
                    SendWhosOnline()
                ' Ver fps
                Case "/fps"
                    Bfps = Not Bfps
                Case "/lps"
                    Blps = Not Blps
                ' Pedir atributos
                Case "/atributos"
                    buffer = New ByteStream(4)
                    buffer.WriteInt32(ClientPackets.CGetStats)
                    Socket.SendData(buffer.Data, buffer.Head)
                    buffer.Dispose()
                Case "/equipe"
                    ' Ter certeza que estao enviando algo
                    If UBound(command) < 1 OrElse IsNumeric(command(1)) Then
                        AddText(Language.Chat.Party, ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendPartyRequest(command(1))

                ' Entrar em equipe
                Case "/entrar"
                    SendAcceptParty()
                ' Leave party
                Case "/sair"
                    SendLeaveParty()

                'soltar
                Case "/soltarpet"
                    SendReleasePet()

                ' // Comandos de Monitor //

                Case "/resetartarefa"
                    If GetPlayerAccess(Myindex) < AdminType.Mapper Then
                        AddText(Language.Chat.AccessAlert, QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(command) < 1 OrElse Not IsNumeric(command(1)) Then
                        AddText(Language.Chat.ResetQuest, ColorType.Yellow)
                        GoTo Continue1
                    End If

                    n = command(1)

                    ' Ter certeza que é um numero de mapa válido
                    If n > 0 AndAlso n <= MaxQuests Then
                        QuestReset(n)
                    Else
                        AddText(Language.Chat.InvalidQuest, QColorType.AlertColor)
                    End If

                ' Ajuda de admin
                Case "/admin"

                    If GetPlayerAccess(Myindex) < AdminType.Monitor Then
                        AddText(Language.Chat.AccessAlert, QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    AddText(Language.Chat.Admin1, ColorType.Yellow)
                    AddText(Language.Chat.Admin2, ColorType.Yellow)
                    AddText(Language.Chat.AdminGblMsg, ColorType.Yellow)
                    AddText(Language.Chat.AdminPvtMsg, ColorType.Yellow)
                ' Chutar jogador
                Case "/chutar"

                    If GetPlayerAccess(Myindex) < AdminType.Monitor Then
                        AddText(Language.Chat.AccessAlert, QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(command) < 1 OrElse IsNumeric(command(1)) Then
                        AddText(Language.Chat.Kick, ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendKick(command(1))
					
                ' // Comandos de Mapeador //
                ' Localização
                Case "/loc"

                    If GetPlayerAccess(Myindex) < AdminType.Mapper Then
                        AddText(Language.Chat.AccessAlert, QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    BLoc = Not BLoc
                ' Teleporte para o jogador
                Case "/melevarpara"

                    If GetPlayerAccess(Myindex) < AdminType.Mapper Then
                        AddText(Language.Chat.AccessAlert, QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(command) < 1 OrElse IsNumeric(command(1)) Then
                        AddText(Language.Chat.WarpMeTo, ColorType.Yellow)
                        GoTo Continue1
                    End If

                    WarpMeTo(command(1))
                ' Trazer um jogador a voce
                Case "/metraga"

                    If GetPlayerAccess(Myindex) < AdminType.Mapper Then
                        AddText(Language.Chat.AccessAlert, QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(command) < 1 OrElse IsNumeric(command(1)) Then
                        AddText(Language.Chat.WarpToMe, ColorType.Yellow)
                        GoTo Continue1
                    End If

                    WarpToMe(command(1))
                ' IR para um mapa
                Case "/irpara"

                    If GetPlayerAccess(Myindex) < AdminType.Mapper Then
                        AddText(Language.Chat.AccessAlert, QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(command) < 1 OrElse Not IsNumeric(command(1)) Then
                        AddText(Language.Chat.WarpTo, ColorType.Yellow)
                        GoTo Continue1
                    End If

                    n = command(1)

                    ' Ter certeza que é um mapa válido
                    If n > 0 AndAlso n <= MAX_MAPS Then
                        WarpTo(n)
                    Else
                        AddText(Language.Chat.InvalidMap, QColorType.AlertColor)
                    End If

                ' Setar sprite
                Case "/sprite"

                    If GetPlayerAccess(Myindex) < AdminType.Mapper Then
                        AddText(Language.Chat.AccessAlert, QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(command) < 1 OrElse Not IsNumeric(command(1)) Then
                        AddText(Language.Chat.Sprite, ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendSetSprite(command(1))
                ' Map report
                Case "/mapreport"

                    If GetPlayerAccess(Myindex) < AdminType.Mapper Then
                        AddText(Language.Chat.AccessAlert, QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    SendRequestMapreport()
                ' Regerar requests
                Case "/respawn"

                    If GetPlayerAccess(Myindex) < AdminType.Mapper Then
                        AddText(Language.Chat.AccessAlert, QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    SendMapRespawn()
                ' Mudar boas-vindas
                Case "/boasvindas"

                    If GetPlayerAccess(Myindex) < AdminType.Mapper Then
                        AddText(Language.Chat.AccessAlert, QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(command) < 1 Then
                        AddText(Language.Chat.Welcome, ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendMotdChange(Right$(chatText, Len(chatText) - 5))
                ' Mandar a lista de bans
                Case "/banlist"

                    If GetPlayerAccess(Myindex) < AdminType.Mapper Then
                        AddText(Language.Chat.AccessAlert, QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    SendBanList()
                ' Banir jogador
                Case "/banir"

                    If GetPlayerAccess(Myindex) < AdminType.Mapper Then
                        AddText(Language.Chat.AccessAlert, QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(command) < 1 Then
                        AddText(Language.Chat.Ban, ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendBan(command(1))
                ' // Comandos do Desenvolvedor //

                ' // Comandos do Criador //
                ' Dar acesso a outro jogador
                Case "/acesso"

                    If GetPlayerAccess(Myindex) < AdminType.Creator Then
                        AddText(Language.Chat.AccessAlert, QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(command) < 2 OrElse
                        IsNumeric(command(1)) OrElse
                        Not IsNumeric(command(2)) Then
                        AddText(Language.Chat.Access, ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendSetAccess(command(1), CLng(command(2)))
                Case Else
                    AddText(Language.Chat.InvalidCmd, QColorType.AlertColor)
            End Select

        ElseIf Len(chatText) > 0 Then
            SayMsg(chatText)
        End If

Continue1:
        ChatInput.CurrentMessage = ""
    End Sub

    Sub CheckMapGetItem()
        Dim buffer As New ByteStream(4)
        buffer = New ByteStream(4)

        If GetTickCount() > Player(Myindex).MapGetTimer + 250 Then
            If Trim$(ChatInput.CurrentMessage) = "" Then
                Player(Myindex).MapGetTimer = GetTickCount()
                buffer.WriteInt32(ClientPackets.CMapGetItem)
                Socket.SendData(buffer.Data, buffer.Head)
            End If
        End If

        buffer.Dispose()
    End Sub


    Friend Sub UpdateDescWindow(itemnum As Integer, amount As Integer, invNum As Integer, windowType As Byte)
        Dim theName As String = "", tmpRarity As Integer

        If Item(itemnum).Randomize <> 0 AndAlso invNum <> 0 Then
            If windowType = 0 Then ' inventario
                theName = GetItemName(PlayerInv(invNum))
                tmpRarity = PlayerInv(invNum).Rarity
            ElseIf windowType = 1 Then ' equips
                theName = GetItemName(Player(Myindex).Equipment(invNum))
                tmpRarity = Player(Myindex).Equipment(invNum).Rarity
            ElseIf windowType = 2 Then ' banco
                theName = GetItemName(Bank.Item(invNum))
                tmpRarity = Bank.Item(invNum).Rarity
            ElseIf windowType = 3 Then ' loja
                theName = GetItemName(Player(Myindex).Equipment(invNum))
                tmpRarity = Player(Myindex).Equipment(invNum).Rarity
            ElseIf windowType = 4 Then ' troca
                theName = GetItemName(Player(Myindex).Equipment(invNum))
                tmpRarity = Player(Myindex).Equipment(invNum).Rarity
            End If
        Else
            theName = Trim$(Item(itemnum).Name)
            tmpRarity = Item(itemnum).Rarity
        End If

        ItemDescName = theName

        ItemDescItemNum = itemnum

        If LastItemDesc = itemnum Then Exit Sub

        ' setar o nome
        Select Case tmpRarity
            Case 0 ' Brabco
                ItemDescRarityColor = ItemRarityColor0
                ItemDescRarityBackColor = SFML.Graphics.Color.Black
            Case 1 ' Verde
                ItemDescRarityColor = ItemRarityColor1
                ItemDescRarityBackColor = SFML.Graphics.Color.Black
            Case 2 ' Azul
                ItemDescRarityColor = ItemRarityColor2
                ItemDescRarityBackColor = SFML.Graphics.Color.Black
            Case 3 ' Vermelho
                ItemDescRarityColor = ItemRarityColor3
                ItemDescRarityBackColor = SFML.Graphics.Color.Black
            Case 4 ' Purpura
                ItemDescRarityColor = ItemRarityColor4
                ItemDescRarityBackColor = SFML.Graphics.Color.Black
            Case 5 'Dourado
                ItemDescRarityColor = ItemRarityColor5
                ItemDescRarityBackColor = SFML.Graphics.Color.Black
        End Select

        ItemDescDescription = Item(itemnum).Description

        ' Para os atributos
        Select Case Item(itemnum).Type
            Case ItemType.None
                ItemDescInfo = Language.ItemDescription.NotAvailable
                ItemDescType = Language.ItemDescription.NotAvailable

            Case ItemType.Equipment
                Select Case Item(itemnum).SubType

                    Case EquipmentType.Weapon
                        If Item(itemnum).Randomize <> 0 Then
                            If windowType = 0 Then
                                ItemDescInfo = Language.ItemDescription.Damage &
                                    PlayerInv(invNum).Damage
                            Else
                                ItemDescInfo = Language.ItemDescription.Damage &
                                    Player(Myindex).Equipment(invNum).Damage
                            End If
                        Else
                            ItemDescInfo = Language.ItemDescription.Damage & Item(itemnum).Data2
                        End If
                        ItemDescType = Language.ItemDescription.Weapon
                    Case EquipmentType.Armor
                        ItemDescInfo = Language.ItemDescription.Defense & Item(itemnum).Data2
                        ItemDescType = Language.ItemDescription.Armor
                    Case EquipmentType.Helmet
                        ItemDescInfo = Language.ItemDescription.Defense & Item(itemnum).Data2
                        ItemDescType = Language.ItemDescription.Helmet
                    Case EquipmentType.Shield
                        ItemDescInfo = Language.ItemDescription.Defense & Item(itemnum).Data2
                        ItemDescType = Language.ItemDescription.Shield
                    Case EquipmentType.Shoes
                        ItemDescInfo = Language.ItemDescription.Defense & Item(itemnum).Data2
                        ItemDescType = Language.ItemDescription.Shoes
                    Case EquipmentType.Gloves
                        ItemDescInfo = Language.ItemDescription.Defense & Item(itemnum).Data2
                        ItemDescType = Language.ItemDescription.Gloves
                End Select

            Case ItemType.Consumable
                Select Case Item(itemnum).SubType
                    Case ConsumableType.Hp, ConsumableType.Mp, ConsumableType.Sp
                        ItemDescInfo = Language.ItemDescription.Restore & Item(itemnum).Data2
                        ItemDescType = Language.ItemDescription.Potion
                    Case ConsumableType.Exp
                        ItemDescInfo = Language.ItemDescription.Amount & Item(itemnum).Data2
                        ItemDescType = Language.ItemDescription.Potion
                End Select

            Case ItemType.Key
                ItemDescInfo = Language.ItemDescription.NotAvailable
                ItemDescType = Language.ItemDescription.Key
            Case ItemType.Currency
                ItemDescInfo = Language.ItemDescription.NotAvailable
                ItemDescType = Language.ItemDescription.Currency
            Case ItemType.Skill
                ItemDescInfo = Language.ItemDescription.NotAvailable
                ItemDescType = Language.ItemDescription.Skill
            Case ItemType.Furniture
                ItemDescInfo = Language.ItemDescription.Furniture
        End Select

        ' Moeda
        ItemDescCost = Item(itemnum).Price & "g"

        ' Se moeda, sair antes de tudo
        If Item(itemnum).Type = ItemType.Currency OrElse Item(itemnum).Type = ItemType.None Then
            ' Limpar outros labels
            ItemDescLevel = Language.ItemDescription.NotAvailable
            ItemDescSpeed = Language.ItemDescription.NotAvailable
            ItemDescStr = Language.ItemDescription.NotAvailable
            ItemDescEnd = Language.ItemDescription.NotAvailable
            ItemDescInt = Language.ItemDescription.NotAvailable
            ItemDescSpr = Language.ItemDescription.NotAvailable
            ItemDescVit = Language.ItemDescription.NotAvailable
            ItemDescLuck = Language.ItemDescription.NotAvailable
            Exit Sub
        End If

        ' Poções e etc
        ItemDescLevel = Item(itemnum).LevelReq

        ' Sair para tudo exceto equips
        If Item(itemnum).Type <> ItemType.Equipment Then

            ' Limpar outros marcadores
            ItemDescSpeed = Language.ItemDescription.NotAvailable
            ItemDescStr = Language.ItemDescription.NotAvailable
            ItemDescEnd = Language.ItemDescription.NotAvailable
            ItemDescInt = Language.ItemDescription.NotAvailable
            ItemDescSpr = Language.ItemDescription.NotAvailable
            ItemDescVit = Language.ItemDescription.NotAvailable
            ItemDescLuck = Language.ItemDescription.NotAvailable
            Exit Sub
        End If

        ' Coisas de Equpiamento
        If Item(itemnum).Randomize <> 0 Then
            If windowType = 0 Then

                If Item(itemnum).SubType = EquipmentType.Weapon Then
                    ItemDescSpeed = PlayerInv(invNum).Speed / 1000 & Language.ItemDescription.Seconds
                End If
                If PlayerInv(invNum).Stat(StatType.Strength) > 0 Then
                    ItemDescStr = "+" & PlayerInv(invNum).Stat(StatType.Strength)
                End If
                If PlayerInv(invNum).Stat(StatType.Vitality) > 0 Then
                    ItemDescVit = "+" & PlayerInv(invNum).Stat(StatType.Vitality)
                End If
                If PlayerInv(invNum).Stat(StatType.Intelligence) > 0 Then
                    ItemDescInt = "+" & PlayerInv(invNum).Stat(StatType.Intelligence)
                End If
                If PlayerInv(invNum).Stat(StatType.Endurance) > 0 Then
                    ItemDescEnd = "+" & PlayerInv(invNum).Stat(StatType.Endurance)
                End If
                If PlayerInv(invNum).Stat(StatType.Luck) > 0 Then
                    ItemDescLuck = "+" & PlayerInv(invNum).Stat(StatType.Luck)
                End If
                If PlayerInv(invNum).Stat(StatType.Spirit) > 0 Then
                    ItemDescSpr = "+" & PlayerInv(invNum).Stat(StatType.Spirit)
                End If

            Else

                If Item(itemnum).SubType = EquipmentType.Weapon Then
                    ItemDescSpeed = Player(Myindex).Equipment(invNum).Speed / 1000 & Language.ItemDescription.Seconds
                End If
                If Player(Myindex).Equipment(invNum).Stat(StatType.Strength) > 0 Then
                    ItemDescStr = "+" & Player(Myindex).Equipment(invNum).Stat(StatType.Strength)
                End If
                If Player(Myindex).Equipment(invNum).Stat(StatType.Vitality) > 0 Then
                    ItemDescVit = "+" & Player(Myindex).Equipment(invNum).Stat(StatType.Vitality)
                End If
                If Player(Myindex).Equipment(invNum).Stat(StatType.Intelligence) > 0 Then
                    ItemDescInt = "+" & Player(Myindex).Equipment(invNum).Stat(StatType.Intelligence)
                End If
                If Player(Myindex).Equipment(invNum).Stat(StatType.Endurance) > 0 Then
                    ItemDescEnd = "+" & Player(Myindex).Equipment(invNum).Stat(StatType.Endurance)
                End If
                If Player(Myindex).Equipment(invNum).Stat(StatType.Luck) > 0 Then
                    ItemDescLuck = "+" & Player(Myindex).Equipment(invNum).Stat(StatType.Luck)
                End If
                If Player(Myindex).Equipment(invNum).Stat(StatType.Spirit) > 0 Then
                    ItemDescSpr = "+" & Player(Myindex).Equipment(invNum).Stat(StatType.Spirit)
                End If

            End If
        Else

            If Item(itemnum).SubType = EquipmentType.Weapon Then
                ItemDescSpeed = Item(itemnum).Speed / 1000 & Language.ItemDescription.Seconds
            End If
            If Item(itemnum).Add_Stat(StatType.Strength) > 0 Then
                ItemDescStr = "+" & Item(itemnum).Add_Stat(StatType.Strength)
            End If
            If Item(itemnum).Add_Stat(StatType.Vitality) > 0 Then
                ItemDescVit = "+" & Item(itemnum).Add_Stat(StatType.Vitality)
            End If
            If Item(itemnum).Add_Stat(StatType.Intelligence) > 0 Then
                ItemDescInt = "+" & Item(itemnum).Add_Stat(StatType.Intelligence)
            End If
            If Item(itemnum).Add_Stat(StatType.Endurance) > 0 Then
                ItemDescEnd = "+" & Item(itemnum).Add_Stat(StatType.Endurance)
            End If
            If Item(itemnum).Add_Stat(StatType.Luck) > 0 Then
                ItemDescLuck = "+" & Item(itemnum).Add_Stat(StatType.Luck)
            End If
            If Item(itemnum).Add_Stat(StatType.Spirit) > 0 Then
                ItemDescSpr = "+" & Item(itemnum).Add_Stat(StatType.Spirit)
            End If

        End If

    End Sub

    Friend Sub OpenShop(shopnum As Integer)
        InShop = shopnum
        ShopAction = 0
    End Sub

    Friend Function GetBankItemNum(bankslot As Byte) As Integer
        GetBankItemNum = 0

        If bankslot = 0 Then
            GetBankItemNum = 0
            Exit Function
        End If

        If bankslot > MAX_BANK Then
            GetBankItemNum = 0
            Exit Function
        End If

        GetBankItemNum = Bank.Item(bankslot).Num
    End Function

    Friend Sub SetBankItemNum(bankslot As Byte, itemnum As Integer)
        Bank.Item(bankslot).Num = itemnum
    End Sub

    Friend Function GetBankItemValue(bankslot As Byte) As Integer
        GetBankItemValue = Bank.Item(bankslot).Value
    End Function

    Friend Sub SetBankItemValue(bankslot As Byte, itemValue As Integer)
        Bank.Item(bankslot).Value = itemValue
    End Sub

    Friend Sub ClearActionMsg(index As Byte)
        ActionMsg(index).Message = ""
        ActionMsg(index).Created = 0
        ActionMsg(index).Type = 0
        ActionMsg(index).Color = 0
        ActionMsg(index).Scroll = 0
        ActionMsg(index).X = 0
        ActionMsg(index).Y = 0
    End Sub

    Friend Sub UpdateSkillWindow(skillnum As Integer)

        If LastSkillDesc = skillnum Then Exit Sub

        SkillDescName = Skill(skillnum).Name

        Select Case Skill(skillnum).Type
            Case SkillType.DamageHp
                SkillDescType = Language.SkillDescription.LoseHp
                SkillDescVital = Language.SkillDescription.Lose
            Case SkillType.DamageMp
                SkillDescType = Language.SkillDescription.LoseMp
                SkillDescVital = Language.SkillDescription.Lose
            Case SkillType.HealHp
                SkillDescType = Language.SkillDescription.GainHp
                SkillDescVital = Language.SkillDescription.Gain
            Case SkillType.HealMp
                SkillDescType = Language.SkillDescription.GainMp
                SkillDescVital = Language.SkillDescription.Gain
            Case SkillType.Warp
                SkillDescType = Language.SkillDescription.Warp
        End Select

        SkillDescReqMp = Skill(skillnum).MpCost
        SkillDescReqLvl = Skill(skillnum).LevelReq
        SkillDescReqAccess = Skill(skillnum).AccessReq

        If Skill(skillnum).ClassReq > 0 Then
            SkillDescReqClass = Trim$(Classes(Skill(skillnum).ClassReq).Name)
        Else
            SkillDescReqClass = Language.SkillDescription.None
        End If

        SkillDescCastTime = Skill(skillnum).CastTime & "s"
        SkillDescCoolDown = Skill(skillnum).CdTime & "s"
        SkillDescDamage = Skill(skillnum).Vital

        If Skill(skillnum).IsAoE Then
            SkillDescAoe = Skill(skillnum).AoE & Language.SkillDescription.Tiles
        Else
            SkillDescAoe = Language.SkillDescription.No
        End If

        If Skill(skillnum).Range > 0 Then
            SkillDescRange = Skill(skillnum).Range & Language.SkillDescription.Tiles
        Else
            SkillDescRange = Language.SkillDescription.SelfCast
        End If

    End Sub



    Friend Sub UpdateDrawMapName()
        Dim g As Graphics = Graphics.FromImage(New Bitmap(1, 1))
        'Dim width As Integer
        'width = g.MeasureString(Trim$(Map.Name), New Font(FONT_NAME, FONT_SIZE, FontStyle.Bold, GraphicsUnit.Pixel)).Width
        'DrawMapNameX = ((SCREEN_MAPX + 1) * PicX / 2) - width + 32
        'DrawMapNameY = 1

        Select Case Map.Moral
            Case MapMoralType.None
                DrawMapNameColor = SFML.Graphics.Color.Red
            Case MapMoralType.Safe
                DrawMapNameColor = SFML.Graphics.Color.Green
            Case Else
                DrawMapNameColor = SFML.Graphics.Color.White
        End Select
        g.Dispose()
    End Sub

    Friend Sub AddChatBubble(target As Integer, targetType As Byte, msg As String, colour As Integer)
        Dim i As Integer, index As Integer

        ' setar o indice global

        ChatBubbleindex = ChatBubbleindex + 1
        If ChatBubbleindex < 1 OrElse ChatBubbleindex > Byte.MaxValue Then ChatBubbleindex = 1
        ' padrao para nova bolha
        index = ChatBubbleindex
        ' fazer um loop para ver se aquele jogador/npc ja tem uma bolha
        For i = 1 To Byte.MaxValue
            If ChatBubble(i).TargetType = targetType Then
                If ChatBubble(i).Target = target Then
                    ' resetar indice mestre
                    If ChatBubbleindex > 1 Then ChatBubbleindex = ChatBubbleindex - 1
                    ' usaremos esse agora
                    index = i
                    Exit For
                End If
            End If
        Next
        ' colocar a bolha
        With ChatBubble(index)
            .Target = target
            .TargetType = targetType
            .Msg = msg
            .Colour = colour
            .Timer = GetTickCount()
            .Active = True
        End With

    End Sub

End Module