Imports System.IO
Imports Ini = ASFW.IO.FileIO.TextFile

Module C_AutoMap
    ' Sistema de Auto-mapeamento

#Region "Globals And Types"

    Friend MapStart As Integer = 1
    Friend MapSize As Integer = 4
    Friend MapX As Integer = 50
    Friend MapY As Integer = 50

    Friend SandBorder As Integer = 4
    Friend DetailFreq As Integer = 10
    Friend ResourceFreq As Integer = 20

    Friend DetailsChecked As Boolean = True
    Friend PathsChecked As Boolean = True
    Friend RiversChecked As Boolean = True
    Friend MountainsChecked As Boolean = True
    Friend OverGrassChecked As Boolean = True
    Friend ResourcesChecked As Boolean = True

    Enum TilePrefab
        Water = 1
        Sand
        Grass
        Passing
        Overgrass
        River
        Mountain
        Count
    End Enum

    'Distância entre montanhas e o limite do mapa, para que o jogador possa andar livremente ao se teletransportar entre mapas
    Private Const MountainBorder As Byte = 5

    Friend Tile(TilePrefab.Count - 1) As TileStruct
    Friend Detail() As DetailRec
    Friend ResourcesNum As String
    Private Resources() As String
    'Private ActualMap As Integer

    Enum MountainTile
        UpLeftBorder = 0
        UpMidBorder
        UpRightBorder
        MidLeftBorder
        Middle
        MidRightBorder
        BottomLeftBorder
        BottomMidBorder
        BottomRightBorder
        LeftBody
        MiddleBody
        RightBody
        LeftFoot
        MiddleFoot
        RightFoot
    End Enum

    Enum MapPrefab
        Undefined = 0
        UpLeftQuarter
        UpBorder
        UpRightQuarter
        RightBorder
        DownRightQuarter
        BottomBorder
        DownLeftQuarter
        LeftBorder
        Common
    End Enum

    Structure DetailRec
        Dim DetailBase As Byte
        Dim Tileset As Long
        Dim StartX As Long
        Dim StartY As Long
        Dim EndX As Long
        Dim EndY As Long
    End Structure

    Structure MapOrientationRec
        Dim Prefab As Integer
        Dim TileStartX As Integer
        Dim TileStartY As Integer
        Dim TileEndX As Integer
        Dim TileEndY As Integer
        Dim Tile(,) As TilePrefab
    End Structure

#End Region

#Region "Loading Functions"

    Sub OpenAutomapper()
        LoadTilePrefab()
        frmEditor_AutoMapper.Visible = True
    End Sub

    Sub LoadTilePrefab()
        Dim Prefab As Integer, Layer As Integer
        Dim cf = Path.Contents & "\AutoMapper.ini"

        ReDim Tile(TilePrefab.Count - 1)
        For Prefab = 1 To TilePrefab.Count - 1

            ReDim Tile(Prefab).Layer(LayerType.Count - 1)
            For Layer = 1 To LayerType.Count - 1
                Tile(Prefab).Layer(Layer).Tileset = Val(Ini.Read(cf, "Prefab" & Prefab, "Layer" & Layer & "Tileset"))
                Tile(Prefab).Layer(Layer).X = Val(Ini.Read(cf, "Prefab" & Prefab, "Layer" & Layer & "X"))
                Tile(Prefab).Layer(Layer).Y = Val(Ini.Read(cf, "Prefab" & Prefab, "Layer" & Layer & "Y"))
                Tile(Prefab).Layer(Layer).AutoTile = Val(Ini.Read(cf, "Prefab" & Prefab, "Layer" & Layer & "Autotile"))
            Next
            Tile(Prefab).Type = Val(Ini.Read(cf, "Prefab" & Prefab, "Type"))
        Next

        ResourcesNum = Ini.Read(cf, "Resources", "ResourcesNum")
        Resources = Split(ResourcesNum, ";")

        LoadDetails()
    End Sub

    Sub AddDetail(Prefab As TilePrefab, Tileset As Integer, X As Integer, Y As Integer, TileType As Integer, EndX As Long, EndY As Long)
        Dim DetailCount As Integer
        DetailCount = UBound(Detail)

        Detail(DetailCount).DetailBase = Prefab
        Detail(DetailCount).Tileset = Tileset
        Detail(DetailCount).StartX = X
        Detail(DetailCount).StartY = Y
        Detail(DetailCount).EndX = EndX
        Detail(DetailCount).EndY = EndY

        ReDim Preserve Detail(DetailCount + 1)
    End Sub

    Sub LoadDetails()
        Dim cf = Path.Contents & "\AutoMapper.ini"
        Dim DetailCount As Long
        Dim TilePrefab As Long
        Dim Tileset As Long
        Dim StartX As Long
        Dim StartY As Long
        Dim EndX As Long
        Dim EndY As Long
        ReDim Detail(0)

        'Área de configuração detalhada
        'Uso: LoadDetail TilePrefab, Tileset, StartTilesetX, StartTilesetY, TileType, EndTilesetX, EndTilesetY

        DetailCount = Val(Ini.Read(cf, "Details", "DetailCount"))
        For TileDetail = 0 To DetailCount - 1
            TilePrefab = Val(Ini.Read(cf, "Detail" & TileDetail, "Prefab"))
            Tileset = Val(Ini.Read(cf, "Detail" & TileDetail, "Tileset"))
            StartX = Val(Ini.Read(cf, "Detail" & TileDetail, "StartX"))
            StartY = Val(Ini.Read(cf, "Detail" & TileDetail, "StartY"))
            EndX = Val(Ini.Read(cf, "Detail" & TileDetail, "EndX"))
            EndY = Val(Ini.Read(cf, "Detail" & TileDetail, "EndY"))

            AddDetail(TilePrefab, Tileset, StartX, StartY, TileType.None, EndX, EndY)
        Next
    End Sub

