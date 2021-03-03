Imports System.IO
Imports System.Windows.Forms
Imports ASFW

Module C_Items

#Region "Globals & Types"

    ' arrastar e soltar do inventário
    Friend DragInvSlotNum As Integer

    Friend InvX As Integer
    Friend InvY As Integer

    Friend InvItemFrame(MAX_INV) As Byte ' Usado para itens animados
    Friend LastItemDesc As Integer ' Guarda o último item que mostramos no desc

#End Region

#Region "DataBase"

    Friend Sub CheckItems()
        Dim i As Integer
        i = 1

        While File.Exists(Path.Graphics & "Itens\" & i & GfxExt)
            NumItems = NumItems + 1
            i = i + 1
        End While

        If NumItems = 0 Then Exit Sub
    End Sub

    Friend Sub ClearItem(index As Integer)
        Item(index) = Nothing
        Item(index) = New ItemStruct
        For x = 0 To StatType.Count - 1
            ReDim Item(index).Add_Stat(x)
        Next
        For x = 0 To StatType.Count - 1
            ReDim Item(index).Stat_Req(x)
        Next

        ReDim Item(index).FurnitureBlocks(3, 3)
        ReDim Item(index).FurnitureFringe(3, 3)

        Item(index).Name = ""
    End Sub

    Sub ClearItems()
        Dim i As Integer

        ReDim Item(MAX_ITEMS)

        For i = 1 To MAX_ITEMS
            ClearItem(i)
        Next

    End Sub

#End Region

#Region "Incoming Packets"

    Friend Sub Packet_UpdateItem(ByRef data() As Byte)
        Dim n As Integer ', i As Integer
        Dim buffer As New ByteStream(data)
        n = buffer.ReadInt32

        Item(n) = DeserializeData(buffer)

        buffer.Dispose()

        ' Muda para o inventário, precisa limpar qualquer drop menu
        FrmGame.pnlCurrency.Visible = False
        FrmGame.txtCurrency.Text = ""
        TmpCurrencyItem = 0
        CurrencyMenu = 0 ' limpeza

    End Sub

#End Region

#Region "Outgoing Packets"

    Sub SendRequestItems()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CRequestItems)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

#End Region

End Module