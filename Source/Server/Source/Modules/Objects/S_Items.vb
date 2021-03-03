Imports System.IO
Imports ASFW
Imports ASFW.IO.FileIO

Friend Module S_Items

#Region "Database"

    Sub SaveItems()
        Dim i As Integer

        For i = 1 To MAX_ITEMS
            SaveItem(i)
        Next

    End Sub

    Sub SaveItem(itemNum As Integer)
        Dim filename As String
        filename = Path.Item(itemNum)

        SaveObject(Item(itemNum), filename)
    End Sub

    Sub LoadItems()
        Dim i As Integer

        CheckItems()

        For i = 1 To MAX_ITEMS
            LoadItem(i)
        Next

    End Sub

    Sub LoadItem(ItemNum As Integer)
        Dim filename As String
        ' Dim s As Integer

        filename = Path.Item(ItemNum)
        LoadObject(Item(ItemNum), filename)

    End Sub

    Sub CheckItems()
        Dim i As Integer

        For i = 1 To MAX_ITEMS

            If Not File.Exists(Path.Item(i)) Then
                SaveItem(i)
            End If

        Next

    End Sub

    Sub ClearItem(index As Integer)
        Item(index) = Nothing
        Item(index).Name = ""
        Item(index).Description = ""

        For i = 0 To MAX_ITEMS
            ReDim Item(i).Add_Stat(StatType.Count - 1)
            ReDim Item(i).Stat_Req(StatType.Count - 1)
            ReDim Item(i).FurnitureBlocks(3, 3)
            ReDim Item(i).FurnitureFringe(3, 3)
        Next

    End Sub

    Sub ClearItems()
        For i = 1 To MAX_ITEMS
            ClearItem(i)
        Next
    End Sub

    Function ItemsData() As Byte()
        Dim buffer As New ByteStream(4)
        For i = 1 To MAX_ITEMS
            If Not Len(Trim$(Item(i).Name)) > 0 Then Continue For
            buffer.WriteBlock(ItemData(i))
        Next
        Return buffer.ToArray
    End Function

    Function ItemData(itemNum As Integer) As Byte()
        Dim buffer As New ByteStream(4)
        buffer.WriteInt32(itemNum)
        buffer.WriteBlock(SerializeData(Item(itemNum)))
        Return buffer.ToArray
    End Function

#End Region

#Region "Map Items"

    Sub SendMapItemsTo(index As Integer, mapNum As Integer)
        Dim i As Integer
        Dim buffer As ByteStream
        buffer = New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SMapItemData)
#If DEBUG Then
        AddDebug("Enviada SMSG: SMapItemData")
#End If
        For i = 1 To MAX_MAP_ITEMS
            buffer.WriteInt32(MapItem(mapNum, i).Num)
            buffer.WriteInt32(MapItem(mapNum, i).Value)
            buffer.WriteInt32(MapItem(mapNum, i).X)
            buffer.WriteInt32(MapItem(mapNum, i).Y)
        Next

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendMapItemsToAll(mapNum As Integer)
        Dim i As Integer
        Dim buffer As ByteStream
        buffer = New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SMapItemData)
#If DEBUG Then
        AddDebug("Enviada SMSG: SMapItemData Para Todos")
