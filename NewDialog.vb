Public Class NewDialog
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
    Friend WithEvents BlankMessageButton As System.Windows.Forms.Button
    Friend WithEvents TemplateMessageButton As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NewDialog))
        Me.BlankMessageButton = New System.Windows.Forms.Button()
        Me.TemplateMessageButton = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BlankMessageButton
        '
        Me.BlankMessageButton.Location = New System.Drawing.Point(40, 16)
        Me.BlankMessageButton.Name = "BlankMessageButton"
        Me.BlankMessageButton.Size = New System.Drawing.Size(120, 23)
        Me.BlankMessageButton.TabIndex = 0
        Me.BlankMessageButton.Text = "Blank Message"
        '
        'TemplateMessageButton
        '
        Me.TemplateMessageButton.Location = New System.Drawing.Point(16, 56)
        Me.TemplateMessageButton.Name = "TemplateMessageButton"
        Me.TemplateMessageButton.Size = New System.Drawing.Size(168, 23)
        Me.TemplateMessageButton.TabIndex = 1
        Me.TemplateMessageButton.Text = "Build Message From Template"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(56, 96)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Cancel"
        '
        'NewDialog
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(202, 128)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.TemplateMessageButton, Me.BlankMessageButton})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NewDialog"
        Me.Text = "New Message File"
        Me.ResumeLayout(False)

    End Sub

#End Region



    Private Sub NewDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TemplateMessageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TemplateMessageButton.Click
        Me.DialogResult = DialogResult.Cancel
        'mainform.ShowBuildMessageForm()

    End Sub
    Private Sub BlankMessageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlankMessageButton.Click
        'mainform.NewMessageFile()
        Me.Dispose()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.Cancel

    End Sub
End Class
