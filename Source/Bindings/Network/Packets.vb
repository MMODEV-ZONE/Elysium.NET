Friend Module Packets

    ' Packets enviadas do cliente ao servidor
    Friend Enum ClientPackets
        CNewAccount = 1
        CDelAccount
        CLogin
        CAddChar
        CUseChar
        CDelChar
        CSayMsg
        CBroadcastMsg
        CPlayerMsg
        CPlayerMove
        CPlayerDir
        CUseItem
        CAttack
        CPlayerInfoRequest
        CWarpMeTo
        CWarpToMe
        CWarpTo
        CSetSprite
        CGetStats
        CRequestNewMap
        CNeedMap
        CMapGetItem
        CMapDropItem
        CKickPlayer
        CBanList
        CBanDestroy
        CBanPlayer
        CRequestEditMap
        CSetAccess
        CWhosOnline
        CSetMotd
        CSearch
        CSkills
        CCast
        CQuit
        CSwapInvSlots
        CCheckPing
        CUnequip
        CRequestPlayerData
        CRequestItems
        CRequestNPCS
        CRequestResources
        CSpawnItem
        CTrainStat
        CRequestAnimations
        CRequestSkills
        CRequestShops
        CRequestLevelUp
        CForgetSkill
        CCloseShop
        CBuyItem
        CSellItem
        CChangeBankSlots
        CDepositItem
        CWithdrawItem
        CCloseBank
        CAdminWarp
        CTradeInvite
        CTradeInviteAccept
        CAcceptTrade
        CDeclineTrade
        CTradeItem
        CUntradeItem
        CAdmin

        'tarefas
        CRequestQuests
        CQuestLogUpdate
        CPlayerHandleQuest
        CQuestReset

        'moradias
        CBuyHouse
        CVisit
        CAcceptVisit
        CPlaceFurniture

        CSellHouse

        'Hotbar
        CSetHotbarSlot
        CDeleteHotbarSlot
        CUseHotbarSlot

        'Eventos
        CEventChatReply
        CEvent
        CSwitchesAndVariables
        CRequestSwitchesAndVariables

        CRequestProjectiles
        CClearProjectile

        CRequestRecipes

        CCloseCraft
        CStartCraft

        CRequestClasses

        'emotes
        CEmote

        'equipes
        CRequestParty
        CAcceptParty
        CDeclineParty
        CLeaveParty
        CPartyChatMsg

        'pets
        CRequestPets
        CSummonPet
        CPetMove
        CSetBehaviour
        CReleasePet
        CPetSkill
        CPetUseStatPoint

        '*******************************
        '***   PACKETS DOS EDITORES  ***
        '*******************************

        ' Packets do Mapper
        CMapRespawn
        CMapReport
        CSaveMap

        ' Packets do AutoMapper
        CRequestAutoMap
        CSaveAutoMap

        ' ####################
        ' ### Dev+ Packets ###
        ' ####################

        'animações
        CRequestEditAnimation
        CSaveAnimation

        'editor de classes
        CRequestEditClasses
        CSaveClasses

        'moradias
        CRequestEditHouse
        CSaveHouses

        'itens
        CRequestEditItem
        CSaveItem

        'npcs
        CRequestEditNpc
        CSaveNpc

        'pets
        CRequestEditPet
        CSavePet

        'projeteis
        CRequestEditProjectiles
        CSaveProjectile

        'tarefas
        CRequestEditQuest
        CSaveQuest

        'receitas
        CRequestEditRecipes
        CSaveRecipe

        'recursos
        CRequestEditResource
        CSaveResource

        'lojas
        CRequestEditShop
        CSaveShop

        'habilidades
        CRequestEditSkill
        CSaveSkill

        ' Ter certeza que Count está abaixo de tudo
        Count
    End Enum

    ' Packets enviadas do servidor ao clinete
    Friend Enum ServerPackets
        SAlertMsg = 1
        SKeyPair
        SLoadCharOk
        SLoginOk
        SNewCharClasses
        SClassesData
        SInGame
        SPlayerInv
        SPlayerInvUpdate
        SPlayerWornEq
        SPlayerHp
        SPlayerMp
        SPlayerSp
        SPlayerStats
        SPlayerData
        SPlayerMove
        SNpcMove
        SPlayerDir
        SNpcDir
        SPlayerXY
        SAttack
        SNpcAttack
        SCheckForMap
        SMapData
        SMapItemData
        SMapNpcData
        SMapNpcUpdate
        SMapDone
        SGlobalMsg
        SAdminMsg
        SPlayerMsg
        SMapMsg
        SSpawnItem
        SItemEditor
        SUpdateItem
        SREditor
        SSpawnNpc
        SNpcDead
        SNpcEditor
        SUpdateNpc
        SMapKey
        SEditMap
        SShopEditor
        SUpdateShop
        SSkillEditor
        SUpdateSkill
        SSkills
        SLeftMap
        SResourceCache
        SResourceEditor
        SUpdateResource
        SSendPing
        SDoorAnimation
        SActionMsg
        SPlayerEXP
        SBlood
        SAnimationEditor
        SUpdateAnimation
        SAnimation
        SMapNpcVitals
        SCooldown
        SClearSkillBuffer
        SSayMsg
        SOpenShop
        SResetShopAction
        SStunned
        SMapWornEq
        SBank
        SLeftGame

        SClearTradeTimer
        STradeInvite
        STrade
        SCloseTrade
        STradeUpdate
        STradeStatus

        SGameData
        SMapReport
        STarget
        SAdmin
        SMapNames
        SCritical
        SNews
        SrClick
        STotalOnline

        'tarefas
        SQuestEditor
        SUpdateQuest
        SPlayerQuest
        SPlayerQuests
        SQuestMessage

        'moradia
        SBuyHouse
        SVisit
        SFurniture
        SHouseEdit
        SHouseConfigs

        'hotbar
        SHotbar

        'Eventos
        SSpawnEvent
        SEventMove
        SEventDir
        SEventChat
        SEventStart
        SEventEnd
        SPlayBGM
        SPlaySound
        SFadeoutBGM
        SStopSound
        SSwitchesAndVariables
        SMapEventData
        SChatBubble
        SSpecialEffect
        SPic
        SHoldPlayer

        SProjectileEditor
        SUpdateProjectile
        SMapProjectile

        'receitas
        SUpdateRecipe
        SRecipeEditor
        SSendPlayerRecipe
        SOpenCraft
        SUpdateCraft

        'editor de classes
        SClassEditor
        SUpdateClasses

        'AutoMapper
        SAutoMapper

        'emotes
        SEmote

        'equipes
        SPartyInvite
        SPartyUpdate
        SPartyVitals

        'pets
        SPetEditor
        SUpdatePet
        SUpdatePlayerPet
        SPetMove
        SPetDir
        SPetVital
        SClearPetSkillBuffer
        SPetAttack
        SPetXY
        SPetExp

        STime
        SClock

        ' Tenha certeza que COUNT está abaixo de tudo
        COUNT
    End Enum

End Module