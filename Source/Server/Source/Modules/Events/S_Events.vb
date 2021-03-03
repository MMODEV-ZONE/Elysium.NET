Imports System.IO
Imports ASFW
Imports Ini = ASFW.IO.FileIO.TextFile

Friend Module S_Events

#Region "Globals"

    Friend TempEventMap() As GlobalEventsStruct
    Friend Switches() As String
    Friend Variables() As String

    Friend Const PathfindingType As Integer = 1

    'Constantes de Efeito - Usado para opções de eventos...
    Friend Const EffectTypeFadein As Integer = 2

    Friend Const EffectTypeFadeout As Integer = 1
    Friend Const EffectTypeFlash As Integer = 3
    Friend Const EffectTypeFog As Integer = 4
    Friend Const EffectTypeWeather As Integer = 5
    Friend Const EffectTypeTint As Integer = 6

#End Region

#Region "Structures"

    Structure MoveRouteStruct
        Dim Index As Integer
        Dim Data1 As Integer
        Dim Data2 As Integer
        Dim Data3 As Integer
        Dim Data4 As Integer
        Dim Data5 As Integer
        Dim Data6 As Integer
    End Structure

    Structure GlobalEventStruct
        Dim X As Integer
        Dim Y As Integer
        Dim Dir As Integer
        Dim Active As Integer

        Dim WalkingAnim As Integer
        Dim FixedDir As Integer
        Dim WalkThrough As Integer
        Dim ShowName As Integer

        Dim Position As Integer

        Dim GraphicType As Integer
        Dim GraphicNum As Integer
        Dim GraphicX As Integer
        Dim GraphicX2 As Integer
        Dim GraphicY As Integer
        Dim GraphicY2 As Integer

        'Opções Apenas do Servidor
        Dim MoveType As Integer

        Dim MoveSpeed As Integer
        Dim MoveFreq As Integer
        Dim MoveRouteCount As Integer
        Dim MoveRoute() As MoveRouteStruct
        Dim MoveRouteStep As Integer

        Dim RepeatMoveRoute As Integer
        Dim IgnoreIfCannotMove As Integer

        Dim MoveTimer As Integer
        Dim QuestNum As Integer
        Dim MoveRouteComplete As Integer
    End Structure

    Structure GlobalEventsStruct
        Dim EventCount As Integer
        Dim Events() As GlobalEventStruct
    End Structure

    Friend Structure ConditionalBranchStruct
        Dim Condition As Integer
        Dim Data1 As Integer
        Dim Data2 As Integer
        Dim Data3 As Integer
        Dim CommandList As Integer
        Dim ElseCommandList As Integer
    End Structure

    Structure EventCommandStruct
        Dim Index As Byte
        Dim Text1 As String
        Dim Text2 As String
        Dim Text3 As String
        Dim Text4 As String
        Dim Text5 As String
        Dim Data1 As Integer
        Dim Data2 As Integer
        Dim Data3 As Integer
        Dim Data4 As Integer
        Dim Data5 As Integer
        Dim Data6 As Integer
        Dim ConditionalBranch As ConditionalBranchStruct
        Dim MoveRouteCount As Integer
        Dim MoveRoute() As MoveRouteStruct
    End Structure

    Structure CommandListStruct
        Dim CommandCount As Integer
        Dim ParentList As Integer
        Dim Commands() As EventCommandStruct
    End Structure

    Structure EventPageStruct
        'Estas são variáveis de condições que decidem se o evento ao menos aparece ao jogador.
        Dim ChkVariable As Integer

        Dim Variableindex As Integer
        Dim VariableCondition As Integer
        Dim VariableCompare As Integer

        Dim ChkSwitch As Integer
        Dim Switchindex As Integer
        Dim SwitchCompare As Integer

        Dim ChkHasItem As Integer
        Dim HasItemindex As Integer
        Dim HasItemAmount As Integer

        Dim ChkSelfSwitch As Integer
        Dim SelfSwitchindex As Integer
        Dim SelfSwitchCompare As Integer
        Dim ChkPlayerGender As Integer
        'Fim das condições

        'Lida com a Sprite do Evento
        Dim GraphicType As Byte

        Dim Graphic As Integer
        Dim GraphicX As Integer
        Dim GraphicY As Integer
        Dim GraphicX2 As Integer
        Dim GraphicY2 As Integer

        'Lida com o Movimento.
        Dim MoveType As Byte

        Dim MoveSpeed As Byte
        Dim MoveFreq As Byte
        Dim MoveRouteCount As Integer
        Dim MoveRoute() As MoveRouteStruct
        Dim IgnoreMoveRoute As Integer
        Dim RepeatMoveRoute As Integer

        'Regras para o Evento
        Dim WalkAnim As Integer

        Dim DirFix As Integer
        Dim WalkThrough As Integer
        Dim ShowName As Integer

        'Gatilho para o evento
        Dim Trigger As Byte

        'Comandos para o evento
        Dim CommandListCount As Integer

        Dim CommandList() As CommandListStruct

        Dim Position As Byte

        Dim QuestNum As Integer

        'Para o EventMap
        Dim X As Integer

        Dim Y As Integer
    End Structure

    <Serializable>
    Structure EventStruct
        Dim Name As String
        Dim Globals As Byte
        Dim PageCount As Integer
        Dim Pages() As EventPageStruct
        Dim X As Integer
        Dim Y As Integer

        'Self Switches re-set on restart.
        Dim SelfSwitches() As Integer '0 to 4

    End Structure

    Friend Structure GlobalMapEventsStruct
        Dim EventId As Integer
        Dim PageId As Integer
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Structure MapEventStruct
        Dim Dir As Integer
        Dim X As Integer
        Dim Y As Integer

        Dim WalkingAnim As Integer
        Dim FixedDir As Integer
        Dim WalkThrough As Integer
        Dim ShowName As Integer

        Dim GraphicType As Integer
        Dim GraphicX As Integer
        Dim GraphicY As Integer
        Dim GraphicX2 As Integer
        Dim GraphicY2 As Integer
        Dim GraphicNum As Integer

        Dim MovementSpeed As Integer
        Dim Position As Integer
        Dim Visible As Integer
        Dim EventId As Integer
        Dim PageId As Integer

        'Opções Apenas do Servidor
        Dim MoveType As Integer

        Dim MoveSpeed As Integer
        Dim MoveFreq As Integer
        Dim MoveRouteCount As Integer
        Dim MoveRoute() As MoveRouteStruct
        Dim MoveRouteStep As Integer

        Dim RepeatMoveRoute As Integer
        Dim IgnoreIfCannotMove As Integer
        Dim QuestNum As Integer

        Dim MoveTimer As Integer
        Dim SelfSwitches() As Integer '0 to 4
        Dim MoveRouteComplete As Integer
    End Structure

    Structure EventMapStruct
        Dim CurrentEvents As Integer
        Dim EventPages() As MapEventStruct
    End Structure

    Structure EventProcessingStruct
        Dim Active As Integer
        Dim CurList As Integer
        Dim CurSlot As Integer
        Dim EventId As Integer
        Dim PageId As Integer
        Dim WaitingForResponse As Integer
        Dim EventMovingId As Integer
        Dim EventMovingType As Integer
        Dim ActionTimer As Integer
        Dim ListLeftOff() As Integer
    End Structure

#End Region

#Region "Enums"

    Friend Enum MoveRouteOpts
        MoveUp = 1
        MoveDown
        MoveLeft
        MoveRight
        MoveRandom
        MoveTowardsPlayer
        MoveAwayFromPlayer
        StepForward
        StepBack
        Wait100Ms
        Wait500Ms
        Wait1000Ms
        TurnUp
        TurnDown
        TurnLeft
        TurnRight
        Turn90Right
        Turn90Left
        Turn180
        TurnRandom
        TurnTowardPlayer
        TurnAwayFromPlayer
        SetSpeed8XSlower
        SetSpeed4XSlower
        SetSpeed2XSlower
        SetSpeedNormal
        SetSpeed2XFaster
        SetSpeed4XFaster
        SetFreqLowest
        SetFreqLower
        SetFreqNormal
        SetFreqHigher
        SetFreqHighest
        WalkingAnimOn
        WalkingAnimOff
        DirFixOn
        DirFixOff
        WalkThroughOn
        WalkThroughOff
        PositionBelowPlayer
        PositionWithPlayer
        PositionAbovePlayer
        ChangeGraphic
    End Enum

    ' Tipos de Eventos
    Friend Enum EventType

        ' Mensagem
        EvAddText = 1

        EvShowText
        EvShowChoices

        ' Progressão de Jogo
        EvPlayerVar

        EvPlayerSwitch
        EvSelfSwitch

        ' Controle de Fluxo
        EvCondition

        EvExitProcess

        ' Jogador
        EvChangeItems

        EvRestoreHp
        EvRestoreMp
        EvLevelUp
        EvChangeLevel
        EvChangeSkills
        EvChangeClass
        EvChangeSprite
        EvChangeSex
        EvChangePk

        ' Movimento
        EvWarpPlayer

        EvSetMoveRoute

        ' Personagem
        EvPlayAnimation

        ' Música e Som
        EvPlayBgm

        EvFadeoutBgm
        EvPlaySound
        EvStopSound

        'Etc...
        EvCustomScript

        EvSetAccess

        'Loja/Banco
        EvOpenBank

        EvOpenShop

        'Novo
        EvGiveExp

        EvShowChatBubble
        EvLabel
        EvGotoLabel
        EvSpawnNpc
        EvFadeIn
        EvFadeOut
        EvFlashWhite
        EvSetFog
        EvSetWeather
        EvSetTint
        EvWait
        EvOpenMail
        EvBeginQuest
        EvEndQuest
        EvQuestTask
        EvShowPicture
        EvHidePicture
        EvWaitMovement
        EvHoldPlayer
        EvReleasePlayer
    End Enum

