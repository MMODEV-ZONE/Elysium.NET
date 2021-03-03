Imports System.Linq
Imports System.Threading

Module modLoop

    Sub ServerLoop()
        Dim tick As Integer
        Dim tmr25 As Integer, tmr300 As Integer
        Dim tmr500 As Integer, tmr1000 As Integer
        Dim lastUpdateSavePlayers As Integer
        Dim lastUpdateMapSpawnItems As Integer
        Dim lastUpdatePlayerVitals As Integer

        Do
            ' Atualizar o valor atual de tick.
            tick = GetTimeMs()

            ' Não processar nada se estiver desligando
            If ServerDestroyed Then End

            ' Pegar todos os jogadores online.
            Dim onlinePlayers = TempPlayer.Where(Function(player) player.InGame).Select(Function(player, index) New With {Key .Index = index + 1, player}).ToArray()

            If tick > tmr25 Then
                ' Verificar se algum jogador terminou de usar uma habilidade e faze-la andar se tiver.
                Dim playerskills = (
                    From p In onlinePlayers
                    Where p.player.SkillBuffer > 0 AndAlso GetTimeMs() > (p.player.SkillBufferTimer + Skill(p.player.SkillBuffer).CastTime * 1000)
                    Select New With {p.Index, Key .Success = HandleCastSkill(p.Index)}
                ).ToArray()

                ' Ver se temos que limpar algum jogador sendo estuporado
                Dim playerstuns = (
                    From p In onlinePlayers
                    Where p.player.StunDuration > 0 AndAlso p.player.StunTimer + (p.player.StunDuration * 1000)
                    Select New With {p.Index, Key .Success = HandleClearStun(p.Index)}
                ).ToArray()

                ' Verificar se algum pet terminou de usar uma habilidade e faze-la andar se tiver.
                Dim petskills = (
                From p In onlinePlayers
                Where Player(p.Index).Character(p.player.CurChar).Pet.Alive = 1 AndAlso TempPlayer(p.Index).PetskillBuffer.Skill > 0 AndAlso GetTimeMs() > p.player.PetskillBuffer.Timer + (Skill(Player(p.Index).Character(p.player.CurChar).Pet.Skill(p.player.PetskillBuffer.Skill)).CastTime * 1000)
                Select New With {p.Index, Key .Success = HandlePetSkill(p.Index)}
                ).ToArray()

                ' Ver se temos que limpar algum pet sendo estuporado.
                Dim petstuns = (
                    From p In onlinePlayers
                    Where p.player.PetStunDuration > 0 AndAlso p.player.PetStunTimer + (p.player.PetStunDuration * 1000)
                    Select New With {p.Index, Key .Success = HandleClearPetStun(p.Index)}
                ).ToArray()

                ' Verificar o timer de regeneração do pet
                Dim petregen = (
                    From p In onlinePlayers
                    Where p.player.PetstopRegen = True AndAlso p.player.PetstopRegenTimer + 5000 < GetTimeMs()
                    Select New With {p.Index, Key .Success = HandleStopPetRegen(p.Index)}
                ).ToArray()

                ' Lógica de HoT e DoT
                'For x = 1 To MAX_COTS
                '    HandleDoT_Pet i, x
                '        HandleHoT_Pet i, x
                '    Next

                ' Atualizar todos nossos eventos disponíveis.
                UpdateEventLogic()

                ' Mover o temporizador em 25ms.
                tmr25 = GetTimeMs() + 25
            End If

            If tick > tmr1000 Then
                ' Lidar com o artesanato de jogador
                Dim playercrafts = (
                    From p In onlinePlayers
                    Where GetTimeMs() > p.player.CraftTimer + (p.player.CraftTimeNeeded * 1000) AndAlso p.player.CraftIt = 1
                    Select New With {p.Index, .Success = HandlePlayerCraft(p.Index)}
                ).ToArray()

                Time.Instance.Tick()

                ' Mover o temporizador em 1000ms.
                tmr1000 = GetTimeMs() + 1000
            End If

            If tick > tmr500 Then

                ' Lidar com temporizador das moradias dos jogadores.
                Dim playerhousing = (
                    From p In onlinePlayers
                    Where Player(p.Index).Character(p.player.CurChar).InHouse > 0 AndAlso
                          IsPlaying(Player(p.Index).Character(p.player.CurChar).InHouse) AndAlso
                          Player(Player(p.Index).Character(p.player.CurChar).InHouse).Character(p.player.CurChar).InHouse <> Player(p.Index).Character(p.player.CurChar).InHouse
                    Select New With {p.Index, Key .Success = HandlePlayerHouse(p.Index)}
                ).ToArray()

                ' Mover o temporizador em 500ms.
                tmr500 = GetTimeMs() + 500

            End If

            If GetTimeMs() > tmr300 Then
                UpdateNpcAi()
                UpdatePetAi()
                tmr300 = GetTimeMs() + 300
            End If

            ' Verificar para atualizar os vitais do jogador a cada 5 segundos - pode ser melhorado
            If tick > lastUpdatePlayerVitals Then
                UpdatePlayerVitals()
                lastUpdatePlayerVitals = GetTimeMs() + 5000
            End If

            ' Verificar para regerar os itens dos mapas a cada 5 minutos - pode ser mlhorado
            If tick > lastUpdateMapSpawnItems Then
                UpdateMapSpawnItems()
                lastUpdateMapSpawnItems = GetTimeMs() + 300000
            End If

            ' Verificar para salvar jogadores a cada 10 minutos - pode ser melhorado
            If tick > lastUpdateSavePlayers Then
                UpdateSavePlayers()
                lastUpdateSavePlayers = GetTimeMs() + 600000
            End If

            Application.DoEvents()
            'Thread.Yield()
            Thread.Sleep(1)
        Loop
    End Sub

    'Function GetTotalPlayersOnline() As Integer
    '    GetTotalPlayersOnline = TempPlayer.Where(Function(x) x.InGame).ToArray().Length
    'End Function

    Sub UpdateSavePlayers()
        Dim i As Integer

        If GetPlayersOnline() > 0 Then
            Console.WriteLine("Salvando todos os jogadores online...")
            GlobalMsg("Salvando todos os jogadores online...")

            For i = 1 To GetPlayersOnline()
                If IsPlaying(i) Then
                    SavePlayer(i)
                    SaveBank(i)
                End If
                Application.DoEvents()
            Next

        End If

    End Sub

    Private Sub UpdateMapSpawnItems()
        Dim x As Integer
        Dim y As Integer

        ' ////////////////////////////////////////////////
        ' // Isso é usado para regerar itens dos mapas //
        ' ///////////////////////////////////////////////
        For y = 1 To MAX_CACHED_MAPS

            ' Ter certeza que ninguém está no mapa quando regerar
            If Not PlayersOnMap(y) Then

                ' Limpar o lixo desnecessário
                For x = 1 To MAX_MAP_ITEMS
                    ClearMapItem(x, y)
                Next

                ' Gerar itens
                SpawnMapItems(y)
                SendMapItemsToAll(y)
            End If

        Next

    End Sub

    Private Sub UpdatePlayerVitals()
        Dim i As Integer

        For i = 1 To GetPlayersOnline()

            If IsPlaying(i) Then
                If GetPlayerVital(i, VitalType.HP) <> GetPlayerMaxVital(i, VitalType.HP) Then
                    SetPlayerVital(i, VitalType.HP, GetPlayerVital(i, VitalType.HP) + GetPlayerVitalRegen(i, VitalType.HP))
                    SendVital(i, VitalType.HP)
                End If

                If GetPlayerVital(i, VitalType.MP) <> GetPlayerMaxVital(i, VitalType.MP) Then
                    SetPlayerVital(i, VitalType.MP, GetPlayerVital(i, VitalType.MP) + GetPlayerVitalRegen(i, VitalType.MP))
                    SendVital(i, VitalType.MP)
                End If

                If GetPlayerVital(i, VitalType.SP) <> GetPlayerMaxVital(i, VitalType.SP) Then
                    SetPlayerVital(i, VitalType.SP, GetPlayerVital(i, VitalType.SP) + GetPlayerVitalRegen(i, VitalType.SP))
                    SendVital(i, VitalType.SP)
                End If
            End If
            ' Enviar vitais a equipe se em uma
            If TempPlayer(i).InParty > 0 Then SendPartyVitals(TempPlayer(i).InParty, i)
        Next

    End Sub

    Private Sub UpdateNpcAi()
        Dim i As Integer, x As Integer, n As Integer, x1 As Integer, y1 As Integer
        Dim mapNum As Integer, tickCount As Integer
        Dim damage As Integer
        Dim distanceX As Integer, distanceY As Integer
        Dim npcNum As Integer
        Dim target As Integer, targetTypes As Byte, targetX As Integer, targetY As Integer, targetVerify As Boolean
        Dim resourceIndex As Integer

        For mapNum = 1 To MAX_CACHED_MAPS

            If ServerDestroyed Then Exit Sub

            ' Itens aparecendo para todos
            For i = 1 To MAX_MAP_ITEMS
                If MapItem(mapNum, i).Num > 0 Then
                    If MapItem(mapNum, i).PlayerName <> vbNullString Then
                        ' Tornar item publico?
                        If MapItem(mapNum, i).PlayerTimer < GetTimeMs() Then
                            ' Fazer publico
                            MapItem(mapNum, i).PlayerName = vbNullString
                            MapItem(mapNum, i).PlayerTimer = 0
                            ' Enviar atualização para todos
                            SendMapItemsToAll(mapNum)
                        End If
                        ' Retirar item?
                        If MapItem(mapNum, i).CanDespawn Then
                            If MapItem(mapNum, i).DespawnTimer < GetTimeMs() Then
                                ' Retirar do mapa
                                ClearMapItem(i, mapNum)
                                ' Enviar atualização para todos
                                SendMapItemsToAll(mapNum)
                            End If
                        End If
                    End If
                End If
            Next

            '  Fechar as portas
            If tickCount > TempTile(mapNum).DoorTimer + 5000 Then

                For x1 = 0 To Map(mapNum).MaxX
                    For y1 = 0 To Map(mapNum).MaxY
                        If Map(mapNum).Tile(x1, y1).Type = TileType.Key AndAlso TempTile(mapNum).DoorOpen(x1, y1) = True Then
                            TempTile(mapNum).DoorOpen(x1, y1) = False
                            SendMapKeyToMap(mapNum, x1, y1, 0)
                        End If
                    Next
                Next

            End If

            ' Regerar recursos
            If ResourceCache Is Nothing Then Exit Sub
            If ResourceCache(mapNum).ResourceCount > 0 Then
                For i = 1 To ResourceCache(mapNum).ResourceCount

                    resourceIndex = Map(mapNum).Tile(ResourceCache(mapNum).ResourceData(i).X, ResourceCache(mapNum).ResourceData(i).Y).Data1

                    If resourceIndex > 0 Then
                        If ResourceCache(mapNum).ResourceData(i).ResourceState = 1 OrElse ResourceCache(mapNum).ResourceData(i).CurHealth < 1 Then  ' dead or fucked up
                            If ResourceCache(mapNum).ResourceData(i).ResourceTimer + (Resource(resourceIndex).RespawnTime * 1000) < GetTimeMs() Then
                                ResourceCache(mapNum).ResourceData(i).ResourceTimer = GetTimeMs()
                                ResourceCache(mapNum).ResourceData(i).ResourceState = 0 ' normal
                                ' re-set health to resource root
                                ResourceCache(mapNum).ResourceData(i).CurHealth = Resource(resourceIndex).Health
                                SendResourceCacheToMap(mapNum, i)
                            End If
                        End If
                    End If
                Next
            End If

            If ServerDestroyed Then Exit Sub

            If PlayersOnMap(mapNum) = True Then
                tickCount = GetTimeMs()

                For x = 1 To MAX_MAP_NPCS
                    npcNum = MapNpc(mapNum).Npc(x).Num

                    ' ver se terminaram de conjurar e se sim, fazer a habilidade seguir adiante
                    If MapNpc(mapNum).Npc(x).SkillBuffer > 0 AndAlso Map(mapNum).Npc(x) > 0 AndAlso MapNpc(mapNum).Npc(x).Num > 0 Then
                        If GetTimeMs() > MapNpc(mapNum).Npc(x).SkillBufferTimer + (Skill(Npc(npcNum).Skill(MapNpc(mapNum).Npc(x).SkillBuffer)).CastTime * 1000) Then
                            CastNpcSkill(x, mapNum, MapNpc(mapNum).Npc(x).SkillBuffer)
                            MapNpc(mapNum).Npc(x).SkillBuffer = 0
                            MapNpc(mapNum).Npc(x).SkillBufferTimer = 0
                        End If
                    Else
                        ' /////////////////////////////////////////
                        ' // Isso é usado para o ATAQUE AO VER   //
                        ' /////////////////////////////////////////
                        ' Ter certeza que tem um NPC no mapa
                        If Map(mapNum).Npc(x) > 0 AndAlso MapNpc(mapNum).Npc(x).Num > 0 Then

                            ' Se o NPC ataca ao ver, procurar por um jogador no mapa
                            If Npc(npcNum).Behaviour = NpcBehavior.AttackOnSight OrElse Npc(npcNum).Behaviour = NpcBehavior.Guard Then

                                ' Tter certeza que não está estuporado
                                If Not MapNpc(mapNum).Npc(x).StunDuration > 0 Then

                                    For i = 1 To GetPlayersOnline()
                                        If IsPlaying(i) Then
                                            If GetPlayerMap(i) = mapNum AndAlso MapNpc(mapNum).Npc(x).Target = 0 AndAlso GetPlayerAccess(i) <= AdminType.Monitor Then
                                                If PetAlive(i) Then
                                                    n = Npc(npcNum).Range
                                                    distanceX = MapNpc(mapNum).Npc(x).X - Player(i).Character(TempPlayer(i).CurChar).Pet.X
                                                    distanceY = MapNpc(mapNum).Npc(x).Y - Player(i).Character(TempPlayer(i).CurChar).Pet.Y

                                                    ' Ter certeza que é um valor positivo
                                                    If distanceX < 0 Then distanceX *= -1
                                                    If distanceY < 0 Then distanceY *= -1

                                                    ' Está ao alcance? Peguem-no
                                                    If distanceX <= n AndAlso distanceY <= n Then
                                                        If Npc(npcNum).Behaviour = NpcBehavior.AttackOnSight OrElse GetPlayerPK(i) = i Then
                                                            If Len(Trim$(Npc(npcNum).AttackSay)) > 0 Then
                                                                PlayerMsg(i, Trim$(Npc(npcNum).Name) & " diz: " & Npc(npcNum).AttackSay.Trim, QColorType.SayColor)
                                                            End If
                                                            MapNpc(mapNum).Npc(x).TargetType = TargetType.Pet
                                                            MapNpc(mapNum).Npc(x).Target = i
                                                        End If
                                                    End If
                                                Else
                                                    n = Npc(npcNum).Range
                                                    distanceX = MapNpc(mapNum).Npc(x).X - GetPlayerX(i)
                                                    distanceY = MapNpc(mapNum).Npc(x).Y - GetPlayerY(i)

                                                    ' Ter certeza que é um valor positivo
                                                    If distanceX < 0 Then distanceX *= -1
                                                    If distanceY < 0 Then distanceY *= -1

                                                    ' Está ao alcance? Peguem-no
                                                    If distanceX <= n AndAlso distanceY <= n Then
                                                        If Npc(npcNum).Behaviour = NpcBehavior.AttackOnSight OrElse GetPlayerPK(i) = True Then
                                                            If Len(Trim$(Npc(npcNum).AttackSay)) > 0 Then
                                                                PlayerMsg(i, CheckGrammar(Trim$(Npc(npcNum).Name), 1) & " diz, '" & Trim$(Npc(npcNum).AttackSay) & "' to you.", ColorType.Yellow)
                                                            End If
                                                            MapNpc(mapNum).Npc(x).TargetType = TargetType.Player
                                                            MapNpc(mapNum).Npc(x).Target = i
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Next

                                    'Ver se o alvo foi encontrado para virar alvo do NPC 
                                    If MapNpc(mapNum).Npc(x).Target = 0 AndAlso Npc(npcNum).Faction > 0 Then
                                        ' Procurar pelo NPC de outra facção pra ter como alvo
                                        For i = 1 To MAX_MAP_NPCS
                                            ' existe?
                                            If MapNpc(mapNum).Npc(i).Num > 0 Then
                                                ' Facção diferente?
                                                If Npc(MapNpc(mapNum).Npc(i).Num).Faction > 0 AndAlso Npc(MapNpc(mapNum).Npc(i).Num).Faction <> Npc(npcNum).Faction Then
                                                    n = Npc(npcNum).Range
                                                    distanceX = MapNpc(mapNum).Npc(x).X - CLng(MapNpc(mapNum).Npc(i).X)
                                                    distanceY = MapNpc(mapNum).Npc(x).Y - CLng(MapNpc(mapNum).Npc(i).Y)

                                                    ' Ter certeza que é valor positivo
                                                    If distanceX < 0 Then distanceX *= -1
                                                    If distanceY < 0 Then distanceY *= -1

                                                    ' Está ao alcance? Peguem-no!
                                                    If distanceX <= n AndAlso distanceY <= n AndAlso Npc(npcNum).Behaviour = NpcBehavior.AttackOnSight Then
                                                        MapNpc(mapNum).Npc(x).TargetType = 2 ' npc
                                                        MapNpc(mapNum).Npc(x).Target = i
                                                    End If
                                                End If
                                            End If
                                        Next
                                    End If
                                End If
                            End If
                        End If

                        targetVerify = False

                        ' //////////////////////////////////////
                        ' // Usado para o NPC andar/ter alvo ///
                        ' /////////////////////////////////////
                        ' Ter certeza que tem um NPC no mapa
                        If Map(mapNum).Npc(x) > 0 AndAlso MapNpc(mapNum).Npc(x).Num > 0 Then
                            If MapNpc(mapNum).Npc(x).StunDuration > 0 Then
                                ' Ver se podemos desestuporá-lo
                                If GetTimeMs() > MapNpc(mapNum).Npc(x).StunTimer + (MapNpc(mapNum).Npc(x).StunDuration * 1000) Then
                                    MapNpc(mapNum).Npc(x).StunDuration = 0
                                    MapNpc(mapNum).Npc(x).StunTimer = 0
                                End If
                            Else

                                target = MapNpc(mapNum).Npc(x).Target
                                targetTypes = MapNpc(mapNum).Npc(x).TargetType

                                ' Ver se é hora do NPC andar
                                If Npc(npcNum).Behaviour <> NpcBehavior.ShopKeeper AndAlso Npc(npcNum).Behaviour <> NpcBehavior.Quest Then
                                    If targetTypes = TargetType.Player Then ' jogador
                                        ' Ver se estamos seguindo um jogador ou não
                                        If target > 0 Then
                                            ' Ver se o jogador sequer está jogando; se sim, seguir
                                            If IsPlaying(target) AndAlso GetPlayerMap(target) = mapNum Then
                                                targetVerify = True
                                                targetY = GetPlayerY(target)
                                                targetX = GetPlayerX(target)
                                            Else
                                                MapNpc(mapNum).Npc(x).TargetType = 0 ' limpar
                                                MapNpc(mapNum).Npc(x).Target = 0
                                            End If
                                        End If
                                    ElseIf targetTypes = TargetType.Npc Then 'npc
                                        If target > 0 Then
                                            If MapNpc(mapNum).Npc(target).Num > 0 Then
                                                targetVerify = True
                                                targetY = MapNpc(mapNum).Npc(target).Y
                                                targetX = MapNpc(mapNum).Npc(target).X
                                            Else
                                                MapNpc(mapNum).Npc(x).TargetType = 0 ' limpar
                                                MapNpc(mapNum).Npc(x).Target = 0
                                            End If
                                        End If
                                    ElseIf targetTypes = TargetType.Pet Then
                                        If target > 0 Then
                                            If IsPlaying(target) = True AndAlso GetPlayerMap(target) = mapNum AndAlso PetAlive(target) Then
                                                targetVerify = True
                                                targetY = Player(target).Character(TempPlayer(target).CurChar).Pet.Y
                                                targetX = Player(target).Character(TempPlayer(target).CurChar).Pet.X
                                            Else
                                                MapNpc(mapNum).Npc(x).TargetType = 0 ' limpar
                                                MapNpc(mapNum).Npc(x).Target = 0
                                            End If
                                        End If
                                    End If

                                    If targetVerify Then
                                        'Faz os NPCs mais inteligentes... Implementar um algoritmo de Pathfind.  Devemos ver o que acontece.
                                        If IsOneBlockAway(targetX, targetY, CLng(MapNpc(mapNum).Npc(x).X), CLng(MapNpc(mapNum).Npc(x).Y)) = False Then

                                            i = FindNpcPath(mapNum, x, targetX, targetY)
                                            If i < 4 Then 'Retorna uma resposta. Move o NPC.
                                                If CanNpcMove(mapNum, x, i) Then
                                                    NpcMove(mapNum, x, i, MovementType.Walking)
                                                End If
                                            Else 'Nenhum caminho bom encontrado. Mover aleatoriamente.
                                                i = Int(Rnd() * 4)
                                                If i = 1 Then
                                                    i = Int(Rnd() * 4)

                                                    If CanNpcMove(mapNum, x, i) Then
                                                        NpcMove(mapNum, x, i, MovementType.Walking)
                                                    End If
                                                End If
                                            End If
                                        Else
                                            NpcDir(mapNum, x, GetNpcDir(targetX, targetY, CLng(MapNpc(mapNum).Npc(x).X), CLng(MapNpc(mapNum).Npc(x).Y)))
                                        End If
                                    Else
                                        i = Int(Rnd() * 4)

                                        If i = 1 Then
                                            i = Int(Rnd() * 4)

                                            If CanNpcMove(mapNum, x, i) Then
                                                NpcMove(mapNum, x, i, MovementType.Walking)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If

                    End If

                    ' //////////////////////////////////////////
                    ' // Usado para NPCs atacarem seus alvos //
                    ' /////////////////////////////////////////
                    ' Ter certeza que tem um NPC no mapa
                    If Map(mapNum).Npc(x) > 0 AndAlso MapNpc(mapNum).Npc(x).Num > 0 Then
                        target = MapNpc(mapNum).Npc(x).Target
                        targetTypes = MapNpc(mapNum).Npc(x).TargetType

                        ' Ver se o NPC pode atacar o jogador-alvo
                        If target > 0 Then

                            If targetTypes = TargetType.Player Then ' jogador

                                ' O jogador está jogando no mesmo mapa?
                                If IsPlaying(target) AndAlso GetPlayerMap(target) = mapNum Then
                                    If IsPlaying(target) AndAlso GetPlayerMap(target) = mapNum Then
                                        If Random(1, 3) = 1 Then
                                            Dim skillnum As Integer = RandomNpcAttack(mapNum, x)
                                            If skillnum > 0 Then
                                                BufferNpcSkill(mapNum, x, skillnum)
                                            Else
                                                TryNpcAttackPlayer(x, target) ', Damage)
                                            End If
                                        Else
                                            TryNpcAttackPlayer(x, target)
                                        End If
                                    Else
                                        ' Jogador saiu do mapa/jogo, botar alvo como zero 
                                        MapNpc(mapNum).Npc(x).Target = 0
                                        MapNpc(mapNum).Npc(x).TargetType = 0 ' limpar

                                    End If
                                Else
                                    'Jogador saiu do mapa/jogo, botar alvo como zero
                                    MapNpc(mapNum).Npc(x).Target = 0
                                    MapNpc(mapNum).Npc(x).TargetType = 0 ' limpar
                                End If
                            ElseIf targetTypes = TargetType.Npc Then
                                If MapNpc(mapNum).Npc(target).Num > 0 Then ' npc existe
                                    'O NPC pode atacar o NPC??
                                    If CanNpcAttackNpc(mapNum, x, target) Then
                                        damage = Npc(npcNum).Stat(StatType.Strength) - CLng(Npc(target).Stat(StatType.Endurance))
                                        If damage < 1 Then damage = 1
                                        NpcAttackNpc(mapNum, x, target, damage)
                                    End If
                                Else
                                    ' NPC está morto ou não-existente
                                    MapNpc(mapNum).Npc(x).Target = 0
                                    MapNpc(mapNum).Npc(x).TargetType = 0 ' limpar
                                End If
                            ElseIf targetTypes = TargetType.Pet Then
                                If IsPlaying(target) AndAlso GetPlayerMap(target) = mapNum AndAlso PetAlive(target) Then
                                    TryNpcAttackPet(x, target)
                                Else
                                    ' Jogador saiu do mapa, definir alvo como zero
                                    MapNpc(mapNum).Npc(x).Target = 0
                                    MapNpc(mapNum).Npc(x).TargetType = 0 ' clear
                                End If
                            End If
                        End If
                    End If

                    ' ///////////////////////////////////////
                    ' // Usado para regenerar o HP do NPC //
                    ' //////////////////////////////////////
                    ' Ver se queremos recuperar parte do HP do NPC
                    If MapNpc(mapNum).Npc(x).Num > 0 AndAlso tickCount > GiveNPCHPTimer + 10000 Then
                        If MapNpc(mapNum).Npc(x).Vital(VitalType.HP) > 0 Then
                            MapNpc(mapNum).Npc(x).Vital(VitalType.HP) = MapNpc(mapNum).Npc(x).Vital(VitalType.HP) + GetNpcVitalRegen(npcNum, VitalType.HP)

                            ' Ver se eles tem mais do que devem; se sim, setar para o HP máximo
                            If MapNpc(mapNum).Npc(x).Vital(VitalType.HP) > GetNpcMaxVital(npcNum, VitalType.HP) Then
                                MapNpc(mapNum).Npc(x).Vital(VitalType.HP) = GetNpcMaxVital(npcNum, VitalType.HP)
                            End If
                        End If
                    End If

                    If MapNpc(mapNum).Npc(x).Num > 0 AndAlso tickCount > GiveNPCMPTimer + 10000 AndAlso MapNpc(mapNum).Npc(x).Vital(VitalType.MP) > 0 Then
                        MapNpc(mapNum).Npc(x).Vital(VitalType.MP) = MapNpc(mapNum).Npc(x).Vital(VitalType.MP) + GetNpcVitalRegen(npcNum, VitalType.MP)

                        ' Ver se eles tem mais do que devem; se sim, setar para o HP máximo
                        If MapNpc(mapNum).Npc(x).Vital(VitalType.MP) > GetNpcMaxVital(npcNum, VitalType.MP) Then
                            MapNpc(mapNum).Npc(x).Vital(VitalType.MP) = GetNpcMaxVital(npcNum, VitalType.MP)
                        End If
                    End If

                    ' ///////////////////////////////////////////////////
                    ' // Usado para checar se o NPC está morto ou não //
                    ' //////////////////////////////////////////////////
                    ' Ver se o NPC está morto ou não
                    If MapNpc(mapNum).Npc(x).Num > 0 AndAlso MapNpc(mapNum).Npc(x).Vital(VitalType.HP) <= 0 Then
                        MapNpc(mapNum).Npc(x).Num = 0
                        MapNpc(mapNum).Npc(x).SpawnWait = GetTimeMs()
                        MapNpc(mapNum).Npc(x).Vital(VitalType.HP) = 0
                    End If

                    ' /////////////////////////////////////
                    ' // Usado para gerar NPCs nos mapas //
                    ' /////////////////////////////////////
                    ' Verificar se devemos gerar NPCs nos mapas ou não
                    If MapNpc(mapNum).Npc(x).Num = 0 AndAlso Map(mapNum).Npc(x) > 0 Then
                        If tickCount > MapNpc(mapNum).Npc(x).SpawnWait + (Npc(Map(mapNum).Npc(x)).SpawnSecs * 1000) Then
                            SpawnNpc(x, mapNum)
                        End If
                    End If
                Next
            End If

        Next

        ' Ter certeza que resetamos o timer da recuperação de hp do NPC
        If GetTimeMs() > GiveNPCHPTimer + 10000 Then GiveNPCHPTimer = GetTimeMs()

        If GetTimeMs() > GiveNPCMPTimer + 10000 Then GiveNPCMPTimer = GetTimeMs()

        ' Ter certeza que resetamos o timer para fechamento de portas
        If GetTimeMs() > KeyTimer + 15000 Then KeyTimer = GetTimeMs()

    End Sub

    Function GetNpcVitalRegen(npcNum As Integer, vital As VitalType) As Integer
        Dim i As Integer

        'Prevenir subscript out of range
        If npcNum <= 0 OrElse npcNum > MAX_NPCS Then
            GetNpcVitalRegen = 0
            Exit Function
        End If

        Select Case vital
            Case VitalType.HP
                i = Npc(npcNum).Stat(StatType.Vitality) \ 3

                If i < 1 Then i = 1
                GetNpcVitalRegen = i
            Case VitalType.MP
                i = Npc(npcNum).Stat(StatType.Intelligence) \ 3

                If i < 1 Then i = 1
                GetNpcVitalRegen = i
        End Select

    End Function

    Friend Function HandleCloseSocket(index As Integer) As Boolean
        Socket.Disconnect(index)
        HandleCloseSocket = True
    End Function

    Friend Function HandlePlayerHouse(index As Integer) As Boolean
        Player(index).Character(TempPlayer(index).CurChar).InHouse = 0
        PlayerWarp(index, Player(index).Character(TempPlayer(index).CurChar).LastMap, Player(index).Character(TempPlayer(index).CurChar).LastX, Player(index).Character(TempPlayer(index).CurChar).LastY)
        PlayerMsg(index, "Sua visita se encerrou possivelmente em virtude de desconexão. Você está sendo teleportado para sua localização anterior.", ColorType.Yellow)
        HandlePlayerHouse = True
    End Function

    Friend Function HandlePetSkill(index As Integer) As Boolean
        PetCastSkill(index, TempPlayer(index).PetskillBuffer.Skill, TempPlayer(index).PetskillBuffer.Target, TempPlayer(index).PetskillBuffer.TargetTypes, True)
        TempPlayer(index).PetskillBuffer.Skill = 0
        TempPlayer(index).PetskillBuffer.Timer = 0
        TempPlayer(index).PetskillBuffer.Target = 0
        TempPlayer(index).PetskillBuffer.TargetTypes = 0
        HandlePetSkill = True
    End Function

    Friend Function HandlePlayerCraft(index As Integer) As Boolean
        TempPlayer(index).CraftIt = 0
        TempPlayer(index).CraftTimer = 0
        TempPlayer(index).CraftTimeNeeded = 0
        UpdateCraft(index)
        HandlePlayerCraft = True
    End Function

    Friend Function HandleClearStun(index As Integer) As Boolean
        TempPlayer(index).StunDuration = 0
        TempPlayer(index).StunTimer = 0
        SendStunned(index)
        HandleClearStun = True
    End Function

    Friend Function HandleClearPetStun(index As Integer) As Boolean
        TempPlayer(index).PetStunDuration = 0
        TempPlayer(index).PetStunTimer = 0
        HandleClearPetStun = True
    End Function

    Friend Function HandleStopPetRegen(index As Integer) As Boolean
        TempPlayer(index).PetstopRegen = False
        TempPlayer(index).PetstopRegenTimer = 0
        HandleStopPetRegen = True
    End Function

    Friend Function HandleCastSkill(index As Integer) As Boolean
        CastSkill(index, TempPlayer(index).SkillBuffer)
        TempPlayer(index).SkillBuffer = 0
        TempPlayer(index).SkillBufferTimer = 0
        HandleCastSkill = True
    End Function

    Friend Sub CastSkill(index As Integer, skillSlot As Integer)
        ' Setar algumas variáveis básicas que estaremos usando.
        Dim skillId = GetPlayerSkill(index, skillSlot)

        ' Checagens preventivas
        If Not IsPlaying(index) OrElse skillSlot <= 0 OrElse skillSlot > MAX_PLAYER_SKILLS OrElse Not HasSkill(index, skillId) Then Exit Sub

        ' Ver se o jogador pode usar a magia.
        If GetPlayerVital(index, VitalType.MP) < Skill(skillId).MpCost Then
            PlayerMsg(index, "Mana insuficiente!", ColorType.BrightRed)
            Exit Sub
        ElseIf GetPlayerLevel(index) < Skill(skillId).LevelReq Then
            PlayerMsg(index, String.Format("Você deve ser nível {0} para usar essa habilidade.", Skill(skillId).LevelReq), ColorType.BrightRed)
            Exit Sub
        ElseIf GetPlayerAccess(index) < Skill(skillId).AccessReq Then
            PlayerMsg(index, "Você deve ser um administrador para usar essa habilidade.", ColorType.BrightRed)
            Exit Sub
        ElseIf Not Skill(skillId).ClassReq = 0 AndAlso GetPlayerClass(index) <> Skill(skillId).ClassReq Then
            PlayerMsg(index, String.Format("Apenas {0} pode usar essa habilidade.", CheckGrammar((Classes(Skill(skillId).ClassReq).Name.Trim()))), ColorType.BrightRed)
            Exit Sub
        ElseIf Skill(skillId).Range > 0 AndAlso Not IsTargetOnMap(index) Then
            Exit Sub
        ElseIf Skill(skillId).Range > 0 AndAlso Not IsInSkillRange(index, skillId) AndAlso Skill(skillId).IsProjectile = 0 Then
            PlayerMsg(index, "Alvo fora de alcance.", ColorType.BrightRed)
            SendClearSkillBuffer(index)
            Exit Sub
        End If

        ' Determinar que tipo de magia estamos utilizando e seguir para os métodos apropriados.
        If Skill(skillId).IsProjectile = 1 Then
            PlayerFireProjectile(index, skillId)
        Else
            If Skill(skillId).Range = 0 AndAlso Not Skill(skillId).IsAoE Then HandleSelfCastSkill(index, skillId)
            If Skill(skillId).Range = 0 AndAlso Skill(skillId).IsAoE Then HandleSelfCastAoESkill(index, skillId)
            If Skill(skillId).Range > 0 AndAlso Skill(skillId).IsAoE Then HandleTargetedAoESkill(index, skillId)
            If Skill(skillId).Range > 0 AndAlso Not Skill(skillId).IsAoE Then HandleTargetedSkill(index, skillId)
        End If

        ' Fazer tudo que precisamos fazer ao fim do uso.
        FinalizeCast(index, GetPlayerSkillSlot(index, skillId), Skill(skillId).MpCost)
    End Sub

    Private Sub HandleSelfCastAoESkill(index As Integer, skillId As Integer)

        ' Preparar algumas variáveis que estaremos usando.
        Dim centerX = GetPlayerX(index)
        Dim centerY = GetPlayerY(index)

        ' Determinar que tipo de magia estamos utilizando e processá-la.
        Select Case Skill(skillId).Type
            Case SkillType.DamageHp, SkillType.DamageMp, SkillType.HealHp, SkillType.HealMp
                HandleAoE(index, skillId, centerX, centerY)

            Case Else
                Throw New NotImplementedException()
        End Select

    End Sub

    Private Sub HandleTargetedAoESkill(index As Integer, skillId As Integer)

        ' Preparar algumas variáveis que estaremos usando.
        Dim centerX As Integer
        Dim centerY As Integer
        Select Case TempPlayer(index).TargetType
            Case TargetType.Npc
                centerX = MapNpc(GetPlayerMap(index)).Npc(TempPlayer(index).Target).X
                centerY = MapNpc(GetPlayerMap(index)).Npc(TempPlayer(index).Target).Y

            Case TargetType.Player
                centerX = GetPlayerX(TempPlayer(index).Target)
                centerY = GetPlayerY(TempPlayer(index).Target)

            Case Else
                Throw New NotImplementedException()

        End Select

        ' Determinar que tipo de magia estamos utilizando e processá-la.
        Select Case Skill(skillId).Type
            Case SkillType.HealMp, SkillType.DamageHp, SkillType.DamageMp, SkillType.HealHp
                HandleAoE(index, skillId, centerX, centerY)

            Case Else
                Throw New NotImplementedException()
        End Select
    End Sub

    Private Sub HandleSelfCastSkill(index As Integer, skillId As Integer)
        ' Determinar que tipo de magia estamos utilizando e processá-la.
        Select Case Skill(skillId).Type
            Case SkillType.HealHp
                SkillPlayer_Effect(VitalType.HP, True, index, Skill(skillId).Vital, skillId)
            Case SkillType.HealMp
                SkillPlayer_Effect(VitalType.MP, True, index, Skill(skillId).Vital, skillId)
            Case SkillType.Warp
                SendAnimation(GetPlayerMap(index), Skill(skillId).SkillAnim, 0, 0, TargetType.Player, index)
                PlayerWarp(index, Skill(skillId).Map, Skill(skillId).X, Skill(skillId).Y)
            Case Else
                Throw New NotImplementedException()
        End Select

        ' Tocar a animação.
        SendAnimation(GetPlayerMap(index), Skill(skillId).SkillAnim, 0, 0, TargetType.Player, index)
    End Sub

    Private Sub HandleTargetedSkill(index As Integer, skillId As Integer)
        ' Preparar algumas variáveis que estaremos usando.
        Dim vital As VitalType
        Dim dealsDamage As Boolean
        Dim amount = Skill(skillId).Vital
        Dim target = TempPlayer(index).Target

        ' Determinar qual vital deve ser ajustado e como.
        Select Case Skill(skillId).Type
            Case SkillType.DamageHp
                vital = VitalType.HP
                dealsDamage = True

            Case SkillType.DamageMp
                vital = VitalType.MP
                dealsDamage = True

            Case SkillType.HealHp
                vital = VitalType.HP
                dealsDamage = False

            Case SkillType.HealMp
                vital = VitalType.MP
                dealsDamage = False

            Case Else
                Throw New NotImplementedException
        End Select

        Select Case TempPlayer(index).TargetType
            Case TargetType.Npc
                ' Lidar com habilidades de dano.
                If dealsDamage AndAlso CanPlayerAttackNpc(index, target, True) Then SkillNpc_Effect(vital, False, target, amount, skillId, GetPlayerMap(index))

                ' Lidar com habilidades de cura
                If Not dealsDamage Then SkillNpc_Effect(vital, True, target, amount, skillId, GetPlayerMap(index))

                ' Lidar com a morte do NPC se matá-lo
                If IsNpcDead(GetPlayerMap(index), TempPlayer(index).Target) Then
                    HandlePlayerKillNpc(GetPlayerMap(index), index, TempPlayer(index).Target)
                End If

            Case TargetType.Player

                ' Lidar com habilidades de dano.
                If dealsDamage AndAlso CanPlayerAttackPlayer(index, target, True) Then SkillPlayer_Effect(vital, False, target, amount, skillId)

                ' Lidar com habilidades de cura
                If Not dealsDamage Then SkillPlayer_Effect(vital, True, target, amount, skillId)

                If IsPlayerDead(target) Then
                    ' Matar o jogador.
                    OnDeath(target)

                    ' Lidar com coisas de PK.
                    HandlePlayerKilledPK(index, target)

                    ' Lidar com o sistema de quest.
                    CheckTasks(index, QuestType.Kill, 0)
                End If
            Case Else
                Throw New NotImplementedException()

        End Select

        ' Tocar nossa animação.
        SendAnimation(GetPlayerMap(index), Skill(skillId).SkillAnim, 0, 0, TempPlayer(index).TargetType, target)
    End Sub

    Private Sub HandleAoE(index As Integer, skillId As Integer, x As Integer, y As Integer)
        ' Ajeitar algumas coisas básicas.
        Dim map = GetPlayerMap(index)
        Dim range = Skill(skillId).Range
        Dim amount = Skill(skillId).Vital
        Dim vital As VitalType
        Dim dealsDamage As Boolean

        ' Determinar qual vital devemos ajustar e como
        Select Case Skill(skillId).Type
            Case SkillType.DamageHp
                vital = VitalType.HP
                dealsDamage = True

            Case SkillType.DamageMp
                vital = VitalType.MP
                dealsDamage = True

            Case SkillType.HealHp
                vital = VitalType.HP
                dealsDamage = False

            Case SkillType.HealMp
                vital = VitalType.MP
                dealsDamage = False

            Case Else
                Throw New NotImplementedException
        End Select

        ' Fazer loops por todos os jogadores online nesse mapa.
        For Each id In TempPlayer.Where(Function(p) p.InGame).Select(Function(p, i) i + 1).Where(Function(i) GetPlayerMap(i) = map AndAlso i <> index).ToArray()
            If IsInRange(range, x, y, GetPlayerX(id), GetPlayerY(id)) Then

                ' Lidar com habilidades de dano.
                If dealsDamage AndAlso CanPlayerAttackPlayer(index, id, True) Then SkillPlayer_Effect(vital, False, id, amount, skillId)

                ' Lidar com habilidades de cura
                If Not dealsDamage Then SkillPlayer_Effect(vital, True, id, amount, skillId)

                ' Enviar nossa animação ao mapa.
                SendAnimation(map, Skill(skillId).SkillAnim, 0, 0, TargetType.Player, id)

                If IsPlayerDead(id) Then
                    ' Matar o jogador.
                    OnDeath(id)

                    ' Lidar com as coisas de PK.
                    HandlePlayerKilledPK(index, id)

                    ' Lidar com o sistema de quests.
                    CheckTasks(index, QuestType.Kill, 0)
                End If
            End If
        Next

        ' Fazer loops por todos os NPCs nesse mapa
        For Each id In MapNpc(map).Npc.Where(Function(n) n.Num > 0 AndAlso n.Vital(VitalType.HP) > 0).Select(Function(n, i) i + 1).ToArray()
            If IsInRange(range, x, y, MapNpc(map).Npc(id).X, MapNpc(map).Npc(id).Y) Then

                ' Lidar com habilidades de dano.
                If dealsDamage AndAlso CanPlayerAttackNpc(index, id, True) Then SkillNpc_Effect(vital, False, id, amount, skillId, map)

                ' Lidar com habilidades de cura
                If Not dealsDamage Then SkillNpc_Effect(vital, True, id, amount, skillId, map)

                ' Enviar nossa animação ao mapa.
                SendAnimation(map, Skill(skillId).SkillAnim, 0, 0, TargetType.Npc, id)

                ' Lidar com a morte do NPC se matar
                If IsNpcDead(map, id) Then
                    HandlePlayerKillNpc(map, index, id)
                End If
            End If
        Next
    End Sub

    Private Sub FinalizeCast(index As Integer, skillSlot As Integer, skillCost As Integer)
        SetPlayerVital(index, VitalType.MP, GetPlayerVital(index, VitalType.MP) - skillCost)
        SendVital(index, VitalType.MP)
        TempPlayer(index).SkillCd(skillSlot) = GetTimeMs() + (Skill(skillSlot).CdTime * 1000)
        SendCooldown(index, skillSlot)
    End Sub

    Private Function IsTargetOnMap(index As Integer) As Boolean
        If TempPlayer(index).TargetType = TargetType.Player Then
            If GetPlayerMap(TempPlayer(index).Target) = GetPlayerMap(index) Then IsTargetOnMap = True
        ElseIf TempPlayer(index).TargetType = TargetType.Npc Then
            If TempPlayer(index).Target > 0 AndAlso TempPlayer(index).Target <= MAX_MAP_NPCS AndAlso MapNpc(GetPlayerMap(index)).Npc(TempPlayer(index).Target).Vital(VitalType.HP) > 0 Then IsTargetOnMap = True
        End If
    End Function

    Private Function IsInSkillRange(index As Integer, SkillId As Integer) As Boolean
        Dim targetX As Integer, targetY As Integer

        If TempPlayer(index).TargetType = TargetType.Player Then
            targetX = GetPlayerX(TempPlayer(index).Target)
            targetY = GetPlayerY(TempPlayer(index).Target)
        ElseIf TempPlayer(index).TargetType = TargetType.Npc Then
            targetX = MapNpc(GetPlayerMap(index)).Npc(TempPlayer(index).Target).X
            targetY = MapNpc(GetPlayerMap(index)).Npc(TempPlayer(index).Target).Y
        End If

        IsInSkillRange = IsInRange(Skill(SkillId).Range, GetPlayerX(index), GetPlayerY(index), targetX, targetY)
    End Function

    Friend Sub CastNpcSkill(npcNum As Integer, mapNum As Integer, skillslot As Integer)
        Dim skillnum As Integer, mpCost As Integer
        Dim vital As Integer, didCast As Boolean
        Dim i As Integer
        Dim aoe As Integer, range As Integer, vitalType As Byte
        Dim increment As Boolean, x As Integer, y As Integer

        Dim targetType As Byte
        Dim target As Integer
        Dim skillCastType As Integer

        didCast = False

        ' Prevenir subscript out of range
        If skillslot <= 0 OrElse skillslot > MAX_NPC_SKILLS Then Exit Sub

        skillnum = GetNpcSkill(MapNpc(mapNum).Npc(npcNum).Num, skillslot)

        mpCost = Skill(skillnum).MpCost

        ' Ver se tem MP suficiente
        If MapNpc(mapNum).Npc(npcNum).Vital(modEnumerators.VitalType.MP) < mpCost Then Exit Sub

        ' descobrir que tipo de habilidade é! em si, alvo ou área de efeito
        If Skill(skillnum).IsProjectile = 1 Then
            skillCastType = 4 ' Projetil
        ElseIf Skill(skillnum).Range > 0 Then
            ' ataque a distancia, alvo simples ou área de efeito?
            If Not Skill(skillnum).IsAoE Then
                skillCastType = 2 ' alvo
            Else
                skillCastType = 3 ' área de efeito em alvo
            End If
        Else
            If Not Skill(skillnum).IsAoE Then
                skillCastType = 0 ' em si
            Else
                skillCastType = 1 ' área de efeito em si
            End If
        End If

        ' setar os vitais
        vital = Skill(skillnum).Vital
        aoe = Skill(skillnum).AoE
        range = Skill(skillnum).Range

        Select Case skillCastType
            Case 0 ' self-cast target
                'Select Case Skill(skillnum).Type
                '    Case SkillType.HEALHP
                '        SkillPlayer_Effect(VitalType.HP, True, NpcNum, Vital, skillnum)
                '        DidCast = True
                '    Case SkillType.HEALMP
                '        SkillPlayer_Effect(VitalType.MP, True, NpcNum, Vital, skillnum)
                '        DidCast = True
                '    Case SkillType.WARP
                '        SendAnimation(MapNum, Skill(skillnum).SkillAnim, 0, 0, TargetType.PLAYER, NpcNum)
                '        PlayerWarp(NpcNum, Skill(skillnum).Map, Skill(skillnum).x, Skill(skillnum).y)
                '        SendAnimation(GetPlayerMap(NpcNum), Skill(skillnum).SkillAnim, 0, 0, TargetType.PLAYER, NpcNum)
                '        DidCast = True
                'End Select

            Case 1, 3 ' área de efeito em si própro & alvo 
                If skillCastType = 1 Then
                    x = MapNpc(mapNum).Npc(npcNum).X
                    y = MapNpc(mapNum).Npc(npcNum).Y
                ElseIf skillCastType = 3 Then
                    targetType = MapNpc(mapNum).Npc(npcNum).TargetType
                    target = MapNpc(mapNum).Npc(npcNum).Target

                    If targetType = 0 Then Exit Sub
                    If target = 0 Then Exit Sub

                    If targetType = modEnumerators.TargetType.Player Then
                        x = GetPlayerX(target)
                        y = GetPlayerY(target)
                    Else
                        x = MapNpc(mapNum).Npc(target).X
                        y = MapNpc(mapNum).Npc(target).Y
                    End If

                    If Not IsInRange(range, x, y, GetPlayerX(npcNum), GetPlayerY(npcNum)) Then
                        Exit Sub
                    End If
                End If
                Select Case Skill(skillnum).Type
                    Case SkillType.DamageHp
                        didCast = True
                        For i = 1 To GetPlayersOnline()
                            If IsPlaying(i) Then
                                If GetPlayerMap(i) = mapNum Then
                                    If IsInRange(aoe, x, y, GetPlayerX(i), GetPlayerY(i)) Then
                                        If CanNpcAttackPlayer(npcNum, i) Then
                                            SendAnimation(mapNum, Skill(skillnum).SkillAnim, 0, 0, modEnumerators.TargetType.Player, i)
                                            PlayerMsg(i, Trim(Npc(MapNpc(mapNum).Npc(npcNum).Num).Name) & " uses " & Trim(Skill(skillnum).Name) & "!", ColorType.Yellow)
                                            SkillPlayer_Effect(modEnumerators.VitalType.HP, False, i, vital, skillnum)
                                        End If
                                    End If
                                End If
                            End If
                        Next
                        For i = 1 To MAX_MAP_NPCS
                            If MapNpc(mapNum).Npc(i).Num > 0 Then
                                If MapNpc(mapNum).Npc(i).Vital(modEnumerators.VitalType.HP) > 0 Then
                                    If IsInRange(aoe, x, y, MapNpc(mapNum).Npc(i).X, MapNpc(mapNum).Npc(i).Y) Then
                                        If CanPlayerAttackNpc(npcNum, i, True) Then
                                            SendAnimation(mapNum, Skill(skillnum).SkillAnim, 0, 0, modEnumerators.TargetType.Npc, i)
                                            SkillNpc_Effect(modEnumerators.VitalType.HP, False, i, vital, skillnum, mapNum)
                                            If Skill(skillnum).KnockBack = 1 Then
                                                KnockBackNpc(npcNum, target, skillnum)
                                            End If
                                        End If
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
                            If IsPlaying(i) AndAlso GetPlayerMap(i) = GetPlayerMap(npcNum) Then
                                If IsInRange(aoe, x, y, GetPlayerX(i), GetPlayerY(i)) Then
                                    SkillPlayer_Effect(vitalType, increment, i, vital, skillnum)
                                End If
                            End If
                        Next
                        For i = 1 To MAX_MAP_NPCS
                            If MapNpc(mapNum).Npc(i).Num > 0 AndAlso MapNpc(mapNum).Npc(i).Vital(modEnumerators.VitalType.HP) > 0 Then
                                If IsInRange(aoe, x, y, MapNpc(mapNum).Npc(i).X, MapNpc(mapNum).Npc(i).Y) Then
                                    SkillNpc_Effect(vitalType, increment, i, vital, skillnum, mapNum)
                                End If
                            End If
                        Next
                End Select

            Case 2 ' alvo

                targetType = MapNpc(mapNum).Npc(npcNum).TargetType
                target = MapNpc(mapNum).Npc(npcNum).Target

                If targetType = 0 OrElse target = 0 Then Exit Sub

                If MapNpc(mapNum).Npc(npcNum).TargetType = modEnumerators.TargetType.Player Then
                    x = GetPlayerX(target)
                    y = GetPlayerY(target)
                Else
                    x = MapNpc(mapNum).Npc(target).X
                    y = MapNpc(mapNum).Npc(target).Y
                End If

                If Not IsInRange(range, MapNpc(mapNum).Npc(npcNum).X, MapNpc(mapNum).Npc(npcNum).Y, x, y) Then Exit Sub

                Select Case Skill(skillnum).Type
                    Case SkillType.DamageHp
                        If MapNpc(mapNum).Npc(npcNum).TargetType = modEnumerators.TargetType.Player Then
                            If CanNpcAttackPlayer(npcNum, target) AndAlso vital > 0 Then
                                SendAnimation(mapNum, Skill(skillnum).SkillAnim, 0, 0, modEnumerators.TargetType.Player, target)
                                PlayerMsg(target, Trim(Npc(MapNpc(mapNum).Npc(npcNum).Num).Name) & " uses " & Trim(Skill(skillnum).Name) & "!", ColorType.Yellow)
                                SkillPlayer_Effect(modEnumerators.VitalType.HP, False, target, vital, skillnum)
                                didCast = True
                            End If
                        Else
                            If CanPlayerAttackNpc(npcNum, target, True) AndAlso vital > 0 Then
                                SendAnimation(mapNum, Skill(skillnum).SkillAnim, 0, 0, modEnumerators.TargetType.Npc, target)
                                SkillNpc_Effect(modEnumerators.VitalType.HP, False, i, vital, skillnum, mapNum)

                                If Skill(skillnum).KnockBack = 1 Then
                                    KnockBackNpc(npcNum, target, skillnum)
                                End If
                                didCast = True
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

                        If TempPlayer(npcNum).TargetType = modEnumerators.TargetType.Player Then
                            If Skill(skillnum).Type = SkillType.DamageMp Then
                                If CanPlayerAttackPlayer(npcNum, target, True) Then
                                    SkillPlayer_Effect(vitalType, increment, target, vital, skillnum)
                                End If
                            Else
                                SkillPlayer_Effect(vitalType, increment, target, vital, skillnum)
                            End If
                        Else
                            If Skill(skillnum).Type = SkillType.DamageMp Then
                                If CanPlayerAttackNpc(npcNum, target, True) Then
                                    SkillNpc_Effect(vitalType, increment, target, vital, skillnum, mapNum)
                                End If
                            Else
                                SkillNpc_Effect(vitalType, increment, target, vital, skillnum, mapNum)
                            End If
                        End If
                End Select
            Case 4 ' Projetil
                PlayerFireProjectile(npcNum, skillnum)

                didCast = True
        End Select

        If didCast Then
            MapNpc(mapNum).Npc(npcNum).Vital(modEnumerators.VitalType.MP) = MapNpc(mapNum).Npc(npcNum).Vital(modEnumerators.VitalType.MP) - mpCost
            SendMapNpcVitals(mapNum, npcNum)
            MapNpc(mapNum).Npc(npcNum).SkillCd(skillslot) = GetTimeMs() + (Skill(skillnum).CdTime * 1000)
        End If
    End Sub

    Friend Sub SkillPlayer_Effect(vital As Byte, increment As Boolean, index As Integer, damage As Integer, skillnum As Integer)
        Dim sSymbol As String
        Dim colour As Integer

        If damage > 0 Then
            ' Calcular para a resistência mágica.
            damage -= ((GetPlayerStat(index, StatType.Spirit) * 2) + (GetPlayerLevel(index) * 3))

            If increment Then
                sSymbol = "+"
                If vital = VitalType.HP Then colour = ColorType.BrightGreen
                If vital = VitalType.MP Then colour = ColorType.BrightBlue
            Else
                sSymbol = "-"
                colour = ColorType.BrightRed
            End If

            ' Lidar com efeitos estuporantes.
            If Skill(skillnum).StunDuration > 0 Then StunPlayer(index, skillnum)

            SendActionMsg(GetPlayerMap(index), sSymbol & damage, colour, ActionMsgType.Scroll, GetPlayerX(index) * 32, GetPlayerY(index) * 32)
            If increment Then SetPlayerVital(index, vital, GetPlayerVital(index, vital) + damage)
            If Not increment Then SetPlayerVital(index, vital, GetPlayerVital(index, vital) - damage)
            SendVital(index, vital)
        End If
    End Sub

    Friend Sub SkillNpc_Effect(vital As Byte, increment As Boolean, index As Integer, damage As Integer, skillnum As Integer, mapNum As Integer)
        Dim sSymbol As String
        Dim color As Integer

        If index <= 0 OrElse index > MAX_MAP_NPCS OrElse damage < 0 OrElse MapNpc(mapNum).Npc(index).Vital(vital) <= 0 Then Exit Sub

        If damage > 0 Then
            If increment Then
                sSymbol = "+"
                If vital = VitalType.HP Then color = ColorType.BrightGreen
                If vital = VitalType.MP Then color = ColorType.BrightBlue
            Else
                sSymbol = "-"
                color = ColorType.BrightRed
            End If

            ' Lidar com efeitos estuporizantes e de recauchute.
            If Skill(skillnum).KnockBack = 1 Then KnockBackNpc(index, index, skillnum)
            If Skill(skillnum).StunDuration > 0 Then StunNPC(index, mapNum, skillnum)

            SendActionMsg(mapNum, sSymbol & damage, color, ActionMsgType.Scroll, MapNpc(mapNum).Npc(index).X * 32, MapNpc(mapNum).Npc(index).Y * 32)
            If increment Then MapNpc(mapNum).Npc(index).Vital(vital) = MapNpc(mapNum).Npc(index).Vital(vital) + damage
            If Not increment Then MapNpc(mapNum).Npc(index).Vital(vital) = MapNpc(mapNum).Npc(index).Vital(vital) - damage
            SendMapNpcVitals(mapNum, index)
        End If
    End Sub

End Module