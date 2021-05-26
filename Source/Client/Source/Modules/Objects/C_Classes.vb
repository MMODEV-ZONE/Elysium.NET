Imports ASFW

Module C_Classes

#Region "Incoming Traffic"

    Sub Packet_NewCharClasses(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)

        SelectedChar = 1

        LoadClassesData(buffer)

        buffer.Dispose()

        ' Usado para caso o jogador esteja criando um novo personagem 
        Frmmenuvisible = True
        Pnlloadvisible = False
        PnlCreditsVisible = False
        PnlRegisterVisible = False
        PnlCharCreateVisible = True
        PnlLoginVisible = False

        ReDim Cmbclass(MAX_CLASSES)

        For i = 1 To MAX_CLASSES
            Cmbclass(i) = Classes(i).Name
        Next

        FrmMenu.DrawCharacter()

        NewCharSprite = 1
    End Sub

    Sub Packet_ClassesData(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)

        SelectedChar = 1

        LoadClassesData(buffer)

        ReDim Cmbclass(MAX_CLASSES)
        For i = 1 To MAX_CLASSES
            Cmbclass(i) = Classes(i).Name
        Next
        FrmMenu.DrawCharacter()
        NewCharSprite = 1

        buffer.Dispose()
    End Sub

    Sub LoadClassesData(buffer As ByteStream)
        Classes = DeserializeData(buffer)
    End Sub

#End Region

#Region "Outgoing Traffic"

    Friend Sub SendRequestClasses()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CRequestClasses)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

#End Region

End Module