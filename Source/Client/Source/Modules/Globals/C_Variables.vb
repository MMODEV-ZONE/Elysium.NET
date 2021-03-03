Imports System.Drawing

Module C_Variables

    'Criação/Seleção de Personagem
    Friend SelectedChar As Byte

    Friend MaxChars As Byte

    Friend TotalOnline As Integer

    ' Para bloqueios direcionais
    Friend DirArrowX(4) As Byte

    Friend DirArrowY(4) As Byte

    Friend LastTileset As Byte

    Friend UseFade As Boolean
    Friend FadeType As Integer
    Friend FadeAmount As Integer
    Friend FlashTimer As Integer

    ' Alvos
    Friend MyTarget As Integer
    Friend MyTargetType As Integer

    ' Bolhas de Conversas
    Friend ChatBubble(Byte.MaxValue) As ChatBubbleRec
    Friend ChatBubbleindex As Integer

    ' Drag&Drop (Arrastar e Soltar) de Habilidades
    Friend DragSkillSlotNum As Integer

    Friend SkillX As Integer
    Friend SkillY As Integer

    ' Interface de Usuário
    Friend EqX As Integer

    Friend EqY As Integer
    Friend Fps As Integer
    Friend Lps As Integer
    Friend PingToDraw As String
    Friend ShowRClick As Boolean

    Friend LastSkillDesc As Integer ' Guardar a última habilidade que mostramos no desc

    Friend TmpCurrencyItem As Integer

    Friend CurrencyMenu As Byte
    Friend HideGui As Boolean

    ' Variáveis do jogador
    Friend Myindex As Integer ' Índice do jogador atual


    Friend PlayerSkills(MAX_PLAYER_SKILLS) As Byte
    Friend InventoryItemSelected As Integer
    Friend SkillBuffer As Integer
    Friend SkillBufferTimer As Integer
    Friend SkillCd(MAX_PLAYER_SKILLS) As Integer
    Friend StunDuration As Integer
    Friend NextlevelExp As Integer

    ' Para o movimento quando atualiza o mapa
    Friend CanMoveNow As Boolean

    ' Controla o Loop Principal do Jogo
    Friend InGame As Boolean

    Friend IsLogging As Boolean
    Friend MapData As Boolean
    Friend PlayerData As Boolean

    ' Variáveis de Texto

    ' Desenhar o nome da Localização do Mapa
    Friend DrawMapNameX As Single = 110

    Friend DrawMapNameY As Single = 70
    Friend DrawMapNameColor As SFML.Graphics.Color

    ' Variáveis da direção de jogo
    Friend DirUp As Boolean

    Friend DirDown As Boolean
    Friend DirLeft As Boolean
    Friend DirRight As Boolean
    Friend ShiftDown As Boolean
    Friend ControlDown As Boolean

    ' Usado para arrastar Picture Boxes
    Friend SOffsetX As Integer

    Friend SOffsetY As Integer

    ' Usado para congelar controles quando entrando em novo mapa
    Friend GettingMap As Boolean = True

    ' Usado pra ver se o FPS precisa ser desenhado
    Friend Bfps As Boolean

    Friend Blps As Boolean
    Friend BLoc As Boolean

    ' Variáveis de movimento baseado em FPS e tempo
    Friend ElapsedTime As Integer

    Friend GameFps As Integer
    Friend GameLps As Integer

    ' Variáveis de Texto
    Friend VbQuote As String

    ' Localização do cursor do mouse com base na tile
    Friend CurX As Integer

    Friend CurY As Integer
    Friend CurMouseX As Integer
    Friend CurMouseY As Integer

    ' Editores de Jogo
    Friend Editor As Byte

    Friend Editorindex As Integer

    ' Usado para ver se está em um editor ou não e variáveis para uso no editor
    Friend SpawnNpcNum As Integer

    Friend SpawnNpcDir As Byte

    ' Usado para o editor de itens no mapa
    Friend ItemEditorNum As Integer

    Friend ItemEditorValue As Integer

    ' Usado para o editor de chaves no mapa
    Friend KeyEditorNum As Integer

    Friend KeyEditorTake As Integer

    ' Usado para o editor de abrir chaves no mapaU
    Friend KeyOpenEditorX As Integer

    Friend KeyOpenEditorY As Integer

    ' Recursos do Mapa
    Friend ResourceEditorNum As Integer

    ' Usado para o editor de cura/armadilha/escorregar
    Friend MapEditorHealType As Integer

    Friend MapEditorHealAmount As Integer
    Friend MapEditorSlideDir As Integer

    Friend Camera As Rectangle
    Friend TileView As Rect

    ' Pinging
    Friend PingStart As Integer

    Friend PingEnd As Integer
    Friend Ping As Integer

    ' Indexação
    Friend ActionMsgIndex As Byte

    Friend BloodIndex As Byte


    ' Novo Personagem
    Friend NewCharSprite As Integer

    Friend NewCharClass As Integer

    Friend TempMapData() As Byte

    'Janelas
    Friend DialogType As Byte

    Friend DialogMsg1 As String
    Friend DialogMsg2 As String
    Friend DialogMsg3 As String
    Friend UpdateDialog As Boolean
    Friend DialogButton1Text As String
    Friend DialogButton2Text As String

    'Guardar notícias aqui
    Friend News As String

    Friend UpdateNews As Boolean

    Friend ShakeTimerEnabled As Boolean
    Friend ShakeTimer As Integer
    Friend ShakeCount As Byte
    Friend LastDir As Byte

    Friend ShowAnimLayers As Boolean
    Friend ShowAnimTimer As Integer

    Friend EKeyPair As New ASFW.IO.Encryption.KeyPair()

    ' O Editor alterou um vetor de itens
    Friend Item_Changed(MAX_ITEMS) As Boolean
    Friend NPC_Changed(MAX_NPCS) As Boolean
    Friend Resource_Changed(MAX_RESOURCES) As Boolean
    Friend Animation_Changed(MAX_ANIMATIONS) As Boolean
    Friend Skill_Changed(MAX_SKILLS) As Boolean
    Friend Shop_Changed(MAX_SHOPS) As Boolean
    Friend Pet_Changed(MAX_PETS) As Boolean

    Friend AnimEditorFrame(1) As Integer
    Friend AnimEditorTimer(1) As Integer

    'Editores
    Friend InitEditor As Boolean
    Friend InitMapEditor As Boolean
    Friend InitPetEditor As Boolean
    Friend InitItemEditor As Boolean
    Friend InitResourceEditor As Boolean
    Friend InitNPCEditor As Boolean
    Friend InitSkillEditor As Boolean
    Friend InitShopEditor As Boolean
    Friend InitAnimationEditor As Boolean
    Friend InitClassEditor As Boolean
    Friend InitAutoMapper As Boolean

    ' Constantes dos Editores do Jogo
    Friend Const EDITOR_ITEM As Byte = 1
    Friend Const EDITOR_NPC As Byte = 2
    Friend Const EDITOR_SKILL As Byte = 3
    Friend Const EDITOR_SHOP As Byte = 4
    Friend Const EDITOR_RESOURCE As Byte = 5
    Friend Const EDITOR_ANIMATION As Byte = 6
    Friend Const EDITOR_PET As Byte = 7
    Friend Const EDITOR_QUEST As Byte = 7
    Friend Const EDITOR_HOUSE As Byte = 8
    Friend Const EDITOR_RECIPE As Byte = 9
    Friend Const EDITOR_CLASSES As Byte = 10
End Module