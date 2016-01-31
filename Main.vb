Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.IO
Imports System.Environment

Module Main

    Public Enum ConsoleMessageType
        OpenSocket = 1
        SendMessage = 2
        ReceiveMessage = 3
    End Enum

    'Public mainform As New MainDialog
    Public NCSMessageInjectorDir As String = CurDir()
    Public TransId As Integer
    Public CurrentSDP As String = String.Empty
    Public WaitForProvResAck As Boolean = False
    Public LogFileNumber As Integer
    Public LogFileName As String = "log.txt"

    '''''''''''''''''''' Options ''''''''''''''''''''''''''
    Public Enum LogType
        None
        All
        Incoming
        Outgoing
    End Enum

    Public OptionEnableACKMessages As Boolean = True
    Public OptionPiggyDelay As Integer = 0
    Public OptionsLogType As Integer = LogType.None
    Public OptionsLogFile As File


    

    ''''''''''''''''''''''''''''''''''''''''''''
    '               Constants                  '
    ''''''''''''''''''''''''''''''''''''''''''''
    Public UNTITLED_MESSAGE_FILE As String = "Untitled"
    Public MTA_LIST_FILE As String = "network.txt"
    Public LOG_FILE As String = "log.txt"
    Public WINDOW_LIST_FILE As String = "windows.txt"

    Public RECV_10001 As String = "10001"
    Public RECV_10002 As String = "10002"
    Public RECV_10005 As String = "10005"
    Public RECV_HU As String = "hu"
    Public RECV_HD As String = "hd"
    Public RECV_2001 As String = "2001"
    Public RECV_200_1203 As String = "200 1203"
    Public RECV_200_1204 As String = "200 1204"
    Public RECV_20001 As String = "20001"
    Public RECV_20002 As String = "20002"
    Public RECV_PROVISIONAL_RESPONSE As String = "100"
    Public NON_SGCP_MESSAGE As String = "Non SCCP Message"
    Public PIGGYBACK_DELIMITER As String = NewLine + "." + NewLine
    Public SDP_DELIMITER As String = "v=0"

    ''''''''''''''''' Message File Keywords '''''''''''''''''''
    Public KEY_TRANSID As String = "transid"
    Public KEY_FQDN As String = "fqdn"
    Public KEY_SDP As String = "sdp"

    Public LineACKStatus(13) As Integer

    'Sub Main(ByVal CmdArgs() As String)


    '    Randomize() ' Initialize random-number generator.
    '    TransId = CInt(Int((200 * Rnd()) + 1)) ' Generate random value between 1 and 200.

    '    mainform.ShowDialog()
    '    mainform.Dispose()

    'End Sub







End Module