#End Region

#Region "Database"

    Sub CreateSwitches()
        For i = 1 To MAX_SWITCHES
            Switches(i) = ""
        Next

        SaveSwitches()
    End Sub

    Sub CreateVariables()
        For i = 1 To MAX_VARIABLES
            Variables(i) = ""
        Next

        SaveVariables()
    End Sub

    Sub SaveSwitches()
        Dim cf = Path.Database & "Switches.ini"
        If Not File.Exists(cf) Then File.Create(cf).Dispose()

        For i = 1 To MAX_SWITCHES
            Ini.PutVar(cf, "Switches", i, Switches(i))
        Next
    End Sub

    Sub SaveVariables()
        Dim cf = Path.Database & "Variables.ini"
        If Not File.Exists(cf) Then File.Create(cf).Dispose()

        For i = 1 To MAX_VARIABLES
            Ini.PutVar(cf, "Variables", i, Variables(i))
        Next
    End Sub

    Sub LoadSwitches()
        Dim cf = Path.Database & "Switches.ini"

        If Not File.Exists(cf) Then
            CreateSwitches()
            Exit Sub
        End If

        For i = 1 To MAX_SWITCHES
            Switches(i) = Ini.GetVar(cf, "Switches", i)
        Next
    End Sub

    Sub LoadVariables()
        Dim cf = Path.Database & "Variables.ini"

        If Not File.Exists(cf) Then
            CreateVariables()
            Exit Sub
        End If

        For i = 1 To MAX_VARIABLES
            Variables(i) = Ini.GetVar(cf, "Variables", i)
        Next
    End Sub

#End Region

