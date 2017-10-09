Public Class MPM00001

    Inherits System.Windows.Forms.Form

    Public rs_MPORDHDR As New DataSet
    Public rs_SYSETINF As New DataSet
    Public rs_SYAGTINF As New DataSet
    Public rs_SYSALREP As New DataSet
    Public rs_CUBASINF As New DataSet
    Public rs_CVNCNTINF As New DataSet
    Public rs_sydisprm As New DataSet
    Public rs_MPORDDTL As New DataSet
    Public rs_VNBASINF As New DataSet
    Public rs_VNCNTINF As New DataSet
    Public rs_ZSITMLST As New DataSet
    Public rs_GRNVENINF As New DataSet

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim varSort As String

    Dim Add_flag As Boolean
    Dim IsUpdated As Boolean
    Dim save_ok As Boolean
    Dim AllowUpdate As Boolean
    Dim Current_TimeStamp As Long
    Dim find_flag As Boolean
    Dim Recordstatus As Boolean

    Dim Form_Error As Boolean
    Dim flag_grdcontrol As String
    Dim flag_exit As Boolean
    Dim Temp_POno As String
    Dim dateok As Boolean
    Dim Total_D_Amt As Double
    Dim Total_D_Per As Double
    Dim Total_P_Amt As Double
    Dim Total_P_Per As Double
    Dim VendorType As String
    Dim befVenAddr As String
    Dim Curr As String
    Dim MaxSeq As Long
    Dim ErrFlag As Boolean
    Dim readingindex As Integer
    Public frmPOB As frmPOBom
    Dim PreviousTab As Integer
    Public flag_cboImpCnt_GotFocus As Boolean



