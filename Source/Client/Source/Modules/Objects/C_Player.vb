﻿Imports System.Drawing
Imports ASFW
Imports SFML.Graphics
Imports SFML.Window

Module C_Player
#Region "Globals"
    Friend CharSelection() As CharSelRec
    Friend Player(MAX_PLAYERS) As PlayerRec
    Friend PlayerInv(MAX_INV) As PlayerInvStruct   ' Inventário
#End Region

#Region "Structs"
    Friend Structure CharSelRec
        Dim Name As String
        Dim Sprite As Integer
        Dim Gender As Integer
        Dim ClassName As String
        Dim Level As Integer
    End Structure

    Friend Structure PlayerRec

        ' Geral
        Dim Name As String

        Dim Classes As Byte
        Dim Sprite As Integer
        Dim Level As Byte
        Dim Exp As Integer
        Dim Access As Byte
        Dim Pk As Byte

        ' Vitais
        Dim Vital() As Integer

        ' Atributos
        Dim Stat() As Byte

        Dim Points As Byte

        ' Equipamento Usado
        Dim Equipment() As PlayerInvStruct

        ' Posição
        Dim Map As Integer

        Dim X As Byte
        Dim Y As Byte
        Dim Dir As Byte

        ' Apenas uso do cliente
        Dim MaxHp As Integer

        Dim MaxMp As Integer
        Dim MaxSp As Integer
        Dim XOffset As Integer
        Dim YOffset As Integer
        Dim Moving As Byte
        Dim Attacking As Byte
        Dim AttackTimer As Integer
        Dim MapGetTimer As Integer
        Dim Steps As Byte

        Dim Emote As Integer
        Dim EmoteTimer As Integer

        Dim PlayerQuest() As PlayerQuestRec

        'Moradia
        Dim House As PlayerHouseRec

        Dim InHouse As Integer
        Dim LastMap As Integer
        Dim LastX As Integer
        Dim LastY As Integer

        Dim Hotbar() As HotbarRec

        Dim EventTimer As Integer

        'gather skills
        Dim GatherSkills() As ResourceSkillsStruct

        Dim RecipeLearned() As Byte

        Dim Pet As PlayerPetRec
    End Structure
#End Region

#Region "Database"
    Sub ClearPlayers()
        Dim i As Integer

        ReDim Player(MAX_PLAYERS)

        For i = 1 To MAX_PLAYERS
            ClearPlayer(i)
        Next
    End Sub

    Sub ClearPlayer(index As Integer)
        Player(index).Name = ""
        Player(index).Access = 0
        Player(index).Attacking = 0
        Player(index).AttackTimer = 0
        Player(index).Classes = 0
        Player(index).Dir = 0

        ReDim Player(index).Equipment(EquipmentType.Count - 1)
        For y = 1 To EquipmentType.Count - 1
            Player(index).Equipment(y).Num = 0
        Next

        Player(index).Exp = 0
        Player(index).Level = 0
        Player(index).Map = 0
        Player(index).MapGetTimer = 0
        Player(index).MaxHp = 0
        Player(index).MaxMp = 0
        Player(index).MaxSp = 0
        Player(index).Moving = 0
        Player(index).Pk = 0
        Player(index).Points = 0
        Player(index).Sprite = 0

        ReDim Player(index).Stat(StatType.Count - 1)
        For x = 1 To StatType.Count - 1
            Player(index).Stat(x) = 0
        Next

        Player(index).Steps = 0

        ReDim Player(index).Vital(VitalType.Count - 1)
        For i = 1 To VitalType.Count - 1
            Player(index).Vital(i) = 0
        Next

        Player(index).X = 0
        Player(index).XOffset = 0
        Player(index).Y = 0
        Player(index).YOffset = 0

        For y = 1 To EquipmentType.Count - 1
            ReDim Player(index).Equipment(y).Stat(StatType.Count - 1)
            For x = 1 To StatType.Count - 1
                Player(index).Equipment(y).Stat(x) = 0
            Next
        Next

        For y = 1 To MAX_INV
            ReDim PlayerInv(y).Stat(StatType.Count - 1)
            For x = 1 To StatType.Count - 1
                PlayerInv(y).Stat(x) = 0
            Next
        Next

        ReDim Player(index).PlayerQuest(MaxQuests)

        ReDim Player(index).Hotbar(MaxHotbar)

        ReDim Player(index).GatherSkills(ResourceSkills.Count - 1)

        ReDim Player(index).RecipeLearned(MAX_RECIPE)

        'pets
        Player(index).Pet.Num = 0
        Player(index).Pet.Health = 0
        Player(index).Pet.Mana = 0
        Player(index).Pet.Level = 0

        ReDim Player(index).Pet.Stat(StatType.Count - 1)
        For i = 1 To StatType.Count - 1
            Player(index).Pet.Stat(i) = 0
        Next

        ReDim Player(index).Pet.Skill(4)
        For i = 1 To 4
            Player(index).Pet.Skill(i) = 0
        Next

        Player(index).Pet.X = 0
        Player(index).Pet.Y = 0
        Player(index).Pet.Dir = 0
        Player(index).Pet.MaxHp = 0
        Player(index).Pet.MaxMp = 0
        Player(index).Pet.Alive = 0
        Player(index).Pet.AttackBehaviour = 0
        Player(index).Pet.Exp = 0
        Player(index).Pet.Tnl = 0
    End Sub
#End Region

