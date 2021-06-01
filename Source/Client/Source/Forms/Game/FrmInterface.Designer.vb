<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmInterface
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInterface))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.txtAuthor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbInterface = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.tbComponents = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbComponents = New System.Windows.Forms.ComboBox()
        Me.btnAddComponent = New System.Windows.Forms.Button()
        Me.tvComponents = New System.Windows.Forms.TreeView()
        Me.icTreeView = New System.Windows.Forms.ImageList(Me.components)
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbLayout = New System.Windows.Forms.ComboBox()
        Me.btnAddLayout = New System.Windows.Forms.Button()
        Me.pbPreview = New System.Windows.Forms.PictureBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.lvProperties = New System.Windows.Forms.ListView()
        Me.clnName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clnValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnEditProp = New System.Windows.Forms.Button()
        Me.cmbPropValue = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.tbComponents.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.pbPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSave, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1029, 631)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label3, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.txtName, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.txtDesc, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.txtAuthor, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cmbInterface, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 2)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 4
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1023, 108)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nome:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descrição:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 30)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Autor:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtName
        '
        Me.txtName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(110, 28)
        Me.txtName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(910, 22)
        Me.txtName.TabIndex = 3
        '
        'txtDesc
        '
        Me.txtDesc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDesc.Enabled = False
        Me.txtDesc.Location = New System.Drawing.Point(110, 54)
        Me.txtDesc.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(910, 22)
        Me.txtDesc.TabIndex = 4
        '
        'txtAuthor
        '
        Me.txtAuthor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAuthor.Enabled = False
        Me.txtAuthor.Location = New System.Drawing.Point(110, 80)
        Me.txtAuthor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(910, 22)
        Me.txtAuthor.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 26)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Interface:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbInterface
        '
        Me.cmbInterface.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbInterface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInterface.FormattingEnabled = True
        Me.cmbInterface.Location = New System.Drawing.Point(110, 2)
        Me.cmbInterface.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbInterface.Name = "cmbInterface"
        Me.cmbInterface.Size = New System.Drawing.Size(910, 24)
        Me.cmbInterface.TabIndex = 9
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.tbComponents, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pbPreview, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel4, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 114)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1023, 474)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'tbComponents
        '
        Me.tbComponents.ColumnCount = 1
        Me.tbComponents.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbComponents.Controls.Add(Me.TableLayoutPanel5, 0, 2)
        Me.tbComponents.Controls.Add(Me.tvComponents, 0, 1)
        Me.tbComponents.Controls.Add(Me.TableLayoutPanel6, 0, 0)
        Me.tbComponents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbComponents.Enabled = False
        Me.tbComponents.Location = New System.Drawing.Point(3, 2)
        Me.tbComponents.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbComponents.Name = "tbComponents"
        Me.tbComponents.RowCount = 3
        Me.tbComponents.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.tbComponents.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbComponents.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.tbComponents.Size = New System.Drawing.Size(249, 470)
        Me.tbComponents.TabIndex = 0
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.cmbComponents, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.btnAddComponent, 1, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 433)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(243, 35)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'cmbComponents
        '
        Me.cmbComponents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbComponents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComponents.FormattingEnabled = True
        Me.cmbComponents.Items.AddRange(New Object() {"Texto", "Botão", "Caixa de texto", "Painel", "Grade de slots"})
        Me.cmbComponents.Location = New System.Drawing.Point(3, 2)
        Me.cmbComponents.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbComponents.Name = "cmbComponents"
        Me.cmbComponents.Size = New System.Drawing.Size(200, 24)
        Me.cmbComponents.TabIndex = 0
        '
        'btnAddComponent
        '
        Me.btnAddComponent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddComponent.Image = Global.My.Resources.Resources.Save
        Me.btnAddComponent.Location = New System.Drawing.Point(209, 2)
        Me.btnAddComponent.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAddComponent.Name = "btnAddComponent"
        Me.btnAddComponent.Size = New System.Drawing.Size(31, 31)
        Me.btnAddComponent.TabIndex = 1
        Me.btnAddComponent.UseVisualStyleBackColor = True
        '
        'tvComponents
        '
        Me.tvComponents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvComponents.ImageIndex = 0
        Me.tvComponents.ImageList = Me.icTreeView
        Me.tvComponents.Location = New System.Drawing.Point(3, 38)
        Me.tvComponents.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tvComponents.Name = "tvComponents"
        Me.tvComponents.SelectedImageIndex = 0
        Me.tvComponents.Size = New System.Drawing.Size(243, 391)
        Me.tvComponents.TabIndex = 1
        '
        'icTreeView
        '
        Me.icTreeView.ImageStream = CType(resources.GetObject("icTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.icTreeView.TransparentColor = System.Drawing.Color.Transparent
        Me.icTreeView.Images.SetKeyName(0, "Label.png")
        Me.icTreeView.Images.SetKeyName(1, "Button.png")
        Me.icTreeView.Images.SetKeyName(2, "TextBox.png")
        Me.icTreeView.Images.SetKeyName(3, "Panel.png")
        Me.icTreeView.Images.SetKeyName(4, "Grid.png")
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 3
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.Label5, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.cmbLayout, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.btnAddLayout, 2, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 2)
        Me.TableLayoutPanel6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(243, 32)
        Me.TableLayoutPanel6.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 32)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Layout:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbLayout
        '
        Me.cmbLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLayout.FormattingEnabled = True
        Me.cmbLayout.Location = New System.Drawing.Point(67, 2)
        Me.cmbLayout.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbLayout.Name = "cmbLayout"
        Me.cmbLayout.Size = New System.Drawing.Size(113, 24)
        Me.cmbLayout.TabIndex = 1
        '
        'btnAddLayout
        '
        Me.btnAddLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddLayout.Location = New System.Drawing.Point(186, 2)
        Me.btnAddLayout.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAddLayout.Name = "btnAddLayout"
        Me.btnAddLayout.Size = New System.Drawing.Size(54, 28)
        Me.btnAddLayout.TabIndex = 2
        Me.btnAddLayout.Text = "Add"
        Me.btnAddLayout.UseVisualStyleBackColor = True
        '
        'pbPreview
        '
        Me.pbPreview.BackColor = System.Drawing.Color.Black
        Me.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbPreview.Location = New System.Drawing.Point(258, 2)
        Me.pbPreview.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbPreview.Name = "pbPreview"
        Me.pbPreview.Size = New System.Drawing.Size(505, 470)
        Me.pbPreview.TabIndex = 2
        Me.pbPreview.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(926, 592)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 37)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Salvar"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.lvProperties, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel7, 0, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(769, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(251, 468)
        Me.TableLayoutPanel4.TabIndex = 3
        '
        'lvProperties
        '
        Me.lvProperties.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clnName, Me.clnValue})
        Me.lvProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvProperties.Enabled = False
        Me.lvProperties.FullRowSelect = True
        Me.lvProperties.GridLines = True
        Me.lvProperties.HideSelection = False
        Me.lvProperties.LabelEdit = True
        Me.lvProperties.Location = New System.Drawing.Point(3, 2)
        Me.lvProperties.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lvProperties.Name = "lvProperties"
        Me.lvProperties.Size = New System.Drawing.Size(245, 424)
        Me.lvProperties.TabIndex = 2
        Me.lvProperties.UseCompatibleStateImageBehavior = False
        Me.lvProperties.View = System.Windows.Forms.View.Details
        '
        'clnName
        '
        Me.clnName.Text = "Propriedade"
        Me.clnName.Width = 139
        '
        'clnValue
        '
        Me.clnValue.Text = "Valor"
        Me.clnValue.Width = 96
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 2
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.btnEditProp, 1, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.cmbPropValue, 0, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(3, 431)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(245, 34)
        Me.TableLayoutPanel7.TabIndex = 3
        '
        'btnEditProp
        '
        Me.btnEditProp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEditProp.Location = New System.Drawing.Point(186, 3)
        Me.btnEditProp.Name = "btnEditProp"
        Me.btnEditProp.Size = New System.Drawing.Size(56, 28)
        Me.btnEditProp.TabIndex = 0
        Me.btnEditProp.Text = "Editar"
        Me.btnEditProp.UseVisualStyleBackColor = True
        '
        'cmbPropValue
        '
        Me.cmbPropValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbPropValue.FormattingEnabled = True
        Me.cmbPropValue.Items.AddRange(New Object() {"False", "True"})
        Me.cmbPropValue.Location = New System.Drawing.Point(3, 3)
        Me.cmbPropValue.Name = "cmbPropValue"
        Me.cmbPropValue.Size = New System.Drawing.Size(177, 24)
        Me.cmbPropValue.TabIndex = 1
        '
        'FrmInterface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 631)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FrmInterface"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editor de interface"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.tbComponents.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        CType(Me.pbPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtDesc As TextBox
    Friend WithEvents txtAuthor As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbInterface As ComboBox
    Friend WithEvents tbComponents As TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents cmbComponents As ComboBox
    Friend WithEvents btnAddComponent As Button
    Friend WithEvents tvComponents As TreeView
    Friend WithEvents pbPreview As PictureBox
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbLayout As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnAddLayout As Button
    Friend WithEvents icTreeView As ImageList
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents lvProperties As ListView
    Friend WithEvents clnName As ColumnHeader
    Friend WithEvents clnValue As ColumnHeader
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents btnEditProp As Button
    Friend WithEvents cmbPropValue As ComboBox
End Class