#Region "Movement"

    Function CanEventMove(index As Integer, mapNum As Integer, x As Integer, y As Integer, eventId As Integer, walkThrough As Integer, dir As Byte, Optional globalevent As Boolean = False) As Boolean
        Dim i As Integer
        Dim n As Integer, z As Integer, begineventprocessing As Boolean

        ' Verificar por subscript out of range

        If mapNum <= 0 OrElse mapNum > MAX_MAPS OrElse dir < DirectionType.Up OrElse dir > DirectionType.Right Then Exit Function

        If Gettingmap = True Then Exit Function

        CanEventMove = True

        If index = 0 Then Exit Function

        Select Case dir
            Case DirectionType.Up

                ' Ver se não está fora dos limites
                If y > 0 Then
                    n = Map(mapNum).Tile(x, y - 1).Type

                    If walkThrough = 1 Then
                        CanEventMove = True
                        Exit Function
                    End If

                    ' Ver se o campo/tile é andável
                    If n = TileType.Blocked Then
                        CanEventMove = False
                        Exit Function
                    End If

                    If n <> TileType.None AndAlso n <> TileType.Item AndAlso n <> TileType.NpcSpawn Then
                        CanEventMove = False
                        Exit Function
                    End If

                    ' Ter certeza que não há um jogador no caminho
                    For i = 1 To Socket.HighIndex
                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = mapNum) AndAlso (GetPlayerX(i) = x) AndAlso (GetPlayerY(i) = y - 1) Then
                                CanEventMove = False
                                'Há um jogador no caminho. Mas talvez o evento seja de toque!
                                If Map(mapNum).Events(eventId).Pages(TempPlayer(index).EventMap.EventPages(eventId).PageId).Trigger = 1 Then
                                    begineventprocessing = True
                                    If begineventprocessing = True Then
                                        ' Processar este evento, ao tocar e tudo dar certo.
                                        If Map(mapNum).Events(eventId).Pages(TempPlayer(index).EventMap.EventPages(eventId).PageId).CommandListCount > 0 Then
                                            TempPlayer(index).EventProcessing(eventId).Active = 1
                                            TempPlayer(index).EventProcessing(eventId).ActionTimer = GetTimeMs()
                                            TempPlayer(index).EventProcessing(eventId).CurList = 1
                                            TempPlayer(index).EventProcessing(eventId).CurSlot = 1
                                            TempPlayer(index).EventProcessing(eventId).EventId = eventId
                                            TempPlayer(index).EventProcessing(eventId).PageId = TempPlayer(index).EventMap.EventPages(eventId).PageId
                                            TempPlayer(index).EventProcessing(eventId).WaitingForResponse = 0
                                            ReDim TempPlayer(index).EventProcessing(eventId).ListLeftOff(Map(GetPlayerMap(index)).Events(TempPlayer(index).EventMap.EventPages(eventId).EventId).Pages(TempPlayer(index).EventMap.EventPages(eventId).PageId).CommandListCount)
                                        End If
                                        begineventprocessing = False
                                    End If
                                End If
                            End If
                        End If
                    Next

                    If CanEventMove = False Then Exit Function
                    ' Ter certeza que não tem um NPC no caminho
                    For i = 1 To MAX_MAP_NPCS
                        If (MapNpc(mapNum).Npc(i).X = x) AndAlso (MapNpc(mapNum).Npc(i).Y = y - 1) Then
                            CanEventMove = False
                            Exit Function
                        End If
                    Next

                    If globalevent = True AndAlso TempEventMap(mapNum).EventCount > 0 Then
                        For z = 1 To TempEventMap(mapNum).EventCount
                            If (z <> eventId) AndAlso (z > 0) AndAlso (TempEventMap(mapNum).Events(z).X = x) AndAlso (TempEventMap(mapNum).Events(z).Y = y - 1) AndAlso (TempEventMap(mapNum).Events(z).WalkThrough = 0) Then
                                CanEventMove = False
                                Exit Function
                            End If
                        Next
                    Else
                        If TempPlayer(index).EventMap.CurrentEvents > 0 Then
                            For z = 1 To TempPlayer(index).EventMap.CurrentEvents
                                If (TempPlayer(index).EventMap.EventPages(z).EventId <> eventId) AndAlso (eventId > 0) AndAlso (TempPlayer(index).EventMap.EventPages(z).X = TempPlayer(index).EventMap.EventPages(eventId).X) AndAlso (TempPlayer(index).EventMap.EventPages(z).Y = TempPlayer(index).EventMap.EventPages(eventId).Y - 1) AndAlso (TempPlayer(index).EventMap.EventPages(z).WalkThrough = 0) Then
                                    CanEventMove = False
                                    Exit Function
                                End If
                            Next
                        End If
                    End If

                    ' Bloqueio direcional
                    If IsDirBlocked(Map(mapNum).Tile(x, y).DirBlock, DirectionType.Up + 1) Then
                        CanEventMove = False
                        Exit Function
                    End If
                Else
                    CanEventMove = False
                End If

            Case DirectionType.Down

                ' Ver se não está fora dos limites
                If y < Map(mapNum).MaxY Then
                    n = Map(mapNum).Tile(x, y + 1).Type

                    If walkThrough = 1 Then
                        CanEventMove = True
                        Exit Function
                    End If

                    ' Ver se o campo/tile é andável
                    If n = TileType.Blocked Then
                        CanEventMove = False
                        Exit Function
                    End If

                    If n <> TileType.None AndAlso n <> TileType.Item AndAlso n <> TileType.NpcSpawn Then
                        CanEventMove = False
                        Exit Function
                    End If

                    ' Ter certeza que não há um jogador no caminho
                    For i = 1 To Socket.HighIndex
                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = mapNum) AndAlso (GetPlayerX(i) = x) AndAlso (GetPlayerY(i) = y + 1) Then
                                CanEventMove = False
                                'Há um jogador no caminho. Mas talvez o evento seja de toque!
                                If Map(mapNum).Events(eventId).Pages(TempPlayer(index).EventMap.EventPages(eventId).PageId).Trigger = 1 Then
                                    begineventprocessing = True
                                    If begineventprocessing = True Then
                                        'Processar este evento, ao tocar e tudo da certo.
                                        If Map(mapNum).Events(eventId).Pages(TempPlayer(index).EventMap.EventPages(eventId).PageId).CommandListCount > 0 Then
                                            TempPlayer(index).EventProcessing(eventId).Active = 1
                                            TempPlayer(index).EventProcessing(eventId).ActionTimer = GetTimeMs()
                                            TempPlayer(index).EventProcessing(eventId).CurList = 1
                                            TempPlayer(index).EventProcessing(eventId).CurSlot = 1
                                            TempPlayer(index).EventProcessing(eventId).EventId = eventId
                                            TempPlayer(index).EventProcessing(eventId).PageId = TempPlayer(index).EventMap.EventPages(eventId).PageId
                                            TempPlayer(index).EventProcessing(eventId).WaitingForResponse = 0
                                            ReDim TempPlayer(index).EventProcessing(eventId).ListLeftOff(Map(GetPlayerMap(index)).Events(TempPlayer(index).EventMap.EventPages(eventId).EventId).Pages(TempPlayer(index).EventMap.EventPages(eventId).PageId).CommandListCount)
                                        End If
                                        begineventprocessing = False
                                    End If
                                End If
                            End If
                        End If
                    Next

                    If CanEventMove = False Then Exit Function

                    ' Ter certeza que não tem um NPC no caminho
                    For i = 1 To MAX_MAP_NPCS
                        If (MapNpc(mapNum).Npc(i).X = x) AndAlso (MapNpc(mapNum).Npc(i).Y = y + 1) Then
                            CanEventMove = False
                            Exit Function
                        End If
                    Next

                    If globalevent = True AndAlso TempEventMap(mapNum).EventCount > 0 Then
                        For z = 1 To TempEventMap(mapNum).EventCount
                            If (z <> eventId) AndAlso (z > 0) AndAlso (TempEventMap(mapNum).Events(z).X = x) AndAlso (TempEventMap(mapNum).Events(z).Y = y + 1) AndAlso (TempEventMap(mapNum).Events(z).WalkThrough = 0) Then
                                CanEventMove = False
                                Exit Function
                            End If
                        Next
                    Else
                        If TempPlayer(index).EventMap.CurrentEvents > 0 Then
                            For z = 1 To TempPlayer(index).EventMap.CurrentEvents
                                If (TempPlayer(index).EventMap.EventPages(z).EventId <> eventId) AndAlso (eventId > 0) AndAlso (TempPlayer(index).EventMap.EventPages(z).X = TempPlayer(index).EventMap.EventPages(eventId).X) AndAlso (TempPlayer(index).EventMap.EventPages(z).Y = TempPlayer(index).EventMap.EventPages(eventId).Y + 1) AndAlso (TempPlayer(index).EventMap.EventPages(z).WalkThrough = 0) Then
                                    CanEventMove = False
                                    Exit Function
                                End If
                            Next
                        End If
                    End If

                    ' Bloqueio direcional
                    If IsDirBlocked(Map(mapNum).Tile(x, y).DirBlock, DirectionType.Down + 1) Then
                        CanEventMove = False
                        Exit Function
                    End If
                Else
                    CanEventMove = False
                End If

            Case DirectionType.Left

                ' Ver se não está fora dos limites
                If x > 0 Then
                    n = Map(mapNum).Tile(x - 1, y).Type

                    If walkThrough = 1 Then
                        CanEventMove = True
                        Exit Function
                    End If

                    ' Ver se o campo/tile é andável
                    If n = TileType.Blocked Then
                        CanEventMove = False
                        Exit Function
                    End If

                    If n <> TileType.None AndAlso n <> TileType.Item AndAlso n <> TileType.NpcSpawn Then
                        CanEventMove = False
                        Exit Function
                    End If

                    ' Ter certeza que não há um jogador no caminho
                    For i = 1 To Socket.HighIndex
                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = mapNum) AndAlso (GetPlayerX(i) = x - 1) AndAlso (GetPlayerY(i) = y) Then
                                CanEventMove = False
                                'Há um jogador no caminho. Mas talvez o evento seja de toque!
                                If Map(mapNum).Events(eventId).Pages(TempPlayer(index).EventMap.EventPages(eventId).PageId).Trigger = 1 Then
                                    begineventprocessing = True
                                    If begineventprocessing = True Then
                                        'Processar este evento, ao tocar e tudo da certo.
                                        If Map(mapNum).Events(eventId).Pages(TempPlayer(index).EventMap.EventPages(eventId).PageId).CommandListCount > 0 Then
                                            TempPlayer(index).EventProcessing(eventId).Active = 1
                                            TempPlayer(index).EventProcessing(eventId).ActionTimer = GetTimeMs()
                                            TempPlayer(index).EventProcessing(eventId).CurList = 1
                                            TempPlayer(index).EventProcessing(eventId).CurSlot = 1
                                            TempPlayer(index).EventProcessing(eventId).EventId = eventId
                                            TempPlayer(index).EventProcessing(eventId).PageId = TempPlayer(index).EventMap.EventPages(eventId).PageId
                                            TempPlayer(index).EventProcessing(eventId).WaitingForResponse = 0
                                            ReDim TempPlayer(index).EventProcessing(eventId).ListLeftOff(Map(GetPlayerMap(index)).Events(TempPlayer(index).EventMap.EventPages(eventId).EventId).Pages(TempPlayer(index).EventMap.EventPages(eventId).PageId).CommandListCount)
                                        End If
                                        begineventprocessing = False
                                    End If
                                End If
                            End If
                        End If
                    Next

                    If CanEventMove = False Then Exit Function

                    ' Ter certeza que não tem um NPC no caminho
                    For i = 1 To MAX_MAP_NPCS
                        If (MapNpc(mapNum).Npc(i).X = x - 1) AndAlso (MapNpc(mapNum).Npc(i).Y = y) Then
                            CanEventMove = False
                            Exit Function
                        End If
                    Next

                    If globalevent = True AndAlso TempEventMap(mapNum).EventCount > 0 Then
                        For z = 1 To TempEventMap(mapNum).EventCount
                            If (z <> eventId) AndAlso (z > 0) AndAlso (TempEventMap(mapNum).Events(z).X = x - 1) AndAlso (TempEventMap(mapNum).Events(z).Y = y) AndAlso (TempEventMap(mapNum).Events(z).WalkThrough = 0) Then
                                CanEventMove = False
                                Exit Function
                            End If
                        Next
                    Else
                        If TempPlayer(index).EventMap.CurrentEvents > 0 Then
                            For z = 1 To TempPlayer(index).EventMap.CurrentEvents
                                If (TempPlayer(index).EventMap.EventPages(z).EventId <> eventId) AndAlso (eventId > 0) AndAlso (TempPlayer(index).EventMap.EventPages(z).X = TempPlayer(index).EventMap.EventPages(eventId).X - 1) AndAlso (TempPlayer(index).EventMap.EventPages(z).Y = TempPlayer(index).EventMap.EventPages(eventId).Y) AndAlso (TempPlayer(index).EventMap.EventPages(z).WalkThrough = 0) Then
                                    CanEventMove = False
                                    Exit Function
                                End If
                            Next
                        End If
                    End If

                    ' Bloqueio direcional
                    If IsDirBlocked(Map(mapNum).Tile(x, y).DirBlock, DirectionType.Left + 1) Then
                        CanEventMove = False
                        Exit Function
                    End If
                Else
                    CanEventMove = False
                End If

            Case DirectionType.Right

                ' Ver se não está fora dos limites
                If x < Map(mapNum).MaxX Then
                    n = Map(mapNum).Tile(x + 1, y).Type

                    If walkThrough = 1 Then
                        CanEventMove = True
                        Exit Function
                    End If

                    ' Ver se o campo/tile é andável
                    If n = TileType.Blocked Then
                        CanEventMove = False
                        Exit Function
                    End If

                    If n <> TileType.None AndAlso n <> TileType.Item AndAlso n <> TileType.NpcSpawn Then
                        CanEventMove = False
                        Exit Function
                    End If

                    ' Ter certeza que não há um jogador no caminho
                    For i = 1 To Socket.HighIndex
                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = mapNum) AndAlso (GetPlayerX(i) = x + 1) AndAlso (GetPlayerY(i) = y) Then
                                CanEventMove = False
                                'Há um jogador no caminho. Mas talvez o evento seja de toque!
                                If Map(mapNum).Events(eventId).Pages(TempPlayer(index).EventMap.EventPages(eventId).PageId).Trigger = 1 Then
                                    begineventprocessing = True
                                    If begineventprocessing = True Then
                                        'Processar este evento, ao tocar e tudo da certo.
                                        If Map(mapNum).Events(eventId).Pages(TempPlayer(index).EventMap.EventPages(eventId).PageId).CommandListCount > 0 Then
                                            TempPlayer(index).EventProcessing(eventId).Active = 1
                                            TempPlayer(index).EventProcessing(eventId).ActionTimer = GetTimeMs()
                                            TempPlayer(index).EventProcessing(eventId).CurList = 1
                                            TempPlayer(index).EventProcessing(eventId).CurSlot = 1
                                            TempPlayer(index).EventProcessing(eventId).EventId = eventId
                                            TempPlayer(index).EventProcessing(eventId).PageId = TempPlayer(index).EventMap.EventPages(eventId).PageId
                                            TempPlayer(index).EventProcessing(eventId).WaitingForResponse = 0
                                            ReDim TempPlayer(index).EventProcessing(eventId).ListLeftOff(Map(GetPlayerMap(index)).Events(TempPlayer(index).EventMap.EventPages(eventId).EventId).Pages(TempPlayer(index).EventMap.EventPages(eventId).PageId).CommandListCount)
                                        End If
                                        begineventprocessing = False
                                    End If
                                End If
                            End If
                        End If
                    Next

                    If CanEventMove = False Then Exit Function

                    ' Ter certeza que não tem um NPC no caminho
                    For i = 1 To MAX_MAP_NPCS
                        If (MapNpc(mapNum).Npc(i).X = x + 1) AndAlso (MapNpc(mapNum).Npc(i).Y = y) Then
                            CanEventMove = False
                            Exit Function
                        End If
                    Next

                    If globalevent = True AndAlso TempEventMap(mapNum).EventCount > 0 Then
                        For z = 1 To TempEventMap(mapNum).EventCount
                            If (z <> eventId) AndAlso (z > 0) AndAlso (TempEventMap(mapNum).Events(z).X = x + 1) AndAlso (TempEventMap(mapNum).Events(z).Y = y) AndAlso (TempEventMap(mapNum).Events(z).WalkThrough = 0) Then
                                CanEventMove = False
                                Exit Function
                            End If
                        Next
                    Else
                        If TempPlayer(index).EventMap.CurrentEvents > 0 Then
                            For z = 1 To TempPlayer(index).EventMap.CurrentEvents
                                If (TempPlayer(index).EventMap.EventPages(z).EventId <> eventId) AndAlso (eventId > 0) AndAlso (TempPlayer(index).EventMap.EventPages(z).X = TempPlayer(index).EventMap.EventPages(eventId).X + 1) AndAlso (TempPlayer(index).EventMap.EventPages(z).Y = TempPlayer(index).EventMap.EventPages(eventId).Y) AndAlso (TempPlayer(index).EventMap.EventPages(z).WalkThrough = 0) Then
                                    CanEventMove = False
                                    Exit Function
                                End If
                            Next
                        End If
                    End If

                    ' Bloqueio direcional
                    If IsDirBlocked(Map(mapNum).Tile(x, y).DirBlock, DirectionType.Right + 1) Then
                        CanEventMove = False
                        Exit Function
                    End If
                Else
                    CanEventMove = False
                End If

        End Select

    End Function

    Sub EventDir(playerindex As Integer, mapNum As Integer, eventId As Integer, dir As Integer, Optional globalevent As Boolean = False)
        Dim buffer As New ByteStream(4)
        Dim eventindex As Integer, i As Integer

        ' Verificar por subscript out of range

        If Gettingmap = True Then Exit Sub

        If mapNum <= 0 OrElse mapNum > MAX_MAPS OrElse dir < DirectionType.Up OrElse dir > DirectionType.Right Then
            Exit Sub
        End If

        If globalevent = False Then
            If TempPlayer(playerindex).EventMap.CurrentEvents > 0 Then
                For i = 1 To TempPlayer(playerindex).EventMap.CurrentEvents
                    If eventId = i Then
                        eventindex = eventId
                        eventId = TempPlayer(playerindex).EventMap.EventPages(i).EventId
                        Exit For
                    End If
                Next
            End If

            If eventindex = 0 OrElse eventId = 0 Then Exit Sub
        End If

        If globalevent Then
            If Map(mapNum).Events(eventId).Pages(1).DirFix = 0 Then TempEventMap(mapNum).Events(eventId).Dir = dir
        Else
            If Map(mapNum).Events(eventId).Pages(TempPlayer(playerindex).EventMap.EventPages(eventindex).PageId).DirFix = 0 Then TempPlayer(playerindex).EventMap.EventPages(eventindex).Dir = dir
        End If

        buffer.WriteInt32(ServerPackets.SEventDir)
        buffer.WriteInt32(eventId)
