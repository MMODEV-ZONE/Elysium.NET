Imports ASFW
Imports SFML.Graphics
Imports SFML.Window

Friend Module C_EventSystem

#Region "Globals"

    ' Armazenamento de eventos temporarios
    Friend TmpEvent As EventStruct

    Friend IsEdit As Boolean

    Friend CurPageNum As Integer
    Friend CurCommand As Integer
    Friend GraphicSelX As Integer
    Friend GraphicSelY As Integer
    Friend GraphicSelX2 As Integer
    Friend GraphicSelY2 As Integer

    Friend EventTileX As Integer
    Friend EventTileY As Integer

    Friend EditorEvent As Integer

    Friend GraphicSelType As Integer 'Estamos selecionando um gráfico para uma rota de movimento? Uma page sprite? O quê?
    Friend TempMoveRouteCount As Integer
    Friend TempMoveRoute() As MoveRouteRec
    Friend IsMoveRouteCommand As Boolean
    Friend ListOfEvents() As Integer

    Friend EventReplyId As Integer
    Friend EventReplyPage As Integer
    Friend EventChatFace As Integer

    Friend RenameType As Integer
    Friend Renameindex As Integer
    Friend EventChatTimer As Integer

    Friend EventChat As Boolean
    Friend EventText As String
    Friend ShowEventLbl As Boolean
    Friend EventChoices(4) As String
    Friend EventChoiceVisible(4) As Boolean
    Friend EventChatType As Integer
    Friend AnotherChat As Integer 'Determina se outra escolha está vindo e, se sim, nao fechar a caixa de evento. 

    'constantes
    Friend Switches(MaxSwitches) As String

    Friend Variables(MaxVariables) As String
    Friend Const MaxSwitches As Integer = 500
    Friend Const MaxVariables As Integer = 500

    Friend CpEvent As EventStruct
    Friend EventCopy As Boolean
    Friend EventPaste As Boolean
    Friend EventList() As EventListRec

    Friend InEvent As Boolean
    Friend HoldPlayer As Boolean
    Friend InitEventEditorForm As Boolean

#End Region

#Region "Types"

    Friend Structure EventCommandRec
        Dim Index As Integer
        Dim Text1 As String
        Dim Text2 As String
        Dim Text3 As String
        Dim Text4 As String
        Dim Text5 As String
        Dim Data1 As Integer
        Dim Data2 As Integer
        Dim Data3 As Integer
        Dim Data4 As Integer
        Dim Data5 As Integer
        Dim Data6 As Integer
        Dim ConditionalBranch As ConditionalBranchRec
        Dim MoveRouteCount As Integer
        Dim MoveRoute() As MoveRouteRec
    End Structure

    Friend Structure MoveRouteRec
        Dim Index As Integer
        Dim Data1 As Integer
        Dim Data2 As Integer
        Dim Data3 As Integer
        Dim Data4 As Integer
        Dim Data5 As Integer
        Dim Data6 As Integer
    End Structure

    Friend Structure CommandListRec
        Dim CommandCount As Integer
        Dim ParentList As Integer
        Dim Commands() As EventCommandRec
    End Structure

    Friend Structure ConditionalBranchRec
        Dim Condition As Integer
        Dim Data1 As Integer
        Dim Data2 As Integer
        Dim Data3 As Integer
        Dim CommandList As Integer
        Dim ElseCommandList As Integer
    End Structure

    Friend Structure EventPageRec

        'Estas são variáveis de condições se decidem se o evento sequer aparece ao jogador.
        Dim ChkVariable As Integer

        Dim Variableindex As Integer
        Dim VariableCondition As Integer
        Dim VariableCompare As Integer
        Dim ChkSwitch As Integer
        Dim Switchindex As Integer
        Dim SwitchCompare As Integer
        Dim ChkHasItem As Integer
        Dim HasItemindex As Integer
        Dim HasItemAmount As Integer
        Dim ChkSelfSwitch As Integer
        Dim SelfSwitchindex As Integer
        Dim SelfSwitchCompare As Integer
        Dim ChkPlayerGender As Integer
        'Fim de Condições

        'Lidar com a Sprite do Evento
        Dim GraphicType As Byte

        Dim Graphic As Integer
        Dim GraphicX As Integer
        Dim GraphicY As Integer
        Dim GraphicX2 As Integer
        Dim GraphicY2 As Integer

        'Lida com Movimento - Rotas de Movimento em breve.
        Dim MoveType As Byte

        Dim MoveSpeed As Byte
        Dim MoveFreq As Byte
        Dim MoveRouteCount As Integer
        Dim MoveRoute() As MoveRouteRec
        Dim IgnoreMoveRoute As Integer
        Dim RepeatMoveRoute As Integer

        'Linhas gerais para o evento
        Dim WalkAnim As Byte

        Dim DirFix As Byte
        Dim WalkThrough As Byte
        Dim ShowName As Byte

        'Gatilho para o evento
        Dim Trigger As Byte

        'Comandos para o evento
        Dim CommandListCount As Integer

        Dim CommandList() As CommandListRec
        Dim Position As Byte
        Dim Questnum As Integer

        'Cliente apenas necessário
        Dim X As Integer

        Dim Y As Integer
    End Structure

    Friend Structure EventStruct
        Dim Name As String
        Dim Globals As Integer
        Dim PageCount As Integer
        Dim Pages() As EventPageRec
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Friend Structure MapEventStruct
        Dim Name As String
        Dim Dir As Integer
        Dim X As Integer
        Dim Y As Integer
        Dim GraphicType As Integer
        Dim GraphicX As Integer
        Dim GraphicY As Integer
        Dim GraphicX2 As Integer
        Dim GraphicY2 As Integer
        Dim GraphicNum As Integer
        Dim Moving As Integer
        Dim MovementSpeed As Integer
        Dim Position As Integer
        Dim XOffset As Integer
        Dim YOffset As Integer
        Dim Steps As Integer
        Dim Visible As Integer
        Dim WalkAnim As Integer
        Dim DirFix As Integer
        Dim ShowDir As Integer
        Dim WalkThrough As Integer
        Dim ShowName As Integer
        Dim Questnum As Integer
    End Structure

    Friend CopyEvent As EventStruct
    Friend CopyEventPage As EventPageRec

    Friend Structure EventListRec
        Dim CommandList As Integer
        Dim CommandNum As Integer
    End Structure

#End Region

#Region "Enums"

    Friend Enum MoveRouteOpts
        MoveUp = 1
        MoveDown
        MoveLeft
        MoveRight
        MoveRandom
        MoveTowardsPlayer
        MoveAwayFromPlayer
        StepForward
        StepBack
        Wait100Ms
        Wait500Ms
        Wait1000Ms
        TurnUp
        TurnDown
        TurnLeft
        TurnRight
        Turn90Right
        Turn90Left
        Turn180
        TurnRandom
        TurnTowardPlayer
        TurnAwayFromPlayer
        SetSpeed8XSlower
        SetSpeed4XSlower
        SetSpeed2XSlower
        SetSpeedNormal
        SetSpeed2XFaster
        SetSpeed4XFaster
        SetFreqLowest
        SetFreqLower
        SetFreqNormal
        SetFreqHigher
        SetFreqHighest
        WalkingAnimOn
        WalkingAnimOff
        DirFixOn
        DirFixOff
        WalkThroughOn
        WalkThroughOff
        PositionBelowPlayer
        PositionWithPlayer
        PositionAbovePlayer
        ChangeGraphic
    End Enum

    ' Tipos de Eventos
    Friend Enum EventType

        ' Mensagem
        EvAddText = 1

        EvShowText
        EvShowChoices

        ' Progressão do Jogo
        EvPlayerVar

        EvPlayerSwitch
        EvSelfSwitch

        ' Controle de Fluxo
        EvCondition

        EvExitProcess

        ' Jogador
        EvChangeItems

        EvRestoreHp
        EvRestoreMp
        EvLevelUp
        EvChangeLevel
        EvChangeSkills
        EvChangeClass
        EvChangeSprite
        EvChangeSex
        EvChangePk

        ' Movimento
        EvWarpPlayer

        EvSetMoveRoute

        ' Personagem
        EvPlayAnimation

        ' Música e Som
        EvPlayBgm

        EvFadeoutBgm
        EvPlaySound
        EvStopSound

        'Etc...
        EvCustomScript

        EvSetAccess

        'Loja/Banco
        EvOpenBank

        EvOpenShop

        'Novo
        EvGiveExp

        EvShowChatBubble
        EvLabel
        EvGotoLabel
        EvSpawnNpc
        EvFadeIn
        EvFadeOut
        EvFlashWhite
        EvSetFog
        EvSetWeather
        EvSetTint
        EvWait
        EvOpenMail
        EvBeginQuest
        EvEndQuest
        EvQuestTask
        EvShowPicture
        EvHidePicture
        EvWaitMovement
        EvHoldPlayer
        EvReleasePlayer
    End Enum

#End Region

#Region "EventEditor"
    'Também inclui funções de eventos do editor de mapas (copiar/colar/deletar)

    Sub CopyEvent_Map(ByVal X As Integer, ByVal Y As Integer)
        Dim count As Integer, i As Integer

        count = Map.EventCount
        If count = 0 Then Exit Sub
        For i = 1 To count
            If Map.Events(i).X = X AndAlso Map.Events(i).Y = Y Then
                ' copiar
                CopyEvent = Map.Events(i)

                ' sair
                Exit Sub
            End If
        Next

    End Sub

    Sub PasteEvent_Map(ByVal X As Integer, ByVal Y As Integer)
        Dim count As Integer, i As Integer, EventNum As Integer

        count = Map.EventCount
        If count > 0 Then
            For i = 1 To count
                If Map.Events(i).X = X AndAlso Map.Events(i).Y = Y Then
                    ' já é um evento - copiar por cima
                    EventNum = i
                End If
            Next
        End If

        ' nãpo pode encontrar um -criar
        If EventNum = 0 Then
            '  incrementar contador
            AddEvent(X, Y, True)
            EventNum = count + 1
        End If

        ' copiar
        Map.Events(EventNum) = CopyEvent
        ' setar posição
        Map.Events(EventNum).X = X
        Map.Events(EventNum).Y = Y

    End Sub

    Sub DeleteEvent(ByVal X As Integer, ByVal Y As Integer)
        Dim count As Integer, i As Integer, lowIndex As Integer

        If Not InMapEditor Then Exit Sub
        If FrmEditor_Events.Visible = True Then Exit Sub

        count = Map.EventCount
        For i = 1 To count
            If Map.Events(i).X = X AndAlso Map.Events(i).Y = Y Then
                ' deletar
                ClearEvent(i)
                lowIndex = i
                Exit For
            End If
        Next
        ' nada encontrado
        If lowIndex = 0 Then Exit Sub
        ' mover tudo em um índice
        For i = lowIndex To count - 1
            Map.Events(i) = Map.Events(i + 1)
        Next
        ' deletar o último índice
        ClearEvent(count)
        ' setar o novo contador
        Map.EventCount = count - 1
        Map.CurrentEvents = count - 1

    End Sub

    Sub AddEvent(ByVal X As Integer, ByVal Y As Integer, Optional ByVal cancelLoad As Boolean = False)
        Dim count As Integer, pageCount As Integer, i As Integer

        count = Map.EventCount + 1
        ' ter certeza que já não é um evento
        If count - 1 > 0 Then
            For i = 1 To count - 1
                If Map.Events(i).X = X AndAlso Map.Events(i).Y = Y Then
                    ' já é um evento - editar
                    If Not cancelLoad Then EventEditorInit(i)
                    Exit Sub
                End If
            Next
        End If
        ' incrementar contador
        Map.EventCount = count
        ReDim Preserve Map.Events(0 To count)
        ' setar novo evento
        Map.Events(count).X = X
        Map.Events(count).Y = Y
        ' dar uma nova página
        pageCount = Map.Events(count).PageCount + 1
        Map.Events(count).PageCount = pageCount
        ReDim Preserve Map.Events(count).Pages(pageCount)
        ' carregar o editor
        If Not cancelLoad Then EventEditorInit(count)

    End Sub

    Sub ClearEvent(ByVal EventNum As Integer)
        If EventNum > Map.EventCount OrElse EventNum > UBound(Map.MapEvents) Then Exit Sub
        With Map.Events(EventNum)
            .Name = ""
            .PageCount = 0
            ReDim .Pages(0)
            .Globals = 0
            .X = 0
            .Y = 0
        End With
        With Map.MapEvents(EventNum)
            .Name = ""
            .Dir = 0
            .ShowDir = 0
            .GraphicNum = 0
            .GraphicType = 0
            .GraphicX = 0
            .GraphicX2 = 0
            .GraphicY = 0
            .GraphicY2 = 0
            .MovementSpeed = 0
            .Moving = 0
            .X = 0
            .Y = 0
            .XOffset = 0
            .YOffset = 0
            .Position = 0
            .Visible = 0
            .WalkAnim = 0
            .DirFix = 0
            .WalkThrough = 0
            .ShowName = 0
            .Questnum = 0
        End With

    End Sub

    Sub EventEditorInit(ByVal EventNum As Integer)

        EditorEvent = EventNum

        TmpEvent = Map.Events(EventNum)
        InitEventEditorForm = True

    End Sub

    Sub EventEditorLoadPage(ByVal PageNum As Integer)
        ' popular formulário

        With TmpEvent.Pages(PageNum)
            GraphicSelX = .GraphicX
            GraphicSelY = .GraphicY
            GraphicSelX2 = .GraphicX2
            GraphicSelY2 = .GraphicY2
            FrmEditor_Events.cmbGraphic.SelectedIndex = .GraphicType
            FrmEditor_Events.cmbHasItem.SelectedIndex = .HasItemindex
            If .HasItemAmount = 0 Then
                FrmEditor_Events.nudCondition_HasItem.Value = 1
            Else
                FrmEditor_Events.nudCondition_HasItem.Value = .HasItemAmount
            End If
            FrmEditor_Events.cmbMoveFreq.SelectedIndex = .MoveFreq
            FrmEditor_Events.cmbMoveSpeed.SelectedIndex = .MoveSpeed
            FrmEditor_Events.cmbMoveType.SelectedIndex = .MoveType
            FrmEditor_Events.cmbPlayerVar.SelectedIndex = .Variableindex
            FrmEditor_Events.cmbPlayerSwitch.SelectedIndex = .Switchindex
            FrmEditor_Events.cmbSelfSwitchCompare.SelectedIndex = .SelfSwitchCompare
            FrmEditor_Events.cmbPlayerSwitchCompare.SelectedIndex = .SwitchCompare
            FrmEditor_Events.cmbPlayervarCompare.SelectedIndex = .VariableCompare
            FrmEditor_Events.chkGlobal.Checked = TmpEvent.Globals
            FrmEditor_Events.cmbTrigger.SelectedIndex = .Trigger
            FrmEditor_Events.chkDirFix.Checked = .DirFix
            FrmEditor_Events.chkHasItem.Checked = .ChkHasItem
            FrmEditor_Events.chkPlayerVar.Checked = .ChkVariable
            FrmEditor_Events.chkPlayerSwitch.Checked = .ChkSwitch
            FrmEditor_Events.chkSelfSwitch.Checked = .ChkSelfSwitch
            FrmEditor_Events.chkWalkAnim.Checked = .WalkAnim
            FrmEditor_Events.chkWalkThrough.Checked = .WalkThrough
            FrmEditor_Events.chkShowName.Checked = .ShowName
            FrmEditor_Events.nudPlayerVariable.Value = .VariableCondition
            FrmEditor_Events.nudGraphic.Value = .Graphic
            If FrmEditor_Events.cmbEventQuest.Items.Count > 0 Then
                If .Questnum >= 0 AndAlso .Questnum <= FrmEditor_Events.cmbEventQuest.Items.Count Then
                    FrmEditor_Events.cmbEventQuest.SelectedIndex = .Questnum
                End If
            End If
            If FrmEditor_Events.cmbEventQuest.SelectedIndex = -1 Then FrmEditor_Events.cmbEventQuest.SelectedIndex = 0
            If .ChkHasItem = 0 Then
                FrmEditor_Events.cmbHasItem.Enabled = False
            Else
                FrmEditor_Events.cmbHasItem.Enabled = True
            End If
            If .ChkSelfSwitch = 0 Then
                FrmEditor_Events.cmbSelfSwitch.Enabled = False
                FrmEditor_Events.cmbSelfSwitchCompare.Enabled = False
            Else
                FrmEditor_Events.cmbSelfSwitch.Enabled = True
                FrmEditor_Events.cmbSelfSwitchCompare.Enabled = True
            End If
            If .ChkSwitch = 0 Then
                FrmEditor_Events.cmbPlayerSwitch.Enabled = False
                FrmEditor_Events.cmbPlayerSwitchCompare.Enabled = False
            Else
                FrmEditor_Events.cmbPlayerSwitch.Enabled = True
                FrmEditor_Events.cmbPlayerSwitchCompare.Enabled = True
            End If
            If .ChkVariable = 0 Then
                FrmEditor_Events.cmbPlayerVar.Enabled = False
                FrmEditor_Events.nudPlayerVariable.Enabled = False
                FrmEditor_Events.cmbPlayervarCompare.Enabled = False
            Else
                FrmEditor_Events.cmbPlayerVar.Enabled = True
                FrmEditor_Events.nudPlayerVariable.Enabled = True
                FrmEditor_Events.cmbPlayervarCompare.Enabled = True
            End If
            If FrmEditor_Events.cmbMoveType.SelectedIndex = 2 Then
                FrmEditor_Events.btnMoveRoute.Enabled = True
            Else
                FrmEditor_Events.btnMoveRoute.Enabled = False
            End If
            FrmEditor_Events.cmbPositioning.SelectedIndex = .Position
            ' mostrar os comandos
            EventListCommands()

            EditorEvent_DrawGraphic()
        End With

    End Sub

    Sub EventEditorOK()
        ' copiar os dados do evento do evento temp

        Map.Events(EditorEvent) = TmpEvent
        ' descarregar formulario
        FrmEditor_Events.Dispose()

    End Sub

    Public Sub EventListCommands()
        Dim i As Integer, curlist As Integer, X As Integer, indent As String = "", listleftoff() As Integer, conditionalstage() As Integer

        FrmEditor_Events.lstCommands.Items.Clear()

        If TmpEvent.Pages(CurPageNum).CommandListCount > 0 Then
            ReDim listleftoff(0 To TmpEvent.Pages(CurPageNum).CommandListCount)
            ReDim conditionalstage(0 To TmpEvent.Pages(CurPageNum).CommandListCount)
            'Começar em 1
            curlist = 1
            X = -1