#End If
        For i = 1 To MAX_MAP_ITEMS
            buffer.WriteInt32(MapItem(mapNum, i).Num)
            buffer.WriteInt32(MapItem(mapNum, i).Value)
            buffer.WriteInt32(MapItem(mapNum, i).X)
            buffer.WriteInt32(MapItem(mapNum, i).Y)
        Next

        SendDataToMap(mapNum, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SpawnItem(itemNum As Integer, ItemVal As Integer, mapNum As Integer, x As Integer, y As Integer)
        Dim i As Integer

        ' Checar por subscript out of range
        If itemNum < 1 OrElse itemNum > MAX_ITEMS OrElse mapNum <= 0 OrElse mapNum > MAX_CACHED_MAPS Then Exit Sub

        ' Encontrar espaço de item aberto no mapa
        i = FindOpenMapItemSlot(mapNum)

        If i = 0 Then Exit Sub

        SpawnItemSlot(i, itemNum, ItemVal, mapNum, x, y)
    End Sub

    Sub SpawnItemSlot(MapItemSlot As Integer, itemNum As Integer, ItemVal As Integer, mapNum As Integer, x As Integer, y As Integer)
        Dim i As Integer
        Dim buffer As New ByteStream(4)

        ' Verificar por subscript out of range
        If MapItemSlot <= 0 OrElse MapItemSlot > MAX_MAP_ITEMS OrElse itemNum < 0 OrElse itemNum > MAX_ITEMS OrElse mapNum <= 0 OrElse mapNum > MAX_CACHED_MAPS Then Exit Sub

        i = MapItemSlot

        If i <> 0 Then
            If itemNum >= 0 AndAlso itemNum <= MAX_ITEMS Then
                MapItem(mapNum, i).Num = itemNum
                MapItem(mapNum, i).Value = ItemVal
                MapItem(mapNum, i).X = x
                MapItem(mapNum, i).Y = y

                buffer.WriteInt32(ServerPackets.SSpawnItem)
                buffer.WriteInt32(i)
                buffer.WriteInt32(itemNum)
                buffer.WriteInt32(ItemVal)
                buffer.WriteInt32(x)
                buffer.WriteInt32(y)
#If DEBUG Then
                AddDebug("Enviada SMSG: SSpawnItem MapItemSlot")
#End If
                SendDataToMap(mapNum, buffer.Data, buffer.Head)
            End If

        End If

        buffer.Dispose()
    End Sub

    Function FindOpenMapItemSlot(mapNum As Integer) As Integer
        Dim i As Integer
        FindOpenMapItemSlot = 0

        ' Verificar por subscript out of range
        If mapNum <= 0 OrElse mapNum > MAX_CACHED_MAPS Then Exit Function

        For i = 1 To MAX_MAP_ITEMS
            If MapItem(mapNum, i).Num = 0 Then
                FindOpenMapItemSlot = i
                Exit Function
            End If
        Next

    End Function

    Sub SpawnAllMapsItems()
        Dim i As Integer

        For i = 1 To MAX_CACHED_MAPS
            SpawnMapItems(i)
        Next

    End Sub

    Sub SpawnMapItems(mapNum As Integer)
        Dim x As Integer
        Dim y As Integer

        ' Verificar por subscript out of range
        If mapNum <= 0 OrElse mapNum > MAX_CACHED_MAPS Then Exit Sub

        ' Gerar o que temos
        For x = 0 To Map(mapNum).MaxX
            For y = 0 To Map(mapNum).MaxY
                ' Verificar se o tipo do tile é um item em caso de alguém largar algo
                If (Map(mapNum).Tile(x, y).Type = TileType.Item) Then
                    ' Verificar se é dinheiro e se setaram o valor para zero, mudar para 1 automaticamente
                    If Item(Map(mapNum).Tile(x, y).Data1).Type = ItemType.Currency OrElse Item(Map(mapNum).Tile(x, y).Data1).Stackable = 1 Then
                        If Map(mapNum).Tile(x, y).Data2 <= 0 Then
                            SpawnItem(Map(mapNum).Tile(x, y).Data1, 1, mapNum, x, y)
                        Else
                            SpawnItem(Map(mapNum).Tile(x, y).Data1, Map(mapNum).Tile(x, y).Data2, mapNum, x, y)
                        End If
                    Else
                        SpawnItem(Map(mapNum).Tile(x, y).Data1, Map(mapNum).Tile(x, y).Data2, mapNum, x, y)
                    End If
                End If
            Next
        Next

    End Sub

#End Region

#Region "Incoming Packets"

    Sub Packet_RequestItems(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida CMSG: CRequestItems")
#End If

        SendItems(index)
    End Sub

    Sub Packet_EditItem(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida EMSG: RequestEditItem")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then Exit Sub

        Dim Buffer = New ByteStream(4)

        Buffer.WriteInt32(ServerPackets.SItemEditor)
        Socket.SendDataTo(index, Buffer.Data, Buffer.Head)
#If DEBUG Then
        AddDebug("Enviada SMSG: SItemEditor")
#End If
        Buffer.Dispose()
    End Sub

    Sub Packet_SaveItem(index As Integer, ByRef data() As Byte)
        Dim n As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida EMSG: SaveItem")
#End If
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub

        n = buffer.ReadInt32

        If n < 0 OrElse n > MAX_ITEMS Then Exit Sub

        Item(n) = DeserializeData(buffer)

        ' Salvar
        SendUpdateItemToAll(n)
        SaveItem(n)
        Addlog(GetPlayerLogin(index) & " salvou o item #" & n & ".", ADMIN_LOG)
        buffer.Dispose()
    End Sub

    Sub Packet_GetItem(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida CMSG: CMapGetItem")
#End If
        PlayerMapGetItem(index)
    End Sub

    Sub Packet_DropItem(index As Integer, ByRef data() As Byte)
        Dim InvNum As Integer, Amount As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CMapDropItem")
#End If
        InvNum = buffer.ReadInt32
        Amount = buffer.ReadInt32
        buffer.Dispose()

        If TempPlayer(index).InBank OrElse TempPlayer(index).InShop Then Exit Sub

        ' Prevenir hacking
        If InvNum < 1 OrElse InvNum > MAX_INV Then Exit Sub
        If GetPlayerInvItemNum(index, InvNum) < 1 OrElse GetPlayerInvItemNum(index, InvNum) > MAX_ITEMS Then Exit Sub
        If Item(GetPlayerInvItemNum(index, InvNum)).Type = ItemType.Currency OrElse Item(GetPlayerInvItemNum(index, InvNum)).Stackable = 1 Then
            If Amount < 1 OrElse Amount > GetPlayerInvItemValue(index, InvNum) Then Exit Sub
        End If

        ' Todo funcionou bem
        PlayerMapDropItem(index, InvNum, Amount)
    End Sub

#End Region

#Region "Outgoing Packets"

    Sub SendItems(index As Integer)
        Dim i As Integer

        For i = 1 To MAX_ITEMS
            If Len(Trim$(Item(i).Name)) > 0 Then
                SendUpdateItemTo(index, i)
            End If
        Next

    End Sub

    Sub SendUpdateItemTo(index As Integer, itemNum As Integer)
        Dim buffer As ByteStream
        buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SUpdateItem)

        buffer.WriteBlock(ItemData(itemNum))
#If DEBUG Then
        AddDebug("Enviada SMSG: SUpdateItem")
#End If
        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendUpdateItemToAll(itemNum As Integer)
        Dim buffer As ByteStream
        buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SUpdateItem)

        buffer.WriteBlock(ItemData(itemNum))
#If DEBUG Then
        AddDebug("Enviada SMSG: SUpdateItem Para Todos")
#End If

        SendDataToAll(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

#End Region

End Module