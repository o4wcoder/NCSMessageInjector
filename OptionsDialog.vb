Imports System.Windows.Forms

Public Class OptionsDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK

        If Me.EnableACKMessageCheckBox.Checked = True Then
            Main.OptionEnableACKMessages = True
        Else
            Main.OptionEnableACKMessages = False
        End If

        Main.OptionPiggyDelay = Me.PiggyDelayTextBox.Text

        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub EnableACKMessageCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableACKMessageCheckBox.CheckedChanged

        If Me.EnableACKMessageCheckBox.Checked = True Then
            Me.ConfigureLinesButton.Enabled = True
        Else
            Me.ConfigureLinesButton.Enabled = False
        End If
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.

        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


    End Sub

    Private Sub OptionsDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If (Main.OptionEnableACKMessages = True) Then
            Me.EnableACKMessageCheckBox.Checked = True
        Else
            Me.EnableACKMessageCheckBox.Checked = False
        End If

        Me.PiggyDelayTextBox.Text = Main.OptionPiggyDelay
    End Sub

    Private Sub BrowseLogFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseLogFileButton.Click
        Dim saveform As New SaveFileDialog()
        saveform.DefaultExt = "txt"
        saveform.Filter = "log files (*.txt; *.log|*.txt; *.log"

        If (saveform.ShowDialog() = DialogResult().OK) Then

            Try

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ConfigureLinesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigureLinesButton.Click

        Dim enableAck As New EnableACK()
        enableAck.ShowDialog()
    End Sub
End Class
