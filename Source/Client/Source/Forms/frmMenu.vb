Imports System.IO
Imports ASFW

Friend Class FrmMenu
    Inherits Form

    Private CustomText As Drawing.Text.PrivateFontCollection = New Drawing.Text.PrivateFontCollection
    Private ButtonNormalColor As Color
    Private ButtonHoverColor As Color

#Region "Form Functions"

    ''' <summary>
    ''' limpar e fechar o jogo.
    ''' </summary>
    Private Sub FrmMenu_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        DestroyGame()
    End Sub

    ''' <summary>
    ''' Ao carregar, preparar interface de usuário.
    ''' </summary>
    Private Sub Frmmenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadMenuGraphics()
        pnlLoad.Width = Width
        pnlLoad.Height = Height
        lblStatus.Left = Width / 2 - lblStatus.Width / 2
        lblStatus.Top = Height / 2 - lblStatus.Height / 2

        If Started = False Then Call Startup()

        Connect()

    End Sub

    ''' <summary>
    ''' Desenhar seleção de personagem quando necessário.
    ''' </summary>
    Private Sub PnlCharSelect_VisibleChanged(sender As Object, e As EventArgs) Handles pnlCharSelect.VisibleChanged
        DrawCharacterSelect()
    End Sub

#End Region

#Region "Draw Functions"

    Friend Sub LoadMenuFont()
        Dim fontPath As String = Path.Gui & "Menu\OpenSans-Regular.ttf"

        If File.Exists(fontPath) Then
            CustomText.AddFontFile(fontPath)

            btnPlay.Font = New Font(CustomText.Families(0), btnPlay.Font.Size, FontStyle.Regular)
            btnRegister.Font = New Font(CustomText.Families(0), btnRegister.Font.Size, FontStyle.Regular)
            btnCredits.Font = New Font(CustomText.Families(0), btnCredits.Font.Size, FontStyle.Regular)
            btnExit.Font = New Font(CustomText.Families(0), btnExit.Font.Size, FontStyle.Regular)
            lblNews.Font = New Font(CustomText.Families(0), lblNews.Font.Size, FontStyle.Regular)
            lblStatusHeader.Font = New Font(CustomText.Families(0), lblStatusHeader.Font.Size, FontStyle.Regular)
            lblServerStatus.Font = New Font(CustomText.Families(0), lblServerStatus.Font.Size, FontStyle.Regular)
            lblStatus.Font = New Font(CustomText.Families(0), lblStatus.Font.Size, FontStyle.Regular)
            lblLoginPass.Font = New Font(CustomText.Families(0), lblLoginPass.Font.Size, FontStyle.Regular)
            lblLoginName.Font = New Font(CustomText.Families(0), lblLoginName.Font.Size, FontStyle.Regular)
            lblNewAccPass2.Font = New Font(CustomText.Families(0), lblNewAccPass2.Font.Size, FontStyle.Regular)
            lblNewAccPass.Font = New Font(CustomText.Families(0), lblNewAccPass.Font.Size, FontStyle.Regular)
            lblNewAccName.Font = New Font(CustomText.Families(0), lblNewAccName.Font.Size, FontStyle.Regular)
            lblCreditsTop.Font = New Font(CustomText.Families(0), lblCreditsTop.Font.Size, FontStyle.Regular)
            lblScrollingCredits.Font = New Font(CustomText.Families(0), lblScrollingCredits.Font.Size, FontStyle.Regular)
            lblNextChar.Font = New Font(CustomText.Families(0), lblNextChar.Font.Size, FontStyle.Regular)
            lblPrevChar.Font = New Font(CustomText.Families(0), lblPrevChar.Font.Size, FontStyle.Regular)
            lblNewCharGender.Font = New Font(CustomText.Families(0), lblNewCharGender.Font.Size, FontStyle.Regular)
            lblNewCharClass.Font = New Font(CustomText.Families(0), lblNewCharClass.Font.Size, FontStyle.Regular)
            lblNewCharName.Font = New Font(CustomText.Families(0), lblNewCharName.Font.Size, FontStyle.Regular)
            lblNewChar.Font = New Font(CustomText.Families(0), lblNewChar.Font.Size, FontStyle.Regular)
            lblNewsHeader.Font = New Font(CustomText.Families(0), lblNewsHeader.Font.Size, FontStyle.Regular)
            lblCharSelect.Font = New Font(CustomText.Families(0), lblCharSelect.Font.Size, FontStyle.Regular)
            lblNewCharSprite.Font = New Font(CustomText.Families(0), lblNewCharSprite.Font.Size, FontStyle.Regular)
            chkSavePass.Font = New Font(CustomText.Families(0), chkSavePass.Font.Size, FontStyle.Regular)

            btnLogin.Font = New Font(CustomText.Families(0), btnLogin.Font.Size, FontStyle.Bold)
            btnCreateAccount.Font = New Font(CustomText.Families(0), btnCreateAccount.Font.Size, FontStyle.Bold)
            btnCreateCharacter.Font = New Font(CustomText.Families(0), btnCreateCharacter.Font.Size, FontStyle.Bold)
            btnDelChar.Font = New Font(CustomText.Families(0), btnDelChar.Font.Size, FontStyle.Bold)
            btnNewChar.Font = New Font(CustomText.Families(0), btnNewChar.Font.Size, FontStyle.Bold)
            btnUseChar.Font = New Font(CustomText.Families(0), btnUseChar.Font.Size, FontStyle.Bold)

            txtPassword.Font = New Font(CustomText.Families(0), txtPassword.Font.Size, FontStyle.Bold)
            txtLogin.Font = New Font(CustomText.Families(0), txtLogin.Font.Size, FontStyle.Bold)
            txtRPass2.Font = New Font(CustomText.Families(0), txtRPass2.Font.Size, FontStyle.Bold)
            txtRPass.Font = New Font(CustomText.Families(0), txtRPass.Font.Size, FontStyle.Bold)
            txtRuser.Font = New Font(CustomText.Families(0), txtRuser.Font.Size, FontStyle.Bold)
            txtCharName.Font = New Font(CustomText.Families(0), txtCharName.Font.Size, FontStyle.Bold)
            txtDescription.Font = New Font(CustomText.Families(0), txtDescription.Font.Size, FontStyle.Bold)
        End If
    End Sub

    ''' <summary>
    ''' Precarregar imagens no menu.
    ''' </summary>
    Friend Sub LoadMenuGraphics()

        LoadMenuFont()

        'Menu Principal
        If File.Exists(Path.Gui & "Menu\menu" & GfxExt) Then
            BackgroundImage = Image.FromFile(Path.Gui & "Menu\menu" & GfxExt)
        End If

        'Botões do Menu Principal
        If File.Exists(Path.Gui & "Menu\button" & GfxExt) Then
            btnLogin.BackgroundImage = Image.FromFile(Path.Gui & "Menu\button" & GfxExt)
            btnNewChar.BackgroundImage = Image.FromFile(Path.Gui & "Menu\button" & GfxExt)
            btnUseChar.BackgroundImage = Image.FromFile(Path.Gui & "Menu\button" & GfxExt)
            btnDelChar.BackgroundImage = Image.FromFile(Path.Gui & "Menu\button" & GfxExt)
            btnCreateAccount.BackgroundImage = Image.FromFile(Path.Gui & "Menu\button" & GfxExt)
        End If

        'logo
        If File.Exists(Path.Gui & "Menu\logo" & GfxExt) Then
            picLogo.BackgroundImage = Image.FromFile(Path.Gui & "Menu\logo" & GfxExt)
        End If

        ' MMODEV
        If Debugger.IsAttached Then
            If File.Exists(Path.Gui & "Menu\MMODEV" & GfxExt) Then
                picMMODEV.BackgroundImage = Image.FromFile(Path.Gui & "Menu\MMODEV" & GfxExt)
            End If
        End If

        ' Principal
        lblStatusHeader.Text = Language.MainMenu.ServerStatus
        lblNewsHeader.Text = Language.MainMenu.NewsHeader
        lblNews.Text = Language.MainMenu.News
        btnPlay.Text = Language.MainMenu.ButtonPlay
        btnRegister.Text = Language.MainMenu.ButtonRegister
        btnCredits.Text = Language.MainMenu.ButtonCredits
        btnExit.Text = Language.MainMenu.ButtonExit

        ' Login
        lblLoginName.Text = Language.MainMenu.LoginName.ToUpper
        lblLoginPass.Text = Language.MainMenu.LoginPass.ToUpper
        chkSavePass.Text = Language.MainMenu.LoginCheckBox
        btnLogin.Text = Language.MainMenu.LoginButton.ToUpper

        ' Novo personagem
        lblNewChar.Text = Language.MainMenu.NewCharacter
        lblNewCharName.Text = Language.MainMenu.NewCharacterName
        lblNewCharClass.Text = Language.MainMenu.NewCharacterClass
        lblNewCharGender.Text = Language.MainMenu.NewCharacterGender
        rdoMale.Text = Language.MainMenu.NewCharacterMale
        rdoFemale.Text = Language.MainMenu.NewCharacterFemale
        lblNewCharSprite.Text = Language.MainMenu.NewCharacterSprite
        btnCreateCharacter.Text = Language.MainMenu.NewCharacterButton.ToUpper

        ' Usar personagem
        lblCharSelect.Text = Language.MainMenu.UseCharacter
        btnNewChar.Text = Language.MainMenu.UseCharacterNew.ToUpper
        btnUseChar.Text = Language.MainMenu.UseCharacterUse.ToUpper
        btnDelChar.Text = Language.MainMenu.UseCharacterDel.ToUpper

        ' Registro
        lblNewAccName.Text = Language.MainMenu.RegisterName.ToUpper
        lblNewAccPass.Text = Language.MainMenu.RegisterPass.ToUpper
        lblNewAccPass2.Text = Language.MainMenu.RetypeRegisterPass.ToUpper

        ' Creditos
        lblCreditsTop.Text = Language.MainMenu.Credits

        ButtonNormalColor = ColorTranslator.FromHtml("#ffffff")
        ButtonHoverColor = ColorTranslator.FromHtml("#05c593")
    End Sub

    ''' <summary>
    ''' Desenhar personagem para nova criação.
    ''' </summary>
    Sub DrawCharacter()
        If pnlNewChar.Visible = True Then
            Dim g As Graphics = pnlNewChar.CreateGraphics
            Dim filename As String
            Dim srcRect As Rectangle
            Dim destRect As Rectangle
            Dim charwidth As Integer
            Dim charheight As Integer

            If NewCharClass = 0 Then NewCharClass = 1
            If NewCharSprite = 0 Then NewCharSprite = 1

            If rdoMale.Checked = True Then
                filename = Path.Graphics & "Personagens\" & Classes(NewCharClass).MaleSprite(NewCharSprite) & GfxExt
            Else
                filename = Path.Graphics & "Personagens\" & Classes(NewCharClass).FemaleSprite(NewCharSprite) & GfxExt
            End If

            Dim charsprite As Bitmap = New Bitmap(filename)

            charwidth = charsprite.Width / 4
            charheight = charsprite.Height / 4

            srcRect = New Rectangle(0, 0, charwidth, charheight)
            destRect = New Rectangle(placeholderforsprite.Left, placeholderforsprite.Top, charwidth, charheight)

            charsprite.MakeTransparent(charsprite.GetPixel(0, 0))

            If charwidth > 32 Then
                Lblnextcharleft = (100 - (64 - charwidth))
            Else
                Lblnextcharleft = 100
            End If
            pnlNewChar.Refresh()
            g.DrawImage(charsprite, destRect, srcRect, GraphicsUnit.Pixel)
            g.Dispose()
        End If
    End Sub

    ''' <summary>
    ''' Desenhar personagem para tela de seleção de personagens.
    ''' </summary>
    Sub DrawCharacterSelect()
        Dim g As Graphics
        Dim srcRect As Rectangle
        Dim destRect As Rectangle

        If pnlCharSelect.Visible = True Then
            Dim filename As String
            Dim charwidth As Integer, charheight As Integer

            'primeiro
            If CharSelection(1).Sprite > 0 Then
                g = picChar1.CreateGraphics

                filename = Path.Graphics & "Personagens\" & CharSelection(1).Sprite & GfxExt

                Dim charsprite As Bitmap = New Bitmap(filename)

                charwidth = charsprite.Width / 4
                charheight = charsprite.Height / 4

                srcRect = New Rectangle(0, 0, charwidth, charheight)
                destRect = New Rectangle(0, 0, charwidth, charheight)

                charsprite.MakeTransparent(charsprite.GetPixel(0, 0))

                picChar1.Refresh()
                g.DrawImage(charsprite, destRect, srcRect, GraphicsUnit.Pixel)

                If SelectedChar = 1 Then
                    g.DrawRectangle(Pens.Red, New Rectangle(0, 0, charwidth - 1, charheight))
                End If

                g.Dispose()
            Else
                picChar1.BorderStyle = BorderStyle.FixedSingle
                picChar1.Refresh()
            End If

            '2o
            If CharSelection(2).Sprite > 0 Then
                g = picChar2.CreateGraphics

                filename = Path.Graphics & "Personagens\" & CharSelection(2).Sprite & GfxExt

                Dim charsprite As Bitmap = New Bitmap(filename)

                charwidth = charsprite.Width / 4
                charheight = charsprite.Height / 4

                srcRect = New Rectangle(0, 0, charwidth, charheight)
                destRect = New Rectangle(0, 0, charwidth, charheight)

                charsprite.MakeTransparent(charsprite.GetPixel(0, 0))

                picChar2.Refresh()
                g.DrawImage(charsprite, destRect, srcRect, GraphicsUnit.Pixel)

                If SelectedChar = 2 Then
                    g.DrawRectangle(Pens.Red, New Rectangle(0, 0, charwidth - 1, charheight))
                End If

                g.Dispose()
            Else
                picChar2.BorderStyle = BorderStyle.FixedSingle
                picChar2.Refresh()
            End If

            'terceiro
            If CharSelection(3).Sprite > 0 Then
                g = picChar3.CreateGraphics

                filename = Path.Graphics & "Personagens\" & CharSelection(3).Sprite & GfxExt

                Dim charsprite As Bitmap = New Bitmap(filename)

                charwidth = charsprite.Width / 4
                charheight = charsprite.Height / 4

                srcRect = New Rectangle(0, 0, charwidth, charheight)
                destRect = New Rectangle(0, 0, charwidth, charheight)

                charsprite.MakeTransparent(charsprite.GetPixel(0, 0))

                picChar3.Refresh()
                g.DrawImage(charsprite, destRect, srcRect, GraphicsUnit.Pixel)

                If SelectedChar = 3 Then
                    g.DrawRectangle(Pens.Red, New Rectangle(0, 0, charwidth - 1, charheight))
                End If

                g.Dispose()
            Else
                picChar3.BorderStyle = BorderStyle.FixedSingle
                picChar3.Refresh()
            End If

        End If
    End Sub

    ''' <summary>
    ''' Parar o painel de novo personagem de se repintar.
    ''' </summary>
    Private Sub PnlNewChar_Paint(sender As Object, e As PaintEventArgs) Handles pnlNewChar.Paint
        'nada aqui
    End Sub

#End Region

#Region "Credits"

    ''' <summary>
    ''' Este temporizador lida com os créditos deslizantes.
    ''' </summary>
    Private Sub TmrCredits_Tick(sender As Object, e As EventArgs) Handles tmrCredits.Tick
        Dim credits As String
        Dim filepath As String
        filepath = Application.StartupPath & "\Dados\Creditos.txt"
        lblScrollingCredits.Top = 177
        If PnlCreditsVisible = True Then
            tmrCredits.Enabled = False
            credits = GetFileContents(filepath)
            lblScrollingCredits.Text = "" & vbNewLine & credits
            Do Until PnlCreditsVisible = False
                lblScrollingCredits.Top = lblScrollingCredits.Top - 1
                If lblScrollingCredits.Bottom <= lblCreditsTop.Bottom Then
                    lblScrollingCredits.Top = 177
                End If
                Application.DoEvents()
                Threading.Thread.Sleep(100)
            Loop
        End If
    End Sub