#Region "Movement"
    Sub CheckMovement()

        If IsTryingToMove() AndAlso CanMove() Then
            ' Ver se o jogador está segurando o shift -> correr 
            If VbKeyShift Then
                Player(Myindex).Moving = MovementType.Running
            Else
                Player(Myindex).Moving = MovementType.Walking
            End If

            If Map.Tile(GetPlayerX(Myindex), GetPlayerY(Myindex)).Type = TileType.Door Then
                With TempTile(GetPlayerX(Myindex), GetPlayerY(Myindex))
                    .DoorFrame = 1
                    .DoorAnimate = 1 ' 0 = nada| 1 = abrindo | 2 = fechando
                    .DoorTimer = GetTickCount()
                End With
            End If

            Select Case GetPlayerDir(Myindex)
                Case DirectionType.Up
                    SendPlayerMove()
                    Player(Myindex).YOffset = PicY
                    SetPlayerY(Myindex, GetPlayerY(Myindex) - 1)
                Case DirectionType.Down
                    SendPlayerMove()
                    Player(Myindex).YOffset = PicY * -1
                    SetPlayerY(Myindex, GetPlayerY(Myindex) + 1)
                Case DirectionType.Left
                    SendPlayerMove()
                    Player(Myindex).XOffset = PicX
                    SetPlayerX(Myindex, GetPlayerX(Myindex) - 1)
                Case DirectionType.Right
                    SendPlayerMove()
                    Player(Myindex).XOffset = PicX * -1
                    SetPlayerX(Myindex, GetPlayerX(Myindex) + 1)
            End Select

            If Player(Myindex).XOffset = 0 AndAlso Player(Myindex).YOffset = 0 Then
                If Map.Tile(GetPlayerX(Myindex), GetPlayerY(Myindex)).Type = TileType.Warp Then
                    GettingMap = True
                End If
            End If

        End If
    End Sub

    Function IsTryingToMove() As Boolean

        If DirUp OrElse DirDown OrElse DirLeft OrElse DirRight Then
            IsTryingToMove = True
        End If

    End Function

    Function CanMove() As Boolean
        Dim d As Integer
        CanMove = True

        If HoldPlayer = True Then
            CanMove = False
            Exit Function
        End If

        If GettingMap = True Then
            CanMove = False
            Exit Function
        End If

        ' Ter certeza que não estão tentando mover quando já estão movendo
        If Player(Myindex).Moving <> 0 Then
            CanMove = False
            Exit Function
        End If

        ' Ter certeza que nao acabaram de usar uma habilidade
        If SkillBuffer > 0 Then
            CanMove = False
            Exit Function
        End If

        ' Ter certeza que não estão estuporados
        If StunDuration > 0 Then
            CanMove = False
            Exit Function
        End If

        If InEvent Then
            CanMove = False
            Exit Function
        End If

        ' Artesanto
        If InCraft Then
            CanMove = False
            Exit Function
        End If

        ' Ter certeza que não está numa Loja
        If InShop > 0 Then
            CanMove = False
            Exit Function
        End If

        If InTrade Then
            CanMove = False
            Exit Function
        End If

        ' Não está em um banco
        If InBank > 0 Then
            CanMove = False
            Exit Function
        End If

        d = GetPlayerDir(Myindex)

        If DirUp Then
            SetPlayerDir(Myindex, DirectionType.Up)

            ' Ver se estão tentando sair dos limites
            If GetPlayerY(Myindex) > 0 Then
                If CheckDirection(DirectionType.Up) Then
                    CanMove = False

                    ' Setar nova direção se não estiverem olhando para ela 
                    If d <> DirectionType.Up Then
                        SendPlayerDir()
                    End If

                    Exit Function
                End If
            Else

                ' Ver se podem transportar para um novo mapa
                If Map.Up > 0 Then
                    SendPlayerRequestNewMap()
                    GettingMap = True
                    CanMoveNow = False
                End If

                CanMove = False
                Exit Function
            End If
        End If

        If DirDown Then
            SetPlayerDir(Myindex, DirectionType.Down)

            ' Ver se estão tentando sair dos limites
            If GetPlayerY(Myindex) < Map.MaxY Then
                If CheckDirection(DirectionType.Down) Then
                    CanMove = False

                    '  Setar nova direção se não estiverem olhadno para ela  
                    If d <> DirectionType.Down Then
                        SendPlayerDir()
                    End If

                    Exit Function
                End If
            Else

                ' Ver se podem teleportar para o novo mapa
                If Map.Down > 0 Then
                    SendPlayerRequestNewMap()
                    GettingMap = True
                    CanMoveNow = False
                End If

                CanMove = False
                Exit Function
            End If
        End If

        If DirLeft Then
            SetPlayerDir(Myindex, DirectionType.Left)

            ' Ver se estão tentando sair dos limites
            If GetPlayerX(Myindex) > 0 Then
                If CheckDirection(DirectionType.Left) Then
                    CanMove = False

                    ' Setar nova direção se não estiverem olhadno para ela
                    If d <> DirectionType.Left Then
                        SendPlayerDir()
                    End If

                    Exit Function
                End If
            Else

                ' Ver se podem teleportar para o novo mapa
                If Map.Left > 0 Then
                    SendPlayerRequestNewMap()
                    GettingMap = True
                    CanMoveNow = False
                End If

                CanMove = False
                Exit Function
            End If
        End If

        If DirRight Then
            SetPlayerDir(Myindex, DirectionType.Right)

            ' Ver se estão tentando sair dos limites
            If GetPlayerX(Myindex) < Map.MaxX Then
                If CheckDirection(DirectionType.Right) Then
                    CanMove = False

                    ' Setar nova direção se não estiverem olhadno para ela
                    If d <> DirectionType.Right Then
                        SendPlayerDir()
                    End If

                    Exit Function
                End If
            Else

                ' Ver se podem teleportar para o novo mapa
                If Map.Right > 0 Then
                    SendPlayerRequestNewMap()
                    GettingMap = True
                    CanMoveNow = False
                End If

                CanMove = False
                Exit Function
            End If
        End If

    End Function

    Function CheckDirection(direction As Byte) As Boolean
        Dim x As Integer, y As Integer
        Dim i As Integer, z As Integer

        CheckDirection = False

        ' Ver bloqueio direcional
        If IsDirBlocked(Map.Tile(GetPlayerX(Myindex), GetPlayerY(Myindex)).DirBlock, direction + 1) Then
            CheckDirection = True
            Exit Function
        End If

        Select Case direction
            Case modEnumerators.DirectionType.Up
                x = GetPlayerX(Myindex)
                y = GetPlayerY(Myindex) - 1
            Case modEnumerators.DirectionType.Down
                x = GetPlayerX(Myindex)
                y = GetPlayerY(Myindex) + 1
            Case modEnumerators.DirectionType.Left
                x = GetPlayerX(Myindex) - 1
                y = GetPlayerY(Myindex)
            Case modEnumerators.DirectionType.Right
                x = GetPlayerX(Myindex) + 1
                y = GetPlayerY(Myindex)
        End Select

        ' Ver se a tile do mapa está bloqueiada ou não
        If Map.Tile(x, y).Type = TileType.Blocked Then
            CheckDirection = True
            Exit Function
        End If

        ' Ver se a tile do mapa é uma árvore ou nãoC
        If Map.Tile(x, y).Type = TileType.Resource Then
            CheckDirection = True
            Exit Function
        End If

        ' Ver se a porta chave está aberta ou não
        If Map.Tile(x, y).Type = TileType.Key Then
            ' Isso ve se está aberta ou nao
            If TempTile(x, y).DoorOpen = False Then
                CheckDirection = True
                Exit Function
            End If
        End If

        If FurnitureHouse > 0 AndAlso FurnitureHouse = Player(Myindex).InHouse Then
            If FurnitureCount > 0 Then
                For i = 1 To FurnitureCount
                    If Item(Furniture(i).ItemNum).Data3 = 0 Then
                        If x >= Furniture(i).X AndAlso x <= Furniture(i).X + Item(Furniture(i).ItemNum).FurnitureWidth - 1 Then
                            If y <= Furniture(i).Y AndAlso y >= Furniture(i).Y - Item(Furniture(i).ItemNum).FurnitureHeight Then
                                z = Item(Furniture(i).ItemNum).FurnitureBlocks(x - Furniture(i).X, ((Furniture(i).Y - y) * -1) + Item(Furniture(i).ItemNum).FurnitureHeight)
                                If z = 1 Then CheckDirection = True : Exit Function
                            End If
                        End If
                    End If
                Next
            End If
        End If

        ' Ver se um jogador já está naquela tile
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) AndAlso GetPlayerMap(i) = GetPlayerMap(Myindex) Then
                If Player(i).InHouse = Player(Myindex).InHouse Then
                    If GetPlayerX(i) = x Then
                        If GetPlayerY(i) = y Then
                            CheckDirection = True
                            Exit Function
                        ElseIf Player(i).Pet.X = x AndAlso Player(i).Pet.Alive = True Then
                            If Player(i).Pet.Y = y Then
                                CheckDirection = True
                                Exit Function
                            End If
                        End If
                    ElseIf Player(i).Pet.X = x AndAlso Player(i).Pet.Y = y AndAlso Player(i).Pet.Alive = True Then
                        CheckDirection = True
                        Exit Function
                    End If
                End If
            End If
        Next

        ' Ver se um npc já está naquela tile ou não 
        For i = 1 To MAX_MAP_NPCS
            If MapNpc(i).Num > 0 AndAlso MapNpc(i).X = x AndAlso MapNpc(i).Y = y Then
                CheckDirection = True
                Exit Function
            End If
        Next

        For i = 1 To Map.CurrentEvents
            If Map.MapEvents(i).Visible = 1 Then
                If Map.MapEvents(i).X = x AndAlso Map.MapEvents(i).Y = y Then
                    If Map.MapEvents(i).WalkThrough = 0 Then
                        CheckDirection = True
                        Exit Function
                    End If
                End If
            End If
        Next

    End Function

    Sub ProcessMovement(index As Integer)
        Dim movementSpeed As Integer

        ' Ver se o  jogador está andando, e se sim processar o movimento
        Select Case Player(index).Moving
            Case MovementType.Walking : movementSpeed = ((ElapsedTime / 1000) * (WalkSpeed * SizeX))
            Case MovementType.Running : movementSpeed = ((ElapsedTime / 1000) * (RunSpeed * SizeX))
            Case Else : Exit Sub
        End Select

        Select Case GetPlayerDir(index)
            Case DirectionType.Up
                Player(index).YOffset = Player(index).YOffset - movementSpeed
                If Player(index).YOffset < 0 Then Player(index).YOffset = 0
            Case DirectionType.Down
                Player(index).YOffset = Player(index).YOffset + movementSpeed
                If Player(index).YOffset > 0 Then Player(index).YOffset = 0
            Case DirectionType.Left
                Player(index).XOffset = Player(index).XOffset - movementSpeed
                If Player(index).XOffset < 0 Then Player(index).XOffset = 0
            Case DirectionType.Right
                Player(index).XOffset = Player(index).XOffset + movementSpeed
                If Player(index).XOffset > 0 Then Player(index).XOffset = 0
        End Select

        ' Ver se completou o andamento para próxima tile
        If Player(index).Moving > 0 Then
            If GetPlayerDir(index) = DirectionType.Right OrElse GetPlayerDir(index) = DirectionType.Down Then
                If (Player(index).XOffset >= 0) AndAlso (Player(index).YOffset >= 0) Then
                    Player(index).Moving = 0
                    If Player(index).Steps = 0 Then
                        Player(index).Steps = 2
                    Else
                        Player(index).Steps = 0
                    End If
                End If
            Else
                If (Player(index).XOffset <= 0) AndAlso (Player(index).YOffset <= 0) Then
                    Player(index).Moving = 0
                    If Player(index).Steps = 0 Then
                        Player(index).Steps = 2
                    Else
                        Player(index).Steps = 0
                    End If
                End If
            End If
        End If

    End Sub

    Function GetPlayerDir(index As Integer) As Integer

        If index > MAX_PLAYERS Then Exit Function
        GetPlayerDir = Player(index).Dir
    End Function
