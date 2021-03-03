Imports System.IO
Imports ASFW
Imports ASFW.IO.FileIO

Friend Module S_Quest

#Region "Constants"

    'Constantes
    Friend Const MAX_QUESTS As Integer = 250

    'Friend Const MAX_TASKS As Byte = 10
    'Friend Const MAX_REQUIREMENTS As Byte = 10
    Friend Const MAX_ACTIVEQUESTS = 10

    Friend Const EDITOR_TASKS As Byte = 7

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

    'Tipo
    Friend Quest(MAX_QUESTS) As QuestRec

    <Serializable>
    Friend Structure PlayerQuestRec
        Dim Status As Integer '0=nao iniciado, 1=iniciado, 2=completo, 3=completo mas repetível
        Dim ActualTask As Integer
        Dim CurrentCount As Integer 'Usado para lidar com o atributo de quantidade
    End Structure

#End Region

#Region "Database"

    Sub SaveQuests()
        Dim I As Integer
        For I = 1 To MAX_QUESTS
            SaveQuest(I)
            Application.DoEvents()
        Next
    End Sub

    Sub SaveQuest(QuestNum As Integer)
        Dim filename As String
        Dim I As Integer
        filename = Path.Quest(QuestNum)

        Dim writer As New ByteStream(100)

        writer.WriteString(Quest(QuestNum).Name)
        writer.WriteString(Quest(QuestNum).QuestLog)
        writer.WriteByte(Quest(QuestNum).Repeat)
        writer.WriteByte(Quest(QuestNum).Cancelable)

        writer.WriteInt32(Quest(QuestNum).ReqCount)
        For I = 1 To Quest(QuestNum).ReqCount
            writer.WriteInt32(Quest(QuestNum).Requirement(I))
            writer.WriteInt32(Quest(QuestNum).RequirementIndex(I))
        Next

        writer.WriteInt32(Quest(QuestNum).QuestGiveItem)
        writer.WriteInt32(Quest(QuestNum).QuestGiveItemValue)
        writer.WriteInt32(Quest(QuestNum).QuestRemoveItem)
        writer.WriteInt32(Quest(QuestNum).QuestRemoveItemValue)

        For I = 1 To 3
            writer.WriteString(Quest(QuestNum).Chat(I))
        Next

        writer.WriteInt32(Quest(QuestNum).RewardCount)
        For I = 1 To Quest(QuestNum).RewardCount
            writer.WriteInt32(Quest(QuestNum).RewardItem(I))
            writer.WriteInt32(Quest(QuestNum).RewardItemAmount(I))
        Next
        writer.WriteInt32(Quest(QuestNum).RewardExp)

        writer.WriteInt32(Quest(QuestNum).TaskCount)
        For I = 1 To Quest(QuestNum).TaskCount
            writer.WriteInt32(Quest(QuestNum).Task(I).Order)
            writer.WriteInt32(Quest(QuestNum).Task(I).NPC)
            writer.WriteInt32(Quest(QuestNum).Task(I).Item)
            writer.WriteInt32(Quest(QuestNum).Task(I).Map)
            writer.WriteInt32(Quest(QuestNum).Task(I).Resource)
            writer.WriteInt32(Quest(QuestNum).Task(I).Amount)
            writer.WriteString(Quest(QuestNum).Task(I).Speech)
            writer.WriteString(Quest(QuestNum).Task(I).TaskLog)
            writer.WriteByte(Quest(QuestNum).Task(I).QuestEnd)
            writer.WriteInt32(Quest(QuestNum).Task(I).TaskType)
        Next

        BinaryFile.Save(filename, writer)
    End Sub

    Sub LoadQuests()
        Dim I As Integer

        CheckQuests()

        For I = 1 To MAX_QUESTS
            LoadQuest(I)
            Application.DoEvents()
        Next
    End Sub

    Sub LoadQuest(QuestNum As Integer)
        Dim FileName As String
        Dim I As Integer

        FileName = Path.Quest(QuestNum)

        Dim reader As New ByteStream()
        BinaryFile.Load(FileName, reader)

        Quest(QuestNum).Name = reader.ReadString()
        Quest(QuestNum).QuestLog = reader.ReadString()
        Quest(QuestNum).Repeat = reader.ReadByte()
        Quest(QuestNum).Cancelable = reader.ReadByte()

        Quest(QuestNum).ReqCount = reader.ReadInt32()
        ReDim Quest(QuestNum).Requirement(Quest(QuestNum).ReqCount)
        ReDim Quest(QuestNum).RequirementIndex(Quest(QuestNum).ReqCount)
        For I = 1 To Quest(QuestNum).ReqCount
            Quest(QuestNum).Requirement(I) = reader.ReadInt32()
            Quest(QuestNum).RequirementIndex(I) = reader.ReadInt32()
        Next

        Quest(QuestNum).QuestGiveItem = reader.ReadInt32()
        Quest(QuestNum).QuestGiveItemValue = reader.ReadInt32()
        Quest(QuestNum).QuestRemoveItem = reader.ReadInt32()
        Quest(QuestNum).QuestRemoveItemValue = reader.ReadInt32()

        For I = 1 To 3
            Quest(QuestNum).Chat(I) = reader.ReadString()
        Next

        Quest(QuestNum).RewardCount = reader.ReadInt32()
        ReDim Quest(QuestNum).RewardItem(Quest(QuestNum).RewardCount)
        ReDim Quest(QuestNum).RewardItemAmount(Quest(QuestNum).RewardCount)
        For I = 1 To Quest(QuestNum).RewardCount
            Quest(QuestNum).RewardItem(I) = reader.ReadInt32()
            Quest(QuestNum).RewardItemAmount(I) = reader.ReadInt32()
        Next
        Quest(QuestNum).RewardExp = reader.ReadInt32()

        Quest(QuestNum).TaskCount = reader.ReadInt32()
        ReDim Quest(QuestNum).Task(Quest(QuestNum).TaskCount)
        For I = 1 To Quest(QuestNum).TaskCount
            Quest(QuestNum).Task(I).Order = reader.ReadInt32()
            Quest(QuestNum).Task(I).NPC = reader.ReadInt32()
            Quest(QuestNum).Task(I).Item = reader.ReadInt32()
            Quest(QuestNum).Task(I).Map = reader.ReadInt32()
            Quest(QuestNum).Task(I).Resource = reader.ReadInt32()
            Quest(QuestNum).Task(I).Amount = reader.ReadInt32()
            Quest(QuestNum).Task(I).Speech = reader.ReadString()
            Quest(QuestNum).Task(I).TaskLog = reader.ReadString()
            Quest(QuestNum).Task(I).QuestEnd = reader.ReadByte()
            Quest(QuestNum).Task(I).TaskType = reader.ReadInt32()
        Next
    End Sub

    Sub CheckQuests()
        Dim I As Integer
        For I = 1 To MAX_QUESTS
            If Not File.Exists(Path.Quest(I)) Then
                SaveQuest(I)
                Application.DoEvents()
            End If
        Next
    End Sub

    Sub ClearQuest(QuestNum As Integer)
        Dim I As Integer

        ' limpar a Quest
        Quest(QuestNum).Name = ""
        Quest(QuestNum).QuestLog = ""
        Quest(QuestNum).Repeat = 0
        Quest(QuestNum).Cancelable = 0

        Quest(QuestNum).ReqCount = 0
        ReDim Quest(QuestNum).Requirement(Quest(QuestNum).ReqCount)
        ReDim Quest(QuestNum).RequirementIndex(Quest(QuestNum).ReqCount)
        For I = 1 To Quest(QuestNum).ReqCount
            Quest(QuestNum).Requirement(QuestNum) = 0
            Quest(QuestNum).RequirementIndex(QuestNum) = 0
        Next

        Quest(QuestNum).QuestGiveItem = 0
        Quest(QuestNum).QuestGiveItemValue = 0
        Quest(QuestNum).QuestRemoveItem = 0
        Quest(QuestNum).QuestRemoveItemValue = 0

        ReDim Quest(QuestNum).Chat(3)
        For I = 1 To 3
            Quest(QuestNum).Chat(I) = ""
        Next

        Quest(QuestNum).RewardCount = 0
        ReDim Quest(QuestNum).RewardItem(Quest(QuestNum).RewardCount)
        ReDim Quest(QuestNum).RewardItemAmount(Quest(QuestNum).RewardCount)
        For I = 1 To Quest(QuestNum).RewardCount
            Quest(QuestNum).RewardItem(I) = 0
            Quest(QuestNum).RewardItemAmount(I) = 0
        Next
        Quest(QuestNum).RewardExp = 0

        Quest(QuestNum).TaskCount = 0
        ReDim Quest(QuestNum).Task(Quest(QuestNum).TaskCount)
        For I = 1 To Quest(QuestNum).TaskCount
            Quest(QuestNum).Task(I).Order = 0
            Quest(QuestNum).Task(I).NPC = 0
            Quest(QuestNum).Task(I).Item = 0
            Quest(QuestNum).Task(I).Map = 0
            Quest(QuestNum).Task(I).Resource = 0
            Quest(QuestNum).Task(I).Amount = 0
            Quest(QuestNum).Task(I).Speech = ""
            Quest(QuestNum).Task(I).TaskLog = ""
            Quest(QuestNum).Task(I).QuestEnd = 0
            Quest(QuestNum).Task(I).TaskType = 0
        Next

    End Sub

    Sub ClearQuests()
        Dim I As Integer

        For I = 1 To MAX_QUESTS
            ClearQuest(I)
        Next
    End Sub

