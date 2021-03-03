Imports System.IO
Imports ASFW
Imports ASFW.IO.FileIO

Module S_Pets

#Region "Declarations"

    Friend Pet() As PetRec

    ' Constantes do sistema de Pets
    Friend Const PetBehaviourFollow As Byte = 0 'O pet irá atacar todos os NPCs ao redor
    Friend Const PetBehaviourGoto As Byte = 1 'Se atacado, o pet lutará de volta
    Friend Const PetAttackBehaviourAttackonsight As Byte = 2 'O pet irá atacar todos os NPCs ao redor
    Friend Const PetAttackBehaviourGuard As Byte = 3 'Se atacado, o pet lutará de volta
    Friend Const PetAttackBehaviourDonothing As Byte = 4 'O pet não atacará mesmo se atacado

    Friend givePetHpTimer As Integer

    <Serializable>
    Friend Structure PlayerPetRec

        Dim Num As Integer
        Dim Health As Integer
        Dim Mana As Integer
        Dim Level As Integer
        Dim Stat() As Byte
        Dim Skill() As Integer
        Dim X As Integer
        Dim Y As Integer
        Dim Dir As Integer
        Dim Alive As Byte
        Dim AttackBehaviour As Integer
        Dim AdoptiveStats As Byte
        Dim Points As Integer
        Dim Exp As Integer

    End Structure

#End Region

#Region "Database"

    Sub SavePets()
        Dim i As Integer

        For i = 1 To MAX_PETS
            SavePet(i)
            Application.DoEvents()
        Next

    End Sub

    Sub SavePet(petNum As Integer)
        Dim filename As String ', i As Integer

        filename = Path.Pet(petNum)

        SaveObject(Pet(petNum), filename)

    End Sub

    Sub LoadPets()
        Dim i As Integer

        ClearPets()
        CheckPets()

        For i = 1 To MAX_PETS
            LoadPet(i)
        Next
        'SavePets()
    End Sub

    Sub LoadPet(petNum As Integer)
        Dim reader As New ByteStream()
        Dim filename As String ', i As Integer

        filename = Path.Pet(petNum)

        LoadObject(Pet(petNum), filename)

    End Sub

    Sub CheckPets()
        For i = 1 To MAX_PETS
            If Not File.Exists(Path.Pet(i)) Then
                SavePet(i)
            End If
        Next
    End Sub

    Sub ClearPet(petNum As Integer)

        Pet(petNum).Name = ""

        ReDim Pet(petNum).Stat(StatType.Count - 1)
        ReDim Pet(petNum).Skill(4)
    End Sub

    Sub ClearPets()
        Dim i As Integer

        ReDim Pet(MAX_PETS)
        For i = 1 To MAX_PETS
            ClearPet(i)
        Next

    End Sub

#End Region