#End Region

#Region "Login"

    ''' <summary>
    ''' Lidar com o enter no txtbox do nome de login.
    ''' </summary>
    Private Sub TxtLogin_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLogin.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnLogin_Click(Me, Nothing)
        End If
    End Sub

    ''' <summary>
    ''' Lidar com o pressionamento do enter nas caixas de texto de senha.
    ''' </summary>
    Private Sub TxtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnLogin_Click(Me, Nothing)
        End If
    End Sub

    ''' <summary>
    ''' Lidar com a caixa de salvar senha.
    ''' </summary>
    Private Sub ChkSavePass_CheckedChanged(sender As Object, e As EventArgs) Handles chkSavePass.CheckedChanged
        ChkSavePassChecked = chkSavePass.Checked
    End Sub

#End Region

#Region "Char Creation"

    ''' <summary>
    ''' Mudar classes selecionadas.
    ''' </summary>
    Private Sub CmbClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClass.SelectedIndexChanged
        NewCharClass = cmbClass.SelectedIndex + 1
        NewCharSprite = 0
        txtDescription.Text = Classes(NewCharClass).Desc
        DrawCharacter()
    End Sub

    ''' <summary>
    ''' Troca para o gênero masculino.
    ''' </summary>
    Private Sub RdoMale_CheckedChanged(sender As Object, e As EventArgs) Handles rdoMale.CheckedChanged
        DrawCharacter()
    End Sub

    ''' <summary>
    ''' Troca para o fêmalo feminino.
    ''' </summary>
    Private Sub RdoFemale_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFemale.CheckedChanged
        DrawCharacter()
    End Sub

    ''' <summary>
    ''' Troca sprite para a classe selecionada para a próxima, se houver
    ''' </summary>
    Private Sub LblNextChar_Click(sender As Object, e As EventArgs) Handles lblNextChar.Click
        NewCharSprite = NewCharSprite + 1
        If rdoMale.Checked = True Then
            If NewCharSprite > Classes(NewCharClass).MaleSprite.Length - 1 Then NewCharSprite = 1
        ElseIf rdoFemale.Checked = True Then
            If NewCharSprite > Classes(NewCharClass).FemaleSprite.Length - 1 Then NewCharSprite = 1
        End If
        DrawCharacter()
    End Sub

    ''' <summary>
    ''' Troca sprite para a classe selecionada para a anterior, se houver
    ''' </summary>
    Private Sub LblPrevChar_Click(sender As Object, e As EventArgs) Handles lblPrevChar.Click
        NewCharSprite = NewCharSprite - 1
        If rdoMale.Checked = True Then
            If NewCharSprite = 0 Then NewCharSprite = Classes(NewCharClass).MaleSprite.Length - 1
        ElseIf rdoFemale.Checked = True Then
            If NewCharSprite = 0 Then NewCharSprite = Classes(NewCharClass).FemaleSprite.Length - 1
        End If
        DrawCharacter()
    End Sub

    ''' <summary>
    ''' Desenho inicial do novo personagem.
    ''' </summary>
    Private Sub PnlNewChar_VisibleChanged(sender As Object, e As EventArgs) Handles pnlNewChar.VisibleChanged
        DrawCharacter()
    End Sub

#End Region

#Region "Buttons"

    ''' <summary>
    ''' Lidar com o botão de Jogar.
    ''' </summary>
    Private Sub BtnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        If Socket.IsConnected() = True Then
            PlaySound("Click.ogg")
            PnlRegisterVisible = False
            PnlLoginVisible = True
            PnlCharCreateVisible = False
            PnlCreditsVisible = False
            txtLogin.Focus()
            If Settings.SavePass = True Then
                txtLogin.Text = Settings.Username
                txtPassword.Text = Settings.Password
                chkSavePass.Checked = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' Lida com o botão de Registrar.
    ''' </summary>
    Private Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        If Socket.IsConnected() = True Then
            PlaySound("Click.ogg")
            PnlRegisterVisible = True
            PnlLoginVisible = False
            PnlCharCreateVisible = False
            PnlCreditsVisible = False
        End If
    End Sub

    ''' <summary>
    ''' Lida com o botão de créditos.
    ''' </summary>
    Private Sub BtnCredits_Click(sender As Object, e As EventArgs) Handles btnCredits.Click
        PlaySound("Click.ogg")
        If PnlCreditsVisible = False Then
            tmrCredits.Enabled = True
        End If
        PnlCreditsVisible = True
        PnlLoginVisible = False
        PnlRegisterVisible = False
        PnlCharCreateVisible = False
    End Sub

    ''' <summary>
    ''' Lida com o botão de sair.
    ''' </summary>
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        PlaySound("Click.ogg")
        DestroyGame()
    End Sub

    ''' <summary>
    ''' Lida com o botão de login.
    ''' </summary>
    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If IsLoginLegal(txtLogin.Text, txtPassword.Text) Then
            MenuState(MenuStateLogin)
        End If
    End Sub

    ''' <summary>
    ''' Muda o botão para o estado de hover..
    ''' </summary>
    Private Sub BtnLogin_MouseEnter(sender As Object, e As EventArgs) Handles btnLogin.MouseEnter
        btnLogin.BackgroundImage = Image.FromFile(Path.Gui & "Menu\button_hover" & GfxExt)
    End Sub

    ''' <summary>
    ''' Muda o botão para o estado normal.
    ''' </summary>
    Private Sub BtnLogin_MouseLeave(sender As Object, e As EventArgs) Handles btnLogin.MouseLeave
        btnLogin.BackgroundImage = Image.FromFile(Path.Gui & "Menu\button" & GfxExt)
    End Sub

    ''' <summary>
    ''' Lida com o botão de Criar conta.
    ''' </summary>
    Private Sub BtnCreateAccount_Click(sender As Object, e As EventArgs) Handles btnCreateAccount.Click
        Dim name As String
        Dim password As String
        Dim passwordAgain As String
        name = Trim$(txtRuser.Text)
        password = Trim$(txtRPass.Text)
        passwordAgain = Trim$(txtRPass2.Text)

        If IsLoginLegal(name, password) Then
            If password <> passwordAgain Then
                MsgBox("As senhas não batem.")
                Exit Sub
            End If

            If Not IsStringLegal(name) Then Exit Sub

            MenuState(MenuStateNewaccount)
        End If
    End Sub

    ''' <summary>
    ''' Muda o botão para o estado de hover.
    ''' </summary>
    Private Sub BtnCreateAccount_MouseEnter(sender As Object, e As EventArgs) Handles btnCreateAccount.MouseEnter
        btnCreateAccount.BackgroundImage = Image.FromFile(Path.Gui & "Menu\button_hover" & GfxExt)
    End Sub

    ''' <summary>
    ''' Muda o botão para o estado normal.
    ''' </summary>
    Private Sub BtnCreateAccount_MouseLeave(sender As Object, e As EventArgs) Handles btnCreateAccount.MouseLeave
        btnCreateAccount.BackgroundImage = Image.FromFile(Path.Gui & "Menu\button" & GfxExt)
    End Sub

    ''' <summary>
    ''' Lida com o botão de criar personagem.
    ''' </summary>
    Private Sub BtnCreateCharacter_Click(sender As Object, e As EventArgs) Handles btnCreateCharacter.Click
        MenuState(MenuStateAddchar)
    End Sub

    ''' <summary>
    ''' Muda o botão para o estado de hover.
    ''' </summary>
    Private Sub BtnCreateCharacter_MouseEnter(sender As Object, e As EventArgs) Handles btnCreateCharacter.MouseEnter
        btnCreateCharacter.BackgroundImage = Image.FromFile(Path.Gui & "Menu\button_hover" & GfxExt)
    End Sub

    ''' <summary>
    ''' Muda o botão para o estado normal.
    ''' </summary>
    Private Sub BtnCreateCharacter_MouseLeave(sender As Object, e As EventArgs) Handles btnCreateCharacter.MouseLeave
        btnCreateCharacter.BackgroundImage = Image.FromFile(Path.Gui & "Menu\button" & GfxExt)
    End Sub

    ''' <summary>
    ''' Selecionar personagem 1.
    ''' </summary>
    Private Sub PicChar1_Click(sender As Object, e As EventArgs) Handles picChar1.Click
        SelectedChar = 1
        DrawCharacterSelect()
    End Sub

    ''' <summary>
    ''' Selecionar personagem 2.
    ''' </summary>
    Private Sub PicChar2_Click(sender As Object, e As EventArgs) Handles picChar2.Click
        SelectedChar = 2
        DrawCharacterSelect()
    End Sub

    ''' <summary>
    ''' Selecionar personagem 3.
    ''' </summary>
    Private Sub PicChar3_Click(sender As Object, e As EventArgs) Handles picChar3.Click
        SelectedChar = 3
        DrawCharacterSelect()
    End Sub

    ''' <summary>
    ''' Lida com o botão de novo personagem.
    ''' </summary>
    Private Sub BtnNewChar_Click(sender As Object, e As EventArgs) Handles btnNewChar.Click
        Dim i As Integer, newSelectedChar As Byte

        newSelectedChar = 0

        For i = 1 To MaxChars
            If CharSelection(i).Name = "" Then
                newSelectedChar = i
                Exit For
            End If
        Next

        If newSelectedChar > 0 Then
            SelectedChar = newSelectedChar
        End If

        PnlCharCreateVisible = True
        PnlCharSelectVisible = False
        DrawChar = True
    End Sub

    ''' <summary>
    ''' Lidar com o botão de usar personagem.
    ''' </summary>
    Private Sub BtnUseChar_Click(sender As Object, e As EventArgs) Handles btnUseChar.Click
        Pnlloadvisible = True
        Frmmenuvisible = False

        Dim buffer As ByteStream
        buffer = New ByteStream(8)
        buffer.WriteInt32(ClientPackets.CUseChar)
        buffer.WriteInt32(SelectedChar)
        Socket.SendData(buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    ''' <summary>
    ''' Lidar com o botão de apagar personagem.
    ''' </summary>
    Private Sub BtnDelChar_Click(sender As Object, e As EventArgs) Handles btnDelChar.Click
        Dim result1 As DialogResult = MessageBox.Show("Tem certeza que quer deletar o personagem " & SelectedChar & "?", "Tem certeza?", MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            Dim buffer As New ByteStream(4)
            buffer.WriteInt32(ClientPackets.CDelChar)
            buffer.WriteInt32(SelectedChar)
            Socket.SendData(buffer.Data, buffer.Head)
            buffer.Dispose()
        End If
    End Sub

    Private Sub lblNewCharName_Click(sender As Object, e As EventArgs) Handles lblNewCharName.Click

    End Sub

    Private Sub btnPlay_MouseEnter(sender As Object, e As EventArgs) Handles btnPlay.MouseEnter
        btnPlay.ForeColor = ButtonHoverColor
    End Sub

    Private Sub btnPlay_MouseLeave(sender As Object, e As EventArgs) Handles btnPlay.MouseLeave
        btnPlay.ForeColor = ButtonNormalColor
    End Sub

    Private Sub btnRegister_MouseEnter(sender As Object, e As EventArgs) Handles btnRegister.MouseEnter
        btnRegister.ForeColor = ButtonHoverColor
    End Sub

    Private Sub btnRegister_MouseLeave(sender As Object, e As EventArgs) Handles btnRegister.MouseLeave
        btnRegister.ForeColor = ButtonNormalColor
    End Sub

    Private Sub btnCredits_MouseEnter(sender As Object, e As EventArgs) Handles btnCredits.MouseEnter
        btnCredits.ForeColor = ButtonHoverColor
    End Sub

    Private Sub btnCredits_MouseLeave(sender As Object, e As EventArgs) Handles btnCredits.MouseLeave
        btnCredits.ForeColor = ButtonNormalColor
    End Sub

    Private Sub btnExit_MouseEnter(sender As Object, e As EventArgs) Handles btnExit.MouseEnter
        btnExit.ForeColor = ButtonHoverColor
    End Sub

    Private Sub btnExit_MouseLeave(sender As Object, e As EventArgs) Handles btnExit.MouseLeave
        btnExit.ForeColor = ButtonNormalColor
    End Sub

    Private Sub btnNewChar_MouseEnter(sender As Object, e As EventArgs) Handles btnNewChar.MouseEnter
        btnNewChar.BackgroundImage = Image.FromFile(Path.Gui & "Menu\button_hover" & GfxExt)
    End Sub

    Private Sub btnNewChar_MouseLeave(sender As Object, e As EventArgs) Handles btnNewChar.MouseLeave
        btnNewChar.BackgroundImage = Image.FromFile(Path.Gui & "Menu\button" & GfxExt)
    End Sub

    Private Sub btnUseChar_MouseEnter(sender As Object, e As EventArgs) Handles btnUseChar.MouseEnter
        btnUseChar.BackgroundImage = Image.FromFile(Path.Gui & "Menu\button_hover" & GfxExt)
    End Sub

    Private Sub btnUseChar_MouseLeave(sender As Object, e As EventArgs) Handles btnUseChar.MouseLeave
        btnUseChar.BackgroundImage = Image.FromFile(Path.Gui & "Menu\button" & GfxExt)
    End Sub

    Private Sub btnDelChar_MouseEnter(sender As Object, e As EventArgs) Handles btnDelChar.MouseEnter
        btnDelChar.BackgroundImage = Image.FromFile(Path.Gui & "Menu\button_hover" & GfxExt)
    End Sub

    Private Sub btnDelChar_MouseLeave(sender As Object, e As EventArgs) Handles btnDelChar.MouseLeave
        btnDelChar.BackgroundImage = Image.FromFile(Path.Gui & "Menu\button" & GfxExt)
    End Sub
#End Region

End Class