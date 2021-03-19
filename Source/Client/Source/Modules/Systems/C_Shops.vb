﻿Imports System.Drawing
Imports ASFW

Module C_Shops

#Region "Globals & Types"

    Friend InShop As Integer ' o jogador está em uma loja?
    Friend ShopAction As Byte ' guarda a ação atual na loja

#End Region

#Region "DataBase"

    Sub ClearShop(index As Integer)
        Shop(index) = Nothing
        Shop(index) = New ShopStruct With {
            .Name = ""
        }
        ReDim Shop(index).TradeItem(MAX_TRADES)
        For x = 0 To MAX_TRADES
            ReDim Shop(index).TradeItem(x)
        Next
    End Sub

    Sub ClearShops()
        Dim i As Integer

        ReDim Shop(MAX_SHOPS)

        For i = 1 To MAX_SHOPS
            ClearShop(i)
        Next

    End Sub

#End Region

#Region "Incoming Packets"

    Friend Sub Packet_OpenShop(ByRef data() As Byte)
        Dim shopnum As Integer
        Dim buffer As New ByteStream(data)
        shopnum = buffer.ReadInt32

        NeedToOpenShop = True
        NeedToOpenShopNum = shopnum

        buffer.Dispose()
    End Sub

    Friend Sub Packet_ResetShopAction(ByRef data() As Byte)
        ShopAction = 0
    End Sub

    Friend Sub Packet_UpdateShop(ByRef data() As Byte)
        Dim shopnum As Integer
        Dim buffer As New ByteStream(data)
        shopnum = buffer.ReadInt32

        Shop(shopnum) = DeserializeData(buffer)

        If Shop(shopnum).Name Is Nothing Then Shop(shopnum).Name = ""

        buffer.Dispose()
    End Sub

#End Region

#Region "Outgoing Packets"

    Friend Sub SendRequestShops()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CRequestShops)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub BuyItem(shopslot As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CBuyItem)
        buffer.WriteInt32(shopslot)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub SellItem(invslot As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CSellItem)
        buffer.WriteInt32(invslot)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

#End Region

