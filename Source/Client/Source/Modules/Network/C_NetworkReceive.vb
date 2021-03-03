Imports ASFW
Imports ASFW.IO

Module C_NetworkReceive

    Sub PacketRouter()
        Socket.PacketId(ServerPackets.SAlertMsg) = AddressOf Packet_AlertMSG
        Socket.PacketId(ServerPackets.SKeyPair) = AddressOf Packet_KeyPair
        Socket.PacketId(ServerPackets.SLoadCharOk) = AddressOf Packet_LoadCharOk
        Socket.PacketId(ServerPackets.SLoginOk) = AddressOf Packet_LoginOk
        Socket.PacketId(ServerPackets.SNewCharClasses) = AddressOf Packet_NewCharClasses
        Socket.PacketId(ServerPackets.SClassesData) = AddressOf Packet_ClassesData
        Socket.PacketId(ServerPackets.SInGame) = AddressOf Packet_InGame
        Socket.PacketId(ServerPackets.SPlayerInv) = AddressOf Packet_PlayerInv
        Socket.PacketId(ServerPackets.SPlayerInvUpdate) = AddressOf Packet_PlayerInvUpdate
        Socket.PacketId(ServerPackets.SPlayerWornEq) = AddressOf Packet_PlayerWornEquipment
        Socket.PacketId(ServerPackets.SPlayerHp) = AddressOf Packet_PlayerHP
        Socket.PacketId(ServerPackets.SPlayerMp) = AddressOf Packet_PlayerMP
        Socket.PacketId(ServerPackets.SPlayerSp) = AddressOf Packet_PlayerSP
        Socket.PacketId(ServerPackets.SPlayerStats) = AddressOf Packet_PlayerStats
        Socket.PacketId(ServerPackets.SPlayerData) = AddressOf Packet_PlayerData
        Socket.PacketId(ServerPackets.SPlayerMove) = AddressOf Packet_PlayerMove
        Socket.PacketId(ServerPackets.SNpcMove) = AddressOf Packet_NpcMove
        Socket.PacketId(ServerPackets.SPlayerDir) = AddressOf Packet_PlayerDir
        Socket.PacketId(ServerPackets.SNpcDir) = AddressOf Packet_NpcDir
        Socket.PacketId(ServerPackets.SPlayerXY) = AddressOf Packet_PlayerXY
        Socket.PacketId(ServerPackets.SAttack) = AddressOf Packet_Attack
        Socket.PacketId(ServerPackets.SNpcAttack) = AddressOf Packet_NpcAttack
        Socket.PacketId(ServerPackets.SCheckForMap) = AddressOf Packet_CheckMap
        Socket.PacketId(ServerPackets.SMapData) = AddressOf Packet_MapData
        Socket.PacketId(ServerPackets.SMapNpcData) = AddressOf Packet_MapNPCData
        Socket.PacketId(ServerPackets.SMapNpcUpdate) = AddressOf Packet_MapNPCUpdate
        Socket.PacketId(ServerPackets.SMapDone) = AddressOf Packet_MapDone
        Socket.PacketId(ServerPackets.SGlobalMsg) = AddressOf Packet_GlobalMessage
        Socket.PacketId(ServerPackets.SPlayerMsg) = AddressOf Packet_PlayerMessage
        Socket.PacketId(ServerPackets.SMapMsg) = AddressOf Packet_MapMessage
        Socket.PacketId(ServerPackets.SSpawnItem) = AddressOf Packet_SpawnItem
        Socket.PacketId(ServerPackets.SUpdateItem) = AddressOf Packet_UpdateItem
        Socket.PacketId(ServerPackets.SSpawnNpc) = AddressOf Packet_SpawnNPC
        Socket.PacketId(ServerPackets.SNpcDead) = AddressOf Packet_NpcDead
        Socket.PacketId(ServerPackets.SUpdateNpc) = AddressOf Packet_UpdateNPC
        Socket.PacketId(ServerPackets.SMapKey) = AddressOf Packet_MapKey
        Socket.PacketId(ServerPackets.SEditMap) = AddressOf Packet_EditMap
        Socket.PacketId(ServerPackets.SUpdateShop) = AddressOf Packet_UpdateShop
        Socket.PacketId(ServerPackets.SUpdateSkill) = AddressOf Packet_UpdateSkill
        Socket.PacketId(ServerPackets.SSkills) = AddressOf Packet_Skills
        Socket.PacketId(ServerPackets.SLeftMap) = AddressOf Packet_LeftMap
        Socket.PacketId(ServerPackets.SResourceCache) = AddressOf Packet_ResourceCache
        Socket.PacketId(ServerPackets.SUpdateResource) = AddressOf Packet_UpdateResource
        Socket.PacketId(ServerPackets.SSendPing) = AddressOf Packet_Ping
        Socket.PacketId(ServerPackets.SDoorAnimation) = AddressOf Packet_DoorAnimation
        Socket.PacketId(ServerPackets.SActionMsg) = AddressOf Packet_ActionMessage
        Socket.PacketId(ServerPackets.SPlayerEXP) = AddressOf Packet_PlayerExp
        Socket.PacketId(ServerPackets.SBlood) = AddressOf Packet_Blood
        Socket.PacketId(ServerPackets.SUpdateAnimation) = AddressOf Packet_UpdateAnimation
        Socket.PacketId(ServerPackets.SAnimation) = AddressOf Packet_Animation
        Socket.PacketId(ServerPackets.SMapNpcVitals) = AddressOf Packet_NPCVitals
        Socket.PacketId(ServerPackets.SCooldown) = AddressOf Packet_Cooldown
        Socket.PacketId(ServerPackets.SClearSkillBuffer) = AddressOf Packet_ClearSkillBuffer
        Socket.PacketId(ServerPackets.SSayMsg) = AddressOf Packet_SayMessage
        Socket.PacketId(ServerPackets.SOpenShop) = AddressOf Packet_OpenShop
        Socket.PacketId(ServerPackets.SResetShopAction) = AddressOf Packet_ResetShopAction
        Socket.PacketId(ServerPackets.SStunned) = AddressOf Packet_Stunned
        Socket.PacketId(ServerPackets.SMapWornEq) = AddressOf Packet_MapWornEquipment
        Socket.PacketId(ServerPackets.SBank) = AddressOf Packet_OpenBank
        Socket.PacketId(ServerPackets.SLeftGame) = AddressOf Packet_LeftGame

        Socket.PacketId(ServerPackets.SClearTradeTimer) = AddressOf Packet_ClearTradeTimer
        Socket.PacketId(ServerPackets.STradeInvite) = AddressOf Packet_TradeInvite
        Socket.PacketId(ServerPackets.STrade) = AddressOf Packet_Trade
        Socket.PacketId(ServerPackets.SCloseTrade) = AddressOf Packet_CloseTrade
        Socket.PacketId(ServerPackets.STradeUpdate) = AddressOf Packet_TradeUpdate
        Socket.PacketId(ServerPackets.STradeStatus) = AddressOf Packet_TradeStatus

        Socket.PacketId(ServerPackets.SGameData) = AddressOf Packet_GameData
        Socket.PacketId(ServerPackets.SMapReport) = AddressOf Packet_Mapreport 'Mapreport
        Socket.PacketId(ServerPackets.STarget) = AddressOf Packet_Target

        Socket.PacketId(ServerPackets.SAdmin) = AddressOf Packet_Admin
        Socket.PacketId(ServerPackets.SMapNames) = AddressOf Packet_MapNames

        Socket.PacketId(ServerPackets.SCritical) = AddressOf Packet_Critical
        Socket.PacketId(ServerPackets.SNews) = AddressOf Packet_News
        Socket.PacketId(ServerPackets.SrClick) = AddressOf Packet_RClick
        Socket.PacketId(ServerPackets.STotalOnline) = AddressOf Packet_TotalOnline

        'quests
        Socket.PacketId(ServerPackets.SUpdateQuest) = AddressOf Packet_UpdateQuest
        Socket.PacketId(ServerPackets.SPlayerQuest) = AddressOf Packet_PlayerQuest
        Socket.PacketId(ServerPackets.SPlayerQuests) = AddressOf Packet_PlayerQuests
        Socket.PacketId(ServerPackets.SQuestMessage) = AddressOf Packet_QuestMessage

        'Moradia
        Socket.PacketId(ServerPackets.SHouseConfigs) = AddressOf Packet_HouseConfigurations
        Socket.PacketId(ServerPackets.SBuyHouse) = AddressOf Packet_HouseOffer
        Socket.PacketId(ServerPackets.SVisit) = AddressOf Packet_Visit
        Socket.PacketId(ServerPackets.SFurniture) = AddressOf Packet_Furniture

        'hotbar
        Socket.PacketId(ServerPackets.SHotbar) = AddressOf Packet_Hotbar

        'Eventos
        Socket.PacketId(ServerPackets.SSpawnEvent) = AddressOf Packet_SpawnEvent
        Socket.PacketId(ServerPackets.SEventMove) = AddressOf Packet_EventMove
        Socket.PacketId(ServerPackets.SEventDir) = AddressOf Packet_EventDir
        Socket.PacketId(ServerPackets.SEventChat) = AddressOf Packet_EventChat
        Socket.PacketId(ServerPackets.SEventStart) = AddressOf Packet_EventStart
        Socket.PacketId(ServerPackets.SEventEnd) = AddressOf Packet_EventEnd
        Socket.PacketId(ServerPackets.SPlayBGM) = AddressOf Packet_PlayBGM
        Socket.PacketId(ServerPackets.SPlaySound) = AddressOf Packet_PlaySound
        Socket.PacketId(ServerPackets.SFadeoutBGM) = AddressOf Packet_FadeOutBGM
        Socket.PacketId(ServerPackets.SStopSound) = AddressOf Packet_StopSound
        Socket.PacketId(ServerPackets.SSwitchesAndVariables) = AddressOf Packet_SwitchesAndVariables
        Socket.PacketId(ServerPackets.SMapEventData) = AddressOf Packet_MapEventData
        Socket.PacketId(ServerPackets.SChatBubble) = AddressOf Packet_ChatBubble
        Socket.PacketId(ServerPackets.SSpecialEffect) = AddressOf Packet_SpecialEffect
        'SPic
        Socket.PacketId(ServerPackets.SHoldPlayer) = AddressOf Packet_HoldPlayer

        Socket.PacketId(ServerPackets.SUpdateProjectile) = AddressOf HandleUpdateProjectile
        Socket.PacketId(ServerPackets.SMapProjectile) = AddressOf HandleMapProjectile

        'Artesanato
        Socket.PacketId(ServerPackets.SUpdateRecipe) = AddressOf Packet_UpdateRecipe
        Socket.PacketId(ServerPackets.SSendPlayerRecipe) = AddressOf Packet_SendPlayerRecipe
        Socket.PacketId(ServerPackets.SOpenCraft) = AddressOf Packet_OpenCraft
        Socket.PacketId(ServerPackets.SUpdateCraft) = AddressOf Packet_UpdateCraft

        'Emotes
        Socket.PacketId(ServerPackets.SEmote) = AddressOf Packet_Emote

        'Equipe
        Socket.PacketId(ServerPackets.SPartyInvite) = AddressOf Packet_PartyInvite
        Socket.PacketId(ServerPackets.SPartyUpdate) = AddressOf Packet_PartyUpdate
        Socket.PacketId(ServerPackets.SPartyVitals) = AddressOf Packet_PartyVitals

        'pets
        Socket.PacketId(ServerPackets.SUpdatePet) = AddressOf Packet_UpdatePet
        Socket.PacketId(ServerPackets.SUpdatePlayerPet) = AddressOf Packet_UpdatePlayerPet
        Socket.PacketId(ServerPackets.SPetMove) = AddressOf Packet_PetMove
        Socket.PacketId(ServerPackets.SPetDir) = AddressOf Packet_PetDir
        Socket.PacketId(ServerPackets.SPetVital) = AddressOf Packet_PetVital
        Socket.PacketId(ServerPackets.SClearPetSkillBuffer) = AddressOf Packet_ClearPetSkillBuffer
        Socket.PacketId(ServerPackets.SPetAttack) = AddressOf Packet_PetAttack
        Socket.PacketId(ServerPackets.SPetXY) = AddressOf Packet_PetXY
        Socket.PacketId(ServerPackets.SPetExp) = AddressOf Packet_PetExperience

        Socket.PacketId(ServerPackets.SClock) = AddressOf Packet_Clock
        Socket.PacketId(ServerPackets.STime) = AddressOf Packet_Time

        ' APENAS PACKETS DO EDITOR
        Socket.PacketId(ServerPackets.SItemEditor) = AddressOf Packet_EditItem
        Socket.PacketId(ServerPackets.SREditor) = AddressOf Packet_ResourceEditor
        Socket.PacketId(ServerPackets.SNpcEditor) = AddressOf Packet_NPCEditor
        Socket.PacketId(ServerPackets.SShopEditor) = AddressOf Packet_EditShop
        Socket.PacketId(ServerPackets.SSkillEditor) = AddressOf Packet_EditSkill
        Socket.PacketId(ServerPackets.SResourceEditor) = AddressOf Packet_ResourceEditor
        Socket.PacketId(ServerPackets.SAnimationEditor) = AddressOf Packet_EditAnimation
        Socket.PacketId(ServerPackets.SQuestEditor) = AddressOf Packet_QuestEditor
        Socket.PacketId(ServerPackets.SHouseEdit) = AddressOf Packet_EditHouses
        Socket.PacketId(ServerPackets.SProjectileEditor) = AddressOf HandleProjectileEditor
        Socket.PacketId(ServerPackets.SRecipeEditor) = AddressOf Packet_RecipeEditor
        Socket.PacketId(ServerPackets.SClassEditor) = AddressOf Packet_ClassEditor
        Socket.PacketId(ServerPackets.SAutoMapper) = AddressOf Packet_AutoMapper
        Socket.PacketId(ServerPackets.SPetEditor) = AddressOf Packet_PetEditor
    End Sub

    Private Sub Packet_AlertMSG(ByRef data() As Byte)
        Dim msg As String
        Dim disconnect As Boolean
        Dim buffer As New ByteStream(data)
        Pnlloadvisible = False

        If FrmMenu.Visible = False Then
            Frmmenuvisible = True
            Frmmaingamevisible = False
        End If

        PnlCharCreateVisible = False
        PnlLoginVisible = False
        PnlRegisterVisible = False
        PnlCharSelectVisible = False

        msg = buffer.ReadString()
        disconnect = buffer.ReadBoolean()

        buffer.Dispose()

        MsgBox(msg, vbOKOnly, Settings.GameName)
        If disconnect Then DestroyGame()
    End Sub

    Private Sub Packet_KeyPair(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        EKeyPair.ImportKeyString(buffer.ReadString())
        buffer.Dispose()
    End Sub

    Private Sub Packet_LoadCharOk(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        ' Agora podemos receber dados do jogo 
        Myindex = buffer.ReadInt32

        buffer.Dispose()

        Pnlloadvisible = True
        SetStatus(Language.Game.DataReceive)
    End Sub

    Private Sub Packet_LoginOk(ByRef data() As Byte)
        Dim charName As String, sprite As Integer
        Dim level As Integer, className As String, gender As Byte

        ' Salvar opções
        Settings.SavePass = ChkSavePassChecked
        Settings.Username = Trim$(TempUserName)

        If ChkSavePassChecked = False Then
            Settings.Password = ""
        Else
            Settings.Password = Trim$(TempPassword)
        End If

        SaveSettings()

        ' Pedir classes.
        SendRequestClasses()

        Dim buffer As New ByteStream(data)
        ' Agora podemos receber dados dos personagens
        MaxChars = buffer.ReadInt32
        ReDim CharSelection(MaxChars)

        SelectedChar = 1

        'Resetar para deletar personagens
        For i = 1 To MaxChars
            CharSelection(i).Name = ""
            CharSelection(i).Sprite = 0
            CharSelection(i).Level = 0
            CharSelection(i).ClassName = ""
            CharSelection(i).Gender = 0
        Next

        For i = 1 To MaxChars
            charName = buffer.ReadString
            sprite = buffer.ReadInt32
            level = buffer.ReadInt32
            className = buffer.ReadString
            gender = buffer.ReadInt32

            CharSelection(i).Name = charName
            CharSelection(i).Sprite = sprite
            CharSelection(i).Level = level
            CharSelection(i).ClassName = className
            CharSelection(i).Gender = gender
        Next

        buffer.Dispose()

        ' Usado caso o jogador esteja criando um novo personagem
        Frmmenuvisible = True
        Pnlloadvisible = False
        PnlCreditsVisible = False
        PnlRegisterVisible = False
        PnlCharCreateVisible = False
        PnlLoginVisible = False

        PnlCharSelectVisible = True

        FrmMenu.DrawCharacter()

        DrawCharSelect = True

    End Sub



    Private Sub Packet_InGame(ByRef data() As Byte)
        InGame = True
        CanMoveNow = True
        GameInit()
    End Sub

    Private Sub Packet_PlayerInv(ByRef data() As Byte)
        Dim i As Integer, invNum As Integer, amount As Integer
        Dim buffer As New ByteStream(data)
        For i = 1 To MAX_INV
            invNum = buffer.ReadInt32
            amount = buffer.ReadInt32
            SetPlayerInvItemNum(Myindex, i, invNum)
            SetPlayerInvItemValue(Myindex, i, amount)

            Player(Myindex).RandInv(i).Prefix = buffer.ReadString
            Player(Myindex).RandInv(i).Suffix = buffer.ReadString
            Player(Myindex).RandInv(i).Rarity = buffer.ReadInt32
            For n = 1 To StatType.Count - 1
                Player(Myindex).RandInv(i).Stat(n) = buffer.ReadInt32
            Next
            Player(Myindex).RandInv(i).Damage = buffer.ReadInt32
            Player(Myindex).RandInv(i).Speed = buffer.ReadInt32
        Next

        ' Muda para o inventário, precisa limpar qualquer outro drop menu
        FrmGame.pnlCurrency.Visible = False
        FrmGame.txtCurrency.Text = ""
        TmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear

        buffer.Dispose()
    End Sub

    Private Sub Packet_PlayerInvUpdate(ByRef data() As Byte)
        Dim n As Integer, i As Integer
        Dim buffer As New ByteStream(data)
        n = buffer.ReadInt32
        SetPlayerInvItemNum(Myindex, n, buffer.ReadInt32)
        SetPlayerInvItemValue(Myindex, n, buffer.ReadInt32)

        Player(Myindex).RandInv(n).Prefix = buffer.ReadString
        Player(Myindex).RandInv(n).Suffix = buffer.ReadString
        Player(Myindex).RandInv(n).Rarity = buffer.ReadInt32
        For i = 1 To StatType.Count - 1
            Player(Myindex).RandInv(n).Stat(i) = buffer.ReadInt32
        Next
        Player(Myindex).RandInv(n).Damage = buffer.ReadInt32
        Player(Myindex).RandInv(n).Speed = buffer.ReadInt32

        ' Mudanças, limpar qualquer drop menu
        FrmGame.pnlCurrency.Visible = False
        FrmGame.txtCurrency.Text = ""
        TmpCurrencyItem = 0
        CurrencyMenu = 0 ' limpeza

        buffer.Dispose()
    End Sub

    Private Sub Packet_PlayerWornEquipment(ByRef data() As Byte)
        Dim i As Integer, n As Integer
        Dim buffer As New ByteStream(data)
        For i = 1 To EquipmentType.Count - 1
            SetPlayerEquipment(Myindex, buffer.ReadInt32, i)
        Next

        For i = 1 To EquipmentType.Count - 1
            Player(Myindex).RandEquip(i).Prefix = buffer.ReadString
            Player(Myindex).RandEquip(i).Suffix = buffer.ReadString
            Player(Myindex).RandEquip(i).Damage = buffer.ReadInt32
            Player(Myindex).RandEquip(i).Speed = buffer.ReadInt32
            Player(Myindex).RandEquip(i).Rarity = buffer.ReadInt32

            For n = 1 To StatType.Count - 1
                Player(Myindex).RandEquip(i).Stat(n) = buffer.ReadInt32
            Next
        Next

        ' mudanças no inventário, limpar qualquer drop menu

        FrmGame.pnlCurrency.Visible = False
        FrmGame.txtCurrency.Text = ""
        TmpCurrencyItem = 0
        CurrencyMenu = 0 ' limpeza

        buffer.Dispose()
    End Sub

    Private Sub Packet_NpcMove(ByRef data() As Byte)
        Dim mapNpcNum As Integer, movement As Integer
        Dim x As Integer, y As Integer, dir As Integer
        Dim buffer As New ByteStream(data)
        mapNpcNum = buffer.ReadInt32
        x = buffer.ReadInt32
        y = buffer.ReadInt32
        dir = buffer.ReadInt32
        movement = buffer.ReadInt32

        With MapNpc(mapNpcNum)
            .X = x
            .Y = y
            .Dir = dir
            .XOffset = 0
            .YOffset = 0
            .Moving = movement

            Select Case .Dir
                Case DirectionType.Up
                    .YOffset = PicY
                Case DirectionType.Down
                    .YOffset = PicY * -1
                Case DirectionType.Left
                    .XOffset = PicX
                Case DirectionType.Right
                    .XOffset = PicX * -1
            End Select
        End With

        buffer.Dispose()
    End Sub

    Private Sub Packet_NpcDir(ByRef data() As Byte)
        Dim dir As Integer, i As Integer
        Dim buffer As New ByteStream(data)
        i = buffer.ReadInt32
        dir = buffer.ReadInt32

        With MapNpc(i)
            .Dir = dir
            .XOffset = 0
            .YOffset = 0
            .Moving = 0
        End With

        buffer.Dispose()
    End Sub

    Private Sub Packet_Attack(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)
        i = buffer.ReadInt32

        ' Colocar jogador para atacar
        Player(i).Attacking = 1
        Player(i).AttackTimer = GetTickCount()

        buffer.Dispose()
    End Sub

    Private Sub Packet_NpcAttack(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)
        i = buffer.ReadInt32

        ' Colocar NPC para atacar
        MapNpc(i).Attacking = 1
        MapNpc(i).AttackTimer = GetTickCount()

        buffer.Dispose()
    End Sub

    Private Sub Packet_GlobalMessage(ByRef data() As Byte)
        Dim msg As String
        Dim buffer As New ByteStream(data)

        msg = Trim(buffer.ReadString)

        buffer.Dispose()

        AddText(msg, QColorType.GlobalColor)
    End Sub

    Private Sub Packet_MapMessage(ByRef data() As Byte)
        Dim msg As String
        Dim buffer As New ByteStream(data)

        msg = Trim(buffer.ReadString)

        buffer.Dispose()

        AddText(msg, QColorType.BroadcastColor)

    End Sub

    Private Sub Packet_SpawnItem(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)

        i = buffer.ReadInt32

        With MapItem(i)
            .Num = buffer.ReadInt32
            .Value = buffer.ReadInt32
            .X = buffer.ReadInt32
            .Y = buffer.ReadInt32
        End With

        buffer.Dispose()
    End Sub

    Private Sub Packet_PlayerMessage(ByRef data() As Byte)
        Dim msg As String, colour As Integer
        Dim buffer As New ByteStream(data)

        msg = Trim(buffer.ReadString)

        colour = buffer.ReadInt32

        buffer.Dispose()

        AddText(msg, colour)
    End Sub

    Private Sub Packet_SpawnNPC(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)
        i = buffer.ReadInt32

        With MapNpc(i)
            .Num = buffer.ReadInt32
            .X = buffer.ReadInt32
            .Y = buffer.ReadInt32
            .Dir = buffer.ReadInt32

            For i = 1 To VitalType.Count - 1
                .Vital(i) = buffer.ReadInt32
            Next
            ' Uso do cliente apenas
            .XOffset = 0
            .YOffset = 0
            .Moving = 0
        End With

        buffer.Dispose()
    End Sub

    Private Sub Packet_NpcDead(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)
        i = buffer.ReadInt32
        ClearMapNpc(i)

        buffer.Dispose()
    End Sub

    Private Sub Packet_UpdateNPC(ByRef data() As Byte)
        Dim i As Integer ', x As Integer
        Dim buffer As New ByteStream(data)
        i = buffer.ReadInt32

        Npc(i) = DeserializeData(buffer)

        If Npc(i).AttackSay Is Nothing Then Npc(i).AttackSay = ""
        If Npc(i).Name Is Nothing Then Npc(i).Name = ""

        buffer.Dispose()
    End Sub

    Private Sub Packet_MapKey(ByRef data() As Byte)
        Dim n As Integer, x As Integer, y As Integer
        Dim buffer As New ByteStream(data)
        x = buffer.ReadInt32
        y = buffer.ReadInt32
        n = buffer.ReadInt32
        TempTile(x, y).DoorOpen = n

        buffer.Dispose()
    End Sub

    Private Sub Packet_UpdateSkill(ByRef data() As Byte)
        Dim skillnum As Integer
        Dim buffer As New ByteStream(data)
        skillnum = buffer.ReadInt32

        Skill(skillnum) = DeserializeData(buffer)

        If Skill(skillnum).Name Is Nothing Then Skill(skillnum).Name = ""

        buffer.Dispose()

    End Sub

    Private Sub Packet_Skills(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)
        For i = 1 To MAX_PLAYER_SKILLS
            PlayerSkills(i) = buffer.ReadInt32
        Next

        buffer.Dispose()
    End Sub

    Private Sub Packet_LeftMap(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        ClearPlayer(buffer.ReadInt32)

        buffer.Dispose()
    End Sub

    Private Sub Packet_Ping(ByRef data() As Byte)
        PingEnd = GetTickCount()
        Ping = PingEnd - PingStart
    End Sub

    Private Sub Packet_DoorAnimation(ByRef data() As Byte)
        Dim x As Integer, y As Integer
        Dim buffer As New ByteStream(data)
        x = buffer.ReadInt32
        y = buffer.ReadInt32
        With TempTile(x, y)
            .DoorFrame = 1
            .DoorAnimate = 1 ' 0 = nada| 1 = abrir | 2 = fechar
            .DoorTimer = GetTickCount()
        End With

        buffer.Dispose()
    End Sub

    Private Sub Packet_ActionMessage(ByRef data() As Byte)
        Dim x As Integer, y As Integer, message As String, color As Integer, tmpType As Integer
        Dim buffer As New ByteStream(data)
        message = Trim(buffer.ReadString)
        color = buffer.ReadInt32
        tmpType = buffer.ReadInt32
        x = buffer.ReadInt32
        y = buffer.ReadInt32

        buffer.Dispose()

        CreateActionMsg(message, color, tmpType, x, y)
    End Sub

    Private Sub Packet_Blood(ByRef data() As Byte)
        Dim x As Integer, y As Integer, sprite As Integer
        Dim buffer As New ByteStream(data)
        x = buffer.ReadInt32
        y = buffer.ReadInt32

        ' Aleatorizar sprite
        sprite = Rand(1, 3)

        BloodIndex = BloodIndex + 1
        If BloodIndex >= Byte.MaxValue Then BloodIndex = 1

        With Blood(BloodIndex)
            .X = x
            .Y = y
            .Sprite = sprite
            .Timer = GetTickCount()
        End With

        buffer.Dispose()
    End Sub



    Private Sub Packet_NPCVitals(ByRef data() As Byte)
        Dim mapNpcNum As Integer
        Dim buffer As New ByteStream(data)
        mapNpcNum = buffer.ReadInt32
        For i = 1 To VitalType.Count - 1
            MapNpc(mapNpcNum).Vital(i) = buffer.ReadInt32
        Next

        buffer.Dispose()
    End Sub

    Private Sub Packet_Cooldown(ByRef data() As Byte)
        Dim slot As Integer
        Dim buffer As New ByteStream(data)
        slot = buffer.ReadInt32
        SkillCd(slot) = GetTickCount()

        buffer.Dispose()
    End Sub

    Private Sub Packet_ClearSkillBuffer(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        SkillBuffer = 0
        SkillBufferTimer = 0

        buffer.Dispose()
    End Sub

    Private Sub Packet_SayMessage(ByRef data() As Byte)
        Dim access As Integer, name As String, message As String
        Dim header As String, pk As Integer
        Dim buffer As New ByteStream(data)
        name = Trim(buffer.ReadString)
        access = buffer.ReadInt32
        pk = buffer.ReadInt32
        message = Trim(buffer.ReadString)
        header = Trim(buffer.ReadString)

        AddText(header & name & ": " & message, QColorType.SayColor)

        buffer.Dispose()
    End Sub

    Private Sub Packet_Stunned(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        StunDuration = buffer.ReadInt32

        buffer.Dispose()
    End Sub

    Private Sub Packet_MapWornEquipment(ByRef data() As Byte)
        Dim playernum As Integer
        Dim buffer As New ByteStream(data)
        playernum = buffer.ReadInt32
        SetPlayerEquipment(playernum, buffer.ReadInt32, EquipmentType.Armor)
        SetPlayerEquipment(playernum, buffer.ReadInt32, EquipmentType.Weapon)
        SetPlayerEquipment(playernum, buffer.ReadInt32, EquipmentType.Helmet)
        SetPlayerEquipment(playernum, buffer.ReadInt32, EquipmentType.Shield)
        SetPlayerEquipment(playernum, buffer.ReadInt32, EquipmentType.Shoes)
        SetPlayerEquipment(playernum, buffer.ReadInt32, EquipmentType.Gloves)

        buffer.Dispose()
    End Sub

    Private Sub Packet_GameData(ByRef data() As Byte)
        Dim n As Integer, i As Integer, z As Integer, x As Integer ', a As Integer, b As Integer
        Dim buffer As New ByteStream(Compression.DecompressBytes(data))

        '\\\Ler dados de classe\\\

        ' Número Máximo de Classes

        For i = 0 To MAX_CLASSES
            ReDim Classes(i).Stat(StatType.Count - 1)
        Next

        For i = 0 To MAX_CLASSES
            ReDim Classes(i).Vital(VitalType.Count - 1)
        Next

        For i = 1 To MAX_CLASSES

            With Classes(i)
                .Name = Trim(buffer.ReadString)
                .Desc = Trim$(buffer.ReadString)

                .Vital(VitalType.HP) = buffer.ReadInt32
                .Vital(VitalType.MP) = buffer.ReadInt32
                .Vital(VitalType.SP) = buffer.ReadInt32

                ' Pegar tamanho do vetor
                z = buffer.ReadInt32
                ' redim no vetor
                ReDim .MaleSprite(z)
                ' Loop de receber dados
                For x = 0 To z
                    .MaleSprite(x) = buffer.ReadInt32
                Next

                ' Pegar tamanho do vetor
                z = buffer.ReadInt32
                ' redim no vetor
                ReDim .FemaleSprite(z)
                ' Loop de receber dados
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

        i = 0
        x = 0
        n = 0
        z = 0

        '\\\Fim da Leitura dos Dados de Classe\\\

        '\\\Ler Dados de Item\\\\\\\
        x = buffer.ReadInt32

        For i = 1 To x
            n = buffer.ReadInt32

            Item(n) = DeserializeData(buffer)
        Next

        ' Mudanças no inventário, tem que limpar qualquer drop menu

        FrmGame.pnlCurrency.Visible = False
        FrmGame.txtCurrency.Text = ""
        TmpCurrencyItem = 0
        CurrencyMenu = 0 ' limpeza

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\Fim da Leitura dos Dados de Itens\\\\\\\

        '\\\Leitura dos dados de animação\\\\\\\
        x = buffer.ReadInt32

        For i = 1 To x
            n = buffer.ReadInt32

            Animation(n) = DeserializeData(buffer)
        Next

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\Fim da Leitura dos Dados de Animação\\\\\\\

        '\\\Leitura dos Dados de NPC\\\\\\\
        x = buffer.ReadInt32
        For i = 1 To x
            n = buffer.ReadInt32
            Npc(n) = DeserializeData(buffer)

            If Npc(n).AttackSay Is Nothing Then Npc(n).AttackSay = ""
            If Npc(n).Name Is Nothing Then Npc(n).Name = ""
        Next

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\Fim da Leitura dos Dados de NPC\\\\\\\

        '\\\Ler Dados de Loja\\\\\\\
        x = buffer.ReadInt32

        For i = 1 To x
            n = buffer.ReadInt32

            Shop(n) = DeserializeData(buffer)

            If Shop(n).Name Is Nothing Then Shop(n).Name = ""
        Next

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\Fim da Leitura dos Dados de Loja\\\\\\\

        '\\\Ler Dados de Habilidade\\\\\\\\\\
        x = buffer.ReadInt32

        For i = 1 To x
            n = buffer.ReadInt32

            Skill(n) = DeserializeData(buffer)

            If Skill(n).Name Is Nothing Then Skill(n).Name = ""
        Next

        i = 0
        x = 0
        n = 0
        z = 0

        '\\\Fim da Leitura dos Dados de Habilidade\\\\\\\\\\

        '\\\Leitura de Dados de Recursos\\\\\\\\\\\\
        x = buffer.ReadInt32

        For i = 1 To x
            n = buffer.ReadInt32

            Resource(n) = DeserializeData(buffer)

            If Resource(n).Name Is Nothing Then Resource(n).Name = ""
            If Resource(n).EmptyMessage Is Nothing Then Resource(n).EmptyMessage = ""
            If Resource(n).SuccessMessage Is Nothing Then Resource(n).SuccessMessage = ""
        Next

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\Fim da Leitura dos Dados de Recursos\\\\\\\\\\\\

        buffer.Dispose()
    End Sub

    Private Sub Packet_Target(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        MyTarget = buffer.ReadInt32
        MyTargetType = buffer.ReadInt32

        buffer.Dispose()
    End Sub

    Private Sub Packet_Mapreport(ByRef data() As Byte)
        Dim I As Integer
        Dim buffer As New ByteStream(data)
        For I = 1 To MAX_MAPS
            MapNames(I) = Trim(buffer.ReadString())
        Next

        UpdateMapnames = True

        buffer.Dispose()
    End Sub

    Private Sub Packet_Admin(ByRef data() As Byte)
        Adminvisible = True
    End Sub

    Private Sub Packet_MapNames(ByRef data() As Byte)
        Dim I As Integer
        Dim buffer As New ByteStream(data)
        For I = 1 To MAX_MAPS
            MapNames(I) = Trim(buffer.ReadString())
        Next

        buffer.Dispose()
    End Sub



    Private Sub Packet_Critical(ByRef data() As Byte)
        ShakeTimerEnabled = True
        ShakeTimer = GetTickCount()
    End Sub

    Private Sub Packet_News(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        Settings.GameName = buffer.ReadString
        News = buffer.ReadString

        UpdateNews = True

        buffer.Dispose()
    End Sub

    Private Sub Packet_RClick(ByRef data() As Byte)
        ShowRClick = True
    End Sub

    Private Sub Packet_TotalOnline(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        TotalOnline = buffer.ReadInt32

        buffer.Dispose()
    End Sub

    Private Sub Packet_Emote(ByRef data() As Byte)
        Dim index As Integer, emote As Integer
        Dim buffer As New ByteStream(data)
        index = buffer.ReadInt32
        emote = buffer.ReadInt32

        With Player(index)
            .Emote = emote
            .EmoteTimer = GetTickCount() + 5000
        End With

        buffer.Dispose()

    End Sub

    Private Sub Packet_ChatBubble(ByRef data() As Byte)
        Dim targetType As Integer, target As Integer, message As String, colour As Integer
        Dim buffer As New ByteStream(data)

        target = buffer.ReadInt32
        targetType = buffer.ReadInt32
        message = Trim(buffer.ReadString)
        colour = buffer.ReadInt32
        AddChatBubble(target, targetType, message, colour)

        buffer.Dispose()

    End Sub

    Private Sub Packet_LeftGame(ByRef data() As Byte)
        DestroyGame()
    End Sub

    '**************************
    '***  COISAS DO EDITOR  ***
    '**************************

    Private Sub Packet_EditAnimation(ByRef data() As Byte)
        InitAnimationEditor = True
    End Sub

    Private Sub Packet_ClassEditor(ByRef data() As Byte)
        InitClassEditor = True
    End Sub

    Sub Packet_EditItem(ByRef data() As Byte)
        InitItemEditor = True
    End Sub

    Private Sub Packet_NPCEditor(ByRef data() As Byte)
        InitNPCEditor = True
    End Sub

    Private Sub Packet_ResourceEditor(ByRef data() As Byte)
        InitResourceEditor = True
    End Sub

    Friend Sub Packet_PetEditor(ByRef data() As Byte)
        InitPetEditor = True
    End Sub

    Friend Sub HandleProjectileEditor(ByRef data() As Byte)
        InitProjectileEditor = True
    End Sub

    Private Sub Packet_EditShop(ByRef data() As Byte)
        InitShopEditor = True
    End Sub

    Private Sub Packet_EditSkill(ByRef data() As Byte)
        InitSkillEditor = True
    End Sub


End Module