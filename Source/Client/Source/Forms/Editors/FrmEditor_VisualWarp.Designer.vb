<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_VisualWarp
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
        Me.btnWarpOK = New System.Windows.Forms.Button()
        Me.DarkLabel15 = New System.Windows.Forms.Label()
        Me.lstMaps = New System.Windows.Forms.ListBox()
        Me.pnlPreview = New System.Windows.Forms.Panel()
        Me.picPreview = New System.Windows.Forms.PictureBox()
        Me.lblSelX = New System.Windows.Forms.Label()
        Me.lblSelY = New System.Windows.Forms.Label()
        Me.pnlPreview.SuspendLayout()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnWarpOK
        '
        Me.btnWarpOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnWarpOK.Location = New System.Drawing.Point(16, 612)
        Me.btnWarpOK.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnWarpOK.Name = "btnWarpOK"
        Me.btnWarpOK.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.btnWarpOK.Size = New System.Drawing.Size(223, 36)
        Me.btnWarpOK.TabIndex = 4
        Me.btnWarpOK.Text = "Ok"
        Me.btnWarpOK.UseVisualStyleBackColor = False
        '
        'DarkLabel15
        '
        Me.DarkLabel15.AutoSize = True
        Me.DarkLabel15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel15.Location = New System.Drawing.Point(16, 11)
        Me.DarkLabel15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DarkLabel15.Name = "DarkLabel15"
        Me.DarkLabel15.Size = New System.Drawing.Size(104, 17)
        Me.DarkLabel15.TabIndex = 3
        Me.DarkLabel15.Text = "Lista de mapas"
        '
        'lstMaps
        '
        Me.lstMaps.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.lstMaps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstMaps.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstMaps.FormattingEnabled = True
        Me.lstMaps.ItemHeight = 16
        Me.lstMaps.Location = New System.Drawing.Point(16, 31)
        Me.lstMaps.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lstMaps.Name = "lstMaps"
        Me.lstMaps.Size = New System.Drawing.Size(230, 338)
        Me.lstMaps.TabIndex = 2
        '
        'pnlPreview
        '
        Me.pnlPreview.AutoScroll = True
        Me.pnlPreview.Controls.Add(Me.picPreview)
        Me.pnlPreview.Location = New System.Drawing.Point(255, 15)
        Me.pnlPreview.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlPreview.Name = "pnlPreview"
        Me.pnlPreview.Size = New System.Drawing.Size(785, 634)
        Me.pnlPreview.TabIndex = 1
        '
        'picPreview
        '
        Me.picPreview.Location = New System.Drawing.Point(4, 4)
        Me.picPreview.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Size = New System.Drawing.Size(475, 463)
        Me.picPreview.TabIndex = 0
        Me.picPreview.TabStop = False
        '
        'lblSelX
        '
        Me.lblSelX.AutoSize = True
        Me.lblSelX.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblSelX.Location = New System.Drawing.Point(16, 385)
        Me.lblSelX.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSelX.Name = "lblSelX"
        Me.lblSelX.Size = New System.Drawing.Size(115, 17)
        Me.lblSelX.TabIndex = 5
        Me.lblSelX.Text = "Coordenada X: 0"
        '
        'lblSelY
        '
        Me.lblSelY.AutoSize = True
        Me.lblSelY.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblSelY.Location = New System.Drawing.Point(16, 416)
        Me.lblSelY.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSelY.Name = "lblSelY"
        Me.lblSelY.Size = New System.Drawing.Size(115, 17)
        Me.lblSelY.TabIndex = 6
        Me.lblSelY.Text = "Coordenada Y: 0"
        '
        'frmEditor_VisualWarp
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1051, 663)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblSelY)
        Me.Controls.Add(Me.lblSelX)
        Me.Controls.Add(Me.pnlPreview)
        Me.Controls.Add(Me.btnWarpOK)
        Me.Controls.Add(Me.DarkLabel15)
        Me.Controls.Add(Me.lstMaps)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmEditor_VisualWarp"
        Me.Text = "Visual Warp"
        Me.pnlPreview.ResumeLayout(False)
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnWarpOK As Button
    Friend WithEvents DarkLabel15 As Label
    Friend WithEvents lstMaps As Windows.Forms.ListBox
    Friend WithEvents pnlPreview As Windows.Forms.Panel
    Friend WithEvents picPreview As Windows.Forms.PictureBox
    Friend WithEvents lblSelX As Label
    Friend WithEvents lblSelY As Label
End Class
