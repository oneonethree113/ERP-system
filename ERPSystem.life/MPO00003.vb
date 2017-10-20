Public Class MPO00003

    Inherits System.Windows.Forms.Form

    Dim rs_MPORDHDR As New DataSet
    Dim rs_MPORDDTL As New DataSet
    Dim rs_Except As New DataSet
    Dim rs_Except_ref As New DataSet
    'Dim rs_MPORDHDR_Blk As New DataSet
    Dim rs_MPORDDTL_Blk As New DataSet
    Dim rs_MPORDHDR_Blk As New DataSet
    Dim save_ok As Boolean
    Dim bolFind As Boolean

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim readingindex As Integer





#Region " Windows Form Designer generated code"
    Friend WithEvents SSTab1 As ERPSystem.BaseTabControl
    Friend WithEvents tpMPO00003_1 As System.Windows.Forms.TabPage
    Friend WithEvents tpMPO00003_2 As System.Windows.Forms.TabPage
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents cmdspecial As System.Windows.Forms.Button
    Friend WithEvents cmdbrowlist As System.Windows.Forms.Button
    Friend WithEvents tpMPO00003_3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents optCtrSiz3 As System.Windows.Forms.RadioButton
    Friend WithEvents optCtrSiz2 As System.Windows.Forms.RadioButton
    Friend WithEvents optCtrSiz1 As System.Windows.Forms.RadioButton
    Friend WithEvents optCtrSiz0 As System.Windows.Forms.RadioButton
    Friend WithEvents optCtrSiz4 As System.Windows.Forms.RadioButton
    Friend WithEvents cboPckRmk As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtColDsc As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtCustUM As System.Windows.Forms.TextBox
    Friend WithEvents optSearch1 As System.Windows.Forms.RadioButton
    Friend WithEvents optSearch0 As System.Windows.Forms.RadioButton
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtInrCtn As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtUntCde As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtVol As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtMtrCtn As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents txtTtlVolD As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtActVol As System.Windows.Forms.TextBox
    Friend WithEvents txtMtrhcm As System.Windows.Forms.TextBox
    Friend WithEvents txtMtrwcm As System.Windows.Forms.TextBox
    Friend WithEvents txtMtrdcm As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents txtTtlNetD As System.Windows.Forms.TextBox
    Friend WithEvents txtNetWgt As System.Windows.Forms.TextBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents txtTtlGrsD As System.Windows.Forms.TextBox
    Friend WithEvents txtGrsWgt As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txtCmpRmk As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents cboPCPrc As System.Windows.Forms.ComboBox
    Friend WithEvents txtCusVen As System.Windows.Forms.TextBox
    Friend WithEvents txtVenNo As System.Windows.Forms.TextBox
    Friend WithEvents txtPurOrd As System.Windows.Forms.TextBox
    Friend WithEvents txtColCde As System.Windows.Forms.TextBox
    Friend WithEvents grdMPOHdr As System.Windows.Forms.DataGridView
    Friend WithEvents txtOrdSeq As System.Windows.Forms.TextBox
    Friend WithEvents txtItmTyp As System.Windows.Forms.TextBox
    Friend WithEvents txtPrcTrm As System.Windows.Forms.TextBox
    Friend WithEvents txtOrgQty As System.Windows.Forms.TextBox
    Friend WithEvents txtOutQty As System.Windows.Forms.TextBox
    Friend WithEvents txtPayTrm As System.Windows.Forms.TextBox
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents StatusBar As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents cboCus2No_dtl As System.Windows.Forms.ComboBox
    Friend WithEvents txtmodvol As System.Windows.Forms.TextBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents RichTextBox3 As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents tpMPO00003_4 As System.Windows.Forms.TabPage
    Friend WithEvents grdExcept As System.Windows.Forms.DataGridView
    Friend WithEvents grdMPODtl As System.Windows.Forms.DataGridView
    Friend WithEvents cmdLastD As System.Windows.Forms.Button
    Friend WithEvents cmdPrevD As System.Windows.Forms.Button
    Friend WithEvents cmdNextD As System.Windows.Forms.Button
    Friend WithEvents cmdFirstD As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPONo As System.Windows.Forms.TextBox
    Friend WithEvents grdExcept_ref As System.Windows.Forms.DataGridView
    Friend WithEvents frmApproveReject As System.Windows.Forms.GroupBox
    Friend WithEvents chkReject As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFm As System.Windows.Forms.TextBox
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPOFm As System.Windows.Forms.TextBox
    Friend WithEvents txtUplDatTo As System.Windows.Forms.TextBox
    Friend WithEvents lblIssDat As System.Windows.Forms.Label
    Friend WithEvents txtUplDatFm As System.Windows.Forms.TextBox
    Friend WithEvents lblRvsDat As System.Windows.Forms.Label
    Friend WithEvents txtPOTo As System.Windows.Forms.TextBox
    Friend WithEvents chkApprove As System.Windows.Forms.CheckBox
    Friend WithEvents frmException As System.Windows.Forms.GroupBox
    Friend WithEvents optHdr As System.Windows.Forms.RadioButton
    Friend WithEvents optDtl As System.Windows.Forms.RadioButton
    Friend WithEvents frmStatus As System.Windows.Forms.GroupBox
    Friend WithEvents optALL As System.Windows.Forms.RadioButton
    Friend WithEvents optWait As System.Windows.Forms.RadioButton
    Friend WithEvents txtMsg As System.Windows.Forms.RichTextBox

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
        Me.frmApproveReject = New System.Windows.Forms.GroupBox
        Me.chkReject = New System.Windows.Forms.CheckBox
        Me.chkApprove = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtFm = New System.Windows.Forms.TextBox
        Me.cmdApply = New System.Windows.Forms.Button
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPOFm = New System.Windows.Forms.TextBox
        Me.txtUplDatTo = New System.Windows.Forms.TextBox
        Me.lblIssDat = New System.Windows.Forms.Label
        Me.txtUplDatFm = New System.Windows.Forms.TextBox
        Me.lblRvsDat = New System.Windows.Forms.Label
        Me.txtPOTo = New System.Windows.Forms.TextBox
        Me.frmException = New System.Windows.Forms.GroupBox
        Me.optHdr = New System.Windows.Forms.RadioButton
        Me.optDtl = New System.Windows.Forms.RadioButton
        Me.frmStatus = New System.Windows.Forms.GroupBox
        Me.optALL = New System.Windows.Forms.RadioButton
        Me.optWait = New System.Windows.Forms.RadioButton
        Me.txtMsg = New System.Windows.Forms.RichTextBox
        Me.SSTab1 = New ERPSystem.BaseTabControl
        Me.tpMPO00003_1 = New System.Windows.Forms.TabPage
        Me.grdExcept = New System.Windows.Forms.DataGridView
        Me.tpMPO00003_2 = New System.Windows.Forms.TabPage
        Me.cmdLastD = New System.Windows.Forms.Button
        Me.cmdPrevD = New System.Windows.Forms.Button
        Me.cmdNextD = New System.Windows.Forms.Button
        Me.cmdFirstD = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPONo = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.grdExcept_ref = New System.Windows.Forms.DataGridView
        Me.txtmodvol = New System.Windows.Forms.TextBox
        Me.txtCusVen = New System.Windows.Forms.TextBox
        Me.txtVenNo = New System.Windows.Forms.TextBox
        Me.cboPCPrc = New System.Windows.Forms.ComboBox
        Me.optSearch1 = New System.Windows.Forms.RadioButton
        Me.optSearch0 = New System.Windows.Forms.RadioButton
        Me.Label30 = New System.Windows.Forms.Label
        Me.txtPurOrd = New System.Windows.Forms.TextBox
        Me.txtVol = New System.Windows.Forms.TextBox
        Me.txtColCde = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.txtMtrCtn = New System.Windows.Forms.TextBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label56 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txtCmpRmk = New System.Windows.Forms.TextBox
        Me.cboCus2No_dtl = New System.Windows.Forms.ComboBox
        Me.Label52 = New System.Windows.Forms.Label
        Me.txtTtlNetD = New System.Windows.Forms.TextBox
        Me.Label88 = New System.Windows.Forms.Label
        Me.txtNetWgt = New System.Windows.Forms.TextBox
        Me.Label49 = New System.Windows.Forms.Label
        Me.Label50 = New System.Windows.Forms.Label
        Me.txtTtlGrsD = New System.Windows.Forms.TextBox
        Me.txtGrsWgt = New System.Windows.Forms.TextBox
        Me.txtItmTyp = New System.Windows.Forms.TextBox
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.txtTtlVolD = New System.Windows.Forms.TextBox
        Me.txtOrdSeq = New System.Windows.Forms.TextBox
        Me.Label46 = New System.Windows.Forms.Label
        Me.txtActVol = New System.Windows.Forms.TextBox
        Me.txtMtrhcm = New System.Windows.Forms.TextBox
        Me.txtMtrwcm = New System.Windows.Forms.TextBox
        Me.txtMtrdcm = New System.Windows.Forms.TextBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.txtOrgQty = New System.Windows.Forms.TextBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.txtInrCtn = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.txtUntCde = New System.Windows.Forms.TextBox
        Me.cboPckRmk = New System.Windows.Forms.ComboBox
        Me.txtColDsc = New System.Windows.Forms.TextBox
        Me.txtOutQty = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.txtPrcTrm = New System.Windows.Forms.TextBox
        Me.txtPayTrm = New System.Windows.Forms.TextBox
        Me.optCtrSiz3 = New System.Windows.Forms.RadioButton
        Me.optCtrSiz4 = New System.Windows.Forms.RadioButton
        Me.optCtrSiz0 = New System.Windows.Forms.RadioButton
        Me.optCtrSiz1 = New System.Windows.Forms.RadioButton
        Me.optCtrSiz2 = New System.Windows.Forms.RadioButton
        Me.txtCustUM = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.tpMPO00003_3 = New System.Windows.Forms.TabPage
        Me.grdMPOHdr = New System.Windows.Forms.DataGridView
        Me.tpMPO00003_4 = New System.Windows.Forms.TabPage
        Me.grdMPODtl = New System.Windows.Forms.DataGridView
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmApproveReject.SuspendLayout()
        Me.frmException.SuspendLayout()
        Me.frmStatus.SuspendLayout()
        Me.SSTab1.SuspendLayout()
        Me.tpMPO00003_1.SuspendLayout()
        CType(Me.grdExcept, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpMPO00003_2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdExcept_ref, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.tpMPO00003_3.SuspendLayout()
        CType(Me.grdMPOHdr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpMPO00003_4.SuspendLayout()
        CType(Me.grdMPODtl, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.cmdLast.Location = New System.Drawing.Point(794, 0)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(38, 34)
        Me.cmdLast.TabIndex = 13
        Me.cmdLast.TabStop = False
        Me.cmdLast.Text = ">>|"
        '
        'cmdPrv
        '
        Me.cmdPrv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdPrv.Location = New System.Drawing.Point(720, 0)
        Me.cmdPrv.Name = "cmdPrv"
        Me.cmdPrv.Size = New System.Drawing.Size(38, 34)
        Me.cmdPrv.TabIndex = 11
        Me.cmdPrv.TabStop = False
        Me.cmdPrv.Text = "<"
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdNext.Location = New System.Drawing.Point(757, 0)
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
        Me.cmdExit.Location = New System.Drawing.Point(838, 0)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(54, 34)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.TabStop = False
        Me.cmdExit.Text = "E&xit"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdDelRow.Location = New System.Drawing.Point(615, 0)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(53, 34)
        Me.cmdDelRow.TabIndex = 9
        Me.cmdDelRow.TabStop = False
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdFirst
        '
        Me.cmdFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdFirst.Location = New System.Drawing.Point(683, 0)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(38, 34)
        Me.cmdFirst.TabIndex = 10
        Me.cmdFirst.TabStop = False
        Me.cmdFirst.Text = "|<<"
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdInsRow.Location = New System.Drawing.Point(562, 0)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(54, 34)
        Me.cmdInsRow.TabIndex = 7
        Me.cmdInsRow.TabStop = False
        Me.cmdInsRow.Text = "I&ns Row"
        '
        'CmdLookup
        '
        Me.CmdLookup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CmdLookup.Location = New System.Drawing.Point(446, 0)
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
        Me.cmdSearch.Location = New System.Drawing.Point(323, 0)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(61, 34)
        Me.cmdSearch.TabIndex = 6
        Me.cmdSearch.TabStop = False
        Me.cmdSearch.Text = "Searc&h"
        '
        'cmdspecial
        '
        Me.cmdspecial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdspecial.Location = New System.Drawing.Point(383, 0)
        Me.cmdspecial.Name = "cmdspecial"
        Me.cmdspecial.Size = New System.Drawing.Size(64, 34)
        Me.cmdspecial.TabIndex = 49
        Me.cmdspecial.TabStop = False
        Me.cmdspecial.Text = "S&pecial Search"
        '
        'cmdbrowlist
        '
        Me.cmdbrowlist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdbrowlist.Location = New System.Drawing.Point(499, 0)
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
        Me.StatusBar.Location = New System.Drawing.Point(0, 510)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2})
        Me.StatusBar.ShowPanels = True
        Me.StatusBar.Size = New System.Drawing.Size(892, 26)
        Me.StatusBar.TabIndex = 276
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 437
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel2.Name = "StatusBarPanel2"
        Me.StatusBarPanel2.Width = 437
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
        'frmApproveReject
        '
        Me.frmApproveReject.Controls.Add(Me.chkReject)
        Me.frmApproveReject.Controls.Add(Me.chkApprove)
        Me.frmApproveReject.Controls.Add(Me.Label6)
        Me.frmApproveReject.Controls.Add(Me.txtFm)
        Me.frmApproveReject.Controls.Add(Me.cmdApply)
        Me.frmApproveReject.Controls.Add(Me.txtTo)
        Me.frmApproveReject.ForeColor = System.Drawing.Color.Black
        Me.frmApproveReject.Location = New System.Drawing.Point(486, 39)
        Me.frmApproveReject.Name = "frmApproveReject"
        Me.frmApproveReject.Size = New System.Drawing.Size(363, 48)
        Me.frmApproveReject.TabIndex = 371
        Me.frmApproveReject.TabStop = False
        Me.frmApproveReject.Text = "Approve/Reject"
        '
        'chkReject
        '
        Me.chkReject.AutoSize = True
        Me.chkReject.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkReject.Location = New System.Drawing.Point(89, 20)
        Me.chkReject.Name = "chkReject"
        Me.chkReject.Size = New System.Drawing.Size(57, 17)
        Me.chkReject.TabIndex = 542
        Me.chkReject.Text = "Reject"
        Me.chkReject.UseVisualStyleBackColor = True
        '
        'chkApprove
        '
        Me.chkApprove.AutoSize = True
        Me.chkApprove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkApprove.Location = New System.Drawing.Point(6, 20)
        Me.chkApprove.Name = "chkApprove"
        Me.chkApprove.Size = New System.Drawing.Size(66, 17)
        Me.chkApprove.TabIndex = 543
        Me.chkApprove.Text = "Approve"
        Me.chkApprove.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(205, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(20, 13)
        Me.Label6.TabIndex = 277
        Me.Label6.Text = "To"
        '
        'txtFm
        '
        Me.txtFm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFm.Location = New System.Drawing.Point(152, 18)
        Me.txtFm.MaxLength = 10
        Me.txtFm.Name = "txtFm"
        Me.txtFm.Size = New System.Drawing.Size(50, 20)
        Me.txtFm.TabIndex = 276
        '
        'cmdApply
        '
        Me.cmdApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdApply.Location = New System.Drawing.Point(281, 16)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(62, 23)
        Me.cmdApply.TabIndex = 0
        Me.cmdApply.TabStop = False
        Me.cmdApply.Text = "&Apply"
        '
        'txtTo
        '
        Me.txtTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTo.Location = New System.Drawing.Point(225, 18)
        Me.txtTo.MaxLength = 10
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(50, 20)
        Me.txtTo.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(87, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 383
        Me.Label1.Text = "From:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(262, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 384
        Me.Label4.Text = "To:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(11, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 381
        Me.Label2.Text = "Upload Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(12, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 382
        Me.Label3.Text = "ZS PO No."
        '
        'txtPOFm
        '
        Me.txtPOFm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPOFm.Location = New System.Drawing.Point(133, 40)
        Me.txtPOFm.MaxLength = 10
        Me.txtPOFm.Name = "txtPOFm"
        Me.txtPOFm.Size = New System.Drawing.Size(114, 20)
        Me.txtPOFm.TabIndex = 0
        '
        'txtUplDatTo
        '
        Me.txtUplDatTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtUplDatTo.Location = New System.Drawing.Point(291, 65)
        Me.txtUplDatTo.MaxLength = 10
        Me.txtUplDatTo.Name = "txtUplDatTo"
        Me.txtUplDatTo.Size = New System.Drawing.Size(114, 20)
        Me.txtUplDatTo.TabIndex = 3
        '
        'lblIssDat
        '
        Me.lblIssDat.AutoSize = True
        Me.lblIssDat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblIssDat.Location = New System.Drawing.Point(87, 65)
        Me.lblIssDat.Name = "lblIssDat"
        Me.lblIssDat.Size = New System.Drawing.Size(33, 13)
        Me.lblIssDat.TabIndex = 378
        Me.lblIssDat.Text = "From:"
        '
        'txtUplDatFm
        '
        Me.txtUplDatFm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtUplDatFm.Location = New System.Drawing.Point(133, 65)
        Me.txtUplDatFm.MaxLength = 10
        Me.txtUplDatFm.Name = "txtUplDatFm"
        Me.txtUplDatFm.Size = New System.Drawing.Size(114, 20)
        Me.txtUplDatFm.TabIndex = 2
        '
        'lblRvsDat
        '
        Me.lblRvsDat.AutoSize = True
        Me.lblRvsDat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblRvsDat.Location = New System.Drawing.Point(262, 65)
        Me.lblRvsDat.Name = "lblRvsDat"
        Me.lblRvsDat.Size = New System.Drawing.Size(23, 13)
        Me.lblRvsDat.TabIndex = 379
        Me.lblRvsDat.Text = "To:"
        '
        'txtPOTo
        '
        Me.txtPOTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPOTo.Location = New System.Drawing.Point(291, 40)
        Me.txtPOTo.MaxLength = 10
        Me.txtPOTo.Name = "txtPOTo"
        Me.txtPOTo.Size = New System.Drawing.Size(114, 20)
        Me.txtPOTo.TabIndex = 1
        '
        'frmException
        '
        Me.frmException.Controls.Add(Me.optHdr)
        Me.frmException.Controls.Add(Me.optDtl)
        Me.frmException.ForeColor = System.Drawing.SystemColors.WindowText
        Me.frmException.Location = New System.Drawing.Point(414, 40)
        Me.frmException.Name = "frmException"
        Me.frmException.Size = New System.Drawing.Size(191, 36)
        Me.frmException.TabIndex = 385
        Me.frmException.TabStop = False
        Me.frmException.Text = "Exception Select"
        '
        'optHdr
        '
        Me.optHdr.AutoSize = True
        Me.optHdr.Location = New System.Drawing.Point(7, 14)
        Me.optHdr.Name = "optHdr"
        Me.optHdr.Size = New System.Drawing.Size(59, 19)
        Me.optHdr.TabIndex = 4
        Me.optHdr.Text = "Header"
        Me.optHdr.UseVisualStyleBackColor = True
        '
        'optDtl
        '
        Me.optDtl.AutoSize = True
        Me.optDtl.Checked = True
        Me.optDtl.Location = New System.Drawing.Point(107, 14)
        Me.optDtl.Name = "optDtl"
        Me.optDtl.Size = New System.Drawing.Size(54, 19)
        Me.optDtl.TabIndex = 5
        Me.optDtl.TabStop = True
        Me.optDtl.Text = "Detail"
        Me.optDtl.UseVisualStyleBackColor = True
        '
        'frmStatus
        '
        Me.frmStatus.Controls.Add(Me.optALL)
        Me.frmStatus.Controls.Add(Me.optWait)
        Me.frmStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.frmStatus.Location = New System.Drawing.Point(626, 39)
        Me.frmStatus.Name = "frmStatus"
        Me.frmStatus.Size = New System.Drawing.Size(243, 36)
        Me.frmStatus.TabIndex = 386
        Me.frmStatus.TabStop = False
        Me.frmStatus.Text = "Status"
        '
        'optALL
        '
        Me.optALL.AutoSize = True
        Me.optALL.Location = New System.Drawing.Point(7, 14)
        Me.optALL.Name = "optALL"
        Me.optALL.Size = New System.Drawing.Size(40, 19)
        Me.optALL.TabIndex = 6
        Me.optALL.Text = "All"
        Me.optALL.UseVisualStyleBackColor = True
        '
        'optWait
        '
        Me.optWait.AutoSize = True
        Me.optWait.Checked = True
        Me.optWait.Location = New System.Drawing.Point(107, 14)
        Me.optWait.Name = "optWait"
        Me.optWait.Size = New System.Drawing.Size(112, 19)
        Me.optWait.TabIndex = 7
        Me.optWait.TabStop = True
        Me.optWait.Text = "Wait for Approve"
        Me.optWait.UseVisualStyleBackColor = True
        '
        'txtMsg
        '
        Me.txtMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtMsg.Location = New System.Drawing.Point(4, 444)
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.Size = New System.Drawing.Size(871, 58)
        Me.txtMsg.TabIndex = 369
        Me.txtMsg.Text = ""
        '
        'SSTab1
        '
        Me.SSTab1.Controls.Add(Me.tpMPO00003_1)
        Me.SSTab1.Controls.Add(Me.tpMPO00003_2)
        Me.SSTab1.Controls.Add(Me.tpMPO00003_3)
        Me.SSTab1.Controls.Add(Me.tpMPO00003_4)
        Me.SSTab1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.SSTab1.Location = New System.Drawing.Point(0, 100)
        Me.SSTab1.Name = "SSTab1"
        Me.SSTab1.SelectedIndex = 0
        Me.SSTab1.Size = New System.Drawing.Size(993, 344)
        Me.SSTab1.TabIndex = 44
        '
        'tpMPO00003_1
        '
        Me.tpMPO00003_1.Controls.Add(Me.grdExcept)
        Me.tpMPO00003_1.Location = New System.Drawing.Point(4, 24)
        Me.tpMPO00003_1.Name = "tpMPO00003_1"
        Me.tpMPO00003_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMPO00003_1.Size = New System.Drawing.Size(985, 316)
        Me.tpMPO00003_1.TabIndex = 0
        Me.tpMPO00003_1.Text = "(1) Exception (Hdr)"
        Me.tpMPO00003_1.UseVisualStyleBackColor = True
        '
        'grdExcept
        '
        Me.grdExcept.AllowUserToAddRows = False
        Me.grdExcept.AllowUserToDeleteRows = False
        Me.grdExcept.ColumnHeadersHeight = 20
        Me.grdExcept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdExcept.Location = New System.Drawing.Point(6, 6)
        Me.grdExcept.Name = "grdExcept"
        Me.grdExcept.RowHeadersWidth = 20
        Me.grdExcept.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdExcept.RowTemplate.Height = 16
        Me.grdExcept.Size = New System.Drawing.Size(866, 308)
        Me.grdExcept.TabIndex = 368
        '
        'tpMPO00003_2
        '
        Me.tpMPO00003_2.Controls.Add(Me.cmdLastD)
        Me.tpMPO00003_2.Controls.Add(Me.cmdPrevD)
        Me.tpMPO00003_2.Controls.Add(Me.cmdNextD)
        Me.tpMPO00003_2.Controls.Add(Me.cmdFirstD)
        Me.tpMPO00003_2.Controls.Add(Me.GroupBox1)
        Me.tpMPO00003_2.Controls.Add(Me.GroupBox3)
        Me.tpMPO00003_2.Controls.Add(Me.txtmodvol)
        Me.tpMPO00003_2.Controls.Add(Me.txtCusVen)
        Me.tpMPO00003_2.Controls.Add(Me.txtVenNo)
        Me.tpMPO00003_2.Controls.Add(Me.cboPCPrc)
        Me.tpMPO00003_2.Controls.Add(Me.optSearch1)
        Me.tpMPO00003_2.Controls.Add(Me.optSearch0)
        Me.tpMPO00003_2.Controls.Add(Me.Label30)
        Me.tpMPO00003_2.Controls.Add(Me.txtPurOrd)
        Me.tpMPO00003_2.Controls.Add(Me.txtVol)
        Me.tpMPO00003_2.Controls.Add(Me.txtColCde)
        Me.tpMPO00003_2.Controls.Add(Me.Label39)
        Me.tpMPO00003_2.Controls.Add(Me.txtMtrCtn)
        Me.tpMPO00003_2.Controls.Add(Me.Label40)
        Me.tpMPO00003_2.Controls.Add(Me.Label56)
        Me.tpMPO00003_2.Controls.Add(Me.GroupBox5)
        Me.tpMPO00003_2.Controls.Add(Me.optCtrSiz3)
        Me.tpMPO00003_2.Controls.Add(Me.optCtrSiz4)
        Me.tpMPO00003_2.Controls.Add(Me.optCtrSiz0)
        Me.tpMPO00003_2.Controls.Add(Me.optCtrSiz1)
        Me.tpMPO00003_2.Controls.Add(Me.optCtrSiz2)
        Me.tpMPO00003_2.Controls.Add(Me.txtCustUM)
        Me.tpMPO00003_2.Controls.Add(Me.Label27)
        Me.tpMPO00003_2.Location = New System.Drawing.Point(4, 22)
        Me.tpMPO00003_2.Name = "tpMPO00003_2"
        Me.tpMPO00003_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMPO00003_2.Size = New System.Drawing.Size(985, 318)
        Me.tpMPO00003_2.TabIndex = 1
        Me.tpMPO00003_2.Text = "(2) Exception (Dtl)"
        Me.tpMPO00003_2.UseVisualStyleBackColor = True
        '
        'cmdLastD
        '
        Me.cmdLastD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdLastD.Location = New System.Drawing.Point(814, 20)
        Me.cmdLastD.Name = "cmdLastD"
        Me.cmdLastD.Size = New System.Drawing.Size(54, 26)
        Me.cmdLastD.TabIndex = 375
        Me.cmdLastD.TabStop = False
        Me.cmdLastD.Text = ">>|"
        '
        'cmdPrevD
        '
        Me.cmdPrevD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdPrevD.Location = New System.Drawing.Point(702, 20)
        Me.cmdPrevD.Name = "cmdPrevD"
        Me.cmdPrevD.Size = New System.Drawing.Size(54, 26)
        Me.cmdPrevD.TabIndex = 373
        Me.cmdPrevD.TabStop = False
        Me.cmdPrevD.Text = "<"
        '
        'cmdNextD
        '
        Me.cmdNextD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdNextD.Location = New System.Drawing.Point(758, 20)
        Me.cmdNextD.Name = "cmdNextD"
        Me.cmdNextD.Size = New System.Drawing.Size(54, 26)
        Me.cmdNextD.TabIndex = 374
        Me.cmdNextD.TabStop = False
        Me.cmdNextD.Text = ">"
        '
        'cmdFirstD
        '
        Me.cmdFirstD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdFirstD.Location = New System.Drawing.Point(646, 20)
        Me.cmdFirstD.Name = "cmdFirstD"
        Me.cmdFirstD.Size = New System.Drawing.Size(54, 26)
        Me.cmdFirstD.TabIndex = 372
        Me.cmdFirstD.TabStop = False
        Me.cmdFirstD.Text = "|<<"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtPONo)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(617, 49)
        Me.GroupBox1.TabIndex = 371
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(13, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 279
        Me.Label5.Text = "PO # : "
        '
        'txtPONo
        '
        Me.txtPONo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPONo.Location = New System.Drawing.Point(66, 16)
        Me.txtPONo.MaxLength = 10
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.Size = New System.Drawing.Size(129, 20)
        Me.txtPONo.TabIndex = 278
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.grdExcept_ref)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 62)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(871, 321)
        Me.GroupBox3.TabIndex = 363
        Me.GroupBox3.TabStop = False
        '
        'grdExcept_ref
        '
        Me.grdExcept_ref.AllowUserToAddRows = False
        Me.grdExcept_ref.AllowUserToDeleteRows = False
        Me.grdExcept_ref.ColumnHeadersHeight = 20
        Me.grdExcept_ref.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdExcept_ref.Location = New System.Drawing.Point(7, 19)
        Me.grdExcept_ref.Name = "grdExcept_ref"
        Me.grdExcept_ref.RowHeadersWidth = 20
        Me.grdExcept_ref.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdExcept_ref.RowTemplate.Height = 16
        Me.grdExcept_ref.Size = New System.Drawing.Size(846, 231)
        Me.grdExcept_ref.TabIndex = 369
        '
        'txtmodvol
        '
        Me.txtmodvol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtmodvol.Location = New System.Drawing.Point(143, 620)
        Me.txtmodvol.MaxLength = 10
        Me.txtmodvol.Name = "txtmodvol"
        Me.txtmodvol.Size = New System.Drawing.Size(61, 20)
        Me.txtmodvol.TabIndex = 362
        Me.txtmodvol.Visible = False
        '
        'txtCusVen
        '
        Me.txtCusVen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCusVen.Location = New System.Drawing.Point(473, 613)
        Me.txtCusVen.MaxLength = 10
        Me.txtCusVen.Name = "txtCusVen"
        Me.txtCusVen.Size = New System.Drawing.Size(34, 20)
        Me.txtCusVen.TabIndex = 350
        Me.txtCusVen.Visible = False
        '
        'txtVenNo
        '
        Me.txtVenNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtVenNo.Location = New System.Drawing.Point(439, 613)
        Me.txtVenNo.MaxLength = 10
        Me.txtVenNo.Name = "txtVenNo"
        Me.txtVenNo.Size = New System.Drawing.Size(34, 20)
        Me.txtVenNo.TabIndex = 349
        Me.txtVenNo.Visible = False
        '
        'cboPCPrc
        '
        Me.cboPCPrc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboPCPrc.FormattingEnabled = True
        Me.cboPCPrc.Location = New System.Drawing.Point(638, 609)
        Me.cboPCPrc.Name = "cboPCPrc"
        Me.cboPCPrc.Size = New System.Drawing.Size(75, 21)
        Me.cboPCPrc.TabIndex = 348
        Me.cboPCPrc.Visible = False
        '
        'optSearch1
        '
        Me.optSearch1.AutoSize = True
        Me.optSearch1.Location = New System.Drawing.Point(832, 669)
        Me.optSearch1.Name = "optSearch1"
        Me.optSearch1.Size = New System.Drawing.Size(51, 19)
        Me.optSearch1.TabIndex = 328
        Me.optSearch1.Text = "S/C #"
        Me.optSearch1.UseVisualStyleBackColor = True
        Me.optSearch1.Visible = False
        '
        'optSearch0
        '
        Me.optSearch0.AutoSize = True
        Me.optSearch0.Location = New System.Drawing.Point(694, 671)
        Me.optSearch0.Name = "optSearch0"
        Me.optSearch0.Size = New System.Drawing.Size(63, 19)
        Me.optSearch0.TabIndex = 327
        Me.optSearch0.Text = "Job No."
        Me.optSearch0.UseVisualStyleBackColor = True
        Me.optSearch0.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(588, 672)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(57, 15)
        Me.Label30.TabIndex = 326
        Me.Label30.Text = "Search by:"
        Me.Label30.Visible = False
        '
        'txtPurOrd
        '
        Me.txtPurOrd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPurOrd.Location = New System.Drawing.Point(374, 613)
        Me.txtPurOrd.MaxLength = 10
        Me.txtPurOrd.Name = "txtPurOrd"
        Me.txtPurOrd.Size = New System.Drawing.Size(26, 20)
        Me.txtPurOrd.TabIndex = 347
        Me.txtPurOrd.Visible = False
        '
        'txtVol
        '
        Me.txtVol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtVol.Location = New System.Drawing.Point(64, 623)
        Me.txtVol.MaxLength = 10
        Me.txtVol.Name = "txtVol"
        Me.txtVol.Size = New System.Drawing.Size(61, 20)
        Me.txtVol.TabIndex = 316
        Me.txtVol.Visible = False
        '
        'txtColCde
        '
        Me.txtColCde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtColCde.Location = New System.Drawing.Point(336, 613)
        Me.txtColCde.MaxLength = 10
        Me.txtColCde.Name = "txtColCde"
        Me.txtColCde.Size = New System.Drawing.Size(41, 20)
        Me.txtColCde.TabIndex = 346
        Me.txtColCde.Visible = False
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(16, 601)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(42, 15)
        Me.Label39.TabIndex = 315
        Me.Label39.Text = "Master"
        Me.Label39.Visible = False
        '
        'txtMtrCtn
        '
        Me.txtMtrCtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtMtrCtn.Location = New System.Drawing.Point(64, 601)
        Me.txtMtrCtn.MaxLength = 10
        Me.txtMtrCtn.Name = "txtMtrCtn"
        Me.txtMtrCtn.Size = New System.Drawing.Size(61, 20)
        Me.txtMtrCtn.TabIndex = 314
        Me.txtMtrCtn.Visible = False
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(18, 622)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(35, 15)
        Me.Label40.TabIndex = 317
        Me.Label40.Text = "CBM"
        Me.Label40.Visible = False
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(531, 615)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(80, 15)
        Me.Label56.TabIndex = 339
        Me.Label56.Text = "Unit Price / PC"
        Me.Label56.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtCmpRmk)
        Me.GroupBox5.Controls.Add(Me.cboCus2No_dtl)
        Me.GroupBox5.Controls.Add(Me.Label52)
        Me.GroupBox5.Controls.Add(Me.txtTtlNetD)
        Me.GroupBox5.Controls.Add(Me.Label88)
        Me.GroupBox5.Controls.Add(Me.txtNetWgt)
        Me.GroupBox5.Controls.Add(Me.Label49)
        Me.GroupBox5.Controls.Add(Me.Label50)
        Me.GroupBox5.Controls.Add(Me.txtTtlGrsD)
        Me.GroupBox5.Controls.Add(Me.txtGrsWgt)
        Me.GroupBox5.Controls.Add(Me.txtItmTyp)
        Me.GroupBox5.Controls.Add(Me.Label48)
        Me.GroupBox5.Controls.Add(Me.Label47)
        Me.GroupBox5.Controls.Add(Me.Label45)
        Me.GroupBox5.Controls.Add(Me.txtTtlVolD)
        Me.GroupBox5.Controls.Add(Me.txtOrdSeq)
        Me.GroupBox5.Controls.Add(Me.Label46)
        Me.GroupBox5.Controls.Add(Me.txtActVol)
        Me.GroupBox5.Controls.Add(Me.txtMtrhcm)
        Me.GroupBox5.Controls.Add(Me.txtMtrwcm)
        Me.GroupBox5.Controls.Add(Me.txtMtrdcm)
        Me.GroupBox5.Controls.Add(Me.Label44)
        Me.GroupBox5.Controls.Add(Me.txtOrgQty)
        Me.GroupBox5.Controls.Add(Me.Label43)
        Me.GroupBox5.Controls.Add(Me.Label42)
        Me.GroupBox5.Controls.Add(Me.Label41)
        Me.GroupBox5.Controls.Add(Me.Label37)
        Me.GroupBox5.Controls.Add(Me.txtInrCtn)
        Me.GroupBox5.Controls.Add(Me.Label38)
        Me.GroupBox5.Controls.Add(Me.txtUntCde)
        Me.GroupBox5.Controls.Add(Me.cboPckRmk)
        Me.GroupBox5.Controls.Add(Me.txtColDsc)
        Me.GroupBox5.Controls.Add(Me.txtOutQty)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Controls.Add(Me.txtPrcTrm)
        Me.GroupBox5.Controls.Add(Me.txtPayTrm)
        Me.GroupBox5.Location = New System.Drawing.Point(125, 604)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(435, 151)
        Me.GroupBox5.TabIndex = 294
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Visible = False
        '
        'txtCmpRmk
        '
        Me.txtCmpRmk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCmpRmk.Location = New System.Drawing.Point(298, 135)
        Me.txtCmpRmk.MaxLength = 10
        Me.txtCmpRmk.Name = "txtCmpRmk"
        Me.txtCmpRmk.Size = New System.Drawing.Size(71, 20)
        Me.txtCmpRmk.TabIndex = 340
        '
        'cboCus2No_dtl
        '
        Me.cboCus2No_dtl.FormattingEnabled = True
        Me.cboCus2No_dtl.Location = New System.Drawing.Point(130, -6)
        Me.cboCus2No_dtl.Name = "cboCus2No_dtl"
        Me.cboCus2No_dtl.Size = New System.Drawing.Size(23, 23)
        Me.cboCus2No_dtl.TabIndex = 359
        Me.cboCus2No_dtl.Visible = False
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(202, 135)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(72, 15)
        Me.Label52.TabIndex = 338
        Me.Label52.Text = "W.M. Comp."
        '
        'txtTtlNetD
        '
        Me.txtTtlNetD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTtlNetD.Location = New System.Drawing.Point(298, 111)
        Me.txtTtlNetD.MaxLength = 10
        Me.txtTtlNetD.Name = "txtTtlNetD"
        Me.txtTtlNetD.Size = New System.Drawing.Size(71, 20)
        Me.txtTtlNetD.TabIndex = 336
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Location = New System.Drawing.Point(103, 2)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(47, 15)
        Me.Label88.TabIndex = 351
        Me.Label88.Text = "Consol#"
        Me.Label88.Visible = False
        '
        'txtNetWgt
        '
        Me.txtNetWgt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtNetWgt.Location = New System.Drawing.Point(123, 111)
        Me.txtNetWgt.MaxLength = 10
        Me.txtNetWgt.Name = "txtNetWgt"
        Me.txtNetWgt.Size = New System.Drawing.Size(71, 20)
        Me.txtNetWgt.TabIndex = 335
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(202, 111)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(78, 15)
        Me.Label49.TabIndex = 334
        Me.Label49.Text = "TTL NW (Kg)"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.BackColor = System.Drawing.Color.Transparent
        Me.Label50.ForeColor = System.Drawing.Color.Green
        Me.Label50.Location = New System.Drawing.Point(6, 111)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(100, 15)
        Me.Label50.TabIndex = 333
        Me.Label50.Text = "Net Wgt/Ctn : (Kg)"
        '
        'txtTtlGrsD
        '
        Me.txtTtlGrsD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTtlGrsD.Location = New System.Drawing.Point(298, 87)
        Me.txtTtlGrsD.MaxLength = 10
        Me.txtTtlGrsD.Name = "txtTtlGrsD"
        Me.txtTtlGrsD.Size = New System.Drawing.Size(71, 20)
        Me.txtTtlGrsD.TabIndex = 332
        '
        'txtGrsWgt
        '
        Me.txtGrsWgt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtGrsWgt.Location = New System.Drawing.Point(123, 87)
        Me.txtGrsWgt.MaxLength = 10
        Me.txtGrsWgt.Name = "txtGrsWgt"
        Me.txtGrsWgt.Size = New System.Drawing.Size(71, 20)
        Me.txtGrsWgt.TabIndex = 331
        '
        'txtItmTyp
        '
        Me.txtItmTyp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmTyp.Location = New System.Drawing.Point(95, -5)
        Me.txtItmTyp.MaxLength = 10
        Me.txtItmTyp.Name = "txtItmTyp"
        Me.txtItmTyp.Size = New System.Drawing.Size(29, 20)
        Me.txtItmTyp.TabIndex = 343
        Me.txtItmTyp.Visible = False
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(202, 87)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(78, 15)
        Me.Label48.TabIndex = 330
        Me.Label48.Text = "TTL GW (Kg)"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.ForeColor = System.Drawing.Color.Green
        Me.Label47.Location = New System.Drawing.Point(6, 87)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(111, 15)
        Me.Label47.TabIndex = 329
        Me.Label47.Text = "Gross Wgt/Ctn : (Kg)"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(202, 63)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(73, 15)
        Me.Label45.TabIndex = 328
        Me.Label45.Text = "TTL CBM    "
        '
        'txtTtlVolD
        '
        Me.txtTtlVolD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTtlVolD.Location = New System.Drawing.Point(298, 63)
        Me.txtTtlVolD.MaxLength = 10
        Me.txtTtlVolD.Name = "txtTtlVolD"
        Me.txtTtlVolD.Size = New System.Drawing.Size(71, 20)
        Me.txtTtlVolD.TabIndex = 327
        '
        'txtOrdSeq
        '
        Me.txtOrdSeq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtOrdSeq.Location = New System.Drawing.Point(70, -5)
        Me.txtOrdSeq.MaxLength = 10
        Me.txtOrdSeq.Name = "txtOrdSeq"
        Me.txtOrdSeq.Size = New System.Drawing.Size(19, 20)
        Me.txtOrdSeq.TabIndex = 342
        Me.txtOrdSeq.Visible = False
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(6, 63)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(91, 15)
        Me.Label46.TabIndex = 326
        Me.Label46.Text = "Actual CBM/Ctn"
        '
        'txtActVol
        '
        Me.txtActVol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtActVol.Location = New System.Drawing.Point(123, 63)
        Me.txtActVol.MaxLength = 10
        Me.txtActVol.Name = "txtActVol"
        Me.txtActVol.Size = New System.Drawing.Size(71, 20)
        Me.txtActVol.TabIndex = 325
        '
        'txtMtrhcm
        '
        Me.txtMtrhcm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtMtrhcm.Location = New System.Drawing.Point(332, 37)
        Me.txtMtrhcm.MaxLength = 10
        Me.txtMtrhcm.Name = "txtMtrhcm"
        Me.txtMtrhcm.Size = New System.Drawing.Size(61, 20)
        Me.txtMtrhcm.TabIndex = 324
        '
        'txtMtrwcm
        '
        Me.txtMtrwcm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtMtrwcm.Location = New System.Drawing.Point(218, 36)
        Me.txtMtrwcm.MaxLength = 10
        Me.txtMtrwcm.Name = "txtMtrwcm"
        Me.txtMtrwcm.Size = New System.Drawing.Size(61, 20)
        Me.txtMtrwcm.TabIndex = 323
        '
        'txtMtrdcm
        '
        Me.txtMtrdcm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtMtrdcm.Location = New System.Drawing.Point(123, 36)
        Me.txtMtrdcm.MaxLength = 10
        Me.txtMtrdcm.Name = "txtMtrdcm"
        Me.txtMtrdcm.Size = New System.Drawing.Size(61, 20)
        Me.txtMtrdcm.TabIndex = 322
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.ForeColor = System.Drawing.Color.Green
        Me.Label44.Location = New System.Drawing.Point(311, 41)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(16, 15)
        Me.Label44.TabIndex = 321
        Me.Label44.Text = "H"
        '
        'txtOrgQty
        '
        Me.txtOrgQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtOrgQty.Location = New System.Drawing.Point(65, -22)
        Me.txtOrgQty.MaxLength = 10
        Me.txtOrgQty.Name = "txtOrgQty"
        Me.txtOrgQty.Size = New System.Drawing.Size(10, 20)
        Me.txtOrgQty.TabIndex = 348
        Me.txtOrgQty.Visible = False
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.ForeColor = System.Drawing.Color.Green
        Me.Label43.Location = New System.Drawing.Point(194, 41)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(18, 15)
        Me.Label43.TabIndex = 320
        Me.Label43.Text = "W"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.ForeColor = System.Drawing.Color.Green
        Me.Label42.Location = New System.Drawing.Point(103, 41)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(14, 15)
        Me.Label42.TabIndex = 319
        Me.Label42.Text = "L"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.ForeColor = System.Drawing.Color.Green
        Me.Label41.Location = New System.Drawing.Point(6, 34)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(84, 15)
        Me.Label41.TabIndex = 318
        Me.Label41.Text = "Dimension (cm)"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(85, 11)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(32, 15)
        Me.Label37.TabIndex = 313
        Me.Label37.Text = "Inner"
        '
        'txtInrCtn
        '
        Me.txtInrCtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtInrCtn.Location = New System.Drawing.Point(123, 11)
        Me.txtInrCtn.MaxLength = 10
        Me.txtInrCtn.Name = "txtInrCtn"
        Me.txtInrCtn.Size = New System.Drawing.Size(61, 20)
        Me.txtInrCtn.TabIndex = 312
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(6, 11)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(31, 15)
        Me.Label38.TabIndex = 311
        Me.Label38.Text = "U/M"
        '
        'txtUntCde
        '
        Me.txtUntCde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtUntCde.Location = New System.Drawing.Point(43, 11)
        Me.txtUntCde.MaxLength = 10
        Me.txtUntCde.Name = "txtUntCde"
        Me.txtUntCde.Size = New System.Drawing.Size(36, 20)
        Me.txtUntCde.TabIndex = 310
        '
        'cboPckRmk
        '
        Me.cboPckRmk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboPckRmk.FormattingEnabled = True
        Me.cboPckRmk.Location = New System.Drawing.Point(-25, 0)
        Me.cboPckRmk.Name = "cboPckRmk"
        Me.cboPckRmk.Size = New System.Drawing.Size(268, 21)
        Me.cboPckRmk.TabIndex = 301
        Me.cboPckRmk.Visible = False
        '
        'txtColDsc
        '
        Me.txtColDsc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtColDsc.Location = New System.Drawing.Point(-13, -22)
        Me.txtColDsc.MaxLength = 10
        Me.txtColDsc.Name = "txtColDsc"
        Me.txtColDsc.Size = New System.Drawing.Size(17, 20)
        Me.txtColDsc.TabIndex = 312
        Me.txtColDsc.Visible = False
        '
        'txtOutQty
        '
        Me.txtOutQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtOutQty.Location = New System.Drawing.Point(49, -22)
        Me.txtOutQty.MaxLength = 10
        Me.txtOutQty.Name = "txtOutQty"
        Me.txtOutQty.Size = New System.Drawing.Size(10, 20)
        Me.txtOutQty.TabIndex = 347
        Me.txtOutQty.Visible = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(-70, -20)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(51, 15)
        Me.Label29.TabIndex = 324
        Me.Label29.Text = "Col Desc"
        Me.Label29.Visible = False
        '
        'txtPrcTrm
        '
        Me.txtPrcTrm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPrcTrm.Location = New System.Drawing.Point(15, -23)
        Me.txtPrcTrm.MaxLength = 10
        Me.txtPrcTrm.Name = "txtPrcTrm"
        Me.txtPrcTrm.Size = New System.Drawing.Size(10, 20)
        Me.txtPrcTrm.TabIndex = 345
        Me.txtPrcTrm.Visible = False
        '
        'txtPayTrm
        '
        Me.txtPayTrm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPayTrm.Location = New System.Drawing.Point(33, -22)
        Me.txtPayTrm.MaxLength = 10
        Me.txtPayTrm.Name = "txtPayTrm"
        Me.txtPayTrm.Size = New System.Drawing.Size(10, 20)
        Me.txtPayTrm.TabIndex = 346
        Me.txtPayTrm.Visible = False
        '
        'optCtrSiz3
        '
        Me.optCtrSiz3.AutoSize = True
        Me.optCtrSiz3.Location = New System.Drawing.Point(288, 674)
        Me.optCtrSiz3.Name = "optCtrSiz3"
        Me.optCtrSiz3.Size = New System.Drawing.Size(39, 19)
        Me.optCtrSiz3.TabIndex = 294
        Me.optCtrSiz3.Text = "45'"
        Me.optCtrSiz3.UseVisualStyleBackColor = True
        '
        'optCtrSiz4
        '
        Me.optCtrSiz4.AutoSize = True
        Me.optCtrSiz4.Checked = True
        Me.optCtrSiz4.Location = New System.Drawing.Point(92, 658)
        Me.optCtrSiz4.Name = "optCtrSiz4"
        Me.optCtrSiz4.Size = New System.Drawing.Size(46, 19)
        Me.optCtrSiz4.TabIndex = 289
        Me.optCtrSiz4.TabStop = True
        Me.optCtrSiz4.Text = "CFS"
        Me.optCtrSiz4.UseVisualStyleBackColor = True
        '
        'optCtrSiz0
        '
        Me.optCtrSiz0.AutoSize = True
        Me.optCtrSiz0.Location = New System.Drawing.Point(93, 674)
        Me.optCtrSiz0.Name = "optCtrSiz0"
        Me.optCtrSiz0.Size = New System.Drawing.Size(39, 19)
        Me.optCtrSiz0.TabIndex = 291
        Me.optCtrSiz0.Text = "20'"
        Me.optCtrSiz0.UseVisualStyleBackColor = True
        '
        'optCtrSiz1
        '
        Me.optCtrSiz1.AutoSize = True
        Me.optCtrSiz1.Location = New System.Drawing.Point(144, 674)
        Me.optCtrSiz1.Name = "optCtrSiz1"
        Me.optCtrSiz1.Size = New System.Drawing.Size(67, 19)
        Me.optCtrSiz1.TabIndex = 292
        Me.optCtrSiz1.Text = "40' (8.5')"
        Me.optCtrSiz1.UseVisualStyleBackColor = True
        '
        'optCtrSiz2
        '
        Me.optCtrSiz2.AutoSize = True
        Me.optCtrSiz2.Location = New System.Drawing.Point(217, 674)
        Me.optCtrSiz2.Name = "optCtrSiz2"
        Me.optCtrSiz2.Size = New System.Drawing.Size(65, 19)
        Me.optCtrSiz2.TabIndex = 293
        Me.optCtrSiz2.Text = "40'(HQ)"
        Me.optCtrSiz2.UseVisualStyleBackColor = True
        '
        'txtCustUM
        '
        Me.txtCustUM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCustUM.Location = New System.Drawing.Point(934, 530)
        Me.txtCustUM.MaxLength = 6
        Me.txtCustUM.Name = "txtCustUM"
        Me.txtCustUM.Size = New System.Drawing.Size(51, 20)
        Me.txtCustUM.TabIndex = 311
        Me.txtCustUM.Visible = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(880, 530)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(51, 15)
        Me.Label27.TabIndex = 323
        Me.Label27.Text = "Cust Um"
        Me.Label27.Visible = False
        '
        'tpMPO00003_3
        '
        Me.tpMPO00003_3.Controls.Add(Me.grdMPOHdr)
        Me.tpMPO00003_3.Location = New System.Drawing.Point(4, 22)
        Me.tpMPO00003_3.Name = "tpMPO00003_3"
        Me.tpMPO00003_3.Size = New System.Drawing.Size(985, 318)
        Me.tpMPO00003_3.TabIndex = 2
        Me.tpMPO00003_3.Text = "(3) MPO Header"
        Me.tpMPO00003_3.UseVisualStyleBackColor = True
        '
        'grdMPOHdr
        '
        Me.grdMPOHdr.AllowUserToAddRows = False
        Me.grdMPOHdr.AllowUserToDeleteRows = False
        Me.grdMPOHdr.ColumnHeadersHeight = 20
        Me.grdMPOHdr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdMPOHdr.Location = New System.Drawing.Point(10, 14)
        Me.grdMPOHdr.Name = "grdMPOHdr"
        Me.grdMPOHdr.RowHeadersWidth = 20
        Me.grdMPOHdr.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdMPOHdr.RowTemplate.Height = 16
        Me.grdMPOHdr.Size = New System.Drawing.Size(866, 301)
        Me.grdMPOHdr.TabIndex = 367
        '
        'tpMPO00003_4
        '
        Me.tpMPO00003_4.Controls.Add(Me.grdMPODtl)
        Me.tpMPO00003_4.Location = New System.Drawing.Point(4, 22)
        Me.tpMPO00003_4.Name = "tpMPO00003_4"
        Me.tpMPO00003_4.Size = New System.Drawing.Size(985, 318)
        Me.tpMPO00003_4.TabIndex = 3
        Me.tpMPO00003_4.Text = "(4) MPO Detail"
        Me.tpMPO00003_4.UseVisualStyleBackColor = True
        '
        'grdMPODtl
        '
        Me.grdMPODtl.AllowUserToAddRows = False
        Me.grdMPODtl.AllowUserToDeleteRows = False
        Me.grdMPODtl.ColumnHeadersHeight = 20
        Me.grdMPODtl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdMPODtl.Location = New System.Drawing.Point(4, 6)
        Me.grdMPODtl.Name = "grdMPODtl"
        Me.grdMPODtl.RowHeadersWidth = 20
        Me.grdMPODtl.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdMPODtl.RowTemplate.Height = 16
        Me.grdMPODtl.Size = New System.Drawing.Size(866, 307)
        Me.grdMPODtl.TabIndex = 368
        '
        'MPO00003
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(892, 536)
        Me.Controls.Add(Me.txtMsg)
        Me.Controls.Add(Me.frmStatus)
        Me.Controls.Add(Me.frmException)
        Me.Controls.Add(Me.frmApproveReject)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPOFm)
        Me.Controls.Add(Me.txtUplDatTo)
        Me.Controls.Add(Me.lblIssDat)
        Me.Controls.Add(Me.txtUplDatFm)
        Me.Controls.Add(Me.lblRvsDat)
        Me.Controls.Add(Me.txtPOTo)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.SSTab1)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MPO00003"
        Me.Text = "MPO00003 - Manufacturing Purchase Order Approve/Reject"
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmApproveReject.ResumeLayout(False)
        Me.frmApproveReject.PerformLayout()
        Me.frmException.ResumeLayout(False)
        Me.frmException.PerformLayout()
        Me.frmStatus.ResumeLayout(False)
        Me.frmStatus.PerformLayout()
        Me.SSTab1.ResumeLayout(False)
        Me.tpMPO00003_1.ResumeLayout(False)
        CType(Me.grdExcept, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpMPO00003_2.ResumeLayout(False)
        Me.tpMPO00003_2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grdExcept_ref, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.tpMPO00003_3.ResumeLayout(False)
        CType(Me.grdMPOHdr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpMPO00003_4.ResumeLayout(False)
        CType(Me.grdMPODtl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region




    Private Sub DisplayHeader()
        Dim intCol As Integer

        Me.grdMPOHdr.DataSource = Nothing
        If rs_Except Is Nothing Then Exit Sub
        If rs_Except.Tables("result") Is Nothing Then Exit Sub
        If rs_Except.Tables("result").Rows.Count <= 0 Then Exit Sub

        If rs_MPORDHDR Is Nothing Then Exit Sub
        If rs_MPORDHDR.Tables("result") Is Nothing Then Exit Sub

        If Me.optHdr.Checked = True Then
            rs_MPORDHDR.Tables("result").DefaultView.RowFilter = "Mpd_pono = '" & rs_Except.Tables("result").Rows(readingindex)("Mxh_pono") & "'"
        Else
            rs_MPORDHDR.Tables("result").DefaultView.RowFilter = "Mpd_pono = '" & rs_Except.Tables("result").Rows(readingindex)("Mxd_pono") & "'"
        End If
        Me.grdMPOHdr.DataSource = rs_MPORDHDR.Tables("result").DefaultView

        With grdMPOHdr
            intCol = 0
            .Columns(intCol).HeaderText = "MPO # (HK)"
            .Columns(intCol).Width = 120 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Supplier #"
            .Columns(intCol).Width = 100 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Import Factory"
            .Columns(intCol).Width = 150 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Currency"
            .Columns(intCol).Width = 80 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ship Place"
            .Columns(intCol).Width = 180 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ship Date"
            .Columns(intCol).Width = 100

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Create Date"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Create User"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Update Date"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Update User"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Price Term"
            .Columns(intCol).Width = 120

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Payment Term"
            .Columns(intCol).Width = 120

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Contact Person Stamp"
            .Columns(intCol).Width = 80

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Total Amt"
            .Columns(intCol).Width = 120

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Discount Amt"
            .Columns(intCol).Width = 120

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Net Amount"
            .Columns(intCol).Width = 120

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Shipping Addr"
            .Columns(intCol).Width = 120

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "MPO Status"
            .Columns(intCol).Width = 100

            intCol = intCol + 1
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

        End With

    End Sub

    Private Sub DisplayDetail()
        Dim intCol As Integer

        Me.grdMPODtl.DataSource = Nothing
        If rs_Except Is Nothing Then Exit Sub
        If rs_Except.Tables("result").Rows.Count <= 0 Then Exit Sub

        If rs_MPORDDTL Is Nothing Then Exit Sub
        If Me.optHdr.Checked = True Then
            rs_MPORDDTL.Tables("result").DefaultView.RowFilter = "Mpd_pono = '" & rs_Except.Tables("result").Rows(readingindex)("Mxh_pono") & "'"
        Else
            rs_MPORDDTL.Tables("result").DefaultView.RowFilter = "Mpd_pono = '" & rs_Except.Tables("result").Rows(readingindex)("Mxd_pono") & "'"
        End If
        Me.grdMPODtl.DataSource = rs_MPORDDTL.Tables("result").DefaultView

        With grdMPODtl
            intCol = 0
            .Columns(intCol).HeaderText = "MPO # (HK)"
            .Columns(intCol).Width = 120 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Seq"
            .Columns(intCol).Width = 60 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "PO # (ZS)"
            .Columns(intCol).Width = 120 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "PO Seq (ZS)"
            .Columns(intCol).Width = 100 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "PO Date"
            .Columns(intCol).Width = 100 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ship Date"
            .Columns(intCol).Width = 100 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ori. Ship Date"
            .Columns(intCol).Width = 100 / 1.3


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Request # (ZS)"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ven. Item #"
            .Columns(intCol).Width = 120 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Item #"
            .Columns(intCol).Width = 120 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Item Name"
            .Columns(intCol).Width = 280 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Item Desc"
            .Columns(intCol).Width = 100 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Color Code"
            .Columns(intCol).Width = 120 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "UM"
            .Columns(intCol).Width = 80 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ord. Qty"
            .Columns(intCol).Width = 80 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ship Qty"
            .Columns(intCol).Width = 80 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Unit Price"
            .Columns(intCol).Width = 80 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Min Price"
            .Columns(intCol).Width = 80 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Packing Method"
            .Columns(intCol).Width = 140 / 1.3


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Dept"
            .Columns(intCol).Width = 100 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Production #"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "File Name (Header)"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "File Seq (Header)"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "File Name (Detail)"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "File Seq (Detail)"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Remark (Header)"
            .Columns(intCol).Width = 260 / 1.3
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Remark (Detail)"
            .Columns(intCol).Width = 260 / 1.3

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Create Date"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Create User"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
            intCol = intCol + 1

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Update Date"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Update User"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Time Stamp"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False


        End With

    End Sub
    Private Sub chkApprove_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkApprove.Click
        If Me.chkApprove.Checked = True Then Me.chkReject.Checked = False
    End Sub

    Private Sub chkReject_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReject.CheckedChanged
        If Me.chkReject.Checked = True Then Me.chkApprove.Checked = False
    End Sub



    Private Sub cmdApply_Click()
        Dim intFm As Integer
        Dim intTo As Integer
        Dim i As Integer
        Dim gen As String

        If Me.SSTab1.SelectedIndex <> 0 And Me.SSTab1.SelectedIndex <> 1 Then Exit Sub

        If SSTab1.SelectedIndex = 0 Then
            If rs_Except Is Nothing Then Exit Sub
            If rs_Except.Tables("result") Is Nothing Then Exit Sub
            If rs_Except.Tables("result").Rows.Count <= 0 Then Exit Sub
        Else
            If rs_Except_ref Is Nothing Then Exit Sub
            If rs_Except_ref.Tables("result") Is Nothing Then Exit Sub
            If rs_Except_ref.Tables("result").Rows.Count <= 0 Then Exit Sub
        End If

        intFm = CInt(Me.txtFm.Text)
        intTo = CInt(Me.txtTo.Text)

        If intFm > intTo Then
            MsgBox("From value > To!")
            Exit Sub
        End If

        If SSTab1.SelectedIndex = 0 Then
            If intFm > rs_Except.Tables("result").Rows.Count Then Exit Sub
            If intFm < 0 Then intFm = 0
            If intTo > rs_Except.Tables("result").Rows.Count Then intTo = rs_Except.Tables("result").Rows.Count
        Else
            If intFm > rs_Except_ref.Tables("result").Rows.Count Then Exit Sub
            If intFm < 0 Then intFm = 0
            If intTo > rs_Except_ref.Tables("result").Rows.Count Then intTo = rs_Except_ref.Tables("result").Rows.Count
        End If

        gen = " "

        If Me.chkApprove.Checked = True Then
            gen = "A"
        ElseIf Me.chkReject.Checked = True Then
            gen = "R"
        End If

        If SSTab1.SelectedIndex = 0 Then
            With rs_Except
                For i = intFm - 1 To intTo - 1
                    '
                    If optHdr.Checked = True Then
                        If Trim(.Tables("RESULT").Rows(i)("Mxh_MPOFlg")) = "E" Then .Tables("RESULT").Rows(i)("Gen") = gen
                    Else
                        If Trim(.Tables("RESULT").Rows(i)("Mxd_MPOFlg")) = "E" Then .Tables("RESULT").Rows(i)("Gen") = gen
                    End If
                Next
                'temp
            End With
        Else
            With rs_Except_ref
                For i = intFm To intTo
                    If optDtl.Checked = True Then
                        If Trim(.Tables("RESULT").Rows(i)("Mxh_MPOFlg")) = "E" Then .Tables("RESULT").Rows(i)("Gen") = gen
                    Else
                        If Trim(.Tables("RESULT").Rows(i)("Mpd_MPOFlg")) = "E" Then .Tables("RESULT").Rows(i)("Gen") = gen
                    End If
                Next
                'temp
            End With
        End If

    End Sub

    '*** Folder 1

    '*** Folder 2


    Private Sub cmdClear_Click()
        Dim YNC As Integer
        If Not rs_Except Is Nothing Then
            If rs_Except.Tables("result").Rows.Count > 0 Then
                rs_Except.Tables("result").DefaultView.RowFilter = "gen = 'A' or gen='R'"
                If rs_Except.Tables("result").DefaultView.Count > 0 Then

                    YNC = MsgBox("There is updated record(s)!" & vbCrLf & "Save before clear screen?", vbYesNoCancel + vbDefaultButton3 + vbQuestion, "Updated record(s) not save")
                    If YNC = vbYes Then
                        If Enq_right_local Then
                            Call CmdSaveClick()
                            If save_ok = False Then Exit Sub
                        Else
                            MsgBox("You do not have rights to save!" & vbCrLf & "Program will clear without save!", vbInformation + vbOKOnly)
                        End If
                    ElseIf YNC = vbCancel Then
                        Exit Sub
                    End If
                End If

            End If
        End If

        Call setStatus("Clear")
    End Sub












    Private Sub cmdFindClick()
        Dim strStatus As String

        '    If Trim(Me.txtFilNamFm.Text) = "" And Trim(Me.txtFilNamTo.Text) <> "" Then
        '       Me.txtFilNamFm.Text = Me.txtFilNamTo.Text
        '    ElseIf Trim(Me.txtFilNamFm.Text) <> "" And Trim(Me.txtFilNamTo.Text) = "" Then
        '        Me.txtFilNamTo.Text = Me.txtFilNamFm.Text
        '    ElseIf Trim(Me.txtFilNamFm.Text) > Trim(Me.txtFilNamTo.Text) Then
        '        MsgBox "File Name From > File Name To!"
        '        Me.txtFilNamFm.SetFocus
        '        Exit Sub
        '    End If

        If Trim(Me.txtPOFm.Text) = "" And Trim(Me.txtPOTo.Text) <> "" Then
            Me.txtPOFm.Text = Me.txtPOTo.Text
        ElseIf Trim(Me.txtPOFm.Text) <> "" And Trim(Me.txtPOTo.Text) = "" Then
            Me.txtPOTo.Text = Me.txtPOFm.Text
        ElseIf Trim(Me.txtPOFm.Text) > Trim(Me.txtPOTo.Text) Then
            MsgBox("PO No From > PO No To!")
            Me.txtPOFm.Focus()
            Exit Sub
        End If


        If Me.txtUplDatFm.Text <> "  /  /    " Then
            If IsDate(Me.txtUplDatFm.Text) = False Then
                MsgBox("Invalid Date Value!")
                Me.txtUplDatFm.Focus()
                Exit Sub
            End If
        End If

        If Me.txtUplDatTo.Text <> "  /  /    " Then
            If IsDate(Me.txtUplDatTo.Text) = False Then
                MsgBox("Invalid Date Value!")
                Me.txtUplDatTo.Focus()
                Exit Sub
            End If
        End If

        '    If Me.txtUplDatFm.Text = "  /  /    " And Me.txtUplDatTo.Text <> "  /  /    " Then
        '        Me.txtUplDatFm.Text = Me.txtUplDatTo.Text
        '    ElseIf Me.txtUplDatFm.Text <> "  /  /    " And Me.txtUplDatTo.Text = "  /  /    " Then
        '        Me.txtUplDatTo.Text = Me.txtUplDatFm.Text
        '    ElseIf Me.txtUplDatFm.Text > Me.txtUplDatTo.Text Then
        '        MsgBox "Upload Date From > Date To!"
        '        Me.txtUplDatFm.SetFocus
        '        Exit Sub
        '    End If
        If Me.txtUplDatFm.Text = "  /  /    " And Me.txtUplDatTo.Text <> "  /  /    " Then
            Me.txtUplDatFm.Text = Me.txtUplDatTo.Text
        ElseIf Me.txtUplDatFm.Text <> "  /  /    " And Me.txtUplDatTo.Text = "  /  /    " Then
            Me.txtUplDatTo.Text = Me.txtUplDatFm.Text
        End If

        'Lester Wu 2006-01-06
        If Me.txtUplDatFm.Text <> "  /  /    " And Me.txtUplDatTo.Text <> "  /  /    " Then
            If CDate(Me.txtUplDatFm.Text) > CDate(Me.txtUplDatTo.Text) Then
                MsgBox("Upload Date From > Date To!")
                Me.txtUplDatFm.Focus()
                Exit Sub
            End If
        End If

        Dim rs As New DataSet
        Dim S As String
        Dim i As Integer

        Dim dtFm As String
        Dim dtTo As String



        If Me.txtUplDatFm.Text = "  /  /    " Then
            dtFm = "01/01/1900"
        Else
            dtFm = Trim(Me.txtUplDatFm.Text)
        End If

        If Me.txtUplDatTo.Text = "  /  /    " Then
            dtTo = "01/01/1900"
        Else
            dtTo = Trim(Me.txtUplDatTo.Text)
        End If
        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_MPO00003 '" & "','" & IIf(optHdr.Checked = True, "H", "D") & "','" & _
               IIf(optWait.Checked = True, "W", "A") & "','" & _
               Trim(Me.txtPOFm.Text) & "','" & Trim(Me.txtPOTo.Text) & "','" & _
               dtFm & "','" & dtTo & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_Except, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtShpNoKeyPress sp_select_MMPORDHDR :" & rtnStr)
            Exit Sub
        End If
        If rs_Except.Tables("result").Rows.Count = 0 Then
            Cursor = Cursors.Default
            MsgBox("Record not found!")
            Exit Sub
        End If

        For i2 As Integer = 0 To rs_Except.Tables("RESULT").Columns.Count - 1
            rs_Except.Tables("RESULT").Columns(i2).ReadOnly = False
        Next



        gspStr = "sp_select_MPO00003_ref    '" & "','" & IIf(optHdr.Checked = True, "H", "D") & "','" & _
            IIf(optWait.Checked = True, "W", "A") & "','" & _
            Trim(Me.txtPOFm.Text) & "','" & Trim(Me.txtPOTo.Text) & "','" & _
            dtFm & "','" & dtTo & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_Except_ref, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtShpNoKeyPress sp_select_MMPORDHDR :" & rtnStr)
            Exit Sub
        End If
        For i2 As Integer = 0 To rs_Except_ref.Tables("RESULT").Columns.Count - 1
            rs_Except_ref.Tables("RESULT").Columns(i2).ReadOnly = False
        Next


        gspStr = "sp_select_MPO00003_Hdr '" & "','" & IIf(optHdr.Checked = True, "H", "D") & "','" & _
            Trim(Me.txtPOFm.Text) & "','" & Trim(Me.txtPOTo.Text) & "','" & _
            dtFm & "','" & dtTo & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_MPORDHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtShpNoKeyPress sp_select_MMPORDHDR :" & rtnStr)
            Exit Sub
        End If
        For i2 As Integer = 0 To rs_MPORDHDR.Tables("RESULT").Columns.Count - 1
            rs_MPORDHDR.Tables("RESULT").Columns(i2).ReadOnly = False
        Next


        gspStr = "sp_select_MPO00003_Dtl   '" & "','" & IIf(optHdr.Checked = True, "H", "D") & "','" & _
            Trim(Me.txtPOFm.Text) & "','" & Trim(Me.txtPOTo.Text) & "','" & _
            dtFm & "','" & dtTo & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_MPORDDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtShpNoKeyPress sp_select_MMPORDHDR :" & rtnStr)
            Exit Sub
        End If
        For i2 As Integer = 0 To rs_MPORDDTL.Tables("RESULT").Columns.Count - 1
            rs_MPORDDTL.Tables("RESULT").Columns(i2).ReadOnly = False
        Next



        Cursor = Cursors.Default


        Me.SSTab1.SelectedIndex = 0
        bolFind = True
        If optHdr.Checked = True Then
            Me.SSTab1.Text = "(1) Exception (Hdr)"
            Me.SSTab1.SelectedIndex = 1
            Me.SSTab1.Text = "(2) Exception (Dtl)"
            Call DisplayHeader_Exp(Me.grdExcept)
            'Call DisplayDetail_Exp(Me.grdExcept_ref)
        Else
            Me.SSTab1.Text = "(1) Exception (Dtl)"
            Me.SSTab1.SelectedIndex = 1
            Me.SSTab1.Text = "(2) Exception (Hdr)"
            Call DisplayDetail_Exp(Me.grdExcept)
            'Call DisplayHeader_Exp(Me.grdExcept_ref)
        End If
        Me.SSTab1.SelectedIndex = 0
        bolFind = False
        Call setStatus("Update")
        Me.txtMsg.Text = ""
    End Sub

    Private Sub cmdFirstD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFirstD.Click
        Call moveHeaderRecord("F")
    End Sub
    Private Sub cmdLastD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLastD.Click
        Call moveHeaderRecord("L")
    End Sub
    Private Sub cmdNextD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextD.Click
        Call moveHeaderRecord("N")
    End Sub

    Private Sub cmdPrevD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevD.Click
        Call moveHeaderRecord("P")
    End Sub


    Private Sub CmdSaveClick()
        Dim S As String
        Dim rs As New DataSet
        Dim intCountFailure As Integer

        If rs_Except Is Nothing Then Exit Sub
        If rs_Except.Tables("result") Is Nothing Then Exit Sub
        rs_Except.Tables("result").DefaultView.RowFilter = "gen='A' or gen='R'"
        rs_Except_ref.Tables("result").DefaultView.RowFilter = "gen='A' or gen='R'"

        If rs_Except.Tables("result").DefaultView.Count <= 0 And rs_Except_ref.Tables("result").DefaultView.Count <= 0 Then
            On Error Resume Next
            rs_Except.Tables("result").DefaultView.RowFilter = ""
            rs_Except_ref.Tables("result").DefaultView.RowFilter = ""
            'Lester Wu 2006-03-10
            If optHdr.Checked = True Then
                Call DisplayHeader_Exp(Me.grdExcept)
            Else
                Call DisplayDetail_Exp(Me.grdExcept)
            End If
            MsgBox("No updated record(s)!")
            Exit Sub
        End If
        Me.SSTab1.SelectedIndex = 0

        Me.txtMsg.Text = ""


        If MsgBox("Confirm to Update Record(s)?", vbYesNo + vbQuestion) = vbNo Then
            On Error Resume Next
            rs_Except.Tables("result").DefaultView.RowFilter = ""
            rs_Except_ref.Tables("result").DefaultView.RowFilter = ""
            'Lester Wu 2006-03-10
            If optHdr.Checked = True Then
                Call DisplayHeader_Exp(Me.grdExcept)
            Else
                Call DisplayDetail_Exp(Me.grdExcept)
            End If
            Exit Sub
        End If

        'Lester Wu 2005-11-16
        intCountFailure = 0

        Cursor = Cursors.WaitCursor
        'Process data in folder (1)
        With rs_Except
            If .Tables("result").DefaultView.Count > 0 Then
                For i As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                    If optHdr.Checked = True Then

                        gspStr = "sp_select_MPO00003_Hdr_update  '" & _
                           "','" & .Tables("RESULT").DefaultView(i)("gen") & _
                           "','" & .Tables("RESULT").DefaultView(i)("Mxh_FilNam") & _
                           "','" & .Tables("RESULT").DefaultView(i)("Mxh_seq") & _
                           "','" & gsUsrID & "'"
                    Else
                        gspStr = "sp_select_MPO00003_Dtl_update  '" & _
                          "','" & .Tables("RESULT").DefaultView(i)("gen") & _
                          "','" & .Tables("RESULT").DefaultView(i)("Mxd_FilNam") & _
                          "','" & .Tables("RESULT").DefaultView(i)("Mxd_seq") & _
                          "','" & gsUsrID & "'"
                    End If

                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading txtShpNoKeyPress sp_select_MMPORDHDR :" & rtnStr)
                        Exit Sub
                    End If



                    If rs.Tables("RESULT").Rows(0)(0).ToString = "99" Then
                        If Not rs Is Nothing Then
                            If rs.Tables("result").DefaultView.Count > 0 Then
                                Me.txtMsg.Text = Me.txtMsg.Text & IIf(Me.txtMsg.Text <> "", vbCrLf, "") & rs.Tables("RESULT").Rows(1)(0).ToString

                                If InStr(rs.Tables("RESULT").Rows(1)(0).ToString, "sucess") <= 0 Then
                                    'tempzzzzzzzzzzzzzzzzzzzzzzzzzzzzz
                                    intCountFailure = intCountFailure + 1
                                End If
                            End If
                        End If
                    ElseIf rtnLong <> "0" Then  '*** An error has occured
                        '                    ElseIf rs.Tables("RESULT").Rows(0)(0).ToString <> "0" Then  '*** An error has occured
                        MsgBox(rs.Tables("RESULT").Rows(0)(0).ToString)
                        Exit Sub
                    Else
                        If Not rs Is Nothing Then
                            If rs.Tables("result").DefaultView.Count > 0 Then
                                Me.txtMsg.Text = Me.txtMsg.Text & IIf(Me.txtMsg.Text <> "", vbCrLf, "") & rs.Tables("RESULT").Rows(0)(0).ToString
                                If InStr(rs.Tables("RESULT").Rows(0)(0).ToString, "Success") <= 0 Then
                                    'tempzzzzzzzzzzzzz
                                    intCountFailure = intCountFailure + 1
                                End If
                            End If
                        End If
                    End If

                Next


                gsCompany = IIf(gsCompanyGroup = "UCG", "UCPP", "MS")
                Call Update_gs_Value(gsCompany)
            End If
        End With


        'Process data in folder (2)
        With rs_Except_ref
            If .Tables("result").DefaultView.Count > 0 Then
                For i As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1

                    If optHdr.Checked = True Then

                        gspStr = "sp_select_MPO00003_Dtl_update  '" & _
                          "','" & .Tables("RESULT").DefaultView(i)("gen") & _
                          "','" & .Tables("RESULT").DefaultView(i)("Mxd_FilNam") & _
                          "','" & .Tables("RESULT").DefaultView(i)("Mxd_seq") & _
                          "','" & gsUsrID & "'"
                    Else

                        gspStr = "sp_select_MPO00003_Hdr_update  '" & _
                           "','" & .Tables("RESULT").DefaultView(i)("gen") & _
                           "','" & .Tables("RESULT").DefaultView(i)("Mxh_FilNam") & _
                           "','" & .Tables("RESULT").DefaultView(i)("Mxh_seq") & _
                           "','" & gsUsrID & "'"

                    End If

                    gsCompany = IIf(gsCompanyGroup = "UCG", "UCPP", "MS")
                    Call Update_gs_Value(gsCompany)
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading txtShpNoKeyPress sp_select_MMPORDHDR :" & rtnStr)
                        Exit Sub
                    End If

                    'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

                    If rs.Tables("RESULT").Rows(0)(0).ToString = "99" Then
                        If Not rs Is Nothing Then
                            If rs.Tables("result").DefaultView.Count > 0 Then
                                Me.txtMsg.Text = Me.txtMsg.Text & IIf(Me.txtMsg.Text <> "", vbCrLf, "") & rs.Tables("RESULT").Rows(1)(0).ToString
                                'Lester Wu 2005-11-16
                                If InStr(rs.Tables("RESULT").Rows(1)(0).ToString, "sucess") <= 0 Then
                                    intCountFailure = intCountFailure + 1
                                End If
                            End If
                        End If

                    ElseIf rtnLong <> "0" Then  '*** An error has occured
                        '                    ElseIf rs.Tables("RESULT").Rows(0)(0).ToString <> "0" Then  '*** An error has occured
                        MsgBox(rs.Tables("RESULT").Rows(0)(0).ToString)
                        Exit Sub
                    Else
                        If Not rs Is Nothing Then
                            If rs.Tables("result").DefaultView.Count > 0 Then
                                Me.txtMsg.Text = Me.txtMsg.Text & IIf(Me.txtMsg.Text <> "", vbCrLf, "") & rs.Tables("RESULT").Rows(0)(0).ToString

                                If InStr(rs.Tables("RESULT").Rows(0)(0).ToString, "sucess") <= 0 Then
                                    intCountFailure = intCountFailure + 1
                                End If
                            End If
                        End If
                    End If
                Next
            End If
        End With

        Cursor = Cursors.Default
        MsgBox("Process Completed with (" & intCountFailure & ") Failure(s)!")
        Call setStatus("Clear")
    End Sub

    Private Sub setStatus(ByVal Mode As String)
        'Private Sub setStatus(Mode As String, Optional rs As New DataSet)

        Select Case Mode
            Case "Init"
                cmdAdd.Enabled = False
                cmdSave.Enabled = False
                cmdDelete.Enabled = False
                cmdCopy.Enabled = False
                cmdFind.Enabled = True
                cmdClear.Enabled = False

                cmdSearch.Enabled = False
                cmdspecial.Enabled = False
                CmdLookup.Enabled = False
                cmdbrowlist.Enabled = False

                cmdInsRow.Enabled = False
                cmdDelRow.Enabled = False

                cmdFirst.Enabled = False
                cmdLast.Enabled = False
                cmdNext.Enabled = False
                cmdPrv.Enabled = False

                cmdExit.Enabled = True

                '        Me.txtFilNamFm.Enabled = True
                '        Me.txtFilNamTo.Enabled = True
                Me.txtPOFm.Enabled = True
                Me.txtPOTo.Enabled = True
                Me.txtUplDatFm.Enabled = True
                Me.txtUplDatTo.Enabled = True

                '        Me.txtFilNamFm.Text = ""
                '        Me.txtFilNamTo.Text = ""
                Me.txtPOFm.Text = ""
                Me.txtPOTo.Text = ""
                Me.txtUplDatFm.Text = Format(Now, "MM/dd/yyyy")
                Me.txtUplDatTo.Text = Format(Now, "MM/dd/yyyy")

                Me.txtFm.Text = 0
                Me.txtTo.Text = 0

                Me.frmApproveReject.Visible = False
                Me.frmException.Visible = True
                Me.frmStatus.Visible = True
                Me.SSTab1.Enabled = False
                Me.SSTab1.SelectedIndex = 0

            Case "Update"
                Me.cmdFind.Enabled = False
                Me.cmdClear.Enabled = True
                Me.cmdSave.Enabled = Enq_right_local 'True
                '        Me.txtFilNamFm.Enabled = False
                '        Me.txtFilNamTo.Enabled = False
                Me.txtPOFm.Enabled = False
                Me.txtPOTo.Enabled = False
                Me.txtUplDatFm.Enabled = False
                Me.txtUplDatTo.Enabled = False
                Me.frmApproveReject.Visible = True
                Me.frmException.Visible = False
                Me.frmStatus.Visible = False
                Me.SSTab1.Enabled = True
                Me.SSTab1.SelectedIndex = 0

            Case "Clear"
                grdExcept.DataSource = Nothing
                grdMPOHdr.DataSource = Nothing
                grdMPODtl.DataSource = Nothing

                rs_Except = Nothing
                rs_MPORDHDR = Nothing
                rs_MPORDDTL = Nothing

                cmdFind.Enabled = True
                cmdClear.Enabled = False
                Me.cmdSave.Enabled = False

                Me.txtPOFm.Enabled = True
                Me.txtPOTo.Enabled = True
                Me.txtUplDatFm.Enabled = True
                Me.txtUplDatTo.Enabled = True

                Me.txtPOFm.Text = ""
                Me.txtPOTo.Text = ""
                ' Me.txtUplDatFm.Text = Format(Now, "MM/dd/yyyy")
                ' Me.txtUplDatTo.Text = Format(Now, "MM/dd/yyyy")

                Me.txtFm.Text = "0"
                Me.txtTo.Text = "0"
                Me.frmApproveReject.Visible = False
                Me.frmException.Visible = True
                Me.frmStatus.Visible = True
                Me.SSTab1.SelectedIndex = 0
                Me.SSTab1.Enabled = False

            Case "Exit"
                '        Set grdExcept.DataSource = Nothing
                '        Set grdMPOHdr.DataSource = Nothing
                '        Set grdMPODtl.DataSource = Nothing
                '        Set rs_Except = Nothing
                '        Set rs_MPORDHDR = Nothing
                '        Set rs_MPORDDTL = Nothing
                Call setStatus("Clear")
        End Select
    End Sub

    Private Sub SetStatusBar(ByVal Mode As String)

        If Me.SSTab1.SelectedIndex = 1 Then
            If Not rs_MPORDHDR Is Nothing Then
                If Not rs_MPORDHDR.Tables("result") Is Nothing Then
                    If rs_MPORDHDR.Tables("result").Rows.Count > 0 Then
                        '                    Me.StatusBar.Panels(2).Text = rs_MPORDHDR("Mxh_UpdUsr") & "  " & Format(rs_MPORDHDR("Mxh_CreDat"), "MM/dd/yyyy") & "  " & Format(rs_MPORDHDR("Mxh_UpdDat"), "MM/dd/yyyy")
                    End If
                End If
            End If
        ElseIf Me.SSTab1.SelectedIndex = 2 Then
            If Not rs_MPORDDTL Is Nothing Then
                If rs_MPORDDTL.Tables("result").Rows.Count > 0 Then
                    '                    Me.StatusBar.Panels(2).Text = rs_MPORDDTL("Mxd_UpdUsr") & "  " & Format(rs_MPORDDTL("Mxd_CreDat"), "MM/dd/yyyy") & "  " & Format(rs_MPORDDTL("Mxd_UpdDat"), "MM/dd/yyyy")
                End If
            End If
        End If
    End Sub

    Private Sub DisplayHeader_Exp(ByRef grd0 As DataGridView)
        Dim intCol As Integer
        Dim i As Integer
        Me.grdMPOHdr.DataSource = Nothing
        Me.grdMPODtl.DataSource = Nothing

        If Me.optHdr.Checked = True Then
            If rs_Except Is Nothing Then Exit Sub
            If rs_Except.Tables("RESULT") Is Nothing Then Exit Sub

            'If rs_Except.Tables("result").Rows.Count <= 0 Then Exit Sub
        Else
            If rs_Except_ref Is Nothing Then Exit Sub
            If rs_Except_ref.Tables("RESULT") Is Nothing Then Exit Sub
            'If rs_Except_ref.Tables("result").Rows.Count <= 0 Then Exit Sub
        End If

        Me.txtFm.Text = "0"
        Me.txtTo.Text = "0"

        If Me.optHdr.Checked = True Then
            With rs_Except
                If .Tables("result").Rows.Count > 0 Then
                    Me.txtFm.Text = "1"

                    For i = 0 To .Tables("result").Rows.Count - 1
                        .Tables("RESULT").Rows(i)("SEQ") = i + 1
                    Next

                    Me.txtTo.Text = CStr(i)

                End If
            End With
        Else
            With rs_Except_ref
                If .Tables("result").Rows.Count > 0 Then
                    Me.txtFm.Text = "1"
                    For i = 0 To .Tables("result").Rows.Count - 1
                        .Tables("RESULT").Rows(i)("SEQ") = i + 1
                    Next
                    Me.txtTo.Text = CStr(i)
                End If
            End With
        End If


        If Me.optHdr.Checked = True Then
            grd0.DataSource = rs_Except.Tables("RESULT")
        Else
            grd0.DataSource = rs_Except_ref.Tables("RESULT")
        End If
        With grd0
            intCol = 0
            .Columns(intCol).HeaderText = "Gen"
            '.Columns(intCol).Button = True
            .Columns(intCol).Width = 40

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Seq"
            .Columns(intCol).Width = 40

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Exception Msg"
            .Columns(intCol).Width = 300

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "PO # (ZS)"
            .Columns(intCol).Width = 100

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Vendor #"
            .Columns(intCol).Width = 80

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Import Vendor"
            .Columns(intCol).Width = 120

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ship To Dest."
            .Columns(intCol).Width = 120

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Currency"
            .Columns(intCol).Width = 80

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Remark"
            .Columns(intCol).Width = 300

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "MPO Flag (HK)"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "MPO # (HK)"
            .Columns(intCol).Width = 140

            '        intCol = intCol + 1
            '        .Columns(intCol).HeaderText = "Exception Msg"
            '        .Columns(intCol).width = 300

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Update Flag (ZS)"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "PO Date"
            .Columns(intCol).Width = 100

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "PO User"
            .Columns(intCol).Width = 100

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Confirm User"
            .Columns(intCol).Width = 100

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Confirm Date"
            .Columns(intCol).Width = 100

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Contact Person"
            .Columns(intCol).Width = 120

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "File Name"
            .Columns(intCol).Width = 200

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "seq #"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

        End With
        Call SetStatusBar("Update")
    End Sub

    Private Sub DisplayDetail_Exp(ByRef grd1 As DataGridView)

        Dim intCol As Integer
        Dim i As Integer

        Me.grdMPOHdr.DataSource = Nothing
        Me.grdMPODtl.DataSource = Nothing

        If Me.optDtl.Checked = True Then
            If rs_Except Is Nothing Then Exit Sub
            If rs_Except.Tables("result") Is Nothing Then Exit Sub
            'If rs_Except.Tables("result").Rows.Count <= 0 Then Exit Sub
        Else
            If rs_Except_ref Is Nothing Then Exit Sub
            If rs_Except_ref.Tables("result") Is Nothing Then Exit Sub
            'If rs_Except_ref.Tables("result").Rows.Count <= 0 Then Exit Sub
        End If

        Me.txtFm.Text = "0"
        Me.txtTo.Text = "0"

        If Me.optDtl.Checked = True Then
            With rs_Except
                If .Tables("result").Rows.Count > 0 Then
                    Me.txtFm.Text = "1"
                    For i = 0 To .Tables("result").Rows.Count - 1
                        .Tables("RESULT").Rows(i)("SEQ") = i + 1
                    Next
                    Me.txtTo.Text = CInt(i + 1)
                End If
            End With
        Else
            With rs_Except_ref
                If .Tables("result").Rows.Count > 0 Then
                    Me.txtFm.Text = "1"
                    For i = 0 To .Tables("result").Rows.Count - 1
                        .Tables("RESULT").Rows(i)("SEQ") = i + 1
                    Next
                    Me.txtTo.Text = CInt(i + 1)
                End If
            End With
        End If

        Me.txtTo.Text = CStr(i)

        If Me.optDtl.Checked = True Then
            grd1.DataSource = rs_Except.Tables("result").DefaultView
        Else
            grd1.DataSource = rs_Except_ref.Tables("result").DefaultView
        End If

        With grd1
            intCol = 0
            .Columns(intCol).HeaderText = "Gen"
            '.Columns(intCol).Button = True
            .Columns(intCol).Width = 40

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Seq"
            .Columns(intCol).Width = 40

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Exception"
            .Columns(intCol).Width = 200

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "PO # (ZS)"
            .Columns(intCol).Width = 120

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Seq (ZS)"
            .Columns(intCol).Width = 80

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Item No"
            .Columns(intCol).Width = 120


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Item Name"
            .Columns(intCol).Width = 200


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Item Description"
            .Columns(intCol).Width = 300


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Color"
            .Columns(intCol).Width = 100


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "UM"
            .Columns(intCol).Width = 80


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Qty"
            .Columns(intCol).Width = 80


            intCol = intCol + 1
            .Columns(intCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(intCol).HeaderText = "Unit Price"
            .Columns(intCol).Width = 100


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Packing Method"
            .Columns(intCol).Width = 150


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Department"
            .Columns(intCol).Width = 120


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Request #"
            .Columns(intCol).Width = 120

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ship Date"
            .Columns(intCol).Width = 120

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Production #"
            .Columns(intCol).Width = 120


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Remark"
            .Columns(intCol).Width = 200

            '
            '        intCol = intCol + 1
            '        .Columns(intCol).HeaderText = "Exception"
            '        .Columns(intCol).width = 200
            '

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Update Flag (ZS)"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "MPO Flag (HK)"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "MPO # (HK)"
            .Columns(intCol).Width = 160


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "File Name"
            .Columns(intCol).Width = 180


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Record Seq"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False


            intCol = intCol + 1
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
        End With

        Call SetStatusBar("Update")

    End Sub

    Private Sub Form_Unload(ByVal Cancel As Integer)
    End Sub



    Private Sub grdExcept_ButtonClick(ByVal ColIndex As Integer)
    End Sub
    'tempzzzzzzzzzzzz
    'Private Sub grdExcept_ref_ButtonClick(ByVal ColIndex As Integer)
    '    If rs_Except_ref Is Nothing Then Exit Sub
    '    If rs_Except_ref.Tables("result").Rows.Count <= 0 Then Exit Sub

    '    If optDtl.Checked = True Then
    '        If Trim(rs_Except_ref("Mxh_MPOFlg")) <> "E" Then Exit Sub
    '    Else
    '        If Trim(rs_Except_ref("Mxd_MPOFlg")) <> "E" Then Exit Sub
    '    End If

    '    With grdExcept_ref
    '        If ColIndex = 0 Then
    '            If .Columns(ColIndex) = " " Then
    '                .Columns(ColIndex) = "A"
    '            ElseIf .Columns(ColIndex) = "A" Then
    '                .Columns(ColIndex) = "R"
    '            ElseIf .Columns(ColIndex) = "R" Then
    '                .Columns(ColIndex) = " "
    '            End If
    '        End If
    '    End With
    'End Sub

    Private Sub grdMPODtl_RowColChange(ByVal LastRow As Object, ByVal LastCol As Integer)
        Call SetStatusBar("Update")
    End Sub
    'temp




    Private Sub grdMPOHdr_RowColChange(ByVal LastRow As Object, ByVal LastCol As Integer)
        Call SetStatusBar("Update")
    End Sub


    Private Sub SSTab1_Click(ByVal PreviousTab As Integer)
    End Sub

    Private Sub moveHeaderRecord(ByVal strAct As String)
        Me.cmdFirstD.Enabled = False
        Me.cmdPrevD.Enabled = False
        Me.cmdNextD.Enabled = False
        Me.cmdLastD.Enabled = False


        If rs_Except Is Nothing Then Exit Sub
        If rs_Except.Tables("result") Is Nothing Then Exit Sub
        If rs_Except.Tables("result").Rows.Count <= 0 Then Exit Sub

        With rs_Except
            Select Case strAct
                Case "F"
                    readingindex = 0
                    '          .MoveFirst()
                Case "P"
                    readingindex = readingindex - 1
                    If readingindex < 0 Then
                        readingindex = 0
                    End If
                    '                    If .BOF = False And .AbsolutePosition > 1 Then .MovePrevious()
                Case "N"
                    readingindex = readingindex + 1
                    If readingindex > rs_Except.Tables("result").Rows.Count - 1 Then
                        readingindex = rs_Except.Tables("result").Rows.Count - 1
                    End If

                    '                    If .EOF = False And .AbsolutePosition < .Tables("result").Rows.Count Then .MoveNext()
                Case "L"
                    readingindex = rs_Except.Tables("result").Rows.Count - 1
                    '                   .MoveLast()
            End Select

            If .Tables("result").Rows.Count > 1 Then
                If readingindex > 0 Then
                    Me.cmdFirstD.Enabled = True
                    Me.cmdPrevD.Enabled = True
                End If
                If readingindex < .Tables("result").Rows.Count - 1 Then
                    Me.cmdNextD.Enabled = True
                    Me.cmdLastD.Enabled = True
                End If
            End If
        End With

        If Me.SSTab1.SelectedIndex = 1 Then
            If optHdr.Checked = True Then
                Me.txtPONo.Text = rs_Except.Tables("result").Rows(readingindex)("Mxh_PONo")
                rs_Except_ref.Tables("result").DefaultView.RowFilter = "Mxd_PONo = '" & rs_Except.Tables("result").Rows(readingindex)("Mxh_PONo") & "'"
                Call DisplayDetail_Exp(Me.grdExcept_ref)
            Else
                Me.txtPONo.Text = rs_Except.Tables("result").Rows(readingindex)("Mxd_PONo")
                rs_Except_ref.Tables("result").DefaultView.RowFilter = "Mxh_PONo = '" & rs_Except.Tables("result").Rows(readingindex)("Mxd_PONo") & "'"
                Call DisplayHeader_Exp(Me.grdExcept_ref)
            End If
        End If
    End Sub







    Private Sub txtFm_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFm.KeyPress
        If e.KeyChar <> Chr(8) And InStr("1234567890", e.KeyChar) <= 0 Then e.KeyChar = Chr(0)
    End Sub


    Private Sub txtFm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFm.LostFocus
        If Me.txtFm.Text = "" Then Me.txtFm.Text = "0"
    End Sub



    'Private Sub txtFilNamFm_LostFocus()
    '    Me.txtFilNamTo.Text = Me.txtFilNamFm.Text
    'End Sub


    'Private Sub txtFilNamTo_GotFocus()
    '    Me.txtFilNamTo.selectionStart = 0
    '    Me.txtFilNamTo.SelectionLength = Len(Me.txtFilNamTo.Text)
    'End Sub

    Private Sub txtPOFm_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPOFm.GotFocus
        Me.txtPOFm.SelectionStart = 0
        Me.txtPOFm.SelectionLength = Len(Me.txtPOFm.Text)
    End Sub

    Private Sub txtPOFm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPOFm.LostFocus
        Me.txtPOTo.Text = Me.txtPOFm.Text
    End Sub

    Private Sub txtPOTo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPOTo.GotFocus
        Me.txtPOTo.SelectionStart = 0
        Me.txtPOTo.SelectionLength = Len(Me.txtPOTo.Text)
    End Sub

    Private Sub txtTo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTo.GotFocus
        Me.txtTo.SelectionStart = 0
        Me.txtTo.SelectionLength = Len(Me.txtTo.Text)
    End Sub



    Private Sub txtTo_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTo.KeyPress
        If e.KeyChar <> Chr(8) And InStr("1234567890", e.KeyChar) <= 0 Then e.KeyChar = Chr(0)

    End Sub


    Private Sub txtTo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTo.LostFocus
        If Me.txtTo.Text = "" Then Me.txtTo.Text = "0"

    End Sub

    Private Sub txtUplDatFm_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUplDatFm.GotFocus
        Me.txtUplDatFm.SelectionStart = 0
        Me.txtUplDatFm.SelectionLength = Len(Me.txtUplDatFm.Text)
    End Sub

    Private Sub txtUplDatFm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUplDatFm.LostFocus
        If Me.txtUplDatFm.Text = "  /  /    " Then Exit Sub
        If IsDate(Me.txtUplDatFm.Text) = False Then
            MsgBox("Invalid Date Value!")
            Me.txtUplDatFm.Focus()
            Exit Sub
        End If
        'Me.txtUplDatTo.Text = Me.txtUplDatFm.Text
    End Sub

    Private Sub txtUplDatTo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUplDatTo.GotFocus
        Me.txtUplDatTo.SelectionStart = 0
        Me.txtUplDatTo.SelectionLength = Len(Me.txtUplDatTo.Text)
    End Sub

    Private Sub txtUplDatTo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUplDatTo.LostFocus
        If Me.txtUplDatTo.Text = "  /  /    " Then Exit Sub
        If IsDate(Me.txtUplDatTo.Text) = False Then
            MsgBox("Invalid Date Value!")
            Me.txtUplDatTo.Focus()
            Exit Sub
        End If

    End Sub


    Private Sub MPO00003_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim YNC As Integer
        If Not rs_Except Is Nothing Then
            If Not rs_Except.Tables("result") Is Nothing Then
                If rs_Except.Tables("result").Rows.Count > 0 Then
                    rs_Except.Tables("result").DefaultView.RowFilter = "gen = 'A' or gen='R'"
                    If rs_Except.Tables("result").DefaultView.Count > 0 Then

                        YNC = MsgBox("There is updated record(s)!" & vbCrLf & "Save before exit?", vbYesNoCancel + vbDefaultButton3 + vbQuestion, "Updated record(s) not save")
                        If YNC = vbYes Then

                            If Enq_right_local Then
                                Call CmdSaveClick()
                                If save_ok = False Then e.Cancel = True
                            Else
                                MsgBox("You do not have rights to save!" & vbCrLf & "Program will exit without save!", vbInformation + vbOKOnly)
                            End If
                        ElseIf YNC = vbCancel Then
                            e.Cancel = True
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub MPO00003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call AccessRight(Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        '#If useMTS Then
        '        Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If

        Cursor = Cursors.WaitCursor
        '        gsConnStr = getConnectionString()
        Me.KeyPreview = True
        Call setStatus("Init")
        Call Formstartup(Me.Name)   'Set the form Sartup position
        Cursor = Cursors.Default


    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Call cmdFindClick()
    End Sub

    Private Sub RichTextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Call CmdSaveClick()
    End Sub

    Private Sub chkApprove_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkApprove.CheckedChanged

    End Sub

    Private Sub txtFm_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFm.GotFocus
        Me.txtFm.SelectionStart = 0
        Me.txtFm.SelectionLength = Len(Me.txtFm.Text)

    End Sub

    Private Sub txtFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFm.TextChanged

    End Sub



    Private Sub txtPOFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPOFm.TextChanged

    End Sub


    Private Sub txtPOTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPOTo.TextChanged

    End Sub




    Private Sub txtTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTo.TextChanged

    End Sub



    Private Sub txtUplDatFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUplDatFm.TextChanged

    End Sub



    Private Sub txtUplDatTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUplDatTo.TextChanged

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()

    End Sub

    Private Sub grdExcept_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdExcept.CellClick
        Dim ColIndex As Integer

        readingindex = e.RowIndex
        ColIndex = e.ColumnIndex

        If rs_Except Is Nothing Then Exit Sub
        If rs_Except.Tables("result").Rows.Count <= 0 Then Exit Sub
        If optHdr.Checked = True Then
            If Trim(rs_Except.Tables("result").Rows(readingindex)("Mxh_MPOFlg")) <> "E" Then Exit Sub
        Else
            If Trim(rs_Except.Tables("result").Rows(readingindex)("Mxd_MPOFlg")) <> "E" Then Exit Sub
        End If
        With grdExcept
            If ColIndex = 0 Then


                If .Item(ColIndex, grdExcept.CurrentCell.RowIndex).Value() = " " Then
                    .Item(ColIndex, grdExcept.CurrentCell.RowIndex).Value() = "A"
                ElseIf .Item(ColIndex, grdExcept.CurrentCell.RowIndex).Value() = "A" Then
                    .Item(ColIndex, grdExcept.CurrentCell.RowIndex).Value() = "R"
                ElseIf .Item(ColIndex, grdExcept.CurrentCell.RowIndex).Value() = "R" Then
                    .Item(ColIndex, grdExcept.CurrentCell.RowIndex).Value() = " "
                End If
            End If
        End With



    End Sub

    Private Sub grdExcept_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdExcept.CellContentClick

    End Sub

    Private Sub grdExcept_ref_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdExcept_ref.CellContentClick

    End Sub

    Private Sub grdMPOHdr_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdMPOHdr.CellContentClick

    End Sub

    Private Sub grdMPODtl_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdMPODtl.CellContentClick

    End Sub


    Private Sub SSTab1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SSTab1.SelectedIndexChanged
        If bolFind = True Then Exit Sub
        Me.txtFm.Text = "0"
        Me.txtTo.Text = "0"
        If SSTab1.SelectedIndex = 0 Then
            If Not rs_Except Is Nothing Then
                If Not rs_Except.Tables("result") Is Nothing Then
                    If rs_Except.Tables("result").Rows.Count > 0 Then
                        Me.txtFm.Text = "1"
                        Me.txtTo.Text = rs_Except.Tables("result").Rows.Count
                    End If
                End If
            End If
        ElseIf SSTab1.SelectedIndex = 1 Then
            '        If optHdr.checked = True Then
            '            rs_Except_ref.Tables("result").DefaultView.RowFilter = "Mxd_PONo = '" & rs_Except.Tables("result").Rows(readingindex)("Mxh_PONo") & "'"
            '        Else
            '            rs_Except_ref.Tables("result").DefaultView.RowFilter = "Mxh_PONo = '" & rs_Except.Tables("result").Rows(readingindex)("Mxd_PONo") & "'"
            '        End If
            moveHeaderRecord("X")
        ElseIf SSTab1.SelectedIndex = 2 Then
            Call DisplayHeader()
        ElseIf SSTab1.SelectedIndex = 3 Then
            Call DisplayDetail()
        End If


    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        Call cmdApply_Click()

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Call cmdClear_Click()


    End Sub

    Private Sub optALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optALL.CheckedChanged

    End Sub
End Class














































































