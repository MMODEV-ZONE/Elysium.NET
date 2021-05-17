<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_AutoMapper
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlResources = New System.Windows.Forms.Panel()
        Me.cmbResources = New System.Windows.Forms.ComboBox()
        Me.btnAddResource = New System.Windows.Forms.Button()
        Me.btnRemoveResource = New System.Windows.Forms.Button()
        Me.btnUpdateResource = New System.Windows.Forms.Button()
        Me.btnSaveResource = New System.Windows.Forms.Button()
        Me.btnCloseResource = New System.Windows.Forms.Button()
        Me.DarkLabel8 = New System.Windows.Forms.Label()
        Me.lstResources = New System.Windows.Forms.ListBox()
        Me.pnlTileConfig = New System.Windows.Forms.Panel()
        Me.tbControl = New System.Windows.Forms.TabControl()
        Me.tbTilesets = New System.Windows.Forms.TabPage()
        Me.chkBlocked = New System.Windows.Forms.CheckBox()
        Me.cmbAutotile = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.DarkLabel10 = New System.Windows.Forms.Label()
        Me.cmbLayer = New System.Windows.Forms.ComboBox()
        Me.tbDetails = New System.Windows.Forms.TabPage()
        Me.btnDeleteDetail = New System.Windows.Forms.Button()
        Me.btnAddDetail = New System.Windows.Forms.Button()
        Me.lstDetails = New System.Windows.Forms.ListBox()
        Me.btnTileSetSave = New System.Windows.Forms.Button()
        Me.btnTileSetClose = New System.Windows.Forms.Button()
        Me.DarkLabel9 = New System.Windows.Forms.Label()
        Me.cmbPrefab = New System.Windows.Forms.ComboBox()
        Me.frmTileset = New System.Windows.Forms.GroupBox()
        Me.scrlPictureX = New System.Windows.Forms.HScrollBar()
        Me.scrlPictureY = New System.Windows.Forms.VScrollBar()
        Me.picBackSelect = New System.Windows.Forms.PictureBox()
        Me.cmbTileset = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DarkMenu = New System.Windows.Forms.MenuStrip()
        Me.ConfigurationsToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TilesetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResourcesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PathsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RiversToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MountainsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OverGrassToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResourcesToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetailsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DarkLabel1 = New System.Windows.Forms.Label()
        Me.DarkLabel2 = New System.Windows.Forms.Label()
        Me.DarkLabel3 = New System.Windows.Forms.Label()
        Me.DarkLabel4 = New System.Windows.Forms.Label()
        Me.DarkLabel5 = New System.Windows.Forms.Label()
        Me.DarkLabel6 = New System.Windows.Forms.Label()
        Me.DarkLabel7 = New System.Windows.Forms.Label()
        Me.txtMapStart = New System.Windows.Forms.TextBox()
        Me.txtMapSize = New System.Windows.Forms.TextBox()
        Me.txtMapX = New System.Windows.Forms.TextBox()
        Me.txtMapY = New System.Windows.Forms.TextBox()
        Me.txtSandBorder = New System.Windows.Forms.TextBox()
        Me.txtDetail = New System.Windows.Forms.TextBox()
        Me.txtResourceFreq = New System.Windows.Forms.TextBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlResources.SuspendLayout()
        Me.pnlTileConfig.SuspendLayout()
        Me.tbControl.SuspendLayout()
        Me.tbTilesets.SuspendLayout()
        Me.tbDetails.SuspendLayout()
        Me.frmTileset.SuspendLayout()
        CType(Me.picBackSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DarkMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlResources
        '
        Me.pnlResources.Controls.Add(Me.cmbResources)
        Me.pnlResources.Controls.Add(Me.btnAddResource)
        Me.pnlResources.Controls.Add(Me.btnRemoveResource)
        Me.pnlResources.Controls.Add(Me.btnUpdateResource)
        Me.pnlResources.Controls.Add(Me.btnSaveResource)
        Me.pnlResources.Controls.Add(Me.btnCloseResource)
        Me.pnlResources.Controls.Add(Me.DarkLabel8)
        Me.pnlResources.Controls.Add(Me.lstResources)
        Me.pnlResources.Location = New System.Drawing.Point(525, 25)
        Me.pnlResources.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlResources.Name = "pnlResources"
        Me.pnlResources.Size = New System.Drawing.Size(514, 351)
        Me.pnlResources.TabIndex = 24
        Me.pnlResources.Visible = False
        '
        'cmbResources
        '
        Me.cmbResources.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.cmbResources.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbResources.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbResources.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbResources.FormattingEnabled = True
        Me.cmbResources.Location = New System.Drawing.Point(82, 149)
        Me.cmbResources.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbResources.Name = "cmbResources"
        Me.cmbResources.Size = New System.Drawing.Size(247, 24)
        Me.cmbResources.TabIndex = 45
        '
        'btnAddResource
        '
        Me.btnAddResource.BackColor = System.Drawing.SystemColors.Control
        Me.btnAddResource.Location = New System.Drawing.Point(337, 149)
        Me.btnAddResource.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddResource.Name = "btnAddResource"
        Me.btnAddResource.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnAddResource.Size = New System.Drawing.Size(163, 37)
        Me.btnAddResource.TabIndex = 14
        Me.btnAddResource.Text = "Adicionar"
        Me.btnAddResource.UseVisualStyleBackColor = False
        '
        'btnRemoveResource
        '
        Me.btnRemoveResource.BackColor = System.Drawing.SystemColors.Control
        Me.btnRemoveResource.Location = New System.Drawing.Point(337, 232)
        Me.btnRemoveResource.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRemoveResource.Name = "btnRemoveResource"
        Me.btnRemoveResource.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnRemoveResource.Size = New System.Drawing.Size(163, 37)
        Me.btnRemoveResource.TabIndex = 13
        Me.btnRemoveResource.Text = "Remover"
        Me.btnRemoveResource.UseVisualStyleBackColor = False
        '
        'btnUpdateResource
        '
        Me.btnUpdateResource.BackColor = System.Drawing.SystemColors.Control
        Me.btnUpdateResource.Location = New System.Drawing.Point(337, 190)
        Me.btnUpdateResource.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUpdateResource.Name = "btnUpdateResource"
        Me.btnUpdateResource.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnUpdateResource.Size = New System.Drawing.Size(163, 37)
        Me.btnUpdateResource.TabIndex = 12
        Me.btnUpdateResource.Text = "Modificar"
        Me.btnUpdateResource.UseVisualStyleBackColor = False
        '
        'btnSaveResource
        '
        Me.btnSaveResource.BackColor = System.Drawing.SystemColors.Control
        Me.btnSaveResource.Location = New System.Drawing.Point(337, 284)
        Me.btnSaveResource.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSaveResource.Name = "btnSaveResource"
        Me.btnSaveResource.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnSaveResource.Size = New System.Drawing.Size(163, 39)
        Me.btnSaveResource.TabIndex = 11
        Me.btnSaveResource.Text = "Salvar"
        Me.btnSaveResource.UseVisualStyleBackColor = False
        '
        'btnCloseResource
        '
        Me.btnCloseResource.BackColor = System.Drawing.SystemColors.Control
        Me.btnCloseResource.Location = New System.Drawing.Point(4, 284)
        Me.btnCloseResource.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCloseResource.Name = "btnCloseResource"
        Me.btnCloseResource.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnCloseResource.Size = New System.Drawing.Size(163, 39)
        Me.btnCloseResource.TabIndex = 10
        Me.btnCloseResource.Text = "Fechar"
        Me.btnCloseResource.UseVisualStyleBackColor = False
        '
        'DarkLabel8
        '
        Me.DarkLabel8.AutoSize = True
        Me.DarkLabel8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel8.Location = New System.Drawing.Point(4, 149)
        Me.DarkLabel8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel8.Name = "DarkLabel8"
        Me.DarkLabel8.Size = New System.Drawing.Size(65, 17)
        Me.DarkLabel8.TabIndex = 8
        Me.DarkLabel8.Text = "Recurso:"
        '
        'lstResources
        '
        Me.lstResources.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.lstResources.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstResources.FormattingEnabled = True
        Me.lstResources.ItemHeight = 16
        Me.lstResources.Location = New System.Drawing.Point(4, 4)
        Me.lstResources.Margin = New System.Windows.Forms.Padding(4)
        Me.lstResources.Name = "lstResources"
        Me.lstResources.Size = New System.Drawing.Size(496, 132)
        Me.lstResources.TabIndex = 0
        '
        'pnlTileConfig
        '
        Me.pnlTileConfig.Controls.Add(Me.tbControl)
        Me.pnlTileConfig.Controls.Add(Me.btnTileSetSave)
        Me.pnlTileConfig.Controls.Add(Me.btnTileSetClose)
        Me.pnlTileConfig.Controls.Add(Me.DarkLabel9)
        Me.pnlTileConfig.Controls.Add(Me.cmbPrefab)
        Me.pnlTileConfig.Controls.Add(Me.frmTileset)
        Me.pnlTileConfig.Location = New System.Drawing.Point(1060, 25)
        Me.pnlTileConfig.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlTileConfig.Name = "pnlTileConfig"
        Me.pnlTileConfig.Size = New System.Drawing.Size(508, 743)
        Me.pnlTileConfig.TabIndex = 25
        Me.pnlTileConfig.Visible = False
        '
        'tbControl
        '
        Me.tbControl.Controls.Add(Me.tbTilesets)
        Me.tbControl.Controls.Add(Me.tbDetails)
        Me.tbControl.Enabled = False
        Me.tbControl.Location = New System.Drawing.Point(12, 41)
        Me.tbControl.Name = "tbControl"
        Me.tbControl.SelectedIndex = 0
        Me.tbControl.Size = New System.Drawing.Size(485, 123)
        Me.tbControl.TabIndex = 49
        '
        'tbTilesets
        '
        Me.tbTilesets.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tbTilesets.Controls.Add(Me.chkBlocked)
        Me.tbTilesets.Controls.Add(Me.cmbAutotile)
        Me.tbTilesets.Controls.Add(Me.Label14)
        Me.tbTilesets.Controls.Add(Me.DarkLabel10)
        Me.tbTilesets.Controls.Add(Me.cmbLayer)
        Me.tbTilesets.ForeColor = System.Drawing.Color.Gainsboro
        Me.tbTilesets.Location = New System.Drawing.Point(4, 25)
        Me.tbTilesets.Name = "tbTilesets"
        Me.tbTilesets.Padding = New System.Windows.Forms.Padding(3)
        Me.tbTilesets.Size = New System.Drawing.Size(477, 94)
        Me.tbTilesets.TabIndex = 0
        Me.tbTilesets.Text = "Tileset"
        '
        'chkBlocked
        '
        Me.chkBlocked.AutoSize = True
        Me.chkBlocked.ForeColor = System.Drawing.Color.Gainsboro
        Me.chkBlocked.Location = New System.Drawing.Point(333, 54)
        Me.chkBlocked.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBlocked.Name = "chkBlocked"
        Me.chkBlocked.Size = New System.Drawing.Size(137, 21)
        Me.chkBlocked.TabIndex = 53
        Me.chkBlocked.Text = "Está bloqueado?"
        '
        'cmbAutotile
        '
        Me.cmbAutotile.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.cmbAutotile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAutotile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAutotile.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbAutotile.FormattingEnabled = True
        Me.cmbAutotile.Items.AddRange(New Object() {"Normal", "AutoTile (VX)", "Fake (VX)", "Animated (VX)", "Cliff (VX)", "Waterfall (VX)"})
        Me.cmbAutotile.Location = New System.Drawing.Point(143, 53)
        Me.cmbAutotile.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbAutotile.Name = "cmbAutotile"
        Me.cmbAutotile.Size = New System.Drawing.Size(174, 24)
        Me.cmbAutotile.TabIndex = 52
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label14.Location = New System.Drawing.Point(71, 55)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 17)
        Me.Label14.TabIndex = 51
        Me.Label14.Text = "AutoTile:"
        '
        'DarkLabel10
        '
        Me.DarkLabel10.AutoSize = True
        Me.DarkLabel10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel10.Location = New System.Drawing.Point(7, 21)
        Me.DarkLabel10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel10.Name = "DarkLabel10"
        Me.DarkLabel10.Size = New System.Drawing.Size(128, 17)
        Me.DarkLabel10.TabIndex = 49
        Me.DarkLabel10.Text = "Escolha a camada:"
        '
        'cmbLayer
        '
        Me.cmbLayer.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.cmbLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbLayer.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbLayer.FormattingEnabled = True
        Me.cmbLayer.Items.AddRange(New Object() {"Chão", "Máscara", "Máscara 2", "Franja", "Franja 2"})
        Me.cmbLayer.Location = New System.Drawing.Point(143, 18)
        Me.cmbLayer.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbLayer.Name = "cmbLayer"
        Me.cmbLayer.Size = New System.Drawing.Size(321, 24)
        Me.cmbLayer.TabIndex = 50
        '
        'tbDetails
        '
        Me.tbDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tbDetails.Controls.Add(Me.btnDeleteDetail)
        Me.tbDetails.Controls.Add(Me.btnAddDetail)
        Me.tbDetails.Controls.Add(Me.lstDetails)
        Me.tbDetails.ForeColor = System.Drawing.Color.Gainsboro
        Me.tbDetails.Location = New System.Drawing.Point(4, 25)
        Me.tbDetails.Name = "tbDetails"
        Me.tbDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tbDetails.Size = New System.Drawing.Size(477, 94)
        Me.tbDetails.TabIndex = 1
        Me.tbDetails.Text = "Detalhes"
        '
        'btnDeleteDetail
        '
        Me.btnDeleteDetail.BackColor = System.Drawing.SystemColors.Control
        Me.btnDeleteDetail.Image = Global.My.Resources.Resources._Exit
        Me.btnDeleteDetail.Location = New System.Drawing.Point(430, 49)
        Me.btnDeleteDetail.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDeleteDetail.Name = "btnDeleteDetail"
        Me.btnDeleteDetail.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnDeleteDetail.Size = New System.Drawing.Size(37, 30)
        Me.btnDeleteDetail.TabIndex = 18
        Me.btnDeleteDetail.UseVisualStyleBackColor = False
        '
        'btnAddDetail
        '
        Me.btnAddDetail.BackColor = System.Drawing.SystemColors.Control
        Me.btnAddDetail.Image = Global.My.Resources.Resources.Save
        Me.btnAddDetail.Location = New System.Drawing.Point(430, 11)
        Me.btnAddDetail.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddDetail.Name = "btnAddDetail"
        Me.btnAddDetail.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnAddDetail.Size = New System.Drawing.Size(37, 30)
        Me.btnAddDetail.TabIndex = 17
        Me.btnAddDetail.UseVisualStyleBackColor = False
        '
        'lstDetails
        '
        Me.lstDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.lstDetails.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstDetails.FormattingEnabled = True
        Me.lstDetails.ItemHeight = 16
        Me.lstDetails.Location = New System.Drawing.Point(10, 13)
        Me.lstDetails.Margin = New System.Windows.Forms.Padding(4)
        Me.lstDetails.Name = "lstDetails"
        Me.lstDetails.Size = New System.Drawing.Size(412, 68)
        Me.lstDetails.TabIndex = 2
        '
        'btnTileSetSave
        '
        Me.btnTileSetSave.BackColor = System.Drawing.SystemColors.Control
        Me.btnTileSetSave.Location = New System.Drawing.Point(397, 688)
        Me.btnTileSetSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTileSetSave.Name = "btnTileSetSave"
        Me.btnTileSetSave.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnTileSetSave.Size = New System.Drawing.Size(100, 39)
        Me.btnTileSetSave.TabIndex = 45
        Me.btnTileSetSave.Text = "Salvar"
        Me.btnTileSetSave.UseVisualStyleBackColor = False
        '
        'btnTileSetClose
        '
        Me.btnTileSetClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnTileSetClose.Location = New System.Drawing.Point(12, 688)
        Me.btnTileSetClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTileSetClose.Name = "btnTileSetClose"
        Me.btnTileSetClose.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnTileSetClose.Size = New System.Drawing.Size(100, 42)
        Me.btnTileSetClose.TabIndex = 44
        Me.btnTileSetClose.Text = "Fechar"
        Me.btnTileSetClose.UseVisualStyleBackColor = False
        '
        'DarkLabel9
        '
        Me.DarkLabel9.AutoSize = True
        Me.DarkLabel9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel9.Location = New System.Drawing.Point(9, 12)
        Me.DarkLabel9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel9.Name = "DarkLabel9"
        Me.DarkLabel9.Size = New System.Drawing.Size(120, 17)
        Me.DarkLabel9.TabIndex = 43
        Me.DarkLabel9.Text = "Escolha o Prefab:"
        '
        'cmbPrefab
        '
        Me.cmbPrefab.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.cmbPrefab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrefab.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPrefab.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbPrefab.FormattingEnabled = True
        Me.cmbPrefab.Items.AddRange(New Object() {"Água", "Areia", "Grama", "Passeio", "Sobre-grama", "Rio", "Montanha"})
        Me.cmbPrefab.Location = New System.Drawing.Point(153, 9)
        Me.cmbPrefab.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPrefab.Name = "cmbPrefab"
        Me.cmbPrefab.Size = New System.Drawing.Size(335, 24)
        Me.cmbPrefab.TabIndex = 43
        '
        'frmTileset
        '
        Me.frmTileset.Controls.Add(Me.scrlPictureX)
        Me.frmTileset.Controls.Add(Me.scrlPictureY)
        Me.frmTileset.Controls.Add(Me.picBackSelect)
        Me.frmTileset.Controls.Add(Me.cmbTileset)
        Me.frmTileset.Controls.Add(Me.Label11)
        Me.frmTileset.Enabled = False
        Me.frmTileset.ForeColor = System.Drawing.Color.Gainsboro
        Me.frmTileset.Location = New System.Drawing.Point(9, 173)
        Me.frmTileset.Margin = New System.Windows.Forms.Padding(4)
        Me.frmTileset.Name = "frmTileset"
        Me.frmTileset.Padding = New System.Windows.Forms.Padding(4)
        Me.frmTileset.Size = New System.Drawing.Size(488, 507)
        Me.frmTileset.TabIndex = 4
        Me.frmTileset.TabStop = False
        Me.frmTileset.Text = "Configurações de Tile"
        '
        'scrlPictureX
        '
        Me.scrlPictureX.LargeChange = 1
        Me.scrlPictureX.Location = New System.Drawing.Point(17, 468)
        Me.scrlPictureX.Name = "scrlPictureX"
        Me.scrlPictureX.Size = New System.Drawing.Size(431, 26)
        Me.scrlPictureX.TabIndex = 47
        '
        'scrlPictureY
        '
        Me.scrlPictureY.LargeChange = 1
        Me.scrlPictureY.Location = New System.Drawing.Point(448, 59)
        Me.scrlPictureY.Name = "scrlPictureY"
        Me.scrlPictureY.Size = New System.Drawing.Size(23, 409)
        Me.scrlPictureY.TabIndex = 48
        '
        'picBackSelect
        '
        Me.picBackSelect.BackColor = System.Drawing.Color.Black
        Me.picBackSelect.Location = New System.Drawing.Point(17, 56)
        Me.picBackSelect.Margin = New System.Windows.Forms.Padding(4)
        Me.picBackSelect.Name = "picBackSelect"
        Me.picBackSelect.Size = New System.Drawing.Size(434, 412)
        Me.picBackSelect.TabIndex = 46
        Me.picBackSelect.TabStop = False
        '
        'cmbTileset
        '
        Me.cmbTileset.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.cmbTileset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTileset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTileset.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbTileset.FormattingEnabled = True
        Me.cmbTileset.Location = New System.Drawing.Point(76, 24)
        Me.cmbTileset.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbTileset.Name = "cmbTileset"
        Me.cmbTileset.Size = New System.Drawing.Size(395, 24)
        Me.cmbTileset.TabIndex = 44
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 27)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 17)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Tileset:"
        '
        'DarkMenu
        '
        Me.DarkMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkMenu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkMenu.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.DarkMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurationsToolStripMenuItem2, Me.GenerateToolStripMenuItem1})
        Me.DarkMenu.Location = New System.Drawing.Point(0, 0)
        Me.DarkMenu.Name = "DarkMenu"
        Me.DarkMenu.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.DarkMenu.Size = New System.Drawing.Size(1584, 28)
        Me.DarkMenu.TabIndex = 27
        '
        'ConfigurationsToolStripMenuItem2
        '
        Me.ConfigurationsToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TilesetsToolStripMenuItem, Me.ResourcesToolStripMenuItem})
        Me.ConfigurationsToolStripMenuItem2.ForeColor = System.Drawing.Color.Gainsboro
        Me.ConfigurationsToolStripMenuItem2.Name = "ConfigurationsToolStripMenuItem2"
        Me.ConfigurationsToolStripMenuItem2.Size = New System.Drawing.Size(112, 24)
        Me.ConfigurationsToolStripMenuItem2.Text = "Configuração"
        '
        'TilesetsToolStripMenuItem
        '
        Me.TilesetsToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.TilesetsToolStripMenuItem.Name = "TilesetsToolStripMenuItem"
        Me.TilesetsToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.TilesetsToolStripMenuItem.Text = "Tilesets"
        '
        'ResourcesToolStripMenuItem
        '
        Me.ResourcesToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.ResourcesToolStripMenuItem.Name = "ResourcesToolStripMenuItem"
        Me.ResourcesToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.ResourcesToolStripMenuItem.Text = "Recursos"
        '
        'GenerateToolStripMenuItem1
        '
        Me.GenerateToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PathsToolStripMenuItem1, Me.RiversToolStripMenuItem1, Me.MountainsToolStripMenuItem1, Me.OverGrassToolStripMenuItem1, Me.ResourcesToolStripMenuItem3, Me.DetailsToolStripMenuItem1})
        Me.GenerateToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.GenerateToolStripMenuItem1.Name = "GenerateToolStripMenuItem1"
        Me.GenerateToolStripMenuItem1.Size = New System.Drawing.Size(59, 24)
        Me.GenerateToolStripMenuItem1.Text = "Gerar"
        '
        'PathsToolStripMenuItem1
        '
        Me.PathsToolStripMenuItem1.Checked = True
        Me.PathsToolStripMenuItem1.CheckOnClick = True
        Me.PathsToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PathsToolStripMenuItem1.ForeColor = System.Drawing.Color.Black
        Me.PathsToolStripMenuItem1.Name = "PathsToolStripMenuItem1"
        Me.PathsToolStripMenuItem1.Size = New System.Drawing.Size(180, 26)
        Me.PathsToolStripMenuItem1.Text = "Caminhos"
        '
        'RiversToolStripMenuItem1
        '
        Me.RiversToolStripMenuItem1.Checked = True
        Me.RiversToolStripMenuItem1.CheckOnClick = True
        Me.RiversToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RiversToolStripMenuItem1.ForeColor = System.Drawing.Color.Black
        Me.RiversToolStripMenuItem1.Name = "RiversToolStripMenuItem1"
        Me.RiversToolStripMenuItem1.Size = New System.Drawing.Size(180, 26)
        Me.RiversToolStripMenuItem1.Text = "Rios"
        '
        'MountainsToolStripMenuItem1
        '
        Me.MountainsToolStripMenuItem1.Checked = True
        Me.MountainsToolStripMenuItem1.CheckOnClick = True
        Me.MountainsToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MountainsToolStripMenuItem1.ForeColor = System.Drawing.Color.Black
        Me.MountainsToolStripMenuItem1.Name = "MountainsToolStripMenuItem1"
        Me.MountainsToolStripMenuItem1.Size = New System.Drawing.Size(180, 26)
        Me.MountainsToolStripMenuItem1.Text = "Montanhas"
        '
        'OverGrassToolStripMenuItem1
        '
        Me.OverGrassToolStripMenuItem1.Checked = True
        Me.OverGrassToolStripMenuItem1.CheckOnClick = True
        Me.OverGrassToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.OverGrassToolStripMenuItem1.ForeColor = System.Drawing.Color.Black
        Me.OverGrassToolStripMenuItem1.Name = "OverGrassToolStripMenuItem1"
        Me.OverGrassToolStripMenuItem1.Size = New System.Drawing.Size(180, 26)
        Me.OverGrassToolStripMenuItem1.Text = "Sobre-grama"
        '
        'ResourcesToolStripMenuItem3
        '
        Me.ResourcesToolStripMenuItem3.Checked = True
        Me.ResourcesToolStripMenuItem3.CheckOnClick = True
        Me.ResourcesToolStripMenuItem3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ResourcesToolStripMenuItem3.ForeColor = System.Drawing.Color.Black
        Me.ResourcesToolStripMenuItem3.Name = "ResourcesToolStripMenuItem3"
        Me.ResourcesToolStripMenuItem3.Size = New System.Drawing.Size(180, 26)
        Me.ResourcesToolStripMenuItem3.Text = "Recursos"
        '
        'DetailsToolStripMenuItem1
        '
        Me.DetailsToolStripMenuItem1.Checked = True
        Me.DetailsToolStripMenuItem1.CheckOnClick = True
        Me.DetailsToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DetailsToolStripMenuItem1.ForeColor = System.Drawing.Color.Black
        Me.DetailsToolStripMenuItem1.Name = "DetailsToolStripMenuItem1"
        Me.DetailsToolStripMenuItem1.Size = New System.Drawing.Size(180, 26)
        Me.DetailsToolStripMenuItem1.Text = "Detalhes"
        '
        'DarkLabel1
        '
        Me.DarkLabel1.AutoSize = True
        Me.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel1.Location = New System.Drawing.Point(16, 38)
        Me.DarkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel1.Name = "DarkLabel1"
        Me.DarkLabel1.Size = New System.Drawing.Size(86, 17)
        Me.DarkLabel1.TabIndex = 28
        Me.DarkLabel1.Text = "Mapa Inicial:"
        '
        'DarkLabel2
        '
        Me.DarkLabel2.AutoSize = True
        Me.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel2.Location = New System.Drawing.Point(16, 70)
        Me.DarkLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel2.Name = "DarkLabel2"
        Me.DarkLabel2.Size = New System.Drawing.Size(88, 17)
        Me.DarkLabel2.TabIndex = 29
        Me.DarkLabel2.Text = "Área de Ilha:"
        '
        'DarkLabel3
        '
        Me.DarkLabel3.AutoSize = True
        Me.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel3.Location = New System.Drawing.Point(18, 102)
        Me.DarkLabel3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel3.Name = "DarkLabel3"
        Me.DarkLabel3.Size = New System.Drawing.Size(154, 17)
        Me.DarkLabel3.TabIndex = 30
        Me.DarkLabel3.Text = "Tamanho do Mapa (X):"
        '
        'DarkLabel4
        '
        Me.DarkLabel4.AutoSize = True
        Me.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel4.Location = New System.Drawing.Point(16, 134)
        Me.DarkLabel4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel4.Name = "DarkLabel4"
        Me.DarkLabel4.Size = New System.Drawing.Size(154, 17)
        Me.DarkLabel4.TabIndex = 31
        Me.DarkLabel4.Text = "Tamanho do Mapa (Y):"
        '
        'DarkLabel5
        '
        Me.DarkLabel5.AutoSize = True
        Me.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel5.Location = New System.Drawing.Point(18, 166)
        Me.DarkLabel5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel5.Name = "DarkLabel5"
        Me.DarkLabel5.Size = New System.Drawing.Size(107, 17)
        Me.DarkLabel5.TabIndex = 32
        Me.DarkLabel5.Text = "Borda de Areia:"
        '
        'DarkLabel6
        '
        Me.DarkLabel6.AutoSize = True
        Me.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel6.Location = New System.Drawing.Point(18, 198)
        Me.DarkLabel6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel6.Name = "DarkLabel6"
        Me.DarkLabel6.Size = New System.Drawing.Size(153, 17)
        Me.DarkLabel6.TabIndex = 33
        Me.DarkLabel6.Text = "Freq. de Detalhes 1 de"
        '
        'DarkLabel7
        '
        Me.DarkLabel7.AutoSize = True
        Me.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel7.Location = New System.Drawing.Point(16, 230)
        Me.DarkLabel7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel7.Name = "DarkLabel7"
        Me.DarkLabel7.Size = New System.Drawing.Size(161, 17)
        Me.DarkLabel7.TabIndex = 34
        Me.DarkLabel7.Text = "Freq. de Recursos 1 de "
        '
        'txtMapStart
        '
        Me.txtMapStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtMapStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMapStart.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtMapStart.Location = New System.Drawing.Point(194, 34)
        Me.txtMapStart.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMapStart.Name = "txtMapStart"
        Me.txtMapStart.Size = New System.Drawing.Size(299, 22)
        Me.txtMapStart.TabIndex = 35
        Me.txtMapStart.Text = "1"
        '
        'txtMapSize
        '
        Me.txtMapSize.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtMapSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMapSize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtMapSize.Location = New System.Drawing.Point(194, 66)
        Me.txtMapSize.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMapSize.Name = "txtMapSize"
        Me.txtMapSize.Size = New System.Drawing.Size(299, 22)
        Me.txtMapSize.TabIndex = 36
        Me.txtMapSize.Text = "4"
        '
        'txtMapX
        '
        Me.txtMapX.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtMapX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMapX.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtMapX.Location = New System.Drawing.Point(194, 98)
        Me.txtMapX.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMapX.Name = "txtMapX"
        Me.txtMapX.Size = New System.Drawing.Size(299, 22)
        Me.txtMapX.TabIndex = 37
        Me.txtMapX.Text = "50"
        '
        'txtMapY
        '
        Me.txtMapY.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtMapY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMapY.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtMapY.Location = New System.Drawing.Point(194, 130)
        Me.txtMapY.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMapY.Name = "txtMapY"
        Me.txtMapY.Size = New System.Drawing.Size(299, 22)
        Me.txtMapY.TabIndex = 38
        Me.txtMapY.Text = "50"
        '
        'txtSandBorder
        '
        Me.txtSandBorder.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtSandBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSandBorder.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtSandBorder.Location = New System.Drawing.Point(194, 162)
        Me.txtSandBorder.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSandBorder.Name = "txtSandBorder"
        Me.txtSandBorder.Size = New System.Drawing.Size(299, 22)
        Me.txtSandBorder.TabIndex = 39
        Me.txtSandBorder.Text = "4"
        '
        'txtDetail
        '
        Me.txtDetail.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDetail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtDetail.Location = New System.Drawing.Point(194, 194)
        Me.txtDetail.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDetail.Name = "txtDetail"
        Me.txtDetail.Size = New System.Drawing.Size(299, 22)
        Me.txtDetail.TabIndex = 40
        Me.txtDetail.Text = "10"
        '
        'txtResourceFreq
        '
        Me.txtResourceFreq.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtResourceFreq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResourceFreq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtResourceFreq.Location = New System.Drawing.Point(194, 226)
        Me.txtResourceFreq.Margin = New System.Windows.Forms.Padding(4)
        Me.txtResourceFreq.Name = "txtResourceFreq"
        Me.txtResourceFreq.Size = New System.Drawing.Size(299, 22)
        Me.txtResourceFreq.TabIndex = 41
        Me.txtResourceFreq.Text = "20"
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.SystemColors.Control
        Me.btnStart.Location = New System.Drawing.Point(21, 286)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(4)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnStart.Size = New System.Drawing.Size(472, 41)
        Me.btnStart.TabIndex = 42
        Me.btnStart.Text = "Criar Mundo"
        Me.btnStart.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.Location = New System.Drawing.Point(19, 335)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnClose.Size = New System.Drawing.Size(472, 41)
        Me.btnClose.TabIndex = 44
        Me.btnClose.Text = "Cancelar"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'frmEditor_AutoMapper
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1584, 796)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlResources)
        Me.Controls.Add(Me.pnlTileConfig)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.txtResourceFreq)
        Me.Controls.Add(Me.txtDetail)
        Me.Controls.Add(Me.txtSandBorder)
        Me.Controls.Add(Me.txtMapY)
        Me.Controls.Add(Me.txtMapX)
        Me.Controls.Add(Me.txtMapSize)
        Me.Controls.Add(Me.txtMapStart)
        Me.Controls.Add(Me.DarkLabel7)
        Me.Controls.Add(Me.DarkLabel6)
        Me.Controls.Add(Me.DarkLabel5)
        Me.Controls.Add(Me.DarkLabel4)
        Me.Controls.Add(Me.DarkLabel3)
        Me.Controls.Add(Me.DarkLabel2)
        Me.Controls.Add(Me.DarkLabel1)
        Me.Controls.Add(Me.DarkMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmEditor_AutoMapper"
        Me.Text = "Gerador Procedural de Mapas"
        Me.pnlResources.ResumeLayout(False)
        Me.pnlResources.PerformLayout()
        Me.pnlTileConfig.ResumeLayout(False)
        Me.pnlTileConfig.PerformLayout()
        Me.tbControl.ResumeLayout(False)
        Me.tbTilesets.ResumeLayout(False)
        Me.tbTilesets.PerformLayout()
        Me.tbDetails.ResumeLayout(False)
        Me.frmTileset.ResumeLayout(False)
        Me.frmTileset.PerformLayout()
        CType(Me.picBackSelect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DarkMenu.ResumeLayout(False)
        Me.DarkMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlResources As Windows.Forms.Panel
    Friend WithEvents lstResources As Windows.Forms.ListBox
    Friend WithEvents pnlTileConfig As Windows.Forms.Panel
    Friend WithEvents frmTileset As Windows.Forms.GroupBox
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents DarkMenu As MenuStrip
    Friend WithEvents ConfigurationsToolStripMenuItem2 As Windows.Forms.ToolStripMenuItem
    Friend WithEvents TilesetsToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResourcesToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateToolStripMenuItem1 As Windows.Forms.ToolStripMenuItem
    Friend WithEvents PathsToolStripMenuItem1 As Windows.Forms.ToolStripMenuItem
    Friend WithEvents RiversToolStripMenuItem1 As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MountainsToolStripMenuItem1 As Windows.Forms.ToolStripMenuItem
    Friend WithEvents OverGrassToolStripMenuItem1 As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResourcesToolStripMenuItem3 As Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetailsToolStripMenuItem1 As Windows.Forms.ToolStripMenuItem
    Friend WithEvents DarkLabel1 As Label
    Friend WithEvents DarkLabel2 As Label
    Friend WithEvents DarkLabel3 As Label
    Friend WithEvents DarkLabel4 As Label
    Friend WithEvents DarkLabel5 As Label
    Friend WithEvents DarkLabel6 As Label
    Friend WithEvents DarkLabel7 As Label
    Friend WithEvents txtMapStart As TextBox
    Friend WithEvents txtMapSize As TextBox
    Friend WithEvents txtMapX As TextBox
    Friend WithEvents txtMapY As TextBox
    Friend WithEvents txtSandBorder As TextBox
    Friend WithEvents txtDetail As TextBox
    Friend WithEvents txtResourceFreq As TextBox
    Friend WithEvents btnStart As Button
    Friend WithEvents DarkLabel8 As Label
    Friend WithEvents btnCloseResource As Button
    Friend WithEvents btnSaveResource As Button
    Friend WithEvents btnUpdateResource As Button
    Friend WithEvents btnRemoveResource As Button
    Friend WithEvents btnAddResource As Button
    Friend WithEvents cmbPrefab As ComboBox
    Friend WithEvents DarkLabel9 As Label
    Friend WithEvents btnTileSetClose As Button
    Friend WithEvents btnTileSetSave As Button
    Friend WithEvents cmbTileset As ComboBox
    Public WithEvents picBackSelect As PictureBox
    Friend WithEvents scrlPictureX As HScrollBar
    Friend WithEvents scrlPictureY As VScrollBar
    Friend WithEvents btnClose As Button
    Friend WithEvents tbControl As TabControl
    Friend WithEvents tbTilesets As TabPage
    Friend WithEvents chkBlocked As CheckBox
    Friend WithEvents cmbAutotile As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents DarkLabel10 As Label
    Friend WithEvents cmbLayer As ComboBox
    Friend WithEvents tbDetails As TabPage
    Friend WithEvents btnAddDetail As Button
    Friend WithEvents lstDetails As ListBox
    Friend WithEvents btnDeleteDetail As Button
    Friend WithEvents cmbResources As ComboBox
End Class