#End Region

#Region "Attacking"
    Sub CheckAttack()
        Dim attackspeed As Integer, x As Integer, y As Integer
        Dim buffer As New ByteStream(4)

        If VbKeyControl Then
            If InEvent = True Then Exit Sub
            If SkillBuffer > 0 Then Exit Sub ' atualmente usnado habilidade, nao pode atacar
            If StunDuration > 0 Then Exit Sub ' estuporado, não pode atacar

            ' velocidade da arma
            If GetPlayerEquipment(Myindex, EquipmentType.Weapon) > 0 Then
                attackspeed = Item(GetPlayerEquipment(Myindex, EquipmentType.Weapon)).Speed * 1000
            Else
                attackspeed = 1000
            End If

            If Player(Myindex).AttackTimer + attackspeed < GetTickCount() Then
                If Player(Myindex).Attacking = 0 Then

                    With Player(Myindex)
                        .Attacking = 1
                        .AttackTimer = GetTickCount()
                    End With

                    SendAttack()
                End If
            End If

            Select Case Player(Myindex).Dir
                Case DirectionType.Up
                    x = GetPlayerX(Myindex)
                    y = GetPlayerY(Myindex) - 1
                Case DirectionType.Down
                    x = GetPlayerX(Myindex)
                    y = GetPlayerY(Myindex) + 1
                Case DirectionType.Left
                    x = GetPlayerX(Myindex) - 1
                    y = GetPlayerY(Myindex)
                Case DirectionType.Right
                    x = GetPlayerX(Myindex) + 1
                    y = GetPlayerY(Myindex)
            End Select

            If GetTickCount() > Player(Myindex).EventTimer Then
                For i = 1 To Map.CurrentEvents
                    If Map.MapEvents(i).Visible = 1 Then
                        If Map.MapEvents(i).X = x AndAlso Map.MapEvents(i).Y = y Then
                            buffer = New ByteStream(4)
                            buffer.WriteInt32(ClientPackets.CEvent)
                            buffer.WriteInt32(i)
                            Socket.SendData(buffer.Data, buffer.Head)
                            buffer.Dispose()
                            Player(Myindex).EventTimer = GetTickCount() + 200
                        End If
                    End If
                Next
            End If
        End If

    End Sub

    Friend Sub PlayerCastSkill(skillslot As Integer)
        Dim buffer As New ByteStream(4)

        ' Verificar por subscript out of range
        If skillslot < 1 OrElse skillslot > MAX_PLAYER_SKILLS Then Exit Sub

        If SkillCd(skillslot) > 0 Then
            AddText("A habilidade ainda não está preparada!", QColorType.AlertColor)
            Exit Sub
        End If

        ' Ver se tem MP suficiente
        If GetPlayerVital(Myindex, VitalType.MP) < Skill(PlayerSkills(skillslot)).MpCost Then
            AddText("Não tem mana suficiente para usar " & Trim$(Skill(PlayerSkills(skillslot)).Name) & ".", QColorType.AlertColor)
            Exit Sub
        End If

        If PlayerSkills(skillslot) > 0 Then
            If GetTickCount() > Player(Myindex).AttackTimer + 1000 Then
                If Player(Myindex).Moving = 0 Then
                    buffer.WriteInt32(ClientPackets.CCast)
                    buffer.WriteInt32(skillslot)

                    Socket.SendData(buffer.Data, buffer.Head)
                    buffer.Dispose()

                    SkillBuffer = skillslot
                    SkillBufferTimer = GetTickCount()
                Else
                    AddText("Não dá para usar a habilidade enquanto anda!", QColorType.AlertColor)
                End If
            End If
        Else
            AddText("Sem habilidade aqui.", QColorType.AlertColor)
        End If

    End Sub
