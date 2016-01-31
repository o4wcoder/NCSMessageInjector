Public Class IPSelect


    Private Sub IPSelectListBox_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IPListBox.DoubleClick

        Me.Close()
    End Sub

    Private Sub IPSelect_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        'Dim ipStr As String = IPListBox.SelectedItem.ToString

        'mainform.LocalIpAddress = System.Net.IPAddress.Parse(ipStr)
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub IPSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        IPListBox.SelectedIndex = 0
    End Sub

    Private Sub IPListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IPListBox.SelectedIndexChanged

    End Sub
End Class