#End Region

#Region "Incoming Packets"

    Sub Packet_AutoMapper(ByRef data() As Byte)
        Dim Layer As Integer, DetailCount As Long
        Dim buffer As New ASFW.ByteStream(data)
        MapStart = buffer.ReadInt32
        MapSize = buffer.ReadInt32
        MapX = buffer.ReadInt32
        MapY = buffer.ReadInt32
        SandBorder = buffer.ReadInt32
        DetailFreq = buffer.ReadInt32
        ResourceFreq = buffer.ReadInt32

        Dim cf = Path.Contents & "\AutoMapper.ini"

        If Not File.Exists(cf) Then Exit Sub

        Ini.Write(cf, "Resources", "ResourcesNum", buffer.ReadString())

        DetailCount = buffer.ReadInt32
        Ini.WriteOrCreate(cf, "Details", "DetailCount", DetailCount)
        For TileDetail = 0 To DetailCount - 1
            Ini.WriteOrCreate(cf, "Detail" & TileDetail, "Prefab", buffer.ReadInt32)
            Ini.WriteOrCreate(cf, "Detail" & TileDetail, "Tileset", buffer.ReadInt32)
            Ini.WriteOrCreate(cf, "Detail" & TileDetail, "StartX", buffer.ReadInt32)
            Ini.WriteOrCreate(cf, "Detail" & TileDetail, "StartY", buffer.ReadInt32)
            Ini.WriteOrCreate(cf, "Detail" & TileDetail, "EndX", buffer.ReadInt32)
            Ini.WriteOrCreate(cf, "Detail" & TileDetail, "EndY", buffer.ReadInt32)
        Next

        For Prefab = 1 To TilePrefab.Count - 1
            ReDim Tile(Prefab).Layer(LayerType.Count - 1)

            Layer = buffer.ReadInt32()
            Ini.Write(cf, "Prefab" & Prefab, "Layer" & Layer & "Tileset", buffer.ReadInt32)
            Ini.Write(cf, "Prefab" & Prefab, "Layer" & Layer & "X", buffer.ReadInt32)
            Ini.Write(cf, "Prefab" & Prefab, "Layer" & Layer & "Y", buffer.ReadInt32)
            Ini.Write(cf, "Prefab" & Prefab, "Layer" & Layer & "Autotile", buffer.ReadInt32)

            Ini.Write(cf, "Prefab" & Prefab, "Type", buffer.ReadInt32)
        Next

        buffer.Dispose()

        InitAutoMapper = True

    End Sub

#End Region

#Region "Outgoing Packets"

    Friend Sub SendRequestAutoMapper()
        Dim buffer As New ASFW.ByteStream(4)

        buffer.WriteInt32(ClientPackets.CRequestAutoMap)
        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub SendSaveAutoMapper()
        Dim detailCount As Long
        Dim cf = Path.Contents & "\AutoMapper.ini"
        Dim buffer As New ASFW.ByteStream(4)

        buffer.WriteInt32(ClientPackets.CSaveAutoMap)

        buffer.WriteInt32(MapStart)
        buffer.WriteInt32(MapSize)
        buffer.WriteInt32(MapX)
        buffer.WriteInt32(MapY)
        buffer.WriteInt32(SandBorder)
        buffer.WriteInt32(DetailFreq)
        buffer.WriteInt32(ResourceFreq)

        'Envio de informações xml
        buffer.WriteString((Ini.Read(cf, "Resources", "ResourcesNum")))

        detailCount = UBound(Detail)
        buffer.WriteInt32(detailCount)
        For TileDetail = 0 To detailCount - 1
            buffer.WriteInt32(Val(Ini.Read(cf, "Detail" & TileDetail, "Prefab")))
            buffer.WriteInt32(Val(Ini.Read(cf, "Detail" & TileDetail, "Tileset")))
            buffer.WriteInt32(Val(Ini.Read(cf, "Detail" & TileDetail, "StartX")))
            buffer.WriteInt32(Val(Ini.Read(cf, "Detail" & TileDetail, "StartY")))
            buffer.WriteInt32(Val(Ini.Read(cf, "Detail" & TileDetail, "EndX")))
            buffer.WriteInt32(Val(Ini.Read(cf, "Detail" & TileDetail, "EndY")))
        Next

        For Prefab = 1 To TilePrefab.Count - 1
            For Layer = 1 To LayerType.Count - 1
                If Val(Ini.Read(cf, "Prefab" & Prefab, "Layer" & Layer & "Tileset")) > 0 Then
                    buffer.WriteInt32(Layer)
                    buffer.WriteInt32(Val(Ini.Read(cf, "Prefab" & Prefab, "Layer" & Layer & "Tileset")))
                    buffer.WriteInt32(Val(Ini.Read(cf, "Prefab" & Prefab, "Layer" & Layer & "X")))
                    buffer.WriteInt32(Val(Ini.Read(cf, "Prefab" & Prefab, "Layer" & Layer & "Y")))
                    buffer.WriteInt32(Val(Ini.Read(cf, "Prefab" & Prefab, "Layer" & Layer & "Autotile")))
                End If
            Next
            buffer.WriteInt32(Val(Ini.Read(cf, "Prefab" & Prefab, "Type")))
        Next

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

#End Region

End Module