#Region " Windows Form Designer generated code"
    Friend WithEvents btcMPM00001 As ERPSystem.BaseTabControl
    Friend WithEvents tpMPM00001_1 As System.Windows.Forms.TabPage
    Friend WithEvents tpMPM00001_2 As System.Windows.Forms.TabPage
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents cmdspecial As System.Windows.Forms.Button
    Friend WithEvents cmdbrowlist As System.Windows.Forms.Button
    Friend WithEvents txtPONo As System.Windows.Forms.TextBox
    Friend WithEvents lblQutNo As System.Windows.Forms.Label
    Friend WithEvents DTRvsDat As System.Windows.Forms.TextBox
    Friend WithEvents lblRvsDat As System.Windows.Forms.Label
    Friend WithEvents DTIssDat As System.Windows.Forms.TextBox
    Friend WithEvents lblIssDat As System.Windows.Forms.Label
    Friend WithEvents lblQutSts As System.Windows.Forms.Label
    Friend WithEvents cboPOStatus As System.Windows.Forms.ComboBox
    Friend WithEvents tpMPM00001_3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gbPri As System.Windows.Forms.GroupBox
    Friend WithEvents txtShpAdr As System.Windows.Forms.RichTextBox
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
    Friend WithEvents chkDelete As System.Windows.Forms.CheckBox
    Friend WithEvents CmdDtlPre As System.Windows.Forms.Button
    Friend WithEvents CmdDtlNext As System.Windows.Forms.Button
    Friend WithEvents txtCusVen As System.Windows.Forms.TextBox
    Friend WithEvents txtVenNo As System.Windows.Forms.TextBox
    Friend WithEvents txtPurOrd As System.Windows.Forms.TextBox
    Friend WithEvents txtColCde As System.Windows.Forms.TextBox
    Friend WithEvents cboPrcTrm As System.Windows.Forms.ComboBox
    Friend WithEvents grdSummary As System.Windows.Forms.DataGridView
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
    Friend WithEvents cboVenNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboVenAddr As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRemAddr As System.Windows.Forms.RichTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboPorCtp As System.Windows.Forms.ComboBox
    Friend WithEvents txtCur1 As System.Windows.Forms.TextBox
    Friend WithEvents txtCty As System.Windows.Forms.TextBox
    Friend WithEvents txtStt As System.Windows.Forms.TextBox
    Friend WithEvents txtPst As System.Windows.Forms.TextBox
    Friend WithEvents cbopayTrm As System.Windows.Forms.ComboBox
    Friend WithEvents txtTtlAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtNetAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtCur2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDiscnt As System.Windows.Forms.TextBox
    Friend WithEvents txtshpplc As System.Windows.Forms.TextBox
    Friend WithEvents cboImpCnt As System.Windows.Forms.ComboBox
    Friend WithEvents txtRmk As System.Windows.Forms.RichTextBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents RichTextBox3 As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPurSeq As System.Windows.Forms.TextBox
    Friend WithEvents cboItmNo As System.Windows.Forms.ComboBox
    Friend WithEvents txtItmNam As System.Windows.Forms.RichTextBox
    Friend WithEvents txtWTPONo As System.Windows.Forms.TextBox
    Friend WithEvents dtdWTPODate As System.Windows.Forms.TextBox
    Friend WithEvents cboUM As System.Windows.Forms.ComboBox
    Friend WithEvents txtVenitm As System.Windows.Forms.TextBox
    Friend WithEvents txtOrdQty As System.Windows.Forms.TextBox
    Friend WithEvents txtOrgUntPrc As System.Windows.Forms.TextBox
    Friend WithEvents txtCur3 As System.Windows.Forms.TextBox
    Friend WithEvents txtUntPrc As System.Windows.Forms.TextBox
    Friend WithEvents cboCurr As System.Windows.Forms.ComboBox
    Friend WithEvents txtSubTtlAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtCur5 As System.Windows.Forms.TextBox
    Friend WithEvents DTDShpDat As System.Windows.Forms.TextBox
    Friend WithEvents DTDOrgShpDat As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label

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
        Me.txtPONo = New System.Windows.Forms.TextBox
        Me.lblQutNo = New System.Windows.Forms.Label
        Me.DTRvsDat = New System.Windows.Forms.TextBox
        Me.lblRvsDat = New System.Windows.Forms.Label
        Me.DTIssDat = New System.Windows.Forms.TextBox
        Me.lblIssDat = New System.Windows.Forms.Label
        Me.lblQutSts = New System.Windows.Forms.Label
        Me.cboPOStatus = New System.Windows.Forms.ComboBox
        Me.StatusBar = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.ComboBox6 = New System.Windows.Forms.ComboBox
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox
        Me.btcMPM00001 = New ERPSystem.BaseTabControl
        Me.tpMPM00001_1 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtRmk = New System.Windows.Forms.RichTextBox
        Me.txtPst = New System.Windows.Forms.TextBox
        Me.cboPorCtp = New System.Windows.Forms.ComboBox
        Me.txtCty = New System.Windows.Forms.TextBox
        Me.txtStt = New System.Windows.Forms.TextBox
        Me.txtRemAddr = New System.Windows.Forms.RichTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboVenAddr = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboVenNo = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtNetAmt = New System.Windows.Forms.TextBox
        Me.txtCur2 = New System.Windows.Forms.TextBox
        Me.txtDiscnt = New System.Windows.Forms.TextBox
        Me.txtTtlAmt = New System.Windows.Forms.TextBox
        Me.cbopayTrm = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboPrcTrm = New System.Windows.Forms.ComboBox
        Me.txtCur1 = New System.Windows.Forms.TextBox
        Me.gbPri = New System.Windows.Forms.GroupBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtshpplc = New System.Windows.Forms.TextBox
        Me.cboImpCnt = New System.Windows.Forms.ComboBox
        Me.txtShpAdr = New System.Windows.Forms.RichTextBox
        Me.tpMPM00001_2 = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.DTDShpDat = New System.Windows.Forms.TextBox
        Me.DTDOrgShpDat = New System.Windows.Forms.TextBox
        Me.txtSubTtlAmt = New System.Windows.Forms.TextBox
        Me.txtCur5 = New System.Windows.Forms.TextBox
        Me.txtUntPrc = New System.Windows.Forms.TextBox
        Me.cboCurr = New System.Windows.Forms.ComboBox
        Me.txtOrgUntPrc = New System.Windows.Forms.TextBox
        Me.txtCur3 = New System.Windows.Forms.TextBox
        Me.txtOrdQty = New System.Windows.Forms.TextBox
        Me.cboUM = New System.Windows.Forms.ComboBox
        Me.txtVenitm = New System.Windows.Forms.TextBox
        Me.dtdWTPODate = New System.Windows.Forms.TextBox
        Me.txtWTPONo = New System.Windows.Forms.TextBox
        Me.txtPurSeq = New System.Windows.Forms.TextBox
        Me.cboItmNo = New System.Windows.Forms.ComboBox
        Me.txtItmNam = New System.Windows.Forms.RichTextBox
        Me.CmdDtlNext = New System.Windows.Forms.Button
        Me.CmdDtlPre = New System.Windows.Forms.Button
        Me.chkDelete = New System.Windows.Forms.CheckBox
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
        Me.tpMPM00001_3 = New System.Windows.Forms.TabPage
        Me.grdSummary = New System.Windows.Forms.DataGridView
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.btcMPM00001.SuspendLayout()
        Me.tpMPM00001_1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbPri.SuspendLayout()
        Me.tpMPM00001_2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.tpMPM00001_3.SuspendLayout()
        CType(Me.grdSummary, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'txtPONo
        '
        Me.txtPONo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPONo.Location = New System.Drawing.Point(53, 35)
        Me.txtPONo.MaxLength = 10
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.Size = New System.Drawing.Size(119, 20)
        Me.txtPONo.TabIndex = 4
        '
        'lblQutNo
        '
        Me.lblQutNo.AutoSize = True
        Me.lblQutNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblQutNo.ForeColor = System.Drawing.Color.Red
        Me.lblQutNo.Location = New System.Drawing.Point(6, 37)
        Me.lblQutNo.Name = "lblQutNo"
        Me.lblQutNo.Size = New System.Drawing.Size(44, 13)
        Me.lblQutNo.TabIndex = 263
        Me.lblQutNo.Text = "MPO # "
        '
        'DTRvsDat
        '
        Me.DTRvsDat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.DTRvsDat.Location = New System.Drawing.Point(438, 36)
        Me.DTRvsDat.MaxLength = 10
        Me.DTRvsDat.Name = "DTRvsDat"
        Me.DTRvsDat.Size = New System.Drawing.Size(74, 20)
        Me.DTRvsDat.TabIndex = 6
        '
        'lblRvsDat
        '
        Me.lblRvsDat.AutoSize = True
        Me.lblRvsDat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblRvsDat.Location = New System.Drawing.Point(363, 36)
        Me.lblRvsDat.Name = "lblRvsDat"
        Me.lblRvsDat.Size = New System.Drawing.Size(69, 13)
        Me.lblRvsDat.TabIndex = 267
        Me.lblRvsDat.Text = "Revise Date:"
        '
        'DTIssDat
        '
        Me.DTIssDat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.DTIssDat.Location = New System.Drawing.Point(288, 35)
        Me.DTIssDat.MaxLength = 10
        Me.DTIssDat.Name = "DTIssDat"
        Me.DTIssDat.Size = New System.Drawing.Size(74, 20)
        Me.DTIssDat.TabIndex = 5
        '
        'lblIssDat
        '
        Me.lblIssDat.AutoSize = True
        Me.lblIssDat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblIssDat.Location = New System.Drawing.Point(223, 35)
        Me.lblIssDat.Name = "lblIssDat"
        Me.lblIssDat.Size = New System.Drawing.Size(61, 13)
        Me.lblIssDat.TabIndex = 266
        Me.lblIssDat.Text = "Issue Date:"
        '
        'lblQutSts
        '
        Me.lblQutSts.AutoSize = True
        Me.lblQutSts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblQutSts.Location = New System.Drawing.Point(696, 39)
        Me.lblQutSts.Name = "lblQutSts"
        Me.lblQutSts.Size = New System.Drawing.Size(67, 13)
        Me.lblQutSts.TabIndex = 275
        Me.lblQutSts.Text = "MPO Status:"
        '
        'cboPOStatus
        '
        Me.cboPOStatus.Enabled = False
        Me.cboPOStatus.FormattingEnabled = True
        Me.cboPOStatus.Location = New System.Drawing.Point(770, 35)
        Me.cboPOStatus.Name = "cboPOStatus"
        Me.cboPOStatus.Size = New System.Drawing.Size(113, 23)
        Me.cboPOStatus.TabIndex = 3
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
        'btcMPM00001
        '
        Me.btcMPM00001.Controls.Add(Me.tpMPM00001_1)
        Me.btcMPM00001.Controls.Add(Me.tpMPM00001_2)
        Me.btcMPM00001.Controls.Add(Me.tpMPM00001_3)
        Me.btcMPM00001.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.btcMPM00001.Location = New System.Drawing.Point(0, 62)
        Me.btcMPM00001.Name = "btcMPM00001"
        Me.btcMPM00001.SelectedIndex = 0
        Me.btcMPM00001.Size = New System.Drawing.Size(993, 664)
        Me.btcMPM00001.TabIndex = 44
        '
        'tpMPM00001_1
        '
        Me.tpMPM00001_1.Controls.Add(Me.GroupBox2)
        Me.tpMPM00001_1.Location = New System.Drawing.Point(4, 24)
        Me.tpMPM00001_1.Name = "tpMPM00001_1"
        Me.tpMPM00001_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMPM00001_1.Size = New System.Drawing.Size(985, 636)
        Me.tpMPM00001_1.TabIndex = 0
        Me.tpMPM00001_1.Text = "(1) Header"
        Me.tpMPM00001_1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtRmk)
        Me.GroupBox2.Controls.Add(Me.txtPst)
        Me.GroupBox2.Controls.Add(Me.cboPorCtp)
        Me.GroupBox2.Controls.Add(Me.txtCty)
        Me.GroupBox2.Controls.Add(Me.txtStt)
        Me.GroupBox2.Controls.Add(Me.txtRemAddr)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cboVenAddr)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cboVenNo)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.gbPri)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(869, 408)
        Me.GroupBox2.TabIndex = 266
        Me.GroupBox2.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(13, 325)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 15)
        Me.Label15.TabIndex = 288
        Me.Label15.Text = "Remark :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 118)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 15)
        Me.Label9.TabIndex = 287
        Me.Label9.Text = " ZIP / Postal Code : "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 148)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 15)
        Me.Label8.TabIndex = 286
        Me.Label8.Text = "Contact Person :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(211, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 15)
        Me.Label7.TabIndex = 285
        Me.Label7.Text = "Country:"
        '
        'txtRmk
        '
        Me.txtRmk.Location = New System.Drawing.Point(118, 330)
        Me.txtRmk.Name = "txtRmk"
        Me.txtRmk.Size = New System.Drawing.Size(684, 65)
        Me.txtRmk.TabIndex = 16
        Me.txtRmk.Text = ""
        '
        'txtPst
        '
        Me.txtPst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPst.Location = New System.Drawing.Point(118, 132)
        Me.txtPst.MaxLength = 20
        Me.txtPst.Name = "txtPst"
        Me.txtPst.Size = New System.Drawing.Size(81, 20)
        Me.txtPst.TabIndex = 6
        '
        'cboPorCtp
        '
        Me.cboPorCtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboPorCtp.FormattingEnabled = True
        Me.cboPorCtp.Location = New System.Drawing.Point(118, 156)
        Me.cboPorCtp.Name = "cboPorCtp"
        Me.cboPorCtp.Size = New System.Drawing.Size(258, 21)
        Me.cboPorCtp.TabIndex = 7
        '
        'txtCty
        '
        Me.txtCty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCty.Location = New System.Drawing.Point(268, 110)
        Me.txtCty.MaxLength = 20
        Me.txtCty.Name = "txtCty"
        Me.txtCty.Size = New System.Drawing.Size(144, 20)
        Me.txtCty.TabIndex = 5
        '
        'txtStt
        '
        Me.txtStt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtStt.Location = New System.Drawing.Point(118, 109)
        Me.txtStt.MaxLength = 20
        Me.txtStt.Name = "txtStt"
        Me.txtStt.Size = New System.Drawing.Size(81, 20)
        Me.txtStt.TabIndex = 4
        '
        'txtRemAddr
        '
        Me.txtRemAddr.Location = New System.Drawing.Point(118, 65)
        Me.txtRemAddr.Name = "txtRemAddr"
        Me.txtRemAddr.Size = New System.Drawing.Size(293, 41)
        Me.txtRemAddr.TabIndex = 3
        Me.txtRemAddr.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 30)
        Me.Label4.TabIndex = 278
        Me.Label4.Text = "Remittance " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Address :"
        '
        'cboVenAddr
        '
        Me.cboVenAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboVenAddr.FormattingEnabled = True
        Me.cboVenAddr.Location = New System.Drawing.Point(118, 39)
        Me.cboVenAddr.Name = "cboVenAddr"
        Me.cboVenAddr.Size = New System.Drawing.Size(293, 21)
        Me.cboVenAddr.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 15)
        Me.Label2.TabIndex = 276
        Me.Label2.Text = "State / Province :"
        '
        'cboVenNo
        '
        Me.cboVenNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboVenNo.FormattingEnabled = True
        Me.cboVenNo.Location = New System.Drawing.Point(118, 14)
        Me.cboVenNo.Name = "cboVenNo"
        Me.cboVenNo.Size = New System.Drawing.Size(293, 21)
        Me.cboVenNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 15)
        Me.Label1.TabIndex = 269
        Me.Label1.Text = "Vendor # :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtNetAmt)
        Me.GroupBox1.Controls.Add(Me.txtCur2)
        Me.GroupBox1.Controls.Add(Me.txtDiscnt)
        Me.GroupBox1.Controls.Add(Me.txtTtlAmt)
        Me.GroupBox1.Controls.Add(Me.cbopayTrm)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboPrcTrm)
        Me.GroupBox1.Controls.Add(Me.txtCur1)
        Me.GroupBox1.Location = New System.Drawing.Point(443, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(374, 170)
        Me.GroupBox1.TabIndex = 267
        Me.GroupBox1.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 119)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 15)
        Me.Label13.TabIndex = 293
        Me.Label13.Text = "Net Amount :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 95)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 15)
        Me.Label12.TabIndex = 292
        Me.Label12.Text = "Discount % :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 73)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 15)
        Me.Label11.TabIndex = 291
        Me.Label11.Text = "Total Amount :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 15)
        Me.Label10.TabIndex = 290
        Me.Label10.Text = "Payment Term :"
        '
        'txtNetAmt
        '
        Me.txtNetAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtNetAmt.Location = New System.Drawing.Point(188, 119)
        Me.txtNetAmt.MaxLength = 20
        Me.txtNetAmt.Name = "txtNetAmt"
        Me.txtNetAmt.Size = New System.Drawing.Size(115, 20)
        Me.txtNetAmt.TabIndex = 289
        '
        'txtCur2
        '
        Me.txtCur2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCur2.Location = New System.Drawing.Point(123, 119)
        Me.txtCur2.MaxLength = 20
        Me.txtCur2.Name = "txtCur2"
        Me.txtCur2.Size = New System.Drawing.Size(59, 20)
        Me.txtCur2.TabIndex = 12
        '
        'txtDiscnt
        '
        Me.txtDiscnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtDiscnt.Location = New System.Drawing.Point(123, 95)
        Me.txtDiscnt.MaxLength = 20
        Me.txtDiscnt.Name = "txtDiscnt"
        Me.txtDiscnt.Size = New System.Drawing.Size(59, 20)
        Me.txtDiscnt.TabIndex = 11
        '
        'txtTtlAmt
        '
        Me.txtTtlAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTtlAmt.Location = New System.Drawing.Point(188, 71)
        Me.txtTtlAmt.MaxLength = 20
        Me.txtTtlAmt.Name = "txtTtlAmt"
        Me.txtTtlAmt.Size = New System.Drawing.Size(115, 20)
        Me.txtTtlAmt.TabIndex = 285
        '
        'cbopayTrm
        '
        Me.cbopayTrm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cbopayTrm.FormattingEnabled = True
        Me.cbopayTrm.Location = New System.Drawing.Point(123, 41)
        Me.cbopayTrm.Name = "cbopayTrm"
        Me.cbopayTrm.Size = New System.Drawing.Size(237, 21)
        Me.cbopayTrm.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 15)
        Me.Label5.TabIndex = 283
        Me.Label5.Text = "Price Term :"
        '
        'cboPrcTrm
        '
        Me.cboPrcTrm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboPrcTrm.FormattingEnabled = True
        Me.cboPrcTrm.Location = New System.Drawing.Point(123, 15)
        Me.cboPrcTrm.Name = "cboPrcTrm"
        Me.cboPrcTrm.Size = New System.Drawing.Size(237, 21)
        Me.cboPrcTrm.TabIndex = 8
        '
        'txtCur1
        '
        Me.txtCur1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCur1.Location = New System.Drawing.Point(123, 71)
        Me.txtCur1.MaxLength = 20
        Me.txtCur1.Name = "txtCur1"
        Me.txtCur1.Size = New System.Drawing.Size(59, 20)
        Me.txtCur1.TabIndex = 10
        '
        'gbPri
        '
        Me.gbPri.Controls.Add(Me.Label14)
        Me.gbPri.Controls.Add(Me.Label6)
        Me.gbPri.Controls.Add(Me.Label3)
        Me.gbPri.Controls.Add(Me.txtshpplc)
        Me.gbPri.Controls.Add(Me.cboImpCnt)
        Me.gbPri.Controls.Add(Me.txtShpAdr)
        Me.gbPri.Location = New System.Drawing.Point(6, 183)
        Me.gbPri.Name = "gbPri"
        Me.gbPri.Size = New System.Drawing.Size(811, 135)
        Me.gbPri.TabIndex = 266
        Me.gbPri.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 67)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(102, 15)
        Me.Label14.TabIndex = 287
        Me.Label14.Text = "Shipping Address : "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Green
        Me.Label6.Location = New System.Drawing.Point(8, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 15)
        Me.Label6.TabIndex = 283
        Me.Label6.Text = "Delivery Place : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(8, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 15)
        Me.Label3.TabIndex = 282
        Me.Label3.Text = "Import Contract : "
        '
        'txtshpplc
        '
        Me.txtshpplc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtshpplc.Location = New System.Drawing.Point(112, 40)
        Me.txtshpplc.MaxLength = 20
        Me.txtshpplc.Name = "txtshpplc"
        Me.txtshpplc.Size = New System.Drawing.Size(105, 20)
        Me.txtshpplc.TabIndex = 14
        '
        'cboImpCnt
        '
        Me.cboImpCnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboImpCnt.FormattingEnabled = True
        Me.cboImpCnt.Location = New System.Drawing.Point(112, 15)
        Me.cboImpCnt.Name = "cboImpCnt"
        Me.cboImpCnt.Size = New System.Drawing.Size(683, 21)
        Me.cboImpCnt.TabIndex = 13
        '
        'txtShpAdr
        '
        Me.txtShpAdr.Location = New System.Drawing.Point(112, 64)
        Me.txtShpAdr.Name = "txtShpAdr"
        Me.txtShpAdr.Size = New System.Drawing.Size(683, 58)
        Me.txtShpAdr.TabIndex = 15
        Me.txtShpAdr.Text = ""
        '
        'tpMPM00001_2
        '
        Me.tpMPM00001_2.Controls.Add(Me.GroupBox3)
        Me.tpMPM00001_2.Controls.Add(Me.txtmodvol)
        Me.tpMPM00001_2.Controls.Add(Me.txtCusVen)
        Me.tpMPM00001_2.Controls.Add(Me.txtVenNo)
        Me.tpMPM00001_2.Controls.Add(Me.cboPCPrc)
        Me.tpMPM00001_2.Controls.Add(Me.optSearch1)
        Me.tpMPM00001_2.Controls.Add(Me.optSearch0)
        Me.tpMPM00001_2.Controls.Add(Me.Label30)
        Me.tpMPM00001_2.Controls.Add(Me.txtPurOrd)
        Me.tpMPM00001_2.Controls.Add(Me.txtVol)
        Me.tpMPM00001_2.Controls.Add(Me.txtColCde)
        Me.tpMPM00001_2.Controls.Add(Me.Label39)
        Me.tpMPM00001_2.Controls.Add(Me.txtMtrCtn)
        Me.tpMPM00001_2.Controls.Add(Me.Label40)
        Me.tpMPM00001_2.Controls.Add(Me.Label56)
        Me.tpMPM00001_2.Controls.Add(Me.GroupBox5)
        Me.tpMPM00001_2.Controls.Add(Me.optCtrSiz3)
        Me.tpMPM00001_2.Controls.Add(Me.optCtrSiz4)
        Me.tpMPM00001_2.Controls.Add(Me.optCtrSiz0)
        Me.tpMPM00001_2.Controls.Add(Me.optCtrSiz1)
        Me.tpMPM00001_2.Controls.Add(Me.optCtrSiz2)
        Me.tpMPM00001_2.Controls.Add(Me.txtCustUM)
        Me.tpMPM00001_2.Controls.Add(Me.Label27)
        Me.tpMPM00001_2.Location = New System.Drawing.Point(4, 22)
        Me.tpMPM00001_2.Name = "tpMPM00001_2"
        Me.tpMPM00001_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMPM00001_2.Size = New System.Drawing.Size(985, 638)
        Me.tpMPM00001_2.TabIndex = 1
        Me.tpMPM00001_2.Text = "(2) Details"
        Me.tpMPM00001_2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label33)
        Me.GroupBox3.Controls.Add(Me.Label32)
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.DTDShpDat)
        Me.GroupBox3.Controls.Add(Me.DTDOrgShpDat)
        Me.GroupBox3.Controls.Add(Me.txtSubTtlAmt)
        Me.GroupBox3.Controls.Add(Me.txtCur5)
        Me.GroupBox3.Controls.Add(Me.txtUntPrc)
        Me.GroupBox3.Controls.Add(Me.cboCurr)
        Me.GroupBox3.Controls.Add(Me.txtOrgUntPrc)
        Me.GroupBox3.Controls.Add(Me.txtCur3)
        Me.GroupBox3.Controls.Add(Me.txtOrdQty)
        Me.GroupBox3.Controls.Add(Me.cboUM)
        Me.GroupBox3.Controls.Add(Me.txtVenitm)
        Me.GroupBox3.Controls.Add(Me.dtdWTPODate)
        Me.GroupBox3.Controls.Add(Me.txtWTPONo)
        Me.GroupBox3.Controls.Add(Me.txtPurSeq)
        Me.GroupBox3.Controls.Add(Me.cboItmNo)
        Me.GroupBox3.Controls.Add(Me.txtItmNam)
        Me.GroupBox3.Controls.Add(Me.CmdDtlNext)
        Me.GroupBox3.Controls.Add(Me.CmdDtlPre)
        Me.GroupBox3.Controls.Add(Me.chkDelete)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(871, 415)
        Me.GroupBox3.TabIndex = 363
        Me.GroupBox3.TabStop = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.ForeColor = System.Drawing.Color.Red
        Me.Label33.Location = New System.Drawing.Point(410, 248)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(90, 15)
        Me.Label33.TabIndex = 365
        Me.Label33.Text = "[Reference Only]"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.ForeColor = System.Drawing.Color.Red
        Me.Label32.Location = New System.Drawing.Point(330, 318)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(90, 15)
        Me.Label32.TabIndex = 364
        Me.Label32.Text = "[Reference Only]"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(17, 318)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(210, 15)
        Me.Label31.TabIndex = 363
        Me.Label31.Text = "Orginal Delivery Date (MM/DD/YYYY) :"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(17, 296)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(82, 15)
        Me.Label28.TabIndex = 362
        Me.Label28.Text = "Total Amount :"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(17, 246)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(103, 15)
        Me.Label26.TabIndex = 361
        Me.Label26.Text = "Original Unit Price :"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(17, 141)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 15)
        Me.Label25.TabIndex = 360
        Me.Label25.Text = "Description :"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(17, 117)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(94, 15)
        Me.Label24.TabIndex = 359
        Me.Label24.Text = "Vendor Item No. :"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(17, 70)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(204, 15)
        Me.Label23.TabIndex = 358
        Me.Label23.Text = "Purchase Order Date (MM/DD/YYYY) :"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(17, 45)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(87, 15)
        Me.Label22.TabIndex = 357
        Me.Label22.Text = "Purchase Order :"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(17, 22)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(33, 15)
        Me.Label21.TabIndex = 356
        Me.Label21.Text = "Seq. :"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.ForeColor = System.Drawing.Color.Green
        Me.Label20.Location = New System.Drawing.Point(17, 340)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(218, 15)
        Me.Label20.TabIndex = 355
        Me.Label20.Text = "Grouped Delivery Date (MM/DD/YYYY) :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.ForeColor = System.Drawing.Color.Green
        Me.Label19.Location = New System.Drawing.Point(17, 275)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(108, 15)
        Me.Label19.TabIndex = 354
        Me.Label19.Text = "Grouped Unit Price :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.Green
        Me.Label18.Location = New System.Drawing.Point(17, 220)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 15)
        Me.Label18.TabIndex = 353
        Me.Label18.Text = "Order Qty. :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Green
        Me.Label17.Location = New System.Drawing.Point(17, 205)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(34, 15)
        Me.Label17.TabIndex = 352
        Me.Label17.Text = "UM :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Green
        Me.Label16.Location = New System.Drawing.Point(17, 93)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 15)
        Me.Label16.TabIndex = 351
        Me.Label16.Text = "Item No. :"
        '
        'DTDShpDat
        '
        Me.DTDShpDat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.DTDShpDat.Location = New System.Drawing.Point(238, 340)
        Me.DTDShpDat.MaxLength = 10
        Me.DTDShpDat.Name = "DTDShpDat"
        Me.DTDShpDat.Size = New System.Drawing.Size(74, 20)
        Me.DTDShpDat.TabIndex = 34
        '
        'DTDOrgShpDat
        '
        Me.DTDOrgShpDat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.DTDOrgShpDat.Location = New System.Drawing.Point(238, 316)
        Me.DTDOrgShpDat.MaxLength = 10
        Me.DTDOrgShpDat.Name = "DTDOrgShpDat"
        Me.DTDOrgShpDat.Size = New System.Drawing.Size(74, 20)
        Me.DTDOrgShpDat.TabIndex = 33
        '
        'txtSubTtlAmt
        '
        Me.txtSubTtlAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSubTtlAmt.Location = New System.Drawing.Point(301, 294)
        Me.txtSubTtlAmt.MaxLength = 20
        Me.txtSubTtlAmt.Name = "txtSubTtlAmt"
        Me.txtSubTtlAmt.Size = New System.Drawing.Size(100, 20)
        Me.txtSubTtlAmt.TabIndex = 32
        '
        'txtCur5
        '
        Me.txtCur5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCur5.Location = New System.Drawing.Point(238, 293)
        Me.txtCur5.MaxLength = 20
        Me.txtCur5.Name = "txtCur5"
        Me.txtCur5.Size = New System.Drawing.Size(56, 20)
        Me.txtCur5.TabIndex = 31
        '
        'txtUntPrc
        '
        Me.txtUntPrc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtUntPrc.Location = New System.Drawing.Point(301, 271)
        Me.txtUntPrc.MaxLength = 20
        Me.txtUntPrc.Name = "txtUntPrc"
        Me.txtUntPrc.Size = New System.Drawing.Size(100, 20)
        Me.txtUntPrc.TabIndex = 30
        '
        'cboCurr
        '
        Me.cboCurr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboCurr.FormattingEnabled = True
        Me.cboCurr.Location = New System.Drawing.Point(238, 269)
        Me.cboCurr.Name = "cboCurr"
        Me.cboCurr.Size = New System.Drawing.Size(55, 21)
        Me.cboCurr.TabIndex = 29
        '
        'txtOrgUntPrc
        '
        Me.txtOrgUntPrc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtOrgUntPrc.Location = New System.Drawing.Point(301, 248)
        Me.txtOrgUntPrc.MaxLength = 20
        Me.txtOrgUntPrc.Name = "txtOrgUntPrc"
        Me.txtOrgUntPrc.Size = New System.Drawing.Size(100, 20)
        Me.txtOrgUntPrc.TabIndex = 28
        '
        'txtCur3
        '
        Me.txtCur3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCur3.Location = New System.Drawing.Point(238, 246)
        Me.txtCur3.MaxLength = 20
        Me.txtCur3.Name = "txtCur3"
        Me.txtCur3.Size = New System.Drawing.Size(56, 20)
        Me.txtCur3.TabIndex = 27
        '
        'txtOrdQty
        '
        Me.txtOrdQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtOrdQty.Location = New System.Drawing.Point(238, 223)
        Me.txtOrdQty.MaxLength = 20
        Me.txtOrdQty.Name = "txtOrdQty"
        Me.txtOrdQty.Size = New System.Drawing.Size(61, 20)
        Me.txtOrdQty.TabIndex = 26
        '
        'cboUM
        '
        Me.cboUM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboUM.FormattingEnabled = True
        Me.cboUM.Location = New System.Drawing.Point(238, 199)
        Me.cboUM.Name = "cboUM"
        Me.cboUM.Size = New System.Drawing.Size(60, 21)
        Me.cboUM.TabIndex = 25
        '
        'txtVenitm
        '
        Me.txtVenitm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtVenitm.Location = New System.Drawing.Point(238, 115)
        Me.txtVenitm.MaxLength = 20
        Me.txtVenitm.Name = "txtVenitm"
        Me.txtVenitm.Size = New System.Drawing.Size(488, 20)
        Me.txtVenitm.TabIndex = 23
        '
        'dtdWTPODate
        '
        Me.dtdWTPODate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtdWTPODate.Location = New System.Drawing.Point(238, 68)
        Me.dtdWTPODate.MaxLength = 10
        Me.dtdWTPODate.Name = "dtdWTPODate"
        Me.dtdWTPODate.Size = New System.Drawing.Size(74, 20)
        Me.dtdWTPODate.TabIndex = 21
        '
        'txtWTPONo
        '
        Me.txtWTPONo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtWTPONo.Location = New System.Drawing.Point(238, 45)
        Me.txtWTPONo.MaxLength = 20
        Me.txtWTPONo.Name = "txtWTPONo"
        Me.txtWTPONo.Size = New System.Drawing.Size(110, 20)
        Me.txtWTPONo.TabIndex = 20
        '
        'txtPurSeq
        '
        Me.txtPurSeq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPurSeq.Location = New System.Drawing.Point(238, 22)
        Me.txtPurSeq.MaxLength = 20
        Me.txtPurSeq.Name = "txtPurSeq"
        Me.txtPurSeq.Size = New System.Drawing.Size(61, 20)
        Me.txtPurSeq.TabIndex = 19
        '
        'cboItmNo
        '
        Me.cboItmNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboItmNo.FormattingEnabled = True
        Me.cboItmNo.Location = New System.Drawing.Point(238, 91)
        Me.cboItmNo.Name = "cboItmNo"
        Me.cboItmNo.Size = New System.Drawing.Size(487, 21)
        Me.cboItmNo.TabIndex = 22
        '
        'txtItmNam
        '
        Me.txtItmNam.Location = New System.Drawing.Point(238, 138)
        Me.txtItmNam.Name = "txtItmNam"
        Me.txtItmNam.Size = New System.Drawing.Size(489, 58)
        Me.txtItmNam.TabIndex = 24
        Me.txtItmNam.Text = ""
        '
        'CmdDtlNext
        '
        Me.CmdDtlNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CmdDtlNext.Location = New System.Drawing.Point(718, 366)
        Me.CmdDtlNext.Name = "CmdDtlNext"
        Me.CmdDtlNext.Size = New System.Drawing.Size(51, 27)
        Me.CmdDtlNext.TabIndex = 336
        Me.CmdDtlNext.TabStop = False
        Me.CmdDtlNext.Text = "&Next"
        '
        'CmdDtlPre
        '
        Me.CmdDtlPre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CmdDtlPre.Location = New System.Drawing.Point(665, 366)
        Me.CmdDtlPre.Name = "CmdDtlPre"
        Me.CmdDtlPre.Size = New System.Drawing.Size(51, 27)
        Me.CmdDtlPre.TabIndex = 335
        Me.CmdDtlPre.TabStop = False
        Me.CmdDtlPre.Text = "&Back"
        '
        'chkDelete
        '
        Me.chkDelete.AutoSize = True
        Me.chkDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkDelete.Location = New System.Drawing.Point(671, 20)
        Me.chkDelete.Name = "chkDelete"
        Me.chkDelete.Size = New System.Drawing.Size(149, 17)
        Me.chkDelete.TabIndex = 337
        Me.chkDelete.Text = "Delete (Checked if delete)"
        Me.chkDelete.UseVisualStyleBackColor = True
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
        'tpMPM00001_3
        '
        Me.tpMPM00001_3.Controls.Add(Me.grdSummary)
        Me.tpMPM00001_3.Location = New System.Drawing.Point(4, 22)
        Me.tpMPM00001_3.Name = "tpMPM00001_3"
        Me.tpMPM00001_3.Size = New System.Drawing.Size(985, 638)
        Me.tpMPM00001_3.TabIndex = 2
        Me.tpMPM00001_3.Text = "(3) Summary"
        Me.tpMPM00001_3.UseVisualStyleBackColor = True
        '
        'grdSummary
        '
        Me.grdSummary.AllowUserToAddRows = False
        Me.grdSummary.AllowUserToDeleteRows = False
        Me.grdSummary.ColumnHeadersHeight = 20
        Me.grdSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdSummary.Location = New System.Drawing.Point(10, 14)
        Me.grdSummary.Name = "grdSummary"
        Me.grdSummary.RowHeadersWidth = 20
        Me.grdSummary.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdSummary.RowTemplate.Height = 16
        Me.grdSummary.Size = New System.Drawing.Size(866, 397)
        Me.grdSummary.TabIndex = 367
        '
        'MPM00001
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(892, 536)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.btcMPM00001)
        Me.Controls.Add(Me.cboPOStatus)
        Me.Controls.Add(Me.DTRvsDat)
        Me.Controls.Add(Me.lblQutSts)
        Me.Controls.Add(Me.lblRvsDat)
        Me.Controls.Add(Me.DTIssDat)
        Me.Controls.Add(Me.lblIssDat)
        Me.Controls.Add(Me.txtPONo)
        Me.Controls.Add(Me.lblQutNo)
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
        Me.Name = "MPM00001"
        Me.Text = "MPM00001 - Manufacturing Purchase Order Maintenance"
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.btcMPM00001.ResumeLayout(False)
        Me.tpMPM00001_1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbPri.ResumeLayout(False)
        Me.gbPri.PerformLayout()
        Me.tpMPM00001_2.ResumeLayout(False)
        Me.tpMPM00001_2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.tpMPM00001_3.ResumeLayout(False)
        CType(Me.grdSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region




    Private Sub fillcboItmNo()
        If rs_ZSITMLST.Tables("result").Rows.Count <> 0 Then
            rs_ZSITMLST.Tables("result").DefaultView.RowFilter = ""
            rs_ZSITMLST.Tables("result").DefaultView.Sort = "Zil_ItmNo"

            For index As Integer = 0 To rs_ZSITMLST.Tables("RESULT").DefaultView.Count - 1
                cboItmNo.Items.Add(rs_ZSITMLST.Tables("RESULT").DefaultView(index)("Zil_ItmNo") & " - " & rs_ZSITMLST.Tables("RESULT").DefaultView(index)("Zil_ItmNam"))
            Next

        End If
    End Sub
    Private Sub fillcboImpCnt()

        If rs_GRNVENINF.Tables("result").Rows.Count <> 0 Then
            rs_GRNVENINF.Tables("result").DefaultView.RowFilter = ""
            For index As Integer = 0 To rs_GRNVENINF.Tables("RESULT").DefaultView.Count - 1
                cboImpCnt.Items.Add(rs_GRNVENINF.Tables("RESULT").DefaultView(index)("gvi_invven") & " - " & rs_GRNVENINF.Tables("RESULT").DefaultView(index)("gvi_vennam"))
            Next
        End If
    End Sub
    Private Sub fillcboPrcTrm()
        rs_SYSETINF.Tables("result").DefaultView.RowFilter = "ysi_typ ='03'"
        If rs_SYSETINF.Tables("result").DefaultView.Count <> 0 Then
            rs_SYSETINF.Tables("result").DefaultView.Sort = "ysi_cde"

            For index As Integer = 0 To rs_SYSETINF.Tables("RESULT").DefaultView.Count - 1
                cboPrcTrm.Items.Add(rs_SYSETINF.Tables("RESULT").DefaultView(index)("ysi_cde") & " - " & rs_SYSETINF.Tables("RESULT").DefaultView(index)("ysi_dsc"))
            Next
        End If
    End Sub
    Private Sub fillcboPayTrm()

        rs_SYSETINF.Tables("result").DefaultView.RowFilter = "ysi_typ ='04'"
        If rs_SYSETINF.Tables("result").DefaultView.Count <> 0 Then
            rs_SYSETINF.Tables("result").DefaultView.Sort = "ysi_cde"

            For index As Integer = 0 To rs_SYSETINF.Tables("RESULT").DefaultView.Count - 1
                cbopayTrm.Items.Add(rs_SYSETINF.Tables("RESULT").DefaultView(index)("ysi_cde") & " - " & rs_SYSETINF.Tables("RESULT").DefaultView(index)("ysi_dsc"))
            Next
        End If


    End Sub
    Private Sub Display()
        '*************Hearder**************************
        txtPONo.Text = rs_MPORDHDR.Tables("result").Rows(0)("mph_mpono")



        DTIssDat.Text = Format(rs_MPORDHDR.Tables("result").Rows(0)("mph_credat"), "MM/dd/yyyy")   '--- Issue Date
        DTRvsDat.Text = Format(rs_MPORDHDR.Tables("result").Rows(0)("mph_upddat"), "MM/dd/yyyy")   '--- Revise Date
        Call display_combo(rs_MPORDHDR.Tables("result").Rows(0)("mph_mposts"), cboPOStatus)
        Call chkstatus()

        'cboVenNo.Text = rs_MPORDHDR.tables("result").rows(0)("mph_venno") & " - " & rs_MPORDHDR.tables("result").rows(0)("vbi_vensna")
        Call display_combo(rs_MPORDHDR.Tables("result").Rows(0)("mph_venno"), cboVenNo)


        'If AllowUpdate = False Then
        '    cboVenNo.Enabled = False '-- Lock if record in update mode
        'End If


        Call Display_VenAddr()
        '--------------------
        txtRemAddr.Text = rs_MPORDHDR.Tables("result").Rows(0)("mph_venadr")
        txtStt.Text = rs_MPORDHDR.Tables("result").Rows(0)("mph_venstt")

        rs_SYSETINF.Tables("result").DefaultView.RowFilter = "ysi_typ ='02' and ysi_cde ='" & rs_MPORDHDR.Tables("result").Rows(0)("mph_vencty") & "'"
        If rs_SYSETINF.Tables("result").DefaultView.Count <> 0 Then
            txtCty.Text = rs_MPORDHDR.Tables("result").Rows(0)("mph_vencty") & " - " & rs_SYSETINF.Tables("result").DefaultView(0)("ysi_dsc")
            'temp
        End If
        txtPst.Text = rs_MPORDHDR.Tables("result").Rows(0)("mph_venpst")


        Call display_combo(rs_MPORDHDR.Tables("result").Rows(0)("mph_prctrm"), cboPrcTrm)
        Call display_combo(rs_MPORDHDR.Tables("result").Rows(0)("mph_paytrm"), cbopayTrm)

        txtCur1.Text = rs_MPORDHDR.Tables("result").Rows(0)("mph_curr")
        txtCur2.Text = rs_MPORDHDR.Tables("result").Rows(0)("mph_curr")

        txtNetAmt.Text = Format(CDbl(rs_MPORDHDR.Tables("result").Rows(0)("mph_netamt")), "#####.00")

        txtRmk.Text = rs_MPORDHDR.Tables("result").Rows(0)("mph_rmk")
        txtshpplc.Text = rs_MPORDHDR.Tables("result").Rows(0)("mph_shpplc")
        txtShpAdr.Text = rs_MPORDHDR.Tables("result").Rows(0)("mph_shpadr")


        ''''''''''''''''''Detail'''''''''''''''''''''''''''''''
        '
        If rs_MPORDDTL.Tables("result").Rows.Count > 0 Then
            '            rs_MPORDDTL.MoveFirst()
            Call DisplayPODetail()

            If readingindex + 1 <> rs_MPORDDTL.Tables("result").Rows.Count Then
                CmdDtlNext.Enabled = True
            Else
                CmdDtlNext.Enabled = False
            End If

        End If
        '
        txtDiscnt.Text = rs_MPORDHDR.Tables("result").Rows(0)("mph_discnt")
        txtTtlAmt.Text = Format(rs_MPORDHDR.Tables("result").Rows(0)("mph_ttlamt"), "#####.00")

        ''''''''''''''' Display Panel ''''''''''''''''''''''''''''
        StatusBar.Panels(1).Text = Format(rs_MPORDHDR.Tables("result").Rows(0)("mph_credat"), "MM/dd/yyyy") & " " & Format(rs_MPORDHDR.Tables("result").Rows(0)("mph_upddat"), "MM/dd/yyyy") & _
                                      " " & rs_MPORDHDR.Tables("result").Rows(0)("mph_updusr")
        'temp

        'Call CalNetAmt



    End Sub

    Private Sub CalNetAmt()
        If Not rs_MPORDDTL Is Nothing Then
            If rs_MPORDDTL.Tables("result").Rows.Count > 0 Then
                Dim varBookmark As Object
                Dim tmpTtlAmt As Double
                Dim BMFlag As Boolean

                tmpTtlAmt = 0

                If Not readingindex = rs_MPORDDTL.Tables("result").Rows.Count - 1 Then
                    '                    varBookmark = rs_MPORDDTL.Bookmark
                    BMFlag = True
                Else
                    BMFlag = False
                End If
                'temp


                rs_MPORDDTL.Tables("result").DefaultView.RowFilter = "mpd_creusr <> '~*DEL*~' and mpd_creusr <> '~*NEW*~'"
                If rs_MPORDDTL.Tables("result").DefaultView.Count > 0 Then

                    For index As Integer = 0 To rs_MPORDDTL.Tables("RESULT").DefaultView.Count - 1
                        tmpTtlAmt = tmpTtlAmt + (Int((rs_MPORDDTL.Tables("result").Rows(index)("mpd_minprc") * rs_MPORDDTL.Tables("result").Rows(index)("mpd_qty") * 100) + 0.5) / 100)
                    Next

                End If
                rs_MPORDDTL.Tables("result").DefaultView.RowFilter = ""

                If BMFlag = True Then
                    '                    rs_MPORDDTL.Bookmark = varBookmark
                    'tempz
                End If


                txtTtlAmt.Text = Format(tmpTtlAmt, "#####.00")
                txtNetAmt.Text = tmpTtlAmt - (tmpTtlAmt * txtDiscnt.Text / 100)
                txtNetAmt.Text = Format(CDbl(txtNetAmt.Text.Trim), "#####.00")
            End If
        End If
    End Sub
    Private Sub DisplayPODetail()
        Dim TmpRecordstatus As Boolean

        TmpRecordstatus = Recordstatus

        If readingindex + 1 <> 1 Then
            CmdDtlPre.Enabled = True
        Else
            CmdDtlPre.Enabled = False
        End If

        If readingindex + 1 <> rs_MPORDDTL.Tables("result").Rows.Count Then
            CmdDtlNext.Enabled = True
        Else
            CmdDtlNext.Enabled = False
        End If

        If readingindex > rs_MPORDDTL.Tables("result").Rows.Count - 1 Then
            Exit Sub
        End If
        txtPurSeq.Text = rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_mposeq")
        txtWTPONo.Text = rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_pono")
        dtdWTPODate.Text = Format(rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_podat"), "MM/dd/yyyy")
        Call display_combo(rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_itmno"), cboItmNo)

        txtItmNam.Text = rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_itmnam")
        'temp
        txtVenitm.Text = rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_venitm")


        'txtUM.Text = rs_MPORDDTL.Tables("result").ROWS(READINGINDEX)("mpd_um")
        If rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_um") <> "" Then
            cboUM.Text = rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_um")
        End If
        txtOrdQty.Text = rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_qty")
        txtUntPrc.Text = Format(rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_minprc"), "#####.0000")
        txtOrgUntPrc.Text = Format(rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_untprc"), "#####.0000")
        txtSubTtlAmt.Text = Format(rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_qty") * rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_minprc"), "#####.00")
        txtCur3.Text = rs_MPORDDTL.Tables("result").Rows(readingindex)("mph_curr")
        If rs_MPORDDTL.Tables("result").Rows(readingindex)("mph_curr") <> "" Then
            cboCurr.Text = rs_MPORDDTL.Tables("result").Rows(readingindex)("mph_curr")
        End If
        txtCur5.Text = rs_MPORDDTL.Tables("result").Rows(readingindex)("mph_curr")
        DTDShpDat.Text = Format(rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_shpdat"), "MM/dd/yyyy")
        DTDOrgShpDat.Text = Format(rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_orgshpdat"), "MM/dd/yyyy")

        If rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_creusr") = "~*DEL*~" Or rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_creusr") = "~*NEW*~" Then
            chkDelete.Checked = True
        Else
            chkDelete.Checked = False
        End If


        If AllowUpdate = True Then
            'Anita request not allowed to amend item no.
            cboItmNo.Enabled = False
            If rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_shpqty") <> 0 Then
                cboUM.Enabled = False
                '    cboItmNo.Enabled = False
            Else
                cboUM.Enabled = True
                '    cboItmNo.Enabled = True

            End If
            Label19.Visible = False
            txtCur3.Visible = False
            txtOrgUntPrc.Visible = False
            Label27.Visible = False
            Label33.Visible = False
            DTDOrgShpDat.Visible = False
            Label32.Visible = False
        Else
            Label19.Visible = True
            txtCur3.Visible = True
            txtOrgUntPrc.Visible = True
            Label27.Visible = True
            Label33.Visible = True
            DTDOrgShpDat.Visible = True
            Label32.Visible = True
        End If

        Recordstatus = TmpRecordstatus

    End Sub
    Private Sub ClearScreen()

        '*************Header**************************
        DTIssDat.Text = Format(Date.Today, "MM/dd/yyyy").ToString
        DTRvsDat.Text = Format(Date.Today, "MM/dd/yyyy").ToString
        Call display_combo("", cboPOStatus)

        cboPOStatus.SelectedIndex = -1


        'txtVendor.Text = ""
        txtRemAddr.Text = ""

        cboPorCtp.Items.Clear()


        txtDiscnt.Text = ""
        txtTtlAmt.Text = ""

        txtNetAmt.Text = ""

        txtCur1.Text = ""
        txtCur2.Text = ""
        txtShpAdr.Text = ""
        txtStt.Text = ""
        txtCty.Text = ""
        txtPst.Text = ""
        'txtLblDue.Text = Format(Date.Today, "MM/dd/yyyy").ToString
        txtRmk.Text = ""
        DTIssDat.Text = Format(Date.Today, "MM/dd/yyyy").ToString
        DTRvsDat.Text = Format(Date.Today, "MM/dd/yyyy").ToString
        cboPOStatus.Text = ""
        'txtVendor.Text = ""
        txtRemAddr.Text = ""
        'cboPrcTrm.Text = ""
        'cboPayTrm.Text = ""
        txtNetAmt.Text = 0
        'txtImpFty.Text = ""
        txtShpAdr.Text = ""
        txtshpplc.Text = ""


    End Sub

    Private Sub setStatus(ByVal Mode As String)
        'Private Sub setStatus(Mode As String, Optional rs As New DataSet)

        If Mode = "Init" Then
            readingindex = 0
            rs_MPORDHDR = Nothing
            rs_MPORDDTL = Nothing
            'tempz

            ErrFlag = False
            Add_flag = False
            find_flag = False
            btcMPM00001.SelectedIndex = 0
            btcMPM00001.Enabled = False
            ' DoEvents()
            Call SetStatusBar(Mode)
            ' DoEvents()
            cmdAdd.Enabled = Enq_right_local
            cmdSave.Enabled = Enq_right_local
            cmdCopy.Enabled = False
            cmdInsRow.Enabled = False
            cboVenNo.Enabled = True
            'cboVenNo.Clear
            cmdDelete.Enabled = False
            cmdDelRow.Enabled = False
            cmdFind.Enabled = True
            CmdLookup.Enabled = True
            cmdExit.Enabled = True
            cmdClear.Enabled = True
            cmdSearch.Enabled = True
            cmdspecial.Enabled = True
            cmdbrowlist.Enabled = True
            cmdFirst.Enabled = False
            cmdLast.Enabled = False
            cmdDelRow.Enabled = False
            cmdNext.Enabled = False
            cmdPrv.Enabled = False
            CmdDtlPre.Enabled = False
            CmdDtlNext.Enabled = False
            txtPONo.Enabled = True
            AllowUpdate = True
            cboVenAddr.Items.Clear()
            cboPrcTrm.Enabled = False

            cboPrcTrm.SelectedIndex = -1

            cbopayTrm.SelectedIndex = -1
            cboImpCnt.SelectedIndex = -1
            cboItmNo.SelectedIndex = -1
            cboVenNo.SelectedIndex = -1
            cboUM.SelectedIndex = -1

            Recordstatus = False
            chkDelete.Enabled = False
            cmdSave.Enabled = False
            MaxSeq = 0

            Label19.Text = "Grouped Unit Price :"
            Label20.Text = "Grouped Delivery Date (MM/DD/YYYY) :"



            chkDelete.Checked = False
            txtPurSeq.Text = "0"
            txtWTPONo.Text = ""
            dtdWTPODate.Text = "  /  /    "
            txtVenitm.Text = ""
            txtItmNam.Text = ""
            'txtUM.Text = ""
            txtOrdQty.Text = "0"
            txtCur3.Text = ""

            cboCurr.SelectedIndex = -1
            txtCur5.Text = ""
            txtOrgUntPrc.Text = "0"
            txtUntPrc.Text = "0"
            txtSubTtlAmt.Text = "0"
            DTDShpDat.Text = "  /  /    "
            DTDOrgShpDat.Text = "  /  /    "

            txtRemAddr.Text = ""
            cboPorCtp.Text = ""
            cboVenAddr.Text = ""


            Recordstatus = False




            Call ClearScreen()
            ' DoEvents()

        ElseIf Mode = "Updating" Then
            cboPOStatus.Enabled = False
            cboVenNo.Enabled = False
            cboVenAddr.Enabled = False
            txtRemAddr.Enabled = False
            txtStt.Enabled = False
            txtCty.Enabled = False
            txtPst.Enabled = False
            cboImpCnt.Enabled = False
            txtshpplc.Enabled = False
            txtDiscnt.Enabled = False




            cmdFind.Enabled = False
            cmdSearch.Enabled = False
            txtPONo.Enabled = False
            btcMPM00001.Enabled = True
            ' User Request to release discount field for update at 21/07/2003
            If gsUsrRank <= 4 Then
                txtDiscnt.Enabled = True
            End If
            If AllowUpdate = True Then
                cmdInsRow.Enabled = Enq_right_local 'True '*** Access Right used  - added by Tommy on 10 March 2002
            Else
                cmdInsRow.Enabled = False
                txtDiscnt.Enabled = False
                dtdWTPODate.Enabled = False
                DTDShpDat.Enabled = False
                DTDOrgShpDat.Enabled = False
            End If

            If rs_MPORDDTL.Tables("result").Rows.Count > 0 Then
                cmdDelRow.Enabled = Del_right_local 'True '*** Access Right used  - added by Tommy on 10 March 2002
                chkDelete.Enabled = Del_right_local
            Else
                cmdDelRow.Enabled = False
                chkDelete.Enabled = False
            End If

            cmdSave.Enabled = Enq_right_local 'True '*** Access Right used  - added by Tommy on 10 March 2002
            Call SetStatusBar(Mode)

        ElseIf Mode = "Save" Then
            Call SetStatusBar(Mode)
            Call setStatus("Init")
            'MsgBox("Record Saved!")
            Call setFocus_text(txtPONo)

            Call ClearScreen()

        ElseIf Mode = "Clear" Then
            Call SetStatusBar(Mode)
            Call ClearScreen()

        ElseIf Mode = "ADD" Then
            Call SetStatusBar(Mode)
            Label19.Text = "Unit Price :"
            Label18.Refresh()
            Label20.Text = "Delivery Date (MM/DD/YYYY) :"
            Label22.Refresh()
            cmdFind.Enabled = False
            cmdAdd.Enabled = False
            txtPONo.Text = ""
            txtPONo.Refresh()
            txtPONo.Enabled = False
            MaxSeq = 0
            txtTtlAmt.Text = "0"
            txtDiscnt.Text = "0"
            txtNetAmt.Text = "0"
            AllowUpdate = True
            cboPOStatus.SelectedIndex = 0
            btcMPM00001.Enabled = True

            '            txtRmk.ReadOnly = True
            'temp
            ' Added by Mark Lau 20090729
            '            txtRmk.readonly = False
        End If

        chkstatus()
    End Sub


    Private Sub SetStatusBar(ByVal Mode As String)

        If Mode = "Init" Then
            StatusBar.Panels(0).Text = "Please Enter a PO No."
            'Add your codes here

        ElseIf Mode = "ADD" Then
            StatusBar.Panels(0).Text = "ADD"
            'Add your codes here

        ElseIf Mode = "Updating" Then
            StatusBar.Panels(0).Text = "Updating"
            'Add your codes here

        ElseIf Mode = "Save" Then
            StatusBar.Panels(0).Text = "Record Saved"
            'Add your codes here

        ElseIf Mode = "Delete" Then
            StatusBar.Panels(0).Text = "Record Deleted"
            'Add your codes here

        ElseIf Mode = "ReadOnly" Then
            StatusBar.Panels(0).Text = "Read Only"
            'Add your codes here
        ElseIf Mode = "Clear" Then
            StatusBar.Panels(0).Text = "Clear Screen"
            'Add your codes here
        End If
    End Sub

    Private Sub chkstatus()

        If cboPOStatus.SelectedIndex <> 0 Then
            ' Header
            DTRvsDat.Enabled = False
            DTIssDat.Enabled = False
            cboVenNo.Enabled = False
            cboVenAddr.Enabled = False
            txtRemAddr.Enabled = False
            txtStt.Enabled = False
            txtCty.Enabled = False
            txtPst.Enabled = False
            cboPorCtp.Enabled = False
            cboImpCnt.Enabled = False
            txtshpplc.Enabled = False
            txtShpAdr.Enabled = False
            txtRmk.Enabled = False
            cboPrcTrm.Enabled = False
            cboPrcTrm.Enabled = False
            txtCur1.Enabled = False
            txtCur2.Enabled = False
            txtDiscnt.Enabled = False
            txtNetAmt.Enabled = False
            txtTtlAmt.Enabled = False

            ' Details
            chkDelete.Enabled = False
            txtPurSeq.Enabled = False
            txtWTPONo.Enabled = False
            dtdWTPODate.Enabled = False
            cboItmNo.Enabled = False
            txtVenitm.Enabled = False
            txtItmNam.Enabled = False
            'txtUM.Enabled = False
            cboUM.Enabled = False
            txtOrdQty.Enabled = False
            txtCur3.Enabled = False
            cboCurr.Enabled = False
            txtCur5.Enabled = False
            txtOrgUntPrc.Enabled = False
            txtUntPrc.Enabled = False
            txtSubTtlAmt.Enabled = False
            DTDShpDat.Enabled = False
            DTDOrgShpDat.Enabled = False
        Else
            cmdSave.Enabled = Enq_right_local 'True '*** Access Right used
            If Not rs_MPORDHDR Is Nothing Then
                If rs_MPORDHDR.Tables("result").Rows(0)("mph_mposts") = "ACT" Then
                    '----
                    If rs_MPORDDTL.Tables("result").Rows.Count > 0 Then
                        chkDelete.Enabled = Del_right_local
                    Else
                        chkDelete.Enabled = False
                    End If
                    '----
                    If AllowUpdate = True Then
                        cboVenNo.Enabled = True
                        cboVenAddr.Enabled = True
                        txtRemAddr.Enabled = True
                        cboPorCtp.Enabled = True
                        cboImpCnt.Enabled = True
                        txtshpplc.Enabled = True
                        txtShpAdr.Enabled = True
                        txtRmk.Enabled = True
                        cboPrcTrm.Enabled = True
                        cboPrcTrm.Enabled = True
                        cmdInsRow.Enabled = True
                        Curr = txtCur1.Text

                        '----
                        If MaxSeq > 0 Then
                            chkDelete.Enabled = Del_right_local
                            txtPurSeq.Enabled = False
                            txtWTPONo.Enabled = True
                            dtdWTPODate.Enabled = True
                            cboItmNo.Enabled = True
                            txtVenitm.Enabled = True
                            txtItmNam.Enabled = False
                            'txtUM.Enabled = True
                            cboUM.Enabled = True
                            txtOrdQty.Enabled = True
                            txtCur3.Enabled = False
                            cboCurr.Enabled = True
                            txtCur5.Enabled = False
                            txtOrgUntPrc.Enabled = False
                            txtUntPrc.Enabled = True
                            txtSubTtlAmt.Enabled = False
                            DTDShpDat.Enabled = True
                            DTDOrgShpDat.Enabled = True
                            Label19.Text = "Unit Price :"
                            Label18.Refresh()
                            Label20.Text = "Delivery Date (MM/DD/YYYY) :"
                            Label22.Refresh()
                        End If
                    Else
                        cboVenNo.Enabled = False
                        cboVenAddr.Enabled = True
                        cboPorCtp.Enabled = True
                        cboPrcTrm.Enabled = True
                        cboPrcTrm.Enabled = True
                        txtShpAdr.Enabled = True
                        txtRmk.Enabled = True
                        chkDelete.Enabled = Del_right_local
                    End If
                End If
            Else
                '----
                cboVenNo.Enabled = True
                cboVenAddr.Enabled = True
                txtRemAddr.Enabled = True
                cboPorCtp.Enabled = True
                cboImpCnt.Enabled = True
                txtshpplc.Enabled = True
                txtShpAdr.Enabled = True
                txtRmk.Enabled = True
                cboPrcTrm.Enabled = True
                cboPrcTrm.Enabled = True
                cmdInsRow.Enabled = True
                '----
                'chkDelete.Enabled = True
                'txtPurSeq.Enabled = False
                'txtWTPONo.Enabled = True
                'dtdWTPODate.Enabled = True
                'cboItmNo.Enabled = True
                'txtVenitm.Enabled = True
                'txtItmNam.Enabled = False
                'txtUM.Enabled = True
                'txtOrdQty.Enabled = True
                'txtCur3.Enabled = False
                'txtCur4.Enabled = True
                'txtCur5.Enabled = False
                'txtOrgUntPrc.Enabled = False
                'txtUntPrc.Enabled = True
                'txtSubTtlAmt.Enabled = False
                'DTDShpDat.Enabled = True
                'DTDOrgShpDat.Enabled = False

            End If
        End If
    End Sub
    Private Sub cboCurr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCurr.SelectedIndexChanged
        'temp
        'Private Sub cboCurr_Click()

        If cboCurr.Enabled = True Then
            Recordstatus = True
            'cboCurr.Text = UCase(cboCurr.Text)
            If cboCurr.Text <> "USD" And cboCurr.Text <> "HKD" Then
                MsgBox("Only Accept 'HKD/USD' currency !")
                Call setFocus_Combo(cboCurr)
            Else
                If Curr <> "" And cboCurr.Text <> Curr Then
                    MsgBox("Only Accept " & Curr & " currency in this MPO !")
                    cboCurr.Text = Curr
                    cboCurr.Refresh()
                    Call setFocus_Combo(cboCurr)
                Else
                    If Curr = "" Then
                        rs_MPORDHDR.Tables("result").Rows(0)("mph_curr") = cboCurr.Text
                        '                        rs_MPORDHDR.Update()
                        rs_MPORDDTL.Tables("result").Rows(readingindex)("mph_curr") = cboCurr.Text
                        '                       
                        Curr = cboCurr.Text
                        txtCur5.Text = Curr
                        txtCur1.Text = Curr
                        txtCur2.Text = Curr
                        txtCur3.Text = Curr
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboImpCnt_Change()
        Recordstatus = True
    End Sub

    Private Sub cboImpCnt_Click()

    End Sub



    Private Sub cboItmNo_Click()
        If cboItmNo.Enabled = False Then Exit Sub
        Recordstatus = True
        If cboItmNo.Text <> "" Then
            txtItmNam.Text = Split(cboItmNo.Text, " - ")(1)
            If cboItmNo.Text <> "" Then
                cboUM.SelectedIndex = -1
                If Curr = "" Then
                    cboCurr.SelectedIndex = -1
                Else
                    cboCurr.Text = Curr
                End If
                txtUntPrc.Text = 0

                rs_ZSITMLST.Tables("result").DefaultView.RowFilter = "zil_itmno='" & Split(cboItmNo.Text, " - ")(0) & "'"
                If rs_ZSITMLST.Tables("result").DefaultView.Count > 0 Then
                    If rs_ZSITMLST.Tables("result").DefaultView(0)("zil_prc") > 0 Then
                        If Curr <> "" And rs_ZSITMLST.Tables("result").DefaultView(0)("zil_cur") <> Curr Then
                            MsgBox("Only Accept " & Curr & " currency in this MPO !")
                            'cboItmNo.SelectedIndex = -1
                            Call setFocus_Combo(cboItmNo)
                        Else
                            cboUM.Text = rs_ZSITMLST.Tables("result").DefaultView(0)("zil_um")
                            cboCurr.Text = rs_ZSITMLST.Tables("result").DefaultView(0)("zil_cur")
                            txtUntPrc.Text = rs_ZSITMLST.Tables("result").DefaultView(0)("zil_prc")
                        End If
                    End If
                End If
                rs_ZSITMLST.Tables("result").DefaultView.RowFilter = ""
            End If
        End If

    End Sub

    Private Sub cboItmNo_KeyPress(ByVal KeyAscii As Integer)
        'If KeyAscii = 13 Then
        '    txtItmNam.Text = Split(cboItmNo.Text, " - ")(1)
        'End If

    End Sub

    Private Sub cboPrcTrm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrcTrm.SelectedIndexChanged
        Recordstatus = True
    End Sub


    Private Sub cbopayTrm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbopayTrm.SelectedIndexChanged
        Recordstatus = True 'Lester Wu 2005-09-23
    End Sub


    Private Sub cbopayTrm_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbopayTrm.KeyPress
        If cboPOStatus.SelectedIndex <> 0 Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub cboPorCtp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPorCtp.SelectedIndexChanged
        Recordstatus = True
    End Sub

    'Private Sub cboPorCtp_Click()
    '    Recordstatus = True 'Lester Wu 2005-09-23
    'End Sub


    Private Sub cboPOStatus_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPOStatus.LostFocus
        chkstatus()
    End Sub

    'Private Sub cboPrcTrm_Change()
    '    Recordstatus = True
    'End Sub

    'Private Sub cboPrcTrm_Click()
    '    Recordstatus = True 'Lester Wu 2005-09-23
    'End Sub


    Private Sub cboUM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUM.SelectedIndexChanged
        Recordstatus = True
    End Sub



    Private Sub cboVenAddr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenAddr.SelectedIndexChanged
        cboVenAddr_Click()
    End Sub
    Private Sub cboVenAddr_Click()
        Cursor = Cursors.Default

        Recordstatus = True 'Lester Wu 2005-09-23
        If Me.cboVenAddr.Text = "" Then
            txtRemAddr.Text = ""
            txtStt.Text = ""
            txtCty.Text = ""
            txtPst.Text = ""
            Cursor = Cursors.Default
            Exit Sub
        End If

        If rs_VNCNTINF Is Nothing Then Exit Sub
        If rs_VNCNTINF.Tables("result").Rows.Count = 0 Then Exit Sub

        ' Added by Mark Lau 20090804
        rs_VNCNTINF.Tables("result").DefaultView.RowFilter = "vci_chnadr='" & Trim(Replace(Me.cboVenAddr.Text, "'", "''")) & "'"

        ' Changed by Mark Lau 20090804
        If rs_VNCNTINF.Tables("result").DefaultView.Count = 0 Then
            rs_VNCNTINF.Tables("result").DefaultView.RowFilter = ""
            rs_VNCNTINF.Tables("result").DefaultView.RowFilter = "vci_adr='" & Trim(Replace(Me.cboVenAddr.Text, "'", "''")) & "'"

        End If



        If rs_VNCNTINF.Tables("result").DefaultView.Count > 0 Then
            txtRemAddr.Text = rs_VNCNTINF.Tables("result").DefaultView(0)("vci_adr")
            txtRemAddr.Refresh()
            txtStt.Text = rs_VNCNTINF.Tables("result").DefaultView(0)("vci_stt")
            txtStt.Refresh()
            txtCty.Text = rs_VNCNTINF.Tables("result").DefaultView(0)("vci_cty")
            txtCty.Refresh()
            txtPst.Text = rs_VNCNTINF.Tables("result").DefaultView(0)("vci_zip")
            txtPst.Refresh()

        End If
        rs_VNCNTINF.Tables("result").DefaultView.RowFilter = ""
        Cursor = Cursors.Default
    End Sub

    'Private Sub cboVenAddr_DblClick()
    '    Recordstatus = True
    'End Sub

    Private Sub cboVenAddr_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenAddr.GotFocus

        befVenAddr = Me.cboVenAddr.Text
    End Sub

    'Private Sub cboVenAddr_KeyPress(ByVal KeyAscii As Integer)
    '    If KeyAscii = 13 Then
    '        Call cboVenAddr_Click()
    '    End If
    'End Sub


    'Private Sub cboVenAddr_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
    '    'Call AutoSearch(Me.cboVenAddr, KeyCode)
    'End Sub

    Private Sub cboVenAddr_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVenAddr.LostFocus

        If ValidateCombo(Me.cboVenAddr) = False Then
            Exit Sub
        End If
        'temp


        'If befVenAddr <> Me.cboVenAddr.Text Then
        '    Call cboVenAddr_Click()
        'End If
        'tempzz

    End Sub


    Private Sub fillcbovenno()
        cboVenNo.Items.Clear()
        If rs_VNBASINF.Tables("result").Rows.Count > 0 Then

            For index As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                cboVenNo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vennam"))
            Next
        End If

    End Sub

    Private Sub Fill_LstVen()

        If rs_VNBASINF.Tables("result").Rows.Count > 0 Then
            For index As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                frmPOB.LstVen.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vennam"))
                frmPOB.LstVenSub.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_curcde") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("ysi_buyrat"))
            Next
        End If



    End Sub

    'Private Sub cboVenno_Change()
    '    Recordstatus = True
    'End Sub

    Private Sub cboVenNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenNo.SelectedIndexChanged

        If cboVenNo.Text <> "" Then
            Recordstatus = True
            Call Display_VenAddr()

            If rs_VNCNTINF.Tables("result") Is Nothing Then
                Exit Sub
            End If
            If rs_VNCNTINF.Tables("result").Rows.Count > 0 Then
                cboVenAddr.SelectedIndex = 1
            End If
            Call cboVenAddr_Click()
            'tempzzz

            Call FillContactPerson()
            If rs_CVNCNTINF.Tables("result").Rows.Count > 0 Then
                cboPorCtp.SelectedIndex = 0
            End If
            If rs_VNBASINF.Tables("result").Rows.Count > 0 Then
                If cboVenNo.Text <> "" Then
                    rs_VNBASINF.Tables("result").DefaultView.RowFilter = "vbi_venno = '" & Split(cboVenNo.Text, " - ")(0) & "'"
                    If rs_VNBASINF.Tables("result").DefaultView.Count > 0 Then
                        Call display_combo(rs_VNBASINF.Tables("result").DefaultView(0)("vbi_prctrm"), cboPrcTrm)
                        Call display_combo(rs_VNBASINF.Tables("result").DefaultView(0)("vbi_paytrm"), cbopayTrm)
                    End If
                    rs_VNBASINF.Tables("result").DefaultView.RowFilter = ""
                End If
            End If
        End If
        Cursor = Cursors.Default

    End Sub

    Private Sub chkDelete_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDelete.Click

        If chkDelete.Checked = True Then
            If Not rs_MPORDDTL Is Nothing Then
                If rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_shpqty") = 0 And rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_dqty") = 0 Then
                    If rs_MPORDDTL.Tables("result").Rows.Count > 0 Then
                        If rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_creusr") <> "~*ADD*~" And _
                            rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_creusr") <> "~*NEW*~" Then
                            rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_creusr") = "~*DEL*~"
                            rs_MPORDDTL.Tables("result").Rows(readingindex)("del") = "Y"
                            Call CalNetAmt()
                            Recordstatus = True
                        ElseIf rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_creusr") = "~*ADD*~" Then
                            rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_creusr") = "~*NEW*~"
                            rs_MPORDDTL.Tables("result").Rows(readingindex)("del") = "N"
                            Call CalNetAmt()
                            Recordstatus = True
                        End If
                        'ElseIf rs_MPORDDTL.tables("result").rows.Count = 1 Then
                        '    chkDelete.checked = false
                        '    msgbox ("This Manufacturing Purchase Order just has one detail line record only, cannot delete.")
                        '    chkDelete.SetFocus
                        '    Exit Sub
                    End If
                Else
                    chkDelete.Checked = False
                    MsgBox("Item have delivery or shipped qty, cannot delete.")
                    'chkDelete.SetFocus
                    Exit Sub
                End If
            End If
        Else
            If Not rs_MPORDDTL Is Nothing Then
                If rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_creusr") = "~*NEW*~" Then
                    rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_creusr") = "~*ADD*~"
                    rs_MPORDDTL.Tables("result").Rows(readingindex)("del") = "N"

                    Call CalNetAmt()
                    Recordstatus = True
                ElseIf rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_creusr") <> "~*NEW*~" And _
                    rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_creusr") <> "~*ADD*~" Then
                    rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_creusr") = "~*UPD*~"
                    rs_MPORDDTL.Tables("result").Rows(readingindex)("del") = "N"

                    Call CalNetAmt()
                    Recordstatus = True
                End If
            End If
        End If

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

        Dim S As String

        Call setStatus("Init")


        Call display_combo("ACT", cboPOStatus)
        Call setStatus("ADD")

        ' Get Empty recordset
        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_MMPORDHDR '" & "" & "','" & "" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_MPORDHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtShpNoKeyPress sp_select_MMPORDHDR :" & rtnStr)
            Exit Sub
        End If
        For i2 As Integer = 0 To rs_MPORDHDR.Tables("RESULT").Columns.Count - 1
            rs_MPORDHDR.Tables("RESULT").Columns(i2).ReadOnly = False
        Next


        gspStr = "sp_select_MMPORDDTL '" & "" & "','" & "" & "'"
        '        gspStr = "sp_select_MMPORDDTL '" & "" & "','" & txtPONo.Text.Trim & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_MPORDDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtShpNoKeyPress sp_select_MMPORDDTL :" & rtnStr)
            Exit Sub
        End If
        For i2 As Integer = 0 To rs_MPORDDTL.Tables("RESULT").Columns.Count - 1
            rs_MPORDDTL.Tables("RESULT").Columns(i2).ReadOnly = False
        Next

        Cursor = Cursors.Default
        '---------------------
        grdSummary.DataSource = rs_MPORDDTL.Tables("result")
        Add_flag = True
        find_flag = False
        AllowUpdate = True

        Call Display_Summary()
        rs_MPORDHDR.Tables("result").Rows.Add()
        rs_MPORDHDR.Tables("result").Rows(0)("mph_mposts") = "ACT"
        Call chkstatus()

        Call setFocus_Combo(cboVenNo)
    End Sub




    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click

        Dim YesNoCancel As Integer
        If Recordstatus = True Then
            YesNoCancel = MsgBox("Do you want to save before clear the screen?", MsgBoxStyle.YesNoCancel)
            '            YesNoCancel = MsgBox("M00248")

            If YesNoCancel = vbYes Then
                If cmdSave.Enabled Then
                    '--- Checking
                    If ErrFlag = False Then
                        If InputIsValid() = False Then
                            ErrFlag = False
                            Exit Sub
                        End If
                    End If
                    '---
                    flag_exit = True
                    Call cmdSaveClick()
                    If save_ok = True Then
                        Temp_POno = txtPONo.Text
                        Call setStatus("Init")
                    Else
                        flag_exit = False
                        Exit Sub
                    End If
                Else
                    flag_exit = False
                      MsgBox("You are not allow to save record!")
                    Exit Sub
                End If

            ElseIf YesNoCancel = vbNo Then
                Temp_POno = txtPONo.Text
                Call setStatus("Init")

                txtDiscnt.Enabled = False
            ElseIf YesNoCancel = vbCancel Then
                flag_exit = False
                Exit Sub
            End If
        Else
            Temp_POno = txtPONo.Text
            Call setStatus("Init")
        End If
        Recordstatus = False
        Call setFocus_text(txtPONo)

    End Sub
    Private Sub Update_PODtl()

        If rs_MPORDDTL Is Nothing Then
            Exit Sub
        End If
        If rs_MPORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        For i2 As Integer = 0 To rs_MPORDDTL.Tables("RESULT").Columns.Count - 1
            rs_MPORDDTL.Tables("RESULT").Columns(i2).ReadOnly = False
        Next

        Dim UpdateFlag As Boolean
        UpdateFlag = False
        If Not rs_MPORDDTL Is Nothing Then
            If rs_MPORDDTL.Tables("result").Rows.Count > 0 And Recordstatus = True Then

                If AllowUpdate = True Then
                    txtOrgUntPrc.Text = txtUntPrc.Text
                    DTDOrgShpDat.Text = DTDShpDat.Text
                End If

                If chkDelete.Checked = True Then
                    If rs_MPORDDTL.Tables("result").Rows(readingindex)("del") <> "Y" Then
                        UpdateFlag = True
                        rs_MPORDDTL.Tables("result").Rows(readingindex)("del") = "Y"
                    End If

                End If

                If rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_MPONO") <> UCase(txtPONo.Text) Then
                    UpdateFlag = True
                    rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_MPONO") = UCase(txtPONo.Text)
                End If

                If rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_MPOseq") <> txtPurSeq.Text Then
                    UpdateFlag = True
                    rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_MPOseq") = txtPurSeq.Text
                End If

                If rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_PONo") <> txtWTPONo.Text Then
                    UpdateFlag = True
                    rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_PONo") = txtWTPONo.Text
                End If

                If rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_ShpDat").ToString <> DTDShpDat.Text Then
                    UpdateFlag = True
                    If IsDate(DTDShpDat.Text) Then
                        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_ShpDat") = CDate(DTDShpDat.Text)
                    Else
                        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_ShpDat") = CDate("01/01/1900")
                    End If

                End If

                If rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_OrgShpDat").ToString <> DTDOrgShpDat.Text Then
                    UpdateFlag = True

                    If IsDate(DTDOrgShpDat.Text) Then
                        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_OrgShpDat") = DTDOrgShpDat.Text
                    Else
                        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_OrgShpDat") = CDate("01/01/1900")
                    End If

                End If

                If rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_VenItm").ToString <> txtVenitm.Text Then
                    UpdateFlag = True
                    rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_VenItm") = txtVenitm.Text
                End If

                If cboItmNo.Text <> "" Then
                    If rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_ItmNo") <> Split(cboItmNo.Text, " - ")(0) Then
                        UpdateFlag = True
                        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_ItmNo") = Split(cboItmNo.Text, " - ")(0)
                    End If

                End If

                If rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_ItmNam") <> txtItmNam.Text Then
                    UpdateFlag = True
                    rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_ItmNam") = txtItmNam.Text
                End If

                If cboUM.Text <> "" Then
                    If rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_UM") <> UCase(cboUM.Text) Then
                        UpdateFlag = True
                        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_UM") = UCase(cboUM.Text)
                    End If
                End If

                If rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_Qty") <> txtOrdQty.Text Then
                    UpdateFlag = True
                    rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_Qty") = txtOrdQty.Text
                End If

                If rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_UntPrc") <> txtOrgUntPrc.Text + 0 Then
                    UpdateFlag = True
                    rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_UntPrc") = txtOrgUntPrc.Text
                End If

                If rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_MinPrc") <> txtUntPrc.Text + 0 Then
                    UpdateFlag = True
                    rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_MinPrc") = txtUntPrc.Text
                End If

                If rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_creusr") <> "~*NEW*~" And _
                    rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_creusr") <> "~*ADD*~" And _
                    rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_creusr") <> "~*DEL*~" Then

                    rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_creusr") = "~*UPD*~"

                End If

                If UpdateFlag = True Then

                End If

            End If
        End If

    End Sub

    Private Sub cmdDelRow_Click()
        If chkDelete.Checked = True Then
            chkDelete.Checked = False
        Else
            chkDelete.Checked = True
        End If
    End Sub

    Private Sub CmdDtlNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDtlNext.Click

        If ErrFlag = False Then
            If InputIsValid() = False Then
                ErrFlag = False
                Exit Sub
            End If
        End If

        Call Update_PODtl()

        If readingindex + 1 <> rs_MPORDDTL.Tables("result").Rows.Count Then
            CmdDtlPre.Enabled = True
            readingindex = readingindex + 1
            If readingindex > rs_MPORDDTL.Tables("result").Rows.Count - 1 Then
                readingindex = rs_MPORDDTL.Tables("result").Rows.Count - 1
            End If
        End If

        Call DisplayPODetail()

        If readingindex + 1 = rs_MPORDDTL.Tables("result").Rows.Count Then
            CmdDtlNext.Enabled = False
        End If

    End Sub

    Private Sub CmdDtlPre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDtlPre.Click

        If ErrFlag = False Then
            If InputIsValid() = False Then
                ErrFlag = False
                Exit Sub
            End If
        End If

        Call Update_PODtl()

        If readingindex + 1 <> 1 Then
            CmdDtlNext.Enabled = True
            readingindex = readingindex - 1
            If readingindex < 0 Then
                readingindex = 0
            End If
        End If
        Call DisplayPODetail()

        If readingindex + 1 = 1 Then
            CmdDtlPre.Enabled = False
        End If

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click

        Me.Close()

    End Sub

    Private Sub FillContactPerson()
        Dim S As String

        If cboVenNo.Text <> "" Then
            cboPorCtp.Items.Clear()


            gspStr = "sp_list_CVNCNTINF '" & "" & "','" & Split(Me.cboVenNo.Text, " - ")(0) & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_CVNCNTINF, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading txtShpNoKeyPress sp_list_CVNCNTINF  :" & rtnStr)
                Exit Sub
            End If

            If rs_CVNCNTINF.Tables("result").Rows.Count > 0 Then

                For index As Integer = 0 To rs_CVNCNTINF.Tables("RESULT").Rows.Count - 1
                    cboPorCtp.Items.Add(rs_CVNCNTINF.Tables("RESULT").Rows(index)("vci_cntctp"))
                Next
            End If

        End If
    End Sub
    Public Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click


        Call cmdfindClick()
    End Sub
    Public Sub cmdfindClick()
        find_flag = True
        Add_flag = False

        If (Trim(txtPONo.Text) = "") Then
            Call setFocus_text(txtPONo)
            MsgBox("Please input PO number!")
            Exit Sub
        End If


        Dim S As String
        Dim sMPORDHDR As String

        gspStr = "sp_select_MMPORDHDR '" & "" & "','" & txtPONo.Text.Trim & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_MPORDHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtShpNoKeyPress sp_select_MMPORDHDR :" & rtnStr)
            Exit Sub
        End If
        For i2 As Integer = 0 To rs_MPORDHDR.Tables("RESULT").Columns.Count - 1
            rs_MPORDHDR.Tables("RESULT").Columns(i2).ReadOnly = False
        Next

        If rs_MPORDHDR.Tables("result").Rows.Count = 0 Then
            Cursor = Cursors.Default
            MsgBox("Record not found!")
            Exit Sub
        Else
            gspStr = "sp_select_MMPORDDTL '" & "" & "','" & txtPONo.Text.Trim & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_MPORDDTL, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading txtShpNoKeyPress sp_select_MMPORDDTL :" & rtnStr)
                Exit Sub
            End If
        End If
        For i2 As Integer = 0 To rs_MPORDDTL.Tables("RESULT").Columns.Count - 1
            rs_MPORDDTL.Tables("RESULT").Columns(i2).ReadOnly = False
        Next

        If rs_MPORDDTL.Tables("result").Rows.Count > 0 Then

            If Len(rs_MPORDDTL.Tables("result").Rows(0)("mpd_creusr")) > 4 And Microsoft.VisualBasic.Right(rs_MPORDDTL.Tables("result").Rows(0)("mpd_creusr"), 4) = "_Gen" Then
                AllowUpdate = False
            ElseIf rs_MPORDDTL.Tables("result").Rows(0)("mpd_poseq").ToString = "" Then
                AllowUpdate = False
            Else
                AllowUpdate = True
            End If
        End If

        '--- Reset the Tables("result").DefaultView.Sort sequence ---
        rs_MPORDDTL.Tables("result").DefaultView.Sort = "mpd_mposeq"
        varSort = rs_MPORDDTL.Tables("result").DefaultView.Sort
        '-------------------------------

        '--- Get Max Seq No.
        If rs_MPORDDTL.Tables("result").Rows.Count > 0 Then
            MaxSeq = rs_MPORDDTL.Tables("result").Rows(rs_MPORDDTL.Tables("result").Rows.Count - 1)("mpd_mposeq")
        End If

        Dim salrep As String


        If rs_MPORDHDR.Tables("result").Rows.Count > 0 Then
            cmdAdd.Enabled = False
            cmdInsRow.Enabled = False

            Current_TimeStamp = rs_MPORDHDR.Tables("result").Rows(0)("mph_timstp")
            Call Display()
            Call FillContactPerson()
            Call display_combo(rs_MPORDHDR.Tables("result").Rows(0)("mph_mporctp"), cboPorCtp)
            Call display_combo(rs_MPORDHDR.Tables("result").Rows(0)("mph_impfty"), cboImpCnt)

            Call setStatus("Updating")
            grdSummary.DataSource = rs_MPORDDTL.Tables("result")
            Call Display_Summary()

            Cursor = Cursors.Default
            Recordstatus = False
            '------------------------------------------
        End If
        Call chkstatus()
        Recordstatus = False

        'Disable all function in 'CLO' & 'CAN' statis
        If Microsoft.VisualBasic.Left(cboPOStatus.Text, 3) = "CAN" Then
            Call SetStatusBar("ReadOnly")
            Dim v
            For Each v In Me.Controls
                If IsInputBoxes(v) Then
                    v.Enabled = False
                End If
            Next
            cmdClear.Enabled = True
            cmdExit.Enabled = True

        End If

        If Microsoft.VisualBasic.Left(cboPOStatus.Text, 3) = "CLO" Then
            Call SetStatusBar("ReadOnly")
            AllowUpdate = False
            cboVenNo.Enabled = False
            cboVenAddr.Enabled = False
            DTRvsDat.Enabled = False
            DTIssDat.Enabled = False
            txtRemAddr.Enabled = False
            txtStt.Enabled = False
            txtCty.Enabled = False
            txtPst.Enabled = False
            cboPorCtp.Enabled = False
            cboImpCnt.Enabled = False
            txtshpplc.Enabled = False
            txtShpAdr.Enabled = False
            ' Changed by Mark Lau 20090525
            'txtRmk.Enabled = False
            txtRmk.Enabled = True

            txtRmk.ReadOnly = True

            cboPrcTrm.Enabled = False
            cboPrcTrm.Enabled = False
            txtCur1.Enabled = False
            txtCur2.Enabled = False
            txtDiscnt.Enabled = False
            txtNetAmt.Enabled = False
            txtTtlAmt.Enabled = False
            cmdSave.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdspecial.Enabled = False
            CmdLookup.Enabled = False
            cmdbrowlist.Enabled = False

        Else
            ' Added by Mark Lau 20090729
            txtRmk.ReadOnly = False
        End If



        'cboPOStatus.Enabled = False
        'cboVenNo.Enabled = False
        'cboVenAddr.Enabled = False
        'txtRemAddr.Enabled = False
        'txtStt.Enabled = False
        'txtCty.Enabled = False
        'txtPst.Enabled = False
        'cboImpCnt.Enabled = False
        'txtshpplc.Enabled = False
        'txtDiscnt.Enabled = False



    End Sub


    Private Function ChecktimeStamp() As Boolean
        '***Add Codes here***
        'Compare the current record's timestamp and the DB timestamp
        Dim Save_TimeStamp As Long
        Dim S As String


        gspStr = "sp_select_MMPORDHDR '" & "" & "','" & txtPONo.Text.Trim & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_MPORDHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtShpNoKeyPress sp_select_MMPORDHDR :" & rtnStr)
            Exit Function
        End If

        If rs_MPORDHDR.Tables("result").Rows.Count = 0 Then
            Cursor = Cursors.Default
            MsgBox("TimeStamp Check error!")
            ChecktimeStamp = False
            Exit Function
        Else
            Save_TimeStamp = rs_MPORDHDR.Tables("result").Rows(0)("mph_timstp")
        End If


        'Write your code for Compare
        If Current_TimeStamp <> Save_TimeStamp Then
            ChecktimeStamp = False
        Else
            ChecktimeStamp = True
        End If

    End Function

    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click


        If ErrFlag = False Then
            If InputIsValid() = False Then
                ErrFlag = False
                Exit Sub
            End If
        End If

        Recordstatus = True

        ' Update Recaordset
        Call Update_PODtl()

        chkDelete.Enabled = Del_right_local
        txtPurSeq.Enabled = False
        txtWTPONo.Enabled = True
        dtdWTPODate.Enabled = True
        cboItmNo.Enabled = True
        txtVenitm.Enabled = True
        txtItmNam.Enabled = False
        'txtUM.Enabled = True
        cboUM.Enabled = True
        txtOrdQty.Enabled = True
        txtCur3.Enabled = False
        cboCurr.Enabled = True
        txtCur5.Enabled = False
        txtOrgUntPrc.Enabled = False
        txtUntPrc.Enabled = True
        txtSubTtlAmt.Enabled = False
        DTDShpDat.Enabled = True
        DTDOrgShpDat.Enabled = True
        Label19.Text = "Unit Price :"
        Label20.Text = "Delivery Date (MM/DD/YYYY) :"
        cboUM.SelectedIndex = -1
        cboItmNo.SelectedIndex = -1

        MaxSeq = MaxSeq + 1
        readingindex = rs_MPORDDTL.Tables("result").Rows.Count

        rs_MPORDDTL.Tables("result").Rows.Add()
        rs_MPORDDTL.Tables("result").Rows(readingindex)("DEL") = "N"
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_MPONO") = UCase(txtPONo.Text)
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_MPOseq") = MaxSeq
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_PONo") = ""
        If DTDShpDat.Text = "  /  /    " Then
            rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_ShpDat") = Format(Date.Today, "MM/dd/yyyy").ToString
        Else
            rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_ShpDat") = DTDShpDat.Text
        End If
        If DTDOrgShpDat.Text = "  /  /    " Then
            rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_OrgShpDat") = Format(Date.Today, "MM/dd/yyyy").ToString
        Else
            rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_OrgShpDat") = DTDOrgShpDat.Text
        End If
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_VenItm") = ""
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_ItmNo") = ""
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_ItmNam") = ""
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_UM") = ""
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_Qty") = 0
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_UntPrc") = 0
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_MinPrc") = 0
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_POSeq") = 0
        If dtdWTPODate.Text = "  /  /    " Then
            rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_PODat") = Format(Date.Today, "MM/dd/yyyy").ToString
        Else
            rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_PODat") = dtdWTPODate.Text
        End If

        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_ReqNo") = ""
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_ItmDsc") = ""
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_ColCde") = ""
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_ShpQty") = 0
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_PckMth") = ""
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_Dept") = ""
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_PrdNo") = ""
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_FilNamH") = ""
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_FilseqH") = 0
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_FilNam") = ""
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_Filseq") = 0
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_HdrRmk") = ""
        rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_Rmk") = ""
        rs_MPORDDTL.Tables("result").Rows(readingindex)("mph_curr") = UCase(Curr)

        rs_MPORDDTL.Tables("result").Rows(readingindex)("mpd_creusr") = "~*ADD*~"
        grdSummary.DataSource = rs_MPORDDTL.Tables("result")
        Call Display_Summary()

        If rs_MPORDDTL.Tables("result").Rows.Count > 0 Then
            cmdDelRow.Enabled = True
        Else
            cmdDelRow.Enabled = False
        End If

        Call DisplayPODetail()
        cboItmNo.Enabled = True

    End Sub
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Call cmdSaveClick()
    End Sub
    Public Sub cmdSaveClick()

        If ErrFlag = False Then
            If InputIsValid() = False Then
                ErrFlag = False
                Exit Sub
            End If
        End If

        Dim rs_AutoGenSCNo As New DataSet


        Cursor = Cursors.WaitCursor

        Call Update_PODtl()


        If Enq_right_local = False Then '*** Access Right used  - added by Tommy on 10 March 2002
            MsgBox("You have no right to SAVE.")
            Exit Sub
        End If

        If Recordstatus = True Then
            ' Skip checking if in Add mode
            If Add_flag <> True Then
                If Not ChecktimeStamp() Then
                    MsgBox("TimeStamp Check error!")
                    Cursor = Cursors.Default
                    save_ok = False
                    Exit Sub
                End If
            End If
            Dim YesNo As Integer
            Dim UpdDtlFlg As Integer
            UpdDtlFlg = 0

            Dim S As String
            Dim rs As New DataSet


            '*****************Auto Gen SC No.********************************
            If Add_flag = True Then
                gsCompany = ""
                Call Update_gs_Value(gsCompany)
                gspStr = "sp_select_DOC_GEN '" & "UCPP" & "','MP','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cmdSaveClick sp_select_DOC_GEN :" & rtnStr)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
                txtPONo.Text = rs.Tables("RESULT").Rows(0)(0).ToString
            End If
        End If
        '****************************************************************

        '************************ Update PO Detail ********************************************
        rs_MPORDDTL.Tables("result").DefaultView.RowFilter = ""


        For i As Integer = 0 To rs_MPORDDTL.Tables("RESULT").Rows.Count - 1
            gspStr = ""
            '--- Add ---
            If rs_MPORDDTL.Tables("result").Rows(i)("mpd_creusr") = "~*ADD*~" Then
                gspStr = "sp_insert_MMPORDDTL '" & "" & "','" & _
                    UCase(txtPONo.Text) & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_MPOseq") & "','" & _
                    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_PONo") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_POSeq") & "','" & _
                    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_PODat") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_ShpDat") & "','" & _
                    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_OrgShpDat") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_ReqNo") & "','" & _
                    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_VenItm") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_ItmNo") & "','" & _
                    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_ItmNam") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_ItmDsc") & "','" & _
                    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_ColCde") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_UM") & "','" & _
                    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_Qty") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_ShpQty") & "','" & _
                    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_UntPrc") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_MinPrc") & "','" & _
                    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_PckMth") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_Dept") & "','" & _
                    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_PrdNo") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_FilNamH") & "','" & _
                    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_FilseqH") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_FilNam") & "','" & _
                    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_Filseq") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_HdrRmk") & "','" & _
                    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_Rmk") & "','" & gsUsrID & "'"
            End If

            '--- Update ---
            If rs_MPORDDTL.Tables("result").Rows(i)("mpd_creusr") = "~*UPD*~" Then
                gspStr = "sp_update_MMPORDDTL '" & "" & "','" & _
    UCase(txtPONo.Text) & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_MPOseq") & "','" & _
    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_PONo") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_POSeq") & "','" & _
    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_PODat") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_ShpDat") & "','" & _
    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_OrgShpDat") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_ReqNo") & "','" & _
    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_VenItm") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_ItmNo") & "','" & _
    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_ItmNam") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_ItmDsc") & "','" & _
    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_ColCde") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_UM") & "','" & _
    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_Qty") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_ShpQty") & "','" & _
    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_UntPrc") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_MinPrc") & "','" & _
    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_PckMth") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_Dept") & "','" & _
    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_PrdNo") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_FilNamH") & "','" & _
    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_FilseqH") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_FilNam") & "','" & _
    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_Filseq") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_HdrRmk") & "','" & _
    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_Rmk") & "','" & gsUsrID & "'"
            End If

            '--- Delete ---
            If rs_MPORDDTL.Tables("result").Rows(i)("mpd_creusr") = "~*DEL*~" Then
                gspStr = "sp_physical_delete_MMPORDDTL '" & "" & "','" & _
                UCase(txtPONo.Text) & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_MPOseq") & "','" & _
                    rs_MPORDDTL.Tables("result").Rows(i)("Mpd_PONo") & "','" & rs_MPORDDTL.Tables("result").Rows(i)("Mpd_POSeq") & "','" & gsUsrID & "'"
            End If

            If gspStr <> "" Then
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    IsUpdated = False
                    MsgBox("Error on  sp_save_MMPORDDTL :" & rtnStr)
                    Exit Sub
                Else
                    IsUpdated = True
                End If

            End If

        Next


        '**************************Update MPORDHDR****************************************
        ' UPDATE NET AMOUNT
        CalNetAmt()
        ' ****************

        ' Update PO Status if all details deleted
        rs_MPORDDTL.Tables("result").DefaultView.RowFilter = "mpd_creusr <> '~*DEL*~'"
        If rs_MPORDDTL.Tables("result").Rows.Count = 0 Then
            cboPOStatus.Text = "CAN - Cancelled"
        End If
        ' ***************************************

        If Add_flag = True Then
            ' ignore Mph_ShpDat field
            gspStr = "sp_insert_MMPORDHDR '" & "" & "','" & _
            UCase(txtPONo.Text) & "','" & _
        Split(cboVenNo.Text, " - ")(0) & "','" & Split(cboImpCnt.Text, " - ")(0) & "','" & _
        txtCur1.Text & "','" & txtshpplc.Text & "','" & _
        txtRmk.Text & "','" & _
        txtRemAddr.Text & "','" & cboPorCtp.Text & "','" & _
        txtStt.Text & "','" & Split(txtCty.Text, " - ")(0) & "','" & _
        txtPst.Text & "','" & Split(cboPrcTrm.Text, " - ")(0) & "','" & _
        Split(cbopayTrm.Text, " - ")(0) & "','" & CDbl(txtTtlAmt.Text) & "','" & _
        CDbl(txtDiscnt.Text) & "','" & CDbl(txtNetAmt.Text) & "','" & _
        txtShpAdr.Text & "','" & Split(cboPOStatus.Text, " - ")(0) & "','" & _
        gsUsrID & "'"
        Else
            gspStr = "sp_update_MMPORDHDR '" & "" & "','" & _
            UCase(txtPONo.Text) & "','" & _
            Split(cboVenNo.Text, " - ")(0) & "','" & Split(cboImpCnt.Text, " - ")(0) & "','" & _
            txtCur1.Text & "','" & txtshpplc.Text & "','" & _
            txtRmk.Text & "','" & _
            txtRemAddr.Text & "','" & cboPorCtp.Text & "','" & _
            txtStt.Text & "','" & Split(txtCty.Text, " - ")(0) & "','" & _
            txtPst.Text & "','" & Split(cboPrcTrm.Text, " - ")(0) & "','" & _
            Split(cbopayTrm.Text, " - ")(0) & "','" & CDbl(txtTtlAmt.Text) & "','" & _
            CDbl(txtDiscnt.Text) & "','" & CDbl(txtNetAmt.Text) & "','" & _
            txtShpAdr.Text & "','" & Split(cboPOStatus.Text, " - ")(0) & "','" & _
            gsUsrID & "'"

        End If


        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            IsUpdated = False
            MsgBox("Error on  sp_save_MMPORDHDR :" & rtnStr)
            Exit Sub
        Else
            IsUpdated = True
        End If




        cmdfindClick()
        Cursor = Cursors.Default
        If IsUpdated Then
            Call setStatus("Save")
            MsgBox("Record Saved!")
        Else
            Call setStatus("Init")
            MsgBox("Record Saved!")
            Call setFocus_text(txtPONo)
            Call ClearScreen()
        End If
        Recordstatus = False
    End Sub
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click

        Dim frmSYM00018 As New SYM00018


        '20130909  
        gsCompany = ""
        'tempz
        Call Update_gs_Value(gsCompany)


        frmSYM00018.keyName = txtPONo.Name
        frmSYM00018.strModule = "MP"

        frmSYM00018.show_frmSYM00018(Me)




    End Sub

    'Private Sub cmdSearch_Click()
    '    gsSearchKey = ""

    '    gsCompany = "UCPP"
    '    Call Update_gs_Value(gsCompany)


    '    SYM00018.Module = "MP"
    '    SYM00018.Show(1)


    '    txtPONo.Text = gsSearchKey
    '    gsSearchKey = ""
    '    txtPONo.selStart = 0
    '    txtPONo.SelLength = Len(txtPONo.Text)

    '    If txtPONo.Text <> "" Then
    '        Timer1.Enabled = True
    '    End If
    'End Sub

    Private Sub DTDOrgShpDat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTDOrgShpDat.TextChanged

        Recordstatus = True
    End Sub

    Private Sub DTDOrgShpDat_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTDOrgShpDat.GotFocus

        Call HighlightMask_text(DTDOrgShpDat)

    End Sub

    Private Sub DTDOrgShpDat_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTDOrgShpDat.LostFocus

        If Not IsDate(DTDOrgShpDat.Text) Then
            'If Not CheckDate(DTDOrgShpDat.Text) Then
            MsgBox("Please input date!")
            Call setFocus_Mask_text(DTDOrgShpDat)
        End If
    End Sub


    Private Sub DTDShpDat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTDShpDat.TextChanged

        Recordstatus = True
    End Sub

    'Private Sub DTDShpDat_GotFocus()
    '    '        Call HighlightMask(DTDShpDat)
    'End Sub
    Private Sub DTDShpDat_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTDShpDat.LostFocus

        If Not IsDate(DTDShpDat.Text) Then
            '            If Not CheckDate(DTDShpDat.Text) Then
            MsgBox("Please input date!")
            Call setFocus_Mask_text(DTDShpDat)
        End If
    End Sub


    Private Sub dtdWTPODate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtdWTPODate.TextChanged

        Recordstatus = True
    End Sub

    'Private Sub dtdWTPODate_GotFocus()
    '    '        Call HighlightMask(dtdWTPODate)
    'End Sub

    Private Sub dtdWTPODate_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtdWTPODate.LostFocus
        If Not IsDate(dtdWTPODate.Text) Then
            'If Not CheckDate(dtdWTPODate.Text) Then
            MsgBox("Please input date!")
            Call setFocus_Mask_text(dtdWTPODate)
        End If
    End Sub

    Private Sub DTRvsDat_Change()

    End Sub





    Private Sub MPM00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = ERP00000.Icon



        Enq_right_local = Enq_right
        Del_right_local = Del_right

        '    Call FillCompCombo(gsUsrID, Me)         'Get availble Company
        '    Call GetDefaultCompany(Me)

        AccessRight(Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001
        'AccessRight_1 (Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001 Change by Lewis on 2 Jul 2003


        varSort = "mpd_mposeq"
        'AccessRight (Me.Name) '*** Access Right used  - added by Tommy on 10 March 2002

        Enq_right_local = Enq_right
        Del_right_local = Del_right

        Call Formstartup(Me.Name)
        '#If useMTS Then
        '        Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If

        '        If gsConnStr = "" Then
        '            gsConnStr = getConnectionString()
        '        End If

        cboUM.Items.Clear()
        cboUM.Items.Add("BAG")
        cboUM.Items.Add("BOX")
        cboUM.Items.Add("BUN")
        cboUM.Items.Add("CM")
        cboUM.Items.Add("CTN")
        cboUM.Items.Add("DZ")
        cboUM.Items.Add("G")
        cboUM.Items.Add("GAL")
        cboUM.Items.Add("GR")
        cboUM.Items.Add("INCH")
        cboUM.Items.Add("KG")
        cboUM.Items.Add("L")
        cboUM.Items.Add("LBS")
        cboUM.Items.Add("M")
        cboUM.Items.Add("MG")
        cboUM.Items.Add("MM")
        cboUM.Items.Add("PC")
        cboUM.Items.Add("PACK")
        cboUM.Items.Add("ROLL")
        cboUM.Items.Add("SET")
        cboUM.Items.Add("ST")
        cboUM.Items.Add("SQCM")
        cboUM.Items.Add("SQIN")
        cboUM.Items.Add("SQM")
        cboUM.Items.Add("STE")
        cboUM.Items.Add("TANK")
        cboUM.Items.Add("THCH")
        cboUM.Items.Add("TIN")
        cboUM.Items.Add("TRAY")
        cboUM.Items.Add("YD")
        cboUM.Items.Add("YDS")

        cboCurr.Items.Clear()
        cboCurr.Items.Add("USD")
        cboCurr.Items.Add("HKD")
        cboCurr.Items.Add("TWD")



        cboPOStatus.Items.Add("ACT - ACTIVE")
        cboPOStatus.Items.Add("OPE - OPEN")
        cboPOStatus.Items.Add("REL - Released")
        cboPOStatus.Items.Add("CLO - Closed")
        cboPOStatus.Items.Add("CAN - Cancelled")

        Dim S As String
        'Dim rs() As New DataSet


        Cursor = Cursors.WaitCursor

        gspStr = "sp_list_SYSETINF '" & "" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_list_SYSETINF :" & rtnStr)
            Exit Sub
        End If


        gspStr = "sp_list_SYAGTINF '" & "" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYAGTINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_list_SYAGTINF :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_SYSALREP '" & "" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSALREP, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_list_SYSALREP :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_ZSITMLST '','',''  "
        'tempz
        rtnLong = execute_SQLStatement(gspStr, rs_ZSITMLST, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_list_SYSALREP :" & rtnStr)
            Exit Sub
        End If


        gspStr = "sp_list_CUBASINF '" & "" & "','A'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If


        gspStr = "sp_select_ZSITMLST '','',''  "
        'tempz
        rtnLong = execute_SQLStatement(gspStr, rs_ZSITMLST, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_ZSITMLST :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_SYDISPRM_All '" & "" & "'"
        'tempz
        rtnLong = execute_SQLStatement(gspStr, rs_sydisprm, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_SYDISPRM_All :" & rtnStr)
            Exit Sub
        End If


        gspStr = "sp_select_GRNVENINF '" & "" & "','MPO'"
        'tempz
        rtnLong = execute_SQLStatement(gspStr, rs_GRNVENINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_GRNVENINF :" & rtnStr)
            Exit Sub
        End If

        'S = "¡ÀSYSETINF¡°L" & _
        '    "¡ÀSYAGTINF¡°L" & _
        '    "¡ÀSYSALREP¡°L" & _
        '    "¡ÀZSITMLST¡°S" & _
        '    "¡ÀCUBASINF¡°L¡°A" & _
        '    "¡ÀSYDISPRM_All¡°S" & _
        '    "¡ÀGRNVENINF¡°S¡°MPO"



        'If rs(0)(0) <> "0" Then  '*** An error has occured
        '    MsgBox(rs(0)(0))
        'Else
        '    rs_SYSETINF = rs(1)
        '    rs_SYAGTINF = rs(2)
        '    rs_SYSALREP = rs(3)
        '    rs_ZSITMLST = rs(4)
        '    rs_CUBASINF = rs(5)
        '    rs_sydisprm = rs(6)
        '    rs_GRNVENINF = rs(7)
        'End If

        Cursor = Cursors.Default

        If rs_SYSETINF.Tables("result").Rows.Count = 0 Then
            Cursor = Cursors.Default
            MsgBox("No Record in SYSETINF.")

            Call setStatus("Init")
            Exit Sub
        Else
            Call fillcboImpCnt()
            Call fillcboPrcTrm()
            Call fillcboPayTrm()
            Call fillcboItmNo()
        End If



        gspStr = "sp_select_VNBASINF_VENNO '" & "" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_VNBASINF_VENNO :" & rtnStr)
            Exit Sub
        End If
        If rs_VNBASINF.Tables("result").Rows.Count = 0 Then
            Cursor = Cursors.Default
            MsgBox("No Record in SYSETINF.")
            Exit Sub
        Else
            Call fillcbovenno()
        End If


        'S = "¡ÀVNBASINF_VENNO¡°S"
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)
        'If rs(0)(0) <> "0" Then  '*** An error has occured
        '    MsgBox(rs(0)(0))
        'Else
        '    rs_VNBASINF = rs(1)
        '    Call fillcbovenno()
        'End If

        ' Timer1.Enabled = False

        Me.KeyPreview = True
        btcMPM00001.SelectedIndex = 0
        Call setStatus("Init")

        find_flag = False

        Cursor = Cursors.Default

        Recordstatus = False
    End Sub
    Private Sub MPM00001_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        '    Private Sub MPM00001_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ' Protected Overloads Overrides Sub MPM00001_Disposed(ByVal cancel As Boolean)
        'tempzzzzzzzzzzz

        Dim YesNoCancel As Integer
        If Recordstatus = True Then

            YesNoCancel = MsgBox("Do you want to save before clear the screen?", MsgBoxStyle.YesNoCancel)


            If YesNoCancel = vbYes Then
                If cmdSave.Enabled Then
                    flag_exit = True
                    Call cmdSaveClick()
                    If save_ok = True Then
                        Me.Close()
                    Else
                        flag_exit = False
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    flag_exit = False
                    MsgBox("You are not allow to save record!")
                    e.Cancel = True
                    Exit Sub
                End If

            ElseIf YesNoCancel = vbNo Then
                'Call ResetDefaultDisp
                Me.Close()

            ElseIf YesNoCancel = vbCancel Then
                flag_exit = False
                e.Cancel = True
                Exit Sub
            End If
        Else
            '      Me.Close()
        End If

    End Sub

    Private Sub grdSummary_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSummary.CellClick

        Recordstatus = True

        '''***)
        If e.RowIndex >= 0 And e.ColumnIndex = 0 Then
            '      grdSummary.Columns(e.ColumnIndex).ReadOnly = False
            '     If grdSummary.Columns(e.ColumnIndex).ReadOnly = False Then
            If rs_MPORDDTL.Tables("RESULT").DefaultView(e.RowIndex)("Del").ToString = "Y" Then
                rs_MPORDDTL.Tables("RESULT").DefaultView(e.RowIndex)("Del") = "N"

                If rs_MPORDDTL.Tables("RESULT").Rows(e.RowIndex).Item("Mpd_creusr") <> "~*ADD*~" And rs_MPORDDTL.Tables("RESULT").Rows(e.RowIndex).Item("Mpd_creusr") <> "~*NEW*~" Then
                    rs_MPORDDTL.Tables("RESULT").Rows(e.RowIndex).Item("Mpd_creusr") = "~*UPD*~"
                End If

                chkDelete.Checked = False
            Else
                rs_MPORDDTL.Tables("RESULT").DefaultView(e.RowIndex)("Del") = "Y"
                rs_MPORDDTL.Tables("RESULT").DefaultView(e.RowIndex)("Mpd_creusr") = "~*DEL*~"

                chkDelete.Checked = True
            End If
            rs_MPORDDTL.Tables("RESULT").AcceptChanges()
            'End If
        End If
        readingindex = e.RowIndex
        DisplayPODetail()

    End Sub
    Private Sub grdSummary_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdSummary.ColumnHeaderMouseClick
        Dim ColIndex
        ColIndex = e.ColumnIndex
        'tempz

        '    Private Sub grdSummary_HeadClick(ByVal ColIndex As Integer)
        If ColIndex = 2 Then
            rs_MPORDDTL.Tables("result").DefaultView.Sort = "Mpd_MPOseq"

        ElseIf ColIndex = 3 Then
            rs_MPORDDTL.Tables("result").DefaultView.Sort = "Mpd_PoNo"

        ElseIf ColIndex = 5 Then
            rs_MPORDDTL.Tables("result").DefaultView.Sort = "Mpd_PODat"



        ElseIf ColIndex = 6 Then
            rs_MPORDDTL.Tables("result").DefaultView.Sort = "Mpd_ShpDat"

        ElseIf ColIndex = 9 Then
            rs_MPORDDTL.Tables("result").DefaultView.Sort = "Mpd_VenItm"

        ElseIf ColIndex = 10 Then
            rs_MPORDDTL.Tables("result").DefaultView.Sort = "Mpd_ItmNo"

        End If



        '0       Mpd_CreUsr as 'mpd_status',
        '1       Mpd_MPONO,
        '2       Mpd_MPOseq,
        '3       Mpd_PONo,
        '4       Mpd_POSeq,
        '5       Mpd_PODat,
        '6       Mpd_ShpDat,
        '7       Mpd_OrgShpDat,
        '8       Mpd_ReqNo,
        '9       isnull(Mpd_VenItm,'') as 'Mpd_VenItm',
        '10      Mpd_ItmNo,
        '11      Mpd_ItmNam,
        '12      Mpd_ItmDsc,
        '13      Mpd_ColCde,
        '14      Mpd_UM,
        '15      Mpd_Qty,
        '16      Mpd_Dqty,
        '17      Mpd_ShpQty,
        '18      Mpd_UntPrc,
        '19      Mpd_MinPrc,
        '20      Mpd_PckMth,
        '21      Mpd_Dept,
        '22      Mpd_PrdNo,
        '23      Mpd_FilNamH,
        '24      Mpd_FilseqH,
        '25      Mpd_FilNam,
        '26      Mpd_Filseq,
        '27      Mpd_HdrRmk,
        '28      Mpd_Rmk,
        '29      Mpd_CreDat,
        '30      Mpd_CreUsr,
        '31      Mpd_UpdDat,
        '32      Mpd_UpdUsr,
        '33      @Mpd_TimStp AS 'Mpd_TimStp'

    End Sub

    Private Sub Label25_Click()

    End Sub

    Private Sub Label10_Click()

    End Sub

    Private Sub btcMPM00001_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcMPM00001.SelectedIndexChanged

        Dim varBookmark As Object

        If PreviousTab = 1 Then
            Call Update_PODtl()
        End If

        '--- Reset Label
        If AllowUpdate = True Then
            Label19.Visible = False
            txtCur3.Visible = False
            txtOrgUntPrc.Visible = False
            Label27.Visible = False
            Label33.Visible = False
            DTDOrgShpDat.Visible = False
            Label32.Visible = False
        Else
            Label19.Visible = True
            txtCur3.Visible = True
            txtOrgUntPrc.Visible = True
            Label27.Visible = True
            Label33.Visible = True
            DTDOrgShpDat.Visible = True
            Label32.Visible = True
        End If

        If ErrFlag = False Then
            If InputIsValid() = False Then
                ErrFlag = False
                Exit Sub
            End If
        End If

        If btcMPM00001.SelectedIndex = 0 Then
            PreviousTab = 0
            Call CalNetAmt()
        ElseIf btcMPM00001.SelectedIndex = 1 Then
            PreviousTab = 1
            If rs_MPORDDTL.Tables("result").Rows.Count > 0 Then
                Call DisplayPODetail()
            End If
        ElseIf btcMPM00001.SelectedIndex = 2 Then
            PreviousTab = 2
            grdSummary.DataSource = rs_MPORDDTL.Tables("result")
            grdSummary.Refresh()
            Call Display_Summary()
        End If

    End Sub

    Private Sub txtCur5_Change()

    End Sub


    Private Sub txtDiscnt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscnt.TextChanged
        If Trim(txtDiscnt.Text) = "" Then
            txtDiscnt.Text = "0"
        End If
    End Sub

    Private Sub txtDiscnt_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscnt.KeyPress
        e.KeyChar = Chr(check_numeric_size(txtDiscnt.Text, Asc(e.KeyChar), txtDiscnt.SelectionStart, 6, 3))
        'tempzz

    End Sub




    'Private Sub txtDRmk_Change()
    '    Recordstatus = True
    'End Sub
    Private Sub txtOrdQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrdQty.TextChanged

        Recordstatus = True
    End Sub

    Private Sub txtOrdQty_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrdQty.GotFocus

        Call HighlightText(txtOrdQty)
    End Sub

    Private Sub txtOrdQty_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrdQty.KeyPress

        'If (InStr("0123456789", Chr(KeyAscii)) = 0) And (KeyAscii > 31 Or KeyAscii < 0) Then
        '    KeyAscii = 0
        'ElseIf (Len(txtOrdQty.Text) + 1 > 7) And (KeyAscii > 31 Or KeyAscii < 0) Then
        '    KeyAscii = 0
        'End If
        e.KeyChar = Chr(check_numeric_size(txtOrdQty.Text, Asc(e.KeyChar), txtOrdQty.SelectionStart, 6, 3))



    End Sub

    Private Sub txtOrdQty_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrdQty.LostFocus

        If txtOrdQty.Text < rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_shpqty") Then
            MsgBox("Order Qty cannot less than shipped qty !")
            Call setFocus_text(txtOrdQty)
        End If

        If txtOrdQty.Text > 0 And txtUntPrc.Text > 0 Then
            txtSubTtlAmt.Text = (Int(((txtOrdQty.Text * txtUntPrc.Text) * 100) + 0.5)) / 100
            rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_subtotal") = txtSubTtlAmt.Text

        End If
    End Sub

    Private Sub txtPONo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPONo.GotFocus

        Call HighlightText(txtPONo)
    End Sub

    Private Sub txtPONo_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPONo.KeyPress
        If e.KeyChar = Chr(13) Then
            Call cmdfindClick()

        End If

    End Sub

    'Private Sub Timer1_Timer()
    '    'Timer1.Enabled = False
    '    Call cmdfindClick()
    'End Sub

    Private Sub txtRemAddr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemAddr.TextChanged
        Recordstatus = True
    End Sub

    'Private Sub txtRmk_Change()
    '    Recordstatus = True
    'End Sub

    Private Sub txtRmk_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRmk.GotFocus
        Call HighlightText_rich(txtRmk)

    End Sub

    Private Function ChkDate() As Boolean
        ChkDate = False

        'If CDate(txtShpStr.Text) < CDate(DTIssDat.Text) Then
        'msgbox "Ship Date should not be earlier than Issue Date"
        'txtShpStr.SetFocus
        'Exit Function
        'End If
        'If CDate(txtShpStr.Text) > CDate(txtShpEnd.Text) Then
        '    msgbox "Ship Start Date should not be greater than Ship End Date"
        '    If txtShpEnd.Enabled And txtShpEnd.Visible Then txtShpEnd.SetFocus
        '
        '    Exit Function
        '
        'End If
        'If CDate(txtShpEnd.Text) < CDate(DTIssDat.Text) Then
        'msgbox "Ship Date should not be earlier than Issue Date"
        'txtShpEnd.SetFocus
        'Exit Function
        'End If

        'If txtPoCDat.Text <> "  /  /    " Then
        'If CDate(txtPoCDat.Text) < CDate(DTIssDat.Text) Then
        'msgbox "PO Cancel Date should not be earlier than Issue Date"
        'txtPoCDat.SetFocus
        'Exit Function
        'End If
        'End If
        '    If txtPoCDat.Text <> "  /  /    " Then
        'If CDate(txtPoCDat.Text) < CDate(txtShpEnd.Text) Or CDate(txtPoCDat.Text) < CDate(txtShpStr.Text) Then
        '            msgbox "PO Cancel Date should not be earlier than Ship Date"
        '            If txtPoCDat.Enabled And txtPoCDat.Visible Then txtPoCDat.SetFocus
        '
        '            Exit Function
        '        End If
        '
        '    End If

        'If CDate(DTDShpStr.Text) < CDate(DTIssDat.Text) And rs_PODTLSHP.tables("result").rows.Count < 2 Then
        'msgbox "Ship Date should not be earlier than Issue Date"
        'DTDShpStr.SetFocus

        'Exit Function

        'End If
        '    If DTDCanDat.Text <> "  /  /    " Then
        '        'If CDate(DTDCanDat.Text) < CDate(DTIssDat.Text) Then
        '            'msgbox "PO Cancel Date should not be earlier than Issue Date"
        '            'DTDCanDat.SetFocus
        '            'Exit Function
        '        'End If
        '    End If
        '    If DTDCanDat.Text <> "  /  /    " Then
        '        If CDate(DTDCanDat.Text) < CDate(DTDShpEnd.Text) Or CDate(DTDCanDat.Text) < CDate(DTDShpStr.Text) Then
        '            msgbox "PO Cancel Date should not be earlier than Ship Date"
        '            If DTDCanDat.Enabled And DTDCanDat.Visible Then DTDCanDat.SetFocus
        '            Exit Function
        '        End If
        '    End If
        '    If CDate(DTDShpStr.Text) > CDate(DTDShpEnd.Text) Then
        '        msgbox "Ship Start Date should not be greater than Ship End Date"
        '        If DTDShpEnd.Enabled And DTDShpEnd.Visible Then DTDShpEnd.SetFocus
        '        Exit Function
        '    End If
        'If CDate(DTDShpEnd.Text) < CDate(DTIssDat.Text) Then
        'msgbox "Ship Date should not be earlier than Issue Date"
        'DTDShpEnd.SetFocus

        'Exit Function
        'End If

        'If CDate(txtLblDue.Text) < CDate(DTIssDat.Text) Then
        'msgbox "Label Due Date should not be earlier than Issue Date"
        'txtLblDue.SetFocus
        'Exit Function
        'End If


        ChkDate = True

    End Function
    Private Sub Display_Summary()
        Dim X As Integer
        Dim Y As Integer

        For Y = 0 To 0

            'For Y = 0 To grdSummary.Splits.count - 1
            '    grdSummary.Split = Y
            With grdSummary
                X = 0
                While X < rs_MPORDDTL.Tables("result").Columns.Count - 1
                    If grdSummary.Columns.Count = 0 Then
                        Exit Sub
                    End If
                    grdSummary.Columns(X).Visible = False
                    grdSummary.Columns(X).Width = 0



                    grdSummary.ReadOnly = True
                    'grdSummary.AllowUpdate = False
                    'grdSummary.Columns(X).readonly = True
                    X = X + 1
                End While

                '0       Mpd_CreUsr as 'mpd_status',
                '1       Mpd_MPONO,


                .Columns(0).ReadOnly = True
                .Columns(0).Width = 40 / 1.3
                .Columns(0).HeaderText = "Del"
                grdSummary.Columns(0).Visible = True


                .Columns(2).Width = 40 / 1.3
                .Columns(2).HeaderText = "Seq #"
                grdSummary.Columns(2).Visible = True

                .Columns(3).Width = 120 / 1.3
                .Columns(3).HeaderText = "PO No."
                grdSummary.Columns(3).Visible = True

                '4       Mpd_POSeq,

                .Columns(5).Width = 110 / 1.3
                .Columns(5).HeaderText = "PO Date"
                grdSummary.Columns(5).Visible = True

                .Columns(6).Width = 110 / 1.3
                .Columns(6).HeaderText = "Delivery Date"
                grdSummary.Columns(6).Visible = True

                .Columns(7).Width = 140 / 1.3
                .Columns(7).HeaderText = "Org Delivery Date"
                grdSummary.Columns(7).Visible = True


                '8       Mpd_ReqNo,

                .Columns(9).Width = 150 / 1.3
                .Columns(9).HeaderText = "Vendor Item #"
                grdSummary.Columns(9).Visible = True

                .Columns(10).Width = 130 / 1.3
                .Columns(10).HeaderText = "Item #"
                grdSummary.Columns(10).Visible = True

                .Columns(11).Width = 400 / 1.3
                .Columns(11).HeaderText = "Item Description"
                grdSummary.Columns(11).Visible = True

                '12      Mpd_ItmDsc,
                '13      Mpd_ColCde,

                .Columns(14).Width = 50 / 1.3
                .Columns(14).HeaderText = "UM"
                grdSummary.Columns(14).Visible = True

                .Columns(15).Width = 100 / 1.3
                .Columns(15).HeaderText = "Order Qty"

                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grdSummary.Columns(15).Visible = True


                .Columns(16).Width = 100 / 1.3
                .Columns(16).HeaderText = "Delivery Qty"
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grdSummary.Columns(16).Visible = True


                .Columns(17).Width = 100 / 1.3
                .Columns(17).HeaderText = "Shiped Qty"
                .Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grdSummary.Columns(17).Visible = True

                '    .Columns(17).width = 2000
                '    .Columns(17).HeaderText  = "Unit Price"
                '    .RightToLeft
                '18      Mpd_UntPrc,

                .Columns(19).Width = 150 / 1.3
                .Columns(19).HeaderText = "Unit Price"
                .Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grdSummary.Columns(19).Visible = True

                .Columns(20).Width = 150 / 1.3
                .Columns(20).HeaderText = "Sub Total"
                .Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grdSummary.Columns(20).Visible = True



                '18      Mpd_MinPrc,
                '19      Mpd_PckMth,
                '20      Mpd_Dept,
                '21      Mpd_PrdNo,
                '22      Mpd_FilNamH,
                '23      Mpd_FilseqH,
                '24      Mpd_FilNam,
                '25      Mpd_Filseq,
                '26      Mpd_HdrRmk,
                '27      Mpd_Rmk,
                '28      Mpd_CreDat,
                '29      Mpd_CreUsr,
                '30      Mpd_UpdDat,
                '31      Mpd_UpdUsr,
                '32      @Mpd_TimStp AS 'Mpd_TimStp'

            End With
        Next Y
    End Sub

    Private Sub Display_VenAddr()
        'Dim rs() As New ADOR.Recordset
        Dim S As String
        Dim venno As String


        'cboVenAddr.Items.Clear()
        'If Me.txtVendor.Text = "" Then Exit Sub

        venno = Trim(Microsoft.VisualBasic.Left(Me.cboVenNo.Text, InStr(Me.cboVenNo.Text, " - ")))


        'Marco Added for fixing global company code problem at 20040108
        'gsCompany = ""
        'Call Update_gs_Value(gsCompany)
        If venno <> "" Then

            Cursor = Cursors.WaitCursor
            gspStr = "sp_list_VNCNTINF '" & "" & "','" & venno & "','" & "M" & "','" & "ADR" & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_VNCNTINF, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading txtShpNoKeyPress sp_list_CVNCNTINF  :" & rtnStr)
                Exit Sub
            End If

            If rs_VNCNTINF.Tables("result").Rows.Count = 0 Then       '***  Not Found Record
                MsgBox("No vendor address found!")
                Exit Sub
            End If

            Me.cboVenAddr.Items.Add("")
            If rs_VNCNTINF.Tables("result").Rows.Count > 0 Then
                For index As Integer = 0 To rs_VNCNTINF.Tables("RESULT").Rows.Count - 1
                    cboVenAddr.Items.Add(Trim(IIf(rs_VNCNTINF.Tables("RESULT").Rows(index)("vci_chnadr") <> "", rs_VNCNTINF.Tables("RESULT").Rows(index)("vci_chnadr"), rs_VNCNTINF.Tables("RESULT").Rows(index)("vci_adr"))))
                Next
            End If
        End If

    End Sub

    Private Sub txtShpAdr_Change()
        Recordstatus = True
    End Sub

    Private Sub txtShpAdr_GotFocus()
        Call HighlightText_rich(txtShpAdr)
    End Sub

    Private Sub txtshpplc_Change()
        Recordstatus = True
    End Sub

    Private Sub txtUntPrc_Change()
        Recordstatus = True
    End Sub

    Private Sub txtUntPrc_GotFocus()
        Call HighlightText(txtUntPrc)
    End Sub

    Private Sub txtUntPrc_KeyPress(ByVal KeyAscii As Integer)
        If (InStr("0123456789.", Chr(KeyAscii)) = 0) And (KeyAscii > 31 Or KeyAscii < 0) Then
            KeyAscii = 0
        ElseIf (Len(txtUntPrc.Text) + 1 > 7) And (KeyAscii > 31 Or KeyAscii < 0) Then
            KeyAscii = 0
        End If
    End Sub

    Private Function InputIsValid() As Boolean

        InputIsValid = False
        ErrFlag = True

        If Not rs_MPORDHDR Is Nothing Then
            '--- checking header
            If cboVenNo.Text = "" Then
                MsgBox("Please Select Vendor No. !")
                btcMPM00001.SelectedIndex = 0
                Call setFocus_Combo(cboVenNo)
                Exit Function
            End If

            If cboImpCnt.Text = "" Then
                MsgBox("Please Select Import Contract !")
                btcMPM00001.SelectedIndex = 0
                Call setFocus_Combo(cboImpCnt)
                Exit Function
            End If

            If txtshpplc.Text = "" Then
                MsgBox("Please Input Delivery Place !")
                btcMPM00001.SelectedIndex = 0
                Call setFocus_text(txtshpplc)
                Exit Function
            End If
        End If


        '--- Checking Detail
        If Not rs_MPORDDTL Is Nothing Then
            'If chkDelete.checked = false And cboVenNo.Text <> "" And cboImpCnt.Text <> "" And rs_MPORDDTL.tables("result").rows.Count > 0 Then
            If chkDelete.Checked = False And rs_MPORDDTL.Tables("result").Rows.Count > 0 Then
                If cboItmNo.Text = "" Then
                    MsgBox("Please input Item No.")
                    btcMPM00001.SelectedIndex = 1
                    'cboItmNo.SetFocus  'Lester Wu 2006-03-07
                    Call setFocus_Combo(cboItmNo)
                    Exit Function
                End If

                'If cboUM.Text = "" Then
                'Frankie Cheung 20110728
                If cboUM.Text = "" And AllowUpdate = True Then
                    MsgBox("Please input UM")
                    btcMPM00001.SelectedIndex = 1
                    'cboUM.SetFocus 'Lester Wu 2006-03-07
                    Call setFocus_Combo(cboUM)
                    Exit Function
                End If

                If cboCurr.Text = "" Then
                    MsgBox("Please input Currency !")
                    btcMPM00001.SelectedIndex = 1
                    Call setFocus_Combo(cboCurr)
                    Exit Function
                End If

                If txtUntPrc.Text = 0 Then
                    MsgBox("Please input Unit Price !")
                    btcMPM00001.SelectedIndex = 1
                    Call setFocus_text(txtUntPrc)
                    Exit Function
                End If

                'If txtOrdQty.Text = "0" Then
                'Frankie Cheung 20110728
                If txtOrdQty.Text = "0" And AllowUpdate = True Then
                    MsgBox("Please input Order Qty !")
                    btcMPM00001.SelectedIndex = 1
                    Call setFocus_text(txtOrdQty)
                    Exit Function
                End If

                If DTDShpDat.Text = "  /  /    " Then
                    MsgBox("Please input Delivery Date !")
                    btcMPM00001.SelectedIndex = 1
                    Call setFocus_Mask_text(DTDShpDat)
                    Exit Function
                End If
            End If
        End If

        InputIsValid = True
        ErrFlag = False

    End Function

    Private Sub txtUntPrc_LostFocus()
        If txtOrdQty.Text > 0 And txtUntPrc.Text > 0 Then
            txtSubTtlAmt.Text = (Int(((txtOrdQty.Text * txtUntPrc.Text) * 100) + 0.5)) / 100
            rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_subtotal") = txtSubTtlAmt.Text

        End If
        If txtOrdQty.Text > 0 And txtUntPrc.Text > 0 Then
            txtSubTtlAmt.Text = (Int(((txtOrdQty.Text * txtUntPrc.Text) * 100) + 0.5)) / 100
            rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_subtotal") = txtSubTtlAmt.Text

        End If
    End Sub

    Private Sub txtVenitm_Change()
        Recordstatus = True
    End Sub

    Private Sub txtWTPONo_Change()
        Recordstatus = True
    End Sub

    Private Sub setFocus_Combo(ByVal cbo As ComboBox)
        If cbo.Enabled = True And cbo.Visible = True Then
            cbo.Focus()
            '        cbo.SelStart = 0
            '        cbo.SelLength = Len(cbo.Text)
        End If
    End Sub

    Private Sub setFocus_text(ByVal txt As TextBox)
        If txt.Enabled = True And txt.Visible = True Then
            txt.Focus()
            '        txt.SelStart = 0
            '        txt.SelLength = Len(txt.Text)
        End If
    End Sub

    Private Sub setFocus_Mask(ByVal txt As MaskedTextBox)

        If txt.Enabled = True And txt.Visible = True Then
            txt.Focus()
            '        txt.SelStart = 0
            '        txt.SelLength = Len(txt.Text)
        End If
    End Sub
    Private Sub setFocus_Mask_text(ByVal txt As TextBox)

        If txt.Enabled = True And txt.Visible = True Then
            txt.Focus()
            '        txt.SelStart = 0
            '        txt.SelLength = Len(txt.Text)
        End If
    End Sub
    Private Sub setFocus_Mask_rich(ByVal txt As RichTextBox)

        If txt.Enabled = True And txt.Visible = True Then
            txt.Focus()
            '        txt.SelStart = 0
            '        txt.SelLength = Len(txt.Text)
        End If
    End Sub



    Private Function ValidateCombo(ByVal Combo1 As ComboBox) As Boolean
        If Combo1.Text = "" Then
            ValidateCombo = True
            Exit Function
        End If
        ValidateCombo = False
        Dim i As Integer
        Dim S As String
        S = Combo1.Text
        For i = 0 To Combo1.Items.Count - 1
            If UCase(Combo1.Items(i).ToString) = UCase(S) Then
                ValidateCombo = True
                Exit Function
            End If
        Next
        If Not ValidateCombo Then
            MsgBox("Invalid Data! Please try again.")
            On Error Resume Next
            Combo1.Focus()
            On Error GoTo 0
        End If
    End Function
    Public Function IsInputBoxes(ByVal v As Object) As Boolean
        If (TypeOf v Is TextBox) Or (TypeOf v Is CheckBox) Or _
           (TypeOf v Is ComboBox) Or (TypeOf v Is CommandType) Or _
           (TypeOf v Is ListBox) Or (TypeOf v Is RadioButton) Or _
           (TypeOf v Is DataGrid) Or (TypeOf v Is BaseTabControl) Or (TypeOf v Is DateTimePicker) Or _
           (TypeOf v Is MaskedTextBox) Then
            'tempz
            IsInputBoxes = True
        Else
            IsInputBoxes = False
        End If


    End Function

    Private Sub grdSummary_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSummary.CellContentClick


    End Sub

    Public Function check_numeric_size(ByVal val As String, ByVal key As Integer, ByVal pos As Integer, ByVal p As Integer, ByVal d As Integer) As Integer

        val = Trim(val)



        If ((InStr("0123456789.", Chr(key)) = 0) And key > 31) Or _
            ((InStr(val, ".") <> 0) And key > 31 And Chr(key) = ".") Then
            check_numeric_size = 0

        ElseIf UBound(Split(val, ".")) = 0 Then
            If (Len(val) + 1 > p) And key > 31 And (Chr(key) <> ".") Then
                check_numeric_size = 0
            Else
                check_numeric_size = key
            End If

        ElseIf UBound(Split(val, ".")) > 0 Then

            If pos <= Len(Split(val, ".")(0)) Then

                If (Len(Split(val, ".")(0)) + 1 > p) And key > 31 Then
                    check_numeric_size = 0
                Else
                    check_numeric_size = key
                End If
            Else
                If (Len(Split(val, ".")(1)) + 1 > d) And key > 31 Then
                    check_numeric_size = 0
                Else
                    check_numeric_size = key
                End If
            End If
        Else
            check_numeric_size = key
        End If

    End Function
    Public Sub HighlightText(ByVal t As TextBox)
        t.SelectionStart = 0
        t.SelectionLength = Len(t.Text)
    End Sub
    Public Sub HighlightText_rich(ByVal t As RichTextBox)
        t.SelectionStart = 0
        t.SelectionLength = Len(t.Text)
    End Sub


    Private Sub cboPOStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPOStatus.SelectedIndexChanged

    End Sub

    Private Sub chkDelete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDelete.CheckedChanged

    End Sub

    Public Sub HighlightMask(ByVal t As MaskedTextBox)
        t.SelectionStart = 0
        t.SelectionLength = Len(t.Text)
    End Sub

    Public Sub HighlightMask_text(ByVal t As TextBox)
        t.SelectionStart = 0
        t.SelectionLength = Len(t.Text)
    End Sub


    Private Sub txtRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRmk.TextChanged
        Recordstatus = True
    End Sub

    Private Sub txtShpAdr_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShpAdr.GotFocus
        Call HighlightText_rich(txtShpAdr)
    End Sub

    Private Sub txtShpAdr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpAdr.TextChanged
        Recordstatus = True
    End Sub

    Private Sub txtshpplc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtshpplc.TextChanged
        Recordstatus = True
    End Sub

    Private Sub txtUntPrc_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUntPrc.GotFocus
        Call HighlightText(txtUntPrc)
    End Sub

    Private Sub txtUntPrc_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUntPrc.KeyPress
        If (InStr("0123456789.", e.KeyChar) = 0) And (Asc(e.KeyChar) > 31 Or Asc(e.KeyChar) < 0) Then
            e.KeyChar = Chr(0)
        ElseIf (Len(txtUntPrc.Text) + 1 > 7) And (Asc(e.KeyChar) > 31 Or Asc(e.KeyChar) < 0) Then
            e.KeyChar = Chr(0)
        End If

    End Sub

    Private Sub txtUntPrc_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUntPrc.LostFocus
        If txtOrdQty.Text > 0 And txtUntPrc.Text > 0 Then
            txtSubTtlAmt.Text = (Int(((txtOrdQty.Text * txtUntPrc.Text) * 100) + 0.5)) / 100
            rs_MPORDDTL.Tables("result").Rows(readingindex)("Mpd_subtotal") = txtSubTtlAmt.Text

        End If
    End Sub

    Private Sub txtUntPrc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUntPrc.TextChanged
        Recordstatus = True

    End Sub

    Private Sub txtVenitm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVenitm.TextChanged
        Recordstatus = True

    End Sub

    Private Sub txtWTPONo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWTPONo.TextChanged
        Recordstatus = True

    End Sub

    Private Sub txtPONo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPONo.TextChanged

    End Sub

    Private Sub txtItmNam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmNam.TextChanged


        If rs_MPORDDTL Is Nothing Then
            Exit Sub
        End If
        If rs_MPORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        Dim tmpstr
        tmpstr = txtItmNam.Text


        ''bug
        If Not IsDBNull(rs_MPORDDTL.Tables("RESULT").Rows(readingindex).Item("Mpd_ItmNam")) Then
            If tmpstr <> rs_MPORDDTL.Tables("RESULT").Rows(readingindex).Item("Mpd_ItmNam") Then
                Recordstatus = True
                If rs_MPORDDTL.Tables("RESULT").Rows(readingindex).Item("Mpd_CreUsr") <> "~*ADD*~" And rs_MPORDDTL.Tables("RESULT").Rows(readingindex).Item("Mpd_CreUsr") <> "~*NEW*~" Then
                    rs_MPORDDTL.Tables("RESULT").Rows(readingindex).Item("Mpd_CreUsr") = "~*UPD*~"
                End If
                rs_MPORDDTL.Tables("RESULT").Rows(readingindex).Item("Mpd_ItmNam") = tmpstr
            End If
        End If

    End Sub

    Private Sub cboImpCnt_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboImpCnt.Click
        'tempzz

        Recordstatus = True 'Lester Wu 2005-09-23

        If rs_GRNVENINF.Tables("result").Rows.Count > 0 And Trim(cboImpCnt.Text) <> "" Then
            rs_GRNVENINF.Tables("result").DefaultView.RowFilter = "gvi_invven ='" & Split(cboImpCnt.Text, " - ")(0) & "'"
            If rs_GRNVENINF.Tables("result").Rows.Count > 0 Then
                txtShpAdr.Text = rs_GRNVENINF.Tables("result").DefaultView(0)("gvi_venaddr")
                txtshpplc.Text = rs_GRNVENINF.Tables("result").DefaultView(0)("gvi_cc")
            End If
            rs_GRNVENINF.Tables("result").DefaultView.RowFilter = ""
        End If

    End Sub

    Private Sub cboImpCnt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboImpCnt.GotFocus
        flag_cboImpCnt_GotFocus = True
    End Sub

    Private Sub cboImpCnt_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboImpCnt.SelectedIndexChanged
        If flag_cboImpCnt_GotFocus = True Then
            flag_cboImpCnt_GotFocus = False

            Recordstatus = True 'Lester Wu 2005-09-23

            If rs_GRNVENINF.Tables("result").Rows.Count > 0 And Trim(cboImpCnt.Text) <> "" Then
                rs_GRNVENINF.Tables("result").DefaultView.RowFilter = "gvi_invven ='" & Split(cboImpCnt.Text, " - ")(0) & "'"
                If rs_GRNVENINF.Tables("result").Rows.Count > 0 Then
                    txtShpAdr.Text = rs_GRNVENINF.Tables("result").DefaultView(0)("gvi_venaddr")
                    txtshpplc.Text = rs_GRNVENINF.Tables("result").DefaultView(0)("gvi_cc")
                End If
                rs_GRNVENINF.Tables("result").DefaultView.RowFilter = ""
            End If

        End If

    End Sub

    Private Sub cboItmNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItmNo.SelectedIndexChanged
        If cboItmNo.Enabled = False Then Exit Sub
        Recordstatus = True
        If cboItmNo.Text <> "" Then
            txtItmNam.Text = Split(cboItmNo.Text, " - ")(1)
            If cboItmNo.Text <> "" Then
                cboUM.SelectedIndex = -1
                If Curr = "" Then
                    cboCurr.SelectedIndex = -1
                Else
                    cboCurr.Text = Curr
                End If
                txtUntPrc.Text = 0

                rs_ZSITMLST.Tables("result").DefaultView.RowFilter = "zil_itmno='" & Split(cboItmNo.Text, " - ")(0) & "'"
                If rs_ZSITMLST.Tables("result").DefaultView.Count > 0 Then
                    If rs_ZSITMLST.Tables("result").DefaultView(0)("zil_prc") > 0 Then
                        If Curr <> "" And rs_ZSITMLST.Tables("result").DefaultView(0)("zil_cur") <> Curr Then
                            MsgBox("Only Accept " & Curr & " currency in this MPO !")
                            'cboItmNo.SelectedIndex = -1
                            Call setFocus_Combo(cboItmNo)
                        Else
                            cboUM.Text = rs_ZSITMLST.Tables("result").DefaultView(0)("zil_um")
                            cboCurr.Text = rs_ZSITMLST.Tables("result").DefaultView(0)("zil_cur")
                            txtUntPrc.Text = rs_ZSITMLST.Tables("result").DefaultView(0)("zil_prc")
                        End If
                    End If
                End If
                rs_ZSITMLST.Tables("result").DefaultView.RowFilter = ""
            End If
        End If

    End Sub

    Private Sub tpMPM00001_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpMPM00001_3.Click

    End Sub

    Private Sub Label26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label26.Click

    End Sub
End Class














































































