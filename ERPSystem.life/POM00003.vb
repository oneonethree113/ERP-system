




Public Class POM00003
    Inherits System.Windows.Forms.Form



#Region " Windows Form Designer generated code "

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
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents tcPOM00010 As ERPSystem.BaseTabControl
    Friend WithEvents tcPOM00010_1 As System.Windows.Forms.TabPage
    Friend WithEvents tcPOM00010_2 As System.Windows.Forms.TabPage
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lbl_S_CustPODate As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_S_SCIssDate As System.Windows.Forms.Label
    Friend WithEvents cmd_S_SalTem As System.Windows.Forms.Button
    Friend WithEvents lbl_S_SalTem As System.Windows.Forms.Label
    Friend WithEvents txt_S_SalTem As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PV As System.Windows.Forms.Button
    Friend WithEvents lbl_S_PV As System.Windows.Forms.Label
    Friend WithEvents txt_S_PV As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_CV As System.Windows.Forms.Button
    Friend WithEvents lbl_S_CV As System.Windows.Forms.Label
    Friend WithEvents txt_S_CV As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_ItmNo As System.Windows.Forms.Button
    Friend WithEvents cmd_S_SCNo As System.Windows.Forms.Button
    Friend WithEvents cmd_S_PONo As System.Windows.Forms.Button
    Friend WithEvents cmd_S_CustPONo As System.Windows.Forms.Button
    Friend WithEvents cmd_S_SecCust As System.Windows.Forms.Button
    Friend WithEvents cmd_S_PriCust As System.Windows.Forms.Button
    Friend WithEvents cmd_S_CoCde As System.Windows.Forms.Button
    Friend WithEvents lbl_S_ItmNo As System.Windows.Forms.Label
    Friend WithEvents lbl_S_SCNo As System.Windows.Forms.Label
    Friend WithEvents lbl_S_PONo As System.Windows.Forms.Label
    Friend WithEvents lbl_S_CustPO As System.Windows.Forms.Label
    Friend WithEvents txt_S_ItmNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_SCNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_PONo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_CustPONo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_SecCust As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_PriCust As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_CoCde As System.Windows.Forms.TextBox
    Friend WithEvents lbl_S_SecCust As System.Windows.Forms.Label
    Friend WithEvents lbl_S_PriCust As System.Windows.Forms.Label
    Friend WithEvents lbl_S_CoCde As System.Windows.Forms.Label
    Friend WithEvents dgHeader As System.Windows.Forms.DataGridView
    Friend WithEvents cmdApprove As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtSeqTo As System.Windows.Forms.TextBox
    Friend WithEvents txtSeqFm As System.Windows.Forms.TextBox
    Friend WithEvents rbNoUpdate As System.Windows.Forms.RadioButton
    Friend WithEvents rbSignature As System.Windows.Forms.RadioButton
    Friend WithEvents rb_BelowBasicPrice As System.Windows.Forms.RadioButton
    Friend WithEvents rbMOQMOA As System.Windows.Forms.RadioButton
    Friend WithEvents rbOneTimePrice As System.Windows.Forms.RadioButton
    Friend WithEvents dgDetail As System.Windows.Forms.DataGridView
    Friend WithEvents txtSCNo As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtSecCus As System.Windows.Forms.TextBox
    Friend WithEvents txtPriCus As System.Windows.Forms.TextBox
    Friend WithEvents txtPOSts As System.Windows.Forms.TextBox
    Friend WithEvents txtPONo As System.Windows.Forms.TextBox
    Friend WithEvents txtCocde As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtSignAppFlg As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtAppDat As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtAppCount As System.Windows.Forms.TextBox
    Friend WithEvents txtResult As System.Windows.Forms.ListBox
    Friend WithEvents dgApproved As System.Windows.Forms.DataGridView
    Friend WithEvents rbFinal As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txt_S_POIssDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_S_POIssDateFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_S_SCIssDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_S_SCIssDateFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_S_CustPODateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_S_CustPODateFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cmdApvApply As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbFinalApv_W As System.Windows.Forms.RadioButton
    Friend WithEvents rbFinalApv_Y As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
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
    Friend WithEvents tcPOM00010_3 As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POM00003))
        Me.TabPage6 = New System.Windows.Forms.TabPage
        Me.TabPage7 = New System.Windows.Forms.TabPage
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
        Me.tcPOM00010 = New ERPSystem.BaseTabControl
        Me.tcPOM00010_1 = New System.Windows.Forms.TabPage
        Me.txt_S_CustPODateTo = New System.Windows.Forms.MaskedTextBox
        Me.txt_S_CustPODateFm = New System.Windows.Forms.MaskedTextBox
        Me.txt_S_SCIssDateTo = New System.Windows.Forms.MaskedTextBox
        Me.txt_S_SCIssDateFm = New System.Windows.Forms.MaskedTextBox
        Me.txt_S_POIssDateTo = New System.Windows.Forms.MaskedTextBox
        Me.txt_S_POIssDateFm = New System.Windows.Forms.MaskedTextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.lbl_S_CustPODate = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_S_SCIssDate = New System.Windows.Forms.Label
        Me.cmd_S_SalTem = New System.Windows.Forms.Button
        Me.lbl_S_SalTem = New System.Windows.Forms.Label
        Me.txt_S_SalTem = New System.Windows.Forms.TextBox
        Me.cmd_S_PV = New System.Windows.Forms.Button
        Me.lbl_S_PV = New System.Windows.Forms.Label
        Me.txt_S_PV = New System.Windows.Forms.TextBox
        Me.cmd_S_CV = New System.Windows.Forms.Button
        Me.lbl_S_CV = New System.Windows.Forms.Label
        Me.txt_S_CV = New System.Windows.Forms.TextBox
        Me.cmd_S_ItmNo = New System.Windows.Forms.Button
        Me.cmd_S_SCNo = New System.Windows.Forms.Button
        Me.cmd_S_PONo = New System.Windows.Forms.Button
        Me.cmd_S_CustPONo = New System.Windows.Forms.Button
        Me.cmd_S_SecCust = New System.Windows.Forms.Button
        Me.cmd_S_PriCust = New System.Windows.Forms.Button
        Me.cmd_S_CoCde = New System.Windows.Forms.Button
        Me.lbl_S_ItmNo = New System.Windows.Forms.Label
        Me.lbl_S_SCNo = New System.Windows.Forms.Label
        Me.lbl_S_PONo = New System.Windows.Forms.Label
        Me.lbl_S_CustPO = New System.Windows.Forms.Label
        Me.txt_S_ItmNo = New System.Windows.Forms.TextBox
        Me.txt_S_SCNo = New System.Windows.Forms.TextBox
        Me.txt_S_PONo = New System.Windows.Forms.TextBox
        Me.txt_S_CustPONo = New System.Windows.Forms.TextBox
        Me.txt_S_SecCust = New System.Windows.Forms.TextBox
        Me.txt_S_PriCust = New System.Windows.Forms.TextBox
        Me.txt_S_CoCde = New System.Windows.Forms.TextBox
        Me.lbl_S_SecCust = New System.Windows.Forms.Label
        Me.lbl_S_PriCust = New System.Windows.Forms.Label
        Me.lbl_S_CoCde = New System.Windows.Forms.Label
        Me.tcPOM00010_2 = New System.Windows.Forms.TabPage
        Me.cmdApvApply = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbFinalApv_W = New System.Windows.Forms.RadioButton
        Me.rbFinalApv_Y = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.dgHeader = New System.Windows.Forms.DataGridView
        Me.txtResult = New System.Windows.Forms.ListBox
        Me.dgApproved = New System.Windows.Forms.DataGridView
        Me.cmdApprove = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbFinal = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.rbNoUpdate = New System.Windows.Forms.RadioButton
        Me.rbSignature = New System.Windows.Forms.RadioButton
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.cmdApply = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtSeqTo = New System.Windows.Forms.TextBox
        Me.txtSeqFm = New System.Windows.Forms.TextBox
        Me.rb_BelowBasicPrice = New System.Windows.Forms.RadioButton
        Me.rbMOQMOA = New System.Windows.Forms.RadioButton
        Me.rbOneTimePrice = New System.Windows.Forms.RadioButton
        Me.tcPOM00010_3 = New System.Windows.Forms.TabPage
        Me.txtAppDat = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtAppCount = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtSignAppFlg = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.dgDetail = New System.Windows.Forms.DataGridView
        Me.txtSCNo = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtSecCus = New System.Windows.Forms.TextBox
        Me.txtPriCus = New System.Windows.Forms.TextBox
        Me.txtPOSts = New System.Windows.Forms.TextBox
        Me.txtPONo = New System.Windows.Forms.TextBox
        Me.txtCocde = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.menuStrip.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.tcPOM00010.SuspendLayout()
        Me.tcPOM00010_1.SuspendLayout()
        Me.tcPOM00010_2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgApproved, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tcPOM00010_3.SuspendLayout()
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabPage6
        '
        Me.TabPage6.Location = New System.Drawing.Point(0, 0)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(200, 100)
        Me.TabPage6.TabIndex = 0
        '
        'TabPage7
        '
        Me.TabPage7.Location = New System.Drawing.Point(0, 0)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(200, 100)
        Me.TabPage7.TabIndex = 0
        '
        'menuStrip
        '
        Me.menuStrip.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdAdd, Me.mmdSave, Me.mmdDelete, Me.mmdCopy, Me.mmdFind, Me.t1, Me.mmdClear, Me.t2, Me.mmdSearch, Me.t3, Me.mmdInsRow, Me.mmdDelRow, Me.t4, Me.mmdPrint, Me.t5, Me.mmdAttach, Me.t6, Me.mmdFunction, Me.t7, Me.mmdLink, Me.t8, Me.mmdExit})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuStrip.Size = New System.Drawing.Size(954, 24)
        Me.menuStrip.TabIndex = 289
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
        Me.StatusBar.Location = New System.Drawing.Point(0, 608)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(954, 24)
        Me.StatusBar.TabIndex = 290
        Me.StatusBar.Text = "StatusStrip1"
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = False
        Me.lblLeft.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(469, 19)
        Me.lblLeft.Spring = True
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRight
        '
        Me.lblRight.AutoSize = False
        Me.lblRight.Font = New System.Drawing.Font("PMingLiU", 9.0!)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(469, 19)
        Me.lblRight.Spring = True
        Me.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tcPOM00010
        '
        Me.tcPOM00010.Controls.Add(Me.tcPOM00010_1)
        Me.tcPOM00010.Controls.Add(Me.tcPOM00010_2)
        Me.tcPOM00010.Controls.Add(Me.tcPOM00010_3)
        Me.tcPOM00010.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tcPOM00010.Location = New System.Drawing.Point(0, 33)
        Me.tcPOM00010.Name = "tcPOM00010"
        Me.tcPOM00010.SelectedIndex = 0
        Me.tcPOM00010.Size = New System.Drawing.Size(951, 570)
        Me.tcPOM00010.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tcPOM00010.TabIndex = 15
        '
        'tcPOM00010_1
        '
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_CustPODateTo)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_CustPODateFm)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_SCIssDateTo)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_SCIssDateFm)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_POIssDateTo)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_POIssDateFm)
        Me.tcPOM00010_1.Controls.Add(Me.Label23)
        Me.tcPOM00010_1.Controls.Add(Me.Label24)
        Me.tcPOM00010_1.Controls.Add(Me.Label25)
        Me.tcPOM00010_1.Controls.Add(Me.Label26)
        Me.tcPOM00010_1.Controls.Add(Me.Label27)
        Me.tcPOM00010_1.Controls.Add(Me.Label11)
        Me.tcPOM00010_1.Controls.Add(Me.Label12)
        Me.tcPOM00010_1.Controls.Add(Me.Label13)
        Me.tcPOM00010_1.Controls.Add(Me.Label14)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_CustPODate)
        Me.tcPOM00010_1.Controls.Add(Me.Label5)
        Me.tcPOM00010_1.Controls.Add(Me.Label4)
        Me.tcPOM00010_1.Controls.Add(Me.Label3)
        Me.tcPOM00010_1.Controls.Add(Me.Label1)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_SCIssDate)
        Me.tcPOM00010_1.Controls.Add(Me.cmd_S_SalTem)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_SalTem)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_SalTem)
        Me.tcPOM00010_1.Controls.Add(Me.cmd_S_PV)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_PV)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_PV)
        Me.tcPOM00010_1.Controls.Add(Me.cmd_S_CV)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_CV)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_CV)
        Me.tcPOM00010_1.Controls.Add(Me.cmd_S_ItmNo)
        Me.tcPOM00010_1.Controls.Add(Me.cmd_S_SCNo)
        Me.tcPOM00010_1.Controls.Add(Me.cmd_S_PONo)
        Me.tcPOM00010_1.Controls.Add(Me.cmd_S_CustPONo)
        Me.tcPOM00010_1.Controls.Add(Me.cmd_S_SecCust)
        Me.tcPOM00010_1.Controls.Add(Me.cmd_S_PriCust)
        Me.tcPOM00010_1.Controls.Add(Me.cmd_S_CoCde)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_ItmNo)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_SCNo)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_PONo)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_CustPO)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_ItmNo)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_SCNo)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_PONo)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_CustPONo)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_SecCust)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_PriCust)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_CoCde)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_SecCust)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_PriCust)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_CoCde)
        Me.tcPOM00010_1.Location = New System.Drawing.Point(4, 22)
        Me.tcPOM00010_1.Name = "tcPOM00010_1"
        Me.tcPOM00010_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tcPOM00010_1.Size = New System.Drawing.Size(943, 544)
        Me.tcPOM00010_1.TabIndex = 0
        Me.tcPOM00010_1.Text = "(1) Search"
        Me.tcPOM00010_1.UseVisualStyleBackColor = True
        '
        'txt_S_CustPODateTo
        '
        Me.txt_S_CustPODateTo.Location = New System.Drawing.Point(545, 438)
        Me.txt_S_CustPODateTo.Mask = "00/00/0000"
        Me.txt_S_CustPODateTo.Name = "txt_S_CustPODateTo"
        Me.txt_S_CustPODateTo.Size = New System.Drawing.Size(88, 22)
        Me.txt_S_CustPODateTo.TabIndex = 90
        Me.txt_S_CustPODateTo.Visible = False
        '
        'txt_S_CustPODateFm
        '
        Me.txt_S_CustPODateFm.Location = New System.Drawing.Point(275, 438)
        Me.txt_S_CustPODateFm.Mask = "00/00/0000"
        Me.txt_S_CustPODateFm.Name = "txt_S_CustPODateFm"
        Me.txt_S_CustPODateFm.Size = New System.Drawing.Size(88, 22)
        Me.txt_S_CustPODateFm.TabIndex = 89
        Me.txt_S_CustPODateFm.Visible = False
        '
        'txt_S_SCIssDateTo
        '
        Me.txt_S_SCIssDateTo.Location = New System.Drawing.Point(545, 403)
        Me.txt_S_SCIssDateTo.Mask = "00/00/0000"
        Me.txt_S_SCIssDateTo.Name = "txt_S_SCIssDateTo"
        Me.txt_S_SCIssDateTo.Size = New System.Drawing.Size(88, 22)
        Me.txt_S_SCIssDateTo.TabIndex = 88
        Me.txt_S_SCIssDateTo.Visible = False
        '
        'txt_S_SCIssDateFm
        '
        Me.txt_S_SCIssDateFm.Location = New System.Drawing.Point(275, 403)
        Me.txt_S_SCIssDateFm.Mask = "00/00/0000"
        Me.txt_S_SCIssDateFm.Name = "txt_S_SCIssDateFm"
        Me.txt_S_SCIssDateFm.Size = New System.Drawing.Size(88, 22)
        Me.txt_S_SCIssDateFm.TabIndex = 87
        Me.txt_S_SCIssDateFm.Visible = False
        '
        'txt_S_POIssDateTo
        '
        Me.txt_S_POIssDateTo.Location = New System.Drawing.Point(545, 368)
        Me.txt_S_POIssDateTo.Mask = "00/00/0000"
        Me.txt_S_POIssDateTo.Name = "txt_S_POIssDateTo"
        Me.txt_S_POIssDateTo.Size = New System.Drawing.Size(88, 22)
        Me.txt_S_POIssDateTo.TabIndex = 86
        '
        'txt_S_POIssDateFm
        '
        Me.txt_S_POIssDateFm.Location = New System.Drawing.Point(275, 368)
        Me.txt_S_POIssDateFm.Mask = "00/00/0000"
        Me.txt_S_POIssDateFm.Name = "txt_S_POIssDateFm"
        Me.txt_S_POIssDateFm.Size = New System.Drawing.Size(88, 22)
        Me.txt_S_POIssDateFm.TabIndex = 85
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(235, 370)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(30, 12)
        Me.Label23.TabIndex = 110
        Me.Label23.Text = "From"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(515, 370)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(18, 12)
        Me.Label24.TabIndex = 109
        Me.Label24.Text = "To"
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(635, 370)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(100, 16)
        Me.Label25.TabIndex = 108
        Me.Label25.Text = "(MM/DD/YYYY)"
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(365, 370)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(100, 16)
        Me.Label26.TabIndex = 105
        Me.Label26.Text = "(MM/DD/YYYY)"
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(85, 370)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(100, 23)
        Me.Label27.TabIndex = 104
        Me.Label27.Text = "PO Update Date"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(235, 440)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 12)
        Me.Label11.TabIndex = 103
        Me.Label11.Text = "From"
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(515, 440)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(18, 12)
        Me.Label12.TabIndex = 102
        Me.Label12.Text = "To"
        Me.Label12.Visible = False
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(635, 440)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 16)
        Me.Label13.TabIndex = 101
        Me.Label13.Text = "(MM/DD/YYYY)"
        Me.Label13.Visible = False
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(365, 440)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 16)
        Me.Label14.TabIndex = 100
        Me.Label14.Text = "(MM/DD/YYYY)"
        Me.Label14.Visible = False
        '
        'lbl_S_CustPODate
        '
        Me.lbl_S_CustPODate.Location = New System.Drawing.Point(85, 440)
        Me.lbl_S_CustPODate.Name = "lbl_S_CustPODate"
        Me.lbl_S_CustPODate.Size = New System.Drawing.Size(100, 23)
        Me.lbl_S_CustPODate.TabIndex = 99
        Me.lbl_S_CustPODate.Text = "Cust PO Date"
        Me.lbl_S_CustPODate.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(235, 405)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 12)
        Me.Label5.TabIndex = 90
        Me.Label5.Text = "From"
        Me.Label5.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(515, 405)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 12)
        Me.Label4.TabIndex = 89
        Me.Label4.Text = "To"
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(635, 405)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "(MM/DD/YYYY)"
        Me.Label3.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(365, 405)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "(MM/DD/YYYY)"
        Me.Label1.Visible = False
        '
        'lbl_S_SCIssDate
        '
        Me.lbl_S_SCIssDate.Location = New System.Drawing.Point(85, 405)
        Me.lbl_S_SCIssDate.Name = "lbl_S_SCIssDate"
        Me.lbl_S_SCIssDate.Size = New System.Drawing.Size(100, 23)
        Me.lbl_S_SCIssDate.TabIndex = 81
        Me.lbl_S_SCIssDate.Text = "SC Issue Date"
        Me.lbl_S_SCIssDate.Visible = False
        '
        'cmd_S_SalTem
        '
        Me.cmd_S_SalTem.Location = New System.Drawing.Point(187, 314)
        Me.cmd_S_SalTem.Name = "cmd_S_SalTem"
        Me.cmd_S_SalTem.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_SalTem.TabIndex = 82
        Me.cmd_S_SalTem.Text = "「「"
        '
        'lbl_S_SalTem
        '
        Me.lbl_S_SalTem.AutoSize = True
        Me.lbl_S_SalTem.Location = New System.Drawing.Point(37, 320)
        Me.lbl_S_SalTem.Name = "lbl_S_SalTem"
        Me.lbl_S_SalTem.Size = New System.Drawing.Size(57, 12)
        Me.lbl_S_SalTem.TabIndex = 77
        Me.lbl_S_SalTem.Text = "Sales Team"
        '
        'txt_S_SalTem
        '
        Me.txt_S_SalTem.Location = New System.Drawing.Point(334, 317)
        Me.txt_S_SalTem.MaxLength = 5000
        Me.txt_S_SalTem.Name = "txt_S_SalTem"
        Me.txt_S_SalTem.Size = New System.Drawing.Size(575, 22)
        Me.txt_S_SalTem.TabIndex = 83
        '
        'cmd_S_PV
        '
        Me.cmd_S_PV.Location = New System.Drawing.Point(187, 284)
        Me.cmd_S_PV.Name = "cmd_S_PV"
        Me.cmd_S_PV.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_PV.TabIndex = 79
        Me.cmd_S_PV.Text = "「「"
        '
        'lbl_S_PV
        '
        Me.lbl_S_PV.AutoSize = True
        Me.lbl_S_PV.Location = New System.Drawing.Point(37, 290)
        Me.lbl_S_PV.Name = "lbl_S_PV"
        Me.lbl_S_PV.Size = New System.Drawing.Size(94, 12)
        Me.lbl_S_PV.TabIndex = 71
        Me.lbl_S_PV.Text = "Production Vendor"
        '
        'txt_S_PV
        '
        Me.txt_S_PV.Location = New System.Drawing.Point(334, 287)
        Me.txt_S_PV.MaxLength = 5000
        Me.txt_S_PV.Name = "txt_S_PV"
        Me.txt_S_PV.Size = New System.Drawing.Size(575, 22)
        Me.txt_S_PV.TabIndex = 80
        '
        'cmd_S_CV
        '
        Me.cmd_S_CV.Location = New System.Drawing.Point(187, 254)
        Me.cmd_S_CV.Name = "cmd_S_CV"
        Me.cmd_S_CV.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_CV.TabIndex = 76
        Me.cmd_S_CV.Text = "「「"
        '
        'lbl_S_CV
        '
        Me.lbl_S_CV.AutoSize = True
        Me.lbl_S_CV.Location = New System.Drawing.Point(37, 260)
        Me.lbl_S_CV.Name = "lbl_S_CV"
        Me.lbl_S_CV.Size = New System.Drawing.Size(79, 12)
        Me.lbl_S_CV.TabIndex = 67
        Me.lbl_S_CV.Text = "Custom Vendor"
        '
        'txt_S_CV
        '
        Me.txt_S_CV.Location = New System.Drawing.Point(334, 257)
        Me.txt_S_CV.MaxLength = 5000
        Me.txt_S_CV.Name = "txt_S_CV"
        Me.txt_S_CV.Size = New System.Drawing.Size(575, 22)
        Me.txt_S_CV.TabIndex = 78
        '
        'cmd_S_ItmNo
        '
        Me.cmd_S_ItmNo.Location = New System.Drawing.Point(187, 224)
        Me.cmd_S_ItmNo.Name = "cmd_S_ItmNo"
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_ItmNo.TabIndex = 74
        Me.cmd_S_ItmNo.Text = "「「"
        '
        'cmd_S_SCNo
        '
        Me.cmd_S_SCNo.Location = New System.Drawing.Point(187, 194)
        Me.cmd_S_SCNo.Name = "cmd_S_SCNo"
        Me.cmd_S_SCNo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_SCNo.TabIndex = 72
        Me.cmd_S_SCNo.Text = "「「"
        '
        'cmd_S_PONo
        '
        Me.cmd_S_PONo.Location = New System.Drawing.Point(187, 164)
        Me.cmd_S_PONo.Name = "cmd_S_PONo"
        Me.cmd_S_PONo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_PONo.TabIndex = 69
        Me.cmd_S_PONo.Text = "「「"
        '
        'cmd_S_CustPONo
        '
        Me.cmd_S_CustPONo.Location = New System.Drawing.Point(187, 134)
        Me.cmd_S_CustPONo.Name = "cmd_S_CustPONo"
        Me.cmd_S_CustPONo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_CustPONo.TabIndex = 66
        Me.cmd_S_CustPONo.Text = "「「"
        '
        'cmd_S_SecCust
        '
        Me.cmd_S_SecCust.Location = New System.Drawing.Point(187, 104)
        Me.cmd_S_SecCust.Name = "cmd_S_SecCust"
        Me.cmd_S_SecCust.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_SecCust.TabIndex = 64
        Me.cmd_S_SecCust.Text = "「「"
        '
        'cmd_S_PriCust
        '
        Me.cmd_S_PriCust.Location = New System.Drawing.Point(187, 74)
        Me.cmd_S_PriCust.Name = "cmd_S_PriCust"
        Me.cmd_S_PriCust.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_PriCust.TabIndex = 62
        Me.cmd_S_PriCust.Text = "「「"
        '
        'cmd_S_CoCde
        '
        Me.cmd_S_CoCde.Location = New System.Drawing.Point(187, 44)
        Me.cmd_S_CoCde.Name = "cmd_S_CoCde"
        Me.cmd_S_CoCde.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_CoCde.TabIndex = 60
        Me.cmd_S_CoCde.Text = "「「"
        '
        'lbl_S_ItmNo
        '
        Me.lbl_S_ItmNo.AutoSize = True
        Me.lbl_S_ItmNo.Location = New System.Drawing.Point(37, 230)
        Me.lbl_S_ItmNo.Name = "lbl_S_ItmNo"
        Me.lbl_S_ItmNo.Size = New System.Drawing.Size(43, 12)
        Me.lbl_S_ItmNo.TabIndex = 59
        Me.lbl_S_ItmNo.Text = "Item No"
        '
        'lbl_S_SCNo
        '
        Me.lbl_S_SCNo.AutoSize = True
        Me.lbl_S_SCNo.Location = New System.Drawing.Point(37, 200)
        Me.lbl_S_SCNo.Name = "lbl_S_SCNo"
        Me.lbl_S_SCNo.Size = New System.Drawing.Size(36, 12)
        Me.lbl_S_SCNo.TabIndex = 58
        Me.lbl_S_SCNo.Text = "SC No"
        '
        'lbl_S_PONo
        '
        Me.lbl_S_PONo.AutoSize = True
        Me.lbl_S_PONo.Location = New System.Drawing.Point(37, 170)
        Me.lbl_S_PONo.Name = "lbl_S_PONo"
        Me.lbl_S_PONo.Size = New System.Drawing.Size(36, 12)
        Me.lbl_S_PONo.TabIndex = 57
        Me.lbl_S_PONo.Text = "PO No"
        '
        'lbl_S_CustPO
        '
        Me.lbl_S_CustPO.AutoSize = True
        Me.lbl_S_CustPO.Location = New System.Drawing.Point(37, 140)
        Me.lbl_S_CustPO.Name = "lbl_S_CustPO"
        Me.lbl_S_CustPO.Size = New System.Drawing.Size(60, 12)
        Me.lbl_S_CustPO.TabIndex = 56
        Me.lbl_S_CustPO.Text = "Cust PO No"
        '
        'txt_S_ItmNo
        '
        Me.txt_S_ItmNo.Location = New System.Drawing.Point(334, 227)
        Me.txt_S_ItmNo.MaxLength = 5000
        Me.txt_S_ItmNo.Name = "txt_S_ItmNo"
        Me.txt_S_ItmNo.Size = New System.Drawing.Size(575, 22)
        Me.txt_S_ItmNo.TabIndex = 75
        '
        'txt_S_SCNo
        '
        Me.txt_S_SCNo.Location = New System.Drawing.Point(334, 197)
        Me.txt_S_SCNo.MaxLength = 5000
        Me.txt_S_SCNo.Name = "txt_S_SCNo"
        Me.txt_S_SCNo.Size = New System.Drawing.Size(575, 22)
        Me.txt_S_SCNo.TabIndex = 73
        '
        'txt_S_PONo
        '
        Me.txt_S_PONo.Location = New System.Drawing.Point(334, 167)
        Me.txt_S_PONo.MaxLength = 5000
        Me.txt_S_PONo.Name = "txt_S_PONo"
        Me.txt_S_PONo.Size = New System.Drawing.Size(575, 22)
        Me.txt_S_PONo.TabIndex = 70
        '
        'txt_S_CustPONo
        '
        Me.txt_S_CustPONo.Location = New System.Drawing.Point(334, 137)
        Me.txt_S_CustPONo.MaxLength = 5000
        Me.txt_S_CustPONo.Name = "txt_S_CustPONo"
        Me.txt_S_CustPONo.Size = New System.Drawing.Size(575, 22)
        Me.txt_S_CustPONo.TabIndex = 68
        '
        'txt_S_SecCust
        '
        Me.txt_S_SecCust.Location = New System.Drawing.Point(334, 107)
        Me.txt_S_SecCust.MaxLength = 5000
        Me.txt_S_SecCust.Name = "txt_S_SecCust"
        Me.txt_S_SecCust.Size = New System.Drawing.Size(575, 22)
        Me.txt_S_SecCust.TabIndex = 65
        '
        'txt_S_PriCust
        '
        Me.txt_S_PriCust.Location = New System.Drawing.Point(334, 77)
        Me.txt_S_PriCust.MaxLength = 5000
        Me.txt_S_PriCust.Name = "txt_S_PriCust"
        Me.txt_S_PriCust.Size = New System.Drawing.Size(575, 22)
        Me.txt_S_PriCust.TabIndex = 63
        '
        'txt_S_CoCde
        '
        Me.txt_S_CoCde.Enabled = False
        Me.txt_S_CoCde.Location = New System.Drawing.Point(334, 47)
        Me.txt_S_CoCde.MaxLength = 5000
        Me.txt_S_CoCde.Name = "txt_S_CoCde"
        Me.txt_S_CoCde.Size = New System.Drawing.Size(575, 22)
        Me.txt_S_CoCde.TabIndex = 61
        '
        'lbl_S_SecCust
        '
        Me.lbl_S_SecCust.AutoSize = True
        Me.lbl_S_SecCust.Location = New System.Drawing.Point(37, 110)
        Me.lbl_S_SecCust.Name = "lbl_S_SecCust"
        Me.lbl_S_SecCust.Size = New System.Drawing.Size(69, 12)
        Me.lbl_S_SecCust.TabIndex = 55
        Me.lbl_S_SecCust.Text = "Sec Customer"
        '
        'lbl_S_PriCust
        '
        Me.lbl_S_PriCust.AutoSize = True
        Me.lbl_S_PriCust.Location = New System.Drawing.Point(37, 80)
        Me.lbl_S_PriCust.Name = "lbl_S_PriCust"
        Me.lbl_S_PriCust.Size = New System.Drawing.Size(66, 12)
        Me.lbl_S_PriCust.TabIndex = 54
        Me.lbl_S_PriCust.Text = "Pri Customer"
        '
        'lbl_S_CoCde
        '
        Me.lbl_S_CoCde.AutoSize = True
        Me.lbl_S_CoCde.Location = New System.Drawing.Point(37, 50)
        Me.lbl_S_CoCde.Name = "lbl_S_CoCde"
        Me.lbl_S_CoCde.Size = New System.Drawing.Size(79, 12)
        Me.lbl_S_CoCde.TabIndex = 53
        Me.lbl_S_CoCde.Text = "Company Code"
        '
        'tcPOM00010_2
        '
        Me.tcPOM00010_2.Controls.Add(Me.cmdApvApply)
        Me.tcPOM00010_2.Controls.Add(Me.GroupBox2)
        Me.tcPOM00010_2.Controls.Add(Me.Label6)
        Me.tcPOM00010_2.Controls.Add(Me.dgHeader)
        Me.tcPOM00010_2.Controls.Add(Me.txtResult)
        Me.tcPOM00010_2.Controls.Add(Me.dgApproved)
        Me.tcPOM00010_2.Controls.Add(Me.cmdApprove)
        Me.tcPOM00010_2.Controls.Add(Me.GroupBox1)
        Me.tcPOM00010_2.Location = New System.Drawing.Point(4, 22)
        Me.tcPOM00010_2.Name = "tcPOM00010_2"
        Me.tcPOM00010_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tcPOM00010_2.Size = New System.Drawing.Size(943, 544)
        Me.tcPOM00010_2.TabIndex = 1
        Me.tcPOM00010_2.Text = "(2) Header"
        Me.tcPOM00010_2.UseVisualStyleBackColor = True
        '
        'cmdApvApply
        '
        Me.cmdApvApply.Location = New System.Drawing.Point(356, 3)
        Me.cmdApvApply.Name = "cmdApvApply"
        Me.cmdApvApply.Size = New System.Drawing.Size(91, 24)
        Me.cmdApvApply.TabIndex = 66
        Me.cmdApvApply.Text = "Apply"
        Me.cmdApvApply.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbFinalApv_W)
        Me.GroupBox2.Controls.Add(Me.rbFinalApv_Y)
        Me.GroupBox2.Location = New System.Drawing.Point(84, -3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(263, 30)
        Me.GroupBox2.TabIndex = 65
        Me.GroupBox2.TabStop = False
        '
        'rbFinalApv_W
        '
        Me.rbFinalApv_W.AutoSize = True
        Me.rbFinalApv_W.Location = New System.Drawing.Point(119, 9)
        Me.rbFinalApv_W.Name = "rbFinalApv_W"
        Me.rbFinalApv_W.Size = New System.Drawing.Size(130, 16)
        Me.rbFinalApv_W.TabIndex = 64
        Me.rbFinalApv_W.Text = "W - Wait for Approval"
        Me.rbFinalApv_W.UseVisualStyleBackColor = True
        '
        'rbFinalApv_Y
        '
        Me.rbFinalApv_Y.AutoSize = True
        Me.rbFinalApv_Y.Checked = True
        Me.rbFinalApv_Y.Location = New System.Drawing.Point(16, 9)
        Me.rbFinalApv_Y.Name = "rbFinalApv_Y"
        Me.rbFinalApv_Y.Size = New System.Drawing.Size(85, 16)
        Me.rbFinalApv_Y.TabIndex = 63
        Me.rbFinalApv_Y.TabStop = True
        Me.rbFinalApv_Y.Text = "Y - Approval"
        Me.rbFinalApv_Y.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 12)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "Final Approval"
        '
        'dgHeader
        '
        Me.dgHeader.AllowUserToAddRows = False
        Me.dgHeader.AllowUserToDeleteRows = False
        Me.dgHeader.AllowUserToResizeRows = False
        Me.dgHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgHeader.Location = New System.Drawing.Point(4, 30)
        Me.dgHeader.Name = "dgHeader"
        Me.dgHeader.RowHeadersWidth = 30
        Me.dgHeader.RowTemplate.Height = 24
        Me.dgHeader.Size = New System.Drawing.Size(936, 508)
        Me.dgHeader.TabIndex = 59
        '
        'txtResult
        '
        Me.txtResult.ItemHeight = 12
        Me.txtResult.Location = New System.Drawing.Point(444, 415)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(354, 76)
        Me.txtResult.TabIndex = 61
        Me.txtResult.Visible = False
        '
        'dgApproved
        '
        Me.dgApproved.AllowUserToAddRows = False
        Me.dgApproved.AllowUserToDeleteRows = False
        Me.dgApproved.AllowUserToResizeColumns = False
        Me.dgApproved.AllowUserToResizeRows = False
        Me.dgApproved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgApproved.Location = New System.Drawing.Point(4, 398)
        Me.dgApproved.Name = "dgApproved"
        Me.dgApproved.ReadOnly = True
        Me.dgApproved.RowHeadersWidth = 30
        Me.dgApproved.RowTemplate.Height = 24
        Me.dgApproved.Size = New System.Drawing.Size(434, 94)
        Me.dgApproved.TabIndex = 60
        Me.dgApproved.Visible = False
        '
        'cmdApprove
        '
        Me.cmdApprove.Location = New System.Drawing.Point(800, 443)
        Me.cmdApprove.Name = "cmdApprove"
        Me.cmdApprove.Size = New System.Drawing.Size(128, 48)
        Me.cmdApprove.TabIndex = 56
        Me.cmdApprove.Text = "Approve"
        Me.cmdApprove.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbFinal)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.rbNoUpdate)
        Me.GroupBox1.Controls.Add(Me.rbSignature)
        Me.GroupBox1.Controls.Add(Me.cmdSelectAll)
        Me.GroupBox1.Controls.Add(Me.cmdApply)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtSeqTo)
        Me.GroupBox1.Controls.Add(Me.txtSeqFm)
        Me.GroupBox1.Controls.Add(Me.rb_BelowBasicPrice)
        Me.GroupBox1.Controls.Add(Me.rbMOQMOA)
        Me.GroupBox1.Controls.Add(Me.rbOneTimePrice)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 494)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(928, 48)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Approval Type"
        Me.GroupBox1.Visible = False
        '
        'rbFinal
        '
        Me.rbFinal.Enabled = False
        Me.rbFinal.Location = New System.Drawing.Point(303, 14)
        Me.rbFinal.Name = "rbFinal"
        Me.rbFinal.Size = New System.Drawing.Size(120, 24)
        Me.rbFinal.TabIndex = 52
        Me.rbFinal.Text = "Y - Final Approval"
        Me.rbFinal.Visible = False
        '
        'RadioButton1
        '
        Me.RadioButton1.Enabled = False
        Me.RadioButton1.Location = New System.Drawing.Point(42, 16)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(120, 24)
        Me.RadioButton1.TabIndex = 51
        Me.RadioButton1.Text = "M - MOQ/MOA"
        Me.RadioButton1.Visible = False
        '
        'rbNoUpdate
        '
        Me.rbNoUpdate.Location = New System.Drawing.Point(542, 16)
        Me.rbNoUpdate.Name = "rbNoUpdate"
        Me.rbNoUpdate.Size = New System.Drawing.Size(104, 24)
        Me.rbNoUpdate.TabIndex = 46
        Me.rbNoUpdate.Text = "N - No Update"
        '
        'rbSignature
        '
        Me.rbSignature.Checked = True
        Me.rbSignature.Location = New System.Drawing.Point(163, 14)
        Me.rbSignature.Name = "rbSignature"
        Me.rbSignature.Size = New System.Drawing.Size(104, 24)
        Me.rbSignature.TabIndex = 45
        Me.rbSignature.TabStop = True
        Me.rbSignature.Text = "S - Signature"
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Location = New System.Drawing.Point(676, 16)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(120, 24)
        Me.cmdSelectAll.TabIndex = 50
        Me.cmdSelectAll.Text = "Select All"
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(802, 16)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(120, 24)
        Me.cmdApply.TabIndex = 49
        Me.cmdApply.Text = "Apply"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(504, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(18, 12)
        Me.Label17.TabIndex = 44
        Me.Label17.Text = "To"
        Me.Label17.Visible = False
        '
        'txtSeqTo
        '
        Me.txtSeqTo.Location = New System.Drawing.Point(528, 16)
        Me.txtSeqTo.Name = "txtSeqTo"
        Me.txtSeqTo.Size = New System.Drawing.Size(32, 22)
        Me.txtSeqTo.TabIndex = 48
        Me.txtSeqTo.Visible = False
        '
        'txtSeqFm
        '
        Me.txtSeqFm.Location = New System.Drawing.Point(464, 16)
        Me.txtSeqFm.Name = "txtSeqFm"
        Me.txtSeqFm.Size = New System.Drawing.Size(32, 22)
        Me.txtSeqFm.TabIndex = 47
        Me.txtSeqFm.Visible = False
        '
        'rb_BelowBasicPrice
        '
        Me.rb_BelowBasicPrice.Enabled = False
        Me.rb_BelowBasicPrice.Location = New System.Drawing.Point(26, 16)
        Me.rb_BelowBasicPrice.Name = "rb_BelowBasicPrice"
        Me.rb_BelowBasicPrice.Size = New System.Drawing.Size(136, 24)
        Me.rb_BelowBasicPrice.TabIndex = 43
        Me.rb_BelowBasicPrice.Text = "B - Below Basic Price"
        Me.rb_BelowBasicPrice.Visible = False
        '
        'rbMOQMOA
        '
        Me.rbMOQMOA.Enabled = False
        Me.rbMOQMOA.Location = New System.Drawing.Point(42, 16)
        Me.rbMOQMOA.Name = "rbMOQMOA"
        Me.rbMOQMOA.Size = New System.Drawing.Size(120, 24)
        Me.rbMOQMOA.TabIndex = 44
        Me.rbMOQMOA.Text = "M - MOQ/MOA"
        Me.rbMOQMOA.Visible = False
        '
        'rbOneTimePrice
        '
        Me.rbOneTimePrice.Enabled = False
        Me.rbOneTimePrice.Location = New System.Drawing.Point(8, 16)
        Me.rbOneTimePrice.Name = "rbOneTimePrice"
        Me.rbOneTimePrice.Size = New System.Drawing.Size(120, 24)
        Me.rbOneTimePrice.TabIndex = 42
        Me.rbOneTimePrice.Text = "P - One Time Price"
        Me.rbOneTimePrice.Visible = False
        '
        'tcPOM00010_3
        '
        Me.tcPOM00010_3.Controls.Add(Me.txtAppDat)
        Me.tcPOM00010_3.Controls.Add(Me.Label22)
        Me.tcPOM00010_3.Controls.Add(Me.txtAppCount)
        Me.tcPOM00010_3.Controls.Add(Me.Label21)
        Me.tcPOM00010_3.Controls.Add(Me.txtSignAppFlg)
        Me.tcPOM00010_3.Controls.Add(Me.Label16)
        Me.tcPOM00010_3.Controls.Add(Me.dgDetail)
        Me.tcPOM00010_3.Controls.Add(Me.txtSCNo)
        Me.tcPOM00010_3.Controls.Add(Me.Label20)
        Me.tcPOM00010_3.Controls.Add(Me.txtSecCus)
        Me.tcPOM00010_3.Controls.Add(Me.txtPriCus)
        Me.tcPOM00010_3.Controls.Add(Me.txtPOSts)
        Me.tcPOM00010_3.Controls.Add(Me.txtPONo)
        Me.tcPOM00010_3.Controls.Add(Me.txtCocde)
        Me.tcPOM00010_3.Controls.Add(Me.Label19)
        Me.tcPOM00010_3.Controls.Add(Me.Label18)
        Me.tcPOM00010_3.Controls.Add(Me.Label15)
        Me.tcPOM00010_3.Controls.Add(Me.Label10)
        Me.tcPOM00010_3.Controls.Add(Me.Label2)
        Me.tcPOM00010_3.Location = New System.Drawing.Point(4, 22)
        Me.tcPOM00010_3.Name = "tcPOM00010_3"
        Me.tcPOM00010_3.Padding = New System.Windows.Forms.Padding(3)
        Me.tcPOM00010_3.Size = New System.Drawing.Size(943, 544)
        Me.tcPOM00010_3.TabIndex = 2
        Me.tcPOM00010_3.Text = "(3) Detail"
        Me.tcPOM00010_3.UseVisualStyleBackColor = True
        '
        'txtAppDat
        '
        Me.txtAppDat.Location = New System.Drawing.Point(480, 62)
        Me.txtAppDat.Name = "txtAppDat"
        Me.txtAppDat.ReadOnly = True
        Me.txtAppDat.Size = New System.Drawing.Size(134, 22)
        Me.txtAppDat.TabIndex = 85
        Me.txtAppDat.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(365, 62)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(95, 12)
        Me.Label22.TabIndex = 84
        Me.Label22.Text = "Last Approval Date"
        Me.Label22.Visible = False
        '
        'txtAppCount
        '
        Me.txtAppCount.Location = New System.Drawing.Point(480, 38)
        Me.txtAppCount.Name = "txtAppCount"
        Me.txtAppCount.ReadOnly = True
        Me.txtAppCount.Size = New System.Drawing.Size(134, 22)
        Me.txtAppCount.TabIndex = 83
        Me.txtAppCount.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(365, 38)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(81, 12)
        Me.Label21.TabIndex = 82
        Me.Label21.Text = "Approval Count"
        Me.Label21.Visible = False
        '
        'txtSignAppFlg
        '
        Me.txtSignAppFlg.Location = New System.Drawing.Point(480, 11)
        Me.txtSignAppFlg.Name = "txtSignAppFlg"
        Me.txtSignAppFlg.ReadOnly = True
        Me.txtSignAppFlg.Size = New System.Drawing.Size(134, 22)
        Me.txtSignAppFlg.TabIndex = 81
        Me.txtSignAppFlg.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(365, 14)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 12)
        Me.Label16.TabIndex = 80
        Me.Label16.Text = "Approval Status"
        Me.Label16.Visible = False
        '
        'dgDetail
        '
        Me.dgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetail.Location = New System.Drawing.Point(6, 158)
        Me.dgDetail.Name = "dgDetail"
        Me.dgDetail.RowHeadersWidth = 30
        Me.dgDetail.RowTemplate.Height = 24
        Me.dgDetail.Size = New System.Drawing.Size(935, 383)
        Me.dgDetail.TabIndex = 79
        '
        'txtSCNo
        '
        Me.txtSCNo.Location = New System.Drawing.Point(120, 131)
        Me.txtSCNo.Name = "txtSCNo"
        Me.txtSCNo.ReadOnly = True
        Me.txtSCNo.Size = New System.Drawing.Size(208, 22)
        Me.txtSCNo.TabIndex = 78
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 131)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(60, 12)
        Me.Label20.TabIndex = 77
        Me.Label20.Text = "SC Number"
        '
        'txtSecCus
        '
        Me.txtSecCus.Location = New System.Drawing.Point(120, 107)
        Me.txtSecCus.Name = "txtSecCus"
        Me.txtSecCus.ReadOnly = True
        Me.txtSecCus.Size = New System.Drawing.Size(208, 22)
        Me.txtSecCus.TabIndex = 76
        '
        'txtPriCus
        '
        Me.txtPriCus.Location = New System.Drawing.Point(120, 83)
        Me.txtPriCus.Name = "txtPriCus"
        Me.txtPriCus.ReadOnly = True
        Me.txtPriCus.Size = New System.Drawing.Size(208, 22)
        Me.txtPriCus.TabIndex = 75
        '
        'txtPOSts
        '
        Me.txtPOSts.Location = New System.Drawing.Point(120, 59)
        Me.txtPOSts.Name = "txtPOSts"
        Me.txtPOSts.ReadOnly = True
        Me.txtPOSts.Size = New System.Drawing.Size(208, 22)
        Me.txtPOSts.TabIndex = 74
        '
        'txtPONo
        '
        Me.txtPONo.Location = New System.Drawing.Point(120, 35)
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.ReadOnly = True
        Me.txtPONo.Size = New System.Drawing.Size(208, 22)
        Me.txtPONo.TabIndex = 73
        '
        'txtCocde
        '
        Me.txtCocde.Location = New System.Drawing.Point(120, 11)
        Me.txtCocde.Name = "txtCocde"
        Me.txtCocde.ReadOnly = True
        Me.txtCocde.Size = New System.Drawing.Size(208, 22)
        Me.txtCocde.TabIndex = 72
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(8, 107)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(102, 12)
        Me.Label19.TabIndex = 71
        Me.Label19.Text = "Secondary Customer"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 83)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(90, 12)
        Me.Label18.TabIndex = 70
        Me.Label18.Text = "Primary Customer"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 59)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 12)
        Me.Label15.TabIndex = 69
        Me.Label15.Text = "PO Status"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 12)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "PO Number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 12)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Company"
        '
        'POM00003
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(954, 632)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.tcPOM00010)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "POM00003"
        Me.Text = "POM00003 - Purchase Order Approval Maintenance (POM03)"
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.tcPOM00010.ResumeLayout(False)
        Me.tcPOM00010_1.ResumeLayout(False)
        Me.tcPOM00010_1.PerformLayout()
        Me.tcPOM00010_2.ResumeLayout(False)
        Me.tcPOM00010_2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgApproved, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tcPOM00010_3.ResumeLayout(False)
        Me.tcPOM00010_3.PerformLayout()
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public rs_SYMUSRCO As New DataSet
    Public rs_POM00010 As New DataSet
    Public rs_POM00010_ori As New DataSet
    Public rs_POM00010_AppList As New DataSet

    Public rs_POORDDTL As New DataSet

    Dim dsNewRow As DataRow

    Dim mode As String





    Private Sub POM00010_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        gspStr = "sp_select_SYMUSRCO '','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYMUSRCO, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POM00010 #001 sp_select_SYMUSRCO : " & rtnStr)
        Else
            Dim i As Integer
            Dim strCocde As String
            strCocde = ""

            If rs_SYMUSRCO.Tables("RESULT").Rows.Count > 0 Then
                For i = 0 To rs_SYMUSRCO.Tables("RESULT").Rows.Count - 1
                    If rs_SYMUSRCO.Tables("RESULT").Rows(i).Item("yuc_cocde") <> "MS" Then
                        If i <> rs_SYMUSRCO.Tables("RESULT").Rows.Count - 1 Then
                            strCocde = strCocde + rs_SYMUSRCO.Tables("RESULT").Rows(i).Item("yuc_cocde") + ","
                        Else
                            strCocde = strCocde + rs_SYMUSRCO.Tables("RESULT").Rows(i).Item("yuc_cocde")
                        End If
                    End If
                Next i
            End If

            Me.txt_S_CoCde.Text = strCocde
        End If

        '        Me.txt_S_ShipDateFm.CtlText = "10/01/2010"
        '        Me.txt_S_ShipDateTo.CtlText = "10/05/2010"


        format_dgApproved()




        mode = "INIT"
        Call formInit(mode)


        Call Formstartup(Me.Name)


        txt_S_POIssDateFm.Text = Format(DateAdd(DateInterval.Month, -1, Date.Now), "MM/dd/yyyy")
        txt_S_POIssDateTo.Text = Format(Date.Now, "MM/dd/yyyy")

    End Sub

    Private Sub cmd_S_CoCde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CoCde.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CoCde.Name
        frmComSearch.callFmString = txt_S_CoCde.Text

        frmComSearch.show_POM00010(Me)
    End Sub

    Private Sub cmd_S_PriCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PriCust.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PriCust.Name
        frmComSearch.callFmString = txt_S_PriCust.Text

        frmComSearch.show_POM00010(Me)
    End Sub

    Private Sub cmd_S_SecCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SecCust.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SecCust.Name
        frmComSearch.callFmString = txt_S_SecCust.Text

        frmComSearch.show_POM00010(Me)
    End Sub

    Private Sub cmd_S_CustPONo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CustPONo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CustPONo.Name
        frmComSearch.callFmString = txt_S_CustPONo.Text

        frmComSearch.show_POM00010(Me)
    End Sub

    Private Sub cmd_S_PONo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PONo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PONo.Name
        frmComSearch.callFmString = txt_S_PONo.Text

        frmComSearch.show_POM00010(Me)
    End Sub

    Private Sub cmd_S_SCNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SCNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SCNo.Name
        frmComSearch.callFmString = txt_S_SCNo.Text

        frmComSearch.show_POM00010(Me)
    End Sub

    Private Sub cmd_S_ItmNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_ItmNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_ItmNo.Name
        frmComSearch.callFmString = txt_S_ItmNo.Text

        frmComSearch.show_POM00010(Me)
    End Sub

    Private Sub cmd_S_CV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CV.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CV.Name
        frmComSearch.callFmString = txt_S_CV.Text

        frmComSearch.show_POM00010(Me)
    End Sub

    Private Sub cmd_S_PV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PV.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PV.Name
        frmComSearch.callFmString = txt_S_PV.Text

        frmComSearch.show_POM00010(Me)
    End Sub

    Private Sub cmd_S_SalTem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SalTem.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SalTem.Name
        frmComSearch.callFmString = txt_S_SalTem.Text

        frmComSearch.show_POM00010(Me)
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub mmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click
        'If checkFocus(Me) Then Exit Sub
        Dim COCDELIST As String
        Dim CUS1NOLIST As String
        Dim CUS2NOLIST As String
        Dim CUSPONOLIST As String
        Dim PONOLIST As String
        Dim SCNOLIST As String
        Dim ITMNOLIST As String
        Dim CVLIST As String
        Dim PVLIST As String
        Dim SALESTEAMLIST As String
        Dim POISSDATFM As String
        Dim POISSDATTO As String
        Dim SCISSDATFM As String
        Dim SCISSDATTO As String
        '        Dim SHPDATFM As String
        '        Dim SHPDATTO As String
        Dim CUSTPODATFM As String
        Dim CUSTPODATTO As String

        If Trim(Me.txt_S_CoCde.Text) = "" Then
            MsgBox("The Company Code List is empty!")
            Exit Sub
        Else
            If Len(Me.txt_S_CoCde.Text) > 1000 Then
                MsgBox("The Company Code List is too long (1000 char)")
                Exit Sub
            End If
            COCDELIST = removeduplicateItem(Trim(Me.txt_S_CoCde.Text))
            COCDELIST = Replace(COCDELIST, "'", "''")
        End If

        If Trim(Me.txt_S_PriCust.Text) = "" Then
            CUS1NOLIST = ""
        Else
            If Len(Me.txt_S_PriCust.Text) > 1000 Then
                MsgBox("The Primary Customer List is too long (1000 char)")
                Exit Sub
            End If
            CUS1NOLIST = removeduplicateItem(Trim(Me.txt_S_PriCust.Text))
            CUS1NOLIST = Replace(CUS1NOLIST, "'", "''")
        End If

        If Trim(Me.txt_S_SecCust.Text) = "" Then
            CUS2NOLIST = ""
        Else
            If Len(Me.txt_S_SecCust.Text) > 1000 Then
                MsgBox("The Secondary Customer List is too long (1000 char)")
                Exit Sub
            End If
            CUS2NOLIST = removeduplicateItem(Trim(Me.txt_S_SecCust.Text))
            CUS2NOLIST = Replace(CUS2NOLIST, "'", "''")
        End If

        If Trim(Me.txt_S_CustPONo.Text) = "" Then
            CUSPONOLIST = ""
        Else
            If Len(Me.txt_S_CustPONo.Text) > 1000 Then
                MsgBox("The Customer PO No List is too long (1000 char)")
                Exit Sub
            End If
            CUSPONOLIST = removeduplicateItem(Trim(Me.txt_S_CustPONo.Text))
            CUSPONOLIST = Replace(CUSPONOLIST, "'", "''")
        End If

        If Trim(Me.txt_S_PONo.Text) = "" Then
            PONOLIST = ""
        Else
            If Len(Me.txt_S_PONo.Text) > 1000 Then
                MsgBox("The PO No List is too long (1000 char)")
                Exit Sub
            End If
            PONOLIST = removeduplicateItem(Trim(Me.txt_S_PONo.Text))
            PONOLIST = Replace(PONOLIST, "'", "''")
        End If

        If Trim(Me.txt_S_SCNo.Text) = "" Then
            SCNOLIST = ""
        Else
            If Len(Me.txt_S_SCNo.Text) > 1000 Then
                MsgBox("The SC No List is too long (1000 char)")
                Exit Sub
            End If
            SCNOLIST = removeduplicateItem(Trim(Me.txt_S_SCNo.Text))
            SCNOLIST = Replace(SCNOLIST, "'", "''")
        End If

        If Trim(Me.txt_S_ItmNo.Text) = "" Then
            ITMNOLIST = ""
        Else
            If Len(Me.txt_S_ItmNo.Text) > 1000 Then
                MsgBox("The Item No List is too long (1000 char)")
                Exit Sub
            End If
            ITMNOLIST = removeduplicateItem(Trim(Me.txt_S_ItmNo.Text))
            ITMNOLIST = Replace(ITMNOLIST, "'", "''")
        End If

        If Trim(Me.txt_S_CV.Text) = "" Then
            CVLIST = ""
        Else
            If Len(Me.txt_S_CV.Text) > 1000 Then
                MsgBox("The Custom Vendor List is too long (1000 char)")
                Exit Sub
            End If
            CVLIST = removeduplicateItem(Trim(Me.txt_S_CV.Text))
            CVLIST = Replace(CVLIST, "'", "''")
        End If

        If Trim(Me.txt_S_PV.Text) = "" Then
            PVLIST = ""
        Else
            If Len(Me.txt_S_PV.Text) > 1000 Then
                MsgBox("The Production Vendor List is too long (1000 char)")
                Exit Sub
            End If
            PVLIST = removeduplicateItem(Trim(Me.txt_S_PV.Text))
            PVLIST = Replace(PVLIST, "'", "''")
        End If

        If Trim(Me.txt_S_SalTem.Text) = "" Then
            SALESTEAMLIST = ""
        Else
            If Len(Me.txt_S_SalTem.Text) > 1000 Then
                MsgBox("Then Sales Team List is too long (1000 char)")
                Exit Sub
            End If
            SALESTEAMLIST = removeduplicateItem(Trim(Me.txt_S_SalTem.Text))
            SALESTEAMLIST = Replace(SALESTEAMLIST, "'", "''")
        End If


        If txt_S_POIssDateFm.Text = "  /  /" Then
            POISSDATFM = "01/01/1900"
        Else
            POISSDATFM = txt_S_POIssDateFm.Text
        End If

        If txt_S_POIssDateTo.Text = "  /  /" Then
            POISSDATTO = "01/01/1900"
        Else
            POISSDATTO = txt_S_POIssDateTo.Text
        End If

        If txt_S_POIssDateFm.Text <> "  /  /" Then
            If Not IsDate(txt_S_POIssDateFm.Text) Then
                MsgBox("Invalid Date Format: PO Issue Date From")
                txt_S_POIssDateFm.Focus()
                Exit Sub
            End If
        End If

        If txt_S_POIssDateTo.Text <> "  /  /" Then
            If Not IsDate(txt_S_POIssDateTo.Text) Then
                MsgBox("Invalid Date Format: PO Issue Date To")
                txt_S_POIssDateTo.Focus()
                Exit Sub
            End If
        End If

        If Mid(txt_S_POIssDateFm.Text, 7) > Mid(txt_S_POIssDateTo.Text, 7) Then
            MsgBox("PO Issue Date: End Date < Start Date (YY)")
            txt_S_POIssDateFm.Focus()
            Exit Sub
        ElseIf Mid(txt_S_POIssDateFm.Text, 7) = Mid(txt_S_POIssDateTo.Text, 7) Then
            If txt_S_POIssDateFm.Text.Substring(0, 2) > txt_S_POIssDateTo.Text.Substring(0, 2) Then
                MsgBox("PO Issue Date: End Date < Start Date (MM)")
                txt_S_POIssDateFm.Focus()
                Exit Sub
            ElseIf txt_S_POIssDateFm.Text.Substring(0, 2) = txt_S_POIssDateTo.Text.Substring(0, 2) Then
                If txt_S_POIssDateFm.Text.Substring(3, 2) > txt_S_POIssDateTo.Text.Substring(3, 2) Then
                    MsgBox("PO Issue Date: End Date < Start Date (DD)")
                    txt_S_POIssDateFm.Focus()
                    Exit Sub
                End If
            End If
        End If



        If txt_S_SCIssDateFm.Text = "  /  /" Then
            SCISSDATFM = "01/01/1900"
        Else
            SCISSDATFM = txt_S_SCIssDateFm.Text
        End If

        If txt_S_SCIssDateTo.Text = "  /  /" Then
            SCISSDATTO = "01/01/1900"
        Else
            SCISSDATTO = txt_S_SCIssDateTo.Text
        End If

        If txt_S_SCIssDateFm.Text <> "  /  /" Then
            If Not IsDate(txt_S_SCIssDateFm.Text) Then
                MsgBox("Invalid Date Format: SC Issue Date From")
                txt_S_SCIssDateFm.Focus()
                Exit Sub
            End If
        End If

        If txt_S_SCIssDateTo.Text <> "  /  /" Then
            If Not IsDate(txt_S_SCIssDateTo.Text) Then
                MsgBox("Invalid Date Format: SC Issue Date To")
                txt_S_SCIssDateTo.Focus()
                Exit Sub
            End If
        End If

        If Mid(txt_S_SCIssDateFm.Text, 7) > Mid(txt_S_SCIssDateTo.Text, 7) Then
            MsgBox("SC Issue Date: End Date < Start Date (YY)")
            txt_S_SCIssDateFm.Focus()
            Exit Sub
        ElseIf Mid(txt_S_SCIssDateFm.Text, 7) = Mid(txt_S_SCIssDateTo.Text, 7) Then
            If txt_S_SCIssDateFm.Text.Substring(0, 2) > txt_S_SCIssDateTo.Text.Substring(0, 2) Then
                MsgBox("SC Issue Date: End Date < Start Date (MM)")
                txt_S_SCIssDateFm.Focus()
                Exit Sub
            ElseIf txt_S_SCIssDateFm.Text.Substring(0, 2) = txt_S_SCIssDateTo.Text.Substring(0, 2) Then
                If txt_S_SCIssDateFm.Text.Substring(3, 2) > txt_S_SCIssDateTo.Text.Substring(3, 2) Then
                    MsgBox("SC Issue Date: End Date < Start Date (DD)")
                    txt_S_SCIssDateFm.Focus()
                    Exit Sub
                End If
            End If
        End If


        If txt_S_CustPODateFm.Text = "  /  /" Then
            CUSTPODATFM = "01/01/1900"
        Else
            CUSTPODATFM = txt_S_CustPODateFm.Text
        End If

        If txt_S_CustPODateTo.Text = "  /  /" Then
            CUSTPODATTO = "01/01/1900"
        Else
            CUSTPODATTO = txt_S_CustPODateTo.Text
        End If

        If txt_S_CustPODateFm.Text <> "  /  /" Then
            If Not IsDate(txt_S_CustPODateFm.Text) Then
                MsgBox("Invalid Date Format: Customer PO Date From")
                txt_S_CustPODateFm.Focus()
                Exit Sub
            End If
        End If

        If txt_S_CustPODateTo.Text <> "  /  /" Then
            If Not IsDate(txt_S_CustPODateTo.Text) Then
                MsgBox("Invalid Date Format: Customer PO Date To")
                txt_S_CustPODateTo.Focus()
                Exit Sub
            End If
        End If

        If Mid(txt_S_CustPODateFm.Text, 7) > Mid(txt_S_CustPODateTo.Text, 7) Then
            MsgBox("Customer PO Date: End Date < Start Date (YY)")
            txt_S_CustPODateFm.Focus()
            Exit Sub
        ElseIf Mid(txt_S_CustPODateFm.Text, 7) = Mid(txt_S_CustPODateTo.Text, 7) Then
            If txt_S_CustPODateFm.Text.Substring(0, 2) > txt_S_CustPODateTo.Text.Substring(0, 2) Then
                MsgBox("Customer PO Date: End Date < Start Date (MM)")
                txt_S_CustPODateFm.Focus()
                Exit Sub
            ElseIf txt_S_CustPODateFm.Text.Substring(0, 2) = txt_S_CustPODateTo.Text.Substring(0, 2) Then
                If txt_S_CustPODateFm.Text.Substring(3, 2) > txt_S_CustPODateTo.Text.Substring(3, 2) Then
                    MsgBox("Customer PO Date: End Date < Start Date (DD)")
                    txt_S_CustPODateFm.Focus()
                    Exit Sub
                End If
            End If
        End If




        gspStr = "sp_list_POM00010 '','" & _
                    COCDELIST & "','" & _
                    CUS1NOLIST & "','" & _
                    CUS2NOLIST & "','" & _
                    CUSPONOLIST & "','" & _
                    PONOLIST & "','" & _
                    SCNOLIST & "','" & _
                    ITMNOLIST & "','" & _
                    CVLIST & "','" & _
                    PVLIST & "','" & _
                    SALESTEAMLIST & "','" & _
                    POISSDATFM & "','" & _
                    POISSDATTO & "','" & _
                    SCISSDATFM & "','" & _
                    SCISSDATTO & "','" & _
                    CUSTPODATFM & "','" & _
                    CUSTPODATTO & "','" & _
                    gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_POM00010, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POM00010 #002 sp_list_POM00010 : " & rtnStr)
        Else
            If rs_POM00010.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record found!")
            Else
                dgHeader.DataSource = rs_POM00010.Tables("RESULT").DefaultView

                rs_POM00010.Tables("RESULT").Columns(0).ReadOnly = False
                dgHeader.Columns("Act").ReadOnly = False

                rs_POM00010_ori = rs_POM00010.Copy()

                Call format_dgHeader()

                Me.tcPOM00010.SelectedIndex = 1

                mode = "MODIFY"
                Call formInit(mode)
            End If
        End If

    End Sub

    Private Function removeduplicateItem(ByVal s As String) As String

        Return s

    End Function



    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click

        Dim i As Integer
        Dim s As String
        If rbSignature.Checked = True Then
            s = "S"
        Else
            s = "N"
        End If

        For i = 0 To dgHeader.SelectedRows.Count - 1
            dgHeader.SelectedRows(i).Cells("Act").Value = s
        Next i


    End Sub



    Private Sub cmdApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApprove.Click
        Dim i As Integer

        Dim sCocde As String
        Dim sPONo As String
        Dim sAppFlg As String

        For i = 0 To dgHeader.SelectedRows.Count - 1
            If dgHeader.SelectedRows(i).Cells("Act").Value <> "W" Then
                sAppFlg = dgHeader.SelectedRows(i).Cells("Act").Value
                sCocde = dgHeader.SelectedRows(i).Cells("Comp").Value
                sPONo = dgHeader.SelectedRows(i).Cells("PO No").Value

                gspStr = "sp_update_POM00010 '" & sCocde & "','" & sPONo & "','" & sAppFlg & "','" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

                If rtnLong <> RC_SUCCESS Then
                    Me.txtResult.Items.Add(sPONo & " : approval failure (" & rtnStr & ")")
                Else
                    Me.txtResult.Items.Add(sPONo & " : approval sucessful" & rtnStr)

                    dsNewRow = rs_POM00010_AppList.Tables("RESULT").NewRow()

                    dsNewRow.Item("Act") = sAppFlg
                    dsNewRow.Item("Comp") = sCocde
                    dsNewRow.Item("PO No") = sPONo

                    rs_POM00010_AppList.Tables("RESULT").Rows.Add(dsNewRow)

                End If
            End If
        Next i
        Call mmdFind_Click(sender, e)


    End Sub



    Private Sub dgHeader_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub tcPOM00010_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcPOM00010.SelectedIndexChanged

        If mode = "INIT" Then
            '   Me.tcPOM00010.SelectedIndex = 0
        ElseIf mode = "MODIFY" And Me.tcPOM00010.SelectedIndex = 0 Then
            '    Me.tcPOM00010.SelectedIndex = 1
        ElseIf mode = "MODIFY" And Me.tcPOM00010.SelectedIndex = 2 Then
            Call displayPODetail()
        End If

    End Sub


    Private Sub formInit(ByVal m As String)
        If m = "INIT" Then
            Me.mmdAdd.Enabled = False
            Me.mmdSave.Enabled = False
            Me.mmdDelete.Enabled = False
            Me.mmdCopy.Enabled = False
            Me.mmdFind.Enabled = True
            Me.mmdClear.Enabled = True

            Me.mmdSearch.Enabled = False

            Me.mmdInsRow.Enabled = False
            Me.mmdDelRow.Enabled = False
            'Me.cmdFirst.Enabled = False
            'Me.cmdPrevious.Enabled = False
            'Me.cmdNext.Enabled = False
            'Me.cmdLast.Enabled = False
            Me.mmdPrint.Enabled = False
            Me.mmdAttach.Enabled = False
            Me.mmdFunction.Enabled = False
            Me.mmdLink.Enabled = False
            Me.mmdExit.Enabled = True

            Me.tcPOM00010.TabPages(0).Enabled = True
            Me.tcPOM00010.TabPages(1).Enabled = False
            Me.tcPOM00010.TabPages(2).Enabled = False

            Me.tcPOM00010.SelectedIndex = 0

            Me.txtResult.Items.Clear()
            rs_POM00010_AppList.Clear()

        ElseIf m = "MODIFY" Then
            Me.mmdAdd.Enabled = False
            Me.mmdSave.Enabled = True
            Me.mmdDelete.Enabled = False
            Me.mmdCopy.Enabled = False
            Me.mmdFind.Enabled = False
            Me.mmdClear.Enabled = True

            Me.mmdSearch.Enabled = False

            Me.mmdInsRow.Enabled = False
            Me.mmdDelRow.Enabled = False
            'Me.cmdFirst.Enabled = True
            'Me.cmdPrevious.Enabled = True
            'Me.cmdNext.Enabled = True
            'Me.cmdLast.Enabled = True
            Me.mmdPrint.Enabled = False
            Me.mmdAttach.Enabled = False
            Me.mmdFunction.Enabled = False
            Me.mmdLink.Enabled = False
            Me.mmdExit.Enabled = True

            Me.tcPOM00010.TabPages(0).Enabled = False
            Me.tcPOM00010.TabPages(1).Enabled = True
            Me.tcPOM00010.TabPages(2).Enabled = False

            Me.tcPOM00010.SelectedIndex = 1
        End If


    End Sub




    Private Sub displayPODetail()
        Dim sCocde As String
        Dim sPONo As String
        Dim sPOSts As String
        Dim sPriCus As String
        Dim sSecCus As String
        Dim sSCNo As String
        Dim sSignAppFlg As String
        Dim sAppCount As String
        Dim sAppDate As String


        If dgHeader.SelectedRows.Count > 0 Then
            sCocde = dgHeader.SelectedRows(0).Cells("Comp").Value
            sPONo = dgHeader.SelectedRows(0).Cells("PO No").Value
            sPOSts = dgHeader.SelectedRows(0).Cells("PO Sts").Value
            'sPriCus = dgHeader.SelectedRows(0).Cells("Pri Cust").Value & " - " & 
            sPriCus = dgHeader.SelectedRows(0).Cells("Pri Cust Name").Value
            'sSecCus = dgHeader.SelectedRows(0).Cells("Sec Cust").Value & " - " & 
            sSecCus = dgHeader.SelectedRows(0).Cells("Sec Cust Name").Value
            sSignAppFlg = dgHeader.SelectedRows(0).Cells("App Sts").Value
            sAppCount = dgHeader.SelectedRows(0).Cells("App Cnt").Value
            sAppDate = dgHeader.SelectedRows(0).Cells("App Date").Value

            If sSecCus = " - " Then
                sSecCus = ""
            End If
            sSCNo = dgHeader.SelectedRows(0).Cells("SC No").Value


            gspStr = "sp_select_POORDDTL '" & sCocde & "','" & sPONo & "'"

            rtnLong = execute_SQLStatement(gspStr, rs_POORDDTL, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading POM00010 #003 sp_select_POORDDTL : " & rtnStr)
            Else
                txtCocde.Text = sCocde
                txtPONo.Text = sPONo
                txtPOSts.Text = sPOSts
                txtPriCus.Text = sPriCus
                txtSecCus.Text = sSecCus
                txtSCNo.Text = sSCNo

                If sSignAppFlg = "S" Then
                    txtSignAppFlg.Text = sSignAppFlg + " - Signature Approved"
                Else
                    txtSignAppFlg.Text = sSignAppFlg + " - None"
                End If

                txtAppCount.Text = sAppCount
                txtAppDat.Text = sAppDate

                Me.dgDetail.DataSource = rs_POORDDTL.Tables("RESULT").DefaultView
                Call format_dgDetail()

            End If
        End If


    End Sub



    Private Sub format_dgApproved()


        If rs_POM00010_AppList.Tables.Count = 0 Then
            rs_POM00010_AppList.Tables.Add("RESULT")
            rs_POM00010_AppList.Tables("RESULT").Columns.Add("Act")
            rs_POM00010_AppList.Tables("RESULT").Columns.Add("Comp")
            rs_POM00010_AppList.Tables("RESULT").Columns.Add("PO No")

            dgApproved.DataSource = rs_POM00010_AppList.Tables("RESULT").DefaultView
        End If


        dgApproved.Columns(0).Width = 30
        dgApproved.Columns(0).HeaderText = "Act"

        dgApproved.Columns(1).Width = 45
        dgApproved.Columns(1).HeaderText = "Comp"

        dgApproved.Columns(2).Width = 80
        dgApproved.Columns(2).HeaderText = "PO No"

    End Sub

    Private Sub format_dgHeader()
        Dim i As Integer
        i = 0
        With dgHeader
            .Columns(i).Width = 35
            .Columns(i).ReadOnly = True
            .Columns(i).HeaderText = "Final Apv"
            .Columns(i).DefaultCellStyle.BackColor = Color.LightBlue
            i = i + 1
            .Columns(i).Width = 32
            .Columns(i).HeaderText = "App Sts"
            .Columns(i).Visible = False
            i = i + 1
            .Columns(i).Width = 32
            .Columns(i).HeaderText = "App Cnt"
            .Columns(i).Visible = False
            i = i + 1
            .Columns(i).Visible = False
            i = i + 1
            .Columns(i).Width = 42
            .Columns(i).HeaderText = "Comp"
            .Columns(i).Visible = False
            i = i + 1
            .Columns(i).Width = 68
            .Columns(i).HeaderText = "PO No"
            i = i + 1
            .Columns(i).Width = 35
            .Columns(i).HeaderText = "PO Sts"
            .Columns(i).Visible = False
            i = i + 1
            .Columns(i).Width = 42
            .Columns(i).HeaderText = "Pri Cust"
            .Columns(i).Visible = False
            i = i + 1
            .Columns(i).Width = 100
            .Columns(i).HeaderText = "Pri Cust Name"
            i = i + 1
            .Columns(i).Width = 42
            .Columns(i).HeaderText = "Sec Cust"
            .Columns(i).Visible = False
            i = i + 1
            .Columns(i).Width = 100
            .Columns(i).HeaderText = "Sec Cust Name"
            i = i + 1
            .Columns(i).Width = 80
            .Columns(i).HeaderText = "PO Date"
            .Columns(i).Visible = False
            i = i + 1
            .Columns(i).Width = 80
            .Columns(i).HeaderText = "Cust PO No"
            .Columns(i).Visible = False
            i = i + 1
            .Columns(i).Width = 68
            .Columns(i).HeaderText = "SC No"
            i = i + 1
            .Columns(i).Width = 36
            .Columns(i).HeaderText = "CV"
            .Columns(i).Visible = False
            i = i + 1
            .Columns(i).Width = 65
            .Columns(i).HeaderText = "CV Name"
            i = i + 1
            .Columns(i).Width = 30
            .Columns(i).HeaderText = "Price Term Diff"
            .Columns(i).DefaultCellStyle.BackColor = Color.LightBlue
            i = i + 1
            .Columns(i).Width = 55
            .Columns(i).HeaderText = "Curr Price Term "
            i = i + 1
            .Columns(i).Width = 55
            .Columns(i).HeaderText = "Org Price Term"
            i = i + 1
            .Columns(i).Width = 30
            .Columns(i).HeaderText = "Pay Term Diff"
            .Columns(i).DefaultCellStyle.BackColor = Color.LightBlue
            i = i + 1
            .Columns(i).Width = 120
            .Columns(i).HeaderText = "Curr Pay Term"
            i = i + 1
            .Columns(i).Width = 120
            .Columns(i).HeaderText = "Org Pay Term"
            i = i + 1
            .Columns(i).Width = 32
            .Columns(i).HeaderText = "Apv Check"
            '            .Columns(i).Visible = False
            i = i + 1
            .Columns(i).Width = 150
            .Columns(i).HeaderText = "Check Reason"
            '           .Columns(i).Visible = False

        End With

    End Sub

    Private Sub format_dgDetail()
        Dim i As Integer
        i = 0
        With dgDetail
            '0
            .Columns(i).Width = 30
            .Columns(i).HeaderText = "Seq"
            i = i + 1
            '1
            .Columns(i).Width = 100
            .Columns(i).HeaderText = "Item"
            i = i + 1
            '2
            .Columns(i).Width = 100
            .Columns(i).HeaderText = "Job No"
            i = i + 1
            '3
            .Columns(i).Visible = False
            i = i + 1
            '4
            .Columns(i).Width = 100
            .Columns(i).HeaderText = "Ven Item No"
            i = i + 1
            '5
            .Columns(i).Width = 100
            .Columns(i).HeaderText = "Cust Item No"
            i = i + 1
            '6
            .Columns(i).Visible = False
            i = i + 1
            '7
            .Columns(i).Width = 100
            .Columns(i).HeaderText = "Vdr Color"
            i = i + 1
            '8
            .Columns(i).Width = 80
            .Columns(i).HeaderText = "Cust Color"
            i = i + 1
            '9
            .Columns(i).Visible = False
            i = i + 1
            '10
            .Columns(i).Width = 120
            .Columns(i).HeaderText = "Packing"
            i = i + 1
            '11
            .Columns(i).Visible = False
            i = i + 1
            '12
            .Columns(i).Width = 50
            .Columns(i).HeaderText = "Order Qty"
            i = i + 1
            '13
            .Columns(i).Visible = False
            i = i + 1
            '14
            .Columns(i).Width = 50
            .Columns(i).HeaderText = "Curr"
            i = i + 1
            '15
            .Columns(i).Width = 60
            .Columns(i).HeaderText = "FtyPrc"
            i = i + 1

            Dim j As Integer
            For j = i To dgDetail.Columns.Count - 1
                .Columns(j).Visible = False
            Next j

        End With

    End Sub
    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'TabControl1.TabPages(1).Enabled = False
        'Me.BaseTabControl1.tabpages(1).enabled = False

        'Dim iTotalTabs As Integer
        'iTotalTabs = Me.TabControl1.TabCount()
        'Dim X As Integer
        'For X = 0 To iTotalTabs - 1
        ' With Me.TabControl1.TabPages(X)
        ' .Enabled = False
        ' If .Name = "TabPage2" Or .Name = "TabPage4" Then
        '.Enabled = True
        'End If
        'End With
        'Next

        '    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        '       ' Check Credentials Here
        '      If CredentialCheck.Checked = True And _
        '     TabControl1.SelectedTab Is TabPage2 Then
        '    TabControl1.SelectedTab = TabPage2
        '   ElseIf CredentialCheck.Checked = False _
        '  And TabControl1.SelectedTab Is TabPage2 Then
        ' MessageBox.Show _
        '("Unable to load tab. You have insufficient access privileges.")
        'TabControl1.SelectedTab = TabPage3
        ' End If
        'End Sub



    End Sub

    Private Sub cmdPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'TabControl1.TabPages(1).Enabled = True
        'Me.BaseTabControl1.tabpages(1).enabled = True
    End Sub

    Private Sub dgHeader_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        If checkFocus(Me) Then Exit Sub
        Me.Close()
    End Sub

    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        If checkFocus(Me) Then Exit Sub
        If checkChangesMade() = True Then
            Dim response As Integer
            response = MsgBox("Changes have been made. Would you like to save changes before clearing?", MsgBoxStyle.YesNoCancel)

            If response = MsgBoxResult.Yes Then
                If mmdSave.Enabled = True Then
                    mmdSave.PerformClick()
                    Exit Sub
                Else
                    MsgBox("You do not have authority to save changes", MsgBoxStyle.Critical, "POM00010 - Saving")
                    Exit Sub
                End If
            ElseIf response = MsgBoxResult.No Then
                Call Me.formInit("INIT")
                Exit Sub
            Else
                Exit Sub
            End If
        End If
        Call Me.formInit("INIT")


        'Call Me.formInit("INIT")
    End Sub

    Private Sub dgHeader_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgHeader.CellClick
        If dgHeader.Focused = True And e.RowIndex >= 0 Then
            Select Case e.ColumnIndex
                Case 0
                    If dgHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "W" And dgHeader.Rows(e.RowIndex).Cells(22).Value = "Pass" Then
                        dgHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "Y"
                    ElseIf dgHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "W" And dgHeader.Rows(e.RowIndex).Cells(22).Value = "Fail" Then
                        MsgBox(dgHeader.Rows(e.RowIndex).Cells(23).Value.ToString())
                        dgHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "W"
                    ElseIf dgHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "Y" Then
                        dgHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "W"
                    End If
            End Select
        End If
    End Sub

    Private Sub dgHeader_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgHeader.CellContentClick

    End Sub

    Private Sub mmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        If checkFocus(Me) Then Exit Sub
        Dim before() As DataRow
        Dim rs_sql As DataSet


        Dim sCocde As String
        Dim sPONo As String
        Dim sAppFlg As String


        ' Saving Detail
        For i As Integer = 0 To rs_POM00010.Tables("RESULT").Rows.Count - 1
            before = Nothing
            before = rs_POM00010_ori.Tables("RESULT").Select("[PO No] = '" & rs_POM00010.Tables("RESULT").Rows(i)("PO No") & "'")

            If before.Length > 0 Then
                If checkChangesMade(before(0), rs_POM00010.Tables("RESULT").Rows(i)) = True Then
                    If rs_POM00010.Tables("RESULT").Rows(i)("Act") <> "W" Then
                        sAppFlg = rs_POM00010.Tables("RESULT").Rows(i)("Act")
                        sCocde = rs_POM00010.Tables("RESULT").Rows(i)("Comp")
                        sPONo = rs_POM00010.Tables("RESULT").Rows(i)("PO No")

                        gspStr = "sp_update_POM00010 '" & sCocde & "','" & sPONo & "','" & sAppFlg & "','" & gsUsrID & "'"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor

                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        Me.Cursor = Windows.Forms.Cursors.Default

                        If rtnLong <> RC_SUCCESS Then
                            Me.txtResult.Items.Add(sPONo & " : approval failure (" & rtnStr & ")")
                        Else
                            Me.txtResult.Items.Add(sPONo & " : approval sucessful" & rtnStr)

                            dsNewRow = rs_POM00010_AppList.Tables("RESULT").NewRow()

                            dsNewRow.Item("Act") = sAppFlg
                            dsNewRow.Item("Comp") = sCocde
                            dsNewRow.Item("PO No") = sPONo

                            rs_POM00010_AppList.Tables("RESULT").Rows.Add(dsNewRow)
                        End If
                    Else
                        sAppFlg = rs_POM00010.Tables("RESULT").Rows(i)("Act")
                        sCocde = rs_POM00010.Tables("RESULT").Rows(i)("Comp")
                        sPONo = rs_POM00010.Tables("RESULT").Rows(i)("PO No")

                        gspStr = "sp_update_POM00010 '" & sCocde & "','" & sPONo & "','" & sAppFlg & "','" & gsUsrID & "'"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor

                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        Me.Cursor = Windows.Forms.Cursors.Default
                    End If
                End If
            Else
                MsgBox("Missing original detail entry")
                Exit Sub
            End If
        Next
        'Call mmdFind_Click(sender, e)

        MsgBox("Save Complete")
        Call Me.formInit("INIT")
    End Sub

    Private Function checkChangesMade(ByVal before As DataRow, ByVal after As DataRow) As Boolean
        If before Is Nothing Or after Is Nothing Then
            Return False
        End If

        For i As Integer = 0 To after.ItemArray.Length - 1
            If before.Item(i).ToString <> after.Item(i).ToString Then
                Return True
            End If
        Next

        Return False
    End Function



    Private Function checkChangesMade() As Boolean
        If rs_POM00010 Is Nothing And rs_POM00010_ori Is Nothing Then
            Return False
        End If

        Dim row() As DataRow

        If rs_POM00010.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_POM00010.Tables("RESULT").Rows.Count - 1
                row = Nothing
                row = rs_POM00010_ori.Tables("RESULT").Select("[PO No] = '" & rs_POM00010.Tables("RESULT").Rows(i)("PO No") & "'")
                If row.Length > 0 Then
                    If row(0)(0) <> rs_POM00010.Tables("RESULT").Rows(i)(0) Then
                        Return True
                    End If
                Else
                    Return True
                End If
            Next
        Else
            Return False
        End If

        Return False
    End Function


    Private Sub txt_S_SCIssDateFm_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txt_S_SCIssDateFm.MaskInputRejected

    End Sub
    Private Sub txt_S_SCIssDateTo_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txt_S_SCIssDateTo.MaskInputRejected

    End Sub

    Private Sub cmdApvApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApvApply.Click
        Dim i As Integer
        Dim s As String
        If rbFinalApv_Y.Checked = True Then
            s = "Y"
        Else
            s = "W"
        End If

        Dim check As Boolean
        Dim checkmsg As String
        check = True
        checkmsg = ""

        For i = 0 To dgHeader.SelectedRows.Count - 1
            If s = "Y" And dgHeader.SelectedRows(i).Cells(0).Value = "W" Then
                If dgHeader.SelectedRows(i).Cells(22).Value = "Pass" Then
                    'dgHeader.SelectedRows(i).Cells(0).Value = "Y"
                ElseIf dgHeader.SelectedRows(i).Cells(22).Value = "Fail" Then
                    'MsgBox(dgHeader.SelectedRows(i).Cells(23).Value.ToString())
                    checkmsg = checkmsg & dgHeader.SelectedRows(i).Cells(5).Value & "; "
                    check = False
                    'dgHeader.SelectedRows(i).Cells(0).Value = "W"
                End If
            End If
        Next i

        If check = False Then
            If MsgBox("The following PO cannot be approved, Are you sure to continue? " & checkmsg, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                For i = 0 To dgHeader.SelectedRows.Count - 1
                    If s = "Y" And dgHeader.SelectedRows(i).Cells(0).Value = "W" Then
                        If dgHeader.SelectedRows(i).Cells(22).Value = "Pass" Then
                            dgHeader.SelectedRows(i).Cells(0).Value = "Y"
                        ElseIf dgHeader.SelectedRows(i).Cells(22).Value = "Fail" Then
                            'MsgBox(dgHeader.SelectedRows(i).Cells(23).Value.ToString())
                            'checkmsg = dgHeader.SelectedRows(i).Cells(5).Value & "; "
                            'check = False
                            dgHeader.SelectedRows(i).Cells(0).Value = "W"
                        End If
                    End If
                Next i
            End If
        Else
            For i = 0 To dgHeader.SelectedRows.Count - 1
                If s = "Y" And dgHeader.SelectedRows(i).Cells(0).Value = "W" Then
                    dgHeader.SelectedRows(i).Cells(0).Value = "Y"
                ElseIf s = "W" And dgHeader.SelectedRows(i).Cells(0).Value = "Y" Then
                    dgHeader.SelectedRows(i).Cells(0).Value = "W"
                End If
            Next i
        End If


    End Sub

    Private Sub mmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAdd.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelete.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdCopy.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSearch.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdPrint.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAttach.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdFunction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFunction.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdLink.Click
        If checkFocus(Me) Then Exit Sub
    End Sub
End Class
