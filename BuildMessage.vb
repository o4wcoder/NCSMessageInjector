Public Class BuildMessage
    Inherits System.Windows.Forms.Form

    Private ACK_NACK As String = "ACK/NACK"
    Private AUCX As String = "AUCX"
    Private AUEP As String = "AUEP"
    Private CRCX As String = "CRCX"
    Private DLCX As String = "DLCX"
    Private RQNT As String = "RQNT"
    Private MDCX As String = "MDCX"

    Private DESC_ACK_NACK As String = "Response Message"
    Private DESC_AUCX As String = "Audit Connection"
    Private DESC_AUEP As String = "Audit Endpoint"
    Private DESC_CRCX As String = "Create Connection"
    Private DESC_DLCX As String = "Delete Connection"
    Private DESC_RQNT As String = "Request for Notification"
    Private DESC_MDCX As String = "Modify Connection"


    Dim mainform As MainDialog

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
    Friend WithEvents MessageTypeLabel As System.Windows.Forms.Label
    Friend WithEvents MessageTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MessagePanel As System.Windows.Forms.Panel
    Friend WithEvents XParamCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents RParamCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SParamCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents QParamCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TParamCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CParamCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents FParamCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents BuildButton As System.Windows.Forms.Button
    Friend WithEvents CancelButton As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DParamCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents IParamCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents MParamCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents RCDParamCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents LParamCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents NParamCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents XParamComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents NParamComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents RParamComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents SParamComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents QParamComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents DParamComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents TParamComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CParamComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents IParamComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents MParamComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents LParamComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents RCDParamComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents FParamComboBox As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BuildMessage))
        Me.MessageTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.MessageTypeLabel = New System.Windows.Forms.Label()
        Me.MessagePanel = New System.Windows.Forms.Panel()
        Me.FParamComboBox = New System.Windows.Forms.ComboBox()
        Me.RCDParamComboBox = New System.Windows.Forms.ComboBox()
        Me.LParamComboBox = New System.Windows.Forms.ComboBox()
        Me.MParamComboBox = New System.Windows.Forms.ComboBox()
        Me.IParamComboBox = New System.Windows.Forms.ComboBox()
        Me.CParamComboBox = New System.Windows.Forms.ComboBox()
        Me.TParamComboBox = New System.Windows.Forms.ComboBox()
        Me.DParamComboBox = New System.Windows.Forms.ComboBox()
        Me.QParamComboBox = New System.Windows.Forms.ComboBox()
        Me.SParamComboBox = New System.Windows.Forms.ComboBox()
        Me.RParamComboBox = New System.Windows.Forms.ComboBox()
        Me.NParamComboBox = New System.Windows.Forms.ComboBox()
        Me.XParamComboBox = New System.Windows.Forms.ComboBox()
        Me.FParamCheckBox = New System.Windows.Forms.CheckBox()
        Me.RCDParamCheckBox = New System.Windows.Forms.CheckBox()
        Me.LParamCheckBox = New System.Windows.Forms.CheckBox()
        Me.MParamCheckBox = New System.Windows.Forms.CheckBox()
        Me.IParamCheckBox = New System.Windows.Forms.CheckBox()
        Me.CParamCheckBox = New System.Windows.Forms.CheckBox()
        Me.TParamCheckBox = New System.Windows.Forms.CheckBox()
        Me.DParamCheckBox = New System.Windows.Forms.CheckBox()
        Me.QParamCheckBox = New System.Windows.Forms.CheckBox()
        Me.SParamCheckBox = New System.Windows.Forms.CheckBox()
        Me.RParamCheckBox = New System.Windows.Forms.CheckBox()
        Me.NParamCheckBox = New System.Windows.Forms.CheckBox()
        Me.XParamCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BuildButton = New System.Windows.Forms.Button()
        Me.CancelButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MessagePanel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MessageTypeComboBox
        '
        Me.MessageTypeComboBox.Location = New System.Drawing.Point(16, 8)
        Me.MessageTypeComboBox.Name = "MessageTypeComboBox"
        Me.MessageTypeComboBox.Size = New System.Drawing.Size(128, 21)
        Me.MessageTypeComboBox.TabIndex = 0
        Me.MessageTypeComboBox.Text = "Select Message Type"
        '
        'MessageTypeLabel
        '
        Me.MessageTypeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MessageTypeLabel.Location = New System.Drawing.Point(160, 7)
        Me.MessageTypeLabel.Name = "MessageTypeLabel"
        Me.MessageTypeLabel.Size = New System.Drawing.Size(136, 23)
        Me.MessageTypeLabel.TabIndex = 1
        Me.MessageTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MessagePanel
        '
        Me.MessagePanel.BackColor = System.Drawing.Color.LightSteelBlue
        Me.MessagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MessagePanel.Controls.AddRange(New System.Windows.Forms.Control() {Me.FParamComboBox, Me.RCDParamComboBox, Me.LParamComboBox, Me.MParamComboBox, Me.IParamComboBox, Me.CParamComboBox, Me.TParamComboBox, Me.DParamComboBox, Me.QParamComboBox, Me.SParamComboBox, Me.RParamComboBox, Me.NParamComboBox, Me.XParamComboBox, Me.FParamCheckBox, Me.RCDParamCheckBox, Me.LParamCheckBox, Me.MParamCheckBox, Me.IParamCheckBox, Me.CParamCheckBox, Me.TParamCheckBox, Me.DParamCheckBox, Me.QParamCheckBox, Me.SParamCheckBox, Me.RParamCheckBox, Me.NParamCheckBox, Me.XParamCheckBox})
        Me.MessagePanel.Location = New System.Drawing.Point(8, 88)
        Me.MessagePanel.Name = "MessagePanel"
        Me.MessagePanel.Size = New System.Drawing.Size(352, 424)
        Me.MessagePanel.TabIndex = 2
        '
        'FParamComboBox
        '
        Me.FParamComboBox.Items.AddRange(New Object() {"<empty>"})
        Me.FParamComboBox.Location = New System.Drawing.Point(208, 392)
        Me.FParamComboBox.Name = "FParamComboBox"
        Me.FParamComboBox.Size = New System.Drawing.Size(136, 21)
        Me.FParamComboBox.TabIndex = 25
        Me.FParamComboBox.Text = "Select/Edit F Value"
        '
        'RCDParamComboBox
        '
        Me.RCDParamComboBox.Items.AddRange(New Object() {"<empty>"})
        Me.RCDParamComboBox.Location = New System.Drawing.Point(208, 360)
        Me.RCDParamComboBox.Name = "RCDParamComboBox"
        Me.RCDParamComboBox.Size = New System.Drawing.Size(136, 21)
        Me.RCDParamComboBox.TabIndex = 24
        Me.RCDParamComboBox.Text = "Select/Edit RCD Value"
        '
        'LParamComboBox
        '
        Me.LParamComboBox.Items.AddRange(New Object() {"<empty>", "p: 10", "p: 10, a: G711", "p: 10, a: G711, dq-rr:"})
        Me.LParamComboBox.Location = New System.Drawing.Point(208, 328)
        Me.LParamComboBox.Name = "LParamComboBox"
        Me.LParamComboBox.Size = New System.Drawing.Size(136, 21)
        Me.LParamComboBox.TabIndex = 23
        Me.LParamComboBox.Text = "Select/Edit L Value"
        '
        'MParamComboBox
        '
        Me.MParamComboBox.Items.AddRange(New Object() {"<empty>", "recvonly", "sendonly", "sendrecv"})
        Me.MParamComboBox.Location = New System.Drawing.Point(208, 296)
        Me.MParamComboBox.Name = "MParamComboBox"
        Me.MParamComboBox.Size = New System.Drawing.Size(136, 21)
        Me.MParamComboBox.TabIndex = 22
        Me.MParamComboBox.Text = "Select/Edit M Value"
        '
        'IParamComboBox
        '
        Me.IParamComboBox.Items.AddRange(New Object() {"<empty>"})
        Me.IParamComboBox.Location = New System.Drawing.Point(208, 264)
        Me.IParamComboBox.Name = "IParamComboBox"
        Me.IParamComboBox.Size = New System.Drawing.Size(136, 21)
        Me.IParamComboBox.TabIndex = 21
        Me.IParamComboBox.Text = "Select/Edit I Value"
        '
        'CParamComboBox
        '
        Me.CParamComboBox.Items.AddRange(New Object() {"<empty>"})
        Me.CParamComboBox.Location = New System.Drawing.Point(208, 232)
        Me.CParamComboBox.Name = "CParamComboBox"
        Me.CParamComboBox.Size = New System.Drawing.Size(136, 21)
        Me.CParamComboBox.TabIndex = 20
        Me.CParamComboBox.Text = "Select/Edit C Value"
        '
        'TParamComboBox
        '
        Me.TParamComboBox.Items.AddRange(New Object() {"<empty>"})
        Me.TParamComboBox.Location = New System.Drawing.Point(208, 200)
        Me.TParamComboBox.Name = "TParamComboBox"
        Me.TParamComboBox.Size = New System.Drawing.Size(136, 21)
        Me.TParamComboBox.TabIndex = 19
        Me.TParamComboBox.Text = "Select/Edit T Value"
        '
        'DParamComboBox
        '
        Me.DParamComboBox.Items.AddRange(New Object() {"<empty>", "(911|311|411|611|0t|00t|[2-9]xxxxxx|1[1-9]xxxxxxxxx|*|x.#|011x.t)", "([2-9]11|*xx|xx#|[2-9]*|[2-9]xxxxxx|1xxxxxxxxxx|011x.t|101xxxx1xxxxxxxxxx|101xxxx" & _
        "011x.t|101xxxx0t|00t|0t)"})
        Me.DParamComboBox.Location = New System.Drawing.Point(208, 168)
        Me.DParamComboBox.Name = "DParamComboBox"
        Me.DParamComboBox.Size = New System.Drawing.Size(136, 21)
        Me.DParamComboBox.TabIndex = 18
        Me.DParamComboBox.Text = "Select/Edit D Value"
        '
        'QParamComboBox
        '
        Me.QParamComboBox.Items.AddRange(New Object() {"<empty>", "discard", "process", "loop"})
        Me.QParamComboBox.Location = New System.Drawing.Point(208, 136)
        Me.QParamComboBox.Name = "QParamComboBox"
        Me.QParamComboBox.Size = New System.Drawing.Size(136, 21)
        Me.QParamComboBox.TabIndex = 17
        Me.QParamComboBox.Text = "Select/Edit Q Value"
        '
        'SParamComboBox
        '
        Me.SParamComboBox.Items.AddRange(New Object() {"<empty>", "signal requests", "rg", "rg, ci(01/02/03/04, 8675309, ""Jenny Jenny"")", "wt1, ci(01/02/03/04, 5551212, ""Ronald Regan"")", "wt1, ci(01/01/01/01,O,O)", "dl"})
        Me.SParamComboBox.Location = New System.Drawing.Point(208, 104)
        Me.SParamComboBox.Name = "SParamComboBox"
        Me.SParamComboBox.Size = New System.Drawing.Size(136, 21)
        Me.SParamComboBox.TabIndex = 16
        Me.SParamComboBox.Text = "Select/Edit S Value"
        '
        'RParamComboBox
        '
        Me.RParamComboBox.Items.AddRange(New Object() {"<empty>", "[0-9#*T](D)", "[0-9#*T](N)", "[0-9](N)", "hd(A,E(R([0-9#*T](D),hu),S(L/dl)))", "hu(n)", "hu(n), [0-9#*T](n)", "oc(n), hf(i), hu(n), [0-9*#t](d)"})
        Me.RParamComboBox.Location = New System.Drawing.Point(208, 72)
        Me.RParamComboBox.Name = "RParamComboBox"
        Me.RParamComboBox.Size = New System.Drawing.Size(136, 21)
        Me.RParamComboBox.TabIndex = 15
        Me.RParamComboBox.Text = "Select/Edit R Value"
        '
        'NParamComboBox
        '
        Me.NParamComboBox.Items.AddRange(New Object() {"<empty>", "ca@mymso.net:2727", "ca@[10.1.33.241]:2727", "ca@mymso.net", "ca@[10.1.33.241]"})
        Me.NParamComboBox.Location = New System.Drawing.Point(208, 40)
        Me.NParamComboBox.Name = "NParamComboBox"
        Me.NParamComboBox.Size = New System.Drawing.Size(136, 21)
        Me.NParamComboBox.TabIndex = 14
        Me.NParamComboBox.Text = "Select/Edit N Value"
        '
        'XParamComboBox
        '
        Me.XParamComboBox.Items.AddRange(New Object() {"<empty>", "100", "0123456789AC"})
        Me.XParamComboBox.Location = New System.Drawing.Point(208, 8)
        Me.XParamComboBox.Name = "XParamComboBox"
        Me.XParamComboBox.Size = New System.Drawing.Size(136, 21)
        Me.XParamComboBox.TabIndex = 13
        Me.XParamComboBox.Text = "Select/Edit X  Value"
        '
        'FParamCheckBox
        '
        Me.FParamCheckBox.Location = New System.Drawing.Point(8, 392)
        Me.FParamCheckBox.Name = "FParamCheckBox"
        Me.FParamCheckBox.Size = New System.Drawing.Size(120, 24)
        Me.FParamCheckBox.TabIndex = 12
        Me.FParamCheckBox.Text = "F - Request Info"
        '
        'RCDParamCheckBox
        '
        Me.RCDParamCheckBox.Location = New System.Drawing.Point(8, 360)
        Me.RCDParamCheckBox.Name = "RCDParamCheckBox"
        Me.RCDParamCheckBox.Size = New System.Drawing.Size(216, 24)
        Me.RCDParamCheckBox.TabIndex = 11
        Me.RCDParamCheckBox.Text = "RCD - Remote Connection Descriptor"
        '
        'LParamCheckBox
        '
        Me.LParamCheckBox.Location = New System.Drawing.Point(8, 328)
        Me.LParamCheckBox.Name = "LParamCheckBox"
        Me.LParamCheckBox.Size = New System.Drawing.Size(176, 24)
        Me.LParamCheckBox.TabIndex = 10
        Me.LParamCheckBox.Text = "L - Local Connection Options"
        '
        'MParamCheckBox
        '
        Me.MParamCheckBox.Location = New System.Drawing.Point(8, 296)
        Me.MParamCheckBox.Name = "MParamCheckBox"
        Me.MParamCheckBox.Size = New System.Drawing.Size(136, 24)
        Me.MParamCheckBox.TabIndex = 9
        Me.MParamCheckBox.Text = "M - Connection Mode"
        '
        'IParamCheckBox
        '
        Me.IParamCheckBox.Location = New System.Drawing.Point(8, 264)
        Me.IParamCheckBox.Name = "IParamCheckBox"
        Me.IParamCheckBox.Size = New System.Drawing.Size(112, 24)
        Me.IParamCheckBox.TabIndex = 8
        Me.IParamCheckBox.Text = "I - Connection ID"
        '
        'CParamCheckBox
        '
        Me.CParamCheckBox.Location = New System.Drawing.Point(8, 232)
        Me.CParamCheckBox.Name = "CParamCheckBox"
        Me.CParamCheckBox.Size = New System.Drawing.Size(112, 24)
        Me.CParamCheckBox.TabIndex = 7
        Me.CParamCheckBox.Text = "C - Caller ID"
        '
        'TParamCheckBox
        '
        Me.TParamCheckBox.Location = New System.Drawing.Point(8, 200)
        Me.TParamCheckBox.Name = "TParamCheckBox"
        Me.TParamCheckBox.Size = New System.Drawing.Size(112, 24)
        Me.TParamCheckBox.TabIndex = 6
        Me.TParamCheckBox.Text = "T - Detect Events"
        '
        'DParamCheckBox
        '
        Me.DParamCheckBox.Location = New System.Drawing.Point(8, 168)
        Me.DParamCheckBox.Name = "DParamCheckBox"
        Me.DParamCheckBox.TabIndex = 5
        Me.DParamCheckBox.Text = "D - Digit Map"
        '
        'QParamCheckBox
        '
        Me.QParamCheckBox.Location = New System.Drawing.Point(8, 136)
        Me.QParamCheckBox.Name = "QParamCheckBox"
        Me.QParamCheckBox.Size = New System.Drawing.Size(152, 24)
        Me.QParamCheckBox.TabIndex = 4
        Me.QParamCheckBox.Text = "Q - Quarantine Handling"
        '
        'SParamCheckBox
        '
        Me.SParamCheckBox.Location = New System.Drawing.Point(8, 104)
        Me.SParamCheckBox.Name = "SParamCheckBox"
        Me.SParamCheckBox.Size = New System.Drawing.Size(128, 24)
        Me.SParamCheckBox.TabIndex = 3
        Me.SParamCheckBox.Text = "S - Signal Requests"
        '
        'RParamCheckBox
        '
        Me.RParamCheckBox.Location = New System.Drawing.Point(8, 72)
        Me.RParamCheckBox.Name = "RParamCheckBox"
        Me.RParamCheckBox.Size = New System.Drawing.Size(136, 24)
        Me.RParamCheckBox.TabIndex = 2
        Me.RParamCheckBox.Text = "R - Requested Events"
        '
        'NParamCheckBox
        '
        Me.NParamCheckBox.Location = New System.Drawing.Point(8, 40)
        Me.NParamCheckBox.Name = "NParamCheckBox"
        Me.NParamCheckBox.Size = New System.Drawing.Size(112, 24)
        Me.NParamCheckBox.TabIndex = 1
        Me.NParamCheckBox.Text = "N - Notified Entity"
        '
        'XParamCheckBox
        '
        Me.XParamCheckBox.Location = New System.Drawing.Point(8, 8)
        Me.XParamCheckBox.Name = "XParamCheckBox"
        Me.XParamCheckBox.TabIndex = 0
        Me.XParamCheckBox.Text = "X - Request ID"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(72, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(232, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Select the parameters to add to the message"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BuildButton
        '
        Me.BuildButton.Location = New System.Drawing.Point(104, 528)
        Me.BuildButton.Name = "BuildButton"
        Me.BuildButton.TabIndex = 4
        Me.BuildButton.Text = "Build"
        '
        'CancelButton
        '
        Me.CancelButton.Location = New System.Drawing.Point(192, 528)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.TabIndex = 5
        Me.CancelButton.Text = "Cancel"
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(8, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Parameter"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(224, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Value"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Desktop
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.Label3})
        Me.Panel1.Location = New System.Drawing.Point(8, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(352, 24)
        Me.Panel1.TabIndex = 8
        '
        'BuildMessage
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(368, 565)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.CancelButton, Me.BuildButton, Me.Label1, Me.MessagePanel, Me.MessageTypeLabel, Me.MessageTypeComboBox})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "BuildMessage"
        Me.Text = "Build NCS Message"
        Me.MessagePanel.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub BuildMessage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        Me.MessageTypeComboBox.Items.Add(ACK_NACK)
        Me.MessageTypeComboBox.Items.Add(AUCX)
        Me.MessageTypeComboBox.Items.Add(AUEP)
        Me.MessageTypeComboBox.Items.Add(CRCX)
        Me.MessageTypeComboBox.Items.Add(RQNT)
        Me.MessageTypeComboBox.Items.Add(MDCX)

    End Sub

    Private Sub MessageTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessageTypeComboBox.SelectedIndexChanged

        Dim type As String = Me.MessageTypeComboBox.SelectedItem

        Select Case (type)
            Case ACK_NACK
                Me.MessageTypeLabel.Text = DESC_ACK_NACK

                Me.XParamCheckBox.Enabled = False
                Me.NParamCheckBox.Enabled = False
                Me.RParamCheckBox.Enabled = False
                Me.SParamCheckBox.Enabled = False
                Me.QParamCheckBox.Enabled = False
                Me.DParamCheckBox.Enabled = False
                Me.TParamCheckBox.Enabled = False
                Me.CParamCheckBox.Enabled = False
                Me.IParamCheckBox.Enabled = False
                Me.MParamCheckBox.Enabled = False
                Me.LParamCheckBox.Enabled = False
                Me.RCDParamCheckBox.Enabled = False
                Me.FParamCheckBox.Enabled = False

                Me.XParamComboBox.Enabled = False
                Me.NParamComboBox.Enabled = False
                Me.RParamComboBox.Enabled = False
                Me.SParamComboBox.Enabled = False
                Me.QParamComboBox.Enabled = False
                Me.DParamComboBox.Enabled = False
                Me.TParamComboBox.Enabled = False
                Me.CParamComboBox.Enabled = False
                Me.IParamComboBox.Enabled = False
                Me.MParamComboBox.Enabled = False
                Me.LParamComboBox.Enabled = False
                Me.RCDParamComboBox.Enabled = False
                Me.FParamComboBox.Enabled = False
            Case AUCX
                Me.MessageTypeLabel.Text = DESC_AUCX

                Me.XParamCheckBox.Enabled = False
                Me.NParamCheckBox.Enabled = False
                Me.RParamCheckBox.Enabled = False
                Me.SParamCheckBox.Enabled = False
                Me.QParamCheckBox.Enabled = False
                Me.DParamCheckBox.Enabled = False
                Me.TParamCheckBox.Enabled = False
                Me.CParamCheckBox.Enabled = False
                Me.IParamCheckBox.Enabled = False
                Me.MParamCheckBox.Enabled = False
                Me.LParamCheckBox.Enabled = False
                Me.RCDParamCheckBox.Enabled = False
                Me.FParamCheckBox.Enabled = True

                Me.XParamComboBox.Enabled = False
                Me.NParamComboBox.Enabled = False
                Me.RParamComboBox.Enabled = False
                Me.SParamComboBox.Enabled = False
                Me.QParamComboBox.Enabled = False
                Me.DParamComboBox.Enabled = False
                Me.TParamComboBox.Enabled = False
                Me.CParamComboBox.Enabled = False
                Me.IParamComboBox.Enabled = False
                Me.MParamComboBox.Enabled = False
                Me.LParamComboBox.Enabled = False
                Me.RCDParamComboBox.Enabled = False
                Me.FParamComboBox.Enabled = True
            Case AUEP
                Me.MessageTypeLabel.Text = DESC_AUEP

                Me.XParamCheckBox.Enabled = False
                Me.NParamCheckBox.Enabled = False
                Me.RParamCheckBox.Enabled = False
                Me.SParamCheckBox.Enabled = False
                Me.QParamCheckBox.Enabled = False
                Me.DParamCheckBox.Enabled = False
                Me.TParamCheckBox.Enabled = False
                Me.CParamCheckBox.Enabled = False
                Me.IParamCheckBox.Enabled = False
                Me.MParamCheckBox.Enabled = False
                Me.LParamCheckBox.Enabled = False
                Me.RCDParamCheckBox.Enabled = False
                Me.FParamCheckBox.Enabled = True

                Me.XParamComboBox.Enabled = False
                Me.NParamComboBox.Enabled = False
                Me.RParamComboBox.Enabled = False
                Me.SParamComboBox.Enabled = False
                Me.QParamComboBox.Enabled = False
                Me.DParamComboBox.Enabled = False
                Me.TParamComboBox.Enabled = False
                Me.CParamComboBox.Enabled = False
                Me.IParamComboBox.Enabled = False
                Me.MParamComboBox.Enabled = False
                Me.LParamComboBox.Enabled = False
                Me.RCDParamComboBox.Enabled = False
                Me.FParamComboBox.Enabled = True
            Case CRCX
                Me.MessageTypeLabel.Text = DESC_CRCX

                Me.XParamCheckBox.Enabled = True
                Me.NParamCheckBox.Enabled = True
                Me.RParamCheckBox.Enabled = True
                Me.SParamCheckBox.Enabled = True
                Me.QParamCheckBox.Enabled = True
                Me.DParamCheckBox.Enabled = True
                Me.TParamCheckBox.Enabled = True
                Me.CParamCheckBox.Enabled = True
                Me.IParamCheckBox.Enabled = True
                Me.MParamCheckBox.Enabled = True
                Me.LParamCheckBox.Enabled = True
                Me.RCDParamCheckBox.Enabled = True
                Me.FParamCheckBox.Enabled = False

                Me.XParamComboBox.Enabled = True
                Me.NParamComboBox.Enabled = True
                Me.RParamComboBox.Enabled = True
                Me.SParamComboBox.Enabled = True
                Me.QParamComboBox.Enabled = True
                Me.DParamComboBox.Enabled = True
                Me.TParamComboBox.Enabled = True
                Me.CParamComboBox.Enabled = True
                Me.IParamComboBox.Enabled = True
                Me.MParamComboBox.Enabled = True
                Me.LParamComboBox.Enabled = True
                Me.RCDParamComboBox.Enabled = True
                Me.FParamComboBox.Enabled = False

            Case DLCX
                Me.MessageTypeLabel.Text = DESC_DLCX

                Me.XParamCheckBox.Enabled = True
                Me.NParamCheckBox.Enabled = True
                Me.RParamCheckBox.Enabled = True
                Me.SParamCheckBox.Enabled = True
                Me.QParamCheckBox.Enabled = True
                Me.DParamCheckBox.Enabled = True
                Me.TParamCheckBox.Enabled = True
                Me.CParamCheckBox.Enabled = True
                Me.IParamCheckBox.Enabled = True
                Me.MParamCheckBox.Enabled = False
                Me.LParamCheckBox.Enabled = False
                Me.RCDParamCheckBox.Enabled = False
                Me.FParamCheckBox.Enabled = False

                Me.XParamComboBox.Enabled = True
                Me.NParamComboBox.Enabled = True
                Me.RParamComboBox.Enabled = True
                Me.SParamComboBox.Enabled = True
                Me.QParamComboBox.Enabled = True
                Me.DParamComboBox.Enabled = True
                Me.TParamComboBox.Enabled = True
                Me.CParamComboBox.Enabled = True
                Me.IParamComboBox.Enabled = True
                Me.MParamComboBox.Enabled = False
                Me.LParamComboBox.Enabled = False
                Me.RCDParamComboBox.Enabled = False
                Me.FParamComboBox.Enabled = False
            Case RQNT
                Me.MessageTypeLabel.Text = DESC_RQNT

                Me.XParamCheckBox.Enabled = True
                Me.NParamCheckBox.Enabled = True
                Me.RParamCheckBox.Enabled = True
                Me.SParamCheckBox.Enabled = True
                Me.QParamCheckBox.Enabled = True
                Me.DParamCheckBox.Enabled = True
                Me.TParamCheckBox.Enabled = True
                Me.CParamCheckBox.Enabled = False
                Me.IParamCheckBox.Enabled = False
                Me.MParamCheckBox.Enabled = False
                Me.LParamCheckBox.Enabled = False
                Me.RCDParamCheckBox.Enabled = False
                Me.FParamCheckBox.Enabled = False

                Me.XParamComboBox.Enabled = True
                Me.NParamComboBox.Enabled = True
                Me.RParamComboBox.Enabled = True
                Me.SParamComboBox.Enabled = True
                Me.QParamComboBox.Enabled = True
                Me.DParamComboBox.Enabled = True
                Me.TParamComboBox.Enabled = True
                Me.CParamComboBox.Enabled = False
                Me.IParamComboBox.Enabled = False
                Me.MParamComboBox.Enabled = False
                Me.LParamComboBox.Enabled = False
                Me.RCDParamComboBox.Enabled = False
                Me.FParamComboBox.Enabled = False
            Case MDCX
                Me.MessageTypeLabel.Text = DESC_MDCX
                Me.XParamCheckBox.Enabled = True
                Me.NParamCheckBox.Enabled = True
                Me.RParamCheckBox.Enabled = True
                Me.SParamCheckBox.Enabled = True
                Me.QParamCheckBox.Enabled = True
                Me.DParamCheckBox.Enabled = True
                Me.TParamCheckBox.Enabled = True
                Me.CParamCheckBox.Enabled = True
                Me.IParamCheckBox.Enabled = True
                Me.MParamCheckBox.Enabled = True
                Me.LParamCheckBox.Enabled = True
                Me.RCDParamCheckBox.Enabled = True
                Me.FParamCheckBox.Enabled = False

                Me.XParamComboBox.Enabled = True
                Me.NParamComboBox.Enabled = True
                Me.RParamComboBox.Enabled = True
                Me.SParamComboBox.Enabled = True
                Me.QParamComboBox.Enabled = True
                Me.DParamComboBox.Enabled = True
                Me.TParamComboBox.Enabled = True
                Me.CParamComboBox.Enabled = True
                Me.IParamComboBox.Enabled = True
                Me.MParamComboBox.Enabled = True
                Me.LParamComboBox.Enabled = True
                Me.RCDParamComboBox.Enabled = True
                Me.FParamComboBox.Enabled = False

        End Select
    End Sub

  
    Private Sub BuildButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuildButton.Click

        Dim type As String = Me.MessageTypeComboBox.SelectedItem

        'first make sure a message type was selected
        If (type = String.Empty And type <> Me.ACK_NACK And _
            type <> AUCX And type <> AUEP And type <> CRCX And _
            type <> DLCX And type <> MDCX And type <> RQNT) Then
            MsgBox("Please choose a message type from the top drop down box")
            Exit Sub
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '                   BUILD Message                        '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim message As String = ""

        Select Case type

            Case ACK_NACK
                message = "AUCX transid fqdn MGCP 1.0 NCS 1.0" & vbCrLf
            Case AUCX
                message = "AUCX transid fqdn MGCP 1.0 NCS 1.0" & vbCrLf
            Case AUEP
                message = "AUEP transid fqdn MGCP 1.0 NCS 1.0" & vbCrLf
            Case CRCX
                message = "CRCX transid fqdn MGCP 1.0 NCS 1.0" & vbCrLf
            Case DLCX
                message = "DLCX transid fqdn MGCP 1.0 NCS 1.0" & vbCrLf
            Case MDCX
                message = "MDCX transid fqdn MGCP 1.0 NCS 1.0" & vbCrLf
            Case RQNT
                message = "RQNT transid fqdn MGCP 1.0 NCS 1.0" & vbCrLf
        End Select

        message += GetParamValue("x", Me.XParamCheckBox, Me.XParamComboBox)
        message += GetParamValue("n", Me.NParamCheckBox, Me.NParamComboBox)
        message += GetParamValue("r", Me.RParamCheckBox, Me.RParamComboBox)
        message += GetParamValue("s", Me.SParamCheckBox, Me.SParamComboBox)
        message += GetParamValue("q", Me.QParamCheckBox, Me.QParamComboBox)
        message += GetParamValue("d", Me.DParamCheckBox, Me.DParamComboBox)
        message += GetParamValue("t", Me.TParamCheckBox, Me.TParamComboBox)
        message += GetParamValue("c", Me.CParamCheckBox, Me.CParamComboBox)
        message += GetParamValue("i", Me.IParamCheckBox, Me.IParamComboBox)
        message += GetParamValue("m", Me.MParamCheckBox, Me.MParamComboBox)
        message += GetParamValue("l", Me.LParamCheckBox, Me.LParamComboBox)
        message += GetParamValue("rcd", Me.RCDParamCheckBox, Me.RCDParamComboBox)
        message += GetParamValue("f", Me.FParamCheckBox, Me.FParamComboBox)


        Me.Close()

        'create new message
        Dim builtMessage As New MessageForm(mainform)
        builtMessage.RichTextBox.Text = message
        builtMessage.MdiParent = mainform
        builtMessage.NeedSave = True
        builtMessage.Show()

        'turn on buttons if they need to
        mainform.SetNonEmptyMDIButtons()

    End Sub

    Private Function GetParamValue(ByVal param As String, ByVal checkBox As CheckBox, ByVal comboBox As ComboBox) As String

        Dim strValue As String

        'first make sure box is enabled
        If (comboBox.Enabled = True) Then

            'if checked, get value
            If (checkBox.Checked = True) Then

                'if box contains default text, then just give empty parameter
                If (InStr(comboBox.Text, "Select/Edit") Or InStr(comboBox.Text, "<empty>")) Then
                    strValue = param + ": "
                Else
                    'get value of parameter
                    strValue = param + ": " + comboBox.Text

                End If

                'do nothing
            Else
                Return ""
            End If

            'do nothing
        Else
            Return ""
        End If

        strValue += vbCrLf

        Return strValue
    End Function

    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Me.Dispose()

    End Sub

    Private Sub RParamCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RParamCheckBox.CheckedChanged
        Me.XParamCheckBox.Checked = True
    End Sub

    Private Sub SParamCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SParamCheckBox.CheckedChanged
        Me.XParamCheckBox.Checked = True
    End Sub

    Private Sub QParamCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QParamCheckBox.CheckedChanged
        Me.XParamCheckBox.Checked = True
    End Sub

    Private Sub DParamCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DParamCheckBox.CheckedChanged
        Me.XParamCheckBox.Checked = True
    End Sub



End Class
