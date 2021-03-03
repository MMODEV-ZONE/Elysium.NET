Imports System.Drawing
Imports ASFW

Module C_Animations

#Region "Globals"

    Friend AnimationIndex As Byte
    Friend AnimInstance(Byte.MaxValue) As AnimInstanceStruct

#End Region

#Region "DataBase"

    Sub ClearAnimation(index As Integer)
        Animation(index) = Nothing
        Animation(index) = New AnimationStruct
        For x = 0 To 1
            ReDim Animation(index).Sprite(x)
        Next
        For x = 0 To 1
            ReDim Animation(index).Frames(x)
        Next
        For x = 0 To 1
            ReDim Animation(index).LoopCount(x)
        Next
        For x = 0 To 1
            ReDim Animation(index).LoopTime(x)
        Next
        Animation(index).Name = ""
    End Sub

    Sub ClearAnimations()
        Dim i As Integer

        ReDim Animation(MAX_ANIMATIONS)

        For i = 1 To MAX_ANIMATIONS
            ClearAnimation(i)
        Next

    End Sub

    Sub ClearAnimInstances()
        Dim i As Integer

        ReDim AnimInstance(MAX_ANIMATIONS)

        For i = 0 To MAX_ANIMATIONS
            For x = 0 To 1
                ReDim AnimInstance(i).Timer(x)
            Next
            For x = 0 To 1
                ReDim AnimInstance(i).Used(x)
            Next
            For x = 0 To 1
                ReDim AnimInstance(i).LoopIndex(x)
            Next
            For x = 0 To 1
                ReDim AnimInstance(i).FrameIndex(x)
            Next

            ClearAnimInstance(i)
        Next
    End Sub

    Sub ClearAnimInstance(index As Integer)
        AnimInstance(index).Animation = 0
        AnimInstance(index).X = 0
        AnimInstance(index).Y = 0

        For i = 0 To UBound(AnimInstance(index).Used)
            AnimInstance(index).Used(i) = False
        Next
        For i = 0 To UBound(AnimInstance(index).Timer)
            AnimInstance(index).Timer(i) = False
        Next
        For i = 0 To UBound(AnimInstance(index).FrameIndex)
            AnimInstance(index).FrameIndex(i) = False
        Next

        AnimInstance(index).LockType = 0
        AnimInstance(index).lockindex = 0
    End Sub

#End Region

#Region "Incoming Traffic"

    Sub Packet_UpdateAnimation(ByRef data() As Byte)
        Dim n As Integer ', i As Integer
        Dim buffer As New ByteStream(data)

        n = buffer.ReadInt32
        Animation(n) = DeserializeData(buffer)

        buffer.Dispose()
    End Sub

    Sub Packet_Animation(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)

        AnimationIndex = AnimationIndex + 1
        If AnimationIndex >= Byte.MaxValue Then AnimationIndex = 1

        With AnimInstance(AnimationIndex)
            .Animation = buffer.ReadInt32
            .X = buffer.ReadInt32
            .Y = buffer.ReadInt32
            .LockType = buffer.ReadInt32
            .lockindex = buffer.ReadInt32
            .Used(0) = True
            .Used(1) = True
        End With

        Dim sound As String = Animation(AnimInstance(AnimationIndex).Animation).Sound
        If sound <> String.Empty Then PlaySound(sound)

        buffer.Dispose()
    End Sub

#End Region

#Region "Outgoing Traffic"

    Sub SendRequestAnimations()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CRequestAnimations)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

#End Region

