Public Class FrmInterface
    Private Sub TableLayoutPanel3_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel3.Paint

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbInterface_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbInterface.SelectedIndexChanged
        If cmbInterface.SelectedIndex >= 0 Then
            SetEditorEnabled(True)
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
End Class