#End Region

#Region "Data Set & Retrieval"
    Function IsPlaying(index As Integer) As Boolean

        ' Se o jogador não existe o nome é igual a zero
        If Len(GetPlayerName(index)) > 0 Then
            IsPlaying = True
        End If

    End Function

    Function GetPlayerName(index As Integer) As String
        GetPlayerName = ""
        If index > MAX_PLAYERS Then Exit Function
        GetPlayerName = Trim$(Player(index).Name)
    End Function

    Function GetPlayerGatherSkillLvl(index As Integer, skillSlot As Integer) As Integer

        GetPlayerGatherSkillLvl = 0

        If index > MAX_PLAYERS Then Exit Function

        GetPlayerGatherSkillLvl = Player(index).GatherSkills(skillSlot).SkillLevel
    End Function

    Function GetPlayerGatherSkillExp(index As Integer, skillSlot As Integer) As Integer

        GetPlayerGatherSkillExp = 0

        If index > MAX_PLAYERS Then Exit Function

        GetPlayerGatherSkillExp = Player(index).GatherSkills(skillSlot).SkillCurExp
    End Function

    Function GetPlayerGatherSkillMaxExp(index As Integer, skillSlot As Integer) As Integer

        GetPlayerGatherSkillMaxExp = 0

        If index > MAX_PLAYERS Then Exit Function

        GetPlayerGatherSkillMaxExp = Player(index).GatherSkills(skillSlot).SkillNextLvlExp
    End Function

    Sub SetPlayerMap(index As Integer, mapNum As Integer)
        If index > MAX_PLAYERS Then Exit Sub
        Player(index).Map = mapNum
    End Sub

    Function GetPlayerInvItemNum(index As Integer, invslot As Integer) As Integer
        GetPlayerInvItemNum = 0
        If index > MAX_PLAYERS Then Exit Function
        If invslot = 0 Then Exit Function
        GetPlayerInvItemNum = PlayerInv(invslot).Num
    End Function

    Sub SetPlayerName(index As Integer, name As String)
        If index > MAX_PLAYERS Then Exit Sub
        Player(index).Name = name
    End Sub

    Sub SetPlayerClass(index As Integer, classnum As Integer)
        If index > MAX_PLAYERS Then Exit Sub
        Player(index).Classes = classnum
    End Sub

    Sub SetPlayerPoints(index As Integer, points As Integer)
        If index > MAX_PLAYERS Then Exit Sub
        Player(index).Points = points
    End Sub

    Sub SetPlayerStat(index As Integer, stat As StatType, value As Integer)
        If index > MAX_PLAYERS Then Exit Sub
        If value <= 0 Then value = 1
        If value > Byte.MaxValue Then value = Byte.MaxValue
        Player(index).Stat(stat) = value
    End Sub

    Sub SetPlayerInvItemNum(index As Integer, invslot As Integer, itemnum As Integer)
        If index > MAX_PLAYERS Then Exit Sub
        PlayerInv(invslot).Num = itemnum
    End Sub

    Function GetPlayerInvItemValue(index As Integer, invslot As Integer) As Integer
        GetPlayerInvItemValue = 0
        If index > MAX_PLAYERS Then Exit Function
        GetPlayerInvItemValue = PlayerInv(invslot).Value
    End Function

    Sub SetPlayerInvItemValue(index As Integer, invslot As Integer, itemValue As Integer)
        If index > MAX_PLAYERS Then Exit Sub
        PlayerInv(invslot).Value = itemValue
    End Sub

    Function GetPlayerPoints(index As Integer) As Integer
        GetPlayerPoints = 0
        If index > MAX_PLAYERS Then Exit Function
        GetPlayerPoints = Player(index).Points
    End Function

    Sub SetPlayerAccess(index As Integer, access As Integer)
        If index > MAX_PLAYERS Then Exit Sub
        Player(index).Access = access
    End Sub

    Sub SetPlayerPk(index As Integer, pk As Integer)
        If index > MAX_PLAYERS Then Exit Sub
        Player(index).Pk = pk
    End Sub

    Sub SetPlayerVital(index As Integer, vital As VitalType, value As Integer)
        If index > MAX_PLAYERS Then Exit Sub
        Player(index).Vital(vital) = value

        If GetPlayerVital(index, vital) > GetPlayerMaxVital(index, vital) Then
            Player(index).Vital(vital) = GetPlayerMaxVital(index, vital)
        End If
    End Sub

    Function GetPlayerMaxVital(index As Integer, vital As VitalType) As Integer
        GetPlayerMaxVital = 0
        If index > MAX_PLAYERS Then Exit Function

        Select Case vital
            Case VitalType.HP
                GetPlayerMaxVital = Player(index).MaxHp
            Case VitalType.MP
                GetPlayerMaxVital = Player(index).MaxMp
            Case VitalType.SP
                GetPlayerMaxVital = Player(index).MaxSp
        End Select

    End Function

    Sub SetPlayerX(index As Integer, x As Integer)
        If index > MAX_PLAYERS Then Exit Sub
        Player(index).X = x
    End Sub

    Sub SetPlayerY(index As Integer, y As Integer)
        If index > MAX_PLAYERS Then Exit Sub
        Player(index).Y = y
    End Sub

    Sub SetPlayerSprite(index As Integer, sprite As Integer)
        If index > MAX_PLAYERS Then Exit Sub
        Player(index).Sprite = sprite
    End Sub

    Sub SetPlayerExp(index As Integer, exp As Integer)
        If index > MAX_PLAYERS Then Exit Sub
        Player(index).Exp = exp
    End Sub

    Sub SetPlayerLevel(index As Integer, level As Integer)
        If index > MAX_PLAYERS Then Exit Sub
        Player(index).Level = level
    End Sub

    Sub SetPlayerDir(index As Integer, dir As Integer)
        If index > MAX_PLAYERS Then Exit Sub
        Player(index).Dir = dir
    End Sub

    Function GetPlayerVital(index As Integer, vital As VitalType) As Integer
        GetPlayerVital = 0
        If index > MAX_PLAYERS Then Exit Function
        GetPlayerVital = Player(index).Vital(vital)
    End Function

    Function GetPlayerSprite(index As Integer) As Integer
        GetPlayerSprite = 0
        If index > MAX_PLAYERS Then Exit Function
        GetPlayerSprite = Player(index).Sprite
    End Function

    Function GetPlayerClass(index As Integer) As Integer
        GetPlayerClass = 0
        If index > MAX_PLAYERS Then Exit Function
        GetPlayerClass = Player(index).Classes
    End Function

    Function GetPlayerMap(index As Integer) As Integer
        GetPlayerMap = 0
        If index > MAX_PLAYERS Then Exit Function
        GetPlayerMap = Player(index).Map
    End Function

    Function GetPlayerLevel(index As Integer) As Integer
        GetPlayerLevel = 0
        If index > MAX_PLAYERS Then Exit Function
        GetPlayerLevel = Player(index).Level
    End Function

    Function GetPlayerEquipment(index As Integer, equipmentSlot As EquipmentType) As Byte
        GetPlayerEquipment = 0
        If index > MAX_PLAYERS Then Exit Function
        GetPlayerEquipment = Player(index).Equipment(equipmentSlot).Num
    End Function

    Function GetPlayerStat(index As Integer, stat As StatType) As Integer
        GetPlayerStat = 0
        If index > MAX_PLAYERS Then Exit Function
        GetPlayerStat = Player(index).Stat(stat)
    End Function

    Function GetPlayerExp(index As Integer) As Integer
        If index > MAX_PLAYERS Then Exit Function
        GetPlayerExp = Player(index).Exp
    End Function

    Function GetPlayerX(index As Integer) As Integer
        GetPlayerX = 0
        If index > MAX_PLAYERS Then Exit Function
        GetPlayerX = Player(index).X
    End Function

    Function GetPlayerY(index As Integer) As Integer
        GetPlayerY = 0
        If index > MAX_PLAYERS Then Exit Function
        GetPlayerY = Player(index).Y
    End Function

    Function GetPlayerAccess(index As Integer) As Integer
        GetPlayerAccess = 0
        If index > MAX_PLAYERS Then Exit Function
        GetPlayerAccess = Player(index).Access
    End Function

    Function GetPlayerPk(index As Integer) As Integer
        GetPlayerPk = 0
        If index > MAX_PLAYERS Then Exit Function
        GetPlayerPk = Player(index).Pk
    End Function

    Sub SetPlayerEquipment(index As Integer, invNum As Integer, equipmentSlot As EquipmentType)
        If index < 1 OrElse index > MAX_PLAYERS Then Exit Sub
        Player(index).Equipment(equipmentSlot).Num = invNum
    End Sub