#Region "Drawing"

    Friend Sub DrawAnimation(index As Integer, layer As Integer)

        Dim sprite As Integer
        Dim sRect As Rectangle
        Dim width As Integer, height As Integer
        Dim frameCount As Integer
        Dim x As Integer, y As Integer
        Dim lockindex As Integer

        If AnimInstance(index).Animation = 0 Then
            ClearAnimInstance(index)
            Exit Sub
        End If

        sprite = Animation(AnimInstance(index).Animation).Sprite(layer)

        If sprite < 1 OrElse sprite > NumAnimations Then Exit Sub

        If AnimationsGfxInfo(sprite).IsLoaded = False Then
            LoadTexture(sprite, 6)
        End If

        frameCount = Animation(AnimInstance(index).Animation).Frames(layer)

        If frameCount <= 0 Then Exit Sub

        ' Comprimento total dividido pelo numero de frames
        width = AnimationsGfxInfo(sprite).Width / frameCount
        height = AnimationsGfxInfo(sprite).Height

        sRect.Y = 0
        sRect.Height = height
        sRect.X = (AnimInstance(index).FrameIndex(layer) - 1) * width
        sRect.Width = width

        ' alterar x ou y se travado
        If AnimInstance(index).LockType > TargetType.None Then ' se <> nenhum
            ' é um jogador
            If AnimInstance(index).LockType = TargetType.Player Then
                ' fazer quick save no índice
                lockindex = AnimInstance(index).lockindex
                ' ver se está no jogo
                If IsPlaying(lockindex) Then
                    ' ver se está no mesmo mapa
                    If GetPlayerMap(lockindex) = GetPlayerMap(Myindex) Then
                        ' está no mapa e jogando, setar x e y
                        x = (GetPlayerX(lockindex) * PicX) + 16 - (width / 2) + Player(lockindex).XOffset
                        y = (GetPlayerY(lockindex) * PicY) + 16 - (height / 2) + Player(lockindex).YOffset
                    End If
                End If
            ElseIf AnimInstance(index).LockType = TargetType.Npc Then
                ' fazer quick save no índice
                lockindex = AnimInstance(index).lockindex
                ' ver se NPC existe
                If MapNpc(lockindex).Num > 0 Then
                    ' ver se está vivo
                    If MapNpc(lockindex).Vital(VitalType.HP) > 0 Then
                        ' existe e está vivo, setar x & y
                        x = (MapNpc(lockindex).X * PicX) + 16 - (width / 2) + MapNpc(lockindex).XOffset
                        y = (MapNpc(lockindex).Y * PicY) + 16 - (height / 2) + MapNpc(lockindex).YOffset
                    Else
                        '  npc morto, matar a animação
                        ClearAnimInstance(index)
                        Exit Sub
                    End If
                Else
                    ' npc morto, matar a animação
                    ClearAnimInstance(index)
                    Exit Sub
                End If
            ElseIf AnimInstance(index).LockType = TargetType.Pet Then
                ' fazer quick save no índice
                lockindex = AnimInstance(index).lockindex
                ' ver se está no jogo
                If IsPlaying(lockindex) AndAlso PetAlive(lockindex) = True Then
                    ' ver se está no mesmo mapa
                    If GetPlayerMap(lockindex) = GetPlayerMap(Myindex) Then
                        ' está no mapa, está jogando, setar x e y
                        x = (Player(lockindex).Pet.X * PicX) + 16 - (width / 2) + Player(lockindex).Pet.XOffset
                        y = (Player(lockindex).Pet.Y * PicY) + 16 - (height / 2) + Player(lockindex).Pet.YOffset
                    End If
                End If
            End If
        Else
            ' sem trava, padrão é x + y
            x = (AnimInstance(index).X * 32) + 16 - (width / 2)
            y = (AnimInstance(index).Y * 32) + 16 - (height / 2)
        End If

        x = ConvertMapX(x)
        y = ConvertMapY(y)

        ' Clipar para tela
        If y < 0 Then

            With sRect
                .Y = .Y - y
                .Height = .Height - (y * (-1))
            End With

            y = 0
        End If

        If x < 0 Then

            With sRect
                .X = .X - x
                .Width = .Width - (y * (-1))
            End With

            x = 0
        End If

        If sRect.Width < 0 OrElse sRect.Height < 0 Then Exit Sub

        RenderSprite(AnimationsSprite(sprite), GameWindow, x, y, sRect.X, sRect.Y, sRect.Width, sRect.Height)

    End Sub

    Friend Sub CheckAnimInstance(index As Integer)
        Dim looptime As Integer
        Dim layer As Integer
        Dim frameCount As Integer

        ' Se não existir, sair da função
        If AnimInstance(index).Animation <= 0 Then Exit Sub
        If AnimInstance(index).Animation >= MAX_ANIMATIONS Then Exit Sub

        For layer = 0 To 1
            If AnimInstance(index).Used(layer) Then
                looptime = Animation(AnimInstance(index).Animation).LoopTime(layer)
                frameCount = Animation(AnimInstance(index).Animation).Frames(layer)

                ' Se zerada, então setamos para que não tenhamos outro loop ou frame
                If AnimInstance(index).FrameIndex(layer) = 0 Then AnimInstance(index).FrameIndex(layer) = 1
                If AnimInstance(index).LoopIndex(layer) = 0 Then AnimInstance(index).LoopIndex(layer) = 1

                ' Ver se o temporizador de frame está ajustado e se precisa de mudanças de frame
                If AnimInstance(index).Timer(layer) + looptime <= GetTickCount() Then
                    ' Ver se está fora de alcance
                    If AnimInstance(index).FrameIndex(layer) >= frameCount Then
                        AnimInstance(index).LoopIndex(layer) = AnimInstance(index).LoopIndex(layer) + 1
                        If AnimInstance(index).LoopIndex(layer) > Animation(AnimInstance(index).Animation).LoopCount(layer) Then
                            AnimInstance(index).Used(layer) = False
                        Else
                            AnimInstance(index).FrameIndex(layer) = 1
                        End If
                    Else
                        AnimInstance(index).FrameIndex(layer) = AnimInstance(index).FrameIndex(layer) + 1
                    End If
                    AnimInstance(index).Timer(layer) = GetTickCount()
                End If
            End If
        Next

        ' Se nenhuma camada for usada, limpar
        If AnimInstance(index).Used(0) = False AndAlso AnimInstance(index).Used(1) = False Then
            ClearAnimInstance(index)
        End If
    End Sub

#End Region

End Module