newlist:
            For i = 1 To TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount
                If listleftoff(curlist) > 0 Then
                    If (TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(listleftoff(curlist)).Index = EventType.EvCondition OrElse TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(listleftoff(curlist)).Index = EventType.EvShowChoices) AndAlso conditionalstage(curlist) <> 0 Then
                        i = listleftoff(curlist)
                    ElseIf listleftoff(curlist) >= i Then
                        i = listleftoff(curlist) + 1
                    End If
                End If
                If i <= TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount Then
                    If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Index = EventType.EvCondition Then
                        X = X + 1
                        Select Case conditionalstage(curlist)
                            Case 0
                                ReDim Preserve EventList(X)
                                EventList(X).CommandList = curlist
                                EventList(X).CommandNum = i
                                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Condition
                                    Case 0
                                        Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2
                                            Case 0
                                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Variável do Jogador [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Variables(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] == " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                            Case 1
                                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Variável do Jogador [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Variables(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] >= " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                            Case 2
                                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Variável do Jogador [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Variables(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] <= " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                            Case 3
                                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Variável do Jogador [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Variables(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] > " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                            Case 4
                                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Variável do Jogador [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Variables(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] < " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                            Case 5
                                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Variável do Jogador [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Variables(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] != " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                        End Select
                                    Case 1
                                        If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2 = 0 Then
                                            FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Switch de Jogador [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Switches(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] == " & "Verdadeiro")
                                        ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2 = 1 Then
                                            FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Switch de Jogador [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Switches(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] == " & "Falso")
                                        End If
                                    Case 2
                                        FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Jogador Tem Item [" & Trim$(Item(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1).Name) & "] x" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2)
                                    Case 3
                                        FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Classe do Jogador É [" & Trim$(Classes(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1).Name) & "]")
                                    Case 4
                                        FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Jogador Sabe Habilidade [" & Trim$(Skill(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1).Name) & "]")
                                    Case 5
                                        Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2
                                            Case 0
                                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Nível do Jogador É == " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1)
                                            Case 1
                                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Nível do Jogador É >= " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1)
                                            Case 2
                                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Nível do Jogador É <= " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1)
                                            Case 3
                                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Nível do Jogador É > " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1)
                                            Case 4
                                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Nível do Jogador É < " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1)
                                            Case 5
                                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Nível do Jogador NÃO É " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1)
                                        End Select
                                    Case 6
                                        If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2 = 0 Then
                                            Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1
                                                Case 0
                                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição:: Auto-Switch [A] == " & "Verdadeiro")
                                                Case 1
                                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição:: Auto-Switch [B] == " & "Verdadeiro")
                                                Case 2
                                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição:: Auto-Switch [C] == " & "Verdadeiro")
                                                Case 3
                                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição:: Auto-Switch [D] == " & "Verdadeiro")
                                            End Select
                                        ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2 = 1 Then
                                            Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1
                                                Case 0
                                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição:: Auto-Switch [A] == " & "Falso")
                                                Case 1
                                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição:: Auto-Switch [B] == " & "Falso")
                                                Case 2
                                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição:: Auto-Switch [C] == " & "Falso")
                                                Case 3
                                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição:: Auto-Switch [D] == " & "Falso")
                                            End Select
                                        End If
                                    Case 7
                                        If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2 = 0 Then
                                            Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3
                                                Case 0
                                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Tarefa [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & "] não iniciada.")
                                                Case 1
                                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Tarefa [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & "] está iniciada.")
                                                Case 2
                                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Tarefa [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & "] está completa.")
                                                Case 3
                                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Tarefa [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & "] pode ser iniciada.")
                                                Case 4
                                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Tarefa [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & "] pode ser finalizada. (Todas sub-tarefas completas)")
                                            End Select
                                        ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2 = 1 Then
                                            FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Tarefa [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & "] está em progresso e na sub-tarefa #" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                        End If
                                    Case 8
                                        Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1
                                            Case SexType.Male
                                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Sexo do Jogador é Masculino")
                                            Case SexType.Female
                                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: Sexo do Jogador é Feminino")
                                        End Select
                                    Case 9
                                        Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1
                                            Case TimeOfDay.Day
                                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: A Hora é Dia")
                                            Case TimeOfDay.Night
                                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: A Hora é Noite")
                                            Case TimeOfDay.Dawn
                                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: A Hora é Alvorecer")
                                            Case TimeOfDay.Dusk
                                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ramo de Condição: A Hora é Crepúsculo")
                                        End Select
                                End Select
                                indent = indent & "       "
                                listleftoff(curlist) = i
                                conditionalstage(curlist) = 1
                                curlist = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.CommandList
                                GoTo newlist
                            Case 1
                                ReDim Preserve EventList(X)
                                EventList(X).CommandList = curlist
                                EventList(X).CommandNum = 0
                                FrmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "Caso Contrário")
                                listleftoff(curlist) = i
                                conditionalstage(curlist) = 2
                                curlist = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.ElseCommandList
                                GoTo newlist
                            Case 2
                                ReDim Preserve EventList(X)
                                EventList(X).CommandList = curlist
                                EventList(X).CommandNum = 0
                                FrmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "Fim do Ramo")
                                indent = Mid(indent, 1, Len(indent) - 7)
                                listleftoff(curlist) = i
                                conditionalstage(curlist) = 0
                        End Select
                    ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Index = EventType.EvShowChoices Then
                        X = X + 1
                        Select Case conditionalstage(curlist)
                            Case 0
                                ReDim Preserve EventList(X)
                                EventList(X).CommandList = curlist
                                EventList(X).CommandNum = i
                                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data5 > 0 Then
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Mostrar Escolhas - Mostrar: " & Mid(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - Rosto: " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data5)
                                Else
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Mostrar Escolhas - Mostrar: " & Mid(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - Sem Rosto")
                                End If
                                indent = indent & "       "
                                listleftoff(curlist) = i
                                conditionalstage(curlist) = 1
                                GoTo newlist
                            Case 1
                                If Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text2) <> "" Then
                                    ReDim Preserve EventList(X)
                                    EventList(X).CommandList = curlist
                                    EventList(X).CommandNum = 0
                                    FrmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "Quando [" & Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text2) & "]")
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 2
                                    curlist = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1
                                    GoTo newlist
                                Else
                                    X = X - 1
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 2
                                    curlist = curlist
                                    GoTo newlist
                                End If
                            Case 2
                                If Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text3) <> "" Then
                                    ReDim Preserve EventList(X)
                                    EventList(X).CommandList = curlist
                                    EventList(X).CommandNum = 0
                                    FrmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "Quando [" & Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text3) & "]")
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 3
                                    curlist = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2
                                    GoTo newlist
                                Else
                                    X = X - 1
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 3
                                    curlist = curlist
                                    GoTo newlist
                                End If
                            Case 3
                                If Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text4) <> "" Then
                                    ReDim Preserve EventList(X)
                                    EventList(X).CommandList = curlist
                                    EventList(X).CommandNum = 0
                                    FrmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "Quando [" & Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text4) & "]")
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 4
                                    curlist = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3
                                    GoTo newlist
                                Else
                                    X = X - 1
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 4
                                    curlist = curlist
                                    GoTo newlist
                                End If
                            Case 4
                                If Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text5) <> "" Then
                                    ReDim Preserve EventList(X)
                                    EventList(X).CommandList = curlist
                                    EventList(X).CommandNum = 0
                                    FrmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "Quando [" & Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text5) & "]")
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 5
                                    curlist = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data4
                                    GoTo newlist
                                Else
                                    X = X - 1
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 5
                                    curlist = curlist
                                    GoTo newlist
                                End If
                            Case 5
                                ReDim Preserve EventList(X)
                                EventList(X).CommandList = curlist
                                EventList(X).CommandNum = 0
                                FrmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "Fim do Ramo")
                                indent = Mid(indent, 1, Len(indent) - 7)
                                listleftoff(curlist) = i
                                conditionalstage(curlist) = 0
                        End Select
                    Else
                        X = X + 1
                        ReDim Preserve EventList(X)
                        EventList(X).CommandList = curlist
                        EventList(X).CommandNum = i
                        Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Index
                            Case EventType.EvAddText
                                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2
                                    Case 0
                                        FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Adicionar Texto - " & Mid(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - Cor: " & GetColorString(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & " - Tipo de Chat: Jogador")
                                    Case 1
                                        FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Adicionar Texto - " & Mid(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - Cor: " & GetColorString(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & " - Tipo de Chat: Mapa")
                                    Case 2
                                        FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Adicionar Texto - " & Mid(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - Cor: " & GetColorString(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & " - Tipo de Chat: Global")
                                End Select
                            Case EventType.EvShowText
                                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 = 0 Then
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Mostrar Texto - " & Mid(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - Sem Rosto")
                                Else
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Mostrar Texto - " & Mid(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - Rosto: " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1)
                                End If
                            Case EventType.EvPlayerVar
                                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2
                                    Case 0
                                        FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Variável de Jogador [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & Variables(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & "] == " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3)
                                    Case 1
                                        FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Variável de Jogador [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & Variables(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & "] + " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3)
                                    Case 2
                                        FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Variável de Jogador [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & Variables(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & "] - " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3)
                                    Case 3
                                        FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Variável de Jogador [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & Variables(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & "] Aleatória entre " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3 & " e " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data4)
                                End Select
                            Case EventType.EvPlayerSwitch
                                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Switch de Jogador [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & ". " & Switches(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & "] == Verdadeiro")
                                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Switch de Jogador [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & ". " & Switches(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & "] == Falso")
                                End If
                            Case EventType.EvSelfSwitch
                                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1
                                    Case 0
                                        If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                            FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Auto-Switch [A] para LIGADO")
                                        ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                            FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Auto-Switch [A] para DESLIGADO")
                                        End If
                                    Case 1
                                        If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                            FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Auto-Switch [B] para LIGADO")
                                        ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                            FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Auto-Switch [B] para DESLIGADO")
                                        End If
                                    Case 2
                                        If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                            FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Auto-Switch [C] para LIGADO")
                                        ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                            FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Auto-Switch [C] para DESLIGADO")
                                        End If
                                    Case 3
                                        If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                            FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Auto-Switch [D] para LIGADO")
                                        ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                            FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Auto-Switch [D] para DESLIGADO")
                                        End If
                                End Select
                            Case EventType.EvExitProcess
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Sair do Processamento de Evento")
                            Case EventType.EvChangeItems
                                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar quantidade de item [" & Trim$(Item(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "] para " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3)
                                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Dar a Jogador " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3 & " " & Trim$(Item(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "(s)")
                                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 2 Then
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Pegar " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3 & " " & Trim$(Item(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "(s) do Jogador.")
                                End If
                            Case EventType.EvRestoreHp
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Restaurar HP do Jogador")
                            Case EventType.EvRestoreMp
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Restaurar MP do Jogador")
                            Case EventType.EvLevelUp
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Aumentar um nível do jogador")
                            Case EventType.EvChangeLevel
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Alterar Nível do Jogador para " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1)
                            Case EventType.EvChangeSkills
                                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ensinar ao Jogador a Habilidade [" & Trim$(Skill(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]")
                                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Remover do Jogador a Habilidade [" & Trim$(Skill(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]")
                                End If
                            Case EventType.EvChangeClass
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Alterar Classe do Jogador para " & Trim$(Classes(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name))
                            Case EventType.EvChangeSprite
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Alterar Sprite do Jogador para " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1)
                            Case EventType.EvChangeSex
                                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 = 0 Then
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Alterar sexo do jogador para masculino.")
                                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 = 1 Then
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Alterar sexo do jogador para feminino.")
                                End If
                            Case EventType.EvChangePk
                                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 = 0 Then
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar PK do Jogador para Negativo.")
                                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 = 1 Then
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar PK do Jogador para Positivo.")
                                End If
                            Case EventType.EvWarpPlayer
                                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data4 = 0 Then
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Teleportar Jogador para o Mapa: " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " Tile(" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 & "," & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3 & "), mantendo a direção.")
                                Else
                                    Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data4 - 1
                                        Case DirectionType.Up
                                            FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Teleportar Jogador para o Mapa: " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " Tile(" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 & "," & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3 & "), direcionado para cima.")
                                        Case DirectionType.Down
                                            FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Teleportar Jogador para o Mapa: " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " Tile(" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 & "," & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3 & ") direcionado para baixo.")
                                        Case DirectionType.Left
                                            FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Teleportar Jogador para o Mapa: " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " Tile(" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 & "," & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3 & ") direcionado para esquerda.")
                                        Case DirectionType.Right
                                            FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Teleportar Jogador para o Mapa: " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " Tile(" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 & "," & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3 & ") direcionado para direita.")
                                    End Select
                                End If
                            Case EventType.EvSetMoveRoute
                                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 <= Map.EventCount Then
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Rota de Movimento para Evento #" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " [" & Trim$(Map.Events(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]")
                                Else
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Rota de Movimento para NÃO ENCONTROU O EVENTO!")
                                End If
                            Case EventType.EvPlayAnimation
                                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Tocar Animação " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " [" & Trim$(Animation(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]" & " on Player")
                                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Tocar Animação " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " [" & Trim$(Animation(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]" & " on Event #" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3 & " [" & Trim$(Map.Events(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3).Name) & "]")
                                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 2 Then
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Tocar Animação " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " [" & Trim$(Animation(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]" & " on Tile(" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3 & "," & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data4 & ")")
                                End If
                            Case EventType.EvCustomScript
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Executar Condição de Script Customizado: " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1)
                            Case EventType.EvPlayBgm
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Tocar BGM [" & Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1) & "]")
                            Case EventType.EvFadeoutBgm
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Esmaecer BGM")
                            Case EventType.EvPlaySound
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Tocar Som [" & Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1) & "]")
                            Case EventType.EvStopSound
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Parar Som")
                            Case EventType.EvOpenBank
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Abrir Banco")
                            Case EventType.EvOpenMail
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Abrir Caixa de Correio")
                            Case EventType.EvOpenShop
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Abrir Loja [" & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & ". " & Trim$(Shop(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]")
                            Case EventType.EvSetAccess
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Alterar Acesso de Jogador para [" & FrmEditor_Events.cmbSetAccess.Items(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & "]")
                            Case EventType.EvGiveExp
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Dar ao Jogador " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " de Experiência.")
                            Case EventType.EvShowChatBubble
                                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1
                                    Case TargetType.Player
                                        FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Mostrar Bolha de Conversa - " & Mid(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - No Jogador")
                                    Case TargetType.Npc
                                        If Map.Npc(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) <= 0 Then
                                            FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Mostrar Bolha de Conversa - " & Mid(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - No NPC [" & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & ". ]")
                                        Else
                                            FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Mostrar Bolha de Conversa - " & Mid(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - No NPC [" & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & ". " & Trim$(Npc(Map.Npc(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2)).Name) & "]")
                                        End If
                                    Case TargetType.Event
                                        FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Mostrar Bolha de Conversa - " & Mid(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - No Evento [" & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & ". " & Trim$(Map.Events(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2).Name) & "]")
                                End Select
                            Case EventType.EvLabel
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Marcador: [" & Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1) & "]")
                            Case EventType.EvGotoLabel
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Ir para Marcador: [" & Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1) & "]")
                            Case EventType.EvSpawnNpc
                                If Map.Npc(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) <= 0 Then
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Gerar NPC: [" & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & ". " & "]")
                                Else
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Gerar NPC: [" & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & ". " & Trim$(Npc(Map.Npc(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1)).Name) & "]")
                                End If
                            Case EventType.EvFadeIn
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Transição de Entrada")
                            Case EventType.EvFadeOut
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Transição de Saída")
                            Case EventType.EvFlashWhite
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Piscar em Branco")
                            Case EventType.EvSetFog
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Névoa [Névoa: " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & " Velocidade: " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & " Opacidade: " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3) & "]")
                            Case EventType.EvSetWeather
                                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1
                                    Case WeatherType.None
                                        FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Clima [Nenhum]")
                                    Case WeatherType.Rain
                                        FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Clima [Chuva - Intensidade: " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & "]")
                                    Case WeatherType.Snow
                                        FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Clima [Neve - Intensidade: " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & "]")
                                    Case WeatherType.Sandstorm
                                        FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Clima [Tempestade de Areia - Intensidade: " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & "]")
                                    Case WeatherType.Storm
                                        FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Setar Clima [Tempestade - Intensidade: " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & "]")
                                End Select
                            Case EventType.EvSetTint
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Alterar RGBA do Mapa [" & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & "," & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & "," & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3) & "," & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data4) & "]")
                            Case EventType.EvWait
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Esperar " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & " Ms")
                            Case EventType.EvBeginQuest
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Iniciar Tarefa: " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & ". " & Trim$(Quest(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name))
                            Case EventType.EvEndQuest
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Finalizar Tarefa: " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & ". " & Trim$(Quest(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name))
                            Case EventType.EvQuestTask
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Completar Subtarefa da Tarefa: " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & ". " & Trim$(Quest(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & " - Sub-tarefa# " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2)
                            Case EventType.EvShowPicture
                                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3
                                    Case 1
                                        FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Mostrar Imagem " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 + 1) & ": Pic=" & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & " Esquerda Superior, X: " & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data4) & " Y: " & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data5))
                                    Case 2
                                        FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Mostrar Imagem " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 + 1) & ": Pic=" & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & " Centro da Tela, X: " & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data4) & " Y: " & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data5))
                                    Case 3
                                        FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Mostrar Imagem " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 + 1) & ": Pic=" & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & " No Jogador, X: " & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data4) & " Y: " & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data5))
                                End Select
                            Case EventType.EvHidePicture
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Esconder Imagem " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 + 1))
                            Case EventType.EvWaitMovement
                                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 <= Map.EventCount Then
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Esperar pelo Evento #" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " [" & Trim$(Map.Events(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "] para completar rota de movimento.")
                                Else
                                    FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Esperar por EVENTO NÃO ENCONTRADO para completar rota de movimento.")
                                End If
                            Case EventType.EvHoldPlayer
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Segurar Jogador [Não permitir que jogador mova.]")
                            Case EventType.EvReleasePlayer
                                FrmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Soltar Jogador [Permitir que Jogador Vire e se Mova Novamente.]")
                            Case Else
                                'Fantasma
                                X = X - 1
                                If X = -1 Then
                                    ReDim EventList(0)
                                Else
                                    ReDim Preserve EventList(X)
                                End If
                        End Select
                    End If
                End If
            Next
            If curlist > 1 Then
                X = X + 1
                ReDim Preserve EventList(X)
                EventList(X).CommandList = curlist
                EventList(X).CommandNum = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount + 1
                FrmEditor_Events.lstCommands.Items.Add(indent & "@> ")
                curlist = TmpEvent.Pages(CurPageNum).CommandList(curlist).ParentList
                GoTo newlist
            End If
        End If
        FrmEditor_Events.lstCommands.Items.Add(indent & "@> ")

        Dim z As Integer
        X = 0
        For i = 0 To FrmEditor_Events.lstCommands.Items.Count - 1
            If X > z Then z = X
        Next

    End Sub

    Sub AddCommand(ByVal Index As Integer)
        Dim curlist As Integer, i As Integer, X As Integer, curslot As Integer, p As Integer, oldCommandList As CommandListRec

        If TmpEvent.Pages(CurPageNum).CommandListCount = 0 Then
            TmpEvent.Pages(CurPageNum).CommandListCount = 1
            ReDim TmpEvent.Pages(CurPageNum).CommandList(1)
        End If

        If FrmEditor_Events.lstCommands.SelectedIndex = FrmEditor_Events.lstCommands.Items.Count - 1 Then
            curlist = 1
        Else
            curlist = EventList(FrmEditor_Events.lstCommands.SelectedIndex).CommandList
        End If
        If TmpEvent.Pages(CurPageNum).CommandListCount = 0 Then
            TmpEvent.Pages(CurPageNum).CommandListCount = 1
            ReDim TmpEvent.Pages(CurPageNum).CommandList(curlist)
        End If
        oldCommandList = TmpEvent.Pages(CurPageNum).CommandList(curlist)
        TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount + 1
        p = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount
        If p <= 0 Then
            ReDim TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(0)
        Else
            ReDim TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(0 To p)
            TmpEvent.Pages(CurPageNum).CommandList(curlist).ParentList = oldCommandList.ParentList
            TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount = p
            For i = 1 To p - 1
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i) = oldCommandList.Commands(i)
            Next
        End If
        If FrmEditor_Events.lstCommands.SelectedIndex = FrmEditor_Events.lstCommands.Items.Count - 1 Then
            curslot = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount
        Else
            i = EventList(FrmEditor_Events.lstCommands.SelectedIndex).CommandNum
            If i < TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount Then
                For X = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount - 1 To i Step -1
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(X + 1) = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(X)
                Next
                curslot = EventList(FrmEditor_Events.lstCommands.SelectedIndex).CommandNum
            Else
                curslot = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount
            End If
        End If

        Select Case Index
            Case EventType.EvAddText
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = FrmEditor_Events.txtAddText_Text.Text
                'tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlAddText_Colour.Value
                If FrmEditor_Events.optAddText_Player.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf FrmEditor_Events.optAddText_Map.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                ElseIf FrmEditor_Events.optAddText_Global.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 2
                End If
            Case EventType.EvCondition
                'Essa é a parte que tudo fica confuso
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandListCount = TmpEvent.Pages(CurPageNum).CommandListCount + 2
                ReDim Preserve TmpEvent.Pages(CurPageNum).CommandList(TmpEvent.Pages(CurPageNum).CommandListCount)
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.CommandList = TmpEvent.Pages(CurPageNum).CommandListCount - 1
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.ElseCommandList = TmpEvent.Pages(CurPageNum).CommandListCount
                TmpEvent.Pages(CurPageNum).CommandList(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.CommandList).ParentList = curlist
                TmpEvent.Pages(CurPageNum).CommandList(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.ElseCommandList).ParentList = curlist

                If FrmEditor_Events.optCondition0.Checked = True Then X = 0
                If FrmEditor_Events.optCondition1.Checked = True Then X = 1
                If FrmEditor_Events.optCondition2.Checked = True Then X = 2
                If FrmEditor_Events.optCondition3.Checked = True Then X = 3
                If FrmEditor_Events.optCondition4.Checked = True Then X = 4
                If FrmEditor_Events.optCondition5.Checked = True Then X = 5
                If FrmEditor_Events.optCondition6.Checked = True Then X = 6
                If FrmEditor_Events.optCondition7.Checked = True Then X = 7
                If FrmEditor_Events.optCondition8.Checked = True Then X = 8
                If FrmEditor_Events.optCondition9.Checked = True Then X = 9

                Select Case X
                    Case 0 'Variáveis de Jogador
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 0
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = FrmEditor_Events.cmbCondition_PlayerVarIndex.SelectedIndex + 1
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = FrmEditor_Events.cmbCondition_PlayerVarCompare.SelectedIndex
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3 = FrmEditor_Events.nudCondition_PlayerVarCondition.Value
                    Case 1 'Switch de Jogador
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 1
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = FrmEditor_Events.cmbCondition_PlayerSwitch.SelectedIndex + 1
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = FrmEditor_Events.cmbCondtion_PlayerSwitchCondition.SelectedIndex
                    Case 2 'Tem Item
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 2
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = FrmEditor_Events.cmbCondition_HasItem.SelectedIndex + 1
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = FrmEditor_Events.nudCondition_HasItem.Value
                    Case 3 'Classe
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 3
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = FrmEditor_Events.cmbCondition_ClassIs.SelectedIndex + 1
                    Case 4 'Habilidade Aprendida
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 4
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = FrmEditor_Events.cmbCondition_LearntSkill.SelectedIndex + 1
                    Case 5 'Nível
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 5
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = FrmEditor_Events.nudCondition_LevelAmount.Value
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = FrmEditor_Events.cmbCondition_LevelCompare.SelectedIndex
                    Case 6 'Auto-Switch
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 6
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = FrmEditor_Events.cmbCondition_SelfSwitch.SelectedIndex
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = FrmEditor_Events.cmbCondition_SelfSwitchCondition.SelectedIndex
                    Case 7 'Tarefas
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 7
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = FrmEditor_Events.nudCondition_Quest.Value
                        If FrmEditor_Events.optCondition_Quest0.Checked Then
                            TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = 0
                            TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3 = FrmEditor_Events.cmbCondition_General.SelectedIndex
                        Else
                            TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = 1
                            TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3 = FrmEditor_Events.nudCondition_QuestTask.Value
                        End If
                    Case 8 'Sexo
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 8
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = FrmEditor_Events.cmbCondition_Gender.SelectedIndex
                    Case 9 'Hora
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 9
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = FrmEditor_Events.cmbCondition_Time.SelectedIndex
                End Select

            Case EventType.EvShowText
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                Dim tmptxt As String = ""
                For i = 0 To UBound(FrmEditor_Events.txtShowText.Lines)
                    tmptxt = tmptxt & FrmEditor_Events.txtShowText.Lines(i)
                Next
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = tmptxt
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.nudShowTextFace.Value

            Case EventType.EvShowChoices
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = FrmEditor_Events.txtChoicePrompt.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text2 = FrmEditor_Events.txtChoices1.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text3 = FrmEditor_Events.txtChoices2.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text4 = FrmEditor_Events.txtChoices3.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text5 = FrmEditor_Events.txtChoices4.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data5 = FrmEditor_Events.nudShowChoicesFace.Value
                TmpEvent.Pages(CurPageNum).CommandListCount = TmpEvent.Pages(CurPageNum).CommandListCount + 4
                ReDim Preserve TmpEvent.Pages(CurPageNum).CommandList(TmpEvent.Pages(CurPageNum).CommandListCount)
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = TmpEvent.Pages(CurPageNum).CommandListCount - 3
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = TmpEvent.Pages(CurPageNum).CommandListCount - 2
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = TmpEvent.Pages(CurPageNum).CommandListCount - 1
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = TmpEvent.Pages(CurPageNum).CommandListCount
                TmpEvent.Pages(CurPageNum).CommandList(TmpEvent.Pages(CurPageNum).CommandListCount - 3).ParentList = curlist
                TmpEvent.Pages(CurPageNum).CommandList(TmpEvent.Pages(CurPageNum).CommandListCount - 2).ParentList = curlist
                TmpEvent.Pages(CurPageNum).CommandList(TmpEvent.Pages(CurPageNum).CommandListCount - 1).ParentList = curlist
                TmpEvent.Pages(CurPageNum).CommandList(TmpEvent.Pages(CurPageNum).CommandListCount).ParentList = curlist

            Case EventType.EvPlayerVar
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbVariable.SelectedIndex + 1

                If FrmEditor_Events.optVariableAction0.Checked = True Then i = 0
                If FrmEditor_Events.optVariableAction1.Checked = True Then i = 1
                If FrmEditor_Events.optVariableAction2.Checked = True Then i = 2
                If FrmEditor_Events.optVariableAction3.Checked = True Then i = 3

                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = i
                If i = 3 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.nudVariableData3.Value
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = FrmEditor_Events.nudVariableData4.Value
                ElseIf i = 0 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.nudVariableData0.Value
                ElseIf i = 1 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.nudVariableData1.Value
                ElseIf i = 2 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.nudVariableData2.Value
                End If

            Case EventType.EvPlayerSwitch
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbSwitch.SelectedIndex + 1
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = FrmEditor_Events.cmbPlayerSwitchSet.SelectedIndex

            Case EventType.EvSelfSwitch
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbSetSelfSwitch.SelectedIndex
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = FrmEditor_Events.cmbSetSelfSwitchTo.SelectedIndex

            Case EventType.EvExitProcess
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.EvChangeItems
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbChangeItemIndex.SelectedIndex + 1
                If FrmEditor_Events.optChangeItemSet.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf FrmEditor_Events.optChangeItemAdd.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                ElseIf FrmEditor_Events.optChangeItemRemove.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 2
                End If
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.nudChangeItemsAmount.Value

            Case EventType.EvRestoreHp
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.EvRestoreMp
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.EvLevelUp
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.EvChangeLevel
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.nudChangeLevel.Value

            Case EventType.EvChangeSkills
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbChangeSkills.SelectedIndex + 1
                If FrmEditor_Events.optChangeSkillsAdd.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf FrmEditor_Events.optChangeSkillsRemove.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                End If

            Case EventType.EvChangeClass
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbChangeClass.SelectedIndex + 1

            Case EventType.EvChangeSprite
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.nudChangeSprite.Value

            Case EventType.EvChangeSex
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                If FrmEditor_Events.optChangeSexMale.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = 0
                ElseIf FrmEditor_Events.optChangeSexFemale.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = 1
                End If

            Case EventType.EvChangePk
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbSetPK.SelectedIndex

            Case EventType.EvWarpPlayer
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.nudWPMap.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = FrmEditor_Events.nudWPX.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.nudWPY.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = FrmEditor_Events.cmbWarpPlayerDir.SelectedIndex

            Case EventType.EvSetMoveRoute
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = ListOfEvents(FrmEditor_Events.cmbEvent.SelectedIndex)
                If FrmEditor_Events.chkIgnoreMove.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                Else
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                End If

                If FrmEditor_Events.chkRepeatRoute.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = 1
                Else
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = 0
                End If

                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).MoveRouteCount = TempMoveRouteCount
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).MoveRoute = TempMoveRoute

            Case EventType.EvPlayAnimation
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbPlayAnim.SelectedIndex + 1
                If FrmEditor_Events.cmbAnimTargetType.SelectedIndex = 0 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf FrmEditor_Events.cmbAnimTargetType.SelectedIndex = 1 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.cmbPlayAnimEvent.SelectedIndex + 1
                ElseIf FrmEditor_Events.cmbAnimTargetType.SelectedIndex = 2 = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 2
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.nudPlayAnimTileX.Value
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = FrmEditor_Events.nudPlayAnimTileY.Value
                End If

            Case EventType.EvCustomScript
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.nudCustomScript.Value

            Case EventType.EvPlayBgm
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = MusicCache(FrmEditor_Events.cmbPlayBGM.SelectedIndex + 1)

            Case EventType.EvFadeoutBgm
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.EvPlaySound
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = SoundCache(FrmEditor_Events.cmbPlaySound.SelectedIndex + 1)

            Case EventType.EvStopSound
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.EvOpenBank
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.EvOpenMail
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.EvOpenShop
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbOpenShop.SelectedIndex + 1

            Case EventType.EvSetAccess
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbSetAccess.SelectedIndex

            Case EventType.EvGiveExp
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.nudGiveExp.Value

            Case EventType.EvShowChatBubble
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = FrmEditor_Events.txtChatbubbleText.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbChatBubbleTargetType.SelectedIndex + 1
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = FrmEditor_Events.cmbChatBubbleTarget.SelectedIndex + 1

            Case EventType.EvLabel
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = FrmEditor_Events.txtLabelName.Text

            Case EventType.EvGotoLabel
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = FrmEditor_Events.txtGotoLabel.Text

            Case EventType.EvSpawnNpc
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbSpawnNpc.SelectedIndex + 1

            Case EventType.EvFadeIn
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.EvFadeOut
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.EvFlashWhite
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.EvSetFog
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.nudFogData0.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = FrmEditor_Events.nudFogData1.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.nudFogData2.Value

            Case EventType.EvSetWeather
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.CmbWeather.SelectedIndex
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = FrmEditor_Events.nudWeatherIntensity.Value

            Case EventType.EvSetTint
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.nudMapTintData0.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = FrmEditor_Events.nudMapTintData1.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.nudMapTintData2.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = FrmEditor_Events.nudMapTintData3.Value

            Case EventType.EvWait
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.nudWaitAmount.Value

            Case EventType.EvBeginQuest
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbBeginQuest.SelectedIndex + 1

            Case EventType.EvEndQuest
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbEndQuest.SelectedIndex + 1

            Case EventType.EvQuestTask
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbCompleteQuest.SelectedIndex
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = FrmEditor_Events.nudCompleteQuestTask.Value

            Case EventType.EvShowPicture
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbPicIndex.SelectedIndex
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = FrmEditor_Events.nudShowPicture.Value

                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.cmbPicLoc.SelectedIndex + 1

                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = FrmEditor_Events.nudPicOffsetX.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data5 = FrmEditor_Events.nudPicOffsetY.Value

            Case EventType.EvHidePicture
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.nudHidePic.Value

            Case EventType.EvWaitMovement
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = ListOfEvents(FrmEditor_Events.cmbMoveWait.SelectedIndex)

            Case EventType.EvHoldPlayer
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.EvReleasePlayer
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
        End Select
        EventListCommands()

    End Sub

    Public Sub EditEventCommand()
        Dim i As Integer, X As Integer, curlist As Integer, curslot As Integer

        i = FrmEditor_Events.lstCommands.SelectedIndex
        If i = -1 Then Exit Sub
        If i > UBound(EventList) Then Exit Sub

        FrmEditor_Events.fraConditionalBranch.Visible = False
        FrmEditor_Events.fraDialogue.BringToFront()

        curlist = EventList(i).CommandList
        curslot = EventList(i).CommandNum
        If curlist = 0 Then Exit Sub
        If curslot = 0 Then Exit Sub
        If curlist > TmpEvent.Pages(CurPageNum).CommandListCount Then Exit Sub
        If curslot > TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount Then Exit Sub
        Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index
            Case EventType.EvAddText
                IsEdit = True
                FrmEditor_Events.txtAddText_Text.Text = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1
                'frmEditor_Events.scrlAddText_Colour.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2
                    Case 0
                        FrmEditor_Events.optAddText_Player.Checked = True
                    Case 1
                        FrmEditor_Events.optAddText_Map.Checked = True
                    Case 2
                        FrmEditor_Events.optAddText_Global.Checked = True
                End Select
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraAddText.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvCondition
                IsEdit = True
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraConditionalBranch.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
                FrmEditor_Events.ClearConditionFrame()

                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition
                    Case 0
                        FrmEditor_Events.optCondition0.Checked = True
                    Case 1
                        FrmEditor_Events.optCondition1.Checked = True
                    Case 2
                        FrmEditor_Events.optCondition2.Checked = True
                    Case 3
                        FrmEditor_Events.optCondition3.Checked = True
                    Case 4
                        FrmEditor_Events.optCondition4.Checked = True
                    Case 5
                        FrmEditor_Events.optCondition5.Checked = True
                    Case 6
                        FrmEditor_Events.optCondition6.Checked = True
                    Case 7
                        FrmEditor_Events.optCondition7.Checked = True
                    Case 8
                        FrmEditor_Events.optCondition8.Checked = True
                    Case 9
                        FrmEditor_Events.optCondition9.Checked = True
                End Select

                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition
                    Case 0
                        FrmEditor_Events.cmbCondition_PlayerVarIndex.Enabled = True
                        FrmEditor_Events.cmbCondition_PlayerVarCompare.Enabled = True
                        FrmEditor_Events.nudCondition_PlayerVarCondition.Enabled = True
                        FrmEditor_Events.cmbCondition_PlayerVarIndex.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 - 1
                        FrmEditor_Events.cmbCondition_PlayerVarCompare.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2
                        FrmEditor_Events.nudCondition_PlayerVarCondition.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3
                    Case 1
                        FrmEditor_Events.cmbCondition_PlayerSwitch.Enabled = True
                        FrmEditor_Events.cmbCondtion_PlayerSwitchCondition.Enabled = True
                        FrmEditor_Events.cmbCondition_PlayerSwitch.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 - 1
                        FrmEditor_Events.cmbCondtion_PlayerSwitchCondition.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2
                    Case 2
                        FrmEditor_Events.cmbCondition_HasItem.Enabled = True
                        FrmEditor_Events.nudCondition_HasItem.Enabled = True
                        FrmEditor_Events.cmbCondition_HasItem.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 - 1
                        FrmEditor_Events.nudCondition_HasItem.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2
                    Case 3
                        FrmEditor_Events.cmbCondition_ClassIs.Enabled = True
                        FrmEditor_Events.cmbCondition_ClassIs.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 - 1
                    Case 4
                        FrmEditor_Events.cmbCondition_LearntSkill.Enabled = True
                        FrmEditor_Events.cmbCondition_LearntSkill.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 - 1
                    Case 5
                        FrmEditor_Events.cmbCondition_LevelCompare.Enabled = True
                        FrmEditor_Events.nudCondition_LevelAmount.Enabled = True
                        FrmEditor_Events.nudCondition_LevelAmount.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1
                        FrmEditor_Events.cmbCondition_LevelCompare.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2
                    Case 6
                        FrmEditor_Events.cmbCondition_SelfSwitch.Enabled = True
                        FrmEditor_Events.cmbCondition_SelfSwitchCondition.Enabled = True
                        FrmEditor_Events.cmbCondition_SelfSwitch.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1
                        FrmEditor_Events.cmbCondition_SelfSwitchCondition.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2
                    Case 7
                        FrmEditor_Events.nudCondition_Quest.Enabled = True
                        FrmEditor_Events.nudCondition_Quest.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1
                        FrmEditor_Events.fraConditions_Quest.Visible = True
                        If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = 0 Then
                            FrmEditor_Events.optCondition_Quest0.Checked = True
                            FrmEditor_Events.cmbCondition_General.Enabled = True
                            FrmEditor_Events.cmbCondition_General.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3
                        ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = 1 Then
                            FrmEditor_Events.optCondition_Quest1.Checked = True
                            FrmEditor_Events.nudCondition_QuestTask.Enabled = True
                            FrmEditor_Events.nudCondition_QuestTask.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3
                        End If
                    Case 8
                        FrmEditor_Events.cmbCondition_Gender.Enabled = True
                        FrmEditor_Events.cmbCondition_Gender.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1
                    Case 9
                        FrmEditor_Events.cmbCondition_Time.Enabled = True
                        FrmEditor_Events.cmbCondition_Time.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1
                End Select
            Case EventType.EvShowText
                IsEdit = True
                FrmEditor_Events.txtShowText.Text = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1
                FrmEditor_Events.nudShowTextFace.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraShowText.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvShowChoices
                IsEdit = True
                FrmEditor_Events.txtChoicePrompt.Text = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1
                FrmEditor_Events.txtChoices1.Text = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text2
                FrmEditor_Events.txtChoices2.Text = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text3
                FrmEditor_Events.txtChoices3.Text = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text4
                FrmEditor_Events.txtChoices4.Text = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text5
                FrmEditor_Events.nudShowChoicesFace.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data5
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraShowChoices.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvPlayerVar
                IsEdit = True
                FrmEditor_Events.cmbVariable.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2
                    Case 0
                        FrmEditor_Events.optVariableAction0.Checked = True
                        FrmEditor_Events.nudVariableData0.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                    Case 1
                        FrmEditor_Events.optVariableAction1.Checked = True
                        FrmEditor_Events.nudVariableData1.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                    Case 2
                        FrmEditor_Events.optVariableAction2.Checked = True
                        FrmEditor_Events.nudVariableData2.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                    Case 3
                        FrmEditor_Events.optVariableAction3.Checked = True
                        FrmEditor_Events.nudVariableData3.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                        FrmEditor_Events.nudVariableData4.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4
                End Select
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraPlayerVariable.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvPlayerSwitch
                IsEdit = True
                FrmEditor_Events.cmbSwitch.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                FrmEditor_Events.cmbPlayerSwitchSet.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraPlayerSwitch.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvSelfSwitch
                IsEdit = True
                FrmEditor_Events.cmbSetSelfSwitch.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                FrmEditor_Events.cmbSetSelfSwitchTo.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraSetSelfSwitch.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvChangeItems
                IsEdit = True
                FrmEditor_Events.cmbChangeItemIndex.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0 Then
                    FrmEditor_Events.optChangeItemSet.Checked = True
                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1 Then
                    FrmEditor_Events.optChangeItemAdd.Checked = True
                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 2 Then
                    FrmEditor_Events.optChangeItemRemove.Checked = True
                End If
                FrmEditor_Events.nudChangeItemsAmount.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraChangeItems.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvChangeLevel
                IsEdit = True
                FrmEditor_Events.nudChangeLevel.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraChangeLevel.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvChangeSkills
                IsEdit = True
                FrmEditor_Events.cmbChangeSkills.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0 Then
                    FrmEditor_Events.optChangeSkillsAdd.Checked = True
                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1 Then
                    FrmEditor_Events.optChangeSkillsRemove.Checked = True
                End If
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraChangeSkills.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvChangeClass
                IsEdit = True
                FrmEditor_Events.cmbChangeClass.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraChangeClass.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvChangeSprite
                IsEdit = True
                FrmEditor_Events.nudChangeSprite.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraChangeSprite.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvChangeSex
                IsEdit = True
                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = 0 Then
                    FrmEditor_Events.optChangeSexMale.Checked = True
                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = 1 Then
                    FrmEditor_Events.optChangeSexFemale.Checked = True
                End If
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraChangeGender.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvChangePk
                IsEdit = True

                FrmEditor_Events.cmbSetPK.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1

                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraChangePK.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvWarpPlayer
                IsEdit = True
                FrmEditor_Events.nudWPMap.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                FrmEditor_Events.nudWPX.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2
                FrmEditor_Events.nudWPY.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                FrmEditor_Events.cmbWarpPlayerDir.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraPlayerWarp.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvSetMoveRoute
                IsEdit = True
                FrmEditor_Events.fraMoveRoute.Visible = True
                FrmEditor_Events.fraMoveRoute.BringToFront()
                FrmEditor_Events.lstMoveRoute.Items.Clear()
                FrmEditor_Events.cmbEvent.Items.Clear()
                ReDim ListOfEvents(0 To Map.EventCount)
                ListOfEvents(0) = EditorEvent
                FrmEditor_Events.cmbEvent.Items.Add("Este Evento")
                FrmEditor_Events.cmbEvent.SelectedIndex = 0
                FrmEditor_Events.cmbEvent.Enabled = True
                For i = 1 To Map.EventCount
                    If i <> EditorEvent Then
                        FrmEditor_Events.cmbEvent.Items.Add(Trim$(Map.Events(i).Name))
                        X = X + 1
                        ListOfEvents(X) = i
                        If i = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 Then FrmEditor_Events.cmbEvent.SelectedIndex = X
                    End If
                Next

                IsMoveRouteCommand = True
                FrmEditor_Events.chkIgnoreMove.Checked = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2
                FrmEditor_Events.chkRepeatRoute.Checked = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                TempMoveRouteCount = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).MoveRouteCount
                TempMoveRoute = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).MoveRoute
                For i = 1 To TempMoveRouteCount
                    Select Case TempMoveRoute(i).Index
                        Case 1
                            FrmEditor_Events.lstMoveRoute.Items.Add("Mover para Cima")
                        Case 2
                            FrmEditor_Events.lstMoveRoute.Items.Add("Mover para Baixo")
                        Case 3
                            FrmEditor_Events.lstMoveRoute.Items.Add("Mover para Esquerda")
                        Case 4
                            FrmEditor_Events.lstMoveRoute.Items.Add("Mover para Direita")
                        Case 5
                            FrmEditor_Events.lstMoveRoute.Items.Add("Mover Aleatoriamente")
                        Case 6
                            FrmEditor_Events.lstMoveRoute.Items.Add("Mover em Direção ao Jogador")
                        Case 7
                            FrmEditor_Events.lstMoveRoute.Items.Add("Mover para Longe do Jogador")
                        Case 8
                            FrmEditor_Events.lstMoveRoute.Items.Add("Passo para Frente")
                        Case 9
                            FrmEditor_Events.lstMoveRoute.Items.Add("Passo para Trás")
                        Case 10
                            FrmEditor_Events.lstMoveRoute.Items.Add("Esperar 100ms")
                        Case 11
                            FrmEditor_Events.lstMoveRoute.Items.Add("Esperar 500ms")
                        Case 12
                            FrmEditor_Events.lstMoveRoute.Items.Add("Esperar 1000ms")
                        Case 13
                            FrmEditor_Events.lstMoveRoute.Items.Add("Virar para Cima")
                        Case 14
                            FrmEditor_Events.lstMoveRoute.Items.Add("Virar para Baixo")
                        Case 15
                            FrmEditor_Events.lstMoveRoute.Items.Add("Virar para Esquerda")
                        Case 16
                            FrmEditor_Events.lstMoveRoute.Items.Add("Virar para Direita")
                        Case 17
                            FrmEditor_Events.lstMoveRoute.Items.Add("Virar 90 Graus à Direita")
                        Case 18
                            FrmEditor_Events.lstMoveRoute.Items.Add("Virar 90 Graus à Esquerda")
                        Case 19
                            FrmEditor_Events.lstMoveRoute.Items.Add("Virar em 180 Graus")
                        Case 20
                            FrmEditor_Events.lstMoveRoute.Items.Add("Virar Aleatoriamente")
                        Case 21
                            FrmEditor_Events.lstMoveRoute.Items.Add("Variar em Direção ao Jogador")
                        Case 22
                            FrmEditor_Events.lstMoveRoute.Items.Add("Virar Oposto ao Jogador")
                        Case 23
                            FrmEditor_Events.lstMoveRoute.Items.Add("Alterar Velocidade para 8x Mais Lento")
                        Case 24
                            FrmEditor_Events.lstMoveRoute.Items.Add("Alterar Velocidade para 4x Mais Lento")
                        Case 25
                            FrmEditor_Events.lstMoveRoute.Items.Add("Alterar Velocidade para 2x Mais Lento")
                        Case 26
                            FrmEditor_Events.lstMoveRoute.Items.Add("Alterar Velocidade para para Normal")
                        Case 27
                            FrmEditor_Events.lstMoveRoute.Items.Add("Alterar Velocidade para 2x Mais Rápido")
                        Case 28
                            FrmEditor_Events.lstMoveRoute.Items.Add("Alterar Velocidade para 4x Mais Rápido")
                        Case 29
                            FrmEditor_Events.lstMoveRoute.Items.Add("Alterar Frequencia para Mais Baixa")
                        Case 30
                            FrmEditor_Events.lstMoveRoute.Items.Add("Alterar Frequencia para Baixa")
                        Case 31
                            FrmEditor_Events.lstMoveRoute.Items.Add("Alterar Frequencia para Normal")
                        Case 32
                            FrmEditor_Events.lstMoveRoute.Items.Add("Alterar Frequencia para Alta")
                        Case 33
                            FrmEditor_Events.lstMoveRoute.Items.Add("Alterar Frequencia para Mais Alta")
                        Case 34
                            FrmEditor_Events.lstMoveRoute.Items.Add("Ligar Animação de Andar")
                        Case 35
                            FrmEditor_Events.lstMoveRoute.Items.Add("Desligar Animação de Andar")
                        Case 36
                            FrmEditor_Events.lstMoveRoute.Items.Add("Ligar Direção Fixada")
                        Case 37
                            FrmEditor_Events.lstMoveRoute.Items.Add("Desligar Direção Fixada")
                        Case 38
                            FrmEditor_Events.lstMoveRoute.Items.Add("Ligar o Atravessar Tudo")
                        Case 39
                            FrmEditor_Events.lstMoveRoute.Items.Add("Desligar o Atravessar Tudo")
                        Case 40
                            FrmEditor_Events.lstMoveRoute.Items.Add("Setar posição abaixo do Jogador")
                        Case 41
                            FrmEditor_Events.lstMoveRoute.Items.Add("Setar posição ao nível do Jogador")
                        Case 42
                            FrmEditor_Events.lstMoveRoute.Items.Add("Setar Posição Acima do Jogadorr")
                        Case 43
                            FrmEditor_Events.lstMoveRoute.Items.Add("Alterar Gráfico")
                    End Select
                Next
                FrmEditor_Events.fraMoveRoute.Width = 841
                FrmEditor_Events.fraMoveRoute.Height = 636
                FrmEditor_Events.fraMoveRoute.Visible = True
                FrmEditor_Events.fraDialogue.Visible = False
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvPlayAnimation
                IsEdit = True
                FrmEditor_Events.lblPlayAnimX.Visible = False
                FrmEditor_Events.lblPlayAnimY.Visible = False
                FrmEditor_Events.nudPlayAnimTileX.Visible = False
                FrmEditor_Events.nudPlayAnimTileY.Visible = False
                FrmEditor_Events.cmbPlayAnimEvent.Visible = False
                FrmEditor_Events.cmbPlayAnim.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                FrmEditor_Events.cmbPlayAnimEvent.Items.Clear()
                For i = 1 To Map.EventCount
                    FrmEditor_Events.cmbPlayAnimEvent.Items.Add(i & ". " & Trim$(Map.Events(i).Name))
                Next
                FrmEditor_Events.cmbPlayAnimEvent.SelectedIndex = 0
                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0 Then
                    FrmEditor_Events.cmbAnimTargetType.SelectedIndex = 0
                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1 Then
                    FrmEditor_Events.cmbAnimTargetType.SelectedIndex = 1
                    FrmEditor_Events.cmbPlayAnimEvent.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 - 1
                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 2 Then
                    FrmEditor_Events.cmbAnimTargetType.SelectedIndex = 2
                    FrmEditor_Events.nudPlayAnimTileX.Maximum = Map.MaxX
                    FrmEditor_Events.nudPlayAnimTileY.Maximum = Map.MaxY
                    FrmEditor_Events.nudPlayAnimTileX.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                    FrmEditor_Events.nudPlayAnimTileY.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4
                End If
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraPlayAnimation.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvCustomScript
                IsEdit = True
                FrmEditor_Events.nudCustomScript.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraCustomScript.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvPlayBgm
                IsEdit = True
                For i = 1 To UBound(MusicCache)
                    If MusicCache(i) = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 Then
                        FrmEditor_Events.cmbPlayBGM.SelectedIndex = i - 1
                    End If
                Next
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraPlayBGM.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvPlaySound
                IsEdit = True
                For i = 1 To UBound(SoundCache)
                    If SoundCache(i) = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 Then
                        FrmEditor_Events.cmbPlaySound.SelectedIndex = i - 1
                    End If
                Next
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraPlaySound.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvOpenShop
                IsEdit = True
                FrmEditor_Events.cmbOpenShop.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraOpenShop.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvSetAccess
                IsEdit = True
                FrmEditor_Events.cmbSetAccess.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraSetAccess.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvGiveExp
                IsEdit = True
                FrmEditor_Events.nudGiveExp.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraGiveExp.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvShowChatBubble
                IsEdit = True
                FrmEditor_Events.txtChatbubbleText.Text = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1
                FrmEditor_Events.cmbChatBubbleTargetType.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                FrmEditor_Events.cmbChatBubbleTarget.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 - 1

                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraShowChatBubble.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvLabel
                IsEdit = True
                FrmEditor_Events.txtLabelName.Text = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraCreateLabel.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvGotoLabel
                IsEdit = True
                FrmEditor_Events.txtGotoLabel.Text = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraGoToLabel.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvSpawnNpc
                IsEdit = True
                FrmEditor_Events.cmbSpawnNpc.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraSpawnNpc.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvSetFog
                IsEdit = True
                FrmEditor_Events.nudFogData0.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                FrmEditor_Events.nudFogData1.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2
                FrmEditor_Events.nudFogData2.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraSetFog.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvSetWeather
                IsEdit = True
                FrmEditor_Events.CmbWeather.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                FrmEditor_Events.nudWeatherIntensity.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraSetWeather.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvSetTint
                IsEdit = True
                FrmEditor_Events.nudMapTintData0.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                FrmEditor_Events.nudMapTintData1.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2
                FrmEditor_Events.nudMapTintData2.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                FrmEditor_Events.nudMapTintData3.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraMapTint.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvWait
                IsEdit = True
                FrmEditor_Events.nudWaitAmount.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraSetWait.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvBeginQuest
                IsEdit = True
                FrmEditor_Events.cmbBeginQuest.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraBeginQuest.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvEndQuest
                IsEdit = True
                FrmEditor_Events.cmbEndQuest.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraEndQuest.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvQuestTask
                IsEdit = True
                FrmEditor_Events.cmbCompleteQuest.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                FrmEditor_Events.nudCompleteQuestTask.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraCompleteTask.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvShowPicture
                IsEdit = True
                FrmEditor_Events.cmbPicIndex.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                FrmEditor_Events.nudShowPicture.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2

                FrmEditor_Events.cmbPicLoc.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 - 1

                FrmEditor_Events.nudPicOffsetX.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4
                FrmEditor_Events.nudPicOffsetY.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data5
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraShowPic.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvHidePicture
                IsEdit = True
                FrmEditor_Events.nudHidePic.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraHidePic.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
            Case EventType.EvWaitMovement
                IsEdit = True
                FrmEditor_Events.fraDialogue.Visible = True
                FrmEditor_Events.fraMoveRouteWait.Visible = True
                FrmEditor_Events.fraCommands.Visible = False
                FrmEditor_Events.cmbMoveWait.Items.Clear()
                ReDim ListOfEvents(0 To Map.EventCount)
                ListOfEvents(0) = EditorEvent
                FrmEditor_Events.cmbMoveWait.Items.Add("Este Evento")
                FrmEditor_Events.cmbMoveWait.SelectedIndex = 0
                For i = 1 To Map.EventCount
                    If i <> EditorEvent Then
                        FrmEditor_Events.cmbMoveWait.Items.Add(Trim$(Map.Events(i).Name))
                        X = X + 1
                        ListOfEvents(X) = i
                        If i = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 Then FrmEditor_Events.cmbMoveWait.SelectedIndex = X
                    End If
                Next
        End Select

    End Sub

    Public Sub DeleteEventCommand()
        Dim i As Integer, X As Integer, curlist As Integer, curslot As Integer, p As Integer, oldCommandList As CommandListRec

        i = FrmEditor_Events.lstCommands.SelectedIndex
        If i = -1 Then Exit Sub
        If i > UBound(EventList) Then Exit Sub
        curlist = EventList(i).CommandList
        curslot = EventList(i).CommandNum
        If curlist = 0 Then Exit Sub
        If curslot = 0 Then Exit Sub
        If curlist > TmpEvent.Pages(CurPageNum).CommandListCount Then Exit Sub
        If curslot > TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount Then Exit Sub
        If curslot = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount Then
            TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount - 1
            p = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount
            If p <= 0 Then
                ReDim TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(0)
            Else
                oldCommandList = TmpEvent.Pages(CurPageNum).CommandList(curlist)
                ReDim TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(p)
                X = 1
                TmpEvent.Pages(CurPageNum).CommandList(curlist).ParentList = oldCommandList.ParentList
                TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount = p
                For i = 1 To p + 1
                    If i <> curslot Then
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(X) = oldCommandList.Commands(i)
                        X = X + 1
                    End If
                Next
            End If
        Else
            TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount - 1
            p = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount
            oldCommandList = TmpEvent.Pages(CurPageNum).CommandList(curlist)
            X = 1
            If p <= 0 Then
                ReDim TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(0)
            Else
                ReDim TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(p)
                TmpEvent.Pages(CurPageNum).CommandList(curlist).ParentList = oldCommandList.ParentList
                TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount = p
                For i = 1 To p + 1
                    If i <> curslot Then
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(X) = oldCommandList.Commands(i)
                        X = X + 1
                    End If
                Next
            End If
        End If
        EventListCommands()

    End Sub

    Public Sub ClearEventCommands()

        ReDim TmpEvent.Pages(CurPageNum).CommandList(1)
        TmpEvent.Pages(CurPageNum).CommandListCount = 1
        EventListCommands()

    End Sub

    Public Sub EditCommand()
        Dim i As Integer, curlist As Integer, curslot As Integer

        i = FrmEditor_Events.lstCommands.SelectedIndex
        If i = -1 Then Exit Sub
        If i > UBound(EventList) Then Exit Sub

        curlist = EventList(i).CommandList
        curslot = EventList(i).CommandNum
        If curlist = 0 Then Exit Sub
        If curslot = 0 Then Exit Sub
        If curlist > TmpEvent.Pages(CurPageNum).CommandListCount Then Exit Sub
        If curslot > TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount Then Exit Sub
        Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index
            Case EventType.EvAddText
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = FrmEditor_Events.txtAddText_Text.Text
                'tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlAddText_Colour.Value
                If FrmEditor_Events.optAddText_Player.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf FrmEditor_Events.optAddText_Map.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                ElseIf FrmEditor_Events.optAddText_Global.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 2
                End If
            Case EventType.EvCondition
                If FrmEditor_Events.optCondition0.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 0
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = FrmEditor_Events.cmbCondition_PlayerVarIndex.SelectedIndex + 1
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = FrmEditor_Events.cmbCondition_PlayerVarCompare.SelectedIndex
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3 = FrmEditor_Events.nudCondition_PlayerVarCondition.Value
                ElseIf FrmEditor_Events.optCondition1.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 1
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = FrmEditor_Events.cmbCondition_PlayerSwitch.SelectedIndex + 1
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = FrmEditor_Events.cmbCondtion_PlayerSwitchCondition.SelectedIndex
                ElseIf FrmEditor_Events.optCondition2.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 2
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = FrmEditor_Events.cmbCondition_HasItem.SelectedIndex + 1
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = FrmEditor_Events.nudCondition_HasItem.Value
                ElseIf FrmEditor_Events.optCondition3.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 3
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = FrmEditor_Events.cmbCondition_ClassIs.SelectedIndex + 1
                ElseIf FrmEditor_Events.optCondition4.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 4
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = FrmEditor_Events.cmbCondition_LearntSkill.SelectedIndex + 1
                ElseIf FrmEditor_Events.optCondition5.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 5
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = FrmEditor_Events.nudCondition_LevelAmount.Value
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = FrmEditor_Events.cmbCondition_LevelCompare.SelectedIndex
                ElseIf FrmEditor_Events.optCondition6.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 6
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = FrmEditor_Events.cmbCondition_SelfSwitch.SelectedIndex
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = FrmEditor_Events.cmbCondition_SelfSwitchCondition.SelectedIndex
                ElseIf FrmEditor_Events.optCondition7.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 7
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = FrmEditor_Events.nudCondition_Quest.Value
                    If FrmEditor_Events.optCondition_Quest0.Checked Then
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = 0
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3 = FrmEditor_Events.cmbCondition_General.SelectedIndex
                    Else
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = 1
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3 = FrmEditor_Events.nudCondition_QuestTask.Value
                    End If
                ElseIf FrmEditor_Events.optCondition8.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 8
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = FrmEditor_Events.cmbCondition_Gender.SelectedIndex
                ElseIf FrmEditor_Events.optCondition9.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 9
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = FrmEditor_Events.cmbCondition_Time.SelectedIndex
                End If
            Case EventType.EvShowText
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = FrmEditor_Events.txtShowText.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.nudShowTextFace.Value
            Case EventType.EvShowChoices
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = FrmEditor_Events.txtChoicePrompt.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text2 = FrmEditor_Events.txtChoices1.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text3 = FrmEditor_Events.txtChoices2.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text4 = FrmEditor_Events.txtChoices3.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text5 = FrmEditor_Events.txtChoices4.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data5 = FrmEditor_Events.nudShowChoicesFace.Value
            Case EventType.EvPlayerVar
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbVariable.SelectedIndex + 1
                If FrmEditor_Events.optVariableAction0.Checked = True Then i = 0
                If FrmEditor_Events.optVariableAction1.Checked = True Then i = 1
                If FrmEditor_Events.optVariableAction2.Checked = True Then i = 2
                If FrmEditor_Events.optVariableAction3.Checked = True Then i = 3
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = i
                If i = 0 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.nudVariableData0.Value
                ElseIf i = 1 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.nudVariableData1.Value
                ElseIf i = 2 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.nudVariableData2.Value
                ElseIf i = 3 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.nudVariableData3.Value
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = FrmEditor_Events.nudVariableData4.Value
                End If
            Case EventType.EvPlayerSwitch
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbSwitch.SelectedIndex + 1
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = FrmEditor_Events.cmbPlayerSwitchSet.SelectedIndex
            Case EventType.EvSelfSwitch
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbSetSelfSwitch.SelectedIndex
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = FrmEditor_Events.cmbSetSelfSwitchTo.SelectedIndex
            Case EventType.EvChangeItems
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbChangeItemIndex.SelectedIndex + 1
                If FrmEditor_Events.optChangeItemSet.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf FrmEditor_Events.optChangeItemAdd.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                ElseIf FrmEditor_Events.optChangeItemRemove.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 2
                End If
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.nudChangeItemsAmount.Value
            Case EventType.EvChangeLevel
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.nudChangeLevel.Value
            Case EventType.EvChangeSkills
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbChangeSkills.SelectedIndex + 1
                If FrmEditor_Events.optChangeSkillsAdd.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf FrmEditor_Events.optChangeSkillsRemove.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                End If
            Case EventType.EvChangeClass
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbChangeClass.SelectedIndex + 1
            Case EventType.EvChangeSprite
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.nudChangeSprite.Value
            Case EventType.EvChangeSex
                If FrmEditor_Events.optChangeSexMale.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = 0
                ElseIf FrmEditor_Events.optChangeSexFemale.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = 1
                End If
            Case EventType.EvChangePk
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbSetPK.SelectedIndex

            Case EventType.EvWarpPlayer
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.nudWPMap.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = FrmEditor_Events.nudWPX.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.nudWPY.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = FrmEditor_Events.cmbWarpPlayerDir.SelectedIndex
            Case EventType.EvSetMoveRoute
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = ListOfEvents(FrmEditor_Events.cmbEvent.SelectedIndex)
                If FrmEditor_Events.chkIgnoreMove.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                Else
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                End If

                If FrmEditor_Events.chkRepeatRoute.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = 1
                Else
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = 0
                End If
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).MoveRouteCount = TempMoveRouteCount
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).MoveRoute = TempMoveRoute
            Case EventType.EvPlayAnimation
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbPlayAnim.SelectedIndex + 1
                If FrmEditor_Events.cmbAnimTargetType.SelectedIndex = 0 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf FrmEditor_Events.cmbAnimTargetType.SelectedIndex = 1 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.cmbPlayAnimEvent.SelectedIndex + 1
                ElseIf FrmEditor_Events.cmbAnimTargetType.SelectedIndex = 2 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 2
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.nudPlayAnimTileX.Value
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = FrmEditor_Events.nudPlayAnimTileY.Value
                End If
            Case EventType.EvCustomScript
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.nudCustomScript.Value
            Case EventType.EvPlayBgm
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = MusicCache(FrmEditor_Events.cmbPlayBGM.SelectedIndex + 1)
            Case EventType.EvPlaySound
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = SoundCache(FrmEditor_Events.cmbPlaySound.SelectedIndex + 1)
            Case EventType.EvOpenShop
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbOpenShop.SelectedIndex + 1
            Case EventType.EvSetAccess
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbSetAccess.SelectedIndex
            Case EventType.EvGiveExp
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.nudGiveExp.Value
            Case EventType.EvShowChatBubble
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = FrmEditor_Events.txtChatbubbleText.Text

                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbChatBubbleTargetType.SelectedIndex + 1
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = FrmEditor_Events.cmbChatBubbleTarget.SelectedIndex + 1
            Case EventType.EvLabel
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = FrmEditor_Events.txtLabelName.Text
            Case EventType.EvGotoLabel
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = FrmEditor_Events.txtGotoLabel.Text
            Case EventType.EvSpawnNpc
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbSpawnNpc.SelectedIndex + 1
            Case EventType.EvSetFog
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.nudFogData0.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = FrmEditor_Events.nudFogData1.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.nudFogData2.Value
            Case EventType.EvSetWeather
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.CmbWeather.SelectedIndex
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = FrmEditor_Events.nudWeatherIntensity.Value
            Case EventType.EvSetTint
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.nudMapTintData0.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = FrmEditor_Events.nudMapTintData1.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.nudMapTintData2.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = FrmEditor_Events.nudMapTintData3.Value
            Case EventType.EvWait
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.nudWaitAmount.Value
            Case EventType.EvBeginQuest
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbBeginQuest.SelectedIndex
            Case EventType.EvEndQuest
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbEndQuest.SelectedIndex
            Case EventType.EvQuestTask
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbCompleteQuest.SelectedIndex
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = FrmEditor_Events.nudCompleteQuestTask.Value
            Case EventType.EvShowPicture
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.cmbPicIndex.SelectedIndex
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = FrmEditor_Events.nudShowPicture.Value

                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = FrmEditor_Events.cmbPicLoc.SelectedIndex + 1

                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = FrmEditor_Events.nudPicOffsetX.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data5 = FrmEditor_Events.nudPicOffsetY.Value
            Case EventType.EvHidePicture
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = FrmEditor_Events.nudHidePic.Value
            Case EventType.EvWaitMovement
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = ListOfEvents(FrmEditor_Events.cmbMoveWait.SelectedIndex)
        End Select
        EventListCommands()

    End Sub

