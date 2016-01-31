Imports System.Text.RegularExpressions

Public Class AddMTA
    Inherits System.Windows.Forms.Form


    Private mainform As MainDialog
#Region " Windows Form Designer generated code "

    Public Sub New(ByRef passform As MainDialog)
        MyBase.New()

        mainform = passform
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RecPortTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DestPortTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MTAIpAddressTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents CancelButton As System.Windows.Forms.Button
    Friend WithEvents FQDNTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddMTA))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.RecPortTextBox = New System.Windows.Forms.TextBox
        Me.DestPortTextBox = New System.Windows.Forms.TextBox
        Me.MTAIpAddressTextBox = New System.Windows.Forms.TextBox
        Me.OKButton = New System.Windows.Forms.Button
        Me.CancelButton = New System.Windows.Forms.Button
        Me.FQDNTextBox = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(26, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "MTA IP Address"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Receive UDP Port from MTA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Destination UDP Port"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RecPortTextBox
        '
        Me.RecPortTextBox.Location = New System.Drawing.Point(152, 88)
        Me.RecPortTextBox.Name = "RecPortTextBox"
        Me.RecPortTextBox.Size = New System.Drawing.Size(96, 20)
        Me.RecPortTextBox.TabIndex = 3
        Me.RecPortTextBox.Text = "2727"
        '
        'DestPortTextBox
        '
        Me.DestPortTextBox.Location = New System.Drawing.Point(152, 128)
        Me.DestPortTextBox.Name = "DestPortTextBox"
        Me.DestPortTextBox.Size = New System.Drawing.Size(96, 20)
        Me.DestPortTextBox.TabIndex = 4
        Me.DestPortTextBox.Text = "2427"
        '
        'MTAIpAddressTextBox
        '
        Me.MTAIpAddressTextBox.Location = New System.Drawing.Point(152, 16)
        Me.MTAIpAddressTextBox.Name = "MTAIpAddressTextBox"
        Me.MTAIpAddressTextBox.Size = New System.Drawing.Size(120, 20)
        Me.MTAIpAddressTextBox.TabIndex = 1
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(296, 16)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 5
        Me.OKButton.Text = "OK"
        '
        'CancelButton
        '
        Me.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelButton.Location = New System.Drawing.Point(296, 56)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(75, 23)
        Me.CancelButton.TabIndex = 6
        Me.CancelButton.Text = "Cancel"
        '
        'FQDNTextBox
        '
        Me.FQDNTextBox.Location = New System.Drawing.Point(152, 48)
        Me.FQDNTextBox.Name = "FQDNTextBox"
        Me.FQDNTextBox.Size = New System.Drawing.Size(120, 20)
        Me.FQDNTextBox.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "FQDN"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AddMTA
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.CancelButton
        Me.ClientSize = New System.Drawing.Size(384, 158)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.FQDNTextBox)
        Me.Controls.Add(Me.CancelButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.MTAIpAddressTextBox)
        Me.Controls.Add(Me.DestPortTextBox)
        Me.Controls.Add(Me.RecPortTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AddMTA"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "AddMTA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub AddMTA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Me.MTAIpAddressTextBox.
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        OK_Button()

    End Sub

    Private Sub OK_Button()
        Dim IpAddress As String
        Dim FQDN As String
        Dim RecPort As String
        Dim DestPort As String
        Dim FieldError As String

        IpAddress = Me.MTAIpAddressTextBox.Text
        FQDN = Me.FQDNTextBox.Text
        RecPort = Me.RecPortTextBox.Text
        DestPort = Me.DestPortTextBox.Text

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        ' If Regex.IsMatch(IpAddress, "^((1?\d(1,2}|2[0-4]\d|25[0-5])\.){3}" & "(1?\d{1,2}|2[0-4]\d|25[0-5])$") Then


        If ((mainform.IpExists(IpAddress))) Then
            MsgBox("Ip Address " & IpAddress & " is already listed.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        FieldError = mainform.GetMTAFieldError(IpAddress, FQDN, RecPort, DestPort)
        If (FieldError <> String.Empty) Then
            MsgBox(FieldError, MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        'everything was ok, except fields
        Dim item As New ListViewItem(IpAddress)
        item.ImageIndex = 3
        'mainform.MTAListView.Items.Add(IpAddress)

        item.SubItems.Add(FQDN)
        item.SubItems.Add(RecPort)
        item.SubItems.Add(DestPort)
        'mainform.MTAListView.Items(mainform.MTAListView.Items.Count - 1).SubItems.Add(FQDN)
        'mainform.MTAListView.Items(mainform.MTAListView.Items.Count - 1).SubItems.Add(RecPort)
        'mainform.MTAListView.Items(mainform.MTAListView.Items.Count - 1).SubItems.Add(DestPort)
        mainform.MTAListView.Items.Add(item)

        Me.Close()
        'Else
        ' MsgBox("Invalid Ip Address " & IpAddress)
        'End If


    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub RecPortTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RecPortTextBox.KeyPress

        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            OK_Button()
        End If
    End Sub

    Private Sub DestPortTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DestPortTextBox.KeyPress
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            OK_Button()
        End If
    End Sub

    Private Sub MTAIpAddressTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MTAIpAddressTextBox.KeyPress
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            OK_Button()
        End If
    End Sub

    Private Sub FQDNTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FQDNTextBox.KeyPress
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            OK_Button()
        End If
    End Sub
End Class
