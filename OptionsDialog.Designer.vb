<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.GeneralGroupBox = New System.Windows.Forms.GroupBox
        Me.ConfigureLinesButton = New System.Windows.Forms.Button
        Me.LocalConnTextBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.PiggyDelayTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.EnableACKMessageCheckBox = New System.Windows.Forms.CheckBox
        Me.LoggingGroupBox = New System.Windows.Forms.GroupBox
        Me.BrowseLogFileButton = New System.Windows.Forms.Button
        Me.LogFileNameTextBox = New System.Windows.Forms.TextBox
        Me.LogFileNameLabel = New System.Windows.Forms.Label
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.IncomingLoggingRadioButton = New System.Windows.Forms.RadioButton
        Me.AllLoggingRadioButton = New System.Windows.Forms.RadioButton
        Me.NoneLoggingRadioButton = New System.Windows.Forms.RadioButton
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GeneralGroupBox.SuspendLayout()
        Me.LoggingGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(152, 238)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'GeneralGroupBox
        '
        Me.GeneralGroupBox.Controls.Add(Me.ConfigureLinesButton)
        Me.GeneralGroupBox.Controls.Add(Me.LocalConnTextBox)
        Me.GeneralGroupBox.Controls.Add(Me.Label2)
        Me.GeneralGroupBox.Controls.Add(Me.PiggyDelayTextBox)
        Me.GeneralGroupBox.Controls.Add(Me.Label1)
        Me.GeneralGroupBox.Controls.Add(Me.EnableACKMessageCheckBox)
        Me.GeneralGroupBox.Location = New System.Drawing.Point(4, 5)
        Me.GeneralGroupBox.Name = "GeneralGroupBox"
        Me.GeneralGroupBox.Size = New System.Drawing.Size(302, 106)
        Me.GeneralGroupBox.TabIndex = 1
        Me.GeneralGroupBox.TabStop = False
        Me.GeneralGroupBox.Text = "General"
        '
        'ConfigureLinesButton
        '
        Me.ConfigureLinesButton.Location = New System.Drawing.Point(151, 15)
        Me.ConfigureLinesButton.Name = "ConfigureLinesButton"
        Me.ConfigureLinesButton.Size = New System.Drawing.Size(94, 23)
        Me.ConfigureLinesButton.TabIndex = 42
        Me.ConfigureLinesButton.Text = "Configure Lines"
        Me.ConfigureLinesButton.UseVisualStyleBackColor = True
        '
        'LocalConnTextBox
        '
        Me.LocalConnTextBox.Location = New System.Drawing.Point(151, 71)
        Me.LocalConnTextBox.Name = "LocalConnTextBox"
        Me.LocalConnTextBox.Size = New System.Drawing.Size(144, 20)
        Me.LocalConnTextBox.TabIndex = 41
        Me.LocalConnTextBox.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "local connection options:"
        '
        'PiggyDelayTextBox
        '
        Me.PiggyDelayTextBox.Location = New System.Drawing.Point(151, 45)
        Me.PiggyDelayTextBox.Name = "PiggyDelayTextBox"
        Me.PiggyDelayTextBox.Size = New System.Drawing.Size(144, 20)
        Me.PiggyDelayTextBox.TabIndex = 39
        Me.PiggyDelayTextBox.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "piggyback delay (ms):"
        '
        'EnableACKMessageCheckBox
        '
        Me.EnableACKMessageCheckBox.AutoSize = True
        Me.EnableACKMessageCheckBox.Checked = True
        Me.EnableACKMessageCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.EnableACKMessageCheckBox.Location = New System.Drawing.Point(16, 19)
        Me.EnableACKMessageCheckBox.Name = "EnableACKMessageCheckBox"
        Me.EnableACKMessageCheckBox.Size = New System.Drawing.Size(134, 17)
        Me.EnableACKMessageCheckBox.TabIndex = 0
        Me.EnableACKMessageCheckBox.Text = "Enable ACK Messages"
        Me.EnableACKMessageCheckBox.UseVisualStyleBackColor = True
        '
        'LoggingGroupBox
        '
        Me.LoggingGroupBox.Controls.Add(Me.BrowseLogFileButton)
        Me.LoggingGroupBox.Controls.Add(Me.LogFileNameTextBox)
        Me.LoggingGroupBox.Controls.Add(Me.LogFileNameLabel)
        Me.LoggingGroupBox.Controls.Add(Me.RadioButton1)
        Me.LoggingGroupBox.Controls.Add(Me.IncomingLoggingRadioButton)
        Me.LoggingGroupBox.Controls.Add(Me.AllLoggingRadioButton)
        Me.LoggingGroupBox.Controls.Add(Me.NoneLoggingRadioButton)
        Me.LoggingGroupBox.Location = New System.Drawing.Point(4, 117)
        Me.LoggingGroupBox.Name = "LoggingGroupBox"
        Me.LoggingGroupBox.Size = New System.Drawing.Size(302, 115)
        Me.LoggingGroupBox.TabIndex = 2
        Me.LoggingGroupBox.TabStop = False
        Me.LoggingGroupBox.Text = "Logging"
        '
        'BrowseLogFileButton
        '
        Me.BrowseLogFileButton.Location = New System.Drawing.Point(220, 86)
        Me.BrowseLogFileButton.Name = "BrowseLogFileButton"
        Me.BrowseLogFileButton.Size = New System.Drawing.Size(75, 23)
        Me.BrowseLogFileButton.TabIndex = 6
        Me.BrowseLogFileButton.Text = "Browse..."
        Me.BrowseLogFileButton.UseVisualStyleBackColor = True
        '
        'LogFileNameTextBox
        '
        Me.LogFileNameTextBox.Location = New System.Drawing.Point(16, 89)
        Me.LogFileNameTextBox.Name = "LogFileNameTextBox"
        Me.LogFileNameTextBox.Size = New System.Drawing.Size(191, 20)
        Me.LogFileNameTextBox.TabIndex = 5
        Me.LogFileNameTextBox.Text = "log.txt"
        '
        'LogFileNameLabel
        '
        Me.LogFileNameLabel.AutoSize = True
        Me.LogFileNameLabel.Location = New System.Drawing.Point(13, 71)
        Me.LogFileNameLabel.Name = "LogFileNameLabel"
        Me.LogFileNameLabel.Size = New System.Drawing.Size(73, 13)
        Me.LogFileNameLabel.TabIndex = 4
        Me.LogFileNameLabel.Text = "Log file name:"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(144, 42)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(92, 17)
        Me.RadioButton1.TabIndex = 3
        Me.RadioButton1.Text = "Outgoing Only"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'IncomingLoggingRadioButton
        '
        Me.IncomingLoggingRadioButton.AutoSize = True
        Me.IncomingLoggingRadioButton.Location = New System.Drawing.Point(144, 19)
        Me.IncomingLoggingRadioButton.Name = "IncomingLoggingRadioButton"
        Me.IncomingLoggingRadioButton.Size = New System.Drawing.Size(92, 17)
        Me.IncomingLoggingRadioButton.TabIndex = 2
        Me.IncomingLoggingRadioButton.Text = "Incoming Only"
        Me.IncomingLoggingRadioButton.UseVisualStyleBackColor = True
        '
        'AllLoggingRadioButton
        '
        Me.AllLoggingRadioButton.AutoSize = True
        Me.AllLoggingRadioButton.Location = New System.Drawing.Point(16, 42)
        Me.AllLoggingRadioButton.Name = "AllLoggingRadioButton"
        Me.AllLoggingRadioButton.Size = New System.Drawing.Size(62, 17)
        Me.AllLoggingRadioButton.TabIndex = 1
        Me.AllLoggingRadioButton.Text = "All Data"
        Me.AllLoggingRadioButton.UseVisualStyleBackColor = True
        '
        'NoneLoggingRadioButton
        '
        Me.NoneLoggingRadioButton.AutoSize = True
        Me.NoneLoggingRadioButton.Checked = True
        Me.NoneLoggingRadioButton.Location = New System.Drawing.Point(16, 19)
        Me.NoneLoggingRadioButton.Name = "NoneLoggingRadioButton"
        Me.NoneLoggingRadioButton.Size = New System.Drawing.Size(51, 17)
        Me.NoneLoggingRadioButton.TabIndex = 0
        Me.NoneLoggingRadioButton.TabStop = True
        Me.NoneLoggingRadioButton.Text = "None"
        Me.NoneLoggingRadioButton.UseVisualStyleBackColor = True
        '
        'OptionsDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(310, 279)
        Me.Controls.Add(Me.LoggingGroupBox)
        Me.Controls.Add(Me.GeneralGroupBox)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OptionsDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "NCS Message Injector Options"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GeneralGroupBox.ResumeLayout(False)
        Me.GeneralGroupBox.PerformLayout()
        Me.LoggingGroupBox.ResumeLayout(False)
        Me.LoggingGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents GeneralGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents LoggingGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents AllLoggingRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents NoneLoggingRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents BrowseLogFileButton As System.Windows.Forms.Button
    Friend WithEvents LogFileNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LogFileNameLabel As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents IncomingLoggingRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents EnableACKMessageCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PiggyDelayTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LocalConnTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ConfigureLinesButton As System.Windows.Forms.Button

End Class
