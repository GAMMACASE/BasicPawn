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


Imports System.Windows.Forms
Imports BasicPawn
Imports BasicPawnPluginInterface

Public Class PluginAutoErrorReport
    Implements IPluginInterface

    Public g_mFormMain As FormMain

    Private g_ClassPlugin As ClassPlugin

    Private Shared ReadOnly g_mSpportedVersion As New Version("0.801")

#Region "Unused"
    Public Sub OnPluginLoad(sDLLPath As String) Implements IPluginInterface.OnPluginLoad
        Throw New NotImplementedException()
    End Sub

    Public Sub OnSettingsChanged() Implements IPluginInterface.OnSettingsChanged
        Throw New NotImplementedException()
    End Sub

    Public Sub OnConfigChanged() Implements IPluginInterface.OnConfigChanged
        Throw New NotImplementedException()
    End Sub

    Public Sub OnEditorSyntaxUpdate() Implements IPluginInterface.OnEditorSyntaxUpdate
        Throw New NotImplementedException()
    End Sub

    Public Sub OnEditorSyntaxUpdateEnd() Implements IPluginInterface.OnEditorSyntaxUpdateEnd
        Throw New NotImplementedException()
    End Sub

    Public Sub OnSyntaxUpdate(iType As Integer, bForceFromMemory As Boolean) Implements IPluginInterface.OnSyntaxUpdate
        Throw New NotImplementedException()
    End Sub

    Public Sub OnSyntaxUpdateEnd(iType As Integer, bForceFromMemory As Boolean) Implements IPluginInterface.OnSyntaxUpdateEnd
        Throw New NotImplementedException()
    End Sub

    Public Sub OnFormColorUpdate() Implements IPluginInterface.OnFormColorUpdate
        Throw New NotImplementedException()
    End Sub

    Public Sub OnDebuggerStart(mFormDebugger As Object) Implements IPluginInterface.OnDebuggerStart
        Throw New NotImplementedException()
    End Sub

    Public Sub OnDebuggerRefresh(mFormDebugger As Object) Implements IPluginInterface.OnDebuggerRefresh
        Throw New NotImplementedException()
    End Sub

    Public Sub OnDebuggerEndPost(mFormDebugger As Object) Implements IPluginInterface.OnDebuggerEndPost
        Throw New NotImplementedException()
    End Sub

    Public Sub OnDebuggerDebugStart() Implements IPluginInterface.OnDebuggerDebugStart
        Throw New NotImplementedException()
    End Sub

    Public Sub OnDebuggerDebugPause() Implements IPluginInterface.OnDebuggerDebugPause
        Throw New NotImplementedException()
    End Sub

    Public Sub OnDebuggerDebugStop() Implements IPluginInterface.OnDebuggerDebugStop
        Throw New NotImplementedException()
    End Sub

    Public Function OnPluginEnd() As Boolean Implements IPluginInterface.OnPluginEnd
        Throw New NotImplementedException()
    End Function

    Public Function OnDebuggerEnd(mFormDebugger As Object) As Boolean Implements IPluginInterface.OnDebuggerEnd
        Throw New NotImplementedException()
    End Function
#End Region

    Public ReadOnly Property m_PluginInformation As IPluginInterface.STRUC_PLUGIN_INFORMATION Implements IPluginInterface.m_PluginInformation
        Get
            Return New IPluginInterface.STRUC_PLUGIN_INFORMATION("Automatic Error Reporting Plugin",
                                                                 "Timocop",
                                                                 "Allows automatic error reporting over FTP",
                                                                 Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString,
                                                                 "https://github.com/Timocop/BasicPawn")
        End Get
    End Property

    Public ReadOnly Property m_PluginEnabled As Boolean Implements IPluginInterface.m_PluginEnabled
        Get
            Return (g_ClassPlugin IsNot Nothing)
        End Get
    End Property

    Public Sub OnPluginStart(mFormMain As Object, bEnabled As Boolean) Implements IPluginInterface.OnPluginStart
        g_mFormMain = DirectCast(mFormMain, FormMain)

        If (bEnabled) Then
            OnPluginEnabled(Nothing)
        End If
    End Sub

    Public Sub OnPluginEndPost() Implements IPluginInterface.OnPluginEndPost
        Throw New NotImplementedException()
    End Sub

    Public Function OnPluginEnabled(ByRef sReason As String) As Boolean Implements IPluginInterface.OnPluginEnabled
#If Not DEBUG Then
        If (New Version(Application.ProductVersion) < g_mSpportedVersion) Then
            sReason = String.Format("Unsupported BasicPawn version! Required is version v{0}.", g_mSpportedVersion.ToString)
            Return False
        End If
