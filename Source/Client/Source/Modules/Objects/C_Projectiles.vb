Imports System.IO
Imports System.Windows.Forms
Imports ASFW
Imports SFML.Graphics
Imports SFML.Window

Friend Module C_Projectiles

#Region "Defines"

    Friend Const MaxProjectiles As Integer = 255
    Friend Projectiles(MaxProjectiles) As ProjectileRec
    Friend MapProjectiles(MaxProjectiles) As MapProjectileRec
    Friend NumProjectiles As Integer
    Friend InitProjectileEditor As Boolean
    Friend Const EditorProjectile As Byte = 10
    Friend ProjectileChanged(MaxProjectiles) As Boolean

#End Region

#Region "Types"

    Friend Structure MapProjectileRec
        Dim ProjectileNum As Integer
        Dim Owner As Integer
        Dim OwnerType As Byte
        Dim X As Integer
        Dim Y As Integer
        Dim Dir As Byte
        Dim Range As Integer
        Dim TravelTime As Integer
        Dim Timer As Integer
    End Structure

#End Region

#Region "Sending"
    Sub SendRequestEditProjectiles()
        Dim buffer As ByteStream

        buffer = New ByteStream(4)
        buffer.WriteInt32(ClientPackets.CRequestEditProjectiles)
        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

    Sub SendSaveProjectile(ProjectileNum As Integer)
        Dim buffer As ByteStream

        buffer = New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CSaveProjectile)
        buffer.WriteInt32(ProjectileNum)
        buffer.WriteBlock(SerializeData(Projectiles(ProjectileNum)))

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub
    Sub SendRequestProjectiles()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CRequestProjectiles)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

    Sub SendClearProjectile(projectileNum As Integer, collisionindex As Integer, collisionType As Byte, collisionZone As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CClearProjectile)
        buffer.WriteInt32(projectileNum)
        buffer.WriteInt32(collisionindex)
        buffer.WriteInt32(collisionType)
        buffer.WriteInt32(collisionZone)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

#End Region

#Region "Recieving"

    Friend Sub HandleUpdateProjectile(ByRef data() As Byte)
        Dim projectileNum As Integer
        Dim buffer As New ByteStream(data)
        projectileNum = buffer.ReadInt32

        Projectiles(projectileNum) = DeserializeData(buffer)

        buffer.Dispose()

    End Sub

    Friend Sub HandleMapProjectile(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)
        i = buffer.ReadInt32

        With MapProjectiles(i)
            .ProjectileNum = buffer.ReadInt32
            .Owner = buffer.ReadInt32
            .OwnerType = buffer.ReadInt32
            .Dir = buffer.ReadInt32
            .X = buffer.ReadInt32
            .Y = buffer.ReadInt32
            .Range = 0
            .Timer = GetTickCount() + 60000
        End With

        buffer.Dispose()

    End Sub

#End Region

#Region "Database"

    Sub ClearProjectiles()
        Dim i As Integer

        For i = 1 To MaxProjectiles
            ClearProjectile(i)
        Next

    End Sub

    Sub ClearProjectile(index As Integer)

        Projectiles(index).Name = ""
        Projectiles(index).Sprite = 0
        Projectiles(index).Range = 0
        Projectiles(index).Speed = 0
        Projectiles(index).Damage = 0

    End Sub

    Sub ClearMapProjectile(projectileNum As Integer)

        MapProjectiles(projectileNum).ProjectileNum = 0
        MapProjectiles(projectileNum).Owner = 0
        MapProjectiles(projectileNum).OwnerType = 0
        MapProjectiles(projectileNum).X = 0
        MapProjectiles(projectileNum).Y = 0
        MapProjectiles(projectileNum).Dir = 0
        MapProjectiles(projectileNum).Timer = 0

    End Sub

#End Region

