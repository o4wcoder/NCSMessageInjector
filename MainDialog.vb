Imports System.IO
Imports System.Text
Imports System.Drawing.Printing
Imports System.Net
Imports System.Net.Sockets
Imports System.Environment



Public Class MainDialog
    Inherits System.Windows.Forms.Form


    Public DeletingMTA As Boolean = False

    Public MESSAGE_DIRECTORY As String = CurDir() & "/messages/"



    Public activeChild As New MessageForm(Me)

    Dim piggybackMessage() As String
    Dim piggyCounter As Integer = 0

    '''''''''''''''''' Socket Info ''''''''''''''''''''''''
    Public receiveThread As New System.Threading.Thread(AddressOf ReceiveMsg)
    Public currentMTAIp As String
    Public currentFQDN As String
    Public currentLineNumber As String
    Public currentRecPort As String
    Public currentDestPort As String
    Public LocalIpAddress As IPAddress
    Public mgcpSocket As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)




    ' printing seteup
    Private PrintPageSettings As New PageSettings()
    Private StringToPrint As String
    Private CurrentPage As Integer = 1
    Private PrintFont As New Font("Arail", 10)
    Friend WithEvents DirectorySearcher1 As System.DirectoryServices.DirectorySearcher
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents DirectoryEntry1 As System.DirectoryServices.DirectoryEntry
    Friend WithEvents DirectoryEntry2 As System.DirectoryServices.DirectoryEntry
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BlankMessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BlankMessageFromTemplateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PageSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MessageConsoleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeConsoleColorsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BlackOnWhiteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WhiteOnBlackToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents YellowOnBlueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrangeOnBlueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditCurrentSDPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileVerticallyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileHorizontallyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutNCSMessageInjectorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ButtonToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintPreviewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CopyToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PasteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents MTALabel As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents FQDNToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents FQDNLabel As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents LineNumberComboBox As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents CurrentMessageFileToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents MessageFileLabel As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OptionsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents BlankMessageToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewMessageFromTemplateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MessageConsole As System.Windows.Forms.RichTextBox
    Friend WithEvents MTAControlsPanel As System.Windows.Forms.Panel
    Friend WithEvents MTAListView As System.Windows.Forms.ListView
    Friend WithEvents IPAddressHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents FQDNHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents RecPortHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents DestPortHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents MessageFileTreeLabel As System.Windows.Forms.Label
    Friend WithEvents MTAConnectionsLabel As System.Windows.Forms.Label
    Friend WithEvents MessageFileTreeView As System.Windows.Forms.TreeView
    Friend WithEvents MTAControlsSplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents MTAConnectionsCenterPanel As System.Windows.Forms.Panel
    Friend WithEvents MessageFileCenterPanel As System.Windows.Forms.Panel
    Friend WithEvents MTAConnectionsToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents AddMTAToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DeleteMTAToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CallToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents MessageConsolePanel As System.Windows.Forms.Panel
    Friend WithEvents MTAConnectionsBottomPanel As System.Windows.Forms.Panel
    Friend WithEvents MTAConnectionsTopPanel As System.Windows.Forms.Panel
    Friend WithEvents MessageFileTreeCenterPanel As System.Windows.Forms.Panel
    Friend WithEvents MessageFileTreeTopPanel As System.Windows.Forms.Panel
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents MTAConnectionButtonPanel As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MTAConnectionsContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditMTAConnectionsContextMenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteMtaConnectionsContextMenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ConnectMtaConnectionsContextMenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MessageFileTreeContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OpenFileMessageFileTreeContextMenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddFolderMessageFileTreeViewContextMenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteMessageFileTreeContextMenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshMessageFileTreeViewContextMenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExpandMessageFileTreeContextMenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExpandAllMessageFileTreeContextMenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Private BoldPrintFont As New Font("Arial", 10, FontStyle.Bold)

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
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents PiggyDelayTimer As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainDialog))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.PiggyDelayTimer = New System.Windows.Forms.Timer(Me.components)
        Me.DirectorySearcher1 = New System.DirectoryServices.DirectorySearcher
        Me.DirectoryEntry1 = New System.DirectoryServices.DirectoryEntry
        Me.DirectoryEntry2 = New System.DirectoryServices.DirectoryEntry
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BlankMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BlankMessageFromTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PageSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MessageConsoleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ChangeConsoleColorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BlackOnWhiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WhiteOnBlackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.YellowOnBlueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OrangeOnBlueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.EditCurrentSDPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.OptionsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TileVerticallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TileHorizontallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutNCSMessageInjectorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.ButtonToolStrip = New System.Windows.Forms.ToolStrip
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripDropDownButton
        Me.BlankMessageToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.NewMessageFromTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PrintPreviewToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PasteToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.MTALabel = New System.Windows.Forms.ToolStripTextBox
        Me.FQDNToolStripLabel = New System.Windows.Forms.ToolStripLabel
        Me.FQDNLabel = New System.Windows.Forms.ToolStripTextBox
        Me.LineNumberComboBox = New System.Windows.Forms.ToolStripComboBox
        Me.CurrentMessageFileToolStripLabel = New System.Windows.Forms.ToolStripLabel
        Me.MessageFileLabel = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.MessageConsole = New System.Windows.Forms.RichTextBox
        Me.MTAControlsPanel = New System.Windows.Forms.Panel
        Me.MTAControlsSplitContainer = New System.Windows.Forms.SplitContainer
        Me.MTAConnectionsBottomPanel = New System.Windows.Forms.Panel
        Me.MTAConnectionsToolStrip = New System.Windows.Forms.ToolStrip
        Me.AddMTAToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.DeleteMTAToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.CallToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.MTAConnectionButtonPanel = New System.Windows.Forms.Panel
        Me.MTAConnectionsCenterPanel = New System.Windows.Forms.Panel
        Me.MTAListView = New System.Windows.Forms.ListView
        Me.IPAddressHeader = New System.Windows.Forms.ColumnHeader
        Me.FQDNHeader = New System.Windows.Forms.ColumnHeader
        Me.RecPortHeader = New System.Windows.Forms.ColumnHeader
        Me.DestPortHeader = New System.Windows.Forms.ColumnHeader
        Me.MTAConnectionsContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditMTAConnectionsContextMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteMtaConnectionsContextMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me.ConnectMtaConnectionsContextMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MTAConnectionsTopPanel = New System.Windows.Forms.Panel
        Me.MTAConnectionsLabel = New System.Windows.Forms.Label
        Me.MessageFileCenterPanel = New System.Windows.Forms.Panel
        Me.MessageFileTreeCenterPanel = New System.Windows.Forms.Panel
        Me.MessageFileTreeView = New System.Windows.Forms.TreeView
        Me.MessageFileTreeContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenFileMessageFileTreeContextMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
        Me.RefreshMessageFileTreeViewContextMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator
        Me.AddFolderMessageFileTreeViewContextMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteMessageFileTreeContextMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MessageFileTreeTopPanel = New System.Windows.Forms.Panel
        Me.MessageFileTreeLabel = New System.Windows.Forms.Label
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.MessageConsolePanel = New System.Windows.Forms.Panel
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.ExpandMessageFileTreeContextMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExpandAllMessageFileTreeContextMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator
        Me.MenuStrip.SuspendLayout()
        Me.ButtonToolStrip.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.MTAControlsPanel.SuspendLayout()
        Me.MTAControlsSplitContainer.Panel1.SuspendLayout()
        Me.MTAControlsSplitContainer.Panel2.SuspendLayout()
        Me.MTAControlsSplitContainer.SuspendLayout()
        Me.MTAConnectionsBottomPanel.SuspendLayout()
        Me.MTAConnectionsToolStrip.SuspendLayout()
        Me.MTAConnectionsCenterPanel.SuspendLayout()
        Me.MTAConnectionsContextMenuStrip.SuspendLayout()
        Me.MTAConnectionsTopPanel.SuspendLayout()
        Me.MessageFileCenterPanel.SuspendLayout()
        Me.MessageFileTreeCenterPanel.SuspendLayout()
        Me.MessageFileTreeContextMenuStrip.SuspendLayout()
        Me.MessageFileTreeTopPanel.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.MessageConsolePanel.SuspendLayout()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        Me.ImageList1.Images.SetKeyName(8, "")
        Me.ImageList1.Images.SetKeyName(9, "")
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "file.ico")
        Me.ImageList2.Images.SetKeyName(1, "")
        Me.ImageList2.Images.SetKeyName(2, "open.ico")
        Me.ImageList2.Images.SetKeyName(3, "Modem-16x16.png")
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'PiggyDelayTimer
        '
        Me.PiggyDelayTimer.Interval = 1
        '
        'DirectorySearcher1
        '
        Me.DirectorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01")
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.CloseToolStripMenuItem, Me.ToolStripSeparator1, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ToolStripSeparator2, Me.PrintToolStripMenuItem, Me.PrintPreviewToolStripMenuItem, Me.PageSetupToolStripMenuItem, Me.ToolStripSeparator3, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BlankMessageToolStripMenuItem, Me.BlankMessageFromTemplateToolStripMenuItem})
        Me.NewToolStripMenuItem.Image = CType(resources.GetObject("NewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'BlankMessageToolStripMenuItem
        '
        Me.BlankMessageToolStripMenuItem.Name = "BlankMessageToolStripMenuItem"
        Me.BlankMessageToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.BlankMessageToolStripMenuItem.Text = "Blank Message"
        '
        'BlankMessageFromTemplateToolStripMenuItem
        '
        Me.BlankMessageFromTemplateToolStripMenuItem.Name = "BlankMessageFromTemplateToolStripMenuItem"
        Me.BlankMessageFromTemplateToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.BlankMessageFromTemplateToolStripMenuItem.Text = "New Message From Template"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = CType(resources.GetObject("OpenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.OpenToolStripMenuItem.Text = "Open..."
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(182, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Image = CType(resources.GetObject("SaveToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.SaveToolStripMenuItem.Text = "Save..."
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save As..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(182, 6)
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Image = CType(resources.GetObject("PrintToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.PrintToolStripMenuItem.Text = "Print..."
        '
        'PrintPreviewToolStripMenuItem
        '
        Me.PrintPreviewToolStripMenuItem.Name = "PrintPreviewToolStripMenuItem"
        Me.PrintPreviewToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.PrintPreviewToolStripMenuItem.Text = "Print Preview..."
        '
        'PageSetupToolStripMenuItem
        '
        Me.PageSetupToolStripMenuItem.Name = "PageSetupToolStripMenuItem"
        Me.PageSetupToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.PageSetupToolStripMenuItem.Text = "Page Setup..."
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(182, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Image = CType(resources.GetObject("CutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Image = CType(resources.GetObject("CopyToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Image = CType(resources.GetObject("PasteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MessageConsoleToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(42, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'MessageConsoleToolStripMenuItem
        '
        Me.MessageConsoleToolStripMenuItem.Checked = True
        Me.MessageConsoleToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MessageConsoleToolStripMenuItem.Name = "MessageConsoleToolStripMenuItem"
        Me.MessageConsoleToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.MessageConsoleToolStripMenuItem.Text = "Message Console"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeConsoleColorsToolStripMenuItem, Me.ToolStripSeparator4, Me.EditCurrentSDPToolStripMenuItem, Me.ToolStripSeparator7, Me.OptionsToolStripMenuItem1})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'ChangeConsoleColorsToolStripMenuItem
        '
        Me.ChangeConsoleColorsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BlackOnWhiteToolStripMenuItem, Me.WhiteOnBlackToolStripMenuItem, Me.YellowOnBlueToolStripMenuItem, Me.OrangeOnBlueToolStripMenuItem})
        Me.ChangeConsoleColorsToolStripMenuItem.Name = "ChangeConsoleColorsToolStripMenuItem"
        Me.ChangeConsoleColorsToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ChangeConsoleColorsToolStripMenuItem.Text = "Change Console Colors"
        '
        'BlackOnWhiteToolStripMenuItem
        '
        Me.BlackOnWhiteToolStripMenuItem.Checked = True
        Me.BlackOnWhiteToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.BlackOnWhiteToolStripMenuItem.Name = "BlackOnWhiteToolStripMenuItem"
        Me.BlackOnWhiteToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.BlackOnWhiteToolStripMenuItem.Text = "Black on White"
        '
        'WhiteOnBlackToolStripMenuItem
        '
        Me.WhiteOnBlackToolStripMenuItem.Name = "WhiteOnBlackToolStripMenuItem"
        Me.WhiteOnBlackToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.WhiteOnBlackToolStripMenuItem.Text = "White on Black"
        '
        'YellowOnBlueToolStripMenuItem
        '
        Me.YellowOnBlueToolStripMenuItem.Name = "YellowOnBlueToolStripMenuItem"
        Me.YellowOnBlueToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.YellowOnBlueToolStripMenuItem.Text = "Yellow on Blue"
        '
        'OrangeOnBlueToolStripMenuItem
        '
        Me.OrangeOnBlueToolStripMenuItem.Name = "OrangeOnBlueToolStripMenuItem"
        Me.OrangeOnBlueToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.OrangeOnBlueToolStripMenuItem.Text = "Orange on Blue"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(181, 6)
        '
        'EditCurrentSDPToolStripMenuItem
        '
        Me.EditCurrentSDPToolStripMenuItem.Name = "EditCurrentSDPToolStripMenuItem"
        Me.EditCurrentSDPToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.EditCurrentSDPToolStripMenuItem.Text = "Edit Current SDP"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(181, 6)
        '
        'OptionsToolStripMenuItem1
        '
        Me.OptionsToolStripMenuItem1.Name = "OptionsToolStripMenuItem1"
        Me.OptionsToolStripMenuItem1.Size = New System.Drawing.Size(184, 22)
        Me.OptionsToolStripMenuItem1.Text = "Options..."
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CascadeToolStripMenuItem, Me.TileVerticallyToolStripMenuItem, Me.TileHorizontallyToolStripMenuItem})
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.WindowToolStripMenuItem.Text = "Window"
        '
        'CascadeToolStripMenuItem
        '
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.CascadeToolStripMenuItem.Text = "Cascade"
        '
        'TileVerticallyToolStripMenuItem
        '
        Me.TileVerticallyToolStripMenuItem.Name = "TileVerticallyToolStripMenuItem"
        Me.TileVerticallyToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.TileVerticallyToolStripMenuItem.Text = "Tile Vertically"
        '
        'TileHorizontallyToolStripMenuItem
        '
        Me.TileHorizontallyToolStripMenuItem.Name = "TileHorizontallyToolStripMenuItem"
        Me.TileHorizontallyToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.TileHorizontallyToolStripMenuItem.Text = "Tile Horizontally"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutNCSMessageInjectorToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutNCSMessageInjectorToolStripMenuItem
        '
        Me.AboutNCSMessageInjectorToolStripMenuItem.Name = "AboutNCSMessageInjectorToolStripMenuItem"
        Me.AboutNCSMessageInjectorToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.AboutNCSMessageInjectorToolStripMenuItem.Text = "About NCS Message Injector"
        '
        'MenuStrip
        '
        Me.MenuStrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ViewToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.WindowToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(782, 24)
        Me.MenuStrip.TabIndex = 40
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'ButtonToolStrip
        '
        Me.ButtonToolStrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ButtonToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.OpenToolStripButton, Me.SaveToolStripButton, Me.ToolStripSeparator5, Me.PrintToolStripButton, Me.PrintPreviewToolStripButton, Me.ToolStripSeparator6, Me.CutToolStripButton, Me.CopyToolStripButton, Me.PasteToolStripButton})
        Me.ButtonToolStrip.Location = New System.Drawing.Point(0, 24)
        Me.ButtonToolStrip.Name = "ButtonToolStrip"
        Me.ButtonToolStrip.Size = New System.Drawing.Size(782, 25)
        Me.ButtonToolStrip.TabIndex = 41
        Me.ButtonToolStrip.Text = "ToolStrip1"
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BlankMessageToolStripMenuItem1, Me.NewMessageFromTemplateToolStripMenuItem})
        Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"), System.Drawing.Image)
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(29, 22)
        Me.NewToolStripButton.ToolTipText = "New Blank Message File"
        '
        'BlankMessageToolStripMenuItem1
        '
        Me.BlankMessageToolStripMenuItem1.Name = "BlankMessageToolStripMenuItem1"
        Me.BlankMessageToolStripMenuItem1.Size = New System.Drawing.Size(215, 22)
        Me.BlankMessageToolStripMenuItem1.Text = "Blank Message"
        '
        'NewMessageFromTemplateToolStripMenuItem
        '
        Me.NewMessageFromTemplateToolStripMenuItem.Name = "NewMessageFromTemplateToolStripMenuItem"
        Me.NewMessageFromTemplateToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.NewMessageFromTemplateToolStripMenuItem.Text = "New Message From Template"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "ToolStripButton1"
        Me.OpenToolStripButton.ToolTipText = "Open Message File"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "ToolStripButton1"
        Me.SaveToolStripButton.ToolTipText = "Save Message File"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "ToolStripButton1"
        Me.PrintToolStripButton.ToolTipText = "Print current message"
        '
        'PrintPreviewToolStripButton
        '
        Me.PrintPreviewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintPreviewToolStripButton.Image = CType(resources.GetObject("PrintPreviewToolStripButton.Image"), System.Drawing.Image)
        Me.PrintPreviewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintPreviewToolStripButton.Name = "PrintPreviewToolStripButton"
        Me.PrintPreviewToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintPreviewToolStripButton.Text = "ToolStripButton1"
        Me.PrintPreviewToolStripButton.ToolTipText = "Print preview of current message file"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'CutToolStripButton
        '
        Me.CutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CutToolStripButton.Image = CType(resources.GetObject("CutToolStripButton.Image"), System.Drawing.Image)
        Me.CutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripButton.Name = "CutToolStripButton"
        Me.CutToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CutToolStripButton.Text = "ToolStripButton1"
        Me.CutToolStripButton.ToolTipText = "Cut"
        '
        'CopyToolStripButton
        '
        Me.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyToolStripButton.Image = CType(resources.GetObject("CopyToolStripButton.Image"), System.Drawing.Image)
        Me.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripButton.Name = "CopyToolStripButton"
        Me.CopyToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CopyToolStripButton.Text = "ToolStripButton1"
        Me.CopyToolStripButton.ToolTipText = "Copy"
        '
        'PasteToolStripButton
        '
        Me.PasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PasteToolStripButton.Image = CType(resources.GetObject("PasteToolStripButton.Image"), System.Drawing.Image)
        Me.PasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteToolStripButton.Name = "PasteToolStripButton"
        Me.PasteToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PasteToolStripButton.Text = "ToolStripButton1"
        Me.PasteToolStripButton.ToolTipText = "Paste"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.MTALabel, Me.FQDNToolStripLabel, Me.FQDNLabel, Me.LineNumberComboBox, Me.CurrentMessageFileToolStripLabel, Me.MessageFileLabel, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 49)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(782, 25)
        Me.ToolStrip1.TabIndex = 43
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(67, 22)
        Me.ToolStripLabel1.Text = "Current MTA"
        '
        'MTALabel
        '
        Me.MTALabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MTALabel.Name = "MTALabel"
        Me.MTALabel.Size = New System.Drawing.Size(100, 25)
        '
        'FQDNToolStripLabel
        '
        Me.FQDNToolStripLabel.BackColor = System.Drawing.SystemColors.ControlText
        Me.FQDNToolStripLabel.Name = "FQDNToolStripLabel"
        Me.FQDNToolStripLabel.Size = New System.Drawing.Size(37, 22)
        Me.FQDNToolStripLabel.Text = "FQDN"
        '
        'FQDNLabel
        '
        Me.FQDNLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FQDNLabel.Name = "FQDNLabel"
        Me.FQDNLabel.Size = New System.Drawing.Size(100, 25)
        '
        'LineNumberComboBox
        '
        Me.LineNumberComboBox.AutoSize = False
        Me.LineNumberComboBox.DropDownWidth = 20
        Me.LineNumberComboBox.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "$", "*"})
        Me.LineNumberComboBox.Name = "LineNumberComboBox"
        Me.LineNumberComboBox.Size = New System.Drawing.Size(55, 21)
        Me.LineNumberComboBox.Text = "Line #"
        '
        'CurrentMessageFileToolStripLabel
        '
        Me.CurrentMessageFileToolStripLabel.Name = "CurrentMessageFileToolStripLabel"
        Me.CurrentMessageFileToolStripLabel.Size = New System.Drawing.Size(106, 22)
        Me.CurrentMessageFileToolStripLabel.Text = "Current Message File"
        '
        'MessageFileLabel
        '
        Me.MessageFileLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MessageFileLabel.Name = "MessageFileLabel"
        Me.MessageFileLabel.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.BackColor = System.Drawing.Color.Firebrick
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripButton1.Text = "Inject"
        '
        'MessageConsole
        '
        Me.MessageConsole.BackColor = System.Drawing.Color.White
        Me.MessageConsole.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MessageConsole.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MessageConsole.ForeColor = System.Drawing.Color.Black
        Me.MessageConsole.Location = New System.Drawing.Point(1, 1)
        Me.MessageConsole.Name = "MessageConsole"
        Me.MessageConsole.Size = New System.Drawing.Size(232, 568)
        Me.MessageConsole.TabIndex = 24
        Me.MessageConsole.Text = ""
        '
        'MTAControlsPanel
        '
        Me.MTAControlsPanel.BackColor = System.Drawing.SystemColors.Control
        Me.MTAControlsPanel.Controls.Add(Me.MTAControlsSplitContainer)
        Me.MTAControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MTAControlsPanel.Location = New System.Drawing.Point(0, 0)
        Me.MTAControlsPanel.Name = "MTAControlsPanel"
        Me.MTAControlsPanel.Size = New System.Drawing.Size(215, 570)
        Me.MTAControlsPanel.TabIndex = 12
        '
        'MTAControlsSplitContainer
        '
        Me.MTAControlsSplitContainer.BackColor = System.Drawing.SystemColors.Control
        Me.MTAControlsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MTAControlsSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.MTAControlsSplitContainer.Name = "MTAControlsSplitContainer"
        Me.MTAControlsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'MTAControlsSplitContainer.Panel1
        '
        Me.MTAControlsSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MTAControlsSplitContainer.Panel1.Controls.Add(Me.MTAConnectionsBottomPanel)
        Me.MTAControlsSplitContainer.Panel1.Controls.Add(Me.MTAConnectionsCenterPanel)
        Me.MTAControlsSplitContainer.Panel1.Controls.Add(Me.MTAConnectionsTopPanel)
        Me.MTAControlsSplitContainer.Panel1.Margin = New System.Windows.Forms.Padding(3)
        Me.MTAControlsSplitContainer.Panel1.Padding = New System.Windows.Forms.Padding(1)
        '
        'MTAControlsSplitContainer.Panel2
        '
        Me.MTAControlsSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MTAControlsSplitContainer.Panel2.Controls.Add(Me.MessageFileCenterPanel)
        Me.MTAControlsSplitContainer.Panel2.Margin = New System.Windows.Forms.Padding(3)
        Me.MTAControlsSplitContainer.Panel2.Padding = New System.Windows.Forms.Padding(1)
        Me.MTAControlsSplitContainer.Size = New System.Drawing.Size(215, 570)
        Me.MTAControlsSplitContainer.SplitterDistance = 245
        Me.MTAControlsSplitContainer.SplitterWidth = 3
        Me.MTAControlsSplitContainer.TabIndex = 0
        '
        'MTAConnectionsBottomPanel
        '
        Me.MTAConnectionsBottomPanel.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MTAConnectionsBottomPanel.Controls.Add(Me.MTAConnectionsToolStrip)
        Me.MTAConnectionsBottomPanel.Controls.Add(Me.MTAConnectionButtonPanel)
        Me.MTAConnectionsBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MTAConnectionsBottomPanel.Location = New System.Drawing.Point(1, 215)
        Me.MTAConnectionsBottomPanel.Name = "MTAConnectionsBottomPanel"
        Me.MTAConnectionsBottomPanel.Padding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.MTAConnectionsBottomPanel.Size = New System.Drawing.Size(213, 29)
        Me.MTAConnectionsBottomPanel.TabIndex = 3
        '
        'MTAConnectionsToolStrip
        '
        Me.MTAConnectionsToolStrip.BackColor = System.Drawing.SystemColors.Control
        Me.MTAConnectionsToolStrip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MTAConnectionsToolStrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.MTAConnectionsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.MTAConnectionsToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddMTAToolStripButton, Me.DeleteMTAToolStripButton, Me.ToolStripSeparator8, Me.CallToolStripButton})
        Me.MTAConnectionsToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MTAConnectionsToolStrip.Location = New System.Drawing.Point(0, 1)
        Me.MTAConnectionsToolStrip.Name = "MTAConnectionsToolStrip"
        Me.MTAConnectionsToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MTAConnectionsToolStrip.Size = New System.Drawing.Size(213, 28)
        Me.MTAConnectionsToolStrip.TabIndex = 0
        Me.MTAConnectionsToolStrip.Text = "ToolStrip2"
        '
        'AddMTAToolStripButton
        '
        Me.AddMTAToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AddMTAToolStripButton.Image = CType(resources.GetObject("AddMTAToolStripButton.Image"), System.Drawing.Image)
        Me.AddMTAToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddMTAToolStripButton.Name = "AddMTAToolStripButton"
        Me.AddMTAToolStripButton.Size = New System.Drawing.Size(23, 25)
        Me.AddMTAToolStripButton.Text = "AddMTAToolStripButton"
        Me.AddMTAToolStripButton.ToolTipText = "Add a new MTA"
        '
        'DeleteMTAToolStripButton
        '
        Me.DeleteMTAToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DeleteMTAToolStripButton.Image = CType(resources.GetObject("DeleteMTAToolStripButton.Image"), System.Drawing.Image)
        Me.DeleteMTAToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeleteMTAToolStripButton.Name = "DeleteMTAToolStripButton"
        Me.DeleteMTAToolStripButton.Size = New System.Drawing.Size(23, 25)
        Me.DeleteMTAToolStripButton.Text = "ToolStripButton3"
        Me.DeleteMTAToolStripButton.ToolTipText = "Delete selected MTA"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 28)
        '
        'CallToolStripButton
        '
        Me.CallToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CallToolStripButton.Image = CType(resources.GetObject("CallToolStripButton.Image"), System.Drawing.Image)
        Me.CallToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CallToolStripButton.Name = "CallToolStripButton"
        Me.CallToolStripButton.Size = New System.Drawing.Size(23, 25)
        Me.CallToolStripButton.Text = "ToolStripButton4"
        Me.CallToolStripButton.ToolTipText = "Set up a call between two endpoints"
        '
        'MTAConnectionButtonPanel
        '
        Me.MTAConnectionButtonPanel.BackColor = System.Drawing.SystemColors.Control
        Me.MTAConnectionButtonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MTAConnectionButtonPanel.Location = New System.Drawing.Point(0, 1)
        Me.MTAConnectionButtonPanel.Name = "MTAConnectionButtonPanel"
        Me.MTAConnectionButtonPanel.Size = New System.Drawing.Size(213, 28)
        Me.MTAConnectionButtonPanel.TabIndex = 56
        '
        'MTAConnectionsCenterPanel
        '
        Me.MTAConnectionsCenterPanel.BackColor = System.Drawing.SystemColors.Control
        Me.MTAConnectionsCenterPanel.Controls.Add(Me.MTAListView)
        Me.MTAConnectionsCenterPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MTAConnectionsCenterPanel.Location = New System.Drawing.Point(1, 25)
        Me.MTAConnectionsCenterPanel.Name = "MTAConnectionsCenterPanel"
        Me.MTAConnectionsCenterPanel.Padding = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.MTAConnectionsCenterPanel.Size = New System.Drawing.Size(213, 219)
        Me.MTAConnectionsCenterPanel.TabIndex = 2
        '
        'MTAListView
        '
        Me.MTAListView.BackColor = System.Drawing.SystemColors.Window
        Me.MTAListView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MTAListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IPAddressHeader, Me.FQDNHeader, Me.RecPortHeader, Me.DestPortHeader})
        Me.MTAListView.ContextMenuStrip = Me.MTAConnectionsContextMenuStrip
        Me.MTAListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MTAListView.FullRowSelect = True
        Me.MTAListView.Location = New System.Drawing.Point(0, 0)
        Me.MTAListView.MultiSelect = False
        Me.MTAListView.Name = "MTAListView"
        Me.MTAListView.Size = New System.Drawing.Size(213, 215)
        Me.MTAListView.SmallImageList = Me.ImageList2
        Me.MTAListView.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.MTAListView.TabIndex = 6
        Me.MTAListView.UseCompatibleStateImageBehavior = False
        Me.MTAListView.View = System.Windows.Forms.View.Details
        '
        'IPAddressHeader
        '
        Me.IPAddressHeader.Text = "IP Address"
        Me.IPAddressHeader.Width = 87
        '
        'FQDNHeader
        '
        Me.FQDNHeader.Text = "FQDN"
        '
        'RecPortHeader
        '
        Me.RecPortHeader.Text = "Rec."
        Me.RecPortHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RecPortHeader.Width = 48
        '
        'DestPortHeader
        '
        Me.DestPortHeader.Text = "Dest."
        Me.DestPortHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.DestPortHeader.Width = 48
        '
        'MTAConnectionsContextMenuStrip
        '
        Me.MTAConnectionsContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditMTAConnectionsContextMenuToolStripMenuItem, Me.DeleteMtaConnectionsContextMenuToolStripMenuItem, Me.ToolStripSeparator9, Me.ConnectMtaConnectionsContextMenuToolStripMenuItem})
        Me.MTAConnectionsContextMenuStrip.Name = "MTAConnectionsContextMenuStrip"
        Me.MTAConnectionsContextMenuStrip.Size = New System.Drawing.Size(115, 76)
        '
        'EditMTAConnectionsContextMenuToolStripMenuItem
        '
        Me.EditMTAConnectionsContextMenuToolStripMenuItem.Name = "EditMTAConnectionsContextMenuToolStripMenuItem"
        Me.EditMTAConnectionsContextMenuToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.EditMTAConnectionsContextMenuToolStripMenuItem.Text = "Edit"
        '
        'DeleteMtaConnectionsContextMenuToolStripMenuItem
        '
        Me.DeleteMtaConnectionsContextMenuToolStripMenuItem.Image = CType(resources.GetObject("DeleteMtaConnectionsContextMenuToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteMtaConnectionsContextMenuToolStripMenuItem.Name = "DeleteMtaConnectionsContextMenuToolStripMenuItem"
        Me.DeleteMtaConnectionsContextMenuToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.DeleteMtaConnectionsContextMenuToolStripMenuItem.Text = "Delete"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(111, 6)
        '
        'ConnectMtaConnectionsContextMenuToolStripMenuItem
        '
        Me.ConnectMtaConnectionsContextMenuToolStripMenuItem.Name = "ConnectMtaConnectionsContextMenuToolStripMenuItem"
        Me.ConnectMtaConnectionsContextMenuToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.ConnectMtaConnectionsContextMenuToolStripMenuItem.Text = "Connect"
        '
        'MTAConnectionsTopPanel
        '
        Me.MTAConnectionsTopPanel.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MTAConnectionsTopPanel.Controls.Add(Me.MTAConnectionsLabel)
        Me.MTAConnectionsTopPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.MTAConnectionsTopPanel.Location = New System.Drawing.Point(1, 1)
        Me.MTAConnectionsTopPanel.Name = "MTAConnectionsTopPanel"
        Me.MTAConnectionsTopPanel.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.MTAConnectionsTopPanel.Size = New System.Drawing.Size(213, 24)
        Me.MTAConnectionsTopPanel.TabIndex = 0
        '
        'MTAConnectionsLabel
        '
        Me.MTAConnectionsLabel.BackColor = System.Drawing.SystemColors.Control
        Me.MTAConnectionsLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MTAConnectionsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MTAConnectionsLabel.Location = New System.Drawing.Point(0, 0)
        Me.MTAConnectionsLabel.Margin = New System.Windows.Forms.Padding(3)
        Me.MTAConnectionsLabel.Name = "MTAConnectionsLabel"
        Me.MTAConnectionsLabel.Size = New System.Drawing.Size(213, 23)
        Me.MTAConnectionsLabel.TabIndex = 4
        Me.MTAConnectionsLabel.Text = "MTA Connections"
        Me.MTAConnectionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MessageFileCenterPanel
        '
        Me.MessageFileCenterPanel.Controls.Add(Me.MessageFileTreeCenterPanel)
        Me.MessageFileCenterPanel.Controls.Add(Me.MessageFileTreeTopPanel)
        Me.MessageFileCenterPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MessageFileCenterPanel.Location = New System.Drawing.Point(1, 1)
        Me.MessageFileCenterPanel.Name = "MessageFileCenterPanel"
        Me.MessageFileCenterPanel.Size = New System.Drawing.Size(213, 320)
        Me.MessageFileCenterPanel.TabIndex = 1
        '
        'MessageFileTreeCenterPanel
        '
        Me.MessageFileTreeCenterPanel.BackColor = System.Drawing.SystemColors.Control
        Me.MessageFileTreeCenterPanel.Controls.Add(Me.MessageFileTreeView)
        Me.MessageFileTreeCenterPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MessageFileTreeCenterPanel.Location = New System.Drawing.Point(0, 25)
        Me.MessageFileTreeCenterPanel.Name = "MessageFileTreeCenterPanel"
        Me.MessageFileTreeCenterPanel.Size = New System.Drawing.Size(213, 295)
        Me.MessageFileTreeCenterPanel.TabIndex = 25
        '
        'MessageFileTreeView
        '
        Me.MessageFileTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MessageFileTreeView.ContextMenuStrip = Me.MessageFileTreeContextMenuStrip
        Me.MessageFileTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MessageFileTreeView.ImageIndex = 0
        Me.MessageFileTreeView.ImageList = Me.ImageList2
        Me.MessageFileTreeView.LabelEdit = True
        Me.MessageFileTreeView.Location = New System.Drawing.Point(0, 0)
        Me.MessageFileTreeView.Name = "MessageFileTreeView"
        Me.MessageFileTreeView.SelectedImageIndex = 0
        Me.MessageFileTreeView.Size = New System.Drawing.Size(213, 295)
        Me.MessageFileTreeView.Sorted = True
        Me.MessageFileTreeView.TabIndex = 1
        '
        'MessageFileTreeContextMenuStrip
        '
        Me.MessageFileTreeContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenFileMessageFileTreeContextMenuToolStripMenuItem, Me.ToolStripSeparator10, Me.RefreshMessageFileTreeViewContextMenuToolStripMenuItem, Me.ToolStripSeparator11, Me.ExpandMessageFileTreeContextMenuToolStripMenuItem, Me.ExpandAllMessageFileTreeContextMenuToolStripMenuItem, Me.ToolStripSeparator12, Me.AddFolderMessageFileTreeViewContextMenuToolStripMenuItem, Me.DeleteMessageFileTreeContextMenuToolStripMenuItem})
        Me.MessageFileTreeContextMenuStrip.Name = "MessageFileTreeContextMenuStrip"
        Me.MessageFileTreeContextMenuStrip.Size = New System.Drawing.Size(153, 176)
        '
        'OpenFileMessageFileTreeContextMenuToolStripMenuItem
        '
        Me.OpenFileMessageFileTreeContextMenuToolStripMenuItem.Image = CType(resources.GetObject("OpenFileMessageFileTreeContextMenuToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenFileMessageFileTreeContextMenuToolStripMenuItem.Name = "OpenFileMessageFileTreeContextMenuToolStripMenuItem"
        Me.OpenFileMessageFileTreeContextMenuToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.OpenFileMessageFileTreeContextMenuToolStripMenuItem.Text = "Open File"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(149, 6)
        '
        'RefreshMessageFileTreeViewContextMenuToolStripMenuItem
        '
        Me.RefreshMessageFileTreeViewContextMenuToolStripMenuItem.Name = "RefreshMessageFileTreeViewContextMenuToolStripMenuItem"
        Me.RefreshMessageFileTreeViewContextMenuToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RefreshMessageFileTreeViewContextMenuToolStripMenuItem.Text = "Refresh"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(149, 6)
        '
        'AddFolderMessageFileTreeViewContextMenuToolStripMenuItem
        '
        Me.AddFolderMessageFileTreeViewContextMenuToolStripMenuItem.Name = "AddFolderMessageFileTreeViewContextMenuToolStripMenuItem"
        Me.AddFolderMessageFileTreeViewContextMenuToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AddFolderMessageFileTreeViewContextMenuToolStripMenuItem.Text = "Add Folder"
        '
        'DeleteMessageFileTreeContextMenuToolStripMenuItem
        '
        Me.DeleteMessageFileTreeContextMenuToolStripMenuItem.Image = CType(resources.GetObject("DeleteMessageFileTreeContextMenuToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteMessageFileTreeContextMenuToolStripMenuItem.Name = "DeleteMessageFileTreeContextMenuToolStripMenuItem"
        Me.DeleteMessageFileTreeContextMenuToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteMessageFileTreeContextMenuToolStripMenuItem.Text = "Delete"
        '
        'MessageFileTreeTopPanel
        '
        Me.MessageFileTreeTopPanel.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MessageFileTreeTopPanel.Controls.Add(Me.MessageFileTreeLabel)
        Me.MessageFileTreeTopPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.MessageFileTreeTopPanel.Location = New System.Drawing.Point(0, 0)
        Me.MessageFileTreeTopPanel.Name = "MessageFileTreeTopPanel"
        Me.MessageFileTreeTopPanel.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.MessageFileTreeTopPanel.Size = New System.Drawing.Size(213, 25)
        Me.MessageFileTreeTopPanel.TabIndex = 0
        '
        'MessageFileTreeLabel
        '
        Me.MessageFileTreeLabel.BackColor = System.Drawing.SystemColors.Control
        Me.MessageFileTreeLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MessageFileTreeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MessageFileTreeLabel.Location = New System.Drawing.Point(0, 0)
        Me.MessageFileTreeLabel.Name = "MessageFileTreeLabel"
        Me.MessageFileTreeLabel.Size = New System.Drawing.Size(213, 24)
        Me.MessageFileTreeLabel.TabIndex = 5
        Me.MessageFileTreeLabel.Text = "Available Message Files"
        Me.MessageFileTreeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Left
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 74)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.MTAControlsPanel)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.MessageConsolePanel)
        Me.SplitContainer2.Size = New System.Drawing.Size(452, 570)
        Me.SplitContainer2.SplitterDistance = 215
        Me.SplitContainer2.SplitterWidth = 3
        Me.SplitContainer2.TabIndex = 53
        '
        'MessageConsolePanel
        '
        Me.MessageConsolePanel.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MessageConsolePanel.Controls.Add(Me.MessageConsole)
        Me.MessageConsolePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MessageConsolePanel.Location = New System.Drawing.Point(0, 0)
        Me.MessageConsolePanel.Name = "MessageConsolePanel"
        Me.MessageConsolePanel.Padding = New System.Windows.Forms.Padding(1)
        Me.MessageConsolePanel.Size = New System.Drawing.Size(234, 570)
        Me.MessageConsolePanel.TabIndex = 0
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 644)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1})
        Me.StatusBar1.Size = New System.Drawing.Size(782, 22)
        Me.StatusBar1.TabIndex = 10
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(452, 74)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 570)
        Me.Splitter1.TabIndex = 54
        Me.Splitter1.TabStop = False
        '
        'ExpandMessageFileTreeContextMenuToolStripMenuItem
        '
        Me.ExpandMessageFileTreeContextMenuToolStripMenuItem.Name = "ExpandMessageFileTreeContextMenuToolStripMenuItem"
        Me.ExpandMessageFileTreeContextMenuToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExpandMessageFileTreeContextMenuToolStripMenuItem.Text = "Expand"
        '
        'ExpandAllMessageFileTreeContextMenuToolStripMenuItem
        '
        Me.ExpandAllMessageFileTreeContextMenuToolStripMenuItem.Name = "ExpandAllMessageFileTreeContextMenuToolStripMenuItem"
        Me.ExpandAllMessageFileTreeContextMenuToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExpandAllMessageFileTreeContextMenuToolStripMenuItem.Text = "ExpandAll"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(149, 6)
        '
        'MainDialog
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(782, 666)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ButtonToolStrip)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.MinimumSize = New System.Drawing.Size(600, 700)
        Me.Name = "MainDialog"
        Me.Text = "NCS Message Injector"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ButtonToolStrip.ResumeLayout(False)
        Me.ButtonToolStrip.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MTAControlsPanel.ResumeLayout(False)
        Me.MTAControlsSplitContainer.Panel1.ResumeLayout(False)
        Me.MTAControlsSplitContainer.Panel2.ResumeLayout(False)
        Me.MTAControlsSplitContainer.ResumeLayout(False)
        Me.MTAConnectionsBottomPanel.ResumeLayout(False)
        Me.MTAConnectionsBottomPanel.PerformLayout()
        Me.MTAConnectionsToolStrip.ResumeLayout(False)
        Me.MTAConnectionsToolStrip.PerformLayout()
        Me.MTAConnectionsCenterPanel.ResumeLayout(False)
        Me.MTAConnectionsContextMenuStrip.ResumeLayout(False)
        Me.MTAConnectionsTopPanel.ResumeLayout(False)
        Me.MessageFileCenterPanel.ResumeLayout(False)
        Me.MessageFileTreeCenterPanel.ResumeLayout(False)
        Me.MessageFileTreeContextMenuStrip.ResumeLayout(False)
        Me.MessageFileTreeTopPanel.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.MessageConsolePanel.ResumeLayout(False)
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Declare Function InitCommonControls Lib "Comctl32.dll" () As Long


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim mta_file_number As Integer
        Dim mta_file_buffer_len As Integer
        Dim networkFileExists As Boolean = True


        InitCommonControls()

        Me.MessageFileTreeView.TreeViewNodeSorter = New NodeSorter()

        Randomize() ' Initialize random-number generator.
        TransId = CInt(Int((200 * Rnd()) + 1)) ' Generate random value between 1 and 200.

        '''''''''''''''' Set up Tool Tips ''''''''''''''''''''''
        Dim CurrentMTAToolTip As New ToolTip()
        'CurrentMTAToolTip.SetToolTip(MeMTALabel, "The Current MTA to send messages to.")
        Dim CurrentFQDNToolTip As New ToolTip()
        'CurrentFQDNToolTip.SetToolTip(Me.FQDNLabel, "The FQDN of the current MTA")
        Dim LineNumberToolTip As New ToolTip()
        'LineNumberToolTip.SetToolTip(Me.LineNumberComboBox, "Select line number to insert into current FQDN. " + vbCrLf + _
        '               "Used with the 'fqdn' keyword in a message file.")
        Dim CurrentMessageToolTip As New ToolTip()
        'CurrentMessageToolTip.SetToolTip(Me.MessageFileLabel, "The current message file to inject into the MTA.")
        Dim MTAListToolTip As New ToolTip()
        MTAListToolTip.SetToolTip(Me.MTAListView, "List of MTAs to inject a message into." + vbCrLf + _
                        "Double Click to connect to the MTA." + vbCrLf + _
                        "Right Click to Edit or Delete MTA.")

        'set buttons to state of no files open
        SetEmptyMDIButtons()

        'read in size of frame, if it is set
        Me.ReadMainFormSize()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '                   Get All MTAs Information                  '
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'see if MTA List File, aka "network.txt"
        Try

            Dim mta_file As New FileInfo(MTA_LIST_FILE)
            If Not mta_file.Exists Then
                networkFileExists = False
            End If
            mta_file_number = FreeFile()
            mta_file_buffer_len = mta_file.Length
            FileOpen(mta_file_number, MTA_LIST_FILE, OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.Default, mta_file_buffer_len)
        Catch ex As Exception

        End Try

        If (networkFileExists) Then
            Try

                Dim line As String
                Dim token As String
                Dim ipAddress As String = ""
                Dim fqdn As String = ""
                Dim recPort As String = ""
                Dim destPort As String = ""
                Dim i As Integer
                Dim j As Integer = 0
                Do Until EOF(mta_file_number) 'read in lines from file
                    line = LineInput(mta_file_number)

                    i = 0

                    'read in ip address
                    ipAddress = Me.ParseToken(line, i, ":")
                    'read in fqdn
                    fqdn = ParseToken(line, i, ":")

                    'read in receive port
                    recPort = ParseToken(line, i, ":")

                    'read in destination port
                    destPort = ParseToken(line, i, ":")

                    Dim item As New ListViewItem(ipAddress)
                    item.ImageIndex = 3
                    ' MTAListView.Items.Add(ipAddress)
                    item.SubItems.Add(fqdn)
                    item.SubItems.Add(recPort)
                    item.SubItems.Add(destPort)
                    MTAListView.Items.Add(item)
                    '  MTAListView.Items(j).SubItems.Add(fqdn)
                    ' MTAListView.Items(j).SubItems.Add(recPort)
                    'MTAListView.Items(j).SubItems.Add(destPort)
                    j += 1

                    'clear strings
                    ipAddress = ""
                    fqdn = ""
                    recPort = ""
                    destPort = ""

                Loop


            Catch ex1 As Exception
                MsgBox("Error reading " & MTA_LIST_FILE)
            End Try

            Try
                FileClose(mta_file_number)
            Catch ex2 As Exception
            End Try

        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '           Open all message forms from last session                '
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'open window list
        Dim windowInfo As New FileInfo(WINDOW_LIST_FILE)

        If (windowInfo.Exists) Then
            Dim windowFileNumber As Integer = FreeFile()
            'Try

            Dim file As String
            Dim line As String
            Dim width As String
            Dim height As String
            Dim xPos As String
            Dim yPos As String
            Dim i As Integer
            FileOpen(windowFileNumber, WINDOW_LIST_FILE, OpenMode.Binary, OpenAccess.Read, OpenShare.LockRead)

            Do Until EOF(windowFileNumber) 'read in lines from file
                line = LineInput(windowFileNumber)
                i = 0

                'read in file
                file = Me.ParseToken(line, i, ",")
                'read in width
                width = ParseToken(line, i, ",")
                'read in height
                height = ParseToken(line, i, ",")
                'read in x Postition
                xPos = ParseToken(line, i, ",")
                'read in y Posistion
                yPos = ParseToken(line, i, ",")

                Try
                    Dim fileInfo As New FileInfo(file)
                    If (fileInfo.Exists) Then
                        Dim messageForm As New MessageForm(Me, file)
                        Dim fileStream As New FileStream(file, FileMode.Open)
                        messageForm.RichTextBox.LoadFile(fileStream, RichTextBoxStreamType.PlainText)
                        messageForm.ColorCodeText()
                        messageForm.MdiParent = Me
                        messageForm.Show()
                        messageForm.Size = New System.Drawing.Size(width, height)
                        messageForm.Location = New System.Drawing.Point(xPos, yPos)
                        fileStream.Close()

                        Me.SetNonEmptyMDIButtons()


                    End If
                Catch
                End Try
            Loop

            FileClose(windowFileNumber)
            'Catch
            'make sure to close file if problem occured
            'FileClose(windowFileNumber)

            'End Try
        End If

        'read all injector files into the tree
        UpdateMessageFileTree()

        Me.MessageConsole.Text = "Message Console. " & vbCrLf & _
                                 "Send and Receive Message Appear Here." & vbCrLf

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '             Set up any default controls                   '
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        DeleteMTAToolStripButton.Enabled = False
        'Set default line number to 1
        LineNumberComboBox.SelectedIndex = 0
        'AddHandler WindowMenu.Popup, AddressOf WindowMenu_Popup


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '             Get Local Machine's Ip Address                '
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim strMachineName As String

        'Get the Host Name
        strMachineName = Dns.GetHostName()

        'Get the Host by Name
        Dim ipHost As IPHostEntry
        ipHost = Dns.GetHostByName(strMachineName)

        'Get the list of addresses associated with the host in an array
        Dim ipAddr() As IPAddress = ipHost.AddressList

        If (ipAddr.Length = 1) Then
            LocalIpAddress = ipAddr(0)
        Else

            'select from a list of local ip addresses
            Dim ipSelectDialog As New IPSelect()
            Dim i As Integer

            For i = 0 To ipAddr.Length - 1
                ipSelectDialog.IPListBox.Items.Add(ipAddr(i).ToString)
            Next

            ipSelectDialog.StartPosition = FormStartPosition.CenterScreen
            If (ipSelectDialog.ShowDialog() = DialogResult.OK) Then
                Dim ipStr As String = ipSelectDialog.IPListBox.SelectedItem.ToString

                LocalIpAddress = System.Net.IPAddress.Parse(ipStr)
            End If
        End If

        ' LocalIpAddress = ipAddr(0)
        MessageConsole.AppendText("Local Machine: " + LocalIpAddress.ToString + vbCrLf)

        'Set LineAckArray to all Enable
        Dim k As Integer = 0
        For k = 0 To 12
            LineACKStatus(k) = 1
        Next


    End Sub


    Public Function ParseToken(ByRef line As String, ByRef i As Integer, ByVal delim As String)

        Dim token As String
        Dim ch As String

        ch = line.Substring(i, 1)
        Do While (ch.CompareTo(delim))
            token += ch
            i += 1
            ch = line.Substring(i, 1)
        Loop

        i += 1
        Return token

    End Function

    <System.Runtime.InteropServices.DllImport("shell32.dll")> Shared Function _
   FindExecutable(ByVal fileName As String, ByVal fileDir As String, _
   ByVal buffer As System.Text.StringBuilder) As Integer
    End Function

    ' Returns the name and path of the EXEcutable file that is associated to the 
    ' specified file.
    ' Returns an empty string if there is no such associated file,
    ' and raises an error if the file or the path hasn't been found.
    ' 
    ' Example: Debug.WriteLine(GetExecutableFile("D:\temp\Db.mdb"))

    Public Function GetExecutableFile(ByVal filePath As String) As String
        Const ERROR_FILE_NO_ASSOCIATION = 31&
        Const ERROR_FILE_NOT_FOUND = 2&
        Const ERROR_PATH_NOT_FOUND = 3&
        Const ERROR_FILE_SUCCESS = 32&
        Dim buffer As New System.Text.StringBuilder(260)

        ' call the FindExecutable API function and process the return value
        Select Case FindExecutable(System.IO.Path.GetFileName(filePath), _
            System.IO.Path.GetDirectoryName(filePath), buffer)
            Case ERROR_FILE_NOT_FOUND, ERROR_PATH_NOT_FOUND
                Throw New System.IO.FileNotFoundException()
            Case ERROR_FILE_NO_ASSOCIATION
                Return ""
            Case Is >= ERROR_FILE_SUCCESS
                ' extract the ANSI string that contains the name of the associated 
                ' executable file
                Return buffer.ToString()
        End Select
    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' ConnectToMTA()                                         '
    ' Binds to a socket to the local machine to listen for   '
    ' incomming MGCP messages. It will then start up the     '
    ' receiver Thread.                                       '
    ' Input:  None                                           '
    ' Output: None                                           '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Sub ConnectToMTA()
        If (DeletingMTA <> True And MTAListView.SelectedIndices.Count <> 0) Then

            currentMTAIp = Trim(MTAListView.SelectedItems(0).Text)
            currentFQDN = Trim(MTAListView.SelectedItems(0).SubItems(1).Text)
            currentDestPort = Trim(MTAListView.SelectedItems(0).SubItems(3).Text)

            'first check if need to change the receiving port
            If (MTAListView.SelectedItems(0).SubItems(2).Text <> currentRecPort) Then

                'Receive port is different, kill tread receive thread if it is running
                If (receiveThread.IsAlive) Then
                    MessageConsole.AppendText("Change in receiving port, reseting receiving thread..")
                    MessageConsole.AppendText(vbCrLf)
                    Try
                        receiveThread.Abort()
                    Catch ex As Exception
                        MessageConsole.AppendText("Error!! Could not kill receive Thread!")
                        MessageConsole.AppendText(vbCrLf)
                    End Try

                End If

                'change current MGCP Receiving port
                currentRecPort = Trim(MTAListView.SelectedItems(0).SubItems(2).Text)

                'open MGCP receiver socket
                Try

                    Dim iRecPort As Integer

                    'get ip and port of local machine
                    iRecPort = System.Int16.Parse(currentRecPort)
                    Dim receiveIp As New IPEndPoint(LocalIpAddress, iRecPort)

                    ' If (mgcpSocket.IsBound()) Then
                    'MsgBox("---is bound, this connecting")
                    '   mgcpSocket As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
                    'End If
                    mgcpSocket.Bind(receiveIp)


                    'Me.BindToReceiverPortToolStripMenuItem.Enabled = True
                    'mainform.ReceivePortCheckBox.Checked = True

                Catch ex As Exception
                    MsgBox("Error Binding to Local Ip " & LocalIpAddress.ToString + ":" & currentRecPort & vbCrLf & ex.ToString)
                End Try

                'start up Thread to listen for incomming messages
                Try
                    receiveThread.Start()
                Catch ex As Exception
                    MsgBox("Error starting receiving Thread. " & vbCrLf & ex.ToString)
                End Try

            End If

            MTALabel.Text = currentMTAIp
            FQDNLabel.Text = currentFQDN

        Else
            MTALabel.Text = String.Empty
            FQDNLabel.Text = String.Empty
        End If

        'reset DeletingMTA flag
        DeletingMTA = False
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' SendMessage()                                             '
    ' Sends a message out to the MTA.                           '
    ' Input:  message to send as string.                        '
    ' Output: None                                              '
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Sub SendMessage(ByVal message As String)

        'convert port from string to integer
        Dim iPort As Integer = System.Int32.Parse(currentDestPort)

        Dim sendIp As New IPEndPoint(System.Net.IPAddress.Parse(currentMTAIp), iPort)

        Dim sendBytes As Byte() = Encoding.ASCII.GetBytes(message)

        'display outgoing message on console
        DisplayConsoleMessage(ConsoleMessageType.SendMessage, message)
        mgcpSocket.SendTo(sendBytes, sendIp)
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' ReceiveMsg()                                             '
    ' Thread run when connected to MTA, to listen for incoming '
    ' messages on a given port. When a message is received, it '
    ' is processed and responded to if need be.                '
    ' Input:  None                                             '
    ' Output: None                                             '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Sub ReceiveMsg()

        Dim ReceiveBytes(1024) As Byte
        Dim iRecPort As Integer

        'get ip and port of local machine
        iRecPort = System.Int16.Parse(currentRecPort)
        Dim receiveIp As New IPEndPoint(LocalIpAddress, iRecPort)

        MessageConsole.AppendText("Listening for MGCP message on port " & currentRecPort)
        MessageConsole.AppendText(vbCrLf)
        MessageConsole.AppendText("Is there anybody out there?")
        MessageConsole.AppendText(vbCrLf)

        'Connected start loop
        While (True)
            Dim strRec As String

            Try
                'blocks and waits for input
                mgcpSocket.ReceiveFrom(ReceiveBytes, receiveIp)

                strRec = Encoding.ASCII.GetString(ReceiveBytes)
                DisplayConsoleMessage(ConsoleMessageType.ReceiveMessage, strRec)

                'clear out buffer
                ReceiveBytes.Clear(ReceiveBytes, 0, ReceiveBytes.Length)

                'first need to check for piggybacked message
                If (InStr(strRec, PIGGYBACK_DELIMITER)) Then

                    'found piggyback message, split apart
                    Try
                        Dim piggybackMessage() As String = Split(strRec, PIGGYBACK_DELIMITER)

                        ProcessMessage(piggybackMessage(0))
                        ProcessMessage(piggybackMessage(1))
                    Catch ex As Exception
                        MessageConsole.AppendText("Error with piggyback message: " & vbCrLf)
                        MessageConsole.AppendText(strRec)
                    End Try

                Else
                    ProcessMessage(strRec)
                End If

                'now check for sdp, caputure it
                Dim SDPArray() = Split(strRec, SDP_DELIMITER)


                If (SDPArray.Length > 1) Then
                    CurrentSDP = SDPArray(1)
                    CurrentSDP = "v=0" + CurrentSDP
                End If


            Catch ex As Exception
                'MsgBox("Error receiving from socket" + vbCrLf + ex.Message)
            End Try
        End While



    End Sub


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' ProcessMessage()                                      '
    ' Examines the messages and responds to the MTA.        '
    ' Input:  Message from MTA.                             '
    ' Output: None                                          '
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Sub ProcessMessage(ByVal strRec As String)
        'remove any blank lines
        Dim i As Integer
        Dim j As Integer = 0
        Dim lineCollection As New Collection()

        ''''''''''''''''''''''''''''''''''''''''''''''''
        '               Parse Message                  '
        ''''''''''''''''''''''''''''''''''''''''''''''''

        'first break up line by line
        Dim tempLineArray() As String = Split(strRec, ControlChars.Lf)
        For i = 0 To tempLineArray.Length - 1

            If (tempLineArray(i) <> String.Empty) Then
                lineCollection.Add(tempLineArray(i))
            End If
        Next


        'If ACK Messages is Enabled
        'If (mainform.EnableACKMenuItem.Checked = True) Then
        'Dim ackMes = AckMessage(lineCollection)
        AckMessage(lineCollection)
        'If (ackMes <> NON_SGCP_MESSAGE) Then
        'SendMessage(ackMes)
        'End If
        'End If
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' AckMessage()                                               '
    ' Puts together an ACK message if the incomming message needs'
    ' an ACK.                                                    '
    ' Input:  Incomming string message.                          '
    ' Output: ACK message, or NON_SGCP_MESSAGE flag.             '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Sub AckMessage(ByVal Message As Collection)

        'split message up by white space
        Dim line1Array() As String = Split(Message.Item(1))
        Dim ackMsg As String = ""

        If (line1Array.Length >= 2) Then
            Dim type As String = UCase(line1Array(0))
            Dim transId As String = line1Array(1)

            If (type = "NTFY" Or type = "RQNT" Or type = "CRCX" Or _
                type = "MDCX" Or type = "AUEP" Or type = "AUCX" Or type = "RSIP") Then
                ackMsg = "200 " & transId & vbCrLf
            ElseIf (type = "DLCX") Then
                ackMsg = "250 " & transId & vbCrLf

                'check for provisional response
            ElseIf (type = RECV_PROVISIONAL_RESPONSE) Then
                WaitForProvResAck = True

                'check for special message of this form
                '200 xxx
                '...
                'k:
                '...
            ElseIf (type = "200") Then
                'now search for empty k parameter 
                Dim i As Integer
                Dim j As Integer
                Dim emptyK As Boolean = True
                For i = 2 To Message.Count
                    Dim lineNextArray() As String = Split(Message.Item(i))
                    If (LCase(lineNextArray(0)) = "k:") Then

                        'check all of the line with k: to see if it is empty
                        For j = 1 To lineNextArray.Length - 1

                            'skip white space, empty strings or newlines
                            If (lineNextArray(j) <> " " And lineNextArray(j) <> String.Empty And _
                               lineNextArray(j) <> ControlChars.Lf) Then
                                emptyK = False
                            End If
                        Next

                        'if no extra prameter were found retun special 000 ...
                        If (emptyK) Then
                            ackMsg = "000 " & transId & vbCrLf
                        End If
                    End If
                Next

            End If

            ProcessACKMessage(Message.Item(1), ackMsg)
        End If


    End Sub
    Public Sub ProcessACKMessage(ByVal msgHeader As String, ByVal ackMsg As String)

        Dim intLine As Integer

        If (ackMsg <> "") Then
            Try
                Dim temp1() As String = Split(msgHeader, "@")
                Dim temp2 As String = temp1(0)

                Dim lineNumber As Char = temp2(temp2.Length - 1)

                If (lineNumber = "*") Then

                    Dim i As Integer
                    For i = 0 To 12
                        If (LineACKStatus(i)) Then
                            SendMessage(ackMsg)
                            Return
                        End If
                    Next
                Else
                    intLine = Integer.Parse(lineNumber)

                    If (LineACKStatus(intLine)) Then
                        SendMessage(ackMsg)
                    End If
                End If

            Catch ex As Exception
            End Try
        End If
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' ReadFromFile()                                          '
    ' Used to read in an NCS message from a file, and respond '
    ' to a incomming message.                                 '
    ' Input:  String filename                                 '
    ' Output: Returns the NCS message in the file as a string '
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Function ReadFromFile(ByVal fileName As String) As String

        Dim returnStr As String
        Dim file_number As Integer

        ChDir(NCSMessageInjectorDir)
        Try

            Dim file As New FileInfo(fileName)
            If Not file.Exists Then
                MsgBox("Could not open file " & fileName)
                Exit Function

            End If
            file_number = FreeFile()

            FileOpen(file_number, MTA_LIST_FILE, OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.Default, file.Length)

            Do Until EOF(file_number) 'read in lines from file
                returnStr = returnStr + LineInput(file_number)
            Loop

            FileClose(file_number)
        Catch ex As Exception
            MsgBox("Error is opening message response file " & fileName, MsgBoxStyle.Exclamation)
        End Try


        Return returnStr
    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' UpdateMessageFileTree()                                          '
    ' Adds in all the injector files from the messages directory and   '
    ' puts them into the MessageFileTree.                              '
    ' Input:  None                                                     '
    ' Output: None                                                     '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub UpdateMessageFileTree()

        ChDir(NCSMessageInjectorDir)

        Try
            Me.MessageFileTreeView.BeginUpdate()
            MessageFileTreeView.Nodes.Clear()

            Dim rootFolder As New DirectoryInfo("messages")

            Dim msgNode As TreeNode = AddNodeAndDescendents(rootFolder)
            msgNode.ImageIndex = 1
            msgNode.SelectedImageIndex = 1

            'get .inj files and put them in the tree
            Dim messageFile = Dir("messages/*.*")
            Do While messageFile <> ""   ' Start the loop.

                Dim filePath As String = rootFolder.FullName & "\" & messageFile
                Dim fileNode As New TreeNode(messageFile)
                fileNode.Tag = filePath
                msgNode.Nodes.Add(fileNode)
                messageFile = Dir()   ' Get next entry.
            Loop


            msgNode.Expand()
            Me.MessageFileTreeView.Nodes.Add(msgNode)
            Me.MessageFileTreeView.SelectedNode = Me.MessageFileTreeView.Nodes(0)

            Me.MessageFileTreeView.EndUpdate()
        Catch
        End Try



    End Sub

    Private Function AddNodeAndDescendents(ByVal folder As DirectoryInfo) As TreeNode

        Dim node As New TreeNode(folder.Name)


        'Recurse through this folder's subfolders
        Dim subFolders As DirectoryInfo() = folder.GetDirectories()
        For Each subFolder As DirectoryInfo In subFolders
            Dim child As TreeNode = AddNodeAndDescendents(subFolder)
            child.ImageIndex = 1
            child.SelectedImageIndex = 1
            node.Nodes.Add(child)

            'get .inj files and put them in the tree
            Dim dirPath As String = subFolder.FullName & "/*.*"
            Dim messageFile = Dir(dirPath)

            Do While messageFile <> ""
                Dim filePath As String = subFolder.FullName & "\" & messageFile
                Dim fileNode As New TreeNode(messageFile)
                fileNode.Tag = filePath
                child.Nodes.Add(fileNode)
                messageFile = Dir()   ' Get next entry.
            Loop
        Next



        Return node     'Return the new TreeNode


    End Function




    Private Sub NewMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub OpenMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        OpenMessageFile()
    End Sub

    Private Sub CloseMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Dim result As MsgBoxResult

        If (activeChild.NeedSave) Then
            result = SavePrompt()
        End If

        If (result <> MsgBoxResult.Cancel) Then
            CType(Me.ActiveMdiChild, MessageForm).Dispose()
        End If
    End Sub

    Private Sub SaveMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click, SaveToolStripButton.Click
        SaveMessageFile()
    End Sub

    Private Sub SaveAsMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveAsMessageFile()
    End Sub

    Private Sub PrintMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click, PrintToolStripButton.Click
        PrintMessageFile()
    End Sub

    Private Sub PrintPreviewMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click, PrintPreviewToolStripButton.Click
        PrintPreviewMessageFile()
    End Sub

    Private Sub ExitMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        'this will call MainDialog_Closing procedure since it listens to the closing
        'event
        MyBase.Close()
    End Sub

    Private Sub CutMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click, CutToolStripButton.Click

        If (CType(Me.ActiveMdiChild, MessageForm).RichTextBox.SelectedText <> String.Empty) Then
            CType(Me.ActiveMdiChild, MessageForm).RichTextBox.Cut()
        Else
            MessageConsole.Cut()
        End If
    End Sub

    Private Sub CopyMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click, CopyToolStripButton.Click

        If (CType(Me.ActiveMdiChild, MessageForm).RichTextBox.SelectedText <> String.Empty) Then

            CType(Me.ActiveMdiChild, MessageForm).RichTextBox.Copy()
        Else
            MessageConsole.Copy()
        End If
    End Sub

    Private Sub PasteMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click, PasteToolStripButton.Click
        CType(Me.ActiveMdiChild, MessageForm).Paste()
        CType(Me.ActiveMdiChild, MessageForm).RichTextBox.ForeColor = Color.DarkBlue

    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' MessageConsoleMenuItem_Click()                               '
    ' Called when the Message Console Menu Item is slelected.      '
    ' Will enable or disable the Message Console.                  '
    ' Input:  Events...                                            '
    ' Output: None                                                 '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub MessageConsoleMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessageConsoleToolStripMenuItem.Click

        If (Me.MessageConsoleToolStripMenuItem.Checked = True) Then
            MessageConsoleToolStripMenuItem.Checked = False
            'MessageConsoleSplitter.Visible = False

            MessageConsole.Visible = False
        Else
            MessageConsoleToolStripMenuItem.Checked = True
            'MessageConsoleSplitter.Visible = True

            MessageConsole.Visible = True
        End If


    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' EnableACKMenuItem_Click()                                   '
    ' Turns on or off whether or not ACK messages will be sent out'
    ' Input:  Events...                                           '
    ' Output: None                                                '
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub EnableACKMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Toggle Enable ACK Messages
        'If (EnableACKMenuItem.Checked = True) Then
        ' EnableACKMenuItem.Checked = False
        ' Else
        ' EnableACKMenuItem.Checked = True
        'End If
        Dim enableACK As New EnableACK()
        enableACK.StartPosition = FormStartPosition.CenterParent
        enableACK.ShowDialog()

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' BlackOnWhiteMenuItem_Click()                                '
    ' Changes the colors of the Console Window to black lettering '
    ' and white background.                                       '
    ' Input:  Events...                                           '
    ' Output: None                                                '
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub BlackOnWhiteMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlackOnWhiteToolStripMenuItem.Click
        BlackOnWhiteConsole()
    End Sub

    Private Sub BlackOnWhiteConsole()
        MessageConsole.BackColor = Color.White
        MessageConsole.ForeColor = Color.Black

        BlackOnWhiteToolStripMenuItem.Checked = True
        WhiteOnBlackToolStripMenuItem.Checked = False
        YellowOnBlueToolStripMenuItem.Checked = False
        OrangeOnBlueToolStripMenuItem.Checked = False
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' WhiteOnBlackMenuItem_Click()                                '
    ' Changes the colors of the Console Window to white lettering '
    ' and black background.                                       '
    ' Input:  Events...                                           '
    ' Output: None                                                '
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub WhiteOnBlackMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WhiteOnBlackToolStripMenuItem.Click
        WhiteOnBlackConsole()
    End Sub

    Private Sub WhiteOnBlackConsole()
        MessageConsole.BackColor = Color.Black
        MessageConsole.ForeColor = Color.White

        BlackOnWhiteToolStripMenuItem.Checked = False
        WhiteOnBlackToolStripMenuItem.Checked = True
        YellowOnBlueToolStripMenuItem.Checked = False
        OrangeOnBlueToolStripMenuItem.Checked = False
    End Sub
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' YellowOnBlueMenuItem_Click()                                '
    ' Changes the colors of the Console Window to yellow lettering '
    ' and blue background.                                       '
    ' Input:  Events...                                           '
    ' Output: None                                                '
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub YellowOnBlueMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YellowOnBlueToolStripMenuItem.Click
        YellowOnBlueConsole()
    End Sub

    Private Sub YellowOnBlueConsole()
        MessageConsole.BackColor = Color.DarkBlue
        MessageConsole.ForeColor = Color.Yellow

        BlackOnWhiteToolStripMenuItem.Checked = False
        WhiteOnBlackToolStripMenuItem.Checked = False
        YellowOnBlueToolStripMenuItem.Checked = True
        OrangeOnBlueToolStripMenuItem.Checked = False
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' OrangeOnBlueMenuItem_Click()                                '
    ' Changes the colors of the Console Window to orange lettering '
    ' and blue background.                                       '
    ' Input:  Events...                                           '
    ' Output: None                                                '
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub OrangeOnBlueMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeConsoleColorsToolStripMenuItem.Click, OrangeOnBlueToolStripMenuItem.Click
        OrangeOnBlueConsole()
    End Sub

    Private Sub OrangeOnBlueConsole()
        MessageConsole.BackColor = Color.DarkBlue
        MessageConsole.ForeColor = Color.Orange

        BlackOnWhiteToolStripMenuItem.Checked = False
        WhiteOnBlackToolStripMenuItem.Checked = False
        YellowOnBlueToolStripMenuItem.Checked = False
        OrangeOnBlueToolStripMenuItem.Checked = True
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' WindowMenu_Popup()                                           '
    ' Called when window menu is selected. Displays all open files '
    ' Input:  Events...                                            '
    ' Output: None                                                 '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub WindowMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Enable/disable child form-handling menu items.
        Dim blnEnable As Boolean = (Me.MdiChildren.Length > 0)
        CascadeToolStripMenuItem.Enabled = blnEnable
        TileHorizontallyToolStripMenuItem.Enabled = blnEnable
        TileVerticallyToolStripMenuItem.Enabled = blnEnable
    End Sub

    Private Sub CascadeMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticallyMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileVerticallyToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontallyMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileHorizontallyToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub AboutMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutNCSMessageInjectorToolStripMenuItem.Click
        Dim aboutDialog As New About()

        aboutDialog.StartPosition = FormStartPosition.CenterParent
        aboutDialog.ShowDialog()

    End Sub


    'Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs)
    '    Select Case ToolBar1.Buttons.IndexOf(e.Button)
    '        Case 0
    '            Dim newMessageDialog As New NewDialog()
    '            newMessageDialog.StartPosition = FormStartPosition.CenterParent
    '            newMessageDialog.ShowDialog(Me)
    '            newMessageDialog.Dispose()

    '        Case 1
    '            OpenMessageFile()
    '        Case 2
    '            SaveMessageFile()
    '        Case 3
    '            Separator
    '        Case 4
    '            PrintMessageFile()
    '        Case 5
    '            PrintPreviewMessageFile()
    '        Case 6
    '        Case 7
    '            CType(Me.ActiveMdiChild, MessageForm).RichTextBox.Cut()
    '        Case 8
    '            CType(Me.ActiveMdiChild, MessageForm).RichTextBox.Copy()
    '        Case 9
    '            CType(Me.ActiveMdiChild, MessageForm).RichTextBox.Paste()
    '    End Select

    'End Sub



    Private Sub AddMTAButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddMTAToolStripButton.Click

        Dim addMTA As New AddMTA(Me)
        addMTA.StartPosition = FormStartPosition.CenterParent
        addMTA.ShowDialog(Me)

    End Sub

    Private Sub DeleteMTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMTAToolStripButton.Click

        DeletingMTA = True
        Me.MTAListView.Items.Remove(MTAListView.SelectedItems(0))
        DeleteMTAToolStripButton.Enabled = False

    End Sub

    Private Sub InjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Try
            If (Me.MTALabel.Text = String.Empty And Me.MessageFileLabel.Text = String.Empty) Then
                MsgBox("Select an MTA from the MTA list and a Message File from the Message File List", MsgBoxStyle.Exclamation)
                Exit Sub
            ElseIf (Me.MTALabel.Text = String.Empty) Then
                MsgBox("Select an MTA from the MTA list", MsgBoxStyle.Exclamation)
                Exit Sub
            ElseIf (Me.MessageFileLabel.Text = String.Empty) Then
                MsgBox("Select a Message File from the Message File List", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            activeChild = Me.ActiveMdiChild
            Dim messageStr As String = activeChild.RichTextBox.Text

            messageStr = Replace(messageStr, Chr(10), NewLine)


            piggybackMessage = Split(messageStr, PIGGYBACK_DELIMITER)

            If (piggybackMessage.Length > 1) Then
                'start up deplayed message sending for piggyback messages
                If (OptionPiggyDelay = String.Empty Or OptionPiggyDelay = "0") Then
                    'if no delay, send entire message at once
                    InsertParameters(messageStr)
                    Exit Sub

                Else
                    If (IsNumeric(OptionPiggyDelay)) Then
                        Me.PiggyDelayTimer.Interval = OptionPiggyDelay
                    Else
                        MsgBox("Illegal Piggyback delay " + OptionPiggyDelay + NewLine + _
                        "Must be a number, in milliseconds.")
                        Exit Sub
                    End If
                End If
                'insert first message without delay
                InsertParameters(piggybackMessage(0))
                piggyCounter += 1
                Me.PiggyDelayTimer.Start()


            Else
                InsertParameters(messageStr)
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try





    End Sub


    Public Function InsertParameters(ByVal message As String) As String

        Dim messageArray() As String = Split(message, " ")
        Dim i As Integer
        If (messageArray.Length > 1) Then

            For i = 0 To messageArray.Length - 1
                If (LCase(messageArray(i) = KEY_TRANSID)) Then
                    'set xxxx to latest transId
                    messageArray(i) = TransId.ToString
                    TransId += 1

                ElseIf (LCase(messageArray(i) = KEY_FQDN)) Then
                    If (currentLineNumber <> String.Empty) Then
                        messageArray(i) = "aaln/" + currentLineNumber + "@" + Me.FQDNLabel.Text
                    Else
                        Me.PiggyDelayTimer.Stop()
                        MsgBox("To use the 'fqdn' keyword, and insert the current FQDN into the message, you must select a line number.", MsgBoxStyle.Exclamation)
                        Exit Function
                    End If
                End If
            Next i
        End If

        'now reconstruct the message with new transId and fqdn, put back in space
        Dim newMessage As String
        For i = 0 To messageArray.Length - 1
            newMessage += messageArray(i)
            newMessage += " "
        Next

        'now check for sdp
        messageArray.Clear(messageArray, 0, messageArray.Length)
        messageArray = Split(newMessage, NewLine)

        For i = 0 To messageArray.Length - 1
            ' MessageConsole.AppendText("part " + i.ToString)
            'MessageConsole.AppendText(messageArray(i))
            If (Trim(LCase(messageArray(i)) = KEY_SDP)) Then
                messageArray(i) = CurrentSDP
            End If
        Next i

        'reconstruct message with sdp, put back in newlines
        newMessage = String.Empty
        For i = 0 To messageArray.Length - 1
            newMessage += messageArray(i)
            newMessage += NewLine
        Next


        SendMessage(newMessage)

    End Function

    Public Sub DisplayConsoleMessage(ByVal type As Integer, ByVal message As String)


        '   Try
        Dim consoleMessage As String
        Select Case type
            Case ConsoleMessageType.OpenSocket
            Case ConsoleMessageType.ReceiveMessage
                Dim selectedText As String
                MessageConsole.SelectionColor = Color.Red
                consoleMessage = "Receiving NCS Message from " & currentMTAIp & vbCrLf
                consoleMessage += "---------------------------------------------------" & vbCrLf
                MessageConsole.SelectedText = consoleMessage

                'add message to Console
                MessageConsole.AppendText(message + vbCrLf + vbCrLf)


                'see if should log message
                'If (Me.LogConsoleToolStripMenuItem.Checked = True) Then
                '    FilePut(LogFileNumber, consoleMessage + message + vbCrLf)
                'End If
                MessageConsole.Focus()
                MessageConsole.ScrollToCaret()

            Case ConsoleMessageType.SendMessage

                MessageConsole.SelectionColor = Color.Red
                consoleMessage = "Sending NCS Message to " & currentMTAIp & vbCrLf
                consoleMessage += "---------------------------------------------------" & vbCrLf
                MessageConsole.SelectedText = consoleMessage

                'add message to Console
                MessageConsole.AppendText(message + vbCrLf)

                'see if should log message
                'If (Me.LogConsoleToolStripMenuItem.Checked = True) Then
                '    FilePut(LogFileNumber, consoleMessage + vbCrLf)
                'End If
                MessageConsole.Focus()
                MessageConsole.ScrollToCaret()

        End Select
        '  Catch ex As Exception
        '     MsgBox("Error reading " & MessageFileLabel.Text)
        ' End Try
    End Sub



    Public Sub NewMessageFile()

        Dim childMessageForm As New MessageForm(Me)
        childMessageForm.MdiParent = Me
        childMessageForm.Show()
        SetNonEmptyMDIButtons()

    End Sub

    Public Sub OpenMessageFile()

        Dim openform As New OpenFileDialog()

        openform.ValidateNames = True
        openform.Multiselect = False
        openform.CheckFileExists = True
        openform.FileName = ""
        openform.Filter() = "injector files (*.inj; *.txt)|*.inj; *.txt"
        If (openform.ShowDialog() = DialogResult.OK) Then

            Dim messageForm As New MessageForm(Me, openform.FileName)
            Dim fileStream As New FileStream(openform.FileName, FileMode.Open)
            messageForm.RichTextBox.LoadFile(fileStream, RichTextBoxStreamType.PlainText)
            'messageForm.ColorCodeText()
            messageForm.MdiParent = Me
            messageForm.Show()
            fileStream.Close()
            'turn on buttons
            Me.SetNonEmptyMDIButtons()


        End If
    End Sub

    Public Sub SaveMessageFile()

        Dim output_file_number As Integer

        activeChild = Me.ActiveMdiChild

        If (activeChild.GetFileName() = UNTITLED_MESSAGE_FILE) Then
            SaveAsMessageFile()
            Exit Sub
        End If

        Try

            Dim output_file_info As New FileInfo(activeChild.GetPathAndFileName())
            If (output_file_info.Exists) Then
                Try

                    Kill(activeChild.GetPathAndFileName())

                Catch ex As Exception
                End Try
            End If

            output_file_number = FreeFile()

            FileOpen(output_file_number, activeChild.GetPathAndFileName(), OpenMode.Binary, OpenAccess.Write, OpenShare.LockWrite)

            FilePut(output_file_number, activeChild.RichTextBox.Text, 1)
            FileClose(output_file_number)
            activeChild.NeedSave = False
            activeChild.ColorCodeText()
        Catch ex As Exception
            MsgBox("Problem writing to file " & activeChild.GetPathAndFileName & " during Save.", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Sub SaveAsMessageFile()

        Dim fileNumber As Integer

        activeChild = Me.ActiveMdiChild

        Dim saveform As New SaveFileDialog()
        saveform.DefaultExt = "inj"
        saveform.Filter = "injector files (*.inj; *.txt)|*.inj; *.txt"

        If (saveform.ShowDialog() = DialogResult().OK) Then

            Try

                'see if file exists..if it does kill it
                Try
                    Dim fileInfo As New FileInfo(saveform.FileName)
                    If (fileInfo.Exists) Then
                        Kill(saveform.FileName)
                    End If
                Catch
                End Try

                fileNumber = FreeFile()

                FileOpen(fileNumber, saveform.FileName, OpenMode.Binary, OpenAccess.Write, OpenShare.LockWrite)
                FilePut(fileNumber, activeChild.RichTextBox.Text)
                activeChild.ColorCodeText()

                FileClose(fileNumber)

                activeChild.SetPathAndFileName(saveform.FileName)
                activeChild.NeedSave = False
                Me.MessageFileLabel.Text = activeChild.GetFileName
            Catch ex As Exception
                MsgBox("Problem saving file " & saveform.FileName & " during Save As.", MsgBoxStyle.Exclamation)
            End Try

            'add new file into Message File Tree
            UpdateMessageFileTree()
        End If

        saveform.Dispose()

    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' SavePrompt()                                                     '
    ' Called when when a new message file is to be opened or that the  '
    ' program is to be shut down. In that case this is called if there '
    ' is changes that need to be saved to the open message file.       '
    ' Input:  None                                                     '
    ' Output: Result of prompt is returned, Yes, No or Cancel.         '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Function SavePrompt() As MsgBoxResult
        Dim result As MsgBoxResult

        activeChild = Me.ActiveMdiChild

        result = MsgBox("Save Changes to " & activeChild.GetFileName() & "?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel, "NCS Message Injector")

        If (result = MsgBoxResult.Yes) Then
            If (activeChild.GetFileName() = UNTITLED_MESSAGE_FILE) Then
                SaveAsMessageFile()
            Else
                SaveMessageFile()
            End If
        ElseIf (result = MsgBoxResult.No) Then
            activeChild.NeedSave = False
        ElseIf (result = MsgBoxResult.Cancel) Then
            activeChild.NeedSave = True
        End If
        Return result
    End Function


    Public Sub SetEmptyMDIButtons()
        Me.SaveAsToolStripMenuItem.Enabled = False
        Me.SaveToolStripButton.Enabled = False
        Me.SaveToolStripMenuItem.Enabled = False
        Me.CloseToolStripMenuItem.Enabled = False
        Me.PrintToolStripMenuItem.Enabled = False
        Me.PrintToolStripButton.Enabled = False
        Me.PrintPreviewToolStripButton.Enabled = False
        Me.PrintPreviewToolStripMenuItem.Enabled = False
        Me.WindowToolStripMenuItem.Visible = False
        Me.CutToolStripButton.Enabled = False
        Me.CutToolStripMenuItem.Enabled = False
        Me.CopyToolStripButton.Enabled = False
        Me.CopyToolStripMenuItem.Enabled = False
        Me.PasteToolStripMenuItem.Enabled = False
        Me.PasteToolStripButton.Enabled = False


    End Sub

    Public Sub SetNonEmptyMDIButtons()

        Me.SaveAsToolStripMenuItem.Enabled = True
        Me.SaveToolStripButton.Enabled = True
        Me.SaveToolStripMenuItem.Enabled = True
        Me.CloseToolStripMenuItem.Enabled = True
        Me.PrintToolStripMenuItem.Enabled = True
        Me.PrintToolStripButton.Enabled = True
        Me.PrintPreviewToolStripButton.Enabled = True
        Me.PrintPreviewToolStripMenuItem.Enabled = True
        Me.WindowToolStripMenuItem.Visible = True
        Me.CutToolStripButton.Enabled = True
        Me.CutToolStripMenuItem.Enabled = True
        Me.CopyToolStripButton.Enabled = True
        Me.CopyToolStripMenuItem.Enabled = True
        Me.PasteToolStripMenuItem.Enabled = True
        Me.PasteToolStripButton.Enabled = True
    End Sub





    Private Sub MessageFileTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles MessageFileTreeView.AfterSelect

        '   Me.MessageFileLabel.Text = MessageFileTreeView.SelectedNode.Text

    End Sub

    Private Sub MessageFileTreeView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessageFileTreeView.DoubleClick

        LoadMessageFile()

    End Sub

    Private Sub LoadMessageFile()
        Try
            Dim messageForm As New MessageForm(Me, MessageFileTreeView.SelectedNode.Tag)
            Dim fileStream As New FileStream(MessageFileTreeView.SelectedNode.Tag, FileMode.Open)
            messageForm.RichTextBox.LoadFile(fileStream, RichTextBoxStreamType.PlainText)
            messageForm.ColorCodeText()
            fileStream.Close()
            messageForm.MdiParent = Me
            messageForm.Show()
        Catch ex As Exception
        End Try

        'turn on buttons
        SetNonEmptyMDIButtons()
    End Sub



    Private Sub MainDialog_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim result As MsgBoxResult
        Dim fileList As String
        Dim fileCollection As New Collection()

        Try
            'go through all open windows and check to see if they need
            'to be saved 
            Do While Me.MdiChildren.Length > 0 And result <> MsgBoxResult.Cancel
                activeChild = Me.ActiveMdiChild

                'store files for opening next time
                fileList = activeChild.GetPathAndFileName()
                fileList += "," + activeChild.Size.Width.ToString + "," + activeChild.Size.Height.ToString + _
                            "," + activeChild.Location.X.ToString + "," + activeChild.Location.Y.ToString + "," + vbCrLf
                fileCollection.Add(fileList)
                If (activeChild.NeedSave) Then
                    result = SavePrompt()
                End If
                If (result <> MsgBoxResult.Cancel) Then
                    activeChild.Dispose()
                End If
            Loop
        Catch ex As Exception
        End Try

        'Change to root directory
        ChDir(NCSMessageInjectorDir)

        '''''''''''''''''''''''''''''''''''''''''''''''''''
        '              save Window list                   '
        '''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim windowFile As New FileInfo(WINDOW_LIST_FILE)
        Dim windowFileNumber As Integer


        Try
            If (windowFile.Exists) Then
                Try
                    Kill(WINDOW_LIST_FILE)
                Catch
                    'if the file does not exist, continue
                End Try
            End If

            windowFileNumber = FreeFile()

            'open windows.txt file
            FileOpen(windowFileNumber, WINDOW_LIST_FILE, OpenMode.Binary, OpenAccess.Write, OpenShare.LockWrite)

            'write each line, reverse from how they are stored. This is so 
            'the files will open in the correct order.
            Dim i As Integer
            For i = fileCollection.Count To 1 Step -1
                Dim fileLine As String = fileCollection(i)
                FilePut(windowFileNumber, fileLine)
            Next i

            FileClose(windowFileNumber)
        Catch
            MsgBox("Error writing to window file list " + WINDOW_LIST_FILE)
        End Try

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        '                save MTA file list              '
        ''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim mta_file As New FileInfo(MTA_LIST_FILE)
        Dim mta_file_number As Integer

        Try
            If mta_file.Exists Then
                Try
                    'make sure the file does not exist so we create a new one
                    Kill(MTA_LIST_FILE)
                Catch
                    'if the file does not exist then continue
                End Try
            End If

            mta_file_number = FreeFile()

            'open network.txt file
            FileOpen(mta_file_number, MTA_LIST_FILE, OpenMode.Binary, OpenAccess.Write, OpenShare.LockWrite)

        Catch ex As Exception
            MsgBox("Error opening " & MTA_LIST_FILE)
        End Try

        ' write mta info to file
        Try

            Dim i As Integer
            Dim j As Integer
            Dim bchar As Byte
            Dim OutputString As String
            Dim ipAddress As String
            Dim fqdn As String
            Dim recPort As String
            Dim destPort As String

            'Get ip address, receive port and destination port from MTA List Box
            For i = 0 To MTAListView.Items.Count - 1

                ipAddress = MTAListView.Items(i).Text
                fqdn = MTAListView.Items(i).SubItems(1).Text
                recPort = MTAListView.Items(i).SubItems(2).Text
                destPort = MTAListView.Items(i).SubItems(3).Text

                'Create display string with a ":" as a delimiter
                OutputString = ipAddress & ":" & fqdn & ":" & recPort & ":" & destPort & ":" & vbCrLf

                'write to network file
                FilePut(mta_file_number, OutputString)
            Next

        Catch ex1 As Exception
            MsgBox("Error writing to " & MTA_LIST_FILE)
        End Try

        Try
            FileClose(mta_file_number)
        Catch e2 As Exception
            MsgBox("Error closing " & MTA_LIST_FILE)
        End Try

        'clean up sockets
        Try
            mgcpSocket.Shutdown(Net.Sockets.SocketShutdown.Both)
            mgcpSocket.Close()
        Catch ex3 As Exception
        End Try

        'kill receiver Thread
        If (receiveThread.IsAlive) Then
            receiveThread.Abort()
        End If


        'write dialog size
        WriteMainFormSize()
    End Sub


    Sub WriteMainFormSize()

        Dim WriteSize As Boolean
        Dim size_file_number As Integer
        Dim size_file_name As String
        Dim outputline As String
        Dim bchar As Byte
        Dim i As Integer
        'if window was closed while minimized, don't want to save size
        If (Me.WindowState <> FormWindowState.Minimized) Then

            'open the MainDialogSize.txt file
            WriteSize = True
            Try
                'If MainDialogSize.txt exists then open and read it
                ChDir(NCSMessageInjectorDir)
                size_file_name = CurDir() & "\MainDialogSize.txt"
                Dim size_file As New FileInfo(size_file_name)
                If size_file.Exists Then
                    Try
                        'make sure the file does not exist so we create a new one
                        Kill(size_file_name)
                    Catch
                        'if the file does not exist then continue
                    End Try
                End If
                size_file_number = FreeFile()
                FileOpen(size_file_number, size_file_name, OpenMode.Binary, OpenAccess.Write, OpenShare.LockWrite)

            Catch ex As Exception
                WriteSize = False
                '   MsgBox("Unable to open output file " & size_file_name)

            End Try

            If WriteSize Then
                Try
                    'write the coordinates to MainDialogSize.txt
                    outputline = Me.Size.Width & ":" & Me.Size.Height & ":" & Me.Location.X & ":" & Me.Location.Y & ":"

                    FilePut(size_file_number, outputline)
                    FilePut(size_file_number, vbCrLf)

                    'write out the message console colors
                    outputline = MessageConsole.ForeColor.ToString & ":" & MessageConsole.BackColor.ToString & vbCrLf
                    FilePut(size_file_number, outputline)

                Catch ex1 As Exception
                    MsgBox("Error writing to file " & size_file_name)
                    Try
                        'Close the file containing the coordinates
                        FileClose(size_file_number)
                        WriteSize = False
                    Catch ex2 As Exception
                        MsgBox("Unable to close the file " & size_file_name)
                    End Try
                End Try
            End If
        End If

    End Sub

    Sub ReadMainFormSize()

        Dim size_file_number As Integer
        Dim size_file_name As String
        Dim size_file_buffer_len As Integer
        Dim MainDialogH_file_bytes As String
        Dim MainDialogW_file_bytes As String
        Dim MainDialogX_file_bytes As String
        Dim MainDialogY_file_bytes As String
        Dim begincordinate As Integer
        Dim i As Integer


        ChDir(NCSMessageInjectorDir)
        size_file_name = CurDir() & "\MainDialogSize.txt"
        i = 0

        Try
            'If MainDialogSize.txt exists then open and read it
            Dim size_file As New FileInfo(size_file_name)
            If Not size_file.Exists Then
                Exit Sub
            End If
            size_file_number = FreeFile()
            size_file_buffer_len = size_file.Length
            FileOpen(size_file_number, size_file_name, OpenMode.Binary, OpenAccess.Read, OpenShare.Default, size_file_buffer_len)
        Catch ex As Exception
            Exit Sub
        End Try

        Try
            Dim line As String = Space(size_file_buffer_len)

            line = LineInput(size_file_number)

            Dim MainDialogW As Integer = CInt(ParseToken(line, i, ":"))
            Dim MainDialogH As Integer = CInt(ParseToken(line, i, ":"))
            Dim MainDialogX As Integer = CInt(ParseToken(line, i, ":"))
            Dim MainDialogY As Integer = CInt(ParseToken(line, i, ":"))

            Me.Size = New System.Drawing.Size(MainDialogW, MainDialogH)
            Me.Location = New System.Drawing.Point(MainDialogX, MainDialogY)

            'get the forground color and set console colors
            line = LineInput(size_file_number)
            Dim lineArray() As String = Split(line, ":")

            Dim forgroundArray() As String = Split(lineArray(0), " ")
            If (forgroundArray(1) = "[Black]") Then
                Me.BlackOnWhiteConsole()
            ElseIf (forgroundArray(1) = "[White]") Then
                Me.WhiteOnBlackConsole()
            ElseIf (forgroundArray(1) = "[Yellow]") Then
                Me.YellowOnBlueConsole()
            Else
                Me.OrangeOnBlueConsole()
            End If

            FileClose(size_file_number)

        Catch ex1 As Exception
            Try
                'wipe clean the temp data before closing and deleteing the file
                'For longi = 1 To size_file_buffer_len
                'FilePut(size_file_number, 0, longi)
                'Next
                FileClose(size_file_number)
                'Kill(size_file_name)

            Catch ex2 As Exception
                Exit Sub
            End Try
        End Try

    End Sub


    Private Sub MDIChildActivated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MdiChildActivate

        Try
            activeChild = Me.ActiveMdiChild
            Dim node As New TreeNode()
            Me.MessageFileLabel.Text = activeChild.GetFileName()

        Catch ex As Exception
        End Try
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                PRINTING FUNCTIONS                                   '
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Private Sub PrintButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PrintMessageFile()
    End Sub

    Private Sub PrintMessageFile()
        Try
            activeChild = Me.ActiveMdiChild
            'Specify current page settings
            PrintDocument1.DefaultPageSettings = PrintPageSettings
            PrintDocument1.DocumentName = activeChild.GetFileName()
            'Specify document for print dialog box and show
            StringToPrint = activeChild.RichTextBox.Text
            PrintDialog1.Document = PrintDocument1

            Dim result As DialogResult = PrintDialog1.ShowDialog()
            'If OK , print document to printer
            If result = DialogResult.OK Then

                PrintDocument1.Print()
            End If
        Catch ex As Exception
            'Display error message
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub PrintPreviewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PrintPreviewMessageFile()
    End Sub

    Private Sub PrintPreviewMessageFile()

        Try
            activeChild = Me.ActiveMdiChild
            'Specify current page settings
            PrintDocument1.DefaultPageSettings = PrintPageSettings
            PrintDocument1.DocumentName = activeChild.GetFileName()

            'Specifiy document for print preview dialog box and show
            StringToPrint = activeChild.RichTextBox.Text
            PrintPreviewDialog1.Document = PrintDocument1

            PrintPreviewDialog1.Text = "Print Preview - " + activeChild.GetFileName()
            PrintPreviewDialog1.ShowDialog()
        Catch ex As Exception
            'Display error message
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' PageSetupButton_Click                                         '
    ' Called when the page setup menu item is click. This is the    '
    ' typical page setup functionality seen in most programs.       '
    ' Input:  Events...                                             '
    ' Output: None                                                  '
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub PageSetupMessageFile(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageSetupToolStripMenuItem.Click

        Try
            activeChild = Me.ActiveMdiChild
            'Load page settings and display page setup dialog box
            PageSetupDialog1.PageSettings = PrintPageSettings
            PrintDocument1.DocumentName = activeChild.GetFileName()

            PageSetupDialog1.ShowDialog()
        Catch ex As Exception
            'Display error message
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim numChars As Integer
        Dim numLines As Integer
        Dim stringForPage As String
        Dim strFormat As New StringFormat()

        'define header rectangle
        Dim headerRectDraw As New RectangleF(e.MarginBounds.Left, e.MarginBounds.Top - 30, _
e.MarginBounds.Width, e.MarginBounds.Height)

        'Based on page setup, define drawable rectangle on page
        Dim bodyRectDraw As New RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, _
        e.MarginBounds.Width, e.MarginBounds.Height)

        'define footer rectangle
        Dim footerRectDraw As New RectangleF(e.MarginBounds.Left, e.MarginBounds.Height + 125, _
e.MarginBounds.Width, e.MarginBounds.Height + 135)

        'Define area to determine how much text cna fit on a page
        'Make height one line shorter to ensure text doesn't clip 
        Dim sizeMeasure As New SizeF(e.MarginBounds.Width, _
    e.MarginBounds.Height - PrintFont.GetHeight(e.Graphics))

        'When drawing logon strings, break between words
        strFormat.Trimming = StringTrimming.Word
        'Compute how many chars and lines can fit based on sizeMeasure
        e.Graphics.MeasureString(StringToPrint, PrintFont, _
        sizeMeasure, strFormat, numChars, numLines)

        'Compute string that will fit on a page
        stringForPage = StringToPrint.Substring(0, numChars)

        Dim strCenterFormat As New StringFormat()
        strCenterFormat.Alignment = StringAlignment.Center

        '   e.Graphics.DrawImage(ImageList2.Images(0), e.MarginBounds.Left, e.MarginBounds.Top - 40)
        'Print title of page
        activeChild = Me.ActiveMdiChild
        e.Graphics.DrawString(activeChild.GetFileName(), BoldPrintFont, _
        Brushes.Black, headerRectDraw, strCenterFormat)

        'draw line under title
        Dim penLine As New Pen(Color.Black)
        e.Graphics.DrawLine(penLine, e.MarginBounds.Left, e.MarginBounds.Top - 10, e.MarginBounds.Right, e.MarginBounds.Top - 10)

        'Print string on current page
        e.Graphics.DrawString(stringForPage, PrintFont, _
        Brushes.Black, bodyRectDraw, strFormat)

        'Print string on current page
        e.Graphics.DrawString(CurrentPage.ToString, PrintFont, _
        Brushes.Black, footerRectDraw, strCenterFormat)

        'If there is more text, indicate there has been printed
        If numChars < StringToPrint.Length Then
            StringToPrint = StringToPrint.Substring(numChars)
            e.HasMorePages = True
            CurrentPage = CurrentPage + 1
        Else
            e.HasMorePages = False
            CurrentPage = 1
            'All text has been printed, so resore string
            StringToPrint = activeChild.RichTextBox.Text
        End If

    End Sub

    Private Sub MTAListView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MTAListView.DoubleClick
        ConnectToMTA()

    End Sub

    Private Sub EditMTADialog()
        Dim editMTA As New EditMTA(Me)

        editMTA.MTAIpAddressTextBox.Text = MTAListView.SelectedItems(0).Text
        editMTA.FQDNTextBox.Text = MTAListView.SelectedItems(0).SubItems(1).Text
        editMTA.RecPortTextBox.Text = MTAListView.SelectedItems(0).SubItems(2).Text
        editMTA.DestPortTextBox.Text = MTAListView.SelectedItems(0).SubItems(3).Text

        editMTA.StartPosition = FormStartPosition.CenterParent
        editMTA.ShowDialog(Me)
    End Sub
    Public Function IpExists(ByVal ip As String)

        Dim i As Integer

        'go though ip's see if match found
        For i = 0 To MTAListView.Items.Count - 1
            If (ip = MTAListView.Items(i).Text) Then
                Return True
            End If
        Next

        'no match found, unique ip
        Return False

    End Function

    Public Function GetMTAFieldError(ByVal ip As String, ByVal fqdn As String, ByVal recPort As String, ByVal destPort As String)

        Dim errorString As String = "Missing field(s)" & vbCrLf
        Dim ipError As Boolean = False
        Dim fqdnError As Boolean = False
        Dim recPortError As Boolean = False
        Dim destPortError As Boolean = False

        If (ip = String.Empty) Then
            ipError = True
            errorString += "MTA IP Address" & vbCrLf
        End If
        If (fqdn = String.Empty) Then
            fqdnError = True
            errorString += "FQDN" & vbCrLf
        End If
        If (recPort = String.Empty) Then
            recPortError = True
            errorString += " Receive UDP Port" & vbCrLf
        End If
        If (destPort = String.Empty) Then
            destPortError = True
            errorString += "Destination UDP Port" & vbCrLf
        End If

        If (ipError Or fqdnError Or recPortError Or destPortError) Then
            Return errorString
        Else
            Return String.Empty
        End If
    End Function
    ''''TEMP context menu
    'Private Sub MTAListViewContextMenuEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MTAListViewContextMenuEdit.Click
    '    EditMTADialog()

    'End Sub

    'Private Sub MTAListViewContextMenuDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MTAListViewContextMenuDelete.Click
    '    DeletingMTA = True
    '    Me.MTAListView.Items.Remove(MTAListView.SelectedItems(0))
    'End Sub

    'Private Sub MTAListViewContextMenuConnect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MTAListViewContextMenuConnect.Click
    '    ConnectToMTA()
    'End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' LogConsoleMenuItem_Click()                                  '
    ' Logs the Console window to a log file, log.rtf.             '
    ' Input:  Events....                                          '
    ' Output: None                                                '
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub LogConsoleMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim file As New FileInfo(LOG_FILE)

        'toggle LogConsoleMenu check mark
        'If (Me.LogConsoleToolStripMenuItem.Checked) Then
        '    Me.LogConsoleToolStripMenuItem.Checked = False
        'Else
        '    'begin loging
        '    Me.LogConsoleToolStripMenuItem.Checked = True

        '    'put log file in root directory
        '    ChDir(NCSMessageInjectorDir)

        '    Try
        '        If file.Exists Then
        '            Try
        '                'make sure the file does not exist so we create a new one
        '                Kill(LOG_FILE)
        '            Catch
        '                'if the file does not exist then continue
        '            End Try
        '        End If
        '        LogFileNumber = FreeFile()

        '        FileOpen(LogFileNumber, LOG_FILE, OpenMode.Binary)
        '    Catch ex As Exception
        '        MsgBox("Could not open a log file. There will be no logging!", MsgBoxStyle.Exclamation)
        '    End Try
        'End If
    End Sub


    Private Sub ReceivePortCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        ' If (Me.ReceivePortCheckBox.Checked) Then

        'Else

        'End If
    End Sub


    Private Sub LineNumberComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineNumberComboBox.SelectedIndexChanged

        Dim index As Integer = LineNumberComboBox.SelectedIndex

        If (index = 0) Then
            currentLineNumber = "1"
        ElseIf (index = 1) Then
            currentLineNumber = "2"
        ElseIf (index = 2) Then
            currentLineNumber = "3"
        ElseIf (index = 3) Then
            currentLineNumber = "4"
        ElseIf (index = 4) Then
            currentLineNumber = "5"
        ElseIf (index = 5) Then
            currentLineNumber = "6"
        ElseIf (index = 6) Then
            currentLineNumber = "7"
        ElseIf (index = 7) Then
            currentLineNumber = "8"
        ElseIf (index = 8) Then
            currentLineNumber = "9"
        ElseIf (index = 9) Then
            currentLineNumber = "10"
        ElseIf (index = 10) Then
            currentLineNumber = "11"
        ElseIf (index = 11) Then
            currentLineNumber = "12"
        ElseIf (index = 12) Then
            currentLineNumber = "$"
        ElseIf (index = 13) Then
            currentLineNumber = "*"
        End If


    End Sub



    Private Sub MessageFileTreeViewContextMenuEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadMessageFile()
    End Sub


    Private Sub NewBlankMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        NewMessageFile()
    End Sub

    Private Sub NewBuildFromTemplateMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowBuildMessageForm()

    End Sub

    Public Sub ShowBuildMessageForm()
        Dim buildMessage As New BuildMessage(Me)
        buildMessage.StartPosition = FormStartPosition.CenterParent
        buildMessage.ShowDialog()
    End Sub


    Private Sub PiggyDelayTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PiggyDelayTimer.Tick


        If (piggyCounter < piggybackMessage.Length) Then
            InsertParameters(piggybackMessage(piggyCounter))
            piggyCounter += 1
        Else
            Me.PiggyDelayTimer.Stop()
            piggyCounter = 0
            piggybackMessage.Clear(piggybackMessage, 0, piggybackMessage.Length)
        End If

    End Sub


    Private Sub EditSDPMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditCurrentSDPToolStripMenuItem.Click
        Dim SDPForm As New SDPForm()

        SDPForm.StartPosition = FormStartPosition.CenterParent
        SDPForm.RichTextBox.Text = CurrentSDP
        SDPForm.Show()
    End Sub


    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim SDPForm As New SDPForm()

        SDPForm.StartPosition = FormStartPosition.CenterParent
        SDPForm.RichTextBox.Text = CurrentSDP
        SDPForm.Show()
    End Sub


    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub OptionsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem1.Click
        Dim optionsDialog As New OptionsDialog
        optionsDialog.ShowDialog()


    End Sub

    Private Sub BlankMessageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlankMessageToolStripMenuItem.Click
        NewMessageFile()
    End Sub

    Private Sub BlankMessageFromTemplateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlankMessageFromTemplateToolStripMenuItem.Click
        ShowBuildMessageForm()
    End Sub

    Private Sub BlankMessageToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlankMessageToolStripMenuItem1.Click
        NewMessageFile()
    End Sub

    Private Sub NewMessageFromTemplateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewMessageFromTemplateToolStripMenuItem.Click
        ShowBuildMessageForm()
    End Sub

    Private Sub MTAListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MTAListView.SelectedIndexChanged
        DeleteMTAToolStripButton.Enabled = True
    End Sub

    Private Sub MenuStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip.ItemClicked

    End Sub

    Private Sub EditMTAConnectionsContextMenuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditMTAConnectionsContextMenuToolStripMenuItem.Click
        Me.EditMTADialog()

    End Sub

    Private Sub DeleteMtaConnectionsContextMenuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMtaConnectionsContextMenuToolStripMenuItem.Click
        DeletingMTA = True
        Me.MTAListView.Items.Remove(MTAListView.SelectedItems(0))
    End Sub

    Private Sub ConnectMtaConnectionsContextMenuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectMtaConnectionsContextMenuToolStripMenuItem.Click
        Me.ConnectToMTA()
    End Sub

    Private Sub OpenFileMessageFileTreeContextMenuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenFileMessageFileTreeContextMenuToolStripMenuItem.Click
        LoadMessageFile()
    End Sub

    Private Sub MessageFileTreeContextMenuStrip_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MessageFileTreeContextMenuStrip.Opening

        'If it's a file and not a folder, then enable the "Open file" menu
        If (MessageFileTreeView.SelectedNode.ImageIndex = 1) Then
            Me.OpenFileMessageFileTreeContextMenuToolStripMenuItem.Enabled = False
            If (MessageFileTreeView.SelectedNode.Nodes.Count > 0) Then
                Me.ExpandMessageFileTreeContextMenuToolStripMenuItem.Enabled = True
            Else
                Me.ExpandMessageFileTreeContextMenuToolStripMenuItem.Enabled = False
            End If
        Else
            Me.OpenFileMessageFileTreeContextMenuToolStripMenuItem.Enabled = True
            Me.ExpandMessageFileTreeContextMenuToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub AddFolderMessageFileTreeViewContextMenuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddFolderMessageFileTreeViewContextMenuToolStripMenuItem.Click
        Dim parentNode As New TreeNode
        Dim newNode As New TreeNode

        MessageFileTreeView.BeginUpdate()

        If (MessageFileTreeView.SelectedNode.Nodes.Count = 0) Then

            parentNode = Me.MessageFileTreeView.SelectedNode.Parent

            If (parentNode Is Nothing) Then
                parentNode = Me.MessageFileTreeView.SelectedNode
            End If
        Else
            parentNode = Me.MessageFileTreeView.SelectedNode
        End If

        'Now add in new folder
        Dim folderPath As String = parentNode.FullPath + "\New Folder"
        Dim dInfo As New DirectoryInfo(folderPath)
        Try
            dInfo.Create()
        Catch ex As Exception
            MessageBox.Show("Could not create new folder", "Error creating new folder", MessageBoxButtons.OK)
        End Try
        parentNode.Nodes.Add(newNode)

        newNode.ImageIndex = 1
        newNode.SelectedImageIndex = 1
        newNode.Text = "New Folder"

        parentNode.Expand()
        MessageFileTreeView.EndUpdate()
    End Sub



    Private Sub RefreshMessageFileTreeViewContextMenuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshMessageFileTreeViewContextMenuToolStripMenuItem.Click
        UpdateMessageFileTree()
    End Sub

    Private Sub MessageFileTreeView_AfterLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles MessageFileTreeView.AfterLabelEdit
        Dim selectedNode As New TreeNode

        MessageFileTreeView.BeginUpdate()

        If Not (e.Label Is Nothing) Then
            If e.Label.Length > 0 Then

                selectedNode = MessageFileTreeView.SelectedNode

                Try
                    If (selectedNode.ImageIndex = 1) Then
                        My.Computer.FileSystem.RenameDirectory(Me.MessageFileTreeView.SelectedNode.FullPath, e.Label)
                    Else
                        My.Computer.FileSystem.RenameFile(Me.MessageFileTreeView.SelectedNode.FullPath, e.Label)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error renaming file/folder", MessageBoxButtons.OK)
                End Try

            Else
                e.CancelEdit = True

            End If
        End If

        MessageFileTreeView.EndUpdate()


    End Sub

    Private Sub DeleteMessageFileTreeContextMenuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMessageFileTreeContextMenuToolStripMenuItem.Click
        Dim selectedNode As TreeNode

        MessageFileTreeView.BeginUpdate()

        selectedNode = MessageFileTreeView.SelectedNode

        Try
            If (selectedNode.ImageIndex = 1) Then
                My.Computer.FileSystem.DeleteDirectory(selectedNode.FullPath, FileIO.DeleteDirectoryOption.DeleteAllContents, _
                FileIO.RecycleOption.SendToRecycleBin)
            Else
                My.Computer.FileSystem.DeleteFile(selectedNode.FullPath)
            End If

            MessageFileTreeView.Nodes.Remove(selectedNode)
        Catch
            MessageBox.Show("Could not delete the the following file/folder " & selectedNode.FullPath, "Error with Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        MessageFileTreeView.EndUpdate()

    End Sub

    Private Sub ExpandMessageFileTreeContextMenuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandMessageFileTreeContextMenuToolStripMenuItem.Click

        Try
            Me.MessageFileTreeView.SelectedNode.ExpandAll()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub ExpandAllMessageFileTreeContextMenuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandAllMessageFileTreeContextMenuToolStripMenuItem.Click
        Try
            Me.MessageFileTreeView.ExpandAll()
        Catch
        End Try
    End Sub
End Class
