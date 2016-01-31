Public Class SDPForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents SDPPanel As System.Windows.Forms.Panel
    Friend WithEvents SaveButton As System.Windows.Forms.Button
    Friend WithEvents SaveExitButton As System.Windows.Forms.Button
    Friend WithEvents RichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SDPForm))
        Me.RichTextBox = New System.Windows.Forms.RichTextBox()
        Me.SDPPanel = New System.Windows.Forms.Panel()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.SaveExitButton = New System.Windows.Forms.Button()
        Me.SDPPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'RichTextBox
        '
        Me.RichTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox.Name = "RichTextBox"
        Me.RichTextBox.Size = New System.Drawing.Size(320, 437)
        Me.RichTextBox.TabIndex = 0
        Me.RichTextBox.Text = ""
        '
        'SDPPanel
        '
        Me.SDPPanel.BackColor = System.Drawing.SystemColors.Control
        Me.SDPPanel.Controls.AddRange(New System.Windows.Forms.Control() {Me.SaveExitButton, Me.SaveButton, Me.CloseButton})
        Me.SDPPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SDPPanel.Location = New System.Drawing.Point(0, 397)
        Me.SDPPanel.Name = "SDPPanel"
        Me.SDPPanel.Size = New System.Drawing.Size(320, 40)
        Me.SDPPanel.TabIndex = 1
        '
        'CloseButton
        '
        Me.CloseButton.Location = New System.Drawing.Point(24, 8)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(72, 23)
        Me.CloseButton.TabIndex = 0
        Me.CloseButton.Text = "Close"
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(118, 8)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.TabIndex = 1
        Me.SaveButton.Text = "Save"
        '
        'SaveExitButton
        '
        Me.SaveExitButton.Location = New System.Drawing.Point(215, 8)
        Me.SaveExitButton.Name = "SaveExitButton"
        Me.SaveExitButton.TabIndex = 2
        Me.SaveExitButton.Text = "Save/Exit"
        '
        'SDPForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(320, 437)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.SDPPanel, Me.RichTextBox})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SDPForm"
        Me.Text = "Edit Current SDP"
        Me.SDPPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click

        Me.Dispose()

    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        CurrentSDP = Me.RichTextBox.Text

    End Sub

    Private Sub SaveExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveExitButton.Click

        CurrentSDP = Me.RichTextBox.Text
        Me.Dispose()

    End Sub
End Class