#End If

        If (g_ClassPlugin Is Nothing) Then
            g_ClassPlugin = New ClassPlugin(Me)
        End If

        Return True
    End Function

    Public Function OnPluginDisabled(ByRef sReason As String) As Boolean Implements IPluginInterface.OnPluginDisabled
        If (g_ClassPlugin IsNot Nothing) Then
            g_ClassPlugin.Dispose()
            g_ClassPlugin = Nothing
        End If

        Return True
    End Function

    Class ClassPlugin
        Implements IDisposable

        Public g_mPluginAutoErrorReport As PluginAutoErrorReport

        Private g_mReportMenuSplit As ToolStripSeparator
        Private g_mReportMenuItem As ToolStripMenuItem
        Private g_mReportMoreManagerMenuItem As ToolStripMenuItem
        Private g_mReportMoreSplit As ToolStripSeparator
        Private g_mReportMoreSettingsMenuItem As ToolStripMenuItem

        Private g_mFormReportManager As FormReportManager

        Public Sub New(mPluginAutoErrorReport As PluginAutoErrorReport)
            g_mPluginAutoErrorReport = mPluginAutoErrorReport

            BuildReportMenu()
        End Sub

        Private Sub BuildReportMenu()
            g_mReportMenuSplit = New ToolStripSeparator
            g_mReportMenuItem = New ToolStripMenuItem("Automatic Error Reporting", My.Resources.miguiresource_500_16x16_32)
            g_mPluginAutoErrorReport.g_mFormMain.ToolStripMenuItem_Tools.DropDownItems.Add(g_mReportMenuSplit)
            g_mPluginAutoErrorReport.g_mFormMain.ToolStripMenuItem_Tools.DropDownItems.Add(g_mReportMenuItem)

            g_mReportMoreManagerMenuItem = New ToolStripMenuItem("Report Manager", My.Resources.miguiresource_500_16x16_32)
            g_mReportMoreSplit = New ToolStripSeparator
            g_mReportMoreSettingsMenuItem = New ToolStripMenuItem("Settings", My.Resources.imageres_5364_16x16_32)
            g_mReportMenuItem.DropDownItems.Add(g_mReportMoreManagerMenuItem)
            g_mReportMenuItem.DropDownItems.Add(g_mReportMoreSplit)
            g_mReportMenuItem.DropDownItems.Add(g_mReportMoreSettingsMenuItem)

            RemoveHandler g_mReportMoreManagerMenuItem.Click, AddressOf OnReportManagerClick
            AddHandler g_mReportMoreManagerMenuItem.Click, AddressOf OnReportManagerClick

            RemoveHandler g_mReportMoreSettingsMenuItem.Click, AddressOf OnSettingsClick
            AddHandler g_mReportMoreSettingsMenuItem.Click, AddressOf OnSettingsClick

            'Update all FormMain controls, to change style for the newly created controls
            ClassControlStyle.UpdateControls(g_mPluginAutoErrorReport.g_mFormMain)
        End Sub

        Private Sub OnSettingsClick(sender As Object, e As EventArgs)
            Try
                Using i As New FormSettings(g_mPluginAutoErrorReport)
                    i.ShowDialog(g_mPluginAutoErrorReport.g_mFormMain)
                End Using
            Catch ex As Exception
                ClassExceptionLog.WriteToLogMessageBox(ex)
            End Try
        End Sub

        Private Sub OnReportManagerClick(sender As Object, e As EventArgs)
            Try
                If (g_mFormReportManager Is Nothing OrElse g_mFormReportManager.IsDisposed) Then
                    g_mFormReportManager = New FormReportManager(g_mPluginAutoErrorReport)
                    g_mFormReportManager.Show()
                Else
                    If (g_mFormReportManager.WindowState = FormWindowState.Minimized) Then
                        ClassTools.ClassForms.FormWindowCommand(g_mFormReportManager, ClassTools.ClassForms.NativeWinAPI.ShowWindowCommands.Restore)
                    End If

                    g_mFormReportManager.Activate()
                End If
            Catch ex As Exception
                ClassExceptionLog.WriteToLogMessageBox(ex)
            End Try
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).

                    'Remove Handlers
                    If (g_mReportMoreManagerMenuItem IsNot Nothing) Then
                        RemoveHandler g_mReportMoreManagerMenuItem.Click, AddressOf OnReportManagerClick
                    End If

                    If (g_mReportMoreSettingsMenuItem IsNot Nothing) Then
                        RemoveHandler g_mReportMoreSettingsMenuItem.Click, AddressOf OnSettingsClick
                    End If

                    'Remove Controls
                    If (g_mReportMenuSplit IsNot Nothing AndAlso Not g_mReportMenuSplit.IsDisposed) Then
                        g_mReportMenuSplit.Dispose()
                        g_mReportMenuSplit = Nothing
                    End If

                    If (g_mReportMenuItem IsNot Nothing AndAlso Not g_mReportMenuItem.IsDisposed) Then
                        g_mReportMenuItem.Dispose()
                        g_mReportMenuItem = Nothing
                    End If

                    If (g_mReportMoreManagerMenuItem IsNot Nothing AndAlso Not g_mReportMoreManagerMenuItem.IsDisposed) Then
                        g_mReportMoreManagerMenuItem.Dispose()
                        g_mReportMoreManagerMenuItem = Nothing
                    End If

                    If (g_mReportMoreSplit IsNot Nothing AndAlso Not g_mReportMoreSplit.IsDisposed) Then
                        g_mReportMoreSplit.Dispose()
                        g_mReportMoreSplit = Nothing
                    End If

                    If (g_mReportMoreSettingsMenuItem IsNot Nothing AndAlso Not g_mReportMoreSettingsMenuItem.IsDisposed) Then
                        g_mReportMoreSettingsMenuItem.Dispose()
                        g_mReportMoreSettingsMenuItem = Nothing
                    End If

                    If (g_mFormReportManager IsNot Nothing AndAlso Not g_mFormReportManager.IsDisposed) Then
                        g_mFormReportManager.Dispose()
                        g_mFormReportManager = Nothing
                    End If
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
End Class
