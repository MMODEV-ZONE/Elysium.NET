Imports System.IO
Imports System.Linq
Imports System.Xml.Serialization
Imports Ini = ASFW.IO.FileIO.TextFile

Public Class FrmInterface
    Private Enum GUIComponents
        Label = 0
        Button
        TextBox
        Panel
        Grid
    End Enum

    Private Layout As GUIPanel

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
        cmbPropValue.Enabled = enabled
        btnEditProp.Enabled = enabled
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

            Dim newLayout = New GUIPanel With {
                    .Name = "Root"
                }

            SaveLayout(newLayout, layoutName)
            UpdateLayoutList()
        End If
    End Sub

    Private Sub UpdateLayoutList()
        Dim lastText As String = cmbLayout.Text
        cmbLayout.Items.Clear()

        Dim layouts = Directory.GetFiles(GetInterfacePath()).Where(Function(x) x.Contains(".xml"))

        For Each file In layouts
            cmbLayout.Items.Add(System.IO.Path.GetFileName(file))

            If System.IO.Path.GetFileName(file) = lastText Then cmbLayout.Text = lastText
        Next
    End Sub

    Private Sub UpdateComponentList()
        tvComponents.Nodes.Clear()

        Dim rootLayout = tvComponents.Nodes.Add(key:=Layout.Name, text:="Janela", imageIndex:=GUIComponents.Panel, selectedImageIndex:=GUIComponents.Panel)

        AddChildren(rootLayout, Layout.Children)

        tvComponents.ExpandAll()
    End Sub

    Private Function GetSelectedItem() As GUIObject
        If tvComponents.SelectedNode IsNot Nothing Then
            Dim component = FindGUIObject(tvComponents.SelectedNode.Name, Layout.Children)

            If tvComponents.SelectedNode.Name = "Root" Then
                component = Layout
            End If

            Return component
        End If
    End Function

    Private Sub UpdatePropertyList()
        lvProperties.Items.Clear()

        Dim component = GetSelectedItem()

        If component IsNot Nothing Then
            Dim permittedTypes As New List(Of String) From {
                "String",
                "Boolean",
                "Int32"
            }

            Dim fields = component.GetType().GetFields()
            Dim orderedFields = fields.OrderBy(Function(x) x.Name)

            For Each field In orderedFields
                If permittedTypes.Contains(field.FieldType.Name) And ((component IsNot Layout) Or field.Name <> "Name") Then
                    Dim item As New ListViewItem
                    item.SubItems.Insert(0, New ListViewItem.ListViewSubItem(item, field.Name))
                    item.SubItems.Insert(1, New ListViewItem.ListViewSubItem(item, If(field.GetValue(component) IsNot Nothing, field.GetValue(component).ToString(), If(field.FieldType.IsValueType, Activator.CreateInstance(field.FieldType), String.Empty))))

                    lvProperties.Items.Add(item)
                End If
            Next
        End If
    End Sub

    Function FindGUIObject(name As String, children As List(Of GUIObject)) As GUIObject
        If Not children Is Nothing And children.Count > 0 Then
            For Each child In children
                If child.Name = name Then Return child

                If child.GetType() Is GetType(GUIPanel) Then
                    Dim castedChild = DirectCast(child, GUIPanel)

                    Return FindGUIObject(name, castedChild.Children)
                End If
            Next
        End If
    End Function

    Private Sub AddChildren(tvNode As TreeNode, children As List(Of GUIObject))
        If Not children Is Nothing And children.Count > 0 Then
            For Each child In children
                Dim imageIndex As Byte

                Select Case child.GetType()
                    Case GetType(GUILabel)
                        imageIndex = GUIComponents.Label
                    Case GetType(GUIButton)
                        imageIndex = GUIComponents.Button
                    Case GetType(GUITextBox)
                        imageIndex = GUIComponents.TextBox
                    Case GetType(GUIPanel)
                        imageIndex = GUIComponents.Panel
                End Select

                Dim newNode = tvNode.Nodes.Add(key:=child.Name, text:=child.Name, imageIndex:=imageIndex, selectedImageIndex:=imageIndex)
                If child.GetType() Is GetType(GUIPanel) Then
                    Dim castedChild = DirectCast(child, GUIPanel)

                    AddChildren(newNode, castedChild.Children)
                End If
            Next
        End If
    End Sub

    Private Sub cmbLayout_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLayout.SelectedIndexChanged
        If cmbLayout.SelectedIndex >= 0 Then
            LoadLayout(cmbLayout.Text)
        End If
    End Sub

    Private Sub SaveLayout(layoutToSave As GUIPanel, filename As String)
        Dim cf As String = GetInterfacePath() & "\" & filename
        Dim writer As New System.Xml.Serialization.XmlSerializer(GetType(GUIPanel))
        Dim file As New System.IO.StreamWriter(cf)
        writer.Serialize(file, layoutToSave)
        file.Close()
    End Sub

    Private Sub LoadLayout(StrLayout As String)
        Try
            Dim filename = GetInterfacePath() & "\" & StrLayout
            Dim reader As New System.Xml.Serialization.XmlSerializer(GetType(GUIPanel))
            Dim file As New System.IO.StreamReader(filename)

            Layout = CType(reader.Deserialize(file), GUIPanel)
            UpdateComponentList()

            file.Close()
        Catch ex As Exception
            MsgBox("Houve uma falha ao carregar o layout:" & Environment.NewLine & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAddComponent_Click(sender As Object, e As EventArgs) Handles btnAddComponent.Click
        Dim GUIComponent As GUIObject
        Dim Parent As GUIObject

        If tvComponents.SelectedNode IsNot Nothing Then
            Parent = FindGUIObject(tvComponents.SelectedNode.Name, Layout.Children)
        End If

        If Parent Is Nothing Then
            Parent = Layout
        Else
            If Parent.GetType() IsNot GetType(GUIPanel) Then
                Parent = Layout
            End If
        End If

        Dim ParentPanel = DirectCast(Parent, GUIPanel)

        Select Case cmbComponents.SelectedIndex
            Case GUIComponents.Label
                GUIComponent = New GUILabel()
            Case GUIComponents.Button
                GUIComponent = New GUIButton()
            Case GUIComponents.TextBox
                GUIComponent = New GUITextBox()
            Case GUIComponents.Panel
                GUIComponent = New GUIPanel()
        End Select

        If Not GUIComponent Is Nothing Then
            GUIComponent.Name = "Objeto" & Guid.NewGuid().ToString().Substring(1, 4)

            ParentPanel.Children.Add(GUIComponent)

            UpdateComponentList()
        End If
    End Sub

    Private Sub tvComponents_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvComponents.NodeMouseClick
        UpdatePropertyList()
    End Sub

    Private Sub tvComponents_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvComponents.AfterSelect
        UpdatePropertyList()
    End Sub

    Private Sub lvProperties_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvProperties.SelectedIndexChanged
        Dim component = GetSelectedItem()

        If component IsNot Nothing And lvProperties.SelectedItems.Count > 0 Then
            Dim fields = component.GetType().GetFields()
            Dim selectedItemName = lvProperties.SelectedItems(0).SubItems(0).Text
            Dim field = fields.FirstOrDefault(Function(x) x.Name = selectedItemName)

            If field IsNot Nothing Then
                cmbPropValue.Text = field.GetValue(component)
            End If
        End If
    End Sub

    Private Sub btnEditProp_Click(sender As Object, e As EventArgs) Handles btnEditProp.Click
        Dim component = GetSelectedItem()

        If component IsNot Nothing And lvProperties.SelectedItems.Count > 0 Then
            Dim fields = component.GetType().GetFields()
            Dim selectedItemName = lvProperties.SelectedItems(0).SubItems(0).Text
            Dim field = fields.FirstOrDefault(Function(x) x.Name = selectedItemName)

            If field IsNot Nothing Then
                Try
                    field.SetValue(component, Convert.ChangeType(cmbPropValue.Text, field.FieldType))

                    If field.Name = "Name" Then
                        UpdateComponentList()
                    End If

                    UpdatePropertyList()
                Catch ex As Exception
                    MsgBox("Ocorreu um erro ao alterar a propriedade do objeto:" & Environment.NewLine & ex.Message, MsgBoxStyle.Exclamation)
                End Try
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveLayout(Layout, cmbLayout.Text)
    End Sub
End Class