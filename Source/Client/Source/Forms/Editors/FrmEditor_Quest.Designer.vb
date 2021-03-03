<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditor_Quest
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
        Me.fraQuestList = New System.Windows.Forms.GroupBox()
        Me.lstIndex = New System.Windows.Forms.ListBox()
        Me.DarkGroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DarkGroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lstRequirements = New System.Windows.Forms.ListBox()
        Me.btnRemoveRequirement = New System.Windows.Forms.Button()
        Me.btnAddRequirement = New System.Windows.Forms.Button()
        Me.DarkGroupBox3 = New System.Windows.Forms.GroupBox()
        Me.nudItemRewValue = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel7 = New System.Windows.Forms.Label()
        Me.cmbItemReward = New System.Windows.Forms.ComboBox()
        Me.DarkLabel6 = New System.Windows.Forms.Label()
        Me.nudExpReward = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel5 = New System.Windows.Forms.Label()
        Me.btnRemoveReward = New System.Windows.Forms.Button()
        Me.btnAddReward = New System.Windows.Forms.Button()
        Me.lstRewards = New System.Windows.Forms.ListBox()
        Me.DarkLabel4 = New System.Windows.Forms.Label()
        Me.DarkLabel3 = New System.Windows.Forms.Label()
        Me.txtEndText = New System.Windows.Forms.TextBox()
        Me.txtProgressText = New System.Windows.Forms.TextBox()
        Me.DarkLabel2 = New System.Windows.Forms.Label()
        Me.txtStartText = New System.Windows.Forms.TextBox()
        Me.chkQuestCancel = New System.Windows.Forms.CheckBox()
        Me.chkRepeat = New System.Windows.Forms.CheckBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.DarkLabel1 = New System.Windows.Forms.Label()
        Me.DarkGroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnRemoveTask = New System.Windows.Forms.Button()
        Me.btnAddTask = New System.Windows.Forms.Button()
        Me.lstTasks = New System.Windows.Forms.ListBox()
        Me.DarkLabel8 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.fraTasks = New System.Windows.Forms.GroupBox()
        Me.btnCancelTask = New System.Windows.Forms.Button()
        Me.btnSaveTask = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.optTask7 = New System.Windows.Forms.RadioButton()
        Me.optTask6 = New System.Windows.Forms.RadioButton()
        Me.optTask5 = New System.Windows.Forms.RadioButton()
        Me.optTask4 = New System.Windows.Forms.RadioButton()
        Me.optTask3 = New System.Windows.Forms.RadioButton()
        Me.optTask2 = New System.Windows.Forms.RadioButton()
        Me.DarkLabel16 = New System.Windows.Forms.Label()
        Me.optTask1 = New System.Windows.Forms.RadioButton()
        Me.optTask0 = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbResource = New System.Windows.Forms.ComboBox()
        Me.cmbMap = New System.Windows.Forms.ComboBox()
        Me.cmbItem = New System.Windows.Forms.ComboBox()
        Me.cmbNpc = New System.Windows.Forms.ComboBox()
        Me.DarkLabel17 = New System.Windows.Forms.Label()
        Me.lblTaskNum = New System.Windows.Forms.Label()
        Me.nudAmount = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel15 = New System.Windows.Forms.Label()
        Me.DarkLabel14 = New System.Windows.Forms.Label()
        Me.DarkLabel13 = New System.Windows.Forms.Label()
        Me.DarkLabel12 = New System.Windows.Forms.Label()
        Me.DarkLabel11 = New System.Windows.Forms.Label()
        Me.chkEnd = New System.Windows.Forms.CheckBox()
        Me.txtTaskSpeech = New System.Windows.Forms.TextBox()
        Me.DarkLabel10 = New System.Windows.Forms.Label()
        Me.txtTaskLog = New System.Windows.Forms.TextBox()
        Me.DarkLabel9 = New System.Windows.Forms.Label()
        Me.fraRequirements = New System.Windows.Forms.GroupBox()
        Me.DarkGroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnRequirementCancel = New System.Windows.Forms.Button()
        Me.btnRequirementSave = New System.Windows.Forms.Button()
        Me.nudTakeAmount = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel23 = New System.Windows.Forms.Label()
        Me.cmbEndItem = New System.Windows.Forms.ComboBox()
        Me.DarkLabel24 = New System.Windows.Forms.Label()
        Me.nudGiveAmount = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel22 = New System.Windows.Forms.Label()
        Me.cmbStartItem = New System.Windows.Forms.ComboBox()
        Me.DarkLabel21 = New System.Windows.Forms.Label()
        Me.cmbClassReq = New System.Windows.Forms.ComboBox()
        Me.DarkLabel20 = New System.Windows.Forms.Label()
        Me.rdbClassReq = New System.Windows.Forms.RadioButton()
        Me.cmbQuestReq = New System.Windows.Forms.ComboBox()
        Me.DarkLabel19 = New System.Windows.Forms.Label()
        Me.rdbQuestReq = New System.Windows.Forms.RadioButton()
        Me.cmbItemReq = New System.Windows.Forms.ComboBox()
        Me.DarkLabel18 = New System.Windows.Forms.Label()
        Me.rdbItemReq = New System.Windows.Forms.RadioButton()
        Me.rdbNoneReq = New System.Windows.Forms.RadioButton()
        Me.fraQuestList.SuspendLayout()
        Me.DarkGroupBox2.SuspendLayout()
        Me.DarkGroupBox4.SuspendLayout()
        Me.DarkGroupBox3.SuspendLayout()
        CType(Me.nudItemRewValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudExpReward, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DarkGroupBox5.SuspendLayout()
        Me.fraTasks.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.nudAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraRequirements.SuspendLayout()
        Me.DarkGroupBox6.SuspendLayout()
        CType(Me.nudTakeAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudGiveAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraQuestList
        '
        Me.fraQuestList.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraQuestList.Controls.Add(Me.lstIndex)
        Me.fraQuestList.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraQuestList.Location = New System.Drawing.Point(4, 4)
        Me.fraQuestList.Margin = New System.Windows.Forms.Padding(4)
        Me.fraQuestList.Name = "fraQuestList"
        Me.fraQuestList.Padding = New System.Windows.Forms.Padding(4)
        Me.fraQuestList.Size = New System.Drawing.Size(283, 612)
        Me.fraQuestList.TabIndex = 0
        Me.fraQuestList.TabStop = False
        Me.fraQuestList.Text = "Lista de quests"
        '
        'lstIndex
        '
        Me.lstIndex.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lstIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstIndex.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstIndex.FormattingEnabled = True
        Me.lstIndex.ItemHeight = 16
        Me.lstIndex.Location = New System.Drawing.Point(12, 23)
        Me.lstIndex.Margin = New System.Windows.Forms.Padding(4)
        Me.lstIndex.Name = "lstIndex"
        Me.lstIndex.Size = New System.Drawing.Size(258, 578)
        Me.lstIndex.TabIndex = 1
        '
        'DarkGroupBox2
        '
        Me.DarkGroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox2.Controls.Add(Me.DarkGroupBox4)
        Me.DarkGroupBox2.Controls.Add(Me.DarkGroupBox3)
        Me.DarkGroupBox2.Controls.Add(Me.DarkLabel4)
        Me.DarkGroupBox2.Controls.Add(Me.DarkLabel3)
        Me.DarkGroupBox2.Controls.Add(Me.txtEndText)
        Me.DarkGroupBox2.Controls.Add(Me.txtProgressText)
        Me.DarkGroupBox2.Controls.Add(Me.DarkLabel2)
        Me.DarkGroupBox2.Controls.Add(Me.txtStartText)
        Me.DarkGroupBox2.Controls.Add(Me.chkQuestCancel)
        Me.DarkGroupBox2.Controls.Add(Me.chkRepeat)
        Me.DarkGroupBox2.Controls.Add(Me.txtName)
        Me.DarkGroupBox2.Controls.Add(Me.DarkLabel1)
        Me.DarkGroupBox2.Controls.Add(Me.DarkGroupBox5)
        Me.DarkGroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox2.Location = New System.Drawing.Point(295, 4)
        Me.DarkGroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox2.Name = "DarkGroupBox2"
        Me.DarkGroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox2.Size = New System.Drawing.Size(663, 564)
        Me.DarkGroupBox2.TabIndex = 1
        Me.DarkGroupBox2.TabStop = False
        Me.DarkGroupBox2.Text = "Configurações basicas"
        '
        'DarkGroupBox4
        '
        Me.DarkGroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox4.Controls.Add(Me.lstRequirements)
        Me.DarkGroupBox4.Controls.Add(Me.btnRemoveRequirement)
        Me.DarkGroupBox4.Controls.Add(Me.btnAddRequirement)
        Me.DarkGroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DarkGroupBox4.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox4.Location = New System.Drawing.Point(0, 313)
        Me.DarkGroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox4.Name = "DarkGroupBox4"
        Me.DarkGroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox4.Size = New System.Drawing.Size(324, 245)
        Me.DarkGroupBox4.TabIndex = 11
        Me.DarkGroupBox4.TabStop = False
        Me.DarkGroupBox4.Text = "Requerimentos"
        '
        'lstRequirements
        '
        Me.lstRequirements.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lstRequirements.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstRequirements.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstRequirements.FormattingEnabled = True
        Me.lstRequirements.ItemHeight = 17
        Me.lstRequirements.Location = New System.Drawing.Point(8, 23)
        Me.lstRequirements.Margin = New System.Windows.Forms.Padding(4)
        Me.lstRequirements.Name = "lstRequirements"
        Me.lstRequirements.Size = New System.Drawing.Size(308, 172)
        Me.lstRequirements.TabIndex = 2
        '
        'btnRemoveRequirement
        '
        Me.btnRemoveRequirement.Location = New System.Drawing.Point(147, 203)
        Me.btnRemoveRequirement.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRemoveRequirement.Name = "btnRemoveRequirement"
        Me.btnRemoveRequirement.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnRemoveRequirement.Size = New System.Drawing.Size(172, 35)
        Me.btnRemoveRequirement.TabIndex = 1
        Me.btnRemoveRequirement.Text = "Remover req."
        '
        'btnAddRequirement
        '
        Me.btnAddRequirement.Location = New System.Drawing.Point(5, 203)
        Me.btnAddRequirement.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddRequirement.Name = "btnAddRequirement"
        Me.btnAddRequirement.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnAddRequirement.Size = New System.Drawing.Size(136, 35)
        Me.btnAddRequirement.TabIndex = 0
        Me.btnAddRequirement.Text = "Adicionar req."
        '
        'DarkGroupBox3
        '
        Me.DarkGroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox3.Controls.Add(Me.nudItemRewValue)
        Me.DarkGroupBox3.Controls.Add(Me.DarkLabel7)
        Me.DarkGroupBox3.Controls.Add(Me.cmbItemReward)
        Me.DarkGroupBox3.Controls.Add(Me.DarkLabel6)
        Me.DarkGroupBox3.Controls.Add(Me.nudExpReward)
        Me.DarkGroupBox3.Controls.Add(Me.DarkLabel5)
        Me.DarkGroupBox3.Controls.Add(Me.btnRemoveReward)
        Me.DarkGroupBox3.Controls.Add(Me.btnAddReward)
        Me.DarkGroupBox3.Controls.Add(Me.lstRewards)
        Me.DarkGroupBox3.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox3.Location = New System.Drawing.Point(8, 176)
        Me.DarkGroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox3.Name = "DarkGroupBox3"
        Me.DarkGroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox3.Size = New System.Drawing.Size(647, 130)
        Me.DarkGroupBox3.TabIndex = 10
        Me.DarkGroupBox3.TabStop = False
        Me.DarkGroupBox3.Text = "Recompensas"
        '
        'nudItemRewValue
        '
        Me.nudItemRewValue.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudItemRewValue.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudItemRewValue.Location = New System.Drawing.Point(532, 98)
        Me.nudItemRewValue.Margin = New System.Windows.Forms.Padding(4)
        Me.nudItemRewValue.Name = "nudItemRewValue"
        Me.nudItemRewValue.Size = New System.Drawing.Size(107, 22)
        Me.nudItemRewValue.TabIndex = 8
        '
        'DarkLabel7
        '
        Me.DarkLabel7.AutoSize = True
        Me.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel7.Location = New System.Drawing.Point(437, 100)
        Me.DarkLabel7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel7.Name = "DarkLabel7"
        Me.DarkLabel7.Size = New System.Drawing.Size(86, 17)
        Me.DarkLabel7.TabIndex = 7
        Me.DarkLabel7.Text = "Quantidade:"
        '
        'cmbItemReward
        '
        Me.cmbItemReward.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbItemReward.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbItemReward.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbItemReward.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbItemReward.FormattingEnabled = True
        Me.cmbItemReward.Location = New System.Drawing.Point(485, 64)
        Me.cmbItemReward.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbItemReward.Name = "cmbItemReward"
        Me.cmbItemReward.Size = New System.Drawing.Size(152, 24)
        Me.cmbItemReward.TabIndex = 6
        '
        'DarkLabel6
        '
        Me.DarkLabel6.AutoSize = True
        Me.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel6.Location = New System.Drawing.Point(437, 68)
        Me.DarkLabel6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel6.Name = "DarkLabel6"
        Me.DarkLabel6.Size = New System.Drawing.Size(38, 17)
        Me.DarkLabel6.TabIndex = 5
        Me.DarkLabel6.Text = "Item:"
        '
        'nudExpReward
        '
        Me.nudExpReward.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudExpReward.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudExpReward.Location = New System.Drawing.Point(532, 27)
        Me.nudExpReward.Margin = New System.Windows.Forms.Padding(4)
        Me.nudExpReward.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.nudExpReward.Name = "nudExpReward"
        Me.nudExpReward.Size = New System.Drawing.Size(107, 22)
        Me.nudExpReward.TabIndex = 4
        '
        'DarkLabel5
        '
        Me.DarkLabel5.AutoSize = True
        Me.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel5.Location = New System.Drawing.Point(437, 30)
        Me.DarkLabel5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel5.Name = "DarkLabel5"
        Me.DarkLabel5.Size = New System.Drawing.Size(74, 17)
        Me.DarkLabel5.TabIndex = 3
        Me.DarkLabel5.Text = "XP ganho:"
        '
        'btnRemoveReward
        '
        Me.btnRemoveReward.Location = New System.Drawing.Point(329, 77)
        Me.btnRemoveReward.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRemoveReward.Name = "btnRemoveReward"
        Me.btnRemoveReward.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnRemoveReward.Size = New System.Drawing.Size(100, 45)
        Me.btnRemoveReward.TabIndex = 2
        Me.btnRemoveReward.Text = "Remover"
        '
        'btnAddReward
        '
        Me.btnAddReward.Location = New System.Drawing.Point(329, 23)
        Me.btnAddReward.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddReward.Name = "btnAddReward"
        Me.btnAddReward.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnAddReward.Size = New System.Drawing.Size(100, 40)
        Me.btnAddReward.TabIndex = 1
        Me.btnAddReward.Text = "Adicionar"
        '
        'lstRewards
        '
        Me.lstRewards.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lstRewards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstRewards.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstRewards.FormattingEnabled = True
        Me.lstRewards.ItemHeight = 16
        Me.lstRewards.Location = New System.Drawing.Point(8, 23)
        Me.lstRewards.Margin = New System.Windows.Forms.Padding(4)
        Me.lstRewards.Name = "lstRewards"
        Me.lstRewards.Size = New System.Drawing.Size(313, 98)
        Me.lstRewards.TabIndex = 0
        '
        'DarkLabel4
        '
        Me.DarkLabel4.AutoSize = True
        Me.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel4.Location = New System.Drawing.Point(430, 69)
        Me.DarkLabel4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel4.Name = "DarkLabel4"
        Me.DarkLabel4.Size = New System.Drawing.Size(116, 17)
        Me.DarkLabel4.TabIndex = 9
        Me.DarkLabel4.Text = "Texto ao finalizar"
        '
        'DarkLabel3
        '
        Me.DarkLabel3.AutoSize = True
        Me.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel3.Location = New System.Drawing.Point(217, 69)
        Me.DarkLabel3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel3.Name = "DarkLabel3"
        Me.DarkLabel3.Size = New System.Drawing.Size(134, 17)
        Me.DarkLabel3.TabIndex = 8
        Me.DarkLabel3.Text = "Texto em progresso"
        '
        'txtEndText
        '
        Me.txtEndText.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtEndText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEndText.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtEndText.Location = New System.Drawing.Point(435, 89)
        Me.txtEndText.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEndText.Multiline = True
        Me.txtEndText.Name = "txtEndText"
        Me.txtEndText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEndText.Size = New System.Drawing.Size(205, 80)
        Me.txtEndText.TabIndex = 7
        '
        'txtProgressText
        '
        Me.txtProgressText.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtProgressText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProgressText.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtProgressText.Location = New System.Drawing.Point(221, 89)
        Me.txtProgressText.Margin = New System.Windows.Forms.Padding(4)
        Me.txtProgressText.Multiline = True
        Me.txtProgressText.Name = "txtProgressText"
        Me.txtProgressText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtProgressText.Size = New System.Drawing.Size(205, 80)
        Me.txtProgressText.TabIndex = 6
        '
        'DarkLabel2
        '
        Me.DarkLabel2.AutoSize = True
        Me.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel2.Location = New System.Drawing.Point(8, 69)
        Me.DarkLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel2.Name = "DarkLabel2"
        Me.DarkLabel2.Size = New System.Drawing.Size(134, 17)
        Me.DarkLabel2.TabIndex = 5
        Me.DarkLabel2.Text = "Texto de introdução"
        '
        'txtStartText
        '
        Me.txtStartText.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtStartText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStartText.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtStartText.Location = New System.Drawing.Point(8, 89)
        Me.txtStartText.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStartText.Multiline = True
        Me.txtStartText.Name = "txtStartText"
        Me.txtStartText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStartText.Size = New System.Drawing.Size(205, 80)
        Me.txtStartText.TabIndex = 4
        '
        'chkQuestCancel
        '
        Me.chkQuestCancel.AutoSize = True
        Me.chkQuestCancel.Location = New System.Drawing.Point(496, 25)
        Me.chkQuestCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.chkQuestCancel.Name = "chkQuestCancel"
        Me.chkQuestCancel.Size = New System.Drawing.Size(133, 21)
        Me.chkQuestCancel.TabIndex = 3
        Me.chkQuestCancel.Text = "Pode cancelar ?"
        '
        'chkRepeat
        '
        Me.chkRepeat.AutoSize = True
        Me.chkRepeat.Location = New System.Drawing.Point(372, 25)
        Me.chkRepeat.Margin = New System.Windows.Forms.Padding(4)
        Me.chkRepeat.Name = "chkRepeat"
        Me.chkRepeat.Size = New System.Drawing.Size(84, 21)
        Me.chkRepeat.TabIndex = 2
        Me.chkRepeat.Text = "Repete?"
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtName.Location = New System.Drawing.Point(130, 23)
        Me.txtName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(234, 22)
        Me.txtName.TabIndex = 1
        '
        'DarkLabel1
        '
        Me.DarkLabel1.AutoSize = True
        Me.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel1.Location = New System.Drawing.Point(8, 26)
        Me.DarkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel1.Name = "DarkLabel1"
        Me.DarkLabel1.Size = New System.Drawing.Size(115, 17)
        Me.DarkLabel1.TabIndex = 0
        Me.DarkLabel1.Text = "Nome da Tarefa:"
        '
        'DarkGroupBox5
        '
        Me.DarkGroupBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox5.Controls.Add(Me.btnRemoveTask)
        Me.DarkGroupBox5.Controls.Add(Me.btnAddTask)
        Me.DarkGroupBox5.Controls.Add(Me.lstTasks)
        Me.DarkGroupBox5.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox5.Location = New System.Drawing.Point(332, 314)
        Me.DarkGroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox5.Name = "DarkGroupBox5"
        Me.DarkGroupBox5.Padding = New System.Windows.Forms.Padding(4)
        Me.DarkGroupBox5.Size = New System.Drawing.Size(325, 242)
        Me.DarkGroupBox5.TabIndex = 12
        Me.DarkGroupBox5.TabStop = False
        Me.DarkGroupBox5.Text = "Tarefas"
        '
        'btnRemoveTask
        '
        Me.btnRemoveTask.Location = New System.Drawing.Point(212, 199)
        Me.btnRemoveTask.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRemoveTask.Name = "btnRemoveTask"
        Me.btnRemoveTask.Padding = New System.Windows.Forms.Padding(4)
        Me.btnRemoveTask.Size = New System.Drawing.Size(105, 35)
        Me.btnRemoveTask.TabIndex = 5
        Me.btnRemoveTask.Text = "Remover task"
        '
        'btnAddTask
        '
        Me.btnAddTask.Location = New System.Drawing.Point(8, 199)
        Me.btnAddTask.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddTask.Name = "btnAddTask"
        Me.btnAddTask.Padding = New System.Windows.Forms.Padding(4)
        Me.btnAddTask.Size = New System.Drawing.Size(99, 35)
        Me.btnAddTask.TabIndex = 4
        Me.btnAddTask.Text = "Adicionar task"
        '
        'lstTasks
        '
        Me.lstTasks.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lstTasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstTasks.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstTasks.FormattingEnabled = True
        Me.lstTasks.ItemHeight = 16
        Me.lstTasks.Location = New System.Drawing.Point(8, 22)
        Me.lstTasks.Margin = New System.Windows.Forms.Padding(4)
        Me.lstTasks.Name = "lstTasks"
        Me.lstTasks.Size = New System.Drawing.Size(305, 162)
        Me.lstTasks.TabIndex = 3
        '
        'DarkLabel8
        '
        Me.DarkLabel8.AutoSize = True
        Me.DarkLabel8.ForeColor = System.Drawing.Color.Red
        Me.DarkLabel8.Location = New System.Drawing.Point(295, 571)
        Me.DarkLabel8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel8.Name = "DarkLabel8"
        Me.DarkLabel8.Size = New System.Drawing.Size(313, 17)
        Me.DarkLabel8.TabIndex = 2
        Me.DarkLabel8.Text = "Use /questreset # para resetar a quest pra teste"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(738, 574)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnSave.Size = New System.Drawing.Size(100, 37)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Salvar"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(845, 574)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnCancel.Size = New System.Drawing.Size(100, 37)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancelar"
        '
        'fraTasks
        '
        Me.fraTasks.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraTasks.Controls.Add(Me.btnCancelTask)
        Me.fraTasks.Controls.Add(Me.btnSaveTask)
        Me.fraTasks.Controls.Add(Me.Panel2)
        Me.fraTasks.Controls.Add(Me.Panel1)
        Me.fraTasks.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraTasks.Location = New System.Drawing.Point(965, 4)
        Me.fraTasks.Margin = New System.Windows.Forms.Padding(4)
        Me.fraTasks.Name = "fraTasks"
        Me.fraTasks.Padding = New System.Windows.Forms.Padding(4)
        Me.fraTasks.Size = New System.Drawing.Size(574, 612)
        Me.fraTasks.TabIndex = 5
        Me.fraTasks.TabStop = False
        Me.fraTasks.Text = "Tarefas"
        '
        'btnCancelTask
        '
        Me.btnCancelTask.Location = New System.Drawing.Point(124, 276)
        Me.btnCancelTask.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelTask.Name = "btnCancelTask"
        Me.btnCancelTask.Padding = New System.Windows.Forms.Padding(4)
        Me.btnCancelTask.Size = New System.Drawing.Size(100, 39)
        Me.btnCancelTask.TabIndex = 3
        Me.btnCancelTask.Text = "Cancelar"
        '
        'btnSaveTask
        '
        Me.btnSaveTask.Location = New System.Drawing.Point(5, 276)
        Me.btnSaveTask.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSaveTask.Name = "btnSaveTask"
        Me.btnSaveTask.Padding = New System.Windows.Forms.Padding(4)
        Me.btnSaveTask.Size = New System.Drawing.Size(98, 39)
        Me.btnSaveTask.TabIndex = 2
        Me.btnSaveTask.Text = "Salvar"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.optTask7)
        Me.Panel2.Controls.Add(Me.optTask6)
        Me.Panel2.Controls.Add(Me.optTask5)
        Me.Panel2.Controls.Add(Me.optTask4)
        Me.Panel2.Controls.Add(Me.optTask3)
        Me.Panel2.Controls.Add(Me.optTask2)
        Me.Panel2.Controls.Add(Me.DarkLabel16)
        Me.Panel2.Controls.Add(Me.optTask1)
        Me.Panel2.Controls.Add(Me.optTask0)
        Me.Panel2.Location = New System.Drawing.Point(228, 15)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(137, 158)
        Me.Panel2.TabIndex = 1
        '
        'optTask7
        '
        Me.optTask7.AutoSize = True
        Me.optTask7.Location = New System.Drawing.Point(5, 140)
        Me.optTask7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.optTask7.Name = "optTask7"
        Me.optTask7.Size = New System.Drawing.Size(144, 21)
        Me.optTask7.TabIndex = 8
        Me.optTask7.TabStop = True
        Me.optTask7.Text = "Pegar item do npc"
        '
        'optTask6
        '
        Me.optTask6.AutoSize = True
        Me.optTask6.Location = New System.Drawing.Point(5, 122)
        Me.optTask6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.optTask6.Name = "optTask6"
        Me.optTask6.Size = New System.Drawing.Size(133, 21)
        Me.optTask6.TabIndex = 7
        Me.optTask6.TabStop = True
        Me.optTask6.Text = "Coletar recursos"
        '
        'optTask5
        '
        Me.optTask5.AutoSize = True
        Me.optTask5.Location = New System.Drawing.Point(5, 103)
        Me.optTask5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.optTask5.Name = "optTask5"
        Me.optTask5.Size = New System.Drawing.Size(129, 21)
        Me.optTask5.TabIndex = 6
        Me.optTask5.TabStop = True
        Me.optTask5.Text = "Dar item ao npc"
        '
        'optTask4
        '
        Me.optTask4.AutoSize = True
        Me.optTask4.Location = New System.Drawing.Point(5, 85)
        Me.optTask4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.optTask4.Name = "optTask4"
        Me.optTask4.Size = New System.Drawing.Size(111, 21)
        Me.optTask4.TabIndex = 5
        Me.optTask4.TabStop = True
        Me.optTask4.Text = "Ir Até x mapa"
        '
        'optTask3
        '
        Me.optTask3.AutoSize = True
        Me.optTask3.Location = New System.Drawing.Point(5, 66)
        Me.optTask3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.optTask3.Name = "optTask3"
        Me.optTask3.Size = New System.Drawing.Size(118, 21)
        Me.optTask3.TabIndex = 4
        Me.optTask3.TabStop = True
        Me.optTask3.Text = "Falar com npc"
        '
        'optTask2
        '
        Me.optTask2.AutoSize = True
        Me.optTask2.Location = New System.Drawing.Point(5, 48)
        Me.optTask2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.optTask2.Name = "optTask2"
        Me.optTask2.Size = New System.Drawing.Size(108, 21)
        Me.optTask2.TabIndex = 3
        Me.optTask2.TabStop = True
        Me.optTask2.Text = "Coletar itens"
        '
        'DarkLabel16
        '
        Me.DarkLabel16.AutoSize = True
        Me.DarkLabel16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel16.Location = New System.Drawing.Point(3, 20)
        Me.DarkLabel16.Name = "DarkLabel16"
        Me.DarkLabel16.Size = New System.Drawing.Size(238, 17)
        Me.DarkLabel16.TabIndex = 2
        Me.DarkLabel16.Text = "----------------------------------------------"
        '
        'optTask1
        '
        Me.optTask1.AutoSize = True
        Me.optTask1.Location = New System.Drawing.Point(5, 30)
        Me.optTask1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.optTask1.Name = "optTask1"
        Me.optTask1.Size = New System.Drawing.Size(92, 21)
        Me.optTask1.TabIndex = 1
        Me.optTask1.TabStop = True
        Me.optTask1.Text = "Matar npc"
        '
        'optTask0
        '
        Me.optTask0.AutoSize = True
        Me.optTask0.Location = New System.Drawing.Point(5, 4)
        Me.optTask0.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.optTask0.Name = "optTask0"
        Me.optTask0.Size = New System.Drawing.Size(63, 21)
        Me.optTask0.TabIndex = 0
        Me.optTask0.TabStop = True
        Me.optTask0.Text = "Nada"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmbResource)
        Me.Panel1.Controls.Add(Me.cmbMap)
        Me.Panel1.Controls.Add(Me.cmbItem)
        Me.Panel1.Controls.Add(Me.cmbNpc)
        Me.Panel1.Controls.Add(Me.DarkLabel17)
        Me.Panel1.Controls.Add(Me.lblTaskNum)
        Me.Panel1.Controls.Add(Me.nudAmount)
        Me.Panel1.Controls.Add(Me.DarkLabel15)
        Me.Panel1.Controls.Add(Me.DarkLabel14)
        Me.Panel1.Controls.Add(Me.DarkLabel13)
        Me.Panel1.Controls.Add(Me.DarkLabel12)
        Me.Panel1.Controls.Add(Me.DarkLabel11)
        Me.Panel1.Controls.Add(Me.chkEnd)
        Me.Panel1.Controls.Add(Me.txtTaskSpeech)
        Me.Panel1.Controls.Add(Me.DarkLabel10)
        Me.Panel1.Controls.Add(Me.txtTaskLog)
        Me.Panel1.Controls.Add(Me.DarkLabel9)
        Me.Panel1.Location = New System.Drawing.Point(5, 15)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(218, 256)
        Me.Panel1.TabIndex = 0
        '
        'cmbResource
        '
        Me.cmbResource.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbResource.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbResource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbResource.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbResource.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbResource.FormattingEnabled = True
        Me.cmbResource.Location = New System.Drawing.Point(55, 159)
        Me.cmbResource.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbResource.Name = "cmbResource"
        Me.cmbResource.Size = New System.Drawing.Size(108, 23)
        Me.cmbResource.TabIndex = 20
        '
        'cmbMap
        '
        Me.cmbMap.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbMap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMap.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbMap.FormattingEnabled = True
        Me.cmbMap.Location = New System.Drawing.Point(55, 138)
        Me.cmbMap.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbMap.Name = "cmbMap"
        Me.cmbMap.Size = New System.Drawing.Size(108, 23)
        Me.cmbMap.TabIndex = 19
        '
        'cmbItem
        '
        Me.cmbItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbItem.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbItem.FormattingEnabled = True
        Me.cmbItem.Location = New System.Drawing.Point(55, 118)
        Me.cmbItem.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbItem.Name = "cmbItem"
        Me.cmbItem.Size = New System.Drawing.Size(108, 23)
        Me.cmbItem.TabIndex = 18
        '
        'cmbNpc
        '
        Me.cmbNpc.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbNpc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbNpc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNpc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbNpc.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbNpc.FormattingEnabled = True
        Me.cmbNpc.Location = New System.Drawing.Point(55, 97)
        Me.cmbNpc.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbNpc.Name = "cmbNpc"
        Me.cmbNpc.Size = New System.Drawing.Size(108, 23)
        Me.cmbNpc.TabIndex = 17
        '
        'DarkLabel17
        '
        Me.DarkLabel17.AutoSize = True
        Me.DarkLabel17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel17.Location = New System.Drawing.Point(6, 178)
        Me.DarkLabel17.Name = "DarkLabel17"
        Me.DarkLabel17.Size = New System.Drawing.Size(383, 17)
        Me.DarkLabel17.TabIndex = 16
        Me.DarkLabel17.Text = "---------------------------------------------------------------------------"
        '
        'lblTaskNum
        '
        Me.lblTaskNum.AutoSize = True
        Me.lblTaskNum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblTaskNum.Location = New System.Drawing.Point(3, 238)
        Me.lblTaskNum.Name = "lblTaskNum"
        Me.lblTaskNum.Size = New System.Drawing.Size(119, 17)
        Me.lblTaskNum.TabIndex = 15
        Me.lblTaskNum.Text = "Numero da tarefa"
        '
        'nudAmount
        '
        Me.nudAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudAmount.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudAmount.Location = New System.Drawing.Point(56, 191)
        Me.nudAmount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.nudAmount.Name = "nudAmount"
        Me.nudAmount.Size = New System.Drawing.Size(107, 22)
        Me.nudAmount.TabIndex = 14
        '
        'DarkLabel15
        '
        Me.DarkLabel15.AutoSize = True
        Me.DarkLabel15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel15.Location = New System.Drawing.Point(3, 193)
        Me.DarkLabel15.Name = "DarkLabel15"
        Me.DarkLabel15.Size = New System.Drawing.Size(39, 17)
        Me.DarkLabel15.TabIndex = 13
        Me.DarkLabel15.Text = "Qnt :"
        '
        'DarkLabel14
        '
        Me.DarkLabel14.AutoSize = True
        Me.DarkLabel14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel14.Location = New System.Drawing.Point(3, 162)
        Me.DarkLabel14.Name = "DarkLabel14"
        Me.DarkLabel14.Size = New System.Drawing.Size(76, 17)
        Me.DarkLabel14.TabIndex = 11
        Me.DarkLabel14.Text = "Recursos :"
        '
        'DarkLabel13
        '
        Me.DarkLabel13.AutoSize = True
        Me.DarkLabel13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel13.Location = New System.Drawing.Point(3, 141)
        Me.DarkLabel13.Name = "DarkLabel13"
        Me.DarkLabel13.Size = New System.Drawing.Size(47, 17)
        Me.DarkLabel13.TabIndex = 9
        Me.DarkLabel13.Text = "Mapa:"
        '
        'DarkLabel12
        '
        Me.DarkLabel12.AutoSize = True
        Me.DarkLabel12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel12.Location = New System.Drawing.Point(3, 120)
        Me.DarkLabel12.Name = "DarkLabel12"
        Me.DarkLabel12.Size = New System.Drawing.Size(38, 17)
        Me.DarkLabel12.TabIndex = 7
        Me.DarkLabel12.Text = "Item:"
        '
        'DarkLabel11
        '
        Me.DarkLabel11.AutoSize = True
        Me.DarkLabel11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel11.Location = New System.Drawing.Point(3, 99)
        Me.DarkLabel11.Name = "DarkLabel11"
        Me.DarkLabel11.Size = New System.Drawing.Size(37, 17)
        Me.DarkLabel11.TabIndex = 5
        Me.DarkLabel11.Text = "Npc:"
        '
        'chkEnd
        '
        Me.chkEnd.AutoSize = True
        Me.chkEnd.ForeColor = System.Drawing.Color.Lime
        Me.chkEnd.Location = New System.Drawing.Point(3, 69)
        Me.chkEnd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkEnd.Name = "chkEnd"
        Me.chkEnd.Size = New System.Drawing.Size(175, 21)
        Me.chkEnd.TabIndex = 4
        Me.chkEnd.Text = "Terminar quest agora?"
        '
        'txtTaskSpeech
        '
        Me.txtTaskSpeech.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtTaskSpeech.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaskSpeech.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtTaskSpeech.Location = New System.Drawing.Point(3, 48)
        Me.txtTaskSpeech.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTaskSpeech.Name = "txtTaskSpeech"
        Me.txtTaskSpeech.Size = New System.Drawing.Size(210, 22)
        Me.txtTaskSpeech.TabIndex = 3
        '
        'DarkLabel10
        '
        Me.DarkLabel10.AutoSize = True
        Me.DarkLabel10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel10.Location = New System.Drawing.Point(3, 35)
        Me.DarkLabel10.Name = "DarkLabel10"
        Me.DarkLabel10.Size = New System.Drawing.Size(96, 17)
        Me.DarkLabel10.TabIndex = 2
        Me.DarkLabel10.Text = "Fala da tarefa"
        '
        'txtTaskLog
        '
        Me.txtTaskLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtTaskLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaskLog.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtTaskLog.Location = New System.Drawing.Point(3, 17)
        Me.txtTaskLog.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTaskLog.Name = "txtTaskLog"
        Me.txtTaskLog.Size = New System.Drawing.Size(210, 22)
        Me.txtTaskLog.TabIndex = 1
        '
        'DarkLabel9
        '
        Me.DarkLabel9.AutoSize = True
        Me.DarkLabel9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel9.Location = New System.Drawing.Point(3, 4)
        Me.DarkLabel9.Name = "DarkLabel9"
        Me.DarkLabel9.Size = New System.Drawing.Size(93, 17)
        Me.DarkLabel9.TabIndex = 0
        Me.DarkLabel9.Text = "Log da tarefa"
        '
        'fraRequirements
        '
        Me.fraRequirements.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraRequirements.Controls.Add(Me.DarkGroupBox6)
        Me.fraRequirements.Controls.Add(Me.cmbClassReq)
        Me.fraRequirements.Controls.Add(Me.DarkLabel20)
        Me.fraRequirements.Controls.Add(Me.rdbClassReq)
        Me.fraRequirements.Controls.Add(Me.cmbQuestReq)
        Me.fraRequirements.Controls.Add(Me.DarkLabel19)
        Me.fraRequirements.Controls.Add(Me.rdbQuestReq)
        Me.fraRequirements.Controls.Add(Me.cmbItemReq)
        Me.fraRequirements.Controls.Add(Me.DarkLabel18)
        Me.fraRequirements.Controls.Add(Me.rdbItemReq)
        Me.fraRequirements.Controls.Add(Me.rdbNoneReq)
        Me.fraRequirements.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraRequirements.Location = New System.Drawing.Point(959, 11)
        Me.fraRequirements.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.fraRequirements.Name = "fraRequirements"
        Me.fraRequirements.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.fraRequirements.Size = New System.Drawing.Size(383, 398)
        Me.fraRequirements.TabIndex = 6
        Me.fraRequirements.TabStop = False
        Me.fraRequirements.Text = "Requerimentos"
        Me.fraRequirements.Visible = False
        '
        'DarkGroupBox6
        '
        Me.DarkGroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox6.Controls.Add(Me.btnRequirementCancel)
        Me.DarkGroupBox6.Controls.Add(Me.btnRequirementSave)
        Me.DarkGroupBox6.Controls.Add(Me.nudTakeAmount)
        Me.DarkGroupBox6.Controls.Add(Me.DarkLabel23)
        Me.DarkGroupBox6.Controls.Add(Me.cmbEndItem)
        Me.DarkGroupBox6.Controls.Add(Me.DarkLabel24)
        Me.DarkGroupBox6.Controls.Add(Me.nudGiveAmount)
        Me.DarkGroupBox6.Controls.Add(Me.DarkLabel22)
        Me.DarkGroupBox6.Controls.Add(Me.cmbStartItem)
        Me.DarkGroupBox6.Controls.Add(Me.DarkLabel21)
        Me.DarkGroupBox6.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox6.Location = New System.Drawing.Point(5, 127)
        Me.DarkGroupBox6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DarkGroupBox6.Name = "DarkGroupBox6"
        Me.DarkGroupBox6.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DarkGroupBox6.Size = New System.Drawing.Size(300, 230)
        Me.DarkGroupBox6.TabIndex = 10
        Me.DarkGroupBox6.TabStop = False
        Me.DarkGroupBox6.Text = "Itens necessarios para a Tarefa"
        '
        'btnRequirementCancel
        '
        Me.btnRequirementCancel.Location = New System.Drawing.Point(215, 188)
        Me.btnRequirementCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRequirementCancel.Name = "btnRequirementCancel"
        Me.btnRequirementCancel.Padding = New System.Windows.Forms.Padding(4)
        Me.btnRequirementCancel.Size = New System.Drawing.Size(80, 37)
        Me.btnRequirementCancel.TabIndex = 9
        Me.btnRequirementCancel.Text = "Cancelar"
        '
        'btnRequirementSave
        '
        Me.btnRequirementSave.Location = New System.Drawing.Point(142, 187)
        Me.btnRequirementSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRequirementSave.Name = "btnRequirementSave"
        Me.btnRequirementSave.Padding = New System.Windows.Forms.Padding(4)
        Me.btnRequirementSave.Size = New System.Drawing.Size(67, 37)
        Me.btnRequirementSave.TabIndex = 8
        Me.btnRequirementSave.Text = "Salvar"
        '
        'nudTakeAmount
        '
        Me.nudTakeAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudTakeAmount.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudTakeAmount.Location = New System.Drawing.Point(233, 58)
        Me.nudTakeAmount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.nudTakeAmount.Name = "nudTakeAmount"
        Me.nudTakeAmount.Size = New System.Drawing.Size(62, 22)
        Me.nudTakeAmount.TabIndex = 7
        '
        'DarkLabel23
        '
        Me.DarkLabel23.AutoSize = True
        Me.DarkLabel23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel23.Location = New System.Drawing.Point(187, 60)
        Me.DarkLabel23.Name = "DarkLabel23"
        Me.DarkLabel23.Size = New System.Drawing.Size(47, 17)
        Me.DarkLabel23.TabIndex = 6
        Me.DarkLabel23.Text = "Qntd.:"
        '
        'cmbEndItem
        '
        Me.cmbEndItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbEndItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEndItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbEndItem.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbEndItem.FormattingEnabled = True
        Me.cmbEndItem.Location = New System.Drawing.Point(60, 58)
        Me.cmbEndItem.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbEndItem.Name = "cmbEndItem"
        Me.cmbEndItem.Size = New System.Drawing.Size(122, 24)
        Me.cmbEndItem.TabIndex = 5
        '
        'DarkLabel24
        '
        Me.DarkLabel24.AutoSize = True
        Me.DarkLabel24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel24.Location = New System.Drawing.Point(5, 60)
        Me.DarkLabel24.Name = "DarkLabel24"
        Me.DarkLabel24.Size = New System.Drawing.Size(83, 17)
        Me.DarkLabel24.TabIndex = 4
        Me.DarkLabel24.Text = "Tomar item:"
        '
        'nudGiveAmount
        '
        Me.nudGiveAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudGiveAmount.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudGiveAmount.Location = New System.Drawing.Point(233, 23)
        Me.nudGiveAmount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.nudGiveAmount.Name = "nudGiveAmount"
        Me.nudGiveAmount.Size = New System.Drawing.Size(62, 22)
        Me.nudGiveAmount.TabIndex = 3
        '
        'DarkLabel22
        '
        Me.DarkLabel22.AutoSize = True
        Me.DarkLabel22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel22.Location = New System.Drawing.Point(187, 25)
        Me.DarkLabel22.Name = "DarkLabel22"
        Me.DarkLabel22.Size = New System.Drawing.Size(39, 17)
        Me.DarkLabel22.TabIndex = 2
        Me.DarkLabel22.Text = "Qtd.:"
        '
        'cmbStartItem
        '
        Me.cmbStartItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbStartItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStartItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbStartItem.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbStartItem.FormattingEnabled = True
        Me.cmbStartItem.Location = New System.Drawing.Point(60, 22)
        Me.cmbStartItem.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbStartItem.Name = "cmbStartItem"
        Me.cmbStartItem.Size = New System.Drawing.Size(122, 24)
        Me.cmbStartItem.TabIndex = 1
        '
        'DarkLabel21
        '
        Me.DarkLabel21.AutoSize = True
        Me.DarkLabel21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel21.Location = New System.Drawing.Point(5, 25)
        Me.DarkLabel21.Name = "DarkLabel21"
        Me.DarkLabel21.Size = New System.Drawing.Size(65, 17)
        Me.DarkLabel21.TabIndex = 0
        Me.DarkLabel21.Text = "Dar item:"
        '
        'cmbClassReq
        '
        Me.cmbClassReq.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbClassReq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClassReq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbClassReq.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbClassReq.FormattingEnabled = True
        Me.cmbClassReq.Location = New System.Drawing.Point(164, 102)
        Me.cmbClassReq.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbClassReq.Name = "cmbClassReq"
        Me.cmbClassReq.Size = New System.Drawing.Size(142, 24)
        Me.cmbClassReq.TabIndex = 9
        '
        'DarkLabel20
        '
        Me.DarkLabel20.AutoSize = True
        Me.DarkLabel20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel20.Location = New System.Drawing.Point(71, 104)
        Me.DarkLabel20.Name = "DarkLabel20"
        Me.DarkLabel20.Size = New System.Drawing.Size(131, 17)
        Me.DarkLabel20.TabIndex = 8
        Me.DarkLabel20.Text = "Classe necessária :"
        '
        'rdbClassReq
        '
        Me.rdbClassReq.AutoSize = True
        Me.rdbClassReq.Location = New System.Drawing.Point(9, 102)
        Me.rdbClassReq.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rdbClassReq.Name = "rdbClassReq"
        Me.rdbClassReq.Size = New System.Drawing.Size(71, 21)
        Me.rdbClassReq.TabIndex = 7
        Me.rdbClassReq.TabStop = True
        Me.rdbClassReq.Text = "Classe"
        '
        'cmbQuestReq
        '
        Me.cmbQuestReq.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbQuestReq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbQuestReq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbQuestReq.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbQuestReq.FormattingEnabled = True
        Me.cmbQuestReq.Location = New System.Drawing.Point(164, 73)
        Me.cmbQuestReq.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbQuestReq.Name = "cmbQuestReq"
        Me.cmbQuestReq.Size = New System.Drawing.Size(142, 24)
        Me.cmbQuestReq.TabIndex = 6
        '
        'DarkLabel19
        '
        Me.DarkLabel19.AutoSize = True
        Me.DarkLabel19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel19.Location = New System.Drawing.Point(71, 75)
        Me.DarkLabel19.Name = "DarkLabel19"
        Me.DarkLabel19.Size = New System.Drawing.Size(127, 17)
        Me.DarkLabel19.TabIndex = 5
        Me.DarkLabel19.Text = "Tarefa necessária:"
        '
        'rdbQuestReq
        '
        Me.rdbQuestReq.AutoSize = True
        Me.rdbQuestReq.Location = New System.Drawing.Point(9, 74)
        Me.rdbQuestReq.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rdbQuestReq.Name = "rdbQuestReq"
        Me.rdbQuestReq.Size = New System.Drawing.Size(71, 21)
        Me.rdbQuestReq.TabIndex = 4
        Me.rdbQuestReq.TabStop = True
        Me.rdbQuestReq.Text = "Tarefa"
        '
        'cmbItemReq
        '
        Me.cmbItemReq.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbItemReq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbItemReq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbItemReq.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbItemReq.FormattingEnabled = True
        Me.cmbItemReq.Location = New System.Drawing.Point(164, 44)
        Me.cmbItemReq.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbItemReq.Name = "cmbItemReq"
        Me.cmbItemReq.Size = New System.Drawing.Size(142, 24)
        Me.cmbItemReq.TabIndex = 3
        '
        'DarkLabel18
        '
        Me.DarkLabel18.AutoSize = True
        Me.DarkLabel18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel18.Location = New System.Drawing.Point(71, 46)
        Me.DarkLabel18.Name = "DarkLabel18"
        Me.DarkLabel18.Size = New System.Drawing.Size(111, 17)
        Me.DarkLabel18.TabIndex = 2
        Me.DarkLabel18.Text = "Item necessário:"
        '
        'rdbItemReq
        '
        Me.rdbItemReq.AutoSize = True
        Me.rdbItemReq.Location = New System.Drawing.Point(9, 45)
        Me.rdbItemReq.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rdbItemReq.Name = "rdbItemReq"
        Me.rdbItemReq.Size = New System.Drawing.Size(55, 21)
        Me.rdbItemReq.TabIndex = 1
        Me.rdbItemReq.TabStop = True
        Me.rdbItemReq.Text = "Item"
        '
        'rdbNoneReq
        '
        Me.rdbNoneReq.AutoSize = True
        Me.rdbNoneReq.Location = New System.Drawing.Point(9, 17)
        Me.rdbNoneReq.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rdbNoneReq.Name = "rdbNoneReq"
        Me.rdbNoneReq.Size = New System.Drawing.Size(82, 21)
        Me.rdbNoneReq.TabIndex = 0
        Me.rdbNoneReq.TabStop = True
        Me.rdbNoneReq.Text = "Nenhum"
        '
        'frmEditor_Quest
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1544, 624)
        Me.ControlBox = False
        Me.Controls.Add(Me.fraRequirements)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.DarkLabel8)
        Me.Controls.Add(Me.DarkGroupBox2)
        Me.Controls.Add(Me.fraQuestList)
        Me.Controls.Add(Me.fraTasks)
        Me.ForeColor = System.Drawing.Color.Gainsboro
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmEditor_Quest"
        Me.Text = "Editor de Tarefas"
        Me.fraQuestList.ResumeLayout(False)
        Me.DarkGroupBox2.ResumeLayout(False)
        Me.DarkGroupBox2.PerformLayout()
        Me.DarkGroupBox4.ResumeLayout(False)
        Me.DarkGroupBox3.ResumeLayout(False)
        Me.DarkGroupBox3.PerformLayout()
        CType(Me.nudItemRewValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudExpReward, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DarkGroupBox5.ResumeLayout(False)
        Me.fraTasks.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.nudAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraRequirements.ResumeLayout(False)
        Me.fraRequirements.PerformLayout()
        Me.DarkGroupBox6.ResumeLayout(False)
        Me.DarkGroupBox6.PerformLayout()
        CType(Me.nudTakeAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudGiveAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fraQuestList As GroupBox
    Friend WithEvents lstIndex As Windows.Forms.ListBox
    Friend WithEvents DarkGroupBox2 As GroupBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents DarkLabel1 As Label
    Friend WithEvents chkRepeat As CheckBox
    Friend WithEvents chkQuestCancel As CheckBox
    Friend WithEvents txtStartText As TextBox
    Friend WithEvents DarkLabel2 As Label
    Friend WithEvents txtEndText As TextBox
    Friend WithEvents txtProgressText As TextBox
    Friend WithEvents DarkLabel3 As Label
    Friend WithEvents DarkLabel4 As Label
    Friend WithEvents DarkGroupBox3 As GroupBox
    Friend WithEvents lstRewards As Windows.Forms.ListBox
    Friend WithEvents btnAddReward As Button
    Friend WithEvents btnRemoveReward As Button
    Friend WithEvents nudExpReward As NumericUpDown
    Friend WithEvents DarkLabel5 As Label
    Friend WithEvents nudItemRewValue As NumericUpDown
    Friend WithEvents DarkLabel7 As Label
    Friend WithEvents cmbItemReward As ComboBox
    Friend WithEvents DarkLabel6 As Label
    Friend WithEvents DarkGroupBox4 As GroupBox
    Friend WithEvents DarkGroupBox5 As GroupBox
    Friend WithEvents btnAddRequirement As Button
    Friend WithEvents btnRemoveRequirement As Button
    Friend WithEvents lstRequirements As Windows.Forms.ListBox
    Friend WithEvents lstTasks As Windows.Forms.ListBox
    Friend WithEvents btnRemoveTask As Button
    Friend WithEvents btnAddTask As Button
    Friend WithEvents DarkLabel8 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents fraTasks As GroupBox
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents txtTaskLog As TextBox
    Friend WithEvents DarkLabel9 As Label
    Friend WithEvents txtTaskSpeech As TextBox
    Friend WithEvents DarkLabel10 As Label
    Friend WithEvents chkEnd As CheckBox
    Friend WithEvents DarkLabel11 As Label
    Friend WithEvents DarkLabel13 As Label
    Friend WithEvents DarkLabel12 As Label
    Friend WithEvents DarkLabel14 As Label
    Friend WithEvents nudAmount As NumericUpDown
    Friend WithEvents DarkLabel15 As Label
    Friend WithEvents lblTaskNum As Label
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents optTask0 As RadioButton
    Friend WithEvents DarkLabel16 As Label
    Friend WithEvents optTask1 As RadioButton
    Friend WithEvents optTask2 As RadioButton
    Friend WithEvents optTask3 As RadioButton
    Friend WithEvents optTask4 As RadioButton
    Friend WithEvents optTask5 As RadioButton
    Friend WithEvents optTask6 As RadioButton
    Friend WithEvents optTask7 As RadioButton
    Friend WithEvents DarkLabel17 As Label
    Friend WithEvents fraRequirements As GroupBox
    Friend WithEvents rdbNoneReq As RadioButton
    Friend WithEvents rdbItemReq As RadioButton
    Friend WithEvents cmbItemReq As ComboBox
    Friend WithEvents DarkLabel18 As Label
    Friend WithEvents cmbQuestReq As ComboBox
    Friend WithEvents DarkLabel19 As Label
    Friend WithEvents rdbQuestReq As RadioButton
    Friend WithEvents cmbClassReq As ComboBox
    Friend WithEvents DarkLabel20 As Label
    Friend WithEvents rdbClassReq As RadioButton
    Friend WithEvents DarkGroupBox6 As GroupBox
    Friend WithEvents cmbStartItem As ComboBox
    Friend WithEvents DarkLabel21 As Label
    Friend WithEvents nudGiveAmount As NumericUpDown
    Friend WithEvents DarkLabel22 As Label
    Friend WithEvents nudTakeAmount As NumericUpDown
    Friend WithEvents DarkLabel23 As Label
    Friend WithEvents cmbEndItem As ComboBox
    Friend WithEvents DarkLabel24 As Label
    Friend WithEvents btnRequirementSave As Button
    Friend WithEvents btnRequirementCancel As Button
    Friend WithEvents btnCancelTask As Button
    Friend WithEvents btnSaveTask As Button
    Friend WithEvents cmbResource As ComboBox
    Friend WithEvents cmbMap As ComboBox
    Friend WithEvents cmbItem As ComboBox
    Friend WithEvents cmbNpc As ComboBox
End Class
