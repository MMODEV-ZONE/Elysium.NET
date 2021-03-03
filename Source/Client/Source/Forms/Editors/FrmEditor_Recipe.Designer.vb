<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_Recipe
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
        Me.DarkGroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstIndex = New System.Windows.Forms.ListBox()
        Me.DarkGroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.nudCreateTime = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel7 = New System.Windows.Forms.Label()
        Me.DarkGroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnIngredientAdd = New System.Windows.Forms.Button()
        Me.numItemAmount = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel6 = New System.Windows.Forms.Label()
        Me.cmbIngredient = New System.Windows.Forms.ComboBox()
        Me.DarkLabel5 = New System.Windows.Forms.Label()
        Me.lstIngredients = New System.Windows.Forms.ListBox()
        Me.nudAmount = New System.Windows.Forms.NumericUpDown()
        Me.DarkLabel4 = New System.Windows.Forms.Label()
        Me.cmbMakeItem = New System.Windows.Forms.ComboBox()
        Me.DarkLabel3 = New System.Windows.Forms.Label()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.DarkLabel2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.DarkLabel1 = New System.Windows.Forms.Label()
        Me.DarkGroupBox1.SuspendLayout()
        Me.DarkGroupBox2.SuspendLayout()
        CType(Me.nudCreateTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DarkGroupBox3.SuspendLayout()
        CType(Me.numItemAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DarkGroupBox1
        '
        Me.DarkGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox1.Controls.Add(Me.lstIndex)
        Me.DarkGroupBox1.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox1.Location = New System.Drawing.Point(4, 2)
        Me.DarkGroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DarkGroupBox1.Name = "DarkGroupBox1"
        Me.DarkGroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DarkGroupBox1.Size = New System.Drawing.Size(277, 414)
        Me.DarkGroupBox1.TabIndex = 0
        Me.DarkGroupBox1.TabStop = False
        Me.DarkGroupBox1.Text = "Lista de Receitas"
        '
        'lstIndex
        '
        Me.lstIndex.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lstIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstIndex.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstIndex.FormattingEnabled = True
        Me.lstIndex.ItemHeight = 16
        Me.lstIndex.Location = New System.Drawing.Point(8, 18)
        Me.lstIndex.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lstIndex.Name = "lstIndex"
        Me.lstIndex.Size = New System.Drawing.Size(261, 386)
        Me.lstIndex.TabIndex = 1
        '
        'DarkGroupBox2
        '
        Me.DarkGroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox2.Controls.Add(Me.btnCancel)
        Me.DarkGroupBox2.Controls.Add(Me.btnDelete)
        Me.DarkGroupBox2.Controls.Add(Me.btnSave)
        Me.DarkGroupBox2.Controls.Add(Me.nudCreateTime)
        Me.DarkGroupBox2.Controls.Add(Me.DarkLabel7)
        Me.DarkGroupBox2.Controls.Add(Me.DarkGroupBox3)
        Me.DarkGroupBox2.Controls.Add(Me.nudAmount)
        Me.DarkGroupBox2.Controls.Add(Me.DarkLabel4)
        Me.DarkGroupBox2.Controls.Add(Me.cmbMakeItem)
        Me.DarkGroupBox2.Controls.Add(Me.DarkLabel3)
        Me.DarkGroupBox2.Controls.Add(Me.cmbType)
        Me.DarkGroupBox2.Controls.Add(Me.DarkLabel2)
        Me.DarkGroupBox2.Controls.Add(Me.txtName)
        Me.DarkGroupBox2.Controls.Add(Me.DarkLabel1)
        Me.DarkGroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox2.Location = New System.Drawing.Point(290, 2)
        Me.DarkGroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DarkGroupBox2.Name = "DarkGroupBox2"
        Me.DarkGroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DarkGroupBox2.Size = New System.Drawing.Size(485, 414)
        Me.DarkGroupBox2.TabIndex = 1
        Me.DarkGroupBox2.TabStop = False
        Me.DarkGroupBox2.Text = "Propriedades da Receita"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(372, 369)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnCancel.Size = New System.Drawing.Size(100, 36)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancelar"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(190, 369)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnDelete.Size = New System.Drawing.Size(100, 36)
        Me.btnDelete.TabIndex = 12
        Me.btnDelete.Text = "Excluir"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(12, 369)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnSave.Size = New System.Drawing.Size(100, 36)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Salvar"
        '
        'nudCreateTime
        '
        Me.nudCreateTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudCreateTime.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudCreateTime.Location = New System.Drawing.Point(228, 146)
        Me.nudCreateTime.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nudCreateTime.Name = "nudCreateTime"
        Me.nudCreateTime.Size = New System.Drawing.Size(160, 22)
        Me.nudCreateTime.TabIndex = 10
        '
        'DarkLabel7
        '
        Me.DarkLabel7.AutoSize = True
        Me.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel7.Location = New System.Drawing.Point(8, 148)
        Me.DarkLabel7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel7.Name = "DarkLabel7"
        Me.DarkLabel7.Size = New System.Drawing.Size(128, 17)
        Me.DarkLabel7.TabIndex = 9
        Me.DarkLabel7.Text = "Tempo de Criação:"
        '
        'DarkGroupBox3
        '
        Me.DarkGroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox3.Controls.Add(Me.btnIngredientAdd)
        Me.DarkGroupBox3.Controls.Add(Me.numItemAmount)
        Me.DarkGroupBox3.Controls.Add(Me.DarkLabel6)
        Me.DarkGroupBox3.Controls.Add(Me.cmbIngredient)
        Me.DarkGroupBox3.Controls.Add(Me.DarkLabel5)
        Me.DarkGroupBox3.Controls.Add(Me.lstIngredients)
        Me.DarkGroupBox3.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox3.Location = New System.Drawing.Point(12, 178)
        Me.DarkGroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DarkGroupBox3.Name = "DarkGroupBox3"
        Me.DarkGroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DarkGroupBox3.Size = New System.Drawing.Size(460, 170)
        Me.DarkGroupBox3.TabIndex = 8
        Me.DarkGroupBox3.TabStop = False
        Me.DarkGroupBox3.Text = "Ingredientes"
        '
        'btnIngredientAdd
        '
        Me.btnIngredientAdd.Location = New System.Drawing.Point(233, 118)
        Me.btnIngredientAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnIngredientAdd.Name = "btnIngredientAdd"
        Me.btnIngredientAdd.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnIngredientAdd.Size = New System.Drawing.Size(192, 36)
        Me.btnIngredientAdd.TabIndex = 6
        Me.btnIngredientAdd.Text = "Atualizar Lista"
        '
        'numItemAmount
        '
        Me.numItemAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.numItemAmount.ForeColor = System.Drawing.Color.Gainsboro
        Me.numItemAmount.Location = New System.Drawing.Point(381, 76)
        Me.numItemAmount.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.numItemAmount.Name = "numItemAmount"
        Me.numItemAmount.Size = New System.Drawing.Size(71, 22)
        Me.numItemAmount.TabIndex = 5
        '
        'DarkLabel6
        '
        Me.DarkLabel6.AutoSize = True
        Me.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel6.Location = New System.Drawing.Point(211, 78)
        Me.DarkLabel6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel6.Name = "DarkLabel6"
        Me.DarkLabel6.Size = New System.Drawing.Size(114, 17)
        Me.DarkLabel6.TabIndex = 4
        Me.DarkLabel6.Text = "Qtd. Necessária:"
        '
        'cmbIngredient
        '
        Me.cmbIngredient.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbIngredient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIngredient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbIngredient.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbIngredient.FormattingEnabled = True
        Me.cmbIngredient.Location = New System.Drawing.Point(215, 43)
        Me.cmbIngredient.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbIngredient.Name = "cmbIngredient"
        Me.cmbIngredient.Size = New System.Drawing.Size(236, 24)
        Me.cmbIngredient.TabIndex = 3
        '
        'DarkLabel5
        '
        Me.DarkLabel5.AutoSize = True
        Me.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel5.Location = New System.Drawing.Point(211, 23)
        Me.DarkLabel5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel5.Name = "DarkLabel5"
        Me.DarkLabel5.Size = New System.Drawing.Size(133, 17)
        Me.DarkLabel5.TabIndex = 2
        Me.DarkLabel5.Text = "Escolha Ingrediente"
        '
        'lstIngredients
        '
        Me.lstIngredients.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lstIngredients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstIngredients.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstIngredients.FormattingEnabled = True
        Me.lstIngredients.ItemHeight = 16
        Me.lstIngredients.Location = New System.Drawing.Point(8, 23)
        Me.lstIngredients.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lstIngredients.Name = "lstIngredients"
        Me.lstIngredients.Size = New System.Drawing.Size(194, 130)
        Me.lstIngredients.TabIndex = 1
        '
        'nudAmount
        '
        Me.nudAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudAmount.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudAmount.Location = New System.Drawing.Point(416, 106)
        Me.nudAmount.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nudAmount.Name = "nudAmount"
        Me.nudAmount.Size = New System.Drawing.Size(56, 22)
        Me.nudAmount.TabIndex = 7
        '
        'DarkLabel4
        '
        Me.DarkLabel4.AutoSize = True
        Me.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel4.Location = New System.Drawing.Point(396, 108)
        Me.DarkLabel4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel4.Name = "DarkLabel4"
        Me.DarkLabel4.Size = New System.Drawing.Size(17, 17)
        Me.DarkLabel4.TabIndex = 6
        Me.DarkLabel4.Text = "X"
        '
        'cmbMakeItem
        '
        Me.cmbMakeItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbMakeItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMakeItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMakeItem.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbMakeItem.FormattingEnabled = True
        Me.cmbMakeItem.Location = New System.Drawing.Point(116, 105)
        Me.cmbMakeItem.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbMakeItem.Name = "cmbMakeItem"
        Me.cmbMakeItem.Size = New System.Drawing.Size(271, 24)
        Me.cmbMakeItem.TabIndex = 5
        '
        'DarkLabel3
        '
        Me.DarkLabel3.AutoSize = True
        Me.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel3.Location = New System.Drawing.Point(8, 108)
        Me.DarkLabel3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel3.Name = "DarkLabel3"
        Me.DarkLabel3.Size = New System.Drawing.Size(67, 17)
        Me.DarkLabel3.TabIndex = 4
        Me.DarkLabel3.Text = "Cria Item:"
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbType.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"Herbalista", "Madereireiro", "Metalista"})
        Me.cmbType.Location = New System.Drawing.Point(116, 66)
        Me.cmbType.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(354, 24)
        Me.cmbType.TabIndex = 3
        '
        'DarkLabel2
        '
        Me.DarkLabel2.AutoSize = True
        Me.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel2.Location = New System.Drawing.Point(8, 70)
        Me.DarkLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel2.Name = "DarkLabel2"
        Me.DarkLabel2.Size = New System.Drawing.Size(40, 17)
        Me.DarkLabel2.TabIndex = 2
        Me.DarkLabel2.Text = "Tipo:"
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtName.Location = New System.Drawing.Point(116, 30)
        Me.txtName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(356, 22)
        Me.txtName.TabIndex = 1
        '
        'DarkLabel1
        '
        Me.DarkLabel1.AutoSize = True
        Me.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel1.Location = New System.Drawing.Point(8, 34)
        Me.DarkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel1.Name = "DarkLabel1"
        Me.DarkLabel1.Size = New System.Drawing.Size(49, 17)
        Me.DarkLabel1.TabIndex = 0
        Me.DarkLabel1.Text = "Nome:"
        '
        'frmEditor_Recipe
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(784, 426)
        Me.ControlBox = False
        Me.Controls.Add(Me.DarkGroupBox2)
        Me.Controls.Add(Me.DarkGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmEditor_Recipe"
        Me.Text = "Editor de Receitas"
        Me.DarkGroupBox1.ResumeLayout(False)
        Me.DarkGroupBox2.ResumeLayout(False)
        Me.DarkGroupBox2.PerformLayout()
        CType(Me.nudCreateTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DarkGroupBox3.ResumeLayout(False)
        Me.DarkGroupBox3.PerformLayout()
        CType(Me.numItemAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DarkGroupBox1 As GroupBox
    Friend WithEvents lstIndex As Windows.Forms.ListBox
    Friend WithEvents DarkGroupBox2 As GroupBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents DarkLabel1 As Label
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents DarkLabel2 As Label
    Friend WithEvents cmbMakeItem As ComboBox
    Friend WithEvents DarkLabel3 As Label
    Friend WithEvents nudAmount As NumericUpDown
    Friend WithEvents DarkLabel4 As Label
    Friend WithEvents DarkGroupBox3 As GroupBox
    Friend WithEvents lstIngredients As Windows.Forms.ListBox
    Friend WithEvents cmbIngredient As ComboBox
    Friend WithEvents DarkLabel5 As Label
    Friend WithEvents DarkLabel6 As Label
    Friend WithEvents numItemAmount As NumericUpDown
    Friend WithEvents btnIngredientAdd As Button
    Friend WithEvents nudCreateTime As NumericUpDown
    Friend WithEvents DarkLabel7 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSave As Button
End Class