#End Region

#Region "Incoming Packets"

    Sub Packet_RequestEditQuest(index As Integer, ByRef data() As Byte)
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub

        Dim Buffer = New ByteStream(4)
        Buffer.WriteInt32(ServerPackets.SQuestEditor)
        Socket.SendDataTo(index, Buffer.Data, Buffer.Head)
        Buffer.Dispose()
    End Sub

    Sub Packet_SaveQuest(index As Integer, ByRef data() As Byte)
        Dim QuestNum As Integer
        Dim buffer As New ByteStream(data)
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub

        QuestNum = buffer.ReadInt32
        If QuestNum < 0 OrElse QuestNum > MAX_QUESTS Then Exit Sub

        Quest(QuestNum) = DeserializeData(buffer)


        buffer.Dispose()

        ' Salvar
        SendQuests(index) ' editor
        SendUpdateQuestToAll(QuestNum) 'jogadores
        SaveQuest(QuestNum)
        Addlog(GetPlayerLogin(index) & " salvou a Quest #" & QuestNum & ".", ADMIN_LOG)
    End Sub

    Sub Packet_RequestQuests(index As Integer, ByRef data() As Byte)
        SendQuests(index)
    End Sub

    Sub Packet_PlayerHandleQuest(index As Integer, ByRef data() As Byte)
        Dim QuestNum As Integer, Order As Integer ', I As Integer
        Dim buffer As New ByteStream(data)
        QuestNum = buffer.ReadInt32
        Order = buffer.ReadInt32 '1 = aceitar, 2 = cancelar

        If Order = 1 Then
            Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).Status = QuestStatusType.Started '1
            Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).ActualTask = 1
            Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).CurrentCount = 0
            PlayerMsg(index, "Nova quest aceita: " & Trim$(Quest(QuestNum).Name) & "!", ColorType.BrightGreen)
        ElseIf Order = 2 Then
            Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).Status = QuestStatusType.NotStarted '2
            Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).ActualTask = 1
            Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).CurrentCount = 0

            PlayerMsg(index, Trim$(Quest(QuestNum).Name) & " foi cancelada!", ColorType.BrightRed)

            If GetPlayerAccess(index) > 0 AndAlso QuestNum = 1 Then
                For I = 1 To MAX_QUESTS
                    Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(I).Status = QuestStatusType.NotStarted '2
                    Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(I).ActualTask = 1
                    Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(I).CurrentCount = 0
                Next
            End If
        End If

        SavePlayer(index)
        SendPlayerData(index)
        SendPlayerQuests(index)
        buffer.Dispose()
    End Sub

    Sub Packet_QuestLogUpdate(index As Integer, ByRef data() As Byte)
        SendPlayerQuests(index)
    End Sub

    Sub Packet_QuestReset(index As Integer, ByRef data() As Byte)
        Dim QuestNum As Integer

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then Exit Sub
        Dim buffer As New ByteStream(data)
        QuestNum = buffer.ReadInt32

        ResetQuest(index, QuestNum)

        buffer.Dispose()
    End Sub

