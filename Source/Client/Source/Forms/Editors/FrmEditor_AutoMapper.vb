Imports Ini = ASFW.IO.FileIO.TextFile

Friend Class frmEditor_AutoMapper

#Region "Frm Code"

    Private Sub FrmAutoMapper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlResources.Top = 0
        pnlResources.Left = 0
        pnlTileConfig.Top = 0
        pnlTileConfig.Left = 0
        pnlDetails.Top = 0
        pnlDetails.Left = 0

        Width = 540

        cmbDetailTileset.Items.Clear()
        For i = 1 To NumTileSets
            cmbDetailTileset.Items.Add("Tileset " & i)
        Next
    End Sub

    Private Sub TilesetsToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles TilesetsToolStripMenuItem.Click
        pnlTileConfig.Visible = True
        pnlTileConfig.BringToFront()
    End Sub

    Private Sub ResourcesToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ResourcesToolStripMenuItem.Click
        Dim Resources() As String
        Dim i As Integer

        pnlResources.Visible = True
        pnlResources.BringToFront()

        Resources = Split(ResourcesNum, ";")

        lstResources.Items.Clear()

        For i = 0 To UBound(Resources)
            lstResources.Items.Add(Resources(i))
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

        SendSaveAutoMapper()

        Me.Dispose()
    End Sub

#End Region

