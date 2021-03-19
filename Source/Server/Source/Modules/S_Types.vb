﻿Module modTypes2

    ' Estrutura de Dados de Amigos
    Friend Map(MAX_CACHED_MAPS) As MapRec

    Friend TempTile(MAX_CACHED_MAPS) As TempTileRec
    Friend PlayersOnMap(MAX_CACHED_MAPS) As Integer
    Friend MapItem(MAX_CACHED_MAPS, MAX_MAP_ITEMS) As MapItemRec
    Friend MapNpc(MAX_CACHED_MAPS) As MapDataRec
    Friend Bank(MAX_PLAYERS) As BankStruct
    Friend TempPlayer(MAX_PLAYERS) As TempPlayerRec
    Friend Player(MAX_PLAYERS) As PlayerRec

    <Serializable>
    Friend Structure PlayerRec

        ' Conta
        Dim Login As String

        Dim Password As String
        Dim Access As Byte

        ' Multi-personagens
        Dim Character() As CharacterRec

    End Structure

    <Serializable>
    Friend Structure CharacterRec

        ' Geral
        Dim Name As String

        Dim Sex As Byte
        Dim Classes As Byte
        Dim Sprite As Integer
        Dim Level As Byte
        Dim Exp As Integer

        Dim Pk As Byte

        ' Vitalidade
        Dim Vital() As Integer

        ' Atributos
        Dim Stat() As Byte

        Dim Points As Byte

        ' Equipamento usado
        Dim Equipment() As PlayerInvStruct

        ' Inventário
        Dim Inv() As PlayerInvStruct

        Dim Skill() As Integer

        ' Posição
        Dim Map As Integer

        Dim X As Byte
        Dim Y As Byte
        Dim Dir As Byte

        Dim PlayerQuest() As PlayerQuestRec

        'Casa
        Dim House As PlayerHouseRec

        Dim InHouse As Integer
        Dim LastMap As Integer
        Dim LastX As Integer
        Dim LastY As Integer

        'Hotbar
        Dim Hotbar() As HotbarRec

        'Evento
        Dim Switches() As Byte

        Dim Variables() As Integer

        'Habilidades
        Dim GatherSkills() As ResourceSkillsStruct

        Dim RecipeLearned() As Byte

        Dim Pet As PlayerPetRec
    End Structure

    Friend Structure TempPlayerRec

        ' Variáveis locais não salvas
        Dim InGame As Boolean

        Dim AttackTimer As Integer
        Dim DataTimer As Integer
        Dim DataBytes As Integer
        Dim DataPackets As Integer
        Dim PartyInvite As Integer
        Dim InParty As Byte
        Dim TargetType As Byte
        Dim Target As Integer
        Dim PartyStarter As Byte
        Dim GettingMap As Byte
        Dim SkillBuffer As Integer
        Dim SkillBufferTimer As Integer
        Dim SkillCd() As Integer
        Dim InShop As Integer
        Dim StunTimer As Integer
        Dim StunDuration As Integer
        Dim InBank As Boolean

        ' Troca
        Dim TradeRequest As Integer

        Dim InTrade As Integer
        Dim TradeOffer() As PlayerInvStruct
        Dim AcceptTrade As Boolean

        'Casa
        Dim BuyHouseindex As Integer

        Dim Invitationindex As Integer
        Dim InvitationTimer As Integer

        Dim EventMap As EventMapStruct
        Dim EventProcessingCount As Integer
        Dim EventProcessing() As EventProcessingStruct

        'Multi-personagem
        Dim CurChar As Byte

        'Crafting
        Dim IsCrafting As Boolean

        Dim CraftIt As Byte
        Dim CraftTimer As Integer
        Dim CraftTimeNeeded As Integer

        Dim CraftRecipe As Integer
        Dim CraftAmount As Integer

        Dim StopRegenTimer As Integer
        Dim StopRegen As Byte

        'instance stuff
        Dim InInstance As Byte

        Dim TmpInstanceNum As Integer
        Dim TmpMap As Integer
        Dim TmpX As Integer
        Dim TmpY As Integer

        'Pets
        Dim PetTarget As Integer

        Dim PetTargetType As Integer
        Dim PetBehavior As Integer

        Dim GoToX As Integer
        Dim GoToY As Integer

        Dim PetStunTimer As Integer
        Dim PetStunDuration As Integer
        Dim PetAttackTimer As Integer

        Dim PetSkillCd() As Integer
        Dim PetskillBuffer As SkillBufferRec

        Dim PetDoT() As DoTRec
        Dim PetHoT() As DoTRec

        ' Regeneração
        Dim PetstopRegen As Boolean

        Dim PetstopRegenTimer As Integer

    End Structure

    <Serializable>
    Friend Structure MapRec
        Dim Name As String
        Dim Music As String

        Dim Revision As Integer
        Dim Moral As Byte
        Dim Tileset As Integer

        Dim Up As Integer
        Dim Down As Integer
        Dim Left As Integer
        Dim Right As Integer

        Dim BootMap As Integer
        Dim BootX As Byte
        Dim BootY As Byte

        Dim MaxX As Byte
        Dim MaxY As Byte

        Dim Tile(,) As TileStruct

        Dim Npc() As Integer

        Dim EventCount As Integer
        Dim Events() As EventStruct

        Dim WeatherType As Byte
        Dim Fogindex As Integer
        Dim WeatherIntensity As Integer
        Dim FogAlpha As Byte
        Dim FogSpeed As Byte

        Dim HasMapTint As Byte
        Dim MapTintR As Byte
        Dim MapTintG As Byte
        Dim MapTintB As Byte
        Dim MapTintA As Byte

        Dim Instanced As Byte

        Dim Panorama As Byte
        Dim Parallax As Byte
    End Structure

    Friend Structure ClassRec
        Dim Name As String
        Dim Desc As String
        Dim Stat() As Byte
        Dim MaleSprite() As Integer
        Dim FemaleSprite() As Integer
        Dim StartItem() As Integer
        Dim StartValue() As Integer
        Dim StartMap As Integer
        Dim StartX As Byte
        Dim StartY As Byte
        Dim BaseExp As Integer
    End Structure

    Friend Structure MapItemRec
        Dim X As Byte
        Dim Y As Byte

        Dim ItemData As PlayerInvStruct

        ' ownership + despawn
        Dim PlayerName As String

        Dim PlayerTimer As Long
        Dim CanDespawn As Boolean
        Dim DespawnTimer As Long
    End Structure

    Friend Structure MapNpcRec
        Dim Num As Integer
        Dim Target As Integer
        Dim TargetType As Byte
        Dim Vital() As Integer
        Dim X As Byte
        Dim Y As Byte
        Dim Dir As Integer

        ' Para uso do servidor apenas
        Dim SpawnWait As Integer

        Dim AttackTimer As Integer
        Dim StunDuration As Integer
        Dim StunTimer As Integer
        Dim SkillBuffer As Integer
        Dim SkillBufferTimer As Integer
        Dim SkillCd() As Integer
        Dim StopRegen As Byte
        Dim StopRegenTimer As Integer
    End Structure

    Friend Structure TempTileRec
        Dim DoorOpen(,) As Byte
        Dim DoorTimer As Integer
    End Structure

    Friend Structure MapDataRec
        Dim Npc() As MapNpcRec
    End Structure

    <Serializable>
    Friend Structure HotbarRec
        Dim Slot As Integer
        Dim SlotType As Byte
    End Structure

    Friend Structure SkillBufferRec
        Dim Skill As Integer
        Dim Timer As Integer
        Dim Target As Integer
        Dim TargetTypes As Byte
    End Structure

    Friend Structure DoTRec
        Dim Used As Boolean
        Dim Skill As Integer
        Dim Timer As Integer
        Dim Caster As Integer
        Dim StartTime As Integer

        'PET
        Dim AttackerType As Integer 'Para Pets

    End Structure

End Module