#End Region

#Region "Incoming Packets"

    Sub Packet_SpawnEvent(ByRef data() As Byte)
        Dim id As Integer
        Dim buffer As New ByteStream(data)
        id = buffer.ReadInt32
        If id > Map.CurrentEvents Then
            Map.CurrentEvents = id
            ReDim Preserve Map.MapEvents(Map.CurrentEvents)
        End If

        With Map.MapEvents(id)
            .Name = buffer.ReadString
            .Dir = buffer.ReadInt32
            .ShowDir = .Dir
            .GraphicNum = buffer.ReadInt32
            .GraphicType = buffer.ReadInt32
            .GraphicX = buffer.ReadInt32
            .GraphicX2 = buffer.ReadInt32
            .GraphicY = buffer.ReadInt32
            .GraphicY2 = buffer.ReadInt32
            .MovementSpeed = buffer.ReadInt32
            .Moving = 0
            .X = buffer.ReadInt32
            .Y = buffer.ReadInt32
            .XOffset = 0
            .YOffset = 0
            .Position = buffer.ReadInt32
            .Visible = buffer.ReadInt32
            .WalkAnim = buffer.ReadInt32
            .DirFix = buffer.ReadInt32
            .WalkThrough = buffer.ReadInt32
            .ShowName = buffer.ReadInt32
            .Questnum = buffer.ReadInt32
        End With
        buffer.Dispose()

    End Sub

    Sub Packet_EventMove(ByRef data() As Byte)
        Dim id As Integer
        Dim x As Integer
        Dim y As Integer
        Dim dir As Integer, showDir As Integer
        Dim movementSpeed As Integer
        Dim buffer As New ByteStream(data)
        id = buffer.ReadInt32
        x = buffer.ReadInt32
        y = buffer.ReadInt32
        dir = buffer.ReadInt32
        showDir = buffer.ReadInt32
        movementSpeed = buffer.ReadInt32
        If id > Map.CurrentEvents Then Exit Sub

        With Map.MapEvents(id)
            .X = x
            .Y = y
            .Dir = dir
            .XOffset = 0
            .YOffset = 0
            .Moving = 1
            .ShowDir = showDir
            .MovementSpeed = movementSpeed

            Select Case dir
                Case DirectionType.Up
                    .YOffset = PicY
                Case DirectionType.Down
                    .YOffset = PicY * -1
                Case DirectionType.Left
                    .XOffset = PicX
                Case DirectionType.Right
                    .XOffset = PicX * -1
            End Select

        End With

    End Sub

    Sub Packet_EventDir(ByRef data() As Byte)
        Dim i As Integer
        Dim dir As Byte
        Dim buffer As New ByteStream(data)
        i = buffer.ReadInt32
        dir = buffer.ReadInt32
        If i > Map.CurrentEvents Then Exit Sub

        With Map.MapEvents(i)
            .Dir = dir
            .ShowDir = dir
            .XOffset = 0
            .YOffset = 0
            .Moving = 0
        End With

    End Sub

    Sub Packet_SwitchesAndVariables(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)
        For i = 1 To MaxSwitches
            Switches(i) = buffer.ReadString
        Next
        For i = 1 To MaxVariables
            Variables(i) = buffer.ReadString
        Next

        buffer.Dispose()

    End Sub

    Sub Packet_MapEventData(ByRef data() As Byte)
        Dim i As Integer, x As Integer, y As Integer, z As Integer, w As Integer
        Dim buffer As New ByteStream(data)
        'Dados de Evento!
        Map.EventCount = buffer.ReadInt32
        If Map.EventCount > 0 Then
            ReDim Map.Events(Map.EventCount)
            For i = 1 To Map.EventCount
                With Map.Events(i)
                    .Name = buffer.ReadString
                    .Globals = buffer.ReadInt32
                    .X = buffer.ReadInt32
                    .Y = buffer.ReadInt32
                    .PageCount = buffer.ReadInt32
                End With
                If Map.Events(i).PageCount > 0 Then
                    ReDim Map.Events(i).Pages(Map.Events(i).PageCount)
                    For x = 1 To Map.Events(i).PageCount
                        With Map.Events(i).Pages(x)
                            .ChkVariable = buffer.ReadInt32
                            .Variableindex = buffer.ReadInt32
                            .VariableCondition = buffer.ReadInt32
                            .VariableCompare = buffer.ReadInt32
                            .ChkSwitch = buffer.ReadInt32
                            .Switchindex = buffer.ReadInt32
                            .SwitchCompare = buffer.ReadInt32
                            .ChkHasItem = buffer.ReadInt32
                            .HasItemindex = buffer.ReadInt32
                            .HasItemAmount = buffer.ReadInt32
                            .ChkSelfSwitch = buffer.ReadInt32
                            .SelfSwitchindex = buffer.ReadInt32
                            .SelfSwitchCompare = buffer.ReadInt32
                            .GraphicType = buffer.ReadInt32
                            .Graphic = buffer.ReadInt32
                            .GraphicX = buffer.ReadInt32
                            .GraphicY = buffer.ReadInt32
                            .GraphicX2 = buffer.ReadInt32
                            .GraphicY2 = buffer.ReadInt32
                            .MoveType = buffer.ReadInt32
                            .MoveSpeed = buffer.ReadInt32
                            .MoveFreq = buffer.ReadInt32
                            .MoveRouteCount = buffer.ReadInt32
                            .IgnoreMoveRoute = buffer.ReadInt32
                            .RepeatMoveRoute = buffer.ReadInt32
                            If .MoveRouteCount > 0 Then
                                ReDim Map.Events(i).Pages(x).MoveRoute(.MoveRouteCount)
                                For y = 1 To .MoveRouteCount
                                    .MoveRoute(y).Index = buffer.ReadInt32
                                    .MoveRoute(y).Data1 = buffer.ReadInt32
                                    .MoveRoute(y).Data2 = buffer.ReadInt32
                                    .MoveRoute(y).Data3 = buffer.ReadInt32
                                    .MoveRoute(y).Data4 = buffer.ReadInt32
                                    .MoveRoute(y).Data5 = buffer.ReadInt32
                                    .MoveRoute(y).Data6 = buffer.ReadInt32
                                Next
                            End If
                            .WalkAnim = buffer.ReadInt32
                            .DirFix = buffer.ReadInt32
                            .WalkThrough = buffer.ReadInt32
                            .ShowName = buffer.ReadInt32
                            .Trigger = buffer.ReadInt32
                            .CommandListCount = buffer.ReadInt32
                            .Position = buffer.ReadInt32
                            .Questnum = buffer.ReadInt32
                        End With
                        If Map.Events(i).Pages(x).CommandListCount > 0 Then
                            ReDim Map.Events(i).Pages(x).CommandList(Map.Events(i).Pages(x).CommandListCount)
                            For y = 1 To Map.Events(i).Pages(x).CommandListCount
                                Map.Events(i).Pages(x).CommandList(y).CommandCount = buffer.ReadInt32
                                Map.Events(i).Pages(x).CommandList(y).ParentList = buffer.ReadInt32
                                If Map.Events(i).Pages(x).CommandList(y).CommandCount > 0 Then
                                    ReDim Map.Events(i).Pages(x).CommandList(y).Commands(Map.Events(i).Pages(x).CommandList(y).CommandCount)
                                    For z = 1 To Map.Events(i).Pages(x).CommandList(y).CommandCount
                                        With Map.Events(i).Pages(x).CommandList(y).Commands(z)
                                            .Index = buffer.ReadInt32
                                            .Text1 = buffer.ReadString
                                            .Text2 = buffer.ReadString
                                            .Text3 = buffer.ReadString
                                            .Text4 = buffer.ReadString
                                            .Text5 = buffer.ReadString
                                            .Data1 = buffer.ReadInt32
                                            .Data2 = buffer.ReadInt32
                                            .Data3 = buffer.ReadInt32
                                            .Data4 = buffer.ReadInt32
                                            .Data5 = buffer.ReadInt32
                                            .Data6 = buffer.ReadInt32
                                            .ConditionalBranch.CommandList = buffer.ReadInt32
                                            .ConditionalBranch.Condition = buffer.ReadInt32
                                            .ConditionalBranch.Data1 = buffer.ReadInt32
                                            .ConditionalBranch.Data2 = buffer.ReadInt32
                                            .ConditionalBranch.Data3 = buffer.ReadInt32
                                            .ConditionalBranch.ElseCommandList = buffer.ReadInt32
                                            .MoveRouteCount = buffer.ReadInt32
                                            If .MoveRouteCount > 0 Then
                                                ReDim Preserve .MoveRoute(.MoveRouteCount)
                                                For w = 1 To .MoveRouteCount
                                                    .MoveRoute(w).Index = buffer.ReadInt32
                                                    .MoveRoute(w).Data1 = buffer.ReadInt32
                                                    .MoveRoute(w).Data2 = buffer.ReadInt32
                                                    .MoveRoute(w).Data3 = buffer.ReadInt32
                                                    .MoveRoute(w).Data4 = buffer.ReadInt32
                                                    .MoveRoute(w).Data5 = buffer.ReadInt32
                                                    .MoveRoute(w).Data6 = buffer.ReadInt32
                                                Next
                                            End If
                                        End With
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        End If
        'Fim dos Dados de Evento
        buffer.Dispose()

    End Sub

    Sub Packet_EventChat(ByRef data() As Byte)
        Dim i As Integer
        Dim choices As Integer
        Dim buffer As New ByteStream(data)
        EventReplyId = buffer.ReadInt32
        EventReplyPage = buffer.ReadInt32
        EventChatFace = buffer.ReadInt32
        EventText = buffer.ReadString
        If EventText = "" Then EventText = " "
        EventChat = True
        ShowEventLbl = True
        choices = buffer.ReadInt32
        InEvent = True
        For i = 1 To 4
            EventChoices(i) = ""
            EventChoiceVisible(i) = False
        Next
        EventChatType = 0
        If choices = 0 Then
        Else
            EventChatType = 1
            For i = 1 To choices
                EventChoices(i) = buffer.ReadString
                EventChoiceVisible(i) = True
            Next
        End If
        AnotherChat = buffer.ReadInt32

        buffer.Dispose()

    End Sub

    Sub Packet_EventStart(ByRef data() As Byte)
        InEvent = True
    End Sub

    Sub Packet_EventEnd(ByRef data() As Byte)
        InEvent = False
    End Sub

    Sub Packet_HoldPlayer(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        If buffer.ReadInt32 = 0 Then
            HoldPlayer = True
        Else
            HoldPlayer = False
        End If

        buffer.Dispose()

    End Sub

    Sub Packet_PlayBGM(ByRef data() As Byte)
        Dim music As String
        Dim buffer As New ByteStream(data)
        music = buffer.ReadString

        PlayMusic(music)

        buffer.Dispose()
    End Sub

    Sub Packet_FadeOutBGM(ByRef data() As Byte)
        CurMusic = ""
        FadeOutSwitch = True
    End Sub

    Sub Packet_PlaySound(ByRef data() As Byte)
        Dim sound As String
        Dim buffer As New ByteStream(data)
        sound = buffer.ReadString

        PlaySound(sound)

        buffer.Dispose()
    End Sub

    Sub Packet_StopSound(ByRef data() As Byte)
        StopSound()
    End Sub

    Sub Packet_SpecialEffect(ByRef data() As Byte)
        Dim effectType As Integer
        Dim buffer As New ByteStream(data)
        effectType = buffer.ReadInt32

        Select Case effectType
            Case EffectTypeFadein
                UseFade = True
                FadeType = 1
                FadeAmount = 0
            Case EffectTypeFadeout
                UseFade = True
                FadeType = 0
                FadeAmount = 255
            Case EffectTypeFlash
                FlashTimer = GetTickCount() + 150
            Case EffectTypeFog
                CurrentFog = buffer.ReadInt32
                CurrentFogSpeed = buffer.ReadInt32
                CurrentFogOpacity = buffer.ReadInt32
            Case EffectTypeWeather
                CurrentWeather = buffer.ReadInt32
                CurrentWeatherIntensity = buffer.ReadInt32
            Case EffectTypeTint
                Map.HasMapTint = 1
                CurrentTintR = buffer.ReadInt32
                CurrentTintG = buffer.ReadInt32
                CurrentTintB = buffer.ReadInt32
                CurrentTintA = buffer.ReadInt32
        End Select

        buffer.Dispose()
    End Sub

#End Region

#Region "Outgoing Packets"

    Sub RequestSwitchesAndVariables()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CRequestSwitchesAndVariables)
        Socket.SendData(buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendSwitchesAndVariables()
        Dim i As Integer
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CSwitchesAndVariables)

        For i = 1 To MaxSwitches
            buffer.WriteString((Trim$(Switches(i))))
        Next
        For i = 1 To MaxVariables
            buffer.WriteString((Trim$(Variables(i))))
        Next

        Socket.SendData(buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

#End Region

#Region "Drawing..."

    Public Sub EditorEvent_DrawGraphic()
        Dim sRect As Rect
        Dim dRect As Rect
        Dim targetBitmap As Bitmap 'Bitmap para o qual desenhamos
        Dim sourceBitmap As Bitmap 'Esta é nossa sprite ou tileset fonte que estamos desenhando
        Dim g As Graphics 'Classe de gráficos que nos ajuda a desenhar

        If FrmEditor_Events.picGraphicSel.Visible Then
            Select Case FrmEditor_Events.cmbGraphic.SelectedIndex
                Case 0
                    'Nenhum
                    FrmEditor_Events.picGraphicSel.BackgroundImage = Nothing
                Case 1
                    If FrmEditor_Events.nudGraphic.Value > 0 AndAlso FrmEditor_Events.nudGraphic.Value <= NumCharacters Then
                        'Carregar personagem da pasta de Contents para nosso sourceBitmap
                        sourceBitmap = New Bitmap(Application.StartupPath & "/Data/graphics/characters/" & FrmEditor_Events.nudGraphic.Value & ".png")
                        targetBitmap = New Bitmap(sourceBitmap.Width, sourceBitmap.Height) 'Criar nosso bitmap alvo

                        g = Graphics.FromImage(targetBitmap)
                        'Esta é a seção que estamos puxando no gráfico fonte  
                        Dim sourceRect As New Rectangle(0, 0, sourceBitmap.Width / 4, sourceBitmap.Height / 4)
                        'Este é o retângulo no gráfico alvo que queremos renderizar 
                        Dim destRect As New Rectangle(0, 0, targetBitmap.Width / 4, targetBitmap.Height / 4)

                        g.DrawImage(sourceBitmap, destRect, sourceRect, GraphicsUnit.Pixel)

                        g.DrawRectangle(Pens.Red, New Rectangle(GraphicSelX * PicX, GraphicSelY * PicY, GraphicSelX2 * PicX, GraphicSelY2 * PicY))

                        FrmEditor_Events.picGraphicSel.Width = targetBitmap.Width
                        FrmEditor_Events.picGraphicSel.Height = targetBitmap.Height
                        FrmEditor_Events.picGraphicSel.Visible = True
                        FrmEditor_Events.picGraphicSel.BackgroundImage = targetBitmap
                        FrmEditor_Events.picGraphic.BackgroundImage = targetBitmap

                        g.Dispose()
                    Else
                        FrmEditor_Events.picGraphicSel.BackgroundImage = Nothing
                        Exit Sub
                    End If
                Case 2
                    If FrmEditor_Events.nudGraphic.Value > 0 AndAlso FrmEditor_Events.nudGraphic.Value <= NumTileSets Then
                        'Carregar  tilesheet de Contents no nosso bitmap fonte
                        sourceBitmap = New Bitmap(Application.StartupPath & "/Data/graphics/tilesets/" & FrmEditor_Events.nudGraphic.Value & ".png")
                        targetBitmap = New Bitmap(sourceBitmap.Width, sourceBitmap.Height) 'Criar o Bitmap alvo

                        If TmpEvent.Pages(CurPageNum).GraphicX2 = 0 AndAlso TmpEvent.Pages(CurPageNum).GraphicY2 = 0 Then
                            sRect.Top = TmpEvent.Pages(CurPageNum).GraphicY * 32
                            sRect.Left = TmpEvent.Pages(CurPageNum).GraphicX * 32
                            sRect.Bottom = sRect.Top + 32
                            sRect.Right = sRect.Left + 32

                            With dRect
                                dRect.Top = (193 / 2) - ((sRect.Bottom - sRect.Top) / 2)
                                dRect.Bottom = dRect.Top + (sRect.Bottom - sRect.Top)
                                dRect.Left = (120 / 2) - ((sRect.Right - sRect.Left) / 2)
                                dRect.Right = dRect.Left + (sRect.Right - sRect.Left)
                            End With
                        Else
                            sRect.Top = TmpEvent.Pages(CurPageNum).GraphicY * 32
                            sRect.Left = TmpEvent.Pages(CurPageNum).GraphicX * 32
                            sRect.Bottom = sRect.Top + ((TmpEvent.Pages(CurPageNum).GraphicY2 - TmpEvent.Pages(CurPageNum).GraphicY) * 32)
                            sRect.Right = sRect.Left + ((TmpEvent.Pages(CurPageNum).GraphicX2 - TmpEvent.Pages(CurPageNum).GraphicX) * 32)

                            With dRect
                                dRect.Top = (193 / 2) - ((sRect.Bottom - sRect.Top) / 2)
                                dRect.Bottom = dRect.Top + (sRect.Bottom - sRect.Top)
                                dRect.Left = (120 / 2) - ((sRect.Right - sRect.Left) / 2)
                                dRect.Right = dRect.Left + (sRect.Right - sRect.Left)
                            End With

                        End If

                        g = Graphics.FromImage(targetBitmap)

                        Dim sourceRect As New Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height)  'This is the section we are pulling from the source graphic
                        Dim destRect As New Rectangle(0, 0, targetBitmap.Width, targetBitmap.Height)     'This is the rectangle in the target graphic we want to render to

                        g.DrawImage(sourceBitmap, destRect, sourceRect, GraphicsUnit.Pixel)

                        g.DrawRectangle(Pens.Red, New Rectangle(GraphicSelX * PicX, GraphicSelY * PicY, (GraphicSelX2) * PicX, (GraphicSelY2) * PicY))

                        g.Dispose()

                        FrmEditor_Events.picGraphicSel.Width = targetBitmap.Width
                        FrmEditor_Events.picGraphicSel.Height = targetBitmap.Height
                        FrmEditor_Events.picGraphicSel.Visible = True
                        FrmEditor_Events.picGraphicSel.BackgroundImage = targetBitmap
                        ' frmEditor_Events.pnlGraphicSelect.Width = targetBitmap.Width
                        'frmEditor_Events.pnlGraphicSelect.Height = targetBitmap.Height
                    Else
                        FrmEditor_Events.picGraphicSel.BackgroundImage = Nothing
                        Exit Sub
                    End If
            End Select
        Else
            If TmpEvent.PageCount > 0 Then
                Select Case TmpEvent.Pages(CurPageNum).GraphicType
                    Case 0
                        FrmEditor_Events.picGraphicSel.BackgroundImage = Nothing
                    Case 1
                        If TmpEvent.Pages(CurPageNum).Graphic > 0 AndAlso TmpEvent.Pages(CurPageNum).Graphic <= NumCharacters Then
                            'Carregar personagem de Contents para nosso bitmap fonte 
                            sourceBitmap = New Bitmap(Path.Graphics & "\Personagens\" & TmpEvent.Pages(CurPageNum).Graphic & ".png")
                            targetBitmap = New Bitmap(sourceBitmap.Width, sourceBitmap.Height) 'Criar nosso bitmap alvo

                            g = Graphics.FromImage(targetBitmap)

                            Dim sourceRect As New Rectangle(0, 0, sourceBitmap.Width / 4, sourceBitmap.Height / 4)
                            Dim destRect As New Rectangle(0, 0, targetBitmap.Width / 4, targetBitmap.Height / 4)

                            g.DrawImage(sourceBitmap, destRect, sourceRect, GraphicsUnit.Pixel)

                            g.Dispose()

                            FrmEditor_Events.picGraphic.Width = targetBitmap.Width
                            FrmEditor_Events.picGraphic.Height = targetBitmap.Height
                            FrmEditor_Events.picGraphic.BackgroundImage = targetBitmap
                        Else
                            FrmEditor_Events.picGraphic.BackgroundImage = Nothing
                            Exit Sub
                        End If
                    Case 2
                        If TmpEvent.Pages(CurPageNum).Graphic > 0 AndAlso TmpEvent.Pages(CurPageNum).Graphic <= NumTileSets Then
                            ''Carregar  tilesheet de Contents no nosso bitmap fonte
                            sourceBitmap = New Bitmap(Path.Graphics & "tilesets\" & TmpEvent.Pages(CurPageNum).Graphic & ".png")
                            targetBitmap = New Bitmap(sourceBitmap.Width, sourceBitmap.Height) 'Criar nosso Bitmap alvo

                            If TmpEvent.Pages(CurPageNum).GraphicX2 = 0 AndAlso TmpEvent.Pages(CurPageNum).GraphicY2 = 0 Then
                                sRect.Top = TmpEvent.Pages(CurPageNum).GraphicY * 32
                                sRect.Left = TmpEvent.Pages(CurPageNum).GraphicX * 32
                                sRect.Bottom = sRect.Top + 32
                                sRect.Right = sRect.Left + 32

                                With dRect
                                    dRect.Top = 0
                                    dRect.Bottom = PicY
                                    dRect.Left = 0
                                    dRect.Right = PicX
                                End With
                            Else
                                sRect.Top = TmpEvent.Pages(CurPageNum).GraphicY * 32
                                sRect.Left = TmpEvent.Pages(CurPageNum).GraphicX * 32
                                sRect.Bottom = TmpEvent.Pages(CurPageNum).GraphicY2 * 32
                                sRect.Right = TmpEvent.Pages(CurPageNum).GraphicX2 * 32

                                With dRect
                                    dRect.Top = 0
                                    dRect.Bottom = sRect.Bottom
                                    dRect.Left = 0
                                    dRect.Right = sRect.Right
                                End With

                            End If

                            g = Graphics.FromImage(targetBitmap)

                            Dim sourceRect As New Rectangle(sRect.Left, sRect.Top, sRect.Right, sRect.Bottom)  'This is the section we are pulling from the source graphic
                            Dim destRect As New Rectangle(dRect.Left, dRect.Top, dRect.Right, dRect.Bottom)     'This is the rectangle in the target graphic we want to render to

                            g.DrawImage(sourceBitmap, destRect, sourceRect, GraphicsUnit.Pixel)

                            g.Dispose()

                            FrmEditor_Events.picGraphic.Width = targetBitmap.Width
                            FrmEditor_Events.picGraphic.Height = targetBitmap.Height
                            FrmEditor_Events.picGraphic.BackgroundImage = targetBitmap
                        End If
                End Select
            End If
        End If

    End Sub

    Friend Sub DrawEvents()
        Dim rec As Rectangle
        Dim width As Integer, height As Integer, i As Integer, x As Integer, y As Integer
        Dim tX As Integer
        Dim tY As Integer

        If Map.EventCount <= 0 Then Exit Sub
        For i = 1 To Map.EventCount
            width = 32
            height = 32
            x = Map.Events(i).X * 32
            y = Map.Events(i).Y * 32
            If Map.Events(i).PageCount <= 0 Then
                With rec
                    .Y = 0
                    .Height = PicY
                    .X = 0
                    .Width = PicX
                End With

                Dim rec2 As New RectangleShape With {
                    .OutlineColor = New SFML.Graphics.Color(SFML.Graphics.Color.Blue),
                    .OutlineThickness = 0.6,
                    .FillColor = New SFML.Graphics.Color(SFML.Graphics.Color.Transparent),
                    .Size = New Vector2f(rec.Width, rec.Height),
                    .Position = New Vector2f(ConvertMapX(CurX * PicX), ConvertMapY(CurY * PicY))
                }
                GameWindow.Draw(rec2)
                GoTo nextevent
            End If
            x = ConvertMapX(x)
            y = ConvertMapY(y)
            If i > Map.EventCount Then Exit Sub
            If 1 > Map.Events(i).PageCount Then Exit Sub
            Select Case Map.Events(i).Pages(1).GraphicType
                Case 0
                    tX = ((x) - 4) + (PicX * 0.5)
                    tY = ((y) - 7) + (PicY * 0.5)
                    DrawText(tX, tY, "EV", (SFML.Graphics.Color.Green), (SFML.Graphics.Color.Black), GameWindow)
                Case 1
                    If Map.Events(i).Pages(1).Graphic > 0 AndAlso Map.Events(i).Pages(1).Graphic <= NumCharacters Then
                        If CharacterGfxInfo(Map.Events(i).Pages(1).Graphic).IsLoaded = False Then
                            LoadTexture(Map.Events(i).Pages(1).Graphic, 2)
                        End If

                        'vendo que ainda vamos utilizar, atulizar contador
                        With CharacterGfxInfo(Map.Events(i).Pages(1).Graphic)
                            .TextureTimer = GetTickCount() + 100000
                        End With
                        With rec
                            .Y = (Map.Events(i).Pages(1).GraphicY * (CharacterGfxInfo(Map.Events(i).Pages(1).Graphic).Height / 4))
                            .Height = .Y + PicY
                            .X = (Map.Events(i).Pages(1).GraphicX * (CharacterGfxInfo(Map.Events(i).Pages(1).Graphic).Width / 4))
                            .Width = .X + PicX
                        End With

                        Dim tmpSprite As Sprite = New Sprite(CharacterGfx(Map.Events(i).Pages(1).Graphic)) With {
                            .TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height),
                            .Position = New Vector2f(ConvertMapX(Map.Events(i).X * PicX), ConvertMapY(Map.Events(i).Y * PicY))
                        }
                        GameWindow.Draw(tmpSprite)
                    Else
                        With rec
                            .Y = 0
                            .Height = PicY
                            .X = 0
                            .Width = PicX
                        End With

                        Dim rec2 As New RectangleShape With {
                            .OutlineColor = New SFML.Graphics.Color(SFML.Graphics.Color.Blue),
                            .OutlineThickness = 0.6,
                            .FillColor = New SFML.Graphics.Color(SFML.Graphics.Color.Transparent),
                            .Size = New Vector2f(rec.Width, rec.Height),
                            .Position = New Vector2f(ConvertMapX(CurX * PicX), ConvertMapY(CurY * PicY))
                        }
                        GameWindow.Draw(rec2)
                    End If
                Case 2
                    If Map.Events(i).Pages(1).Graphic > 0 AndAlso Map.Events(i).Pages(1).Graphic <= NumTileSets Then
                        With rec
                            .X = Map.Events(i).Pages(1).GraphicX * 32
                            .Width = Map.Events(i).Pages(1).GraphicX2 * 32
                            .Y = Map.Events(i).Pages(1).GraphicY * 32
                            .Height = Map.Events(i).Pages(1).GraphicY2 * 32
                        End With

                        If TileSetTextureInfo(Map.Events(i).Pages(1).Graphic).IsLoaded = False Then
                            LoadTexture(Map.Events(i).Pages(1).Graphic, 1)
                        End If
                        ' ainda usamos, vamos atualizar contador
                        With TileSetTextureInfo(Map.Events(i).Pages(1).Graphic)
                            .TextureTimer = GetTickCount() + 100000
                        End With

                        If rec.Height > 32 Then
                            RenderSprite(TileSetSprite(Map.Events(i).Pages(1).Graphic), GameWindow, ConvertMapX(Map.Events(i).X * PicX), ConvertMapY(Map.Events(i).Y * PicY) - PicY, rec.X, rec.Y, rec.Width, rec.Height)
                        Else
                            RenderSprite(TileSetSprite(Map.Events(i).Pages(1).Graphic), GameWindow, ConvertMapX(Map.Events(i).X * PicX), ConvertMapY(Map.Events(i).Y * PicY), rec.X, rec.Y, rec.Width, rec.Height)
                        End If
                    Else
                        With rec
                            .Y = 0
                            .Height = PicY
                            .X = 0
                            .Width = PicX
                        End With

                        Dim rec2 As New RectangleShape With {
                            .OutlineColor = New SFML.Graphics.Color(SFML.Graphics.Color.Blue),
                            .OutlineThickness = 0.6,
                            .FillColor = New SFML.Graphics.Color(SFML.Graphics.Color.Transparent),
                            .Size = New Vector2f(rec.Width, rec.Height),
                            .Position = New Vector2f(ConvertMapX(CurX * PicX), ConvertMapY(CurY * PicY))
                        }
                        GameWindow.Draw(rec2)
                    End If
            End Select
nextevent:
        Next

    End Sub

    Friend Sub DrawEvent(id As Integer) ' desenhar no mapa, fora do editor
        Dim x As Integer, y As Integer, width As Integer, height As Integer, sRect As Rectangle, anim As Integer, spritetop As Integer

        If Map.MapEvents(id).Visible = 0 Then Exit Sub

        Select Case Map.MapEvents(id).GraphicType
            Case 0
                Exit Sub
            Case 1
                If Map.MapEvents(id).GraphicNum <= 0 OrElse Map.MapEvents(id).GraphicNum > NumCharacters Then Exit Sub

                ' Resetar frame
                If Map.MapEvents(id).Steps = 3 Then
                    anim = 0
                ElseIf Map.MapEvents(id).Steps = 1 Then
                    anim = 2
                End If

                Select Case Map.MapEvents(id).Dir
                    Case DirectionType.Up
                        If (Map.MapEvents(id).YOffset > 8) Then anim = Map.MapEvents(id).Steps
                    Case DirectionType.Down
                        If (Map.MapEvents(id).YOffset < -8) Then anim = Map.MapEvents(id).Steps
                    Case DirectionType.Left
                        If (Map.MapEvents(id).XOffset > 8) Then anim = Map.MapEvents(id).Steps
                    Case DirectionType.Right
                        If (Map.MapEvents(id).XOffset < -8) Then anim = Map.MapEvents(id).Steps
                End Select

                ' Setar a esquerda
                Select Case Map.MapEvents(id).ShowDir
                    Case DirectionType.Up
                        spritetop = 3
                    Case DirectionType.Right
                        spritetop = 2
                    Case DirectionType.Down
                        spritetop = 0
                    Case DirectionType.Left
                        spritetop = 1
                End Select

                If Map.MapEvents(id).WalkAnim = 1 Then anim = 0
                If Map.MapEvents(id).Moving = 0 Then anim = Map.MapEvents(id).GraphicX

                width = CharacterGfxInfo(Map.MapEvents(id).GraphicNum).Width / 4
                height = CharacterGfxInfo(Map.MapEvents(id).GraphicNum).Height / 4

                sRect = New Rectangle((anim) * (CharacterGfxInfo(Map.MapEvents(id).GraphicNum).Width / 4), spritetop * (CharacterGfxInfo(Map.MapEvents(id).GraphicNum).Height / 4), (CharacterGfxInfo(Map.MapEvents(id).GraphicNum).Width / 4), (CharacterGfxInfo(Map.MapEvents(id).GraphicNum).Height / 4))
                ' Calcular o X
                x = Map.MapEvents(id).X * PicX + Map.MapEvents(id).XOffset - ((CharacterGfxInfo(Map.MapEvents(id).GraphicNum).Width / 4 - 32) / 2)

                ' Altura do jogador é mairo que 32..?
                If (CharacterGfxInfo(Map.MapEvents(id).GraphicNum).Height * 4) > 32 Then
                    ' Criar um offset de 32 pixel para sprites maiores
                    y = Map.MapEvents(id).Y * PicY + Map.MapEvents(id).YOffset - ((CharacterGfxInfo(Map.MapEvents(id).GraphicNum).Height / 4) - 32)
                Else
                    ' Continuar normalmente
                    y = Map.MapEvents(id).Y * PicY + Map.MapEvents(id).YOffset
                End If
                ' renderizar sprite
                DrawCharacter(Map.MapEvents(id).GraphicNum, x, y, sRect)

                If Map.MapEvents(id).Questnum > 0 Then
                    If CanStartQuest(Map.MapEvents(id).Questnum) Then
                        If Player(Myindex).PlayerQuest(Map.MapEvents(id).Questnum).Status = QuestStatusType.NotStarted Then
                            DrawEmotes(x, y, 5)
                        End If
                    ElseIf Player(Myindex).PlayerQuest(Map.MapEvents(id).Questnum).Status = QuestStatusType.Started Then
                        DrawEmotes(x, y, 9)
                    End If
                End If
            Case 2
                If Map.MapEvents(id).GraphicNum < 1 OrElse Map.MapEvents(id).GraphicNum > NumTileSets Then Exit Sub
                If Map.MapEvents(id).GraphicY2 > 0 OrElse Map.MapEvents(id).GraphicX2 > 0 Then
                    With sRect
                        .X = Map.MapEvents(id).GraphicX * 32
                        .Y = Map.MapEvents(id).GraphicY * 32
                        .Width = Map.MapEvents(id).GraphicX2 * 32
                        .Height = Map.MapEvents(id).GraphicY2 * 32
                    End With
                Else
                    With sRect
                        .X = Map.MapEvents(id).GraphicY * 32
                        .Height = .Top + 32
                        .Y = Map.MapEvents(id).GraphicX * 32
                        .Width = .Left + 32
                    End With
                End If

                If TileSetTextureInfo(Map.MapEvents(id).GraphicNum).IsLoaded = False Then
                    LoadTexture(Map.MapEvents(id).GraphicNum, 1)
                End If
                ' vamos usar, então atualizar contador
                With TileSetTextureInfo(Map.MapEvents(id).GraphicNum)
                    .TextureTimer = GetTickCount() + 100000
                End With

                x = Map.MapEvents(id).X * 32
                y = Map.MapEvents(id).Y * 32
                x = x - ((sRect.Right - sRect.Left) / 2)
                y = y - (sRect.Bottom - sRect.Top) + 32

                If Map.MapEvents(id).GraphicY2 > 1 Then
                    RenderSprite(TileSetSprite(Map.MapEvents(id).GraphicNum), GameWindow, ConvertMapX(Map.MapEvents(id).X * PicX), ConvertMapY(Map.MapEvents(id).Y * PicY) - PicY, sRect.Left, sRect.Top, sRect.Width, sRect.Height)
                Else
                    RenderSprite(TileSetSprite(Map.MapEvents(id).GraphicNum), GameWindow, ConvertMapX(Map.MapEvents(id).X * PicX), ConvertMapY(Map.MapEvents(id).Y * PicY), sRect.Left, sRect.Top, sRect.Width, sRect.Height)
                End If

                If Map.MapEvents(id).Questnum > 0 Then
                    If CanStartQuest(Map.MapEvents(id).Questnum) Then
                        If Player(Myindex).PlayerQuest(Map.MapEvents(id).Questnum).Status = QuestStatusType.NotStarted Then
                            DrawEmotes(x, y, 5)
                        End If
                    ElseIf Player(Myindex).PlayerQuest(Map.MapEvents(id).Questnum).Status = QuestStatusType.Started Then
                        DrawEmotes(x, y, 9)
                    End If
                End If
        End Select

    End Sub

    Friend Sub DrawEventChat()
        Dim temptext As String, txtArray As New List(Of String)
        Dim tmpY As Integer = 0

        'primeiro renderixar painel
        RenderSprite(EventChatSprite, GameWindow, EventChatX, EventChatY, 0, 0, EventChatGfxInfo.Width, EventChatGfxInfo.Height)

        With FrmGame
            'rosto
            If EventChatFace > 0 AndAlso EventChatFace < NumFaces Then
                'renderizar rosto
                If FacesGfxInfo(EventChatFace).IsLoaded = False Then
                    LoadTexture(EventChatFace, 7)
                End If

                'vamos usar, atualizar contador
                With FacesGfxInfo(EventChatFace)
                    .TextureTimer = GetTickCount() + 100000
                End With
                RenderSprite(FacesSprite(EventChatFace), GameWindow, EventChatX + 12, EventChatY + 14, 0, 0, FacesGfxInfo(EventChatFace).Width, FacesGfxInfo(EventChatFace).Height)
                EventChatTextX = 113
            Else
                EventChatTextX = 14
            End If

            'EventPrompt
            txtArray = WordWrap(EventText, 45, WrapMode.Characters, WrapType.BreakWord)
            For i = 0 To txtArray.Count
                If i = txtArray.Count Then Exit For
                'desenhar texto
                DrawText(EventChatX + EventChatTextX, EventChatY + EventChatTextY + tmpY, Trim$(txtArray(i).Replace(vbCrLf, "")), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 13)
                tmpY = tmpY + 20
            Next

            If EventChatType = 1 Then

                If EventChoiceVisible(1) Then
                    'Resposta1
                    temptext = EventChoices(1)
                    DrawText(EventChatX + 10, EventChatY + 124, Trim(temptext), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 13)
                End If

                If EventChoiceVisible(2) Then
                    'Resposta2
                    temptext = EventChoices(2)
                    DrawText(EventChatX + 10, EventChatY + 146, Trim(temptext), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 13)
                End If

                If EventChoiceVisible(3) Then
                    'Resposta3
                    temptext = EventChoices(3)
                    DrawText(EventChatX + 226, EventChatY + 124, Trim(temptext), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 13)
                End If

                If EventChoiceVisible(4) Then
                    'Resposta4
                    temptext = EventChoices(4)
                    DrawText(EventChatX + 226, EventChatY + 146, Trim(temptext), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 13)
                End If
            Else
                temptext = Language.Events.OptContinue
                DrawText(EventChatX + 410, EventChatY + 156, Trim(temptext), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 13)
            End If

        End With

    End Sub

#End Region

#Region "Misc"

    Sub ProcessEventMovement(id As Integer)

        If id > Map.EventCount Then Exit Sub
        If id > Map.MapEvents.Length Then Exit Sub

        If Map.MapEvents(id).Moving = 1 Then
            Select Case Map.MapEvents(id).Dir
                Case DirectionType.Up
                    Map.MapEvents(id).YOffset = Map.MapEvents(id).YOffset - ((ElapsedTime / 1000) * (Map.MapEvents(id).MovementSpeed * SizeX))
                    If Map.MapEvents(id).YOffset < 0 Then Map.MapEvents(id).YOffset = 0
                Case DirectionType.Down
                    Map.MapEvents(id).YOffset = Map.MapEvents(id).YOffset + ((ElapsedTime / 1000) * (Map.MapEvents(id).MovementSpeed * SizeX))
                    If Map.MapEvents(id).YOffset > 0 Then Map.MapEvents(id).YOffset = 0
                Case DirectionType.Left
                    Map.MapEvents(id).XOffset = Map.MapEvents(id).XOffset - ((ElapsedTime / 1000) * (Map.MapEvents(id).MovementSpeed * SizeX))
                    If Map.MapEvents(id).XOffset < 0 Then Map.MapEvents(id).XOffset = 0
                Case DirectionType.Right
                    Map.MapEvents(id).XOffset = Map.MapEvents(id).XOffset + ((ElapsedTime / 1000) * (Map.MapEvents(id).MovementSpeed * SizeX))
                    If Map.MapEvents(id).XOffset > 0 Then Map.MapEvents(id).XOffset = 0
            End Select
            ' Ver se terminou de andar para a próxima tile
            If Map.MapEvents(id).Moving > 0 Then
                If Map.MapEvents(id).Dir = DirectionType.Right OrElse Map.MapEvents(id).Dir = DirectionType.Down Then
                    If (Map.MapEvents(id).XOffset >= 0) AndAlso (Map.MapEvents(id).YOffset >= 0) Then
                        Map.MapEvents(id).Moving = 0
                        If Map.MapEvents(id).Steps = 1 Then
                            Map.MapEvents(id).Steps = 3
                        Else
                            Map.MapEvents(id).Steps = 1
                        End If
                    End If
                Else
                    If (Map.MapEvents(id).XOffset <= 0) AndAlso (Map.MapEvents(id).YOffset <= 0) Then
                        Map.MapEvents(id).Moving = 0
                        If Map.MapEvents(id).Steps = 1 Then
                            Map.MapEvents(id).Steps = 3
                        Else
                            Map.MapEvents(id).Steps = 1
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Friend Function GetColorString(color As Integer)

        Select Case color
            Case 0
                GetColorString = "Preto"
            Case 1
                GetColorString = "Azul"
            Case 2
                GetColorString = "Verde"
            Case 3
                GetColorString = "Ciano"
            Case 4
                GetColorString = "Vermelho"
            Case 5
                GetColorString = "Magenta"
            Case 6
                GetColorString = "Marrom"
            Case 7
                GetColorString = "Cinza"
            Case 8
                GetColorString = "Cinza Escuro"
            Case 9
                GetColorString = "Azul Claro"
            Case 10
                GetColorString = "Verde Claro"
            Case 11
                GetColorString = "Ciano Claro"
            Case 12
                GetColorString = "Vermelho Claro"
            Case 13
                GetColorString = "Rosa"
            Case 14
                GetColorString = "Amarelo"
            Case 15
                GetColorString = "Branco"
            Case Else
                GetColorString = "Preto"
        End Select

    End Function

    Sub ClearEventChat()
        Dim i As Integer

        If AnotherChat = 1 Then
            For i = 1 To 4
                EventChoiceVisible(i) = False
            Next
            EventText = ""
            EventChatType = 1
            EventChatTimer = GetTickCount() + 100
        ElseIf AnotherChat = 2 Then
            For i = 1 To 4
                EventChoiceVisible(i) = False
            Next
            EventText = ""
            EventChatType = 1
            EventChatTimer = GetTickCount() + 100
        Else
            EventChat = False
        End If
        PnlEventChatVisible = False
    End Sub

    Friend Sub ResetEventdata()
        For i = 0 To Map.EventCount
            ReDim Map.MapEvents(Map.EventCount)
            Map.CurrentEvents = 0
            With Map.MapEvents(i)
                .Name = ""
                .Dir = 0
                .ShowDir = 0
                .GraphicNum = 0
                .GraphicType = 0
                .GraphicX = 0
                .GraphicX2 = 0
                .GraphicY = 0
                .GraphicY2 = 0
                .MovementSpeed = 0
                .Moving = 0
                .X = 0
                .Y = 0
                .XOffset = 0
                .YOffset = 0
                .Position = 0
                .Visible = 0
                .WalkAnim = 0
                .DirFix = 0
                .WalkThrough = 0
                .ShowName = 0
                .Questnum = 0
            End With
        Next
    End Sub

#End Region

End Module