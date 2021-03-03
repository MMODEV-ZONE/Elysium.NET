<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMenu
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenu))
        Me.pnlLogin = New System.Windows.Forms.Panel()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.chkSavePass = New System.Windows.Forms.CheckBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblLoginPass = New System.Windows.Forms.Label()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.lblLoginName = New System.Windows.Forms.Label()
        Me.pnlRegister = New System.Windows.Forms.Panel()
        Me.txtRPass2 = New System.Windows.Forms.TextBox()
        Me.lblNewAccPass2 = New System.Windows.Forms.Label()
        Me.txtRPass = New System.Windows.Forms.TextBox()
        Me.lblNewAccPass = New System.Windows.Forms.Label()
        Me.txtRuser = New System.Windows.Forms.TextBox()
        Me.lblNewAccName = New System.Windows.Forms.Label()
        Me.btnCreateAccount = New System.Windows.Forms.Button()
        Me.pnlCharSelect = New System.Windows.Forms.Panel()
        Me.btnUseChar = New System.Windows.Forms.Button()
        Me.btnDelChar = New System.Windows.Forms.Button()
        Me.btnNewChar = New System.Windows.Forms.Button()
        Me.picChar3 = New System.Windows.Forms.PictureBox()
        Me.picChar2 = New System.Windows.Forms.PictureBox()
        Me.picChar1 = New System.Windows.Forms.PictureBox()
        Me.lblCharSelect = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.pnlCredits = New System.Windows.Forms.Panel()
        Me.lblCreditsTop = New System.Windows.Forms.Label()
        Me.lblScrollingCredits = New System.Windows.Forms.Label()
        Me.tmrCredits = New System.Windows.Forms.Timer(Me.components)
        Me.pnlNewChar = New System.Windows.Forms.Panel()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblNewCharSprite = New System.Windows.Forms.Label()
        Me.btnCreateCharacter = New System.Windows.Forms.Button()
        Me.placeholderforsprite = New System.Windows.Forms.PictureBox()
        Me.lblNextChar = New System.Windows.Forms.Label()
        Me.lblPrevChar = New System.Windows.Forms.Label()
        Me.rdoFemale = New System.Windows.Forms.RadioButton()
        Me.rdoMale = New System.Windows.Forms.RadioButton()
        Me.cmbClass = New System.Windows.Forms.ComboBox()
        Me.lblNewCharGender = New System.Windows.Forms.Label()
        Me.lblNewCharClass = New System.Windows.Forms.Label()
        Me.txtCharName = New System.Windows.Forms.TextBox()
        Me.lblNewCharName = New System.Windows.Forms.Label()
        Me.lblNewChar = New System.Windows.Forms.Label()
        Me.lblStatusHeader = New System.Windows.Forms.Label()
        Me.lblServerStatus = New System.Windows.Forms.Label()
        Me.pnlMainMenu = New System.Windows.Forms.Panel()
        Me.lblNewsHeader = New System.Windows.Forms.Label()
        Me.lblNews = New System.Windows.Forms.Label()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.btnCredits = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.pnlLoad = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.picMMODEV = New System.Windows.Forms.PictureBox()
        Me.pnlLogin.SuspendLayout()
        Me.pnlRegister.SuspendLayout()
        Me.pnlCharSelect.SuspendLayout()
        CType(Me.picChar3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picChar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picChar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCredits.SuspendLayout()
        Me.pnlNewChar.SuspendLayout()
        CType(Me.placeholderforsprite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMainMenu.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLoad.SuspendLayout()
        CType(Me.picMMODEV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlLogin
        '
        Me.pnlLogin.BackColor = System.Drawing.Color.Transparent
        Me.pnlLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlLogin.Controls.Add(Me.btnLogin)
        Me.pnlLogin.Controls.Add(Me.chkSavePass)
        Me.pnlLogin.Controls.Add(Me.txtPassword)
        Me.pnlLogin.Controls.Add(Me.lblLoginPass)
        Me.pnlLogin.Controls.Add(Me.txtLogin)
        Me.pnlLogin.Controls.Add(Me.lblLoginName)
        Me.pnlLogin.ForeColor = System.Drawing.Color.White
        Me.pnlLogin.Location = New System.Drawing.Point(312, 229)
        Me.pnlLogin.Name = "pnlLogin"
        Me.pnlLogin.Size = New System.Drawing.Size(400, 303)
        Me.pnlLogin.TabIndex = 58
        Me.pnlLogin.Visible = False
        '
        'btnLogin
        '
        Me.btnLogin.BackgroundImage = CType(resources.GetObject("btnLogin.BackgroundImage"), System.Drawing.Image)
        Me.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLogin.FlatAppearance.BorderSize = 0
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnLogin.Location = New System.Drawing.Point(145, 236)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(110, 41)
        Me.btnLogin.TabIndex = 57
        Me.btnLogin.Text = "ENTRAR"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'chkSavePass
        '
        Me.chkSavePass.AutoSize = True
        Me.chkSavePass.BackColor = System.Drawing.Color.Transparent
        Me.chkSavePass.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSavePass.Location = New System.Drawing.Point(71, 189)
        Me.chkSavePass.Name = "chkSavePass"
        Me.chkSavePass.Size = New System.Drawing.Size(143, 27)
        Me.chkSavePass.TabIndex = 58
        Me.chkSavePass.Text = "Salvar senha ?"
        Me.chkSavePass.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPassword.Location = New System.Drawing.Point(71, 154)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(266, 29)
        Me.txtPassword.TabIndex = 24
        '
        'lblLoginPass
        '
        Me.lblLoginPass.AutoSize = True
        Me.lblLoginPass.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoginPass.Location = New System.Drawing.Point(67, 128)
        Me.lblLoginPass.Name = "lblLoginPass"
        Me.lblLoginPass.Size = New System.Drawing.Size(67, 23)
        Me.lblLoginPass.TabIndex = 58
        Me.lblLoginPass.Text = "SENHA"
        '
        'txtLogin
        '
        Me.txtLogin.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtLogin.Location = New System.Drawing.Point(71, 85)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(266, 29)
        Me.txtLogin.TabIndex = 17
        '
        'lblLoginName
        '
        Me.lblLoginName.AutoSize = True
        Me.lblLoginName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoginName.Location = New System.Drawing.Point(67, 59)
        Me.lblLoginName.Name = "lblLoginName"
        Me.lblLoginName.Size = New System.Drawing.Size(85, 23)
        Me.lblLoginName.TabIndex = 58
        Me.lblLoginName.Text = "USUÁRIO"
        '
        'pnlRegister
        '
        Me.pnlRegister.BackColor = System.Drawing.Color.Transparent
        Me.pnlRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlRegister.Controls.Add(Me.txtRPass2)
        Me.pnlRegister.Controls.Add(Me.lblNewAccPass2)
        Me.pnlRegister.Controls.Add(Me.txtRPass)
        Me.pnlRegister.Controls.Add(Me.lblNewAccPass)
        Me.pnlRegister.Controls.Add(Me.txtRuser)
        Me.pnlRegister.Controls.Add(Me.lblNewAccName)
        Me.pnlRegister.Controls.Add(Me.btnCreateAccount)
        Me.pnlRegister.ForeColor = System.Drawing.Color.White
        Me.pnlRegister.Location = New System.Drawing.Point(312, 229)
        Me.pnlRegister.Name = "pnlRegister"
        Me.pnlRegister.Size = New System.Drawing.Size(400, 303)
        Me.pnlRegister.TabIndex = 58
        Me.pnlRegister.Visible = False
        '
        'txtRPass2
        '
        Me.txtRPass2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRPass2.Location = New System.Drawing.Point(71, 177)
        Me.txtRPass2.Name = "txtRPass2"
        Me.txtRPass2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtRPass2.Size = New System.Drawing.Size(266, 29)
        Me.txtRPass2.TabIndex = 21
        '
        'lblNewAccPass2
        '
        Me.lblNewAccPass2.AutoSize = True
        Me.lblNewAccPass2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewAccPass2.Location = New System.Drawing.Point(69, 151)
        Me.lblNewAccPass2.Name = "lblNewAccPass2"
        Me.lblNewAccPass2.Size = New System.Drawing.Size(159, 23)
        Me.lblNewAccPass2.TabIndex = 20
        Me.lblNewAccPass2.Text = "Re-digite a senha :"
        '
        'txtRPass
        '
        Me.txtRPass.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRPass.Location = New System.Drawing.Point(71, 117)
        Me.txtRPass.Name = "txtRPass"
        Me.txtRPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtRPass.Size = New System.Drawing.Size(266, 29)
        Me.txtRPass.TabIndex = 19
        '
        'lblNewAccPass
        '
        Me.lblNewAccPass.AutoSize = True
        Me.lblNewAccPass.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewAccPass.Location = New System.Drawing.Point(69, 91)
        Me.lblNewAccPass.Name = "lblNewAccPass"
        Me.lblNewAccPass.Size = New System.Drawing.Size(68, 23)
        Me.lblNewAccPass.TabIndex = 18
        Me.lblNewAccPass.Text = "Senha :"
        '
        'txtRuser
        '
        Me.txtRuser.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRuser.Location = New System.Drawing.Point(71, 59)
        Me.txtRuser.Name = "txtRuser"
        Me.txtRuser.Size = New System.Drawing.Size(266, 29)
        Me.txtRuser.TabIndex = 17
        '
        'lblNewAccName
        '
        Me.lblNewAccName.AutoSize = True
        Me.lblNewAccName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewAccName.Location = New System.Drawing.Point(69, 33)
        Me.lblNewAccName.Name = "lblNewAccName"
        Me.lblNewAccName.Size = New System.Drawing.Size(65, 23)
        Me.lblNewAccName.TabIndex = 16
        Me.lblNewAccName.Text = "Login :"
        '
        'btnCreateAccount
        '
        Me.btnCreateAccount.BackgroundImage = CType(resources.GetObject("btnCreateAccount.BackgroundImage"), System.Drawing.Image)
        Me.btnCreateAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCreateAccount.FlatAppearance.BorderSize = 0
        Me.btnCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreateAccount.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateAccount.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnCreateAccount.Location = New System.Drawing.Point(145, 236)
        Me.btnCreateAccount.Name = "btnCreateAccount"
        Me.btnCreateAccount.Size = New System.Drawing.Size(110, 41)
        Me.btnCreateAccount.TabIndex = 23
        Me.btnCreateAccount.Text = "REGISTRAR"
        Me.btnCreateAccount.UseVisualStyleBackColor = True
        '
        'pnlCharSelect
        '
        Me.pnlCharSelect.BackColor = System.Drawing.Color.Transparent
        Me.pnlCharSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlCharSelect.Controls.Add(Me.btnUseChar)
        Me.pnlCharSelect.Controls.Add(Me.btnDelChar)
        Me.pnlCharSelect.Controls.Add(Me.btnNewChar)
        Me.pnlCharSelect.Controls.Add(Me.picChar3)
        Me.pnlCharSelect.Controls.Add(Me.picChar2)
        Me.pnlCharSelect.Controls.Add(Me.picChar1)
        Me.pnlCharSelect.Controls.Add(Me.lblCharSelect)
        Me.pnlCharSelect.Controls.Add(Me.Label16)
        Me.pnlCharSelect.ForeColor = System.Drawing.Color.White
        Me.pnlCharSelect.Location = New System.Drawing.Point(312, 229)
        Me.pnlCharSelect.Name = "pnlCharSelect"
        Me.pnlCharSelect.Size = New System.Drawing.Size(400, 303)
        Me.pnlCharSelect.TabIndex = 60
        Me.pnlCharSelect.Visible = False
        '
        'btnUseChar
        '
        Me.btnUseChar.BackgroundImage = CType(resources.GetObject("btnUseChar.BackgroundImage"), System.Drawing.Image)
        Me.btnUseChar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUseChar.FlatAppearance.BorderSize = 0
        Me.btnUseChar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUseChar.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUseChar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnUseChar.Location = New System.Drawing.Point(145, 196)
        Me.btnUseChar.Name = "btnUseChar"
        Me.btnUseChar.Size = New System.Drawing.Size(110, 41)
        Me.btnUseChar.TabIndex = 52
        Me.btnUseChar.Text = "Usar Personagem"
        Me.btnUseChar.UseVisualStyleBackColor = True
        '
        'btnDelChar
        '
        Me.btnDelChar.BackgroundImage = CType(resources.GetObject("btnDelChar.BackgroundImage"), System.Drawing.Image)
        Me.btnDelChar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDelChar.FlatAppearance.BorderSize = 0
        Me.btnDelChar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelChar.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelChar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnDelChar.Location = New System.Drawing.Point(269, 196)
        Me.btnDelChar.Name = "btnDelChar"
        Me.btnDelChar.Size = New System.Drawing.Size(110, 41)
        Me.btnDelChar.TabIndex = 51
        Me.btnDelChar.Text = "Excluir Personagem"
        Me.btnDelChar.UseVisualStyleBackColor = True
        '
        'btnNewChar
        '
        Me.btnNewChar.BackgroundImage = CType(resources.GetObject("btnNewChar.BackgroundImage"), System.Drawing.Image)
        Me.btnNewChar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNewChar.FlatAppearance.BorderSize = 0
        Me.btnNewChar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewChar.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewChar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnNewChar.Location = New System.Drawing.Point(20, 196)
        Me.btnNewChar.Name = "btnNewChar"
        Me.btnNewChar.Size = New System.Drawing.Size(110, 41)
        Me.btnNewChar.TabIndex = 50
        Me.btnNewChar.Text = "Novo Personagem"
        Me.btnNewChar.UseVisualStyleBackColor = True
        '
        'picChar3
        '
        Me.picChar3.BackColor = System.Drawing.Color.Transparent
        Me.picChar3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picChar3.Location = New System.Drawing.Point(298, 87)
        Me.picChar3.Name = "picChar3"
        Me.picChar3.Size = New System.Drawing.Size(48, 60)
        Me.picChar3.TabIndex = 44
        Me.picChar3.TabStop = False
        '
        'picChar2
        '
        Me.picChar2.BackColor = System.Drawing.Color.Transparent
        Me.picChar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picChar2.Location = New System.Drawing.Point(173, 87)
        Me.picChar2.Name = "picChar2"
        Me.picChar2.Size = New System.Drawing.Size(48, 60)
        Me.picChar2.TabIndex = 43
        Me.picChar2.TabStop = False
        '
        'picChar1
        '
        Me.picChar1.BackColor = System.Drawing.Color.Transparent
        Me.picChar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picChar1.Location = New System.Drawing.Point(50, 87)
        Me.picChar1.Name = "picChar1"
        Me.picChar1.Size = New System.Drawing.Size(48, 60)
        Me.picChar1.TabIndex = 42
        Me.picChar1.TabStop = False
        '
        'lblCharSelect
        '
        Me.lblCharSelect.BackColor = System.Drawing.Color.Transparent
        Me.lblCharSelect.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCharSelect.Location = New System.Drawing.Point(44, 12)
        Me.lblCharSelect.Name = "lblCharSelect"
        Me.lblCharSelect.Size = New System.Drawing.Size(312, 33)
        Me.lblCharSelect.TabIndex = 15
        Me.lblCharSelect.Text = "Sel. de Personagem"
        Me.lblCharSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(70, 179)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(0, 19)
        Me.Label16.TabIndex = 17
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlCredits
        '
        Me.pnlCredits.BackColor = System.Drawing.Color.Transparent
        Me.pnlCredits.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlCredits.Controls.Add(Me.lblCreditsTop)
        Me.pnlCredits.Controls.Add(Me.lblScrollingCredits)
        Me.pnlCredits.ForeColor = System.Drawing.Color.White
        Me.pnlCredits.Location = New System.Drawing.Point(312, 229)
        Me.pnlCredits.Name = "pnlCredits"
        Me.pnlCredits.Size = New System.Drawing.Size(400, 303)
        Me.pnlCredits.TabIndex = 56
        Me.pnlCredits.Visible = False
        '
        'lblCreditsTop
        '
        Me.lblCreditsTop.BackColor = System.Drawing.Color.Transparent
        Me.lblCreditsTop.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreditsTop.Location = New System.Drawing.Point(78, 6)
        Me.lblCreditsTop.Name = "lblCreditsTop"
        Me.lblCreditsTop.Size = New System.Drawing.Size(247, 33)
        Me.lblCreditsTop.TabIndex = 56
        Me.lblCreditsTop.Text = "Créditos"
        Me.lblCreditsTop.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblScrollingCredits
        '
        Me.lblScrollingCredits.AutoSize = True
        Me.lblScrollingCredits.BackColor = System.Drawing.Color.Transparent
        Me.lblScrollingCredits.Location = New System.Drawing.Point(70, 179)
        Me.lblScrollingCredits.Name = "lblScrollingCredits"
        Me.lblScrollingCredits.Size = New System.Drawing.Size(0, 19)
        Me.lblScrollingCredits.TabIndex = 17
        Me.lblScrollingCredits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tmrCredits
        '
        Me.tmrCredits.Enabled = True
        Me.tmrCredits.Interval = 1000
        '
        'pnlNewChar
        '
        Me.pnlNewChar.BackColor = System.Drawing.Color.Transparent
        Me.pnlNewChar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlNewChar.Controls.Add(Me.txtDescription)
        Me.pnlNewChar.Controls.Add(Me.lblNewCharSprite)
        Me.pnlNewChar.Controls.Add(Me.btnCreateCharacter)
        Me.pnlNewChar.Controls.Add(Me.placeholderforsprite)
        Me.pnlNewChar.Controls.Add(Me.lblNextChar)
        Me.pnlNewChar.Controls.Add(Me.lblPrevChar)
        Me.pnlNewChar.Controls.Add(Me.rdoFemale)
        Me.pnlNewChar.Controls.Add(Me.rdoMale)
        Me.pnlNewChar.Controls.Add(Me.cmbClass)
        Me.pnlNewChar.Controls.Add(Me.lblNewCharGender)
        Me.pnlNewChar.Controls.Add(Me.lblNewCharClass)
        Me.pnlNewChar.Controls.Add(Me.txtCharName)
        Me.pnlNewChar.Controls.Add(Me.lblNewCharName)
        Me.pnlNewChar.Controls.Add(Me.lblNewChar)
        Me.pnlNewChar.ForeColor = System.Drawing.Color.White
        Me.pnlNewChar.Location = New System.Drawing.Point(312, 229)
        Me.pnlNewChar.Name = "pnlNewChar"
        Me.pnlNewChar.Size = New System.Drawing.Size(400, 303)
        Me.pnlNewChar.TabIndex = 57
        Me.pnlNewChar.Visible = False
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtDescription.Location = New System.Drawing.Point(199, 128)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(185, 102)
        Me.txtDescription.TabIndex = 44
        '
        'lblNewCharSprite
        '
        Me.lblNewCharSprite.AutoSize = True
        Me.lblNewCharSprite.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewCharSprite.Location = New System.Drawing.Point(20, 124)
        Me.lblNewCharSprite.Name = "lblNewCharSprite"
        Me.lblNewCharSprite.Size = New System.Drawing.Size(54, 23)
        Me.lblNewCharSprite.TabIndex = 43
        Me.lblNewCharSprite.Text = "Sprite"
        '
        'btnCreateCharacter
        '
        Me.btnCreateCharacter.BackgroundImage = CType(resources.GetObject("btnCreateCharacter.BackgroundImage"), System.Drawing.Image)
        Me.btnCreateCharacter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCreateCharacter.FlatAppearance.BorderSize = 0
        Me.btnCreateCharacter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreateCharacter.Font = New System.Drawing.Font("Segoe UI", 6.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateCharacter.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnCreateCharacter.Location = New System.Drawing.Point(274, 243)
        Me.btnCreateCharacter.Name = "btnCreateCharacter"
        Me.btnCreateCharacter.Size = New System.Drawing.Size(110, 41)
        Me.btnCreateCharacter.TabIndex = 42
        Me.btnCreateCharacter.Text = "Criar personagem"
        Me.btnCreateCharacter.UseVisualStyleBackColor = True
        '
        'placeholderforsprite
        '
        Me.placeholderforsprite.Location = New System.Drawing.Point(19, 148)
        Me.placeholderforsprite.Name = "placeholderforsprite"
        Me.placeholderforsprite.Size = New System.Drawing.Size(55, 60)
        Me.placeholderforsprite.TabIndex = 41
        Me.placeholderforsprite.TabStop = False
        Me.placeholderforsprite.Visible = False
        '
        'lblNextChar
        '
        Me.lblNextChar.AutoSize = True
        Me.lblNextChar.Location = New System.Drawing.Point(52, 214)
        Me.lblNextChar.Name = "lblNextChar"
        Me.lblNextChar.Size = New System.Drawing.Size(19, 19)
        Me.lblNextChar.TabIndex = 40
        Me.lblNextChar.Text = ">"
        '
        'lblPrevChar
        '
        Me.lblPrevChar.AutoSize = True
        Me.lblPrevChar.Location = New System.Drawing.Point(18, 214)
        Me.lblPrevChar.Name = "lblPrevChar"
        Me.lblPrevChar.Size = New System.Drawing.Size(19, 19)
        Me.lblPrevChar.TabIndex = 39
        Me.lblPrevChar.Text = "<"
        '
        'rdoFemale
        '
        Me.rdoFemale.AutoSize = True
        Me.rdoFemale.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoFemale.Location = New System.Drawing.Point(82, 171)
        Me.rdoFemale.Name = "rdoFemale"
        Me.rdoFemale.Size = New System.Drawing.Size(101, 27)
        Me.rdoFemale.TabIndex = 38
        Me.rdoFemale.TabStop = True
        Me.rdoFemale.Text = "Feminino"
        Me.rdoFemale.UseVisualStyleBackColor = True
        '
        'rdoMale
        '
        Me.rdoMale.AutoSize = True
        Me.rdoMale.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoMale.Location = New System.Drawing.Point(82, 146)
        Me.rdoMale.Name = "rdoMale"
        Me.rdoMale.Size = New System.Drawing.Size(108, 27)
        Me.rdoMale.TabIndex = 37
        Me.rdoMale.TabStop = True
        Me.rdoMale.Text = "Masculino"
        Me.rdoMale.UseVisualStyleBackColor = True
        '
        'cmbClass
        '
        Me.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClass.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbClass.FormattingEnabled = True
        Me.cmbClass.Location = New System.Drawing.Point(85, 87)
        Me.cmbClass.Name = "cmbClass"
        Me.cmbClass.Size = New System.Drawing.Size(299, 29)
        Me.cmbClass.TabIndex = 36
        '
        'lblNewCharGender
        '
        Me.lblNewCharGender.AutoSize = True
        Me.lblNewCharGender.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewCharGender.Location = New System.Drawing.Point(81, 124)
        Me.lblNewCharGender.Name = "lblNewCharGender"
        Me.lblNewCharGender.Size = New System.Drawing.Size(75, 23)
        Me.lblNewCharGender.TabIndex = 34
        Me.lblNewCharGender.Text = "Genero :"
        '
        'lblNewCharClass
        '
        Me.lblNewCharClass.AutoSize = True
        Me.lblNewCharClass.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewCharClass.Location = New System.Drawing.Point(22, 88)
        Me.lblNewCharClass.Name = "lblNewCharClass"
        Me.lblNewCharClass.Size = New System.Drawing.Size(66, 23)
        Me.lblNewCharClass.TabIndex = 33
        Me.lblNewCharClass.Text = "Classe :"
        '
        'txtCharName
        '
        Me.txtCharName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCharName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCharName.Location = New System.Drawing.Point(85, 45)
        Me.txtCharName.Name = "txtCharName"
        Me.txtCharName.Size = New System.Drawing.Size(299, 29)
        Me.txtCharName.TabIndex = 32
        '
        'lblNewCharName
        '
        Me.lblNewCharName.AutoSize = True
        Me.lblNewCharName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewCharName.ForeColor = System.Drawing.Color.White
        Me.lblNewCharName.Location = New System.Drawing.Point(22, 48)
        Me.lblNewCharName.Name = "lblNewCharName"
        Me.lblNewCharName.Size = New System.Drawing.Size(66, 23)
        Me.lblNewCharName.TabIndex = 31
        Me.lblNewCharName.Text = "Nome :"
        '
        'lblNewChar
        '
        Me.lblNewChar.AutoSize = True
        Me.lblNewChar.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewChar.ForeColor = System.Drawing.Color.White
        Me.lblNewChar.Location = New System.Drawing.Point(115, 12)
        Me.lblNewChar.Name = "lblNewChar"
        Me.lblNewChar.Size = New System.Drawing.Size(191, 23)
        Me.lblNewChar.TabIndex = 30
        Me.lblNewChar.Text = "Criação de personagem"
        '
        'lblStatusHeader
        '
        Me.lblStatusHeader.AutoSize = True
        Me.lblStatusHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusHeader.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusHeader.ForeColor = System.Drawing.Color.White
        Me.lblStatusHeader.Location = New System.Drawing.Point(12, 9)
        Me.lblStatusHeader.Name = "lblStatusHeader"
        Me.lblStatusHeader.Size = New System.Drawing.Size(113, 19)
        Me.lblStatusHeader.TabIndex = 44
        Me.lblStatusHeader.Text = "Conectividade :"
        '
        'lblServerStatus
        '
        Me.lblServerStatus.AutoSize = True
        Me.lblServerStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblServerStatus.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServerStatus.ForeColor = System.Drawing.Color.Red
        Me.lblServerStatus.Location = New System.Drawing.Point(119, 9)
        Me.lblServerStatus.Name = "lblServerStatus"
        Me.lblServerStatus.Size = New System.Drawing.Size(54, 19)
        Me.lblServerStatus.TabIndex = 45
        Me.lblServerStatus.Text = "Offline"
        '
        'pnlMainMenu
        '
        Me.pnlMainMenu.BackColor = System.Drawing.Color.Transparent
        Me.pnlMainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlMainMenu.Controls.Add(Me.lblNewsHeader)
        Me.pnlMainMenu.Controls.Add(Me.lblNews)
        Me.pnlMainMenu.ForeColor = System.Drawing.Color.White
        Me.pnlMainMenu.Location = New System.Drawing.Point(312, 229)
        Me.pnlMainMenu.Name = "pnlMainMenu"
        Me.pnlMainMenu.Size = New System.Drawing.Size(400, 303)
        Me.pnlMainMenu.TabIndex = 56
        '
        'lblNewsHeader
        '
        Me.lblNewsHeader.AutoSize = True
        Me.lblNewsHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblNewsHeader.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewsHeader.Location = New System.Drawing.Point(94, 2)
        Me.lblNewsHeader.Name = "lblNewsHeader"
        Me.lblNewsHeader.Size = New System.Drawing.Size(281, 50)
        Me.lblNewsHeader.TabIndex = 56
        Me.lblNewsHeader.Text = "Ultimas noticias"
        '
        'lblNews
        '
        Me.lblNews.BackColor = System.Drawing.Color.Transparent
        Me.lblNews.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNews.Location = New System.Drawing.Point(17, 43)
        Me.lblNews.Name = "lblNews"
        Me.lblNews.Size = New System.Drawing.Size(366, 138)
        Me.lblNews.TabIndex = 56
        Me.lblNews.Text = resources.GetString("lblNews.Text")
        Me.lblNews.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'picLogo
        '
        Me.picLogo.BackColor = System.Drawing.Color.Transparent
        Me.picLogo.BackgroundImage = CType(resources.GetObject("picLogo.BackgroundImage"), System.Drawing.Image)
        Me.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picLogo.Location = New System.Drawing.Point(314, 95)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(396, 111)
        Me.picLogo.TabIndex = 52
        Me.picLogo.TabStop = False
        '
        'btnPlay
        '
        Me.btnPlay.BackColor = System.Drawing.Color.Transparent
        Me.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnPlay.FlatAppearance.BorderSize = 0
        Me.btnPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlay.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlay.ForeColor = System.Drawing.Color.White
        Me.btnPlay.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnPlay.Location = New System.Drawing.Point(196, 577)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(150, 37)
        Me.btnPlay.TabIndex = 53
        Me.btnPlay.Text = "Entrar"
        Me.btnPlay.UseVisualStyleBackColor = False
        '
        'btnRegister
        '
        Me.btnRegister.BackColor = System.Drawing.Color.Transparent
        Me.btnRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRegister.FlatAppearance.BorderSize = 0
        Me.btnRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegister.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegister.ForeColor = System.Drawing.Color.White
        Me.btnRegister.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnRegister.Location = New System.Drawing.Point(352, 577)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(150, 37)
        Me.btnRegister.TabIndex = 54
        Me.btnRegister.Text = "Criar Nova Conta"
        Me.btnRegister.UseVisualStyleBackColor = False
        '
        'btnCredits
        '
        Me.btnCredits.BackColor = System.Drawing.Color.Transparent
        Me.btnCredits.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCredits.FlatAppearance.BorderSize = 0
        Me.btnCredits.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnCredits.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnCredits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCredits.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCredits.ForeColor = System.Drawing.Color.White
        Me.btnCredits.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnCredits.Location = New System.Drawing.Point(508, 577)
        Me.btnCredits.Name = "btnCredits"
        Me.btnCredits.Size = New System.Drawing.Size(150, 37)
        Me.btnCredits.TabIndex = 55
        Me.btnCredits.Text = "Créditos"
        Me.btnCredits.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.White
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnExit.Location = New System.Drawing.Point(664, 577)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(150, 37)
        Me.btnExit.TabIndex = 56
        Me.btnExit.Text = "Sair"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'pnlLoad
        '
        Me.pnlLoad.BackgroundImage = CType(resources.GetObject("pnlLoad.BackgroundImage"), System.Drawing.Image)
        Me.pnlLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlLoad.Controls.Add(Me.lblStatus)
        Me.pnlLoad.Location = New System.Drawing.Point(-2, 1)
        Me.pnlLoad.Name = "pnlLoad"
        Me.pnlLoad.Size = New System.Drawing.Size(18, 17)
        Me.pnlLoad.TabIndex = 58
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(224, 261)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(280, 30)
        Me.lblStatus.TabIndex = 1
        Me.lblStatus.Text = "Loading text"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picMMODEV
        '
        Me.picMMODEV.BackColor = System.Drawing.Color.Transparent
        Me.picMMODEV.BackgroundImage = CType(resources.GetObject("picMMODEV.BackgroundImage"), System.Drawing.Image)
        Me.picMMODEV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picMMODEV.Location = New System.Drawing.Point(876, 12)
        Me.picMMODEV.Name = "picMMODEV"
        Me.picMMODEV.Size = New System.Drawing.Size(118, 26)
        Me.picMMODEV.TabIndex = 61
        Me.picMMODEV.TabStop = False
        '
        'FrmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1006, 721)
        Me.Controls.Add(Me.pnlCredits)
        Me.Controls.Add(Me.pnlNewChar)
        Me.Controls.Add(Me.pnlCharSelect)
        Me.Controls.Add(Me.pnlRegister)
        Me.Controls.Add(Me.picMMODEV)
        Me.Controls.Add(Me.pnlLogin)
        Me.Controls.Add(Me.pnlLoad)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnCredits)
        Me.Controls.Add(Me.btnRegister)
        Me.Controls.Add(Me.btnPlay)
        Me.Controls.Add(Me.lblServerStatus)
        Me.Controls.Add(Me.lblStatusHeader)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.pnlMainMenu)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMenu"
        Me.pnlLogin.ResumeLayout(False)
        Me.pnlLogin.PerformLayout()
        Me.pnlRegister.ResumeLayout(False)
        Me.pnlRegister.PerformLayout()
        Me.pnlCharSelect.ResumeLayout(False)
        Me.pnlCharSelect.PerformLayout()
        CType(Me.picChar3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picChar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picChar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCredits.ResumeLayout(False)
        Me.pnlCredits.PerformLayout()
        Me.pnlNewChar.ResumeLayout(False)
        Me.pnlNewChar.PerformLayout()
        CType(Me.placeholderforsprite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMainMenu.ResumeLayout(False)
        Me.pnlMainMenu.PerformLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLoad.ResumeLayout(False)
        CType(Me.picMMODEV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlLogin As System.Windows.Forms.Panel
    Friend WithEvents chkSavePass As System.Windows.Forms.CheckBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblLoginPass As System.Windows.Forms.Label
    Friend WithEvents txtLogin As System.Windows.Forms.TextBox
    Friend WithEvents lblLoginName As System.Windows.Forms.Label
    Friend WithEvents pnlRegister As System.Windows.Forms.Panel
    Friend WithEvents txtRPass2 As System.Windows.Forms.TextBox
    Friend WithEvents lblNewAccPass2 As System.Windows.Forms.Label
    Friend WithEvents txtRPass As System.Windows.Forms.TextBox
    Friend WithEvents lblNewAccPass As System.Windows.Forms.Label
    Friend WithEvents txtRuser As System.Windows.Forms.TextBox
    Friend WithEvents lblNewAccName As System.Windows.Forms.Label
    Friend WithEvents pnlCredits As System.Windows.Forms.Panel
    Friend WithEvents lblCreditsTop As System.Windows.Forms.Label
    Friend WithEvents lblScrollingCredits As System.Windows.Forms.Label
    Friend WithEvents tmrCredits As System.Windows.Forms.Timer
    Friend WithEvents pnlNewChar As System.Windows.Forms.Panel
    Friend WithEvents placeholderforsprite As System.Windows.Forms.PictureBox
    Friend WithEvents lblNextChar As System.Windows.Forms.Label
    Friend WithEvents lblPrevChar As System.Windows.Forms.Label
    Friend WithEvents rdoFemale As System.Windows.Forms.RadioButton
    Friend WithEvents rdoMale As System.Windows.Forms.RadioButton
    Friend WithEvents cmbClass As System.Windows.Forms.ComboBox
    Friend WithEvents lblNewCharGender As System.Windows.Forms.Label
    Friend WithEvents lblNewCharClass As System.Windows.Forms.Label
    Friend WithEvents txtCharName As System.Windows.Forms.TextBox
    Friend WithEvents lblNewCharName As System.Windows.Forms.Label
    Friend WithEvents lblNewChar As System.Windows.Forms.Label
    Friend WithEvents lblStatusHeader As System.Windows.Forms.Label
    Friend WithEvents lblServerStatus As System.Windows.Forms.Label
    Friend WithEvents pnlMainMenu As System.Windows.Forms.Panel
    Friend WithEvents lblNewsHeader As System.Windows.Forms.Label
    Friend WithEvents lblNews As System.Windows.Forms.Label
    Friend WithEvents picLogo As Windows.Forms.PictureBox
    Friend WithEvents btnLogin As Windows.Forms.Button
    Friend WithEvents btnCreateAccount As Windows.Forms.Button
    Friend WithEvents btnPlay As Windows.Forms.Button
    Friend WithEvents btnRegister As Windows.Forms.Button
    Friend WithEvents btnCredits As Windows.Forms.Button
    Friend WithEvents btnExit As Windows.Forms.Button
    Friend WithEvents btnCreateCharacter As Windows.Forms.Button
    Friend WithEvents pnlCharSelect As Windows.Forms.Panel
    Friend WithEvents lblCharSelect As Windows.Forms.Label
    Friend WithEvents Label16 As Windows.Forms.Label
    Friend WithEvents picChar3 As Windows.Forms.PictureBox
    Friend WithEvents picChar2 As Windows.Forms.PictureBox
    Friend WithEvents picChar1 As Windows.Forms.PictureBox
    Friend WithEvents btnDelChar As Windows.Forms.Button
    Friend WithEvents btnNewChar As Windows.Forms.Button
    Friend WithEvents btnUseChar As Windows.Forms.Button
    Friend WithEvents txtDescription As Windows.Forms.TextBox
    Friend WithEvents lblNewCharSprite As Windows.Forms.Label
    Friend WithEvents pnlLoad As Windows.Forms.Panel
    Friend WithEvents lblStatus As Windows.Forms.Label
    Friend WithEvents picMMODEV As PictureBox
End Class
