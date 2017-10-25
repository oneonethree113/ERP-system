Public Class IMM00004

    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code"
    Friend WithEvents StatusBar As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents RichTextBox3 As System.Windows.Forms.RichTextBox
    Friend WithEvents txtItmNo As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtItmDsc As System.Windows.Forms.RichTextBox
    Friend WithEvents txtMsg As System.Windows.Forms.RichTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtItmSts As System.Windows.Forms.TextBox
    Friend WithEvents txtItmTyp As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents grdItemList As System.Windows.Forms.DataGridView
    Friend WithEvents optHold As System.Windows.Forms.RadioButton
    Friend WithEvents optRelease As System.Windows.Forms.RadioButton
    Friend WithEvents cmdList As System.Windows.Forms.Button
    Friend WithEvents menuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents mmdAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdFind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdInsRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdDelRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdAttach As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdFunction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdLink As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdExit As System.Windows.Forms.ToolStripMenuItem

    Public rs_POM00010_AppList As New DataSet

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMM00004))
        Me.StatusBar = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.ComboBox6 = New System.Windows.Forms.ComboBox
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox
        Me.txtItmNo = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtItmDsc = New System.Windows.Forms.RichTextBox
        Me.txtMsg = New System.Windows.Forms.RichTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtItmSts = New System.Windows.Forms.TextBox
        Me.txtItmTyp = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.grdItemList = New System.Windows.Forms.DataGridView
        Me.optHold = New System.Windows.Forms.RadioButton
        Me.optRelease = New System.Windows.Forms.RadioButton
        Me.cmdList = New System.Windows.Forms.Button
        Me.menuStrip = New System.Windows.Forms.MenuStrip
        Me.mmdAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdSave = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdCopy = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdFind = New System.Windows.Forms.ToolStripMenuItem
        Me.t1 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdClear = New System.Windows.Forms.ToolStripMenuItem
        Me.t2 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.t3 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdInsRow = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdDelRow = New System.Windows.Forms.ToolStripMenuItem
        Me.t4 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.t5 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdAttach = New System.Windows.Forms.ToolStripMenuItem
        Me.t6 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdFunction = New System.Windows.Forms.ToolStripMenuItem
        Me.t7 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdLink = New System.Windows.Forms.ToolStripMenuItem
        Me.t8 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdExit = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusBar
        '
        Me.StatusBar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusBar.Location = New System.Drawing.Point(0, 605)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2})
        Me.StatusBar.ShowPanels = True
        Me.StatusBar.Size = New System.Drawing.Size(954, 26)
        Me.StatusBar.TabIndex = 276
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 469
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel2.Name = "StatusBarPanel2"
        Me.StatusBarPanel2.Width = 469
        '
        'TextBox11
        '
        Me.TextBox11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TextBox11.Location = New System.Drawing.Point(112, 40)
        Me.TextBox11.MaxLength = 20
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(105, 20)
        Me.TextBox11.TabIndex = 281
        '
        'ComboBox6
        '
        Me.ComboBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Location = New System.Drawing.Point(112, 15)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(683, 21)
        Me.ComboBox6.TabIndex = 271
        '
        'RichTextBox3
        '
        Me.RichTextBox3.Location = New System.Drawing.Point(112, 64)
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.Size = New System.Drawing.Size(683, 58)
        Me.RichTextBox3.TabIndex = 17
        Me.RichTextBox3.Text = ""
        '
        'txtItmNo
        '
        Me.txtItmNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmNo.Location = New System.Drawing.Point(109, 40)
        Me.txtItmNo.MaxLength = 3000
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(787, 20)
        Me.txtItmNo.TabIndex = 1
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(17, 444)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(36, 12)
        Me.Label33.TabIndex = 296
        Me.Label33.Text = "Action"
        '
        'txtItmDsc
        '
        Me.txtItmDsc.Enabled = False
        Me.txtItmDsc.Location = New System.Drawing.Point(109, 74)
        Me.txtItmDsc.Name = "txtItmDsc"
        Me.txtItmDsc.Size = New System.Drawing.Size(787, 172)
        Me.txtItmDsc.TabIndex = 376
        Me.txtItmDsc.Text = ""
        '
        'txtMsg
        '
        Me.txtMsg.Enabled = False
        Me.txtMsg.Location = New System.Drawing.Point(110, 471)
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.Size = New System.Drawing.Size(786, 119)
        Me.txtMsg.TabIndex = 377
        Me.txtMsg.Text = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(521, 261)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 12)
        Me.Label5.TabIndex = 389
        Me.Label5.Text = "Item Status"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 263)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 388
        Me.Label6.Text = "Item Type"
        '
        'txtItmSts
        '
        Me.txtItmSts.Enabled = False
        Me.txtItmSts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmSts.Location = New System.Drawing.Point(633, 258)
        Me.txtItmSts.MaxLength = 10
        Me.txtItmSts.Name = "txtItmSts"
        Me.txtItmSts.Size = New System.Drawing.Size(263, 20)
        Me.txtItmSts.TabIndex = 387
        '
        'txtItmTyp
        '
        Me.txtItmTyp.Enabled = False
        Me.txtItmTyp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmTyp.Location = New System.Drawing.Point(110, 259)
        Me.txtItmTyp.MaxLength = 10
        Me.txtItmTyp.Name = "txtItmTyp"
        Me.txtItmTyp.Size = New System.Drawing.Size(283, 20)
        Me.txtItmTyp.TabIndex = 386
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 12)
        Me.Label8.TabIndex = 391
        Me.Label8.Text = "Item Number"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 77)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 12)
        Me.Label9.TabIndex = 392
        Me.Label9.Text = "Item Description"
        '
        'grdItemList
        '
        Me.grdItemList.AllowUserToAddRows = False
        Me.grdItemList.AllowUserToDeleteRows = False
        Me.grdItemList.ColumnHeadersHeight = 20
        Me.grdItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdItemList.Location = New System.Drawing.Point(110, 298)
        Me.grdItemList.Name = "grdItemList"
        Me.grdItemList.RowHeadersWidth = 20
        Me.grdItemList.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdItemList.RowTemplate.Height = 16
        Me.grdItemList.Size = New System.Drawing.Size(786, 118)
        Me.grdItemList.TabIndex = 393
        '
        'optHold
        '
        Me.optHold.AutoSize = True
        Me.optHold.Location = New System.Drawing.Point(110, 445)
        Me.optHold.Name = "optHold"
        Me.optHold.Size = New System.Drawing.Size(46, 16)
        Me.optHold.TabIndex = 394
        Me.optHold.Text = "Hold"
        Me.optHold.UseVisualStyleBackColor = True
        '
        'optRelease
        '
        Me.optRelease.AutoSize = True
        Me.optRelease.Checked = True
        Me.optRelease.Location = New System.Drawing.Point(231, 445)
        Me.optRelease.Name = "optRelease"
        Me.optRelease.Size = New System.Drawing.Size(58, 16)
        Me.optRelease.TabIndex = 395
        Me.optRelease.TabStop = True
        Me.optRelease.Text = "Release"
        Me.optRelease.UseVisualStyleBackColor = True
        '
        'cmdList
        '
        Me.cmdList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdList.Location = New System.Drawing.Point(902, 38)
        Me.cmdList.Name = "cmdList"
        Me.cmdList.Size = New System.Drawing.Size(40, 22)
        Me.cmdList.TabIndex = 396
        Me.cmdList.TabStop = False
        Me.cmdList.Text = "..."
        '
        'menuStrip
        '
        Me.menuStrip.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdAdd, Me.mmdSave, Me.mmdDelete, Me.mmdCopy, Me.mmdFind, Me.t1, Me.mmdClear, Me.t2, Me.mmdSearch, Me.t3, Me.mmdInsRow, Me.mmdDelRow, Me.t4, Me.mmdPrint, Me.t5, Me.mmdAttach, Me.t6, Me.mmdFunction, Me.t7, Me.mmdLink, Me.t8, Me.mmdExit})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuStrip.Size = New System.Drawing.Size(954, 24)
        Me.menuStrip.TabIndex = 534
        Me.menuStrip.Text = "MenuStrip1"
        '
        'mmdAdd
        '
        Me.mmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.mmdAdd.Name = "mmdAdd"
        Me.mmdAdd.Size = New System.Drawing.Size(40, 20)
        Me.mmdAdd.Tag = "Add"
        Me.mmdAdd.Text = "&Add"
        '
        'mmdSave
        '
        Me.mmdSave.Name = "mmdSave"
        Me.mmdSave.Size = New System.Drawing.Size(46, 20)
        Me.mmdSave.Text = "&Save"
        '
        'mmdDelete
        '
        Me.mmdDelete.Name = "mmdDelete"
        Me.mmdDelete.Size = New System.Drawing.Size(55, 20)
        Me.mmdDelete.Text = "&Delete"
        '
        'mmdCopy
        '
        Me.mmdCopy.Name = "mmdCopy"
        Me.mmdCopy.Size = New System.Drawing.Size(47, 20)
        Me.mmdCopy.Text = "&Copy"
        '
        'mmdFind
        '
        Me.mmdFind.Name = "mmdFind"
        Me.mmdFind.Size = New System.Drawing.Size(43, 20)
        Me.mmdFind.Text = "&Find"
        '
        't1
        '
        Me.t1.AutoSize = False
        Me.t1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t1.Enabled = False
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(8, 20)
        Me.t1.Text = "|"
        '
        'mmdClear
        '
        Me.mmdClear.Name = "mmdClear"
        Me.mmdClear.Size = New System.Drawing.Size(49, 20)
        Me.mmdClear.Text = "Cl&ear"
        '
        't2
        '
        Me.t2.AutoSize = False
        Me.t2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t2.Enabled = False
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(8, 20)
        Me.t2.Text = "|"
        '
        'mmdSearch
        '
        Me.mmdSearch.Name = "mmdSearch"
        Me.mmdSearch.Size = New System.Drawing.Size(58, 20)
        Me.mmdSearch.Text = "Searc&h"
        '
        't3
        '
        Me.t3.AutoSize = False
        Me.t3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t3.Enabled = False
        Me.t3.Name = "t3"
        Me.t3.Size = New System.Drawing.Size(8, 20)
        Me.t3.Text = "|"
        '
        'mmdInsRow
        '
        Me.mmdInsRow.Name = "mmdInsRow"
        Me.mmdInsRow.Size = New System.Drawing.Size(64, 20)
        Me.mmdInsRow.Text = "I&ns Row"
        '
        'mmdDelRow
        '
        Me.mmdDelRow.Name = "mmdDelRow"
        Me.mmdDelRow.Size = New System.Drawing.Size(66, 20)
        Me.mmdDelRow.Text = "Del Ro&w"
        '
        't4
        '
        Me.t4.AutoSize = False
        Me.t4.Enabled = False
        Me.t4.Name = "t4"
        Me.t4.Size = New System.Drawing.Size(8, 20)
        Me.t4.Text = "|"
        '
        'mmdPrint
        '
        Me.mmdPrint.Name = "mmdPrint"
        Me.mmdPrint.Size = New System.Drawing.Size(44, 20)
        Me.mmdPrint.Text = "&Print"
        '
        't5
        '
        Me.t5.AutoSize = False
        Me.t5.Enabled = False
        Me.t5.Name = "t5"
        Me.t5.Size = New System.Drawing.Size(8, 20)
        Me.t5.Text = "|"
        '
        'mmdAttach
        '
        Me.mmdAttach.Name = "mmdAttach"
        Me.mmdAttach.Size = New System.Drawing.Size(52, 20)
        Me.mmdAttach.Text = "Attach"
        '
        't6
        '
        Me.t6.AutoSize = False
        Me.t6.Enabled = False
        Me.t6.Name = "t6"
        Me.t6.Size = New System.Drawing.Size(8, 20)
        Me.t6.Text = "|"
        '
        'mmdFunction
        '
        Me.mmdFunction.Name = "mmdFunction"
        Me.mmdFunction.Size = New System.Drawing.Size(66, 20)
        Me.mmdFunction.Text = "Function"
        '
        't7
        '
        Me.t7.AutoSize = False
        Me.t7.Enabled = False
        Me.t7.Name = "t7"
        Me.t7.Size = New System.Drawing.Size(8, 20)
        Me.t7.Text = "|"
        '
        'mmdLink
        '
        Me.mmdLink.Name = "mmdLink"
        Me.mmdLink.Size = New System.Drawing.Size(42, 20)
        Me.mmdLink.Text = "Link"
        '
        't8
        '
        Me.t8.AutoSize = False
        Me.t8.Enabled = False
        Me.t8.Name = "t8"
        Me.t8.Size = New System.Drawing.Size(8, 20)
        Me.t8.Text = "|"
        '
        'mmdExit
        '
        Me.mmdExit.Name = "mmdExit"
        Me.mmdExit.Size = New System.Drawing.Size(38, 20)
        Me.mmdExit.Text = "E&xit"
        '
        'IMM00004
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.cmdList)
        Me.Controls.Add(Me.optHold)
        Me.Controls.Add(Me.optRelease)
        Me.Controls.Add(Me.grdItemList)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtItmSts)
        Me.Controls.Add(Me.txtItmTyp)
        Me.Controls.Add(Me.txtMsg)
        Me.Controls.Add(Me.txtItmDsc)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.txtItmNo)
        Me.Controls.Add(Me.StatusBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "IMM00004"
        Me.Text = "IMM00004 - Hold / Release Item Status (IMM04)"
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Dim EditModeHdr As String

    Dim CanModify As Boolean ' Check for access right

    Dim Current_TimeStamp As Long 'For current record's time stamp

    Dim strStatus As String 'For status of item

    '***********************************************************************
    '*** Define RecordSet variable Here
    Public rs_IMM00004 As DataSet

    '***********************************************************************

    '***********************************************************************
    '*** Define other variable Here

    '***********************************************************************
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean





    Private Sub cmdClear_Click()
        Call setStatus("Init")
        txtItmNo.Focus()
        Call HighlightText(txtItmNo)
    End Sub

    'Private Sub CmdDelete_Click()
    '
    '    Dim reset As Integer
    '
    '    reset = MsgBox("Are you sure to reset Item " & txtItmNo.Text & " ?", vbOKCancel)
    '
    '    If reset = vbOK Then
    '        Call func_ResetItem
    '        Call cmdclear_Click
    '        MsgBox "Item reset"
    '        txtItmNo.SetFocus
    '        Call HighlightText(txtItmNo)
    '    End If
    '
    'End Sub

    Private Sub CmdExit_Click()
        'Unload(Me)
        cmdClear_Click()
        Me.Close()
    End Sub

    Private Sub cmdfirst_Click()
        'Check for the browser list recordset if Bof the this button should be disable
        'Add Code here
        MsgBox("First")
    End Sub

    Private Sub cmdList_Click()
        frmItemList.strItem = txtItmNo.Text
        'frmItemList.Show()
        Call frmItemList.getform("IMM00004")
        frmItemList.ShowDialog()
        txtItmNo.Text = frmItemList.strSel
        'frmItemList.strItem = Me.txtItmNo.Text
        'frmItemList.Show()
        'Me.txtItmNo.Text = frmItemList.strSel
    End Sub

    Private Sub cmdNext_Click()
        'Add Code here
        'Check for the browser list recordset
        MsgBox("Next")
    End Sub

    Private Sub CmdLookup_Click()
        'frmlookup.Show()
    End Sub

    Private Sub cmdFind_Click()

        If Trim(txtItmNo.Text) <> "" Then

            Cursor = Cursors.WaitCursor

            If func_ReadRecordset() = False Then
                Cursor = Cursors.Default
                Exit Sub
            End If

            If rs_IMM00004.Tables("RESULT").Rows.Count > 0 Then

                'Current_TimeStamp = rs_IMM00004.Tables("RESULT").Rows(index)("ibi_timstp")
                Call DisplayDetail()
                'Call SetStatus("Updating")

            Else
                MsgBox("Item not found!")
                txtItmNo.Focus()
                Call HighlightText(txtItmNo)
            End If

            Cursor = Cursors.Default
        Else
            MsgBox("Item Number is blank!")
            txtItmNo.Focus()
            Call HighlightText(txtItmNo)
        End If

    End Sub


    Private Sub CmdSave_Click()
        Dim strAction As String

        strAction = IIf(strStatus = "HLD", "Complete", "Hold")
        If MsgBox("Are you sure to set the following Item(s) to " & strAction & " status?" & vbCrLf & vbCrLf & Replace(Me.txtItmNo.Text, ",", vbCrLf), vbYesNo + vbQuestion + vbDefaultButton1) <> vbYes Then
            Exit Sub
        End If

        If ChecktimeStamp() <> True Then
            MsgBox("The record has been modified by other users, please clear and try again.")
            Exit Sub
        End If

        If func_ResetItem(strAction) = True Then
            MsgBox("Item status updated.")
        End If
        Call cmdClear_Click()
       
        txtItmNo.Focus()
        Call HighlightText(txtItmNo)

    End Sub


    Function ChecktimeStamp() As Boolean
        Dim Save_TimeStamp As Long
        Dim S As String
        ''Dim rs() As DataSet
        Dim rs_IMBASINF As DataSet

        ChecktimeStamp = False

        For index As Integer = 0 To rs_IMM00004.Tables("RESULT").Rows.Count - 1
            S = "sp_select_IMM00004 '','" & Trim(rs_IMM00004.Tables("RESULT").Rows(index)("ibi_itmno")) & "'"
            gspStr = S
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading  sp  :" & rtnStr)
                Exit Function
            Else
                If rs.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("Record not found!")
                    Exit Function
                Else
                    rs_IMBASINF = rs.Copy
                    Save_TimeStamp = rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_timstp")
                    rs_IMBASINF = Nothing

                End If
            End If

            'Write your code for Compare
            If rs_IMM00004.Tables("RESULT").Rows(index)("ibi_timstp") <> Save_TimeStamp Then
                ChecktimeStamp = False
            Else
                ChecktimeStamp = True
            End If

        Next
    End Function

    Private Sub cmdspecial_Click()
        'COR00002.TableName = "CUSITMSUM"
        'COR00002.Show()
    End Sub

    Private Sub Form_Load()

        AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        Dim v

        '#If useMTS Then
        '    Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If

        Cursor = Cursors.WaitCursor


        '****************************************************************
        '*** Fill Combo box Start ***************************************
        '****************************************************************

        '**************************************************************
        '*** Fill Combo box End ***************************************
        '**************************************************************

        '**************************************************************
        '*** Fill List box      ***************************************
        '**************************************************************

        '**************************************************************
        '*** Fill List box END  ***************************************
        '**************************************************************


        '***Get the Current User's access right form the DB
        '    If (DB Value = CanModify) Then  'Get the Value from Database
        CanModify = True
        '    Else
        '        CanModify = False
        '    End If

        Me.KeyPreview = True

        Call setStatus("Init")

        Call Formstartup(Me.Name)   'Set the form Sartup position

        Cursor = Cursors.Default
    End Sub



    Private Sub Form_Unload(ByVal Cancel As Integer)
        '  'Unload(Me)
    End Sub

    Private Sub setStatus(ByVal Mode As String)

        If Mode = "Init" Then
            'DoEvents()
            'DoEvents()
            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = True
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdExit.Enabled = True
            mmdClear.Enabled = False
            mmdSearch.Enabled = False
            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False
            cmdList.Enabled = True
            mmdAdd.Enabled = False

            txtItmNo.Enabled = True

            Me.optHold.Enabled = False
            Me.optRelease.Enabled = False
            '            Me.cmdList.Enabled = True
            If Not grdItemList.DataSource Is Nothing Then
                grdItemList.DataSource = Nothing
            End If

            Call DisplayInit()

            'DoEvents()

        ElseIf Mode = "Updating" Then
            'DoEvents()
            'DoEvents()
            mmdAdd.Enabled = False
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdExit.Enabled = True
            mmdClear.Enabled = True
            mmdSearch.Enabled = False
            cmdList.Enabled = False
            mmdAdd.Enabled = False

            txtItmNo.Enabled = False
            'Me.cmdList.Enabled = False
            'DoEvents()
        End If

    End Sub

    Private Sub SetStatusBar(ByVal Mode As String)

        If Mode = "Init" Then
            StatusBar.Panels(1).Text = "Init"
            'Add your codes here

        ElseIf Mode = "ADD" Then
            StatusBar.Panels(1).Text = "ADD"
            'Add your codes here

        ElseIf Mode = "Updating" Then
            StatusBar.Panels(1).Text = "Updating"
            'Add your codes here

        ElseIf Mode = "Save" Then
            StatusBar.Panels(1).Text = "Record Saved"
            'Add your codes here

        ElseIf Mode = "Delete" Then
            StatusBar.Panels(1).Text = "Record Deleted"
            'Add your codes here

        ElseIf Mode = "ReadOnly" Then
            StatusBar.Panels(1).Text = "Read Only"
            'Add your codes here

        ElseIf Mode = "Clear" Then
            StatusBar.Panels(1).Text = "Clear Screen"
            'Add your codes here
        End If
    End Sub




    Private Function func_ReadRecordset() As Boolean
        ''Dim rs() As DataSet
        Dim S As String
        Dim i As Integer
        func_ReadRecordset = False
        S = "sp_select_IMM00004    '','" & txtItmNo.Text & "'"

        Cursor = Cursors.WaitCursor

        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_IMM00004, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_IMM00004      :" & rtnStr)
            Exit Function
        Else
        End If

        Cursor = Cursors.Default

        func_ReadRecordset = True
    End Function


    Private Function DisplayInit()

        '    txtLneCde.Text = ""
        '    txtCatLvl0.Text = ""
        '    txtCatLvl1.Text = ""
        '    txtCatLvl2.Text = ""
        '    txtCatLvl3.Text = ""
        '    txtCatLvl4.Text = ""
        txtItmSts.Text = ""
        txtItmTyp.Text = ""
        txtItmDsc.Text = ""

    End Function


    Private Function DisplayDetail()
        Dim strItmsts As String
        Dim bolSave As Boolean
        Dim itmList As String

        If rs_IMM00004.Tables("RESULT").Rows.Count > 0 Then
            For index As Integer = 0 To rs_IMM00004.Tables("RESULT").Rows.Count - 1

                strItmsts = rs_IMM00004.Tables("RESULT").Rows(index)("ibi_itmsts")

                If InStr(strItmsts, "-") > 0 Then
                    strStatus = Trim(Split(strItmsts, "-")(0))

                    If strStatus = "HLD" Then
                        optRelease.Enabled = True
                        optRelease.Checked = True
                    ElseIf strStatus = "CMP" Then
                        optHold.Enabled = True
                        optHold.Checked = True
                    Else

                        '                        rs_IMM00004.MoveFirst()

                        itmList = ""
                        For index2 As Integer = 0 To rs_IMM00004.Tables("RESULT").Rows.Count - 1
                            itmList = itmList & vbCrLf & rs_IMM00004.Tables("RESULT").Rows(index2)("ibi_itmsts")
                        Next

                        MsgBox("The following Item(s) status is not Complete / Hold !" & itmList)
                        Call cmdClear_Click()
                        Exit Function
                    End If
                Else
                    MsgBox("Item status is not valid!")
                    Call cmdClear_Click()
                    Exit Function
                End If

                Me.grdItemList.DataSource = rs_IMM00004.Tables("RESULT")

                txtItmSts.Text = rs_IMM00004.Tables("RESULT").Rows(index)("ibi_itmsts")
                txtItmTyp.Text = rs_IMM00004.Tables("RESULT").Rows(index)("ibi_typ")
                txtItmDsc.Text = rs_IMM00004.Tables("RESULT").Rows(index)("ibi_engdsc")
                Current_TimeStamp = rs_IMM00004.Tables("RESULT").Rows(index)("ibi_timstp")

                Dim col As Integer

                col = 0
                Me.grdItemList.Columns(col).Width = 0
                Me.grdItemList.Columns(col).Visible = False

                col = col + 1
                Me.grdItemList.Columns(col).HeaderText = "Item No"
                Me.grdItemList.Columns(col).Width = 1500 / 13

                col = col + 1
                Me.grdItemList.Columns(col).Width = 0
                Me.grdItemList.Columns(col).Visible = False

                col = col + 1
                Me.grdItemList.Columns(col).Width = 0
                Me.grdItemList.Columns(col).Visible = False

                col = col + 1
                Me.grdItemList.Columns(col).Width = 0
                Me.grdItemList.Columns(col).Visible = False

                col = col + 1
                Me.grdItemList.Columns(col).Width = 0
                Me.grdItemList.Columns(col).Visible = False

                col = col + 1
                Me.grdItemList.Columns(col).Width = 0
                Me.grdItemList.Columns(col).Visible = False

                col = col + 1
                Me.grdItemList.Columns(col).HeaderText = "Category"
                Me.grdItemList.Columns(col).Width = 1200 / 13

                col = col + 1
                Me.grdItemList.Columns(col).HeaderText = "Item Status"
                Me.grdItemList.Columns(col).Width = 3000 / 13

                col = col + 1
                Me.grdItemList.Columns(col).HeaderText = "Item Type"
                Me.grdItemList.Columns(col).Width = 1200 / 13

                col = col + 1
                Me.grdItemList.Columns(col).HeaderText = "Eng. Desc"
                Me.grdItemList.Columns(col).Width = 3000 / 13

                col = col + 1
                Me.grdItemList.Columns(col).Width = 0
                Me.grdItemList.Columns(col).Visible = False

                strItmsts = rs_IMM00004.Tables("RESULT").Rows(index)("ibi_itmsts")
                bolSave = True
                For index3 As Integer = 0 To rs_IMM00004.Tables("RESULT").Rows.Count - 1
                    If rs_IMM00004.Tables("RESULT").Rows(index3)("ibi_itmsts") <> strItmsts Then
                        itmList = itmList & vbCrLf & " - " & rs_IMM00004.Tables("RESULT").Rows(index3)("ibi_itmno")
                        bolSave = False
                    End If
                Next

                ' index = 0

                'tempzzzzzzzzzzz
                '                rs_IMM00004.MoveFirst()
                If Len(itmList) > 0 Then
                    MsgBox("The following item(s) is/are not in " & strItmsts & itmList)
                End If
                Call setStatus("Updating")

                mmdSave.Enabled = False
                If bolSave Then mmdSave.Enabled = True

            Next
        End If


    End Function


    Private Function func_ResetItem(ByVal strAction As String) As Boolean

        ''Dim rs() As DataSet
        Dim S As String

        func_ResetItem = False

        strAction = IIf(strAction = "Complete", "CMP", "HLD")
        For index As Integer = 0 To rs_IMM00004.Tables("RESULT").Rows.Count - 1

            S = "sp_update_IMM00004  '','" & rs_IMM00004.Tables("RESULT").Rows(index)("ibi_itmno") & "','" & strAction & "','" & gsUsrID & "'"
            Cursor = Cursors.WaitCursor
            gspStr = S
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading  sp  :" & rtnStr)
                Exit Function
            Else
            End If
        Next
        Cursor = Cursors.Default

        func_ResetItem = True

    End Function


    Private Sub grdItemList_RowColChange(ByVal LastRow As Object, ByVal LastCol As Integer)
        'If rs_IMM00004 Is Nothing Then Exit Sub
        'If rs_IMM00004.Tables("RESULT").Rows.Count <= 0 Then Exit Sub
        'If rs_IMM00004.BOF Or rs_IMM00004.EOF Then Exit Sub

        'txtItmSts.Text = rs_IMM00004.Tables("RESULT").Rows(index)("ibi_itmsts")
        'txtItmTyp.Text = rs_IMM00004.Tables("RESULT").Rows(index)("ibi_typ")
        'txtItmDsc.Text = rs_IMM00004.Tables("RESULT").Rows(index)("ibi_engdsc")
        'Current_TimeStamp = rs_IMM00004.Tables("RESULT").Rows(index)("ibi_timstp")


    End Sub


    Private Sub txtItmNo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        If KeyCode = 13 Then
            Call cmdFind_Click()
        End If
    End Sub


    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        Call CmdSave_Click()

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        Call cmdClear_Click()

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        Call CmdExit_Click()

    End Sub

    Private Sub cmdFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call cmdFind_Click()

    End Sub

    Private Sub IMM00004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Form_Load()
    End Sub

    Private Sub grdItemList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdItemList.CellContentClick

    End Sub

    Private Sub grdItemList_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdItemList.CurrentCellChanged
        If grdItemList.CurrentCell Is Nothing Then
            Exit Sub
        End If

        If rs_IMM00004 Is Nothing Then Exit Sub
        If rs_IMM00004.Tables("RESULT") Is Nothing Then Exit Sub
        If rs_IMM00004.Tables("RESULT").Rows.Count <= 0 Then Exit Sub
        '        If rs_IMM00004.BOF Or rs_IMM00004.EOF Then Exit Sub
        Dim index As Integer
        index = grdItemList.CurrentCell.RowIndex
        txtItmSts.Text = rs_IMM00004.Tables("RESULT").Rows(index)("ibi_itmsts")
        txtItmTyp.Text = rs_IMM00004.Tables("RESULT").Rows(index)("ibi_typ")
        txtItmDsc.Text = rs_IMM00004.Tables("RESULT").Rows(index)("ibi_engdsc")
        Current_TimeStamp = rs_IMM00004.Tables("RESULT").Rows(index)("ibi_timstp")



    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click
        Call cmdFind_Click()

    End Sub

    Private Sub cmdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdList.Click
        Call cmdList_Click()


    End Sub
    Public Function settxtItemList(ByVal strA As String)
        Me.txtItmNo.Text = strA
        'Me.Show()
        'Me.Refresh()


    End Function

    Private Sub txtItmNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItmNo.KeyPress

        If e.KeyChar = Chr(13) And mmdFind.Enabled = True Then
            'txtQutNo.Text = UCase(Trim(txtQutNo.Text))
            'Call txtQutNoKeyPress()
            Call cmdFind_Click()
        End If
    End Sub

    Public Sub callByIMM01(ByVal ItmNo As String, ByVal formnameA As String)

        txtItmNo.Text = ItmNo
        AddHandler Me.Shown, AddressOf callByIMM01AfterLoading
        Me.ShowDialog()

    End Sub


    Private Sub callByIMM01AfterLoading()
        cmdFind_Click()
        txtItmNo.Enabled = False
        cmdList.Enabled = False
        mmdClear.Enabled = False
        RemoveHandler Me.Shown, AddressOf callByIMM01AfterLoading
        'RemoveHandler Me.mmdClear.Click, AddressOf cmdClear_Click
        AddHandler Me.mmdSave.Click, AddressOf callByIMM01KeepTheItemAfterSave
    End Sub


    Private Sub callByIMM01KeepTheItemAfterSave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cmdFind_Click()
        mmdClear.Enabled = False
    End Sub
End Class

