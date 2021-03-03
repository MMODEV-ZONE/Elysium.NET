Imports System.Drawing

Module C_Constants

    'Balões de Conversa
    Friend Const ChatBubbleWidth As Integer = 100

    Friend Const EffectTypeFadein As Integer = 1
    Friend Const EffectTypeFadeout As Integer = 2
    Friend Const EffectTypeFlash As Integer = 3
    Friend Const EffectTypeFog As Integer = 4
    Friend Const EffectTypeWeather As Integer = 5
    Friend Const EffectTypeTint As Integer = 6

    ' Variáveis de Fonte
    Friend Const FontName As String = "Arial.ttf"

    Friend Const FontSize As Byte = 13

    ' Variáveis e Diretorio de Logs
    Friend Const LogDebug As String = "debug.txt"

    ' Variáveis e Diretorio de Gráficos
    Friend Const GfxExt As String = ".png"

    ' Estados do Menu
    Friend Const MenuStateNewaccount As Byte = 0

    Friend Const MenuStateDelaccount As Byte = 1
    Friend Const MenuStateLogin As Byte = 2
    Friend Const MenuStateGetchars As Byte = 3
    Friend Const MenuStateNewchar As Byte = 4
    Friend Const MenuStateAddchar As Byte = 5
    Friend Const MenuStateDelchar As Byte = 6
    Friend Const MenuStateUsechar As Byte = 7
    Friend Const MenuStateInit As Byte = 8

    ' Número de Tiles em comprimento nos tilesets
    Friend Const TilesheetWidth As Integer = 15 ' * PicX pixels

    Friend MapGrid As Boolean

    ' Variáveis de velocidade de movimento
    Friend Const WalkSpeed As Byte = 6

    Friend Const RunSpeed As Byte = 10

    ' Constantes do Tamanho da Tile
    Friend Const PicX As Integer = 32

    Friend Const PicY As Integer = 32

    ' Constantes de tamanho de item, sprite e habilidades
    Friend Const SizeX As Integer = 32

    Friend Const SizeY As Integer = 32

    ' ************************************************************
    ' * Os valores abaixo devem bater com os valores do servidor *
    ' ************************************************************

    ' Constantes do Mapa
    Friend ScreenMapx As Byte = 35

    Friend ScreenMapy As Byte = 26

    Friend ItemRarityColor0 = SFML.Graphics.Color.White ' Branco
    Friend ItemRarityColor1 = New SFML.Graphics.Color(102, 255, 0) ' Verde
    Friend ItemRarityColor2 = New SFML.Graphics.Color(73, 151, 208) ' Azul
    Friend ItemRarityColor3 = New SFML.Graphics.Color(255, 0, 0) ' Vermelho
    Friend ItemRarityColor4 = New SFML.Graphics.Color(159, 0, 197) ' Roxo
    Friend ItemRarityColor5 = New SFML.Graphics.Color(255, 215, 0) ' Dourado

    ' Usado para ver se está no editor ou não e variáveis para uso no editor
    Public InMapEditor As Boolean

    Public EditorTileX As Integer
    Public EditorTileY As Integer
    Public EditorTileWidth As Integer
    Public EditorTileHeight As Integer
    Public EditorWarpMap As Integer
    Public EditorWarpX As Integer
    Public EditorWarpY As Integer
    Public EditorShop As Integer
    Public EditorTileSelStart As Point
    Public EditorTileSelEnd As Point

    Friend HalfX As Integer = ((ScreenMapx + 1) \ 2) * PicX
    Friend HalfY As Integer = ((ScreenMapy + 1) \ 2) * PicY
    Friend ScreenX As Integer = (ScreenMapx + 1) * PicX
    Friend ScreenY As Integer = (ScreenMapy + 1) * PicY

    'Tipos de Diálogos
    Friend Const DialogueTypeBuyhome As Byte = 1

    Friend Const DialogueTypeVisit As Byte = 2
    Friend Const DialogueTypeParty As Byte = 3
    Friend Const DialogueTypeQuest As Byte = 4
    Friend Const DialogueTypeTrade As Byte = 5

End Module