#If DEBUG Then
        Addlog("Enviada SMSG: SEventDir", PACKET_LOG)
        Console.WriteLine("Enviada SMSG: SEventDir")
#End If
        If globalevent Then
            buffer.WriteInt32(TempEventMap(mapNum).Events(eventId).Dir)
        Else
            buffer.WriteInt32(TempPlayer(playerindex).EventMap.EventPages(eventindex).Dir)
        End If

        SendDataToMap(mapNum, buffer.Data, buffer.Head)

        buffer.Dispose()

    End Sub

    Sub EventMove(index As Integer, mapNum As Integer, eventId As Integer, dir As Integer, movementspeed As Integer, Optional globalevent As Boolean = False)
        Dim buffer As New ByteStream(4)
        Dim eventindex As Integer, i As Integer

        ' Verificar por subscript out of range
        If Gettingmap = True Then Exit Sub

        If mapNum <= 0 OrElse mapNum > MAX_MAPS OrElse dir < DirectionType.Up OrElse dir > DirectionType.Right Then Exit Sub

        If globalevent = False Then
            If TempPlayer(index).EventMap.CurrentEvents > 0 Then
                For i = 1 To TempPlayer(index).EventMap.CurrentEvents
                    If eventId = i Then
                        eventindex = eventId
                        eventId = TempPlayer(index).EventMap.EventPages(i).EventId
                        Exit For
                    End If
                Next
            End If

            If eventindex = 0 OrElse eventId = 0 Then Exit Sub
        Else
            eventindex = eventId
            If eventindex = 0 Then Exit Sub
        End If

        If globalevent Then
            If Map(mapNum).Events(eventId).Pages(1).DirFix = 0 Then TempEventMap(mapNum).Events(eventId).Dir = dir
        Else
            If Map(mapNum).Events(eventId).Pages(TempPlayer(index).EventMap.EventPages(eventindex).PageId).DirFix = 0 Then TempPlayer(index).EventMap.EventPages(eventindex).Dir = dir
        End If

        Select Case dir
            Case DirectionType.Up
                If globalevent Then
                    TempEventMap(mapNum).Events(eventindex).Y = TempEventMap(mapNum).Events(eventindex).Y - 1
                    buffer.WriteInt32(ServerPackets.SEventMove)
                    buffer.WriteInt32(eventId)
                    buffer.WriteInt32(TempEventMap(mapNum).Events(eventindex).X)
                    buffer.WriteInt32(TempEventMap(mapNum).Events(eventindex).Y)
                    buffer.WriteInt32(dir)
                    buffer.WriteInt32(TempEventMap(mapNum).Events(eventindex).Dir)
                    buffer.WriteInt32(movementspeed)
#If DEBUG Then
                    Addlog("Enviada SMSG: SEventMove Dir Up GlobalEvent", PACKET_LOG)
                    Console.WriteLine("Enviada SMSG: SEventMove Dir Up GlobalEvent")
#End If
                    If globalevent Then
                        SendDataToMap(mapNum, buffer.Data, buffer.Head)
                    Else
                        Socket.SendDataTo(index, buffer.Data, buffer.Head)
                    End If
                    buffer.Dispose()
                Else
                    TempPlayer(index).EventMap.EventPages(eventindex).Y = TempPlayer(index).EventMap.EventPages(eventindex).Y - 1
                    buffer.WriteInt32(ServerPackets.SEventMove)
                    buffer.WriteInt32(eventId)
                    buffer.WriteInt32(TempPlayer(index).EventMap.EventPages(eventindex).X)
                    buffer.WriteInt32(TempPlayer(index).EventMap.EventPages(eventindex).Y)
                    buffer.WriteInt32(dir)
                    buffer.WriteInt32(TempPlayer(index).EventMap.EventPages(eventindex).Dir)
                    buffer.WriteInt32(movementspeed)
#If DEBUG Then
                    Addlog("Enviada SMSG: SEventMove Dir Up", PACKET_LOG)
                    Console.WriteLine("Enviada SMSG: SEventMove Dir Up")
#End If
                    If globalevent Then
                        SendDataToMap(mapNum, buffer.Data, buffer.Head)
                    Else
                        Socket.SendDataTo(index, buffer.Data, buffer.Head)
                    End If
                    buffer.Dispose()
                End If

            Case DirectionType.Down
                If globalevent Then
                    TempEventMap(mapNum).Events(eventindex).Y = TempEventMap(mapNum).Events(eventindex).Y + 1
                    buffer.WriteInt32(ServerPackets.SEventMove)
                    buffer.WriteInt32(eventId)
                    buffer.WriteInt32(TempEventMap(mapNum).Events(eventindex).X)
                    buffer.WriteInt32(TempEventMap(mapNum).Events(eventindex).Y)
                    buffer.WriteInt32(dir)
                    buffer.WriteInt32(TempEventMap(mapNum).Events(eventindex).Dir)
                    buffer.WriteInt32(movementspeed)
#If DEBUG Then
                    Addlog("Enviada SMSG: SEventMove Down GlobalEvent", PACKET_LOG)
                    Console.WriteLine("Enviada SMSG: SEventMove Down GlobalEvent")
#End If
                    If globalevent Then
                        SendDataToMap(mapNum, buffer.Data, buffer.Head)
                    Else
                        Socket.SendDataTo(index, buffer.Data, buffer.Head)
                    End If
                    buffer.Dispose()
                Else
                    TempPlayer(index).EventMap.EventPages(eventindex).Y = TempPlayer(index).EventMap.EventPages(eventindex).Y + 1
                    buffer.WriteInt32(ServerPackets.SEventMove)
                    buffer.WriteInt32(eventId)
                    buffer.WriteInt32(TempPlayer(index).EventMap.EventPages(eventindex).X)
                    buffer.WriteInt32(TempPlayer(index).EventMap.EventPages(eventindex).Y)
                    buffer.WriteInt32(dir)
                    buffer.WriteInt32(TempPlayer(index).EventMap.EventPages(eventindex).Dir)
                    buffer.WriteInt32(movementspeed)
#If DEBUG Then
                    Addlog("Enviada SMSG: SEventMove", PACKET_LOG)
                    Console.WriteLine("Enviada SMSG: SEventMove")
#End If
                    If globalevent Then
                        SendDataToMap(mapNum, buffer.Data, buffer.Head)
                    Else
                        Socket.SendDataTo(index, buffer.Data, buffer.Head)
                    End If
                    buffer.Dispose()
                End If
            Case DirectionType.Left
                If globalevent Then
                    TempEventMap(mapNum).Events(eventindex).X = TempEventMap(mapNum).Events(eventindex).X - 1
                    buffer.WriteInt32(ServerPackets.SEventMove)
                    buffer.WriteInt32(eventId)
                    buffer.WriteInt32(TempEventMap(mapNum).Events(eventindex).X)
                    buffer.WriteInt32(TempEventMap(mapNum).Events(eventindex).Y)
                    buffer.WriteInt32(dir)
                    buffer.WriteInt32(TempEventMap(mapNum).Events(eventindex).Dir)
                    buffer.WriteInt32(movementspeed)
#If DEBUG Then
                    Addlog("Enviada SMSG: SEventMove Left GlobalEvent", PACKET_LOG)
                    Console.WriteLine("Enviada SMSG: SEventMove Left GlobalEvent")
#End If
                    If globalevent Then
                        SendDataToMap(mapNum, buffer.Data, buffer.Head)
                    Else
                        Socket.SendDataTo(index, buffer.Data, buffer.Head)
                    End If
                    buffer.Dispose()
                Else
                    TempPlayer(index).EventMap.EventPages(eventindex).X = TempPlayer(index).EventMap.EventPages(eventindex).X - 1
                    buffer.WriteInt32(ServerPackets.SEventMove)
                    buffer.WriteInt32(eventId)
                    buffer.WriteInt32(TempPlayer(index).EventMap.EventPages(eventindex).X)
                    buffer.WriteInt32(TempPlayer(index).EventMap.EventPages(eventindex).Y)
                    buffer.WriteInt32(dir)
                    buffer.WriteInt32(TempPlayer(index).EventMap.EventPages(eventindex).Dir)
                    buffer.WriteInt32(movementspeed)
#If DEBUG Then
                    Addlog("Enviada SMSG: SEventMove", PACKET_LOG)
                    Console.WriteLine("Enviada SMSG: SEventMove")
