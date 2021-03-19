﻿Imports System.Drawing
Imports ASFW

Module C_Banks

#Region "Globals & Types"

    Friend Bank As BankStruct

    ' guarda o último item do banco que mostramos no desc 
    Friend LastBankDesc As Integer

    Friend InBank As Integer

    ' arrastar e soltar no banco
    Friend DragBankSlotNum As Integer

    Friend BankX As Integer
    Friend BankY As Integer

#End Region

#Region "Database"

    Sub ClearBank()
        ReDim Bank.Item(MAX_BANK)
        ReDim Bank.ItemRand(MAX_BANK)
        For x = 1 To MAX_BANK
            ReDim Bank.ItemRand(x).Stat(StatType.Count - 1)
        Next
    End Sub

#End Region

#Region "Incoming Packets"

    Friend Sub Packet_OpenBank(ByRef data() As Byte)
        'Dim i As Integer, x As Integer
        Dim buffer As New ByteStream(data)

        Bank = DeserializeData(buffer)

        NeedToOpenBank = True

        buffer.Dispose()
    End Sub

#End Region

#Region "Outgoing Packets"

    Friend Sub DepositItem(invslot As Integer, amount As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CDepositItem)
        buffer.WriteInt32(invslot)
        buffer.WriteInt32(amount)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub WithdrawItem(bankslot As Integer, amount As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CWithdrawItem)
        buffer.WriteInt32(bankslot)
        buffer.WriteInt32(amount)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub ChangeBankSlots(oldSlot As Integer, newSlot As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CChangeBankSlots)
        buffer.WriteInt32(oldSlot)
        buffer.WriteInt32(newSlot)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub CloseBank()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CCloseBank)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

        InBank = False
        PnlBankVisible = False
    End Sub

#End Region

#Region "Drawing"

    Sub DrawBank()
        Dim i As Integer, x As Integer, y As Integer, itemnum As Integer
        Dim amount As String
        Dim sRect As Rectangle, dRect As Rectangle
        Dim sprite As Integer, colour As SFML.Graphics.Color

        'renderizar painel
        RenderSprite(BankPanelSprite, GameWindow, BankWindowX, BankWindowY, 0, 0, BankPanelGfxInfo.Width, BankPanelGfxInfo.Height)

        'cabeçalho
        DrawText(BankWindowX + 140, BankWindowY + 6, "Seu Banco", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 15)

        'fechar
        DrawText(BankWindowX + 140, BankWindowY + BankPanelGfxInfo.Height - 20, "Fechar Banco", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 15)

        For i = 1 To MAX_BANK
            itemnum = GetBankItemNum(i)
            If itemnum > 0 AndAlso itemnum <= MAX_ITEMS Then

                sprite = Item(itemnum).Pic

                If ItemsGfxInfo(sprite).IsLoaded = False Then
                    LoadTexture(sprite, TextureType.Items)
                End If

                'se ainda utilizar, atualizar contador
                With ItemsGfxInfo(sprite)
                    .TextureTimer = GetTickCount() + 100000
                End With

                With sRect
                    .Y = 0
                    .Height = PicY
                    .X = 0
                    .Width = PicX
                End With

                With dRect
                    .Y = BankWindowY + BankTop + ((BankOffsetY + 32) * ((i - 1) \ BankColumns))
                    .Height = PicY
                    .X = BankWindowX + BankLeft + ((BankOffsetX + 32) * (((i - 1) Mod BankColumns)))
                    .Width = PicX
                End With

                RenderSprite(ItemsSprite(sprite), GameWindow, dRect.X, dRect.Y, sRect.X, sRect.Y, sRect.Width, sRect.Height)

                ' Se o item está em pilha, desenhar a quantidade
                If GetBankItemValue(i) > 1 Then
                    y = dRect.Top + 22
                    x = dRect.Left - 4

                    amount = GetBankItemValue(i)
                    colour = SFML.Graphics.Color.White
                    ' Desenhar valores com k, m, b, etc
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
        Next

    End Sub

    Friend Sub DrawBankItem(x As Integer, y As Integer)
        Dim rec As Rectangle

        Dim itemnum As Integer
        Dim sprite As Integer

        itemnum = GetBankItemNum(DragBankSlotNum)
        sprite = Item(GetBankItemNum(DragBankSlotNum)).Pic

        If itemnum > 0 AndAlso itemnum <= MAX_ITEMS Then

            If ItemsGfxInfo(sprite).IsLoaded = False Then
                LoadTexture(sprite, TextureType.Items)
            End If

            'Vendo que ainda vamos utilizar, atualizar contador
            With ItemsGfxInfo(sprite)
                .TextureTimer = GetTickCount() + 100000
            End With

            With rec
                .Y = 0
                .Height = PicY
                .X = 0
                .Width = PicX
            End With
        End If

        RenderSprite(ItemsSprite(sprite), GameWindow, x + 16, y + 16, rec.X, rec.Y, rec.Width, rec.Height)

    End Sub

#End Region

End Module