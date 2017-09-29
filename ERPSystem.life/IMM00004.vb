Public Class IMM00004

    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code"
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents cmdspecial As System.Windows.Forms.Button
    Friend WithEvents cmdbrowlist As System.Windows.Forms.Button
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
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdLast As System.Windows.Forms.Button
    Friend WithEvents cmdPrv As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdDelRow As System.Windows.Forms.Button
    Friend WithEvents cmdFirst As System.Windows.Forms.Button
    Friend WithEvents cmdInsRow As System.Windows.Forms.Button
    Friend WithEvents CmdLookup As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdLast = New System.Windows.Forms.Button
        Me.cmdPrv = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdFind = New System.Windows.Forms.Button
        Me.cmdCopy = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdDelRow = New System.Windows.Forms.Button
        Me.cmdFirst = New System.Windows.Forms.Button
        Me.cmdInsRow = New System.Windows.Forms.Button
        Me.CmdLookup = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.cmdspecial = New System.Windows.Forms.Button
        Me.cmdbrowlist = New System.Windows.Forms.Button
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
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdDelete
        '
        Me.cmdDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdDelete.Location = New System.Drawing.Point(106, 0)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(54, 34)
        Me.cmdDelete.TabIndex = 2
        Me.cmdDelete.TabStop = False
        Me.cmdDelete.Text = "&Delete"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdSave.Location = New System.Drawing.Point(53, 0)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(54, 34)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.TabStop = False
        Me.cmdSave.Text = "&Save"
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdAdd.Location = New System.Drawing.Point(0, 0)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(54, 34)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.TabStop = False
        Me.cmdAdd.Text = "&Add"
        '
        'cmdLast
        '
        Me.cmdLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdLast.Location = New System.Drawing.Point(785, 0)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(38, 34)
        Me.cmdLast.TabIndex = 13
        Me.cmdLast.TabStop = False
        Me.cmdLast.Text = ">>|"
        '
        'cmdPrv
        '
        Me.cmdPrv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdPrv.Location = New System.Drawing.Point(711, 0)
        Me.cmdPrv.Name = "cmdPrv"
        Me.cmdPrv.Size = New System.Drawing.Size(38, 34)
        Me.cmdPrv.TabIndex = 11
        Me.cmdPrv.TabStop = False
        Me.cmdPrv.Text = "<"
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdNext.Location = New System.Drawing.Point(748, 0)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(38, 34)
        Me.cmdNext.TabIndex = 12
        Me.cmdNext.TabStop = False
        Me.cmdNext.Text = ">"
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdFind.Location = New System.Drawing.Point(206, 0)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(54, 34)
        Me.cmdFind.TabIndex = 4
        Me.cmdFind.TabStop = False
        Me.cmdFind.Text = "&Find"
        '
        'cmdCopy
        '
        Me.cmdCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdCopy.Location = New System.Drawing.Point(159, 0)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(48, 34)
        Me.cmdCopy.TabIndex = 3
        Me.cmdCopy.TabStop = False
        Me.cmdCopy.Text = "&Copy"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdClear.Location = New System.Drawing.Point(259, 0)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(53, 34)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.TabStop = False
        Me.cmdClear.Text = "Cl&ear"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdExit.Location = New System.Drawing.Point(829, 0)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(54, 34)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.TabStop = False
        Me.cmdExit.Text = "E&xit"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdDelRow.Location = New System.Drawing.Point(610, 0)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(53, 34)
        Me.cmdDelRow.TabIndex = 9
        Me.cmdDelRow.TabStop = False
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdFirst
        '
        Me.cmdFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdFirst.Location = New System.Drawing.Point(674, 0)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(38, 34)
        Me.cmdFirst.TabIndex = 10
        Me.cmdFirst.TabStop = False
        Me.cmdFirst.Text = "|<<"
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdInsRow.Location = New System.Drawing.Point(557, 0)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(54, 34)
        Me.cmdInsRow.TabIndex = 7
        Me.cmdInsRow.TabStop = False
        Me.cmdInsRow.Text = "I&ns Row"
        '
        'CmdLookup
        '
        Me.CmdLookup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CmdLookup.Location = New System.Drawing.Point(444, 0)
        Me.CmdLookup.Name = "CmdLookup"
        Me.CmdLookup.Size = New System.Drawing.Size(54, 34)
        Me.CmdLookup.TabIndex = 8
        Me.CmdLookup.TabStop = False
        Me.CmdLookup.Text = "Look &up"
        Me.CmdLookup.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdSearch.Location = New System.Drawing.Point(321, 0)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(61, 34)
        Me.cmdSearch.TabIndex = 6
        Me.cmdSearch.TabStop = False
        Me.cmdSearch.Text = "Searc&h"
        '
        'cmdspecial
        '
        Me.cmdspecial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdspecial.Location = New System.Drawing.Point(381, 0)
        Me.cmdspecial.Name = "cmdspecial"
        Me.cmdspecial.Size = New System.Drawing.Size(64, 34)
        Me.cmdspecial.TabIndex = 49
        Me.cmdspecial.TabStop = False
        Me.cmdspecial.Text = "S&pecial Search"
        '
        'cmdbrowlist
        '
        Me.cmdbrowlist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdbrowlist.Location = New System.Drawing.Point(497, 0)
        Me.cmdbrowlist.Name = "cmdbrowlist"
        Me.cmdbrowlist.Size = New System.Drawing.Size(52, 34)
        Me.cmdbrowlist.TabIndex = 50
        Me.cmdbrowlist.TabStop = False
        Me.cmdbrowlist.Text = "&Browse List"
        Me.cmdbrowlist.UseVisualStyleBackColor = True
        '
        'StatusBar
        '
        Me.StatusBar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusBar.Location = New System.Drawing.Point(0, 380)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2})
        Me.StatusBar.ShowPanels = True
        Me.StatusBar.Size = New System.Drawing.Size(883, 26)
        Me.StatusBar.TabIndex = 276
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 433
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel2.Name = "StatusBarPanel2"
        Me.StatusBarPanel2.Width = 433
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
        Me.txtItmNo.Location = New System.Drawing.Point(185, 39)
        Me.txtItmNo.MaxLength = 3000
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(538, 20)
        Me.txtItmNo.TabIndex = 1
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label33.Location = New System.Drawing.Point(59, 279)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(37, 13)
        Me.Label33.TabIndex = 296
        Me.Label33.Text = "Action"
        '
        'txtItmDsc
        '
        Me.txtItmDsc.Enabled = False
        Me.txtItmDsc.Location = New System.Drawing.Point(185, 62)
        Me.txtItmDsc.Name = "txtItmDsc"
        Me.txtItmDsc.Size = New System.Drawing.Size(538, 43)
        Me.txtItmDsc.TabIndex = 376
        Me.txtItmDsc.Text = ""
        '
        'txtMsg
        '
        Me.txtMsg.Enabled = False
        Me.txtMsg.Location = New System.Drawing.Point(185, 295)
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.Size = New System.Drawing.Size(538, 62)
        Me.txtMsg.TabIndex = 377
        Me.txtMsg.Text = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(434, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 389
        Me.Label5.Text = "Item Status"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(59, 111)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 388
        Me.Label6.Text = "Item Type"
        '
        'txtItmSts
        '
        Me.txtItmSts.Enabled = False
        Me.txtItmSts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmSts.Location = New System.Drawing.Point(507, 109)
        Me.txtItmSts.MaxLength = 10
        Me.txtItmSts.Name = "txtItmSts"
        Me.txtItmSts.Size = New System.Drawing.Size(205, 20)
        Me.txtItmSts.TabIndex = 387
        '
        'txtItmTyp
        '
        Me.txtItmTyp.Enabled = False
        Me.txtItmTyp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmTyp.Location = New System.Drawing.Point(185, 109)
        Me.txtItmTyp.MaxLength = 10
        Me.txtItmTyp.Name = "txtItmTyp"
        Me.txtItmTyp.Size = New System.Drawing.Size(219, 20)
        Me.txtItmTyp.TabIndex = 386
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label8.Location = New System.Drawing.Point(59, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 391
        Me.Label8.Text = "Item Number"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label9.Location = New System.Drawing.Point(59, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 13)
        Me.Label9.TabIndex = 392
        Me.Label9.Text = "Item Description"
        '
        'grdItemList
        '
        Me.grdItemList.AllowUserToAddRows = False
        Me.grdItemList.AllowUserToDeleteRows = False
        Me.grdItemList.ColumnHeadersHeight = 20
        Me.grdItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdItemList.Location = New System.Drawing.Point(185, 135)
        Me.grdItemList.Name = "grdItemList"
        Me.grdItemList.RowHeadersWidth = 20
        Me.grdItemList.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdItemList.RowTemplate.Height = 16
        Me.grdItemList.Size = New System.Drawing.Size(538, 118)
        Me.grdItemList.TabIndex = 393
        '
        'optHold
        '
        Me.optHold.AutoSize = True
        Me.optHold.Location = New System.Drawing.Point(185, 270)
        Me.optHold.Name = "optHold"
        Me.optHold.Size = New System.Drawing.Size(49, 19)
        Me.optHold.TabIndex = 394
        Me.optHold.Text = "Hold"
        Me.optHold.UseVisualStyleBackColor = True
        '
        'optRelease
        '
        Me.optRelease.AutoSize = True
        Me.optRelease.Checked = True
        Me.optRelease.Location = New System.Drawing.Point(306, 270)
        Me.optRelease.Name = "optRelease"
        Me.optRelease.Size = New System.Drawing.Size(61, 19)
        Me.optRelease.TabIndex = 395
        Me.optRelease.TabStop = True
        Me.optRelease.Text = "Release"
        Me.optRelease.UseVisualStyleBackColor = True
        '
        'cmdList
        '
        Me.cmdList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdList.Location = New System.Drawing.Point(729, 39)
        Me.cmdList.Name = "cmdList"
        Me.cmdList.Size = New System.Drawing.Size(40, 22)
        Me.cmdList.TabIndex = 396
        Me.cmdList.TabStop = False
        Me.cmdList.Text = "..."
        '
        'IMM00004
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(883, 406)
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
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdbrowlist)
        Me.Controls.Add(Me.cmdspecial)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.CmdLookup)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.cmdLast)
        Me.Controls.Add(Me.cmdPrv)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdFirst)
        Me.Controls.Add(Me.cmdDelRow)
        Me.Controls.Add(Me.cmdInsRow)
        Me.Controls.Add(Me.cmdSearch)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "IMM00004"
        Me.Text = "IMM00004 - Hold / Release Item Status"
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemList, System.ComponentModel.ISupportInitialize).EndInit()
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

    'Private Sub DefinedKey(ByVal KeyCode As Integer)

    '    If (KeyCode = vbKeyF3) And (cmdClear.Enabled = True) Then
    '        Call cmdClear_Click()     'Hot Key for Clear (F3)

    '    ElseIf (KeyCode = vbKeyF5) And (cmdFirst.Enabled = True) Then
    '        'Call cmdfirst_Click     'Hot Key for Move First (F5)

    '    ElseIf (KeyCode = vbKeyF6) And (cmdPrv.Enabled = True) Then
    '        'Call cmdPrv_Click       'Hot Key for Move Previous (F6)

    '    ElseIf (KeyCode = vbKeyF7) And (cmdNext.Enabled = True) Then
    '        'Call cmdNext_Click      'Hot Key for Move Next (F7)

    '    ElseIf (KeyCode = vbKeyF8) And (cmdLast.Enabled = True) Then
    '        'Call cmdlast_Click      'Hot Key for Move Last (F8)
    '    End If
    'End Sub
    'tempz

    Private Sub Form_Unload(ByVal Cancel As Integer)
        '  'Unload(Me)
    End Sub

    Private Sub setStatus(ByVal Mode As String)

        If Mode = "Init" Then
            'DoEvents()
            'DoEvents()
            cmdAdd.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = True
            CmdLookup.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdExit.Enabled = True
            cmdClear.Enabled = False
            cmdSearch.Enabled = False
            cmdspecial.Enabled = False
            cmdbrowlist.Enabled = False

            cmdAdd.Enabled = False
            cmdFirst.Enabled = False
            cmdLast.Enabled = False
            cmdNext.Enabled = False
            cmdPrv.Enabled = False

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
            cmdAdd.Enabled = False
            '        CmdSave.Enabled = True
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            CmdLookup.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdExit.Enabled = True
            cmdClear.Enabled = True
            cmdSearch.Enabled = False
            cmdspecial.Enabled = False
            cmdbrowlist.Enabled = False

            cmdAdd.Enabled = False
            cmdFirst.Enabled = False
            cmdLast.Enabled = False
            cmdNext.Enabled = False
            cmdPrv.Enabled = False

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
                Me.grdItemList.Columns(col).HeaderText = "Item #"
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

                cmdSave.Enabled = False
                If bolSave Then cmdSave.Enabled = True

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


    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Call CmdSave_Click()

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Call cmdClear_Click()

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Call CmdExit_Click()

    End Sub

    Private Sub cmdFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFirst.Click
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

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
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

End Class














































































