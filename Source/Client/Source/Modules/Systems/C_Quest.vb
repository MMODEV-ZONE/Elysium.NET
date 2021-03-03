Imports ASFW

Friend Module C_Quest

#Region "Global Info"

    'Constantes
    Friend Const MaxQuests As Integer = 250

    'Friend Const MAX_TASKS As Byte = 10
    'Friend Const MAX_REQUIREMENTS As Byte = 10
    Friend Const EditorTasks As Byte = 7

    'Friend Const QUEST_TYPE_GOSLAY As Byte = 1
    'Friend Const QUEST_TYPE_GOCOLLECT As Byte = 2
    'Friend Const QUEST_TYPE_GOTALK As Byte = 3
    'Friend Const QUEST_TYPE_GOREACH As Byte = 4
    'Friend Const QUEST_TYPE_GOGIVE As Byte = 5
    'Friend Const QUEST_TYPE_GOKILL As Byte = 6
    'Friend Const QUEST_TYPE_GOGATHER As Byte = 7
    'Friend Const QUEST_TYPE_GOFETCH As Byte = 8
    'Friend Const QUEST_TYPE_TALKEVENT As Byte = 9

    'Friend Const QUEST_NOT_STARTED As Byte = 0
    'Friend Const QUEST_STARTED As Byte = 1
    'Friend Const QUEST_COMPLETED As Byte = 2
    'Friend Const QUEST_REPEATABLE As Byte = 3

    Friend QuestLogPage As Integer
    Friend QuestNames(MaxActivequests) As String

    Friend QuestChanged(MaxQuests) As Boolean

    Friend QuestEditorShow As Boolean

    'variáveis de log

    Friend Const MaxActivequests = 10

    Friend QuestLogX As Integer = 150
    Friend QuestLogY As Integer = 100

    Friend PnlQuestLogVisible As Boolean
    Friend SelectedQuest As Integer
    Friend QuestTaskLogText As String = ""
    Friend ActualTaskText As String = ""
    Friend QuestDialogText As String = ""
    Friend QuestStatus2Text As String = ""
    Friend AbandonQuestText As String = ""
    Friend AbandonQuestVisible As Boolean
    Friend QuestRequirementsText As String = ""
    Friend QuestRewardsText() As String

    'guardar informacoes temporarias
    Friend UpdateQuestWindow As Boolean

    Friend UpdateQuestChat As Boolean
    Friend QuestNum As Integer
    Friend QuestNumForStart As Integer
    Friend QuestMessage As String
    Friend QuestAcceptTag As Integer

    'Tipes
    Friend Quest(MaxQuests) As QuestRec

    Friend Structure PlayerQuestRec
        Dim Status As Integer '0=nao iniciado, 1=iniciado, 2=completo, 3=completo mas repetitivel
        Dim ActualTask As Integer
        Dim CurrentCount As Integer 'Usado para lidar com a propriedade de quantidade
    End Structure




#End Region

