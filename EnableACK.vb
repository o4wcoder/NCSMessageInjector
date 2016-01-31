Public Class EnableACK

    Private Sub AllLinesCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllLinesCheckBox.CheckedChanged
        If (Me.AllLinesCheckBox.Checked = True) Then
            Me.AllLinesGroupBox.Enabled = False
            Me.ClearAllButton.Enabled = False
            Me.Line1CheckBox.Checked = True
            Me.Line2CheckBox.Checked = True
            Me.Line3CheckBox.Checked = True
            Me.Line4CheckBox.Checked = True
            Me.Line5CheckBox.Checked = True
            Me.Line6CheckBox.Checked = True
            Me.Line7CheckBox.Checked = True
            Me.Line8CheckBox.Checked = True
            Me.Line9CheckBox.Checked = True
            Me.Line10CheckBox.Checked = True
            Me.Line11CheckBox.Checked = True
            Me.Line12CheckBox.Checked = True
        Else
            Me.AllLinesGroupBox.Enabled = True
            Me.ClearAllButton.Enabled = True
        End If
    End Sub

    Private Sub OkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkButton.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        If (Me.AllLinesCheckBox.Checked) Then
            Dim i As Integer
            For i = 0 To 12
                Main.LineACKStatus(i) = 1
            Next
        Else
            Main.LineACKStatus(0) = 0

            'Line 1
            If (Me.Line1CheckBox.Checked) Then
                Main.LineACKStatus(1) = 1
            Else
                Main.LineACKStatus(1) = 0
            End If

            'Line 2
            If (Me.Line2CheckBox.Checked) Then
                Main.LineACKStatus(2) = 1
            Else
                Main.LineACKStatus(2) = 0
            End If

            'Line 3
            If (Me.Line3CheckBox.Checked) Then
                Main.LineACKStatus(3) = 1
            Else
                Main.LineACKStatus(3) = 0
            End If

            'Line 4
            If (Me.Line4CheckBox.Checked) Then
                Main.LineACKStatus(4) = 1
            Else
                Main.LineACKStatus(4) = 0
            End If

            'Line 5
            If (Me.Line5CheckBox.Checked) Then
                Main.LineACKStatus(5) = 1
            Else
                Main.LineACKStatus(5) = 0
            End If

            'Line 6
            If (Me.Line6CheckBox.Checked) Then
                Main.LineACKStatus(6) = 1
            Else
                Main.LineACKStatus(6) = 0
            End If

            'Line 7
            If (Me.Line7CheckBox.Checked) Then
                Main.LineACKStatus(7) = 1
            Else
                Main.LineACKStatus(7) = 0
            End If

            'Line 8
            If (Me.Line8CheckBox.Checked) Then
                Main.LineACKStatus(8) = 1
            Else
                Main.LineACKStatus(8) = 0
            End If

            'Line 9
            If (Me.Line9CheckBox.Checked) Then
                Main.LineACKStatus(9) = 1
            Else
                Main.LineACKStatus(9) = 0
            End If

            'Line 10
            If (Me.Line10CheckBox.Checked) Then
                Main.LineACKStatus(10) = 1
            Else
                Main.LineACKStatus(10) = 0
            End If

            'Line 11
            If (Me.Line11CheckBox.Checked) Then
                Main.LineACKStatus(11) = 1
            Else
                Main.LineACKStatus(11) = 0
            End If

            'Line 12
            If (Me.Line12CheckBox.Checked) Then
                Main.LineACKStatus(12) = 1
            Else
                Main.LineACKStatus(12) = 0
            End If

        End If
        Me.Close()
    End Sub

    Private Sub ClearAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearAllButton.Click
        Me.Line1CheckBox.Checked = False
        Me.Line2CheckBox.Checked = False
        Me.Line3CheckBox.Checked = False
        Me.Line4CheckBox.Checked = False
        Me.Line5CheckBox.Checked = False
        Me.Line6CheckBox.Checked = False
        Me.Line7CheckBox.Checked = False
        Me.Line8CheckBox.Checked = False
        Me.Line9CheckBox.Checked = False
        Me.Line10CheckBox.Checked = False
        Me.Line11CheckBox.Checked = False
        Me.Line12CheckBox.Checked = False
    End Sub

    Private Sub EnableACK_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (Main.LineACKStatus(0)) Then
            Me.AllLinesCheckBox.Checked = True
            Me.AllLinesGroupBox.Enabled = False
            Me.ClearAllButton.Enabled = False
            Me.Line1CheckBox.Checked = True
            Me.Line2CheckBox.Checked = True
            Me.Line3CheckBox.Checked = True
            Me.Line4CheckBox.Checked = True
            Me.Line5CheckBox.Checked = True
            Me.Line6CheckBox.Checked = True
            Me.Line7CheckBox.Checked = True
            Me.Line8CheckBox.Checked = True
            Me.Line9CheckBox.Checked = True
            Me.Line10CheckBox.Checked = True
            Me.Line11CheckBox.Checked = True
            Me.Line12CheckBox.Checked = True
        Else
            Me.AllLinesCheckBox.Checked = False
            Me.AllLinesGroupBox.Enabled = True

            'Line 1
            If (Main.LineACKStatus(1)) Then
                Me.Line1CheckBox.Checked = True
            Else
                Me.Line1CheckBox.Checked = False
            End If

            'Line 2
            If (Main.LineACKStatus(2)) Then
                Me.Line2CheckBox.Checked = True
            Else
                Me.Line2CheckBox.Checked = False
            End If

            'Line 3
            If (Main.LineACKStatus(3)) Then
                Me.Line3CheckBox.Checked = True
            Else
                Me.Line3CheckBox.Checked = False
            End If

            'Line 4
            If (Main.LineACKStatus(4)) Then
                Me.Line4CheckBox.Checked = True
            Else
                Me.Line4CheckBox.Checked = False
            End If

            'Line 5
            If (Main.LineACKStatus(5)) Then
                Me.Line5CheckBox.Checked = True
            Else
                Me.Line5CheckBox.Checked = False
            End If

            'Line 6
            If (Main.LineACKStatus(6)) Then
                Me.Line6CheckBox.Checked = True
            Else
                Me.Line6CheckBox.Checked = False
            End If

            'Line 7
            If (Main.LineACKStatus(7)) Then
                Me.Line7CheckBox.Checked = True
            Else
                Me.Line7CheckBox.Checked = False
            End If

            'Line 8
            If (Main.LineACKStatus(8)) Then
                Me.Line8CheckBox.Checked = True
            Else
                Me.Line8CheckBox.Checked = False
            End If

            'Line 9
            If (Main.LineACKStatus(9)) Then
                Me.Line9CheckBox.Checked = True
            Else
                Me.Line9CheckBox.Checked = False
            End If

            'Line 10
            If (Main.LineACKStatus(10)) Then
                Me.Line10CheckBox.Checked = True
            Else
                Me.Line10CheckBox.Checked = False
            End If

            'Line 11
            If (Main.LineACKStatus(11)) Then
                Me.Line11CheckBox.Checked = True
            Else
                Me.Line11CheckBox.Checked = False
            End If

            'Line 12
            If (Main.LineACKStatus(12)) Then
                Me.Line12CheckBox.Checked = True
            Else
                Me.Line12CheckBox.Checked = False
            End If


        End If
    End Sub
End Class