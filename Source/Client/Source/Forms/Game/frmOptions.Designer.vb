<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOptions
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
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbScreenSize = New System.Windows.Forms.ComboBox()
        Me.lblVolume = New System.Windows.Forms.Label()
        Me.scrlVolume = New System.Windows.Forms.HScrollBar()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optSOff = New System.Windows.Forms.RadioButton()
        Me.optSOn = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optMOff = New System.Windows.Forms.RadioButton()
        Me.optMOn = New System.Windows.Forms.RadioButton()
        Me.chkHighEnd = New System.Windows.Forms.CheckBox()
        Me.chkNpcBars = New System.Windows.Forms.CheckBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.ForeColor = System.Drawing.Color.Black
        Me.btnSaveSettings.Location = New System.Drawing.Point(14, 252)
        Me.btnSaveSettings.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(274, 28)
        Me.btnSaveSettings.TabIndex = 14
        Me.btnSaveSettings.Text = "Alterar Configurações"
        Me.btnSaveSettings.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 123)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 17)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Resolução de Tela:"
        '
        'cmbScreenSize
        '
        Me.cmbScreenSize.FormattingEnabled = True
        Me.cmbScreenSize.Items.AddRange(New Object() {"800X600", "1024X768", "1152X864"})
        Me.cmbScreenSize.Location = New System.Drawing.Point(14, 142)
        Me.cmbScreenSize.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbScreenSize.Name = "cmbScreenSize"
        Me.cmbScreenSize.Size = New System.Drawing.Size(273, 24)
        Me.cmbScreenSize.TabIndex = 12
        '
        'lblVolume
        '
        Me.lblVolume.AutoSize = True
        Me.lblVolume.BackColor = System.Drawing.Color.Transparent
        Me.lblVolume.ForeColor = System.Drawing.Color.Black
        Me.lblVolume.Location = New System.Drawing.Point(16, 66)
        Me.lblVolume.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVolume.Name = "lblVolume"
        Me.lblVolume.Size = New System.Drawing.Size(63, 17)
        Me.lblVolume.TabIndex = 11
        Me.lblVolume.Text = "Volume: "
        '
        'scrlVolume
        '
        Me.scrlVolume.LargeChange = 1
        Me.scrlVolume.Location = New System.Drawing.Point(16, 85)
        Me.scrlVolume.Name = "scrlVolume"
        Me.scrlVolume.Size = New System.Drawing.Size(274, 17)
        Me.scrlVolume.TabIndex = 10
        Me.scrlVolume.Value = 100
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optSOff)
        Me.GroupBox2.Controls.Add(Me.optSOn)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(157, 16)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(133, 46)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sons"
        '
        'optSOff
        '
        Me.optSOff.AutoSize = True
        Me.optSOff.Location = New System.Drawing.Point(66, 23)
        Me.optSOff.Margin = New System.Windows.Forms.Padding(4)
        Me.optSOff.Name = "optSOff"
        Me.optSOff.Size = New System.Drawing.Size(48, 21)
        Me.optSOff.TabIndex = 5
        Me.optSOff.TabStop = True
        Me.optSOff.Text = "Off"
        Me.optSOff.UseVisualStyleBackColor = True
        '
        'optSOn
        '
        Me.optSOn.AutoSize = True
        Me.optSOn.Location = New System.Drawing.Point(5, 23)
        Me.optSOn.Margin = New System.Windows.Forms.Padding(4)
        Me.optSOn.Name = "optSOn"
        Me.optSOn.Size = New System.Drawing.Size(48, 21)
        Me.optSOn.TabIndex = 4
        Me.optSOn.TabStop = True
        Me.optSOn.Text = "On"
        Me.optSOn.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optMOff)
        Me.GroupBox1.Controls.Add(Me.optMOn)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(16, 14)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(133, 48)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Música"
        '
        'optMOff
        '
        Me.optMOff.AutoSize = True
        Me.optMOff.Location = New System.Drawing.Point(66, 21)
        Me.optMOff.Margin = New System.Windows.Forms.Padding(4)
        Me.optMOff.Name = "optMOff"
        Me.optMOff.Size = New System.Drawing.Size(48, 21)
        Me.optMOff.TabIndex = 2
        Me.optMOff.TabStop = True
        Me.optMOff.Text = "Off"
        Me.optMOff.UseVisualStyleBackColor = True
        '
        'optMOn
        '
        Me.optMOn.AutoSize = True
        Me.optMOn.Location = New System.Drawing.Point(5, 21)
        Me.optMOn.Margin = New System.Windows.Forms.Padding(4)
        Me.optMOn.Name = "optMOn"
        Me.optMOn.Size = New System.Drawing.Size(48, 21)
        Me.optMOn.TabIndex = 1
        Me.optMOn.TabStop = True
        Me.optMOn.Text = "On"
        Me.optMOn.UseVisualStyleBackColor = True
        '
        'chkHighEnd
        '
        Me.chkHighEnd.AutoSize = True
        Me.chkHighEnd.Location = New System.Drawing.Point(16, 176)
        Me.chkHighEnd.Margin = New System.Windows.Forms.Padding(4)
        Me.chkHighEnd.Name = "chkHighEnd"
        Me.chkHighEnd.Size = New System.Drawing.Size(179, 21)
        Me.chkHighEnd.TabIndex = 15
        Me.chkHighEnd.Text = "Configurações Máximas"
        Me.chkHighEnd.UseVisualStyleBackColor = True
        '
        'chkNpcBars
        '
        Me.chkNpcBars.AutoSize = True
        Me.chkNpcBars.Location = New System.Drawing.Point(14, 204)
        Me.chkNpcBars.Margin = New System.Windows.Forms.Padding(4)
        Me.chkNpcBars.Name = "chkNpcBars"
        Me.chkNpcBars.Size = New System.Drawing.Size(182, 21)
        Me.chkNpcBars.TabIndex = 16
        Me.chkNpcBars.Text = "Mostrar barras de NPCs"
        Me.chkNpcBars.UseVisualStyleBackColor = True
        '
        'FrmOptions
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(309, 294)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkNpcBars)
        Me.Controls.Add(Me.chkHighEnd)
        Me.Controls.Add(Me.btnSaveSettings)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmbScreenSize)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblVolume)
        Me.Controls.Add(Me.scrlVolume)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmOptions"
        Me.ShowInTaskbar = False
        Me.Text = "Configurações de Jogo"
        Me.TopMost = True
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSaveSettings As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents cmbScreenSize As Windows.Forms.ComboBox
    Friend WithEvents lblVolume As Windows.Forms.Label
    Friend WithEvents scrlVolume As Windows.Forms.HScrollBar
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents optSOff As Windows.Forms.RadioButton
    Friend WithEvents optSOn As Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents optMOff As Windows.Forms.RadioButton
    Friend WithEvents optMOn As Windows.Forms.RadioButton
    Friend WithEvents chkHighEnd As Windows.Forms.CheckBox
    Friend WithEvents chkNpcBars As Windows.Forms.CheckBox
End Class