#Region "Outgoing Packets"

    Sub SendPets(index As Integer)
        Dim i As Integer

        For i = 1 To MAX_PETS
            If Pet(i).Name.Length > 0 Then
                SendUpdatePetTo(index, i)
            End If
        Next

    End Sub

    Sub SendUpdatePetToAll(petNum As Integer)
        Dim buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SUpdatePet)

        buffer.WriteInt32(petNum)
        buffer.WriteBlock(SerializeData(Pet(petNum)))

        SendDataToAll(buffer.Data, buffer.Head)

        buffer.Dispose()

    End Sub

    Sub SendUpdatePetTo(index As Integer, petNum As Integer)
        Dim buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SUpdatePet)

        buffer.WriteInt32(petNum)

        buffer.WriteBlock(SerializeData(Pet(petNum)))

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()

    End Sub

    Friend Sub SendUpdatePlayerPet(index As Integer, ownerOnly As Boolean)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SUpdatePlayerPet)

        buffer.WriteInt32(index)

        buffer.WriteInt32(GetPetNum(index))
        buffer.WriteInt32(GetPetVital(index, VitalType.HP))
        buffer.WriteInt32(GetPetVital(index, VitalType.MP))
        buffer.WriteInt32(GetPetLevel(index))

        For i = 1 To StatType.Count - 1
            buffer.WriteInt32(GetPetStat(index, i))
        Next

        For i = 1 To 4
            buffer.WriteInt32(Player(index).Character(TempPlayer(index).CurChar).Pet.Skill(i))
        Next

        buffer.WriteInt32(GetPetX(index))
        buffer.WriteInt32(GetPetY(index))
        buffer.WriteInt32(GetPetDir(index))

        buffer.WriteInt32(GetPetMaxVital(index, VitalType.HP))
        buffer.WriteInt32(GetPetMaxVital(index, VitalType.MP))

        buffer.WriteInt32(Player(index).Character(TempPlayer(index).CurChar).Pet.Alive)

        buffer.WriteInt32(GetPetBehaviour(index))
        buffer.WriteInt32(GetPetPoints(index))
        buffer.WriteInt32(GetPetExp(index))
        buffer.WriteInt32(GetPetNextLevel(index))

        If ownerOnly Then
            Socket.SendDataTo(index, buffer.Data, buffer.Head)
        Else
            SendDataToMap(GetPlayerMap(index), buffer.Data, buffer.Head)
        End If

        buffer.Dispose()
    End Sub

    Sub SendPetAttack(index As Integer, mapNum As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SPetAttack)
        buffer.WriteInt32(index)
        SendDataToMap(mapNum, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendPetXy(index As Integer, x As Integer, y As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SPetXY)
        buffer.WriteInt32(index)
        buffer.WriteInt32(x)
        buffer.WriteInt32(y)
        SendDataToMap(GetPlayerMap(index), buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendPetExp(index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SPetExp)
        buffer.WriteInt32(GetPetExp(index))
        buffer.WriteInt32(GetPetNextLevel(index))
        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendPetVital(index As Integer, vital As VitalType)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SPetVital)

        buffer.WriteInt32(index)

        If vital = VitalType.HP Then
            buffer.WriteInt32(1)
        ElseIf vital = VitalType.MP Then
            buffer.WriteInt32(2)
        End If

        Select Case vital
            Case VitalType.HP
                buffer.WriteInt32(GetPetMaxVital(index, VitalType.HP))
                buffer.WriteInt32(GetPetVital(index, VitalType.HP))

            Case VitalType.MP
                buffer.WriteInt32(GetPetMaxVital(index, VitalType.MP))
                buffer.WriteInt32(GetPetVital(index, VitalType.MP))
        End Select

        SendDataToMap(GetPlayerMap(index), buffer.Data, buffer.Head)

        buffer.Dispose()

    End Sub

    Sub SendClearPetSpellBuffer(index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SClearPetSkillBuffer)

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()

    End Sub

#End Region

#Region "Incoming Packets"

    Sub Packet_RequestEditPet(index As Integer, ByRef data() As Byte)
        Dim buffer = New ByteStream(4)

        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub

        buffer.WriteInt32(ServerPackets.SPetEditor)
        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()

    End Sub

    Sub Packet_SavePet(index As Integer, ByRef data() As Byte)
        Dim petNum As Integer
        Dim buffer As New ByteStream(data)

        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub

        petNum = buffer.ReadInt32

        ' Prevenir hacking
        If petNum < 0 OrElse petNum > MAX_PETS Then Exit Sub

        Pet(petNum) = DeserializeData(buffer)

        ' Save it
        SendUpdatePetToAll(petNum)
        SavePet(petNum)
        Addlog(GetPlayerLogin(index) & " salvou o Pet #" & petNum & ".", ADMIN_LOG)
        SendPets(index)
    End Sub

    Sub Packet_RequestPets(index As Integer, ByRef data() As Byte)

        SendPets(index)

    End Sub

    Sub Packet_SummonPet(index As Integer, ByRef data() As Byte)
        If PetAlive(index) Then
            ReCallPet(index)
        Else
            SummonPet(index)
        End If
    End Sub

    Sub Packet_PetMove(index As Integer, ByRef data() As Byte)
        Dim x As Integer, y As Integer, i As Integer
        Dim buffer As New ByteStream(data)
        x = buffer.ReadInt32
        y = buffer.ReadInt32

        ' Prevenir subscript out of range
        If x < 0 OrElse x > Map(GetPlayerMap(index)).MaxX OrElse y < 0 OrElse y > Map(GetPlayerMap(index)).MaxY Then Exit Sub

        ' Verificar por um jogador
        For i = 1 To GetPlayersOnline()

            If IsPlaying(i) Then
                If GetPlayerMap(index) = GetPlayerMap(i) AndAlso GetPlayerX(i) = x AndAlso GetPlayerY(i) = y Then
                    If i = index Then
                        ' Alterar alvo
                        If TempPlayer(index).PetTargetType = TargetType.Player AndAlso TempPlayer(index).PetTarget = i Then
                            TempPlayer(index).PetTarget = 0
                            TempPlayer(index).PetTargetType = TargetType.None
                            TempPlayer(index).PetBehavior = PetBehaviourGoto
                            TempPlayer(index).GoToX = x
                            TempPlayer(index).GoToY = y
                            ' Enviar alvo ao jogador
                            PlayerMsg(index, "Seu pet não está mais te seguindo.", ColorType.BrightGreen)
                        Else
                            TempPlayer(index).PetTarget = i
                            TempPlayer(index).PetTargetType = TargetType.Player
                            ' Enviar alvo ao jogador
                            TempPlayer(index).PetBehavior = PetBehaviourFollow
                            PlayerMsg(index, "Seu " & GetPetName(index).Trim & " agora está te seguindo.", ColorType.BrightGreen)
                        End If
                    Else
                        ' Alterar alvo
                        If TempPlayer(index).PetTargetType = TargetType.Player AndAlso TempPlayer(index).PetTarget = i Then
                            TempPlayer(index).PetTarget = 0
                            TempPlayer(index).PetTargetType = TargetType.None
                            ' Enviar alvo ao jogador
                            PlayerMsg(index, "Seu pet não tem mais " & GetPlayerName(i).Trim & " como alvo.", ColorType.BrightGreen)
                        Else
                            TempPlayer(index).PetTarget = i
                            TempPlayer(index).PetTargetType = TargetType.Player
                            ' Enviar alvo ao jogador
                            PlayerMsg(index, "Seu pet agora tem " & GetPlayerName(i).Trim & " como alvo.", ColorType.BrightGreen)
                        End If
                    End If
                    Exit Sub
                End If
            End If

            If PetAlive(i) AndAlso i <> index Then
                If GetPetX(i) = x AndAlso GetPetY(i) = y Then
                    ' Change target
                    If TempPlayer(index).PetTargetType = TargetType.Pet AndAlso TempPlayer(index).PetTarget = i Then
                        TempPlayer(index).PetTarget = 0
                        TempPlayer(index).PetTargetType = TargetType.None
                        ' send target to player
                        PlayerMsg(index, "Seu pet não está tem mais o  " & GetPetName(i).Trim & " de " & GetPlayerName(i).Trim & " como alvo.", ColorType.BrightGreen)
                    Else
                        TempPlayer(index).PetTarget = i
                        TempPlayer(index).PetTargetType = TargetType.Pet
                        ' send target to player
                        PlayerMsg(index, "Seu pet agora tem como alvo o " & GetPetName(i).Trim & " de " & GetPlayerName(i).Trim & " como alvo.", ColorType.BrightGreen)
                    End If
                    Exit Sub
                End If
            End If
        Next

        'Procurar por um alvo primeiro
        ' Verificar npc
        For i = 1 To MAX_MAP_NPCS
            If MapNpc(GetPlayerMap(index)).Npc(i).Num > 0 AndAlso MapNpc(GetPlayerMap(index)).Npc(i).X = x AndAlso MapNpc(GetPlayerMap(index)).Npc(i).Y = y Then
                If TempPlayer(index).PetTarget = i AndAlso TempPlayer(index).PetTargetType = TargetType.Npc Then
                    ' alterar alvo target
                    TempPlayer(index).PetTarget = 0
                    TempPlayer(index).PetTargetType = TargetType.None
                    ' enviar alvo ao jogador
                    PlayerMsg(index, "O alvo de " & GetPetName(index).Trim & " não é mais um(a) " & Npc(MapNpc(GetPlayerMap(index)).Npc(i).Num).Name.Trim & "!", ColorType.BrightGreen)
                    Exit Sub
                Else
                    ' Alterar alvo
                    TempPlayer(index).PetTarget = i
                    TempPlayer(index).PetTargetType = TargetType.Npc
                    ' Enviar alvo para o jogador
                    PlayerMsg(index, "O alvo de seu " & GetPetName(index).Trim & " agora é um " & Npc(MapNpc(GetPlayerMap(index)).Npc(i).Num).Name.Trim & "!", ColorType.BrightGreen)
                    Exit Sub
                End If
            End If
        Next

        TempPlayer(index).PetBehavior = PetBehaviourGoto
        TempPlayer(index).PetTargetType = 0
        TempPlayer(index).PetTarget = 0
        TempPlayer(index).GoToX = x
        TempPlayer(index).GoToY = y

        buffer.Dispose()

    End Sub

    Sub Packet_SetPetBehaviour(index As Integer, ByRef data() As Byte)
        Dim behaviour As Integer
        Dim buffer As New ByteStream(data)
        behaviour = buffer.ReadInt32

        If PetAlive(index) Then
            Select Case behaviour
                Case PetAttackBehaviourAttackonsight
                    SetPetBehaviour(index, PetAttackBehaviourAttackonsight)
                    SendActionMsg(GetPlayerMap(index), "Modo agressivo!", ColorType.White, 0, GetPetX(index) * 32, GetPetY(index) * 32, index)
                Case PetAttackBehaviourGuard
                    SetPetBehaviour(index, PetAttackBehaviourGuard)
                    SendActionMsg(GetPlayerMap(index), "Modo defensivo!", ColorType.White, 0, GetPetX(index) * 32, GetPetY(index) * 32, index)
            End Select
        End If

        buffer.Dispose()

    End Sub

    Sub Packet_ReleasePet(index As Integer, ByRef data() As Byte)
        If GetPetNum(index) > 0 Then ReleasePet(index)
    End Sub

    Sub Packet_PetSkill(index As Integer, ByRef data() As Byte)
        Dim n As Integer
        Dim buffer As New ByteStream(data)
        ' Espaço de Habilidade
        n = buffer.ReadInt32

        buffer.Dispose()

        ' Colocar o buffer da skill antes de conjurar
        BufferPetSkill(index, n)

    End Sub

    Sub Packet_UsePetStatPoint(index As Integer, ByRef data() As Byte)
        Dim pointType As Byte
        Dim sMes As String = ""
        Dim buffer As New ByteStream(data)
        pointType = buffer.ReadInt32
        buffer.Dispose()

        ' Prevenir hacking
        If (pointType < 0) OrElse (pointType > StatType.Count) Then Exit Sub

        If Not PetAlive(index) Then Exit Sub

        ' Ter certeza que tem pontos
        If GetPetPoints(index) > 0 Then

            ' Ter certeza que não estão no máximo#
            If GetPetStat(index, pointType) >= 255 Then
                PlayerMsg(index, "Você não pode gastar mais pontos nesse atributo no seu pet.", ColorType.BrightRed)
                Exit Sub
            End If

            SetPetPoints(index, GetPetPoints(index) - 1)

            ' Everything is ok
            Select Case pointType
                Case StatType.Strength
                    SetPetStat(index, pointType, GetPetStat(index, pointType) + 1)
                    sMes = "Força"
                Case StatType.Endurance
                    SetPetStat(index, pointType, GetPetStat(index, pointType) + 1)
                    sMes = "Resistência"
                Case StatType.Intelligence
                    SetPetStat(index, pointType, GetPetStat(index, pointType) + 1)
                    sMes = "Inteligência"
                Case StatType.Luck
                    SetPetStat(index, pointType, GetPetStat(index, pointType) + 1)
                    sMes = "Agilidade"
                Case StatType.Spirit
                    SetPetStat(index, pointType, GetPetStat(index, pointType) + 1)
                    sMes = "Força de Vontade"
            End Select

            SendActionMsg(GetPlayerMap(index), "+1 " & sMes, ColorType.White, 1, (GetPetX(index) * 32), (GetPetY(index) * 32))
        Else
            Exit Sub
        End If

        ' Enviar a atualização
        SendUpdatePlayerPet(index, True)

    End Sub

#End Region

#Region "Pet Functions"

    Friend Sub UpdatePetAi()
        Dim didWalk As Boolean, playerindex As Integer
        Dim mapNum As Integer, tickCount As Integer, i As Integer, n As Integer
        Dim distanceX As Integer, distanceY As Integer, tmpdir As Integer
        Dim target As Integer, targetTypes As Byte, targetX As Integer, targetY As Integer, targetVerify As Boolean

        For mapNum = 1 To MAX_CACHED_MAPS
            For playerindex = 1 To GetPlayersOnline()
                tickCount = GetTimeMs()

                If GetPlayerMap(playerindex) = mapNum AndAlso PetAlive(playerindex) Then
                    ' // Isto é usado para atacar ã vista //

                    ' Se o NPC é atacar a vista, procurar por um jogador no mapa
                    If GetPetBehaviour(playerindex) <> PetAttackBehaviourDonothing Then

                        ' Ter certeza que não está estuporado
                        If Not TempPlayer(playerindex).PetStunDuration > 0 Then

                            For i = 1 To Socket.HighIndex
                                If TempPlayer(playerindex).PetTargetType > 0 Then
                                    If TempPlayer(playerindex).PetTargetType = 1 AndAlso TempPlayer(playerindex).PetTarget = playerindex Then
                                    Else
                                        Exit For
                                    End If
                                End If

                                If IsPlaying(i) AndAlso i <> playerindex Then
                                    If GetPlayerMap(i) = mapNum AndAlso GetPlayerAccess(i) <= AdminType.Monitor Then
                                        If PetAlive(i) Then
                                            n = GetPetRange(playerindex)
                                            distanceX = GetPetX(playerindex) - GetPetX(i)
                                            distanceY = GetPetY(playerindex) - GetPetY(i)

                                            ' Ter certeza de valor positivo
                                            If distanceX < 0 Then distanceX *= -1
                                            If distanceY < 0 Then distanceY *= -1

                                            ' Está ao alcance? Pegue-os!
                                            If distanceX <= n AndAlso distanceY <= n Then
                                                If GetPetBehaviour(playerindex) = PetAttackBehaviourAttackonsight Then
                                                    TempPlayer(playerindex).PetTargetType = TargetType.Pet ' pet
                                                    TempPlayer(playerindex).PetTarget = i
                                                End If
                                            End If
                                        Else
                                            n = GetPetRange(playerindex)
                                            distanceX = GetPetX(playerindex) - GetPlayerX(i)
                                            distanceY = GetPetY(playerindex) - GetPlayerY(i)

                                            ' Ter certeza de valor positivo
                                            If distanceX < 0 Then distanceX *= -1
                                            If distanceY < 0 Then distanceY *= -1

                                            ' Está ao alcance? Pegue-os!
                                            If distanceX <= n AndAlso distanceY <= n Then
                                                If GetPetBehaviour(playerindex) = PetAttackBehaviourAttackonsight Then
                                                    TempPlayer(playerindex).PetTargetType = TargetType.Player ' player
                                                    TempPlayer(playerindex).PetTarget = i
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Next

                            If TempPlayer(playerindex).PetTargetType = 0 Then
                                For i = 1 To MAX_MAP_NPCS

                                    If TempPlayer(playerindex).PetTargetType > 0 Then Exit For
                                    If PetAlive(playerindex) Then
                                        n = GetPetRange(playerindex)
                                        distanceX = GetPetX(playerindex) - MapNpc(GetPlayerMap(playerindex)).Npc(i).X
                                        distanceY = GetPetY(playerindex) - MapNpc(GetPlayerMap(playerindex)).Npc(i).Y

                                        ' Ter certeza de valor positivo
                                        If distanceX < 0 Then distanceX *= -1
                                        If distanceY < 0 Then distanceY *= -1

                                        ' Está ao alcance? Pegue-os!
                                        If distanceX <= n AndAlso distanceY <= n Then
                                            If GetPetBehaviour(playerindex) = PetAttackBehaviourAttackonsight Then
                                                TempPlayer(playerindex).PetTargetType = TargetType.Npc ' npc
                                                TempPlayer(playerindex).PetTarget = i
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                        End If

                        targetVerify = False

                        ' // Isto é usado para o pet andar/ter alvos //

                        ' Ter certeza que há um NPC com o mapa
                        If TempPlayer(playerindex).PetStunDuration > 0 Then
                            ' Verificar se podemos desestuporá-lo
                            If GetTimeMs() > TempPlayer(playerindex).PetStunTimer + (TempPlayer(playerindex).PetStunDuration * 1000) Then
                                TempPlayer(playerindex).PetStunDuration = 0
                                TempPlayer(playerindex).PetStunTimer = 0
                            End If
                        Else
                            target = TempPlayer(playerindex).PetTarget
                            targetTypes = TempPlayer(playerindex).PetTargetType

                            ' Verificar se é hora do NPC andar
                            If GetPetBehaviour(playerindex) <> PetAttackBehaviourDonothing Then

                                If targetTypes = TargetType.Player Then ' jogador
                                    ' Verificar se estamos seguindo um jogador ou não
                                    If target > 0 Then

                                        ' Verificar se o jogador está jogando; se sim, segui-lo
                                        If IsPlaying(target) AndAlso GetPlayerMap(target) = mapNum Then
                                            If target <> playerindex Then
                                                didWalk = False
                                                targetVerify = True
                                                targetY = GetPlayerY(target)
                                                targetX = GetPlayerX(target)
                                            End If
                                        Else
                                            TempPlayer(playerindex).PetTargetType = TargetType.None ' limpar
                                            TempPlayer(playerindex).PetTarget = 0
                                        End If
                                    End If
                                ElseIf targetTypes = TargetType.Npc Then 'npc
                                    If target > 0 Then
                                        If MapNpc(mapNum).Npc(target).Num > 0 Then
                                            didWalk = False
                                            targetVerify = True
                                            targetY = MapNpc(mapNum).Npc(target).Y
                                            targetX = MapNpc(mapNum).Npc(target).X
                                        Else
                                            TempPlayer(playerindex).PetTargetType = TargetType.None ' limpar
                                            TempPlayer(playerindex).PetTarget = 0
                                        End If
                                    End If
                                ElseIf targetTypes = TargetType.Pet Then 'outro pet
                                    If target > 0 Then
                                        If IsPlaying(target) AndAlso GetPlayerMap(target) = mapNum AndAlso PetAlive(target) Then
                                            didWalk = False
                                            targetVerify = True
                                            targetY = GetPetY(target)
                                            targetX = GetPetX(target)
                                        Else
                                            TempPlayer(playerindex).PetTargetType = TargetType.None ' limpar
                                            TempPlayer(playerindex).PetTarget = 0
                                        End If
                                    End If
                                End If
                            End If

                            If targetVerify Then
                                didWalk = False

                                If IsOneBlockAway(GetPetX(playerindex), GetPetY(playerindex), targetX, targetY) Then
                                    If GetPetX(playerindex) < targetX Then
                                        PetDir(playerindex, DirectionType.Right)
                                        didWalk = True
                                    ElseIf GetPetX(playerindex) > targetX Then
                                        PetDir(playerindex, DirectionType.Left)
                                        didWalk = True
                                    ElseIf GetPetY(playerindex) < targetY Then
                                        PetDir(playerindex, DirectionType.Up)
                                        didWalk = True
                                    ElseIf GetPetY(playerindex) > targetY Then
                                        PetDir(playerindex, DirectionType.Down)
                                        didWalk = True
                                    End If
                                Else
                                    didWalk = PetTryWalk(playerindex, targetX, targetY)
                                End If

                            ElseIf TempPlayer(playerindex).PetBehavior = PetBehaviourGoto AndAlso targetVerify = False Then

                                If GetPetX(playerindex) = TempPlayer(playerindex).GoToX AndAlso GetPetY(playerindex) = TempPlayer(playerindex).GoToY Then
                                    'Descomentar esses para viradas aleatórias
                                    'i = Int(Rnd() * 4)
                                    'PetDir(playerindex, i)
                                Else
                                    didWalk = False
                                    targetX = TempPlayer(playerindex).GoToX
                                    targetY = TempPlayer(playerindex).GoToY
                                    didWalk = PetTryWalk(playerindex, targetX, targetY)

                                    If didWalk = False Then
                                        tmpdir = Int(Rnd() * 4)

                                        If tmpdir = 1 Then
                                            tmpdir = Int(Rnd() * 4)
                                            If CanPetMove(playerindex, mapNum, tmpdir) Then
                                                PetMove(playerindex, mapNum, tmpdir, MovementType.Walking)
                                            End If
                                        End If
                                    End If
                                End If

                            ElseIf TempPlayer(playerindex).PetBehavior = PetBehaviourFollow Then

                                If IsPetByPlayer(playerindex) Then
                                    'Descomentar esses para viradas aleatórias
                                    'i = Int(Rnd() * 4)
                                    'PetDir(playerindex, i)
                                Else
                                    didWalk = False
                                    targetX = GetPlayerX(playerindex)
                                    targetY = GetPlayerY(playerindex)
                                    didWalk = PetTryWalk(playerindex, targetX, targetY)

                                    If didWalk = False Then
                                        tmpdir = Int(Rnd() * 4)
                                        If tmpdir = 1 Then
                                            tmpdir = Int(Rnd() * 4)
                                            If CanPetMove(playerindex, mapNum, tmpdir) Then
                                                PetMove(playerindex, mapNum, tmpdir, MovementType.Walking)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If

                        ' // Isto é usado para pets atacarem seus alvos //

                        ' Ter certeza que tem um npc no mapa
                        target = TempPlayer(playerindex).PetTarget
                        targetTypes = TempPlayer(playerindex).PetTargetType

                        ' Ter certeza que o pet pode atacar o jogador-alvo
                        If target > 0 Then
                            If targetTypes = TargetType.Player Then ' é jogador?
                                ' O alvo está jogando e no mesmo mapa?
                                If IsPlaying(target) AndAlso GetPlayerMap(target) = mapNum Then
                                    If playerindex <> target Then TryPetAttackPlayer(playerindex, target)
                                Else
                                    ' Jogador saiu do mapa ou do jogo, bote alvo como zero
                                    TempPlayer(playerindex).PetTarget = 0
                                    TempPlayer(playerindex).PetTargetType = TargetType.None ' limpar

                                End If
                            ElseIf targetTypes = TargetType.Npc Then 'npc
                                If MapNpc(GetPlayerMap(playerindex)).Npc(TempPlayer(playerindex).PetTarget).Num > 0 Then
                                    TryPetAttackNpc(playerindex, TempPlayer(playerindex).PetTarget)
                                Else
                                    ' Jogador saiu do mapa ou do jogo, bote alvo como zero
                                    TempPlayer(playerindex).PetTarget = 0
                                    TempPlayer(playerindex).PetTargetType = TargetType.None ' limpar
                                End If
                            ElseIf targetTypes = TargetType.Pet Then 'pet
                                ' O alvo está jogando e no mesmo mapa? E o pet está vivo?
                                If IsPlaying(target) AndAlso GetPlayerMap(target) = mapNum AndAlso PetAlive(target) Then
                                    TryPetAttackPet(playerindex, target)
                                Else
                                    ' Jogador saiu do mapa ou do jogo, colocar alvo como zero
                                    TempPlayer(playerindex).PetTarget = 0
                                    TempPlayer(playerindex).PetTargetType = TargetType.None ' limpar
                                End If
                            End If
                        End If

                        ' //////////////////////////////////////
                        ' // Usado para regenerar o HP do Pet //
                        ' //////////////////////////////////////
                        ' Ver se queremos regenerar parte do HP do NPC
                        If Not TempPlayer(playerindex).PetstopRegen Then
                            If PetAlive(playerindex) AndAlso tickCount > givePetHpTimer + 10000 Then
                                If GetPetVital(playerindex, VitalType.HP) > 0 Then
                                    SetPetVital(playerindex, VitalType.HP, GetPetVital(playerindex, VitalType.HP) + GetPetVitalRegen(playerindex, VitalType.HP))
                                    SetPetVital(playerindex, VitalType.MP, GetPetVital(playerindex, VitalType.MP) + GetPetVitalRegen(playerindex, VitalType.MP))

                                    ' Verificar se tem mais do que devem; se sim, setar para o máximo
                                    If GetPetVital(playerindex, VitalType.HP) > GetPetMaxVital(playerindex, VitalType.HP) Then
                                        SetPetVital(playerindex, VitalType.HP, GetPetMaxVital(playerindex, VitalType.HP))
                                    End If

                                    If GetPetVital(playerindex, VitalType.MP) > GetPetMaxVital(playerindex, VitalType.MP) Then
                                        SetPetVital(playerindex, VitalType.MP, GetPetMaxVital(playerindex, VitalType.MP))
                                    End If

                                    If Not GetPetVital(playerindex, VitalType.HP) = GetPetMaxVital(playerindex, VitalType.HP) Then
                                        SendPetVital(playerindex, VitalType.HP)
                                        SendPetVital(playerindex, VitalType.MP)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

            Next

        Next

        ' Ter certeza que resetamos o temporizados para a regeneração de HP
        If GetTimeMs() > givePetHpTimer + 10000 Then
            givePetHpTimer = GetTimeMs()
        End If
    End Sub

    Sub SummonPet(index As Integer)
        Player(index).Character(TempPlayer(index).CurChar).Pet.Alive = 1
        PlayerMsg(index, "Você convocou " & GetPetName(index).Trim & "!", ColorType.BrightGreen)
        SendUpdatePlayerPet(index, False)
    End Sub

    Sub ReCallPet(index As Integer)
        PlayerMsg(index, "Você recolheu " & GetPetName(index).Trim & "!", ColorType.BrightGreen)
        Player(index).Character(TempPlayer(index).CurChar).Pet.Alive = 0
        SendUpdatePlayerPet(index, False)
    End Sub

    Sub ReleasePet(index As Integer)
        Dim i As Integer

        Player(index).Character(TempPlayer(index).CurChar).Pet.Alive = 0
        Player(index).Character(TempPlayer(index).CurChar).Pet.Num = 0
        Player(index).Character(TempPlayer(index).CurChar).Pet.AttackBehaviour = 0
        Player(index).Character(TempPlayer(index).CurChar).Pet.Dir = 0
        Player(index).Character(TempPlayer(index).CurChar).Pet.Health = 0
        Player(index).Character(TempPlayer(index).CurChar).Pet.Level = 0
        Player(index).Character(TempPlayer(index).CurChar).Pet.Mana = 0
        Player(index).Character(TempPlayer(index).CurChar).Pet.X = 0
        Player(index).Character(TempPlayer(index).CurChar).Pet.Y = 0

        TempPlayer(index).PetTarget = 0
        TempPlayer(index).PetTargetType = 0
        TempPlayer(index).GoToX = -1
        TempPlayer(index).GoToY = -1

        For i = 1 To 4
            Player(index).Character(TempPlayer(index).CurChar).Pet.Skill(i) = 0
        Next

        For i = 1 To StatType.Count - 1
            Player(index).Character(TempPlayer(index).CurChar).Pet.Stat(i) = 0
        Next

        SendUpdatePlayerPet(index, False)

        SavePlayer(index)

        PlayerMsg(index, "Você libertou seu pet!", ColorType.BrightGreen)

        For i = 1 To MAX_MAP_NPCS
            If MapNpc(GetPlayerMap(index)).Npc(i).Vital(VitalType.HP) > 0 Then
                If MapNpc(GetPlayerMap(index)).Npc(i).TargetType = TargetType.Pet Then
                    If MapNpc(GetPlayerMap(index)).Npc(i).Target = index Then
                        MapNpc(GetPlayerMap(index)).Npc(i).TargetType = TargetType.Player
                        MapNpc(GetPlayerMap(index)).Npc(i).Target = index
                    End If
                End If
            End If
        Next

    End Sub

    Sub AdoptPet(index As Integer, petNum As Integer)

        If GetPetNum(index) = 0 Then
            PlayerMsg(index, "Você adotou um " & Pet(petNum).Name.Trim, ColorType.BrightGreen)
        Else
            PlayerMsg(index, "Você já tem um " & Pet(petNum).Name.Trim & "; primeiro liberte seu pet atual!", ColorType.BrightGreen)
            Exit Sub
        End If

        Player(index).Character(TempPlayer(index).CurChar).Pet.Num = petNum

        For i = 1 To 4
            Player(index).Character(TempPlayer(index).CurChar).Pet.Skill(i) = Pet(petNum).Skill(i)
        Next

        If Pet(petNum).StatType = 0 Then
            Player(index).Character(TempPlayer(index).CurChar).Pet.Health = GetPlayerMaxVital(index, VitalType.HP)
            Player(index).Character(TempPlayer(index).CurChar).Pet.Mana = GetPlayerMaxVital(index, VitalType.MP)
            Player(index).Character(TempPlayer(index).CurChar).Pet.Level = GetPlayerLevel(index)

            For i = 1 To StatType.Count - 1
                Player(index).Character(TempPlayer(index).CurChar).Pet.Stat(i) = Player(index).Character(TempPlayer(index).CurChar).Stat(i)
            Next

            Player(index).Character(TempPlayer(index).CurChar).Pet.AdoptiveStats = 1
        Else
            For i = 1 To StatType.Count - 1
                Player(index).Character(TempPlayer(index).CurChar).Pet.Stat(i) = Pet(petNum).Stat(i)
            Next

            Player(index).Character(TempPlayer(index).CurChar).Pet.Level = Pet(petNum).Level
            Player(index).Character(TempPlayer(index).CurChar).Pet.AdoptiveStats = 0
            Player(index).Character(TempPlayer(index).CurChar).Pet.Health = GetPetMaxVital(index, VitalType.HP)
            Player(index).Character(TempPlayer(index).CurChar).Pet.Mana = GetPetMaxVital(index, VitalType.MP)
        End If

        Player(index).Character(TempPlayer(index).CurChar).Pet.X = GetPlayerX(index)
        Player(index).Character(TempPlayer(index).CurChar).Pet.Y = GetPlayerY(index)

        Player(index).Character(TempPlayer(index).CurChar).Pet.Alive = 1
        Player(index).Character(TempPlayer(index).CurChar).Pet.Points = 0
        Player(index).Character(TempPlayer(index).CurChar).Pet.Exp = 0

        Player(index).Character(TempPlayer(index).CurChar).Pet.AttackBehaviour = PetAttackBehaviourGuard 'By default it will guard but this can be changed

        SavePlayer(index)

        SendUpdatePlayerPet(index, False)

    End Sub

    Sub PetMove(index As Integer, mapNum As Integer, dir As Integer, movement As Integer)
        Dim buffer As New ByteStream(4)

        If mapNum < 1 OrElse mapNum > MAX_MAPS OrElse index <= 0 OrElse index > MAX_PLAYERS OrElse dir < DirectionType.Up OrElse dir > DirectionType.Right OrElse movement < 1 OrElse movement > 2 Then
            Exit Sub
        End If

        Player(index).Character(TempPlayer(index).CurChar).Pet.Dir = dir

        Select Case dir
            Case DirectionType.Up
                SetPetY(index, GetPetY(index) - 1)

            Case DirectionType.Down
                SetPetY(index, GetPetY(index) + 1)

            Case DirectionType.Left
                SetPetX(index, GetPetX(index) - 1)

            Case DirectionType.Right
                SetPetX(index, GetPetX(index) + 1)
        End Select

        buffer.WriteInt32(ServerPackets.SPetMove)
        buffer.WriteInt32(index)
        buffer.WriteInt32(GetPetX(index))
        buffer.WriteInt32(GetPetY(index))
        buffer.WriteInt32(GetPetDir(index))
        buffer.WriteInt32(movement)
        SendDataToMap(mapNum, buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

    Function CanPetMove(index As Integer, mapNum As Integer, dir As Byte) As Boolean
        Dim i As Integer, n As Integer
        Dim x As Integer, y As Integer

        If mapNum < 1 OrElse mapNum > MAX_MAPS OrElse index <= 0 OrElse index > MAX_PLAYERS OrElse dir < DirectionType.Up OrElse dir > DirectionType.Right Then
            Exit Function
        End If

        If index <= 0 OrElse index > MAX_PLAYERS Then Exit Function

        x = GetPetX(index)
        y = GetPetY(index)

        If x < 0 OrElse x > Map(mapNum).MaxX Then Exit Function
        If y < 0 OrElse y > Map(mapNum).MaxY Then Exit Function

        CanPetMove = True

        If TempPlayer(index).PetskillBuffer.Skill > 0 Then
            CanPetMove = False
            Exit Function
        End If

        Select Case dir

            Case DirectionType.Up
                ' Ter certeza que não estamos fora dos limites
                If y > 0 Then
                    n = Map(mapNum).Tile(x, y - 1).Type

                    ' Ter certeza que a tile é andável
                    If n <> TileType.None AndAlso n <> TileType.NpcSpawn AndAlso n <> TileType.NpcAvoid Then
                        CanPetMove = False
                        Exit Function
                    End If

                    ' Ter certeza que não há jogador no caminho
                    For i = 1 To GetPlayersOnline()
                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = mapNum) AndAlso (GetPlayerX(i) = GetPetX(index) + 1) AndAlso (GetPlayerY(i) = GetPetY(index) - 1) Then
                                CanPetMove = False
                                Exit Function
                            ElseIf PetAlive(i) AndAlso (GetPlayerMap(i) = mapNum) AndAlso (GetPetX(i) = GetPetX(index)) AndAlso (GetPetY(i) = GetPetY(index) - 1) Then
                                CanPetMove = False
                                Exit Function
                            End If
                        End If
                    Next

                    ' Ter certeza que não há outro NPC no caminho
                    For i = 1 To MAX_MAP_NPCS
                        If (MapNpc(mapNum).Npc(i).Num > 0) AndAlso (MapNpc(mapNum).Npc(i).X = GetPetX(index)) AndAlso (MapNpc(mapNum).Npc(i).Y = GetPetY(index) - 1) Then
                            CanPetMove = False
                            Exit Function
                        End If
                    Next

                    ' Bloqueio direcional
                    If IsDirBlocked(Map(mapNum).Tile(GetPetX(index), GetPetY(index)).DirBlock, DirectionType.Up + 1) Then
                        CanPetMove = False
                        Exit Function
                    End If
                Else
                    CanPetMove = False
                End If

            Case DirectionType.Down

                ' Ter certeza que não estamos fora dos limites
                If y < Map(mapNum).MaxY Then
                    n = Map(mapNum).Tile(x, y + 1).Type

                    ' Ter certeza que a tile é andável
                    If n <> TileType.None AndAlso n <> TileType.NpcSpawn AndAlso n <> TileType.NpcAvoid Then
                        CanPetMove = False
                        Exit Function
                    End If

                    For i = 1 To GetPlayersOnline()
                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = mapNum) AndAlso (GetPlayerX(i) = GetPetX(index)) AndAlso (GetPlayerY(i) = GetPetY(index) + 1) Then
                                CanPetMove = False
                                Exit Function
                            ElseIf PetAlive(i) AndAlso (GetPlayerMap(i) = mapNum) AndAlso (GetPetX(i) = GetPetX(index)) AndAlso (GetPetY(i) = GetPetY(index) + 1) Then
                                CanPetMove = False
                                Exit Function
                            End If
                        End If
                    Next

                    ' Ter certeza que não há outro NPC no caminho
                    For i = 1 To MAX_MAP_NPCS
                        If (MapNpc(mapNum).Npc(i).Num > 0) AndAlso (MapNpc(mapNum).Npc(i).X = GetPetX(index)) AndAlso (MapNpc(mapNum).Npc(i).Y = GetPetY(index) + 1) Then
                            CanPetMove = False
                            Exit Function
                        End If
                    Next

                    ' Bloqueio direcional
                    If IsDirBlocked(Map(mapNum).Tile(GetPetX(index), GetPetY(index)).DirBlock, DirectionType.Down + 1) Then
                        CanPetMove = False
                        Exit Function
                    End If
                Else
                    CanPetMove = False
                End If

            Case DirectionType.Left

                ' Ter certeza que não estamos fora dos limites
                If x > 0 Then
                    n = Map(mapNum).Tile(x - 1, y).Type

                    ' Ter certeza que a tile é andável
                    If n <> TileType.None AndAlso n <> TileType.NpcSpawn AndAlso n <> TileType.NpcAvoid Then
                        CanPetMove = False
                        Exit Function
                    End If

                    For i = 1 To GetPlayersOnline()
                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = mapNum) AndAlso (GetPlayerX(i) = GetPetX(index) - 1) AndAlso (GetPlayerY(i) = GetPetY(index)) Then
                                CanPetMove = False
                                Exit Function
                            ElseIf PetAlive(i) AndAlso (GetPlayerMap(i) = mapNum) AndAlso (GetPetX(i) = GetPetX(index) - 1) AndAlso (GetPetY(i) = GetPetY(index)) Then
                                CanPetMove = False
                                Exit Function
                            End If
                        End If
                    Next

                    ' Ter certeza que não há outro NPC no caminho
                    For i = 1 To MAX_MAP_NPCS
                        If (MapNpc(mapNum).Npc(i).Num > 0) AndAlso (MapNpc(mapNum).Npc(i).X = GetPetX(index) - 1) AndAlso (MapNpc(mapNum).Npc(i).Y = GetPetY(index)) Then
                            CanPetMove = False
                            Exit Function
                        End If
                    Next

                    ' Bloqueio direcional
                    If IsDirBlocked(Map(mapNum).Tile(GetPetX(index), GetPetY(index)).DirBlock, DirectionType.Left + 1) Then
                        CanPetMove = False
                        Exit Function
                    End If
                Else
                    CanPetMove = False
                End If

            Case DirectionType.Right

                ' Ter certeza que não estamos fora dos limites
                If x < Map(mapNum).MaxX Then
                    n = Map(mapNum).Tile(x + 1, y).Type

                    ' Ter certeza que a tile é andável
                    If n <> TileType.None AndAlso n <> TileType.NpcSpawn AndAlso n <> TileType.NpcAvoid Then
                        CanPetMove = False
                        Exit Function
                    End If

                    For i = 1 To GetPlayersOnline()
                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = mapNum) AndAlso (GetPlayerX(i) = GetPetX(index) + 1) AndAlso (GetPlayerY(i) = GetPetY(index)) Then
                                CanPetMove = False
                                Exit Function
                            ElseIf PetAlive(i) AndAlso (GetPlayerMap(i) = mapNum) AndAlso (GetPetX(i) = GetPetX(index) + 1) AndAlso (GetPetY(i) = GetPetY(index)) Then
                                CanPetMove = False
                                Exit Function
                            End If
                        End If
                    Next

                    ' Ter certeza que não há outro NPC no caminho
                    For i = 1 To MAX_MAP_NPCS
                        If (MapNpc(mapNum).Npc(i).Num > 0) AndAlso (MapNpc(mapNum).Npc(i).X = GetPetX(index) + 1) AndAlso (MapNpc(mapNum).Npc(i).Y = GetPetY(index)) Then
                            CanPetMove = False
                            Exit Function
                        End If
                    Next

                    ' Bloqueio direcional
                    If IsDirBlocked(Map(mapNum).Tile(GetPetX(index), GetPetY(index)).DirBlock, DirectionType.Right + 1) Then
                        CanPetMove = False
                        Exit Function
                    End If
                Else
                    CanPetMove = False
                End If

        End Select

    End Function

    Sub PetDir(index As Integer, dir As Integer)
        Dim buffer As New ByteStream(4)

        If index <= 0 OrElse index > MAX_PLAYERS OrElse dir < DirectionType.Up OrElse dir > DirectionType.Right Then Exit Sub

        If TempPlayer(index).PetskillBuffer.Skill > 0 Then Exit Sub

        Player(index).Character(TempPlayer(index).CurChar).Pet.Dir = dir

        buffer.WriteInt32(ServerPackets.SPetDir)
        buffer.WriteInt32(index)
        buffer.WriteInt32(dir)
        SendDataToMap(GetPlayerMap(index), buffer.Data, buffer.Head)

        buffer.Dispose()

    End Sub

    Function PetTryWalk(index As Integer, targetX As Integer, targetY As Integer) As Boolean
        Dim i As Integer, x As Integer, didwalk As Boolean
        Dim mapNum As Integer

        mapNum = GetPlayerMap(index)
        x = index

        If IsOneBlockAway(targetX, targetY, GetPetX(index), GetPetY(index)) = False Then

            If PathfindingType = 1 Then
                i = Int(Rnd() * 5)

                ' Vamos mover o pet
                Select Case i
                    Case 0
                        ' Cima
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.Y > targetY AndAlso Not didwalk Then
                            If CanPetMove(x, mapNum, DirectionType.Up) Then
                                PetMove(x, mapNum, DirectionType.Up, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Baixo
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.Y < targetY AndAlso Not didwalk Then
                            If CanPetMove(x, mapNum, DirectionType.Down) Then
                                PetMove(x, mapNum, DirectionType.Down, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Esquerda
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.X > targetX AndAlso Not didwalk Then
                            If CanPetMove(x, mapNum, DirectionType.Left) Then
                                PetMove(x, mapNum, DirectionType.Left, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Direita
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.X < targetX AndAlso Not didwalk Then
                            If CanPetMove(x, mapNum, DirectionType.Right) Then
                                PetMove(x, mapNum, DirectionType.Right, MovementType.Walking)
                                didwalk = True
                            End If
                        End If
                    Case 1

                        ' Direita
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.X < targetX AndAlso Not didwalk Then
                            If CanPetMove(x, mapNum, DirectionType.Right) Then
                                PetMove(x, mapNum, DirectionType.Right, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Esquerda
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.X > targetX AndAlso Not didwalk Then
                            If CanPetMove(x, mapNum, DirectionType.Left) Then
                                PetMove(x, mapNum, DirectionType.Left, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Baixo
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.Y < targetY AndAlso Not didwalk Then
                            If CanPetMove(x, mapNum, DirectionType.Down) Then
                                PetMove(x, mapNum, DirectionType.Down, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Cima
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.Y > targetY AndAlso Not didwalk Then
                            If CanPetMove(x, mapNum, DirectionType.Up) Then
                                PetMove(x, mapNum, DirectionType.Up, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                    Case 2

                        ' Baixo
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.Y < targetY AndAlso Not didwalk Then
                            If CanPetMove(x, mapNum, DirectionType.Down) Then
                                PetMove(x, mapNum, DirectionType.Down, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Cima
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.Y > targetY AndAlso Not didwalk Then
                            If CanPetMove(x, mapNum, DirectionType.Up) Then
                                PetMove(x, mapNum, DirectionType.Up, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Direita
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.X < targetX AndAlso Not didwalk Then
                            If CanPetMove(x, mapNum, DirectionType.Right) Then
                                PetMove(x, mapNum, DirectionType.Right, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Esquerda
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.X > targetX AndAlso Not didwalk Then
                            If CanPetMove(x, mapNum, DirectionType.Left) Then
                                PetMove(x, mapNum, DirectionType.Left, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                    Case 3

                        ' Esquerda
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.X > targetX AndAlso Not didwalk Then
                            If CanPetMove(x, mapNum, DirectionType.Left) Then
                                Call PetMove(x, mapNum, DirectionType.Left, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Direita
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.X < targetX AndAlso Not didwalk Then
                            If CanPetMove(x, mapNum, DirectionType.Right) Then
                                PetMove(x, mapNum, DirectionType.Right, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Cima
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.Y > targetY AndAlso Not didwalk Then
                            If CanPetMove(x, mapNum, DirectionType.Up) Then
                                PetMove(x, mapNum, DirectionType.Up, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Baixo
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.Y < targetY AndAlso Not didwalk Then
                            If CanPetMove(x, mapNum, DirectionType.Down) Then
                                PetMove(x, mapNum, DirectionType.Down, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                End Select

                ' Verificar se não podemos mover e se o alvo está atrás de algo e se podemos apenas trocar direções 
                If Not didwalk Then
                    If GetPetX(x) - 1 = targetX AndAlso GetPetY(x) = targetY Then

                        If GetPetDir(x) <> DirectionType.Left Then
                            PetDir(x, DirectionType.Left)
                        End If

                        didwalk = True
                    End If

                    If GetPetX(x) + 1 = targetX AndAlso GetPetY(x) = targetY Then

                        If GetPetDir(x) <> DirectionType.Right Then
                            PetDir(x, DirectionType.Right)
                        End If

                        didwalk = True
                    End If

                    If GetPetX(x) = targetX AndAlso GetPetY(x) - 1 = targetY Then

                        If GetPetDir(x) <> DirectionType.Up Then
                            PetDir(x, DirectionType.Up)
                        End If

                        didwalk = True
                    End If

                    If GetPetX(x) = targetX AndAlso GetPetY(x) + 1 = targetY Then

                        If GetPetDir(x) <> DirectionType.Down Then
                            PetDir(x, DirectionType.Down)
                        End If

                        didwalk = True
                    End If
                End If
            Else
                'Pathfind
                i = FindPetPath(mapNum, x, targetX, targetY)

                If i < 4 Then 'Retornou reposta. Mover o pet.
                    If CanPetMove(x, mapNum, i) Then
                        PetMove(x, mapNum, i, MovementType.Walking)
                        didwalk = True
                    End If
                End If
            End If
        Else

            'Olhar o alvo
            If GetPetX(index) > TempPlayer(index).GoToX Then
                If CanPetMove(x, mapNum, DirectionType.Left) Then
                    PetMove(x, mapNum, DirectionType.Left, MovementType.Walking)
                    didwalk = True
                Else
                    PetDir(x, DirectionType.Left)
                    didwalk = True
                End If

            ElseIf GetPetX(index) < TempPlayer(index).GoToX Then

                If CanPetMove(x, mapNum, DirectionType.Right) Then
                    PetMove(x, mapNum, DirectionType.Right, MovementType.Walking)
                    didwalk = True
                Else
                    PetDir(x, DirectionType.Right)
                    didwalk = True
                End If

            ElseIf GetPetY(index) > TempPlayer(index).GoToY Then

                If CanPetMove(x, mapNum, DirectionType.Up) Then
                    PetMove(x, mapNum, DirectionType.Up, MovementType.Walking)
                    didwalk = True
                Else
                    PetDir(x, DirectionType.Up)
                    didwalk = True
                End If

            ElseIf GetPetY(index) < TempPlayer(index).GoToY Then

                If CanPetMove(x, mapNum, DirectionType.Down) Then
                    PetMove(x, mapNum, DirectionType.Down, MovementType.Walking)
                    didwalk = True
                Else
                    PetDir(x, DirectionType.Down)
                    didwalk = True
                End If
            End If
        End If

        ' Não podemos mover, então o alvo deve estar atrás de algo. Andar aleatoriamente.
        If Not didwalk Then
            i = Int(Rnd() * 2)

            If i = 1 Then
                i = Int(Rnd() * 4)

                If CanPetMove(x, mapNum, i) Then
                    PetMove(x, mapNum, i, MovementType.Walking)
                End If
            End If
        End If

        PetTryWalk = didwalk

    End Function

    Function FindPetPath(mapNum As Integer, index As Integer, targetX As Integer, targetY As Integer) As Integer

        Dim tim As Integer, sX As Integer, sY As Integer, pos(,) As Integer, reachable As Boolean, j As Integer, lastSum As Integer, sum As Integer, fx As Integer, fy As Integer, i As Integer

        Dim path() As Point, lastX As Integer, lastY As Integer, did As Boolean

        'Fase de Inicialização

        tim = 0
        sX = GetPetX(index)
        sY = GetPetY(index)

        fx = targetX
        fy = targetY

        If fx = -1 Then Exit Function
        If fy = -1 Then Exit Function

        ReDim pos(Map(mapNum).MaxX, Map(mapNum).MaxY)
        'pos = MapBlocks(MapNum).Blocks

        pos(sX, sY) = 100 + tim
        pos(fx, fy) = 2

        'Resetar reachable (alcançável)
        reachable = False

        'Executar enquanto reachable for falso... se é setado para verdeiro, pulamos fora
        'Se o caminho é decididamente não-alcançavel no processo, saíremos da sub. Não é o melhor jeito, mas é rápido.

        Do While reachable = False

            'Fazemos um loop por todos os quadrados
            For j = 0 To Map(mapNum).MaxY
                For i = 0 To Map(mapNum).MaxX

                    'If j = 10 AndAlso i = 0 Then MsgBox "oi!"
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
                Next
            Next

            'Se o reachable ainda é falso, então
            If reachable = False Then
                'resetar soma
                sum = 0

                For j = 0 To Map(mapNum).MaxY
                    For i = 0 To Map(mapNum).MaxX
                        'adicionamos todos os quadrados
                        sum += pos(i, j)
                    Next i
                Next j

                'Agora se a soma é igual à última soma, não é alcançavel; se não é, então guardamos a soma na última soma
                If sum = lastSum Then
                    FindPetPath = 4
                    Exit Function
                Else
                    lastSum = sum
                End If
            End If

            'aumentar o ponteiro para apontar ao próximo quadrado a ser expandido
            tim += 1
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
            tim -= 1
            'resetar did para falso
            did = False

            'Se não estamos na borda
            If lastX < Map(mapNum).MaxX Then

                'Ver o quadrado a direita da solução. É um tim-1? Ou apenas um branco?
                If pos(lastX + 1, lastY) = 100 + tim Then
                    'Se é, então faça-o amarelo e mude did para verdade
                    lastX += 1
                    did = True
                End If
            End If

            'Isso vai funcionar apenas se a parte anterior não executar e did ainda é falso.
            'Então queremos checar outro quadrado, o da esquerda. É um tim-1?
            If did = False Then
                If lastX > 0 Then
                    If pos(lastX - 1, lastY) = 100 + tim Then
                        lastX -= 1
                        did = True
                    End If
                End If
            End If

            'Checamos o abaixo dele
            If did = False Then
                If lastY < Map(mapNum).MaxY Then
                    If pos(lastX, lastY + 1) = 100 + tim Then
                        lastY += 1
                        did = True
                    End If
                End If
            End If

            'E acima dele. Algum desses tem que ser, já que encontramos a solução e sabemos que há um jeito de volta. 
            If did = False Then
                If lastY > 0 Then
                    If pos(lastX, lastY - 1) = 100 + tim Then
                        lastY -= 1
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
            FindPetPath = DirectionType.Right
        ElseIf path(1).Y > lastY Then
            FindPetPath = DirectionType.Down
        ElseIf path(1).Y < lastY Then
            FindPetPath = DirectionType.Up
        ElseIf path(1).X < lastX Then
            FindPetPath = DirectionType.Left
        End If

    End Function

    Function GetPetDamage(index As Integer) As Integer
        GetPetDamage = 0

        ' Verificar por subscript out of range
        If IsPlaying(index) = False OrElse index <= 0 OrElse index > MAX_PLAYERS OrElse Not PetAlive(index) Then
            Exit Function
        End If

        GetPetDamage = (Player(index).Character(TempPlayer(index).CurChar).Pet.Stat(StatType.Strength) * 2) + (Player(index).Character(TempPlayer(index).CurChar).Pet.Level * 3) + Random(0, 20)

    End Function

    Friend Function CanPetCrit(index As Integer) As Boolean
        Dim rate As Integer
        Dim rndNum As Integer

        If Not PetAlive(index) Then Exit Function

        CanPetCrit = False

        rate = Player(index).Character(TempPlayer(index).CurChar).Pet.Stat(StatType.Luck) / 3
        rndNum = Random(1, 100)

        If rndNum <= rate Then CanPetCrit = True

    End Function

    Function IsPetByPlayer(index As Integer) As Boolean
        Dim x As Integer, y As Integer, x1 As Integer, y1 As Integer

        If index <= 0 OrElse index > MAX_PLAYERS OrElse Not PetAlive(index) Then Exit Function

        IsPetByPlayer = False

        x = GetPlayerX(index)
        y = GetPlayerY(index)
        x1 = GetPetX(index)
        y1 = GetPetY(index)

        If x = x1 Then
            If y = y1 + 1 OrElse y = y1 - 1 Then
                IsPetByPlayer = True
            End If
        ElseIf y = y1 Then
            If x = x1 - 1 OrElse x = x1 + 1 Then
                IsPetByPlayer = True
            End If
        End If

    End Function

    Function GetPetVitalRegen(index As Integer, vital As VitalType) As Integer
        Dim i As Integer

        If index <= 0 OrElse index > MAX_PLAYERS OrElse Not PetAlive(index) Then
            GetPetVitalRegen = 0
            Exit Function
        End If

        Select Case vital
            Case VitalType.HP
                i = (GetPlayerStat(index, StatType.Spirit) * 0.8) + 6

            Case VitalType.MP
                i = (GetPlayerStat(index, StatType.Spirit) / 4) + 12.5
        End Select

        GetPetVitalRegen = i

    End Function

    Sub CheckPetLevelUp(index As Integer)
        Dim expRollover As Integer, levelCount As Integer

        levelCount = 0

        Do While GetPetExp(index) >= GetPetNextLevel(index)
            expRollover = GetPetExp(index) - GetPetNextLevel(index)

            ' pode subir de nível?
            If GetPetLevel(index) < 99 AndAlso GetPetLevel(index) < Pet(Player(index).Character(TempPlayer(index).CurChar).Pet.Num).MaxLevel Then
                SetPetLevel(index, GetPetLevel(index) + 1)
            End If

            SetPetPoints(index, GetPetPoints(index) + Pet(Player(index).Character(TempPlayer(index).CurChar).Pet.Num).LevelPnts)
            SetPetExp(index, expRollover)
            levelCount += 1
        Loop

        If levelCount > 0 Then
            If levelCount = 1 Then
                'singular
                PlayerMsg(index, "Seu " & GetPetName(index).Trim & " ganhou " & levelCount & " nível!", ColorType.BrightGreen)
            Else
                'plural
                PlayerMsg(index, "Seu " & GetPetName(index).Trim & " subiu " & levelCount & " níveis!", ColorType.BrightGreen)
            End If

            SendPlayerData(index)

        End If

    End Sub

    Friend Sub PetFireProjectile(index As Integer, spellnum As Integer)
        Dim projectileSlot As Integer, projectileNum As Integer
        Dim mapNum As Integer, i As Integer

        ' Preveir subscript out of range

        mapNum = GetPlayerMap(index)

        'Encontrar um projetil livre
        For i = 1 To MAX_PROJECTILES
            If MapProjectiles(mapNum, i).ProjectileNum = 0 Then ' Libere Projectile
                projectileSlot = i
                Exit For
            End If
        Next

        'Verificar por nenhum projetil; então apenas sobrescrever o primeiro espaço
        If projectileSlot = 0 Then projectileSlot = 1

        If spellnum < 1 OrElse spellnum > MAX_SKILLS Then Exit Sub

        projectileNum = Skill(spellnum).Projectile

        With MapProjectiles(mapNum, projectileSlot)
            .ProjectileNum = projectileNum
            .Owner = index
            .OwnerType = TargetType.Pet
            .Dir = Player(i).Character(TempPlayer(i).CurChar).Pet.Dir
            .X = Player(i).Character(TempPlayer(i).CurChar).Pet.X
            .Y = Player(i).Character(TempPlayer(i).CurChar).Pet.Y
            .Timer = GetTimeMs() + 60000
        End With

        SendProjectileToMap(mapNum, projectileSlot)

    End Sub

#End Region

#Region "Pet > Npc"

    Friend Sub TryPetAttackNpc(index As Integer, mapNpcNum As Integer)
        Dim blockAmount As Integer
        Dim npcnum As Integer
        Dim mapNum As Integer
        Dim damage As Integer


        ' Podemos atacar o NPC?
        If CanPetAttackNpc(index, mapNpcNum) Then

            mapNum = GetPlayerMap(index)
            npcnum = MapNpc(mapNum).Npc(mapNpcNum).Num

            ' check if NPC can avoid the attack
            If CanNpcDodge(npcnum) Then
                SendActionMsg(mapNum, "Desvio!", ColorType.Pink, 1, (MapNpc(mapNum).Npc(mapNpcNum).X * 32), (MapNpc(mapNum).Npc(mapNpcNum).Y * 32))
                Exit Sub
            End If

            If CanNpcParry(npcnum) Then
                SendActionMsg(mapNum, "Bloquio!", ColorType.Pink, 1, (MapNpc(mapNum).Npc(mapNpcNum).X * 32), (MapNpc(mapNum).Npc(mapNpcNum).Y * 32))
                Exit Sub
            End If

            ' Pegar o dano que podemos dar
            damage = GetPetDamage(index)

            ' Se o NPC bloquear, retirar a quantidade bloqueada
            blockAmount = CanNpcBlock(mapNpcNum)
            damage -= blockAmount

            ' Diminuir o dano pela armadura
            damage -= Random(1, (Npc(npcnum).Stat(StatType.Luck) * 2))
            ' Aleatorizar de um ao dano máximo
            damage = Random(1, damage)

            ' * 1.5 se for crítico!
            If CanPetCrit(index) Then
                damage *= 1.5
                SendActionMsg(mapNum, "Crítico!", ColorType.BrightCyan, 1, (GetPlayerX(index) * 32), (GetPlayerY(index) * 32))
            End If

            If damage > 0 Then
                PetAttackNpc(index, mapNpcNum, damage)
            Else
                PlayerMsg(index, "O ataque de seu pet não fez nada.", ColorType.BrightRed)
            End If

        End If

    End Sub

    Friend Function CanPetAttackNpc(attacker As Integer, mapnpcnum As Integer, Optional isSpell As Boolean = False) As Boolean
        Dim mapNum As Integer
        Dim npcnum As Integer
        Dim npcX As Integer
        Dim npcY As Integer
        Dim attackspeed As Integer

        If IsPlaying(attacker) = False OrElse mapnpcnum <= 0 OrElse mapnpcnum > MAX_MAP_NPCS OrElse Not PetAlive(attacker) Then
            Exit Function
        End If

        ' Verificar por subscript out of range
        If MapNpc(GetPlayerMap(attacker)).Npc(mapnpcnum).Num <= 0 Then Exit Function

        mapNum = GetPlayerMap(attacker)
        npcnum = MapNpc(mapNum).Npc(mapnpcnum).Num

        ' Ter certeza que o NPC já nao está morto
        If MapNpc(mapNum).Npc(mapnpcnum).Vital(VitalType.HP) <= 0 Then Exit Function

        ' Ter certeza que estão no mesmo mapa
        If IsPlaying(attacker) Then

            If TempPlayer(attacker).PetskillBuffer.Skill > 0 AndAlso isSpell = False Then Exit Function

            ' Sair mais cedo
            If isSpell AndAlso npcnum > 0 Then
                If Npc(npcnum).Behaviour <> NpcBehavior.Friendly AndAlso Npc(npcnum).Behaviour <> NpcBehavior.ShopKeeper Then
                    CanPetAttackNpc = True
                    Exit Function
                End If
            End If

            attackspeed = 1000 'Pet não pode usar arma

            If npcnum > 0 AndAlso GetTimeMs() > TempPlayer(attacker).PetAttackTimer + attackspeed Then

                ' Verificar se estão na mesma coordenada
                Select Case GetPetDir(attacker)

                    Case DirectionType.Up
                        npcX = MapNpc(mapNum).Npc(mapnpcnum).X
                        npcY = MapNpc(mapNum).Npc(mapnpcnum).Y + 1

                    Case DirectionType.Down
                        npcX = MapNpc(mapNum).Npc(mapnpcnum).X
                        npcY = MapNpc(mapNum).Npc(mapnpcnum).Y - 1

                    Case DirectionType.Left
                        npcX = MapNpc(mapNum).Npc(mapnpcnum).X + 1
                        npcY = MapNpc(mapNum).Npc(mapnpcnum).Y

                    Case DirectionType.Right
                        npcX = MapNpc(mapNum).Npc(mapnpcnum).X - 1
                        npcY = MapNpc(mapNum).Npc(mapnpcnum).Y

                End Select

                If npcX = GetPetX(attacker) AndAlso npcY = GetPetY(attacker) Then
                    If Npc(npcnum).Behaviour <> NpcBehavior.Friendly AndAlso Npc(npcnum).Behaviour <> NpcBehavior.ShopKeeper Then
                        CanPetAttackNpc = True
                    Else
                        CanPetAttackNpc = False
                    End If
                End If
            End If
        End If

    End Function

    Friend Sub PetAttackNpc(attacker As Integer, mapnpcnum As Integer, damage As Integer, Optional skillnum As Integer = 0) ', Optional overTime As Boolean = False)
        Dim name As String, exp As Integer
        Dim i As Integer, mapNum As Integer, npcnum As Integer

        ' Verificar por subscript out of range
        If IsPlaying(attacker) = False OrElse mapnpcnum <= 0 OrElse mapnpcnum > MAX_MAP_NPCS OrElse damage < 0 OrElse Not PetAlive(attacker) Then
            Exit Sub
        End If

        mapNum = GetPlayerMap(attacker)
        npcnum = MapNpc(mapNum).Npc(mapnpcnum).Num
        name = Trim$(Npc(npcnum).Name)

        If skillnum = 0 Then
            ' Enviar esta packet para que vejam o pet atacando
            SendPetAttack(attacker, mapNum)
        End If

        ' Setar o temporizador de regeneração
        TempPlayer(attacker).PetstopRegen = True
        TempPlayer(attacker).PetstopRegenTimer = GetTimeMs()

        If damage >= MapNpc(mapNum).Npc(mapnpcnum).Vital(VitalType.HP) Then

            SendActionMsg(GetPlayerMap(attacker), "-" & MapNpc(mapNum).Npc(mapnpcnum).Vital(VitalType.HP), ColorType.BrightRed, 1, (MapNpc(mapNum).Npc(mapnpcnum).X * 32), (MapNpc(mapNum).Npc(mapnpcnum).Y * 32))
            SendBlood(GetPlayerMap(attacker), MapNpc(mapNum).Npc(mapnpcnum).X, MapNpc(mapNum).Npc(mapnpcnum).Y)

            ' Calcule a experiência para dar ao atacante
            exp = Npc(npcnum).Exp

            ' Ter certeza que não pegamos menos que zero
            If exp < 0 Then
                exp = 1
            End If

            ' Em equipe?
            If TempPlayer(attacker).InParty > 0 Then
                ' Passar pela função de compartilhamento com a equipe
                Party_ShareExp(TempPlayer(attacker).InParty, exp, attacker, mapNum)
            Else
                ' Sem equipe - manter exp para si
                GivePlayerExp(attacker, exp)
            End If

            'For n = 1 To 20
            '    If MapNpc(MapNum).Npc(mapnpcnum).Num > 0 Then
            '        'SpawnItem(MapNpc(MapNum).Npc(mapnpcnum).Inventory(n).Num, MapNpc(MapNum).Npc(mapnpcnum).Inventory(n).Value, MapNum, MapNpc(MapNum).Npc(mapnpcnum).x, MapNpc(MapNum).Npc(mapnpcnum).y)
            '        'MapNpc(MapNum).Npc(mapnpcnum).Inventory(n).Value = 0
            '        'MapNpc(MapNum).Npc(mapnpcnum).Inventory(n).Num = 0
            '    End If
            'Next
            ' Agora setar o HP para 0 para que saibamos que os matamos no loop do servidor
            MapNpc(mapNum).Npc(mapnpcnum).Num = 0
            MapNpc(mapNum).Npc(mapnpcnum).SpawnWait = GetTimeMs()
            MapNpc(mapNum).Npc(mapnpcnum).Vital(VitalType.HP) = 0
            MapNpc(mapNum).Npc(mapnpcnum).TargetType = 0
            MapNpc(mapNum).Npc(mapnpcnum).Target = 0

            ' Limpar DoTs e HoTs
            'For i = 1 To MAX_COTS
            '    With MapNpc(MapNum).Npc(mapnpcnum).DoT(i)
            '        .Spell = 0
            '        .Timer = 0
            '        .Caster = 0
            '        .StartTime = 0
            '        .Used = False
            '    End With
            '    With MapNpc(MapNum).Npc(mapnpcnum).HoT(i)
            '        .Spell = 0
            '        .Timer = 0
            '        .Caster = 0
            '        .StartTime = 0
            '        .Used = False
            '    End With
            'Next

            ' Mandar morte para o mapa
            SendNpcDead(mapNum, mapnpcnum)

            'Fazer loop por todo o mapa e tirar o NPCs dos alvos
            For i = 1 To Socket.HighIndex

                If IsPlaying(i) Then
                    If GetPlayerMap(i) = mapNum Then
                        If TempPlayer(i).TargetType = TargetType.Npc Then
                            If TempPlayer(i).Target = mapnpcnum Then
                                TempPlayer(i).Target = 0
                                TempPlayer(i).TargetType = TargetType.None
                                SendTarget(i, 0, TargetType.None)
                            End If
                        End If

                        If TempPlayer(i).PetTargetType = TargetType.Npc Then
                            If TempPlayer(i).PetTarget = mapnpcnum Then
                                TempPlayer(i).PetTarget = 0
                                TempPlayer(i).PetTargetType = TargetType.None
                            End If
                        End If
                    End If
                End If
            Next
        Else
            ' NPC não morreu, apenas dê o dano
            MapNpc(mapNum).Npc(mapnpcnum).Vital(VitalType.HP) = MapNpc(mapNum).Npc(mapnpcnum).Vital(VitalType.HP) - damage

            ' Verificar a arma e dar o dano
            SendActionMsg(mapNum, "-" & damage, ColorType.BrightRed, 1, (MapNpc(mapNum).Npc(mapnpcnum).X * 32), (MapNpc(mapNum).Npc(mapnpcnum).Y * 32))
            SendBlood(GetPlayerMap(attacker), MapNpc(mapNum).Npc(mapnpcnum).X, MapNpc(mapNum).Npc(mapnpcnum).Y)

            ' Enviar o som
            'If Spellnum > 0 Then SendMapSound Attacker, MapNpc(MapNum).Npc(mapnpcnum).x, MapNpc(MapNum).Npc(mapnpcnum).y, SoundEntity.seSpell, Spellnum

            ' Alterar o alvo do NPC para o jogador
            MapNpc(mapNum).Npc(mapnpcnum).TargetType = TargetType.Pet ' pet do jogador
            MapNpc(mapNum).Npc(mapnpcnum).Target = attacker

            ' Agora verificar a inteligência defesa e se sim, ter todos os guardas atrás deles
            If Npc(MapNpc(mapNum).Npc(mapnpcnum).Num).Behaviour = NpcBehavior.Guard Then

                For i = 1 To MAX_MAP_NPCS

                    If MapNpc(mapNum).Npc(i).Num = MapNpc(mapNum).Npc(mapnpcnum).Num Then
                        MapNpc(mapNum).Npc(i).Target = attacker
                        MapNpc(mapNum).Npc(i).TargetType = TargetType.Pet ' pet
                    End If
                Next
            End If

            ' Setar o temporizador de regeneração
            MapNpc(mapNum).Npc(mapnpcnum).StopRegen = True
            MapNpc(mapNum).Npc(mapnpcnum).StopRegenTimer = GetTimeMs()

            ' Se magia estuporante, estuporar o NPC
            If skillnum > 0 Then
                If Skill(skillnum).StunDuration > 0 Then StunNPC(mapnpcnum, mapNum, skillnum)
                ' DoT
                If Skill(skillnum).Duration > 0 Then
                    'AddDoT_Npc(MapNum, mapnpcnum, Skillnum, Attacker, 3)
                End If
            End If

            SendMapNpcVitals(mapNum, mapnpcnum)
        End If

        If skillnum = 0 Then
            ' Resetar temporiador de ataque
            TempPlayer(attacker).PetAttackTimer = GetTimeMs()
        End If

    End Sub

#End Region

#Region "Npc > Pet"

    Friend Sub TryNpcAttackPet(mapNpcNum As Integer, index As Integer)

        Dim mapNum As Integer, npcnum As Integer, damage As Integer

        ' O NPC pode atacar o pet?

        If CanNpcAttackPet(mapNpcNum, index) Then
            mapNum = GetPlayerMap(index)
            npcnum = MapNpc(mapNum).Npc(mapNpcNum).Num

            ' Ver se o pet pode desviar do ataque
            If CanPetDodge(index) Then
                SendActionMsg(mapNum, "Desvio!", ColorType.Pink, ActionMsgType.Scroll, (GetPetX(index) * 32), (GetPetY(index) * 32))
                Exit Sub
            End If

            ' Pegar o dano que podemos fazer
            damage = GetNpcDamage(npcnum)

            ' Subtrair armadura
            damage -= ((GetPetStat(index, StatType.Endurance) * 2) + (GetPetLevel(index) * 2))

            ' * 1.5 se crítico
            If CanNpcCrit(npcnum) Then
                damage *= 1.5
                SendActionMsg(mapNum, "Crítico!", ColorType.BrightCyan, ActionMsgType.Scroll, (MapNpc(mapNum).Npc(mapNpcNum).X * 32), (MapNpc(mapNum).Npc(mapNpcNum).Y * 32))
            End If
        End If

        If damage > 0 Then
            NpcAttackPet(mapNpcNum, index, damage)
        End If

    End Sub

    Function CanNpcAttackPet(mapNpcNum As Integer, index As Integer) As Boolean
        Dim mapNum As Integer
        Dim npcnum As Integer

        CanNpcAttackPet = False

        If mapNpcNum <= 0 OrElse mapNpcNum > MAX_MAP_NPCS OrElse Not IsPlaying(index) OrElse Not PetAlive(index) Then
            Exit Function
        End If

        ' Verificar por subscript out of range
        If MapNpc(GetPlayerMap(index)).Npc(mapNpcNum).Num <= 0 Then Exit Function

        mapNum = GetPlayerMap(index)
        npcnum = MapNpc(mapNum).Npc(mapNpcNum).Num

        'Ter certeza que o NPC já não está morto
        If MapNpc(mapNum).Npc(mapNpcNum).Vital(VitalType.HP) <= 0 Then Exit Function

        ' Ter certeza que os NPCs não ataquem masi de uma vez por segundo
        If GetTimeMs() < MapNpc(mapNum).Npc(mapNpcNum).AttackTimer + 1000 Then Exit Function

        ' Ter certeza que não atacamos o jogador se ele está trocando de mapa
        If TempPlayer(index).GettingMap = 1 Then Exit Function

        MapNpc(mapNum).Npc(mapNpcNum).AttackTimer = GetTimeMs()

        ' Ter certeza que está no mesmo mapa
        If IsPlaying(index) AndAlso PetAlive(index) Then
            If npcnum > 0 Then

                ' Ver se está na mesma coordenada
                If (GetPetY(index) + 1 = MapNpc(mapNum).Npc(mapNpcNum).Y) AndAlso (GetPetX(index) = MapNpc(mapNum).Npc(mapNpcNum).X) Then
                    CanNpcAttackPet = True
                Else

                    If (GetPetY(index) - 1 = MapNpc(mapNum).Npc(mapNpcNum).Y) AndAlso (GetPetX(index) = MapNpc(mapNum).Npc(mapNpcNum).X) Then
                        CanNpcAttackPet = True
                    Else

                        If (GetPetY(index) = MapNpc(mapNum).Npc(mapNpcNum).Y) AndAlso (GetPetX(index) + 1 = MapNpc(mapNum).Npc(mapNpcNum).X) Then
                            CanNpcAttackPet = True
                        Else

                            If (GetPetY(index) = MapNpc(mapNum).Npc(mapNpcNum).Y) AndAlso (GetPetX(index) - 1 = MapNpc(mapNum).Npc(mapNpcNum).X) Then
                                CanNpcAttackPet = True
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Function

    Sub NpcAttackPet(mapnpcnum As Integer, victim As Integer, damage As Integer)
        Dim name As String, mapNum As Integer

        ' Verificar por subscript out of range
        If mapnpcnum <= 0 OrElse mapnpcnum > MAX_MAP_NPCS OrElse IsPlaying(victim) = False OrElse Not PetAlive(victim) Then
            Exit Sub
        End If

        ' Verificar por subscript out of range
        If MapNpc(GetPlayerMap(victim)).Npc(mapnpcnum).Num <= 0 Then Exit Sub

        mapNum = GetPlayerMap(victim)
        name = Trim$(Npc(MapNpc(mapNum).Npc(mapnpcnum).Num).Name)

        ' Enviar esta packet para que vejam o NPC atacando
        SendNpcAttack(victim, mapnpcnum)

        If damage <= 0 Then Exit Sub

        ' Setar temporizador de regeneração
        MapNpc(mapNum).Npc(mapnpcnum).StopRegen = True
        MapNpc(mapNum).Npc(mapnpcnum).StopRegenTimer = GetTimeMs()

        If damage >= GetPetVital(victim, VitalType.HP) Then
            ' Falar dano
            SendActionMsg(GetPlayerMap(victim), "-" & GetPetVital(victim, VitalType.HP), ColorType.BrightRed, ActionMsgType.Scroll, (GetPetX(victim) * 32), (GetPetY(victim) * 32))

            ' Matar pet
            PlayerMsg(victim, "Seu " & Trim$(GetPetName(victim)) & " foi morto por " & Trim$(Npc(MapNpc(mapNum).Npc(mapnpcnum).Num).Name) & ".", ColorType.BrightRed)
            ReCallPet(victim)

            ' Agora que o pet morreu, ir atrás do dono
            MapNpc(mapNum).Npc(mapnpcnum).Target = victim
            MapNpc(mapNum).Npc(mapnpcnum).TargetType = TargetType.Player
        Else
            ' Pet não morreu, apenas fazer dano
            SetPetVital(victim, VitalType.HP, GetPetVital(victim, VitalType.HP) - damage)
            SendPetVital(victim, VitalType.HP)
            SendAnimation(mapNum, Npc(MapNpc(GetPlayerMap(victim)).Npc(mapnpcnum).Num).Animation, 0, 0, TargetType.Pet, victim)

            ' Dizer dano
            SendActionMsg(GetPlayerMap(victim), "-" & damage, ColorType.BrightRed, ActionMsgType.Scroll, (GetPetX(victim) * 32), (GetPetY(victim) * 32))
            SendBlood(GetPlayerMap(victim), GetPetX(victim), GetPetY(victim))

            ' Setar timer de regeneração
            TempPlayer(victim).PetstopRegen = True
            TempPlayer(victim).PetstopRegenTimer = GetTimeMs()

            'Pet foi atacado, vamos alterar o alvo
            TempPlayer(victim).PetTarget = mapnpcnum
            TempPlayer(victim).PetTargetType = TargetType.Npc
        End If

    End Sub

#End Region

#Region "Pet > Player"

    Function CanPetAttackPlayer(attacker As Integer, victim As Integer, Optional isSkill As Boolean = False) As Boolean

        If Not isSkill Then
            If GetTimeMs() < TempPlayer(attacker).PetAttackTimer + 1000 Then Exit Function
        End If

        ' Verificar por subscript out of range
        If Not IsPlaying(victim) Then Exit Function

        ' Ter certeza que estão no mesmo mapa
        If Not GetPlayerMap(attacker) = GetPlayerMap(victim) Then Exit Function

        ' Ter certeza que não estamos atacando o jogador se estiver trocando de mapa
        If TempPlayer(victim).GettingMap = 1 Then Exit Function

        If TempPlayer(attacker).PetskillBuffer.Skill > 0 AndAlso isSkill = False Then Exit Function

        If Not isSkill Then
            ' Verificar se está nas mesmas coordenadas
            Select Case GetPetDir(attacker)
                Case DirectionType.Up
                    If Not (GetPlayerY(victim) + 1 = GetPetY(attacker)) AndAlso (GetPlayerX(victim) = GetPetX(attacker)) Then Exit Function

                Case DirectionType.Down
                    If Not (GetPlayerY(victim) - 1 = GetPetY(attacker)) AndAlso (GetPlayerX(victim) = GetPetX(attacker)) Then Exit Function

                Case DirectionType.Left
                    If Not (GetPlayerY(victim) = GetPetY(attacker)) AndAlso (GetPlayerX(victim) + 1 = GetPetX(attacker)) Then Exit Function

                Case DirectionType.Right
                    If Not (GetPlayerY(victim) = GetPetY(attacker)) AndAlso (GetPlayerX(victim) - 1 = GetPetX(attacker)) Then Exit Function

                Case Else
                    Exit Function
            End Select
        End If

        ' Verificar se o mapa é atacável
        If Not Map(GetPlayerMap(attacker)).Moral = MapMoralType.None Then
            If GetPlayerPK(victim) = 0 Then
                Exit Function
            End If
        End If

        ' Ter certeza que tem mais que zero de HP
        If GetPlayerVital(victim, VitalType.HP) <= 0 Then Exit Function

        ' Ter certeza que não tem acesso
        If GetPlayerAccess(attacker) > AdminType.Monitor Then
            PlayerMsg(attacker, "Admins não podem atacar outros jogadores.", ColorType.Yellow)
            Exit Function
        End If

        ' Ter certeza que a vítima não é um administrador
        If GetPlayerAccess(victim) > AdminType.Monitor Then
            PlayerMsg(attacker, "Você não pode atacar " & GetPlayerName(victim) & "!", ColorType.Yellow)
            Exit Function
        End If

        ' Não atacar um membro da equipe
        If TempPlayer(attacker).InParty > 0 AndAlso TempPlayer(victim).InParty > 0 Then
            If TempPlayer(attacker).InParty = TempPlayer(victim).InParty Then
                PlayerMsg(attacker, "Você não pode atacar um membro da sua equipe!", ColorType.Yellow)
                Exit Function
            End If
        End If

        CanPetAttackPlayer = True

    End Function

    Sub PetAttackPlayer(attacker As Integer, victim As Integer, damage As Integer, Optional skillNum As Integer = 0)
        Dim exp As Integer, i As Integer

        ' Verificar por subscript out of range

        If IsPlaying(attacker) = False OrElse IsPlaying(victim) = False OrElse damage < 0 OrElse PetAlive(attacker) = False Then
            Exit Sub
        End If

        If skillNum = 0 Then
            ' Enviar esta packet para ver o pet atacando
            SendPetAttack(attacker, victim)
        End If

        ' Setar o timer de regeneração
        TempPlayer(attacker).PetstopRegen = True
        TempPlayer(attacker).PetstopRegenTimer = GetTimeMs()

        If damage >= GetPlayerVital(victim, VitalType.HP) Then
            SendActionMsg(GetPlayerMap(victim), "-" & GetPlayerVital(victim, VitalType.HP), ColorType.BrightRed, 1, (GetPlayerX(victim) * 32), (GetPlayerY(victim) * 32))

            ' Enviar o som
            'If SkillNum > 0 Then SendMapSound(Victim, GetPlayerX(Victim), GetPlayerY(Victim), SoundEntity.seSpell, SkillNum)

            ' Jogador morreu
            GlobalMsg(GetPlayerName(victim) & " foi morto pelo " & Trim$(GetPetName(attacker)) & " de " & GetPlayerName(attacker) & ".")

            ' Calcular exp para dar ao atacante
            exp = (GetPlayerExp(victim) \ 10)

            ' Ter certeza que não pegamos menos que zero
            If exp < 0 Then
                exp = 0
            End If

            If exp = 0 Then
                PlayerMsg(victim, "Você não perdeu experiência.", ColorType.BrightGreen)
                PlayerMsg(attacker, "You não recebeu experiência.", ColorType.BrightRed)
            Else
                SetPlayerExp(victim, GetPlayerExp(victim) - exp)
                SendExp(victim)
                PlayerMsg(victim, "Você perdeu " & exp & " de experiência.", ColorType.BrightRed)

                ' Ver se estamos em equipe
                If TempPlayer(attacker).InParty > 0 Then
                    ' Usar a função de compartilhar exp
                    Party_ShareExp(TempPlayer(attacker).InParty, exp, attacker, GetPlayerMap(attacker))
                Else
                    ' Não está na equipe, pegar a exp toda pra si
                    GivePlayerExp(attacker, exp)
                End If
            End If

            ' Tirar a informação de alvo de qualquer um que tenha o NPC como alvo
            For i = 1 To Socket.HighIndex

                If IsPlaying(i) AndAlso Socket.IsConnected(i) Then
                    If GetPlayerMap(i) = GetPlayerMap(attacker) Then
                        If TempPlayer(i).TargetType = TargetType.Player Then
                            If TempPlayer(i).Target = victim Then
                                TempPlayer(i).Target = 0
                                TempPlayer(i).TargetType = TargetType.None
                                SendTarget(i, 0, TargetType.None)
                            End If
                        End If

                        If Player(i).Character(TempPlayer(i).CurChar).Pet.Alive = 1 Then
                            If TempPlayer(i).PetTargetType = TargetType.Player Then
                                If TempPlayer(i).PetTarget = victim Then
                                    TempPlayer(i).PetTarget = 0
                                    TempPlayer(i).PetTargetType = TargetType.None
                                End If
                            End If
                        End If
                    End If
                End If
            Next

            If GetPlayerPK(victim) = 0 Then
                If GetPlayerPK(attacker) = 0 Then
                    SetPlayerPK(attacker, 1)
                    SendPlayerData(attacker)
                    GlobalMsg(GetPlayerName(attacker) & " agora é considerado um Player Killer!!!")
                End If
            Else
                GlobalMsg(GetPlayerName(victim) & " pagou o preço por ser um Player Killer!!!")
            End If

            OnDeath(victim)
        Else
            ' Jogador nao morreu, apenas dar dano
            SetPlayerVital(victim, VitalType.HP, GetPlayerVital(victim, VitalType.HP) - damage)
            SendVital(victim, VitalType.HP)

            ' Enviar vitais para a equipe, se houver alguém
            If TempPlayer(victim).InParty > 0 Then SendPartyVitals(TempPlayer(victim).InParty, victim)

            ' Enviar som
            'If SkillNum > 0 Then SendMapSound(Victim, GetPlayerX(Victim), GetPlayerY(Victim), SoundEntity.seSpell, SkillNum)

            SendActionMsg(GetPlayerMap(victim), "-" & damage, ColorType.BrightRed, 1, (GetPlayerX(victim) * 32), (GetPlayerY(victim) * 32))
            SendBlood(GetPlayerMap(victim), GetPlayerX(victim), GetPlayerY(victim))

            ' Setar temporizador de regenerar
            TempPlayer(victim).StopRegen = True
            TempPlayer(victim).StopRegenTimer = GetTimeMs()

            'Se magia estuporante, estuporar jogador
            If skillNum > 0 Then
                If Skill(skillNum).StunDuration > 0 Then StunPlayer(victim, skillNum)

                ' DoT
                If Skill(skillNum).Duration > 0 Then
                    'AddDoT_Player(Victim, SkillNum, Attacker)
                End If
            End If
        End If

        ' Resetar temporizador de ataque
        TempPlayer(attacker).PetAttackTimer = GetTimeMs()

    End Sub

    Friend Sub TryPetAttackPlayer(index As Integer, victim As Integer)
        Dim mapNum As Integer, blockAmount As Integer, damage As Integer

        If GetPlayerMap(index) <> GetPlayerMap(victim) Then Exit Sub

        If Not PetAlive(index) Then Exit Sub

        ' NPC pode atacar o jogador?
        If CanPetAttackPlayer(index, victim) Then
            mapNum = GetPlayerMap(index)

            ' Verificar se jogador pode desviar do ataque
            If CanPlayerDodge(victim) Then
                SendActionMsg(mapNum, "Desvio!", ColorType.Pink, 1, (GetPlayerX(victim) * 32), (GetPlayerY(victim) * 32))
                Exit Sub
            End If

            If CanPlayerParry(victim) Then
                SendActionMsg(mapNum, "Bloqueio!", ColorType.Pink, 1, (GetPlayerX(victim) * 32), (GetPlayerY(victim) * 32))
                Exit Sub
            End If

            ' Pegar o dano que podemos fazer
            damage = GetPetDamage(index)

            ' se o jogador bloquear, subtrair o que foi bloqueado
            blockAmount = CanPlayerBlockHit(victim)
            damage -= blockAmount

            ' subtrair armadura
            damage -= Random(1, (GetPetStat(index, StatType.Luck)) * 2)

            ' aleatorizar até 10% mais baixo que o dano máximo
            damage = Random(1, damage)

            ' * 1.5 se crítico
            If CanPetCrit(index) Then
                damage *= 1.5
                SendActionMsg(mapNum, "Crítico!", ColorType.BrightCyan, 1, (GetPetX(index) * 32), (GetPetY(index) * 32))
            End If

            If damage > 0 Then
                PetAttackPlayer(index, victim, damage)
            End If

        End If

    End Sub

#End Region

#Region "Pet > Pet"

    Function CanPetAttackPet(attacker As Integer, victim As Integer, Optional isSkill As Integer = 0) As Boolean

        If Not isSkill Then
            If GetTimeMs() < TempPlayer(attacker).PetAttackTimer + 1000 Then Exit Function
        End If

        ' Verificar por subscript out of range
        If Not IsPlaying(victim) OrElse Not IsPlaying(attacker) Then Exit Function

        ' Ter certeza que estão no mesmo mapa
        If Not GetPlayerMap(attacker) = GetPlayerMap(victim) Then Exit Function

        ' Ter certeza que não estamos atacando um jogador que está trocando de mapa
        If TempPlayer(victim).GettingMap = 1 Then Exit Function

        If TempPlayer(attacker).PetskillBuffer.Skill > 0 AndAlso isSkill = False Then Exit Function

        If Not isSkill Then

            ' Verificar se está na mesma coordenada
            Select Case GetPetDir(attacker)
                Case DirectionType.Up
                    If Not ((GetPetY(victim) - 1 = GetPetY(attacker)) AndAlso (GetPetX(victim) = GetPetX(attacker))) Then Exit Function

                Case DirectionType.Down
                    If Not ((GetPetY(victim) + 1 = GetPetY(attacker)) AndAlso (GetPetX(victim) = GetPetX(attacker))) Then Exit Function

                Case DirectionType.Left
                    If Not ((GetPetY(victim) = GetPetY(attacker)) AndAlso (GetPetX(victim) + 1 = GetPetX(attacker))) Then Exit Function

                Case DirectionType.Right
                    If Not ((GetPetY(victim) = GetPetY(attacker)) AndAlso (GetPetX(victim) - 1 = GetPetX(attacker))) Then Exit Function

                Case Else
                    Exit Function
            End Select
        End If

        ' Verificar se o mapa é atacável
        If Not Map(GetPlayerMap(attacker)).Moral = MapMoralType.None Then
            If GetPlayerPK(victim) = 0 Then
                Exit Function
            End If
        End If

        ' Ter certeza que tem mais de 0 de hp
        If Player(victim).Character(TempPlayer(victim).CurChar).Pet.Health <= 0 Then Exit Function

        ' Ter certeza que não tem acesso
        If GetPlayerAccess(attacker) > AdminType.Monitor Then
            PlayerMsg(attacker, "Administradores não podem atacar outros jogadores.", ColorType.BrightRed)
            Exit Function
        End If

        ' Ter certeza que a vítima não é um adminisrador
        If GetPlayerAccess(victim) > AdminType.Monitor Then
            PlayerMsg(attacker, "Você não pode atacar " & GetPlayerName(victim) & "!", ColorType.BrightRed)
            Exit Function
        End If

        ' Não atacar um membro da equipe
        If TempPlayer(attacker).InParty > 0 AndAlso TempPlayer(victim).InParty > 0 Then
            If TempPlayer(attacker).InParty = TempPlayer(victim).InParty Then
                PlayerMsg(attacker, "Você não pode atacar outro membro da equipe!", ColorType.BrightRed)
                Exit Function
            End If
        End If

        If TempPlayer(attacker).InParty > 0 AndAlso TempPlayer(victim).InParty > 0 AndAlso TempPlayer(attacker).InParty = TempPlayer(victim).InParty Then
            If isSkill > 0 Then
                If Skill(isSkill).Type = SkillType.HealMp OrElse Skill(isSkill).Type = SkillType.HealHp Then
                    'Carry On :D
                Else
                    Exit Function
                End If
            Else
                Exit Function
            End If
        End If

        CanPetAttackPet = True

    End Function

    Sub PetAttackPet(attacker As Integer, victim As Integer, damage As Integer, Optional skillnum As Integer = 0)
        Dim exp As Integer, i As Integer

        ' Verificar por subscript out of range

        If IsPlaying(attacker) = False OrElse IsPlaying(victim) = False OrElse damage < 0 OrElse PetAlive(attacker) = False OrElse PetAlive(victim) = False Then
            Exit Sub
        End If

        If skillnum = 0 Then
            ' Enviar esta packet para que se veja o pet atacando
            SendPetAttack(attacker, victim)
        End If

        ' Setar timer de regeneração
        TempPlayer(attacker).PetstopRegen = True
        TempPlayer(attacker).PetstopRegenTimer = GetTimeMs()

        If damage >= GetPetVital(victim, VitalType.HP) Then
            SendActionMsg(GetPlayerMap(victim), "-" & GetPetVital(victim, VitalType.HP), ColorType.BrightRed, ActionMsgType.Scroll, (GetPetX(victim) * 32), (GetPetY(victim) * 32))

            ' Enviar som
            'If Spellnum > 0 Then SendMapSound Victim, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.x, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.y, SoundEntity.seSpell, Spellnum

            ' Jogador está morto
            GlobalMsg(GetPlayerName(victim) & " foi morto pelo " & Trim$(GetPetName(attacker)) & " de " & GetPlayerName(attacker) & ".")

            ' Calcular exp para dar ao atacante
            exp = (GetPlayerExp(victim) \ 10)

            ' Ter certeza que não pegamos menos que zero
            If exp < 0 Then exp = 0

            If exp = 0 Then
                PlayerMsg(victim, "Você não perdeu experiência.", ColorType.BrightGreen)
                PlayerMsg(attacker, "Você não recebeu experiência.", ColorType.Yellow)
            Else
                SetPlayerExp(victim, GetPlayerExp(victim) - exp)
                SendExp(victim)
                PlayerMsg(victim, "You lost " & exp & " exp.", ColorType.BrightRed)

                ' Verificar se estamos em equipe
                If TempPlayer(attacker).InParty > 0 Then
                    ' Passar pela função de compatilhamento com equipe
                    Party_ShareExp(TempPlayer(attacker).InParty, exp, attacker, GetPlayerMap(attacker))
                Else
                    ' Não está em equipe, pegar para si
                    GivePlayerExp(attacker, exp)
                End If
            End If

            ' Limpar informação de todo mundo que tem o morto como alvo
            For i = 1 To Socket.HighIndex

                If IsPlaying(i) AndAlso Socket.IsConnected(i) Then
                    If GetPlayerMap(i) = GetPlayerMap(attacker) Then
                        If TempPlayer(i).TargetType = TargetType.Player Then
                            If TempPlayer(i).Target = victim Then
                                TempPlayer(i).Target = 0
                                TempPlayer(i).TargetType = TargetType.None
                                SendTarget(i, 0, TargetType.None)
                            End If
                        End If

                        If PetAlive(i) Then
                            If TempPlayer(i).PetTargetType = TargetType.Player Then
                                If TempPlayer(i).PetTarget = victim Then
                                    TempPlayer(i).PetTarget = 0
                                    TempPlayer(i).PetTargetType = TargetType.None
                                End If
                            End If
                        End If
                    End If
                End If
            Next

            If GetPlayerPK(victim) = 0 Then
                If GetPlayerPK(attacker) = 0 Then
                    SetPlayerPK(attacker, 1)
                    SendPlayerData(attacker)
                    GlobalMsg(GetPlayerName(attacker) & " foi declarado um Player Killer!!!")
                End If
            Else
                GlobalMsg(GetPlayerName(victim) & " pagou o preço por ser um Player Killer!!!")
            End If

            ' kill pet
            PlayerMsg(victim, "Seu " & Trim$(GetPetName(victim)) & " foi morto pelo " & Trim$(GetPetName(attacker)) & " de " & Trim$(GetPlayerName(attacker)) & "!", ColorType.BrightRed)
            ReleasePet(victim)
        Else
            ' Jogador não está morto, apenas faça o dano
            SetPetVital(victim, VitalType.HP, GetPetVital(victim, VitalType.HP) - damage)
            SendPetVital(victim, VitalType.HP)

            'Set pet to begin attacking the other pet if it isn't dead or dosent have another target
            If TempPlayer(victim).PetTarget <= 0 AndAlso TempPlayer(victim).PetBehavior <> PetBehaviourGoto Then
                TempPlayer(victim).PetTarget = attacker
                TempPlayer(victim).PetTargetType = TargetType.Pet
            End If

            ' Enviar som
            'If Spellnum > 0 Then SendMapSound Victim, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.x, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.y, SoundEntity.seSpell, Spellnum

            SendActionMsg(GetPlayerMap(victim), "-" & damage, ColorType.BrightRed, 1, (GetPetX(victim) * 32), (GetPetY(victim) * 32))
            SendBlood(GetPlayerMap(victim), GetPetX(victim), GetPetY(victim))

            ' Setar timer de regeneração
            TempPlayer(victim).PetstopRegen = True
            TempPlayer(victim).PetstopRegenTimer = GetTimeMs()

            'Se magia estuporante, estuporar o jogador
            If skillnum > 0 Then
                If Skill(skillnum).StunDuration > 0 Then StunPet(victim, skillnum)
                ' DoT
                If Skill(skillnum).Duration > 0 Then
                    'AddDoT_Pet(Victim, Skillnum, Attacker, TargetType.Pet)
                End If
            End If
        End If

        ' Resetar temporizador de ataque
        TempPlayer(attacker).PetAttackTimer = GetTimeMs()

    End Sub

    Friend Sub TryPetAttackPet(index As Integer, victim As Integer)
        Dim mapNum As Integer, blockAmount As Integer, damage As Integer

        If GetPlayerMap(index) <> GetPlayerMap(victim) Then Exit Sub

        If Not PetAlive(index) OrElse Not PetAlive(victim) Then Exit Sub

        ' O NPC pode atacar o jogador?
        If CanPetAttackPet(index, victim) Then
            mapNum = GetPlayerMap(index)

            ' Ver se o pet pode desviar do ataque
            If CanPetDodge(victim) Then
                SendActionMsg(mapNum, "Desvio!", ColorType.Pink, 1, (GetPetX(victim) * 32), (GetPetY(victim) * 32))
                Exit Sub
            End If

            If CanPetParry(victim) Then
                SendActionMsg(mapNum, "Bloqueio!", ColorType.Pink, 1, (GetPetX(victim) * 32), (GetPetY(victim) * 32))
                Exit Sub
            End If

            ' Pegar o dano que podemos fazer
            damage = GetPetDamage(index)

            ' Se o jogador bloquear, subtrair o bloqueio
            damage -= blockAmount

            ' Descontar armadura
            damage -= Random(1, (Player(index).Character(TempPlayer(index).CurChar).Pet.Stat(StatType.Luck) * 2))

            ' Aleatorizar para até 10% mais baixo que o dano máximo
            damage = Random(1, damage)

            ' * 1.5 se crítico
            If CanPetCrit(index) Then
                damage *= 1.5
                SendActionMsg(mapNum, "Crítico!", ColorType.BrightCyan, 1, (GetPetX(index) * 32), (GetPetY(index) * 32))
            End If

            If damage > 0 Then
                PetAttackPet(index, victim, damage)
            End If

        End If

    End Sub

#End Region

#Region "Skills"

    Friend Sub BufferPetSkill(index As Integer, skillSlot As Integer)
        Dim skillnum As Integer, mpCost As Integer, levelReq As Integer
        Dim mapNum As Integer, skillCastType As Integer
        Dim accessReq As Integer, range As Integer, hasBuffered As Boolean
        Dim targetTypes As Byte, target As Integer

        ' Prevenir subscript out of range

        If skillSlot <= 0 OrElse skillSlot > 4 Then Exit Sub

        skillnum = Player(index).Character(TempPlayer(index).CurChar).Pet.Skill(skillSlot)
        mapNum = GetPlayerMap(index)

        If skillnum <= 0 OrElse skillnum > MAX_SKILLS Then Exit Sub

        ' Ver se o cooldown terminou
        If TempPlayer(index).PetSkillCd(skillSlot) > GetTimeMs() Then
            PlayerMsg(index, "A habilidade de " & Trim$(GetPetName(index)) & " ainda não está pronta!", ColorType.BrightRed)
            Exit Sub
        End If

        mpCost = Skill(skillnum).MpCost

        ' Ver se ainda tem MP suficiente
        If GetPetVital(index, VitalType.MP) < mpCost Then
            PlayerMsg(index, "Seu " & Trim$(GetPetName(index)) & " não tem mana suficiente!", ColorType.BrightRed)
            Exit Sub
        End If

        levelReq = Skill(skillnum).LevelReq

        ' Ter certeza que atinge requerimentos de nível
        If levelReq > GetPetLevel(index) Then
            PlayerMsg(index, Trim$(GetPetName(index)) & " deve ter o nível " & levelReq & " para usar essa habilidade.", ColorType.BrightRed)
            Exit Sub
        End If

        accessReq = Skill(skillnum).AccessReq

        ' Ter certeza que tem o acesso correto
        If accessReq > GetPlayerAccess(index) Then
            PlayerMsg(index, "Você deve ser um administrador pra usar essa magia, mesmo como dono do pet.", ColorType.BrightRed)
            Exit Sub
        End If

        ' descobrir que tipo de magia é! si proprio, alvo ou área
        If Skill(skillnum).Range > 0 Then

            ' ataque a distancia, alvo simples ou area?
            If Not Skill(skillnum).IsAoE Then
                skillCastType = 2 ' alvo
            Else
                skillCastType = 3 ' área alvo
            End If
        Else
            If Not Skill(skillnum).IsAoE Then
                skillCastType = 0 ' si proprio
            Else
                skillCastType = 1 ' área em si próprio
            End If
        End If

        targetTypes = TempPlayer(index).PetTargetType
        target = TempPlayer(index).PetTarget
        range = Skill(skillnum).Range
        hasBuffered = False

        Select Case skillCastType

            'PET
            Case 0, 1, SkillType.Pet ' si & área em si

                hasBuffered = True

            Case 2, 3 ' alvo & área alvo

                ' ver se tem alvo
                If Not target > 0 Then
                    If skillCastType = SkillType.HealHp OrElse skillCastType = SkillType.HealMp Then
                        target = index
                        targetTypes = TargetType.Pet
                    Else
                        PlayerMsg(index, "Seu " & Trim$(GetPetName(index)) & " não tem um alvo.", ColorType.Yellow)
                    End If
                End If

                If targetTypes = TargetType.Player Then

                    ' se tem alvo, verificar se está ao alcance
                    If Not IsInRange(range, GetPetX(index), GetPetY(index), GetPlayerX(target), GetPlayerY(target)) Then
                        PlayerMsg(index, "Alvo não está ao alcance de " & Trim$(GetPetName(index)) & ".", ColorType.Yellow)
                    Else
                        ' percorrer pelos tipos de magias
                        If Skill(skillnum).Type <> SkillType.DamageHp AndAlso Skill(skillnum).Type <> SkillType.DamageMp Then
                            hasBuffered = True
                        Else
                            If CanPetAttackPlayer(index, target, True) Then
                                hasBuffered = True
                            End If
                        End If
                    End If

                ElseIf targetTypes = TargetType.Npc Then

                    ' se tiver alvo, verificar se está ao alcance
                    If Not IsInRange(range, GetPetX(index), GetPetY(index), MapNpc(mapNum).Npc(target).X, MapNpc(mapNum).Npc(target).Y) Then
                        PlayerMsg(index, "Alvo não está ao alcance de " & Trim$(GetPetName(index)) & ".", ColorType.Yellow)
                        hasBuffered = False
                    Else
                        ' percorrer pelos tipos de magias
                        If Skill(skillnum).Type <> SkillType.DamageHp AndAlso Skill(skillnum).Type <> SkillType.DamageMp Then
                            hasBuffered = True
                        Else
                            If CanPetAttackNpc(index, target, True) Then
                                hasBuffered = True
                            End If
                        End If
                    End If

                    'PET
                ElseIf targetTypes = TargetType.Pet Then

                    ' se tiver alvo, verificar o alcance
                    If Not IsInRange(range, GetPetX(index), GetPetY(index), GetPetX(target), GetPetY(target)) Then
                        PlayerMsg(index, "Alvo não está ao alcance de " & GetPetName(index).Trim & ".", ColorType.Yellow)
                        hasBuffered = False
                    Else
                        ' percorrer pelos tipos de magia
                        If Skill(skillnum).Type <> SkillType.DamageHp AndAlso Skill(skillnum).Type <> SkillType.DamageMp Then
                            hasBuffered = True
                        Else
                            If CanPetAttackPet(index, target, skillnum) Then
                                hasBuffered = True
                            End If
                        End If
                    End If
                End If
        End Select

        If hasBuffered Then
            SendAnimation(mapNum, Skill(skillnum).CastAnim, 0, 0, TargetType.Pet, index)
            SendActionMsg(mapNum, "Conjurando " & Trim$(Skill(skillnum).Name) & "!", ColorType.BrightRed, ActionMsgType.Scroll, GetPetX(index) * 32, GetPetY(index) * 32)
            TempPlayer(index).PetskillBuffer.Skill = skillSlot
            TempPlayer(index).PetskillBuffer.Timer = GetTimeMs()
            TempPlayer(index).PetskillBuffer.Target = target
            TempPlayer(index).PetskillBuffer.TargetTypes = targetTypes
            Exit Sub
        Else
            SendClearPetSpellBuffer(index)
        End If

    End Sub

    Friend Sub PetCastSkill(index As Integer, skillslot As Integer, target As Integer, targetTypes As Byte, Optional takeMana As Boolean = True)
        Dim skillnum As Integer, mpCost As Integer, levelReq As Integer
        Dim mapNum As Integer, vital As Integer, didCast As Boolean
        Dim accessReq As Integer, i As Integer
        Dim aoE As Integer, range As Integer, vitalType As Byte
        Dim increment As Boolean, x As Integer, y As Integer
        Dim skillCastType As Integer

        didCast = False

        ' Prevenir subscript out of range
        If skillslot <= 0 OrElse skillslot > 4 Then Exit Sub

        skillnum = Player(index).Character(TempPlayer(index).CurChar).Pet.Skill(skillslot)
        mapNum = GetPlayerMap(index)

        mpCost = Skill(skillnum).MpCost

        ' Ver se tem MP suficiente
        If Player(index).Character(TempPlayer(index).CurChar).Pet.Mana < mpCost Then
            PlayerMsg(index, "Seu " & Trim$(GetPetName(index)) & " não tem mana o suficiente!", ColorType.BrightRed)
            Exit Sub
        End If

        levelReq = Skill(skillnum).LevelReq

        ' Requisitos de nível
        If levelReq > Player(index).Character(TempPlayer(index).CurChar).Pet.Level Then
            PlayerMsg(index, Trim$(GetPetName(index)) & " deve ter o nível " & levelReq & " para usar essa magia.", ColorType.BrightRed)
            Exit Sub
        End If

        accessReq = Skill(skillnum).AccessReq

        ' ter certeza que tem acesso correto
        If accessReq > GetPlayerAccess(index) Then
            PlayerMsg(index, "Você deve ser um administrador para que seu pet possa usar essa magia.", ColorType.BrightRed)
            Exit Sub
        End If

        ' Descobrir que tipo de magia é! Em si, alvo ou área de efeito
        If Skill(skillnum).IsProjectile = True Then
            skillCastType = 4 ' Projetil
        ElseIf Skill(skillnum).Range > 0 Then
            ' Ataque a distnacia, alvo simples or área de efeito?
            If Not Skill(skillnum).IsAoE Then
                skillCastType = 2 ' alvo
            Else
                skillCastType = 3 ' alvo de área
            End If
        Else
            If Not Skill(skillnum).IsAoE Then
                skillCastType = 0 ' si
            Else
                skillCastType = 1 ' área de efeito em si
            End If
        End If

        ' setar os vitais
        vital = Skill(skillnum).Vital
        aoE = Skill(skillnum).AoE
        range = Skill(skillnum).Range

        Select Case skillCastType
            Case 0 ' alvo em si próprio
                Select Case Skill(skillnum).Type
                    Case SkillType.HealHp
                        SkillPet_Effect(modEnumerators.VitalType.HP, True, index, vital, skillnum)
                        didCast = True
                    Case SkillType.HealMp
                        SkillPet_Effect(modEnumerators.VitalType.MP, True, index, vital, skillnum)
                        didCast = True
                End Select

            Case 1, 3 ' área de efeito em si & alvo de AOE

                If skillCastType = 1 Then
                    x = GetPetX(index)
                    y = GetPetY(index)
                ElseIf skillCastType = 3 Then

                    If targetTypes = 0 Then Exit Sub
                    If target = 0 Then Exit Sub

                    If targetTypes = TargetType.Player Then
                        x = GetPlayerX(target)
                        y = GetPlayerY(target)
                    ElseIf targetTypes = TargetType.Npc Then
                        x = MapNpc(mapNum).Npc(target).X
                        y = MapNpc(mapNum).Npc(target).Y
                    ElseIf targetTypes = TargetType.Pet Then
                        x = GetPetX(target)
                        y = GetPetY(target)
                    End If

                    If Not IsInRange(range, GetPetX(index), GetPetY(index), x, y) Then
                        PlayerMsg(index, "O alvo de " & Trim$(GetPetName(index)) & " não está ao alcance.", ColorType.Yellow)
                        SendClearPetSpellBuffer(index)
                    End If
                End If

                Select Case Skill(skillnum).Type

                    Case SkillType.DamageHp
                        didCast = True

                        For i = 1 To GetPlayersOnline()
                            If IsPlaying(i) AndAlso i <> index Then
                                If GetPlayerMap(i) = GetPlayerMap(index) Then
                                    If IsInRange(aoE, x, y, GetPlayerX(i), GetPlayerY(i)) Then
                                        If CanPetAttackPlayer(index, i, True) AndAlso index <> target Then
                                            SendAnimation(mapNum, Skill(skillnum).SkillAnim, 0, 0, TargetType.Player, i)
                                            PetAttackPlayer(index, i, vital, skillnum)
                                        End If
                                    End If

                                    If PetAlive(i) Then
                                        If IsInRange(aoE, x, y, GetPetX(i), GetPetY(i)) Then

                                            If CanPetAttackPet(index, i, skillnum) Then
                                                SendAnimation(mapNum, Skill(skillnum).SkillAnim, 0, 0, TargetType.Pet, i)
                                                PetAttackPet(index, i, vital, skillnum)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next

                        For i = 1 To MAX_MAP_NPCS
                            If MapNpc(mapNum).Npc(i).Num > 0 AndAlso MapNpc(mapNum).Npc(i).Vital(modEnumerators.VitalType.HP) > 0 Then
                                If IsInRange(aoE, x, y, MapNpc(mapNum).Npc(i).X, MapNpc(mapNum).Npc(i).Y) Then
                                    If CanPetAttackNpc(index, i, True) Then
                                        SendAnimation(mapNum, Skill(skillnum).SkillAnim, 0, 0, TargetType.Npc, i)
                                        PetAttackNpc(index, i, vital, skillnum)
                                    End If
                                End If
                            End If
                        Next

                    Case SkillType.HealHp, SkillType.HealMp, SkillType.DamageMp

                        If Skill(skillnum).Type = SkillType.HealHp Then
                            vitalType = modEnumerators.VitalType.HP
                            increment = True
                        ElseIf Skill(skillnum).Type = SkillType.HealMp Then
                            vitalType = modEnumerators.VitalType.MP
                            increment = True
                        ElseIf Skill(skillnum).Type = SkillType.DamageMp Then
                            vitalType = modEnumerators.VitalType.MP
                            increment = False
                        End If

                        didCast = True

                        For i = 1 To GetPlayersOnline()
                            If IsPlaying(i) AndAlso GetPlayerMap(i) = GetPlayerMap(index) Then
                                If IsInRange(aoE, x, y, GetPlayerX(i), GetPlayerY(i)) Then
                                    SpellPlayer_Effect(vitalType, increment, i, vital, skillnum)
                                End If

                                If PetAlive(i) Then
                                    If IsInRange(aoE, x, y, GetPetX(i), GetPetY(i)) Then
                                        SkillPet_Effect(vitalType, increment, i, vital, skillnum)
                                    End If
                                End If
                            End If
                        Next
                End Select

            Case 2 ' alvo

                If targetTypes = 0 Then Exit Sub
                If target = 0 Then Exit Sub

                If targetTypes = TargetType.Player Then
                    x = GetPlayerX(target)
                    y = GetPlayerY(target)
                ElseIf targetTypes = TargetType.Npc Then
                    x = MapNpc(mapNum).Npc(target).X
                    y = MapNpc(mapNum).Npc(target).Y
                ElseIf targetTypes = TargetType.Pet Then
                    x = GetPetX(target)
                    y = GetPetY(target)
                End If

                If Not IsInRange(range, GetPetX(index), GetPetY(index), x, y) Then
                    PlayerMsg(index, "O alvo não está ao alcance de seu " & Trim$(GetPetName(index)) & "!", ColorType.Yellow)
                    SendClearPetSpellBuffer(index)
                    Exit Sub
                End If

                Select Case Skill(skillnum).Type

                    Case SkillType.DamageHp

                        If targetTypes = TargetType.Player Then
                            If CanPetAttackPlayer(index, target, True) AndAlso index <> target Then
                                If vital > 0 Then
                                    SendAnimation(mapNum, Skill(skillnum).SkillAnim, 0, 0, TargetType.Player, target)
                                    PetAttackPlayer(index, target, vital, skillnum)
                                    didCast = True
                                End If
                            End If
                        ElseIf targetTypes = TargetType.Npc Then
                            If CanPetAttackNpc(index, target, True) Then
                                If vital > 0 Then
                                    SendAnimation(mapNum, Skill(skillnum).SkillAnim, 0, 0, TargetType.Npc, target)
                                    PetAttackNpc(index, target, vital, skillnum)
                                    didCast = True
                                End If
                            End If
                        ElseIf targetTypes = TargetType.Pet Then
                            If CanPetAttackPet(index, target, skillnum) Then
                                If vital > 0 Then
                                    SendAnimation(mapNum, Skill(skillnum).SkillAnim, 0, 0, TargetType.Pet, target)
                                    PetAttackPet(index, target, vital, skillnum)
                                    didCast = True
                                End If
                            End If
                        End If

                    Case SkillType.DamageMp, SkillType.HealMp, SkillType.HealHp

                        If Skill(skillnum).Type = SkillType.DamageMp Then
                            vitalType = modEnumerators.VitalType.MP
                            increment = False
                        ElseIf Skill(skillnum).Type = SkillType.HealMp Then
                            vitalType = modEnumerators.VitalType.MP
                            increment = True
                        ElseIf Skill(skillnum).Type = SkillType.HealHp Then
                            vitalType = modEnumerators.VitalType.HP
                            increment = True
                        End If

                        If targetTypes = TargetType.Player Then
                            If Skill(skillnum).Type = SkillType.DamageMp Then
                                If CanPetAttackPlayer(index, target, True) Then
                                    SpellPlayer_Effect(vitalType, increment, target, vital, skillnum)
                                End If
                            Else
                                SpellPlayer_Effect(vitalType, increment, target, vital, skillnum)
                            End If

                        ElseIf targetTypes = TargetType.Npc Then

                            If Skill(skillnum).Type = SkillType.DamageMp Then
                                If CanPetAttackNpc(index, target, True) Then
                                    SpellNpc_Effect(vitalType, increment, target, vital, skillnum, mapNum)
                                End If
                            Else
                                If Skill(skillnum).Type = SkillType.HealHp OrElse Skill(skillnum).Type = SkillType.HealMp Then
                                    SkillPet_Effect(vitalType, increment, index, vital, skillnum)
                                Else
                                    SpellNpc_Effect(vitalType, increment, target, vital, skillnum, mapNum)
                                End If
                            End If

                        ElseIf targetTypes = TargetType.Pet Then

                            If Skill(skillnum).Type = SkillType.DamageMp Then
                                If CanPetAttackPet(index, target, skillnum) Then
                                    SkillPet_Effect(vitalType, increment, target, vital, skillnum)
                                End If
                            Else
                                SkillPet_Effect(vitalType, increment, target, vital, skillnum)
                                SendPetVital(target, vital)
                            End If
                        End If
                End Select

            Case 4 ' Projetil
                PetFireProjectile(index, skillnum)
                didCast = True
        End Select

        If didCast Then
            If takeMana Then SetPetVital(index, modEnumerators.VitalType.MP, GetPetVital(index, modEnumerators.VitalType.MP) - mpCost)
            SendPetVital(index, modEnumerators.VitalType.MP)
            SendPetVital(index, modEnumerators.VitalType.HP)

            TempPlayer(index).PetSkillCd(skillslot) = GetTimeMs() + (Skill(skillnum).CdTime * 1000)

            SendActionMsg(mapNum, Trim$(Skill(skillnum).Name) & "!", ColorType.BrightRed, ActionMsgType.Scroll, GetPetX(index) * 32, GetPetY(index) * 32)
        End If

    End Sub

    Friend Sub SkillPet_Effect(vital As Byte, increment As Boolean, index As Integer, damage As Integer, skillnum As Integer)
        Dim sSymbol As String
        Dim colour As Integer

        If damage > 0 Then
            If increment Then
                sSymbol = "+"
                If vital = VitalType.HP Then colour = ColorType.BrightGreen
                If vital = VitalType.MP Then colour = ColorType.BrightBlue
            Else
                sSymbol = "-"
                colour = ColorType.Blue
            End If

            SendAnimation(GetPlayerMap(index), Skill(skillnum).SkillAnim, 0, 0, TargetType.Pet, index)
            SendActionMsg(GetPlayerMap(index), sSymbol & damage, colour, ActionMsgType.Scroll, GetPetX(index) * 32, GetPetY(index) * 32)

            ' enviar som
            'SendMapSound(Index, Player(Index).Character(TempPlayer(Index).CurChar).Pet.x, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y, SoundEntity.seSpell, Skillnum)

            If increment Then
                SetPetVital(index, VitalType.HP, GetPetVital(index, VitalType.HP) + damage)

                If Skill(skillnum).Duration > 0 Then
                    AddHoT_Pet(index, skillnum)
                End If

            ElseIf Not increment Then
                If vital = VitalType.HP Then
                    SetPetVital(index, VitalType.HP, GetPetVital(index, VitalType.HP) - damage)
                ElseIf vital = VitalType.MP Then
                    SetPetVital(index, VitalType.MP, GetPetVital(index, VitalType.MP) - damage)
                End If
            End If
        End If

        If GetPetVital(index, VitalType.HP) > GetPetMaxVital(index, VitalType.HP) Then SetPetVital(index, VitalType.HP, GetPetMaxVital(index, VitalType.HP))

        If GetPetVital(index, VitalType.MP) > GetPetMaxVital(index, VitalType.MP) Then SetPetVital(index, VitalType.MP, GetPetMaxVital(index, VitalType.MP))

    End Sub

    Friend Sub AddHoT_Pet(index As Integer, skillnum As Integer)
        Dim i As Integer

        For i = 1 To MAX_COTS
            With TempPlayer(index).PetHoT(i)

                If .Skill = skillnum Then
                    .Timer = GetTimeMs()
                    .StartTime = GetTimeMs()
                    Exit Sub
                End If

                If .Used = False Then
                    .Skill = skillnum
                    .Timer = GetTimeMs()
                    .Used = True
                    .StartTime = GetTimeMs()
                    Exit Sub
                End If
            End With
        Next

    End Sub

    Friend Sub AddDoT_Pet(index As Integer, skillnum As Integer, caster As Integer, attackerType As Integer)
        Dim i As Integer

        If Not PetAlive(index) Then Exit Sub

        For i = 1 To MAX_COTS
            With TempPlayer(index).PetDoT(i)
                If .Skill = skillnum Then
                    .Timer = GetTimeMs()
                    .Caster = caster
                    .StartTime = GetTimeMs()
                    .AttackerType = attackerType
                    Exit Sub
                End If

                If .Used = False Then
                    .Skill = skillnum
                    .Timer = GetTimeMs()
                    .Caster = caster
                    .Used = True
                    .StartTime = GetTimeMs()
                    .AttackerType = attackerType
                    Exit Sub
                End If
            End With
        Next

    End Sub

    Friend Sub StunPet(index As Integer, skillnum As Integer)
        ' Ver se é magia estuporante

        If PetAlive(index) Then
            If Skill(skillnum).StunDuration > 0 Then
                ' Setar valors no índice
                TempPlayer(index).PetStunDuration = Skill(skillnum).StunDuration
                TempPlayer(index).PetStunTimer = GetTimeMs()
                ' Avisar que ele está estuporado
                PlayerMsg(index, "Seu " & Trim$(GetPetName(index)) & " foi estuporado.", ColorType.Yellow)
            End If
        End If

    End Sub

    Friend Sub HandleDoT_Pet(index As Integer, dotNum As Integer)

        With TempPlayer(index).PetDoT(dotNum)

            If .Used AndAlso .Skill > 0 Then
                ' hora de ticar?
                If GetTimeMs() > .Timer + (Skill(.Skill).Interval * 1000) Then
                    If .AttackerType = TargetType.Pet Then
                        If CanPetAttackPet(.Caster, index, .Skill) Then
                            PetAttackPet(.Caster, index, Skill(.Skill).Vital)
                            SendPetVital(index, VitalType.HP)
                            SendPetVital(index, VitalType.MP)
                        End If
                    ElseIf .AttackerType = TargetType.Player Then
                        If CanPlayerAttackPet(.Caster, index, .Skill) Then
                            PlayerAttackPet(.Caster, index, Skill(.Skill).Vital)
                            SendPetVital(index, VitalType.HP)
                            SendPetVital(index, VitalType.MP)
                        End If
                    End If

                    .Timer = GetTimeMs()

                    ' ver se o DoT ainda está ativo - se o jogador morrer, ele será retirado
                    If .Used AndAlso .Skill > 0 Then
                        ' destruir dot se encerrado
                        If GetTimeMs() - .StartTime >= (Skill(.Skill).Duration * 1000) Then
                            .Used = False
                            .Skill = 0
                            .Timer = 0
                            .Caster = 0
                            .StartTime = 0
                        End If
                    End If
                End If
            End If
        End With

    End Sub

    Friend Sub HandleHoT_Pet(index As Integer, hotNum As Integer)

        With TempPlayer(index).PetHoT(hotNum)

            If .Used AndAlso .Skill > 0 Then
                ' hora de ticar?
                If GetTimeMs() > .Timer + (Skill(.Skill).Interval * 1000) Then
                    SendActionMsg(GetPlayerMap(index), "+" & Skill(.Skill).Vital, ColorType.BrightGreen, ActionMsgType.Scroll, Player(index).Character(TempPlayer(index).CurChar).Pet.X * 32, Player(index).Character(TempPlayer(index).CurChar).Pet.Y * 32,)
                    SetPetVital(index, VitalType.HP, GetPetVital(index, VitalType.HP) + Skill(.Skill).Vital)

                    If GetPetVital(index, VitalType.HP) > GetPetMaxVital(index, VitalType.HP) Then SetPetVital(index, VitalType.HP, GetPetMaxVital(index, VitalType.HP))

                    If GetPetVital(index, VitalType.MP) > GetPetMaxVital(index, VitalType.MP) Then SetPetVital(index, VitalType.MP, GetPetMaxVital(index, VitalType.MP))

                    SendPetVital(index, VitalType.HP)
                    SendPetVital(index, VitalType.MP)
                    .Timer = GetTimeMs()

                    ' ver se o DoT ainda está ativo - se jogador morreu, será retirado
                    If .Used AndAlso .Skill > 0 Then
                        ' destruir hoT se terminado
                        If GetTimeMs() - .StartTime >= (Skill(.Skill).Duration * 1000) Then
                            .Used = False
                            .Skill = 0
                            .Timer = 0
                            .Caster = 0
                            .StartTime = 0
                        End If
                    End If
                End If
            End If
        End With

    End Sub

    Friend Function CanPetDodge(index As Integer) As Boolean
        Dim rate As Integer, rndNum As Integer

        If Not PetAlive(index) Then Exit Function

        CanPetDodge = False

        rate = GetPetStat(index, StatType.Luck) / 4
        rndNum = Random(1, 100)

        If rndNum <= rate Then
            CanPetDodge = True
        End If

    End Function

    Friend Function CanPetParry(index As Integer) As Boolean
        Dim rate As Integer, rndNum As Integer

        If Not PetAlive(index) Then Exit Function

        CanPetParry = False

        rate = GetPetStat(index, StatType.Luck) / 6
        rndNum = Random(1, 100)

        If rndNum <= rate Then
            CanPetParry = True
        End If

    End Function

#End Region

#Region "Player > Pet"

    Function CanPlayerAttackPet(attacker As Integer, victim As Integer, Optional isSkill As Boolean = False) As Boolean

        If isSkill = False Then
            ' Checar temporizador de ataque
            If GetPlayerEquipment(attacker, EquipmentType.Weapon) > 0 Then
                If GetTimeMs() < TempPlayer(attacker).AttackTimer + Item(GetPlayerEquipment(attacker, EquipmentType.Weapon)).Speed Then Exit Function
            Else
                If GetTimeMs() < TempPlayer(attacker).AttackTimer + 1000 Then Exit Function
            End If
        End If

        ' Verificar por subscript out of range
        If Not IsPlaying(victim) Then Exit Function

        If Not PetAlive(victim) Then Exit Function

        ' Ter certeza que estão no mesmo mapa
        If Not GetPlayerMap(attacker) = GetPlayerMap(victim) Then Exit Function

        ' Ter certeza que não estamos atacando jogadores que estão trocando de mapa
        If TempPlayer(victim).GettingMap = 1 Then Exit Function

        If isSkill = False Then

            ' Verificar se estamos nas mesmas coordenadas
            Select Case GetPlayerDir(attacker)

                Case DirectionType.Up
                    If Not ((GetPetY(victim) + 1 = GetPlayerY(attacker)) AndAlso (GetPetX(victim) = GetPlayerX(attacker))) Then Exit Function

                Case DirectionType.Down
                    If Not ((GetPetY(victim) - 1 = GetPlayerY(attacker)) AndAlso (GetPetX(victim) = GetPlayerX(attacker))) Then Exit Function

                Case DirectionType.Left
                    If Not ((GetPetY(victim) = GetPlayerY(attacker)) AndAlso (GetPetX(victim) + 1 = GetPlayerX(attacker))) Then Exit Function

                Case DirectionType.Right
                    If Not ((GetPetY(victim) = GetPlayerY(attacker)) AndAlso (GetPetX(victim) - 1 = GetPlayerX(attacker))) Then Exit Function

                Case Else
                    Exit Function
            End Select
        End If

        ' Ver se o mapa é atacável
        If Not Map(GetPlayerMap(attacker)).Moral = MapMoralType.None Then
            If GetPlayerPK(victim) = 0 Then
                PlayerMsg(attacker, "Esta é uma zona segura!", ColorType.Yellow)
                Exit Function
            End If
        End If

        ' Ter certeza que tem mais de 0 de hp
        If GetPetVital(victim, VitalType.HP) <= 0 Then Exit Function

        ' Verificar se eles não tem acessoCheck to make sure that they dont have access
        If GetPlayerAccess(attacker) > AdminType.Monitor Then
            PlayerMsg(attacker, "Administradores não podem atacar outros jogadores.", ColorType.BrightRed)
            Exit Function
        End If

        ' Ter certeza que a vítima não é um administrador
        If GetPlayerAccess(victim) > AdminType.Monitor Then
            PlayerMsg(attacker, "Você não pode atacar o " & Trim$(GetPetName(victim)) & " de " & GetPlayerName(victim) & "!", ColorType.BrightRed)
            Exit Function
        End If

        ' Não atacar membro da equipe
        If TempPlayer(attacker).InParty > 0 AndAlso TempPlayer(victim).InParty > 0 Then
            If TempPlayer(attacker).InParty = TempPlayer(victim).InParty Then
                PlayerMsg(attacker, "Você não pode atacar outro membro da equipe!", ColorType.BrightRed)
                Exit Function
            End If
        End If

        If TempPlayer(attacker).InParty > 0 AndAlso TempPlayer(victim).InParty > 0 AndAlso TempPlayer(attacker).InParty = TempPlayer(victim).InParty Then
            If isSkill > 0 Then
                If Skill(isSkill).Type = SkillType.HealMp OrElse Skill(isSkill).Type = SkillType.HealHp Then
                    'Levar adiante :D
                Else
                    Exit Function
                End If
            Else
                Exit Function
            End If
        End If

        CanPlayerAttackPet = True

    End Function

    Sub PlayerAttackPet(attacker As Integer, victim As Integer, damage As Integer, Optional skillnum As Integer = 0)
        Dim exp As Integer, n As Integer, i As Integer

        ' Verificar por subscript out of range

        If IsPlaying(attacker) = False OrElse IsPlaying(victim) = False OrElse damage < 0 OrElse Not PetAlive(victim) Then Exit Sub

        If GetPlayerEquipment(attacker, EquipmentType.Weapon) > 0 Then
            n = GetPlayerEquipment(attacker, EquipmentType.Weapon)
        End If

        ' Setar o temporizador de regeneração
        TempPlayer(attacker).StopRegen = True
        TempPlayer(attacker).StopRegenTimer = GetTimeMs()

        If damage >= GetPetVital(victim, VitalType.HP) Then
            SendActionMsg(GetPlayerMap(victim), "-" & GetPetVital(victim, VitalType.HP), ColorType.BrightRed, 1, (GetPetX(victim) * 32), (GetPetY(victim) * 32))

            ' Enviar o som
            'If Spellnum > 0 Then SendMapSound Victim, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.x, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.y, SoundEntity.seSpell, Spellnum

            ' Calcular experiencia para dar ao atacante
            exp = (GetPlayerExp(victim) \ 10)

            ' Ter certeza que nao pegamos menos que zero
            If exp < 0 Then exp = 0

            If exp = 0 Then
                PlayerMsg(victim, "Você não perdeu experiência.", ColorType.BrightGreen)
                PlayerMsg(attacker, "Você não recebeu experiência.", ColorType.Yellow)
            Else
                SetPlayerExp(victim, GetPlayerExp(victim) - exp)
                SendExp(victim)
                PlayerMsg(victim, "Você perdeu " & exp & " de experiência.", ColorType.BrightRed)

                ' Ver se estamos em equipe
                If TempPlayer(attacker).InParty > 0 Then
                    ' Passar pela funcão de compartilhamento
                    Party_ShareExp(TempPlayer(attacker).InParty, exp, attacker, GetPlayerMap(attacker))
                Else
                    ' Não está em grupo, compartilhar consigo mesmo
                    GivePlayerExp(attacker, exp)
                End If
            End If

            ' purge target info of anyone who targetted dead guy
            For i = 1 To GetPlayersOnline()
                If IsPlaying(i) AndAlso Socket.IsConnected(i) AndAlso GetPlayerMap(i) = GetPlayerMap(attacker) Then
                    If TempPlayer(i).Target = TargetType.Pet AndAlso TempPlayer(i).Target = victim Then
                        TempPlayer(i).Target = 0
                        TempPlayer(i).TargetType = TargetType.None
                        SendTarget(i, 0, TargetType.None)
                    End If
                End If
            Next

            PlayerMsg(victim, ("Your " & GetPetName(victim).Trim & " was killed by  " & GetPlayerName(attacker).Trim & "."), ColorType.BrightRed)
            ReCallPet(victim)
        Else
            ' Pet not dead, just do the damage
            SetPetVital(victim, VitalType.HP, GetPetVital(victim, VitalType.HP) - damage)
            SendPetVital(victim, VitalType.HP)

            'Set pet to begin attacking the other pet if it isn't dead or dosent have another target
            If TempPlayer(victim).PetTarget <= 0 AndAlso TempPlayer(victim).PetBehavior <> PetBehaviourGoto Then
                TempPlayer(victim).PetTarget = attacker
                TempPlayer(victim).PetTargetType = TargetType.Player
            End If

            ' send the sound
            'If Spellnum > 0 Then SendMapSound Victim, GetPetX(Victim), GetPety(Victim), SoundEntity.seSpell, Spellnum

            SendActionMsg(GetPlayerMap(victim), "-" & damage, ColorType.BrightRed, 1, (GetPetX(victim) * 32), (GetPetY(victim) * 32))
            SendBlood(GetPlayerMap(victim), GetPetX(victim), GetPetY(victim))

            ' set the regen timer
            TempPlayer(victim).PetstopRegen = True
            TempPlayer(victim).PetstopRegenTimer = GetTimeMs()

            'if a stunning spell, stun the player
            If skillnum > 0 Then
                If Skill(skillnum).StunDuration > 0 Then StunPet(victim, skillnum)

                ' DoT
                If Skill(skillnum).Duration > 0 Then
                    AddDoT_Pet(victim, skillnum, attacker, TargetType.Player)
                End If
            End If
        End If

        ' Reset attack timer
        TempPlayer(attacker).AttackTimer = GetTimeMs()

    End Sub

    Friend Sub TryPlayerAttackPet(attacker As Integer, victim As Integer)
        Dim blockAmount As Integer, mapNum As Integer
        If Not PetAlive(victim) Then Exit Sub

        ' Podemos atacar o NPC?
        If CanPlayerAttackPet(attacker, victim) Then

            mapNum = GetPlayerMap(attacker)

            TempPlayer(attacker).Target = victim
            TempPlayer(attacker).TargetType = TargetType.Pet

            ' Ver se o NPC pode desviar do ataque
            If CanPetDodge(victim) Then
                SendActionMsg(mapNum, "Desvio!", ColorType.Pink, 1, (GetPlayerX(victim) * 32), (GetPlayerY(victim) * 32))
                Exit Sub
            End If

            If CanPetParry(victim) Then
                SendActionMsg(mapNum, "Bloqueio!", ColorType.Pink, 1, (GetPlayerX(victim) * 32), (GetPlayerY(victim) * 32))
                Exit Sub
            End If

            ' Pegar o dano que podemos fazer
            Dim damage As Integer = GetPlayerDamage(attacker)

            ' Se o NPC bloquear, retirar o dano de bloqueio
            blockAmount = 0
            damage -= blockAmount

            ' Subtrair armadura
            damage -= Random(1, (GetPlayerStat(victim, StatType.Luck) * 2))

            ' Aleatorizar até 10% o dano máximo
            damage = Random(1, damage)

            ' * 1.5 se crítico
            If CanPlayerCriticalHit(attacker) Then
                damage *= 1.5
                SendActionMsg(mapNum, "Crítico!", ColorType.BrightCyan, 1, (GetPlayerX(attacker) * 32), (GetPlayerY(attacker) * 32))
            End If

            If damage > 0 Then
                PlayerAttackPet(attacker, victim, damage)
            Else
                PlayerMsg(attacker, "Seu ataque não fez nada.", ColorType.BrightRed)
            End If
        End If

    End Sub

#End Region

#Region "Data Functions"

    Friend Function PetAlive(index As Integer) As Boolean
        PetAlive = False

        If Player(index).Character(TempPlayer(index).CurChar).Pet.Alive = 1 Then
            PetAlive = True
        End If

    End Function

    Friend Function GetPetName(index As Integer) As String
        GetPetName = ""

        If PetAlive(index) Then
            GetPetName = Pet(Player(index).Character(TempPlayer(index).CurChar).Pet.Num).Name.Trim
        End If

    End Function

    Friend Function GetPetNum(index As Integer) As Integer
        GetPetNum = Player(index).Character(TempPlayer(index).CurChar).Pet.Num

    End Function

    Friend Function GetPetRange(index As Integer) As Integer
        GetPetRange = 0

        If PetAlive(index) Then
            GetPetRange = Pet(Player(index).Character(TempPlayer(index).CurChar).Pet.Num).Range
        End If

    End Function

    Friend Function GetPetLevel(index As Integer) As Integer
        GetPetLevel = 0

        If PetAlive(index) Then
            GetPetLevel = Player(index).Character(TempPlayer(index).CurChar).Pet.Level
        End If

    End Function

    Friend Sub SetPetLevel(index As Integer, newlvl As Integer)
        If PetAlive(index) Then
            Player(index).Character(TempPlayer(index).CurChar).Pet.Level = newlvl
        End If
    End Sub

    Friend Function GetPetX(index As Integer) As Integer
        GetPetX = 0

        If PetAlive(index) Then
            GetPetX = Player(index).Character(TempPlayer(index).CurChar).Pet.X
        End If

    End Function

    Friend Sub SetPetX(index As Integer, x As Integer)
        If PetAlive(index) Then
            Player(index).Character(TempPlayer(index).CurChar).Pet.X = x
        End If
    End Sub

    Friend Function GetPetY(index As Integer) As Integer
        GetPetY = 0

        If PetAlive(index) Then
            GetPetY = Player(index).Character(TempPlayer(index).CurChar).Pet.Y
        End If

    End Function

    Friend Sub SetPetY(index As Integer, y As Integer)
        If PetAlive(index) Then
            Player(index).Character(TempPlayer(index).CurChar).Pet.Y = y
        End If
    End Sub

    Friend Function GetPetDir(index As Integer) As Integer
        GetPetDir = 0

        If PetAlive(index) Then
            GetPetDir = Player(index).Character(TempPlayer(index).CurChar).Pet.Dir
        End If

    End Function

    Friend Function GetPetBehaviour(index As Integer) As Integer
        GetPetBehaviour = 0

        If PetAlive(index) Then
            GetPetBehaviour = Player(index).Character(TempPlayer(index).CurChar).Pet.AttackBehaviour
        End If

    End Function

    Friend Sub SetPetBehaviour(index As Integer, behaviour As Byte)
        If PetAlive(index) Then
            Player(index).Character(TempPlayer(index).CurChar).Pet.AttackBehaviour = behaviour
        End If
    End Sub

    Friend Function GetPetStat(index As Integer, stat As StatType) As Integer
        GetPetStat = 0

        If PetAlive(index) Then
            GetPetStat = Player(index).Character(TempPlayer(index).CurChar).Pet.Stat(stat)
        End If

    End Function

    Friend Sub SetPetStat(index As Integer, stat As StatType, amount As Integer)

        If PetAlive(index) Then
            Player(index).Character(TempPlayer(index).CurChar).Pet.Stat(stat) = amount
        End If

    End Sub

    Friend Function GetPetPoints(index As Integer) As Integer
        GetPetPoints = 0

        If PetAlive(index) Then
            GetPetPoints = Player(index).Character(TempPlayer(index).CurChar).Pet.Points
        End If

    End Function

    Friend Sub SetPetPoints(index As Integer, amount As Integer)

        If PetAlive(index) Then
            Player(index).Character(TempPlayer(index).CurChar).Pet.Points = amount
        End If

    End Sub

    Friend Function GetPetExp(index As Integer) As Integer
        GetPetExp = 0

        If PetAlive(index) Then
            GetPetExp = Player(index).Character(TempPlayer(index).CurChar).Pet.Exp
        End If

    End Function

    Friend Sub SetPetExp(index As Integer, amount As Integer)
        If PetAlive(index) Then
            Player(index).Character(TempPlayer(index).CurChar).Pet.Exp = amount
        End If
    End Sub

    Function GetPetVital(index As Integer, vital As VitalType) As Integer

        If index > MAX_PLAYERS Then Exit Function

        Select Case vital
            Case VitalType.HP
                GetPetVital = Player(index).Character(TempPlayer(index).CurChar).Pet.Health

            Case VitalType.MP
                GetPetVital = Player(index).Character(TempPlayer(index).CurChar).Pet.Mana
        End Select

    End Function

    Sub SetPetVital(index As Integer, vital As VitalType, amount As Integer)

        If index > MAX_PLAYERS Then Exit Sub

        Select Case vital
            Case VitalType.HP
                Player(index).Character(TempPlayer(index).CurChar).Pet.Health = amount

            Case VitalType.MP
                Player(index).Character(TempPlayer(index).CurChar).Pet.Mana = amount
        End Select

    End Sub

    Function GetPetMaxVital(index As Integer, vital As VitalType) As Integer

        If index > MAX_PLAYERS Then Exit Function

        Select Case vital
            Case VitalType.HP
                GetPetMaxVital = ((Player(index).Character(TempPlayer(index).CurChar).Pet.Level * 4) + (Player(index).Character(TempPlayer(index).CurChar).Pet.Stat(StatType.Endurance) * 10)) + 150

            Case VitalType.MP
                GetPetMaxVital = ((Player(index).Character(TempPlayer(index).CurChar).Pet.Level * 4) + (Player(index).Character(TempPlayer(index).CurChar).Pet.Stat(StatType.Spirit) / 2)) * 5 + 50
        End Select

    End Function

    Function GetPetNextLevel(index As Integer) As Integer

        If PetAlive(index) Then
            If Player(index).Character(TempPlayer(index).CurChar).Pet.Level = Pet(Player(index).Character(TempPlayer(index).CurChar).Pet.Num).MaxLevel Then GetPetNextLevel = 0 : Exit Function
            GetPetNextLevel = (50 / 3) * ((Player(index).Character(TempPlayer(index).CurChar).Pet.Level + 1) ^ 3 - (6 * (Player(index).Character(TempPlayer(index).CurChar).Pet.Level + 1) ^ 2) + 17 * (Player(index).Character(TempPlayer(index).CurChar).Pet.Level + 1) - 12)
        End If

    End Function

#End Region

End Module