﻿'BasicPawn
'Copyright(C) 2018 TheTimocop

'This program Is free software: you can redistribute it And/Or modify
'it under the terms Of the GNU General Public License As published by
'the Free Software Foundation, either version 3 Of the License, Or
'(at your option) any later version.

'This program Is distributed In the hope that it will be useful,
'but WITHOUT ANY WARRANTY; without even the implied warranty Of
'MERCHANTABILITY Or FITNESS FOR A PARTICULAR PURPOSE.  See the
'GNU General Public License For more details.

'You should have received a copy Of the GNU General Public License
'along with this program. If Not, see < http: //www.gnu.org/licenses/>.


Imports System.Drawing
Imports System.Windows.Forms
Imports BasicPawn

Public Class FormReportManager
    Private g_mFtpSecureStorage As ClassSecureStorage
    Private g_mSettingsSecureStorage As ClassSecureStorage

    Private g_mClassTreeViewColumns As ClassTreeViewColumns

    Private g_mClassReports As ClassReports
    Private g_mClassLogs As ClassLogs

    Public g_mPluginAutoErrorReport As PluginAutoErrorReport

    Public g_sGetReportsOrginalText As String = ""
    Public g_sGetReportsOrginalImage As Image
    Public g_sGetLogsOrginalText As String = ""
    Public g_sGetLogsOrginalImage As Image

    Const ICON_FILE = 0
    Const ICON_WARN = 1
    Const ICON_ERROR = 2
    Const ICON_ARROW = 3

    Const ERROR_NOERROR = 0
    Const ERROR_MSGONLY = 1
    Const ERROR_TOOBIG = 2

    Enum ENUM_FTP_PROTOCOL_TYPE
        FTP
        SFTP
    End Enum

    Structure STRUC_FTP_ENTRY_ITEM
        Dim sGUID As String
        Dim sHost As String
        Dim sDatabaseEntry As String
        Dim sSourceModPath As String
        Dim iProtocolType As ENUM_FTP_PROTOCOL_TYPE

        Sub New(_Host As String, _DatabaseEntry As String, _SourceModPath As String, _ProtocolType As ENUM_FTP_PROTOCOL_TYPE)
            sGUID = Guid.NewGuid.ToString
            sHost = _Host
            sDatabaseEntry = _DatabaseEntry
            sSourceModPath = _SourceModPath
            iProtocolType = _ProtocolType
        End Sub
    End Structure

    Public Sub New(mPluginAutoErrorReport As PluginAutoErrorReport)
        g_mPluginAutoErrorReport = mPluginAutoErrorReport

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call. 
        g_mClassTreeViewColumns = New ClassTreeViewColumns
        g_mClassTreeViewColumns.m_TreeView.ImageList = ImageList_Logs
        g_mClassTreeViewColumns.m_Columns.Add("File", 400)
        g_mClassTreeViewColumns.m_Columns.Add("Size", 100)
        g_mClassTreeViewColumns.m_Columns.Add("Date", 100)
        g_mClassTreeViewColumns.Dock = DockStyle.Fill
        g_mClassTreeViewColumns.Parent = TabPage_Logs

        AddHandler g_mClassTreeViewColumns.m_TreeView.DoubleClick, AddressOf ClassTreeViewColumns_DoubleClick

        ImageList_Logs.Images.Clear()
        ImageList_Logs.Images.Add(CStr(ICON_FILE), My.Resources.imageres_5304_16x16_32)
        ImageList_Logs.Images.Add(CStr(ICON_WARN), My.Resources.user32_101_16x16_32)
        ImageList_Logs.Images.Add(CStr(ICON_ERROR), My.Resources.user32_103_16x16_32)
        ImageList_Logs.Images.Add(CStr(ICON_ARROW), My.Resources.netshell_1607_16x16_32)

        g_sGetReportsOrginalText = ToolStripMenuItem_GetReports.Text
        g_sGetReportsOrginalImage = ToolStripMenuItem_GetReports.Image
        g_sGetLogsOrginalText = ToolStripMenuItem_GetLogs.Text
        g_sGetLogsOrginalImage = ToolStripMenuItem_GetLogs.Image

        g_mFtpSecureStorage = New ClassSecureStorage("PluginAutoErrorReportFtpEntries")
        g_mSettingsSecureStorage = New ClassSecureStorage("PluginAutoErrorReportSettings")

        g_mClassReports = New ClassReports(Me)
        g_mClassLogs = New ClassLogs(Me)
    End Sub

    Private Sub FormReportManager_Load(sender As Object, e As EventArgs) Handles Me.Load
        ClassControlStyle.UpdateControls(Me)

        g_mClassReports.FetchReports()
        g_mClassLogs.FetchLogs()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub GetReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_GetReports.Click
        If (g_mClassReports.IsFetchingReports) Then
            g_mClassReports.AbortFetching()
        Else
            g_mClassReports.FetchReports()
        End If
    End Sub


    Private Sub ToolStripMenuItem_GetLogs_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_GetLogs.Click
        If (g_mClassLogs.IsFetchingLogs) Then
            g_mClassLogs.AbortFetching()
        Else
            g_mClassLogs.FetchLogs()
        End If
    End Sub

    Private Sub CloseReportWindowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_CloseReportWindows.Click
        g_mClassReports.CloseReportForms()
    End Sub

    Private Sub ReportListBox_Reports_DoubleClick(sender As Object, e As EventArgs) Handles ReportListBox_Reports.DoubleClick
        If (ReportListBox_Reports.SelectedItems.Count < 1) Then
            Return
        End If

        Dim mReportItem = TryCast(ReportListBox_Reports.SelectedItems(0), ClassReportListBox.ClassReportItem)
        If (mReportItem Is Nothing) Then
            Return
        End If

        If (Not mReportItem.m_IsClickable) Then
            Return
        End If

        Dim iCount = 0
        For Each mForm As Form In Application.OpenForms
            If (TypeOf mForm Is FormReportDetails) Then
                iCount += 1
            End If
        Next

        If (iCount > 100) Then
            MessageBox.Show("Too many 'Report' windows open!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim mFormReportDetails As New FormReportDetails(Me, mReportItem.m_Exception)
            mFormReportDetails.Show()
        End If
    End Sub

    Private Sub ClassTreeViewColumns_DoubleClick(sender As Object, e As EventArgs)
        Try
            If (g_mClassTreeViewColumns.m_TreeView.SelectedNode Is Nothing) Then
                Return
            End If

            Dim mTreeNodeData = TryCast(g_mClassTreeViewColumns.m_TreeView.SelectedNode, ClassTreeNodeData)
            If (mTreeNodeData Is Nothing) Then
                Return
            End If

            Dim sTitle As String = CStr(mTreeNodeData.g_mData("Title"))
            Dim sRemoteFile As String = CStr(mTreeNodeData.g_mData("RemoteFile"))
            Dim sLocalFile As String = CStr(mTreeNodeData.g_mData("LocalFile"))
            Dim iDate As Date = New Date(CLng(mTreeNodeData.g_mData("DateTick")))
            Dim iSize As Long = CLng(mTreeNodeData.g_mData("Size"))
            Dim iErrorIndex As Integer = CInt(mTreeNodeData.g_mData("ErrorIndex"))

            Select Case (iErrorIndex)
                Case ERROR_NOERROR
                    If (String.IsNullOrEmpty(sLocalFile) OrElse Not IO.File.Exists(sLocalFile)) Then
                        Throw New ArgumentException("Unable to open. Could not find local file.")
                    End If

                    Process.Start("notepad.exe", sLocalFile)

                Case ERROR_MSGONLY
                    Return

                Case ERROR_TOOBIG
                    Throw New ArgumentException("Unable to open. This file is too big to fetch.")

            End Select
        Catch ex As Exception
            ClassExceptionLog.WriteToLogMessageBox(ex)
        End Try
    End Sub

    Class ClassReports
        Implements IDisposable

        Public g_mFormReportManager As FormReportManager

        Private g_mFetchReportsThread As Threading.Thread

        Public Sub New(mFormReportManager As FormReportManager)
            g_mFormReportManager = mFormReportManager
        End Sub

        Public Sub FetchReports()
            If (ClassThread.IsValid(g_mFetchReportsThread)) Then
                Return
            End If

            g_mFetchReportsThread = New Threading.Thread(Sub()
                                                             Try
                                                                 ClassThread.ExecAsync(g_mFormReportManager, Sub()
                                                                                                                 g_mFormReportManager.ToolStripMenuItem_GetReports.Text = "Abort fetching reports"
                                                                                                                 g_mFormReportManager.ToolStripMenuItem_GetReports.Image = My.Resources.imageres_5337_16x16_32
                                                                                                             End Sub)

                                                                 Dim lReportItems As New List(Of Object()) '{sTitle, sMessage, mImage}
                                                                 Dim lReportExceptionItems As New List(Of ClassDebuggerParser.STRUC_SM_EXCEPTION)
                                                                 Dim lFtpEntries As New List(Of STRUC_FTP_ENTRY_ITEM)

                                                                 Dim iMaxFileBytes As Long = (100 * 1024 * 1024)
                                                                 Dim bFilesTooBig As Boolean = False

                                                                 g_mFormReportManager.g_mFtpSecureStorage.Open()
                                                                 g_mFormReportManager.g_mSettingsSecureStorage.Open()

                                                                 'Load Servers
                                                                 Using mIni As New ClassIni(g_mFormReportManager.g_mFtpSecureStorage.m_String(System.Text.Encoding.Default))
                                                                     For Each sSection As String In mIni.GetSectionNames
                                                                         Dim sHost As String = mIni.ReadKeyValue(sSection, "Host", Nothing)
                                                                         Dim sDatabaseEntry As String = mIni.ReadKeyValue(sSection, "DatabaseEntry", Nothing)
                                                                         Dim sSourceModPath As String = mIni.ReadKeyValue(sSection, "SourceModPath", Nothing)
                                                                         Dim sProtocol As String = mIni.ReadKeyValue(sSection, "Protocol", "FTP")

                                                                         If (String.IsNullOrEmpty(sHost) OrElse String.IsNullOrEmpty(sDatabaseEntry)) Then
                                                                             Continue For
                                                                         End If

                                                                         Dim iProtocolType As ENUM_FTP_PROTOCOL_TYPE
                                                                         Select Case (sProtocol)
                                                                             Case "SFTP"
                                                                                 iProtocolType = ENUM_FTP_PROTOCOL_TYPE.SFTP
                                                                             Case Else
                                                                                 iProtocolType = ENUM_FTP_PROTOCOL_TYPE.FTP
                                                                         End Select

                                                                         lFtpEntries.Add(New STRUC_FTP_ENTRY_ITEM(sHost, sDatabaseEntry, sSourceModPath, iProtocolType))
                                                                     Next
                                                                 End Using

                                                                 'Load Settings
                                                                 Using mIni As New ClassIni(g_mFormReportManager.g_mSettingsSecureStorage.m_String(System.Text.Encoding.Default))
                                                                     Dim iMaxFileSize As Integer = 0
                                                                     If (Integer.TryParse(mIni.ReadKeyValue("Settings", "MaxFileSize", "100"), iMaxFileSize)) Then
                                                                         iMaxFileBytes = (iMaxFileSize * 1024 * 1024)
                                                                     End If
                                                                 End Using

                                                                 'Fetch Reports
                                                                 For Each mFtpItem In lFtpEntries
                                                                     Dim g_mClassFTP As ClassFTP = Nothing
                                                                     Dim g_mClassSFTP As Renci.SshNet.SftpClient = Nothing

                                                                     Dim sLogDirectory As String = IO.Path.Combine(mFtpItem.sSourceModPath, "logs").Replace("\", "/")

                                                                     Try
                                                                         Dim mDatabaseItem = ClassDatabase.FindDatabaseItemByName(mFtpItem.sDatabaseEntry)
                                                                         If (mDatabaseItem Is Nothing) Then
                                                                             Throw New ArgumentException(String.Format("Unable to find database entry: {0}", mFtpItem.sDatabaseEntry))
                                                                         End If

                                                                         Select Case (mFtpItem.iProtocolType)
                                                                             Case ENUM_FTP_PROTOCOL_TYPE.FTP
                                                                                 g_mClassFTP = New ClassFTP(mFtpItem.sHost, mDatabaseItem.m_Username, mDatabaseItem.m_Password)

                                                                                 If (Not g_mClassFTP.PathExist(sLogDirectory)) Then
                                                                                     Throw New ArgumentException(String.Format("Could not find SourceMod 'logs' directory on: {0}/{1}", mFtpItem.sHost.TrimEnd("/"c), sLogDirectory.TrimStart("/"c)))
                                                                                 End If

                                                                                 For Each mItem In g_mClassFTP.GetDirectoryEntries(sLogDirectory)
                                                                                     Select Case (mItem.sName)
                                                                                         Case ".", ".."
                                                                                             Continue For
                                                                                     End Select

                                                                                     If (mItem.bIsDirectory) Then
                                                                                         Continue For
                                                                                     End If

                                                                                     Dim sFileExt As String = IO.Path.GetExtension(mItem.sName)
                                                                                     Dim sFileFullName As String = IO.Path.GetFileName(mItem.sName)

                                                                                     If (sFileExt.ToLower <> ".log" OrElse Not sFileFullName.ToLower.StartsWith("errors_")) Then
                                                                                         Continue For
                                                                                     End If

                                                                                     If (mItem.iSize > iMaxFileBytes) Then
                                                                                         bFilesTooBig = True
                                                                                         Continue For
                                                                                     End If

                                                                                     Dim sTmpFile As String = IO.Path.GetTempFileName
                                                                                     Try
                                                                                         g_mClassFTP.DownloadFile(mItem.sFullName, sTmpFile)

                                                                                         With New ClassDebuggerParser(Nothing)
                                                                                             lReportExceptionItems.AddRange(.ReadSourceModLogExceptions(IO.File.ReadAllLines(sTmpFile)))
                                                                                         End With
                                                                                     Finally
                                                                                         IO.File.Delete(sTmpFile)
                                                                                     End Try
                                                                                 Next


                                                                             Case ENUM_FTP_PROTOCOL_TYPE.SFTP
                                                                                 g_mClassSFTP = New Renci.SshNet.SftpClient(mFtpItem.sHost, mDatabaseItem.m_Username, mDatabaseItem.m_Password)

                                                                                 If (Not g_mClassSFTP.IsConnected) Then
                                                                                     g_mClassSFTP.Connect()
                                                                                 End If

                                                                                 If (Not g_mClassSFTP.Exists(sLogDirectory)) Then
                                                                                     Throw New ArgumentException(String.Format("Could not find SourceMod 'logs' directory on: {0}/{1}", mFtpItem.sHost.TrimEnd("/"c), sLogDirectory.TrimStart("/"c)))
                                                                                 End If

                                                                                 For Each mItem In g_mClassSFTP.ListDirectory(sLogDirectory)
                                                                                     Select Case (mItem.Name)
                                                                                         Case ".", ".."
                                                                                             Continue For
                                                                                     End Select

                                                                                     If (mItem.IsDirectory) Then
                                                                                         Continue For
                                                                                     End If

                                                                                     Dim sFileExt As String = IO.Path.GetExtension(mItem.Name)
                                                                                     Dim sFileFullName As String = IO.Path.GetFileName(mItem.Name)

                                                                                     If (sFileExt.ToLower <> ".log" OrElse Not sFileFullName.ToLower.StartsWith("errors_")) Then
                                                                                         Continue For
                                                                                     End If

                                                                                     If (mItem.Length > iMaxFileBytes) Then
                                                                                         bFilesTooBig = True
                                                                                         Continue For
                                                                                     End If

                                                                                     Dim sTmpFile As String = IO.Path.GetTempFileName
                                                                                     Try
                                                                                         Using mStream As New IO.FileStream(sTmpFile, IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite)
                                                                                             g_mClassSFTP.DownloadFile(mItem.FullName, mStream)
                                                                                         End Using

                                                                                         With New ClassDebuggerParser(Nothing)
                                                                                             lReportExceptionItems.AddRange(.ReadSourceModLogExceptions(IO.File.ReadAllLines(sTmpFile)))
                                                                                         End With
                                                                                     Finally
                                                                                         IO.File.Delete(sTmpFile)
                                                                                     End Try
                                                                                 Next

                                                                             Case Else
                                                                                 Throw New ArgumentException("Unknown connection type")
                                                                         End Select
                                                                     Catch ex As Threading.ThreadAbortException
                                                                         Throw
                                                                     Catch ex As Exception
                                                                         lReportItems.Add({"Error", ex.Message, My.Resources.user32_103_16x16_32})
                                                                     Finally
                                                                         If (g_mClassSFTP IsNot Nothing) Then
                                                                             g_mClassSFTP.Dispose()
                                                                             g_mClassSFTP = Nothing
                                                                         End If
                                                                     End Try
                                                                 Next

                                                                 If (bFilesTooBig) Then
                                                                     lReportItems.Add({"Unable to fetch some reports", String.Format("Some reports are too big to fetch. (max. {0} MB)", iMaxFileBytes / 1024 / 1024), My.Resources.user32_101_16x16_32})
                                                                 End If

                                                                 If (lReportExceptionItems.Count < 1) Then
                                                                     lReportItems.Add({"No error reports found", "Congratulations! No error reports have been found!", My.Resources.ieframe_36866_16x16_32})
                                                                 End If

                                                                 'Remove duplicates
                                                                 Dim lTmpList As New List(Of ClassDebuggerParser.STRUC_SM_EXCEPTION)
                                                                 For Each mItem In lReportExceptionItems.ToArray
                                                                     If (lTmpList.Exists(Function(x As ClassDebuggerParser.STRUC_SM_EXCEPTION)
                                                                                             If (x.sExceptionInfo <> mItem.sExceptionInfo) Then
                                                                                                 Return False
                                                                                             End If

                                                                                             If (x.sBlamingFile <> mItem.sBlamingFile) Then
                                                                                                 Return False
                                                                                             End If

                                                                                             If (x.dLogDate <> mItem.dLogDate) Then
                                                                                                 Return False
                                                                                             End If

                                                                                             If (x.mStackTraces.Length <> mItem.mStackTraces.Length) Then
                                                                                                 Return False
                                                                                             End If

                                                                                             For i = 0 To x.mStackTraces.Length - 1
                                                                                                 If (x.mStackTraces(i).sFunctionName <> mItem.mStackTraces(i).sFunctionName) Then
                                                                                                     Return False
                                                                                                 End If

                                                                                                 If (x.mStackTraces(i).iLine <> mItem.mStackTraces(i).iLine) Then
                                                                                                     Return False
                                                                                                 End If

                                                                                                 If (x.mStackTraces(i).sFileName <> mItem.mStackTraces(i).sFileName) Then
                                                                                                     Return False
                                                                                                 End If

                                                                                                 If (x.mStackTraces(i).bNativeFault <> mItem.mStackTraces(i).bNativeFault) Then
                                                                                                     Return False
                                                                                                 End If
                                                                                             Next

                                                                                             Return True
                                                                                         End Function)) Then
                                                                         Continue For
                                                                     End If

                                                                     lTmpList.Add(mItem)
                                                                 Next
                                                                 lReportExceptionItems.Clear()
                                                                 lReportExceptionItems.AddRange(lTmpList)

                                                                 'Sort all reports. Top = Newer.
                                                                 lReportExceptionItems.Sort(Function(x As ClassDebuggerParser.STRUC_SM_EXCEPTION, y As ClassDebuggerParser.STRUC_SM_EXCEPTION)
                                                                                                Return -(x.dLogDate.CompareTo(y.dLogDate))
                                                                                            End Function)

                                                                 ClassThread.ExecAsync(g_mFormReportManager, Sub()
                                                                                                                 g_mFormReportManager.ReportListBox_Reports.BeginUpdate()
                                                                                                                 g_mFormReportManager.ReportListBox_Reports.Items.Clear()

                                                                                                                 For Each mItem In lReportExceptionItems

                                                                                                                     g_mFormReportManager.ReportListBox_Reports.Items.Add(New ClassReportListBox.ClassReportItem(mItem))
                                                                                                                 Next

                                                                                                                 For Each mItem In lReportItems
                                                                                                                     g_mFormReportManager.ReportListBox_Reports.Items.Add(New ClassReportListBox.ClassReportItem(CStr(mItem(0)), CStr(mItem(1)), "", CType(mItem(2), Image), False, Nothing))
                                                                                                                 Next

                                                                                                                 g_mFormReportManager.ReportListBox_Reports.EndUpdate()
                                                                                                             End Sub)

                                                                 ClassThread.ExecAsync(g_mFormReportManager, Sub()
                                                                                                                 g_mFormReportManager.ToolStripMenuItem_GetReports.Text = g_mFormReportManager.g_sGetReportsOrginalText
                                                                                                                 g_mFormReportManager.ToolStripMenuItem_GetReports.Image = g_mFormReportManager.g_sGetReportsOrginalImage
                                                                                                             End Sub)
                                                             Catch ex As Threading.ThreadAbortException
                                                                 Throw
                                                             Catch ex As Exception
                                                                 ClassExceptionLog.WriteToLogMessageBox(ex)

                                                                 ClassThread.ExecAsync(g_mFormReportManager, Sub()
                                                                                                                 g_mFormReportManager.ToolStripMenuItem_GetReports.Text = g_mFormReportManager.g_sGetReportsOrginalText
                                                                                                                 g_mFormReportManager.ToolStripMenuItem_GetReports.Image = g_mFormReportManager.g_sGetReportsOrginalImage
                                                                                                             End Sub)
                                                             End Try
                                                         End Sub) With {
                .IsBackground = True
            }
            g_mFetchReportsThread.Start()
        End Sub

        Public Function IsFetchingReports() As Boolean
            Return ClassThread.IsValid(g_mFetchReportsThread)
        End Function

        Public Sub AbortFetching()
            ClassThread.Abort(g_mFetchReportsThread)

            g_mFormReportManager.ToolStripMenuItem_GetReports.Text = g_mFormReportManager.g_sGetReportsOrginalText
            g_mFormReportManager.ToolStripMenuItem_GetReports.Image = g_mFormReportManager.g_sGetReportsOrginalImage
        End Sub

        Public Sub CloseReportForms()
            Dim lForms As New List(Of Form)

            For Each mForm As Form In Application.OpenForms
                If (TypeOf mForm Is FormReportDetails) Then
                    lForms.Add(mForm)
                End If
            Next

            For Each mForm In lForms
                mForm.Close()
            Next
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                    AbortFetching()
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            ' TODO: uncomment the following line if Finalize() is overridden above.
            ' GC.SuppressFinalize(Me)
        End Sub
#End Region
    End Class

    Class ClassLogs
        Implements IDisposable

        Public g_mFormReportManager As FormReportManager

        Private g_mFetchLogsThread As Threading.Thread
        Private g_lFilesCleanup As New List(Of String)

        Public Sub New(mFormReportManager As FormReportManager)
            g_mFormReportManager = mFormReportManager
        End Sub

        Public Sub FetchLogs()
            If (ClassThread.IsValid(g_mFetchLogsThread)) Then
                Return
            End If

            'Cleanup old files
            For Each sFile As String In g_lFilesCleanup
                IO.File.Delete(sFile)
            Next
            g_lFilesCleanup.Clear()

            'Start new thread
            g_mFetchLogsThread = New Threading.Thread(Sub()
                                                          Try
                                                              ClassThread.ExecAsync(g_mFormReportManager, Sub()
                                                                                                              g_mFormReportManager.ToolStripMenuItem_GetLogs.Text = "Abort fetching logs"
                                                                                                              g_mFormReportManager.ToolStripMenuItem_GetLogs.Image = My.Resources.imageres_5337_16x16_32
                                                                                                          End Sub)

                                                              Const E_TITLE = 0
                                                              Const E_REMOTEFILE = 1
                                                              Const E_LOCALFILE = 2
                                                              Const E_DATETICK = 3
                                                              Const E_SIZE = 4
                                                              Const E_ERRORINDEX = 5 'See ERROR_* constants

                                                              Dim lReportItems As New List(Of Object()) '{sTitle, sRemoteFile, sLocalFile, iDateTick, iSize, iErrorIndex} 
                                                              Dim lFtpEntries As New List(Of STRUC_FTP_ENTRY_ITEM)

                                                              Dim iMaxFileBytes As Long = (100 * 1024 * 1024)
                                                              Dim bFilesTooBig As Boolean = False

                                                              g_mFormReportManager.g_mFtpSecureStorage.Open()
                                                              g_mFormReportManager.g_mSettingsSecureStorage.Open()

                                                              'Load Servers
                                                              Using mIni As New ClassIni(g_mFormReportManager.g_mFtpSecureStorage.m_String(System.Text.Encoding.Default))
                                                                  For Each sSection As String In mIni.GetSectionNames
                                                                      Dim sHost As String = mIni.ReadKeyValue(sSection, "Host", Nothing)
                                                                      Dim sDatabaseEntry As String = mIni.ReadKeyValue(sSection, "DatabaseEntry", Nothing)
                                                                      Dim sSourceModPath As String = mIni.ReadKeyValue(sSection, "SourceModPath", Nothing)
                                                                      Dim sProtocol As String = mIni.ReadKeyValue(sSection, "Protocol", "FTP")

                                                                      If (String.IsNullOrEmpty(sHost) OrElse String.IsNullOrEmpty(sDatabaseEntry)) Then
                                                                          Continue For
                                                                      End If

                                                                      Dim iProtocolType As ENUM_FTP_PROTOCOL_TYPE
                                                                      Select Case (sProtocol)
                                                                          Case "SFTP"
                                                                              iProtocolType = ENUM_FTP_PROTOCOL_TYPE.SFTP
                                                                          Case Else
                                                                              iProtocolType = ENUM_FTP_PROTOCOL_TYPE.FTP
                                                                      End Select

                                                                      lFtpEntries.Add(New STRUC_FTP_ENTRY_ITEM(sHost, sDatabaseEntry, sSourceModPath, iProtocolType))
                                                                  Next
                                                              End Using

                                                              'Load Settings
                                                              Using mIni As New ClassIni(g_mFormReportManager.g_mSettingsSecureStorage.m_String(System.Text.Encoding.Default))
                                                                  Dim iMaxFileSize As Integer = 0
                                                                  If (Integer.TryParse(mIni.ReadKeyValue("Settings", "MaxFileSize", "100"), iMaxFileSize)) Then
                                                                      iMaxFileBytes = (iMaxFileSize * 1024 * 1024)
                                                                  End If
                                                              End Using

                                                              'Fetch Logs
                                                              For Each mFtpItem In lFtpEntries
                                                                  Dim g_mClassFTP As ClassFTP = Nothing
                                                                  Dim g_mClassSFTP As Renci.SshNet.SftpClient = Nothing

                                                                  Dim sLogDirectory As String = IO.Path.Combine(mFtpItem.sSourceModPath, "logs").Replace("\", "/")

                                                                  Try
                                                                      Dim mDatabaseItem = ClassDatabase.FindDatabaseItemByName(mFtpItem.sDatabaseEntry)
                                                                      If (mDatabaseItem Is Nothing) Then
                                                                          Throw New ArgumentException(String.Format("Unable to find database entry: {0}", mFtpItem.sDatabaseEntry))
                                                                      End If

                                                                      Select Case (mFtpItem.iProtocolType)
                                                                          Case ENUM_FTP_PROTOCOL_TYPE.FTP
                                                                              g_mClassFTP = New ClassFTP(mFtpItem.sHost, mDatabaseItem.m_Username, mDatabaseItem.m_Password)

                                                                              If (Not g_mClassFTP.PathExist(sLogDirectory)) Then
                                                                                  Throw New ArgumentException(String.Format("Could not find SourceMod 'logs' directory on: {0}/{1}", mFtpItem.sHost.TrimEnd("/"c), sLogDirectory.TrimStart("/"c)))
                                                                              End If

                                                                              For Each mItem In g_mClassFTP.GetDirectoryEntries(sLogDirectory)
                                                                                  Select Case (mItem.sName)
                                                                                      Case ".", ".."
                                                                                          Continue For
                                                                                  End Select

                                                                                  If (mItem.bIsDirectory) Then
                                                                                      Continue For
                                                                                  End If

                                                                                  Dim sFileExt As String = IO.Path.GetExtension(mItem.sName)
                                                                                  Dim sFileFullName As String = IO.Path.GetFileName(mItem.sName)

                                                                                  If (sFileExt.ToLower <> ".log" AndAlso sFileExt.ToLower <> ".txt") Then
                                                                                      Continue For
                                                                                  End If

                                                                                  If (mItem.iSize > iMaxFileBytes) Then
                                                                                      bFilesTooBig = True

                                                                                      lReportItems.Add({mItem.sName, mFtpItem.sHost.TrimEnd("\"c) & mItem.sFullName.TrimStart("\"c), "", mItem.dModified.Ticks, mItem.iSize, ERROR_TOOBIG})
                                                                                      Continue For
                                                                                  End If

                                                                                  Dim sTmpFile As String = IO.Path.GetTempFileName
                                                                                  g_lFilesCleanup.Add(sTmpFile)
                                                                                  g_mClassFTP.DownloadFile(mItem.sFullName, sTmpFile)
                                                                                  ApplyNewlineFix(sTmpFile)

                                                                                  lReportItems.Add({mItem.sName, mFtpItem.sHost.TrimEnd("\"c) & mItem.sFullName.TrimStart("\"c), sTmpFile, mItem.dModified.Ticks, mItem.iSize, ERROR_NOERROR})
                                                                              Next


                                                                          Case ENUM_FTP_PROTOCOL_TYPE.SFTP
                                                                              g_mClassSFTP = New Renci.SshNet.SftpClient(mFtpItem.sHost, mDatabaseItem.m_Username, mDatabaseItem.m_Password)

                                                                              If (Not g_mClassSFTP.IsConnected) Then
                                                                                  g_mClassSFTP.Connect()
                                                                              End If

                                                                              If (Not g_mClassSFTP.Exists(sLogDirectory)) Then
                                                                                  Throw New ArgumentException(String.Format("Could not find SourceMod 'logs' directory on: {0}/{1}", mFtpItem.sHost.TrimEnd("/"c), sLogDirectory.TrimStart("/"c)))
                                                                              End If

                                                                              For Each mItem In g_mClassSFTP.ListDirectory(sLogDirectory)
                                                                                  Select Case (mItem.Name)
                                                                                      Case ".", ".."
                                                                                          Continue For
                                                                                  End Select

                                                                                  If (mItem.IsDirectory) Then
                                                                                      Continue For
                                                                                  End If

                                                                                  Dim sFileExt As String = IO.Path.GetExtension(mItem.Name)
                                                                                  Dim sFileFullName As String = IO.Path.GetFileName(mItem.Name)

                                                                                  If (sFileExt.ToLower <> ".log" AndAlso sFileExt.ToLower <> ".txt") Then
                                                                                      Continue For
                                                                                  End If

                                                                                  If (mItem.Length > iMaxFileBytes) Then
                                                                                      bFilesTooBig = True

                                                                                      lReportItems.Add({mItem.Name, mFtpItem.sHost.TrimEnd("\"c) & mItem.FullName.TrimStart("\"c), "", mItem.Attributes.LastWriteTime.Ticks, mItem.Length, ERROR_TOOBIG})
                                                                                      Continue For
                                                                                  End If

                                                                                  Dim sTmpFile As String = IO.Path.GetTempFileName
                                                                                  g_lFilesCleanup.Add(sTmpFile)
                                                                                  Using mStream As New IO.FileStream(sTmpFile, IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite)
                                                                                      g_mClassSFTP.DownloadFile(mItem.FullName, mStream)
                                                                                  End Using
                                                                                  ApplyNewlineFix(sTmpFile)

                                                                                  lReportItems.Add({mItem.Name, mFtpItem.sHost.TrimEnd("\"c) & mItem.FullName.TrimStart("\"c), sTmpFile, mItem.Attributes.LastWriteTime.Ticks, mItem.Length, ERROR_NOERROR})
                                                                              Next

                                                                              If (bFilesTooBig) Then
                                                                                  lReportItems.Add({String.Format("Unable to fetch some log files. Some log files are too big to fetch. (max. {0} MB)", iMaxFileBytes / 1024 / 1024), "", "", 0, 0, ERROR_MSGONLY})
                                                                              End If

                                                                          Case Else
                                                                              Throw New ArgumentException("Unknown connection type")
                                                                      End Select
                                                                  Catch ex As Threading.ThreadAbortException
                                                                      Throw
                                                                  Catch ex As Exception
                                                                      lReportItems.Add({"Error: " & ex.Message, "", "", 0, 0, ERROR_MSGONLY})
                                                                  Finally
                                                                      If (g_mClassSFTP IsNot Nothing) Then
                                                                          g_mClassSFTP.Dispose()
                                                                          g_mClassSFTP = Nothing
                                                                      End If
                                                                  End Try
                                                              Next

                                                              ClassThread.ExecAsync(g_mFormReportManager, Sub()
                                                                                                              g_mFormReportManager.TabPage_Logs.SuspendLayout()
                                                                                                              g_mFormReportManager.g_mClassTreeViewColumns.m_TreeView.BeginUpdate()
                                                                                                              g_mFormReportManager.g_mClassTreeViewColumns.m_TreeView.Nodes.Clear()

                                                                                                              For Each mItem In lReportItems
                                                                                                                  Dim sTitle As String = CStr(mItem(E_TITLE))
                                                                                                                  Dim sRemoteFile As String = CStr(mItem(E_REMOTEFILE))
                                                                                                                  Dim sLocalFile As String = CStr(mItem(E_LOCALFILE))
                                                                                                                  Dim iDate As Date = New Date(CLng(mItem(E_DATETICK)))
                                                                                                                  Dim iSize As Long = CLng(mItem(E_SIZE))
                                                                                                                  Dim iErrorIndex As Integer = CInt(mItem(E_ERRORINDEX))

                                                                                                                  Dim iImageIndex As Integer = ICON_FILE
                                                                                                                  Select Case (iErrorIndex)
                                                                                                                      Case ERROR_MSGONLY
                                                                                                                          iImageIndex = ICON_WARN

                                                                                                                      Case ERROR_TOOBIG
                                                                                                                          iImageIndex = ICON_ERROR

                                                                                                                  End Select

                                                                                                                  Select Case (iErrorIndex)
                                                                                                                      Case ERROR_MSGONLY
                                                                                                                          Dim sRootNodeName As String = "Information"

                                                                                                                          Dim mRootNodes As TreeNodeCollection = g_mFormReportManager.g_mClassTreeViewColumns.m_TreeView.Nodes
                                                                                                                          Dim mFileNodes As TreeNodeCollection

                                                                                                                          If (Not mRootNodes.ContainsKey(sRootNodeName)) Then
                                                                                                                              mRootNodes.Add(New TreeNode(sRootNodeName, ICON_ARROW, ICON_ARROW) With {
                                                                                                                                .Name = sRootNodeName
                                                                                                                              })
                                                                                                                          End If

                                                                                                                          mFileNodes = mRootNodes(sRootNodeName).Nodes

                                                                                                                          mFileNodes.Add(New TreeNode(sTitle, iImageIndex, iImageIndex))
                                                                                                                      Case Else

                                                                                                                          'Check if the remote path is present, we need that
                                                                                                                          If (String.IsNullOrEmpty(sRemoteFile)) Then
                                                                                                                              Continue For
                                                                                                                          End If

                                                                                                                          Dim sRootNodeName As String = IO.Path.GetDirectoryName(sRemoteFile)

                                                                                                                          Dim mRootNodes As TreeNodeCollection = g_mFormReportManager.g_mClassTreeViewColumns.m_TreeView.Nodes
                                                                                                                          Dim mFileNodes As TreeNodeCollection

                                                                                                                          If (Not mRootNodes.ContainsKey(sRootNodeName)) Then
                                                                                                                              mRootNodes.Add(New TreeNode(sRootNodeName, ICON_ARROW, ICON_ARROW) With {
                                                                                                                            .Name = sRootNodeName
                                                                                                                          })
                                                                                                                          End If

                                                                                                                          mFileNodes = mRootNodes(sRootNodeName).Nodes

                                                                                                                          Dim mNode As New ClassTreeNodeData(sTitle, iImageIndex, iImageIndex) With {
                                                                                                                              .Tag = New String() {ClassTools.ClassStrings.FormatBytes(iSize), iDate.ToString}
                                                                                                                          }

                                                                                                                          mNode.g_mData("Title") = sTitle
                                                                                                                          mNode.g_mData("RemoteFile") = sRemoteFile
                                                                                                                          mNode.g_mData("LocalFile") = sLocalFile
                                                                                                                          mNode.g_mData("DateTick") = iDate.Ticks
                                                                                                                          mNode.g_mData("Size") = iSize
                                                                                                                          mNode.g_mData("ErrorIndex") = iErrorIndex

                                                                                                                          mFileNodes.Add(mNode)
                                                                                                                  End Select
                                                                                                              Next

                                                                                                              g_mFormReportManager.g_mClassTreeViewColumns.m_TreeView.Sort()
                                                                                                              g_mFormReportManager.g_mClassTreeViewColumns.m_TreeView.ExpandAll()
                                                                                                              g_mFormReportManager.g_mClassTreeViewColumns.m_TreeView.EndUpdate()
                                                                                                              g_mFormReportManager.TabPage_Logs.ResumeLayout()
                                                                                                          End Sub)

                                                              ClassThread.ExecAsync(g_mFormReportManager, Sub()
                                                                                                              g_mFormReportManager.ToolStripMenuItem_GetLogs.Text = g_mFormReportManager.g_sGetLogsOrginalText
                                                                                                              g_mFormReportManager.ToolStripMenuItem_GetLogs.Image = g_mFormReportManager.g_sGetLogsOrginalImage
                                                                                                          End Sub)
                                                          Catch ex As Threading.ThreadAbortException
                                                              Throw
                                                          Catch ex As Exception
                                                              ClassExceptionLog.WriteToLogMessageBox(ex)

                                                              ClassThread.ExecAsync(g_mFormReportManager, Sub()
                                                                                                              g_mFormReportManager.ToolStripMenuItem_GetLogs.Text = g_mFormReportManager.g_sGetLogsOrginalText
                                                                                                              g_mFormReportManager.ToolStripMenuItem_GetLogs.Image = g_mFormReportManager.g_sGetLogsOrginalImage
                                                                                                          End Sub)
                                                          End Try
                                                      End Sub) With {
                .IsBackground = True
            }
            g_mFetchLogsThread.Start()
        End Sub

        'Unix newline fix for notepad or other editors that doesnt support it
        Private Sub ApplyNewlineFix(sPath As String)
            Dim sText As String = IO.File.ReadAllText(sPath)

            sText = String.Join(Environment.NewLine, sText.Split(New String() {vbNewLine, vbLf}, 0))

            IO.File.WriteAllText(sPath, sText)
        End Sub

        Public Function IsFetchingLogs() As Boolean
            Return ClassThread.IsValid(g_mFetchLogsThread)
        End Function

        Public Sub AbortFetching()
            ClassThread.Abort(g_mFetchLogsThread)

            g_mFormReportManager.ToolStripMenuItem_GetLogs.Text = g_mFormReportManager.g_sGetLogsOrginalText
            g_mFormReportManager.ToolStripMenuItem_GetLogs.Image = g_mFormReportManager.g_sGetLogsOrginalImage
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                    AbortFetching()

                    'Cleanup old files
                    For Each sFile As String In g_lFilesCleanup
                        IO.File.Delete(sFile)
                    Next
                    g_lFilesCleanup.Clear()
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            ' TODO: uncomment the following line if Finalize() is overridden above.
            ' GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Private Sub FormReportManager_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CleanUp()
    End Sub

    Private Sub CleanUp()

        If (g_mClassTreeViewColumns IsNot Nothing) Then
            RemoveHandler g_mClassTreeViewColumns.m_TreeView.DoubleClick, AddressOf ClassTreeViewColumns_DoubleClick
        End If

        If (g_mClassTreeViewColumns IsNot Nothing AndAlso Not g_mClassTreeViewColumns.IsDisposed) Then
            g_mClassTreeViewColumns.Dispose()
            g_mClassTreeViewColumns = Nothing
        End If

        If (g_mClassReports IsNot Nothing) Then
            g_mClassReports.CloseReportForms()

            g_mClassReports.Dispose()
            g_mClassReports = Nothing
        End If

        If (g_mClassLogs IsNot Nothing) Then
            g_mClassLogs.Dispose()
            g_mClassLogs = Nothing
        End If
    End Sub
End Class