Imports System.Drawing
Imports ASFW

Module C_Trade

#Region "Globals & Types"

    Friend TradeTimer As Integer
    Friend TradeRequest As Boolean
    Friend InTrade As Boolean
    Friend TradeYourOffer(MAX_INV) As PlayerInvStruct
    Friend TradeTheirOffer(MAX_INV) As PlayerInvStruct
    Friend TradeX As Integer
    Friend TradeY As Integer
    Friend TheirWorth As String
    Friend YourWorth As String

#End Region

#Region "Incoming Packets"

    Sub Packet_ClearTradeTimer(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        TradeRequest = False
        TradeTimer = 0

        buffer.Dispose()
    End Sub

    Sub Packet_TradeInvite(ByRef data() As Byte)
        Dim requester As Integer
        Dim buffer As New ByteStream(data)
        requester = buffer.ReadInt32

        DialogType = DialogueTypeTrade

        DialogMsg1 = String.Format(Language.Trade.Request, Trim$((Player(requester).Name)))

        UpdateDialog = True

        buffer.Dispose()
    End Sub

    Sub Packet_Trade(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        NeedToOpenTrade = True
        buffer.ReadInt32()
        Tradername = Trim(buffer.ReadString)
        PnlTradeVisible = True

        buffer.Dispose()
    End Sub

    Sub Packet_CloseTrade(ByRef data() As Byte)
        NeedtoCloseTrade = True
    End Sub

    Sub Packet_TradeUpdate(ByRef data() As Byte)
        Dim datatype As Integer
        Dim buffer As New ByteStream(data)
        datatype = buffer.ReadInt32

        If datatype = 0 Then ' nossa!
            For i = 1 To MAX_INV
                TradeYourOffer(i).Num = buffer.ReadInt32
                TradeYourOffer(i).Value = buffer.ReadInt32
            Next
            YourWorth = String.Format(Language.Trade.Value, buffer.ReadInt32) & "g"
        ElseIf datatype = 1 Then 'dele
            For i = 1 To MAX_INV
                TradeTheirOffer(i).Num = buffer.ReadInt32
                TradeTheirOffer(i).Value = buffer.ReadInt32
            Next
            TheirWorth = String.Format(Language.Trade.Value, buffer.ReadInt32) & "g"
        End If

        NeedtoUpdateTrade = True

        buffer.Dispose()
    End Sub

    Sub Packet_TradeStatus(ByRef data() As Byte)
        Dim tradestatus As Integer
        Dim buffer As New ByteStream(data)
        tradestatus = buffer.ReadInt32

        Select Case tradestatus
            Case 0 ' limpo
            Case 1 ' ele aceitou
                AddText(Language.Trade.StatusOther, ColorType.White)
            Case 2 ' você aceitou
                AddText(Language.Trade.StatusSelf, ColorType.White)
        End Select

        buffer.Dispose()
    End Sub

#End Region

#Region "Outgoing Packets"

    Friend Sub AcceptTrade()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CAcceptTrade)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub DeclineTrade()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CDeclineTrade)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendTradeRequest(name As String)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CTradeInvite)

        buffer.WriteString((name))

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

    Sub SendTradeInviteAccept(awnser As Byte)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CTradeInviteAccept)

        buffer.WriteInt32(awnser)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

    Friend Sub TradeItem(invslot As Integer, amount As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CTradeItem)
        buffer.WriteInt32(invslot)
        buffer.WriteInt32(amount)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub UntradeItem(invslot As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CUntradeItem)
        buffer.WriteInt32(invslot)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

#End Region