#End Region

#Region "Drawing"
    Friend Sub DrawPlayer(index As Integer)
        Dim anim As Byte, x As Integer, y As Integer
        Dim spritenum As Integer, spriteleft As Integer
        Dim attackspeed As Integer
        Dim srcrec As Rectangle

        spritenum = GetPlayerSprite(index)

        If spritenum < 1 OrElse spritenum > NumCharacters Then Exit Sub

        ' velocidade da arma
        If GetPlayerEquipment(index, EquipmentType.Weapon) > 0 Then
            attackspeed = Item(GetPlayerEquipment(index, EquipmentType.Weapon)).Speed
        Else
            attackspeed = 1000
        End If

        ' Resetar frame
        anim = 1

        ' Verificar pela animação de ataque
        If Player(index).AttackTimer + (attackspeed / 2) > GetTickCount() Then
            If Player(index).Attacking = 1 Then
                anim = 2
            End If
        Else
            ' Se não estiver atacando, andar normalmente
            Select Case GetPlayerDir(index)
                Case DirectionType.Up

                    If (Player(index).YOffset > 8) Then anim = Player(index).Steps
                Case DirectionType.Down

                    If (Player(index).YOffset < -8) Then anim = Player(index).Steps
                Case DirectionType.Left

                    If (Player(index).XOffset > 8) Then anim = Player(index).Steps
                Case DirectionType.Right

                    If (Player(index).XOffset < -8) Then anim = Player(index).Steps
            End Select
        End If

        ' Ver se queremos parar de fazê-lo atacar 
        With Player(index)
            If .AttackTimer + attackspeed < GetTickCount() Then
                .Attacking = 0
                .AttackTimer = 0
            End If
        End With

        ' Setar a esquerda
        Select Case GetPlayerDir(index)
            Case DirectionType.Up
                spriteleft = 3
            Case DirectionType.Right
                spriteleft = 2
            Case DirectionType.Down
                spriteleft = 0
            Case DirectionType.Left
                spriteleft = 1
        End Select

        srcrec = New Rectangle((anim) * (CharacterGfxInfo(spritenum).Width / 3), spriteleft * (CharacterGfxInfo(spritenum).Height / 4), (CharacterGfxInfo(spritenum).Width / 3), (CharacterGfxInfo(spritenum).Height / 4))

        ' Calcular o X
        x = GetPlayerX(index) * PicX + Player(index).XOffset - ((CharacterGfxInfo(spritenum).Width / 3 - 32) / 2)

        ' Se a altura do jogador é maior que 32...
        If (CharacterGfxInfo(spritenum).Height) > 32 Then
            ' Criar um offset de 32 pixels para sprites maiores
            y = GetPlayerY(index) * PicY + Player(index).YOffset - ((CharacterGfxInfo(spritenum).Height / 4) - 32)
        Else
            ' Proceder normalmente
            y = GetPlayerY(index) * PicY + Player(index).YOffset
        End If

        ' Renderizar a sprite do personagem
        DrawCharacter(spritenum, x, y, srcrec)

        'Verificar paperdoll
        For i = 1 To EquipmentType.Count - 1
            If GetPlayerEquipment(index, i) > 0 Then
                If Item(GetPlayerEquipment(index, i)).Paperdoll > 0 Then
                    DrawPaperdoll(x, y, Item(GetPlayerEquipment(index, i)).Paperdoll, anim, spriteleft)
                End If
            End If
        Next

        ' Verificar se queremos parar de mostrar emotes
        With Player(index)
            If .EmoteTimer < GetTickCount() Then
                .Emote = 0
                .EmoteTimer = 0
            End If
        End With

        'Verificar emotes
        'Player(Index).Emote = 4
        If Player(index).Emote > 0 Then
            DrawEmotes(x, y, Player(index).Emote)
        End If
    End Sub

    Friend Sub DrawPlayerName(index As Integer)
        Dim textX As Integer
        Dim textY As Integer
        Dim color As SFML.Graphics.Color, backcolor As SFML.Graphics.Color
        Dim name As String

        ' Verificar nível de acesso
        If GetPlayerPk(index) = False Then

            Select Case GetPlayerAccess(index)
                Case AdminType.Player
                    color = SFML.Graphics.Color.Red
                    backcolor = SFML.Graphics.Color.Black
                Case AdminType.Monitor
                    color = SFML.Graphics.Color.Black
                    backcolor = SFML.Graphics.Color.White
                Case AdminType.Mapper
                    color = SFML.Graphics.Color.Cyan
                    backcolor = SFML.Graphics.Color.Black
                Case AdminType.Developer
                    color = SFML.Graphics.Color.Green
                    backcolor = SFML.Graphics.Color.Black
                Case AdminType.Creator
                    color = SFML.Graphics.Color.Yellow
                    backcolor = SFML.Graphics.Color.Black
            End Select
        Else
            color = SFML.Graphics.Color.Red
        End If

        name = Trim$(Player(index).Name)
        ' Calcular  posição
        textX = ConvertMapX(GetPlayerX(index) * PicX) + Player(index).XOffset + (PicX \ 2)
        textX = textX - (GetTextWidth((Trim$(name))) / 2)
        If GetPlayerSprite(index) < 1 OrElse GetPlayerSprite(index) > NumCharacters Then
            textY = ConvertMapY(GetPlayerY(index) * PicY) + Player(index).YOffset - 16
        Else
            ' Determinar localização para o texto
            textY = ConvertMapY(GetPlayerY(index) * PicY) + Player(index).YOffset - (CharacterGfxInfo(GetPlayerSprite(index)).Height / 4) + 16
        End If

        ' Desenhar o nome
        DrawText(textX, textY, Trim$(name), color, backcolor, GameWindow)
    End Sub

    Sub DrawEquipment()
        Dim i As Integer, itemnum As Integer, itempic As Integer, tmprarity As Byte
        Dim rec As Rectangle, recPos As Rectangle, playersprite As Integer
        Dim tmpSprite2 As Sprite = New Sprite(CharPanelGfx)
        Dim tempRarityColor As SFML.Graphics.Color

        If NumItems = 0 Then Exit Sub

        'Primeiramente renderizar o painel
        RenderSprite(CharPanelSprite, GameWindow, CharWindowX, CharWindowY, 0, 0, CharPanelGfxInfo.Width, CharPanelGfxInfo.Height)

        'Vamos botar a sprite od jogador para renderizar
        playersprite = GetPlayerSprite(Myindex)

        With rec
            .Y = 0
            .Height = CharacterGfxInfo(playersprite).Height / 4
            .X = 0
            .Width = CharacterGfxInfo(playersprite).Width / 4
        End With

        RenderSprite(CharacterSprite(playersprite), GameWindow, CharWindowX + CharPanelGfxInfo.Width / 4 - rec.Width / 2, CharWindowY + CharPanelGfxInfo.Height / 2 - rec.Height / 2, rec.X, rec.Y, rec.Width, rec.Height)

        For i = 1 To EquipmentType.Count - 1
            itemnum = GetPlayerEquipment(Myindex, i)

            If itemnum > 0 Then

                itempic = Item(itemnum).Pic

                If ItemsGfxInfo(itempic).IsLoaded = False Then
                    LoadTexture(itempic, TextureType.Items)
                End If

                'Vendo que ainda vamos utilizar, atualizar temporizador
                With ItemsGfxInfo(itempic)
                    .TextureTimer = GetTickCount() + 100000
                End With

                With rec
                    .Y = 0
                    .Height = 32
                    .X = 0
                    .Width = 32
                End With

                With recPos
                    .Y = CharWindowY + EqTop + ((EqOffsetY + 32) * ((i - 1) \ EqColumns))
                    .Height = PicY
                    .X = CharWindowX + EqLeft + 1 + ((EqOffsetX + 32 - 2) * (((i - 1) Mod EqColumns)))
                    .Width = PicX
                End With

                ItemsSprite(itempic).TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
                ItemsSprite(itempic).Position = New Vector2f(recPos.X, recPos.Y)
                GameWindow.Draw(ItemsSprite(itempic))

                ' Setar o nome
                If Item(itemnum).Randomize <> 0 Then
                    tmprarity = Player(Myindex).Equipment(i).Rarity
                Else
                    tmprarity = Item(itemnum).Rarity
                End If

                Select Case tmprarity
                    Case 0 ' Branco
                        tempRarityColor = ItemRarityColor0
                    Case 1 ' Verde
                        tempRarityColor = ItemRarityColor1
                    Case 2 ' Azul
                        tempRarityColor = ItemRarityColor2
                    Case 3 ' Marrom
                        tempRarityColor = ItemRarityColor3
                    Case 4 ' Roxo
                        tempRarityColor = ItemRarityColor4
                    Case 5 'Ouro
                        tempRarityColor = ItemRarityColor5
                End Select

                Dim rec2 As New RectangleShape With {
                    .OutlineColor = New SFML.Graphics.Color(tempRarityColor),
                    .OutlineThickness = 2,
                    .FillColor = New SFML.Graphics.Color(SFML.Graphics.Color.Transparent),
                    .Size = New Vector2f(30, 30),
                    .Position = New Vector2f(recPos.X, recPos.Y)
                }
                GameWindow.Draw(rec2)
            End If

        Next

        ' Setar janelas dos personagens
        'nome
        DrawText(CharWindowX + 10, CharWindowY + 14, Language.Character.name & GetPlayerName(Myindex), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'classe
        DrawText(CharWindowX + 10, CharWindowY + 33, Language.Character.ClassType & Trim(Classes(GetPlayerClass(Myindex)).Name), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'nível
        DrawText(CharWindowX + 150, CharWindowY + 14, Language.Character.Level & GetPlayerLevel(Myindex), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'pontos
        DrawText(CharWindowX + 6, CharWindowY + 200, Language.Character.Points & GetPlayerPoints(Myindex), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        'cabeçalho
        DrawText(CharWindowX + 250, CharWindowY + 14, Language.Character.StatsLabel, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        'atributos de força
        DrawText(CharWindowX + 210, CharWindowY + 30, Language.Character.Strength & GetPlayerStat(Myindex, StatType.Strength), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 11)
        'atributos de resistência
        DrawText(CharWindowX + 210, CharWindowY + 50, Language.Character.endurance & GetPlayerStat(Myindex, StatType.Endurance), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 11)
        'atributo de vitalidade
        DrawText(CharWindowX + 210, CharWindowY + 70, Language.Character.Vitality & GetPlayerStat(Myindex, StatType.Vitality), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 11)
        'atributo de inteligência
        DrawText(CharWindowX + 210, CharWindowY + 90, Language.Character.intelligence & GetPlayerStat(Myindex, StatType.Intelligence), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 11)
        'atributo de sorte
        DrawText(CharWindowX + 210, CharWindowY + 110, Language.Character.Luck & GetPlayerStat(Myindex, StatType.Luck), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 11)
        'atributo de espírito
        DrawText(CharWindowX + 210, CharWindowY + 130, Language.Character.spirit & GetPlayerStat(Myindex, StatType.Spirit), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 11)

        If GetPlayerPoints(Myindex) > 0 Then
            'aumento de força
            RenderSprite(CharPanelPlusSprite, GameWindow, CharWindowX + StrengthUpgradeX, CharWindowY + StrengthUpgradeY + 4, 0, 0, CharPanelPlusGfxInfo.Width, CharPanelPlusGfxInfo.Height)
            'aumento de resistencia
            RenderSprite(CharPanelPlusSprite, GameWindow, CharWindowX + EnduranceUpgradeX, CharWindowY + EnduranceUpgradeY + 4, 0, 0, CharPanelPlusGfxInfo.Width, CharPanelPlusGfxInfo.Height)
            'aumento de vitalidade
            RenderSprite(CharPanelPlusSprite, GameWindow, CharWindowX + VitalityUpgradeX, CharWindowY + VitalityUpgradeY + 4, 0, 0, CharPanelPlusGfxInfo.Width, CharPanelPlusGfxInfo.Height)
            'aumento de inteligencia
            RenderSprite(CharPanelPlusSprite, GameWindow, CharWindowX + IntellectUpgradeX, CharWindowY + IntellectUpgradeY + 4, 0, 0, CharPanelPlusGfxInfo.Width, CharPanelPlusGfxInfo.Height)
            'aumento de força de vontade
            RenderSprite(CharPanelPlusSprite, GameWindow, CharWindowX + LuckUpgradeX, CharWindowY + LuckUpgradeY + 4, 0, 0, CharPanelPlusGfxInfo.Width, CharPanelPlusGfxInfo.Height)
            'aumento de espirtio
            RenderSprite(CharPanelPlusSprite, GameWindow, CharWindowX + SpiritUpgradeX, CharWindowY + SpiritUpgradeY + 4, 0, 0, CharPanelPlusGfxInfo.Width, CharPanelPlusGfxInfo.Height)
        End If

        'habilidades de pegar
        'cabeçalho
        DrawText(CharWindowX + 250, CharWindowY + 145, Language.Character.SkillLabel, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'herbalista
        DrawText(CharWindowX + 210, CharWindowY + 164, String.Format(Language.Character.Herbalist & GetPlayerGatherSkillLvl(Myindex, ResourceSkills.Herbalist)) & Language.Character.Exp & GetPlayerGatherSkillExp(Myindex, ResourceSkills.Herbalist) & "/" & GetPlayerGatherSkillMaxExp(Myindex, ResourceSkills.Herbalist), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 11)
        'lenhador
        DrawText(CharWindowX + 210, CharWindowY + 184, String.Format(Language.Character.Woodcutter & GetPlayerGatherSkillLvl(Myindex, ResourceSkills.WoodCutter)) & Language.Character.Exp & GetPlayerGatherSkillExp(Myindex, ResourceSkills.WoodCutter) & "/" & GetPlayerGatherSkillMaxExp(Myindex, ResourceSkills.WoodCutter), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 11)
        'mineração
        DrawText(CharWindowX + 210, CharWindowY + 204, String.Format(Language.Character.Miner & GetPlayerGatherSkillLvl(Myindex, ResourceSkills.Miner)) & Language.Character.Exp & GetPlayerGatherSkillExp(Myindex, ResourceSkills.Miner) & "/" & GetPlayerGatherSkillMaxExp(Myindex, ResourceSkills.Miner), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 11)
        'pesca
        DrawText(CharWindowX + 210, CharWindowY + 224, String.Format(Language.Character.Fisherman & GetPlayerGatherSkillLvl(Myindex, ResourceSkills.Fisherman)) & Language.Character.Exp & GetPlayerGatherSkillExp(Myindex, ResourceSkills.Fisherman) & "/" & GetPlayerGatherSkillMaxExp(Myindex, ResourceSkills.Fisherman), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 11)
    End Sub
#End Region

#Region "Outgoing Traffic"

#End Region

#Region "Incoming Traffic"
    Sub Packet_PlayerHP(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        Player(Myindex).MaxHp = buffer.ReadInt32

        SetPlayerVital(Myindex, VitalType.HP, buffer.ReadInt32)

        If GetPlayerMaxVital(Myindex, VitalType.HP) > 0 Then
            LblHpText = GetPlayerVital(Myindex, VitalType.HP) & "/" & GetPlayerMaxVital(Myindex, VitalType.HP)
            ' barra de hp
            PicHpWidth = Int(((GetPlayerVital(Myindex, VitalType.HP) / 169) / (GetPlayerMaxVital(Myindex, VitalType.HP) / 169)) * 169)
        End If

        buffer.Dispose()
    End Sub

    Sub Packet_PlayerMP(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        Player(Myindex).MaxMp = buffer.ReadInt32
        SetPlayerVital(Myindex, VitalType.MP, buffer.ReadInt32)

        If GetPlayerMaxVital(Myindex, VitalType.MP) > 0 Then
            LblManaText = GetPlayerVital(Myindex, VitalType.MP) & "/" & GetPlayerMaxVital(Myindex, VitalType.MP)
            ' mp bar
            PicManaWidth = Int(((GetPlayerVital(Myindex, VitalType.MP) / 169) / (GetPlayerMaxVital(Myindex, VitalType.MP) / 169)) * 169)
        End If

        buffer.Dispose()
    End Sub

    Sub Packet_PlayerSP(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        Player(Myindex).MaxSp = buffer.ReadInt32
        SetPlayerVital(Myindex, VitalType.SP, buffer.ReadInt32)

        buffer.Dispose()
    End Sub

    Sub Packet_PlayerStats(ByRef data() As Byte)
        Dim i As Integer, index As Integer
        Dim buffer As New ByteStream(data)
        index = buffer.ReadInt32
        For i = 1 To StatType.Count - 1
            SetPlayerStat(index, i, buffer.ReadInt32)
        Next
        UpdateCharacterPanel = True

        buffer.Dispose()
    End Sub

    Sub Packet_PlayerData(ByRef data() As Byte)
        Dim i As Integer, x As Integer
        Dim buffer As New ByteStream(data)
        i = buffer.ReadInt32
        SetPlayerName(i, buffer.ReadString)
        SetPlayerClass(i, buffer.ReadInt32)
        SetPlayerLevel(i, buffer.ReadInt32)
        SetPlayerPoints(i, buffer.ReadInt32)
        SetPlayerSprite(i, buffer.ReadInt32)
        SetPlayerMap(i, buffer.ReadInt32)
        SetPlayerX(i, buffer.ReadInt32)
        SetPlayerY(i, buffer.ReadInt32)
        SetPlayerDir(i, buffer.ReadInt32)
        SetPlayerAccess(i, buffer.ReadInt32)
        SetPlayerPk(i, buffer.ReadInt32)

        For x = 1 To StatType.Count - 1
            SetPlayerStat(i, x, buffer.ReadInt32)
        Next

        Player(i).InHouse = buffer.ReadInt32

        For x = 0 To ResourceSkills.Count - 1
            Player(i).GatherSkills(x).SkillLevel = buffer.ReadInt32
            Player(i).GatherSkills(x).SkillCurExp = buffer.ReadInt32
            Player(i).GatherSkills(x).SkillNextLvlExp = buffer.ReadInt32
        Next

        For x = 1 To MAX_RECIPE
            Player(i).RecipeLearned(x) = buffer.ReadInt32
        Next

        ' Ver se o jogador é o jogador cliente
        If i = Myindex Then
            ' resetar direções
            DirUp = False
            DirDown = False
            DirLeft = False
            DirRight = False

            UpdateCharacterPanel = True
        End If

        ' Ter certeza que não estão andando
        Player(i).Moving = 0
        Player(i).XOffset = 0
        Player(i).YOffset = 0

        If i = Myindex Then PlayerData = True

        buffer.Dispose()
    End Sub

    Sub Packet_PlayerMove(ByRef data() As Byte)
        Dim i As Integer, x As Integer, y As Integer
        Dim dir As Integer, n As Byte
        Dim buffer As New ByteStream(data)
        i = buffer.ReadInt32
        x = buffer.ReadInt32
        y = buffer.ReadInt32
        dir = buffer.ReadInt32
        n = buffer.ReadInt32

        SetPlayerX(i, x)
        SetPlayerY(i, y)
        SetPlayerDir(i, dir)
        Player(i).XOffset = 0
        Player(i).YOffset = 0
        Player(i).Moving = n

        Select Case GetPlayerDir(i)
            Case DirectionType.Up
                Player(i).YOffset = PicY
            Case DirectionType.Down
                Player(i).YOffset = PicY * -1
            Case DirectionType.Left
                Player(i).XOffset = PicX
            Case DirectionType.Right
                Player(i).XOffset = PicX * -1
        End Select

        buffer.Dispose()
    End Sub

    Sub Packet_PlayerDir(ByRef data() As Byte)
        Dim dir As Integer, i As Integer
        Dim buffer As New ByteStream(data)
        i = buffer.ReadInt32
        dir = buffer.ReadInt32

        SetPlayerDir(i, dir)

        With Player(i)
            .XOffset = 0
            .YOffset = 0
            .Moving = 0
        End With

        buffer.Dispose()
    End Sub

    Sub Packet_PlayerExp(ByRef data() As Byte)
        Dim index As Integer, tnl As Integer
        Dim buffer As New ByteStream(data)
        index = buffer.ReadInt32
        SetPlayerExp(index, buffer.ReadInt32)
        tnl = buffer.ReadInt32

        If tnl = 0 Then tnl = 1
        NextlevelExp = tnl

        buffer.Dispose()
    End Sub

    Sub Packet_PlayerXY(ByRef data() As Byte)
        Dim x As Integer, y As Integer, dir As Integer
        Dim buffer As New ByteStream(data)
        x = buffer.ReadInt32
        y = buffer.ReadInt32
        dir = buffer.ReadInt32

        SetPlayerX(Myindex, x)
        SetPlayerY(Myindex, y)
        SetPlayerDir(Myindex, dir)

        ' Ter certeza que nao estao andando
        Player(Myindex).Moving = 0
        Player(Myindex).XOffset = 0
        Player(Myindex).YOffset = 0

        buffer.Dispose()
    End Sub
#End Region

End Module