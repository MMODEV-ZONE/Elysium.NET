﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEditor_MapEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEditor_MapEditor))
        Me.scrlPictureX = New System.Windows.Forms.HScrollBar()
        Me.scrlPictureY = New System.Windows.Forms.VScrollBar()
        Me.optHouse = New System.Windows.Forms.RadioButton()
        Me.btnClearAttribute = New System.Windows.Forms.Button()
        Me.optTrap = New System.Windows.Forms.RadioButton()
        Me.optHeal = New System.Windows.Forms.RadioButton()
        Me.optBank = New System.Windows.Forms.RadioButton()
        Me.optShop = New System.Windows.Forms.RadioButton()
        Me.optNPCSpawn = New System.Windows.Forms.RadioButton()
        Me.optDoor = New System.Windows.Forms.RadioButton()
        Me.optResource = New System.Windows.Forms.RadioButton()
        Me.optKeyOpen = New System.Windows.Forms.RadioButton()
        Me.optKey = New System.Windows.Forms.RadioButton()
        Me.optNPCAvoid = New System.Windows.Forms.RadioButton()
        Me.optItem = New System.Windows.Forms.RadioButton()
        Me.optWarp = New System.Windows.Forms.RadioButton()
        Me.optBlocked = New System.Windows.Forms.RadioButton()
        Me.pnlBack = New System.Windows.Forms.Panel()
        Me.picBackSelect = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlAttributes = New System.Windows.Forms.Panel()
        Me.fraMapWarp = New System.Windows.Forms.GroupBox()
        Me.btnMapWarp = New System.Windows.Forms.Button()
        Me.scrlMapWarpY = New System.Windows.Forms.HScrollBar()
        Me.scrlMapWarpX = New System.Windows.Forms.HScrollBar()
        Me.scrlMapWarpMap = New System.Windows.Forms.HScrollBar()
        Me.lblMapWarpY = New System.Windows.Forms.Label()
        Me.lblMapWarpX = New System.Windows.Forms.Label()
        Me.lblMapWarpMap = New System.Windows.Forms.Label()
        Me.fraBuyHouse = New System.Windows.Forms.GroupBox()
        Me.btnHouseTileOk = New System.Windows.Forms.Button()
        Me.scrlBuyHouse = New System.Windows.Forms.HScrollBar()
        Me.lblHouseName = New System.Windows.Forms.Label()
        Me.fraKeyOpen = New System.Windows.Forms.GroupBox()
        Me.scrlKeyY = New System.Windows.Forms.HScrollBar()
        Me.lblKeyY = New System.Windows.Forms.Label()
        Me.btnMapKeyOpen = New System.Windows.Forms.Button()
        Me.scrlKeyX = New System.Windows.Forms.HScrollBar()
        Me.lblKeyX = New System.Windows.Forms.Label()
        Me.fraMapKey = New System.Windows.Forms.GroupBox()
        Me.chkMapKey = New System.Windows.Forms.CheckBox()
        Me.picMapKey = New System.Windows.Forms.PictureBox()
        Me.btnMapKey = New System.Windows.Forms.Button()
        Me.scrlMapKey = New System.Windows.Forms.HScrollBar()
        Me.lblMapKey = New System.Windows.Forms.Label()
        Me.fraNpcSpawn = New System.Windows.Forms.GroupBox()
        Me.lstNpc = New System.Windows.Forms.ComboBox()
        Me.btnNpcSpawn = New System.Windows.Forms.Button()
        Me.scrlNpcDir = New System.Windows.Forms.HScrollBar()
        Me.lblNpcDir = New System.Windows.Forms.Label()
        Me.fraHeal = New System.Windows.Forms.GroupBox()
        Me.scrlHeal = New System.Windows.Forms.HScrollBar()
        Me.lblHeal = New System.Windows.Forms.Label()
        Me.cmbHeal = New System.Windows.Forms.ComboBox()
        Me.btnHeal = New System.Windows.Forms.Button()
        Me.fraShop = New System.Windows.Forms.GroupBox()
        Me.cmbShop = New System.Windows.Forms.ComboBox()
        Me.btnShop = New System.Windows.Forms.Button()
        Me.fraResource = New System.Windows.Forms.GroupBox()
        Me.btnResourceOk = New System.Windows.Forms.Button()
        Me.scrlResource = New System.Windows.Forms.HScrollBar()
        Me.lblResource = New System.Windows.Forms.Label()
        Me.fraMapItem = New System.Windows.Forms.GroupBox()
        Me.picMapItem = New System.Windows.Forms.PictureBox()
        Me.btnMapItem = New System.Windows.Forms.Button()
        Me.scrlMapItemValue = New System.Windows.Forms.HScrollBar()
        Me.scrlMapItem = New System.Windows.Forms.HScrollBar()
        Me.lblMapItem = New System.Windows.Forms.Label()
        Me.fraTrap = New System.Windows.Forms.GroupBox()
        Me.btnTrap = New System.Windows.Forms.Button()
        Me.scrlTrap = New System.Windows.Forms.HScrollBar()
        Me.lblTrap = New System.Windows.Forms.Label()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbDiscard = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbMapGrid = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbFill = New System.Windows.Forms.ToolStripButton()
        Me.tsbClear = New System.Windows.Forms.ToolStripButton()
        Me.tabpages = New System.Windows.Forms.TabControl()
        Me.tpTiles = New System.Windows.Forms.TabPage()
        Me.cmbAutoTile = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbLayers = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbTileSets = New System.Windows.Forms.ComboBox()
        Me.tpAttributes = New System.Windows.Forms.TabPage()
        Me.optLight = New System.Windows.Forms.RadioButton()
        Me.optCraft = New System.Windows.Forms.RadioButton()
        Me.tpNpcs = New System.Windows.Forms.TabPage()
        Me.fraNpcs = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbNpcList = New System.Windows.Forms.ComboBox()
        Me.lstMapNpc = New System.Windows.Forms.ListBox()
        Me.ComboBox23 = New System.Windows.Forms.ComboBox()
        Me.tpSettings = New System.Windows.Forms.TabPage()
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.fraMapSettings = New System.Windows.Forms.GroupBox()
        Me.chkInstance = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbMoral = New System.Windows.Forms.ComboBox()
        Me.fraMapLinks = New System.Windows.Forms.GroupBox()
        Me.txtDown = New System.Windows.Forms.TextBox()
        Me.txtLeft = New System.Windows.Forms.TextBox()
        Me.lblMap = New System.Windows.Forms.Label()
        Me.txtRight = New System.Windows.Forms.TextBox()
        Me.txtUp = New System.Windows.Forms.TextBox()
        Me.fraBootSettings = New System.Windows.Forms.GroupBox()
        Me.txtBootMap = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBootY = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBootX = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.fraMaxSizes = New System.Windows.Forms.GroupBox()
        Me.txtMaxY = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMaxX = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.lstMusic = New System.Windows.Forms.ListBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tpDirBlock = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tpEvents = New System.Windows.Forms.TabPage()
        Me.lblPasteMode = New System.Windows.Forms.Label()
        Me.lblCopyMode = New System.Windows.Forms.Label()
        Me.btnPasteEvent = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnCopyEvent = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmbParallax = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbPanorama = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkUseTint = New System.Windows.Forms.CheckBox()
        Me.lblMapAlpha = New System.Windows.Forms.Label()
        Me.lblMapBlue = New System.Windows.Forms.Label()
        Me.lblMapGreen = New System.Windows.Forms.Label()
        Me.lblMapRed = New System.Windows.Forms.Label()
        Me.scrlMapAlpha = New System.Windows.Forms.HScrollBar()
        Me.scrlMapBlue = New System.Windows.Forms.HScrollBar()
        Me.scrlMapGreen = New System.Windows.Forms.HScrollBar()
        Me.scrlMapRed = New System.Windows.Forms.HScrollBar()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.scrlFogAlpha = New System.Windows.Forms.HScrollBar()
        Me.lblFogAlpha = New System.Windows.Forms.Label()
        Me.scrlFogSpeed = New System.Windows.Forms.HScrollBar()
        Me.lblFogSpeed = New System.Windows.Forms.Label()
        Me.scrlIntensity = New System.Windows.Forms.HScrollBar()
        Me.lblIntensity = New System.Windows.Forms.Label()
        Me.scrlFog = New System.Windows.Forms.HScrollBar()
        Me.lblFogIndex = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbWeather = New System.Windows.Forms.ComboBox()
        Me.pnlBack.SuspendLayout()
        CType(Me.picBackSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAttributes.SuspendLayout()
        Me.fraMapWarp.SuspendLayout()
        Me.fraBuyHouse.SuspendLayout()
        Me.fraKeyOpen.SuspendLayout()
        Me.fraMapKey.SuspendLayout()
        CType(Me.picMapKey, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraNpcSpawn.SuspendLayout()
        Me.fraHeal.SuspendLayout()
        Me.fraShop.SuspendLayout()
        Me.fraResource.SuspendLayout()
        Me.fraMapItem.SuspendLayout()
        CType(Me.picMapItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraTrap.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.tabpages.SuspendLayout()
        Me.tpTiles.SuspendLayout()
        Me.tpAttributes.SuspendLayout()
        Me.tpNpcs.SuspendLayout()
        Me.fraNpcs.SuspendLayout()
        Me.tpSettings.SuspendLayout()
        Me.fraMapSettings.SuspendLayout()
        Me.fraMapLinks.SuspendLayout()
        Me.fraBootSettings.SuspendLayout()
        Me.fraMaxSizes.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tpDirBlock.SuspendLayout()
        Me.tpEvents.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'scrlPictureX
        '
        Me.scrlPictureX.LargeChange = 1
        Me.scrlPictureX.Location = New System.Drawing.Point(4, 628)
        Me.scrlPictureX.Name = "scrlPictureX"
        Me.scrlPictureX.Size = New System.Drawing.Size(694, 16)
        Me.scrlPictureX.TabIndex = 1
        '
        'scrlPictureY
        '
        Me.scrlPictureY.LargeChange = 1
        Me.scrlPictureY.Location = New System.Drawing.Point(704, 14)
        Me.scrlPictureY.Name = "scrlPictureY"
        Me.scrlPictureY.Size = New System.Drawing.Size(16, 609)
        Me.scrlPictureY.TabIndex = 2
        '
        'optHouse
        '
        Me.optHouse.AutoSize = True
        Me.optHouse.Location = New System.Drawing.Point(480, 75)
        Me.optHouse.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optHouse.Name = "optHouse"
        Me.optHouse.Size = New System.Drawing.Size(156, 24)
        Me.optHouse.TabIndex = 15
        Me.optHouse.TabStop = True
        Me.optHouse.Text = "Comprar Moradia"
        Me.optHouse.UseVisualStyleBackColor = True
        '
        'btnClearAttribute
        '
        Me.btnClearAttribute.Location = New System.Drawing.Point(480, 672)
        Me.btnClearAttribute.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClearAttribute.Name = "btnClearAttribute"
        Me.btnClearAttribute.Size = New System.Drawing.Size(248, 38)
        Me.btnClearAttribute.TabIndex = 14
        Me.btnClearAttribute.Text = "Clear All Attributes"
        Me.btnClearAttribute.UseVisualStyleBackColor = True
        '
        'optTrap
        '
        Me.optTrap.AutoSize = True
        Me.optTrap.Location = New System.Drawing.Point(152, 131)
        Me.optTrap.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optTrap.Name = "optTrap"
        Me.optTrap.Size = New System.Drawing.Size(105, 24)
        Me.optTrap.TabIndex = 12
        Me.optTrap.TabStop = True
        Me.optTrap.Text = "Armadilha"
        Me.optTrap.UseVisualStyleBackColor = True
        '
        'optHeal
        '
        Me.optHeal.AutoSize = True
        Me.optHeal.Location = New System.Drawing.Point(15, 131)
        Me.optHeal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optHeal.Name = "optHeal"
        Me.optHeal.Size = New System.Drawing.Size(68, 24)
        Me.optHeal.TabIndex = 11
        Me.optHeal.TabStop = True
        Me.optHeal.Text = "Cura"
        Me.optHeal.UseVisualStyleBackColor = True
        '
        'optBank
        '
        Me.optBank.AutoSize = True
        Me.optBank.Location = New System.Drawing.Point(644, 75)
        Me.optBank.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optBank.Name = "optBank"
        Me.optBank.Size = New System.Drawing.Size(80, 24)
        Me.optBank.TabIndex = 10
        Me.optBank.TabStop = True
        Me.optBank.Text = "Banco"
        Me.optBank.UseVisualStyleBackColor = True
        '
        'optShop
        '
        Me.optShop.AutoSize = True
        Me.optShop.Location = New System.Drawing.Point(614, 22)
        Me.optShop.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optShop.Name = "optShop"
        Me.optShop.Size = New System.Drawing.Size(64, 24)
        Me.optShop.TabIndex = 9
        Me.optShop.TabStop = True
        Me.optShop.Text = "Loja"
        Me.optShop.UseVisualStyleBackColor = True
        '
        'optNPCSpawn
        '
        Me.optNPCSpawn.AutoSize = True
        Me.optNPCSpawn.Location = New System.Drawing.Point(480, 22)
        Me.optNPCSpawn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optNPCSpawn.Name = "optNPCSpawn"
        Me.optNPCSpawn.Size = New System.Drawing.Size(111, 24)
        Me.optNPCSpawn.TabIndex = 8
        Me.optNPCSpawn.TabStop = True
        Me.optNPCSpawn.Text = "Gerar NPC"
        Me.optNPCSpawn.UseVisualStyleBackColor = True
        '
        'optDoor
        '
        Me.optDoor.AutoSize = True
        Me.optDoor.Location = New System.Drawing.Point(152, 78)
        Me.optDoor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optDoor.Name = "optDoor"
        Me.optDoor.Size = New System.Drawing.Size(72, 24)
        Me.optDoor.TabIndex = 7
        Me.optDoor.TabStop = True
        Me.optDoor.Text = "Porta"
        Me.optDoor.UseVisualStyleBackColor = True
        '
        'optResource
        '
        Me.optResource.AutoSize = True
        Me.optResource.Location = New System.Drawing.Point(15, 78)
        Me.optResource.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optResource.Name = "optResource"
        Me.optResource.Size = New System.Drawing.Size(94, 24)
        Me.optResource.TabIndex = 6
        Me.optResource.TabStop = True
        Me.optResource.Text = "Recurso"
        Me.optResource.UseVisualStyleBackColor = True
        '
        'optKeyOpen
        '
        Me.optKeyOpen.AutoSize = True
        Me.optKeyOpen.Location = New System.Drawing.Point(356, 78)
        Me.optKeyOpen.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optKeyOpen.Name = "optKeyOpen"
        Me.optKeyOpen.Size = New System.Drawing.Size(116, 24)
        Me.optKeyOpen.TabIndex = 5
        Me.optKeyOpen.TabStop = True
        Me.optKeyOpen.Text = "Chave Abrir"
        Me.optKeyOpen.UseVisualStyleBackColor = True
        '
        'optKey
        '
        Me.optKey.AutoSize = True
        Me.optKey.Location = New System.Drawing.Point(260, 78)
        Me.optKey.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optKey.Name = "optKey"
        Me.optKey.Size = New System.Drawing.Size(79, 24)
        Me.optKey.TabIndex = 4
        Me.optKey.TabStop = True
        Me.optKey.Text = "Chave"
        Me.optKey.UseVisualStyleBackColor = True
        '
        'optNPCAvoid
        '
        Me.optNPCAvoid.AutoSize = True
        Me.optNPCAvoid.Location = New System.Drawing.Point(356, 22)
        Me.optNPCAvoid.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optNPCAvoid.Name = "optNPCAvoid"
        Me.optNPCAvoid.Size = New System.Drawing.Size(110, 24)
        Me.optNPCAvoid.TabIndex = 3
        Me.optNPCAvoid.TabStop = True
        Me.optNPCAvoid.Text = "Evitar NPC"
        Me.optNPCAvoid.UseVisualStyleBackColor = True
        '
        'optItem
        '
        Me.optItem.AutoSize = True
        Me.optItem.Location = New System.Drawing.Point(260, 22)
        Me.optItem.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optItem.Name = "optItem"
        Me.optItem.Size = New System.Drawing.Size(66, 24)
        Me.optItem.TabIndex = 2
        Me.optItem.TabStop = True
        Me.optItem.Text = "Item"
        Me.optItem.UseVisualStyleBackColor = True
        '
        'optWarp
        '
        Me.optWarp.AutoSize = True
        Me.optWarp.Location = New System.Drawing.Point(152, 22)
        Me.optWarp.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optWarp.Name = "optWarp"
        Me.optWarp.Size = New System.Drawing.Size(101, 24)
        Me.optWarp.TabIndex = 1
        Me.optWarp.TabStop = True
        Me.optWarp.Text = "Teleporte"
        Me.optWarp.UseVisualStyleBackColor = True
        '
        'optBlocked
        '
        Me.optBlocked.AutoSize = True
        Me.optBlocked.Location = New System.Drawing.Point(15, 22)
        Me.optBlocked.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optBlocked.Name = "optBlocked"
        Me.optBlocked.Size = New System.Drawing.Size(111, 24)
        Me.optBlocked.TabIndex = 0
        Me.optBlocked.TabStop = True
        Me.optBlocked.Text = "Bloqueado"
        Me.optBlocked.UseVisualStyleBackColor = True
        '
        'pnlBack
        '
        Me.pnlBack.Controls.Add(Me.picBackSelect)
        Me.pnlBack.Location = New System.Drawing.Point(9, 12)
        Me.pnlBack.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlBack.Name = "pnlBack"
        Me.pnlBack.Size = New System.Drawing.Size(690, 611)
        Me.pnlBack.TabIndex = 9
        '
        'picBackSelect
        '
        Me.picBackSelect.BackColor = System.Drawing.Color.Black
        Me.picBackSelect.Location = New System.Drawing.Point(0, 0)
        Me.picBackSelect.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.picBackSelect.Name = "picBackSelect"
        Me.picBackSelect.Size = New System.Drawing.Size(690, 611)
        Me.picBackSelect.TabIndex = 1
        Me.picBackSelect.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(117, 651)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(343, 20)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Arraste o Mouse para Selecionar Múltiplas Tiles"
        '
        'pnlAttributes
        '
        Me.pnlAttributes.Controls.Add(Me.fraMapWarp)
        Me.pnlAttributes.Controls.Add(Me.fraBuyHouse)
        Me.pnlAttributes.Controls.Add(Me.fraKeyOpen)
        Me.pnlAttributes.Controls.Add(Me.fraMapKey)
        Me.pnlAttributes.Controls.Add(Me.fraNpcSpawn)
        Me.pnlAttributes.Controls.Add(Me.fraHeal)
        Me.pnlAttributes.Controls.Add(Me.fraShop)
        Me.pnlAttributes.Controls.Add(Me.fraResource)
        Me.pnlAttributes.Controls.Add(Me.fraMapItem)
        Me.pnlAttributes.Controls.Add(Me.fraTrap)
        Me.pnlAttributes.Location = New System.Drawing.Point(758, 48)
        Me.pnlAttributes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlAttributes.Name = "pnlAttributes"
        Me.pnlAttributes.Size = New System.Drawing.Size(753, 755)
        Me.pnlAttributes.TabIndex = 12
        Me.pnlAttributes.Visible = False
        '
        'fraMapWarp
        '
        Me.fraMapWarp.Controls.Add(Me.btnMapWarp)
        Me.fraMapWarp.Controls.Add(Me.scrlMapWarpY)
        Me.fraMapWarp.Controls.Add(Me.scrlMapWarpX)
        Me.fraMapWarp.Controls.Add(Me.scrlMapWarpMap)
        Me.fraMapWarp.Controls.Add(Me.lblMapWarpY)
        Me.fraMapWarp.Controls.Add(Me.lblMapWarpX)
        Me.fraMapWarp.Controls.Add(Me.lblMapWarpMap)
        Me.fraMapWarp.Location = New System.Drawing.Point(14, 569)
        Me.fraMapWarp.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraMapWarp.Name = "fraMapWarp"
        Me.fraMapWarp.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraMapWarp.Size = New System.Drawing.Size(378, 182)
        Me.fraMapWarp.TabIndex = 0
        Me.fraMapWarp.TabStop = False
        Me.fraMapWarp.Text = "Teleporte de Mapa"
        '
        'btnMapWarp
        '
        Me.btnMapWarp.Location = New System.Drawing.Point(120, 135)
        Me.btnMapWarp.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnMapWarp.Name = "btnMapWarp"
        Me.btnMapWarp.Size = New System.Drawing.Size(135, 42)
        Me.btnMapWarp.TabIndex = 6
        Me.btnMapWarp.Text = "Aceitar"
        Me.btnMapWarp.UseVisualStyleBackColor = True
        '
        'scrlMapWarpY
        '
        Me.scrlMapWarpY.Location = New System.Drawing.Point(93, 98)
        Me.scrlMapWarpY.Name = "scrlMapWarpY"
        Me.scrlMapWarpY.Size = New System.Drawing.Size(242, 18)
        Me.scrlMapWarpY.TabIndex = 5
        '
        'scrlMapWarpX
        '
        Me.scrlMapWarpX.Location = New System.Drawing.Point(93, 62)
        Me.scrlMapWarpX.Name = "scrlMapWarpX"
        Me.scrlMapWarpX.Size = New System.Drawing.Size(242, 18)
        Me.scrlMapWarpX.TabIndex = 4
        '
        'scrlMapWarpMap
        '
        Me.scrlMapWarpMap.Location = New System.Drawing.Point(93, 31)
        Me.scrlMapWarpMap.Name = "scrlMapWarpMap"
        Me.scrlMapWarpMap.Size = New System.Drawing.Size(242, 18)
        Me.scrlMapWarpMap.TabIndex = 3
        '
        'lblMapWarpY
        '
        Me.lblMapWarpY.AutoSize = True
        Me.lblMapWarpY.Location = New System.Drawing.Point(10, 102)
        Me.lblMapWarpY.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMapWarpY.Name = "lblMapWarpY"
        Me.lblMapWarpY.Size = New System.Drawing.Size(37, 20)
        Me.lblMapWarpY.TabIndex = 2
        Me.lblMapWarpY.Text = "Y: 1"
        '
        'lblMapWarpX
        '
        Me.lblMapWarpX.AutoSize = True
        Me.lblMapWarpX.Location = New System.Drawing.Point(10, 71)
        Me.lblMapWarpX.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMapWarpX.Name = "lblMapWarpX"
        Me.lblMapWarpX.Size = New System.Drawing.Size(37, 20)
        Me.lblMapWarpX.TabIndex = 1
        Me.lblMapWarpX.Text = "X: 1"
        '
        'lblMapWarpMap
        '
        Me.lblMapWarpMap.AutoSize = True
        Me.lblMapWarpMap.Location = New System.Drawing.Point(9, 38)
        Me.lblMapWarpMap.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMapWarpMap.Name = "lblMapWarpMap"
        Me.lblMapWarpMap.Size = New System.Drawing.Size(66, 20)
        Me.lblMapWarpMap.TabIndex = 0
        Me.lblMapWarpMap.Text = "Mapa: 1"
        '
        'fraBuyHouse
        '
        Me.fraBuyHouse.Controls.Add(Me.btnHouseTileOk)
        Me.fraBuyHouse.Controls.Add(Me.scrlBuyHouse)
        Me.fraBuyHouse.Controls.Add(Me.lblHouseName)
        Me.fraBuyHouse.Location = New System.Drawing.Point(504, 9)
        Me.fraBuyHouse.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraBuyHouse.Name = "fraBuyHouse"
        Me.fraBuyHouse.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraBuyHouse.Size = New System.Drawing.Size(246, 174)
        Me.fraBuyHouse.TabIndex = 17
        Me.fraBuyHouse.TabStop = False
        Me.fraBuyHouse.Text = "Comprar Moradia"
        '
        'btnHouseTileOk
        '
        Me.btnHouseTileOk.Location = New System.Drawing.Point(58, 118)
        Me.btnHouseTileOk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnHouseTileOk.Name = "btnHouseTileOk"
        Me.btnHouseTileOk.Size = New System.Drawing.Size(135, 42)
        Me.btnHouseTileOk.TabIndex = 6
        Me.btnHouseTileOk.Text = "Aceitar"
        Me.btnHouseTileOk.UseVisualStyleBackColor = True
        '
        'scrlBuyHouse
        '
        Me.scrlBuyHouse.LargeChange = 1
        Me.scrlBuyHouse.Location = New System.Drawing.Point(14, 58)
        Me.scrlBuyHouse.Name = "scrlBuyHouse"
        Me.scrlBuyHouse.Size = New System.Drawing.Size(213, 18)
        Me.scrlBuyHouse.TabIndex = 3
        '
        'lblHouseName
        '
        Me.lblHouseName.AutoSize = True
        Me.lblHouseName.Location = New System.Drawing.Point(9, 26)
        Me.lblHouseName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHouseName.Name = "lblHouseName"
        Me.lblHouseName.Size = New System.Drawing.Size(70, 20)
        Me.lblHouseName.TabIndex = 0
        Me.lblHouseName.Text = "Moradia:"
        '
        'fraKeyOpen
        '
        Me.fraKeyOpen.Controls.Add(Me.scrlKeyY)
        Me.fraKeyOpen.Controls.Add(Me.lblKeyY)
        Me.fraKeyOpen.Controls.Add(Me.btnMapKeyOpen)
        Me.fraKeyOpen.Controls.Add(Me.scrlKeyX)
        Me.fraKeyOpen.Controls.Add(Me.lblKeyX)
        Me.fraKeyOpen.Location = New System.Drawing.Point(398, 569)
        Me.fraKeyOpen.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraKeyOpen.Name = "fraKeyOpen"
        Me.fraKeyOpen.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraKeyOpen.Size = New System.Drawing.Size(300, 180)
        Me.fraKeyOpen.TabIndex = 9
        Me.fraKeyOpen.TabStop = False
        Me.fraKeyOpen.Text = "Uso da Chave de Mapa"
        '
        'scrlKeyY
        '
        Me.scrlKeyY.Location = New System.Drawing.Point(94, 69)
        Me.scrlKeyY.Name = "scrlKeyY"
        Me.scrlKeyY.Size = New System.Drawing.Size(190, 18)
        Me.scrlKeyY.TabIndex = 8
        '
        'lblKeyY
        '
        Me.lblKeyY.AutoSize = True
        Me.lblKeyY.Location = New System.Drawing.Point(9, 72)
        Me.lblKeyY.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKeyY.Name = "lblKeyY"
        Me.lblKeyY.Size = New System.Drawing.Size(37, 20)
        Me.lblKeyY.TabIndex = 7
        Me.lblKeyY.Text = "Y: 0"
        '
        'btnMapKeyOpen
        '
        Me.btnMapKeyOpen.Location = New System.Drawing.Point(76, 118)
        Me.btnMapKeyOpen.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnMapKeyOpen.Name = "btnMapKeyOpen"
        Me.btnMapKeyOpen.Size = New System.Drawing.Size(135, 42)
        Me.btnMapKeyOpen.TabIndex = 6
        Me.btnMapKeyOpen.Text = "Aceitar"
        Me.btnMapKeyOpen.UseVisualStyleBackColor = True
        '
        'scrlKeyX
        '
        Me.scrlKeyX.Location = New System.Drawing.Point(94, 26)
        Me.scrlKeyX.Name = "scrlKeyX"
        Me.scrlKeyX.Size = New System.Drawing.Size(190, 18)
        Me.scrlKeyX.TabIndex = 3
        '
        'lblKeyX
        '
        Me.lblKeyX.AutoSize = True
        Me.lblKeyX.Location = New System.Drawing.Point(9, 34)
        Me.lblKeyX.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKeyX.Name = "lblKeyX"
        Me.lblKeyX.Size = New System.Drawing.Size(37, 20)
        Me.lblKeyX.TabIndex = 0
        Me.lblKeyX.Text = "X: 0"
        '
        'fraMapKey
        '
        Me.fraMapKey.Controls.Add(Me.chkMapKey)
        Me.fraMapKey.Controls.Add(Me.picMapKey)
        Me.fraMapKey.Controls.Add(Me.btnMapKey)
        Me.fraMapKey.Controls.Add(Me.scrlMapKey)
        Me.fraMapKey.Controls.Add(Me.lblMapKey)
        Me.fraMapKey.Location = New System.Drawing.Point(274, 386)
        Me.fraMapKey.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraMapKey.Name = "fraMapKey"
        Me.fraMapKey.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraMapKey.Size = New System.Drawing.Size(249, 174)
        Me.fraMapKey.TabIndex = 8
        Me.fraMapKey.TabStop = False
        Me.fraMapKey.Text = "Chave de Mapa"
        '
        'chkMapKey
        '
        Me.chkMapKey.AutoSize = True
        Me.chkMapKey.Checked = True
        Me.chkMapKey.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMapKey.Location = New System.Drawing.Point(14, 89)
        Me.chkMapKey.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkMapKey.Name = "chkMapKey"
        Me.chkMapKey.Size = New System.Drawing.Size(203, 24)
        Me.chkMapKey.TabIndex = 8
        Me.chkMapKey.Text = "Tomar Chave Após Uso"
        Me.chkMapKey.UseVisualStyleBackColor = True
        '
        'picMapKey
        '
        Me.picMapKey.BackColor = System.Drawing.Color.Black
        Me.picMapKey.Location = New System.Drawing.Point(26, 118)
        Me.picMapKey.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.picMapKey.Name = "picMapKey"
        Me.picMapKey.Size = New System.Drawing.Size(48, 49)
        Me.picMapKey.TabIndex = 7
        Me.picMapKey.TabStop = False
        '
        'btnMapKey
        '
        Me.btnMapKey.Location = New System.Drawing.Point(82, 122)
        Me.btnMapKey.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnMapKey.Name = "btnMapKey"
        Me.btnMapKey.Size = New System.Drawing.Size(135, 42)
        Me.btnMapKey.TabIndex = 6
        Me.btnMapKey.Text = "Aceitar"
        Me.btnMapKey.UseVisualStyleBackColor = True
        '
        'scrlMapKey
        '
        Me.scrlMapKey.Location = New System.Drawing.Point(14, 48)
        Me.scrlMapKey.Name = "scrlMapKey"
        Me.scrlMapKey.Size = New System.Drawing.Size(228, 18)
        Me.scrlMapKey.TabIndex = 3
        '
        'lblMapKey
        '
        Me.lblMapKey.AutoSize = True
        Me.lblMapKey.Location = New System.Drawing.Point(9, 25)
        Me.lblMapKey.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMapKey.Name = "lblMapKey"
        Me.lblMapKey.Size = New System.Drawing.Size(109, 20)
        Me.lblMapKey.TabIndex = 0
        Me.lblMapKey.Text = "Item: Nenhum"
        '
        'fraNpcSpawn
        '
        Me.fraNpcSpawn.Controls.Add(Me.lstNpc)
        Me.fraNpcSpawn.Controls.Add(Me.btnNpcSpawn)
        Me.fraNpcSpawn.Controls.Add(Me.scrlNpcDir)
        Me.fraNpcSpawn.Controls.Add(Me.lblNpcDir)
        Me.fraNpcSpawn.Location = New System.Drawing.Point(4, 9)
        Me.fraNpcSpawn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraNpcSpawn.Name = "fraNpcSpawn"
        Me.fraNpcSpawn.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraNpcSpawn.Size = New System.Drawing.Size(261, 174)
        Me.fraNpcSpawn.TabIndex = 11
        Me.fraNpcSpawn.TabStop = False
        Me.fraNpcSpawn.Text = "Npc Spawn"
        '
        'lstNpc
        '
        Me.lstNpc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lstNpc.FormattingEnabled = True
        Me.lstNpc.Location = New System.Drawing.Point(9, 25)
        Me.lstNpc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lstNpc.Name = "lstNpc"
        Me.lstNpc.Size = New System.Drawing.Size(230, 28)
        Me.lstNpc.TabIndex = 37
        '
        'btnNpcSpawn
        '
        Me.btnNpcSpawn.Location = New System.Drawing.Point(58, 118)
        Me.btnNpcSpawn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNpcSpawn.Name = "btnNpcSpawn"
        Me.btnNpcSpawn.Size = New System.Drawing.Size(135, 42)
        Me.btnNpcSpawn.TabIndex = 6
        Me.btnNpcSpawn.Text = "Aceitar"
        Me.btnNpcSpawn.UseVisualStyleBackColor = True
        '
        'scrlNpcDir
        '
        Me.scrlNpcDir.LargeChange = 1
        Me.scrlNpcDir.Location = New System.Drawing.Point(12, 85)
        Me.scrlNpcDir.Maximum = 3
        Me.scrlNpcDir.Name = "scrlNpcDir"
        Me.scrlNpcDir.Size = New System.Drawing.Size(230, 18)
        Me.scrlNpcDir.TabIndex = 3
        '
        'lblNpcDir
        '
        Me.lblNpcDir.AutoSize = True
        Me.lblNpcDir.Location = New System.Drawing.Point(8, 62)
        Me.lblNpcDir.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNpcDir.Name = "lblNpcDir"
        Me.lblNpcDir.Size = New System.Drawing.Size(108, 20)
        Me.lblNpcDir.TabIndex = 0
        Me.lblNpcDir.Text = "Direção: Cima"
        '
        'fraHeal
        '
        Me.fraHeal.Controls.Add(Me.scrlHeal)
        Me.fraHeal.Controls.Add(Me.lblHeal)
        Me.fraHeal.Controls.Add(Me.cmbHeal)
        Me.fraHeal.Controls.Add(Me.btnHeal)
        Me.fraHeal.Location = New System.Drawing.Point(4, 386)
        Me.fraHeal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraHeal.Name = "fraHeal"
        Me.fraHeal.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraHeal.Size = New System.Drawing.Size(261, 174)
        Me.fraHeal.TabIndex = 15
        Me.fraHeal.TabStop = False
        Me.fraHeal.Text = "Cura"
        '
        'scrlHeal
        '
        Me.scrlHeal.Location = New System.Drawing.Point(6, 86)
        Me.scrlHeal.Name = "scrlHeal"
        Me.scrlHeal.Size = New System.Drawing.Size(232, 17)
        Me.scrlHeal.TabIndex = 39
        '
        'lblHeal
        '
        Me.lblHeal.AutoSize = True
        Me.lblHeal.Location = New System.Drawing.Point(4, 66)
        Me.lblHeal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHeal.Name = "lblHeal"
        Me.lblHeal.Size = New System.Drawing.Size(109, 20)
        Me.lblHeal.TabIndex = 38
        Me.lblHeal.Text = "Quantidade: 0"
        '
        'cmbHeal
        '
        Me.cmbHeal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHeal.FormattingEnabled = True
        Me.cmbHeal.Items.AddRange(New Object() {"Heal HP", "Heal MP"})
        Me.cmbHeal.Location = New System.Drawing.Point(9, 29)
        Me.cmbHeal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbHeal.Name = "cmbHeal"
        Me.cmbHeal.Size = New System.Drawing.Size(230, 28)
        Me.cmbHeal.TabIndex = 37
        '
        'btnHeal
        '
        Me.btnHeal.Location = New System.Drawing.Point(56, 118)
        Me.btnHeal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnHeal.Name = "btnHeal"
        Me.btnHeal.Size = New System.Drawing.Size(135, 42)
        Me.btnHeal.TabIndex = 6
        Me.btnHeal.Text = "Aceitar"
        Me.btnHeal.UseVisualStyleBackColor = True
        '
        'fraShop
        '
        Me.fraShop.Controls.Add(Me.cmbShop)
        Me.fraShop.Controls.Add(Me.btnShop)
        Me.fraShop.Location = New System.Drawing.Point(504, 192)
        Me.fraShop.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraShop.Name = "fraShop"
        Me.fraShop.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraShop.Size = New System.Drawing.Size(220, 185)
        Me.fraShop.TabIndex = 12
        Me.fraShop.TabStop = False
        Me.fraShop.Text = "Loja"
        '
        'cmbShop
        '
        Me.cmbShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbShop.FormattingEnabled = True
        Me.cmbShop.Location = New System.Drawing.Point(9, 29)
        Me.cmbShop.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbShop.Name = "cmbShop"
        Me.cmbShop.Size = New System.Drawing.Size(198, 28)
        Me.cmbShop.TabIndex = 37
        '
        'btnShop
        '
        Me.btnShop.Location = New System.Drawing.Point(44, 131)
        Me.btnShop.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnShop.Name = "btnShop"
        Me.btnShop.Size = New System.Drawing.Size(135, 42)
        Me.btnShop.TabIndex = 6
        Me.btnShop.Text = "Aceitar"
        Me.btnShop.UseVisualStyleBackColor = True
        '
        'fraResource
        '
        Me.fraResource.Controls.Add(Me.btnResourceOk)
        Me.fraResource.Controls.Add(Me.scrlResource)
        Me.fraResource.Controls.Add(Me.lblResource)
        Me.fraResource.Location = New System.Drawing.Point(274, 9)
        Me.fraResource.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraResource.Name = "fraResource"
        Me.fraResource.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraResource.Size = New System.Drawing.Size(220, 174)
        Me.fraResource.TabIndex = 10
        Me.fraResource.TabStop = False
        Me.fraResource.Text = "Recurso"
        '
        'btnResourceOk
        '
        Me.btnResourceOk.Location = New System.Drawing.Point(42, 118)
        Me.btnResourceOk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnResourceOk.Name = "btnResourceOk"
        Me.btnResourceOk.Size = New System.Drawing.Size(135, 42)
        Me.btnResourceOk.TabIndex = 6
        Me.btnResourceOk.Text = "Aceitar"
        Me.btnResourceOk.UseVisualStyleBackColor = True
        '
        'scrlResource
        '
        Me.scrlResource.Location = New System.Drawing.Point(4, 55)
        Me.scrlResource.Name = "scrlResource"
        Me.scrlResource.Size = New System.Drawing.Size(204, 18)
        Me.scrlResource.TabIndex = 3
        '
        'lblResource
        '
        Me.lblResource.AutoSize = True
        Me.lblResource.Location = New System.Drawing.Point(0, 25)
        Me.lblResource.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblResource.Name = "lblResource"
        Me.lblResource.Size = New System.Drawing.Size(56, 20)
        Me.lblResource.TabIndex = 0
        Me.lblResource.Text = "Objeto"
        '
        'fraMapItem
        '
        Me.fraMapItem.Controls.Add(Me.picMapItem)
        Me.fraMapItem.Controls.Add(Me.btnMapItem)
        Me.fraMapItem.Controls.Add(Me.scrlMapItemValue)
        Me.fraMapItem.Controls.Add(Me.scrlMapItem)
        Me.fraMapItem.Controls.Add(Me.lblMapItem)
        Me.fraMapItem.Location = New System.Drawing.Point(4, 194)
        Me.fraMapItem.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraMapItem.Name = "fraMapItem"
        Me.fraMapItem.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraMapItem.Size = New System.Drawing.Size(261, 182)
        Me.fraMapItem.TabIndex = 7
        Me.fraMapItem.TabStop = False
        Me.fraMapItem.Text = "Item de Mapa"
        '
        'picMapItem
        '
        Me.picMapItem.BackColor = System.Drawing.Color.Black
        Me.picMapItem.Location = New System.Drawing.Point(200, 55)
        Me.picMapItem.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.picMapItem.Name = "picMapItem"
        Me.picMapItem.Size = New System.Drawing.Size(48, 49)
        Me.picMapItem.TabIndex = 7
        Me.picMapItem.TabStop = False
        '
        'btnMapItem
        '
        Me.btnMapItem.Location = New System.Drawing.Point(58, 129)
        Me.btnMapItem.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnMapItem.Name = "btnMapItem"
        Me.btnMapItem.Size = New System.Drawing.Size(135, 42)
        Me.btnMapItem.TabIndex = 6
        Me.btnMapItem.Text = "Aceitar"
        Me.btnMapItem.UseVisualStyleBackColor = True
        '
        'scrlMapItemValue
        '
        Me.scrlMapItemValue.Location = New System.Drawing.Point(14, 91)
        Me.scrlMapItemValue.Name = "scrlMapItemValue"
        Me.scrlMapItemValue.Size = New System.Drawing.Size(180, 18)
        Me.scrlMapItemValue.TabIndex = 4
        '
        'scrlMapItem
        '
        Me.scrlMapItem.Location = New System.Drawing.Point(14, 58)
        Me.scrlMapItem.Name = "scrlMapItem"
        Me.scrlMapItem.Size = New System.Drawing.Size(180, 18)
        Me.scrlMapItem.TabIndex = 3
        '
        'lblMapItem
        '
        Me.lblMapItem.AutoSize = True
        Me.lblMapItem.Location = New System.Drawing.Point(9, 34)
        Me.lblMapItem.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMapItem.Name = "lblMapItem"
        Me.lblMapItem.Size = New System.Drawing.Size(129, 20)
        Me.lblMapItem.TabIndex = 0
        Me.lblMapItem.Text = "Item: Nenhum x0"
        '
        'fraTrap
        '
        Me.fraTrap.Controls.Add(Me.btnTrap)
        Me.fraTrap.Controls.Add(Me.scrlTrap)
        Me.fraTrap.Controls.Add(Me.lblTrap)
        Me.fraTrap.Location = New System.Drawing.Point(274, 192)
        Me.fraTrap.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraTrap.Name = "fraTrap"
        Me.fraTrap.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraTrap.Size = New System.Drawing.Size(220, 185)
        Me.fraTrap.TabIndex = 16
        Me.fraTrap.TabStop = False
        Me.fraTrap.Text = "Armadilha"
        '
        'btnTrap
        '
        Me.btnTrap.Location = New System.Drawing.Point(42, 131)
        Me.btnTrap.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnTrap.Name = "btnTrap"
        Me.btnTrap.Size = New System.Drawing.Size(135, 42)
        Me.btnTrap.TabIndex = 42
        Me.btnTrap.Text = "Aceitar"
        Me.btnTrap.UseVisualStyleBackColor = True
        '
        'scrlTrap
        '
        Me.scrlTrap.Location = New System.Drawing.Point(16, 51)
        Me.scrlTrap.Name = "scrlTrap"
        Me.scrlTrap.Size = New System.Drawing.Size(192, 17)
        Me.scrlTrap.TabIndex = 41
        '
        'lblTrap
        '
        Me.lblTrap.AutoSize = True
        Me.lblTrap.Location = New System.Drawing.Point(9, 25)
        Me.lblTrap.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTrap.Name = "lblTrap"
        Me.lblTrap.Size = New System.Drawing.Size(109, 20)
        Me.lblTrap.TabIndex = 40
        Me.lblTrap.Text = "Quantidade: 0"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.tsbDiscard, Me.ToolStripSeparator1, Me.tsbMapGrid, Me.ToolStripSeparator2, Me.tsbFill, Me.tsbClear})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip.Size = New System.Drawing.Size(1521, 34)
        Me.ToolStrip.TabIndex = 13
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'tsbSave
        '
        Me.tsbSave.Image = Global.My.Resources.Resources.Save
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(87, 29)
        Me.tsbSave.Text = "Salvar"
        '
        'tsbDiscard
        '
        Me.tsbDiscard.Image = Global.My.Resources.Resources._Exit
        Me.tsbDiscard.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDiscard.Name = "tsbDiscard"
        Me.tsbDiscard.Size = New System.Drawing.Size(114, 29)
        Me.tsbDiscard.Text = "Descartar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 34)
        '
        'tsbMapGrid
        '
        Me.tsbMapGrid.Image = Global.My.Resources.Resources.Grid
        Me.tsbMapGrid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMapGrid.Name = "tsbMapGrid"
        Me.tsbMapGrid.Size = New System.Drawing.Size(88, 29)
        Me.tsbMapGrid.Text = "Malha"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 34)
        '
        'tsbFill
        '
        Me.tsbFill.Image = Global.My.Resources.Resources.Fill
        Me.tsbFill.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbFill.Name = "tsbFill"
        Me.tsbFill.Size = New System.Drawing.Size(187, 29)
        Me.tsbFill.Text = "Preencher Camada"
        Me.tsbFill.ToolTipText = "Fill Layer"
        '
        'tsbClear
        '
        Me.tsbClear.Image = Global.My.Resources.Resources.Clear
        Me.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClear.Name = "tsbClear"
        Me.tsbClear.Size = New System.Drawing.Size(164, 29)
        Me.tsbClear.Text = "Limpar Camada"
        '
        'tabpages
        '
        Me.tabpages.Controls.Add(Me.tpTiles)
        Me.tabpages.Controls.Add(Me.tpAttributes)
        Me.tabpages.Controls.Add(Me.tpNpcs)
        Me.tabpages.Controls.Add(Me.tpSettings)
        Me.tabpages.Controls.Add(Me.tpDirBlock)
        Me.tabpages.Controls.Add(Me.tpEvents)
        Me.tabpages.Controls.Add(Me.TabPage1)
        Me.tabpages.Location = New System.Drawing.Point(6, 42)
        Me.tabpages.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabpages.Name = "tabpages"
        Me.tabpages.SelectedIndex = 0
        Me.tabpages.Size = New System.Drawing.Size(748, 760)
        Me.tabpages.TabIndex = 14
        '
        'tpTiles
        '
        Me.tpTiles.Controls.Add(Me.cmbAutoTile)
        Me.tpTiles.Controls.Add(Me.Label11)
        Me.tpTiles.Controls.Add(Me.Label10)
        Me.tpTiles.Controls.Add(Me.cmbLayers)
        Me.tpTiles.Controls.Add(Me.Label9)
        Me.tpTiles.Controls.Add(Me.cmbTileSets)
        Me.tpTiles.Controls.Add(Me.pnlBack)
        Me.tpTiles.Controls.Add(Me.Label1)
        Me.tpTiles.Controls.Add(Me.scrlPictureX)
        Me.tpTiles.Controls.Add(Me.scrlPictureY)
        Me.tpTiles.Location = New System.Drawing.Point(4, 29)
        Me.tpTiles.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpTiles.Name = "tpTiles"
        Me.tpTiles.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpTiles.Size = New System.Drawing.Size(740, 727)
        Me.tpTiles.TabIndex = 0
        Me.tpTiles.Text = "Tiles"
        Me.tpTiles.UseVisualStyleBackColor = True
        '
        'cmbAutoTile
        '
        Me.cmbAutoTile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAutoTile.FormattingEnabled = True
        Me.cmbAutoTile.Items.AddRange(New Object() {"Normal", "AutoTile (VX)", "Fake (VX)", "Animated (VX)", "Cliff (VX)", "Waterfall (VX)"})
        Me.cmbAutoTile.Location = New System.Drawing.Point(549, 682)
        Me.cmbAutoTile.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbAutoTile.Name = "cmbAutoTile"
        Me.cmbAutoTile.Size = New System.Drawing.Size(176, 28)
        Me.cmbAutoTile.TabIndex = 17
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(466, 686)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 20)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "AutoTile:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(213, 686)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 20)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Camada:"
        '
        'cmbLayers
        '
        Me.cmbLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLayers.FormattingEnabled = True
        Me.cmbLayers.Items.AddRange(New Object() {"Ground", "Mask", "Mask 2", "Fringe", "Fringe 2"})
        Me.cmbLayers.Location = New System.Drawing.Point(276, 682)
        Me.cmbLayers.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbLayers.Name = "cmbLayers"
        Me.cmbLayers.Size = New System.Drawing.Size(180, 28)
        Me.cmbLayers.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 686)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 20)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Tileset:"
        '
        'cmbTileSets
        '
        Me.cmbTileSets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTileSets.FormattingEnabled = True
        Me.cmbTileSets.Location = New System.Drawing.Point(80, 682)
        Me.cmbTileSets.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbTileSets.Name = "cmbTileSets"
        Me.cmbTileSets.Size = New System.Drawing.Size(122, 28)
        Me.cmbTileSets.TabIndex = 12
        '
        'tpAttributes
        '
        Me.tpAttributes.Controls.Add(Me.optLight)
        Me.tpAttributes.Controls.Add(Me.optCraft)
        Me.tpAttributes.Controls.Add(Me.optHouse)
        Me.tpAttributes.Controls.Add(Me.btnClearAttribute)
        Me.tpAttributes.Controls.Add(Me.optTrap)
        Me.tpAttributes.Controls.Add(Me.optBlocked)
        Me.tpAttributes.Controls.Add(Me.optHeal)
        Me.tpAttributes.Controls.Add(Me.optWarp)
        Me.tpAttributes.Controls.Add(Me.optBank)
        Me.tpAttributes.Controls.Add(Me.optItem)
        Me.tpAttributes.Controls.Add(Me.optShop)
        Me.tpAttributes.Controls.Add(Me.optNPCAvoid)
        Me.tpAttributes.Controls.Add(Me.optNPCSpawn)
        Me.tpAttributes.Controls.Add(Me.optKey)
        Me.tpAttributes.Controls.Add(Me.optDoor)
        Me.tpAttributes.Controls.Add(Me.optKeyOpen)
        Me.tpAttributes.Controls.Add(Me.optResource)
        Me.tpAttributes.Location = New System.Drawing.Point(4, 29)
        Me.tpAttributes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpAttributes.Name = "tpAttributes"
        Me.tpAttributes.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpAttributes.Size = New System.Drawing.Size(740, 727)
        Me.tpAttributes.TabIndex = 3
        Me.tpAttributes.Text = "Atributos"
        Me.tpAttributes.UseVisualStyleBackColor = True
        '
        'optLight
        '
        Me.optLight.AutoSize = True
        Me.optLight.Location = New System.Drawing.Point(381, 131)
        Me.optLight.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optLight.Name = "optLight"
        Me.optLight.Size = New System.Drawing.Size(60, 24)
        Me.optLight.TabIndex = 18
        Me.optLight.TabStop = True
        Me.optLight.Text = "Luz"
        Me.optLight.UseVisualStyleBackColor = True
        '
        'optCraft
        '
        Me.optCraft.AutoSize = True
        Me.optCraft.Location = New System.Drawing.Point(260, 131)
        Me.optCraft.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optCraft.Name = "optCraft"
        Me.optCraft.Size = New System.Drawing.Size(113, 24)
        Me.optCraft.TabIndex = 17
        Me.optCraft.TabStop = True
        Me.optCraft.Text = "Artesanato"
        Me.optCraft.UseVisualStyleBackColor = True
        '
        'tpNpcs
        '
        Me.tpNpcs.Controls.Add(Me.fraNpcs)
        Me.tpNpcs.Location = New System.Drawing.Point(4, 29)
        Me.tpNpcs.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpNpcs.Name = "tpNpcs"
        Me.tpNpcs.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpNpcs.Size = New System.Drawing.Size(740, 727)
        Me.tpNpcs.TabIndex = 1
        Me.tpNpcs.Text = "Npcs"
        Me.tpNpcs.UseVisualStyleBackColor = True
        '
        'fraNpcs
        '
        Me.fraNpcs.Controls.Add(Me.Label18)
        Me.fraNpcs.Controls.Add(Me.Label17)
        Me.fraNpcs.Controls.Add(Me.cmbNpcList)
        Me.fraNpcs.Controls.Add(Me.lstMapNpc)
        Me.fraNpcs.Controls.Add(Me.ComboBox23)
        Me.fraNpcs.Location = New System.Drawing.Point(9, 12)
        Me.fraNpcs.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraNpcs.Name = "fraNpcs"
        Me.fraNpcs.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraNpcs.Size = New System.Drawing.Size(718, 655)
        Me.fraNpcs.TabIndex = 11
        Me.fraNpcs.TabStop = False
        Me.fraNpcs.Text = "NPCs"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(387, 45)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(221, 20)
        Me.Label18.TabIndex = 72
        Me.Label18.Text = "2, então selecione o NPC aqui"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 45)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(215, 20)
        Me.Label17.TabIndex = 71
        Me.Label17.Text = "1, Escolha um campo da lista"
        '
        'cmbNpcList
        '
        Me.cmbNpcList.FormattingEnabled = True
        Me.cmbNpcList.Location = New System.Drawing.Point(392, 69)
        Me.cmbNpcList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbNpcList.Name = "cmbNpcList"
        Me.cmbNpcList.Size = New System.Drawing.Size(318, 28)
        Me.cmbNpcList.TabIndex = 70
        '
        'lstMapNpc
        '
        Me.lstMapNpc.FormattingEnabled = True
        Me.lstMapNpc.ItemHeight = 20
        Me.lstMapNpc.Location = New System.Drawing.Point(14, 69)
        Me.lstMapNpc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lstMapNpc.Name = "lstMapNpc"
        Me.lstMapNpc.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstMapNpc.Size = New System.Drawing.Size(270, 564)
        Me.lstMapNpc.TabIndex = 69
        '
        'ComboBox23
        '
        Me.ComboBox23.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox23.FormattingEnabled = True
        Me.ComboBox23.Location = New System.Drawing.Point(512, 722)
        Me.ComboBox23.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ComboBox23.Name = "ComboBox23"
        Me.ComboBox23.Size = New System.Drawing.Size(198, 28)
        Me.ComboBox23.TabIndex = 68
        '
        'tpSettings
        '
        Me.tpSettings.Controls.Add(Me.btnSaveSettings)
        Me.tpSettings.Controls.Add(Me.fraMapSettings)
        Me.tpSettings.Controls.Add(Me.fraMapLinks)
        Me.tpSettings.Controls.Add(Me.fraBootSettings)
        Me.tpSettings.Controls.Add(Me.fraMaxSizes)
        Me.tpSettings.Controls.Add(Me.GroupBox2)
        Me.tpSettings.Controls.Add(Me.txtName)
        Me.tpSettings.Controls.Add(Me.Label6)
        Me.tpSettings.Location = New System.Drawing.Point(4, 29)
        Me.tpSettings.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpSettings.Name = "tpSettings"
        Me.tpSettings.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpSettings.Size = New System.Drawing.Size(740, 727)
        Me.tpSettings.TabIndex = 2
        Me.tpSettings.Text = "Configurações"
        Me.tpSettings.UseVisualStyleBackColor = True
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.Location = New System.Drawing.Point(566, 675)
        Me.btnSaveSettings.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(162, 35)
        Me.btnSaveSettings.TabIndex = 16
        Me.btnSaveSettings.Text = "Save Settings"
        Me.btnSaveSettings.UseVisualStyleBackColor = True
        '
        'fraMapSettings
        '
        Me.fraMapSettings.Controls.Add(Me.chkInstance)
        Me.fraMapSettings.Controls.Add(Me.Label8)
        Me.fraMapSettings.Controls.Add(Me.cmbMoral)
        Me.fraMapSettings.Location = New System.Drawing.Point(9, 49)
        Me.fraMapSettings.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraMapSettings.Name = "fraMapSettings"
        Me.fraMapSettings.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraMapSettings.Size = New System.Drawing.Size(348, 105)
        Me.fraMapSettings.TabIndex = 15
        Me.fraMapSettings.TabStop = False
        Me.fraMapSettings.Text = "Configurações de Mapa"
        '
        'chkInstance
        '
        Me.chkInstance.AutoSize = True
        Me.chkInstance.Location = New System.Drawing.Point(9, 69)
        Me.chkInstance.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkInstance.Name = "chkInstance"
        Me.chkInstance.Size = New System.Drawing.Size(127, 24)
        Me.chkInstance.TabIndex = 40
        Me.chkInstance.Text = "Instanciado?"
        Me.chkInstance.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 22)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 20)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Moral:"
        '
        'cmbMoral
        '
        Me.cmbMoral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoral.FormattingEnabled = True
        Me.cmbMoral.Items.AddRange(New Object() {"None", "Safe Zone", "Indoors"})
        Me.cmbMoral.Location = New System.Drawing.Point(68, 18)
        Me.cmbMoral.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbMoral.Name = "cmbMoral"
        Me.cmbMoral.Size = New System.Drawing.Size(270, 28)
        Me.cmbMoral.TabIndex = 37
        '
        'fraMapLinks
        '
        Me.fraMapLinks.Controls.Add(Me.txtDown)
        Me.fraMapLinks.Controls.Add(Me.txtLeft)
        Me.fraMapLinks.Controls.Add(Me.lblMap)
        Me.fraMapLinks.Controls.Add(Me.txtRight)
        Me.fraMapLinks.Controls.Add(Me.txtUp)
        Me.fraMapLinks.Location = New System.Drawing.Point(9, 162)
        Me.fraMapLinks.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraMapLinks.Name = "fraMapLinks"
        Me.fraMapLinks.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraMapLinks.Size = New System.Drawing.Size(348, 172)
        Me.fraMapLinks.TabIndex = 14
        Me.fraMapLinks.TabStop = False
        Me.fraMapLinks.Text = "Map Links"
        '
        'txtDown
        '
        Me.txtDown.Location = New System.Drawing.Point(135, 132)
        Me.txtDown.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDown.Name = "txtDown"
        Me.txtDown.Size = New System.Drawing.Size(73, 26)
        Me.txtDown.TabIndex = 6
        Me.txtDown.Text = "0"
        '
        'txtLeft
        '
        Me.txtLeft.Location = New System.Drawing.Point(10, 72)
        Me.txtLeft.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLeft.Name = "txtLeft"
        Me.txtLeft.Size = New System.Drawing.Size(62, 26)
        Me.txtLeft.TabIndex = 5
        Me.txtLeft.Text = "0"
        '
        'lblMap
        '
        Me.lblMap.AutoSize = True
        Me.lblMap.Location = New System.Drawing.Point(112, 78)
        Me.lblMap.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMap.Name = "lblMap"
        Me.lblMap.Size = New System.Drawing.Size(107, 20)
        Me.lblMap.TabIndex = 4
        Me.lblMap.Text = "Mapa Atual: 0"
        '
        'txtRight
        '
        Me.txtRight.Location = New System.Drawing.Point(266, 72)
        Me.txtRight.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtRight.Name = "txtRight"
        Me.txtRight.Size = New System.Drawing.Size(73, 26)
        Me.txtRight.TabIndex = 3
        Me.txtRight.Text = "0"
        '
        'txtUp
        '
        Me.txtUp.Location = New System.Drawing.Point(134, 15)
        Me.txtUp.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtUp.Name = "txtUp"
        Me.txtUp.Size = New System.Drawing.Size(73, 26)
        Me.txtUp.TabIndex = 1
        Me.txtUp.Text = "0"
        '
        'fraBootSettings
        '
        Me.fraBootSettings.Controls.Add(Me.txtBootMap)
        Me.fraBootSettings.Controls.Add(Me.Label5)
        Me.fraBootSettings.Controls.Add(Me.txtBootY)
        Me.fraBootSettings.Controls.Add(Me.Label3)
        Me.fraBootSettings.Controls.Add(Me.txtBootX)
        Me.fraBootSettings.Controls.Add(Me.Label4)
        Me.fraBootSettings.Location = New System.Drawing.Point(9, 345)
        Me.fraBootSettings.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraBootSettings.Name = "fraBootSettings"
        Me.fraBootSettings.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraBootSettings.Size = New System.Drawing.Size(348, 140)
        Me.fraBootSettings.TabIndex = 13
        Me.fraBootSettings.TabStop = False
        Me.fraBootSettings.Text = "Configurações da Re-geração"
        '
        'txtBootMap
        '
        Me.txtBootMap.Location = New System.Drawing.Point(264, 18)
        Me.txtBootMap.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtBootMap.Name = "txtBootMap"
        Me.txtBootMap.Size = New System.Drawing.Size(73, 26)
        Me.txtBootMap.TabIndex = 5
        Me.txtBootMap.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 25)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Respawn Map:"
        '
        'txtBootY
        '
        Me.txtBootY.Location = New System.Drawing.Point(264, 98)
        Me.txtBootY.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtBootY.Name = "txtBootY"
        Me.txtBootY.Size = New System.Drawing.Size(73, 26)
        Me.txtBootY.TabIndex = 3
        Me.txtBootY.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 100)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Respawn Y:"
        '
        'txtBootX
        '
        Me.txtBootX.Location = New System.Drawing.Point(264, 58)
        Me.txtBootX.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtBootX.Name = "txtBootX"
        Me.txtBootX.Size = New System.Drawing.Size(73, 26)
        Me.txtBootX.TabIndex = 1
        Me.txtBootX.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 58)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Respawn X:"
        '
        'fraMaxSizes
        '
        Me.fraMaxSizes.Controls.Add(Me.txtMaxY)
        Me.fraMaxSizes.Controls.Add(Me.Label2)
        Me.fraMaxSizes.Controls.Add(Me.txtMaxX)
        Me.fraMaxSizes.Controls.Add(Me.Label7)
        Me.fraMaxSizes.Location = New System.Drawing.Point(366, 345)
        Me.fraMaxSizes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraMaxSizes.Name = "fraMaxSizes"
        Me.fraMaxSizes.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fraMaxSizes.Size = New System.Drawing.Size(362, 120)
        Me.fraMaxSizes.TabIndex = 12
        Me.fraMaxSizes.TabStop = False
        Me.fraMaxSizes.Text = "Tamanho do Mapa"
        '
        'txtMaxY
        '
        Me.txtMaxY.Location = New System.Drawing.Point(186, 65)
        Me.txtMaxY.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMaxY.Name = "txtMaxY"
        Me.txtMaxY.Size = New System.Drawing.Size(73, 26)
        Me.txtMaxY.TabIndex = 3
        Me.txtMaxY.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 69)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Y Máximo:"
        '
        'txtMaxX
        '
        Me.txtMaxX.Location = New System.Drawing.Point(186, 25)
        Me.txtMaxX.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMaxX.Name = "txtMaxX"
        Me.txtMaxX.Size = New System.Drawing.Size(73, 26)
        Me.txtMaxX.TabIndex = 1
        Me.txtMaxX.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 29)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 20)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "X Máximo:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnPreview)
        Me.GroupBox2.Controls.Add(Me.lstMusic)
        Me.GroupBox2.Location = New System.Drawing.Point(366, 5)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(362, 332)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Música"
        '
        'btnPreview
        '
        Me.btnPreview.Image = CType(resources.GetObject("btnPreview.Image"), System.Drawing.Image)
        Me.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPreview.Location = New System.Drawing.Point(74, 278)
        Me.btnPreview.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(208, 45)
        Me.btnPreview.TabIndex = 4
        Me.btnPreview.Text = "Ouvir Música"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'lstMusic
        '
        Me.lstMusic.FormattingEnabled = True
        Me.lstMusic.ItemHeight = 20
        Me.lstMusic.Location = New System.Drawing.Point(9, 29)
        Me.lstMusic.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lstMusic.Name = "lstMusic"
        Me.lstMusic.ScrollAlwaysVisible = True
        Me.lstMusic.Size = New System.Drawing.Size(342, 244)
        Me.lstMusic.TabIndex = 3
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(80, 9)
        Me.txtName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(276, 26)
        Me.txtName.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 14)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 20)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Nome:"
        '
        'tpDirBlock
        '
        Me.tpDirBlock.Controls.Add(Me.Label12)
        Me.tpDirBlock.Location = New System.Drawing.Point(4, 29)
        Me.tpDirBlock.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpDirBlock.Name = "tpDirBlock"
        Me.tpDirBlock.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpDirBlock.Size = New System.Drawing.Size(740, 727)
        Me.tpDirBlock.TabIndex = 4
        Me.tpDirBlock.Text = "Bloqueio Direcional"
        Me.tpDirBlock.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(33, 35)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(439, 20)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Apenas pressione as setas para bloquear aquele lado da tile."
        '
        'tpEvents
        '
        Me.tpEvents.Controls.Add(Me.lblPasteMode)
        Me.tpEvents.Controls.Add(Me.lblCopyMode)
        Me.tpEvents.Controls.Add(Me.btnPasteEvent)
        Me.tpEvents.Controls.Add(Me.Label16)
        Me.tpEvents.Controls.Add(Me.btnCopyEvent)
        Me.tpEvents.Controls.Add(Me.Label15)
        Me.tpEvents.Controls.Add(Me.Label13)
        Me.tpEvents.Location = New System.Drawing.Point(4, 29)
        Me.tpEvents.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpEvents.Name = "tpEvents"
        Me.tpEvents.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpEvents.Size = New System.Drawing.Size(740, 727)
        Me.tpEvents.TabIndex = 5
        Me.tpEvents.Text = "Eventos"
        Me.tpEvents.UseVisualStyleBackColor = True
        '
        'lblPasteMode
        '
        Me.lblPasteMode.AutoSize = True
        Me.lblPasteMode.Location = New System.Drawing.Point(156, 262)
        Me.lblPasteMode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPasteMode.Name = "lblPasteMode"
        Me.lblPasteMode.Size = New System.Drawing.Size(116, 20)
        Me.lblPasteMode.TabIndex = 6
        Me.lblPasteMode.Text = "PasteMode Off"
        '
        'lblCopyMode
        '
        Me.lblCopyMode.AutoSize = True
        Me.lblCopyMode.Location = New System.Drawing.Point(161, 172)
        Me.lblCopyMode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCopyMode.Name = "lblCopyMode"
        Me.lblCopyMode.Size = New System.Drawing.Size(111, 20)
        Me.lblCopyMode.TabIndex = 5
        Me.lblCopyMode.Text = "CopyMode Off"
        '
        'btnPasteEvent
        '
        Me.btnPasteEvent.Location = New System.Drawing.Point(34, 255)
        Me.btnPasteEvent.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnPasteEvent.Name = "btnPasteEvent"
        Me.btnPasteEvent.Size = New System.Drawing.Size(112, 35)
        Me.btnPasteEvent.TabIndex = 4
        Me.btnPasteEvent.Text = "Colar Evento"
        Me.btnPasteEvent.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(30, 229)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(666, 20)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Para colar um evento copiado, aperte o botão de colar e então clique no mapa para" &
    " colocá-lo."
        '
        'btnCopyEvent
        '
        Me.btnCopyEvent.Location = New System.Drawing.Point(34, 165)
        Me.btnCopyEvent.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCopyEvent.Name = "btnCopyEvent"
        Me.btnCopyEvent.Size = New System.Drawing.Size(124, 35)
        Me.btnCopyEvent.TabIndex = 2
        Me.btnCopyEvent.Text = "Copiar Evento"
        Me.btnCopyEvent.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(30, 134)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(549, 20)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Para copiar um evento existente, aperte o botão de copiar e depois o evento."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(30, 32)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(382, 20)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Clique no mapa onde você quer adicionar um evento."
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage1.Size = New System.Drawing.Size(740, 727)
        Me.TabPage1.TabIndex = 6
        Me.TabPage1.Text = "Efeitos de Mapa"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.cmbParallax)
        Me.GroupBox5.Location = New System.Drawing.Point(380, 255)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox5.Size = New System.Drawing.Size(354, 82)
        Me.GroupBox5.TabIndex = 21
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Map Parallax"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(9, 34)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(68, 20)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Parallax:"
        '
        'cmbParallax
        '
        Me.cmbParallax.FormattingEnabled = True
        Me.cmbParallax.Location = New System.Drawing.Point(105, 29)
        Me.cmbParallax.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbParallax.Name = "cmbParallax"
        Me.cmbParallax.Size = New System.Drawing.Size(238, 28)
        Me.cmbParallax.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.cmbPanorama)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 255)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox4.Size = New System.Drawing.Size(362, 82)
        Me.GroupBox4.TabIndex = 20
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Map Panorama"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(9, 34)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(86, 20)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Panorama:"
        '
        'cmbPanorama
        '
        Me.cmbPanorama.FormattingEnabled = True
        Me.cmbPanorama.Location = New System.Drawing.Point(105, 29)
        Me.cmbPanorama.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbPanorama.Name = "cmbPanorama"
        Me.cmbPanorama.Size = New System.Drawing.Size(246, 28)
        Me.cmbPanorama.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkUseTint)
        Me.GroupBox3.Controls.Add(Me.lblMapAlpha)
        Me.GroupBox3.Controls.Add(Me.lblMapBlue)
        Me.GroupBox3.Controls.Add(Me.lblMapGreen)
        Me.GroupBox3.Controls.Add(Me.lblMapRed)
        Me.GroupBox3.Controls.Add(Me.scrlMapAlpha)
        Me.GroupBox3.Controls.Add(Me.scrlMapBlue)
        Me.GroupBox3.Controls.Add(Me.scrlMapGreen)
        Me.GroupBox3.Controls.Add(Me.scrlMapRed)
        Me.GroupBox3.Location = New System.Drawing.Point(380, 9)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Size = New System.Drawing.Size(354, 238)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Map Tint"
        '
        'chkUseTint
        '
        Me.chkUseTint.AutoSize = True
        Me.chkUseTint.Location = New System.Drawing.Point(9, 29)
        Me.chkUseTint.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkUseTint.Name = "chkUseTint"
        Me.chkUseTint.Size = New System.Drawing.Size(134, 24)
        Me.chkUseTint.TabIndex = 18
        Me.chkUseTint.Text = "Use MapTint?"
        Me.chkUseTint.UseVisualStyleBackColor = True
        '
        'lblMapAlpha
        '
        Me.lblMapAlpha.AutoSize = True
        Me.lblMapAlpha.Location = New System.Drawing.Point(12, 148)
        Me.lblMapAlpha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMapAlpha.Name = "lblMapAlpha"
        Me.lblMapAlpha.Size = New System.Drawing.Size(67, 20)
        Me.lblMapAlpha.TabIndex = 17
        Me.lblMapAlpha.Text = "Alpha: 0"
        '
        'lblMapBlue
        '
        Me.lblMapBlue.AutoSize = True
        Me.lblMapBlue.Location = New System.Drawing.Point(12, 118)
        Me.lblMapBlue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMapBlue.Name = "lblMapBlue"
        Me.lblMapBlue.Size = New System.Drawing.Size(58, 20)
        Me.lblMapBlue.TabIndex = 16
        Me.lblMapBlue.Text = "Blue: 0"
        '
        'lblMapGreen
        '
        Me.lblMapGreen.AutoSize = True
        Me.lblMapGreen.Location = New System.Drawing.Point(12, 89)
        Me.lblMapGreen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMapGreen.Name = "lblMapGreen"
        Me.lblMapGreen.Size = New System.Drawing.Size(71, 20)
        Me.lblMapGreen.TabIndex = 15
        Me.lblMapGreen.Text = "Green: 0"
        '
        'lblMapRed
        '
        Me.lblMapRed.AutoSize = True
        Me.lblMapRed.Location = New System.Drawing.Point(9, 60)
        Me.lblMapRed.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMapRed.Name = "lblMapRed"
        Me.lblMapRed.Size = New System.Drawing.Size(56, 20)
        Me.lblMapRed.TabIndex = 14
        Me.lblMapRed.Text = "Red: 0"
        '
        'scrlMapAlpha
        '
        Me.scrlMapAlpha.LargeChange = 1
        Me.scrlMapAlpha.Location = New System.Drawing.Point(129, 145)
        Me.scrlMapAlpha.Maximum = 255
        Me.scrlMapAlpha.Name = "scrlMapAlpha"
        Me.scrlMapAlpha.Size = New System.Drawing.Size(218, 17)
        Me.scrlMapAlpha.TabIndex = 13
        '
        'scrlMapBlue
        '
        Me.scrlMapBlue.LargeChange = 1
        Me.scrlMapBlue.Location = New System.Drawing.Point(129, 115)
        Me.scrlMapBlue.Maximum = 255
        Me.scrlMapBlue.Name = "scrlMapBlue"
        Me.scrlMapBlue.Size = New System.Drawing.Size(218, 17)
        Me.scrlMapBlue.TabIndex = 12
        '
        'scrlMapGreen
        '
        Me.scrlMapGreen.LargeChange = 1
        Me.scrlMapGreen.Location = New System.Drawing.Point(129, 86)
        Me.scrlMapGreen.Maximum = 255
        Me.scrlMapGreen.Name = "scrlMapGreen"
        Me.scrlMapGreen.Size = New System.Drawing.Size(218, 17)
        Me.scrlMapGreen.TabIndex = 11
        '
        'scrlMapRed
        '
        Me.scrlMapRed.LargeChange = 1
        Me.scrlMapRed.Location = New System.Drawing.Point(129, 58)
        Me.scrlMapRed.Maximum = 255
        Me.scrlMapRed.Name = "scrlMapRed"
        Me.scrlMapRed.Size = New System.Drawing.Size(218, 17)
        Me.scrlMapRed.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.scrlFogAlpha)
        Me.GroupBox1.Controls.Add(Me.lblFogAlpha)
        Me.GroupBox1.Controls.Add(Me.scrlFogSpeed)
        Me.GroupBox1.Controls.Add(Me.lblFogSpeed)
        Me.GroupBox1.Controls.Add(Me.scrlIntensity)
        Me.GroupBox1.Controls.Add(Me.lblIntensity)
        Me.GroupBox1.Controls.Add(Me.scrlFog)
        Me.GroupBox1.Controls.Add(Me.lblFogIndex)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.cmbWeather)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 9)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(362, 238)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Clima do Mapa"
        '
        'scrlFogAlpha
        '
        Me.scrlFogAlpha.LargeChange = 1
        Me.scrlFogAlpha.Location = New System.Drawing.Point(135, 191)
        Me.scrlFogAlpha.Maximum = 255
        Me.scrlFogAlpha.Name = "scrlFogAlpha"
        Me.scrlFogAlpha.Size = New System.Drawing.Size(218, 17)
        Me.scrlFogAlpha.TabIndex = 9
        '
        'lblFogAlpha
        '
        Me.lblFogAlpha.AutoSize = True
        Me.lblFogAlpha.Location = New System.Drawing.Point(9, 194)
        Me.lblFogAlpha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFogAlpha.Name = "lblFogAlpha"
        Me.lblFogAlpha.Size = New System.Drawing.Size(117, 20)
        Me.lblFogAlpha.TabIndex = 8
        Me.lblFogAlpha.Text = "Fog Alpha: 255"
        '
        'scrlFogSpeed
        '
        Me.scrlFogSpeed.LargeChange = 1
        Me.scrlFogSpeed.Location = New System.Drawing.Point(135, 155)
        Me.scrlFogSpeed.Name = "scrlFogSpeed"
        Me.scrlFogSpeed.Size = New System.Drawing.Size(218, 17)
        Me.scrlFogSpeed.TabIndex = 7
        '
        'lblFogSpeed
        '
        Me.lblFogSpeed.AutoSize = True
        Me.lblFogSpeed.Location = New System.Drawing.Point(9, 162)
        Me.lblFogSpeed.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFogSpeed.Name = "lblFogSpeed"
        Me.lblFogSpeed.Size = New System.Drawing.Size(119, 20)
        Me.lblFogSpeed.TabIndex = 6
        Me.lblFogSpeed.Text = "FogSpeed: 100"
        '
        'scrlIntensity
        '
        Me.scrlIntensity.LargeChange = 1
        Me.scrlIntensity.Location = New System.Drawing.Point(135, 78)
        Me.scrlIntensity.Name = "scrlIntensity"
        Me.scrlIntensity.Size = New System.Drawing.Size(218, 17)
        Me.scrlIntensity.TabIndex = 5
        '
        'lblIntensity
        '
        Me.lblIntensity.AutoSize = True
        Me.lblIntensity.Location = New System.Drawing.Point(9, 82)
        Me.lblIntensity.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIntensity.Name = "lblIntensity"
        Me.lblIntensity.Size = New System.Drawing.Size(128, 20)
        Me.lblIntensity.TabIndex = 4
        Me.lblIntensity.Text = "Intensidade: 100"
        '
        'scrlFog
        '
        Me.scrlFog.LargeChange = 1
        Me.scrlFog.Location = New System.Drawing.Point(135, 125)
        Me.scrlFog.Name = "scrlFog"
        Me.scrlFog.Size = New System.Drawing.Size(218, 17)
        Me.scrlFog.TabIndex = 3
        '
        'lblFogIndex
        '
        Me.lblFogIndex.AutoSize = True
        Me.lblFogIndex.Location = New System.Drawing.Point(9, 126)
        Me.lblFogIndex.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFogIndex.Name = "lblFogIndex"
        Me.lblFogIndex.Size = New System.Drawing.Size(71, 20)
        Me.lblFogIndex.TabIndex = 2
        Me.lblFogIndex.Text = "Névoa: 1"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 38)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(112, 20)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Weather Type:"
        '
        'cmbWeather
        '
        Me.cmbWeather.FormattingEnabled = True
        Me.cmbWeather.Items.AddRange(New Object() {"None", "Rain", "Snow", "Hail", "Sand Storm", "Storm", "Fog"})
        Me.cmbWeather.Location = New System.Drawing.Point(135, 34)
        Me.cmbWeather.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbWeather.Name = "cmbWeather"
        Me.cmbWeather.Size = New System.Drawing.Size(216, 28)
        Me.cmbWeather.TabIndex = 0
        '
        'FrmEditor_MapEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1521, 811)
        Me.ControlBox = False
        Me.Controls.Add(Me.tabpages)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.pnlAttributes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "FrmEditor_MapEditor"
        Me.Text = "Editor de Mapa"
        Me.pnlBack.ResumeLayout(False)
        CType(Me.picBackSelect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAttributes.ResumeLayout(False)
        Me.fraMapWarp.ResumeLayout(False)
        Me.fraMapWarp.PerformLayout()
        Me.fraBuyHouse.ResumeLayout(False)
        Me.fraBuyHouse.PerformLayout()
        Me.fraKeyOpen.ResumeLayout(False)
        Me.fraKeyOpen.PerformLayout()
        Me.fraMapKey.ResumeLayout(False)
        Me.fraMapKey.PerformLayout()
        CType(Me.picMapKey, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraNpcSpawn.ResumeLayout(False)
        Me.fraNpcSpawn.PerformLayout()
        Me.fraHeal.ResumeLayout(False)
        Me.fraHeal.PerformLayout()
        Me.fraShop.ResumeLayout(False)
        Me.fraResource.ResumeLayout(False)
        Me.fraResource.PerformLayout()
        Me.fraMapItem.ResumeLayout(False)
        Me.fraMapItem.PerformLayout()
        CType(Me.picMapItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraTrap.ResumeLayout(False)
        Me.fraTrap.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.tabpages.ResumeLayout(False)
        Me.tpTiles.ResumeLayout(False)
        Me.tpTiles.PerformLayout()
        Me.tpAttributes.ResumeLayout(False)
        Me.tpAttributes.PerformLayout()
        Me.tpNpcs.ResumeLayout(False)
        Me.fraNpcs.ResumeLayout(False)
        Me.fraNpcs.PerformLayout()
        Me.tpSettings.ResumeLayout(False)
        Me.tpSettings.PerformLayout()
        Me.fraMapSettings.ResumeLayout(False)
        Me.fraMapSettings.PerformLayout()
        Me.fraMapLinks.ResumeLayout(False)
        Me.fraMapLinks.PerformLayout()
        Me.fraBootSettings.ResumeLayout(False)
        Me.fraBootSettings.PerformLayout()
        Me.fraMaxSizes.ResumeLayout(False)
        Me.fraMaxSizes.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.tpDirBlock.ResumeLayout(False)
        Me.tpDirBlock.PerformLayout()
        Me.tpEvents.ResumeLayout(False)
        Me.tpEvents.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents scrlPictureX As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlPictureY As System.Windows.Forms.VScrollBar
    Friend WithEvents pnlBack As System.Windows.Forms.Panel
    Friend WithEvents optTrap As System.Windows.Forms.RadioButton
    Friend WithEvents optHeal As System.Windows.Forms.RadioButton
    Friend WithEvents optBank As System.Windows.Forms.RadioButton
    Friend WithEvents optShop As System.Windows.Forms.RadioButton
    Friend WithEvents optNPCSpawn As System.Windows.Forms.RadioButton
    Friend WithEvents optDoor As System.Windows.Forms.RadioButton
    Friend WithEvents optResource As System.Windows.Forms.RadioButton
    Friend WithEvents optKeyOpen As System.Windows.Forms.RadioButton
    Friend WithEvents optKey As System.Windows.Forms.RadioButton
    Friend WithEvents optNPCAvoid As System.Windows.Forms.RadioButton
    Friend WithEvents optItem As System.Windows.Forms.RadioButton
    Friend WithEvents optWarp As System.Windows.Forms.RadioButton
    Friend WithEvents optBlocked As System.Windows.Forms.RadioButton
    Public WithEvents picBackSelect As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClearAttribute As System.Windows.Forms.Button
    Friend WithEvents pnlAttributes As System.Windows.Forms.Panel
    Friend WithEvents fraMapWarp As System.Windows.Forms.GroupBox
    Friend WithEvents lblMapWarpY As System.Windows.Forms.Label
    Friend WithEvents lblMapWarpX As System.Windows.Forms.Label
    Friend WithEvents lblMapWarpMap As System.Windows.Forms.Label
    Friend WithEvents scrlMapWarpY As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlMapWarpX As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlMapWarpMap As System.Windows.Forms.HScrollBar
    Friend WithEvents btnMapWarp As System.Windows.Forms.Button
    Friend WithEvents fraMapItem As System.Windows.Forms.GroupBox
    Friend WithEvents btnMapItem As System.Windows.Forms.Button
    Friend WithEvents scrlMapItemValue As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlMapItem As System.Windows.Forms.HScrollBar
    Friend WithEvents lblMapItem As System.Windows.Forms.Label
    Friend WithEvents picMapItem As System.Windows.Forms.PictureBox
    Friend WithEvents fraMapKey As System.Windows.Forms.GroupBox
    Friend WithEvents chkMapKey As System.Windows.Forms.CheckBox
    Friend WithEvents picMapKey As System.Windows.Forms.PictureBox
    Friend WithEvents btnMapKey As System.Windows.Forms.Button
    Friend WithEvents scrlMapKey As System.Windows.Forms.HScrollBar
    Friend WithEvents lblMapKey As System.Windows.Forms.Label
    Friend WithEvents fraKeyOpen As System.Windows.Forms.GroupBox
    Friend WithEvents btnMapKeyOpen As System.Windows.Forms.Button
    Friend WithEvents scrlKeyX As System.Windows.Forms.HScrollBar
    Friend WithEvents lblKeyX As System.Windows.Forms.Label
    Friend WithEvents scrlKeyY As System.Windows.Forms.HScrollBar
    Friend WithEvents lblKeyY As System.Windows.Forms.Label
    Friend WithEvents fraResource As System.Windows.Forms.GroupBox
    Friend WithEvents btnResourceOk As System.Windows.Forms.Button
    Friend WithEvents scrlResource As System.Windows.Forms.HScrollBar
    Friend WithEvents lblResource As System.Windows.Forms.Label
    Friend WithEvents fraNpcSpawn As System.Windows.Forms.GroupBox
    Friend WithEvents btnNpcSpawn As System.Windows.Forms.Button
    Friend WithEvents scrlNpcDir As System.Windows.Forms.HScrollBar
    Friend WithEvents lblNpcDir As System.Windows.Forms.Label
    Friend WithEvents lstNpc As System.Windows.Forms.ComboBox
    Friend WithEvents fraShop As System.Windows.Forms.GroupBox
    Friend WithEvents cmbShop As System.Windows.Forms.ComboBox
    Friend WithEvents btnShop As System.Windows.Forms.Button
    Friend WithEvents fraHeal As System.Windows.Forms.GroupBox
    Friend WithEvents lblHeal As System.Windows.Forms.Label
    Friend WithEvents cmbHeal As System.Windows.Forms.ComboBox
    Friend WithEvents btnHeal As System.Windows.Forms.Button
    Friend WithEvents scrlHeal As System.Windows.Forms.HScrollBar
    Friend WithEvents fraTrap As System.Windows.Forms.GroupBox
    Friend WithEvents btnTrap As System.Windows.Forms.Button
    Friend WithEvents scrlTrap As System.Windows.Forms.HScrollBar
    Friend WithEvents lblTrap As System.Windows.Forms.Label
    Friend WithEvents optHouse As Windows.Forms.RadioButton
    Friend WithEvents fraBuyHouse As Windows.Forms.GroupBox
    Friend WithEvents btnHouseTileOk As Windows.Forms.Button
    Friend WithEvents scrlBuyHouse As Windows.Forms.HScrollBar
    Friend WithEvents lblHouseName As Windows.Forms.Label
    Friend WithEvents ToolStrip As Windows.Forms.ToolStrip
    Friend WithEvents tsbSave As Windows.Forms.ToolStripButton
    Friend WithEvents tsbDiscard As Windows.Forms.ToolStripButton
    Friend WithEvents tabpages As Windows.Forms.TabControl
    Friend WithEvents tpTiles As Windows.Forms.TabPage
    Friend WithEvents tpNpcs As Windows.Forms.TabPage
    Friend WithEvents tpSettings As Windows.Forms.TabPage
    Friend WithEvents fraNpcs As Windows.Forms.GroupBox
    Friend WithEvents ComboBox23 As Windows.Forms.ComboBox
    Friend WithEvents txtName As Windows.Forms.TextBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents fraMapLinks As Windows.Forms.GroupBox
    Friend WithEvents txtDown As Windows.Forms.TextBox
    Friend WithEvents txtLeft As Windows.Forms.TextBox
    Friend WithEvents lblMap As Windows.Forms.Label
    Friend WithEvents txtRight As Windows.Forms.TextBox
    Friend WithEvents txtUp As Windows.Forms.TextBox
    Friend WithEvents fraBootSettings As Windows.Forms.GroupBox
    Friend WithEvents txtBootMap As Windows.Forms.TextBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents txtBootY As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents txtBootX As Windows.Forms.TextBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents fraMaxSizes As Windows.Forms.GroupBox
    Friend WithEvents txtMaxY As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txtMaxX As Windows.Forms.TextBox
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents lstMusic As Windows.Forms.ListBox
    Friend WithEvents fraMapSettings As Windows.Forms.GroupBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents cmbMoral As Windows.Forms.ComboBox
    Friend WithEvents btnSaveSettings As Windows.Forms.Button
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbNpcList As Windows.Forms.ComboBox
    Friend WithEvents lstMapNpc As Windows.Forms.ListBox
    Friend WithEvents tpAttributes As Windows.Forms.TabPage
    Friend WithEvents cmbTileSets As Windows.Forms.ComboBox
    Friend WithEvents cmbAutoTile As Windows.Forms.ComboBox
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents cmbLayers As Windows.Forms.ComboBox
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents tpDirBlock As Windows.Forms.TabPage
    Friend WithEvents tpEvents As Windows.Forms.TabPage
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents tsbMapGrid As Windows.Forms.ToolStripButton
    Friend WithEvents btnPreview As Windows.Forms.Button
    Friend WithEvents optCraft As Windows.Forms.RadioButton
    Friend WithEvents tsbFill As Windows.Forms.ToolStripButton
    Friend WithEvents tsbClear As Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As Windows.Forms.ToolStripSeparator
    Friend WithEvents chkInstance As Windows.Forms.CheckBox
    Friend WithEvents optLight As Windows.Forms.RadioButton
    Friend WithEvents btnPasteEvent As Windows.Forms.Button
    Friend WithEvents Label16 As Windows.Forms.Label
    Friend WithEvents btnCopyEvent As Windows.Forms.Button
    Friend WithEvents Label15 As Windows.Forms.Label
    Friend WithEvents lblPasteMode As Windows.Forms.Label
    Friend WithEvents lblCopyMode As Windows.Forms.Label
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents chkUseTint As Windows.Forms.CheckBox
    Friend WithEvents lblMapAlpha As Windows.Forms.Label
    Friend WithEvents lblMapBlue As Windows.Forms.Label
    Friend WithEvents lblMapGreen As Windows.Forms.Label
    Friend WithEvents lblMapRed As Windows.Forms.Label
    Friend WithEvents scrlMapAlpha As Windows.Forms.HScrollBar
    Friend WithEvents scrlMapBlue As Windows.Forms.HScrollBar
    Friend WithEvents scrlMapGreen As Windows.Forms.HScrollBar
    Friend WithEvents scrlMapRed As Windows.Forms.HScrollBar
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents scrlFogAlpha As Windows.Forms.HScrollBar
    Friend WithEvents lblFogAlpha As Windows.Forms.Label
    Friend WithEvents scrlFogSpeed As Windows.Forms.HScrollBar
    Friend WithEvents lblFogSpeed As Windows.Forms.Label
    Friend WithEvents scrlIntensity As Windows.Forms.HScrollBar
    Friend WithEvents lblIntensity As Windows.Forms.Label
    Friend WithEvents scrlFog As Windows.Forms.HScrollBar
    Friend WithEvents lblFogIndex As Windows.Forms.Label
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents cmbWeather As Windows.Forms.ComboBox
    Friend WithEvents Label18 As Windows.Forms.Label
    Friend WithEvents Label17 As Windows.Forms.Label
    Friend WithEvents GroupBox5 As Windows.Forms.GroupBox
    Friend WithEvents Label20 As Windows.Forms.Label
    Friend WithEvents cmbParallax As Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As Windows.Forms.GroupBox
    Friend WithEvents Label19 As Windows.Forms.Label
    Friend WithEvents cmbPanorama As Windows.Forms.ComboBox
End Class