#Region "Drawing"

    Sub DrawTrade()
        Dim i As Integer, x As Integer, y As Integer, itemnum As Integer, itempic As Integer
        Dim amount As String
        Dim rec As Rectangle, recPos As Rectangle
        Dim colour As SFML.Graphics.Color

        amount = 0
        colour = SFML.Graphics.Color.White

        If Not InGame Then Exit Sub

        'renderizar painel primeiro
        RenderSprite(TradePanelSprite, GameWindow, TradeWindowX, TradeWindowY, 0, 0, TradePanelGfxInfo.Width, TradePanelGfxInfo.Height)

        'cabeçalho texto
        DrawText(TradeWindowX + 70, TradeWindowY + 6, "Sua Oferta", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 15)

        DrawText(TradeWindowX + 260, TradeWindowY + 6, "Oferta de " & Tradername, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 15)

        For i = 1 To MAX_INV
            ' blt sua própria oferta
            itemnum = GetPlayerInvItemNum(Myindex, TradeYourOffer(i).Num)

            If itemnum > 0 AndAlso itemnum <= MAX_ITEMS Then
                itempic = Item(itemnum).Pic

                If itempic > 0 AndAlso itempic <= NumItems Then

                    If ItemsGfxInfo(itempic).IsLoaded = False Then
                        LoadTexture(itempic, 4)
                    End If

                    'vendo que ainda vamos utilizar, atualizar contador
                    With ItemsGfxInfo(itempic)
                        .TextureTimer = GetTickCount() + 100000
                    End With

                    With rec
                        .Y = 0
                        .Height = PicY
                        .X = 0
                        .Width = PicX
                    End With

                    With recPos
                        .Y = TradeWindowY + OurTradeY + InvTop + ((InvOffsetY + 32) * ((i - 1) \ InvColumns))
                        .Height = PicY
                        .X = TradeWindowX + OurTradeX + InvLeft + ((InvOffsetX + 32) * (((i - 1) Mod InvColumns)))
                        .Width = PicX
                    End With

                    RenderSprite(ItemsSprite(itempic), GameWindow, recPos.X, recPos.Y, rec.X, rec.Y, rec.Width, rec.Height)

                    ' Se o item é uma pilha, desenhar a quantidade que tem 
                    If TradeYourOffer(i).Value >= 1 Then
                        y = recPos.Top + 22
                        x = recPos.Left - 4

                        ' Desenhar dinheiro, mas com k, m, b, usando uma função de conversão
                        If amount < 1000000 Then
                            colour = SFML.Graphics.Color.White
                        ElseIf amount > 1000000 AndAlso CLng(amount) < 10000000 Then
                            colour = SFML.Graphics.Color.Yellow
                        ElseIf amount > 10000000 Then
                            colour = SFML.Graphics.Color.Green
                        End If

                        amount = TradeYourOffer(i).Value
                        DrawText(x, y, ConvertCurrency(amount), colour, SFML.Graphics.Color.Black, GameWindow)
                    End If
                End If
            End If
        Next

        DrawText(TradeWindowX + 8, TradeWindowY + 288, YourWorth, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 13)

        For i = 1 To MAX_INV
            ' blt oferta contrária
            itemnum = TradeTheirOffer(i).Num
            'itemnum = GetPlayerInvItemNum(MyIndex, TradeYourOffer(i).Num)
            If itemnum > 0 AndAlso itemnum <= MAX_ITEMS Then
                itempic = Item(itemnum).Pic

                If itempic > 0 AndAlso itempic <= NumItems Then
                    If ItemsGfxInfo(itempic).IsLoaded = False Then
                        LoadTexture(itempic, 4)
                    End If

                    'vendo que ainda vamos utilizar, atualizar contador
                    With ItemsGfxInfo(itempic)
                        .TextureTimer = GetTickCount() + 100000
                    End With

                    With rec
                        .Y = 0
                        .Height = PicY
                        .X = 0
                        .Width = PicX
                    End With

                    With recPos
                        .Y = TradeWindowY + TheirTradeY + InvTop + ((InvOffsetY + 32) * ((i - 1) \ InvColumns))
                        .Height = PicY
                        .X = TradeWindowX + TheirTradeX + InvLeft + ((InvOffsetX + 32) * (((i - 1) Mod InvColumns)))
                        .Width = PicX
                    End With

                    RenderSprite(ItemsSprite(itempic), GameWindow, recPos.X, recPos.Y, rec.X, rec.Y, rec.Width, rec.Height)

                    ' Se o item é uma pilha, desenhar a quantidade que ele tem
                    If TradeTheirOffer(i).Value >= 1 Then
                        y = recPos.Top + 22
                        x = recPos.Left - 4

                        ' Desenhar dinheiro, mas com k, m, b, usando uma função de conversão
                        If amount < 1000000 Then
                            colour = SFML.Graphics.Color.White
                        ElseIf amount > 1000000 AndAlso CLng(amount) < 10000000 Then
                            colour = SFML.Graphics.Color.Yellow
                        ElseIf amount > 10000000 Then
                            colour = SFML.Graphics.Color.Green
                        End If

                        amount = TradeTheirOffer(i).Value
                        DrawText(x, y, amount, colour, SFML.Graphics.Color.Black, GameWindow)
                    End If
                End If
            End If
        Next

        DrawText(TradeWindowX + 208, TradeWindowY + 288, TheirWorth, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 13)

        'Renderizar botão de aceitar
        DrawButton("Aceitar Troca", TradeWindowX + TradeButtonAcceptX, TradeWindowY + TradeButtonAcceptY, 0)

        'renderizar botão de recusar
        DrawButton("Recusar Troca", TradeWindowX + TradeButtonDeclineX, TradeWindowY + TradeButtonDeclineY, 0)
    End Sub

#End Region

End Module