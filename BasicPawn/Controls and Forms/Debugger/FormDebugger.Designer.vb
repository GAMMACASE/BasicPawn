﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDebugger
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If (disposing) Then
                CleanUp()
            End If

            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDebugger))
        Me.StatusStrip_BPDebugger = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel_DebugState = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_NoConnection = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_EditorDebugLing = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_EditorLine = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_EditorCollum = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_EditorSelected = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip_BPDebugger = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem_File = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemFile_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Tools = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_ToolsSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_SettingsCatchExceptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_SettingsEntities = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_EntitiesEnableColor = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_EntitiesEnableShowNewEnts = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_ToolsCleanupTemp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_DebugStart = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_DebugPause = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_DebugStop = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_DebugRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TabControl2 = New BasicPawn.ClassTabControlColor()
        Me.TabPage_Source = New System.Windows.Forms.TabPage()
        Me.TextEditorControlEx_DebuggerSource = New BasicPawn.TextEditorControlEx()
        Me.TabPage_Diasm = New System.Windows.Forms.TabPage()
        Me.RichTextBox_DisasmSource = New System.Windows.Forms.RichTextBox()
        Me.ClassTabControlColor1 = New BasicPawn.ClassTabControlColor()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ListBox_Information = New System.Windows.Forms.ListBox()
        Me.TabControl1 = New BasicPawn.ClassTabControlColor()
        Me.TabPage_Breakpoints = New System.Windows.Forms.TabPage()
        Me.ListView_Breakpoints = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip_Breakpoints = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem_BreakpointsEnableAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_BreakpointsDisableAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem_BreakpointsSetValues = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage_Asserts = New System.Windows.Forms.TabPage()
        Me.ListView_Asserts = New System.Windows.Forms.ListView()
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip_Asserts = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem_AssertAction = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage_Watchers = New System.Windows.Forms.TabPage()
        Me.ListView_Watchers = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage_Entities = New System.Windows.Forms.TabPage()
        Me.ListView_Entities = New System.Windows.Forms.ListView()
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Timer_ConnectionCheck = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip_BPDebugger.SuspendLayout()
        Me.MenuStrip_BPDebugger.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage_Source.SuspendLayout()
        Me.TabPage_Diasm.SuspendLayout()
        Me.ClassTabControlColor1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage_Breakpoints.SuspendLayout()
        Me.ContextMenuStrip_Breakpoints.SuspendLayout()
        Me.TabPage_Asserts.SuspendLayout()
        Me.ContextMenuStrip_Asserts.SuspendLayout()
        Me.TabPage_Watchers.SuspendLayout()
        Me.TabPage_Entities.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip_BPDebugger
        '
        Me.StatusStrip_BPDebugger.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel_DebugState, Me.ToolStripStatusLabel_NoConnection, Me.ToolStripStatusLabel_EditorDebugLing, Me.ToolStripStatusLabel_EditorLine, Me.ToolStripStatusLabel_EditorCollum, Me.ToolStripStatusLabel_EditorSelected})
        Me.StatusStrip_BPDebugger.Location = New System.Drawing.Point(0, 707)
        Me.StatusStrip_BPDebugger.Name = "StatusStrip_BPDebugger"
        Me.StatusStrip_BPDebugger.Size = New System.Drawing.Size(1008, 22)
        Me.StatusStrip_BPDebugger.TabIndex = 1
        Me.StatusStrip_BPDebugger.Text = "StatusStrip_BasicPawnDebugger"
        '
        'ToolStripStatusLabel_DebugState
        '
        Me.ToolStripStatusLabel_DebugState.BackColor = System.Drawing.Color.Red
        Me.ToolStripStatusLabel_DebugState.Name = "ToolStripStatusLabel_DebugState"
        Me.ToolStripStatusLabel_DebugState.Size = New System.Drawing.Size(143, 17)
        Me.ToolStripStatusLabel_DebugState.Text = "Status: Debugger stopped"
        '
        'ToolStripStatusLabel_NoConnection
        '
        Me.ToolStripStatusLabel_NoConnection.BackColor = System.Drawing.Color.Red
        Me.ToolStripStatusLabel_NoConnection.Name = "ToolStripStatusLabel_NoConnection"
        Me.ToolStripStatusLabel_NoConnection.Size = New System.Drawing.Size(132, 17)
        Me.ToolStripStatusLabel_NoConnection.Text = "(Target not responding)"
        Me.ToolStripStatusLabel_NoConnection.Visible = False
        '
        'ToolStripStatusLabel_EditorDebugLing
        '
        Me.ToolStripStatusLabel_EditorDebugLing.Name = "ToolStripStatusLabel_EditorDebugLing"
        Me.ToolStripStatusLabel_EditorDebugLing.Size = New System.Drawing.Size(33, 17)
        Me.ToolStripStatusLabel_EditorDebugLing.Text = "DL: 0"
        '
        'ToolStripStatusLabel_EditorLine
        '
        Me.ToolStripStatusLabel_EditorLine.Name = "ToolStripStatusLabel_EditorLine"
        Me.ToolStripStatusLabel_EditorLine.Size = New System.Drawing.Size(25, 17)
        Me.ToolStripStatusLabel_EditorLine.Text = "L: 0"
        '
        'ToolStripStatusLabel_EditorCollum
        '
        Me.ToolStripStatusLabel_EditorCollum.Name = "ToolStripStatusLabel_EditorCollum"
        Me.ToolStripStatusLabel_EditorCollum.Size = New System.Drawing.Size(27, 17)
        Me.ToolStripStatusLabel_EditorCollum.Text = "C: 0"
        '
        'ToolStripStatusLabel_EditorSelected
        '
        Me.ToolStripStatusLabel_EditorSelected.Name = "ToolStripStatusLabel_EditorSelected"
        Me.ToolStripStatusLabel_EditorSelected.Size = New System.Drawing.Size(25, 17)
        Me.ToolStripStatusLabel_EditorSelected.Text = "S: 0"
        '
        'MenuStrip_BPDebugger
        '
        Me.MenuStrip_BPDebugger.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_File, Me.ToolStripMenuItem_Tools, Me.ToolStripMenuItem_DebugStart, Me.ToolStripMenuItem_DebugPause, Me.ToolStripMenuItem_DebugStop, Me.ToolStripMenuItem_DebugRefresh})
        Me.MenuStrip_BPDebugger.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip_BPDebugger.Name = "MenuStrip_BPDebugger"
        Me.MenuStrip_BPDebugger.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip_BPDebugger.ShowItemToolTips = True
        Me.MenuStrip_BPDebugger.Size = New System.Drawing.Size(1008, 24)
        Me.MenuStrip_BPDebugger.TabIndex = 2
        Me.MenuStrip_BPDebugger.Text = "MenuStrip_BasicPawnDebugger"
        '
        'ToolStripMenuItem_File
        '
        Me.ToolStripMenuItem_File.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemFile_Exit})
        Me.ToolStripMenuItem_File.Image = Global.BasicPawn.My.Resources.Resources.imageres_5306_16x16
        Me.ToolStripMenuItem_File.Name = "ToolStripMenuItem_File"
        Me.ToolStripMenuItem_File.Size = New System.Drawing.Size(53, 20)
        Me.ToolStripMenuItem_File.Text = "&File"
        '
        'ToolStripMenuItemFile_Exit
        '
        Me.ToolStripMenuItemFile_Exit.Image = Global.BasicPawn.My.Resources.Resources.imageres_5337_16x16
        Me.ToolStripMenuItemFile_Exit.Name = "ToolStripMenuItemFile_Exit"
        Me.ToolStripMenuItemFile_Exit.Size = New System.Drawing.Size(92, 22)
        Me.ToolStripMenuItemFile_Exit.Text = "&Exit"
        '
        'ToolStripMenuItem_Tools
        '
        Me.ToolStripMenuItem_Tools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_ToolsSettings, Me.ToolStripMenuItem_ToolsCleanupTemp})
        Me.ToolStripMenuItem_Tools.Image = Global.BasicPawn.My.Resources.Resources.imageres_5364_16x16
        Me.ToolStripMenuItem_Tools.Name = "ToolStripMenuItem_Tools"
        Me.ToolStripMenuItem_Tools.Size = New System.Drawing.Size(63, 20)
        Me.ToolStripMenuItem_Tools.Text = "Tools"
        '
        'ToolStripMenuItem_ToolsSettings
        '
        Me.ToolStripMenuItem_ToolsSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_SettingsCatchExceptions, Me.ToolStripMenuItem_SettingsEntities})
        Me.ToolStripMenuItem_ToolsSettings.Image = Global.BasicPawn.My.Resources.Resources.imageres_5364_16x16
        Me.ToolStripMenuItem_ToolsSettings.Name = "ToolStripMenuItem_ToolsSettings"
        Me.ToolStripMenuItem_ToolsSettings.Size = New System.Drawing.Size(254, 22)
        Me.ToolStripMenuItem_ToolsSettings.Text = "Settings"
        '
        'ToolStripMenuItem_SettingsCatchExceptions
        '
        Me.ToolStripMenuItem_SettingsCatchExceptions.CheckOnClick = True
        Me.ToolStripMenuItem_SettingsCatchExceptions.Name = "ToolStripMenuItem_SettingsCatchExceptions"
        Me.ToolStripMenuItem_SettingsCatchExceptions.Size = New System.Drawing.Size(164, 22)
        Me.ToolStripMenuItem_SettingsCatchExceptions.Text = "Catch exceptions"
        '
        'ToolStripMenuItem_SettingsEntities
        '
        Me.ToolStripMenuItem_SettingsEntities.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_EntitiesEnableColor, Me.ToolStripMenuItem_EntitiesEnableShowNewEnts})
        Me.ToolStripMenuItem_SettingsEntities.Name = "ToolStripMenuItem_SettingsEntities"
        Me.ToolStripMenuItem_SettingsEntities.Size = New System.Drawing.Size(164, 22)
        Me.ToolStripMenuItem_SettingsEntities.Text = "Entities"
        '
        'ToolStripMenuItem_EntitiesEnableColor
        '
        Me.ToolStripMenuItem_EntitiesEnableColor.CheckOnClick = True
        Me.ToolStripMenuItem_EntitiesEnableColor.DoubleClickEnabled = True
        Me.ToolStripMenuItem_EntitiesEnableColor.Name = "ToolStripMenuItem_EntitiesEnableColor"
        Me.ToolStripMenuItem_EntitiesEnableColor.Size = New System.Drawing.Size(265, 22)
        Me.ToolStripMenuItem_EntitiesEnableColor.Text = "Colorize created and deleted entities"
        '
        'ToolStripMenuItem_EntitiesEnableShowNewEnts
        '
        Me.ToolStripMenuItem_EntitiesEnableShowNewEnts.CheckOnClick = True
        Me.ToolStripMenuItem_EntitiesEnableShowNewEnts.DoubleClickEnabled = True
        Me.ToolStripMenuItem_EntitiesEnableShowNewEnts.Name = "ToolStripMenuItem_EntitiesEnableShowNewEnts"
        Me.ToolStripMenuItem_EntitiesEnableShowNewEnts.Size = New System.Drawing.Size(265, 22)
        Me.ToolStripMenuItem_EntitiesEnableShowNewEnts.Text = "Automatically scroll to new entities"
        '
        'ToolStripMenuItem_ToolsCleanupTemp
        '
        Me.ToolStripMenuItem_ToolsCleanupTemp.Image = Global.BasicPawn.My.Resources.Resources.imageres_5368_16x16
        Me.ToolStripMenuItem_ToolsCleanupTemp.Name = "ToolStripMenuItem_ToolsCleanupTemp"
        Me.ToolStripMenuItem_ToolsCleanupTemp.Size = New System.Drawing.Size(254, 22)
        Me.ToolStripMenuItem_ToolsCleanupTemp.Text = "Cleanup temporary debugger files"
        '
        'ToolStripMenuItem_DebugStart
        '
        Me.ToolStripMenuItem_DebugStart.AutoToolTip = True
        Me.ToolStripMenuItem_DebugStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripMenuItem_DebugStart.Image = Global.BasicPawn.My.Resources.Resources.imageres_5341_16x16
        Me.ToolStripMenuItem_DebugStart.Name = "ToolStripMenuItem_DebugStart"
        Me.ToolStripMenuItem_DebugStart.Size = New System.Drawing.Size(28, 20)
        Me.ToolStripMenuItem_DebugStart.ToolTipText = "Start/Continue debugging"
        '
        'ToolStripMenuItem_DebugPause
        '
        Me.ToolStripMenuItem_DebugPause.AutoToolTip = True
        Me.ToolStripMenuItem_DebugPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripMenuItem_DebugPause.Image = Global.BasicPawn.My.Resources.Resources.imageres_5313_16x16
        Me.ToolStripMenuItem_DebugPause.Name = "ToolStripMenuItem_DebugPause"
        Me.ToolStripMenuItem_DebugPause.Size = New System.Drawing.Size(28, 20)
        Me.ToolStripMenuItem_DebugPause.ToolTipText = "Suspend target"
        '
        'ToolStripMenuItem_DebugStop
        '
        Me.ToolStripMenuItem_DebugStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripMenuItem_DebugStop.Image = Global.BasicPawn.My.Resources.Resources.imageres_5337_16x16
        Me.ToolStripMenuItem_DebugStop.Name = "ToolStripMenuItem_DebugStop"
        Me.ToolStripMenuItem_DebugStop.Size = New System.Drawing.Size(28, 20)
        Me.ToolStripMenuItem_DebugStop.ToolTipText = "Stop debugging"
        '
        'ToolStripMenuItem_DebugRefresh
        '
        Me.ToolStripMenuItem_DebugRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripMenuItem_DebugRefresh.Image = Global.BasicPawn.My.Resources.Resources.imageres_5311_16x16
        Me.ToolStripMenuItem_DebugRefresh.Name = "ToolStripMenuItem_DebugRefresh"
        Me.ToolStripMenuItem_DebugRefresh.Size = New System.Drawing.Size(28, 20)
        Me.ToolStripMenuItem_DebugRefresh.ToolTipText = "Refreshes the source and restarts the debugger when debugging is active"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1008, 683)
        Me.SplitContainer1.SplitterDistance = 715
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.TabControl2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.ClassTabControlColor1)
        Me.SplitContainer2.Size = New System.Drawing.Size(715, 683)
        Me.SplitContainer2.SplitterDistance = 508
        Me.SplitContainer2.TabIndex = 2
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage_Source)
        Me.TabControl2.Controls.Add(Me.TabPage_Diasm)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Location = New System.Drawing.Point(0, 0)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(715, 508)
        Me.TabControl2.TabIndex = 1
        '
        'TabPage_Source
        '
        Me.TabPage_Source.Controls.Add(Me.TextEditorControlEx_DebuggerSource)
        Me.TabPage_Source.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Source.Name = "TabPage_Source"
        Me.TabPage_Source.Size = New System.Drawing.Size(707, 482)
        Me.TabPage_Source.TabIndex = 0
        Me.TabPage_Source.Text = "Source"
        '
        'TextEditorControlEx_DebuggerSource
        '
        Me.TextEditorControlEx_DebuggerSource.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextEditorControlEx_DebuggerSource.IsReadOnly = False
        Me.TextEditorControlEx_DebuggerSource.LineViewerStyle = ICSharpCode.TextEditor.Document.LineViewerStyle.FullRow
        Me.TextEditorControlEx_DebuggerSource.Location = New System.Drawing.Point(0, 0)
        Me.TextEditorControlEx_DebuggerSource.Name = "TextEditorControlEx_DebuggerSource"
        Me.TextEditorControlEx_DebuggerSource.ShowMatchingBracket = False
        Me.TextEditorControlEx_DebuggerSource.ShowTabs = True
        Me.TextEditorControlEx_DebuggerSource.ShowVRuler = False
        Me.TextEditorControlEx_DebuggerSource.Size = New System.Drawing.Size(707, 482)
        Me.TextEditorControlEx_DebuggerSource.TabIndex = 0
        Me.TextEditorControlEx_DebuggerSource.Text = "Packed Source"
        '
        'TabPage_Diasm
        '
        Me.TabPage_Diasm.Controls.Add(Me.RichTextBox_DisasmSource)
        Me.TabPage_Diasm.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Diasm.Name = "TabPage_Diasm"
        Me.TabPage_Diasm.Size = New System.Drawing.Size(707, 482)
        Me.TabPage_Diasm.TabIndex = 1
        Me.TabPage_Diasm.Text = "DIASM"
        '
        'RichTextBox_DisasmSource
        '
        Me.RichTextBox_DisasmSource.AutoWordSelection = True
        Me.RichTextBox_DisasmSource.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox_DisasmSource.DetectUrls = False
        Me.RichTextBox_DisasmSource.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox_DisasmSource.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox_DisasmSource.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBox_DisasmSource.Name = "RichTextBox_DisasmSource"
        Me.RichTextBox_DisasmSource.Size = New System.Drawing.Size(707, 482)
        Me.RichTextBox_DisasmSource.TabIndex = 0
        Me.RichTextBox_DisasmSource.Text = ""
        Me.RichTextBox_DisasmSource.WordWrap = False
        '
        'ClassTabControlColor1
        '
        Me.ClassTabControlColor1.Controls.Add(Me.TabPage1)
        Me.ClassTabControlColor1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ClassTabControlColor1.Location = New System.Drawing.Point(0, 0)
        Me.ClassTabControlColor1.Name = "ClassTabControlColor1"
        Me.ClassTabControlColor1.SelectedIndex = 0
        Me.ClassTabControlColor1.Size = New System.Drawing.Size(715, 171)
        Me.ClassTabControlColor1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ListBox_Information)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(707, 145)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ListBox_Information
        '
        Me.ListBox_Information.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox_Information.FormattingEnabled = True
        Me.ListBox_Information.HorizontalScrollbar = True
        Me.ListBox_Information.Location = New System.Drawing.Point(3, 3)
        Me.ListBox_Information.Name = "ListBox_Information"
        Me.ListBox_Information.Size = New System.Drawing.Size(701, 139)
        Me.ListBox_Information.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage_Breakpoints)
        Me.TabControl1.Controls.Add(Me.TabPage_Asserts)
        Me.TabControl1.Controls.Add(Me.TabPage_Watchers)
        Me.TabControl1.Controls.Add(Me.TabPage_Entities)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(289, 683)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage_Breakpoints
        '
        Me.TabPage_Breakpoints.Controls.Add(Me.ListView_Breakpoints)
        Me.TabPage_Breakpoints.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Breakpoints.Name = "TabPage_Breakpoints"
        Me.TabPage_Breakpoints.Size = New System.Drawing.Size(281, 657)
        Me.TabPage_Breakpoints.TabIndex = 0
        Me.TabPage_Breakpoints.Text = "Breakpoints"
        '
        'ListView_Breakpoints
        '
        Me.ListView_Breakpoints.CheckBoxes = True
        Me.ListView_Breakpoints.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader4})
        Me.ListView_Breakpoints.ContextMenuStrip = Me.ContextMenuStrip_Breakpoints
        Me.ListView_Breakpoints.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView_Breakpoints.FullRowSelect = True
        Me.ListView_Breakpoints.HideSelection = False
        Me.ListView_Breakpoints.Location = New System.Drawing.Point(0, 0)
        Me.ListView_Breakpoints.MultiSelect = False
        Me.ListView_Breakpoints.Name = "ListView_Breakpoints"
        Me.ListView_Breakpoints.Size = New System.Drawing.Size(281, 657)
        Me.ListView_Breakpoints.TabIndex = 0
        Me.ListView_Breakpoints.UseCompatibleStateImageBehavior = False
        Me.ListView_Breakpoints.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Line"
        Me.ColumnHeader1.Width = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Breakpoint"
        Me.ColumnHeader2.Width = 100
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Value"
        Me.ColumnHeader4.Width = 100
        '
        'ContextMenuStrip_Breakpoints
        '
        Me.ContextMenuStrip_Breakpoints.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_BreakpointsEnableAll, Me.ToolStripMenuItem_BreakpointsDisableAll, Me.ToolStripSeparator1, Me.ToolStripMenuItem_BreakpointsSetValues})
        Me.ContextMenuStrip_Breakpoints.Name = "ContextMenuStrip_Breakpoints"
        Me.ContextMenuStrip_Breakpoints.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip_Breakpoints.ShowImageMargin = False
        Me.ContextMenuStrip_Breakpoints.Size = New System.Drawing.Size(200, 76)
        '
        'ToolStripMenuItem_BreakpointsEnableAll
        '
        Me.ToolStripMenuItem_BreakpointsEnableAll.Name = "ToolStripMenuItem_BreakpointsEnableAll"
        Me.ToolStripMenuItem_BreakpointsEnableAll.Size = New System.Drawing.Size(199, 22)
        Me.ToolStripMenuItem_BreakpointsEnableAll.Text = "Enable all breakpoints"
        '
        'ToolStripMenuItem_BreakpointsDisableAll
        '
        Me.ToolStripMenuItem_BreakpointsDisableAll.Name = "ToolStripMenuItem_BreakpointsDisableAll"
        Me.ToolStripMenuItem_BreakpointsDisableAll.Size = New System.Drawing.Size(199, 22)
        Me.ToolStripMenuItem_BreakpointsDisableAll.Text = "Disable all breakpoints"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(196, 6)
        '
        'ToolStripMenuItem_BreakpointsSetValues
        '
        Me.ToolStripMenuItem_BreakpointsSetValues.Name = "ToolStripMenuItem_BreakpointsSetValues"
        Me.ToolStripMenuItem_BreakpointsSetValues.Size = New System.Drawing.Size(199, 22)
        Me.ToolStripMenuItem_BreakpointsSetValues.Text = "Set active breakpoint value..."
        '
        'TabPage_Asserts
        '
        Me.TabPage_Asserts.Controls.Add(Me.ListView_Asserts)
        Me.TabPage_Asserts.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Asserts.Name = "TabPage_Asserts"
        Me.TabPage_Asserts.Size = New System.Drawing.Size(281, 657)
        Me.TabPage_Asserts.TabIndex = 3
        Me.TabPage_Asserts.Text = "Asserts"
        Me.TabPage_Asserts.UseVisualStyleBackColor = True
        '
        'ListView_Asserts
        '
        Me.ListView_Asserts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14})
        Me.ListView_Asserts.ContextMenuStrip = Me.ContextMenuStrip_Asserts
        Me.ListView_Asserts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView_Asserts.FullRowSelect = True
        Me.ListView_Asserts.HideSelection = False
        Me.ListView_Asserts.Location = New System.Drawing.Point(0, 0)
        Me.ListView_Asserts.MultiSelect = False
        Me.ListView_Asserts.Name = "ListView_Asserts"
        Me.ListView_Asserts.Size = New System.Drawing.Size(281, 657)
        Me.ListView_Asserts.TabIndex = 1
        Me.ListView_Asserts.UseCompatibleStateImageBehavior = False
        Me.ListView_Asserts.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Line"
        Me.ColumnHeader11.Width = 50
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Assert"
        Me.ColumnHeader12.Width = 75
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Value"
        Me.ColumnHeader13.Width = 75
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Action"
        Me.ColumnHeader14.Width = 50
        '
        'ContextMenuStrip_Asserts
        '
        Me.ContextMenuStrip_Asserts.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_AssertAction})
        Me.ContextMenuStrip_Asserts.Name = "ContextMenuStrip_Asserts"
        Me.ContextMenuStrip_Asserts.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip_Asserts.ShowImageMargin = False
        Me.ContextMenuStrip_Asserts.Size = New System.Drawing.Size(183, 26)
        '
        'ToolStripMenuItem_AssertAction
        '
        Me.ToolStripMenuItem_AssertAction.Name = "ToolStripMenuItem_AssertAction"
        Me.ToolStripMenuItem_AssertAction.Size = New System.Drawing.Size(182, 22)
        Me.ToolStripMenuItem_AssertAction.Text = "Set active asserts action..."
        '
        'TabPage_Watchers
        '
        Me.TabPage_Watchers.Controls.Add(Me.ListView_Watchers)
        Me.TabPage_Watchers.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Watchers.Name = "TabPage_Watchers"
        Me.TabPage_Watchers.Size = New System.Drawing.Size(281, 657)
        Me.TabPage_Watchers.TabIndex = 1
        Me.TabPage_Watchers.Text = "Watcher"
        '
        'ListView_Watchers
        '
        Me.ListView_Watchers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.ListView_Watchers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView_Watchers.FullRowSelect = True
        Me.ListView_Watchers.HideSelection = False
        Me.ListView_Watchers.Location = New System.Drawing.Point(0, 0)
        Me.ListView_Watchers.MultiSelect = False
        Me.ListView_Watchers.Name = "ListView_Watchers"
        Me.ListView_Watchers.Size = New System.Drawing.Size(281, 657)
        Me.ListView_Watchers.TabIndex = 0
        Me.ListView_Watchers.UseCompatibleStateImageBehavior = False
        Me.ListView_Watchers.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Line"
        Me.ColumnHeader3.Width = 50
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Watcher"
        Me.ColumnHeader5.Width = 75
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Value"
        Me.ColumnHeader6.Width = 75
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Count"
        Me.ColumnHeader7.Width = 50
        '
        'TabPage_Entities
        '
        Me.TabPage_Entities.Controls.Add(Me.ListView_Entities)
        Me.TabPage_Entities.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Entities.Name = "TabPage_Entities"
        Me.TabPage_Entities.Size = New System.Drawing.Size(281, 657)
        Me.TabPage_Entities.TabIndex = 2
        Me.TabPage_Entities.Text = "Entities"
        '
        'ListView_Entities
        '
        Me.ListView_Entities.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10})
        Me.ListView_Entities.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView_Entities.FullRowSelect = True
        Me.ListView_Entities.Location = New System.Drawing.Point(0, 0)
        Me.ListView_Entities.MultiSelect = False
        Me.ListView_Entities.Name = "ListView_Entities"
        Me.ListView_Entities.Size = New System.Drawing.Size(281, 657)
        Me.ListView_Entities.TabIndex = 0
        Me.ListView_Entities.UseCompatibleStateImageBehavior = False
        Me.ListView_Entities.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "#"
        Me.ColumnHeader8.Width = 35
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Reference"
        Me.ColumnHeader9.Width = 50
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Classname"
        Me.ColumnHeader10.Width = 175
        '
        'Timer_ConnectionCheck
        '
        Me.Timer_ConnectionCheck.Interval = 10000
        '
        'FormDebugger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip_BPDebugger)
        Me.Controls.Add(Me.MenuStrip_BPDebugger)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip_BPDebugger
        Me.Name = "FormDebugger"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BasicPawn Debugger"
        Me.StatusStrip_BPDebugger.ResumeLayout(False)
        Me.StatusStrip_BPDebugger.PerformLayout()
        Me.MenuStrip_BPDebugger.ResumeLayout(False)
        Me.MenuStrip_BPDebugger.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage_Source.ResumeLayout(False)
        Me.TabPage_Diasm.ResumeLayout(False)
        Me.ClassTabControlColor1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage_Breakpoints.ResumeLayout(False)
        Me.ContextMenuStrip_Breakpoints.ResumeLayout(False)
        Me.TabPage_Asserts.ResumeLayout(False)
        Me.ContextMenuStrip_Asserts.ResumeLayout(False)
        Me.TabPage_Watchers.ResumeLayout(False)
        Me.TabPage_Entities.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents StatusStrip_BPDebugger As StatusStrip
    Friend WithEvents MenuStrip_BPDebugger As MenuStrip
    Friend WithEvents ToolStripMenuItem_File As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemFile_Exit As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel_DebugState As ToolStripStatusLabel
    Friend WithEvents TabControl1 As ClassTabControlColor
    Friend WithEvents TabPage_Breakpoints As TabPage
    Friend WithEvents TabPage_Watchers As TabPage
    Friend WithEvents TextEditorControlEx_DebuggerSource As TextEditorControlEx
    Friend WithEvents ListView_Breakpoints As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents TabControl2 As ClassTabControlColor
    Friend WithEvents TabPage_Source As TabPage
    Friend WithEvents TabPage_Diasm As TabPage
    Friend WithEvents ToolStripMenuItem_DebugStart As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_DebugStop As ToolStripMenuItem
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ContextMenuStrip_Breakpoints As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem_BreakpointsEnableAll As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_BreakpointsDisableAll As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem_BreakpointsSetValues As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Tools As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_ToolsCleanupTemp As ToolStripMenuItem
    Friend WithEvents ListView_Watchers As ListView
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ToolStripMenuItem_DebugPause As ToolStripMenuItem
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents TabPage_Entities As TabPage
    Friend WithEvents ListView_Entities As ListView
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ToolStripMenuItem_ToolsSettings As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_SettingsCatchExceptions As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_SettingsEntities As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_EntitiesEnableColor As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_EntitiesEnableShowNewEnts As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel_EditorDebugLing As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_EditorLine As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_EditorCollum As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_EditorSelected As ToolStripStatusLabel
    Friend WithEvents ToolStripMenuItem_DebugRefresh As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel_NoConnection As ToolStripStatusLabel
    Friend WithEvents Timer_ConnectionCheck As Timer
    Friend WithEvents RichTextBox_DisasmSource As RichTextBox
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents ClassTabControlColor1 As ClassTabControlColor
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents ListBox_Information As ListBox
    Friend WithEvents TabPage_Asserts As TabPage
    Friend WithEvents ListView_Asserts As ListView
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents ContextMenuStrip_Asserts As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem_AssertAction As ToolStripMenuItem
End Class