#Region "DataBase"

    Sub ClearQuest(questNum As Integer)
        Dim I As Integer

        ' limpar a Quest
        Quest(questNum).Name = ""
        Quest(questNum).QuestLog = ""
        Quest(questNum).Repeat = 0
        Quest(questNum).Cancelable = 0

        Quest(questNum).ReqCount = 0
        ReDim Quest(questNum).Requirement(Quest(questNum).ReqCount)
        ReDim Quest(questNum).RequirementIndex(Quest(questNum).ReqCount)
        For I = 1 To Quest(questNum).ReqCount
            Quest(questNum).Requirement(I) = 0
            Quest(questNum).RequirementIndex(I) = 0
        Next

        Quest(questNum).QuestGiveItem = 0
        Quest(questNum).QuestGiveItemValue = 0
        Quest(questNum).QuestRemoveItem = 0
        Quest(questNum).QuestRemoveItemValue = 0

        ReDim Quest(questNum).Chat(3)
        For I = 1 To 3
            Quest(questNum).Chat(I) = ""
        Next

        Quest(questNum).RewardCount = 0
        ReDim Quest(questNum).RewardItem(Quest(questNum).RewardCount)
        ReDim Quest(questNum).RewardItemAmount(Quest(questNum).RewardCount)
        For I = 1 To Quest(questNum).RewardCount
            Quest(questNum).RewardItem(I) = 0
            Quest(questNum).RewardItemAmount(I) = 0
        Next
        Quest(questNum).RewardExp = 0

        Quest(questNum).TaskCount = 0
        ReDim Quest(questNum).Task(Quest(questNum).TaskCount)
        For I = 1 To Quest(questNum).TaskCount
            Quest(questNum).Task(I).Order = 0
            Quest(questNum).Task(I).Npc = 0
            Quest(questNum).Task(I).Item = 0
            Quest(questNum).Task(I).Map = 0
            Quest(questNum).Task(I).Resource = 0
            Quest(questNum).Task(I).Amount = 0
            Quest(questNum).Task(I).Speech = ""
            Quest(questNum).Task(I).TaskLog = ""
            Quest(questNum).Task(I).QuestEnd = 0
            Quest(questNum).Task(I).TaskType = 0
        Next

    End Sub

    Sub ClearQuests()
        Dim I As Integer

        ReDim Quest(MaxQuests)

        For I = 1 To MaxQuests
            ClearQuest(I)
        Next
    End Sub

#End Region

#Region "Incoming Packets"

    Friend Sub Packet_QuestEditor(ByRef data() As Byte)
        QuestEditorShow = True
    End Sub

    Friend Sub Packet_UpdateQuest(ByRef data() As Byte)
        Dim questNum As Integer
        Dim buffer As New ByteStream(data)
        questNum = buffer.ReadInt32
        Quest(questNum) = DeserializeData(buffer)

        buffer.Dispose()
    End Sub

    Friend Sub Packet_PlayerQuest(ByRef data() As Byte)
        Dim questNum As Integer
        Dim buffer As New ByteStream(data)
        questNum = buffer.ReadInt32

        Player(Myindex).PlayerQuest(questNum).Status = buffer.ReadInt32
        Player(Myindex).PlayerQuest(questNum).ActualTask = buffer.ReadInt32
        Player(Myindex).PlayerQuest(questNum).CurrentCount = buffer.ReadInt32

        RefreshQuestLog()

        buffer.Dispose()
    End Sub

    Friend Sub Packet_PlayerQuests(ByRef data() As Byte)
        Dim I As Integer
        Dim buffer As New ByteStream(data)
        For I = 1 To MaxQuests
            Player(Myindex).PlayerQuest(I).Status = buffer.ReadInt32
            Player(Myindex).PlayerQuest(I).ActualTask = buffer.ReadInt32
            Player(Myindex).PlayerQuest(I).CurrentCount = buffer.ReadInt32
        Next

        RefreshQuestLog()

        buffer.Dispose()
    End Sub

    Friend Sub Packet_QuestMessage(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        QuestNum = buffer.ReadInt32
        QuestMessage = Trim$(buffer.ReadString)
        QuestMessage = QuestMessage.Replace("$playername$", GetPlayerName(Myindex))
        QuestNumForStart = buffer.ReadInt32

        UpdateQuestChat = True

        buffer.Dispose()
    End Sub

#End Region

#Region "Outgoing Packets"

    Friend Sub SendRequestEditQuest()
        Dim buffer As ByteStream

        buffer = New ByteStream(4)
        buffer.WriteInt32(ClientPackets.CRequestEditQuest)
        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

    Friend Sub SendRequestQuests()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CRequestQuests)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

    Friend Sub UpdateQuestLog()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CQuestLogUpdate)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

    Friend Sub PlayerHandleQuest(questNum As Integer, order As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CPlayerHandleQuest)
        buffer.WriteInt32(questNum)
        buffer.WriteInt32(order) '1=aceitar, 2=cancelar

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub QuestReset(questNum As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CQuestReset)
        buffer.WriteInt32(questNum)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

#End Region

