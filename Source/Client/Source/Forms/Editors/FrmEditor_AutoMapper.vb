Imports SFML.Graphics
Imports SFML.Window
Imports Ini = ASFW.IO.FileIO.TextFile

Friend Class frmEditor_AutoMapper

#Region "Frm Code"
    Private Prefab As Integer
    Private Layer As Integer
    Dim picBackTop As Integer, picBackLeft As Integer

    Private Sub FrmAutoMapper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlResources.Top = 32
        pnlResources.Left = 12
        pnlTileConfig.Top = 0
        pnlTileConfig.Left = 12

        Width = 540
        Height = 440

        Dim cf = Path.Contents & "\AutoMapper.ini"

        If Not String.IsNullOrEmpty(Ini.Read(cf, "GERAL", "MapStart")) Then
            txtMapStart.Text = Ini.Read(cf, "GERAL", "MapStart")
        End If

        If Not String.IsNullOrEmpty(Ini.Read(cf, "GERAL", "MapSize")) Then
            txtMapSize.Text = Ini.Read(cf, "GERAL", "MapSize")
        End If

        If Not String.IsNullOrEmpty(Ini.Read(cf, "GERAL", "MapX")) Then
            txtMapX.Text = Ini.Read(cf, "GERAL", "MapX")
        End If

        If Not String.IsNullOrEmpty(Ini.Read(cf, "GERAL", "MapY")) Then
            txtMapY.Text = Ini.Read(cf, "GERAL", "MapY")
        End If

        If Not String.IsNullOrEmpty(Ini.Read(cf, "GERAL", "SandBorder")) Then
            txtSandBorder.Text = Ini.Read(cf, "GERAL", "SandBorder")
        End If

        If Not String.IsNullOrEmpty(Ini.Read(cf, "GERAL", "Detail")) Then
            txtDetail.Text = Ini.Read(cf, "GERAL", "Detail")
        End If

        If Not String.IsNullOrEmpty(Ini.Read(cf, "GERAL", "ResourceFreq")) Then
            txtResourceFreq.Text = Ini.Read(cf, "GERAL", "ResourceFreq")
        End If

        cmbTileset.Items.Clear()
        For i = 1 To NumTileSets
            cmbTileset.Items.Add("Tileset " & i)
        Next
    End Sub

    Private Sub TilesetsToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles TilesetsToolStripMenuItem.Click
        pnlTileConfig.Visible = True
        pnlTileConfig.BringToFront()
        Me.Height = 780

        UpdateTileset(1)
    End Sub

    Private Sub ResourcesToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ResourcesToolStripMenuItem.Click
        Dim Resources() As String
        Dim i As Integer

        pnlResources.Visible = True
        pnlResources.BringToFront()

        Resources = Split(ResourcesNum, ";")

        lstResources.Items.Clear()

        For i = 0 To UBound(Resources)
            lstResources.Items.Add(Resources(i) & ": " & Trim(Resource(Resources(i)).Name))
        Next

        cmbResources.Items.Clear()

        For i = 1 To MAX_RESOURCES
            If String.IsNullOrEmpty(Resource(i).Name) Then
                cmbResources.Items.Add(i & ": Nenhum")
            Else
                cmbResources.Items.Add(i & ": " & Trim(Resource(i).Name))
            End If
        Next
    End Sub

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        MapStart = Val(txtMapStart.Text)
        MapSize = Val(txtMapSize.Text)
        MapX = Val(txtMapX.Text)
        MapY = Val(txtMapY.Text)
        SandBorder = Val(txtSandBorder.Text)
        DetailFreq = Val(txtDetail.Text)
        ResourceFreq = Val(txtResourceFreq.Text)

        Dim cf = Path.Contents & "\AutoMapper.ini"
        Ini.WriteOrCreate(cf, "GERAL", "MapStart", txtMapStart.Text)
        Ini.WriteOrCreate(cf, "GERAL", "MapSize", txtMapSize.Text)
        Ini.WriteOrCreate(cf, "GERAL", "MapX", txtMapX.Text)
        Ini.WriteOrCreate(cf, "GERAL", "MapY", txtMapY.Text)
        Ini.WriteOrCreate(cf, "GERAL", "SandBorder", txtSandBorder.Text)
        Ini.WriteOrCreate(cf, "GERAL", "Detail", txtDetail.Text)
        Ini.WriteOrCreate(cf, "GERAL", "ResourceFreq", txtResourceFreq.Text)

        SendSaveAutoMapper(True)

        Visible = False
    End Sub

#End Region

