Public Class MIM00001

    Inherits System.Windows.Forms.Form

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    '    Dim objBSGate As Object    '*** an object of "ucpBS_Gate.clsBSGate"

    Dim EditModeHdr As String

    Dim CanModify As Boolean ' Check for access right
    Dim save_ok As Boolean
    Dim dup(50) As String

    Dim Current_TimeStamp As Long 'For current record's time stamp

    Public rs_ZSITMLST As DataSet
    Public rs_ZSITMLST_check As DataSet

    Public rs_L0 As DataSet
    Public rs_L1 As DataSet
    Public rs_L2 As DataSet
    Public rs_L3 As DataSet
    Public rs_L4 As DataSet

    Dim Add_flag As Boolean '***Check for Add Record

    Dim Recordstatus As Boolean '***Check the Current record is modified or not
    '***This flag must used in each fields of the Scree
    Dim readingindex As Integer

    Public Save_flag As Boolean '****Reject enter to RowColchange event


#Region " Windows Form Designer generated code"
    Friend WithEvents txtItmFm As System.Windows.Forms.TextBox
    Friend WithEvents StatusBar As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents RichTextBox3 As System.Windows.Forms.RichTextBox
    Friend WithEvents gbRelation As System.Windows.Forms.GroupBox
    Friend WithEvents GrdCatRel As System.Windows.Forms.DataGridView
    Friend WithEvents txtItmTo As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents LstCUR As System.Windows.Forms.ListBox
    Friend WithEvents LstCUSTUM As System.Windows.Forms.ListBox
    Friend WithEvents LstUM As System.Windows.Forms.ListBox
    Friend WithEvents Lstlvl0 As System.Windows.Forms.ListBox
    Friend WithEvents Lstlvl1 As System.Windows.Forms.ListBox
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
    Friend WithEvents mmdRel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdApv As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdLink As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MIM00001))
        Me.txtItmFm = New System.Windows.Forms.TextBox
        Me.StatusBar = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.ComboBox6 = New System.Windows.Forms.ComboBox
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox
        Me.gbRelation = New System.Windows.Forms.GroupBox
        Me.LstCUR = New System.Windows.Forms.ListBox
        Me.LstCUSTUM = New System.Windows.Forms.ListBox
        Me.LstUM = New System.Windows.Forms.ListBox
        Me.Lstlvl0 = New System.Windows.Forms.ListBox
        Me.Lstlvl1 = New System.Windows.Forms.ListBox
        Me.GrdCatRel = New System.Windows.Forms.DataGridView
        Me.txtItmTo = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
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
        Me.mmdRel = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdApv = New System.Windows.Forms.ToolStripMenuItem
        Me.t7 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdLink = New System.Windows.Forms.ToolStripMenuItem
        Me.t8 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdExit = New System.Windows.Forms.ToolStripMenuItem
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRelation.SuspendLayout()
        CType(Me.GrdCatRel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtItmFm
        '
        Me.txtItmFm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmFm.Location = New System.Drawing.Point(99, 30)
        Me.txtItmFm.MaxLength = 10
        Me.txtItmFm.Name = "txtItmFm"
        Me.txtItmFm.Size = New System.Drawing.Size(119, 20)
        Me.txtItmFm.TabIndex = 0
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
        'gbRelation
        '
        Me.gbRelation.Controls.Add(Me.LstCUR)
        Me.gbRelation.Controls.Add(Me.LstCUSTUM)
        Me.gbRelation.Controls.Add(Me.LstUM)
        Me.gbRelation.Controls.Add(Me.Lstlvl0)
        Me.gbRelation.Controls.Add(Me.Lstlvl1)
        Me.gbRelation.Controls.Add(Me.GrdCatRel)
        Me.gbRelation.Location = New System.Drawing.Point(0, 53)
        Me.gbRelation.Name = "gbRelation"
        Me.gbRelation.Size = New System.Drawing.Size(954, 546)
        Me.gbRelation.TabIndex = 283
        Me.gbRelation.TabStop = False
        '
        'LstCUR
        '
        Me.LstCUR.FormattingEnabled = True
        Me.LstCUR.ItemHeight = 12
        Me.LstCUR.Location = New System.Drawing.Point(466, 80)
        Me.LstCUR.Name = "LstCUR"
        Me.LstCUR.Size = New System.Drawing.Size(59, 28)
        Me.LstCUR.TabIndex = 373
        '
        'LstCUSTUM
        '
        Me.LstCUSTUM.FormattingEnabled = True
        Me.LstCUSTUM.ItemHeight = 12
        Me.LstCUSTUM.Location = New System.Drawing.Point(466, 41)
        Me.LstCUSTUM.Name = "LstCUSTUM"
        Me.LstCUSTUM.Size = New System.Drawing.Size(76, 28)
        Me.LstCUSTUM.TabIndex = 372
        '
        'LstUM
        '
        Me.LstUM.FormattingEnabled = True
        Me.LstUM.ItemHeight = 12
        Me.LstUM.Location = New System.Drawing.Point(363, 41)
        Me.LstUM.Name = "LstUM"
        Me.LstUM.Size = New System.Drawing.Size(86, 124)
        Me.LstUM.TabIndex = 371
        '
        'Lstlvl0
        '
        Me.Lstlvl0.FormattingEnabled = True
        Me.Lstlvl0.ItemHeight = 12
        Me.Lstlvl0.Location = New System.Drawing.Point(55, 156)
        Me.Lstlvl0.Name = "Lstlvl0"
        Me.Lstlvl0.Size = New System.Drawing.Size(292, 100)
        Me.Lstlvl0.TabIndex = 370
        '
        'Lstlvl1
        '
        Me.Lstlvl1.FormattingEnabled = True
        Me.Lstlvl1.ItemHeight = 12
        Me.Lstlvl1.Location = New System.Drawing.Point(55, 41)
        Me.Lstlvl1.Name = "Lstlvl1"
        Me.Lstlvl1.Size = New System.Drawing.Size(292, 100)
        Me.Lstlvl1.TabIndex = 369
        '
        'GrdCatRel
        '
        Me.GrdCatRel.AllowUserToAddRows = False
        Me.GrdCatRel.AllowUserToDeleteRows = False
        Me.GrdCatRel.ColumnHeadersHeight = 20
        Me.GrdCatRel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GrdCatRel.Location = New System.Drawing.Point(6, 13)
        Me.GrdCatRel.Name = "GrdCatRel"
        Me.GrdCatRel.RowHeadersWidth = 20
        Me.GrdCatRel.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdCatRel.RowTemplate.Height = 16
        Me.GrdCatRel.Size = New System.Drawing.Size(942, 527)
        Me.GrdCatRel.TabIndex = 368
        '
        'txtItmTo
        '
        Me.txtItmTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmTo.Location = New System.Drawing.Point(250, 30)
        Me.txtItmTo.MaxLength = 10
        Me.txtItmTo.Name = "txtItmTo"
        Me.txtItmTo.Size = New System.Drawing.Size(119, 20)
        Me.txtItmTo.TabIndex = 1
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(224, 33)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(18, 12)
        Me.Label33.TabIndex = 296
        Me.Label33.Text = "To"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label25.Location = New System.Drawing.Point(11, 33)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(46, 12)
        Me.Label25.TabIndex = 295
        Me.Label25.Text = "Item No."
        '
        'menuStrip
        '
        Me.menuStrip.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdAdd, Me.mmdSave, Me.mmdDelete, Me.mmdCopy, Me.mmdFind, Me.t1, Me.mmdClear, Me.t2, Me.mmdSearch, Me.t3, Me.mmdInsRow, Me.mmdDelRow, Me.t4, Me.mmdPrint, Me.t5, Me.mmdAttach, Me.t6, Me.mmdFunction, Me.t7, Me.mmdLink, Me.t8, Me.mmdExit})
        Me.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuStrip.Size = New System.Drawing.Size(954, 24)
        Me.menuStrip.TabIndex = 297
        Me.menuStrip.Text = "MenuStrip1"
        '
        'mmdAdd
        '
        Me.mmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.mmdAdd.Name = "mmdAdd"
        Me.mmdAdd.Size = New System.Drawing.Size(40, 19)
        Me.mmdAdd.Tag = "Add"
        Me.mmdAdd.Text = "&Add"
        '
        'mmdSave
        '
        Me.mmdSave.Name = "mmdSave"
        Me.mmdSave.Size = New System.Drawing.Size(46, 19)
        Me.mmdSave.Text = "&Save"
        '
        'mmdDelete
        '
        Me.mmdDelete.Name = "mmdDelete"
        Me.mmdDelete.Size = New System.Drawing.Size(55, 19)
        Me.mmdDelete.Text = "&Delete"
        '
        'mmdCopy
        '
        Me.mmdCopy.Name = "mmdCopy"
        Me.mmdCopy.Size = New System.Drawing.Size(47, 19)
        Me.mmdCopy.Text = "&Copy"
        '
        'mmdFind
        '
        Me.mmdFind.Name = "mmdFind"
        Me.mmdFind.Size = New System.Drawing.Size(43, 19)
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
        Me.mmdClear.Size = New System.Drawing.Size(49, 19)
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
        Me.mmdSearch.Size = New System.Drawing.Size(58, 19)
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
        Me.mmdInsRow.Size = New System.Drawing.Size(64, 19)
        Me.mmdInsRow.Text = "I&ns Row"
        '
        'mmdDelRow
        '
        Me.mmdDelRow.Name = "mmdDelRow"
        Me.mmdDelRow.Size = New System.Drawing.Size(66, 19)
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
        Me.mmdPrint.Size = New System.Drawing.Size(44, 19)
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
        Me.mmdAttach.Size = New System.Drawing.Size(52, 19)
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
        Me.mmdFunction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdRel, Me.mmdApv})
        Me.mmdFunction.Name = "mmdFunction"
        Me.mmdFunction.Size = New System.Drawing.Size(66, 19)
        Me.mmdFunction.Text = "Function"
        '
        'mmdRel
        '
        Me.mmdRel.Name = "mmdRel"
        Me.mmdRel.Size = New System.Drawing.Size(121, 22)
        Me.mmdRel.Text = "Release"
        '
        'mmdApv
        '
        Me.mmdApv.Name = "mmdApv"
        Me.mmdApv.Size = New System.Drawing.Size(121, 22)
        Me.mmdApv.Text = "Approval"
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
        Me.mmdLink.Size = New System.Drawing.Size(42, 19)
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
        Me.mmdExit.Size = New System.Drawing.Size(38, 19)
        Me.mmdExit.Text = "E&xit"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(63, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 12)
        Me.Label1.TabIndex = 298
        Me.Label1.Text = "From"
        '
        'MIM00001
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txtItmTo)
        Me.Controls.Add(Me.gbRelation)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.txtItmFm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MIM00001"
        Me.Text = "MIM00001 - WT Factory Item Master (MIM01)"
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRelation.ResumeLayout(False)
        CType(Me.GrdCatRel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region




    Private Sub cmdClear_Click()
        Dim YNC, book As Integer
        If rs_ZSITMLST.Tables("RESULT").Rows.Count > 0 Then

            '            book = rs_ZSITMLST.AbsolutePosition
            rs_ZSITMLST.Tables("result").DefaultView.RowFilter = "zil_creusr = " & "'" & "~*ADD*~" & "'" & _
                                      "or zil_creusr = " & "'" & "~*UPD*~" & "'" & _
                                      "or zil_creusr = " & "'" & "~*DEL*~" & "'" & _
                                      "or zil_creusr = " & "'" & "~*NEW*~" & "'"
            If rs_ZSITMLST.Tables("RESULT").DefaultView.Count = 0 Then
                Call setStatus("init")
                Call Form_Load()
            Else
                rs_ZSITMLST.Tables("result").DefaultView.RowFilter = ""
                Call Display()

                YNC = MsgBox("Record updated!" & vbCrLf & "Save before clear?", vbYesNoCancel + vbDefaultButton1 + vbQuestion, "")
                'goto

                '                YNC = MsgBox("M00245")

                If YNC = vbYes Then
                    If Enq_right_local = True Then
                        Call CmdSave_Click()
                        If save_ok = True Then
                            'Cancel = False
                        Else
                            rs_ZSITMLST.Tables("result").DefaultView.RowFilter = ""
                            Call Display()
                        End If
                    Else
                        MsgBox("Sorry! You do not right to save!")
                    End If
                ElseIf YNC = vbNo Then
                    Call setStatus("init")
                    Call Form_Load()
                    Exit Sub
                ElseIf YNC = vbCancel Then
                    rs_ZSITMLST.Tables("result").DefaultView.RowFilter = ""
                    Call Display()
                    Exit Sub
                End If
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cmdDelRow_Click()

        If Not rs_ZSITMLST.Tables("RESULT").Rows.Count = 0 Then
            If rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_creusr") = "~*ADD*~" Then
                If rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_status") = " " Then
                    rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_updusr").Value = rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_creusr").Value
                    rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_creusr").Value = "~*NEW*~"
                    rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_status").Value = "Y"

                    mmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001

                ElseIf rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_status") = "Y" Then
                    rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_creusr").Value = rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_updusr").Value
                    rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_status").Value = " "

                End If
            ElseIf rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_creusr") <> "~*ADD*~" Then
                If rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_status") = " " Then
                    rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_updusr").Value = rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_creusr").Value
                    rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_creusr").Value = "~*DEL*~"
                    rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_status").Value = "Y"

                    mmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001

                ElseIf rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_status") = "Y" Then
                    rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_creusr").Value = rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_updusr").Value
                    rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_status").Value = " "

                End If
            End If
        End If



    End Sub

    Private Sub CmdExit_Click()

        Me.Close()


    End Sub

    Private Sub cmdFind_Click()
        Dim rs As DataSet
        Dim S As String
        Dim i As Integer

        'gsConnStr = getConnectionString()
        '*** query item master header
        If Trim(txtItmTo.Text) <> "" Then
            S = "sp_select_ZSITMLST '','" + txtItmFm.Text + "','" + txtItmTo.Text + "'"
        Else
            S = "sp_select_ZSITMLST   '','','' "
        End If

        Cursor = Cursors.WaitCursor

        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_ZSITMLST, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
            Exit Sub
        Else
            With rs_ZSITMLST
                For i2 As Integer = 0 To .Tables("RESULT").Columns.Count - 1
                    .Tables("RESULT").Columns(i2).ReadOnly = False
                Next i2
            End With

            If rs_ZSITMLST.Tables("result").Rows.Count > 0 Then
                For index As Integer = 0 To rs_ZSITMLST.Tables("RESULT").Rows.Count - 1
                    rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_status") = ""
                Next
            End If
        End If


        Call show_lvl0()
        Call show_lvl1()

        If rs_ZSITMLST.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
            MsgBox("Record not found!")
            Call Display()
            Call setStatus("init")
            Cursor = Cursors.Default
            Exit Sub
        Else
            'rs_ZSITMLST.MoveFirst()
            Current_TimeStamp = rs_ZSITMLST.Tables("RESULT").Rows(0)("zil_timstp")
            'tempzz
            Cursor = Cursors.Default
            Call Display()
            '            Call setStatus("init")
        End If

        Cursor = Cursors.Default
        txtItmFm.ReadOnly = True
        txtItmTo.ReadOnly = True
        mmdFind.Enabled = False
        mmdClear.Enabled = True
        mmdInsRow.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
        mmdDelRow.Enabled = Del_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001



    End Sub

    Private Sub cmdInsRow_Click()

        If Not rs_ZSITMLST.Tables("RESULT").Rows.Count = 0 Then
            Add_flag = True
            '    rs_ZSITMLST.MoveLast()
        End If

        Call setStatus("InsRow")

        readingindex = rs_ZSITMLST.Tables("RESULT").Rows.Count - 1
        'tempzzzzzzz

        rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_creusr") = "~*ADD*~"
        '        'rs_ZSITMLST.Update()


        GrdCatRel.CurrentCell = GrdCatRel.Item(1, readingindex)
        GrdCatRel.BeginEdit(True)
        GrdCatRel.Focus()


        '        GrdCatRel.col = 1
        'temp

    End Sub

    Private Sub CmdSave_Click()

        'If msgbox("M00129") = vbNo Then
        '    Exit Sub
        'End If

        save_ok = True
        '----------------------------check whether is empty field ------------------
        If Not rs_ZSITMLST.Tables("RESULT").Rows.Count = 0 Then
            For index As Integer = 0 To rs_ZSITMLST.Tables("RESULT").Rows.Count - 1
                If rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr") = "~*ADD*~" And rs_ZSITMLST.Tables("RESULT").Rows(index)(1) = "" Then
                    MsgBox("Please Input Item No.")
                    '       GrdCatRel.col = 1

                    GrdCatRel.CurrentCell = GrdCatRel.Item(1, readingindex)

                    GrdCatRel.CurrentCell = GrdCatRel.Item(1, index)
                    GrdCatRel.BeginEdit(True)

                    GrdCatRel.Focus()
                    save_ok = False
                    Exit Sub
                End If
                If rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr") = "~*ADD*~" And rs_ZSITMLST.Tables("RESULT").Rows(index)(2) = "" Then
                    MsgBox("Please Input Item Name.")
                    GrdCatRel.CurrentCell = GrdCatRel.Item(index, 1)
                    GrdCatRel.BeginEdit(True)

                    '      GrdCatRel.col = 2
                    GrdCatRel.Focus()
                    save_ok = False
                    Exit Sub
                End If
            Next

        End If
        '-----------------------------------------------------------------------------

        Save_flag = True
        Cursor = Cursors.WaitCursor

        If Not Add_flag Then
            '***check timeStamp is equal
            If Not ChecktimeStamp() Then
                MsgBox("The data has been modified by others, could not save!")
                Cursor = Cursors.Default
                save_ok = False
                Exit Sub
            End If
        End If



        Dim S As String
        Dim rs As DataSet

        Dim IsUpdated As Boolean
        IsUpdated = False


        rs_ZSITMLST.Tables("result").DefaultView.RowFilter = ""
        'rs_ZSITMLST.MoveFirst()

        For index As Integer = 0 To rs_ZSITMLST.Tables("RESULT").Rows.Count - 1

            If InStr(rs_ZSITMLST.Tables("RESULT").Rows(index)(8), " - ") > 0 Then
                rs_ZSITMLST.Tables("RESULT").Rows(index)(8) = Split(rs_ZSITMLST.Tables("RESULT").Rows(index)(8), " - ")(0)
            End If
            If InStr(rs_ZSITMLST.Tables("RESULT").Rows(index)(10), " - ") > 0 Then
                rs_ZSITMLST.Tables("RESULT").Rows(index)(10) = Split(rs_ZSITMLST.Tables("RESULT").Rows(index)(10), " - ")(0)
            End If


            S = ""

            If rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr") = "~*ADD*~" Then

                S = "sp_insert_ZSITMLST  '','" & rs_ZSITMLST.Tables("RESULT").Rows(index)(1) & "','" & rs_ZSITMLST.Tables("RESULT").Rows(index)(2) & _
                    "','" & rs_ZSITMLST.Tables("RESULT").Rows(index)(4) & "','" & rs_ZSITMLST.Tables("RESULT").Rows(index)(5) & _
                    "','" & rs_ZSITMLST.Tables("RESULT").Rows(index)(6) & "','" & rs_ZSITMLST.Tables("RESULT").Rows(index)(7) & _
                    "','" & rs_ZSITMLST.Tables("RESULT").Rows(index)(8) & "','" & rs_ZSITMLST.Tables("RESULT").Rows(index)(10) & _
                    "','" & gsUsrID & "'"

            ElseIf rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr") = "~*UPD*~" Then

                S = "sp_update_ZSITMLST  '','" & rs_ZSITMLST.Tables("RESULT").Rows(index)(1) & _
                    "','" & rs_ZSITMLST.Tables("RESULT").Rows(index)(4) & "','" & rs_ZSITMLST.Tables("RESULT").Rows(index)(5) & _
                    "','" & rs_ZSITMLST.Tables("RESULT").Rows(index)(6) & "','" & rs_ZSITMLST.Tables("RESULT").Rows(index)(7) & _
                    "','" & rs_ZSITMLST.Tables("RESULT").Rows(index)(8) & "','" & rs_ZSITMLST.Tables("RESULT").Rows(index)(10) & _
                    "','" & gsUsrID & "'"

            ElseIf rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr") = "~*DEL*~" Then
                S = "sp_physical_delete_ZSITMLST  '','" & rs_ZSITMLST.Tables("RESULT").Rows(index)(1) & "'"

            ElseIf rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr") = "~*NEW*~" Then
                IsUpdated = True

            End If

            If S <> "" Then  '*** if there is something to do with s ...


                gspStr = S
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    IsUpdated = False
                    MsgBox("Error on    saving  :" & rtnStr)
                    Exit Sub
                Else
                    IsUpdated = True
                End If
            End If

        Next


        If IsUpdated Then
            Call setStatus("Save")
            'GrdCatRel.col = 1
            GrdCatRel.Focus()
        Else
            save_ok = False
            MsgBox("Record Saved!")
        End If
        Cursor = Cursors.Default
        Call setStatus("init")

    End Sub
    Private Sub MIM00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Form_Load()
    End Sub

    Private Sub Form_Load()
        AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        Dim v

        '#If useMTS Then
        '        Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If

        Cursor = Cursors.WaitCursor      ' mean 11

        Lstlvl0.Visible = False
        Lstlvl1.Visible = False
        LstUM.Visible = False
        LstCUSTUM.Visible = False
        LstCUR.Visible = False
        mmdInsRow.Enabled = False
        mmdDelRow.Enabled = False

        CanModify = True

        Dim rs As DataSet
        Dim S As String
        Dim i As Integer
        '        gsConnStr = getConnectionString()

        '*** query
        S = "sp_select_ZSITMLST  '' , '" + "ZZZZZZZZZZZZZZZZZZ" + "','" + "ZZZZZZZZZZZZZZZZZZ'"


        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_ZSITMLST, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_ZSITMLST  :" & rtnStr)
            Exit Sub
        Else
        End If

        Cursor = Cursors.Default



        Call Display()
        '*** query



        Call Formstartup(Me.Name)
        Call setStatus("init")
        Cursor = Cursors.Default
        Me.KeyPreview = True


    End Sub

    Private Sub Display()
        GrdCatRel.DataSource = rs_ZSITMLST.Tables("result").DefaultView


        'grdcatrel.Columns(0).value = grdcatrel.Columns(8).value

        GrdCatRel.Columns(0).Width = 600 / 10
        GrdCatRel.Columns(0).HeaderText = "Del"
        '        GrdCatRel.Columns(0).Button = True
        'GrdCatRel.Columns(0).Readonly = True
        GrdCatRel.Columns(0).ReadOnly = True


        GrdCatRel.Columns(1).HeaderText = "Item No."
        GrdCatRel.Columns(1).Width = 1850 / 10
        '        GrdCatRel.Columns(1).Button = False
        '        GrdCatRel.Columns(1).Readonly = True
        GrdCatRel.Columns(1).ReadOnly = True

        GrdCatRel.Columns(2).HeaderText = "Item Name"
        GrdCatRel.Columns(2).Width = 2500 / 10
        '       GrdCatRel.Columns(2).Button = False
        '       GrdCatRel.Columns(2).Readonly = True
        GrdCatRel.Columns(2).ReadOnly = True

        GrdCatRel.Columns(3).Width = 0
        ' GrdCatRel.Columns(3).HeaderText = "Item Desc."
        ' GrdCatRel.Columns(3).width = 1850
        ' GrdCatRel.Columns(3).Button = False
        ' GrdCatRel.Columns(3).Readonly = True
        GrdCatRel.Columns(3).ReadOnly = True
        GrdCatRel.Columns(3).Visible = False



        GrdCatRel.Columns(4).HeaderText = "UM"
        GrdCatRel.Columns(4).Width = 750 / 10
        '      GrdCatRel.Columns(4).Button = True
        '      GrdCatRel.Columns(4).Readonly = True
        GrdCatRel.Columns(4).ReadOnly = True

        GrdCatRel.Columns(5).HeaderText = "CUR"
        GrdCatRel.Columns(5).Width = 600 / 10
        '     GrdCatRel.Columns(5).Button = True
        '     GrdCatRel.Columns(5).Readonly = True
        GrdCatRel.Columns(5).ReadOnly = True

        GrdCatRel.Columns(6).HeaderText = "Unit Price"
        GrdCatRel.Columns(6).Width = 800 / 10
        '    GrdCatRel.Columns(6).Button = False
        '        GrdCatRel.Columns(6).Alignment = dbgRight
        GrdCatRel.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        'GrdCatRel.Columns(5).Readonly = True
        ''''''''''''''''''''''''''''''''''''''''''  GrdCatRel.Columns(6).ReadOnly = False

        GrdCatRel.Columns(7).HeaderText = "Custom UM"
        GrdCatRel.Columns(7).Width = 1000 / 10
        '   GrdCatRel.Columns(7).Button = True
        'GrdCatRel.Columns(5).Readonly = True
        GrdCatRel.Columns(7).ReadOnly = True

        GrdCatRel.Columns(8).HeaderText = "Item Category"
        GrdCatRel.Columns(8).Width = 1100 / 10
        '  GrdCatRel.Columns(8).Button = True
        '    GrdCatRel.Columns(8).Readonly = True
        GrdCatRel.Columns(8).ReadOnly = True

        GrdCatRel.Columns(9).HeaderText = "Category Desc"
        GrdCatRel.Columns(9).Width = 2500 / 10
        ' GrdCatRel.Columns(9).Button = False
        '   GrdCatRel.Columns(9).Readonly = True
        GrdCatRel.Columns(9).ReadOnly = True

        GrdCatRel.Columns(10).HeaderText = "Custom Category"
        GrdCatRel.Columns(10).Width = 1300 / 10
        'GrdCatRel.Columns(10).Button = True
        '  GrdCatRel.Columns(10).Readonly = True
        GrdCatRel.Columns(10).ReadOnly = True

        GrdCatRel.Columns(11).HeaderText = "Category Desc"
        GrdCatRel.Columns(11).Width = 2500 / 10
        'GrdCatRel.Columns(11).Button = False
        ' GrdCatRel.Columns(11).Readonly = True
        GrdCatRel.Columns(11).ReadOnly = True

        GrdCatRel.Columns(12).Width = 0
        GrdCatRel.Columns(12).Visible = False
        GrdCatRel.Columns(13).Width = 0
        GrdCatRel.Columns(13).Visible = False

        GrdCatRel.Columns(14).Width = 0
        GrdCatRel.Columns(14).Visible = False

        GrdCatRel.Columns(15).Width = 0
        GrdCatRel.Columns(15).Visible = False

        GrdCatRel.Columns(16).Width = 0
        GrdCatRel.Columns(16).Visible = False

        GrdCatRel.Columns(17).Width = 0
        GrdCatRel.Columns(17).Visible = False

        GrdCatRel.Columns(18).Width = 0
        GrdCatRel.Columns(18).Visible = False

        ' Display the RECORD information "Create Date" "Update Dare" "Last Update User"
        If Not rs_ZSITMLST.Tables("RESULT").Rows.Count = 0 Then
            StatusBar.Panels(1).Text = Format(rs_ZSITMLST.Tables("RESULT").Rows(0)("zil_credat"), "MM/dd/yyyy") & " " & Format(rs_ZSITMLST.Tables("RESULT").Rows(0)("zil_upddat"), "MM/dd/yyyy") & _
                                          " " & rs_ZSITMLST.Tables("RESULT").Rows(0)("zil_updusr")
        End If
    End Sub
    Private Sub setStatus(ByVal Mode As String)
        'Private Sub setStatus(Mode As String, Optional rs As Dataset)

        If Mode = "init" Then
            readingindex = 0
            'Call SetInputBoxesStatus("DisableAll")
            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            '        CmdCopy.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
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


            txtItmFm.Text = ""
            txtItmTo.Text = ""
            txtItmFm.ReadOnly = False
            txtItmTo.ReadOnly = False

            'Call ResetDefaultDisp
            Call SetStatusBar(Mode)

            '***Reset the flag
            Recordstatus = False
            Save_flag = False
            mmdCopy.Enabled = False
            'Add your codes here

        ElseIf Mode = "InsRow" Then

            'EditModeHdr = Mode
            'Call SetInputBoxesStatus("EnableAll")

            rs_ZSITMLST.Tables("RESULT").Rows.Add()
            rs_ZSITMLST.Tables("RESULT").Rows(rs_ZSITMLST.Tables("RESULT").Rows.Count - 1)("zil_status") = ""
            rs_ZSITMLST.Tables("RESULT").Rows(rs_ZSITMLST.Tables("RESULT").Rows.Count - 1)("zil_itmno") = ""
            rs_ZSITMLST.Tables("RESULT").Rows(rs_ZSITMLST.Tables("RESULT").Rows.Count - 1)("zil_itmnam") = ""
            rs_ZSITMLST.Tables("RESULT").Rows(rs_ZSITMLST.Tables("RESULT").Rows.Count - 1)("zil_itmdesc") = ""
            rs_ZSITMLST.Tables("RESULT").Rows(rs_ZSITMLST.Tables("RESULT").Rows.Count - 1)("zil_UM") = ""
            rs_ZSITMLST.Tables("RESULT").Rows(rs_ZSITMLST.Tables("RESULT").Rows.Count - 1)("zil_Cur") = ""
            rs_ZSITMLST.Tables("RESULT").Rows(rs_ZSITMLST.Tables("RESULT").Rows.Count - 1)("zil_prc") = 0

            rs_ZSITMLST.Tables("RESULT").Rows(rs_ZSITMLST.Tables("RESULT").Rows.Count - 1)("Zil_CustUM") = ""             '------New
            rs_ZSITMLST.Tables("RESULT").Rows(rs_ZSITMLST.Tables("RESULT").Rows.Count - 1)("Zil_CatCde1") = ""             '------New
            rs_ZSITMLST.Tables("RESULT").Rows(rs_ZSITMLST.Tables("RESULT").Rows.Count - 1)("cat1desc") = ""             '------New
            rs_ZSITMLST.Tables("RESULT").Rows(rs_ZSITMLST.Tables("RESULT").Rows.Count - 1)("Zil_CatCde2") = ""             '------New
            rs_ZSITMLST.Tables("RESULT").Rows(rs_ZSITMLST.Tables("RESULT").Rows.Count - 1)("cat2desc") = ""             '------New
            rs_ZSITMLST.Tables("RESULT").Rows(rs_ZSITMLST.Tables("RESULT").Rows.Count - 1)("Zil_Moq") = 0             '------New
            rs_ZSITMLST.Tables("RESULT").Rows(rs_ZSITMLST.Tables("RESULT").Rows.Count - 1)("Zil_MtyBy") = 0             '------New

            rs_ZSITMLST.Tables("RESULT").Rows(rs_ZSITMLST.Tables("RESULT").Rows.Count - 1)("zil_credat") = Format(Date.Today, "MM/dd/yyyy").ToString
            rs_ZSITMLST.Tables("RESULT").Rows(rs_ZSITMLST.Tables("RESULT").Rows.Count - 1)("zil_upddat") = Format(Date.Today, "MM/dd/yyyy").ToString
            rs_ZSITMLST.Tables("RESULT").Rows(rs_ZSITMLST.Tables("RESULT").Rows.Count - 1)("zil_creusr") = gsUsrID
            rs_ZSITMLST.Tables("RESULT").Rows(rs_ZSITMLST.Tables("RESULT").Rows.Count - 1)("zil_updusr") = gsUsrID
            '            GrdCatRel.Columns(1).readonly = False
            '           GrdCatRel.Columns(2).readonly = False
            GrdCatRel.Columns(1).ReadOnly = True
            GrdCatRel.Columns(2).ReadOnly = True

            '   GrdCatRel.col = 1

            mmdCopy.Enabled = False
            mmdFind.Enabled = False

            mmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
            mmdDelRow.Enabled = Del_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001


            Call SetStatusBar(Mode)

        ElseIf Mode = "Save" Then
            'Call ResetDefaultDisp
            Call SetStatusBar(Mode)

            MsgBox("Record Saved!")

            Call setStatus("init")
            Call Form_Load()
            mmdClear.Enabled = True



        End If

        If Not CanModify Then
            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            'CmdLookup.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False

            'Call ResetDefaultDisp
            Call SetStatusBar("ReadOnly")
        End If
    End Sub
    Private Sub SetStatusBar(ByVal Mode As String)

        If Mode = "init" Then
            StatusBar.Panels(0).Text = "Init" '& " " & "Total Record : " & rs_sycolinf.Tables("RESULT").Rows.Count
            'Add your codes here

        ElseIf Mode = "InsRow" Then
            StatusBar.Panels(0).Text = "Insert Row"
            'Add your codes here

        ElseIf Mode = "Updating" Then
            StatusBar.Panels(0).Text = "Updating"
            'Add your codes here

        ElseIf Mode = "Save" Then
            StatusBar.Panels(0).Text = "Record Saved"
            'Add your codes here

        ElseIf Mode = "DelRow" Then
            StatusBar.Panels(0).Text = "Record Row Deleted"
            'Add your codes here

        ElseIf Mode = "ReadOnly" Then
            StatusBar.Panels(0).Text = "Read Only" '& " " & "Total Record : " & rs_sycolinf.Tables("RESULT").Rows.Count
            'Add your codes here
        ElseIf Mode = "Clear" Then
            StatusBar.Panels(0).Text = "Clear Screen"
            'Add your codes here
        End If
    End Sub
    Private Sub MIM00001_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '    Private Sub Form_Unload(ByVal Cancel As Integer)
        Dim YNC, book As Integer
        If rs_ZSITMLST.Tables("RESULT").Rows.Count > 0 Then

            'If rs_ZSITMLST.EOF = True Then
            '    e.Cancel = False
            'Else
            'temp

            '                book = rs_ZSITMLST.AbsolutePosition

            rs_ZSITMLST.Tables("result").DefaultView.RowFilter = "zil_creusr = " & "'" & "~*ADD*~" & "'" & _
                                      "or zil_creusr = " & "'" & "~*UPD*~" & "'" & _
                                      "or zil_creusr = " & "'" & "~*DEL*~" & "'" & _
                                      "or zil_creusr = " & "'" & "~*NEW*~" & "'"

            If rs_ZSITMLST.Tables("RESULT").DefaultView.Count = 0 Then
                e.Cancel = False
            Else
                rs_ZSITMLST.Tables("result").DefaultView.RowFilter = ""
                Call Display()
                YNC = MsgBox("Save before exit?", MsgBoxStyle.YesNo)
                If YNC = vbYes Then
                    If Enq_right_local = True Then
                        Call CmdSave_Click()
                        If save_ok = True Then
                            e.Cancel = False
                        Else
                            rs_ZSITMLST.Tables("result").DefaultView.RowFilter = ""
                            Call Display()
                            e.Cancel = True
                        End If
                    Else
                        MsgBox("Sorry! You do not right to save!")
                    End If
                ElseIf YNC = vbNo Then
                    e.Cancel = False
                    Exit Sub
                ElseIf YNC = vbCancel Then
                    rs_ZSITMLST.Tables("result").DefaultView.RowFilter = ""
                    Call Display()
                    e.Cancel = True
                    Exit Sub
                End If
                Exit Sub
            End If
        End If

    End Sub

    'goto
    Private Sub GrdCatRel_AfterColUpdate(ByVal ColIndex As Integer)
        'cellendedit

        'Dim tmp As String
        'Dim tmpBookMark As Integer
        ''Dim old_Tables("result").DefaultView.RowFilter
        'Dim current_pos As Integer

        'Dim lngMOQMOA As Long


        'If Not rs_ZSITMLST.Tables("RESULT").Rows.Count = 0 Then


        '    If ColIndex = 1 And rs_ZSITMLST.Tables("RESULT").Rows(readingindex)(1) <> "" Then

        '        If GrdCatRel.col = 1 Then
        '            rs_ZSITMLST.Tables("RESULT").Rows(readingindex)(1).Value = Trim(UCase(rs_ZSITMLST.Tables("RESULT").Rows(readingindex)(1).Value))
        '        End If

        '        '                current_pos = rs_ZSITMLST.AbsolutePosition
        '        '               tmpBookMark = rs_ZSITMLST.Bookmark

        '        tmp = rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("ZIL_itmno")

        '        For index As Integer = 0 To rs_ZSITMLST.Tables("RESULT").Rows.Count - 1
        '            If tmp = rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_itmno") Then
        '                MsgBox("This grid have " & tmp & " Item No !", vbInformation)
        '                'If current_pos > 0 Then
        '                '    rs_ZSITMLST.AbsolutePosition = current_pos
        '                rs_ZSITMLST.Tables("RESULT").Rows(index)(1).Value = ""
        '                '    GrdCatRel.col = 1
        '                '    GrdCatRel.Focus()
        '                'End If
        '                Exit Sub
        '            End If
        '        Next
        '        'tempzz


        '        'If current_pos > 0 Then
        '        '    rs_ZSITMLST.AbsolutePosition = current_pos
        '        'End If
        '    ElseIf ColIndex = 4 Or ColIndex = 5 Or ColIndex = 6 Or ColIndex = 7 Then
        '        If rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_creusr") <> "~*ADD*~" Then
        '            rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_creusr") = "~*UPD*~"
        '            'rs_ZSITMLST.Update()
        '            cmdSave.Enabled = Enq_right_local
        '        End If
        '    End If
        'End If


    End Sub

    'Private Sub grdcatrel_ButtonClick(ByVal ColIndex As Integer)
    '    '''''''''''''''
    '    'cell click
    '    If ColIndex = 0 Then
    '        If GrdCatRel.Columns(0).Text = " " Then
    '            GrdCatRel.Columns(0).Text = "Y"
    '            rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr").Value = "~*DEL*~"
    '            cmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
    '        Else
    '            GrdCatRel.Columns(0).Text = " "
    '            rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr").Value = " "
    '        End If
    '    End If

    '    'If rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr") = "~*ADD*~" Then

    '    If ColIndex = 4 Then

    '        LstUM.Visible = True
    '        If (GrdCatRel.RowTop(GrdCatRel.row) + GrdCatRel.Columns(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) > 4483 Then
    '        LstUM.Move (GrdCatRel.Columns(ColIndex).Left + GrdCatRel.Left), 3500 + ((GrdCatRel.RowTop(GrdCatRel.row) + GrdCatRel.Columns(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) - 5444.599)
    '        Else
    '        LstUM.Move (GrdCatRel.Columns(ColIndex).Left + GrdCatRel.Left), (GrdCatRel.RowTop(GrdCatRel.row) + GrdCatRel.Columns(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) - 100
    '        End If
    '        LstUM.Focus()


    '    ElseIf ColIndex = 5 Then

    '        LstCUR.Visible = True
    '        If (GrdCatRel.RowTop(GrdCatRel.row) + GrdCatRel.Columns(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) > 4483 Then
    '        LstCUR.Move (GrdCatRel.Columns(ColIndex).Left + GrdCatRel.Left), 3500 + ((GrdCatRel.RowTop(GrdCatRel.row) + GrdCatRel.Columns(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) - 5444.599)
    '        Else
    '        LstCUR.Move (GrdCatRel.Columns(ColIndex).Left + GrdCatRel.Left), (GrdCatRel.RowTop(GrdCatRel.row) + GrdCatRel.Columns(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) - 100
    '        End If
    '        LstCUR.Focus()


    '    ElseIf ColIndex = 7 Then

    '        LstCUSTUM.Visible = True
    '        If (GrdCatRel.RowTop(GrdCatRel.row) + GrdCatRel.Columns(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) > 4483 Then
    '        LstCUSTUM.Move (GrdCatRel.Columns(ColIndex).Left + GrdCatRel.Left), 3500 + ((GrdCatRel.RowTop(GrdCatRel.row) + GrdCatRel.Columns(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) - 5444.599)
    '        Else
    '        LstCUSTUM.Move (GrdCatRel.Columns(ColIndex).Left + GrdCatRel.Left), (GrdCatRel.RowTop(GrdCatRel.row) + GrdCatRel.Columns(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) - 100
    '        End If
    '        LstCUSTUM.Focus()


    '    ElseIf ColIndex = 8 Then

    '        Lstlvl0.Visible = True
    '        If (GrdCatRel.RowTop(GrdCatRel.row) + GrdCatRel.Columns(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) > 4483 Then
    '        Lstlvl0.Move (GrdCatRel.Columns(ColIndex).Left + GrdCatRel.Left), 3500 + ((GrdCatRel.RowTop(GrdCatRel.row) + GrdCatRel.Columns(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) - 5444.599)
    '        Else
    '        Lstlvl0.Move (GrdCatRel.Columns(ColIndex).Left + GrdCatRel.Left), (GrdCatRel.RowTop(GrdCatRel.row) + GrdCatRel.Columns(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) - 100
    '        End If
    '        Lstlvl0.Focus()

    '    ElseIf ColIndex = 10 Then

    '        Lstlvl1.Visible = True
    '        If (GrdCatRel.RowTop(GrdCatRel.row) + GrdCatRel.Columns(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) > 4483 Then
    '        Lstlvl1.Move (GrdCatRel.Columns(ColIndex).Left + GrdCatRel.Left), 3500 + ((GrdCatRel.RowTop(GrdCatRel.row) + GrdCatRel.Columns(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) - 5444.599)
    '        Else
    '        Lstlvl1.Move (GrdCatRel.Columns(ColIndex).Left + GrdCatRel.Left), (GrdCatRel.RowTop(GrdCatRel.row) + GrdCatRel.Columns(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) - 100
    '        End If
    '        Lstlvl1.Focus()


    '    End If
    '    'End If
    'End Sub
    Private Function ChecktimeStamp() As Boolean
        Dim Save_TimeStamp As Long
        Dim S As String
        Dim rs As DataSet

        If Trim(txtItmTo.Text) <> "" Then
            S = "sp_select_ZSITMLST '','" + txtItmFm.Text + "','" + txtItmTo.Text & "'"
        Else
            S = "sp_select_ZSITMLST '','','' "
        End If

        gspStr = S
        Cursor = Cursors.WaitCursor

        rtnLong = execute_SQLStatement(gspStr, rs_ZSITMLST_check, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_MPM00002  :" & rtnStr)
            Exit Function
        Else
            Save_TimeStamp = rs_ZSITMLST_check.Tables("RESULT").Rows(0)("zil_timstp")
        End If
        Cursor = Cursors.Default



        If Current_TimeStamp <> Save_TimeStamp Then
            ChecktimeStamp = False
        Else
            ChecktimeStamp = True
        End If

    End Function
    Private Sub show_lvl0()
        'goto
        ''this should be cbo
        Cursor = Cursors.WaitCursor      ' mean 11
        Dim rs As DataSet
        Dim S As String
        Dim i As Integer

        '*** query item master header
        S = "sp_select_SYMCATCDE_level  '','0' "
        gspStr = S
        Cursor = Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_L0, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_SYMCATCDE_level   :" & rtnStr)
            Exit Sub
        Else
        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub show_lvl1()
        Cursor = Cursors.WaitCursor      ' mean 11
        Dim rs As DataSet
        Dim S As String
        Dim i As Integer

        '*** query item master header
        S = "sp_select_SYMCATCDE_level  '','1' "
        gspStr = S
        Cursor = Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_L1, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_SYMCATCDE_level   :" & rtnStr)
            Exit Sub
        Else
        End If
        Cursor = Cursors.Default

    End Sub
    Private Sub GrdCatRel_DblClick()
        'cell d c?
        'If GrdCatRel.col = 0 Then
        '    If rs_ZSITMLST.EOF <> True Then
        '        If GrdCatRel.Columns(0).Text = " " Then
        '            GrdCatRel.Columns(0).Text = "Y"
        '            rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr").Value = "~*DEL*~"
        '            cmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
        '        Else
        '            GrdCatRel.Columns(0).Text = " "
        '            rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr").Value = " "
        '        End If
        '    End If
        'End If
    End Sub

    'Private Sub GrdCatRel_Error(ByVal DataError As Integer, ByVal Response As Integer)
    '    If DataError = 7007 Then
    '        MsgBox("M00018")
    '        Response = 0
    '        Exit Sub

    '    End If

    'End Sub

    Private Sub GrdCatRel_HeadClick(ByVal ColIndex As Integer)
    End Sub

    Private Sub GrdCatRel_KeyPress(ByVal KeyAscii As Integer)
        'cellclick?
        'If Not rs_ZSITMLST.Tables("RESULT").Rows.Count = 0 Then

        '    If GrdCatRel.col = 0 Then
        '        If KeyAscii = 32 Then
        '            Call GrdCatRel_DblClick()
        '        End If
        '    End If

        '    If GrdCatRel.col = 3 Then
        '        If KeyAscii = 32 Then
        '            Call grdcatrel_ButtonClick(3)
        '        End If

        '    ElseIf GrdCatRel.col = 4 Then
        '        If KeyAscii = 32 Then
        '            Call grdcatrel_ButtonClick(4)
        '        End If

        '    ElseIf GrdCatRel.col = 5 Then
        '        If KeyAscii = 32 Then
        '            Call grdcatrel_ButtonClick(5)
        '        End If

        '    ElseIf GrdCatRel.col = 6 Then
        '        If KeyAscii = 32 Then
        '            Call grdcatrel_ButtonClick(6)
        '        End If

        '    ElseIf GrdCatRel.col = 7 Then
        '        If KeyAscii = 32 Then
        '            Call grdcatrel_ButtonClick(7)
        '        End If
        '    End If

        'End If

    End Sub

    Private Sub GrdCatRel_RowColChange(ByVal LastRow As Object, ByVal LastCol As Integer)

        'readingindex = e.rowindex

        'If Not rs_ZSITMLST.Tables("RESULT").Rows.Count = 0 Then
        '    StatusBar.Panels(1).Text = Format(rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_credat"), "MM/dd/yyyy") & " " & Format(rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_upddat"), "MM/dd/yyyy") & _
        '                                  " " & rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_updusr")
        'End If

        'If rs_ZSITMLST.Tables("RESULT").Rows.Count > 0 Then
        '    If rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr") = "~*ADD*~" Then
        '        GrdCatRel.Columns(1).ReadOnly = False
        '        GrdCatRel.Columns(2).ReadOnly = False
        '    Else
        '        If LastCol <> 0 Then
        '            GrdCatRel.Columns(1).ReadOnly = True
        '            GrdCatRel.Columns(2).ReadOnly = True
        '        End If
        '    End If
        'End If

    End Sub

    'Private Sub LstCUR_DblClick()
    '    GrdCatRel.Columns(5).Text = LstCUR.Text
    '    GrdCatRel.Enabled = True
    '    LstCUR.Visible = False

    '    If rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr") <> "~*ADD*~" Then rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr") = "~*UPD*~"
    '    'rs_ZSITMLST.Update()
    '    cmdSave.Enabled = Enq_right_local

    'End Sub

    'Private Sub LstCUR_KeyPress(ByVal KeyAscii As Integer)
    '    If KeyAscii = 32 Then
    '        GrdCatRel.Columns(5).Text = LstCUR.Text
    '        GrdCatRel.Enabled = True
    '        LstCUR.Visible = False
    '    End If
    'End Sub

    'Private Sub LstCUR_LostFocus()
    '    LstCUR.Visible = False
    'End Sub

    'Private Sub LstCUSTUM_DblClick()
    '    GrdCatRel.Columns(7).Text = LstCUSTUM.Text
    '    GrdCatRel.Enabled = True
    '    LstCUSTUM.Visible = False

    '    If rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr") <> "~*ADD*~" Then rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr") = "~*UPD*~"
    '    'rs_ZSITMLST.Update()
    '    cmdSave.Enabled = Enq_right_local

    'End Sub

    'Private Sub LstCUSTUM_KeyPress(ByVal KeyAscii As Integer)
    '    If KeyAscii = 32 Then
    '        GrdCatRel.Columns(7).Text = LstCUSTUM.Text
    '        GrdCatRel.Enabled = True
    '        LstCUSTUM.Visible = False
    '    End If
    'End Sub

    'Private Sub LstCUSTUM_LostFocus()
    '    LstCUSTUM.Visible = False
    'End Sub

    'Private Sub Lstlvl0_DblClick()
    '    GrdCatRel.Columns(8).Text = Split(Lstlvl0.Text, " - ")(0)
    '    GrdCatRel.Columns(9).Text = Split(Lstlvl0.Text, " - ")(1)
    '    GrdCatRel.Enabled = True
    '    Lstlvl0.Visible = False

    '    If rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr") <> "~*ADD*~" Then rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr") = "~*UPD*~"
    '    'rs_ZSITMLST.Update()
    '    cmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001

    'End Sub

    'Private Sub Lstlvl0_KeyPress(ByVal KeyAscii As Integer)
    '    If KeyAscii = 32 Then
    '        GrdCatRel.Columns(8).Text = Split(Lstlvl0.Text, " - ")(0)
    '        GrdCatRel.Columns(9).Text = Split(Lstlvl0.Text, " - ")(1)
    '        GrdCatRel.Enabled = True
    '        Lstlvl0.Visible = False
    '    End If
    'End Sub

    'Private Sub Lstlvl0_LostFocus()
    '    Lstlvl0.Visible = False
    'End Sub

    'Private Sub Lstlvl1_DblClick()
    '    GrdCatRel.Columns(10).Text = Split(Lstlvl1.Text, " - ")(0)
    '    GrdCatRel.Columns(11).Text = Split(Lstlvl1.Text, " - ")(1)
    '    GrdCatRel.Enabled = True
    '    Lstlvl1.Visible = False

    '    If rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr") <> "~*ADD*~" Then rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr") = "~*UPD*~"
    '    'rs_ZSITMLST.Update()
    '    cmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001


    'End Sub

    'Private Sub Lstlvl1_KeyPress(ByVal KeyAscii As Integer)
    '    If KeyAscii = 32 Then
    '        GrdCatRel.Columns(10).Text = Split(Lstlvl1.Text, " - ")(0)
    '        GrdCatRel.Columns(11).Text = Split(Lstlvl1.Text, " - ")(1)
    '        GrdCatRel.Enabled = True
    '        Lstlvl1.Visible = False
    '    End If

    'End Sub

    'Private Sub Lstlvl1_LostFocus()
    '    Lstlvl1.Visible = False
    'End Sub

    'Private Function InputIsValid() As Boolean
    'End Function


    'Private Sub LstUM_DblClick()
    '    GrdCatRel.Columns(4).Text = LstUM.Text
    '    GrdCatRel.Enabled = True
    '    LstUM.Visible = False

    '    If rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr") <> "~*ADD*~" Then rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_creusr") = "~*UPD*~"
    '    'rs_ZSITMLST.Update()
    '    cmdSave.Enabled = Enq_right_local

    'End Sub

    'Private Sub LstUM_KeyPress(ByVal KeyAscii As Integer)
    '    If KeyAscii = 32 Then
    '        GrdCatRel.Columns(4).Text = LstUM.Text
    '        GrdCatRel.Enabled = True
    '        LstUM.Visible = False
    '    End If
    'End Sub

    'Private Sub LstUM_LostFocus()
    '    LstUM.Visible = False
    'End Sub

    Private Sub txtItmFm_Change()
    End Sub

    Private Sub txtItmFm_GotFocus()

    End Sub

    Private Sub txtItmTo_GotFocus()
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click
        Call cmdFind_Click()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        Call CmdSave_Click()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        Call cmdClear_Click()
    End Sub

    Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click
        Call cmdDelRow_Click()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        Call CmdExit_Click()
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSearch.Click

    End Sub

    Private Sub GrdCatRel_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdCatRel.CellClick
        Dim ColIndex As Integer

        GrdCatRel.Columns(6).ReadOnly = False
        readingindex = e.RowIndex
        ColIndex = e.ColumnIndex

        '''''''''''''''
        'cell click
        If ColIndex = 0 Then

            If rs_ZSITMLST.Tables("RESULT").Rows(readingindex)(0) = " " Then
                'tempzz
                rs_ZSITMLST.Tables("RESULT").Rows(readingindex)(0) = "Y"
                rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_creusr") = "~*DEL*~"
                mmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
            Else
                rs_ZSITMLST.Tables("RESULT").Rows(readingindex)(0) = " "
                rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_creusr") = " "
            End If
        End If

        'If rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_creusr") = "~*ADD*~" Then

        If ColIndex = 4 Then
            comboBoxCell(GrdCatRel, "Um")

            'LstUM.Visible = True

            'If (GrdCatRel.RowTop(GrdCatRel.row) + rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) > 4483 Then
            'LstUM.Move (rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Left + GrdCatRel.Left), 3500 + ((GrdCatRel.RowTop(GrdCatRel.row) + rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) - 5444.599)
            'Else
            'LstUM.Move (rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Left + GrdCatRel.Left), (GrdCatRel.RowTop(GrdCatRel.row) + rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) - 100
            'End If
            'LstUM.Focus()


        ElseIf ColIndex = 5 Then
            comboBoxCell(GrdCatRel, "Cur")

            'LstCUR.Visible = True
            'If (GrdCatRel.RowTop(GrdCatRel.row) + rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) > 4483 Then
            'LstCUR.Move (rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Left + GrdCatRel.Left), 3500 + ((GrdCatRel.RowTop(GrdCatRel.row) + rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) - 5444.599)
            'Else
            'LstCUR.Move (rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Left + GrdCatRel.Left), (GrdCatRel.RowTop(GrdCatRel.row) + rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) - 100
            'End If
            'LstCUR.Focus()


        ElseIf ColIndex = 7 Then
            comboBoxCell(GrdCatRel, "Um")

            'LstCUSTUM.Visible = True
            'If (GrdCatRel.RowTop(GrdCatRel.row) + rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) > 4483 Then
            'LstCUSTUM.Move (rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Left + GrdCatRel.Left), 3500 + ((GrdCatRel.RowTop(GrdCatRel.row) + rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) - 5444.599)
            'Else
            'LstCUSTUM.Move (rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Left + GrdCatRel.Left), (GrdCatRel.RowTop(GrdCatRel.row) + rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) - 100
            'End If
            'LstCUSTUM.Focus()


        ElseIf ColIndex = 8 Then
            comboBoxCell(GrdCatRel, "l0")

            'Lstlvl0.Visible = True
            'If (GrdCatRel.RowTop(GrdCatRel.row) + rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) > 4483 Then
            'Lstlvl0.Move (rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Left + GrdCatRel.Left), 3500 + ((GrdCatRel.RowTop(GrdCatRel.row) + rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) - 5444.599)
            'Else
            'Lstlvl0.Move (rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Left + GrdCatRel.Left), (GrdCatRel.RowTop(GrdCatRel.row) + rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) - 100
            'End If
            'Lstlvl0.Focus()

        ElseIf ColIndex = 10 Then
            comboBoxCell(GrdCatRel, "l1")

            'Lstlvl1.Visible = True
            'If (GrdCatRel.RowTop(GrdCatRel.row) + rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) > 4483 Then
            'Lstlvl1.Move (rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Left + GrdCatRel.Left), 3500 + ((GrdCatRel.RowTop(GrdCatRel.row) + rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) - 5444.599)
            'Else
            'Lstlvl1.Move (rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Left + GrdCatRel.Left), (GrdCatRel.RowTop(GrdCatRel.row) + rs_ZSITMLST.Tables("RESULT").rows(readingindex)(ColIndex).Top + GrdCatRel.Top + GrdCatRel.RowHeight) - 100
            'End If
            'Lstlvl1.Focus()





        End If

        'If mode <> "ADD" And mode <> "UPDATE" Then
        '    Exit Sub
        'End If

        'If grdVnCntInf.RowCount = 0 Then
        '    Exit Sub
        'End If

        'Select Case grdVnCntInf.CurrentCell.ColumnIndex
        '    Case grdVnCntInf_vci_cty
        '        comboBoxCell(grdVnCntInf, "Cty")





        '   rs_ZSITMLST.Tables("RESULT").AcceptChanges()

    End Sub

    Private Sub GrdCatRel_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdCatRel.CellContentClick

    End Sub

    Private Sub LstCUSTUM_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstCUSTUM.Move

    End Sub

    Private Sub LstCUSTUM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstCUSTUM.SelectedIndexChanged

    End Sub

    Private Sub GrdCatRel_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdCatRel.CellDoubleClick
        readingindex = e.RowIndex

        If e.ColumnIndex = 0 Then
            If rs_ZSITMLST.Tables("RESULT").Rows.Count > 0 Then
                If rs_ZSITMLST.Tables("RESULT").Rows(readingindex)(0) = " " Then
                    rs_ZSITMLST.Tables("RESULT").Rows(readingindex)(0) = "Y"
                    rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_creusr") = "~*DEL*~"

                    mmdSave.Enabled = Enq_right_local 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
                Else
                    rs_ZSITMLST.Tables("RESULT").Rows(readingindex)(0) = " "
                    rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_creusr") = " "
                End If
            End If

        End If

        '   rs_ZSITMLST.Tables("RESULT").AcceptChanges()


    End Sub

    Private Sub GrdCatRel_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdCatRel.CellEndEdit

        Dim tmp As String
        Dim tmpBookMark As Integer
        Dim ColIndex As Integer
        'Dim old_Tables("result").DefaultView.RowFilter
        Dim current_pos As Integer
        Dim lngMOQMOA As Long

        If Not rs_ZSITMLST.Tables("RESULT").Rows.Count = 0 Then

            ColIndex = e.ColumnIndex
            If e.ColumnIndex = 1 And rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("Zil_ItmNo") <> "" Then
                'tempz

                If ColIndex = 1 Then
                    'If GrdCatRel.col = 1 Then
                    rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("Zil_ItmNo") = Trim(UCase(rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("Zil_ItmNo")))
                End If

                '                current_pos = rs_ZSITMLST.AbsolutePosition
                '               tmpBookMark = rs_ZSITMLST.Bookmark

                tmp = rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("ZIL_itmno")
                For index As Integer = 0 To rs_ZSITMLST.Tables("RESULT").Rows.Count - 1
                    If index <> readingindex Then
                        If tmp = rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_itmno") Then
                            MsgBox("This grid have " & tmp & " Item No !", vbInformation)
                            'If current_pos > 0 Then
                            '    rs_ZSITMLST.AbsolutePosition = current_pos
                            rs_ZSITMLST.Tables("RESULT").Rows(index)("zil_itmno").Value = ""
                            '    GrdCatRel.col = 1
                            '    GrdCatRel.Focus()
                            'End If
                            Exit Sub
                        End If

                    End If
                Next
                'tempzz


                'If current_pos > 0 Then
                '    rs_ZSITMLST.AbsolutePosition = current_pos
                'End If
            ElseIf ColIndex = 4 Or ColIndex = 5 Or ColIndex = 6 Or ColIndex = 7 Then
                If rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_creusr") <> "~*ADD*~" Then
                    rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_creusr") = "~*UPD*~"
                    'rs_ZSITMLST.Update()
                    mmdSave.Enabled = Enq_right_local
                End If
            ElseIf ColIndex = 8 Then
                If InStr(rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("Zil_CatCde1"), " - ") > 0 Then
                    rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("cat1desc") = Split(rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("Zil_CatCde1"), " - ")(1)
                End If


            ElseIf ColIndex = 10 Then
                If InStr(rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("Zil_CatCde2"), " - ") > 0 Then
                    rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("cat2desc") = Split(rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("Zil_CatCde2"), " - ")(1)
                End If


            End If
        End If

        rs_ZSITMLST.Tables("RESULT").AcceptChanges()

    End Sub

    Private Sub comboBoxCell(ByVal dgv As DataGridView, ByVal typ As String)
        Dim cboCell As New DataGridViewComboBoxCell

        Dim iCol As Integer = dgv.CurrentCell.ColumnIndex
        Dim iRow As Integer = dgv.CurrentCell.RowIndex

        Dim row As DataGridViewRow = dgv.CurrentRow

        'dgv.Rows(iRow).Cells(iCol).ReadOnly = True

        Dim i As Integer

        Select Case typ
            Case "l1"
                For i = 0 To rs_L1.Tables("RESULT").Rows.Count - 1
                    cboCell.Items.Add(rs_L1.Tables("RESULT").Rows(i).Item("ymc_catcde") + " - " + rs_L1.Tables("RESULT").Rows(i).Item("ymc_catdsc"))
                Next i
            Case "l0"
                For i = 0 To rs_L0.Tables("RESULT").Rows.Count - 1
                    cboCell.Items.Add(rs_L0.Tables("RESULT").Rows(i).Item("ymc_catcde") + " - " + rs_L0.Tables("RESULT").Rows(i).Item("ymc_catdsc"))
                Next i
            Case "Um"
                cboCell.Items.Add("BAG")
                cboCell.Items.Add("BOX")
                cboCell.Items.Add("BUN")
                cboCell.Items.Add("CM")
                cboCell.Items.Add("CTN")
                cboCell.Items.Add("DZ")
                cboCell.Items.Add("G")
                cboCell.Items.Add("GAL")
                cboCell.Items.Add("GR")
                cboCell.Items.Add("INCH")
                cboCell.Items.Add("KG")
                cboCell.Items.Add("L")
                cboCell.Items.Add("LBS")
                cboCell.Items.Add("M")
                cboCell.Items.Add("MG")
                cboCell.Items.Add("MM")
                cboCell.Items.Add("PC")
                cboCell.Items.Add("ROLL")
                cboCell.Items.Add("SET")
                cboCell.Items.Add("SQCM")
                cboCell.Items.Add("SQIN")
                cboCell.Items.Add("SQM")
                cboCell.Items.Add("STE")
                cboCell.Items.Add("TANK")
                cboCell.Items.Add("THCH")
                cboCell.Items.Add("TIN")
                cboCell.Items.Add("TRAY")
                cboCell.Items.Add("YDS")
            Case "Wgt"
                cboCell.Items.Add("KG")
                cboCell.Items.Add("M")
            Case "Cur"
                cboCell.Items.Add("HKD")
                cboCell.Items.Add("USD")
        End Select

        cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox

        dgv.Rows(iRow).Cells(iCol) = cboCell
        dgv.Rows(iRow).Cells(iCol).ReadOnly = False

    End Sub

    Private Sub GrdCatRel_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GrdCatRel.ColumnHeaderMouseClick

        Dim ColIndex
        ColIndex = e.ColumnIndex

        Select Case ColIndex
            Case 1
                rs_ZSITMLST.Tables("result").DefaultView.Sort = "zil_itmno"
            Case 2
                rs_ZSITMLST.Tables("result").DefaultView.Sort = "zil_itmnam"
            Case 4
                rs_ZSITMLST.Tables("result").DefaultView.Sort = "zil_catcde1"
            Case 6
                rs_ZSITMLST.Tables("result").DefaultView.Sort = "zil_catcde2"


            Case 5
                rs_ZSITMLST.Tables("result").DefaultView.Sort = "cat1desc"
            Case 7
                rs_ZSITMLST.Tables("result").DefaultView.Sort = "cat2desc"

        End Select




    End Sub


    Private Sub GrdCatRel_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdCatRel.CurrentCellChanged
        GrdCatRel.Columns(6).ReadOnly = False

        If readingindex < 0 Then
            readingindex = 0
        End If

        If Not rs_ZSITMLST.Tables("RESULT").Rows.Count = 0 Then
            StatusBar.Panels(1).Text = Format(rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_credat"), "MM/dd/yyyy") & " " & Format(rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_upddat"), "MM/dd/yyyy") & _
                                          " " & rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_updusr")
        End If

        If rs_ZSITMLST.Tables("RESULT").Rows.Count > 0 Then
            If rs_ZSITMLST.Tables("RESULT").Rows(readingindex)("zil_creusr") = "~*ADD*~" Then
                GrdCatRel.Columns(1).ReadOnly = False
                GrdCatRel.Columns(2).ReadOnly = False
            Else
                'If LastCol <> 0 Then
                '    GrdCatRel.Columns(1).ReadOnly = True
                '    GrdCatRel.Columns(2).ReadOnly = True
                'End If
            End If
        End If
        'rs_ZSITMLST.Tables("RESULT").AcceptChanges()

    End Sub

    Private Sub txtItmFm_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItmFm.GotFocus
        Call HighlightText(txtItmFm)
    End Sub

    Private Sub txtItmFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmFm.TextChanged
        txtItmTo.Text = txtItmFm.Text

    End Sub
    Public Sub HighlightText(ByVal t As TextBox)
        t.SelectionStart = 0
        t.SelectionLength = Len(t.Text)

    End Sub

    Private Sub txtItmTo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItmTo.GotFocus
        Call HighlightText(txtItmTo)

    End Sub

    Private Sub txtItmTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmTo.TextChanged

    End Sub

    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        Call cmdInsRow_Click()
    End Sub
End Class