#Region "Drawing"

    Sub DrawShop()
        Dim i As Integer, x As Integer, y As Integer, itemnum As Integer, itempic As Integer
        Dim amount As String
        Dim rec As Rectangle, recPos As Rectangle
        Dim colour As SFML.Graphics.Color

        If Not InGame OrElse PnlShopVisible = False Then Exit Sub

        'primeiramente renderizar painel
        RenderSprite(ShopPanelSprite, GameWindow, ShopWindowX, ShopWindowY, 0, 0, ShopPanelGfxInfo.Width, ShopPanelGfxInfo.Height)

        If Shop(InShop).Face > 0 Then
            'renderizar rosto
            If FacesGfxInfo(Shop(InShop).Face).IsLoaded = False Then
                LoadTexture(Shop(InShop).Face, TextureType.Faces)
            End If

            'se estivermos utilizando, atualizar contador
            With FacesGfxInfo(Shop(InShop).Face)
                .TextureTimer = GetTickCount() + 100000
            End With
            RenderSprite(FacesSprite(Shop(InShop).Face), GameWindow, ShopWindowX + ShopFaceX, ShopWindowY + ShopFaceY, 0, 0, FacesGfxInfo(Shop(InShop).Face).Width, FacesGfxInfo(Shop(InShop).Face).Height)
        End If

        'desenhar texto
        DrawText(ShopWindowX + ShopLeft, ShopWindowY + 10, Trim(Shop(InShop).Name), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 15)

        DrawText(ShopWindowX + 10, ShopWindowY + 10, "Olá e bem-vindo", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 15)
        DrawText(ShopWindowX + 10, ShopWindowY + 25, "à loja!", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 15)

        'renderizar botão de compra
        If CurMouseX > ShopWindowX + ShopButtonBuyX AndAlso CurMouseX < ShopWindowX + ShopButtonBuyX + ButtonGfxInfo.Width And
             CurMouseY > ShopWindowY + ShopButtonBuyY AndAlso CurMouseY < ShopWindowY + ShopButtonBuyY + ButtonGfxInfo.Height Then
            DrawButton("Comprar Item", ShopWindowX + ShopButtonBuyX, ShopWindowY + ShopButtonBuyY, 1)
        Else
            DrawButton("Comprar Item", ShopWindowX + ShopButtonBuyX, ShopWindowY + ShopButtonBuyY, 0)
        End If

        'renderizar botão de venda
        If CurMouseX > ShopWindowX + ShopButtonSellX AndAlso CurMouseX < ShopWindowX + ShopButtonSellX + ButtonGfxInfo.Width And
             CurMouseY > ShopWindowY + ShopButtonSellY AndAlso CurMouseY < ShopWindowY + ShopButtonSellY + ButtonGfxInfo.Height Then
            DrawButton("Sell Item", ShopWindowX + ShopButtonSellX, ShopWindowY + ShopButtonSellY, 1)
        Else
            DrawButton("Sell Item", ShopWindowX + ShopButtonSellX, ShopWindowY + ShopButtonSellY, 0)
        End If

        'render close button
        If CurMouseX > ShopWindowX + ShopButtonCloseX AndAlso CurMouseX < ShopWindowX + ShopButtonCloseX + ButtonGfxInfo.Width And
             CurMouseY > ShopWindowY + ShopButtonCloseY AndAlso CurMouseY < ShopWindowY + ShopButtonCloseY + ButtonGfxInfo.Height Then
            DrawButton("Fechar Loja", ShopWindowX + ShopButtonCloseX, ShopWindowY + ShopButtonCloseY, 1)
        Else
            DrawButton("Fechar Loja", ShopWindowX + ShopButtonCloseX, ShopWindowY + ShopButtonCloseY, 0)
        End If

        For i = 1 To MAX_TRADES
            itemnum = Shop(InShop).TradeItem(i).Item
            If itemnum > 0 AndAlso itemnum <= MAX_ITEMS Then
                itempic = Item(itemnum).Pic
                If itempic > 0 AndAlso itempic <= NumItems Then

                    If ItemsGfxInfo(itempic).IsLoaded = False Then
                        LoadTexture(itempic, TextureType.Items)
                    End If

                    'se estivermos utilizando, atualizar contador
                    With ItemsGfxInfo(itempic)
                        .TextureTimer = GetTickCount() + 100000
                    End With

                    With rec
                        .Y = 0
                        .Height = 32
                        .X = 0
                        .Width = 32
                    End With

                    With recPos
                        .Y = ShopWindowY + ShopTop + ((ShopOffsetY + 32) * ((i - 1) \ ShopColumns))
                        .Height = PicY
                        .X = ShopWindowX + ShopLeft + ((ShopOffsetX + 1 + 32) * (((i - 1) Mod ShopColumns)))
                        .Width = PicX
                    End With

                    RenderSprite(ItemsSprite(itempic), GameWindow, recPos.X, recPos.Y, rec.X, rec.Y, rec.Width, rec.Height)

                    ' Se o item é uma pilha, desenhar a quantidade que temos
                    If Shop(InShop).TradeItem(i).ItemValue > 1 Then
                        y = recPos.Top + 22
                        x = recPos.Left - 4
                        amount = Shop(InShop).TradeItem(i).ItemValue
                        colour = SFML.Graphics.Color.White
                        ' Desenhar moeda mas com k, m, b, etc.
                        If CLng(amount) < 1000000 Then
                            colour = SFML.Graphics.Color.White
                        ElseIf CLng(amount) > 1000000 AndAlso CLng(amount) < 10000000 Then
                            colour = SFML.Graphics.Color.Yellow
                        ElseIf CLng(amount) > 10000000 Then
                            colour = SFML.Graphics.Color.Green
                        End If

                        DrawText(x, y, ConvertCurrency(amount), colour, SFML.Graphics.Color.Black, GameWindow)
                    End If
                End If
            End If
        Next

    End Sub

#End Region

End Module