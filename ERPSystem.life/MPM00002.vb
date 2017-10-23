Imports System.Collections.Generic
Class MPM00002

    Inherits System.Windows.Forms.Form

    Const stsMPO As Byte = 0
    Const stsAdHoc As Byte = 1
    Const stsMisc As Byte = 2

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim MPR03_right_local As Boolean

    Dim objBSGate As Object    '*** an object of "ucpBS_Gate.clsBSGate"

    Dim colShpQty As Long       '*** Column index of Ship Qty in grdDtlLst
    Dim colDtlRmk As Long

    Dim ColSeq As Integer
    Dim colGroup As Integer
    Dim colItmNo As Integer
    Dim colItmName As Integer
    Dim colType As Integer
    Dim colCTNFm As Integer
    Dim colCustCat As Integer

    Dim seq As Long
    Dim bolDisplay As Boolean

    Dim Recordstatus As Boolean
    '*** Folder 1
    Dim rs_IMPFTY As New DataSet 'A list of Custom Factory
    Dim rs_DEST As New DataSet   'A list of available destination
    Dim rs_CUSTCAT As New DataSet 'A list of Custom Category from SYMCATCDE
    Dim rs_DROPDOWN As New DataSet    'A list of country
    Dim rs_CURR As New DataSet   'A list of Currency


    Dim rs_MPONo As New DataSet  'A list of MPO No available for the select Custom Factory

    Dim rs_MPORDDTL_lst As New DataSet 'Detail list of selected MPO No
    Dim rs_MPORDDTL_dtl As New DataSet 'Detail info of selected item no

    Dim rs_GRNTRFHDR As New DataSet 'Store data of MPM00002 header
    Dim rs_GRNTRFDTL As New DataSet 'Store data of MPM00002 detail
    Dim rs_GRNTRFLST As New DataSet 'Store data of MPM00002 detail

    Dim rs_Group As New DataSet
    Dim rs_CTN As New DataSet

    Dim strMode As String
    Dim addFlag As Boolean
    Dim save_ok As Boolean
    Dim hdr_TimStp As Integer
    Dim dtl_TimStp As Integer
    Dim strCurr As String
    Dim strCurrGBL As String

    Dim dblExchange As Double
    Dim Dtl_ORIQTY As Double


    '2005-10-17, declare variables for cumulative ship qty and os qty
    Dim rs_CUMULATIVE As New DataSet

    ' Added by Mark Lau 20090617
    Dim rs_AllMPONo As New DataSet
    Dim readingindex As Integer
    Dim PreviousTab As Integer
    Dim gi_dgselstart As Integer
    Dim flag_cboImpFty_Click As Boolean
    Dim dr() As DataRow
    Dim isSorting As Boolean = False
    Dim flag_optType0_Click As Boolean
    Dim flag_optType1_Click As Boolean
    Dim flag_optType2_Click As Boolean
    Dim flag_cboDtl_KeyPress As Boolean
    Dim flag_cboCurr_GotFocus As Boolean

#Region " Windows Form Designer generated code"
    Friend WithEvents btcMPM00002 As ERPSystem.BaseTabControl
    Friend WithEvents tpMPM00002_1 As System.Windows.Forms.TabPage
    Friend WithEvents tpMPM00002_2 As System.Windows.Forms.TabPage
    Friend WithEvents txtGRNNo As System.Windows.Forms.TextBox
    Friend WithEvents txtRvsDat As System.Windows.Forms.TextBox
    Friend WithEvents lblRvsDat As System.Windows.Forms.Label
    Friend WithEvents txtIssDat As System.Windows.Forms.TextBox
    Friend WithEvents lblIssDat As System.Windows.Forms.Label
    Friend WithEvents cboImpFty As System.Windows.Forms.ComboBox
    Friend WithEvents tpMPM00002_3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents gbPri As System.Windows.Forms.GroupBox
    Friend WithEvents txtImpFtyAddr As System.Windows.Forms.RichTextBox
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
    Friend WithEvents cmdPrvD As System.Windows.Forms.Button
    Friend WithEvents cmdNextD As System.Windows.Forms.Button
    Friend WithEvents txtCusVen As System.Windows.Forms.TextBox
    Friend WithEvents txtVenNo As System.Windows.Forms.TextBox
    Friend WithEvents txtPurOrd As System.Windows.Forms.TextBox
    Friend WithEvents txtColCde As System.Windows.Forms.TextBox
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
    Friend WithEvents txtTtlNW As System.Windows.Forms.TextBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents RichTextBox3 As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDest As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtMode As System.Windows.Forms.TextBox
    Friend WithEvents cboCustUM_H As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtInvHdr As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDestAddr As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTtlCTN As System.Windows.Forms.TextBox
    Friend WithEvents txtTtlGW As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCTNFm As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPrtGrp As System.Windows.Forms.TextBox
    Friend WithEvents gbRelation As System.Windows.Forms.GroupBox
    Friend WithEvents optType2 As System.Windows.Forms.RadioButton
    Friend WithEvents optType1 As System.Windows.Forms.RadioButton
    Friend WithEvents optType0 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSeq As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTtlNW_D As System.Windows.Forms.TextBox
    Friend WithEvents txtNW As System.Windows.Forms.TextBox
    Friend WithEvents cboGroup As System.Windows.Forms.ComboBox
    Friend WithEvents cboDtl As System.Windows.Forms.ComboBox
    Friend WithEvents cboMPONo As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCat As System.Windows.Forms.ComboBox
    Friend WithEvents txtDept As System.Windows.Forms.TextBox

    Friend WithEvents txtItmNo As System.Windows.Forms.TextBox
    Friend WithEvents txtDtlRmk As System.Windows.Forms.RichTextBox
    Friend WithEvents cboCountry As System.Windows.Forms.ComboBox
    Friend WithEvents grdDtlLst As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCtrNo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTrdCty As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboInvUM_H As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAgtNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents 物料號 As System.Windows.Forms.Label
    Friend WithEvents lblDtlRmk As System.Windows.Forms.Label
    Friend WithEvents lblPONo As System.Windows.Forms.Label
    Friend WithEvents txtPONo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox19 As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox20 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCurr As System.Windows.Forms.ComboBox
    Friend WithEvents txtOSQty As System.Windows.Forms.TextBox
    Friend WithEvents txtTtlCTN_D As System.Windows.Forms.TextBox
    Friend WithEvents txtCTNTo As System.Windows.Forms.TextBox
    Friend WithEvents cboTtlCTN_D_UM As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtTtlGW_D_UM As System.Windows.Forms.TextBox
    Friend WithEvents txtGW_UM As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtTtlGW_D As System.Windows.Forms.TextBox
    Friend WithEvents txtGW As System.Windows.Forms.TextBox
    Friend WithEvents txtTtlNW_D_UM As System.Windows.Forms.TextBox
    Friend WithEvents txtNW_UM As System.Windows.Forms.TextBox
    Friend WithEvents txtPck_UM As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents txtPck As System.Windows.Forms.TextBox
    Friend WithEvents txtShpUM As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtShpQty As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents txtCustSubTtl As System.Windows.Forms.TextBox
    Friend WithEvents CboCustUM As System.Windows.Forms.ComboBox
    Friend WithEvents txtCustQty As System.Windows.Forms.TextBox
    Friend WithEvents txtUntPrc As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents cboCar As System.Windows.Forms.ComboBox
    Friend WithEvents txtDlvDat As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtItmNam As System.Windows.Forms.RichTextBox
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
    Friend WithEvents tsiMPR03 As System.Windows.Forms.ToolStripMenuItem

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MPM00002))
        Me.txtGRNNo = New System.Windows.Forms.TextBox
        Me.txtRvsDat = New System.Windows.Forms.TextBox
        Me.lblRvsDat = New System.Windows.Forms.Label
        Me.txtIssDat = New System.Windows.Forms.TextBox
        Me.lblIssDat = New System.Windows.Forms.Label
        Me.cboImpFty = New System.Windows.Forms.ComboBox
        Me.StatusBar = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.ComboBox6 = New System.Windows.Forms.ComboBox
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox
        Me.cboDest = New System.Windows.Forms.ComboBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.txtMode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label57 = New System.Windows.Forms.Label
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
        Me.btcMPM00002 = New ERPSystem.BaseTabControl
        Me.tpMPM00002_1 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cboInvUM_H = New System.Windows.Forms.ComboBox
        Me.GroupBox17 = New System.Windows.Forms.GroupBox
        Me.cboCustUM_H = New System.Windows.Forms.ComboBox
        Me.GroupBox16 = New System.Windows.Forms.GroupBox
        Me.txtDlvDat = New System.Windows.Forms.MaskedTextBox
        Me.GroupBox15 = New System.Windows.Forms.GroupBox
        Me.txtCtrNo = New System.Windows.Forms.TextBox
        Me.GroupBox14 = New System.Windows.Forms.GroupBox
        Me.cboCar = New System.Windows.Forms.ComboBox
        Me.GroupBox13 = New System.Windows.Forms.GroupBox
        Me.txtTrdCty = New System.Windows.Forms.TextBox
        Me.GroupBox18 = New System.Windows.Forms.GroupBox
        Me.txtAgtNo = New System.Windows.Forms.TextBox
        Me.GroupBox12 = New System.Windows.Forms.GroupBox
        Me.TextBox14 = New System.Windows.Forms.TextBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtTtlCTN = New System.Windows.Forms.TextBox
        Me.txtTtlGW = New System.Windows.Forms.TextBox
        Me.txtTtlNW = New System.Windows.Forms.TextBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.txtDestAddr = New System.Windows.Forms.RichTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtInvHdr = New System.Windows.Forms.TextBox
        Me.gbPri = New System.Windows.Forms.GroupBox
        Me.txtImpFtyAddr = New System.Windows.Forms.RichTextBox
        Me.tpMPM00002_2 = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox20 = New System.Windows.Forms.GroupBox
        Me.Label55 = New System.Windows.Forms.Label
        Me.Label54 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.CboCustUM = New System.Windows.Forms.ComboBox
        Me.txtCustQty = New System.Windows.Forms.TextBox
        Me.txtUntPrc = New System.Windows.Forms.TextBox
        Me.txtCustSubTtl = New System.Windows.Forms.TextBox
        Me.cboCurr = New System.Windows.Forms.ComboBox
        Me.GroupBox19 = New System.Windows.Forms.GroupBox
        Me.Label53 = New System.Windows.Forms.Label
        Me.txtShpUM = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtShpQty = New System.Windows.Forms.TextBox
        Me.txtOSQty = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtQty = New System.Windows.Forms.TextBox
        Me.grdDtlLst = New System.Windows.Forms.DataGridView
        Me.GroupBox11 = New System.Windows.Forms.GroupBox
        Me.lblPONo = New System.Windows.Forms.Label
        Me.txtPONo = New System.Windows.Forms.TextBox
        Me.物料號 = New System.Windows.Forms.Label
        Me.lblDtlRmk = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtColor = New System.Windows.Forms.TextBox
        Me.txtDtlRmk = New System.Windows.Forms.RichTextBox
        Me.cboCountry = New System.Windows.Forms.ComboBox
        Me.cboCat = New System.Windows.Forms.ComboBox
        Me.txtDept = New System.Windows.Forms.TextBox
        Me.txtItmNam = New System.Windows.Forms.RichTextBox
        Me.txtItmNo = New System.Windows.Forms.TextBox
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboDtl = New System.Windows.Forms.ComboBox
        Me.cboMPONo = New System.Windows.Forms.ComboBox
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.txtPck_UM = New System.Windows.Forms.TextBox
        Me.Label51 = New System.Windows.Forms.Label
        Me.txtPck = New System.Windows.Forms.TextBox
        Me.txtTtlGW_D_UM = New System.Windows.Forms.TextBox
        Me.txtGW_UM = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.txtTtlGW_D = New System.Windows.Forms.TextBox
        Me.txtGW = New System.Windows.Forms.TextBox
        Me.txtTtlNW_D_UM = New System.Windows.Forms.TextBox
        Me.txtNW_UM = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtTtlCTN_D = New System.Windows.Forms.TextBox
        Me.txtCTNTo = New System.Windows.Forms.TextBox
        Me.cboTtlCTN_D_UM = New System.Windows.Forms.ComboBox
        Me.cboGroup = New System.Windows.Forms.ComboBox
        Me.txtTtlNW_D = New System.Windows.Forms.TextBox
        Me.txtNW = New System.Windows.Forms.TextBox
        Me.txtCTNFm = New System.Windows.Forms.TextBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtSeq = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.gbRelation = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.optType2 = New System.Windows.Forms.RadioButton
        Me.optType1 = New System.Windows.Forms.RadioButton
        Me.optType0 = New System.Windows.Forms.RadioButton
        Me.txtPrtGrp = New System.Windows.Forms.TextBox
        Me.cmdNextD = New System.Windows.Forms.Button
        Me.cmdPrvD = New System.Windows.Forms.Button
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
        Me.tpMPM00002_3 = New System.Windows.Forms.TabPage
        Me.grdSummary = New System.Windows.Forms.DataGridView
        Me.tsiMPR03 = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuStrip.SuspendLayout()
        Me.btcMPM00002.SuspendLayout()
        Me.tpMPM00002_1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbPri.SuspendLayout()
        Me.tpMPM00002_2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox20.SuspendLayout()
        Me.GroupBox19.SuspendLayout()
        CType(Me.grdDtlLst, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.gbRelation.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.tpMPM00002_3.SuspendLayout()
        CType(Me.grdSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtGRNNo
        '
        Me.txtGRNNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtGRNNo.Location = New System.Drawing.Point(64, 34)
        Me.txtGRNNo.MaxLength = 10
        Me.txtGRNNo.Name = "txtGRNNo"
        Me.txtGRNNo.Size = New System.Drawing.Size(121, 20)
        Me.txtGRNNo.TabIndex = 0
        '
        'txtRvsDat
        '
        Me.txtRvsDat.Enabled = False
        Me.txtRvsDat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtRvsDat.Location = New System.Drawing.Point(807, 36)
        Me.txtRvsDat.MaxLength = 10
        Me.txtRvsDat.Name = "txtRvsDat"
        Me.txtRvsDat.Size = New System.Drawing.Size(83, 20)
        Me.txtRvsDat.TabIndex = 6
        '
        'lblRvsDat
        '
        Me.lblRvsDat.AutoSize = True
        Me.lblRvsDat.Location = New System.Drawing.Point(735, 38)
        Me.lblRvsDat.Name = "lblRvsDat"
        Me.lblRvsDat.Size = New System.Drawing.Size(60, 12)
        Me.lblRvsDat.TabIndex = 267
        Me.lblRvsDat.Text = "Revise Date"
        '
        'txtIssDat
        '
        Me.txtIssDat.Enabled = False
        Me.txtIssDat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtIssDat.Location = New System.Drawing.Point(647, 36)
        Me.txtIssDat.MaxLength = 10
        Me.txtIssDat.Name = "txtIssDat"
        Me.txtIssDat.Size = New System.Drawing.Size(78, 20)
        Me.txtIssDat.TabIndex = 3
        '
        'lblIssDat
        '
        Me.lblIssDat.AutoSize = True
        Me.lblIssDat.Location = New System.Drawing.Point(583, 38)
        Me.lblIssDat.Name = "lblIssDat"
        Me.lblIssDat.Size = New System.Drawing.Size(52, 12)
        Me.lblIssDat.TabIndex = 266
        Me.lblIssDat.Text = "Issue Date"
        '
        'cboImpFty
        '
        Me.cboImpFty.FormattingEnabled = True
        Me.cboImpFty.Location = New System.Drawing.Point(267, 36)
        Me.cboImpFty.Name = "cboImpFty"
        Me.cboImpFty.Size = New System.Drawing.Size(113, 20)
        Me.cboImpFty.TabIndex = 1
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
        Me.StatusBarPanel1.Width = 468
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel2.Name = "StatusBarPanel2"
        Me.StatusBarPanel2.Width = 468
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
        'cboDest
        '
        Me.cboDest.FormattingEnabled = True
        Me.cboDest.Location = New System.Drawing.Point(460, 36)
        Me.cboDest.Name = "cboDest"
        Me.cboDest.Size = New System.Drawing.Size(113, 20)
        Me.cboDest.TabIndex = 2
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(14, 37)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(49, 12)
        Me.Label32.TabIndex = 278
        Me.Label32.Text = "GRN No."
        '
        'txtMode
        '
        Me.txtMode.Enabled = False
        Me.txtMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtMode.Location = New System.Drawing.Point(896, 36)
        Me.txtMode.MaxLength = 10
        Me.txtMode.Name = "txtMode"
        Me.txtMode.Size = New System.Drawing.Size(51, 20)
        Me.txtMode.TabIndex = 279
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(191, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 283
        Me.Label2.Text = "Custom Fty"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.BackColor = System.Drawing.Color.Transparent
        Me.Label57.ForeColor = System.Drawing.Color.Green
        Me.Label57.Location = New System.Drawing.Point(391, 38)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(57, 12)
        Me.Label57.TabIndex = 284
        Me.Label57.Text = "Destination"
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
        Me.menuStrip.TabIndex = 285
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
        Me.mmdPrint.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsiMPR03})
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
        Me.mmdRel.Size = New System.Drawing.Size(152, 22)
        Me.mmdRel.Text = "Release"
        '
        'mmdApv
        '
        Me.mmdApv.Name = "mmdApv"
        Me.mmdApv.Size = New System.Drawing.Size(152, 22)
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
        'btcMPM00002
        '
        Me.btcMPM00002.Controls.Add(Me.tpMPM00002_1)
        Me.btcMPM00002.Controls.Add(Me.tpMPM00002_2)
        Me.btcMPM00002.Controls.Add(Me.tpMPM00002_3)
        Me.btcMPM00002.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.btcMPM00002.Location = New System.Drawing.Point(0, 60)
        Me.btcMPM00002.Name = "btcMPM00002"
        Me.btcMPM00002.SelectedIndex = 0
        Me.btcMPM00002.Size = New System.Drawing.Size(954, 539)
        Me.btcMPM00002.TabIndex = 44
        '
        'tpMPM00002_1
        '
        Me.tpMPM00002_1.Controls.Add(Me.GroupBox2)
        Me.tpMPM00002_1.Location = New System.Drawing.Point(4, 22)
        Me.tpMPM00002_1.Name = "tpMPM00002_1"
        Me.tpMPM00002_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMPM00002_1.Size = New System.Drawing.Size(946, 513)
        Me.tpMPM00002_1.TabIndex = 0
        Me.tpMPM00002_1.Text = "(1) Header"
        Me.tpMPM00002_1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox17)
        Me.GroupBox2.Controls.Add(Me.GroupBox16)
        Me.GroupBox2.Controls.Add(Me.GroupBox15)
        Me.GroupBox2.Controls.Add(Me.GroupBox14)
        Me.GroupBox2.Controls.Add(Me.GroupBox13)
        Me.GroupBox2.Controls.Add(Me.GroupBox18)
        Me.GroupBox2.Controls.Add(Me.GroupBox12)
        Me.GroupBox2.Controls.Add(Me.GroupBox7)
        Me.GroupBox2.Controls.Add(Me.GroupBox6)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.gbPri)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(935, 504)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboInvUM_H)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Green
        Me.GroupBox4.Location = New System.Drawing.Point(796, 61)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(116, 47)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Invoice UM"
        '
        'cboInvUM_H
        '
        Me.cboInvUM_H.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboInvUM_H.FormattingEnabled = True
        Me.cboInvUM_H.Location = New System.Drawing.Point(8, 18)
        Me.cboInvUM_H.Name = "cboInvUM_H"
        Me.cboInvUM_H.Size = New System.Drawing.Size(96, 21)
        Me.cboInvUM_H.TabIndex = 13
        '
        'GroupBox17
        '
        Me.GroupBox17.Controls.Add(Me.cboCustUM_H)
        Me.GroupBox17.ForeColor = System.Drawing.Color.Green
        Me.GroupBox17.Location = New System.Drawing.Point(796, 8)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(116, 47)
        Me.GroupBox17.TabIndex = 12
        Me.GroupBox17.TabStop = False
        Me.GroupBox17.Text = "Custom UM"
        '
        'cboCustUM_H
        '
        Me.cboCustUM_H.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboCustUM_H.FormattingEnabled = True
        Me.cboCustUM_H.Location = New System.Drawing.Point(8, 18)
        Me.cboCustUM_H.Name = "cboCustUM_H"
        Me.cboCustUM_H.Size = New System.Drawing.Size(96, 21)
        Me.cboCustUM_H.TabIndex = 271
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.txtDlvDat)
        Me.GroupBox16.ForeColor = System.Drawing.Color.Green
        Me.GroupBox16.Location = New System.Drawing.Point(461, 270)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(322, 47)
        Me.GroupBox16.TabIndex = 11
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "Delivery Date"
        '
        'txtDlvDat
        '
        Me.txtDlvDat.Location = New System.Drawing.Point(11, 16)
        Me.txtDlvDat.Mask = "##/##/####"
        Me.txtDlvDat.Name = "txtDlvDat"
        Me.txtDlvDat.Size = New System.Drawing.Size(127, 22)
        Me.txtDlvDat.TabIndex = 11
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.txtCtrNo)
        Me.GroupBox15.ForeColor = System.Drawing.Color.Green
        Me.GroupBox15.Location = New System.Drawing.Point(459, 220)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(322, 47)
        Me.GroupBox15.TabIndex = 10
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Container No."
        '
        'txtCtrNo
        '
        Me.txtCtrNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCtrNo.Location = New System.Drawing.Point(11, 17)
        Me.txtCtrNo.MaxLength = 20
        Me.txtCtrNo.Name = "txtCtrNo"
        Me.txtCtrNo.Size = New System.Drawing.Size(301, 20)
        Me.txtCtrNo.TabIndex = 10
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.cboCar)
        Me.GroupBox14.ForeColor = System.Drawing.Color.Green
        Me.GroupBox14.Location = New System.Drawing.Point(461, 167)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(322, 47)
        Me.GroupBox14.TabIndex = 9
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Transportation"
        '
        'cboCar
        '
        Me.cboCar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboCar.FormattingEnabled = True
        Me.cboCar.Location = New System.Drawing.Point(11, 17)
        Me.cboCar.Name = "cboCar"
        Me.cboCar.Size = New System.Drawing.Size(299, 21)
        Me.cboCar.TabIndex = 9
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.txtTrdCty)
        Me.GroupBox13.ForeColor = System.Drawing.Color.Green
        Me.GroupBox13.Location = New System.Drawing.Point(461, 114)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(322, 47)
        Me.GroupBox13.TabIndex = 8
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Trading Country"
        '
        'txtTrdCty
        '
        Me.txtTrdCty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTrdCty.Location = New System.Drawing.Point(11, 17)
        Me.txtTrdCty.MaxLength = 20
        Me.txtTrdCty.Name = "txtTrdCty"
        Me.txtTrdCty.Size = New System.Drawing.Size(301, 20)
        Me.txtTrdCty.TabIndex = 8
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.txtAgtNo)
        Me.GroupBox18.ForeColor = System.Drawing.Color.Green
        Me.GroupBox18.Location = New System.Drawing.Point(461, 61)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(322, 47)
        Me.GroupBox18.TabIndex = 7
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "Agreement No"
        '
        'txtAgtNo
        '
        Me.txtAgtNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtAgtNo.Location = New System.Drawing.Point(11, 17)
        Me.txtAgtNo.MaxLength = 20
        Me.txtAgtNo.Name = "txtAgtNo"
        Me.txtAgtNo.Size = New System.Drawing.Size(301, 20)
        Me.txtAgtNo.TabIndex = 7
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.TextBox14)
        Me.GroupBox12.ForeColor = System.Drawing.Color.Green
        Me.GroupBox12.Location = New System.Drawing.Point(461, 61)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(322, 47)
        Me.GroupBox12.TabIndex = 292
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Invoice Header"
        '
        'TextBox14
        '
        Me.TextBox14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TextBox14.Location = New System.Drawing.Point(6, 17)
        Me.TextBox14.MaxLength = 20
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(301, 20)
        Me.TextBox14.TabIndex = 281
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label12)
        Me.GroupBox7.Controls.Add(Me.Label11)
        Me.GroupBox7.Controls.Add(Me.Label10)
        Me.GroupBox7.Controls.Add(Me.Label9)
        Me.GroupBox7.Controls.Add(Me.Label8)
        Me.GroupBox7.Controls.Add(Me.Label7)
        Me.GroupBox7.Controls.Add(Me.txtTtlCTN)
        Me.GroupBox7.Controls.Add(Me.txtTtlGW)
        Me.GroupBox7.Controls.Add(Me.txtTtlNW)
        Me.GroupBox7.ForeColor = System.Drawing.Color.Black
        Me.GroupBox7.Location = New System.Drawing.Point(6, 224)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(449, 93)
        Me.GroupBox7.TabIndex = 291
        Me.GroupBox7.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(224, 68)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(28, 12)
        Me.Label12.TabIndex = 289
        Me.Label12.Text = "CTN"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(224, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(21, 12)
        Me.Label11.TabIndex = 288
        Me.Label11.Text = "KG"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(224, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(21, 12)
        Me.Label10.TabIndex = 287
        Me.Label10.Text = "KG"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(21, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 12)
        Me.Label9.TabIndex = 286
        Me.Label9.Text = "Total CTN"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 12)
        Me.Label8.TabIndex = 285
        Me.Label8.Text = "Total G.W."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 12)
        Me.Label7.TabIndex = 284
        Me.Label7.Text = "Total N.W."
        '
        'txtTtlCTN
        '
        Me.txtTtlCTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTtlCTN.Location = New System.Drawing.Point(100, 66)
        Me.txtTtlCTN.MaxLength = 20
        Me.txtTtlCTN.Name = "txtTtlCTN"
        Me.txtTtlCTN.Size = New System.Drawing.Size(112, 20)
        Me.txtTtlCTN.TabIndex = 283
        '
        'txtTtlGW
        '
        Me.txtTtlGW.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTtlGW.Location = New System.Drawing.Point(100, 43)
        Me.txtTtlGW.MaxLength = 20
        Me.txtTtlGW.Name = "txtTtlGW"
        Me.txtTtlGW.Size = New System.Drawing.Size(112, 20)
        Me.txtTtlGW.TabIndex = 282
        '
        'txtTtlNW
        '
        Me.txtTtlNW.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTtlNW.Location = New System.Drawing.Point(101, 19)
        Me.txtTtlNW.MaxLength = 20
        Me.txtTtlNW.Name = "txtTtlNW"
        Me.txtTtlNW.Size = New System.Drawing.Size(112, 20)
        Me.txtTtlNW.TabIndex = 281
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtDestAddr)
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(6, 116)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(449, 106)
        Me.GroupBox6.TabIndex = 5
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Destination Address"
        '
        'txtDestAddr
        '
        Me.txtDestAddr.Location = New System.Drawing.Point(6, 15)
        Me.txtDestAddr.Name = "txtDestAddr"
        Me.txtDestAddr.Size = New System.Drawing.Size(437, 85)
        Me.txtDestAddr.TabIndex = 5
        Me.txtDestAddr.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtInvHdr)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Green
        Me.GroupBox1.Location = New System.Drawing.Point(461, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(322, 47)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Invoice Header"
        '
        'txtInvHdr
        '
        Me.txtInvHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtInvHdr.Location = New System.Drawing.Point(11, 17)
        Me.txtInvHdr.MaxLength = 20
        Me.txtInvHdr.Name = "txtInvHdr"
        Me.txtInvHdr.Size = New System.Drawing.Size(301, 20)
        Me.txtInvHdr.TabIndex = 6
        '
        'gbPri
        '
        Me.gbPri.Controls.Add(Me.txtImpFtyAddr)
        Me.gbPri.ForeColor = System.Drawing.Color.Black
        Me.gbPri.Location = New System.Drawing.Point(5, 8)
        Me.gbPri.Name = "gbPri"
        Me.gbPri.Size = New System.Drawing.Size(449, 106)
        Me.gbPri.TabIndex = 4
        Me.gbPri.TabStop = False
        Me.gbPri.Text = "Custom Factory Address"
        '
        'txtImpFtyAddr
        '
        Me.txtImpFtyAddr.Location = New System.Drawing.Point(6, 15)
        Me.txtImpFtyAddr.Name = "txtImpFtyAddr"
        Me.txtImpFtyAddr.Size = New System.Drawing.Size(437, 85)
        Me.txtImpFtyAddr.TabIndex = 4
        Me.txtImpFtyAddr.Text = ""
        '
        'tpMPM00002_2
        '
        Me.tpMPM00002_2.Controls.Add(Me.GroupBox3)
        Me.tpMPM00002_2.Controls.Add(Me.txtmodvol)
        Me.tpMPM00002_2.Controls.Add(Me.txtCusVen)
        Me.tpMPM00002_2.Controls.Add(Me.txtVenNo)
        Me.tpMPM00002_2.Controls.Add(Me.cboPCPrc)
        Me.tpMPM00002_2.Controls.Add(Me.optSearch1)
        Me.tpMPM00002_2.Controls.Add(Me.optSearch0)
        Me.tpMPM00002_2.Controls.Add(Me.Label30)
        Me.tpMPM00002_2.Controls.Add(Me.txtPurOrd)
        Me.tpMPM00002_2.Controls.Add(Me.txtVol)
        Me.tpMPM00002_2.Controls.Add(Me.txtColCde)
        Me.tpMPM00002_2.Controls.Add(Me.Label39)
        Me.tpMPM00002_2.Controls.Add(Me.txtMtrCtn)
        Me.tpMPM00002_2.Controls.Add(Me.Label40)
        Me.tpMPM00002_2.Controls.Add(Me.Label56)
        Me.tpMPM00002_2.Controls.Add(Me.GroupBox5)
        Me.tpMPM00002_2.Controls.Add(Me.optCtrSiz3)
        Me.tpMPM00002_2.Controls.Add(Me.optCtrSiz4)
        Me.tpMPM00002_2.Controls.Add(Me.optCtrSiz0)
        Me.tpMPM00002_2.Controls.Add(Me.optCtrSiz1)
        Me.tpMPM00002_2.Controls.Add(Me.optCtrSiz2)
        Me.tpMPM00002_2.Controls.Add(Me.txtCustUM)
        Me.tpMPM00002_2.Controls.Add(Me.Label27)
        Me.tpMPM00002_2.Location = New System.Drawing.Point(4, 22)
        Me.tpMPM00002_2.Name = "tpMPM00002_2"
        Me.tpMPM00002_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMPM00002_2.Size = New System.Drawing.Size(946, 513)
        Me.tpMPM00002_2.TabIndex = 1
        Me.tpMPM00002_2.Text = "(2) Details"
        Me.tpMPM00002_2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox20)
        Me.GroupBox3.Controls.Add(Me.GroupBox19)
        Me.GroupBox3.Controls.Add(Me.grdDtlLst)
        Me.GroupBox3.Controls.Add(Me.GroupBox11)
        Me.GroupBox3.Controls.Add(Me.GroupBox10)
        Me.GroupBox3.Controls.Add(Me.GroupBox9)
        Me.GroupBox3.Controls.Add(Me.GroupBox8)
        Me.GroupBox3.Controls.Add(Me.cmdNextD)
        Me.GroupBox3.Controls.Add(Me.cmdPrvD)
        Me.GroupBox3.Controls.Add(Me.chkDelete)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(938, 507)
        Me.GroupBox3.TabIndex = 363
        Me.GroupBox3.TabStop = False
        '
        'GroupBox20
        '
        Me.GroupBox20.Controls.Add(Me.Label55)
        Me.GroupBox20.Controls.Add(Me.Label54)
        Me.GroupBox20.Controls.Add(Me.Label24)
        Me.GroupBox20.Controls.Add(Me.Label23)
        Me.GroupBox20.Controls.Add(Me.CboCustUM)
        Me.GroupBox20.Controls.Add(Me.txtCustQty)
        Me.GroupBox20.Controls.Add(Me.txtUntPrc)
        Me.GroupBox20.Controls.Add(Me.txtCustSubTtl)
        Me.GroupBox20.Controls.Add(Me.cboCurr)
        Me.GroupBox20.ForeColor = System.Drawing.Color.Black
        Me.GroupBox20.Location = New System.Drawing.Point(477, 161)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Size = New System.Drawing.Size(453, 63)
        Me.GroupBox20.TabIndex = 41
        Me.GroupBox20.TabStop = False
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(255, 40)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(51, 12)
        Me.Label55.TabIndex = 297
        Me.Label55.Text = "Sub-Total"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(256, 15)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(46, 12)
        Me.Label54.TabIndex = 296
        Me.Label54.Text = "Cust Qty"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(107, 14)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(51, 12)
        Me.Label24.TabIndex = 295
        Me.Label24.Text = "Unit Price"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(4, 15)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(27, 12)
        Me.Label23.TabIndex = 294
        Me.Label23.Text = "Curr"
        '
        'CboCustUM
        '
        Me.CboCustUM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CboCustUM.FormattingEnabled = True
        Me.CboCustUM.Location = New System.Drawing.Point(375, 10)
        Me.CboCustUM.Name = "CboCustUM"
        Me.CboCustUM.Size = New System.Drawing.Size(63, 21)
        Me.CboCustUM.TabIndex = 45
        '
        'txtCustQty
        '
        Me.txtCustQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCustQty.Location = New System.Drawing.Point(309, 11)
        Me.txtCustQty.MaxLength = 20
        Me.txtCustQty.Name = "txtCustQty"
        Me.txtCustQty.Size = New System.Drawing.Size(62, 20)
        Me.txtCustQty.TabIndex = 44
        '
        'txtUntPrc
        '
        Me.txtUntPrc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtUntPrc.Location = New System.Drawing.Point(165, 12)
        Me.txtUntPrc.MaxLength = 20
        Me.txtUntPrc.Name = "txtUntPrc"
        Me.txtUntPrc.Size = New System.Drawing.Size(67, 20)
        Me.txtUntPrc.TabIndex = 43
        '
        'txtCustSubTtl
        '
        Me.txtCustSubTtl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCustSubTtl.Location = New System.Drawing.Point(309, 36)
        Me.txtCustSubTtl.MaxLength = 20
        Me.txtCustSubTtl.Name = "txtCustSubTtl"
        Me.txtCustSubTtl.Size = New System.Drawing.Size(129, 20)
        Me.txtCustSubTtl.TabIndex = 46
        '
        'cboCurr
        '
        Me.cboCurr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboCurr.FormattingEnabled = True
        Me.cboCurr.Location = New System.Drawing.Point(34, 11)
        Me.cboCurr.Name = "cboCurr"
        Me.cboCurr.Size = New System.Drawing.Size(63, 21)
        Me.cboCurr.TabIndex = 42
        '
        'GroupBox19
        '
        Me.GroupBox19.Controls.Add(Me.Label53)
        Me.GroupBox19.Controls.Add(Me.txtShpUM)
        Me.GroupBox19.Controls.Add(Me.Label22)
        Me.GroupBox19.Controls.Add(Me.txtShpQty)
        Me.GroupBox19.Controls.Add(Me.txtOSQty)
        Me.GroupBox19.Controls.Add(Me.Label21)
        Me.GroupBox19.Controls.Add(Me.txtQty)
        Me.GroupBox19.ForeColor = System.Drawing.Color.Black
        Me.GroupBox19.Location = New System.Drawing.Point(477, 116)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Size = New System.Drawing.Size(453, 44)
        Me.GroupBox19.TabIndex = 36
        Me.GroupBox19.TabStop = False
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(121, 19)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(39, 12)
        Me.Label53.TabIndex = 310
        Me.Label53.Text = "OS Qty"
        '
        'txtShpUM
        '
        Me.txtShpUM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtShpUM.Location = New System.Drawing.Point(397, 15)
        Me.txtShpUM.MaxLength = 20
        Me.txtShpUM.Name = "txtShpUM"
        Me.txtShpUM.Size = New System.Drawing.Size(41, 20)
        Me.txtShpUM.TabIndex = 40
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(255, 19)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(46, 12)
        Me.Label22.TabIndex = 308
        Me.Label22.Text = "Ship Qty"
        '
        'txtShpQty
        '
        Me.txtShpQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtShpQty.Location = New System.Drawing.Point(310, 16)
        Me.txtShpQty.MaxLength = 20
        Me.txtShpQty.Name = "txtShpQty"
        Me.txtShpQty.Size = New System.Drawing.Size(60, 20)
        Me.txtShpQty.TabIndex = 39
        '
        'txtOSQty
        '
        Me.txtOSQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtOSQty.Location = New System.Drawing.Point(165, 16)
        Me.txtOSQty.MaxLength = 20
        Me.txtOSQty.Name = "txtOSQty"
        Me.txtOSQty.Size = New System.Drawing.Size(67, 20)
        Me.txtOSQty.TabIndex = 38
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(2, 19)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(52, 12)
        Me.Label21.TabIndex = 285
        Me.Label21.Text = "Order Qty"
        '
        'txtQty
        '
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtQty.Location = New System.Drawing.Point(55, 16)
        Me.txtQty.MaxLength = 20
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(52, 20)
        Me.txtQty.TabIndex = 37
        '
        'grdDtlLst
        '
        Me.grdDtlLst.AllowUserToAddRows = False
        Me.grdDtlLst.AllowUserToDeleteRows = False
        Me.grdDtlLst.ColumnHeadersHeight = 20
        Me.grdDtlLst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdDtlLst.Location = New System.Drawing.Point(7, 299)
        Me.grdDtlLst.Name = "grdDtlLst"
        Me.grdDtlLst.RowHeadersWidth = 20
        Me.grdDtlLst.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDtlLst.RowTemplate.Height = 16
        Me.grdDtlLst.Size = New System.Drawing.Size(921, 202)
        Me.grdDtlLst.TabIndex = 368
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.lblPONo)
        Me.GroupBox11.Controls.Add(Me.txtPONo)
        Me.GroupBox11.Controls.Add(Me.物料號)
        Me.GroupBox11.Controls.Add(Me.lblDtlRmk)
        Me.GroupBox11.Controls.Add(Me.Label17)
        Me.GroupBox11.Controls.Add(Me.Label16)
        Me.GroupBox11.Controls.Add(Me.Label15)
        Me.GroupBox11.Controls.Add(Me.Label14)
        Me.GroupBox11.Controls.Add(Me.Label13)
        Me.GroupBox11.Controls.Add(Me.txtColor)
        Me.GroupBox11.Controls.Add(Me.txtDtlRmk)
        Me.GroupBox11.Controls.Add(Me.cboCountry)
        Me.GroupBox11.Controls.Add(Me.cboCat)
        Me.GroupBox11.Controls.Add(Me.txtDept)
        Me.GroupBox11.Controls.Add(Me.txtItmNam)
        Me.GroupBox11.Controls.Add(Me.txtItmNo)
        Me.GroupBox11.ForeColor = System.Drawing.Color.Black
        Me.GroupBox11.Location = New System.Drawing.Point(7, 116)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(464, 176)
        Me.GroupBox11.TabIndex = 11
        Me.GroupBox11.TabStop = False
        '
        'lblPONo
        '
        Me.lblPONo.AutoSize = True
        Me.lblPONo.Location = New System.Drawing.Point(222, 104)
        Me.lblPONo.Name = "lblPONo"
        Me.lblPONo.Size = New System.Drawing.Size(82, 12)
        Me.lblPONo.TabIndex = 297
        Me.lblPONo.Text = "PO No. /Ref No."
        '
        'txtPONo
        '
        Me.txtPONo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPONo.Location = New System.Drawing.Point(289, 101)
        Me.txtPONo.MaxLength = 20
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.Size = New System.Drawing.Size(168, 20)
        Me.txtPONo.TabIndex = 18
        '
        '物料號
        '
        Me.物料號.AutoSize = True
        Me.物料號.Location = New System.Drawing.Point(251, 15)
        Me.物料號.Name = "物料號"
        Me.物料號.Size = New System.Drawing.Size(41, 12)
        Me.物料號.TabIndex = 295
        Me.物料號.Text = "物料號"
        '
        'lblDtlRmk
        '
        Me.lblDtlRmk.AutoSize = True
        Me.lblDtlRmk.Location = New System.Drawing.Point(17, 125)
        Me.lblDtlRmk.Name = "lblDtlRmk"
        Me.lblDtlRmk.Size = New System.Drawing.Size(42, 12)
        Me.lblDtlRmk.TabIndex = 294
        Me.lblDtlRmk.Text = "Remark"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(17, 103)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 12)
        Me.Label17.TabIndex = 293
        Me.Label17.Text = "Country"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(17, 81)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 12)
        Me.Label16.TabIndex = 292
        Me.Label16.Text = "Recv Dept"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(17, 59)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 12)
        Me.Label15.TabIndex = 291
        Me.Label15.Text = "Custom Cat"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(17, 37)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 12)
        Me.Label14.TabIndex = 290
        Me.Label14.Text = "Item Name"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 12)
        Me.Label13.TabIndex = 289
        Me.Label13.Text = "Item No"
        '
        'txtColor
        '
        Me.txtColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtColor.Location = New System.Drawing.Point(297, 12)
        Me.txtColor.MaxLength = 20
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(160, 20)
        Me.txtColor.TabIndex = 13
        '
        'txtDtlRmk
        '
        Me.txtDtlRmk.Location = New System.Drawing.Point(90, 124)
        Me.txtDtlRmk.Name = "txtDtlRmk"
        Me.txtDtlRmk.Size = New System.Drawing.Size(367, 43)
        Me.txtDtlRmk.TabIndex = 19
        Me.txtDtlRmk.Text = ""
        '
        'cboCountry
        '
        Me.cboCountry.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboCountry.FormattingEnabled = True
        Me.cboCountry.Location = New System.Drawing.Point(90, 101)
        Me.cboCountry.Name = "cboCountry"
        Me.cboCountry.Size = New System.Drawing.Size(106, 21)
        Me.cboCountry.TabIndex = 17
        '
        'cboCat
        '
        Me.cboCat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboCat.FormattingEnabled = True
        Me.cboCat.Location = New System.Drawing.Point(90, 56)
        Me.cboCat.Name = "cboCat"
        Me.cboCat.Size = New System.Drawing.Size(367, 21)
        Me.cboCat.TabIndex = 15
        '
        'txtDept
        '
        Me.txtDept.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtDept.Location = New System.Drawing.Point(90, 79)
        Me.txtDept.MaxLength = 20
        Me.txtDept.Name = "txtDept"
        Me.txtDept.Size = New System.Drawing.Size(367, 20)
        Me.txtDept.TabIndex = 16
        '
        'txtItmNam
        '
        Me.txtItmNam.Location = New System.Drawing.Point(90, 35)
        Me.txtItmNam.Name = "txtItmNam"
        Me.txtItmNam.Size = New System.Drawing.Size(367, 20)
        Me.txtItmNam.TabIndex = 14
        Me.txtItmNam.Text = ""
        '
        'txtItmNo
        '
        Me.txtItmNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmNo.Location = New System.Drawing.Point(90, 12)
        Me.txtItmNo.MaxLength = 20
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(148, 20)
        Me.txtItmNo.TabIndex = 12
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.Label6)
        Me.GroupBox10.Controls.Add(Me.Label5)
        Me.GroupBox10.Controls.Add(Me.cboDtl)
        Me.GroupBox10.Controls.Add(Me.cboMPONo)
        Me.GroupBox10.ForeColor = System.Drawing.Color.Black
        Me.GroupBox10.Location = New System.Drawing.Point(9, 53)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(464, 63)
        Me.GroupBox10.TabIndex = 8
        Me.GroupBox10.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 12)
        Me.Label6.TabIndex = 289
        Me.Label6.Text = "Detail(s)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 12)
        Me.Label5.TabIndex = 288
        Me.Label5.Text = "MPO No"
        '
        'cboDtl
        '
        Me.cboDtl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboDtl.FormattingEnabled = True
        Me.cboDtl.Location = New System.Drawing.Point(90, 35)
        Me.cboDtl.Name = "cboDtl"
        Me.cboDtl.Size = New System.Drawing.Size(365, 21)
        Me.cboDtl.TabIndex = 10
        '
        'cboMPONo
        '
        Me.cboMPONo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboMPONo.FormattingEnabled = True
        Me.cboMPONo.Location = New System.Drawing.Point(90, 12)
        Me.cboMPONo.Name = "cboMPONo"
        Me.cboMPONo.Size = New System.Drawing.Size(168, 21)
        Me.cboMPONo.TabIndex = 9
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.txtPck_UM)
        Me.GroupBox9.Controls.Add(Me.Label51)
        Me.GroupBox9.Controls.Add(Me.txtPck)
        Me.GroupBox9.Controls.Add(Me.txtTtlGW_D_UM)
        Me.GroupBox9.Controls.Add(Me.txtGW_UM)
        Me.GroupBox9.Controls.Add(Me.Label35)
        Me.GroupBox9.Controls.Add(Me.Label36)
        Me.GroupBox9.Controls.Add(Me.txtTtlGW_D)
        Me.GroupBox9.Controls.Add(Me.txtGW)
        Me.GroupBox9.Controls.Add(Me.txtTtlNW_D_UM)
        Me.GroupBox9.Controls.Add(Me.txtNW_UM)
        Me.GroupBox9.Controls.Add(Me.Label34)
        Me.GroupBox9.Controls.Add(Me.Label33)
        Me.GroupBox9.Controls.Add(Me.Label31)
        Me.GroupBox9.Controls.Add(Me.Label28)
        Me.GroupBox9.Controls.Add(Me.Label26)
        Me.GroupBox9.Controls.Add(Me.Label25)
        Me.GroupBox9.Controls.Add(Me.txtTtlCTN_D)
        Me.GroupBox9.Controls.Add(Me.txtCTNTo)
        Me.GroupBox9.Controls.Add(Me.cboTtlCTN_D_UM)
        Me.GroupBox9.Controls.Add(Me.cboGroup)
        Me.GroupBox9.Controls.Add(Me.txtTtlNW_D)
        Me.GroupBox9.Controls.Add(Me.txtNW)
        Me.GroupBox9.Controls.Add(Me.txtCTNFm)
        Me.GroupBox9.ForeColor = System.Drawing.Color.Black
        Me.GroupBox9.Location = New System.Drawing.Point(477, 10)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(451, 106)
        Me.GroupBox9.TabIndex = 20
        Me.GroupBox9.TabStop = False
        '
        'txtPck_UM
        '
        Me.txtPck_UM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPck_UM.Location = New System.Drawing.Point(391, 35)
        Me.txtPck_UM.MaxLength = 20
        Me.txtPck_UM.Name = "txtPck_UM"
        Me.txtPck_UM.Size = New System.Drawing.Size(41, 20)
        Me.txtPck_UM.TabIndex = 27
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(250, 37)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(42, 12)
        Me.Label51.TabIndex = 305
        Me.Label51.Text = "Packing"
        '
        'txtPck
        '
        Me.txtPck.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPck.Location = New System.Drawing.Point(309, 35)
        Me.txtPck.MaxLength = 20
        Me.txtPck.Name = "txtPck"
        Me.txtPck.Size = New System.Drawing.Size(80, 20)
        Me.txtPck.TabIndex = 26
        '
        'txtTtlGW_D_UM
        '
        Me.txtTtlGW_D_UM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTtlGW_D_UM.Location = New System.Drawing.Point(391, 81)
        Me.txtTtlGW_D_UM.MaxLength = 20
        Me.txtTtlGW_D_UM.Name = "txtTtlGW_D_UM"
        Me.txtTtlGW_D_UM.Size = New System.Drawing.Size(41, 20)
        Me.txtTtlGW_D_UM.TabIndex = 35
        '
        'txtGW_UM
        '
        Me.txtGW_UM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtGW_UM.Location = New System.Drawing.Point(391, 58)
        Me.txtGW_UM.MaxLength = 20
        Me.txtGW_UM.Name = "txtGW_UM"
        Me.txtGW_UM.Size = New System.Drawing.Size(41, 20)
        Me.txtGW_UM.TabIndex = 31
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(249, 84)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(54, 12)
        Me.Label35.TabIndex = 301
        Me.Label35.Text = "Total G.W"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(249, 61)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(53, 12)
        Me.Label36.TabIndex = 300
        Me.Label36.Text = "G.W/CTN"
        '
        'txtTtlGW_D
        '
        Me.txtTtlGW_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTtlGW_D.Location = New System.Drawing.Point(309, 80)
        Me.txtTtlGW_D.MaxLength = 20
        Me.txtTtlGW_D.Name = "txtTtlGW_D"
        Me.txtTtlGW_D.Size = New System.Drawing.Size(80, 20)
        Me.txtTtlGW_D.TabIndex = 34
        '
        'txtGW
        '
        Me.txtGW.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtGW.Location = New System.Drawing.Point(309, 58)
        Me.txtGW.MaxLength = 20
        Me.txtGW.Name = "txtGW"
        Me.txtGW.Size = New System.Drawing.Size(80, 20)
        Me.txtGW.TabIndex = 30
        '
        'txtTtlNW_D_UM
        '
        Me.txtTtlNW_D_UM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTtlNW_D_UM.Location = New System.Drawing.Point(158, 79)
        Me.txtTtlNW_D_UM.MaxLength = 20
        Me.txtTtlNW_D_UM.Name = "txtTtlNW_D_UM"
        Me.txtTtlNW_D_UM.Size = New System.Drawing.Size(41, 20)
        Me.txtTtlNW_D_UM.TabIndex = 33
        '
        'txtNW_UM
        '
        Me.txtNW_UM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtNW_UM.Location = New System.Drawing.Point(158, 57)
        Me.txtNW_UM.MaxLength = 20
        Me.txtNW_UM.Name = "txtNW_UM"
        Me.txtNW_UM.Size = New System.Drawing.Size(41, 20)
        Me.txtNW_UM.TabIndex = 29
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(249, 15)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(44, 12)
        Me.Label34.TabIndex = 295
        Me.Label34.Text = "Ttl CTN"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(133, 15)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(18, 12)
        Me.Label33.TabIndex = 294
        Me.Label33.Text = "To"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(3, 82)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(54, 12)
        Me.Label31.TabIndex = 293
        Me.Label31.Text = "Total N.W"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(3, 60)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(53, 12)
        Me.Label28.TabIndex = 292
        Me.Label28.Text = "N.W/CTN"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(3, 37)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(35, 12)
        Me.Label26.TabIndex = 291
        Me.Label26.Text = "Group"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(3, 16)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(28, 12)
        Me.Label25.TabIndex = 290
        Me.Label25.Text = "CTN"
        '
        'txtTtlCTN_D
        '
        Me.txtTtlCTN_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTtlCTN_D.Location = New System.Drawing.Point(309, 12)
        Me.txtTtlCTN_D.MaxLength = 20
        Me.txtTtlCTN_D.Name = "txtTtlCTN_D"
        Me.txtTtlCTN_D.Size = New System.Drawing.Size(55, 20)
        Me.txtTtlCTN_D.TabIndex = 23
        '
        'txtCTNTo
        '
        Me.txtCTNTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCTNTo.Location = New System.Drawing.Point(156, 12)
        Me.txtCTNTo.MaxLength = 20
        Me.txtCTNTo.Name = "txtCTNTo"
        Me.txtCTNTo.Size = New System.Drawing.Size(59, 20)
        Me.txtCTNTo.TabIndex = 22
        '
        'cboTtlCTN_D_UM
        '
        Me.cboTtlCTN_D_UM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboTtlCTN_D_UM.FormattingEnabled = True
        Me.cboTtlCTN_D_UM.Location = New System.Drawing.Point(367, 12)
        Me.cboTtlCTN_D_UM.Name = "cboTtlCTN_D_UM"
        Me.cboTtlCTN_D_UM.Size = New System.Drawing.Size(65, 21)
        Me.cboTtlCTN_D_UM.TabIndex = 24
        '
        'cboGroup
        '
        Me.cboGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboGroup.FormattingEnabled = True
        Me.cboGroup.Location = New System.Drawing.Point(70, 34)
        Me.cboGroup.Name = "cboGroup"
        Me.cboGroup.Size = New System.Drawing.Size(106, 21)
        Me.cboGroup.TabIndex = 25
        '
        'txtTtlNW_D
        '
        Me.txtTtlNW_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTtlNW_D.Location = New System.Drawing.Point(70, 79)
        Me.txtTtlNW_D.MaxLength = 20
        Me.txtTtlNW_D.Name = "txtTtlNW_D"
        Me.txtTtlNW_D.Size = New System.Drawing.Size(83, 20)
        Me.txtTtlNW_D.TabIndex = 32
        '
        'txtNW
        '
        Me.txtNW.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtNW.Location = New System.Drawing.Point(70, 57)
        Me.txtNW.MaxLength = 20
        Me.txtNW.Name = "txtNW"
        Me.txtNW.Size = New System.Drawing.Size(83, 20)
        Me.txtNW.TabIndex = 28
        '
        'txtCTNFm
        '
        Me.txtCTNFm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCTNFm.Location = New System.Drawing.Point(70, 12)
        Me.txtCTNFm.MaxLength = 20
        Me.txtCTNFm.Name = "txtCTNFm"
        Me.txtCTNFm.Size = New System.Drawing.Size(59, 20)
        Me.txtCTNFm.TabIndex = 21
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label4)
        Me.GroupBox8.Controls.Add(Me.txtSeq)
        Me.GroupBox8.Controls.Add(Me.Label3)
        Me.GroupBox8.Controls.Add(Me.gbRelation)
        Me.GroupBox8.Controls.Add(Me.txtPrtGrp)
        Me.GroupBox8.ForeColor = System.Drawing.Color.Black
        Me.GroupBox8.Location = New System.Drawing.Point(7, 10)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(466, 44)
        Me.GroupBox8.TabIndex = 1
        Me.GroupBox8.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 12)
        Me.Label4.TabIndex = 285
        Me.Label4.Text = "Seq"
        '
        'txtSeq
        '
        Me.txtSeq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSeq.Location = New System.Drawing.Point(48, 15)
        Me.txtSeq.MaxLength = 20
        Me.txtSeq.Name = "txtSeq"
        Me.txtSeq.Size = New System.Drawing.Size(37, 20)
        Me.txtSeq.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(351, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 12)
        Me.Label3.TabIndex = 283
        Me.Label3.Text = "Print Group"
        '
        'gbRelation
        '
        Me.gbRelation.Controls.Add(Me.Label1)
        Me.gbRelation.Controls.Add(Me.optType2)
        Me.gbRelation.Controls.Add(Me.optType1)
        Me.gbRelation.Controls.Add(Me.optType0)
        Me.gbRelation.Location = New System.Drawing.Point(93, 7)
        Me.gbRelation.Name = "gbRelation"
        Me.gbRelation.Size = New System.Drawing.Size(226, 30)
        Me.gbRelation.TabIndex = 3
        Me.gbRelation.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 279
        Me.Label1.Text = "Type"
        '
        'optType2
        '
        Me.optType2.AutoSize = True
        Me.optType2.Location = New System.Drawing.Point(170, 10)
        Me.optType2.Name = "optType2"
        Me.optType2.Size = New System.Drawing.Size(45, 16)
        Me.optType2.TabIndex = 6
        Me.optType2.TabStop = True
        Me.optType2.Text = "Misc"
        Me.optType2.UseVisualStyleBackColor = True
        '
        'optType1
        '
        Me.optType1.AutoSize = True
        Me.optType1.Location = New System.Drawing.Point(99, 10)
        Me.optType1.Name = "optType1"
        Me.optType1.Size = New System.Drawing.Size(57, 16)
        Me.optType1.TabIndex = 5
        Me.optType1.TabStop = True
        Me.optType1.Text = "Ad hoc"
        Me.optType1.UseVisualStyleBackColor = True
        '
        'optType0
        '
        Me.optType0.AutoSize = True
        Me.optType0.Location = New System.Drawing.Point(45, 10)
        Me.optType0.Name = "optType0"
        Me.optType0.Size = New System.Drawing.Size(47, 16)
        Me.optType0.TabIndex = 4
        Me.optType0.TabStop = True
        Me.optType0.Text = "MPO"
        Me.optType0.UseVisualStyleBackColor = True
        '
        'txtPrtGrp
        '
        Me.txtPrtGrp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPrtGrp.Location = New System.Drawing.Point(412, 16)
        Me.txtPrtGrp.MaxLength = 20
        Me.txtPrtGrp.Name = "txtPrtGrp"
        Me.txtPrtGrp.Size = New System.Drawing.Size(45, 20)
        Me.txtPrtGrp.TabIndex = 7
        '
        'cmdNextD
        '
        Me.cmdNextD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdNextD.Location = New System.Drawing.Point(839, 260)
        Me.cmdNextD.Name = "cmdNextD"
        Me.cmdNextD.Size = New System.Drawing.Size(51, 27)
        Me.cmdNextD.TabIndex = 48
        Me.cmdNextD.TabStop = False
        Me.cmdNextD.Text = "&Next"
        '
        'cmdPrvD
        '
        Me.cmdPrvD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdPrvD.Location = New System.Drawing.Point(786, 260)
        Me.cmdPrvD.Name = "cmdPrvD"
        Me.cmdPrvD.Size = New System.Drawing.Size(51, 27)
        Me.cmdPrvD.TabIndex = 47
        Me.cmdPrvD.TabStop = False
        Me.cmdPrvD.Text = "&Back"
        '
        'chkDelete
        '
        Me.chkDelete.AutoSize = True
        Me.chkDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkDelete.Location = New System.Drawing.Point(482, 266)
        Me.chkDelete.Name = "chkDelete"
        Me.chkDelete.Size = New System.Drawing.Size(57, 17)
        Me.chkDelete.TabIndex = 49
        Me.chkDelete.Text = "Delete"
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
        Me.optSearch1.Size = New System.Drawing.Size(49, 16)
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
        Me.optSearch0.Size = New System.Drawing.Size(59, 16)
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
        Me.Label30.Size = New System.Drawing.Size(54, 12)
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
        Me.Label39.Size = New System.Drawing.Size(36, 12)
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
        Me.Label40.Size = New System.Drawing.Size(31, 12)
        Me.Label40.TabIndex = 317
        Me.Label40.Text = "CBM"
        Me.Label40.Visible = False
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(531, 615)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(74, 12)
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
        Me.cboCus2No_dtl.Size = New System.Drawing.Size(23, 20)
        Me.cboCus2No_dtl.TabIndex = 359
        Me.cboCus2No_dtl.Visible = False
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(202, 135)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(67, 12)
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
        Me.Label88.Size = New System.Drawing.Size(44, 12)
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
        Me.Label49.Size = New System.Drawing.Size(73, 12)
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
        Me.Label50.Size = New System.Drawing.Size(95, 12)
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
        Me.Label48.Size = New System.Drawing.Size(73, 12)
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
        Me.Label47.Size = New System.Drawing.Size(105, 12)
        Me.Label47.TabIndex = 329
        Me.Label47.Text = "Gross Wgt/Ctn : (Kg)"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(202, 63)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(67, 12)
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
        Me.Label46.Size = New System.Drawing.Size(84, 12)
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
        Me.Label44.Size = New System.Drawing.Size(13, 12)
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
        Me.Label43.Size = New System.Drawing.Size(16, 12)
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
        Me.Label42.Size = New System.Drawing.Size(12, 12)
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
        Me.Label41.Size = New System.Drawing.Size(80, 12)
        Me.Label41.TabIndex = 318
        Me.Label41.Text = "Dimension (cm)"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(85, 11)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(30, 12)
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
        Me.Label38.Size = New System.Drawing.Size(26, 12)
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
        Me.Label29.Size = New System.Drawing.Size(47, 12)
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
        Me.optCtrSiz3.Size = New System.Drawing.Size(37, 16)
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
        Me.optCtrSiz4.Size = New System.Drawing.Size(43, 16)
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
        Me.optCtrSiz0.Size = New System.Drawing.Size(37, 16)
        Me.optCtrSiz0.TabIndex = 291
        Me.optCtrSiz0.Text = "20'"
        Me.optCtrSiz0.UseVisualStyleBackColor = True
        '
        'optCtrSiz1
        '
        Me.optCtrSiz1.AutoSize = True
        Me.optCtrSiz1.Location = New System.Drawing.Point(144, 674)
        Me.optCtrSiz1.Name = "optCtrSiz1"
        Me.optCtrSiz1.Size = New System.Drawing.Size(65, 16)
        Me.optCtrSiz1.TabIndex = 292
        Me.optCtrSiz1.Text = "40' (8.5')"
        Me.optCtrSiz1.UseVisualStyleBackColor = True
        '
        'optCtrSiz2
        '
        Me.optCtrSiz2.AutoSize = True
        Me.optCtrSiz2.Location = New System.Drawing.Point(217, 674)
        Me.optCtrSiz2.Name = "optCtrSiz2"
        Me.optCtrSiz2.Size = New System.Drawing.Size(61, 16)
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
        Me.Label27.Size = New System.Drawing.Size(46, 12)
        Me.Label27.TabIndex = 323
        Me.Label27.Text = "Cust Um"
        Me.Label27.Visible = False
        '
        'tpMPM00002_3
        '
        Me.tpMPM00002_3.Controls.Add(Me.grdSummary)
        Me.tpMPM00002_3.Location = New System.Drawing.Point(4, 22)
        Me.tpMPM00002_3.Name = "tpMPM00002_3"
        Me.tpMPM00002_3.Size = New System.Drawing.Size(946, 513)
        Me.tpMPM00002_3.TabIndex = 2
        Me.tpMPM00002_3.Text = "(3) Summary"
        Me.tpMPM00002_3.UseVisualStyleBackColor = True
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
        Me.grdSummary.Size = New System.Drawing.Size(928, 496)
        Me.grdSummary.TabIndex = 367
        '
        'tsiMPR03
        '
        Me.tsiMPR03.Name = "tsiMPR03"
        Me.tsiMPR03.Size = New System.Drawing.Size(197, 22)
        Me.tsiMPR03.Text = "GRN Transfer Reports"
        '
        'MPM00002
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.txtMode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.cboDest)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.btcMPM00002)
        Me.Controls.Add(Me.cboImpFty)
        Me.Controls.Add(Me.txtRvsDat)
        Me.Controls.Add(Me.lblRvsDat)
        Me.Controls.Add(Me.txtIssDat)
        Me.Controls.Add(Me.lblIssDat)
        Me.Controls.Add(Me.txtGRNNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MPM00002"
        Me.Text = "MPM00002 - GRN Transfer Maintenance (MPM02)"
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.btcMPM00002.ResumeLayout(False)
        Me.tpMPM00002_1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbPri.ResumeLayout(False)
        Me.tpMPM00002_2.ResumeLayout(False)
        Me.tpMPM00002_2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox20.ResumeLayout(False)
        Me.GroupBox20.PerformLayout()
        Me.GroupBox19.ResumeLayout(False)
        Me.GroupBox19.PerformLayout()
        CType(Me.grdDtlLst, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.gbRelation.ResumeLayout(False)
        Me.gbRelation.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.tpMPM00002_3.ResumeLayout(False)
        CType(Me.grdSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private Sub calTotalNWGW_Dtl()
        Dim ctn As Long
        Dim gw As Double
        Dim nw As Double

        Me.txtTtlGW_D.Text = ""
        Me.txtTtlNW_D.Text = ""
        If Trim(txtTtlCTN_D.Text) = "" Then Exit Sub

        On Error GoTo err_Handle_not_number_CTN
        ctn = CLng(Me.txtTtlCTN_D.Text)
        On Error GoTo 0

        On Error GoTo err_Handle_not_number_GW
        If Trim(Me.txtGW.Text) <> "" Then
            gw = CDbl(IIf(Me.txtGW.Text = "", 0, Me.txtGW.Text))
            Me.txtTtlGW_D.Text = gw * ctn
        End If
        On Error GoTo 0

        On Error GoTo err_Handle_not_number_NW
        If Trim(Me.txtNW.Text) <> "" Then
            nw = CDbl(IIf(Me.txtNW.Text = "", 0, Me.txtNW.Text))
            Me.txtTtlNW_D.Text = nw * ctn
            If Trim(Me.txtTtlCTN.Text) <> "" Then
                Me.txtCustQty.Text = Format(nw * ctn, "###,###.#0")
                Me.txtCustSubTtl.Text = CDbl(IIf(Trim(Me.txtCustQty.Text) = "", 0, Me.txtCustQty.Text)) * _
                                        CDbl(IIf(Trim(Me.txtUntPrc.Text) = "", 0, Me.txtUntPrc.Text))
            End If
        End If
        On Error GoTo 0
        Exit Sub

err_Handle_not_number_CTN:
        MsgBox("Total CTN should be an integer value!")
        If txtTtlCTN_D.Enabled = True Then Me.txtTtlCTN_D.Focus()
        Exit Sub
err_Handle_not_number_GW:
        MsgBox("G.W/CTN should be a numerical value!")
        If Me.txtGW.Enabled = True Then Me.txtGW.Focus()
        Exit Sub
err_Handle_not_number_NW:
        MsgBox("N.W/CTN should be a numerical value!")
        If Me.txtNW.Enabled = True Then Me.txtNW.Focus()
        'Me.txtTtlCTN_D.Focus
        Exit Sub
    End Sub

    Private Sub calTotalNWGW_Hdr()
        Dim ctn As Long
        Dim gw As Double
        Dim nw As Double
        Dim pos As Integer

        Me.txtTtlGW.Text = "0"
        Me.txtTtlNW.Text = "0"
        Me.txtTtlCTN.Text = "0"

        If rs_GRNTRFDTL.Tables("result") Is Nothing Then Exit Sub
        If rs_GRNTRFDTL.Tables("result").Rows.Count <= 0 Then Exit Sub

        ctn = 0
        gw = 0
        nw = 0

        With rs_GRNTRFDTL

            For index As Integer = 0 To rs_GRNTRFDTL.Tables("RESULT").Rows.Count - 1
                If rs_GRNTRFDTL.Tables("RESULT").Rows(index)("Del") <> "Y" And _
                rs_GRNTRFDTL.Tables("RESULT").Rows(index)("CreUsr") <> "~*NEW*~" Then
                    ctn = ctn + CLng(IIf(IsDBNull(rs_GRNTRFDTL.Tables("RESULT").Rows(index)("Grd_TtlCTN")), 0, rs_GRNTRFDTL.Tables("RESULT").Rows(index)("Grd_TtlCTN")))
                    gw = gw + CDbl(IIf(IsDBNull(rs_GRNTRFDTL.Tables("RESULT").Rows(index)("Grd_TtlGW")), 0, rs_GRNTRFDTL.Tables("RESULT").Rows(index)("Grd_TtlGW")))
                    nw = nw + CDbl(IIf(IsDBNull(rs_GRNTRFDTL.Tables("RESULT").Rows(index)("Grd_TtlNW")), 0, rs_GRNTRFDTL.Tables("RESULT").Rows(index)("Grd_TtlNW")))
                End If
            Next
        End With




        Me.txtTtlCTN.Text = ctn
        Me.txtTtlGW.Text = gw
        Me.txtTtlNW.Text = nw
    End Sub


    Private Function CheckGroupData() As Boolean
        Dim rs_check As New DataSet
        Dim rs_check_tmp As New DataSet
        Dim str_grp As String

        CheckGroupData = False
        If rs_GRNTRFDTL.Tables("result") Is Nothing Then Exit Function
        If rs_GRNTRFDTL.Tables("result").Rows.Count <= 0 Then Exit Function
        rs_check = rs_GRNTRFDTL.Copy
        rs_check_tmp = rs_check.Copy
        If rs_check.Tables("result") Is Nothing Then Exit Function
        If rs_check.Tables("result").Rows.Count <= 0 Then Exit Function
        If rs_check_tmp.Tables("result") Is Nothing Then Exit Function
        If rs_check_tmp.Tables("result").Rows.Count <= 0 Then Exit Function
        str_grp = ""

        rs_check.Tables("result").DefaultView.Sort = "Grd_Grp"

        For index As Integer = 0 To rs_check.Tables("RESULT").DefaultView.Count - 1
            If IsDBNull(rs_check.Tables("RESULT").DefaultView(index)("grd_grp")) Then
                rs_check.Tables("RESULT").DefaultView(index)("grd_grp") = ""
            End If
            'tempzzzz
            If rs_check.Tables("RESULT").DefaultView(index)("grd_grp") <> "" _
                    And str_grp = rs_check.Tables("RESULT").DefaultView(index)("grd_grp") _
                    And rs_check.Tables("RESULT").DefaultView(index)("Del") <> "Y" Then
                str_grp = Trim(rs_check.Tables("RESULT").DefaultView(index)("grd_grp"))
                rs_check_tmp.Tables("result").DefaultView.RowFilter = "grd_grp = '" & str_grp & "'"

                For index_tmp As Integer = 0 To rs_check_tmp.Tables("RESULT").DefaultView.Count - 1
                    If rs_check_tmp.Tables("RESULT").DefaultView(index_tmp)("Del") <> "Y" Then
                        If rs_check_tmp.Tables("RESULT").DefaultView(index_tmp)("Grd_CustCat") <> rs_check.Tables("RESULT").DefaultView(index)("Grd_CustCat") Or _
                        rs_check_tmp.Tables("RESULT").DefaultView(index_tmp)("Grd_CTNFm") <> rs_check.Tables("RESULT").DefaultView(index)("Grd_CTNFm") Or _
                        rs_check_tmp.Tables("RESULT").DefaultView(index_tmp)("Grd_CTNTo") <> rs_check.Tables("RESULT").DefaultView(index)("Grd_CTNTo") Or _
                        rs_check_tmp.Tables("RESULT").DefaultView(index_tmp)("Grd_TtlCTN") <> rs_check.Tables("RESULT").DefaultView(index)("Grd_TtlCTN") Or _
                        rs_check_tmp.Tables("RESULT").DefaultView(index_tmp)("Grd_CtnUM") <> rs_check.Tables("RESULT").DefaultView(index)("Grd_CtnUM") Or _
                        rs_check_tmp.Tables("RESULT").DefaultView(index_tmp)("Grd_GW") <> rs_check.Tables("RESULT").DefaultView(index)("Grd_GW") Or _
                        rs_check_tmp.Tables("RESULT").DefaultView(index_tmp)("Grd_NW") <> rs_check.Tables("RESULT").DefaultView(index)("Grd_NW") Or _
                        rs_check_tmp.Tables("RESULT").DefaultView(index_tmp)("Grd_TtlGW") <> rs_check.Tables("RESULT").DefaultView(index)("Grd_TtlGW") Or _
                        rs_check_tmp.Tables("RESULT").DefaultView(index_tmp)("Grd_TtlNW") <> rs_check.Tables("RESULT").DefaultView(index)("Grd_TtlNW") Or _
                        rs_check_tmp.Tables("RESULT").DefaultView(index_tmp)("Grd_CustUM") <> rs_check.Tables("RESULT").DefaultView(index)("Grd_CustUM") Or _
                        rs_check_tmp.Tables("RESULT").DefaultView(index_tmp)("Grd_CustQty") <> rs_check.Tables("RESULT").DefaultView(index)("Grd_CustQty") Or _
                        rs_check_tmp.Tables("RESULT").DefaultView(index_tmp)("Grd_untprc") <> rs_check.Tables("RESULT").DefaultView(index)("Grd_untprc") Then
                            MsgBox("Data of Group [" & str_grp & "] not match!" & vbCrLf & "Please check CTN Fm, CTN To, Ttl CTN, UM(CTN), G.W., N.W., Cust Qty, Cust UM or Unit Price of Group [" & str_grp & "]")
                            Exit Function
                        End If
                    End If
                Next
                rs_check_tmp.Tables("result").DefaultView.RowFilter = ""
            End If
        Next





        CheckGroupData = True
        Exit Function

err_handle:
        MsgBox(Err.Description)
        Err.Clear()
        Exit Function
    End Function

    Private Function checkHeader() As Boolean
        checkHeader = False
        If Trim(Me.cboDest.Text) = "" Then
            Call show_header_msg("Please select Destination!", Me.cboDest)
            Exit Function
        End If

        If Trim(Me.txtInvHdr.Text) = "" Then
            Call show_header_msg("Please input Invoice Header!", Me.txtInvHdr)
            Exit Function
        End If

        If Trim(Me.txtAgtNo.Text) = "" Then
            Call show_header_msg("Please input Agreement No!", Me.txtAgtNo)
            Exit Function
        End If

        If Trim(Me.txtTrdCty.Text) = "" Then
            Call show_header_msg("Please input Trading Country!", Me.txtTrdCty)
            Exit Function
        End If

        If Trim(Me.cboCar.Text) = "" Then
            Call show_header_msg("Please input Transportation!", Me.cboCar)
            Exit Function
        End If

        If Trim(Me.cboCustUM_H.Text) = "" Then
            Call show_header_msg("Please input Custom UM!", Me.cboCustUM_H)
            Exit Function
        End If

        If Trim(Me.cboInvUM_H.Text) = "" Then
            Call show_header_msg("Please input Invoice UM!", Me.cboInvUM_H)
            Exit Function
        End If

        '2006-03-20
        If Trim(Me.txtDlvDat.Text) = "  \  \    " Then
            Call show_header_msg("Please input Delivery Date!", Me.txtDlvDat)
            Exit Function
        ElseIf Not IsDate(Me.txtDlvDat.Text) Then
            Call show_header_msg("Invalid Delivery Date!", Me.txtDlvDat)
            Exit Function
        End If

        checkHeader = True
    End Function

    Private Function isDetailUpdated() As Boolean
        Dim pos As Integer
        Dim seq As Integer

        '---------------------------------------------------
        isDetailUpdated = False
        '---------------------------------------------------
        If rs_GRNTRFDTL Is Nothing Then Exit Function
        If rs_GRNTRFDTL.Tables("result") Is Nothing Then Exit Function
        If rs_GRNTRFDTL.Tables("result").Rows.Count <= 0 Then Exit Function


        '        'pos = rs_GRNTRFDTL.AbsolutePosition
        seq = 0
        If Me.txtSeq.Text <> "" Then seq = CInt(Me.txtSeq.Text)
        rs_GRNTRFDTL.Tables("result").DefaultView.RowFilter = "(CreUsr = '~*ADD*~' and Del <> 'Y') or (CreUsr <> '~*NEW*~' and Del = 'Y') or (CreUsr = '~*UPD*~' and Del <> 'Y')"
        If rs_GRNTRFDTL.Tables("result").DefaultView.Count > 0 Then
            isDetailUpdated = True
        End If
        rs_GRNTRFDTL.Tables("result").DefaultView.RowFilter = ""
        If seq > 0 Then
            rs_GRNTRFDTL.Tables("result").DefaultView.RowFilter = "Grd_Seq = " & seq
            '''rs_GRNTRFDTL.Tables("result").DefaultView.RowFilter =("Grd_Seq = " & seq)
            'temp
        ElseIf pos > 0 Then
            '''            rs_GRNTRFDTL.AbsolutePosition = pos
            't
        End If

        If isDetailUpdated = True Then Exit Function

        '---------------------------------------------------

        If btcMPM00002.SelectedIndex = 1 Then
            'With rs_GRNTRFDTL
            isDetailUpdated = False
            If rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_ItmNo") <> Trim(Me.txtItmNo.Text) Then
                isDetailUpdated = True
            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_ItmNam") <> Trim(Me.txtItmNam.Text) Then
                isDetailUpdated = True
                '            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_ItmDsc") <> Trim(Me.txtItmDesc.Text) Then
                '                isDetailUpdated = True
            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_Color") <> Trim(Me.txtColor.Text) Then
                isDetailUpdated = True
            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_UntPrc") <> CDbl(IIf(Me.txtUntPrc.Text = "", 0, Me.txtUntPrc.Text)) Then
                isDetailUpdated = True
            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_TtlShpQty") <> CDbl(IIf(Me.txtShpQty.Text = "", 0, Me.txtShpQty.Text)) Then
                isDetailUpdated = True
            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_custQty") <> CDbl(IIf(Me.txtCustQty.Text = "", 0, Me.txtCustQty.Text)) Then
                isDetailUpdated = True
            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_ShpUM") <> Trim(Me.txtShpUM.Text) Then
                isDetailUpdated = True
            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_RevDept") <> Trim(Me.txtDept.Text) Then
                isDetailUpdated = True
                'ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_CustCat") <> IIf(Trim(Me.cboCat.Text) = "", "", Trim(Split(Me.cboCat.Text, "-")(0))) Then
                '    isDetailUpdated = True
            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_CustCat") <> Trim(Me.cboCat.Text) Then
                isDetailUpdated = True
            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_Cty") <> Trim(Me.cboCountry.Text) Then
                isDetailUpdated = True
            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_CTNFm") <> Trim(Me.txtCTNFm.Text) Then
                isDetailUpdated = True
            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_CTNTo") <> Trim(Me.txtCTNTo.Text) Then
                isDetailUpdated = True
            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_TtlCTN") <> CLng(IIf(Me.txtTtlCTN_D.Text = "", 0, Me.txtTtlCTN_D.Text)) Then
                isDetailUpdated = True
            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_CtnUM") <> Trim(Me.cboTtlCTN_D_UM.Text) Then
                isDetailUpdated = True
            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_GW") <> CDbl(IIf(Me.txtGW.Text = "", 0, Me.txtGW.Text)) Then
                isDetailUpdated = True
            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_NW") <> CDbl(IIf(Me.txtNW.Text = "", 0, Me.txtNW.Text)) Then
                isDetailUpdated = True
            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_TtlGW") <> CDbl(IIf(Me.txtTtlGW_D.Text = "", 0, Me.txtTtlGW_D.Text)) Then
                isDetailUpdated = True
            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_TtlNW") <> CDbl(IIf(Me.txtTtlNW_D.Text = "", 0, Me.txtTtlNW_D.Text)) Then
                isDetailUpdated = True
            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_PckWgt") <> CDbl(IIf(Me.txtPck.Text = "", 0, Me.txtPck.Text)) Then
                isDetailUpdated = True
            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_PckUM") <> Trim(Me.txtPck_UM.Text) Then
                isDetailUpdated = True
            ElseIf rs_GRNTRFDTL.Tables("RESULT").Rows(0)("Grd_Grp") <> Trim(Me.cboGroup.Text) Then
                isDetailUpdated = True
            End If
            'End With
        End If

    End Function

    Private Function isEqual_Long(ByVal strFm As String, ByVal strTO As String, ByVal strTtl As String) As Boolean
        On Error GoTo err_Handle_Equal
        isEqual_Long = False
        If CLng(strFm) >= CLng(strFm) Then
            If CLng(strTtl) = CLng(strTO) - CLng(strFm) + 1 Then
                isEqual_Long = True
            End If
        End If
        Exit Function
err_Handle_Equal:
        isEqual_Long = True
        Err.Clear()
    End Function

    Private Function isHeaderUpdated() As Boolean
        isHeaderUpdated = False

        If addFlag = False Then
            If Not rs_GRNTRFHDR Is Nothing Then
                If Not rs_GRNTRFHDR.Tables("result") Is Nothing Then
                    If rs_GRNTRFHDR.Tables("result").Rows.Count > 0 Then
                        '                    With rs_GRNTRFHDR
                        If Trim(Me.cboDest.Text) <> rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_ShpPlc") Then
                            isHeaderUpdated = True
                        ElseIf Trim(Me.txtImpFtyAddr.Text) <> rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_Addr") Then
                            isHeaderUpdated = True
                        ElseIf Trim(Me.txtDestAddr.Text) <> rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_ShpAddr") Then
                            isHeaderUpdated = True
                        ElseIf Trim(Me.txtInvHdr.Text) <> rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_InvHdr") Then
                            isHeaderUpdated = True
                        ElseIf Trim(Me.txtAgtNo.Text) <> rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_AgtNo") Then
                            isHeaderUpdated = True
                        ElseIf Trim(Me.txtTrdCty.Text) <> rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_TrdCty") Then
                            isHeaderUpdated = True
                        ElseIf Trim(Me.cboCar.Text) <> rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_Car") Then
                            isHeaderUpdated = True
                        ElseIf Trim(Me.cboCustUM_H.Text) <> rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_CUSUM") Then
                            isHeaderUpdated = True
                        ElseIf Trim(Me.cboInvUM_H.Text) <> rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_INVUM") Then
                            isHeaderUpdated = True
                        ElseIf Trim(Me.txtTtlNW.Text) <> CStr(rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_TtlNw")) Then
                            isHeaderUpdated = True
                        ElseIf Trim(Me.txtTtlGW.Text) <> CStr(rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_TtlGW")) Then
                            isHeaderUpdated = True
                        ElseIf Trim(Me.txtTtlCTN.Text) <> CStr(rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_TtlCtn")) Then
                            isHeaderUpdated = True
                            '2006-03-20
                        ElseIf Trim(Me.txtDlvDat.Text) <> CStr(rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_DlvDat")) Then
                            isHeaderUpdated = True
                        ElseIf Trim(Me.txtCtrNo.Text) <> CStr(rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_CtrNo")) Then
                            isHeaderUpdated = True
                        End If

                        'End With
                    End If
                End If
            End If
        End If

        Recordstatus = isHeaderUpdated

    End Function

    '
    Private Function checkDetail() As Boolean
        Dim bolShpQty As Boolean
        Dim i As Integer
        Dim lngShpQty As Double
        Dim lngLstShpQty As Double

        Dim msg As String

        checkDetail = False

        If Me.chkDelete.Checked = True Then
            checkDetail = True
            Exit Function
        End If

        ' Frankie Cheung 20091015 Check Print Group
        If Len(Trim(Me.txtPrtGrp.Text)) = 0 Then
            Call show_detail_msg("Print Group is empty!", txtPrtGrp)
            Exit Function
        ElseIf Not IsNumeric(Trim(Me.txtPrtGrp.Text)) Then
            Call show_detail_msg("Print Group is not valid number!", txtPrtGrp)
            Exit Function
        End If

        '====================================================================================================
        If Trim(Me.txtShpQty.Text) <> "" Then
            lngShpQty = CDbl(Me.txtShpQty.Text)
            lngLstShpQty = 0
            If Not rs_GRNTRFLST.Tables("result") Is Nothing Then
                If Not Me.grdDtlLst.DataSource Is Nothing Then

                    For index As Integer = 0 To rs_GRNTRFLST.Tables("RESULT").Rows.Count - 1
                        If rs_GRNTRFLST.Tables("RESULT").Rows(index)("Grl_grnseq") = CLng(Me.txtSeq.Text) Then
                            lngLstShpQty = lngLstShpQty + rs_GRNTRFLST.Tables("RESULT").Rows(index)("ShpQty")
                        End If
                    Next

                    If lngLstShpQty <> lngShpQty Then
                        Call show_detail_msg("Ship Qty invalid!" & vbCrLf & "Please press <Enter> in Ship Qty to recalculate.", Me.txtShpQty)
                        Exit Function
                    End If


                End If
            End If
        End If
        '====================================================================================================


        If optType0.Checked = True Or optType1.Checked = True Then
            If optType0.Checked = True Then
                If Trim(Me.cboMPONo.Text) = "" Then
                    Call show_detail_msg("Please Select MPO #!", Me.cboMPONo)
                    Exit Function
                ElseIf Trim(Me.cboDtl.Text) = "" Then
                    Call show_detail_msg("Please select Item #!", Me.cboDtl)
                    Exit Function
                End If
            End If

            If Trim(Me.txtItmNo.Text) = "" Then
                Call show_detail_msg("Please input Item #!", txtItmNo)
                Exit Function
            ElseIf Trim(Me.txtItmNam.Text) = "" Then
                Call show_detail_msg("Please input Item Name!", txtItmNam)
                Exit Function
            ElseIf Trim(Me.cboCat.Text) = "" Then
                Call show_detail_msg("Please select Custom Category", cboCat)
                Exit Function
            ElseIf Trim(Me.cboCountry.Text) = "" Then
                Call show_detail_msg("Please select Country", cboCountry)
                Exit Function
            ElseIf Trim(Me.txtCTNFm.Text) = "" Then
                Call show_detail_msg("Please input CTN From!", txtCTNFm)
                Exit Function
            ElseIf Trim(Me.txtCTNTo.Text) = "" Then
                Call show_detail_msg("Please input CTN To!", txtCTNTo)
                Exit Function
            ElseIf isGreater_Long(Trim(Me.txtCTNFm.Text), Trim(Me.txtCTNTo.Text)) = False Then
                Call show_detail_msg("CTN Fm > CTN To!", txtCTNTo)
                Exit Function
            ElseIf Trim(Me.txtTtlCTN_D.Text) = "" Then
                Call show_detail_msg("Please input total CTN!", txtTtlCTN_D)
                Exit Function
                'ElseIf CLng(Trim(Me.txtCTNTo.Text)) - CLng(Trim(Me.txtCTNFm.Text)) + 1 <> CLng(Trim(Me.txtTtlCTN_D.Text)) Then
                ''        ElseIf isEqual_Long(Me.txtCTNFm.Text, Me.txtCTNTo.Text, Me.txtTtlCTN_D.Text) = False Then
                ''            Call show_detail_msg("Total CTN is not correct!", txtTtlCTN_D)
                ''            Exit Function
            ElseIf Trim(Me.txtGW.Text) = "" Then
                Call show_detail_msg("Please input G.W/CTN!", txtGW)
                Exit Function
            ElseIf Trim(Me.txtNW.Text) = "" Then
                Call show_detail_msg("Please input N.W/CTN!", txtNW)
                Exit Function
            ElseIf CDbl(Me.txtGW.Text) < CDbl(Me.txtNW.Text) Then
                Call show_detail_msg("N.W/CTN > G.W/CTN!", txtNW)
                Exit Function
            ElseIf Trim(Me.txtTtlGW_D.Text) = "" Then
                Call show_detail_msg("Please input Total G.W.", txtTtlGW_D)
                Exit Function
            ElseIf Trim(Me.txtTtlNW_D.Text) = "" Then
                Call show_detail_msg("Please input Total N.W.!", txtTtlNW_D)
                Exit Function
                '        ElseIf Trim(Me.txtPck.Text) = "" Then
                '            Call show_detail_msg("Please input Packing/CTN!", txtPck)
                '            Exit Function
            ElseIf Trim(Me.cboCurr.Text) = "" Then
                Call show_detail_msg("Please select currency!", cboCurr)
                Exit Function
            ElseIf Trim(Me.txtShpQty.Text) = "" Or Trim(Me.txtShpQty.Text) = "0" Then
                Call show_detail_msg("Please input Ship Qty!", txtShpQty)
                Exit Function
            ElseIf Trim(Me.txtCustQty.Text) = "" Or Trim(Me.txtCustQty.Text) = "0" Then
                Call show_detail_msg("Please input Custom Qty!", txtCustQty)
                Exit Function
            ElseIf Trim(Me.txtOSQty.Text) <> "" Then
                If CDbl(Me.txtShpQty.Text) - Dtl_ORIQTY > CDbl(Me.txtOSQty.Text) Then
                    Call show_detail_msg("Ship Qty cannot greater then O/S Qty!", txtShpQty)
                    Exit Function
                End If
            End If
            If Me.txtUntPrc.Text = "" Or Me.txtUntPrc.Text = "0" Then
                Call show_detail_msg("Please input Unit Price", txtUntPrc)
                Exit Function
                '        ElseIf Me.txtSubTtl.Text = "" Or Me.txtSubTtl.Text = "0" Then
                '            Call show_detail_msg("Sub-Total value not valid!", txtSubTtl)
                Exit Function
            ElseIf Me.txtCustSubTtl.Text = "" Or Me.txtCustSubTtl.Text = "0" Then
                Call show_detail_msg("Custom Sub-Total value not valid!", txtCustSubTtl)
                Exit Function
                '        ElseIf Trim(Me.txtShpQty.Text) <> "" And Trim(Me.txtUntPrc) <> "" Then
                '            If Format((CLng(IIf(Trim(Me.txtShpQty.Text) = "", "0", Trim(Me.txtShpQty.Text))) * CDbl(IIf(Trim(Me.txtUntPrc.Text) = "", "0", Trim(Me.txtUntPrc.Text)))), "#########.#0") <> Format(CDbl(Me.txtSubTtl.Text), "#########.#0") Then
                '                Call show_detail_msg("Sub-Total value not valid!" & vbCrLf & "Please press <Enter> in Ship Qty field to recalculate.", txtSubTtl)
                '                Exit Function
                '            End If
            ElseIf Trim(Me.cboCurr.Text) <> "" And Trim(strCurrGBL) <> "" And Trim(Me.cboCurr.Text) <> Trim(strCurrGBL) Then
                Call show_detail_msg("Currency not match!" & vbCrLf & "Please re-select the currency.", cboCurr)
                Exit Function
            ElseIf Trim(Me.txtCustQty.Text) <> "" And Trim(Me.txtUntPrc.Text) <> "" Then
                If Format((CDbl(IIf(Trim(Me.txtCustQty.Text) = "", "0", Trim(Me.txtCustQty.Text))) * CDbl(IIf(Trim(Me.txtUntPrc.Text) = "", "0", Trim(Me.txtUntPrc.Text)))), "#########.#0") <> Format(CDbl(Me.txtCustSubTtl.Text), "#########.#0") Then
                    Call show_detail_msg("Custom Sub-Total value not valid!" & vbCrLf & "Please press <Enter> in Custom Qty field to recalculate.", txtCustSubTtl)
                    Exit Function
                End If
            End If

            If Trim(Me.txtGW.Text) <> "" And Trim(Me.txtTtlGW_D.Text) <> "" And Trim(Me.txtTtlCTN_D.Text) <> "" Then
                If Format(CDbl(Me.txtTtlCTN_D.Text) * CDbl(Me.txtGW.Text), "#########.#0") <> Format(CDbl(Me.txtTtlGW_D.Text), "#########.#0") Then
                    Call show_detail_msg("Total G.W. Not Equal Ttl CTN * G.W.!" & vbCrLf & "Please press <Eneter> in G.W. to recalculate", txtGW)
                    Exit Function
                End If
            End If

            If Trim(Me.txtNW.Text) <> "" And Trim(Me.txtTtlNW_D.Text) <> "" And Trim(Me.txtTtlCTN_D.Text) <> "" Then
                If Format(CDbl(Me.txtTtlCTN_D.Text) * CDbl(Me.txtNW.Text), "#########.#0") <> Format(CDbl(Me.txtTtlNW_D.Text), "#########.#0") Then
                    Call show_detail_msg("Total N.W. Not Equal Ttl CTN * N.W.!" & vbCrLf & "Please press <Eneter> in N.W. to recalculate", txtNW)
                    Exit Function
                End If
            End If

        ElseIf optType2.Checked = True Then
            If Trim(Me.txtItmNam.Text) = "" Then
                Call show_detail_msg("Please input Item Name!", txtItmNam)
                Exit Function
                '        ElseIf Trim(Me.txtCTNFm.Text) = "" Then
                '            Call show_detail_msg("Please input CTN From!", txtCTNFm)
                '            Exit Function
                '        ElseIf Trim(Me.txtCTNTo.Text) = "" Then
                '            Call show_detail_msg("Please input CTN To!", txtCTNTo)
                '            Exit Function
                '        ElseIf Trim(Me.txtCTNFm.Text) > Trim(Me.txtCTNTo.Text) Then
                '            Call show_detail_msg("CTN Fm > CTN To!", txtCTNTo)
                '            Exit Function
            ElseIf Trim(Me.txtTtlCTN_D.Text) = "" Then
                Call show_detail_msg("Please input total CTN!", txtTtlCTN)
                Exit Function
            ElseIf Trim(Me.cboTtlCTN_D_UM.Text) = "" Then
                Call show_detail_msg("Please input total CTN UM!", cboTtlCTN_D_UM)
                Exit Function
            ElseIf Trim(Me.txtUntPrc.Text) <> "" Then
                If Trim(Me.cboCurr.Text) = "" Then
                    Call show_detail_msg("Please select currency!", cboCurr)
                    Exit Function
                End If
            ElseIf Trim(Me.txtShpQty.Text) = "" Or Trim(Me.txtShpQty.Text) = "0" Then
                Call show_detail_msg("Please input Ship Qty!", txtShpQty)
                Exit Function
            ElseIf Trim(Me.txtCustQty.Text) = "" Or Trim(Me.txtCustQty.Text) = "0" Then
                Call show_detail_msg("Please input Custom Qty!", txtCustQty)
                Exit Function
            ElseIf Trim(Me.txtShpUM.Text) = "" Then
                Call show_detail_msg("Please input Ship UM!", txtShpUM)
                Exit Function
                '        ElseIf Trim(Me.txtCustUM.Text) = "" Then
                '            Call show_detail_msg("Custom UM is empty!", txtCustUM)
                '            Exit Function
            ElseIf Trim(Me.CboCustUM.Text) = "" Then
                Call show_detail_msg("Custom UM is empty!", CboCustUM)
                Exit Function
            End If
        Else
            MsgBox("Invalid detail type!")
            checkDetail = False
        End If
        checkDetail = True
        Exit Function
        'show_msg:
        '    bolDisplay = True
        '    Me.btcMPM00002.selectedindex = 1
        '
        '    bolDisplay = False
    End Function



    Private Function checkNumeric(ByRef txt As TextBox, ByVal lngKeyCode As Long) As Integer
        Dim str As String
        If InStr("1234567890", Chr(lngKeyCode)) > 0 Then
            'tempzzz
            'If InStr("1234567890", Chr(e.KeyCode)) > 0 Then
            checkNumeric = lngKeyCode
            Exit Function
        End If
        checkNumeric = 0
    End Function

    Private Sub DisplayHeader()
        If rs_GRNTRFHDR.Tables("result") Is Nothing Then Exit Sub
        If rs_GRNTRFHDR.Tables("result").Rows.Count <= 0 Then Exit Sub
        '        With rs_GRNTRFHDR
        Me.txtRvsDat.Text = Format(rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_UpdDat"), "MM/dd/yyyy")
        Me.txtIssDat.Text = Format(rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_CreDat"), "MM/dd/yyyy")
        Me.cboImpFty.Text = rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_ImpFty")
        Me.cboDest.Text = rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_ShpPlc")
        Me.txtImpFtyAddr.Text = rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_Addr")
        Me.txtDestAddr.Text = rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_ShpAddr")
        Me.txtInvHdr.Text = rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_InvHdr")
        Me.txtAgtNo.Text = rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_AgtNo")
        Me.txtTrdCty.Text = rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_TrdCty")
        Me.cboCar.Text = rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_Car")
        Me.cboCustUM_H.Text = rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_cusum")
        Me.cboInvUM_H.Text = rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_invum")
        Me.txtTtlNW.Text = rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_TtlNW")
        Me.txtTtlGW.Text = rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_TtlGW")
        Me.txtTtlCTN.Text = rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_TtlCtn")
        '2006-03-20
        If Trim(rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_DlvDat")) <> "" Then
            If IsDate(rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_DlvDat")) Then
                Me.txtDlvDat.Text = Format(CDate(rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_DlvDat")), "MM/dd/yyyy")
            Else
                Me.txtDlvDat.Text = "01/01/1900"
            End If
        End If
        Me.txtCtrNo.Text = rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_CtrNo")
        'End With
    End Sub

    Private Sub enableDetail(Optional ByVal bolEnable As Boolean = True)

    End Sub

    Private Sub freelock()
        On Error GoTo err_Handle_out_of_range
        If bolDisplay = True Then Exit Sub
        If rs_GRNTRFLST.Tables("result") Is Nothing Then Exit Sub
        If rs_GRNTRFLST.Tables("result").Rows.Count <= 0 Then Exit Sub

        'If rs_GRNTRFLST.BOF = True Then Exit Sub
        'If rs_GRNTRFLST.EOF = True Then Exit Sub
        If grdDtlLst.DataSource.Tables("result") Is Nothing Then Exit Sub

        If strMode = "CLO" Or rs_GRNTRFLST.Tables("result").Rows(0)("CreUsr") = "~*NEW*~" Or rs_GRNTRFLST.Tables("result").Rows(0)("Del") = "Y" Then
            grdDtlLst.Columns(CInt(colShpQty)).ReadOnly = True
        Else
            grdDtlLst.Columns(CInt(colShpQty)).ReadOnly = False
        End If
        Exit Sub
err_Handle_out_of_range:
        Err.Clear()
    End Sub

    Private Sub createGroup()
        If Not rs_Group Is Nothing Then rs_Group = Nothing

        rs_Group = New DataSet
        rs_Group.Tables.Add("RESULT")


        With rs_Group
            .Tables("RESULT").Columns.Add("_grp")
            .Tables("RESULT").Columns.Add("_CustCat")
            .Tables("RESULT").Columns.Add("_CtnFm")
            .Tables("RESULT").Columns.Add("_CtnTo")
            .Tables("RESULT").Columns.Add("_TtlCTN")
            .Tables("RESULT").Columns.Add("_CtnUM")
            .Tables("RESULT").Columns.Add("_GW")
            .Tables("RESULT").Columns.Add("_NW")
            .Tables("RESULT").Columns.Add("_TtlGW")
            .Tables("RESULT").Columns.Add("_TtlNW")
            .Tables("RESULT").Columns.Add("_CustUM")
            .Tables("RESULT").Columns.Add("_CustQty")
            .Tables("RESULT").Columns.Add("_untprc")
        End With



    End Sub

    Private Sub createCTN()
        If Not rs_CTN.Tables("result") Is Nothing Then rs_CTN = Nothing

        rs_CTN = New DataSet

        With rs_CTN
            .Tables("RESULT").Columns.Add("_Fm")
            .Tables("RESULT").Columns.Add("_To")

        End With



    End Sub

    Private Function isDuplicate() As Boolean
        Dim pos As Integer
        Dim Filter As String
        Dim itmNo As String
        Dim um As String
        Dim color As String

        isDuplicate = False
        If rs_GRNTRFDTL.Tables("result") Is Nothing Then Exit Function
        If rs_GRNTRFDTL.Tables("result").Rows.Count <= 0 Then Exit Function
        If rs_GRNTRFDTL.Tables("result").Rows.Count = 1 Then Exit Function
        isDuplicate = True

        If Me.optType0.Checked = True Then
            If Me.cboMPONo.Text = "" Then Exit Function
            If Me.cboDtl.Text = "" Then Exit Function

            On Error GoTo err_Handle_Invalid_Dtl
            itmNo = Trim(Split(Me.cboDtl.Text, ";")(0))
            color = Trim(Split(Me.cboDtl.Text, ";")(2))
            um = Trim(Split(Me.cboDtl.Text, ";")(3))
            On Error GoTo 0
            Cursor = Cursors.WaitCursor

            With rs_GRNTRFDTL
                'pos = .AbsolutePosition
                Filter = .Tables("result").DefaultView.RowFilter
                .Tables("result").DefaultView.RowFilter = "Grd_type = 'MPO' and Grd_MPONo = '" & cboMPONo.Text & "' and Grd_ItmNo = '" & itmNo & "' and  Grd_Color = '" & color & "' and Grd_ShpUM = '" & um & "'"
                If .Tables("result").Rows.Count > 0 Then
                    .Tables("result").DefaultView.RowFilter = ""
                    .Tables("result").DefaultView.RowFilter = ("Grd_Seq = " & Me.txtSeq.Text)
                    If MsgBox("Selected detail record already exist!" & vbCrLf & "Continue with selected item?", vbYesNo) = vbNo Then
                        Cursor = Cursors.Default
                        Call setFocus_Combo(Me.cboDtl)
                        Exit Function
                    End If
                End If
                .Tables("result").DefaultView.RowFilter = ""
                .Tables("result").DefaultView.RowFilter = ("Grd_Seq = " & Me.txtSeq.Text)
                isDuplicate = False
            End With

            Cursor = Cursors.Default
        ElseIf Me.optType1.Checked = True Then
            isDuplicate = False
        Else
            isDuplicate = False
        End If
        Exit Function
err_Handle_Invalid_Dtl:
        MsgBox("Invalid Detail Record!")
        isDuplicate = True
    End Function

    Private Function isGreater_Long(ByVal FmValue As String, ByVal tovalue As String) As Boolean
        isGreater_Long = False
        On Error GoTo err_Handle_Not_Long
        If CLng(tovalue) >= CLng(FmValue) Then
            isGreater_Long = True
        End If
        Exit Function
err_Handle_Not_Long:
        Err.Clear()
        isGreater_Long = True
        '    If Len(FmValue) = Len(ToValue) And Trim(ToValue) < Trim(FmValue) Then
        '        isGreater_Long = False
        '    End If
    End Function

    Private Sub setFocus_Combo(ByVal cbo As ComboBox)
        If cbo.Enabled = True And cbo.Visible = True Then
            cbo.Focus()

            cbo.SelectionStart = 0
            cbo.SelectionLength = Len(cbo.Text)
        End If
    End Sub

    Private Sub setFocus_text(ByVal txt As TextBox)
        If txt.Enabled = True And txt.Visible = True Then
            txt.Focus()
            txt.SelectionStart = 0
            txt.SelectionLength = Len(txt.Text)
        End If
    End Sub
    Private Sub setFocus_text_rich(ByVal txt As RichTextBox)
        If txt.Enabled = True And txt.Visible = True Then
            txt.Focus()
            txt.SelectionStart = 0
            txt.SelectionLength = Len(txt.Text)
        End If
    End Sub

    Private Sub SetStatusBar(Optional ByVal msg As String = "", Optional ByVal idx As Integer = 0)
        If msg <> "" Then
            Me.StatusBar.Panels(idx).Text = msg
        Else
            If btcMPM00002.SelectedIndex = 0 Then
                If addFlag = True Then

                Else

                End If
            ElseIf btcMPM00002.SelectedIndex = 1 Then

            Else

            End If
        End If
    End Sub

    Private Sub show_detail_msg(ByVal str As String, ByVal obj As Control)
        bolDisplay = True
        If btcMPM00002.Enabled = True Then btcMPM00002.SelectedIndex = 1
        bolDisplay = False
        MsgBox(str)
        If TypeOf obj Is ComboBox Then
            Call setFocus_Combo(obj)
        ElseIf TypeOf obj Is TextBox Then
            Call setFocus_text(obj)
        End If

    End Sub

    Private Sub show_header_msg(ByVal str As String, ByVal obj As Control)
        bolDisplay = True
        If btcMPM00002.Enabled = True Then btcMPM00002.SelectedIndex = 0
        bolDisplay = False
        MsgBox(str)
        If TypeOf obj Is ComboBox Then
            Call setFocus_Combo(obj)
        ElseIf TypeOf obj Is TextBox Then
            Call setFocus_text(obj)
        End If

    End Sub



    Private Sub showGroup()
        Dim i As Integer
        Me.cboGroup.Items.Clear()
        If rs_Group.Tables("result") Is Nothing Then Exit Sub

        With rs_Group
            .Tables("result").DefaultView.RowFilter = ""
            If .Tables("result").Rows.Count > 0 Then
                .Tables("result").DefaultView.Sort = "_grp"

                For index As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                    cboGroup.Items.Add(.Tables("RESULT").DefaultView(index)("_grp"))
                Next

            End If
        End With


    End Sub

    Private Sub checkCTN(ByVal strCTNFm As String, ByVal strCTNTo As String)
        If Trim(strCTNFm) = "" Then Exit Sub
        If Trim(strCTNTo) = "" Then Exit Sub

        If rs_CTN.Tables("result") Is Nothing Then Exit Sub
        With rs_CTN
            If .Tables("result").Rows.Count > 0 Then
                .Tables("result").DefaultView.RowFilter = "_FM = '" & UCase(Trim(strCTNFm)) & "'"
                If .Tables("result").Rows.Count > 0 Then
                    .Tables("result").DefaultView.RowFilter = ""
                    Exit Sub
                End If
            End If
        End With
        With rs_Group
            .Tables("RESULT").Rows.Add()
            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_FM") = UCase(Trim(strCTNFm))

        End With
        'Call showGroup
    End Sub

    Private Sub addtoGroup(ByVal strgrp As String)
        If Trim(strgrp) = "" Then Exit Sub
        If rs_Group.Tables("result") Is Nothing Then Exit Sub
        With rs_Group
            If .Tables("result").Rows.Count > 0 Then
                .Tables("result").DefaultView.RowFilter = "_grp = '" & UCase(Trim(strgrp)) & "'"
                If .Tables("result").DefaultView.Count > 0 Then
                    .Tables("result").DefaultView.RowFilter = ""
                    Exit Sub
                End If
            End If
        End With
        With rs_Group
            .Tables("RESULT").Rows.Add()
            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_grp") = UCase(Trim(strgrp))
            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_CustCat") = rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_CustCat")
            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_CtnFm") = rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_CtnFm")
            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_CtnTo") = rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_CtnTo")
            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_TtlCTN") = rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_TtlCtn")
            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_CtnUM") = rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_CtnUM")
            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_GW") = rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_GW")
            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_NW") = rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_NW")
            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_TtlGW") = rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_TtlGW")
            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_TtlNW") = rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_TtlNW")
            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_CustUM") = rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_CustUM")
            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_CustQty") = rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_CustQty")
            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_untprc") = rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_UntPrc")


        End With
        Call showGroup()
    End Sub

    Private Sub initGroup()
        Dim strgrp As String
        Dim pos As Integer

        Me.cboGroup.Items.Clear()

        If rs_GRNTRFDTL.Tables("result") Is Nothing Then Exit Sub
        If rs_GRNTRFDTL.Tables("result").Rows.Count <= 0 Then Exit Sub
        'If rs_Group.Tables("result")  Is Nothing Then Exit Sub

        If rs_Group Is Nothing Then
            'If rs_Group.Tables("result") Is Nothing Then
            Call createGroup()
        End If
        If rs_Group.Tables("result") Is Nothing Then Exit Sub


        ''''''''''''''''''''''''
        For index As Integer = 0 To rs_GRNTRFDTL.Tables("RESULT").Rows.Count - 1

            With rs_Group
                strgrp = rs_GRNTRFDTL.Tables("RESULT").Rows(index)("Grd_Grp")
                If strgrp <> "" Then
                    .Tables("result").DefaultView.RowFilter = "_grp = '" & Trim(strgrp) & "'"
                    If .Tables("result").DefaultView.Count <= 0 Then
                        .Tables("RESULT").Rows.Add()
                        .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_grp") = Trim(strgrp)
                        .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_CustCat") = rs_GRNTRFDTL.Tables("RESULT").Rows(index)("Grd_CustCat")
                        .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_CtnFm") = rs_GRNTRFDTL.Tables("RESULT").Rows(index)("Grd_CtnFm")
                        .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_CtnTo") = rs_GRNTRFDTL.Tables("RESULT").Rows(index)("Grd_CtnTo")
                        .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_TtlCTN") = rs_GRNTRFDTL.Tables("RESULT").Rows(index)("Grd_TtlCtn")
                        .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_CtnUM") = rs_GRNTRFDTL.Tables("RESULT").Rows(index)("Grd_CtnUM")
                        .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_GW") = rs_GRNTRFDTL.Tables("RESULT").Rows(index)("Grd_GW")
                        .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_NW") = rs_GRNTRFDTL.Tables("RESULT").Rows(index)("Grd_NW")
                        .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_TtlGW") = rs_GRNTRFDTL.Tables("RESULT").Rows(index)("Grd_TtlGW")
                        .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_TtlNW") = rs_GRNTRFDTL.Tables("RESULT").Rows(index)("Grd_TtlNW")
                        .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_CustUM") = rs_GRNTRFDTL.Tables("RESULT").Rows(index)("Grd_CustUM")
                        .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_CustQty") = rs_GRNTRFDTL.Tables("RESULT").Rows(index)("Grd_CustQty")
                        .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_untprc") = rs_GRNTRFDTL.Tables("RESULT").Rows(index)("Grd_UntPrc")
                    End If
                End If
            End With
        Next
        ''''''''''''''''''''''''

        Call showGroup()
    End Sub


    Private Sub UpdateDetail()
        Dim bolUpdate As Boolean
        If rs_GRNTRFDTL.Tables("result") Is Nothing Then Exit Sub
        If rs_GRNTRFDTL.Tables("result").Rows.Count <= 0 Then Exit Sub

        'If rs_GRNTRFDTL.BOF Then Exit Sub
        'If rs_GRNTRFDTL.EOF Then Exit Sub

        If rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("CreUsr") = "~*NEW*~" Or rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Del") = "Y" Then Exit Sub

        With rs_GRNTRFDTL
            If .Tables("RESULT").Rows(readingindex)("CreUsr") = "~*ADD*~" Then
                .Tables("RESULT").Rows(readingindex)("Grd_Type") = Trim(IIf(Me.optType0.Checked = True, "MPO", IIf(Me.optType1.Checked = True, "AdHoc", "Misc")))
                .Tables("RESULT").Rows(readingindex)("Grd_ItmNo") = Trim(Me.txtItmNo.Text)
                .Tables("RESULT").Rows(readingindex)("Grd_ItmNam") = Trim(Me.txtItmNam.Text)
                .Tables("RESULT").Rows(readingindex)("Grd_PrtGrp") = Trim(Me.txtPrtGrp.Text) 'Frankie Cheung 20091015
                '.Tables("RESULT").Rows(readingindex)("Grd_ItmDsc") = Trim(Me.txtItmDesc.Text)
                .Tables("RESULT").Rows(readingindex)("Grd_Color") = Trim(Me.txtColor.Text)
                .Tables("RESULT").Rows(readingindex)("Grd_Curr") = Trim(Me.cboCurr.Text)
                .Tables("RESULT").Rows(readingindex)("Grd_UntPrc") = CDbl(IIf(Me.txtUntPrc.Text = "", 0, Me.txtUntPrc.Text))
                .Tables("RESULT").Rows(readingindex)("Grd_TtlShpQty") = CDbl(Me.txtShpQty.Text)
                .Tables("RESULT").Rows(readingindex)("Grd_CustQty") = CDbl(Me.txtCustQty.Text)
                .Tables("RESULT").Rows(readingindex)("Grd_ShpUM") = Trim(Me.txtShpUM.Text)
                .Tables("RESULT").Rows(readingindex)("Grd_RevDept") = Trim(Me.txtDept.Text)
                '.Tables("RESULT").Rows(readingindex)("Grd_CustCat") = IIf(Trim(Me.cboCat.Text) = "", "", Trim(Split(Me.cboCat.Text, "-")(0)))
                .Tables("RESULT").Rows(readingindex)("Grd_CustCat") = Trim(Me.cboCat.Text)
                .Tables("RESULT").Rows(readingindex)("Grd_Cty") = Trim(Me.cboCountry.Text)
                .Tables("RESULT").Rows(readingindex)("Grd_CTNFm") = Trim(Me.txtCTNFm.Text)
                .Tables("RESULT").Rows(readingindex)("Grd_CTNTo") = Trim(Me.txtCTNTo.Text)
                .Tables("RESULT").Rows(readingindex)("Grd_TtlCTN") = IIf(Me.txtTtlCTN_D.Text = "", 0, CLng(Me.txtTtlCTN_D.Text))
                .Tables("RESULT").Rows(readingindex)("Grd_CtnUM") = Trim(Me.cboTtlCTN_D_UM.Text)
                .Tables("RESULT").Rows(readingindex)("Grd_GW") = CDbl(IIf(Me.txtGW.Text = "", 0, Me.txtGW.Text))
                .Tables("RESULT").Rows(readingindex)("Grd_NW") = CDbl(IIf(Me.txtNW.Text = "", 0, Me.txtNW.Text))
                .Tables("RESULT").Rows(readingindex)("Grd_TtlGW") = CDbl(IIf(Me.txtTtlGW_D.Text = "", 0, Me.txtTtlGW_D.Text))
                .Tables("RESULT").Rows(readingindex)("Grd_TtlNW") = CDbl(IIf(Me.txtTtlNW_D.Text = "", 0, Me.txtTtlNW_D.Text))
                .Tables("RESULT").Rows(readingindex)("Grd_PckWgt") = CDbl(IIf(Me.txtPck.Text = "", 0, Me.txtPck.Text))
                .Tables("RESULT").Rows(readingindex)("Grd_PckUM") = Trim(Me.txtPck_UM.Text)
                .Tables("RESULT").Rows(readingindex)("Grd_Grp") = Trim(Me.cboGroup.Text)
                .Tables("RESULT").Rows(readingindex)("Grd_RefNo") = Trim(Me.txtPONo.Text)
                '------------------------------------------------
                '2005-10-14
                '.Tables("RESULT").Rows(readingindex)("Grd_CustUM") = Trim(Me.txtCustUM.Text)
                .Tables("RESULT").Rows(readingindex)("Grd_CustUM") = Trim(Me.CboCustUM.Text)
                .Tables("RESULT").Rows(readingindex)("Grd_DtlRmk") = Trim(Me.txtDtlRmk.Text)
                '------------------------------------------------
                Call addtoGroup(Trim(Me.cboGroup.Text))

            Else
                bolUpdate = False
                If .Tables("RESULT").Rows(readingindex)("Grd_ItmNo") <> Trim(Me.txtItmNo.Text) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_ItmNo") = Trim(Me.txtItmNo.Text)
                    bolUpdate = True
                End If

                If .Tables("RESULT").Rows(readingindex)("Grd_ItmNam") <> Trim(Me.txtItmNam.Text) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_ItmNam") = Trim(Me.txtItmNam.Text)
                    bolUpdate = True
                End If

                '            If .Tables("RESULT").Rows(readingindex)("Grd_ItmDsc") <> Trim(Me.txtItmDesc.Text) Then
                '                .Tables("RESULT").Rows(readingindex)("Grd_ItmDsc") = Trim(Me.txtItmDesc.Text)
                '                bolUpdate = True
                '            End If

                If .Tables("RESULT").Rows(readingindex)("Grd_Color") <> Trim(Me.txtColor.Text) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_Color") = Trim(Me.txtColor.Text)
                    bolUpdate = True
                End If

                If .Tables("RESULT").Rows(readingindex)("Grd_Curr") <> Trim(Me.cboCurr.Text) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_curr") = Trim(Me.cboCurr.Text)
                    bolUpdate = True
                End If


                If .Tables("RESULT").Rows(readingindex)("Grd_UntPrc") <> CDbl(IIf(Me.txtUntPrc.Text = "", 0, Me.txtUntPrc.Text)) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_UntPrc") = CDbl(IIf(Me.txtUntPrc.Text = "", 0, Me.txtUntPrc.Text))
                    bolUpdate = True
                End If

                If .Tables("RESULT").Rows(readingindex)("Grd_TtlShpQty") <> CDbl(IIf(Me.txtShpQty.Text = "", 0, Me.txtShpQty.Text)) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_TtlShpQty") = CDbl(IIf(Me.txtShpQty.Text = "", 0, Me.txtShpQty.Text))
                    bolUpdate = True
                End If

                If .Tables("RESULT").Rows(readingindex)("Grd_CustQty") <> CDbl(IIf(Me.txtCustQty.Text = "", 0, Me.txtCustQty.Text)) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_CustQty") = CDbl(IIf(Me.txtCustQty.Text = "", 0, Me.txtCustQty.Text))
                    bolUpdate = True
                End If

                If .Tables("RESULT").Rows(readingindex)("Grd_ShpUM") <> Trim(Me.txtShpUM.Text) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_ShpUM") = Trim(Me.txtShpUM.Text)
                    bolUpdate = True
                End If

                If .Tables("RESULT").Rows(readingindex)("Grd_RefNo") <> Trim(Me.txtPONo.Text) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_RefNo") = Trim(Me.txtPONo.Text)
                    bolUpdate = True
                End If

                If .Tables("RESULT").Rows(readingindex)("Grd_RevDept") <> Trim(Me.txtDept.Text) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_RevDept") = Trim(Me.txtDept.Text)
                    bolUpdate = True
                End If

                '            If .Tables("RESULT").Rows(readingindex)("Grd_CustCat") <> IIf(Trim(Me.cboCat.Text) = "", "", Trim(Split(Me.cboCat.Text, "-")(0))) Then
                '                .Tables("RESULT").Rows(readingindex)("Grd_CustCat") = IIf(Trim(Me.cboCat.Text) = "", "", Trim(Split(Me.cboCat.Text, "-")(0)))
                '                bolUpdate = True
                '            End If

                If .Tables("RESULT").Rows(readingindex)("Grd_CustCat") <> Trim(Me.cboCat.Text) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_CustCat") = Trim(Me.cboCat.Text)
                    bolUpdate = True
                End If

                If .Tables("RESULT").Rows(readingindex)("Grd_Cty") <> Trim(Me.cboCountry.Text) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_Cty") = Trim(Me.cboCountry.Text)
                    bolUpdate = True
                End If

                If .Tables("RESULT").Rows(readingindex)("Grd_CTNFm") <> Trim(Me.txtCTNFm.Text) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_CTNFm") = Trim(Me.txtCTNFm.Text)
                    bolUpdate = True
                End If

                If .Tables("RESULT").Rows(readingindex)("Grd_CTNTo") <> Trim(Me.txtCTNTo.Text) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_CTNTo") = Trim(Me.txtCTNTo.Text)
                    bolUpdate = True
                End If

                If .Tables("RESULT").Rows(readingindex)("Grd_TtlCTN") <> CLng(IIf(Me.txtTtlCTN_D.Text = "", 0, Me.txtTtlCTN_D.Text)) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_TtlCTN") = CLng(IIf(Me.txtTtlCTN_D.Text = "", 0, Me.txtTtlCTN_D.Text))
                    bolUpdate = True
                End If

                If .Tables("RESULT").Rows(readingindex)("Grd_CtnUM") <> Trim(Me.cboTtlCTN_D_UM.Text) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_CtnUM") = Trim(Me.cboTtlCTN_D_UM.Text)
                    bolUpdate = True
                End If

                If .Tables("RESULT").Rows(readingindex)("Grd_GW") <> CDbl(IIf(Me.txtGW.Text = "", 0, Me.txtGW.Text)) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_GW") = CDbl(IIf(Me.txtGW.Text = "", 0, Me.txtGW.Text))
                    bolUpdate = True
                End If

                If .Tables("RESULT").Rows(readingindex)("Grd_NW") <> CDbl(IIf(Me.txtNW.Text = "", 0, Me.txtNW.Text)) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_NW") = CDbl(IIf(Me.txtNW.Text = "", 0, Me.txtNW.Text))
                    bolUpdate = True
                End If

                If .Tables("RESULT").Rows(readingindex)("Grd_TtlGW") <> CDbl(IIf(Me.txtTtlGW_D.Text = "", 0, Me.txtTtlGW_D.Text)) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_TtlGW") = CDbl(IIf(Me.txtTtlGW_D.Text = "", 0, Me.txtTtlGW_D.Text))
                    bolUpdate = True
                End If

                If .Tables("RESULT").Rows(readingindex)("Grd_TtlNW") <> CDbl(IIf(Me.txtTtlNW_D.Text = "", 0, Me.txtTtlNW_D.Text)) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_TtlNW") = CDbl(IIf(Me.txtTtlNW_D.Text = "", 0, Me.txtTtlNW_D.Text))
                    bolUpdate = True
                End If

                If .Tables("RESULT").Rows(readingindex)("Grd_PckWgt") <> CDbl(IIf(Me.txtPck.Text = "", 0, Me.txtPck.Text)) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_PckWgt") = CDbl(IIf(Me.txtPck.Text = "", 0, Me.txtPck.Text))
                    bolUpdate = True
                End If

                If .Tables("RESULT").Rows(readingindex)("Grd_PckUM") <> Trim(Me.txtPck_UM.Text) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_PckUM") = Trim(Me.txtPck_UM.Text)
                    bolUpdate = True
                End If

                If .Tables("RESULT").Rows(readingindex)("Grd_Grp") <> Trim(Me.cboGroup.Text) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_Grp") = Trim(Me.cboGroup.Text)
                    Call addtoGroup(Trim(Me.cboGroup.Text))
                    bolUpdate = True
                End If

                '---------------------------------------------------------
                '2005-10-14
                '            If .Tables("RESULT").Rows(readingindex)("Grd_CustUM") <> Trim(Me.txtCustUM.Text) Then
                '                .Tables("RESULT").Rows(readingindex)("Grd_CustUM") = Trim(Me.txtCustUM.Text)
                '                bolUpdate = True
                '            End If
                If .Tables("RESULT").Rows(readingindex)("Grd_CustUM") <> Trim(Me.CboCustUM.Text) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_CustUM") = Trim(Me.CboCustUM.Text)
                    bolUpdate = True
                End If

                If .Tables("RESULT").Rows(readingindex)("Grd_DtlRmk") <> Trim(Me.txtDtlRmk.Text) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_DtlRmk") = Trim(Me.txtDtlRmk.Text)
                    bolUpdate = True
                End If

                ' Frankie Cheung 20091015
                If .Tables("RESULT").Rows(readingindex)("Grd_PrtGrp") <> Trim(Me.txtPrtGrp.Text) Then
                    .Tables("RESULT").Rows(readingindex)("Grd_PrtGrp") = Trim(Me.txtPrtGrp.Text)
                    bolUpdate = True
                End If

                '---------------------------------------------------------

                If bolUpdate = True Then
                    If .Tables("RESULT").Rows(readingindex)("Del") <> "Y" And .Tables("RESULT").Rows(readingindex)("CreUsr") <> "~*NEW*~" And .Tables("RESULT").Rows(readingindex)("CreUsr") <> "~*ADD*~" Then
                        .Tables("RESULT").Rows(readingindex)("CreUsr") = "~*UPD*~"
                    End If
                End If

            End If



        End With
        '---------------------------------


    End Sub

    Private Sub UpdateGrid()
        Dim shpqty As Double
        shpqty = 0

        If Not rs_GRNTRFLST.Tables("result") Is Nothing Then
            With rs_GRNTRFLST
                If .Tables("result").Rows.Count > 0 Then

                    For index As Integer = 0 To rs_GRNTRFLST.Tables("RESULT").Rows.Count - 1

                        If .Tables("RESULT").Rows(index)("ShpQty") > .Tables("RESULT").Rows(index)("Cul_OSQty") + .Tables("RESULT").Rows(index)("Prv_ShpQty") Then
                            .Tables("RESULT").Rows(index)("ShpQty") = .Tables("RESULT").Rows(index)("Cul_OSQty") + .Tables("RESULT").Rows(index)("Prv_ShpQty")
                        End If
                        '======================================================================================================================
                        '<CULMULATIVE QTY>
                        Call CumulativeQty_update(.Tables("RESULT").Rows(index)("Grl_PONo"), .Tables("RESULT").Rows(index)("Grl_POSeq"), .Tables("RESULT").Rows(index)("Mpd_ItmNo"), .Tables("RESULT").Rows(index)("ShpQty") - .Tables("RESULT").Rows(index)("Prv_Shpqty"), 0)
                        .Tables("RESULT").Rows(index)("Cul_ShpQty") = CumulativeQty_show(.Tables("RESULT").Rows(index)("Grl_PONo"), .Tables("RESULT").Rows(index)("Grl_POSeq"), .Tables("RESULT").Rows(index)("Mpd_ItmNo"), "SHP")
                        .Tables("RESULT").Rows(index)("Cul_OSQty") = CumulativeQty_show(.Tables("RESULT").Rows(index)("Grl_PONo"), .Tables("RESULT").Rows(index)("Grl_POSeq"), .Tables("RESULT").Rows(index)("Mpd_ItmNo"), "OS")
                        '======================================================================================================================
                        .Tables("RESULT").Rows(index)("Prv_ShpQty") = IIf(IsDBNull(.Tables("RESULT").Rows(index)("ShpQty")), 0, .Tables("RESULT").Rows(index)("ShpQty"))
                        shpqty = shpqty + CDbl(IIf(IsDBNull(.Tables("RESULT").Rows(index)("ShpQty")), 0, .Tables("RESULT").Rows(index)("ShpQty")))

                    Next


                End If
            End With
        End If
        Me.txtShpQty.Text = shpqty
    End Sub


    Private Sub Grid_CalSubTtl()
        Dim subttl As Double
        Dim untprc As Double
        subttl = 0

        untprc = CDbl(IIf(Trim(Me.txtUntPrc.Text) <> "", Me.txtUntPrc.Text, 0))

        If Not rs_GRNTRFLST.Tables("result") Is Nothing Then
            With rs_GRNTRFLST
                '''''''''''''''''''''''''''''
                For index As Integer = 0 To rs_GRNTRFLST.Tables("RESULT").Rows.Count - 1
                    subttl = subttl + CDbl(IIf(IsDBNull(.Tables("RESULT").Rows(index)("ShpQty")), 0, .Tables("RESULT").Rows(index)("ShpQty"))) * untprc
                Next
                ''''''''''''''''''''''''

            End With
        End If
        'Me.txtSubTtl.Text = Format(subttl, "######.#0")
    End Sub


    Private Sub cboCat_LostFocus()
        If ValidateCombo(Me.cboCat) = False Then
            Exit Sub
        End If
    End Sub


    Private Sub cboCurr_Click()
        Dim current_pos As Integer

        On Error GoTo err_handle_curr
        If Me.cboCurr.Text <> strCurrGBL Then
            If MsgBox("The currency of the whole GRN will be changed?", vbOKCancel) = vbOK Then
                strCurrGBL = Me.cboCurr.Text
                If rs_GRNTRFDTL.Tables("result") Is Nothing Then Exit Sub
                '                If rs_GRNTRFDTL.EOF Then Exit Sub
                Cursor = Cursors.WaitCursor
                'current_() 'pos = rs_GRNTRFDTL.AbsolutePosition



                With rs_GRNTRFDTL
                    For index As Integer = 0 To rs_GRNTRFDTL.Tables("RESULT").Rows.Count - 1
                        If .Tables("RESULT").Rows(index)("Grd_Curr") <> strCurrGBL Then
                            .Tables("RESULT").Rows(index)("Grd_Curr") = strCurrGBL
                            If .Tables("RESULT").Rows(index)("CreUsr") <> "~*NEW*~" And .Tables("RESULT").Rows(index)("CreUsr") <> "~*ADD*~" And .Tables("RESULT").Rows(index)("Del") <> "Y" Then
                                .Tables("RESULT").Rows(index)("CreUsr") = "~*UPD*~"
                            End If
                        End If
                    Next
                End With

                'If current_pos > 0 Then rs_GRNTRFDTL.AbsolutePosition = current_pos
                Cursor = Cursors.Default
            Else
                Call displaycombo(cboCurr, Trim(strCurrGBL))
                Cursor = Cursors.Default
            End If
        End If
        Exit Sub
err_handle_curr:
        MsgBox(Err.Description, , "")
        Err.Clear()
    End Sub

    Private Sub cboCurr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCurr.GotFocus
        flag_cboCurr_GotFocus = True

    End Sub

    Private Sub cboCurr_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCurr.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    'Private Sub cboCurr_KeyPress(ByVal Asc(e.KeyChar) As Integer)
    '    e.KeyChar = Chr(0)
    'End Sub

    Private Sub cboCurr_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCurr.KeyUp
        Call auto_search_combo(Me.cboCurr, e.KeyCode)
    End Sub
    'Private Sub cboCurr_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
    '    Call auto_search_combo(Me.cboCurr, e.KeyCode)
    'End Sub

    Private Sub cboCurr_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCurr.LostFocus
        If ValidateCombo(Me.cboCurr) = False Then
            'MsgBox "Please select from dropdown menu!"
            Exit Sub
        End If
    End Sub


    'Private Sub cboCurr_LostFocus()
    '    If ValidateCombo(Me.cboCurr) = False Then
    '        'MsgBox "Please select from dropdown menu!"
    '        Exit Sub
    '    End If
    'End Sub




    Private Sub cboDest_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDest.SelectedIndexChanged
        If Me.cboDest.Text = "" Then Me.txtDestAddr.Text = ""

        Me.txtDestAddr.Text = ""
        If Trim(Me.cboDest.Text) <> "" Then
            If Not rs_DEST.Tables("result") Is Nothing Then
                With rs_DEST
                    If .Tables("result").Rows.Count > 0 Then
                        .Tables("result").DefaultView.RowFilter = "ShpPlc='" & Trim(Me.cboDest.Text) & "'"
                        If .Tables("result").DefaultView.Count > 0 Then
                            Me.txtDestAddr.Text = .Tables("RESULT").DefaultView(0)("_Bill_Addr")
                        End If
                        .Tables("result").DefaultView.RowFilter = ""
                    End If
                End With
            End If
        End If

    End Sub

    'Private Sub cboDest_Change()
    '    If Me.cboDest.Text = "" Then Me.txtDestAddr.Text = ""
    'End Sub

    'Private Sub cboDest_Click()
    '    Me.txtDestAddr.Text = ""
    '    If Trim(Me.cboDest.Text) <> "" Then
    '        If Not rs_DEST.Tables("result") Is Nothing Then
    '            With rs_DEST
    '                If .Tables("result").Rows.Count > 0 Then
    '                    .Tables("result").DefaultView.RowFilter = "ShpPlc='" & Trim(Me.cboDest.Text) & "'"
    '                    If .Tables("result").Rows.Count > 0 Then
    '                        Me.txtDestAddr.Text = .Fields("_Bill_Addr")
    '                    End If
    '                    .Tables("result").DefaultView.RowFilter = ""
    '                End If
    '            End With
    '        End If
    '    End If
    'End Sub



    Private Sub cboDest_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDest.KeyPress
        If e.KeyChar = Chr(13) Then
            '            Call cboDest_Click()
            'temp
        End If
        If e.KeyChar <> Chr(9) And e.KeyChar <> Chr(8) And Len(Me.cboDest.Text) > 100 Then
            e.KeyChar = Chr(0)
        End If

    End Sub

    'Private Sub cboDest_KeyPress(ByVal Asc(e.KeyChar) As Integer)
    '    If Asc(e.KeyChar) = 13 Then
    '        Call cboDest_Click()
    '    End If
    '    If e.KeyChar <> 9 And e.KeyChar <> 8 And Len(Me.cboDest.Text) > 100 Then
    '        e.KeyChar = Chr(0)
    '    End If
    'End Sub
    Private Sub cboDest_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDest.KeyUp
        Call auto_search_combo(Me.cboDest, e.KeyCode)
    End Sub


    Private Sub cboDtl_Change()
        If Trim(Me.cboDtl.Text) = "" Then
            'Clear Detail record
            Call clearDetail("DTL")
        End If
    End Sub

    Private Sub cboDtl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDtl.GotFocus
        flag_cboDtl_KeyPress = True
    End Sub

    Private Sub cboDtl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDtl.KeyPress
        flag_cboDtl_KeyPress = True
    End Sub

    Private Sub cboDtl_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDtl.LostFocus

    End Sub

    Private Sub cboDtl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDtl.SelectedIndexChanged
        If flag_cboDtl_KeyPress = True Then
            flag_cboDtl_KeyPress = False

            Dim itmNo As String
            Dim um As String
            Dim color As String
            Dim bolOne As Boolean
            Dim lngOrd As Double
            Dim lngOS As Double
            Dim i As Integer

            Dim strCurr As String
            Dim dblUntPrc As Double


            If Me.cboDtl.Text = "" Then Exit Sub

            If isDuplicate() Then Exit Sub

            On Error GoTo err_Handle_split

            itmNo = Trim(Split(Me.cboDtl.Text, ";")(0))
            color = Trim(Split(Me.cboDtl.Text, ";")(2))
            um = Trim(Split(Me.cboDtl.Text, ";")(3))
            On Error GoTo 0

            On Error GoTo err_Handle_sp

            Cursor = Cursors.WaitCursor




            gspStr = "sp_select_MPM00002  '','" & Trim(Me.cboMPONo.Text) & "','" & itmNo & "','" & um & "','" & color & "','DTL'"
            Cursor = Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_MPORDDTL_dtl, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading  sp_select_MPM00002  :" & rtnStr)
                Exit Sub
            Else
                ''''''''''''''''''''''''''''''''''''
                If rs_MPORDDTL_dtl.Tables("result").Rows.Count > 0 Then

                    bolDisplay = True

                    rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_MpoNo") = Trim(Me.cboMPONo.Text)
                    rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_ItmNo") = itmNo
                    rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_ShpUM") = um
                    rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_Color") = color
                    rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Del") = "N"

                    'Set Me.grdDtlLst.DataSource = rs_MPORDDTL_dtl
                    Call displayGrdDtlLst_add()
                    Call displayGrdDtlLst()
                    'Call showGroup

                    With rs_MPORDDTL_dtl
                        If .Tables("result").Rows.Count = 1 Then bolOne = True

                        '.MoveFirst()

                        'Me.txtCustUM.ReadOnly = True
                        '2008-02-28
                        'Me.CboCustUM.ReadOnly = True
                        'Me.txtCustUM.Text = .Tables("RESULT").Rows(readingindex)("Zil_CustUM")
                        Me.CboCustUM.Text = .Tables("RESULT").Rows(0)("Zil_CustUM")
                        Me.txtCustQty.Text = "0"
                        Me.txtCustSubTtl.Text = "0"
                        Me.txtItmNo.Text = itmNo
                        Me.txtColor.Text = color
                        Me.txtItmNam.Text = .Tables("RESULT").Rows(0)("Mpd_ItmNam")
                        'Me.txtItmDesc.Text = .Tables("RESULT").Rows(readingindex)("Mpd_ItmDsc")
                        Me.txtPONo.Text = "" '.Tables("RESULT").Rows(readingindex)("Mpd_PONo")
                        Me.txtDtlRmk.Text = ""  '2005-10-14
                        Me.cboCat.Text = .Tables("RESULT").Rows(0)("CustCat")
                        Me.cboCountry.Text = ""
                        Me.txtDept.Text = ""

                        Me.txtCTNFm.Text = ""
                        Me.txtCTNTo.Text = ""
                        Me.txtTtlCTN_D.Text = ""
                        Me.cboTtlCTN_D_UM.Text = ""
                        Me.txtGW.Text = ""
                        Me.txtGW_UM.Text = "KG"
                        Me.txtNW.Text = ""
                        Me.txtNW_UM.Text = "KG"
                        Me.txtTtlGW_D.Text = ""
                        Me.txtTtlGW_D_UM.Text = "KG"
                        Me.txtTtlNW_D.Text = ""
                        Me.txtTtlNW_D_UM.Text = "KG"
                        Me.txtPck.Text = ""
                        Me.txtPck_UM.Text = "KG"
                        Me.txtCustQty.Text = "0"
                        txtCustSubTtl.Text = "0"

                        dblUntPrc = .Tables("RESULT").Rows(0)("Mpd_UntPrc")
                        For i = 0 To .Tables("result").Rows.Count - 1
                            lngOrd = lngOrd + .Tables("RESULT").Rows(0)("Mpd_Qty")
                            lngOS = lngOS + .Tables("RESULT").Rows(0)("OSQty")
                            If dblUntPrc > .Tables("RESULT").Rows(0)("Mpd_UntPrc") Then dblUntPrc = .Tables("RESULT").Rows(readingindex)("Mpd_UntPrc")
                            '  .MoveNext()
                        Next

                        '.MoveFirst()
                        Me.txtQty.Text = lngOrd
                        Me.txtOSQty.Text = lngOS
                        Dtl_ORIQTY = 0
                        Me.txtShpQty.Text = "0"
                        Me.txtShpUM.Text = um
                        Me.cboCurr.Text = strCurrGBL '"HKD"
                        Me.txtUntPrc.Text = ""
                        'Me.txtMinPrc.Text = ""


                        'Me.txtSubTtl.Text = ""



                        ' Added by Mark Lau 20090616
                        Dim strPONO As String
                        strPONO = .Tables("RESULT").Rows(0)("Mpd_pono")
                        If optType1.Checked = True Or optType0.Checked = True Then

                            Me.txtDept.Text = GetRecvDept(strPONO)
                            Me.txtDept.Enabled = True
                        Else
                            Me.txtDept.Enabled = False
                        End If
                        strPONO = ""


                        Me.cboMPONo.Enabled = False
                        Me.cboDtl.Enabled = False

                        strCurr = .Tables("RESULT").Rows(0)("Mph_Curr")
                        If strCurr <> "HKD" Then
                            If dblExchange <= 0 Then
                                dblExchange = 0.12903225806
                            End If
                            Me.txtUntPrc.Text = Format(dblUntPrc / dblExchange, "#########.###0") '
                        Else
                            Me.txtUntPrc.Text = Format(dblUntPrc, "#########.###0")
                        End If
                        Call enableOptType(False)
                        bolDisplay = False
                    End With

                    Cursor = Cursors.Default
                    Exit Sub
                End If
                '''''''''''''''''''''''''''''''''''
            End If
            For i2 As Integer = 0 To rs_MPORDDTL_dtl.Tables("RESULT").Columns.Count - 1
                rs_MPORDDTL_dtl.Tables("RESULT").Columns(i2).ReadOnly = False
            Next

            Call clearDetail("DTL")
            MsgBox("Detail record not found")
            Cursor = Cursors.Default

            cboMPONo.Enabled = False
            cboDtl.Enabled = False




            Exit Sub
err_Handle_split:
            MsgBox(Err.Description, , "Item list value not valid!")
            Err.Clear()
            bolDisplay = False
            Cursor = Cursors.Default
            Exit Sub
err_Handle_sp:
            MsgBox(Err.Description, , "Retrieve item detail failure!")
            Err.Clear()
            bolDisplay = False
            Cursor = Cursors.Default

        End If

    End Sub

    '
    '   Private Sub cboDtl_Click()
    '        Dim itmNo As String
    '        Dim um As String
    '        Dim color As String
    '        Dim bolOne As Boolean
    '        Dim lngOrd As Double
    '        Dim lngOS As Double
    '        Dim i As Integer

    '        Dim strCurr As String
    '        Dim dblUntPrc As Double


    '        If Me.cboDtl.Text = "" Then Exit Sub

    '        If isDuplicate() Then Exit Sub

    '        On Error GoTo err_Handle_split

    '        itmNo = Trim(Split(Me.cboDtl.Text, ";")(0))
    '        color = Trim(Split(Me.cboDtl.Text, ";")(2))
    '        um = Trim(Split(Me.cboDtl.Text, ";")(3))
    '        On Error GoTo 0

    '        On Error GoTo err_Handle_sp

    '        Cursor = Cursors.WaitCursor
    '        
    '        


    '        gspStr = "sp_select_MPM00002  ','" & Trim(Me.cboMPONo.Text) & "','" & itmNo & "','" & um & "','" & color & "','DTL"
    '        Cursor = Cursors.WaitCursor
    '        rtnLong = execute_SQLStatement(gspStr, rs_MPORDDTL_dtl, rtnStr)
    '        If rtnLong <> RC_SUCCESS Then
    '            MsgBox("Error on loading  sp_select_MMPORDHDR :" & rtnStr)
    '            Exit Sub
    '        Else
    '            ''''''''''''''''''''''''''''''''''''
    '            If rs_MPORDDTL_dtl.Tables("result").Rows.Count > 0 Then

    '                bolDisplay = True

    '                rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_MpoNo") = Trim(Me.cboMPONo.Text)
    '                rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_ItmNo") = itmNo
    '                rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_ShpUM") = um
    '                rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_Color") = color
    '                rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Del") = "N"

    '                'Set Me.grdDtlLst.DataSource = rs_MPORDDTL_dtl
    '                Call displayGrdDtlLst_add()
    '                Call displayGrdDtlLst()
    '                'Call showGroup

    '                With rs_MPORDDTL_dtl
    '                    If .Tables("result").Rows.Count = 1 Then bolOne = True

    '                    .MoveFirst()

    '                    'Me.txtCustUM.ReadOnly = True
    '                    '2008-02-28
    '                    'Me.CboCustUM.ReadOnly = True
    '                    'Me.txtCustUM.Text = .Fields("Zil_CustUM")
    '                    Me.CboCustUM.Text = .Fields("Zil_CustUM")
    '                    Me.txtCustQty.Text = "0"
    '                    Me.txtCustSubTtl.Text = "0"
    '                    Me.txtItmNo.Text = itmNo
    '                    Me.txtColor.Text = color
    '                    Me.txtItmNam.Text = .Fields("Mpd_ItmNam")
    '                    'Me.txtItmDesc.Text = .Fields("Mpd_ItmDsc")
    '                    Me.txtPONo.Text = "" '.Fields("Mpd_PONo")
    '                    Me.txtDtlRmk.Text = ""  '2005-10-14
    '                    Me.cboCat.Text = .Fields("CustCat")
    '                    Me.cboCountry.Text = ""
    '                    Me.txtDept.Text = ""

    '                    Me.txtCTNFm.Text = ""
    '                    Me.txtCTNTo.Text = ""
    '                    Me.txtTtlCTN_D.Text = ""
    '                    Me.cboTtlCTN_D_UM.Text = ""
    '                    Me.txtGW.Text = ""
    '                    Me.txtGW_UM.Text = "KG"
    '                    Me.txtNW.Text = ""
    '                    Me.txtNW_UM.Text = "KG"
    '                    Me.txtTtlGW_D.Text = ""
    '                    Me.txtTtlGW_D_UM.Text = "KG"
    '                    Me.txtTtlNW_D.Text = ""
    '                    Me.txtTtlNW_D_UM.Text = "KG"
    '                    Me.txtPck.Text = ""
    '                    Me.txtPck_UM.Text = "KG"
    '                    Me.txtCustQty.Text = "0"
    '                    txtCustSubTtl.Text = "0"

    '                    dblUntPrc = .Fields("Mpd_UntPrc")
    '                    For i = 0 To .Tables("result").Rows.Count - 1
    '                        lngOrd = lngOrd + .Fields("Mpd_Qty")
    '                        lngOS = lngOS + .Fields("OSQty")
    '                        If dblUntPrc > .Fields("Mpd_UntPrc") Then dblUntPrc = .Fields("Mpd_UntPrc")
    '                        .MoveNext()
    '                    Next

    '                    .MoveFirst()
    '                    Me.txtQty.Text = lngOrd
    '                    Me.txtOSQty.Text = lngOS
    '                    Dtl_ORIQTY = 0
    '                    Me.txtShpQty.Text = "0"
    '                    Me.txtShpUM.Text = um
    '                    Me.cboCurr.Text = strCurrGBL '"HKD"
    '                    Me.txtUntPrc.Text = ""
    '                    'Me.txtMinPrc.Text = ""


    '                    'Me.txtSubTtl.Text = ""



    '                    ' Added by Mark Lau 20090616
    '                    Dim strPONO As String
    '                    strPONO = .Fields("Mpd_pono")
    '                    If optType1.checked = True Or optType0.checked = True Then

    '                        Me.txtDept.Text = GetRecvDept(strPONO)
    '                        Me.txtDept.Enabled = True
    '                    Else
    '                        Me.txtDept.Enabled = False
    '                    End If
    '                    strPONO = ""


    '                    Me.cboMPONo.Enabled = False
    '                    Me.cboDtl.Enabled = False

    '                    strCurr = .Fields("Mph_Curr")
    '                    If strCurr <> "HKD" Then
    '                        If dblExchange <= 0 Then
    '                            dblExchange = 0.12903225806
    '                        End If
    '                        Me.txtUntPrc.Text = Format(dblUntPrc / dblExchange, "#########.###0") '
    '                    Else
    '                        Me.txtUntPrc.Text = Format(dblUntPrc, "#########.###0")
    '                    End If
    '                    Call enableOptType(False)
    '                    bolDisplay = False
    '                End With

    '                Cursor = Cursors.Default
    '                Exit Sub
    '            End If
    '            '''''''''''''''''''''''''''''''''''
    '        End If
    '        For i2 As Integer = 0 To rs_MPORDDTL_dtl.Tables("RESULT").Columns.Count - 1
    '            rs_MPORDDTL_dtl.Tables("RESULT").Columns(i2).ReadOnly = False
    '        Next

    '        Call clearDetail("DTL")
    '        MsgBox("Detail record not found")
    '        Cursor = Cursors.Default

    '        Exit Sub
    'err_Handle_split:
    '        MsgBox(Err.Description, , "Item list value not valid!")
    '        Err.Clear()
    '        bolDisplay = False
    '        Cursor = Cursors.Default
    '        Exit Sub
    'err_Handle_sp:
    '        MsgBox(Err.Description, , "Retrieve item detail failure!")
    '        Err.Clear()
    '        bolDisplay = False
    '        Cursor = Cursors.Default
    '    End Sub



    'Private Sub cboDtl_KeyPress(ByVal Asc(e.KeyChar) As Integer)
    '    If Asc(e.KeyChar) = 13 Then
    '        Call cboDtl_Click()
    '    End If
    'End Sub
    Private Sub cboDtl_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDtl.KeyUp
        Call auto_search_combo(Me.cboDtl, e.KeyCode)
    End Sub


    Private Sub cboDtl_LostFocus()
        If ValidateCombo(Me.cboDtl) = False Then
            'MsgBox "Please select from dropdown menu!"
            Exit Sub
        End If
    End Sub

    Private Sub displayGrdDtlLst()
        grdDtlLst.DataSource = Nothing
        If rs_GRNTRFLST.Tables("result") Is Nothing Then Exit Sub
        If Trim(Me.txtSeq.Text) = "" Then Exit Sub
        rs_GRNTRFLST.Tables("result").DefaultView.RowFilter = "Grl_GrnSeq = " & Trim(Me.txtSeq.Text)

        If rs_GRNTRFLST.Tables("result").DefaultView.Count <= 0 Then Exit Sub
        '<CULMULATIVE QTY>
        With rs_GRNTRFLST
            For index As Integer = 0 To .Tables("result").DefaultView.Count - 1
                .Tables("result").DefaultView(index)("Cul_ShpQty") = CumulativeQty_show(.Tables("result").DefaultView(index)("Grl_PONo"), .Tables("result").DefaultView(index)("Grl_POSeq"), .Tables("result").DefaultView(index)("Mpd_ItmNo"), "SHP")
                .Tables("result").DefaultView(index)("Cul_OSQty") = CumulativeQty_show(.Tables("result").DefaultView(index)("Grl_PONo"), .Tables("result").DefaultView(index)("Grl_POSeq"), .Tables("result").DefaultView(index)("Mpd_ItmNo"), "OS")
            Next
        End With

        grdDtlLst.DataSource = rs_GRNTRFLST.Tables("result")
        Dim intCol As Integer

        With grdDtlLst
            intCol = 0
            .Columns(intCol).HeaderText = "CreUsr"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "PO #"   'Mpd_PONo,
            .Columns(intCol).Width = 120
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Seq"   '        Mpd_POSeq,
            .Columns(intCol).Width = 60
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ord Qty"   'Mpd_Qty,
            .Columns(intCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(intCol).Width = 60
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Delivery Qty"   'Mpd_DQty,
            .Columns(intCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(intCol).Width = 60
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "OS Qty"   'Mpd_Qty - Mpd_ShpQty as 'OSQty',
            .Columns(intCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(intCol).Width = 60
            .Columns(intCol).ReadOnly = True

            '-- ################################################### --
            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Cum Ship Qty"
            .Columns(intCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(intCol).Width = 100
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Cum OS Qty"
            .Columns(intCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(intCol).Width = 100
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Previous Ship Qty"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
            .Columns(intCol).ReadOnly = True
            '-- ################################################### --


            intCol = intCol + 1
            colShpQty = intCol
            .Columns(intCol).HeaderText = "Ship Qty"   '0 as Mpd_ShpQty,
            .Columns(intCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(intCol).Width = 60
            '.Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ori Ship Qty"
            .Columns(intCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Currency"   'Mpd_UntPrc,
            .Columns(intCol).Width = 70
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Unit Price"   'Mpd_UntPrc,
            .Columns(intCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(intCol).Width = 70
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ori Price"   'Mpd_MinPrc,
            .Columns(intCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Item Name"   'Mpd_ItmNam,
            .Columns(intCol).Width = 200
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Item Desc"   'Mpd_ItmDsc,
            .Columns(intCol).Width = 120
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "MPO #"   'Mpd_MPONO,
            .Columns(intCol).Width = 100
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "MPO Seq"   'Mpd_MPOseq,
            .Columns(intCol).Width = 80
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Recv Dept"   'Mpd_Dept,
            .Columns(intCol).Width = 100
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "PO Date"   'Mpd_PODat,
            .Columns(intCol).Width = 100
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ship Date"   'Mpd_ShpDat,
            .Columns(intCol).Width = 100
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ori Ship Date"   'Mpd_OrgShpDat,
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Req #"   'Mpd_ReqNo,
            .Columns(intCol).Width = 100
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Prod #"   'Mpd_PrdNo,
            .Columns(intCol).Width = 100
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Packing Method"   'Mpd_PckMth,
            .Columns(intCol).Width = 160
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "(WT) Header Remark"   'Mpd_HdrRmk,
            .Columns(intCol).Width = 120
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "(WT) Detail Remark"   'Mpd_Rmk,
            .Columns(intCol).Width = 120
            .Columns(intCol).ReadOnly = True


            intCol = intCol + 1
            .Columns(intCol).HeaderText = ""   'Grl_GrnNo,
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = ""   'Grl_GrnSeq,
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            colDtlRmk = intCol
            .Columns(intCol).HeaderText = "Detail Remark"   'Mpd_Rmk,
            .Columns(intCol).Width = 120
            '.Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = ""   'Grl_CreUsr,
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = ""   'Grl_CreDat,
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = ""   'Grl_UpdUsr,
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = ""   'Grl_UpdDat,
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = ""   'convert(int,Mpd_TimStp)
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = ""   'Del
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = ""   'Del
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = ""   'Del
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
            .Columns(intCol).ReadOnly = True

        End With
    End Sub

    Private Function CumulativeQty_init() As Boolean


        On Error GoTo err_Handle_CUMULATIVE
        If Not rs_CUMULATIVE Is Nothing Then rs_CUMULATIVE = Nothing
        '   If Not rs_CUMULATIVE.Tables("result") Is Nothing Then rs_CUMULATIVE.Tables("result") = Nothing

        rs_CUMULATIVE = Nothing
        rs_CUMULATIVE = New DataSet
        rs_CUMULATIVE.Tables.Add("RESULT")

        With rs_CUMULATIVE
            .Tables("RESULT").Columns.Add("_PO")
            .Tables("RESULT").Columns.Add("_Seq")
            .Tables("RESULT").Columns.Add("_ItmNo")
            .Tables("RESULT").Columns.Add("_ShpQty")
            .Tables("RESULT").Columns.Add("_OSQty")

        End With

        If Not rs_CUMULATIVE.Tables("result") Is Nothing Then
            If Not rs_GRNTRFLST.Tables("result") Is Nothing Then
                With rs_GRNTRFLST
                    If .Tables("result").Rows.Count > 0 Then

                        For index As Integer = 0 To .Tables("RESULT").Rows.Count - 1
                            rs_CUMULATIVE.Tables("result").DefaultView.RowFilter = "_PO = '" & .Tables("RESULT").Rows(index)("Grl_PONo") & "' and _Seq = " & .Tables("RESULT").Rows(index)("Grl_POSeq") & " and _ItmNo = '" & .Tables("RESULT").Rows(index)("Mpd_ItmNo") & "'"
                            If rs_CUMULATIVE.Tables("result").DefaultView.Count > 0 Then
                                rs_CUMULATIVE.Tables("RESULT").DefaultView(0)("_ShpQty") = IIf(IsDBNull(rs_CUMULATIVE.Tables("RESULT").DefaultView(0)("_ShpQty")), 0, rs_CUMULATIVE.Tables("RESULT").DefaultView(0)("_ShpQty")) + .Tables("RESULT").Rows(index)("ShpQty")
                            Else
                                rs_CUMULATIVE.Tables("RESULT").Rows.Add()
                                rs_CUMULATIVE.Tables("RESULT").Rows(rs_CUMULATIVE.Tables("RESULT").Rows.Count - 1)("_PO") = .Tables("RESULT").Rows(index)("Grl_PONo")
                                rs_CUMULATIVE.Tables("RESULT").Rows(rs_CUMULATIVE.Tables("RESULT").Rows.Count - 1)("_Seq") = .Tables("RESULT").Rows(index)("Grl_POSeq")
                                rs_CUMULATIVE.Tables("RESULT").Rows(rs_CUMULATIVE.Tables("RESULT").Rows.Count - 1)("_ItmNo") = .Tables("RESULT").Rows(index)("Mpd_ItmNo")       '2006-04-24
                                rs_CUMULATIVE.Tables("RESULT").Rows(rs_CUMULATIVE.Tables("RESULT").Rows.Count - 1)("_ShpQty") = .Tables("RESULT").Rows(index)("ShpQty")
                                rs_CUMULATIVE.Tables("RESULT").Rows(rs_CUMULATIVE.Tables("RESULT").Rows.Count - 1)("_OSQty") = .Tables("RESULT").Rows(index)("OSQty")
                            End If

                            rs_CUMULATIVE.Tables("result").DefaultView.RowFilter = ""
                        Next

                    End If
                End With
            End If
        End If
        CumulativeQty_init = True

        Exit Function
err_Handle_CUMULATIVE:
        CumulativeQty_init = False
        MsgBox(Err.Number & " : " & Err.Description)
        Err.Clear()
    End Function

    Private Function CumulativeQty_show(ByVal po As String, ByVal seq As Integer, ByVal itemno As String, ByVal strType As String) As Double
        Dim result_Qty As Double

        On Error GoTo err_Handle_show

        result_Qty = 0
        If Not rs_CUMULATIVE.Tables("result") Is Nothing Then
            With rs_CUMULATIVE
                .Tables("result").DefaultView.RowFilter = "_PO = '" & po & "' and _Seq = " & seq & " and _ItmNo = '" & itemno & "'"
                If .Tables("result").Rows.Count > 0 Then
                    If strType = "OS" Then
                        result_Qty = IIf(IsDBNull(rs_CUMULATIVE.Tables("RESULT").DefaultView(0)("_OSQty")), 0, rs_CUMULATIVE.Tables("RESULT").DefaultView(0)("_OSQty"))
                    Else
                        result_Qty = IIf(IsDBNull(rs_CUMULATIVE.Tables("RESULT").DefaultView(0)("_ShpQty")), 0, rs_CUMULATIVE.Tables("RESULT").DefaultView(0)("_ShpQty"))
                    End If
                End If
                .Tables("result").DefaultView.RowFilter = ""
            End With
        End If
        CumulativeQty_show = round(result_Qty, 2)
        Exit Function
err_Handle_show:
        CumulativeQty_show = 0
        MsgBox(Err.Number & " : " & Err.Description)
        Err.Clear()
    End Function

    Private Sub CumulativeQty_update(ByVal po As String, ByVal seq As Integer, ByVal itemno As String, ByVal qty As Double, ByVal OSQty As Double)

        On Error GoTo err_Handle_update
        If Not rs_CUMULATIVE.Tables("result") Is Nothing Then
            With rs_CUMULATIVE
                .Tables("result").DefaultView.RowFilter = "_PO = '" & po & "' and _Seq = " & seq & " and _ItmNo = '" & itemno & "'"
                If .Tables("result").DefaultView.Count > 0 Then
                    .Tables("result").DefaultView(0)("_ShpQty") = IIf(IsDBNull(.Tables("result").DefaultView(0)("_ShpQty")), 0, .Tables("result").DefaultView(0)("_ShpQty")) + qty
                    .Tables("result").DefaultView(0)("_OSQty") = .Tables("result").DefaultView(0)("_OSQty") - qty
                Else
                    .Tables("RESULT").Rows.Add()
                    .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_PO") = po
                    .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_Seq") = seq
                    .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_ItmNo") = itemno
                    .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_ShpQty") = qty
                    .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("_OSQty") = OSQty
                End If

                .Tables("result").DefaultView.RowFilter = ""
            End With
        End If
        Exit Sub
err_Handle_update:
        MsgBox(Err.Number & " : " & Err.Description)
        Err.Clear()
    End Sub

    Private Sub CumulativeQty_clear()
        If Not rs_CUMULATIVE.Tables("result") Is Nothing Then rs_CUMULATIVE = Nothing
    End Sub

    Private Sub displayGrdDtlLst_add()
        Dim i As Integer
        If Not rs_MPORDDTL_dtl.Tables("result") Is Nothing Then
            If rs_MPORDDTL_dtl.Tables("result").Rows.Count > 0 Then
                If Not rs_GRNTRFLST.Tables("result") Is Nothing Then

                    'rs_MPORDDTL_dtl.MoveFirst()

                    For i = 0 To rs_MPORDDTL_dtl.Tables("result").Rows.Count - 1
                        With rs_GRNTRFLST
                            .Tables("RESULT").Rows.Add()
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("CreUsr") = "~*ADD*~"
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grl_PONo") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_PONo")
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grl_POSeq") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_POSeq")
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("OrdQty") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_Qty")
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("OSQty") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("OSQty")
                            '----------------------------
                            '2005-10-17
                            '----------------------------
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("DlvQty") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_DQty")
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Mpd_ItmNo") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_ItmNo")

                            '<CULMULATIVE QTY>
                            '                            Call CumulativeQty_update(rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_PONo"), rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_POSeq"), "", 0, rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("OSQty"))
                            '                           .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Cul_ShpQty") = CumulativeQty_show(.Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grl_PONo"), .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grl_POSeq"), "", "SHP")
                            '                           .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Cul_OSQty") = CumulativeQty_show(.Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grl_PONo"), .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grl_POSeq"), "", "OS")

                            Call CumulativeQty_update(rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_PONo"), rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_POSeq"), .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Mpd_ItmNo"), 0, rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("OSQty"))
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Cul_ShpQty") = CumulativeQty_show(.Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grl_PONo"), .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grl_POSeq"), .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Mpd_ItmNo"), "SHP")
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Cul_OSQty") = CumulativeQty_show(.Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grl_PONo"), .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grl_POSeq"), .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Mpd_ItmNo"), "OS")

                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Prv_ShpQty") = 0
                            '----------------------------
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("ShpQty") = 0
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("OriShpQty") = 0
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grl_Curr") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mph_Curr")
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grl_UntPrc") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_UntPrc")
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grl_OrgPrc") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_MinPrc")
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Mpd_ItmNam") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_ItmNam")
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Mpd_ItmDsc") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_ItmDsc")

                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("MPONo") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("MPONo")
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("MPOSeq") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("MPOSeq")
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Dept") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Dept")

                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Mpd_PODat") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_PODat")
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Mpd_ShpDat") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_ShpDat")
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Mpd_OrgShpDat") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_OrgShpDat")
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Mpd_ReqNo") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_ReqNo")
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Mpd_PrdNo") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_PrdNo")
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Mpd_PckMth") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_PckMth")
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Mpd_HdrRmk") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_HdrRmk")
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Mpd_Rmk") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("Mpd_Rmk")
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grl_GrnNo") = Me.txtGRNNo.Text
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grl_GrnSeq") = seq
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grl_CreUsr") = gsUsrID
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grl_CreDat") = Now()
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grl_UpdUsr") = gsUsrID
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grl_UpdDat") = Now()
                            '2005-10-14
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grl_DtlRmk") = ""
                            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("TimStp") = rs_MPORDDTL_dtl.Tables("RESULT").Rows(i)("TimStp")


                        End With
                        '   rs_MPORDDTL_dtl.MoveNext()
                    Next

                End If
            End If
        End If


        '    Dim intCol As Integer
        '    With grdDtlLst
        '        intCol = 0
        '       .Columns(intCol).Caption = "PO #"   'Mpd_PONo,
        '        .Columns(intCol).width = 800
        '
        '        intCol = intCol + 1
        '        .Columns(intCol).Caption = "Seq"   '        Mpd_POSeq,
        '        .Columns(intCol).width = 800
        '
        '        intCol = intCol + 1
        '        .Columns(intCol).Caption = "Ord Qty"   'Mpd_Qty,
        '        .Columns(intCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '        .Columns(intCol).width = 800
        '
        '        intCol = intCol + 1
        '        .Columns(intCol).Caption = "OS Qty"   'Mpd_Qty - Mpd_ShpQty as 'OSQty',
        '        .Columns(intCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '        .Columns(intCol).width = 800
        '
        '        intCol = intCol + 1
        '        .Columns(intCol).Caption = "Ship Qty"   '0 as Mpd_ShpQty,
        '        .Columns(intCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '        .Columns(intCol).width = 800
        '
        '        intCol = intCol + 1
        '        .Columns(intCol).Caption = "Original Price"   'Mpd_UntPrc,
        '        .Columns(intCol).width = 800
        '
        '        intCol = intCol + 1
        '        .Columns(intCol).Caption = "Unit Price"   'Mpd_MinPrc,
        '        .Columns(intCol).width = 800
        '
        '        intCol = intCol + 1
        '        .Columns(intCol).Caption = "Item Name"   'Mpd_ItmNam,
        '        .Columns(intCol).width = 800
        '
        '        intCol = intCol + 1
        '        .Columns(intCol).Caption = "Item Desc"   'Mpd_ItmDsc,
        '        .Columns(intCol).width = 800
        '
        '        intCol = intCol + 1
        '        .Columns(intCol).Caption = "MPO #"   'Mpd_MPONO,
        '        .Columns(intCol).width = 800
        '
        '        intCol = intCol + 1
        '        .Columns(intCol).Caption = "MPO Seq"   'Mpd_MPOseq,
        '        .Columns(intCol).width = 800
        '
        '        intCol = intCol + 1
        '        .Columns(intCol).Caption = "Recv Dept"   'Mpd_Dept,
        '        .Columns(intCol).width = 800
        '
        '        intCol = intCol + 1
        '        .Columns(intCol).Caption = "PO Date"   'Mpd_PODat,
        '        .Columns(intCol).width = 800
        '
        '        intCol = intCol + 1
        '        .Columns(intCol).Caption = "Ship Date"   'Mpd_ShpDat,
        '        .Columns(intCol).width = 800
        '
        '        intCol = intCol + 1
        '        .Columns(intCol).Caption = "Original Ship Date"   'Mpd_OrgShpDat,
        '        .Columns(intCol).width = 800
        '
        '        intCol = intCol + 1
        '        .Columns(intCol).Caption = "Req #"   'Mpd_ReqNo,
        '        .Columns(intCol).width = 800
        '
        '        intCol = intCol + 1
        '        .Columns(intCol).Caption = "Prod #"   'Mpd_PrdNo,
        '        .Columns(intCol).width = 800
        '
        '        intCol = intCol + 1
        '        .Columns(intCol).Caption = "Packing Method"   'Mpd_PckMth,
        '        .Columns(intCol).width = 800
        '
        '        intCol = intCol + 1
        '        .Columns(intCol).Caption = "Header Remark"   'Mpd_HdrRmk,
        '        .Columns(intCol).width = 800
        '
        '        intCol = intCol + 1
        '        .Columns(intCol).Caption = "Detail Remark"   'Mpd_Rmk,
        '        .Columns(intCol).width = 800
        '
        '        intCol = intCol + 1
        '        .Columns(intCol).Caption = ""   'convert(int,Mpd_TimStp)
        '        .Columns(intCol).width = 0
        '
        '    End With
    End Sub

    Private Sub cboGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGroup.SelectedIndexChanged

        Dim strgrp As String

        strgrp = Trim(Me.cboGroup.Text)

        If Trim(strgrp) = "" Then Exit Sub
        If rs_Group.Tables("result") Is Nothing Then Exit Sub
        With rs_Group

            If .Tables("result").Rows.Count > 0 Then
                .Tables("result").DefaultView.RowFilter = "_grp = '" & UCase(Trim(strgrp)) & "'"

                If .Tables("result").Rows.Count > 0 Then
                    Me.cboCat.Text = .Tables("result").DefaultView(0)("_CustCat")
                    Me.txtCTNFm.Text = .Tables("result").DefaultView(0)("_CtnFm")
                    Me.txtCTNTo.Text = .Tables("result").DefaultView(0)("_CtnTo")
                    Me.txtTtlCTN_D.Text = .Tables("result").DefaultView(0)("_TtlCTN")
                    Me.txtTtlCTN_D.Refresh()
                    cboTtlCTN_D_UM.Text = .Tables("result").DefaultView(0)("_CtnUM")
                    Me.cboTtlCTN_D_UM.Refresh()
                    Me.txtGW.Text = .Tables("result").DefaultView(0)("_GW")
                    Me.txtNW.Text = .Tables("result").DefaultView(0)("_NW")
                    Me.txtTtlGW_D.Text = .Tables("result").DefaultView(0)("_TtlGW")
                    Me.txtTtlNW_D.Text = .Tables("result").DefaultView(0)("_TtlNW")
                    Me.CboCustUM.Text = .Tables("result").DefaultView(0)("_CustUM")
                    Me.txtCustQty.Text = .Tables("result").DefaultView(0)("_CustQty")
                    Me.txtUntPrc.Text = .Tables("result").DefaultView(0)("_untprc")
                    Call txtCustQty_KeyPress(13)
                    .Tables("result").DefaultView.RowFilter = ""
                    Exit Sub
                End If
            End If
        End With

        Exit Sub
err_handle_show_group:
        Err.Clear()
        Exit Sub


    End Sub




    '    Private Sub cboGroup_Click()
    '        Dim strgrp As String

    '        strgrp = Trim(Me.cboGroup.Text)

    '        If Trim(strgrp) = "" Then Exit Sub
    '        If rs_Group.Tables("result") Is Nothing Then Exit Sub
    '        With rs_Group
    '            If .Tables("result").Rows.Count > 0 Then
    '                .Tables("result").DefaultView.RowFilter = "_grp = '" & UCase(Trim(strgrp)) & "'"
    '                If .Tables("result").Rows.Count > 0 Then
    '                    Me.cboCat.Text = .Fields("_CustCat")
    '                    Me.txtCTNFm.Text = .Fields("_CtnFm")
    '                    Me.txtCTNTo.Text = .Fields("_CtnTo")
    '                    Me.txtTtlCTN_D.Text = .Fields("_TtlCTN")
    '                    Me.txtTtlCTN_D.Refresh()
    '                    cboTtlCTN_D_UM.Text = .Fields("_CtnUM")
    '                    Me.cboTtlCTN_D_UM.Refresh()
    '                    Me.txtGW.Text = .Fields("_GW")
    '                    Me.txtNW.Text = .Fields("_NW")
    '                    Me.txtTtlGW_D.Text = .Fields("_TtlGW")
    '                    Me.txtTtlNW_D.Text = .Fields("_TtlNW")
    '                    Me.CboCustUM.Text = .Fields("_CustUM")
    '                    Me.txtCustQty.Text = .Fields("_CustQty")
    '                    Me.txtUntPrc.Text = .Fields("_untprc")
    '                    Call txtCustQty_KeyPress(13)
    '                    .Tables("result").DefaultView.RowFilter = ""
    '                    Exit Sub
    '                End If
    '            End If
    '        End With

    '        Exit Sub
    'err_handle_show_group:
    '        Err.Clear()
    '        Exit Sub
    '    End Sub

    Private Sub cboGroup_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboGroup.KeyPress
        If e.KeyChar <> Chr(8) And Len(Me.cboGroup.Text) > 40 Then
            e.KeyChar = Chr(0)
        End If
        'If e.KeyChar = Chr(13) Then
        '    Call cboGroup_Click()
        'End If

    End Sub
    'Private Sub cboGroup_KeyPress(ByVal Asc(e.KeyChar) As Integer)
    '    If e.KeyChar <> 8 And Len(Me.cboGroup.Text) > 40 Then
    '        e.KeyChar = Chr(0)
    '    End If
    '    If Asc(e.KeyChar) = 13 Then
    '        Call cboGroup_Click()
    '    End If
    'End Sub

    Private Sub cboGroup_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboGroup.KeyUp
        Call auto_search_combo(Me.cboGroup, e.KeyCode)
    End Sub
    'Private Sub cboGroup_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
    '    Call auto_search_combo(Me.cboGroup, e.KeyCode)
    'End Sub

    Private Sub cboGroup_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGroup.LostFocus
        Me.cboGroup.Text = UCase(Me.cboGroup.Text)
    End Sub

    Private Sub cboImpFty_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboImpFty.Click
        flag_cboImpFty_Click = True

    End Sub
    'Private Sub cboGroup_LostFocus()
    '    Me.cboGroup.Text = UCase(Me.cboGroup.Text)
    'End Sub


    Private Sub cboImpFty_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboImpFty.SelectedIndexChanged
        If flag_cboImpFty_Click = True Then
            flag_cboImpFty_Click = False
            If Trim(Me.cboImpFty.Text) <> "" Then
                Call AddRecord()
            End If

        End If

    End Sub
    'Private Sub cboImpFty_Click()
    '    '    If Trim(Me.cboImpFty.Text) <> "" And Trim(Me.cboDest.Text) <> "" Then
    '    '        Call AddRecord
    '    '    End If
    '    If Trim(Me.cboImpFty.Text) <> "" Then
    '        Call AddRecord()
    '    End If
    'End Sub

    Private Sub cboImpFty_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboImpFty.KeyPress
        'If Asc(e.KeyChar) = 13 Then
        '    Call cboImpFty_Click()
        'End If
        If e.KeyChar <> Chr(9) And e.KeyChar <> Chr(8) And Len(Me.cboImpFty.Text) > 20 Then
            e.KeyChar = Chr(0)
        End If
    End Sub
    'Private Sub cboImpFty_KeyPress(ByVal Asc(e.KeyChar) As Integer)
    '    If Asc(e.KeyChar) = 13 Then
    '        Call cboImpFty_Click()
    '    End If
    '    If e.KeyChar <> 9 And e.KeyChar <> 8 And Len(Me.cboImpFty.Text) > 20 Then
    '        e.KeyChar = Chr(0)
    '    End If
    'End Sub

    Private Sub cboImpFty_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboImpFty.KeyUp
        Call auto_search_combo(Me.cboImpFty, e.KeyCode)
    End Sub
    'Private Sub cboImpFty_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
    '    Call auto_search_combo(Me.cboImpFty, e.KeyCode)
    'End Sub
    Public Sub cboMPONo_Click()
        If Me.cboMPONo.Text = "" Then Exit Sub

        Cursor = Cursors.WaitCursor

        If Not rs_MPONo.Tables("result") Is Nothing Then
            If rs_MPONo.Tables("result").Rows.Count > 0 Then
                rs_MPONo.Tables("result").DefaultView.RowFilter = "Mph_MPONo= '" & Trim(Me.cboMPONo.Text) & "'"
                If rs_MPONo.Tables("result").DefaultView.Count > 0 Then
                    strCurr = UCase(rs_MPONo.Tables("result").DefaultView(0)("Mph_Curr"))
                End If
                rs_MPONo.Tables("result").DefaultView.RowFilter = ""
            End If
        End If


        gspStr = "sp_select_MPM00002  '','" & Trim(Me.cboMPONo.Text) & "','','','','LST'"
        Cursor = Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_MPORDDTL_lst, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_MPM00002  :" & rtnStr)
            Exit Sub
        Else

            Me.cboDtl.Items.Clear()
            For index As Integer = 0 To rs_MPORDDTL_lst.Tables("RESULT").Rows.Count - 1
                cboDtl.Items.Add(rs_MPORDDTL_lst.Tables("RESULT").Rows(index)("Mpd_ItmNo") & "; " & rs_MPORDDTL_lst.Tables("RESULT").Rows(index)("Mpd_ItmNam") & "; " & rs_MPORDDTL_lst.Tables("RESULT").Rows(index)("Mpd_ColCde") & "; " & rs_MPORDDTL_lst.Tables("RESULT").Rows(index)("Mpd_UM"))
            Next
        End If

        Cursor = Cursors.Default

        If Trim(Me.cboMPONo.Text) = "" Then
            Me.cboDtl.Items.Clear()
        End If
        'temp

    End Sub
    Private Sub cboMPONo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMPONo.SelectedIndexChanged

        Call cboMPONo_Click()

    End Sub

    'Private Sub cboMPONo_Change()
    '    If Trim(Me.cboMPONo.Text) = "" Then
    '        Me.cboDtl.Items.Clear()
    '    End If
    'End Sub

    'Private Sub cboMPONo_Click()
    '    If Me.cboMPONo.Text = "" Then Exit Sub

    '    Cursor = Cursors.WaitCursor

    '    If Not rs_MPONo.Tables("result") Is Nothing Then
    '        If rs_MPONo.Tables("result").Rows.Count > 0 Then
    '            rs_MPONo.Tables("result").DefaultView.RowFilter = "Mph_MPONo= '" & Trim(Me.cboMPONo.Text) & "'"
    '            If rs_MPONo.Tables("result").Rows.Count > 0 Then
    '                strCurr = UCase(rs_MPONo.Fields("Mph_Curr"))
    '            End If
    '            rs_MPONo.Tables("result").DefaultView.RowFilter = ""
    '        End If
    '    End If




    '    gspStr = "sp_select_MPM00002  ','" & Trim(Me.cboMPONo.Text) & "','','','','LST"
    '    Cursor = Cursors.WaitCursor
    '    rtnLong = execute_SQLStatement(gspStr, rs_MPORDDTL_lst, rtnStr)
    '    If rtnLong <> RC_SUCCESS Then
    '        MsgBox("Error on loading  sp_select_MMPORDHDR :" & rtnStr)
    '        Exit Sub
    '    End If
    '    For i2 As Integer = 0 To rs_MPORDDTL_dtl.Tables("RESULT").Columns.Count - 1
    '        rs_MPORDDTL_dtl.Tables("RESULT").Columns(i2).ReadOnly = False
    '    Next


    '    rs = objBSGate.Enquire(gsConnStr, "sp_general", S)
    '    If rs(0)(0) <> "0" Then  '*** An error has occured
    '        MsgBox(rs(0)(0))
    '    Else
    '        rs_MPORDDTL_lst = rs(1)
    '        Me.cboDtl.Items.Clear()
    '        With rs_MPORDDTL_lst
    '            If .Tables("result").Rows.Count > 0 Then
    '                .MoveFirst()
    '                While Not .EOF
    '                Me.cboDtl.Items.add .Fields("Mpd_ItmNo") & "; " & .Fields("Mpd_ItmNam") & "; " & .Fields("Mpd_ColCde") & "; " & .Fields("Mpd_UM")
    '                    .MoveNext()
    '                End While
    '            End If
    '        End With
    '    End If
    '    Cursor = Cursors.Default

    'End Sub





    Private Sub cboMPONo_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMPONo.KeyPress
        'If Asc(e.KeyChar) = 13 Then
        '    Call cboMPONo_Click()
        'End If
    End Sub

    'Private Sub cboMPONo_KeyPress(ByVal Asc(e.KeyChar) As Integer)
    '    If Asc(e.KeyChar) = 13 Then
    '        Call cboMPONo_Click()
    '    End If
    'End Sub

    Private Sub cboMPONo_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMPONo.KeyUp
        Call auto_search_combo(cboMPONo, e.KeyCode)
    End Sub
    'Private Sub cboMPONo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
    '    Call auto_search_combo(cboMPONo, e.KeyCode)
    'End Sub

    Private Sub cboMPONo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMPONo.LostFocus
        If ValidateCombo(Me.cboMPONo) = False Then
            'MsgBox "Please select from dropdown menu!"
            Exit Sub
        End If
    End Sub
    'Private Sub cboMPONo_LostFocus()
    '    If ValidateCombo(Me.cboMPONo) = False Then
    '        'MsgBox "Please select from dropdown menu!"
    '        Exit Sub
    '    End If
    'End Sub

    Private Sub chkDelete_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDelete.Click
        Dim i As Integer
        If bolDisplay = True Then Exit Sub
        If rs_GRNTRFDTL.Tables("result") Is Nothing Then Exit Sub
        If rs_GRNTRFDTL.Tables("result").Rows.Count <= 0 Then Exit Sub
        Me.chkDelete.Enabled = False

        On Error GoTo err_Handle_Check_Delete
        If chkDelete.Checked = True Then
            Call setStatus("Delete_Dtl")
            Call enableOptType(False)
            Me.cboMPONo.Enabled = False
            Me.cboDtl.Enabled = False
            With rs_GRNTRFDTL
                If .Tables("result").Rows(readingindex)("CreUsr") = "~*ADD*~" Then
                    .Tables("result").Rows(readingindex)("CreUsr") = "~*NEW*~"

                End If
                .Tables("result").Rows(readingindex)("Del") = "Y"

            End With
            If optType0.Checked = True Then
                If Me.cboMPONo.Text <> "" And Me.cboDtl.Text <> "" Then
                    If Not rs_GRNTRFLST.Tables("result") Is Nothing Then
                        With rs_GRNTRFLST
                            If .Tables("result").Rows.Count > 0 Then
                                For i = 0 To .Tables("result").Rows.Count - 1
                                    If .Tables("result").Rows(i)("CreUsr") = "~*ADD*~" Then
                                        .Tables("result").Rows(i)("CreUsr") = "~*NEW*~"
                                    End If
                                    .Tables("result").Rows(i)("Del") = "Y"
                                Next
                            End If
                        End With
                    End If
                End If
            End If
        Else
            Call setStatus("Update_Dtl")
            If Me.optType0.Checked = True Then
                If Trim(Me.cboMPONo.Text) = "" Or Trim(Me.cboDtl.Text) = "" Then
                    Call enableOptType(True)
                    Me.cboMPONo.Enabled = True
                    Me.cboDtl.Enabled = True
                End If
            End If

            With rs_GRNTRFDTL
                If .Tables("result").Rows(readingindex)("CreUsr") = "~*NEW*~" Then
                    .Tables("result").Rows(readingindex)("CreUsr") = "~*ADD*~"
                End If
                .Tables("result").Rows(readingindex)("Del") = "N"

            End With
            If optType0.Checked = True Then
                If Me.cboMPONo.Text <> "" And Me.cboDtl.Text <> "" Then
                    If Not rs_GRNTRFLST.Tables("result") Is Nothing Then
                        With rs_GRNTRFLST
                            If .Tables("result").Rows.Count > 0 Then
                                For i = 0 To .Tables("result").Rows.Count - 1
                                    If .Tables("result").Rows(readingindex)("CreUsr") = "~*NEW*~" Then
                                        .Tables("result").Rows(readingindex)("CreUsr") = "~*ADD*~"
                                    End If
                                    .Tables("result").Rows(readingindex)("Del") = "N"

                                Next
                            End If
                        End With
                    End If
                End If
            End If
        End If
        Call freelock()
        'Me.chkDelete.Enabled = True
        '2006-04-22
        Me.chkDelete.Enabled = Del_right_local
        Exit Sub
err_Handle_Check_Delete:
        MsgBox(Err.Number & " - " & Err.Description, , "Check Delete")
        'Me.chkDelete.Enabled = True
        '2006-04-22
        Me.chkDelete.Enabled = Del_right_local

    End Sub

    Private Sub chkDelete_Click()
        '        Dim i As Integer
        '        If bolDisplay = True Then Exit Sub
        '        If rs_GRNTRFDTL.Tables("result") Is Nothing Then Exit Sub
        '        If rs_GRNTRFDTL.Tables("result").Rows.Count <= 0 Then Exit Sub
        '        Me.chkDelete.Enabled = False

        '        On Error GoTo err_Handle_Check_Delete
        '        If chkDelete.Checked = True Then
        '            Call setStatus("Delete_Dtl")
        '            Call enableOptType(False)
        '            Me.cboMPONo.Enabled = False
        '            Me.cboDtl.Enabled = False
        '            With rs_GRNTRFDTL
        '                If .Fields("CreUsr") = "~*ADD*~" Then
        '                    .Fields("CreUsr") = "~*NEW*~"

        '                End If
        '                .Fields("Del") = "Y"

        '            End With
        '            If optType0.Checked = True Then
        '                If Me.cboMPONo.Text <> "" And Me.cboDtl.Text <> "" Then
        '                    If Not rs_GRNTRFLST.Tables("result") Is Nothing Then
        '                        With rs_GRNTRFLST
        '                            If .Tables("result").Rows.Count > 0 Then
        '                                .MoveFirst()
        '                                For i = 0 To .Tables("result").Rows.Count - 1
        '                                    If .Fields("CreUsr") = "~*ADD*~" Then
        '                                        .Fields("CreUsr") = "~*NEW*~"
        '                                    End If
        '                                    .Fields("Del") = "Y"

        '                                    .MoveNext()
        '                                Next
        '                                .MoveFirst()
        '                            End If
        '                        End With
        '                    End If
        '                End If
        '            End If
        '        Else
        '            Call setStatus("Update_Dtl")
        '            If Me.optType0.Checked = True Then
        '                If Trim(Me.cboMPONo.Text) = "" Or Trim(Me.cboDtl.Text) = "" Then
        '                    Call enableOptType(True)
        '                    Me.cboMPONo.Enabled = True
        '                    Me.cboDtl.Enabled = True
        '                End If
        '            End If

        '            With rs_GRNTRFDTL
        '                If .Fields("CreUsr") = "~*NEW*~" Then
        '                    .Fields("CreUsr") = "~*ADD*~"
        '                End If
        '                .Fields("Del") = "N"

        '            End With
        '            If optType0.Checked = True Then
        '                If Me.cboMPONo.Text <> "" And Me.cboDtl.Text <> "" Then
        '                    If Not rs_GRNTRFLST.Tables("result") Is Nothing Then
        '                        With rs_GRNTRFLST
        '                            If .Tables("result").Rows.Count > 0 Then
        '                                .MoveFirst()
        '                                For i = 0 To .Tables("result").Rows.Count - 1
        '                                    If .Fields("CreUsr") = "~*NEW*~" Then
        '                                        .Fields("CreUsr") = "~*ADD*~"
        '                                    End If
        '                                    .Fields("Del") = "N"

        '                                    .MoveNext()
        '                                Next
        '                                .MoveFirst()
        '                            End If
        '                        End With
        '                    End If
        '                End If
        '            End If
        '        End If
        '        Call freelock()
        '        'Me.chkDelete.Enabled = True
        '        '2006-04-22
        '        Me.chkDelete.Enabled = Del_right_local
        '        Exit Sub
        'err_Handle_Check_Delete:
        '        MsgBox(Err.Number & " - " & Err.Description, , "Check Delete")
        '        'Me.chkDelete.Enabled = True
        '        '2006-04-22
        '        Me.chkDelete.Enabled = Del_right_local
    End Sub
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAdd.Click
        If gsUsrGrp = "CST-G1" Then
            optType1.Checked = True
            optType0.Checked = False
            optType2.Checked = False

            'optType0.Enabled = False
            'optType1.Enabled = False
            'optType2.Enabled = False
            '20151209
            '20151110
        End If

        Me.mmdAdd.Enabled = False
        mmdAdd.Enabled = False
        mmdFind.Enabled = False
        mmdClear.Enabled = True
        Me.txtGRNNo.Text = ""
        Me.txtGRNNo.Enabled = False
        Me.cboImpFty.Enabled = True
        Me.cboDest.Enabled = True
        '2005-10-17, initial recordset for cumulative i) Ship Qty and ii) OS Qty
        Call CumulativeQty_init()
        Call setFocus_Combo(Me.cboImpFty)
        Me.StatusBar.Panels(1).Text = UCase(gsUsrID) & " " & Format(Now(), "MM/dd/yyyy") & " " & Format(Now(), "MM/dd/yyyy")

    End Sub

    '
    '
    Private Sub cmdAdd_Click()
    End Sub

    Private Sub AddRecord()

        If Trim(Me.cboImpFty.Text) = "" Then
            MsgBox("Please select/input Custom Factory!")
            Call setFocus_Combo(Me.cboImpFty)
            Exit Sub
        End If

        '    If Trim(Me.cboDest.Text) = "" Then
        '        MsgBox "Please select/input Destination!"
        '        Call setFocus_Combo(Me.cboDest)
        '        Exit Sub
        '    End If

        'Show Invoice Header

        Me.cboDest.Text = Me.cboImpFty.Text
        'Call cboDest_Click()
        'tempzzzzzzzzz

        If Not rs_IMPFTY.Tables("result") Is Nothing Then
            With rs_IMPFTY
                If .Tables("result").Rows.Count > 0 Then
                    .Tables("result").DefaultView.RowFilter = "_CustFty='" & Trim(Me.cboImpFty.Text) & "'"
                    If .Tables("result").DefaultView.Count > 0 Then
                        Me.txtInvHdr.Text = .Tables("result").DefaultView(0)("_Bill_Eng")
                        Me.txtImpFtyAddr.Text = .Tables("result").DefaultView(0)("_Bill_Addr")
                    End If
                    .Tables("result").DefaultView.RowFilter = ""
                End If
            End With
        End If

        'Show a list of MPO available for shipment
        Cursor = Cursors.WaitCursor
        strMode = "ACT"
        Me.txtMode.Text = strMode
        Me.txtIssDat.Text = Format(Date.Today, "MM/dd/yyyy").ToString
        Me.txtRvsDat.Text = Format(Date.Today, "MM/dd/yyyy").ToString




        gspStr = "sp_list_MPM00002  '','MPO','" & Trim(cboImpFty.Text) & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_MPONo, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_list_MPM00002  :" & rtnStr)
            Exit Sub
        End If
        For i2 As Integer = 0 To rs_MPONo.Tables("RESULT").Columns.Count - 1
            rs_MPONo.Tables("RESULT").Columns(i2).ReadOnly = False
        Next

        gspStr = "sp_select_GRNTRFHDR  '','XXX'"
        rtnLong = execute_SQLStatement(gspStr, rs_GRNTRFHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_GRNTRFHDR  :" & rtnStr)
            Exit Sub
        End If
        For i2 As Integer = 0 To rs_GRNTRFHDR.Tables("RESULT").Columns.Count - 1
            rs_GRNTRFHDR.Tables("RESULT").Columns(i2).ReadOnly = False
        Next


        gspStr = "sp_select_GRNTRFDTL  '','XXX'"
        rtnLong = execute_SQLStatement(gspStr, rs_GRNTRFDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_GRNTRFDTL  :" & rtnStr)
            Exit Sub
        End If
        For i2 As Integer = 0 To rs_GRNTRFDTL.Tables("RESULT").Columns.Count - 1
            rs_GRNTRFDTL.Tables("RESULT").Columns(i2).ReadOnly = False
        Next


        gspStr = "sp_select_GRNTRFLST '','XXX'"
        rtnLong = execute_SQLStatement(gspStr, rs_GRNTRFLST, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_GRNTRFLST :" & rtnStr)
            Exit Sub
        End If
        For i2 As Integer = 0 To rs_GRNTRFLST.Tables("RESULT").Columns.Count - 1
            rs_GRNTRFLST.Tables("RESULT").Columns(i2).ReadOnly = False
        Next

        Me.cboMPONo.Items.Clear()
        For index As Integer = 0 To rs_MPONo.Tables("RESULT").Rows.Count - 1
            cboMPONo.Items.Add(rs_MPONo.Tables("RESULT").Rows(index)("Mph_MpoNo"))
        Next

        Call DisplaySummary()

        Call initGroup()
        Cursor = Cursors.Default

        'Set initial sequence no
        seq = 0
        setStatus("Add")
        addFlag = True
        txtTrdCty.Text = "香港"

    End Sub
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        Dim YNC As Integer
        If IsUpdated() Then
            YNC = MsgBox("Record updated!" & vbCrLf & "Save before clear?", vbYesNoCancel + vbDefaultButton1 + vbQuestion, "")
            If YNC = vbYes Then
                If Enq_right_local Then
                    save_ok = False
                    Call CmdSaveClick()
                    If save_ok = False Then Exit Sub
                Else
                    MsgBox("You do not have rights to save!" & vbCrLf & "Program will clear without save!", vbInformation + vbOKOnly)
                End If
                '            save_ok = False
                '            Call CmdSaveClick
                '            If save_ok = False Then Exit Sub
            ElseIf YNC = vbCancel Then
                Exit Sub
            End If
        End If

        ''    If btcMPM00002.selectedindex = 1 Then
        ''        If Not rs_GRNTRFDTL.Tables("result") .Tables("result")  Is Nothing Then
        ''            If rs_GRNTRFDTL.tables("result").rows.count > 0 Then
        ''                If checkDetail = False Then Exit Sub
        ''                'check and update deatil
        ''                Call UpdateDetail
        ''
        ''            End If
        ''        End If
        ''    End If
        Call setStatus("Clear")
        addFlag = False


    End Sub

    Private Sub cmdClear_Click()
        'Dim YNC As Integer
        'If IsUpdated() Then
        '    YNC = MsgBox("Record updated!" & vbCrLf & "Save before clear?", vbYesNoCancel + vbDefaultButton1 + vbQuestion, "")
        '    If YNC = vbYes Then
        '        If Enq_right_local Then
        '            save_ok = False
        '            Call CmdSaveClick()
        '            If save_ok = False Then Exit Sub
        '        Else
        '            MsgBox("You do not have rights to save!" & vbCrLf & "Program will clear without save!", vbInformation + vbOKOnly)
        '        End If
        '        '            save_ok = False
        '        '            Call CmdSaveClick
        '        '            If save_ok = False Then Exit Sub
        '    ElseIf YNC = vbCancel Then
        '        Exit Sub
        '    End If
        'End If

        ' ''    If btcMPM00002.selectedindex = 1 Then
        ' ''        If Not rs_GRNTRFDTL.Tables("result") .Tables("result")  Is Nothing Then
        ' ''            If rs_GRNTRFDTL.tables("result").rows.count > 0 Then
        ' ''                If checkDetail = False Then Exit Sub
        ' ''                'check and update deatil
        ' ''                Call UpdateDetail
        ' ''
        ' ''            End If
        ' ''        End If
        ' ''    End If
        'Call setStatus("Clear")
        'addFlag = False

    End Sub

    Private Function IsUpdated() As Boolean
        IsUpdated = False
        If addFlag = True Then
            IsUpdated = True
        ElseIf isHeaderUpdated() Then
            IsUpdated = True
        ElseIf isDetailUpdated() Then
            IsUpdated = True
        End If
    End Function

    Private Sub cmdDelRow_Click()
    End Sub

    Private Sub CmdExit_Click()
        Me.Close()

    End Sub

    '
    '

    Private Sub moveRecord(ByVal strAct As String)

        If btcMPM00002.SelectedIndex <> 1 Then Exit Sub
        If rs_GRNTRFDTL.Tables("result") Is Nothing Then Exit Sub
        If rs_GRNTRFDTL.Tables("result").Rows.Count <= 0 Then Exit Sub

        If strAct <> "X" Then
            If checkDetail() = False Then Exit Sub
            Call UpdateDetail()
        End If

        '    Me.cmdfirstD.Enabled = False
        Me.cmdPrvD.Enabled = False
        Me.cmdNextD.Enabled = False
        '    Me.cmdlastD.Enabled = False

        With rs_GRNTRFDTL
            Select Case strAct
                Case "F"
                    readingindex = 0
                    '                    .MoveFirst()
                Case "P"
                    readingindex = readingindex - 1
                    If readingindex < 0 Then
                        readingindex = 0
                    End If

                    '                    If .BOF = False And .AbsolutePosition > 1 Then .MovePrevious()
                Case "N"
                    readingindex = readingindex + 1
                    If readingindex > .Tables("result").Rows.Count - 1 Then
                        readingindex = .Tables("result").Rows.Count - 1
                    End If

                    '                    If rs_GRNTRFDTL.EOF = False And rs_GRNTRFDTL.AbsolutePosition < rs_GRNTRFDTL.Tables("result").Rows.Count Then rs_GRNTRFDTL.MoveNext()
                Case "L"
                    readingindex = .Tables("result").Rows.Count - 1
                    '                    rs_GRNTRFDTL.MoveLast()
            End Select


        End With

        Call DisplayDetail()
        Call showStatusBar()

        If rs_GRNTRFDTL.Tables("result").Rows.Count > 1 Then

            If readingindex > 0 Then
                Me.cmdPrvD.Enabled = True
            End If
            'If rs_GRNTRFDTL.AbsolutePosition > 1 Then
            '    '                Me.cmdfirstD.Enabled = True
            '    Me.cmdPrvD.Enabled = True
            'End If
            If readingindex < rs_GRNTRFDTL.Tables("result").Rows.Count - 1 Then
                Me.cmdNextD.Enabled = True
            End If


            'If rs_GRNTRFDTL.AbsolutePosition < rs_GRNTRFDTL.Tables("result").Rows.Count Then
            '    Me.cmdNextD.Enabled = True
            '    '                Me.cmdlastD.Enabled = True
            'End If
        End If
    End Sub
    'tempzzzzzzzzz




    '
    Private Sub DisplaySummary()
        Dim col As Integer


        grdSummary.DataSource = Nothing
        If rs_GRNTRFDTL.Tables("result") Is Nothing Then Exit Sub

        grdSummary.DataSource = rs_GRNTRFDTL.Tables("result")

        With grdSummary
            col = 0
            .Columns(col).HeaderText = "Del"  ''N' as 'Del',
            .Columns(col).Width = 40 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "Flag"  'Grd_CreUsr as 'CreUsr',
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 0
            .Columns(col).Visible = False


            col = col + 1
            .Columns(col).HeaderText = "GRN No"  'Grd_GrnNo,
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 0
            .Columns(col).Visible = False

            col = col + 1
            ColSeq = col
            .Columns(col).HeaderText = "Seq"  'Grd_Seq,
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 60 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "Prt Grp."  'Grd_PrtGrp,
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 60

            col = col + 1
            colType = col
            .Columns(col).HeaderText = "Type"  'Grd_Type,
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 70 / 1.3

            col = col + 1
            colGroup = col
            .Columns(col).HeaderText = "Group"  'Grd_Grp,
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 100 / 1.3

            col = col + 1
            colItmNo = col
            .Columns(col).HeaderText = "Item No"  'Grd_ItmNo,
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 140 / 1.3

            col = col + 1
            colItmName = col
            .Columns(col).HeaderText = "Item Name"  'Grd_ItmNam,
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 240 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "Item Desc"  'Grd_ItmDsc,
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 150 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "Curr"  'Grd_Curr,
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 80 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "Unit Price"  'Grd_UntPrc,
            .Columns(col).ReadOnly = True
            .Columns(col).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(col).Width = 100 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "Color"  'Grd_Color,
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 120 / 1.3

            col = col + 1
            colCustCat = col
            .Columns(col).HeaderText = "Cust. Category"  'Grd_CustCat + case IsDBNull(ymc_catdsc,'') when '' then 'Cat Not Found' else ymc_catdsc end as 'Grd_CustCat',
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 200 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "Country"  'Grd_Cty,
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 80 / 1.3

            col = col + 1
            colCTNFm = col
            .Columns(col).HeaderText = "CTN Fm"  'Grd_CTNFm,
            .Columns(col).ReadOnly = True
            .Columns(col).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(col).Width = 80 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "CTN To"  'Grd_CTNTo,
            .Columns(col).ReadOnly = True
            .Columns(col).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(col).Width = 80 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "Ttl CTN"  'Grd_TtlCTN,
            .Columns(col).ReadOnly = True
            .Columns(col).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(col).Width = 80 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "UM (CTN)"  'Grd_CtnUM,
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 100 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "G.W. (Kg)"  'Grd_GW,
            .Columns(col).ReadOnly = True
            .Columns(col).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(col).Width = 100 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "N.W. (Kg)"  'Grd_NW,
            .Columns(col).ReadOnly = True
            .Columns(col).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(col).Width = 100 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "Ttl G.W. (Kg)"  'Grd_TtlGW,
            .Columns(col).ReadOnly = True
            .Columns(col).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(col).Width = 100 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "Ttl N.W. (Kg)"  'Grd_TtlNW,
            .Columns(col).ReadOnly = True
            .Columns(col).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(col).Width = 100 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "Packing (Wgt)"  'Grd_PckWgt,
            .Columns(col).ReadOnly = True
            .Columns(col).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(col).Width = 120 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "Packing (UM)"  'Grd_PckUM,
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 120 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "Ttl Ship Qty"  'Grd_TtlShpQty,
            .Columns(col).ReadOnly = True
            .Columns(col).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(col).Width = 100 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "Ori Ship Qty"  'Grd_TtlShpQty as 'OriShpQty',
            .Columns(col).ReadOnly = True
            .Columns(col).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(col).Width = 75

            col = col + 1
            .Columns(col).HeaderText = "UM (Ttl Ship Qty)"  'Grd_ShpUM,
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 110

            col = col + 1
            .Columns(col).HeaderText = "Department"  'Grd_RevDept,
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 140 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "Ref No"  'Grd_RefNo,
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 100 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "MPO No"  'Grd_MpoNo,
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 120 / 1.3

            col = col + 1
            .Columns(col).HeaderText = "Custom Qty"  'Grd_CustQty,
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 80
            .Columns(col).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            col = col + 1
            .Columns(col).HeaderText = "Custom UM"  'Grd_CustUM,
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 80

            col = col + 1                    'Grd_DtlRmk
            .Columns(col).Width = 0
            .Columns(col).Visible = False

            col = col + 1
            '.Columns(col).HeaderText = ""  'Grd_CreUsr,
            .Columns(col).Width = 0
            .Columns(col).Visible = False

            col = col + 1
            '.Columns(col).HeaderText = ""  'Grd_CreDat,
            .Columns(col).Width = 0
            .Columns(col).Visible = False

            col = col + 1
            '.Columns(col).HeaderText = ""  'Grd_UpdUsr,
            .Columns(col).Width = 0
            .Columns(col).Visible = False

            col = col + 1
            '.Columns(col).HeaderText = ""  'Grd_UpdDat,
            .Columns(col).Width = 0
            .Columns(col).Visible = False

            col = col + 1
            '.Columns(col).HeaderText = ""  'cast(Grd_TimStp as int) as 'TimStp'
            .Columns(col).Width = 0
            .Columns(col).Visible = False


            '        col = col + 1
            '        .Columns(col).width = 0
        End With
    End Sub

    Private Sub DisplayDetail()
        Dim um As String
        Dim color As String
        Dim itmNo As String
        Dim itmnam As String

        Dim lngOrd As Double
        Dim lngOS As Double

        If rs_GRNTRFDTL.Tables("result") Is Nothing Then Exit Sub
        If rs_GRNTRFDTL.Tables("result").Rows.Count <= 0 Then
            Call setStatus("Display_Dtl")
            Exit Sub
        End If
        bolDisplay = True

        If rs_GRNTRFDTL.Tables("result").Rows(readingindex)("DEL") = "Y" Then
            Exit Sub
        End If


        With rs_GRNTRFDTL
            'If .BOF = True Then
            '    .MoveFirst()
            'ElseIf .EOF = True Then
            '    .MoveFirst()
            'End If

            Me.txtSeq.Text = .Tables("result").Rows(readingindex)("Grd_Seq")
            If IsDBNull(.Tables("result").Rows(readingindex)("Grd_PrtGrp")) Then
                Me.txtPrtGrp.Text = ""
            Else
                Me.txtPrtGrp.Text = .Tables("result").Rows(readingindex)("Grd_PrtGrp")
            End If

            Me.txtQty.Text = ""
            Me.txtOSQty.Text = ""
            Dtl_ORIQTY = 0
            If Trim(.Tables("result").Rows(readingindex)("Grd_Type")) = "MPO" Or Trim(.Tables("result").Rows(readingindex)("Grd_Type")) = "AdHoc" Then
                Me.cboMPONo.Text = .Tables("result").Rows(readingindex)("Grd_MpoNo")
                Me.cboDtl.Text = .Tables("result").Rows(readingindex)("Grd_ItmNo") & "; " & Microsoft.VisualBasic.Left(.Tables("result").Rows(readingindex)("Grd_ItmNam"), 20) & "; " & .Tables("result").Rows(readingindex)("Grd_Color") & "; " & .Tables("result").Rows(readingindex)("Grd_ShpUM")
                Me.optType0.Checked = True
                Me.txtItmNo.ReadOnly = True
                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                '2005-10-14
                lblPONo.Visible = False
                Me.txtPONo.Visible = False
                lblDtlRmk.Visible = False
                txtDtlRmk.Visible = False
                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                Call displayGrdDtlLst()
                If Not rs_GRNTRFLST.Tables("result") Is Nothing Then

                    With rs_GRNTRFLST
                        For index As Integer = 0 To rs_GRNTRFLST.Tables("RESULT").DefaultView.Count - 1
                            lngOrd = lngOrd + .Tables("result").DefaultView(index)("OrdQty")
                            lngOS = lngOS + .Tables("result").DefaultView(index)("OSQty")
                            Dtl_ORIQTY = Dtl_ORIQTY + .Tables("result").DefaultView(index)("OriShpQty")
                        Next
                    End With

                    ' Changed by Mark Lau 20090616
                    If Trim(.Tables("result").Rows(readingindex)("Grd_Type")) = "AdHoc" And .Tables("result").Rows(readingindex)("Grd_MpoNo") = "" Then

                    Else
                        Me.txtQty.Text = lngOrd
                        Me.txtOSQty.Text = lngOS
                    End If

                End If
                'Call Grid_CalSubTtl
            ElseIf Trim(.Tables("result").Rows(readingindex)("Grd_Type")) = "AdHoc" Then

                '            Me.cboMPONo.Text = ""
                '            Me.cboDtl.Text = ""
                '
                '            Me.optType1.checked = True
                '            Me.txtItmNo.ReadOnly = False
                '            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                '            '2005-10-14
                '            lblPONo.Visible = True
                '            Me.txtPONo.Visible = True
                '            lblDtlRmk.Visible = True
                '            txtDtlRmk.Visible = True
                '            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            ElseIf Trim(.Tables("result").Rows(readingindex)("Grd_Type")) = "Misc" Then
                Me.cboMPONo.Text = ""
                Me.cboDtl.Text = ""
                Me.optType2.Checked = True
                Me.txtItmNo.ReadOnly = False
                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                '2005-10-14
                lblPONo.Visible = True
                Me.txtPONo.Visible = True
                lblDtlRmk.Visible = True
                txtDtlRmk.Visible = True
                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            End If

            ' Added by Mark Lau 20090616
            If Trim(.Tables("result").Rows(readingindex)("Grd_Type")) = "AdHoc" Then
                If .Tables("result").Rows(readingindex)("Grd_MpoNo") = "" Then
                    Me.cboMPONo.Text = ""
                    Me.cboDtl.Text = ""
                End If

                Me.optType1.Checked = True
                Me.txtItmNo.ReadOnly = False
                lblPONo.Visible = True
                Me.txtPONo.Visible = True
                lblDtlRmk.Visible = True
                txtDtlRmk.Visible = True
            End If


            Me.txtItmNo.Text = .Tables("result").Rows(readingindex)("Grd_ItmNo")
            Me.txtItmNam.Text = .Tables("result").Rows(readingindex)("Grd_ItmNam")
            'Me.txtItmDesc.Text = .Tables("result").rows(readingindex)("Grd_ItmDsc")
            Me.txtColor.Text = .Tables("result").Rows(readingindex)("Grd_Color")
            Me.txtUntPrc.Text = .Tables("result").Rows(readingindex)("Grd_UntPrc")
            Me.txtShpQty.Text = .Tables("result").Rows(readingindex)("Grd_TtlShpQty")
            Me.txtShpUM.Text = .Tables("result").Rows(readingindex)("Grd_ShpUM")
            Me.txtDept.Text = .Tables("result").Rows(readingindex)("Grd_RevDept")

            Me.cboCat.Text = IIf(IsDBNull(.Tables("result").Rows(readingindex)("Grd_CustCat")), "", .Tables("result").Rows(readingindex)("Grd_CustCat"))
            Me.txtPONo.Text = IIf(IsDBNull(.Tables("result").Rows(readingindex)("Grd_RefNo")), "", .Tables("result").Rows(readingindex)("Grd_RefNo"))
            Me.txtDtlRmk.Text = IIf(IsDBNull(.Tables("result").Rows(readingindex)("Grd_DtlRmk")), "", .Tables("result").Rows(readingindex)("Grd_DtlRmk"))  '2005-10-14
            Me.cboCountry.Text = .Tables("result").Rows(readingindex)("Grd_Cty")

            Me.txtCTNFm.Text = .Tables("result").Rows(readingindex)("Grd_CTNFm")
            Me.txtCTNTo.Text = .Tables("result").Rows(readingindex)("Grd_CTNTo")
            Me.txtTtlCTN_D.Text = .Tables("result").Rows(readingindex)("Grd_TtlCTN")
            Me.cboTtlCTN_D_UM.Text = .Tables("result").Rows(readingindex)("Grd_CtnUM")
            Me.txtGW.Text = .Tables("result").Rows(readingindex)("Grd_GW")
            Me.txtNW.Text = .Tables("result").Rows(readingindex)("Grd_NW")
            Me.txtTtlGW_D.Text = .Tables("result").Rows(readingindex)("Grd_TtlGW")
            Me.txtTtlNW_D.Text = .Tables("result").Rows(readingindex)("Grd_TtlNW")
            Me.txtPck.Text = .Tables("result").Rows(readingindex)("Grd_PckWgt")
            Me.txtPck_UM.Text = .Tables("result").Rows(readingindex)("Grd_PckUM")
            Me.cboGroup.Text = .Tables("result").Rows(readingindex)("Grd_Grp")

            '2005-10-14
            Me.txtDtlRmk.Text = .Tables("result").Rows(readingindex)("Grd_DtlRmk")
            'Me.txtCustUM.ReadOnly = True
            '2008-02-28
            'Me.CboCustUM.ReadOnly = True

            'Me.txtCustUM.Text = .Tables("result").rows(readingindex)("Grd_CustUM")
            Me.CboCustUM.Text = .Tables("result").Rows(readingindex)("Grd_CustUM")

            Me.txtCustQty.Text = Format(.Tables("result").Rows(readingindex)("Grd_CustQty"), "######.#0")
            '--------------------------------------------

            Me.cboCurr.Text = .Tables("result").Rows(readingindex)("Grd_Curr")
            Me.txtUntPrc.Text = .Tables("result").Rows(readingindex)("Grd_UntPrc")
            If Trim(.Tables("result").Rows(readingindex)("Grd_Type")) = "MPO" Or Trim(.Tables("result").Rows(readingindex)("Grd_Type")) = "AdHoc" Then
                'Me.txtUntPrc.Text = "0"
                Call Grid_CalSubTtl()
                Call grdDtlLst_AfterColUpdate(colShpQty)
            Else
                'Me.txtSubTtl.Text = Format(CLng(IIf(Me.txtShpQty.Text = "", 0, Me.txtShpQty.Text)) * CDbl(IIf(Me.txtUntPrc.Text = "", 0, Me.txtUntPrc.Text)), "######.#0")
                Me.grdDtlLst.DataSource = Nothing
            End If

            Me.txtCustSubTtl.Text = Format(CDbl(IIf(Me.txtCustQty.Text = "", 0, Me.txtCustQty.Text)) * CDbl(IIf(Me.txtUntPrc.Text = "", 0, Me.txtUntPrc.Text)), "######.#0")

            If .Tables("result").Rows(readingindex)("Del") = "Y" Or .Tables("result").Rows(readingindex)("CreUsr") = "~*NEW*~" Then
                Me.chkDelete.Checked = True
            Else
                Me.chkDelete.Checked = False
            End If

            If strMode = "CLO" Or strMode = "REL" Then
                Call setStatus("Display_Dtl")
            ElseIf .Tables("result").Rows(readingindex)("Del") = "Y" Or .Tables("result").Rows(readingindex)("CreUsr") = "~*NEW*~" Then
                Call setStatus("Delete_Dtl")
            Else
                Call setStatus("Update_Dtl")
            End If
        End With
        bolDisplay = False
    End Sub
    'temp



    Public Sub mmdFindClick()

        If Me.txtGRNNo.Text = "" Then
            MsgBox("Please input GRN No!")
            If Me.txtGRNNo.Enabled = True Then Me.txtGRNNo.Focus()
            Exit Sub
        End If

        addFlag = False

        'Show a list of MPO available for shipment
        Cursor = Cursors.WaitCursor
        Me.txtGRNNo.Text = UCase(Me.txtGRNNo.Text)



        gspStr = "sp_select_GRNTRFHDR  '','" & Trim(Me.txtGRNNo.Text) & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_GRNTRFHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_GRNTRFHDR  :" & rtnStr)
            Exit Sub
        End If
        For i2 As Integer = 0 To rs_GRNTRFHDR.Tables("RESULT").Columns.Count - 1
            rs_GRNTRFHDR.Tables("RESULT").Columns(i2).ReadOnly = False
        Next

        If rs_GRNTRFHDR.Tables("result").Rows.Count <= 0 Then
            MsgBox("No Record Found!")
            Call setFocus_text(Me.txtGRNNo)
            Cursor = Cursors.Default
            Exit Sub
        Else
            strMode = ""
            strMode = rs_GRNTRFHDR.Tables("result").Rows(0)("Mode")
        End If

        gspStr = "sp_select_GRNTRFDTL  '','" & Trim(Me.txtGRNNo.Text) & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_GRNTRFDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_GRNTRFDTL  :" & rtnStr)
            Exit Sub
        End If
        For i2 As Integer = 0 To rs_GRNTRFDTL.Tables("RESULT").Columns.Count - 1
            rs_GRNTRFDTL.Tables("RESULT").Columns(i2).ReadOnly = False
        Next


        gspStr = "sp_select_GRNTRFLST '','" & Trim(Me.txtGRNNo.Text) & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_GRNTRFLST, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_GRNTRFLST :" & rtnStr)
            Exit Sub
        End If
        For i2 As Integer = 0 To rs_GRNTRFLST.Tables("RESULT").Columns.Count - 1
            rs_GRNTRFLST.Tables("RESULT").Columns(i2).ReadOnly = False
        Next

        'Cursor = Cursors.Default






        txtMode.Text = strMode

        'Set initial sequence no
        With rs_GRNTRFDTL
            If Not rs_GRNTRFDTL.Tables("result") Is Nothing Then
                If .Tables("result").Rows.Count > 0 Then

                    .Tables("result").DefaultView.Sort = "Grd_Seq"

                    seq = CInt(.Tables("result").DefaultView(.Tables("result").DefaultView.Count - 1)("Grd_Seq"))


                End If
            End If
        End With

        '2005-10-17, initial recordset for cumulative i) Ship Qty and ii) OS Qty
        Call CumulativeQty_init()


        If strMode = "ACT" Then
            Call setStatus("Update")
        Else
            Call setStatus("Display")
        End If
        Call DisplayHeader()

        Cursor = Cursors.WaitCursor


        gspStr = "sp_list_MPM00002  '','MPO','" & Trim(cboImpFty.Text) & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_MPONo, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_list_MPM00002:" & rtnStr)
            Exit Sub
        End If
        Me.cboMPONo.Items.Clear()
        For index As Integer = 0 To rs_MPONo.Tables("RESULT").Rows.Count - 1
            cboMPONo.Items.Add(rs_MPONo.Tables("RESULT").Rows(index)("Mph_MpoNo"))
        Next



        If Not rs_GRNTRFDTL.Tables("result") Is Nothing Then
            If rs_GRNTRFDTL.Tables("result").Rows.Count > 0 Then
                'rs_GRNTRFDTL.MoveFirst()
                readingindex = 0
                'tempz
                strCurrGBL = rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_Curr")

                Call initGroup()
                Call DisplayDetail()
                Call setStatus("Update_Dtl")
            Else
                seq = 0
                Call setStatus("Display_Dtl")
            End If
            Call DisplaySummary()
        End If

        addFlag = False
        Cursor = Cursors.Default
    End Sub

    'Private Sub cmdfirstD_Click()
    '    Call moveRecord("F")
    'End Sub

    Private Sub cmdInsRow_Click()
    End Sub

    Private Sub showStatusBar()
        If bolDisplay = True Then Exit Sub
        If addFlag = True Then Exit Sub

        If Me.btcMPM00002.SelectedIndex = 0 Then
            If Not rs_GRNTRFHDR.Tables("result") Is Nothing Then
                With rs_GRNTRFHDR
                    If .Tables("result").Rows.Count > 0 Then
                        'If Not .BOF Then
                        'If Not .EOF Then
                        Me.StatusBar.Panels(1).Text = UCase(rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_UpdUsr")) & " " & Format(rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_CreDat"), "MM/dd/yyyy") & " " & Format(rs_GRNTRFHDR.Tables("result").Rows(0)("Grh_UpdDat"), "MM/dd/yyyy")
                        'End If
                        'End If
                    End If
                End With
            End If

        Else
            If Not rs_GRNTRFDTL.Tables("result") Is Nothing Then
                With rs_GRNTRFDTL
                    If .Tables("result").Rows.Count > 0 Then
                        'If Not .BOF Then
                        'If Not .EOF Then
                        Me.StatusBar.Panels(1).Text = UCase(.Tables("result").Rows(0)("Grd_UpdUsr")) & " " & Format(.Tables("result").Rows(0)("Grd_CreDat"), "MM/dd/yyyy") & " " & Format(.Tables("result").Rows(0)("Grd_UpdDat"), "MM/dd/yyyy")
                        'End If
                        'End If
                    End If
                End With
            End If
        End If

    End Sub


    Private Sub clearHeader()
        Me.txtImpFtyAddr.Text = ""
        Me.txtDestAddr.Text = ""
        Me.txtInvHdr.Text = ""
        Me.cboCar.Text = ""
        Me.cboCustUM_H.Text = ""
        Me.cboInvUM_H.Text = ""
        Me.txtAgtNo.Text = ""
        Me.txtTtlNW.Text = ""
        Me.txtTtlGW.Text = ""
        Me.txtTtlCTN.Text = ""
        '2006-03-20
        Me.txtDlvDat.Text = Format(Date.Today, "MM/dd/yyyy").ToString
        Me.txtCtrNo.Text = ""
    End Sub

    Private Sub clearDetail(Optional ByVal opt As String = "")
        'Me.txtSeq.Text = ""
        'Me.optType0.checked = True
        If opt = "ALL" Then
            Me.cboMPONo.Items.Clear()
            Me.cboGroup.Items.Clear()
            Me.cboDtl.Items.Clear()
            Me.txtSeq.Text = ""
        ElseIf opt = "DTL" Then
            Me.cboDtl.Text = ""
        Else
            'Me.cboMPONo.Text = ""
            Me.cboGroup.Text = ""
            Me.cboDtl.Text = ""
        End If


        Me.txtItmNo.Text = ""
        Me.txtItmNam.Text = ""
        'Me.txtItmDesc.Text = ""
        Me.txtPONo.Text = ""
        Me.txtDtlRmk.Text = "" '2005-10-14
        Me.cboCat.Text = ""
        Me.cboCountry.Text = ""
        Me.txtDept.Text = ""

        Me.txtCTNFm.Text = ""
        Me.txtCTNTo.Text = ""
        Me.txtTtlCTN_D.Text = ""
        Me.txtCustQty.Text = "0"
        txtCustSubTtl.Text = "0"
        Me.cboTtlCTN_D_UM.Text = ""
        Me.txtGW.Text = ""
        'Me.txtGW_UM.Text = ""
        Me.txtNW.Text = ""
        'Me.txtNW_UM.Text = ""
        Me.txtTtlGW_D.Text = ""
        'Me.txtTtlGW_D_UM.Text = ""
        Me.txtTtlNW_D.Text = ""
        'Me.txtTtlNW_D_UM.Text = ""
        Me.txtPck.Text = ""
        'Me.txtPck_UM.Text = ""

        Me.txtQty.Text = ""
        Me.txtOSQty.Text = ""
        Dtl_ORIQTY = 0
        Me.txtShpQty.Text = ""
        'Me.txtShpUM.Text = ""
        '    Me.cboCurr.Text = ""
        Me.txtUntPrc.Text = ""
        'Me.txtMinPrc.Text = ""
        'Me.txtSubTtl.Text = ""

        grdDtlLst.DataSource = Nothing
    End Sub

    Private Sub clearTop()
        'me.txtGRNNo.Text = ""
        Me.txtMode.Text = ""
        Me.cboImpFty.Text = ""
        Me.cboDest.Text = ""
        Me.txtIssDat.Text = ""
        Me.txtRvsDat.Text = ""
    End Sub

    'Private Sub cmdlastD_Click()
    'Call moveRecord("L")
    'End Sub

    'Private Sub cmdNextD_Click()
    '    Call moveRecord("N")
    'End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        Call CmdSaveClick()
    End Sub

    '
    Private Sub CmdSaveClick()
        If checkFocus(Me) Then Exit Sub
        Dim MaxSeq As Integer
        Dim custCat As String
        Dim lngCount As Long

        Dim Doc_No As String
        Dim rs_tmp As New DataSet
        'tempz
        'Dim rs_tmp() As New DataSet
        Dim rs_Modify As New DataSet

        Dim strMPO As String
        Dim tmpMPO As String
        Dim strSeq As String
        Dim tmpSeq As String
        Dim OSQty As Double
        Dim strSeqLst As String
        Dim strName As String

        Dim strOSMsg As String

        save_ok = False
        'check data validation (Detail)
        If btcMPM00002.SelectedIndex = 1 Then
            If Not rs_GRNTRFDTL.Tables("result") Is Nothing Then
                If rs_GRNTRFDTL.Tables("result").Rows.Count > 0 Then
                    If checkDetail() = False Then Exit Sub
                    'check and update detail
                    Call UpdateDetail()
                End If
            End If
        End If


        If rs_GRNTRFDTL.Tables("result") Is Nothing Then Exit Sub
        If rs_GRNTRFDTL.Tables("result").Rows.Count <= 0 Then Exit Sub

        '#################################################
        'Check OS Ship Qty before save


        If CheckGroupData() = False Then
            Exit Sub
        End If




        Cursor = Cursors.WaitCursor
        strOSMsg = ""
        If Not rs_GRNTRFLST.Tables("result") Is Nothing Then
            If rs_GRNTRFLST.Tables("result").Rows.Count > 0 Then
                OSQty = 0
                bolDisplay = True
                With rs_GRNTRFLST
                    .Tables("result").DefaultView.RowFilter = ""
                    .Tables("result").DefaultView.Sort = "MPONo,MPOSeq"

                    For index As Integer = 0 To rs_GRNTRFLST.Tables("RESULT").DefaultView.Count - 1
                        '           .MoveFirst()

                        strMPO = .Tables("result").DefaultView(index)("MPONo")
                        strSeq = .Tables("result").DefaultView(index)("MPOSeq")
                        strName = .Tables("result").DefaultView(index)("Mpd_ItmNam")
                        strSeqLst = ""

                        'Do While Not .EOF
                        tmpMPO = .Tables("result").DefaultView(index)("MPONo")
                        tmpSeq = .Tables("result").DefaultView(index)("MPOSeq")

                        If tmpMPO <> strMPO Or strSeq <> tmpSeq Then
                            If OSQty <> 0 Then
                                gsCompany = IIf(gsCompanyGroup = "UCG", "UCPP", "MS")
                                Call Update_gs_Value(gsCompany)
                                gspStr = "sp_select_MPM00002_OS_Qty '','" & strMPO & "'," & strSeq
                                rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
                                If rtnLong <> RC_SUCCESS Then
                                    bolDisplay = False
                                    MsgBox("Error on loading  sp_select_MPM00002_OS_Qty :" & rtnStr)
                                    Exit Sub
                                Else
                                    If OSQty > CDbl(rs_tmp.Tables("RESULT").Rows(0)("OSQty")) Then
                                        strOSMsg = strOSMsg & IIf(Len(strOSMsg) > 0, vbCrLf, "") & "MPO # : " & strMPO & " Seq(" & strSeqLst & ")" & "User Request : " & Str(OSQty) & IIf(OSQty > 0, " more.", " less.") & " OS Qty : " & rs_tmp.Tables("RESULT").Rows(0)("OSQty") & vbCrLf & "Item : " & strName
                                    End If
                                End If

                                'OSQty = (.Tables("result").DefaultView(index)("ShpQty") - .Tables("result").DefaultView(index)("OriShpQty"))
                                If .Tables("result").DefaultView(index)("CreUsr") <> "~*NEW*~" And .Tables("result").DefaultView(index)("Del") = "Y" Then
                                    OSQty = (0 - .Tables("result").DefaultView(index)("OriShpQty"))
                                Else
                                    OSQty = (.Tables("result").DefaultView(index)("ShpQty") - .Tables("result").DefaultView(index)("OriShpQty"))
                                End If


                                strMPO = tmpMPO
                                strSeq = tmpSeq
                                strSeqLst = .Tables("result").DefaultView(index)("Grl_GrnSeq")
                                strName = .Tables("result").DefaultView(index)("Mpd_ItmNam")
                            Else
                                'OSQty = OSQty + (.Tables("result").DefaultView(index)("ShpQty") - .Tables("result").DefaultView(index)("OriShpQty"))
                                If .Tables("result").DefaultView(index)("CreUsr") <> "~*NEW*~" And .Tables("result").DefaultView(index)("Del") = "Y" Then
                                    OSQty = OSQty + (0 - .Tables("result").DefaultView(index)("OriShpQty"))
                                Else
                                    OSQty = OSQty + (.Tables("result").DefaultView(index)("ShpQty") - .Tables("result").DefaultView(index)("OriShpQty"))
                                End If

                                strSeqLst = strSeqLst & IIf(Len(strSeqLst) > 0, ",", "") & .Tables("result").DefaultView(index)("Grl_GrnSeq")

                            End If
                        End If
                    Next

                    '.MoveNext()
                    'Loop


                    If OSQty <> 0 Then
                        gspStr = "sp_select_MPM00002_OS_Qty '','" & strMPO & "'," & strSeq
                        gsCompany = IIf(gsCompanyGroup = "UCG", "UCPP", "MS")
                        Call Update_gs_Value(gsCompany)
                        gspStr = "sp_select_MPM00002_OS_Qty '','" & strMPO & "'," & strSeq
                        rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            bolDisplay = False
                            MsgBox("Error on loading  sp_select_MPM00002_OS_Qty :" & rtnStr)
                            Exit Sub
                        Else
                            If OSQty > CDbl(rs_tmp.Tables("RESULT").Rows(0)("OSQty")) Then
                                strOSMsg = strOSMsg & IIf(Len(strOSMsg) > 0, vbCrLf, "") & "MPO # : " & strMPO & " Seq(" & strSeqLst & ")" & " User Request : " & Str(OSQty) & IIf(OSQty > 0, " more.", " less.") & " OS Qty : " & rs_tmp.Tables("RESULT").Rows(0)("OSQty") & vbCrLf & "Item : " & strName
                            End If
                        End If
                    End If
                    '.MoveFirst
                End With
                bolDisplay = False
            End If
        End If



        If strOSMsg <> "" Then
            Call moveRecord("X")
            MsgBox(strOSMsg, vbOKOnly + vbCritical, "OS Qty Violation")
            Cursor = Cursors.Default
            Exit Sub
        End If

        '#################################################

        If addFlag = True Then
            With rs_GRNTRFDTL
                .Tables("result").DefaultView.RowFilter = "CreUsr='~*ADD*~' and Del <> 'Y'"
                If .Tables("result").Rows.Count <= 0 Then
                    .Tables("result").DefaultView.RowFilter = ""
                    MsgBox("There is no detail record!")
                    Cursor = Cursors.Default
                    Exit Sub
                End If
                .Tables("result").DefaultView.RowFilter = ""
            End With
        End If


        'Check data validation (Header)
        Call calTotalNWGW_Hdr()
        If checkHeader() = False Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Doc_No = ""

        If addFlag = True Then
            gspStr = "sp_select_DOC_GEN '" & "UCPP" & "','GT','" & gsUsrID & "'"
            'tempzzzzzzzzzzzzzzzzz   co
            rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdSaveClick sp_select_DOC_GEN :" & rtnStr)
                Cursor = Cursors.Default
                Exit Sub
            End If
            Doc_No = rs_tmp.Tables("RESULT").Rows(0)(0).ToString
        Else
            Doc_No = Trim(Me.txtGRNNo.Text)
        End If

        Cursor = Cursors.Default
        If Doc_No = "" Then Exit Sub

        Call isHeaderUpdated()
        '---------------------------------------------------------------------

        'Add / Modify Header info
        '---------------------------------------------------------------------

        Cursor = Cursors.WaitCursor
        If addFlag = True Then
            '1 . Insert Header
            gspStr = "sp_insert_GRNTRFHDR "
        ElseIf Recordstatus = True Then
            '2 . Update Header
            gspStr = "sp_Update_GRNTRFHDR "
        End If


        If gspStr <> "" Then
            gspStr = gspStr & "'','" & Doc_No & _
                    "','" & Trim(Me.cboImpFty.Text) & _
                    "','" & Trim(Me.cboDest.Text) & _
                    "','" & Trim(Me.txtImpFtyAddr.Text) & _
                    "','" & Trim(Me.txtDestAddr.Text) & _
                    "','" & Trim(Me.txtInvHdr.Text) & _
                    "','" & Trim(Me.txtAgtNo.Text) & _
                    "','" & Trim(Me.txtTrdCty.Text) & _
                    "','" & Trim(Replace(Me.cboCar.Text, "'", "''")) & _
                    "','" & Trim(Me.cboCustUM_H.Text) & _
                    "','" & Trim(Me.cboInvUM_H.Text) & _
                    "','" & Trim(Me.txtTtlCTN.Text) & _
                    "','" & Trim(Me.txtTtlNW.Text) & _
                    "','" & Trim(Me.txtTtlGW.Text) & _
                    "','" & Trim(Me.txtDlvDat.Text) & _
                    "','" & Trim(Me.txtCtrNo.Text) & _
                    "','" & gsUsrID & "'"

            gsCompany = IIf(gsCompanyGroup = "UCG", "UCPP", "MS")
            Call Update_gs_Value(gsCompany)

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading Saving Header:" & rtnStr)
                Cursor = Cursors.Default
                Exit Sub
            End If


        End If
        Cursor = Cursors.Default


        '---------------------------------------------------------------------

        'Add / Modify / Delete Detail info
        '---------------------------------------------------------------------


        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        'Delete
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        Cursor = Cursors.WaitCursor

        With rs_GRNTRFDTL
            .Tables("result").DefaultView.RowFilter = ""
            .Tables("result").DefaultView.RowFilter = "CreUsr<>'~*NEW*~' and CreUsr <> '~*ADD*~' and Del = 'Y'"

            For index As Integer = 0 To rs_GRNTRFDTL.Tables("RESULT").DefaultView.Count - 1
                gspStr = "sp_physical_delete_GRNTRFDTL  '','" & .Tables("result").DefaultView(index)("Grd_GrnNo") & _
                  "','" & .Tables("result").DefaultView(index)("Grd_seq") & _
                  "','" & .Tables("result").DefaultView(index)("TimStp") & _
                  "','" & gsUsrID & "'"
                gsCompany = IIf(gsCompanyGroup = "UCG", "UCPP", "MS")
                Call Update_gs_Value(gsCompany)

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading deleting Detail:" & rtnStr)
                    Cursor = Cursors.Default
                    Exit Sub
                End If

            Next


        End With
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        'Update
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        Cursor = Cursors.WaitCursor

        With rs_GRNTRFDTL
            .Tables("result").DefaultView.RowFilter = ""
            .Tables("result").DefaultView.RowFilter = "CreUsr='~*UPD*~' and Del <> 'Y'"

            For index As Integer = 0 To rs_GRNTRFDTL.Tables("RESULT").DefaultView.Count - 1

                custCat = ""
                If InStr(Trim(.Tables("result").DefaultView(index)("Grd_CustCat")), "-") > 0 Then
                    'custCat = Replace(Trim(Split(.Tables("result").DefaultView(index)("Grd_CustCat"), "-")(0)), "'", "''")
                    custCat = Trim(Split(.Tables("result").DefaultView(index)("Grd_CustCat"), "-")(0))
                End If

                gspStr = "sp_update_GRNTRFDTL  ''," & _
                                  "'" & .Tables("result").DefaultView(index)("Grd_GrnNo") & "','" & .Tables("result").DefaultView(index)("Grd_Seq") & _
                                  "','" & .Tables("result").DefaultView(index)("Grd_Type") & "','" & .Tables("result").DefaultView(index)("Grd_MpoNo") & _
                                  "','" & .Tables("result").DefaultView(index)("Grd_RefNo") & _
                                  "','" & .Tables("result").DefaultView(index)("Grd_ItmNo") & "','" & .Tables("result").DefaultView(index)("Grd_ItmNam") & _
                                  "','" & .Tables("result").DefaultView(index)("Grd_ItmDsc") & "','" & .Tables("result").DefaultView(index)("Grd_Curr") & _
                                  "','" & .Tables("result").DefaultView(index)("Grd_UntPrc") & "','" & .Tables("result").DefaultView(index)("Grd_Color") & _
                                  "','" & custCat & "','" & .Tables("result").DefaultView(index)("Grd_Cty") & _
                                  "','" & .Tables("result").DefaultView(index)("Grd_CTNFm") & "','" & .Tables("result").DefaultView(index)("Grd_CTNTo") & _
                                  "','" & .Tables("result").DefaultView(index)("Grd_TtlCTN") & "','" & .Tables("result").DefaultView(index)("Grd_CtnUM") & _
                                  "','" & .Tables("result").DefaultView(index)("Grd_GW") & "','" & .Tables("result").DefaultView(index)("Grd_NW") & _
                                  "','" & .Tables("result").DefaultView(index)("Grd_TtlGW") & "','" & .Tables("result").DefaultView(index)("Grd_TtlNW") & _
                                  "','" & .Tables("result").DefaultView(index)("Grd_PckWgt") & "','" & .Tables("result").DefaultView(index)("Grd_PckUM") & _
                                  "','" & .Tables("result").DefaultView(index)("Grd_Grp") & "','" & .Tables("result").DefaultView(index)("Grd_TtlShpQty") & _
                                  "','" & .Tables("result").DefaultView(index)("Grd_ShpUM") & "','" & .Tables("result").DefaultView(index)("Grd_RevDept") & _
                                  "','" & .Tables("result").DefaultView(index)("Grd_CustUM") & "','" & .Tables("result").DefaultView(index)("Grd_DtlRmk") & _
                                  "','" & .Tables("result").DefaultView(index)("Grd_CustQty") & _
                                  "','" & .Tables("result").DefaultView(index)("Grd_PrtGrp") & _
                                  "','" & .Tables("result").DefaultView(index)("TimStp") & _
                                  "','" & gsUsrID & "'"

                gsCompany = IIf(gsCompanyGroup = "UCG", "UCPP", "MS")
                Call Update_gs_Value(gsCompany)

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading updating Detail:" & rtnStr)
                    Cursor = Cursors.Default
                    Exit Sub
                End If

            Next


        End With

        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        'Add
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        Dim seq As Integer


        Cursor = Cursors.WaitCursor

        With rs_GRNTRFDTL
            .Tables("result").DefaultView.RowFilter = ""
            .Tables("result").DefaultView.RowFilter = "CreUsr='~*ADD*~' and Del <> 'Y'"

            For index As Integer = 0 To rs_GRNTRFDTL.Tables("RESULT").DefaultView.Count - 1

                custCat = ""
                If InStr(Trim(.Tables("result").DefaultView(index)("Grd_CustCat")), "-") > 0 Then
                    'custCat = Replace(Trim(Split(.Tables("result").DefaultView(index)("Grd_CustCat"), "-")(0)), "'", "''")
                    custCat = Trim(Split(.Tables("result").DefaultView(index)("Grd_CustCat"), "-")(0))
                End If

                gspStr = "sp_insert_GRNTRFDTL '" & _
                                "','" & Doc_No & _
                               "','" & .Tables("result").DefaultView(index)("Grd_Type") & "','" & .Tables("result").DefaultView(index)("Grd_MpoNo") & _
                               "','" & .Tables("result").DefaultView(index)("Grd_RefNo") & _
                               "','" & .Tables("result").DefaultView(index)("Grd_ItmNo") & "','" & .Tables("result").DefaultView(index)("Grd_ItmNam") & _
                               "','" & .Tables("result").DefaultView(index)("Grd_ItmDsc") & "','" & .Tables("result").DefaultView(index)("Grd_Curr") & _
                               "','" & .Tables("result").DefaultView(index)("Grd_UntPrc") & "','" & .Tables("result").DefaultView(index)("Grd_Color") & _
                               "','" & custCat & "','" & .Tables("result").DefaultView(index)("Grd_Cty") & _
                               "','" & .Tables("result").DefaultView(index)("Grd_CTNFm") & "','" & .Tables("result").DefaultView(index)("Grd_CTNTo") & _
                               "','" & .Tables("result").DefaultView(index)("Grd_TtlCTN") & "','" & .Tables("result").DefaultView(index)("Grd_CtnUM") & _
                               "','" & .Tables("result").DefaultView(index)("Grd_GW") & "','" & .Tables("result").DefaultView(index)("Grd_NW") & _
                               "','" & .Tables("result").DefaultView(index)("Grd_TtlGW") & "','" & .Tables("result").DefaultView(index)("Grd_TtlNW") & _
                               "','" & .Tables("result").DefaultView(index)("Grd_PckWgt") & "','" & .Tables("result").DefaultView(index)("Grd_PckUM") & _
                               "','" & .Tables("result").DefaultView(index)("Grd_Grp") & "','" & .Tables("result").DefaultView(index)("Grd_TtlShpQty") & _
                               "','" & .Tables("result").DefaultView(index)("Grd_ShpUM") & _
                               "','" & .Tables("result").DefaultView(index)("Grd_RevDept") & "','" & .Tables("result").DefaultView(index)("Grd_CustUM") & _
                               "','" & Trim(Me.txtDtlRmk.Text) & _
                               "','" & .Tables("result").DefaultView(index)("Grd_CustQty") & _
                               "','" & .Tables("result").DefaultView(index)("Grd_PrtGrp") & _
                               "','" & gsUsrID & "'"
                '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                gsCompany = IIf(gsCompanyGroup = "UCG", "UCPP", "MS")
                Call Update_gs_Value(gsCompany)

                rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading adding Detail:" & rtnStr)
                    Cursor = Cursors.Default
                    Exit Sub
                Else
                    seq = CInt(rs_tmp.Tables("RESULT").Rows(0)(0))
                    '                    seq = CInt(rs_tmp.Tables("RESULT").Rows(0)("Grd_Seq"))
                    'seq = CInt(rs_tmp(1)(0))
                    'tempzzzzzzzzzzzzzzzz

                    bolDisplay = True
                    If Not rs_GRNTRFLST.Tables("result") Is Nothing Then
                        rs_GRNTRFLST.Tables("result").DefaultView.RowFilter = "Grl_GrnSeq = " & .Tables("result").DefaultView(index)("Grd_Seq")
                        If rs_GRNTRFLST.Tables("result").DefaultView.Count > 0 Then
                            For index9 As Integer = 0 To rs_GRNTRFLST.Tables("RESULT").DefaultView.Count - 1
                                rs_GRNTRFLST.Tables("result").DefaultView(index9)("Grl_GrnSeq") = 3000 + seq

                                'Check Trigger Row Col Update or not
                            Next

                        End If
                        rs_GRNTRFLST.Tables("result").DefaultView.RowFilter = ""
                    End If
                    bolDisplay = False
                End If

            Next


        End With




        '---------------------------------------------------------------------

        'Add / Modify / Delete Detail List info
        '---------------------------------------------------------------------

        Cursor = Cursors.WaitCursor
        If Not rs_GRNTRFLST.Tables("result") Is Nothing Then

            With rs_GRNTRFLST
                .Tables("result").DefaultView.RowFilter = "CreUsr<>'~*ADD*~' and CreUsr <> '~*NEW*~' and Del='Y'"

                For index As Integer = 0 To rs_GRNTRFLST.Tables("RESULT").DefaultView.Count - 1
                    gsCompany = IIf(gsCompanyGroup = "UCG", "UCPP", "MS")
                    Call Update_gs_Value(gsCompany)
                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    '7 . Delete List
                    gspStr = "sp_physical_delete_GRNTRFLST  '" & _
                                   "','" & Doc_No & "','" & IIf(.Tables("result").DefaultView(index)("Grl_GrnSeq") > 3000, .Tables("result").DefaultView(index)("Grl_GrnSeq") - 3000, .Tables("result").DefaultView(index)("Grl_GrnSeq")) & _
                                   "','" & .Tables("result").DefaultView(index)("OriShpQty") & _
                                   "','" & .Tables("result").DefaultView(index)("MPONo") & "','" & .Tables("result").DefaultView(index)("MPOSeq") & _
                                   "','" & .Tables("result").DefaultView(index)("TimStp") & _
                                   "','" & gsUsrID & "'"
                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    If gspStr <> "" Then
                        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        'Debug.Print S
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading adding Detail:" & rtnStr)
                            Cursor = Cursors.Default
                            Exit Sub
                        End If

                        'If rs_Modify(0)(0) <> "0" Then  '*** An error has occured
                        '    'tempzzzzzzzzzzzzzzzz
                        '    If rs_Modify(0)(0) = "99" Then
                        '        MsgBox("Update Ship Qty of " & .Tables("result").DefaultView(index)("MPONo") & " (" & IIf(.Tables("result").DefaultView(index)("Grl_GrnSeq") > 3000, .Tables("result").DefaultView(index)("Grl_GrnSeq") - 3000, .Tables("result").DefaultView(index)("Grl_GrnSeq")) & ") failure!" & vbCrLf & "Please check the OS Qty.")
                        '    ElseIf rs_Modify(0)(0) = "88" Then
                        '        MsgBox("Process of " & .Tables("result").DefaultView(index)("MPONo") & " (" & IIf(.Tables("result").DefaultView(index)("Grl_GrnSeq") > 3000, .Tables("result").DefaultView(index)("Grl_GrnSeq") - 3000, .Tables("result").DefaultView(index)("Grl_GrnSeq")) & ") failure!")
                        '    Else
                        '        MsgBox(rs_Modify(0)(0), , "Save Header")
                        '    End If
                        '    Cursor = Cursors.Default
                        '    Exit Sub
                        'End If
                        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    End If
                    gspStr = ""
                Next


            End With


            With rs_GRNTRFLST
                .Tables("result").DefaultView.RowFilter = ""
                .Tables("result").DefaultView.RowFilter = "CreUsr<>'~*ADD*~' and CreUsr<>'~*NEW*~'"

                For index As Integer = 0 To rs_GRNTRFLST.Tables("RESULT").DefaultView.Count - 1

                    gsCompany = IIf(gsCompanyGroup = "UCG", "UCPP", "MS")
                    Call Update_gs_Value(gsCompany)

                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    'If .Tables("result").DefaultView(index)("ShpQty") <> .Tables("result").DefaultView(index)("OriShpQty") Then
                    If .Tables("result").DefaultView(index)("ShpQty") <> .Tables("result").DefaultView(index)("OriShpQty") Or _
                        Trim(.Tables("result").DefaultView(index)("Grl_DtlRmk")) <> Trim(.Tables("result").DefaultView(index)("_DtlRmk")) Then
                        '8 . Update List
                        gspStr = "sp_update_GRNTRFLST '" & _
                                       "','" & Doc_No & "','" & IIf(.Tables("result").DefaultView(index)("Grl_GrnSeq") > 3000, .Tables("result").DefaultView(index)("Grl_GrnSeq") - 3000, .Tables("result").DefaultView(index)("Grl_GrnSeq")) & _
                                       "','" & .Tables("result").DefaultView(index)("OriShpQty") & "','" & .Tables("result").DefaultView(index)("ShpQty") & _
                                       "','" & .Tables("result").DefaultView(index)("MPONo") & "','" & .Tables("result").DefaultView(index)("MPOSeq") & _
                                       "','" & .Tables("result").DefaultView(index)("Grl_DtlRmk") & "','" & .Tables("result").DefaultView(index)("TimStp") & _
                                       "','" & gsUsrID & "'"
                        If gspStr <> "" Then
                            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            'Debug.Print S
                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading adding Detail:" & rtnStr)
                                Cursor = Cursors.Default
                                Exit Sub
                            End If

                            'rs_Modify = objBSGate.Modify(gsConnStr, "sp_general", S)
                            'If rs_Modify(0)(0) <> "0" Then  '*** An error has occured
                            '    If rs_Modify(0)(0) = "99" Then
                            '        MsgBox("Update Ship Qty of " & .Tables("result").DefaultView(index)("MPONo") & " (" & IIf(.Tables("result").DefaultView(index)("Grl_GrnSeq") > 3000, .Tables("result").DefaultView(index)("Grl_GrnSeq") - 3000, .Tables("result").DefaultView(index)("Grl_GrnSeq")) & ") failure!" & vbCrLf & "Please check the OS Qty.")
                            '    ElseIf rs_Modify(0)(0) = "88" Then
                            '        MsgBox("Process of " & .Tables("result").DefaultView(index)("MPONo") & " (" & IIf(.Tables("result").DefaultView(index)("Grl_GrnSeq") > 3000, .Tables("result").DefaultView(index)("Grl_GrnSeq") - 3000, .Tables("result").DefaultView(index)("Grl_GrnSeq")) & ") failure!")
                            '    Else
                            '        MsgBox(rs_Modify(0)(0), , "Save Header")
                            '    End If
                            '    Cursor = Cursors.Default
                            '    Exit Sub
                            'End If
                            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        End If
                    End If
                    gspStr = ""
                Next
            End With


            With rs_GRNTRFLST
                .Tables("result").DefaultView.RowFilter = "CreUsr = '~*ADD*~'"


                For index As Integer = 0 To rs_GRNTRFLST.Tables("RESULT").DefaultView.Count - 1

                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    '6 . Insert List
                    gspStr = "sp_insert_GRNTRFLST '" & _
                                   "','" & Doc_No & _
                                   "','" & IIf(.Tables("result").DefaultView(index)("Grl_GrnSeq") > 3000, .Tables("result").DefaultView(index)("Grl_GrnSeq") - 3000, .Tables("result").DefaultView(index)("Grl_GrnSeq")) & _
                                   "','" & .Tables("result").DefaultView(index)("Grl_PONo") & "','" & .Tables("result").DefaultView(index)("Grl_POSeq") & _
                                   "','" & .Tables("result").DefaultView(index)("ShpQty") & "','" & .Tables("result").DefaultView(index)("Grl_Curr") & _
                                   "','" & .Tables("result").DefaultView(index)("Grl_UntPrc") & "','" & .Tables("result").DefaultView(index)("Grl_OrgPrc") & _
                                   "','" & .Tables("result").DefaultView(index)("MPONo") & "','" & .Tables("result").DefaultView(index)("MPOSeq") & _
                                   "','" & .Tables("result").DefaultView(index)("Dept") & "','" & .Tables("result").DefaultView(index)("Grl_DtlRmk") & "','" & .Tables("result").DefaultView(index)("TimStp") & _
                                   "','" & gsUsrID & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading adding Detail:" & rtnStr)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    'If gspStr <> "" Then
                    '    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    '    'Debug.Print S
                    '    gsCompany = IIf(gsCompanyGroup = "UCG", "UCPP", "MS")
                    '    Call Update_gs_Value(gsCompany)
                    '    rs_Modify = objBSGate.Modify(gsConnStr, "sp_general", S)
                    '    If rs_Modify(0)(0) <> "0" Then  '*** An error has occured
                    '        If rs_Modify(0)(0) = "99" Then
                    '            MsgBox("Update Ship Qty of " & .Tables("result").DefaultView(index)("MPONo") & " (" & IIf(.Tables("result").DefaultView(index)("Grl_GrnSeq") > 3000, .Tables("result").DefaultView(index)("Grl_GrnSeq") - 3000, .Tables("result").DefaultView(index)("Grl_GrnSeq")) & ") failure!" & vbCrLf & "Please check the OS Qty.")
                    '        ElseIf rs_Modify(0)(0) = "88" Then
                    '            MsgBox("Process of " & .Tables("result").DefaultView(index)("MPONo") & " (" & IIf(.Tables("result").DefaultView(index)("Grl_GrnSeq") > 3000, .Tables("result").DefaultView(index)("Grl_GrnSeq") - 3000, .Tables("result").DefaultView(index)("Grl_GrnSeq")) & ") failure!")
                    '        Else
                    '            MsgBox(rs_Modify(0)(0), , "Save Header")
                    '        End If
                    '        Cursor = Cursors.Default
                    '        Exit Sub
                    '    End If
                    '    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    'End If
                    gspStr = ""
                Next

            End With



        End If
        save_ok = True
        Call setStatus("Clear")
        MsgBox("Record Saved")
        Me.txtGRNNo.Text = Doc_No
        Cursor = Cursors.Default
    End Sub

    Private Sub setColor()

        '    If optType2.checked = True Then
        '        lblItmNo.ForeColor = &H80000012
        '        lblItmNam.ForeColor = &H80000012
        '        lblCat.ForeColor = &H80000012
        '        lblCountry.ForeColor = &H80000012
        '        lblCTN.ForeColor = &H80000012
        '        lblGW.ForeColor = &H80000012
        '        lblNW.ForeColor = &H80000012
        '        lblTtlGW_D.ForeColor = &H80000012
        '        lblTtlNW_D.ForeColor = &H80000012
        '        Exit Sub
        '    End If
        '
        '    If optType0.checked = True Then
        '        lblMPONo.ForeColor = &H80000008
        '        lblDtl.ForeColor = &H80000008
        '    End If
        '
        '    lblItmNo.ForeColor = &H80000008
        '    lblItmNo.Refresh
        '    lblItmNam.ForeColor = &H80000008
        '    lblCat.ForeColor = vbGreen '&H80000008
        '    lblCountry.ForeColor = &H80000008
        '    lblCTN.ForeColor = &H80000012
        '    lblGW.ForeColor = &H80000008
        '    lblNW.ForeColor = vbDarkGreen
        '    lblTtlGW_D.ForeColor = "H80000008"
        '    lblTtlNW_D.ForeColor = &H80000008

    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSearch.Click

        Dim frmSYM00018 As New SYM00018


        '20130909  
        gsCompany = ""
        'tempz
        Call Update_gs_Value(gsCompany)


        frmSYM00018.keyName = txtGRNNo.Name
        frmSYM00018.strModule = "GT"

        frmSYM00018.show_frmSYM00018(Me)




        '        gsSearchKey = ""

        '        gsCompany = "UCPP"
        '        Call Update_gs_Value(gsCompany)

        '        On Error GoTo err_Handle_Search_Fail
        '        frmSYM00018.keyName = txtPONo.Name
        '        frmSYM00018.strModule = "MP"

        '        frmSYM00018.show_frmSYM00018(Me)


        '        Me.txtGRNNo.Text = gsSearchKey
        '        gsSearchKey = ""
        '        txtGRNNo.SelectionStart = 0
        '        txtGRNNo.SelectionLength = Len(txtGRNNo.Text)

        '        If txtGRNNo.Text <> "" Then
        '            'Timer1.Enabled = True
        '        End If

        '        Exit Sub
        'err_Handle_Search_Fail:
        '        Err.Clear()

    End Sub

    Private Sub cmdSearch_Click()
    End Sub


    Private Sub MPM00002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right
        MPR03_right_local = getEnquiryRightByFormName(MPR00003.Name.ToString)
        Dim v

        If gsUsrGrp = "CST-G1" Then
            optType1.Checked = True
            optType0.Checked = False
            optType2.Checked = False

            optType0.Enabled = False
            optType1.Enabled = False
            optType2.Enabled = False
            '20151110
        End If

        '#If useMTS Then
        '        Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If

        Cursor = Cursors.WaitCursor
        Me.KeyPreview = True

        '        Me.'Timer1.Enabled = False   '2006-04-28

        '2006-03-20
        Me.txtCtrNo.MaxLength = 30
        Me.txtDlvDat.Text = Format(Date.Today, "MM/dd/yyyy").ToString



        strMode = ""



        '1. Custom Factory and Letter Head
        '2. Desctination
        '3. Custom Category
        '4. Country

        gspStr = "sp_list_MPM00002  '','LH','" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMPFTY, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_list_MPM00002  :" & rtnStr)
            Exit Sub
        End If
        gspStr = "sp_list_MPM00002  '','DEST','" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_DEST, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_list_MPM00002  :" & rtnStr)
            Exit Sub
        End If
        gspStr = "sp_list_MPM00002  '','CUSTCAT','" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUSTCAT, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_list_MPM00002  :" & rtnStr)
            Exit Sub
        End If
        gspStr = "sp_list_MPM00002  '','DROPDOWN','" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_DROPDOWN, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_list_MPM00002  :" & rtnStr)
            Exit Sub
        End If
        gspStr = "sp_list_MPM00002  '','CURR','" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CURR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_list_MPM00002  :" & rtnStr)
            Exit Sub
        End If
        'tempz


        'gspStr = "MPM00002','L','LH" & _
        '    "㊣MPM00002','L','DEST" & _
        '    "㊣MPM00002','L','CUSTCAT" & _
        '    "㊣MPM00002','L','DROPDOWN" & _
        '    "㊣MPM00002','L','CURR"

        ''        Cursor = Cursors.WaitCursor
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        '' If rs(0)(0) <> "0" Then  '*** An error has occured
        '' MsgBox(rs(0)(0))
        ''Else
        'rs_IMPFTY = rs(1)
        'rs_DEST = rs(2)
        'rs_CUSTCAT = rs(3)
        'rs_DROPDOWN = rs(4)
        'rs_CURR = rs(5)

        Me.cboImpFty.Items.Clear()
        If Not rs_IMPFTY.Tables("result") Is Nothing Then
            With rs_IMPFTY
                If .Tables("result").Rows.Count > 0 Then
                    For index As Integer = 0 To rs_IMPFTY.Tables("RESULT").Rows.Count - 1
                        cboImpFty.Items.Add(rs_IMPFTY.Tables("RESULT").Rows(index)("_CustFty"))
                    Next
                End If
            End With
        End If


        Me.cboDest.Items.Clear()
        If Not rs_DEST.Tables("result") Is Nothing Then
            With rs_DEST
                If .Tables("result").Rows.Count > 0 Then
                    For index As Integer = 0 To rs_DEST.Tables("RESULT").Rows.Count - 1
                        cboDest.Items.Add(rs_DEST.Tables("RESULT").Rows(index)("ShpPlc"))
                    Next
                End If
            End With
        End If

        Me.cboCat.Items.Clear()
        If Not rs_CUSTCAT.Tables("result") Is Nothing Then
            With rs_CUSTCAT
                If .Tables("result").Rows.Count > 0 Then
                    For index As Integer = 0 To rs_CUSTCAT.Tables("RESULT").Rows.Count - 1
                        cboCat.Items.Add(rs_CUSTCAT.Tables("RESULT").Rows(index)("CustCat"))
                    Next
                End If
            End With
        End If

        Me.cboCountry.Items.Clear()
        Me.cboTtlCTN_D_UM.Items.Clear()
        Me.cboCar.Items.Clear()
        Me.cboCustUM_H.Items.Clear()
        Me.cboInvUM_H.Items.Clear()

        If Not rs_DROPDOWN.Tables("result") Is Nothing Then
            With rs_DROPDOWN
                'Country Dropdown list
                .Tables("result").DefaultView.RowFilter = "_type = '_Cty'"
                If .Tables("result").DefaultView.Count > 0 Then
                    For index As Integer = 0 To rs_DROPDOWN.Tables("RESULT").DefaultView.Count - 1
                        cboCountry.Items.Add(rs_DROPDOWN.Tables("RESULT").DefaultView(index)("_Value"))
                    Next
                End If

                .Tables("result").DefaultView.RowFilter = ""
                'Carton Dropdown list
                Me.cboCustUM_H.Items.Add("散")
                Me.cboInvUM_H.Items.Add("散")
                .Tables("result").DefaultView.RowFilter = "_type = '_UM'"
                If .Tables("result").DefaultView.Count > 0 Then
                    For index As Integer = 0 To rs_DROPDOWN.Tables("RESULT").DefaultView.Count - 1
                        cboTtlCTN_D_UM.Items.Add(rs_DROPDOWN.Tables("RESULT").DefaultView(index)("_Value"))
                        cboCustUM_H.Items.Add(rs_DROPDOWN.Tables("RESULT").DefaultView(index)("_Value"))
                        cboInvUM_H.Items.Add(rs_DROPDOWN.Tables("RESULT").DefaultView(index)("_Value"))
                    Next
                End If

                CboCustUM.Items.Clear()
                .Tables("result").DefaultView.RowFilter = "_type = '_UM2'"
                If .Tables("result").DefaultView.Count > 0 Then
                    For index As Integer = 0 To rs_DROPDOWN.Tables("RESULT").DefaultView.Count - 1
                        CboCustUM.Items.Add(rs_DROPDOWN.Tables("RESULT").DefaultView(index)("_Value"))
                    Next
                End If

                .Tables("result").DefaultView.RowFilter = ""
                'Transport Dropdown list
                .Tables("result").DefaultView.RowFilter = "_type = '_CAR'"
                If .Tables("result").DefaultView.Count > 0 Then
                    For index As Integer = 0 To rs_DROPDOWN.Tables("RESULT").DefaultView.Count - 1
                        cboCar.Items.Add(rs_DROPDOWN.Tables("RESULT").DefaultView(index)("_Value"))
                    Next
                End If

            End With
        End If

        dblExchange = 0
        Me.cboCurr.Items.Clear()
        If Not rs_CURR.Tables("result") Is Nothing Then
            With rs_CURR
                If .Tables("result").Rows.Count > 0 Then

                    For index As Integer = 0 To rs_CURR.Tables("RESULT").Rows.Count - 1
                        cboCurr.Items.Add(rs_CURR.Tables("RESULT").Rows(index)("_val"))
                        If rs_CURR.Tables("RESULT").Rows(index)("_val") = "HKD" Then
                            dblExchange = rs_CURR.Tables("RESULT").Rows(index)("_exchange")
                        End If
                    Next

                End If
            End With
        End If


        '  End If


        strCurrGBL = "HKD"
        Call createGroup()

        Cursor = Cursors.Default



        Call setStatus("Init")
        Call Formstartup(Me.Name)   'Set the form Sartup position
        Cursor = Cursors.Default
    End Sub

    '
    Private Sub setStatus(ByVal opt As String)
        Dim bolEnable As Boolean

        '    strMode = opt
        Select Case opt
            Case "Init"
                readingindex = 0
                txtTrdCty.Text = ""
                txtColor.Text = ""

                flag_optType0_Click = False
                flag_optType1_Click = False
                flag_optType2_Click = False

                readingindex = 0
                mmdAdd.Enabled = Enq_right_local
                mmdSave.Enabled = False
                mmdDelete.Enabled = False
                mmdCopy.Enabled = False
                mmdFind.Enabled = True
                mmdClear.Enabled = False

                mmdSearch.Enabled = True

                mmdInsRow.Enabled = False
                mmdDelRow.Enabled = False


                mmdPrint.Enabled = False
                tsiMPR03.Enabled = False
                mmdAttach.Enabled = False
                mmdFunction.Enabled = False
                mmdLink.Enabled = False
                '            cmdfirstD.Enabled = False
                '            cmdlastD.Enabled = False
                cmdNextD.Enabled = False
                cmdPrvD.Enabled = False

                mmdExit.Enabled = True

                Me.cboImpFty.Enabled = False
                Me.cboDest.Enabled = False

                bolDisplay = True
                Me.btcMPM00002.SelectedIndex = 0
                Me.btcMPM00002.Enabled = False
                bolDisplay = False

                Me.txtSeq.ReadOnly = True

                '                Me.txtTtlGW_D.Enabled = False
                '               Me.txtTtlGW_D_UM.Enabled = False
                '              Me.txtTtlNW_D.Enabled = False
                '             Me.txtTtlNW_D_UM.Enabled = False

                Me.optType0.Checked = True
                Me.cboCurr.Text = "HKD"
                Me.txtCustQty.Text = ""
                txtCustSubTtl.Text = "0"
                Me.CboCustUM.Text = ""
                Me.cboCurr.Enabled = False
                Me.StatusBar.Panels(1).Text = ""
            Case "Add"
                mmdAdd.Enabled = False
                mmdFind.Enabled = False
                'CmdSave.Enabled = True
                mmdSave.Enabled = Enq_right_local
                mmdClear.Enabled = True

                mmdSearch.Enabled = False

                'cmdInsRow.Enabled = True
                'cmdDelRow.Enabled = True
                mmdInsRow.Enabled = Enq_right_local     '2006-03-18
                mmdDelRow.Enabled = Del_right_local

                '            cmdfirstD.Enabled = True
                '            cmdlastD.Enabled = True
                cmdNextD.Enabled = True
                cmdPrvD.Enabled = True

                Me.txtGRNNo.Text = ""
                Me.txtGRNNo.Enabled = False
                Me.cboImpFty.Enabled = False
                'Me.cboDest.Enabled = False

                Me.txtImpFtyAddr.Enabled = True
                Me.txtDestAddr.Enabled = True
                Me.txtAgtNo.Enabled = True
                Me.txtTrdCty.Enabled = True
                Me.cboCar.Enabled = True
                Me.cboCustUM_H.Enabled = True
                Me.cboInvUM_H.Enabled = True

                '2006-03-20
                Me.txtCtrNo.Enabled = True
                Me.txtDlvDat.Enabled = True

                Me.cboMPONo.Enabled = False
                Me.cboDtl.Enabled = False

                Call enableOptType(False)
                bolDisplay = True
                btcMPM00002.SelectedIndex = 0
                btcMPM00002.Enabled = True
                bolDisplay = False
            Case "Update"
                mmdAdd.Enabled = False
                mmdFind.Enabled = False
                'CmdSave.Enabled = IIf(strMode = "ACT", True, False)
                mmdSave.Enabled = IIf(strMode = "ACT", Enq_right_local, False)

                mmdClear.Enabled = True

                mmdSearch.Enabled = False

                mmdPrint.Enabled = MPR03_right_local
                tsiMPR03.Enabled = MPR03_right_local
                'cmdInsRow.Enabled = True
                'cmdDelRow.Enabled = True
                mmdInsRow.Enabled = Enq_right_local     '2006-03-18
                mmdDelRow.Enabled = Del_right_local

                '            cmdfirstD.Enabled = True
                '            cmdlastD.Enabled = True
                cmdNextD.Enabled = True
                cmdPrvD.Enabled = True

                Me.txtGRNNo.Enabled = False
                Me.cboImpFty.Enabled = False
                Me.cboDest.Enabled = True

                Me.txtImpFtyAddr.Enabled = True
                Me.txtDestAddr.Enabled = True
                Me.txtAgtNo.Enabled = True
                Me.txtTrdCty.Enabled = True
                Me.cboCar.Enabled = True
                Me.cboCustUM_H.Enabled = True
                Me.cboInvUM_H.Enabled = True
                '2006-03-20
                Me.txtCtrNo.Enabled = True
                Me.txtDlvDat.Enabled = True

                bolDisplay = True
                Me.btcMPM00002.SelectedIndex = 0
                btcMPM00002.Enabled = True
                bolDisplay = False
            Case "Clear"
                'CmdAdd.Enabled = True
                '2006-04-22
                readingindex = 0
                txtTrdCty.Text = ""
                txtColor.Text = ""

                mmdAdd.Enabled = Enq_right_local
                mmdSave.Enabled = False
                mmdFind.Enabled = True
                mmdClear.Enabled = False

                mmdSearch.Enabled = True

                mmdInsRow.Enabled = False
                mmdDelRow.Enabled = False

                '            cmdfirstD.Enabled = False
                '            cmdlastD.Enabled = False
                cmdNextD.Enabled = False
                cmdPrvD.Enabled = False

                Me.txtGRNNo.Enabled = True
                '            Me.cboImpFty.Enabled = True
                '            Me.cboDest.Enabled = True

                Me.cboImpFty.Enabled = False
                Me.cboDest.Enabled = False
                Me.cboCurr.Text = "HKD"
                Me.txtCustQty.Text = ""
                txtCustSubTtl.Text = ""
                Me.CboCustUM.Text = ""
                txtCustSubTtl.Text = ""
                Call clearHeader()
                Call clearDetail("ALL")
                Call clearTop()
                bolDisplay = True
                btcMPM00002.SelectedIndex = 0
                btcMPM00002.Enabled = False
                bolDisplay = False
                Me.optType0.Checked = True
                '2005-10-18
                Call CumulativeQty_clear()
                rs_MPORDDTL_lst = Nothing  'Detail list of selected MPO No
                rs_MPORDDTL_dtl = Nothing  'Detail info of selected item no

                rs_GRNTRFHDR = Nothing    'Store data of MPM00002 header
                rs_GRNTRFDTL = Nothing    'Store data of MPM00002 detail
                rs_GRNTRFLST = Nothing    'Store data of MPM00002 detail
                rs_Group = Nothing

                If gsUsrGrp = "CST-G1" Then
                    optType1.Checked = True
                    optType0.Checked = False
                    optType2.Checked = False

                    optType0.Enabled = False
                    optType1.Enabled = False
                    optType2.Enabled = False
                    '20151110
                End If

            Case "Display"
                mmdAdd.Enabled = False
                mmdFind.Enabled = False
                mmdSave.Enabled = False
                mmdClear.Enabled = True

                mmdSearch.Enabled = False

                mmdInsRow.Enabled = False
                mmdDelRow.Enabled = False

                cmdNextD.Enabled = True
                cmdPrvD.Enabled = True


                Me.txtGRNNo.Enabled = False
                Me.cboImpFty.Enabled = False
                Me.cboDest.Enabled = False

                Me.txtImpFtyAddr.Enabled = False
                Me.txtDestAddr.Enabled = False
                Me.txtAgtNo.Enabled = False
                Me.txtTrdCty.Enabled = False
                Me.cboCar.Enabled = False
                Me.cboCustUM_H.Enabled = False
                Me.cboInvUM_H.Enabled = False
                Me.mmdPrint.Enabled = MPR03_right_local
                Me.tsiMPR03.Enabled = MPR03_right_local
                '2006-03-20
                Me.txtCtrNo.Enabled = False
                Me.txtDlvDat.Enabled = False

                bolDisplay = True
                Me.btcMPM00002.SelectedIndex = 0
                btcMPM00002.Enabled = True
                bolDisplay = False
            Case "Add_Dtl"
                bolEnable = True

                Call enableOptType(bolEnable)

                Me.optType0.Checked = True

                Me.cboMPONo.Enabled = bolEnable
                Me.cboDtl.Enabled = bolEnable

                Me.txtColor.Enabled = bolEnable
                Me.cboCat.Enabled = bolEnable
                Me.cboCountry.Enabled = bolEnable

                Me.txtCTNFm.Enabled = bolEnable
                Me.txtCTNTo.Enabled = bolEnable
                Me.txtTtlCTN_D.Enabled = bolEnable
                Me.cboTtlCTN_D_UM.Enabled = bolEnable
                Me.txtGW.Enabled = bolEnable
                Me.txtGW_UM.Enabled = bolEnable
                Me.txtNW.Enabled = bolEnable
                Me.txtNW_UM.Enabled = bolEnable
                '            Me.txtTtlGW_D.Enabled = bolEnable
                '            Me.txtTtlGW_D_UM.Enabled = bolEnable
                '            Me.txtTtlNW_D.Enabled = bolEnable
                '            Me.txtTtlNW_D_UM.Enabled = bolEnable
                Me.txtPck.Enabled = bolEnable
                Me.txtPck_UM.Enabled = bolEnable
                Me.txtDtlRmk.Enabled = bolEnable        '2005-10-14
                Me.txtPONo.Enabled = bolEnable
                Me.grdDtlLst.Enabled = bolEnable

                Me.cboGroup.Enabled = bolEnable

                Me.txtShpQty.Enabled = bolEnable
                '  Me.txtShpUM.Enabled = bolEnable
                'Me.txtSubTtl.Enabled = bolEnable
                Me.cboCurr.Enabled = bolEnable
                Me.txtUntPrc.Enabled = bolEnable

                Me.txtDept.Enabled = bolEnable
                'Me.chkDelete.Enabled = bolEnable
                '2006-04-22
                Me.chkDelete.Enabled = Del_right_local
                bolDisplay = True
                Me.chkDelete.Checked = False
                bolDisplay = False
            Case "Delete_Dtl"
                Call setStatus("Display_Dtl")
                'Me.chkDelete.Enabled = True
                '2006-04-22
                Me.chkDelete.Enabled = Del_right_local
            Case "Update_Dtl"
                bolEnable = True
                Call enableOptType(Not bolEnable)

                Me.cboMPONo.Enabled = Not bolEnable
                Me.cboDtl.Enabled = Not bolEnable
                Me.txtItmNo.Enabled = bolEnable
                Me.txtColor.Enabled = bolEnable
                Me.txtItmNam.Enabled = bolEnable
                'Me.txtItmDesc.Enabled = bolEnable
                Me.cboCat.Enabled = bolEnable
                Me.cboCountry.Enabled = bolEnable

                Me.txtCTNFm.Enabled = bolEnable
                Me.txtCTNTo.Enabled = bolEnable
                Me.txtTtlCTN_D.Enabled = bolEnable
                Me.cboTtlCTN_D_UM.Enabled = bolEnable
                Me.txtGW.Enabled = bolEnable
                Me.txtGW_UM.Enabled = bolEnable
                Me.txtNW.Enabled = bolEnable
                Me.txtNW_UM.Enabled = bolEnable
                '            Me.txtTtlGW_D.Enabled = bolEnable
                '            Me.txtTtlGW_D_UM.Enabled = bolEnable
                '            Me.txtTtlNW_D.Enabled = bolEnable
                '            Me.txtTtlNW_D_UM.Enabled = bolEnable
                Me.txtPck.Enabled = bolEnable
                Me.txtPck_UM.Enabled = bolEnable
                Me.cboGroup.Enabled = bolEnable
                Me.txtDtlRmk.Enabled = bolEnable        '2005-10-14
                Me.txtPONo.Enabled = bolEnable
                Me.grdDtlLst.Enabled = bolEnable
                Me.txtShpQty.Enabled = bolEnable

                Me.txtShpUM.Enabled = bolEnable
                'Me.txtSubTtl.Enabled = bolEnable

                Me.cboCurr.Enabled = bolEnable
                Me.txtUntPrc.Enabled = bolEnable
                If Me.optType0.Checked = True Then
                    Me.txtDept.Enabled = False
                Else
                    Me.txtDept.Enabled = bolEnable
                End If
                'Me.chkDelete.Enabled = bolEnable
                '2006-04-22
                Me.chkDelete.Enabled = Del_right_local

            Case "Display_Dtl"
                bolEnable = False

                Call enableOptType(bolEnable)

                Me.cboMPONo.Enabled = bolEnable
                Me.cboDtl.Enabled = bolEnable

                Me.txtItmNo.Enabled = bolEnable
                Me.txtColor.Enabled = bolEnable
                Me.txtItmNam.Enabled = bolEnable
                'Me.txtItmDesc.Enabled = bolEnable
                Me.cboCat.Enabled = bolEnable
                Me.cboCountry.Enabled = bolEnable
                Me.txtDept.Enabled = bolEnable

                Me.txtCTNFm.Enabled = bolEnable
                Me.txtCTNTo.Enabled = bolEnable
                Me.txtTtlCTN_D.Enabled = bolEnable
                Me.cboTtlCTN_D_UM.Enabled = bolEnable
                Me.txtGW.Enabled = bolEnable
                Me.txtGW_UM.Enabled = bolEnable
                Me.txtNW.Enabled = bolEnable
                Me.txtNW_UM.Enabled = bolEnable
                '            Me.txtTtlGW_D.Enabled = bolEnable
                '            Me.txtTtlGW_D_UM.Enabled = bolEnable
                '            Me.txtTtlNW_D.Enabled = bolEnable
                '            Me.txtTtlNW_D_UM.Enabled = bolEnable
                Me.txtPck.Enabled = bolEnable
                Me.txtPck_UM.Enabled = bolEnable
                Me.txtDtlRmk.Enabled = bolEnable        '2005-10-14
                Me.txtPONo.Enabled = bolEnable
                Me.cboGroup.Enabled = bolEnable

                'Me.grdDtlLst.Enabled = bolEnable
                Me.txtQty.Enabled = bolEnable
                Me.txtOSQty.Enabled = bolEnable
                Me.txtShpQty.Enabled = bolEnable
                Me.txtShpUM.Enabled = bolEnable
                'Me.txtSubTtl.Enabled = bolEnable
                'Me.cboCurr.Enabled = bolEnable
                Me.txtUntPrc.Enabled = bolEnable
                'Me.txtMinPrc.Enabled = bolEnable

                Me.txtDept.Enabled = bolEnable
                Me.chkDelete.Enabled = False

        End Select
    End Sub

    Private Sub MPM00002_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim YNC As Integer
        If IsUpdated() Then
            YNC = MsgBox("Record updated!" & vbCrLf & "Save before exit?", vbYesNoCancel + vbDefaultButton1 + vbQuestion, "")
            If YNC = vbYes Then
                '2006-03-18
                If Enq_right_local Then
                    save_ok = False
                    Call CmdSaveClick()
                    If save_ok = False Then
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    MsgBox("You do not have rights to save!" & vbCrLf & "Program will exit without save.", vbInformation + vbOKOnly)
                End If
            ElseIf YNC = vbCancel Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        rs_MPORDDTL_lst = Nothing  'Detail list of selected MPO No
        rs_MPORDDTL_dtl = Nothing  'Detail info of selected item no

        rs_GRNTRFHDR = Nothing    'Store data of MPM00002 header
        rs_GRNTRFDTL = Nothing    'Store data of MPM00002 detail
        rs_GRNTRFLST = Nothing    'Store data of MPM00002 detail
        rs_Group = Nothing

        e.Cancel = False

    End Sub


    Private Sub grdDtlLst_AfterColUpdate(ByVal ColIndex As Integer)
        Dim shpqty As Double
        Dim subttl As Double
        If bolDisplay = True Then Exit Sub
        If ColIndex = colShpQty Then
            Call UpdateGrid()
            Call Grid_CalSubTtl()
        End If
    End Sub

    Private Sub grdDtlLst_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdDtlLst.DataError
        '        Response = 0

    End Sub

    'Private Sub grdDtlLst_Error(ByVal DataError As Integer, ByVal Response As Integer)
    '    Response = 0
    'End Sub
    Private Sub grdDtlLst_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDtlLst.GotFocus
        Call freelock()
    End Sub

    'Private Sub grdDtlLst_GotFocus()

    '    Call freelock()
    'End Sub


    Private Sub grdDtlLst_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDtlLst.EditingControlShowing

        gi_dgselstart = CType(e.Control, TextBox).SelectionStart

        Dim txtEdit As TextBox = e.Control
        'remove any existing handler
        RemoveHandler txtEdit.KeyPress, AddressOf txtEdit_Keypress
        AddHandler txtEdit.KeyPress, AddressOf txtEdit_Keypress

    End Sub
    Private Sub txtEdit_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)


        '        Console.WriteLine("KeyPress " & e.KeyChar.ToString())
        'Test for numeric value or backspace in first column
        'If grdDtlLst.CurrentCell.ColumnIndex = colShpQty Then
        '    If IsNumeric(e.KeyChar.ToString()) _
        '    Or e.KeyChar = ChrW(Keys.Back) _
        '    Or e.KeyChar = "." Then
        '        'Console.WriteLine("KeyPress number")
        '        e.Handled = False 'if numeric display 
        '    Else
        '        'Console.WriteLine("Enter Numbers Only")
        '        e.Handled = True  'if non numeric don't display
        '    End If
        'End If

        If grdDtlLst.CurrentCell.ColumnIndex = colShpQty Then
            'If e.KeyChar <> Chr(9) And e.KeyChar <> Chr(8) And InStr("1234567890", e.KeyChar) <= 0 Then
            '    e.KeyChar = Chr(0)
            'End If

            '            e.KeyChar = Chr(check_numeric_size(txtShpQty.Text, Asc(e.KeyChar), txtShpQty.SelectionStart, 9, 2))
            e.KeyChar = Chr(check_numeric_size(sender.text, Asc(e.KeyChar), sender.selectionstart, 9, 2))

        ElseIf grdDtlLst.CurrentCell.ColumnIndex = colDtlRmk Then
            '2005-10-14, Check Detail Remark not more than 300 characters
            If e.KeyChar <> Chr(9) And e.KeyChar <> Chr(8) And Len(sender.text) >= 300 Then
                e.KeyChar = Chr(0)
            End If
        End If
        '    If CLng(grdDtlLst.SelectedColumns.ToString) = colShpQty Then
        '        '        If e.KeyChar <> 9 And e.KeyChar <> 8 And InStr("1234567890", e.KeyChar) <= 0 Then
        '        '            e.KeyChar = Chr(0)
        '        '        End If

        '        e.KeyChar = check_numeric_size(grdDtlLst.Columns(CLng(grdDtlLst.SelectedColumns.ToString)), Asc(e.KeyChar), gi_dgselstart, 9, 2)
        '    ElseIf grdDtlLst.SelectedColumns = colDtlRmk Then
        '        '2005-10-14, Check Detail Remark not more than 300 characters
        '        If e.KeyChar <> Chr(9) And e.KeyChar <> Chr(8) And Len(grdDtlLst.Columns(colDtlRmk).Value) >= 300 Then
        '            e.KeyChar = Chr(0)
        '        End If
        '    End If


    End Sub
    'Private Sub grdDtlLst_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdDtlLst.KeyPress
    '    If CLng(grdDtlLst.SelectedColumns.ToString) = colShpQty Then
    '        '        If e.KeyChar <> 9 And e.KeyChar <> 8 And InStr("1234567890", e.KeyChar) <= 0 Then
    '        '            e.KeyChar = Chr(0)
    '        '        End If

    '        e.KeyChar = check_numeric_size(grdDtlLst.Columns(CLng(grdDtlLst.SelectedColumns.ToString)), Asc(e.KeyChar), gi_dgselstart, 9, 2)
    '    ElseIf grdDtlLst.SelectedColumns = colDtlRmk Then
    '        '2005-10-14, Check Detail Remark not more than 300 characters
    '        If e.KeyChar <> Chr(9) And e.KeyChar <> Chr(8) And Len(grdDtlLst.Columns(colDtlRmk).Value) >= 300 Then
    '            e.KeyChar = Chr(0)
    '        End If
    '    End If

    'End Sub
    'Private Sub grdDtlLst_KeyPress(ByVal Asc(e.KeyChar) As Integer)
    'End Sub

    Private Sub grdDtlLst_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDtlLst.CurrentCellChanged
        Call freelock()
    End Sub
    'Private Sub grdDtlLst_RowColChange(ByVal LastRow As Object, ByVal LastCol As Integer)
    '    Call freelock()
    'End Sub


    Private Sub grdSummary_Error(ByVal DataError As Integer, ByVal Response As Integer)
        '    MsgBox DataError & " " & Response
        '    Dim i As Integer
        '    Dim j As Integer
        '    on error  GoTo err_handle
        '    rs_GRNTRFDTL.MoveFirst
        '    For i = 0 To rs_GRNTRFDTL.tables("result").rows.count - 1
        '        For j = 0 To rs_GRNTRFDTL.Fields.count - 1
        '            'Debug.Print i & " : " & j & rs_GRNTRFDTL.Fields(j).Name & " : " & IIf(IsDBNull(rs_GRNTRFDTL.Fields(j).value), "NULL", rs_GRNTRFDTL.Fields(j).value) & "<"
        '            Debug.Print "rs_GRNTRFDTL.Field(""" & rs_GRNTRFDTL.Fields(j).Name & """) = null" & vbCrLf; "debug.print """ & rs_GRNTRFDTL.Fields(j).Name & """"
        '        Next
        '        rs_GRNTRFDTL.MoveNext
        '    Next
        'err_handle:
        '    MsgBox Err.Description
        'Err.Clear
    End Sub

    Private Sub grdSummary_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSummary.CellClick

        Dim grdseq As Integer


        'If e.RowIndex >= 0 Then
        '    isSorting = False
        '    dr = rs_GRNTRFDTL.Tables("RESULT").Select("", "Grd_Seq")

        '    For index As Integer = 0 To dr.Length - 1
        '        If rs_GRNTRFDTL.Tables("RESULT").DefaultView(e.RowIndex)("Grd_Seq") = dr(index)("Grd_Seq") Then
        '            readingindex = index
        '        End If
        '    Next
        'Else
        '    isSorting = True
        'End If

        '''***)
        If e.RowIndex >= 0 And e.ColumnIndex = 0 Then
            If Me.chkDelete.Enabled = True Then

                Recordstatus = True

                If grdSummary.Columns(e.ColumnIndex).ReadOnly = False Then
                    If rs_GRNTRFDTL.Tables("RESULT").DefaultView(e.RowIndex)("Del").ToString = "Y" Then
                        rs_GRNTRFDTL.Tables("RESULT").DefaultView(e.RowIndex)("Del") = "N"

                        If rs_GRNTRFDTL.Tables("RESULT").Rows(e.RowIndex).Item("Grd_creusr") <> "~*ADD*~" And rs_GRNTRFDTL.Tables("RESULT").Rows(e.RowIndex).Item("Grd_creusr") <> "~*NEW*~" Then
                            rs_GRNTRFDTL.Tables("RESULT").Rows(e.RowIndex).Item("Grd_creusr") = "~*UPD*~"
                        End If

                        chkDelete.Checked = False
                    Else
                        rs_GRNTRFDTL.Tables("RESULT").DefaultView(e.RowIndex)("Del") = "Y"
                        rs_GRNTRFDTL.Tables("RESULT").DefaultView(e.RowIndex)("Grd_creusr") = "~*DEL*~"

                        chkDelete.Checked = True
                    End If
                    rs_GRNTRFDTL.Tables("RESULT").AcceptChanges()
                End If
            End If
        End If



        ''reset detail page
        grdseq = grdSummary.Item(3, grdSummary.CurrentCell.RowIndex).Value

        For i As Integer = 0 To rs_GRNTRFDTL.Tables("RESULT").Rows.Count - 1
            ''bug
            If Not IsDBNull(rs_GRNTRFDTL.Tables("RESULT").Rows(i).Item("Grd_Seq")) Then

                If grdseq = rs_GRNTRFDTL.Tables("RESULT").Rows(i).Item("Grd_Seq") Then
                    readingindex = i
                End If
            End If

        Next i

        If rs_GRNTRFDTL.Tables("RESULT").Rows.Count > readingindex Then

            '''20140304 may same itmno 
            '            If txtItmNo.Text.Trim <> rs_GRNTRFDTL.Tables("RESULT").Rows(ReadingIndex)("Grd_itmno").ToString.Trim Then
            '''''''''''''    txtItmNo.Text = rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_itmno").ToString.Trim
            Call DisplayDetail()
            ''Call txtItmNo_Press()
            'End If
        End If


        '''''''''''        Call DeleteClickCheck()

    End Sub
    Private Sub grdSummary_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdSummary.ColumnHeaderMouseClick

        Dim seq As Integer
        On Error GoTo err_Handle_Sort
        seq = 0
        If Me.txtSeq.Text <> "" Then seq = CInt(Me.txtSeq.Text)

        If Not rs_GRNTRFDTL Is Nothing Then
            With rs_GRNTRFDTL
                If e.ColumnIndex = ColSeq Then
                    .Tables("result").DefaultView.Sort = "Grd_Seq"
                ElseIf e.ColumnIndex = colGroup Then
                    .Tables("result").DefaultView.Sort = "Grd_Grp"
                ElseIf e.ColumnIndex = colItmNo Then
                    .Tables("result").DefaultView.Sort = "Grd_ItmNo,Grd_CTNFm"
                ElseIf e.ColumnIndex = colItmName Then
                    .Tables("result").DefaultView.Sort = "Grd_ItmNam,Grd_CTNFm"
                ElseIf e.ColumnIndex = colType Then
                    .Tables("result").DefaultView.Sort = "Grd_Type,Grd_ItmNo,Grd_CTNFm"
                ElseIf e.ColumnIndex = colCTNFm Then
                    .Tables("result").DefaultView.Sort = "Grd_CTNFm"
                ElseIf e.ColumnIndex = colCustCat Then
                    .Tables("result").DefaultView.Sort = "Grd_CustCat"
                End If
            End With
        End If

        If seq > 0 Then rs_GRNTRFDTL.Tables("result").DefaultView.RowFilter = ("Grd_Seq=" & seq)

        Exit Sub
err_Handle_Sort:
        MsgBox(Err.Number & " - " & Err.Description, vbCritical, "Error")
        Err.Clear()

    End Sub


    'Private Sub grdSummary_HeadClick(ByVal ColIndex As Integer)
    'End Sub



    Private Sub grdSummary_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSummary.CurrentCellChanged
        Call showStatusBar()
    End Sub
    'Private Sub grdSummary_RowColChange(ByVal LastRow As Object, ByVal LastCol As Integer)
    'End Sub
    'goto

    Private Sub optType_Click(ByVal Index As Integer)
        Call setColor()
        If bolDisplay = True Then Exit Sub
        Call clearDetail()
        If Index = stsMPO Then
            Me.cboMPONo.Enabled = True
            Me.cboDtl.Enabled = True
            '            Me.txtShpUM.Enabled = False
            'Me.txtShpUM.ReadOnly = True
            'Me.cboCurr.Enabled = False
            Me.txtItmNo.Enabled = True
            '  Me.txtItmNo.ReadOnly = True
            'Me.txtUntPrc.Enabled = False
            lblPONo.Visible = False
            Me.txtPONo.Visible = False
            '2005-10-14
            lblDtlRmk.Visible = False
            txtDtlRmk.Visible = False

            txtDept.Enabled = False

            ' Added by Mark Lau 20090617
            SetMPO("")
            'Lester Wu
            Call cboMPONo_Click()
        ElseIf Index = stsAdHoc Then

            ' Rem by Mark Lau 20090616
            'Me.cboMPONo.Enabled = False
            'Me.cboDtl.Enabled = False
            'Me.cboMPONo.Text = ""
            'Me.cboDtl.Text = ""


            'Me.cboCurr.Enabled = True
            Me.txtShpUM.Enabled = True
            Me.txtShpUM.ReadOnly = False
            Me.txtItmNo.Enabled = True
            Me.txtItmNo.ReadOnly = False
            'Me.txtUntPrc.Enabled = True
            txtDept.Enabled = True
            lblPONo.Visible = True
            Me.txtPONo.Visible = True
            '2005-10-14
            lblDtlRmk.Visible = True
            txtDtlRmk.Visible = True

            ' Added by Mark Lau 20090617
            SetMPO("ALL")

            Call setFocus_text(Me.txtItmNo)
        ElseIf Index = stsMisc Then
            Me.cboMPONo.Enabled = False
            Me.cboDtl.Enabled = False
            Me.cboMPONo.Text = ""
            Me.cboDtl.Text = ""
            Me.txtShpUM.Text = ""
            Me.txtShpUM.Enabled = True
            Me.txtShpUM.ReadOnly = False
            Me.txtItmNo.Enabled = True
            Me.txtItmNo.ReadOnly = False
            'Me.txtUntPrc.Enabled = True
            txtDept.Enabled = True
            lblPONo.Visible = True
            Me.txtPONo.Visible = True
            '2005-10-14
            lblDtlRmk.Visible = True
            txtDtlRmk.Visible = True
            Call setFocus_text(Me.txtItmNo)
        End If
    End Sub
    Private Sub btcMPM00002_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcMPM00002.SelectedIndexChanged
        If bolDisplay = True Then Exit Sub
        If PreviousTab = 1 Then
            If Not rs_GRNTRFDTL.Tables("result") Is Nothing Then
                If rs_GRNTRFDTL.Tables("result").Rows.Count > 0 Then

                    If checkDetail() = False Then Exit Sub
                    'check and update deatil
                    Call UpdateDetail()

                End If
            End If

        End If
        If btcMPM00002.SelectedIndex = 0 Then
            'Call Total NW, GW ...
            Call calTotalNWGW_Hdr()
            Call showStatusBar()
        ElseIf btcMPM00002.SelectedIndex = 1 Then
            'DisplayDetail
            Call moveRecord("X")

        ElseIf btcMPM00002.SelectedIndex = 2 Then
            Call DisplaySummary()
            Call showStatusBar()
        End If
        PreviousTab = btcMPM00002.SelectedIndex
        'tempzz

    End Sub

    'Private Sub SSTab1_Click(ByVal PreviousTab As Integer)

    'End Sub


    'Private Sub 'Timer1_'Timer()
    '    'Timer1.Enabled = False
    '    Call cmdFindClick()
    'End Sub
    'goto 8023
    Private Sub txtAgtNo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAgtNo.GotFocus
        Call setFocus_text(Me.txtAgtNo)
    End Sub


    'Private Sub txtAgtNo_GotFocus()
    '    Call setFocus_text(Me.txtAgtNo)
    'End Sub

    '2006-03-20
    Private Sub txtCtrNo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCtrNo.GotFocus
        Call setFocus_text(Me.txtCtrNo)
    End Sub
    'Private Sub txtCtrNo_GotFocus()
    '    Call setFocus_text(Me.txtCtrNo)
    'End Sub
    Private Sub txtCustQty_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustQty.GotFocus
        Call setFocus_text(Me.txtCustQty)
    End Sub
    'Private Sub txtCustQty_GotFocus()
    '    Call setFocus_text(Me.txtCustQty)
    'End Sub
    Private Sub txtCustQty_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCustQty.KeyPress

        e.KeyChar = Chr(check_numeric_size(txtCustQty.Text, Asc(e.KeyChar), txtCustQty.SelectionStart, 9, 2))

        Call txtCustQty_KeyPress(Asc(e.KeyChar))
    End Sub

    Private Sub txtCustQty_KeyPress(ByVal asc_value)
        Dim shpqty As Double
        Dim untprc As Double


        Dim OSQty As Double
        Dim subttl As Double
        Dim i As Integer




        If asc_value = 13 Then
            If Me.txtCustQty.Text = "" Then Exit Sub


            If optType0.Checked = True Then
                shpqty = CDbl(Me.txtCustQty.Text)
                untprc = CDbl(IIf(Trim(Me.txtUntPrc.Text) <> "", Trim(Me.txtUntPrc.Text), 2))
                subttl = shpqty * untprc
                Me.txtCustSubTtl.Text = Format(subttl, "######.#0")
            Else
                Me.txtCustSubTtl.Text = ""
                If Trim(Me.txtUntPrc.Text) <> "" And Trim(Me.txtCustQty.Text) <> "" Then
                    On Error GoTo err_Handle_not_numeric
                    Me.txtCustSubTtl.Text = round(Me.txtUntPrc.Text * Me.txtCustQty.Text, 2)
                    On Error GoTo 0
                End If
            End If
            Exit Sub
        End If

        ''  asc_value = check_numeric_size(txtCustQty.Text, asc_value, txtCustQty.SelectionStart, 9, 2)
        'tempzzzzzzzzzzzzzzzzzzzzzzzzzz

        Exit Sub
err_Handle_not_numeric:
        MsgBox("Custom Unit Price and/or Custom Qty not valid")
        Err.Clear()
    End Sub

    Private Sub txtDlvDat_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.txtDlvDat.SelectionStart = 0
        Me.txtDlvDat.SelectionLength = Me.txtDlvDat.MaxLength

    End Sub
    Private Sub cboCar_GotFocus()
        'Call setFocus_Combo(Me.cboCar)
    End Sub

    Private Sub txtColor_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtColor.GotFocus
        Call setFocus_text(Me.txtColor)
    End Sub

    Private Sub txtCTNFm_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCTNFm.GotFocus
        Call setFocus_text(Me.txtCTNFm)
    End Sub




    Private Sub initCTN()

    End Sub
    Private Sub txtCTNFm_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCTNFm.KeyPress
        If Asc(e.KeyChar) = 9 Or Asc(e.KeyChar) = 8 Or InStr("1234567890", e.KeyChar) > 0 Then Exit Sub
        e.KeyChar = Chr(0)
    End Sub

    Private Sub txtCTNTo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCTNTo.GotFocus
        Call setFocus_text(Me.txtCTNTo)
    End Sub


    Private Sub txtCTNTo_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCTNTo.KeyPress
        On Error GoTo err_Not_Integer
        If Asc(e.KeyChar) = 13 Then
            If CLng(Me.txtCTNTo.Text) >= CLng(Me.txtCTNFm.Text) Then
                Me.txtTtlCTN_D.Text = CLng(Me.txtCTNTo.Text) - CLng(Me.txtCTNFm.Text) + 1
            End If
        End If
        If Asc(e.KeyChar) = 9 Or Asc(e.KeyChar) = 8 Or InStr("1234567890", e.KeyChar) > 0 Then Exit Sub
        e.KeyChar = Chr(0)
err_Not_Integer:
        Err.Clear()

    End Sub


    Private Sub txtCTNTo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCTNTo.LostFocus
        On Error GoTo err_Handle_Not_Integer
        If CLng(Me.txtCTNFm.Text) > CLng(Me.txtCTNTo.Text) Then
            MsgBox("CTN Fm > CTN To!")
            Call setFocus_text(Me.txtCTNTo)
        Else
            Me.txtTtlCTN_D.Text = CLng(Me.txtCTNTo.Text) - CLng(Me.txtCTNFm.Text) + 1
        End If
        Exit Sub
err_Handle_Not_Integer:
        '    If Len(Trim(Me.txtCTNFm.Text)) = Len(Trim(Me.txtCTNTo.Text)) Then
        '        If Trim(Me.txtCTNFm.Text) > Trim(Me.txtCTNTo.Text) Then
        '            MsgBox "CTN Fm > CTN To!"
        '            Call setFocus_text(Me.txtCTNTo)
        '        End If
        '    End If
        Err.Clear()

    End Sub



    'Private Sub txtCustUM_KeyPress(Asc(e.KeyChar) As Integer)
    '    If e.KeyChar = vbKeyF8 And gsUsRank <= 3 Then
    '        Me.txtCustUM.ReadOnly = False
    '    End If
    'End Sub
    Private Sub CboCustUM_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboCustUM.KeyPress
        If Asc(e.KeyChar) = 119 And gsUsrRank <= 3 Then
            Me.CboCustUM.Enabled = True
        End If

    End Sub

    Private Sub txtDept_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDept.TextChanged
        Call setFocus_text(Me.txtDept)
    End Sub
    Private Sub txtGRNNo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGRNNo.GotFocus
        Call setFocus_text(Me.txtGRNNo)
    End Sub

    Private Sub txtGRNNo_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGRNNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Call mmdFindClick()
        End If

    End Sub



    Private Sub txtGW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGW.TextChanged
        If InStr(Trim(Me.txtGW.Text), ".") > 0 And Len(Trim(Me.txtGW.Text)) - InStr(Trim(Me.txtGW.Text), ".") > 4 Then
            Me.txtGW.Text = round(CDbl(IIf(Me.txtGW.Text = "", 0, Me.txtGW.Text)), 4)
        End If
    End Sub
    Private Sub txtGW_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGW.GotFocus
        Call setFocus_text(Me.txtGW)

    End Sub

    Private Sub txtGW_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGW.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Call calTotalNWGW_Dtl()
            Exit Sub
        End If

        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 9 Then Exit Sub

        If Len(Me.txtGW.Text) > 9 Then
            If InStr(Me.txtGW.Text, ".") > 0 Then
                If Len(Microsoft.VisualBasic.Left(Me.txtGW.Text, InStr(Me.txtGW.Text, "."))) > 9 Then
                    e.KeyChar = Chr(0)
                    Exit Sub
                End If
            Else
                e.KeyChar = Chr(0)
            End If
        End If

        If InStr("1234567890", e.KeyChar) > 0 Then Exit Sub
        If e.KeyChar = "." And InStr(Me.txtGW.Text, ".") <= 0 Then Exit Sub

        e.KeyChar = Chr(0)


    End Sub

    Private Sub txtGW_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGW.LostFocus
        If Trim(Me.txtGW.Text) <> "" And Trim(Me.txtNW.Text) <> "" Then
            If CDbl(Me.txtGW.Text) < CDbl(Me.txtNW.Text) Then
                Call show_detail_msg("N.W/CTN > G.W/CTN!", txtGW)
            End If
        End If

        Call calTotalNWGW_Dtl()

    End Sub

    Private Sub txtInvHdr_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInvHdr.GotFocus
        Call setFocus_text(Me.txtInvHdr)
    End Sub


    'Private Sub txtItmDesc_GotFocus()
    '    Call setFocus_text(Me.txtItmDesc)
    'End Sub
    Private Sub txtItmNam_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItmNam.GotFocus
        'Call setFocus_text(Me.txtItmNam)
        txtItmNam.Height = 90
        txtItmNam.BringToFront()

    End Sub

    Private Sub txtItmNo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItmNo.GotFocus
        Call setFocus_text(Me.txtItmNo)
    End Sub





    Private Sub txtItmNo_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItmNo.KeyPress
        'If ASC(e.KeyChar) = 13 And (Me.optType1.checked = True Or Me.optType2.checked = True) Then
        If Asc(e.KeyChar) = 13 Then
            'search item info
            'If isDuplicate = True Then Exit Sub
            '++++++++++++++++++++++++++++++++++++++++++++++++++
            'Item

            gspStr = "sp_list_MPM00002  '','ITEM','" & Trim(Me.txtItmNo.Text) & "'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading  sp_list_MPM00002  :" & rtnStr)
                Exit Sub
            Else
                If rs.Tables("result").Rows.Count > 0 Then
                    Me.txtItmNam.Text = rs.Tables("result").Rows(0)("Zil_ItmNam")
                    'Me.txtItmDesc.Text = rs.Tables("result").Rows(0)("Zil_ItmDesc")
                    Me.cboCat.Text = rs.Tables("result").Rows(0)("CustCat")
                    '2005-10-18, show customer item UM
                    'Me.txtCustUM.ReadOnly = True
                    'Me.txtCustUM.Text = rs.Tables("result").Rows(0)("Zil_CustUM")
                    '2008-02-28
                    'Me.CboCustUM.ReadOnly = True
                    Me.CboCustUM.Text = rs.Tables("result").Rows(0)("Zil_CustUM")
                Else
                    MsgBox("Item Not Found!")
                    Call setFocus_text(Me.txtItmNo)
                    Exit Sub
                End If

            End If
            '            gspStr = "MPM00002','L','ITEM','" & Trim(Me.txtItmNo.Text)
            '        Cursor = Cursors.WaitCursor
            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)


            '++++++++++++++++++++++++++++++++++++++++++++++++++
            rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Grd_MpoNo") = Trim(Me.cboMPONo.Text)
            rs_GRNTRFDTL.Tables("RESULT").Rows(readingindex)("Del") = "N"
            Call enableOptType(False)
            'If Me.txtColor.Enabled = True Then Me.txtColor.Focus
        End If

    End Sub
    'Private Sub txtitmno_KeyPress(ByVal Asc(e.KeyChar) As Integer)
    'End Sub

    Private Sub enableOptType(Optional ByVal bolEnable As Boolean = False)
        Me.optType0.Enabled = bolEnable
        Me.optType1.Enabled = bolEnable
        Me.optType2.Enabled = bolEnable
    End Sub
    Private Sub txtNW_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNW.GotFocus
        Call setFocus_text(Me.txtNW)
    End Sub

    Private Sub txtNW_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNW.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Call calTotalNWGW_Dtl()
            Exit Sub
        End If

        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 9 Then Exit Sub

        If Len(Me.txtNW.Text) > 9 Then
            If InStr(Me.txtNW.Text, ".") > 0 Then
                If Len(Microsoft.VisualBasic.Left(Me.txtNW.Text, InStr(Me.txtNW.Text, "."))) > 9 Then
                    e.KeyChar = Chr(0)
                    Exit Sub
                End If
            Else
                e.KeyChar = Chr(0)
            End If
        End If

        If InStr("1234567890", e.KeyChar) > 0 Then Exit Sub

        'If e.KeyChar = 8 Or InStr("1234567890", e.KeyChar) > 0 Then Exit Sub
        If e.KeyChar = "." And InStr(Me.txtNW.Text, ".") <= 0 Then Exit Sub

        e.KeyChar = Chr(0)
    End Sub



    Private Sub txtNW_LostFocus()
        '    If bolCheckWgt = True Then Exit Sub
        '    bolCheckWgt = False
        '    If Trim(Me.txtGW.Text) <> "" And Trim(Me.txtNW.Text) <> "" Then
        '        If CDbl(Me.txtGW.Text) < CDbl(Me.txtNW.Text) Then
        '            Call show_detail_msg("N.W/CTN > G.W/CTN!", txtNW)
        '            bolCheckWgt = True
        '        End If
        '    End If

    End Sub

    Private Sub txtPck_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPck.GotFocus
        Call setFocus_text(Me.txtPck)

    End Sub

    Private Sub txtPck_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPck.LostFocus
        change_meter()

    End Sub

    Private Sub txtPck_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPck.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 9 Then Exit Sub

        If Len(Me.txtPck.Text) > 9 Then
            If InStr(Me.txtPck.Text, ".") > 0 Then
                If Len(Microsoft.VisualBasic.Left(Me.txtPck.Text, InStr(Me.txtPck.Text, "."))) > 9 Then
                    e.KeyChar = Chr(0)
                    Exit Sub
                End If
            Else
                e.KeyChar = Chr(0)
            End If
        End If

        If InStr("1234567890", e.KeyChar) > 0 Then Exit Sub
        If e.KeyChar = "." And InStr(Me.txtPck.Text, ".") <= 0 Then Exit Sub

        e.KeyChar = Chr(0)

    End Sub
    Private Sub txtPONo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPONo.GotFocus
        Call setFocus_text(Me.txtPONo)
    End Sub


    Private Sub txtDtlRmk_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDtlRmk.GotFocus
        Call setFocus_text_rich(Me.txtDtlRmk)
    End Sub

    Private Sub txtPck_UM_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPck_UM.LostFocus
        Me.txtPck_UM.Text = UCase(Me.txtPck_UM.Text)
        change_meter()

    End Sub

    Private Sub txtShpQty_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShpQty.GotFocus
        Call setFocus_text(Me.txtShpQty)
    End Sub

    Private Sub txtShpQty_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShpQty.KeyPress
        Dim shpqty As Double
        Dim untprc As Double

        Dim remainQty As Double
        Dim OSQty As Double
        Dim subttl As Double
        Dim i As Integer

        If Asc(e.KeyChar) = 13 Then
            If Me.txtShpQty.Text = "" Then Exit Sub

            If optType0.Checked = True Or optType1.Checked = True Then
                OSQty = 0
                shpqty = CDbl(Me.txtShpQty.Text)
                untprc = CDbl(IIf(Trim(Me.txtUntPrc.Text) <> "", Trim(Me.txtUntPrc.Text), 0))
                '2005-08-31
                If Not rs_GRNTRFLST.Tables("result") Is Nothing Then
                    With rs_GRNTRFLST
                        If .Tables("result").DefaultView.Count > 0 Then
                            For index As Integer = 0 To rs_GRNTRFLST.Tables("RESULT").DefaultView.Count - 1
                                ', 2005-10-17
                                'OSQty = OSQty + .Tables("result").defaultview(index)("OSQty") + .Tables("result").defaultview(index)("OriShpQty")
                                OSQty = OSQty + .Tables("result").DefaultView(index)("Cul_OSQty") + .Tables("result").DefaultView(index)("ShpQty")
                                Debug.Print("OS:" & OSQty & " , C.OS:" & .Tables("result").DefaultView(index)("Cul_OSQty") & " , P.SHP" & .Tables("result").DefaultView(index)("ShpQty"))
                                '.Tables("result").defaultview(index)("Cul_ShpQty")
                            Next

                            If shpqty > OSQty Then
                                Call show_detail_msg("Ship Qty (" & shpqty & ") > OS Qty (" & OSQty & ")!", Me.txtShpQty)
                                Exit Sub
                            End If
                        End If
                    End With
                End If
                '---------------------
                OSQty = 0
                shpqty = CDbl(Me.txtShpQty.Text)
                untprc = CDbl(IIf(Trim(Me.txtUntPrc.Text) <> "", Trim(Me.txtUntPrc.Text), 0))
                'If shpqty = 0 Then Exit Sub
                remainQty = shpqty
                If Not rs_GRNTRFLST.Tables("result") Is Nothing Then
                    bolDisplay = True
                    With rs_GRNTRFLST
                        If .Tables("result").DefaultView.Count > 0 Then


                            For index As Integer = 0 To .Tables("result").DefaultView.Count - 1
                                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                '2006-04-24
                                .Tables("result").DefaultView(index)("Prv_Shpqty") = .Tables("result").DefaultView(index)("ShpQty")
                                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                .Tables("result").DefaultView(index)("ShpQty") = 0

                            Next

                            For index As Integer = 0 To .Tables("result").DefaultView.Count - 1
                                ''''''For index As Integer = 0 To .Tables("result").defaultview.Count - 1
                                'osqty = .Tables("result").defaultview(index)("OSQty") + .Tables("result").defaultview(index)("OriShpQty")
                                OSQty = .Tables("result").DefaultView(index)("Cul_OSQty") + .Tables("result").DefaultView(index)("Prv_ShpQty")
                                If OSQty >= remainQty Then


                                    .Tables("result").DefaultView(index)("ShpQty") = remainQty

                                    remainQty = 0
                                    'shpqty = OSQty
                                    'subttl = subttl + CLng(IIf(IsDBNull(.Tables("result").defaultview(index)("ShpQty")), 0, .Tables("result").defaultview(index)("ShpQty"))) * .Tables("result").defaultview(index)("Grl_UntPrc")
                                    'subttl = subttl + (CDbl(IIf(IsDBNull(.Tables("result").defaultview(index)("ShpQty")), 0, .Tables("result").defaultview(index)("ShpQty"))) * untprc)
                                    '<CULMULATIVE QTY>
                                    Call CumulativeQty_update(.Tables("result").DefaultView(index)("Grl_PONo"), .Tables("result").DefaultView(index)("Grl_POSeq"), .Tables("result").DefaultView(index)("Mpd_ItmNo"), .Tables("result").DefaultView(index)("ShpQty") - .Tables("result").DefaultView(index)("Prv_Shpqty"), 0)
                                    .Tables("result").DefaultView(index)("Cul_ShpQty") = CumulativeQty_show(.Tables("result").DefaultView(index)("Grl_PONo"), .Tables("result").DefaultView(index)("Grl_POSeq"), .Tables("result").DefaultView(index)("Mpd_ItmNo"), "SHP")
                                    .Tables("result").DefaultView(index)("Cul_OSQty") = CumulativeQty_show(.Tables("result").DefaultView(index)("Grl_PONo"), .Tables("result").DefaultView(index)("Grl_POSeq"), .Tables("result").DefaultView(index)("Mpd_ItmNo"), "OS")
                                    'Exit For
                                Else
                                    .Tables("result").DefaultView(index)("ShpQty") = OSQty

                                    '<CULMULATIVE QTY>
                                    Call CumulativeQty_update(.Tables("result").DefaultView(index)("Grl_PONo"), .Tables("result").DefaultView(index)("Grl_POSeq"), .Tables("result").DefaultView(index)("Mpd_ItmNo"), .Tables("result").DefaultView(index)("ShpQty") - .Tables("result").DefaultView(index)("Prv_Shpqty"), 0)
                                    .Tables("result").DefaultView(index)("Cul_ShpQty") = CumulativeQty_show(.Tables("result").DefaultView(index)("Grl_PONo"), .Tables("result").DefaultView(index)("Grl_POSeq"), .Tables("result").DefaultView(index)("Mpd_ItmNo"), "SHP")
                                    .Tables("result").DefaultView(index)("Cul_OSQty") = CumulativeQty_show(.Tables("result").DefaultView(index)("Grl_PONo"), .Tables("result").DefaultView(index)("Grl_POSeq"), .Tables("result").DefaultView(index)("Mpd_ItmNo"), "OS")
                                    remainQty = round(remainQty - OSQty, 2)
                                End If
                                'subttl = subttl + CLng(IIf(IsDBNull(.Tables("result").defaultview(index)("ShpQty")), 0, .Tables("result").defaultview(index)("ShpQty"))) * .Tables("result").defaultview(index)("Grl_UntPrc")
                                subttl = subttl + (CDbl(IIf(IsDBNull(.Tables("result").DefaultView(index)("ShpQty")), 0, .Tables("result").DefaultView(index)("ShpQty"))) * untprc)
                                '.MoveNext()
                            Next
                        End If
                    End With
                    bolDisplay = False
                End If
                If shpqty = remainQty Then
                    Me.txtShpQty.Text = "0"
                ElseIf remainQty > 0 Then
                    Me.txtShpQty.Text = shpqty - remainQty
                Else
                    Me.txtShpQty.Text = shpqty
                End If
                'Me.txtSubTtl.Text = Format(subttl, "######.#0")
            Else
                'Me.txtSubTtl.Text = ""
                If Trim(Me.txtUntPrc.Text) <> "" And Trim(Me.txtShpQty.Text) <> "" Then
                    On Error GoTo err_Handle_not_numeric
                    'Me.txtSubTtl.Text = round(Me.txtUntPrc.Text * Me.txtShpQty.Text, 2)
                    On Error GoTo 0
                End If
            End If
            Exit Sub
        End If
        '2005-10-19, call function in Module instead of hardcode
        'If e.KeyChar = 8 Or InStr("1234567890", e.KeyChar) > 0 Then Exit Sub
        'e.KeyChar = Chr(0)


        e.KeyChar = Chr(check_numeric_size(txtShpQty.Text, Asc(e.KeyChar), txtShpQty.SelectionStart, 9, 2))
        Exit Sub
err_Handle_not_numeric:
        MsgBox("Unit Price and/or Ship Qty not valid")
        Err.Clear()
    End Sub
    Private Sub txtShpUM_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShpUM.LostFocus
        Me.txtShpUM.Text = UCase(Me.txtShpUM.Text)

    End Sub


    Private Sub txtTrdCty_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTrdCty.GotFocus
        Call setFocus_text(Me.txtTrdCty)
    End Sub


    Private Sub txtTtlCTN_D_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTtlCTN_D.GotFocus
        Call setFocus_text(Me.txtTtlCTN_D)
    End Sub
    Private Sub txtTtlCTN_D_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTtlCTN_D.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Call calTotalNWGW_Dtl()
            Exit Sub
        End If
        If Asc(e.KeyChar) = 8 Or InStr("1234567890", e.KeyChar) > 0 Then Exit Sub
        e.KeyChar = Chr(0)
    End Sub



    Private Sub cboTtlCTN_D_UM_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTtlCTN_D_UM.LostFocus
        'Me.cboTtlCTN_D_UM.Text = UCase(Me.cboTtlCTN_D_UM.Text)
        If ValidateCombo(Me.cboTtlCTN_D_UM) = False Then
            Exit Sub
        End If

    End Sub
    Private Sub txtTtlGW_D_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTtlGW_D.GotFocus
        Call setFocus_text(Me.txtTtlGW_D)
    End Sub

    Private Sub txtTtlGW_D_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTtlGW_D.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 9 Then Exit Sub

        If Len(Me.txtTtlGW_D.Text) > 9 Then
            If InStr(Me.txtTtlGW_D.Text, ".") > 0 Then
                If Len(Microsoft.VisualBasic.Left(Me.txtTtlGW_D.Text, InStr(Me.txtTtlGW_D.Text, "."))) > 9 Then
                    e.KeyChar = Chr(0)
                    Exit Sub
                End If
            Else
                e.KeyChar = Chr(0)
            End If
        End If

        If InStr("1234567890", e.KeyChar) > 0 Then Exit Sub
        If e.KeyChar = "." And InStr(Me.txtTtlGW_D.Text, ".") <= 0 Then Exit Sub

        e.KeyChar = Chr(0)


    End Sub


    'goto
    Private Sub txtTtlNW_D_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTtlNW_D.GotFocus
        Call setFocus_text(Me.txtTtlNW_D)

    End Sub

    Private Sub txtTtlNW_D_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTtlNW_D.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 9 Then Exit Sub

        If Len(Me.txtTtlNW_D.Text) > 9 Then
            If InStr(Me.txtTtlNW_D.Text, ".") > 0 Then
                If Len(Microsoft.VisualBasic.Left(Me.txtTtlNW_D.Text, InStr(Me.txtTtlNW_D.Text, "."))) > 9 Then
                    e.KeyChar = Chr(0)
                    Exit Sub
                End If
            Else
                e.KeyChar = Chr(0)
            End If
        End If

        If InStr("1234567890", e.KeyChar) > 0 Then Exit Sub
        If e.KeyChar = "." And InStr(Me.txtTtlNW_D.Text, ".") <= 0 Then Exit Sub

        e.KeyChar = Chr(0)
    End Sub



    Private Sub txtUntPrc_Change()
        '2005-10-19
        '    If InStr(Trim(Me.txtUntPrc.Text), ".") > 0 And Len(Trim(Me.txtUntPrc.Text)) - InStr(Trim(Me.txtUntPrc.Text), ".") > 4 Then
        '        Me.txtUntPrc.Text = round(CDbl(IIf(Me.txtUntPrc.Text = "", 0, Me.txtUntPrc.Text)), 4)
        '    End If
    End Sub

    Private Sub txtUntPrc_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUntPrc.GotFocus
        Call setFocus_text(Me.txtUntPrc)
    End Sub

    Private Sub txtUntPrc_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUntPrc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'Call txtShpQty_KeyPress(Asc(e.KeyChar))
            Call txtCustQty_KeyPress(Asc(e.KeyChar))
        End If
        If Asc(e.KeyChar) = 9 Or Asc(e.KeyChar) = 8 Then Exit Sub

        e.KeyChar = Chr(check_numeric_size(txtUntPrc.Text, Asc(e.KeyChar), txtUntPrc.SelectionStart, 9, 4))

    End Sub

    Private Function GetRecvDept(ByVal strPONO As String)
        GetRecvDept = ""

        Dim rs_GetRecvDept As New DataSet

        If strPONO = "" Then
            GetRecvDept = ""
        Else

            gspStr = "sp_select_MPM00002_GetRecvDept  '', '" & Trim(strPONO) & "'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading  sp_select_MPM00002_GetRecvDept  :" & rtnStr)
                Exit Function
            Else
                If rs.Tables("result").Rows.Count > 0 Then

                    If IsDBNull(rs.Tables("result").Rows(0)("RecvDept")) Then
                        GetRecvDept = ""
                    Else
                        GetRecvDept = rs.Tables("result").Rows(0)("RecvDept")
                    End If


                    'tempzzzzzzz
                Else
                    GetRecvDept = ""
                End If
            End If
        End If

    End Function

    'goto
    Private Sub SetMPO(ByVal strFty As String)

        If Trim(cboImpFty.Text) <> "" Then
            If strFty = "ALL" Then
                gspStr = "sp_list_MPM00002_All_MPO     '','ALL' ,'' "
            Else
                gspStr = "sp_list_MPM00002     '','MPO' ,'" & Trim(cboImpFty.Text) & "' "
            End If

            Cursor = Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_MPONo, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading  sp_list_MPM00002:" & rtnStr)
                Exit Sub
            Else
                Me.cboMPONo.Items.Clear()
                If Not rs_MPONo.Tables("result") Is Nothing Then
                    If rs_MPONo.Tables("result").Rows.Count > 0 Then
                        For index As Integer = 0 To rs_MPONo.Tables("RESULT").Rows.Count - 1
                            cboMPONo.Items.Add(rs_MPONo.Tables("RESULT").Rows(index)("Mph_MpoNo"))
                        Next
                    Else
                    End If

                End If
            End If
            Cursor = Cursors.Default
        End If
    End Sub


    Private Function ValidateCombo(ByVal Combo1 As ComboBox) As Boolean
        Dim S As String
        If Combo1.Text = "" Then
            ValidateCombo = True
            Exit Function
        End If
        ValidateCombo = False
        Dim i As Integer

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
    Public Sub displaycombo(ByVal combo As ComboBox, ByVal val As String)

        If val = "" Then
            combo.Text = val
            Exit Sub
        End If

        Dim i As Integer

        For i = 0 To combo.Items.Count - 1
            If val = Split(combo.Items(i), " - ")(0) Then
                combo.Text = combo.Items(i)
                Exit Sub
            End If
        Next i

        combo.Text = val
    End Sub

    Private Function round(ByVal a As Double, ByVal Value As Double) As Double
        Dim S As String

        S = "0"

        If Value = 0 Then S = "0"
        If Value = 1 Then S = "0.0"
        If Value = 2 Then S = "0.00"
        If Value = 3 Then S = "0.000"
        If Value = 4 Then S = "0.0000"
        If Value = 5 Then S = "0.00000"
        If Value = 6 Then S = "0.000000"
        If Value = 7 Then S = "0.0000000"
        If Value = 8 Then S = "0.00000000"
        If Value = 9 Then S = "0.000000000"
        If Value = 10 Then S = "0.0000000000"

        round = CDbl(Format(a, S))
    End Function

    Private Sub chkDelete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDelete.CheckedChanged

    End Sub

    Private Sub grdDtlLst_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDtlLst.CellContentClick

    End Sub

    Private Sub grdDtlLst_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDtlLst.CellEndEdit

        grdDtlLst_AfterColUpdate(e.ColumnIndex)
        'tempzzzzzzzzzz

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


    Private Sub grdSummary_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSummary.CellContentClick


    End Sub

    Private Sub optType0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optType0.CheckedChanged
        If flag_optType0_Click = True Then
            flag_optType0_Click = False
            optType_Click(0)
        End If
    End Sub

    Private Sub optType1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optType1.CheckedChanged
        If flag_optType1_Click = True Then
            flag_optType1_Click = False
            optType_Click(1)
        End If


    End Sub

    Private Sub optType2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optType2.CheckedChanged
        If flag_optType2_Click = True Then
            flag_optType2_Click = False
            optType_Click(2)
        End If

    End Sub


    Private Sub txtCTNTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCTNTo.TextChanged

    End Sub


    Private Sub CboCustUM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCustUM.SelectedIndexChanged

    End Sub

    Public Sub mmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click


        Call mmdFindClick()

    End Sub

    Private Sub cmdNextD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextD.Click
        Call moveRecord("N")

    End Sub

    Private Sub cmdPrvD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrvD.Click
        Call moveRecord("P")

    End Sub

    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        If btcMPM00002.SelectedIndex <> 1 Then Exit Sub




        'check data validation
        If Not rs_GRNTRFDTL.Tables("result") Is Nothing Then
            If rs_GRNTRFDTL.Tables("result").Rows.Count > 0 Then
                '++++++++++++++++++++++++++++++++++++++++++++
                If checkDetail() = False Then Exit Sub
                'check and update deatil
                Call UpdateDetail()
                '++++++++++++++++++++++++++++++++++++++++++++
            End If
        End If


        seq = seq + 1
        Me.txtSeq.Text = seq
        Me.txtPrtGrp.Text = 1
        If Not rs_GRNTRFDTL.Tables("result") Is Nothing Then
            With rs_GRNTRFDTL

                .Tables("RESULT").Rows.Add()

                readingindex = .Tables("RESULT").Rows.Count - 1

                .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Del") = "N"
                .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("CreUsr") = "~*ADD*~"
                .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_Seq") = seq
                .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_CreUsr") = gsUsrID
                .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_CreDat") = Now()
                .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_UpdUsr") = gsUsrID
                .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_UpdDat") = Now()
                .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_CustCat") = ""
                .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_Curr") = strCurrGBL
                '.Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_Curr") = "HKD"
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_GrnNo") = Me.txtGRNNo.Text
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_Type") = "MPO"
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_Grp") = ""
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_ItmNo") = ""
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_ItmNam") = ""
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_ItmDsc") = ""
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_Curr") = ""
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_UntPrc") = 0
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_Color") = ""
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_CustCat") = Null
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_Cty") = ""
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_CTNFm") = ""
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_CTNTo") = ""
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_TtlCTN") = 0
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_CtnUM") = ""
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_GW") = 0
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_NW") = ""

                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_TtlGW") = 0
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_TtlNW") = 0
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_PckWgt") = 0
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_PckUM") = ""
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_TtlShpQty") = 0
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("OriShpQty") = 0
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_ShpUM") = ""
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_RevDept") = ""
                '            .Tables("RESULT").Rows(.Tables("RESULT").Rows.Count - 1)("Grd_MpoNo") = ""

            End With


        End If


        '    Me.cmdfirstD.Enabled = False
        Me.cmdPrvD.Enabled = False
        Me.cmdNextD.Enabled = False
        '    Me.cmdlastD.Enabled = False

        If seq > 1 Then
            '        Me.cmdfirstD.Enabled = True
            Me.cmdPrvD.Enabled = True
            Me.cmdNextD.Enabled = False
            '        Me.cmdlastD.Enabled = False
        End If

        Call setStatus("Add_Dtl")
        Call enableOptType(True)
        Me.optType0.Checked = True
        Call optType_Click(stsMPO)
        Call showStatusBar()

        If gsUsrGrp = "CST-G1" Then
            optType1.Checked = True
            optType0.Checked = False
            optType2.Checked = False

            'optType0.Enabled = False
            'optType1.Enabled = False
            'optType2.Enabled = False
            '20151209
            '20151110
        End If

    End Sub

    Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click
        If btcMPM00002.SelectedIndex <> 1 Then Exit Sub
        If rs_GRNTRFDTL.Tables("result") Is Nothing Then Exit Sub
        If rs_GRNTRFDTL.Tables("result").Rows.Count <= 0 Then Exit Sub

        If Me.chkDelete.Enabled = False Then Exit Sub
        If Me.chkDelete.Checked = True Then
            Me.chkDelete.Checked = False
        Else
            Me.chkDelete.Checked = True
        End If

    End Sub

    Private Sub optType0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optType0.Click
        flag_optType0_Click = True
    End Sub

    Private Sub optType1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optType1.Click
        flag_optType1_Click = True
    End Sub

    Private Sub optType2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optType2.Click
        flag_optType2_Click = True
    End Sub

    Private Sub txtPck_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPck.TextChanged

    End Sub

    Private Sub txtCustQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustQty.TextChanged

    End Sub

    Private Sub txtTtlGW_D_UM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTtlGW_D_UM.TextChanged

    End Sub

    Private Sub grdDtlLst_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdDtlLst.KeyPress

        'e.KeyChar

        '    e.KeyChar = Chr(check_numeric_size(txtShpQty.Text, Asc(e.KeyChar), txtShpQty.SelectionStart, 9, 2))

    End Sub

    Private Sub txtShpQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpQty.TextChanged

    End Sub

    Private Sub Label33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label33.Click

    End Sub

    Private Sub Label25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label25.Click

    End Sub

    Private Sub txtDlvDat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 

    End Sub

    Private Sub txtItmNam_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItmNam.LostFocus
        txtItmNam.Height = 20

    End Sub

    Private Sub txtItmNam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmNam.TextChanged

    End Sub

    Private Sub txtPck_UM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPck_UM.TextChanged

    End Sub
    Sub change_meter()
        If Trim(txtPck_UM.Text) = "碼" Or UCase(Trim(txtPck_UM.Text)) = UCase("yard") Or UCase(Trim(txtPck_UM.Text)) = UCase("yards") Or UCase(Trim(txtPck_UM.Text)) = UCase("YDS") Then
            txtCustQty.Text = round(Val(txtPck.Text) * 0.9144, 4)
            CboCustUM.Text = "M"
        End If


    End Sub

    Private Sub txtNW_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNW.LostFocus
        '    If bolCheckWgt = True Then Exit Sub
        '    bolCheckWgt = False
        '    If Trim(Me.txtGW.Text) <> "" And Trim(Me.txtNW.Text) <> "" Then
        '        If CDbl(Me.txtGW.Text) < CDbl(Me.txtNW.Text) Then
        '            Call show_detail_msg("N.W/CTN > G.W/CTN!", txtNW)
        '            bolCheckWgt = True
        '        End If
        '    End If

        Call calTotalNWGW_Dtl()
        txtCustQty.Text = txtTtlNW_D.Text

        'txtTtlNW_D.Text = Val(txtNW.Text) * Val(txtTtlCTN_D.Text)
    End Sub


    Private Sub txtNW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNW.TextChanged

    End Sub

    Private Sub txtMode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMode.TextChanged

    End Sub

    Private Sub cboCustUM_H_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustUM_H.SelectedIndexChanged

    End Sub

    Private Sub GroupBox8_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox8.Enter

    End Sub

    Private Sub txtItmNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmNo.TextChanged

    End Sub

    Private Sub cboCurr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCurr.SelectedIndexChanged
        If flag_cboCurr_GotFocus = True Then
            flag_cboCurr_GotFocus = False
            Call cboCurr_Click()

        End If

    End Sub
#Region "For testing"

    Dim currow As Integer = 0
    Dim curcol As Integer = 0

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        MessageBox.Show("Width : " + grdSummary.Columns(curcol).Width.ToString + "Header : " + grdSummary.Columns(curcol).HeaderText.ToString + ", Col:" + curcol.ToString)
    End Sub
    Private Sub contentclick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSummary.CellClick

        currow = e.RowIndex
        curcol = e.ColumnIndex
        'AddHandler grdResult.Shown, AddressOf contentclick
    End Sub

    Private Sub grdResult_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSummary.CellClick
        currow = e.RowIndex
        curcol = e.ColumnIndex
    End Sub

#End Region

    Private Sub tsiMPR03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsiMPR03.Click
        If Recordstatus = True Then
            MessageBox.Show("GRN has been changed. Please save before printing.")
        Else
            Dim frmMPR00003 As New MPR00003
            Dim GRNno As String
            GRNno = txtGRNNo.Text
            frmMPR00003.callByMPM02(GRNno)
        End If
    End Sub
End Class
