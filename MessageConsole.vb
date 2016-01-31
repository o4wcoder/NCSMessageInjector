Public Class MessageConsole
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
    Friend WithEvents ConsoleRichTextBox As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ConsoleRichTextBox = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'ConsoleRichTextBox
        '
        Me.ConsoleRichTextBox.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.ConsoleRichTextBox.BackColor = System.Drawing.SystemColors.WindowText
        Me.ConsoleRichTextBox.ForeColor = System.Drawing.SystemColors.Window
        Me.ConsoleRichTextBox.Name = "ConsoleRichTextBox"
        Me.ConsoleRichTextBox.Size = New System.Drawing.Size(296, 280)
        Me.ConsoleRichTextBox.TabIndex = 0
        Me.ConsoleRichTextBox.Text = ""
        '
        'MessageConsole
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ConsoleRichTextBox})
        Me.Name = "MessageConsole"
        Me.Text = "MessageConsole"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub MessageConsole_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
