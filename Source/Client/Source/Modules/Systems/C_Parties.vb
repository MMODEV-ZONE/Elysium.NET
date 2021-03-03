Imports System.Drawing
Imports ASFW
Imports SFML.Graphics
Imports SFML.Window

Module C_Parties

#Region "Types and Globals"

    Friend Party As PartyRec

    Friend Structure PartyRec
        Dim Leader As Integer
        Dim Member() As Integer
        Dim MemberCount As Integer
    End Structure

#End Region

#Region "Database"

    Sub ClearParty()
        Party = New PartyRec With {
            .Leader = 0,
            .MemberCount = 0
        }
        ReDim Party.Member(MAX_PARTY_MEMBERS)
    End Sub

#End Region

#Region "Incoming Packets"

    Sub Packet_PartyInvite(ByRef data() As Byte)
        Dim name As String
        Dim buffer As New ByteStream(data)
        name = buffer.ReadString

        DialogType = DialogueTypeParty

        DialogMsg1 = "Convite para Equipe"
        DialogMsg2 = Trim$(name) & " te convidou para uma equipe. Quer entrar?"

        UpdateDialog = True

        buffer.Dispose()
    End Sub

    Sub Packet_PartyUpdate(ByRef data() As Byte)
        Dim I As Integer, inParty As Integer
        Dim buffer As New ByteStream(data)
        inParty = buffer.ReadInt32

        ' sair se não estamos em uma equipe
        If inParty = 0 Then
            ClearParty()
            ' sair mais cedo
            buffer.Dispose()
            Exit Sub
        End If

        ' continuar caso contrario
        Party.Leader = buffer.ReadInt32
        For I = 1 To MAX_PARTY_MEMBERS
            Party.Member(I) = buffer.ReadInt32
        Next
        Party.MemberCount = buffer.ReadInt32

        buffer.Dispose()
    End Sub

    Sub Packet_PartyVitals(ByRef data() As Byte)
        Dim playerNum As Integer, partyindex As Integer
        Dim buffer As New ByteStream(data)
        ' que jogador?
        playerNum = buffer.ReadInt32

        ' encontrar o numero da equipe
        For I = 1 To MAX_PARTY_MEMBERS
            If Party.Member(I) = playerNum Then
                partyindex = I
            End If
        Next

        ' sair se info errada
        If partyindex <= 0 OrElse partyindex > MAX_PARTY_MEMBERS Then Exit Sub

        ' setar vitais
        Player(playerNum).MaxHp = buffer.ReadInt32
        Player(playerNum).Vital(VitalType.HP) = buffer.ReadInt32

        Player(playerNum).MaxMp = buffer.ReadInt32
        Player(playerNum).Vital(VitalType.MP) = buffer.ReadInt32

        Player(playerNum).MaxSp = buffer.ReadInt32
        Player(playerNum).Vital(VitalType.SP) = buffer.ReadInt32

        buffer.Dispose()
    End Sub

#End Region

#Region "Outgoing Packets"

    Friend Sub SendPartyRequest(name As String)
        Dim buffer As New ByteStream(4)
        buffer.WriteInt32(ClientPackets.CRequestParty)
        buffer.WriteString((name))

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub SendAcceptParty()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CAcceptParty)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub SendDeclineParty()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CDeclineParty)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub SendLeaveParty()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CLeaveParty)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub SendPartyChatMsg(text As String)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CPartyChatMsg)
        buffer.WriteString((text))

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

#End Region

#Region "Drawing"

    Friend Sub DrawParty()
        Dim I As Integer, x As Integer, y As Integer, barwidth As Integer, playerNum As Integer, theName As String
        Dim rec(1) As Rectangle

        ' renderizar a janela

        ' desenhar barras
        If Party.Leader > 0 Then ' ter certeza que estamos na equipe
            ' desenhar lider
            playerNum = Party.Leader
            ' nome
            theName = Trim$(GetPlayerName(playerNum))
            ' desenhar nome
            y = 100
            x = 10
            DrawText(x, y, theName, SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)

            ' desenhar hp
            If Player(playerNum).Vital(VitalType.HP) > 0 Then
                ' calcular o comprimnto para preencher
                barwidth = ((Player(playerNum).Vital(VitalType.HP) / (GetPlayerMaxVital(playerNum, VitalType.HP)) * 64))
                ' desenhar barras
                rec(1) = New Rectangle(x, y, barwidth, 6)
                Dim rectShape As New RectangleShape(New Vector2f(barwidth, 6)) With {
                    .Position = New Vector2f(x, y + 15),
                    .FillColor = SFML.Graphics.Color.Red
                }
                GameWindow.Draw(rectShape)
            End If
            ' desenhar mp
            If Player(playerNum).Vital(VitalType.MP) > 0 Then
                ' calcular comprimento para preencher
                barwidth = ((Player(playerNum).Vital(VitalType.MP) / (GetPlayerMaxVital(playerNum, VitalType.MP)) * 64))
                ' desenhar barras
                rec(1) = New Rectangle(x, y, barwidth, 6)
                Dim rectShape2 As New RectangleShape(New Vector2f(barwidth, 6)) With {
                    .Position = New Vector2f(x, y + 24),
                    .FillColor = SFML.Graphics.Color.Blue
                }
                GameWindow.Draw(rectShape2)
            End If

            ' desenhar membros
            For I = 1 To MAX_PARTY_MEMBERS
                If Party.Member(I) > 0 Then
                    If Party.Member(I) <> Party.Leader Then
                        ' fazer cache do index
                        playerNum = Party.Member(I)
                        ' nome
                        theName = Trim$(GetPlayerName(playerNum))
                        ' desenhar nome
                        y = 100 + ((I - 1) * 30)

                        DrawText(x, y, theName, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
                        ' desenhar hp
                        y = 115 + ((I - 1) * 30)

                        ' ter certeza que temos os dados antes de renderizar
                        If GetPlayerVital(playerNum, VitalType.HP) > 0 AndAlso GetPlayerMaxVital(playerNum, VitalType.HP) > 0 Then
                            barwidth = ((Player(playerNum).Vital(VitalType.HP) / (GetPlayerMaxVital(playerNum, VitalType.HP)) * 64))
                        End If
                        rec(1) = New Rectangle(x, y, barwidth, 6)
                        Dim rectShape As New RectangleShape(New Vector2f(barwidth, 6)) With {
                            .Position = New Vector2f(x, y),
                            .FillColor = SFML.Graphics.Color.Red
                        }
                        GameWindow.Draw(rectShape)
                        ' desenhar mp
                        y = 115 + ((I - 1) * 30)
                        ' ter certeza que temos os dados antes de renderizar
                        If GetPlayerVital(playerNum, VitalType.MP) > 0 AndAlso GetPlayerMaxVital(playerNum, VitalType.MP) > 0 Then
                            barwidth = ((Player(playerNum).Vital(VitalType.MP) / (GetPlayerMaxVital(playerNum, VitalType.MP)) * 64))
                        End If
                        rec(1) = New Rectangle(x, y, barwidth, 6)
                        Dim rectShape2 As New RectangleShape(New Vector2f(barwidth, 6)) With {
                            .Position = New Vector2f(x, y + 8),
                            .FillColor = SFML.Graphics.Color.Blue
                        }
                        GameWindow.Draw(rectShape2)
                    End If
                End If
            Next
        End If
    End Sub

#End Region

End Module