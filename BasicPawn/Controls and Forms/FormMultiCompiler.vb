﻿'BasicPawn
'Copyright(C) 2017 TheTimocop

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


Imports System.Text.RegularExpressions

Public Class FormMultiCompiler
    Private g_mMainForm As FormMain

    Private g_sSourceFiles As String()
    Private g_bTestingOnly As Boolean = False
    Private g_bCleanDebuggerPlaceholder As Boolean = False

    Private g_mCompilerThread As Threading.Thread

    Public Sub New(f As FormMain, sSourceFiles As String(), bTestingOnly As Boolean, bCleanDebuggerPlaceholder As Boolean)
        g_mMainForm = f
        g_sSourceFiles = sSourceFiles
        g_bTestingOnly = bTestingOnly
        g_bCleanDebuggerPlaceholder = bCleanDebuggerPlaceholder

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call. 
        Panel_FooterControl.Name &= "@FooterControl"
        Panel_FooterDarkControl.Name &= "@FooterDarkControl"
    End Sub

    Private Sub FormMultiCompiler_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClassControlStyle.UpdateControls(Me)

        StartCompile()
    End Sub

    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        Me.Close()
    End Sub


    Public Sub StartCompile()
        If (ClassThread.IsValid(g_mCompilerThread)) Then
            Return
        End If

        g_mCompilerThread = New Threading.Thread(AddressOf CompilerThread) With {
            .IsBackground = True
        }
        g_mCompilerThread.Start()
    End Sub

    Private Sub CompilerThread()
        Try
            ClassThread.Exec(Of Object)(ProgressBar_Compiled, Sub()
                                                                  ProgressBar_Compiled.Maximum = g_sSourceFiles.Length
                                                                  ProgressBar_Compiled.Value = 0
                                                              End Sub)

            For i = 0 To g_sSourceFiles.Length - 1
                Dim sSourceFile As String = g_sSourceFiles(i)
                Dim sSource As String = IO.File.ReadAllText(g_sSourceFiles(i))
                Dim sCompilerOutput As String = ""
                Dim iModType As ClassSyntaxTools.ENUM_MOD_TYPE = ClassSyntaxTools.ENUM_MOD_TYPE.SOURCEMOD

                'We have no other choices here. Get mod type by extension...
                If (ClassConfigs.m_ActiveConfig.g_iModType = ClassConfigs.STRUC_CONFIG_ITEM.ENUM_MOD_TYPE.AUTO_DETECT) Then
                    Select Case (IO.Path.GetExtension(sSourceFile).ToLower)
                        Case ".sp"
                            iModType = ClassSyntaxTools.ENUM_MOD_TYPE.SOURCEMOD

                        Case ".sma"
                            iModType = ClassSyntaxTools.ENUM_MOD_TYPE.AMXMODX

                        Case ".p", ".pwn"
                            iModType = ClassSyntaxTools.ENUM_MOD_TYPE.PAWN

                        Case Else
                            Select Case (MessageBox.Show(String.Format("Could not detect mod type on file '{0}'", sSourceFile), "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                                Case DialogResult.Cancel
                                    Throw New ArgumentException("Compiling canceled")
                            End Select
                    End Select
                Else
                    Select Case (ClassConfigs.m_ActiveConfig.g_iModType)
                        Case ClassConfigs.STRUC_CONFIG_ITEM.ENUM_MOD_TYPE.SOURCEMOD
                            iModType = ClassSyntaxTools.ENUM_MOD_TYPE.SOURCEMOD

                        Case ClassConfigs.STRUC_CONFIG_ITEM.ENUM_MOD_TYPE.AMXMODX
                            iModType = ClassSyntaxTools.ENUM_MOD_TYPE.AMXMODX

                        Case Else
                            Throw New ArgumentException("Unknown mod type")
                    End Select
                End If


                Dim sOutputFile As String = IO.Path.Combine(ClassConfigs.m_ActiveConfig.g_sOutputFolder, String.Format("{0}.unk", IO.Path.GetFileNameWithoutExtension(sSourceFile)))
                Dim bSuccess As Boolean = ClassThread.Exec(Of Boolean)(Me, Function()
                                                                               If (g_bCleanDebuggerPlaceholder) Then
                                                                                   With New ClassDebuggerParser(g_mMainForm)
                                                                                       If (.HasDebugPlaceholder(sSource)) Then
                                                                                           Call .CleanupDebugPlaceholder(sSource, iModType)
                                                                                       End If
                                                                                   End With
                                                                               End If

                                                                               Return g_mMainForm.g_ClassTextEditorTools.CompileSource(g_bTestingOnly, sSource, sOutputFile, IO.Path.GetDirectoryName(sSourceFile), ClassConfigs.m_ActiveConfig.g_sCompilerPath, ClassConfigs.m_ActiveConfig.g_sIncludeFolders, sSourceFile, sCompilerOutput)
                                                                           End Function)

                Dim bWarning As Boolean = Regex.Match(sCompilerOutput, "\s+[0-9]+\s+\b(Warning|Warnings)\b\.").Success

                Dim bCancel As Boolean = False

                If (Not bSuccess) Then
                    ClassThread.Exec(Of Object)(Me, Sub()
                                                        With New Text.StringBuilder
                                                            .AppendLine(String.Format("'{0}' failed to compile!", sSourceFile))
                                                            .AppendLine("See information tab for more information.")
                                                            .AppendLine()
                                                            .AppendLine("Do you want to open the file now?")

                                                            Select Case (MessageBox.Show(Me, .ToString, "Compiler failure", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error))
                                                                Case DialogResult.Yes
                                                                    Dim mTab = g_mMainForm.g_ClassTabControl.AddTab()
                                                                    mTab.OpenFileTab(sSourceFile)
                                                                    mTab.SelectTab()

                                                                Case DialogResult.Cancel
                                                                    bCancel = True
                                                            End Select
                                                        End With
                                                    End Sub)
                ElseIf (bWarning) Then
                    ClassThread.Exec(Of Object)(Me, Sub()
                                                        With New Text.StringBuilder
                                                            .AppendLine(String.Format("'{0}' has compiler warnings!", sSourceFile))
                                                            .AppendLine("See information tab for more information.")
                                                            .AppendLine()
                                                            .AppendLine("Do you want to open the file now?")

                                                            Select Case (MessageBox.Show(Me, .ToString, "Compiler warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
                                                                Case DialogResult.Yes
                                                                    Dim mTab = g_mMainForm.g_ClassTabControl.AddTab()
                                                                    mTab.OpenFileTab(sSourceFile)
                                                                    mTab.SelectTab()

                                                                Case DialogResult.Cancel
                                                                    bCancel = True
                                                            End Select
                                                        End With
                                                    End Sub)
                End If

                If (bCancel) Then
                    Exit For
                End If

                ClassThread.Exec(Of Object)(ProgressBar_Compiled, Sub() ProgressBar_Compiled.Increment(1))
                ClassThread.Exec(Of Object)(Me, Sub() Me.Refresh())
            Next

            ClassThread.ExecAsync(Me, Sub() Me.Close())
        Catch ex As Threading.ThreadAbortException
            Throw
        Catch ex As Exception
            ClassExceptionLog.WriteToLogMessageBox(ex)

            ClassThread.ExecAsync(Me, Sub() Me.Close())
        End Try
    End Sub

    Private Sub FormMultiCompiler_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CleanUp()
    End Sub

    Private Sub CleanUp()
        ClassThread.Abort(g_mCompilerThread)
    End Sub
End Class