#End If
                    If globalevent Then
                        SendDataToMap(mapNum, buffer.Data, buffer.Head)
                    Else
                        Socket.SendDataTo(index, buffer.Data, buffer.Head)
                    End If
                    buffer.Dispose()
                End If
            Case DirectionType.Right
                If globalevent Then
                    TempEventMap(mapNum).Events(eventindex).X = TempEventMap(mapNum).Events(eventindex).X + 1
                    buffer.WriteInt32(ServerPackets.SEventMove)
                    buffer.WriteInt32(eventId)
                    buffer.WriteInt32(TempEventMap(mapNum).Events(eventindex).X)
                    buffer.WriteInt32(TempEventMap(mapNum).Events(eventindex).Y)
                    buffer.WriteInt32(dir)
                    buffer.WriteInt32(TempEventMap(mapNum).Events(eventindex).Dir)
                    buffer.WriteInt32(movementspeed)
#If DEBUG Then
                    Addlog("Enviada SMSG: SEventMove GlobalEvent", PACKET_LOG)
                    Console.WriteLine("Enviada SMSG: SEventMove GlobalEvent")
#End If
                    If globalevent Then
                        SendDataToMap(mapNum, buffer.Data, buffer.Head)
                    Else
                        Socket.SendDataTo(index, buffer.Data, buffer.Head)
                    End If
                    buffer.Dispose()
                Else
                    TempPlayer(index).EventMap.EventPages(eventindex).X = TempPlayer(index).EventMap.EventPages(eventindex).X + 1
                    buffer.WriteInt32(ServerPackets.SEventMove)
                    buffer.WriteInt32(eventId)
                    buffer.WriteInt32(TempPlayer(index).EventMap.EventPages(eventindex).X)
                    buffer.WriteInt32(TempPlayer(index).EventMap.EventPages(eventindex).Y)
                    buffer.WriteInt32(dir)
                    buffer.WriteInt32(TempPlayer(index).EventMap.EventPages(eventindex).Dir)
                    buffer.WriteInt32(movementspeed)
#If DEBUG Then
                    Addlog("Enviada SMSG: SEventMove", PACKET_LOG)
                    Console.WriteLine("Enviada SMSG: SEventMove")