#Region "Support Functions"

    'Diz se a quest está em progresso ou não
    Friend Function QuestInProgress(questNum As Integer) As Boolean
        QuestInProgress = False
        If questNum < 1 OrElse questNum > MaxQuests Then Exit Function

        If Player(Myindex).PlayerQuest(questNum).Status = QuestStatusType.Started Then 'Status=1 significa que começou
            QuestInProgress = True
        End If
    End Function

    Friend Function QuestCompleted(questNum As Integer) As Boolean
        QuestCompleted = False
        If questNum < 1 OrElse questNum > MaxQuests Then Exit Function

        If Player(Myindex).PlayerQuest(questNum).Status = QuestStatusType.Completed OrElse Player(Myindex).PlayerQuest(questNum).Status = QuestStatusType.Repeatable Then
            QuestCompleted = True
        End If
    End Function

    Friend Function GetQuestNum(questName As String) As Integer
        Dim I As Integer
        GetQuestNum = 0

        For I = 1 To MaxQuests
            If Trim$(Quest(I).Name) = Trim$(questName) Then
                GetQuestNum = I
                Exit For
            End If
        Next
    End Function

#End Region

#Region "Misc Functions"

    Friend Function CanStartQuest(questNum As Integer) As Boolean
        Dim i As Integer

        CanStartQuest = False

        If questNum < 1 OrElse questNum > MaxQuests Then Exit Function
        If QuestInProgress(questNum) Then Exit Function

        'ver se o jogador tem a quest 0 (não iniciada) ou 3 (completa mas repetitível)
        If Player(Myindex).PlayerQuest(questNum).Status = QuestStatusType.NotStarted OrElse Player(Myindex).PlayerQuest(questNum).Status = QuestStatusType.Repeatable Then

            For i = 1 To Quest(questNum).ReqCount
                'ver se item é necessário
                If Quest(questNum).Requirement(i) = 1 Then
                    If Quest(questNum).RequirementIndex(i) > 0 AndAlso Quest(questNum).RequirementIndex(i) <= MAX_ITEMS Then
                        If HasItem(Myindex, Quest(questNum).RequirementIndex(i)) = 0 Then
                            Exit Function
                        End If
                    End If
                End If

                'ver se tarefa anterior é necessário
                If Quest(questNum).Requirement(i) = 2 Then
                    If Quest(questNum).RequirementIndex(i) > 0 AndAlso Quest(questNum).RequirementIndex(i) <= MaxQuests Then
                        If Player(Myindex).PlayerQuest(Quest(questNum).RequirementIndex(i)).Status = QuestStatusType.NotStarted OrElse Player(Myindex).PlayerQuest(Quest(questNum).RequirementIndex(i)).Status = QuestStatusType.Started Then
                            Exit Function
                        End If
                    End If
                End If

            Next

            'Seguir
            CanStartQuest = True
        Else
            CanStartQuest = False
        End If
    End Function

    Friend Function CanEndQuest(index As Integer, questNum As Integer) As Boolean
        CanEndQuest = False

        If Player(index).PlayerQuest(questNum).ActualTask >= Quest(questNum).Task.Length Then
            CanEndQuest = True
        End If
        If Quest(questNum).Task(Player(index).PlayerQuest(questNum).ActualTask).QuestEnd = 1 Then
            CanEndQuest = True
        End If
    End Function

    Function HasItem(index As Integer, itemNum As Integer) As Integer
        Dim i As Integer

        ' Verificar por subscript out of range
        If IsPlaying(index) = False OrElse itemNum <= 0 OrElse itemNum > MAX_ITEMS Then
            Exit Function
        End If

        For i = 1 To MAX_INV

            ' Ver se o jogador tem o item
            If GetPlayerInvItemNum(index, i) = itemNum Then
                If Item(itemNum).Type = ItemType.Currency OrElse Item(itemNum).Stackable = 1 Then
                    HasItem = GetPlayerInvItemValue(index, i)
                Else
                    HasItem = 1
                End If

                Exit Function
            End If

        Next

    End Function

    Friend Sub RefreshQuestLog()
        Dim I As Integer, x As Integer

        For I = 1 To MaxActivequests
            QuestNames(I) = ""
        Next

        x = 1

        For I = 1 To MaxQuests
            If QuestInProgress(I) AndAlso x < MaxActivequests Then
                QuestNames(x) = Trim$(Quest(I).Name)
                x = x + 1
            End If
        Next

    End Sub

    ' ///////////////////////
    ' // Interação Visual  //
    ' ///////////////////////

    Friend Sub LoadQuestlogBox()
        Dim questNum As Integer, curTask As Integer, I As Integer

        If SelectedQuest = 0 Then Exit Sub

        For I = 1 To MaxQuests
            If Trim$(QuestNames(SelectedQuest)) = Trim$(Quest(I).Name) Then
                questNum = I
            End If
        Next

        If questNum = 0 Then Exit Sub

        curTask = Player(Myindex).PlayerQuest(questNum).ActualTask

        If curTask >= Quest(questNum).Task.Length Then Exit Sub

        'Quest Log (Tarefa Principal)
        QuestTaskLogText = Trim$(Quest(questNum).QuestLog)

        'Tarefa Atual
        QuestTaskLogText = Trim$(Quest(questNum).Task(curTask).TaskLog)

        'Última janela de diálogo
        If Player(Myindex).PlayerQuest(questNum).ActualTask > 1 Then
            If Len(Trim$(Quest(questNum).Task(curTask - 1).Speech)) > 0 Then
                QuestDialogText = Trim$(Quest(questNum).Task(curTask - 1).Speech).Replace("$playername$", GetPlayerName(Myindex))
            Else
                QuestDialogText = Trim$(Quest(questNum).Chat(1).Replace("$playername$", GetPlayerName(Myindex)))
            End If
        Else
            QuestDialogText = Trim$(Quest(questNum).Chat(1).Replace("$playername$", GetPlayerName(Myindex)))
        End If

        'Status da Tarefa
        If Player(Myindex).PlayerQuest(questNum).Status = QuestStatusType.Started Then
            QuestStatus2Text = Language.Quest.Started
            AbandonQuestText = Language.Quest.Cancel
            AbandonQuestVisible = True
        ElseIf Player(Myindex).PlayerQuest(questNum).Status = QuestStatusType.Completed Then
            QuestStatus2Text = Language.Quest.Completed
            AbandonQuestVisible = False
        Else
            QuestStatus2Text = "???"
            AbandonQuestVisible = False
        End If

        Select Case Quest(questNum).Task(curTask).TaskType
                'derrotar x npcs
            Case QuestType.Slay
                Dim curCount As Integer = Player(Myindex).PlayerQuest(questNum).CurrentCount
                Dim maxAmount As Integer = Quest(questNum).Task(curTask).Amount
                Dim npcName As String = Npc(Quest(questNum).Task(curTask).Npc).Name
                ActualTaskText = String.Format(Language.Quest.Slay, curCount, maxAmount, npcName)'"Derrotar " & CurCount & "/" & MaxAmount & " " & NpcName
                'pegar x quantidade de itens
            Case QuestType.Collect
                Dim curCount As Integer = Player(Myindex).PlayerQuest(questNum).CurrentCount
                Dim maxAmount As Integer = Quest(questNum).Task(curTask).Amount
                Dim itemName As String = Item(Quest(questNum).Task(curTask).Item).Name
                ActualTaskText = String.Format(Language.Quest.Collect, curCount, maxAmount, itemName)'"Coletar " & CurCount & "/" & MaxAmount & " " & ItemName
                'falar com npc
            Case QuestType.Talk
                Dim npcName As String = Npc(Quest(questNum).Task(curTask).Npc).Name
                ActualTaskText = String.Format(Language.Quest.Talk, npcName)'"Falar com  " & NpcName
                'chegar a certo mapa
            Case QuestType.Reach
                Dim mapName As String = MapNames(Quest(questNum).Task(curTask).Map)
                ActualTaskText = String.Format(Language.Quest.Reach, mapName)'"Ir para " & MapName
            Case QuestType.Give
                'dar x quantidade de itens para npc
                Dim npcName As String = Npc(Quest(questNum).Task(curTask).Npc).Name
                Dim curCount As Integer = HasItem(Myindex, Quest(questNum).Task(curTask).Item)
                Dim maxAmount As Integer = Quest(questNum).Task(curTask).Amount
                Dim itemName As String = Item(Quest(questNum).Task(curTask).Item).Name
                ActualTaskText = String.Format(Language.Quest.TurnIn, npcName, itemName, curCount, maxAmount)'"Dar a" & NpcName & " o " & ItemName & CurCount & "/" & MaxAmount & " que ele pediu"
                'derrotar certa quantidade de jogadores
            Case QuestType.Kill
                Dim curCount As Integer = Player(Myindex).PlayerQuest(questNum).CurrentCount
                Dim maxAmount As Integer = Quest(questNum).Task(curTask).Amount
                ActualTaskText = String.Format(Language.Quest.Kill, curCount, maxAmount)'"Derrotar " & CurCount & "/" & MaxAmount & " JOgadores em batalha"
                'ir coletar recursos
            Case QuestType.Gather
                Dim curCount As Integer = Player(Myindex).PlayerQuest(questNum).CurrentCount
                Dim maxAmount As Integer = Quest(questNum).Task(curTask).Amount
                Dim resourceName As String = Resource(Quest(questNum).Task(curTask).Resource).Name
                ActualTaskText = String.Format(Language.Quest.Gather, curCount, maxAmount, resourceName)'"Gather " & CurCount & "/" & MaxAmount & " " & ResourceName
                'pegar x quantidade de itens de npcs
            Case QuestType.Fetch
                Dim npcName As String = Item(Quest(questNum).Task(curTask).Npc).Name
                Dim maxAmount As Integer = Quest(questNum).Task(curTask).Amount
                Dim itemName As String = Item(Quest(questNum).Task(curTask).Item).Name
                ActualTaskText = String.Format(Language.Quest.Fetch, itemName, maxAmount, npcName) '"Pegar " & ItemName & "X" & MaxAmount & " de " & NpcName
            Case Else
                'ToDo
                ActualTaskText = "errr..."
        End Select

        'Recompensa
        ReDim QuestRewardsText(Quest(questNum).RewardCount + 1)
        For I = 1 To Quest(questNum).RewardCount
            QuestRewardsText(I) = Item(Quest(questNum).RewardItem(I)).Name & " X" & Str(Quest(questNum).RewardItemAmount(I))
        Next
        QuestRewardsText(I) = Str(Quest(questNum).RewardExp) & " EXP"
    End Sub

    Friend Sub DrawQuestLog()
        Dim i As Integer, y As Integer

        y = 10

        'Renderizar painel
        RenderSprite(QuestSprite, GameWindow, QuestLogX, QuestLogY, 0, 0, QuestGfxInfo.Width, QuestGfxInfo.Height)

        'desenhar nome da quest
        For i = 1 To MaxActivequests
            If Len(Trim$(QuestNames(i))) > 0 Then
                DrawText(QuestLogX + 7, QuestLogY + y, Trim$(QuestNames(i)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
                y = y + 20
            End If
        Next

        If SelectedQuest <= 0 Then Exit Sub

        'texto do log da tarefa
        y = 0
        For Each str As String In WordWrap(Trim$(QuestTaskLogText), 35, WrapMode.Characters, WrapType.BreakWord)
            'descrição
            DrawText(QuestLogX + 204, QuestLogY + 30 + y, str, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
            y = y + 15
        Next

        y = 0
        For Each str As String In WordWrap(Trim$(ActualTaskText), 40, WrapMode.Characters, WrapType.BreakWord)
            'descrição
            DrawText(QuestLogX + 204, QuestLogY + 147 + y, str, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
            y = y + 15
        Next

        y = 0
        For Each str As String In WordWrap(Trim$(QuestDialogText), 40, WrapMode.Characters, WrapType.BreakWord)

            'descrição
            DrawText(QuestLogX + 204, QuestLogY + 218 + y, str.Replace(vbCrLf, String.Empty), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
            y = y + 15
        Next
        DrawText(QuestLogX + 280, QuestLogY + 263, Trim$(QuestStatus2Text), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)



        If Not (QuestRewardsText Is Nothing) Then
            y = 0
            For i = 1 To QuestRewardsText.Length - 1
                'descrição
                DrawText(QuestLogX + 255, QuestLogY + 292 + y, Trim$(QuestRewardsText(i)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
                y = y + 15
            Next
        End If

    End Sub

    Friend Sub ResetQuestLog()

        QuestTaskLogText = ""
        ActualTaskText = ""
        QuestDialogText = ""
        QuestStatus2Text = ""
        AbandonQuestText = ""
        AbandonQuestVisible = False
        QuestRequirementsText = ""
        ReDim QuestRewardsText(0)
        PnlQuestLogVisible = False

        SelectedQuest = 0
    End Sub

    Friend Sub LoadRequirement(QuestNum As Integer, ReqNum As Integer)
        Dim i As Integer

        With frmEditor_Quest
            'Encher comboboxes
            .cmbItemReq.Items.Clear()
            .cmbItemReq.Items.Add("Nenhum")

            For i = 1 To MAX_ITEMS
                .cmbItemReq.Items.Add(i & ": " & Item(i).Name)
            Next

            .cmbQuestReq.Items.Clear()
            .cmbQuestReq.Items.Add("Nenhum")

            For i = 1 To MaxQuests
                .cmbQuestReq.Items.Add(i & ": " & Quest(i).Name)
            Next

            .cmbClassReq.Items.Clear()
            .cmbClassReq.Items.Add("Nenhum")

            For i = 1 To MAX_CLASSES
                .cmbClassReq.Items.Add(i & ": " & Classes(i).Name)
            Next

            .cmbItemReq.Enabled = False
            .cmbQuestReq.Enabled = False
            .cmbClassReq.Enabled = False

            Select Case Quest(QuestNum).Requirement(ReqNum)
                Case 0
                    .rdbNoneReq.Checked = True
                Case 1
                    .rdbItemReq.Checked = True
                    .cmbItemReq.Enabled = True
                    .cmbItemReq.SelectedIndex = Quest(QuestNum).RequirementIndex(ReqNum)
                Case 2
                    .rdbQuestReq.Checked = True
                    .cmbQuestReq.Enabled = True
                    .cmbQuestReq.SelectedIndex = Quest(QuestNum).RequirementIndex(ReqNum)
                Case 3
                    .rdbClassReq.Checked = True
                    .cmbClassReq.Enabled = True
                    .cmbClassReq.SelectedIndex = Quest(QuestNum).RequirementIndex(ReqNum)
            End Select

        End With

    End Sub

    'Subrotina que carrega a tarefa no formulário
    Friend Sub LoadTask(QuestNum As Integer, TaskNum As Integer)
        Dim TaskToLoad As TaskRec
        If TaskNum >= Quest(QuestNum).Task.Length Then Exit Sub

        TaskToLoad = Quest(QuestNum).Task(TaskNum)

        With frmEditor_Quest
            'Carregar o tipo de tarefa
            Select Case TaskToLoad.Order
                Case 0
                    .optTask0.Checked = True
                Case 1
                    .optTask1.Checked = True
                Case 2
                    .optTask2.Checked = True
                Case 3
                    .optTask3.Checked = True
                Case 4
                    .optTask4.Checked = True
                Case 5
                    .optTask5.Checked = True
                Case 6
                    .optTask6.Checked = True
                Case 7
                    .optTask7.Checked = True
            End Select

            'Carregar caixas de textos
            .txtTaskLog.Text = "" & Trim$(TaskToLoad.TaskLog)
            .txtTaskSpeech.Text = "" & Trim(TaskToLoad.Speech)

            'Encher combo boxes
            .cmbNpc.Items.Clear()
            .cmbNpc.Items.Add("Nenhum")

            For i = 1 To MAX_NPCS
                .cmbNpc.Items.Add(i & ": " & Npc(i).Name)
            Next

            .cmbItem.Items.Clear()
            .cmbItem.Items.Add("Nenhum")

            For i = 1 To MAX_ITEMS
                .cmbItem.Items.Add(i & ": " & Item(i).Name)
            Next

            .cmbMap.Items.Clear()
            .cmbMap.Items.Add("Nenhum")

            For i = 1 To MAX_MAPS
                .cmbMap.Items.Add(i)
            Next

            .cmbResource.Items.Clear()
            .cmbResource.Items.Add("Nenhum")

            For i = 1 To MAX_RESOURCES
                .cmbResource.Items.Add(i & ": " & Resource(i).Name)
            Next

            'Setar  combo para 0 e desativar para que possam ser ativados quando for necessário
            .cmbNpc.SelectedIndex = 0
            .cmbItem.SelectedIndex = 0
            .cmbMap.SelectedIndex = 0
            .cmbResource.SelectedIndex = 0
            .nudAmount.Value = 0

            .cmbNpc.Enabled = False
            .cmbItem.Enabled = False
            .cmbMap.Enabled = False
            .cmbResource.Enabled = False
            .nudAmount.Enabled = False

            If TaskToLoad.QuestEnd = 1 Then
                .chkEnd.Checked = True
            Else
                .chkEnd.Checked = False
            End If

            Select Case TaskToLoad.Order
                Case 0 'Nada

                Case QuestType.Slay '1
                    .cmbNpc.Enabled = True
                    .cmbNpc.SelectedIndex = TaskToLoad.Npc
                    .nudAmount.Enabled = True
                    .nudAmount.Value = TaskToLoad.Amount

                Case QuestType.Collect '2
                    .cmbItem.Enabled = True
                    .cmbItem.SelectedIndex = TaskToLoad.Item
                    .nudAmount.Enabled = True
                    .nudAmount.Value = TaskToLoad.Amount

                Case QuestType.Talk '3
                    .cmbNpc.Enabled = True
                    .cmbNpc.SelectedIndex = TaskToLoad.Npc

                Case QuestType.Reach '4
                    .cmbMap.Enabled = True
                    .cmbMap.SelectedIndex = TaskToLoad.Map

                Case QuestType.Give '5
                    .cmbItem.Enabled = True
                    .cmbItem.SelectedIndex = TaskToLoad.Item
                    .nudAmount.Enabled = True
                    .nudAmount.Value = TaskToLoad.Amount
                    .cmbNpc.Enabled = True
                    .cmbNpc.SelectedIndex = TaskToLoad.Npc
                    .txtTaskSpeech.Text = "" & Trim$(TaskToLoad.Speech)

                Case QuestType.Kill '6
                    .cmbResource.Enabled = True
                    .cmbResource.SelectedIndex = TaskToLoad.Resource
                    .nudAmount.Enabled = True
                    .nudAmount.Value = TaskToLoad.Amount

                Case QuestType.Gather '7
                    .cmbNpc.Enabled = True
                    .cmbNpc.SelectedIndex = TaskToLoad.Npc
                    .cmbItem.Enabled = True
                    .cmbItem.SelectedIndex = TaskToLoad.Item
                    .nudAmount.Enabled = True
                    .nudAmount.Value = TaskToLoad.Amount
                    .txtTaskSpeech.Text = "" & Trim$(TaskToLoad.Speech)
            End Select

            .lblTaskNum.Text = "Número da Tarefa: " & TaskNum
        End With
    End Sub

#End Region

#Region "Quest Editor"

    Friend Sub SendSaveQuest(QuestNum As Integer)
        Dim buffer As ByteStream

        buffer = New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CSaveQuest)
        buffer.WriteInt32(QuestNum)
        buffer.WriteBlock(SerializeData(Quest(QuestNum)))

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub
    Friend Sub QuestEditorInit()

        If frmEditor_Quest.Visible = False Then Exit Sub
        Editorindex = frmEditor_Quest.lstIndex.SelectedIndex + 1

        With frmEditor_Quest
            .txtName.Text = Trim$(Quest(Editorindex).Name)

            If Quest(Editorindex).Repeat = 1 Then
                .chkRepeat.Checked = True
            Else
                .chkRepeat.Checked = False
            End If

            .txtStartText.Text = Trim$(Quest(Editorindex).Chat(1))
            .txtProgressText.Text = Trim$(Quest(Editorindex).Chat(2))
            .txtEndText.Text = Trim$(Quest(Editorindex).Chat(3))

            .cmbStartItem.Items.Clear()
            .cmbItemReq.Items.Clear()
            .cmbEndItem.Items.Clear()
            .cmbItemReward.Items.Clear()
            .cmbStartItem.Items.Add("Nenhum")
            .cmbItemReq.Items.Add("Nenhum")
            .cmbEndItem.Items.Add("Nenhum")
            .cmbItemReward.Items.Add("Nenhum")

            For i = 1 To MAX_ITEMS
                .cmbStartItem.Items.Add(i & ": " & Item(i).Name)
                .cmbItemReq.Items.Add(i & ": " & Item(i).Name)
                .cmbEndItem.Items.Add(i & ": " & Item(i).Name)
                .cmbItemReward.Items.Add(i & ": " & Item(i).Name)
            Next

            .cmbStartItem.SelectedIndex = 0
            .cmbItemReq.SelectedIndex = 0
            .cmbEndItem.SelectedIndex = 0
            .cmbItemReward.SelectedIndex = 0

            .cmbClassReq.Items.Clear()
            .cmbClassReq.Items.Add("Nenhum")
            For i = 1 To MAX_CLASSES
                .cmbClassReq.Items.Add(Trim(Classes(i).Name))
            Next

            .cmbStartItem.SelectedIndex = Quest(Editorindex).QuestGiveItem
            .cmbEndItem.SelectedIndex = Quest(Editorindex).QuestRemoveItem

            .nudGiveAmount.Value = Quest(Editorindex).QuestGiveItemValue

            .nudTakeAmount.Value = Quest(Editorindex).QuestRemoveItemValue

            .lstRewards.Items.Clear()
            For i = 1 To Quest(Editorindex).RewardCount
                .lstRewards.Items.Add(i & ":" & Quest(Editorindex).RewardItemAmount(i) & " X " & Trim(Item(Quest(Editorindex).RewardItem(i)).Name))
            Next

            .nudExpReward.Value = Quest(Editorindex).RewardExp

            .lstRequirements.Items.Clear()

            For i = 1 To Quest(Editorindex).ReqCount

                Select Case Quest(Editorindex).Requirement(i)
                    Case 1
                        .lstRequirements.Items.Add(i & ":" & "Requerimento de Item: " & Trim(Item(Quest(Editorindex).RequirementIndex(i)).Name))
                    Case 2
                        .lstRequirements.Items.Add(i & ":" & "Requerimento de Tarefa: " & Trim(Quest(Quest(Editorindex).RequirementIndex(i)).Name))
                    Case 3
                        .lstRequirements.Items.Add(i & ":" & "Requerimento de Classe: " & Trim(Classes(Quest(Editorindex).RequirementIndex(i)).Name))
                    Case Else
                        .lstRequirements.Items.Add(i & ":")
                End Select
            Next

            .lstTasks.Items.Clear()
            For i = 1 To Quest(Editorindex).TaskCount
                frmEditor_Quest.lstTasks.Items.Add(i & ":" & Quest(Editorindex).Task(i).TaskLog)
            Next

            .rdbNoneReq.Checked = True
        End With

        QuestChanged(Editorindex) = True

    End Sub

    Friend Sub QuestEditorOk()
        Dim I As Integer

        For I = 1 To MaxQuests
            If QuestChanged(I) Then
                SendSaveQuest(I)
            End If
        Next

        frmEditor_Quest.Dispose()
        Editor = 0
        ClearChanged_Quest()

    End Sub

    Friend Sub QuestEditorCancel()
        Editor = 0
        frmEditor_Quest.Dispose()
        ClearChanged_Quest()
        ClearQuests()
        SendRequestQuests()
    End Sub

    Friend Sub ClearChanged_Quest()
        Dim I As Integer

        For I = 0 To MaxQuests
            QuestChanged(I) = False
        Next
    End Sub

#End Region

End Module