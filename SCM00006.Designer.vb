<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SCM00006
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SCM00006))
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
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
        Me.StatusBar = New System.Windows.Forms.StatusStrip
        Me.lblLeft = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblRight = New System.Windows.Forms.ToolStripStatusLabel
        Me.tabFrame = New ERPSystem.BaseTabControl
        Me.tabFrame_Search = New System.Windows.Forms.TabPage
        Me.grpSearch = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtSCRvsdatTo = New System.Windows.Forms.MaskedTextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtSCRvsdatFm = New System.Windows.Forms.MaskedTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_S_ItmNo = New System.Windows.Forms.TextBox
        Me.cmd_S_ItmNo = New System.Windows.Forms.Button
        Me.txt_S_SCNo = New System.Windows.Forms.TextBox
        Me.cmd_S_SCNo = New System.Windows.Forms.Button
        Me.txt_S_SecCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_SecCust = New System.Windows.Forms.Button
        Me.txt_S_PriCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_PriCust = New System.Windows.Forms.Button
        Me.txt_S_CoCde = New System.Windows.Forms.TextBox
        Me.cmd_S_CoCde = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tabFrame_Header = New System.Windows.Forms.TabPage
        Me.grpHeader = New System.Windows.Forms.GroupBox
        Me.cmdHdrApvApply = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbHdrApv_W = New System.Windows.Forms.RadioButton
        Me.rbHdrApv_Y = New System.Windows.Forms.RadioButton
        Me.lblPricing = New System.Windows.Forms.Label
        Me.gbPriceView = New System.Windows.Forms.GroupBox
        Me.rbHdrApvFilter_CloseOut = New System.Windows.Forms.RadioButton
        Me.rbHdrApvFilter_Replacement = New System.Windows.Forms.RadioButton
        Me.rbHdrApvFilter_PaymentTerm = New System.Windows.Forms.RadioButton
        Me.rbHdrApvFilter_PriceTerm = New System.Windows.Forms.RadioButton
        Me.rbHdrApvFilter_All = New System.Windows.Forms.RadioButton
        Me.grpHdrAprv = New System.Windows.Forms.GroupBox
        Me.cmdHdrApply = New System.Windows.Forms.Button
        Me.cmdHdrSelectAll = New System.Windows.Forms.Button
        Me.optHdrAprvY = New System.Windows.Forms.RadioButton
        Me.optHdrAprvW = New System.Windows.Forms.RadioButton
        Me.optHdrAprvN = New System.Windows.Forms.RadioButton
        Me.dgHeader = New System.Windows.Forms.DataGridView
        Me.tabFrame_Detail = New System.Windows.Forms.TabPage
        Me.grpDetail = New System.Windows.Forms.GroupBox
        Me.cmdDtlApvApply = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.rbDtlApv_W = New System.Windows.Forms.RadioButton
        Me.rbDtlApv_Y = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbDtlApvFilter_ChgSelPrc = New System.Windows.Forms.RadioButton
        Me.rbDtlApvFilter_ChgDVPVFtyCst = New System.Windows.Forms.RadioButton
        Me.rbDtlApvFilter_OneTime = New System.Windows.Forms.RadioButton
        Me.rbDtlApvFilter_BelowMinMU = New System.Windows.Forms.RadioButton
        Me.rbDtlApvFilter_MOQ = New System.Windows.Forms.RadioButton
        Me.rbDtlApvFilter_All = New System.Windows.Forms.RadioButton
        Me.dgDetail = New System.Windows.Forms.DataGridView
        Me.txtRvsDat = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtSecCus = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtPriCus = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtOrdSts = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtSCNo = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdDtlApply = New System.Windows.Forms.Button
        Me.cmdDtlSelectAll = New System.Windows.Forms.Button
        Me.optDtlAprvY = New System.Windows.Forms.RadioButton
        Me.optDtlAprvW = New System.Windows.Forms.RadioButton
        Me.optDtlAprvN = New System.Windows.Forms.RadioButton
        Me.txtCoCde = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.menuStrip.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.tabFrame.SuspendLayout()
        Me.tabFrame_Search.SuspendLayout()
        Me.grpSearch.SuspendLayout()
        Me.tabFrame_Header.SuspendLayout()
        Me.grpHeader.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbPriceView.SuspendLayout()
        Me.grpHdrAprv.SuspendLayout()
        CType(Me.dgHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabFrame_Detail.SuspendLayout()
        Me.grpDetail.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(116, 10)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(127, 17)
        Me.RadioButton1.TabIndex = 64
        Me.RadioButton1.Text = "W - Wait for Approval"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(16, 9)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(83, 17)
        Me.RadioButton2.TabIndex = 63
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Y - Approval"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(116, 10)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(127, 17)
        Me.RadioButton3.TabIndex = 64
        Me.RadioButton3.Text = "W - Wait for Approval"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Checked = True
        Me.RadioButton4.Location = New System.Drawing.Point(16, 9)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(83, 17)
        Me.RadioButton4.TabIndex = 63
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Y - Approval"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'menuStrip
        '
        Me.menuStrip.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdAdd, Me.mmdSave, Me.mmdDelete, Me.mmdCopy, Me.mmdFind, Me.t1, Me.mmdClear, Me.t2, Me.mmdSearch, Me.t3, Me.mmdInsRow, Me.mmdDelRow, Me.t4, Me.mmdPrint, Me.t5, Me.mmdAttach, Me.t6, Me.mmdFunction, Me.t7, Me.mmdLink, Me.t8, Me.mmdExit})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuStrip.Size = New System.Drawing.Size(944, 24)
        Me.menuStrip.TabIndex = 296
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
        Me.mmdInsRow.Text = "In&s Row"
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
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblLeft, Me.lblRight})
        Me.StatusBar.Location = New System.Drawing.Point(0, 598)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(944, 24)
        Me.StatusBar.TabIndex = 297
        Me.StatusBar.Text = "StatusStrip1"
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = False
        Me.lblLeft.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(464, 19)
        Me.lblLeft.Spring = True
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRight
        '
        Me.lblRight.AutoSize = False
        Me.lblRight.Font = New System.Drawing.Font("PMingLiU", 9.0!)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(464, 19)
        Me.lblRight.Spring = True
        Me.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabFrame
        '
        Me.tabFrame.Controls.Add(Me.tabFrame_Search)
        Me.tabFrame.Controls.Add(Me.tabFrame_Header)
        Me.tabFrame.Controls.Add(Me.tabFrame_Detail)
        Me.tabFrame.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tabFrame.ItemSize = New System.Drawing.Size(100, 20)
        Me.tabFrame.Location = New System.Drawing.Point(0, 27)
        Me.tabFrame.Name = "tabFrame"
        Me.tabFrame.SelectedIndex = 0
        Me.tabFrame.Size = New System.Drawing.Size(944, 571)
        Me.tabFrame.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabFrame.TabIndex = 294
        '
        'tabFrame_Search
        '
        Me.tabFrame_Search.Controls.Add(Me.grpSearch)
        Me.tabFrame_Search.Location = New System.Drawing.Point(4, 24)
        Me.tabFrame_Search.Name = "tabFrame_Search"
        Me.tabFrame_Search.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFrame_Search.Size = New System.Drawing.Size(936, 543)
        Me.tabFrame_Search.TabIndex = 0
        Me.tabFrame_Search.Text = "(1) Search"
        Me.tabFrame_Search.UseVisualStyleBackColor = True
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.Label16)
        Me.grpSearch.Controls.Add(Me.Label15)
        Me.grpSearch.Controls.Add(Me.txtSCRvsdatTo)
        Me.grpSearch.Controls.Add(Me.Label8)
        Me.grpSearch.Controls.Add(Me.txtSCRvsdatFm)
        Me.grpSearch.Controls.Add(Me.Label7)
        Me.grpSearch.Controls.Add(Me.txt_S_ItmNo)
        Me.grpSearch.Controls.Add(Me.cmd_S_ItmNo)
        Me.grpSearch.Controls.Add(Me.txt_S_SCNo)
        Me.grpSearch.Controls.Add(Me.cmd_S_SCNo)
        Me.grpSearch.Controls.Add(Me.txt_S_SecCustAll)
        Me.grpSearch.Controls.Add(Me.cmd_S_SecCust)
        Me.grpSearch.Controls.Add(Me.txt_S_PriCustAll)
        Me.grpSearch.Controls.Add(Me.cmd_S_PriCust)
        Me.grpSearch.Controls.Add(Me.txt_S_CoCde)
        Me.grpSearch.Controls.Add(Me.cmd_S_CoCde)
        Me.grpSearch.Controls.Add(Me.Label6)
        Me.grpSearch.Controls.Add(Me.Label5)
        Me.grpSearch.Controls.Add(Me.Label4)
        Me.grpSearch.Controls.Add(Me.Label3)
        Me.grpSearch.Controls.Add(Me.Label2)
        Me.grpSearch.Controls.Add(Me.Label1)
        Me.grpSearch.Location = New System.Drawing.Point(1, -3)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(931, 545)
        Me.grpSearch.TabIndex = 0
        Me.grpSearch.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(417, 317)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 12)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "MM/DD/YYYY"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(197, 317)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 12)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "MM/DD/YYYY"
        '
        'txtSCRvsdatTo
        '
        Me.txtSCRvsdatTo.Location = New System.Drawing.Point(418, 296)
        Me.txtSCRvsdatTo.Mask = "00/00/0000"
        Me.txtSCRvsdatTo.Name = "txtSCRvsdatTo"
        Me.txtSCRvsdatTo.Size = New System.Drawing.Size(100, 22)
        Me.txtSCRvsdatTo.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(382, 299)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 12)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "To"
        '
        'txtSCRvsdatFm
        '
        Me.txtSCRvsdatFm.Location = New System.Drawing.Point(199, 296)
        Me.txtSCRvsdatFm.Mask = "00/00/0000"
        Me.txtSCRvsdatFm.Name = "txtSCRvsdatFm"
        Me.txtSCRvsdatFm.Size = New System.Drawing.Size(100, 22)
        Me.txtSCRvsdatFm.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(148, 299)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 12)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "From"
        '
        'txt_S_ItmNo
        '
        Me.txt_S_ItmNo.Location = New System.Drawing.Point(199, 253)
        Me.txt_S_ItmNo.Name = "txt_S_ItmNo"
        Me.txt_S_ItmNo.Size = New System.Drawing.Size(707, 22)
        Me.txt_S_ItmNo.TabIndex = 15
        '
        'cmd_S_ItmNo
        '
        Me.cmd_S_ItmNo.Location = New System.Drawing.Point(125, 252)
        Me.cmd_S_ItmNo.Name = "cmd_S_ItmNo"
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_ItmNo.TabIndex = 14
        Me.cmd_S_ItmNo.Text = ">>"
        Me.cmd_S_ItmNo.UseVisualStyleBackColor = True
        '
        'txt_S_SCNo
        '
        Me.txt_S_SCNo.Location = New System.Drawing.Point(199, 211)
        Me.txt_S_SCNo.Name = "txt_S_SCNo"
        Me.txt_S_SCNo.Size = New System.Drawing.Size(707, 22)
        Me.txt_S_SCNo.TabIndex = 13
        '
        'cmd_S_SCNo
        '
        Me.cmd_S_SCNo.Location = New System.Drawing.Point(125, 209)
        Me.cmd_S_SCNo.Name = "cmd_S_SCNo"
        Me.cmd_S_SCNo.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_SCNo.TabIndex = 12
        Me.cmd_S_SCNo.Text = ">>"
        Me.cmd_S_SCNo.UseVisualStyleBackColor = True
        '
        'txt_S_SecCustAll
        '
        Me.txt_S_SecCustAll.Location = New System.Drawing.Point(199, 169)
        Me.txt_S_SecCustAll.Name = "txt_S_SecCustAll"
        Me.txt_S_SecCustAll.Size = New System.Drawing.Size(707, 22)
        Me.txt_S_SecCustAll.TabIndex = 11
        '
        'cmd_S_SecCust
        '
        Me.cmd_S_SecCust.Location = New System.Drawing.Point(125, 167)
        Me.cmd_S_SecCust.Name = "cmd_S_SecCust"
        Me.cmd_S_SecCust.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_SecCust.TabIndex = 10
        Me.cmd_S_SecCust.Text = ">>"
        Me.cmd_S_SecCust.UseVisualStyleBackColor = True
        '
        'txt_S_PriCustAll
        '
        Me.txt_S_PriCustAll.Location = New System.Drawing.Point(199, 126)
        Me.txt_S_PriCustAll.Name = "txt_S_PriCustAll"
        Me.txt_S_PriCustAll.Size = New System.Drawing.Size(707, 22)
        Me.txt_S_PriCustAll.TabIndex = 9
        '
        'cmd_S_PriCust
        '
        Me.cmd_S_PriCust.Location = New System.Drawing.Point(125, 124)
        Me.cmd_S_PriCust.Name = "cmd_S_PriCust"
        Me.cmd_S_PriCust.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_PriCust.TabIndex = 8
        Me.cmd_S_PriCust.Text = ">>"
        Me.cmd_S_PriCust.UseVisualStyleBackColor = True
        '
        'txt_S_CoCde
        '
        Me.txt_S_CoCde.Location = New System.Drawing.Point(199, 81)
        Me.txt_S_CoCde.Name = "txt_S_CoCde"
        Me.txt_S_CoCde.Size = New System.Drawing.Size(707, 22)
        Me.txt_S_CoCde.TabIndex = 7
        '
        'cmd_S_CoCde
        '
        Me.cmd_S_CoCde.Location = New System.Drawing.Point(125, 79)
        Me.cmd_S_CoCde.Name = "cmd_S_CoCde"
        Me.cmd_S_CoCde.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_CoCde.TabIndex = 6
        Me.cmd_S_CoCde.Text = ">>"
        Me.cmd_S_CoCde.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 299)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 12)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "SC Revised Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 256)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 12)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Item No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 214)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "SC No."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 172)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Sec. Customer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Pri. Customer"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Code"
        '
        'tabFrame_Header
        '
        Me.tabFrame_Header.Controls.Add(Me.grpHeader)
        Me.tabFrame_Header.Location = New System.Drawing.Point(4, 24)
        Me.tabFrame_Header.Name = "tabFrame_Header"
        Me.tabFrame_Header.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFrame_Header.Size = New System.Drawing.Size(936, 543)
        Me.tabFrame_Header.TabIndex = 1
        Me.tabFrame_Header.Text = "(2) Header"
        Me.tabFrame_Header.UseVisualStyleBackColor = True
        '
        'grpHeader
        '
        Me.grpHeader.Controls.Add(Me.cmdHdrApvApply)
        Me.grpHeader.Controls.Add(Me.GroupBox3)
        Me.grpHeader.Controls.Add(Me.lblPricing)
        Me.grpHeader.Controls.Add(Me.gbPriceView)
        Me.grpHeader.Controls.Add(Me.grpHdrAprv)
        Me.grpHeader.Controls.Add(Me.dgHeader)
        Me.grpHeader.Location = New System.Drawing.Point(1, -3)
        Me.grpHeader.Name = "grpHeader"
        Me.grpHeader.Size = New System.Drawing.Size(932, 544)
        Me.grpHeader.TabIndex = 1
        Me.grpHeader.TabStop = False
        '
        'cmdHdrApvApply
        '
        Me.cmdHdrApvApply.Location = New System.Drawing.Point(866, 20)
        Me.cmdHdrApvApply.Name = "cmdHdrApvApply"
        Me.cmdHdrApvApply.Size = New System.Drawing.Size(55, 22)
        Me.cmdHdrApvApply.TabIndex = 94
        Me.cmdHdrApvApply.Text = "Apply"
        Me.cmdHdrApvApply.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbHdrApv_W)
        Me.GroupBox3.Controls.Add(Me.rbHdrApv_Y)
        Me.GroupBox3.Location = New System.Drawing.Point(607, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(237, 32)
        Me.GroupBox3.TabIndex = 93
        Me.GroupBox3.TabStop = False
        '
        'rbHdrApv_W
        '
        Me.rbHdrApv_W.AutoSize = True
        Me.rbHdrApv_W.Location = New System.Drawing.Point(99, 10)
        Me.rbHdrApv_W.Name = "rbHdrApv_W"
        Me.rbHdrApv_W.Size = New System.Drawing.Size(130, 16)
        Me.rbHdrApv_W.TabIndex = 64
        Me.rbHdrApv_W.Text = "W - Wait for Approval"
        Me.rbHdrApv_W.UseVisualStyleBackColor = True
        '
        'rbHdrApv_Y
        '
        Me.rbHdrApv_Y.AutoSize = True
        Me.rbHdrApv_Y.Checked = True
        Me.rbHdrApv_Y.Location = New System.Drawing.Point(10, 10)
        Me.rbHdrApv_Y.Name = "rbHdrApv_Y"
        Me.rbHdrApv_Y.Size = New System.Drawing.Size(85, 16)
        Me.rbHdrApv_Y.TabIndex = 63
        Me.rbHdrApv_Y.TabStop = True
        Me.rbHdrApv_Y.Text = "Y - Approval"
        Me.rbHdrApv_Y.UseVisualStyleBackColor = True
        '
        'lblPricing
        '
        Me.lblPricing.AutoSize = True
        Me.lblPricing.Location = New System.Drawing.Point(3, 24)
        Me.lblPricing.Name = "lblPricing"
        Me.lblPricing.Size = New System.Drawing.Size(76, 12)
        Me.lblPricing.TabIndex = 88
        Me.lblPricing.Text = "Approval Filter"
        '
        'gbPriceView
        '
        Me.gbPriceView.Controls.Add(Me.rbHdrApvFilter_CloseOut)
        Me.gbPriceView.Controls.Add(Me.rbHdrApvFilter_Replacement)
        Me.gbPriceView.Controls.Add(Me.rbHdrApvFilter_PaymentTerm)
        Me.gbPriceView.Controls.Add(Me.rbHdrApvFilter_PriceTerm)
        Me.gbPriceView.Controls.Add(Me.rbHdrApvFilter_All)
        Me.gbPriceView.Location = New System.Drawing.Point(94, 12)
        Me.gbPriceView.Name = "gbPriceView"
        Me.gbPriceView.Size = New System.Drawing.Size(508, 32)
        Me.gbPriceView.TabIndex = 87
        Me.gbPriceView.TabStop = False
        '
        'rbHdrApvFilter_CloseOut
        '
        Me.rbHdrApvFilter_CloseOut.AutoSize = True
        Me.rbHdrApvFilter_CloseOut.Location = New System.Drawing.Point(376, 10)
        Me.rbHdrApvFilter_CloseOut.Name = "rbHdrApvFilter_CloseOut"
        Me.rbHdrApvFilter_CloseOut.Size = New System.Drawing.Size(99, 16)
        Me.rbHdrApvFilter_CloseOut.TabIndex = 505
        Me.rbHdrApvFilter_CloseOut.Text = "Close Out Order"
        Me.rbHdrApvFilter_CloseOut.UseVisualStyleBackColor = True
        '
        'rbHdrApvFilter_Replacement
        '
        Me.rbHdrApvFilter_Replacement.AutoSize = True
        Me.rbHdrApvFilter_Replacement.Location = New System.Drawing.Point(247, 10)
        Me.rbHdrApvFilter_Replacement.Name = "rbHdrApvFilter_Replacement"
        Me.rbHdrApvFilter_Replacement.Size = New System.Drawing.Size(113, 16)
        Me.rbHdrApvFilter_Replacement.TabIndex = 504
        Me.rbHdrApvFilter_Replacement.Text = "Replacement Order"
        Me.rbHdrApvFilter_Replacement.UseVisualStyleBackColor = True
        '
        'rbHdrApvFilter_PaymentTerm
        '
        Me.rbHdrApvFilter_PaymentTerm.AutoSize = True
        Me.rbHdrApvFilter_PaymentTerm.Location = New System.Drawing.Point(145, 10)
        Me.rbHdrApvFilter_PaymentTerm.Name = "rbHdrApvFilter_PaymentTerm"
        Me.rbHdrApvFilter_PaymentTerm.Size = New System.Drawing.Size(91, 16)
        Me.rbHdrApvFilter_PaymentTerm.TabIndex = 503
        Me.rbHdrApvFilter_PaymentTerm.Text = "Payment Term"
        Me.rbHdrApvFilter_PaymentTerm.UseVisualStyleBackColor = True
        '
        'rbHdrApvFilter_PriceTerm
        '
        Me.rbHdrApvFilter_PriceTerm.AutoSize = True
        Me.rbHdrApvFilter_PriceTerm.Location = New System.Drawing.Point(59, 10)
        Me.rbHdrApvFilter_PriceTerm.Name = "rbHdrApvFilter_PriceTerm"
        Me.rbHdrApvFilter_PriceTerm.Size = New System.Drawing.Size(74, 16)
        Me.rbHdrApvFilter_PriceTerm.TabIndex = 502
        Me.rbHdrApvFilter_PriceTerm.Text = "Price Term"
        Me.rbHdrApvFilter_PriceTerm.UseVisualStyleBackColor = True
        '
        'rbHdrApvFilter_All
        '
        Me.rbHdrApvFilter_All.AutoSize = True
        Me.rbHdrApvFilter_All.Checked = True
        Me.rbHdrApvFilter_All.Location = New System.Drawing.Point(6, 10)
        Me.rbHdrApvFilter_All.Name = "rbHdrApvFilter_All"
        Me.rbHdrApvFilter_All.Size = New System.Drawing.Size(37, 16)
        Me.rbHdrApvFilter_All.TabIndex = 501
        Me.rbHdrApvFilter_All.TabStop = True
        Me.rbHdrApvFilter_All.Text = "All"
        Me.rbHdrApvFilter_All.UseVisualStyleBackColor = True
        '
        'grpHdrAprv
        '
        Me.grpHdrAprv.Controls.Add(Me.cmdHdrApply)
        Me.grpHdrAprv.Controls.Add(Me.cmdHdrSelectAll)
        Me.grpHdrAprv.Controls.Add(Me.optHdrAprvY)
        Me.grpHdrAprv.Controls.Add(Me.optHdrAprvW)
        Me.grpHdrAprv.Controls.Add(Me.optHdrAprvN)
        Me.grpHdrAprv.Location = New System.Drawing.Point(5, 389)
        Me.grpHdrAprv.Name = "grpHdrAprv"
        Me.grpHdrAprv.Size = New System.Drawing.Size(696, 40)
        Me.grpHdrAprv.TabIndex = 1
        Me.grpHdrAprv.TabStop = False
        Me.grpHdrAprv.Text = "Approval Type"
        Me.grpHdrAprv.Visible = False
        '
        'cmdHdrApply
        '
        Me.cmdHdrApply.Location = New System.Drawing.Point(591, 12)
        Me.cmdHdrApply.Name = "cmdHdrApply"
        Me.cmdHdrApply.Size = New System.Drawing.Size(100, 21)
        Me.cmdHdrApply.TabIndex = 4
        Me.cmdHdrApply.Text = "Apply"
        Me.cmdHdrApply.UseVisualStyleBackColor = True
        '
        'cmdHdrSelectAll
        '
        Me.cmdHdrSelectAll.Location = New System.Drawing.Point(487, 12)
        Me.cmdHdrSelectAll.Name = "cmdHdrSelectAll"
        Me.cmdHdrSelectAll.Size = New System.Drawing.Size(100, 21)
        Me.cmdHdrSelectAll.TabIndex = 3
        Me.cmdHdrSelectAll.Text = "Select All"
        Me.cmdHdrSelectAll.UseVisualStyleBackColor = True
        '
        'optHdrAprvY
        '
        Me.optHdrAprvY.AutoSize = True
        Me.optHdrAprvY.Location = New System.Drawing.Point(334, 14)
        Me.optHdrAprvY.Name = "optHdrAprvY"
        Me.optHdrAprvY.Size = New System.Drawing.Size(125, 16)
        Me.optHdrAprvY.TabIndex = 2
        Me.optHdrAprvY.TabStop = True
        Me.optHdrAprvY.Text = "Y - Approval Granted"
        Me.optHdrAprvY.UseVisualStyleBackColor = True
        '
        'optHdrAprvW
        '
        Me.optHdrAprvW.AutoSize = True
        Me.optHdrAprvW.Location = New System.Drawing.Point(178, 14)
        Me.optHdrAprvW.Name = "optHdrAprvW"
        Me.optHdrAprvW.Size = New System.Drawing.Size(145, 16)
        Me.optHdrAprvW.TabIndex = 1
        Me.optHdrAprvW.TabStop = True
        Me.optHdrAprvW.Text = "W - Waiting for Approval"
        Me.optHdrAprvW.UseVisualStyleBackColor = True
        '
        'optHdrAprvN
        '
        Me.optHdrAprvN.AutoSize = True
        Me.optHdrAprvN.Location = New System.Drawing.Point(15, 14)
        Me.optHdrAprvN.Name = "optHdrAprvN"
        Me.optHdrAprvN.Size = New System.Drawing.Size(148, 16)
        Me.optHdrAprvN.TabIndex = 0
        Me.optHdrAprvN.TabStop = True
        Me.optHdrAprvN.Text = "N - No Approval Required"
        Me.optHdrAprvN.UseVisualStyleBackColor = True
        '
        'dgHeader
        '
        Me.dgHeader.AllowUserToAddRows = False
        Me.dgHeader.AllowUserToDeleteRows = False
        Me.dgHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgHeader.Location = New System.Drawing.Point(2, 53)
        Me.dgHeader.Name = "dgHeader"
        Me.dgHeader.ReadOnly = True
        Me.dgHeader.RowHeadersWidth = 21
        Me.dgHeader.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgHeader.RowTemplate.Height = 20
        Me.dgHeader.Size = New System.Drawing.Size(928, 487)
        Me.dgHeader.TabIndex = 0
        '
        'tabFrame_Detail
        '
        Me.tabFrame_Detail.Controls.Add(Me.grpDetail)
        Me.tabFrame_Detail.Location = New System.Drawing.Point(4, 24)
        Me.tabFrame_Detail.Name = "tabFrame_Detail"
        Me.tabFrame_Detail.Size = New System.Drawing.Size(936, 543)
        Me.tabFrame_Detail.TabIndex = 2
        Me.tabFrame_Detail.Text = "(3) Detail"
        Me.tabFrame_Detail.UseVisualStyleBackColor = True
        '
        'grpDetail
        '
        Me.grpDetail.Controls.Add(Me.cmdDtlApvApply)
        Me.grpDetail.Controls.Add(Me.GroupBox4)
        Me.grpDetail.Controls.Add(Me.GroupBox2)
        Me.grpDetail.Controls.Add(Me.dgDetail)
        Me.grpDetail.Controls.Add(Me.txtRvsDat)
        Me.grpDetail.Controls.Add(Me.Label12)
        Me.grpDetail.Controls.Add(Me.txtSecCus)
        Me.grpDetail.Controls.Add(Me.Label13)
        Me.grpDetail.Controls.Add(Me.txtPriCus)
        Me.grpDetail.Controls.Add(Me.Label14)
        Me.grpDetail.Controls.Add(Me.txtOrdSts)
        Me.grpDetail.Controls.Add(Me.Label11)
        Me.grpDetail.Controls.Add(Me.txtSCNo)
        Me.grpDetail.Controls.Add(Me.Label10)
        Me.grpDetail.Controls.Add(Me.GroupBox1)
        Me.grpDetail.Controls.Add(Me.txtCoCde)
        Me.grpDetail.Controls.Add(Me.Label9)
        Me.grpDetail.Controls.Add(Me.Label17)
        Me.grpDetail.Location = New System.Drawing.Point(1, -3)
        Me.grpDetail.Name = "grpDetail"
        Me.grpDetail.Size = New System.Drawing.Size(933, 542)
        Me.grpDetail.TabIndex = 1
        Me.grpDetail.TabStop = False
        '
        'cmdDtlApvApply
        '
        Me.cmdDtlApvApply.Location = New System.Drawing.Point(875, 20)
        Me.cmdDtlApvApply.Name = "cmdDtlApvApply"
        Me.cmdDtlApvApply.Size = New System.Drawing.Size(55, 22)
        Me.cmdDtlApvApply.TabIndex = 92
        Me.cmdDtlApvApply.Text = "Apply"
        Me.cmdDtlApvApply.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbDtlApv_W)
        Me.GroupBox4.Controls.Add(Me.rbDtlApv_Y)
        Me.GroupBox4.Location = New System.Drawing.Point(659, 11)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(214, 32)
        Me.GroupBox4.TabIndex = 91
        Me.GroupBox4.TabStop = False
        '
        'rbDtlApv_W
        '
        Me.rbDtlApv_W.AutoSize = True
        Me.rbDtlApv_W.Location = New System.Drawing.Point(86, 11)
        Me.rbDtlApv_W.Name = "rbDtlApv_W"
        Me.rbDtlApv_W.Size = New System.Drawing.Size(130, 16)
        Me.rbDtlApv_W.TabIndex = 64
        Me.rbDtlApv_W.Text = "W - Wait for Approval"
        Me.rbDtlApv_W.UseVisualStyleBackColor = True
        '
        'rbDtlApv_Y
        '
        Me.rbDtlApv_Y.AutoSize = True
        Me.rbDtlApv_Y.Checked = True
        Me.rbDtlApv_Y.Location = New System.Drawing.Point(3, 11)
        Me.rbDtlApv_Y.Name = "rbDtlApv_Y"
        Me.rbDtlApv_Y.Size = New System.Drawing.Size(85, 16)
        Me.rbDtlApv_Y.TabIndex = 63
        Me.rbDtlApv_Y.TabStop = True
        Me.rbDtlApv_Y.Text = "Y - Approval"
        Me.rbDtlApv_Y.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbDtlApvFilter_ChgSelPrc)
        Me.GroupBox2.Controls.Add(Me.rbDtlApvFilter_ChgDVPVFtyCst)
        Me.GroupBox2.Controls.Add(Me.rbDtlApvFilter_OneTime)
        Me.GroupBox2.Controls.Add(Me.rbDtlApvFilter_BelowMinMU)
        Me.GroupBox2.Controls.Add(Me.rbDtlApvFilter_MOQ)
        Me.GroupBox2.Controls.Add(Me.rbDtlApvFilter_All)
        Me.GroupBox2.Location = New System.Drawing.Point(79, 11)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(576, 32)
        Me.GroupBox2.TabIndex = 89
        Me.GroupBox2.TabStop = False
        '
        'rbDtlApvFilter_ChgSelPrc
        '
        Me.rbDtlApvFilter_ChgSelPrc.AutoSize = True
        Me.rbDtlApvFilter_ChgSelPrc.Location = New System.Drawing.Point(42, 10)
        Me.rbDtlApvFilter_ChgSelPrc.Name = "rbDtlApvFilter_ChgSelPrc"
        Me.rbDtlApvFilter_ChgSelPrc.Size = New System.Drawing.Size(120, 16)
        Me.rbDtlApvFilter_ChgSelPrc.TabIndex = 506
        Me.rbDtlApvFilter_ChgSelPrc.Text = "Change Selling Price"
        Me.rbDtlApvFilter_ChgSelPrc.UseVisualStyleBackColor = True
        '
        'rbDtlApvFilter_ChgDVPVFtyCst
        '
        Me.rbDtlApvFilter_ChgDVPVFtyCst.AutoSize = True
        Me.rbDtlApvFilter_ChgDVPVFtyCst.Location = New System.Drawing.Point(446, 10)
        Me.rbDtlApvFilter_ChgDVPVFtyCst.Name = "rbDtlApvFilter_ChgDVPVFtyCst"
        Me.rbDtlApvFilter_ChgDVPVFtyCst.Size = New System.Drawing.Size(128, 16)
        Me.rbDtlApvFilter_ChgDVPVFtyCst.TabIndex = 505
        Me.rbDtlApvFilter_ChgDVPVFtyCst.Text = "Change DV/PV FtyCst"
        Me.rbDtlApvFilter_ChgDVPVFtyCst.UseVisualStyleBackColor = True
        '
        'rbDtlApvFilter_OneTime
        '
        Me.rbDtlApvFilter_OneTime.AutoSize = True
        Me.rbDtlApvFilter_OneTime.Location = New System.Drawing.Point(347, 10)
        Me.rbDtlApvFilter_OneTime.Name = "rbDtlApvFilter_OneTime"
        Me.rbDtlApvFilter_OneTime.Size = New System.Drawing.Size(95, 16)
        Me.rbDtlApvFilter_OneTime.TabIndex = 504
        Me.rbDtlApvFilter_OneTime.Text = "One Time Price"
        Me.rbDtlApvFilter_OneTime.UseVisualStyleBackColor = True
        '
        'rbDtlApvFilter_BelowMinMU
        '
        Me.rbDtlApvFilter_BelowMinMU.AutoSize = True
        Me.rbDtlApvFilter_BelowMinMU.Location = New System.Drawing.Point(252, 10)
        Me.rbDtlApvFilter_BelowMinMU.Name = "rbDtlApvFilter_BelowMinMU"
        Me.rbDtlApvFilter_BelowMinMU.Size = New System.Drawing.Size(96, 16)
        Me.rbDtlApvFilter_BelowMinMU.TabIndex = 503
        Me.rbDtlApvFilter_BelowMinMU.Text = "Below Min MU"
        Me.rbDtlApvFilter_BelowMinMU.UseVisualStyleBackColor = True
        '
        'rbDtlApvFilter_MOQ
        '
        Me.rbDtlApvFilter_MOQ.AutoSize = True
        Me.rbDtlApvFilter_MOQ.Location = New System.Drawing.Point(167, 10)
        Me.rbDtlApvFilter_MOQ.Name = "rbDtlApvFilter_MOQ"
        Me.rbDtlApvFilter_MOQ.Size = New System.Drawing.Size(82, 16)
        Me.rbDtlApvFilter_MOQ.TabIndex = 502
        Me.rbDtlApvFilter_MOQ.Text = "Below MOQ"
        Me.rbDtlApvFilter_MOQ.UseVisualStyleBackColor = True
        '
        'rbDtlApvFilter_All
        '
        Me.rbDtlApvFilter_All.AutoSize = True
        Me.rbDtlApvFilter_All.Checked = True
        Me.rbDtlApvFilter_All.Location = New System.Drawing.Point(3, 10)
        Me.rbDtlApvFilter_All.Name = "rbDtlApvFilter_All"
        Me.rbDtlApvFilter_All.Size = New System.Drawing.Size(37, 16)
        Me.rbDtlApvFilter_All.TabIndex = 501
        Me.rbDtlApvFilter_All.TabStop = True
        Me.rbDtlApvFilter_All.Text = "All"
        Me.rbDtlApvFilter_All.UseVisualStyleBackColor = True
        '
        'dgDetail
        '
        Me.dgDetail.AllowUserToAddRows = False
        Me.dgDetail.AllowUserToDeleteRows = False
        Me.dgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetail.Location = New System.Drawing.Point(2, 53)
        Me.dgDetail.Name = "dgDetail"
        Me.dgDetail.ReadOnly = True
        Me.dgDetail.RowHeadersWidth = 21
        Me.dgDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgDetail.RowTemplate.Height = 20
        Me.dgDetail.Size = New System.Drawing.Size(929, 485)
        Me.dgDetail.TabIndex = 15
        '
        'txtRvsDat
        '
        Me.txtRvsDat.BackColor = System.Drawing.Color.White
        Me.txtRvsDat.ForeColor = System.Drawing.Color.Black
        Me.txtRvsDat.Location = New System.Drawing.Point(649, 110)
        Me.txtRvsDat.Name = "txtRvsDat"
        Me.txtRvsDat.Size = New System.Drawing.Size(78, 22)
        Me.txtRvsDat.TabIndex = 14
        Me.txtRvsDat.Text = "00/00/0000"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(559, 113)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 12)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "SC Revised Date"
        '
        'txtSecCus
        '
        Me.txtSecCus.BackColor = System.Drawing.Color.White
        Me.txtSecCus.ForeColor = System.Drawing.Color.Black
        Me.txtSecCus.Location = New System.Drawing.Point(487, 134)
        Me.txtSecCus.Name = "txtSecCus"
        Me.txtSecCus.Size = New System.Drawing.Size(240, 22)
        Me.txtSecCus.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(376, 137)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(102, 12)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Secondary Customer"
        '
        'txtPriCus
        '
        Me.txtPriCus.BackColor = System.Drawing.Color.White
        Me.txtPriCus.ForeColor = System.Drawing.Color.Black
        Me.txtPriCus.Location = New System.Drawing.Point(108, 134)
        Me.txtPriCus.Name = "txtPriCus"
        Me.txtPriCus.Size = New System.Drawing.Size(240, 22)
        Me.txtPriCus.TabIndex = 10
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 137)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(90, 12)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "Primary Customer"
        '
        'txtOrdSts
        '
        Me.txtOrdSts.BackColor = System.Drawing.Color.White
        Me.txtOrdSts.ForeColor = System.Drawing.Color.Black
        Me.txtOrdSts.Location = New System.Drawing.Point(379, 110)
        Me.txtOrdSts.Name = "txtOrdSts"
        Me.txtOrdSts.Size = New System.Drawing.Size(169, 22)
        Me.txtOrdSts.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(319, 113)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 12)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "SC Status"
        '
        'txtSCNo
        '
        Me.txtSCNo.BackColor = System.Drawing.Color.White
        Me.txtSCNo.ForeColor = System.Drawing.Color.Black
        Me.txtSCNo.Location = New System.Drawing.Point(208, 110)
        Me.txtSCNo.Name = "txtSCNo"
        Me.txtSCNo.Size = New System.Drawing.Size(91, 22)
        Me.txtSCNo.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(159, 113)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 12)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "SC No"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdDtlApply)
        Me.GroupBox1.Controls.Add(Me.cmdDtlSelectAll)
        Me.GroupBox1.Controls.Add(Me.optDtlAprvY)
        Me.GroupBox1.Controls.Add(Me.optDtlAprvW)
        Me.GroupBox1.Controls.Add(Me.optDtlAprvN)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 542)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(709, 39)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Approval Type"
        Me.GroupBox1.Visible = False
        '
        'cmdDtlApply
        '
        Me.cmdDtlApply.Location = New System.Drawing.Point(603, 12)
        Me.cmdDtlApply.Name = "cmdDtlApply"
        Me.cmdDtlApply.Size = New System.Drawing.Size(100, 21)
        Me.cmdDtlApply.TabIndex = 4
        Me.cmdDtlApply.Text = "Apply"
        Me.cmdDtlApply.UseVisualStyleBackColor = True
        '
        'cmdDtlSelectAll
        '
        Me.cmdDtlSelectAll.Location = New System.Drawing.Point(502, 12)
        Me.cmdDtlSelectAll.Name = "cmdDtlSelectAll"
        Me.cmdDtlSelectAll.Size = New System.Drawing.Size(100, 21)
        Me.cmdDtlSelectAll.TabIndex = 3
        Me.cmdDtlSelectAll.Text = "Select All"
        Me.cmdDtlSelectAll.UseVisualStyleBackColor = True
        '
        'optDtlAprvY
        '
        Me.optDtlAprvY.AutoSize = True
        Me.optDtlAprvY.Location = New System.Drawing.Point(334, 15)
        Me.optDtlAprvY.Name = "optDtlAprvY"
        Me.optDtlAprvY.Size = New System.Drawing.Size(125, 16)
        Me.optDtlAprvY.TabIndex = 2
        Me.optDtlAprvY.TabStop = True
        Me.optDtlAprvY.Text = "Y - Approval Granted"
        Me.optDtlAprvY.UseVisualStyleBackColor = True
        '
        'optDtlAprvW
        '
        Me.optDtlAprvW.AutoSize = True
        Me.optDtlAprvW.Location = New System.Drawing.Point(178, 15)
        Me.optDtlAprvW.Name = "optDtlAprvW"
        Me.optDtlAprvW.Size = New System.Drawing.Size(145, 16)
        Me.optDtlAprvW.TabIndex = 1
        Me.optDtlAprvW.TabStop = True
        Me.optDtlAprvW.Text = "W - Waiting for Approval"
        Me.optDtlAprvW.UseVisualStyleBackColor = True
        '
        'optDtlAprvN
        '
        Me.optDtlAprvN.AutoSize = True
        Me.optDtlAprvN.Location = New System.Drawing.Point(15, 15)
        Me.optDtlAprvN.Name = "optDtlAprvN"
        Me.optDtlAprvN.Size = New System.Drawing.Size(148, 16)
        Me.optDtlAprvN.TabIndex = 0
        Me.optDtlAprvN.TabStop = True
        Me.optDtlAprvN.Text = "N - No Approval Required"
        Me.optDtlAprvN.UseVisualStyleBackColor = True
        '
        'txtCoCde
        '
        Me.txtCoCde.BackColor = System.Drawing.Color.White
        Me.txtCoCde.ForeColor = System.Drawing.Color.Black
        Me.txtCoCde.Location = New System.Drawing.Point(71, 110)
        Me.txtCoCde.Name = "txtCoCde"
        Me.txtCoCde.Size = New System.Drawing.Size(70, 22)
        Me.txtCoCde.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 113)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 12)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Company"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 23)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 12)
        Me.Label17.TabIndex = 90
        Me.Label17.Text = "Approval Filter"
        '
        'SCM00006
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 622)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.tabFrame)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SCM00006"
        Me.Text = "SCM00006 - Sales Confirmation Approval (SCM06)"
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.tabFrame.ResumeLayout(False)
        Me.tabFrame_Search.ResumeLayout(False)
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.tabFrame_Header.ResumeLayout(False)
        Me.grpHeader.ResumeLayout(False)
        Me.grpHeader.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gbPriceView.ResumeLayout(False)
        Me.gbPriceView.PerformLayout()
        Me.grpHdrAprv.ResumeLayout(False)
        Me.grpHdrAprv.PerformLayout()
        CType(Me.dgHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabFrame_Detail.ResumeLayout(False)
        Me.grpDetail.ResumeLayout(False)
        Me.grpDetail.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabFrame As ERPSystem.BaseTabControl
    Friend WithEvents tabFrame_Search As System.Windows.Forms.TabPage
    Friend WithEvents tabFrame_Header As System.Windows.Forms.TabPage
    Friend WithEvents tabFrame_Detail As System.Windows.Forms.TabPage
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents grpHeader As System.Windows.Forms.GroupBox
    Friend WithEvents grpDetail As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSCRvsdatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSCRvsdatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_S_ItmNo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_ItmNo As System.Windows.Forms.Button
    Friend WithEvents txt_S_SCNo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SCNo As System.Windows.Forms.Button
    Friend WithEvents txt_S_SecCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SecCust As System.Windows.Forms.Button
    Friend WithEvents txt_S_PriCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PriCust As System.Windows.Forms.Button
    Friend WithEvents txt_S_CoCde As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_CoCde As System.Windows.Forms.Button
    Friend WithEvents dgHeader As System.Windows.Forms.DataGridView
    Friend WithEvents grpHdrAprv As System.Windows.Forms.GroupBox
    Friend WithEvents cmdHdrApply As System.Windows.Forms.Button
    Friend WithEvents cmdHdrSelectAll As System.Windows.Forms.Button
    Friend WithEvents optHdrAprvY As System.Windows.Forms.RadioButton
    Friend WithEvents optHdrAprvW As System.Windows.Forms.RadioButton
    Friend WithEvents optHdrAprvN As System.Windows.Forms.RadioButton
    Friend WithEvents txtCoCde As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDtlApply As System.Windows.Forms.Button
    Friend WithEvents cmdDtlSelectAll As System.Windows.Forms.Button
    Friend WithEvents optDtlAprvY As System.Windows.Forms.RadioButton
    Friend WithEvents optDtlAprvW As System.Windows.Forms.RadioButton
    Friend WithEvents optDtlAprvN As System.Windows.Forms.RadioButton
    Friend WithEvents txtSCNo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtOrdSts As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtRvsDat As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSecCus As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPriCus As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dgDetail As System.Windows.Forms.DataGridView
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblPricing As System.Windows.Forms.Label
    Friend WithEvents gbPriceView As System.Windows.Forms.GroupBox
    Friend WithEvents rbHdrApvFilter_CloseOut As System.Windows.Forms.RadioButton
    Friend WithEvents rbHdrApvFilter_Replacement As System.Windows.Forms.RadioButton
    Friend WithEvents rbHdrApvFilter_PaymentTerm As System.Windows.Forms.RadioButton
    Friend WithEvents rbHdrApvFilter_PriceTerm As System.Windows.Forms.RadioButton
    Friend WithEvents rbHdrApvFilter_All As System.Windows.Forms.RadioButton
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbDtlApvFilter_ChgDVPVFtyCst As System.Windows.Forms.RadioButton
    Friend WithEvents rbDtlApvFilter_OneTime As System.Windows.Forms.RadioButton
    Friend WithEvents rbDtlApvFilter_BelowMinMU As System.Windows.Forms.RadioButton
    Friend WithEvents rbDtlApvFilter_MOQ As System.Windows.Forms.RadioButton
    Friend WithEvents rbDtlApvFilter_All As System.Windows.Forms.RadioButton
    Friend WithEvents rbDtlApvFilter_ChgSelPrc As System.Windows.Forms.RadioButton
    Friend WithEvents cmdDtlApvApply As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbDtlApv_W As System.Windows.Forms.RadioButton
    Friend WithEvents rbDtlApv_Y As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents cmdHdrApvApply As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbHdrApv_W As System.Windows.Forms.RadioButton
    Friend WithEvents rbHdrApv_Y As System.Windows.Forms.RadioButton
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
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRight As System.Windows.Forms.ToolStripStatusLabel
End Class