#End Region

#Region "Outgoing packets"

    Sub SendQuests(index As Integer)
        Dim I As Integer

        For I = 1 To MAX_QUESTS
            If Len(Trim$(Quest(I).Name)) > 0 Then
                SendUpdateQuestTo(index, I)
            End If
        Next
    End Sub

    Sub SendUpdateQuestToAll(QuestNum As Integer)
        Dim buffer As ByteStream
        buffer = New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SUpdateQuest)
        buffer.WriteInt32(QuestNum)
        buffer.WriteBlock(SerializeData(Quest(QuestNum)))

        SendDataToAll(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendUpdateQuestTo(index As Integer, QuestNum As Integer)
        Dim buffer As ByteStream ', I As Integer
        buffer = New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SUpdateQuest)
        buffer.WriteInt32(QuestNum)

        buffer.WriteBlock(SerializeData(Quest(QuestNum)))

        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub SendPlayerQuests(index As Integer)
        Dim I As Integer
        Dim buffer As ByteStream
        buffer = New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SPlayerQuests)

        For I = 1 To MAX_QUESTS
            buffer.WriteInt32(Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(I).Status)
            buffer.WriteInt32(Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(I).ActualTask)
            buffer.WriteInt32(Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(I).CurrentCount)
        Next

        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

    Friend Sub SendPlayerQuest(index As Integer, QuestNum As Integer)
        Dim buffer As ByteStream

        buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SPlayerQuest)

        buffer.WriteInt32(QuestNum)
        buffer.WriteInt32(Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).Status)
        buffer.WriteInt32(Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).ActualTask)
        buffer.WriteInt32(Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).CurrentCount)

        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    'envia mensagem que é mostrada na tela para o cliente 
    Friend Sub QuestMessage(index As Integer, QuestNum As Integer, message As String, QuestNumForStart As Integer)
        If message = "" Then Exit Sub

        Dim buffer As ByteStream
        buffer = New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SQuestMessage)

        buffer.WriteInt32(QuestNum)
        buffer.WriteString(message)
        buffer.WriteInt32(QuestNumForStart)

        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

