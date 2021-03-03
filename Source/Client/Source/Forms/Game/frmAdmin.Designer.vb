<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAdmin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAdmin))
        Me.btnRespawn = New System.Windows.Forms.Button()
        Me.btnMapReport = New System.Windows.Forms.Button()
        Me.btnALoc = New System.Windows.Forms.Button()
        Me.btnSpawnItem = New System.Windows.Forms.Button()
        Me.lblSpawnItemAmount = New System.Windows.Forms.Label()
        Me.lblItemSpawn = New System.Windows.Forms.Label()
        Me.btnAdminSetSprite = New System.Windows.Forms.Button()
        Me.btnAdminWarpTo = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAdminSetAccess = New System.Windows.Forms.Button()
        Me.btnAdminWarpMe2 = New System.Windows.Forms.Button()
        Me.btnAdminWarp2Me = New System.Windows.Forms.Button()
        Me.btnAdminBan = New System.Windows.Forms.Button()
        Me.btnAdminKick = New System.Windows.Forms.Button()
        Me.txtAdminName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstMaps = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabModeration = New System.Windows.Forms.TabPage()
        Me.nudAdminSprite = New System.Windows.Forms.NumericUpDown()
        Me.nudAdminMap = New System.Windows.Forms.NumericUpDown()
        Me.btnLevelUp = New System.Windows.Forms.Button()
        Me.cmbAccess = New System.Windows.Forms.ComboBox()
        Me.tabMapList = New System.Windows.Forms.TabPage()
        Me.tabMapTools = New System.Windows.Forms.TabPage()
        Me.nudSpawnItemAmount = New System.Windows.Forms.NumericUpDown()
        Me.cmbSpawnItem = New System.Windows.Forms.ComboBox()
        Me.tabEditors = New System.Windows.Forms.TabPage()
        Me.btnPetEditor = New System.Windows.Forms.Button()
        Me.btnAutoMapper = New System.Windows.Forms.Button()
        Me.btnClassEditor = New System.Windows.Forms.Button()
        Me.btnRecipeEditor = New System.Windows.Forms.Button()
        Me.btnProjectiles = New System.Windows.Forms.Button()
        Me.btnQuest = New System.Windows.Forms.Button()
        Me.btnhouseEditor = New System.Windows.Forms.Button()
        Me.btnMapEditor = New System.Windows.Forms.Button()
        Me.btnItemEditor = New System.Windows.Forms.Button()
        Me.btnResourceEditor = New System.Windows.Forms.Button()
        Me.btnNPCEditor = New System.Windows.Forms.Button()
        Me.btnSkillEditor = New System.Windows.Forms.Button()
        Me.btnShopEditor = New System.Windows.Forms.Button()
        Me.btnAnimationEditor = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.tabModeration.SuspendLayout()
        CType(Me.nudAdminSprite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAdminMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMapList.SuspendLayout()
        Me.tabMapTools.SuspendLayout()
        CType(Me.nudSpawnItemAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEditors.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnRespawn
        '
        Me.btnRespawn.Location = New System.Drawing.Point(204, 25)
        Me.btnRespawn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnRespawn.Name = "btnRespawn"
        Me.btnRespawn.Size = New System.Drawing.Size(159, 34)
        Me.btnRespawn.TabIndex = 34
        Me.btnRespawn.Text = "Mapa de Respawn"
        Me.btnRespawn.UseVisualStyleBackColor = True
        '
        'btnMapReport
        '
        Me.btnMapReport.Location = New System.Drawing.Point(9, 322)
        Me.btnMapReport.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnMapReport.Name = "btnMapReport"
        Me.btnMapReport.Size = New System.Drawing.Size(357, 34)
        Me.btnMapReport.TabIndex = 33
        Me.btnMapReport.Text = "Atualizar lista"
        Me.btnMapReport.UseVisualStyleBackColor = True
        '
        'btnALoc
        '
        Me.btnALoc.Location = New System.Drawing.Point(21, 25)
        Me.btnALoc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnALoc.Name = "btnALoc"
        Me.btnALoc.Size = New System.Drawing.Size(159, 34)
        Me.btnALoc.TabIndex = 31
        Me.btnALoc.Text = "Localização"
        Me.btnALoc.UseVisualStyleBackColor = True
        '
        'btnSpawnItem
        '
        Me.btnSpawnItem.Location = New System.Drawing.Point(21, 223)
        Me.btnSpawnItem.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSpawnItem.Name = "btnSpawnItem"
        Me.btnSpawnItem.Size = New System.Drawing.Size(342, 34)
        Me.btnSpawnItem.TabIndex = 29
        Me.btnSpawnItem.Text = "Gerar Item"
        Me.btnSpawnItem.UseVisualStyleBackColor = True
        '
        'lblSpawnItemAmount
        '
        Me.lblSpawnItemAmount.AutoSize = True
        Me.lblSpawnItemAmount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSpawnItemAmount.Location = New System.Drawing.Point(16, 186)
        Me.lblSpawnItemAmount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSpawnItemAmount.Name = "lblSpawnItemAmount"
        Me.lblSpawnItemAmount.Size = New System.Drawing.Size(100, 20)
        Me.lblSpawnItemAmount.TabIndex = 26
        Me.lblSpawnItemAmount.Text = "Quantidade :"
        '
        'lblItemSpawn
        '
        Me.lblItemSpawn.AutoSize = True
        Me.lblItemSpawn.Location = New System.Drawing.Point(16, 146)
        Me.lblItemSpawn.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItemSpawn.Name = "lblItemSpawn"
        Me.lblItemSpawn.Size = New System.Drawing.Size(90, 20)
        Me.lblItemSpawn.TabIndex = 25
        Me.lblItemSpawn.Text = "Gerar Item:"
        '
        'btnAdminSetSprite
        '
        Me.btnAdminSetSprite.Location = New System.Drawing.Point(201, 317)
        Me.btnAdminSetSprite.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAdminSetSprite.Name = "btnAdminSetSprite"
        Me.btnAdminSetSprite.Size = New System.Drawing.Size(162, 37)
        Me.btnAdminSetSprite.TabIndex = 16
        Me.btnAdminSetSprite.Text = "Alterar Sprite"
        Me.btnAdminSetSprite.UseVisualStyleBackColor = True
        '
        'btnAdminWarpTo
        '
        Me.btnAdminWarpTo.Location = New System.Drawing.Point(201, 271)
        Me.btnAdminWarpTo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAdminWarpTo.Name = "btnAdminWarpTo"
        Me.btnAdminWarpTo.Size = New System.Drawing.Size(162, 37)
        Me.btnAdminWarpTo.TabIndex = 15
        Me.btnAdminWarpTo.Text = "Teleporte p/ Mapa"
        Me.btnAdminWarpTo.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 325)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Sprite:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 280)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 20)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "ID do Mapa:"
        '
        'btnAdminSetAccess
        '
        Me.btnAdminSetAccess.Location = New System.Drawing.Point(14, 228)
        Me.btnAdminSetAccess.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAdminSetAccess.Name = "btnAdminSetAccess"
        Me.btnAdminSetAccess.Size = New System.Drawing.Size(350, 34)
        Me.btnAdminSetAccess.TabIndex = 9
        Me.btnAdminSetAccess.Text = "Alterar Acesso"
        Me.btnAdminSetAccess.UseVisualStyleBackColor = True
        '
        'btnAdminWarpMe2
        '
        Me.btnAdminWarpMe2.Location = New System.Drawing.Point(190, 95)
        Me.btnAdminWarpMe2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAdminWarpMe2.Name = "btnAdminWarpMe2"
        Me.btnAdminWarpMe2.Size = New System.Drawing.Size(172, 34)
        Me.btnAdminWarpMe2.TabIndex = 8
        Me.btnAdminWarpMe2.Text = "Me Levar Ao Jogador"
        Me.btnAdminWarpMe2.UseVisualStyleBackColor = True
        '
        'btnAdminWarp2Me
        '
        Me.btnAdminWarp2Me.Location = New System.Drawing.Point(9, 95)
        Me.btnAdminWarp2Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAdminWarp2Me.Name = "btnAdminWarp2Me"
        Me.btnAdminWarp2Me.Size = New System.Drawing.Size(172, 34)
        Me.btnAdminWarp2Me.TabIndex = 7
        Me.btnAdminWarp2Me.Text = "Trazer Jogador à Mim"
        Me.btnAdminWarp2Me.UseVisualStyleBackColor = True
        '
        'btnAdminBan
        '
        Me.btnAdminBan.Location = New System.Drawing.Point(190, 52)
        Me.btnAdminBan.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAdminBan.Name = "btnAdminBan"
        Me.btnAdminBan.Size = New System.Drawing.Size(172, 34)
        Me.btnAdminBan.TabIndex = 6
        Me.btnAdminBan.Text = "Banir Jogador"
        Me.btnAdminBan.UseVisualStyleBackColor = True
        '
        'btnAdminKick
        '
        Me.btnAdminKick.Location = New System.Drawing.Point(9, 52)
        Me.btnAdminKick.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAdminKick.Name = "btnAdminKick"
        Me.btnAdminKick.Size = New System.Drawing.Size(172, 34)
        Me.btnAdminKick.TabIndex = 5
        Me.btnAdminKick.Text = "Chutar Jogador"
        Me.btnAdminKick.UseVisualStyleBackColor = True
        '
        'txtAdminName
        '
        Me.txtAdminName.Location = New System.Drawing.Point(88, 12)
        Me.txtAdminName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtAdminName.Name = "txtAdminName"
        Me.txtAdminName.Size = New System.Drawing.Size(272, 26)
        Me.txtAdminName.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 191)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Acesso:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 17)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Jogador:"
        '
        'lstMaps
        '
        Me.lstMaps.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lstMaps.FullRowSelect = True
        Me.lstMaps.GridLines = True
        Me.lstMaps.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstMaps.HideSelection = False
        Me.lstMaps.Location = New System.Drawing.Point(9, 9)
        Me.lstMaps.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lstMaps.MultiSelect = False
        Me.lstMaps.Name = "lstMaps"
        Me.lstMaps.Size = New System.Drawing.Size(356, 301)
        Me.lstMaps.TabIndex = 4
        Me.lstMaps.UseCompatibleStateImageBehavior = False
        Me.lstMaps.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "#"
        Me.ColumnHeader1.Width = 30
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Nome"
        Me.ColumnHeader2.Width = 200
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabModeration)
        Me.TabControl1.Controls.Add(Me.tabMapList)
        Me.TabControl1.Controls.Add(Me.tabMapTools)
        Me.TabControl1.Controls.Add(Me.tabEditors)
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(387, 408)
        Me.TabControl1.TabIndex = 38
        '
        'tabModeration
        '
        Me.tabModeration.Controls.Add(Me.nudAdminSprite)
        Me.tabModeration.Controls.Add(Me.nudAdminMap)
        Me.tabModeration.Controls.Add(Me.btnLevelUp)
        Me.tabModeration.Controls.Add(Me.cmbAccess)
        Me.tabModeration.Controls.Add(Me.Label2)
        Me.tabModeration.Controls.Add(Me.Label3)
        Me.tabModeration.Controls.Add(Me.txtAdminName)
        Me.tabModeration.Controls.Add(Me.btnAdminKick)
        Me.tabModeration.Controls.Add(Me.btnAdminBan)
        Me.tabModeration.Controls.Add(Me.btnAdminWarp2Me)
        Me.tabModeration.Controls.Add(Me.btnAdminWarpMe2)
        Me.tabModeration.Controls.Add(Me.btnAdminSetAccess)
        Me.tabModeration.Controls.Add(Me.Label4)
        Me.tabModeration.Controls.Add(Me.Label5)
        Me.tabModeration.Controls.Add(Me.btnAdminWarpTo)
        Me.tabModeration.Controls.Add(Me.btnAdminSetSprite)
        Me.tabModeration.Location = New System.Drawing.Point(4, 29)
        Me.tabModeration.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabModeration.Name = "tabModeration"
        Me.tabModeration.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabModeration.Size = New System.Drawing.Size(379, 375)
        Me.tabModeration.TabIndex = 0
        Me.tabModeration.Text = "Moderação"
        Me.tabModeration.UseVisualStyleBackColor = True
        '
        'nudAdminSprite
        '
        Me.nudAdminSprite.Location = New System.Drawing.Point(120, 323)
        Me.nudAdminSprite.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudAdminSprite.Name = "nudAdminSprite"
        Me.nudAdminSprite.Size = New System.Drawing.Size(72, 26)
        Me.nudAdminSprite.TabIndex = 33
        '
        'nudAdminMap
        '
        Me.nudAdminMap.Location = New System.Drawing.Point(120, 274)
        Me.nudAdminMap.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudAdminMap.Name = "nudAdminMap"
        Me.nudAdminMap.Size = New System.Drawing.Size(72, 26)
        Me.nudAdminMap.TabIndex = 32
        '
        'btnLevelUp
        '
        Me.btnLevelUp.Location = New System.Drawing.Point(48, 138)
        Me.btnLevelUp.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnLevelUp.Name = "btnLevelUp"
        Me.btnLevelUp.Size = New System.Drawing.Size(282, 34)
        Me.btnLevelUp.TabIndex = 31
        Me.btnLevelUp.Text = "Subir de Nível"
        Me.btnLevelUp.UseVisualStyleBackColor = True
        '
        'cmbAccess
        '
        Me.cmbAccess.FormattingEnabled = True
        Me.cmbAccess.Items.AddRange(New Object() {"Normal Player", "Monitor (GM)", "Mapper", "Developer", "Creator"})
        Me.cmbAccess.Location = New System.Drawing.Point(86, 186)
        Me.cmbAccess.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbAccess.Name = "cmbAccess"
        Me.cmbAccess.Size = New System.Drawing.Size(276, 28)
        Me.cmbAccess.TabIndex = 17
        '
        'tabMapList
        '
        Me.tabMapList.Controls.Add(Me.lstMaps)
        Me.tabMapList.Controls.Add(Me.btnMapReport)
        Me.tabMapList.Location = New System.Drawing.Point(4, 29)
        Me.tabMapList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabMapList.Name = "tabMapList"
        Me.tabMapList.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabMapList.Size = New System.Drawing.Size(379, 375)
        Me.tabMapList.TabIndex = 2
        Me.tabMapList.Text = "Lista de Mapas"
        Me.tabMapList.UseVisualStyleBackColor = True
        '
        'tabMapTools
        '
        Me.tabMapTools.Controls.Add(Me.nudSpawnItemAmount)
        Me.tabMapTools.Controls.Add(Me.cmbSpawnItem)
        Me.tabMapTools.Controls.Add(Me.btnRespawn)
        Me.tabMapTools.Controls.Add(Me.btnALoc)
        Me.tabMapTools.Controls.Add(Me.lblItemSpawn)
        Me.tabMapTools.Controls.Add(Me.lblSpawnItemAmount)
        Me.tabMapTools.Controls.Add(Me.btnSpawnItem)
        Me.tabMapTools.Location = New System.Drawing.Point(4, 29)
        Me.tabMapTools.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabMapTools.Name = "tabMapTools"
        Me.tabMapTools.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabMapTools.Size = New System.Drawing.Size(379, 375)
        Me.tabMapTools.TabIndex = 3
        Me.tabMapTools.Text = "Ferramentas de Mapa"
        Me.tabMapTools.UseVisualStyleBackColor = True
        '
        'nudSpawnItemAmount
        '
        Me.nudSpawnItemAmount.Location = New System.Drawing.Point(124, 183)
        Me.nudSpawnItemAmount.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudSpawnItemAmount.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.nudSpawnItemAmount.Name = "nudSpawnItemAmount"
        Me.nudSpawnItemAmount.Size = New System.Drawing.Size(238, 26)
        Me.nudSpawnItemAmount.TabIndex = 37
        '
        'cmbSpawnItem
        '
        Me.cmbSpawnItem.FormattingEnabled = True
        Me.cmbSpawnItem.Location = New System.Drawing.Point(124, 142)
        Me.cmbSpawnItem.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbSpawnItem.Name = "cmbSpawnItem"
        Me.cmbSpawnItem.Size = New System.Drawing.Size(236, 28)
        Me.cmbSpawnItem.TabIndex = 36
        '
        'tabEditors
        '
        Me.tabEditors.Controls.Add(Me.btnPetEditor)
        Me.tabEditors.Controls.Add(Me.btnAutoMapper)
        Me.tabEditors.Controls.Add(Me.btnClassEditor)
        Me.tabEditors.Controls.Add(Me.btnRecipeEditor)
        Me.tabEditors.Controls.Add(Me.btnProjectiles)
        Me.tabEditors.Controls.Add(Me.btnQuest)
        Me.tabEditors.Controls.Add(Me.btnhouseEditor)
        Me.tabEditors.Controls.Add(Me.btnMapEditor)
        Me.tabEditors.Controls.Add(Me.btnItemEditor)
        Me.tabEditors.Controls.Add(Me.btnResourceEditor)
        Me.tabEditors.Controls.Add(Me.btnNPCEditor)
        Me.tabEditors.Controls.Add(Me.btnSkillEditor)
        Me.tabEditors.Controls.Add(Me.btnShopEditor)
        Me.tabEditors.Controls.Add(Me.btnAnimationEditor)
        Me.tabEditors.Location = New System.Drawing.Point(4, 29)
        Me.tabEditors.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabEditors.Name = "tabEditors"
        Me.tabEditors.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabEditors.Size = New System.Drawing.Size(379, 375)
        Me.tabEditors.TabIndex = 4
        Me.tabEditors.Text = "Editores"
        Me.tabEditors.UseVisualStyleBackColor = True
        '
        'btnPetEditor
        '
        Me.btnPetEditor.Location = New System.Drawing.Point(195, 9)
        Me.btnPetEditor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnPetEditor.Name = "btnPetEditor"
        Me.btnPetEditor.Size = New System.Drawing.Size(168, 38)
        Me.btnPetEditor.TabIndex = 68
        Me.btnPetEditor.Text = "Editor de Pets"
        Me.btnPetEditor.UseVisualStyleBackColor = True
        '
        'btnAutoMapper
        '
        Me.btnAutoMapper.Location = New System.Drawing.Point(9, 200)
        Me.btnAutoMapper.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAutoMapper.Name = "btnAutoMapper"
        Me.btnAutoMapper.Size = New System.Drawing.Size(168, 38)
        Me.btnAutoMapper.TabIndex = 67
        Me.btnAutoMapper.Text = "Gerador de Mapas"
        Me.btnAutoMapper.UseVisualStyleBackColor = True
        '
        'btnClassEditor
        '
        Me.btnClassEditor.Location = New System.Drawing.Point(9, 57)
        Me.btnClassEditor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClassEditor.Name = "btnClassEditor"
        Me.btnClassEditor.Size = New System.Drawing.Size(168, 38)
        Me.btnClassEditor.TabIndex = 66
        Me.btnClassEditor.Text = "Editor de Classes"
        Me.btnClassEditor.UseVisualStyleBackColor = True
        '
        'btnRecipeEditor
        '
        Me.btnRecipeEditor.Location = New System.Drawing.Point(195, 152)
        Me.btnRecipeEditor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnRecipeEditor.Name = "btnRecipeEditor"
        Me.btnRecipeEditor.Size = New System.Drawing.Size(168, 38)
        Me.btnRecipeEditor.TabIndex = 65
        Me.btnRecipeEditor.Text = "Editor de Receitas"
        Me.btnRecipeEditor.UseVisualStyleBackColor = True
        '
        'btnProjectiles
        '
        Me.btnProjectiles.Location = New System.Drawing.Point(195, 57)
        Me.btnProjectiles.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnProjectiles.Name = "btnProjectiles"
        Me.btnProjectiles.Size = New System.Drawing.Size(168, 38)
        Me.btnProjectiles.TabIndex = 64
        Me.btnProjectiles.Text = "Editor de Projéteis"
        Me.btnProjectiles.UseVisualStyleBackColor = True
        '
        'btnQuest
        '
        Me.btnQuest.Location = New System.Drawing.Point(195, 105)
        Me.btnQuest.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnQuest.Name = "btnQuest"
        Me.btnQuest.Size = New System.Drawing.Size(168, 38)
        Me.btnQuest.TabIndex = 62
        Me.btnQuest.Text = "Editor de Tarefas"
        Me.btnQuest.UseVisualStyleBackColor = True
        '
        'btnhouseEditor
        '
        Me.btnhouseEditor.Location = New System.Drawing.Point(9, 105)
        Me.btnhouseEditor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnhouseEditor.Name = "btnhouseEditor"
        Me.btnhouseEditor.Size = New System.Drawing.Size(168, 38)
        Me.btnhouseEditor.TabIndex = 63
        Me.btnhouseEditor.Text = "Editor de Moradias"
        Me.btnhouseEditor.UseVisualStyleBackColor = True
        '
        'btnMapEditor
        '
        Me.btnMapEditor.Location = New System.Drawing.Point(9, 248)
        Me.btnMapEditor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnMapEditor.Name = "btnMapEditor"
        Me.btnMapEditor.Size = New System.Drawing.Size(168, 38)
        Me.btnMapEditor.TabIndex = 55
        Me.btnMapEditor.Text = "Editor de Mapas"
        Me.btnMapEditor.UseVisualStyleBackColor = True
        '
        'btnItemEditor
        '
        Me.btnItemEditor.Location = New System.Drawing.Point(9, 152)
        Me.btnItemEditor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnItemEditor.Name = "btnItemEditor"
        Me.btnItemEditor.Size = New System.Drawing.Size(168, 38)
        Me.btnItemEditor.TabIndex = 56
        Me.btnItemEditor.Text = "Editor de Itens"
        Me.btnItemEditor.UseVisualStyleBackColor = True
        '
        'btnResourceEditor
        '
        Me.btnResourceEditor.Location = New System.Drawing.Point(195, 200)
        Me.btnResourceEditor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnResourceEditor.Name = "btnResourceEditor"
        Me.btnResourceEditor.Size = New System.Drawing.Size(168, 38)
        Me.btnResourceEditor.TabIndex = 57
        Me.btnResourceEditor.Text = "Editor de Recursos"
        Me.btnResourceEditor.UseVisualStyleBackColor = True
        '
        'btnNPCEditor
        '
        Me.btnNPCEditor.Location = New System.Drawing.Point(9, 295)
        Me.btnNPCEditor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNPCEditor.Name = "btnNPCEditor"
        Me.btnNPCEditor.Size = New System.Drawing.Size(168, 70)
        Me.btnNPCEditor.TabIndex = 58
        Me.btnNPCEditor.Text = "Editor de NPCs"
        Me.btnNPCEditor.UseVisualStyleBackColor = True
        '
        'btnSkillEditor
        '
        Me.btnSkillEditor.Location = New System.Drawing.Point(195, 295)
        Me.btnSkillEditor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSkillEditor.Name = "btnSkillEditor"
        Me.btnSkillEditor.Size = New System.Drawing.Size(168, 70)
        Me.btnSkillEditor.TabIndex = 59
        Me.btnSkillEditor.Text = "Editor de Habilidades"
        Me.btnSkillEditor.UseVisualStyleBackColor = True
        '
        'btnShopEditor
        '
        Me.btnShopEditor.Location = New System.Drawing.Point(195, 248)
        Me.btnShopEditor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnShopEditor.Name = "btnShopEditor"
        Me.btnShopEditor.Size = New System.Drawing.Size(168, 38)
        Me.btnShopEditor.TabIndex = 60
        Me.btnShopEditor.Text = "Editor de Lojas"
        Me.btnShopEditor.UseVisualStyleBackColor = True
        '
        'btnAnimationEditor
        '
        Me.btnAnimationEditor.Location = New System.Drawing.Point(9, 9)
        Me.btnAnimationEditor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAnimationEditor.Name = "btnAnimationEditor"
        Me.btnAnimationEditor.Size = New System.Drawing.Size(168, 38)
        Me.btnAnimationEditor.TabIndex = 61
        Me.btnAnimationEditor.Text = "Editor de Animações"
        Me.btnAnimationEditor.UseVisualStyleBackColor = True
        '
        'FrmAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(390, 415)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAdmin"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Painel de Administração"
        Me.TabControl1.ResumeLayout(False)
        Me.tabModeration.ResumeLayout(False)
        Me.tabModeration.PerformLayout()
        CType(Me.nudAdminSprite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAdminMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMapList.ResumeLayout(False)
        Me.tabMapTools.ResumeLayout(False)
        Me.tabMapTools.PerformLayout()
        CType(Me.nudSpawnItemAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEditors.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnRespawn As Windows.Forms.Button
    Friend WithEvents btnMapReport As Windows.Forms.Button
    Friend WithEvents btnALoc As Windows.Forms.Button
    Friend WithEvents btnSpawnItem As Windows.Forms.Button
    Friend WithEvents lblSpawnItemAmount As Windows.Forms.Label
    Friend WithEvents lblItemSpawn As Windows.Forms.Label
    Friend WithEvents btnAdminSetSprite As Windows.Forms.Button
    Friend WithEvents btnAdminWarpTo As Windows.Forms.Button
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents btnAdminSetAccess As Windows.Forms.Button
    Friend WithEvents btnAdminWarpMe2 As Windows.Forms.Button
    Friend WithEvents btnAdminWarp2Me As Windows.Forms.Button
    Friend WithEvents btnAdminBan As Windows.Forms.Button
    Friend WithEvents btnAdminKick As Windows.Forms.Button
    Friend WithEvents txtAdminName As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents lstMaps As Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As Windows.Forms.ColumnHeader
    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents tabModeration As Windows.Forms.TabPage
    Friend WithEvents tabMapList As Windows.Forms.TabPage
    Friend WithEvents tabMapTools As Windows.Forms.TabPage
    Friend WithEvents cmbAccess As Windows.Forms.ComboBox
    Friend WithEvents cmbSpawnItem As Windows.Forms.ComboBox
    Friend WithEvents nudAdminSprite As Windows.Forms.NumericUpDown
    Friend WithEvents nudAdminMap As Windows.Forms.NumericUpDown
    Friend WithEvents btnLevelUp As Windows.Forms.Button
    Friend WithEvents nudSpawnItemAmount As Windows.Forms.NumericUpDown
    Friend WithEvents tabEditors As Windows.Forms.TabPage
    Friend WithEvents btnPetEditor As Windows.Forms.Button
    Friend WithEvents btnAutoMapper As Windows.Forms.Button
    Friend WithEvents btnClassEditor As Windows.Forms.Button
    Friend WithEvents btnRecipeEditor As Windows.Forms.Button
    Friend WithEvents btnProjectiles As Windows.Forms.Button
    Friend WithEvents btnQuest As Windows.Forms.Button
    Friend WithEvents btnhouseEditor As Windows.Forms.Button
    Friend WithEvents btnMapEditor As Windows.Forms.Button
    Friend WithEvents btnItemEditor As Windows.Forms.Button
    Friend WithEvents btnResourceEditor As Windows.Forms.Button
    Friend WithEvents btnNPCEditor As Windows.Forms.Button
    Friend WithEvents btnSkillEditor As Windows.Forms.Button
    Friend WithEvents btnShopEditor As Windows.Forms.Button
    Friend WithEvents btnAnimationEditor As Windows.Forms.Button
End Class
