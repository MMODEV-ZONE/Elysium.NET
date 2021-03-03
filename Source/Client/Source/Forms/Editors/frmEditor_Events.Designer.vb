Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEditor_Events
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Show Text")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Show Choices")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Add Chatbox Text")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Show ChatBubble")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mensagens", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4})
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Set Player Variable")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Set Player Switch")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Set Self Switch")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Processamento de Evento", New System.Windows.Forms.TreeNode() {TreeNode6, TreeNode7, TreeNode8})
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Conditional Branch")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Stop Event Processing")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Label")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("GoTo Label")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Controle de Fluxo", New System.Windows.Forms.TreeNode() {TreeNode10, TreeNode11, TreeNode12, TreeNode13})
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Change Items")
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Restore HP")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Restore MP")
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Level Up")
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Change Level")
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Change Skills")
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Change Class")
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Change Sprite")
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Change Gender")
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Change PK")
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Give Experience")
        Dim TreeNode26 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Opções do Jogador", New System.Windows.Forms.TreeNode() {TreeNode15, TreeNode16, TreeNode17, TreeNode18, TreeNode19, TreeNode20, TreeNode21, TreeNode22, TreeNode23, TreeNode24, TreeNode25})
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Warp Player")
        Dim TreeNode28 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Set Move Route")
        Dim TreeNode29 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Wait for Route Completion")
        Dim TreeNode30 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Force Spawn Npc")
        Dim TreeNode31 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Hold Player")
        Dim TreeNode32 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Release Player")
        Dim TreeNode33 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Movimento", New System.Windows.Forms.TreeNode() {TreeNode27, TreeNode28, TreeNode29, TreeNode30, TreeNode31, TreeNode32})
        Dim TreeNode34 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Animation")
        Dim TreeNode35 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Animação", New System.Windows.Forms.TreeNode() {TreeNode34})
        Dim TreeNode36 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Begin Quest")
        Dim TreeNode37 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Complete Task")
        Dim TreeNode38 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("End Quest")
        Dim TreeNode39 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tarefas", New System.Windows.Forms.TreeNode() {TreeNode36, TreeNode37, TreeNode38})
        Dim TreeNode40 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Set Fog")
        Dim TreeNode41 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Set Weather")
        Dim TreeNode42 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Set Map Tinting")
        Dim TreeNode43 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Funções de Mapa", New System.Windows.Forms.TreeNode() {TreeNode40, TreeNode41, TreeNode42})
        Dim TreeNode44 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Play BGM")
        Dim TreeNode45 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Stop BGM")
        Dim TreeNode46 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Play Sound")
        Dim TreeNode47 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Stop Sounds")
        Dim TreeNode48 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Músicas e Sons", New System.Windows.Forms.TreeNode() {TreeNode44, TreeNode45, TreeNode46, TreeNode47})
        Dim TreeNode49 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Wait...")
        Dim TreeNode50 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Set Access")
        Dim TreeNode51 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Custom Script")
        Dim TreeNode52 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Etc...", New System.Windows.Forms.TreeNode() {TreeNode49, TreeNode50, TreeNode51})
        Dim TreeNode53 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Open Bank")
        Dim TreeNode54 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Open Shop")
        Dim TreeNode55 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Loja e Banco", New System.Windows.Forms.TreeNode() {TreeNode53, TreeNode54})
        Dim TreeNode56 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Fade In")
        Dim TreeNode57 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Fade Out")
        Dim TreeNode58 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Opções de Cutscenes", New System.Windows.Forms.TreeNode() {TreeNode56, TreeNode57})
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Movement", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Wait", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Turning", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup4 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Speed", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup5 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Walk Animation", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup6 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Fixed Direction", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup7 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("WalkThrough", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup8 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Set Position", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup9 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Set Graphic", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Move Up")
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Move Down")
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Move left")
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Move Right")
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Move Randomly")
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Move To Player***")
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Move from Player***")
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Step Forwards")
        Dim ListViewItem9 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Step Backwards")
        Dim ListViewItem10 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Wait 100Ms")
        Dim ListViewItem11 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Wait 500Ms")
        Dim ListViewItem12 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Wait 1000Ms")
        Dim ListViewItem13 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Turn Up")
        Dim ListViewItem14 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Turn Down")
        Dim ListViewItem15 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Turn Left")
        Dim ListViewItem16 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Turn Right")
        Dim ListViewItem17 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Turn 90DG Right")
        Dim ListViewItem18 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Turn 90DG Left")
        Dim ListViewItem19 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Turn 180DG")
        Dim ListViewItem20 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Turn Randomly")
        Dim ListViewItem21 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Turn To Player***")
        Dim ListViewItem22 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Turn From Player***")
        Dim ListViewItem23 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Speed 8x Slower")
        Dim ListViewItem24 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Speed 4x Slower")
        Dim ListViewItem25 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Speed 2x Slower")
        Dim ListViewItem26 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Speed To Normal")
        Dim ListViewItem27 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Speed 2x Faster")
        Dim ListViewItem28 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Speed 4x Faster")
        Dim ListViewItem29 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Freq. To Lowest")
        Dim ListViewItem30 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Freq. To Lower")
        Dim ListViewItem31 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Freq. To Normal")
        Dim ListViewItem32 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Freq. To Higher")
        Dim ListViewItem33 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Freq. To Highest")
        Dim ListViewItem34 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Walking Animation ON")
        Dim ListViewItem35 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Walking Animation OFF")
        Dim ListViewItem36 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Fixed Direction ON")
        Dim ListViewItem37 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Fixed Direction OFF")
        Dim ListViewItem38 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Walkthrough ON")
        Dim ListViewItem39 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Walkthrough ON")
        Dim ListViewItem40 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Position Below Player")
        Dim ListViewItem41 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set PositionWith Player")
        Dim ListViewItem42 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Position Above Player")
        Dim ListViewItem43 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Graphic...")
        Me.tvCommands = New System.Windows.Forms.TreeView()
        Me.fraPageSetUp = New System.Windows.Forms.GroupBox()
        Me.chkGlobal = New System.Windows.Forms.CheckBox()
        Me.btnClearPage = New System.Windows.Forms.Button()
        Me.btnDeletePage = New System.Windows.Forms.Button()
        Me.btnPastePage = New System.Windows.Forms.Button()
        Me.btnCopyPage = New System.Windows.Forms.Button()
        Me.btnNewPage = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.DarkLabel1 = New System.Windows.Forms.Label()
        Me.tabPages = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.pnlTabPage = New System.Windows.Forms.Panel()
        Me.fraCommands = New System.Windows.Forms.Panel()
        Me.btnCancelCommand = New System.Windows.Forms.Button()
        Me.DarkGroupBox8 = New System.Windows.Forms.GroupBox()
        Me.btnClearCommand = New System.Windows.Forms.Button()
        Me.btnDeleteCommand = New System.Windows.Forms.Button()
        Me.btnEditCommand = New System.Windows.Forms.Button()
        Me.btnAddCommand = New System.Windows.Forms.Button()
        Me.lstCommands = New System.Windows.Forms.ListBox()
        Me.DarkLabel10 = New System.Windows.Forms.Label()
        Me.DarkLabel9 = New System.Windows.Forms.Label()
        Me.DarkGroupBox7 = New System.Windows.Forms.GroupBox()
        Me.cmbEventQuest = New System.Windows.Forms.ComboBox()
        Me.DarkLabel8 = New System.Windows.Forms.Label()
        Me.DarkGroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cmbTrigger = New System.Windows.Forms.ComboBox()
        Me.DarkGroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmbPositioning = New System.Windows.Forms.ComboBox()
        Me.DarkGroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DarkLabel7 = New System.Windows.Forms.Label()
        Me.cmbMoveFreq = New System.Windows.Forms.ComboBox()
        Me.DarkLabel6 = New System.Windows.Forms.Label()
        Me.cmbMoveSpeed = New System.Windows.Forms.ComboBox()
        Me.btnMoveRoute = New System.Windows.Forms.Button()
        Me.cmbMoveType = New System.Windows.Forms.ComboBox()
        Me.DarkLabel5 = New System.Windows.Forms.Label()
        Me.DarkGroupBox2 = New System.Windows.Forms.GroupBox()
        Me.picGraphic = New System.Windows.Forms.PictureBox()
        Me.DarkGroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbSelfSwitchCompare = New System.Windows.Forms.ComboBox()
        Me.DarkLabel4 = New System.Windows.Forms.Label()
        Me.cmbSelfSwitch = New System.Windows.Forms.ComboBox()
        Me.chkSelfSwitch = New System.Windows.Forms.CheckBox()
        Me.cmbHasItem = New System.Windows.Forms.ComboBox()
        Me.chkHasItem = New System.Windows.Forms.CheckBox()
        Me.cmbPlayerSwitchCompare = New System.Windows.Forms.ComboBox()
        Me.DarkLabel3 = New System.Windows.Forms.Label()
        Me.cmbPlayerSwitch = New System.Windows.Forms.ComboBox()
        Me.chkPlayerSwitch = New System.Windows.Forms.CheckBox()
        Me.nudPlayerVariable = New System.Windows.Forms.NumericUpDown()
        Me.cmbPlayervarCompare = New System.Windows.Forms.ComboBox()
        Me.DarkLabel2 = New System.Windows.Forms.Label()
        Me.cmbPlayerVar = New System.Windows.Forms.ComboBox()
        Me.chkPlayerVar = New System.Windows.Forms.CheckBox()
        Me.DarkGroupBox6 = New System.Windows.Forms.GroupBox()
        Me.chkShowName = New System.Windows.Forms.CheckBox()
        Me.chkWalkThrough = New System.Windows.Forms.CheckBox()
        Me.chkDirFix = New System.Windows.Forms.CheckBox()
        Me.chkWalkAnim = New System.Windows.Forms.CheckBox()
        Me.btnLabeling = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.fraMoveRoute = New System.Windows.Forms.GroupBox()
        Me.btnMoveRouteOk = New System.Windows.Forms.Button()
        Me.btnMoveRouteCancel = New System.Windows.Forms.Button()
        Me.chkRepeatRoute = New System.Windows.Forms.CheckBox()
        Me.chkIgnoreMove = New System.Windows.Forms.CheckBox()
        Me.DarkGroupBox10 = New System.Windows.Forms.GroupBox()
        Me.lstvwMoveRoute = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstMoveRoute = New System.Windows.Forms.ListBox()
        Me.cmbEvent = New System.Windows.Forms.ComboBox()
        Me.fraGraphic = New System.Windows.Forms.GroupBox()
        Me.pnlGraphicSel = New System.Windows.Forms.Panel()
        Me.picGraphicSel = New System.Windows.Forms.PictureBox()
        Me.btnGraphicOk = New System.Windows.Forms.Button()
        Me.btnGraphicCancel = New System.Windows.Forms.Button()
        Me.DarkLabel13 = New System.Windows.Forms.Label()
        Me.nudGraphic = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel12 = New System.Windows.Forms.Label()
        Me.cmbGraphic = New System.Windows.Forms.ComboBox()
        Me.DarkLabel11 = New System.Windows.Forms.Label()
        Me.fraDialogue = New System.Windows.Forms.GroupBox()
        Me.fraConditionalBranch = New System.Windows.Forms.GroupBox()
        Me.cmbCondition_Time = New System.Windows.Forms.ComboBox()
        Me.optCondition9 = New System.Windows.Forms.RadioButton()
        Me.btnConditionalBranchOk = New System.Windows.Forms.Button()
        Me.btnConditionalBranchCancel = New System.Windows.Forms.Button()
        Me.cmbCondition_Gender = New System.Windows.Forms.ComboBox()
        Me.optCondition8 = New System.Windows.Forms.RadioButton()
        Me.fraConditions_Quest = New System.Windows.Forms.GroupBox()
        Me.DarkLabel20 = New System.Windows.Forms.Label()
        Me.nudCondition_QuestTask = New System.Windows.Forms.NumericUpDown()
        Me.cmbCondition_General = New System.Windows.Forms.ComboBox()
        Me.DarkLabel19 = New System.Windows.Forms.Label()
        Me.optCondition_Quest1 = New System.Windows.Forms.RadioButton()
        Me.optCondition_Quest0 = New System.Windows.Forms.RadioButton()
        Me.nudCondition_Quest = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel18 = New System.Windows.Forms.Label()
        Me.optCondition7 = New System.Windows.Forms.RadioButton()
        Me.cmbCondition_SelfSwitchCondition = New System.Windows.Forms.ComboBox()
        Me.DarkLabel17 = New System.Windows.Forms.Label()
        Me.cmbCondition_SelfSwitch = New System.Windows.Forms.ComboBox()
        Me.optCondition6 = New System.Windows.Forms.RadioButton()
        Me.nudCondition_LevelAmount = New System.Windows.Forms.NumericUpDown()
        Me.optCondition5 = New System.Windows.Forms.RadioButton()
        Me.cmbCondition_LevelCompare = New System.Windows.Forms.ComboBox()
        Me.cmbCondition_LearntSkill = New System.Windows.Forms.ComboBox()
        Me.optCondition4 = New System.Windows.Forms.RadioButton()
        Me.cmbCondition_ClassIs = New System.Windows.Forms.ComboBox()
        Me.optCondition3 = New System.Windows.Forms.RadioButton()
        Me.nudCondition_HasItem = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel16 = New System.Windows.Forms.Label()
        Me.cmbCondition_HasItem = New System.Windows.Forms.ComboBox()
        Me.optCondition2 = New System.Windows.Forms.RadioButton()
        Me.optCondition1 = New System.Windows.Forms.RadioButton()
        Me.DarkLabel15 = New System.Windows.Forms.Label()
        Me.cmbCondtion_PlayerSwitchCondition = New System.Windows.Forms.ComboBox()
        Me.cmbCondition_PlayerSwitch = New System.Windows.Forms.ComboBox()
        Me.nudCondition_PlayerVarCondition = New System.Windows.Forms.NumericUpDown()
        Me.cmbCondition_PlayerVarCompare = New System.Windows.Forms.ComboBox()
        Me.DarkLabel14 = New System.Windows.Forms.Label()
        Me.cmbCondition_PlayerVarIndex = New System.Windows.Forms.ComboBox()
        Me.optCondition0 = New System.Windows.Forms.RadioButton()
        Me.fraPlayAnimation = New System.Windows.Forms.GroupBox()
        Me.btnPlayAnimationOk = New System.Windows.Forms.Button()
        Me.btnPlayAnimationCancel = New System.Windows.Forms.Button()
        Me.lblPlayAnimY = New System.Windows.Forms.Label()
        Me.lblPlayAnimX = New System.Windows.Forms.Label()
        Me.cmbPlayAnimEvent = New System.Windows.Forms.ComboBox()
        Me.DarkLabel62 = New System.Windows.Forms.Label()
        Me.cmbAnimTargetType = New System.Windows.Forms.ComboBox()
        Me.nudPlayAnimTileY = New System.Windows.Forms.NumericUpDown()
        Me.nudPlayAnimTileX = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel61 = New System.Windows.Forms.Label()
        Me.cmbPlayAnim = New System.Windows.Forms.ComboBox()
        Me.fraMoveRouteWait = New System.Windows.Forms.GroupBox()
        Me.btnMoveWaitCancel = New System.Windows.Forms.Button()
        Me.btnMoveWaitOk = New System.Windows.Forms.Button()
        Me.DarkLabel79 = New System.Windows.Forms.Label()
        Me.cmbMoveWait = New System.Windows.Forms.ComboBox()
        Me.fraCustomScript = New System.Windows.Forms.GroupBox()
        Me.nudCustomScript = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel78 = New System.Windows.Forms.Label()
        Me.btnCustomScriptCancel = New System.Windows.Forms.Button()
        Me.btnCustomScriptOk = New System.Windows.Forms.Button()
        Me.fraSetWeather = New System.Windows.Forms.GroupBox()
        Me.btnSetWeatherOk = New System.Windows.Forms.Button()
        Me.btnSetWeatherCancel = New System.Windows.Forms.Button()
        Me.DarkLabel76 = New System.Windows.Forms.Label()
        Me.nudWeatherIntensity = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel75 = New System.Windows.Forms.Label()
        Me.CmbWeather = New System.Windows.Forms.ComboBox()
        Me.fraSpawnNpc = New System.Windows.Forms.GroupBox()
        Me.btnSpawnNpcOk = New System.Windows.Forms.Button()
        Me.btnSpawnNpcCancel = New System.Windows.Forms.Button()
        Me.cmbSpawnNpc = New System.Windows.Forms.ComboBox()
        Me.fraGiveExp = New System.Windows.Forms.GroupBox()
        Me.btnGiveExpOk = New System.Windows.Forms.Button()
        Me.btnGiveExpCancel = New System.Windows.Forms.Button()
        Me.nudGiveExp = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel77 = New System.Windows.Forms.Label()
        Me.fraEndQuest = New System.Windows.Forms.GroupBox()
        Me.btnEndQuestOk = New System.Windows.Forms.Button()
        Me.btnEndQuestCancel = New System.Windows.Forms.Button()
        Me.cmbEndQuest = New System.Windows.Forms.ComboBox()
        Me.fraSetAccess = New System.Windows.Forms.GroupBox()
        Me.btnSetAccessOk = New System.Windows.Forms.Button()
        Me.btnSetAccessCancel = New System.Windows.Forms.Button()
        Me.cmbSetAccess = New System.Windows.Forms.ComboBox()
        Me.fraSetWait = New System.Windows.Forms.GroupBox()
        Me.btnSetWaitOk = New System.Windows.Forms.Button()
        Me.btnSetWaitCancel = New System.Windows.Forms.Button()
        Me.DarkLabel74 = New System.Windows.Forms.Label()
        Me.DarkLabel72 = New System.Windows.Forms.Label()
        Me.DarkLabel73 = New System.Windows.Forms.Label()
        Me.nudWaitAmount = New System.Windows.Forms.NumericUpDown()
        Me.fraShowPic = New System.Windows.Forms.GroupBox()
        Me.btnShowPicOk = New System.Windows.Forms.Button()
        Me.btnShowPicCancel = New System.Windows.Forms.Button()
        Me.DarkLabel71 = New System.Windows.Forms.Label()
        Me.DarkLabel70 = New System.Windows.Forms.Label()
        Me.DarkLabel67 = New System.Windows.Forms.Label()
        Me.DarkLabel68 = New System.Windows.Forms.Label()
        Me.nudPicOffsetY = New System.Windows.Forms.NumericUpDown()
        Me.nudPicOffsetX = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel69 = New System.Windows.Forms.Label()
        Me.cmbPicLoc = New System.Windows.Forms.ComboBox()
        Me.nudShowPicture = New System.Windows.Forms.NumericUpDown()
        Me.picShowPic = New System.Windows.Forms.PictureBox()
        Me.cmbPicIndex = New System.Windows.Forms.ComboBox()
        Me.DarkLabel66 = New System.Windows.Forms.Label()
        Me.fraOpenShop = New System.Windows.Forms.GroupBox()
        Me.btnOpenShopOk = New System.Windows.Forms.Button()
        Me.btnOpenShopCancel = New System.Windows.Forms.Button()
        Me.cmbOpenShop = New System.Windows.Forms.ComboBox()
        Me.fraChangeLevel = New System.Windows.Forms.GroupBox()
        Me.btnChangeLevelOk = New System.Windows.Forms.Button()
        Me.btnChangeLevelCancel = New System.Windows.Forms.Button()
        Me.DarkLabel65 = New System.Windows.Forms.Label()
        Me.nudChangeLevel = New System.Windows.Forms.NumericUpDown()
        Me.fraChangeGender = New System.Windows.Forms.GroupBox()
        Me.btnChangeGenderOk = New System.Windows.Forms.Button()
        Me.btnChangeGenderCancel = New System.Windows.Forms.Button()
        Me.optChangeSexFemale = New System.Windows.Forms.RadioButton()
        Me.optChangeSexMale = New System.Windows.Forms.RadioButton()
        Me.fraGoToLabel = New System.Windows.Forms.GroupBox()
        Me.btnGoToLabelOk = New System.Windows.Forms.Button()
        Me.btnGoToLabelCancel = New System.Windows.Forms.Button()
        Me.txtGotoLabel = New System.Windows.Forms.TextBox()
        Me.DarkLabel60 = New System.Windows.Forms.Label()
        Me.fraHidePic = New System.Windows.Forms.GroupBox()
        Me.btnHidePicOk = New System.Windows.Forms.Button()
        Me.btnHidePicCancel = New System.Windows.Forms.Button()
        Me.nudHidePic = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel59 = New System.Windows.Forms.Label()
        Me.fraBeginQuest = New System.Windows.Forms.GroupBox()
        Me.btnBeginQuestOk = New System.Windows.Forms.Button()
        Me.btnBeginQuestCancel = New System.Windows.Forms.Button()
        Me.cmbBeginQuest = New System.Windows.Forms.ComboBox()
        Me.DarkLabel58 = New System.Windows.Forms.Label()
        Me.fraShowChoices = New System.Windows.Forms.GroupBox()
        Me.txtChoices4 = New System.Windows.Forms.TextBox()
        Me.txtChoices3 = New System.Windows.Forms.TextBox()
        Me.txtChoices2 = New System.Windows.Forms.TextBox()
        Me.txtChoices1 = New System.Windows.Forms.TextBox()
        Me.DarkLabel56 = New System.Windows.Forms.Label()
        Me.DarkLabel57 = New System.Windows.Forms.Label()
        Me.DarkLabel55 = New System.Windows.Forms.Label()
        Me.DarkLabel54 = New System.Windows.Forms.Label()
        Me.DarkLabel52 = New System.Windows.Forms.Label()
        Me.txtChoicePrompt = New System.Windows.Forms.TextBox()
        Me.btnShowChoicesOk = New System.Windows.Forms.Button()
        Me.picShowChoicesFace = New System.Windows.Forms.PictureBox()
        Me.btnShowChoicesCancel = New System.Windows.Forms.Button()
        Me.DarkLabel53 = New System.Windows.Forms.Label()
        Me.nudShowChoicesFace = New System.Windows.Forms.NumericUpDown()
        Me.fraPlayerVariable = New System.Windows.Forms.GroupBox()
        Me.nudVariableData2 = New System.Windows.Forms.NumericUpDown()
        Me.optVariableAction2 = New System.Windows.Forms.RadioButton()
        Me.btnPlayerVarOk = New System.Windows.Forms.Button()
        Me.btnPlayerVarCancel = New System.Windows.Forms.Button()
        Me.DarkLabel51 = New System.Windows.Forms.Label()
        Me.DarkLabel50 = New System.Windows.Forms.Label()
        Me.nudVariableData4 = New System.Windows.Forms.NumericUpDown()
        Me.nudVariableData3 = New System.Windows.Forms.NumericUpDown()
        Me.optVariableAction3 = New System.Windows.Forms.RadioButton()
        Me.optVariableAction1 = New System.Windows.Forms.RadioButton()
        Me.nudVariableData1 = New System.Windows.Forms.NumericUpDown()
        Me.nudVariableData0 = New System.Windows.Forms.NumericUpDown()
        Me.optVariableAction0 = New System.Windows.Forms.RadioButton()
        Me.cmbVariable = New System.Windows.Forms.ComboBox()
        Me.DarkLabel49 = New System.Windows.Forms.Label()
        Me.fraChangeSprite = New System.Windows.Forms.GroupBox()
        Me.btnChangeSpriteOk = New System.Windows.Forms.Button()
        Me.btnChangeSpriteCancel = New System.Windows.Forms.Button()
        Me.DarkLabel48 = New System.Windows.Forms.Label()
        Me.nudChangeSprite = New System.Windows.Forms.NumericUpDown()
        Me.picChangeSprite = New System.Windows.Forms.PictureBox()
        Me.fraSetSelfSwitch = New System.Windows.Forms.GroupBox()
        Me.btnSelfswitchOk = New System.Windows.Forms.Button()
        Me.btnSelfswitchCancel = New System.Windows.Forms.Button()
        Me.DarkLabel47 = New System.Windows.Forms.Label()
        Me.cmbSetSelfSwitchTo = New System.Windows.Forms.ComboBox()
        Me.DarkLabel46 = New System.Windows.Forms.Label()
        Me.cmbSetSelfSwitch = New System.Windows.Forms.ComboBox()
        Me.fraMapTint = New System.Windows.Forms.GroupBox()
        Me.btnMapTintOk = New System.Windows.Forms.Button()
        Me.btnMapTintCancel = New System.Windows.Forms.Button()
        Me.DarkLabel42 = New System.Windows.Forms.Label()
        Me.nudMapTintData3 = New System.Windows.Forms.NumericUpDown()
        Me.nudMapTintData2 = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel43 = New System.Windows.Forms.Label()
        Me.DarkLabel44 = New System.Windows.Forms.Label()
        Me.nudMapTintData1 = New System.Windows.Forms.NumericUpDown()
        Me.nudMapTintData0 = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel45 = New System.Windows.Forms.Label()
        Me.fraShowChatBubble = New System.Windows.Forms.GroupBox()
        Me.btnShowChatBubbleOk = New System.Windows.Forms.Button()
        Me.btnShowChatBubbleCancel = New System.Windows.Forms.Button()
        Me.DarkLabel41 = New System.Windows.Forms.Label()
        Me.cmbChatBubbleTarget = New System.Windows.Forms.ComboBox()
        Me.cmbChatBubbleTargetType = New System.Windows.Forms.ComboBox()
        Me.DarkLabel40 = New System.Windows.Forms.Label()
        Me.txtChatbubbleText = New System.Windows.Forms.TextBox()
        Me.DarkLabel39 = New System.Windows.Forms.Label()
        Me.fraPlaySound = New System.Windows.Forms.GroupBox()
        Me.btnPlaySoundOk = New System.Windows.Forms.Button()
        Me.btnPlaySoundCancel = New System.Windows.Forms.Button()
        Me.cmbPlaySound = New System.Windows.Forms.ComboBox()
        Me.fraChangePK = New System.Windows.Forms.GroupBox()
        Me.btnChangePkOk = New System.Windows.Forms.Button()
        Me.btnChangePkCancel = New System.Windows.Forms.Button()
        Me.cmbSetPK = New System.Windows.Forms.ComboBox()
        Me.fraCreateLabel = New System.Windows.Forms.GroupBox()
        Me.btnCreatelabelOk = New System.Windows.Forms.Button()
        Me.btnCreatelabelCancel = New System.Windows.Forms.Button()
        Me.txtLabelName = New System.Windows.Forms.TextBox()
        Me.lblLabelName = New System.Windows.Forms.Label()
        Me.fraChangeClass = New System.Windows.Forms.GroupBox()
        Me.btnChangeClassOk = New System.Windows.Forms.Button()
        Me.btnChangeClassCancel = New System.Windows.Forms.Button()
        Me.cmbChangeClass = New System.Windows.Forms.ComboBox()
        Me.DarkLabel38 = New System.Windows.Forms.Label()
        Me.fraChangeSkills = New System.Windows.Forms.GroupBox()
        Me.btnChangeSkillsOk = New System.Windows.Forms.Button()
        Me.btnChangeSkillsCancel = New System.Windows.Forms.Button()
        Me.optChangeSkillsRemove = New System.Windows.Forms.RadioButton()
        Me.optChangeSkillsAdd = New System.Windows.Forms.RadioButton()
        Me.cmbChangeSkills = New System.Windows.Forms.ComboBox()
        Me.DarkLabel37 = New System.Windows.Forms.Label()
        Me.fraCompleteTask = New System.Windows.Forms.GroupBox()
        Me.btnCompleteQuestTaskOk = New System.Windows.Forms.Button()
        Me.btnCompleteQuestTaskCancel = New System.Windows.Forms.Button()
        Me.DarkLabel35 = New System.Windows.Forms.Label()
        Me.DarkLabel36 = New System.Windows.Forms.Label()
        Me.nudCompleteQuestTask = New System.Windows.Forms.NumericUpDown()
        Me.cmbCompleteQuest = New System.Windows.Forms.ComboBox()
        Me.fraPlayerWarp = New System.Windows.Forms.GroupBox()
        Me.btnPlayerWarpOk = New System.Windows.Forms.Button()
        Me.btnPlayerWarpCancel = New System.Windows.Forms.Button()
        Me.DarkLabel31 = New System.Windows.Forms.Label()
        Me.cmbWarpPlayerDir = New System.Windows.Forms.ComboBox()
        Me.nudWPY = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel32 = New System.Windows.Forms.Label()
        Me.nudWPX = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel33 = New System.Windows.Forms.Label()
        Me.nudWPMap = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel34 = New System.Windows.Forms.Label()
        Me.fraSetFog = New System.Windows.Forms.GroupBox()
        Me.btnSetFogOk = New System.Windows.Forms.Button()
        Me.btnSetFogCancel = New System.Windows.Forms.Button()
        Me.DarkLabel30 = New System.Windows.Forms.Label()
        Me.DarkLabel29 = New System.Windows.Forms.Label()
        Me.DarkLabel28 = New System.Windows.Forms.Label()
        Me.nudFogData2 = New System.Windows.Forms.NumericUpDown()
        Me.nudFogData1 = New System.Windows.Forms.NumericUpDown()
        Me.nudFogData0 = New System.Windows.Forms.NumericUpDown()
        Me.fraShowText = New System.Windows.Forms.GroupBox()
        Me.DarkLabel27 = New System.Windows.Forms.Label()
        Me.txtShowText = New System.Windows.Forms.TextBox()
        Me.btnShowTextCancel = New System.Windows.Forms.Button()
        Me.btnShowTextOk = New System.Windows.Forms.Button()
        Me.picShowTextFace = New System.Windows.Forms.PictureBox()
        Me.DarkLabel26 = New System.Windows.Forms.Label()
        Me.nudShowTextFace = New System.Windows.Forms.NumericUpDown()
        Me.fraAddText = New System.Windows.Forms.GroupBox()
        Me.btnAddTextOk = New System.Windows.Forms.Button()
        Me.btnAddTextCancel = New System.Windows.Forms.Button()
        Me.optAddText_Global = New System.Windows.Forms.RadioButton()
        Me.optAddText_Map = New System.Windows.Forms.RadioButton()
        Me.optAddText_Player = New System.Windows.Forms.RadioButton()
        Me.DarkLabel25 = New System.Windows.Forms.Label()
        Me.txtAddText_Text = New System.Windows.Forms.TextBox()
        Me.DarkLabel24 = New System.Windows.Forms.Label()
        Me.fraPlayerSwitch = New System.Windows.Forms.GroupBox()
        Me.btnSetPlayerSwitchOk = New System.Windows.Forms.Button()
        Me.btnSetPlayerswitchCancel = New System.Windows.Forms.Button()
        Me.cmbPlayerSwitchSet = New System.Windows.Forms.ComboBox()
        Me.DarkLabel23 = New System.Windows.Forms.Label()
        Me.cmbSwitch = New System.Windows.Forms.ComboBox()
        Me.DarkLabel22 = New System.Windows.Forms.Label()
        Me.fraChangeItems = New System.Windows.Forms.GroupBox()
        Me.btnChangeItemsOk = New System.Windows.Forms.Button()
        Me.btnChangeItemsCancel = New System.Windows.Forms.Button()
        Me.nudChangeItemsAmount = New System.Windows.Forms.NumericUpDown()
        Me.optChangeItemRemove = New System.Windows.Forms.RadioButton()
        Me.optChangeItemAdd = New System.Windows.Forms.RadioButton()
        Me.optChangeItemSet = New System.Windows.Forms.RadioButton()
        Me.cmbChangeItemIndex = New System.Windows.Forms.ComboBox()
        Me.DarkLabel21 = New System.Windows.Forms.Label()
        Me.fraPlayBGM = New System.Windows.Forms.GroupBox()
        Me.btnPlayBgmOk = New System.Windows.Forms.Button()
        Me.btnPlayBgmCancel = New System.Windows.Forms.Button()
        Me.cmbPlayBGM = New System.Windows.Forms.ComboBox()
        Me.pnlVariableSwitches = New System.Windows.Forms.Panel()
        Me.FraRenaming = New System.Windows.Forms.GroupBox()
        Me.btnRename_Cancel = New System.Windows.Forms.Button()
        Me.btnRename_Ok = New System.Windows.Forms.Button()
        Me.fraRandom10 = New System.Windows.Forms.GroupBox()
        Me.txtRename = New System.Windows.Forms.TextBox()
        Me.lblEditing = New System.Windows.Forms.Label()
        Me.fraLabeling = New System.Windows.Forms.GroupBox()
        Me.lstSwitches = New System.Windows.Forms.ListBox()
        Me.lstVariables = New System.Windows.Forms.ListBox()
        Me.btnLabel_Cancel = New System.Windows.Forms.Button()
        Me.lblRandomLabel36 = New System.Windows.Forms.Label()
        Me.btnRenameVariable = New System.Windows.Forms.Button()
        Me.lblRandomLabel25 = New System.Windows.Forms.Label()
        Me.btnRenameSwitch = New System.Windows.Forms.Button()
        Me.btnLabel_Ok = New System.Windows.Forms.Button()
        Me.fraPageSetUp.SuspendLayout()
        Me.tabPages.SuspendLayout()
        Me.pnlTabPage.SuspendLayout()
        Me.fraCommands.SuspendLayout()
        Me.DarkGroupBox8.SuspendLayout()
        Me.DarkGroupBox7.SuspendLayout()
        Me.DarkGroupBox5.SuspendLayout()
        Me.DarkGroupBox4.SuspendLayout()
        Me.DarkGroupBox3.SuspendLayout()
        Me.DarkGroupBox2.SuspendLayout()
        CType(Me.picGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DarkGroupBox1.SuspendLayout()
        CType(Me.nudPlayerVariable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DarkGroupBox6.SuspendLayout()
        Me.fraMoveRoute.SuspendLayout()
        Me.DarkGroupBox10.SuspendLayout()
        Me.fraGraphic.SuspendLayout()
        Me.pnlGraphicSel.SuspendLayout()
        CType(Me.picGraphicSel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraDialogue.SuspendLayout()
        Me.fraConditionalBranch.SuspendLayout()
        Me.fraConditions_Quest.SuspendLayout()
        CType(Me.nudCondition_QuestTask, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCondition_Quest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCondition_LevelAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCondition_HasItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCondition_PlayerVarCondition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraPlayAnimation.SuspendLayout()
        CType(Me.nudPlayAnimTileY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPlayAnimTileX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraMoveRouteWait.SuspendLayout()
        Me.fraCustomScript.SuspendLayout()
        CType(Me.nudCustomScript, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraSetWeather.SuspendLayout()
        CType(Me.nudWeatherIntensity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraSpawnNpc.SuspendLayout()
        Me.fraGiveExp.SuspendLayout()
        CType(Me.nudGiveExp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraEndQuest.SuspendLayout()
        Me.fraSetAccess.SuspendLayout()
        Me.fraSetWait.SuspendLayout()
        CType(Me.nudWaitAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraShowPic.SuspendLayout()
        CType(Me.nudPicOffsetY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPicOffsetX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudShowPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picShowPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraOpenShop.SuspendLayout()
        Me.fraChangeLevel.SuspendLayout()
        CType(Me.nudChangeLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraChangeGender.SuspendLayout()
        Me.fraGoToLabel.SuspendLayout()
        Me.fraHidePic.SuspendLayout()
        CType(Me.nudHidePic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraBeginQuest.SuspendLayout()
        Me.fraShowChoices.SuspendLayout()
        CType(Me.picShowChoicesFace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudShowChoicesFace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraPlayerVariable.SuspendLayout()
        CType(Me.nudVariableData2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudVariableData4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudVariableData3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudVariableData1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudVariableData0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraChangeSprite.SuspendLayout()
        CType(Me.nudChangeSprite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picChangeSprite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraSetSelfSwitch.SuspendLayout()
        Me.fraMapTint.SuspendLayout()
        CType(Me.nudMapTintData3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMapTintData2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMapTintData1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMapTintData0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraShowChatBubble.SuspendLayout()
        Me.fraPlaySound.SuspendLayout()
        Me.fraChangePK.SuspendLayout()
        Me.fraCreateLabel.SuspendLayout()
        Me.fraChangeClass.SuspendLayout()
        Me.fraChangeSkills.SuspendLayout()
        Me.fraCompleteTask.SuspendLayout()
        CType(Me.nudCompleteQuestTask, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraPlayerWarp.SuspendLayout()
        CType(Me.nudWPY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudWPX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudWPMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraSetFog.SuspendLayout()
        CType(Me.nudFogData2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudFogData1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudFogData0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraShowText.SuspendLayout()
        CType(Me.picShowTextFace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudShowTextFace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraAddText.SuspendLayout()
        Me.fraPlayerSwitch.SuspendLayout()
        Me.fraChangeItems.SuspendLayout()
        CType(Me.nudChangeItemsAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraPlayBGM.SuspendLayout()
        Me.pnlVariableSwitches.SuspendLayout()
        Me.FraRenaming.SuspendLayout()
        Me.fraRandom10.SuspendLayout()
        Me.fraLabeling.SuspendLayout()
        Me.SuspendLayout()
        '
        'tvCommands
        '
        Me.tvCommands.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.tvCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvCommands.ForeColor = System.Drawing.Color.Gainsboro
        Me.tvCommands.Location = New System.Drawing.Point(8, 4)
        Me.tvCommands.Margin = New System.Windows.Forms.Padding(4)
        Me.tvCommands.Name = "tvCommands"
        TreeNode1.Name = "Node1"
        TreeNode1.Text = "Show Text"
        TreeNode2.Name = "Node2"
        TreeNode2.Text = "Show Choices"
        TreeNode3.Name = "Node3"
        TreeNode3.Text = "Add Chatbox Text"
        TreeNode4.Name = "Node5"
        TreeNode4.Text = "Show ChatBubble"
        TreeNode5.Name = "NodeMessages"
        TreeNode5.Text = "Mensagens"
        TreeNode6.Name = "Node1"
        TreeNode6.Text = "Set Player Variable"
        TreeNode7.Name = "Node2"
        TreeNode7.Text = "Set Player Switch"
        TreeNode8.Name = "Node3"
        TreeNode8.Text = "Set Self Switch"
        TreeNode9.Name = "NodeProcessing"
        TreeNode9.Text = "Processamento de Evento"
        TreeNode10.Name = "Node1"
        TreeNode10.Text = "Conditional Branch"
        TreeNode11.Name = "Node2"
        TreeNode11.Text = "Stop Event Processing"
        TreeNode12.Name = "Node3"
        TreeNode12.Text = "Label"
        TreeNode13.Name = "Node4"
        TreeNode13.Text = "GoTo Label"
        TreeNode14.Name = "NodeFlowControl"
        TreeNode14.Text = "Controle de Fluxo"
        TreeNode15.Name = "Node1"
        TreeNode15.Text = "Change Items"
        TreeNode16.Name = "Node2"
        TreeNode16.Text = "Restore HP"
        TreeNode17.Name = "Node3"
        TreeNode17.Text = "Restore MP"
        TreeNode18.Name = "Node4"
        TreeNode18.Text = "Level Up"
        TreeNode19.Name = "Node5"
        TreeNode19.Text = "Change Level"
        TreeNode20.Name = "Node6"
        TreeNode20.Text = "Change Skills"
        TreeNode21.Name = "Node7"
        TreeNode21.Text = "Change Class"
        TreeNode22.Name = "Node8"
        TreeNode22.Text = "Change Sprite"
        TreeNode23.Name = "Node9"
        TreeNode23.Text = "Change Gender"
        TreeNode24.Name = "Node10"
        TreeNode24.Text = "Change PK"
        TreeNode25.Name = "Node11"
        TreeNode25.Text = "Give Experience"
        TreeNode26.Name = "NodePlayerOptions"
        TreeNode26.Text = "Opções do Jogador"
        TreeNode27.Name = "Node1"
        TreeNode27.Text = "Warp Player"
        TreeNode28.Name = "Node2"
        TreeNode28.Text = "Set Move Route"
        TreeNode29.Name = "Node3"
        TreeNode29.Text = "Wait for Route Completion"
        TreeNode30.Name = "Node4"
        TreeNode30.Text = "Force Spawn Npc"
        TreeNode31.Name = "Node5"
        TreeNode31.Text = "Hold Player"
        TreeNode32.Name = "Node6"
        TreeNode32.Text = "Release Player"
        TreeNode33.Name = "NodeMovement"
        TreeNode33.Text = "Movimento"
        TreeNode34.Name = "Node1"
        TreeNode34.Text = "Animation"
        TreeNode35.Name = "NodeAnimation"
        TreeNode35.Text = "Animação"
        TreeNode36.Name = "Node1"
        TreeNode36.Text = "Begin Quest"
        TreeNode37.Name = "Node2"
        TreeNode37.Text = "Complete Task"
        TreeNode38.Name = "Node3"
        TreeNode38.Text = "End Quest"
        TreeNode39.Name = "NodeQuesting"
        TreeNode39.Text = "Tarefas"
        TreeNode40.Name = "Node1"
        TreeNode40.Text = "Set Fog"
        TreeNode41.Name = "Node2"
        TreeNode41.Text = "Set Weather"
        TreeNode42.Name = "Node3"
        TreeNode42.Text = "Set Map Tinting"
        TreeNode43.Name = "NodeMapFunctions"
        TreeNode43.Text = "Funções de Mapa"
        TreeNode44.Name = "Node1"
        TreeNode44.Text = "Play BGM"
        TreeNode45.Name = "Node2"
        TreeNode45.Text = "Stop BGM"
        TreeNode46.Name = "Node3"
        TreeNode46.Text = "Play Sound"
        TreeNode47.Name = "Node4"
        TreeNode47.Text = "Stop Sounds"
        TreeNode48.Name = "NodeSound"
        TreeNode48.Text = "Músicas e Sons"
        TreeNode49.Name = "Node1"
        TreeNode49.Text = "Wait..."
        TreeNode50.Name = "Node2"
        TreeNode50.Text = "Set Access"
        TreeNode51.Name = "Node3"
        TreeNode51.Text = "Custom Script"
        TreeNode52.Name = "NodeEtc"
        TreeNode52.Text = "Etc..."
        TreeNode53.Name = "Node1"
        TreeNode53.Text = "Open Bank"
        TreeNode54.Name = "Node2"
        TreeNode54.Text = "Open Shop"
        TreeNode55.Name = "NodeShopBank"
        TreeNode55.Text = "Loja e Banco"
        TreeNode56.Name = "Node1"
        TreeNode56.Text = "Fade In"
        TreeNode57.Name = "Node2"
        TreeNode57.Text = "Fade Out"
        TreeNode58.Name = "Node0"
        TreeNode58.Text = "Opções de Cutscenes"
        Me.tvCommands.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode9, TreeNode14, TreeNode26, TreeNode33, TreeNode35, TreeNode39, TreeNode43, TreeNode48, TreeNode52, TreeNode55, TreeNode58})
        Me.tvCommands.Size = New System.Drawing.Size(507, 544)
        Me.tvCommands.TabIndex = 1
        '
        'fraPageSetUp
        '
        Me.fraPageSetUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraPageSetUp.Controls.Add(Me.chkGlobal)
        Me.fraPageSetUp.Controls.Add(Me.btnClearPage)
        Me.fraPageSetUp.Controls.Add(Me.btnDeletePage)
        Me.fraPageSetUp.Controls.Add(Me.btnPastePage)
        Me.fraPageSetUp.Controls.Add(Me.btnCopyPage)
        Me.fraPageSetUp.Controls.Add(Me.btnNewPage)
        Me.fraPageSetUp.Controls.Add(Me.txtName)
        Me.fraPageSetUp.Controls.Add(Me.DarkLabel1)
        Me.fraPageSetUp.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraPageSetUp.Location = New System.Drawing.Point(4, 4)
        Me.fraPageSetUp.Margin = New System.Windows.Forms.Padding(4)
        Me.fraPageSetUp.Name = "fraPageSetUp"
        Me.fraPageSetUp.Padding = New System.Windows.Forms.Padding(4)
        Me.fraPageSetUp.Size = New System.Drawing.Size(1054, 62)
        Me.fraPageSetUp.TabIndex = 2
        Me.fraPageSetUp.TabStop = False
        Me.fraPageSetUp.Text = "Geral"
        '
        'chkGlobal
        '
        Me.chkGlobal.AutoSize = True
        Me.chkGlobal.Location = New System.Drawing.Point(373, 25)
        Me.chkGlobal.Margin = New System.Windows.Forms.Padding(4)
        Me.chkGlobal.Name = "chkGlobal"
        Me.chkGlobal.Size = New System.Drawing.Size(71, 21)
        Me.chkGlobal.TabIndex = 7
        Me.chkGlobal.Text = "Global"
        '
        'btnClearPage
        '
        Me.btnClearPage.Location = New System.Drawing.Point(942, 14)
        Me.btnClearPage.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClearPage.Name = "btnClearPage"
        Me.btnClearPage.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnClearPage.Size = New System.Drawing.Size(100, 34)
        Me.btnClearPage.TabIndex = 6
        Me.btnClearPage.Text = "Limpar "
        '
        'btnDeletePage
        '
        Me.btnDeletePage.Location = New System.Drawing.Point(829, 14)
        Me.btnDeletePage.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDeletePage.Name = "btnDeletePage"
        Me.btnDeletePage.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnDeletePage.Size = New System.Drawing.Size(105, 34)
        Me.btnDeletePage.TabIndex = 5
        Me.btnDeletePage.Text = "Deletar "
        '
        'btnPastePage
        '
        Me.btnPastePage.Location = New System.Drawing.Point(722, 14)
        Me.btnPastePage.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPastePage.Name = "btnPastePage"
        Me.btnPastePage.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnPastePage.Size = New System.Drawing.Size(100, 34)
        Me.btnPastePage.TabIndex = 4
        Me.btnPastePage.Text = "Colar"
        '
        'btnCopyPage
        '
        Me.btnCopyPage.Location = New System.Drawing.Point(613, 14)
        Me.btnCopyPage.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCopyPage.Name = "btnCopyPage"
        Me.btnCopyPage.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnCopyPage.Size = New System.Drawing.Size(100, 34)
        Me.btnCopyPage.TabIndex = 3
        Me.btnCopyPage.Text = "Copiar"
        '
        'btnNewPage
        '
        Me.btnNewPage.Location = New System.Drawing.Point(505, 14)
        Me.btnNewPage.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNewPage.Name = "btnNewPage"
        Me.btnNewPage.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnNewPage.Size = New System.Drawing.Size(100, 34)
        Me.btnNewPage.TabIndex = 2
        Me.btnNewPage.Text = "Nova"
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtName.Location = New System.Drawing.Point(136, 23)
        Me.txtName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(229, 22)
        Me.txtName.TabIndex = 1
        '
        'DarkLabel1
        '
        Me.DarkLabel1.AutoSize = True
        Me.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel1.Location = New System.Drawing.Point(12, 26)
        Me.DarkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel1.Name = "DarkLabel1"
        Me.DarkLabel1.Size = New System.Drawing.Size(117, 17)
        Me.DarkLabel1.TabIndex = 0
        Me.DarkLabel1.Text = "Nome do Evento:"
        '
        'tabPages
        '
        Me.tabPages.Controls.Add(Me.TabPage1)
        Me.tabPages.Location = New System.Drawing.Point(16, 73)
        Me.tabPages.Margin = New System.Windows.Forms.Padding(4)
        Me.tabPages.Name = "tabPages"
        Me.tabPages.SelectedIndex = 0
        Me.tabPages.Size = New System.Drawing.Size(946, 23)
        Me.tabPages.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.DimGray
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(938, 0)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'pnlTabPage
        '
        Me.pnlTabPage.Controls.Add(Me.fraCommands)
        Me.pnlTabPage.Controls.Add(Me.DarkGroupBox8)
        Me.pnlTabPage.Controls.Add(Me.lstCommands)
        Me.pnlTabPage.Controls.Add(Me.DarkLabel10)
        Me.pnlTabPage.Controls.Add(Me.DarkLabel9)
        Me.pnlTabPage.Controls.Add(Me.DarkGroupBox7)
        Me.pnlTabPage.Controls.Add(Me.DarkGroupBox5)
        Me.pnlTabPage.Controls.Add(Me.DarkGroupBox4)
        Me.pnlTabPage.Controls.Add(Me.DarkGroupBox3)
        Me.pnlTabPage.Controls.Add(Me.DarkGroupBox2)
        Me.pnlTabPage.Controls.Add(Me.DarkGroupBox1)
        Me.pnlTabPage.Location = New System.Drawing.Point(4, 100)
        Me.pnlTabPage.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlTabPage.Name = "pnlTabPage"
        Me.pnlTabPage.Size = New System.Drawing.Size(1054, 612)
        Me.pnlTabPage.TabIndex = 4
        '
        'fraCommands
        '
        Me.fraCommands.Controls.Add(Me.btnCancelCommand)
        Me.fraCommands.Controls.Add(Me.tvCommands)
        Me.fraCommands.Location = New System.Drawing.Point(519, 7)
        Me.fraCommands.Margin = New System.Windows.Forms.Padding(4)
        Me.fraCommands.Name = "fraCommands"
        Me.fraCommands.Size = New System.Drawing.Size(524, 594)
        Me.fraCommands.TabIndex = 6
        Me.fraCommands.Visible = False
        '
        'btnCancelCommand
        '
        Me.btnCancelCommand.Location = New System.Drawing.Point(416, 544)
        Me.btnCancelCommand.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancelCommand.Name = "btnCancelCommand"
        Me.btnCancelCommand.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnCancelCommand.Size = New System.Drawing.Size(100, 40)
        Me.btnCancelCommand.TabIndex = 2
        Me.btnCancelCommand.Text = "Cancelar"
        '
        'DarkGroupBox8
        '
        Me.DarkGroupBox8.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox8.Controls.Add(Me.btnClearCommand)
        Me.DarkGroupBox8.Controls.Add(Me.btnDeleteCommand)
        Me.DarkGroupBox8.Controls.Add(Me.btnEditCommand)
        Me.DarkGroupBox8.Controls.Add(Me.btnAddCommand)
        Me.DarkGroupBox8.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox8.Location = New System.Drawing.Point(519, 540)
        Me.DarkGroupBox8.Margin = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox8.Name = "DarkGroupBox8"
        Me.DarkGroupBox8.Padding = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox8.Size = New System.Drawing.Size(524, 60)
        Me.DarkGroupBox8.TabIndex = 9
        Me.DarkGroupBox8.TabStop = False
        Me.DarkGroupBox8.Text = "Commands"
        '
        'btnClearCommand
        '
        Me.btnClearCommand.Location = New System.Drawing.Point(416, 23)
        Me.btnClearCommand.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClearCommand.Name = "btnClearCommand"
        Me.btnClearCommand.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnClearCommand.Size = New System.Drawing.Size(100, 28)
        Me.btnClearCommand.TabIndex = 3
        Me.btnClearCommand.Text = "Clear"
        '
        'btnDeleteCommand
        '
        Me.btnDeleteCommand.Location = New System.Drawing.Point(283, 23)
        Me.btnDeleteCommand.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDeleteCommand.Name = "btnDeleteCommand"
        Me.btnDeleteCommand.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnDeleteCommand.Size = New System.Drawing.Size(100, 28)
        Me.btnDeleteCommand.TabIndex = 2
        Me.btnDeleteCommand.Text = "Delete"
        '
        'btnEditCommand
        '
        Me.btnEditCommand.Location = New System.Drawing.Point(144, 23)
        Me.btnEditCommand.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEditCommand.Name = "btnEditCommand"
        Me.btnEditCommand.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnEditCommand.Size = New System.Drawing.Size(100, 28)
        Me.btnEditCommand.TabIndex = 1
        Me.btnEditCommand.Text = "Edit"
        '
        'btnAddCommand
        '
        Me.btnAddCommand.Location = New System.Drawing.Point(8, 23)
        Me.btnAddCommand.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddCommand.Name = "btnAddCommand"
        Me.btnAddCommand.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnAddCommand.Size = New System.Drawing.Size(100, 28)
        Me.btnAddCommand.TabIndex = 0
        Me.btnAddCommand.Text = "Add"
        '
        'lstCommands
        '
        Me.lstCommands.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lstCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstCommands.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstCommands.FormattingEnabled = True
        Me.lstCommands.ItemHeight = 16
        Me.lstCommands.Location = New System.Drawing.Point(519, 7)
        Me.lstCommands.Margin = New System.Windows.Forms.Padding(4)
        Me.lstCommands.Name = "lstCommands"
        Me.lstCommands.Size = New System.Drawing.Size(523, 530)
        Me.lstCommands.TabIndex = 8
        '
        'DarkLabel10
        '
        Me.DarkLabel10.ForeColor = System.Drawing.Color.Red
        Me.DarkLabel10.Location = New System.Drawing.Point(243, 564)
        Me.DarkLabel10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel10.Name = "DarkLabel10"
        Me.DarkLabel10.Size = New System.Drawing.Size(267, 37)
        Me.DarkLabel10.TabIndex = 7
        Me.DarkLabel10.Text = "** Se global, apenas a primeira página será processada."
        '
        'DarkLabel9
        '
        Me.DarkLabel9.ForeColor = System.Drawing.Color.Red
        Me.DarkLabel9.Location = New System.Drawing.Point(243, 522)
        Me.DarkLabel9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel9.Name = "DarkLabel9"
        Me.DarkLabel9.Size = New System.Drawing.Size(268, 42)
        Me.DarkLabel9.TabIndex = 6
        Me.DarkLabel9.Text = "* Auto-Switches são sempre globais e reiniciam quando o servidor reinicia."
        '
        'DarkGroupBox7
        '
        Me.DarkGroupBox7.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox7.Controls.Add(Me.cmbEventQuest)
        Me.DarkGroupBox7.Controls.Add(Me.DarkLabel8)
        Me.DarkGroupBox7.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox7.Location = New System.Drawing.Point(243, 462)
        Me.DarkGroupBox7.Margin = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox7.Name = "DarkGroupBox7"
        Me.DarkGroupBox7.Padding = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox7.Size = New System.Drawing.Size(267, 55)
        Me.DarkGroupBox7.TabIndex = 5
        Me.DarkGroupBox7.TabStop = False
        Me.DarkGroupBox7.Text = "Ícone da Tarefa"
        '
        'cmbEventQuest
        '
        Me.cmbEventQuest.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbEventQuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEventQuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbEventQuest.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbEventQuest.FormattingEnabled = True
        Me.cmbEventQuest.Location = New System.Drawing.Point(68, 21)
        Me.cmbEventQuest.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbEventQuest.Name = "cmbEventQuest"
        Me.cmbEventQuest.Size = New System.Drawing.Size(189, 24)
        Me.cmbEventQuest.TabIndex = 1
        '
        'DarkLabel8
        '
        Me.DarkLabel8.AutoSize = True
        Me.DarkLabel8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel8.Location = New System.Drawing.Point(9, 25)
        Me.DarkLabel8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel8.Name = "DarkLabel8"
        Me.DarkLabel8.Size = New System.Drawing.Size(54, 17)
        Me.DarkLabel8.TabIndex = 0
        Me.DarkLabel8.Text = "Tarefa:"
        '
        'DarkGroupBox5
        '
        Me.DarkGroupBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox5.Controls.Add(Me.cmbTrigger)
        Me.DarkGroupBox5.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox5.Location = New System.Drawing.Point(243, 395)
        Me.DarkGroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox5.Name = "DarkGroupBox5"
        Me.DarkGroupBox5.Padding = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox5.Size = New System.Drawing.Size(267, 60)
        Me.DarkGroupBox5.TabIndex = 4
        Me.DarkGroupBox5.TabStop = False
        Me.DarkGroupBox5.Text = "Gatilho de Início"
        '
        'cmbTrigger
        '
        Me.cmbTrigger.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTrigger.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTrigger.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbTrigger.FormattingEnabled = True
        Me.cmbTrigger.Items.AddRange(New Object() {"Botão de Ação", "Toque do Jogador", "Processo Paralelo"})
        Me.cmbTrigger.Location = New System.Drawing.Point(8, 23)
        Me.cmbTrigger.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbTrigger.Name = "cmbTrigger"
        Me.cmbTrigger.Size = New System.Drawing.Size(251, 24)
        Me.cmbTrigger.TabIndex = 0
        '
        'DarkGroupBox4
        '
        Me.DarkGroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox4.Controls.Add(Me.cmbPositioning)
        Me.DarkGroupBox4.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox4.Location = New System.Drawing.Point(243, 329)
        Me.DarkGroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox4.Name = "DarkGroupBox4"
        Me.DarkGroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox4.Size = New System.Drawing.Size(267, 59)
        Me.DarkGroupBox4.TabIndex = 3
        Me.DarkGroupBox4.TabStop = False
        Me.DarkGroupBox4.Text = "Posicionamento"
        '
        'cmbPositioning
        '
        Me.cmbPositioning.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbPositioning.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPositioning.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPositioning.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbPositioning.FormattingEnabled = True
        Me.cmbPositioning.Items.AddRange(New Object() {"Abaixo dos Personagens", "Mesmo dos Personagens", "Acima dos Personagens"})
        Me.cmbPositioning.Location = New System.Drawing.Point(8, 23)
        Me.cmbPositioning.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPositioning.Name = "cmbPositioning"
        Me.cmbPositioning.Size = New System.Drawing.Size(251, 24)
        Me.cmbPositioning.TabIndex = 0
        '
        'DarkGroupBox3
        '
        Me.DarkGroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox3.Controls.Add(Me.DarkLabel7)
        Me.DarkGroupBox3.Controls.Add(Me.cmbMoveFreq)
        Me.DarkGroupBox3.Controls.Add(Me.DarkLabel6)
        Me.DarkGroupBox3.Controls.Add(Me.cmbMoveSpeed)
        Me.DarkGroupBox3.Controls.Add(Me.btnMoveRoute)
        Me.DarkGroupBox3.Controls.Add(Me.cmbMoveType)
        Me.DarkGroupBox3.Controls.Add(Me.DarkLabel5)
        Me.DarkGroupBox3.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox3.Location = New System.Drawing.Point(244, 170)
        Me.DarkGroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox3.Name = "DarkGroupBox3"
        Me.DarkGroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox3.Size = New System.Drawing.Size(267, 151)
        Me.DarkGroupBox3.TabIndex = 2
        Me.DarkGroupBox3.TabStop = False
        Me.DarkGroupBox3.Text = "Movimentação"
        '
        'DarkLabel7
        '
        Me.DarkLabel7.AutoSize = True
        Me.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel7.Location = New System.Drawing.Point(8, 123)
        Me.DarkLabel7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel7.Name = "DarkLabel7"
        Me.DarkLabel7.Size = New System.Drawing.Size(83, 17)
        Me.DarkLabel7.TabIndex = 6
        Me.DarkLabel7.Text = "Frequência:"
        '
        'cmbMoveFreq
        '
        Me.cmbMoveFreq.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbMoveFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoveFreq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMoveFreq.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbMoveFreq.FormattingEnabled = True
        Me.cmbMoveFreq.Items.AddRange(New Object() {"Mais Baixa", "Baixa", "Normal", "Alta", "Mais Alta"})
        Me.cmbMoveFreq.Location = New System.Drawing.Point(92, 119)
        Me.cmbMoveFreq.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbMoveFreq.Name = "cmbMoveFreq"
        Me.cmbMoveFreq.Size = New System.Drawing.Size(166, 24)
        Me.cmbMoveFreq.TabIndex = 5
        '
        'DarkLabel6
        '
        Me.DarkLabel6.AutoSize = True
        Me.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel6.Location = New System.Drawing.Point(8, 90)
        Me.DarkLabel6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel6.Name = "DarkLabel6"
        Me.DarkLabel6.Size = New System.Drawing.Size(82, 17)
        Me.DarkLabel6.TabIndex = 4
        Me.DarkLabel6.Text = "Velocidade:"
        '
        'cmbMoveSpeed
        '
        Me.cmbMoveSpeed.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbMoveSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoveSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMoveSpeed.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbMoveSpeed.FormattingEnabled = True
        Me.cmbMoveSpeed.Items.AddRange(New Object() {"8x Slower", "4x Slower", "2x Slower", "Normal", "2x Faster", "4x Faster"})
        Me.cmbMoveSpeed.Location = New System.Drawing.Point(92, 86)
        Me.cmbMoveSpeed.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbMoveSpeed.Name = "cmbMoveSpeed"
        Me.cmbMoveSpeed.Size = New System.Drawing.Size(166, 24)
        Me.cmbMoveSpeed.TabIndex = 3
        '
        'btnMoveRoute
        '
        Me.btnMoveRoute.Location = New System.Drawing.Point(158, 44)
        Me.btnMoveRoute.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMoveRoute.Name = "btnMoveRoute"
        Me.btnMoveRoute.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnMoveRoute.Size = New System.Drawing.Size(100, 34)
        Me.btnMoveRoute.TabIndex = 2
        Me.btnMoveRoute.Text = "Mover rota"
        '
        'cmbMoveType
        '
        Me.cmbMoveType.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbMoveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoveType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMoveType.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbMoveType.FormattingEnabled = True
        Me.cmbMoveType.Items.AddRange(New Object() {"Posição Fixa", "Aleatório", "Rota de Movimento"})
        Me.cmbMoveType.Location = New System.Drawing.Point(92, 18)
        Me.cmbMoveType.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbMoveType.Name = "cmbMoveType"
        Me.cmbMoveType.Size = New System.Drawing.Size(166, 24)
        Me.cmbMoveType.TabIndex = 1
        '
        'DarkLabel5
        '
        Me.DarkLabel5.AutoSize = True
        Me.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel5.Location = New System.Drawing.Point(8, 21)
        Me.DarkLabel5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel5.Name = "DarkLabel5"
        Me.DarkLabel5.Size = New System.Drawing.Size(40, 17)
        Me.DarkLabel5.TabIndex = 0
        Me.DarkLabel5.Text = "Tipo:"
        '
        'DarkGroupBox2
        '
        Me.DarkGroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox2.Controls.Add(Me.picGraphic)
        Me.DarkGroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox2.Location = New System.Drawing.Point(4, 170)
        Me.DarkGroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox2.Name = "DarkGroupBox2"
        Me.DarkGroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox2.Size = New System.Drawing.Size(231, 286)
        Me.DarkGroupBox2.TabIndex = 1
        Me.DarkGroupBox2.TabStop = False
        Me.DarkGroupBox2.Text = "Gráfico"
        '
        'picGraphic
        '
        Me.picGraphic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picGraphic.Location = New System.Drawing.Point(8, 23)
        Me.picGraphic.Margin = New System.Windows.Forms.Padding(4)
        Me.picGraphic.Name = "picGraphic"
        Me.picGraphic.Size = New System.Drawing.Size(215, 254)
        Me.picGraphic.TabIndex = 1
        Me.picGraphic.TabStop = False
        '
        'DarkGroupBox1
        '
        Me.DarkGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox1.Controls.Add(Me.cmbSelfSwitchCompare)
        Me.DarkGroupBox1.Controls.Add(Me.DarkLabel4)
        Me.DarkGroupBox1.Controls.Add(Me.cmbSelfSwitch)
        Me.DarkGroupBox1.Controls.Add(Me.chkSelfSwitch)
        Me.DarkGroupBox1.Controls.Add(Me.cmbHasItem)
        Me.DarkGroupBox1.Controls.Add(Me.chkHasItem)
        Me.DarkGroupBox1.Controls.Add(Me.cmbPlayerSwitchCompare)
        Me.DarkGroupBox1.Controls.Add(Me.DarkLabel3)
        Me.DarkGroupBox1.Controls.Add(Me.cmbPlayerSwitch)
        Me.DarkGroupBox1.Controls.Add(Me.chkPlayerSwitch)
        Me.DarkGroupBox1.Controls.Add(Me.nudPlayerVariable)
        Me.DarkGroupBox1.Controls.Add(Me.cmbPlayervarCompare)
        Me.DarkGroupBox1.Controls.Add(Me.DarkLabel2)
        Me.DarkGroupBox1.Controls.Add(Me.cmbPlayerVar)
        Me.DarkGroupBox1.Controls.Add(Me.chkPlayerVar)
        Me.DarkGroupBox1.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox1.Location = New System.Drawing.Point(4, 7)
        Me.DarkGroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox1.Name = "DarkGroupBox1"
        Me.DarkGroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox1.Size = New System.Drawing.Size(507, 155)
        Me.DarkGroupBox1.TabIndex = 0
        Me.DarkGroupBox1.TabStop = False
        Me.DarkGroupBox1.Text = "Condições"
        '
        'cmbSelfSwitchCompare
        '
        Me.cmbSelfSwitchCompare.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbSelfSwitchCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSelfSwitchCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSelfSwitchCompare.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbSelfSwitchCompare.FormattingEnabled = True
        Me.cmbSelfSwitchCompare.Items.AddRange(New Object() {"Falso = 0", "Verdade = 1"})
        Me.cmbSelfSwitchCompare.Location = New System.Drawing.Point(297, 121)
        Me.cmbSelfSwitchCompare.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSelfSwitchCompare.Name = "cmbSelfSwitchCompare"
        Me.cmbSelfSwitchCompare.Size = New System.Drawing.Size(118, 24)
        Me.cmbSelfSwitchCompare.TabIndex = 14
        '
        'DarkLabel4
        '
        Me.DarkLabel4.AutoSize = True
        Me.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel4.Location = New System.Drawing.Point(270, 124)
        Me.DarkLabel4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel4.Name = "DarkLabel4"
        Me.DarkLabel4.Size = New System.Drawing.Size(16, 17)
        Me.DarkLabel4.TabIndex = 13
        Me.DarkLabel4.Text = "é"
        '
        'cmbSelfSwitch
        '
        Me.cmbSelfSwitch.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbSelfSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSelfSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSelfSwitch.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbSelfSwitch.FormattingEnabled = True
        Me.cmbSelfSwitch.Items.AddRange(New Object() {"Nenhum", "1 - A", "2 - B", "3 - C", "4 - D"})
        Me.cmbSelfSwitch.Location = New System.Drawing.Point(144, 121)
        Me.cmbSelfSwitch.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSelfSwitch.Name = "cmbSelfSwitch"
        Me.cmbSelfSwitch.Size = New System.Drawing.Size(118, 24)
        Me.cmbSelfSwitch.TabIndex = 12
        '
        'chkSelfSwitch
        '
        Me.chkSelfSwitch.AutoSize = True
        Me.chkSelfSwitch.Location = New System.Drawing.Point(8, 123)
        Me.chkSelfSwitch.Margin = New System.Windows.Forms.Padding(4)
        Me.chkSelfSwitch.Name = "chkSelfSwitch"
        Me.chkSelfSwitch.Size = New System.Drawing.Size(109, 21)
        Me.chkSelfSwitch.TabIndex = 11
        Me.chkSelfSwitch.Text = "Auto-Switch*"
        '
        'cmbHasItem
        '
        Me.cmbHasItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbHasItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHasItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbHasItem.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbHasItem.FormattingEnabled = True
        Me.cmbHasItem.Location = New System.Drawing.Point(144, 87)
        Me.cmbHasItem.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbHasItem.Name = "cmbHasItem"
        Me.cmbHasItem.Size = New System.Drawing.Size(271, 24)
        Me.cmbHasItem.TabIndex = 10
        '
        'chkHasItem
        '
        Me.chkHasItem.AutoSize = True
        Me.chkHasItem.Location = New System.Drawing.Point(8, 90)
        Me.chkHasItem.Margin = New System.Windows.Forms.Padding(4)
        Me.chkHasItem.Name = "chkHasItem"
        Me.chkHasItem.Size = New System.Drawing.Size(144, 21)
        Me.chkHasItem.TabIndex = 9
        Me.chkHasItem.Text = "Jogador Tem Item"
        '
        'cmbPlayerSwitchCompare
        '
        Me.cmbPlayerSwitchCompare.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbPlayerSwitchCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlayerSwitchCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPlayerSwitchCompare.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbPlayerSwitchCompare.FormattingEnabled = True
        Me.cmbPlayerSwitchCompare.Items.AddRange(New Object() {"Falso = 0", "Verdadeiro = 1"})
        Me.cmbPlayerSwitchCompare.Location = New System.Drawing.Point(297, 54)
        Me.cmbPlayerSwitchCompare.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPlayerSwitchCompare.Name = "cmbPlayerSwitchCompare"
        Me.cmbPlayerSwitchCompare.Size = New System.Drawing.Size(118, 24)
        Me.cmbPlayerSwitchCompare.TabIndex = 8
        '
        'DarkLabel3
        '
        Me.DarkLabel3.AutoSize = True
        Me.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel3.Location = New System.Drawing.Point(270, 58)
        Me.DarkLabel3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel3.Name = "DarkLabel3"
        Me.DarkLabel3.Size = New System.Drawing.Size(16, 17)
        Me.DarkLabel3.TabIndex = 7
        Me.DarkLabel3.Text = "é"
        '
        'cmbPlayerSwitch
        '
        Me.cmbPlayerSwitch.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbPlayerSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlayerSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPlayerSwitch.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbPlayerSwitch.FormattingEnabled = True
        Me.cmbPlayerSwitch.Location = New System.Drawing.Point(144, 54)
        Me.cmbPlayerSwitch.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPlayerSwitch.Name = "cmbPlayerSwitch"
        Me.cmbPlayerSwitch.Size = New System.Drawing.Size(118, 24)
        Me.cmbPlayerSwitch.TabIndex = 6
        '
        'chkPlayerSwitch
        '
        Me.chkPlayerSwitch.AutoSize = True
        Me.chkPlayerSwitch.Location = New System.Drawing.Point(8, 57)
        Me.chkPlayerSwitch.Margin = New System.Windows.Forms.Padding(4)
        Me.chkPlayerSwitch.Name = "chkPlayerSwitch"
        Me.chkPlayerSwitch.Size = New System.Drawing.Size(146, 21)
        Me.chkPlayerSwitch.TabIndex = 5
        Me.chkPlayerSwitch.Text = "Switch do Jogador"
        '
        'nudPlayerVariable
        '
        Me.nudPlayerVariable.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudPlayerVariable.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudPlayerVariable.Location = New System.Drawing.Point(424, 22)
        Me.nudPlayerVariable.Margin = New System.Windows.Forms.Padding(4)
        Me.nudPlayerVariable.Name = "nudPlayerVariable"
        Me.nudPlayerVariable.Size = New System.Drawing.Size(75, 22)
        Me.nudPlayerVariable.TabIndex = 4
        '
        'cmbPlayervarCompare
        '
        Me.cmbPlayervarCompare.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbPlayervarCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlayervarCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPlayervarCompare.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbPlayervarCompare.FormattingEnabled = True
        Me.cmbPlayervarCompare.Items.AddRange(New Object() {"Igual à", "Great Than OrElse Equal To", "Less Than or Equal To", "Maior que", "Menor que", "Não é igual à"})
        Me.cmbPlayervarCompare.Location = New System.Drawing.Point(297, 21)
        Me.cmbPlayervarCompare.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPlayervarCompare.Name = "cmbPlayervarCompare"
        Me.cmbPlayervarCompare.Size = New System.Drawing.Size(118, 24)
        Me.cmbPlayervarCompare.TabIndex = 3
        '
        'DarkLabel2
        '
        Me.DarkLabel2.AutoSize = True
        Me.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel2.Location = New System.Drawing.Point(270, 28)
        Me.DarkLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel2.Name = "DarkLabel2"
        Me.DarkLabel2.Size = New System.Drawing.Size(16, 17)
        Me.DarkLabel2.TabIndex = 2
        Me.DarkLabel2.Text = "é"
        '
        'cmbPlayerVar
        '
        Me.cmbPlayerVar.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbPlayerVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlayerVar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPlayerVar.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbPlayerVar.FormattingEnabled = True
        Me.cmbPlayerVar.Location = New System.Drawing.Point(144, 21)
        Me.cmbPlayerVar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPlayerVar.Name = "cmbPlayerVar"
        Me.cmbPlayerVar.Size = New System.Drawing.Size(118, 24)
        Me.cmbPlayerVar.TabIndex = 1
        '
        'chkPlayerVar
        '
        Me.chkPlayerVar.AutoSize = True
        Me.chkPlayerVar.Location = New System.Drawing.Point(8, 23)
        Me.chkPlayerVar.Margin = New System.Windows.Forms.Padding(4)
        Me.chkPlayerVar.Name = "chkPlayerVar"
        Me.chkPlayerVar.Size = New System.Drawing.Size(157, 21)
        Me.chkPlayerVar.TabIndex = 0
        Me.chkPlayerVar.Text = "Variável do Jogador"
        '
        'DarkGroupBox6
        '
        Me.DarkGroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox6.Controls.Add(Me.chkShowName)
        Me.DarkGroupBox6.Controls.Add(Me.chkWalkThrough)
        Me.DarkGroupBox6.Controls.Add(Me.chkDirFix)
        Me.DarkGroupBox6.Controls.Add(Me.chkWalkAnim)
        Me.DarkGroupBox6.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox6.Location = New System.Drawing.Point(4, 562)
        Me.DarkGroupBox6.Margin = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox6.Name = "DarkGroupBox6"
        Me.DarkGroupBox6.Padding = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox6.Size = New System.Drawing.Size(235, 138)
        Me.DarkGroupBox6.TabIndex = 5
        Me.DarkGroupBox6.TabStop = False
        Me.DarkGroupBox6.Text = "Opções"
        '
        'chkShowName
        '
        Me.chkShowName.AutoSize = True
        Me.chkShowName.Location = New System.Drawing.Point(8, 108)
        Me.chkShowName.Margin = New System.Windows.Forms.Padding(4)
        Me.chkShowName.Name = "chkShowName"
        Me.chkShowName.Size = New System.Drawing.Size(119, 21)
        Me.chkShowName.TabIndex = 3
        Me.chkShowName.Text = "Mostrar Nome"
        '
        'chkWalkThrough
        '
        Me.chkWalkThrough.AutoSize = True
        Me.chkWalkThrough.Location = New System.Drawing.Point(8, 80)
        Me.chkWalkThrough.Margin = New System.Windows.Forms.Padding(4)
        Me.chkWalkThrough.Name = "chkWalkThrough"
        Me.chkWalkThrough.Size = New System.Drawing.Size(130, 21)
        Me.chkWalkThrough.TabIndex = 2
        Me.chkWalkThrough.Text = "Andar por Tudo"
        '
        'chkDirFix
        '
        Me.chkDirFix.AutoSize = True
        Me.chkDirFix.Location = New System.Drawing.Point(8, 52)
        Me.chkDirFix.Margin = New System.Windows.Forms.Padding(4)
        Me.chkDirFix.Name = "chkDirFix"
        Me.chkDirFix.Size = New System.Drawing.Size(108, 21)
        Me.chkDirFix.TabIndex = 1
        Me.chkDirFix.Text = "Direção Fixa"
        '
        'chkWalkAnim
        '
        Me.chkWalkAnim.AutoSize = True
        Me.chkWalkAnim.Location = New System.Drawing.Point(8, 23)
        Me.chkWalkAnim.Margin = New System.Windows.Forms.Padding(4)
        Me.chkWalkAnim.Name = "chkWalkAnim"
        Me.chkWalkAnim.Size = New System.Drawing.Size(186, 21)
        Me.chkWalkAnim.TabIndex = 0
        Me.chkWalkAnim.Text = "Sem Animação de Andar"
        '
        'btnLabeling
        '
        Me.btnLabeling.Location = New System.Drawing.Point(4, 718)
        Me.btnLabeling.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLabeling.Name = "btnLabeling"
        Me.btnLabeling.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnLabeling.Size = New System.Drawing.Size(227, 41)
        Me.btnLabeling.TabIndex = 6
        Me.btnLabeling.Text = "Editar Variáveis / Switches"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(958, 718)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnCancel.Size = New System.Drawing.Size(100, 41)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancelar"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(851, 718)
        Me.btnOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnOk.Size = New System.Drawing.Size(100, 41)
        Me.btnOk.TabIndex = 8
        Me.btnOk.Text = "Confirmar"
        '
        'fraMoveRoute
        '
        Me.fraMoveRoute.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraMoveRoute.Controls.Add(Me.btnMoveRouteOk)
        Me.fraMoveRoute.Controls.Add(Me.btnMoveRouteCancel)
        Me.fraMoveRoute.Controls.Add(Me.chkRepeatRoute)
        Me.fraMoveRoute.Controls.Add(Me.chkIgnoreMove)
        Me.fraMoveRoute.Controls.Add(Me.DarkGroupBox10)
        Me.fraMoveRoute.Controls.Add(Me.lstMoveRoute)
        Me.fraMoveRoute.Controls.Add(Me.cmbEvent)
        Me.fraMoveRoute.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraMoveRoute.Location = New System.Drawing.Point(1067, 14)
        Me.fraMoveRoute.Margin = New System.Windows.Forms.Padding(4)
        Me.fraMoveRoute.Name = "fraMoveRoute"
        Me.fraMoveRoute.Padding = New System.Windows.Forms.Padding(4)
        Me.fraMoveRoute.Size = New System.Drawing.Size(124, 105)
        Me.fraMoveRoute.TabIndex = 0
        Me.fraMoveRoute.TabStop = False
        Me.fraMoveRoute.Text = "Move Route"
        Me.fraMoveRoute.Visible = False
        '
        'btnMoveRouteOk
        '
        Me.btnMoveRouteOk.Location = New System.Drawing.Point(856, 530)
        Me.btnMoveRouteOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMoveRouteOk.Name = "btnMoveRouteOk"
        Me.btnMoveRouteOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnMoveRouteOk.Size = New System.Drawing.Size(100, 28)
        Me.btnMoveRouteOk.TabIndex = 7
        Me.btnMoveRouteOk.Text = "Ok"
        '
        'btnMoveRouteCancel
        '
        Me.btnMoveRouteCancel.Location = New System.Drawing.Point(964, 530)
        Me.btnMoveRouteCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMoveRouteCancel.Name = "btnMoveRouteCancel"
        Me.btnMoveRouteCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnMoveRouteCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnMoveRouteCancel.TabIndex = 6
        Me.btnMoveRouteCancel.Text = "Cancel"
        '
        'chkRepeatRoute
        '
        Me.chkRepeatRoute.AutoSize = True
        Me.chkRepeatRoute.Location = New System.Drawing.Point(8, 558)
        Me.chkRepeatRoute.Margin = New System.Windows.Forms.Padding(4)
        Me.chkRepeatRoute.Name = "chkRepeatRoute"
        Me.chkRepeatRoute.Size = New System.Drawing.Size(118, 21)
        Me.chkRepeatRoute.TabIndex = 5
        Me.chkRepeatRoute.Text = "Repeat Route"
        '
        'chkIgnoreMove
        '
        Me.chkIgnoreMove.AutoSize = True
        Me.chkIgnoreMove.Location = New System.Drawing.Point(8, 530)
        Me.chkIgnoreMove.Margin = New System.Windows.Forms.Padding(4)
        Me.chkIgnoreMove.Name = "chkIgnoreMove"
        Me.chkIgnoreMove.Size = New System.Drawing.Size(192, 21)
        Me.chkIgnoreMove.TabIndex = 4
        Me.chkIgnoreMove.Text = "Ignore if event can't move"
        '
        'DarkGroupBox10
        '
        Me.DarkGroupBox10.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox10.Controls.Add(Me.lstvwMoveRoute)
        Me.DarkGroupBox10.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox10.Location = New System.Drawing.Point(270, 12)
        Me.DarkGroupBox10.Margin = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox10.Name = "DarkGroupBox10"
        Me.DarkGroupBox10.Padding = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox10.Size = New System.Drawing.Size(793, 510)
        Me.DarkGroupBox10.TabIndex = 3
        Me.DarkGroupBox10.TabStop = False
        Me.DarkGroupBox10.Text = "Commands"
        '
        'lstvwMoveRoute
        '
        Me.lstvwMoveRoute.AutoArrange = False
        Me.lstvwMoveRoute.BackColor = System.Drawing.Color.DimGray
        Me.lstvwMoveRoute.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstvwMoveRoute.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lstvwMoveRoute.Dock = System.Windows.Forms.DockStyle.Top
        Me.lstvwMoveRoute.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstvwMoveRoute.ForeColor = System.Drawing.Color.Gainsboro
        ListViewGroup1.Header = "Movement"
        ListViewGroup1.Name = "lstVgMovement"
        ListViewGroup2.Header = "Wait"
        ListViewGroup2.Name = "lstVgWait"
        ListViewGroup3.Header = "Turning"
        ListViewGroup3.Name = "lstVgTurn"
        ListViewGroup4.Header = "Speed"
        ListViewGroup4.Name = "lstVgSpeed"
        ListViewGroup5.Header = "Walk Animation"
        ListViewGroup5.Name = "lstVgWalk"
        ListViewGroup6.Header = "Fixed Direction"
        ListViewGroup6.Name = "lstVgDirection"
        ListViewGroup7.Header = "WalkThrough"
        ListViewGroup7.Name = "lstVgWalkThrough"
        ListViewGroup8.Header = "Set Position"
        ListViewGroup8.Name = "lstVgSetposition"
        ListViewGroup9.Header = "Set Graphic"
        ListViewGroup9.Name = "lstVgSetGraphic"
        Me.lstvwMoveRoute.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3, ListViewGroup4, ListViewGroup5, ListViewGroup6, ListViewGroup7, ListViewGroup8, ListViewGroup9})
        Me.lstvwMoveRoute.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstvwMoveRoute.HideSelection = False
        ListViewItem1.Group = ListViewGroup1
        ListViewItem2.Group = ListViewGroup1
        ListViewItem2.IndentCount = 1
        ListViewItem3.Group = ListViewGroup1
        ListViewItem4.Group = ListViewGroup1
        ListViewItem4.IndentCount = 1
        ListViewItem5.Group = ListViewGroup1
        ListViewItem6.Group = ListViewGroup1
        ListViewItem7.Group = ListViewGroup1
        ListViewItem8.Group = ListViewGroup1
        ListViewItem9.Group = ListViewGroup1
        ListViewItem10.Group = ListViewGroup2
        ListViewItem11.Group = ListViewGroup2
        ListViewItem12.Group = ListViewGroup2
        ListViewItem13.Group = ListViewGroup3
        ListViewItem14.Group = ListViewGroup3
        ListViewItem15.Group = ListViewGroup3
        ListViewItem16.Group = ListViewGroup3
        ListViewItem17.Group = ListViewGroup3
        ListViewItem18.Group = ListViewGroup3
        ListViewItem19.Group = ListViewGroup3
        ListViewItem20.Group = ListViewGroup3
        ListViewItem21.Group = ListViewGroup3
        ListViewItem22.Group = ListViewGroup3
        ListViewItem23.Group = ListViewGroup4
        ListViewItem24.Group = ListViewGroup4
        ListViewItem25.Group = ListViewGroup4
        ListViewItem26.Group = ListViewGroup4
        ListViewItem27.Group = ListViewGroup4
        ListViewItem28.Group = ListViewGroup4
        ListViewItem29.Group = ListViewGroup4
        ListViewItem30.Group = ListViewGroup4
        ListViewItem31.Group = ListViewGroup4
        ListViewItem32.Group = ListViewGroup4
        ListViewItem33.Group = ListViewGroup4
        ListViewItem34.Group = ListViewGroup5
        ListViewItem35.Group = ListViewGroup5
        ListViewItem36.Group = ListViewGroup6
        ListViewItem37.Group = ListViewGroup6
        ListViewItem38.Group = ListViewGroup7
        ListViewItem39.Group = ListViewGroup7
        ListViewItem40.Group = ListViewGroup8
        ListViewItem41.Group = ListViewGroup8
        ListViewItem42.Group = ListViewGroup8
        ListViewItem43.Group = ListViewGroup9
        Me.lstvwMoveRoute.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8, ListViewItem9, ListViewItem10, ListViewItem11, ListViewItem12, ListViewItem13, ListViewItem14, ListViewItem15, ListViewItem16, ListViewItem17, ListViewItem18, ListViewItem19, ListViewItem20, ListViewItem21, ListViewItem22, ListViewItem23, ListViewItem24, ListViewItem25, ListViewItem26, ListViewItem27, ListViewItem28, ListViewItem29, ListViewItem30, ListViewItem31, ListViewItem32, ListViewItem33, ListViewItem34, ListViewItem35, ListViewItem36, ListViewItem37, ListViewItem38, ListViewItem39, ListViewItem40, ListViewItem41, ListViewItem42, ListViewItem43})
        Me.lstvwMoveRoute.LabelWrap = False
        Me.lstvwMoveRoute.Location = New System.Drawing.Point(4, 19)
        Me.lstvwMoveRoute.Margin = New System.Windows.Forms.Padding(4)
        Me.lstvwMoveRoute.MultiSelect = False
        Me.lstvwMoveRoute.Name = "lstvwMoveRoute"
        Me.lstvwMoveRoute.Size = New System.Drawing.Size(785, 489)
        Me.lstvwMoveRoute.TabIndex = 5
        Me.lstvwMoveRoute.UseCompatibleStateImageBehavior = False
        Me.lstvwMoveRoute.View = System.Windows.Forms.View.Tile
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = ""
        Me.ColumnHeader3.Width = 150
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = ""
        Me.ColumnHeader4.Width = 150
        '
        'lstMoveRoute
        '
        Me.lstMoveRoute.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lstMoveRoute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstMoveRoute.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstMoveRoute.FormattingEnabled = True
        Me.lstMoveRoute.ItemHeight = 16
        Me.lstMoveRoute.Location = New System.Drawing.Point(8, 57)
        Me.lstMoveRoute.Margin = New System.Windows.Forms.Padding(4)
        Me.lstMoveRoute.Name = "lstMoveRoute"
        Me.lstMoveRoute.Size = New System.Drawing.Size(254, 466)
        Me.lstMoveRoute.TabIndex = 2
        '
        'cmbEvent
        '
        Me.cmbEvent.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbEvent.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbEvent.FormattingEnabled = True
        Me.cmbEvent.Location = New System.Drawing.Point(8, 23)
        Me.cmbEvent.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbEvent.Name = "cmbEvent"
        Me.cmbEvent.Size = New System.Drawing.Size(253, 24)
        Me.cmbEvent.TabIndex = 0
        '
        'fraGraphic
        '
        Me.fraGraphic.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraGraphic.Controls.Add(Me.pnlGraphicSel)
        Me.fraGraphic.Controls.Add(Me.btnGraphicOk)
        Me.fraGraphic.Controls.Add(Me.btnGraphicCancel)
        Me.fraGraphic.Controls.Add(Me.DarkLabel13)
        Me.fraGraphic.Controls.Add(Me.nudGraphic)
        Me.fraGraphic.Controls.Add(Me.DarkLabel12)
        Me.fraGraphic.Controls.Add(Me.cmbGraphic)
        Me.fraGraphic.Controls.Add(Me.DarkLabel11)
        Me.fraGraphic.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraGraphic.Location = New System.Drawing.Point(1075, 139)
        Me.fraGraphic.Margin = New System.Windows.Forms.Padding(4)
        Me.fraGraphic.Name = "fraGraphic"
        Me.fraGraphic.Padding = New System.Windows.Forms.Padding(4)
        Me.fraGraphic.Size = New System.Drawing.Size(104, 89)
        Me.fraGraphic.TabIndex = 9
        Me.fraGraphic.TabStop = False
        Me.fraGraphic.Text = "Graphic Selection"
        Me.fraGraphic.Visible = False
        '
        'pnlGraphicSel
        '
        Me.pnlGraphicSel.AutoScroll = True
        Me.pnlGraphicSel.Controls.Add(Me.picGraphicSel)
        Me.pnlGraphicSel.Location = New System.Drawing.Point(8, 55)
        Me.pnlGraphicSel.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlGraphicSel.Name = "pnlGraphicSel"
        Me.pnlGraphicSel.Size = New System.Drawing.Size(1077, 638)
        Me.pnlGraphicSel.TabIndex = 9
        '
        'picGraphicSel
        '
        Me.picGraphicSel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picGraphicSel.Location = New System.Drawing.Point(0, 0)
        Me.picGraphicSel.Margin = New System.Windows.Forms.Padding(4)
        Me.picGraphicSel.Name = "picGraphicSel"
        Me.picGraphicSel.Size = New System.Drawing.Size(1069, 633)
        Me.picGraphicSel.TabIndex = 5
        Me.picGraphicSel.TabStop = False
        '
        'btnGraphicOk
        '
        Me.btnGraphicOk.Location = New System.Drawing.Point(869, 702)
        Me.btnGraphicOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGraphicOk.Name = "btnGraphicOk"
        Me.btnGraphicOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnGraphicOk.Size = New System.Drawing.Size(100, 28)
        Me.btnGraphicOk.TabIndex = 8
        Me.btnGraphicOk.Text = "Ok"
        '
        'btnGraphicCancel
        '
        Me.btnGraphicCancel.Location = New System.Drawing.Point(978, 702)
        Me.btnGraphicCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGraphicCancel.Name = "btnGraphicCancel"
        Me.btnGraphicCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnGraphicCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnGraphicCancel.TabIndex = 7
        Me.btnGraphicCancel.Text = "Cancel"
        '
        'DarkLabel13
        '
        Me.DarkLabel13.AutoSize = True
        Me.DarkLabel13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel13.Location = New System.Drawing.Point(12, 702)
        Me.DarkLabel13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel13.Name = "DarkLabel13"
        Me.DarkLabel13.Size = New System.Drawing.Size(211, 17)
        Me.DarkLabel13.TabIndex = 6
        Me.DarkLabel13.Text = "Hold Shift to select multiple tiles."
        '
        'nudGraphic
        '
        Me.nudGraphic.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudGraphic.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudGraphic.Location = New System.Drawing.Point(507, 23)
        Me.nudGraphic.Margin = New System.Windows.Forms.Padding(4)
        Me.nudGraphic.Name = "nudGraphic"
        Me.nudGraphic.Size = New System.Drawing.Size(160, 22)
        Me.nudGraphic.TabIndex = 3
        '
        'DarkLabel12
        '
        Me.DarkLabel12.AutoSize = True
        Me.DarkLabel12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel12.Location = New System.Drawing.Point(436, 26)
        Me.DarkLabel12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel12.Name = "DarkLabel12"
        Me.DarkLabel12.Size = New System.Drawing.Size(62, 17)
        Me.DarkLabel12.TabIndex = 2
        Me.DarkLabel12.Text = "Number:"
        '
        'cmbGraphic
        '
        Me.cmbGraphic.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbGraphic.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbGraphic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGraphic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbGraphic.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbGraphic.FormattingEnabled = True
        Me.cmbGraphic.Items.AddRange(New Object() {"None", "Character", "Tileset"})
        Me.cmbGraphic.Location = New System.Drawing.Point(139, 22)
        Me.cmbGraphic.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbGraphic.Name = "cmbGraphic"
        Me.cmbGraphic.Size = New System.Drawing.Size(288, 23)
        Me.cmbGraphic.TabIndex = 1
        '
        'DarkLabel11
        '
        Me.DarkLabel11.AutoSize = True
        Me.DarkLabel11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel11.Location = New System.Drawing.Point(25, 26)
        Me.DarkLabel11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel11.Name = "DarkLabel11"
        Me.DarkLabel11.Size = New System.Drawing.Size(105, 17)
        Me.DarkLabel11.TabIndex = 0
        Me.DarkLabel11.Text = "Graphics Type:"
        '
        'fraDialogue
        '
        Me.fraDialogue.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraDialogue.Controls.Add(Me.fraConditionalBranch)
        Me.fraDialogue.Controls.Add(Me.fraPlayAnimation)
        Me.fraDialogue.Controls.Add(Me.fraMoveRouteWait)
        Me.fraDialogue.Controls.Add(Me.fraCustomScript)
        Me.fraDialogue.Controls.Add(Me.fraSetWeather)
        Me.fraDialogue.Controls.Add(Me.fraSpawnNpc)
        Me.fraDialogue.Controls.Add(Me.fraGiveExp)
        Me.fraDialogue.Controls.Add(Me.fraEndQuest)
        Me.fraDialogue.Controls.Add(Me.fraSetAccess)
        Me.fraDialogue.Controls.Add(Me.fraSetWait)
        Me.fraDialogue.Controls.Add(Me.fraShowPic)
        Me.fraDialogue.Controls.Add(Me.fraOpenShop)
        Me.fraDialogue.Controls.Add(Me.fraChangeLevel)
        Me.fraDialogue.Controls.Add(Me.fraChangeGender)
        Me.fraDialogue.Controls.Add(Me.fraGoToLabel)
        Me.fraDialogue.Controls.Add(Me.fraHidePic)
        Me.fraDialogue.Controls.Add(Me.fraBeginQuest)
        Me.fraDialogue.Controls.Add(Me.fraShowChoices)
        Me.fraDialogue.Controls.Add(Me.fraPlayerVariable)
        Me.fraDialogue.Controls.Add(Me.fraChangeSprite)
        Me.fraDialogue.Controls.Add(Me.fraSetSelfSwitch)
        Me.fraDialogue.Controls.Add(Me.fraMapTint)
        Me.fraDialogue.Controls.Add(Me.fraShowChatBubble)
        Me.fraDialogue.Controls.Add(Me.fraPlaySound)
        Me.fraDialogue.Controls.Add(Me.fraChangePK)
        Me.fraDialogue.Controls.Add(Me.fraCreateLabel)
        Me.fraDialogue.Controls.Add(Me.fraChangeClass)
        Me.fraDialogue.Controls.Add(Me.fraChangeSkills)
        Me.fraDialogue.Controls.Add(Me.fraCompleteTask)
        Me.fraDialogue.Controls.Add(Me.fraPlayerWarp)
        Me.fraDialogue.Controls.Add(Me.fraSetFog)
        Me.fraDialogue.Controls.Add(Me.fraShowText)
        Me.fraDialogue.Controls.Add(Me.fraAddText)
        Me.fraDialogue.Controls.Add(Me.fraPlayerSwitch)
        Me.fraDialogue.Controls.Add(Me.fraChangeItems)
        Me.fraDialogue.Controls.Add(Me.fraPlayBGM)
        Me.fraDialogue.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraDialogue.Location = New System.Drawing.Point(1207, 14)
        Me.fraDialogue.Margin = New System.Windows.Forms.Padding(4)
        Me.fraDialogue.Name = "fraDialogue"
        Me.fraDialogue.Padding = New System.Windows.Forms.Padding(4)
        Me.fraDialogue.Size = New System.Drawing.Size(887, 732)
        Me.fraDialogue.TabIndex = 10
        Me.fraDialogue.TabStop = False
        Me.fraDialogue.Visible = False
        '
        'fraConditionalBranch
        '
        Me.fraConditionalBranch.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondition_Time)
        Me.fraConditionalBranch.Controls.Add(Me.optCondition9)
        Me.fraConditionalBranch.Controls.Add(Me.btnConditionalBranchOk)
        Me.fraConditionalBranch.Controls.Add(Me.btnConditionalBranchCancel)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondition_Gender)
        Me.fraConditionalBranch.Controls.Add(Me.optCondition8)
        Me.fraConditionalBranch.Controls.Add(Me.fraConditions_Quest)
        Me.fraConditionalBranch.Controls.Add(Me.nudCondition_Quest)
        Me.fraConditionalBranch.Controls.Add(Me.DarkLabel18)
        Me.fraConditionalBranch.Controls.Add(Me.optCondition7)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondition_SelfSwitchCondition)
        Me.fraConditionalBranch.Controls.Add(Me.DarkLabel17)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondition_SelfSwitch)
        Me.fraConditionalBranch.Controls.Add(Me.optCondition6)
        Me.fraConditionalBranch.Controls.Add(Me.nudCondition_LevelAmount)
        Me.fraConditionalBranch.Controls.Add(Me.optCondition5)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondition_LevelCompare)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondition_LearntSkill)
        Me.fraConditionalBranch.Controls.Add(Me.optCondition4)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondition_ClassIs)
        Me.fraConditionalBranch.Controls.Add(Me.optCondition3)
        Me.fraConditionalBranch.Controls.Add(Me.nudCondition_HasItem)
        Me.fraConditionalBranch.Controls.Add(Me.DarkLabel16)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondition_HasItem)
        Me.fraConditionalBranch.Controls.Add(Me.optCondition2)
        Me.fraConditionalBranch.Controls.Add(Me.optCondition1)
        Me.fraConditionalBranch.Controls.Add(Me.DarkLabel15)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondtion_PlayerSwitchCondition)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondition_PlayerSwitch)
        Me.fraConditionalBranch.Controls.Add(Me.nudCondition_PlayerVarCondition)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondition_PlayerVarCompare)
        Me.fraConditionalBranch.Controls.Add(Me.DarkLabel14)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondition_PlayerVarIndex)
        Me.fraConditionalBranch.Controls.Add(Me.optCondition0)
        Me.fraConditionalBranch.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraConditionalBranch.Location = New System.Drawing.Point(8, 9)
        Me.fraConditionalBranch.Margin = New System.Windows.Forms.Padding(4)
        Me.fraConditionalBranch.Name = "fraConditionalBranch"
        Me.fraConditionalBranch.Padding = New System.Windows.Forms.Padding(4)
        Me.fraConditionalBranch.Size = New System.Drawing.Size(519, 550)
        Me.fraConditionalBranch.TabIndex = 0
        Me.fraConditionalBranch.TabStop = False
        Me.fraConditionalBranch.Text = "Árvore Condicional"
        Me.fraConditionalBranch.Visible = False
        '
        'cmbCondition_Time
        '
        Me.cmbCondition_Time.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbCondition_Time.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondition_Time.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCondition_Time.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbCondition_Time.FormattingEnabled = True
        Me.cmbCondition_Time.Items.AddRange(New Object() {"Dia", "Noite", "Alvorecer", "Crepúsculo"})
        Me.cmbCondition_Time.Location = New System.Drawing.Point(318, 425)
        Me.cmbCondition_Time.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCondition_Time.Name = "cmbCondition_Time"
        Me.cmbCondition_Time.Size = New System.Drawing.Size(191, 24)
        Me.cmbCondition_Time.TabIndex = 33
        '
        'optCondition9
        '
        Me.optCondition9.AutoSize = True
        Me.optCondition9.Location = New System.Drawing.Point(8, 426)
        Me.optCondition9.Margin = New System.Windows.Forms.Padding(4)
        Me.optCondition9.Name = "optCondition9"
        Me.optCondition9.Size = New System.Drawing.Size(121, 21)
        Me.optCondition9.TabIndex = 32
        Me.optCondition9.TabStop = True
        Me.optCondition9.Text = "Hora do Dia é:"
        '
        'btnConditionalBranchOk
        '
        Me.btnConditionalBranchOk.Location = New System.Drawing.Point(301, 501)
        Me.btnConditionalBranchOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConditionalBranchOk.Name = "btnConditionalBranchOk"
        Me.btnConditionalBranchOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnConditionalBranchOk.Size = New System.Drawing.Size(100, 39)
        Me.btnConditionalBranchOk.TabIndex = 31
        Me.btnConditionalBranchOk.Text = "Confirmar"
        '
        'btnConditionalBranchCancel
        '
        Me.btnConditionalBranchCancel.Location = New System.Drawing.Point(409, 501)
        Me.btnConditionalBranchCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConditionalBranchCancel.Name = "btnConditionalBranchCancel"
        Me.btnConditionalBranchCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnConditionalBranchCancel.Size = New System.Drawing.Size(100, 39)
        Me.btnConditionalBranchCancel.TabIndex = 30
        Me.btnConditionalBranchCancel.Text = "Cancelar"
        '
        'cmbCondition_Gender
        '
        Me.cmbCondition_Gender.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbCondition_Gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondition_Gender.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCondition_Gender.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbCondition_Gender.FormattingEnabled = True
        Me.cmbCondition_Gender.Items.AddRange(New Object() {"Masculino", "Feminino"})
        Me.cmbCondition_Gender.Location = New System.Drawing.Point(318, 391)
        Me.cmbCondition_Gender.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCondition_Gender.Name = "cmbCondition_Gender"
        Me.cmbCondition_Gender.Size = New System.Drawing.Size(191, 24)
        Me.cmbCondition_Gender.TabIndex = 29
        '
        'optCondition8
        '
        Me.optCondition8.AutoSize = True
        Me.optCondition8.Location = New System.Drawing.Point(8, 393)
        Me.optCondition8.Margin = New System.Windows.Forms.Padding(4)
        Me.optCondition8.Name = "optCondition8"
        Me.optCondition8.Size = New System.Drawing.Size(169, 21)
        Me.optCondition8.TabIndex = 28
        Me.optCondition8.TabStop = True
        Me.optCondition8.Text = "Gênero do Jogador é:"
        '
        'fraConditions_Quest
        '
        Me.fraConditions_Quest.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraConditions_Quest.Controls.Add(Me.DarkLabel20)
        Me.fraConditions_Quest.Controls.Add(Me.nudCondition_QuestTask)
        Me.fraConditions_Quest.Controls.Add(Me.cmbCondition_General)
        Me.fraConditions_Quest.Controls.Add(Me.DarkLabel19)
        Me.fraConditions_Quest.Controls.Add(Me.optCondition_Quest1)
        Me.fraConditions_Quest.Controls.Add(Me.optCondition_Quest0)
        Me.fraConditions_Quest.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraConditions_Quest.Location = New System.Drawing.Point(8, 290)
        Me.fraConditions_Quest.Margin = New System.Windows.Forms.Padding(4)
        Me.fraConditions_Quest.Name = "fraConditions_Quest"
        Me.fraConditions_Quest.Padding = New System.Windows.Forms.Padding(4)
        Me.fraConditions_Quest.Size = New System.Drawing.Size(501, 94)
        Me.fraConditions_Quest.TabIndex = 27
        Me.fraConditions_Quest.TabStop = False
        Me.fraConditions_Quest.Text = "Condições da Tarefa"
        '
        'DarkLabel20
        '
        Me.DarkLabel20.AutoSize = True
        Me.DarkLabel20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel20.Location = New System.Drawing.Point(121, 60)
        Me.DarkLabel20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel20.Name = "DarkLabel20"
        Me.DarkLabel20.Size = New System.Drawing.Size(187, 17)
        Me.DarkLabel20.TabIndex = 5
        Me.DarkLabel20.Text = "Jogador está na subtarefa..."
        '
        'nudCondition_QuestTask
        '
        Me.nudCondition_QuestTask.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudCondition_QuestTask.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudCondition_QuestTask.Location = New System.Drawing.Point(311, 55)
        Me.nudCondition_QuestTask.Margin = New System.Windows.Forms.Padding(4)
        Me.nudCondition_QuestTask.Name = "nudCondition_QuestTask"
        Me.nudCondition_QuestTask.Size = New System.Drawing.Size(183, 22)
        Me.nudCondition_QuestTask.TabIndex = 4
        '
        'cmbCondition_General
        '
        Me.cmbCondition_General.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbCondition_General.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondition_General.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCondition_General.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbCondition_General.FormattingEnabled = True
        Me.cmbCondition_General.Items.AddRange(New Object() {"Não Iniciada", "Completa", "Pode Iniciar", "Pode Finalizar"})
        Me.cmbCondition_General.Location = New System.Drawing.Point(311, 22)
        Me.cmbCondition_General.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCondition_General.Name = "cmbCondition_General"
        Me.cmbCondition_General.Size = New System.Drawing.Size(182, 24)
        Me.cmbCondition_General.TabIndex = 3
        '
        'DarkLabel19
        '
        Me.DarkLabel19.AutoSize = True
        Me.DarkLabel19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel19.Location = New System.Drawing.Point(132, 25)
        Me.DarkLabel19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel19.Name = "DarkLabel19"
        Me.DarkLabel19.Size = New System.Drawing.Size(173, 17)
        Me.DarkLabel19.TabIndex = 2
        Me.DarkLabel19.Text = "Se a tarefa seleciona está"
        '
        'optCondition_Quest1
        '
        Me.optCondition_Quest1.AutoSize = True
        Me.optCondition_Quest1.Location = New System.Drawing.Point(8, 55)
        Me.optCondition_Quest1.Margin = New System.Windows.Forms.Padding(4)
        Me.optCondition_Quest1.Name = "optCondition_Quest1"
        Me.optCondition_Quest1.Size = New System.Drawing.Size(91, 21)
        Me.optCondition_Quest1.TabIndex = 1
        Me.optCondition_Quest1.TabStop = True
        Me.optCondition_Quest1.Text = "Subtarefa"
        '
        'optCondition_Quest0
        '
        Me.optCondition_Quest0.AutoSize = True
        Me.optCondition_Quest0.Location = New System.Drawing.Point(8, 23)
        Me.optCondition_Quest0.Margin = New System.Windows.Forms.Padding(4)
        Me.optCondition_Quest0.Name = "optCondition_Quest0"
        Me.optCondition_Quest0.Size = New System.Drawing.Size(64, 21)
        Me.optCondition_Quest0.TabIndex = 0
        Me.optCondition_Quest0.TabStop = True
        Me.optCondition_Quest0.Text = "Geral"
        '
        'nudCondition_Quest
        '
        Me.nudCondition_Quest.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudCondition_Quest.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudCondition_Quest.Location = New System.Drawing.Point(349, 258)
        Me.nudCondition_Quest.Margin = New System.Windows.Forms.Padding(4)
        Me.nudCondition_Quest.Name = "nudCondition_Quest"
        Me.nudCondition_Quest.Size = New System.Drawing.Size(160, 22)
        Me.nudCondition_Quest.TabIndex = 26
        '
        'DarkLabel18
        '
        Me.DarkLabel18.AutoSize = True
        Me.DarkLabel18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel18.Location = New System.Drawing.Point(291, 262)
        Me.DarkLabel18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel18.Name = "DarkLabel18"
        Me.DarkLabel18.Size = New System.Drawing.Size(50, 17)
        Me.DarkLabel18.TabIndex = 25
        Me.DarkLabel18.Text = "Quest:"
        '
        'optCondition7
        '
        Me.optCondition7.AutoSize = True
        Me.optCondition7.Location = New System.Drawing.Point(8, 258)
        Me.optCondition7.Margin = New System.Windows.Forms.Padding(4)
        Me.optCondition7.Name = "optCondition7"
        Me.optCondition7.Size = New System.Drawing.Size(143, 21)
        Me.optCondition7.TabIndex = 24
        Me.optCondition7.TabStop = True
        Me.optCondition7.Text = "Estado da Tarefa:"
        '
        'cmbCondition_SelfSwitchCondition
        '
        Me.cmbCondition_SelfSwitchCondition.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbCondition_SelfSwitchCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondition_SelfSwitchCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCondition_SelfSwitchCondition.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbCondition_SelfSwitchCondition.FormattingEnabled = True
        Me.cmbCondition_SelfSwitchCondition.Items.AddRange(New Object() {"Falso", "Verdadeiro"})
        Me.cmbCondition_SelfSwitchCondition.Location = New System.Drawing.Point(349, 226)
        Me.cmbCondition_SelfSwitchCondition.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCondition_SelfSwitchCondition.Name = "cmbCondition_SelfSwitchCondition"
        Me.cmbCondition_SelfSwitchCondition.Size = New System.Drawing.Size(160, 24)
        Me.cmbCondition_SelfSwitchCondition.TabIndex = 23
        '
        'DarkLabel17
        '
        Me.DarkLabel17.AutoSize = True
        Me.DarkLabel17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel17.Location = New System.Drawing.Point(312, 229)
        Me.DarkLabel17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel17.Name = "DarkLabel17"
        Me.DarkLabel17.Size = New System.Drawing.Size(16, 17)
        Me.DarkLabel17.TabIndex = 22
        Me.DarkLabel17.Text = "é"
        '
        'cmbCondition_SelfSwitch
        '
        Me.cmbCondition_SelfSwitch.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbCondition_SelfSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondition_SelfSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCondition_SelfSwitch.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbCondition_SelfSwitch.FormattingEnabled = True
        Me.cmbCondition_SelfSwitch.Location = New System.Drawing.Point(142, 226)
        Me.cmbCondition_SelfSwitch.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCondition_SelfSwitch.Name = "cmbCondition_SelfSwitch"
        Me.cmbCondition_SelfSwitch.Size = New System.Drawing.Size(160, 24)
        Me.cmbCondition_SelfSwitch.TabIndex = 21
        '
        'optCondition6
        '
        Me.optCondition6.AutoSize = True
        Me.optCondition6.Location = New System.Drawing.Point(8, 226)
        Me.optCondition6.Margin = New System.Windows.Forms.Padding(4)
        Me.optCondition6.Name = "optCondition6"
        Me.optCondition6.Size = New System.Drawing.Size(103, 21)
        Me.optCondition6.TabIndex = 20
        Me.optCondition6.TabStop = True
        Me.optCondition6.Text = "Auto-Switch"
        '
        'nudCondition_LevelAmount
        '
        Me.nudCondition_LevelAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudCondition_LevelAmount.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudCondition_LevelAmount.Location = New System.Drawing.Point(359, 194)
        Me.nudCondition_LevelAmount.Margin = New System.Windows.Forms.Padding(4)
        Me.nudCondition_LevelAmount.Name = "nudCondition_LevelAmount"
        Me.nudCondition_LevelAmount.Size = New System.Drawing.Size(151, 22)
        Me.nudCondition_LevelAmount.TabIndex = 19
        '
        'optCondition5
        '
        Me.optCondition5.AutoSize = True
        Me.optCondition5.Location = New System.Drawing.Point(8, 194)
        Me.optCondition5.Margin = New System.Windows.Forms.Padding(4)
        Me.optCondition5.Name = "optCondition5"
        Me.optCondition5.Size = New System.Drawing.Size(73, 21)
        Me.optCondition5.TabIndex = 18
        Me.optCondition5.TabStop = True
        Me.optCondition5.Text = "Nível É"
        '
        'cmbCondition_LevelCompare
        '
        Me.cmbCondition_LevelCompare.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbCondition_LevelCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondition_LevelCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCondition_LevelCompare.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbCondition_LevelCompare.FormattingEnabled = True
        Me.cmbCondition_LevelCompare.Items.AddRange(New Object() {"Igual a", "Maior ou Igual à", "Menor ou Igual à", "Maior Que", "Menor Que", "Diferente de"})
        Me.cmbCondition_LevelCompare.Location = New System.Drawing.Point(142, 192)
        Me.cmbCondition_LevelCompare.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCondition_LevelCompare.Name = "cmbCondition_LevelCompare"
        Me.cmbCondition_LevelCompare.Size = New System.Drawing.Size(207, 24)
        Me.cmbCondition_LevelCompare.TabIndex = 17
        '
        'cmbCondition_LearntSkill
        '
        Me.cmbCondition_LearntSkill.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbCondition_LearntSkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondition_LearntSkill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCondition_LearntSkill.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbCondition_LearntSkill.FormattingEnabled = True
        Me.cmbCondition_LearntSkill.Location = New System.Drawing.Point(142, 158)
        Me.cmbCondition_LearntSkill.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCondition_LearntSkill.Name = "cmbCondition_LearntSkill"
        Me.cmbCondition_LearntSkill.Size = New System.Drawing.Size(367, 24)
        Me.cmbCondition_LearntSkill.TabIndex = 16
        '
        'optCondition4
        '
        Me.optCondition4.AutoSize = True
        Me.optCondition4.Location = New System.Drawing.Point(8, 160)
        Me.optCondition4.Margin = New System.Windows.Forms.Padding(4)
        Me.optCondition4.Name = "optCondition4"
        Me.optCondition4.Size = New System.Drawing.Size(128, 21)
        Me.optCondition4.TabIndex = 15
        Me.optCondition4.TabStop = True
        Me.optCondition4.Text = "Tem Habilidade"
        '
        'cmbCondition_ClassIs
        '
        Me.cmbCondition_ClassIs.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbCondition_ClassIs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondition_ClassIs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCondition_ClassIs.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbCondition_ClassIs.FormattingEnabled = True
        Me.cmbCondition_ClassIs.Location = New System.Drawing.Point(142, 126)
        Me.cmbCondition_ClassIs.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCondition_ClassIs.Name = "cmbCondition_ClassIs"
        Me.cmbCondition_ClassIs.Size = New System.Drawing.Size(367, 24)
        Me.cmbCondition_ClassIs.TabIndex = 14
        '
        'optCondition3
        '
        Me.optCondition3.AutoSize = True
        Me.optCondition3.Location = New System.Drawing.Point(8, 126)
        Me.optCondition3.Margin = New System.Windows.Forms.Padding(4)
        Me.optCondition3.Name = "optCondition3"
        Me.optCondition3.Size = New System.Drawing.Size(84, 21)
        Me.optCondition3.TabIndex = 13
        Me.optCondition3.TabStop = True
        Me.optCondition3.Text = "Classe É"
        '
        'nudCondition_HasItem
        '
        Me.nudCondition_HasItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudCondition_HasItem.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudCondition_HasItem.Location = New System.Drawing.Point(349, 94)
        Me.nudCondition_HasItem.Margin = New System.Windows.Forms.Padding(4)
        Me.nudCondition_HasItem.Name = "nudCondition_HasItem"
        Me.nudCondition_HasItem.Size = New System.Drawing.Size(160, 22)
        Me.nudCondition_HasItem.TabIndex = 12
        '
        'DarkLabel16
        '
        Me.DarkLabel16.AutoSize = True
        Me.DarkLabel16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel16.Location = New System.Drawing.Point(312, 96)
        Me.DarkLabel16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel16.Name = "DarkLabel16"
        Me.DarkLabel16.Size = New System.Drawing.Size(17, 17)
        Me.DarkLabel16.TabIndex = 11
        Me.DarkLabel16.Text = "X"
        '
        'cmbCondition_HasItem
        '
        Me.cmbCondition_HasItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbCondition_HasItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondition_HasItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCondition_HasItem.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbCondition_HasItem.FormattingEnabled = True
        Me.cmbCondition_HasItem.Location = New System.Drawing.Point(142, 92)
        Me.cmbCondition_HasItem.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCondition_HasItem.Name = "cmbCondition_HasItem"
        Me.cmbCondition_HasItem.Size = New System.Drawing.Size(160, 24)
        Me.cmbCondition_HasItem.TabIndex = 10
        '
        'optCondition2
        '
        Me.optCondition2.AutoSize = True
        Me.optCondition2.Location = New System.Drawing.Point(8, 94)
        Me.optCondition2.Margin = New System.Windows.Forms.Padding(4)
        Me.optCondition2.Name = "optCondition2"
        Me.optCondition2.Size = New System.Drawing.Size(87, 21)
        Me.optCondition2.TabIndex = 9
        Me.optCondition2.TabStop = True
        Me.optCondition2.Text = "Tem Item"
        '
        'optCondition1
        '
        Me.optCondition1.AutoSize = True
        Me.optCondition1.Location = New System.Drawing.Point(8, 60)
        Me.optCondition1.Margin = New System.Windows.Forms.Padding(4)
        Me.optCondition1.Name = "optCondition1"
        Me.optCondition1.Size = New System.Drawing.Size(145, 21)
        Me.optCondition1.TabIndex = 8
        Me.optCondition1.TabStop = True
        Me.optCondition1.Text = "Switch de Jogador"
        '
        'DarkLabel15
        '
        Me.DarkLabel15.AutoSize = True
        Me.DarkLabel15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel15.Location = New System.Drawing.Point(312, 62)
        Me.DarkLabel15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel15.Name = "DarkLabel15"
        Me.DarkLabel15.Size = New System.Drawing.Size(16, 17)
        Me.DarkLabel15.TabIndex = 7
        Me.DarkLabel15.Text = "é"
        '
        'cmbCondtion_PlayerSwitchCondition
        '
        Me.cmbCondtion_PlayerSwitchCondition.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbCondtion_PlayerSwitchCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondtion_PlayerSwitchCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCondtion_PlayerSwitchCondition.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbCondtion_PlayerSwitchCondition.FormattingEnabled = True
        Me.cmbCondtion_PlayerSwitchCondition.Items.AddRange(New Object() {"Falso", "Verdadeiro"})
        Me.cmbCondtion_PlayerSwitchCondition.Location = New System.Drawing.Point(349, 59)
        Me.cmbCondtion_PlayerSwitchCondition.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCondtion_PlayerSwitchCondition.Name = "cmbCondtion_PlayerSwitchCondition"
        Me.cmbCondtion_PlayerSwitchCondition.Size = New System.Drawing.Size(160, 24)
        Me.cmbCondtion_PlayerSwitchCondition.TabIndex = 6
        '
        'cmbCondition_PlayerSwitch
        '
        Me.cmbCondition_PlayerSwitch.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbCondition_PlayerSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondition_PlayerSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCondition_PlayerSwitch.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbCondition_PlayerSwitch.FormattingEnabled = True
        Me.cmbCondition_PlayerSwitch.Location = New System.Drawing.Point(142, 59)
        Me.cmbCondition_PlayerSwitch.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCondition_PlayerSwitch.Name = "cmbCondition_PlayerSwitch"
        Me.cmbCondition_PlayerSwitch.Size = New System.Drawing.Size(160, 24)
        Me.cmbCondition_PlayerSwitch.TabIndex = 5
        '
        'nudCondition_PlayerVarCondition
        '
        Me.nudCondition_PlayerVarCondition.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudCondition_PlayerVarCondition.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudCondition_PlayerVarCondition.Location = New System.Drawing.Point(446, 27)
        Me.nudCondition_PlayerVarCondition.Margin = New System.Windows.Forms.Padding(4)
        Me.nudCondition_PlayerVarCondition.Name = "nudCondition_PlayerVarCondition"
        Me.nudCondition_PlayerVarCondition.Size = New System.Drawing.Size(62, 22)
        Me.nudCondition_PlayerVarCondition.TabIndex = 4
        '
        'cmbCondition_PlayerVarCompare
        '
        Me.cmbCondition_PlayerVarCompare.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbCondition_PlayerVarCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondition_PlayerVarCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCondition_PlayerVarCompare.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbCondition_PlayerVarCompare.FormattingEnabled = True
        Me.cmbCondition_PlayerVarCompare.Items.AddRange(New Object() {"Igual à", "Maior Que ou Igual à", "Menor Que ou Equal à", "Maior Que", "Menor Que", "Diferente de"})
        Me.cmbCondition_PlayerVarCompare.Location = New System.Drawing.Point(315, 26)
        Me.cmbCondition_PlayerVarCompare.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCondition_PlayerVarCompare.Name = "cmbCondition_PlayerVarCompare"
        Me.cmbCondition_PlayerVarCompare.Size = New System.Drawing.Size(116, 24)
        Me.cmbCondition_PlayerVarCompare.TabIndex = 3
        '
        'DarkLabel14
        '
        Me.DarkLabel14.AutoSize = True
        Me.DarkLabel14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel14.Location = New System.Drawing.Point(288, 30)
        Me.DarkLabel14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel14.Name = "DarkLabel14"
        Me.DarkLabel14.Size = New System.Drawing.Size(16, 17)
        Me.DarkLabel14.TabIndex = 2
        Me.DarkLabel14.Text = "é"
        '
        'cmbCondition_PlayerVarIndex
        '
        Me.cmbCondition_PlayerVarIndex.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbCondition_PlayerVarIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondition_PlayerVarIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCondition_PlayerVarIndex.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbCondition_PlayerVarIndex.FormattingEnabled = True
        Me.cmbCondition_PlayerVarIndex.Location = New System.Drawing.Point(142, 26)
        Me.cmbCondition_PlayerVarIndex.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCondition_PlayerVarIndex.Name = "cmbCondition_PlayerVarIndex"
        Me.cmbCondition_PlayerVarIndex.Size = New System.Drawing.Size(136, 24)
        Me.cmbCondition_PlayerVarIndex.TabIndex = 1
        '
        'optCondition0
        '
        Me.optCondition0.AutoSize = True
        Me.optCondition0.Location = New System.Drawing.Point(8, 27)
        Me.optCondition0.Margin = New System.Windows.Forms.Padding(4)
        Me.optCondition0.Name = "optCondition0"
        Me.optCondition0.Size = New System.Drawing.Size(156, 21)
        Me.optCondition0.TabIndex = 0
        Me.optCondition0.TabStop = True
        Me.optCondition0.Text = "Variável de Jogador"
        '
        'fraPlayAnimation
        '
        Me.fraPlayAnimation.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraPlayAnimation.Controls.Add(Me.btnPlayAnimationOk)
        Me.fraPlayAnimation.Controls.Add(Me.btnPlayAnimationCancel)
        Me.fraPlayAnimation.Controls.Add(Me.lblPlayAnimY)
        Me.fraPlayAnimation.Controls.Add(Me.lblPlayAnimX)
        Me.fraPlayAnimation.Controls.Add(Me.cmbPlayAnimEvent)
        Me.fraPlayAnimation.Controls.Add(Me.DarkLabel62)
        Me.fraPlayAnimation.Controls.Add(Me.cmbAnimTargetType)
        Me.fraPlayAnimation.Controls.Add(Me.nudPlayAnimTileY)
        Me.fraPlayAnimation.Controls.Add(Me.nudPlayAnimTileX)
        Me.fraPlayAnimation.Controls.Add(Me.DarkLabel61)
        Me.fraPlayAnimation.Controls.Add(Me.cmbPlayAnim)
        Me.fraPlayAnimation.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraPlayAnimation.Location = New System.Drawing.Point(535, 316)
        Me.fraPlayAnimation.Margin = New System.Windows.Forms.Padding(4)
        Me.fraPlayAnimation.Name = "fraPlayAnimation"
        Me.fraPlayAnimation.Padding = New System.Windows.Forms.Padding(4)
        Me.fraPlayAnimation.Size = New System.Drawing.Size(331, 199)
        Me.fraPlayAnimation.TabIndex = 36
        Me.fraPlayAnimation.TabStop = False
        Me.fraPlayAnimation.Text = "Play Animation"
        Me.fraPlayAnimation.Visible = False
        '
        'btnPlayAnimationOk
        '
        Me.btnPlayAnimationOk.Location = New System.Drawing.Point(115, 162)
        Me.btnPlayAnimationOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPlayAnimationOk.Name = "btnPlayAnimationOk"
        Me.btnPlayAnimationOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnPlayAnimationOk.Size = New System.Drawing.Size(100, 28)
        Me.btnPlayAnimationOk.TabIndex = 36
        Me.btnPlayAnimationOk.Text = "Ok"
        '
        'btnPlayAnimationCancel
        '
        Me.btnPlayAnimationCancel.Location = New System.Drawing.Point(222, 162)
        Me.btnPlayAnimationCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPlayAnimationCancel.Name = "btnPlayAnimationCancel"
        Me.btnPlayAnimationCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnPlayAnimationCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnPlayAnimationCancel.TabIndex = 35
        Me.btnPlayAnimationCancel.Text = "Cancel"
        '
        'lblPlayAnimY
        '
        Me.lblPlayAnimY.AutoSize = True
        Me.lblPlayAnimY.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblPlayAnimY.Location = New System.Drawing.Point(174, 130)
        Me.lblPlayAnimY.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPlayAnimY.Name = "lblPlayAnimY"
        Me.lblPlayAnimY.Size = New System.Drawing.Size(79, 17)
        Me.lblPlayAnimY.TabIndex = 34
        Me.lblPlayAnimY.Text = "Map Tile Y:"
        '
        'lblPlayAnimX
        '
        Me.lblPlayAnimX.AutoSize = True
        Me.lblPlayAnimX.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblPlayAnimX.Location = New System.Drawing.Point(8, 130)
        Me.lblPlayAnimX.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPlayAnimX.Name = "lblPlayAnimX"
        Me.lblPlayAnimX.Size = New System.Drawing.Size(79, 17)
        Me.lblPlayAnimX.TabIndex = 33
        Me.lblPlayAnimX.Text = "Map Tile X:"
        '
        'cmbPlayAnimEvent
        '
        Me.cmbPlayAnimEvent.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbPlayAnimEvent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPlayAnimEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlayAnimEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPlayAnimEvent.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbPlayAnimEvent.FormattingEnabled = True
        Me.cmbPlayAnimEvent.Location = New System.Drawing.Point(110, 90)
        Me.cmbPlayAnimEvent.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPlayAnimEvent.Name = "cmbPlayAnimEvent"
        Me.cmbPlayAnimEvent.Size = New System.Drawing.Size(210, 23)
        Me.cmbPlayAnimEvent.TabIndex = 32
        '
        'DarkLabel62
        '
        Me.DarkLabel62.AutoSize = True
        Me.DarkLabel62.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel62.Location = New System.Drawing.Point(5, 60)
        Me.DarkLabel62.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel62.Name = "DarkLabel62"
        Me.DarkLabel62.Size = New System.Drawing.Size(86, 17)
        Me.DarkLabel62.TabIndex = 31
        Me.DarkLabel62.Text = "Target Type"
        '
        'cmbAnimTargetType
        '
        Me.cmbAnimTargetType.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbAnimTargetType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAnimTargetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnimTargetType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAnimTargetType.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbAnimTargetType.FormattingEnabled = True
        Me.cmbAnimTargetType.Items.AddRange(New Object() {"Player", "Event", "Tile"})
        Me.cmbAnimTargetType.Location = New System.Drawing.Point(110, 57)
        Me.cmbAnimTargetType.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbAnimTargetType.Name = "cmbAnimTargetType"
        Me.cmbAnimTargetType.Size = New System.Drawing.Size(210, 23)
        Me.cmbAnimTargetType.TabIndex = 30
        '
        'nudPlayAnimTileY
        '
        Me.nudPlayAnimTileY.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudPlayAnimTileY.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudPlayAnimTileY.Location = New System.Drawing.Point(264, 128)
        Me.nudPlayAnimTileY.Margin = New System.Windows.Forms.Padding(4)
        Me.nudPlayAnimTileY.Name = "nudPlayAnimTileY"
        Me.nudPlayAnimTileY.Size = New System.Drawing.Size(59, 22)
        Me.nudPlayAnimTileY.TabIndex = 29
        '
        'nudPlayAnimTileX
        '
        Me.nudPlayAnimTileX.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudPlayAnimTileX.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudPlayAnimTileX.Location = New System.Drawing.Point(98, 128)
        Me.nudPlayAnimTileX.Margin = New System.Windows.Forms.Padding(4)
        Me.nudPlayAnimTileX.Name = "nudPlayAnimTileX"
        Me.nudPlayAnimTileX.Size = New System.Drawing.Size(59, 22)
        Me.nudPlayAnimTileX.TabIndex = 28
        '
        'DarkLabel61
        '
        Me.DarkLabel61.AutoSize = True
        Me.DarkLabel61.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel61.Location = New System.Drawing.Point(8, 27)
        Me.DarkLabel61.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel61.Name = "DarkLabel61"
        Me.DarkLabel61.Size = New System.Drawing.Size(74, 17)
        Me.DarkLabel61.TabIndex = 1
        Me.DarkLabel61.Text = "Animation:"
        '
        'cmbPlayAnim
        '
        Me.cmbPlayAnim.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbPlayAnim.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPlayAnim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlayAnim.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPlayAnim.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbPlayAnim.FormattingEnabled = True
        Me.cmbPlayAnim.Location = New System.Drawing.Point(83, 23)
        Me.cmbPlayAnim.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPlayAnim.Name = "cmbPlayAnim"
        Me.cmbPlayAnim.Size = New System.Drawing.Size(239, 23)
        Me.cmbPlayAnim.TabIndex = 0
        '
        'fraMoveRouteWait
        '
        Me.fraMoveRouteWait.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraMoveRouteWait.Controls.Add(Me.btnMoveWaitCancel)
        Me.fraMoveRouteWait.Controls.Add(Me.btnMoveWaitOk)
        Me.fraMoveRouteWait.Controls.Add(Me.DarkLabel79)
        Me.fraMoveRouteWait.Controls.Add(Me.cmbMoveWait)
        Me.fraMoveRouteWait.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraMoveRouteWait.Location = New System.Drawing.Point(535, 610)
        Me.fraMoveRouteWait.Margin = New System.Windows.Forms.Padding(4)
        Me.fraMoveRouteWait.Name = "fraMoveRouteWait"
        Me.fraMoveRouteWait.Padding = New System.Windows.Forms.Padding(4)
        Me.fraMoveRouteWait.Size = New System.Drawing.Size(331, 92)
        Me.fraMoveRouteWait.TabIndex = 48
        Me.fraMoveRouteWait.TabStop = False
        Me.fraMoveRouteWait.Text = "Move Route Wait"
        Me.fraMoveRouteWait.Visible = False
        '
        'btnMoveWaitCancel
        '
        Me.btnMoveWaitCancel.Location = New System.Drawing.Point(222, 57)
        Me.btnMoveWaitCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMoveWaitCancel.Name = "btnMoveWaitCancel"
        Me.btnMoveWaitCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnMoveWaitCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnMoveWaitCancel.TabIndex = 26
        Me.btnMoveWaitCancel.Text = "Cancel"
        '
        'btnMoveWaitOk
        '
        Me.btnMoveWaitOk.Location = New System.Drawing.Point(115, 57)
        Me.btnMoveWaitOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMoveWaitOk.Name = "btnMoveWaitOk"
        Me.btnMoveWaitOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnMoveWaitOk.Size = New System.Drawing.Size(100, 28)
        Me.btnMoveWaitOk.TabIndex = 27
        Me.btnMoveWaitOk.Text = "Ok"
        '
        'DarkLabel79
        '
        Me.DarkLabel79.AutoSize = True
        Me.DarkLabel79.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel79.Location = New System.Drawing.Point(9, 27)
        Me.DarkLabel79.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel79.Name = "DarkLabel79"
        Me.DarkLabel79.Size = New System.Drawing.Size(48, 17)
        Me.DarkLabel79.TabIndex = 1
        Me.DarkLabel79.Text = "Event:"
        '
        'cmbMoveWait
        '
        Me.cmbMoveWait.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbMoveWait.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMoveWait.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoveWait.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMoveWait.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbMoveWait.FormattingEnabled = True
        Me.cmbMoveWait.Location = New System.Drawing.Point(68, 23)
        Me.cmbMoveWait.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbMoveWait.Name = "cmbMoveWait"
        Me.cmbMoveWait.Size = New System.Drawing.Size(253, 23)
        Me.cmbMoveWait.TabIndex = 0
        '
        'fraCustomScript
        '
        Me.fraCustomScript.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraCustomScript.Controls.Add(Me.nudCustomScript)
        Me.fraCustomScript.Controls.Add(Me.DarkLabel78)
        Me.fraCustomScript.Controls.Add(Me.btnCustomScriptCancel)
        Me.fraCustomScript.Controls.Add(Me.btnCustomScriptOk)
        Me.fraCustomScript.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraCustomScript.Location = New System.Drawing.Point(535, 487)
        Me.fraCustomScript.Margin = New System.Windows.Forms.Padding(4)
        Me.fraCustomScript.Name = "fraCustomScript"
        Me.fraCustomScript.Padding = New System.Windows.Forms.Padding(4)
        Me.fraCustomScript.Size = New System.Drawing.Size(331, 117)
        Me.fraCustomScript.TabIndex = 47
        Me.fraCustomScript.TabStop = False
        Me.fraCustomScript.Text = "Execute Custom Script"
        Me.fraCustomScript.Visible = False
        '
        'nudCustomScript
        '
        Me.nudCustomScript.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudCustomScript.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudCustomScript.Location = New System.Drawing.Point(89, 23)
        Me.nudCustomScript.Margin = New System.Windows.Forms.Padding(4)
        Me.nudCustomScript.Name = "nudCustomScript"
        Me.nudCustomScript.Size = New System.Drawing.Size(226, 22)
        Me.nudCustomScript.TabIndex = 1
        '
        'DarkLabel78
        '
        Me.DarkLabel78.AutoSize = True
        Me.DarkLabel78.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel78.Location = New System.Drawing.Point(13, 26)
        Me.DarkLabel78.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel78.Name = "DarkLabel78"
        Me.DarkLabel78.Size = New System.Drawing.Size(44, 17)
        Me.DarkLabel78.TabIndex = 0
        Me.DarkLabel78.Text = "Case:"
        '
        'btnCustomScriptCancel
        '
        Me.btnCustomScriptCancel.Location = New System.Drawing.Point(215, 55)
        Me.btnCustomScriptCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCustomScriptCancel.Name = "btnCustomScriptCancel"
        Me.btnCustomScriptCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnCustomScriptCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnCustomScriptCancel.TabIndex = 24
        Me.btnCustomScriptCancel.Text = "Cancel"
        '
        'btnCustomScriptOk
        '
        Me.btnCustomScriptOk.Location = New System.Drawing.Point(107, 55)
        Me.btnCustomScriptOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCustomScriptOk.Name = "btnCustomScriptOk"
        Me.btnCustomScriptOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnCustomScriptOk.Size = New System.Drawing.Size(100, 28)
        Me.btnCustomScriptOk.TabIndex = 25
        Me.btnCustomScriptOk.Text = "Ok"
        '
        'fraSetWeather
        '
        Me.fraSetWeather.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraSetWeather.Controls.Add(Me.btnSetWeatherOk)
        Me.fraSetWeather.Controls.Add(Me.btnSetWeatherCancel)
        Me.fraSetWeather.Controls.Add(Me.DarkLabel76)
        Me.fraSetWeather.Controls.Add(Me.nudWeatherIntensity)
        Me.fraSetWeather.Controls.Add(Me.DarkLabel75)
        Me.fraSetWeather.Controls.Add(Me.CmbWeather)
        Me.fraSetWeather.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraSetWeather.Location = New System.Drawing.Point(535, 434)
        Me.fraSetWeather.Margin = New System.Windows.Forms.Padding(4)
        Me.fraSetWeather.Name = "fraSetWeather"
        Me.fraSetWeather.Padding = New System.Windows.Forms.Padding(4)
        Me.fraSetWeather.Size = New System.Drawing.Size(331, 117)
        Me.fraSetWeather.TabIndex = 44
        Me.fraSetWeather.TabStop = False
        Me.fraSetWeather.Text = "Set Weather"
        Me.fraSetWeather.Visible = False
        '
        'btnSetWeatherOk
        '
        Me.btnSetWeatherOk.Location = New System.Drawing.Point(61, 82)
        Me.btnSetWeatherOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSetWeatherOk.Name = "btnSetWeatherOk"
        Me.btnSetWeatherOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnSetWeatherOk.Size = New System.Drawing.Size(100, 28)
        Me.btnSetWeatherOk.TabIndex = 34
        Me.btnSetWeatherOk.Text = "Ok"
        '
        'btnSetWeatherCancel
        '
        Me.btnSetWeatherCancel.Location = New System.Drawing.Point(169, 82)
        Me.btnSetWeatherCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSetWeatherCancel.Name = "btnSetWeatherCancel"
        Me.btnSetWeatherCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnSetWeatherCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnSetWeatherCancel.TabIndex = 33
        Me.btnSetWeatherCancel.Text = "Cancel"
        '
        'DarkLabel76
        '
        Me.DarkLabel76.AutoSize = True
        Me.DarkLabel76.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel76.Location = New System.Drawing.Point(11, 54)
        Me.DarkLabel76.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel76.Name = "DarkLabel76"
        Me.DarkLabel76.Size = New System.Drawing.Size(64, 17)
        Me.DarkLabel76.TabIndex = 32
        Me.DarkLabel76.Text = "Intensity:"
        '
        'nudWeatherIntensity
        '
        Me.nudWeatherIntensity.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudWeatherIntensity.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudWeatherIntensity.Location = New System.Drawing.Point(116, 50)
        Me.nudWeatherIntensity.Margin = New System.Windows.Forms.Padding(4)
        Me.nudWeatherIntensity.Name = "nudWeatherIntensity"
        Me.nudWeatherIntensity.Size = New System.Drawing.Size(206, 22)
        Me.nudWeatherIntensity.TabIndex = 31
        '
        'DarkLabel75
        '
        Me.DarkLabel75.AutoSize = True
        Me.DarkLabel75.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel75.Location = New System.Drawing.Point(8, 22)
        Me.DarkLabel75.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel75.Name = "DarkLabel75"
        Me.DarkLabel75.Size = New System.Drawing.Size(98, 17)
        Me.DarkLabel75.TabIndex = 1
        Me.DarkLabel75.Text = "Weather Type"
        '
        'CmbWeather
        '
        Me.CmbWeather.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.CmbWeather.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbWeather.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbWeather.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbWeather.ForeColor = System.Drawing.Color.Gainsboro
        Me.CmbWeather.FormattingEnabled = True
        Me.CmbWeather.Items.AddRange(New Object() {"None", "Rain", "Snow", "Hail", "Sand Storm", "Storm"})
        Me.CmbWeather.Location = New System.Drawing.Point(115, 18)
        Me.CmbWeather.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbWeather.Name = "CmbWeather"
        Me.CmbWeather.Size = New System.Drawing.Size(205, 23)
        Me.CmbWeather.TabIndex = 0
        '
        'fraSpawnNpc
        '
        Me.fraSpawnNpc.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraSpawnNpc.Controls.Add(Me.btnSpawnNpcOk)
        Me.fraSpawnNpc.Controls.Add(Me.btnSpawnNpcCancel)
        Me.fraSpawnNpc.Controls.Add(Me.cmbSpawnNpc)
        Me.fraSpawnNpc.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraSpawnNpc.Location = New System.Drawing.Point(535, 507)
        Me.fraSpawnNpc.Margin = New System.Windows.Forms.Padding(4)
        Me.fraSpawnNpc.Name = "fraSpawnNpc"
        Me.fraSpawnNpc.Padding = New System.Windows.Forms.Padding(4)
        Me.fraSpawnNpc.Size = New System.Drawing.Size(331, 94)
        Me.fraSpawnNpc.TabIndex = 46
        Me.fraSpawnNpc.TabStop = False
        Me.fraSpawnNpc.Text = "Spawn Npc"
        Me.fraSpawnNpc.Visible = False
        '
        'btnSpawnNpcOk
        '
        Me.btnSpawnNpcOk.Location = New System.Drawing.Point(61, 58)
        Me.btnSpawnNpcOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSpawnNpcOk.Name = "btnSpawnNpcOk"
        Me.btnSpawnNpcOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnSpawnNpcOk.Size = New System.Drawing.Size(100, 28)
        Me.btnSpawnNpcOk.TabIndex = 27
        Me.btnSpawnNpcOk.Text = "Ok"
        '
        'btnSpawnNpcCancel
        '
        Me.btnSpawnNpcCancel.Location = New System.Drawing.Point(169, 58)
        Me.btnSpawnNpcCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSpawnNpcCancel.Name = "btnSpawnNpcCancel"
        Me.btnSpawnNpcCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnSpawnNpcCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnSpawnNpcCancel.TabIndex = 26
        Me.btnSpawnNpcCancel.Text = "Cancel"
        '
        'cmbSpawnNpc
        '
        Me.cmbSpawnNpc.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbSpawnNpc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSpawnNpc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSpawnNpc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSpawnNpc.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbSpawnNpc.FormattingEnabled = True
        Me.cmbSpawnNpc.Location = New System.Drawing.Point(8, 23)
        Me.cmbSpawnNpc.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSpawnNpc.Name = "cmbSpawnNpc"
        Me.cmbSpawnNpc.Size = New System.Drawing.Size(311, 23)
        Me.cmbSpawnNpc.TabIndex = 0
        '
        'fraGiveExp
        '
        Me.fraGiveExp.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraGiveExp.Controls.Add(Me.btnGiveExpOk)
        Me.fraGiveExp.Controls.Add(Me.btnGiveExpCancel)
        Me.fraGiveExp.Controls.Add(Me.nudGiveExp)
        Me.fraGiveExp.Controls.Add(Me.DarkLabel77)
        Me.fraGiveExp.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraGiveExp.Location = New System.Drawing.Point(535, 434)
        Me.fraGiveExp.Margin = New System.Windows.Forms.Padding(4)
        Me.fraGiveExp.Name = "fraGiveExp"
        Me.fraGiveExp.Padding = New System.Windows.Forms.Padding(4)
        Me.fraGiveExp.Size = New System.Drawing.Size(331, 90)
        Me.fraGiveExp.TabIndex = 45
        Me.fraGiveExp.TabStop = False
        Me.fraGiveExp.Text = "Give Experience"
        Me.fraGiveExp.Visible = False
        '
        'btnGiveExpOk
        '
        Me.btnGiveExpOk.Location = New System.Drawing.Point(67, 55)
        Me.btnGiveExpOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGiveExpOk.Name = "btnGiveExpOk"
        Me.btnGiveExpOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnGiveExpOk.Size = New System.Drawing.Size(100, 28)
        Me.btnGiveExpOk.TabIndex = 27
        Me.btnGiveExpOk.Text = "Ok"
        '
        'btnGiveExpCancel
        '
        Me.btnGiveExpCancel.Location = New System.Drawing.Point(174, 55)
        Me.btnGiveExpCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGiveExpCancel.Name = "btnGiveExpCancel"
        Me.btnGiveExpCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnGiveExpCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnGiveExpCancel.TabIndex = 26
        Me.btnGiveExpCancel.Text = "Cancel"
        '
        'nudGiveExp
        '
        Me.nudGiveExp.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudGiveExp.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudGiveExp.Location = New System.Drawing.Point(103, 23)
        Me.nudGiveExp.Margin = New System.Windows.Forms.Padding(4)
        Me.nudGiveExp.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.nudGiveExp.Name = "nudGiveExp"
        Me.nudGiveExp.Size = New System.Drawing.Size(220, 22)
        Me.nudGiveExp.TabIndex = 20
        '
        'DarkLabel77
        '
        Me.DarkLabel77.AutoSize = True
        Me.DarkLabel77.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel77.Location = New System.Drawing.Point(8, 26)
        Me.DarkLabel77.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel77.Name = "DarkLabel77"
        Me.DarkLabel77.Size = New System.Drawing.Size(68, 17)
        Me.DarkLabel77.TabIndex = 0
        Me.DarkLabel77.Text = "Give Exp:"
        '
        'fraEndQuest
        '
        Me.fraEndQuest.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraEndQuest.Controls.Add(Me.btnEndQuestOk)
        Me.fraEndQuest.Controls.Add(Me.btnEndQuestCancel)
        Me.fraEndQuest.Controls.Add(Me.cmbEndQuest)
        Me.fraEndQuest.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraEndQuest.Location = New System.Drawing.Point(535, 512)
        Me.fraEndQuest.Margin = New System.Windows.Forms.Padding(4)
        Me.fraEndQuest.Name = "fraEndQuest"
        Me.fraEndQuest.Padding = New System.Windows.Forms.Padding(4)
        Me.fraEndQuest.Size = New System.Drawing.Size(331, 90)
        Me.fraEndQuest.TabIndex = 43
        Me.fraEndQuest.TabStop = False
        Me.fraEndQuest.Text = "End Quest"
        Me.fraEndQuest.Visible = False
        '
        'btnEndQuestOk
        '
        Me.btnEndQuestOk.Location = New System.Drawing.Point(61, 54)
        Me.btnEndQuestOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEndQuestOk.Name = "btnEndQuestOk"
        Me.btnEndQuestOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnEndQuestOk.Size = New System.Drawing.Size(100, 28)
        Me.btnEndQuestOk.TabIndex = 30
        Me.btnEndQuestOk.Text = "Ok"
        '
        'btnEndQuestCancel
        '
        Me.btnEndQuestCancel.Location = New System.Drawing.Point(169, 54)
        Me.btnEndQuestCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEndQuestCancel.Name = "btnEndQuestCancel"
        Me.btnEndQuestCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnEndQuestCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnEndQuestCancel.TabIndex = 29
        Me.btnEndQuestCancel.Text = "Cancel"
        '
        'cmbEndQuest
        '
        Me.cmbEndQuest.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbEndQuest.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbEndQuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEndQuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbEndQuest.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbEndQuest.FormattingEnabled = True
        Me.cmbEndQuest.Location = New System.Drawing.Point(44, 18)
        Me.cmbEndQuest.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbEndQuest.Name = "cmbEndQuest"
        Me.cmbEndQuest.Size = New System.Drawing.Size(249, 23)
        Me.cmbEndQuest.TabIndex = 28
        '
        'fraSetAccess
        '
        Me.fraSetAccess.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraSetAccess.Controls.Add(Me.btnSetAccessOk)
        Me.fraSetAccess.Controls.Add(Me.btnSetAccessCancel)
        Me.fraSetAccess.Controls.Add(Me.cmbSetAccess)
        Me.fraSetAccess.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraSetAccess.Location = New System.Drawing.Point(535, 434)
        Me.fraSetAccess.Margin = New System.Windows.Forms.Padding(4)
        Me.fraSetAccess.Name = "fraSetAccess"
        Me.fraSetAccess.Padding = New System.Windows.Forms.Padding(4)
        Me.fraSetAccess.Size = New System.Drawing.Size(331, 98)
        Me.fraSetAccess.TabIndex = 42
        Me.fraSetAccess.TabStop = False
        Me.fraSetAccess.Text = "Set Access"
        Me.fraSetAccess.Visible = False
        '
        'btnSetAccessOk
        '
        Me.btnSetAccessOk.Location = New System.Drawing.Point(61, 59)
        Me.btnSetAccessOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSetAccessOk.Name = "btnSetAccessOk"
        Me.btnSetAccessOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnSetAccessOk.Size = New System.Drawing.Size(100, 28)
        Me.btnSetAccessOk.TabIndex = 27
        Me.btnSetAccessOk.Text = "Ok"
        '
        'btnSetAccessCancel
        '
        Me.btnSetAccessCancel.Location = New System.Drawing.Point(169, 59)
        Me.btnSetAccessCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSetAccessCancel.Name = "btnSetAccessCancel"
        Me.btnSetAccessCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnSetAccessCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnSetAccessCancel.TabIndex = 26
        Me.btnSetAccessCancel.Text = "Cancel"
        '
        'cmbSetAccess
        '
        Me.cmbSetAccess.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbSetAccess.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSetAccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSetAccess.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSetAccess.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbSetAccess.FormattingEnabled = True
        Me.cmbSetAccess.Items.AddRange(New Object() {"0: Player", "1: Monitor", "2: Mapper", "3: Developer", "4: Creator"})
        Me.cmbSetAccess.Location = New System.Drawing.Point(44, 23)
        Me.cmbSetAccess.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSetAccess.Name = "cmbSetAccess"
        Me.cmbSetAccess.Size = New System.Drawing.Size(249, 23)
        Me.cmbSetAccess.TabIndex = 0
        '
        'fraSetWait
        '
        Me.fraSetWait.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraSetWait.Controls.Add(Me.btnSetWaitOk)
        Me.fraSetWait.Controls.Add(Me.btnSetWaitCancel)
        Me.fraSetWait.Controls.Add(Me.DarkLabel74)
        Me.fraSetWait.Controls.Add(Me.DarkLabel72)
        Me.fraSetWait.Controls.Add(Me.DarkLabel73)
        Me.fraSetWait.Controls.Add(Me.nudWaitAmount)
        Me.fraSetWait.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraSetWait.Location = New System.Drawing.Point(535, 325)
        Me.fraSetWait.Margin = New System.Windows.Forms.Padding(4)
        Me.fraSetWait.Name = "fraSetWait"
        Me.fraSetWait.Padding = New System.Windows.Forms.Padding(4)
        Me.fraSetWait.Size = New System.Drawing.Size(331, 110)
        Me.fraSetWait.TabIndex = 41
        Me.fraSetWait.TabStop = False
        Me.fraSetWait.Text = "Wait..."
        Me.fraSetWait.Visible = False
        '
        'btnSetWaitOk
        '
        Me.btnSetWaitOk.Location = New System.Drawing.Point(67, 71)
        Me.btnSetWaitOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSetWaitOk.Name = "btnSetWaitOk"
        Me.btnSetWaitOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnSetWaitOk.Size = New System.Drawing.Size(100, 28)
        Me.btnSetWaitOk.TabIndex = 37
        Me.btnSetWaitOk.Text = "Ok"
        '
        'btnSetWaitCancel
        '
        Me.btnSetWaitCancel.Location = New System.Drawing.Point(174, 71)
        Me.btnSetWaitCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSetWaitCancel.Name = "btnSetWaitCancel"
        Me.btnSetWaitCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnSetWaitCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnSetWaitCancel.TabIndex = 36
        Me.btnSetWaitCancel.Text = "Cancel"
        '
        'DarkLabel74
        '
        Me.DarkLabel74.AutoSize = True
        Me.DarkLabel74.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel74.Location = New System.Drawing.Point(93, 52)
        Me.DarkLabel74.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel74.Name = "DarkLabel74"
        Me.DarkLabel74.Size = New System.Drawing.Size(147, 17)
        Me.DarkLabel74.TabIndex = 35
        Me.DarkLabel74.Text = "Hint: 1000 Ms = 1 Sec"
        '
        'DarkLabel72
        '
        Me.DarkLabel72.AutoSize = True
        Me.DarkLabel72.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel72.Location = New System.Drawing.Point(291, 28)
        Me.DarkLabel72.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel72.Name = "DarkLabel72"
        Me.DarkLabel72.Size = New System.Drawing.Size(26, 17)
        Me.DarkLabel72.TabIndex = 34
        Me.DarkLabel72.Text = "Ms"
        '
        'DarkLabel73
        '
        Me.DarkLabel73.AutoSize = True
        Me.DarkLabel73.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel73.Location = New System.Drawing.Point(20, 28)
        Me.DarkLabel73.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel73.Name = "DarkLabel73"
        Me.DarkLabel73.Size = New System.Drawing.Size(36, 17)
        Me.DarkLabel73.TabIndex = 33
        Me.DarkLabel73.Text = "Wait"
        '
        'nudWaitAmount
        '
        Me.nudWaitAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudWaitAmount.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudWaitAmount.Location = New System.Drawing.Point(67, 23)
        Me.nudWaitAmount.Margin = New System.Windows.Forms.Padding(4)
        Me.nudWaitAmount.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.nudWaitAmount.Name = "nudWaitAmount"
        Me.nudWaitAmount.Size = New System.Drawing.Size(217, 22)
        Me.nudWaitAmount.TabIndex = 32
        '
        'fraShowPic
        '
        Me.fraShowPic.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraShowPic.Controls.Add(Me.btnShowPicOk)
        Me.fraShowPic.Controls.Add(Me.btnShowPicCancel)
        Me.fraShowPic.Controls.Add(Me.DarkLabel71)
        Me.fraShowPic.Controls.Add(Me.DarkLabel70)
        Me.fraShowPic.Controls.Add(Me.DarkLabel67)
        Me.fraShowPic.Controls.Add(Me.DarkLabel68)
        Me.fraShowPic.Controls.Add(Me.nudPicOffsetY)
        Me.fraShowPic.Controls.Add(Me.nudPicOffsetX)
        Me.fraShowPic.Controls.Add(Me.DarkLabel69)
        Me.fraShowPic.Controls.Add(Me.cmbPicLoc)
        Me.fraShowPic.Controls.Add(Me.nudShowPicture)
        Me.fraShowPic.Controls.Add(Me.picShowPic)
        Me.fraShowPic.Controls.Add(Me.cmbPicIndex)
        Me.fraShowPic.Controls.Add(Me.DarkLabel66)
        Me.fraShowPic.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraShowPic.Location = New System.Drawing.Point(535, 327)
        Me.fraShowPic.Margin = New System.Windows.Forms.Padding(4)
        Me.fraShowPic.Name = "fraShowPic"
        Me.fraShowPic.Padding = New System.Windows.Forms.Padding(4)
        Me.fraShowPic.Size = New System.Drawing.Size(331, 274)
        Me.fraShowPic.TabIndex = 40
        Me.fraShowPic.TabStop = False
        Me.fraShowPic.Text = "Show Picture"
        Me.fraShowPic.Visible = False
        '
        'btnShowPicOk
        '
        Me.btnShowPicOk.Location = New System.Drawing.Point(115, 238)
        Me.btnShowPicOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnShowPicOk.Name = "btnShowPicOk"
        Me.btnShowPicOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnShowPicOk.Size = New System.Drawing.Size(100, 28)
        Me.btnShowPicOk.TabIndex = 55
        Me.btnShowPicOk.Text = "Ok"
        '
        'btnShowPicCancel
        '
        Me.btnShowPicCancel.Location = New System.Drawing.Point(222, 238)
        Me.btnShowPicCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnShowPicCancel.Name = "btnShowPicCancel"
        Me.btnShowPicCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnShowPicCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnShowPicCancel.TabIndex = 54
        Me.btnShowPicCancel.Text = "Cancel"
        '
        'DarkLabel71
        '
        Me.DarkLabel71.AutoSize = True
        Me.DarkLabel71.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel71.Location = New System.Drawing.Point(13, 171)
        Me.DarkLabel71.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel71.Name = "DarkLabel71"
        Me.DarkLabel71.Size = New System.Drawing.Size(140, 17)
        Me.DarkLabel71.TabIndex = 53
        Me.DarkLabel71.Text = "Offset from Location:"
        '
        'DarkLabel70
        '
        Me.DarkLabel70.AutoSize = True
        Me.DarkLabel70.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel70.Location = New System.Drawing.Point(149, 98)
        Me.DarkLabel70.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel70.Name = "DarkLabel70"
        Me.DarkLabel70.Size = New System.Drawing.Size(62, 17)
        Me.DarkLabel70.TabIndex = 52
        Me.DarkLabel70.Text = "Location"
        '
        'DarkLabel67
        '
        Me.DarkLabel67.AutoSize = True
        Me.DarkLabel67.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel67.Location = New System.Drawing.Point(183, 199)
        Me.DarkLabel67.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel67.Name = "DarkLabel67"
        Me.DarkLabel67.Size = New System.Drawing.Size(21, 17)
        Me.DarkLabel67.TabIndex = 51
        Me.DarkLabel67.Text = "Y:"
        '
        'DarkLabel68
        '
        Me.DarkLabel68.AutoSize = True
        Me.DarkLabel68.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel68.Location = New System.Drawing.Point(13, 202)
        Me.DarkLabel68.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel68.Name = "DarkLabel68"
        Me.DarkLabel68.Size = New System.Drawing.Size(21, 17)
        Me.DarkLabel68.TabIndex = 50
        Me.DarkLabel68.Text = "X:"
        '
        'nudPicOffsetY
        '
        Me.nudPicOffsetY.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudPicOffsetY.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudPicOffsetY.Location = New System.Drawing.Point(243, 197)
        Me.nudPicOffsetY.Margin = New System.Windows.Forms.Padding(4)
        Me.nudPicOffsetY.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudPicOffsetY.Name = "nudPicOffsetY"
        Me.nudPicOffsetY.Size = New System.Drawing.Size(76, 22)
        Me.nudPicOffsetY.TabIndex = 49
        '
        'nudPicOffsetX
        '
        Me.nudPicOffsetX.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudPicOffsetX.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudPicOffsetX.Location = New System.Drawing.Point(69, 197)
        Me.nudPicOffsetX.Margin = New System.Windows.Forms.Padding(4)
        Me.nudPicOffsetX.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudPicOffsetX.Name = "nudPicOffsetX"
        Me.nudPicOffsetX.Size = New System.Drawing.Size(76, 22)
        Me.nudPicOffsetX.TabIndex = 48
        '
        'DarkLabel69
        '
        Me.DarkLabel69.AutoSize = True
        Me.DarkLabel69.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel69.Location = New System.Drawing.Point(155, 57)
        Me.DarkLabel69.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel69.Name = "DarkLabel69"
        Me.DarkLabel69.Size = New System.Drawing.Size(56, 17)
        Me.DarkLabel69.TabIndex = 47
        Me.DarkLabel69.Text = "Picture:"
        '
        'cmbPicLoc
        '
        Me.cmbPicLoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbPicLoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPicLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPicLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPicLoc.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbPicLoc.FormattingEnabled = True
        Me.cmbPicLoc.Items.AddRange(New Object() {"Top Left of Screen", "Center Screen", "Centered on Player"})
        Me.cmbPicLoc.Location = New System.Drawing.Point(153, 121)
        Me.cmbPicLoc.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPicLoc.Name = "cmbPicLoc"
        Me.cmbPicLoc.Size = New System.Drawing.Size(164, 23)
        Me.cmbPicLoc.TabIndex = 46
        '
        'nudShowPicture
        '
        Me.nudShowPicture.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudShowPicture.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudShowPicture.Location = New System.Drawing.Point(220, 54)
        Me.nudShowPicture.Margin = New System.Windows.Forms.Padding(4)
        Me.nudShowPicture.Name = "nudShowPicture"
        Me.nudShowPicture.Size = New System.Drawing.Size(100, 22)
        Me.nudShowPicture.TabIndex = 45
        '
        'picShowPic
        '
        Me.picShowPic.BackColor = System.Drawing.Color.Black
        Me.picShowPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picShowPic.Location = New System.Drawing.Point(12, 53)
        Me.picShowPic.Margin = New System.Windows.Forms.Padding(4)
        Me.picShowPic.Name = "picShowPic"
        Me.picShowPic.Size = New System.Drawing.Size(133, 114)
        Me.picShowPic.TabIndex = 42
        Me.picShowPic.TabStop = False
        '
        'cmbPicIndex
        '
        Me.cmbPicIndex.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbPicIndex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPicIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPicIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPicIndex.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbPicIndex.FormattingEnabled = True
        Me.cmbPicIndex.Location = New System.Drawing.Point(104, 21)
        Me.cmbPicIndex.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPicIndex.Name = "cmbPicIndex"
        Me.cmbPicIndex.Size = New System.Drawing.Size(215, 23)
        Me.cmbPicIndex.TabIndex = 1
        '
        'DarkLabel66
        '
        Me.DarkLabel66.AutoSize = True
        Me.DarkLabel66.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel66.Location = New System.Drawing.Point(8, 25)
        Me.DarkLabel66.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel66.Name = "DarkLabel66"
        Me.DarkLabel66.Size = New System.Drawing.Size(93, 17)
        Me.DarkLabel66.TabIndex = 0
        Me.DarkLabel66.Text = "Picture Index:"
        '
        'fraOpenShop
        '
        Me.fraOpenShop.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraOpenShop.Controls.Add(Me.btnOpenShopOk)
        Me.fraOpenShop.Controls.Add(Me.btnOpenShopCancel)
        Me.fraOpenShop.Controls.Add(Me.cmbOpenShop)
        Me.fraOpenShop.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraOpenShop.Location = New System.Drawing.Point(537, 267)
        Me.fraOpenShop.Margin = New System.Windows.Forms.Padding(4)
        Me.fraOpenShop.Name = "fraOpenShop"
        Me.fraOpenShop.Padding = New System.Windows.Forms.Padding(4)
        Me.fraOpenShop.Size = New System.Drawing.Size(328, 98)
        Me.fraOpenShop.TabIndex = 39
        Me.fraOpenShop.TabStop = False
        Me.fraOpenShop.Text = "Open Shop"
        Me.fraOpenShop.Visible = False
        '
        'btnOpenShopOk
        '
        Me.btnOpenShopOk.Location = New System.Drawing.Point(59, 58)
        Me.btnOpenShopOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOpenShopOk.Name = "btnOpenShopOk"
        Me.btnOpenShopOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnOpenShopOk.Size = New System.Drawing.Size(100, 28)
        Me.btnOpenShopOk.TabIndex = 27
        Me.btnOpenShopOk.Text = "Ok"
        '
        'btnOpenShopCancel
        '
        Me.btnOpenShopCancel.Location = New System.Drawing.Point(167, 58)
        Me.btnOpenShopCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOpenShopCancel.Name = "btnOpenShopCancel"
        Me.btnOpenShopCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnOpenShopCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnOpenShopCancel.TabIndex = 26
        Me.btnOpenShopCancel.Text = "Cancel"
        '
        'cmbOpenShop
        '
        Me.cmbOpenShop.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbOpenShop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbOpenShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOpenShop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbOpenShop.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbOpenShop.FormattingEnabled = True
        Me.cmbOpenShop.Location = New System.Drawing.Point(12, 25)
        Me.cmbOpenShop.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbOpenShop.Name = "cmbOpenShop"
        Me.cmbOpenShop.Size = New System.Drawing.Size(300, 23)
        Me.cmbOpenShop.TabIndex = 0
        '
        'fraChangeLevel
        '
        Me.fraChangeLevel.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraChangeLevel.Controls.Add(Me.btnChangeLevelOk)
        Me.fraChangeLevel.Controls.Add(Me.btnChangeLevelCancel)
        Me.fraChangeLevel.Controls.Add(Me.DarkLabel65)
        Me.fraChangeLevel.Controls.Add(Me.nudChangeLevel)
        Me.fraChangeLevel.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraChangeLevel.Location = New System.Drawing.Point(535, 361)
        Me.fraChangeLevel.Margin = New System.Windows.Forms.Padding(4)
        Me.fraChangeLevel.Name = "fraChangeLevel"
        Me.fraChangeLevel.Padding = New System.Windows.Forms.Padding(4)
        Me.fraChangeLevel.Size = New System.Drawing.Size(331, 89)
        Me.fraChangeLevel.TabIndex = 38
        Me.fraChangeLevel.TabStop = False
        Me.fraChangeLevel.Text = "Change Level"
        Me.fraChangeLevel.Visible = False
        '
        'btnChangeLevelOk
        '
        Me.btnChangeLevelOk.Location = New System.Drawing.Point(61, 55)
        Me.btnChangeLevelOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnChangeLevelOk.Name = "btnChangeLevelOk"
        Me.btnChangeLevelOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnChangeLevelOk.Size = New System.Drawing.Size(100, 28)
        Me.btnChangeLevelOk.TabIndex = 27
        Me.btnChangeLevelOk.Text = "Ok"
        '
        'btnChangeLevelCancel
        '
        Me.btnChangeLevelCancel.Location = New System.Drawing.Point(169, 55)
        Me.btnChangeLevelCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnChangeLevelCancel.Name = "btnChangeLevelCancel"
        Me.btnChangeLevelCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnChangeLevelCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnChangeLevelCancel.TabIndex = 26
        Me.btnChangeLevelCancel.Text = "Cancel"
        '
        'DarkLabel65
        '
        Me.DarkLabel65.AutoSize = True
        Me.DarkLabel65.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel65.Location = New System.Drawing.Point(9, 26)
        Me.DarkLabel65.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel65.Name = "DarkLabel65"
        Me.DarkLabel65.Size = New System.Drawing.Size(46, 17)
        Me.DarkLabel65.TabIndex = 24
        Me.DarkLabel65.Text = "Level:"
        '
        'nudChangeLevel
        '
        Me.nudChangeLevel.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudChangeLevel.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudChangeLevel.Location = New System.Drawing.Point(80, 23)
        Me.nudChangeLevel.Margin = New System.Windows.Forms.Padding(4)
        Me.nudChangeLevel.Name = "nudChangeLevel"
        Me.nudChangeLevel.Size = New System.Drawing.Size(160, 22)
        Me.nudChangeLevel.TabIndex = 23
        '
        'fraChangeGender
        '
        Me.fraChangeGender.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraChangeGender.Controls.Add(Me.btnChangeGenderOk)
        Me.fraChangeGender.Controls.Add(Me.btnChangeGenderCancel)
        Me.fraChangeGender.Controls.Add(Me.optChangeSexFemale)
        Me.fraChangeGender.Controls.Add(Me.optChangeSexMale)
        Me.fraChangeGender.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraChangeGender.Location = New System.Drawing.Point(535, 448)
        Me.fraChangeGender.Margin = New System.Windows.Forms.Padding(4)
        Me.fraChangeGender.Name = "fraChangeGender"
        Me.fraChangeGender.Padding = New System.Windows.Forms.Padding(4)
        Me.fraChangeGender.Size = New System.Drawing.Size(331, 89)
        Me.fraChangeGender.TabIndex = 37
        Me.fraChangeGender.TabStop = False
        Me.fraChangeGender.Text = "Change Player Gender"
        Me.fraChangeGender.Visible = False
        '
        'btnChangeGenderOk
        '
        Me.btnChangeGenderOk.Location = New System.Drawing.Point(52, 52)
        Me.btnChangeGenderOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnChangeGenderOk.Name = "btnChangeGenderOk"
        Me.btnChangeGenderOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnChangeGenderOk.Size = New System.Drawing.Size(100, 28)
        Me.btnChangeGenderOk.TabIndex = 27
        Me.btnChangeGenderOk.Text = "Ok"
        '
        'btnChangeGenderCancel
        '
        Me.btnChangeGenderCancel.Location = New System.Drawing.Point(160, 52)
        Me.btnChangeGenderCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnChangeGenderCancel.Name = "btnChangeGenderCancel"
        Me.btnChangeGenderCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnChangeGenderCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnChangeGenderCancel.TabIndex = 26
        Me.btnChangeGenderCancel.Text = "Cancel"
        '
        'optChangeSexFemale
        '
        Me.optChangeSexFemale.AutoSize = True
        Me.optChangeSexFemale.Location = New System.Drawing.Point(188, 23)
        Me.optChangeSexFemale.Margin = New System.Windows.Forms.Padding(4)
        Me.optChangeSexFemale.Name = "optChangeSexFemale"
        Me.optChangeSexFemale.Size = New System.Drawing.Size(75, 21)
        Me.optChangeSexFemale.TabIndex = 1
        Me.optChangeSexFemale.TabStop = True
        Me.optChangeSexFemale.Text = "Female"
        '
        'optChangeSexMale
        '
        Me.optChangeSexMale.AutoSize = True
        Me.optChangeSexMale.Location = New System.Drawing.Point(69, 23)
        Me.optChangeSexMale.Margin = New System.Windows.Forms.Padding(4)
        Me.optChangeSexMale.Name = "optChangeSexMale"
        Me.optChangeSexMale.Size = New System.Drawing.Size(59, 21)
        Me.optChangeSexMale.TabIndex = 0
        Me.optChangeSexMale.TabStop = True
        Me.optChangeSexMale.Text = "Male"
        '
        'fraGoToLabel
        '
        Me.fraGoToLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraGoToLabel.Controls.Add(Me.btnGoToLabelOk)
        Me.fraGoToLabel.Controls.Add(Me.btnGoToLabelCancel)
        Me.fraGoToLabel.Controls.Add(Me.txtGotoLabel)
        Me.fraGoToLabel.Controls.Add(Me.DarkLabel60)
        Me.fraGoToLabel.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraGoToLabel.Location = New System.Drawing.Point(535, 314)
        Me.fraGoToLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.fraGoToLabel.Name = "fraGoToLabel"
        Me.fraGoToLabel.Padding = New System.Windows.Forms.Padding(4)
        Me.fraGoToLabel.Size = New System.Drawing.Size(331, 90)
        Me.fraGoToLabel.TabIndex = 35
        Me.fraGoToLabel.TabStop = False
        Me.fraGoToLabel.Text = "GoTo Label"
        Me.fraGoToLabel.Visible = False
        '
        'btnGoToLabelOk
        '
        Me.btnGoToLabelOk.Location = New System.Drawing.Point(115, 54)
        Me.btnGoToLabelOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGoToLabelOk.Name = "btnGoToLabelOk"
        Me.btnGoToLabelOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnGoToLabelOk.Size = New System.Drawing.Size(100, 28)
        Me.btnGoToLabelOk.TabIndex = 27
        Me.btnGoToLabelOk.Text = "Ok"
        '
        'btnGoToLabelCancel
        '
        Me.btnGoToLabelCancel.Location = New System.Drawing.Point(222, 54)
        Me.btnGoToLabelCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGoToLabelCancel.Name = "btnGoToLabelCancel"
        Me.btnGoToLabelCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnGoToLabelCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnGoToLabelCancel.TabIndex = 26
        Me.btnGoToLabelCancel.Text = "Cancel"
        '
        'txtGotoLabel
        '
        Me.txtGotoLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtGotoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGotoLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtGotoLabel.Location = New System.Drawing.Point(104, 22)
        Me.txtGotoLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGotoLabel.Name = "txtGotoLabel"
        Me.txtGotoLabel.Size = New System.Drawing.Size(218, 22)
        Me.txtGotoLabel.TabIndex = 1
        '
        'DarkLabel60
        '
        Me.DarkLabel60.AutoSize = True
        Me.DarkLabel60.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel60.Location = New System.Drawing.Point(4, 25)
        Me.DarkLabel60.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel60.Name = "DarkLabel60"
        Me.DarkLabel60.Size = New System.Drawing.Size(88, 17)
        Me.DarkLabel60.TabIndex = 0
        Me.DarkLabel60.Text = "Label Name:"
        '
        'fraHidePic
        '
        Me.fraHidePic.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraHidePic.Controls.Add(Me.btnHidePicOk)
        Me.fraHidePic.Controls.Add(Me.btnHidePicCancel)
        Me.fraHidePic.Controls.Add(Me.nudHidePic)
        Me.fraHidePic.Controls.Add(Me.DarkLabel59)
        Me.fraHidePic.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraHidePic.Location = New System.Drawing.Point(535, 226)
        Me.fraHidePic.Margin = New System.Windows.Forms.Padding(4)
        Me.fraHidePic.Name = "fraHidePic"
        Me.fraHidePic.Padding = New System.Windows.Forms.Padding(4)
        Me.fraHidePic.Size = New System.Drawing.Size(331, 87)
        Me.fraHidePic.TabIndex = 34
        Me.fraHidePic.TabStop = False
        Me.fraHidePic.Text = "Hide Picture"
        Me.fraHidePic.Visible = False
        '
        'btnHidePicOk
        '
        Me.btnHidePicOk.Location = New System.Drawing.Point(115, 50)
        Me.btnHidePicOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnHidePicOk.Name = "btnHidePicOk"
        Me.btnHidePicOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnHidePicOk.Size = New System.Drawing.Size(100, 28)
        Me.btnHidePicOk.TabIndex = 27
        Me.btnHidePicOk.Text = "Ok"
        '
        'btnHidePicCancel
        '
        Me.btnHidePicCancel.Location = New System.Drawing.Point(222, 50)
        Me.btnHidePicCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnHidePicCancel.Name = "btnHidePicCancel"
        Me.btnHidePicCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnHidePicCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnHidePicCancel.TabIndex = 26
        Me.btnHidePicCancel.Text = "Cancel"
        '
        'nudHidePic
        '
        Me.nudHidePic.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudHidePic.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudHidePic.Location = New System.Drawing.Point(112, 18)
        Me.nudHidePic.Margin = New System.Windows.Forms.Padding(4)
        Me.nudHidePic.Name = "nudHidePic"
        Me.nudHidePic.Size = New System.Drawing.Size(211, 22)
        Me.nudHidePic.TabIndex = 1
        '
        'DarkLabel59
        '
        Me.DarkLabel59.AutoSize = True
        Me.DarkLabel59.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel59.Location = New System.Drawing.Point(8, 20)
        Me.DarkLabel59.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel59.Name = "DarkLabel59"
        Me.DarkLabel59.Size = New System.Drawing.Size(93, 17)
        Me.DarkLabel59.TabIndex = 0
        Me.DarkLabel59.Text = "Picture Index:"
        '
        'fraBeginQuest
        '
        Me.fraBeginQuest.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraBeginQuest.Controls.Add(Me.btnBeginQuestOk)
        Me.fraBeginQuest.Controls.Add(Me.btnBeginQuestCancel)
        Me.fraBeginQuest.Controls.Add(Me.cmbBeginQuest)
        Me.fraBeginQuest.Controls.Add(Me.DarkLabel58)
        Me.fraBeginQuest.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraBeginQuest.Location = New System.Drawing.Point(535, 130)
        Me.fraBeginQuest.Margin = New System.Windows.Forms.Padding(4)
        Me.fraBeginQuest.Name = "fraBeginQuest"
        Me.fraBeginQuest.Padding = New System.Windows.Forms.Padding(4)
        Me.fraBeginQuest.Size = New System.Drawing.Size(331, 98)
        Me.fraBeginQuest.TabIndex = 33
        Me.fraBeginQuest.TabStop = False
        Me.fraBeginQuest.Text = "Begin Quest"
        Me.fraBeginQuest.Visible = False
        '
        'btnBeginQuestOk
        '
        Me.btnBeginQuestOk.Location = New System.Drawing.Point(115, 58)
        Me.btnBeginQuestOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBeginQuestOk.Name = "btnBeginQuestOk"
        Me.btnBeginQuestOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnBeginQuestOk.Size = New System.Drawing.Size(100, 28)
        Me.btnBeginQuestOk.TabIndex = 27
        Me.btnBeginQuestOk.Text = "Ok"
        '
        'btnBeginQuestCancel
        '
        Me.btnBeginQuestCancel.Location = New System.Drawing.Point(222, 58)
        Me.btnBeginQuestCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBeginQuestCancel.Name = "btnBeginQuestCancel"
        Me.btnBeginQuestCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnBeginQuestCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnBeginQuestCancel.TabIndex = 26
        Me.btnBeginQuestCancel.Text = "Cancel"
        '
        'cmbBeginQuest
        '
        Me.cmbBeginQuest.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbBeginQuest.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbBeginQuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBeginQuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbBeginQuest.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbBeginQuest.FormattingEnabled = True
        Me.cmbBeginQuest.Location = New System.Drawing.Point(67, 25)
        Me.cmbBeginQuest.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbBeginQuest.Name = "cmbBeginQuest"
        Me.cmbBeginQuest.Size = New System.Drawing.Size(252, 23)
        Me.cmbBeginQuest.TabIndex = 1
        '
        'DarkLabel58
        '
        Me.DarkLabel58.AutoSize = True
        Me.DarkLabel58.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel58.Location = New System.Drawing.Point(8, 28)
        Me.DarkLabel58.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel58.Name = "DarkLabel58"
        Me.DarkLabel58.Size = New System.Drawing.Size(50, 17)
        Me.DarkLabel58.TabIndex = 0
        Me.DarkLabel58.Text = "Quest:"
        '
        'fraShowChoices
        '
        Me.fraShowChoices.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraShowChoices.Controls.Add(Me.txtChoices4)
        Me.fraShowChoices.Controls.Add(Me.txtChoices3)
        Me.fraShowChoices.Controls.Add(Me.txtChoices2)
        Me.fraShowChoices.Controls.Add(Me.txtChoices1)
        Me.fraShowChoices.Controls.Add(Me.DarkLabel56)
        Me.fraShowChoices.Controls.Add(Me.DarkLabel57)
        Me.fraShowChoices.Controls.Add(Me.DarkLabel55)
        Me.fraShowChoices.Controls.Add(Me.DarkLabel54)
        Me.fraShowChoices.Controls.Add(Me.DarkLabel52)
        Me.fraShowChoices.Controls.Add(Me.txtChoicePrompt)
        Me.fraShowChoices.Controls.Add(Me.btnShowChoicesOk)
        Me.fraShowChoices.Controls.Add(Me.picShowChoicesFace)
        Me.fraShowChoices.Controls.Add(Me.btnShowChoicesCancel)
        Me.fraShowChoices.Controls.Add(Me.DarkLabel53)
        Me.fraShowChoices.Controls.Add(Me.nudShowChoicesFace)
        Me.fraShowChoices.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraShowChoices.Location = New System.Drawing.Point(535, 126)
        Me.fraShowChoices.Margin = New System.Windows.Forms.Padding(4)
        Me.fraShowChoices.Name = "fraShowChoices"
        Me.fraShowChoices.Padding = New System.Windows.Forms.Padding(4)
        Me.fraShowChoices.Size = New System.Drawing.Size(331, 410)
        Me.fraShowChoices.TabIndex = 32
        Me.fraShowChoices.TabStop = False
        Me.fraShowChoices.Text = "Show Choices"
        Me.fraShowChoices.Visible = False
        '
        'txtChoices4
        '
        Me.txtChoices4.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtChoices4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChoices4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtChoices4.Location = New System.Drawing.Point(188, 214)
        Me.txtChoices4.Margin = New System.Windows.Forms.Padding(4)
        Me.txtChoices4.Name = "txtChoices4"
        Me.txtChoices4.Size = New System.Drawing.Size(133, 22)
        Me.txtChoices4.TabIndex = 34
        '
        'txtChoices3
        '
        Me.txtChoices3.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtChoices3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChoices3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtChoices3.Location = New System.Drawing.Point(8, 213)
        Me.txtChoices3.Margin = New System.Windows.Forms.Padding(4)
        Me.txtChoices3.Name = "txtChoices3"
        Me.txtChoices3.Size = New System.Drawing.Size(133, 22)
        Me.txtChoices3.TabIndex = 33
        '
        'txtChoices2
        '
        Me.txtChoices2.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtChoices2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChoices2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtChoices2.Location = New System.Drawing.Point(188, 165)
        Me.txtChoices2.Margin = New System.Windows.Forms.Padding(4)
        Me.txtChoices2.Name = "txtChoices2"
        Me.txtChoices2.Size = New System.Drawing.Size(133, 22)
        Me.txtChoices2.TabIndex = 32
        '
        'txtChoices1
        '
        Me.txtChoices1.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtChoices1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChoices1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtChoices1.Location = New System.Drawing.Point(8, 165)
        Me.txtChoices1.Margin = New System.Windows.Forms.Padding(4)
        Me.txtChoices1.Name = "txtChoices1"
        Me.txtChoices1.Size = New System.Drawing.Size(133, 22)
        Me.txtChoices1.TabIndex = 31
        '
        'DarkLabel56
        '
        Me.DarkLabel56.AutoSize = True
        Me.DarkLabel56.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel56.Location = New System.Drawing.Point(184, 194)
        Me.DarkLabel56.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel56.Name = "DarkLabel56"
        Me.DarkLabel56.Size = New System.Drawing.Size(63, 17)
        Me.DarkLabel56.TabIndex = 30
        Me.DarkLabel56.Text = "Choice 4"
        '
        'DarkLabel57
        '
        Me.DarkLabel57.AutoSize = True
        Me.DarkLabel57.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel57.Location = New System.Drawing.Point(9, 194)
        Me.DarkLabel57.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel57.Name = "DarkLabel57"
        Me.DarkLabel57.Size = New System.Drawing.Size(63, 17)
        Me.DarkLabel57.TabIndex = 29
        Me.DarkLabel57.Text = "Choice 3"
        '
        'DarkLabel55
        '
        Me.DarkLabel55.AutoSize = True
        Me.DarkLabel55.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel55.Location = New System.Drawing.Point(184, 146)
        Me.DarkLabel55.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel55.Name = "DarkLabel55"
        Me.DarkLabel55.Size = New System.Drawing.Size(63, 17)
        Me.DarkLabel55.TabIndex = 28
        Me.DarkLabel55.Text = "Choice 2"
        '
        'DarkLabel54
        '
        Me.DarkLabel54.AutoSize = True
        Me.DarkLabel54.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel54.Location = New System.Drawing.Point(8, 146)
        Me.DarkLabel54.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel54.Name = "DarkLabel54"
        Me.DarkLabel54.Size = New System.Drawing.Size(63, 17)
        Me.DarkLabel54.TabIndex = 27
        Me.DarkLabel54.Text = "Choice 1"
        '
        'DarkLabel52
        '
        Me.DarkLabel52.AutoSize = True
        Me.DarkLabel52.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel52.Location = New System.Drawing.Point(9, 23)
        Me.DarkLabel52.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel52.Name = "DarkLabel52"
        Me.DarkLabel52.Size = New System.Drawing.Size(53, 17)
        Me.DarkLabel52.TabIndex = 26
        Me.DarkLabel52.Text = "Prompt"
        '
        'txtChoicePrompt
        '
        Me.txtChoicePrompt.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtChoicePrompt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChoicePrompt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtChoicePrompt.Location = New System.Drawing.Point(12, 46)
        Me.txtChoicePrompt.Margin = New System.Windows.Forms.Padding(4)
        Me.txtChoicePrompt.Multiline = True
        Me.txtChoicePrompt.Name = "txtChoicePrompt"
        Me.txtChoicePrompt.Size = New System.Drawing.Size(303, 94)
        Me.txtChoicePrompt.TabIndex = 21
        '
        'btnShowChoicesOk
        '
        Me.btnShowChoicesOk.Location = New System.Drawing.Point(112, 375)
        Me.btnShowChoicesOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnShowChoicesOk.Name = "btnShowChoicesOk"
        Me.btnShowChoicesOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnShowChoicesOk.Size = New System.Drawing.Size(100, 28)
        Me.btnShowChoicesOk.TabIndex = 25
        Me.btnShowChoicesOk.Text = "Ok"
        '
        'picShowChoicesFace
        '
        Me.picShowChoicesFace.BackColor = System.Drawing.Color.Black
        Me.picShowChoicesFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picShowChoicesFace.Location = New System.Drawing.Point(8, 245)
        Me.picShowChoicesFace.Margin = New System.Windows.Forms.Padding(4)
        Me.picShowChoicesFace.Name = "picShowChoicesFace"
        Me.picShowChoicesFace.Size = New System.Drawing.Size(133, 114)
        Me.picShowChoicesFace.TabIndex = 2
        Me.picShowChoicesFace.TabStop = False
        '
        'btnShowChoicesCancel
        '
        Me.btnShowChoicesCancel.Location = New System.Drawing.Point(220, 375)
        Me.btnShowChoicesCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnShowChoicesCancel.Name = "btnShowChoicesCancel"
        Me.btnShowChoicesCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnShowChoicesCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnShowChoicesCancel.TabIndex = 24
        Me.btnShowChoicesCancel.Text = "Cancel"
        '
        'DarkLabel53
        '
        Me.DarkLabel53.AutoSize = True
        Me.DarkLabel53.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel53.Location = New System.Drawing.Point(146, 338)
        Me.DarkLabel53.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel53.Name = "DarkLabel53"
        Me.DarkLabel53.Size = New System.Drawing.Size(43, 17)
        Me.DarkLabel53.TabIndex = 22
        Me.DarkLabel53.Text = "Face:"
        '
        'nudShowChoicesFace
        '
        Me.nudShowChoicesFace.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudShowChoicesFace.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudShowChoicesFace.Location = New System.Drawing.Point(195, 334)
        Me.nudShowChoicesFace.Margin = New System.Windows.Forms.Padding(4)
        Me.nudShowChoicesFace.Name = "nudShowChoicesFace"
        Me.nudShowChoicesFace.Size = New System.Drawing.Size(123, 22)
        Me.nudShowChoicesFace.TabIndex = 23
        '
        'fraPlayerVariable
        '
        Me.fraPlayerVariable.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraPlayerVariable.Controls.Add(Me.nudVariableData2)
        Me.fraPlayerVariable.Controls.Add(Me.optVariableAction2)
        Me.fraPlayerVariable.Controls.Add(Me.btnPlayerVarOk)
        Me.fraPlayerVariable.Controls.Add(Me.btnPlayerVarCancel)
        Me.fraPlayerVariable.Controls.Add(Me.DarkLabel51)
        Me.fraPlayerVariable.Controls.Add(Me.DarkLabel50)
        Me.fraPlayerVariable.Controls.Add(Me.nudVariableData4)
        Me.fraPlayerVariable.Controls.Add(Me.nudVariableData3)
        Me.fraPlayerVariable.Controls.Add(Me.optVariableAction3)
        Me.fraPlayerVariable.Controls.Add(Me.optVariableAction1)
        Me.fraPlayerVariable.Controls.Add(Me.nudVariableData1)
        Me.fraPlayerVariable.Controls.Add(Me.nudVariableData0)
        Me.fraPlayerVariable.Controls.Add(Me.optVariableAction0)
        Me.fraPlayerVariable.Controls.Add(Me.cmbVariable)
        Me.fraPlayerVariable.Controls.Add(Me.DarkLabel49)
        Me.fraPlayerVariable.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraPlayerVariable.Location = New System.Drawing.Point(535, 347)
        Me.fraPlayerVariable.Margin = New System.Windows.Forms.Padding(4)
        Me.fraPlayerVariable.Name = "fraPlayerVariable"
        Me.fraPlayerVariable.Padding = New System.Windows.Forms.Padding(4)
        Me.fraPlayerVariable.Size = New System.Drawing.Size(328, 190)
        Me.fraPlayerVariable.TabIndex = 31
        Me.fraPlayerVariable.TabStop = False
        Me.fraPlayerVariable.Text = "Player Variable"
        Me.fraPlayerVariable.Visible = False
        '
        'nudVariableData2
        '
        Me.nudVariableData2.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudVariableData2.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudVariableData2.Location = New System.Drawing.Point(160, 89)
        Me.nudVariableData2.Margin = New System.Windows.Forms.Padding(4)
        Me.nudVariableData2.Name = "nudVariableData2"
        Me.nudVariableData2.Size = New System.Drawing.Size(160, 22)
        Me.nudVariableData2.TabIndex = 29
        '
        'optVariableAction2
        '
        Me.optVariableAction2.AutoSize = True
        Me.optVariableAction2.Location = New System.Drawing.Point(8, 89)
        Me.optVariableAction2.Margin = New System.Windows.Forms.Padding(4)
        Me.optVariableAction2.Name = "optVariableAction2"
        Me.optVariableAction2.Size = New System.Drawing.Size(82, 21)
        Me.optVariableAction2.TabIndex = 28
        Me.optVariableAction2.TabStop = True
        Me.optVariableAction2.Text = "Subtract"
        '
        'btnPlayerVarOk
        '
        Me.btnPlayerVarOk.Location = New System.Drawing.Point(112, 153)
        Me.btnPlayerVarOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPlayerVarOk.Name = "btnPlayerVarOk"
        Me.btnPlayerVarOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnPlayerVarOk.Size = New System.Drawing.Size(100, 28)
        Me.btnPlayerVarOk.TabIndex = 27
        Me.btnPlayerVarOk.Text = "Ok"
        '
        'btnPlayerVarCancel
        '
        Me.btnPlayerVarCancel.Location = New System.Drawing.Point(220, 153)
        Me.btnPlayerVarCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPlayerVarCancel.Name = "btnPlayerVarCancel"
        Me.btnPlayerVarCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnPlayerVarCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnPlayerVarCancel.TabIndex = 26
        Me.btnPlayerVarCancel.Text = "Cancel"
        '
        'DarkLabel51
        '
        Me.DarkLabel51.AutoSize = True
        Me.DarkLabel51.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel51.Location = New System.Drawing.Point(100, 123)
        Me.DarkLabel51.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel51.Name = "DarkLabel51"
        Me.DarkLabel51.Size = New System.Drawing.Size(37, 17)
        Me.DarkLabel51.TabIndex = 16
        Me.DarkLabel51.Text = "Low:"
        '
        'DarkLabel50
        '
        Me.DarkLabel50.AutoSize = True
        Me.DarkLabel50.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel50.Location = New System.Drawing.Point(211, 123)
        Me.DarkLabel50.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel50.Name = "DarkLabel50"
        Me.DarkLabel50.Size = New System.Drawing.Size(41, 17)
        Me.DarkLabel50.TabIndex = 15
        Me.DarkLabel50.Text = "High:"
        '
        'nudVariableData4
        '
        Me.nudVariableData4.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudVariableData4.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudVariableData4.Location = New System.Drawing.Point(261, 121)
        Me.nudVariableData4.Margin = New System.Windows.Forms.Padding(4)
        Me.nudVariableData4.Name = "nudVariableData4"
        Me.nudVariableData4.Size = New System.Drawing.Size(59, 22)
        Me.nudVariableData4.TabIndex = 14
        '
        'nudVariableData3
        '
        Me.nudVariableData3.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudVariableData3.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudVariableData3.Location = New System.Drawing.Point(148, 121)
        Me.nudVariableData3.Margin = New System.Windows.Forms.Padding(4)
        Me.nudVariableData3.Name = "nudVariableData3"
        Me.nudVariableData3.Size = New System.Drawing.Size(59, 22)
        Me.nudVariableData3.TabIndex = 13
        '
        'optVariableAction3
        '
        Me.optVariableAction3.AutoSize = True
        Me.optVariableAction3.Location = New System.Drawing.Point(8, 121)
        Me.optVariableAction3.Margin = New System.Windows.Forms.Padding(4)
        Me.optVariableAction3.Name = "optVariableAction3"
        Me.optVariableAction3.Size = New System.Drawing.Size(82, 21)
        Me.optVariableAction3.TabIndex = 12
        Me.optVariableAction3.TabStop = True
        Me.optVariableAction3.Text = "Random"
        '
        'optVariableAction1
        '
        Me.optVariableAction1.AutoSize = True
        Me.optVariableAction1.Location = New System.Drawing.Point(195, 57)
        Me.optVariableAction1.Margin = New System.Windows.Forms.Padding(4)
        Me.optVariableAction1.Name = "optVariableAction1"
        Me.optVariableAction1.Size = New System.Drawing.Size(54, 21)
        Me.optVariableAction1.TabIndex = 11
        Me.optVariableAction1.TabStop = True
        Me.optVariableAction1.Text = "Add"
        '
        'nudVariableData1
        '
        Me.nudVariableData1.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudVariableData1.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudVariableData1.Location = New System.Drawing.Point(261, 57)
        Me.nudVariableData1.Margin = New System.Windows.Forms.Padding(4)
        Me.nudVariableData1.Name = "nudVariableData1"
        Me.nudVariableData1.Size = New System.Drawing.Size(59, 22)
        Me.nudVariableData1.TabIndex = 10
        '
        'nudVariableData0
        '
        Me.nudVariableData0.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudVariableData0.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudVariableData0.Location = New System.Drawing.Point(83, 57)
        Me.nudVariableData0.Margin = New System.Windows.Forms.Padding(4)
        Me.nudVariableData0.Name = "nudVariableData0"
        Me.nudVariableData0.Size = New System.Drawing.Size(59, 22)
        Me.nudVariableData0.TabIndex = 9
        '
        'optVariableAction0
        '
        Me.optVariableAction0.AutoSize = True
        Me.optVariableAction0.Location = New System.Drawing.Point(8, 57)
        Me.optVariableAction0.Margin = New System.Windows.Forms.Padding(4)
        Me.optVariableAction0.Name = "optVariableAction0"
        Me.optVariableAction0.Size = New System.Drawing.Size(50, 21)
        Me.optVariableAction0.TabIndex = 2
        Me.optVariableAction0.TabStop = True
        Me.optVariableAction0.Text = "Set"
        '
        'cmbVariable
        '
        Me.cmbVariable.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVariable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbVariable.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbVariable.FormattingEnabled = True
        Me.cmbVariable.Location = New System.Drawing.Point(80, 23)
        Me.cmbVariable.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbVariable.Name = "cmbVariable"
        Me.cmbVariable.Size = New System.Drawing.Size(237, 23)
        Me.cmbVariable.TabIndex = 1
        '
        'DarkLabel49
        '
        Me.DarkLabel49.AutoSize = True
        Me.DarkLabel49.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel49.Location = New System.Drawing.Point(8, 27)
        Me.DarkLabel49.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel49.Name = "DarkLabel49"
        Me.DarkLabel49.Size = New System.Drawing.Size(64, 17)
        Me.DarkLabel49.TabIndex = 0
        Me.DarkLabel49.Text = "Variable:"
        '
        'fraChangeSprite
        '
        Me.fraChangeSprite.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraChangeSprite.Controls.Add(Me.btnChangeSpriteOk)
        Me.fraChangeSprite.Controls.Add(Me.btnChangeSpriteCancel)
        Me.fraChangeSprite.Controls.Add(Me.DarkLabel48)
        Me.fraChangeSprite.Controls.Add(Me.nudChangeSprite)
        Me.fraChangeSprite.Controls.Add(Me.picChangeSprite)
        Me.fraChangeSprite.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraChangeSprite.Location = New System.Drawing.Point(535, 345)
        Me.fraChangeSprite.Margin = New System.Windows.Forms.Padding(4)
        Me.fraChangeSprite.Name = "fraChangeSprite"
        Me.fraChangeSprite.Padding = New System.Windows.Forms.Padding(4)
        Me.fraChangeSprite.Size = New System.Drawing.Size(328, 144)
        Me.fraChangeSprite.TabIndex = 30
        Me.fraChangeSprite.TabStop = False
        Me.fraChangeSprite.Text = "Change Sprite"
        Me.fraChangeSprite.Visible = False
        '
        'btnChangeSpriteOk
        '
        Me.btnChangeSpriteOk.Location = New System.Drawing.Point(112, 110)
        Me.btnChangeSpriteOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnChangeSpriteOk.Name = "btnChangeSpriteOk"
        Me.btnChangeSpriteOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnChangeSpriteOk.Size = New System.Drawing.Size(100, 28)
        Me.btnChangeSpriteOk.TabIndex = 30
        Me.btnChangeSpriteOk.Text = "Ok"
        '
        'btnChangeSpriteCancel
        '
        Me.btnChangeSpriteCancel.Location = New System.Drawing.Point(220, 110)
        Me.btnChangeSpriteCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnChangeSpriteCancel.Name = "btnChangeSpriteCancel"
        Me.btnChangeSpriteCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnChangeSpriteCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnChangeSpriteCancel.TabIndex = 29
        Me.btnChangeSpriteCancel.Text = "Cancel"
        '
        'DarkLabel48
        '
        Me.DarkLabel48.AutoSize = True
        Me.DarkLabel48.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel48.Location = New System.Drawing.Point(107, 82)
        Me.DarkLabel48.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel48.Name = "DarkLabel48"
        Me.DarkLabel48.Size = New System.Drawing.Size(45, 17)
        Me.DarkLabel48.TabIndex = 28
        Me.DarkLabel48.Text = "Sprite"
        '
        'nudChangeSprite
        '
        Me.nudChangeSprite.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudChangeSprite.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudChangeSprite.Location = New System.Drawing.Point(160, 78)
        Me.nudChangeSprite.Margin = New System.Windows.Forms.Padding(4)
        Me.nudChangeSprite.Name = "nudChangeSprite"
        Me.nudChangeSprite.Size = New System.Drawing.Size(160, 22)
        Me.nudChangeSprite.TabIndex = 27
        '
        'picChangeSprite
        '
        Me.picChangeSprite.BackColor = System.Drawing.Color.Black
        Me.picChangeSprite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picChangeSprite.Location = New System.Drawing.Point(8, 23)
        Me.picChangeSprite.Margin = New System.Windows.Forms.Padding(4)
        Me.picChangeSprite.Name = "picChangeSprite"
        Me.picChangeSprite.Size = New System.Drawing.Size(93, 114)
        Me.picChangeSprite.TabIndex = 3
        Me.picChangeSprite.TabStop = False
        '
        'fraSetSelfSwitch
        '
        Me.fraSetSelfSwitch.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraSetSelfSwitch.Controls.Add(Me.btnSelfswitchOk)
        Me.fraSetSelfSwitch.Controls.Add(Me.btnSelfswitchCancel)
        Me.fraSetSelfSwitch.Controls.Add(Me.DarkLabel47)
        Me.fraSetSelfSwitch.Controls.Add(Me.cmbSetSelfSwitchTo)
        Me.fraSetSelfSwitch.Controls.Add(Me.DarkLabel46)
        Me.fraSetSelfSwitch.Controls.Add(Me.cmbSetSelfSwitch)
        Me.fraSetSelfSwitch.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraSetSelfSwitch.Location = New System.Drawing.Point(535, 222)
        Me.fraSetSelfSwitch.Margin = New System.Windows.Forms.Padding(4)
        Me.fraSetSelfSwitch.Name = "fraSetSelfSwitch"
        Me.fraSetSelfSwitch.Padding = New System.Windows.Forms.Padding(4)
        Me.fraSetSelfSwitch.Size = New System.Drawing.Size(328, 123)
        Me.fraSetSelfSwitch.TabIndex = 29
        Me.fraSetSelfSwitch.TabStop = False
        Me.fraSetSelfSwitch.Text = "Self Switches"
        Me.fraSetSelfSwitch.Visible = False
        '
        'btnSelfswitchOk
        '
        Me.btnSelfswitchOk.Location = New System.Drawing.Point(112, 90)
        Me.btnSelfswitchOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSelfswitchOk.Name = "btnSelfswitchOk"
        Me.btnSelfswitchOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnSelfswitchOk.Size = New System.Drawing.Size(100, 28)
        Me.btnSelfswitchOk.TabIndex = 27
        Me.btnSelfswitchOk.Text = "Ok"
        '
        'btnSelfswitchCancel
        '
        Me.btnSelfswitchCancel.Location = New System.Drawing.Point(220, 90)
        Me.btnSelfswitchCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSelfswitchCancel.Name = "btnSelfswitchCancel"
        Me.btnSelfswitchCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnSelfswitchCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnSelfswitchCancel.TabIndex = 26
        Me.btnSelfswitchCancel.Text = "Cancel"
        '
        'DarkLabel47
        '
        Me.DarkLabel47.AutoSize = True
        Me.DarkLabel47.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel47.Location = New System.Drawing.Point(8, 60)
        Me.DarkLabel47.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel47.Name = "DarkLabel47"
        Me.DarkLabel47.Size = New System.Drawing.Size(50, 17)
        Me.DarkLabel47.TabIndex = 3
        Me.DarkLabel47.Text = "Set To"
        '
        'cmbSetSelfSwitchTo
        '
        Me.cmbSetSelfSwitchTo.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbSetSelfSwitchTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSetSelfSwitchTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSetSelfSwitchTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSetSelfSwitchTo.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbSetSelfSwitchTo.FormattingEnabled = True
        Me.cmbSetSelfSwitchTo.Items.AddRange(New Object() {"Off", "On"})
        Me.cmbSetSelfSwitchTo.Location = New System.Drawing.Point(96, 57)
        Me.cmbSetSelfSwitchTo.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSetSelfSwitchTo.Name = "cmbSetSelfSwitchTo"
        Me.cmbSetSelfSwitchTo.Size = New System.Drawing.Size(223, 23)
        Me.cmbSetSelfSwitchTo.TabIndex = 2
        '
        'DarkLabel46
        '
        Me.DarkLabel46.AutoSize = True
        Me.DarkLabel46.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel46.Location = New System.Drawing.Point(8, 27)
        Me.DarkLabel46.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel46.Name = "DarkLabel46"
        Me.DarkLabel46.Size = New System.Drawing.Size(80, 17)
        Me.DarkLabel46.TabIndex = 1
        Me.DarkLabel46.Text = "Self Switch:"
        '
        'cmbSetSelfSwitch
        '
        Me.cmbSetSelfSwitch.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbSetSelfSwitch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSetSelfSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSetSelfSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSetSelfSwitch.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbSetSelfSwitch.FormattingEnabled = True
        Me.cmbSetSelfSwitch.Location = New System.Drawing.Point(96, 23)
        Me.cmbSetSelfSwitch.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSetSelfSwitch.Name = "cmbSetSelfSwitch"
        Me.cmbSetSelfSwitch.Size = New System.Drawing.Size(223, 23)
        Me.cmbSetSelfSwitch.TabIndex = 0
        '
        'fraMapTint
        '
        Me.fraMapTint.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraMapTint.Controls.Add(Me.btnMapTintOk)
        Me.fraMapTint.Controls.Add(Me.btnMapTintCancel)
        Me.fraMapTint.Controls.Add(Me.DarkLabel42)
        Me.fraMapTint.Controls.Add(Me.nudMapTintData3)
        Me.fraMapTint.Controls.Add(Me.nudMapTintData2)
        Me.fraMapTint.Controls.Add(Me.DarkLabel43)
        Me.fraMapTint.Controls.Add(Me.DarkLabel44)
        Me.fraMapTint.Controls.Add(Me.nudMapTintData1)
        Me.fraMapTint.Controls.Add(Me.nudMapTintData0)
        Me.fraMapTint.Controls.Add(Me.DarkLabel45)
        Me.fraMapTint.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraMapTint.Location = New System.Drawing.Point(535, 222)
        Me.fraMapTint.Margin = New System.Windows.Forms.Padding(4)
        Me.fraMapTint.Name = "fraMapTint"
        Me.fraMapTint.Padding = New System.Windows.Forms.Padding(4)
        Me.fraMapTint.Size = New System.Drawing.Size(328, 178)
        Me.fraMapTint.TabIndex = 28
        Me.fraMapTint.TabStop = False
        Me.fraMapTint.Text = "Map Tinting"
        Me.fraMapTint.Visible = False
        '
        'btnMapTintOk
        '
        Me.btnMapTintOk.Location = New System.Drawing.Point(112, 142)
        Me.btnMapTintOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMapTintOk.Name = "btnMapTintOk"
        Me.btnMapTintOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnMapTintOk.Size = New System.Drawing.Size(100, 28)
        Me.btnMapTintOk.TabIndex = 45
        Me.btnMapTintOk.Text = "Ok"
        '
        'btnMapTintCancel
        '
        Me.btnMapTintCancel.Location = New System.Drawing.Point(220, 142)
        Me.btnMapTintCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMapTintCancel.Name = "btnMapTintCancel"
        Me.btnMapTintCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnMapTintCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnMapTintCancel.TabIndex = 44
        Me.btnMapTintCancel.Text = "Cancel"
        '
        'DarkLabel42
        '
        Me.DarkLabel42.AutoSize = True
        Me.DarkLabel42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel42.Location = New System.Drawing.Point(7, 114)
        Me.DarkLabel42.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel42.Name = "DarkLabel42"
        Me.DarkLabel42.Size = New System.Drawing.Size(60, 17)
        Me.DarkLabel42.TabIndex = 43
        Me.DarkLabel42.Text = "Opacity:"
        '
        'nudMapTintData3
        '
        Me.nudMapTintData3.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudMapTintData3.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudMapTintData3.Location = New System.Drawing.Point(126, 110)
        Me.nudMapTintData3.Margin = New System.Windows.Forms.Padding(4)
        Me.nudMapTintData3.Name = "nudMapTintData3"
        Me.nudMapTintData3.Size = New System.Drawing.Size(192, 22)
        Me.nudMapTintData3.TabIndex = 42
        '
        'nudMapTintData2
        '
        Me.nudMapTintData2.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudMapTintData2.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudMapTintData2.Location = New System.Drawing.Point(126, 78)
        Me.nudMapTintData2.Margin = New System.Windows.Forms.Padding(4)
        Me.nudMapTintData2.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudMapTintData2.Name = "nudMapTintData2"
        Me.nudMapTintData2.Size = New System.Drawing.Size(192, 22)
        Me.nudMapTintData2.TabIndex = 41
        '
        'DarkLabel43
        '
        Me.DarkLabel43.AutoSize = True
        Me.DarkLabel43.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel43.Location = New System.Drawing.Point(7, 82)
        Me.DarkLabel43.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel43.Name = "DarkLabel43"
        Me.DarkLabel43.Size = New System.Drawing.Size(40, 17)
        Me.DarkLabel43.TabIndex = 40
        Me.DarkLabel43.Text = "Blue:"
        '
        'DarkLabel44
        '
        Me.DarkLabel44.AutoSize = True
        Me.DarkLabel44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel44.Location = New System.Drawing.Point(5, 53)
        Me.DarkLabel44.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel44.Name = "DarkLabel44"
        Me.DarkLabel44.Size = New System.Drawing.Size(52, 17)
        Me.DarkLabel44.TabIndex = 39
        Me.DarkLabel44.Text = "Green:"
        '
        'nudMapTintData1
        '
        Me.nudMapTintData1.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudMapTintData1.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudMapTintData1.Location = New System.Drawing.Point(126, 48)
        Me.nudMapTintData1.Margin = New System.Windows.Forms.Padding(4)
        Me.nudMapTintData1.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudMapTintData1.Name = "nudMapTintData1"
        Me.nudMapTintData1.Size = New System.Drawing.Size(192, 22)
        Me.nudMapTintData1.TabIndex = 38
        '
        'nudMapTintData0
        '
        Me.nudMapTintData0.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudMapTintData0.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudMapTintData0.Location = New System.Drawing.Point(126, 18)
        Me.nudMapTintData0.Margin = New System.Windows.Forms.Padding(4)
        Me.nudMapTintData0.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudMapTintData0.Name = "nudMapTintData0"
        Me.nudMapTintData0.Size = New System.Drawing.Size(192, 22)
        Me.nudMapTintData0.TabIndex = 37
        '
        'DarkLabel45
        '
        Me.DarkLabel45.AutoSize = True
        Me.DarkLabel45.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel45.Location = New System.Drawing.Point(7, 20)
        Me.DarkLabel45.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel45.Name = "DarkLabel45"
        Me.DarkLabel45.Size = New System.Drawing.Size(38, 17)
        Me.DarkLabel45.TabIndex = 36
        Me.DarkLabel45.Text = "Red:"
        '
        'fraShowChatBubble
        '
        Me.fraShowChatBubble.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraShowChatBubble.Controls.Add(Me.btnShowChatBubbleOk)
        Me.fraShowChatBubble.Controls.Add(Me.btnShowChatBubbleCancel)
        Me.fraShowChatBubble.Controls.Add(Me.DarkLabel41)
        Me.fraShowChatBubble.Controls.Add(Me.cmbChatBubbleTarget)
        Me.fraShowChatBubble.Controls.Add(Me.cmbChatBubbleTargetType)
        Me.fraShowChatBubble.Controls.Add(Me.DarkLabel40)
        Me.fraShowChatBubble.Controls.Add(Me.txtChatbubbleText)
        Me.fraShowChatBubble.Controls.Add(Me.DarkLabel39)
        Me.fraShowChatBubble.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraShowChatBubble.Location = New System.Drawing.Point(535, 222)
        Me.fraShowChatBubble.Margin = New System.Windows.Forms.Padding(4)
        Me.fraShowChatBubble.Name = "fraShowChatBubble"
        Me.fraShowChatBubble.Padding = New System.Windows.Forms.Padding(4)
        Me.fraShowChatBubble.Size = New System.Drawing.Size(328, 174)
        Me.fraShowChatBubble.TabIndex = 27
        Me.fraShowChatBubble.TabStop = False
        Me.fraShowChatBubble.Text = "Show ChatBubble"
        Me.fraShowChatBubble.Visible = False
        '
        'btnShowChatBubbleOk
        '
        Me.btnShowChatBubbleOk.Location = New System.Drawing.Point(112, 138)
        Me.btnShowChatBubbleOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnShowChatBubbleOk.Name = "btnShowChatBubbleOk"
        Me.btnShowChatBubbleOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnShowChatBubbleOk.Size = New System.Drawing.Size(100, 28)
        Me.btnShowChatBubbleOk.TabIndex = 31
        Me.btnShowChatBubbleOk.Text = "Ok"
        '
        'btnShowChatBubbleCancel
        '
        Me.btnShowChatBubbleCancel.Location = New System.Drawing.Point(220, 138)
        Me.btnShowChatBubbleCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnShowChatBubbleCancel.Name = "btnShowChatBubbleCancel"
        Me.btnShowChatBubbleCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnShowChatBubbleCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnShowChatBubbleCancel.TabIndex = 30
        Me.btnShowChatBubbleCancel.Text = "Cancel"
        '
        'DarkLabel41
        '
        Me.DarkLabel41.AutoSize = True
        Me.DarkLabel41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel41.Location = New System.Drawing.Point(8, 108)
        Me.DarkLabel41.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel41.Name = "DarkLabel41"
        Me.DarkLabel41.Size = New System.Drawing.Size(45, 17)
        Me.DarkLabel41.TabIndex = 29
        Me.DarkLabel41.Text = "Index:"
        '
        'cmbChatBubbleTarget
        '
        Me.cmbChatBubbleTarget.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbChatBubbleTarget.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbChatBubbleTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChatBubbleTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbChatBubbleTarget.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbChatBubbleTarget.FormattingEnabled = True
        Me.cmbChatBubbleTarget.Location = New System.Drawing.Point(108, 105)
        Me.cmbChatBubbleTarget.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbChatBubbleTarget.Name = "cmbChatBubbleTarget"
        Me.cmbChatBubbleTarget.Size = New System.Drawing.Size(210, 23)
        Me.cmbChatBubbleTarget.TabIndex = 28
        '
        'cmbChatBubbleTargetType
        '
        Me.cmbChatBubbleTargetType.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbChatBubbleTargetType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbChatBubbleTargetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChatBubbleTargetType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbChatBubbleTargetType.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbChatBubbleTargetType.FormattingEnabled = True
        Me.cmbChatBubbleTargetType.Items.AddRange(New Object() {"Player", "Npc", "Event"})
        Me.cmbChatBubbleTargetType.Location = New System.Drawing.Point(108, 71)
        Me.cmbChatBubbleTargetType.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbChatBubbleTargetType.Name = "cmbChatBubbleTargetType"
        Me.cmbChatBubbleTargetType.Size = New System.Drawing.Size(210, 23)
        Me.cmbChatBubbleTargetType.TabIndex = 27
        '
        'DarkLabel40
        '
        Me.DarkLabel40.AutoSize = True
        Me.DarkLabel40.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel40.Location = New System.Drawing.Point(8, 75)
        Me.DarkLabel40.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel40.Name = "DarkLabel40"
        Me.DarkLabel40.Size = New System.Drawing.Size(90, 17)
        Me.DarkLabel40.TabIndex = 2
        Me.DarkLabel40.Text = "Target Type:"
        '
        'txtChatbubbleText
        '
        Me.txtChatbubbleText.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtChatbubbleText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChatbubbleText.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtChatbubbleText.Location = New System.Drawing.Point(8, 39)
        Me.txtChatbubbleText.Margin = New System.Windows.Forms.Padding(4)
        Me.txtChatbubbleText.Name = "txtChatbubbleText"
        Me.txtChatbubbleText.Size = New System.Drawing.Size(311, 22)
        Me.txtChatbubbleText.TabIndex = 1
        '
        'DarkLabel39
        '
        Me.DarkLabel39.AutoSize = True
        Me.DarkLabel39.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel39.Location = New System.Drawing.Point(8, 20)
        Me.DarkLabel39.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel39.Name = "DarkLabel39"
        Me.DarkLabel39.Size = New System.Drawing.Size(112, 17)
        Me.DarkLabel39.TabIndex = 0
        Me.DarkLabel39.Text = "ChatBubble Text"
        '
        'fraPlaySound
        '
        Me.fraPlaySound.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraPlaySound.Controls.Add(Me.btnPlaySoundOk)
        Me.fraPlaySound.Controls.Add(Me.btnPlaySoundCancel)
        Me.fraPlaySound.Controls.Add(Me.cmbPlaySound)
        Me.fraPlaySound.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraPlaySound.Location = New System.Drawing.Point(535, 220)
        Me.fraPlaySound.Margin = New System.Windows.Forms.Padding(4)
        Me.fraPlaySound.Name = "fraPlaySound"
        Me.fraPlaySound.Padding = New System.Windows.Forms.Padding(4)
        Me.fraPlaySound.Size = New System.Drawing.Size(328, 94)
        Me.fraPlaySound.TabIndex = 26
        Me.fraPlaySound.TabStop = False
        Me.fraPlaySound.Text = "Play Sound"
        Me.fraPlaySound.Visible = False
        '
        'btnPlaySoundOk
        '
        Me.btnPlaySoundOk.Location = New System.Drawing.Point(112, 57)
        Me.btnPlaySoundOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPlaySoundOk.Name = "btnPlaySoundOk"
        Me.btnPlaySoundOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnPlaySoundOk.Size = New System.Drawing.Size(100, 28)
        Me.btnPlaySoundOk.TabIndex = 27
        Me.btnPlaySoundOk.Text = "Ok"
        '
        'btnPlaySoundCancel
        '
        Me.btnPlaySoundCancel.Location = New System.Drawing.Point(220, 57)
        Me.btnPlaySoundCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPlaySoundCancel.Name = "btnPlaySoundCancel"
        Me.btnPlaySoundCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnPlaySoundCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnPlaySoundCancel.TabIndex = 26
        Me.btnPlaySoundCancel.Text = "Cancel"
        '
        'cmbPlaySound
        '
        Me.cmbPlaySound.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbPlaySound.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPlaySound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlaySound.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPlaySound.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbPlaySound.FormattingEnabled = True
        Me.cmbPlaySound.Location = New System.Drawing.Point(8, 23)
        Me.cmbPlaySound.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPlaySound.Name = "cmbPlaySound"
        Me.cmbPlaySound.Size = New System.Drawing.Size(311, 23)
        Me.cmbPlaySound.TabIndex = 0
        '
        'fraChangePK
        '
        Me.fraChangePK.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraChangePK.Controls.Add(Me.btnChangePkOk)
        Me.fraChangePK.Controls.Add(Me.btnChangePkCancel)
        Me.fraChangePK.Controls.Add(Me.cmbSetPK)
        Me.fraChangePK.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraChangePK.Location = New System.Drawing.Point(535, 128)
        Me.fraChangePK.Margin = New System.Windows.Forms.Padding(4)
        Me.fraChangePK.Name = "fraChangePK"
        Me.fraChangePK.Padding = New System.Windows.Forms.Padding(4)
        Me.fraChangePK.Size = New System.Drawing.Size(328, 92)
        Me.fraChangePK.TabIndex = 25
        Me.fraChangePK.TabStop = False
        Me.fraChangePK.Text = "Set Player PK"
        Me.fraChangePK.Visible = False
        '
        'btnChangePkOk
        '
        Me.btnChangePkOk.Location = New System.Drawing.Point(107, 57)
        Me.btnChangePkOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnChangePkOk.Name = "btnChangePkOk"
        Me.btnChangePkOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnChangePkOk.Size = New System.Drawing.Size(100, 28)
        Me.btnChangePkOk.TabIndex = 27
        Me.btnChangePkOk.Text = "Ok"
        '
        'btnChangePkCancel
        '
        Me.btnChangePkCancel.Location = New System.Drawing.Point(215, 57)
        Me.btnChangePkCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnChangePkCancel.Name = "btnChangePkCancel"
        Me.btnChangePkCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnChangePkCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnChangePkCancel.TabIndex = 26
        Me.btnChangePkCancel.Text = "Cancel"
        '
        'cmbSetPK
        '
        Me.cmbSetPK.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbSetPK.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSetPK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSetPK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSetPK.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbSetPK.FormattingEnabled = True
        Me.cmbSetPK.Items.AddRange(New Object() {"No", "Yes"})
        Me.cmbSetPK.Location = New System.Drawing.Point(13, 23)
        Me.cmbSetPK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSetPK.Name = "cmbSetPK"
        Me.cmbSetPK.Size = New System.Drawing.Size(300, 23)
        Me.cmbSetPK.TabIndex = 18
        '
        'fraCreateLabel
        '
        Me.fraCreateLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraCreateLabel.Controls.Add(Me.btnCreatelabelOk)
        Me.fraCreateLabel.Controls.Add(Me.btnCreatelabelCancel)
        Me.fraCreateLabel.Controls.Add(Me.txtLabelName)
        Me.fraCreateLabel.Controls.Add(Me.lblLabelName)
        Me.fraCreateLabel.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraCreateLabel.Location = New System.Drawing.Point(535, 162)
        Me.fraCreateLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.fraCreateLabel.Name = "fraCreateLabel"
        Me.fraCreateLabel.Padding = New System.Windows.Forms.Padding(4)
        Me.fraCreateLabel.Size = New System.Drawing.Size(328, 91)
        Me.fraCreateLabel.TabIndex = 24
        Me.fraCreateLabel.TabStop = False
        Me.fraCreateLabel.Text = "Create Label"
        Me.fraCreateLabel.Visible = False
        '
        'btnCreatelabelOk
        '
        Me.btnCreatelabelOk.Location = New System.Drawing.Point(112, 55)
        Me.btnCreatelabelOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCreatelabelOk.Name = "btnCreatelabelOk"
        Me.btnCreatelabelOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnCreatelabelOk.Size = New System.Drawing.Size(100, 28)
        Me.btnCreatelabelOk.TabIndex = 27
        Me.btnCreatelabelOk.Text = "Ok"
        '
        'btnCreatelabelCancel
        '
        Me.btnCreatelabelCancel.Location = New System.Drawing.Point(220, 55)
        Me.btnCreatelabelCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCreatelabelCancel.Name = "btnCreatelabelCancel"
        Me.btnCreatelabelCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnCreatelabelCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnCreatelabelCancel.TabIndex = 26
        Me.btnCreatelabelCancel.Text = "Cancel"
        '
        'txtLabelName
        '
        Me.txtLabelName.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtLabelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLabelName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtLabelName.Location = New System.Drawing.Point(107, 23)
        Me.txtLabelName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLabelName.Name = "txtLabelName"
        Me.txtLabelName.Size = New System.Drawing.Size(213, 22)
        Me.txtLabelName.TabIndex = 1
        '
        'lblLabelName
        '
        Me.lblLabelName.AutoSize = True
        Me.lblLabelName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblLabelName.Location = New System.Drawing.Point(9, 26)
        Me.lblLabelName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLabelName.Name = "lblLabelName"
        Me.lblLabelName.Size = New System.Drawing.Size(88, 17)
        Me.lblLabelName.TabIndex = 0
        Me.lblLabelName.Text = "Label Name:"
        '
        'fraChangeClass
        '
        Me.fraChangeClass.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraChangeClass.Controls.Add(Me.btnChangeClassOk)
        Me.fraChangeClass.Controls.Add(Me.btnChangeClassCancel)
        Me.fraChangeClass.Controls.Add(Me.cmbChangeClass)
        Me.fraChangeClass.Controls.Add(Me.DarkLabel38)
        Me.fraChangeClass.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraChangeClass.Location = New System.Drawing.Point(535, 134)
        Me.fraChangeClass.Margin = New System.Windows.Forms.Padding(4)
        Me.fraChangeClass.Name = "fraChangeClass"
        Me.fraChangeClass.Padding = New System.Windows.Forms.Padding(4)
        Me.fraChangeClass.Size = New System.Drawing.Size(328, 94)
        Me.fraChangeClass.TabIndex = 23
        Me.fraChangeClass.TabStop = False
        Me.fraChangeClass.Text = "Change Player Class"
        Me.fraChangeClass.Visible = False
        '
        'btnChangeClassOk
        '
        Me.btnChangeClassOk.Location = New System.Drawing.Point(112, 57)
        Me.btnChangeClassOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnChangeClassOk.Name = "btnChangeClassOk"
        Me.btnChangeClassOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnChangeClassOk.Size = New System.Drawing.Size(100, 28)
        Me.btnChangeClassOk.TabIndex = 27
        Me.btnChangeClassOk.Text = "Ok"
        '
        'btnChangeClassCancel
        '
        Me.btnChangeClassCancel.Location = New System.Drawing.Point(220, 57)
        Me.btnChangeClassCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnChangeClassCancel.Name = "btnChangeClassCancel"
        Me.btnChangeClassCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnChangeClassCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnChangeClassCancel.TabIndex = 26
        Me.btnChangeClassCancel.Text = "Cancel"
        '
        'cmbChangeClass
        '
        Me.cmbChangeClass.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbChangeClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbChangeClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChangeClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbChangeClass.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbChangeClass.FormattingEnabled = True
        Me.cmbChangeClass.Location = New System.Drawing.Point(66, 23)
        Me.cmbChangeClass.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbChangeClass.Name = "cmbChangeClass"
        Me.cmbChangeClass.Size = New System.Drawing.Size(253, 23)
        Me.cmbChangeClass.TabIndex = 1
        '
        'DarkLabel38
        '
        Me.DarkLabel38.AutoSize = True
        Me.DarkLabel38.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel38.Location = New System.Drawing.Point(11, 27)
        Me.DarkLabel38.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel38.Name = "DarkLabel38"
        Me.DarkLabel38.Size = New System.Drawing.Size(46, 17)
        Me.DarkLabel38.TabIndex = 0
        Me.DarkLabel38.Text = "Class:"
        '
        'fraChangeSkills
        '
        Me.fraChangeSkills.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraChangeSkills.Controls.Add(Me.btnChangeSkillsOk)
        Me.fraChangeSkills.Controls.Add(Me.btnChangeSkillsCancel)
        Me.fraChangeSkills.Controls.Add(Me.optChangeSkillsRemove)
        Me.fraChangeSkills.Controls.Add(Me.optChangeSkillsAdd)
        Me.fraChangeSkills.Controls.Add(Me.cmbChangeSkills)
        Me.fraChangeSkills.Controls.Add(Me.DarkLabel37)
        Me.fraChangeSkills.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraChangeSkills.Location = New System.Drawing.Point(535, 133)
        Me.fraChangeSkills.Margin = New System.Windows.Forms.Padding(4)
        Me.fraChangeSkills.Name = "fraChangeSkills"
        Me.fraChangeSkills.Padding = New System.Windows.Forms.Padding(4)
        Me.fraChangeSkills.Size = New System.Drawing.Size(328, 121)
        Me.fraChangeSkills.TabIndex = 22
        Me.fraChangeSkills.TabStop = False
        Me.fraChangeSkills.Text = "Change Player Skills"
        Me.fraChangeSkills.Visible = False
        '
        'btnChangeSkillsOk
        '
        Me.btnChangeSkillsOk.Location = New System.Drawing.Point(112, 82)
        Me.btnChangeSkillsOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnChangeSkillsOk.Name = "btnChangeSkillsOk"
        Me.btnChangeSkillsOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnChangeSkillsOk.Size = New System.Drawing.Size(100, 28)
        Me.btnChangeSkillsOk.TabIndex = 27
        Me.btnChangeSkillsOk.Text = "Ok"
        '
        'btnChangeSkillsCancel
        '
        Me.btnChangeSkillsCancel.Location = New System.Drawing.Point(220, 82)
        Me.btnChangeSkillsCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnChangeSkillsCancel.Name = "btnChangeSkillsCancel"
        Me.btnChangeSkillsCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnChangeSkillsCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnChangeSkillsCancel.TabIndex = 26
        Me.btnChangeSkillsCancel.Text = "Cancel"
        '
        'optChangeSkillsRemove
        '
        Me.optChangeSkillsRemove.AutoSize = True
        Me.optChangeSkillsRemove.Location = New System.Drawing.Point(196, 54)
        Me.optChangeSkillsRemove.Margin = New System.Windows.Forms.Padding(4)
        Me.optChangeSkillsRemove.Name = "optChangeSkillsRemove"
        Me.optChangeSkillsRemove.Size = New System.Drawing.Size(70, 21)
        Me.optChangeSkillsRemove.TabIndex = 3
        Me.optChangeSkillsRemove.TabStop = True
        Me.optChangeSkillsRemove.Text = "Forget"
        '
        'optChangeSkillsAdd
        '
        Me.optChangeSkillsAdd.AutoSize = True
        Me.optChangeSkillsAdd.Location = New System.Drawing.Point(87, 54)
        Me.optChangeSkillsAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.optChangeSkillsAdd.Name = "optChangeSkillsAdd"
        Me.optChangeSkillsAdd.Size = New System.Drawing.Size(69, 21)
        Me.optChangeSkillsAdd.TabIndex = 2
        Me.optChangeSkillsAdd.TabStop = True
        Me.optChangeSkillsAdd.Text = "Teach"
        '
        'cmbChangeSkills
        '
        Me.cmbChangeSkills.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbChangeSkills.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbChangeSkills.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChangeSkills.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbChangeSkills.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbChangeSkills.FormattingEnabled = True
        Me.cmbChangeSkills.Location = New System.Drawing.Point(55, 21)
        Me.cmbChangeSkills.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbChangeSkills.Name = "cmbChangeSkills"
        Me.cmbChangeSkills.Size = New System.Drawing.Size(263, 23)
        Me.cmbChangeSkills.TabIndex = 1
        '
        'DarkLabel37
        '
        Me.DarkLabel37.AutoSize = True
        Me.DarkLabel37.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel37.Location = New System.Drawing.Point(8, 25)
        Me.DarkLabel37.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel37.Name = "DarkLabel37"
        Me.DarkLabel37.Size = New System.Drawing.Size(37, 17)
        Me.DarkLabel37.TabIndex = 0
        Me.DarkLabel37.Text = "Skill:"
        '
        'fraCompleteTask
        '
        Me.fraCompleteTask.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraCompleteTask.Controls.Add(Me.btnCompleteQuestTaskOk)
        Me.fraCompleteTask.Controls.Add(Me.btnCompleteQuestTaskCancel)
        Me.fraCompleteTask.Controls.Add(Me.DarkLabel35)
        Me.fraCompleteTask.Controls.Add(Me.DarkLabel36)
        Me.fraCompleteTask.Controls.Add(Me.nudCompleteQuestTask)
        Me.fraCompleteTask.Controls.Add(Me.cmbCompleteQuest)
        Me.fraCompleteTask.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraCompleteTask.Location = New System.Drawing.Point(535, 4)
        Me.fraCompleteTask.Margin = New System.Windows.Forms.Padding(4)
        Me.fraCompleteTask.Name = "fraCompleteTask"
        Me.fraCompleteTask.Padding = New System.Windows.Forms.Padding(4)
        Me.fraCompleteTask.Size = New System.Drawing.Size(328, 123)
        Me.fraCompleteTask.TabIndex = 20
        Me.fraCompleteTask.TabStop = False
        Me.fraCompleteTask.Text = "Complete Quest Task"
        Me.fraCompleteTask.Visible = False
        '
        'btnCompleteQuestTaskOk
        '
        Me.btnCompleteQuestTaskOk.Location = New System.Drawing.Point(112, 91)
        Me.btnCompleteQuestTaskOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCompleteQuestTaskOk.Name = "btnCompleteQuestTaskOk"
        Me.btnCompleteQuestTaskOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnCompleteQuestTaskOk.Size = New System.Drawing.Size(100, 28)
        Me.btnCompleteQuestTaskOk.TabIndex = 27
        Me.btnCompleteQuestTaskOk.Text = "Ok"
        '
        'btnCompleteQuestTaskCancel
        '
        Me.btnCompleteQuestTaskCancel.Location = New System.Drawing.Point(220, 91)
        Me.btnCompleteQuestTaskCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCompleteQuestTaskCancel.Name = "btnCompleteQuestTaskCancel"
        Me.btnCompleteQuestTaskCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnCompleteQuestTaskCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnCompleteQuestTaskCancel.TabIndex = 26
        Me.btnCompleteQuestTaskCancel.Text = "Cancel"
        '
        'DarkLabel35
        '
        Me.DarkLabel35.AutoSize = True
        Me.DarkLabel35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel35.Location = New System.Drawing.Point(13, 62)
        Me.DarkLabel35.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel35.Name = "DarkLabel35"
        Me.DarkLabel35.Size = New System.Drawing.Size(43, 17)
        Me.DarkLabel35.TabIndex = 23
        Me.DarkLabel35.Text = "Task:"
        '
        'DarkLabel36
        '
        Me.DarkLabel36.AutoSize = True
        Me.DarkLabel36.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel36.Location = New System.Drawing.Point(13, 27)
        Me.DarkLabel36.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel36.Name = "DarkLabel36"
        Me.DarkLabel36.Size = New System.Drawing.Size(50, 17)
        Me.DarkLabel36.TabIndex = 22
        Me.DarkLabel36.Text = "Quest:"
        '
        'nudCompleteQuestTask
        '
        Me.nudCompleteQuestTask.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudCompleteQuestTask.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudCompleteQuestTask.Location = New System.Drawing.Point(80, 59)
        Me.nudCompleteQuestTask.Margin = New System.Windows.Forms.Padding(4)
        Me.nudCompleteQuestTask.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudCompleteQuestTask.Name = "nudCompleteQuestTask"
        Me.nudCompleteQuestTask.Size = New System.Drawing.Size(238, 22)
        Me.nudCompleteQuestTask.TabIndex = 21
        '
        'cmbCompleteQuest
        '
        Me.cmbCompleteQuest.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbCompleteQuest.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCompleteQuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCompleteQuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCompleteQuest.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbCompleteQuest.FormattingEnabled = True
        Me.cmbCompleteQuest.Location = New System.Drawing.Point(80, 23)
        Me.cmbCompleteQuest.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCompleteQuest.Name = "cmbCompleteQuest"
        Me.cmbCompleteQuest.Size = New System.Drawing.Size(237, 23)
        Me.cmbCompleteQuest.TabIndex = 20
        '
        'fraPlayerWarp
        '
        Me.fraPlayerWarp.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraPlayerWarp.Controls.Add(Me.btnPlayerWarpOk)
        Me.fraPlayerWarp.Controls.Add(Me.btnPlayerWarpCancel)
        Me.fraPlayerWarp.Controls.Add(Me.DarkLabel31)
        Me.fraPlayerWarp.Controls.Add(Me.cmbWarpPlayerDir)
        Me.fraPlayerWarp.Controls.Add(Me.nudWPY)
        Me.fraPlayerWarp.Controls.Add(Me.DarkLabel32)
        Me.fraPlayerWarp.Controls.Add(Me.nudWPX)
        Me.fraPlayerWarp.Controls.Add(Me.DarkLabel33)
        Me.fraPlayerWarp.Controls.Add(Me.nudWPMap)
        Me.fraPlayerWarp.Controls.Add(Me.DarkLabel34)
        Me.fraPlayerWarp.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraPlayerWarp.Location = New System.Drawing.Point(535, 7)
        Me.fraPlayerWarp.Margin = New System.Windows.Forms.Padding(4)
        Me.fraPlayerWarp.Name = "fraPlayerWarp"
        Me.fraPlayerWarp.Padding = New System.Windows.Forms.Padding(4)
        Me.fraPlayerWarp.Size = New System.Drawing.Size(328, 119)
        Me.fraPlayerWarp.TabIndex = 19
        Me.fraPlayerWarp.TabStop = False
        Me.fraPlayerWarp.Text = "Warp Player"
        Me.fraPlayerWarp.Visible = False
        '
        'btnPlayerWarpOk
        '
        Me.btnPlayerWarpOk.Location = New System.Drawing.Point(110, 84)
        Me.btnPlayerWarpOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPlayerWarpOk.Name = "btnPlayerWarpOk"
        Me.btnPlayerWarpOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnPlayerWarpOk.Size = New System.Drawing.Size(100, 28)
        Me.btnPlayerWarpOk.TabIndex = 46
        Me.btnPlayerWarpOk.Text = "Ok"
        '
        'btnPlayerWarpCancel
        '
        Me.btnPlayerWarpCancel.Location = New System.Drawing.Point(219, 84)
        Me.btnPlayerWarpCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPlayerWarpCancel.Name = "btnPlayerWarpCancel"
        Me.btnPlayerWarpCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnPlayerWarpCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnPlayerWarpCancel.TabIndex = 45
        Me.btnPlayerWarpCancel.Text = "Cancel"
        '
        'DarkLabel31
        '
        Me.DarkLabel31.AutoSize = True
        Me.DarkLabel31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel31.Location = New System.Drawing.Point(11, 54)
        Me.DarkLabel31.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel31.Name = "DarkLabel31"
        Me.DarkLabel31.Size = New System.Drawing.Size(68, 17)
        Me.DarkLabel31.TabIndex = 44
        Me.DarkLabel31.Text = "Direction:"
        '
        'cmbWarpPlayerDir
        '
        Me.cmbWarpPlayerDir.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbWarpPlayerDir.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbWarpPlayerDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWarpPlayerDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbWarpPlayerDir.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbWarpPlayerDir.FormattingEnabled = True
        Me.cmbWarpPlayerDir.Items.AddRange(New Object() {"Retain Direction", "Up", "Down", "Left", "Right"})
        Me.cmbWarpPlayerDir.Location = New System.Drawing.Point(128, 50)
        Me.cmbWarpPlayerDir.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbWarpPlayerDir.Name = "cmbWarpPlayerDir"
        Me.cmbWarpPlayerDir.Size = New System.Drawing.Size(189, 23)
        Me.cmbWarpPlayerDir.TabIndex = 43
        '
        'nudWPY
        '
        Me.nudWPY.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudWPY.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudWPY.Location = New System.Drawing.Point(267, 18)
        Me.nudWPY.Margin = New System.Windows.Forms.Padding(4)
        Me.nudWPY.Name = "nudWPY"
        Me.nudWPY.Size = New System.Drawing.Size(52, 22)
        Me.nudWPY.TabIndex = 42
        '
        'DarkLabel32
        '
        Me.DarkLabel32.AutoSize = True
        Me.DarkLabel32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel32.Location = New System.Drawing.Point(236, 21)
        Me.DarkLabel32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel32.Name = "DarkLabel32"
        Me.DarkLabel32.Size = New System.Drawing.Size(21, 17)
        Me.DarkLabel32.TabIndex = 41
        Me.DarkLabel32.Text = "Y:"
        '
        'nudWPX
        '
        Me.nudWPX.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudWPX.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudWPX.Location = New System.Drawing.Point(173, 18)
        Me.nudWPX.Margin = New System.Windows.Forms.Padding(4)
        Me.nudWPX.Name = "nudWPX"
        Me.nudWPX.Size = New System.Drawing.Size(52, 22)
        Me.nudWPX.TabIndex = 40
        '
        'DarkLabel33
        '
        Me.DarkLabel33.AutoSize = True
        Me.DarkLabel33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel33.Location = New System.Drawing.Point(142, 21)
        Me.DarkLabel33.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel33.Name = "DarkLabel33"
        Me.DarkLabel33.Size = New System.Drawing.Size(21, 17)
        Me.DarkLabel33.TabIndex = 39
        Me.DarkLabel33.Text = "X:"
        '
        'nudWPMap
        '
        Me.nudWPMap.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudWPMap.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudWPMap.Location = New System.Drawing.Point(57, 18)
        Me.nudWPMap.Margin = New System.Windows.Forms.Padding(4)
        Me.nudWPMap.Name = "nudWPMap"
        Me.nudWPMap.Size = New System.Drawing.Size(77, 22)
        Me.nudWPMap.TabIndex = 38
        '
        'DarkLabel34
        '
        Me.DarkLabel34.AutoSize = True
        Me.DarkLabel34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel34.Location = New System.Drawing.Point(8, 21)
        Me.DarkLabel34.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel34.Name = "DarkLabel34"
        Me.DarkLabel34.Size = New System.Drawing.Size(39, 17)
        Me.DarkLabel34.TabIndex = 37
        Me.DarkLabel34.Text = "Map:"
        '
        'fraSetFog
        '
        Me.fraSetFog.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraSetFog.Controls.Add(Me.btnSetFogOk)
        Me.fraSetFog.Controls.Add(Me.btnSetFogCancel)
        Me.fraSetFog.Controls.Add(Me.DarkLabel30)
        Me.fraSetFog.Controls.Add(Me.DarkLabel29)
        Me.fraSetFog.Controls.Add(Me.DarkLabel28)
        Me.fraSetFog.Controls.Add(Me.nudFogData2)
        Me.fraSetFog.Controls.Add(Me.nudFogData1)
        Me.fraSetFog.Controls.Add(Me.nudFogData0)
        Me.fraSetFog.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraSetFog.Location = New System.Drawing.Point(535, 9)
        Me.fraSetFog.Margin = New System.Windows.Forms.Padding(4)
        Me.fraSetFog.Name = "fraSetFog"
        Me.fraSetFog.Padding = New System.Windows.Forms.Padding(4)
        Me.fraSetFog.Size = New System.Drawing.Size(328, 118)
        Me.fraSetFog.TabIndex = 18
        Me.fraSetFog.TabStop = False
        Me.fraSetFog.Text = "Set Fog"
        Me.fraSetFog.Visible = False
        '
        'btnSetFogOk
        '
        Me.btnSetFogOk.Location = New System.Drawing.Point(112, 82)
        Me.btnSetFogOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSetFogOk.Name = "btnSetFogOk"
        Me.btnSetFogOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnSetFogOk.Size = New System.Drawing.Size(100, 28)
        Me.btnSetFogOk.TabIndex = 41
        Me.btnSetFogOk.Text = "Ok"
        '
        'btnSetFogCancel
        '
        Me.btnSetFogCancel.Location = New System.Drawing.Point(220, 82)
        Me.btnSetFogCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSetFogCancel.Name = "btnSetFogCancel"
        Me.btnSetFogCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnSetFogCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnSetFogCancel.TabIndex = 40
        Me.btnSetFogCancel.Text = "Cancel"
        '
        'DarkLabel30
        '
        Me.DarkLabel30.AutoSize = True
        Me.DarkLabel30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel30.Location = New System.Drawing.Point(165, 52)
        Me.DarkLabel30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel30.Name = "DarkLabel30"
        Me.DarkLabel30.Size = New System.Drawing.Size(88, 17)
        Me.DarkLabel30.TabIndex = 39
        Me.DarkLabel30.Text = "Fog Opacity:"
        '
        'DarkLabel29
        '
        Me.DarkLabel29.AutoSize = True
        Me.DarkLabel29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel29.Location = New System.Drawing.Point(9, 52)
        Me.DarkLabel29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel29.Name = "DarkLabel29"
        Me.DarkLabel29.Size = New System.Drawing.Size(81, 17)
        Me.DarkLabel29.TabIndex = 38
        Me.DarkLabel29.Text = "Fog Speed:"
        '
        'DarkLabel28
        '
        Me.DarkLabel28.AutoSize = True
        Me.DarkLabel28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel28.Location = New System.Drawing.Point(9, 18)
        Me.DarkLabel28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel28.Name = "DarkLabel28"
        Me.DarkLabel28.Size = New System.Drawing.Size(36, 17)
        Me.DarkLabel28.TabIndex = 37
        Me.DarkLabel28.Text = "Fog:"
        '
        'nudFogData2
        '
        Me.nudFogData2.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudFogData2.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudFogData2.Location = New System.Drawing.Point(254, 48)
        Me.nudFogData2.Margin = New System.Windows.Forms.Padding(4)
        Me.nudFogData2.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudFogData2.Name = "nudFogData2"
        Me.nudFogData2.Size = New System.Drawing.Size(66, 22)
        Me.nudFogData2.TabIndex = 36
        '
        'nudFogData1
        '
        Me.nudFogData1.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudFogData1.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudFogData1.Location = New System.Drawing.Point(96, 50)
        Me.nudFogData1.Margin = New System.Windows.Forms.Padding(4)
        Me.nudFogData1.Name = "nudFogData1"
        Me.nudFogData1.Size = New System.Drawing.Size(64, 22)
        Me.nudFogData1.TabIndex = 35
        '
        'nudFogData0
        '
        Me.nudFogData0.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudFogData0.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudFogData0.Location = New System.Drawing.Point(130, 14)
        Me.nudFogData0.Margin = New System.Windows.Forms.Padding(4)
        Me.nudFogData0.Name = "nudFogData0"
        Me.nudFogData0.Size = New System.Drawing.Size(190, 22)
        Me.nudFogData0.TabIndex = 34
        '
        'fraShowText
        '
        Me.fraShowText.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraShowText.Controls.Add(Me.DarkLabel27)
        Me.fraShowText.Controls.Add(Me.txtShowText)
        Me.fraShowText.Controls.Add(Me.btnShowTextCancel)
        Me.fraShowText.Controls.Add(Me.btnShowTextOk)
        Me.fraShowText.Controls.Add(Me.picShowTextFace)
        Me.fraShowText.Controls.Add(Me.DarkLabel26)
        Me.fraShowText.Controls.Add(Me.nudShowTextFace)
        Me.fraShowText.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraShowText.Location = New System.Drawing.Point(8, 374)
        Me.fraShowText.Margin = New System.Windows.Forms.Padding(4)
        Me.fraShowText.Name = "fraShowText"
        Me.fraShowText.Padding = New System.Windows.Forms.Padding(4)
        Me.fraShowText.Size = New System.Drawing.Size(331, 350)
        Me.fraShowText.TabIndex = 17
        Me.fraShowText.TabStop = False
        Me.fraShowText.Text = "Show Text"
        Me.fraShowText.Visible = False
        '
        'DarkLabel27
        '
        Me.DarkLabel27.AutoSize = True
        Me.DarkLabel27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel27.Location = New System.Drawing.Point(9, 23)
        Me.DarkLabel27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel27.Name = "DarkLabel27"
        Me.DarkLabel27.Size = New System.Drawing.Size(35, 17)
        Me.DarkLabel27.TabIndex = 26
        Me.DarkLabel27.Text = "Text"
        '
        'txtShowText
        '
        Me.txtShowText.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtShowText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShowText.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtShowText.Location = New System.Drawing.Point(12, 46)
        Me.txtShowText.Margin = New System.Windows.Forms.Padding(4)
        Me.txtShowText.Multiline = True
        Me.txtShowText.Name = "txtShowText"
        Me.txtShowText.Size = New System.Drawing.Size(303, 128)
        Me.txtShowText.TabIndex = 21
        '
        'btnShowTextCancel
        '
        Me.btnShowTextCancel.Location = New System.Drawing.Point(222, 300)
        Me.btnShowTextCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnShowTextCancel.Name = "btnShowTextCancel"
        Me.btnShowTextCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnShowTextCancel.Size = New System.Drawing.Size(100, 38)
        Me.btnShowTextCancel.TabIndex = 24
        Me.btnShowTextCancel.Text = "Cancelar"
        '
        'btnShowTextOk
        '
        Me.btnShowTextOk.Location = New System.Drawing.Point(115, 300)
        Me.btnShowTextOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnShowTextOk.Name = "btnShowTextOk"
        Me.btnShowTextOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnShowTextOk.Size = New System.Drawing.Size(100, 38)
        Me.btnShowTextOk.TabIndex = 25
        Me.btnShowTextOk.Text = "Confirmar"
        '
        'picShowTextFace
        '
        Me.picShowTextFace.BackColor = System.Drawing.Color.Black
        Me.picShowTextFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picShowTextFace.Location = New System.Drawing.Point(9, 183)
        Me.picShowTextFace.Margin = New System.Windows.Forms.Padding(4)
        Me.picShowTextFace.Name = "picShowTextFace"
        Me.picShowTextFace.Size = New System.Drawing.Size(133, 114)
        Me.picShowTextFace.TabIndex = 2
        Me.picShowTextFace.TabStop = False
        '
        'DarkLabel26
        '
        Me.DarkLabel26.AutoSize = True
        Me.DarkLabel26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel26.Location = New System.Drawing.Point(147, 276)
        Me.DarkLabel26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel26.Name = "DarkLabel26"
        Me.DarkLabel26.Size = New System.Drawing.Size(49, 17)
        Me.DarkLabel26.TabIndex = 22
        Me.DarkLabel26.Text = "Rosto:"
        '
        'nudShowTextFace
        '
        Me.nudShowTextFace.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudShowTextFace.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudShowTextFace.Location = New System.Drawing.Point(196, 274)
        Me.nudShowTextFace.Margin = New System.Windows.Forms.Padding(4)
        Me.nudShowTextFace.Name = "nudShowTextFace"
        Me.nudShowTextFace.Size = New System.Drawing.Size(123, 22)
        Me.nudShowTextFace.TabIndex = 23
        '
        'fraAddText
        '
        Me.fraAddText.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraAddText.Controls.Add(Me.btnAddTextOk)
        Me.fraAddText.Controls.Add(Me.btnAddTextCancel)
        Me.fraAddText.Controls.Add(Me.optAddText_Global)
        Me.fraAddText.Controls.Add(Me.optAddText_Map)
        Me.fraAddText.Controls.Add(Me.optAddText_Player)
        Me.fraAddText.Controls.Add(Me.DarkLabel25)
        Me.fraAddText.Controls.Add(Me.txtAddText_Text)
        Me.fraAddText.Controls.Add(Me.DarkLabel24)
        Me.fraAddText.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraAddText.Location = New System.Drawing.Point(8, 446)
        Me.fraAddText.Margin = New System.Windows.Forms.Padding(4)
        Me.fraAddText.Name = "fraAddText"
        Me.fraAddText.Padding = New System.Windows.Forms.Padding(4)
        Me.fraAddText.Size = New System.Drawing.Size(311, 230)
        Me.fraAddText.TabIndex = 3
        Me.fraAddText.TabStop = False
        Me.fraAddText.Text = "Add Text"
        Me.fraAddText.Visible = False
        '
        'btnAddTextOk
        '
        Me.btnAddTextOk.Location = New System.Drawing.Point(73, 192)
        Me.btnAddTextOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddTextOk.Name = "btnAddTextOk"
        Me.btnAddTextOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnAddTextOk.Size = New System.Drawing.Size(100, 28)
        Me.btnAddTextOk.TabIndex = 9
        Me.btnAddTextOk.Text = "Ok"
        '
        'btnAddTextCancel
        '
        Me.btnAddTextCancel.Location = New System.Drawing.Point(181, 192)
        Me.btnAddTextCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddTextCancel.Name = "btnAddTextCancel"
        Me.btnAddTextCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnAddTextCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnAddTextCancel.TabIndex = 8
        Me.btnAddTextCancel.Text = "Cancel"
        '
        'optAddText_Global
        '
        Me.optAddText_Global.AutoSize = True
        Me.optAddText_Global.Location = New System.Drawing.Point(231, 164)
        Me.optAddText_Global.Margin = New System.Windows.Forms.Padding(4)
        Me.optAddText_Global.Name = "optAddText_Global"
        Me.optAddText_Global.Size = New System.Drawing.Size(70, 21)
        Me.optAddText_Global.TabIndex = 5
        Me.optAddText_Global.TabStop = True
        Me.optAddText_Global.Text = "Global"
        '
        'optAddText_Map
        '
        Me.optAddText_Map.AutoSize = True
        Me.optAddText_Map.Location = New System.Drawing.Point(162, 164)
        Me.optAddText_Map.Margin = New System.Windows.Forms.Padding(4)
        Me.optAddText_Map.Name = "optAddText_Map"
        Me.optAddText_Map.Size = New System.Drawing.Size(56, 21)
        Me.optAddText_Map.TabIndex = 4
        Me.optAddText_Map.TabStop = True
        Me.optAddText_Map.Text = "Map"
        '
        'optAddText_Player
        '
        Me.optAddText_Player.AutoSize = True
        Me.optAddText_Player.Location = New System.Drawing.Point(82, 164)
        Me.optAddText_Player.Margin = New System.Windows.Forms.Padding(4)
        Me.optAddText_Player.Name = "optAddText_Player"
        Me.optAddText_Player.Size = New System.Drawing.Size(69, 21)
        Me.optAddText_Player.TabIndex = 3
        Me.optAddText_Player.TabStop = True
        Me.optAddText_Player.Text = "Player"
        '
        'DarkLabel25
        '
        Me.DarkLabel25.AutoSize = True
        Me.DarkLabel25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel25.Location = New System.Drawing.Point(8, 166)
        Me.DarkLabel25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel25.Name = "DarkLabel25"
        Me.DarkLabel25.Size = New System.Drawing.Size(64, 17)
        Me.DarkLabel25.TabIndex = 2
        Me.DarkLabel25.Text = "Channel:"
        '
        'txtAddText_Text
        '
        Me.txtAddText_Text.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtAddText_Text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddText_Text.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtAddText_Text.Location = New System.Drawing.Point(8, 38)
        Me.txtAddText_Text.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAddText_Text.Multiline = True
        Me.txtAddText_Text.Name = "txtAddText_Text"
        Me.txtAddText_Text.Size = New System.Drawing.Size(295, 118)
        Me.txtAddText_Text.TabIndex = 1
        '
        'DarkLabel24
        '
        Me.DarkLabel24.AutoSize = True
        Me.DarkLabel24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel24.Location = New System.Drawing.Point(8, 18)
        Me.DarkLabel24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel24.Name = "DarkLabel24"
        Me.DarkLabel24.Size = New System.Drawing.Size(35, 17)
        Me.DarkLabel24.TabIndex = 0
        Me.DarkLabel24.Text = "Text"
        '
        'fraPlayerSwitch
        '
        Me.fraPlayerSwitch.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraPlayerSwitch.Controls.Add(Me.btnSetPlayerSwitchOk)
        Me.fraPlayerSwitch.Controls.Add(Me.btnSetPlayerswitchCancel)
        Me.fraPlayerSwitch.Controls.Add(Me.cmbPlayerSwitchSet)
        Me.fraPlayerSwitch.Controls.Add(Me.DarkLabel23)
        Me.fraPlayerSwitch.Controls.Add(Me.cmbSwitch)
        Me.fraPlayerSwitch.Controls.Add(Me.DarkLabel22)
        Me.fraPlayerSwitch.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraPlayerSwitch.Location = New System.Drawing.Point(284, 480)
        Me.fraPlayerSwitch.Margin = New System.Windows.Forms.Padding(4)
        Me.fraPlayerSwitch.Name = "fraPlayerSwitch"
        Me.fraPlayerSwitch.Padding = New System.Windows.Forms.Padding(4)
        Me.fraPlayerSwitch.Size = New System.Drawing.Size(243, 123)
        Me.fraPlayerSwitch.TabIndex = 2
        Me.fraPlayerSwitch.TabStop = False
        Me.fraPlayerSwitch.Text = "Change Items"
        Me.fraPlayerSwitch.Visible = False
        '
        'btnSetPlayerSwitchOk
        '
        Me.btnSetPlayerSwitchOk.Location = New System.Drawing.Point(27, 78)
        Me.btnSetPlayerSwitchOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSetPlayerSwitchOk.Name = "btnSetPlayerSwitchOk"
        Me.btnSetPlayerSwitchOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnSetPlayerSwitchOk.Size = New System.Drawing.Size(100, 39)
        Me.btnSetPlayerSwitchOk.TabIndex = 9
        Me.btnSetPlayerSwitchOk.Text = "Confirmar"
        '
        'btnSetPlayerswitchCancel
        '
        Me.btnSetPlayerswitchCancel.Location = New System.Drawing.Point(135, 78)
        Me.btnSetPlayerswitchCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSetPlayerswitchCancel.Name = "btnSetPlayerswitchCancel"
        Me.btnSetPlayerswitchCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnSetPlayerswitchCancel.Size = New System.Drawing.Size(100, 39)
        Me.btnSetPlayerswitchCancel.TabIndex = 8
        Me.btnSetPlayerswitchCancel.Text = "Cancelar"
        '
        'cmbPlayerSwitchSet
        '
        Me.cmbPlayerSwitchSet.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbPlayerSwitchSet.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPlayerSwitchSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlayerSwitchSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPlayerSwitchSet.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbPlayerSwitchSet.FormattingEnabled = True
        Me.cmbPlayerSwitchSet.Items.AddRange(New Object() {"False", "True"})
        Me.cmbPlayerSwitchSet.Location = New System.Drawing.Point(68, 50)
        Me.cmbPlayerSwitchSet.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPlayerSwitchSet.Name = "cmbPlayerSwitchSet"
        Me.cmbPlayerSwitchSet.Size = New System.Drawing.Size(166, 23)
        Me.cmbPlayerSwitchSet.TabIndex = 3
        '
        'DarkLabel23
        '
        Me.DarkLabel23.AutoSize = True
        Me.DarkLabel23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel23.Location = New System.Drawing.Point(8, 57)
        Me.DarkLabel23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel23.Name = "DarkLabel23"
        Me.DarkLabel23.Size = New System.Drawing.Size(45, 17)
        Me.DarkLabel23.TabIndex = 2
        Me.DarkLabel23.Text = "Set to"
        '
        'cmbSwitch
        '
        Me.cmbSwitch.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbSwitch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSwitch.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbSwitch.FormattingEnabled = True
        Me.cmbSwitch.Location = New System.Drawing.Point(68, 16)
        Me.cmbSwitch.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSwitch.Name = "cmbSwitch"
        Me.cmbSwitch.Size = New System.Drawing.Size(166, 23)
        Me.cmbSwitch.TabIndex = 1
        '
        'DarkLabel22
        '
        Me.DarkLabel22.AutoSize = True
        Me.DarkLabel22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel22.Location = New System.Drawing.Point(8, 20)
        Me.DarkLabel22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel22.Name = "DarkLabel22"
        Me.DarkLabel22.Size = New System.Drawing.Size(48, 17)
        Me.DarkLabel22.TabIndex = 0
        Me.DarkLabel22.Text = "Switch"
        '
        'fraChangeItems
        '
        Me.fraChangeItems.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraChangeItems.Controls.Add(Me.btnChangeItemsOk)
        Me.fraChangeItems.Controls.Add(Me.btnChangeItemsCancel)
        Me.fraChangeItems.Controls.Add(Me.nudChangeItemsAmount)
        Me.fraChangeItems.Controls.Add(Me.optChangeItemRemove)
        Me.fraChangeItems.Controls.Add(Me.optChangeItemAdd)
        Me.fraChangeItems.Controls.Add(Me.optChangeItemSet)
        Me.fraChangeItems.Controls.Add(Me.cmbChangeItemIndex)
        Me.fraChangeItems.Controls.Add(Me.DarkLabel21)
        Me.fraChangeItems.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraChangeItems.Location = New System.Drawing.Point(8, 480)
        Me.fraChangeItems.Margin = New System.Windows.Forms.Padding(4)
        Me.fraChangeItems.Name = "fraChangeItems"
        Me.fraChangeItems.Padding = New System.Windows.Forms.Padding(4)
        Me.fraChangeItems.Size = New System.Drawing.Size(249, 148)
        Me.fraChangeItems.TabIndex = 1
        Me.fraChangeItems.TabStop = False
        Me.fraChangeItems.Text = "Change Items"
        Me.fraChangeItems.Visible = False
        '
        'btnChangeItemsOk
        '
        Me.btnChangeItemsOk.Location = New System.Drawing.Point(34, 112)
        Me.btnChangeItemsOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnChangeItemsOk.Name = "btnChangeItemsOk"
        Me.btnChangeItemsOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnChangeItemsOk.Size = New System.Drawing.Size(100, 28)
        Me.btnChangeItemsOk.TabIndex = 7
        Me.btnChangeItemsOk.Text = "Ok"
        '
        'btnChangeItemsCancel
        '
        Me.btnChangeItemsCancel.Location = New System.Drawing.Point(141, 112)
        Me.btnChangeItemsCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnChangeItemsCancel.Name = "btnChangeItemsCancel"
        Me.btnChangeItemsCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnChangeItemsCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnChangeItemsCancel.TabIndex = 6
        Me.btnChangeItemsCancel.Text = "Cancel"
        '
        'nudChangeItemsAmount
        '
        Me.nudChangeItemsAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudChangeItemsAmount.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudChangeItemsAmount.Location = New System.Drawing.Point(12, 80)
        Me.nudChangeItemsAmount.Margin = New System.Windows.Forms.Padding(4)
        Me.nudChangeItemsAmount.Name = "nudChangeItemsAmount"
        Me.nudChangeItemsAmount.Size = New System.Drawing.Size(229, 22)
        Me.nudChangeItemsAmount.TabIndex = 5
        '
        'optChangeItemRemove
        '
        Me.optChangeItemRemove.AutoSize = True
        Me.optChangeItemRemove.Location = New System.Drawing.Point(162, 52)
        Me.optChangeItemRemove.Margin = New System.Windows.Forms.Padding(4)
        Me.optChangeItemRemove.Name = "optChangeItemRemove"
        Me.optChangeItemRemove.Size = New System.Drawing.Size(61, 21)
        Me.optChangeItemRemove.TabIndex = 4
        Me.optChangeItemRemove.TabStop = True
        Me.optChangeItemRemove.Text = "Take"
        '
        'optChangeItemAdd
        '
        Me.optChangeItemAdd.AutoSize = True
        Me.optChangeItemAdd.Location = New System.Drawing.Point(91, 52)
        Me.optChangeItemAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.optChangeItemAdd.Name = "optChangeItemAdd"
        Me.optChangeItemAdd.Size = New System.Drawing.Size(58, 21)
        Me.optChangeItemAdd.TabIndex = 3
        Me.optChangeItemAdd.TabStop = True
        Me.optChangeItemAdd.Text = "Give"
        '
        'optChangeItemSet
        '
        Me.optChangeItemSet.AutoSize = True
        Me.optChangeItemSet.Location = New System.Drawing.Point(12, 52)
        Me.optChangeItemSet.Margin = New System.Windows.Forms.Padding(4)
        Me.optChangeItemSet.Name = "optChangeItemSet"
        Me.optChangeItemSet.Size = New System.Drawing.Size(66, 21)
        Me.optChangeItemSet.TabIndex = 2
        Me.optChangeItemSet.TabStop = True
        Me.optChangeItemSet.Text = "Set to"
        '
        'cmbChangeItemIndex
        '
        Me.cmbChangeItemIndex.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbChangeItemIndex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbChangeItemIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChangeItemIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbChangeItemIndex.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbChangeItemIndex.FormattingEnabled = True
        Me.cmbChangeItemIndex.Location = New System.Drawing.Point(56, 16)
        Me.cmbChangeItemIndex.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbChangeItemIndex.Name = "cmbChangeItemIndex"
        Me.cmbChangeItemIndex.Size = New System.Drawing.Size(184, 23)
        Me.cmbChangeItemIndex.TabIndex = 1
        '
        'DarkLabel21
        '
        Me.DarkLabel21.AutoSize = True
        Me.DarkLabel21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel21.Location = New System.Drawing.Point(8, 20)
        Me.DarkLabel21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel21.Name = "DarkLabel21"
        Me.DarkLabel21.Size = New System.Drawing.Size(38, 17)
        Me.DarkLabel21.TabIndex = 0
        Me.DarkLabel21.Text = "Item:"
        '
        'fraPlayBGM
        '
        Me.fraPlayBGM.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraPlayBGM.Controls.Add(Me.btnPlayBgmOk)
        Me.fraPlayBGM.Controls.Add(Me.btnPlayBgmCancel)
        Me.fraPlayBGM.Controls.Add(Me.cmbPlayBGM)
        Me.fraPlayBGM.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraPlayBGM.Location = New System.Drawing.Point(535, 2)
        Me.fraPlayBGM.Margin = New System.Windows.Forms.Padding(4)
        Me.fraPlayBGM.Name = "fraPlayBGM"
        Me.fraPlayBGM.Padding = New System.Windows.Forms.Padding(4)
        Me.fraPlayBGM.Size = New System.Drawing.Size(328, 92)
        Me.fraPlayBGM.TabIndex = 21
        Me.fraPlayBGM.TabStop = False
        Me.fraPlayBGM.Text = "Play BGM"
        Me.fraPlayBGM.Visible = False
        '
        'btnPlayBgmOk
        '
        Me.btnPlayBgmOk.Location = New System.Drawing.Point(61, 57)
        Me.btnPlayBgmOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPlayBgmOk.Name = "btnPlayBgmOk"
        Me.btnPlayBgmOk.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnPlayBgmOk.Size = New System.Drawing.Size(100, 28)
        Me.btnPlayBgmOk.TabIndex = 27
        Me.btnPlayBgmOk.Text = "Ok"
        '
        'btnPlayBgmCancel
        '
        Me.btnPlayBgmCancel.Location = New System.Drawing.Point(169, 57)
        Me.btnPlayBgmCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPlayBgmCancel.Name = "btnPlayBgmCancel"
        Me.btnPlayBgmCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnPlayBgmCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnPlayBgmCancel.TabIndex = 26
        Me.btnPlayBgmCancel.Text = "Cancel"
        '
        'cmbPlayBGM
        '
        Me.cmbPlayBGM.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbPlayBGM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPlayBGM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlayBGM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPlayBGM.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbPlayBGM.FormattingEnabled = True
        Me.cmbPlayBGM.Location = New System.Drawing.Point(8, 23)
        Me.cmbPlayBGM.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPlayBGM.Name = "cmbPlayBGM"
        Me.cmbPlayBGM.Size = New System.Drawing.Size(310, 23)
        Me.cmbPlayBGM.TabIndex = 0
        '
        'pnlVariableSwitches
        '
        Me.pnlVariableSwitches.Controls.Add(Me.FraRenaming)
        Me.pnlVariableSwitches.Controls.Add(Me.fraLabeling)
        Me.pnlVariableSwitches.Location = New System.Drawing.Point(1067, 247)
        Me.pnlVariableSwitches.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlVariableSwitches.Name = "pnlVariableSwitches"
        Me.pnlVariableSwitches.Size = New System.Drawing.Size(124, 112)
        Me.pnlVariableSwitches.TabIndex = 11
        '
        'FraRenaming
        '
        Me.FraRenaming.Controls.Add(Me.btnRename_Cancel)
        Me.FraRenaming.Controls.Add(Me.btnRename_Ok)
        Me.FraRenaming.Controls.Add(Me.fraRandom10)
        Me.FraRenaming.ForeColor = System.Drawing.Color.Gainsboro
        Me.FraRenaming.Location = New System.Drawing.Point(315, 528)
        Me.FraRenaming.Margin = New System.Windows.Forms.Padding(4)
        Me.FraRenaming.Name = "FraRenaming"
        Me.FraRenaming.Padding = New System.Windows.Forms.Padding(4)
        Me.FraRenaming.Size = New System.Drawing.Size(485, 176)
        Me.FraRenaming.TabIndex = 8
        Me.FraRenaming.TabStop = False
        Me.FraRenaming.Text = "Renaming Variable/Switch"
        Me.FraRenaming.Visible = False
        '
        'btnRename_Cancel
        '
        Me.btnRename_Cancel.ForeColor = System.Drawing.Color.Black
        Me.btnRename_Cancel.Location = New System.Drawing.Point(306, 126)
        Me.btnRename_Cancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRename_Cancel.Name = "btnRename_Cancel"
        Me.btnRename_Cancel.Size = New System.Drawing.Size(100, 28)
        Me.btnRename_Cancel.TabIndex = 2
        Me.btnRename_Cancel.Text = "Cancel"
        Me.btnRename_Cancel.UseVisualStyleBackColor = True
        '
        'btnRename_Ok
        '
        Me.btnRename_Ok.ForeColor = System.Drawing.Color.Black
        Me.btnRename_Ok.Location = New System.Drawing.Point(72, 126)
        Me.btnRename_Ok.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRename_Ok.Name = "btnRename_Ok"
        Me.btnRename_Ok.Size = New System.Drawing.Size(100, 28)
        Me.btnRename_Ok.TabIndex = 1
        Me.btnRename_Ok.Text = "Ok"
        Me.btnRename_Ok.UseVisualStyleBackColor = True
        '
        'fraRandom10
        '
        Me.fraRandom10.Controls.Add(Me.txtRename)
        Me.fraRandom10.Controls.Add(Me.lblEditing)
        Me.fraRandom10.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraRandom10.Location = New System.Drawing.Point(8, 23)
        Me.fraRandom10.Margin = New System.Windows.Forms.Padding(4)
        Me.fraRandom10.Name = "fraRandom10"
        Me.fraRandom10.Padding = New System.Windows.Forms.Padding(4)
        Me.fraRandom10.Size = New System.Drawing.Size(469, 94)
        Me.fraRandom10.TabIndex = 0
        Me.fraRandom10.TabStop = False
        Me.fraRandom10.Text = "Editing Variable/Switch"
        '
        'txtRename
        '
        Me.txtRename.Location = New System.Drawing.Point(8, 50)
        Me.txtRename.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRename.Name = "txtRename"
        Me.txtRename.Size = New System.Drawing.Size(452, 22)
        Me.txtRename.TabIndex = 1
        '
        'lblEditing
        '
        Me.lblEditing.AutoSize = True
        Me.lblEditing.Location = New System.Drawing.Point(4, 30)
        Me.lblEditing.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEditing.Name = "lblEditing"
        Me.lblEditing.Size = New System.Drawing.Size(132, 17)
        Me.lblEditing.TabIndex = 0
        Me.lblEditing.Text = "Naming Variable #1"
        '
        'fraLabeling
        '
        Me.fraLabeling.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraLabeling.Controls.Add(Me.lstSwitches)
        Me.fraLabeling.Controls.Add(Me.lstVariables)
        Me.fraLabeling.Controls.Add(Me.btnLabel_Cancel)
        Me.fraLabeling.Controls.Add(Me.lblRandomLabel36)
        Me.fraLabeling.Controls.Add(Me.btnRenameVariable)
        Me.fraLabeling.Controls.Add(Me.lblRandomLabel25)
        Me.fraLabeling.Controls.Add(Me.btnRenameSwitch)
        Me.fraLabeling.Controls.Add(Me.btnLabel_Ok)
        Me.fraLabeling.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraLabeling.Location = New System.Drawing.Point(260, 36)
        Me.fraLabeling.Margin = New System.Windows.Forms.Padding(4)
        Me.fraLabeling.Name = "fraLabeling"
        Me.fraLabeling.Padding = New System.Windows.Forms.Padding(4)
        Me.fraLabeling.Size = New System.Drawing.Size(608, 476)
        Me.fraLabeling.TabIndex = 0
        Me.fraLabeling.TabStop = False
        Me.fraLabeling.Text = "Label Variables and  Switches   "
        '
        'lstSwitches
        '
        Me.lstSwitches.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lstSwitches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstSwitches.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstSwitches.FormattingEnabled = True
        Me.lstSwitches.ItemHeight = 16
        Me.lstSwitches.Location = New System.Drawing.Point(315, 48)
        Me.lstSwitches.Margin = New System.Windows.Forms.Padding(4)
        Me.lstSwitches.Name = "lstSwitches"
        Me.lstSwitches.Size = New System.Drawing.Size(272, 354)
        Me.lstSwitches.TabIndex = 7
        '
        'lstVariables
        '
        Me.lstVariables.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lstVariables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstVariables.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstVariables.FormattingEnabled = True
        Me.lstVariables.ItemHeight = 16
        Me.lstVariables.Location = New System.Drawing.Point(19, 48)
        Me.lstVariables.Margin = New System.Windows.Forms.Padding(4)
        Me.lstVariables.Name = "lstVariables"
        Me.lstVariables.Size = New System.Drawing.Size(272, 354)
        Me.lstVariables.TabIndex = 6
        '
        'btnLabel_Cancel
        '
        Me.btnLabel_Cancel.ForeColor = System.Drawing.Color.Black
        Me.btnLabel_Cancel.Location = New System.Drawing.Point(315, 420)
        Me.btnLabel_Cancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLabel_Cancel.Name = "btnLabel_Cancel"
        Me.btnLabel_Cancel.Size = New System.Drawing.Size(100, 28)
        Me.btnLabel_Cancel.TabIndex = 12
        Me.btnLabel_Cancel.Text = "Cancel"
        Me.btnLabel_Cancel.UseVisualStyleBackColor = True
        '
        'lblRandomLabel36
        '
        Me.lblRandomLabel36.AutoSize = True
        Me.lblRandomLabel36.Location = New System.Drawing.Point(391, 28)
        Me.lblRandomLabel36.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRandomLabel36.Name = "lblRandomLabel36"
        Me.lblRandomLabel36.Size = New System.Drawing.Size(107, 17)
        Me.lblRandomLabel36.TabIndex = 5
        Me.lblRandomLabel36.Text = "Player Switches"
        '
        'btnRenameVariable
        '
        Me.btnRenameVariable.ForeColor = System.Drawing.Color.Black
        Me.btnRenameVariable.Location = New System.Drawing.Point(19, 420)
        Me.btnRenameVariable.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRenameVariable.Name = "btnRenameVariable"
        Me.btnRenameVariable.Size = New System.Drawing.Size(141, 28)
        Me.btnRenameVariable.TabIndex = 9
        Me.btnRenameVariable.Text = "Rename Variable"
        Me.btnRenameVariable.UseVisualStyleBackColor = True
        '
        'lblRandomLabel25
        '
        Me.lblRandomLabel25.AutoSize = True
        Me.lblRandomLabel25.Location = New System.Drawing.Point(107, 26)
        Me.lblRandomLabel25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRandomLabel25.Name = "lblRandomLabel25"
        Me.lblRandomLabel25.Size = New System.Drawing.Size(111, 17)
        Me.lblRandomLabel25.TabIndex = 4
        Me.lblRandomLabel25.Text = "Player Variables"
        '
        'btnRenameSwitch
        '
        Me.btnRenameSwitch.ForeColor = System.Drawing.Color.Black
        Me.btnRenameSwitch.Location = New System.Drawing.Point(443, 420)
        Me.btnRenameSwitch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRenameSwitch.Name = "btnRenameSwitch"
        Me.btnRenameSwitch.Size = New System.Drawing.Size(146, 28)
        Me.btnRenameSwitch.TabIndex = 10
        Me.btnRenameSwitch.Text = "Rename Switch"
        Me.btnRenameSwitch.UseVisualStyleBackColor = True
        '
        'btnLabel_Ok
        '
        Me.btnLabel_Ok.ForeColor = System.Drawing.Color.Black
        Me.btnLabel_Ok.Location = New System.Drawing.Point(192, 420)
        Me.btnLabel_Ok.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLabel_Ok.Name = "btnLabel_Ok"
        Me.btnLabel_Ok.Size = New System.Drawing.Size(100, 28)
        Me.btnLabel_Ok.TabIndex = 11
        Me.btnLabel_Ok.Text = "Ok"
        Me.btnLabel_Ok.UseVisualStyleBackColor = True
        '
        'FrmEditor_Events
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1710, 764)
        Me.ControlBox = False
        Me.Controls.Add(Me.fraGraphic)
        Me.Controls.Add(Me.pnlVariableSwitches)
        Me.Controls.Add(Me.fraDialogue)
        Me.Controls.Add(Me.fraMoveRoute)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnLabeling)
        Me.Controls.Add(Me.DarkGroupBox6)
        Me.Controls.Add(Me.pnlTabPage)
        Me.Controls.Add(Me.tabPages)
        Me.Controls.Add(Me.fraPageSetUp)
        Me.ForeColor = System.Drawing.Color.Gainsboro
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmEditor_Events"
        Me.Text = "Editor de Eventos"
        Me.fraPageSetUp.ResumeLayout(False)
        Me.fraPageSetUp.PerformLayout()
        Me.tabPages.ResumeLayout(False)
        Me.pnlTabPage.ResumeLayout(False)
        Me.fraCommands.ResumeLayout(False)
        Me.DarkGroupBox8.ResumeLayout(False)
        Me.DarkGroupBox7.ResumeLayout(False)
        Me.DarkGroupBox7.PerformLayout()
        Me.DarkGroupBox5.ResumeLayout(False)
        Me.DarkGroupBox4.ResumeLayout(False)
        Me.DarkGroupBox3.ResumeLayout(False)
        Me.DarkGroupBox3.PerformLayout()
        Me.DarkGroupBox2.ResumeLayout(False)
        CType(Me.picGraphic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DarkGroupBox1.ResumeLayout(False)
        Me.DarkGroupBox1.PerformLayout()
        CType(Me.nudPlayerVariable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DarkGroupBox6.ResumeLayout(False)
        Me.DarkGroupBox6.PerformLayout()
        Me.fraMoveRoute.ResumeLayout(False)
        Me.fraMoveRoute.PerformLayout()
        Me.DarkGroupBox10.ResumeLayout(False)
        Me.fraGraphic.ResumeLayout(False)
        Me.fraGraphic.PerformLayout()
        Me.pnlGraphicSel.ResumeLayout(False)
        CType(Me.picGraphicSel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudGraphic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraDialogue.ResumeLayout(False)
        Me.fraConditionalBranch.ResumeLayout(False)
        Me.fraConditionalBranch.PerformLayout()
        Me.fraConditions_Quest.ResumeLayout(False)
        Me.fraConditions_Quest.PerformLayout()
        CType(Me.nudCondition_QuestTask, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCondition_Quest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCondition_LevelAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCondition_HasItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCondition_PlayerVarCondition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraPlayAnimation.ResumeLayout(False)
        Me.fraPlayAnimation.PerformLayout()
        CType(Me.nudPlayAnimTileY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPlayAnimTileX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraMoveRouteWait.ResumeLayout(False)
        Me.fraMoveRouteWait.PerformLayout()
        Me.fraCustomScript.ResumeLayout(False)
        Me.fraCustomScript.PerformLayout()
        CType(Me.nudCustomScript, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraSetWeather.ResumeLayout(False)
        Me.fraSetWeather.PerformLayout()
        CType(Me.nudWeatherIntensity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraSpawnNpc.ResumeLayout(False)
        Me.fraGiveExp.ResumeLayout(False)
        Me.fraGiveExp.PerformLayout()
        CType(Me.nudGiveExp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraEndQuest.ResumeLayout(False)
        Me.fraSetAccess.ResumeLayout(False)
        Me.fraSetWait.ResumeLayout(False)
        Me.fraSetWait.PerformLayout()
        CType(Me.nudWaitAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraShowPic.ResumeLayout(False)
        Me.fraShowPic.PerformLayout()
        CType(Me.nudPicOffsetY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPicOffsetX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudShowPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picShowPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraOpenShop.ResumeLayout(False)
        Me.fraChangeLevel.ResumeLayout(False)
        Me.fraChangeLevel.PerformLayout()
        CType(Me.nudChangeLevel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraChangeGender.ResumeLayout(False)
        Me.fraChangeGender.PerformLayout()
        Me.fraGoToLabel.ResumeLayout(False)
        Me.fraGoToLabel.PerformLayout()
        Me.fraHidePic.ResumeLayout(False)
        Me.fraHidePic.PerformLayout()
        CType(Me.nudHidePic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraBeginQuest.ResumeLayout(False)
        Me.fraBeginQuest.PerformLayout()
        Me.fraShowChoices.ResumeLayout(False)
        Me.fraShowChoices.PerformLayout()
        CType(Me.picShowChoicesFace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudShowChoicesFace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraPlayerVariable.ResumeLayout(False)
        Me.fraPlayerVariable.PerformLayout()
        CType(Me.nudVariableData2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudVariableData4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudVariableData3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudVariableData1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudVariableData0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraChangeSprite.ResumeLayout(False)
        Me.fraChangeSprite.PerformLayout()
        CType(Me.nudChangeSprite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picChangeSprite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraSetSelfSwitch.ResumeLayout(False)
        Me.fraSetSelfSwitch.PerformLayout()
        Me.fraMapTint.ResumeLayout(False)
        Me.fraMapTint.PerformLayout()
        CType(Me.nudMapTintData3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMapTintData2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMapTintData1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMapTintData0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraShowChatBubble.ResumeLayout(False)
        Me.fraShowChatBubble.PerformLayout()
        Me.fraPlaySound.ResumeLayout(False)
        Me.fraChangePK.ResumeLayout(False)
        Me.fraCreateLabel.ResumeLayout(False)
        Me.fraCreateLabel.PerformLayout()
        Me.fraChangeClass.ResumeLayout(False)
        Me.fraChangeClass.PerformLayout()
        Me.fraChangeSkills.ResumeLayout(False)
        Me.fraChangeSkills.PerformLayout()
        Me.fraCompleteTask.ResumeLayout(False)
        Me.fraCompleteTask.PerformLayout()
        CType(Me.nudCompleteQuestTask, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraPlayerWarp.ResumeLayout(False)
        Me.fraPlayerWarp.PerformLayout()
        CType(Me.nudWPY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudWPX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudWPMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraSetFog.ResumeLayout(False)
        Me.fraSetFog.PerformLayout()
        CType(Me.nudFogData2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudFogData1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudFogData0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraShowText.ResumeLayout(False)
        Me.fraShowText.PerformLayout()
        CType(Me.picShowTextFace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudShowTextFace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraAddText.ResumeLayout(False)
        Me.fraAddText.PerformLayout()
        Me.fraPlayerSwitch.ResumeLayout(False)
        Me.fraPlayerSwitch.PerformLayout()
        Me.fraChangeItems.ResumeLayout(False)
        Me.fraChangeItems.PerformLayout()
        CType(Me.nudChangeItemsAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraPlayBGM.ResumeLayout(False)
        Me.pnlVariableSwitches.ResumeLayout(False)
        Me.FraRenaming.ResumeLayout(False)
        Me.fraRandom10.ResumeLayout(False)
        Me.fraRandom10.PerformLayout()
        Me.fraLabeling.ResumeLayout(False)
        Me.fraLabeling.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tvCommands As TreeView
    Friend WithEvents fraPageSetUp As GroupBox
    Friend WithEvents tabPages As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents txtName As TextBox
    Friend WithEvents DarkLabel1 As Label
    Friend WithEvents btnNewPage As Button
    Friend WithEvents btnCopyPage As Button
    Friend WithEvents btnPastePage As Button
    Friend WithEvents btnClearPage As Button
    Friend WithEvents btnDeletePage As Button
    Friend WithEvents pnlTabPage As Panel
    Friend WithEvents DarkGroupBox1 As GroupBox
    Friend WithEvents chkPlayerVar As CheckBox
    Friend WithEvents cmbPlayerVar As ComboBox
    Friend WithEvents DarkLabel2 As Label
    Friend WithEvents cmbPlayervarCompare As ComboBox
    Friend WithEvents nudPlayerVariable As NumericUpDown
    Friend WithEvents chkPlayerSwitch As CheckBox
    Friend WithEvents cmbPlayerSwitch As ComboBox
    Friend WithEvents cmbPlayerSwitchCompare As ComboBox
    Friend WithEvents DarkLabel3 As Label
    Friend WithEvents cmbHasItem As ComboBox
    Friend WithEvents chkHasItem As CheckBox
    Friend WithEvents cmbSelfSwitch As ComboBox
    Friend WithEvents chkSelfSwitch As CheckBox
    Friend WithEvents cmbSelfSwitchCompare As ComboBox
    Friend WithEvents DarkLabel4 As Label
    Friend WithEvents DarkGroupBox2 As GroupBox
    Friend WithEvents picGraphic As PictureBox
    Friend WithEvents DarkGroupBox3 As GroupBox
    Friend WithEvents chkGlobal As CheckBox
    Friend WithEvents DarkLabel5 As Label
    Friend WithEvents cmbMoveType As ComboBox
    Friend WithEvents btnMoveRoute As Button
    Friend WithEvents DarkLabel6 As Label
    Friend WithEvents cmbMoveSpeed As ComboBox
    Friend WithEvents cmbMoveFreq As ComboBox
    Friend WithEvents DarkLabel7 As Label
    Friend WithEvents DarkGroupBox4 As GroupBox
    Friend WithEvents cmbPositioning As ComboBox
    Friend WithEvents DarkGroupBox5 As GroupBox
    Friend WithEvents cmbTrigger As ComboBox
    Friend WithEvents DarkGroupBox6 As GroupBox
    Friend WithEvents chkWalkAnim As CheckBox
    Friend WithEvents chkDirFix As CheckBox
    Friend WithEvents chkWalkThrough As CheckBox
    Friend WithEvents chkShowName As CheckBox
    Friend WithEvents DarkGroupBox7 As GroupBox
    Friend WithEvents cmbEventQuest As ComboBox
    Friend WithEvents DarkLabel8 As Label
    Friend WithEvents DarkLabel10 As Label
    Friend WithEvents DarkLabel9 As Label
    Friend WithEvents lstCommands As ListBox
    Friend WithEvents DarkGroupBox8 As GroupBox
    Friend WithEvents btnAddCommand As Button
    Friend WithEvents btnDeleteCommand As Button
    Friend WithEvents btnEditCommand As Button
    Friend WithEvents btnClearCommand As Button
    Friend WithEvents fraCommands As Panel
    Friend WithEvents btnLabeling As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOk As Button
    Friend WithEvents btnCancelCommand As Button
    Friend WithEvents fraMoveRoute As GroupBox
    Friend WithEvents cmbEvent As ComboBox
    Friend WithEvents lstMoveRoute As ListBox
    Friend WithEvents DarkGroupBox10 As GroupBox
    Friend WithEvents lstvwMoveRoute As ListView
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents chkRepeatRoute As CheckBox
    Friend WithEvents chkIgnoreMove As CheckBox
    Friend WithEvents btnMoveRouteOk As Button
    Friend WithEvents btnMoveRouteCancel As Button
    Friend WithEvents fraGraphic As GroupBox
    Friend WithEvents DarkLabel11 As Label
    Friend WithEvents cmbGraphic As ComboBox
    Friend WithEvents DarkLabel12 As Label
    Friend WithEvents nudGraphic As NumericUpDown
    Friend WithEvents DarkLabel13 As Label
    Friend WithEvents picGraphicSel As PictureBox
    Friend WithEvents btnGraphicOk As Button
    Friend WithEvents btnGraphicCancel As Button
    Friend WithEvents fraDialogue As GroupBox
    Friend WithEvents fraConditionalBranch As GroupBox
    Friend WithEvents optCondition0 As RadioButton
    Friend WithEvents cmbCondition_PlayerVarIndex As ComboBox
    Friend WithEvents nudCondition_PlayerVarCondition As NumericUpDown
    Friend WithEvents cmbCondition_PlayerVarCompare As ComboBox
    Friend WithEvents DarkLabel14 As Label
    Friend WithEvents optCondition1 As RadioButton
    Friend WithEvents DarkLabel15 As Label
    Friend WithEvents cmbCondtion_PlayerSwitchCondition As ComboBox
    Friend WithEvents cmbCondition_PlayerSwitch As ComboBox
    Friend WithEvents optCondition2 As RadioButton
    Friend WithEvents nudCondition_HasItem As NumericUpDown
    Friend WithEvents DarkLabel16 As Label
    Friend WithEvents cmbCondition_HasItem As ComboBox
    Friend WithEvents optCondition3 As RadioButton
    Friend WithEvents cmbCondition_ClassIs As ComboBox
    Friend WithEvents optCondition4 As RadioButton
    Friend WithEvents cmbCondition_LearntSkill As ComboBox
    Friend WithEvents optCondition5 As RadioButton
    Friend WithEvents cmbCondition_LevelCompare As ComboBox
    Friend WithEvents nudCondition_LevelAmount As NumericUpDown
    Friend WithEvents optCondition6 As RadioButton
    Friend WithEvents cmbCondition_SelfSwitchCondition As ComboBox
    Friend WithEvents DarkLabel17 As Label
    Friend WithEvents cmbCondition_SelfSwitch As ComboBox
    Friend WithEvents optCondition7 As RadioButton
    Friend WithEvents nudCondition_Quest As NumericUpDown
    Friend WithEvents DarkLabel18 As Label
    Friend WithEvents fraConditions_Quest As GroupBox
    Friend WithEvents DarkLabel19 As Label
    Friend WithEvents optCondition_Quest1 As RadioButton
    Friend WithEvents optCondition_Quest0 As RadioButton
    Friend WithEvents cmbCondition_General As ComboBox
    Friend WithEvents nudCondition_QuestTask As NumericUpDown
    Friend WithEvents DarkLabel20 As Label
    Friend WithEvents optCondition8 As RadioButton
    Friend WithEvents cmbCondition_Gender As ComboBox
    Friend WithEvents btnConditionalBranchOk As Button
    Friend WithEvents btnConditionalBranchCancel As Button
    Friend WithEvents fraChangeItems As GroupBox
    Friend WithEvents fraPlayerSwitch As GroupBox
    Friend WithEvents cmbChangeItemIndex As ComboBox
    Friend WithEvents DarkLabel21 As Label
    Friend WithEvents optChangeItemSet As RadioButton
    Friend WithEvents optChangeItemRemove As RadioButton
    Friend WithEvents optChangeItemAdd As RadioButton
    Friend WithEvents nudChangeItemsAmount As NumericUpDown
    Friend WithEvents btnChangeItemsOk As Button
    Friend WithEvents btnChangeItemsCancel As Button
    Friend WithEvents cmbSwitch As ComboBox
    Friend WithEvents DarkLabel22 As Label
    Friend WithEvents DarkLabel23 As Label
    Friend WithEvents cmbPlayerSwitchSet As ComboBox
    Friend WithEvents btnSetPlayerSwitchOk As Button
    Friend WithEvents btnSetPlayerswitchCancel As Button
    Friend WithEvents fraAddText As GroupBox
    Friend WithEvents txtAddText_Text As TextBox
    Friend WithEvents DarkLabel24 As Label
    Friend WithEvents optAddText_Player As RadioButton
    Friend WithEvents DarkLabel25 As Label
    Friend WithEvents optAddText_Map As RadioButton
    Friend WithEvents btnAddTextOk As Button
    Friend WithEvents btnAddTextCancel As Button
    Friend WithEvents optAddText_Global As RadioButton
    Friend WithEvents btnShowTextOk As Button
    Friend WithEvents btnShowTextCancel As Button
    Friend WithEvents nudShowTextFace As NumericUpDown
    Friend WithEvents DarkLabel26 As Label
    Friend WithEvents txtShowText As TextBox
    Friend WithEvents picShowTextFace As PictureBox
    Friend WithEvents DarkLabel27 As Label
    Friend WithEvents fraShowText As GroupBox
    Friend WithEvents fraSetFog As GroupBox
    Friend WithEvents btnSetFogOk As Button
    Friend WithEvents btnSetFogCancel As Button
    Friend WithEvents DarkLabel30 As Label
    Friend WithEvents DarkLabel29 As Label
    Friend WithEvents DarkLabel28 As Label
    Friend WithEvents nudFogData2 As NumericUpDown
    Friend WithEvents nudFogData1 As NumericUpDown
    Friend WithEvents nudFogData0 As NumericUpDown
    Friend WithEvents fraPlayerWarp As GroupBox
    Friend WithEvents btnPlayerWarpOk As Button
    Friend WithEvents btnPlayerWarpCancel As Button
    Friend WithEvents DarkLabel31 As Label
    Friend WithEvents cmbWarpPlayerDir As ComboBox
    Friend WithEvents nudWPY As NumericUpDown
    Friend WithEvents DarkLabel32 As Label
    Friend WithEvents nudWPX As NumericUpDown
    Friend WithEvents DarkLabel33 As Label
    Friend WithEvents nudWPMap As NumericUpDown
    Friend WithEvents DarkLabel34 As Label
    Friend WithEvents fraCompleteTask As GroupBox
    Friend WithEvents btnCompleteQuestTaskOk As Button
    Friend WithEvents btnCompleteQuestTaskCancel As Button
    Friend WithEvents DarkLabel35 As Label
    Friend WithEvents DarkLabel36 As Label
    Friend WithEvents nudCompleteQuestTask As NumericUpDown
    Friend WithEvents cmbCompleteQuest As ComboBox
    Friend WithEvents fraPlayBGM As GroupBox
    Friend WithEvents cmbPlayBGM As ComboBox
    Friend WithEvents btnPlayBgmOk As Button
    Friend WithEvents btnPlayBgmCancel As Button
    Friend WithEvents fraChangeSkills As GroupBox
    Friend WithEvents cmbChangeSkills As ComboBox
    Friend WithEvents DarkLabel37 As Label
    Friend WithEvents optChangeSkillsAdd As RadioButton
    Friend WithEvents btnChangeSkillsOk As Button
    Friend WithEvents btnChangeSkillsCancel As Button
    Friend WithEvents optChangeSkillsRemove As RadioButton
    Friend WithEvents fraChangeClass As GroupBox
    Friend WithEvents cmbChangeClass As ComboBox
    Friend WithEvents DarkLabel38 As Label
    Friend WithEvents btnChangeClassOk As Button
    Friend WithEvents btnChangeClassCancel As Button
    Friend WithEvents fraCreateLabel As GroupBox
    Friend WithEvents lblLabelName As Label
    Friend WithEvents txtLabelName As TextBox
    Friend WithEvents btnCreatelabelOk As Button
    Friend WithEvents btnCreatelabelCancel As Button
    Friend WithEvents fraChangePK As GroupBox
    Friend WithEvents btnChangePkOk As Button
    Friend WithEvents btnChangePkCancel As Button
    Friend WithEvents cmbSetPK As ComboBox
    Friend WithEvents fraPlaySound As GroupBox
    Friend WithEvents btnPlaySoundOk As Button
    Friend WithEvents btnPlaySoundCancel As Button
    Friend WithEvents cmbPlaySound As ComboBox
    Friend WithEvents fraShowChatBubble As GroupBox
    Friend WithEvents DarkLabel39 As Label
    Friend WithEvents txtChatbubbleText As TextBox
    Friend WithEvents DarkLabel40 As Label
    Friend WithEvents cmbChatBubbleTarget As ComboBox
    Friend WithEvents cmbChatBubbleTargetType As ComboBox
    Friend WithEvents btnShowChatBubbleOk As Button
    Friend WithEvents btnShowChatBubbleCancel As Button
    Friend WithEvents DarkLabel41 As Label
    Friend WithEvents fraMapTint As GroupBox
    Friend WithEvents btnMapTintOk As Button
    Friend WithEvents btnMapTintCancel As Button
    Friend WithEvents DarkLabel42 As Label
    Friend WithEvents nudMapTintData3 As NumericUpDown
    Friend WithEvents nudMapTintData2 As NumericUpDown
    Friend WithEvents DarkLabel43 As Label
    Friend WithEvents DarkLabel44 As Label
    Friend WithEvents nudMapTintData1 As NumericUpDown
    Friend WithEvents nudMapTintData0 As NumericUpDown
    Friend WithEvents DarkLabel45 As Label
    Friend WithEvents fraSetSelfSwitch As GroupBox
    Friend WithEvents cmbSetSelfSwitch As ComboBox
    Friend WithEvents DarkLabel46 As Label
    Friend WithEvents btnSelfswitchOk As Button
    Friend WithEvents btnSelfswitchCancel As Button
    Friend WithEvents DarkLabel47 As Label
    Friend WithEvents cmbSetSelfSwitchTo As ComboBox
    Friend WithEvents fraChangeSprite As GroupBox
    Friend WithEvents picChangeSprite As PictureBox
    Friend WithEvents btnChangeSpriteOk As Button
    Friend WithEvents btnChangeSpriteCancel As Button
    Friend WithEvents DarkLabel48 As Label
    Friend WithEvents nudChangeSprite As NumericUpDown
    Friend WithEvents fraPlayerVariable As GroupBox
    Friend WithEvents cmbVariable As ComboBox
    Friend WithEvents DarkLabel49 As Label
    Friend WithEvents optVariableAction0 As RadioButton
    Friend WithEvents optVariableAction1 As RadioButton
    Friend WithEvents nudVariableData1 As NumericUpDown
    Friend WithEvents nudVariableData0 As NumericUpDown
    Friend WithEvents optVariableAction3 As RadioButton
    Friend WithEvents nudVariableData3 As NumericUpDown
    Friend WithEvents optVariableAction2 As RadioButton
    Friend WithEvents btnPlayerVarOk As Button
    Friend WithEvents btnPlayerVarCancel As Button
    Friend WithEvents DarkLabel51 As Label
    Friend WithEvents DarkLabel50 As Label
    Friend WithEvents nudVariableData4 As NumericUpDown
    Friend WithEvents nudVariableData2 As NumericUpDown
    Friend WithEvents fraShowChoices As GroupBox
    Friend WithEvents DarkLabel52 As Label
    Friend WithEvents txtChoicePrompt As TextBox
    Friend WithEvents btnShowChoicesOk As Button
    Friend WithEvents picShowChoicesFace As PictureBox
    Friend WithEvents btnShowChoicesCancel As Button
    Friend WithEvents DarkLabel53 As Label
    Friend WithEvents nudShowChoicesFace As NumericUpDown
    Friend WithEvents DarkLabel56 As Label
    Friend WithEvents DarkLabel57 As Label
    Friend WithEvents DarkLabel55 As Label
    Friend WithEvents DarkLabel54 As Label
    Friend WithEvents txtChoices4 As TextBox
    Friend WithEvents txtChoices3 As TextBox
    Friend WithEvents txtChoices2 As TextBox
    Friend WithEvents txtChoices1 As TextBox
    Friend WithEvents fraBeginQuest As GroupBox
    Friend WithEvents cmbBeginQuest As ComboBox
    Friend WithEvents DarkLabel58 As Label
    Friend WithEvents btnBeginQuestOk As Button
    Friend WithEvents btnBeginQuestCancel As Button
    Friend WithEvents fraHidePic As GroupBox
    Friend WithEvents nudHidePic As NumericUpDown
    Friend WithEvents DarkLabel59 As Label
    Friend WithEvents btnHidePicOk As Button
    Friend WithEvents btnHidePicCancel As Button
    Friend WithEvents fraGoToLabel As GroupBox
    Friend WithEvents txtGotoLabel As TextBox
    Friend WithEvents DarkLabel60 As Label
    Friend WithEvents btnGoToLabelOk As Button
    Friend WithEvents btnGoToLabelCancel As Button
    Friend WithEvents fraPlayAnimation As GroupBox
    Friend WithEvents DarkLabel61 As Label
    Friend WithEvents cmbPlayAnim As ComboBox
    Friend WithEvents DarkLabel62 As Label
    Friend WithEvents cmbAnimTargetType As ComboBox
    Friend WithEvents nudPlayAnimTileY As NumericUpDown
    Friend WithEvents nudPlayAnimTileX As NumericUpDown
    Friend WithEvents cmbPlayAnimEvent As ComboBox
    Friend WithEvents btnPlayAnimationOk As Button
    Friend WithEvents btnPlayAnimationCancel As Button
    Friend WithEvents lblPlayAnimY As Label
    Friend WithEvents lblPlayAnimX As Label
    Friend WithEvents fraChangeGender As GroupBox
    Friend WithEvents btnChangeGenderOk As Button
    Friend WithEvents btnChangeGenderCancel As Button
    Friend WithEvents optChangeSexFemale As RadioButton
    Friend WithEvents optChangeSexMale As RadioButton
    Friend WithEvents fraChangeLevel As GroupBox
    Friend WithEvents btnChangeLevelOk As Button
    Friend WithEvents btnChangeLevelCancel As Button
    Friend WithEvents DarkLabel65 As Label
    Friend WithEvents nudChangeLevel As NumericUpDown
    Friend WithEvents fraOpenShop As GroupBox
    Friend WithEvents cmbOpenShop As ComboBox
    Friend WithEvents btnOpenShopOk As Button
    Friend WithEvents btnOpenShopCancel As Button
    Friend WithEvents fraShowPic As GroupBox
    Friend WithEvents cmbPicIndex As ComboBox
    Friend WithEvents DarkLabel66 As Label
    Friend WithEvents DarkLabel67 As Label
    Friend WithEvents DarkLabel68 As Label
    Friend WithEvents nudPicOffsetY As NumericUpDown
    Friend WithEvents nudPicOffsetX As NumericUpDown
    Friend WithEvents DarkLabel69 As Label
    Friend WithEvents cmbPicLoc As ComboBox
    Friend WithEvents nudShowPicture As NumericUpDown
    Friend WithEvents picShowPic As PictureBox
    Friend WithEvents btnShowPicOk As Button
    Friend WithEvents btnShowPicCancel As Button
    Friend WithEvents DarkLabel71 As Label
    Friend WithEvents DarkLabel70 As Label
    Friend WithEvents fraSetWait As GroupBox
    Friend WithEvents btnSetWaitOk As Button
    Friend WithEvents btnSetWaitCancel As Button
    Friend WithEvents DarkLabel74 As Label
    Friend WithEvents DarkLabel72 As Label
    Friend WithEvents DarkLabel73 As Label
    Friend WithEvents nudWaitAmount As NumericUpDown
    Friend WithEvents fraSetAccess As GroupBox
    Friend WithEvents btnSetAccessOk As Button
    Friend WithEvents btnSetAccessCancel As Button
    Friend WithEvents cmbSetAccess As ComboBox
    Friend WithEvents fraEndQuest As GroupBox
    Friend WithEvents btnEndQuestOk As Button
    Friend WithEvents btnEndQuestCancel As Button
    Friend WithEvents cmbEndQuest As ComboBox
    Friend WithEvents fraSetWeather As GroupBox
    Friend WithEvents DarkLabel75 As Label
    Friend WithEvents CmbWeather As ComboBox
    Friend WithEvents btnSetWeatherOk As Button
    Friend WithEvents btnSetWeatherCancel As Button
    Friend WithEvents DarkLabel76 As Label
    Friend WithEvents nudWeatherIntensity As NumericUpDown
    Friend WithEvents fraGiveExp As GroupBox
    Friend WithEvents DarkLabel77 As Label
    Friend WithEvents fraSpawnNpc As GroupBox
    Friend WithEvents cmbSpawnNpc As ComboBox
    Friend WithEvents btnGiveExpOk As Button
    Friend WithEvents btnGiveExpCancel As Button
    Friend WithEvents nudGiveExp As NumericUpDown
    Friend WithEvents btnSpawnNpcOk As Button
    Friend WithEvents btnSpawnNpcCancel As Button
    Friend WithEvents fraCustomScript As GroupBox
    Friend WithEvents nudCustomScript As NumericUpDown
    Friend WithEvents DarkLabel78 As Label
    Friend WithEvents btnCustomScriptCancel As Button
    Friend WithEvents btnCustomScriptOk As Button
    Friend WithEvents fraMoveRouteWait As GroupBox
    Friend WithEvents btnMoveWaitCancel As Button
    Friend WithEvents btnMoveWaitOk As Button
    Friend WithEvents DarkLabel79 As Label
    Friend WithEvents cmbMoveWait As ComboBox
    Friend WithEvents pnlVariableSwitches As Panel
    Friend WithEvents fraLabeling As GroupBox
    Friend WithEvents lstSwitches As ListBox
    Friend WithEvents lstVariables As ListBox
    Friend WithEvents lblRandomLabel36 As Label
    Friend WithEvents lblRandomLabel25 As Label
    Friend WithEvents FraRenaming As GroupBox
    Friend WithEvents btnRename_Cancel As Button
    Friend WithEvents btnRename_Ok As Button
    Friend WithEvents fraRandom10 As GroupBox
    Friend WithEvents txtRename As TextBox
    Friend WithEvents lblEditing As Label
    Friend WithEvents btnLabel_Cancel As Button
    Friend WithEvents btnRenameVariable As Button
    Friend WithEvents btnRenameSwitch As Button
    Friend WithEvents btnLabel_Ok As Button
    Friend WithEvents pnlGraphicSel As Panel
    Friend WithEvents cmbCondition_Time As ComboBox
    Friend WithEvents optCondition9 As RadioButton
End Class
