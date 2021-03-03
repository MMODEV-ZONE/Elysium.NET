Imports System.IO
Imports ASFW
Imports ASFW.IO.FileIO

Friend Module S_Animations

#Region "Database"

    Sub SaveAnimations()
        Dim i As Integer

        For i = 1 To MAX_ANIMATIONS
            SaveAnimation(i)
        Next

    End Sub

    Sub SaveAnimation(AnimationNum As Integer)
        Dim filename As String

        filename = Path.Animation(AnimationNum)

        SaveObject(Animation(AnimationNum), filename)
    End Sub

    Sub LoadAnimations()
        Dim i As Integer

        CheckAnimations()

        For i = 1 To MAX_ANIMATIONS
            LoadAnimation(i)
        Next

    End Sub

    Sub LoadAnimation(AnimationNum As Integer)
        Dim filename As String

        filename = Path.Animation(AnimationNum)
        LoadObject(Animation(AnimationNum), filename)

        If Animation(AnimationNum).Name Is Nothing Then Animation(AnimationNum).Name = ""
    End Sub

    Sub CheckAnimations()
        Dim i As Integer

        For i = 1 To MAX_ANIMATIONS

            If Not File.Exists(Path.Animation(i)) Then
                SaveAnimation(i)
                Application.DoEvents()
            End If

        Next
    End Sub

    Sub ClearAnimation(index As Integer)
        Animation(index) = Nothing
        Animation(index).Name = ""
        Animation(index).Sound = ""
        ReDim Animation(index).Sprite(1)
        ReDim Animation(index).Frames(1)
        ReDim Animation(index).LoopCount(1)
        ReDim Animation(index).LoopTime(1)
    End Sub

    Sub ClearAnimations()
        For i = 1 To MAX_ANIMATIONS
            ClearAnimation(i)
        Next
    End Sub

    Function AnimationsData() As Byte()
        Dim buffer As New ByteStream(4)

        For i = 1 To MAX_ANIMATIONS
            If Not Len(Trim$(Animation(i).Name)) > 0 Then Continue For
            buffer.WriteBlock(AnimationData(i))
        Next

        Return buffer.ToArray
    End Function

    Function AnimationData(AnimationNum As Integer) As Byte()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(AnimationNum)
        buffer.WriteBlock(SerializeData(Animation(AnimationNum)))

        Return buffer.ToArray
    End Function

#End Region

#Region "Incoming Packets"

    Sub Packet_EditAnimation(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recieved EMSG: RequestEditAnimation")
#End If

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub

        Dim Buffer = New ByteStream(4)
        Buffer.WriteInt32(ServerPackets.SAnimationEditor)
        Socket.SendDataTo(index, Buffer.Data, Buffer.Head)
        Buffer.Dispose()
    End Sub

    Sub Packet_SaveAnimation(index As Integer, ByRef data() As Byte)
        Dim AnimNum As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida EMSG: SaveAnimation")
#End If
        AnimNum = buffer.ReadInt32

        Animation(AnimNum) = DeserializeData(buffer)

        buffer.Dispose()

        ' Salvar
        SaveAnimation(AnimNum)
        SendUpdateAnimationToAll(AnimNum)
        Addlog(GetPlayerLogin(index) & " salvou Animação #" & AnimNum & ".", ADMIN_LOG)

    End Sub

    Sub Packet_RequestAnimations(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida CMSG: CRequestAnimations")
#End If
        SendAnimations(index)
    End Sub

#End Region

#Region "Outgoing Packets"

    Sub SendAnimation(mapNum As Integer, Anim As Integer, X As Integer, Y As Integer, Optional LockType As Byte = 0, Optional Lockindex As Integer = 0)
        Dim buffer As New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SAnimation)
        buffer.WriteInt32(Anim)
        buffer.WriteInt32(X)
        buffer.WriteInt32(Y)
        buffer.WriteInt32(LockType)
        buffer.WriteInt32(Lockindex)
#If DEBUG Then
        AddDebug("Enviada SMSG: SAnimation")
#End If
        SendDataToMap(mapNum, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendAnimations(index As Integer)
        Dim i As Integer

        For i = 1 To MAX_ANIMATIONS

            If Len(Trim$(Animation(i).Name)) > 0 Then
                SendUpdateAnimationTo(index, i)
            End If

        Next

    End Sub

    Sub SendUpdateAnimationTo(index As Integer, AnimationNum As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SUpdateAnimation)

        buffer.WriteBlock(AnimationData(AnimationNum))
#If DEBUG Then
        AddDebug("Enviada SMSG: SUpdateAnimation")
#End If
        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendUpdateAnimationToAll(AnimationNum As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SUpdateAnimation)

        buffer.WriteBlock(AnimationData(AnimationNum))
#If DEBUG Then
        AddDebug("Enviada SMSG: SUpdateAnimation To All")
#End If
        SendDataToAll(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

#End Region

End Module