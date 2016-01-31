Imports System.Environment

Public Class MessageForm
    Inherits System.Windows.Forms.Form

    Public NeedSave As Boolean = False
    Private FileName As String
    Private PathAndFileName As String
    Private EmptyText As Boolean = True
    Private CursorPos As Integer
    Private mainform As MainDialog



#Region " Windows Form Designer generated code "

    Public Sub New(ByRef passform As MainDialog, ByVal path As String)
        MyBase.New()
        mainform = passform
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        SetPathAndFileName(path)
        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByRef passform As MainDialog)
        MyBase.New()

        mainform = passform

        'This call is required by the Windows Form Designer.
        InitializeComponent()


        Me.Text = UNTITLED_MESSAGE_FILE
        Me.PathAndFileName = String.Empty
        Me.FileName = Text
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
    Friend WithEvents RichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents MessageFileContextMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents InsertCurrentSDPMenuItem As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MessageForm))
        Me.RichTextBox = New System.Windows.Forms.RichTextBox
        Me.MessageFileContextMenu = New System.Windows.Forms.ContextMenu
        Me.InsertCurrentSDPMenuItem = New System.Windows.Forms.MenuItem
        Me.SuspendLayout()
        '
        'RichTextBox
        '
        Me.RichTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox.ContextMenu = Me.MessageFileContextMenu
        Me.RichTextBox.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RichTextBox.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBox.Name = "RichTextBox"
        Me.RichTextBox.Size = New System.Drawing.Size(298, 346)
        Me.RichTextBox.TabIndex = 0
        Me.RichTextBox.Text = ""
        '
        'MessageFileContextMenu
        '
        Me.MessageFileContextMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.InsertCurrentSDPMenuItem})
        '
        'InsertCurrentSDPMenuItem
        '
        Me.InsertCurrentSDPMenuItem.Index = 0
        Me.InsertCurrentSDPMenuItem.Text = "Insert Current SDP"
        '
        'MessageForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(294, 339)
        Me.Controls.Add(Me.RichTextBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MessageForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "MessageForm"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub MessageForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MessageForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim result As MsgBoxResult

        Try

            ' mainform.activeChild = mainform.ActiveMdiChild

            If (NeedSave) Then
                result = mainform.SavePrompt()
            End If

            If (result <> MsgBoxResult.Cancel) Then
                e.Cancel = False

                If (mainform.MdiChildren.Length = 1) Then
                    mainform.SetEmptyMDIButtons()
                End If
            Else
                e.Cancel = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RichTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RichTextBox.KeyPress
        NeedSave = True

        If (e.KeyChar = Chr(Keys.Space)) Then
            CursorPos = RichTextBox.SelectionStart

            ColorCodeText()
            'reset Cursor
            RichTextBox.SelectionStart = CursorPos

        End If
    End Sub


    Private Sub RichTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox.TextChanged
        ' MessageBox.Show("Change text with Empty text " & EmptyText.ToString)
        'If (EmptyText <> True) Then
        '    NeedSave = True
        'End If

        'EmptyText = False


    End Sub

    Public Function GetPathAndFileName()
        Return PathAndFileName
    End Function

    Public Function GetFileName()
        Return FileName
    End Function

    Public Sub SetPathAndFileName(ByVal path As String)
        Me.PathAndFileName = path
        Me.Text = System.IO.Path.GetFileName(path)
        Me.FileName = Text
    End Sub

    Public Sub Paste()

        Me.RichTextBox.Paste()
        Me.RichTextBox.ForeColor = Color.Black


    End Sub

    Private Sub InsertCurrentSDPMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertCurrentSDPMenuItem.Click
        Me.RichTextBox.AppendText(CurrentSDP)
    End Sub

    Public Sub ColorCodeText()

        Dim lineArray() As String = Split(RichTextBox.Text, vbCrLf)

        Dim i As Integer

        RichTextBox.Clear()
        For i = 0 To lineArray.Length - 1

            Dim wordArray() As String = Split(lineArray(i))

            Dim j As Integer

            For j = 0 To wordArray.Length - 1

                RichTextBox.SelectionColor = Color.Black
                'Dim token As String = (LCase(wordArray(j)))
                Dim token As String = wordArray(j)

                If (token = "ntfy" Or token = "rqnt" Or token = "crcx" Or _
    token = "mdcx" Or token = "auep" Or token = "aucx" Or token = "rsip" Or token = "dlcx" Or _
    token = "NTFY" Or token = "RQNT" Or token = "CRCX" Or _
    token = "MDCX" Or token = "AUEP" Or token = "AUCX" Or token = "RSIP" Or token = "DLCX") Then

                    RichTextBox.SelectionColor = Color.Blue
                ElseIf (token = "transid" Or token = "fqdn" Or token = "connid") Then
                    RichTextBox.SelectionColor = Color.Red
                End If


                RichTextBox.SelectedText = token + " "


            Next j
            If (Not ((i + 1) >= lineArray.Length - 1)) Then
                RichTextBox.SelectedText = NewLine
            End If
        Next i
    End Sub
End Class