#End If
                    If globalevent Then
                        SendDataToMap(mapNum, buffer.Data, buffer.Head)
                    Else
                        Socket.SendDataTo(index, buffer.Data, buffer.Head)
                    End If
                    buffer.Dispose()
                End If
        End Select

    End Sub

    Function IsOneBlockAway(x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer) As Boolean

        If x1 = x2 Then
            If y1 = y2 - 1 OrElse y1 = y2 + 1 Then
                IsOneBlockAway = True
            Else
                IsOneBlockAway = False
            End If
        ElseIf y1 = y2 Then
            If x1 = x2 - 1 OrElse x1 = x2 + 1 Then
                IsOneBlockAway = True
            Else
                IsOneBlockAway = False
            End If
        Else
            IsOneBlockAway = False
        End If

    End Function

    Function GetNpcDir(x As Integer, y As Integer, x1 As Integer, y1 As Integer) As Integer
        Dim i As Integer, distance As Integer

        i = DirectionType.Right

        If x - x1 > 0 Then
            If x - x1 > distance Then
                i = DirectionType.Right
                distance = x - x1
            End If
        ElseIf x - x1 < 0 Then
            If ((x - x1) * -1) > distance Then
                i = DirectionType.Left
                distance = ((x - x1) * -1)
            End If
        End If

        If y - y1 > 0 Then
            If y - y1 > distance Then
                i = DirectionType.Down
                distance = y - y1
            End If
        ElseIf y - y1 < 0 Then
            If ((y - y1) * -1) > distance Then
                i = DirectionType.Up
                distance = ((y - y1) * -1)
            End If
        End If

        GetNpcDir = i

    End Function

    Function CanEventMoveTowardsPlayer(playerId As Integer, mapNum As Integer, eventId As Integer) As Integer
        Dim i As Integer, x As Integer, y As Integer, x1 As Integer, y1 As Integer, didwalk As Boolean, walkThrough As Integer
        Dim tim As Integer, sX As Integer, sY As Integer, pos(,) As Integer, reachable As Boolean, j As Integer, lastSum As Integer, sum As Integer, fx As Integer, fy As Integer
        Dim path() As Point, lastX As Integer, lastY As Integer, did As Boolean
        ' Isso não funciona para eventos globais, então deve ser o primeiro jogador...
        ' Este evento retorna a direção. 4 não é direção valida então assumimos falha a não ser que se diga o contrário.
        CanEventMoveTowardsPlayer = 4

        If playerId <= 0 OrElse playerId > MAX_PLAYERS Then Exit Function
        If mapNum <= 0 OrElse mapNum > MAX_MAPS Then Exit Function
        If eventId <= 0 OrElse eventId > TempPlayer(playerId).EventMap.CurrentEvents Then Exit Function
        If Gettingmap = True Then Exit Function

        x = GetPlayerX(playerId)
        y = GetPlayerY(playerId)
        x1 = TempPlayer(playerId).EventMap.EventPages(eventId).X
        y1 = TempPlayer(playerId).EventMap.EventPages(eventId).Y
        walkThrough = Map(mapNum).Events(TempPlayer(playerId).EventMap.EventPages(eventId).EventId).Pages(TempPlayer(playerId).EventMap.EventPages(eventId).PageId).WalkThrough
        'Adicionar opção de pathfind até opção de aleatoriedade.

        If PathfindingType = 1 Then
            i = Int(Rnd() * 5)
            didwalk = False

            ' Vamos mover o evento
            Select Case i
                Case 0
                    ' Cima
                    If y1 > y AndAlso Not didwalk Then
                        If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Up, False) Then
                            CanEventMoveTowardsPlayer = DirectionType.Up
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Baixo
                    If y1 < y AndAlso Not didwalk Then
                        If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Down, False) Then
                            CanEventMoveTowardsPlayer = DirectionType.Down
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Esquerda
                    If x1 > x AndAlso Not didwalk Then
                        If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Left, False) Then
                            CanEventMoveTowardsPlayer = DirectionType.Left
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Direita
                    If x1 < x AndAlso Not didwalk Then
                        If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Right, False) Then
                            CanEventMoveTowardsPlayer = DirectionType.Right
                            Exit Function
                            didwalk = True
                        End If
                    End If

                Case 1
                    ' Direita
                    If x1 < x AndAlso Not didwalk Then
                        If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Right, False) Then
                            CanEventMoveTowardsPlayer = DirectionType.Right
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Esquerda
                    If x1 > x AndAlso Not didwalk Then
                        If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Left, False) Then
                            CanEventMoveTowardsPlayer = DirectionType.Left
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Baixo
                    If y1 < y AndAlso Not didwalk Then
                        If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Down, False) Then
                            CanEventMoveTowardsPlayer = DirectionType.Down
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Cima
                    If y1 > y AndAlso Not didwalk Then
                        If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Up, False) Then
                            CanEventMoveTowardsPlayer = DirectionType.Up
                            Exit Function
                            didwalk = True
                        End If
                    End If

                Case 2
                    ' Baixo
                    If y1 < y AndAlso Not didwalk Then
                        If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Down, False) Then
                            CanEventMoveTowardsPlayer = DirectionType.Down
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Cima
                    If y1 > y AndAlso Not didwalk Then
                        If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Up, False) Then
                            CanEventMoveTowardsPlayer = DirectionType.Up
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Direita
                    If x1 < x AndAlso Not didwalk Then
                        If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Right, False) Then
                            CanEventMoveTowardsPlayer = DirectionType.Right
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Esquerda
                    If x1 > x AndAlso Not didwalk Then
                        If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Left, False) Then
                            CanEventMoveTowardsPlayer = DirectionType.Left
                            Exit Function
                            didwalk = True
                        End If
                    End If

                Case 3
                    ' Esquerda
                    If x1 > x AndAlso Not didwalk Then
                        If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Left, False) Then
                            CanEventMoveTowardsPlayer = DirectionType.Left
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Direita
                    If x1 < x AndAlso Not didwalk Then
                        If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Right, False) Then
                            CanEventMoveTowardsPlayer = DirectionType.Right
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Cima
                    If y1 > y AndAlso Not didwalk Then
                        If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Up, False) Then
                            CanEventMoveTowardsPlayer = DirectionType.Up
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Baixo
                    If y1 < y AndAlso Not didwalk Then
                        If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Down, False) Then
                            CanEventMoveTowardsPlayer = DirectionType.Down
                            Exit Function
                            didwalk = True
                        End If
                    End If
            End Select
            CanEventMoveTowardsPlayer = Random(0, 3)
        ElseIf PathfindingType = 2 Then
            'fase de inicialização
            tim = 0
            sX = x1
            sY = y1
            fx = x
            fy = y

            ReDim pos(Map(mapNum).MaxX, Map(mapNum).MaxY)

            For i = 1 To TempPlayer(playerId).EventMap.CurrentEvents
                If TempPlayer(playerId).EventMap.EventPages(i).Visible Then
                    If TempPlayer(playerId).EventMap.EventPages(i).WalkThrough = 1 Then
                        pos(TempPlayer(playerId).EventMap.EventPages(i).X, TempPlayer(playerId).EventMap.EventPages(i).Y) = 9
                    End If
                End If
            Next

            pos(sX, sY) = 100 + tim
            pos(fx, fy) = 2

            'Resetar reachable
            reachable = False

            'Executar enquanto reachable for falso... se é setado para verdeiro, pulamos fora
            'Se o caminho é decididamente não-alcançavel no processo, saíremos da sub. Não é o melhor jeito, mas é rápido.
            Do While reachable = False
                'Fazemos um loop por todos os quadrados
                For j = 0 To Map(mapNum).MaxY
                    For i = 0 To Map(mapNum).MaxX
                        'If j = 10 AndAlso i = 0 Then MsgBox "hi!"
                        'Se eles são estendidos, o ponteiro TIM está com eles
                        If pos(i, j) = 100 + tim Then
                            'A parte deve ser estendida, então faça isso
                            'Temos que ter certeza que há uma posição(i+1,j) ANTES de usarmos
                            'porque então teremos error... SE o quadrado está do lado, não testamos para esse!
                            If i < Map(mapNum).MaxX Then
                                'Se não há uma parede ou qualquer outra coisa...
                                If pos(i + 1, j) = 0 Then
                                    'Expanda e faça a posição igual a tim+1, daí a próxima vez que fizemos este loop,
                                    'ela irá expandir aquele quadrado também! Esta é uma parte crucial do programa.
                                    pos(i + 1, j) = 100 + tim + 1
                                ElseIf pos(i + 1, j) = 2 Then
                                    'Se a posição não é 0 mas é 2 (FIM) então Reachable = true! Acabou
                                    reachable = True
                                End If
                            End If

                            'Isso é igual ao último. É simplesmente outro lado que temos que testar... então ao invés de
                            'i+1 teremos i-1. É bem igual, e não vou comentar, já que é basicamente repetir a mesma coisa
                            'com mudançãs menores para checar lados
                            If i > 0 Then
                                If pos((i - 1), j) = 0 Then
                                    pos(i - 1, j) = 100 + tim + 1
                                ElseIf pos(i - 1, j) = 2 Then
                                    reachable = True
                                End If
                            End If

                            If j < Map(mapNum).MaxY Then
                                If pos(i, j + 1) = 0 Then
                                    pos(i, j + 1) = 100 + tim + 1
                                ElseIf pos(i, j + 1) = 2 Then
                                    reachable = True
                                End If
                            End If

                            If j > 0 Then
                                If pos(i, j - 1) = 0 Then
                                    pos(i, j - 1) = 100 + tim + 1
                                ElseIf pos(i, j - 1) = 2 Then
                                    reachable = True
                                End If
                            End If
                        End If
                        Application.DoEvents()
                    Next i
                Next j

                'Se o reachable ainda é falso, então
                If reachable = False Then
                    'resetar soma
                    sum = 0
                    For j = 0 To Map(mapNum).MaxY
                        For i = 0 To Map(mapNum).MaxX
                            'adicionamos todos os quadrados
                            sum = sum + pos(i, j)
                        Next i
                    Next j

                    'Agora se a soma é igual à última soma, não é alcançavel; se não é, então guardamos a soma na última soma
                    If sum = lastSum Then
                        CanEventMoveTowardsPlayer = 4
                        Exit Function
                    Else
                        lastSum = sum
                    End If
                End If

                'aumentar o ponteiro para apontar ao próximo quadrado a ser expandido
                tim = tim + 1
            Loop

            'Trabalhamos de trás-pra-frente para achar o caminho...
            lastX = fx
            lastY = fy

            ReDim path(tim + 1)

            'O código abaixo pode ser um pouco confuso
            'Trabalhamos de trás-pra-frente para achar UM DOS caminhos mais curtos de volta ao início
            'Então repetimos o loop até que LastX e LastY não estejam no início. Olhe o código para ver
            'como LastX e LastY mudam.
            Do While lastX <> sX OrElse lastY <> sY
                ' Diminuimos tim por um e então encontramos qualquer quadrado adjacente ao final que tenha aquele valor.
                'Então digamos que tim seria 5, porque levaria 5 passos ao alvo. Agora todas as vezes diminuimos e 
                'fazemos ser 4, olhamos por quadrados adjacentes qu tem esse valor. Qunado encontramos, colorimos 
                'de amarelo como a solução
                tim = tim - 1
                'resetar did para falso
                did = False

                'Se não estamos na borda
                If lastX < Map(mapNum).MaxX Then
                    'Ver o quadrado a direita da solução. É um tim-1? Ou apenas um branco?
                    If pos(lastX + 1, lastY) = 100 + tim Then
                        'Se é, então faça-o amarelo e mude did para verdade
                        lastX = lastX + 1
                        did = True
                    End If
                End If

                'Isso vai funcionar apenas se a parte anterior não executar e did ainda é falso.
                'Então queremos checar outro quadrado, o da esquerda. É um tim-1?
                If did = False Then
                    If lastX > 0 Then
                        If pos(lastX - 1, lastY) = 100 + tim Then
                            lastX = lastX - 1
                            did = True
                        End If
                    End If
                End If

                'Checamos o abaixo dele
                If did = False Then
                    If lastY < Map(mapNum).MaxY Then
                        If pos(lastX, lastY + 1) = 100 + tim Then
                            lastY = lastY + 1
                            did = True
                        End If
                    End If
                End If

                'E acima dele. Algum desses tem que ser, já que encontramos a solução e sabemos que há um jeito de volta. 
                If did = False Then
                    If lastY > 0 Then
                        If pos(lastX, lastY - 1) = 100 + tim Then
                            lastY = lastY - 1
                        End If
                    End If
                End If

                path(tim).X = lastX
                path(tim).Y = lastY

                'Agora fazemos um loop reverso e diminuimos tim, 
                'e procuramos pelo próximo quadrado com um valor menor
                Application.DoEvents()
            Loop

            'OK. Temos um caminho.
            'Agora vamos oolhar ao primeiro passo e ver que direção temos que tomar.
            If path(1).X > lastX Then
                CanEventMoveTowardsPlayer = DirectionType.Right
            ElseIf path(1).Y > lastY Then
                CanEventMoveTowardsPlayer = DirectionType.Down
            ElseIf path(1).Y < lastY Then
                CanEventMoveTowardsPlayer = DirectionType.Up
            ElseIf path(1).X < lastX Then
                CanEventMoveTowardsPlayer = DirectionType.Left
            End If

        End If

    End Function

    Function CanEventMoveAwayFromPlayer(playerId As Integer, mapNum As Integer, eventId As Integer) As Integer
        Dim i As Integer, x As Integer, y As Integer, x1 As Integer, y1 As Integer, didwalk As Boolean, walkThrough As Integer
        ' Isso não funciona para evnetos globais, então DEVE ser o primeiro jogador
        ' Este evento retorna uma direção. 5 não é válido então assumimos falha a não ser que se diga o contrário.
        CanEventMoveAwayFromPlayer = 5

        If playerId <= 0 OrElse playerId > MAX_PLAYERS Then Exit Function
        If mapNum <= 0 OrElse mapNum > MAX_MAPS Then Exit Function
        If eventId <= 0 OrElse eventId > TempPlayer(playerId).EventMap.CurrentEvents Then Exit Function
        If Gettingmap = True Then Exit Function

        x = GetPlayerX(playerId)
        y = GetPlayerY(playerId)
        x1 = TempPlayer(playerId).EventMap.EventPages(eventId).X
        y1 = TempPlayer(playerId).EventMap.EventPages(eventId).Y
        walkThrough = Map(mapNum).Events(TempPlayer(playerId).EventMap.EventPages(eventId).EventId).Pages(TempPlayer(playerId).EventMap.EventPages(eventId).PageId).WalkThrough

        i = Int(Rnd() * 5)
        didwalk = False

        ' Vamos mover o evento
        Select Case i
            Case 0
                ' Cima
                If y1 > y AndAlso Not didwalk Then
                    If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Down, False) Then
                        CanEventMoveAwayFromPlayer = DirectionType.Down
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Baixo
                If y1 < y AndAlso Not didwalk Then
                    If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Up, False) Then
                        CanEventMoveAwayFromPlayer = DirectionType.Up
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Esquerda
                If x1 > x AndAlso Not didwalk Then
                    If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Right, False) Then
                        CanEventMoveAwayFromPlayer = DirectionType.Right
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Direita
                If x1 < x AndAlso Not didwalk Then
                    If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Left, False) Then
                        CanEventMoveAwayFromPlayer = DirectionType.Left
                        Exit Function
                        didwalk = True
                    End If
                End If

            Case 1
                ' Direita
                If x1 < x AndAlso Not didwalk Then
                    If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Left, False) Then
                        CanEventMoveAwayFromPlayer = DirectionType.Left
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Esqeurda
                If x1 > x AndAlso Not didwalk Then
                    If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Right, False) Then
                        CanEventMoveAwayFromPlayer = DirectionType.Right
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Baixo
                If y1 < y AndAlso Not didwalk Then
                    If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Up, False) Then
                        CanEventMoveAwayFromPlayer = DirectionType.Up
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Cima
                If y1 > y AndAlso Not didwalk Then
                    If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Down, False) Then
                        CanEventMoveAwayFromPlayer = DirectionType.Down
                        Exit Function
                        didwalk = True
                    End If
                End If

            Case 2
                ' Baixo
                If y1 < y AndAlso Not didwalk Then
                    If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Up, False) Then
                        CanEventMoveAwayFromPlayer = DirectionType.Up
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Cima
                If y1 > y AndAlso Not didwalk Then
                    If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Down, False) Then
                        CanEventMoveAwayFromPlayer = DirectionType.Down
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Direita
                If x1 < x AndAlso Not didwalk Then
                    If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Left, False) Then
                        CanEventMoveAwayFromPlayer = DirectionType.Left
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Esquerda
                If x1 > x AndAlso Not didwalk Then
                    If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Right, False) Then
                        CanEventMoveAwayFromPlayer = DirectionType.Right
                        Exit Function
                        didwalk = True
                    End If
                End If

            Case 3
                ' Esquerda
                If x1 > x AndAlso Not didwalk Then
                    If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Right, False) Then
                        CanEventMoveAwayFromPlayer = DirectionType.Right
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Direita
                If x1 < x AndAlso Not didwalk Then
                    If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Left, False) Then
                        CanEventMoveAwayFromPlayer = DirectionType.Left
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Cima
                If y1 > y AndAlso Not didwalk Then
                    If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Down, False) Then
                        CanEventMoveAwayFromPlayer = DirectionType.Down
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Baixo
                If y1 < y AndAlso Not didwalk Then
                    If CanEventMove(playerId, mapNum, x1, y1, eventId, walkThrough, DirectionType.Up, False) Then
                        CanEventMoveAwayFromPlayer = DirectionType.Up
                        Exit Function
                        didwalk = True
                    End If
                End If

        End Select

        CanEventMoveAwayFromPlayer = Random(0, 3)

    End Function

    Function GetDirToPlayer(playerId As Integer, mapNum As Integer, eventId As Integer) As Integer
        Dim i As Integer, x As Integer, y As Integer, x1 As Integer, y1 As Integer, distance As Integer
        'Isso não funciona para evnetos globais, então DEVE ser o primeiro jogador....

        If playerId <= 0 OrElse playerId > MAX_PLAYERS Then Exit Function
        If mapNum <= 0 OrElse mapNum > MAX_MAPS Then Exit Function
        If eventId <= 0 OrElse eventId > TempPlayer(playerId).EventMap.CurrentEvents Then Exit Function

        x = GetPlayerX(playerId)
        y = GetPlayerY(playerId)
        x1 = TempPlayer(playerId).EventMap.EventPages(eventId).X
        y1 = TempPlayer(playerId).EventMap.EventPages(eventId).Y

        i = DirectionType.Right

        If x - x1 > 0 Then
            If x - x1 > distance Then
                i = DirectionType.Right
                distance = x - x1
            End If
        ElseIf x - x1 < 0 Then
            If ((x - x1) * -1) > distance Then
                i = DirectionType.Left
                distance = ((x - x1) * -1)
            End If
        End If

        If y - y1 > 0 Then
            If y - y1 > distance Then
                i = DirectionType.Down
                distance = y - y1
            End If
        ElseIf y - y1 < 0 Then
            If ((y - y1) * -1) > distance Then
                i = DirectionType.Up
                distance = ((y - y1) * -1)
            End If
        End If

        GetDirToPlayer = i

    End Function

    Function GetDirAwayFromPlayer(playerId As Integer, mapNum As Integer, eventId As Integer) As Integer
        Dim i As Integer, x As Integer, y As Integer, x1 As Integer, y1 As Integer, distance As Integer
        'Isso não funciona para evnetos globais, então DEVE ser o primeiro jogador....

        If playerId <= 0 OrElse playerId > MAX_PLAYERS Then Exit Function
        If mapNum <= 0 OrElse mapNum > MAX_MAPS Then Exit Function
        If eventId <= 0 OrElse eventId > TempPlayer(playerId).EventMap.CurrentEvents Then Exit Function

        x = GetPlayerX(playerId)
        y = GetPlayerY(playerId)
        x1 = TempPlayer(playerId).EventMap.EventPages(eventId).X
        y1 = TempPlayer(playerId).EventMap.EventPages(eventId).Y

        i = DirectionType.Right

        If x - x1 > 0 Then
            If x - x1 > distance Then
                i = DirectionType.Left
                distance = x - x1
            End If
        ElseIf x - x1 < 0 Then
            If ((x - x1) * -1) > distance Then
                i = DirectionType.Right
                distance = ((x - x1) * -1)
            End If
        End If

        If y - y1 > 0 Then
            If y - y1 > distance Then
                i = DirectionType.Up
                distance = y - y1
            End If
        ElseIf y - y1 < 0 Then
            If ((y - y1) * -1) > distance Then
                i = DirectionType.Down
                distance = ((y - y1) * -1)
            End If
        End If

        GetDirAwayFromPlayer = i

    End Function

