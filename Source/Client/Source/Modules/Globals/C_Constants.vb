Imports System.Drawing

Module C_Constants

    'Balões de Conversa
    Friend Const ChatBubbleWidth As Integer = 100

    ' Variáveis de Fonte
    Friend Const FontName As String = "MinimalFont.ttf"
    Friend Const FontSize As Byte = 13

    ' Variáveis e Diretorio de Logs
    Friend Const LogDebug As String = "debug.txt"

    ' Variáveis e Diretorio de Gráficos
    Friend Const GfxExt As String = ".png"

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

    Friend HalfX As Integer = ((ScreenMapx + 1) \ 2) * PicX
    Friend HalfY As Integer = ((ScreenMapy + 1) \ 2) * PicY
    Friend ScreenX As Integer = (ScreenMapx + 1) * PicX
    Friend ScreenY As Integer = (ScreenMapy + 1) * PicY

End Module