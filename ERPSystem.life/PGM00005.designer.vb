<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PGM00005
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PGM00005))
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBJNo = New System.Windows.Forms.TextBox
        Me.txtRunNoFrm = New System.Windows.Forms.TextBox
        Me.txtRunNoTo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdApply = New System.Windows.Forms.Button
        Me.dgBatchJob = New System.Windows.Forms.DataGridView
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.txtMsg = New System.Windows.Forms.TextBox
        Me.chkReGen = New System.Windows.Forms.CheckBox
        Me.cmdCalculate = New System.Windows.Forms.Button
        Me.PanelOpt = New System.Windows.Forms.Panel
        Me.cmdOptExit = New System.Windows.Forms.Button
        Me.cmdOptApply = New System.Windows.Forms.Button
        Me.rdoUCPItm = New System.Windows.Forms.RadioButton
        Me.rdoAssItm = New System.Windows.Forms.RadioButton
        Me.rdoSKU = New System.Windows.Forms.RadioButton
        Me.rdoPackItem = New System.Windows.Forms.RadioButton
        Me.PanelResult = New System.Windows.Forms.Panel
        Me.cmdRExit = New System.Windows.Forms.Button
        Me.lblTitle = New System.Windows.Forms.Label
        Me.dgCal = New System.Windows.Forms.DataGridView
        Me.chkReqWas = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbFilter_Ord = New System.Windows.Forms.RadioButton
        Me.rbFilter_Req = New System.Windows.Forms.RadioButton
        Me.rbFilter_All = New System.Windows.Forms.RadioButton
        Me.Label11 = New System.Windows.Forms.Label
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
        Me.StatusBar = New System.Windows.Forms.StatusStrip
        Me.lblLeft = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblRight = New System.Windows.Forms.ToolStripStatusLabel
        Me.txtCount = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbGenFmReq = New System.Windows.Forms.CheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cbGenFmItm = New System.Windows.Forms.CheckBox
        Me.gbGenDescFm = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.grpOutFmt = New System.Windows.Forms.GroupBox
        Me.optExcel = New System.Windows.Forms.RadioButton
        Me.optPDF = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtJobOrdFrm = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtJobOrdTo = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboRptFmt = New System.Windows.Forms.ComboBox
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.grpConfirm = New System.Windows.Forms.GroupBox
        Me.btnConfirm = New System.Windows.Forms.Button
        Me.rbNo = New System.Windows.Forms.RadioButton
        Me.rbYes = New System.Windows.Forms.RadioButton
        CType(Me.dgBatchJob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelOpt.SuspendLayout()
        Me.PanelResult.SuspendLayout()
        CType(Me.dgCal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.menuStrip.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.gbGenDescFm.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpOutFmt.SuspendLayout()
        Me.grpConfirm.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(143, 25)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(81, 20)
        Me.cboCoCde.TabIndex = 259
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(15, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 12)
        Me.Label1.TabIndex = 260
        Me.Label1.Text = "Company Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 12)
        Me.Label2.TabIndex = 261
        Me.Label2.Text = "Packaging Order No."
        '
        'txtBJNo
        '
        Me.txtBJNo.BackColor = System.Drawing.Color.White
        Me.txtBJNo.Location = New System.Drawing.Point(143, 49)
        Me.txtBJNo.Name = "txtBJNo"
        Me.txtBJNo.Size = New System.Drawing.Size(150, 22)
        Me.txtBJNo.TabIndex = 262
        '
        'txtRunNoFrm
        '
        Me.txtRunNoFrm.BackColor = System.Drawing.Color.White
        Me.txtRunNoFrm.Enabled = False
        Me.txtRunNoFrm.Location = New System.Drawing.Point(176, 74)
        Me.txtRunNoFrm.Name = "txtRunNoFrm"
        Me.txtRunNoFrm.Size = New System.Drawing.Size(150, 22)
        Me.txtRunNoFrm.TabIndex = 264
        '
        'txtRunNoTo
        '
        Me.txtRunNoTo.BackColor = System.Drawing.Color.White
        Me.txtRunNoTo.Enabled = False
        Me.txtRunNoTo.Location = New System.Drawing.Point(358, 74)
        Me.txtRunNoTo.Name = "txtRunNoTo"
        Me.txtRunNoTo.Size = New System.Drawing.Size(150, 22)
        Me.txtRunNoTo.TabIndex = 266
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(332, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 12)
        Me.Label4.TabIndex = 265
        Me.Label4.Text = "To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 12)
        Me.Label3.TabIndex = 263
        Me.Label3.Text = "Packaging Request No."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(140, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 12)
        Me.Label7.TabIndex = 271
        Me.Label7.Text = "From"
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(514, 74)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(63, 21)
        Me.cmdApply.TabIndex = 274
        Me.cmdApply.Text = "Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'dgBatchJob
        '
        Me.dgBatchJob.AllowUserToAddRows = False
        Me.dgBatchJob.AllowUserToDeleteRows = False
        Me.dgBatchJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBatchJob.Location = New System.Drawing.Point(9, 100)
        Me.dgBatchJob.Name = "dgBatchJob"
        Me.dgBatchJob.ReadOnly = True
        Me.dgBatchJob.RowTemplate.Height = 24
        Me.dgBatchJob.Size = New System.Drawing.Size(941, 402)
        Me.dgBatchJob.TabIndex = 277
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Location = New System.Drawing.Point(230, 25)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.ReadOnly = True
        Me.txtCoNam.Size = New System.Drawing.Size(360, 22)
        Me.txtCoNam.TabIndex = 280
        '
        'txtMsg
        '
        Me.txtMsg.BackColor = System.Drawing.Color.White
        Me.txtMsg.Location = New System.Drawing.Point(9, 508)
        Me.txtMsg.Multiline = True
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.Size = New System.Drawing.Size(941, 96)
        Me.txtMsg.TabIndex = 281
        '
        'chkReGen
        '
        Me.chkReGen.AutoSize = True
        Me.chkReGen.Location = New System.Drawing.Point(748, 56)
        Me.chkReGen.Name = "chkReGen"
        Me.chkReGen.Size = New System.Drawing.Size(75, 16)
        Me.chkReGen.TabIndex = 283
        Me.chkReGen.Text = "Re-Arange"
        Me.chkReGen.UseVisualStyleBackColor = True
        '
        'cmdCalculate
        '
        Me.cmdCalculate.Location = New System.Drawing.Point(874, 73)
        Me.cmdCalculate.Name = "cmdCalculate"
        Me.cmdCalculate.Size = New System.Drawing.Size(75, 21)
        Me.cmdCalculate.TabIndex = 284
        Me.cmdCalculate.Text = "Calculate"
        Me.cmdCalculate.UseVisualStyleBackColor = True
        '
        'PanelOpt
        '
        Me.PanelOpt.BackColor = System.Drawing.Color.SkyBlue
        Me.PanelOpt.Controls.Add(Me.cmdOptExit)
        Me.PanelOpt.Controls.Add(Me.cmdOptApply)
        Me.PanelOpt.Controls.Add(Me.rdoUCPItm)
        Me.PanelOpt.Controls.Add(Me.rdoAssItm)
        Me.PanelOpt.Controls.Add(Me.rdoSKU)
        Me.PanelOpt.Controls.Add(Me.rdoPackItem)
        Me.PanelOpt.Location = New System.Drawing.Point(192, 265)
        Me.PanelOpt.Name = "PanelOpt"
        Me.PanelOpt.Size = New System.Drawing.Size(334, 63)
        Me.PanelOpt.TabIndex = 285
        '
        'cmdOptExit
        '
        Me.cmdOptExit.Location = New System.Drawing.Point(242, 36)
        Me.cmdOptExit.Name = "cmdOptExit"
        Me.cmdOptExit.Size = New System.Drawing.Size(75, 21)
        Me.cmdOptExit.TabIndex = 5
        Me.cmdOptExit.Text = "Exit "
        Me.cmdOptExit.UseVisualStyleBackColor = True
        '
        'cmdOptApply
        '
        Me.cmdOptApply.Location = New System.Drawing.Point(242, 8)
        Me.cmdOptApply.Name = "cmdOptApply"
        Me.cmdOptApply.Size = New System.Drawing.Size(75, 21)
        Me.cmdOptApply.TabIndex = 4
        Me.cmdOptApply.Text = "Apply"
        Me.cmdOptApply.UseVisualStyleBackColor = True
        '
        'rdoUCPItm
        '
        Me.rdoUCPItm.AutoSize = True
        Me.rdoUCPItm.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.rdoUCPItm.Location = New System.Drawing.Point(135, 36)
        Me.rdoUCPItm.Name = "rdoUCPItm"
        Me.rdoUCPItm.Size = New System.Drawing.Size(85, 19)
        Me.rdoUCPItm.TabIndex = 3
        Me.rdoUCPItm.TabStop = True
        Me.rdoUCPItm.Text = "UCP Item#"
        Me.rdoUCPItm.UseVisualStyleBackColor = True
        '
        'rdoAssItm
        '
        Me.rdoAssItm.AutoSize = True
        Me.rdoAssItm.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.rdoAssItm.Location = New System.Drawing.Point(14, 36)
        Me.rdoAssItm.Name = "rdoAssItm"
        Me.rdoAssItm.Size = New System.Drawing.Size(73, 19)
        Me.rdoAssItm.TabIndex = 2
        Me.rdoAssItm.TabStop = True
        Me.rdoAssItm.Text = "Ass.Item"
        Me.rdoAssItm.UseVisualStyleBackColor = True
        '
        'rdoSKU
        '
        Me.rdoSKU.AutoSize = True
        Me.rdoSKU.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.rdoSKU.Location = New System.Drawing.Point(135, 11)
        Me.rdoSKU.Name = "rdoSKU"
        Me.rdoSKU.Size = New System.Drawing.Size(57, 19)
        Me.rdoSKU.TabIndex = 1
        Me.rdoSKU.TabStop = True
        Me.rdoSKU.Text = "SKU#"
        Me.rdoSKU.UseVisualStyleBackColor = True
        '
        'rdoPackItem
        '
        Me.rdoPackItem.AutoSize = True
        Me.rdoPackItem.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.rdoPackItem.Location = New System.Drawing.Point(14, 11)
        Me.rdoPackItem.Name = "rdoPackItem"
        Me.rdoPackItem.Size = New System.Drawing.Size(79, 19)
        Me.rdoPackItem.TabIndex = 0
        Me.rdoPackItem.TabStop = True
        Me.rdoPackItem.Text = "Pack.Item"
        Me.rdoPackItem.UseVisualStyleBackColor = True
        '
        'PanelResult
        '
        Me.PanelResult.BackColor = System.Drawing.Color.SkyBlue
        Me.PanelResult.Controls.Add(Me.cmdRExit)
        Me.PanelResult.Controls.Add(Me.lblTitle)
        Me.PanelResult.Controls.Add(Me.dgCal)
        Me.PanelResult.Location = New System.Drawing.Point(291, 205)
        Me.PanelResult.Name = "PanelResult"
        Me.PanelResult.Size = New System.Drawing.Size(642, 170)
        Me.PanelResult.TabIndex = 286
        '
        'cmdRExit
        '
        Me.cmdRExit.Location = New System.Drawing.Point(564, 3)
        Me.cmdRExit.Name = "cmdRExit"
        Me.cmdRExit.Size = New System.Drawing.Size(75, 21)
        Me.cmdRExit.TabIndex = 2
        Me.cmdRExit.Text = "Exit"
        Me.cmdRExit.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblTitle.Location = New System.Drawing.Point(22, 7)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(52, 15)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "Label10"
        '
        'dgCal
        '
        Me.dgCal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCal.Location = New System.Drawing.Point(3, 26)
        Me.dgCal.Name = "dgCal"
        Me.dgCal.RowTemplate.Height = 24
        Me.dgCal.Size = New System.Drawing.Size(636, 140)
        Me.dgCal.TabIndex = 0
        '
        'chkReqWas
        '
        Me.chkReqWas.AutoSize = True
        Me.chkReqWas.Location = New System.Drawing.Point(748, 77)
        Me.chkReqWas.Name = "chkReqWas"
        Me.chkReqWas.Size = New System.Drawing.Size(102, 16)
        Me.chkReqWas.TabIndex = 287
        Me.chkReqWas.Text = "By Req Wastage"
        Me.chkReqWas.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbFilter_Ord)
        Me.GroupBox1.Controls.Add(Me.rbFilter_Req)
        Me.GroupBox1.Controls.Add(Me.rbFilter_All)
        Me.GroupBox1.Location = New System.Drawing.Point(664, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(285, 35)
        Me.GroupBox1.TabIndex = 291
        Me.GroupBox1.TabStop = False
        '
        'rbFilter_Ord
        '
        Me.rbFilter_Ord.AutoSize = True
        Me.rbFilter_Ord.Location = New System.Drawing.Point(147, 12)
        Me.rbFilter_Ord.Name = "rbFilter_Ord"
        Me.rbFilter_Ord.Size = New System.Drawing.Size(113, 16)
        Me.rbFilter_Ord.TabIndex = 2
        Me.rbFilter_Ord.TabStop = True
        Me.rbFilter_Ord.Text = "Request with Order"
        Me.rbFilter_Ord.UseVisualStyleBackColor = True
        '
        'rbFilter_Req
        '
        Me.rbFilter_Req.AutoSize = True
        Me.rbFilter_Req.Location = New System.Drawing.Point(52, 12)
        Me.rbFilter_Req.Name = "rbFilter_Req"
        Me.rbFilter_Req.Size = New System.Drawing.Size(86, 16)
        Me.rbFilter_Req.TabIndex = 1
        Me.rbFilter_Req.Text = "Request Only"
        Me.rbFilter_Req.UseVisualStyleBackColor = True
        '
        'rbFilter_All
        '
        Me.rbFilter_All.AutoSize = True
        Me.rbFilter_All.Checked = True
        Me.rbFilter_All.Location = New System.Drawing.Point(6, 12)
        Me.rbFilter_All.Name = "rbFilter_All"
        Me.rbFilter_All.Size = New System.Drawing.Size(37, 16)
        Me.rbFilter_All.TabIndex = 0
        Me.rbFilter_All.TabStop = True
        Me.rbFilter_All.Text = "All"
        Me.rbFilter_All.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(625, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 12)
        Me.Label11.TabIndex = 292
        Me.Label11.Text = "Filter"
        '
        'menuStrip
        '
        Me.menuStrip.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdAdd, Me.mmdSave, Me.mmdDelete, Me.mmdCopy, Me.mmdFind, Me.t1, Me.mmdClear, Me.t2, Me.mmdSearch, Me.t3, Me.mmdInsRow, Me.mmdDelRow, Me.t4, Me.mmdPrint, Me.t5, Me.mmdAttach, Me.t6, Me.mmdFunction, Me.t7, Me.mmdLink, Me.t8, Me.mmdExit})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuStrip.Size = New System.Drawing.Size(954, 24)
        Me.menuStrip.TabIndex = 2109
        Me.menuStrip.Text = "MenuStrip1"
        '
        'mmdAdd
        '
        Me.mmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.mmdAdd.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdAdd.Name = "mmdAdd"
        Me.mmdAdd.Size = New System.Drawing.Size(40, 20)
        Me.mmdAdd.Tag = "Add"
        Me.mmdAdd.Text = "&Add"
        '
        'mmdSave
        '
        Me.mmdSave.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdSave.Name = "mmdSave"
        Me.mmdSave.Size = New System.Drawing.Size(46, 20)
        Me.mmdSave.Text = "&Save"
        '
        'mmdDelete
        '
        Me.mmdDelete.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdDelete.Name = "mmdDelete"
        Me.mmdDelete.Size = New System.Drawing.Size(55, 20)
        Me.mmdDelete.Text = "&Delete"
        '
        'mmdCopy
        '
        Me.mmdCopy.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdCopy.Name = "mmdCopy"
        Me.mmdCopy.Size = New System.Drawing.Size(47, 20)
        Me.mmdCopy.Text = "&Copy"
        '
        'mmdFind
        '
        Me.mmdFind.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdFind.Name = "mmdFind"
        Me.mmdFind.Size = New System.Drawing.Size(43, 20)
        Me.mmdFind.Text = "&Find"
        '
        't1
        '
        Me.t1.AutoSize = False
        Me.t1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t1.Enabled = False
        Me.t1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(8, 20)
        Me.t1.Text = "|"
        '
        'mmdClear
        '
        Me.mmdClear.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdClear.Name = "mmdClear"
        Me.mmdClear.Size = New System.Drawing.Size(49, 20)
        Me.mmdClear.Text = "Cl&ear"
        '
        't2
        '
        Me.t2.AutoSize = False
        Me.t2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t2.Enabled = False
        Me.t2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(8, 20)
        Me.t2.Text = "|"
        '
        'mmdSearch
        '
        Me.mmdSearch.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdSearch.Name = "mmdSearch"
        Me.mmdSearch.Size = New System.Drawing.Size(58, 20)
        Me.mmdSearch.Text = "Searc&h"
        '
        't3
        '
        Me.t3.AutoSize = False
        Me.t3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t3.Enabled = False
        Me.t3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t3.Name = "t3"
        Me.t3.Size = New System.Drawing.Size(8, 20)
        Me.t3.Text = "|"
        '
        'mmdInsRow
        '
        Me.mmdInsRow.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdInsRow.Name = "mmdInsRow"
        Me.mmdInsRow.Size = New System.Drawing.Size(64, 20)
        Me.mmdInsRow.Text = "In&s Row"
        '
        'mmdDelRow
        '
        Me.mmdDelRow.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdDelRow.Name = "mmdDelRow"
        Me.mmdDelRow.Size = New System.Drawing.Size(66, 20)
        Me.mmdDelRow.Text = "Del Ro&w"
        '
        't4
        '
        Me.t4.AutoSize = False
        Me.t4.Enabled = False
        Me.t4.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t4.Name = "t4"
        Me.t4.Size = New System.Drawing.Size(8, 20)
        Me.t4.Text = "|"
        '
        'mmdPrint
        '
        Me.mmdPrint.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdPrint.Name = "mmdPrint"
        Me.mmdPrint.Size = New System.Drawing.Size(44, 20)
        Me.mmdPrint.Text = "&Print"
        '
        't5
        '
        Me.t5.AutoSize = False
        Me.t5.Enabled = False
        Me.t5.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t5.Name = "t5"
        Me.t5.Size = New System.Drawing.Size(8, 20)
        Me.t5.Text = "|"
        '
        'mmdAttach
        '
        Me.mmdAttach.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdAttach.Name = "mmdAttach"
        Me.mmdAttach.Size = New System.Drawing.Size(52, 20)
        Me.mmdAttach.Text = "Attach"
        '
        't6
        '
        Me.t6.AutoSize = False
        Me.t6.Enabled = False
        Me.t6.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t6.Name = "t6"
        Me.t6.Size = New System.Drawing.Size(8, 20)
        Me.t6.Text = "|"
        '
        'mmdFunction
        '
        Me.mmdFunction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdRel, Me.mmdApv})
        Me.mmdFunction.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdFunction.Name = "mmdFunction"
        Me.mmdFunction.Size = New System.Drawing.Size(66, 20)
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
        Me.t7.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t7.Name = "t7"
        Me.t7.Size = New System.Drawing.Size(8, 20)
        Me.t7.Text = "|"
        '
        'mmdLink
        '
        Me.mmdLink.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdLink.Name = "mmdLink"
        Me.mmdLink.Size = New System.Drawing.Size(42, 20)
        Me.mmdLink.Text = "Link"
        '
        't8
        '
        Me.t8.AutoSize = False
        Me.t8.Enabled = False
        Me.t8.Font = New System.Drawing.Font("Arial", 9.0!)
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
        'StatusBar
        '
        Me.StatusBar.AutoSize = False
        Me.StatusBar.GripMargin = New System.Windows.Forms.Padding(0)
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblLeft, Me.lblRight})
        Me.StatusBar.Location = New System.Drawing.Point(0, 611)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(954, 24)
        Me.StatusBar.TabIndex = 2110
        Me.StatusBar.Text = "StatusStrip1"
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = False
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(400, 19)
        Me.lblLeft.Text = "Init"
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRight
        '
        Me.lblRight.AutoSize = False
        Me.lblRight.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(539, 19)
        Me.lblRight.Spring = True
        Me.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCount
        '
        Me.txtCount.BackColor = System.Drawing.Color.White
        Me.txtCount.Location = New System.Drawing.Point(394, 54)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(99, 22)
        Me.txtCount.TabIndex = 279
        Me.txtCount.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(398, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 12)
        Me.Label9.TabIndex = 278
        Me.Label9.Text = "Record Count"
        Me.Label9.Visible = False
        '
        'cbGenFmReq
        '
        Me.cbGenFmReq.AutoSize = True
        Me.cbGenFmReq.Checked = True
        Me.cbGenFmReq.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbGenFmReq.Location = New System.Drawing.Point(13, 25)
        Me.cbGenFmReq.Name = "cbGenFmReq"
        Me.cbGenFmReq.Size = New System.Drawing.Size(61, 16)
        Me.cbGenFmReq.TabIndex = 0
        Me.cbGenFmReq.Text = "Request"
        Me.cbGenFmReq.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(154, 12)
        Me.Label10.TabIndex = 290
        Me.Label10.Text = "Generate Item Description From"
        Me.Label10.Visible = False
        '
        'cbGenFmItm
        '
        Me.cbGenFmItm.AutoSize = True
        Me.cbGenFmItm.Location = New System.Drawing.Point(108, 25)
        Me.cbGenFmItm.Name = "cbGenFmItm"
        Me.cbGenFmItm.Size = New System.Drawing.Size(79, 16)
        Me.cbGenFmItm.TabIndex = 1
        Me.cbGenFmItm.Text = "Item Master"
        Me.cbGenFmItm.UseVisualStyleBackColor = True
        '
        'gbGenDescFm
        '
        Me.gbGenDescFm.Controls.Add(Me.cbGenFmItm)
        Me.gbGenDescFm.Controls.Add(Me.Label10)
        Me.gbGenDescFm.Controls.Add(Me.cbGenFmReq)
        Me.gbGenDescFm.Controls.Add(Me.GroupBox2)
        Me.gbGenDescFm.Location = New System.Drawing.Point(400, 47)
        Me.gbGenDescFm.Name = "gbGenDescFm"
        Me.gbGenDescFm.Size = New System.Drawing.Size(109, 23)
        Me.gbGenDescFm.TabIndex = 288
        Me.gbGenDescFm.TabStop = False
        Me.gbGenDescFm.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.grpOutFmt)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtJobOrdFrm)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtJobOrdTo)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cboRptFmt)
        Me.GroupBox2.Controls.Add(Me.cmdPrint)
        Me.GroupBox2.Location = New System.Drawing.Point(54, 18)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(55, 19)
        Me.GroupBox2.TabIndex = 289
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "No Use"
        Me.GroupBox2.Visible = False
        '
        'grpOutFmt
        '
        Me.grpOutFmt.Controls.Add(Me.optExcel)
        Me.grpOutFmt.Controls.Add(Me.optPDF)
        Me.grpOutFmt.Location = New System.Drawing.Point(20, 21)
        Me.grpOutFmt.Name = "grpOutFmt"
        Me.grpOutFmt.Size = New System.Drawing.Size(58, 21)
        Me.grpOutFmt.TabIndex = 276
        Me.grpOutFmt.TabStop = False
        Me.grpOutFmt.Text = "Output Format"
        Me.grpOutFmt.Visible = False
        '
        'optExcel
        '
        Me.optExcel.AutoSize = True
        Me.optExcel.Location = New System.Drawing.Point(111, 18)
        Me.optExcel.Name = "optExcel"
        Me.optExcel.Size = New System.Drawing.Size(49, 16)
        Me.optExcel.TabIndex = 1
        Me.optExcel.TabStop = True
        Me.optExcel.Text = "Excel"
        Me.optExcel.UseVisualStyleBackColor = True
        '
        'optPDF
        '
        Me.optPDF.AutoSize = True
        Me.optPDF.Location = New System.Drawing.Point(39, 18)
        Me.optPDF.Name = "optPDF"
        Me.optPDF.Size = New System.Drawing.Size(43, 16)
        Me.optPDF.TabIndex = 0
        Me.optPDF.TabStop = True
        Me.optPDF.Text = "PDF"
        Me.optPDF.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 12)
        Me.Label6.TabIndex = 267
        Me.Label6.Text = "Packaging Order No."
        Me.Label6.Visible = False
        '
        'txtJobOrdFrm
        '
        Me.txtJobOrdFrm.BackColor = System.Drawing.Color.White
        Me.txtJobOrdFrm.Location = New System.Drawing.Point(167, 24)
        Me.txtJobOrdFrm.Name = "txtJobOrdFrm"
        Me.txtJobOrdFrm.Size = New System.Drawing.Size(11, 22)
        Me.txtJobOrdFrm.TabIndex = 268
        Me.txtJobOrdFrm.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(184, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 12)
        Me.Label5.TabIndex = 269
        Me.Label5.Text = "To"
        Me.Label5.Visible = False
        '
        'txtJobOrdTo
        '
        Me.txtJobOrdTo.BackColor = System.Drawing.Color.White
        Me.txtJobOrdTo.Location = New System.Drawing.Point(210, 24)
        Me.txtJobOrdTo.Name = "txtJobOrdTo"
        Me.txtJobOrdTo.Size = New System.Drawing.Size(10, 22)
        Me.txtJobOrdTo.TabIndex = 270
        Me.txtJobOrdTo.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(131, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 12)
        Me.Label8.TabIndex = 272
        Me.Label8.Text = "From"
        Me.Label8.Visible = False
        '
        'cboRptFmt
        '
        Me.cboRptFmt.BackColor = System.Drawing.Color.White
        Me.cboRptFmt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRptFmt.FormattingEnabled = True
        Me.cboRptFmt.Location = New System.Drawing.Point(98, 18)
        Me.cboRptFmt.Name = "cboRptFmt"
        Me.cboRptFmt.Size = New System.Drawing.Size(30, 20)
        Me.cboRptFmt.TabIndex = 273
        Me.cboRptFmt.Visible = False
        '
        'cmdPrint
        '
        Me.cmdPrint.Location = New System.Drawing.Point(241, 22)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(18, 21)
        Me.cmdPrint.TabIndex = 275
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        Me.cmdPrint.Visible = False
        '
        'grpConfirm
        '
        Me.grpConfirm.Controls.Add(Me.btnConfirm)
        Me.grpConfirm.Controls.Add(Me.rbNo)
        Me.grpConfirm.Controls.Add(Me.rbYes)
        Me.grpConfirm.Location = New System.Drawing.Point(595, 63)
        Me.grpConfirm.Name = "grpConfirm"
        Me.grpConfirm.Size = New System.Drawing.Size(147, 33)
        Me.grpConfirm.TabIndex = 2111
        Me.grpConfirm.TabStop = False
        Me.grpConfirm.Text = "Confirm"
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(78, 9)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(58, 21)
        Me.btnConfirm.TabIndex = 2
        Me.btnConfirm.Text = "Confirm"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'rbNo
        '
        Me.rbNo.AutoSize = True
        Me.rbNo.Checked = True
        Me.rbNo.Location = New System.Drawing.Point(44, 13)
        Me.rbNo.Name = "rbNo"
        Me.rbNo.Size = New System.Drawing.Size(31, 16)
        Me.rbNo.TabIndex = 1
        Me.rbNo.TabStop = True
        Me.rbNo.Text = "N"
        Me.rbNo.UseVisualStyleBackColor = True
        '
        'rbYes
        '
        Me.rbYes.AutoSize = True
        Me.rbYes.Location = New System.Drawing.Point(7, 13)
        Me.rbYes.Name = "rbYes"
        Me.rbYes.Size = New System.Drawing.Size(31, 16)
        Me.rbYes.TabIndex = 0
        Me.rbYes.Text = "Y"
        Me.rbYes.UseVisualStyleBackColor = True
        '
        'PGM00005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 635)
        Me.Controls.Add(Me.grpConfirm)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtCount)
        Me.Controls.Add(Me.gbGenDescFm)
        Me.Controls.Add(Me.PanelOpt)
        Me.Controls.Add(Me.chkReqWas)
        Me.Controls.Add(Me.PanelResult)
        Me.Controls.Add(Me.cmdCalculate)
        Me.Controls.Add(Me.chkReGen)
        Me.Controls.Add(Me.txtMsg)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dgBatchJob)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtRunNoTo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtRunNoFrm)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBJNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuStrip
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(960, 660)
        Me.MinimumSize = New System.Drawing.Size(960, 660)
        Me.Name = "PGM00005"
        Me.Text = "PGM00005 - Packaging Order Generation and Update (PGM05)"
        CType(Me.dgBatchJob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelOpt.ResumeLayout(False)
        Me.PanelOpt.PerformLayout()
        Me.PanelResult.ResumeLayout(False)
        Me.PanelResult.PerformLayout()
        CType(Me.dgCal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.gbGenDescFm.ResumeLayout(False)
        Me.gbGenDescFm.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpOutFmt.ResumeLayout(False)
        Me.grpOutFmt.PerformLayout()
        Me.grpConfirm.ResumeLayout(False)
        Me.grpConfirm.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBJNo As System.Windows.Forms.TextBox
    Friend WithEvents txtRunNoFrm As System.Windows.Forms.TextBox
    Friend WithEvents txtRunNoTo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents dgBatchJob As System.Windows.Forms.DataGridView
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents txtMsg As System.Windows.Forms.TextBox
    Friend WithEvents cmdCalculate As System.Windows.Forms.Button
    Friend WithEvents PanelOpt As System.Windows.Forms.Panel
    Friend WithEvents rdoUCPItm As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAssItm As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSKU As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPackItem As System.Windows.Forms.RadioButton
    Friend WithEvents PanelResult As System.Windows.Forms.Panel
    Friend WithEvents cmdOptApply As System.Windows.Forms.Button
    Friend WithEvents dgCal As System.Windows.Forms.DataGridView
    Friend WithEvents cmdRExit As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents cmdOptExit As System.Windows.Forms.Button
    Friend WithEvents chkReqWas As System.Windows.Forms.CheckBox
    Friend WithEvents chkReGen As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbFilter_Req As System.Windows.Forms.RadioButton
    Friend WithEvents rbFilter_All As System.Windows.Forms.RadioButton
    Friend WithEvents rbFilter_Ord As System.Windows.Forms.RadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
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
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRight As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtCount As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbGenFmReq As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbGenFmItm As System.Windows.Forms.CheckBox
    Friend WithEvents gbGenDescFm As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cboRptFmt As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtJobOrdTo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtJobOrdFrm As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents grpOutFmt As System.Windows.Forms.GroupBox
    Friend WithEvents optExcel As System.Windows.Forms.RadioButton
    Friend WithEvents optPDF As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grpConfirm As System.Windows.Forms.GroupBox
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents rbNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbYes As System.Windows.Forms.RadioButton
End Class
