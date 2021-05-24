﻿Imports System.Drawing
Imports System.Windows.Forms
Imports ASFW

Friend Module C_GuiFunctions
#Region "Enumerators"
    Enum DialogueType As Byte
        BuyHome = 1
        Visit
        Party
        Quest
        Trade
    End Enum
#End Region

    Friend Sub CheckGuiMove(x As Integer, y As Integer)
        Dim eqNum As Integer, invNum As Integer, skillslot As Integer
        Dim bankitem As Integer, shopslot As Integer, tradeNum As Integer

        ShowItemDesc = False
        'Painel do Personagem
        If PnlCharacterVisible Then
            If x > CharWindowX AndAlso x < CharWindowX + CharPanelGfxInfo.Width Then
                If y > CharWindowY AndAlso y < CharWindowY + CharPanelGfxInfo.Height Then
                    eqNum = IsEqItem(x, y)
                    If eqNum <> 0 Then
                        UpdateDescWindow(GetPlayerEquipment(Myindex, eqNum), 0, eqNum, 1)
                        LastItemDesc = GetPlayerEquipment(Myindex, eqNum) ' Setar para não ter que re-setar
                        ShowItemDesc = True
                        Exit Sub
                    Else
                        ShowItemDesc = False
                        LastItemDesc = 0 ' nenhum item foi carregado da ultima vez
                    End If
                End If
            End If
        End If

        'inventário
        If PnlInventoryVisible Then
            If AboveInvpanel(x, y) Then
                InvX = x
                InvY = y

                If DragInvSlotNum > 0 Then
                    If InTrade Then Exit Sub
                    If InBank OrElse InShop Then Exit Sub
                    DrawInventoryItem(x, y)
                    ShowItemDesc = False
                    LastItemDesc = 0 ' nenhum item foi carregado da ultima vez
                Else
                    invNum = IsInvItem(x, y)

                    If invNum <> 0 Then
                        ' sair se estivermos oferecendo o item
                        For i = 1 To MAX_INV
                            If TradeYourOffer(i).Num = invNum Then
                                Exit Sub
                            End If
                        Next
                        UpdateDescWindow(GetPlayerInvItemNum(Myindex, invNum), GetPlayerInvItemValue(Myindex, invNum), invNum, 0)
                        LastItemDesc = GetPlayerInvItemNum(Myindex, invNum) ' Setar para não ter que re-setar
                        ShowItemDesc = True
                        Exit Sub
                    Else
                        ShowItemDesc = False
                        LastItemDesc = 0 ' nenhum item foi carregado da ultima vez
                    End If
                End If
            End If
        End If

        ' habilidades
        If PnlSkillsVisible = True Then
            If AboveSkillpanel(x, y) Then
                SkillX = x
                SkillY = y

                If DragSkillSlotNum > 0 Then
                    If InTrade Then Exit Sub
                    If InBank OrElse InShop Then Exit Sub
                    DrawSkillItem(x, y)
                    LastSkillDesc = 0 ' nenhum item foi carregado da ultima vez
                    ShowSkillDesc = False
                Else
                    skillslot = IsPlayerSkill(x, y)

                    If skillslot <> 0 Then
                        UpdateSkillWindow(PlayerSkills(skillslot))
                        LastSkillDesc = PlayerSkills(skillslot)
                        ShowSkillDesc = True
                        Exit Sub
                    Else
                        LastSkillDesc = 0
                        ShowSkillDesc = False
                    End If
                End If

            End If
        End If

        'banco
        If PnlBankVisible = True Then
            If AboveBankpanel(x, y) Then
                BankX = x
                BankY = y

                If DragBankSlotNum > 0 Then
                    DrawBankItem(x, y)
                Else
                    bankitem = IsBankItem(x, y)

                    If bankitem <> 0 Then

                        UpdateDescWindow(Bank.Item(bankitem).Num, Bank.Item(bankitem).Value, bankitem, 2)
                        ShowItemDesc = True
                        Exit Sub
                    Else
                        ShowItemDesc = False
                        LastItemDesc = 0 ' nenhum item foi carregado da ultima vez
                    End If
                End If

            End If
        End If

        ' Loja
        If PnlShopVisible = True Then
            If AboveShoppanel(x, y) Then
                shopslot = IsShopItem(x, y)

                If shopslot <> 0 Then

                    UpdateDescWindow(Shop(InShop).TradeItem(shopslot).Item, Shop(InShop).TradeItem(shopslot).ItemValue, shopslot, 3)
                    LastItemDesc = Shop(InShop).TradeItem(shopslot).Item
                    ShowItemDesc = True
                    Exit Sub
                Else
                    ShowItemDesc = False
                    LastItemDesc = 0
                End If

            End If
        End If

        ' Troca
        If PnlTradeVisible = True Then
            If AboveTradepanel(x, y) Then
                TradeX = x
                TradeY = y

                ' Nosso
                tradeNum = IsTradeItem(x, y, True)

                If tradeNum <> 0 Then
                    UpdateDescWindow(GetPlayerInvItemNum(Myindex, TradeYourOffer(tradeNum).Num), TradeYourOffer(tradeNum).Value, tradeNum, 4)
                    LastItemDesc = GetPlayerInvItemNum(Myindex, TradeYourOffer(tradeNum).Num) ' Setar para não ter que re-setar valores
                    ShowItemDesc = True
                    Exit Sub
                Else
                    ShowItemDesc = False
                    LastItemDesc = 0
                End If

                'deles
                tradeNum = IsTradeItem(x, y, False)

                If tradeNum <> 0 Then
                    UpdateDescWindow(TradeTheirOffer(tradeNum).Num, TradeTheirOffer(tradeNum).Value, tradeNum, 4)
                    LastItemDesc = TradeTheirOffer(tradeNum).Num ' Setar para não ter que re-setar valores
                    ShowItemDesc = True
                    Exit Sub
                Else
                    ShowItemDesc = False
                    LastItemDesc = 0
                End If
            End If
        End If

    End Sub

    Friend Function CheckGuiClick(x As Integer, y As Integer, e As MouseEventArgs) As Boolean
        Dim eqNum As Integer
        Dim slotnum As Integer, hotbarslot As Integer
        Dim buffer As ByteStream

        CheckGuiClick = False
        'painel de ações
        If HudVisible AndAlso HideGui = False Then
            If AboveActionPanel(x, y) Then
                ' botao esquerdo
                If e.Button = MouseButtons.Left Then
                    'Inventari
                    If x > ActionPanelX + InvBtnX AndAlso x < ActionPanelX + InvBtnX + 48 AndAlso y > ActionPanelY + InvBtnY AndAlso y < ActionPanelY + InvBtnY + 32 Then
                        PlaySound("Click.ogg")
                        PnlInventoryVisible = Not PnlInventoryVisible
                        PnlCharacterVisible = False
                        PnlSkillsVisible = False
                        CheckGuiClick = True
                        'Habilidades
                    ElseIf x > ActionPanelX + SkillBtnX AndAlso x < ActionPanelX + SkillBtnX + 48 AndAlso y > ActionPanelY + SkillBtnY AndAlso y < ActionPanelY + SkillBtnY + 32 Then
                        PlaySound("Click.ogg")
                        buffer = New ByteStream(4)
                        buffer.WriteInt32(ClientPackets.CSkills)
                        Socket.SendData(buffer.Data, buffer.Head)
                        buffer.Dispose()
                        PnlSkillsVisible = Not PnlSkillsVisible
                        PnlInventoryVisible = False
                        PnlCharacterVisible = False
                        CheckGuiClick = True
                        'Personagem
                    ElseIf x > ActionPanelX + CharBtnX AndAlso x < ActionPanelX + CharBtnX + 48 AndAlso y > ActionPanelY + CharBtnY AndAlso y < ActionPanelY + CharBtnY + 32 Then
                        PlaySound("Click.ogg")
                        SendRequestPlayerData()
                        PnlCharacterVisible = Not PnlCharacterVisible
                        PnlInventoryVisible = False
                        PnlSkillsVisible = False
                        CheckGuiClick = True
                        'Quest
                    ElseIf x > ActionPanelX + QuestBtnX AndAlso x < ActionPanelX + QuestBtnX + 48 AndAlso y > ActionPanelY + QuestBtnY AndAlso y < ActionPanelY + QuestBtnY + 32 Then
                        UpdateQuestLog()
                        ' Mostrar janela
                        PnlInventoryVisible = False
                        PnlCharacterVisible = False
                        RefreshQuestLog()
                        PnlQuestLogVisible = Not PnlQuestLogVisible
                        CheckGuiClick = True
                        'Opções
                    ElseIf x > ActionPanelX + OptBtnX AndAlso x < ActionPanelX + OptBtnX + 48 AndAlso y > ActionPanelY + OptBtnY AndAlso y < ActionPanelY + OptBtnY + 32 Then
                        PlaySound("Click.ogg")
                        PnlCharacterVisible = False
                        PnlInventoryVisible = False
                        PnlSkillsVisible = False

                        OptionsVisible = Not OptionsVisible
                        FrmOptions.BringToFront()
                        CheckGuiClick = True
                        'Sair
                    ElseIf x > ActionPanelX + ExitBtnX AndAlso x < ActionPanelX + ExitBtnX + 48 AndAlso y > ActionPanelY + ExitBtnY AndAlso y < ActionPanelY + ExitBtnY + 32 Then
                        PlaySound("Click.ogg")
                        FrmAdmin.Dispose()
                        SendLeaveGame()
                        'DestroyGame()

                        CheckGuiClick = True
                    End If
                End If
            End If

            'hotbar
            If AboveHotbar(x, y) Then

                hotbarslot = IsHotBarSlot(e.Location.X, e.Location.Y)

                If e.Button = MouseButtons.Left Then
                    If hotbarslot > 0 Then
                        slotnum = Player(Myindex).Hotbar(hotbarslot).Slot

                        If slotnum <> 0 Then
                            PlaySound("Click.ogg")
                            SendUseHotbarSlot(hotbarslot)
                        End If

                        CheckGuiClick = True
                    End If
                ElseIf e.Button = MouseButtons.Right Then ' botão direito
                    If Player(Myindex).Hotbar(hotbarslot).Slot > 0 Then
                        'esquece habilidade da  hotbar 
                        Dim result1 As DialogResult = MessageBox.Show("Quer deletar isso da sua hotbar?", Settings.GameName, MessageBoxButtons.YesNo)
                        If result1 = DialogResult.Yes Then
                            SendDeleteHotbar(IsHotBarSlot(e.Location.X, e.Location.Y))
                        End If

                        CheckGuiClick = True
                    Else
                        buffer = New ByteStream(4)
                        buffer.WriteInt32(ClientPackets.CSkills)
                        Socket.SendData(buffer.Data, buffer.Head)
                        buffer.Dispose()
                        PnlSkillsVisible = True
                        AddText("Clique na habilidade que você quer colocar aqui.", QColorType.TellColor)
                        SelSkillSlot = True
                        SelHotbarSlot = IsHotBarSlot(e.Location.X, e.Location.Y)
                    End If
                End If
                CheckGuiClick = True
            End If

            If AbovePetbar(x, y) Then
                If Player(Myindex).Pet.Num > 0 Then
                    hotbarslot = IsPetBarSlot(e.Location.X, e.Location.Y)

                    If e.Button = MouseButtons.Left Then
                        If hotbarslot > 0 Then
                            If hotbarslot >= 1 AndAlso hotbarslot <= 3 Then
                                If hotbarslot = 1 Then
                                    'summon
                                    SendSummonPet()
                                ElseIf hotbarslot = 2 Then
                                    SendPetBehaviour(PetAttackBehaviourAttackonsight)
                                ElseIf hotbarslot = 3 Then
                                    SendPetBehaviour(PetAttackBehaviourGuard)
                                End If

                            ElseIf hotbarslot >= 4 AndAlso hotbarslot <= 7 Then
                                slotnum = Player(Myindex).Pet.Skill(hotbarslot - 3)

                                If slotnum <> 0 Then
                                    PlaySound("Click.ogg")
                                    SendUsePetSkill(slotnum)
                                End If
                            End If

                            CheckGuiClick = True
                        End If
                    End If

                    CheckGuiClick = True
                End If
            End If

        End If

        'Painel do personagem
        If PnlCharacterVisible Then
            If AboveCharpanel(x, y) Then
                ' Botao esquerdo
                If e.Button = MouseButtons.Left Then

                    'Vamos ver se quer dar upgrade
                    'Força
                    If x > CharWindowX + StrengthUpgradeX AndAlso x < CharWindowX + StrengthUpgradeX + 10 AndAlso y > CharWindowY + StrengthUpgradeY AndAlso y < CharWindowY + StrengthUpgradeY + 10 Then
                        If Not GetPlayerPoints(Myindex) = 0 Then
                            PlaySound("Click.ogg")
                            SendTrainStat(1)
                        End If
                    End If
                    'Resistencia
                    If x > CharWindowX + EnduranceUpgradeX AndAlso x < CharWindowX + EnduranceUpgradeX + 10 AndAlso y > CharWindowY + EnduranceUpgradeY AndAlso y < CharWindowY + EnduranceUpgradeY + 10 Then
                        If Not GetPlayerPoints(Myindex) = 0 Then
                            PlaySound("Click.ogg")
                            SendTrainStat(2)
                        End If
                    End If
                    'Vitalidade
                    If x > CharWindowX + VitalityUpgradeX AndAlso x < CharWindowX + VitalityUpgradeX + 10 AndAlso y > CharWindowY + VitalityUpgradeY AndAlso y < CharWindowY + VitalityUpgradeY + 10 Then
                        If Not GetPlayerPoints(Myindex) = 0 Then
                            PlaySound("Click.ogg")
                            SendTrainStat(3)
                        End If
                    End If
                    'Força de Vontade
                    If x > CharWindowX + LuckUpgradeX AndAlso x < CharWindowX + LuckUpgradeX + 10 AndAlso y > CharWindowY + LuckUpgradeY AndAlso y < CharWindowY + LuckUpgradeY + 10 Then
                        If Not GetPlayerPoints(Myindex) = 0 Then
                            PlaySound("Click.ogg")
                            SendTrainStat(4)
                        End If
                    End If
                    'Intelecto
                    If x > CharWindowX + IntellectUpgradeX AndAlso x < CharWindowX + IntellectUpgradeX + 10 AndAlso y > CharWindowY + IntellectUpgradeY AndAlso y < CharWindowY + IntellectUpgradeY + 10 Then
                        If Not GetPlayerPoints(Myindex) = 0 Then
                            PlaySound("Click.ogg")
                            SendTrainStat(5)
                        End If
                    End If
                    'Espírito
                    If x > CharWindowX + SpiritUpgradeX AndAlso x < CharWindowX + SpiritUpgradeX + 10 AndAlso y > CharWindowY + SpiritUpgradeY AndAlso y < CharWindowY + SpiritUpgradeY + 10 Then
                        If Not GetPlayerPoints(Myindex) = 0 Then
                            PlaySound("Click.ogg")
                            SendTrainStat(6)
                        End If
                    End If
                    CheckGuiClick = True
                ElseIf e.Button = MouseButtons.Right Then
                    'Primeiro ver o equipamento
                    eqNum = IsEqItem(x, y)

                    If eqNum <> 0 Then
                        PlaySound("Click.ogg")
                        Dim result1 As DialogResult = MessageBox.Show("Quer desequipar?", Settings.GameName, MessageBoxButtons.YesNo)
                        If result1 = DialogResult.Yes Then
                            SendUnequip(eqNum)
                        End If
                        CheckGuiClick = True
                    End If
                End If
            End If

            'Painel o inventário
        ElseIf PnlInventoryVisible Then
            If AboveInvpanel(x, y) Then CheckGuiClick = True
        End If

        If DialogPanelVisible Then
            'Botão de ok
            If x > DialogPanelX + OkButtonX AndAlso x < DialogPanelX + OkButtonX + ButtonGfxInfo.Width AndAlso y > DialogPanelY + OkButtonY AndAlso y < DialogPanelY + OkButtonY + ButtonGfxInfo.Height Then
                VbKeyDown = False
                VbKeyUp = False
                VbKeyLeft = False
                VbKeyRight = False

                If DialogType = DialogueType.BuyHome Then 'Oferta de Moradia
                    SendBuyHouse(1)
                ElseIf DialogType = DialogueType.Visit Then
                    SendVisit(1)
                ElseIf DialogType = DialogueType.Party Then
                    SendAcceptParty()
                ElseIf DialogType = DialogueType.Quest Then
                    If QuestAcceptTag > 0 Then
                        PlayerHandleQuest(QuestAcceptTag, 1)
                        QuestAcceptTag = 0
                        RefreshQuestLog()
                    End If
                ElseIf DialogType = DialogueType.Trade Then
                    SendTradeInviteAccept(1)
                End If

                PlaySound("Click.ogg")
                DialogPanelVisible = False
            End If
            'Botão de Cancelar
            If x > DialogPanelX + CancelButtonX AndAlso x < DialogPanelX + CancelButtonX + ButtonGfxInfo.Width AndAlso y > DialogPanelY + CancelButtonY AndAlso y < DialogPanelY + CancelButtonY + ButtonGfxInfo.Height Then
                VbKeyDown = False
                VbKeyUp = False
                VbKeyLeft = False
                VbKeyRight = False

                If DialogType = DialogueType.BuyHome Then 'Oferta de Moradia recusada
                    SendBuyHouse(0)
                ElseIf DialogueType.Visit Then 'Visita recusada
                    SendVisit(0)
                ElseIf DialogueType.Party Then 'Equipe recusada
                    SendLeaveParty()
                ElseIf DialogueType.Quest Then 'quest recusada
                    QuestAcceptTag = 0
                ElseIf DialogType = DialogueType.Trade Then
                    SendTradeInviteAccept(0)
                End If
                PlaySound("Click.ogg")
                DialogPanelVisible = False
            End If
            CheckGuiClick = True
        End If

        If PnlBankVisible = True Then
            If AboveBankpanel(x, y) Then
                If x > BankWindowX + 140 AndAlso x < BankWindowX + 140 + GetTextWidth("Close Bank", 15) Then
                    If y > BankWindowY + BankPanelGfxInfo.Height - 15 AndAlso y < BankWindowY + BankPanelGfxInfo.Height Then
                        PlaySound("Click.ogg")
                        CloseBank()
                    End If
                End If
                CheckGuiClick = True
            End If
        End If

        'troca
        If PnlTradeVisible = True Then
            If AboveTradepanel(x, y) Then
                'botao de aceitar
                If x > TradeWindowX + TradeButtonAcceptX AndAlso x < TradeWindowX + TradeButtonAcceptX + ButtonGfxInfo.Width Then
                    If y > TradeWindowY + TradeButtonAcceptY AndAlso y < TradeWindowY + TradeButtonAcceptY + ButtonGfxInfo.Height Then
                        PlaySound("Click.ogg")
                        AcceptTrade()
                    End If
                End If

                'botao de rejeitar
                If x > TradeWindowX + TradeButtonDeclineX AndAlso x < TradeWindowX + TradeButtonDeclineX + ButtonGfxInfo.Width Then
                    If y > TradeWindowY + TradeButtonDeclineY AndAlso y < TradeWindowY + TradeButtonDeclineY + ButtonGfxInfo.Height Then
                        PlaySound("Click.ogg")
                        DeclineTrade()
                    End If
                End If

                CheckGuiClick = True
            End If

        End If

        'Chat de eventos
        If PnlEventChatVisible = True Then
            If AboveEventChat(x, y) Then
                'Resposta 1
                If EventChoiceVisible(1) Then
                    If x > EventChatX + 10 AndAlso x < EventChatX + 10 + GetTextWidth(EventChoices(1)) Then
                        If y > EventChatY + 124 AndAlso y < EventChatY + 124 + 13 Then
                            PlaySound("Click.ogg")
                            buffer = New ByteStream(4)
                            buffer.WriteInt32(ClientPackets.CEventChatReply)
                            buffer.WriteInt32(EventReplyId)
                            buffer.WriteInt32(EventReplyPage)
                            buffer.WriteInt32(1)
                            Socket.SendData(buffer.Data, buffer.Head)
                            buffer.Dispose()
                            ClearEventChat()
                            InEvent = False
                        End If
                    End If
                End If

                'Resposta 2
                If EventChoiceVisible(2) Then
                    If x > EventChatX + 10 AndAlso x < EventChatX + 10 + GetTextWidth(EventChoices(2)) Then
                        If y > EventChatY + 146 AndAlso y < EventChatY + 146 + 13 Then
                            PlaySound("Click.ogg")
                            buffer = New ByteStream(4)
                            buffer.WriteInt32(ClientPackets.CEventChatReply)
                            buffer.WriteInt32(EventReplyId)
                            buffer.WriteInt32(EventReplyPage)
                            buffer.WriteInt32(2)
                            Socket.SendData(buffer.Data, buffer.Head)
                            buffer.Dispose()
                            ClearEventChat()
                            InEvent = False
                        End If
                    End If
                End If

                'Resposta 3
                If EventChoiceVisible(3) Then
                    If x > EventChatX + 226 AndAlso x < EventChatX + 226 + GetTextWidth(EventChoices(3)) Then
                        If y > EventChatY + 124 AndAlso y < EventChatY + 124 + 13 Then
                            PlaySound("Click.ogg")
                            buffer = New ByteStream(4)
                            buffer.WriteInt32(ClientPackets.CEventChatReply)
                            buffer.WriteInt32(EventReplyId)
                            buffer.WriteInt32(EventReplyPage)
                            buffer.WriteInt32(3)
                            Socket.SendData(buffer.Data, buffer.Head)
                            buffer.Dispose()
                            ClearEventChat()
                            InEvent = False
                        End If
                    End If
                End If

                'Resposta 4
                If EventChoiceVisible(4) Then
                    If x > EventChatX + 226 AndAlso x < EventChatX + 226 + GetTextWidth(EventChoices(4)) Then
                        If y > EventChatY + 146 AndAlso y < EventChatY + 146 + 13 Then
                            PlaySound("Click.ogg")
                            buffer = New ByteStream(4)
                            buffer.WriteInt32(ClientPackets.CEventChatReply)
                            buffer.WriteInt32(EventReplyId)
                            buffer.WriteInt32(EventReplyPage)
                            buffer.WriteInt32(4)
                            Socket.SendData(buffer.Data, buffer.Head)
                            buffer.Dispose()
                            ClearEventChat()
                            InEvent = False
                        End If
                    End If
                End If

                'Continuar
                If EventChatType <> 1 Then
                    If x > EventChatX + 410 AndAlso x < EventChatX + 410 + GetTextWidth("Continue") Then
                        If y > EventChatY + 156 AndAlso y < EventChatY + 156 + 13 Then
                            PlaySound("Click.ogg")
                            buffer = New ByteStream(4)
                            buffer.WriteInt32(ClientPackets.CEventChatReply)
                            buffer.WriteInt32(EventReplyId)
                            buffer.WriteInt32(EventReplyPage)
                            buffer.WriteInt32(0)
                            Socket.SendData(buffer.Data, buffer.Head)
                            buffer.Dispose()
                            ClearEventChat()
                            InEvent = False
                        End If
                    End If
                End If
                CheckGuiClick = True
            End If
        End If

        'Botao direito
        If PnlRClickVisible = True Then
            If AboveRClickPanel(x, y) Then
                'Troca
                If x > RClickX + (RClickGfxInfo.Width \ 2) - (GetTextWidth("Convidar para Trocar") \ 2) AndAlso x < RClickX + (RClickGfxInfo.Width \ 2) - (GetTextWidth("Invite to Trade") \ 2) + GetTextWidth("Invite to Trade") Then
                    If y > RClickY + 35 AndAlso y < RClickY + 35 + 12 Then
                        If MyTarget > 0 Then
                            SendTradeRequest(Player(MyTarget).Name)
                        End If
                        PnlRClickVisible = False
                    End If
                End If

                'Equipe
                If x > RClickX + (RClickGfxInfo.Width \ 2) - (GetTextWidth("Convidar para Equipe") \ 2) AndAlso x < RClickX + (RClickGfxInfo.Width \ 2) - (GetTextWidth("Invite to Party") \ 2) + GetTextWidth("Invite to Party") Then
                    If y > RClickY + 60 AndAlso y < RClickY + 60 + 12 Then
                        If MyTarget > 0 Then
                            SendPartyRequest(Player(MyTarget).Name)
                        End If
                        PnlRClickVisible = False
                    End If
                End If

                'Moradia
                If x > RClickX + (RClickGfxInfo.Width \ 2) - (GetTextWidth("Convidar para Moradia") \ 2) AndAlso x < RClickX + (RClickGfxInfo.Width \ 2) - (GetTextWidth("Invite to House") \ 2) + GetTextWidth("Invite to House") Then
                    If y > RClickY + 85 AndAlso y < RClickY + 85 + 12 Then
                        If MyTarget > 0 Then
                            SendInvite(Player(MyTarget).Name)
                        End If
                        PnlRClickVisible = False
                    End If
                End If

                CheckGuiClick = True
            End If
        End If

        If PnlQuestLogVisible Then
            If AboveQuestPanel(x, y) Then
                'Ver se apertaram a lista
                Dim tmpy As Integer = 10
                For i = 1 To MaxActivequests
                    If Len(Trim$(QuestNames(i))) > 0 Then
                        If x > (QuestLogX + 7) AndAlso x < (QuestLogX + 7) + (GetTextWidth(QuestNames(i))) Then
                            If y > (QuestLogY + tmpy) AndAlso y < (QuestLogY + tmpy + 13) Then
                                SelectedQuest = i
                                LoadQuestlogBox()
                            End If
                        End If
                        tmpy += 20
                    End If
                Next

                'Botao de fechar
                If x > (QuestLogX + 195) AndAlso x < (QuestLogX + 290) Then
                    If y > (QuestLogY + 358) AndAlso y < (QuestLogY + 375) Then
                        ResetQuestLog()
                    End If

                    CheckGuiClick = True
                End If
            End If
        End If

        If PnlCraftVisible Then
            If AboveCraftPanel(x, y) Then
                'Ver se apertaram a lista
                Dim tmpy As Integer = 10
                For i = 1 To MAX_RECIPE
                    If Len(Trim$(RecipeNames(i))) > 0 Then
                        If x > (CraftPanelX + 12) AndAlso x < (CraftPanelX + 12) + (GetTextWidth(RecipeNames(i))) Then
                            If y > (CraftPanelY + tmpy) AndAlso y < (CraftPanelY + tmpy + 13) Then
                                SelectedRecipe = i
                                CraftingInit()
                            End If
                        End If
                        tmpy += 20
                    End If
                Next

                'Botao de inicio
                If x > (CraftPanelX + 256) AndAlso x < (CraftPanelX + 330) Then
                    If y > (CraftPanelY + 415) AndAlso y < (CraftPanelY + 437) Then
                        If SelectedRecipe > 0 Then
                            CraftProgressValue = 0
                            SendCraftIt(RecipeNames(SelectedRecipe), CraftAmountValue)
                        End If
                    End If
                End If

                'Botao de fechar
                If x > (CraftPanelX + 614) AndAlso x < (CraftPanelX + 689) Then
                    If y > (CraftPanelY + 472) AndAlso y < (CraftPanelY + 494) Then
                        ResetCraftPanel()
                        PnlCraftVisible = False
                        InCraft = False
                        SendCloseCraft()
                    End If
                End If

                'Menos
                If x > (CraftPanelX + 340) AndAlso x < (CraftPanelX + 340 + 10) Then
                    If y > (CraftPanelY + 422) AndAlso y < (CraftPanelY + 422 + 10) Then
                        If CraftAmountValue > 1 Then
                            CraftAmountValue -= 1
                        End If
                    End If
                End If

                'Mais
                If x > (CraftPanelX + 392) AndAlso x < (CraftPanelX + 392 + 10) Then
                    If y > (CraftPanelY + 422) AndAlso y < (CraftPanelY + 422 + 10) Then
                        If CraftAmountValue < 100 Then
                            CraftAmountValue += 1
                        End If
                    End If
                End If

                CheckGuiClick = True
            End If
        End If

    End Function

    Friend Function CheckGuiDoubleClick(x As Integer, y As Integer, e As MouseEventArgs) As Boolean
        Dim invNum As Integer, skillnum As Integer, bankItem As Integer
        Dim value As Integer, tradeNum As Integer
        Dim multiplier As Double
        Dim i As Integer

        If PnlInventoryVisible Then
            If AboveInvpanel(x, y) Then
                DragInvSlotNum = 0
                invNum = IsInvItem(InvX, InvY)

                If invNum <> 0 Then

                    ' Estamos em uma loja?
                    If InShop > 0 Then
                        Select Case ShopAction
                            Case 0 ' nada, dar valor
                                multiplier = Shop(InShop).BuyRate / 100
                                value = Item(GetPlayerInvItemNum(Myindex, invNum)).Price * multiplier
                                If value > 0 Then
                                    AddText("Você pode vender esse item por " & value & " gold.", QColorType.TellColor)
                                Else
                                    AddText("Esta loja não quer esse item.", QColorType.AlertColor)
                                End If
                            Case 2 ' 2 = sell
                                SellItem(invNum)
                        End Select

                        Exit Function
                    End If

                    ' No banco?
                    If InBank Then
                        If Item(GetPlayerInvItemNum(Myindex, invNum)).Type = ItemType.Currency OrElse Item(GetPlayerInvItemNum(Myindex, invNum)).Stackable = 1 Then
                            CurrencyMenu = 2 ' deposito
                            FrmGame.lblCurrency.Text = "Quantos você quer depositar?"
                            TmpCurrencyItem = invNum
                            FrmGame.txtCurrency.Text = ""
                            FrmGame.pnlCurrency.Visible = True
                            FrmGame.pnlCurrency.BringToFront()
                            FrmGame.txtCurrency.Focus()
                            Exit Function
                        End If
                        DepositItem(invNum, 0)
                        Exit Function
                    End If

                    ' em troca?
                    If InTrade = True Then
                        ' sair se estivermos oferecendo aquele item
                        For i = 1 To MAX_INV
                            If TradeYourOffer(i).Num = invNum Then
                                Exit Function
                            End If
                        Next
                        If Item(GetPlayerInvItemNum(Myindex, invNum)).Type = ItemType.Currency OrElse Item(GetPlayerInvItemNum(Myindex, invNum)).Stackable = 1 Then
                            CurrencyMenu = 4 ' troca
                            FrmGame.lblCurrency.Text = "Quantos você quer trocar?"
                            TmpCurrencyItem = invNum
                            FrmGame.txtCurrency.Text = ""
                            FrmGame.pnlCurrency.Visible = True
                            FrmGame.pnlCurrency.BringToFront()
                            FrmGame.txtCurrency.Focus()
                            Exit Function
                        End If
                        TradeItem(invNum, 0)
                        Exit Function
                    End If

                    ' usar item se não estiver fazendo nada
                    If Item(GetPlayerInvItemNum(Myindex, invNum)).Type = ItemType.None Then Exit Function
                    SendUseItem(invNum)
                    Exit Function
                End If
            End If
        End If

        'Painel de Habilidade
        If PnlSkillsVisible = True Then
            If AboveSkillpanel(x, y) Then

                skillnum = IsPlayerSkill(SkillX, SkillY)

                If skillnum <> 0 Then
                    PlayerCastSkill(skillnum)
                    Exit Function
                End If
            End If
        End If

        'Painel de Banco
        If PnlBankVisible = True Then
            If AboveBankpanel(x, y) Then

                DragBankSlotNum = 0

                bankItem = IsBankItem(BankX, BankY)
                If bankItem <> 0 Then
                    If GetBankItemNum(bankItem) = ItemType.None Then Exit Function

                    If Item(GetBankItemNum(bankItem)).Type = ItemType.Currency OrElse Item(GetBankItemNum(bankItem)).Stackable = 1 Then
                        CurrencyMenu = 3 ' retirar
                        FrmGame.lblCurrency.Text = "Quantos você quer retirar?"
                        TmpCurrencyItem = bankItem
                        FrmGame.txtCurrency.Text = ""
                        FrmGame.pnlCurrency.Visible = True
                        FrmGame.txtCurrency.Focus()
                        Exit Function
                    End If

                    WithdrawItem(bankItem, 0)
                    Exit Function
                End If
            End If
        End If

        'painel de troca
        If PnlTradeVisible = True Then
            'nosso?
            If AboveTradepanel(x, y) Then
                tradeNum = IsTradeItem(TradeX, TradeY, True)

                If tradeNum <> 0 Then
                    UntradeItem(tradeNum)
                End If
            End If
        End If

    End Function

    Friend Function CheckGuiMouseUp(x As Integer, y As Integer, e As MouseEventArgs) As Boolean
        Dim i As Integer, recPos As Rectangle, buffer As ByteStream
        Dim hotbarslot As Integer

        'Inventario
        If PnlInventoryVisible Then
            If AboveInvpanel(x, y) Then
                If InTrade > 0 Then Exit Function
                If InBank OrElse InShop Then Exit Function

                If DragInvSlotNum > 0 Then

                    For i = 1 To MAX_INV

                        With recPos
                            .Y = InvWindowY + InvTop + ((InvOffsetY + 32) * ((i - 1) \ InvColumns))
                            .Height = PicY
                            .X = InvWindowX + InvLeft + ((InvOffsetX + 32) * (((i - 1) Mod InvColumns)))
                            .Width = PicX
                        End With

                        If e.Location.X >= recPos.Left AndAlso e.Location.X <= recPos.Right Then
                            If e.Location.Y >= recPos.Top AndAlso e.Location.Y <= recPos.Bottom Then '
                                If DragInvSlotNum <> i Then
                                    SendChangeInvSlots(DragInvSlotNum, i)
                                    Exit For
                                End If
                            End If
                        End If

                    Next

                End If

                DragInvSlotNum = 0
            ElseIf AboveHotbar(x, y) Then
                If DragInvSlotNum > 0 Then
                    hotbarslot = IsHotBarSlot(e.Location.X, e.Location.Y)
                    If hotbarslot > 0 Then
                        SendSetHotbarSlot(hotbarslot, DragInvSlotNum, 2)
                    End If
                End If

                DragInvSlotNum = 0
            Else
                If FurnitureSelected > 0 Then
                    If Player(Myindex).InHouse = Myindex Then
                        If Item(PlayerInv(FurnitureSelected).Num).Type = ItemType.Furniture Then
                            buffer = New ByteStream(4)
                            buffer.WriteInt32(ClientPackets.CPlaceFurniture)
                            i = CurX
                            buffer.WriteInt32(i)
                            i = CurY
                            buffer.WriteInt32(i)
                            buffer.WriteInt32(FurnitureSelected)
                            Socket.SendData(buffer.Data, buffer.Head)
                            buffer.Dispose()

                            FurnitureSelected = 0
                        End If
                    End If
                End If
            End If
        End If

        'habilidades
        If PnlSkillsVisible Then
            If AboveSkillpanel(x, y) Then
                If InTrade > 0 Then Exit Function
                If InBank OrElse InShop Then Exit Function

                If DragSkillSlotNum > 0 Then

                    For i = 1 To MAX_PLAYER_SKILLS

                        With recPos
                            .Y = SkillWindowY + SkillTop + ((SkillOffsetY + 32) * ((i - 1) \ SkillColumns))
                            .Height = PicY
                            .X = SkillWindowX + SkillLeft + ((SkillOffsetX + 32) * (((i - 1) Mod SkillColumns)))
                            .Width = PicX
                        End With

                        If e.Location.X >= recPos.Left AndAlso e.Location.X <= recPos.Right Then
                            If e.Location.Y >= recPos.Top AndAlso e.Location.Y <= recPos.Bottom Then '
                                If DragSkillSlotNum <> i Then
                                    'SendChangeSkillSlots(DragSkillSlotNum, i)
                                    Exit For
                                End If
                            End If
                        End If

                    Next

                End If

                DragSkillSlotNum = 0
            ElseIf AboveHotbar(x, y) Then
                If DragSkillSlotNum > 0 Then
                    hotbarslot = IsHotBarSlot(e.Location.X, e.Location.Y)
                    If hotbarslot > 0 Then
                        SendSetHotbarSlot(hotbarslot, DragSkillSlotNum, 1)
                    End If
                End If

                DragSkillSlotNum = 0
            End If
        End If

        'banco
        If PnlBankVisible = True Then
            If AboveBankpanel(x, y) Then
                ' TODO : Adicionar função para mudar os bankslots primeiro no cliente para que não haja delay na troca
                If DragBankSlotNum > 0 Then
                    For i = 1 To MAX_BANK
                        With recPos
                            .Y = BankWindowY + BankTop + ((BankOffsetY + 32) * ((i - 1) \ BankColumns))
                            .Height = PicY
                            .X = BankWindowX + BankLeft + ((BankOffsetX + 32) * (((i - 1) Mod BankColumns)))
                            .Width = PicX
                        End With

                        If x >= recPos.Left AndAlso x <= recPos.Right Then
                            If y >= recPos.Top AndAlso y <= recPos.Bottom Then
                                If DragBankSlotNum <> i Then
                                    ChangeBankSlots(DragBankSlotNum, i)
                                    Exit For
                                End If
                            End If
                        End If
                    Next
                End If

                DragBankSlotNum = 0
            End If
        End If

    End Function

    Friend Function CheckGuiMouseDown(x As Integer, y As Integer, e As MouseEventArgs) As Boolean
        Dim invNum As Integer, skillnum As Integer, bankNum As Integer, shopItem As Integer

        'Inventario
        If PnlInventoryVisible Then
            If AboveInvpanel(x, y) Then
                invNum = IsInvItem(e.Location.X, e.Location.Y)

                If e.Button = MouseButtons.Left Then
                    If invNum <> 0 Then
                        If InTrade Then Exit Function
                        If InBank OrElse InShop Then Exit Function
                        DragInvSlotNum = invNum
                    End If
                ElseIf e.Button = MouseButtons.Right Then
                    If Not InBank AndAlso Not InShop AndAlso Not InTrade Then
                        If invNum <> 0 Then
                            If Item(GetPlayerInvItemNum(Myindex, invNum)).Type = ItemType.Currency OrElse Item(GetPlayerInvItemNum(Myindex, invNum)).Stackable = 1 Then
                                If GetPlayerInvItemValue(Myindex, invNum) > 0 Then
                                    CurrencyMenu = 1 ' largar
                                    FrmGame.lblCurrency.Text = "Quantos você quer largar?"
                                    TmpCurrencyItem = invNum
                                    FrmGame.txtCurrency.Text = ""
                                    FrmGame.pnlCurrency.Visible = True
                                    FrmGame.txtCurrency.Focus()
                                End If
                            Else
                                SendDropItem(invNum, 0)
                            End If
                        End If
                    End If
                End If
            End If
        End If

        'habilidades
        If PnlSkillsVisible = True Then
            If AboveSkillpanel(x, y) Then
                skillnum = IsPlayerSkill(e.Location.X, e.Location.Y)
                If e.Button = MouseButtons.Left Then
                    If skillnum <> 0 Then
                        If InTrade Then Exit Function

                        DragSkillSlotNum = skillnum

                        If SelSkillSlot = True Then
                            SendSetHotbarSlot(SelHotbarSlot, skillnum, 1)
                        End If
                    End If
                ElseIf e.Button = MouseButtons.Right Then ' botao dierito

                    If skillnum <> 0 Then
                        Dim result1 As DialogResult = MessageBox.Show("Quer esquecer essa habilidade?", Settings.GameName, MessageBoxButtons.YesNo)
                        If result1 = DialogResult.Yes Then
                            ForgetSkill(skillnum)
                            Exit Function
                        End If
                    End If
                End If
            End If
        End If

        'Banco
        If PnlBankVisible = True Then
            If AboveBankpanel(x, y) Then
                bankNum = IsBankItem(x, y)

                If bankNum <> 0 Then

                    If e.Button = MouseButtons.Left Then
                        DragBankSlotNum = bankNum
                    End If

                End If
            End If
        End If

        'Loja
        If PnlShopVisible = True Then
            If AboveShoppanel(x, y) Then
                shopItem = IsShopItem(x, y)

                If shopItem > 0 Then
                    Select Case ShopAction
                        Case 0 ' sem açao, dar custo
                            With Shop(InShop).TradeItem(shopItem)
                                AddText("Você pode comprar esse item por " & .CostValue & " " & Trim$(Item(.CostItem).Name) & ".", ColorType.Yellow)
                            End With
                        Case 1 ' comprar item
                            ' comprar código do item
                            BuyItem(shopItem)
                    End Select
                Else
                    ' ver botão de compra
                    If x > ShopWindowX + ShopButtonBuyX AndAlso x < ShopWindowX + ShopButtonBuyX + ButtonGfxInfo.Width Then
                        If y > ShopWindowY + ShopButtonBuyY AndAlso y < ShopWindowY + ShopButtonBuyY + ButtonGfxInfo.Height Then
                            If ShopAction = 1 Then Exit Function
                            ShopAction = 1 ' comprando um item
                            AddText("Clique no item que você quer comprar.", ColorType.Yellow)
                        End If
                    End If
                    ' ver botão de venda
                    If x > ShopWindowX + ShopButtonSellX AndAlso x < ShopWindowX + ShopButtonSellX + ButtonGfxInfo.Width Then
                        If y > ShopWindowY + ShopButtonSellY AndAlso y < ShopWindowY + ShopButtonSellY + ButtonGfxInfo.Height Then
                            If ShopAction = 2 Then Exit Function
                            ShopAction = 2 ' selling an item
                            AddText("Dê duplo-clique no item de seu inventário que você quer vender.", ColorType.Yellow)
                        End If
                    End If
                    ' ver botão de fechar
                    If x > ShopWindowX + ShopButtonCloseX AndAlso x < ShopWindowX + ShopButtonCloseX + ButtonGfxInfo.Width Then
                        If y > ShopWindowY + ShopButtonCloseY AndAlso y < ShopWindowY + ShopButtonCloseY + ButtonGfxInfo.Height Then
                            Dim buffer As ByteStream
                            buffer = New ByteStream(4)
                            buffer.WriteInt32(ClientPackets.CCloseShop)
                            Socket.SendData(buffer.Data, buffer.Head)
                            buffer.Dispose()
                            PnlShopVisible = False
                            InShop = 0
                            ShopAction = 0
                        End If
                    End If
                End If
            End If
        End If

        If HudVisible = True Then
            If AboveChatScrollUp(x, y) Then
                If ScrollMod + FirstLineindex < MaxChatDisplayLines Then
                    ScrollMod += 1
                End If
            End If
            If AboveChatScrollDown(x, y) Then
                If ScrollMod - 1 >= 0 Then
                    ScrollMod -= 1
                End If
            End If
        End If

    End Function

