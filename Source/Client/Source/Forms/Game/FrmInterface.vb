Imports System.IO
Imports System.Linq
Imports Ini = ASFW.IO.FileIO.TextFile

Public Class FrmInterface
    Private Layout As Panel

    Private Sub TableLayoutPanel3_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel3.Paint

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbInterface_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbInterface.SelectedIndexChanged
        SetEditorEnabled(False)

        If cmbInterface.SelectedIndex >= 0 Then
            Try
                Dim cf As String = GetInterfacePath() & "\interface.ini"
                txtName.Text = Ini.Read(cf, "INFO", "Name")
                txtDesc.Text = Ini.Read(cf, "INFO", "Description")
                txtAuthor.Text = Ini.Read(cf, "INFO", "Author")
                UpdateLayoutList()
                SetEditorEnabled(True)
            Catch ex As Exception
                MsgBox("Houve uma falha ao carregar a interface: " & vbNewLine & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub SetEditorEnabled(enabled As Boolean)
        txtName.Enabled = enabled
        txtDesc.Enabled = enabled
        txtAuthor.Enabled = enabled
        btnSave.Enabled = enabled
        tbComponents.Enabled = enabled
        lvProperties.Enabled = enabled
    End Sub

    Private Sub FrmInterface_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateInterfaceList()
    End Sub

    Private Sub UpdateInterfaceList()
        cmbInterface.Items.Clear()

        Dim interfaces = Directory.GetDirectories(Path.Gui)

        For Each folder In interfaces
            cmbInterface.Items.Add(System.IO.Path.GetFileName(folder))
        Next
    End Sub
    Private Function GetInterfacePath() As String
        Return Path.Gui & "\" & cmbInterface.Text
    End Function

    Private Function GetInterfacePath(interfaceName As String) As String
        Return Path.Gui & "\" & interfaceName
    End Function

    Private Sub btnAddLayout_Click(sender As Object, e As EventArgs) Handles btnAddLayout.Click
        Dim layoutName = InputBox("Digite o nome do layout:")

        If Not String.IsNullOrEmpty(layoutName) Then
            If Not layoutName.Contains(".xml") Then
                layoutName = layoutName & ".xml"
            End If

            File.Create(GetInterfacePath() & "\" & layoutName)
            UpdateLayoutList()
        End If
    End Sub

    Private Sub UpdateLayoutList()
        cmbLayout.Items.Clear()

        Dim layouts = Directory.GetFiles(GetInterfacePath()).Where(Function(x) x.Contains(".xml"))

        For Each file In layouts
            cmbLayout.Items.Add(System.IO.Path.GetFileName(file))
        Next
    End Sub

    Private Sub cmbLayout_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLayout.SelectedIndexChanged
        If cmbLayout.SelectedIndex >= 0 Then
            LoadLayout(cmbLayout.Text)
        End If
    End Sub

    Private Sub LoadLayout(StrLayout As String)
        Try
            Dim filename = GetInterfacePath() & "\" & StrLayout

            'Mock
            Layout = New Panel()


        Catch ex As Exception

        End Try
    End Sub
End Class