#Region "Resources"

    Private Sub LstResources_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstResources.SelectedIndexChanged
        If lstResources.SelectedIndex < 0 Then Exit Sub
        txtResource.Text = lstResources.Items.Item(lstResources.SelectedIndex)
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAddResource.Click
        lstResources.Items.Add(Val(txtResource.Text))
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles btnRemoveResource.Click
        If lstResources.SelectedIndex < 0 Then Exit Sub
        lstResources.Items.RemoveAt(lstResources.SelectedIndex)
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdateResource.Click

        If lstResources.SelectedIndex < 0 Then Exit Sub

        lstResources.Items.Item(lstResources.SelectedIndex) = txtResource.Text
    End Sub

    Private Sub BtnCloseResource_Click(sender As Object, e As EventArgs) Handles btnCloseResource.Click
        pnlResources.Visible = False
    End Sub

    Private Sub BtnSaveResource_Click(sender As Object, e As EventArgs) Handles btnSaveResource.Click
        Dim i As Integer
        Dim ResourceStr As String = ""
        Dim cf = Path.Contents & "AutoMapper.ini"

        For i = 0 To lstResources.Items.Count - 1
            ResourceStr = CStr(ResourceStr & lstResources.Items(i))
            If i < lstResources.Items.Count - 1 Then ResourceStr = ResourceStr & ";"
        Next

        Ini.Write(cf, "Resources", "ResourcesNum", ResourceStr)

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

        cmbLayer.SelectedIndex = Layer - 1
        CmbLayer_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub CmbLayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLayer.SelectedIndexChanged
        Dim Prefab As Integer
        Dim Layer As Integer
        Prefab = cmbPrefab.SelectedIndex + 1
        Layer = cmbLayer.SelectedIndex + 1
        txtTileset.Text = Tile(Prefab).Layer(Layer).Tileset
        txtTileX.Text = Tile(Prefab).Layer(Layer).X
        txtTileY.Text = Tile(Prefab).Layer(Layer).Y
        txtAutotile.Text = Tile(Prefab).Layer(Layer).AutoTile

        If Tile(Prefab).Type = TileType.Blocked Then
            chkBlocked.Checked = True
        Else
            chkBlocked.Checked = False
        End If
    End Sub

    Private Sub BtnTileSetClose_Click(sender As Object, e As EventArgs) Handles btnTileSetClose.Click
        pnlTileConfig.Visible = False
    End Sub

    Private Sub BtnTileSetSave_Click(sender As Object, e As EventArgs) Handles btnTileSetSave.Click
        Dim Prefab As Integer, Layer As Integer
        Dim cf = Path.Contents & "AutoMapper.ini"

        Prefab = cmbPrefab.SelectedIndex + 1

        For Layer = 1 To 5
            If Tile(Prefab).Layer(Layer).Tileset > 0 Then
                Ini.Write(cf, "Prefab" & Prefab, "Layer" & Layer & "Tileset", Val(Tile(Prefab).Layer(Layer).Tileset))
                Ini.Write(cf, "Prefab" & Prefab, "Layer" & Layer & "X", Val(Tile(Prefab).Layer(Layer).X))
                Ini.Write(cf, "Prefab" & Prefab, "Layer" & Layer & "Y", Val(Tile(Prefab).Layer(Layer).Y))
                Ini.Write(cf, "Prefab" & Prefab, "Layer" & Layer & "Autotile", Val(Tile(Prefab).Layer(Layer).AutoTile))
            End If
        Next Layer

        Ini.Write(cf, "Prefab" & Prefab, "Type", Val(Tile(Prefab).Type))

        pnlTileConfig.Visible = False

        LoadTilePrefab()
        LoadDetails()
    End Sub

    Private Sub btnDetailHelper_Click(sender As Object, e As EventArgs) Handles btnDetailHelper.Click
        MsgBox("- Os detalhes serão sobrepostos da camada que for selecionada em 'Aparecer somente sobre'" & vbNewLine &
               "- Selecione o tileset que contenha detalhes (Como flores, pedras, cogumelos, etc...) um ao lado do outro" & vbNewLine &
               "- Em Início X e Y, indique um número inteiro onde os detalhes se iniciam no tileset, utilize o editor de mapa se necessário. Cada número representa um quadrado 32x32 pixels." & vbNewLine &
               "- Em Area X e Y, indique um número inteiro de quantos detalhes possuem naquela região. Cada número representa um quadrado 32x32 pixels")
    End Sub

    Private Sub ResourcesToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ResourcesToolStripMenuItem3.Click

    End Sub

    Private Sub DetalhesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetalhesToolStripMenuItem.Click
        pnlDetails.Visible = True
        pnlDetails.BringToFront()
        UpdateDetailList()
    End Sub

    Private Sub UpdateDetailList()
        Dim i As Long
        lstDetails.Items.Clear()

        For i = 1 To UBound(Detail)
            lstDetails.Items.Add("Detalhe " & i)
        Next
    End Sub

    Private Sub lstDetails_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDetails.SelectedIndexChanged
        cmbDetailPrefab.Enabled = True
        cmbDetailTileset.Enabled = True
        txtDetailStartX.Enabled = True
        txtDetailStartY.Enabled = True
        txtAreaXDetail.Enabled = True
        txtAreaYDetail.Enabled = True

        Dim index As Long = lstDetails.SelectedIndex

        cmbDetailPrefab.SelectedIndex = Detail(index).DetailBase
        cmbDetailTileset.SelectedIndex = Detail(index).Tileset
        txtDetailStartX.Text = Detail(index).StartX
        txtDetailStartY.Text = Detail(index).StartY
        txtAreaXDetail.Text = Detail(index).EndX
        txtAreaYDetail.Text = Detail(index).EndY
    End Sub

    Private Sub btnCloseDetail_Click(sender As Object, e As EventArgs) Handles btnCloseDetail.Click
        pnlDetails.Visible = False
    End Sub

    Private Sub txtDetailStartX_TextChanged(sender As Object, e As EventArgs) Handles txtDetailStartX.TextChanged
        If lstDetails.SelectedIndex >= 0 Then
            Detail(lstDetails.SelectedIndex).StartX = Val(txtDetailStartX.Text)
        End If
    End Sub

    Private Sub cmbDetailPrefab_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDetailPrefab.SelectedIndexChanged
        If lstDetails.SelectedIndex >= 0 Then
            Detail(lstDetails.SelectedIndex).DetailBase = cmbDetailPrefab.SelectedIndex
        End If
    End Sub

    Private Sub cmbDetailTileset_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDetailTileset.SelectedIndexChanged
        If lstDetails.SelectedIndex >= 0 Then
            Detail(lstDetails.SelectedIndex).Tileset = cmbDetailTileset.SelectedIndex
        End If
    End Sub

    Private Sub txtDetailStartY_TextChanged(sender As Object, e As EventArgs) Handles txtDetailStartY.TextChanged
        If lstDetails.SelectedIndex >= 0 Then
            Detail(lstDetails.SelectedIndex).StartY = Val(txtDetailStartY.Text)
        End If
    End Sub

    Private Sub txtAreaXDetail_TextChanged(sender As Object, e As EventArgs) Handles txtAreaXDetail.TextChanged
        If lstDetails.SelectedIndex >= 0 Then
            Detail(lstDetails.SelectedIndex).EndX = Val(txtAreaXDetail.Text)
        End If
    End Sub

    Private Sub txtAreaYDetail_TextChanged(sender As Object, e As EventArgs) Handles txtAreaYDetail.TextChanged
        If lstDetails.SelectedIndex >= 0 Then
            Detail(lstDetails.SelectedIndex).EndY = Val(txtAreaYDetail.Text)
        End If
    End Sub

    Private Sub txtResource_TextChanged(sender As Object, e As EventArgs) Handles txtResource.TextChanged

    End Sub

    Private Sub btnAddDetail_Click(sender As Object, e As EventArgs) Handles btnAddDetail.Click
        Dim DetailCount As Integer
        DetailCount = UBound(Detail) + 1

        ReDim Preserve Detail(DetailCount)
        UpdateDetailList()
    End Sub

    Private Sub btnDeleteDetail_Click(sender As Object, e As EventArgs) Handles btnDeleteDetail.Click
        If lstDetails.SelectedIndex >= 0 Then
            Detail = Detail.RemoveAt(lstDetails.SelectedIndex + 1)
            UpdateDetailList()
        End If
    End Sub

    Private Sub btnSaveDetail_Click(sender As Object, e As EventArgs) Handles btnSaveDetail.Click
        Dim TileDetail As Integer
        Dim cf = Path.Contents & "AutoMapper.ini"

        For TileDetail = 0 To UBound(Detail) - 1
            Ini.WriteOrCreate(cf, "Detail" & TileDetail, "Prefab", Val(Detail(TileDetail).DetailBase))
            Ini.WriteOrCreate(cf, "Detail" & TileDetail, "Tileset", Val(Detail(TileDetail).Tileset))
            Ini.WriteOrCreate(cf, "Detail" & TileDetail, "StartX", Val(Detail(TileDetail).StartX))
            Ini.WriteOrCreate(cf, "Detail" & TileDetail, "StartY", Val(Detail(TileDetail).StartY))
            Ini.WriteOrCreate(cf, "Detail" & TileDetail, "EndX", Val(Detail(TileDetail).EndX))
            Ini.WriteOrCreate(cf, "Detail" & TileDetail, "EndY", Val(Detail(TileDetail).EndY))
        Next TileDetail

        Ini.WriteOrCreate(cf, "Details", "DetailCount", Val(UBound(Detail)))

        pnlDetails.Visible = False
    End Sub

#End Region

End Class