#End Region

#Region "Incoming Packets"

    Sub Packet_EventChatReply(index As Integer, ByRef data() As Byte)
        Dim eventId As Integer, pageId As Integer, reply As Integer, i As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CEventChatReply")
#End If
        eventId = buffer.ReadInt32
        pageId = buffer.ReadInt32
        reply = buffer.ReadInt32

        If TempPlayer(index).EventProcessingCount > 0 Then
            For i = 1 To TempPlayer(index).EventProcessingCount
                If TempPlayer(index).EventProcessing(i).EventId = eventId AndAlso TempPlayer(index).EventProcessing(i).PageId = pageId Then
                    If TempPlayer(index).EventProcessing(i).WaitingForResponse = 1 Then
                        If reply = 0 Then
                            If Map(GetPlayerMap(index)).Events(eventId).Pages(pageId).CommandList(TempPlayer(index).EventProcessing(i).CurList).Commands(TempPlayer(index).EventProcessing(i).CurSlot - 1).Index = EventType.EvShowText Then
                                TempPlayer(index).EventProcessing(i).WaitingForResponse = 0
                            End If
                        ElseIf reply > 0 Then
                            If Map(GetPlayerMap(index)).Events(eventId).Pages(pageId).CommandList(TempPlayer(index).EventProcessing(i).CurList).Commands(TempPlayer(index).EventProcessing(i).CurSlot - 1).Index = EventType.EvShowChoices Then
                                Select Case reply
                                    Case 1
                                        TempPlayer(index).EventProcessing(i).ListLeftOff(TempPlayer(index).EventProcessing(i).CurList) = TempPlayer(index).EventProcessing(i).CurSlot - 1
                                        TempPlayer(index).EventProcessing(i).CurList = Map(GetPlayerMap(index)).Events(eventId).Pages(pageId).CommandList(TempPlayer(index).EventProcessing(i).CurList).Commands(TempPlayer(index).EventProcessing(i).CurSlot - 1).Data1
                                        TempPlayer(index).EventProcessing(i).CurSlot = 1
                                    Case 2
                                        TempPlayer(index).EventProcessing(i).ListLeftOff(TempPlayer(index).EventProcessing(i).CurList) = TempPlayer(index).EventProcessing(i).CurSlot - 1
                                        TempPlayer(index).EventProcessing(i).CurList = Map(GetPlayerMap(index)).Events(eventId).Pages(pageId).CommandList(TempPlayer(index).EventProcessing(i).CurList).Commands(TempPlayer(index).EventProcessing(i).CurSlot - 1).Data2
                                        TempPlayer(index).EventProcessing(i).CurSlot = 1
                                    Case 3
                                        TempPlayer(index).EventProcessing(i).ListLeftOff(TempPlayer(index).EventProcessing(i).CurList) = TempPlayer(index).EventProcessing(i).CurSlot - 1
                                        TempPlayer(index).EventProcessing(i).CurList = Map(GetPlayerMap(index)).Events(eventId).Pages(pageId).CommandList(TempPlayer(index).EventProcessing(i).CurList).Commands(TempPlayer(index).EventProcessing(i).CurSlot - 1).Data3
                                        TempPlayer(index).EventProcessing(i).CurSlot = 1
                                    Case 4
                                        TempPlayer(index).EventProcessing(i).ListLeftOff(TempPlayer(index).EventProcessing(i).CurList) = TempPlayer(index).EventProcessing(i).CurSlot - 1
                                        TempPlayer(index).EventProcessing(i).CurList = Map(GetPlayerMap(index)).Events(eventId).Pages(pageId).CommandList(TempPlayer(index).EventProcessing(i).CurList).Commands(TempPlayer(index).EventProcessing(i).CurSlot - 1).Data4
                                        TempPlayer(index).EventProcessing(i).CurSlot = 1
                                End Select
                            End If
                            TempPlayer(index).EventProcessing(i).WaitingForResponse = 0
                        End If
                    End If
                End If
            Next
        End If

        buffer.Dispose()

    End Sub

    Sub Packet_Event(index As Integer, ByRef data() As Byte)
        Dim i As Integer, begineventprocessing As Boolean, z As Integer
        Dim x As Integer, y As Integer
        Dim buffer As New ByteStream(data)

#If DEBUG Then
        AddDebug("Recebida CMSG: CEvent")