#Region "Resources"

    Private Sub LstResources_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstResources.SelectedIndexChanged
        If lstResources.SelectedIndex < 0 Then Exit Sub
        Dim itemStr As String = lstResources.Items(lstResources.SelectedIndex).ToString()
        cmbResources.SelectedIndex = itemStr.Substring(0, itemStr.IndexOf(":")) - 1
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAddResource.Click
        If cmbResources.SelectedIndex >= 0 Then
            Dim Index As Integer = Val(cmbResources.SelectedIndex + 1)
            Dim Name As String = Resource(Index).Name
            lstResources.Items.Add(Index & ": " & Trim(Name))
        End If
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles btnRemoveResource.Click
        If lstResources.SelectedIndex < 0 Then Exit Sub
        lstResources.Items.RemoveAt(lstResources.SelectedIndex)
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdateResource.Click
        If lstResources.SelectedIndex < 0 Or cmbResources.SelectedIndex < 0 Then Exit Sub
        Dim Index As Integer = Val(cmbResources.SelectedIndex + 1)
        Dim Name As String = Resource(Index).Name
        lstResources.Items.Item(lstResources.SelectedIndex) = Index & ": " & Name
    End Sub

    Private Sub BtnCloseResource_Click(sender As Object, e As EventArgs) Handles btnCloseResource.Click
        pnlResources.Visible = False
    End Sub

    Private Sub BtnSaveResource_Click(sender As Object, e As EventArgs) Handles btnSaveResource.Click
        Dim i As Integer
        Dim ResourceStr As String = ""
        Dim cf = Path.Contents & "AutoMapper.ini"

        For i = 0 To lstResources.Items.Count - 1
            Dim itemStr As String = lstResources.Items(i).ToString()
            ResourceStr = CStr(ResourceStr & itemStr.Substring(0, itemStr.IndexOf(":")))
            If i < lstResources.Items.Count - 1 Then ResourceStr = ResourceStr & ";"
        Next

        Ini.Write(cf, "Resources", "ResourcesNum", ResourceStr)

        SendSaveAutoMapper(False)

        pnlResources.Visible = False
    End Sub

#End Region

