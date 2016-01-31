Public Class NodeSorter
    Implements IComparer

    Public Function Compare(ByVal x As Object, ByVal y As Object) _
    As Integer Implements IComparer.Compare
        Dim node1 As TreeNode = CType(x, TreeNode)
        Dim node2 As TreeNode = CType(y, TreeNode)

        If (node1.ImageIndex = 1) Then
            Return -1
        Else
            Return 1
        End If
        'If node1.Text.Length <> node2.Text.Length Then
        'Return node1.Text.Length - node2.Text.Length
        'End If
        'Return String.Compare(node2.Text, node1.Text)


    End Function

End Class
