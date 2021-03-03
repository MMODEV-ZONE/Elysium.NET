Imports ASFW

Friend Module C_Time

    Sub Packet_Clock(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        Time.Instance.GameSpeed = buffer.ReadInt32()
        Time.Instance.Time = New Date(BitConverter.ToInt64(buffer.ReadBytes(), 0))

        buffer.Dispose()
    End Sub

    Sub Packet_Time(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)

        Time.Instance.TimeOfDay = buffer.ReadByte

        Select Case Time.Instance.TimeOfDay
            Case TimeOfDay.Dawn
                AddText("Uma brisa fria e refrescante veio com a manhã.", ColorType.BrightBlue)
                Exit Select

            Case TimeOfDay.Day
                AddText("O dia amanheceu nesta região.", ColorType.Yellow)
                Exit Select

            Case TimeOfDay.Dusk
                AddText("Os céus começaram a alvorecer...", ColorType.BrightRed)
                Exit Select

            Case Else
                AddText("A noite caiu em cima dos cansados aventureiros.", ColorType.DarkGray)
                Exit Select
        End Select

        buffer.Dispose()
    End Sub

End Module