#End If
        i = buffer.ReadInt32
        buffer.Dispose()

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

        If TempPlayer(index).EventMap.CurrentEvents > 0 Then
            For z = 1 To TempPlayer(index).EventMap.CurrentEvents
                If TempPlayer(index).EventMap.EventPages(z).EventId = i Then
                    i = z
                    begineventprocessing = True
                    Exit For
                End If
            Next
        End If

        If begineventprocessing = True Then
            If Map(GetPlayerMap(index)).Events(TempPlayer(index).EventMap.EventPages(i).EventId).Pages(TempPlayer(index).EventMap.EventPages(i).PageId).CommandListCount > 0 Then
                'Processar este evento, se é botão de ação e tudo dá ok.
                If (TempPlayer(index).EventProcessing(TempPlayer(index).EventMap.EventPages(i).EventId).Active = 0) Then
                    TempPlayer(index).EventProcessing(TempPlayer(index).EventMap.EventPages(i).EventId).Active = 1
                    With TempPlayer(index).EventProcessing(TempPlayer(index).EventMap.EventPages(i).EventId)
                        .ActionTimer = GetTimeMs()
                        .CurList = 1
                        .CurSlot = 1
                        .EventId = TempPlayer(index).EventMap.EventPages(i).EventId
                        .PageId = TempPlayer(index).EventMap.EventPages(i).PageId
                        .WaitingForResponse = 0
                        ReDim .ListLeftOff(Map(GetPlayerMap(index)).Events(TempPlayer(index).EventMap.EventPages(i).EventId).Pages(TempPlayer(index).EventMap.EventPages(i).PageId).CommandListCount)
                    End With
                End If
            End If
            begineventprocessing = False
        End If

    End Sub

    Sub Packet_RequestSwitchesAndVariables(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida CMSG: CRequestSwitchesAndVariables")
#End If
        SendSwitchesAndVariables(index)
    End Sub

    Sub Packet_SwitchesAndVariables(index As Integer, ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CSwitchesAndVariables")
#End If
        For i = 1 To MAX_SWITCHES
            Switches(i) = buffer.ReadString
        Next

        For i = 1 To MAX_VARIABLES
            Variables(i) = buffer.ReadString
        Next

        SaveSwitches()
        SaveVariables()

        buffer.Dispose()

        SendSwitchesAndVariables(0, True)

    End Sub

#End Region

#Region "Outgoing Packets"

    Sub SendSpecialEffect(index As Integer, effectType As Integer, Optional data1 As Integer = 0, Optional data2 As Integer = 0, Optional data3 As Integer = 0, Optional data4 As Integer = 0)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SSpecialEffect)
#If DEBUG Then
        AddDebug("Enviada SMSG: SSpecialEffect")
#End If
        Select Case effectType
            Case EffectTypeFadein
                buffer.WriteInt32(effectType)
            Case EffectTypeFadeout
                buffer.WriteInt32(effectType)
            Case EffectTypeFlash
                buffer.WriteInt32(effectType)
            Case EffectTypeFog
                buffer.WriteInt32(effectType)
                buffer.WriteInt32(data1) 'num da nevoa
                buffer.WriteInt32(data2) 'velocidade do movimento da nevoa
                buffer.WriteInt32(data3) 'opacidade
            Case EffectTypeWeather
                buffer.WriteInt32(effectType)
                buffer.WriteInt32(data1) 'clima tipo
                buffer.WriteInt32(data2) 'intensidade do clima
            Case EffectTypeTint
                buffer.WriteInt32(effectType)
                buffer.WriteInt32(data1) 'vermelho
                buffer.WriteInt32(data2) 'verde
                buffer.WriteInt32(data3) 'azul
                buffer.WriteInt32(data4) 'alpha
        End Select

        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

    Sub SendSwitchesAndVariables(index As Integer, Optional everyone As Boolean = False)
        Dim buffer As New ByteStream(4), i As Integer

        buffer.WriteInt32(ServerPackets.SSwitchesAndVariables)
#If DEBUG Then
        AddDebug("Enviada SMSG: SSwitchesAndVariables")
#End If
        For i = 1 To MAX_SWITCHES
            buffer.WriteString((Trim(Switches(i))))
        Next

        For i = 1 To MAX_VARIABLES
            buffer.WriteString((Trim(Variables(i))))
        Next

        If everyone Then
            SendDataToAll(buffer.Data, buffer.Head)
        Else
            Socket.SendDataTo(index, buffer.Data, buffer.Head)
        End If

        buffer.Dispose()

    End Sub

    Sub SendMapEventData(index As Integer)
        Dim buffer As New ByteStream(4), i As Integer, x As Integer, y As Integer
        Dim z As Integer, mapNum As Integer, w As Integer

        buffer.WriteInt32(ServerPackets.SMapEventData)
        mapNum = GetPlayerMap(index)
#If DEBUG Then
        AddDebug("Enviada SMSG: SMapEventData")
#End If

        'Dados de Evento
        buffer.WriteInt32(Map(mapNum).EventCount)

        If Map(mapNum).EventCount > 0 Then
            For i = 1 To Map(mapNum).EventCount
                With Map(mapNum).Events(i)
                    buffer.WriteString((Trim(.Name)))
                    buffer.WriteInt32(.Globals)
                    buffer.WriteInt32(.X)
                    buffer.WriteInt32(.Y)
                    buffer.WriteInt32(.PageCount)
                End With
                If Map(mapNum).Events(i).PageCount > 0 Then
                    For x = 1 To Map(mapNum).Events(i).PageCount
                        With Map(mapNum).Events(i).Pages(x)
                            buffer.WriteInt32(.ChkVariable)
                            buffer.WriteInt32(.Variableindex)
                            buffer.WriteInt32(.VariableCondition)
                            buffer.WriteInt32(.VariableCompare)

                            buffer.WriteInt32(.ChkSwitch)
                            buffer.WriteInt32(.Switchindex)
                            buffer.WriteInt32(.SwitchCompare)

                            buffer.WriteInt32(.ChkHasItem)
                            buffer.WriteInt32(.HasItemindex)
                            buffer.WriteInt32(.HasItemAmount)

                            buffer.WriteInt32(.ChkSelfSwitch)
                            buffer.WriteInt32(.SelfSwitchindex)
                            buffer.WriteInt32(.SelfSwitchCompare)

                            buffer.WriteInt32(.GraphicType)
                            buffer.WriteInt32(.Graphic)
                            buffer.WriteInt32(.GraphicX)
                            buffer.WriteInt32(.GraphicY)
                            buffer.WriteInt32(.GraphicX2)
                            buffer.WriteInt32(.GraphicY2)

                            buffer.WriteInt32(.MoveType)
                            buffer.WriteInt32(.MoveSpeed)
                            buffer.WriteInt32(.MoveFreq)
                            buffer.WriteInt32(.MoveRouteCount)

                            buffer.WriteInt32(.IgnoreMoveRoute)
                            buffer.WriteInt32(.RepeatMoveRoute)

                            If .MoveRouteCount > 0 Then
                                For y = 1 To .MoveRouteCount
                                    buffer.WriteInt32(.MoveRoute(y).Index)
                                    buffer.WriteInt32(.MoveRoute(y).Data1)
                                    buffer.WriteInt32(.MoveRoute(y).Data2)
                                    buffer.WriteInt32(.MoveRoute(y).Data3)
                                    buffer.WriteInt32(.MoveRoute(y).Data4)
                                    buffer.WriteInt32(.MoveRoute(y).Data5)
                                    buffer.WriteInt32(.MoveRoute(y).Data6)
                                Next
                            End If

                            buffer.WriteInt32(.WalkAnim)
                            buffer.WriteInt32(.DirFix)
                            buffer.WriteInt32(.WalkThrough)
                            buffer.WriteInt32(.ShowName)
                            buffer.WriteInt32(.Trigger)
                            buffer.WriteInt32(.CommandListCount)

                            buffer.WriteInt32(.Position)
                            buffer.WriteInt32(.QuestNum)
                        End With

                        If Map(mapNum).Events(i).Pages(x).CommandListCount > 0 Then
                            For y = 1 To Map(mapNum).Events(i).Pages(x).CommandListCount
                                buffer.WriteInt32(Map(mapNum).Events(i).Pages(x).CommandList(y).CommandCount)
                                buffer.WriteInt32(Map(mapNum).Events(i).Pages(x).CommandList(y).ParentList)
                                If Map(mapNum).Events(i).Pages(x).CommandList(y).CommandCount > 0 Then
                                    For z = 1 To Map(mapNum).Events(i).Pages(x).CommandList(y).CommandCount
                                        With Map(mapNum).Events(i).Pages(x).CommandList(y).Commands(z)
                                            buffer.WriteInt32(.Index)
                                            buffer.WriteString((.Text1))
                                            buffer.WriteString((.Text2))
                                            buffer.WriteString((.Text3))
                                            buffer.WriteString((.Text4))
                                            buffer.WriteString((.Text5))
                                            buffer.WriteInt32(.Data1)
                                            buffer.WriteInt32(.Data2)
                                            buffer.WriteInt32(.Data3)
                                            buffer.WriteInt32(.Data4)
                                            buffer.WriteInt32(.Data5)
                                            buffer.WriteInt32(.Data6)
                                            buffer.WriteInt32(.ConditionalBranch.CommandList)
                                            buffer.WriteInt32(.ConditionalBranch.Condition)
                                            buffer.WriteInt32(.ConditionalBranch.Data1)
                                            buffer.WriteInt32(.ConditionalBranch.Data2)
                                            buffer.WriteInt32(.ConditionalBranch.Data3)
                                            buffer.WriteInt32(.ConditionalBranch.ElseCommandList)
                                            buffer.WriteInt32(.MoveRouteCount)
                                            If .MoveRouteCount > 0 Then
                                                For w = 1 To .MoveRouteCount
                                                    buffer.WriteInt32(.MoveRoute(w).Index)
                                                    buffer.WriteInt32(.MoveRoute(w).Data1)
                                                    buffer.WriteInt32(.MoveRoute(w).Data2)
                                                    buffer.WriteInt32(.MoveRoute(w).Data3)
                                                    buffer.WriteInt32(.MoveRoute(w).Data4)
                                                    buffer.WriteInt32(.MoveRoute(w).Data5)
                                                    buffer.WriteInt32(.MoveRoute(w).Data6)
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

        'Fim dos Dados do Evento
        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
        SendSwitchesAndVariables(index)

    End Sub

#End Region

#Region "Misc"

    Friend Sub GivePlayerExp(index As Integer, exp As Integer)
        Dim petnum As Integer

        ' Dar a experiência

        SetPlayerExp(index, GetPlayerExp(index) + exp)
        SendActionMsg(GetPlayerMap(index), "+" & exp & " Exp", ColorType.White, 1, (GetPlayerX(index) * 32), (GetPlayerY(index) * 32))
        ' Ver se subimos de nível
        CheckPlayerLevelUp(index)

        If PetAlive(index) Then
            petnum = GetPetNum(index)

            If Pet(petnum).LevelingType = 1 Then
                SetPetExp(index, GetPetExp(index) + (exp * (Pet(petnum).ExpGain / 100)))
                SendActionMsg(GetPlayerMap(index), "+" & (exp * (Pet(petnum).ExpGain / 100)) & " Exp", ColorType.White, 1, (GetPetX(index) * 32), (GetPetY(index) * 32))
                CheckPetLevelUp(index)
                SendPetExp(index)
            End If
        End If

        SendExp(index)
        SendPlayerData(index)

    End Sub

    Friend Sub CustomScript(index As Integer, caseId As Integer, mapNum As Integer, eventId As Integer)

        Select Case caseId

            Case Else
                PlayerMsg(index, "Você acabou de ativar o script customizado #" & caseId & ". Este script ainda não está programado.", ColorType.BrightRed)
        End Select

    End Sub

#End Region

End Module