#Region "Drawing"

    Friend Sub CheckProjectiles()
        Dim i As Integer

        i = 1

        While File.Exists(Path.Graphics & "Projeteis\" & i & GfxExt)

            NumProjectiles = NumProjectiles + 1
            i = i + 1
        End While

        If NumProjectiles = 0 Then Exit Sub

    End Sub

    Friend Sub DrawProjectile(projectileNum As Integer)
        Dim rec As Rect
        Dim canClearProjectile As Boolean
        Dim collisionindex As Integer
        Dim collisionType As Byte
        Dim collisionZone As Integer
        Dim xOffset As Integer, yOffset As Integer
        Dim x As Integer, y As Integer
        Dim i As Integer
        Dim sprite As Integer

        ' Ver se é hora de mover o projétil
        If GetTickCount() > MapProjectiles(projectileNum).TravelTime Then
            Select Case MapProjectiles(projectileNum).Dir
                Case DirectionType.Up
                    MapProjectiles(projectileNum).Y = MapProjectiles(projectileNum).Y - 1
                Case DirectionType.Down
                    MapProjectiles(projectileNum).Y = MapProjectiles(projectileNum).Y + 1
                Case DirectionType.Left
                    MapProjectiles(projectileNum).X = MapProjectiles(projectileNum).X - 1
                Case DirectionType.Right
                    MapProjectiles(projectileNum).X = MapProjectiles(projectileNum).X + 1
            End Select
            MapProjectiles(projectileNum).TravelTime = GetTickCount() + Projectiles(MapProjectiles(projectileNum).ProjectileNum).Speed
            MapProjectiles(projectileNum).Range = MapProjectiles(projectileNum).Range + 1
        End If

        x = MapProjectiles(projectileNum).X
        y = MapProjectiles(projectileNum).Y

        'Ver se ele está indo há 1 minuto; se sim, limpar.
        If MapProjectiles(projectileNum).Timer < GetTickCount() Then canClearProjectile = True

        If x > Map.MaxX OrElse x < 0 Then canClearProjectile = True
        If y > Map.MaxY OrElse y < 0 Then canClearProjectile = True

        'Verificar se bateu em parede bloqueada
        If canClearProjectile = False Then 'Adicionar uma verificaçao para evitar crash
            If Map.Tile(x, y).Type = TileType.Blocked Then canClearProjectile = True
        End If

        'Verificar por colisÕes com NPCs
        For i = 1 To MAX_MAP_NPCS
            If MapNpc(i).X = x AndAlso MapNpc(i).Y = y Then
                canClearProjectile = True
                collisionindex = i
                collisionType = TargetType.Npc
                collisionZone = -1
                Exit For
            End If
        Next

        'Verificar por colisão com jogador
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) AndAlso GetPlayerMap(i) = GetPlayerMap(Myindex) Then
                If GetPlayerX(i) = x AndAlso GetPlayerY(i) = y Then
                    canClearProjectile = True
                    collisionindex = i
                    collisionType = TargetType.Player
                    collisionZone = -1
                    If MapProjectiles(projectileNum).OwnerType = TargetType.Player Then
                        If MapProjectiles(projectileNum).Owner = i Then canClearProjectile = False ' Resetar se for o dono do projetil
                    End If
                    Exit For
                End If

            End If
        Next

        'Ver se atingiu seu alcance maximo
        If MapProjectiles(projectileNum).Range >= Projectiles(MapProjectiles(projectileNum).ProjectileNum).Range + 1 Then canClearProjectile = True

        'Limpar o projetil se possível
        If canClearProjectile = True Then
            'Apenas enviar o CLEAR para o servidor se você for o usuário do projétil ou o atingido (apenas se o dono nao for um jogador)
            If (MapProjectiles(projectileNum).OwnerType = TargetType.Player AndAlso MapProjectiles(projectileNum).Owner = Myindex) Then
                SendClearProjectile(projectileNum, collisionindex, collisionType, collisionZone)
            End If

            ClearMapProjectile(projectileNum)
            Exit Sub
        End If

        sprite = Projectiles(MapProjectiles(projectileNum).ProjectileNum).Sprite
        If sprite < 1 OrElse sprite > NumProjectiles Then Exit Sub

        If ProjectileGfxInfo(sprite).IsLoaded = False Then
            LoadTexture(sprite, 11)
        End If

        'Vendo que ainda vmaos utilizar, atualizar temporizador
        With ProjectileGfxInfo(sprite)
            .TextureTimer = GetTickCount() + 100000
        End With

        ' src rect
        With rec
            .Top = 0
            .Bottom = ProjectileGfxInfo(sprite).Height
            .Left = MapProjectiles(projectileNum).Dir * PicX
            .Right = .Left + PicX
        End With

        'Encontrar o offset
        Select Case MapProjectiles(projectileNum).Dir
            Case DirectionType.Up
                yOffset = ((MapProjectiles(projectileNum).TravelTime - GetTickCount()) / Projectiles(MapProjectiles(projectileNum).ProjectileNum).Speed) * PicY
            Case DirectionType.Down
                yOffset = -((MapProjectiles(projectileNum).TravelTime - GetTickCount()) / Projectiles(MapProjectiles(projectileNum).ProjectileNum).Speed) * PicY
            Case DirectionType.Left
                xOffset = ((MapProjectiles(projectileNum).TravelTime - GetTickCount()) / Projectiles(MapProjectiles(projectileNum).ProjectileNum).Speed) * PicX
            Case DirectionType.Right
                xOffset = -((MapProjectiles(projectileNum).TravelTime - GetTickCount()) / Projectiles(MapProjectiles(projectileNum).ProjectileNum).Speed) * PicX
        End Select

        x = ConvertMapX(x * PicX)
        y = ConvertMapY(y * PicY)

        Dim tmpSprite As Sprite = New Sprite(ProjectileGfx(sprite)) With {
            .TextureRect = New IntRect(rec.Left, rec.Top, 32, 32),
            .Position = New Vector2f(x, y)
        }
        GameWindow.Draw(tmpSprite)

    End Sub

    Friend Sub EditorProjectile_DrawProjectile()
        Dim iconnum As Integer

        iconnum = frmEditor_Projectile.nudPic.Value

        If iconnum < 1 OrElse iconnum > NumProjectiles Then
            frmEditor_Projectile.picProjectile.BackgroundImage = Nothing
            Exit Sub
        End If

        If File.Exists(Path.Graphics & "Projeteis\" & iconnum & GfxExt) Then
            frmEditor_Projectile.picProjectile.BackgroundImage = Drawing.Image.FromFile(Path.Graphics & "Projeteis\" & iconnum & GfxExt)
        End If

    End Sub
#End Region

#Region "Projectile Editor"

    Friend Sub ProjectileEditorInit()

        If frmEditor_Projectile.Visible = False Then Exit Sub
        Editorindex = frmEditor_Projectile.lstIndex.SelectedIndex + 1

        With Projectiles(Editorindex)
            frmEditor_Projectile.txtName.Text = Trim$(.Name)
            frmEditor_Projectile.nudPic.Value = .Sprite
            frmEditor_Projectile.nudRange.Value = .Range
            frmEditor_Projectile.nudSpeed.Value = .Speed
            frmEditor_Projectile.nudDamage.Value = .Damage
        End With

        ProjectileChanged(Editorindex) = True

    End Sub

    Friend Sub ProjectileEditorOk()
        Dim i As Integer

        For i = 1 To MaxProjectiles
            If ProjectileChanged(i) Then
                Call SendSaveProjectile(i)
            End If
        Next

        frmEditor_Projectile.Dispose()
        Editor = 0
        ClearChanged_Projectile()

    End Sub

    Friend Sub ProjectileEditorCancel()

        Editor = 0
        frmEditor_Projectile.Dispose()
        ClearChanged_Projectile()
        ClearProjectiles()
        SendRequestProjectiles()

    End Sub

    Friend Sub ClearChanged_Projectile()
        Dim i As Integer

        For i = 0 To MaxProjectiles
            ProjectileChanged(i) = False
        Next

    End Sub

#End Region

End Module