#Region "TileSet"

    Private Sub CmbPrefab_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPrefab.SelectedIndexChanged
        Dim Layer As Integer

        For Layer = 1 To LayerType.Count - 1
            If Tile(cmbPrefab.SelectedIndex + 1).Layer(Layer).Tileset > 0 Then
                Exit For
            End If
        Next

        tbControl.Enabled = (cmbPrefab.SelectedIndex >= 0)
        frmTileset.Enabled = (cmbPrefab.SelectedIndex >= 0)

        cmbLayer.SelectedIndex = Layer - 1
        cmbLayer_SelectedIndexChanged(sender, e)

        UpdateDetailList()
    End Sub


    Private Sub BtnTileSetClose_Click(sender As Object, e As EventArgs) Handles btnTileSetClose.Click
        pnlTileConfig.Visible = False
        Me.Height = 440
    End Sub

    Private Sub BtnTileSetSave_Click(sender As Object, e As EventArgs) Handles btnTileSetSave.Click
        Dim Prefab As Integer, Layer As Integer
        Dim cf = Path.Contents & "\AutoMapper.ini"

        For Prefab = 1 To TilePrefab.Count - 1
            For Layer = 1 To 5
                If Tile(Prefab).Layer(Layer).Tileset > 0 Then
                    Ini.Write(cf, "Prefab" & Prefab, "Layer" & Layer & "Tileset", Val(Tile(Prefab).Layer(Layer).Tileset))
                    Ini.Write(cf, "Prefab" & Prefab, "Layer" & Layer & "X", Val(Tile(Prefab).Layer(Layer).X))
                    Ini.Write(cf, "Prefab" & Prefab, "Layer" & Layer & "Y", Val(Tile(Prefab).Layer(Layer).Y))
                    Ini.Write(cf, "Prefab" & Prefab, "Layer" & Layer & "Autotile", Val(Tile(Prefab).Layer(Layer).AutoTile))
                End If
            Next Layer

            Ini.Write(cf, "Prefab" & Prefab, "Type", Val(Tile(Prefab).Type))
        Next Prefab

        For TileDetail = 0 To UBound(Detail) - 1
            Ini.WriteOrCreate(cf, "Detail" & TileDetail, "Prefab", Val(Detail(TileDetail).DetailBase))
            Ini.WriteOrCreate(cf, "Detail" & TileDetail, "Tileset", Val(Detail(TileDetail).Tileset))
            Ini.WriteOrCreate(cf, "Detail" & TileDetail, "StartX", Val(Detail(TileDetail).StartX))
            Ini.WriteOrCreate(cf, "Detail" & TileDetail, "StartY", Val(Detail(TileDetail).StartY))
            Ini.WriteOrCreate(cf, "Detail" & TileDetail, "EndX", Val(Detail(TileDetail).EndX))
            Ini.WriteOrCreate(cf, "Detail" & TileDetail, "EndY", Val(Detail(TileDetail).EndY))
        Next TileDetail

        Ini.WriteOrCreate(cf, "Details", "DetailCount", Val(UBound(Detail)))

        pnlTileConfig.Visible = False
        Me.Height = 440

        LoadTilePrefab()
        LoadDetails()
        SendSaveAutoMapper(False)
    End Sub

    Private Sub ResourcesToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ResourcesToolStripMenuItem3.Click

    End Sub

    Private Sub UpdateDetailList()
        Dim i As Long
        lstDetails.Items.Clear()

        If cmbPrefab.SelectedIndex >= 0 Then
            For i = 0 To UBound(Detail) - 1
                If Detail(i).DetailBase = cmbPrefab.SelectedIndex Then
                    lstDetails.Items.Add(String.Format("Detalhe (Tileset={0} | Loc={1},{2} | Area={3},{4})", Detail(i).Tileset + 1, Detail(i).StartX, Detail(i).StartY, Detail(i).EndX, Detail(i).EndY))
                End If
            Next
        End If
    End Sub

    Private Sub lstDetails_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDetails.SelectedIndexChanged
        If lstDetails.SelectedIndex >= 0 Then
            Dim index As Long = GetDetailIndex(lstDetails.SelectedIndex)
            cmbTileset.SelectedIndex = Detail(index).Tileset
            EditorTileX = Detail(index).StartX
            EditorTileY = Detail(index).StartY
            EditorTileWidth = Detail(index).EndX + 1
            EditorTileHeight = Detail(index).EndY + 1

            EditorTileSelStart = New Point(EditorTileX, EditorTileY)
        End If
    End Sub

    Private Sub txtResource_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnAddDetail_Click(sender As Object, e As EventArgs) Handles btnAddDetail.Click
        Dim DetailCount As Integer
        DetailCount = UBound(Detail)

        SaveDetail(DetailCount)
        DetailCount += 1
        ReDim Preserve Detail(DetailCount)
        UpdateDetailList()
    End Sub

    Private Sub btnDeleteDetail_Click(sender As Object, e As EventArgs) Handles btnDeleteDetail.Click
        If lstDetails.SelectedIndex >= 0 Then
            Dim DetailIndex As Integer = GetDetailIndex(lstDetails.SelectedIndex)
            Detail = Detail.RemoveAt(DetailIndex)
            UpdateDetailList()
        End If
    End Sub

    Private Sub chkBlocked_CheckedChanged(sender As Object, e As EventArgs)
        If chkBlocked.Checked Then
            Tile(Prefab).Type = TileType.Blocked
        Else
            Tile(Prefab).Type = TileType.None
        End If
    End Sub

    Private Sub txtResourceFreq_TextChanged(sender As Object, e As EventArgs) Handles txtResourceFreq.TextChanged

    End Sub

    Private Sub txtDetail_TextChanged(sender As Object, e As EventArgs) Handles txtDetail.TextChanged

    End Sub

    Private Sub txtSandBorder_TextChanged(sender As Object, e As EventArgs) Handles txtSandBorder.TextChanged

    End Sub

    Private Sub txtMapY_TextChanged(sender As Object, e As EventArgs) Handles txtMapY.TextChanged

    End Sub

    Private Sub txtMapX_TextChanged(sender As Object, e As EventArgs) Handles txtMapX.TextChanged

    End Sub

    Private Sub txtMapSize_TextChanged(sender As Object, e As EventArgs) Handles txtMapSize.TextChanged

    End Sub

    Private Sub txtMapStart_TextChanged(sender As Object, e As EventArgs) Handles txtMapStart.TextChanged

    End Sub

    Private Sub scrlPictureY_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlPictureY.Scroll
        AutomapperEditorTileScroll()
    End Sub

    Private Sub cmbTileset_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTileset.SelectedIndexChanged
        If cmbTileset.SelectedIndex + 1 > NumTileSets Then
            cmbTileset.SelectedIndex = 0
        End If

        EditorTileSelStart = New Point(0, 0)
        EditorTileSelEnd = New Point(1, 1)

        scrlPictureY.Maximum = (picBackSelect.Height \ PicY)
        scrlPictureX.Maximum = (picBackSelect.Width \ PicX)

        If Layer > 0 And Prefab > 0 And tbControl.SelectedTab Is tbTilesets Then
            Tile(Prefab).Layer(Layer).Tileset = cmbTileset.SelectedIndex + 1
        End If
    End Sub

    Public Sub AutomapperEditorTileScroll()
        picBackTop = (scrlPictureY.Value * PicY) ' * -1
        picBackLeft = (scrlPictureX.Value * PicX) ' * -1
    End Sub

    Private Sub scrlPictureX_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlPictureX.Scroll
        AutomapperEditorTileScroll()
    End Sub

    Private Sub UpdateTileset(Tileset As Integer)
        If TileSetTextureInfo(Tileset).IsLoaded = False Then
            LoadTexture(Tileset, TextureType.Tilesets)
        End If

        With TileSetTextureInfo(Tileset)
            .TextureTimer = GetTickCount() + 100000
        End With

        scrlPictureY.Maximum = (TileSetTextureInfo(Tileset).Height \ PicY) \ 2
        scrlPictureX.Maximum = (TileSetTextureInfo(Tileset).Width \ PicX) \ 2
    End Sub

    Public Sub Automapper_DrawTileset()
        Dim tileset As Integer

        AutomapperTilesetWindow.DispatchEvents()
        AutomapperTilesetWindow.Clear(SFML.Graphics.Color.Black)

        ' encontrar numero da tileset
        tileset = cmbTileset.SelectedIndex + 1

        ' sair se nao existir
        If tileset <= 0 OrElse tileset > NumTileSets Then Exit Sub

        Dim rec2 As New RectangleShape With {
            .OutlineColor = New SFML.Graphics.Color(SFML.Graphics.Color.Red),
            .OutlineThickness = 0.6,
            .FillColor = New SFML.Graphics.Color(SFML.Graphics.Color.Transparent)
        }

        If TileSetTextureInfo(tileset).IsLoaded = False Then
            LoadTexture(tileset, TextureType.Tilesets)
        End If
        ' atualizar contador
        With TileSetTextureInfo(tileset)
            .TextureTimer = GetTickCount() + 100000
        End With

        ' alterar forma selecionada para autotile
        UpdateTileSize()

        If TileSetTextureInfo(tileset).Width - picBackLeft < picBackSelect.Width Or TileSetTextureInfo(tileset).Height - picBackTop < picBackSelect.Height Then
            RenderSprite(TileSetSprite(tileset), AutomapperTilesetWindow, 0, 0, picBackLeft, picBackTop, TileSetTextureInfo(tileset).Width - picBackLeft, TileSetTextureInfo(tileset).Height - picBackTop)
        Else
            RenderSprite(TileSetSprite(tileset), AutomapperTilesetWindow, 0, 0, picBackLeft, picBackTop, picBackLeft + picBackSelect.Width, picBackTop + picBackSelect.Height)
        End If

        rec2.Size = New Vector2f(EditorTileWidth * PicX, EditorTileHeight * PicY)

        rec2.Position = New Vector2f((EditorTileSelStart.X * PicX - picBackLeft), (EditorTileSelStart.Y * PicY - picBackTop))
        AutomapperTilesetWindow.Draw(rec2)

        'mostrar tudo na tela
        AutomapperTilesetWindow.Display()

        LastTileset = tileset
    End Sub

    Private Sub picBackSelect_MouseDown(sender As Object, e As MouseEventArgs) Handles picBackSelect.MouseDown
        AutomapperEditorChooseTile(e.Button, e.X, e.Y)
    End Sub

    Private Sub picBackSelect_Paint(sender As Object, e As PaintEventArgs) Handles picBackSelect.Paint

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Visible = False
    End Sub

    Private Sub cmbLayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLayer.SelectedIndexChanged
        Prefab = cmbPrefab.SelectedIndex + 1
        Layer = cmbLayer.SelectedIndex + 1
        cmbTileset.SelectedIndex = Tile(Prefab).Layer(Layer).Tileset - 1
        EditorTileX = Tile(Prefab).Layer(Layer).X
        EditorTileY = Tile(Prefab).Layer(Layer).Y
        EditorTileSelStart = New Point(EditorTileX, EditorTileY)
        cmbAutotile.SelectedIndex = Tile(Prefab).Layer(Layer).AutoTile
        chkBlocked.Checked = (Tile(Prefab).Type = TileType.Blocked)
    End Sub

    Private Sub picBackSelect_Click(sender As Object, e As EventArgs) Handles picBackSelect.Click

    End Sub

    Public Sub AutomapperEditorChooseTile(ByVal Button As Integer, ByVal X As Single, ByVal Y As Single)
        EditorTileX = (picBackLeft \ PicX) + (X \ PicX)
        EditorTileY = (picBackTop \ PicY) + (Y \ PicY)

        EditorTileSelStart = New Point(EditorTileX, EditorTileY)
        EditorTileSelEnd = New Point(EditorTileX, EditorTileY)

        UpdateTileSize()

        If Button = MouseButtons.Left Then
            If Prefab > 0 And Layer > 0 And tbControl.SelectedTab Is tbTilesets Then
                Tile(Prefab).Layer(Layer).Tileset = cmbTileset.SelectedIndex + 1
                Tile(Prefab).Layer(Layer).X = EditorTileX
                Tile(Prefab).Layer(Layer).Y = EditorTileY
                Tile(Prefab).Layer(Layer).AutoTile = cmbAutotile.SelectedIndex
            End If
        End If
    End Sub

    Private Sub UpdateTileSize()
        If tbControl.SelectedTab Is tbTilesets Then
            If cmbPrefab.SelectedIndex + 1 = TilePrefab.Mountain Then
                EditorTileWidth = 3
                EditorTileHeight = 5
            Else
                Select Case Me.cmbAutotile.SelectedIndex
                    Case 1 ' autotile
                        EditorTileWidth = 2
                        EditorTileHeight = 3
                    Case 2 ' autotile falsa
                        EditorTileWidth = 1
                        EditorTileHeight = 1
                    Case 3 ' animada
                        EditorTileWidth = 6
                        EditorTileHeight = 3
                    Case 4 ' penhasco
                        EditorTileWidth = 2
                        EditorTileHeight = 2
                    Case 5 ' cachoeira
                        EditorTileWidth = 2
                        EditorTileHeight = 3
                    Case Else
                        EditorTileWidth = 1
                        EditorTileHeight = 1
                End Select
            End If
        End If
    End Sub

    Public Function GetDetailIndex(Index As Integer) As Integer
        Dim i As Integer
        Dim DetailList As New List(Of Integer)
        For i = 0 To UBound(Detail) - 1
            If Detail(i).DetailBase = cmbPrefab.SelectedIndex Then
                DetailList.Add(i)
            End If
        Next

        Return DetailList(Index)
    End Function

    Public Sub AutomapperEditorDrag(ByVal Button As Integer, ByVal X As Single, ByVal Y As Single)

        If Button = MouseButtons.Left And tbControl.SelectedTab Is tbDetails And Me.cmbTileset.SelectedIndex > 0 Then 'botao esquerdo do mouse
            Dim MaxWidth As Integer = TileSetSprite(Me.cmbTileset.SelectedIndex + 1).Texture.Size.X / PicX
            Dim MaxHeight As Integer = TileSetSprite(Me.cmbTileset.SelectedIndex + 1).Texture.Size.Y / PicY

            ' converter o numero do pixel para o numero do tile
            X = (picBackLeft \ PicX) + (X \ PicX) + 1
            Y = (picBackTop \ PicY) + (Y \ PicY) + 1
            ' ver se nao está fora dos limites
            If X < 0 Then X = 0
            If X > MaxWidth Then X = MaxWidth
            If Y < 0 Then Y = 0
            If Y > MaxHeight Then Y = MaxHeight
            ' descobrir qual deve ser o comprimento + altura 
            If X > EditorTileX Then ' drag right
                'EditorTileWidth = X
                EditorTileWidth = X - EditorTileX
            Else ' levar a esquerda
                ' TO DO
            End If
            If Y > EditorTileY Then ' levar para baixo
                'EditorTileHeight = Y
                EditorTileHeight = Y - EditorTileY
            Else ' levar para cima
                ' TO DO
            End If

            EditorTileSelStart = New Point(EditorTileX, EditorTileY)
            EditorTileSelEnd = New Point(EditorTileWidth, EditorTileHeight)
        End If

    End Sub

    Private Sub picBackSelect_MouseMove(sender As Object, e As MouseEventArgs) Handles picBackSelect.MouseMove
        AutomapperEditorDrag(e.Button, e.X, e.Y)
    End Sub

    Private Sub cmbAutotile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAutotile.SelectedIndexChanged
        If Layer > 0 And Prefab > 0 Then
            Tile(Prefab).Layer(Layer).AutoTile = cmbAutotile.SelectedIndex
        End If
    End Sub

    Sub SaveDetail(Index As Integer)
        Detail(Index).DetailBase = cmbPrefab.SelectedIndex
        Detail(Index).Tileset = cmbTileset.SelectedIndex
        Detail(Index).StartX = EditorTileX
        Detail(Index).StartY = EditorTileY
        Detail(Index).EndX = EditorTileWidth - 1
        Detail(Index).EndY = EditorTileHeight - 1
    End Sub

#End Region

End Class