﻿'BasicPawn
'Copyright(C) 2016 TheTimocop

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
Imports ICSharpCode.TextEditor

Public Class UCInformationList
    Private g_mFormMain As FormMain

    Public Sub New(f As FormMain)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        g_mFormMain = f
    End Sub

    Private Sub ListBox_Information_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox_Information.SelectedIndexChanged
        If (ListBox_Information.SelectedItems.Count < 1) Then
            Return
        End If

        Try
            Dim bForceEnd As Boolean = False
            While True
                For i = 0 To g_mFormMain.g_ClassTabControl.TabsCount - 1
                    If (String.IsNullOrEmpty(g_mFormMain.g_ClassTabControl.Tab(i).File) OrElse Not IO.File.Exists(g_mFormMain.g_ClassTabControl.Tab(i).File)) Then
                        Continue For
                    End If


                    Dim sRegexPath As String = g_mFormMain.g_ClassTabControl.Tab(i).File.Replace("/"c, "\"c)

                    Dim lPathNames As New List(Of String)
                    For Each sName As String In sRegexPath.Split("\"c)
                        lPathNames.Add(Regex.Escape(sName))
                    Next

                    sRegexPath = String.Join("[\/|\\]", lPathNames.ToArray)


                    Dim regMatch As Match = Regex.Match(ListBox_Information.SelectedItems(0).ToString, String.Format("\b{0}\b\((?<Line>[0-9]+)\)\s\:", sRegexPath), RegexOptions.IgnoreCase)
                    If (regMatch.Success) Then
                        Dim iLineNum As Integer = CInt(regMatch.Groups("Line").Value) - 1
                        If (iLineNum < 0 OrElse iLineNum > g_mFormMain.g_ClassTabControl.Tab(i).TextEditor.Document.TotalNumberOfLines - 1) Then
                            Return
                        End If

                        g_mFormMain.g_ClassTabControl.Tab(i).TextEditor.ActiveTextAreaControl.Caret.Line = iLineNum
                        g_mFormMain.g_ClassTabControl.Tab(i).TextEditor.ActiveTextAreaControl.Caret.Column = 0
                        g_mFormMain.g_ClassTabControl.Tab(i).TextEditor.ActiveTextAreaControl.SelectionManager.ClearSelection()

                        Dim iLineLen As Integer = g_mFormMain.g_ClassTabControl.Tab(i).TextEditor.Document.GetLineSegment(iLineNum).Length

                        Dim iStart As New TextLocation(0, iLineNum)
                        Dim iEnd As New TextLocation(iLineLen, iLineNum)

                        g_mFormMain.g_ClassTabControl.Tab(i).TextEditor.ActiveTextAreaControl.SelectionManager.SetSelection(iStart, iEnd)

                        g_mFormMain.g_ClassTabControl.SelectTab(i)
                        Return
                    End If
                Next

                If (bForceEnd) Then
                    Exit While
                End If

                For Each sPath As String In g_mFormMain.g_ClassAutocompleteUpdater.GetIncludeFiles(g_mFormMain.g_ClassTabControl.ActiveTab.TextEditor.Document.TextContent, g_mFormMain.g_ClassTabControl.ActiveTab.File, g_mFormMain.g_ClassTabControl.ActiveTab.File, True)
                    If (String.IsNullOrEmpty(sPath) OrElse Not IO.File.Exists(sPath)) Then
                        Continue For
                    End If


                    Dim sRegexPath As String = sPath.Replace("/"c, "\"c)

                    Dim lPathNames As New List(Of String)
                    For Each sName As String In sRegexPath.Split("\"c)
                        lPathNames.Add(Regex.Escape(sName))
                    Next

                    sRegexPath = String.Join("[\/|\\]", lPathNames.ToArray)


                    Dim regMatch As Match = Regex.Match(ListBox_Information.SelectedItems(0).ToString, String.Format("\b{0}\b\((?<Line>[0-9]+)\)\s\:", sRegexPath), RegexOptions.IgnoreCase)
                    If (Not regMatch.Success) Then
                        Continue For
                    End If

                    g_mFormMain.g_ClassTabControl.AddTab(True)
                    g_mFormMain.g_ClassTabControl.OpenFileTab(g_mFormMain.g_ClassTabControl.TabsCount - 1, sPath)

                    bForceEnd = True
                    Continue While
                Next

                Exit While
            End While
        Catch ex As Exception
            ClassExceptionLog.WriteToLogMessageBox(ex)
        End Try
    End Sub

    Private Sub OpenInNotepadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenInNotepadToolStripMenuItem.Click
        Try
            Dim lInfos As New List(Of String)

            For Each sLine As String In ListBox_Information.Items
                lInfos.Add(sLine)
            Next

            Dim sTempFile As String = IO.Path.GetTempFileName
            IO.File.WriteAllLines(sTempFile, lInfos.ToArray)

            Process.Start("notepad.exe", sTempFile)
        Catch ex As Exception
            ClassExceptionLog.WriteToLogMessageBox(ex)
        End Try
    End Sub

    Private Sub CopyAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyAllToolStripMenuItem.Click
        Try
            Dim sbInfos As New Text.StringBuilder

            For Each sLine As String In ListBox_Information.Items
                sbInfos.AppendLine(sLine)
            Next

            My.Computer.Clipboard.SetText(sbInfos.ToString, TextDataFormat.Text)
        Catch ex As Exception
            ClassExceptionLog.WriteToLogMessageBox(ex)
        End Try
    End Sub
End Class