#End Region

#Region "Functions"

    Friend Sub ResetQuest(index As Integer, QuestNum As Integer)
        If GetPlayerAccess(index) > 0 Then
            Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).Status = QuestStatusType.NotStarted
            Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).ActualTask = 1
            Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).CurrentCount = 0

            SendPlayerQuests(index)
            PlayerMsg(index, "Quest " & QuestNum & " reset!", ColorType.BrightRed)
        End If
    End Sub

    Friend Function CanStartQuest(index As Integer, QuestNum As Integer) As Boolean
        CanStartQuest = False
        If QuestNum < 1 OrElse QuestNum > MAX_QUESTS Then Exit Function
        If QuestInProgress(index, QuestNum) Then Exit Function

        'Ver se o o jogador tem a quest 0 (não iniciada) ou 3 (completa mas pode fazer de novo)
        If Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).Status = QuestStatusType.NotStarted OrElse Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).Status = QuestStatusType.Repeatable Then
            For i = 1 To Quest(QuestNum).ReqCount
                'Ver se algum item é necessário
                If Quest(QuestNum).Requirement(i) = 1 Then
                    If Quest(QuestNum).RequirementIndex(i) > 0 AndAlso Quest(QuestNum).RequirementIndex(i) <= MAX_ITEMS Then
                        If HasItem(index, Quest(QuestNum).RequirementIndex(i)) = 0 Then
                            PlayerMsg(index, "Você precisa de " & Item(Quest(QuestNum).RequirementIndex(i)).Name & " para essa quest!", ColorType.Yellow)
                            Exit Function
                        End If
                    End If
                End If

                'Ver se uma quest anterior é necessária
                If Quest(QuestNum).Requirement(i) = 2 Then
                    If Quest(QuestNum).RequirementIndex(i) > 0 AndAlso Quest(QuestNum).RequirementIndex(i) <= MAX_QUESTS Then
                        If Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(Quest(QuestNum).RequirementIndex(i)).Status = QuestStatusType.NotStarted OrElse Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(Quest(QuestNum).RequirementIndex(i)).Status = QuestStatusType.Started Then
                            PlayerMsg(index, "Você precisa completar a quest " & Trim$(Quest(Quest(QuestNum).RequirementIndex(i)).Name) & " para começar esta!", ColorType.Yellow)
                            Exit Function
                        End If
                    End If
                End If

            Next

            'Siga em frente :)
            CanStartQuest = True
        Else
            'PlayerMsg Index, "Você não pode começar aquela quest de novo!", BrightRed
        End If
    End Function

    Friend Function CanEndQuest(index As Integer, QuestNum As Integer) As Boolean
        CanEndQuest = False

        If Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).ActualTask >= Quest(QuestNum).Task.Length Then
            CanEndQuest = True
        End If
        If Quest(QuestNum).Task(Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).ActualTask).QuestEnd = 1 Then
            CanEndQuest = True
        End If
    End Function

    'Fala se a quest está em progresso ou não
    Friend Function QuestInProgress(index As Integer, QuestNum As Integer) As Boolean
        QuestInProgress = False
        If QuestNum < 1 OrElse QuestNum > MAX_QUESTS Then Exit Function

        If Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).Status = QuestStatusType.Started Then 'Status=1 means started
            QuestInProgress = True
        End If
    End Function

    Friend Function QuestCompleted(index As Integer, QuestNum As Integer) As Boolean
        QuestCompleted = False
        If QuestNum < 1 OrElse QuestNum > MAX_QUESTS Then Exit Function

        If Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).Status = 2 OrElse Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).Status = 3 Then
            QuestCompleted = True
        End If
    End Function

    'Pegar o numero de referencia da quest do nome da quest (deve ser único)
    Friend Function GetQuestNum(QuestName As String) As Integer
        Dim I As Integer
        GetQuestNum = 0

        For I = 1 To MAX_QUESTS
            If Trim$(Quest(I).Name) = Trim$(QuestName) Then
                GetQuestNum = I
                Exit For
            End If
        Next
    End Function

    Friend Function GetItemNum(ItemName As String) As Integer
        Dim I As Integer
        GetItemNum = 0

        For I = 1 To MAX_ITEMS
            If Trim$(Item(I).Name) = Trim$(ItemName) Then
                GetItemNum = I
                Exit For
            End If
        Next
    End Function

    ' ////////////////////////
    ' // Propósitos Gerais //
    ' ///////////////////////

    Friend Sub CheckTasks(index As Integer, TaskType As Integer, Targetindex As Integer)
        Dim I As Integer

        For I = 1 To MAX_QUESTS
            If QuestInProgress(index, I) Then
                CheckTask(index, I, TaskType, Targetindex)
            End If
        Next
    End Sub

    Friend Sub CheckTask(index As Integer, QuestNum As Integer, TaskType As Integer, Targetindex As Integer)
        Dim ActualTask As Integer, I As Integer
        ActualTask = Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).ActualTask

        If ActualTask >= Quest(QuestNum).Task.Length Then Exit Sub

        Select Case TaskType
            Case QuestType.Slay 'derrotar X quantidade de X npc's.

                'o id do npc derrotado é o mesmo que tenho que derrotar?
                If Targetindex = Quest(QuestNum).Task(ActualTask).NPC Then
                    'Contador +1
                    Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).CurrentCount = Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).CurrentCount + 1
                    'acabei o trabalho?
                    If Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).CurrentCount >= Quest(QuestNum).Task(ActualTask).Amount Then
                        QuestMessage(index, QuestNum, Trim$(Quest(QuestNum).Task(ActualTask).TaskLog) & " - Tarefa completa", 0)
                        'is the quest's end?
                        If CanEndQuest(index, QuestNum) Then
                            EndQuest(index, QuestNum)
                        Else
                            'Caso contrário, continuar para a próxima
                            Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                        End If
                    End If
                End If

            Case QuestType.Collect 'Pegar X quantidade de X item.
                If Targetindex = Quest(QuestNum).Task(ActualTask).Item Then
                    Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).CurrentCount = Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).CurrentCount + 1
                    If Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).CurrentCount >= Quest(QuestNum).Task(ActualTask).Amount Then
                        QuestMessage(index, QuestNum, Trim$(Quest(QuestNum).Task(ActualTask).TaskLog) & " - Tarefa completa", 0)
                        If CanEndQuest(index, QuestNum) Then
                            EndQuest(index, QuestNum)
                        Else
                            Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                        End If
                    End If
                End If

            Case QuestType.Talk 'Interagir com X npc.
                If Targetindex = Quest(QuestNum).Task(ActualTask).NPC AndAlso Quest(QuestNum).Task(ActualTask).Amount = 0 Then
                    QuestMessage(index, QuestNum, Quest(QuestNum).Task(ActualTask).Speech, 0)
                    If CanEndQuest(index, QuestNum) Then
                        EndQuest(index, QuestNum)
                    Else
                        Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                    End If
                End If

            Case QuestType.Reach 'Reach X map.
                If Targetindex = Quest(QuestNum).Task(ActualTask).Map Then
                    QuestMessage(index, QuestNum, Trim$(Quest(QuestNum).Task(ActualTask).TaskLog) & " - Tarefa completa", 0)
                    If CanEndQuest(index, QuestNum) Then
                        EndQuest(index, QuestNum)
                    Else
                        Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                    End If
                End If

            Case QuestType.Give 'Dar X quantidade de X item para X npc.
                If Targetindex = Quest(QuestNum).Task(ActualTask).NPC Then
                    For I = 1 To MAX_INV
                        If GetPlayerInvItemNum(index, I) = Quest(QuestNum).Task(ActualTask).Item Then
                            If GetPlayerInvItemValue(index, I) >= Quest(QuestNum).Task(ActualTask).Amount Then
                                TakeInvItem(index, GetPlayerInvItemNum(index, I), Quest(QuestNum).Task(ActualTask).Amount)
                                If Quest(QuestNum).Task(ActualTask).Speech <> "" Then QuestMessage(index, QuestNum, Quest(QuestNum).Task(ActualTask).Speech, 0)
                                If CanEndQuest(index, QuestNum) Then
                                    EndQuest(index, QuestNum)
                                Else
                                    Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                                End If
                                Exit For
                            End If
                        End If
                    Next
                End If

            Case QuestType.Kill 'Matar X quantidade de jogadores.
                Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).CurrentCount = Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).CurrentCount + 1
                If Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).CurrentCount >= Quest(QuestNum).Task(ActualTask).Amount Then
                    QuestMessage(index, QuestNum, Trim$(Quest(QuestNum).Task(ActualTask).TaskLog) & " - Tarefa completa", 0)
                    If CanEndQuest(index, QuestNum) Then
                        EndQuest(index, QuestNum)
                    Else
                        Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                    End If
                End If

            Case QuestType.Gather 'Atingir X quantidade de vezes X recurso.
                If Targetindex = Quest(QuestNum).Task(ActualTask).Resource Then
                    Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).CurrentCount = Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).CurrentCount + 1
                    If Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).CurrentCount >= Quest(QuestNum).Task(ActualTask).Amount Then
                        QuestMessage(index, QuestNum, Trim$(Quest(QuestNum).Task(ActualTask).TaskLog) & " - Tarefa completa", 0)
                        If CanEndQuest(index, QuestNum) Then
                            EndQuest(index, QuestNum)
                        Else
                            Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                        End If
                    End If
                End If

            Case QuestType.Fetch 'Pegar X quantidade de X item do X npc.
                If Targetindex = Quest(QuestNum).Task(ActualTask).NPC Then
                    GiveInvItem(index, Quest(QuestNum).Task(ActualTask).Item, Quest(QuestNum).Task(ActualTask).Amount)
                    QuestMessage(index, QuestNum, Quest(QuestNum).Task(ActualTask).Speech, 0)
                    If CanEndQuest(index, QuestNum) Then
                        EndQuest(index, QuestNum)
                    Else
                        Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                    End If
                End If
        End Select

        SendPlayerQuest(index, QuestNum)
    End Sub

    Friend Sub ShowQuest(index As Integer, QuestNum As Integer)
        If QuestInProgress(index, QuestNum) Then
            QuestMessage(index, QuestNum, Trim$(Quest(QuestNum).Chat(2)), 0) 'mostrar mensagem enquanto isso
            Exit Sub
        End If
        If Not CanStartQuest(index, QuestNum) Then Exit Sub

        QuestMessage(index, QuestNum, Trim$(Quest(QuestNum).Chat(1)), QuestNum) 'chat 1 = pedir mensagem
    End Sub

    Friend Sub EndQuest(index As Integer, QuestNum As Integer)
        Dim I As Integer

        QuestMessage(index, QuestNum, Trim$(Quest(QuestNum).Chat(3)), 0)

        For I = 1 To Quest(QuestNum).RewardCount
            If Quest(QuestNum).RewardItem(I) > 0 Then
                PlayerMsg(index, "Você recebeu " & Quest(QuestNum).RewardItemAmount(I) & " " & Trim(Item(Quest(QuestNum).RewardItem(I)).Name), ColorType.BrightGreen)
            End If
            GiveInvItem(index, Quest(QuestNum).RewardItem(I), Quest(QuestNum).RewardItemAmount(I))
        Next

        If Quest(QuestNum).RewardExp > 0 Then
            SetPlayerExp(index, GetPlayerExp(index) + Quest(QuestNum).RewardExp)
            SendExp(index)
            ' Verificar subida de nível
            CheckPlayerLevelUp(index)
        End If

        'Ver se quest é repetível, setar como completa
        If Quest(QuestNum).Repeat = True Then
            Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).Status = QuestStatusType.Repeatable
        Else
            Player(index).Character(TempPlayer(index).CurChar).PlayerQuest(QuestNum).Status = QuestStatusType.Completed
        End If
        PlayerMsg(index, Trim$(Quest(QuestNum).Name) & ": quest completa", ColorType.BrightGreen)

        SavePlayer(index)
        SendPlayerData(index)
        SendPlayerQuest(index, QuestNum)
    End Sub

#End Region

End Module