#Region "Support Functions"

    Function IsEqItem(x As Single, y As Single) As Integer
        Dim tempRec As Rect
        Dim i As Integer
        IsEqItem = 0

        For i = 1 To EquipmentType.Count - 1

            If GetPlayerEquipment(Myindex, i) > 0 AndAlso GetPlayerEquipment(Myindex, i) <= MAX_ITEMS Then

                With tempRec
                    .Top = CharWindowY + EqTop + ((EqOffsetY + 32) * ((i - 1) \ EqColumns))
                    .Bottom = .Top + PicY
                    .Left = CharWindowX + EqLeft + ((EqOffsetX + 32) * (((i - 1) Mod EqColumns)))
                    .Right = .Left + PicX
                End With

                If x >= tempRec.Left AndAlso x <= tempRec.Right Then
                    If y >= tempRec.Top AndAlso y <= tempRec.Bottom Then
                        IsEqItem = i
                        Exit Function
                    End If
                End If
            End If

        Next

    End Function

    Function IsInvItem(x As Single, y As Single) As Integer
        Dim tempRec As Rect
        Dim i As Integer
        IsInvItem = 0

        For i = 1 To MAX_INV

            If GetPlayerInvItemNum(Myindex, i) > 0 AndAlso GetPlayerInvItemNum(Myindex, i) <= MAX_ITEMS Then

                With tempRec
                    .Top = InvWindowY + InvTop + ((InvOffsetY + 32) * ((i - 1) \ InvColumns))
                    .Bottom = .Top + PicY
                    .Left = InvWindowX + InvLeft + ((InvOffsetX + 32) * (((i - 1) Mod InvColumns)))
                    .Right = .Left + PicX
                End With

                If x >= tempRec.Left AndAlso x <= tempRec.Right Then
                    If y >= tempRec.Top AndAlso y <= tempRec.Bottom Then
                        IsInvItem = i
                        Exit Function
                    End If
                End If
            End If

        Next

    End Function

    Function IsPlayerSkill(x As Single, y As Single) As Integer
        Dim tempRec As Rect
        Dim i As Integer

        IsPlayerSkill = 0

        For i = 1 To MAX_PLAYER_SKILLS

            If PlayerSkills(i) > 0 AndAlso PlayerSkills(i) <= MAX_PLAYER_SKILLS Then

                With tempRec
                    .Top = SkillWindowY + SkillTop + ((SkillOffsetY + 32) * ((i - 1) \ SkillColumns))
                    .Bottom = .Top + PicY
                    .Left = SkillWindowX + SkillLeft + ((SkillOffsetX + 32) * (((i - 1) Mod SkillColumns)))
                    .Right = .Left + PicX
                End With

                If x >= tempRec.Left AndAlso x <= tempRec.Right Then
                    If y >= tempRec.Top AndAlso y <= tempRec.Bottom Then
                        IsPlayerSkill = i
                        Exit Function
                    End If
                End If
            End If

        Next

    End Function

    Function IsBankItem(x As Single, y As Single) As Integer
        Dim tempRec As Rect
        Dim i As Integer

        IsBankItem = 0

        For i = 1 To MAX_BANK
            If GetBankItemNum(i) > 0 AndAlso GetBankItemNum(i) <= MAX_ITEMS Then

                With tempRec
                    .Top = BankWindowY + BankTop + ((BankOffsetY + 32) * ((i - 1) \ BankColumns))
                    .Bottom = .Top + PicY
                    .Left = BankWindowX + BankLeft + ((BankOffsetX + 32) * (((i - 1) Mod BankColumns)))
                    .Right = .Left + PicX
                End With

                If x >= tempRec.Left AndAlso x <= tempRec.Right Then
                    If y >= tempRec.Top AndAlso y <= tempRec.Bottom Then

                        IsBankItem = i
                        Exit Function
                    End If
                End If
            End If
        Next
    End Function

    Function IsShopItem(x As Single, y As Single) As Integer
        Dim tempRec As Rectangle
        Dim i As Integer
        IsShopItem = 0

        For i = 1 To MAX_TRADES

            If Shop(InShop).TradeItem(i).Item > 0 AndAlso Shop(InShop).TradeItem(i).Item <= MAX_ITEMS Then
                With tempRec
                    .Y = ShopWindowY + ShopTop + ((ShopOffsetY + 32) * ((i - 1) \ ShopColumns))
                    .Height = PicY
                    .X = ShopWindowX + ShopLeft + ((ShopOffsetX + 32) * (((i - 1) Mod ShopColumns)))
                    .Width = PicX
                End With

                If x >= tempRec.Left AndAlso x <= tempRec.Right Then
                    If y >= tempRec.Top AndAlso y <= tempRec.Bottom Then
                        IsShopItem = i
                        Exit Function
                    End If
                End If
            End If
        Next
    End Function

    Function IsTradeItem(x As Single, y As Single, yours As Boolean) As Integer
        Dim tempRec As Rect
        Dim i As Integer
        Dim itemnum As Integer

        IsTradeItem = 0

        For i = 1 To MAX_INV

            If yours Then
                itemnum = GetPlayerInvItemNum(Myindex, TradeYourOffer(i).Num)

                With tempRec
                    .Top = TradeWindowY + OurTradeY + InvTop + ((InvOffsetY + 32) * ((i - 1) \ InvColumns))
                    .Bottom = .Top + PicY
                    .Left = TradeWindowX + OurTradeX + InvLeft + ((InvOffsetX + 32) * (((i - 1) Mod InvColumns)))
                    .Right = .Left + PicX
                End With
            Else
                itemnum = TradeTheirOffer(i).Num

                With tempRec
                    .Top = TradeWindowY + TheirTradeY + InvTop + ((InvOffsetY + 32) * ((i - 1) \ InvColumns))
                    .Bottom = .Top + PicY
                    .Left = TradeWindowX + TheirTradeX + InvLeft + ((InvOffsetX + 32) * (((i - 1) Mod InvColumns)))
                    .Right = .Left + PicX
                End With
            End If

            If itemnum > 0 AndAlso itemnum <= MAX_ITEMS Then

                If x >= tempRec.Left AndAlso x <= tempRec.Right Then
                    If y >= tempRec.Top AndAlso y <= tempRec.Bottom Then
                        IsTradeItem = i
                        Exit Function
                    End If
                End If

            End If

        Next

    End Function

    Function AboveActionPanel(x As Single, y As Single) As Boolean
        AboveActionPanel = False

        If x > ActionPanelX AndAlso x < ActionPanelX + ActionPanelGfxInfo.Width Then
            If y > ActionPanelY AndAlso y < ActionPanelY + ActionPanelGfxInfo.Height Then
                AboveActionPanel = True
            End If
        End If
    End Function

    Function AboveHotbar(x As Single, y As Single) As Boolean
        AboveHotbar = False

        If x > HotbarX AndAlso x < HotbarX + HotBarGfxInfo.Width Then
            If y > HotbarY AndAlso y < HotbarY + HotBarGfxInfo.Height Then
                AboveHotbar = True
            End If
        End If
    End Function

    Function AbovePetbar(x As Single, y As Single) As Boolean
        AbovePetbar = False

        If x > PetbarX AndAlso x < PetbarX + PetbarGfxInfo.Width Then
            If y > PetbarY AndAlso y < PetbarY + HotBarGfxInfo.Height Then
                AbovePetbar = True
            End If
        End If
    End Function

    Function AboveInvpanel(x As Single, y As Single) As Boolean
        AboveInvpanel = False

        If x > InvWindowX AndAlso x < InvWindowX + InvPanelGfxInfo.Width Then
            If y > InvWindowY AndAlso y < InvWindowY + InvPanelGfxInfo.Height Then
                AboveInvpanel = True
            End If
        End If
    End Function

    Function AboveCharpanel(x As Single, y As Single) As Boolean
        AboveCharpanel = False

        If x > CharWindowX AndAlso x < CharWindowX + CharPanelGfxInfo.Width Then
            If y > CharWindowY AndAlso y < CharWindowY + CharPanelGfxInfo.Height Then
                AboveCharpanel = True
            End If
        End If
    End Function

    Function AboveSkillpanel(x As Single, y As Single) As Boolean
        AboveSkillpanel = False

        If x > SkillWindowX AndAlso x < SkillWindowX + SkillPanelGfxInfo.Width Then
            If y > SkillWindowY AndAlso y < SkillWindowY + SkillPanelGfxInfo.Height Then
                AboveSkillpanel = True
            End If
        End If
    End Function

    Function AboveBankpanel(x As Single, y As Single) As Boolean
        AboveBankpanel = False

        If x > BankWindowX AndAlso x < BankWindowX + BankPanelGfxInfo.Width Then
            If y > BankWindowY AndAlso y < BankWindowY + BankPanelGfxInfo.Height Then
                AboveBankpanel = True
            End If
        End If
    End Function

    Function AboveShoppanel(x As Single, y As Single) As Boolean
        AboveShoppanel = False

        If x > ShopWindowX AndAlso x < ShopWindowX + ShopPanelGfxInfo.Width Then
            If y > ShopWindowY AndAlso y < ShopWindowY + ShopPanelGfxInfo.Height Then
                AboveShoppanel = True
            End If
        End If
    End Function

    Function AboveTradepanel(x As Single, y As Single) As Boolean
        AboveTradepanel = False

        If x > TradeWindowX AndAlso x < TradeWindowX + TradePanelGfxInfo.Width Then
            If y > TradeWindowY AndAlso y < TradeWindowY + TradePanelGfxInfo.Height Then
                AboveTradepanel = True
            End If
        End If
    End Function

    Function AboveEventChat(x As Single, y As Single) As Boolean
        AboveEventChat = False

        If x > EventChatX AndAlso x < EventChatX + EventChatGfxInfo.Width Then
            If y > EventChatY AndAlso y < EventChatY + EventChatGfxInfo.Height Then
                AboveEventChat = True
            End If
        End If
    End Function

    Function AboveChatScrollUp(x As Single, y As Single) As Boolean
        AboveChatScrollUp = False

        If x > ChatWindowX + ChatWindowGfxInfo.Width - 24 AndAlso x < ChatWindowX + ChatWindowGfxInfo.Width Then
            If y > ChatWindowY AndAlso y < ChatWindowY + 24 Then 'ChatWindowGFXInfo.height Then
                AboveChatScrollUp = True
            End If
        End If
    End Function

    Function AboveChatScrollDown(x As Single, y As Single) As Boolean
        AboveChatScrollDown = False

        If x > ChatWindowX + ChatWindowGfxInfo.Width - 24 AndAlso x < ChatWindowX + ChatWindowGfxInfo.Width Then
            If y > ChatWindowY + ChatWindowGfxInfo.Height - 24 AndAlso y < ChatWindowY + ChatWindowGfxInfo.Height Then
                AboveChatScrollDown = True
            End If
        End If
    End Function

    Function AboveRClickPanel(x As Single, y As Single) As Boolean
        AboveRClickPanel = False

        If x > RClickX AndAlso x < RClickX + RClickGfxInfo.Width Then
            If y > RClickY AndAlso y < RClickY + RClickGfxInfo.Height Then
                AboveRClickPanel = True
            End If
        End If
    End Function

    Function AboveQuestPanel(x As Single, y As Single) As Boolean
        AboveQuestPanel = False

        If x > QuestLogX AndAlso x < QuestLogX + QuestGfxInfo.Width Then
            If y > QuestLogY AndAlso y < QuestLogY + QuestGfxInfo.Height Then
                AboveQuestPanel = True
            End If
        End If
    End Function

    Function AboveCraftPanel(x As Single, y As Single) As Boolean
        AboveCraftPanel = False

        If x > CraftPanelX AndAlso x < CraftPanelX + CraftGfxInfo.Width Then
            If y > CraftPanelY AndAlso y < CraftPanelY + CraftGfxInfo.Height Then
                AboveCraftPanel = True
            End If
        End If
    End Function

#End Region

End Module