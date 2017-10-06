Public Class CLM00001
    Inherits System.Windows.Forms.Form

    Private Const sMODULE As String = "CL"

    Dim dsNewRow As DataRow
    Dim mode As String
    Dim dr() As DataRow
    Public sReadingIndexQ_ship As String = 0
    Public sReadingIndexQ_Item As String = 0
    Private Const cModeInit As String = "INIT"
    Private Const cModeAdd As String = "ADD"
    Private Const cModeCopy As String = "COPY"
    Private Const cModeUpd As String = "UPDATING"
    Private Const cModeSave As String = "SAVE"
    Private Const cModeDel As String = "DELETE"
    Private Const cModeRead As String = "READONLY"
    Private Const cModeClear As String = "CLEAR"
    Dim gb_count_rbViewOn As Integer
    Dim PreviousTab As Integer = 0
    Dim bIsShowPanels As Boolean  ' if a Panel is shown, set to true, cover the whole form to prevent detail index be changed
    Dim sMode As String
    Dim orgclmsts As String
    Dim Previous_rbViewOn_I_Checked As Boolean
    Dim flag_rbViewOn_click As Boolean
    Dim rs_syusrpr As DataSet
    Dim temp_yup_usrgrp As String
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim flag_keypress_txt_Hdr_ClaimToInsAmt As Boolean
    Dim flag_keypress_txt_Hdr_ClaimToVNAmt As Boolean
    Dim flag_keypress_txt_Hdr_FinalClaimAmt As Boolean
    Dim flag_keypress_txt_Hdr_OrgClaimAmt As Boolean
    Dim flag_keypress_txt_Hdr_ClaimToInsAmt_ori As Boolean
    Dim flag_keypress_txt_Hdr_ClaimToVNAmt_ori As Boolean

    Dim gl_tor As Decimal
    Dim gl_rate As Decimal

    Dim rs_curex As New DataSet
    Dim flag_keypress_1a As Boolean
    Dim flag_keypress_2a As Boolean
    Dim flag_keypress_3a As Boolean
    Dim flag_keypress_1b As Boolean
    Dim flag_keypress_2b As Boolean
    Dim flag_keypress_3b As Boolean
    Dim flag_cmdfind_process As Boolean
    Dim FLAG_FIRST_TIME_CHECK_CASE As Boolean
    Public rs_CUBASINF_CR As New DataSet
    Dim not_allow_save As Boolean
    Public rs_SYUSRRIGHT_Check As New DataSet
    Dim dtHDRPAIDDAT_btcCLM00001_Selecting As String
    Dim dtHDRRCVDAT_btcCLM00001_Selecting As String
    Dim flag_chkwait_Click As Boolean

    Public FrmCLR00001 As CLR00001










#Region " Windows Form Designer generated code"
    Friend WithEvents btcCLM00001 As ERPSystem.BaseTabControl
    Friend WithEvents tpCLM00001_1 As System.Windows.Forms.TabPage
    Friend WithEvents tpCLM00001_3 As System.Windows.Forms.TabPage
    Friend WithEvents tpCLM00001_4 As System.Windows.Forms.TabPage
    Friend WithEvents dgSummary As System.Windows.Forms.DataGridView
    Friend WithEvents gb_Hdr_ClaimAmt As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Hdr_ExceedAppLmt As System.Windows.Forms.Label
    Friend WithEvents cmd_Hdr_Apv1 As System.Windows.Forms.Button
    Friend WithEvents lbl_Hdr_FinalClaimAmt As System.Windows.Forms.Label
    Friend WithEvents lbl_Hdr_OrgClaimAmt As System.Windows.Forms.Label
    Friend WithEvents txt_Hdr_OrgClaimAmt As System.Windows.Forms.TextBox
    Friend WithEvents cbo_Hdr_ClaimAmtCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Hdr_FinalClaimAmt As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Hdr_AppLmtChkPer_Ttl As System.Windows.Forms.Label
    Friend WithEvents txt_Hdr_AppLmtChk_Ttl As System.Windows.Forms.TextBox
    Friend WithEvents txt_Hdr_SalesAmt_Ttl As System.Windows.Forms.TextBox
    Friend WithEvents txtSalesManager As System.Windows.Forms.TextBox
    Friend WithEvents txtSalesTeam As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Hdr_AppLmtChk As System.Windows.Forms.Label
    Friend WithEvents gb_Hdr_ClaimTo As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_Hdr_Apv2 As System.Windows.Forms.Button
    Friend WithEvents txt_Hdr_ClaimToInsAmt As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Hdr_ClaimToInsAmt As System.Windows.Forms.Label
    Friend WithEvents cbo_Hdr_ClaimToInsAmtCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Hdr_ClaimToVNAmt As System.Windows.Forms.Label
    Friend WithEvents lbl_Hdr_ClaimToHKOAmt As System.Windows.Forms.Label
    Friend WithEvents cbo_Hdr_ClaimToVNAmtCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Hdr_ClaimToVNAmt As System.Windows.Forms.TextBox
    Friend WithEvents cbo_Hdr_ClaimToHKOAmtCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Hdr_ClaimToHKOAmt As System.Windows.Forms.TextBox
    Friend WithEvents lblSalesManager As System.Windows.Forms.Label
    Friend WithEvents lblSalesTeam As System.Windows.Forms.Label
    Friend WithEvents lbl_Hdr_Rmk As System.Windows.Forms.Label
    Friend WithEvents lbl_Hdr_SalesAmt As System.Windows.Forms.Label
    Friend WithEvents lblClaimType As System.Windows.Forms.Label
    Friend WithEvents gbClaimBy As System.Windows.Forms.GroupBox
    Friend WithEvents rbClaimBy_U As System.Windows.Forms.RadioButton
    Friend WithEvents lblClaimBy As System.Windows.Forms.Label
    Friend WithEvents cboVendor As System.Windows.Forms.ComboBox
    Friend WithEvents lblVendor As System.Windows.Forms.Label
    Friend WithEvents cboSecCust As System.Windows.Forms.ComboBox
    Friend WithEvents lblSecCust As System.Windows.Forms.Label
    Friend WithEvents cboPriCust As System.Windows.Forms.ComboBox
    Friend WithEvents lblPriCust As System.Windows.Forms.Label
    Friend WithEvents rbClaimBy_V As System.Windows.Forms.RadioButton
    Friend WithEvents rbClaimBy_C As System.Windows.Forms.RadioButton
    Friend WithEvents lbl_Dtl_AppLmtChkPer As System.Windows.Forms.Label
    Friend WithEvents txtSelPrc As System.Windows.Forms.TextBox
    Friend WithEvents txtItmCst As System.Windows.Forms.TextBox
    Friend WithEvents txtCusPONo As System.Windows.Forms.TextBox
    Friend WithEvents txtInvETADat As System.Windows.Forms.TextBox
    Friend WithEvents txtInvETDDat As System.Windows.Forms.TextBox
    Friend WithEvents txtInvIssDat As System.Windows.Forms.TextBox
    Friend WithEvents txtPV As System.Windows.Forms.TextBox
    Friend WithEvents txtCustStyNo As System.Windows.Forms.TextBox
    Friend WithEvents txtOrdQtyUM As System.Windows.Forms.TextBox
    Friend WithEvents txtOrdQty As System.Windows.Forms.TextBox
    Friend WithEvents txtVenItmNo As System.Windows.Forms.TextBox
    Friend WithEvents txtCustItmNo As System.Windows.Forms.TextBox
    Friend WithEvents txtItmNo As System.Windows.Forms.TextBox
    Friend WithEvents txtInvNo As System.Windows.Forms.TextBox
    Friend WithEvents txtJobNo As System.Windows.Forms.TextBox
    Friend WithEvents txtPOSeq As System.Windows.Forms.TextBox
    Friend WithEvents txtPONo As System.Windows.Forms.TextBox
    Friend WithEvents txtSCSeq As System.Windows.Forms.TextBox
    Friend WithEvents txtSCNo As System.Windows.Forms.TextBox
    Friend WithEvents lblSelPrc As System.Windows.Forms.Label
    Friend WithEvents lblItmCst As System.Windows.Forms.Label
    Friend WithEvents lblCustPONo As System.Windows.Forms.Label
    Friend WithEvents lblInvETADat As System.Windows.Forms.Label
    Friend WithEvents lblInvETDDat As System.Windows.Forms.Label
    Friend WithEvents lblInvIssDat As System.Windows.Forms.Label
    Friend WithEvents lblCustStyNo As System.Windows.Forms.Label
    Friend WithEvents lblItmDsc As System.Windows.Forms.Label
    Friend WithEvents lblCoCde As System.Windows.Forms.Label
    Friend WithEvents lbl_Dtl_Rmk As System.Windows.Forms.Label
    Friend WithEvents lblPV As System.Windows.Forms.Label
    Friend WithEvents lblOdrQty As System.Windows.Forms.Label
    Friend WithEvents lblVenItmNo As System.Windows.Forms.Label
    Friend WithEvents lblCustItmNo As System.Windows.Forms.Label
    Friend WithEvents lblItmNo As System.Windows.Forms.Label
    Friend WithEvents lblInvoiceNo As System.Windows.Forms.Label
    Friend WithEvents lblJobNo As System.Windows.Forms.Label
    Friend WithEvents lblPONo As System.Windows.Forms.Label
    Friend WithEvents lblSCNo As System.Windows.Forms.Label
    Friend WithEvents lblSeq As System.Windows.Forms.Label
    Friend WithEvents lblSeqtext As System.Windows.Forms.Label
    Friend WithEvents txt_Dtl_Rmk As System.Windows.Forms.RichTextBox
    Friend WithEvents txt_Hdr_Rmk As System.Windows.Forms.RichTextBox
    Friend WithEvents txtItmDsc As System.Windows.Forms.RichTextBox
    Friend WithEvents cboClaimSts As System.Windows.Forms.ComboBox
    Friend WithEvents chkDelete As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_dtl_Next As System.Windows.Forms.Button
    Friend WithEvents cmd_dtl_Back As System.Windows.Forms.Button
    Friend WithEvents lbl_Hdr_ClaimToHKOAmt_ExchRate As System.Windows.Forms.Label
    Friend WithEvents lbl_Hdr_ClaimToVNAmt_ExchRate As System.Windows.Forms.Label
    Friend WithEvents lbl_Hdr_ClaimToInsAmt_ExchRate As System.Windows.Forms.Label
    Friend WithEvents cbo_Dtl_ClaimType As System.Windows.Forms.ComboBox
    Friend WithEvents cms_CopyNPaste As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents smi_Copy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smi_Paste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblClaimPeriod As System.Windows.Forms.Label
    Friend WithEvents cboClaimPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaimAmtPer As System.Windows.Forms.Label
    Friend WithEvents rbClaimAmtPer_C As System.Windows.Forms.RadioButton

    Friend WithEvents rbClaimAmtPer_I As System.Windows.Forms.RadioButton
    Friend WithEvents rbClaimAmtPer_S As System.Windows.Forms.RadioButton
    Friend WithEvents txt_Hdr_RemainClaim_Ttl As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Hdr_RemainClaim As System.Windows.Forms.Label
    Friend WithEvents lbl_Hdr_ClaimAmt As System.Windows.Forms.Label
    Friend WithEvents txtShipNo As System.Windows.Forms.TextBox
    Friend WithEvents lblShipNo As System.Windows.Forms.Label
    Friend WithEvents rbViewOn_S As System.Windows.Forms.RadioButton
    Friend WithEvents rbViewOn_I As System.Windows.Forms.RadioButton
    Friend WithEvents lblViewOn As System.Windows.Forms.Label
    Friend WithEvents txtShipQty As System.Windows.Forms.TextBox
    Friend WithEvents lblShipQty As System.Windows.Forms.Label
    Friend WithEvents txtShipQtyUM As System.Windows.Forms.TextBox
    Friend WithEvents txtCoCde As System.Windows.Forms.TextBox
    Friend WithEvents txtItmCstCurrency As System.Windows.Forms.TextBox
    Friend WithEvents txtSelPrcCurrency As System.Windows.Forms.TextBox
    Friend WithEvents cbo_Hdr_RemainClaimCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_Hdr_AppLmtChkCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_Hdr_SalesAmtCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents gbClaimAmtPer As System.Windows.Forms.GroupBox
    Friend WithEvents gbViewOn As System.Windows.Forms.GroupBox
    Friend WithEvents txtClaimPeriod As System.Windows.Forms.TextBox
    Friend WithEvents txtShipSeq As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Hdr_Finding As System.Windows.Forms.Label
    Friend WithEvents lbl_Hdr_CustComment As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    '    Friend WithEvents DirectoryEntry1 As System.DirectoryServices.DirectoryEntry
    Friend WithEvents cboClaimType As System.Windows.Forms.ComboBox
    Friend WithEvents lblSeason As System.Windows.Forms.Label
    Friend WithEvents cboSeason As System.Windows.Forms.ComboBox
    Friend WithEvents chkCancel As System.Windows.Forms.CheckBox
    Friend WithEvents gbPanelReason As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPanQuit As System.Windows.Forms.Button
    Friend WithEvents cmdPanOK As System.Windows.Forms.Button
    Friend WithEvents lblPrcElemtTitleP As System.Windows.Forms.Label
    Friend WithEvents txtreason As System.Windows.Forms.RichTextBox
    Friend WithEvents CmdViewReason As System.Windows.Forms.Button
    Friend WithEvents chkapv1a As System.Windows.Forms.CheckBox
    Friend WithEvents chkwait As System.Windows.Forms.CheckBox
    Friend WithEvents chkapv1b As System.Windows.Forms.CheckBox
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents tpCLM00001_2 As System.Windows.Forms.TabPage
    Friend WithEvents chkapv3a As System.Windows.Forms.CheckBox
    Friend WithEvents gb_pay As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_Hdr_AcctClaimAmt As System.Windows.Forms.TextBox
    Friend WithEvents cmd_close As System.Windows.Forms.Button
    Friend WithEvents chkClose As System.Windows.Forms.CheckBox
    Friend WithEvents gb_income As System.Windows.Forms.GroupBox
    Friend WithEvents cboAPRVSTS As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkapv3b As System.Windows.Forms.CheckBox
    Friend WithEvents chkapv2a As System.Windows.Forms.CheckBox
    Friend WithEvents chkapv2b As System.Windows.Forms.CheckBox
    Friend WithEvents txt_Hdr_ClaimToInsAmt_ori As System.Windows.Forms.TextBox
    Friend WithEvents txt_Hdr_ClaimToVNAmt_ori As System.Windows.Forms.TextBox
    Friend WithEvents txt_Hdr_ClaimToHKOAmt_ori As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_cmt_a As System.Windows.Forms.RichTextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_cmt_b As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_ref_no As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_stschg_date As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txt_stschg_usr As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_pay_potamt As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_pay_actamt As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txt_pay_upddat As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_income_potamt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_income_actamt As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_income_upddat As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dt_ref_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmd_attch As System.Windows.Forms.Button
    Friend WithEvents chkreplace As System.Windows.Forms.CheckBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cbo_Hdr_ClaimToHKOAmtCur As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_Hdr_ClaimToVNAmtCur As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_Hdr_ClaimToInsAmtCur As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_pay_cur As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_income_cur As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_outamt_pay As System.Windows.Forms.Label
    Friend WithEvents lbl_outamt_income As System.Windows.Forms.Label
    Friend WithEvents txt_org_dif As System.Windows.Forms.TextBox
    Friend WithEvents txt_final_dif As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lbl_amt_cur As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkvalidclm As System.Windows.Forms.RadioButton
    Friend WithEvents chkconfirmclm As System.Windows.Forms.RadioButton
    Friend WithEvents lbl_pay_amt As System.Windows.Forms.Label
    Friend WithEvents lbl_income_amt As System.Windows.Forms.Label
    Friend WithEvents txt_pay_rmk As System.Windows.Forms.RichTextBox
    Friend WithEvents txt_income_rmk As System.Windows.Forms.RichTextBox
    Friend WithEvents txt_Hdr_Finding As System.Windows.Forms.RichTextBox
    Friend WithEvents cboClaimPaySTS As System.Windows.Forms.ComboBox
    Friend WithEvents cboClaimIncomeSTS As System.Windows.Forms.ComboBox
    Friend WithEvents dtHDRPAIDDAT As System.Windows.Forms.MaskedTextBox
    Friend WithEvents dtHDRRCVDAT As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cboSETTLE_CUS As System.Windows.Forms.ComboBox
    Friend WithEvents cboSETTLE_FTY As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Hdr_CustComment As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtReplaceClaimNo As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
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
    '    Friend WithEvents rbClaimAmtPer_C As System.Windows.Forms.RadioButton

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
    Friend WithEvents StatusBar As System.Windows.Forms.StatusBar
    Friend WithEvents lblClaimNo As System.Windows.Forms.Label
    Friend WithEvents lblClaimStatus As System.Windows.Forms.Label
    Friend WithEvents txtClaimNo As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CLM00001))
        Me.StatusBar = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel
        Me.lblClaimNo = New System.Windows.Forms.Label
        Me.txtClaimNo = New System.Windows.Forms.TextBox
        Me.lblClaimStatus = New System.Windows.Forms.Label
        Me.cboClaimSts = New System.Windows.Forms.ComboBox
        Me.cms_CopyNPaste = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.smi_Copy = New System.Windows.Forms.ToolStripMenuItem
        Me.smi_Paste = New System.Windows.Forms.ToolStripMenuItem
        Me.lblClaimPeriod = New System.Windows.Forms.Label
        Me.cboClaimPeriod = New System.Windows.Forms.ComboBox
        Me.txtClaimPeriod = New System.Windows.Forms.TextBox
        Me.lblSeason = New System.Windows.Forms.Label
        Me.cboSeason = New System.Windows.Forms.ComboBox
        Me.gbPanelReason = New System.Windows.Forms.GroupBox
        Me.txtreason = New System.Windows.Forms.RichTextBox
        Me.cmdPanQuit = New System.Windows.Forms.Button
        Me.cmdPanOK = New System.Windows.Forms.Button
        Me.lblPrcElemtTitleP = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txt_stschg_date = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txt_stschg_usr = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.cmd_attch = New System.Windows.Forms.Button
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
        Me.btcCLM00001 = New ERPSystem.BaseTabControl
        Me.tpCLM00001_1 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtReplaceClaimNo = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.txt_Hdr_Finding = New System.Windows.Forms.RichTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkvalidclm = New System.Windows.Forms.RadioButton
        Me.chkconfirmclm = New System.Windows.Forms.RadioButton
        Me.Label25 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dt_ref_date = New System.Windows.Forms.DateTimePicker
        Me.Label19 = New System.Windows.Forms.Label
        Me.txt_ref_no = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.chkwait = New System.Windows.Forms.CheckBox
        Me.lbl_Hdr_Finding = New System.Windows.Forms.Label
        Me.lbl_Hdr_CustComment = New System.Windows.Forms.Label
        Me.CmdViewReason = New System.Windows.Forms.Button
        Me.gbClaimAmtPer = New System.Windows.Forms.GroupBox
        Me.chkreplace = New System.Windows.Forms.CheckBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.lblClaimAmtPer = New System.Windows.Forms.Label
        Me.rbClaimAmtPer_C = New System.Windows.Forms.RadioButton
        Me.rbClaimAmtPer_I = New System.Windows.Forms.RadioButton
        Me.rbClaimAmtPer_S = New System.Windows.Forms.RadioButton
        Me.chkCancel = New System.Windows.Forms.CheckBox
        Me.cboClaimType = New System.Windows.Forms.ComboBox
        Me.txt_Hdr_CustComment = New System.Windows.Forms.RichTextBox
        Me.cmd_Hdr_Apv2 = New System.Windows.Forms.Button
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_Hdr_Rmk = New System.Windows.Forms.RichTextBox
        Me.gb_Hdr_ClaimAmt = New System.Windows.Forms.GroupBox
        Me.chkapv3a = New System.Windows.Forms.CheckBox
        Me.chkapv1a = New System.Windows.Forms.CheckBox
        Me.lbl_Hdr_ClaimAmt = New System.Windows.Forms.Label
        Me.lbl_Hdr_ExceedAppLmt = New System.Windows.Forms.Label
        Me.chkapv2a = New System.Windows.Forms.CheckBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.lbl_Hdr_FinalClaimAmt = New System.Windows.Forms.Label
        Me.txt_cmt_a = New System.Windows.Forms.RichTextBox
        Me.lbl_Hdr_OrgClaimAmt = New System.Windows.Forms.Label
        Me.txt_Hdr_OrgClaimAmt = New System.Windows.Forms.TextBox
        Me.cbo_Hdr_ClaimAmtCurrency = New System.Windows.Forms.ComboBox
        Me.txt_Hdr_FinalClaimAmt = New System.Windows.Forms.TextBox
        Me.cmd_Hdr_Apv1 = New System.Windows.Forms.Button
        Me.txtSalesManager = New System.Windows.Forms.TextBox
        Me.txtSalesTeam = New System.Windows.Forms.TextBox
        Me.gb_Hdr_ClaimTo = New System.Windows.Forms.GroupBox
        Me.lbl_amt_cur = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.txt_org_dif = New System.Windows.Forms.TextBox
        Me.txt_final_dif = New System.Windows.Forms.TextBox
        Me.cbo_Hdr_ClaimToHKOAmtCur = New System.Windows.Forms.ComboBox
        Me.cbo_Hdr_ClaimToVNAmtCur = New System.Windows.Forms.ComboBox
        Me.cbo_Hdr_ClaimToInsAmtCur = New System.Windows.Forms.ComboBox
        Me.txt_Hdr_ClaimToInsAmt_ori = New System.Windows.Forms.TextBox
        Me.txt_Hdr_ClaimToVNAmt_ori = New System.Windows.Forms.TextBox
        Me.chkapv1b = New System.Windows.Forms.CheckBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txt_Hdr_ClaimToHKOAmt_ori = New System.Windows.Forms.TextBox
        Me.txt_cmt_b = New System.Windows.Forms.RichTextBox
        Me.chkapv3b = New System.Windows.Forms.CheckBox
        Me.lbl_Hdr_ClaimToHKOAmt_ExchRate = New System.Windows.Forms.Label
        Me.chkapv2b = New System.Windows.Forms.CheckBox
        Me.lbl_Hdr_ClaimToVNAmt_ExchRate = New System.Windows.Forms.Label
        Me.lbl_Hdr_ClaimToInsAmt_ExchRate = New System.Windows.Forms.Label
        Me.txt_Hdr_ClaimToInsAmt = New System.Windows.Forms.TextBox
        Me.lbl_Hdr_ClaimToInsAmt = New System.Windows.Forms.Label
        Me.cbo_Hdr_ClaimToInsAmtCurrency = New System.Windows.Forms.ComboBox
        Me.lbl_Hdr_ClaimToVNAmt = New System.Windows.Forms.Label
        Me.lbl_Hdr_ClaimToHKOAmt = New System.Windows.Forms.Label
        Me.cbo_Hdr_ClaimToVNAmtCurrency = New System.Windows.Forms.ComboBox
        Me.txt_Hdr_ClaimToVNAmt = New System.Windows.Forms.TextBox
        Me.cbo_Hdr_ClaimToHKOAmtCurrency = New System.Windows.Forms.ComboBox
        Me.txt_Hdr_ClaimToHKOAmt = New System.Windows.Forms.TextBox
        Me.txt_Hdr_RemainClaim_Ttl = New System.Windows.Forms.TextBox
        Me.lblSalesManager = New System.Windows.Forms.Label
        Me.lblSalesTeam = New System.Windows.Forms.Label
        Me.cbo_Hdr_RemainClaimCurrency = New System.Windows.Forms.ComboBox
        Me.lbl_Hdr_Rmk = New System.Windows.Forms.Label
        Me.lblClaimType = New System.Windows.Forms.Label
        Me.lbl_Hdr_RemainClaim = New System.Windows.Forms.Label
        Me.gbClaimBy = New System.Windows.Forms.GroupBox
        Me.rbClaimBy_U = New System.Windows.Forms.RadioButton
        Me.lblClaimBy = New System.Windows.Forms.Label
        Me.cboVendor = New System.Windows.Forms.ComboBox
        Me.lblVendor = New System.Windows.Forms.Label
        Me.cboSecCust = New System.Windows.Forms.ComboBox
        Me.lblSecCust = New System.Windows.Forms.Label
        Me.cboPriCust = New System.Windows.Forms.ComboBox
        Me.lblPriCust = New System.Windows.Forms.Label
        Me.rbClaimBy_V = New System.Windows.Forms.RadioButton
        Me.rbClaimBy_C = New System.Windows.Forms.RadioButton
        Me.cbo_Hdr_SalesAmtCurrency = New System.Windows.Forms.ComboBox
        Me.lbl_Hdr_SalesAmt = New System.Windows.Forms.Label
        Me.lbl_Hdr_AppLmtChk = New System.Windows.Forms.Label
        Me.lbl_Hdr_AppLmtChkPer_Ttl = New System.Windows.Forms.Label
        Me.cbo_Hdr_AppLmtChkCurrency = New System.Windows.Forms.ComboBox
        Me.txt_Hdr_SalesAmt_Ttl = New System.Windows.Forms.TextBox
        Me.txt_Hdr_AppLmtChk_Ttl = New System.Windows.Forms.TextBox
        Me.tpCLM00001_2 = New System.Windows.Forms.TabPage
        Me.gb_income = New System.Windows.Forms.GroupBox
        Me.cboSETTLE_FTY = New System.Windows.Forms.ComboBox
        Me.dtHDRRCVDAT = New System.Windows.Forms.MaskedTextBox
        Me.cboClaimIncomeSTS = New System.Windows.Forms.ComboBox
        Me.txt_income_rmk = New System.Windows.Forms.RichTextBox
        Me.lbl_income_amt = New System.Windows.Forms.Label
        Me.lbl_outamt_income = New System.Windows.Forms.Label
        Me.cbo_income_cur = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_income_upddat = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txt_income_potamt = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_income_actamt = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.gb_pay = New System.Windows.Forms.GroupBox
        Me.cboSETTLE_CUS = New System.Windows.Forms.ComboBox
        Me.dtHDRPAIDDAT = New System.Windows.Forms.MaskedTextBox
        Me.cboClaimPaySTS = New System.Windows.Forms.ComboBox
        Me.txt_pay_rmk = New System.Windows.Forms.RichTextBox
        Me.lbl_pay_amt = New System.Windows.Forms.Label
        Me.lbl_outamt_pay = New System.Windows.Forms.Label
        Me.cbo_pay_cur = New System.Windows.Forms.ComboBox
        Me.txt_pay_upddat = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_pay_potamt = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_pay_actamt = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmd_close = New System.Windows.Forms.Button
        Me.cboAPRVSTS = New System.Windows.Forms.ComboBox
        Me.chkClose = New System.Windows.Forms.CheckBox
        Me.txt_Hdr_AcctClaimAmt = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.tpCLM00001_3 = New System.Windows.Forms.TabPage
        Me.txtShipSeq = New System.Windows.Forms.TextBox
        Me.gbViewOn = New System.Windows.Forms.GroupBox
        Me.lblViewOn = New System.Windows.Forms.Label
        Me.rbViewOn_I = New System.Windows.Forms.RadioButton
        Me.rbViewOn_S = New System.Windows.Forms.RadioButton
        Me.txtItmCstCurrency = New System.Windows.Forms.TextBox
        Me.txtSelPrcCurrency = New System.Windows.Forms.TextBox
        Me.txtCoCde = New System.Windows.Forms.TextBox
        Me.txtShipQtyUM = New System.Windows.Forms.TextBox
        Me.txtShipQty = New System.Windows.Forms.TextBox
        Me.lblShipQty = New System.Windows.Forms.Label
        Me.txtShipNo = New System.Windows.Forms.TextBox
        Me.lblShipNo = New System.Windows.Forms.Label
        Me.cbo_Dtl_ClaimType = New System.Windows.Forms.ComboBox
        Me.cmd_dtl_Next = New System.Windows.Forms.Button
        Me.cmd_dtl_Back = New System.Windows.Forms.Button
        Me.chkDelete = New System.Windows.Forms.CheckBox
        Me.txtItmDsc = New System.Windows.Forms.RichTextBox
        Me.txt_Dtl_Rmk = New System.Windows.Forms.RichTextBox
        Me.lbl_Dtl_AppLmtChkPer = New System.Windows.Forms.Label
        Me.txtSelPrc = New System.Windows.Forms.TextBox
        Me.txtItmCst = New System.Windows.Forms.TextBox
        Me.txtCusPONo = New System.Windows.Forms.TextBox
        Me.txtInvETADat = New System.Windows.Forms.TextBox
        Me.txtInvETDDat = New System.Windows.Forms.TextBox
        Me.txtInvIssDat = New System.Windows.Forms.TextBox
        Me.txtPV = New System.Windows.Forms.TextBox
        Me.txtCustStyNo = New System.Windows.Forms.TextBox
        Me.txtOrdQtyUM = New System.Windows.Forms.TextBox
        Me.txtOrdQty = New System.Windows.Forms.TextBox
        Me.txtVenItmNo = New System.Windows.Forms.TextBox
        Me.txtCustItmNo = New System.Windows.Forms.TextBox
        Me.txtItmNo = New System.Windows.Forms.TextBox
        Me.txtInvNo = New System.Windows.Forms.TextBox
        Me.txtJobNo = New System.Windows.Forms.TextBox
        Me.txtPOSeq = New System.Windows.Forms.TextBox
        Me.txtPONo = New System.Windows.Forms.TextBox
        Me.txtSCSeq = New System.Windows.Forms.TextBox
        Me.txtSCNo = New System.Windows.Forms.TextBox
        Me.lblSelPrc = New System.Windows.Forms.Label
        Me.lblItmCst = New System.Windows.Forms.Label
        Me.lblCustPONo = New System.Windows.Forms.Label
        Me.lblInvETADat = New System.Windows.Forms.Label
        Me.lblInvETDDat = New System.Windows.Forms.Label
        Me.lblInvIssDat = New System.Windows.Forms.Label
        Me.lblCustStyNo = New System.Windows.Forms.Label
        Me.lblItmDsc = New System.Windows.Forms.Label
        Me.lblCoCde = New System.Windows.Forms.Label
        Me.lbl_Dtl_Rmk = New System.Windows.Forms.Label
        Me.lblPV = New System.Windows.Forms.Label
        Me.lblOdrQty = New System.Windows.Forms.Label
        Me.lblVenItmNo = New System.Windows.Forms.Label
        Me.lblCustItmNo = New System.Windows.Forms.Label
        Me.lblItmNo = New System.Windows.Forms.Label
        Me.lblInvoiceNo = New System.Windows.Forms.Label
        Me.lblJobNo = New System.Windows.Forms.Label
        Me.lblPONo = New System.Windows.Forms.Label
        Me.lblSCNo = New System.Windows.Forms.Label
        Me.lblSeq = New System.Windows.Forms.Label
        Me.lblSeqtext = New System.Windows.Forms.Label
        Me.tpCLM00001_4 = New System.Windows.Forms.TabPage
        Me.dgSummary = New System.Windows.Forms.DataGridView
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms_CopyNPaste.SuspendLayout()
        Me.gbPanelReason.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.menuStrip.SuspendLayout()
        Me.btcCLM00001.SuspendLayout()
        Me.tpCLM00001_1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbClaimAmtPer.SuspendLayout()
        Me.gb_Hdr_ClaimAmt.SuspendLayout()
        Me.gb_Hdr_ClaimTo.SuspendLayout()
        Me.gbClaimBy.SuspendLayout()
        Me.tpCLM00001_2.SuspendLayout()
        Me.gb_income.SuspendLayout()
        Me.gb_pay.SuspendLayout()
        Me.tpCLM00001_3.SuspendLayout()
        Me.gbViewOn.SuspendLayout()
        Me.tpCLM00001_4.SuspendLayout()
        CType(Me.dgSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusBar
        '
        Me.StatusBar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.StatusBar.Location = New System.Drawing.Point(0, 607)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2})
        Me.StatusBar.ShowPanels = True
        Me.StatusBar.Size = New System.Drawing.Size(954, 24)
        Me.StatusBar.TabIndex = 1
        '
        'StatusBarPanel1
        '
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
        'lblClaimNo
        '
        Me.lblClaimNo.AutoSize = True
        Me.lblClaimNo.ForeColor = System.Drawing.Color.Green
        Me.lblClaimNo.Location = New System.Drawing.Point(3, 32)
        Me.lblClaimNo.Name = "lblClaimNo"
        Me.lblClaimNo.Size = New System.Drawing.Size(50, 12)
        Me.lblClaimNo.TabIndex = 16
        Me.lblClaimNo.Text = "Claim No"
        '
        'txtClaimNo
        '
        Me.txtClaimNo.Location = New System.Drawing.Point(56, 27)
        Me.txtClaimNo.MaxLength = 9
        Me.txtClaimNo.Name = "txtClaimNo"
        Me.txtClaimNo.Size = New System.Drawing.Size(92, 22)
        Me.txtClaimNo.TabIndex = 15
        '
        'lblClaimStatus
        '
        Me.lblClaimStatus.AutoSize = True
        Me.lblClaimStatus.ForeColor = System.Drawing.Color.Black
        Me.lblClaimStatus.Location = New System.Drawing.Point(1, 14)
        Me.lblClaimStatus.Name = "lblClaimStatus"
        Me.lblClaimStatus.Size = New System.Drawing.Size(63, 12)
        Me.lblClaimStatus.TabIndex = 23
        Me.lblClaimStatus.Text = "Claim Status"
        '
        'cboClaimSts
        '
        Me.cboClaimSts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClaimSts.FormattingEnabled = True
        Me.cboClaimSts.Location = New System.Drawing.Point(75, 11)
        Me.cboClaimSts.Name = "cboClaimSts"
        Me.cboClaimSts.Size = New System.Drawing.Size(276, 20)
        Me.cboClaimSts.TabIndex = 18
        '
        'cms_CopyNPaste
        '
        Me.cms_CopyNPaste.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smi_Copy, Me.smi_Paste})
        Me.cms_CopyNPaste.Name = "cms_CopyNPaste"
        Me.cms_CopyNPaste.Size = New System.Drawing.Size(131, 48)
        '
        'smi_Copy
        '
        Me.smi_Copy.AutoSize = False
        Me.smi_Copy.Name = "smi_Copy"
        Me.smi_Copy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.smi_Copy.Size = New System.Drawing.Size(152, 22)
        '
        'smi_Paste
        '
        Me.smi_Paste.AutoSize = False
        Me.smi_Paste.Name = "smi_Paste"
        Me.smi_Paste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.smi_Paste.Size = New System.Drawing.Size(170, 22)
        Me.smi_Paste.Text = "Paste"
        Me.smi_Paste.ToolTipText = "Paste"
        '
        'lblClaimPeriod
        '
        Me.lblClaimPeriod.AutoSize = True
        Me.lblClaimPeriod.ForeColor = System.Drawing.Color.Green
        Me.lblClaimPeriod.Location = New System.Drawing.Point(154, 32)
        Me.lblClaimPeriod.Name = "lblClaimPeriod"
        Me.lblClaimPeriod.Size = New System.Drawing.Size(66, 12)
        Me.lblClaimPeriod.TabIndex = 46
        Me.lblClaimPeriod.Text = "Claim Period"
        '
        'cboClaimPeriod
        '
        Me.cboClaimPeriod.FormattingEnabled = True
        Me.cboClaimPeriod.Location = New System.Drawing.Point(224, 26)
        Me.cboClaimPeriod.Name = "cboClaimPeriod"
        Me.cboClaimPeriod.Size = New System.Drawing.Size(152, 20)
        Me.cboClaimPeriod.TabIndex = 16
        Me.cboClaimPeriod.Text = "04/01/2011 - 03/31/2012"
        '
        'txtClaimPeriod
        '
        Me.txtClaimPeriod.Location = New System.Drawing.Point(224, 27)
        Me.txtClaimPeriod.MaxLength = 8
        Me.txtClaimPeriod.Name = "txtClaimPeriod"
        Me.txtClaimPeriod.Size = New System.Drawing.Size(152, 22)
        Me.txtClaimPeriod.TabIndex = 48
        Me.txtClaimPeriod.Text = "04/01/2011 - 03/31/2012"
        '
        'lblSeason
        '
        Me.lblSeason.AutoSize = True
        Me.lblSeason.ForeColor = System.Drawing.Color.Green
        Me.lblSeason.Location = New System.Drawing.Point(387, 32)
        Me.lblSeason.Name = "lblSeason"
        Me.lblSeason.Size = New System.Drawing.Size(37, 12)
        Me.lblSeason.TabIndex = 278
        Me.lblSeason.Text = "Season"
        '
        'cboSeason
        '
        Me.cboSeason.FormattingEnabled = True
        Me.cboSeason.Location = New System.Drawing.Point(427, 28)
        Me.cboSeason.Name = "cboSeason"
        Me.cboSeason.Size = New System.Drawing.Size(98, 20)
        Me.cboSeason.TabIndex = 17
        '
        'gbPanelReason
        '
        Me.gbPanelReason.BackColor = System.Drawing.Color.SkyBlue
        Me.gbPanelReason.Controls.Add(Me.txtreason)
        Me.gbPanelReason.Controls.Add(Me.cmdPanQuit)
        Me.gbPanelReason.Controls.Add(Me.cmdPanOK)
        Me.gbPanelReason.Controls.Add(Me.lblPrcElemtTitleP)
        Me.gbPanelReason.Location = New System.Drawing.Point(38, 49)
        Me.gbPanelReason.Name = "gbPanelReason"
        Me.gbPanelReason.Size = New System.Drawing.Size(548, 358)
        Me.gbPanelReason.TabIndex = 531
        Me.gbPanelReason.TabStop = False
        '
        'txtreason
        '
        Me.txtreason.Location = New System.Drawing.Point(111, 83)
        Me.txtreason.Name = "txtreason"
        Me.txtreason.Size = New System.Drawing.Size(352, 163)
        Me.txtreason.TabIndex = 530
        Me.txtreason.Text = ""
        '
        'cmdPanQuit
        '
        Me.cmdPanQuit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPanQuit.Location = New System.Drawing.Point(292, 266)
        Me.cmdPanQuit.Name = "cmdPanQuit"
        Me.cmdPanQuit.Size = New System.Drawing.Size(103, 26)
        Me.cmdPanQuit.TabIndex = 383
        Me.cmdPanQuit.Text = "Quit"
        Me.cmdPanQuit.UseVisualStyleBackColor = True
        '
        'cmdPanOK
        '
        Me.cmdPanOK.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPanOK.Location = New System.Drawing.Point(183, 266)
        Me.cmdPanOK.Name = "cmdPanOK"
        Me.cmdPanOK.Size = New System.Drawing.Size(103, 26)
        Me.cmdPanOK.TabIndex = 520
        Me.cmdPanOK.Text = "Update"
        Me.cmdPanOK.UseVisualStyleBackColor = True
        '
        'lblPrcElemtTitleP
        '
        Me.lblPrcElemtTitleP.AutoSize = True
        Me.lblPrcElemtTitleP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrcElemtTitleP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPrcElemtTitleP.Location = New System.Drawing.Point(192, 49)
        Me.lblPrcElemtTitleP.Name = "lblPrcElemtTitleP"
        Me.lblPrcElemtTitleP.Size = New System.Drawing.Size(152, 20)
        Me.lblPrcElemtTitleP.TabIndex = 529
        Me.lblPrcElemtTitleP.Text = "Reason to Cancel"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txt_stschg_date)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.txt_stschg_usr)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.cboClaimSts)
        Me.GroupBox4.Controls.Add(Me.lblClaimStatus)
        Me.GroupBox4.Enabled = False
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(564, 18)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(357, 60)
        Me.GroupBox4.TabIndex = 541
        Me.GroupBox4.TabStop = False
        '
        'txt_stschg_date
        '
        Me.txt_stschg_date.Enabled = False
        Me.txt_stschg_date.Location = New System.Drawing.Point(283, 34)
        Me.txt_stschg_date.Name = "txt_stschg_date"
        Me.txt_stschg_date.Size = New System.Drawing.Size(66, 22)
        Me.txt_stschg_date.TabIndex = 544
        Me.txt_stschg_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(253, 39)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(26, 12)
        Me.Label20.TabIndex = 543
        Me.Label20.Text = "Date"
        '
        'txt_stschg_usr
        '
        Me.txt_stschg_usr.Enabled = False
        Me.txt_stschg_usr.Location = New System.Drawing.Point(36, 33)
        Me.txt_stschg_usr.Name = "txt_stschg_usr"
        Me.txt_stschg_usr.Size = New System.Drawing.Size(211, 22)
        Me.txt_stschg_usr.TabIndex = 542
        Me.txt_stschg_usr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(3, 39)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(26, 12)
        Me.Label21.TabIndex = 541
        Me.Label21.Text = "User"
        '
        'cmd_attch
        '
        Me.cmd_attch.Location = New System.Drawing.Point(427, 52)
        Me.cmd_attch.Name = "cmd_attch"
        Me.cmd_attch.Size = New System.Drawing.Size(98, 23)
        Me.cmd_attch.TabIndex = 534
        Me.cmd_attch.TabStop = False
        Me.cmd_attch.Text = "Attachment"
        '
        'menuStrip
        '
        Me.menuStrip.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdAdd, Me.mmdSave, Me.mmdDelete, Me.mmdCopy, Me.mmdFind, Me.t1, Me.mmdClear, Me.t2, Me.mmdSearch, Me.t3, Me.mmdInsRow, Me.mmdDelRow, Me.t4, Me.mmdPrint, Me.t5, Me.mmdAttach, Me.t6, Me.mmdFunction, Me.t7, Me.mmdLink, Me.t8, Me.mmdExit})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuStrip.Size = New System.Drawing.Size(954, 24)
        Me.menuStrip.TabIndex = 2113
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
        Me.mmdInsRow.Size = New System.Drawing.Size(84, 20)
        Me.mmdInsRow.Text = "&Quick Insert"
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
        'btcCLM00001
        '
        Me.btcCLM00001.Controls.Add(Me.tpCLM00001_1)
        Me.btcCLM00001.Controls.Add(Me.tpCLM00001_2)
        Me.btcCLM00001.Controls.Add(Me.tpCLM00001_3)
        Me.btcCLM00001.Controls.Add(Me.tpCLM00001_4)
        Me.btcCLM00001.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.btcCLM00001.Location = New System.Drawing.Point(0, 56)
        Me.btcCLM00001.Name = "btcCLM00001"
        Me.btcCLM00001.SelectedIndex = 0
        Me.btcCLM00001.Size = New System.Drawing.Size(954, 550)
        Me.btcCLM00001.TabIndex = 44
        '
        'tpCLM00001_1
        '
        Me.tpCLM00001_1.Controls.Add(Me.GroupBox2)
        Me.tpCLM00001_1.Controls.Add(Me.txt_Hdr_Finding)
        Me.tpCLM00001_1.Controls.Add(Me.GroupBox1)
        Me.tpCLM00001_1.Controls.Add(Me.Label25)
        Me.tpCLM00001_1.Controls.Add(Me.GroupBox3)
        Me.tpCLM00001_1.Controls.Add(Me.chkwait)
        Me.tpCLM00001_1.Controls.Add(Me.lbl_Hdr_Finding)
        Me.tpCLM00001_1.Controls.Add(Me.lbl_Hdr_CustComment)
        Me.tpCLM00001_1.Controls.Add(Me.CmdViewReason)
        Me.tpCLM00001_1.Controls.Add(Me.gbClaimAmtPer)
        Me.tpCLM00001_1.Controls.Add(Me.chkCancel)
        Me.tpCLM00001_1.Controls.Add(Me.cboClaimType)
        Me.tpCLM00001_1.Controls.Add(Me.txt_Hdr_CustComment)
        Me.tpCLM00001_1.Controls.Add(Me.cmd_Hdr_Apv2)
        Me.tpCLM00001_1.Controls.Add(Me.cboCoCde)
        Me.tpCLM00001_1.Controls.Add(Me.Label1)
        Me.tpCLM00001_1.Controls.Add(Me.txt_Hdr_Rmk)
        Me.tpCLM00001_1.Controls.Add(Me.gb_Hdr_ClaimAmt)
        Me.tpCLM00001_1.Controls.Add(Me.cmd_Hdr_Apv1)
        Me.tpCLM00001_1.Controls.Add(Me.txtSalesManager)
        Me.tpCLM00001_1.Controls.Add(Me.txtSalesTeam)
        Me.tpCLM00001_1.Controls.Add(Me.gb_Hdr_ClaimTo)
        Me.tpCLM00001_1.Controls.Add(Me.txt_Hdr_RemainClaim_Ttl)
        Me.tpCLM00001_1.Controls.Add(Me.lblSalesManager)
        Me.tpCLM00001_1.Controls.Add(Me.lblSalesTeam)
        Me.tpCLM00001_1.Controls.Add(Me.cbo_Hdr_RemainClaimCurrency)
        Me.tpCLM00001_1.Controls.Add(Me.lbl_Hdr_Rmk)
        Me.tpCLM00001_1.Controls.Add(Me.lblClaimType)
        Me.tpCLM00001_1.Controls.Add(Me.lbl_Hdr_RemainClaim)
        Me.tpCLM00001_1.Controls.Add(Me.gbClaimBy)
        Me.tpCLM00001_1.Controls.Add(Me.cbo_Hdr_SalesAmtCurrency)
        Me.tpCLM00001_1.Controls.Add(Me.lbl_Hdr_SalesAmt)
        Me.tpCLM00001_1.Controls.Add(Me.lbl_Hdr_AppLmtChk)
        Me.tpCLM00001_1.Controls.Add(Me.lbl_Hdr_AppLmtChkPer_Ttl)
        Me.tpCLM00001_1.Controls.Add(Me.cbo_Hdr_AppLmtChkCurrency)
        Me.tpCLM00001_1.Controls.Add(Me.txt_Hdr_SalesAmt_Ttl)
        Me.tpCLM00001_1.Controls.Add(Me.txt_Hdr_AppLmtChk_Ttl)
        Me.tpCLM00001_1.Location = New System.Drawing.Point(4, 22)
        Me.tpCLM00001_1.Name = "tpCLM00001_1"
        Me.tpCLM00001_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCLM00001_1.Size = New System.Drawing.Size(946, 524)
        Me.tpCLM00001_1.TabIndex = 0
        Me.tpCLM00001_1.Text = "(1) Customer"
        Me.tpCLM00001_1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtReplaceClaimNo)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(481, 79)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(326, 37)
        Me.GroupBox2.TabIndex = 1001
        Me.GroupBox2.TabStop = False
        '
        'txtReplaceClaimNo
        '
        Me.txtReplaceClaimNo.Location = New System.Drawing.Point(83, 12)
        Me.txtReplaceClaimNo.Name = "txtReplaceClaimNo"
        Me.txtReplaceClaimNo.Size = New System.Drawing.Size(237, 22)
        Me.txtReplaceClaimNo.TabIndex = 34
        Me.txtReplaceClaimNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(2, 15)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(76, 12)
        Me.Label28.TabIndex = 541
        Me.Label28.Text = "Replace Clam#"
        '
        'txt_Hdr_Finding
        '
        Me.txt_Hdr_Finding.Location = New System.Drawing.Point(124, 338)
        Me.txt_Hdr_Finding.Name = "txt_Hdr_Finding"
        Me.txt_Hdr_Finding.Size = New System.Drawing.Size(351, 50)
        Me.txt_Hdr_Finding.TabIndex = 30
        Me.txt_Hdr_Finding.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkvalidclm)
        Me.GroupBox1.Controls.Add(Me.chkconfirmclm)
        Me.GroupBox1.Location = New System.Drawing.Point(125, 117)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(350, 31)
        Me.GroupBox1.TabIndex = 999
        Me.GroupBox1.TabStop = False
        '
        'chkvalidclm
        '
        Me.chkvalidclm.AutoSize = True
        Me.chkvalidclm.Location = New System.Drawing.Point(180, 10)
        Me.chkvalidclm.Name = "chkvalidclm"
        Me.chkvalidclm.Size = New System.Drawing.Size(79, 16)
        Me.chkvalidclm.TabIndex = 999
        Me.chkvalidclm.Text = "Valid Claim"
        Me.chkvalidclm.UseVisualStyleBackColor = True
        '
        'chkconfirmclm
        '
        Me.chkconfirmclm.AutoSize = True
        Me.chkconfirmclm.Location = New System.Drawing.Point(58, 11)
        Me.chkconfirmclm.Name = "chkconfirmclm"
        Me.chkconfirmclm.Size = New System.Drawing.Size(94, 16)
        Me.chkconfirmclm.TabIndex = 38
        Me.chkconfirmclm.Text = "Potential Claim"
        Me.chkconfirmclm.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.Green
        Me.Label25.Location = New System.Drawing.Point(15, 126)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(58, 12)
        Me.Label25.TabIndex = 541
        Me.Label25.Text = "Claim Case"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dt_ref_date)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.txt_ref_no)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(481, 7)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(326, 72)
        Me.GroupBox3.TabIndex = 32
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Customer / Vendor Claim"
        '
        'dt_ref_date
        '
        Me.dt_ref_date.CustomFormat = "MM/dd/yyyy"
        Me.dt_ref_date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_ref_date.Location = New System.Drawing.Point(83, 47)
        Me.dt_ref_date.MaxDate = New Date(2999, 12, 31, 0, 0, 0, 0)
        Me.dt_ref_date.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dt_ref_date.Name = "dt_ref_date"
        Me.dt_ref_date.Size = New System.Drawing.Size(86, 22)
        Me.dt_ref_date.TabIndex = 33
        Me.dt_ref_date.Value = New Date(2014, 3, 1, 0, 0, 0, 0)
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(3, 50)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(26, 12)
        Me.Label19.TabIndex = 543
        Me.Label19.Text = "Date"
        '
        'txt_ref_no
        '
        Me.txt_ref_no.Location = New System.Drawing.Point(83, 20)
        Me.txt_ref_no.Name = "txt_ref_no"
        Me.txt_ref_no.Size = New System.Drawing.Size(237, 22)
        Me.txt_ref_no.TabIndex = 32
        Me.txt_ref_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(2, 23)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 12)
        Me.Label18.TabIndex = 541
        Me.Label18.Text = "Reference"
        '
        'chkwait
        '
        Me.chkwait.AutoSize = True
        Me.chkwait.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkwait.ForeColor = System.Drawing.Color.Black
        Me.chkwait.Location = New System.Drawing.Point(821, 8)
        Me.chkwait.Name = "chkwait"
        Me.chkwait.Size = New System.Drawing.Size(117, 17)
        Me.chkwait.TabIndex = 998
        Me.chkwait.Text = "Ready for Approval"
        Me.chkwait.UseVisualStyleBackColor = True
        '
        'lbl_Hdr_Finding
        '
        Me.lbl_Hdr_Finding.AutoSize = True
        Me.lbl_Hdr_Finding.Location = New System.Drawing.Point(15, 341)
        Me.lbl_Hdr_Finding.Name = "lbl_Hdr_Finding"
        Me.lbl_Hdr_Finding.Size = New System.Drawing.Size(45, 12)
        Me.lbl_Hdr_Finding.TabIndex = 128
        Me.lbl_Hdr_Finding.Text = "Findings"
        '
        'lbl_Hdr_CustComment
        '
        Me.lbl_Hdr_CustComment.Location = New System.Drawing.Point(15, 288)
        Me.lbl_Hdr_CustComment.Name = "lbl_Hdr_CustComment"
        Me.lbl_Hdr_CustComment.Size = New System.Drawing.Size(55, 41)
        Me.lbl_Hdr_CustComment.TabIndex = 127
        Me.lbl_Hdr_CustComment.Text = "Customer Comment"
        '
        'CmdViewReason
        '
        Me.CmdViewReason.Location = New System.Drawing.Point(822, 92)
        Me.CmdViewReason.Name = "CmdViewReason"
        Me.CmdViewReason.Size = New System.Drawing.Size(87, 22)
        Me.CmdViewReason.TabIndex = 532
        Me.CmdViewReason.TabStop = False
        Me.CmdViewReason.Text = "Cancel Reason"
        '
        'gbClaimAmtPer
        '
        Me.gbClaimAmtPer.Controls.Add(Me.chkreplace)
        Me.gbClaimAmtPer.Controls.Add(Me.Label24)
        Me.gbClaimAmtPer.Controls.Add(Me.lblClaimAmtPer)
        Me.gbClaimAmtPer.Controls.Add(Me.rbClaimAmtPer_C)
        Me.gbClaimAmtPer.Controls.Add(Me.rbClaimAmtPer_I)
        Me.gbClaimAmtPer.Controls.Add(Me.rbClaimAmtPer_S)
        Me.gbClaimAmtPer.Enabled = False
        Me.gbClaimAmtPer.Location = New System.Drawing.Point(8, 143)
        Me.gbClaimAmtPer.Name = "gbClaimAmtPer"
        Me.gbClaimAmtPer.Size = New System.Drawing.Size(467, 53)
        Me.gbClaimAmtPer.TabIndex = 24
        Me.gbClaimAmtPer.TabStop = False
        '
        'chkreplace
        '
        Me.chkreplace.AutoSize = True
        Me.chkreplace.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkreplace.Location = New System.Drawing.Point(120, 33)
        Me.chkreplace.Name = "chkreplace"
        Me.chkreplace.Size = New System.Drawing.Size(89, 17)
        Me.chkreplace.TabIndex = 541
        Me.chkreplace.Text = "Replacement"
        Me.chkreplace.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(6, 33)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(76, 12)
        Me.Label24.TabIndex = 49
        Me.Label24.Text = "Claim Quantity"
        '
        'lblClaimAmtPer
        '
        Me.lblClaimAmtPer.AutoSize = True
        Me.lblClaimAmtPer.ForeColor = System.Drawing.Color.Green
        Me.lblClaimAmtPer.Location = New System.Drawing.Point(6, 11)
        Me.lblClaimAmtPer.Name = "lblClaimAmtPer"
        Me.lblClaimAmtPer.Size = New System.Drawing.Size(92, 12)
        Me.lblClaimAmtPer.TabIndex = 48
        Me.lblClaimAmtPer.Text = "Claim Amount Per"
        '
        'rbClaimAmtPer_C
        '
        Me.rbClaimAmtPer_C.AutoSize = True
        Me.rbClaimAmtPer_C.Location = New System.Drawing.Point(292, 10)
        Me.rbClaimAmtPer_C.Name = "rbClaimAmtPer_C"
        Me.rbClaimAmtPer_C.Size = New System.Drawing.Size(68, 16)
        Me.rbClaimAmtPer_C.TabIndex = 25
        Me.rbClaimAmtPer_C.Text = "Customer"
        Me.rbClaimAmtPer_C.UseVisualStyleBackColor = True
        '
        'rbClaimAmtPer_I
        '
        Me.rbClaimAmtPer_I.AutoSize = True
        Me.rbClaimAmtPer_I.Checked = True
        Me.rbClaimAmtPer_I.Location = New System.Drawing.Point(120, 11)
        Me.rbClaimAmtPer_I.Name = "rbClaimAmtPer_I"
        Me.rbClaimAmtPer_I.Size = New System.Drawing.Size(44, 16)
        Me.rbClaimAmtPer_I.TabIndex = 26
        Me.rbClaimAmtPer_I.TabStop = True
        Me.rbClaimAmtPer_I.Text = "Item"
        Me.rbClaimAmtPer_I.UseVisualStyleBackColor = True
        '
        'rbClaimAmtPer_S
        '
        Me.rbClaimAmtPer_S.AutoSize = True
        Me.rbClaimAmtPer_S.Location = New System.Drawing.Point(196, 11)
        Me.rbClaimAmtPer_S.Name = "rbClaimAmtPer_S"
        Me.rbClaimAmtPer_S.Size = New System.Drawing.Size(67, 16)
        Me.rbClaimAmtPer_S.TabIndex = 27
        Me.rbClaimAmtPer_S.Text = "Shipment"
        Me.rbClaimAmtPer_S.UseVisualStyleBackColor = True
        '
        'chkCancel
        '
        Me.chkCancel.AutoSize = True
        Me.chkCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkCancel.ForeColor = System.Drawing.Color.Black
        Me.chkCancel.Location = New System.Drawing.Point(823, 68)
        Me.chkCancel.Name = "chkCancel"
        Me.chkCancel.Size = New System.Drawing.Size(87, 17)
        Me.chkCancel.TabIndex = 279
        Me.chkCancel.Text = "Cancel Claim"
        Me.chkCancel.UseVisualStyleBackColor = True
        '
        'cboClaimType
        '
        Me.cboClaimType.FormattingEnabled = True
        Me.cboClaimType.Location = New System.Drawing.Point(125, 208)
        Me.cboClaimType.Name = "cboClaimType"
        Me.cboClaimType.Size = New System.Drawing.Size(350, 20)
        Me.cboClaimType.TabIndex = 28
        '
        'txt_Hdr_CustComment
        '
        Me.txt_Hdr_CustComment.Location = New System.Drawing.Point(125, 286)
        Me.txt_Hdr_CustComment.Name = "txt_Hdr_CustComment"
        Me.txt_Hdr_CustComment.Size = New System.Drawing.Size(351, 50)
        Me.txt_Hdr_CustComment.TabIndex = 29
        Me.txt_Hdr_CustComment.Text = ""
        '
        'cmd_Hdr_Apv2
        '
        Me.cmd_Hdr_Apv2.AutoSize = True
        Me.cmd_Hdr_Apv2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Hdr_Apv2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_Hdr_Apv2.Location = New System.Drawing.Point(376, 462)
        Me.cmd_Hdr_Apv2.Name = "cmd_Hdr_Apv2"
        Me.cmd_Hdr_Apv2.Size = New System.Drawing.Size(90, 40)
        Me.cmd_Hdr_Apv2.TabIndex = 40
        Me.cmd_Hdr_Apv2.Text = "Approval 2"
        Me.cmd_Hdr_Apv2.UseVisualStyleBackColor = True
        Me.cmd_Hdr_Apv2.Visible = False
        '
        'cboCoCde
        '
        Me.cboCoCde.Enabled = False
        Me.cboCoCde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(50, 446)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(87, 21)
        Me.cboCoCde.TabIndex = 38
        Me.cboCoCde.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label1.Location = New System.Drawing.Point(37, 447)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Company Code:"
        Me.Label1.Visible = False
        '
        'txt_Hdr_Rmk
        '
        Me.txt_Hdr_Rmk.Location = New System.Drawing.Point(125, 390)
        Me.txt_Hdr_Rmk.Name = "txt_Hdr_Rmk"
        Me.txt_Hdr_Rmk.Size = New System.Drawing.Size(350, 126)
        Me.txt_Hdr_Rmk.TabIndex = 31
        Me.txt_Hdr_Rmk.Text = ""
        '
        'gb_Hdr_ClaimAmt
        '
        Me.gb_Hdr_ClaimAmt.Controls.Add(Me.chkapv3a)
        Me.gb_Hdr_ClaimAmt.Controls.Add(Me.chkapv1a)
        Me.gb_Hdr_ClaimAmt.Controls.Add(Me.lbl_Hdr_ClaimAmt)
        Me.gb_Hdr_ClaimAmt.Controls.Add(Me.lbl_Hdr_ExceedAppLmt)
        Me.gb_Hdr_ClaimAmt.Controls.Add(Me.chkapv2a)
        Me.gb_Hdr_ClaimAmt.Controls.Add(Me.Label16)
        Me.gb_Hdr_ClaimAmt.Controls.Add(Me.lbl_Hdr_FinalClaimAmt)
        Me.gb_Hdr_ClaimAmt.Controls.Add(Me.txt_cmt_a)
        Me.gb_Hdr_ClaimAmt.Controls.Add(Me.lbl_Hdr_OrgClaimAmt)
        Me.gb_Hdr_ClaimAmt.Controls.Add(Me.txt_Hdr_OrgClaimAmt)
        Me.gb_Hdr_ClaimAmt.Controls.Add(Me.cbo_Hdr_ClaimAmtCurrency)
        Me.gb_Hdr_ClaimAmt.Controls.Add(Me.txt_Hdr_FinalClaimAmt)
        Me.gb_Hdr_ClaimAmt.ForeColor = System.Drawing.Color.Black
        Me.gb_Hdr_ClaimAmt.Location = New System.Drawing.Point(481, 118)
        Me.gb_Hdr_ClaimAmt.Name = "gb_Hdr_ClaimAmt"
        Me.gb_Hdr_ClaimAmt.Size = New System.Drawing.Size(457, 150)
        Me.gb_Hdr_ClaimAmt.TabIndex = 39
        Me.gb_Hdr_ClaimAmt.TabStop = False
        Me.gb_Hdr_ClaimAmt.Text = "Claim Amount"
        '
        'chkapv3a
        '
        Me.chkapv3a.AutoSize = True
        Me.chkapv3a.Location = New System.Drawing.Point(379, 70)
        Me.chkapv3a.Name = "chkapv3a"
        Me.chkapv3a.Size = New System.Drawing.Size(57, 16)
        Me.chkapv3a.TabIndex = 536
        Me.chkapv3a.Text = "APV3a"
        Me.chkapv3a.UseVisualStyleBackColor = True
        '
        'chkapv1a
        '
        Me.chkapv1a.AutoSize = True
        Me.chkapv1a.Location = New System.Drawing.Point(378, 24)
        Me.chkapv1a.Name = "chkapv1a"
        Me.chkapv1a.Size = New System.Drawing.Size(57, 16)
        Me.chkapv1a.TabIndex = 534
        Me.chkapv1a.Text = "APV1a"
        Me.chkapv1a.UseVisualStyleBackColor = True
        '
        'lbl_Hdr_ClaimAmt
        '
        Me.lbl_Hdr_ClaimAmt.AutoSize = True
        Me.lbl_Hdr_ClaimAmt.Location = New System.Drawing.Point(15, 54)
        Me.lbl_Hdr_ClaimAmt.Name = "lbl_Hdr_ClaimAmt"
        Me.lbl_Hdr_ClaimAmt.Size = New System.Drawing.Size(43, 12)
        Me.lbl_Hdr_ClaimAmt.TabIndex = 87
        Me.lbl_Hdr_ClaimAmt.Text = "Amount"
        '
        'lbl_Hdr_ExceedAppLmt
        '
        Me.lbl_Hdr_ExceedAppLmt.AutoSize = True
        Me.lbl_Hdr_ExceedAppLmt.ForeColor = System.Drawing.Color.Crimson
        Me.lbl_Hdr_ExceedAppLmt.Location = New System.Drawing.Point(9, 26)
        Me.lbl_Hdr_ExceedAppLmt.Name = "lbl_Hdr_ExceedAppLmt"
        Me.lbl_Hdr_ExceedAppLmt.Size = New System.Drawing.Size(113, 12)
        Me.lbl_Hdr_ExceedAppLmt.TabIndex = 86
        Me.lbl_Hdr_ExceedAppLmt.Text = "(exceed approval limit)"
        '
        'chkapv2a
        '
        Me.chkapv2a.AutoSize = True
        Me.chkapv2a.Location = New System.Drawing.Point(379, 47)
        Me.chkapv2a.Name = "chkapv2a"
        Me.chkapv2a.Size = New System.Drawing.Size(57, 16)
        Me.chkapv2a.TabIndex = 537
        Me.chkapv2a.Text = "APV2a"
        Me.chkapv2a.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(15, 92)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 24)
        Me.Label16.TabIndex = 537
        Me.Label16.Text = "Approval A" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Comment" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lbl_Hdr_FinalClaimAmt
        '
        Me.lbl_Hdr_FinalClaimAmt.AutoSize = True
        Me.lbl_Hdr_FinalClaimAmt.ForeColor = System.Drawing.Color.Black
        Me.lbl_Hdr_FinalClaimAmt.Location = New System.Drawing.Point(275, 36)
        Me.lbl_Hdr_FinalClaimAmt.Name = "lbl_Hdr_FinalClaimAmt"
        Me.lbl_Hdr_FinalClaimAmt.Size = New System.Drawing.Size(47, 12)
        Me.lbl_Hdr_FinalClaimAmt.TabIndex = 82
        Me.lbl_Hdr_FinalClaimAmt.Text = "Finalized"
        '
        'txt_cmt_a
        '
        Me.txt_cmt_a.Location = New System.Drawing.Point(97, 92)
        Me.txt_cmt_a.Name = "txt_cmt_a"
        Me.txt_cmt_a.Size = New System.Drawing.Size(354, 52)
        Me.txt_cmt_a.TabIndex = 536
        Me.txt_cmt_a.Text = ""
        '
        'lbl_Hdr_OrgClaimAmt
        '
        Me.lbl_Hdr_OrgClaimAmt.AutoSize = True
        Me.lbl_Hdr_OrgClaimAmt.ForeColor = System.Drawing.Color.Black
        Me.lbl_Hdr_OrgClaimAmt.Location = New System.Drawing.Point(173, 35)
        Me.lbl_Hdr_OrgClaimAmt.Name = "lbl_Hdr_OrgClaimAmt"
        Me.lbl_Hdr_OrgClaimAmt.Size = New System.Drawing.Size(48, 12)
        Me.lbl_Hdr_OrgClaimAmt.TabIndex = 81
        Me.lbl_Hdr_OrgClaimAmt.Text = "Proposed"
        '
        'txt_Hdr_OrgClaimAmt
        '
        Me.txt_Hdr_OrgClaimAmt.Location = New System.Drawing.Point(148, 52)
        Me.txt_Hdr_OrgClaimAmt.Name = "txt_Hdr_OrgClaimAmt"
        Me.txt_Hdr_OrgClaimAmt.Size = New System.Drawing.Size(101, 22)
        Me.txt_Hdr_OrgClaimAmt.TabIndex = 36
        Me.txt_Hdr_OrgClaimAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbo_Hdr_ClaimAmtCurrency
        '
        Me.cbo_Hdr_ClaimAmtCurrency.DisplayMember = "HKD"
        Me.cbo_Hdr_ClaimAmtCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Hdr_ClaimAmtCurrency.FormattingEnabled = True
        Me.cbo_Hdr_ClaimAmtCurrency.Location = New System.Drawing.Point(96, 53)
        Me.cbo_Hdr_ClaimAmtCurrency.Name = "cbo_Hdr_ClaimAmtCurrency"
        Me.cbo_Hdr_ClaimAmtCurrency.Size = New System.Drawing.Size(52, 20)
        Me.cbo_Hdr_ClaimAmtCurrency.TabIndex = 35
        '
        'txt_Hdr_FinalClaimAmt
        '
        Me.txt_Hdr_FinalClaimAmt.Location = New System.Drawing.Point(249, 52)
        Me.txt_Hdr_FinalClaimAmt.Name = "txt_Hdr_FinalClaimAmt"
        Me.txt_Hdr_FinalClaimAmt.Size = New System.Drawing.Size(87, 22)
        Me.txt_Hdr_FinalClaimAmt.TabIndex = 37
        Me.txt_Hdr_FinalClaimAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmd_Hdr_Apv1
        '
        Me.cmd_Hdr_Apv1.AutoSize = True
        Me.cmd_Hdr_Apv1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Hdr_Apv1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_Hdr_Apv1.Location = New System.Drawing.Point(376, 462)
        Me.cmd_Hdr_Apv1.Name = "cmd_Hdr_Apv1"
        Me.cmd_Hdr_Apv1.Size = New System.Drawing.Size(90, 40)
        Me.cmd_Hdr_Apv1.TabIndex = 39
        Me.cmd_Hdr_Apv1.Text = "Approval 1"
        Me.cmd_Hdr_Apv1.UseVisualStyleBackColor = True
        Me.cmd_Hdr_Apv1.Visible = False
        '
        'txtSalesManager
        '
        Me.txtSalesManager.Location = New System.Drawing.Point(125, 237)
        Me.txtSalesManager.Name = "txtSalesManager"
        Me.txtSalesManager.Size = New System.Drawing.Size(350, 22)
        Me.txtSalesManager.TabIndex = 929
        '
        'txtSalesTeam
        '
        Me.txtSalesTeam.Location = New System.Drawing.Point(125, 261)
        Me.txtSalesTeam.Name = "txtSalesTeam"
        Me.txtSalesTeam.Size = New System.Drawing.Size(350, 22)
        Me.txtSalesTeam.TabIndex = 930
        '
        'gb_Hdr_ClaimTo
        '
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.lbl_amt_cur)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.Label26)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.txt_org_dif)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.txt_final_dif)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.cbo_Hdr_ClaimToHKOAmtCur)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.cbo_Hdr_ClaimToVNAmtCur)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.cbo_Hdr_ClaimToInsAmtCur)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.txt_Hdr_ClaimToInsAmt_ori)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.txt_Hdr_ClaimToVNAmt_ori)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.chkapv1b)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.Label17)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.txt_Hdr_ClaimToHKOAmt_ori)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.txt_cmt_b)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.chkapv3b)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.lbl_Hdr_ClaimToHKOAmt_ExchRate)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.chkapv2b)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.lbl_Hdr_ClaimToVNAmt_ExchRate)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.lbl_Hdr_ClaimToInsAmt_ExchRate)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.txt_Hdr_ClaimToInsAmt)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.lbl_Hdr_ClaimToInsAmt)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.cbo_Hdr_ClaimToInsAmtCurrency)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.lbl_Hdr_ClaimToVNAmt)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.lbl_Hdr_ClaimToHKOAmt)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.cbo_Hdr_ClaimToVNAmtCurrency)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.txt_Hdr_ClaimToVNAmt)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.cbo_Hdr_ClaimToHKOAmtCurrency)
        Me.gb_Hdr_ClaimTo.Controls.Add(Me.txt_Hdr_ClaimToHKOAmt)
        Me.gb_Hdr_ClaimTo.ForeColor = System.Drawing.Color.Black
        Me.gb_Hdr_ClaimTo.Location = New System.Drawing.Point(481, 274)
        Me.gb_Hdr_ClaimTo.Name = "gb_Hdr_ClaimTo"
        Me.gb_Hdr_ClaimTo.Size = New System.Drawing.Size(457, 242)
        Me.gb_Hdr_ClaimTo.TabIndex = 36
        Me.gb_Hdr_ClaimTo.TabStop = False
        Me.gb_Hdr_ClaimTo.Text = "Total Claim To"
        '
        'lbl_amt_cur
        '
        Me.lbl_amt_cur.AutoSize = True
        Me.lbl_amt_cur.Enabled = False
        Me.lbl_amt_cur.Location = New System.Drawing.Point(109, 106)
        Me.lbl_amt_cur.Name = "lbl_amt_cur"
        Me.lbl_amt_cur.Size = New System.Drawing.Size(27, 12)
        Me.lbl_amt_cur.TabIndex = 545
        Me.lbl_amt_cur.Text = "USD"
        Me.lbl_amt_cur.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Enabled = False
        Me.Label26.Location = New System.Drawing.Point(9, 110)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(54, 12)
        Me.Label26.TabIndex = 544
        Me.Label26.Text = "Difference"
        Me.Label26.Visible = False
        '
        'txt_org_dif
        '
        Me.txt_org_dif.Enabled = False
        Me.txt_org_dif.Location = New System.Drawing.Point(155, 104)
        Me.txt_org_dif.Name = "txt_org_dif"
        Me.txt_org_dif.Size = New System.Drawing.Size(73, 22)
        Me.txt_org_dif.TabIndex = 542
        Me.txt_org_dif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_org_dif.Visible = False
        '
        'txt_final_dif
        '
        Me.txt_final_dif.Enabled = False
        Me.txt_final_dif.Location = New System.Drawing.Point(228, 104)
        Me.txt_final_dif.Name = "txt_final_dif"
        Me.txt_final_dif.Size = New System.Drawing.Size(73, 22)
        Me.txt_final_dif.TabIndex = 543
        Me.txt_final_dif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_final_dif.Visible = False
        '
        'cbo_Hdr_ClaimToHKOAmtCur
        '
        Me.cbo_Hdr_ClaimToHKOAmtCur.DisplayMember = "HKD"
        Me.cbo_Hdr_ClaimToHKOAmtCur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Hdr_ClaimToHKOAmtCur.FormattingEnabled = True
        Me.cbo_Hdr_ClaimToHKOAmtCur.Location = New System.Drawing.Point(103, 78)
        Me.cbo_Hdr_ClaimToHKOAmtCur.Name = "cbo_Hdr_ClaimToHKOAmtCur"
        Me.cbo_Hdr_ClaimToHKOAmtCur.Size = New System.Drawing.Size(52, 20)
        Me.cbo_Hdr_ClaimToHKOAmtCur.TabIndex = 541
        '
        'cbo_Hdr_ClaimToVNAmtCur
        '
        Me.cbo_Hdr_ClaimToVNAmtCur.DisplayMember = "HKD"
        Me.cbo_Hdr_ClaimToVNAmtCur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Hdr_ClaimToVNAmtCur.FormattingEnabled = True
        Me.cbo_Hdr_ClaimToVNAmtCur.Location = New System.Drawing.Point(103, 51)
        Me.cbo_Hdr_ClaimToVNAmtCur.Name = "cbo_Hdr_ClaimToVNAmtCur"
        Me.cbo_Hdr_ClaimToVNAmtCur.Size = New System.Drawing.Size(52, 20)
        Me.cbo_Hdr_ClaimToVNAmtCur.TabIndex = 540
        '
        'cbo_Hdr_ClaimToInsAmtCur
        '
        Me.cbo_Hdr_ClaimToInsAmtCur.DisplayMember = "HKD"
        Me.cbo_Hdr_ClaimToInsAmtCur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Hdr_ClaimToInsAmtCur.FormattingEnabled = True
        Me.cbo_Hdr_ClaimToInsAmtCur.Location = New System.Drawing.Point(103, 25)
        Me.cbo_Hdr_ClaimToInsAmtCur.Name = "cbo_Hdr_ClaimToInsAmtCur"
        Me.cbo_Hdr_ClaimToInsAmtCur.Size = New System.Drawing.Size(52, 20)
        Me.cbo_Hdr_ClaimToInsAmtCur.TabIndex = 538
        '
        'txt_Hdr_ClaimToInsAmt_ori
        '
        Me.txt_Hdr_ClaimToInsAmt_ori.Location = New System.Drawing.Point(155, 25)
        Me.txt_Hdr_ClaimToInsAmt_ori.Name = "txt_Hdr_ClaimToInsAmt_ori"
        Me.txt_Hdr_ClaimToInsAmt_ori.Size = New System.Drawing.Size(73, 22)
        Me.txt_Hdr_ClaimToInsAmt_ori.TabIndex = 36
        Me.txt_Hdr_ClaimToInsAmt_ori.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Hdr_ClaimToVNAmt_ori
        '
        Me.txt_Hdr_ClaimToVNAmt_ori.Location = New System.Drawing.Point(155, 51)
        Me.txt_Hdr_ClaimToVNAmt_ori.Name = "txt_Hdr_ClaimToVNAmt_ori"
        Me.txt_Hdr_ClaimToVNAmt_ori.Size = New System.Drawing.Size(73, 22)
        Me.txt_Hdr_ClaimToVNAmt_ori.TabIndex = 37
        Me.txt_Hdr_ClaimToVNAmt_ori.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkapv1b
        '
        Me.chkapv1b.AutoSize = True
        Me.chkapv1b.Location = New System.Drawing.Point(322, 26)
        Me.chkapv1b.Name = "chkapv1b"
        Me.chkapv1b.Size = New System.Drawing.Size(58, 16)
        Me.chkapv1b.TabIndex = 535
        Me.chkapv1b.Text = "APV1b"
        Me.chkapv1b.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 125)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 24)
        Me.Label17.TabIndex = 539
        Me.Label17.Text = "Approval B" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Comment"
        '
        'txt_Hdr_ClaimToHKOAmt_ori
        '
        Me.txt_Hdr_ClaimToHKOAmt_ori.Location = New System.Drawing.Point(155, 78)
        Me.txt_Hdr_ClaimToHKOAmt_ori.Name = "txt_Hdr_ClaimToHKOAmt_ori"
        Me.txt_Hdr_ClaimToHKOAmt_ori.Size = New System.Drawing.Size(73, 22)
        Me.txt_Hdr_ClaimToHKOAmt_ori.TabIndex = 38
        Me.txt_Hdr_ClaimToHKOAmt_ori.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_cmt_b
        '
        Me.txt_cmt_b.Location = New System.Drawing.Point(93, 111)
        Me.txt_cmt_b.Name = "txt_cmt_b"
        Me.txt_cmt_b.Size = New System.Drawing.Size(358, 125)
        Me.txt_cmt_b.TabIndex = 43
        Me.txt_cmt_b.Text = ""
        '
        'chkapv3b
        '
        Me.chkapv3b.AutoSize = True
        Me.chkapv3b.Location = New System.Drawing.Point(322, 77)
        Me.chkapv3b.Name = "chkapv3b"
        Me.chkapv3b.Size = New System.Drawing.Size(58, 16)
        Me.chkapv3b.TabIndex = 539
        Me.chkapv3b.Text = "APV3b"
        Me.chkapv3b.UseVisualStyleBackColor = True
        '
        'lbl_Hdr_ClaimToHKOAmt_ExchRate
        '
        Me.lbl_Hdr_ClaimToHKOAmt_ExchRate.AutoSize = True
        Me.lbl_Hdr_ClaimToHKOAmt_ExchRate.Location = New System.Drawing.Point(150, 89)
        Me.lbl_Hdr_ClaimToHKOAmt_ExchRate.Name = "lbl_Hdr_ClaimToHKOAmt_ExchRate"
        Me.lbl_Hdr_ClaimToHKOAmt_ExchRate.Size = New System.Drawing.Size(0, 12)
        Me.lbl_Hdr_ClaimToHKOAmt_ExchRate.TabIndex = 57
        Me.lbl_Hdr_ClaimToHKOAmt_ExchRate.Visible = False
        '
        'chkapv2b
        '
        Me.chkapv2b.AutoSize = True
        Me.chkapv2b.Location = New System.Drawing.Point(322, 52)
        Me.chkapv2b.Name = "chkapv2b"
        Me.chkapv2b.Size = New System.Drawing.Size(58, 16)
        Me.chkapv2b.TabIndex = 538
        Me.chkapv2b.Text = "APV2b"
        Me.chkapv2b.UseVisualStyleBackColor = True
        '
        'lbl_Hdr_ClaimToVNAmt_ExchRate
        '
        Me.lbl_Hdr_ClaimToVNAmt_ExchRate.AutoSize = True
        Me.lbl_Hdr_ClaimToVNAmt_ExchRate.Location = New System.Drawing.Point(150, 62)
        Me.lbl_Hdr_ClaimToVNAmt_ExchRate.Name = "lbl_Hdr_ClaimToVNAmt_ExchRate"
        Me.lbl_Hdr_ClaimToVNAmt_ExchRate.Size = New System.Drawing.Size(0, 12)
        Me.lbl_Hdr_ClaimToVNAmt_ExchRate.TabIndex = 55
        Me.lbl_Hdr_ClaimToVNAmt_ExchRate.Visible = False
        '
        'lbl_Hdr_ClaimToInsAmt_ExchRate
        '
        Me.lbl_Hdr_ClaimToInsAmt_ExchRate.AutoSize = True
        Me.lbl_Hdr_ClaimToInsAmt_ExchRate.Location = New System.Drawing.Point(150, 36)
        Me.lbl_Hdr_ClaimToInsAmt_ExchRate.Name = "lbl_Hdr_ClaimToInsAmt_ExchRate"
        Me.lbl_Hdr_ClaimToInsAmt_ExchRate.Size = New System.Drawing.Size(0, 12)
        Me.lbl_Hdr_ClaimToInsAmt_ExchRate.TabIndex = 54
        Me.lbl_Hdr_ClaimToInsAmt_ExchRate.Visible = False
        '
        'txt_Hdr_ClaimToInsAmt
        '
        Me.txt_Hdr_ClaimToInsAmt.Location = New System.Drawing.Point(228, 25)
        Me.txt_Hdr_ClaimToInsAmt.Name = "txt_Hdr_ClaimToInsAmt"
        Me.txt_Hdr_ClaimToInsAmt.Size = New System.Drawing.Size(73, 22)
        Me.txt_Hdr_ClaimToInsAmt.TabIndex = 40
        Me.txt_Hdr_ClaimToInsAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Hdr_ClaimToInsAmt
        '
        Me.lbl_Hdr_ClaimToInsAmt.AutoSize = True
        Me.lbl_Hdr_ClaimToInsAmt.Location = New System.Drawing.Point(8, 34)
        Me.lbl_Hdr_ClaimToInsAmt.Name = "lbl_Hdr_ClaimToInsAmt"
        Me.lbl_Hdr_ClaimToInsAmt.Size = New System.Drawing.Size(91, 12)
        Me.lbl_Hdr_ClaimToInsAmt.TabIndex = 50
        Me.lbl_Hdr_ClaimToInsAmt.Text = "Customer Amount"
        '
        'cbo_Hdr_ClaimToInsAmtCurrency
        '
        Me.cbo_Hdr_ClaimToInsAmtCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Hdr_ClaimToInsAmtCurrency.Enabled = False
        Me.cbo_Hdr_ClaimToInsAmtCurrency.FormattingEnabled = True
        Me.cbo_Hdr_ClaimToInsAmtCurrency.Location = New System.Drawing.Point(393, 25)
        Me.cbo_Hdr_ClaimToInsAmtCurrency.Name = "cbo_Hdr_ClaimToInsAmtCurrency"
        Me.cbo_Hdr_ClaimToInsAmtCurrency.Size = New System.Drawing.Size(7, 20)
        Me.cbo_Hdr_ClaimToInsAmtCurrency.TabIndex = 37
        Me.cbo_Hdr_ClaimToInsAmtCurrency.Visible = False
        '
        'lbl_Hdr_ClaimToVNAmt
        '
        Me.lbl_Hdr_ClaimToVNAmt.AutoSize = True
        Me.lbl_Hdr_ClaimToVNAmt.Location = New System.Drawing.Point(8, 60)
        Me.lbl_Hdr_ClaimToVNAmt.Name = "lbl_Hdr_ClaimToVNAmt"
        Me.lbl_Hdr_ClaimToVNAmt.Size = New System.Drawing.Size(81, 12)
        Me.lbl_Hdr_ClaimToVNAmt.TabIndex = 32
        Me.lbl_Hdr_ClaimToVNAmt.Text = "Vendor Amount"
        '
        'lbl_Hdr_ClaimToHKOAmt
        '
        Me.lbl_Hdr_ClaimToHKOAmt.AutoSize = True
        Me.lbl_Hdr_ClaimToHKOAmt.Location = New System.Drawing.Point(8, 87)
        Me.lbl_Hdr_ClaimToHKOAmt.Name = "lbl_Hdr_ClaimToHKOAmt"
        Me.lbl_Hdr_ClaimToHKOAmt.Size = New System.Drawing.Size(94, 12)
        Me.lbl_Hdr_ClaimToHKOAmt.TabIndex = 35
        Me.lbl_Hdr_ClaimToHKOAmt.Text = "HK Office Amount"
        '
        'cbo_Hdr_ClaimToVNAmtCurrency
        '
        Me.cbo_Hdr_ClaimToVNAmtCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Hdr_ClaimToVNAmtCurrency.Enabled = False
        Me.cbo_Hdr_ClaimToVNAmtCurrency.FormattingEnabled = True
        Me.cbo_Hdr_ClaimToVNAmtCurrency.Location = New System.Drawing.Point(393, 51)
        Me.cbo_Hdr_ClaimToVNAmtCurrency.Name = "cbo_Hdr_ClaimToVNAmtCurrency"
        Me.cbo_Hdr_ClaimToVNAmtCurrency.Size = New System.Drawing.Size(7, 20)
        Me.cbo_Hdr_ClaimToVNAmtCurrency.TabIndex = 39
        Me.cbo_Hdr_ClaimToVNAmtCurrency.Visible = False
        '
        'txt_Hdr_ClaimToVNAmt
        '
        Me.txt_Hdr_ClaimToVNAmt.Location = New System.Drawing.Point(228, 51)
        Me.txt_Hdr_ClaimToVNAmt.Name = "txt_Hdr_ClaimToVNAmt"
        Me.txt_Hdr_ClaimToVNAmt.Size = New System.Drawing.Size(73, 22)
        Me.txt_Hdr_ClaimToVNAmt.TabIndex = 41
        Me.txt_Hdr_ClaimToVNAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbo_Hdr_ClaimToHKOAmtCurrency
        '
        Me.cbo_Hdr_ClaimToHKOAmtCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Hdr_ClaimToHKOAmtCurrency.Enabled = False
        Me.cbo_Hdr_ClaimToHKOAmtCurrency.FormattingEnabled = True
        Me.cbo_Hdr_ClaimToHKOAmtCurrency.Location = New System.Drawing.Point(393, 78)
        Me.cbo_Hdr_ClaimToHKOAmtCurrency.Name = "cbo_Hdr_ClaimToHKOAmtCurrency"
        Me.cbo_Hdr_ClaimToHKOAmtCurrency.Size = New System.Drawing.Size(7, 20)
        Me.cbo_Hdr_ClaimToHKOAmtCurrency.TabIndex = 41
        Me.cbo_Hdr_ClaimToHKOAmtCurrency.Visible = False
        '
        'txt_Hdr_ClaimToHKOAmt
        '
        Me.txt_Hdr_ClaimToHKOAmt.Location = New System.Drawing.Point(228, 78)
        Me.txt_Hdr_ClaimToHKOAmt.Name = "txt_Hdr_ClaimToHKOAmt"
        Me.txt_Hdr_ClaimToHKOAmt.Size = New System.Drawing.Size(73, 22)
        Me.txt_Hdr_ClaimToHKOAmt.TabIndex = 42
        Me.txt_Hdr_ClaimToHKOAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Hdr_RemainClaim_Ttl
        '
        Me.txt_Hdr_RemainClaim_Ttl.Enabled = False
        Me.txt_Hdr_RemainClaim_Ttl.ForeColor = System.Drawing.Color.Black
        Me.txt_Hdr_RemainClaim_Ttl.Location = New System.Drawing.Point(252, 451)
        Me.txt_Hdr_RemainClaim_Ttl.Name = "txt_Hdr_RemainClaim_Ttl"
        Me.txt_Hdr_RemainClaim_Ttl.Size = New System.Drawing.Size(76, 22)
        Me.txt_Hdr_RemainClaim_Ttl.TabIndex = 125
        Me.txt_Hdr_RemainClaim_Ttl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_Hdr_RemainClaim_Ttl.Visible = False
        '
        'lblSalesManager
        '
        Me.lblSalesManager.AutoSize = True
        Me.lblSalesManager.Location = New System.Drawing.Point(15, 240)
        Me.lblSalesManager.Name = "lblSalesManager"
        Me.lblSalesManager.Size = New System.Drawing.Size(72, 12)
        Me.lblSalesManager.TabIndex = 97
        Me.lblSalesManager.Text = "Sales Manager"
        '
        'lblSalesTeam
        '
        Me.lblSalesTeam.AutoSize = True
        Me.lblSalesTeam.Location = New System.Drawing.Point(15, 264)
        Me.lblSalesTeam.Name = "lblSalesTeam"
        Me.lblSalesTeam.Size = New System.Drawing.Size(57, 12)
        Me.lblSalesTeam.TabIndex = 95
        Me.lblSalesTeam.Text = "Sales Team"
        '
        'cbo_Hdr_RemainClaimCurrency
        '
        Me.cbo_Hdr_RemainClaimCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Hdr_RemainClaimCurrency.Enabled = False
        Me.cbo_Hdr_RemainClaimCurrency.ForeColor = System.Drawing.Color.Black
        Me.cbo_Hdr_RemainClaimCurrency.FormattingEnabled = True
        Me.cbo_Hdr_RemainClaimCurrency.Location = New System.Drawing.Point(190, 449)
        Me.cbo_Hdr_RemainClaimCurrency.Name = "cbo_Hdr_RemainClaimCurrency"
        Me.cbo_Hdr_RemainClaimCurrency.Size = New System.Drawing.Size(55, 20)
        Me.cbo_Hdr_RemainClaimCurrency.TabIndex = 124
        Me.cbo_Hdr_RemainClaimCurrency.Visible = False
        '
        'lbl_Hdr_Rmk
        '
        Me.lbl_Hdr_Rmk.AutoSize = True
        Me.lbl_Hdr_Rmk.Location = New System.Drawing.Point(17, 399)
        Me.lbl_Hdr_Rmk.Name = "lbl_Hdr_Rmk"
        Me.lbl_Hdr_Rmk.Size = New System.Drawing.Size(42, 12)
        Me.lbl_Hdr_Rmk.TabIndex = 93
        Me.lbl_Hdr_Rmk.Text = "Remark"
        '
        'lblClaimType
        '
        Me.lblClaimType.AutoSize = True
        Me.lblClaimType.ForeColor = System.Drawing.Color.Green
        Me.lblClaimType.Location = New System.Drawing.Point(15, 208)
        Me.lblClaimType.Name = "lblClaimType"
        Me.lblClaimType.Size = New System.Drawing.Size(60, 12)
        Me.lblClaimType.TabIndex = 88
        Me.lblClaimType.Text = "Claim Type"
        '
        'lbl_Hdr_RemainClaim
        '
        Me.lbl_Hdr_RemainClaim.AutoSize = True
        Me.lbl_Hdr_RemainClaim.Enabled = False
        Me.lbl_Hdr_RemainClaim.ForeColor = System.Drawing.Color.Black
        Me.lbl_Hdr_RemainClaim.Location = New System.Drawing.Point(122, 445)
        Me.lbl_Hdr_RemainClaim.Name = "lbl_Hdr_RemainClaim"
        Me.lbl_Hdr_RemainClaim.Size = New System.Drawing.Size(113, 12)
        Me.lbl_Hdr_RemainClaim.TabIndex = 123
        Me.lbl_Hdr_RemainClaim.Text = "Remain Claim Amount"
        Me.lbl_Hdr_RemainClaim.Visible = False
        '
        'gbClaimBy
        '
        Me.gbClaimBy.Controls.Add(Me.rbClaimBy_U)
        Me.gbClaimBy.Controls.Add(Me.lblClaimBy)
        Me.gbClaimBy.Controls.Add(Me.cboVendor)
        Me.gbClaimBy.Controls.Add(Me.lblVendor)
        Me.gbClaimBy.Controls.Add(Me.cboSecCust)
        Me.gbClaimBy.Controls.Add(Me.lblSecCust)
        Me.gbClaimBy.Controls.Add(Me.cboPriCust)
        Me.gbClaimBy.Controls.Add(Me.lblPriCust)
        Me.gbClaimBy.Controls.Add(Me.rbClaimBy_V)
        Me.gbClaimBy.Controls.Add(Me.rbClaimBy_C)
        Me.gbClaimBy.Location = New System.Drawing.Point(8, 2)
        Me.gbClaimBy.Name = "gbClaimBy"
        Me.gbClaimBy.Size = New System.Drawing.Size(467, 115)
        Me.gbClaimBy.TabIndex = 87
        Me.gbClaimBy.TabStop = False
        '
        'rbClaimBy_U
        '
        Me.rbClaimBy_U.AutoSize = True
        Me.rbClaimBy_U.Location = New System.Drawing.Point(261, 10)
        Me.rbClaimBy_U.Name = "rbClaimBy_U"
        Me.rbClaimBy_U.Size = New System.Drawing.Size(71, 16)
        Me.rbClaimBy_U.TabIndex = 20
        Me.rbClaimBy_U.Text = "HK Office"
        Me.rbClaimBy_U.UseVisualStyleBackColor = True
        '
        'lblClaimBy
        '
        Me.lblClaimBy.AutoSize = True
        Me.lblClaimBy.ForeColor = System.Drawing.Color.Green
        Me.lblClaimBy.Location = New System.Drawing.Point(7, 13)
        Me.lblClaimBy.Name = "lblClaimBy"
        Me.lblClaimBy.Size = New System.Drawing.Size(50, 12)
        Me.lblClaimBy.TabIndex = 37
        Me.lblClaimBy.Text = "Claim By"
        '
        'cboVendor
        '
        Me.cboVendor.FormattingEnabled = True
        Me.cboVendor.Location = New System.Drawing.Point(117, 84)
        Me.cboVendor.Name = "cboVendor"
        Me.cboVendor.Size = New System.Drawing.Size(342, 20)
        Me.cboVendor.TabIndex = 23
        '
        'lblVendor
        '
        Me.lblVendor.AutoSize = True
        Me.lblVendor.ForeColor = System.Drawing.Color.Black
        Me.lblVendor.Location = New System.Drawing.Point(6, 87)
        Me.lblVendor.Name = "lblVendor"
        Me.lblVendor.Size = New System.Drawing.Size(40, 12)
        Me.lblVendor.TabIndex = 36
        Me.lblVendor.Text = "Vendor"
        '
        'cboSecCust
        '
        Me.cboSecCust.FormattingEnabled = True
        Me.cboSecCust.Location = New System.Drawing.Point(117, 58)
        Me.cboSecCust.Name = "cboSecCust"
        Me.cboSecCust.Size = New System.Drawing.Size(342, 20)
        Me.cboSecCust.TabIndex = 22
        '
        'lblSecCust
        '
        Me.lblSecCust.AutoSize = True
        Me.lblSecCust.ForeColor = System.Drawing.Color.Black
        Me.lblSecCust.Location = New System.Drawing.Point(6, 61)
        Me.lblSecCust.Name = "lblSecCust"
        Me.lblSecCust.Size = New System.Drawing.Size(102, 12)
        Me.lblSecCust.TabIndex = 34
        Me.lblSecCust.Text = "Secondary Customer"
        '
        'cboPriCust
        '
        Me.cboPriCust.FormattingEnabled = True
        Me.cboPriCust.Location = New System.Drawing.Point(116, 31)
        Me.cboPriCust.Name = "cboPriCust"
        Me.cboPriCust.Size = New System.Drawing.Size(342, 20)
        Me.cboPriCust.TabIndex = 21
        '
        'lblPriCust
        '
        Me.lblPriCust.AutoSize = True
        Me.lblPriCust.ForeColor = System.Drawing.Color.Green
        Me.lblPriCust.Location = New System.Drawing.Point(6, 36)
        Me.lblPriCust.Name = "lblPriCust"
        Me.lblPriCust.Size = New System.Drawing.Size(90, 12)
        Me.lblPriCust.TabIndex = 32
        Me.lblPriCust.Text = "Primary Customer"
        '
        'rbClaimBy_V
        '
        Me.rbClaimBy_V.AutoSize = True
        Me.rbClaimBy_V.Location = New System.Drawing.Point(195, 10)
        Me.rbClaimBy_V.Name = "rbClaimBy_V"
        Me.rbClaimBy_V.Size = New System.Drawing.Size(58, 16)
        Me.rbClaimBy_V.TabIndex = 19
        Me.rbClaimBy_V.Text = "Vendor"
        Me.rbClaimBy_V.UseVisualStyleBackColor = True
        '
        'rbClaimBy_C
        '
        Me.rbClaimBy_C.AutoSize = True
        Me.rbClaimBy_C.Location = New System.Drawing.Point(117, 10)
        Me.rbClaimBy_C.Name = "rbClaimBy_C"
        Me.rbClaimBy_C.Size = New System.Drawing.Size(68, 16)
        Me.rbClaimBy_C.TabIndex = 18
        Me.rbClaimBy_C.Text = "Customer"
        Me.rbClaimBy_C.UseVisualStyleBackColor = True
        '
        'cbo_Hdr_SalesAmtCurrency
        '
        Me.cbo_Hdr_SalesAmtCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Hdr_SalesAmtCurrency.Enabled = False
        Me.cbo_Hdr_SalesAmtCurrency.ForeColor = System.Drawing.Color.Black
        Me.cbo_Hdr_SalesAmtCurrency.FormattingEnabled = True
        Me.cbo_Hdr_SalesAmtCurrency.Location = New System.Drawing.Point(190, 445)
        Me.cbo_Hdr_SalesAmtCurrency.Name = "cbo_Hdr_SalesAmtCurrency"
        Me.cbo_Hdr_SalesAmtCurrency.Size = New System.Drawing.Size(55, 20)
        Me.cbo_Hdr_SalesAmtCurrency.TabIndex = 29
        Me.cbo_Hdr_SalesAmtCurrency.Visible = False
        '
        'lbl_Hdr_SalesAmt
        '
        Me.lbl_Hdr_SalesAmt.AutoSize = True
        Me.lbl_Hdr_SalesAmt.Enabled = False
        Me.lbl_Hdr_SalesAmt.ForeColor = System.Drawing.Color.Black
        Me.lbl_Hdr_SalesAmt.Location = New System.Drawing.Point(143, 445)
        Me.lbl_Hdr_SalesAmt.Name = "lbl_Hdr_SalesAmt"
        Me.lbl_Hdr_SalesAmt.Size = New System.Drawing.Size(90, 12)
        Me.lbl_Hdr_SalesAmt.TabIndex = 90
        Me.lbl_Hdr_SalesAmt.Text = "Shipment Amount"
        Me.lbl_Hdr_SalesAmt.Visible = False
        '
        'lbl_Hdr_AppLmtChk
        '
        Me.lbl_Hdr_AppLmtChk.AutoSize = True
        Me.lbl_Hdr_AppLmtChk.Enabled = False
        Me.lbl_Hdr_AppLmtChk.ForeColor = System.Drawing.Color.Black
        Me.lbl_Hdr_AppLmtChk.Location = New System.Drawing.Point(143, 447)
        Me.lbl_Hdr_AppLmtChk.Name = "lbl_Hdr_AppLmtChk"
        Me.lbl_Hdr_AppLmtChk.Size = New System.Drawing.Size(77, 12)
        Me.lbl_Hdr_AppLmtChk.TabIndex = 110
        Me.lbl_Hdr_AppLmtChk.Text = "Approval Limit"
        Me.lbl_Hdr_AppLmtChk.Visible = False
        '
        'lbl_Hdr_AppLmtChkPer_Ttl
        '
        Me.lbl_Hdr_AppLmtChkPer_Ttl.AutoSize = True
        Me.lbl_Hdr_AppLmtChkPer_Ttl.ForeColor = System.Drawing.Color.Black
        Me.lbl_Hdr_AppLmtChkPer_Ttl.Location = New System.Drawing.Point(106, 476)
        Me.lbl_Hdr_AppLmtChkPer_Ttl.Name = "lbl_Hdr_AppLmtChkPer_Ttl"
        Me.lbl_Hdr_AppLmtChkPer_Ttl.Size = New System.Drawing.Size(0, 12)
        Me.lbl_Hdr_AppLmtChkPer_Ttl.TabIndex = 43
        Me.lbl_Hdr_AppLmtChkPer_Ttl.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lbl_Hdr_AppLmtChkPer_Ttl.Visible = False
        '
        'cbo_Hdr_AppLmtChkCurrency
        '
        Me.cbo_Hdr_AppLmtChkCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Hdr_AppLmtChkCurrency.Enabled = False
        Me.cbo_Hdr_AppLmtChkCurrency.ForeColor = System.Drawing.Color.Black
        Me.cbo_Hdr_AppLmtChkCurrency.FormattingEnabled = True
        Me.cbo_Hdr_AppLmtChkCurrency.Location = New System.Drawing.Point(190, 447)
        Me.cbo_Hdr_AppLmtChkCurrency.Name = "cbo_Hdr_AppLmtChkCurrency"
        Me.cbo_Hdr_AppLmtChkCurrency.Size = New System.Drawing.Size(55, 20)
        Me.cbo_Hdr_AppLmtChkCurrency.TabIndex = 36
        Me.cbo_Hdr_AppLmtChkCurrency.Visible = False
        '
        'txt_Hdr_SalesAmt_Ttl
        '
        Me.txt_Hdr_SalesAmt_Ttl.Enabled = False
        Me.txt_Hdr_SalesAmt_Ttl.ForeColor = System.Drawing.Color.Black
        Me.txt_Hdr_SalesAmt_Ttl.Location = New System.Drawing.Point(240, 447)
        Me.txt_Hdr_SalesAmt_Ttl.Name = "txt_Hdr_SalesAmt_Ttl"
        Me.txt_Hdr_SalesAmt_Ttl.Size = New System.Drawing.Size(76, 22)
        Me.txt_Hdr_SalesAmt_Ttl.TabIndex = 32
        Me.txt_Hdr_SalesAmt_Ttl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_Hdr_SalesAmt_Ttl.Visible = False
        '
        'txt_Hdr_AppLmtChk_Ttl
        '
        Me.txt_Hdr_AppLmtChk_Ttl.Enabled = False
        Me.txt_Hdr_AppLmtChk_Ttl.ForeColor = System.Drawing.Color.Black
        Me.txt_Hdr_AppLmtChk_Ttl.Location = New System.Drawing.Point(252, 449)
        Me.txt_Hdr_AppLmtChk_Ttl.Name = "txt_Hdr_AppLmtChk_Ttl"
        Me.txt_Hdr_AppLmtChk_Ttl.Size = New System.Drawing.Size(76, 22)
        Me.txt_Hdr_AppLmtChk_Ttl.TabIndex = 39
        Me.txt_Hdr_AppLmtChk_Ttl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_Hdr_AppLmtChk_Ttl.Visible = False
        '
        'tpCLM00001_2
        '
        Me.tpCLM00001_2.Controls.Add(Me.gb_income)
        Me.tpCLM00001_2.Controls.Add(Me.gb_pay)
        Me.tpCLM00001_2.Controls.Add(Me.cmd_close)
        Me.tpCLM00001_2.Controls.Add(Me.cboAPRVSTS)
        Me.tpCLM00001_2.Controls.Add(Me.chkClose)
        Me.tpCLM00001_2.Controls.Add(Me.txt_Hdr_AcctClaimAmt)
        Me.tpCLM00001_2.Controls.Add(Me.Label9)
        Me.tpCLM00001_2.Controls.Add(Me.Label8)
        Me.tpCLM00001_2.Location = New System.Drawing.Point(4, 22)
        Me.tpCLM00001_2.Name = "tpCLM00001_2"
        Me.tpCLM00001_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCLM00001_2.Size = New System.Drawing.Size(946, 524)
        Me.tpCLM00001_2.TabIndex = 3
        Me.tpCLM00001_2.Text = "(2) Acct"
        Me.tpCLM00001_2.UseVisualStyleBackColor = True
        '
        'gb_income
        '
        Me.gb_income.Controls.Add(Me.cboSETTLE_FTY)
        Me.gb_income.Controls.Add(Me.dtHDRRCVDAT)
        Me.gb_income.Controls.Add(Me.cboClaimIncomeSTS)
        Me.gb_income.Controls.Add(Me.txt_income_rmk)
        Me.gb_income.Controls.Add(Me.lbl_income_amt)
        Me.gb_income.Controls.Add(Me.lbl_outamt_income)
        Me.gb_income.Controls.Add(Me.cbo_income_cur)
        Me.gb_income.Controls.Add(Me.Label12)
        Me.gb_income.Controls.Add(Me.txt_income_upddat)
        Me.gb_income.Controls.Add(Me.Label23)
        Me.gb_income.Controls.Add(Me.txt_income_potamt)
        Me.gb_income.Controls.Add(Me.Label7)
        Me.gb_income.Controls.Add(Me.txt_income_actamt)
        Me.gb_income.Controls.Add(Me.Label13)
        Me.gb_income.Controls.Add(Me.Label10)
        Me.gb_income.Controls.Add(Me.Label11)
        Me.gb_income.Controls.Add(Me.Label14)
        Me.gb_income.ForeColor = System.Drawing.Color.Black
        Me.gb_income.Location = New System.Drawing.Point(470, 59)
        Me.gb_income.Name = "gb_income"
        Me.gb_income.Size = New System.Drawing.Size(468, 345)
        Me.gb_income.TabIndex = 550
        Me.gb_income.TabStop = False
        Me.gb_income.Text = "Claim Received Status"
        '
        'cboSETTLE_FTY
        '
        Me.cboSETTLE_FTY.FormattingEnabled = True
        Me.cboSETTLE_FTY.Location = New System.Drawing.Point(175, 165)
        Me.cboSETTLE_FTY.Name = "cboSETTLE_FTY"
        Me.cboSETTLE_FTY.Size = New System.Drawing.Size(194, 20)
        Me.cboSETTLE_FTY.TabIndex = 568
        '
        'dtHDRRCVDAT
        '
        Me.dtHDRRCVDAT.Location = New System.Drawing.Point(174, 136)
        Me.dtHDRRCVDAT.Mask = "##/##/####"
        Me.dtHDRRCVDAT.Name = "dtHDRRCVDAT"
        Me.dtHDRRCVDAT.Size = New System.Drawing.Size(195, 22)
        Me.dtHDRRCVDAT.TabIndex = 564
        '
        'cboClaimIncomeSTS
        '
        Me.cboClaimIncomeSTS.FormattingEnabled = True
        Me.cboClaimIncomeSTS.Location = New System.Drawing.Point(118, 43)
        Me.cboClaimIncomeSTS.Name = "cboClaimIncomeSTS"
        Me.cboClaimIncomeSTS.Size = New System.Drawing.Size(329, 20)
        Me.cboClaimIncomeSTS.TabIndex = 567
        '
        'txt_income_rmk
        '
        Me.txt_income_rmk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txt_income_rmk.Location = New System.Drawing.Point(174, 194)
        Me.txt_income_rmk.Name = "txt_income_rmk"
        Me.txt_income_rmk.Size = New System.Drawing.Size(195, 51)
        Me.txt_income_rmk.TabIndex = 562
        Me.txt_income_rmk.Text = ""
        '
        'lbl_income_amt
        '
        Me.lbl_income_amt.AutoSize = True
        Me.lbl_income_amt.Location = New System.Drawing.Point(381, 84)
        Me.lbl_income_amt.Name = "lbl_income_amt"
        Me.lbl_income_amt.Size = New System.Drawing.Size(0, 12)
        Me.lbl_income_amt.TabIndex = 566
        '
        'lbl_outamt_income
        '
        Me.lbl_outamt_income.AutoSize = True
        Me.lbl_outamt_income.Location = New System.Drawing.Point(122, 110)
        Me.lbl_outamt_income.Name = "lbl_outamt_income"
        Me.lbl_outamt_income.Size = New System.Drawing.Size(0, 12)
        Me.lbl_outamt_income.TabIndex = 564
        '
        'cbo_income_cur
        '
        Me.cbo_income_cur.DisplayMember = "HKD"
        Me.cbo_income_cur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_income_cur.FormattingEnabled = True
        Me.cbo_income_cur.Location = New System.Drawing.Point(118, 76)
        Me.cbo_income_cur.Name = "cbo_income_cur"
        Me.cbo_income_cur.Size = New System.Drawing.Size(52, 20)
        Me.cbo_income_cur.TabIndex = 563
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 24)
        Me.Label12.TabIndex = 558
        Me.Label12.Text = "Received Amt " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(in Acct system)"
        '
        'txt_income_upddat
        '
        Me.txt_income_upddat.Enabled = False
        Me.txt_income_upddat.Location = New System.Drawing.Point(175, 246)
        Me.txt_income_upddat.Name = "txt_income_upddat"
        Me.txt_income_upddat.Size = New System.Drawing.Size(194, 22)
        Me.txt_income_upddat.TabIndex = 562
        Me.txt_income_upddat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(18, 246)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(110, 12)
        Me.Label23.TabIndex = 561
        Me.Label23.Text = "F&&A Last Update Date"
        '
        'txt_income_potamt
        '
        Me.txt_income_potamt.Location = New System.Drawing.Point(175, 106)
        Me.txt_income_potamt.Name = "txt_income_potamt"
        Me.txt_income_potamt.Size = New System.Drawing.Size(194, 22)
        Me.txt_income_potamt.TabIndex = 560
        Me.txt_income_potamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 108)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 12)
        Me.Label7.TabIndex = 559
        Me.Label7.Text = "Outstanding Amt"
        '
        'txt_income_actamt
        '
        Me.txt_income_actamt.Location = New System.Drawing.Point(175, 75)
        Me.txt_income_actamt.Name = "txt_income_actamt"
        Me.txt_income_actamt.Size = New System.Drawing.Size(194, 22)
        Me.txt_income_actamt.TabIndex = 558
        Me.txt_income_actamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 196)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 12)
        Me.Label13.TabIndex = 555
        Me.Label13.Text = "Remark"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(14, 169)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(118, 12)
        Me.Label10.TabIndex = 547
        Me.Label10.Text = "Settlement Method (Fty)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(14, 141)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 12)
        Me.Label11.TabIndex = 546
        Me.Label11.Text = "Received Date"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(15, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 12)
        Me.Label14.TabIndex = 543
        Me.Label14.Text = "Received Status"
        '
        'gb_pay
        '
        Me.gb_pay.Controls.Add(Me.cboSETTLE_CUS)
        Me.gb_pay.Controls.Add(Me.dtHDRPAIDDAT)
        Me.gb_pay.Controls.Add(Me.cboClaimPaySTS)
        Me.gb_pay.Controls.Add(Me.txt_pay_rmk)
        Me.gb_pay.Controls.Add(Me.lbl_pay_amt)
        Me.gb_pay.Controls.Add(Me.lbl_outamt_pay)
        Me.gb_pay.Controls.Add(Me.cbo_pay_cur)
        Me.gb_pay.Controls.Add(Me.txt_pay_upddat)
        Me.gb_pay.Controls.Add(Me.Label6)
        Me.gb_pay.Controls.Add(Me.txt_pay_potamt)
        Me.gb_pay.Controls.Add(Me.Label5)
        Me.gb_pay.Controls.Add(Me.txt_pay_actamt)
        Me.gb_pay.Controls.Add(Me.Label22)
        Me.gb_pay.Controls.Add(Me.Label15)
        Me.gb_pay.Controls.Add(Me.Label4)
        Me.gb_pay.Controls.Add(Me.Label3)
        Me.gb_pay.Controls.Add(Me.Label2)
        Me.gb_pay.ForeColor = System.Drawing.Color.Black
        Me.gb_pay.Location = New System.Drawing.Point(6, 60)
        Me.gb_pay.Name = "gb_pay"
        Me.gb_pay.Size = New System.Drawing.Size(458, 344)
        Me.gb_pay.TabIndex = 134
        Me.gb_pay.TabStop = False
        Me.gb_pay.Text = "Claim Paid Status"
        '
        'cboSETTLE_CUS
        '
        Me.cboSETTLE_CUS.FormattingEnabled = True
        Me.cboSETTLE_CUS.Location = New System.Drawing.Point(175, 161)
        Me.cboSETTLE_CUS.Name = "cboSETTLE_CUS"
        Me.cboSETTLE_CUS.Size = New System.Drawing.Size(197, 20)
        Me.cboSETTLE_CUS.TabIndex = 564
        '
        'dtHDRPAIDDAT
        '
        Me.dtHDRPAIDDAT.Location = New System.Drawing.Point(174, 134)
        Me.dtHDRPAIDDAT.Mask = "##/##/####"
        Me.dtHDRPAIDDAT.Name = "dtHDRPAIDDAT"
        Me.dtHDRPAIDDAT.Size = New System.Drawing.Size(198, 22)
        Me.dtHDRPAIDDAT.TabIndex = 563
        '
        'cboClaimPaySTS
        '
        Me.cboClaimPaySTS.FormattingEnabled = True
        Me.cboClaimPaySTS.Location = New System.Drawing.Point(117, 43)
        Me.cboClaimPaySTS.Name = "cboClaimPaySTS"
        Me.cboClaimPaySTS.Size = New System.Drawing.Size(335, 20)
        Me.cboClaimPaySTS.TabIndex = 562
        '
        'txt_pay_rmk
        '
        Me.txt_pay_rmk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txt_pay_rmk.Location = New System.Drawing.Point(174, 189)
        Me.txt_pay_rmk.Name = "txt_pay_rmk"
        Me.txt_pay_rmk.Size = New System.Drawing.Size(198, 51)
        Me.txt_pay_rmk.TabIndex = 561
        Me.txt_pay_rmk.Text = ""
        '
        'lbl_pay_amt
        '
        Me.lbl_pay_amt.AutoSize = True
        Me.lbl_pay_amt.Location = New System.Drawing.Point(414, 73)
        Me.lbl_pay_amt.Name = "lbl_pay_amt"
        Me.lbl_pay_amt.Size = New System.Drawing.Size(0, 12)
        Me.lbl_pay_amt.TabIndex = 560
        '
        'lbl_outamt_pay
        '
        Me.lbl_outamt_pay.AutoSize = True
        Me.lbl_outamt_pay.Location = New System.Drawing.Point(122, 108)
        Me.lbl_outamt_pay.Name = "lbl_outamt_pay"
        Me.lbl_outamt_pay.Size = New System.Drawing.Size(0, 12)
        Me.lbl_outamt_pay.TabIndex = 558
        '
        'cbo_pay_cur
        '
        Me.cbo_pay_cur.DisplayMember = "HKD"
        Me.cbo_pay_cur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_pay_cur.FormattingEnabled = True
        Me.cbo_pay_cur.Location = New System.Drawing.Point(117, 75)
        Me.cbo_pay_cur.Name = "cbo_pay_cur"
        Me.cbo_pay_cur.Size = New System.Drawing.Size(52, 20)
        Me.cbo_pay_cur.TabIndex = 551
        '
        'txt_pay_upddat
        '
        Me.txt_pay_upddat.Enabled = False
        Me.txt_pay_upddat.Location = New System.Drawing.Point(174, 246)
        Me.txt_pay_upddat.Name = "txt_pay_upddat"
        Me.txt_pay_upddat.Size = New System.Drawing.Size(198, 22)
        Me.txt_pay_upddat.TabIndex = 557
        Me.txt_pay_upddat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 246)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 12)
        Me.Label6.TabIndex = 556
        Me.Label6.Text = "F&&A Last Update Date"
        '
        'txt_pay_potamt
        '
        Me.txt_pay_potamt.Location = New System.Drawing.Point(175, 106)
        Me.txt_pay_potamt.Name = "txt_pay_potamt"
        Me.txt_pay_potamt.Size = New System.Drawing.Size(197, 22)
        Me.txt_pay_potamt.TabIndex = 554
        Me.txt_pay_potamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 12)
        Me.Label5.TabIndex = 553
        Me.Label5.Text = "Outstanding Amt"
        '
        'txt_pay_actamt
        '
        Me.txt_pay_actamt.Location = New System.Drawing.Point(175, 75)
        Me.txt_pay_actamt.Name = "txt_pay_actamt"
        Me.txt_pay_actamt.Size = New System.Drawing.Size(197, 22)
        Me.txt_pay_actamt.TabIndex = 552
        Me.txt_pay_actamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(7, 73)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(80, 24)
        Me.Label22.TabIndex = 551
        Me.Label22.Text = "Paid Amt " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(in Acct system)"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 191)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 12)
        Me.Label15.TabIndex = 549
        Me.Label15.Text = "Remark"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(4, 166)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 12)
        Me.Label4.TabIndex = 545
        Me.Label4.Text = "Settlement Method (Cus)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(4, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 12)
        Me.Label3.TabIndex = 544
        Me.Label3.Text = "Paid Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(7, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 12)
        Me.Label2.TabIndex = 543
        Me.Label2.Text = "Paid Status"
        '
        'cmd_close
        '
        Me.cmd_close.AutoSize = True
        Me.cmd_close.Enabled = False
        Me.cmd_close.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_close.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_close.Location = New System.Drawing.Point(380, 427)
        Me.cmd_close.Name = "cmd_close"
        Me.cmd_close.Size = New System.Drawing.Size(170, 29)
        Me.cmd_close.TabIndex = 47
        Me.cmd_close.Text = "Claims Completed"
        Me.cmd_close.UseVisualStyleBackColor = True
        '
        'cboAPRVSTS
        '
        Me.cboAPRVSTS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAPRVSTS.FormattingEnabled = True
        Me.cboAPRVSTS.Location = New System.Drawing.Point(590, 478)
        Me.cboAPRVSTS.Name = "cboAPRVSTS"
        Me.cboAPRVSTS.Size = New System.Drawing.Size(172, 20)
        Me.cboAPRVSTS.TabIndex = 542
        Me.cboAPRVSTS.Visible = False
        '
        'chkClose
        '
        Me.chkClose.AutoSize = True
        Me.chkClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkClose.ForeColor = System.Drawing.Color.Black
        Me.chkClose.Location = New System.Drawing.Point(668, 33)
        Me.chkClose.Name = "chkClose"
        Me.chkClose.Size = New System.Drawing.Size(52, 17)
        Me.chkClose.TabIndex = 311
        Me.chkClose.Text = "Close"
        Me.chkClose.UseVisualStyleBackColor = True
        Me.chkClose.Visible = False
        '
        'txt_Hdr_AcctClaimAmt
        '
        Me.txt_Hdr_AcctClaimAmt.Location = New System.Drawing.Point(367, 32)
        Me.txt_Hdr_AcctClaimAmt.Name = "txt_Hdr_AcctClaimAmt"
        Me.txt_Hdr_AcctClaimAmt.Size = New System.Drawing.Size(172, 22)
        Me.txt_Hdr_AcctClaimAmt.TabIndex = 536
        Me.txt_Hdr_AcctClaimAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_Hdr_AcctClaimAmt.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(475, 478)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 12)
        Me.Label9.TabIndex = 548
        Me.Label9.Text = "Approval Status"
        Me.Label9.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(288, 35)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 12)
        Me.Label8.TabIndex = 536
        Me.Label8.Text = "Acct Amount"
        Me.Label8.Visible = False
        '
        'tpCLM00001_3
        '
        Me.tpCLM00001_3.Controls.Add(Me.txtShipSeq)
        Me.tpCLM00001_3.Controls.Add(Me.gbViewOn)
        Me.tpCLM00001_3.Controls.Add(Me.txtItmCstCurrency)
        Me.tpCLM00001_3.Controls.Add(Me.txtSelPrcCurrency)
        Me.tpCLM00001_3.Controls.Add(Me.txtCoCde)
        Me.tpCLM00001_3.Controls.Add(Me.txtShipQtyUM)
        Me.tpCLM00001_3.Controls.Add(Me.txtShipQty)
        Me.tpCLM00001_3.Controls.Add(Me.lblShipQty)
        Me.tpCLM00001_3.Controls.Add(Me.txtShipNo)
        Me.tpCLM00001_3.Controls.Add(Me.lblShipNo)
        Me.tpCLM00001_3.Controls.Add(Me.cbo_Dtl_ClaimType)
        Me.tpCLM00001_3.Controls.Add(Me.cmd_dtl_Next)
        Me.tpCLM00001_3.Controls.Add(Me.cmd_dtl_Back)
        Me.tpCLM00001_3.Controls.Add(Me.chkDelete)
        Me.tpCLM00001_3.Controls.Add(Me.txtItmDsc)
        Me.tpCLM00001_3.Controls.Add(Me.txt_Dtl_Rmk)
        Me.tpCLM00001_3.Controls.Add(Me.lbl_Dtl_AppLmtChkPer)
        Me.tpCLM00001_3.Controls.Add(Me.txtSelPrc)
        Me.tpCLM00001_3.Controls.Add(Me.txtItmCst)
        Me.tpCLM00001_3.Controls.Add(Me.txtCusPONo)
        Me.tpCLM00001_3.Controls.Add(Me.txtInvETADat)
        Me.tpCLM00001_3.Controls.Add(Me.txtInvETDDat)
        Me.tpCLM00001_3.Controls.Add(Me.txtInvIssDat)
        Me.tpCLM00001_3.Controls.Add(Me.txtPV)
        Me.tpCLM00001_3.Controls.Add(Me.txtCustStyNo)
        Me.tpCLM00001_3.Controls.Add(Me.txtOrdQtyUM)
        Me.tpCLM00001_3.Controls.Add(Me.txtOrdQty)
        Me.tpCLM00001_3.Controls.Add(Me.txtVenItmNo)
        Me.tpCLM00001_3.Controls.Add(Me.txtCustItmNo)
        Me.tpCLM00001_3.Controls.Add(Me.txtItmNo)
        Me.tpCLM00001_3.Controls.Add(Me.txtInvNo)
        Me.tpCLM00001_3.Controls.Add(Me.txtJobNo)
        Me.tpCLM00001_3.Controls.Add(Me.txtPOSeq)
        Me.tpCLM00001_3.Controls.Add(Me.txtPONo)
        Me.tpCLM00001_3.Controls.Add(Me.txtSCSeq)
        Me.tpCLM00001_3.Controls.Add(Me.txtSCNo)
        Me.tpCLM00001_3.Controls.Add(Me.lblSelPrc)
        Me.tpCLM00001_3.Controls.Add(Me.lblItmCst)
        Me.tpCLM00001_3.Controls.Add(Me.lblCustPONo)
        Me.tpCLM00001_3.Controls.Add(Me.lblInvETADat)
        Me.tpCLM00001_3.Controls.Add(Me.lblInvETDDat)
        Me.tpCLM00001_3.Controls.Add(Me.lblInvIssDat)
        Me.tpCLM00001_3.Controls.Add(Me.lblCustStyNo)
        Me.tpCLM00001_3.Controls.Add(Me.lblItmDsc)
        Me.tpCLM00001_3.Controls.Add(Me.lblCoCde)
        Me.tpCLM00001_3.Controls.Add(Me.lbl_Dtl_Rmk)
        Me.tpCLM00001_3.Controls.Add(Me.lblPV)
        Me.tpCLM00001_3.Controls.Add(Me.lblOdrQty)
        Me.tpCLM00001_3.Controls.Add(Me.lblVenItmNo)
        Me.tpCLM00001_3.Controls.Add(Me.lblCustItmNo)
        Me.tpCLM00001_3.Controls.Add(Me.lblItmNo)
        Me.tpCLM00001_3.Controls.Add(Me.lblInvoiceNo)
        Me.tpCLM00001_3.Controls.Add(Me.lblJobNo)
        Me.tpCLM00001_3.Controls.Add(Me.lblPONo)
        Me.tpCLM00001_3.Controls.Add(Me.lblSCNo)
        Me.tpCLM00001_3.Controls.Add(Me.lblSeq)
        Me.tpCLM00001_3.Controls.Add(Me.lblSeqtext)
        Me.tpCLM00001_3.Location = New System.Drawing.Point(4, 22)
        Me.tpCLM00001_3.Name = "tpCLM00001_3"
        Me.tpCLM00001_3.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCLM00001_3.Size = New System.Drawing.Size(946, 524)
        Me.tpCLM00001_3.TabIndex = 1
        Me.tpCLM00001_3.Text = "(3) Item & Shipment"
        Me.tpCLM00001_3.UseVisualStyleBackColor = True
        '
        'txtShipSeq
        '
        Me.txtShipSeq.Location = New System.Drawing.Point(901, 76)
        Me.txtShipSeq.Name = "txtShipSeq"
        Me.txtShipSeq.Size = New System.Drawing.Size(37, 22)
        Me.txtShipSeq.TabIndex = 213
        '
        'gbViewOn
        '
        Me.gbViewOn.Controls.Add(Me.lblViewOn)
        Me.gbViewOn.Controls.Add(Me.rbViewOn_I)
        Me.gbViewOn.Controls.Add(Me.rbViewOn_S)
        Me.gbViewOn.Location = New System.Drawing.Point(69, 0)
        Me.gbViewOn.Name = "gbViewOn"
        Me.gbViewOn.Size = New System.Drawing.Size(207, 34)
        Me.gbViewOn.TabIndex = 13
        Me.gbViewOn.TabStop = False
        Me.gbViewOn.Visible = False
        '
        'lblViewOn
        '
        Me.lblViewOn.AutoSize = True
        Me.lblViewOn.ForeColor = System.Drawing.Color.Black
        Me.lblViewOn.Location = New System.Drawing.Point(6, 13)
        Me.lblViewOn.Name = "lblViewOn"
        Me.lblViewOn.Size = New System.Drawing.Size(46, 12)
        Me.lblViewOn.TabIndex = 203
        Me.lblViewOn.Text = "View On"
        '
        'rbViewOn_I
        '
        Me.rbViewOn_I.AutoSize = True
        Me.rbViewOn_I.Location = New System.Drawing.Point(62, 11)
        Me.rbViewOn_I.Name = "rbViewOn_I"
        Me.rbViewOn_I.Size = New System.Drawing.Size(44, 16)
        Me.rbViewOn_I.TabIndex = 204
        Me.rbViewOn_I.Text = "Item"
        Me.rbViewOn_I.UseVisualStyleBackColor = True
        '
        'rbViewOn_S
        '
        Me.rbViewOn_S.AutoSize = True
        Me.rbViewOn_S.Checked = True
        Me.rbViewOn_S.Location = New System.Drawing.Point(115, 11)
        Me.rbViewOn_S.Name = "rbViewOn_S"
        Me.rbViewOn_S.Size = New System.Drawing.Size(67, 16)
        Me.rbViewOn_S.TabIndex = 205
        Me.rbViewOn_S.TabStop = True
        Me.rbViewOn_S.Text = "Shipment"
        Me.rbViewOn_S.UseVisualStyleBackColor = True
        '
        'txtItmCstCurrency
        '
        Me.txtItmCstCurrency.Location = New System.Drawing.Point(95, 280)
        Me.txtItmCstCurrency.Name = "txtItmCstCurrency"
        Me.txtItmCstCurrency.Size = New System.Drawing.Size(52, 22)
        Me.txtItmCstCurrency.TabIndex = 212
        '
        'txtSelPrcCurrency
        '
        Me.txtSelPrcCurrency.Location = New System.Drawing.Point(95, 254)
        Me.txtSelPrcCurrency.Name = "txtSelPrcCurrency"
        Me.txtSelPrcCurrency.Size = New System.Drawing.Size(52, 22)
        Me.txtSelPrcCurrency.TabIndex = 211
        '
        'txtCoCde
        '
        Me.txtCoCde.Location = New System.Drawing.Point(774, 49)
        Me.txtCoCde.Name = "txtCoCde"
        Me.txtCoCde.Size = New System.Drawing.Size(164, 22)
        Me.txtCoCde.TabIndex = 210
        '
        'txtShipQtyUM
        '
        Me.txtShipQtyUM.Location = New System.Drawing.Point(95, 228)
        Me.txtShipQtyUM.Name = "txtShipQtyUM"
        Me.txtShipQtyUM.Size = New System.Drawing.Size(52, 22)
        Me.txtShipQtyUM.TabIndex = 209
        '
        'txtShipQty
        '
        Me.txtShipQty.Location = New System.Drawing.Point(147, 228)
        Me.txtShipQty.Name = "txtShipQty"
        Me.txtShipQty.Size = New System.Drawing.Size(106, 22)
        Me.txtShipQty.TabIndex = 206
        Me.txtShipQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblShipQty
        '
        Me.lblShipQty.AutoSize = True
        Me.lblShipQty.Location = New System.Drawing.Point(13, 231)
        Me.lblShipQty.Name = "lblShipQty"
        Me.lblShipQty.Size = New System.Drawing.Size(63, 12)
        Me.lblShipQty.TabIndex = 207
        Me.lblShipQty.Text = "Shipped Qty"
        '
        'txtShipNo
        '
        Me.txtShipNo.AcceptsReturn = True
        Me.txtShipNo.Location = New System.Drawing.Point(774, 76)
        Me.txtShipNo.Name = "txtShipNo"
        Me.txtShipNo.Size = New System.Drawing.Size(126, 22)
        Me.txtShipNo.TabIndex = 201
        '
        'lblShipNo
        '
        Me.lblShipNo.AutoSize = True
        Me.lblShipNo.Location = New System.Drawing.Point(669, 80)
        Me.lblShipNo.Name = "lblShipNo"
        Me.lblShipNo.Size = New System.Drawing.Size(66, 12)
        Me.lblShipNo.TabIndex = 202
        Me.lblShipNo.Text = "Shipment No"
        '
        'cbo_Dtl_ClaimType
        '
        Me.cbo_Dtl_ClaimType.Enabled = False
        Me.cbo_Dtl_ClaimType.FormattingEnabled = True
        Me.cbo_Dtl_ClaimType.Location = New System.Drawing.Point(293, 9)
        Me.cbo_Dtl_ClaimType.Name = "cbo_Dtl_ClaimType"
        Me.cbo_Dtl_ClaimType.Size = New System.Drawing.Size(259, 20)
        Me.cbo_Dtl_ClaimType.TabIndex = 194
        Me.cbo_Dtl_ClaimType.Text = "01 - Markdown Support"
        Me.cbo_Dtl_ClaimType.Visible = False
        '
        'cmd_dtl_Next
        '
        Me.cmd_dtl_Next.Location = New System.Drawing.Point(834, 480)
        Me.cmd_dtl_Next.Name = "cmd_dtl_Next"
        Me.cmd_dtl_Next.Size = New System.Drawing.Size(46, 22)
        Me.cmd_dtl_Next.TabIndex = 100
        Me.cmd_dtl_Next.Text = "&Next"
        Me.cmd_dtl_Next.UseVisualStyleBackColor = True
        '
        'cmd_dtl_Back
        '
        Me.cmd_dtl_Back.Location = New System.Drawing.Point(782, 480)
        Me.cmd_dtl_Back.Name = "cmd_dtl_Back"
        Me.cmd_dtl_Back.Size = New System.Drawing.Size(46, 22)
        Me.cmd_dtl_Back.TabIndex = 99
        Me.cmd_dtl_Back.Text = "&Back"
        Me.cmd_dtl_Back.UseVisualStyleBackColor = True
        '
        'chkDelete
        '
        Me.chkDelete.AutoSize = True
        Me.chkDelete.Location = New System.Drawing.Point(591, 483)
        Me.chkDelete.Name = "chkDelete"
        Me.chkDelete.Size = New System.Drawing.Size(147, 16)
        Me.chkDelete.TabIndex = 98
        Me.chkDelete.Text = "Delete (Checked if Delete)"
        Me.chkDelete.UseVisualStyleBackColor = True
        '
        'txtItmDsc
        '
        Me.txtItmDsc.Location = New System.Drawing.Point(317, 51)
        Me.txtItmDsc.Name = "txtItmDsc"
        Me.txtItmDsc.Size = New System.Drawing.Size(335, 189)
        Me.txtItmDsc.TabIndex = 68
        Me.txtItmDsc.Text = ""
        '
        'txt_Dtl_Rmk
        '
        Me.txt_Dtl_Rmk.Location = New System.Drawing.Point(317, 262)
        Me.txt_Dtl_Rmk.Name = "txt_Dtl_Rmk"
        Me.txt_Dtl_Rmk.Size = New System.Drawing.Size(335, 201)
        Me.txt_Dtl_Rmk.TabIndex = 79
        Me.txt_Dtl_Rmk.Text = ""
        '
        'lbl_Dtl_AppLmtChkPer
        '
        Me.lbl_Dtl_AppLmtChkPer.AutoSize = True
        Me.lbl_Dtl_AppLmtChkPer.ForeColor = System.Drawing.Color.Black
        Me.lbl_Dtl_AppLmtChkPer.Location = New System.Drawing.Point(550, 75)
        Me.lbl_Dtl_AppLmtChkPer.Name = "lbl_Dtl_AppLmtChkPer"
        Me.lbl_Dtl_AppLmtChkPer.Size = New System.Drawing.Size(0, 12)
        Me.lbl_Dtl_AppLmtChkPer.TabIndex = 193
        '
        'txtSelPrc
        '
        Me.txtSelPrc.Location = New System.Drawing.Point(147, 254)
        Me.txtSelPrc.Name = "txtSelPrc"
        Me.txtSelPrc.Size = New System.Drawing.Size(106, 22)
        Me.txtSelPrc.TabIndex = 76
        Me.txtSelPrc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtItmCst
        '
        Me.txtItmCst.Location = New System.Drawing.Point(147, 280)
        Me.txtItmCst.Name = "txtItmCst"
        Me.txtItmCst.Size = New System.Drawing.Size(106, 22)
        Me.txtItmCst.TabIndex = 78
        Me.txtItmCst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCusPONo
        '
        Me.txtCusPONo.Enabled = False
        Me.txtCusPONo.Location = New System.Drawing.Point(774, 211)
        Me.txtCusPONo.Name = "txtCusPONo"
        Me.txtCusPONo.Size = New System.Drawing.Size(164, 22)
        Me.txtCusPONo.TabIndex = 61
        '
        'txtInvETADat
        '
        Me.txtInvETADat.Location = New System.Drawing.Point(803, 292)
        Me.txtInvETADat.Name = "txtInvETADat"
        Me.txtInvETADat.Size = New System.Drawing.Size(135, 22)
        Me.txtInvETADat.TabIndex = 64
        '
        'txtInvETDDat
        '
        Me.txtInvETDDat.Location = New System.Drawing.Point(803, 266)
        Me.txtInvETDDat.Name = "txtInvETDDat"
        Me.txtInvETDDat.Size = New System.Drawing.Size(135, 22)
        Me.txtInvETDDat.TabIndex = 63
        '
        'txtInvIssDat
        '
        Me.txtInvIssDat.Location = New System.Drawing.Point(803, 240)
        Me.txtInvIssDat.Name = "txtInvIssDat"
        Me.txtInvIssDat.Size = New System.Drawing.Size(135, 22)
        Me.txtInvIssDat.TabIndex = 62
        '
        'txtPV
        '
        Me.txtPV.Location = New System.Drawing.Point(111, 78)
        Me.txtPV.Name = "txtPV"
        Me.txtPV.Size = New System.Drawing.Size(142, 22)
        Me.txtPV.TabIndex = 69
        '
        'txtCustStyNo
        '
        Me.txtCustStyNo.Location = New System.Drawing.Point(111, 130)
        Me.txtCustStyNo.Name = "txtCustStyNo"
        Me.txtCustStyNo.Size = New System.Drawing.Size(142, 22)
        Me.txtCustStyNo.TabIndex = 66
        '
        'txtOrdQtyUM
        '
        Me.txtOrdQtyUM.Location = New System.Drawing.Point(95, 202)
        Me.txtOrdQtyUM.Name = "txtOrdQtyUM"
        Me.txtOrdQtyUM.Size = New System.Drawing.Size(52, 22)
        Me.txtOrdQtyUM.TabIndex = 71
        '
        'txtOrdQty
        '
        Me.txtOrdQty.Location = New System.Drawing.Point(147, 202)
        Me.txtOrdQty.Name = "txtOrdQty"
        Me.txtOrdQty.Size = New System.Drawing.Size(106, 22)
        Me.txtOrdQty.TabIndex = 72
        Me.txtOrdQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVenItmNo
        '
        Me.txtVenItmNo.Location = New System.Drawing.Point(111, 156)
        Me.txtVenItmNo.Name = "txtVenItmNo"
        Me.txtVenItmNo.Size = New System.Drawing.Size(142, 22)
        Me.txtVenItmNo.TabIndex = 67
        '
        'txtCustItmNo
        '
        Me.txtCustItmNo.Location = New System.Drawing.Point(111, 104)
        Me.txtCustItmNo.Name = "txtCustItmNo"
        Me.txtCustItmNo.Size = New System.Drawing.Size(142, 22)
        Me.txtCustItmNo.TabIndex = 65
        '
        'txtItmNo
        '
        Me.txtItmNo.Location = New System.Drawing.Point(111, 51)
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(142, 22)
        Me.txtItmNo.TabIndex = 70
        '
        'txtInvNo
        '
        Me.txtInvNo.Location = New System.Drawing.Point(774, 184)
        Me.txtInvNo.Name = "txtInvNo"
        Me.txtInvNo.Size = New System.Drawing.Size(164, 22)
        Me.txtInvNo.TabIndex = 60
        '
        'txtJobNo
        '
        Me.txtJobNo.Location = New System.Drawing.Point(774, 157)
        Me.txtJobNo.Name = "txtJobNo"
        Me.txtJobNo.Size = New System.Drawing.Size(164, 22)
        Me.txtJobNo.TabIndex = 59
        '
        'txtPOSeq
        '
        Me.txtPOSeq.Location = New System.Drawing.Point(901, 130)
        Me.txtPOSeq.Name = "txtPOSeq"
        Me.txtPOSeq.Size = New System.Drawing.Size(37, 22)
        Me.txtPOSeq.TabIndex = 58
        '
        'txtPONo
        '
        Me.txtPONo.Location = New System.Drawing.Point(774, 130)
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.Size = New System.Drawing.Size(126, 22)
        Me.txtPONo.TabIndex = 57
        '
        'txtSCSeq
        '
        Me.txtSCSeq.Location = New System.Drawing.Point(901, 103)
        Me.txtSCSeq.Name = "txtSCSeq"
        Me.txtSCSeq.Size = New System.Drawing.Size(37, 22)
        Me.txtSCSeq.TabIndex = 56
        '
        'txtSCNo
        '
        Me.txtSCNo.Location = New System.Drawing.Point(774, 103)
        Me.txtSCNo.Name = "txtSCNo"
        Me.txtSCNo.Size = New System.Drawing.Size(126, 22)
        Me.txtSCNo.TabIndex = 55
        '
        'lblSelPrc
        '
        Me.lblSelPrc.AutoSize = True
        Me.lblSelPrc.Location = New System.Drawing.Point(13, 257)
        Me.lblSelPrc.Name = "lblSelPrc"
        Me.lblSelPrc.Size = New System.Drawing.Size(63, 12)
        Me.lblSelPrc.TabIndex = 184
        Me.lblSelPrc.Text = "Selling Price"
        '
        'lblItmCst
        '
        Me.lblItmCst.AutoSize = True
        Me.lblItmCst.Location = New System.Drawing.Point(13, 283)
        Me.lblItmCst.Name = "lblItmCst"
        Me.lblItmCst.Size = New System.Drawing.Size(50, 12)
        Me.lblItmCst.TabIndex = 181
        Me.lblItmCst.Text = "Item Cost"
        '
        'lblCustPONo
        '
        Me.lblCustPONo.AutoSize = True
        Me.lblCustPONo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCustPONo.Location = New System.Drawing.Point(669, 214)
        Me.lblCustPONo.Name = "lblCustPONo"
        Me.lblCustPONo.Size = New System.Drawing.Size(60, 12)
        Me.lblCustPONo.TabIndex = 173
        Me.lblCustPONo.Text = "Cust PO No"
        '
        'lblInvETADat
        '
        Me.lblInvETADat.AutoSize = True
        Me.lblInvETADat.Location = New System.Drawing.Point(669, 295)
        Me.lblInvETADat.Name = "lblInvETADat"
        Me.lblInvETADat.Size = New System.Drawing.Size(89, 12)
        Me.lblInvETADat.TabIndex = 170
        Me.lblInvETADat.Text = "Invoice ETA Date"
        '
        'lblInvETDDat
        '
        Me.lblInvETDDat.AutoSize = True
        Me.lblInvETDDat.Location = New System.Drawing.Point(669, 269)
        Me.lblInvETDDat.Name = "lblInvETDDat"
        Me.lblInvETDDat.Size = New System.Drawing.Size(89, 12)
        Me.lblInvETDDat.TabIndex = 169
        Me.lblInvETDDat.Text = "Invoice ETD Date"
        '
        'lblInvIssDat
        '
        Me.lblInvIssDat.AutoSize = True
        Me.lblInvIssDat.Location = New System.Drawing.Point(669, 243)
        Me.lblInvIssDat.Name = "lblInvIssDat"
        Me.lblInvIssDat.Size = New System.Drawing.Size(90, 12)
        Me.lblInvIssDat.TabIndex = 167
        Me.lblInvIssDat.Text = "Invoice Issue Date"
        '
        'lblCustStyNo
        '
        Me.lblCustStyNo.AutoSize = True
        Me.lblCustStyNo.Location = New System.Drawing.Point(13, 133)
        Me.lblCustStyNo.Name = "lblCustStyNo"
        Me.lblCustStyNo.Size = New System.Drawing.Size(69, 12)
        Me.lblCustStyNo.TabIndex = 164
        Me.lblCustStyNo.Text = "Cust Style No"
        '
        'lblItmDsc
        '
        Me.lblItmDsc.AutoSize = True
        Me.lblItmDsc.Location = New System.Drawing.Point(257, 54)
        Me.lblItmDsc.Name = "lblItmDsc"
        Me.lblItmDsc.Size = New System.Drawing.Size(51, 12)
        Me.lblItmDsc.TabIndex = 163
        Me.lblItmDsc.Text = "Item Desc"
        '
        'lblCoCde
        '
        Me.lblCoCde.AutoSize = True
        Me.lblCoCde.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCoCde.Location = New System.Drawing.Point(669, 52)
        Me.lblCoCde.Name = "lblCoCde"
        Me.lblCoCde.Size = New System.Drawing.Size(51, 12)
        Me.lblCoCde.TabIndex = 161
        Me.lblCoCde.Text = "Company"
        '
        'lbl_Dtl_Rmk
        '
        Me.lbl_Dtl_Rmk.AutoSize = True
        Me.lbl_Dtl_Rmk.Location = New System.Drawing.Point(259, 265)
        Me.lbl_Dtl_Rmk.Name = "lbl_Dtl_Rmk"
        Me.lbl_Dtl_Rmk.Size = New System.Drawing.Size(42, 12)
        Me.lbl_Dtl_Rmk.TabIndex = 159
        Me.lbl_Dtl_Rmk.Text = "Remark"
        '
        'lblPV
        '
        Me.lblPV.AutoSize = True
        Me.lblPV.Location = New System.Drawing.Point(14, 81)
        Me.lblPV.Name = "lblPV"
        Me.lblPV.Size = New System.Drawing.Size(65, 12)
        Me.lblPV.TabIndex = 155
        Me.lblPV.Text = "Prod Vendor"
        '
        'lblOdrQty
        '
        Me.lblOdrQty.AutoSize = True
        Me.lblOdrQty.Location = New System.Drawing.Point(13, 205)
        Me.lblOdrQty.Name = "lblOdrQty"
        Me.lblOdrQty.Size = New System.Drawing.Size(52, 12)
        Me.lblOdrQty.TabIndex = 152
        Me.lblOdrQty.Text = "Order Qty"
        '
        'lblVenItmNo
        '
        Me.lblVenItmNo.AutoSize = True
        Me.lblVenItmNo.Location = New System.Drawing.Point(13, 159)
        Me.lblVenItmNo.Name = "lblVenItmNo"
        Me.lblVenItmNo.Size = New System.Drawing.Size(81, 12)
        Me.lblVenItmNo.TabIndex = 150
        Me.lblVenItmNo.Text = "Vendor Item No"
        '
        'lblCustItmNo
        '
        Me.lblCustItmNo.AutoSize = True
        Me.lblCustItmNo.Location = New System.Drawing.Point(13, 107)
        Me.lblCustItmNo.Name = "lblCustItmNo"
        Me.lblCustItmNo.Size = New System.Drawing.Size(67, 12)
        Me.lblCustItmNo.TabIndex = 148
        Me.lblCustItmNo.Text = "Cust Item No"
        '
        'lblItmNo
        '
        Me.lblItmNo.AutoSize = True
        Me.lblItmNo.Location = New System.Drawing.Point(13, 55)
        Me.lblItmNo.Name = "lblItmNo"
        Me.lblItmNo.Size = New System.Drawing.Size(43, 12)
        Me.lblItmNo.TabIndex = 146
        Me.lblItmNo.Text = "Item No"
        '
        'lblInvoiceNo
        '
        Me.lblInvoiceNo.AutoSize = True
        Me.lblInvoiceNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInvoiceNo.Location = New System.Drawing.Point(669, 187)
        Me.lblInvoiceNo.Name = "lblInvoiceNo"
        Me.lblInvoiceNo.Size = New System.Drawing.Size(57, 12)
        Me.lblInvoiceNo.TabIndex = 144
        Me.lblInvoiceNo.Text = "Invoice No"
        '
        'lblJobNo
        '
        Me.lblJobNo.AutoSize = True
        Me.lblJobNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblJobNo.Location = New System.Drawing.Point(669, 160)
        Me.lblJobNo.Name = "lblJobNo"
        Me.lblJobNo.Size = New System.Drawing.Size(38, 12)
        Me.lblJobNo.TabIndex = 142
        Me.lblJobNo.Text = "Job No"
        '
        'lblPONo
        '
        Me.lblPONo.AutoSize = True
        Me.lblPONo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPONo.Location = New System.Drawing.Point(669, 133)
        Me.lblPONo.Name = "lblPONo"
        Me.lblPONo.Size = New System.Drawing.Size(36, 12)
        Me.lblPONo.TabIndex = 139
        Me.lblPONo.Text = "PO No"
        '
        'lblSCNo
        '
        Me.lblSCNo.AutoSize = True
        Me.lblSCNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSCNo.Location = New System.Drawing.Point(669, 106)
        Me.lblSCNo.Name = "lblSCNo"
        Me.lblSCNo.Size = New System.Drawing.Size(36, 12)
        Me.lblSCNo.TabIndex = 136
        Me.lblSCNo.Text = "SC No"
        '
        'lblSeq
        '
        Me.lblSeq.AutoSize = True
        Me.lblSeq.ForeColor = System.Drawing.Color.Crimson
        Me.lblSeq.Location = New System.Drawing.Point(45, 13)
        Me.lblSeq.Name = "lblSeq"
        Me.lblSeq.Size = New System.Drawing.Size(11, 12)
        Me.lblSeq.TabIndex = 135
        Me.lblSeq.Text = "1"
        '
        'lblSeqtext
        '
        Me.lblSeqtext.AutoSize = True
        Me.lblSeqtext.ForeColor = System.Drawing.Color.Crimson
        Me.lblSeqtext.Location = New System.Drawing.Point(18, 13)
        Me.lblSeqtext.Name = "lblSeqtext"
        Me.lblSeqtext.Size = New System.Drawing.Size(22, 12)
        Me.lblSeqtext.TabIndex = 134
        Me.lblSeqtext.Text = "Seq"
        '
        'tpCLM00001_4
        '
        Me.tpCLM00001_4.Controls.Add(Me.dgSummary)
        Me.tpCLM00001_4.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.tpCLM00001_4.Location = New System.Drawing.Point(4, 22)
        Me.tpCLM00001_4.Name = "tpCLM00001_4"
        Me.tpCLM00001_4.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCLM00001_4.Size = New System.Drawing.Size(946, 524)
        Me.tpCLM00001_4.TabIndex = 2
        Me.tpCLM00001_4.Text = "(4) Summary"
        Me.tpCLM00001_4.UseVisualStyleBackColor = True
        '
        'dgSummary
        '
        Me.dgSummary.AllowUserToAddRows = False
        Me.dgSummary.AllowUserToDeleteRows = False
        Me.dgSummary.AllowUserToResizeRows = False
        Me.dgSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSummary.Location = New System.Drawing.Point(1, 1)
        Me.dgSummary.Name = "dgSummary"
        Me.dgSummary.RowHeadersWidth = 30
        Me.dgSummary.RowTemplate.Height = 24
        Me.dgSummary.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSummary.Size = New System.Drawing.Size(945, 520)
        Me.dgSummary.TabIndex = 101
        '
        'CLM00001
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.cmd_attch)
        Me.Controls.Add(Me.lblSeason)
        Me.Controls.Add(Me.cboSeason)
        Me.Controls.Add(Me.lblClaimPeriod)
        Me.Controls.Add(Me.btcCLM00001)
        Me.Controls.Add(Me.gbPanelReason)
        Me.Controls.Add(Me.lblClaimNo)
        Me.Controls.Add(Me.txtClaimNo)
        Me.Controls.Add(Me.txtClaimPeriod)
        Me.Controls.Add(Me.cboClaimPeriod)
        Me.Controls.Add(Me.StatusBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuStrip
        Me.MaximizeBox = False
        Me.Name = "CLM00001"
        Me.Text = "CLM00001 - Claims Transaction Maintenance (CLM01)"
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms_CopyNPaste.ResumeLayout(False)
        Me.gbPanelReason.ResumeLayout(False)
        Me.gbPanelReason.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.btcCLM00001.ResumeLayout(False)
        Me.tpCLM00001_1.ResumeLayout(False)
        Me.tpCLM00001_1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gbClaimAmtPer.ResumeLayout(False)
        Me.gbClaimAmtPer.PerformLayout()
        Me.gb_Hdr_ClaimAmt.ResumeLayout(False)
        Me.gb_Hdr_ClaimAmt.PerformLayout()
        Me.gb_Hdr_ClaimTo.ResumeLayout(False)
        Me.gb_Hdr_ClaimTo.PerformLayout()
        Me.gbClaimBy.ResumeLayout(False)
        Me.gbClaimBy.PerformLayout()
        Me.tpCLM00001_2.ResumeLayout(False)
        Me.tpCLM00001_2.PerformLayout()
        Me.gb_income.ResumeLayout(False)
        Me.gb_income.PerformLayout()
        Me.gb_pay.ResumeLayout(False)
        Me.gb_pay.PerformLayout()
        Me.tpCLM00001_3.ResumeLayout(False)
        Me.tpCLM00001_3.PerformLayout()
        Me.gbViewOn.ResumeLayout(False)
        Me.gbViewOn.PerformLayout()
        Me.tpCLM00001_4.ResumeLayout(False)
        CType(Me.dgSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Dim addition As String
    Dim Recordstatus As Boolean
    Dim UserEditCombo As Boolean
    Dim Recorddisplay As Boolean
    'Dim bSetToInit As Boolean
    Dim sCheckedLevel As String = "C"

    'Dim ClaimAmt_Header As Boolean

    Public rs_CUBASINF_P As New DataSet
    Public rs_CUBASINF_P_CLM As New DataSet
    Public rs_CUBASINF_P_SALES As New DataSet
    Public rs_CUBASINF_S As New DataSet
    Public rs_CUBASINF_S_All As New DataSet
    Public rs_VNBASINF As New DataSet
    Public rs_SYUSRRIGHT_0 As New DataSet
    Public rs_SYUSRRIGHT_except_0 As New DataSet

    Public rs_SYCLMPST As New DataSet
    Public rs_SYCLMIST As New DataSet
    Public rs_SYCLMSTC As New DataSet
    Public rs_SYCLMSTF As New DataSet
    Public rs_SYCLMAPS As New DataSet
    Public rs_SYCLMTYP As New DataSet

    Public rs_CAORDHDR As New DataSet
    Public rs_CAORDITM As New DataSet
    Public rs_CAORDDTL As New DataSet
    Public rs_CAREMHDR As New DataSet
    Public rs_CAREMITM As New DataSet

    Public rs_search_CAORDDTL As New DataSet
    Public rs_CAORDDTL_ALL As New DataSet
    Public rs_SYSETINF As New DataSet
    Public rs_Currency As New DataSet
    Public rs_CLAIMSTS As New DataSet
    Public rs_SYCOMINF As New DataSet
    Public rs_DOC_GEN As New DataSet
    Public rs_SYCUREX As New DataSet
    Public rs_usr As New DataSet
    Public rs_CACUSLMT As New DataSet
    Public rs_Season As New DataSet

    'Dim ApprovalLimitPer_I As Decimal
    'Dim ApprovalLimitPer_E As Decimal
    Dim ApprovalLimitPer As Decimal = 1.0
    Dim ApprovalRights As Boolean
    Dim SuperApprovalRights As Boolean


    'Check for update or read mode
    Dim sClaimStatus As String

    Dim sHdrPriCust As String
    Dim sHdrSecCust As String
    Dim sHdrVendor As String
    Dim sHdrClaimBy As String
    Dim sHdrClaimType As String
    Dim sDtlClaimType As String
    Dim sDtlPV As String
    Dim sDtlOrdQtyUM As String

    Dim nHdrSearchBy As Integer

    Dim sReadingSeq_Item As String = 1
    Dim sReadingSeq_ship As String = 1

    Dim sHdrClaimAmtPer As String

    Private Const cHdrAppLmtChkPer As Decimal = 0.01
    Private Const cDtlAppLmtChkPer As Decimal = 0.25


    '  Dim mmdPrint_Right As Boolean = False

    Private Sub CLM00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '     Call AccessRight("CLR00001")
        '    mmdPrint_Right = Enq_right

        Call setStatus(cModeInit)
        'Call formInit(mode)
        Call Formstartup(Me.Name)


        rbViewOn_S.Checked = True
        rbViewOn_I.Checked = False




        mmdAdd.Enabled = True
        mmdSearch.Enabled = True


        Call AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        flag_rbViewOn_click = False

        ''' customer control by user login
        '''cocde,cus1no,cus2no
        ''' 

        '2013 should set up the rights functions according to the metrics


        Call FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company

        Call fillcus1no()

        '        Call GetDefaultCompany(cboCoCde, txtCoNam)

        'cboClaimPeriod.Items.Add("04/01/2012 - 03/31/2013")

        'Call fillParameter()

        'Call fillclaimSts()
        'Call fillclaimscategory()

        'Call fill_combo_cur(cbo_Hdr_ClaimAmtCurrency)

        mode = cModeInit

        gspStr = "sp_select_CLCUREX '" & gsCompany & "','','N'"
        rtnLong = execute_SQLStatement(gspStr, rs_curex, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_CLCUREX : " & rtnStr)
        End If

        gl_tor = rs_curex.Tables("RESULT").Rows(0).Item("cce_tor")
        gl_tor = 0
        gl_rate = rs_curex.Tables("RESULT").Rows(0).Item("cce_selrat")

        If rs_Currency.Tables.Count = 0 Then
            rs_Currency.Tables.Add("RESULT")
            rs_Currency.Tables("RESULT").Columns.Add("CURRENCY")

            dsNewRow = rs_Currency.Tables("RESULT").NewRow()
            dsNewRow.Item("CURRENCY") = "USD"
            rs_Currency.Tables("RESULT").Rows.Add(dsNewRow)

            dsNewRow = rs_Currency.Tables("RESULT").NewRow()
            dsNewRow.Item("CURRENCY") = "HKD"
            rs_Currency.Tables("RESULT").Rows.Add(dsNewRow)

            dsNewRow = rs_Currency.Tables("RESULT").NewRow()
            dsNewRow.Item("CURRENCY") = "CNY"
            'rs_Currency.Tables("RESULT").Rows.Add(dsNewRow)
        End If

        If rs_CLAIMSTS.Tables.Count = 0 Then
            rs_CLAIMSTS.Tables.Add("RESULT")
            rs_CLAIMSTS.Tables("RESULT").Columns.Add("claimsts")

            dsNewRow = rs_CLAIMSTS.Tables("RESULT").NewRow()
            dsNewRow.Item("claimsts") = "OPEN - Open/Active"
            rs_CLAIMSTS.Tables("RESULT").Rows.Add(dsNewRow)

            dsNewRow = rs_CLAIMSTS.Tables("RESULT").NewRow()
            dsNewRow.Item("claimsts") = "WAIT - Waiting For Approval"
            rs_CLAIMSTS.Tables("RESULT").Rows.Add(dsNewRow)

            dsNewRow = rs_CLAIMSTS.Tables("RESULT").NewRow()
            dsNewRow.Item("claimsts") = "APVa - Customer Claim Amt confirmed"
            rs_CLAIMSTS.Tables("RESULT").Rows.Add(dsNewRow)

            dsNewRow = rs_CLAIMSTS.Tables("RESULT").NewRow()
            dsNewRow.Item("claimsts") = "APVb - Vendor Claim Amt confirmed"
            rs_CLAIMSTS.Tables("RESULT").Rows.Add(dsNewRow)

            dsNewRow = rs_CLAIMSTS.Tables("RESULT").NewRow()
            dsNewRow.Item("claimsts") = "CANL - Cancel"
            rs_CLAIMSTS.Tables("RESULT").Rows.Add(dsNewRow)

            dsNewRow = rs_CLAIMSTS.Tables("RESULT").NewRow()
            dsNewRow.Item("claimsts") = "CLOS - Closed"
            rs_CLAIMSTS.Tables("RESULT").Rows.Add(dsNewRow)
        End If

        Call AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        gspStr = "sp_list_SYCUREX '','" & Format(Today.Date, "MM/dd/yyyy") & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCUREX, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_SYCUREX :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_CUBASINF_CA '','" & gsUsrID & "','QU','Primary'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_CUBASINF '','P'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_S_All, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_VNBASINF ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_VNBASINF :" & rtnStr)
            Exit Sub
        End If


        gspStr = "sp_select_CUBASINF_Curex '" & "" & "','','0','','N'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_CR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading frmQut_Load sp_select_CUBASINF_Curex :" & rtnStr)
            'Exit Sub
        End If

        gspStr = "sp_list_SYCLMPST ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCLMPST, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_SYCLMPST :" & rtnStr)
            'Exit Sub
        End If

        '2014-05-14
        gspStr = "sp_list_SYCLMIST ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCLMIST, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_SYCLMIST :" & rtnStr)
            'Exit Sub
        End If

        gspStr = "sp_list_SYCLMSTC ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCLMSTC, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_SYCLMSTC :" & rtnStr)
            'Exit Sub
        End If

        gspStr = "sp_list_SYCLMSTF ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCLMSTF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_SYCLMSTF :" & rtnStr)
            'Exit Sub
        End If

        gspStr = "sp_list_SYCLMAPS ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCLMAPS, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_SYCLMAPS :" & rtnStr)
            'Exit Sub
        End If

        gspStr = "sp_list_SYCLMTYP ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCLMTYP, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_SYCLMTYP :" & rtnStr)
            'Exit Sub
        End If

        gspStr = "sp_select_SYCOMINF_M '','All'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCOMINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_select_SYCOMINF_M :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_SYUSRRIGHT '','UCG','" & gsUsrID & "',0"
        rtnLong = execute_SQLStatement(gspStr, rs_SYUSRRIGHT_0, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_select_SYUSRRIGHT :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_SYUSRRIGHT '','UCG','" & gsUsrID & "',1"
        rtnLong = execute_SQLStatement(gspStr, rs_SYUSRRIGHT_except_0, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_select_SYUSRRIGHT :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_CAORDDTL '','ALL'"
        rtnLong = execute_SQLStatement(gspStr, rs_CAORDDTL_ALL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_select_CAORDDTL ALL :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_SYSETINF '','05'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_select_SYSETINF 05 :" & rtnStr)
            Exit Sub
        End If

        'user dept
        gspStr = "sp_select_SYUSRPRF_All '" & gsCompany & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_usr, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_select_SYUSRPRF_All  :" & rtnStr)
            Exit Sub
        End If


        Call format_cboClaimPeriod()
        '        Call format_cboClaimSts()
        Call fillclaimSts()

        'Call format_cboPriCust()
        Call format_cboSecCustAll()
        Call format_cboVendor()
        Call format_cboClaimPaySTS()
        Call format_cboClaimIncomeSTS()
        Call format_cboSETTLE_CUS()
        Call format_cboSETTLE_FTY()
        Call format_cboAPRVSTS()
        Call format_cboClaimType("C")
        Call format_cboCurrency()
        Call SetHdrSeason()

        'Call format_cboCocde()
        'Call format_cboOrdQtyUM()

        'Need to be implemented
        'ApprovalLimitPer_I = 5.0 (Old)
        'ApprovalLimitPer_E = 5.0 (Old)
        'Set it when it is declared

        'Check for Approval Rights
        SuperApprovalRights = False
        ApprovalRights = False


        dr = rs_SYUSRRIGHT_0.Tables("RESULT").Select("yur_doctyp = 'CA'")
        If dr.Length = 1 Then
            SuperApprovalRights = True
            ApprovalRights = True
        Else
            If gsUsrRank <= 3 Then
                ApprovalRights = True
            Else
                ApprovalRights = False
            End If
        End If


        If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
            mmdAdd.Enabled = False
        End If


    End Sub
    Private Sub format_cboClaimPeriod()
        'This function is only for creating new Claim
        Dim strList As String
        Dim sFirstYear As String
        Dim sSecondYear As String

        cboClaimPeriod.Items.Clear()

        If Today.Month > 3 Then
            sFirstYear = (Today.Year() - 2).ToString
            sSecondYear = sFirstYear + 1
            strList = "04/01/" + sFirstYear + " - 03/31/" + sSecondYear

            If sFirstYear >= "2014" Then
                cboClaimPeriod.Items.Add(strList)
            End If

            sFirstYear = sSecondYear
            sSecondYear = sFirstYear + 1
            strList = "04/01/" + sFirstYear + " - 03/31/" + sSecondYear

            If sFirstYear >= "2014" Then
                cboClaimPeriod.Items.Add(strList)
            End If

            sFirstYear = sSecondYear
            sSecondYear = sFirstYear + 1
            strList = "04/01/" + sFirstYear + " - 03/31/" + sSecondYear

            If sFirstYear >= "2014" Then
                cboClaimPeriod.Items.Add(strList)
            End If

            cboClaimPeriod.Text = strList
        Else
            sFirstYear = (Today.Year() - 3).ToString
            sSecondYear = sFirstYear + 1
            strList = "04/01/" + sFirstYear + " - 03/31/" + sSecondYear

            If sFirstYear >= "2014" Then
                cboClaimPeriod.Items.Add(strList)
            End If

            sFirstYear = sSecondYear
            sSecondYear = sFirstYear + 1
            strList = "04/01/" + sFirstYear + " - 03/31/" + sSecondYear

            If sFirstYear >= "2014" Then
                cboClaimPeriod.Items.Add(strList)
            End If

            sFirstYear = sSecondYear
            sSecondYear = sFirstYear + 1
            strList = "04/01/" + sFirstYear + " - 03/31/" + sSecondYear
            If sFirstYear >= "2014" Then
                cboClaimPeriod.Items.Add(strList)
            End If
            cboClaimPeriod.Text = strList

            End If



    End Sub


    Private Sub format_cboClaimSts()
        Dim i As Integer
        Dim strList As String

        cboClaimSts.Items.Clear()

        If rs_CLAIMSTS.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_CLAIMSTS.Tables("RESULT").Rows.Count - 1
                strList = rs_CLAIMSTS.Tables("RESULT").Rows(i).Item("claimsts")
                If strList <> "" Then
                    cboClaimSts.Items.Add(strList)
                End If
            Next i
        End If
    End Sub

    Private Sub format_cboPriCust()
        Dim i As Integer
        Dim strList As String

        cboPriCust.Items.Clear()

        If rs_CUBASINF_P.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_CUBASINF_P.Tables("RESULT").Rows.Count - 1
                strList = ""
                If rs_CUBASINF_P.Tables("RESULT").Rows(i).Item("cbi_cusno") > "50000" Then
                    strList = rs_CUBASINF_P.Tables("RESULT").Rows(i).Item("cbi_cusno") & " - " & rs_CUBASINF_P.Tables("RESULT").Rows(i).Item("cbi_cussna")
                End If

                If strList <> "" Then
                    cboPriCust.Items.Add(strList)
                End If
            Next i
        End If
    End Sub

    Private Sub format_cboSecCustAll()
        Dim i As Integer
        Dim strList As String

        cboSecCust.Items.Clear()

        If rs_CUBASINF_S_All.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_CUBASINF_S_All.Tables("RESULT").Rows.Count - 1
                strList = ""
                If rs_CUBASINF_S_All.Tables("RESULT").Rows(i).Item("cbi_cusno") > "50000" Then
                    strList = rs_CUBASINF_S_All.Tables("RESULT").Rows(i).Item("cbi_cusno") & " - " & rs_CUBASINF_S_All.Tables("RESULT").Rows(i).Item("cbi_cussna")
                End If

                If strList <> "" Then
                    cboSecCust.Items.Add(strList)
                End If
            Next i
        End If
    End Sub

    Private Sub format_cboVendor()
        Dim i As Integer
        Dim strList As String

        cboVendor.Items.Clear()

        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                strList = rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensna")
                If strList <> "" Then
                    cboVendor.Items.Add(strList)
                End If
            Next i
        End If
    End Sub

    Private Sub format_cboClaimPaySTS()
        Dim i As Integer
        Dim strList As String


        If rs_SYCLMPST.Tables.Count = 0 Then
            Exit Sub
        End If

        cboClaimPaySTS.Items.Clear()

        If rs_SYCLMPST.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYCLMPST.Tables("RESULT").Rows.Count - 1

                strList = Trim(rs_SYCLMPST.Tables("RESULT").Rows(i).Item("ycp_cde")) & " - " & Trim(rs_SYCLMPST.Tables("RESULT").Rows(i).Item("ycp_dsc"))

                If strList <> "" Then
                    If Microsoft.VisualBasic.Left(strList, 1) = "P" Then
                        cboClaimPaySTS.Items.Add(strList)
                    End If
                End If
            Next i
        End If
    End Sub

    Private Sub format_cboSETTLE_CUS()
        Dim i As Integer
        Dim strList As String


        If rs_SYCLMSTC.Tables.Count = 0 Then
            Exit Sub
        End If

        cboSETTLE_CUS.Items.Clear()

        If rs_SYCLMSTC.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYCLMSTC.Tables("RESULT").Rows.Count - 1

                strList = rs_SYCLMSTC.Tables("RESULT").Rows(i).Item("ycc_dsc")

                If strList <> "" Then
                    cboSETTLE_CUS.Items.Add(strList)

                End If
            Next i
        End If
    End Sub

    Private Sub format_cboSETTLE_FTY()
        Dim i As Integer
        Dim strList As String


        If rs_SYCLMSTF.Tables.Count = 0 Then
            Exit Sub
        End If

        cboSETTLE_FTY.Items.Clear()

        If rs_SYCLMSTF.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYCLMSTF.Tables("RESULT").Rows.Count - 1

                strList = rs_SYCLMSTF.Tables("RESULT").Rows(i).Item("ycf_dsc")

                If strList <> "" Then
                    cboSETTLE_FTY.Items.Add(strList)

                End If
            Next i
        End If
    End Sub
    Private Sub format_cboAPRVSTS()
        Dim i As Integer
        Dim strList As String


        If rs_SYCLMAPS.Tables.Count = 0 Then
            Exit Sub
        End If

        cboAPRVSTS.Items.Clear()

        If rs_SYCLMAPS.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYCLMAPS.Tables("RESULT").Rows.Count - 1

                strList = rs_SYCLMAPS.Tables("RESULT").Rows(i).Item("yca_cde") & " - " & rs_SYCLMAPS.Tables("RESULT").Rows(i).Item("yca_dsc")

                If strList <> "" Then
                    cboAPRVSTS.Items.Add(strList)

                End If
            Next i
        End If
    End Sub


    Private Sub format_cboClaimType(ByVal claimtby As String)
        Dim i As Integer
        Dim strList As String

        Dim claimtby_check As String
        claimtby_check = ""

        If rs_SYCLMTYP.Tables.Count = 0 Then
            Exit Sub
        End If

        cboClaimType.Text = ""
        cboClaimType.Items.Clear()
        cbo_Dtl_ClaimType.Items.Clear()

        If rs_SYCLMTYP.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYCLMTYP.Tables("RESULT").Rows.Count - 1
                Select Case claimtby
                    Case "C"

                        cbo_Hdr_ClaimToHKOAmtCur.Enabled = False

                        lblVendor.ForeColor = Color.Black


                        claimtby_check = rs_SYCLMTYP.Tables("RESULT").Rows(i).Item("yct_cus")

                        If rbClaimAmtPer_C.Checked = True Then
                            'claim per cus

                            If Val(rs_SYCLMTYP.Tables("RESULT").Rows(i).Item("yct_cde")) >= 3 _
                            And Val(rs_SYCLMTYP.Tables("RESULT").Rows(i).Item("yct_cde")) <= 11 _
                            And Val(rs_SYCLMTYP.Tables("RESULT").Rows(i).Item("yct_cde")) <> 98 Then
                                claimtby_check = "N"
                            End If

                        Else
                            'claim per Item/ship
                            '                            Or Val(rs_SYCLMTYP.Tables("RESULT").Rows(i).Item("yct_cde")) = 98 _
                            '20140522

                            If Val(rs_SYCLMTYP.Tables("RESULT").Rows(i).Item("yct_cde")) = 1 _
                            Or Val(rs_SYCLMTYP.Tables("RESULT").Rows(i).Item("yct_cde")) = 2 _
                            Then
                                claimtby_check = "N"
                            End If

                        End If

                    Case "V"
                        claimtby_check = rs_SYCLMTYP.Tables("RESULT").Rows(i).Item("yct_ven")
                        lblVendor.ForeColor = Color.Green
                        cbo_Hdr_ClaimToHKOAmtCur.Enabled = False
                        chkconfirmclm.Enabled = False
                        chkvalidclm.Enabled = False
                    Case "U"
                        claimtby_check = rs_SYCLMTYP.Tables("RESULT").Rows(i).Item("yct_ucp")
                        lblVendor.ForeColor = Color.Green
                        chkconfirmclm.Enabled = False
                        chkvalidclm.Enabled = False
                    Case Else
                        claimtby_check = "Y"
                End Select

                strList = Trim(rs_SYCLMTYP.Tables("RESULT").Rows(i).Item("yct_cde") & " - " & rs_SYCLMTYP.Tables("RESULT").Rows(i).Item("yct_dsc"))
                If strList <> "" Then
                    If claimtby_check = "Y" Then


                        cboClaimType.Items.Add(strList)
                        cbo_Dtl_ClaimType.Items.Add(strList)


                    End If
                End If
            Next i
        End If
        '''20131205
        ''' 
        cboPriCust.Enabled = True



    End Sub
   

    Private Sub format_cboCurrency()
        Dim i As Integer
        Dim s As String

        For i = 0 To rs_Currency.Tables("RESULT").Rows.Count - 1
            s = rs_Currency.Tables("RESULT").Rows(i).Item("CURRENCY")

            cbo_Hdr_SalesAmtCurrency.Items.Add(s)
            'cbo_Hdr_GrsPftCurrency.Items.Add(s)
            cbo_Hdr_AppLmtChkCurrency.Items.Add(s)
            cbo_Hdr_RemainClaimCurrency.Items.Add(s)

            cbo_Hdr_ClaimAmtCurrency.Items.Add(s)

            cbo_Hdr_ClaimToInsAmtCur.Items.Add(s)
            cbo_Hdr_ClaimToVNAmtCur.Items.Add(s)
            cbo_Hdr_ClaimToHKOAmtCur.Items.Add(s)

            cbo_Hdr_ClaimToInsAmtCurrency.Items.Add(s)
            cbo_Hdr_ClaimToVNAmtCurrency.Items.Add(s)
            'cbo_Hdr_ClaimToEVNAmtCurrency.Items.Add(s)
            cbo_Hdr_ClaimToHKOAmtCurrency.Items.Add(s)

            cbo_income_cur.Items.Add(s)
            cbo_pay_cur.Items.Add(s)

        Next i
    End Sub

    Private Sub formInit(ByVal m As String)
        Recorddisplay = True
        Call clearAllDisplay(Me)

        Call resetcmdButton(m)

        Call resetDisplay(m)

        Me.StatusBar.Text = m
        Recorddisplay = False
    End Sub

    Private Sub clearAllDisplay(ByVal fv As Control)
        Dim v As Control
        For Each v In fv.Controls

            If TypeOf v Is BaseTabControl Then
                Dim btc As BaseTabControl
                btc = v
                Dim i As Integer
                For i = 0 To btc.TabPages.Count - 1
                    Call clearAllDisplay(btc.TabPages(i))
                Next i
            ElseIf TypeOf v Is GroupBox Then
                Call clearAllDisplay(v)
                v.Enabled = False
            Else
                If TypeOf v Is TextBox Or TypeOf v Is MaskedTextBox Or TypeOf v Is ComboBox Or TypeOf v Is RichTextBox Then
                    v.Text = ""
                    v.Enabled = False
                ElseIf TypeOf v Is ListBox Then
                    Dim lb As ListBox
                    lb = v
                    lb.Items.Clear()
                    v.Enabled = False
                ElseIf TypeOf v Is CheckBox Then
                    Dim cb As CheckBox
                    cb = v
                    cb.Checked = False
                    v.Enabled = False
                ElseIf TypeOf v Is DataGridView Then
                    Dim dg As DataGridView
                    dg = v
                    dg.DataSource = Nothing
                End If
            End If
        Next v
    End Sub

    Private Sub resetcmdButton(ByVal m As String)
        If m = cModeInit Then

            If Enq_right_local = True Then
                mmdAdd.Enabled = True
                '                cmdSearch.Enabled = True
            Else
                mmdAdd.Enabled = False
                '               cmdSearch.Enabled = False
            End If


            mmdSave.Enabled = False

            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = True
            mmdClear.Enabled = False

            'cmdSearch.Enabled = False

            mmdInsRow.Enabled = False

            mmdDelRow.Enabled = False


            mmdExit.Enabled = True

            mmdInsRow.Enabled = False

            Me.chkapv1a.Enabled = False
            Me.chkapv1b.Enabled = False

            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False
            'Me.cb_Dtl_APV1.Enabled = False
            'Me.cb_Dtl_APV2.Enabled = False
        ElseIf m = cModeAdd Then
            mmdAdd.Enabled = False
            '''
            mmdSave.Enabled = True

            'cmdSave.Enabled = False

            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdClear.Enabled = True

            'cmdSearch.Enabled = False

            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False

            mmdExit.Enabled = True

            mmdInsRow.Enabled = False
        ElseIf m = cModeUpd Then
            mmdAdd.Enabled = False
            mmdSave.Enabled = True
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdClear.Enabled = True

            'cmdSearch.Enabled = False

            If sClaimStatus = "OPEN" Then
                mmdInsRow.Enabled = True
                mmdInsRow.Enabled = True
            Else
                mmdInsRow.Enabled = False
                mmdInsRow.Enabled = False
            End If
            mmdDelRow.Enabled = False


            mmdExit.Enabled = True

        ElseIf m = cModeRead Then
            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdClear.Enabled = True

            'cmdSearch.Enabled = False

            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False

            mmdExit.Enabled = True

            Me.mmdInsRow.Enabled = False
        End If
    End Sub

    Private Sub resetDisplay(ByVal m As String)
        If m = cModeInit Then
            Me.txtClaimNo.Enabled = True

            Me.cboClaimPeriod.Visible = False
            Me.txtClaimPeriod.Visible = True

            Me.rbClaimAmtPer_C.Checked = False
            Me.rbClaimAmtPer_I.Checked = False
            Me.rbClaimAmtPer_S.Checked = False
            sHdrClaimAmtPer = "C"

            'Me.lbl_Hdr_AppLmtChkPer_E.Text = ""
            'Me.lbl_Hdr_AppLmtChkPer_I.Text = ""
            Me.lbl_Hdr_AppLmtChkPer_Ttl.Text = ""
            Me.lbl_Hdr_ExceedAppLmt.Visible = False

            Me.lbl_Dtl_AppLmtChkPer.Text = ""
            'Me.lbl_Dtl_ExceedAppLmt.Visible = False

            Me.sReadingSeq_Item = 1
            Me.sReadingSeq_ship = 1

            '  Me.btcCLM00001.TabPages(0).Enabled = False
            Me.btcCLM00001.TabPages(0).Enabled = True
            Me.btcCLM00001.TabPages(1).Enabled = False
            Me.btcCLM00001.TabPages(2).Enabled = False

            btcCLM00001.SelectedIndex = 0

            Recordstatus = False
            Recorddisplay = False
            UserEditCombo = False
            'ClaimAmt_Header = False

            sClaimStatus = ""
            nHdrSearchBy = 0
            sReadingSeq_Item = 1
            sReadingSeq_ship = 1
            sCheckedLevel = "C"
            addition = ""

            txtClaimNo.Focus()

            dgSummary.DataSource = Nothing



        ElseIf m = cModeAdd Then
            Me.txtClaimNo.Text = ""
            Me.txtClaimNo.Enabled = False

            Me.btcCLM00001.TabPages(0).Enabled = True
            Me.btcCLM00001.TabPages(1).Enabled = True
            Me.btcCLM00001.TabPages(2).Enabled = True
            '''Me.btcCLM00001.TabPages(1).Enabled = False
            '''Me.btcCLM00001.TabPages(2).Enabled = False

            'Me.txtClaimIssDate.Enabled = True
            'Me.txtClaimIssDate.Text = Format(Date.Today, "MM/dd/yyyy")
            Me.cboClaimPeriod.Enabled = True
            Me.cboClaimPeriod.Visible = True
            Me.txtClaimPeriod.Enabled = False
            Me.txtClaimPeriod.Visible = False

            display_combo("OPEN", cboClaimSts)
            sClaimStatus = "OPEN"
            addition = sClaimStatus

            'Initial for Customer fields
            cbo_Hdr_SalesAmtCurrency.Text = "USD"
            'cbo_Hdr_GrsPftCurrency.Text = "USD"
            cbo_Hdr_AppLmtChkCurrency.Text = "USD"
            cbo_Hdr_RemainClaimCurrency.Text = "USD"

            cbo_Hdr_ClaimAmtCurrency.Text = "USD"

            cbo_Hdr_ClaimToInsAmtCurrency.Text = "USD"
            cbo_Hdr_ClaimToVNAmtCurrency.Text = "USD"
            'cbo_Hdr_ClaimToEVNAmtCurrency.Text = "USD"
            cbo_Hdr_ClaimToHKOAmtCurrency.Text = "USD"

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cocde") = ""

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salcur") = cbo_Hdr_SalesAmtCurrency.Text

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salttlamt") = "0.00"
            'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salttlamt_i") = "0.00"
            'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salttlamt_e") = "0.00"

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_grspftamt") = "0.00"
            'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_grspftamt_i") = "0.00"
            'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_grspftamt_e") = "0.00"

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtamt") = "0.00"
            'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtamt_i") = "0.00"
            'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtamt_e") = "0.00"

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtper") = Decimal.Round(cHdrAppLmtChkPer * 100, 0)
            'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtper_i") = "0.00"
            'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtper_e") = "0.00"

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caremamt") = "0.00"

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cacur") = cbo_Hdr_ClaimAmtCurrency.Text

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_org") = "0.00"
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_final") = "0.00"
            'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cavsgrspft") = "0.00"

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app1flg") = ""
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app1flgby") = ""
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app1flgdat") = "01/01/1900"

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoinscur") = cbo_Hdr_ClaimToInsAmtCurrency.Text
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoinsamt") = "0.00"
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catovncur") = cbo_Hdr_ClaimToVNAmtCurrency.Text
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catovnamt") = "0.00"
            'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoevncur") = cbo_Hdr_ClaimToEVNAmtCurrency.Text
            'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoevnamt") = "0.00"
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catohkocur") = cbo_Hdr_ClaimToHKOAmtCurrency.Text
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catohkoamt") = "0.00"

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app2flg") = ""
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app2flgby") = ""
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app2flgdat") = "01/01/1900"

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_curexrat") = "0.00"
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_curexeffdat") = rs_SYCUREX.Tables("RESULT").Rows(0).Item("yce_effdat")
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salesmanger") = ""
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salesteam") = ""
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~"
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_updusr") = "~*ADD*~"

           
        ElseIf m = cModeUpd Then
            Me.txtClaimNo.Enabled = False

            Me.btcCLM00001.TabPages(0).Enabled = True
            Me.btcCLM00001.TabPages(1).Enabled = True
            Me.btcCLM00001.TabPages(2).Enabled = True

            Me.gbClaimAmtPer.Enabled = False
            Me.rbClaimAmtPer_C.Enabled = False
            Me.rbClaimAmtPer_I.Enabled = False
            Me.rbClaimAmtPer_S.Enabled = False

            Me.cboClaimType.Enabled = False

            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then

                Me.txt_Hdr_Rmk.Enabled = True
                Me.txt_Hdr_Rmk.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_Hdr_Rmk.ReadOnly = False

                Me.txt_Hdr_CustComment.Enabled = True
                Me.txt_Hdr_CustComment.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_Hdr_CustComment.ReadOnly = False

                Me.txt_Hdr_Finding.Enabled = True
                Me.txt_Hdr_Finding.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_Hdr_Finding.ReadOnly = False

            Else

                Me.txt_Hdr_Rmk.Enabled = True
                Me.txt_Hdr_CustComment.Enabled = True
                Me.txt_Hdr_Finding.Enabled = True
                txt_Hdr_Rmk.ReadOnly = False
                txt_Hdr_CustComment.ReadOnly = False
                txt_Hdr_Finding.ReadOnly = False

            End If





            'If rs_CAORDDTL.Tables("RESULT").Rows.Count > 0 Then
            Me.txt_Dtl_Rmk.Enabled = True
            'Me.txt_Dtl_OrgClaimQty.Enabled = True
            'Me.cbo_Dtl_ClaimType.Enabled = True

            If sClaimStatus = "OPEN" Then
                Me.chkDelete.Enabled = True
            End If
            'End If
            addition = sClaimStatus
        ElseIf m = cModeRead Then
            Me.txtClaimNo.Enabled = False

            Me.btcCLM00001.TabPages(0).Enabled = True
            Me.btcCLM00001.TabPages(1).Enabled = True
            Me.btcCLM00001.TabPages(2).Enabled = True
        End If
    End Sub

    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        If checkFocus(Me) Then Exit Sub
        If Recordstatus = True Then
            If MsgBox("Are you sure to quit without saving record?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Me.Close()
    End Sub

    Private Sub SetStatusBar(ByVal mode As String)
        If mode = cModeRead Or mode = cModeInit Or mode = cModeUpd Or mode = cModeSave Then
            Me.StatusBar.Text = mode
        End If
    End Sub

    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        If checkFocus(Me) Then Exit Sub
        mode = cModeInit

        If Recordstatus = True Then
            If MsgBox("Are you sure to clear without saving record?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Dim docno As String
        docno = Me.txtClaimNo.Text


        'Me.formInit(mode)

        btcCLM00001.SelectedIndex = 0

        Call setStatus(cModeInit)
        Me.txtClaimNo.Text = docno
    End Sub

    Private Sub mmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAdd.Click
        If checkFocus(Me) Then Exit Sub
        Cursor = Cursors.WaitCursor
        flag_rbViewOn_click = False

        If Recordstatus = True Then
            If MsgBox("Are you sure to clear without saving record?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Cursor = Cursors.Default

                Exit Sub
            End If
        End If

        setStatus(cModeInit)



        mode = cModeAdd



        ''add the filling cus1no here
        ''''''''''''''''''''''''''''''''''''''''''''''
        gspStr = "sp_select_CUBASINF_PRI '" & cboCoCde.Text & "','" & gsUsrID & "','" & "QU" & "'"
        'Fixing global company code problem at 20100420
        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        gspStr = ""
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then  '*** An error has occured
            MsgBox("Error on loading QUM00001  sp_select_CUBASINF_PRI : " & rtnStr)
            Exit Sub
        Else
            rs_CUBASINF_P = rs.Copy() '*** Cus for company
        End If
        Call fillcboPriCust() '
        ''''''''''''''''''''''''''''''''''''''''''''''
        'Call fillcus1no()


        gspStr = "sp_select_CAORDHDR '',''"
        rtnLong = execute_SQLStatement(gspStr, rs_CAORDHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdAdd_Click sp_select_CAORDHDR : " & rtnStr)
            Exit Sub
        End If

        rs_CAORDHDR.Tables("RESULT").Rows.Add()


        Dim i As Integer
        For i = 0 To rs_CAORDHDR.Tables("RESULT").Columns.Count - 1
            rs_CAORDHDR.Tables("RESULT").Columns(i).ReadOnly = False
        Next i

        gspStr = "sp_select_CAORDITM '',''"
        rtnLong = execute_SQLStatement(gspStr, rs_CAORDITM, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdAdd_Click sp_select_CAORDITM : " & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_CAORDDTL '',''"
        rtnLong = execute_SQLStatement(gspStr, rs_CAORDDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdAdd_Click sp_select_CAORDDTL : " & rtnStr)
            Exit Sub
        End If

        Call setStatus(cModeAdd)
        'Call formInit(mode)
        'Call cbAdhoc.Focus()
        cboClaimPeriod.Focus()

        Recordstatus = True

        Cursor = Cursors.Default

        '''20131205
        ''' 
        mmdFind.Enabled = False
        'dtHDRRCVDAT.Enabled = False
        mmdAdd.Enabled = False



    End Sub

    Private Sub cboClaimPeriod_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboClaimPeriod.KeyPress
        '        If Not cboClaimPeriod.SelectedIndex = -1 Then
        txtClaimPeriod.Text = cboClaimPeriod.Text
        cboSeason.Enabled = True


        ''Me.gbClaimBy.Enabled = True
        'Me.rbClaimBy_C.Enabled = True
        'Me.rbClaimBy_V.Enabled = True
        'Me.rbClaimBy_U.Enabled = True
        'Me.rbClaimBy_C.Checked = True

        ''format_gbClaimBy_Add()
        '''20131205
        ''' 
        cboClaimSts.Enabled = False
        cboClaimPeriod.Enabled = False
        'End If

    End Sub

    Private Sub cboClaimPeriod_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboClaimPeriod.LostFocus
        txtClaimPeriod.Text = cboClaimPeriod.Text
        cboSeason.Enabled = True

        cboClaimSts.Enabled = False
        cboClaimPeriod.Enabled = False

        cboSeason.Focus()


    End Sub


    Private Sub format_gbClaimBy_Add()
        Me.cboPriCust.Enabled = False
        Me.cboSecCust.Enabled = False
        Me.cboSecCust.Text = Nothing
        Me.cboVendor.Enabled = True
        Me.cboVendor.Text = Nothing

        Me.cboCoCde.Enabled = True

        '20131115
        '        Me.cboCoCde.Focus()

        Me.cboPriCust.Enabled = True
        Me.cboPriCust.Focus()

        Call fillcboPriCust()



    End Sub

    Private Sub rbClaimBy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbClaimBy_C.CheckedChanged, rbClaimBy_V.CheckedChanged, rbClaimBy_U.CheckedChanged
        format_gbClaimBy_Add()
        If rbClaimBy_C.Checked = True Then
            format_cboClaimType("C")
        
        ElseIf rbClaimBy_V.Checked = True Then
            format_cboClaimType("V")
        Else
            format_cboClaimType("U")
        End If
    End Sub

    Private Sub cboPriCust_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPriCust.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            If rbClaimBy_C.Checked = True Then
                If checkValidCombo(cboPriCust, cboPriCust.Text) Then
                    Call format_cboSecCust(Split(cboPriCust.Text, " - ")(0).ToString)
                    If cboSecCust.Items.Count > 0 Then
                        cboSecCust.Enabled = True
                        '20131125 enable
                        Call format_inputClaimBy_after()
                        cboSecCust.Select()
                    Else
                        cboSecCust.Enabled = False
                        Call format_inputClaimBy_after()
                    End If
                Else
                    showCheckboxErrMsg(cboPriCust)
                    cboSecCust.Enabled = False
                    cboSecCust.Text = Nothing
                    cboVendor.Enabled = True
                    cboVendor.Text = Nothing
                End If
            ElseIf rbClaimBy_V.Checked = True Or rbClaimBy_U.Checked = True Then
                If checkValidCombo(cboPriCust, cboPriCust.Text) Then
                    Call format_cboSecCust(Split(cboPriCust.Text, " - ")(0).ToString)
                    If cboSecCust.Items.Count > 0 Then
                        cboSecCust.Enabled = True
                        cboSecCust.Select()
                    Else
                        cboSecCust.Enabled = False
                        cboVendor.Enabled = True
                        cboVendor.Select()
                    End If
                Else
                    showCheckboxErrMsg(cboPriCust)
                    cboSecCust.Enabled = False
                    cboSecCust.Text = Nothing
                    cboVendor.Enabled = True
                    cboVendor.Text = Nothing
                End If
                '''
                'Call format_inputClaimBy_after()
            End If
        End If
    End Sub

    Private Sub cboPriCust_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPriCust.KeyUp
        If cboPriCust.Text.Length > 0 Then
            If e.KeyCode <> Keys.Back Then
                sHdrPriCust = cboPriCust.Text
                auto_search_combo(cboPriCust)
            Else
                cboPriCust.Text = sHdrPriCust.Substring(0, sHdrPriCust.Length - 1)
                auto_search_combo(cboPriCust)
                sHdrPriCust = sHdrPriCust.Substring(0, sHdrPriCust.Length - 1)
            End If
        End If
    End Sub

    Private Sub cboSecCust_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSecCust.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            If checkValidCombo(cboSecCust, cboSecCust.Text) Then
                If rbClaimBy_C.Checked = True Then
                    Call format_inputClaimBy_after()
                ElseIf rbClaimBy_V.Checked = True Or rbClaimBy_U.Checked = True Then
                    cboVendor.Enabled = True
                    cboVendor.Select()
                End If
            Else
                showCheckboxErrMsg(cboSecCust)
                cboVendor.Enabled = True
                cboVendor.Text = Nothing
            End If
        End If
    End Sub

    Private Sub cboSecCust_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSecCust.KeyUp
        If cboSecCust.Text.Length > 0 Then
            If e.KeyCode <> Keys.Back Then
                sHdrSecCust = cboSecCust.Text
                auto_search_combo(cboSecCust)
            Else
                cboSecCust.Text = sHdrSecCust.Substring(0, sHdrSecCust.Length - 1)
                auto_search_combo(cboSecCust)
                sHdrSecCust = sHdrSecCust.Substring(0, sHdrSecCust.Length - 1)
            End If
        End If
    End Sub

    Private Sub cboVendor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboVendor.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            If checkValidCombo(cboVendor, cboVendor.Text) Then
                Call format_inputClaimBy_after()
                cboPriCust.Enabled = False
                cboVendor.Enabled = False
                rbClaimBy_C.Enabled = False
                rbClaimBy_V.Enabled = False
                rbClaimBy_U.Enabled = False
            Else
                showCheckboxErrMsg(cboVendor)
            End If
        End If
    End Sub

    Private Sub cboVendor_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVendor.KeyUp
        If cboVendor.Text.Length > 0 Then
            If e.KeyCode <> Keys.Back Then
                sHdrVendor = cboVendor.Text
                auto_search_combo(cboVendor)
            Else
                cboVendor.Text = sHdrVendor.Substring(0, sHdrVendor.Length - 1)
                auto_search_combo(cboVendor)
                sHdrVendor = sHdrVendor.Substring(0, sHdrVendor.Length - 1)
            End If
        End If
    End Sub

    Private Sub showCheckboxErrMsg(ByVal cbo As ComboBox)
        MsgBox("""" & cbo.Text & """ does not exist in the list")
        cbo.Select()
    End Sub

    Private Sub format_inputClaimBy_after()
        chkconfirmclm.Enabled = True
        chkvalidclm.Enabled = True

        'gbClaimAmtPer.Enabled = True

        'rbClaimAmtPer_C.Enabled = True
        'rbClaimAmtPer_I.Enabled = True
        'rbClaimAmtPer_S.Enabled = True

        'chkreplace.Enabled = True

    End Sub


    Private Sub format_cboSecCust(ByVal PriCust As String)
        gspStr = "sp_select_CUBASINF '','" & PriCust & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P_SALES, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading format_cboSecCust sp_select_CUBASINF :" & rtnStr)
            Exit Sub
        End If

        If rs_CUBASINF_P_SALES.Tables("RESULT").Rows.Count > 0 Then
            txtSalesManager.Text = rs_CUBASINF_P_SALES.Tables("RESULT").Rows(0).Item("cbi_salmgt")
            txtSalesTeam.Text = "Sales Team " & rs_CUBASINF_P_SALES.Tables("RESULT").Rows(0).Item("ysr_saltem") & _
                                " - " & rs_CUBASINF_P_SALES.Tables("RESULT").Rows(0).Item("cbi_srname")
        End If

        cboSecCust.Items.Clear()

        gspStr = "sp_select_CUBASINF_Q ''," & PriCust & ",'Secondary'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_S, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001 #002 sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If

        Dim i As Integer
        Dim strList As String

        If rs_CUBASINF_S.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_CUBASINF_S.Tables("RESULT").Rows.Count - 1
                strList = ""
                strList = rs_CUBASINF_S.Tables("RESULT").Rows(i).Item("csc_seccus") & " - " & rs_CUBASINF_S.Tables("RESULT").Rows(i).Item("cbi_cussna")
                If strList <> "" Then
                    cboSecCust.Items.Add(strList)
                End If
            Next i
        End If
    End Sub

    Private Sub rbClaimAmtPer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbClaimAmtPer_I.CheckedChanged, rbClaimAmtPer_S.CheckedChanged, rbClaimAmtPer_C.CheckedChanged
        If rbClaimAmtPer_C.Checked = True Or rbClaimAmtPer_I.Checked = True Or rbClaimAmtPer_S.Checked Then
            If mode = cModeAdd Then
                gbClaimBy.Enabled = False
                cboClaimPeriod.Enabled = False
                mmdInsRow.Enabled = False
                cboClaimType.Enabled = True
                cboClaimType.Focus()
                getBasicInfo()
            ElseIf mode = cModeUpd Then
                gbClaimBy.Enabled = False
                cboClaimPeriod.Enabled = False
                cboClaimType.Enabled = False
                mmdInsRow.Enabled = True
                getBasicInfo()
            ElseIf mode = cModeRead Then
                gbClaimBy.Enabled = False
                cboClaimPeriod.Enabled = False
                cboClaimType.Enabled = False
                mmdInsRow.Enabled = False

            End If
        End If
        '20131206
        Call set_clamitype()
    End Sub

    Private Sub getBasicInfo()
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cocde") = ""
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordno") = txtClaimNo.Text
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = Split(cboClaimSts.Text, " - ")(0)
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claPeriod") = txtClaimPeriod.Text

        If rs_CAORDHDR.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_clasearchby") = nHdrSearchBy

        If rbClaimBy_C.Checked = True Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claby") = "C"
        ElseIf rbClaimBy_V.Checked = True Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claby") = "V"
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claby") = "U"
        End If

        If cboPriCust.Text = "" Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus1no") = ""
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus1no") = Split(cboPriCust.Text, " - ")(0)
        End If

        If cboSecCust.Text = "" Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus2no") = ""
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus2no") = Split(cboSecCust.Text, " - ")(0)
        End If

        If cboVendor.Text = "" Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_venno") = ""
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_venno") = Split(cboVendor.Text, " - ")(0)
        End If

        If rbClaimAmtPer_C.Checked Then
            sHdrClaimAmtPer = "C"
        ElseIf rbClaimAmtPer_I.Checked Then
            sHdrClaimAmtPer = "I"
        Else
            sHdrClaimAmtPer = "S"
        End If

        'If Not IsNumeric(sHdrClaimAmtPer) Then
        '    sHdrClaimAmtPer = "0"
        'End If
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_per") = sHdrClaimAmtPer
    End Sub


    'Private Sub cboClaimType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboClaimType.Click
        'If rbClaimAmtPer_C.Checked = True Then
        'ElseIf rbClaimAmtPer_I.Checked = True Then
        'Else
        'End If


    'End Sub

    Private Sub cboClaimType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboClaimType.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            If checkValidCombo(cboClaimType, cboClaimType.Text) Then
                Call format_input_cboClaimType_after()
                ''Call format_inputDtl_insert_after()
                Call set_APVS()
            Else
                showCheckboxErrMsg(cboClaimType)
            End If
        End If


        '''20131206
        Call fill_CAORDHDR()

        '''20140311 

        cbo_Hdr_ClaimAmtCurrency.Enabled = True
        txt_Hdr_OrgClaimAmt.Enabled = True
        txt_Hdr_FinalClaimAmt.Enabled = True

        txt_Hdr_ClaimToInsAmt.Enabled = True
        txt_Hdr_ClaimToVNAmt.Enabled = True
        txt_Hdr_ClaimToHKOAmt.Enabled = True

        txt_Hdr_ClaimToInsAmt_ori.Enabled = True
        cbo_Hdr_ClaimToInsAmtCur.Enabled = True
        cbo_Hdr_ClaimToInsAmtCur.Enabled = True
        txt_Hdr_ClaimToVNAmt_ori.Enabled = True
        cbo_Hdr_ClaimToVNAmtCur.Enabled = True
        txt_Hdr_ClaimToHKOAmt_ori.Enabled = True
        cbo_Hdr_ClaimToHKOAmtCur.Enabled = True

        If rbClaimBy_C.Checked = True Then
            txt_Hdr_ClaimToInsAmt_ori.Text = "0"
            txt_Hdr_ClaimToInsAmt.Text = "0"
            txt_Hdr_ClaimToInsAmt_ori.Enabled = False   
   cbo_Hdr_ClaimToInsAmtCur.Enabled = False
            txt_Hdr_ClaimToInsAmt.Enabled = False
        ElseIf rbClaimBy_V.Checked = True Then
            txt_Hdr_ClaimToVNAmt_ori.Text = "0"
            txt_Hdr_ClaimToVNAmt.Text = "0"
            txt_Hdr_ClaimToVNAmt_ori.Enabled = False 
        cbo_Hdr_ClaimToVNAmtCur.Enabled = False
            txt_Hdr_ClaimToVNAmt.Enabled = False
        ElseIf rbClaimBy_U.Checked = True Then
            txt_Hdr_ClaimToHKOAmt_ori.Text = "0"
            txt_Hdr_ClaimToHKOAmt.Text = "0"

            cbo_Hdr_ClaimToHKOAmtCur.Enabled = False
            txt_Hdr_ClaimToHKOAmt_ori.Enabled = False
            txt_Hdr_ClaimToHKOAmt.Enabled = False

        End If

        mmdSave.Enabled = True

        '        txt_Hdr_Rmk.Focus()
        txt_Hdr_CustComment.Focus()

        FLAG_FIRST_TIME_CHECK_CASE = False

        If rbClaimBy_C.Checked = True Then
            cbo_Hdr_ClaimToHKOAmtCur.Enabled = False
        End If
        If rbClaimBy_V.Checked = True Then
            cbo_Hdr_ClaimToHKOAmtCur.Enabled = False
        End If


    End Sub

    Private Sub cboClaimType_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboClaimType.KeyUp
        cboClaimType.SelectionLength = 0

        If cboClaimType.Text.Length > 0 Then
            If e.KeyCode <> Keys.Back Then
                sHdrClaimType = cboClaimType.Text
                auto_search_combo(cboClaimType)
            Else
                cboClaimType.Text = sHdrClaimType.Substring(0, sHdrClaimType.Length - 1)
                auto_search_combo(cboClaimType)
                sHdrClaimType = sHdrClaimType.Substring(0, sHdrClaimType.Length - 1)
            End If
        End If
    End Sub

    Private Sub format_input_cboClaimType_after()

        cboClaimType.Enabled = False

        If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then

            Me.txt_Hdr_Rmk.Enabled = True
            Me.txt_Hdr_Rmk.ScrollBars = RichTextBoxScrollBars.ForcedVertical
            txt_Hdr_Rmk.ReadOnly = False

            Me.txt_Hdr_CustComment.Enabled = True
            Me.txt_Hdr_CustComment.ScrollBars = RichTextBoxScrollBars.ForcedVertical
            txt_Hdr_CustComment.ReadOnly = False

            Me.txt_Hdr_Finding.Enabled = True
            Me.txt_Hdr_Finding.ScrollBars = RichTextBoxScrollBars.ForcedVertical
            txt_Hdr_Finding.ReadOnly = False

        Else

            Me.txt_Hdr_Rmk.Enabled = True
            Me.txt_Hdr_CustComment.Enabled = True
            Me.txt_Hdr_Finding.Enabled = True
            txt_Hdr_Rmk.ReadOnly = False
            txt_Hdr_CustComment.ReadOnly = False
            txt_Hdr_Finding.ReadOnly = False

        End If


         
 
        txt_Hdr_ClaimToInsAmt_ori.Enabled = True
        cbo_Hdr_ClaimToInsAmtCur.Enabled = True
        cbo_Hdr_ClaimToInsAmtCur.Enabled = True
        txt_Hdr_ClaimToVNAmt_ori.Enabled = True
        cbo_Hdr_ClaimToVNAmtCur.Enabled = True
        txt_Hdr_ClaimToHKOAmt_ori.Enabled = True
        cbo_Hdr_ClaimToHKOAmtCur.Enabled = True
 
 

        ''grey
        If rbClaimBy_C.Checked = True Then
            txt_Hdr_ClaimToInsAmt_ori.Enabled = False   
   cbo_Hdr_ClaimToInsAmtCur.Enabled = False
            txt_Hdr_ClaimToInsAmt.Enabled = False
        ElseIf rbClaimBy_V.Checked = True Then
            txt_Hdr_ClaimToVNAmt_ori.Enabled = False 
        cbo_Hdr_ClaimToVNAmtCur.Enabled = False
            txt_Hdr_ClaimToVNAmt.Enabled = False
        ElseIf rbClaimBy_U.Checked = True Then
            cbo_Hdr_ClaimToHKOAmtCur.Enabled = False
            txt_Hdr_ClaimToHKOAmt_ori.Enabled = False
            txt_Hdr_ClaimToHKOAmt.Enabled = False
        End If

        If rbClaimBy_C.Checked = True Then
            txt_ref_no.Enabled = True
            dt_ref_date.Enabled = True
            


        ElseIf rbClaimBy_V.Checked = True Then
            txt_ref_no.Enabled = True
            dt_ref_date.Enabled = True
            

        Else
            txt_ref_no.Enabled = False
            dt_ref_date.Enabled = False
            
        End If

        chkconfirmclm.Enabled = False
        chkvalidclm.Enabled = False
        gbClaimAmtPer.Enabled = False
        rbClaimAmtPer_C.Enabled = False
        rbClaimAmtPer_I.Enabled = False
        rbClaimAmtPer_S.Enabled = False

        'rbClaimAmtPer_C.Checked = False

        chkreplace.Enabled = False

        chkwait.Enabled = True
        '        cmd_attch.Enabled = True



        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cocde") = ""
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordno") = txtClaimNo.Text

        If cboClaimSts.Text = "" Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "OPEN"
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
            txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
            txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString

        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = Split(cboClaimSts.Text, " - ")(0)
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
            txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
            txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString

        End If

        If mode = cModeAdd Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claperiod") = cboClaimPeriod.Text
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claperiod") = txtClaimPeriod.Text
        End If

        If rbClaimAmtPer_C.Checked Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_per") = "C"
        ElseIf rbClaimAmtPer_I.Checked Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_per") = "I"
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_per") = "S"
        End If

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_clasearchby") = nHdrSearchBy

        If rbClaimBy_C.Checked = True Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claby") = "C"
        ElseIf rbClaimBy_V.Checked = True Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claby") = "V"
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claby") = "U"
        End If

        If cboPriCust.Text <> "" Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus1no") = Split(cboPriCust.Text, " - ")(0)
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus1no") = ""
        End If

        If cboSecCust.Text <> "" Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus2no") = Split(cboSecCust.Text, " - ")(0)
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus2no") = ""
        End If

        If cboVendor.Text <> "" Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_venno") = Split(cboVendor.Text, " - ")(0)
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_venno") = ""
        End If





        If cboClaimType.Text <> "" Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_clatyp") = Split(cboClaimType.Text, " - ")(0)
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_clatyp") = ""
        End If

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_rmk") = txt_Hdr_Rmk.Text
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_custcomment") = txt_Hdr_CustComment.Text
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_finding") = txt_Hdr_Finding.Text

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salesmanger") = txtSalesManager.Text
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salesteam") = txtSalesTeam.Text

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_clatyp") = Split(cboClaimType.Text, " - ")(0)
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_rmk") = txt_Hdr_Rmk.Text
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_custcomment") = txt_Hdr_CustComment.Text
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_finding") = txt_Hdr_Finding.Text

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~"
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_updusr") = "~*ADD*~"

        mmdInsRow.Enabled = True
        'cmdDelRow.Enabled = True
        mmdInsRow.Enabled = True
        'cmdSave.Enabled = True

        '''20131205
        ''' 
        txt_Hdr_Rmk.Text = ""
        txt_Hdr_CustComment.Text = ""
        txt_Hdr_Finding.Text = ""

        '        cboSETTLE_CUS.Enabled = False
        txt_Hdr_FinalClaimAmt.Enabled = False

    End Sub

    Private Sub display_CAORDHDR()
        Dim CAH_COCDE As String
        Dim CAH_CAORDNO As String
        Dim CAH_CAORDSTS As String
        'Dim CAH_ADHOC As String
        'Dim CAH_ISSDAT As String
        Dim CAH_CLAPERIOD As String
        Dim CAH_CAAMT_PER As String
        Dim CAH_CLASEARCHBY As String
        Dim CAH_CLABY As String
        Dim CAH_CUS1NO As String
        Dim CAH_CUS2NO As String
        Dim CAH_VENNO As String
        Dim CAH_CLATYP As String
        Dim CAH_RMK As String
        Dim CAH_CUSTCOMMENT As String
        Dim CAH_FINDING As String
        Dim CAH_SALCUR As String
        Dim CAH_SALTTLAMT As Decimal
        'Dim CAH_SALTTLAMT_I As Decimal
        'Dim CAH_SALTTLAMT_E As Decimal
        Dim CAH_GRSPFTAMT As Decimal
        'Dim CAH_GRSPFTAMT_I As Decimal
        'Dim CAH_GRSPFTAMT_E As Decimal
        Dim CAH_CALMTAMT As Decimal
        'Dim CAH_CALMTAMT_I As Decimal
        'Dim CAH_CALMTAMT_E As Decimal
        Dim CAH_CALMTPER As Decimal
        'Dim CAH_CALMTPER_I As Decimal
        'Dim CAH_CALMTPER_E As Decimal
        Dim CAH_CAREMAMT As Decimal
        Dim CAH_CACUR As String
        Dim CAH_CAAMT_ORG As Decimal
        Dim CAH_CAAMT_FINAL As Decimal
        'Dim CAH_CAVSGRSPFT As Decimal
        Dim CAH_APP1FLG As String
        Dim CAH_APP1FLGBY As String
        Dim CAH_APP1FLGDAT As String
        Dim CAH_CATOINSCUR As String
        Dim CAH_CATOINSAMT As Decimal
        Dim CAH_CATOVNCUR As String
        Dim CAH_CATOVNAMT As Decimal
        'Dim CAH_CATOEVNCUR As String
        'Dim CAH_CATOEVNAMT As Decimal
        Dim CAH_CATOHKOCUR As String
        Dim CAH_CATOHKOAMT As Decimal
        Dim CAH_APP2FLG As String
        Dim CAH_APP2FLGBY As String
        Dim CAH_APP2FLGDAT As String
        Dim CAH_CUREXRAT As String
        Dim CAH_CUREXEFFDAT As String
        Dim CAH_SALESMANGER As String
        Dim CAH_SALESTEAM As String
        Dim CAH_CREUSR As String
        Dim CAH_UPDUSR As String

        Dim CAH_PAYSTS As String
        Dim CAH_PAIDDAT As String
        Dim CAH_SETTLE_CUS As String
        Dim CAH_RCVDAT As String
        Dim CAH_SETTLE_FTY As String
        Dim CAH_APRVSTS As String
        Dim CAH_FA_LSTUPDDAT As String
        Dim CAH_Reason As String
        Dim CAH_confclm As String
        Dim CAH_acct_caamt_final As String
        Dim CAH_season As String
        Dim cah_income_cur As String
        Dim cah_pay_cur As String

        If rs_CAORDHDR.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        If rs_CAORDHDR.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        If IsDBNull(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cocde")) Then
            Exit Sub
        End If


        CAH_COCDE = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cocde")
        CAH_CAORDNO = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordno").ToString
        CAH_CAORDSTS = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts").ToString

        'CAH_ADHOC = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_adhoc")
        'CAH_ISSDAT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_issdat")
        CAH_CLAPERIOD = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claperiod").ToString
        '''20131105field 
        CAH_CAAMT_PER = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_per")
        '''20131105field CAH_CLASEARCHBY = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_clasearchby")
        CAH_CLABY = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claby").ToString
        CAH_CUS1NO = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus1no").ToString
        CAH_CUS2NO = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus2no").ToString
        CAH_VENNO = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_venno").ToString
        CAH_CLATYP = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_clatyp").ToString
        CAH_RMK = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_rmk").ToString
        CAH_CUSTCOMMENT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_custcomment").ToString
        CAH_FINDING = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_finding").ToString
        CAH_SALCUR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salcur").ToString
        CAH_SALTTLAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salttlamt")
        'CAH_SALTTLAMT_I = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salttlamt_i")
        'CAH_SALTTLAMT_E = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salttlamt_e")
        CAH_GRSPFTAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_grspftamt")
        'CAH_GRSPFTAMT_I = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_grspftamt_i")
        'CAH_GRSPFTAMT_E = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_grspftamt_e")
        CAH_CALMTAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtamt")
        'CAH_CALMTAMT_I = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtamt_i")
        'CAH_CALMTAMT_E = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtamt_e")
        CAH_CALMTPER = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtper").ToString
        'CAH_CALMTPER_I = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtper_i")
        'CAH_CALMTPER_E = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtper_e")
        '''20131105field CAH_CAREMAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caremamt")
        CAH_CACUR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cacur").ToString
        CAH_CAAMT_ORG = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_org")
        CAH_CAAMT_FINAL = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_final")
        'CAH_CAVSGRSPFT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cavsgrspft")
        CAH_APP1FLG = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app1flg").ToString
        CAH_APP1FLGBY = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app1flgby").ToString
        CAH_APP1FLGDAT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app1flgdat")
        CAH_CATOINSCUR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoinscur")
        CAH_CATOINSAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoinsamt")
        CAH_CATOVNCUR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catovncur")
        CAH_CATOVNAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catovnamt")
        'CAH_CATOEVNCUR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoevncur")
        'CAH_CATOEVNAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoevnamt")
        CAH_CATOHKOCUR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catohkocur")
        CAH_CATOHKOAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catohkoamt")
        CAH_APP2FLG = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app2flg")
        CAH_APP2FLGBY = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app2flgby")
        CAH_APP2FLGDAT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app2flgdat")
        CAH_CUREXRAT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_curexrat")
        CAH_CUREXEFFDAT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_curexeffdat")
        CAH_SALESMANGER = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salesmanger")
        CAH_SALESTEAM = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salesteam")
        CAH_season = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_season")
        If IsDBNull(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_cur")) Then
            cah_income_cur = "USD"
        Else
            cah_income_cur = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_cur")
        End If

        If IsDBNull(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_cur")) Then
            cah_pay_cur = "USD"
        Else
            cah_pay_cur = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_cur")
        End If


        CAH_CREUSR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr")
        CAH_UPDUSR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_updusr")

        cboSeason.Text = CAH_season

        txtClaimNo.Text = CAH_CAORDNO

        display_combo(CAH_CLAPERIOD, cboClaimPeriod)
        txtClaimPeriod.Text = CAH_CLAPERIOD

        display_combo(CAH_CAORDSTS, cboClaimSts)
        If CAH_CAORDSTS = "WAIT" Or _
         CAH_CAORDSTS = "APRV" Or _
          CAH_CAORDSTS = "RELS" Or _
           CAH_CAORDSTS = "CLOS" _
        Then
            chkwait.Checked = True
        Else
            chkwait.Checked = False
        End If

        If CAH_CAORDSTS = "CANL" Then
            chkCancel.Checked = True
            chkCancel.Enabled = False


        Else
            chkCancel.Checked = False
        End If


        If CAH_CLABY = "C" Then
            rbClaimBy_C.Checked = True
        ElseIf CAH_CLABY = "V" Then
            rbClaimBy_V.Checked = True
        Else
            rbClaimBy_U.Checked = True
        End If

        display_combo(CAH_CUS1NO, cboPriCust)
        display_combo(CAH_CUS2NO, cboSecCust)
        display_combo(CAH_VENNO, cboVendor)

        If CAH_CAAMT_PER = "C" Then
            rbClaimAmtPer_C.Checked = True
        ElseIf CAH_CAAMT_PER = "I" Then
            rbClaimAmtPer_I.Checked = True
        Else
            rbClaimAmtPer_S.Checked = True
        End If

        nHdrSearchBy = CAH_CLASEARCHBY

        display_combo(CAH_CLATYP, cboClaimType)
        txtSalesManager.Text = CAH_SALESMANGER
        txtSalesTeam.Text = CAH_SALESTEAM

        txt_Hdr_Rmk.Text = CAH_RMK
        txt_Hdr_CustComment.Text = CAH_CUSTCOMMENT
        txt_Hdr_Finding.Text = CAH_FINDING

        'gspStr = "sp_select_CAREMHDR '','" + txtClaimPeriod.Text + "'"
        'rtnLong = execute_SQLStatement(gspStr, rs_CAREMHDR, rtnStr)
        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading cmdAdd_Click sp_select_CAREMHDR : " & rtnStr)
        '    Exit Sub
        'End If

        'Dim temp_salcur As String = "USD"
        'Dim temp_salttlamt As Decimal = "0.00"
        'Dim temp_calmtamt As Decimal = "0.00"
        'Dim temp_calmtper As Decimal = "0.00"
        'Dim temp_caremamt As Decimal = "0.00"

        'For index_H As Integer = 0 To rs_CAREMHDR.Tables("RESULT").Rows.Count - 1
        '    If rs_CAREMHDR.Tables("RESULT").Rows(index_H).Item("crh_claPeriod") = CAH_CLAPERIOD And _
        '        rs_CAREMHDR.Tables("RESULT").Rows(index_H).Item("crh_cus1no") = CAH_CUS1NO And _
        '        rs_CAREMHDR.Tables("RESULT").Rows(index_H).Item("crh_cus2no") = CAH_CUS2NO And _
        '        rs_CAREMHDR.Tables("RESULT").Rows(index_H).Item("crh_venno") = CAH_VENNO Then
        '        temp_salcur = rs_CAREMHDR.Tables("RESULT").Rows(index_H).Item("crh_salcur")
        '        temp_salttlamt = rs_CAREMHDR.Tables("RESULT").Rows(index_H).Item("crh_salttlamt")
        '        temp_calmtamt = rs_CAREMHDR.Tables("RESULT").Rows(index_H).Item("crh_calmtamt")
        '        temp_calmtper = rs_CAREMHDR.Tables("RESULT").Rows(index_H).Item("crh_calmtper")
        '        temp_caremamt = rs_CAREMHDR.Tables("RESULT").Rows(index_H).Item("crh_caremamt")
        '        Exit For
        '    End If
        'Next

        display_combo(CAH_SALCUR, cbo_Hdr_SalesAmtCurrency)

        display_combo(cah_income_cur, cbo_income_cur)
        display_combo(cah_pay_cur, cbo_pay_cur)
        lbl_outamt_pay.Text = cbo_pay_cur.Text
        lbl_outamt_income.Text = cbo_income_cur.Text


        '   ''''' 20131108
        ' txt_Hdr_SalesAmt_Ttl.Text = Decimal.Round(CAH_SALTTLAMT, 2)
        'txt_Hdr_SalesAmt_I.Text = Decimal.Round(CAH_SALTTLAMT_I, 2)
        'txt_Hdr_SalesAmt_E.Text = Decimal.Round(CAH_SALTTLAMT_E, 2)

        'cbo_Hdr_GrsPftCurrency.Text = CAH_SALCUR
        'txt_Hdr_GrsPft_Ttl.Text = Decimal.Round(CAH_GRSPFTAMT, 2)
        'txt_Hdr_GrsPft_I.Text = Decimal.Round(CAH_GRSPFTAMT_I, 2)
        'txt_Hdr_GrsPft_E.Text = Decimal.Round(CAH_GRSPFTAMT_E, 2)

        cbo_Hdr_AppLmtChkCurrency.Text = CAH_SALCUR
        ''''' 20131108 txt_Hdr_AppLmtChk_Ttl.Text = Decimal.Round(CAH_CALMTAMT, 2)

        'txt_Hdr_AppLmtChk_I.Text = Decimal.Round(CAH_CALMTAMT_I, 2)
        'txt_Hdr_AppLmtChk_E.Text = Decimal.Round(CAH_CALMTAMT_E, 2)

        lbl_Hdr_AppLmtChkPer_Ttl.Text = Decimal.Round(CAH_CALMTPER, 0).ToString + "%"
        'lbl_Hdr_AppLmtChkPer_I.Text = Decimal.Round(CAH_CALMTPER_I, 1).ToString + "%"
        'lbl_Hdr_AppLmtChkPer_E.Text = Decimal.Round(CAH_CALMTPER_E, 1).ToString + "%"

        cbo_Hdr_RemainClaimCurrency.Text = CAH_SALCUR

        '''''20131108
        '''''txt_Hdr_RemainClaim_Ttl.Text = Decimal.Round(CAH_CAREMAMT, 2)

        cbo_Hdr_ClaimAmtCurrency.Text = CAH_CACUR
        txt_Hdr_OrgClaimAmt.Text = Decimal.Round(CAH_CAAMT_ORG, 2)
        txt_Hdr_FinalClaimAmt.Text = Decimal.Round(CAH_CAAMT_FINAL, 2)
        'txt_Hdr_ClaimVSGPPer.Text = Decimal.Round(CAH_CAVSGRSPFT, 2)

        cbo_Hdr_ClaimToInsAmtCur.Text = CAH_CATOINSCUR
        txt_Hdr_ClaimToInsAmt.Text = Decimal.Round(CAH_CATOINSAMT, 2)
        cbo_Hdr_ClaimToVNAmtCur.Text = CAH_CATOVNCUR
        txt_Hdr_ClaimToVNAmt.Text = Decimal.Round(CAH_CATOVNAMT, 2)
        'cbo_Hdr_ClaimToEVNAmtCurrency.Text = CAH_CATOEVNCUR
        'txt_Hdr_ClaimToEVNAmt.Text = Decimal.Round(CAH_CATOEVNAMT, 2)
        cbo_Hdr_ClaimToHKOAmtCur.Text = CAH_CATOHKOCUR
        txt_Hdr_ClaimToHKOAmt.Text = Decimal.Round(CAH_CATOHKOAMT, 2)

        lbl_Hdr_ClaimToInsAmt_ExchRate.Text = Decimal.Round(getExchangeRate(CAH_CATOINSCUR, CAH_CACUR, "BuyRate"), 4)
        lbl_Hdr_ClaimToVNAmt_ExchRate.Text = Decimal.Round(getExchangeRate(CAH_CATOVNCUR, CAH_CACUR, "BuyRate"), 4)
        'lbl_Hdr_ClaimToEVNAmt_ExchRate.Text = Decimal.Round(getExchangeRate(CAH_CATOEVNCUR, CAH_CACUR, "BuyRate"), 4)
        lbl_Hdr_ClaimToHKOAmt_ExchRate.Text = Decimal.Round(getExchangeRate(CAH_CATOHKOCUR, CAH_CACUR, "BuyRate"), 4)

        If Not IsDBNull(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_PAYSTS")) Then
            display_combo(Trim(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_PAYSTS")), cboClaimPaySTS)
            If Trim(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_PAYSTS")) = "" Then
                cboClaimPaySTS.Text = ""
            End If
        Else
            cboClaimPaySTS.Text = ""
        End If

        ' txt_pay_rmk.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_rmk")
        If Not IsDBNull(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_rmk")) Then
            txt_pay_rmk.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_rmk")
        Else
            txt_pay_rmk.Text = ""
        End If

        '        txt_pay_actamt = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_actamt")


        '        cboClaimPaySTS.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_PAYSTS")
        If Format(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_PAIDDAT"), "MM/dd/yyyy") = "01/01/1900" Then
            dtHDRPAIDDAT.Text =""
        Else
            dtHDRPAIDDAT.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_PAIDDAT")
        End If

        cboSETTLE_CUS.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_SETTLE_CUS")

        If Format(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_RCVDAT"), "MM/dd/yyyy") = "01/01/1900" Then
            dtHDRRCVDAT.Text = ""
        Else
            dtHDRRCVDAT.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_RCVDAT")
        End If


        cboSETTLE_FTY.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_SETTLE_FTY")
        display_combo(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_APRVSTS"), cboAPRVSTS)


        ''If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "APV3b" Or _
        ''rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "CLOS" Then
        ''    chkapv1a.Checked = True
        ''    chkapv1b.Checked = True
        ''    chkapv2a.Checked = True
        ''    chkapv2b.Checked = True
        ''    chkapv3a.Checked = True
        ''    chkapv3b.Checked = True
        ''    chkapv1a.Enabled = False
        ''    chkapv1b.Enabled = False
        ''    chkapv2a.Enabled = False
        ''    chkapv2b.Enabled = False
        ''    chkapv3a.Enabled = False
        ''    chkapv3b.Enabled = True
        ''End If
        ''If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "APV3a" Then
        ''    chkapv1a.Checked = True
        ''    chkapv1b.Checked = True
        ''    chkapv2a.Checked = True
        ''    chkapv2b.Checked = True
        ''    chkapv3a.Checked = True
        ''    chkapv1a.Enabled = False
        ''    chkapv1b.Enabled = False
        ''    chkapv2a.Enabled = False
        ''    chkapv2b.Enabled = False
        ''    chkapv3a.Enabled = True
        ''End If
        ''If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "APV2b" Then
        ''    chkapv1a.Checked = True
        ''    chkapv1b.Checked = True
        ''    chkapv2a.Checked = True
        ''    chkapv2b.Checked = True
        ''    chkapv1a.Enabled = False
        ''    chkapv1b.Enabled = False
        ''    chkapv2a.Enabled = False
        ''    chkapv2b.Enabled = True
        ''End If
        ''If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "APV2a" Then
        ''    chkapv1a.Checked = True
        ''    chkapv2a.Checked = True

        ''    chkapv1a.Enabled = False

        ''    chkapv2a.Enabled = True
        ''End If
        ''If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "APV1b" Then
        ''    chkapv1a.Checked = True
        ''    chkapv2a.Checked = True
        ''    chkapv1b.Checked = True

        ''    chkapv1a.Enabled = False
        ''    chkapv2a.Enabled = False

        ''    chkapv1b.Enabled = True

        ''End If

        ''If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "APV1a" Then
        ''    chkapv1a.Checked = True

        ''    chkapv1a.Enabled = True

        ''End If

        '        cboAPRVSTS.Text = display_combo(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_APRVSTS"), cboAPRVSTS)
        'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_FA_LSTUPDDAT") = "01/01/1900"
        txtreason.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_Reason")

        '''20140513
        ''If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_confclm") = "Y" Then
        ''    chkconfirmclm.Checked = True
        ''Else
        ''    chkconfirmclm.Checked = False
        ''End If

        txt_Hdr_AcctClaimAmt.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_acct_caamt_final")

        '''
        If IsDBNull(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pot_val")) Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pot_val") = ""
        End If
        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pot_val") = "P" Then
            chkconfirmclm.Checked = True
        ElseIf rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pot_val") = "V" Then
            chkvalidclm.Checked = True
        ElseIf rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pot_val") = "A" Then
            chkconfirmclm.Checked = True
            chkvalidclm.Checked = True
        End If


        txt_ref_no.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_ref_no")

        If Format(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_ref_dat"), "MM/dd/yyyy") = "01/01/1900" Then
            dt_ref_date.Text = ""
        Else
            dt_ref_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_ref_dat")
        End If


        txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
        txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat")
        txt_cmt_a.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cmt_a")
        txt_cmt_b.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cmt_b")


        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_actamt") = 0 Then
            txt_pay_actamt.Text = ""
        Else
            txt_pay_actamt.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_actamt")
        End If

        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_potamt") = 0 Then
            txt_pay_potamt.Text = ""
        Else
            txt_pay_potamt.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_potamt")
        End If

        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_actamt") = 0 Then
            txt_income_actamt.Text = ""
        Else
            txt_income_actamt.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_actamt")
        End If

        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_potamt") = 0 Then
            txt_income_potamt.Text = ""
        Else
            txt_income_potamt.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_potamt")
        End If

        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_actamt") = 0 Then
            txt_pay_actamt.Text = ""
        Else
            txt_pay_actamt.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_actamt")
        End If

        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_actamt") = 0 Then
            txt_income_actamt.Text = ""
        Else
            txt_income_actamt.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_actamt")
        End If

        'txt_pay_actamt.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_actamt")
        'txt_income_actamt.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_actamt")
        'txt_pay_actamt.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_actamt")
        'txt_income_actamt.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_actamt")
        '''20140604
        If Not IsDBNull(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_upddat")) Then
            If Format(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_upddat"), "MM/dd/yyyy") = "01/01/1900" Then
                txt_pay_upddat.Text = ""
            Else
                txt_pay_upddat.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_upddat")
            End If
        Else
            txt_pay_upddat.Text = ""
        End If

        If Not IsDBNull(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_upddat")) Then
            If Format(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_upddat"), "MM/dd/yyyy") = "01/01/1900" Then
                txt_income_upddat.Text = ""
            Else
                txt_income_upddat.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_upddat")
            End If
        Else
            txt_income_upddat.Text = ""
        End If


        If Not IsDBNull(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_INCOMESTS")) Then
            display_combo(Trim(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_INCOMESTS")), cboClaimIncomeSTS)
            If Trim(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_INCOMESTS")) = "" Then
                'cboClaimIncomeSTS.Enabled = True
                cboClaimIncomeSTS.Text = ""
                'cboClaimIncomeSTS.Enabled = False
            End If
        Else
            cboClaimIncomeSTS.Text = ""
        End If

        '        txt_income_rmk.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_rmk")
        If Not IsDBNull(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_rmk")) Then
            txt_income_rmk.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_rmk")
        Else
            txt_income_rmk.Text = ""
        End If

        txt_Hdr_ClaimToInsAmt_ori.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_ClaimToInsAmt_ori")
        txt_Hdr_ClaimToVNAmt_ori.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_ClaimToVNAmt_ori")
        txt_Hdr_ClaimToHKOAmt_ori.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_ClaimToHKOAmt_ori")

        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_replace") = "Y" Then
            chkreplace.Checked = True
        Else
            chkreplace.Checked = False
        End If

        If IsDBNull(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a")) Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a") = ""
        End If
        If IsDBNull(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b")) Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = ""
        End If

        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a") = "APV3a" Then
            chkapv3a.Checked = True
            chkapv2a.Checked = True
            chkapv1a.Checked = True
        ElseIf rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a") = "APV2a" Then
            chkapv3a.Checked = False
            chkapv2a.Checked = True
            chkapv1a.Checked = True
        ElseIf rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a") = "APV1a" Then
            chkapv3a.Checked = False
            chkapv2a.Checked = False
            chkapv1a.Checked = True
        End If
        '''
        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = "APV3b" Then
            chkapv3b.Checked = True
            chkapv2b.Checked = True
            chkapv1b.Checked = True
        ElseIf rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = "APV2b" Then
            chkapv3b.Checked = False
            chkapv2b.Checked = True
            chkapv1b.Checked = True
        ElseIf rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = "APV1b" Then
            chkapv3b.Checked = False
            chkapv2b.Checked = False
            chkapv1b.Checked = True
        End If


        txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
        txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat")

        txtReplaceClaimNo.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_rplno")



        'format_Approval(0)

        '''20140403
        StatusBar.Panels(1).Text = Format(rs_CAORDHDR.Tables("RESULT").Rows(0)("cah_credat"), "MM/dd/yyyy") & _
                                    "   " & Format(rs_CAORDHDR.Tables("RESULT").Rows(0)("cah_upddat"), "MM/dd/yyyy") & _
                                    "   " & rs_CAORDHDR.Tables("RESULT").Rows(0)("cah_updusr").ToString()
        '''20140604
        '''cbo_Hdr_ClaimAmtCurrency = "US"
        ''' MGt cur ??
        If cbo_Hdr_ClaimAmtCurrency.Text.Trim = "USD" Then
            If Val(txt_Hdr_FinalClaimAmt.Text) > 5000 Then
                lbl_Hdr_ExceedAppLmt.Visible = True
            Else
                lbl_Hdr_ExceedAppLmt.Visible = False
            End If
        Else
            If Val(txt_Hdr_FinalClaimAmt.Text) > 5000 * gl_rate Then
                lbl_Hdr_ExceedAppLmt.Visible = True
            Else
                lbl_Hdr_ExceedAppLmt.Visible = False
            End If
        End If

    End Sub

    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        If checkFocus(Me) Then Exit Sub
        '''20140305
        Call fill_CAORDHDR()


        Dim frm As New frmCLMQuickInsert(txtClaimPeriod.Text, cboPriCust.Text, cboSecCust.Text, cboVendor.Text, nHdrSearchBy)

        frm.MdiParent = Me.MdiParent
        frm.Show()
        Call frm.get_date_range(Me.cboClaimPeriod.Text.Trim)


        AddHandler frm.returnSelectedRecords, AddressOf returnSelectedRecordsHandler

        '''
        Dim i As Integer

        If Not rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            If rs_CAORDDTL.Tables("RESULT").Rows.Count <> 0 Then

                For i = 0 To rs_CAORDDTL.Tables("RESULT").Columns.Count - 1
                    rs_CAORDDTL.Tables("RESULT").Columns(i).ReadOnly = False
                Next i

                Dim tmp_seq_dtl As Integer
                tmp_seq_dtl = rs_CAORDDTL.Tables("RESULT").Rows(0).Item("CAD_CAORDSEQ")
                Call display_CAORDDTL(tmp_seq_dtl)
            End If
        End If

        'RemoveHandler frm.returnSelectedRecords, AddressOf returnSelectedRecordsHandler
    End Sub

    Private Sub returnSelectedRecordsHandler(ByVal sender As Object, _
                                             ByVal returnedRecords As DataRow(), _
                                             ByVal returnedSearchBy As Integer)

        If rs_CAORDITM.Tables.Count = 0 And rs_CAORDDTL.Tables.Count = 0 Then
            Exit Sub
        End If

        If returnedRecords.Length = 0 Then
            Exit Sub
        Else
            btcCLM00001.TabPages(2).Enabled = False
            btcCLM00001.TabPages(3).Enabled = False
            btcCLM00001.TabPages(2).Enabled = True
            btcCLM00001.TabPages(3).Enabled = True
            nHdrSearchBy = returnedSearchBy
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_clasearchby") = nHdrSearchBy
        End If

        Dim lastseq As Integer

        If rs_CAORDDTL.Tables("RESULT").Rows.Count = 0 Then
            lastseq = 1
        Else
            If IsNumeric(rs_CAORDDTL.Tables("RESULT").Rows(rs_CAORDDTL.Tables("RESULT").Rows.Count - 1).Item("cad_caordseq")) Then
                lastseq = rs_CAORDDTL.Tables("RESULT").Rows(rs_CAORDDTL.Tables("RESULT").Rows.Count - 1).Item("cad_caordseq")
            Else
                lastseq = 0
            End If
            lastseq = lastseq + 1
        End If

        Dim lastseq_Item As Integer

        If rs_CAORDITM.Tables("RESULT").Rows.Count = 0 Then
            lastseq_Item = 1
        Else
            If IsNumeric(rs_CAORDITM.Tables("RESULT").Rows(rs_CAORDITM.Tables("RESULT").Rows.Count - 1).Item("cai_caordseq")) Then
                lastseq_Item = rs_CAORDITM.Tables("RESULT").Rows(rs_CAORDITM.Tables("RESULT").Rows.Count - 1).Item("cai_caordseq")
            Else
                lastseq_Item = 0
            End If
            lastseq_Item = lastseq_Item + 1
        End If

        Dim rowno As Integer
        '''rowno equal to last seq#
        rowno = rs_CAORDDTL.Tables("RESULT").Rows.Count - 1

        Dim i As Integer
        For i = 0 To rs_CAORDDTL.Tables("RESULT").Columns.Count - 1
            rs_CAORDDTL.Tables("RESULT").Columns(i).ReadOnly = False
        Next i

        Dim j As Integer
        For j = 0 To rs_CAORDITM.Tables("RESULT").Columns.Count - 1
            rs_CAORDITM.Tables("RESULT").Columns(j).ReadOnly = False
        Next j

        '' gspStr = "sp_select_CAREMITM '','" + txtClaimPeriod.Text + "','" + _
        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus1no") + "','" + _
        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus2no") + "'"
        '' rtnLong = execute_SQLStatement(gspStr, rs_CAREMITM, rtnStr)
        'If rtnLong <> RC_SUCCESS Then
        'MsgBox("Error on loading cmdAdd_Click sp_select_CAREMITM : " & rtnStr)
        'Exit Sub
        '  End If

        Dim sTxCocde_Dtl As String
        Dim sShpNo_Dtl As String
        Dim nShpSeq_Dtl As Integer
        Dim bExisted As Boolean = False

        Dim sItmNo_Item As String
        Dim bExisted_Item As Boolean = False

        Dim temp_salcur As String = "USD"
        Dim temp_salamt As Decimal = "0.00"
        Dim temp_grspftamt As Decimal = "0.00"
        Dim temp_calmtamt As Decimal = "0.00"
        Dim temp_calmtper As Decimal = "0.00"
        Dim temp_caremamt As Decimal = "0.00"

        For index As Integer = 0 To returnedRecords.Length - 1

            'MsgBox(index)


            For i = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
                sTxCocde_Dtl = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_txcocde").ToString.Trim
                sShpNo_Dtl = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_shpno").ToString.Trim
                nShpSeq_Dtl = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_shpseq")
                bExisted = False

                If returnedRecords(index).Item("sod_cocde").ToString.Trim.ToUpper = sTxCocde_Dtl.ToUpper And _
                       returnedRecords(index).Item("hid_shpno").ToString.Trim.ToUpper = sShpNo_Dtl.ToUpper And _
                       returnedRecords(index).Item("hid_shpseq").ToString.Trim = nShpSeq_Dtl.ToString Then
                    If nHdrSearchBy = 2 Then
                        MsgBox("Shipment No '" & returnedRecords(index).Item("hid_shpno").ToString.Trim.ToUpper & _
                               "'  Shipment Seq '" & returnedRecords(index).Item("hid_shpseq").ToString.Trim & "' already exist!")
                    End If
                    bExisted = True
                    Exit For
                End If
            Next i

            If bExisted = False Then
                rs_CAORDDTL.Tables("RESULT").Rows.Add()
                rowno = rowno + 1

                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_txcocde") = IIf(IsDBNull(returnedRecords(index).Item("sod_cocde")), " ", returnedRecords(index).Item("sod_cocde"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_shpno") = IIf(IsDBNull(returnedRecords(index).Item("hid_shpno")), " ", returnedRecords(index).Item("hid_shpno"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_shpseq") = IIf(IsDBNull(returnedRecords(index).Item("hid_shpseq")), 0, returnedRecords(index).Item("hid_shpseq"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_scordno") = IIf(IsDBNull(returnedRecords(index).Item("sod_ordno")), " ", returnedRecords(index).Item("sod_ordno"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_scordseq") = IIf(IsDBNull(returnedRecords(index).Item("sod_ordseq")), 0, returnedRecords(index).Item("sod_ordseq"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_popurord") = IIf(IsDBNull(returnedRecords(index).Item("pod_purord")), " ", returnedRecords(index).Item("pod_purord"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_popurseq") = IIf(IsDBNull(returnedRecords(index).Item("pod_purseq")), 0, returnedRecords(index).Item("pod_purseq"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_pojobord") = IIf(IsDBNull(returnedRecords(index).Item("pod_jobord")), " ", returnedRecords(index).Item("pod_jobord"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_shinvno") = IIf(IsDBNull(returnedRecords(index).Item("hid_invno")), " ", returnedRecords(index).Item("hid_invno"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_sccuspono") = IIf(IsDBNull(returnedRecords(index).Item("sod_cuspo")), " ", returnedRecords(index).Item("sod_cuspo"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_shissdat") = IIf(IsDBNull(returnedRecords(index).Item("hih_issdat")), "01/01/1900", returnedRecords(index).Item("hih_issdat"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_shetddat") = IIf(IsDBNull(returnedRecords(index).Item("hih_slnonb")), "01/01/1900", returnedRecords(index).Item("hih_slnonb"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_shetadat") = IIf(IsDBNull(returnedRecords(index).Item("hih_arrdat")), "01/01/1900", returnedRecords(index).Item("hih_arrdat"))

                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_itmno") = IIf(IsDBNull(returnedRecords(index).Item("sod_itmno")), " ", returnedRecords(index).Item("sod_itmno"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_cusitm") = IIf(IsDBNull(returnedRecords(index).Item("sod_cusitm")), " ", returnedRecords(index).Item("sod_cusitm"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_cusstyno") = IIf(IsDBNull(returnedRecords(index).Item("sod_cusstyno")), " ", returnedRecords(index).Item("sod_cusstyno"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_venitm") = IIf(IsDBNull(returnedRecords(index).Item("sod_venitm")), " ", returnedRecords(index).Item("sod_venitm"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_itmdsc") = IIf(IsDBNull(returnedRecords(index).Item("sod_itmdsc")), " ", returnedRecords(index).Item("sod_itmdsc"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_prdven") = IIf(IsDBNull(returnedRecords(index).Item("sod_prdven")), " ", returnedRecords(index).Item("sod_prdven"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_ventyp") = IIf(IsDBNull(returnedRecords(index).Item("vbi_ventyp")), " ", returnedRecords(index).Item("vbi_ventyp"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_sccurcde") = IIf(IsDBNull(returnedRecords(index).Item("sod_curcde")), " ", returnedRecords(index).Item("sod_curcde"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_scnetuntprc") = IIf(IsDBNull(returnedRecords(index).Item("sod_netuntprc")), " ", returnedRecords(index).Item("sod_netuntprc"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_scfcurcde") = IIf(IsDBNull(returnedRecords(index).Item("sod_dvfcurcde")), " ", returnedRecords(index).Item("sod_dvfcurcde"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_scftyprc") = IIf(IsDBNull(returnedRecords(index).Item("sod_dvftyprc")), " ", returnedRecords(index).Item("sod_dvftyprc"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_scpckunt") = IIf(IsDBNull(returnedRecords(index).Item("sod_pckunt")), " ", returnedRecords(index).Item("sod_pckunt"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_scordqty") = IIf(IsDBNull(returnedRecords(index).Item("sod_ordqty")), 0, returnedRecords(index).Item("sod_ordqty"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_scuntcde") = IIf(IsDBNull(returnedRecords(index).Item("hid_untcde")), " ", returnedRecords(index).Item("hid_untcde"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_scshpqty") = IIf(IsDBNull(returnedRecords(index).Item("hid_shpqty")), 0, returnedRecords(index).Item("hid_shpqty"))

                '''20140228  if nul,0
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_salcur") = IIf(IsDBNull(returnedRecords(index).Item("hid_untamt")), 0, returnedRecords(index).Item("hid_untamt"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_salamt") = IIf(IsDBNull(returnedRecords(index).Item("hid_ttlamt")), 0, returnedRecords(index).Item("hid_ttlamt"))
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_grspftamt") = "0.00"
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_calmtamt") = "0.00"
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_caremamt") = "0.00"

                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_caqty") = 0
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_caqty_final") = 0
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_clatyp") = ""
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_rmk") = ""

                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_cacur") = "USD"

                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_caqtyamt_org") = "0.00"
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_caqtyamt_final") = "0.00"

                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_caamt_org") = "0.00"
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_caamt_final") = "0.00"

                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_ttlcaamt_org") = "0.00"
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_ttlcaamt_final") = "0.00"

                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_catoinscur") = "USD"
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_catoinsamt") = "0.00"
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_catovncur") = "USD"
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_catovnamt") = "0.00"
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_catohkocur") = "USD"
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_catohkoamt") = "0.00"

                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_del") = ""
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_cocde") = ""
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_caordno") = txtClaimNo.Text
                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_caordseq") = lastseq

                rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_creusr") = "~*ADD*~"

                lastseq = lastseq + 1

                Dim rowno_Item As Integer = rs_CAORDITM.Tables("RESULT").Rows.Count - 1

                For i = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
                    sItmNo_Item = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_itmno").ToString.Trim
                    bExisted_Item = False

                    If sItmNo_Item = rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_itmno").ToString.Trim Then
                        bExisted_Item = True
                        rowno_Item = i
                        Exit For
                    End If
                Next

                If Not bExisted_Item Then
                    rs_CAORDITM.Tables("RESULT").Rows.Add()
                    rowno_Item = rowno_Item + 1

                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_clatyp") = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_clatyp")
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_txcocde") = rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_txcocde")
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_itmno") = rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_itmno")
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_itmdsc") = rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_itmdsc")
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_rmk") = ""

                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_salcur") = "USD"
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_salamt") = "0.00"
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_grspftamt") = "0.00"
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_calmtamt") = "0.00"
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_calmtper") = "0"
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_caremamt") = "0.00"

                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_cacur") = "USD"
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_caqtyamt_org") = "0.00"
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_caqtyamt_final") = "0.00"
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_caamt_org") = "0.00"
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_caamt_final") = "0.00"
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_ttlcaamt_org") = "0.00"
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_ttlcaamt_final") = "0.00"

                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_app1flg") = ""
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_app1flgby") = ""
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_app1flgdat") = "01/01/1900"

                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_catoinscur") = "USD"
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_catoinsamt") = "0.00"
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_catovncur") = "USD"
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_catovnamt") = "0.00"
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_catohkocur") = "USD"
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_catohkoamt") = "0.00"

                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_app2flg") = ""
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_app2flgby") = ""
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_app2flgdat") = "01/01/1900"

                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_del") = ""
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_cocde") = ""
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_caordno") = txtClaimNo.Text
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_caordseq") = lastseq_Item

                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_cusitm") = rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_cusitm")
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_cusstyno") = rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_cusstyno")
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_venitm") = rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_venitm")
                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_prdven") = rs_CAORDDTL.Tables("RESULT").Rows(rowno).Item("cad_prdven")

                    rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_creusr") = "~*ADD*~"

                    lastseq_Item = lastseq_Item + 1

                    'For index_I As Integer = 0 To rs_CAREMITM.Tables("RESULT").Rows.Count - 1
                    '    If rs_CAREMITM.Tables("RESULT").Rows(index_I).Item("cri_claPeriod") = txtClaimPeriod.Text And _
                    '        rs_CAREMITM.Tables("RESULT").Rows(index_I).Item("cri_cus1no") = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus1no") And _
                    '        rs_CAREMITM.Tables("RESULT").Rows(index_I).Item("cri_cus2no") = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus2no") And _
                    '        rs_CAREMITM.Tables("RESULT").Rows(index_I).Item("cri_itmno") = rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_itmno") Then
                    '        temp_salcur = rs_CAREMITM.Tables("RESULT").Rows(index_I).Item("cri_salcur")
                    '        temp_salamt = rs_CAREMITM.Tables("RESULT").Rows(index_I).Item("cri_salamt")
                    '        temp_grspftamt = rs_CAREMITM.Tables("RESULT").Rows(index_I).Item("cri_grspftamt")
                    '        temp_calmtamt = rs_CAREMITM.Tables("RESULT").Rows(index_I).Item("cri_calmtamt")
                    '        temp_calmtper = rs_CAREMITM.Tables("RESULT").Rows(index_I).Item("cri_calmtper")
                    '        temp_caremamt = rs_CAREMITM.Tables("RESULT").Rows(index_I).Item("cri_caremamt")
                    '        Exit For
                    '    End If
                    'Next

                    'rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_salcur") = temp_salcur
                    'rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_salamt") = temp_salamt
                    'rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_grspftamt") = temp_grspftamt
                    'rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_calmtamt") = temp_calmtamt
                    'rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_calmtper") = temp_calmtper
                    'rs_CAORDITM.Tables("RESULT").Rows(rowno_Item).Item("cai_caremamt") = temp_caremamt

                    'temp_salcur = "USD"
                    'temp_salamt = "0.00"
                    'temp_grspftamt = "0.00"
                    'temp_calmtamt = "0.00"
                    'temp_calmtper = "0.00"
                    'temp_caremamt = "0.00"
                End If
            End If
        Next

        'gspStr = "sp_select_CAREMHDR '','" + txtClaimPeriod.Text + "','" + _
        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus1no") + "','" + _
        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus2no") + "'"
        'rtnLong = execute_SQLStatement(gspStr, rs_CAREMHDR, rtnStr)
        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading cmdAdd_Click sp_select_CAREMHDR : " & rtnStr)
        '    Exit Sub
        'End If

        'Dim temp_salcur_hdr As String = "USD"
        'Dim temp_salttlamt_hdr As Decimal = "0.00"
        'Dim temp_calmtamt_hdr As Decimal = "0.00"
        'Dim temp_calmtper_hdr As Decimal = "0.00"
        'Dim temp_caremamt_hdr As Decimal = "0.00"

        'If rs_CAREMHDR.Tables("RESULT").Rows.Count = 1 Then
        '    temp_salcur_hdr = rs_CAREMHDR.Tables("RESULT").Rows(0).Item("crh_salcur")
        '    temp_salttlamt_hdr = rs_CAREMHDR.Tables("RESULT").Rows(0).Item("crh_salttlamt")
        '    temp_calmtamt_hdr = rs_CAREMHDR.Tables("RESULT").Rows(0).Item("crh_calmtamt")
        '    temp_calmtper_hdr = rs_CAREMHDR.Tables("RESULT").Rows(0).Item("crh_calmtper")
        '    temp_caremamt_hdr = rs_CAREMHDR.Tables("RESULT").Rows(0).Item("crh_caremamt")
        'Else
        '    MsgBox("Error on loading cmdAdd_Click sp_select_CAREMHDR : " & rtnStr)
        '    Exit Sub
        'End If

        'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salcur") = temp_salcur_hdr
        'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salttlamt") = temp_salttlamt_hdr
        'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_grspftamt") = "0.00"
        'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtamt") = temp_calmtamt_hdr
        'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtper") = temp_calmtper_hdr
        'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caremamt") = temp_caremamt_hdr

        gbClaimAmtPer.Enabled = False
        rbClaimAmtPer_C.Enabled = False
        rbClaimAmtPer_I.Enabled = False
        rbClaimAmtPer_S.Enabled = False

        If nHdrSearchBy = 1 Then
            rbViewOn_I.Checked = True
            dgSummary.DataSource = rs_CAORDITM.Tables("RESULT").DefaultView
        Else
            rbViewOn_S.Checked = True
            dgSummary.DataSource = rs_CAORDDTL.Tables("RESULT").DefaultView
        End If

        format_dgSummary()
        format_inputDtl_insert_txno_after()

        Set_Approval_Right_for_dgSummary(cModeInit)

        If sClaimStatus = "OPEN" Then
            Me.chkDelete.Enabled = True
        End If

        If sHdrClaimAmtPer = "C" Then
            btcCLM00001.SelectedIndex = 0
            display_CAORDHDR()
            'format_Approval(0)
        Else
            btcCLM00001.SelectedIndex = 2
            If sHdrClaimAmtPer = "I" Then
                'format_Approval(0)
            Else
                'format_Approval(0)
            End If
        End If

    End Sub

    Private Function getExchangeRate(ByVal fmCurr As String, ByVal toCurr As String, ByVal bsrate As String) As Decimal
        If rs_SYCUREX.Tables.Count = 0 Then
            getExchangeRate = 0.0
            Exit Function
        End If

        If rs_SYCUREX.Tables("RESULT").Rows.Count = 0 Then
            getExchangeRate = 0.0
            Exit Function
        End If

        Dim buyrate As Decimal
        Dim selrate As Decimal

        Dim dr() As DataRow

        dr = rs_SYCUREX.Tables("RESULT").Select("yce_frmcur = '" & fmCurr & "' and yce_tocur = '" & toCurr & "'")
        If dr.Length <> 1 Then
            getExchangeRate = 0.0
            Exit Function
        Else
            buyrate = dr(0).Item("yce_buyrat")
            selrate = dr(0).Item("yce_selrat")

            If bsrate = "BuyRate" Then
                getExchangeRate = buyrate
            Else
                getExchangeRate = selrate
            End If
        End If
    End Function '''20131105field 
    Private Sub btcCLM00001_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles btcCLM00001.Selecting

        dtHDRPAIDDAT_btcCLM00001_Selecting = dtHDRPAIDDAT.Text
        dtHDRRCVDAT_btcCLM00001_Selecting = dtHDRRCVDAT.Text


        Select Case PreviousTab
            Case 0 'Header page check - check for Add mode
                If mode = cModeAdd Or mode = cModeUpd Then
                    ''duplicate 
                    'If check_QuotationHeader() = True Then
                    Call fill_CAORDHDR()
                    If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Then
                        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~"
                    End If
                    If Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Or rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~") Then
                        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~"
                    End If

                    'End If
                End If
            Case 1 'Header page check - check for Add mode
                If mode = cModeAdd Or mode = cModeUpd Then
                    ''duplicate 
                    'If check_QuotationHeader() = True Then
                    Call fill_CAORDHDR()
                    If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Then
                        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~"
                    End If
                    If Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Or rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~") Then
                        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~"
                    End If

                    'End If
                End If

            Case 2
                If mode = cModeAdd Or mode = cModeUpd Then
                    'If rbViewOn_I.Checked Then
                    '    Call fill_CAORDITM()
                    'Else
                    '    Call fill_CAORDDTL()
                    'End If

                    '''???
                    'Call insert_CAORDDTL(False)


                End If

            Case 3
                If mode = cModeAdd Or mode = cModeUpd Then
                End If

        End Select

    End Sub



    Private Sub btcCLM00001_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btcCLM00001.SelectedIndexChanged
        ' dtHDRPAIDDAT.Text = dtHDRPAIDDAT_btcCLM00001_Selecting
        'dtHDRPAIDDAT.Text =""


        '  dtHDRRCVDAT.Text = dtHDRRCVDAT_btcCLM00001_Selecting




        Select Case PreviousTab

            Case 0 'Header page check - check for Add mode

                If mode = cModeAdd Then
                    ''2nd/auto change index

                    'If no_need_check_btcindex = False Then

                    '    If check_QuotationHeader() = True Then
                    '        no_need_check_btcindex = True

                    '    Else
                    '        no_need_check_btcindex = True
                    '        btcCLM00001.SelectedIndex = 0
                    '    End If
                    'Else
                    '    no_need_check_btcindex = False
                    'End If



                    Call fill_CAORDHDR()

                    If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Then
                        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~"
                    End If

                    If Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Or rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~") Then
                        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~"
                    End If

                End If

            Case 2
                If mode = cModeAdd Or mode = cModeUpd Then

                    If chkconfirmclm.Checked = False And chkvalidclm.Checked = False Then
                        MsgBox("Please choose potential/valid claim!")
                        btcCLM00001.SelectedIndex = 0

                        Exit Sub
                    End If

                    '''??? sometimes data not filled?
                    If rbViewOn_I.Checked Then
                        Call fill_CAORDITM()
                        dgSummary.DataSource = rs_CAORDITM.Tables("RESULT").DefaultView

                        '''0811 
                        If rs_CAORDITM.Tables("RESULT") Is Nothing Then
                            Exit Sub
                        End If
                        If rs_CAORDITM.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
                            Exit Sub
                        End If
                        If rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cai_creusr") = "~*ADD*~" Or rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cai_creusr") = "~*NEW*~" Then
                            rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cai_creusr") = "~*NEW*~"
                        Else
                            '''1122
                            rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cai_creusr") = "~*UPD*~"
                        End If
                    Else
                        Call fill_CAORDDTL()
                        dgSummary.DataSource = rs_CAORDDTL.Tables("RESULT").DefaultView
                        '''0811 
                        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
                            Exit Sub
                        End If
                        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
                            Exit Sub
                        End If
                        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
                            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~"
                        Else
                            '''1122
                            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
                        End If

                    End If



                End If

                'Call display_dgSummary("A")

            Case 3

                If mode = cModeAdd Or mode = cModeUpd Then

                End If
        End Select




        If Me.btcCLM00001.SelectedIndex = 0 Then
            display_CAORDHDR()
            'format_Approval(0)
        ElseIf Me.btcCLM00001.SelectedIndex = 1 Then

            If rbClaimBy_U.Checked = True Then
                lbl_pay_amt.Text = "0"
            Else
                lbl_pay_amt.Text = cal_cur_rate(Val(txt_Hdr_FinalClaimAmt.Text), cbo_Hdr_ClaimAmtCurrency.Text.Trim)
                lbl_pay_amt.Text = round(cal_cur_rate2(Val(lbl_pay_amt.Text), cbo_pay_cur.Text), 2)
            End If
            lbl_income_amt.Text = cal_cur_rate(Val(txt_Hdr_ClaimToVNAmt.Text), cbo_Hdr_ClaimToVNAmtCur.Text.Trim) + cal_cur_rate(Val(txt_Hdr_ClaimToInsAmt.Text), cbo_Hdr_ClaimToInsAmtCur.Text.Trim)
            lbl_income_amt.Text = round(cal_cur_rate2(Val(lbl_income_amt.Text), cbo_income_cur.Text), 2)



        ElseIf Me.btcCLM00001.SelectedIndex = 2 Then
            gbViewOn.Enabled = True
            rbViewOn_I.Enabled = True
            rbViewOn_S.Enabled = True

            Dim newseq As Integer

            If mode = cModeAdd Then
                'If dgSummary.SelectedRows.Count > 0 Then

                '    If Val(dgSummary.SelectedRows(0).Cells("cai_caordseq").Value) > 0 Then
                '        display_CAORDITM(dgSummary.SelectedRows(0).Cells("cai_caordseq").Value)
                '    End If

                '    'format_Approval(dgSummary.SelectedRows(0).Cells("cai_caordseq").Value)
                'Else

                If rs_CAORDDTL.Tables("RESULT").Rows.Count = 0 Then
                    If MsgBox("Do you want to insert detail reference?", vbYesNo) = vbYes Then
                        'MsgBox("Please use Quick Insert function to insert reference.")
                        Dim frm As New frmCLMQuickInsert(txtClaimPeriod.Text, cboPriCust.Text, cboSecCust.Text, cboVendor.Text, nHdrSearchBy)

                        frm.MdiParent = Me.MdiParent
                        frm.Show()
                        Call frm.get_date_range(Me.cboClaimPeriod.Text.Trim)

                        AddHandler frm.returnSelectedRecords, AddressOf returnSelectedRecordsHandler


                        'Call insert_CAORDDTL(True)
                        'Call insert_CAORDITM(True)
                        'rbViewOn_S.Checked = True
                        'Call display_CAORDDTL(1)
                        btcCLM00001.SelectedIndex = 0
                    Else
                        btcCLM00001.SelectedIndex = 0
                    End If
                Else
                    '''20140414
                    'not zero rows
                    ' ''If rbViewOn_I.Checked Then
                    ' ''    newseq = rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("CAI_CAORDSEQ")
                    ' ''    Call display_CAORDITM(newseq)
                    ' ''Else
                    newseq = rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("CAD_CAORDSEQ")
                    Call display_CAORDDTL(newseq)
                    ' ''End If

                End If


                'format_Approval(sReadingSeq_Item)
                'End If
            ElseIf mode = cModeUpd Then
                'If dgSummary.SelectedRows.Count > 0 Then
                '    If Val(dgSummary.SelectedRows(0).Cells("cad_caordseq").Value) > 0 Then
                '        display_CAORDDTL(dgSummary.SelectedRows(0).Cells("cad_caordseq").Value)

                '    End If
                '    'format_Approval(dgSummary.SelectedRows(0).Cells("cad_caordseq").Value)
                'Else
                If rs_CAORDDTL.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("No Ship reference! Please use Quick Insert function to insert reference.")
                    btcCLM00001.TabPages(0).Enabled = True
                    'btcCLM00001.TabPages(1).Enabled = True
                    btcCLM00001.TabPages(2).Enabled = True
                    btcCLM00001.TabPages(3).Enabled = False
                    btcCLM00001.SelectedIndex = 0
                    mmdInsRow.Enabled = False
                    mmdDelRow.Enabled = False

                    If mode = cModeUpd Then
                        If Microsoft.VisualBasic.Left(temp_yup_usrgrp, 3) <> "ACT" Then
                            mmdInsRow.Enabled = True
                        End If

                        If sClaimStatus <> "OPEN" And sClaimStatus <> "WAIT" Then
                            mmdInsRow.Enabled = False
                        End If


                    End If


                Else
                    '20140414
                    '''not zero rows
                    ' ''If rbViewOn_I.Checked Then
                    ' ''    newseq = rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("CAI_CAORDSEQ")
                    ' ''    Call display_CAORDITM(newseq)
                    ' ''Else
                    newseq = rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("CAD_CAORDSEQ")
                    Call display_CAORDDTL(newseq)
                    ' ''End If
                End If
            End If


            Call set_Back_Next_button()

        ElseIf Me.btcCLM00001.SelectedIndex = 3 Then
            If IsNumeric(lblSeq.Text) Then
                If rbViewOn_I.Checked Then
                    'update_CAORDITM(lblSeq.Text)
                    ' Set_Approval_Right_for_dgSummary(cModeUpd)
                Else
                    'update_CAORDDTL(lblSeq.Text)
                    'Set_Approval_Right_for_dgSummary(cModeUpd)
                End If
            End If
            Call format_dgSummary()

        Else


        End If

        PreviousTab = btcCLM00001.SelectedIndex
        Cursor = Cursors.Default

    End Sub
    Private Sub set_Back_Next_button()

        If rbViewOn_I.Checked Then

            If sReadingIndexQ_Item = 0 Then
                cmd_dtl_Back.Enabled = False
            Else
                cmd_dtl_Back.Enabled = True
            End If
            If sReadingIndexQ_Item = rs_CAORDITM.Tables("RESULT").Rows.Count - 1 Then
                cmd_dtl_Next.Enabled = False
            Else
                cmd_dtl_Next.Enabled = True
            End If

        Else

            If sReadingIndexQ_ship = 0 Then
                cmd_dtl_Back.Enabled = False
            Else
                cmd_dtl_Back.Enabled = True
            End If
            If sReadingIndexQ_ship = rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 Then
                cmd_dtl_Next.Enabled = False
            Else
                cmd_dtl_Next.Enabled = True
            End If

        End If
    End Sub

    Private Sub format_Back_Next_button()
        If rbViewOn_I.Checked Then
            If rs_CAORDITM.Tables("RESULT").Rows.Count > 0 Then
                If rs_CAORDITM.Tables("RESULT").Rows.Count <> 1 Then
                    If lblSeq.Text = rs_CAORDITM.Tables("RESULT").Rows(rs_CAORDITM.Tables("RESULT").Rows.Count - 1).Item("cai_caordseq") Then
                        cmd_dtl_Back.Enabled = True
                        cmd_dtl_Next.Enabled = False
                    ElseIf lblSeq.Text = rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_caordseq") Then
                        cmd_dtl_Back.Enabled = False
                        cmd_dtl_Next.Enabled = True
                    Else
                        cmd_dtl_Back.Enabled = True
                        cmd_dtl_Next.Enabled = True
                    End If
                Else
                    cmd_dtl_Back.Enabled = False
                    cmd_dtl_Next.Enabled = False
                End If
            Else
                cmd_dtl_Back.Enabled = False
                cmd_dtl_Next.Enabled = False
            End If
        Else

            If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
                Exit Sub
            End If


            If rs_CAORDDTL.Tables("RESULT").Rows.Count > 0 Then
                If rs_CAORDDTL.Tables("RESULT").Rows.Count <> 1 Then
                    If lblSeq.Text = rs_CAORDDTL.Tables("RESULT").Rows(rs_CAORDDTL.Tables("RESULT").Rows.Count - 1).Item("cad_caordseq") Then
                        cmd_dtl_Back.Enabled = True
                        cmd_dtl_Next.Enabled = False
                    ElseIf lblSeq.Text = rs_CAORDDTL.Tables("RESULT").Rows(0).Item("cad_caordseq") Then
                        cmd_dtl_Back.Enabled = False
                        cmd_dtl_Next.Enabled = True
                    Else
                        cmd_dtl_Back.Enabled = True
                        cmd_dtl_Next.Enabled = True
                    End If
                Else
                    cmd_dtl_Back.Enabled = False
                    cmd_dtl_Next.Enabled = False
                End If
            Else
                cmd_dtl_Back.Enabled = False
                cmd_dtl_Next.Enabled = False
            End If
        End If
    End Sub

    Private Sub cmd_dtl_Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_dtl_Back.Click
        Dim i As Integer


        If rbViewOn_I.Checked Then
            ''item
            '20131203
            fill_CAORDITM()

            '''
            ''avoid DBNULL
            If Not rs_CAORDITM.Tables("RESULT").Rows.Count > sReadingIndexQ_Item Then

                Exit Sub
            End If

            '''0811
            If rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("cai_creusr") = "~*ADD*~" Or rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("cai_creusr") = "~*NEW*~" Then
                rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("cai_creusr") = "~*NEW*~"
            End If

            If sReadingIndexQ_Item = 0 Then
                sReadingIndexQ_Item = 0
            Else
                sReadingIndexQ_Item = sReadingIndexQ_Item - 1
            End If

            ''avoid DBNULL
            If Not rs_CAORDITM.Tables("RESULT").Rows.Count > sReadingIndexQ_Item Then
                Exit Sub
            End If



            Dim newseq As Integer
            newseq = rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("CAI_CAORDSEQ")

            Call display_CAORDITM(newseq)
            'If rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("del") = "Y" Then
            '    Exit Sub
            'End If


            cmd_dtl_Next.Enabled = True
            If sReadingIndexQ_Item = 0 Then
                cmd_dtl_Back.Enabled = False
            Else
                cmd_dtl_Back.Enabled = True
            End If

        Else
            ''ship
            fill_CAORDDTL()

            '''
            ''avoid DBNULL
            If Not rs_CAORDDTL.Tables("RESULT").Rows.Count > sReadingIndexQ_ship Then

                Exit Sub
            End If

            '''0811
            If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
                rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~"
            End If

            If sReadingIndexQ_ship = 0 Then
                sReadingIndexQ_ship = 0
            Else
                sReadingIndexQ_ship = sReadingIndexQ_ship - 1
            End If

            ''avoid DBNULL
            If Not rs_CAORDDTL.Tables("RESULT").Rows.Count > sReadingIndexQ_ship Then
                Exit Sub
            End If



            Dim newseq As Integer
            newseq = rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_CAORDSEQ")

            Call display_CAORDDTL(newseq)
            'If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("del") = "Y" Then
            '    Exit Sub
            'End If


            cmd_dtl_Next.Enabled = True
            If sReadingIndexQ_ship = 0 Then
                cmd_dtl_Back.Enabled = False
            Else
                cmd_dtl_Back.Enabled = True
            End If


        End If
    End Sub

    Private Sub cmd_dtl_Next_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_dtl_Next.Click
        Dim i As Integer


        If rbViewOn_I.Checked Then
            ''Item
            '20131203
            fill_CAORDITM()

            '''
            ''avoid DBNULL
            If Not rs_CAORDITM.Tables("RESULT").Rows.Count > sReadingIndexQ_Item Then
                Exit Sub
            End If

            If sReadingIndexQ_Item = rs_CAORDITM.Tables("RESULT").Rows.Count - 1 Then
                sReadingIndexQ_Item = sReadingIndexQ_Item
            Else
                sReadingIndexQ_Item = sReadingIndexQ_Item + 1
            End If

            ''avoid DBNULL
            If Not rs_CAORDITM.Tables("RESULT").Rows.Count > sReadingIndexQ_Item Then
                Exit Sub
            End If

            Dim newseq As Integer
            newseq = rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("cai_caordseq")

            Call display_CAORDITM(newseq)
            'If rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("del") = "Y" Then
            '    Exit Sub
            'End If

            cmd_dtl_Back.Enabled = True
            If sReadingIndexQ_Item = rs_CAORDITM.Tables("RESULT").Rows.Count - 1 Then
                cmd_dtl_Next.Enabled = False
            Else
                cmd_dtl_Next.Enabled = True
            End If


        Else
            ''Ship
            '20131203
            fill_CAORDDTL()

            '''
            ''avoid DBNULL
            If Not rs_CAORDDTL.Tables("RESULT").Rows.Count > sReadingIndexQ_ship Then
                Exit Sub
            End If

            If sReadingIndexQ_ship = rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 Then
                sReadingIndexQ_ship = sReadingIndexQ_ship
            Else
                sReadingIndexQ_ship = sReadingIndexQ_ship + 1
            End If

            ''avoid DBNULL
            If Not rs_CAORDDTL.Tables("RESULT").Rows.Count > sReadingIndexQ_ship Then
                Exit Sub
            End If

            Dim newseq As Integer
            newseq = rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("CAD_CAORDSEQ")

            Call display_CAORDDTL(newseq)
            'If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("del") = "Y" Then
            'Exit Sub
            ' End If

            cmd_dtl_Back.Enabled = True
            If sReadingIndexQ_ship = rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 Then
                cmd_dtl_Next.Enabled = False
            Else
                cmd_dtl_Next.Enabled = True
            End If

        End If



    End Sub

    'Private Sub rbViewOn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbViewOn_I.CheckedChanged, rbViewOn_S.CheckedChanged

    '    '''prevent 2nd call
    '    gb_count_rbViewOn = Val(gb_count_rbViewOn) + 1
    '    If gb_count_rbViewOn >= 2 Then
    '        gb_count_rbViewOn = 0
    '        Exit Sub
    '    End If


    '    If mode = cModeAdd Or mode = cModeUpd Or mode = cModeRead Then
    '        If rbViewOn_I.Checked Then

    '            Call fill_CAORDDTL()

    '            'cbo_Dtl_ClaimType.Visible = False
    '            'lbl_Dtl_AppLmtChkPer.Visible = False

    '            Dim newseq As Integer
    '            If sReadingIndexQ_Item > rs_CAORDITM.Tables("RESULT").Rows.Count - 1 Then
    '                sReadingIndexQ_Item = rs_CAORDITM.Tables("RESULT").Rows.Count - 1
    '                If sReadingIndexQ_Item < 0 Then
    '                    sReadingIndexQ_Item = 0
    '                End If
    '            End If
    '            newseq = rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("cai_caordseq")
    '            display_CAORDITM(newseq)

    '            'format_Approval(newseq)

    '            dgSummary.DataSource = rs_CAORDITM.Tables("RESULT").DefaultView
    '            set_Back_Next_button()
    '        Else

    '            Call fill_CAORDITM()

    '            'cbo_Dtl_ClaimType.Enabled = False
    '            'lbl_Dtl_AppLmtChkPer.Visible = False

    '            Dim newseq As Integer
    '            If sReadingIndexQ_ship > rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 Then
    '                sReadingIndexQ_ship = rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
    '                If sReadingIndexQ_ship < 0 Then
    '                    sReadingIndexQ_ship = 0
    '                End If
    '            End If
    '            newseq = rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("CAD_CAORDSEQ")

    '            display_CAORDDTL(newseq)

    '            'format_Approval(newseq)
    '            dgSummary.DataSource = rs_CAORDDTL.Tables("RESULT").DefaultView
    '            set_Back_Next_button()
    '        End If
    '        'format_dgSummary()
    '    End If

    'End Sub

    Private Sub display_CAORDITM(ByVal seq As Integer)
        ' ''If rs_CAORDITM.Tables.Count = 0 Then
        ' ''    Exit Sub
        ' ''End If

        ' ''If rs_CAORDITM.Tables("RESULT").Rows.Count = 0 Then
        ' ''    Exit Sub
        ' ''End If

        ' ''Dim CAI_DEL As String
        ' ''Dim CAI_COCDE As String
        ' ''Dim CAI_CAORDNO As String
        ' ''Dim CAI_CAORDSEQ As String
        ' ''Dim CAI_CLATYP As String
        ' ''Dim CAI_TXCOCDE As String
        ' ''Dim CAI_ITMNO As String
        '' ''Dim CAI_CUSITM As String
        '' ''Dim CAI_CUSSTYNO As String
        '' ''Dim CAI_VENITM As String
        ' ''Dim CAI_ITMDSC As String
        '' ''Dim CAI_PRDVEN As String
        '' ''Dim CAI_VENTYP As String
        '' ''Dim CAI_SCCURCDE As String
        '' ''Dim CAI_SCNETUNTPRC As Decimal
        '' ''Dim CAI_SCFCURCDE As String
        '' ''Dim CAI_SCFTYPRC As Decimal
        '' ''Dim CAI_SCPCKUNT As String
        '' ''Dim CAI_SCORDQTY As String
        '' ''Dim CAI_SCSHPQTY As String
        '' ''Dim CAI_CAQTY As String
        '' ''Dim CAI_CAQTY_FINAL As String
        ' ''Dim CAI_RMK As String
        ' ''Dim CAI_SALCUR As String
        ' ''Dim CAI_SALAMT As Decimal
        ' ''Dim CAI_GRSPFTAMT As Decimal
        ' ''Dim CAI_CALMTAMT As Decimal
        ' ''Dim CAI_CALMTPER As String
        ' ''Dim CAI_CAREMAMT As Decimal
        ' ''Dim CAI_CACUR As String
        ' ''Dim CAI_CAQTYAMT_ORG As Decimal
        ' ''Dim CAI_CAQTYAMT_FINAL As Decimal
        ' ''Dim CAI_CAAMT_ORG As Decimal
        ' ''Dim CAI_CAAMT_FINAL As Decimal
        ' ''Dim CAI_TTLCAAMT_ORG As Decimal
        ' ''Dim CAI_TTLCAAMT_FINAL As Decimal
        '' ''Dim CAI_CAVSGRSPFT As Decimal
        ' ''Dim CAI_APP1FLG As String
        ' ''Dim CAI_APP1FLGBY As String
        ' ''Dim CAI_APP1FLGDAT As String
        ' ''Dim CAI_CATOINSCUR As String
        ' ''Dim CAI_CATOINSAMT As Decimal
        ' ''Dim CAI_CATOVNCUR As String
        ' ''Dim CAI_CATOVNAMT As Decimal
        ' ''Dim CAI_CATOHKOCUR As String
        ' ''Dim CAI_CATOHKOAMT As Decimal
        ' ''Dim CAI_APP2FLG As String
        ' ''Dim CAI_APP2FLGBY As String
        ' ''Dim CAI_APP2FLGDAT As String
        ' ''Dim cai_cusitm As String
        ' ''Dim cai_cusstyno As String
        ' ''Dim cai_venitm As String
        ' ''Dim cai_prdven As String
        ' ''Dim CAI_CREUSR As String

        ' ''Dim line As Integer
        ' ''Dim i As Integer

        ' ''line = 0

        ' ''For i = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
        ' ''    If seq = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caordseq") Then
        ' ''        line = i
        ' ''    End If
        ' ''Next i

        ' ''CAI_COCDE = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_cocde")
        ' ''CAI_CAORDNO = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caordno")
        ' ''CAI_CAORDSEQ = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caordseq")
        ''''''DBNULL?
        ' ''CAI_CLATYP = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_clatyp")
        ' ''CAI_TXCOCDE = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_txcocde")
        '' ''CAI_SCORDNO = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_scordno")
        '' ''CAI_SCORDSEQ = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_scordseq")
        '' ''CAI_POPURORD = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_popurord")
        '' ''CAI_POPURSEQ = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_popurseq")
        '' ''CAI_POJOBORD = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_pojobord")
        '' ''CAI_SHINVNO = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_shinvno")
        '' ''CAI_SCCUSPONO = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_sccuspono")
        '' ''CAI_SHISSDAT = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_shissdat")
        '' ''CAI_SHETDDAT = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_shetddat")
        '' ''CAI_SHETADAT = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_shetadat")
        ' ''CAI_ITMNO = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_itmno")
        '' ''CAI_CUSITM = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_cusitm")
        '' ''CAI_CUSSTYNO = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_cusstyno")
        '' ''CAI_VENITM = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_venitm")
        ' ''CAI_ITMDSC = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_itmdsc")
        '' ''CAI_PRDVEN = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_prdven")
        '' ''CAI_VENTYP = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_ventyp")
        '' ''CAI_SCCURCDE = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_sccurcde")
        '' ''CAI_SCNETUNTPRC = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_scnetuntprc")
        '' ''CAI_SCFCURCDE = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_scfcurcde")
        '' ''CAI_SCFTYPRC = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_scftyprc")
        '' ''CAI_SCPCKUNT = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_scpckunt")
        '' ''CAI_SCORDQTY = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_scordqty")
        '' ''CAI_SCSHPQTY = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_scshpqty")
        '' ''CAI_CAQTY = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caqty")
        '' ''CAI_CAQTY_FINAL = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caqty_final")
        ' ''CAI_RMK = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_rmk")
        ' ''CAI_SALCUR = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_salcur")
        ' ''CAI_SALAMT = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_salamt")
        ' ''CAI_GRSPFTAMT = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_grspftamt")
        ' ''CAI_CALMTAMT = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_calmtamt")
        ''''''20131114
        '' '' CAI_CALMTPER = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_calmtper")
        '' ''CAI_CAREMAMT = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caremamt")
        ' ''CAI_CACUR = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_cacur")
        ' ''CAI_CAQTYAMT_ORG = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caqtyamt_org")
        ' ''CAI_CAQTYAMT_FINAL = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caqtyamt_final")
        ' ''CAI_CAAMT_ORG = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caamt_org")
        ' ''CAI_CAAMT_FINAL = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caamt_final")
        ' ''CAI_TTLCAAMT_ORG = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_ttlcaamt_org")
        ' ''CAI_TTLCAAMT_FINAL = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_ttlcaamt_final")
        '' ''CAI_CAVSGRSPFT = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_cavsgrspft")
        ' ''CAI_APP1FLG = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_app1flg")
        ' ''CAI_APP1FLGBY = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_app1flgby")
        ' ''CAI_APP1FLGDAT = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_app1flgdat")
        ' ''CAI_CATOINSCUR = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catoinscur")
        ' ''CAI_CATOINSAMT = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catoinsamt")
        ' ''CAI_CATOVNCUR = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catovncur")
        ' ''CAI_CATOVNAMT = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catovnamt")
        ' ''CAI_CATOHKOCUR = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catohkocur")
        ' ''CAI_CATOHKOAMT = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catohkoamt")
        ' ''CAI_APP2FLG = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_app2flg")
        ' ''CAI_APP2FLGBY = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_app2flgby")
        ' ''CAI_APP2FLGDAT = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_app2flgdat")
        ' ''cai_cusitm = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_cusitm")
        ' ''cai_cusstyno = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_cusstyno")
        ' ''cai_venitm = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_venitm")
        ' ''cai_prdven = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_prdven")
        ' ''CAI_CREUSR = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr")

        ''''''20131105field CAI_DEL = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_del")

        ' ''lblSeq.Text = CAI_CAORDSEQ

        ' ''Call display_combo(CAI_CLATYP, cbo_Dtl_ClaimType)
        ' ''sDtlClaimType = cbo_Dtl_ClaimType.Text

        '' ''cboCoCde.Text = CAI_TXCOCDE
        ' ''txtCoCde.Text = CAI_TXCOCDE
        ' ''txtShipNo.Text = ""
        ' ''txtShipSeq.Text = ""
        ' ''txtSCNo.Text = ""
        ' ''txtSCSeq.Text = ""
        ' ''txtPONo.Text = ""
        ' ''txtPOSeq.Text = ""
        ' ''txtJobNo.Text = ""
        ' ''txtInvNo.Text = ""

        ' ''txtCusPONo.Text = ""
        ' ''txtInvIssDat.Text = ""
        ' ''txtInvETDDat.Text = ""
        ' ''txtInvETADat.Text = ""

        ' ''txtItmNo.Text = CAI_ITMNO
        ' ''txtCustItmNo.Text = cai_cusitm
        ' ''txtCustStyNo.Text = cai_cusstyno
        ' ''txtVenItmNo.Text = cai_venitm
        ' ''txtItmDsc.Text = CAI_ITMDSC
        ' ''txtPV.Text = cai_prdven
        '' ''Call display_combo(CAI_PRDVEN, cboPV)

        '' ''lblVentyp.Text = CAI_VENTYP
        '' ''lblVentyp.Text = ""

        '' ''If lblVentyp.Text = "E" Then
        '' ''    lbl_Dtl_ClaimToVNAmt.Text = "External Vendor Amount"
        '' ''Else
        '' ''    lbl_Dtl_ClaimToVNAmt.Text = "Internal Vendor Amount"
        '' ''End If

        '' ''cboSelPrcCurrency.Text = CAI_SCCURCDE
        ' ''txtSelPrcCurrency.Text = ""
        ' ''txtSelPrc.Text = ""
        '' ''cboItmCstCurrency.Text = CAI_SCFCURCDE
        ' ''txtItmCstCurrency.Text = ""
        ' ''txtItmCst.Text = ""
        ' ''txtOrdQtyUM.Text = ""
        ' ''txtShipQtyUM.Text = ""
        ' ''txtOrdQty.Text = ""
        ' ''txtShipQty.Text = ""
        ' ''txt_Dtl_Rmk.Text = CAI_RMK

        '' ''cbo_Dtl_SalesAmtCurrency.Text = CAI_SALCUR
        '' ''txt_Dtl_SalesAmt.Text = Decimal.Round(CAI_SALAMT, 2)
        '' ''cbo_Dtl_GrsPftCurrency.Text = CAI_SALCUR
        '' ''txt_Dtl_GrsPft.Text = Decimal.Round(CAI_GRSPFTAMT, 2)
        '' ''cbo_Dtl_AppLmtChkCurrency.Text = CAI_SALCUR
        '' ''txt_Dtl_AppLmtChk.Text = Decimal.Round(CAI_CALMTAMT, 2)

        ''''''20131112 tmp
        '' ''        lbl_Dtl_AppLmtChkPer.Text = ""
        ''''''lbl_Dtl_AppLmtChkPer.Text = Decimal.Round(Val(CAI_CALMTPER), 0).ToString + "%"

        '' ''cbo_Dtl_RemainClaimCurrency.Text = CAI_SALCUR

        ''''''''20131108
        '''''''''txt_Dtl_RemainClaim.Text = Decimal.Round(CAI_CAREMAMT, 2)

        '' ''txtClaimQtyUM.Text = ""
        ' '' ''Call display_combo(CAI_SCPCKUNT, cboOrdQtyUM)
        '' ''txt_Dtl_OrgClaimQty.Text = ""
        '' ''txt_Dtl_FinalClaimQty.Text = ""

        '' ''cbo_Dtl_ClaimQtyAmtCurrency.Text = CAI_CACUR
        '' ''cbo_Dtl_ClaimAmtCurrency.Text = CAI_CACUR
        '' ''cbo_Dtl_ClaimTtlAmtCurrency.Text = CAI_CACUR

        '' ''txt_Dtl_OrgClaimQtyAmt.Text = ""
        '' ''txt_Dtl_FinalClaimQtyAmt.Text = ""

        '' ''txt_Dtl_OrgClaimAmt.Text = Decimal.Round(CAI_CAAMT_ORG, 2)
        '' ''txt_Dtl_FinalClaimAmt.Text = Decimal.Round(CAI_CAAMT_FINAL, 2)

        '' ''txt_Dtl_OrgClaimTtlAmt.Text = Decimal.Round(CAI_TTLCAAMT_ORG, 2)
        '' ''txt_Dtl_FinalClaimTtlAmt.Text = Decimal.Round(CAI_TTLCAAMT_FINAL, 2)

        '' ''txt_Dtl_ClaimVSGPPer.Text = Decimal.Round(CAI_CAVSGRSPFT, 2)

        ' '' ''cbo_Dtl_ClaimToInsAmtCurrency.Text = CAI_CATOINSCUR
        ' '' ''txt_Dtl_ClaimToInsAmt.Text = Decimal.Round(CAI_CATOINSAMT, 2)
        ' '' ''cbo_Dtl_ClaimToVNAmtCurrency.Text = CAI_CATOVNCUR
        ' '' ''txt_Dtl_ClaimToVNAmt.Text = Decimal.Round(CAI_CATOVNAMT, 2)
        ' '' ''cbo_Dtl_ClaimToHKOAmtCurrency.Text = CAI_CATOHKOCUR
        ' '' ''txt_Dtl_ClaimToHKOAmt.Text = Decimal.Round(CAI_CATOHKOAMT, 2)

        ' '' ''lbl_Dtl_ClaimToInsAmt_ExchRate.Text = Decimal.Round(getExchangeRate(CAI_CATOINSCUR, CAI_CACUR, "BuyRate"), 4)
        ' '' ''lbl_Dtl_ClaimToVNAmt_ExchRate.Text = Decimal.Round(getExchangeRate(CAI_CATOVNCUR, CAI_CACUR, "BuyRate"), 4)
        ' '' ''lbl_Dtl_ClaimToHKOAmt_ExchRate.Text = Decimal.Round(getExchangeRate(CAI_CATOHKOCUR, CAI_CACUR, "BuyRate"), 4)

        ' ''CAI_APP1FLG = CAI_APP1FLG.Trim
        ' ''CAI_APP2FLG = CAI_APP2FLG.Trim

        ' ''If CAI_DEL = "Y" Then
        ' ''    chkDelete.Checked = True
        ' ''Else
        ' ''    chkDelete.Checked = False
        ' ''End If

        ' ''If CAI_APP1FLG = "Y" Then
        ' ''    ''cb_Dtl_APV1.Checked = True
        ' ''    chkDelete.Enabled = False
        ' ''Else
        ' ''    'cb_Dtl_APV1.Checked = False
        ' ''    If sCheckedLevel = "I" Or sCheckedLevel = "C" Then
        ' ''        chkDelete.Enabled = True
        ' ''    Else
        ' ''        chkDelete.Enabled = False
        ' ''    End If
        ' ''End If

        ' ''If CAI_APP2FLG = "Y" Then
        ' ''    'cb_Dtl_APV2.Checked = True
        ' ''Else
        ' ''    ''cb_Dtl_APV2.Checked = False
        ' ''End If

        '' ''If rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caqtyamt_final") = 0.0 And cb_Dtl_APV1.Checked = False Then
        '' ''If rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_ttlcaamt_final") = 0.0 And cb_Dtl_APV1.Checked = False Then
        '' ''    'cbo_Dtl_ClaimAmtCurrency.Enabled = True
        '' ''Else
        '' ''    'cbo_Dtl_ClaimAmtCurrency.Enabled = False
        '' ''End If
        '' ''txt_Dtl_OrgClaimQty.Enabled = False

        ' ''If rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_del") = "Y" Then
        ' ''    chkDelete.Checked = True
        ' ''    txt_Dtl_Rmk.Enabled = False

        ' ''Else
        ' ''    chkDelete.Checked = False
        ' ''    txt_Dtl_Rmk.Enabled = True

        ' ''End If



        ' ''btcCLM00001.TabPages(1).Enabled = True
        ' ''btcCLM00001.TabPages(2).Enabled = True
        '' ''20140218
        ''''''btcCLM00001.SelectedIndex = 2




        ' ''lblOdrQty.Enabled = False
        ' ''lblShipQty.Enabled = False
        ' ''lblSelPrc.Enabled = False
        ' ''lblItmCst.Enabled = False
        ' ''lblCoCde.Enabled = False
        ' ''lblShipNo.Enabled = False
        ' ''lblSCNo.Enabled = False
        ' ''lblPONo.Enabled = False
        ' ''lblJobNo.Enabled = False
        ' ''lblInvoiceNo.Enabled = False
        ' ''lblCustPONo.Enabled = False
        ' ''lblInvIssDat.Enabled = False
        ' ''lblInvETDDat.Enabled = False
        ' ''lblInvETADat.Enabled = False

        '' ''format_Back_Next_button()
        '' ''format_Approval(seq)
    End Sub

    Private Sub display_CAORDDTL(ByVal seq As Integer)
        If rs_CAORDDTL.Tables.Count = 0 Then
            Exit Sub
        End If

        If rs_CAORDDTL.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        Dim CAD_DEL As String
        Dim CAD_COCDE As String
        Dim CAD_CAORDNO As String
        Dim CAD_CAORDSEQ As String
        Dim CAD_CLATYP As String
        Dim CAD_TXCOCDE As String
        Dim CAD_SHPNO As String
        Dim CAD_SHPSEQ As String
        Dim CAD_SCORDNO As String
        Dim CAD_SCORDSEQ As String
        Dim CAD_POPURORD As String
        Dim CAD_POPURSEQ As String
        Dim CAD_POJOBORD As String
        Dim CAD_SHINVNO As String
        Dim CAD_SCCUSPONO As String
        Dim CAD_SHISSDAT As String
        Dim CAD_SHETDDAT As String
        Dim CAD_SHETADAT As String
        Dim CAD_ITMNO As String
        Dim CAD_CUSITM As String
        Dim CAD_CUSSTYNO As String
        Dim CAD_VENITM As String
        Dim CAD_ITMDSC As String
        Dim CAD_PRDVEN As String
        Dim CAD_VENTYP As String
        Dim CAD_SCCURCDE As String
        Dim CAD_SCNETUNTPRC As Decimal
        Dim CAD_SCFCURCDE As String
        Dim CAD_SCFTYPRC As Decimal
        Dim CAD_SCPCKUNT As String
        Dim CAD_SCORDQTY As String
        Dim CAD_SCUNTCDE As String
        Dim CAD_SCSHPQTY As String
        Dim CAD_CAQTY As String
        Dim CAD_CAQTY_FINAL As String
        Dim CAD_RMK As String
        Dim CAD_SALCUR As String
        Dim CAD_SALAMT As Decimal
        Dim CAD_GRSPFTAMT As Decimal
        Dim CAD_CALMTAMT As Decimal
        'Dim CAD_CALMTPER As Decimal
        Dim CAD_CAREMAMT As Decimal
        Dim CAD_CACUR As String
        Dim CAD_CAQTYAMT_ORG As Decimal
        Dim CAD_CAQTYAMT_FINAL As Decimal
        Dim CAD_CAAMT_ORG As Decimal
        Dim CAD_CAAMT_FINAL As Decimal
        Dim CAD_TTLCAAMT_ORG As Decimal
        Dim CAD_TTLCAAMT_FINAL As Decimal
        'Dim CAD_CAVSGRSPFT As Decimal
        'Dim CAD_APP1FLG As String
        'Dim CAD_APP1FLGBY As String
        'Dim CAD_APP1FLGDAT As String
        Dim CAD_CATOINSCUR As String
        Dim CAD_CATOINSAMT As Decimal
        Dim CAD_CATOVNCUR As String
        Dim CAD_CATOVNAMT As Decimal
        Dim CAD_CATOHKOCUR As String
        Dim CAD_CATOHKOAMT As Decimal
        'Dim CAD_APP2FLG As String
        'Dim CAD_APP2FLGBY As String
        'Dim CAD_APP2FLGDAT As String
        Dim CAD_CREUSR As String

        Dim line As Integer
        Dim i As Integer

        line = 0

        For i = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
            If seq = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caordseq") Then
                line = i
            End If
        Next i

        CAD_COCDE = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_cocde")
        CAD_CAORDNO = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caordno")
        CAD_CAORDSEQ = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caordseq")
        CAD_CLATYP = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_clatyp")
        CAD_TXCOCDE = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_txcocde")
        CAD_SHPNO = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_shpno")
        CAD_SHPSEQ = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_shpseq")
        CAD_SCORDNO = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_scordno")
        CAD_SCORDSEQ = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_scordseq")
        CAD_POPURORD = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_popurord")
        CAD_POPURSEQ = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_popurseq")
        CAD_POJOBORD = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_pojobord")
        CAD_SHINVNO = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_shinvno")
        CAD_SCCUSPONO = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_sccuspono")
        CAD_SHISSDAT = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_shissdat")
        CAD_SHETDDAT = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_shetddat")
        CAD_SHETADAT = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_shetadat")
        CAD_ITMNO = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_itmno")
        CAD_CUSITM = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_cusitm")
        CAD_CUSSTYNO = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_cusstyno")
        CAD_VENITM = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_venitm")
        CAD_ITMDSC = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_itmdsc")
        CAD_PRDVEN = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_prdven")
        CAD_VENTYP = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_ventyp")
        CAD_SCCURCDE = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_sccurcde")
        CAD_SCNETUNTPRC = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_scnetuntprc")
        CAD_SCFCURCDE = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_scfcurcde")
        CAD_SCFTYPRC = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_scftyprc")
        CAD_SCPCKUNT = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_scpckunt")
        CAD_SCORDQTY = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_scordqty")
        CAD_SCUNTCDE = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_scuntcde")
        CAD_SCSHPQTY = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_scshpqty")
        CAD_CAQTY = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caqty")
        CAD_CAQTY_FINAL = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caqty_final")
        CAD_RMK = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_rmk")
        CAD_SALCUR = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_salcur")
        CAD_SALAMT = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_salamt")
        CAD_GRSPFTAMT = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_grspftamt")
        CAD_CALMTAMT = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_calmtamt")
        'CAD_CALMTPER = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_calmtper")
        '''20131105field CAD_CAREMAMT = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caremamt")
        CAD_CACUR = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_cacur")
        CAD_CAQTYAMT_ORG = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caqtyamt_org")
        CAD_CAQTYAMT_FINAL = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caqtyamt_final")
        CAD_CAAMT_ORG = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caamt_org")
        CAD_CAAMT_FINAL = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caamt_final")
        CAD_TTLCAAMT_ORG = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_ttlcaamt_org")
        CAD_TTLCAAMT_FINAL = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_ttlcaamt_final")
        'CAD_CAVSGRSPFT = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_cavsgrspft")
        'CAD_APP1FLG = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_app1flg")
        'CAD_APP1FLGBY = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_app1flgby")
        'CAD_APP1FLGDAT = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_app1flgdat")
        CAD_CATOINSCUR = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catoinscur")
        CAD_CATOINSAMT = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catoinsamt")
        CAD_CATOVNCUR = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catovncur")
        CAD_CATOVNAMT = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catovnamt")
        CAD_CATOHKOCUR = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catohkocur")
        CAD_CATOHKOAMT = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catohkoamt")
        'CAD_APP2FLG = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_app2flg")
        'CAD_APP2FLGBY = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_app2flgby")
        'CAD_APP2FLGDAT = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_app2flgdat")
        CAD_CREUSR = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr")

        CAD_DEL = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_del")

        lblSeq.Text = CAD_CAORDSEQ

        cbo_Dtl_ClaimType.SelectedIndex = -1
        Call display_combo(CAD_CLATYP, cbo_Dtl_ClaimType)
        sDtlClaimType = cbo_Dtl_ClaimType.Text

        'cboCoCde.Text = CAD_TXCOCDE
        txtCoCde.Text = CAD_TXCOCDE
        txtShipNo.Text = CAD_SHPNO
        txtShipSeq.Text = CAD_SHPSEQ
        txtSCNo.Text = CAD_SCORDNO
        txtSCSeq.Text = CAD_SCORDSEQ
        txtPONo.Text = CAD_POPURORD
        txtPOSeq.Text = CAD_POPURSEQ
        txtJobNo.Text = CAD_POJOBORD
        txtInvNo.Text = CAD_SHINVNO

        txtCusPONo.Text = CAD_SCCUSPONO
        txtInvIssDat.Text = CAD_SHISSDAT
        txtInvETDDat.Text = CAD_SHETDDAT
        txtInvETADat.Text = CAD_SHETADAT

        txtItmNo.Text = CAD_ITMNO
        txtCustItmNo.Text = CAD_CUSITM
        txtCustStyNo.Text = CAD_CUSSTYNO
        txtVenItmNo.Text = CAD_VENITM
        txtItmDsc.Text = CAD_ITMDSC
        txtPV.Text = CAD_PRDVEN
        'Call display_combo(CAD_PRDVEN, cboPV)

        'lblVentyp.Text = CAD_VENTYP

        'If lblVentyp.Text = "E" Then
        '    lbl_Dtl_ClaimToVNAmt.Text = "External Vendor Amount"
        'Else
        '    lbl_Dtl_ClaimToVNAmt.Text = "Internal Vendor Amount"
        'End If

        'cboSelPrcCurrency.Text = CAD_SCCURCDE
        txtSelPrcCurrency.Text = CAD_SCCURCDE
        txtSelPrc.Text = Decimal.Round(CAD_SCNETUNTPRC, 2)
        'cboItmCstCurrency.Text = CAD_SCFCURCDE
        txtItmCstCurrency.Text = CAD_SCFCURCDE
        txtItmCst.Text = Decimal.Round(CAD_SCFTYPRC, 2)
        txtOrdQtyUM.Text = CAD_SCPCKUNT
        ' ''txtClaimQtyUM.Text = CAD_SCPCKUNT
        txtShipQtyUM.Text = CAD_SCUNTCDE
        'Call display_combo(CAD_SCPCKUNT, cboOrdQtyUM)
        txtOrdQty.Text = CAD_SCORDQTY
        txtShipQty.Text = CAD_SCSHPQTY
        ''txt_Dtl_OrgClaimQty.Text = CAD_CAQTY
        ''txt_Dtl_FinalClaimQty.Text = CAD_CAQTY_FINAL
        txt_Dtl_Rmk.Text = CAD_RMK

        'cbo_Dtl_SalesAmtCurrency.Text = CAD_SALCUR
        'txt_Dtl_SalesAmt.Text = Decimal.Round(CAD_SALAMT, 2)
        '' ''cbo_Dtl_GrsPftCurrency.Text = CAD_SALCUR
        '' ''txt_Dtl_GrsPft.Text = ""
        '' ''cbo_Dtl_AppLmtChkCurrency.Text = CAD_SALCUR
        '' ''txt_Dtl_AppLmtChk.Text = ""
        ' '' ''lbl_Dtl_AppLmtChkPer.Text = Decimal.Round(CAD_CALMTPER, 1).ToString + "%"
        '' ''cbo_Dtl_RemainClaimCurrency.Text = CAD_SALCUR
        '' ''txt_Dtl_RemainClaim.Text = ""

        '' ''cbo_Dtl_ClaimQtyAmtCurrency.Text = CAD_CACUR
        '' ''cbo_Dtl_ClaimAmtCurrency.Text = CAD_CACUR
        '' ''cbo_Dtl_ClaimTtlAmtCurrency.Text = CAD_CACUR

        '' ''txt_Dtl_OrgClaimQtyAmt.Text = Decimal.Round(CAD_CAQTYAMT_ORG, 2)
        '' ''txt_Dtl_FinalClaimQtyAmt.Text = Decimal.Round(CAD_CAQTYAMT_FINAL, 2)

        ''txt_Dtl_OrgClaimAmt.Text = Decimal.Round(CAD_CAAMT_ORG, 2)
        ''txt_Dtl_FinalClaimAmt.Text = Decimal.Round(CAD_CAAMT_FINAL, 2)

        ''txt_Dtl_OrgClaimTtlAmt.Text = Decimal.Round(CAD_TTLCAAMT_ORG, 2)
        ''txt_Dtl_FinalClaimTtlAmt.Text = Decimal.Round(CAD_TTLCAAMT_FINAL, 2)

        ''txt_Dtl_ClaimVSGPPer.Text = Decimal.Round(CAD_CAVSGRSPFT, 2)

        'cbo_Dtl_ClaimToInsAmtCurrency.Text = CAD_CATOINSCUR
        'txt_Dtl_ClaimToInsAmt.Text = Decimal.Round(CAD_CATOINSAMT, 2)
        'cbo_Dtl_ClaimToVNAmtCurrency.Text = CAD_CATOVNCUR
        'txt_Dtl_ClaimToVNAmt.Text = Decimal.Round(CAD_CATOVNAMT, 2)
        'cbo_Dtl_ClaimToHKOAmtCurrency.Text = CAD_CATOHKOCUR
        'txt_Dtl_ClaimToHKOAmt.Text = Decimal.Round(CAD_CATOHKOAMT, 2)

        'lbl_Dtl_ClaimToInsAmt_ExchRate.Text = Decimal.Round(getExchangeRate(CAD_CATOINSCUR, CAD_CACUR, "BuyRate"), 4)
        'lbl_Dtl_ClaimToVNAmt_ExchRate.Text = Decimal.Round(getExchangeRate(CAD_CATOVNCUR, CAD_CACUR, "BuyRate"), 4)
        'lbl_Dtl_ClaimToHKOAmt_ExchRate.Text = Decimal.Round(getExchangeRate(CAD_CATOHKOCUR, CAD_CACUR, "BuyRate"), 4)

        If CAD_DEL = "Y" Then
            chkDelete.Checked = True
        Else
            chkDelete.Checked = False
        End If

        For index As Integer = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
            If CAD_ITMNO = rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_itmno") Then
                If rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_app1flg") = "Y" Then
                    chkDelete.Enabled = False
                Else
                    If sCheckedLevel = "S" Or sCheckedLevel = "C" Then
                        chkDelete.Enabled = True
                    Else
                        chkDelete.Enabled = False
                    End If
                End If
                Exit For
            End If
        Next

        'cb_Dtl_APV1.Checked = False
        'cb_Dtl_APV2.Checked = False

        'CAD_APP1FLG = CAD_APP1FLG.Trim
        'CAD_APP2FLG = CAD_APP2FLG.Trim

        'If CAD_APP1FLG = "Y" Then
        '    cb_Dtl_APV1.Checked = True
        '    cbDel.Enabled = False
        'Else
        '    cb_Dtl_APV1.Checked = False
        '    cbDel.Enabled = True
        'End If

        'If CAD_APP2FLG = "Y" Then
        '    cb_Dtl_APV2.Checked = True
        'Else
        '    cb_Dtl_APV2.Checked = False
        'End If

        'If rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_ttlcaamt_final") = 0.0 And cb_Dtl_APV1.Checked = False Then
        '    ''txt_Dtl_OrgClaimQty.Enabled = True
        '    ''cbo_Dtl_ClaimAmtCurrency.Enabled = True
        'Else
        '    ''txt_Dtl_OrgClaimQty.Enabled = False
        '    ''cbo_Dtl_ClaimAmtCurrency.Enabled = False
        'End If
        'txt_Dtl_OrgClaimQty.Enabled = True

        If rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_del") = "Y" Then
            chkDelete.Checked = True
            txt_Dtl_Rmk.Enabled = False


        Else
            chkDelete.Checked = False
            txt_Dtl_Rmk.Enabled = True

            If sClaimStatus <> "OPEN" And sClaimStatus <> "WAIT" Then
                txt_Dtl_Rmk.Enabled = False
                chkDelete.Enabled = False
                dgSummary.Enabled = False
            Else
                txt_Dtl_Rmk.Enabled = False
                chkDelete.Enabled = False
                dgSummary.Enabled = False
                If gsUsrRank < 3 Or Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "SAL" Then
                    txt_Dtl_Rmk.Enabled = True
                    chkDelete.Enabled = True
                    dgSummary.Enabled = True
                End If
            End If


        End If

        btcCLM00001.TabPages(2).Enabled = True
        btcCLM00001.TabPages(3).Enabled = True
        '''btcCLM00001.SelectedIndex = 2

        lblOdrQty.Enabled = True
        lblShipQty.Enabled = True
        lblSelPrc.Enabled = True
        lblItmCst.Enabled = True
        lblCoCde.Enabled = True
        lblShipNo.Enabled = True
        lblSCNo.Enabled = True
        lblPONo.Enabled = True
        lblJobNo.Enabled = True
        lblInvoiceNo.Enabled = True
        lblCustPONo.Enabled = True
        lblInvIssDat.Enabled = True
        lblInvETDDat.Enabled = True
        lblInvETADat.Enabled = True


        'format_Back_Next_button()
        'format_Approval(seq)
    End Sub

    Private Sub format_inputDtl_insert_txno_after()
        txt_Dtl_Rmk.Enabled = True
        If rbViewOn_I.Checked Then
            cbo_Dtl_ClaimType.Enabled = True
        Else
            cbo_Dtl_ClaimType.Enabled = False
        End If
        'gb_Dtl_ClaimAmt.Enabled = True
        'If txt_Dtl_FinalClaimAmt.Text = "0.00" And cb_Dtl_APV1.Checked = False Then
        '    cbo_Dtl_ClaimAmtCurrency.Enabled = True
        'End If
        'txt_Dtl_OrgClaimAmt.Enabled = True
        'txt_Dtl_FinalClaimAmt.Enabled = True
        'cb_Dtl_APV1.Enabled = False
        mmdSave.Enabled = True
    End Sub

    Private Sub format_dgSummary()
        If rs_CAORDDTL.Tables("result").Rows.Count = 0 Then
            Exit Sub
        End If
        dgSummary.Dock = DockStyle.Fill

        rbViewOn_I.Checked = False
        rbViewOn_S.Checked = True

        '''''''''''''''''''''''''''''Item''''''''''''''''''''
        If rbViewOn_I.Checked Then
            Dim i As Integer

            For i = 0 To dgSummary.Columns.Count - 1
                dgSummary.Columns(i).Resizable = DataGridViewTriState.True


                If dgSummary.Columns(i).ValueType.Name = "String" Then
                    dgSummary.Columns(i).DefaultCellStyle.DataSourceNullValue = ""
                ElseIf dgSummary.Columns(i).ValueType.Name = "Int32" Then
                    dgSummary.Columns(i).DefaultCellStyle.DataSourceNullValue = "0"
                    dgSummary.Columns(i).CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgSummary.Columns(i).DefaultCellStyle.Format = "##,0"
                ElseIf dgSummary.Columns(i).ValueType.Name = "Decimal" Then
                    dgSummary.Columns(i).DefaultCellStyle.DataSourceNullValue = "0.00"
                    dgSummary.Columns(i).CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgSummary.Columns(i).DefaultCellStyle.Format = "##,0.00"
                End If

                Select Case i
                    Case 0
                        dgSummary.Columns(i).HeaderText = "Del"
                        dgSummary.Columns(i).Width = 40
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                    Case 3
                        dgSummary.Columns(i).HeaderText = "Seq"
                        dgSummary.Columns(i).Width = 37
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White

                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.Automatic

                        dgSummary.Columns(i).Visible = True
                    Case 5 'Claim Type
                        dgSummary.Columns(i).HeaderText = "Type"
                        dgSummary.Columns(i).Width = 0
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                        dgSummary.Columns(i).Visible = False
                    Case 6 'Item No
                        dgSummary.Columns(i).HeaderText = "Item No"
                        dgSummary.Columns(i).Width = 137
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.Automatic
                    Case 7 'Item desc
                        dgSummary.Columns(i).HeaderText = "Item Desc"
                        dgSummary.Columns(i).Width = 198
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.Automatic
                    Case 8 'Item desc
                        dgSummary.Columns(i).HeaderText = "Remark"
                        dgSummary.Columns(i).Width = 198
                        dgSummary.Columns(i).ReadOnly = False
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.Automatic

                        dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.LightBlue
                        'Case 8 'Remark
                        '    dgSummary.Columns(i).HeaderText = "Remark"
                        '    dgSummary.Columns(i).Width = 100
                        '    If mode = cModeRead Then
                        '        dgSummary.Columns(i).ReadOnly = True
                        '        dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        '    Else
                        '        dgSummary.Columns(i).ReadOnly = False
                        '        dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.Orange
                        '    End If
                        '    dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                    Case 15 'Currency
                        dgSummary.Columns(i).HeaderText = "Curr"
                        dgSummary.Columns(i).Width = 0
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                        dgSummary.Columns(i).Visible = False
                    Case 18, 19
                        If i = 18 Then  'Orginal Claim Amt
                            dgSummary.Columns(i).HeaderText = "Org Amt"
                            dgSummary.Columns(i).Width = 0
                            dgSummary.Columns(i).Visible = False
                        ElseIf i = 19 Then 'Final Claim Amt
                            dgSummary.Columns(i).HeaderText = "FinalAmt"
                            dgSummary.Columns(i).Width = 0
                            dgSummary.Columns(i).Visible = False
                        End If

                        '30240312
                        'If mode = cModeAdd Then
                        '    If sHdrClaimAmtPer = "C" Or sHdrClaimAmtPer = "S" Then
                        '        dgSummary.Columns(i).ReadOnly = True
                        '        dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        '    Else
                        '        dgSummary.Columns(i).ReadOnly = False
                        '        dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.Orange
                        '    End If
                        'ElseIf mode = cModeUpd Then
                        '    If sHdrClaimAmtPer = "C" Or sHdrClaimAmtPer = "S" Then
                        '        dgSummary.Columns(i).ReadOnly = True
                        '        dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        '    Else
                        '        If sClaimStatus = "OPEN" Then
                        '            dgSummary.Columns(i).ReadOnly = False
                        '            dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.Orange
                        '        Else
                        '            dgSummary.Columns(i).ReadOnly = True
                        '            dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        '        End If
                        '    End If
                        'Else 'mode = READ
                        '    dgSummary.Columns(i).ReadOnly = True
                        '    dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        'End If
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                    Case 25, 27, 29 'Claim to Currency
                        dgSummary.Columns(i).HeaderText = "Curr"
                        dgSummary.Columns(i).Width = 0
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                        dgSummary.Columns(i).Visible = False

                    Case 26, 28
                        If i = 26 Then
                            dgSummary.Columns(i).HeaderText = "Ins Amt"
                            dgSummary.Columns(i).Width = 0
                            dgSummary.Columns(i).Visible = False
                        ElseIf i = 28 Then
                            dgSummary.Columns(i).HeaderText = "Vdr Amt"
                            dgSummary.Columns(i).Visible = False
                            dgSummary.Columns(i).Width = 0
                        End If

                        If mode = cModeAdd Then
                            If sHdrClaimAmtPer = "C" Or sHdrClaimAmtPer = "S" Then
                                dgSummary.Columns(i).ReadOnly = True
                                dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                            Else
                                dgSummary.Columns(i).ReadOnly = False
                                dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.Orange
                            End If
                        ElseIf mode = cModeUpd Then
                            If sHdrClaimAmtPer = "C" Or sHdrClaimAmtPer = "S" Then
                                dgSummary.Columns(i).ReadOnly = True
                                dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                            Else
                                If sClaimStatus = "OPEN" Or sClaimStatus = "APV1a" Then
                                    dgSummary.Columns(i).ReadOnly = False
                                    dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.Orange
                                Else
                                    dgSummary.Columns(i).ReadOnly = True
                                    dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                                End If
                            End If
                        Else 'mode = READ
                            dgSummary.Columns(i).ReadOnly = True
                            dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        End If

                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                    Case 30 'Claim to Amt for HKO
                        dgSummary.Columns(i).HeaderText = "HKO Amt"
                        dgSummary.Columns(i).Width = 0
                        dgSummary.Columns(i).ReadOnly = False
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                        dgSummary.Columns(i).Visible = False
                    Case 22 'APV1 Status
                        dgSummary.Columns(i).HeaderText = "Ap1"
                        dgSummary.Columns(i).Width = 0
                        dgSummary.Columns(i).ReadOnly = False
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                        If sHdrClaimAmtPer = "C" Then
                            dgSummary.Columns(i).Visible = False
                        End If
                    Case 31 'APV2 Status
                        dgSummary.Columns(i).HeaderText = "Ap2"
                        dgSummary.Columns(i).Width = 0
                        dgSummary.Columns(i).ReadOnly = False
                        If sHdrClaimAmtPer = "C" Then
                            dgSummary.Columns(i).Visible = False
                        End If
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                    Case 34 'Item No
                        dgSummary.Columns(i).HeaderText = "Cus Item No"
                        dgSummary.Columns(i).Width = 127
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.Automatic
                    Case 35 'Item No
                        dgSummary.Columns(i).HeaderText = "Cus Style No"
                        dgSummary.Columns(i).Width = 127
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.Automatic
                    Case 36 'Item No
                        dgSummary.Columns(i).HeaderText = "Ven Item No"
                        dgSummary.Columns(i).Width = 137
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.Automatic
                    Case 37 'Item No
                        dgSummary.Columns(i).HeaderText = "Prod. Vendor"
                        dgSummary.Columns(i).Width = 127
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.Automatic
                        'Case 39 'Exceed Approval Limit
                        '    dgSummary.Columns(i).HeaderText = "Ex"
                        '    dgSummary.Columns(i).Width = 0
                        '    If sHdrClaimAmtPer = "I" Then
                        '        dgSummary.Columns(i).Visible = False
                        '    Else
                        '        dgSummary.Columns(i).Visible = False
                        '    End If
                        '    dgSummary.Columns(i).ReadOnly = False
                    Case Else
                        dgSummary.Columns(i).HeaderText = ""
                        dgSummary.Columns(i).Width = 0
                        dgSummary.Columns(i).Visible = False
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                End Select
            Next i

            '20140218
            ''If (dgSummary.Columns.Count > 0) Then
            ''    'Move columns APV1, APV2,EXCE, and Claim Type from the back
            ''    dgSummary.Columns("cai_app1flg").DisplayIndex = 1
            ''    dgSummary.Columns("cai_app2flg").DisplayIndex = 2
            ''    'dgSummary.Columns("EXCE").DisplayIndex = 3
            ''End If

            'dgSummary.ContextMenuStrip = cms_CopyNPaste

            '''''''''''''''''''''''''''''Ship''''''''''''''''''''
        Else
            '''
            Dim i As Integer

            For i = 0 To dgSummary.Columns.Count - 1
                dgSummary.Columns(i).Resizable = DataGridViewTriState.True


                If dgSummary.Columns(i).ValueType.Name = "String" Then
                    dgSummary.Columns(i).DefaultCellStyle.DataSourceNullValue = ""
                ElseIf dgSummary.Columns(i).ValueType.Name = "Int32" Then
                    dgSummary.Columns(i).DefaultCellStyle.DataSourceNullValue = "0"
                    dgSummary.Columns(i).CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgSummary.Columns(i).DefaultCellStyle.Format = "##,0"
                ElseIf dgSummary.Columns(i).ValueType.Name = "Decimal" Then
                    dgSummary.Columns(i).DefaultCellStyle.DataSourceNullValue = "0.00"
                    dgSummary.Columns(i).CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgSummary.Columns(i).DefaultCellStyle.Format = "##,0.00"
                End If

                Select Case i
                    Case 0
                        dgSummary.Columns(i).HeaderText = "Del"
                        dgSummary.Columns(i).Width = 28
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                        'Case 1, 2, 4, 7, 8, 9, 10, 11, 12, 13, 14, 16, 17, 18, 21, 22, 23, 24, 25, 26, 28, _
                        '    32, 33, 34, 35, 36, 38, 39, 42, 43, 44
                        '    dgSummary.Columns(i).HeaderText = ""
                        '    dgSummary.Columns(i).Width = 0
                        '    dgSummary.Columns(i).Visible = False
                        '    dgSummary.Columns(i).ReadOnly = True
                        '    dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                        'Case 3 'Claim Seq
                        'dgSummary.Columns(i).HeaderText = "Seq"
                        'dgSummary.Columns(i).Width = 28
                        'dgSummary.Columns(i).ReadOnly = True
                        'dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.Automatic
                    Case 3
                        dgSummary.Columns(i).HeaderText = "Seq"
                        dgSummary.Columns(i).Width = 37
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White


                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.Automatic
                        dgSummary.Columns(i).Visible = True
                    Case 68 'Shipment No
                        dgSummary.Columns(i).HeaderText = "Ship No"
                        dgSummary.Columns(i).Width = 77
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.Automatic
                    Case 69 'Shipment Seq
                        dgSummary.Columns(i).HeaderText = ""
                        dgSummary.Columns(i).Width = 20
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                    Case 5 'SC No
                        dgSummary.Columns(i).HeaderText = "SC No"
                        dgSummary.Columns(i).Width = 72
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.Automatic
                    Case 6 'SC Seq
                        dgSummary.Columns(i).HeaderText = ""
                        dgSummary.Columns(i).Width = 20
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                        'Case 7 'PO No
                        '    dgSummary.Columns(i).HeaderText = "PO No"
                        '    dgSummary.Columns(i).Width = 72
                        '    dgSummary.Columns(i).ReadOnly = True
                        '    dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.Automatic
                        'Case 8 'PO Seq
                        '    dgSummary.Columns(i).HeaderText = ""
                        '    dgSummary.Columns(i).Width = 20
                        '    dgSummary.Columns(i).ReadOnly = True
                        '    dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                        'Case 9 'Job No
                        '    dgSummary.Columns(i).HeaderText = "Job No"
                        '    dgSummary.Columns(i).Width = 95
                        '    dgSummary.Columns(i).ReadOnly = True
                        '    dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.Automatic
                    Case 15 'Item No
                        dgSummary.Columns(i).HeaderText = "Item No"
                        dgSummary.Columns(i).Width = 105
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.Automatic
                        'Case 19 'Item Desc
                        'dgSummary.Columns(i).HeaderText = "Item Desc"
                        'dgSummary.Columns(i).Width = 105
                        'dgSummary.Columns(i).ReadOnly = True
                        'dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.Automatic
                    Case 19 ' 
                        dgSummary.Columns(i).HeaderText = "Item DSC"
                        dgSummary.Columns(i).Width = 130
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.Automatic
                    Case 20 'PV
                        dgSummary.Columns(i).HeaderText = "PV"
                        dgSummary.Columns(i).Width = 75
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.Automatic
                    Case 26 'SC UM
                        dgSummary.Columns(i).HeaderText = "SC UM"
                        dgSummary.Columns(i).Width = 55
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                    Case 27 'Order Qty
                        dgSummary.Columns(i).HeaderText = "Order Qty"
                        dgSummary.Columns(i).Width = 66
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                    Case 31 'Order Qty
                        dgSummary.Columns(i).HeaderText = "Remark"
                        dgSummary.Columns(i).Width = 99
                        If Not rs_CAORDDTL.Tables("result").Rows.Count = 0 Then

                            '''test
                            ' dgSummary.Columns(i).ReadOnly = False
                        End If

                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                        dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.LightBlue


                    Case 66 'Ship UM
                        dgSummary.Columns(i).HeaderText = "UM"
                        dgSummary.Columns(i).Width = 40
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                    Case 28 'Ship Qty
                        dgSummary.Columns(i).HeaderText = "Shipped Qty"
                        dgSummary.Columns(i).Width = 78
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                        'Case 33 'Original Claim Qty
                        '    dgSummary.Columns(i).HeaderText = "Org Qty"
                        '    dgSummary.Columns(i).Width = 60
                        '    If mode = cModeAdd Then
                        '        If sHdrClaimAmtPer = "C" Or sHdrClaimAmtPer = "I" Then
                        '            dgSummary.Columns(i).ReadOnly = True
                        '            dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        '        Else
                        '            dgSummary.Columns(i).ReadOnly = False
                        '            dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.Orange
                        '        End If
                        '    ElseIf mode = cModeUpd Then
                        '        If sHdrClaimAmtPer = "C" Or sHdrClaimAmtPer = "I" Then
                        '            dgSummary.Columns(i).ReadOnly = True
                        '            dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        '        Else
                        '            If sClaimStatus = "OPEN" Then
                        '                dgSummary.Columns(i).ReadOnly = False
                        '                dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.Orange
                        '            Else
                        '                dgSummary.Columns(i).ReadOnly = True
                        '                dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        '            End If
                        '        End If
                        '    Else 'mode = READ
                        '        dgSummary.Columns(i).ReadOnly = True
                        '        dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        '    End If
                        '    dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                        'Case 34 'Final Claim Qty
                        '    dgSummary.Columns(i).HeaderText = "Final Qty"
                        '    dgSummary.Columns(i).Width = 60
                        '    dgSummary.Columns(i).ReadOnly = True
                        '    dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                        '    'Case 35 'Remark
                        '    '    dgSummary.Columns(i).HeaderText = "Remark"
                        '    '    dgSummary.Columns(i).Width = 100
                        '    '    If mode = cModeRead Then
                        '    '        dgSummary.Columns(i).ReadOnly = True
                        '    '        dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        '    '    Else
                        '    '        dgSummary.Columns(i).ReadOnly = False
                        '    '        dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.Orange
                        '    '    End If
                        '    '    dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                        'Case 41 'Currency
                        '    dgSummary.Columns(i).HeaderText = "Curr"
                        '    dgSummary.Columns(i).Width = 50
                        '    dgSummary.Columns(i).ReadOnly = True
                        '    dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        '    dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                        'Case 44, 45
                        '    If i = 44 Then  'Orginal Claim Amt
                        '        dgSummary.Columns(i).HeaderText = "Org Amt"
                        '        dgSummary.Columns(i).Width = 60
                        '    ElseIf i = 45 Then 'Final Cliam Amt
                        '        dgSummary.Columns(i).HeaderText = "FinalAmt"
                        '        dgSummary.Columns(i).Width = 60
                        '    End If

                        '    If mode = cModeAdd Then
                        '        If sHdrClaimAmtPer = "C" Or sHdrClaimAmtPer = "I" Then
                        '            dgSummary.Columns(i).ReadOnly = True
                        '            dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        '        Else
                        '            dgSummary.Columns(i).ReadOnly = False
                        '            dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.Orange
                        '        End If
                        '    ElseIf mode = cModeUpd Then
                        '        If sHdrClaimAmtPer = "C" Or sHdrClaimAmtPer = "I" Then
                        '            dgSummary.Columns(i).ReadOnly = True
                        '            dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        '        Else
                        '            If sClaimStatus = "OPEN" Then
                        '                dgSummary.Columns(i).ReadOnly = False
                        '                dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.Orange
                        '            Else
                        '                dgSummary.Columns(i).ReadOnly = True
                        '                dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        '            End If
                        '        End If
                        '    Else 'mode = READ
                        '        dgSummary.Columns(i).ReadOnly = True
                        '        dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        '    End If
                        '    dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                        'Case 46, 48, 50 'Claim to Currency
                        '    dgSummary.Columns(i).HeaderText = "Curr"
                        '    dgSummary.Columns(i).Width = 50
                        '    dgSummary.Columns(i).ReadOnly = True
                        '    dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        '    dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                        '    'Case 47, 49, 51 'Claim to Amt
                        'Case 47, 49
                        '    If i = 47 Then
                        '        dgSummary.Columns(i).HeaderText = "Ins Amt"
                        '        dgSummary.Columns(i).Width = 60
                        '    ElseIf i = 49 Then
                        '        dgSummary.Columns(i).HeaderText = "Vdr Amt"
                        '        dgSummary.Columns(i).Width = 60
                        '    End If

                        '    If mode = cModeAdd Then
                        '        If sHdrClaimAmtPer = "C" Or sHdrClaimAmtPer = "I" Then
                        '            dgSummary.Columns(i).ReadOnly = True
                        '            dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        '        Else
                        '            dgSummary.Columns(i).ReadOnly = False
                        '            dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.Orange
                        '        End If
                        '    ElseIf mode = cModeUpd Then
                        '        If sHdrClaimAmtPer = "C" Or sHdrClaimAmtPer = "I" Then
                        '            dgSummary.Columns(i).ReadOnly = True
                        '            dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        '        Else
                        '            If sClaimStatus = "OPEN" Or sClaimStatus = "APV1a" Then
                        '                dgSummary.Columns(i).ReadOnly = False
                        '                dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.Orange
                        '            Else
                        '                dgSummary.Columns(i).ReadOnly = True
                        '                dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        '            End If
                        '        End If
                        '    Else 'mode = READ
                        '        dgSummary.Columns(i).ReadOnly = True
                        '        dgSummary.Columns(i).CellTemplate.Style.BackColor = Color.White
                        '    End If

                        '    dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                        'Case 51 'Claim to Amt for HKO
                        '    dgSummary.Columns(i).HeaderText = "HKO Amt"
                        '    dgSummary.Columns(i).Width = 70
                        '    dgSummary.Columns(i).ReadOnly = True
                        '    dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                    Case Else
                        dgSummary.Columns(i).HeaderText = ""
                        dgSummary.Columns(i).Width = 0
                        dgSummary.Columns(i).Visible = False
                        dgSummary.Columns(i).ReadOnly = True
                        dgSummary.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                End Select
            Next i

            'dgSummary.ContextMenuStrip = cms_CopyNPaste
        End If
        dgSummary.AllowUserToAddRows = False
        dgSummary.RowHeadersWidth = 25
        dgSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgSummary.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgSummary.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText

        '''20140312
        '''
        ''If rbViewOn_I.Checked Then
        ''    dgSummary.Columns(8).CellTemplate.Style.BackColor = Color.LightBlue
        ''Else
        ''    dgSummary.Columns(31).CellTemplate.Style.BackColor = Color.LightBlue
        ''End If
        ''dgSummary.Refresh()

    End Sub

    Private Sub format_Approval(ByVal seq As Integer)

        ' ''20131111tmp
        ''Exit Sub

        ''If sHdrClaimAmtPer = "C" Then
        ''    If mode = cModeAdd Then
        ''        Me.gb_Hdr_ClaimAmt.Enabled = True
        ''        Me.gb_Hdr_ClaimTo.Enabled = True

        ''        Me.cbo_Hdr_ClaimAmtCurrency.Enabled = True
        ''        Me.txt_Hdr_OrgClaimAmt.Enabled = True
        ''        Me.txt_Hdr_FinalClaimAmt.Enabled = True

        ''        Me.cbo_Hdr_ClaimToInsAmtCurrency.Enabled = False
        ''        Me.txt_Hdr_ClaimToInsAmt.Enabled = False
        ''        Me.cbo_Hdr_ClaimToVNAmtCurrency.Enabled = False
        ''        Me.txt_Hdr_ClaimToVNAmt.Enabled = False

        ''        If txt_Hdr_FinalClaimAmt.Text <> "0.00" Or chkDelete.Checked Then
        ''            Me.cbo_Hdr_ClaimAmtCurrency.Enabled = False
        ''        End If

        ''        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_org") > 0 _
        ''            Or rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_final") > 0 _
        ''            And chkDelete.Checked = False Then
        ''            Me.txt_Hdr_ClaimToInsAmt.Enabled = True
        ''            Me.txt_Hdr_ClaimToVNAmt.Enabled = True
        ''        End If
        ''    ElseIf mode = cModeUpd Then
        ''        Me.gb_Hdr_ClaimAmt.Enabled = True
        ''        Me.gb_Hdr_ClaimTo.Enabled = True

        ''        If sClaimStatus = "OPEN" Then
        ''            Me.cbo_Hdr_ClaimAmtCurrency.Enabled = True
        ''            Me.txt_Hdr_OrgClaimAmt.Enabled = True
        ''            Me.txt_Hdr_FinalClaimAmt.Enabled = True
        ''        Else
        ''            Me.cbo_Hdr_ClaimAmtCurrency.Enabled = False
        ''            Me.txt_Hdr_OrgClaimAmt.Enabled = False
        ''            Me.txt_Hdr_FinalClaimAmt.Enabled = False
        ''        End If

        ''        If txt_Hdr_FinalClaimAmt.Text <> "0.00" Or chkDelete.Checked Then
        ''            Me.cbo_Hdr_ClaimAmtCurrency.Enabled = False
        ''        End If

        ''        If sClaimStatus = "OPEN" Or sClaimStatus = "APV1a" Then
        ''            Me.cbo_Hdr_ClaimToInsAmtCurrency.Enabled = False
        ''            Me.txt_Hdr_ClaimToInsAmt.Enabled = True
        ''            Me.cbo_Hdr_ClaimToVNAmtCurrency.Enabled = False
        ''            Me.txt_Hdr_ClaimToVNAmt.Enabled = True
        ''        Else
        ''            Me.cbo_Hdr_ClaimToInsAmtCurrency.Enabled = False
        ''            Me.txt_Hdr_ClaimToInsAmt.Enabled = False
        ''            Me.cbo_Hdr_ClaimToVNAmtCurrency.Enabled = False
        ''            Me.txt_Hdr_ClaimToVNAmt.Enabled = False
        ''        End If
        ''    End If

        ''    'display approval button
        ''    If ApprovalRights = True Then
        ''        check_ApprovalAction(0)
        ''    End If

        ''    'Me.gb_Dtl_ClaimAmt.Enabled = False
        ''    'Me.gb_Dtl_ClaimTo.Enabled = False
        ''    Me.txt_Dtl_OrgClaimQty.Enabled = False
        ''    Me.cbo_Dtl_ClaimAmtCurrency.Enabled = False
        ''    Me.txt_Dtl_OrgClaimAmt.Enabled = False
        ''    Me.txt_Dtl_FinalClaimAmt.Enabled = False

        ''    Me.cbo_Dtl_ClaimToInsAmtCurrency.Enabled = False
        ''    Me.txt_Dtl_ClaimToInsAmt.Enabled = False
        ''    Me.cbo_Dtl_ClaimToVNAmtCurrency.Enabled = False
        ''    Me.txt_Dtl_ClaimToVNAmt.Enabled = False
        ''Else
        ''    If mode = cModeAdd Then
        ''        ' ''Me.gb_Dtl_ClaimAmt.Enabled = True
        ''        ' ''Me.gb_Dtl_ClaimTo.Enabled = True

        ''        ' ''Me.txt_Dtl_OrgClaimQty.Enabled = True
        ''        ' ''Me.cbo_Dtl_ClaimAmtCurrency.Enabled = True
        ''        ' ''Me.txt_Dtl_OrgClaimAmt.Enabled = True
        ''        ' ''Me.txt_Dtl_FinalClaimAmt.Enabled = True

        ''        ''Me.cbo_Dtl_ClaimToInsAmtCurrency.Enabled = False
        ''        ''Me.txt_Dtl_ClaimToInsAmt.Enabled = False
        ''        ''Me.cbo_Dtl_ClaimToVNAmtCurrency.Enabled = False
        ''        ''Me.txt_Dtl_ClaimToVNAmt.Enabled = False

        ''        If Val(txt_Dtl_OrgClaimTtlAmt.Text) > 0 Or Val(txt_Dtl_FinalClaimTtlAmt.Text) > 0 Then
        ''            Me.txt_Dtl_ClaimToInsAmt.Enabled = True
        ''            Me.txt_Dtl_ClaimToVNAmt.Enabled = True
        ''        End If

        ''        If txt_Dtl_FinalClaimTtlAmt.Text <> "0.00" Or cb_Dtl_APV1.Checked = True Or chkDelete.Checked Then
        ''            Me.cbo_Dtl_ClaimAmtCurrency.Enabled = False
        ''        End If

        ''        If sHdrClaimAmtPer = "I" Then
        ''            Me.txt_Dtl_OrgClaimQty.Enabled = False
        ''        End If

        ''        If sHdrClaimAmtPer = "I" And rbViewOn_S.Checked Or _
        ''            sHdrClaimAmtPer = "S" And rbViewOn_I.Checked Then
        ''            Me.gb_Dtl_ClaimAmt.Enabled = False
        ''            Me.gb_Dtl_ClaimTo.Enabled = False

        ''            Me.txt_Dtl_OrgClaimQty.Enabled = False
        ''            Me.cbo_Dtl_ClaimAmtCurrency.Enabled = False
        ''            Me.txt_Dtl_OrgClaimAmt.Enabled = False
        ''            Me.txt_Dtl_FinalClaimAmt.Enabled = False

        ''            Me.cbo_Dtl_ClaimToInsAmtCurrency.Enabled = False
        ''            Me.txt_Dtl_ClaimToInsAmt.Enabled = False
        ''            Me.cbo_Dtl_ClaimToVNAmtCurrency.Enabled = False
        ''            Me.txt_Dtl_ClaimToVNAmt.Enabled = False
        ''        End If
        ''    ElseIf mode = cModeUpd Then
        ''        If sHdrClaimAmtPer = "I" And rbViewOn_I.Checked = True Or _
        ''            sHdrClaimAmtPer = "S" And rbViewOn_S.Checked = True Then
        ''            Me.gb_Dtl_ClaimAmt.Enabled = True
        ''            Me.gb_Dtl_ClaimTo.Enabled = True

        ''            If sClaimStatus = "OPEN" And cb_Dtl_APV1.Checked = False Then
        ''                If txt_Dtl_FinalClaimTtlAmt.Text <> "0.00" Or chkDelete.Checked Then
        ''                    Me.cbo_Dtl_ClaimAmtCurrency.Enabled = False
        ''                Else
        ''                    Me.cbo_Dtl_ClaimAmtCurrency.Enabled = True
        ''                End If

        ''                If chkDelete.Checked = False Then
        ''                    Me.txt_Dtl_OrgClaimAmt.Enabled = True
        ''                    Me.txt_Dtl_FinalClaimAmt.Enabled = True
        ''                    Me.txt_Dtl_OrgClaimQty.Enabled = True
        ''                End If
        ''            Else
        ''                If txt_Dtl_FinalClaimTtlAmt.Text <> "0.00" Or cb_Dtl_APV1.Checked = True Or chkDelete.Checked Then
        ''                    cbo_Dtl_ClaimAmtCurrency.Enabled = False
        ''                End If
        ''                Me.txt_Dtl_OrgClaimAmt.Enabled = False
        ''                Me.txt_Dtl_FinalClaimAmt.Enabled = False

        ''                Me.txt_Dtl_OrgClaimQty.Enabled = False
        ''            End If

        ''            If (sClaimStatus = "OPEN" Or sClaimStatus = "APV1a") And cb_Dtl_APV2.Checked = False Then
        ''                Me.cbo_Dtl_ClaimToInsAmtCurrency.Enabled = False
        ''                Me.txt_Dtl_ClaimToInsAmt.Enabled = True
        ''                Me.cbo_Dtl_ClaimToVNAmtCurrency.Enabled = False
        ''                Me.txt_Dtl_ClaimToVNAmt.Enabled = True
        ''            Else
        ''                Me.cbo_Dtl_ClaimToInsAmtCurrency.Enabled = False
        ''                Me.txt_Dtl_ClaimToInsAmt.Enabled = False
        ''                Me.cbo_Dtl_ClaimToVNAmtCurrency.Enabled = False
        ''                Me.txt_Dtl_ClaimToVNAmt.Enabled = False
        ''            End If

        ''            If sHdrClaimAmtPer = "S" And rbViewOn_S.Checked = True And txt_Dtl_FinalClaimAmt.Enabled = True Then
        ''                txt_Dtl_OrgClaimQty.Enabled = True
        ''            Else
        ''                txt_Dtl_OrgClaimQty.Enabled = False
        ''            End If
        ''        Else
        ''            Me.gb_Dtl_ClaimAmt.Enabled = False
        ''            Me.gb_Dtl_ClaimTo.Enabled = False

        ''            Me.cbo_Dtl_ClaimAmtCurrency.Enabled = False
        ''            Me.txt_Dtl_OrgClaimAmt.Enabled = False
        ''            Me.txt_Dtl_FinalClaimAmt.Enabled = False
        ''            Me.txt_Dtl_OrgClaimQty.Enabled = False

        ''            Me.cbo_Dtl_ClaimToInsAmtCurrency.Enabled = False
        ''            Me.txt_Dtl_ClaimToInsAmt.Enabled = False
        ''            Me.cbo_Dtl_ClaimToVNAmtCurrency.Enabled = False
        ''            Me.txt_Dtl_ClaimToVNAmt.Enabled = False
        ''        End If
        ''    End If

        ''    'display approval button
        ''    If ApprovalRights = True Then
        ''        check_ApprovalAction(sReadingSeq_Item)
        ''    End If

        ''    'Me.gb_Hdr_ClaimAmt.Enabled = False
        ''    'Me.gb_Hdr_ClaimTo.Enabled = False
        ''    Me.cbo_Hdr_ClaimAmtCurrency.Enabled = False
        ''    Me.txt_Hdr_OrgClaimAmt.Enabled = False
        ''    Me.txt_Hdr_FinalClaimAmt.Enabled = False

        ''    Me.cbo_Hdr_ClaimToInsAmtCurrency.Enabled = False
        ''    Me.txt_Hdr_ClaimToInsAmt.Enabled = False
        ''    Me.cbo_Hdr_ClaimToVNAmtCurrency.Enabled = False
        ''    Me.txt_Hdr_ClaimToVNAmt.Enabled = False

        ''    'If m = "HEADER" Then
        ''    '    If mode = cModeAdd Then
        ''    '        If ClaimAmt_Header = False And rs_CAORDDTL.Tables("RESULT").Rows.Count > 0 _
        ''    '            And (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_org") > 0 _
        ''    '            Or rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_final") > 0) Then
        ''    '            Me.gb_Hdr_ClaimAmt.Enabled = True
        ''    '            Me.cbo_Hdr_ClaimAmtCurrency.Enabled = False
        ''    '            Me.txt_Hdr_OrgClaimAmt.Enabled = False
        ''    '            Me.txt_Hdr_FinalClaimAmt.Enabled = False

        ''    '            Me.gb_Hdr_ClaimTo.Enabled = True
        ''    '            Me.cbo_Hdr_ClaimToInsAmtCurrency.Enabled = False
        ''    '            Me.txt_Hdr_ClaimToInsAmt.Enabled = False
        ''    '            Me.cbo_Hdr_ClaimToVNAmtCurrency.Enabled = False
        ''    '            Me.txt_Hdr_ClaimToVNAmt.Enabled = False
        ''    '            'Me.cbo_Hdr_ClaimToEVNAmtCurrency.Enabled = False
        ''    '            'Me.txt_Hdr_ClaimToEVNAmt.Enabled = False
        ''    '        Else
        ''    '            Me.gb_Hdr_ClaimAmt.Enabled = True
        ''    '            Me.cbo_Hdr_ClaimAmtCurrency.Enabled = True
        ''    '            Me.txt_Hdr_OrgClaimAmt.Enabled = True
        ''    '            Me.txt_Hdr_FinalClaimAmt.Enabled = True

        ''    '            Me.gb_Hdr_ClaimTo.Enabled = True
        ''    '            Me.cbo_Hdr_ClaimToInsAmtCurrency.Enabled = True
        ''    '            Me.txt_Hdr_ClaimToInsAmt.Enabled = True
        ''    '            Me.cbo_Hdr_ClaimToVNAmtCurrency.Enabled = True
        ''    '            Me.txt_Hdr_ClaimToVNAmt.Enabled = True
        ''    '            'Me.cbo_Hdr_ClaimToEVNAmtCurrency.Enabled = True
        ''    '            'Me.txt_Hdr_ClaimToEVNAmt.Enabled = True
        ''    '        End If

        ''    '        'display approval button
        ''    '        If ApprovalRights = True Then
        ''    '            Call check_ApprovalAction("Hdr", 0)
        ''    '        End If
        ''    '    ElseIf mode = cModeUpd Then
        ''    '        If check_ClaimAmt_Header() = "DETAIL" Then
        ''    '            Me.gb_Hdr_ClaimAmt.Enabled = True
        ''    '            Me.cbo_Hdr_ClaimAmtCurrency.Enabled = False
        ''    '            Me.txt_Hdr_OrgClaimAmt.Enabled = False
        ''    '            Me.txt_Hdr_FinalClaimAmt.Enabled = False

        ''    '            Me.gb_Hdr_ClaimTo.Enabled = True
        ''    '            Me.cbo_Hdr_ClaimToInsAmtCurrency.Enabled = False
        ''    '            Me.txt_Hdr_ClaimToInsAmt.Enabled = False
        ''    '            Me.cbo_Hdr_ClaimToVNAmtCurrency.Enabled = False
        ''    '            Me.txt_Hdr_ClaimToVNAmt.Enabled = False
        ''    '            'Me.cbo_Hdr_ClaimToEVNAmtCurrency.Enabled = False
        ''    '            'Me.txt_Hdr_ClaimToEVNAmt.Enabled = False
        ''    '        Else 'HEADER or BOTH
        ''    '            Me.gb_Hdr_ClaimAmt.Enabled = True

        ''    '            If sClaimStatus = "OPEN" Then
        ''    '                Me.cbo_Hdr_ClaimAmtCurrency.Enabled = True
        ''    '                Me.txt_Hdr_OrgClaimAmt.Enabled = True
        ''    '                Me.txt_Hdr_FinalClaimAmt.Enabled = True
        ''    '            Else
        ''    '                Me.cbo_Hdr_ClaimAmtCurrency.Enabled = False
        ''    '                Me.txt_Hdr_OrgClaimAmt.Enabled = False
        ''    '                Me.txt_Hdr_FinalClaimAmt.Enabled = False
        ''    '            End If

        ''    '            Me.gb_Hdr_ClaimTo.Enabled = True

        ''    '            If sClaimStatus = "OPEN" Or sClaimStatus = "APV1a" Then
        ''    '                Me.cbo_Hdr_ClaimToInsAmtCurrency.Enabled = True
        ''    '                Me.txt_Hdr_ClaimToInsAmt.Enabled = True
        ''    '                Me.cbo_Hdr_ClaimToVNAmtCurrency.Enabled = True
        ''    '                Me.txt_Hdr_ClaimToVNAmt.Enabled = True
        ''    '                'Me.cbo_Hdr_ClaimToEVNAmtCurrency.Enabled = True
        ''    '                'Me.txt_Hdr_ClaimToEVNAmt.Enabled = True
        ''    '            Else
        ''    '                Me.cbo_Hdr_ClaimToInsAmtCurrency.Enabled = False
        ''    '                Me.txt_Hdr_ClaimToInsAmt.Enabled = False
        ''    '                Me.cbo_Hdr_ClaimToVNAmtCurrency.Enabled = False
        ''    '                Me.txt_Hdr_ClaimToVNAmt.Enabled = False
        ''    '                'Me.cbo_Hdr_ClaimToEVNAmtCurrency.Enabled = False
        ''    '                'Me.txt_Hdr_ClaimToEVNAmt.Enabled = False
        ''    '            End If
        ''    '        End If

        ''    '        'display approval button
        ''    '        If ApprovalRights = True Then
        ''    '            Call check_ApprovalAction("Hdr", 0)
        ''    '        End If
        ''    '    End If
        ''    'Else 'm = DETAIL
        ''    '    If mode = cModeAdd Then
        ''    '        If ClaimAmt_Header = True Then
        ''    '            Me.gb_Dtl_ClaimAmt.Enabled = True
        ''    '            Me.cbo_Dtl_ClaimAmtCurrency.Enabled = False
        ''    '            Me.txt_Dtl_OrgClaimAmt.Enabled = False
        ''    '            Me.txt_Dtl_FinalClaimAmt.Enabled = False

        ''    '            Me.txt_Dtl_OrgClaimQty.Enabled = False

        ''    '            Me.gb_Dtl_ClaimTo.Enabled = True
        ''    '            Me.cbo_Dtl_ClaimToInsAmtCurrency.Enabled = False
        ''    '            Me.txt_Dtl_ClaimToInsAmt.Enabled = False
        ''    '            Me.cbo_Dtl_ClaimToVNAmtCurrency.Enabled = False
        ''    '            Me.txt_Dtl_ClaimToVNAmt.Enabled = False
        ''    '        Else
        ''    '            Me.gb_Dtl_ClaimAmt.Enabled = True
        ''    '            'Me.cbo_Dtl_ClaimAmtCurrency.Enabled = True
        ''    '            If txt_Dtl_FinalClaimQtyAmt.Text = "0.00" And cb_Dtl_APV1.Checked = False Then
        ''    '                cbo_Dtl_ClaimAmtCurrency.Enabled = True
        ''    '            End If
        ''    '            Me.txt_Dtl_OrgClaimAmt.Enabled = True
        ''    '            Me.txt_Dtl_FinalClaimAmt.Enabled = True

        ''    '            Me.txt_Dtl_OrgClaimQty.Enabled = True

        ''    '            Me.gb_Dtl_ClaimTo.Enabled = True
        ''    '            Me.cbo_Dtl_ClaimToInsAmtCurrency.Enabled = True
        ''    '            Me.txt_Dtl_ClaimToInsAmt.Enabled = True
        ''    '            Me.cbo_Dtl_ClaimToVNAmtCurrency.Enabled = True
        ''    '            Me.txt_Dtl_ClaimToVNAmt.Enabled = True
        ''    '        End If

        ''    '        'display approval button
        ''    '        If ApprovalRights = True Then
        ''    '            Call check_ApprovalAction("Dtl", dtlseq)
        ''    '        End If
        ''    '    ElseIf mode = cModeUpd Then
        ''    '        If check_ClaimAmt_Header() = "HEADER" Then
        ''    '            Me.gb_Dtl_ClaimAmt.Enabled = True
        ''    '            Me.cbo_Dtl_ClaimAmtCurrency.Enabled = False
        ''    '            Me.txt_Dtl_OrgClaimAmt.Enabled = False
        ''    '            Me.txt_Dtl_FinalClaimAmt.Enabled = False

        ''    '            Me.txt_Dtl_OrgClaimQty.Enabled = False

        ''    '            Me.gb_Dtl_ClaimTo.Enabled = True
        ''    '            Me.cbo_Dtl_ClaimToInsAmtCurrency.Enabled = False
        ''    '            Me.txt_Dtl_ClaimToInsAmt.Enabled = False
        ''    '            Me.cbo_Dtl_ClaimToVNAmtCurrency.Enabled = False
        ''    '            Me.txt_Dtl_ClaimToVNAmt.Enabled = False
        ''    '        Else 'HEADER or BOTH
        ''    '            Me.gb_Dtl_ClaimAmt.Enabled = True

        ''    '            If sClaimStatus = "OPEN" And cb_Dtl_APV1.Checked = False Then
        ''    '                Me.cbo_Dtl_ClaimAmtCurrency.Enabled = True
        ''    '                Me.txt_Dtl_OrgClaimAmt.Enabled = True
        ''    '                Me.txt_Dtl_FinalClaimAmt.Enabled = True
        ''    '                Me.txt_Dtl_OrgClaimQty.Enabled = True
        ''    '            Else
        ''    '                'Me.cbo_Dtl_ClaimAmtCurrency.Enabled = False
        ''    '                If txt_Dtl_FinalClaimQtyAmt.Text <> "0.00" Or cb_Dtl_APV1.Checked = True Then
        ''    '                    cbo_Dtl_ClaimAmtCurrency.Enabled = False
        ''    '                End If
        ''    '                Me.txt_Dtl_OrgClaimAmt.Enabled = False
        ''    '                Me.txt_Dtl_FinalClaimAmt.Enabled = False

        ''    '                Me.txt_Dtl_OrgClaimQty.Enabled = False
        ''    '            End If

        ''    '            Me.gb_Dtl_ClaimTo.Enabled = True

        ''    '            If ((sClaimStatus = "OPEN" Or sClaimStatus = "APV1a") And cb_Dtl_APV2.Checked = False) Then
        ''    '                Me.cbo_Dtl_ClaimToInsAmtCurrency.Enabled = True
        ''    '                Me.txt_Dtl_ClaimToInsAmt.Enabled = True
        ''    '                Me.cbo_Dtl_ClaimToVNAmtCurrency.Enabled = True
        ''    '                Me.txt_Dtl_ClaimToVNAmt.Enabled = True
        ''    '            Else
        ''    '                Me.cbo_Dtl_ClaimToInsAmtCurrency.Enabled = False
        ''    '                Me.txt_Dtl_ClaimToInsAmt.Enabled = False
        ''    '                Me.cbo_Dtl_ClaimToVNAmtCurrency.Enabled = False
        ''    '                Me.txt_Dtl_ClaimToVNAmt.Enabled = False
        ''    '            End If
        ''    '        End If

        ''    '        'display approval button
        ''    '        If ApprovalRights = True Then
        ''    '            Call check_ApprovalAction("Dtl", dtlseq)
        ''    '        End If
        ''    '    End If
        ''    'End If
        ''End If
    End Sub

    Private Sub check_ApprovalAction(ByVal dtlseq As Integer)
        'Dim final_claim_amt_c As Decimal
        'Dim remain_claim_amt_c As Decimal

        'Dim final_claim_limit_currency_c As String
        'Dim final_claim_amt_currency_c As String

        'Dim exrate_c As Decimal

        'Dim bNeedCheck As Boolean = True

        ''If btcCLM00001.SelectedIndex = 0 Then
        ''chkapv1a.Enabled = False
        ''chkapv1b.Enabled = False
        ''lbl_Hdr_ExceedAppLmt.Visible = True

        'final_claim_limit_currency_c = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salcur")
        'final_claim_amt_currency_c = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cacur")
        'exrate_c = getExchangeRate(final_claim_amt_currency_c, final_claim_limit_currency_c, "BuyRate")

        'final_claim_amt_c = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_final")
        'remain_claim_amt_c = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caremamt")

        'If final_claim_amt_c * getExchangeRate(final_claim_limit_currency_c, "USD", "BuyRate") < 2000 Then
        '    bNeedCheck = False
        'End If

        'If bNeedCheck Then
        '    If SuperApprovalRights = True Or final_claim_amt_c * exrate_c <= remain_claim_amt_c Then
        '        If sClaimStatus = "OPEN" Then
        '            If final_claim_amt_c <> 0 Then
        '                gb_Hdr_ClaimAmt.Enabled = True
        '                chkapv1a.Enabled = True
        '            Else
        '                chkapv1a.Enabled = False
        '            End If
        '        End If

        '        If sClaimStatus = "APV1a" Then
        '            If final_claim_amt_c <> 0 Then
        '                gb_Hdr_ClaimTo.Enabled = True
        '                chkapv1b.Enabled = True
        '            Else
        '                chkapv1b.Enabled = False
        '            End If
        '        Else
        '            chkapv1b.Enabled = False
        '        End If

        '        lbl_Hdr_ExceedAppLmt.Visible = False
        '    Else
        '        chkapv1a.Enabled = False
        '        chkapv1b.Enabled = False

        '        If final_claim_amt_c <> 0 Then
        '            lbl_Hdr_ExceedAppLmt.Visible = True
        '        Else
        '            lbl_Hdr_ExceedAppLmt.Visible = False
        '        End If
        '    End If

        '    'ElseIf btcCLM00001.SelectedIndex = 2 And rbViewOn_I.Checked Then
        '    If sHdrClaimAmtPer = "I" Or sHdrClaimAmtPer = "S" Then
        '        If rbViewOn_I.Checked Then
        '            Dim final_claim_amt As Decimal
        '            Dim remain_claim_amt As Decimal

        '            Dim final_claim_limit_currency As String
        '            Dim final_claim_amt_currency As String

        '            Dim exrate As Decimal

        '            Dim dtlRow As Integer
        '            Dim i As Integer

        '            dtlRow = 0

        '            For i = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
        '                If dtlseq = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caordseq") Then
        '                    dtlRow = i
        '                    Exit For
        '                End If
        '            Next i

        '            cb_Dtl_APV1.Visible = True
        '            cb_Dtl_APV2.Visible = True
        '            lbl_Dtl_ExceedAppLmt.Visible = False
        '            'cb_Dtl_APV1.Enabled = False
        '            'cb_Dtl_APV2.Enabled = False
        '            'lbl_Dtl_ExceedAppLmt.Visible = True

        '            final_claim_limit_currency = rs_CAORDITM.Tables("RESULT").Rows(dtlRow).Item("cai_salcur")
        '            final_claim_amt_currency = rs_CAORDITM.Tables("RESULT").Rows(dtlRow).Item("cai_cacur")
        '            exrate = getExchangeRate(final_claim_amt_currency, final_claim_limit_currency, "BuyRate")

        '            final_claim_amt = rs_CAORDITM.Tables("RESULT").Rows(dtlRow).Item("cai_caamt_final")
        '            remain_claim_amt = rs_CAORDITM.Tables("RESULT").Rows(dtlRow).Item("cai_caremamt")

        '            If SuperApprovalRights = True Or remain_claim_amt = 0 Or _
        '                final_claim_amt * exrate <= remain_claim_amt Then
        '                If rs_CAORDITM.Tables("RESULT").Rows(dtlRow).Item("cai_app1flg").ToString.Trim = "" Then
        '                    If final_claim_amt <> 0 Then
        '                        gb_Dtl_ClaimAmt.Enabled = True
        '                        cb_Dtl_APV1.Enabled = True
        '                    Else
        '                        cb_Dtl_APV1.Enabled = False
        '                    End If
        '                End If

        '                If rs_CAORDITM.Tables("RESULT").Rows(dtlRow).Item("cai_app1flg").ToString.Trim = "Y" Then
        '                    If rs_CAORDITM.Tables("RESULT").Rows(dtlRow).Item("cai_app2flg").ToString.Trim = "N" Then
        '                        If final_claim_amt <> 0 Then
        '                            gb_Dtl_ClaimAmt.Enabled = True
        '                            cb_Dtl_APV1.Enabled = True
        '                        Else
        '                            cb_Dtl_APV1.Enabled = False
        '                        End If
        '                    End If
        '                End If

        '                If rs_CAORDITM.Tables("RESULT").Rows(dtlRow).Item("cai_app1flg").ToString.Trim = "Y" And _
        '                    (rs_CAORDITM.Tables("RESULT").Rows(dtlRow).Item("cai_app2flg").ToString.Trim = "" Or _
        '                    rs_CAORDITM.Tables("RESULT").Rows(dtlRow).Item("cai_app2flg").ToString.Trim = "N") Then
        '                    If final_claim_amt <> 0 Then
        '                        gb_Dtl_ClaimTo.Enabled = True
        '                        cb_Dtl_APV2.Enabled = True
        '                    Else
        '                        cb_Dtl_APV2.Enabled = False
        '                    End If
        '                Else
        '                    cb_Dtl_APV2.Enabled = False
        '                End If

        '                lbl_Dtl_ExceedAppLmt.Visible = False
        '            Else
        '                cb_Dtl_APV1.Enabled = False
        '                cb_Dtl_APV2.Enabled = False

        '                If final_claim_amt <> 0 Then
        '                    lbl_Dtl_ExceedAppLmt.Visible = True
        '                Else
        '                    lbl_Dtl_ExceedAppLmt.Visible = False
        '                End If
        '            End If
        '        Else
        '            cb_Dtl_APV1.Visible = False
        '            cb_Dtl_APV2.Visible = False
        '            lbl_Dtl_ExceedAppLmt.Visible = False
        '        End If
        '    Else
        '        cb_Dtl_APV1.Visible = False
        '        cb_Dtl_APV2.Visible = False
        '        lbl_Dtl_ExceedAppLmt.Visible = False
        '    End If
        'Else
        '    If sClaimStatus = "OPEN" Then
        '        If final_claim_amt_c <> 0 Then
        '            gb_Hdr_ClaimAmt.Enabled = True
        '            chkapv1a.Enabled = True
        '        Else
        '            chkapv1a.Enabled = False
        '        End If
        '    End If

        '    If sClaimStatus = "APV1a" Then
        '        If final_claim_amt_c <> 0 Then
        '            gb_Hdr_ClaimTo.Enabled = True
        '            chkapv1b.Enabled = True
        '        Else
        '            chkapv1b.Enabled = False
        '        End If
        '    Else
        '        chkapv1b.Enabled = False
        '    End If

        '    lbl_Hdr_ExceedAppLmt.Visible = False

        '    cb_Dtl_APV1.Visible = False
        '    cb_Dtl_APV2.Visible = False
        '    lbl_Dtl_ExceedAppLmt.Visible = False
        'End If
    End Sub

    Private Sub mmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        If checkFocus(Me) Then Exit Sub
        If rs_CAORDDTL.Tables("result").Rows.Count = 0 Then

            'If rbClaimAmtPer_I.Checked = True Or rbClaimAmtPer_S.Checked = True Then
            '    MsgBox("The Item/ship reference should not be empty!")
            '    btcCLM00001.SelectedIndex = 2

            '    Exit Sub
            'End If

            If MsgBox("There is no Item/Ship Reference. Do you still want to save?", vbYesNo) = vbYes Then
                Call save_click()
            Else
                Exit Sub
            End If

        Else

            Call save_click()
        End If


    End Sub

    Private Function check_CAORDHDR_CAORDITM_CAORDDTL() As Boolean
        If rs_CAORDHDR.Tables.Count = 0 Then
            MsgBox("Error on loading check_CAORDHDR_CAORDITM_CAORDDTL rs_CAORDHDR.Tables.Count = 0")
            check_CAORDHDR_CAORDITM_CAORDDTL = False
            Exit Function
        ElseIf rs_CAORDITM.Tables.Count = 0 Then
            ''may need a checking for zero ..
            '            MsgBox("Error on loading check_CAORDHDR_CAORDITM_CAORDDTL rs_CAORDITM.Tables.Count = 0")

            check_CAORDHDR_CAORDITM_CAORDDTL = False
            Exit Function
        ElseIf rs_CAORDDTL.Tables.Count = 0 Then
            '           MsgBox("Error on loading check_CAORDHDR_CAORDITM_CAORDDTL rs_CAORDDTL.Tables.Count = 0")

            check_CAORDHDR_CAORDITM_CAORDDTL = False
            Exit Function
        End If

        Dim i As Integer

        If rs_CAORDDTL.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
                'if going to delete it, no checking required
                If Not rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_del") = "Y" Then
                    'check Claim Types
                    'sClaimTypeDTL = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_clatyp").ToString.Trim
                    'If sClaimTypeHDR <> sClaimTypeDTL Then
                    '    If MsgBox("Claim Type in Seq No " & rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caordseq").ToString.Trim & _
                    '              " is not as same as in Header, Are you sure?", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                    '        cbo_Dtl_ClaimType.Select()
                    '        check_CAORDHDR_CAORDDTL = False
                    '        Exit Function
                    '    End If
                    'End If

                    'check Shipment No claimed by other claims
                    Dim shpno As String
                    Dim shpseq As Integer
                    Dim creusr As String
                    'shpno = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_shpno")
                    ' shpseq = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_shpseq")
                    creusr = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_creusr")

                    If mode = cModeAdd Or creusr = "~*ADD*~" Or creusr = "~*NEW*~" Then
                        Dim dr() As DataRow

                        dr = rs_CAORDDTL.Tables("RESULT").Select("cad_shpno = '" & shpno & "' and cad_shpseq = " & shpseq)
                        '''dr = rs_CAORDDTL_ALL.Tables("RESULT").Select("cad_shpno = '" & shpno & "' and cad_shpseq = " & shpseq)
                        If dr.Length > 0 Then
                            '''???
                            'If MsgBox("Shipment: " & shpno & "-" & shpseq & " already claimed by other claims, Are you sure?", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                            '    cbDel.Focus()
                            '    check_CAORDHDR_CAORDITM_CAORDDTL = False
                            '    Exit Function
                            'End If
                        End If
                    End If
                End If
            Next i
        End If

        Return True
    End Function

    Private Function save_CAORDHDR_CAORDITM_CAORDDTL(ByRef rtnDocNo As String) As Boolean
        '0. DOC NO
        Dim sDocNo As String
        sDocNo = ""
        Dim rs_tmp As DataSet

        If mode = cModeAdd Then
            Dim sClaimBy As String

            If rbClaimBy_C.Checked = True Then
                sClaimBy = "C"
            ElseIf rbClaimBy_V.Checked = True Then
                sClaimBy = "V"
            Else
                sClaimBy = "U"
            End If

            gspStr = "sp_select_DOC_GEN '','CL','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_DOC_GEN, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading save_CAORDHDR_CAORDITM_CAORDDTL sp_select_DOC_GEN :" & rtnStr)
                save_CAORDHDR_CAORDITM_CAORDDTL = False
                Exit Function
            End If

            sDocNo = rs_DOC_GEN.Tables("RESULT").Rows(0).Item(0)
            'sDocNo = Year(Today) & sClaimBy & Mid(sDocNo, 5, 4)
        Else
            sDocNo = Me.txtClaimNo.Text
        End If

        '1. CAORDHDR
        Dim CAH_COCDE As String
        Dim CAH_CAORDNO As String
        Dim CAH_CAORDSTS As String
        'Dim CAH_ADHOC As String
        'Dim CAH_ISSDAT As String
        Dim CAH_CLAPERIOD As String
        Dim CAH_CAAMT_PER As String
        Dim CAH_CLASEARCHBY As String
        Dim CAH_CLABY As String
        Dim CAH_CUS1NO As String
        Dim CAH_CUS2NO As String
        Dim CAH_VENNO As String
        Dim CAH_CLATYP As String
        Dim CAH_RMK As String
        Dim CAH_CUSTCOMMENT As String
        Dim CAH_FINDING As String
        Dim CAH_SALCUR As String
        Dim CAH_SALTTLAMT As String
        'Dim CAH_SALTTLAMT_I As String
        'Dim CAH_SALTTLAMT_E As String
        Dim CAH_GRSPFTAMT As String
        'Dim CAH_GRSPFTAMT_I As String
        'Dim CAH_GRSPFTAMT_E As String
        Dim CAH_CALMTAMT As String
        'Dim CAH_CALMTAMT_I As String
        'Dim CAH_CALMTAMT_E As String
        Dim CAH_CALMTPER As String
        'Dim CAH_CALMTPER_I As String
        'Dim CAH_CALMTPER_E As String
        Dim CAH_CAREMAMT As String
        Dim CAH_CACUR As String
        Dim CAH_CAAMT_ORG As String
        Dim CAH_CAAMT_FINAL As String
        'Dim CAH_CAVSGRSPFT As String
        Dim CAH_APP1FLG As String
        Dim CAH_APP1FLGBY As String
        Dim CAH_APP1FLGDAT As String
        Dim CAH_CATOINSCUR As String
        Dim CAH_CATOINSAMT As String
        Dim CAH_CATOVNCUR As String
        Dim CAH_CATOVNAMT As String
        'Dim CAH_CATOEVNCUR As String
        'Dim CAH_CATOEVNAMT As String
        Dim CAH_CATOHKOCUR As String
        Dim CAH_CATOHKOAMT As String
        Dim CAH_APP2FLG As String
        Dim CAH_APP2FLGBY As String
        Dim CAH_APP2FLGDAT As String
        Dim CAH_CUREXRAT As String
        Dim CAH_CUREXEFFDAT As String

        Dim CAH_PAYSTS As String
        Dim CAH_PAIDDAT As String
        Dim CAH_SETTLE_CUS As String
        Dim CAH_RCVDAT As String
        Dim CAH_SETTLE_FTY As String
        Dim CAH_APRVSTS As String
        Dim CAH_FA_LSTUPDDAT As String
        Dim CAH_Reason As String
        Dim CAH_confclm As String
        Dim CAH_acct_caamt_final As String

        Dim cah_pot_val As String
        Dim cah_ref_no As String
        Dim cah_ref_dat As String
        Dim cah_stschg_usr As String
        Dim cah_stschg_dat As String
        Dim cah_cmt_a As String
        Dim cah_cmt_b As String
        Dim cah_pay_actamt As String
        Dim cah_income_actamt As String
        Dim cah_pay_potamt As String
        Dim cah_income_potamt As String
        Dim cah_pay_upddat As String
        Dim cah_income_upddat As String
        Dim cah_INCOMESTS As String
        Dim cah_ClaimToInsAmt_ori As String
        Dim cah_ClaimToVNAmt_ori As String
        Dim cah_ClaimToHKOAmt_ori As String
        Dim cah_replace As String
        Dim cah_caordsts_a As String
        Dim cah_caordsts_b As String
        Dim cah_season As String

        Dim cah_pay_rmk As String
        Dim cah_income_rmk As String
        Dim cah_income_cur As String
        Dim cah_pay_cur As String

        Dim cah_rplno As String

        CAH_COCDE = ""
        CAH_CAORDNO = sDocNo
        If cboClaimSts.Text = "" Then
            CAH_CAORDSTS = "OPEN"
        Else
            CAH_CAORDSTS = Split(cboClaimSts.Text, " - ")(0)
        End If

        If mode = cModeAdd Then
            CAH_CLAPERIOD = cboClaimPeriod.Text
        Else
            CAH_CLAPERIOD = txtClaimPeriod.Text
        End If

        If rbClaimAmtPer_C.Checked Then
            CAH_CAAMT_PER = "C"
        ElseIf rbClaimAmtPer_I.Checked Then
            CAH_CAAMT_PER = "I"
        Else
            CAH_CAAMT_PER = "S"
        End If

        CAH_CLASEARCHBY = nHdrSearchBy

        If rbClaimBy_C.Checked = True Then
            CAH_CLABY = "C"
        ElseIf rbClaimBy_V.Checked = True Then
            CAH_CLABY = "V"
        Else
            CAH_CLABY = "U"
        End If

        If cboPriCust.Text <> "" Then
            CAH_CUS1NO = Split(cboPriCust.Text, " - ")(0)
        Else
            CAH_CUS1NO = ""
        End If

        If cboSecCust.Text <> "" Then
            CAH_CUS2NO = Split(cboSecCust.Text, " - ")(0)
        Else
            CAH_CUS2NO = ""
        End If

        If cboVendor.Text <> "" Then
            CAH_VENNO = Split(cboVendor.Text, " - ")(0)
        Else
            CAH_VENNO = ""
        End If

        If cboClaimType.Text <> "" Then
            CAH_CLATYP = Split(cboClaimType.Text, " - ")(0)
        Else
            CAH_CLATYP = ""
        End If

        'CAH_RMK = txt_Hdr_Rmk.Text
        'CAH_CUSTCOMMENT = txt_Hdr_CustComment.Text
        'CAH_FINDING = txt_Hdr_Finding.Text
        CAH_RMK = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_rmk").ToString

        CAH_CUSTCOMMENT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_custcomment").ToString

        CAH_FINDING = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_finding").ToString


        'CAH_SALCUR = cbo_Hdr_SalesAmtCurrency.Text
        CAH_SALCUR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salcur")
        'CAH_SALTTLAMT = IIf(txt_Hdr_SalesAmt_Ttl.Text = "", "0.00", txt_Hdr_SalesAmt_Ttl.Text)
        CAH_SALTTLAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salttlamt")
        'CAH_SALTTLAMT_I = IIf(txt_Hdr_SalesAmt_I.Text = "", "0.00", txt_Hdr_SalesAmt_I.Text)
        'CAH_SALTTLAMT_E = IIf(txt_Hdr_SalesAmt_E.Text = "", "0.00", txt_Hdr_SalesAmt_E.Text)

        CAH_GRSPFTAMT = "0.00"
        'CAH_GRSPFTAMT_I = IIf(txt_Hdr_GrsPft_I.Text = "", "0.00", txt_Hdr_GrsPft_I.Text)
        'CAH_GRSPFTAMT_E = IIf(txt_Hdr_GrsPft_E.Text = "", "0.00", txt_Hdr_GrsPft_E.Text)

        'CAH_CALMTAMT = IIf(txt_Hdr_AppLmtChk_Ttl.Text = "", "0.00", txt_Hdr_AppLmtChk_Ttl.Text)
        CAH_CALMTAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtamt")
        'CAH_CALMTAMT_I = IIf(txt_Hdr_AppLmtChk_I.Text = "", "0.00", txt_Hdr_AppLmtChk_I.Text)
        'CAH_CALMTAMT_E = IIf(txt_Hdr_AppLmtChk_E.Text = "", "0.00", txt_Hdr_AppLmtChk_E.Text)

        'CAH_CALMTPER = IIf(lbl_Hdr_AppLmtChkPer_Ttl.Text = "", "0.00", Split(lbl_Hdr_AppLmtChkPer_Ttl.Text, "%")(0))
        CAH_CALMTPER = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtper")
        'CAH_CALMTPER_I = IIf(lbl_Hdr_AppLmtChkPer_I.Text = "", "0.00", Split(lbl_Hdr_AppLmtChkPer_I.Text, "%")(0))
        'CAH_CALMTPER_E = IIf(lbl_Hdr_AppLmtChkPer_E.Text = "", "0.00", Split(lbl_Hdr_AppLmtChkPer_E.Text, "%")(0))

        'CAH_CAREMAMT = IIf(txt_Hdr_RemainClaim_Ttl.Text = "", "0.00", txt_Hdr_RemainClaim_Ttl.Text)
        CAH_CAREMAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caremamt").ToString


        'CAH_CACUR = cbo_Hdr_ClaimAmtCurrency.Text
        'CAH_CAAMT_ORG = IIf(txt_Hdr_OrgClaimAmt.Text = "", "0.00", txt_Hdr_OrgClaimAmt.Text)
        'CAH_CAAMT_FINAL = IIf(txt_Hdr_FinalClaimAmt.Text = "", "0.00", txt_Hdr_FinalClaimAmt.Text)
        CAH_CACUR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cacur")
        CAH_CAAMT_ORG = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_org")
        CAH_CAAMT_FINAL = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_final")

        'If mode = cModeAdd Or mode = cModeUpd Then
        CAH_CAREMAMT = 0
        '''20131112
        'CAH_CAREMAMT = CAH_CAREMAMT - CAH_CAAMT_FINAL * getExchangeRate(CAH_CACUR, CAH_SALCUR, "BuyRate")
        'End If

        'CAH_CAVSGRSPFT = IIf(txt_Hdr_ClaimVSGPPer.Text = "", "0.00", txt_Hdr_ClaimVSGPPer.Text)

        If CAH_CAORDSTS = "OPEN" Then
            CAH_APP1FLG = ""
            CAH_APP1FLGBY = ""
            CAH_APP1FLGDAT = "01/01/1900"
        ElseIf CAH_CAORDSTS = "APV1a" Then
            CAH_APP1FLG = "Y"
            CAH_APP1FLGBY = gsUsrID
            CAH_APP1FLGDAT = Format(Date.Today, "MM/dd/yyyy")
        Else
            CAH_APP1FLG = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app1flg")
            CAH_APP1FLGBY = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app1flgby")
            CAH_APP1FLGDAT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app1flgdat")
        End If

        'CAH_CATOINSCUR = cbo_Hdr_ClaimToInsAmtCurrency.Text
        'CAH_CATOINSAMT = IIf(txt_Hdr_ClaimToInsAmt.Text = "", "0.00", txt_Hdr_ClaimToInsAmt.Text)
        'CAH_CATOVNCUR = cbo_Hdr_ClaimToVNAmtCurrency.Text
        'CAH_CATOVNAMT = IIf(txt_Hdr_ClaimToVNAmt.Text = "", "0.00", txt_Hdr_ClaimToVNAmt.Text)
        CAH_CATOINSCUR = cbo_Hdr_ClaimToInsAmtCur.Text.Trim
        CAH_CATOINSAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoinsamt")
        CAH_CATOVNCUR = cbo_Hdr_ClaimToVNAmtCur.Text.Trim
        CAH_CATOVNAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catovnamt")
        'CAH_CATOEVNCUR = cbo_Hdr_ClaimToEVNAmtCurrency.Text
        'CAH_CATOEVNAMT = IIf(txt_Hdr_ClaimToEVNAmt.Text = "", "0.00", txt_Hdr_ClaimToEVNAmt.Text)
        'CAH_CATOHKOCUR = cbo_Hdr_ClaimToHKOAmtCurrency.Text
        'CAH_CATOHKOAMT = IIf(txt_Hdr_ClaimToHKOAmt.Text = "", "0.00", txt_Hdr_ClaimToHKOAmt.Text)
        CAH_CATOHKOCUR = cbo_Hdr_ClaimToHKOAmtCur.Text.Trim
        CAH_CATOHKOAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catohkoamt")

        If CAH_CAORDSTS = "OPEN" Or CAH_CAORDSTS = "APV1a" Then
            CAH_APP2FLG = ""
            CAH_APP2FLGBY = ""
            CAH_APP2FLGDAT = "01/01/1900"
        Else
            CAH_APP2FLG = "Y"
            CAH_APP2FLGBY = gsUsrID
            CAH_APP2FLGDAT = Format(Date.Today, "MM/dd/yyyy")
        End If

        CAH_CUREXRAT = "1.0"
        CAH_CUREXEFFDAT = "01/01/1900"

        CAH_PAYSTS = Split(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_PAYSTS"), " - ")(0)
        CAH_PAIDDAT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_PAIDDAT")
        CAH_SETTLE_CUS = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_SETTLE_CUS")

        CAH_SETTLE_CUS = Replace(CAH_SETTLE_CUS, "'", "''")

        CAH_RCVDAT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_RCVDAT")
        CAH_SETTLE_FTY = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_SETTLE_FTY")

        CAH_SETTLE_FTY = Replace(CAH_SETTLE_FTY, "'", "''")

        CAH_APRVSTS = Split(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_APRVSTS"), " - ")(0)
        CAH_FA_LSTUPDDAT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_FA_LSTUPDDAT")
        CAH_Reason = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_Reason")
        CAH_Reason = Replace(CAH_Reason, "'", "''")
        CAH_confclm = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_confclm")
        CAH_acct_caamt_final = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_acct_caamt_final")

        cah_pot_val = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pot_val")

        ' cah_pot_val = "P"

        cah_ref_no = Replace(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_ref_no"), "'", "''")
        cah_ref_dat = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_ref_dat")
        cah_stschg_usr = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
        cah_stschg_dat = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat")
        cah_cmt_a = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cmt_a")
        cah_cmt_b = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cmt_b")
        cah_pay_actamt = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_actamt")
        cah_income_actamt = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_actamt")
        cah_pay_potamt = Val(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_potamt"))
        cah_income_potamt = Val(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_potamt"))
        If IsDBNull(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_upddat")) Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_upddat") = "01/01/1900"
        End If
        cah_pay_upddat = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_upddat")
        If IsDBNull(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_upddat")) Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_upddat") = "01/01/1900"
        End If
        cah_income_upddat = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_upddat")
        cah_INCOMESTS = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_INCOMESTS")

        cah_ClaimToInsAmt_ori = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_ClaimToInsAmt_ori")
        cah_ClaimToVNAmt_ori = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_ClaimToVNAmt_ori")
        cah_ClaimToHKOAmt_ori = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_ClaimToHKOAmt_ori")

        cah_pay_rmk = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_rmk")
        cah_income_rmk = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_rmk")


        cah_replace = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_replace")
        If IsDBNull(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a")) Then
            cah_caordsts_a = ""
        Else
            cah_caordsts_a = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a")
        End If

        If IsDBNull(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b")) Then
            cah_caordsts_b = ""
        Else
            cah_caordsts_b = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b")
        End If

        cah_season = cboSeason.Text

        cah_income_cur = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_cur")
        cah_pay_cur = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_cur")

        CAH_CUSTCOMMENT = Replace(CAH_CUSTCOMMENT, "'", "''")
        CAH_RMK = Replace(CAH_RMK, "'", "''")
        CAH_FINDING = Replace(CAH_FINDING, "'", "''")
        cah_cmt_a = Replace(cah_cmt_a, "'", "''")
        cah_cmt_b = Replace(cah_cmt_b, "'", "''")
        cah_pay_rmk = Replace(cah_pay_rmk, "'", "''")
        cah_income_rmk = Replace(cah_income_rmk, "'", "''")
        cah_rplno = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_rplno")

        If mode = cModeAdd Then
            gspStr = "sp_insert_CAORDHDR '" & CAH_COCDE & "','" & CAH_CAORDNO & "','" & CAH_CAORDSTS & "','" & CAH_CLAPERIOD & "','" & CAH_CAAMT_PER & "','" & _
                                            CAH_CLASEARCHBY & "','" & CAH_CLABY & "','" & CAH_CUS1NO & "','" & CAH_CUS2NO & "','" & CAH_VENNO & "','" & CAH_CLATYP & "','" & _
                                            CAH_RMK & "','" & CAH_CUSTCOMMENT & "','" & CAH_FINDING & "','" & CAH_SALCUR & "','" & CAH_SALTTLAMT & "','" & _
                                            CAH_GRSPFTAMT & "','" & CAH_CALMTAMT & "','" & CAH_CALMTPER & "','" & CAH_CACUR & "','" & _
                                            CAH_CAAMT_ORG & "','" & CAH_CAAMT_FINAL & "','" & CAH_APP1FLG & "','" & CAH_APP1FLGBY & "','" & _
                                            CAH_APP1FLGDAT & "','" & CAH_CATOINSCUR & "','" & CAH_CATOINSAMT & "','" & CAH_CATOVNCUR & "','" & CAH_CATOVNAMT & "','" & _
                                            CAH_CATOHKOCUR & "','" & CAH_CATOHKOAMT & "','" & CAH_APP2FLG & "','" & _
                                            CAH_APP2FLGBY & "','" & CAH_APP2FLGDAT & "','" & CAH_CUREXRAT & "','" & CAH_CUREXEFFDAT & _
                                            "" & "','" & CAH_PAYSTS _
                                             & "','" & CAH_PAIDDAT _
                                             & "','" & CAH_SETTLE_CUS _
                                             & "','" & CAH_RCVDAT _
                                             & "','" & CAH_SETTLE_FTY _
                                             & "','" & CAH_APRVSTS _
                                             & "','" & CAH_FA_LSTUPDDAT _
                                             & "','" & CAH_Reason _
                                             & "','" & CAH_confclm _
                                             & "','" & CAH_acct_caamt_final _
                                             & "' ,'" & cah_pot_val _
                                             & "' ,'" & cah_ref_no _
                                             & "' ,'" & cah_ref_dat _
                                             & "' ,'" & cah_stschg_usr _
                                             & "' ,'" & cah_stschg_dat _
                                             & "' ,'" & cah_cmt_a _
                                             & "' ,'" & cah_cmt_b _
                                             & "' ,'" & cah_pay_actamt _
                                             & "' ,'" & cah_income_actamt _
                                             & "' ,'" & cah_pay_potamt _
                                             & "' ,'" & cah_income_potamt _
                                             & "' ,'" & cah_pay_upddat _
                                             & "' ,'" & cah_income_upddat _
                                             & "' ,'" & cah_INCOMESTS _
                                            & "'  ,'" & cah_ClaimToInsAmt_ori _
                                            & "'  ,'" & cah_ClaimToVNAmt_ori _
                                            & "'  ,'" & cah_ClaimToHKOAmt_ori _
                                            & "'  ,'" & cah_replace _
                                            & "'  ,'" & cah_caordsts_a _
                                            & "'  ,'" & cah_caordsts_b _
                                            & "'  ,'" & cah_season _
                                            & "'  ,'" & cah_pay_rmk _
                                            & "'  ,'" & cah_income_rmk _
                                            & "'  ,'" & cah_income_cur _
                                            & "'  ,'" & cah_pay_cur _
                                            & "'  ,'" & cah_rplno _
                                             & "','" & gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading save_CAORDHDR_CAORDITM_CAORDDTL sp_insert_CAORDHDR :" & rtnStr)
                save_CAORDHDR_CAORDITM_CAORDDTL = False
                Exit Function
            End If
        ElseIf mode = cModeUpd Then
            '''check timestamp
            gspStr = "sp_select_CAORDHDR  '" & cboCoCde.Text & "','" & sDocNo & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading CLAIM sp_select_CAORDHDR : " & rtnStr)
                Exit Function
            End If

            If rs_tmp.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("CLAIM # " & sDocNo & ": The record has been modified by other users, please clear and try again.")
                Exit Function
            Else
                If rs_tmp.Tables("RESULT").Rows(0)("cah_timstp") <> rs_CAORDHDR.Tables("RESULT").Rows(0)("cah_timstp") Then
                    MsgBox("CLAIM # " & sDocNo & ": The record has been modified by other users, please clear and try again.")
                    Exit Function
                End If
            End If

            '''

            gspStr = "sp_update_CAORDHDR '" & CAH_COCDE & "','" & CAH_CAORDNO & "','" & CAH_CAORDSTS & "','" & CAH_CLAPERIOD & "','" & CAH_CAAMT_PER & "','" & _
                                            CAH_CLASEARCHBY & "','" & CAH_CLABY & "','" & CAH_CUS1NO & "','" & CAH_CUS2NO & "','" & CAH_VENNO & "','" & CAH_CLATYP & "','" & _
                                            CAH_RMK & "','" & CAH_CUSTCOMMENT & "','" & CAH_FINDING & "','" & CAH_SALCUR & "','" & CAH_SALTTLAMT & "','" & _
                                            CAH_GRSPFTAMT & "','" & CAH_CALMTAMT & "','" & CAH_CALMTPER & "','" & CAH_CACUR & "','" & _
                                            CAH_CAAMT_ORG & "','" & CAH_CAAMT_FINAL & "','" & CAH_APP1FLG & "','" & CAH_APP1FLGBY & "','" & _
                                            CAH_APP1FLGDAT & "','" & CAH_CATOINSCUR & "','" & CAH_CATOINSAMT & "','" & CAH_CATOVNCUR & "','" & CAH_CATOVNAMT & "','" & _
                                            CAH_CATOHKOCUR & "','" & CAH_CATOHKOAMT & "','" & CAH_APP2FLG & "','" & _
                                            CAH_APP2FLGBY & "','" & CAH_APP2FLGDAT & "','" & CAH_CUREXRAT & "','" & CAH_CUREXEFFDAT & _
                                            "" & "','" & CAH_PAYSTS _
                                             & "','" & CAH_PAIDDAT _
                                             & "','" & CAH_SETTLE_CUS _
                                             & "','" & CAH_RCVDAT _
                                             & "','" & CAH_SETTLE_FTY _
                                             & "','" & CAH_APRVSTS _
                                             & "','" & CAH_FA_LSTUPDDAT _
                                             & "','" & CAH_Reason _
                                             & "','" & CAH_confclm _
                                             & "','" & CAH_acct_caamt_final _
                                             & "' ,'" & cah_pot_val _
                                             & "' ,'" & cah_ref_no _
                                             & "' ,'" & cah_ref_dat _
                                             & "' ,'" & cah_stschg_usr _
                                             & "' ,'" & cah_stschg_dat _
                                             & "' ,'" & cah_cmt_a _
                                             & "' ,'" & cah_cmt_b _
                                             & "' ,'" & cah_pay_actamt _
                                             & "' ,'" & cah_income_actamt _
                                             & "' ,'" & cah_pay_potamt _
                                             & "' ,'" & cah_income_potamt _
                                             & "' ,'" & cah_pay_upddat _
                                             & "' ,'" & cah_income_upddat _
                                             & "' ,'" & cah_INCOMESTS _
                                            & "'  ,'" & cah_ClaimToInsAmt_ori _
                                            & "'  ,'" & cah_ClaimToVNAmt_ori _
                                            & "'  ,'" & cah_ClaimToHKOAmt_ori _
                                            & "'  ,'" & cah_replace _
                                            & "'  ,'" & cah_caordsts_a _
                                            & "'  ,'" & cah_caordsts_b _
                                            & "'  ,'" & cah_season _
                                            & "'  ,'" & cah_pay_rmk _
                                            & "'  ,'" & cah_income_rmk _
                                            & "'  ,'" & cah_income_cur _
                                            & "'  ,'" & cah_pay_cur _
                                            & "'  ,'" & cah_rplno _
                                             & "','" & gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading save_CAORDHDR_CAORDITM_CAORDDTL sp_update_CAORDHDR :" & rtnStr)
                save_CAORDHDR_CAORDITM_CAORDDTL = False
                Exit Function
            End If
        End If


        '2. CAORDITM
        If rs_CAORDITM.Tables("RESULT").Rows.Count > 0 Then
            Dim CAI_DEL As String
            Dim CAI_COCDE As String
            Dim CAI_CAORDNO As String
            Dim CAI_CAORDSEQ As String
            Dim CAI_CLATYP As String
            Dim CAI_TXCOCDE As String
            'Dim CAI_SCORDNO As String
            'Dim CAI_SCORDSEQ As String
            'Dim CAI_POPURORD As String
            'Dim CAI_POPURSEQ As String
            'Dim CAI_POJOBORD As String
            'Dim CAI_SHINVNO As String
            'Dim CAI_SCCUSPONO As String

            'Dim CAI_SHISSDAT As String
            'Dim CAI_SHETDDAT As String
            'Dim CAI_SHETADAT As String

            Dim CAI_ITMNO As String
            'Dim CAI_CUSITM As String
            'Dim CAI_CUSSTYNO As String
            'Dim CAI_VENITM As String
            Dim CAI_ITMDSC As String
            'Dim CAI_PRDVEN As String
            'Dim CAI_VENTYP As String

            'Dim CAI_SCCURCDE As String
            'Dim CAI_SCNETUNTPRC As String
            'Dim CAI_SCFCURCDE As String
            'Dim CAI_SCFTYPRC As String

            'Dim CAI_SCPCKUNT As String
            'Dim CAI_SCORDQTY As String
            'Dim CAI_SCSHPQTY As String
            'Dim CAI_CAQTY As String
            'Dim CAI_CAQTY_FINAL As String
            Dim CAI_RMK As String

            Dim CAI_SALCUR As String
            Dim CAI_SALAMT As String
            Dim CAI_GRSPFTAMT As String
            Dim CAI_CALMTAMT As String
            Dim CAI_CALMTPER As String
            Dim CAI_CAREMAMT As Decimal

            Dim CAI_CACUR As String
            Dim CAI_CAQTYAMT_ORG As String
            Dim CAI_CAQTYAMT_FINAL As String
            Dim CAI_CAAMT_ORG As String
            Dim CAI_CAAMT_FINAL As String
            Dim CAI_TTLCAAMT_ORG As String
            Dim CAI_TTLCAAMT_FINAL As String
            'Dim CAI_CAVSGRSPFT As String

            Dim CAI_APP1FLG As String
            Dim CAI_APP1FLGBY As String
            Dim CAI_APP1FLGDAT As String

            Dim CAI_CATOINSCUR As String
            Dim CAI_CATOINSAMT As String
            Dim CAI_CATOVNCUR As String
            Dim CAI_CATOVNAMT As String
            Dim CAI_CATOHKOCUR As String
            Dim CAI_CATOHKOAMT As String

            Dim CAI_APP2FLG As String
            Dim CAI_APP2FLGBY As String
            Dim CAI_APP2FLGDAT As String
            Dim cai_cusitm As String
            Dim cai_cusstyno As String
            Dim cai_venitm As String
            Dim cai_prdven As String
            Dim CAI_CREUSR As String

            Dim APV1_CHECKING_COUNT As Integer
            Dim APV2_CHECKING_COUNT As Integer
            Dim APV1_CHECKING_FLAG As Integer
            Dim APV2_CHECKING_FLAG As Integer

            APV1_CHECKING_COUNT = 0
            APV2_CHECKING_COUNT = 0
            APV1_CHECKING_FLAG = False
            APV2_CHECKING_FLAG = False

            Dim i As Integer

            For i = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
                CAI_DEL = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_del").ToString

                CAI_COCDE = ""
                CAI_CAORDNO = sDocNo
                CAI_CAORDSEQ = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caordseq")

                If CAI_DEL = "Y" Then
                    gspStr = "sp_physical_delete_CAORDITM '" & CAI_COCDE & "','" & CAI_CAORDNO & "','" & CAI_CAORDSEQ & " ','" & gsUsrID & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_CAORDHDR_CAORDITM_CAORDDTL sp_physical_delete_CAORDITM :" & rtnStr)
                        save_CAORDHDR_CAORDITM_CAORDDTL = False
                        Exit Function
                    End If
                    APV1_CHECKING_COUNT = APV1_CHECKING_COUNT + 1
                    APV2_CHECKING_COUNT = APV2_CHECKING_COUNT + 1
                Else
                    CAI_CLATYP = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_clatyp")
                    CAI_TXCOCDE = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_txcocde")
                    'CAD_SCORDNO = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_scordno")
                    'CAD_SCORDSEQ = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_scordseq")
                    'CAD_POPURORD = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_popurord")
                    'CAD_POPURSEQ = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_popurseq")
                    'CAD_POJOBORD = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_pojobord")
                    'CAD_SHINVNO = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_shinvno")
                    'CAD_SCCUSPONO = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_sccuspono")
                    'CAD_SHISSDAT = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_shissdat")
                    'CAD_SHETDDAT = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_shetddat")
                    'CAD_SHETADAT = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_shetadat")
                    CAI_ITMNO = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_itmno")
                    'CAD_CUSITM = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_cusitm")
                    'CAD_CUSSTYNO = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_cusstyno")
                    'CAD_VENITM = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_venitm")
                    CAI_ITMDSC = Replace(rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_itmdsc"), "'", "''''")
                    'CAD_PRDVEN = Split(rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_prdven"), " - ")(0)
                    'CAD_VENTYP = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_ventyp")
                    'CAD_SCCURCDE = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_sccurcde")
                    'CAD_SCNETUNTPRC = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_scnetuntprc")
                    'CAD_SCFCURCDE = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_scfcurcde")
                    'CAD_SCFTYPRC = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_scftyprc")
                    'CAD_SCPCKUNT = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_scpckunt")
                    'CAD_SCORDQTY = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_scordqty")
                    'CAD_SCSHPQTY = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_scshpqty")
                    'CAI_CAQTY = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caqty")
                    'CAI_CAQTY_FINAL = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caqty_final")
                    CAI_RMK = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_rmk")
                    CAI_SALCUR = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_salcur")
                    CAI_SALAMT = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_salamt")
                    CAI_GRSPFTAMT = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_grspftamt")
                    CAI_CALMTAMT = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_calmtamt")
                    CAI_CALMTPER = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_calmtper").ToString

                    CAI_CAREMAMT = 0
                    '''CAI_CAREMAMT = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caremamt").ToString

                    CAI_CACUR = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_cacur")
                    CAI_CAQTYAMT_ORG = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caqtyamt_org")
                    CAI_CAQTYAMT_FINAL = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caqtyamt_final")
                    CAI_CAAMT_ORG = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caamt_org")
                    CAI_CAAMT_FINAL = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caamt_final")
                    CAI_TTLCAAMT_ORG = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_ttlcaamt_org")
                    CAI_TTLCAAMT_FINAL = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_ttlcaamt_final")
                    'CAD_CAVSGRSPFT = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cad_cavsgrspft")
                    CAI_APP1FLG = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_app1flg")
                    CAI_APP1FLGBY = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_app1flgby")
                    CAI_APP1FLGDAT = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_app1flgdat")
                    CAI_CATOINSCUR = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_catoinscur")
                    CAI_CATOINSAMT = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_catoinsamt")
                    CAI_CATOVNCUR = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_catovncur")
                    CAI_CATOVNAMT = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_catovnamt")
                    CAI_CATOHKOCUR = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_catohkocur")
                    CAI_CATOHKOAMT = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_catohkoamt")
                    CAI_APP2FLG = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_app2flg")
                    CAI_APP2FLGBY = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_app2flgby")
                    CAI_APP2FLGDAT = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_app2flgdat")
                    cai_cusitm = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_cusitm")
                    cai_cusstyno = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_cusstyno")
                    cai_venitm = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_venitm")
                    cai_prdven = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_prdven")
                    CAI_CREUSR = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_creusr")

                    'If mode = cModeAdd Or mode = cModeUpd Then
                    CAI_CAREMAMT = 0
                    ''' CAI_CAREMAMT = CAI_CAREMAMT - CAI_TTLCAAMT_FINAL * getExchangeRate(CAI_CACUR, CAI_SALCUR, "BuyRate")
                    'End If

                    CAI_APP1FLG = CAI_APP1FLG.Trim
                    CAI_APP2FLG = CAI_APP2FLG.Trim

                    If CAI_APP2FLG <> "Y" Then
                        CAI_APP2FLG = ""
                    End If

                    If CAI_APP1FLG = "Y" Then
                        APV1_CHECKING_COUNT = APV1_CHECKING_COUNT + 1
                        APV1_CHECKING_FLAG = True
                    End If

                    If CAI_APP2FLG = "Y" Then
                        APV2_CHECKING_COUNT = APV2_CHECKING_COUNT + 1
                        APV2_CHECKING_FLAG = True
                    End If

                    Dim casechange As String
                    casechange = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts").ToString
                    If casechange <> addition Then
                        If casechange = "APV1a" Then
                            If CAI_APP1FLG = "" Then
                                CAI_APP1FLG = "Y"
                                CAI_APP1FLGBY = gsUsrID
                                CAI_APP1FLGDAT = Format(Date.Today, "MM/dd/yyyy")

                                If Not (CAI_CREUSR = "~*ADD*~" Or _
                                        CAI_CREUSR = "~*NEW*~" Or _
                                        CAI_CREUSR = "~*UPD*~" Or _
                                        CAI_CREUSR = "~*DEL*~") Then
                                    CAI_CREUSR = "~*UPD*~"
                                End If
                            End If

                        ElseIf casechange = "APV1b" Then
                            If CAI_APP2FLG = "" Then
                                CAI_APP2FLG = "Y"
                                CAI_APP2FLGBY = gsUsrID
                                CAI_APP2FLGDAT = Format(Date.Today, "MM/dd/yyyy")
                                If Not (CAI_CREUSR = "~*ADD*~" Or _
                                        CAI_CREUSR = "~*NEW*~" Or _
                                        CAI_CREUSR = "~*UPD*~" Or _
                                        CAI_CREUSR = "~*DEL*~") Then
                                    CAI_CREUSR = "~*UPD*~"
                                End If
                            End If
                        End If
                    End If

                    '                    If mode = cModeAdd Then
                    'tmp20131114
                    'If CAI_CREUSR = "~*ADD*~" Then

                    If mode = cModeAdd Or CAI_CREUSR = "~*ADD*~" Then

                        gspStr = "sp_insert_CAORDITM '" & CAI_COCDE & "','" & CAI_CAORDNO & "','" & CAI_CAORDSEQ & "','" & CAI_CLATYP & "','" & CAI_TXCOCDE & "','" & _
                                                        CAI_ITMNO & "','" & CAI_ITMDSC & "','" & CAI_RMK & "','" & _
                                                        CAI_SALCUR & "','" & CAI_SALAMT & "','" & CAI_GRSPFTAMT & "','" & CAI_CALMTAMT & "','" & CAI_CALMTPER & "','" & _
                                                        CAI_CAREMAMT & "','" & CAI_CACUR & "','" & CAI_CAQTYAMT_ORG & "','" & CAI_CAQTYAMT_FINAL & "','" & CAI_CAAMT_ORG & "','" & _
                                                        CAI_CAAMT_FINAL & "','" & CAI_TTLCAAMT_ORG & "','" & CAI_TTLCAAMT_FINAL & "','" & CAI_APP1FLG & "','" & _
                                                        CAI_APP1FLGBY & "','" & CAI_APP1FLGDAT & "','" & CAI_CATOINSCUR & "','" & CAI_CATOINSAMT & "','" & CAI_CATOVNCUR & "','" & _
                                                        CAI_CATOVNAMT & "','" & CAI_CATOHKOCUR & "','" & CAI_CATOHKOAMT & "','" & CAI_APP2FLG & "','" & CAI_APP2FLGBY & "','" & _
                                                        CAI_APP2FLGDAT & "','" & _
                                                        cai_cusitm & "','" & _
                                                        cai_cusstyno & "','" & _
                                                        cai_venitm & "','" & _
                                                        cai_prdven & "','" & _
                                                         gsUsrID & "','" & gsUsrID & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading save_CAORDHDR_CAORDITM_CAORDDTL sp_insert_CAORDITM :" & rtnStr)
                            save_CAORDHDR_CAORDITM_CAORDDTL = False
                            Exit Function
                        End If
                        'ElseIf mode = cModeUpd Then
                        'tmp20131114
                    ElseIf CAI_CREUSR = "~*UPD*~" Then
                        gspStr = "sp_update_CAORDITM '" & CAI_COCDE & "','" & CAI_CAORDNO & "','" & CAI_CAORDSEQ & "','" & CAI_CLATYP & "','" & CAI_TXCOCDE & "','" & _
                                                        CAI_ITMNO & "','" & CAI_ITMDSC & "','" & CAI_RMK & "','" & _
                                                        CAI_SALCUR & "','" & CAI_SALAMT & "','" & CAI_GRSPFTAMT & "','" & CAI_CALMTAMT & "','" & _
                                                        CAI_CACUR & "','" & CAI_CAQTYAMT_ORG & "','" & CAI_CAQTYAMT_FINAL & "','" & CAI_CAAMT_ORG & "','" & _
                                                        CAI_CAAMT_FINAL & "','" & CAI_TTLCAAMT_ORG & "','" & CAI_TTLCAAMT_FINAL & "','" & CAI_APP1FLG & "','" & _
                                                        CAI_APP1FLGBY & "','" & CAI_APP1FLGDAT & "','" & CAI_CATOINSCUR & "','" & CAI_CATOINSAMT & "','" & CAI_CATOVNCUR & "','" & _
                                                        CAI_CATOVNAMT & "','" & CAI_CATOHKOCUR & "','" & CAI_CATOHKOAMT & "','" & CAI_APP2FLG & "','" & _
                                                        CAI_APP2FLGBY & "','" & _
                                                        CAI_APP2FLGDAT & "','" & _
                                                        cai_cusitm & "','" & _
                                                        cai_cusstyno & "','" & _
                                                        cai_venitm & "','" & _
                                                        cai_prdven & "','" & _
                                                         gsUsrID & "'"
                        'gspStr = "sp_update_CAORDITM '" & CAI_COCDE & "','" & CAI_CAORDNO & "','" & CAI_CAORDSEQ & "','" & CAI_CLATYP & "','" & CAI_TXCOCDE & "','" & _
                        '                        CAI_ITMNO & "','" & CAI_ITMDSC & "','" & CAI_RMK & "','" & _
                        '                        CAI_SALCUR & "','" & CAI_SALAMT & "','" & CAI_GRSPFTAMT & "','" & CAI_CALMTAMT & "','" & CAI_CALMTPER & "','" & _
                        '                        CAI_CAREMAMT & "','" & CAI_CACUR & "','" & CAI_CAQTYAMT_ORG & "','" & CAI_CAQTYAMT_FINAL & "','" & CAI_CAAMT_ORG & "','" & _
                        '                        CAI_CAAMT_FINAL & "','" & CAI_TTLCAAMT_ORG & "','" & CAI_TTLCAAMT_FINAL & "','" & CAI_APP1FLG & "','" & _
                        '                        CAI_APP1FLGBY & "','" & CAI_APP1FLGDAT & "','" & CAI_CATOINSCUR & "','" & CAI_CATOINSAMT & "','" & CAI_CATOVNCUR & "','" & _
                        '                        CAI_CATOVNAMT & "','" & CAI_CATOHKOCUR & "','" & CAI_CATOHKOAMT & "','" & CAI_APP2FLG & "','" & CAI_APP2FLGBY & "','" & _
                        '                        CAI_APP2FLGDAT & "','" & gsUsrID & "'"

                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading save_CAORDHDR_CAORDITM_CAORDDTL sp_update_CAORDITM :" & rtnStr)
                            save_CAORDHDR_CAORDITM_CAORDDTL = False
                            Exit Function
                        End If
                    End If
                End If
            Next i

            If CAH_CAAMT_FINAL * getExchangeRate(CAH_CACUR, CAH_SALCUR, "BuyRate") <= CAH_CAREMAMT Then
                If CAH_CAORDSTS = "OPEN" Then
                    If APV1_CHECKING_FLAG = True And APV1_CHECKING_COUNT = rs_CAORDITM.Tables("RESULT").Rows.Count Then
                        gspStr = "sp_update_CAORDHDR '" & CAH_COCDE & "','" & CAH_CAORDNO & "','" & "APV1a" & "','" & CAH_CLAPERIOD & "','" & _
                                                        CAH_CLASEARCHBY & "','" & CAH_CLABY & "','" & CAH_CUS1NO & "','" & CAH_CUS2NO & "','" & CAH_VENNO & "','" & CAH_CLATYP & "','" & _
                                                        CAH_RMK & "','" & CAH_CUSTCOMMENT & "','" & CAH_FINDING & "','" & CAH_SALCUR & "','" & CAH_SALTTLAMT & "','" & _
                                                        CAH_GRSPFTAMT & "','" & CAH_CALMTAMT & "','" & CAH_CALMTPER & "','" & CAH_CACUR & "','" & _
                                                        CAH_CAAMT_ORG & "','" & CAH_CAAMT_FINAL & "','" & "Y" & "','" & gsUsrID & "','" & _
                                                        Format(Date.Today, "MM/dd/yyyy") & "','" & CAH_CATOINSCUR & "','" & CAH_CATOINSAMT & "','" & CAH_CATOVNCUR & "','" & CAH_CATOVNAMT & "','" & _
                                                        CAH_CATOHKOCUR & "','" & CAH_CATOHKOAMT & "','" & CAH_APP2FLG & "','" & _
                                                        CAH_APP2FLGBY & "','" & CAH_APP2FLGDAT & "','" & CAH_CUREXRAT & "','" & CAH_CUREXEFFDAT & "','" & gsUsrID & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading save_CAORDHDR_CAORDITM_CAORDDTL sp_update_CAORDHDR APV1 :" & rtnStr)
                            save_CAORDHDR_CAORDITM_CAORDDTL = False
                            Exit Function
                        End If
                    End If
                ElseIf CAH_CAORDSTS = "APV1a" Then
                    If APV2_CHECKING_FLAG = True And APV2_CHECKING_COUNT = rs_CAORDITM.Tables("RESULT").Rows.Count Then
                        gspStr = "sp_update_CAORDHDR '" & CAH_COCDE & "','" & CAH_CAORDNO & "','" & "APV1b" & "','" & CAH_CLAPERIOD & "','" & CAH_CAAMT_PER & "','" & _
                                                        CAH_CLASEARCHBY & "','" & CAH_CLABY & "','" & CAH_CUS1NO & "','" & CAH_CUS2NO & "','" & CAH_VENNO & "','" & CAH_CLATYP & "','" & _
                                                        CAH_RMK & "','" & CAH_CUSTCOMMENT & "','" & CAH_FINDING & "','" & CAH_SALCUR & "','" & CAH_SALTTLAMT & "','" & _
                                                        CAH_GRSPFTAMT & "','" & CAH_CALMTAMT & "','" & CAH_CALMTPER & "','" & CAH_CACUR & "','" & _
                                                        CAH_CAAMT_ORG & "','" & CAH_CAAMT_FINAL & "','" & CAH_APP1FLG & "','" & CAH_APP1FLGBY & "','" & _
                                                        CAH_APP1FLGDAT & "','" & CAH_CATOINSCUR & "','" & CAH_CATOINSAMT & "','" & CAH_CATOVNCUR & "','" & CAH_CATOVNAMT & "','" & _
                                                        CAH_CATOHKOCUR & "','" & CAH_CATOHKOAMT & "','" & "Y" & "','" & _
                                                        gsUsrID & "','" & Format(Date.Today, "MM/dd/yyyy") & "','" & CAH_CUREXRAT & "','" & CAH_CUREXEFFDAT & "','" & gsUsrID & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading save_CAORDHDR_CAORDITM_CAORDDTL sp_update_CAORDHDR APV2 :" & rtnStr)
                            save_CAORDHDR_CAORDITM_CAORDDTL = False
                            Exit Function
                        End If
                    End If
                End If
            End If
        End If

        '3. CAORDDTL
        If rs_CAORDDTL.Tables("RESULT").Rows.Count > 0 Then
            Dim CAD_DEL As String
            Dim CAD_COCDE As String
            Dim CAD_CAORDNO As String
            Dim CAD_CAORDSEQ As String
            Dim CAD_CLATYP As String
            Dim CAD_TXCOCDE As String
            Dim CAD_SHPNO As String
            Dim CAD_SHPSEQ As String
            Dim CAD_SCORDNO As String
            Dim CAD_SCORDSEQ As String
            Dim CAD_POPURORD As String
            Dim CAD_POPURSEQ As String
            Dim CAD_POJOBORD As String
            Dim CAD_SHINVNO As String
            Dim CAD_SCCUSPONO As String

            Dim CAD_SHISSDAT As String
            Dim CAD_SHETDDAT As String
            Dim CAD_SHETADAT As String

            Dim CAD_ITMNO As String
            Dim CAD_CUSITM As String
            Dim CAD_CUSSTYNO As String
            Dim CAD_VENITM As String
            Dim CAD_ITMDSC As String
            Dim CAD_PRDVEN As String
            Dim CAD_VENTYP As String

            Dim CAD_SCCURCDE As String
            Dim CAD_SCNETUNTPRC As String
            Dim CAD_SCFCURCDE As String
            Dim CAD_SCFTYPRC As String

            Dim CAD_SCPCKUNT As String
            Dim CAD_SCORDQTY As String
            Dim CAD_SCUNTCDE As String
            Dim CAD_SCSHPQTY As String
            Dim CAD_CAQTY As String
            Dim CAD_CAQTY_FINAL As String
            Dim CAD_RMK As String

            Dim CAD_SALCUR As String
            Dim CAD_SALAMT As String
            Dim CAD_GRSPFTAMT As String
            Dim CAD_CALMTAMT As String
            'Dim CAD_CALMTPER As String
            Dim CAD_CAREMAMT As String

            Dim CAD_CACUR As String
            Dim CAD_CAQTYAMT_ORG As String
            Dim CAD_CAQTYAMT_FINAL As String
            Dim CAD_CAAMT_ORG As String
            Dim CAD_CAAMT_FINAL As String
            Dim CAD_TTLCAAMT_ORG As String
            Dim CAD_TTLCAAMT_FINAL As String
            'Dim CAD_CAVSGRSPFT As String

            'Dim CAD_APP1FLG As String
            'Dim CAD_APP1FLGBY As String
            'Dim CAD_APP1FLGDAT As String

            Dim CAD_CATOINSCUR As String
            Dim CAD_CATOINSAMT As String
            Dim CAD_CATOVNCUR As String
            Dim CAD_CATOVNAMT As String
            Dim CAD_CATOHKOCUR As String
            Dim CAD_CATOHKOAMT As String

            'Dim CAD_APP2FLG As String
            'Dim CAD_APP2FLGBY As String
            'Dim CAD_APP2FLGDAT As String
            Dim CAD_CREUSR As String

            'Dim APV1_CHECKING_COUNT As Integer
            'Dim APV2_CHECKING_COUNT As Integer
            'Dim APV1_CHECKING_FLAG As Integer
            'Dim APV2_CHECKING_FLAG As Integer

            'APV1_CHECKING_COUNT = 0
            'APV2_CHECKING_COUNT = 0
            'APV1_CHECKING_FLAG = False
            'APV2_CHECKING_FLAG = False

            Dim i As Integer

            For i = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
                CAD_DEL = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_del")
                CAD_COCDE = ""
                CAD_CAORDNO = sDocNo
                CAD_CAORDSEQ = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caordseq")

                If CAD_DEL = "Y" Then
                    gspStr = "sp_physical_delete_CAORDDTL '" & CAD_COCDE & "','" & CAD_CAORDNO & "','" & CAD_CAORDSEQ & " ','" & gsUsrID & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_CAORDHDR_CAORDITM_CAORDDTL sp_physical_delete_CAORDDTL :" & rtnStr)
                        save_CAORDHDR_CAORDITM_CAORDDTL = False
                        Exit Function
                    End If
                    'APV1_CHECKING_COUNT = APV1_CHECKING_COUNT + 1
                    'APV2_CHECKING_COUNT = APV2_CHECKING_COUNT + 1
                Else
                    CAD_CLATYP = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_clatyp")
                    CAD_TXCOCDE = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_txcocde")
                    '''''''''''''''???

                    CAD_SHPNO = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("CAD_SHPNO")
                    CAD_SHPSEQ = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("CAD_SHPSEQ")

                    '                    CAD_SHPNO = "tempshpno"
                    '                   CAD_SHPSEQ = "1"

                    CAD_SCORDNO = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_scordno")
                    CAD_SCORDSEQ = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_scordseq")
                    CAD_POPURORD = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_popurord")
                    CAD_POPURSEQ = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_popurseq")
                    CAD_POJOBORD = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_pojobord")

                    '''''''''''''''???
                    CAD_SHINVNO = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_shinvno")
                    '''''''''''''''???
                    CAD_SCCUSPONO = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_sccuspono")

                    CAD_SHISSDAT = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_shissdat")
                    CAD_SHETDDAT = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_shetddat")
                    CAD_SHETADAT = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_shetadat")
                    CAD_ITMNO = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_itmno")
                    CAD_CUSITM = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_cusitm")
                    CAD_CUSSTYNO = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_cusstyno")
                    CAD_VENITM = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_venitm")
                    CAD_ITMDSC = Replace(rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_itmdsc"), "'", "''''")
                    CAD_PRDVEN = Split(rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_prdven"), " - ")(0)
                    CAD_VENTYP = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_ventyp")
                    CAD_SCCURCDE = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_sccurcde")
                    CAD_SCNETUNTPRC = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_scnetuntprc")
                    CAD_SCFCURCDE = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_scfcurcde")
                    CAD_SCFTYPRC = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_scftyprc")
                    CAD_SCPCKUNT = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_scpckunt")
                    CAD_SCORDQTY = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_scordqty")
                    CAD_SCUNTCDE = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_scuntcde").ToString

                    CAD_SCSHPQTY = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_scshpqty")
                    CAD_CAQTY = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caqty")
                    CAD_CAQTY_FINAL = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caqty_final")
                    CAD_RMK = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_rmk")
                    CAD_SALCUR = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_salcur")
                    CAD_SALAMT = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_salamt")
                    CAD_GRSPFTAMT = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_grspftamt")
                    CAD_CALMTAMT = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_calmtamt")
                    'CAD_CALMTPER = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_calmtper")
                    'CAD_CAREMAMT = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caremamt")
                    CAD_CACUR = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_cacur")
                    CAD_CAQTYAMT_ORG = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caqtyamt_org")
                    CAD_CAQTYAMT_FINAL = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caqtyamt_final")
                    CAD_CAAMT_ORG = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caamt_org")
                    CAD_CAAMT_FINAL = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caamt_final")
                    CAD_TTLCAAMT_ORG = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_ttlcaamt_org")
                    CAD_TTLCAAMT_FINAL = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_ttlcaamt_final")
                    'CAD_CAVSGRSPFT = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_cavsgrspft")
                    'CAD_APP1FLG = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_app1flg")
                    'CAD_APP1FLGBY = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_app1flgby")
                    'CAD_APP1FLGDAT = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_app1flgdat")
                    CAD_CATOINSCUR = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_catoinscur")
                    CAD_CATOINSAMT = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_catoinsamt")
                    CAD_CATOVNCUR = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_catovncur")
                    CAD_CATOVNAMT = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_catovnamt")
                    CAD_CATOHKOCUR = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_catohkocur")
                    CAD_CATOHKOAMT = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_catohkoamt")
                    'CAD_APP2FLG = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_app2flg")
                    'CAD_APP2FLGBY = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_app2flgby")
                    'CAD_APP2FLGDAT = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_app2flgdat")
                    CAD_CREUSR = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_creusr")

                    CAD_RMK = Replace(CAD_RMK, "'", "''")


                    'CAD_APP1FLG = CAD_APP1FLG.Trim
                    'CAD_APP2FLG = CAD_APP2FLG.Trim

                    'If CAD_APP1FLG = "Y" Then
                    '    APV1_CHECKING_COUNT = APV1_CHECKING_COUNT + 1
                    '    APV1_CHECKING_FLAG = True
                    'End If

                    'If CAD_APP2FLG = "Y" Then
                    '    APV2_CHECKING_COUNT = APV2_CHECKING_COUNT + 1
                    '    APV2_CHECKING_FLAG = True
                    'End If

                    'Dim casechange As String
                    'casechange = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts").ToString
                    'If casechange <> addition Then
                    '    If casechange = "APV1a" Then
                    '        'If CAD_APP1FLG = "" Then
                    '        '    CAD_APP1FLG = "Y"
                    '        '    CAD_APP1FLGBY = gsUsrID
                    '        '    CAD_APP1FLGDAT = Format(Date.Today, "MM/dd/yyyy")

                    '        If Not (CAD_CREUSR = "~*ADD*~" Or _
                    '                CAD_CREUSR = "~*NEW*~" Or _
                    '                CAD_CREUSR = "~*UPD*~" Or _
                    '                CAD_CREUSR = "~*DEL*~") Then
                    '            CAD_CREUSR = "~*UPD*~"
                    '        End If
                    '        'End If

                    '    ElseIf casechange = "APV1b" Then
                    '        'If CAD_APP2FLG = "" Then
                    '        '    CAD_APP2FLG = "Y"
                    '        '    CAD_APP2FLGBY = gsUsrID
                    '        '    CAD_APP2FLGDAT = Format(Date.Today, "MM/dd/yyyy")
                    '        If Not (CAD_CREUSR = "~*ADD*~" Or _
                    '                CAD_CREUSR = "~*NEW*~" Or _
                    '                CAD_CREUSR = "~*UPD*~" Or _
                    '                CAD_CREUSR = "~*DEL*~") Then
                    '            CAD_CREUSR = "~*UPD*~"
                    '        End If
                    '    End If
                    'End If
                    'End If

                    '''20131126 temp use mode = cModeAdd 
                    If mode = cModeAdd Or CAD_CREUSR = "~*ADD*~" Or CAD_CREUSR = "~*NEW*~" Then
                        'If mode = cModeAdd Then
                        gspStr = "sp_insert_CAORDDTL '" & CAD_COCDE & "','" & CAD_CAORDNO & "','" & CAD_CAORDSEQ & "','" & CAD_CLATYP & "','" & CAD_TXCOCDE & "','" & _
                                                        CAD_SHPNO & "','" & CAD_SHPSEQ & "','" & CAD_SCORDNO & "','" & CAD_SCORDSEQ & "','" & _
                                                        CAD_POPURORD & "','" & CAD_POPURSEQ & "','" & CAD_POJOBORD & "','" & CAD_SHINVNO & "','" & _
                                                        CAD_SCCUSPONO & "','" & CAD_SHISSDAT & "','" & CAD_SHETDDAT & "','" & CAD_SHETADAT & "','" & CAD_ITMNO & "','" & _
                                                        CAD_CUSITM & "','" & CAD_CUSSTYNO & "','" & CAD_VENITM & "','" & CAD_ITMDSC & "','" & CAD_PRDVEN & "','" & _
                                                        CAD_VENTYP & "','" & CAD_SCCURCDE & "','" & CAD_SCNETUNTPRC & "','" & CAD_SCFCURCDE & "','" & CAD_SCFTYPRC & "','" & _
                                                        CAD_SCPCKUNT & "','" & CAD_SCORDQTY & "','" & CAD_SCSHPQTY & "','" & _
                                                        CAD_CAQTY & "','" & CAD_CAQTY_FINAL & "','" & CAD_RMK & "','" & CAD_SALCUR & "','" & CAD_SALAMT & "','" & _
                                                        CAD_GRSPFTAMT & "','" & CAD_CALMTAMT & "','" & _
                                                        CAD_CACUR & "','" & CAD_CAQTYAMT_ORG & "','" & CAD_CAQTYAMT_FINAL & "','" & CAD_CAAMT_ORG & "','" & CAD_CAAMT_FINAL & "','" & _
                                                        CAD_TTLCAAMT_ORG & "','" & CAD_TTLCAAMT_FINAL & "','" & CAD_CATOINSCUR & "','" & CAD_CATOINSAMT & "','" & CAD_CATOVNCUR & "','" & _
                                                        CAD_CATOVNAMT & "','" & CAD_CATOHKOCUR & "','" & CAD_CATOHKOAMT & "','" & CAD_SCUNTCDE & "','" & gsUsrID & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading save_CAORDHDR_CAORDITM_CAORDDTL sp_insert_CAORDDTL :" & rtnStr)
                            save_CAORDHDR_CAORDITM_CAORDDTL = False
                            Exit Function
                        End If
                        'ElseIf mode = cModeUpd Then
                    ElseIf CAD_CREUSR = "~*UPD*~" Then
                        '''CAD_SCUNTCDE
                        'CAD_SCUNTCDE & "','" &
                        gspStr = "sp_update_CAORDDTL '" & CAD_COCDE & "','" & CAD_CAORDNO & "','" & CAD_CAORDSEQ & "','" & CAD_CLATYP & "','" & CAD_TXCOCDE & "','" & _
                                                        CAD_SHPNO & "','" & CAD_SHPSEQ & "','" & CAD_SCORDNO & "','" & CAD_SCORDSEQ & "','" & _
                                                        CAD_POPURORD & "','" & CAD_POPURSEQ & "','" & CAD_POJOBORD & "','" & CAD_SHINVNO & "','" & _
                                                        CAD_SCCUSPONO & "','" & CAD_SHISSDAT & "','" & CAD_SHETDDAT & "','" & CAD_SHETADAT & "','" & CAD_ITMNO & "','" & _
                                                        CAD_CUSITM & "','" & CAD_CUSSTYNO & "','" & CAD_VENITM & "','" & CAD_ITMDSC & "','" & CAD_PRDVEN & "','" & _
                                                        CAD_VENTYP & "','" & CAD_SCCURCDE & "','" & CAD_SCNETUNTPRC & "','" & CAD_SCFCURCDE & "','" & CAD_SCFTYPRC & "','" & _
                                                        CAD_SCPCKUNT & "','" & CAD_SCORDQTY & "','" & CAD_SCSHPQTY & "','" & _
                                                        CAD_CAQTY & "','" & CAD_CAQTY_FINAL & "','" & CAD_RMK & "','" & CAD_SALCUR & "','" & CAD_SALAMT & "','" & _
                                                        CAD_GRSPFTAMT & "','" & CAD_CALMTAMT & "','" & _
                                                        CAD_CACUR & "','" & CAD_CAQTYAMT_ORG & "','" & CAD_CAQTYAMT_FINAL & "','" & CAD_CAAMT_ORG & "','" & CAD_CAAMT_FINAL & "','" & _
                                                        CAD_TTLCAAMT_ORG & "','" & CAD_TTLCAAMT_FINAL & "','" & CAD_CATOINSCUR & "','" & CAD_CATOINSAMT & "','" & CAD_CATOVNCUR & "','" & _
                                                        CAD_CATOVNAMT & "','" & CAD_CATOHKOCUR & "','" & CAD_CATOHKOAMT & "','" & CAD_SCUNTCDE & "','" & gsUsrID & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading save_CAORDHDR_CAORDITM_CAORDDTL sp_update_CAORDDTL :" & rtnStr)
                            save_CAORDHDR_CAORDITM_CAORDDTL = False
                            Exit Function
                        End If
                    End If
                End If
            Next i
        End If

        'If mode = cModeAdd Or CAH_CAORDSTS = "OPEN" Then
        If CAH_CAREMAMT > 0 Then
            If Not update_claim_remain_tables("OPEN") Then
                save_CAORDHDR_CAORDITM_CAORDDTL = False
            End If
        End If

        rtnDocNo = sDocNo
        save_CAORDHDR_CAORDITM_CAORDDTL = True
    End Function

    Private Function update_claim_remain_tables(ByVal sClaimSts As String) As Boolean
        Dim CRH_COCDE As String
        Dim CRH_CLAPERIOD As String
        Dim CRH_CUS1NO As String
        Dim CRH_CUS2NO As String
        Dim CRH_SALCUR As String
        Dim CRH_SALTTLAMT As String
        Dim CRH_GRSPFTAMT As String
        Dim CRH_CALMTAMT As String
        Dim CRH_CALMTPER As String
        Dim CRH_CAREMAMT As String
        Dim CRH_CAAMT_FINAL As String
        Dim CRH_CACUR As String
        Dim CRH_CUREXRAT As String
        Dim CRH_CUREXEFFDAT As String

        CRH_COCDE = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cocde")
        CRH_CLAPERIOD = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claPeriod")
        CRH_CUS1NO = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus1no")
        CRH_CUS2NO = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus2no")
        CRH_SALCUR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salcur")
        CRH_SALTTLAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salttlamt")
        CRH_GRSPFTAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_grspftamt")
        CRH_CALMTAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtamt")
        CRH_CALMTPER = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtper")
        CRH_CAREMAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caremamt")
        CRH_CAAMT_FINAL = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_final")
        CRH_CACUR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cacur")

        'If sClaimSts = "OPEN" Then
        CRH_CAREMAMT = CRH_CAREMAMT - CRH_CAAMT_FINAL * getExchangeRate(CRH_CACUR, CRH_SALCUR, "BuyRate")
        'Else
        'CRH_CAREMAMT = CRH_CAREMAMT + CRH_CAAMT_FINAL * getExchangeRate(CRH_CACUR, CRH_SALCUR, "BuyRate")
        'End If

        CRH_CUREXRAT = "1.0"
        CRH_CUREXEFFDAT = "01/01/1900"

        gspStr = "sp_update_CAREMHDR '" & CRH_COCDE & "','" & CRH_CLAPERIOD & "','" & CRH_CUS1NO & "','" & _
                                            CRH_CUS2NO & "','" & CRH_SALCUR & "','" & CRH_SALTTLAMT & "','" & _
                                            CRH_GRSPFTAMT & "','" & CRH_CALMTAMT & "','" & CRH_CALMTPER & "','" & _
                                            CRH_CAREMAMT & "','" & CRH_CUREXRAT & "','" & CRH_CUREXEFFDAT & "','" & _
                                            gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading update_claim_remain_tables sp_update_CAREMHDR :" & rtnStr)
            update_claim_remain_tables = False
            Exit Function
        End If

        Dim CRI_COCDE As String
        Dim CRI_CLAPERIOD As String
        Dim CRI_CUS1NO As String
        Dim CRI_CUS2NO As String
        Dim CRI_ITMNO As String
        Dim CRI_SALCUR As String
        Dim CRI_SALAMT As String
        Dim CRI_GRSPFTAMT As String
        Dim CRI_CALMTAMT As String
        Dim CRI_CALMTPER As String
        Dim CRI_CAREMAMT As String
        Dim CRI_CAAMT_FINAL As String
        Dim CRI_CACUR As String

        For i As Integer = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
            CRI_COCDE = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_cocde")
            CRI_CLAPERIOD = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claPeriod")
            CRI_CUS1NO = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus1no")
            CRI_CUS2NO = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus2no")
            CRI_ITMNO = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_itmno")
            CRI_SALCUR = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_salcur")
            CRI_SALAMT = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_salamt")
            CRI_GRSPFTAMT = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_grspftamt")
            CRI_CALMTAMT = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_calmtamt")
            CRI_CALMTPER = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_calmtper")
            CRI_CAREMAMT = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caremamt")
            CRI_CAAMT_FINAL = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_ttlcaamt_final")
            CRI_CACUR = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_cacur")

            'If sClaimSts = "OPEN" Then
            CRI_CAREMAMT = CRI_CAREMAMT - CRI_CAAMT_FINAL * getExchangeRate(CRI_CACUR, CRI_SALCUR, "BuyRate")
            'Else
            'CRI_CAREMAMT = CRI_CAREMAMT + CRI_CAAMT_FINAL * getExchangeRate(CRI_CACUR, CRI_SALCUR, "BuyRate")
            'End If

            gspStr = "sp_update_CAREMITM '" & CRI_COCDE & "','" & CRI_CLAPERIOD & "','" & CRI_CUS1NO & "','" & _
                                                CRI_CUS2NO & "','" & CRI_ITMNO & "','" & _
                                                CRI_SALCUR & "','" & CRI_SALAMT & "','" & CRI_GRSPFTAMT & "','" & _
                                                CRI_CALMTAMT & "','" & CRI_CALMTPER & "','" & _
                                                CRI_CAREMAMT & "','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading update_claim_remain_tables sp_update_CAREMITM :" & rtnStr)
                update_claim_remain_tables = False
                Exit Function
            End If
        Next

        update_claim_remain_tables = True
    End Function
    Public Sub mmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click
        If checkFocus(Me) Then Exit Sub
        Me.Cursor = Cursors.WaitCursor

        cboClaimPaySTS.Text = ""
        cboClaimIncomeSTS.Text = ""



        flag_cmdfind_process = True
        'If Enq_right_local = True Then
        '    sMode = cModeUpd
        '    Call formInit(cModeUpd)
        'Else
        '    sMode = cModeRead
        '    Call formInit(cModeRead)
        'End If

        flag_rbViewOn_click = False

        Dim i As Integer

        If txtClaimNo.Text = "" Then
            MsgBox("Please enter Claim No")
            txtClaimNo.Select()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If Len(txtClaimNo.Text) <> 9 Then
            MsgBox("Invalid Claim No")
            txtClaimNo.Select()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Dim sClaimNo As String

        sClaimNo = txtClaimNo.Text

        gspStr = "sp_select_CAORDHDR '','" & sClaimNo & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CAORDHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdFind_Click sp_select_CAORDHDR : " & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If rs_CAORDHDR.Tables.Count = 0 Then
            MsgBox("Table not found!")
            txtClaimNo.Select()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If rs_CAORDHDR.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("Record not found!")
            txtClaimNo.Select()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_SYUSRRIGHT_Check '" & cboCoCde.Text & "','" & gsUsrID & "','" & txtClaimNo.Text & "','" & "CL" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYUSRRIGHT_Check, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtQutNoKeyPress sp_select_SYUSRRIGHT_Check :" & rtnStr)
            Exit Sub
        End If
        If Not rs_SYUSRRIGHT_Check.Tables("RESULT") Is Nothing Then
            If rs_SYUSRRIGHT_Check.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("You have no Right access this document.")
                Me.Cursor = Windows.Forms.Cursors.Default


                Exit Sub
            Else
            End If
        Else
            MsgBox("Rights access error.")
            Me.Cursor = Windows.Forms.Cursors.Default

            Exit Sub
        End If



        Dim pricust As String
        pricust = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus1no")

        '''check pricust
        ''' 
        Dim pricust_found As Boolean

        gspStr = "sp_select_CUBASINF_PRI '" & "" & "','" & gsUsrID & "','" & "QU" & "'"
        'Fixing global company code problem at 20100420
        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        gspStr = ""
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then  '*** An error has occured
            MsgBox("Error on loading    sp_select_CUBASINF_PRI_CLM : " & rtnStr)
            Exit Sub
        Else
            rs_CUBASINF_P_CLM = rs.Copy() '*** Cus for company
        End If

        If rs_CUBASINF_P_CLM.Tables("RESULT").Rows.Count > 0 Then

            dr = rs_CUBASINF_P_CLM.Tables("RESULT").Select("cbi_cusno >= '50000'")


            If Not dr Is Nothing Then
                If dr.Length > 0 Then
                    For index As Integer = 0 To dr.Length - 1
                        If pricust = dr(index)("cbi_cusno") Then
                            pricust_found = True
                        End If
                    Next index
                End If
            End If
        Else
            ''MsgBox("There is no function, please contact EDP or System Administrator.")
            flag_cmdfind_process = False
            ' Exit Sub
        End If

        'If pricust_found <> True Then
        '    MsgBox("You have no rights to access this document.")
        '    Exit Sub
        'End If



        If pricust <> "" Then
            Call display_combo(pricust, cboPriCust)
            If cboPriCust.Text = pricust Then
                'MsgBox("You have no access right of customer!")
                cboPriCust.Text = ""
                txtClaimNo.Select()
                Me.Cursor = Cursors.Default
                ' Exit Sub
            End If
            cboPriCust.Text = ""
        End If

        'Get exchange rate
        rs_SYCUREX.Tables("RESULT").Rows.Clear()

        gspStr = "sp_list_SYCUREX '','" & Format(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_curexeffdat"), "MM/dd/yyyy") & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCUREX, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdFind_Click sp_list_SYCUREX :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_select_CAORDITM '','" & sClaimNo & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CAORDITM, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdFind_Click sp_select_CAORDITM : " & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_select_CAORDDTL '','" & sClaimNo & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CAORDDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdFind_Click sp_select_CAORDDTL : " & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        '''
        If rs_CAORDDTL.Tables("RESULT").Rows.Count <> 0 Then

            For i = 0 To rs_CAORDDTL.Tables("RESULT").Columns.Count - 1
                rs_CAORDDTL.Tables("RESULT").Columns(i).ReadOnly = False
            Next i

            Dim tmp_seq_dtl As Integer
            tmp_seq_dtl = rs_CAORDDTL.Tables("RESULT").Rows(0).Item("CAD_CAORDSEQ")
            Call display_CAORDDTL(tmp_seq_dtl)
        End If


        ' ''If rs_CAORDITM.Tables.Count = 0 Or rs_CAORDDTL.Tables.Count = 0 Then
        ' ''    MsgBox("Record not found!")
        ' ''    txtClaimNo.Select()
        ' ''    Me.Cursor = Cursors.Default
        ' ''    Exit Sub
        ' ''End If

        '' ''If rs_CAORDITM.Tables("RESULT").Rows.Count = 0 Or rs_CAORDDTL.Tables("RESULT").Rows.Count = 0 Then
        '' ''    MsgBox("Record not found!")
        '' ''    txtClaimNo.Select()
        '' ''    Me.Cursor = Cursors.Default
        '' ''    Exit Sub
        '' ''End If

        'maybe need cocde   
        ' ''gspStr = "sp_select_CAREMHDR '" + rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claPeriod") + "','" + _
        ' ''            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus1no") + "','" + _
        ' ''            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus2no") + "'"
        ' ''rtnLong = execute_SQLStatement(gspStr, rs_CAREMHDR, rtnStr)
        ' ''If rtnLong <> RC_SUCCESS Then
        ' ''    MsgBox("Error on loading cmdFind_Click sp_select_CAREMHDR : " & rtnStr)
        ' ''    Exit Sub
        ' ''End If

        ' ''gspStr = "sp_select_CAREMITM '" + rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claPeriod") + "','" + _
        ' ''            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus1no") + "','" + _
        ' ''            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus2no") + "'"
        ' ''rtnLong = execute_SQLStatement(gspStr, rs_CAREMITM, rtnStr)
        ' ''If rtnLong <> RC_SUCCESS Then
        ' ''    MsgBox("Error on loading cmdFind_Click sp_select_CAREMITM : " & rtnStr)
        ' ''    Exit Sub
        ' ''End If

        sClaimStatus = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts")

        If Enq_right_local Then
            If (sClaimStatus = "CANL" Or sClaimStatus = "CLOS") Then
                Call setStatus(cModeRead)
                mode = cModeRead
                mmdClear.Enabled = True

                If sClaimStatus = "CANL" Then
                    CmdViewReason.Enabled = True
                End If

                'mode = cModeRead
                'formInit(mode)
            Else
                Call setStatus(cModeUpd)
                mode = cModeUpd

                'mode = cModeUpd
                'formInit(mode)
            End If
        Else
            Call setStatus(cModeRead)
            mode = cModeRead
            'formInit(mode)
        End If

        For i = 0 To rs_CAORDHDR.Tables("RESULT").Columns.Count - 1
            rs_CAORDHDR.Tables("RESULT").Columns(i).ReadOnly = False
        Next i

        If Not rs_CAORDITM.Tables("RESULT").Rows.Count = 0 Then
            For i = 0 To rs_CAORDITM.Tables("RESULT").Columns.Count - 1
                rs_CAORDITM.Tables("RESULT").Columns(i).ReadOnly = False
            Next
        Else
            ''' for no detail ref case
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False

        End If

        If Not rs_CAORDDTL.Tables("RESULT").Rows.Count = 0 Then
            For i = 0 To rs_CAORDDTL.Tables("RESULT").Columns.Count - 1
                rs_CAORDDTL.Tables("RESULT").Columns(i).ReadOnly = False
            Next i

        End If

        Recorddisplay = True

        display_CAORDHDR()
        'Call ori_lost_focus12()


        Call final_lost_focus12_nomsg()

        ' txt_Hdr_ClaimToHKOAmt_ori.ForeColor = Color.Black
        '  txt_Hdr_ClaimToHKOAmt.ForeColor = Color.Black



        display_CAORDITM(0)
        display_CAORDDTL(0)

        '''20140328
        Call set_app_buttons()





        'update_claim_remain_after_find()

        If Not sHdrClaimAmtPer = "C" Then
            If nHdrSearchBy = 1 Then
                rbViewOn_I.Checked = True
                format_dgSummary()
                dgSummary.DataSource = rs_CAORDITM.Tables("RESULT").DefaultView
            Else
                rbViewOn_S.Checked = True
                format_dgSummary()
                dgSummary.DataSource = rs_CAORDDTL.Tables("RESULT").DefaultView
            End If
            format_dgSummary()
            Set_Approval_Right_for_dgSummary(cModeInit)
        End If

        If sHdrClaimAmtPer = "C" Then
            Me.btcCLM00001.SelectedIndex = 0
            format_dgSummary()
            'format_Approval(0)
        Else
            'Me.btcCLM00001.SelectedIndex = 2
            Me.btcCLM00001.SelectedIndex = 0
            format_dgSummary()
        End If


        If sHdrClaimAmtPer = "C" Then
            display_CAORDHDR()
            display_CAORDITM(0)
            display_CAORDDTL(0)
            btcCLM00001.SelectedIndex = 0
        Else
            If sHdrClaimAmtPer = "I" Then
                display_CAORDHDR()
                display_CAORDDTL(0)
                display_CAORDITM(0)
                rbViewOn_I.Checked = True
            Else
                display_CAORDHDR()
                display_CAORDITM(0)
                display_CAORDDTL(0)
                rbViewOn_S.Checked = True
            End If
            btcCLM00001.SelectedIndex = 0
        End If

        Me.Cursor = Cursors.Default

        Recorddisplay = False

        '''20131205
        ''' 
        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "CANL" Then
            cmdPanOK.Enabled = False
            If gsUsrRank < 2 Then
                cmdPanOK.Enabled = True
            End If
            If gsUsrRank < 4 Then
                CmdViewReason.Enabled = True
            End If
        End If

        '''
        If mode = cModeRead Then
            format_dgSummary()
            dgSummary.DataSource = rs_CAORDDTL.Tables("RESULT").DefaultView
            rs_CAORDDTL.Tables("RESULT").AcceptChanges()
            format_dgSummary()
            dgSummary.DataSource = rs_CAORDDTL.Tables("RESULT").DefaultView
            rs_CAORDDTL.Tables("RESULT").AcceptChanges()
            format_dgSummary()

            flag_cmdfind_process = False

            mmdFind.Enabled = False
            mmdSearch.Enabled = False
            Recordstatus = False
            Exit Sub
        End If

        '''
        cboClaimPeriod.Enabled = False
        mmdDelRow.Enabled = True
        mmdFind.Enabled = False

        mmdSave.Enabled = True
        mmdAttach.Enabled = True

        '''
        If sClaimStatus = "CLOS" Then


            If Microsoft.VisualBasic.Left(temp_yup_usrgrp, 3) = "ACT" Then

                chkconfirmclm.Enabled = False
                chkvalidclm.Enabled = False

                mmdInsRow.Enabled = False
                mmdDelRow.Enabled = False
                cmd_attch.Enabled = False
                mmdAttach.Enabled = False
                mmdSave.Enabled = True
            Else

                chkconfirmclm.Enabled = False
                chkvalidclm.Enabled = False

                mmdInsRow.Enabled = False
                mmdDelRow.Enabled = False
                cmd_attch.Enabled = False
                mmdAttach.Enabled = False
                mmdSave.Enabled = False
            End If
        End If

        '''20140305

        '''need to check user-group & rank
        'gsUsrGrp
        'checking
        Dim temp_claim_type_a As String
        Dim temp_claim_type_b As String
        temp_claim_type_a = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a")
        temp_claim_type_b = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b")

        '''
        Call setall_readmode()

        If Microsoft.VisualBasic.Left(temp_yup_usrgrp, 3) = "ACT" _
        And Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a") = "APV2a" Or rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = "APV2b") Then
            setStatus(cModeRead)
        End If


        ''''' michael page2 account use
        If Microsoft.VisualBasic.Left(temp_yup_usrgrp, 3) = "ACT" Then
            gb_pay.Enabled = True
            gb_income.Enabled = True
            mmdSave.Enabled = True

            If sClaimStatus = "RELS" Then
                If Del_right_local = True Then
                    If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a") = "APV2a" Or rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a") = "APV3a" Then
                        chkapv3a.Enabled = True
                    End If

                    If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = "APV2b" Or rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = "APV3b" Then
                        chkapv3b.Enabled = True
                    End If

                    If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a") = "APV3a" And _
                        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = "APV3b" Then
                        cmd_close.Enabled = True
                        txt_Hdr_AcctClaimAmt.Enabled = True
                    End If
                Else
                    cmd_close.Enabled = False
                    chkapv3a.Enabled = False
                    chkapv3b.Enabled = False
                End If
            ElseIf sClaimStatus = "CLOS" Then
                cmd_close.Enabled = False
                chkapv3a.Enabled = False
                chkapv3b.Enabled = False
            End If
        Else
            txt_Hdr_AcctClaimAmt.Enabled = False

        End If
        'End If



        If Split(cboClaimSts.Text, " - ")(0) = "OPEN" Then
            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "SAL" Or gsUsrRank < 3 Then
                cbo_Hdr_ClaimAmtCurrency.Enabled = True
                txt_Hdr_OrgClaimAmt.Enabled = True
                txt_Hdr_FinalClaimAmt.Enabled = True
                txt_Hdr_ClaimToInsAmt.Enabled = True
                txt_Hdr_ClaimToVNAmt.Enabled = True
                txt_Hdr_ClaimToHKOAmt.Enabled = True

                If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                    txt_cmt_a.Enabled = True
                    txt_cmt_a.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                    txt_cmt_a.ReadOnly = False
                Else
                    txt_cmt_a.Enabled = True
                End If

                txt_Hdr_ClaimToInsAmt_ori.Enabled = True
                cbo_Hdr_ClaimToInsAmtCur.Enabled = True
                txt_Hdr_ClaimToVNAmt_ori.Enabled = True
                cbo_Hdr_ClaimToVNAmtCur.Enabled = True
                txt_Hdr_ClaimToHKOAmt_ori.Enabled = True
                cbo_Hdr_ClaimToHKOAmtCur.Enabled = True
                If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                    txt_cmt_b.Enabled = True
                    txt_cmt_b.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                    txt_cmt_b.ReadOnly = False
                Else
                    txt_cmt_b.Enabled = True
                End If


            Else
                mmdAdd.Enabled = False
            End If

            Call set_app_buttons()

        End If
        'If Split(cboClaimSts.Text, " - ")(0) = "APV1a" Then
        '    If gsUsrRank < 4 Then
        '        chkapv1a.Enabled = False
        '        chkapv1b.Enabled = True
        '    Else
        '        chkapv1a.Enabled = False
        '        chkapv1b.Enabled = False
        '    End If
        'End If

        If (temp_claim_type_a = "APV1a") And _
        gsUsrRank < 4 Then
            cbo_Hdr_ClaimAmtCurrency.Enabled = True
            txt_Hdr_OrgClaimAmt.Enabled = True
            txt_Hdr_FinalClaimAmt.Enabled = True

        End If
        If (temp_claim_type_b = "APV1b") And _
        gsUsrRank < 4 Then
            txt_Hdr_ClaimToInsAmt.Enabled = True
            txt_Hdr_ClaimToVNAmt.Enabled = True
            txt_Hdr_ClaimToHKOAmt.Enabled = True

            txt_Hdr_ClaimToInsAmt_ori.Enabled = True
            cbo_Hdr_ClaimToInsAmtCur.Enabled = True
            txt_Hdr_ClaimToVNAmt_ori.Enabled = True
            cbo_Hdr_ClaimToVNAmtCur.Enabled = True
            txt_Hdr_ClaimToHKOAmt_ori.Enabled = True
            cbo_Hdr_ClaimToHKOAmtCur.Enabled = True


        End If

        If (temp_claim_type_a = "APV2a") Then
            cbo_Hdr_ClaimAmtCurrency.Enabled = False
            txt_Hdr_OrgClaimAmt.Enabled = False
            txt_Hdr_FinalClaimAmt.Enabled = False
        End If
        If (temp_claim_type_b = "APV2b") Then
            txt_Hdr_ClaimToInsAmt.Enabled = False
            txt_Hdr_ClaimToVNAmt.Enabled = False
            txt_Hdr_ClaimToHKOAmt.Enabled = False

            txt_Hdr_ClaimToInsAmt_ori.Enabled = False
            cbo_Hdr_ClaimToInsAmtCur.Enabled = False
            txt_Hdr_ClaimToVNAmt_ori.Enabled = False
            cbo_Hdr_ClaimToVNAmtCur.Enabled = False
            txt_Hdr_ClaimToHKOAmt_ori.Enabled = False
            cbo_Hdr_ClaimToHKOAmtCur.Enabled = False

        End If



        If Microsoft.VisualBasic.Left(temp_yup_usrgrp, 3) = "ACT" Then
            mmdAdd.Enabled = False
        End If


        '''need check open or..
        ''' 
        '      chkapv1a.Enabled = True
        'chkapv1b.Enabled = True

        ''''tmp
        'Call setStatus(cModeRead)

        'cboClaimSts.Text = "CANL -Cancle"




        format_dgSummary()
        dgSummary.DataSource = rs_CAORDDTL.Tables("RESULT").DefaultView
        rs_CAORDDTL.Tables("RESULT").AcceptChanges()
        format_dgSummary()
        dgSummary.DataSource = rs_CAORDDTL.Tables("RESULT").DefaultView
        rs_CAORDDTL.Tables("RESULT").AcceptChanges()
        format_dgSummary()

        btcCLM00001.SelectedIndex = 0

        flag_cmdfind_process = False

        ''grey
        If rbClaimBy_C.Checked = True Then
            txt_Hdr_ClaimToInsAmt_ori.Enabled = False
            cbo_Hdr_ClaimToInsAmtCur.Enabled = False
            txt_Hdr_ClaimToInsAmt.Enabled = False
        ElseIf rbClaimBy_V.Checked = True Then
            txt_Hdr_ClaimToVNAmt_ori.Enabled = False
            cbo_Hdr_ClaimToVNAmtCur.Enabled = False
            txt_Hdr_ClaimToVNAmt.Enabled = False
        ElseIf rbClaimBy_U.Checked = True Then
            cbo_Hdr_ClaimToHKOAmtCur.Enabled = False
            txt_Hdr_ClaimToHKOAmt_ori.Enabled = False
            txt_Hdr_ClaimToHKOAmt.Enabled = False
        End If


        ''**
        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a") = "APV3a" Then
            chkapv2a.Enabled = False
        End If

        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = "APV3b" Then
            chkapv2b.Enabled = False
        End If


        Recordstatus = False

        If sClaimStatus <> "OPEN" Then
            txt_ref_no.Enabled = False
            dt_ref_date.Enabled = False


            chkreplace.Enabled = False
            'txt_Hdr_CustComment.Enabled = False    



            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) <> "HAH" Then

                txt_Hdr_CustComment.Enabled = True

                txt_Hdr_CustComment.ReadOnly = True
                'txt_Hdr_Rmk.Enabled = False     

                txt_Hdr_Rmk.Enabled = True

                txt_Hdr_Rmk.ReadOnly = True
                'txt_Hdr_Finding.Enabled = False     

                txt_Hdr_Finding.Enabled = True

                txt_Hdr_Finding.ReadOnly = True


            Else

                txt_Hdr_Rmk.Enabled = False
                txt_Hdr_Finding.Enabled = False
                txt_Hdr_CustComment.Enabled = False

            End If


        End If


        Call set_sal_mgt_cmt()

        If sClaimStatus = "APRV" Then

            cbo_Hdr_ClaimAmtCurrency.Enabled = False
            txt_Hdr_OrgClaimAmt.Enabled = False
            txt_Hdr_FinalClaimAmt.Enabled = False

            cbo_Hdr_ClaimToInsAmtCur.Enabled = False
            cbo_Hdr_ClaimToVNAmtCur.Enabled = False
            cbo_Hdr_ClaimToHKOAmtCur.Enabled = False

            txt_Hdr_ClaimToInsAmt_ori.Enabled = False
            txt_Hdr_ClaimToVNAmt_ori.Enabled = False
            txt_Hdr_ClaimToHKOAmt_ori.Enabled = False

            txt_Hdr_ClaimToInsAmt.Enabled = False
            txt_Hdr_ClaimToVNAmt.Enabled = False
            txt_Hdr_ClaimToHKOAmt.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False

            ' cmd_attch.Enabled = False



        End If


        If rbClaimBy_C.Checked = True Then
            cbo_Hdr_ClaimToHKOAmtCur.Enabled = False
        End If
        If rbClaimBy_V.Checked = True Then
            cbo_Hdr_ClaimToHKOAmtCur.Enabled = False
        End If

        If sClaimStatus = "WAIT" Or sClaimStatus = "APRV" Then
            If gsUsrRank < 3 Then
                If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                    txt_cmt_a.Enabled = True
                    txt_cmt_a.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                    txt_cmt_a.ReadOnly = False
                Else
                    txt_cmt_a.Enabled = True
                End If

                If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                    txt_cmt_b.Enabled = True
                    txt_cmt_b.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                    txt_cmt_b.ReadOnly = False
                Else
                    txt_cmt_b.Enabled = True
                End If

            End If
        End If

        Recordstatus = False


    End Sub

    Private Sub txtClaimNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClaimNo.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            Call mmdFind_Click(sender, e)
        End If
    End Sub

    Private Sub cal_ClaimAmt_CAORDHDR()
        Dim sClaimAmtCurrency As String = "USD"
        Dim nOrgClaimAmt As Decimal = "0.00"
        Dim nFinalClaimAmt As Decimal = "0.00"
        Dim nCaToInsAmt As Decimal = "0.00"
        Dim nCaToVnAmt As Decimal = "0.00"
        Dim nCaToHkoAmt As Decimal = "0.00"

        For index As Integer = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
            '''20131114tmp field not ddefined yet
            '''If rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_del") <> "Y" Then
            sClaimAmtCurrency = rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_cacur")

            nOrgClaimAmt = nOrgClaimAmt + rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_ttlcaamt_org") _
                            * getExchangeRate(sClaimAmtCurrency, "USD", "Buyrate")

            nFinalClaimAmt = nFinalClaimAmt + rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_ttlcaamt_final") _
                            * getExchangeRate(sClaimAmtCurrency, "USD", "Buyrate")

            nCaToInsAmt = nCaToInsAmt + rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_catoinsamt") _
                            * getExchangeRate(sClaimAmtCurrency, "USD", "Buyrate")

            nCaToVnAmt = nCaToVnAmt + rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_catovnamt") _
                            * getExchangeRate(sClaimAmtCurrency, "USD", "Buyrate")

            nCaToHkoAmt = nCaToHkoAmt + rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_catohkoamt") _
                            * getExchangeRate(sClaimAmtCurrency, "USD", "Buyrate")
            '''End If
        Next

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cacur") = sClaimAmtCurrency
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_org") = nOrgClaimAmt
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_final") = nFinalClaimAmt
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoinscur") = sClaimAmtCurrency
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoinsamt") = nCaToInsAmt
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catovncur") = sClaimAmtCurrency
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catovnamt") = nCaToVnAmt
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catohkocur") = sClaimAmtCurrency
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catohkoamt") = nCaToHkoAmt

        If Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Or _
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~" Or _
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~" Or _
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*DEL*~") Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~"
        End If
    End Sub

    Private Sub cal_ClaimAmt_CAORDITM()


        If rs_CAORDITM.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        If rs_CAORDDTL.Tables("result") Is Nothing Then
            Exit Sub
        End If

        If sHdrClaimAmtPer = "C" Then
            'For from HDR = ALL
            'If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_final") > 0 Then
            Dim nTtlSalAmt As Decimal = "0.00"
            Dim nItmSalAmt As Decimal = "0.00"
            Dim nAmtRatio As Decimal = "0.00"

            Dim sClaimAmtCurrency_HDR As String = "USD"
            Dim nOrgClaimAmt_HDR As Decimal = "0.00"
            Dim nFinalClaimAmt_HDR As Decimal = "0.00"
            Dim nCaToInsAmt_HDR As Decimal = "0.00"
            Dim nCaToVnAmt_HDR As Decimal = "0.00"
            Dim nCaToHkoAmt_HDR As Decimal = "0.00"


            For index As Integer = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1

                If rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_del") <> "Y" Then
                    nTtlSalAmt = nTtlSalAmt + rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_salamt")
                End If

            Next

            For index1 As Integer = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
                If rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_del") <> "Y" Then

                    nItmSalAmt = rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_salamt")

                    'Item Ratio (Item over overall)
                    If nTtlSalAmt = 0 Then
                        nAmtRatio = 0
                    Else
                        nAmtRatio = nItmSalAmt / nTtlSalAmt
                    End If

                    sClaimAmtCurrency_HDR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cacur")

                    If IsDBNull(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_org")) Then
                        Exit Sub
                    End If
                    nOrgClaimAmt_HDR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_org") * nAmtRatio
                    nFinalClaimAmt_HDR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_final") * nAmtRatio
                    nCaToInsAmt_HDR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoinsamt") * nAmtRatio
                    nCaToVnAmt_HDR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catovnamt") * nAmtRatio
                    nCaToHkoAmt_HDR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catohkoamt") * nAmtRatio

                    rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_cacur") = sClaimAmtCurrency_HDR
                    rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_caamt_org") = nOrgClaimAmt_HDR
                    rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_caamt_final") = nFinalClaimAmt_HDR
                    rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_ttlcaamt_org") = nOrgClaimAmt_HDR
                    rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_ttlcaamt_final") = nFinalClaimAmt_HDR
                    rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_catoinscur") = sClaimAmtCurrency_HDR
                    rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_catoinsamt") = nCaToInsAmt_HDR
                    rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_catovncur") = sClaimAmtCurrency_HDR
                    rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_catovnamt") = nCaToVnAmt_HDR
                    rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_catohkocur") = sClaimAmtCurrency_HDR
                    rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_catohkoamt") = nCaToHkoAmt_HDR

                    If Not (rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_creusr") = "~*ADD*~" Or _
                            rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_creusr") = "~*NEW*~" Or _
                            rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_creusr") = "~*UPD*~" Or _
                            rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_creusr") = "~*DEL*~") Then
                        rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_creusr") = "~*UPD*~"
                    End If
                End If
            Next
            'End If
        Else

            'For from DTL = Item No
            For index As Integer = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
                Dim sClaimAmtCurrency As String = "USD"
                Dim nOrgClaimAmt As Decimal = "0.00"
                Dim nFinalClaimAmt As Decimal = "0.00"
                Dim nCaToInsAmt As Decimal = "0.00"
                Dim nCaToVnAmt As Decimal = "0.00"
                Dim nCaToHkoAmt As Decimal = "0.00"

                For index1 As Integer = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
                    If rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_itmno") = rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_itmno") Then
                        If rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_del") <> "Y" Then

                            sClaimAmtCurrency = rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_cacur")
                            '''just sum up same item
                            nOrgClaimAmt = nOrgClaimAmt + rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_ttlcaamt_org") _
                                            * getExchangeRate(sClaimAmtCurrency, "USD", "Buyrate")

                            nFinalClaimAmt = nFinalClaimAmt + rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_ttlcaamt_final") _
                                            * getExchangeRate(sClaimAmtCurrency, "USD", "Buyrate")

                            nCaToInsAmt = nCaToInsAmt + rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_catoinsamt") _
                                            * getExchangeRate(sClaimAmtCurrency, "USD", "Buyrate")

                            nCaToVnAmt = nCaToVnAmt + rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_catovnamt") _
                                            * getExchangeRate(sClaimAmtCurrency, "USD", "Buyrate")

                            nCaToHkoAmt = nCaToHkoAmt + rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_catohkoamt") _
                                            * getExchangeRate(sClaimAmtCurrency, "USD", "Buyrate")
                        End If
                    End If
                Next

                rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_cacur") = "USD"
                rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_caamt_org") = nOrgClaimAmt
                rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_caamt_final") = nFinalClaimAmt
                rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_ttlcaamt_org") = nOrgClaimAmt
                rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_ttlcaamt_final") = nFinalClaimAmt
                rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_catoinscur") = "USD"
                rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_catoinsamt") = nCaToInsAmt
                rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_catovncur") = "USD"
                rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_catovnamt") = nCaToVnAmt
                rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_catohkocur") = "USD"
                rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_catohkoamt") = nCaToHkoAmt

                If Not (rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_creusr") = "~*ADD*~" Or _
                        rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_creusr") = "~*NEW*~" Or _
                        rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_creusr") = "~*UPD*~" Or _
                        rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_creusr") = "~*DEL*~") Then
                    rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_creusr") = "~*UPD*~"
                End If
            Next
        End If
    End Sub

    Private Sub cal_ClaimAmt_CAORDDTL()
        If rs_CAORDITM.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        For index As Integer = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
            'If rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_caamt_final") > 0 Then
            Dim nTtlSalAmt As Decimal = "0.00"
            Dim nItmSalAmt As Decimal = "0.00"
            Dim nAmtRatio As Decimal = "0.00"

            Dim sClaimAmtCurrency_DTL As String = "USD"
            Dim nOrgClaimAmt_DTL As Decimal = "0.00"
            Dim nFinalClaimAmt_DTL As Decimal = "0.00"
            Dim nCaToInsAmt_DTL As Decimal = "0.00"
            Dim nCaToVnAmt_DTL As Decimal = "0.00"
            Dim nCaToHkoAmt_DTL As Decimal = "0.00"

            For index1 As Integer = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
                If rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_itmno") = rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_itmno") Then
                    If rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_del") <> "Y" Then


                        nTtlSalAmt = nTtlSalAmt + rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_salamt") _
                                        * getExchangeRate(rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_salcur"), _
                                        rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_salcur"), "Buyrate")


                    End If
                End If
            Next

            For index1 As Integer = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
                If rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_itmno") = rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_itmno") Then
                    If rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_del") <> "Y" Then


                        nItmSalAmt = rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_salamt") _
                                        * getExchangeRate(rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_salcur"), _
                                        rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_salcur"), "Buyrate")

                        If nTtlSalAmt = 0 Then
                            nAmtRatio = 0
                        Else
                            nAmtRatio = nItmSalAmt / nTtlSalAmt
                        End If


                        sClaimAmtCurrency_DTL = rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_cacur")
                        nOrgClaimAmt_DTL = rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_ttlcaamt_org") * nAmtRatio
                        nFinalClaimAmt_DTL = rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_ttlcaamt_final") * nAmtRatio
                        nCaToInsAmt_DTL = rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_catoinsamt") * nAmtRatio
                        nCaToVnAmt_DTL = rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_catovnamt") * nAmtRatio
                        nCaToHkoAmt_DTL = rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_catohkoamt") * nAmtRatio

                        rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_cacur") = sClaimAmtCurrency_DTL
                        rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_caamt_org") = nOrgClaimAmt_DTL
                        rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_caamt_final") = nFinalClaimAmt_DTL
                        rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_ttlcaamt_org") = nOrgClaimAmt_DTL
                        rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_ttlcaamt_final") = nFinalClaimAmt_DTL
                        rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_catoinscur") = sClaimAmtCurrency_DTL
                        rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_catoinsamt") = nCaToInsAmt_DTL
                        rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_catovncur") = sClaimAmtCurrency_DTL
                        rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_catovnamt") = nCaToVnAmt_DTL
                        rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_catohkocur") = sClaimAmtCurrency_DTL
                        rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_catohkoamt") = nCaToHkoAmt_DTL

                        If Not (rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_creusr") = "~*ADD*~" Or _
                                rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_creusr") = "~*NEW*~" Or _
                                rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_creusr") = "~*UPD*~" Or _
                                rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_creusr") = "~*DEL*~") Then
                            rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_creusr") = "~*UPD*~"
                        End If
                    End If
                End If
            Next
            'End If
        Next
    End Sub

    Private Sub txt_Hdr_OrgClaimAmt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Hdr_OrgClaimAmt.GotFocus
        '        flag_keypress_txt_Hdr_OrgClaimAmt = True

    End Sub

    Private Sub txt_Hdr_OrgClaimAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Hdr_OrgClaimAmt.KeyPress
        flag_keypress_txt_Hdr_OrgClaimAmt = True

        flag_keypress_txt_Hdr_OrgClaimAmt = True

        If mode = cModeAdd Then
            If e.KeyChar.Equals(Chr(13)) Then
                'If cbAdhoc.Checked = True Then
                '    cmdInsRow.Enabled = True
                '    cmdDelRow.Enabled = True
                '    cmdQuickInsert.Enabled = True

                '    cmdQuickInsert.Visible = False
                '    cmdInsRow.Visible = True

                '    btcCLM00001.TabPages(1).Enabled = True
                '    btcCLM00001.TabPages(2).Enabled = True
                'Else
                'cmdQuickInsert.Visible = True
                'cmdInsRow.Visible = False
                'End If

                '        Call format_inputHdr_FinalClaimAmt_after()
                Exit Sub
            End If
        End If

        Dim allowedChars As String = "0123456789."

        If allowedChars.IndexOf(e.KeyChar) = -1 Then
            ' Invalid Character
            e.KeyChar = ""
            Exit Sub
        End If

        Dim currenttext As String

        currenttext = txt_Hdr_OrgClaimAmt.Text & e.KeyChar

        'check for only 1.
        If e.KeyChar = "." Then
            If Mid(currenttext, 1, Len(currenttext) - 1).IndexOf(".") <> -1 Then
                e.KeyChar = ""
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txt_Hdr_OrgClaimAmt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Hdr_OrgClaimAmt.KeyUp
        'If Not IsNumeric(txt_Hdr_OrgClaimAmt.Text) Then
        '    Exit Sub
        'End If

        If e.KeyCode <> Keys.Decimal Or txt_Hdr_OrgClaimAmt.Text.IndexOf(".") <> txt_Hdr_OrgClaimAmt.Text.Length - 1 Then
            Dim pos As Integer = txt_Hdr_OrgClaimAmt.SelectionStart
            If e.KeyCode = Keys.Back And txt_Hdr_OrgClaimAmt.Text.Length > 0 Then
                If pos = txt_Hdr_OrgClaimAmt.Text.Length Then
                    txt_Hdr_OrgClaimAmt.Text = txt_Hdr_OrgClaimAmt.Text.Substring(0, txt_Hdr_OrgClaimAmt.Text.Length - 1)
                    txt_Hdr_OrgClaimAmt.Select(pos, 0)
                ElseIf pos > 0 And pos < txt_Hdr_OrgClaimAmt.Text.Length Then
                    txt_Hdr_OrgClaimAmt.Text = _
                    txt_Hdr_OrgClaimAmt.Text.Substring(0, pos - 1) + _
                    txt_Hdr_OrgClaimAmt.Text.Substring(pos, txt_Hdr_OrgClaimAmt.Text.Length - pos)
                    txt_Hdr_OrgClaimAmt.Select(pos - 1, 0)
                End If
            End If

            If txt_Hdr_OrgClaimAmt.Text.Length = 0 Then
                txt_Hdr_OrgClaimAmt.Text = "0.00"
            Else
                txt_Hdr_OrgClaimAmt.Text = Decimal.Round(Convert.ToDecimal(txt_Hdr_OrgClaimAmt.Text), 2)
            End If
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_org") = txt_Hdr_OrgClaimAmt.Text

            If Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Or _
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~" Or _
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~" Or _
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*DEL*~") Then
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~"
            End If

            'cal_ClaimAmt_CAORDITM()
            'cal_ClaimAmt_CAORDDTL()

            Recordstatus = True
        End If
    End Sub

    Private Sub txt_Hdr_OrgClaimAmt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Hdr_OrgClaimAmt.LostFocus

        If txt_Hdr_ClaimToInsAmt_ori.Enabled = True Then

            'txt_Hdr_ClaimToInsAmt_ori.Focus()
            'txt_Hdr_ClaimToInsAmt_ori.Focus()
            'txt_Hdr_ClaimToInsAmt_ori.Focus()
        Else
            'txt_Hdr_ClaimToVNAmt_ori.Focus()
            'txt_Hdr_ClaimToVNAmt_ori.Focus()
            'txt_Hdr_ClaimToVNAmt_ori.Focus()

        End If

        'flag_keypress_txt_Hdr_OrgClaimAmt = True

        ''If rs_CAORDHDR.Tables("RESULT") Is Nothing Then
        ''    Exit Sub
        ''End If
        ''txt_Hdr_OrgClaimAmt.Text = sReformatCurrency(txt_Hdr_OrgClaimAmt.Text)
        ''rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_org") = txt_Hdr_OrgClaimAmt.Text

        ''If txt_Hdr_OrgClaimAmt.Text <> "0" And txt_Hdr_OrgClaimAmt.Text <> "0.00" Or _
        ''   txt_Hdr_FinalClaimAmt.Text <> "0" And txt_Hdr_FinalClaimAmt.Text <> "0.00" Then
        ''    'format_Approval(0)
        ''    '    ClaimAmt_Header = True
        ''    'Else
        ''    '    ClaimAmt_Header = False
        ''End If

        ' ''If Not ClaimAmt_Header Then
        ' ''    calculate_CAORDHDR()
        ' ''Else
        ' ''    'format_Approval(0)
        ' ''End If
    End Sub

    Private Sub txt_Hdr_FinalClaimAmt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Hdr_FinalClaimAmt.GotFocus
        '        flag_keypress_txt_Hdr_FinalClaimAmt = True

    End Sub

    Private Sub txt_Hdr_FinalClaimAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Hdr_FinalClaimAmt.KeyPress
        flag_keypress_txt_Hdr_FinalClaimAmt = True

        'If mode = cModeAdd Then
        '    If e.KeyChar.Equals(Chr(13)) Then
        '        'If cbAdhoc.Checked = True Then
        '        '    cmdInsRow.Enabled = True
        '        '    cmdDelRow.Enabled = True
        '        '    cmdQuickInsert.Enabled = True

        '        '    cmdQuickInsert.Visible = False
        '        '    cmdInsRow.Visible = True

        '        '    btcCLM00001.TabPages(1).Enabled = True
        '        '    btcCLM00001.TabPages(2).Enabled = True
        '        'Else
        '        'cmdQuickInsert.Visible = True
        '        'cmdInsRow.Visible = False
        '        'End If

        '        Call format_inputHdr_FinalClaimAmt_after()
        '        Exit Sub
        '    End If
        'End If

        'Dim allowedChars As String = "0123456789."

        'If allowedChars.IndexOf(e.KeyChar) = -1 Then
        '    ' Invalid Character
        '    e.KeyChar = ""
        '    Exit Sub
        'End If

        'Dim currenttext As String
        'If txt_Hdr_FinalClaimAmt.Text = "0.00" Then
        '    currenttext = e.KeyChar
        'Else
        '    currenttext = txt_Hdr_FinalClaimAmt.Text & e.KeyChar
        'End If

        ''check for only 1.
        'If e.KeyChar = "." Then
        '    If Mid(currenttext, 1, Len(currenttext) - 1).IndexOf(".") <> -1 Then
        '        e.KeyChar = ""
        '        Exit Sub
        '    End If
        'End If
    End Sub

    Private Sub txt_Hdr_FinalClaimAmt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Hdr_FinalClaimAmt.KeyUp
        'calculate claim vs gp %
        'If Not IsNumeric(txt_Hdr_FinalClaimAmt.Text) Then
        '    Exit Sub
        'End If

        'If e.KeyCode <> Keys.Decimal Or txt_Hdr_FinalClaimAmt.Text.IndexOf(".") <> txt_Hdr_FinalClaimAmt.Text.Length - 1 Then
        '    Dim pos As Integer = txt_Hdr_FinalClaimAmt.SelectionStart
        '    If e.KeyCode = Keys.Back And txt_Hdr_FinalClaimAmt.Text.Length > 0 Then
        '        If pos = txt_Hdr_FinalClaimAmt.Text.Length Then
        '            txt_Hdr_FinalClaimAmt.Text = txt_Hdr_FinalClaimAmt.Text.Substring(0, txt_Hdr_FinalClaimAmt.Text.Length - 1)
        '            txt_Hdr_FinalClaimAmt.Select(pos, 0)
        '        ElseIf pos > 0 And pos < txt_Hdr_FinalClaimAmt.Text.Length Then
        '            txt_Hdr_FinalClaimAmt.Text = _
        '            txt_Hdr_FinalClaimAmt.Text.Substring(0, pos - 1) + _
        '            txt_Hdr_FinalClaimAmt.Text.Substring(pos, txt_Hdr_FinalClaimAmt.Text.Length - pos)
        '            txt_Hdr_FinalClaimAmt.Select(pos - 1, 0)
        '        End If
        '    End If

        '    If txt_Hdr_FinalClaimAmt.Text.Length = 0 Then
        '        txt_Hdr_FinalClaimAmt.Text = "0.00"
        '    Else
        '        txt_Hdr_FinalClaimAmt.Text = Decimal.Round(Convert.ToDecimal(txt_Hdr_FinalClaimAmt.Text), 2)
        '    End If
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_final") = txt_Hdr_FinalClaimAmt.Text

        '    If Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Or _
        '        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~" Or _
        '        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~" Or _
        '        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*DEL*~") Then
        '        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~"
        '    End If

        '    'Dim total_grpfamt As Decimal
        '    'Dim cavsgrpfper As Decimal
        '    'If IsNumeric(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_grspftamt")) Then
        '    '    total_grpfamt = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_grspftamt")
        '    '    If total_grpfamt > 0 Then
        '    '        If IsNumeric(txt_Hdr_FinalClaimAmt.Text) Then
        '    '            cavsgrpfper = (txt_Hdr_FinalClaimAmt.Text / total_grpfamt) * 100

        '    '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cavsgrspft") = Decimal.Round(cavsgrpfper, 2)
        '    '            'txt_Hdr_ClaimVSGPPer.Text = Decimal.Round(cavsgrpfper, 2)
        '    '        End If
        '    '    End If
        '    'End If

        '    ''calculate_HKOAmount("Header", 0, True)
        '    'calculate_HKOAmount(0)
        '    'txt_Hdr_ClaimToHKOAmt.Text = sReformatCurrency(Decimal.Round(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catohkoamt"), 2))

        '    'cal_ClaimAmt_CAORDITM()
        '    'cal_ClaimAmt_CAORDDTL()

        '    'format_Approval(0)

        '    Recordstatus = True
        'End If
    End Sub

    Private Sub txt_Hdr_FinalClaimAmt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Hdr_FinalClaimAmt.LostFocus
        ' txt_Hdr_FinalClaimAmt.Text = sReformatCurrency(txt_Hdr_FinalClaimAmt.Text)
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_final") = Val(txt_Hdr_FinalClaimAmt.Text)

        If txt_Hdr_OrgClaimAmt.Text <> "0" And txt_Hdr_OrgClaimAmt.Text <> "0.00" Or _
           txt_Hdr_FinalClaimAmt.Text <> "0" And txt_Hdr_FinalClaimAmt.Text <> "0.00" Then
            'format_Approval(0)
            '    ClaimAmt_Header = True
            'Else
            '    ClaimAmt_Header = False
        End If

        'If Not ClaimAmt_Header Then
        '    calculate_CAORDHDR()
        'Else
        '    'format_Approval(0)
        'End If


        If txt_Hdr_ClaimToInsAmt_ori.Enabled = True Then
            txt_Hdr_ClaimToInsAmt_ori.Focus()
        Else
            txt_Hdr_ClaimToVNAmt_ori.Focus()
        End If
    End Sub

    Private Function sReformatCurrency(ByVal sCurrency As String) As String
        If sCurrency.IndexOf(".") = -1 Then
            sCurrency = sCurrency + ".00"
        Else
            If sCurrency.IndexOf(".") = sCurrency.Length - 2 Then
                sCurrency = sCurrency + "0"
            End If
        End If
        Return sCurrency
    End Function

    Private Sub format_inputHdr_FinalClaimAmt_after()
        gb_Hdr_ClaimTo.Enabled = True

        cbo_Hdr_ClaimToInsAmtCurrency.Enabled = False
        txt_Hdr_ClaimToInsAmt.Enabled = True
        cbo_Hdr_ClaimToVNAmtCurrency.Enabled = False
        txt_Hdr_ClaimToVNAmt.Enabled = True
        'cbo_Hdr_ClaimToEVNAmtCurrency.Enabled = True
        'txt_Hdr_ClaimToEVNAmt.Enabled = True

        chkapv1b.Enabled = False
    End Sub

    Private Function calculate_HKOAmount(ByVal line_no As Integer) As Decimal
        'Private Function 'calculate_HKOAmount(ByVal t As String, ByVal dtl_line_no As Integer, ByVal updCurr As Boolean) As Decimal
        'calculate Customer HKO Amount
        Dim CAH_CACUR As String
        Dim CAH_CAAMT_FINAL As Decimal
        Dim CAH_CATOINSCUR As String
        Dim CAH_CATOINSAMT As Decimal
        Dim CAH_CATOVNCUR As String
        Dim CAH_CATOVNAMT As Decimal
        'Dim CAH_CATOEVNCUR As String
        'Dim CAH_CATOEVNAMT As Decimal
        Dim CAH_CATOHKOCUR As String
        Dim CAH_CATOHKOAMT As Decimal

        'calculate Item HKO Amount
        Dim CAI_CACUR As String
        Dim CAI_TTLCAAMT_FINAL As Decimal
        Dim CAI_CATOINSCUR As String
        Dim CAI_CATOINSAMT As Decimal
        Dim CAI_CATOVNCUR As String
        Dim CAI_CATOVNAMT As Decimal
        Dim CAI_CATOHKOCUR As String
        Dim CAI_CATOHKOAMT As Decimal

        'calculate Shipment HKO Amount
        Dim CAD_CACUR As String
        Dim CAD_TTLCAAMT_FINAL As Decimal
        Dim CAD_CATOINSCUR As String
        Dim CAD_CATOINSAMT As Decimal
        Dim CAD_CATOVNCUR As String
        Dim CAD_CATOVNAMT As Decimal
        Dim CAD_CATOHKOCUR As String
        Dim CAD_CATOHKOAMT As Decimal

        Dim exchrate_ins As Decimal
        Dim exchrate_vn As Decimal
        'Dim exchrate_evn As Decimal
        Dim exchrate_hko As Decimal

        Dim hkoamt As Decimal

        If rs_CAORDHDR.Tables("RESULT") Is Nothing Then
            Exit Function
        End If
        If rs_CAORDHDR.Tables("RESULT").Rows.Count = 0 Then
            Exit Function
        End If

        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Function
        End If

        If rs_CAORDDTL.Tables("RESULT").Rows.Count = 0 Then
            Exit Function
        End If

        If rs_CAORDDTL.Tables("RESULT").Rows.Count <= line_no Then
            Exit Function
        End If

        If sHdrClaimAmtPer = "C" Then
            'Update Latest Exchange Currency
            'If cbo_Hdr_ClaimAmtCurrency.Text = "" Or cbo_Hdr_ClaimToInsAmtCurrency.Text = "" Or cbo_Hdr_ClaimToVNAmtCurrency.Text = "" Or cbo_Hdr_ClaimToEVNAmtCurrency.Text = "" Or cbo_Hdr_ClaimToHKOAmtCurrency.Text = "" Then
            If cbo_Hdr_ClaimAmtCurrency.Text = "" Or cbo_Hdr_ClaimToInsAmtCurrency.Text = "" Or _
                cbo_Hdr_ClaimToVNAmtCurrency.Text = "" Or cbo_Hdr_ClaimToHKOAmtCurrency.Text = "" Then
                Exit Function
            End If

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cacur") = cbo_Hdr_ClaimAmtCurrency.Text
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoinscur") = cbo_Hdr_ClaimToInsAmtCurrency.Text
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catovncur") = cbo_Hdr_ClaimToVNAmtCurrency.Text
            'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoevncur") = cbo_Hdr_ClaimToEVNAmtCurrency.Text
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catohkocur") = cbo_Hdr_ClaimToHKOAmtCurrency.Text

            CAH_CACUR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cacur")
            '''20131115
            If IsDBNull(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_final")) Then
                Exit Function
            End If

            CAH_CAAMT_FINAL = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_final")
            CAH_CATOINSCUR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoinscur")
            CAH_CATOINSAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoinsamt")
            CAH_CATOVNCUR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catovncur")
            CAH_CATOVNAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catovnamt")
            'CAH_CATOEVNCUR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoevncur")
            'CAH_CATOEVNAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoevnamt")
            CAH_CATOHKOCUR = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catohkocur")
            CAH_CATOHKOAMT = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catohkoamt")

            exchrate_ins = getExchangeRate(CAH_CATOINSCUR, CAH_CACUR, "BuyRate")
            exchrate_vn = getExchangeRate(CAH_CATOVNCUR, CAH_CACUR, "BuyRate")
            'exchrate_evn = getExchangeRate(CAH_CATOEVNCUR, CAH_CACUR, "BuyRate")
            exchrate_hko = getExchangeRate(CAH_CATOHKOCUR, CAH_CACUR, "BuyRate")

            hkoamt = CAH_CAAMT_FINAL - (exchrate_ins * CAH_CATOINSAMT) - (exchrate_vn * CAH_CATOVNAMT) '- (exchrate_evn * CAH_CATOEVNAMT)

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catohkoamt") = Decimal.Round(hkoamt / exchrate_hko, 2)
        Else
            If rbViewOn_I.Checked Then
                CAI_CACUR = rs_CAORDITM.Tables("RESULT").Rows(line_no).Item("cai_cacur")
                CAI_TTLCAAMT_FINAL = rs_CAORDITM.Tables("RESULT").Rows(line_no).Item("cai_ttlcaamt_final")
                CAI_CATOINSCUR = rs_CAORDITM.Tables("RESULT").Rows(line_no).Item("cai_catoinscur")
                CAI_CATOINSAMT = rs_CAORDITM.Tables("RESULT").Rows(line_no).Item("cai_catoinsamt")
                CAI_CATOVNCUR = rs_CAORDITM.Tables("RESULT").Rows(line_no).Item("cai_catovncur")
                CAI_CATOVNAMT = rs_CAORDITM.Tables("RESULT").Rows(line_no).Item("cai_catovnamt")
                CAI_CATOHKOCUR = rs_CAORDITM.Tables("RESULT").Rows(line_no).Item("cai_catohkocur")
                CAI_CATOHKOAMT = rs_CAORDITM.Tables("RESULT").Rows(line_no).Item("cai_catohkoamt")

                exchrate_ins = getExchangeRate(CAI_CATOINSCUR, CAI_CACUR, "BuyRate")
                exchrate_vn = getExchangeRate(CAI_CATOVNCUR, CAI_CACUR, "BuyRate")
                exchrate_hko = getExchangeRate(CAI_CATOHKOCUR, CAI_CACUR, "BuyRate")

                If exchrate_ins = 0 Or exchrate_vn = 0 Or exchrate_hko = 0 Then
                    Exit Function
                End If

                hkoamt = CAI_TTLCAAMT_FINAL - (exchrate_ins * CAI_CATOINSAMT) - (exchrate_vn * CAI_CATOVNAMT)

                rs_CAORDITM.Tables("RESULT").Rows(line_no).Item("cai_catohkoamt") = Decimal.Round(hkoamt / exchrate_hko, 2)
            Else
                CAD_CACUR = rs_CAORDDTL.Tables("RESULT").Rows(line_no).Item("cad_cacur")
                CAD_TTLCAAMT_FINAL = rs_CAORDDTL.Tables("RESULT").Rows(line_no).Item("cad_ttlcaamt_final")
                CAD_CATOINSCUR = rs_CAORDDTL.Tables("RESULT").Rows(line_no).Item("cad_catoinscur")
                CAD_CATOINSAMT = rs_CAORDDTL.Tables("RESULT").Rows(line_no).Item("cad_catoinsamt")
                CAD_CATOVNCUR = rs_CAORDDTL.Tables("RESULT").Rows(line_no).Item("cad_catovncur")
                CAD_CATOVNAMT = rs_CAORDDTL.Tables("RESULT").Rows(line_no).Item("cad_catovnamt")
                CAD_CATOHKOCUR = rs_CAORDDTL.Tables("RESULT").Rows(line_no).Item("cad_catohkocur")
                CAD_CATOHKOAMT = rs_CAORDDTL.Tables("RESULT").Rows(line_no).Item("cad_catohkoamt")

                exchrate_ins = getExchangeRate(CAD_CATOINSCUR, CAD_CACUR, "BuyRate")
                exchrate_vn = getExchangeRate(CAD_CATOVNCUR, CAD_CACUR, "BuyRate")
                exchrate_hko = getExchangeRate(CAD_CATOHKOCUR, CAD_CACUR, "BuyRate")

                If exchrate_ins = 0 Or exchrate_vn = 0 Or exchrate_hko = 0 Then
                    Exit Function
                End If

                hkoamt = CAD_TTLCAAMT_FINAL - (exchrate_ins * CAD_CATOINSAMT) - (exchrate_vn * CAD_CATOVNAMT)

                rs_CAORDDTL.Tables("RESULT").Rows(line_no).Item("cad_catohkoamt") = Decimal.Round(hkoamt / exchrate_hko, 2)
            End If
            'Else
            '    If rbViewOn_I.Checked Then
            '        CAD_CACUR = rs_CAORDDTL.Tables("RESULT").Rows(line_no).Item("cad_cacur")
            '        CAD_TTLCAAMT_FINAL = rs_CAORDDTL.Tables("RESULT").Rows(line_no).Item("cad_ttlcaamt_final")
            '        CAD_CATOINSCUR = rs_CAORDDTL.Tables("RESULT").Rows(line_no).Item("cad_catoinscur")
            '        CAD_CATOINSAMT = rs_CAORDDTL.Tables("RESULT").Rows(line_no).Item("cad_catoinsamt")
            '        CAD_CATOVNCUR = rs_CAORDDTL.Tables("RESULT").Rows(line_no).Item("cad_catovncur")
            '        CAD_CATOVNAMT = rs_CAORDDTL.Tables("RESULT").Rows(line_no).Item("cad_catovnamt")
            '        CAD_CATOHKOCUR = rs_CAORDDTL.Tables("RESULT").Rows(line_no).Item("cad_catohkocur")
            '        CAD_CATOHKOAMT = rs_CAORDDTL.Tables("RESULT").Rows(line_no).Item("cad_catohkoamt")

            '        exchrate_ins = getExchangeRate(CAD_CATOINSCUR, CAD_CACUR, "BuyRate")
            '        exchrate_vn = getExchangeRate(CAD_CATOVNCUR, CAD_CACUR, "BuyRate")
            '        exchrate_hko = getExchangeRate(CAD_CATOHKOCUR, CAD_CACUR, "BuyRate")

            '        If exchrate_ins = 0 Or exchrate_vn = 0 Or exchrate_hko = 0 Then
            '            Exit Function
            '        End If

            '        hkoamt = CAD_TTLCAAMT_FINAL - (exchrate_ins * CAD_CATOINSAMT) - (exchrate_vn * CAD_CATOVNAMT)

            '        rs_CAORDDTL.Tables("RESULT").Rows(line_no).Item("cad_catohkoamt") = Decimal.Round(hkoamt / exchrate_hko, 2)
            '    End If
        End If
    End Function

    Private Sub cbo_Hdr_ClaimAmtCurrency_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_Hdr_ClaimAmtCurrency.LostFocus
        txt_Hdr_OrgClaimAmt.Focus()

    End Sub

    Private Sub cbo_Hdr_ClaimAmtCurrency_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_Hdr_ClaimAmtCurrency.MouseEnter

    End Sub

    Private Sub cbo_Hdr_ClaimAmtCurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Hdr_ClaimAmtCurrency.SelectedIndexChanged
        show_org_dif()
        show_final_dif()
        lbl_amt_cur.Text = cbo_Hdr_ClaimAmtCurrency.Text
        txt_Hdr_ClaimToVNAmt.Text = ""
        txt_Hdr_ClaimToHKOAmt.Text = ""
        txt_Hdr_ClaimToVNAmt_ori.Text = ""
        txt_Hdr_ClaimToHKOAmt_ori.Text = ""
        txt_Hdr_ClaimToHKOAmt.Text = ""
        txt_Hdr_ClaimToHKOAmt_ori.Text = ""

        'If Recorddisplay = True Then
        '    Exit Sub
        'End If

        'cbo_Hdr_ClaimToInsAmtCurrency.Text = cbo_Hdr_ClaimAmtCurrency.Text
        'cbo_Hdr_ClaimToVNAmtCurrency.Text = cbo_Hdr_ClaimAmtCurrency.Text
        'cbo_Hdr_ClaimToHKOAmtCurrency.Text = cbo_Hdr_ClaimAmtCurrency.Text

        'lbl_Hdr_ClaimToInsAmt_ExchRate.Text = Decimal.Round(getExchangeRate(cbo_Hdr_ClaimToInsAmtCurrency.Text, cbo_Hdr_ClaimAmtCurrency.Text, "BuyRate"), 2)
        'lbl_Hdr_ClaimToVNAmt_ExchRate.Text = Decimal.Round(getExchangeRate(cbo_Hdr_ClaimToVNAmtCurrency.Text, cbo_Hdr_ClaimAmtCurrency.Text, "BuyRate"), 2)
        ''lbl_Hdr_ClaimToEVNAmt_ExchRate.Text = Decimal.Round(getExchangeRate(cbo_Hdr_ClaimToEVNAmtCurrency.Text, cbo_Hdr_ClaimAmtCurrency.Text, "BuyRate"), 4)
        'lbl_Hdr_ClaimToHKOAmt_ExchRate.Text = Decimal.Round(getExchangeRate(cbo_Hdr_ClaimToHKOAmtCurrency.Text, cbo_Hdr_ClaimAmtCurrency.Text, "BuyRate"), 2)

        ''calculate_HKOAmount("Header", 0, True)
        'calculate_HKOAmount(0)
        'display_CAORDHDR()
        'cal_ClaimAmt_CAORDITM()
        'cal_ClaimAmt_CAORDDTL()

        'format_Approval(0)
    End Sub

    Private Sub txt_Hdr_ClaimToInsAmt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Hdr_ClaimToInsAmt.GotFocus
        '        flag_keypress_txt_Hdr_ClaimToInsAmt = True
    End Sub

    Private Sub txt_Hdr_ClaimToInsAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Hdr_ClaimToInsAmt.KeyPress
        flag_keypress_txt_Hdr_ClaimToInsAmt = True

        'Dim allowedChars As String = "0123456789."

        'If allowedChars.IndexOf(e.KeyChar) = -1 Then
        '    e.KeyChar = ""
        '    Exit Sub
        'End If

        'Dim currenttext As String

        'currenttext = txt_Hdr_ClaimToInsAmt.Text & e.KeyChar

        'If e.KeyChar = "." Then
        '    If Mid(currenttext, 1, Len(currenttext) - 1).IndexOf(".") <> -1 Then
        '        e.KeyChar = ""
        '        Exit Sub
        '    End If
        'End If
    End Sub

    Private Sub txt_Hdr_ClaimToInsAmt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Hdr_ClaimToInsAmt.KeyUp
        '        flag_keypress_txt_Hdr_ClaimToInsAmt = True
        'If Not IsNumeric(txt_Hdr_ClaimToInsAmt.Text) Then
        '    Exit Sub
        'End If

        'If e.KeyCode <> Keys.Decimal Or txt_Hdr_ClaimToInsAmt.Text.IndexOf(".") <> txt_Hdr_ClaimToInsAmt.Text.Length - 1 Then
        '    Dim pos As Integer = txt_Hdr_ClaimToInsAmt.SelectionStart
        '    If e.KeyCode = Keys.Back And txt_Hdr_ClaimToInsAmt.Text.Length > 0 Then
        '        If pos = txt_Hdr_ClaimToInsAmt.Text.Length Then
        '            txt_Hdr_ClaimToInsAmt.Text = txt_Hdr_ClaimToInsAmt.Text.Substring(0, txt_Hdr_ClaimToInsAmt.Text.Length - 1)
        '            txt_Hdr_ClaimToInsAmt.Select(pos, 0)
        '        ElseIf pos > 0 And pos < txt_Hdr_ClaimToInsAmt.Text.Length Then
        '            txt_Hdr_ClaimToInsAmt.Text = _
        '            txt_Hdr_ClaimToInsAmt.Text.Substring(0, pos - 1) + _
        '            txt_Hdr_ClaimToInsAmt.Text.Substring(pos, txt_Hdr_ClaimToInsAmt.Text.Length - pos)
        '            txt_Hdr_ClaimToInsAmt.Select(pos - 1, 0)
        '        End If
        '    End If

        '    If txt_Hdr_ClaimToInsAmt.Text.Length = 0 Then
        '        txt_Hdr_ClaimToInsAmt.Text = "0.00"
        '    Else
        '        txt_Hdr_ClaimToInsAmt.Text = Decimal.Round(Convert.ToDecimal(txt_Hdr_ClaimToInsAmt.Text), 2)
        '    End If

        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoinsamt") = txt_Hdr_ClaimToInsAmt.Text

        '    If Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Or _
        '        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~" Or _
        '        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~" Or _
        '        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*DEL*~") Then
        '        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~"
        '    End If

        '    ''calculate_HKOAmount("Header", 0, True)
        '    'calculate_HKOAmount(0)
        '    '''            txt_Hdr_ClaimToHKOAmt.Text = sReformatCurrency(Decimal.Round(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catohkoamt"), 2))

        '    'cal_ClaimAmt_CAORDITM()
        '    'cal_ClaimAmt_CAORDDTL()

        '    'format_Approval(0)
        'End If
    End Sub

    Private Sub txt_Hdr_ClaimToInsAmt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Hdr_ClaimToInsAmt.LostFocus


        If rs_CAORDHDR.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub

        End If
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoinsamt") = Val(txt_Hdr_ClaimToInsAmt.Text)
    End Sub

    Private Sub txt_Hdr_ClaimToVNAmt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Hdr_ClaimToVNAmt.GotFocus
        'flag_keypress_txt_Hdr_ClaimToVNAmt = True

    End Sub

    Private Sub txt_Hdr_ClaimToIVNAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Hdr_ClaimToVNAmt.KeyPress

        flag_keypress_txt_Hdr_ClaimToVNAmt = True
        'Dim allowedChars As String = "0123456789."

        'If allowedChars.IndexOf(e.KeyChar) = -1 Then
        '    e.KeyChar = ""
        '    Exit Sub
        'End If

        'Dim currenttext As String

        'currenttext = txt_Hdr_ClaimToVNAmt.Text & e.KeyChar

        'If e.KeyChar = "." Then
        '    If Mid(currenttext, 1, Len(currenttext) - 1).IndexOf(".") <> -1 Then
        '        e.KeyChar = ""
        '        Exit Sub
        '    End If
        'End If
    End Sub

    Private Sub txt_Hdr_ClaimToIVNAmt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Hdr_ClaimToVNAmt.KeyUp
        flag_keypress_txt_Hdr_ClaimToVNAmt = True

        'If Not IsNumeric(txt_Hdr_ClaimToVNAmt.Text) Then
        '    Exit Sub
        'End If

        If e.KeyCode <> Keys.Decimal Or txt_Hdr_ClaimToVNAmt.Text.IndexOf(".") <> txt_Hdr_ClaimToVNAmt.Text.Length - 1 Then
            '    Dim pos As Integer = txt_Hdr_ClaimToVNAmt.SelectionStart
            '    If e.KeyCode = Keys.Back And txt_Hdr_ClaimToVNAmt.Text.Length > 0 Then
            '        If pos = txt_Hdr_ClaimToVNAmt.Text.Length Then
            '            txt_Hdr_ClaimToVNAmt.Text = txt_Hdr_ClaimToVNAmt.Text.Substring(0, txt_Hdr_ClaimToVNAmt.Text.Length - 1)
            '            txt_Hdr_ClaimToVNAmt.Select(pos, 0)
            '        ElseIf pos > 0 And pos < txt_Hdr_ClaimToVNAmt.Text.Length Then
            '            txt_Hdr_ClaimToVNAmt.Text = _
            '            txt_Hdr_ClaimToVNAmt.Text.Substring(0, pos - 1) + _
            '            txt_Hdr_ClaimToVNAmt.Text.Substring(pos, txt_Hdr_ClaimToVNAmt.Text.Length - pos)
            '            txt_Hdr_ClaimToVNAmt.Select(pos - 1, 0)
            '        End If
            '    End If

            '    If txt_Hdr_ClaimToVNAmt.Text.Length = 0 Then
            '        txt_Hdr_ClaimToVNAmt.Text = "0.00"
            '    Else
            '        txt_Hdr_ClaimToVNAmt.Text = Decimal.Round(Convert.ToDecimal(txt_Hdr_ClaimToVNAmt.Text), 2)
            '    End If

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catovnamt") = Val(txt_Hdr_ClaimToVNAmt.Text)

            If Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Or _
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~" Or _
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~" Or _
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*DEL*~") Then
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~"
            End If

            ''calculate_HKOAmount("Header", 0, True)
            'calculate_HKOAmount(0)
            'txt_Hdr_ClaimToHKOAmt.Text = sReformatCurrency(Decimal.Round(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catohkoamt"), 2))

            'cal_ClaimAmt_CAORDITM()
            'cal_ClaimAmt_CAORDDTL()

            'format_Approval(0)
        End If
    End Sub

    Private Sub txt_Hdr_ClaimToIVNAmt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Hdr_ClaimToVNAmt.LostFocus


    End Sub

    Private Sub cbo_Dtl_ClaimType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_Dtl_ClaimType.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            If Not checkValidCombo(cbo_Dtl_ClaimType, cbo_Dtl_ClaimType.Text) Then
                showCheckboxErrMsg(cbo_Dtl_ClaimType)
            End If
        End If
    End Sub

    Private Sub cbo_Dtl_ClaimType_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbo_Dtl_ClaimType.KeyUp
        If cbo_Dtl_ClaimType.Text.Length > 0 Then
            If e.KeyCode <> Keys.Back Then
                sDtlClaimType = cbo_Dtl_ClaimType.Text
                auto_search_combo(cbo_Dtl_ClaimType)
            Else
                cbo_Dtl_ClaimType.Text = sDtlClaimType.Substring(0, sDtlClaimType.Length - 1)
                auto_search_combo(cbo_Dtl_ClaimType)
                sDtlClaimType = sDtlClaimType.Substring(0, sDtlClaimType.Length - 1)
            End If
        End If
    End Sub

    Private Sub cbo_Dtl_ClaimType_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_Dtl_ClaimType.Leave
        ' ''If Not checkValidCombo(cbo_Dtl_ClaimType, cbo_Dtl_ClaimType.Text) Then
        ' ''    showCheckboxErrMsg(cbo_Dtl_ClaimType)
        ' ''End If
    End Sub

    Private Sub cbo_Dtl_ClaimType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Dtl_ClaimType.SelectedIndexChanged
        If Recorddisplay = True Then
            Exit Sub
        End If

        If rbViewOn_I.Checked Then
            Dim line As Integer
            Dim i As Integer
            Dim seq As Integer

            seq = lblSeq.Text

            line = 0

            For i = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
                If seq = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caordseq") Then
                    line = i
                End If
            Next i

            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_clatyp") = Split(cbo_Dtl_ClaimType.Text, " - ")(0)

            If Not (rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*ADD*~" Or _
                rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*NEW*~" Or _
                rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~" Or _
                rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*DEL*~") Then
                rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~"
            End If
        End If

        Recordstatus = True
    End Sub

    Private Sub txt_Dtl_OrgClaimQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim allowedChars As String = "0123456789"

        If allowedChars.IndexOf(e.KeyChar) = -1 Then
            ' Invalid Character
            e.KeyChar = ""
            Exit Sub
        End If

        Dim currenttext As String

        currenttext = txt_Hdr_OrgClaimAmt.Text & e.KeyChar

        'check for only 1.
        If e.KeyChar = "." Then
            If Mid(currenttext, 1, Len(currenttext) - 1).IndexOf(".") <> -1 Then
                e.KeyChar = ""
                Exit Sub
            End If
        End If

        Recordstatus = True
    End Sub

    Private Sub txt_Dtl_OrgClaimQty_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        '    Dim line As Integer
        '    Dim i As Integer
        '    Dim seq As Integer

        '    seq = lblSeq.Text

        '    line = 0

        '    For i = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
        '        If seq = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caordseq") Then
        '            line = i
        '        End If
        '    Next i

        '    Dim ftycur As String
        '    Dim cacur As String
        '    Dim exrate As Decimal

        '    ftycur = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_scfcurcde")
        '    cacur = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_cacur")
        '    exrate = 0.0
        '    exrate = getExchangeRate(ftycur, cacur, "BuyRate")

        '    If IsNumeric(txt_Dtl_OrgClaimQty.Text) Then
        '        If Mid(txt_Dtl_OrgClaimQty.Text, Len(txt_Dtl_OrgClaimQty.Text), 1) <> "." Then
        '            rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caqty") = txt_Dtl_OrgClaimQty.Text
        '        End If
        '    End If

        '    If IsNumeric(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_scftyprc")) And IsNumeric(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caqty")) Then
        '        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caqtyamt_org") = Decimal.Round(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caqty") * rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_scftyprc") * exrate, 2)
        '        txt_Dtl_OrgClaimQtyAmt.Text = Decimal.Round(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caqtyamt_org"), 2)
        '    End If

        '    rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_ttlcaamt_org") = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caqtyamt_org") + rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caamt_org")
        '    txt_Dtl_OrgClaimTtlAmt.Text = Decimal.Round(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_ttlcaamt_org"), 2)

        '    If Not (rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*ADD*~" Or _
        '        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*NEW*~" Or _
        '        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*UPD*~" Or _
        '        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*DEL*~") Then
        '        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*UPD*~"
        '    End If

        '    'cal_ClaimAmt_CAORDITM()
        '    'cal_ClaimAmt_CAORDHDR()

        '    'display_CAORDDTL(seq)
        '    Recordstatus = True
        '    Set_Approval_Right_for_dgSummary(cModeUpd)
        'End Sub

        'Private Sub txt_Dtl_OrgClaimQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) 
        '    Dim dtl_orgclaimqty As Integer
        '    Dim dtl_ordqty As Integer

        '    dtl_orgclaimqty = Val(txt_Dtl_OrgClaimQty.Text)
        '    dtl_ordqty = Val(txtShipQty.Text)

        '    If dtl_orgclaimqty > dtl_ordqty Then
        '        MessageBox.Show("Claim Original Quantity can't larger than Shipment Quantity.", "Information Error.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '        '''txt_Dtl_OrgClaimQty.Focus()
        '        '''20131112 tmpcmt
        '        '''Exit Sub
        '    End If

        '    'If txt_Dtl_OrgClaimQty.Modified = True Then
        '    '    ClaimAmt_Header = True
        '    '    For index As Integer = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
        '    '        If rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_ttlcaamt_org") <> "0.00" Or _
        '    '           rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_ttlcaamt_final") <> "0.00" Then
        '    '            ClaimAmt_Header = False
        '    '            Exit For
        '    '        End If
        '    '    Next

        '    '    check_ClaimAmt_Header()
        '    '    'format_Approval(check_ClaimAmt_Header, 0)
        '    'End If
        'End Sub

        'Private Sub txt_Dtl_OrgClaimAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 
        '    Dim allowedChars As String = "0123456789."

        '    If allowedChars.IndexOf(e.KeyChar) = -1 Then
        '        ' Invalid Character
        '        e.KeyChar = ""
        '        Exit Sub
        '    End If

        '    Dim currenttext As String
        '    If txt_Dtl_OrgClaimAmt.Text = "0.00" Then
        '        currenttext = e.KeyChar
        '    Else
        '        currenttext = txt_Dtl_OrgClaimAmt.Text & e.KeyChar
        '    End If

        '    'check for only 1.
        '    If e.KeyChar = "." Then
        '        If Mid(currenttext, 1, Len(currenttext) - 1).IndexOf(".") <> -1 Then
        '            e.KeyChar = ""
        '            Exit Sub
        '        End If
        '    End If
    End Sub

    Private Sub txt_Dtl_OrgClaimAmt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        ''Dim line As Integer
        ''Dim i As Integer
        ''Dim seq As Integer

        ''seq = lblSeq.Text

        ''line = 0

        ''If rbViewOn_I.Checked Then
        ''    For i = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
        ''        If seq = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caordseq") Then
        ''            line = i
        ''        End If
        ''    Next i

        ''    'If IsNumeric(txt_Dtl_OrgClaimAmt.Text) Then
        ''    If e.KeyCode <> Keys.Decimal Or txt_Dtl_OrgClaimAmt.Text.IndexOf(".") <> txt_Dtl_OrgClaimAmt.Text.Length - 1 Then
        ''        Dim pos As Integer = txt_Dtl_OrgClaimAmt.SelectionStart
        ''        If e.KeyCode = Keys.Back And txt_Dtl_OrgClaimAmt.Text.Length > 0 Then
        ''            If pos = txt_Dtl_OrgClaimAmt.Text.Length Then
        ''                txt_Dtl_OrgClaimAmt.Text = txt_Dtl_OrgClaimAmt.Text.Substring(0, txt_Dtl_OrgClaimAmt.Text.Length - 1)
        ''                txt_Dtl_OrgClaimAmt.Select(pos, 0)
        ''            ElseIf pos > 0 And pos < txt_Dtl_OrgClaimAmt.Text.Length Then
        ''                txt_Dtl_OrgClaimAmt.Text = _
        ''                txt_Dtl_OrgClaimAmt.Text.Substring(0, pos - 1) + _
        ''                txt_Dtl_OrgClaimAmt.Text.Substring(pos, txt_Dtl_OrgClaimAmt.Text.Length - pos)
        ''                txt_Dtl_OrgClaimAmt.Select(pos - 1, 0)
        ''            End If
        ''        End If

        ''        If txt_Dtl_OrgClaimAmt.Text.Length = 0 Then
        ''            txt_Dtl_OrgClaimAmt.Text = "0.00"
        ''        Else
        ''            txt_Dtl_OrgClaimAmt.Text = Decimal.Round(Convert.ToDecimal(txt_Dtl_OrgClaimAmt.Text), 2)
        ''        End If

        ''        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caamt_org") = txt_Dtl_OrgClaimAmt.Text
        ''        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_ttlcaamt_org") = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caqtyamt_org") + rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caamt_org")
        ''        txt_Dtl_OrgClaimTtlAmt.Text = Decimal.Round(rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_ttlcaamt_org"), 2)
        ''    End If
        ''    'End If

        ''    If Not (rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*ADD*~" Or _
        ''        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*NEW*~" Or _
        ''        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~" Or _
        ''        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*DEL*~") Then
        ''        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~"
        ''    End If

        ''    If sHdrClaimAmtPer = "I" Then
        ''        'cal_ClaimAmt_CAORDHDR()
        ''        'cal_ClaimAmt_CAORDDTL()
        ''    ElseIf sHdrClaimAmtPer = "S" Then
        ''        'cal_ClaimAmt_CAORDITM()
        ''        'cal_ClaimAmt_CAORDHDR()
        ''    End If
        ''Else
        ''    For i = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
        ''        If seq = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caordseq") Then
        ''            line = i
        ''        End If
        ''    Next i

        ''    'If IsNumeric(txt_Dtl_OrgClaimAmt.Text) Then
        ''    If e.KeyCode <> Keys.Decimal Or txt_Dtl_OrgClaimAmt.Text.IndexOf(".") <> txt_Dtl_OrgClaimAmt.Text.Length - 1 Then
        ''        Dim pos As Integer = txt_Dtl_OrgClaimAmt.SelectionStart
        ''        If e.KeyCode = Keys.Back And txt_Dtl_OrgClaimAmt.Text.Length > 0 Then
        ''            If pos = txt_Dtl_OrgClaimAmt.Text.Length Then
        ''                txt_Dtl_OrgClaimAmt.Text = txt_Dtl_OrgClaimAmt.Text.Substring(0, txt_Dtl_OrgClaimAmt.Text.Length - 1)
        ''                txt_Dtl_OrgClaimAmt.Select(pos, 0)
        ''            ElseIf pos > 0 And pos < txt_Dtl_OrgClaimAmt.Text.Length Then
        ''                txt_Dtl_OrgClaimAmt.Text = _
        ''                txt_Dtl_OrgClaimAmt.Text.Substring(0, pos - 1) + _
        ''                txt_Dtl_OrgClaimAmt.Text.Substring(pos, txt_Dtl_OrgClaimAmt.Text.Length - pos)
        ''                txt_Dtl_OrgClaimAmt.Select(pos - 1, 0)
        ''            End If
        ''        End If

        ''        If txt_Dtl_OrgClaimAmt.Text.Length = 0 Then
        ''            txt_Dtl_OrgClaimAmt.Text = "0.00"
        ''        Else
        ''            txt_Dtl_OrgClaimAmt.Text = Decimal.Round(Convert.ToDecimal(txt_Dtl_OrgClaimAmt.Text), 2)
        ''        End If

        ''        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caamt_org") = txt_Dtl_OrgClaimAmt.Text
        ''        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_ttlcaamt_org") = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caqtyamt_org") + rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caamt_org")
        ''        txt_Dtl_OrgClaimTtlAmt.Text = Decimal.Round(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_ttlcaamt_org"), 2)
        ''    End If
        ''    'End If

        ''    If Not (rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*ADD*~" Or _
        ''        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*NEW*~" Or _
        ''        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*UPD*~" Or _
        ''        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*DEL*~") Then
        ''        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*UPD*~"
        ''    End If

        ''    If sHdrClaimAmtPer = "I" Then
        ''        'cal_ClaimAmt_CAORDHDR()
        ''        'cal_ClaimAmt_CAORDDTL()
        ''    ElseIf sHdrClaimAmtPer = "S" Then
        ''        'cal_ClaimAmt_CAORDITM()
        ''        'cal_ClaimAmt_CAORDHDR()
        ''    End If
        ''End If

        ''Recordstatus = True
    End Sub

    Private Sub txt_Dtl_OrgClaimAmt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim line As Integer
        'Dim i As Integer
        'Dim seq As Integer

        'seq = lblSeq.Text

        'line = 0

        'If rbViewOn_I.Checked Then
        '    For i = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
        '        If seq = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caordseq") Then
        '            line = i
        '        End If
        '    Next i

        '    txt_Dtl_OrgClaimAmt.Text = sReformatCurrency(txt_Dtl_OrgClaimAmt.Text)
        '    rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caamt_org") = txt_Dtl_OrgClaimAmt.Text

        '    If txt_Dtl_OrgClaimAmt.Modified = True Then
        '        'ClaimAmt_Header = True
        '        'For index As Integer = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
        '        '    If rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_ttlcaamt_org") <> "0.00" Or _
        '        '       rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_ttlcaamt_final") <> "0.00" Then
        '        '        ClaimAmt_Header = False
        '        '        Exit For
        '        '    End If
        '        'Next

        '        'check_ClaimAmt_Header()
        '        'format_Approval(seq)
        '    End If
        'Else
        '    For i = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
        '        If seq = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caordseq") Then
        '            line = i
        '        End If
        '    Next i

        '    txt_Dtl_OrgClaimAmt.Text = sReformatCurrency(txt_Dtl_OrgClaimAmt.Text)
        '    rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caamt_org") = txt_Dtl_OrgClaimAmt.Text

        '    If txt_Dtl_OrgClaimAmt.Modified = True Then
        '        'ClaimAmt_Header = True
        '        'For index As Integer = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
        '        '    If rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_ttlcaamt_org") <> "0.00" Or _
        '        '       rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_ttlcaamt_final") <> "0.00" Then
        '        '        ClaimAmt_Header = False
        '        '        Exit For
        '        '    End If
        '        'Next

        '        'check_ClaimAmt_Header()
        '        'format_Approval(seq)
        '    End If
        'End If
    End Sub

    'Private Sub txt_Dtl_FinalClaimAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 
    '    Dim allowedChars As String = "0123456789."

    '    If allowedChars.IndexOf(e.KeyChar) = -1 Then
    '        ' Invalid Character
    '        e.KeyChar = ""
    '        Exit Sub
    '    End If

    '    Dim currenttext As String
    '    If txt_Dtl_FinalClaimAmt.Text = "0.00" Then
    '        currenttext = e.KeyChar
    '    Else
    '        currenttext = txt_Dtl_FinalClaimAmt.Text & e.KeyChar
    '    End If

    '    'check for only 1.
    '    If e.KeyChar = "." Then
    '        If Mid(currenttext, 1, Len(currenttext) - 1).IndexOf(".") <> -1 Then
    '            e.KeyChar = ""
    '            Exit Sub
    '        End If
    '    End If
    'End Sub

    'Private Sub txt_Dtl_FinalClaimAmt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) 
    '    ' ''If Not IsNumeric(txt_Dtl_FinalClaimAmt.Text) Then
    '    ' ''    Exit Sub
    '    ' ''End If

    '    ''Dim line As Integer
    '    ''Dim i As Integer
    '    ''Dim seq As Integer

    '    ''seq = lblSeq.Text

    '    ''line = 0

    '    ''If rbViewOn_I.Checked Then
    '    ''    For i = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
    '    ''        If seq = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caordseq") Then
    '    ''            line = i
    '    ''        End If
    '    ''    Next i

    '    ''    'If IsNumeric(txt_Dtl_FinalClaimAmt.Text) Then
    '    ''    If e.KeyCode <> Keys.Decimal Or txt_Dtl_FinalClaimAmt.Text.IndexOf(".") <> txt_Dtl_FinalClaimAmt.Text.Length - 1 Then
    '    ''        Dim pos As Integer = txt_Dtl_FinalClaimAmt.SelectionStart
    '    ''        If e.KeyCode = Keys.Back And txt_Dtl_FinalClaimAmt.Text.Length > 0 Then
    '    ''            If pos = txt_Dtl_FinalClaimAmt.Text.Length Then
    '    ''                txt_Dtl_FinalClaimAmt.Text = txt_Dtl_FinalClaimAmt.Text.Substring(0, txt_Dtl_FinalClaimAmt.Text.Length - 1)
    '    ''                txt_Dtl_FinalClaimAmt.Select(pos, 0)
    '    ''            ElseIf pos > 0 And pos < txt_Dtl_FinalClaimAmt.Text.Length Then
    '    ''                txt_Dtl_FinalClaimAmt.Text = _
    '    ''                txt_Dtl_FinalClaimAmt.Text.Substring(0, pos - 1) + _
    '    ''                txt_Dtl_FinalClaimAmt.Text.Substring(pos, txt_Dtl_FinalClaimAmt.Text.Length - pos)
    '    ''                txt_Dtl_FinalClaimAmt.Select(pos - 1, 0)
    '    ''            End If
    '    ''        End If

    '    ''        If txt_Dtl_FinalClaimAmt.Text.Length = 0 Then
    '    ''            txt_Dtl_FinalClaimAmt.Text = "0.00"
    '    ''        Else
    '    ''            txt_Dtl_FinalClaimAmt.Text = Decimal.Round(Convert.ToDecimal(txt_Dtl_FinalClaimAmt.Text), 2)
    '    ''        End If

    '    ''        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caamt_final") = txt_Dtl_FinalClaimAmt.Text
    '    ''        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_ttlcaamt_final") = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caqtyamt_final") + rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caamt_final")
    '    ''        txt_Dtl_FinalClaimTtlAmt.Text = Decimal.Round(rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_ttlcaamt_final"), 2)
    '    ''    End If
    '    ''    'End If

    '    ''    'Dim cacur As String
    '    ''    'Dim gpcur As String
    '    ''    'Dim exrate As Decimal

    '    ''    'cacur = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_cacur")
    '    ''    'gpcur = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_salcur")
    '    ''    'exrate = 0.0
    '    ''    'exrate = getExchangeRate(cacur, gpcur, "BuyRate")

    '    ''    'If Not IsNumeric(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_grspftamt")) Then
    '    ''    '    Exit Sub
    '    ''    'End If

    '    ''    ''If Not cbAdhoc.Checked Then
    '    ''    'If rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_grspftamt") = 0 Then
    '    ''    '    Exit Sub
    '    ''    'Else
    '    ''    '    'rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_cavsgrspft") = ((rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_ttlcaamt_final") * exrate) / rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_grspftamt")) * 100
    '    ''    '    'txt_Dtl_ClaimVSGPPer.Text = Decimal.Round(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_cavsgrspft"), 2)
    '    ''    'End If
    '    ''    ''End If

    '    ''    If Not (rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*ADD*~" Or _
    '    ''        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*NEW*~" Or _
    '    ''        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~" Or _
    '    ''        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*DEL*~") Then
    '    ''        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~"
    '    ''    End If

    '    ''    ''calculate_HKOAmount("Detail", line, False)
    '    ''    'calculate_HKOAmount(line)
    '    ''    txt_Dtl_ClaimToHKOAmt.Text = Decimal.Round(rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catohkoamt"), 2)
    '    ''Else
    '    ''    For i = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
    '    ''        If seq = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caordseq") Then
    '    ''            line = i
    '    ''        End If
    '    ''    Next i

    '    ''    'If IsNumeric(txt_Dtl_FinalClaimAmt.Text) Then
    '    ''    If e.KeyCode <> Keys.Decimal Or txt_Dtl_FinalClaimAmt.Text.IndexOf(".") <> txt_Dtl_FinalClaimAmt.Text.Length - 1 Then
    '    ''        Dim pos As Integer = txt_Dtl_FinalClaimAmt.SelectionStart
    '    ''        If e.KeyCode = Keys.Back And txt_Dtl_FinalClaimAmt.Text.Length > 0 Then
    '    ''            If pos = txt_Dtl_FinalClaimAmt.Text.Length Then
    '    ''                txt_Dtl_FinalClaimAmt.Text = txt_Dtl_FinalClaimAmt.Text.Substring(0, txt_Dtl_FinalClaimAmt.Text.Length - 1)
    '    ''                txt_Dtl_FinalClaimAmt.Select(pos, 0)
    '    ''            ElseIf pos > 0 And pos < txt_Dtl_FinalClaimAmt.Text.Length Then
    '    ''                txt_Dtl_FinalClaimAmt.Text = _
    '    ''                txt_Dtl_FinalClaimAmt.Text.Substring(0, pos - 1) + _
    '    ''                txt_Dtl_FinalClaimAmt.Text.Substring(pos, txt_Dtl_FinalClaimAmt.Text.Length - pos)
    '    ''                txt_Dtl_FinalClaimAmt.Select(pos - 1, 0)
    '    ''            End If
    '    ''        End If

    '    ''        If txt_Dtl_FinalClaimAmt.Text.Length = 0 Then
    '    ''            txt_Dtl_FinalClaimAmt.Text = "0.00"
    '    ''        Else
    '    ''            txt_Dtl_FinalClaimAmt.Text = Decimal.Round(Convert.ToDecimal(txt_Dtl_FinalClaimAmt.Text), 2)
    '    ''        End If

    '    ''        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caamt_final") = txt_Dtl_FinalClaimAmt.Text
    '    ''        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_ttlcaamt_final") = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caqtyamt_final") + rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caamt_final")
    '    ''        txt_Dtl_FinalClaimTtlAmt.Text = Decimal.Round(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_ttlcaamt_final"), 2)
    '    ''    End If
    '    ''    'End If

    '    ''    'Dim cacur As String
    '    ''    'Dim gpcur As String
    '    ''    'Dim exrate As Decimal

    '    ''    'cacur = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_cacur")
    '    ''    'gpcur = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_salcur")
    '    ''    'exrate = 0.0
    '    ''    'exrate = getExchangeRate(cacur, gpcur, "BuyRate")

    '    ''    'If Not IsNumeric(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_grspftamt")) Then
    '    ''    '    Exit Sub
    '    ''    'End If

    '    ''    ''If Not cbAdhoc.Checked Then
    '    ''    'If rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_grspftamt") = 0 Then
    '    ''    '    Exit Sub
    '    ''    'Else
    '    ''    '    'rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_cavsgrspft") = ((rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_ttlcaamt_final") * exrate) / rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_grspftamt")) * 100
    '    ''    '    'txt_Dtl_ClaimVSGPPer.Text = Decimal.Round(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_cavsgrspft"), 2)
    '    ''    'End If
    '    ''    ''End If

    '    ''    If Not (rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*ADD*~" Or _
    '    ''        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*NEW*~" Or _
    '    ''        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*UPD*~" Or _
    '    ''        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*DEL*~") Then
    '    ''        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*UPD*~"
    '    ''    End If

    '    ''    ''calculate_HKOAmount("Detail", line, False)
    '    ''    'calculate_HKOAmount(line)
    '    ''    txt_Dtl_ClaimToHKOAmt.Text = Decimal.Round(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catohkoamt"), 2)
    '    ''End If

    '    ''If sHdrClaimAmtPer = "I" Then
    '    ''    'cal_ClaimAmt_CAORDHDR()
    '    ''    'cal_ClaimAmt_CAORDDTL()
    '    ''    'format_Approval(seq)
    '    ''ElseIf sHdrClaimAmtPer = "S" Then
    '    ''    'cal_ClaimAmt_CAORDITM()
    '    ''    'cal_ClaimAmt_CAORDHDR()
    '    ''    'format_Approval(seq)
    '    ''End If

    '    ''Recordstatus = True

    '    ''Set_Approval_Right_for_dgSummary(cModeUpd)
    'End Sub

    'Private Sub txt_Dtl_FinalClaimAmt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) 
    '    Dim line As Integer
    '    Dim i As Integer
    '    Dim seq As Integer

    '    seq = lblSeq.Text

    '    line = 0

    '    If rbViewOn_I.Checked Then
    '        For i = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
    '            If seq = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caordseq") Then
    '                line = i
    '            End If
    '        Next i

    '        txt_Dtl_FinalClaimAmt.Text = sReformatCurrency(txt_Dtl_FinalClaimAmt.Text)
    '        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caamt_final") = txt_Dtl_FinalClaimAmt.Text

    '        If txt_Dtl_FinalClaimAmt.Modified = True Then
    '            'ClaimAmt_Header = True
    '            'For index As Integer = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
    '            '    'If rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_caamt_final") <> "0.00" Then
    '            '    If rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_ttlcaamt_org") <> "0.00" Or _
    '            '       rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_ttlcaamt_final") <> "0.00" Then
    '            '        ClaimAmt_Header = False
    '            '        Exit For
    '            '    End If
    '            'Next

    '            'check_ClaimAmt_Header()
    '            'format_Approval(seq)
    '        End If
    '    Else
    '        For i = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
    '            If seq = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caordseq") Then
    '                line = i
    '            End If
    '        Next i

    '        txt_Dtl_FinalClaimAmt.Text = sReformatCurrency(txt_Dtl_FinalClaimAmt.Text)
    '        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caamt_final") = txt_Dtl_FinalClaimAmt.Text

    '        If txt_Dtl_FinalClaimAmt.Modified = True Then
    '            'ClaimAmt_Header = True
    '            'For index As Integer = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
    '            '    'If rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_caamt_final") <> "0.00" Then
    '            '    If rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_ttlcaamt_org") <> "0.00" Or _
    '            '       rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_ttlcaamt_final") <> "0.00" Then
    '            '        ClaimAmt_Header = False
    '            '        Exit For
    '            '    End If
    '            'Next

    '            'check_ClaimAmt_Header()
    '            'format_Approval(seq)
    '        End If
    '    End If
    'End Sub

    'Private Sub cbo_Dtl_ClaimAmtCurrency_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 
    '    UserEditCombo = True
    'End Sub

    'Private Sub cbo_Dtl_ClaimAmtCurrency_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) 
    '    UserEditCombo = True
    'End Sub

    'Private Sub cbo_Dtl_ClaimAmtCurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 
    '    '    'If rs_CAORDDTL.Tables.Count = 0 Then
    '    '    '    Exit Sub
    '    '    'End If

    '    '    'If rs_CAORDDTL.Tables("RESULT").Rows.Count = 0 Then
    '    '    '    Exit Sub
    '    '    'End If

    '    '    Dim line As Integer
    '    '    Dim i As Integer
    '    '    Dim seq As Integer

    '    '    If rs_CAORDDTL.Tables("result") Is Nothing Then
    '    '        Exit Sub
    '    '    End If
    '    '    If rs_CAORDITM.Tables("RESULT") Is Nothing Then
    '    '        Exit Sub
    '    '    End If

    '    '    seq = lblSeq.Text

    '    '    line = 0

    '    '    If rbViewOn_I.Checked Then
    '    '        For i = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
    '    '            If seq = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caordseq") Then
    '    '                line = i
    '    '            End If
    '    '        Next i

    '    '        'rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_cacur") = cbo_Dtl_ClaimAmtCurrency.Text

    '    '        'Dim ftycur As String
    '    '        'Dim cacur As String
    '    '        'Dim exrate As Decimal

    '    '        'ftycur = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_scfcurcde")
    '    '        'cacur = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_cacur")
    '    '        'exrate = 0.0
    '    '        'exrate = getExchangeRate(ftycur, cacur, "BuyRate")

    '    '        'If IsNumeric(rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_scftyprc")) And IsNumeric(rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caqty")) Then
    '    '        '    rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caqtyamt_org") = Decimal.Round(rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caqty") * rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_scftyprc") * exrate, 2)
    '    '        'End If

    '    '        'rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_ttlcaamt_org") = _
    '    '        'rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caqtyamt_org") + _
    '    '        'rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_caamt_org")

    '    '        'Dim gpcur As String

    '    '        'cacur = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_cacur")
    '    '        'gpcur = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_salcur")
    '    '        'exrate = 0.0
    '    '        'exrate = getExchangeRate(cacur, gpcur, "BuyRate")

    '    '        'If Not IsNumeric(rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_grspftamt")) Then
    '    '        '    Exit Sub
    '    '        'End If

    '    '        'If rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_grspftamt") = 0 Then
    '    '        '    Exit Sub
    '    '        'End If

    '    '        'rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_cavsgrspft") = ((rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_ttlcaamt_final") * exrate) / rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_grspftamt")) * 100
    '    '        'txt_Dtl_ClaimVSGPPer.Text = Decimal.Round(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_cavsgrspft"), 2)

    '    '        cbo_Dtl_ClaimToInsAmtCurrency.Text = cbo_Dtl_ClaimAmtCurrency.Text
    '    '        cbo_Dtl_ClaimToVNAmtCurrency.Text = cbo_Dtl_ClaimAmtCurrency.Text
    '    '        cbo_Dtl_ClaimToHKOAmtCurrency.Text = cbo_Dtl_ClaimAmtCurrency.Text

    '    '        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_cacur") = cbo_Dtl_ClaimAmtCurrency.Text
    '    '        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catoinscur") = cbo_Dtl_ClaimToInsAmtCurrency.Text
    '    '        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catovncur") = cbo_Dtl_ClaimToVNAmtCurrency.Text
    '    '        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catohkocur") = cbo_Dtl_ClaimToHKOAmtCurrency.Text

    '    '        lbl_Dtl_ClaimToInsAmt_ExchRate.Text = Decimal.Round(getExchangeRate(cbo_Dtl_ClaimToInsAmtCurrency.Text, cbo_Dtl_ClaimAmtCurrency.Text, "BuyRate"), 2)
    '    '        lbl_Dtl_ClaimToVNAmt_ExchRate.Text = Decimal.Round(getExchangeRate(cbo_Dtl_ClaimToVNAmtCurrency.Text, cbo_Dtl_ClaimAmtCurrency.Text, "BuyRate"), 2)
    '    '        'lbl_Dtl_ClaimToEVNAmt_ExchRate.Text = Decimal.Round(getExchangeRate(cbo_Dtl_ClaimToEVNAmtCurrency.Text, cbo_Dtl_ClaimAmtCurrency.Text, "BuyRate"), 4)
    '    '        lbl_Dtl_ClaimToHKOAmt_ExchRate.Text = Decimal.Round(getExchangeRate(cbo_Dtl_ClaimToHKOAmtCurrency.Text, cbo_Dtl_ClaimAmtCurrency.Text, "BuyRate"), 2)

    '    '        ''calculate_HKOAmount("Detail", line, False)
    '    '        'calculate_HKOAmount(line)
    '    '        txt_Dtl_ClaimToHKOAmt.Text = Decimal.Round(rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catohkoamt"), 2)

    '    '        If UserEditCombo = True Then
    '    '            If Not (rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*ADD*~" Or _
    '    '                rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*NEW*~" Or _
    '    '                rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~" Or _
    '    '                rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*DEL*~") Then
    '    '                rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~"
    '    '            End If
    '    '        End If

    '    '        Dim newseq As Integer
    '    '        newseq = rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("cai_CAORDSEQ")
    '    '        Call display_CAORDITM(newseq)


    '    '        If sHdrClaimAmtPer = "I" Then
    '    '            'cal_ClaimAmt_CAORDHDR()
    '    '            'cal_ClaimAmt_CAORDDTL()
    '    '        ElseIf sHdrClaimAmtPer = "S" Then
    '    '            'cal_ClaimAmt_CAORDITM()
    '    '            'cal_ClaimAmt_CAORDHDR()
    '    '        End If
    '    '    Else
    '    '        For i = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
    '    '            If seq = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caordseq") Then
    '    '                line = i
    '    '            End If
    '    '        Next i

    '    '        'rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_cacur") = cbo_Dtl_ClaimAmtCurrency.Text

    '    '        'Dim ftycur As String
    '    '        'Dim cacur As String
    '    '        'Dim exrate As Decimal

    '    '        'ftycur = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_scfcurcde")
    '    '        'cacur = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_cacur")
    '    '        'exrate = 0.0
    '    '        'exrate = getExchangeRate(ftycur, cacur, "BuyRate")

    '    '        'If IsNumeric(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_scftyprc")) And IsNumeric(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caqty")) Then
    '    '        '    rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caqtyamt_org") = Decimal.Round(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caqty") * rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_scftyprc") * exrate, 2)
    '    '        'End If

    '    '        'rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_ttlcaamt_org") = _
    '    '        'rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caqtyamt_org") + _
    '    '        'rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_caamt_org")

    '    '        'Dim gpcur As String

    '    '        'cacur = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_cacur")
    '    '        'gpcur = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_salcur")
    '    '        'exrate = 0.0
    '    '        'exrate = getExchangeRate(cacur, gpcur, "BuyRate")

    '    '        'If Not IsNumeric(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_grspftamt")) Then
    '    '        '    Exit Sub
    '    '        'End If

    '    '        'If rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_grspftamt") = 0 Then
    '    '        '    Exit Sub
    '    '        'End If

    '    '        'rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_cavsgrspft") = ((rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_ttlcaamt_final") * exrate) / rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_grspftamt")) * 100
    '    '        'txt_Dtl_ClaimVSGPPer.Text = Decimal.Round(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_cavsgrspft"), 2)

    '    '        cbo_Dtl_ClaimToInsAmtCurrency.Text = cbo_Dtl_ClaimAmtCurrency.Text
    '    '        cbo_Dtl_ClaimToVNAmtCurrency.Text = cbo_Dtl_ClaimAmtCurrency.Text
    '    '        cbo_Dtl_ClaimToHKOAmtCurrency.Text = cbo_Dtl_ClaimAmtCurrency.Text

    '    '        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_cacur") = cbo_Dtl_ClaimAmtCurrency.Text
    '    '        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catoinscur") = cbo_Dtl_ClaimToInsAmtCurrency.Text
    '    '        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catovncur") = cbo_Dtl_ClaimToVNAmtCurrency.Text
    '    '        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catohkocur") = cbo_Dtl_ClaimToHKOAmtCurrency.Text

    '    '        lbl_Dtl_ClaimToInsAmt_ExchRate.Text = Decimal.Round(getExchangeRate(cbo_Dtl_ClaimToInsAmtCurrency.Text, cbo_Dtl_ClaimAmtCurrency.Text, "BuyRate"), 2)
    '    '        lbl_Dtl_ClaimToVNAmt_ExchRate.Text = Decimal.Round(getExchangeRate(cbo_Dtl_ClaimToVNAmtCurrency.Text, cbo_Dtl_ClaimAmtCurrency.Text, "BuyRate"), 2)
    '    '        'lbl_Dtl_ClaimToEVNAmt_ExchRate.Text = Decimal.Round(getExchangeRate(cbo_Dtl_ClaimToEVNAmtCurrency.Text, cbo_Dtl_ClaimAmtCurrency.Text, "BuyRate"), 4)
    '    '        lbl_Dtl_ClaimToHKOAmt_ExchRate.Text = Decimal.Round(getExchangeRate(cbo_Dtl_ClaimToHKOAmtCurrency.Text, cbo_Dtl_ClaimAmtCurrency.Text, "BuyRate"), 2)

    '    '        ''calculate_HKOAmount("Detail", line, False)
    '    '        'calculate_HKOAmount(line)
    '    '        txt_Dtl_ClaimToHKOAmt.Text = Decimal.Round(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catohkoamt"), 2)

    '    '        If UserEditCombo = True Then
    '    '            If Not (rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*ADD*~" Or _
    '    '                rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*NEW*~" Or _
    '    '                rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*UPD*~" Or _
    '    '                rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*DEL*~") Then
    '    '                rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*UPD*~"
    '    '            End If
    '    '        End If

    '    '        Dim newseq As Integer
    '    '        newseq = rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("CAD_CAORDSEQ")
    '    '        Call display_CAORDDTL(newseq)


    '    '        If sHdrClaimAmtPer = "I" Then
    '    '            'cal_ClaimAmt_CAORDHDR()
    '    '            'cal_ClaimAmt_CAORDDTL()
    '    '        ElseIf sHdrClaimAmtPer = "S" Then
    '    '            'cal_ClaimAmt_CAORDITM()
    '    '            'cal_ClaimAmt_CAORDHDR()
    '    '        End If
    '    '    End If
    '    '    If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
    '    '        Exit Sub
    '    '    End If
    '    '    If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
    '    '        Exit Sub
    '    '    End If
    '    '    If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
    '    '        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
    '    '    Else
    '    '        '''1122
    '    '        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
    '    '    End If

    '    '    Recordstatus = True
    '    'End Sub

    '    'Private Sub txt_Dtl_ClaimToInsAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 
    '    '    Dim allowedChars As String = "0123456789."

    '    '    If allowedChars.IndexOf(e.KeyChar) = -1 Then
    '    '        ' Invalid Character
    '    '        e.KeyChar = ""
    '    '        Exit Sub
    '    '    End If

    '    '    Dim currenttext As String
    '    '    currenttext = txt_Dtl_ClaimToInsAmt.Text & e.KeyChar

    '    '    'check for only 1.
    '    '    If e.KeyChar = "." Then
    '    '        If Mid(currenttext, 1, Len(currenttext) - 1).IndexOf(".") <> -1 Then
    '    '            e.KeyChar = ""
    '    '            Exit Sub
    '    '        End If
    '    '    End If
    'End Sub

    'Private Sub txt_Dtl_ClaimToInsAmt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) 
    '    'Dim line As Integer
    '    'Dim i As Integer
    '    'Dim seq As Integer

    '    'seq = lblSeq.Text

    '    'line = 0

    '    'If rbViewOn_I.Checked Then
    '    '    For i = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
    '    '        If seq = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caordseq") Then
    '    '            line = i
    '    '        End If
    '    '    Next i

    '    '    'If IsNumeric(txt_Dtl_ClaimToInsAmt.Text) Then
    '    '    If e.KeyCode <> Keys.Decimal Or txt_Dtl_ClaimToInsAmt.Text.IndexOf(".") <> txt_Dtl_ClaimToInsAmt.Text.Length - 1 Then
    '    '        Dim pos As Integer = txt_Dtl_ClaimToInsAmt.SelectionStart
    '    '        If e.KeyCode = Keys.Back And txt_Dtl_ClaimToInsAmt.Text.Length > 0 Then
    '    '            If pos = txt_Dtl_ClaimToInsAmt.Text.Length Then
    '    '                txt_Dtl_ClaimToInsAmt.Text = txt_Dtl_ClaimToInsAmt.Text.Substring(0, txt_Dtl_ClaimToInsAmt.Text.Length - 1)
    '    '                txt_Dtl_ClaimToInsAmt.Select(pos, 0)
    '    '            ElseIf pos > 0 And pos < txt_Dtl_ClaimToInsAmt.Text.Length Then
    '    '                txt_Dtl_ClaimToInsAmt.Text = _
    '    '                txt_Dtl_ClaimToInsAmt.Text.Substring(0, pos - 1) + _
    '    '                txt_Dtl_ClaimToInsAmt.Text.Substring(pos, txt_Dtl_ClaimToInsAmt.Text.Length - pos)
    '    '                txt_Dtl_ClaimToInsAmt.Select(pos - 1, 0)
    '    '            End If
    '    '        End If

    '    '        If txt_Dtl_ClaimToInsAmt.Text.Length = 0 Then
    '    '            txt_Dtl_ClaimToInsAmt.Text = "0.00"
    '    '        Else
    '    '            txt_Dtl_ClaimToInsAmt.Text = Decimal.Round(Convert.ToDecimal(txt_Dtl_ClaimToInsAmt.Text), 2)
    '    '        End If

    '    '        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catoinsamt") = Val(txt_Dtl_ClaimToInsAmt.Text)

    '    '        If Not (rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*ADD*~" Or _
    '    '                rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*NEW*~" Or _
    '    '                rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~" Or _
    '    '                rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*DEL*~") Then
    '    '            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~"
    '    '        End If

    '    '        ''calculate_HKOAmount("Detail", line, False)
    '    '        'calculate_HKOAmount(line)
    '    '        txt_Dtl_ClaimToHKOAmt.Text = Decimal.Round(rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catohkoamt"), 2)
    '    '    End If

    '    '    If sHdrClaimAmtPer = "I" Then
    '    '        'cal_ClaimAmt_CAORDHDR()
    '    '        'cal_ClaimAmt_CAORDDTL()
    '    '    ElseIf sHdrClaimAmtPer = "S" Then
    '    '        'cal_ClaimAmt_CAORDITM()
    '    '        'cal_ClaimAmt_CAORDHDR()
    '    '    End If
    '    '    'End If
    '    'Else
    '    '    For i = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
    '    '        If seq = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caordseq") Then
    '    '            line = i
    '    '        End If
    '    '    Next i

    '    '    'If IsNumeric(txt_Dtl_ClaimToInsAmt.Text) Then
    '    '    If e.KeyCode <> Keys.Decimal Or txt_Dtl_ClaimToInsAmt.Text.IndexOf(".") <> txt_Dtl_ClaimToInsAmt.Text.Length - 1 Then
    '    '        Dim pos As Integer = txt_Dtl_ClaimToInsAmt.SelectionStart
    '    '        If e.KeyCode = Keys.Back And txt_Dtl_ClaimToInsAmt.Text.Length > 0 Then
    '    '            If pos = txt_Dtl_ClaimToInsAmt.Text.Length Then
    '    '                txt_Dtl_ClaimToInsAmt.Text = txt_Dtl_ClaimToInsAmt.Text.Substring(0, txt_Dtl_ClaimToInsAmt.Text.Length - 1)
    '    '                txt_Dtl_ClaimToInsAmt.Select(pos, 0)
    '    '            ElseIf pos > 0 And pos < txt_Dtl_ClaimToInsAmt.Text.Length Then
    '    '                txt_Dtl_ClaimToInsAmt.Text = _
    '    '                txt_Dtl_ClaimToInsAmt.Text.Substring(0, pos - 1) + _
    '    '                txt_Dtl_ClaimToInsAmt.Text.Substring(pos, txt_Dtl_ClaimToInsAmt.Text.Length - pos)
    '    '                txt_Dtl_ClaimToInsAmt.Select(pos - 1, 0)
    '    '            End If
    '    '        End If

    '    '        If txt_Dtl_ClaimToInsAmt.Text.Length = 0 Then
    '    '            txt_Dtl_ClaimToInsAmt.Text = "0.00"
    '    '        Else
    '    '            txt_Dtl_ClaimToInsAmt.Text = Decimal.Round(Convert.ToDecimal(txt_Dtl_ClaimToInsAmt.Text), 2)
    '    '        End If

    '    '        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catoinsamt") = txt_Dtl_ClaimToInsAmt.Text

    '    '        If Not (rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*ADD*~" Or _
    '    '                rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*NEW*~" Or _
    '    '                rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~" Or _
    '    '                rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*DEL*~") Then
    '    '            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~"
    '    '        End If

    '    '        ''calculate_HKOAmount("Detail", line, False)
    '    '        'calculate_HKOAmount(line)
    '    '        txt_Dtl_ClaimToHKOAmt.Text = Decimal.Round(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catohkoamt"), 2)
    '    '    End If

    '    '    If sHdrClaimAmtPer = "I" Then
    '    '        'cal_ClaimAmt_CAORDHDR()
    '    '        'cal_ClaimAmt_CAORDDTL()
    '    '    ElseIf sHdrClaimAmtPer = "S" Then
    '    '        'cal_ClaimAmt_CAORDITM()
    '    '        'cal_ClaimAmt_CAORDHDR()
    '    '    End If
    '    '    'End If
    '    'End If
    'End Sub

    ''Private Sub txt_Dtl_ClaimToInsAmt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) 
    ''    Dim line As Integer
    ''    Dim i As Integer
    ''    Dim seq As Integer

    ''    seq = lblSeq.Text

    ''    line = 0

    ''    If rbViewOn_I.Checked Then
    ''        For i = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
    ''            If seq = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caordseq") Then
    ''                line = i
    ''            End If
    ''        Next i

    ''        txt_Dtl_ClaimToInsAmt.Text = sReformatCurrency(txt_Dtl_ClaimToInsAmt.Text)
    ''        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catoinsamt") = Val(txt_Dtl_ClaimToInsAmt.Text)
    ''    Else
    ''        For i = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
    ''            If seq = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caordseq") Then
    ''                line = i
    ''            End If
    ''        Next i

    ''        txt_Dtl_ClaimToInsAmt.Text = sReformatCurrency(txt_Dtl_ClaimToInsAmt.Text)
    ''        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catoinsamt") = Val(txt_Dtl_ClaimToInsAmt.Text)
    ''    End If
    ''End Sub

    ''Private Sub txt_Dtl_ClaimToVNAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 
    ''    Dim allowedChars As String = "0123456789."

    ''    If allowedChars.IndexOf(e.KeyChar) = -1 Then
    ''        ' Invalid Character
    ''        e.KeyChar = ""
    ''        Exit Sub
    ''    End If

    ''    Dim currenttext As String
    ''    currenttext = txt_Dtl_ClaimToVNAmt.Text & e.KeyChar

    ''    'check for only 1.
    ''    If e.KeyChar = "." Then
    ''        If Mid(currenttext, 1, Len(currenttext) - 1).IndexOf(".") <> -1 Then
    ''            e.KeyChar = ""
    ''            Exit Sub
    ''        End If
    ''    End If
    ''End Sub

    ''Private Sub txt_Dtl_ClaimToVNAmt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) 
    ''    Dim line As Integer
    ''    Dim i As Integer
    ''    Dim seq As Integer

    ''    seq = lblSeq.Text

    ''    line = 0
    ''    If rbViewOn_I.Checked Then
    ''        For i = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
    ''            If seq = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caordseq") Then
    ''                line = i
    ''            End If
    ''        Next i

    ''        'If IsNumeric(txt_Dtl_ClaimToVNAmt.Text) Then
    ''        If e.KeyCode <> Keys.Decimal Or txt_Dtl_ClaimToVNAmt.Text.IndexOf(".") <> txt_Dtl_ClaimToVNAmt.Text.Length - 1 Then
    ''            Dim pos As Integer = txt_Dtl_ClaimToVNAmt.SelectionStart
    ''            If e.KeyCode = Keys.Back And txt_Dtl_ClaimToVNAmt.Text.Length > 0 Then
    ''                If pos = txt_Dtl_ClaimToVNAmt.Text.Length Then
    ''                    txt_Dtl_ClaimToVNAmt.Text = txt_Dtl_ClaimToVNAmt.Text.Substring(0, txt_Dtl_ClaimToVNAmt.Text.Length - 1)
    ''                    txt_Dtl_ClaimToVNAmt.Select(pos, 0)
    ''                ElseIf pos > 0 And pos < txt_Dtl_ClaimToVNAmt.Text.Length Then
    ''                    txt_Dtl_ClaimToVNAmt.Text = _
    ''                    txt_Dtl_ClaimToVNAmt.Text.Substring(0, pos - 1) + _
    ''                    txt_Dtl_ClaimToVNAmt.Text.Substring(pos, txt_Dtl_ClaimToVNAmt.Text.Length - pos)
    ''                    txt_Dtl_ClaimToVNAmt.Select(pos - 1, 0)
    ''                End If
    ''            End If

    ''            If txt_Dtl_ClaimToVNAmt.Text.Length = 0 Then
    ''                txt_Dtl_ClaimToVNAmt.Text = "0.00"
    ''            Else
    ''                txt_Dtl_ClaimToVNAmt.Text = Decimal.Round(Convert.ToDecimal(txt_Dtl_ClaimToVNAmt.Text), 2)
    ''            End If

    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catovnamt") = Val(txt_Dtl_ClaimToVNAmt.Text)

    ''            If Not (rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*ADD*~" Or _
    ''                    rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*NEW*~" Or _
    ''                    rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~" Or _
    ''                    rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*DEL*~") Then
    ''                rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~"
    ''            End If

    ''            ''calculate_HKOAmount("Detail", line, False)
    ''            'calculate_HKOAmount(line)
    ''            txt_Dtl_ClaimToHKOAmt.Text = Decimal.Round(rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catohkoamt"), 2)
    ''        End If

    ''        If sHdrClaimAmtPer = "I" Then
    ''            'cal_ClaimAmt_CAORDHDR()
    ''            'cal_ClaimAmt_CAORDDTL()
    ''        ElseIf sHdrClaimAmtPer = "S" Then
    ''            'cal_ClaimAmt_CAORDITM()
    ''            'cal_ClaimAmt_CAORDHDR()
    ''        End If
    ''        'End If
    ''    Else
    ''        For i = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
    ''            If seq = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caordseq") Then
    ''                line = i
    ''            End If
    ''        Next i

    ''        'If IsNumeric(txt_Dtl_ClaimToVNAmt.Text) Then
    ''        If e.KeyCode <> Keys.Decimal Or txt_Dtl_ClaimToVNAmt.Text.IndexOf(".") <> txt_Dtl_ClaimToVNAmt.Text.Length - 1 Then
    ''            Dim pos As Integer = txt_Dtl_ClaimToVNAmt.SelectionStart
    ''            If e.KeyCode = Keys.Back And txt_Dtl_ClaimToVNAmt.Text.Length > 0 Then
    ''                If pos = txt_Dtl_ClaimToVNAmt.Text.Length Then
    ''                    txt_Dtl_ClaimToVNAmt.Text = txt_Dtl_ClaimToVNAmt.Text.Substring(0, txt_Dtl_ClaimToVNAmt.Text.Length - 1)
    ''                    txt_Dtl_ClaimToVNAmt.Select(pos, 0)
    ''                ElseIf pos > 0 And pos < txt_Dtl_ClaimToVNAmt.Text.Length Then
    ''                    txt_Dtl_ClaimToVNAmt.Text = _
    ''                    txt_Dtl_ClaimToVNAmt.Text.Substring(0, pos - 1) + _
    ''                    txt_Dtl_ClaimToVNAmt.Text.Substring(pos, txt_Dtl_ClaimToVNAmt.Text.Length - pos)
    ''                    txt_Dtl_ClaimToVNAmt.Select(pos - 1, 0)
    ''                End If
    ''            End If

    ''            If txt_Dtl_ClaimToVNAmt.Text.Length = 0 Then
    ''                txt_Dtl_ClaimToVNAmt.Text = "0.00"
    ''            Else
    ''                txt_Dtl_ClaimToVNAmt.Text = Decimal.Round(Convert.ToDecimal(txt_Dtl_ClaimToVNAmt.Text), 2)
    ''            End If

    ''            rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catovnamt") = txt_Dtl_ClaimToVNAmt.Text

    ''            If Not (rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*ADD*~" Or _
    ''                    rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*NEW*~" Or _
    ''                    rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~" Or _
    ''                    rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*DEL*~") Then
    ''                rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~"
    ''            End If

    ''            ''calculate_HKOAmount("Detail", line, False)
    ''            'calculate_HKOAmount(line)
    ''            txt_Dtl_ClaimToHKOAmt.Text = Decimal.Round(rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catohkoamt"), 2)
    ''        End If

    ''        If sHdrClaimAmtPer = "I" Then
    ''            'cal_ClaimAmt_CAORDHDR()
    ''            'cal_ClaimAmt_CAORDDTL()
    ''        ElseIf sHdrClaimAmtPer = "S" Then
    ''            'cal_ClaimAmt_CAORDITM()
    ''            'cal_ClaimAmt_CAORDHDR()
    ''        End If
    ''        'End If
    ''    End If
    ''End Sub

    ''Private Sub txt_Dtl_ClaimToVNAmt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) 
    ''    Dim line As Integer
    ''    Dim i As Integer
    ''    Dim seq As Integer

    ''    seq = lblSeq.Text

    ''    line = 0

    ''    If rbViewOn_I.Checked Then
    ''        For i = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
    ''            If seq = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caordseq") Then
    ''                line = i
    ''            End If
    ''        Next i

    ''        If txt_Dtl_ClaimToVNAmt.Text.Length = 0 Then
    ''            txt_Dtl_ClaimToVNAmt.Text = "0.00"
    ''        Else
    ''            txt_Dtl_ClaimToVNAmt.Text = Decimal.Round(Convert.ToDecimal(txt_Dtl_ClaimToVNAmt.Text), 2)
    ''        End If

    ''        txt_Dtl_ClaimToVNAmt.Text = sReformatCurrency(txt_Dtl_ClaimToVNAmt.Text)
    ''        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catovnamt") = Val(txt_Dtl_ClaimToVNAmt.Text)
    ''    Else
    ''        For i = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
    ''            If seq = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caordseq") Then
    ''                line = i
    ''            End If
    ''        Next i

    ''        If txt_Dtl_ClaimToVNAmt.Text.Length = 0 Then
    ''            txt_Dtl_ClaimToVNAmt.Text = "0.00"
    ''        Else
    ''            txt_Dtl_ClaimToVNAmt.Text = Decimal.Round(Convert.ToDecimal(txt_Dtl_ClaimToVNAmt.Text), 2)
    ''        End If

    ''        txt_Dtl_ClaimToVNAmt.Text = sReformatCurrency(txt_Dtl_ClaimToVNAmt.Text)
    ''        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catovnamt") = Val(txt_Dtl_ClaimToVNAmt.Text)
    ''    End If
    ''End Sub

    Private Sub cmd_Hdr_Apv1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Hdr_Apv1.Click
        'If MsgBox("Are you sure to change status to the APV1?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '    Dim final_claim_amt As Decimal
        '    Dim remain_claim_amt As Decimal

        '    Dim final_claim_limit_currency As String
        '    Dim final_claim_amt_currency As String

        '    Dim exrate As Decimal

        '    Dim bCanApp As Boolean = True
        '    Dim sSeq_Item As String = ""

        '    For index As Integer = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1

        '        final_claim_limit_currency = rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_salcur")
        '        final_claim_amt_currency = rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_cacur")
        '        exrate = getExchangeRate(final_claim_amt_currency, final_claim_limit_currency, "BuyRate")

        '        final_claim_amt = rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_ttlcaamt_final")
        '        ' remain_claim_amt = rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_caremamt")

        '        If final_claim_amt * exrate > remain_claim_amt Then
        '            bCanApp = False
        '            sSeq_Item = rs_CAORDITM.Tables("RESULT").Rows(index).Item("cai_caordseq")
        '            Exit For
        '        End If

        '    Next

        '    If bCanApp Then
        '        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "APV1a"
        '        display_combo("APV1a", cboClaimSts)
        '        chkapv1a.Enabled = False
        '        cmdAdd.Enabled = False

        '        Call set_app_buttons()


        '        'cmdSave_Click(sender, e)
        '    Else
        '        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "OPEN"
        '        display_combo("OPEN", cboClaimSts)
        '        MsgBox("Item Seq No. " + sSeq_Item + " exceeds the Remain Claim Amount, this Claim cannot be approved!", MsgBoxStyle.Exclamation)
        '    End If
        'End If
    End Sub

    Private Sub cmd_Hdr_Apv2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Hdr_Apv2.Click
        'If MsgBox("Are you sure to change status to the APV2?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "APV1b"
        '    display_combo("APV1b", cboClaimSts)
        '    chkapv1b.Enabled = False

        '    '''need to check user-group & rank
        '    If gsUsrRank < 3 Then
        '        'cmd_close.Enabled = True

        '        'cboClaimPaySTS.Enabled = True
        '        'gb_pay.Enabled = True
        '        'gb_income.Enabled = True

        '        'dtHDRPAIDDAT.Enabled = True
        '        'cboSETTLE_CUS.Enabled = True
        '        'dtHDRRCVDAT.Enabled = True
        '        'cboSETTLE_FTY.Enabled = True
        '        'cboAPRVSTS.Enabled = True
        '        chkClose.Enabled = True
        '    End If
        '    cmdAdd.Enabled = False

        '    cbo_Hdr_ClaimAmtCurrency.Enabled = False
        '    cbo_Hdr_ClaimToInsAmtCurrency.Enabled = False
        '    cbo_Hdr_ClaimToVNAmtCurrency.Enabled = False
        '    cbo_Hdr_ClaimToHKOAmtCurrency.Enabled = False
        '    txt_Hdr_OrgClaimAmt.Enabled = False
        '    txt_Hdr_FinalClaimAmt.Enabled = False
        '    txt_Hdr_ClaimToInsAmt.Enabled = False
        '    txt_Hdr_ClaimToVNAmt.Enabled = False
        '    txt_Hdr_ClaimToHKOAmt.Enabled = False

        '    Call set_app_buttons()

        '    '            cmdSave_Click(sender, e)
        'End If
    End Sub

    ''Private Sub cb_Dtl_APV1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) 
    ''    If Recorddisplay = True Then
    ''        Exit Sub
    ''    End If

    ''    If rbViewOn_I.Checked Then
    ''        Dim seq As Integer
    ''        Dim line As Integer
    ''        Dim i As Integer

    ''        seq = lblSeq.Text
    ''        line = 0

    ''        For i = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
    ''            If seq = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caordseq") Then
    ''                line = i
    ''            End If
    ''        Next i

    ''        If cb_Dtl_APV1.Checked = True Then
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_app1flg") = "Y"
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_app1flgby") = gsUsrID
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_app1flgdat") = Format(Date.Today, "MM/dd/yyyy")
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_app2flg") = "N"
    ''        Else
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_app1flg") = ""
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_app1flgby") = ""
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_app1flgdat") = "01/01/1900"
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_app2flg") = ""
    ''        End If

    ''        If Not (rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*ADD*~" Or _
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*NEW*~" Or _
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~" Or _
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*DEL*~") Then
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~"
    ''        End If

    ''        Recordstatus = True
    ''        sReadingSeq_Item = seq
    ''        Dim newseq As Integer
    ''        newseq = rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("cai_CAORDSEQ")
    ''        Call display_CAORDITM(newseq)

    ''    End If
    ''End Sub

    ''Private Sub cb_Dtl_APV2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) 
    ''    If Recorddisplay = True Then
    ''        Exit Sub
    ''    End If

    ''    If rbViewOn_I.Checked Then
    ''        Dim seq As Integer
    ''        Dim line As Integer
    ''        Dim i As Integer

    ''        seq = lblSeq.Text
    ''        line = 0

    ''        For i = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
    ''            If seq = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caordseq") Then
    ''                line = i
    ''            End If
    ''        Next i

    ''        If cb_Dtl_APV2.Checked = True Then
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_app2flg") = "Y"
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_app2flgby") = gsUsrID
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_app2flgdat") = Format(Date.Today, "MM/dd/yyyy")
    ''        Else
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_app2flg") = ""
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_app2flgby") = ""
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_app2flgdat") = "01/01/1900"
    ''        End If

    ''        If Not (rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*ADD*~" Or _
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*NEW*~" Or _
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~" Or _
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*DEL*~") Then
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~"
    ''        End If

    ''        Recordstatus = True
    ''        sReadingSeq_Item = seq
    ''        Dim newseq As Integer
    ''        newseq = rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("cai_CAORDSEQ")
    ''        Call display_CAORDITM(newseq)

    ''    End If
    ''End Sub

    ''Private Sub cbDel_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkDelete.MouseUp
    ''    If Recorddisplay = True Then
    ''        Exit Sub
    ''    End If

    ''    If rbViewOn_I.Checked Then
    ''        If sHdrClaimAmtPer = "C" Or sHdrClaimAmtPer = "I" Then
    ''            Dim seq As Integer
    ''            Dim line As Integer
    ''            Dim i As Integer
    ''            Dim sYesNo As String = "Y"

    ''            seq = lblSeq.Text
    ''            line = 0

    ''            For i = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
    ''                If seq = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caordseq") Then
    ''                    line = i
    ''                End If
    ''            Next i

    ''            If chkDelete.Checked = True Then
    ''                sYesNo = "Y"
    ''                sCheckedLevel = "I"
    ''            Else
    ''                sYesNo = ""
    ''                sCheckedLevel = "C"
    ''            End If

    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_del") = sYesNo

    ''            If sYesNo = "Y" Then
    ''                Call Delete_dtl_from_itm(line)
    ''            Else
    ''                Call UNDelete_dtl_from_itm(line)
    ''            End If

    ''            'If sYesNo = "Y" Then
    ''            '    rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_ttlcaamt_org") = "0.00"
    ''            '    rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_ttlcaamt_final") = "0.00"
    ''            '    rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catoinscur") = "USD"
    ''            '    rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catoinsamt") = "0.00"
    ''            '    rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catovncur") = "USD"
    ''            '    rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catovnamt") = "0.00"
    ''            '    rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catohkocur") = "USD"
    ''            '    rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_catohkoamt") = "0.00"
    ''            'Else
    ''            '    recal_item_shipment()
    ''            'End If

    ''            If sHdrClaimAmtPer = "C" Then
    ''                'cal_ClaimAmt_CAORDITM()
    ''                'cal_ClaimAmt_CAORDDTL()
    ''            ElseIf sHdrClaimAmtPer = "I" Then
    ''                'cal_ClaimAmt_CAORDHDR()
    ''                'cal_ClaimAmt_CAORDDTL()
    ''            Else
    ''                'cal_ClaimAmt_CAORDITM()
    ''                'cal_ClaimAmt_CAORDHDR()
    ''            End If

    ''            If Not (rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*ADD*~" Or _
    ''                rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*NEW*~" Or _
    ''                rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~" Or _
    ''                rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*DEL*~") Then
    ''                rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~"
    ''            End If

    ''            display_CAORDITM(seq)

    ''            For index As Integer = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
    ''                If rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_itmno") = rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_itmno") Then
    ''                    rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_del") = sYesNo

    ''                    If sYesNo = "Y" Then
    ''                        Call Delete_itm_from_dtl(index)
    ''                    Else
    ''                        Call UNDelete_itm_from_dtl(index)
    ''                    End If

    ''                    'If sYesNo = "Y" Then
    ''                    '    rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_ttlcaamt_org") = "0.00"
    ''                    '    rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_ttlcaamt_final") = "0.00"
    ''                    '    rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_catoinscur") = "USD"
    ''                    '    rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_catoinsamt") = "0.00"
    ''                    '    rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_catovncur") = "USD"
    ''                    '    rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_catovnamt") = "0.00"
    ''                    '    rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_catohkocur") = "USD"
    ''                    '    rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_catohkoamt") = "0.00"
    ''                    'Else
    ''                    '    recal_item_shipment()
    ''                    'End If

    ''                    If sHdrClaimAmtPer = "C" Then
    ''                        'cal_ClaimAmt_CAORDITM()
    ''                        'cal_ClaimAmt_CAORDDTL()
    ''                    ElseIf sHdrClaimAmtPer = "I" Then
    ''                        'cal_ClaimAmt_CAORDHDR()
    ''                        'cal_ClaimAmt_CAORDDTL()
    ''                    Else
    ''                        'cal_ClaimAmt_CAORDITM()
    ''                        'cal_ClaimAmt_CAORDHDR()
    ''                    End If

    ''                    If Not (rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_creusr") = "~*ADD*~" Or _
    ''                        rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_creusr") = "~*NEW*~" Or _
    ''                        rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_creusr") = "~*UPD*~" Or _
    ''                        rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_creusr") = "~*DEL*~") Then
    ''                        rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_creusr") = "~*UPD*~"
    ''                    End If
    ''                End If
    ''            Next
    ''        ElseIf sHdrClaimAmtPer = "S" Then
    ''            Dim seq As Integer
    ''            Dim line As Integer
    ''            Dim i As Integer
    ''            Dim sItmNo As String
    ''            Dim sYesNo As String = "Y"

    ''            seq = lblSeq.Text
    ''            line = 0

    ''            For i = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
    ''                If seq = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caordseq") Then
    ''                    line = i
    ''                End If
    ''            Next i

    ''            If chkDelete.Checked = True Then
    ''                sYesNo = "Y"
    ''                sCheckedLevel = "I"
    ''            Else
    ''                sYesNo = ""
    ''                sCheckedLevel = "C"
    ''            End If

    ''            sItmNo = rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_itmno").ToString.Trim
    ''            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_del") = sYesNo

    ''            For index As Integer = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
    ''                If rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_itmno") = sItmNo Then
    ''                    rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_del") = sYesNo

    ''                    If sYesNo = "Y" Then
    ''                        rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_ttlcaamt_org") = "0.00"
    ''                        rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_ttlcaamt_final") = "0.00"
    ''                        rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_catoinscur") = "USD"
    ''                        rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_catoinsamt") = "0.00"
    ''                        rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_catovncur") = "USD"
    ''                        rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_catovnamt") = "0.00"
    ''                        rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_catohkocur") = "USD"
    ''                        rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_catohkoamt") = "0.00"
    ''                    Else
    ''                        recal_item_shipment(rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_shpno"), rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_shpseq"))
    ''                    End If

    ''                    If Not (rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_creusr") = "~*ADD*~" Or _
    ''                        rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_creusr") = "~*NEW*~" Or _
    ''                        rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_creusr") = "~*UPD*~" Or _
    ''                        rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_creusr") = "~*DEL*~") Then
    ''                        rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_creusr") = "~*UPD*~"
    ''                    End If
    ''                End If
    ''            Next

    ''            If sHdrClaimAmtPer = "C" Then
    ''                'cal_ClaimAmt_CAORDITM()
    ''                'cal_ClaimAmt_CAORDDTL()
    ''            ElseIf sHdrClaimAmtPer = "I" Then
    ''                'cal_ClaimAmt_CAORDHDR()
    ''                'cal_ClaimAmt_CAORDDTL()
    ''            Else
    ''                'cal_ClaimAmt_CAORDITM()
    ''                'cal_ClaimAmt_CAORDHDR()
    ''            End If

    ''            display_CAORDITM(seq)
    ''        End If
    ''    Else
    ''        Dim seq As Integer
    ''        Dim line As Integer
    ''        Dim i As Integer
    ''        Dim sYesNo As String = "Y"

    ''        seq = lblSeq.Text
    ''        line = 0

    ''        For i = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
    ''            If seq = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caordseq") Then
    ''                line = i
    ''            End If
    ''        Next i

    ''        If chkDelete.Checked = True Then
    ''            sYesNo = "Y"
    ''            sCheckedLevel = "S"
    ''        Else
    ''            sYesNo = ""
    ''            sCheckedLevel = "C"
    ''        End If

    ''        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_del") = sYesNo

    ''        If sYesNo = "Y" Then
    ''            rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_ttlcaamt_org") = "0.00"
    ''            rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_ttlcaamt_final") = "0.00"
    ''            rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catoinscur") = "USD"
    ''            rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catoinsamt") = "0.00"
    ''            rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catovncur") = "USD"
    ''            rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catovnamt") = "0.00"
    ''            rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catohkocur") = "USD"
    ''            rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_catohkoamt") = "0.00"
    ''        Else
    ''            recal_item_shipment()
    ''        End If

    ''        If sHdrClaimAmtPer = "C" Then
    ''            'cal_ClaimAmt_CAORDITM()
    ''            'cal_ClaimAmt_CAORDDTL()
    ''        ElseIf sHdrClaimAmtPer = "I" Then
    ''            'cal_ClaimAmt_CAORDHDR()
    ''            'cal_ClaimAmt_CAORDDTL()
    ''        Else
    ''            'cal_ClaimAmt_CAORDITM()
    ''            'cal_ClaimAmt_CAORDHDR()
    ''        End If

    ''        If Not (rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*ADD*~" Or _
    ''            rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*NEW*~" Or _
    ''            rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*UPD*~" Or _
    ''            rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*DEL*~") Then
    ''            rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*UPD*~"
    ''        End If

    ''        display_CAORDDTL(seq)

    ''        Dim bAll As Boolean = True

    ''        If sYesNo = "Y" Then
    ''            For index As Integer = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
    ''                If rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_itmno") = rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_itmno") Then
    ''                    If rs_CAORDDTL.Tables("RESULT").Rows(index).Item("cad_del") <> sYesNo Then
    ''                        bAll = False
    ''                        Exit For
    ''                    End If
    ''                End If
    ''            Next
    ''        End If

    ''        If bAll Then
    ''            For index1 As Integer = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
    ''                If rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_itmno") = rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_itmno") Then
    ''                    rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_del") = sYesNo

    ''                    If sYesNo = "Y" Then
    ''                        rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_ttlcaamt_org") = "0.00"
    ''                        rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_ttlcaamt_final") = "0.00"
    ''                        rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_catoinscur") = "USD"
    ''                        rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_catoinsamt") = "0.00"
    ''                        rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_catovncur") = "USD"
    ''                        rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_catovnamt") = "0.00"
    ''                        rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_catohkocur") = "USD"
    ''                        rs_CAORDITM.Tables("RESULT").Rows(index1).Item("cai_catohkoamt") = "0.00"
    ''                    Else
    ''                        recal_item_shipment()
    ''                    End If

    ''                    If sHdrClaimAmtPer = "C" Then
    ''                        'cal_ClaimAmt_CAORDITM()
    ''                        'cal_ClaimAmt_CAORDDTL()
    ''                    ElseIf sHdrClaimAmtPer = "I" Then
    ''                        'cal_ClaimAmt_CAORDHDR()
    ''                        'cal_ClaimAmt_CAORDDTL()
    ''                    Else
    ''                        'cal_ClaimAmt_CAORDITM()
    ''                        'cal_ClaimAmt_CAORDHDR()
    ''                    End If

    ''                    If Not (rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_creusr") = "~*ADD*~" Or _
    ''                         rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_creusr") = "~*NEW*~" Or _
    ''                         rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_creusr") = "~*UPD*~" Or _
    ''                         rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_creusr") = "~*DEL*~") Then
    ''                        rs_CAORDDTL.Tables("RESULT").Rows(index1).Item("cad_creusr") = "~*UPD*~"
    ''                    End If

    ''                    Exit For
    ''                End If
    ''            Next
    ''        End If
    ''    End If

    ''    Recordstatus = True
    ''End Sub

    'Private Sub recal_item_shipment(Optional ByVal sShpNo As String = "", Optional ByVal sShpSeq As String = "")
    '    Dim line1 As Integer
    '    Dim i1 As Integer
    '    Dim seq1 As Integer

    '    seq1 = lblSeq.Text

    '    line1 = 0

    '    If rbViewOn_I.Checked Then
    '        If sHdrClaimAmtPer = "I" Then
    '            For i1 = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
    '                If seq1 = rs_CAORDITM.Tables("RESULT").Rows(i1).Item("cai_caordseq") Then
    '                    line1 = i1
    '                End If
    '            Next i1

    '            txt_Dtl_FinalClaimAmt.Text = Decimal.Round(Convert.ToDecimal(txt_Dtl_FinalClaimAmt.Text), 2)
    '            rs_CAORDITM.Tables("RESULT").Rows(line1).Item("cai_caamt_final") = txt_Dtl_FinalClaimAmt.Text
    '            rs_CAORDITM.Tables("RESULT").Rows(line1).Item("cai_ttlcaamt_final") = rs_CAORDITM.Tables("RESULT").Rows(line1).Item("cai_caqtyamt_final") + rs_CAORDITM.Tables("RESULT").Rows(line1).Item("cai_caamt_final")
    '            txt_Dtl_FinalClaimTtlAmt.Text = Decimal.Round(rs_CAORDITM.Tables("RESULT").Rows(line1).Item("cai_ttlcaamt_final"), 2)

    '            'calculate_HKOAmount(line1)
    '            txt_Dtl_ClaimToHKOAmt.Text = Decimal.Round(rs_CAORDITM.Tables("RESULT").Rows(line1).Item("cai_catohkoamt"), 2)
    '        ElseIf sHdrClaimAmtPer = "S" Then
    '            If rbViewOn_I.Checked Then
    '                For i1 = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
    '                    rs_CAORDDTL.Tables("RESULT").Rows(i1).Item("cad_ttlcaamt_final") = rs_CAORDDTL.Tables("RESULT").Rows(i1).Item("cad_caqtyamt_final") + rs_CAORDDTL.Tables("RESULT").Rows(i1).Item("cad_caamt_final")
    '                    'calculate_HKOAmount(i1)
    '                Next i1
    '            Else
    '                For i1 = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
    '                    If sShpNo = rs_CAORDDTL.Tables("RESULT").Rows(i1).Item("cad_shpno") And _
    '                        sShpSeq = rs_CAORDDTL.Tables("RESULT").Rows(i1).Item("cad_shpseq") Then
    '                        line1 = i1
    '                    End If
    '                Next i1

    '                rs_CAORDDTL.Tables("RESULT").Rows(line1).Item("cad_ttlcaamt_final") = rs_CAORDDTL.Tables("RESULT").Rows(line1).Item("cad_caqtyamt_final") + rs_CAORDDTL.Tables("RESULT").Rows(line1).Item("cad_caamt_final")

    '                'calculate_HKOAmount(line1)
    '            End If
    '        End If
    '    Else
    '        For i1 = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
    '            If seq1 = rs_CAORDDTL.Tables("RESULT").Rows(i1).Item("cad_caordseq") Then
    '                line1 = i1
    '            End If
    '        Next i1

    '        txt_Dtl_FinalClaimAmt.Text = Decimal.Round(Convert.ToDecimal(txt_Dtl_FinalClaimAmt.Text), 2)
    '        rs_CAORDDTL.Tables("RESULT").Rows(line1).Item("cad_caamt_final") = txt_Dtl_FinalClaimAmt.Text
    '        rs_CAORDDTL.Tables("RESULT").Rows(line1).Item("cad_ttlcaamt_final") = rs_CAORDDTL.Tables("RESULT").Rows(line1).Item("cad_caqtyamt_final") + rs_CAORDDTL.Tables("RESULT").Rows(line1).Item("cad_caamt_final")
    '        txt_Dtl_FinalClaimTtlAmt.Text = Decimal.Round(rs_CAORDDTL.Tables("RESULT").Rows(line1).Item("cad_ttlcaamt_final"), 2)

    '        'calculate_HKOAmount(line1)
    '        txt_Dtl_ClaimToHKOAmt.Text = Decimal.Round(rs_CAORDDTL.Tables("RESULT").Rows(line1).Item("cad_catohkoamt"), 2)
    '    End If

    '    If sHdrClaimAmtPer = "I" Then
    '        'cal_ClaimAmt_CAORDHDR()
    '        'cal_ClaimAmt_CAORDDTL()
    '        'format_Approval(seq1)
    '    ElseIf sHdrClaimAmtPer = "S" Then
    '        'cal_ClaimAmt_CAORDITM()
    '        'cal_ClaimAmt_CAORDHDR()
    '        'format_Approval(seq1)
    '    End If

    '    Recordstatus = True

    '    Set_Approval_Right_for_dgSummary(cModeUpd)
    'End Sub

    'Private Sub txt_Dtl_Rmk_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Dtl_Rmk.KeyUp
    '    Dim line As Integer
    '    Dim i As Integer
    '    Dim seq As Integer

    '    seq = lblSeq.Text

    '    line = 0

    '    If rbViewOn_I.Checked Then
    '        For i = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
    '            If seq = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_caordseq") Then
    '                line = i
    '            End If
    '        Next i

    '        rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_rmk") = txt_Dtl_Rmk.Text

    '        If Not (rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*ADD*~" Or _
    '            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*NEW*~" Or _
    '            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~" Or _
    '            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*DEL*~") Then
    '            rs_CAORDITM.Tables("RESULT").Rows(line).Item("cai_creusr") = "~*UPD*~"
    '        End If
    '    Else
    '        For i = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
    '            If seq = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_caordseq") Then
    '                line = i
    '            End If
    '        Next i

    '        '20131111
    '        If rs_CAORDDTL.Tables("RESULT").Rows.Count <= line Then
    '            Exit Sub
    '        End If
    '        rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_rmk") = txt_Dtl_Rmk.Text

    '        If Not (rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*ADD*~" Or _
    '            rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*NEW*~" Or _
    '            rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*UPD*~" Or _
    '            rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*DEL*~") Then
    '            rs_CAORDDTL.Tables("RESULT").Rows(line).Item("cad_creusr") = "~*UPD*~"
    '        End If
    '    End If

    '    Recordstatus = True
    'End Sub

    Private Sub Set_Approval_Right_for_dgSummary(ByVal sStatus As String)
        '''tmp 20131115
        Exit Sub

        Dim final_claim_limit_currency_c As String
        Dim final_claim_amt_currency_c As String
        Dim exrate_c As Decimal

        Dim final_claim_amt_c As Decimal
        Dim remain_claim_amt_c As Decimal

        Dim bNeedCheck As Boolean = True

        Dim final_claim_limit_currency As String
        Dim final_claim_amt_currency As String
        Dim exrate As Decimal

        Dim final_claim_amt As Decimal
        Dim total_claim_limit As Decimal

        If dgSummary.Rows.Count > 0 Then
            If sHdrClaimAmtPer = "C" Then
                For indexA As Integer = 1 To dgSummary.ColumnCount - 1
                    dgSummary.Columns(indexA).ReadOnly = True
                    For indexB As Integer = 0 To dgSummary.RowCount - 1
                        If sHdrClaimAmtPer = "I" Then
                            dgSummary.Rows(indexB).Cells("cai_app1flg").Style.BackColor = Color.White
                            dgSummary.Rows(indexB).Cells("cai_app2flg").Style.BackColor = Color.White
                            dgSummary.Rows(indexB).Cells("cai_caamt_org").Style.BackColor = Color.White
                            dgSummary.Rows(indexB).Cells("cai_caamt_final").Style.BackColor = Color.White
                            dgSummary.Rows(indexB).Cells("cai_catoinsamt").Style.BackColor = Color.White
                            dgSummary.Rows(indexB).Cells("cai_catovnamt").Style.BackColor = Color.White
                        ElseIf sHdrClaimAmtPer = "S" Then
                            dgSummary.Rows(indexB).Cells("cad_caqty").Style.BackColor = Color.White
                            dgSummary.Rows(indexB).Cells("cad_caamt_org").Style.BackColor = Color.White
                            dgSummary.Rows(indexB).Cells("cad_caamt_final").Style.BackColor = Color.White
                            dgSummary.Rows(indexB).Cells("cad_catoinsamt").Style.BackColor = Color.White
                            dgSummary.Rows(indexB).Cells("cad_catovnamt").Style.BackColor = Color.White
                        End If
                    Next
                Next
                'bSetToInit = True
            Else
                'If bSetToInit Then
                '    sStatus = cModeInit
                '    bSetToInit = False
                'End If

                If sHdrClaimAmtPer = "I" Then
                    If rbViewOn_I.Checked Then
                        For index As Integer = 0 To dgSummary.RowCount - 1
                            final_claim_limit_currency = dgSummary.Rows(index).Cells("cai_salcur").EditedFormattedValue
                            final_claim_amt_currency = dgSummary.Rows(index).Cells("cai_cacur").EditedFormattedValue
                            exrate = getExchangeRate(final_claim_amt_currency, final_claim_limit_currency, "BuyRate")

                            If IsNumeric(dgSummary.Rows(index).Cells("cai_ttlcaamt_final").EditedFormattedValue) And _
                                IsNumeric(dgSummary.Rows(index).Cells("cai_caremamt").EditedFormattedValue) Then
                                final_claim_amt = dgSummary.Rows(index).Cells("cai_ttlcaamt_final").EditedFormattedValue
                                total_claim_limit = dgSummary.Rows(index).Cells("cai_caremamt").EditedFormattedValue
                            End If

                            dgSummary.Rows(index).Cells("cai_caamt_org").ReadOnly = True
                            dgSummary.Rows(index).Cells("cai_caamt_org").Style.BackColor = Color.White
                            dgSummary.Rows(index).Cells("cai_caamt_final").ReadOnly = True
                            dgSummary.Rows(index).Cells("cai_caamt_final").Style.BackColor = Color.White
                            dgSummary.Rows(index).Cells("cai_catoinsamt").ReadOnly = True
                            dgSummary.Rows(index).Cells("cai_catoinsamt").Style.BackColor = Color.White
                            dgSummary.Rows(index).Cells("cai_catovnamt").ReadOnly = True
                            dgSummary.Rows(index).Cells("cai_catovnamt").Style.BackColor = Color.White

                            If SuperApprovalRights = True Or total_claim_limit = 0 Or _
                                final_claim_amt * exrate <= total_claim_limit Then
                                If dgSummary.Rows(index).Cells("cai_app1flg").EditedFormattedValue <> "Y" Then
                                    If final_claim_amt <> 0 Then
                                        dgSummary.Rows(index).Cells("cai_app1flg").ReadOnly = False
                                        dgSummary.Rows(index).Cells("cai_app1flg").Style.BackColor = Color.Orange
                                        dgSummary.Rows(index).Cells("cai_app2flg").ReadOnly = True
                                        dgSummary.Rows(index).Cells("cai_app2flg").Style.BackColor = Color.White
                                        dgSummary.Rows(index).Cells("cai_caamt_org").ReadOnly = False
                                        dgSummary.Rows(index).Cells("cai_caamt_org").Style.BackColor = Color.Orange
                                        dgSummary.Rows(index).Cells("cai_caamt_final").ReadOnly = False
                                        dgSummary.Rows(index).Cells("cai_caamt_final").Style.BackColor = Color.Orange
                                        'Else
                                        '    dgSummary.Rows(index).Cells("cai_app1flg").Style.BackColor = Color.White
                                    End If
                                Else
                                    If dgSummary.Rows(index).Cells("cai_creusr").EditedFormattedValue <> "~*ADD*~" _
                                        And dgSummary.Rows(index).Cells("cai_creusr").EditedFormattedValue <> "~*UPD*~" Then
                                        dgSummary.Rows(index).Cells("cai_app1flg").ReadOnly = True
                                        dgSummary.Rows(index).Cells("cai_app1flg").Style.BackColor = Color.White
                                    End If
                                    dgSummary.Rows(index).Cells("cai_caamt_org").ReadOnly = True
                                    dgSummary.Rows(index).Cells("cai_caamt_org").Style.BackColor = Color.White
                                    dgSummary.Rows(index).Cells("cai_caamt_final").ReadOnly = True
                                    dgSummary.Rows(index).Cells("cai_caamt_final").Style.BackColor = Color.White
                                End If

                                If dgSummary.Rows(index).Cells("cai_app1flg").EditedFormattedValue = "Y" _
                                     And dgSummary.Rows(index).Cells("cai_app2flg").EditedFormattedValue <> "Y" Then
                                    If final_claim_amt <> 0 Then
                                        'If dgSummary.Rows(index).Cells("cai_creusr").EditedFormattedValue <> "~*ADD*~" _
                                        '    And dgSummary.Rows(index).Cells("cai_creusr").EditedFormattedValue <> "~*UPD*~" Then
                                        dgSummary.Rows(index).Cells("cai_app2flg").ReadOnly = False
                                        dgSummary.Rows(index).Cells("cai_app2flg").Style.BackColor = Color.Orange
                                        'End If
                                        dgSummary.Rows(index).Cells("cai_catoinsamt").ReadOnly = False
                                        dgSummary.Rows(index).Cells("cai_catoinsamt").Style.BackColor = Color.Orange
                                        dgSummary.Rows(index).Cells("cai_catovnamt").ReadOnly = False
                                        dgSummary.Rows(index).Cells("cai_catovnamt").Style.BackColor = Color.Orange
                                    Else
                                        'If dgSummary.Rows(index).Cells("cai_creusr").EditedFormattedValue <> "~*UPD*~" Then
                                        dgSummary.Rows(index).Cells("cai_app2flg").ReadOnly = True
                                        dgSummary.Rows(index).Cells("cai_app2flg").Style.BackColor = Color.White
                                        'End If
                                        dgSummary.Rows(index).Cells("cai_catoinsamt").ReadOnly = True
                                        dgSummary.Rows(index).Cells("cai_catoinsamt").Style.BackColor = Color.White
                                        dgSummary.Rows(index).Cells("cai_catovnamt").ReadOnly = True
                                        dgSummary.Rows(index).Cells("cai_catovnamt").Style.BackColor = Color.White
                                    End If
                                ElseIf dgSummary.Rows(index).Cells("cai_app1flg").EditedFormattedValue = "Y" _
                                     And dgSummary.Rows(index).Cells("cai_app2flg").EditedFormattedValue = "Y" Then
                                    dgSummary.Rows(index).Cells("cai_catoinsamt").ReadOnly = True
                                    dgSummary.Rows(index).Cells("cai_catoinsamt").Style.BackColor = Color.White
                                    dgSummary.Rows(index).Cells("cai_catovnamt").ReadOnly = True
                                    dgSummary.Rows(index).Cells("cai_catovnamt").Style.BackColor = Color.White
                                Else
                                    If dgSummary.Rows(index).Cells("cai_creusr").EditedFormattedValue <> "~*ADD*~" _
                                        And dgSummary.Rows(index).Cells("cai_creusr").EditedFormattedValue <> "~*UPD*~" Then
                                        dgSummary.Rows(index).Cells("cai_app2flg").ReadOnly = True
                                        dgSummary.Rows(index).Cells("cai_app2flg").Style.BackColor = Color.White
                                    End If
                                End If
                                dgSummary.Rows(index).Cells("EXCE").Style.ForeColor = Color.White
                                dgSummary.Rows(index).Cells("EXCE").Style.SelectionForeColor = SystemColors.Highlight
                            Else
                                dgSummary.Rows(index).Cells("cai_app1flg").ReadOnly = True
                                dgSummary.Rows(index).Cells("cai_app1flg").Style.BackColor = Color.White
                                dgSummary.Rows(index).Cells("cai_app2flg").ReadOnly = True
                                dgSummary.Rows(index).Cells("cai_app2flg").Style.BackColor = Color.White

                                If final_claim_amt <> 0 Then
                                    dgSummary.Rows(index).Cells("EXCE").Style.ForeColor = Color.Black
                                    dgSummary.Rows(index).Cells("EXCE").Style.SelectionForeColor = Color.White
                                Else
                                    dgSummary.Rows(index).Cells("EXCE").Style.ForeColor = Color.White
                                    dgSummary.Rows(index).Cells("EXCE").Style.SelectionForeColor = SystemColors.Highlight
                                End If
                            End If
                        Next

                        final_claim_limit_currency_c = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salcur")
                        final_claim_amt_currency_c = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cacur")
                        exrate_c = getExchangeRate(final_claim_amt_currency_c, final_claim_limit_currency_c, "BuyRate")

                        final_claim_amt_c = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_final")
                        remain_claim_amt_c = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caremamt")

                        If final_claim_amt_c * getExchangeRate(final_claim_limit_currency_c, "USD", "BuyRate") < 2000 Then
                            bNeedCheck = False
                        End If

                        If Not bNeedCheck Then
                            dgSummary.Columns("cai_app1flg").Visible = False
                            dgSummary.Columns("cai_app2flg").Visible = False
                            dgSummary.Columns("EXCE").Visible = False
                        End If
                    End If
                ElseIf sHdrClaimAmtPer = "S" Then
                    If rbViewOn_S.Checked Then
                        For index As Integer = 0 To dgSummary.RowCount - 1
                            final_claim_limit_currency = dgSummary.Rows(index).Cells("cad_salcur").EditedFormattedValue
                            final_claim_amt_currency = dgSummary.Rows(index).Cells("cad_cacur").EditedFormattedValue
                            exrate = getExchangeRate(final_claim_amt_currency, final_claim_limit_currency, "BuyRate")

                            If IsNumeric(dgSummary.Rows(index).Cells("cad_ttlcaamt_final").EditedFormattedValue) And _
                                IsNumeric(dgSummary.Rows(index).Cells("cad_caremamt").EditedFormattedValue) Then
                                final_claim_amt = dgSummary.Rows(index).Cells("cad_ttlcaamt_final").EditedFormattedValue
                                total_claim_limit = dgSummary.Rows(index).Cells("cad_caremamt").EditedFormattedValue
                            End If

                            'If sStatus = cModeInit Then
                            dgSummary.Rows(index).Cells("cad_caqty").ReadOnly = True
                            dgSummary.Rows(index).Cells("cad_caqty").Style.BackColor = Color.White
                            dgSummary.Rows(index).Cells("cad_caamt_org").ReadOnly = True
                            dgSummary.Rows(index).Cells("cad_caamt_org").Style.BackColor = Color.White
                            dgSummary.Rows(index).Cells("cad_caamt_final").ReadOnly = True
                            dgSummary.Rows(index).Cells("cad_caamt_final").Style.BackColor = Color.White
                            dgSummary.Rows(index).Cells("cad_catoinsamt").ReadOnly = True
                            dgSummary.Rows(index).Cells("cad_catoinsamt").Style.BackColor = Color.White
                            dgSummary.Rows(index).Cells("cad_catovnamt").ReadOnly = True
                            dgSummary.Rows(index).Cells("cad_catovnamt").Style.BackColor = Color.White
                            'End If

                            'If SuperApprovalRights = True Or total_claim_limit = 0 Or _
                            '    final_claim_amt * exrate <= total_claim_limit Then
                            '    If dgSummary.Rows(index).Cells("cad_app1flg").EditedFormattedValue <> "Y" Then
                            '        If final_claim_amt <> 0 Then
                            '            dgSummary.Rows(index).Cells("cad_app1flg").Style.BackColor = Color.Orange
                            '            dgSummary.Rows(index).Cells("cad_app2flg").Style.BackColor = Color.White
                            '            dgSummary.Rows(index).Cells("cad_caqty").ReadOnly = False
                            '            dgSummary.Rows(index).Cells("cad_caqty").Style.BackColor = Color.Orange
                            '            dgSummary.Rows(index).Cells("cad_caamt_org").ReadOnly = False
                            '            dgSummary.Rows(index).Cells("cad_caamt_org").Style.BackColor = Color.Orange
                            '            dgSummary.Rows(index).Cells("cad_caamt_final").ReadOnly = False
                            '            dgSummary.Rows(index).Cells("cad_caamt_final").Style.BackColor = Color.Orange
                            '        Else
                            '            dgSummary.Rows(index).Cells("cad_app1flg").Style.BackColor = Color.White
                            '        End If
                            '    Else
                            '        dgSummary.Rows(index).Cells("cad_caqty").ReadOnly = True
                            '        dgSummary.Rows(index).Cells("cad_caqty").Style.BackColor = Color.White
                            '        dgSummary.Rows(index).Cells("cad_caamt_org").ReadOnly = True
                            '        dgSummary.Rows(index).Cells("cad_caamt_org").Style.BackColor = Color.White
                            '        dgSummary.Rows(index).Cells("cad_caamt_final").ReadOnly = True
                            '        dgSummary.Rows(index).Cells("cad_caamt_final").Style.BackColor = Color.White
                            '        If sStatus = cModeInit Then
                            '            dgSummary.Rows(index).Cells("cad_app1flg").ReadOnly = True
                            '            dgSummary.Rows(index).Cells("cad_app1flg").Style.BackColor = Color.White
                            '        End If
                            '    End If

                            '    If dgSummary.Rows(index).Cells("cad_app1flg").EditedFormattedValue = "Y" _
                            '         And dgSummary.Rows(index).Cells("cad_app2flg").EditedFormattedValue <> "Y" Then
                            '        If final_claim_amt <> 0 Then
                            '            If dgSummary.Rows(index).Cells("cad_creusr").EditedFormattedValue <> "~*ADD*~" _
                            '                And dgSummary.Rows(index).Cells("cad_creusr").EditedFormattedValue <> "~*UPD*~" Then
                            '                dgSummary.Rows(index).Cells("cad_app2flg").Style.BackColor = Color.Orange
                            '            End If
                            '            dgSummary.Rows(index).Cells("cad_catoinsamt").ReadOnly = False
                            '            dgSummary.Rows(index).Cells("cad_catoinsamt").Style.BackColor = Color.Orange
                            '            dgSummary.Rows(index).Cells("cad_catovnamt").ReadOnly = False
                            '            dgSummary.Rows(index).Cells("cad_catovnamt").Style.BackColor = Color.Orange
                            '        Else
                            '            If dgSummary.Rows(index).Cells("cad_creusr").EditedFormattedValue <> "~*UPD*~" Then
                            '                dgSummary.Rows(index).Cells("cad_app2flg").Style.BackColor = Color.White
                            '            End If
                            '        End If
                            '    ElseIf dgSummary.Rows(index).Cells("cad_app1flg").EditedFormattedValue = "Y" _
                            '         And dgSummary.Rows(index).Cells("cad_app2flg").EditedFormattedValue = "Y" Then
                            '        dgSummary.Rows(index).Cells("cad_catoinsamt").ReadOnly = True
                            '        dgSummary.Rows(index).Cells("cad_catoinsamt").Style.BackColor = Color.White
                            '        dgSummary.Rows(index).Cells("cad_catovnamt").ReadOnly = True
                            '        dgSummary.Rows(index).Cells("cad_catovnamt").Style.BackColor = Color.White
                            '    Else
                            '        If sStatus = cModeInit Then
                            '            dgSummary.Rows(index).Cells("cad_app2flg").ReadOnly = True
                            '            dgSummary.Rows(index).Cells("cad_app2flg").Style.BackColor = Color.White
                            '        End If
                            '    End If

                            '    dgSummary.Rows(index).Cells("EXCE").Style.ForeColor = Color.White
                            '    dgSummary.Rows(index).Cells("EXCE").Style.SelectionForeColor = SystemColors.Highlight
                            'Else
                            '    dgSummary.Rows(index).Cells("cad_app1flg").ReadOnly = True
                            '    dgSummary.Rows(index).Cells("cad_app1flg").Style.BackColor = Color.White
                            '    dgSummary.Rows(index).Cells("cad_app2flg").ReadOnly = True
                            '    dgSummary.Rows(index).Cells("cad_app2flg").Style.BackColor = Color.White

                            '    If final_claim_amt <> 0 Then
                            '        dgSummary.Rows(index).Cells("EXCE").Style.ForeColor = Color.Black
                            '        dgSummary.Rows(index).Cells("EXCE").Style.SelectionForeColor = Color.White
                            '    Else
                            '        dgSummary.Rows(index).Cells("EXCE").Style.ForeColor = Color.White
                            '        dgSummary.Rows(index).Cells("EXCE").Style.SelectionForeColor = SystemColors.Highlight
                            '    End If
                            'End If
                        Next
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgSummary_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgSummary.EditingControlShowing
        Dim txtbox_dgSummary As TextBox = CType(e.Control, TextBox)

        If Not (txtbox_dgSummary Is Nothing) Then
            AddHandler txtbox_dgSummary.KeyPress, AddressOf txtBox_dgSummary_KeyPress
            AddHandler txtbox_dgSummary.TextChanged, AddressOf txt_dgSummary_TextChanged

            'AddHandler txtbox_dgSummary.KeyUp, AddressOf txtbox_dgSummary_KeyUp
        End If
    End Sub

    Private Sub txtBox_dgSummary_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim checktype As String
        Dim allowedChars As String

        If rbViewOn_I.Checked Then
            Select Case dgSummary.CurrentCell.ColumnIndex
                Case 18, 19, 26, 28
                    checktype = "DECIMAL"
                Case Else
                    checktype = "STRING"
            End Select

            Select Case checktype
                Case "DECIMAL"
                    allowedChars = "0123456789."

                    If allowedChars.IndexOf(e.KeyChar) = -1 Then
                        ' Invalid Character
                        e.KeyChar = ""
                        Exit Sub
                    End If

                    Dim currenttext As String

                    If dgSummary.Item(dgSummary.CurrentCell.ColumnIndex, dgSummary.CurrentCell.RowIndex).EditedFormattedValue = "0.00" Then
                        currenttext = e.KeyChar
                    Else
                        currenttext = dgSummary.Item(dgSummary.CurrentCell.ColumnIndex, dgSummary.CurrentCell.RowIndex).EditedFormattedValue & e.KeyChar
                    End If

                    'check for only 1.
                    If e.KeyChar = "." Then
                        If Mid(currenttext, 1, Len(currenttext) - 1).IndexOf(".") <> -1 Then
                            e.KeyChar = ""
                            Exit Sub
                        End If
                    End If
                Case Else
            End Select

            If Not (dgSummary.Item("cai_creusr", dgSummary.CurrentCell.RowIndex).Value = "~*ADD*~" Or _
                dgSummary.Item("cai_creusr", dgSummary.CurrentCell.RowIndex).Value = "~*NEW*~" Or _
                dgSummary.Item("cai_creusr", dgSummary.CurrentCell.RowIndex).Value = "~*UPD*~" Or _
                dgSummary.Item("cai_creusr", dgSummary.CurrentCell.RowIndex).Value = "~*DEL*~") Then
                dgSummary.Item("cai_creusr", dgSummary.CurrentCell.RowIndex).Value = "~*UPD*~"
            End If
        Else
            Select Case dgSummary.CurrentCell.ColumnIndex
                Case 6 'cad_scordno, cad_scordseq, cad_scordseq
                    checktype = "NONE"
                Case 33 'cad_caqty
                    checktype = "INTEGER"
                Case 44, 45, 47, 49
                    checktype = "DECIMAL"
                Case Else
                    checktype = "STRING"
            End Select

            Select Case checktype
                Case "NONE"
                    allowedChars = ""

                    If allowedChars.IndexOf(e.KeyChar) = -1 Then
                        ' Invalid Character
                        e.KeyChar = ""
                        Exit Sub
                    End If
                Case "INTEGER"
                    allowedChars = "0123456789"

                    If allowedChars.IndexOf(e.KeyChar) = -1 Then
                        ' Invalid Character
                        e.KeyChar = ""
                        Exit Sub
                    End If
                Case "DECIMAL"
                    allowedChars = "0123456789."

                    If allowedChars.IndexOf(e.KeyChar) = -1 Then
                        ' Invalid Character
                        e.KeyChar = ""
                        Exit Sub
                    End If

                    Dim currenttext As String

                    If dgSummary.Item(dgSummary.CurrentCell.ColumnIndex, dgSummary.CurrentCell.RowIndex).EditedFormattedValue = "0.00" Then
                        currenttext = e.KeyChar
                    Else
                        currenttext = dgSummary.Item(dgSummary.CurrentCell.ColumnIndex, dgSummary.CurrentCell.RowIndex).EditedFormattedValue & e.KeyChar
                    End If

                    'check for only 1.
                    If e.KeyChar = "." Then
                        If Mid(currenttext, 1, Len(currenttext) - 1).IndexOf(".") <> -1 Then
                            e.KeyChar = ""
                            Exit Sub
                        End If
                    End If
                Case Else
            End Select

            If Not (dgSummary.Item("cad_creusr", dgSummary.CurrentCell.RowIndex).Value = "~*ADD*~" Or _
                dgSummary.Item("cad_creusr", dgSummary.CurrentCell.RowIndex).Value = "~*NEW*~" Or _
                dgSummary.Item("cad_creusr", dgSummary.CurrentCell.RowIndex).Value = "~*UPD*~" Or _
                dgSummary.Item("cad_creusr", dgSummary.CurrentCell.RowIndex).Value = "~*DEL*~") Then
                dgSummary.Item("cad_creusr", dgSummary.CurrentCell.RowIndex).Value = "~*UPD*~"
            End If
        End If
    End Sub

    'Private Sub txtbox_dgSummary_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    Dim current_col As Integer
    '    Dim current_row As Integer

    '    current_col = dgSummary.CurrentCell.ColumnIndex
    '    current_row = dgSummary.CurrentCell.RowIndex

    '    Dim ftycur As String
    '    Dim cacur As String
    '    Dim gpcur As String
    '    Dim exrate As Decimal
    '    'Dim caamt_final As Decimal

    '    Dim cad_ttlcaamt_final As Decimal
    '    Dim catoinscur As String
    '    Dim catoinsamt As Decimal
    '    Dim catovncur As String
    '    Dim catovnamt As Decimal
    '    Dim catohkocur As String
    '    Dim exrate_ins As Decimal
    '    Dim exrate_ivn As Decimal
    '    Dim exrate_hko As Decimal
    '    Dim hkoamt As Decimal

    '    Select Case current_col
    '        Case 29 'cad_caqty
    '            ftycur = dgSummary.Item("cad_scfcurcde", current_row).Value
    '            cacur = dgSummary.Item("cad_cacur", current_row).Value
    '            exrate = 0.0
    '            exrate = getExchangeRate(ftycur, cacur, "BuyRate")

    '            If IsNumeric(dgSummary.Item("cad_caqty", current_row).EditedFormattedValue) Then
    '                If Mid(dgSummary.Item("cad_caqty", current_row).EditedFormattedValue, _
    '                       Len(dgSummary.Item("cad_caqty", current_row).EditedFormattedValue), 1) <> "." Then
    '                    dgSummary.Item("cad_caqty", current_row).Value = dgSummary.Item("cad_caqty", current_row).EditedFormattedValue
    '                End If
    '            End If

    '            If IsNumeric(dgSummary.Item("cad_scftyprc", current_row).Value) And IsNumeric(dgSummary.Item("cad_caqty", current_row).EditedFormattedValue) Then
    '                dgSummary.Item("cad_caqtyamt_org", current_row).Value = _
    '                Decimal.Round(dgSummary.Item("cad_caqty", current_row).EditedFormattedValue * dgSummary.Item("cad_scftyprc", current_row).Value * exrate, 2)
    '            End If

    '            dgSummary.Item("cad_ttlcaamt_org", current_row).Value = _
    '            dgSummary.Item("cad_caqtyamt_org", current_row).Value + _
    '            dgSummary.Item("cad_caamt_org", current_row).Value

    '            If Not (dgSummary.Item("cad_creusr", current_row).Value = "~*ADD*~" Or _
    '                dgSummary.Item("cad_creusr", current_row).Value = "~*NEW*~" Or _
    '                dgSummary.Item("cad_creusr", current_row).Value = "~*UPD*~" Or _
    '                dgSummary.Item("cad_creusr", current_row).Value = "~*DEL*~") Then
    '                dgSummary.Item("cad_creusr", current_row).Value = "~*UPD*~"
    '            End If

    '            Recordstatus = True
    '            Set_Approval_Right_for_dgSummary(cModeUpd)
    '        Case 40 'cad_caamt_org
    '            If Not IsNumeric(dgSummary.Item("cad_caamt_org", current_row).EditedFormattedValue) Then
    '                dgSummary.Item("cad_caamt_org", current_row).Value = "0.00"
    '            Else
    '                'dgSummary.Item("cad_caamt_org", current_row).Value = dgSummary.Item("cad_caamt_org", current_row).EditedFormattedValue
    '                dgSummary.Item("cad_ttlcaamt_org", current_row).Value = _
    '                dgSummary.Item("cad_caqtyamt_org", current_row).Value + _
    '                dgSummary.Item("cad_caamt_org", current_row).EditedFormattedValue
    '            End If

    '            If Not (dgSummary.Item("cad_creusr", current_row).Value = "~*ADD*~" Or _
    '                dgSummary.Item("cad_creusr", current_row).Value = "~*NEW*~" Or _
    '                dgSummary.Item("cad_creusr", current_row).Value = "~*UPD*~" Or _
    '                dgSummary.Item("cad_creusr", current_row).Value = "~*DEL*~") Then
    '                dgSummary.Item("cad_creusr", current_row).Value = "~*UPD*~"
    '            End If

    '            Recordstatus = True
    '            Set_Approval_Right_for_dgSummary(cModeUpd)
    '        Case 41 'cad_caamt_final
    '            If Not IsNumeric(dgSummary.Item("cad_caamt_final", current_row).EditedFormattedValue) Then
    '                dgSummary.Item("cad_caamt_final", current_row).Value = "0.00"
    '            Else
    '                dgSummary.Item("cad_ttlcaamt_final", current_row).Value = _
    '                dgSummary.Item("cad_caqtyamt_final", current_row).Value + _
    '                dgSummary.Item("cad_caamt_final", current_row).EditedFormattedValue
    '                'dgSummary.Item("cad_caamt_final", current_row).Value = dgSummary.Item("cad_caamt_final", current_row).EditedFormattedValue
    '            End If

    '            cacur = dgSummary.Item("cad_cacur", current_row).Value
    '            gpcur = dgSummary.Item("cad_salcur", current_row).Value
    '            exrate = 0.0
    '            exrate = getExchangeRate(cacur, gpcur, "BuyRate")

    '            If Not IsNumeric(dgSummary.Item("cad_grspftamt", current_row).Value) Then
    '                Exit Sub
    '            End If

    '            If dgSummary.Item("cad_grspftamt", current_row).Value = 0 Then
    '                Exit Sub
    '            End If

    '            'dgSummary.Item("cad_cavsgrspft", current_row).Value = _
    '            '((dgSummary.Item("cad_ttlcaamt_final", current_row).Value * exrate) / _
    '            'dgSummary.Item("cad_grspftamt", current_row).Value) * 100
    '            'txt_Dtl_ClaimVSGPPer.Text = Decimal.Round(dgSummary.Item("cad_cavsgrspft", current_row).Value, 2)

    '            If Not (dgSummary.Item("cad_creusr", current_row).Value = "~*ADD*~" Or _
    '                dgSummary.Item("cad_creusr", current_row).Value = "~*NEW*~" Or _
    '                dgSummary.Item("cad_creusr", current_row).Value = "~*UPD*~" Or _
    '                dgSummary.Item("cad_creusr", current_row).Value = "~*DEL*~") Then
    '                dgSummary.Item("cad_creusr", current_row).Value = "~*UPD*~"
    '            End If

    '            ''calculate_HKOAmount("Detail", current_row, False)
    '            'calculate_HKOAmount(current_row)
    '            dgSummary.Item("cad_catohkoamt", current_row).Value = Decimal.Round(dgSummary.Item("cad_catohkoamt", current_row).Value, 2)

    '            Recordstatus = True
    '            Set_Approval_Right_for_dgSummary(cModeUpd)
    '        Case 49, 51 'cad_catoinsamt, cad_catovnamt
    '            cacur = dgSummary.Item("cad_cacur", current_row).Value
    '            If Not IsNumeric(dgSummary.Item("cad_ttlcaamt_final", current_row).EditedFormattedValue) Then
    '                cad_ttlcaamt_final = "0.00"
    '            Else
    '                cad_ttlcaamt_final = dgSummary.Item("cad_ttlcaamt_final", current_row).EditedFormattedValue
    '            End If
    '            catoinscur = dgSummary.Item("cad_catoinscur", current_row).Value
    '            If Not IsNumeric(dgSummary.Item("cad_catoinsamt", current_row).EditedFormattedValue) Then
    '                catoinsamt = "0.00"
    '            Else
    '                catoinsamt = dgSummary.Item("cad_catoinsamt", current_row).EditedFormattedValue
    '            End If
    '            catovncur = dgSummary.Item("cad_catovncur", current_row).Value
    '            If Not IsNumeric(dgSummary.Item("cad_catovnamt", current_row).EditedFormattedValue) Then
    '                catovnamt = "0.00"
    '            Else
    '                catovnamt = dgSummary.Item("cad_catovnamt", current_row).EditedFormattedValue
    '            End If
    '            catohkocur = dgSummary.Item("cad_catohkocur", current_row).Value

    '            exrate_ins = getExchangeRate(catoinscur, cacur, "BuyRate")
    '            exrate_ivn = getExchangeRate(catovncur, cacur, "BuyRate")
    '            exrate_hko = getExchangeRate(catohkocur, cacur, "BuyRate")

    '            If exrate_ins = 0 Or exrate_ivn = 0 Or exrate_hko = 0 Then
    '                Exit Sub
    '            End If

    '            hkoamt = cad_ttlcaamt_final - (exrate_ins * catoinsamt) - (exrate_ivn * catovnamt)

    '            dgSummary.Item("cad_catohkoamt", current_row).Value = Decimal.Round(hkoamt / exrate_hko, 2)
    '    End Select
    'End Sub

    Private Sub dgSummary_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSummary.CellClick
        '''20140218
        ''' 
        Dim cell As DataGridViewCell = dgSummary.CurrentCell




        If rbViewOn_I.Checked Then

            Dim tmp_seq_itm
            tmp_seq_itm = dgSummary.Item("CAI_CAORDSEQ", cell.RowIndex).Value
            For i As Integer = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
                ''bug
                If Not IsDBNull(rs_CAORDITM.Tables("RESULT").Rows(i).Item("CAI_CAORDSEQ")) Then

                    If tmp_seq_itm = rs_CAORDITM.Tables("RESULT").Rows(i).Item("CAI_CAORDSEQ") Then
                        sReadingIndexQ_Item = i
                    End If
                End If

            Next i
            '''20140217

            Call display_CAORDITM(tmp_seq_itm)


            For i As Integer = 0 To dgSummary.Columns.Count - 1
                dgSummary.Columns(i).ReadOnly = True
            Next
            If dgSummary.Columns.Count > 0 Then
                '''140515
                If Microsoft.VisualBasic.Left(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts"), 3) = "APV" Then
                    dgSummary.Columns(0).ReadOnly = True
                    'ElseIf rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "APV1b" Then
                    '    dgSummary.Columns(0).ReadOnly = True
                    'Else
                    dgSummary.Columns(0).ReadOnly = False
                End If
            End If
            'rmk
            dgSummary.Columns(dgSummary.Item("CAI_RMK", cell.RowIndex).ColumnIndex).ReadOnly = False

            'dgSummary.Columns(0).ReadOnly = False

            If e.RowIndex >= 0 And e.ColumnIndex = 0 Then
                If dgSummary.Columns(e.ColumnIndex).ReadOnly = False Then
                    If rs_CAORDITM.Tables("RESULT").DefaultView(e.RowIndex)("cai_Del").ToString = "Y" Then
                        rs_CAORDITM.Tables("RESULT").DefaultView(e.RowIndex)("cai_Del") = "N"
                        Call UNDelete_dtl_from_itm(e.RowIndex)

                        If rs_CAORDITM.Tables("RESULT").Rows(e.RowIndex).Item("cai_creusr") <> "~*ADD*~" And rs_CAORDITM.Tables("RESULT").Rows(e.RowIndex).Item("cai_creusr") <> "~*NEW*~" Then
                            rs_CAORDITM.Tables("RESULT").Rows(e.RowIndex).Item("cai_creusr") = "~*UPD*~"
                        End If

                        chkDelete.Checked = False
                    Else
                        rs_CAORDITM.Tables("RESULT").DefaultView(e.RowIndex)("cai_Del") = "Y"
                        Call Delete_dtl_from_itm(e.RowIndex)

                        rs_CAORDITM.Tables("RESULT").DefaultView(e.RowIndex)("cai_creusr") = "~*DEL*~"

                        chkDelete.Checked = True
                    End If
                    rs_CAORDITM.Tables("RESULT").AcceptChanges()
                End If
            End If


        Else

            Dim tmp_seq_dtl
            tmp_seq_dtl = dgSummary.Item("CAD_CAORDSEQ", cell.RowIndex).Value

            For i As Integer = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
                ''bug
                If Not IsDBNull(rs_CAORDDTL.Tables("RESULT").Rows(i).Item("CAD_CAORDSEQ")) Then

                    If tmp_seq_dtl = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("CAD_CAORDSEQ") Then
                        sReadingIndexQ_ship = i
                    End If
                End If

            Next i

            Call display_CAORDDTL(tmp_seq_dtl)


            '''20140217
            For i As Integer = 0 To dgSummary.Columns.Count - 1
                dgSummary.Columns(i).ReadOnly = True
            Next
            If dgSummary.Columns.Count > 0 Then
                If Microsoft.VisualBasic.Left(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts"), 3) = "APV" Then
                    dgSummary.Columns(0).ReadOnly = True
                    'ElseIf rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "APV1b" Then
                    '    dgSummary.Columns(0).ReadOnly = True
                Else
                    dgSummary.Columns(0).ReadOnly = False
                End If
            End If
            'rmk
            dgSummary.Columns(dgSummary.Item("CAD_RMK", cell.RowIndex).ColumnIndex).ReadOnly = False

            'dgSummary.Columns(0).ReadOnly = False

            If e.RowIndex >= 0 And e.ColumnIndex = 0 Then
                If dgSummary.Columns(e.ColumnIndex).ReadOnly = False Then
                    If rs_CAORDDTL.Tables("RESULT").DefaultView(e.RowIndex)("cad_Del").ToString = "Y" Then
                        rs_CAORDDTL.Tables("RESULT").DefaultView(e.RowIndex)("cad_Del") = "N"
                        Call UNDelete_itm_from_dtl(e.RowIndex)

                        If rs_CAORDDTL.Tables("RESULT").Rows(e.RowIndex).Item("cad_creusr") <> "~*ADD*~" And rs_CAORDDTL.Tables("RESULT").Rows(e.RowIndex).Item("cad_creusr") <> "~*NEW*~" Then
                            rs_CAORDDTL.Tables("RESULT").Rows(e.RowIndex).Item("cad_creusr") = "~*UPD*~"
                        End If

                        chkDelete.Checked = False
                    Else
                        rs_CAORDDTL.Tables("RESULT").DefaultView(e.RowIndex)("cad_Del") = "Y"
                        Call Delete_itm_from_dtl(e.RowIndex)

                        rs_CAORDDTL.Tables("RESULT").DefaultView(e.RowIndex)("cad_creusr") = "~*DEL*~"

                        chkDelete.Checked = True
                    End If
                    rs_CAORDDTL.Tables("RESULT").AcceptChanges()
                End If
            End If



        End If



        'Dim cell As DataGridViewCell = dgSummary.CurrentCell

        'If rbViewOn_I.Checked Then
        '    If Not (e.ColumnIndex = -1 Or e.RowIndex = -1) Then
        '        If cell.ColumnIndex = 0 Then
        '            If mode = cModeAdd Or mode = cModeUpd Then
        '                'If mode = cModeAdd Or mode = cModeUpd Then
        '                If dgSummary.Item("cai_app1flg", cell.RowIndex).Value <> "Y" Then
        '                    If dgSummary.Item(cell.ColumnIndex, cell.RowIndex).Value = "Y" Then
        '                        dgSummary.Item(cell.ColumnIndex, cell.RowIndex).Value = ""
        '                    Else
        '                        dgSummary.Item(cell.ColumnIndex, cell.RowIndex).Value = "Y"
        '                    End If
        '                End If
        '            End If
        '        End If

        '        If cell.ColumnIndex = 22 Or cell.ColumnIndex = 31 Then
        '            If cell.Style.BackColor = Color.Orange Then
        '                If cell.ColumnIndex = 22 Then 'cad_app1flg
        '                    cell.ReadOnly = False
        '                    If cell.Value <> "Y" Then
        '                        cell.Value = "Y"
        '                        dgSummary.Item("cai_app1flg", cell.RowIndex).Value = "Y"
        '                        dgSummary.Item("cai_app1flgby", cell.RowIndex).Value = gsUsrID
        '                        dgSummary.Item("cai_app1flgdat", cell.RowIndex).Value = Format(Date.Today, "MM/dd/yyyy")
        '                    Else
        '                        cell.Value = ""
        '                        dgSummary.Item("cai_app1flg", cell.RowIndex).Value = ""
        '                        dgSummary.Item("cai_app1flgby", cell.RowIndex).Value = ""
        '                        dgSummary.Item("cai_app1flgdat", cell.RowIndex).Value = "01/01/1900"
        '                        If dgSummary.Item("cai_app2flg", cell.RowIndex).Value = "Y" Then
        '                            dgSummary.Item("cai_app2flg", cell.RowIndex).Value = ""
        '                        End If
        '                    End If
        '                    cell.ReadOnly = True
        '                Else 'cad_app2flg
        '                    cell.ReadOnly = False
        '                    If cell.Value = "Y" Then
        '                        cell.Value = ""
        '                        dgSummary.Item("cai_app2flg", cell.RowIndex).Value = ""
        '                        dgSummary.Item("cai_app2flgby", cell.RowIndex).Value = ""
        '                        dgSummary.Item("cai_app2flgdat", cell.RowIndex).Value = "01/01/1900"
        '                    Else
        '                        cell.Value = "Y"
        '                        dgSummary.Item("cai_app2flg", cell.RowIndex).Value = "Y"
        '                        dgSummary.Item("cai_app2flgby", cell.RowIndex).Value = gsUsrID
        '                        dgSummary.Item("cai_app2flgdat", cell.RowIndex).Value = Format(Date.Today, "MM/dd/yyyy")
        '                        If dgSummary.Item("cai_app1flg", cell.RowIndex).Value = "" Then
        '                            dgSummary.Item("cai_app1flg", cell.RowIndex).Value = "Y"
        '                        End If
        '                    End If
        '                    cell.ReadOnly = True
        '                End If
        '                If Not (rs_CAORDITM.Tables("RESULT").Rows(cell.RowIndex).Item("cai_creusr") = "~*ADD*~" Or _
        '                    rs_CAORDITM.Tables("RESULT").Rows(cell.RowIndex).Item("cai_creusr") = "~*NEW*~" Or _
        '                    rs_CAORDITM.Tables("RESULT").Rows(cell.RowIndex).Item("cai_creusr") = "~*UPD*~" Or _
        '                    rs_CAORDITM.Tables("RESULT").Rows(cell.RowIndex).Item("cai_creusr") = "~*DEL*~") Then
        '                    rs_CAORDITM.Tables("RESULT").Rows(cell.RowIndex).Item("cai_creusr") = "~*UPD*~"
        '                End If
        '            Else
        '                cell.ReadOnly = True
        '            End If
        '            Set_Approval_Right_for_dgSummary(cModeUpd)
        '        End If
        '    End If
        'Else
        '    '''ship
        '    If cell.ColumnIndex = 0 Then
        '        If mode = cModeAdd Or mode = cModeUpd Then
        '            'If mode = cModeAdd Or mode = cModeUpd Then
        '            If dgSummary.Item(cell.ColumnIndex, cell.RowIndex).Value = "Y" Then
        '                dgSummary.Item(cell.ColumnIndex, cell.RowIndex).Value = ""
        '            Else
        '                dgSummary.Item(cell.ColumnIndex, cell.RowIndex).Value = "Y"
        '            End If

        '        End If
        'End If

        'End If

        'dgSummary.Columns(1).CellTemplate.Style.BackColor = Color.LightBlue

        'dgSummary.Columns(8).CellTemplate.Style.BackColor = Color.LightBlue
        'dgSummary.Columns(31).CellTemplate.Style.BackColor = Color.LightBlue


    End Sub

    Private Sub dgSummary_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSummary.Sorted
        Set_Approval_Right_for_dgSummary(cModeUpd)
    End Sub

    Private Sub dgSummary_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgSummary.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If (dgSummary.SelectedCells.Count <> 1) Then
                dgSummary.ContextMenuStrip = Nothing
                MessageBox.Show("Please select 1 cell only.", "Please try again.", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Else
                dgSummary.ContextMenuStrip = cms_CopyNPaste
            End If
        End If
    End Sub

    Private Sub smi_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smi_Copy.Click
        Try
            Dim doDataObject As New DataObject
            doDataObject = dgSummary.GetClipboardContent()

            If Not doDataObject Is Nothing Then
                Clipboard.SetDataObject(doDataObject)
            Else
                MessageBox.Show("Please select a cell that you want to copy.", "Please try again.", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As System.Runtime.InteropServices.ExternalException
            Throw New Exception(ex.Message, ex.InnerException)
            MessageBox.Show("The Clipboard could not be accessed.", "Please try again.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub smi_Paste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smi_Paste.Click
        If (dgSummary.SelectedCells.Count <> 1) Then
            MessageBox.Show("Please select a cell that you want to paste.", "Please try again.", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            Dim sClipboardText As String
            sClipboardText = Clipboard.GetText

            If Not sClipboardText = "" Then
                If dgSummary.SelectedCells(0).ReadOnly = False Then
                    If dgSummary.SelectedCells(0).ValueType.Name = "String" Then
                        dgSummary.SelectedCells(0).Value = sClipboardText
                    ElseIf dgSummary.SelectedCells(0).ValueType.Name = "Int32" Then
                        If IsNumeric(sClipboardText) And sClipboardText.Contains(".") = 0 Then
                            dgSummary.SelectedCells(0).Value = sClipboardText
                        Else
                            MessageBox.Show("Copied data is not in same format.", "Please try again.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    Else
                        If IsNumeric(sClipboardText) Then
                            dgSummary.SelectedCells(0).Value = sClipboardText
                        Else
                            MessageBox.Show("Copied data is not in same format.", "Please try again.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    End If
                Else
                    MessageBox.Show("Cannot paste data into a readonly cell.", "Please try again.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If
        End If
    End Sub


    Private Sub fillParameter()
        '' Cursor = Cursors.WaitCursor

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_CUBASINF_PC '" & cboCoCde.Text & "','" & gsUsrID & "','" & sMODULE & "','Primary'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        gspStr = ""

        '''''' Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading fillParameter sp_select_CUBASINF_PC :" & rtnStr)
            Exit Sub
        End If

        If rs_CUBASINF_P.Tables("RESULT").Rows.Count > 0 Then
            cboPriCust.Items.Clear()
            cboPriCust.Text = ""

            dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno >= '50000'")


            If Not dr Is Nothing Then
                If dr.Length > 0 Then
                    For index As Integer = 0 To dr.Length - 1
                        cboPriCust.Items.Add(dr(index)("cbi_cusno") + " - " + dr(index)("cbi_cussna"))
                    Next index
                End If
            End If
        Else
            ''MsgBox("There is no function, please contact EDP or System Administrator.")
            Exit Sub
        End If

        '*** Customer Group
        '''''' Cursor = Cursors.WaitCursor


        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_list_VNBASINF ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtItmNoVen_KeyPress sp_list_VNBASINF :" & rtnStr)
            Exit Sub
        End If

        Dim tmpstr As String
        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
            cboVendor.Items.Add("")

            For index As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                tmpstr = rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna")
                cboVendor.Items.Add(tmpstr)
                If rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_ventyp") = "E" Then
                    cboVendor.Items.Add(tmpstr)
                End If
            Next
        End If


    End Sub


    Private Sub cboPriCust_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPriCust.SelectedIndexChanged
        Call cboPriCustClick()
        If checkValidCombo(cboPriCust, cboPriCust.Text) Then
            Call format_cboSecCust(Split(cboPriCust.Text, " - ")(0).ToString)
        End If
        Recordstatus = True
    End Sub


    Private Sub cboPriCustClick()

        If cboPriCust.Text <> "" Then
            cboSecCust.Items.Clear()
            cboSecCust.Text = ""

            If InStr(cboPriCust.Text, " - ") - 1 >= 0 Then
                dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno = " & "'" & Microsoft.VisualBasic.Left(cboPriCust.Text, InStr(cboPriCust.Text, " - ") - 1) & "'")
            End If

            Dim srname As String
            '            srname = dr(0).Item("cbi_srname")


            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_CUBASINF_Q '" & cboCoCde.Text & "','" & Microsoft.VisualBasic.Left(cboPriCust.Text, InStr(cboPriCust.Text, " - ") - 1) & "','Secondary'"
            rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_S, rtnStr)
            gspStr = ""

            '' Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cboPriCustClick sp_select_CUBASINF_Q 2 :" & rtnStr)
                '' Cursor = Cursors.Default
                Exit Sub
            End If

            If rs_CUBASINF_S.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
                cboSecCust.Enabled = False
            Else
                cboSecCust.Enabled = True
                cboSecCust.Items.Clear()
                cboSecCust.Text = ""

                dr = rs_CUBASINF_S.Tables("RESULT").Select("csc_seccus >= 60000")

                If Not dr Is Nothing Then
                    'possible bug ?
                    'If dr.Length > 1 Then
                    If dr.Length > 0 Then
                        For index As Integer = 0 To dr.Length - 1
                            cboSecCust.Items.Add(dr(index)("csc_seccus").ToString + " - " + dr(index)("cbi_cussna").ToString)
                        Next
                    End If
                End If
            End If

            '*** Agent for Primary Customer
            '' Cursor = Cursors.WaitCursor

            '            dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno = " & "'" & Microsoft.VisualBasic.Left(cboPriCust.Text, InStr(cboPriCust.Text, " - ") - 1) & "'")

        End If

    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        gspStr = "sp_select_CUBASINF_P '" & cboCoCde.Text & "','Primary'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        gspStr = ""
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading QUM00001  sp_select_CUBASINF_P : " & rtnStr)
            Exit Sub
        End If


        Call fillcboPriCust()

        Me.cboPriCust.Enabled = True
        Me.cboPriCust.Focus()


    End Sub


    Private Sub fillcboPriCust()

        Dim dr() As DataRow
        '        If addFlag = True Then


        gspStr = "sp_select_CUBASINF_CA '','" & gsUsrID & "','QU','Primary'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If

        dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno >= '50000'")
        'Else
        'dr = rs_CUBASINF_P.Tables("RESULT").Select("")
        'End If

        If dr.Length > 0 Then
            cboPriCust.Items.Clear()

            For i As Integer = 0 To dr.Length - 1
                cboPriCust.Items.Add(dr(i).Item("cbi_cusno") & " - " & dr(i).Item("cbi_cussna"))
            Next
        End If

    End Sub


    Private Sub fillclaimscategory()
        cboClaimType.Items.Clear()
        cboClaimType.Items.Add("01 - Markdown Support")
        cboClaimType.Items.Add("02 - Return of funds withheld")
        cboClaimType.Items.Add("03 - Quality & Defective issue")
        cboClaimType.Items.Add("04 - Product damage in transit")
        cboClaimType.Items.Add("05 - Short shipment")
        cboClaimType.Items.Add("06 - Late shipment")
        cboClaimType.Items.Add("07 - Wrong shipment")
        cboClaimType.Items.Add("08 - Container Underload / Carton volume variance")
        cboClaimType.Items.Add("09 - Labeling claim")
        cboClaimType.Items.Add("10 - Packaging damage")
        cboClaimType.Items.Add("11 - Product Liability (Insurance)")
        cboClaimType.Items.Add("98 - Others from Customer")

        cboClaimType.Items.Add("21 - Quantity change / order cancellation")
        cboClaimType.Items.Add("99 - Others from Vendor")
    End Sub

    Private Sub fillclaimSts()
        cboClaimSts.Items.Clear()
        cboClaimSts.Items.Add("OPEN - Open/Active")
        cboClaimSts.Items.Add("WAIT - Waiting For Approval")
        cboClaimSts.Items.Add("APRV - Claim Amt confirmed")
        cboClaimSts.Items.Add("RELS - Released")
        cboClaimSts.Items.Add("CANL - Cancel")
        cboClaimSts.Items.Add("CLOS - Close")
    End Sub


    Public Sub fill_combo_cur(ByVal combo As ComboBox)

        combo.Items.Clear()
        combo.Items.Add("RMB")
        combo.Items.Add("HKD")
        combo.Items.Add("USD")
        combo.Text = "USD"

    End Sub

    Private Sub cboClaimSts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClaimSts.SelectedIndexChanged

    End Sub


    Private Function insert_CAORDDTL(ByVal addnew As Boolean) As Integer
        Dim qutseq As Integer
        Dim loc As Integer

        qutseq = 0

        If addnew = True Then
            Dim i As Integer

            For i = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
                If rs_CAORDDTL.Tables("RESULT").Rows(i).Item("CAD_qutseq") > qutseq Then
                    qutseq = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("CAD_qutseq")
                End If
            Next i

            qutseq = qutseq + 1

            insert_CAORDDTL = qutseq

            rs_CAORDDTL.Tables("RESULT").Rows.Add()

            loc = rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
        Else
            ''should be the cur one, instead of last item
            qutseq = rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_caordseq")
            loc = sReadingIndexQ_ship
            ''qutseq = rs_CAORDDTL.Tables("RESULT").Rows(rs_CAORDDTL.Tables("RESULT").Rows.Count - 1).Item("CAD_qutseq")
        End If


        ''loc = sReadingIndexQ_ship
        ''loc = rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_cocde") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_caordno") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_caordseq") = qutseq
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_clatyp") = "00"
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_txcocde") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_scordno") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_scordseq") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_popurord") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_popurseq") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_pojobord") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_shinvno") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_sccuspono") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_shissdat") = "01/01/1900"
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_shetddat") = "01/01/1900"
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_shetadat") = "01/01/1900"
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_itmno") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("CAD_itmnoven") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_cusitm") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_cusstyno") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_venitm") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_itmdsc") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_prdven") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_ventyp") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_sccurcde") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_scnetuntprc") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("CAD_alscolcde") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_scfcurcde") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_scftyprc") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_scpckunt") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("CAD_untcde") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_scordqty") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_scshpqty") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_caqty") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_caqty_final") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_rmk") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_salcur") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_salamt") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_grspftamt") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_calmtamt") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_calmtper") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_cacur") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_caqtyamt_org") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_caqtyamt_final") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_caamt_org") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_caamt_final") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_ttlcaamt_org") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_ttlcaamt_final") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_cavsgrspft") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_app1flg") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_app1flgby") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_app1flgdat") = "01/01/1900"
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_catoinscur") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_catoinsamt") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_catovncur") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_catovnamt") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_catohkocur") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_catohkoamt") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_app2flg") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_app2flgby") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("cad_app2flgdat") = "01/01/1900"
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("CAD_DEL") = "N"
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("CAD_SHPNO") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("CAD_SHPSEQ") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("CAD_SCUNTCDE") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("CAD_CAREMAMT") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("CAD_creusr") = "~*ADD*~"
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("CAD_updusr") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("CAD_credat") = "01/01/1900"
        rs_CAORDDTL.Tables("RESULT").Rows(loc).Item("CAD_upddat") = "01/01/1900"
    End Function

    Private Function insert_CAORDITM(ByVal addnew As Boolean) As Integer
        Dim qutseq As Integer
        Dim loc As Integer

        qutseq = 0

        If addnew = True Then
            Dim i As Integer

            For i = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
                If rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_qutseq") > qutseq Then
                    qutseq = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_qutseq")
                End If
            Next i

            qutseq = qutseq + 1

            insert_CAORDITM = qutseq

            rs_CAORDITM.Tables("RESULT").Rows.Add()

            loc = rs_CAORDITM.Tables("RESULT").Rows.Count - 1
        Else
            ''should be the cur one, instead of last item
            qutseq = rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("cai_qutseq")
            loc = sReadingIndexQ_Item
            ''qutseq = rs_CAORDITM.Tables("RESULT").Rows(rs_CAORDITM.Tables("RESULT").Rows.Count - 1).Item("cai_qutseq")
        End If


        ''loc = sReadingIndexQ_Item
        ''loc = rs_CAORDITM.Tables("RESULT").Rows.Count - 1
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_cocde") = ""
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_caordno") = ""
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_caordseq") = qutseq
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_clatyp") = "00"
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_txcocde") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_scordno") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_scordseq") = 0
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_popurord") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_popurseq") = 0
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_pojobord") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_shinvno") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_sccuspono") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_shissdat") = "01/01/1900"
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_shetddat") = "01/01/1900"
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_shetadat") = "01/01/1900"
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_itmno") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_itmnoven") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_cusitm") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_cusstyno") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_venitm") = ""
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_itmdsc") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_prdven") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_ventyp") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_sccurcde") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_scnetuntprc") = 0
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_alscolcde") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_scfcurcde") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_scftyprc") = 0
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_scpckunt") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_untcde") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_scordqty") = 0
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_scshpqty") = 0
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_caqty") = 0
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_caqty_final") = 0
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_rmk") = "" '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_salcur") = "" '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_salamt") = 0 '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_grspftamt") = 0 '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_calmtamt") = 0 '
        '''rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_calmtper") = "" '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_cacur") = "" '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_caqtyamt_org") = 0 '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_caqtyamt_final") = 0 '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_caamt_org") = 0 '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_caamt_final") = 0 '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_ttlcaamt_org") = 0 '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_ttlcaamt_final") = 0 '
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_cavsgrspft") = 0
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_app1flg") = "" '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_app1flgby") = "" '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_app1flgdat") = "01/01/1900" '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_catoinscur") = "" '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_catoinsamt") = 0 '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_catovncur") = "" '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_catovnamt") = 0 '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_catohkocur") = "" '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_catohkoamt") = 0 '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_app2flg") = "" '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_app2flgby") = "" '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_app2flgdat") = "01/01/1900" '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_cusitm") = "" '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_cusstyno") = "" '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_venitm") = "" '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_prdven") = "" '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_DEL") = "N" '
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_SHPNO") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_SHPSEQ") = 0
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_SCUNTCDE") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_CAREMAMT") = 0 '
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_creusr") = "~*ADD*~"
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_updusr") = ""
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_credat") = "01/01/1900"
        rs_CAORDITM.Tables("RESULT").Rows(loc).Item("cai_upddat") = "01/01/1900"
    End Function

    Private Sub setStatus(ByVal Mode As String)

        If Mode = cModeInit Then



            cboClaimPaySTS.Text = ""
            cboClaimIncomeSTS.Text = ""

            txtItmNo.Text = ""
            txtPV.Text = ""
            txtCustItmNo.Text = ""
            txtCustStyNo.Text = ""
            txtVenItmNo.Text = ""
            txtItmDsc.Text = ""
            txtOrdQtyUM.Text = ""
            txtOrdQty.Text = ""
            txtShipQtyUM.Text = ""
            txtShipQty.Text = ""
            txtSelPrcCurrency.Text = ""
            txtSelPrc.Text = ""
            txtItmCstCurrency.Text = ""
            txtItmCst.Text = ""
            txt_Dtl_Rmk.Text = ""

            txtShipNo.Text = ""
            txtShipSeq.Text = ""
            txtSCNo.Text = ""
            txtSCSeq.Text = ""
            txtPONo.Text = ""
            txtPOSeq.Text = ""
            txtJobNo.Text = ""
            txtInvNo.Text = ""

            txtCusPONo.Text = ""
            txtInvIssDat.Text = ""
            txtInvETDDat.Text = ""
            txtInvETADat.Text = ""



            txtreason.Text = ""

            txt_org_dif.Text = ""
            txt_final_dif.Text = ""



            lblVendor.ForeColor = Color.Black

            txt_Hdr_FinalClaimAmt.ForeColor = Color.Black
            txt_Hdr_ClaimToHKOAmt.ForeColor = Color.Black
            txt_Hdr_ClaimToInsAmt.ForeColor = Color.Black
            txt_Hdr_ClaimToVNAmt.ForeColor = Color.Black


            FLAG_FIRST_TIME_CHECK_CASE = True
            '
            txt_Hdr_AcctClaimAmt.Text = ""
            cboClaimPaySTS.Text = ""
            txt_pay_rmk.Text = ""
            txt_pay_actamt.Text = ""
            txt_pay_potamt.Text = ""
            dtHDRPAIDDAT.Text = ""

            cboSETTLE_CUS.Text = ""
            txt_pay_upddat.Text = ""
            cbo_pay_cur.Text = "USD"

            cboClaimIncomeSTS.Text = ""
            txt_income_rmk.Text = ""
            txt_income_actamt.Text = ""
            txt_income_potamt.Text = ""
            dtHDRRCVDAT.Text = ""
            cboSETTLE_FTY.Text = ""
            txt_income_upddat.Text = ""
            cbo_income_cur.Text = "USD"



            cbo_Hdr_ClaimToInsAmtCur.Text = "USD"
            cbo_Hdr_ClaimToVNAmtCur.Text = "USD"
            cbo_Hdr_ClaimToHKOAmtCur.Text = "USD"

            rbClaimBy_C.Checked = False
            rbClaimBy_V.Checked = False
            rbClaimBy_U.Checked = False

            chkwait.Enabled = False
            cmd_attch.Enabled = False
            mmdAttach.Enabled = False

            chkconfirmclm.Checked = False
            chkvalidclm.Checked = False
            chkconfirmclm.Enabled = False
            chkvalidclm.Enabled = False

            chkreplace.Checked = False

            txt_ref_no.Text = ""
            dt_ref_date.Text = ""

            txt_stschg_usr.Text = ""
            txt_stschg_date.Text = ""

            txt_cmt_a.Text = ""
            txt_cmt_b.Text = ""
            txt_Hdr_ClaimToInsAmt_ori.Text = ""
            txt_Hdr_ClaimToVNAmt_ori.Text = ""
            txt_Hdr_ClaimToHKOAmt_ori.Text = ""


            chkapv1a.Checked = False
            chkapv1b.Checked = False
            chkapv2a.Checked = False
            chkapv2b.Checked = False
            chkapv3a.Checked = False
            chkapv3b.Checked = False


            chkapv1a.Enabled = False
            chkapv1b.Enabled = False
            chkapv2a.Enabled = False
            chkapv2b.Enabled = False
            chkapv3a.Enabled = False
            chkapv3b.Enabled = False

            Me.btcCLM00001.TabPages(0).Enabled = True
            Me.btcCLM00001.TabPages(1).Enabled = False
            Me.btcCLM00001.TabPages(2).Enabled = False
            Me.btcCLM00001.TabPages(3).Enabled = False


            StatusBar.Panels(1).Text = Format(Today, "MM/dd/yyyy") & _
                            "   " & Format(Today, "MM/dd/yyyy") & _
                            "   " & gsUsrID

            cboSeason.Text = ""
            txtSalesManager.Text = ""
            txtSalesTeam.Text = ""

            txt_Hdr_AcctClaimAmt.Enabled = False

            chkapv1a.Checked = False
            chkapv1b.Checked = False
            chkapv2a.Checked = False
            chkapv2b.Checked = False
            chkapv3a.Checked = False
            chkapv3b.Checked = False

            chkapv1b.Enabled = False
            chkapv2a.Enabled = False
            chkapv2b.Enabled = False
            chkapv3a.Enabled = False
            chkapv3b.Enabled = False

            chkconfirmclm.Checked = False
            chkwait.Checked = False

            chkconfirmclm.Enabled = False
            chkvalidclm.Enabled = False
            txt_ref_no.Enabled = False
            dt_ref_date.Enabled = False
            

            chkwait.Enabled = False
            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                txt_cmt_a.Enabled = True
                txt_cmt_a.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_cmt_a.ReadOnly = True
            Else
                txt_cmt_a.Enabled = True
            End If

            txt_Hdr_ClaimToInsAmt_ori.Enabled = False
            cbo_Hdr_ClaimToInsAmtCur.Enabled = False
            txt_Hdr_ClaimToVNAmt_ori.Enabled = False
            cbo_Hdr_ClaimToVNAmtCur.Enabled = False
            txt_Hdr_ClaimToHKOAmt_ori.Enabled = False
            cbo_Hdr_ClaimToHKOAmtCur.Enabled = False
            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                txt_cmt_b.Enabled = True
                txt_cmt_b.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_cmt_b.ReadOnly = True
            Else
                txt_cmt_b.Enabled = True
            End If

            chkreplace.Checked = False
            chkreplace.Enabled = False



            Call resetcmdButton(cModeInit)
            flag_rbViewOn_click = False
            rbViewOn_S.Checked = True
            rbViewOn_I.Checked = False

            Me.txtClaimNo.Enabled = True

            Me.cboClaimPeriod.Visible = False
            Me.txtClaimPeriod.Visible = True

            Me.rbClaimAmtPer_C.Checked = False
            Me.rbClaimAmtPer_I.Checked = False
            Me.rbClaimAmtPer_S.Checked = False
            sHdrClaimAmtPer = "C"

            'Me.lbl_Hdr_AppLmtChkPer_E.Text = ""
            'Me.lbl_Hdr_AppLmtChkPer_I.Text = ""
            Me.lbl_Hdr_AppLmtChkPer_Ttl.Text = ""
            Me.lbl_Hdr_ExceedAppLmt.Visible = False

            Me.lbl_Dtl_AppLmtChkPer.Text = ""
            ''Me.lbl_Dtl_ExceedAppLmt.Visible = False

            Me.sReadingSeq_Item = 1
            Me.sReadingSeq_ship = 1

            Me.btcCLM00001.TabPages(0).Enabled = False
            Me.btcCLM00001.TabPages(0).Enabled = True
            Me.btcCLM00001.TabPages(1).Enabled = False
            Me.btcCLM00001.TabPages(2).Enabled = False
            Me.btcCLM00001.TabPages(3).Enabled = False

            btcCLM00001.SelectedIndex = 0

            Recordstatus = False
            Recorddisplay = False
            UserEditCombo = False
            'ClaimAmt_Header = False

            sClaimStatus = ""
            nHdrSearchBy = 0
            sReadingSeq_Item = 1
            sReadingSeq_ship = 1
            sCheckedLevel = "C"
            addition = ""

            '2013 should reset  display here
            '''123
            Call resetDisplay(cModeInit)

            txtClaimNo.Focus()


            '''20131205
            ''' 
            cboClaimPeriod.Enabled = False
            txtClaimPeriod.Enabled = False
            cboSeason.Enabled = False
            cboClaimSts.Enabled = False
            chkCancel.Enabled = False

            gbClaimBy.Enabled = False
            rbClaimBy_C.Enabled = False
            rbClaimBy_V.Enabled = False
            rbClaimBy_U.Enabled = False

            cboPriCust.Enabled = False
            cboSecCust.Enabled = False
            cboVendor.Enabled = False

            rbClaimAmtPer_C.Enabled = False
            rbClaimAmtPer_I.Enabled = False
            rbClaimAmtPer_S.Enabled = False

            cboClaimType.Enabled = False
            txtSalesManager.Enabled = False
            txtSalesTeam.Enabled = False


            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) <> "HAH" Then

                txt_Hdr_Rmk.Enabled = True

                txt_Hdr_Rmk.ReadOnly = True
                'txt_Hdr_CustComment.Enabled = False    

                txt_Hdr_CustComment.Enabled = True

                txt_Hdr_CustComment.ReadOnly = True
                'txt_Hdr_Finding.Enabled = False     

                txt_Hdr_Finding.Enabled = True

                txt_Hdr_Finding.ReadOnly = True


            Else

                txt_Hdr_Rmk.Enabled = False
                txt_Hdr_Finding.Enabled = False
                txt_Hdr_CustComment.Enabled = False

            End If



            cbo_Hdr_ClaimAmtCurrency.Enabled = False
            txt_Hdr_OrgClaimAmt.Enabled = False
            txt_Hdr_FinalClaimAmt.Enabled = False

            cbo_Hdr_ClaimToInsAmtCurrency.Enabled = False
            txt_Hdr_ClaimToInsAmt.Enabled = False
            cbo_Hdr_ClaimToVNAmtCurrency.Enabled = False
            txt_Hdr_ClaimToVNAmt.Enabled = False
            cbo_Hdr_ClaimToHKOAmtCurrency.Enabled = False
            txt_Hdr_ClaimToHKOAmt.Enabled = False


            'cboClaimPaySTS.Enabled = False
            gb_pay.Enabled = False
            gb_income.Enabled = False

            'dtHDRPAIDDAT.Enabled = False
            'cboSETTLE_CUS.Enabled = False
            'cboSETTLE_FTY.Enabled = False
            'cboAPRVSTS.Enabled = False

            chkClose.Enabled = False
            txt_Hdr_FinalClaimAmt.Text = ""

            'dtHDRRCVDAT.Enabled = False


            resetcmdButton(cModeInit)


            'txtSalesManager.Text = ""
            ' txtSalesTeam.Text = ""

            chkCancel.Checked = False

            txt_Hdr_Rmk.Text = ""
            txt_Hdr_CustComment.Text = ""
            txt_Hdr_Finding.Text = ""

            txt_Hdr_OrgClaimAmt.Text = "0"
            txt_Hdr_FinalClaimAmt.Text = "0"

            txt_Hdr_ClaimToInsAmt.Text = "0"
            txt_Hdr_ClaimToVNAmt.Text = "0"
            txt_Hdr_ClaimToHKOAmt.Text = "0"

            txt_Hdr_ClaimToInsAmt_ori.Text = "0"
            txt_Hdr_ClaimToVNAmt_ori.Text = "0"
            txt_Hdr_ClaimToHKOAmt_ori.Text = "0"

            chkapv1a.Enabled = False

            gbPanelReason.Hide()
            gbPanelReason.Visible = False

            CmdViewReason.Enabled = False

            txtItmNo.Enabled = False
            txtPV.Enabled = False
            txtCustItmNo.Enabled = False
            txtCustStyNo.Enabled = False
            txtVenItmNo.Enabled = False
            txtOrdQtyUM.Enabled = False
            txtOrdQty.Enabled = False
            txtShipQtyUM.Enabled = False
            txtShipQty.Enabled = False
            txtSelPrcCurrency.Enabled = False
            txtSelPrc.Enabled = False
            txtItmCstCurrency.Enabled = False
            txtItmCst.Enabled = False
            txtItmDsc.Enabled = False

            txtCoCde.Enabled = False
            txtShipNo.Enabled = False
            txtShipSeq.Enabled = False
            txtSCNo.Enabled = False
            txtSCSeq.Enabled = False
            txtPONo.Enabled = False
            txtPOSeq.Enabled = False
            txtJobNo.Enabled = False
            txtInvNo.Enabled = False
            txtCusPONo.Enabled = False

            txtInvIssDat.Enabled = False
            txtInvETDDat.Enabled = False
            txtInvETADat.Enabled = False

            chkDelete.Enabled = False

            sReadingIndexQ_Item = 0
            sReadingIndexQ_ship = 0

            If Microsoft.VisualBasic.Left(temp_yup_usrgrp, 3) = "ACT" Then
                mmdAdd.Enabled = False
            End If

            txtReplaceClaimNo.Enabled = False

            mmdPrint.Enabled = False

        ElseIf Mode = cModeAdd Then

            'chkwait.Enabled = True
            'chkconfirmclm.Enabled = True

            'should
            'cboClaimType.Text = ""
            'txtSalesManager.Text = ""
            'txtSalesTeam.Text = ""
            CmdViewReason.Enabled = False

            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_CAORDDTL '',''"
            rtnLong = execute_SQLStatement(gspStr, rs_CAORDDTL, rtnStr)
            gspStr = ""

            '''' Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading setStatus sp_select_CAORDDTL :" & rtnStr)
                '''' Cursor = Cursors.Default
                Exit Sub
            Else
                For i As Integer = 0 To rs_CAORDDTL.Tables("RESULT").Columns.Count - 1
                    rs_CAORDDTL.Tables("RESULT").Columns(i).ReadOnly = False
                Next i

                'drNewRow = rs_CAORDDTL.Tables("RESULT").NewRow()
                'drNewRow("mode") = "NEW"
                'drNewRow("qud_apprve") = ""
                'rs_CAORDDTL.Tables("RESULT").Rows.Add(drNewRow)
                '''Call insert_CAORDDTL(True)

                '''                rs_CAORDDTL.Tables("RESULT").Rows(0).Item("mode") = "NEW"
                'Call display_dgOthDtl("A")
                '''             Insert_flag = True
                lblSeq.Text = rs_CAORDDTL.Tables("RESULT").Rows.Count


                '

                gspStr = "sp_select_CAORDITM '',''"
                rtnLong = execute_SQLStatement(gspStr, rs_CAORDITM, rtnStr)
                gspStr = ""

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading setStatus sp_select_CAORDITM :" & rtnStr)
                    '''' Cursor = Cursors.Default
                    Exit Sub
                Else
                    For i As Integer = 0 To rs_CAORDITM.Tables("RESULT").Columns.Count - 1
                        rs_CAORDITM.Tables("RESULT").Columns(i).ReadOnly = False
                    Next i

                    'drNewRow = rs_CAORDITM.Tables("RESULT").NewRow()
                    'drNewRow("mode") = "NEW"
                    'drNewRow("qud_apprve") = ""
                    'rs_CAORDITM.Tables("RESULT").Rows.Add(drNewRow)
                    ''' Call insert_CAORDITM(True)

                End If

                Me.txtClaimNo.Text = ""
                Me.txtClaimNo.Enabled = False

                Me.btcCLM00001.TabPages(0).Enabled = True
                Me.btcCLM00001.TabPages(1).Enabled = False
                Me.btcCLM00001.TabPages(2).Enabled = False
                Me.btcCLM00001.TabPages(3).Enabled = False
                '''Me.btcCLM00001.TabPages(1).Enabled = False
                '''Me.btcCLM00001.TabPages(2).Enabled = False

                'Me.txtClaimIssDate.Enabled = True
                'Me.txtClaimIssDate.Text = Format(Date.Today, "MM/dd/yyyy")
                Me.cboClaimPeriod.Enabled = True
                Me.cboClaimPeriod.Visible = True
                Me.txtClaimPeriod.Enabled = False
                Me.txtClaimPeriod.Visible = False

                display_combo("OPEN", cboClaimSts)
                sClaimStatus = "OPEN"
                addition = sClaimStatus

                'Initial for Customer fields
                cbo_Hdr_SalesAmtCurrency.Text = "USD"
                'cbo_Hdr_GrsPftCurrency.Text = "USD"
                cbo_Hdr_AppLmtChkCurrency.Text = "USD"
                cbo_Hdr_RemainClaimCurrency.Text = "USD"

                cbo_Hdr_ClaimAmtCurrency.Text = "USD"

                cbo_Hdr_ClaimToInsAmtCurrency.Text = "USD"
                cbo_Hdr_ClaimToVNAmtCurrency.Text = "USD"
                'cbo_Hdr_ClaimToEVNAmtCurrency.Text = "USD"
                cbo_Hdr_ClaimToHKOAmtCurrency.Text = "USD"

                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cocde") = ""

                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salcur") = cbo_Hdr_SalesAmtCurrency.Text

                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salttlamt") = "0.00"
                'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salttlamt_i") = "0.00"
                'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salttlamt_e") = "0.00"

                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_grspftamt") = "0.00"
                'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_grspftamt_i") = "0.00"
                'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_grspftamt_e") = "0.00"

                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtamt") = "0.00"
                'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtamt_i") = "0.00"
                'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtamt_e") = "0.00"

                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtper") = Decimal.Round(cHdrAppLmtChkPer * 100, 0)
                'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtper_i") = "0.00"
                'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtper_e") = "0.00"

                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caremamt") = "0.00"

                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cacur") = cbo_Hdr_ClaimAmtCurrency.Text

                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_org") = "0.00"
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_final") = "0.00"
                'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cavsgrspft") = "0.00"

                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app1flg") = ""
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app1flgby") = ""
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app1flgdat") = "01/01/1900"

                'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoinscur") = cbo_Hdr_ClaimToInsAmtCurrency.Text
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoinsamt") = "0.00"
                'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catovncur") = cbo_Hdr_ClaimToVNAmtCurrency.Text
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catovnamt") = "0.00"
                'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoevncur") = cbo_Hdr_ClaimToEVNAmtCurrency.Text
                'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoevnamt") = "0.00"
                'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catohkocur") = cbo_Hdr_ClaimToHKOAmtCurrency.Text
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catohkoamt") = "0.00"

                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app2flg") = ""
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app2flgby") = ""
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app2flgdat") = "01/01/1900"

                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_curexrat") = "0.00"
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_curexeffdat") = rs_SYCUREX.Tables("RESULT").Rows(0).Item("yce_effdat")
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salesmanger") = ""
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salesteam") = ""
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~"
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_updusr") = "~*ADD*~"

                '''20131115
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_per") = "C"

                'Initial for Item and Shipment fields
                'cboSelPrcCurrency.Text = "USD"
                'cboItmCstCurrency.Text = "USD"

                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_caordseq") = "1"
                'rs_CAORDDTL.Tables("RESULT").Rows(0).Item("cad_caordseq") = "1"

                'cbo_Dtl_SalesAmtCurrency.Text = "USD"
                'cbo_Dtl_GrsPftCurrency.Text = "USD"
                'cbo_Dtl_AppLmtChkCurrency.Text = "USD"
                'cbo_Dtl_RemainClaimCurrency.Text = "USD"

                'cbo_Dtl_ClaimQtyAmtCurrency.Text = "USD"
                'cbo_Dtl_ClaimAmtCurrency.Text = "USD"
                'cbo_Dtl_ClaimTtlAmtCurrency.Text = "USD"

                'cbo_Dtl_ClaimToInsAmtCurrency.Text = "USD"
                'cbo_Dtl_ClaimToVNAmtCurrency.Text = "USD"
                'cbo_Dtl_ClaimToHKOAmtCurrency.Text = "USD"

                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_cocde") = ""

                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_salcur") = cbo_Dtl_SalesAmtCurrency.Text

                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_salttlamt") = "0.00"
                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_grspftamt") = "0.00"
                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_calmtamt") = "0.00"
                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_calmtper") = Decimal.Round(cDtlAppLmtChkPer * 100, 0)

                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_caremamt") = "0.00"

                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_cacur") = cbo_Dtl_ClaimAmtCurrency.Text

                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_caamt_org") = "0.00"
                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_caamt_final") = "0.00"

                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_app1flg") = ""
                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_app1flgby") = ""
                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_app1flgdat") = "01/01/1900"

                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_catoinscur") = cbo_Dtl_ClaimToInsAmtCurrency.Text
                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_catoinsamt") = "0.00"
                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_catovncur") = cbo_Dtl_ClaimToVNAmtCurrency.Text
                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_catovnamt") = "0.00"
                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_catohkocur") = cbo_Dtl_ClaimToHKOAmtCurrency.Text
                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_catohkoamt") = "0.00"

                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_app2flg") = ""
                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_app2flgby") = ""
                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_app2flgdat") = "01/01/1900"

                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_creusr") = "~*ADD*~"
                'rs_CAORDITM.Tables("RESULT").Rows(0).Item("cai_updusr") = "~*ADD*~"

                'rs_CAORDDTL.Tables("RESULT").Rows(0).Item("cad_cocde") = ""

                'rs_CAORDDTL.Tables("RESULT").Rows(0).Item("cad_cacur") = cbo_Dtl_SalesAmtCurrency.Text

                'rs_CAORDDTL.Tables("RESULT").Rows(0).Item("cad_caqtyamt_org") = "0.00"
                'rs_CAORDDTL.Tables("RESULT").Rows(0).Item("cad_caqtyamt_final") = "0.00"

                'rs_CAORDDTL.Tables("RESULT").Rows(0).Item("cad_caamt_org") = "0.00"
                'rs_CAORDDTL.Tables("RESULT").Rows(0).Item("cad_caamt_final") = "0.00"

                'rs_CAORDDTL.Tables("RESULT").Rows(0).Item("cad_ttlcaamt_org") = "0.00"
                'rs_CAORDDTL.Tables("RESULT").Rows(0).Item("cad_ttlcaamt_final") = "0.00"

                'rs_CAORDDTL.Tables("RESULT").Rows(0).Item("cad_catoinscur") = cbo_Dtl_ClaimToInsAmtCurrency.Text
                'rs_CAORDDTL.Tables("RESULT").Rows(0).Item("cad_catoinsamt") = "0.00"
                'rs_CAORDDTL.Tables("RESULT").Rows(0).Item("cad_catovncur") = cbo_Dtl_ClaimToVNAmtCurrency.Text
                'rs_CAORDDTL.Tables("RESULT").Rows(0).Item("cad_catovnamt") = "0.00"
                'rs_CAORDDTL.Tables("RESULT").Rows(0).Item("cad_catohkocur") = cbo_Dtl_ClaimToHKOAmtCurrency.Text
                'rs_CAORDDTL.Tables("RESULT").Rows(0).Item("cad_catohkoamt") = "0.00"

                'rs_CAORDDTL.Tables("RESULT").Rows(0).Item("cad_creusr") = "~*ADD*~"
                'rs_CAORDDTL.Tables("RESULT").Rows(0).Item("cad_updusr") = "~*ADD*~"
                '''201312217 deatil
                ''' 
                txtItmNo.Enabled = False
                txtPV.Enabled = False
                txtCustItmNo.Enabled = False
                txtCustStyNo.Enabled = False
                txtVenItmNo.Enabled = False
                txtOrdQtyUM.Enabled = False
                txtOrdQty.Enabled = False
                txtShipQtyUM.Enabled = False
                txtShipQty.Enabled = False
                txtSelPrcCurrency.Enabled = False
                txtSelPrc.Enabled = False
                txtItmCstCurrency.Enabled = False
                txtItmCst.Enabled = False
                txtItmDsc.Enabled = False

                txtCoCde.Enabled = False
                txtShipNo.Enabled = False
                txtShipSeq.Enabled = False
                txtSCNo.Enabled = False
                txtSCSeq.Enabled = False
                txtPONo.Enabled = False
                txtPOSeq.Enabled = False
                txtJobNo.Enabled = False
                txtInvNo.Enabled = False
                txtCusPONo.Enabled = False

                txtInvIssDat.Enabled = False
                txtInvETDDat.Enabled = False
                txtInvETADat.Enabled = False

                mmdClear.Enabled = True



            End If

            txtReplaceClaimNo.Enabled = True



        ElseIf Mode = cModeUpd Then

            mmdAdd.Enabled = False


            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                gb_pay.Enabled = True
                gb_income.Enabled = True
            End If

            If Microsoft.VisualBasic.Left(get_usr_dept(), 3) = "SAL" And _
    gsUsrRank >= 3 And (sClaimStatus = "OPEN") Then
                chkconfirmclm.Enabled = True
                chkvalidclm.Enabled = True
            Else
                chkconfirmclm.Enabled = False
                chkvalidclm.Enabled = False
            End If

            If Not ((sClaimStatus = "OPEN")) Then
                If Microsoft.VisualBasic.Left(gsUsrGrp, 3) <> "HAH" Then


                    txt_Hdr_CustComment.Enabled = True

                    txt_Hdr_CustComment.ReadOnly = True

                    txt_Hdr_Rmk.Enabled = True

                    txt_Hdr_Rmk.ReadOnly = True

                    txt_Hdr_Finding.Enabled = True

                    txt_Hdr_Finding.ReadOnly = True



                Else

                    txt_Hdr_Rmk.Enabled = False
                    txt_Hdr_Finding.Enabled = False
                    txt_Hdr_CustComment.Enabled = False
                End If



                chkreplace.Enabled = False
                txt_ref_no.Enabled = False
                dt_ref_date.Enabled = False
                


            End If

            'If Microsoft.VisualBasic.Left(get_usr_dept(), 3) = "SAL" And _
            '    gsUsrRank >= 3 And (sClaimStatus = "OPEN" Or sClaimStatus = "WAIT") Then
            '    chkconfirmclm.Enabled = True
            '    chkvalidclm.Enabled = True
            'Else
            '    chkconfirmclm.Enabled = False
            '    chkvalidclm.Enabled = False
            'End If

            'If Not ((sClaimStatus = "OPEN" Or sClaimStatus = "WAIT")) Then
            '    'txt_Hdr_CustComment.Enabled = False    

            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) <> "HAH" Then

                txt_Hdr_CustComment.Enabled = True
                txt_Hdr_CustComment.ReadOnly = True
                txt_Hdr_Rmk.Enabled = True
                txt_Hdr_Rmk.ReadOnly = True
                txt_Hdr_Finding.Enabled = True
                txt_Hdr_Finding.ReadOnly = True

            Else
                txt_Hdr_Rmk.Enabled = False
                txt_Hdr_Finding.Enabled = False
                txt_Hdr_CustComment.Enabled = False

            End If



            '    chkreplace.Enabled = False
            '    txt_ref_no.Enabled = False
            '    dt_ref_date.Enabled = False
            'End If

            Me.gbClaimAmtPer.Enabled = False
            If Microsoft.VisualBasic.Left(get_usr_dept(), 3) = "SAL" And _
                gsUsrRank >= 3 Then
                gbClaimAmtPer.Enabled = True
                chkreplace.Enabled = True
                txt_ref_no.Enabled = True
                dt_ref_date.Enabled = True

            Else
                chkreplace.Enabled = False
                txt_ref_no.Enabled = False
                dt_ref_date.Enabled = False
                
            End If



            If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "OPEN" _
             Or rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "APRV" _
            Then
                chkconfirmclm.Enabled = True
                chkvalidclm.Enabled = True
            End If

            cmd_attch.Enabled = True
            mmdAttach.Enabled = True

            If rbClaimBy_C.Checked = True Then
                txt_Hdr_ClaimToInsAmt_ori.Text = "0"
                txt_Hdr_ClaimToInsAmt.Text = "0"
                txt_Hdr_ClaimToInsAmt_ori.Enabled = False
                cbo_Hdr_ClaimToInsAmtCur.Enabled = False
                txt_Hdr_ClaimToInsAmt.Enabled = False
            ElseIf rbClaimBy_V.Checked = True Then
                txt_Hdr_ClaimToVNAmt_ori.Text = "0"
                txt_Hdr_ClaimToVNAmt.Text = "0"
                txt_Hdr_ClaimToVNAmt_ori.Enabled = False
                cbo_Hdr_ClaimToVNAmtCur.Enabled = False
                txt_Hdr_ClaimToVNAmt.Enabled = False
            End If

            'If (gsUsrRank < 3 Or Microsoft.VisualBasic.Left(get_usr_dept(), 3) = "SAL") And (sClaimStatus = "OPEN" Or sClaimStatus = "WAIT") Then
            '    chkwait.Enabled = True
            'Else
            '    'chkwait.Enabled = false
            'End If
            If sClaimStatus = "OPEN" Or sClaimStatus = "WAIT" Then
                chkwait.Enabled = True
            End If


            Me.txtClaimNo.Enabled = False

            If gsUsrRank < 4 _
                 Or Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                chkCancel.Enabled = True
            Else
                chkCancel.Enabled = False
            End If

            '
            If gsUsrRank < 3 _
     Or Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                Me.btcCLM00001.TabPages(1).Enabled = True
            Else
                Me.btcCLM00001.TabPages(1).Enabled = False
            End If


            Call set_app_buttons()

            Me.btcCLM00001.TabPages(0).Enabled = True
            Me.btcCLM00001.TabPages(1).Enabled = True
            Me.btcCLM00001.TabPages(2).Enabled = True
            Me.btcCLM00001.TabPages(3).Enabled = True


            Me.rbClaimAmtPer_C.Enabled = False
            Me.rbClaimAmtPer_I.Enabled = False
            Me.rbClaimAmtPer_S.Enabled = False

            Me.cboClaimType.Enabled = False


            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then

                Me.txt_Hdr_Rmk.Enabled = True
                Me.txt_Hdr_Rmk.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_Hdr_Rmk.ReadOnly = False

                Me.txt_Hdr_CustComment.Enabled = True
                Me.txt_Hdr_CustComment.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_Hdr_CustComment.ReadOnly = False

                Me.txt_Hdr_Finding.Enabled = True
                Me.txt_Hdr_Finding.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_Hdr_Finding.ReadOnly = False

            Else

                Me.txt_Hdr_Rmk.Enabled = True
                Me.txt_Hdr_CustComment.Enabled = True
                Me.txt_Hdr_Finding.Enabled = True
                txt_Hdr_Rmk.ReadOnly = False
                txt_Hdr_CustComment.ReadOnly = False
                txt_Hdr_Finding.ReadOnly = False

            End If


            'If rs_CAORDDTL.Tables("RESULT").Rows.Count > 0 Then
            Me.txt_Dtl_Rmk.Enabled = True
            'Me.txt_Dtl_OrgClaimQty.Enabled = True
            'Me.cbo_Dtl_ClaimType.Enabled = True

            If sClaimStatus = "OPEN" Then
                Me.chkDelete.Enabled = True
            ElseIf Mid(sClaimStatus, 4, 1) = "a" Then

                cbo_Hdr_ClaimAmtCurrency.Enabled = False
                txt_Hdr_OrgClaimAmt.Enabled = False
                txt_Hdr_FinalClaimAmt.Enabled = False

                cbo_Hdr_ClaimToInsAmtCurrency.Enabled = True
                txt_Hdr_ClaimToInsAmt.Enabled = True
                cbo_Hdr_ClaimToVNAmtCurrency.Enabled = True
                txt_Hdr_ClaimToVNAmt.Enabled = True
                cbo_Hdr_ClaimToHKOAmtCurrency.Enabled = True
                txt_Hdr_ClaimToHKOAmt.Enabled = True
                chkwait.Enabled = False

                chkconfirmclm.Enabled = False
                chkvalidclm.Enabled = False

            ElseIf Mid(sClaimStatus, 4, 1) = "b" Then
                cbo_Hdr_ClaimAmtCurrency.Enabled = False
                txt_Hdr_OrgClaimAmt.Enabled = False
                txt_Hdr_FinalClaimAmt.Enabled = False

                cbo_Hdr_ClaimToInsAmtCurrency.Enabled = False
                txt_Hdr_ClaimToInsAmt.Enabled = False
                cbo_Hdr_ClaimToVNAmtCurrency.Enabled = False
                txt_Hdr_ClaimToVNAmt.Enabled = False
                cbo_Hdr_ClaimToHKOAmtCurrency.Enabled = False
                txt_Hdr_ClaimToHKOAmt.Enabled = False
                chkwait.Enabled = False

                chkconfirmclm.Enabled = False
                chkvalidclm.Enabled = False

                txt_Hdr_AcctClaimAmt.Enabled = True

                If Microsoft.VisualBasic.Left(gsUsrGrp, 3) <> "HAH" Then
                    txt_Hdr_Rmk.Enabled = True
                    txt_Hdr_Rmk.ReadOnly = True
                    txt_Hdr_CustComment.Enabled = True
                    txt_Hdr_CustComment.ReadOnly = True
                    txt_Hdr_Finding.Enabled = True
                    txt_Hdr_Finding.ReadOnly = True
                Else
                    txt_Hdr_Rmk.Enabled = False
                    txt_Hdr_Finding.Enabled = False
                    txt_Hdr_CustComment.Enabled = False
                End If



                ''gb_pay.Enabled = True
                ''gb_income.Enabled = True
            ElseIf sClaimStatus = "APRV" Then
                'gb_pay.Enabled = True
                'gb_income.Enabled = True


                cbo_Hdr_ClaimAmtCurrency.Enabled = False
                txt_Hdr_OrgClaimAmt.Enabled = False
                txt_Hdr_FinalClaimAmt.Enabled = False

                cbo_Hdr_ClaimToInsAmtCur.Enabled = False
                cbo_Hdr_ClaimToVNAmtCur.Enabled = False
                cbo_Hdr_ClaimToHKOAmtCur.Enabled = False

                txt_Hdr_ClaimToInsAmt_ori.Enabled = False
                txt_Hdr_ClaimToVNAmt_ori.Enabled = False
                txt_Hdr_ClaimToHKOAmt_ori.Enabled = False

                txt_Hdr_ClaimToInsAmt.Enabled = False
                txt_Hdr_ClaimToVNAmt.Enabled = False
                txt_Hdr_ClaimToHKOAmt.Enabled = False


            ElseIf sClaimStatus = "CLOS" Then
                chkreplace.Enabled = False
                txt_ref_no.Enabled = False
                dt_ref_date.Enabled = False
                

                chkwait.Enabled = False

                chkconfirmclm.Enabled = False
                chkvalidclm.Enabled = False

                chkCancel.Enabled = False
                txt_Hdr_AcctClaimAmt.Enabled = False
                'txt_Hdr_Rmk.Enabled = False     

                If Microsoft.VisualBasic.Left(gsUsrGrp, 3) <> "ACT" Then
                    txt_Hdr_Rmk.Enabled = True
                    txt_Hdr_Rmk.ReadOnly = True
                    txt_Hdr_CustComment.Enabled = True
                    txt_Hdr_CustComment.ReadOnly = True
                    txt_Hdr_Finding.Enabled = True
                    txt_Hdr_Finding.ReadOnly = True
                Else
                    txt_Hdr_Rmk.Enabled = False
                    txt_Hdr_Finding.Enabled = False
                    txt_Hdr_CustComment.Enabled = False
                End If

                chkapv1a.Enabled = False
                chkapv1b.Enabled = False

                cmd_close.Enabled = False
                txt_Hdr_AcctClaimAmt.Enabled = False

                'gb_pay.Enabled = True
                'gb_income.Enabled = True
                chkconfirmclm.Enabled = False
                chkvalidclm.Enabled = False
                mmdInsRow.Enabled = False
                mmdDelRow.Enabled = False
                cmd_attch.Enabled = False
                mmdAttach.Enabled = False

                If Microsoft.VisualBasic.Left(temp_yup_usrgrp, 3) = "ACT" Then
                    mmdSave.Enabled = True

                Else
                    mmdSave.Enabled = False

                End If

                If sClaimStatus <> "OPEN" And sClaimStatus <> "WAIT" Then
                    txt_Dtl_Rmk.Enabled = False
                    chkDelete.Enabled = False
                    dgSummary.Enabled = False
                Else
                    If gsUsrRank < 3 Or Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "SAL" Then
                        txt_Dtl_Rmk.Enabled = True
                        chkDelete.Enabled = True
                        dgSummary.Enabled = True
                    End If
                End If

            ElseIf sClaimStatus = "CANL" Then


                chkwait.Enabled = False

                chkconfirmclm.Enabled = False
                chkvalidclm.Enabled = False

                chkCancel.Enabled = False
                CmdViewReason.Enabled = False

                chkapv1a.Enabled = False
                chkapv1b.Enabled = False
                chkapv2a.Enabled = False
                chkapv2b.Enabled = False
                chkapv3a.Enabled = False
                chkapv3b.Enabled = False
                If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                    txt_cmt_a.Enabled = True
                    txt_cmt_a.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                    txt_cmt_a.ReadOnly = True
                Else
                    txt_cmt_a.Enabled = True
                End If

                If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                    txt_cmt_b.Enabled = True
                    txt_cmt_b.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                    txt_cmt_b.ReadOnly = True
                Else
                    txt_cmt_b.Enabled = True
                End If


            Else
            End If

            'If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") <> "APV1b" Then
            '    If chkCancel.Checked = False Then
            '        chkClose.Enabled = False
            '    End If
            'End If

            'End If
            addition = sClaimStatus

            mmdClear.Enabled = True
            mmdPrint.Enabled = True

            txtReplaceClaimNo.Enabled = True

        ElseIf Mode = cModeSave Then
            'Call SetStatusBar(Mode)
            'If Add_flag = True Then
            '    txtQutNo.Text = qutNo
            'End If
            'MsgBox("Record Saved!")
            'copy_flag = False

            'rs_CAORDHDR.Tables.Clear()
            'rs_CAORDDTL.Tables.Clear()
            ''*** Phase 2
            'rs_QUPRCEMT.Tables.Clear()

            'rs_QUCPTBKD.Tables.Clear()
            'rs_QUASSINF.Tables.Clear()
            ''*** Phase 2 comment it
            ''rs_QUADDINF.Tables.Clear()
            ''rs_QUCSTEMT.Tables.Clear()
            ''rs_QUELC.Tables.Clear()
            ''rs_QUELCDTL.Tables.Clear()
            'ori_qce_amt = "0"
            'ori_qce_percent = "0"
            'ori_qed_percent = "0"

            Call setStatus(cModeInit)
            '  sMode = cModeInit
            ' OldItemRecord = False
        ElseIf Mode = cModeDel Then
            'Call SetStatusBar(Mode)
            'OldItemRecord = False
        ElseIf Mode = cModeClear Then
            'Call setStatus(cModeInit)
            'sMode = cModeInit
            'Call SetStatusBar(Mode)

            'QuotCopyFlag = False
            ' rs_CAORDHDR.Tables.Clear()
            'rs_CAORDDTL.Tables.Clear()
            '*** Phase Call setStatus(cModeRead)
            sReadingIndexQ_Item = 0
            sReadingIndexQ_ship = 0
        ElseIf Mode = cModeRead Then
            ''
            mmdAdd.Enabled = False

            mmdClear.Enabled = True




            '''20131205
            chkreplace.Enabled = False

            chkapv1a.Enabled = False
            chkapv1b.Enabled = False
            chkapv2a.Enabled = False
            chkapv2b.Enabled = False
            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) <> "ACT" Then
                chkapv3a.Enabled = False
                chkapv3b.Enabled = False

            End If


            mmdInsRow.Enabled = False
            'cmd_attch.Enabled = False
            chkconfirmclm.Enabled = False
            chkvalidclm.Enabled = False
            txt_ref_no.Enabled = False
            dt_ref_date.Enabled = False

            chkwait.Enabled = False
            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                txt_cmt_a.Enabled = True
                txt_cmt_a.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_cmt_a.ReadOnly = True
            Else
                txt_cmt_a.Enabled = True
            End If

            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                txt_cmt_b.Enabled = True
                txt_cmt_b.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_cmt_b.ReadOnly = True
            Else
                txt_cmt_b.Enabled = True
            End If

            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                txtReplaceClaimNo.Enabled = True
            End If



            txt_Hdr_ClaimToInsAmt_ori.Enabled = False
            cbo_Hdr_ClaimToInsAmtCur.Enabled = False
            txt_Hdr_ClaimToVNAmt_ori.Enabled = False
            cbo_Hdr_ClaimToVNAmtCur.Enabled = False
            txt_Hdr_ClaimToHKOAmt_ori.Enabled = False
            cbo_Hdr_ClaimToHKOAmtCur.Enabled = False


            cbo_Hdr_ClaimAmtCurrency.Enabled = False
            txt_Hdr_OrgClaimAmt.Enabled = False
            txt_Hdr_FinalClaimAmt.Enabled = False
            txt_Hdr_ClaimToInsAmt.Enabled = False
            txt_Hdr_ClaimToVNAmt.Enabled = False
            txt_Hdr_ClaimToHKOAmt.Enabled = False

            mmdDelete.Enabled = False

            mmdDelRow.Enabled = False



            Me.btcCLM00001.TabPages(0).Enabled = True
            Me.btcCLM00001.TabPages(1).Enabled = True
            Me.btcCLM00001.TabPages(2).Enabled = True
            Me.btcCLM00001.TabPages(3).Enabled = True

            cmd_close.Enabled = False
            txt_Dtl_Rmk.Enabled = False
            'dgSummary.Enabled = False

            cboClaimPeriod.Enabled = False
            txtClaimPeriod.Enabled = False
            cboClaimSts.Enabled = False

            gbClaimBy.Enabled = False
            rbClaimBy_C.Enabled = False
            rbClaimBy_V.Enabled = False
            rbClaimBy_U.Enabled = False

            cboPriCust.Enabled = False
            cboSecCust.Enabled = False
            cboVendor.Enabled = False

            rbClaimAmtPer_C.Enabled = False
            rbClaimAmtPer_I.Enabled = False
            rbClaimAmtPer_S.Enabled = False

            cboClaimType.Enabled = False
            txtSalesManager.Enabled = False
            txtSalesTeam.Enabled = False

            'txt_Hdr_Rmk.Enabled = False     

            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) <> "HAH" Then
                txt_Hdr_Rmk.Enabled = True
                txt_Hdr_Rmk.ReadOnly = True
                txt_Hdr_CustComment.Enabled = True
                txt_Hdr_CustComment.ReadOnly = True
                txt_Hdr_Finding.Enabled = True
                txt_Hdr_Finding.ReadOnly = True
            Else
                txt_Hdr_Rmk.Enabled = False
                txt_Hdr_Finding.Enabled = False
                txt_Hdr_CustComment.Enabled = False
            End If


            cbo_Hdr_ClaimAmtCurrency.Enabled = False
            txt_Hdr_OrgClaimAmt.Enabled = False
            txt_Hdr_FinalClaimAmt.Enabled = False

            cbo_Hdr_ClaimToInsAmtCurrency.Enabled = False
            txt_Hdr_ClaimToInsAmt.Enabled = False
            cbo_Hdr_ClaimToVNAmtCurrency.Enabled = False
            txt_Hdr_ClaimToVNAmt.Enabled = False
            cbo_Hdr_ClaimToHKOAmtCurrency.Enabled = False
            txt_Hdr_ClaimToHKOAmt.Enabled = False


            'cboClaimPaySTS.Enabled = False
            gb_pay.Enabled = False
            gb_income.Enabled = False

            'dtHDRPAIDDAT.Enabled = False
            'cboSETTLE_CUS.Enabled = False
            'cboSETTLE_FTY.Enabled = False
            'cboAPRVSTS.Enabled = False

            mmdInsRow.Enabled = False

            mmdSave.Enabled = False
            chkapv1a.Enabled = False

            chkCancel.Enabled = False

            mmdPrint.Enabled = True
        End If
        '' Cursor = Cursors.Default
    End Sub


    Private Sub fill_CAORDHDR()

        If rs_CAORDHDR.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        If rs_CAORDHDR.Tables("RESULT").Rows.Count = 0 Then
            rs_CAORDHDR.Tables("RESULT").Rows.Add()
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~"
        End If


        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cocde") = ""
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordno") = txtClaimNo.Text
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = Split(cboClaimSts.Text, " - ")(0)
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claPeriod") = txtClaimPeriod.Text
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_season") = cboSeason.Text.Trim



        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_clasearchby") = nHdrSearchBy

        If rbClaimBy_C.Checked = True Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claby") = "C"
        ElseIf rbClaimBy_V.Checked = True Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claby") = "V"
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claby") = "U"
        End If

        If cboPriCust.Text = "" Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus1no") = ""
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus1no") = Split(cboPriCust.Text, " - ")(0)
        End If

        If cboSecCust.Text = "" Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus2no") = ""
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus2no") = Split(cboSecCust.Text, " - ")(0)
        End If

        If cboVendor.Text = "" Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_venno") = ""
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_venno") = Split(cboVendor.Text, " - ")(0)
        End If

        If rbClaimAmtPer_C.Checked Then
            sHdrClaimAmtPer = "C"
        ElseIf rbClaimAmtPer_I.Checked Then
            sHdrClaimAmtPer = "I"
        Else
            sHdrClaimAmtPer = "S"
        End If

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_per") = sHdrClaimAmtPer



        'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cocde") = cboCoCde.Text
        'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordno") =
        'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") =
        'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claby") =
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus1no") = Me.cboPriCust.Text.Trim
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cus2no") = Me.cboSecCust.Text.Trim
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_venno") = Me.cboVendor.Text.Trim
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_clatyp") = Trim(Split(cboClaimType.Text, " - ")(0))
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_rmk") = txt_Hdr_Rmk.Text.Trim
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_custcomment") = txt_Hdr_CustComment.Text.Trim
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_finding") = txt_Hdr_Finding.Text.Trim
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salcur") = ""
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salttlamt") = 0
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_grspftamt") = 0
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtamt") = 0
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_calmtper") = 0
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cacur") = cbo_Hdr_ClaimAmtCurrency.Text.Trim
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_org") = Val(txt_Hdr_OrgClaimAmt.Text.Trim)
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caamt_final") = Val(txt_Hdr_FinalClaimAmt.Text.Trim)
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app1flg") = ""
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app1flgby") = ""
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app1flgdat") = "01/01/1900"
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoinscur") = cbo_Hdr_ClaimToInsAmtCur.Text.Trim
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catoinsamt") = Val(txt_Hdr_ClaimToInsAmt.Text.Trim)
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catohkocur") = cbo_Hdr_ClaimToHKOAmtCur.Text.Trim
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catohkoamt") = Val(txt_Hdr_ClaimToHKOAmt.Text.Trim)
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app2flg") = ""
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app2flgby") = ""
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_app2flgdat") = "01/01/1900"
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_curexrat") = "1"
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_curexeffdat") = rs_SYCUREX.Tables("RESULT").Rows(0).Item("yce_effdat")
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = gsUsrID
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_updusr") = gsUsrID
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_credat") = Format(Today.Date, "MM/dd/yyyy")
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_upddat") = Format(Today.Date, "MM/dd/yyyy")
        ''rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_timstp") =
        'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_claPeriod") =
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAREMAMT") = 0
        'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAAMT_PER") =
        'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CLASEARCHBY") =
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CATOVNCUR") = cbo_Hdr_ClaimToVNAmtCur.Text.Trim
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CATOVNAMT") = Val(txt_Hdr_ClaimToVNAmt.Text.Trim)
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salesmanger") = txtSalesManager.Text.Trim
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_salesteam") = txtSalesTeam.Text.Trim

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_PAYSTS") = cboClaimPaySTS.Text.Trim
        If IsDate(dtHDRPAIDDAT.Text.Trim) Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_PAIDDAT") = dtHDRPAIDDAT.Text.Trim
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_PAIDDAT") = "1900-01-01"
        End If
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_SETTLE_CUS") = cboSETTLE_CUS.Text.Trim


        If IsDate(dtHDRRCVDAT.Text.Trim) Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_RCVDAT") = dtHDRRCVDAT.Text.Trim
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_RCVDAT") = "1900-01-01"
        End If

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_SETTLE_CUS") = cboSETTLE_CUS.Text.Trim

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_SETTLE_FTY") = cboSETTLE_FTY.Text.Trim
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_APRVSTS") = cboAPRVSTS.Text.Trim
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_FA_LSTUPDDAT") = "01/01/1900"

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_reason") = txtreason.Text.Trim

        If chkconfirmclm.Checked = True Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_confclm") = "Y"
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_confclm") = "N"
        End If

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_acct_caamt_final") = Val(txt_Hdr_AcctClaimAmt.Text)

        '''
        If chkconfirmclm.Checked = True And chkvalidclm.Checked = True Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pot_val") = "A"
        ElseIf chkconfirmclm.Checked = True Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pot_val") = "P"
        ElseIf chkvalidclm.Checked = True Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pot_val") = "V"
        End If
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_ref_no") = txt_ref_no.Text.Trim
        If dt_ref_date.Text.Trim = "" Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_ref_dat") = "01/01/1900"
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_ref_dat") = dt_ref_date.Text.Trim
        End If

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = txt_stschg_usr.Text.Trim

        If txt_stschg_date.Text.Trim = "" Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = "01/01/1900"
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = txt_stschg_date.Text.Trim
        End If

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cmt_a") = txt_cmt_a.Text
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_cmt_b") = txt_cmt_b.Text

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_actamt") = Val(txt_pay_actamt.Text)
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_actamt") = Val(txt_income_actamt.Text)
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_potamt") = Val(txt_pay_potamt.Text)
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_potamt") = Val(txt_income_potamt.Text)

        'If Not IsDate(txt_pay_upddat.Text.Trim) And _
        ' rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_upddat") = "01/01/1900" _
        'Then
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_upddat") = "01/01/1900"
        'Else
        '    'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_upddat") = txt_pay_upddat.Text
        'End If

        'If Not IsDate(txt_income_upddat.Text.Trim) And _
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_upddat") = "01/01/1900" _
        '     Then
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_upddat") = "01/01/1900"
        'Else
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_upddat") = txt_income_upddat.Text.Trim
        'End If

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_INCOMESTS") = cboClaimIncomeSTS.Text.Trim

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_ClaimToInsAmt_ori") = Val(txt_Hdr_ClaimToInsAmt_ori.Text.Trim)
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_ClaimToVNAmt_ori") = Val(txt_Hdr_ClaimToVNAmt_ori.Text.Trim)
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_ClaimToHKOAmt_ori") = Val(txt_Hdr_ClaimToHKOAmt_ori.Text.Trim)


        If chkreplace.Checked = True Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_replace") = "Y"
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_replace") = "N"
        End If

        If chkapv3b.Checked = True Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = "APV3b"
        ElseIf chkapv2b.Checked = True Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = "APV2b"
        ElseIf chkapv1b.Checked = True Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = "APV1b"
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = ""
        End If

        If chkapv3a.Checked = True Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a") = "APV3a"
        ElseIf chkapv2a.Checked = True Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a") = "APV2a"
        ElseIf chkapv1a.Checked = True Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a") = "APV1a"
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a") = ""
        End If

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_rmk") = txt_pay_rmk.Text
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_rmk") = txt_income_rmk.Text

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_cur") = cbo_income_cur.Text
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_cur") = cbo_pay_cur.Text

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_rplno") = txtReplaceClaimNo.Text.Trim


    End Sub

    Public Sub fill_CAORDDTL()
        If Not rs_CAORDDTL.Tables("RESULT").Rows.Count > 0 Then
            Exit Sub
        End If
        If sReadingIndexQ_ship > rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 Then
            Exit Sub
        End If
        '''        sReadingIndexQ_ship = 0

        If txtItmNo.Text.Trim = "" Then
            Exit Sub
        End If
        If txtShipNo.Text.Trim = "" Then
            Exit Sub
        End If

        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_cocde") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_caordno") = txtClaimNo.Text.Trim
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_caordseq") = lblSeq.Text.Trim
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_clatyp") = Trim(Split(cboClaimType.Text, " - ")(0))
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_txcocde") = txtCoCde.Text.Trim  ''' company code may be diff by input
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_scordno") = txtSCNo.Text.Trim
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_scordseq") = Val(txtSCSeq.Text.Trim)
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_popurord") = txtPONo.Text.Trim
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_popurseq") = Val(txtPOSeq.Text.Trim)
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_pojobord") = txtJobNo.Text.Trim
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_shinvno") = txtInvNo.Text.Trim
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_sccuspono") = txtCusPONo.Text.Trim
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_shissdat") = IIf(Not (IsDate(txtInvIssDat.Text.Trim)), "01/01/1900", txtInvIssDat.Text.Trim)
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_shetddat") = IIf(Not (IsDate(txtInvETDDat.Text.Trim)), "01/01/1900", txtInvETDDat.Text.Trim)
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_shetadat") = IIf(Not (IsDate(txtInvETADat.Text.Trim)), "01/01/1900", txtInvETADat.Text.Trim)
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_itmno") = txtItmNo.Text.Trim
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_cusitm") = txtCustItmNo.Text.Trim
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_cusstyno") = txtCustStyNo.Text.Trim
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_venitm") = txtVenItmNo.Text.Trim
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_itmdsc") = txtItmDsc.Text.Trim
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_prdven") = txtPV.Text.Trim
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_ventyp") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_sccurcde") = txtSelPrcCurrency.Text.Trim
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_scnetuntprc") = Val(txtSelPrc.Text.Trim)
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_scfcurcde") = txtItmCstCurrency.Text.Trim
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_scftyprc") = Val(txtItmCst.Text.Trim)
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_scpckunt") = txtOrdQtyUM.Text.Trim
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_scordqty") = Val(txtOrdQty.Text.Trim)
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_scshpqty") = Val(txtShipQty.Text.Trim)
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_caqty") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_caqty_final") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_rmk") = txt_Dtl_Rmk.Text.Trim
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_salcur") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_salamt") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_grspftamt") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_calmtamt") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_calmtper") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_cacur") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_caqtyamt_org") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_caqtyamt_final") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_caamt_org") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_caamt_final") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_ttlcaamt_org") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_ttlcaamt_final") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_cavsgrspft") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_app1flg") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_app1flgby") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_app1flgdat") = "01/01/900"
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_catoinscur") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_catoinsamt") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_catovncur") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_catovnamt") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_catohkocur") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_catohkoamt") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_app2flg") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_app2flgby") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_app2flgdat") = "01/01/1900"
        'rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_creusr") = gsUsrID
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_updusr") = gsUsrID
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_credat") = "01/01/1900"
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_upddat") = "01/01/1900"
        'rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_timstp") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_DEL") = IIf(chkDelete.Checked = True, "Y", "N")
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_SHPNO") = txtShipNo.Text.Trim
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_SHPSEQ") = Val(txtShipSeq.Text.Trim)
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_SCUNTCDE") = txtShipQtyUM.Text.Trim
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_CAREMAMT") = 0
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_itmnoven") = txtVenItmNo.Text.Trim
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_alscolcde") = ""
        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_untcde") = ""



    End Sub

    Public Sub fill_CAORDITM()
        If Not rs_CAORDITM.Tables("RESULT").Rows.Count > 0 Then
            Exit Sub
        End If
        'sReadingIndexQ_Item = 0

        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_cocde") = ""
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_caordno") = txtClaimNo.Text.Trim
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_caordseq") = lblSeq.Text.Trim
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_clatyp") = Trim(Split(cboClaimType.Text, " - ")(0))
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_txcocde") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_scordno") = txtSCNo.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_scordseq") = txtSCSeq.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_popurord") = txtPONo.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_popurseq") = txtPOSeq.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_pojobord") = txtJobNo.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_shinvno") = txtInvNo.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_sccuspono") = txtCusPONo.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_shissdat") = txtInvIssDat.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_shetddat") = txtInvETDDat.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_shetadat") = txtInvETADat.Text.Trim
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_itmno") = txtItmNo.Text.Trim
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_cusitm") = txtCustItmNo.Text.Trim
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_cusstyno") = txtCustStyNo.Text.Trim
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_venitm") = txtVenItmNo.Text.Trim
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_itmdsc") = txtItmDsc.Text.Trim
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_prdven") = txtPV.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_ventyp") = lblVentyp.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_sccurcde") = txtSelPrcCurrency.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_scnetuntprc") = txtSelPrc.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_scfcurcde") = txtItmCstCurrency.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_scftyprc") = txtItmCst.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_scpckunt") = txtOrdQtyUM.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_scordqty") = txtOrdQty.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_scshpqty") = txtShipQty.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_caqty") = txt_Dtl_OrgClaimQty.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_caqty_final") = txt_Dtl_FinalClaimQty.Text.Trim
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_rmk") = txt_Dtl_Rmk.Text.Trim
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_salcur") = ""
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_salamt") = 0
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_grspftamt") = 0
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_calmtamt") = 0
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_calmtper") = 0
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_cacur") = ""
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_caqtyamt_org") = 0
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_caqtyamt_final") = 0
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_caamt_org") = 0
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_caamt_final") = 0
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_ttlcaamt_org") = 0
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_ttlcaamt_final") = 0
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_cavsgrspft") = 0
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_app1flg") = ""
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_app1flgby") = ""
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_app1flgdat") = "01/01/1900"
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_catoinscur") = ""
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_catoinsamt") = 0
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_catovncur") = ""
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_catovnamt") = 0
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_catohkocur") = ""
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_catohkoamt") = 0
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_app2flg") = ""
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_app2flgby") = ""
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_app2flgdat") = "01/01/1900"
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_creusr") = gsUsrID
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_updusr") = gsUsrID
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_credat") = "01/01/1900"
        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_upddat") = "01/01/1900"
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_timstp") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_DEL") = IIf(cbDel.Checked = True, "Y", "N")
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_SHPNO") = txtShipNo.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_SHPSEQ") = Val(txtShipSeq.Text.Trim)
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_SCUNTCDE") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_CAREMAMT") = 0
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_itmnoven") = txtVenItmNo.Text.Trim
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_alscolcde") = ""
        'rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_untcde") = ""



    End Sub



    Private Sub mmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click
        '''
        If checkFocus(Me) Then Exit Sub
        Dim newseq As Integer
        If btcCLM00001.SelectedIndex = 0 Then
            MsgBox("Please delete row in detail/summary page!")
            Exit Sub
        End If


        If rbViewOn_S.Checked = True Then
            If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
                Exit Sub
            End If

            If rs_CAORDDTL.Tables("RESULT").Rows.Count = 0 Then
                Exit Sub
            End If

            If rs_CAORDDTL.Tables("RESULT").Rows.Count = 1 Then
                MsgBox("This Claim  just has one detail line record only, cannot delete.")
                Exit Sub
            End If

            If rs_CAORDDTL.Tables("RESULT").Rows.Count > sReadingIndexQ_ship Then
                If chkDelete.Checked = False Then
                    chkDelete.Checked = True
                    rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_Del") = "Y"
                    Call Delete_itm_from_dtl(sReadingIndexQ_ship)
                Else
                    chkDelete.Checked = False
                    rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("cad_Del") = "N"
                    Call UNDelete_itm_from_dtl(sReadingIndexQ_ship)
                End If
            End If
            Recordstatus = True
            '''Call DeleteClickCheck()
            newseq = rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("CAD_CAORDSEQ")
            Call display_CAORDDTL(newseq)

        Else
            '''
            If rs_CAORDITM.Tables("RESULT") Is Nothing Then
                Exit Sub
            End If

            If rs_CAORDITM.Tables("RESULT").Rows.Count = 0 Then
                Exit Sub
            End If

            If rs_CAORDITM.Tables("RESULT").Rows.Count = 1 Then
                MsgBox("This Claim  just has one detail line record only, cannot delete.")
                Exit Sub
            End If

            If rs_CAORDITM.Tables("RESULT").Rows.Count > sReadingIndexQ_Item Then
                If chkDelete.Checked = False Then
                    chkDelete.Checked = True
                    rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_Del") = "Y"
                    Call Delete_dtl_from_itm(sReadingIndexQ_Item)
                Else
                    chkDelete.Checked = False
                    rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item)("cai_Del") = "N"
                    Call UNDelete_dtl_from_itm(sReadingIndexQ_Item)
                End If
            End If
            Recordstatus = True

            newseq = rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("cai_CAORDSEQ")
            Call display_CAORDITM(newseq)

        End If


    End Sub

    Private Sub cboSecCust_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSecCust.SelectedIndexChanged

    End Sub


    Private Sub mmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSearch.Click
        If checkFocus(Me) Then Exit Sub
        Dim frmSYM00018 As New SYM00018


        '20130909  
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)


        frmSYM00018.keyName = txtClaimNo.Name
        frmSYM00018.strModule = "CL"

        frmSYM00018.show_frmSYM00018(Me)



    End Sub

    Private Sub txtSalesTeam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalesTeam.TextChanged

    End Sub



    Private Sub txt_Hdr_Finding_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'txt_ref_no.Focus()
        'txt_ref_no.Focus()
    End Sub

    Private Sub txt_Hdr_Finding_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub tpCLM00001_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpCLM00001_3.Click

    End Sub

    Private Sub txtOrdQtyUM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrdQtyUM.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtCoCde_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCoCde.TextChanged

        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If

        '''0811 


        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtItmNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmNo.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtShipNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShipNo.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtShipSeq_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShipSeq.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtPV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPV.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtSCNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSCNo.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtSCSeq_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSCSeq.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtCustItmNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustItmNo.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtPONo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPONo.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtPOSeq_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPOSeq.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtCustStyNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustStyNo.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtJobNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJobNo.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtVenItmNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVenItmNo.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtInvNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvNo.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtCusPONo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCusPONo.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtOrdQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrdQty.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtShipQtyUM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShipQtyUM.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtShipQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShipQty.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtInvIssDat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvIssDat.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtSelPrcCurrency_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSelPrcCurrency.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If


    End Sub

    Private Sub txtSelPrc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSelPrc.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtInvETDDat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvETDDat.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtItmCstCurrency_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmCstCurrency.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtItmCst_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmCst.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtInvETADat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvETADat.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtItmDsc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmDsc.TextChanged
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txt_Dtl_Rmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Dtl_Rmk.TextChanged


        If rbViewOn_I.Checked Then
            If rs_CAORDITM.Tables("RESULT") Is Nothing Then
                Exit Sub
            End If
            If rs_CAORDITM.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_Item Then
                Exit Sub
            End If
            If rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("cai_creusr") = "~*ADD*~" Or rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("cai_creusr") = "~*NEW*~" Then
                rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("cai_creusr") = "~*ADD*~"
            Else
                '''1122
                rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("cai_creusr") = "~*UPD*~"
            End If
        Else
            If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
                Exit Sub
            End If
            If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
                Exit Sub
            End If
            If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
                rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
            Else
                '''1122
                rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
            End If
        End If



    End Sub

    Private Sub txtClaimQtyUM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txt_Dtl_OrgClaimQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txt_Dtl_FinalClaimQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub cbo_Dtl_ClaimQtyAmtCurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txt_Dtl_OrgClaimQtyAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txt_Dtl_FinalClaimQtyAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txt_Dtl_OrgClaimAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txt_Dtl_FinalClaimAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub cbo_Dtl_ClaimTtlAmtCurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txt_Dtl_OrgClaimTtlAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txt_Dtl_FinalClaimTtlAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub cb_Dtl_APV1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub cbo_Dtl_ClaimToInsAmtCurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txt_Dtl_ClaimToInsAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cbo_Dtl_ClaimToVNAmtCurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txt_Dtl_ClaimToVNAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cbo_Dtl_ClaimToHKOAmtCurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txt_Dtl_ClaimToHKOAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub cb_Dtl_APV2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
            Exit Sub
        End If
        If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        Else
            '''1122
            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        End If

    End Sub

    'Private Sub cboClaimType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClaimType.SelectedIndexChanged

    '        Call check_aprv_rights()

    'End Sub
    Private Function check_aprv_rights() As Integer

        'check user dept
        If gsUsrRank < 2 Then
            Return 1
            Exit Function
        End If

        If gsUsrRank > 5 Then
            Return 0
            Exit Function
        End If

        ''' user access right control
        '''  
        If Not (Microsoft.VisualBasic.Left(get_usr_dept(), 3) = "SAL" _
            Or Microsoft.VisualBasic.Left(get_usr_dept(), 3) = "SHP") _
            Then                                                                            ''' OR SZ
            Return 0
            Exit Function
        End If

        '''sp
        Dim p_a As String
        Dim p_b As String
        Dim p_c As String

        p_a = Split(cboClaimType.Text, " - ")(0).ToString
        p_b = Microsoft.VisualBasic.Left(get_usr_dept(), 3)
        p_c = txt_Hdr_OrgClaimAmt.Text.ToString

        gspStr = "sp_select_CACUSLMT '','" & p_a & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CACUSLMT, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_CUBASINF :" & rtnStr)
            Exit Function
        End If

        If rs_CACUSLMT.Tables("result").Rows.Count = 0 Then
            Return 0
            Exit Function
        Else
            For j As Integer = 0 To rs_CACUSLMT.Tables("result").Rows.Count - 1
                If p_b = "SAL" Then
                    If rs_CACUSLMT.Tables("result").Rows(j).Item("ccl_SM_flag") = "Y" _
                    And p_c <= Val(rs_CACUSLMT.Tables("result").Rows(j).Item("ccl_calmt")) _
                    Then
                        Return 1
                        Exit Function
                    End If
                    If rs_CACUSLMT.Tables("result").Rows(j).Item("ccl_SM_flag") = "Y" _
                    And p_c > Val(rs_CACUSLMT.Tables("result").Rows(j).Item("ccl_calmt")) _
                    Then
                        Return 2
                        Exit Function
                    End If
                End If

                If p_b = "SHP" Then
                    If rs_CACUSLMT.Tables("result").Rows(j).Item("ccl_SH_flag") = "Y" _
                    And p_c <= Val(rs_CACUSLMT.Tables("result").Rows(j).Item("ccl_calmt")) _
                    Then
                        Return 1
                        Exit Function
                    End If
                End If
                If p_b = "SHP" Then
                    If rs_CACUSLMT.Tables("result").Rows(j).Item("ccl_SH_flag") = "Y" _
                    And p_c > Val(rs_CACUSLMT.Tables("result").Rows(j).Item("ccl_calmt")) _
                    Then
                        Return 2
                        Exit Function
                    End If
                End If
            Next

            Return 0

        End If

        'lmt checking
        'dept,,,,,, lmt

    End Function

    Private Sub fillcus1no()
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_CUBASINF_PC '" & cboCoCde.Text & "','" & gsUsrID & "','" & sMODULE & "','Primary'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        gspStr = ""

        '''''' Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading fillParameter sp_select_CUBASINF_PC :" & rtnStr)
            Exit Sub
        End If

        If rs_CUBASINF_P.Tables("RESULT").Rows.Count > 0 Then
            cboPriCust.Items.Clear()
            cboPriCust.Text = ""

            'If Add_flag = True Then
            dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno >= '50000'")
            'End If

            If Not dr Is Nothing Then
                If dr.Length > 0 Then
                    For index As Integer = 0 To dr.Length - 1
                        cboPriCust.Items.Add(dr(index)("cbi_cusno") + " - " + dr(index)("cbi_cussna"))
                    Next index
                End If
            End If
        Else
            'MsgBox("There is no function, please contact EDP or System Administrator.")
            Exit Sub
        End If

    End Sub

    Private Function get_usr_dept() As String
        For i As Integer = 0 To rs_usr.Tables("result").Rows.Count - 1
            If rs_usr.Tables("result").Rows(i).Item("yup_usrid") = gsUsrID Then
                'Return rs_usr.Tables("result").Rows(i).Item("yup_usrgrp")
                '??? 20140522
                Return rs_usr.Tables("result").Rows(i).Item("yuC_usrgrp")
                Exit Function
            End If
        Next
        Return ""
    End Function


    Private Sub txt_Hdr_OrgClaimAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Hdr_OrgClaimAmt.TextChanged
        If mode = cModeRead Then
            Exit Sub
        End If
        If flag_keypress_txt_Hdr_OrgClaimAmt = True Then
            flag_keypress_txt_Hdr_OrgClaimAmt = False
            Call cal_office_amt_ori()

        End If
        'Dim get_aprv_right As Integer
        'get_aprv_right = check_aprv_rights()

        'If get_aprv_right = 1 Then
        '    chkapv1a.Enabled = True
        '    cmd_Hdr_Apv1.Visible = True
        'Else
        '    chkapv1a.Enabled = False
        '    cmd_Hdr_Apv1.Visible = False
        'End If

        'If get_aprv_right = 2 Then
        '    lbl_Hdr_ExceedAppLmt.Visible = True
        'Else
        '    lbl_Hdr_ExceedAppLmt.Visible = False
        'End If
        show_org_dif()

    End Sub

    Private Sub txtClaimNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClaimNo.TextChanged

    End Sub

    Public Sub set_clamitype()

        If rbClaimBy_C.Checked = True Then
            format_cboClaimType("C")
        ElseIf rbClaimBy_V.Checked = True Then
            format_cboClaimType("V")
        Else
            format_cboClaimType("U")
        End If

    End Sub

    Private Sub lblSeason_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSeason.Click

    End Sub

    Private Sub lblClaimStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClaimStatus.Click

    End Sub

    Private Sub lblClaimNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClaimNo.Click

    End Sub

    Private Sub lblClaimPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClaimPeriod.Click

    End Sub

    Private Sub SetHdrSeason()
        rs_Season.Tables.Clear()

        '' Cursor = Cursors.WaitCursor

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_SYSETINF '" & cboCoCde.Text & "','19'"
        rtnLong = execute_SQLStatement(gspStr, rs_Season, rtnStr)
        gspStr = ""

        '' Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SetHdrSeason sp_select_SYSETINF :" & rtnStr)
            '' Cursor = Cursors.Default
            Exit Sub
        End If

        cboSeason.Items.Clear()
        cboSeason.Text = ""
        cboSeason.Items.Add("")
        'cboSeason.Items.Add("Prior years claim (< Mar 2013)")
        'cboSeason.Items.Add("Spring / Summer & Everyday 2013")
        'cboSeason.Items.Add("Fall & Halloween 2013")
        'cboSeason.Items.Add("Christmas 2013")
        'cboSeason.Items.Add("Spring / Summer & Everyday 2014")


        If rs_Season.Tables("RESULT").Rows.Count > 0 Then
            For index As Integer = 0 To rs_Season.Tables("RESULT").Rows.Count - 1
                cboSeason.Items.Add(rs_Season.Tables("RESULT").Rows(index)("ysi_dsc").ToString())
            Next
        End If
    End Sub

    Private Sub cboSeason_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSeason.KeyPress
        Me.gbClaimBy.Enabled = True

        Me.rbClaimBy_C.Enabled = True
        Me.rbClaimBy_V.Enabled = True
        Me.rbClaimBy_U.Enabled = True
        Me.rbClaimBy_C.Checked = False
        cboSeason.Enabled = False
        cboPriCust.Enabled = False


        cboPriCust.Text = ""


    End Sub

    Private Sub cboSeason_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSeason.LostFocus
        Me.gbClaimBy.Enabled = True

        Me.rbClaimBy_C.Enabled = True
        Me.rbClaimBy_V.Enabled = True
        Me.rbClaimBy_U.Enabled = True
        Me.rbClaimBy_C.Checked = False
        cboSeason.Enabled = False
        cboPriCust.Enabled = False


        cboPriCust.Text = ""

    End Sub

    Private Sub cboSeason_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSeason.SelectedIndexChanged

    End Sub

    Private Sub txt_Hdr_ClaimToInsAmt_RightToLeftChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Hdr_ClaimToInsAmt.RightToLeftChanged

    End Sub

    Private Sub txt_Hdr_ClaimToInsAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Hdr_ClaimToInsAmt.TextChanged

        If flag_keypress_txt_Hdr_ClaimToInsAmt = True Then
            flag_keypress_txt_Hdr_ClaimToInsAmt = False

            Call cal_office_amt2()

            show_final_dif()

        End If

    End Sub

    Private Sub chkClose_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'If chkClose.Checked = True Then
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "CLOS"
        'Else
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "APV1b"
        'End If

        'display_combo(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts"), cboClaimSts)


        'If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
        '    rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~"
        'Else
        '    '''1122
        '    rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        'End If


    End Sub

    Private Sub chkCancel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCancel.CheckedChanged

    End Sub

    Private Sub txt_Hdr_ClaimToVNAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Hdr_ClaimToVNAmt.TextChanged


        If flag_keypress_txt_Hdr_ClaimToVNAmt = True Then
            flag_keypress_txt_Hdr_ClaimToVNAmt = False
            Call cal_office_amt()

        End If
        show_final_dif()
    End Sub

    Private Sub txt_Hdr_ClaimToHKOAmt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Hdr_ClaimToHKOAmt.LostFocus

        'txt_Hdr_FinalClaimAmt.Focus()



    End Sub

    Private Sub txt_Hdr_ClaimToHKOAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Hdr_ClaimToHKOAmt.TextChanged
        show_final_dif()
        If Val(txt_Hdr_ClaimToHKOAmt.Text) < 0 Then
            MsgBox("HK Office Amount must be greater than 0.")
            txt_Hdr_ClaimToHKOAmt.Text = "0"
        End If

    End Sub
    Public Sub set_APVS()

        txt_Hdr_ClaimToInsAmt.Enabled = False
        txt_Hdr_ClaimToVNAmt.Enabled = False
        txt_Hdr_ClaimToHKOAmt.Enabled = False


    End Sub

    Private Sub lblDiscntMaxP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub gbPanelCstEmt_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbPanelReason.Enter

    End Sub

    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtreason.TextChanged

    End Sub

    Private Sub cmdPanQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanQuit.Click

        'If txtreason.Text.Trim = "" Then
        '    MsgBox("Please input a reason!")
        '    Exit Sub
        'End If

        bIsShowPanels = False
        gbPanelReason.SendToBack()
        gbPanelReason.Visible = False

    End Sub

    Private Sub cmdPanOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanOK.Click
        If txtreason.Text.Trim = "" Then
            MsgBox("Please input a reason!")
            Exit Sub
        End If

        bIsShowPanels = False

        gbPanelReason.SendToBack()
        gbPanelReason.Visible = False
        '''add to database


        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_reason") = txtreason.Text.Trim

    End Sub

    Private Sub CmdViewReason_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdViewReason.Click

        '''panel
        txtreason.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_Reason")
        gbPanelReason.Location = New Point(139, 77)


        bIsShowPanels = True
        gbPanelReason.Visible = True
        gbPanelReason.BringToFront()
        '''



    End Sub

    Private Sub rbClaimBy_C_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbClaimBy_C.Click
        format_gbClaimBy_Add()
        If rbClaimBy_C.Checked = True Then
            format_cboClaimType("C")
        ElseIf rbClaimBy_V.Checked = True Then
            format_cboClaimType("V")
        Else
            format_cboClaimType("U")
        End If

    End Sub

    Public Sub save_click()

        If chkconfirmclm.Checked = False And chkvalidclm.Checked = False Then
            chkconfirmclm.Enabled = True
            chkvalidclm.Enabled = True
            MsgBox("Please choose potential/valid claim!")
            Exit Sub
        End If

        If Val(txt_Hdr_FinalClaimAmt.Text) = 0 And chkreplace.Checked = False And chkwait.Checked = True Then
            chkreplace.Enabled = True
            gbClaimAmtPer.Enabled = True
            MsgBox("When ready for approval, Finalized Amount should not be zero Or Replacement should be checked!")
            Exit Sub
        End If

        'Call final_lost_focus()
        'Call ori_lost_focus()
        'If not_allow_save = True Then
        '    MsgBox("Final Amount is less than the sum up!")
        '    Exit Sub
        'End If


        If chkwait.Checked = True And chkvalidclm.Checked = False Then
            chkwait.Enabled = True
            chkconfirmclm.Enabled = True
            chkvalidclm.Enabled = True

            MsgBox("Please choose valid claim for 'Ready for Approval'!")
            Exit Sub
        End If



        Me.Cursor = Cursors.WaitCursor

        If check_CAORDHDR_CAORDITM_CAORDDTL() = True Then
            Dim docno As String
            docno = ""

            Call fill_CAORDHDR()

            If btcCLM00001.SelectedIndex <> 2 Then
                If rbViewOn_I.Checked Then
                    Call fill_CAORDITM()
                Else
                    Call fill_CAORDDTL()
                End If
            End If

            If check_save() = False Then
                Exit Sub
            End If


            If save_CAORDHDR_CAORDITM_CAORDDTL(docno) = True Then
                Dim casechange As String
                casechange = ""

                If rs_CAORDHDR.Tables("RESULT").Rows.Count > 0 Then
                    casechange = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts").ToString
                End If
                mode = cModeSave
                Call setStatus(cModeSave)

                MsgBox("Record Saved! Claim No:" & docno)
                btcCLM00001.SelectedIndex = 0

                mode = cModeInit
                Call setStatus(cModeInit)
                mode = cModeInit
                'formInit(mode)
                Me.txtClaimNo.Text = docno
            End If
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub lblCustPONo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCustPONo.Click

    End Sub

    Private Sub txt_Hdr_FinalClaimAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Hdr_FinalClaimAmt.TextChanged
        If mode = cModeRead Then
            Exit Sub
        End If
        If flag_keypress_txt_Hdr_FinalClaimAmt = True Then
            flag_keypress_txt_Hdr_FinalClaimAmt = False
            '''            Call cal_office_amt()

            If cbo_Hdr_ClaimAmtCurrency.Text.Trim = "USD" Then
                If Val(txt_Hdr_FinalClaimAmt.Text) > 5000 Then
                    lbl_Hdr_ExceedAppLmt.Visible = True
                Else
                    lbl_Hdr_ExceedAppLmt.Visible = False
                End If
            Else
                If Val(txt_Hdr_FinalClaimAmt.Text) > 5000 * gl_rate Then
                    lbl_Hdr_ExceedAppLmt.Visible = True
                Else
                    lbl_Hdr_ExceedAppLmt.Visible = False
                End If
            End If



            txt_Hdr_ClaimToVNAmt.Text = ""
            txt_Hdr_ClaimToHKOAmt.Text = ""
            txt_Hdr_ClaimToVNAmt_ori.Text = ""
            txt_Hdr_ClaimToHKOAmt_ori.Text = ""
            txt_Hdr_ClaimToHKOAmt.Text = ""
            txt_Hdr_ClaimToHKOAmt_ori.Text = ""

            'If Val(txt_Hdr_FinalClaimAmt.Text) > 5000 Then
            '    lbl_Hdr_ExceedAppLmt.Visible = True
            'Else
            '    lbl_Hdr_ExceedAppLmt.Visible = False
            'End If

        End If
        'Dim get_aprv_right As Integer
        'get_aprv_right = check_aprv_rights()

        'If get_aprv_right = 1 Then
        '    chkapv1a.Enabled = True
        '    cmd_Hdr_Apv1.Visible = True
        'Else
        '    chkapv1a.Enabled = False
        '    cmd_Hdr_Apv1.Visible = False
        'End If

        'If get_aprv_right = 2 Then
        '    lbl_Hdr_ExceedAppLmt.Visible = True
        'Else
        '    lbl_Hdr_ExceedAppLmt.Visible = False
        'End If
        show_final_dif()
    End Sub
    Function cal_claim_to_total() As Boolean
        If Val(txt_Hdr_OrgClaimAmt.Text) = Val(txt_Hdr_ClaimToInsAmt.Text) + Val(txt_Hdr_ClaimToVNAmt.Text) + Val(txt_Hdr_ClaimToHKOAmt.Text) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub DeleteClickCheck()
        ''Dim qutseq As Integer

        ''If chkDelete.Checked = True Then
        ''    If rs_CAORDDTL.Tables.Count > 0 Then
        ''        If rs_CAORDDTL.Tables("RESULT").Rows.Count > 1 Then
        ''            ''empty item
        ''            If txtItmNo.Text = "" Then
        ''                '''***)using flag to indicate delete, instead of row delete
        ''                '''rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_Ship).Delete()
        ''                rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("Del") = "Y"
        ''                rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("qud_creusr") = "~*DEL*~"
        ''                rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("qpe_creusr") = "~*DEL*~"

        ''                If rs_CAORDDTL.Tables("RESULT").Rows.Count = 0 Then
        ''                    Call reset_QUOTNDTL()
        ''                    cmdBackD.Enabled = False
        ''                    cmdNextD.Enabled = False
        ''                Else
        ''                    ''
        ''                    sReadingIndexQ_ship = 0
        ''                    'Call Display_Detail()
        ''                    cmdBackD.Enabled = False
        ''                    cmdNextD.Enabled = True
        ''                    cboColCde.Enabled = False
        ''                    cboPcking.Enabled = False

        ''                    If txtItmNo.Enabled And txtItmNo.Visible Then txtItmNo.Focus()
        ''                End If

        ''                '''not empty item
        ''            Else
        ''                If Add_flag = True Or Insert_flag = True Then
        ''                    'not empty item??
        ''                    If txtItmNo.Text <> "" And txtItmNo.Enabled = True Then
        ''                        If not_exist_ITEM() = True Then
        ''                            '''***)using flag to indicate delete, instead of row delete
        ''                            '''  rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_Ship).Delete()
        ''                            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("Del") = "Y"
        ''                            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("qud_creusr") = "~*DEL*~"
        ''                            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("qpe_creusr") = "~*DEL*~"

        ''                            If rs_CAORDDTL.Tables("RESULT").Rows.Count = 0 Then
        ''                                Call reset_QUOTNDTL()
        ''                                cmdBackD.Enabled = False
        ''                                cmdNextD.Enabled = False
        ''                            Else
        ''                                sReadingIndexQ_ship = 0
        ''                                'Call Display_Detail()
        ''                                cmdBackD.Enabled = False
        ''                                cmdNextD.Enabled = True
        ''                                cboColCde.Enabled = False
        ''                                cboPcking.Enabled = False
        ''                                If txtItmNo.Enabled And txtItmNo.Visible Then txtItmNo.Focus()
        ''                            End If
        ''                            Exit Sub
        ''                        End If
        ''                    End If
        ''                End If

        ''                '*** check for Discontinued New Item
        ''                If Microsoft.VisualBasic.Left(txtQutSts.Text, 1) = "H" And _
        ''                    rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("qud_itmsts").ToString = "OLD" Then

        ''                    Dim rsIMBASINF As New DataSet

        ''                    '' Cursor = Cursors.WaitCursor

        ''                    gsCompany = Trim(cboCoCde.Text)
        ''                    Call Update_gs_Value(gsCompany)

        ''                    gspStr = "sp_select_IMBASINF_Q_Check_Dis '" & cboCoCde.Text & "','" & rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("qud_itmsts").ToString & "'"
        ''                    rtnLong = execute_SQLStatement(gspStr, rsIMBASINF, rtnStr)
        ''                    gspStr = ""

        ''                    '' Cursor = Cursors.Default

        ''                    If rtnLong <> RC_SUCCESS Then
        ''                        MsgBox("Error on loading DeleteClickCheck sp_select_IMBASINF_Q_Check_Dis :" & rtnStr)
        ''                        Exit Sub
        ''                    End If

        ''                    If rsIMBASINF.Tables("RESULT").Rows.Count > 0 Then
        ''                        Dim counter As Integer
        ''                        For counter = 0 To rsIMBASINF.Tables("RESULT").Rows.Count - 1
        ''                            If rsIMBASINF.Tables("RESULT").Rows(0)("ibi_itmsts") = "DIS" Then
        ''                                '''20130807 allow delete item chkDelete.Enabled = False
        ''                                cmdSave.Enabled = True
        ''                                Exit For
        ''                            End If
        ''                        Next
        ''                    End If
        ''                End If

        ''                Recordstatus = True
        ''            End If
        ''        ElseIf rs_CAORDDTL.Tables("RESULT").Rows.Count = 1 Then
        ''            rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship)("Del") = "N"
        ''            chkDelete.Checked = False

        ''            If flgRenewing = False Then
        ''                MsgBox("This Quotation just has one detail line record only, cannot delete.")
        ''            End If
        ''            If txtItmNo.Enabled And txtItmNo.Visible Then txtItmNo.Focus()
        ''            'Exit Sub
        ''        End If
        ''    End If

        ''    ''
        ''Else
        ''    rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("del") = "N"

        ''End If

        ''qutseq = rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("qud_qutseq")

        ''Call display_Detail(qutseq)

        ''If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("del") = "Y" Then
        ''    Exit Sub
        ''End If

    End Sub

    Private Sub chkDelete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDelete.CheckedChanged

    End Sub

    Private Sub dgSummary_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub lblOdrQty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblOdrQty.Click

    End Sub

    Private Sub lblShipQty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblShipQty.Click

    End Sub

    Private Sub dgSummary_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSummary.CellContentClick

    End Sub
    Sub Delete_dtl_from_itm(ByVal find_sReadingIndexQ_Item)

        Dim tmp_itmno As String
        tmp_itmno = rs_CAORDITM.Tables("RESULT").Rows(find_sReadingIndexQ_Item).Item("cai_itmno")

        For i As Integer = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
            If tmp_itmno = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_itmno") Then
                rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_del") = "Y"
                If rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_creusr") = "~*NEW*~" Then
                    rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_creusr") = "~*NEW*~"
                Else
                    rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_creusr") = "~*UPD*~"
                End If
            End If
        Next

    End Sub
    Sub UNDelete_dtl_from_itm(ByVal find_sReadingIndexQ_Item)

        Dim tmp_itmno As String
        tmp_itmno = rs_CAORDITM.Tables("RESULT").Rows(find_sReadingIndexQ_Item).Item("cai_itmno")

        For i As Integer = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
            If tmp_itmno = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_itmno") Then
                rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_del") = "N"
                If rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_creusr") = "~*NEW*~" Then
                    rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_creusr") = "~*NEW*~"
                Else
                    rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_creusr") = "~*UPD*~"
                End If
            End If
        Next

    End Sub
    Sub Delete_itm_from_dtl(ByVal find_sReadingIndexQ_Ship)

        Dim tmp_itmno As String
        Dim tmp_count As Integer
        tmp_itmno = rs_CAORDDTL.Tables("RESULT").Rows(find_sReadingIndexQ_Ship).Item("cad_itmno")
        tmp_count = 0

        For i As Integer = 0 To rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
            If tmp_itmno = rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_itmno") And _
                rs_CAORDDTL.Tables("RESULT").Rows(i).Item("cad_del") = "N" Then
                tmp_count = tmp_count + 1
            End If
        Next


        If tmp_count = 0 Then
            For i As Integer = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
                If tmp_itmno = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_itmno") Then
                    rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_del") = "Y"
                    If rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_creusr") = "~*ADD*~" Or rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_creusr") = "~*NEW*~" Then
                        rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_creusr") = "~*NEW*~"
                    Else
                        rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_creusr") = "~*UPD*~"
                    End If
                End If
            Next
        End If

    End Sub

    Sub UNDelete_itm_from_dtl(ByVal find_sReadingIndexQ_Ship)

        Dim tmp_itmno As String
        tmp_itmno = rs_CAORDDTL.Tables("RESULT").Rows(find_sReadingIndexQ_Ship).Item("cad_itmno")

        For i As Integer = 0 To rs_CAORDITM.Tables("RESULT").Rows.Count - 1
            If tmp_itmno = rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_itmno") Then
                rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_del") = "N"
                If rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_creusr") = "~*ADD*~" Or rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_creusr") = "~*NEW*~" Then
                    rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_creusr") = "~*NEW*~"
                Else
                    rs_CAORDITM.Tables("RESULT").Rows(i).Item("cai_creusr") = "~*UPD*~"
                End If
            End If
        Next

    End Sub

    Private Sub rbViewOn_S_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbViewOn_S.CheckedChanged
        Call rbViewOn_I_OR_S()
    End Sub

    Private Sub rbViewOn_S_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbViewOn_S.Click
        'Call rbViewOn_I_OR_S()
        'flag_rbViewOn_click = True

    End Sub
    Sub rbViewOn_I_OR_S()


        If flag_rbViewOn_click = True Then
            flag_rbViewOn_click = False
            '''prevent 2nd call
            '''20140219
            'gb_count_rbViewOn = Val(gb_count_rbViewOn) + 1
            'If gb_count_rbViewOn >= 2 Then
            '    gb_count_rbViewOn = 0
            '    Exit Sub
            'End If

            Call format_dgSummary()

            If mode = cModeAdd Or mode = cModeUpd Or mode = cModeRead Then
                If rbViewOn_I.Checked Then

                    Call fill_CAORDDTL()

                    'cbo_Dtl_ClaimType.Visible = False
                    'lbl_Dtl_AppLmtChkPer.Visible = False

                    Dim newseq As Integer
                    If sReadingIndexQ_Item > rs_CAORDITM.Tables("RESULT").Rows.Count - 1 Then
                        sReadingIndexQ_Item = rs_CAORDITM.Tables("RESULT").Rows.Count - 1
                        If sReadingIndexQ_Item < 0 Then
                            sReadingIndexQ_Item = 0
                        End If
                    End If
                    newseq = rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("cai_caordseq")
                    display_CAORDITM(newseq)

                    'format_Approval(newseq)

                    dgSummary.DataSource = rs_CAORDITM.Tables("RESULT").DefaultView
                    dgSummary.Refresh()
                    Call format_dgSummary()
                    Call format_dgSummary()
                    rs_CAORDITM.Tables("RESULT").AcceptChanges()

                    set_Back_Next_button()
                Else

                    Call fill_CAORDITM()

                    'cbo_Dtl_ClaimType.Enabled = False
                    'lbl_Dtl_AppLmtChkPer.Visible = False

                    Dim newseq As Integer
                    If sReadingIndexQ_ship > rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 Then
                        sReadingIndexQ_ship = rs_CAORDDTL.Tables("RESULT").Rows.Count - 1
                        If sReadingIndexQ_ship < 0 Then
                            sReadingIndexQ_ship = 0
                        End If
                    End If
                    newseq = rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("CAD_CAORDSEQ")

                    display_CAORDDTL(newseq)

                    'format_Approval(newseq)

                    dgSummary.DataSource = rs_CAORDDTL.Tables("RESULT").DefaultView
                    dgSummary.Refresh()
                    Call format_dgSummary()
                    Call format_dgSummary()
                    rs_CAORDDTL.Tables("RESULT").AcceptChanges()

                    set_Back_Next_button()
                End If
                'format_dgSummary()
            End If

            'If rbViewOn_I.Checked Then
            '    Previous_rbViewOn_I_Checked = True
            'Else
            '    Previous_rbViewOn_I_Checked = False
            'End If

        End If
    End Sub

    Private Sub rbViewOn_I_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbViewOn_I.CheckedChanged
        Call rbViewOn_I_OR_S()
    End Sub

    Private Sub rbViewOn_I_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbViewOn_I.Click
        'Call rbViewOn_I_OR_S()
        '        flag_rbViewOn_click = True

    End Sub

    Private Sub rbViewOn_S_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbViewOn_S.GotFocus
        flag_rbViewOn_click = True
    End Sub

    Private Sub rbViewOn_S_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rbViewOn_S.KeyDown
        ''flag_rbViewOn_click = True
    End Sub

    Private Sub rbViewOn_I_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbViewOn_I.GotFocus
        flag_rbViewOn_click = True
    End Sub

    Private Sub rbViewOn_I_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rbViewOn_I.KeyDown
        '                flag_rbViewOn_click = True
    End Sub

    Private Sub gb_Dtl_ClaimAmt_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_dgSummary_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        '''''''''''''''''''''''''''~*
        'If rbViewOn_I.Checked Then
        '    If rs_CAORDITM.Tables("RESULT") Is Nothing Then
        '        Exit Sub
        '    End If
        '    If rs_CAORDITM.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_Item Then
        '        Exit Sub
        '    End If
        '    If rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("cai_creusr") = "~*ADD*~" Or rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("cai_creusr") = "~*NEW*~" Then
        '        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("cai_creusr") = "~*ADD*~"
        '    Else
        '        '''1122
        '        rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("cai_creusr") = "~*UPD*~"
        '    End If
        'Else
        '    If rs_CAORDDTL.Tables("RESULT") Is Nothing Then
        '        Exit Sub
        '    End If
        '    If rs_CAORDDTL.Tables("RESULT").Rows.Count - 1 < sReadingIndexQ_ship Then
        '        Exit Sub
        '    End If
        '    If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
        '        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~"
        '    Else
        '        '''1122
        '        rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
        '    End If
        'End If


        ''''''''''''''''''''''''''''''''''''''''''display

        'Dim iRow As Integer = dgSummary.CurrentCell.RowIndex
        'Dim iCol As Integer = dgSummary.CurrentCell.ColumnIndex
        'Dim curvalue As String = dgSummary.CurrentCell.EditedFormattedValue
        'Dim i As Integer
        'Dim newseq As Integer

        ' '''
        'If rbViewOn_I.Checked Then
        '    If rs_CAORDITM.Tables("RESULT").Rows.Count > sReadingIndexQ_Item Then
        '        txt_Dtl_Rmk.Text = rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("CAI_RMK")
        '        newseq = rs_CAORDITM.Tables("RESULT").Rows(sReadingIndexQ_Item).Item("CAI_CAORDSEQ")
        '        Call display_CAORDITM(newseq)
        '    End If
        'Else
        '    If rs_CAORDDTL.Tables("RESULT").Rows.Count > sReadingIndexQ_ship Then
        '        txt_Dtl_Rmk.Text = rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("CAD_RMK")
        '        'newseq = rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("CAD_CAORDSEQ")
        '        'Call display_CAORDDTL(newseq)
        '    End If
        'End If



    End Sub

    Private Sub cboSeason_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboSeason.Validating

        Dim tmpstr As String
        tmpstr = cboSeason.Text

        If cboSeason.Items.IndexOf(tmpstr) = -1 _
        Or cboSeason.Items.IndexOf(tmpstr) = 0 Then
            MsgBox("Season - Data is Invalid, please select in Drop Down List.")
            e.Cancel = True
            cboSeason.Enabled = True
        Else
            cboSeason.Enabled = False
        End If




    End Sub


    Public Sub cal_office_amt()

        Dim temp_test As Decimal

        txt_Hdr_ClaimToInsAmt.ForeColor = Color.Black
        txt_Hdr_ClaimToVNAmt.ForeColor = Color.Black
        txt_Hdr_ClaimToHKOAmt.ForeColor = Color.Black

        If mode = cModeAdd Or mode = cModeUpd Then


            '            txt_Hdr_ClaimToHKOAmt.Text = Val(txt_Hdr_FinalClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text)
            If rbClaimBy_C.Checked = True Then

                cbo_Hdr_ClaimToHKOAmtCur.Text = cbo_Hdr_ClaimToVNAmtCur.Text

                Dim tmp_1i As Decimal
                Dim tmp_2i As Decimal
                Dim tmp_3i As Decimal
                Dim tmp_1o As Decimal
                Dim tmp_2o As Decimal
                Dim tmp_3o As Decimal
                Dim tmp_1c As String
                Dim tmp_2c As String
                Dim tmp_3c As String

                tmp_1i = Val(txt_Hdr_ClaimToInsAmt.Text)
                tmp_2i = Val(txt_Hdr_ClaimToVNAmt.Text)
                tmp_3i = Val(txt_Hdr_ClaimToHKOAmt.Text)

                tmp_1c = cbo_Hdr_ClaimToInsAmtCur.Text
                tmp_2c = cbo_Hdr_ClaimToVNAmtCur.Text
                tmp_3c = cbo_Hdr_ClaimToHKOAmtCur.Text

                tmp_1o = cal_cur_rate(tmp_1i, tmp_1c)
                tmp_2o = cal_cur_rate(tmp_2i, tmp_2c)
                tmp_3o = cal_cur_rate(tmp_3i, tmp_3c)

                temp_test = Val(txt_Hdr_FinalClaimAmt.Text) - tmp_2o
                If temp_test >= 0 Then
                    'txt_Hdr_ClaimToInsAmt.Text = ""
                    'txt_Hdr_ClaimToVNAmt.Text = ""
                    txt_Hdr_ClaimToHKOAmt.Text = round(cal_cur_rate2(temp_test, tmp_2c), 2)
                Else
                    txt_Hdr_ClaimToHKOAmt.Text = "0"
                End If

            End If
        End If
        'txt_Hdr_ClaimToHKOAmt.ForeColor = Color.Black
        'txt_Hdr_FinalClaimAmt.ForeColor = Color.Black
        'txt_Hdr_ClaimToInsAmt.ForeColor = Color.Black
        'txt_Hdr_ClaimToVNAmt.ForeColor = Color.Black

    End Sub
    Public Sub cal_office_amt2()
        Dim temp_test As Decimal
        txt_Hdr_ClaimToInsAmt.ForeColor = Color.Black
        txt_Hdr_ClaimToVNAmt.ForeColor = Color.Black
        txt_Hdr_ClaimToHKOAmt.ForeColor = Color.Black

        If mode = cModeAdd Or mode = cModeUpd Then
            Dim tmp_1i As Decimal
            Dim tmp_2i As Decimal
            Dim tmp_3i As Decimal
            Dim tmp_1o As Decimal
            Dim tmp_2o As Decimal
            Dim tmp_3o As Decimal
            Dim tmp_1c As String
            Dim tmp_2c As String
            Dim tmp_3c As String

            '            txt_Hdr_ClaimToHKOAmt.Text = Val(txt_Hdr_FinalClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text)
            If rbClaimBy_V.Checked = True Then
                cbo_Hdr_ClaimToHKOAmtCur.Text = cbo_Hdr_ClaimToInsAmtCur.Text

                tmp_1i = Val(txt_Hdr_ClaimToInsAmt.Text)
                tmp_2i = Val(txt_Hdr_ClaimToVNAmt.Text)
                tmp_3i = Val(txt_Hdr_ClaimToHKOAmt.Text)

                tmp_1c = cbo_Hdr_ClaimToInsAmtCur.Text
                tmp_2c = cbo_Hdr_ClaimToVNAmtCur.Text
                tmp_3c = cbo_Hdr_ClaimToHKOAmtCur.Text

                tmp_1o = cal_cur_rate(tmp_1i, tmp_1c)
                tmp_2o = cal_cur_rate(tmp_2i, tmp_2c)
                tmp_3o = cal_cur_rate(tmp_3i, tmp_3c)

                temp_test = Val(txt_Hdr_FinalClaimAmt.Text) - tmp_1o
                If temp_test >= 0 Then
                    'txt_Hdr_ClaimToInsAmt.Text = ""
                    'txt_Hdr_ClaimToVNAmt.Text = ""
                    txt_Hdr_ClaimToHKOAmt.Text = round(cal_cur_rate2(temp_test, tmp_1c), 2)
                Else
                    txt_Hdr_ClaimToHKOAmt.Text = "0"
                End If

            End If

            If rbClaimBy_U.Checked = True Then
                tmp_1i = Val(txt_Hdr_ClaimToInsAmt.Text)
                tmp_2i = Val(txt_Hdr_ClaimToVNAmt.Text)
                tmp_3i = Val(txt_Hdr_ClaimToHKOAmt.Text)

                tmp_1c = cbo_Hdr_ClaimToInsAmtCur.Text
                tmp_2c = cbo_Hdr_ClaimToVNAmtCur.Text
                tmp_3c = cbo_Hdr_ClaimToHKOAmtCur.Text

                tmp_1o = cal_cur_rate(tmp_1i, tmp_1c)
                tmp_2o = cal_cur_rate(tmp_2i, tmp_2c)
                tmp_3o = cal_cur_rate(tmp_3i, tmp_3c)


                temp_test = Val(txt_Hdr_FinalClaimAmt.Text) - tmp_1o
                If temp_test >= 0 Then
                    txt_Hdr_ClaimToVNAmt.Text = round(cal_cur_rate2(temp_test, tmp_2c), 2)
                    '                txt_Hdr_ClaimToHKOAmt.Text = temp_test
                Else
                    MsgBox("The sum of 'Finalized Customer  Amount' and  'Finalized Vendor Amount' should be equal to  'Finalized Claim Amount'!")
                    txt_Hdr_ClaimToVNAmt.Text = "0"
                    txt_Hdr_ClaimToInsAmt.Text = "0"

                End If

                'cbo_Hdr_ClaimToHKOAmtCur.Text = cbo_Hdr_ClaimToInsAmtCur.Text
            End If


            'txt_Hdr_ClaimToHKOAmt.ForeColor = Color.Black
            'txt_Hdr_FinalClaimAmt.ForeColor = Color.Black
            'txt_Hdr_ClaimToInsAmt.ForeColor = Color.Black
            'txt_Hdr_ClaimToVNAmt.ForeColor = Color.Black
        End If

    End Sub


    Public Sub cal_office_amt_ori()
        'If mode = cModeAdd Or mode = cModeUpd Then
        '    txt_Hdr_ClaimToHKOAmt_ori.Text = Val(txt_Hdr_OrgClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt_ori.Text) - Val(txt_Hdr_ClaimToVNAmt_ori.Text)
        '    If Val(txt_Hdr_ClaimToHKOAmt_ori.Text) < 0 Then
        '        MsgBox("'Customer Amount' + 'Vendor Amount' + 'HK Office Amount' should be equal to 'Original Claim Amount'.")
        '        txt_Hdr_ClaimToInsAmt_ori.Text = ""
        '        txt_Hdr_ClaimToVNAmt_ori.Text = ""
        '        txt_Hdr_ClaimToHKOAmt_ori.Text = ""
        '    End If
        'End If
        'txt_Hdr_ClaimToHKOAmt_ori.ForeColor = Color.Black
        'txt_Hdr_OrgClaimAmt.ForeColor = Color.Black
        'txt_Hdr_ClaimToInsAmt_ori.ForeColor = Color.Black
        'txt_Hdr_ClaimToVNAmt_ori.ForeColor = Color.Black
    End Sub


    Private Sub cmd_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_close.Click
        'If Val(txt_Hdr_FinalClaimAmt.Text) <> Val(txt_Hdr_AcctClaimAmt.Text) Then
        'If Val(txt_Hdr_ClaimToHKOAmt.Text) <> Val(txt_Hdr_AcctClaimAmt.Text) Then
        If Not (Val(txt_pay_potamt.Text) = 0) Then
            MsgBox("Paid Outstanding Amount<> 0 !")
            Exit Sub
        End If

        If Not (Val(txt_income_potamt.Text) = 0) Then
            MsgBox("Received Outstanding  Amount<> 0 !")
            Exit Sub
        End If

        If Not (round(cal_cur_rate(Val(txt_income_actamt.Text), cbo_income_cur.Text.Trim), 1) = round(cal_cur_rate(Val(txt_Hdr_ClaimToVNAmt.Text), cbo_Hdr_ClaimToVNAmtCur.Text.Trim) + cal_cur_rate(Val(txt_Hdr_ClaimToInsAmt.Text), cbo_Hdr_ClaimToInsAmtCur.Text.Trim), 1)) Then
            MsgBox("Received Amt <> Customer Amt + Vendor Amt !")
            Exit Sub
        End If

        If rbClaimBy_U.Checked = True Then
            If Not (Val(txt_pay_actamt.Text) = 0) Then
                MsgBox("Claim By HK Office, but Paid Amount <> 0!")
                Exit Sub
            End If
        Else
            If Not (round(cal_cur_rate(Val(txt_pay_actamt.Text), cbo_pay_cur.Text.Trim), 1) = round(cal_cur_rate(Val(txt_Hdr_FinalClaimAmt.Text), cbo_Hdr_ClaimAmtCurrency.Text.Trim), 1)) Then
                MsgBox("Claim By  Customer/ Vendor, but Paid Amount <> Finalized Amount!")
                Exit Sub
            End If
        End If

        'If Val(txt_Hdr_ClaimToHKOAmt.Text) <> Val(txt_Hdr_AcctClaimAmt.Text) Then
        '    MsgBox("The final approved claim amount should be equal to Account dept amount!")
        '    Exit Sub
        'End If

        If MsgBox("Are you sure to change status to the CLOSE?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "CLOS"
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
            txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
            txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString

            display_combo("CLOS", cboClaimSts)
            setStatus(cModeRead)
            mmdSave_Click(sender, e)
        End If
    End Sub

    Private Sub txtSalesManager_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalesManager.TextChanged

    End Sub

    Public Sub set_app_buttons()
        '20140327
        'Approve Rights Table
        Dim temp_claim_type As String
        Dim temp_mgt_apprgt As Boolean

        Dim temp_claim_type_a As String
        Dim temp_claim_type_b As String

        temp_claim_type = Split(cboClaimType.Text, " - ")(0)

        temp_claim_type_a = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a")
        temp_claim_type_b = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b")

        Dim i As Integer
        For i = 0 To rs_CAORDHDR.Tables("RESULT").Columns.Count - 1
            rs_CAORDHDR.Tables("RESULT").Columns(i).ReadOnly = False
        Next i


        '''       rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a").

        '''usr-grp
        ''' usr-rank
        ''' which mgt
        gspStr = "sp_list_SYUSRPRF_1 '" & gsCompany & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_syusrpr, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If

        If rs_syusrpr.Tables("result").Rows.Count = 0 Then
            MsgBox("User group not found!")
            Exit Sub
        Else
            '''find out which user group
            'yup_usrid()
            'yup_usrgrp()
            For index4 As Integer = 0 To rs_syusrpr.Tables("result").Rows.Count - 1
                If gsUsrID = rs_syusrpr.Tables("RESULT").Rows(index4).Item("yup_usrid") Then
                    temp_yup_usrgrp = rs_syusrpr.Tables("RESULT").Rows(index4).Item("yup_usrgrp")
                End If
            Next
        End If

        temp_yup_usrgrp = gsUsrGrp


        ''' read table:  rights= y/n
        temp_mgt_apprgt = False
        For index5 As Integer = 0 To rs_SYCLMTYP.Tables("result").Rows.Count - 1
            If temp_claim_type = rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_cde") Then
                If temp_yup_usrgrp = "SAL-S" Then
                    If rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_SMApprgt") = "Y" Then
                        temp_mgt_apprgt = True
                    End If
                ElseIf temp_yup_usrgrp = "SAL-ZS" Then
                    If rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_SZApprgt") = "Y" Then
                        temp_mgt_apprgt = True
                    End If
                ElseIf temp_yup_usrgrp = "SHP-S" Then
                    If rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_ShpApprgt") = "Y" Then
                        temp_mgt_apprgt = True
                    End If
                Else
                    temp_mgt_apprgt = False
                End If

            End If
        Next

        '''AmtApp
        '''text amt final
        Dim temp_finalclmamt As Decimal
        temp_finalclmamt = Val(txt_Hdr_FinalClaimAmt.Text)
        If cbo_Hdr_ClaimAmtCurrency.Text.Trim <> "USD" Then
            temp_finalclmamt = temp_finalclmamt / gl_rate
        End If

        '''amt in the table
        ''comapre
        For index5 As Integer = 0 To rs_SYCLMTYP.Tables("result").Rows.Count - 1
            If temp_claim_type = rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_cde") Then
                If temp_finalclmamt <= IIf(IsDBNull(rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_appamt")), 0, rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_appamt")) Then
                    If temp_mgt_apprgt = True Then
                        temp_mgt_apprgt = True ''' second check for Approve right
                    End If
                Else
                    temp_mgt_apprgt = False
                End If

            End If
        Next



        'If Split(cboClaimSts.Text, " - ")(0) = "OPEN" _
        'Or Split(cboClaimSts.Text, " - ")(0) = "WAIT" Then
        If Split(cboClaimSts.Text, " - ")(0) = "WAIT" Then

            If gsUsrRank <= 3 Or temp_mgt_apprgt = True Then
                chkapv1a.Enabled = True
                chkapv1b.Enabled = True
            Else
                chkapv1a.Enabled = False
                chkapv2a.Checked = False
                chkapv2a.Enabled = False
            End If
            '  chkapv1b.Enabled = False
            chkapv2b.Checked = False
            chkapv2b.Enabled = False

            cmd_close.Enabled = False
        End If

        ''''''''''''''''
        'If temp_claim_type_a = "" Then
        '    If gsUsrRank < 4 Or temp_mgt_apprgt = True Then
        '        chkapv1a.Enabled = True
        '    End If

        'End If


        '
        If temp_claim_type_a = "APV1a" Or temp_claim_type_a = "APV2a" _
        And Microsoft.VisualBasic.Left(temp_yup_usrgrp, 3) <> "ACT" Then
            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" And Del_right_local = True Then
                txt_cmt_a.Enabled = True
                txt_cmt_a.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_cmt_a.ReadOnly = False
            Else
                txt_cmt_a.Enabled = True
            End If

        Else
            If gsUsrRank > 3 Then
                If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" And Del_right_local = True Then
                    txt_cmt_a.Enabled = True
                    txt_cmt_a.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                    txt_cmt_a.ReadOnly = True
                Else
                    txt_cmt_a.Enabled = True
                End If

            End If
        End If
        If temp_claim_type_b = "APV1b" Or temp_claim_type_b = "APV2b" _
       And Microsoft.VisualBasic.Left(temp_yup_usrgrp, 3) <> "ACT" Then
            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" And Del_right_local = True Then
                txt_cmt_b.Enabled = True
                txt_cmt_b.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_cmt_b.ReadOnly = False
            Else
                txt_cmt_b.Enabled = True
            End If

        Else
            If gsUsrRank >= 3 Then
                If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" And Del_right_local = True Then
                    txt_cmt_b.Enabled = True
                    txt_cmt_b.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                    txt_cmt_b.ReadOnly = True
                Else
                    txt_cmt_b.Enabled = True
                End If

            End If
        End If


        If temp_claim_type_a = "APV1a" Then
            chkapv1a.Checked = True
            chkapv1a.Enabled = True

            If gsUsrRank < 3 Or temp_mgt_apprgt = True Then
                chkapv2a.Enabled = True
            Else
                chkapv2a.Enabled = False
            End If
            chkapv3a.Checked = False
            chkapv3a.Enabled = False

            chkapv1b.Enabled = True
            cmd_close.Enabled = False
        End If

        If temp_claim_type_a = "APV2a" Then

            chkapv1a.Checked = True
            chkapv1a.Enabled = False
            chkapv2a.Checked = True
            chkapv2a.Enabled = True

            If Microsoft.VisualBasic.Left(temp_yup_usrgrp, 3) = "ACT" And Del_right_local = True Then
                chkapv3a.Enabled = True
            Else
                chkapv3a.Enabled = False
            End If

            cmd_close.Enabled = False
        End If


        If temp_claim_type_a = "APV3a" Then
            chkapv3a.Checked = True

            chkapv1a.Checked = True
            chkapv1a.Enabled = False
            chkapv2a.Checked = True
            chkapv2a.Enabled = False

            If Microsoft.VisualBasic.Left(temp_yup_usrgrp, 3) = "ACT" And Del_right_local = True Then
                chkapv3a.Enabled = True
            Else
                chkapv3a.Enabled = False
            End If

        End If


        ''
        'If temp_claim_type_b = "" Then
        '    If gsUsrRank < 4 Or temp_mgt_apprgt = True Then
        '        chkapv1b.Enabled = True
        '    End If
        'End If

        If temp_claim_type_b = "APV1b" Then
            chkapv1b.Checked = True
            chkapv1b.Enabled = True


            If gsUsrRank < 3 Or temp_mgt_apprgt = True Then
                chkapv2b.Enabled = True
            Else
                chkapv2b.Enabled = False
            End If

            'chkapv2b.Checked = True
            'temp_claim_type_b = "APV2b"
            'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = temp_claim_type_b

            'chkapv2b.Enabled = True

            chkapv3b.Checked = False
            chkapv3b.Enabled = False

            cmd_close.Enabled = False
        End If

        If temp_claim_type_b = "APV2b" Then

            chkapv1b.Checked = True
            chkapv1b.Enabled = False
            chkapv2b.Checked = True
            chkapv2b.Enabled = True

            If Microsoft.VisualBasic.Left(temp_yup_usrgrp, 3) = "ACT" And Del_right_local = True Then
                chkapv3b.Enabled = True
            Else
                chkapv3b.Enabled = False
            End If

            cmd_close.Enabled = False
        End If


        If temp_claim_type_b = "APV3b" Then
            chkapv3b.Checked = True

            chkapv1b.Checked = True
            chkapv1b.Enabled = False
            chkapv2b.Checked = True
            chkapv2b.Enabled = False

            If Microsoft.VisualBasic.Left(temp_yup_usrgrp, 3) = "ACT" And Del_right_local = True Then
                chkapv3b.Enabled = True
            Else
                chkapv3b.Enabled = False
            End If

        End If


        ''''''''''''''''''''''''''''''
        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "APRV" Then
            If (temp_claim_type_a = "APV2a" Or temp_claim_type_a = "APV3a") And (temp_claim_type_b = "APV2b" Or temp_claim_type_b = "APV3b") Then
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "RELS"
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
                txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
                txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString

                display_combo("RELS", cboClaimSts)
            End If
            '''
            If temp_mgt_apprgt = True Or gsUsrRank < 3 Then
                If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = "" Then
                    chkapv1b.Enabled = True
                End If
            End If

        End If


        ''''''''''''''''''''''''''''''
        If Split(cboClaimSts.Text, " - ")(0) <> "CLOS" Then

            If temp_mgt_apprgt = True Or gsUsrRank < 3 Or Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "SAL" Then
                chkCancel.Enabled = True
            Else
                chkCancel.Enabled = False
            End If

        End If



        If Microsoft.VisualBasic.Left(temp_yup_usrgrp, 3) = "ACT" Then
            chkapv1a.Enabled = False
            chkapv2a.Enabled = False
            chkapv1b.Enabled = False
            chkapv2b.Enabled = False
        End If

        If gsUsrRank > 3 Then
            chkapv1a.Enabled = False
            chkapv2a.Enabled = False
            chkapv1b.Enabled = False
            chkapv2b.Enabled = False
        End If

        If gsUsrRank >= 3 And temp_mgt_apprgt <> True Then
            chkapv2a.Enabled = False
            chkapv2b.Enabled = False
        End If

        If gsUsrRank < 3 Or temp_mgt_apprgt = True Then
            If temp_claim_type_a = "" Then
                chkapv1a.Enabled = True
            End If
            If temp_claim_type_b = "" Then
                chkapv1b.Enabled = True
            End If


        End If




        If mode = cModeRead Then
            setStatus(cModeRead)
        End If

        'If chkapv2a.Checked = True Then
        '    chkapv3a.Enabled = True
        'Else
        '    chkapv3a.Enabled = False
        'End If
        'If chkapv2b.Checked = True Then
        '    chkapv3b.Enabled = True
        'Else
        '    chkapv3b.Enabled = False
        'End If
        If Microsoft.VisualBasic.Left(temp_yup_usrgrp, 3) = "ACT" And Del_right_local = True Then
            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                txt_cmt_a.Enabled = True
                txt_cmt_a.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_cmt_a.ReadOnly = True
            Else
                txt_cmt_a.Enabled = True
            End If

            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" And Del_right_local = True Then
                txt_cmt_b.Enabled = True
                txt_cmt_b.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_cmt_b.ReadOnly = True
            Else
                txt_cmt_b.Enabled = True
            End If

        End If


    End Sub

    Private Sub chkwait_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkwait.CheckedChanged
        Dim msg As String

        'If chkwait.Checked = True Then
        '    msg = "Are you sure to change status to 'Waiting for Approval' ?"
        'Else
        '    msg = "Are you sure to change status to 'Open' ?"
        'End If

        'If MsgBox(msg, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "OPEN" Or _
         rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "WAIT" _
        Then

            If chkwait.Checked = True Then

                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "WAIT"
                If flag_chkwait_Click = True Then
                    flag_chkwait_Click = False
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
                    txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
                    txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
                End If
                display_combo("WAIT", cboClaimSts)
                chkapv1a.Enabled = False
                chkapv1b.Enabled = False
                mmdAdd.Enabled = False


                '    Call set_app_buttons()
            Else
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "OPEN"
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
                txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
                txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString

                display_combo("OPEN", cboClaimSts)
                chkapv1a.Enabled = False
                chkapv1b.Enabled = False
                mmdAdd.Enabled = False
                '   Call set_app_buttons()

            End If
        End If

        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~"
        End If
        If Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Or rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~") Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~"
        End If
        'Else

        'End If
    End Sub

    Private Sub chkconfirmclm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub chkapv1a_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkapv1a.CheckedChanged
    End Sub

    Private Sub chkapv1b_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkapv1b.CheckedChanged

    End Sub

    Private Sub txt_Hdr_AcctClaimAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If rs_CAORDHDR.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        If rs_CAORDHDR.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_acct_caamt_final") = Val(txt_Hdr_AcctClaimAmt.Text)

        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~"
        End If
        If Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Or rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~") Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~"
        End If


    End Sub

    Private Sub cboClaimPeriod_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboClaimPeriod.Validating
        Dim tmpstr As String
        tmpstr = cboClaimPeriod.Text

        'If cboClaimPeriod.Items.IndexOf(tmpstr) = -1 _
        'Or cboClaimPeriod.Items.IndexOf(tmpstr) = 0 Then
        If cboClaimPeriod.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Claim Period - Data is Invalid, please select in Drop Down List.")
            e.Cancel = True
            cboClaimPeriod.Enabled = True
        Else
            cboClaimPeriod.Enabled = False
        End If




    End Sub


    Private Sub tpCLM00001_2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpCLM00001_2.Click

    End Sub

    Private Sub GroupBox1_Enter_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gb_pay.Enter

    End Sub

    Private Sub StatusBar_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles StatusBar.PanelClick

    End Sub

    Private Sub gb_Hdr_ClaimAmt_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gb_Hdr_ClaimAmt.Enter

    End Sub

    Private Sub txt_Hdr_ClaimToHKOAmt_ori_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Hdr_ClaimToHKOAmt_ori.LostFocus


        'txt_Hdr_FinalClaimAmt.Focus()

    End Sub

    Private Sub txt_Hdr_ClaimToHKOAmt_ori_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txt_Hdr_ClaimToHKOAmt_ori.MouseWheel

    End Sub



    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Hdr_ClaimToHKOAmt_ori.TextChanged
        show_org_dif()

    End Sub

    Private Sub TextBox11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim tmpstr As String
        tmpstr = txt_income_rmk.Text
        If tmpstr <> rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_rmk") Then
            '''
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_upddat") = Format(Today.Date, "MM/dd/yyyy")
        End If


        'rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_upddat") = Format(Today.Date, "MM/dd/yyyy")
    End Sub

    Private Sub txt_pay_rmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim tmpstr As String
        tmpstr = txt_pay_rmk.Text
        If tmpstr <> rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_rmk") Then
            '''
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_upddat") = Format(Today.Date, "MM/dd/yyyy")
        End If

    End Sub

    Private Sub format_cboClaimIncomeSTS()
        Dim i As Integer
        Dim strList As String


        If rs_SYCLMIST.Tables.Count = 0 Then
            Exit Sub
        End If

        cboClaimIncomeSTS.Items.Clear()

        If rs_SYCLMIST.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYCLMIST.Tables("RESULT").Rows.Count - 1

                strList = Trim(rs_SYCLMIST.Tables("RESULT").Rows(i).Item("yci_cde")) & " - " & Trim(rs_SYCLMIST.Tables("RESULT").Rows(i).Item("yci_dsc"))

                If strList <> "" Then
                    cboClaimIncomeSTS.Items.Add(strList)

                End If
            Next i
        End If
    End Sub


    Private Sub chkapv2a_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkapv2a.CheckedChanged

    End Sub

    Private Sub chkapv2b_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkapv2b.CheckedChanged

    End Sub

    Private Sub chkapv3a_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkapv3a.CheckedChanged

    End Sub

    Private Sub chkapv3b_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkapv3b.CheckedChanged


    End Sub


    Private Sub chkapv1a_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkapv1a.Click


        If chkapv1a.Checked = True Then

            If check_amt() = False Then
                chkapv1a.Checked = False
                Exit Sub
            End If

            If chkwait.Checked = False Then
                MsgBox("The Claim must be ready for Approval!")
                chkapv1a.Checked = False
                Exit Sub
            End If


            If 1 = 1 Then
                '                flag_keypress_1a = False

                If MsgBox("Are you sure to change status to the APV1a?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_A") = "APV1a"
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "APRV"
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
                    txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
                    txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "APRV"
                    display_combo("APRV", cboClaimSts)
                    chkapv1a.Enabled = True
                    chkapv1b.Enabled = True
                    mmdAdd.Enabled = False

                    chkapv1a.Enabled = False

                    'chkapv2a.Checked = True
                    Call set_app_buttons_2a2b()
                    'cmdSave_Click(sender, e)
                Else
                    chkapv1a.Checked = False
                    Call set_app_buttons()

                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_A") = ""
                    chkapv2a.Checked = False

                    Exit Sub
                End If
            End If
        Else
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_A") = ""
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
            txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
            txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "WAIT"
            display_combo("WAIT", cboClaimSts)
            chkapv2a.Checked = False

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_A") = ""
            chkapv2a.Checked = False


            'Call set_app_buttons()
        End If



        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~"
        End If
        If Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Or rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~") Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~"
        End If


        'If chkapv1a.Checked = True Then
        '    If 1 = 1 Then
        '        '                flag_keypress_1a = False

        '        If MsgBox("Are you sure to change status to the APV1a?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_A") = "APV1a"
        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "APRV"
        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
        '            txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
        '            txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
        '            display_combo("APRV", cboClaimSts)
        '            chkapv1a.Enabled = True
        '            chkapv1b.Enabled = True
        '            cmdAdd.Enabled = False

        '            chkapv1a.Enabled = False

        '            'chkapv2a.Checked = True
        '            Call set_app_buttons_2a2b()
        '            'cmdSave_Click(sender, e)
        '        Else
        '            chkapv1a.Checked = False
        '            Call set_app_buttons()
        '            Exit Sub
        '        End If
        '    End If
        'Else
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_A") = ""
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
        '    txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
        '    txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
        '    display_combo("OPEN", cboClaimSts)
        '    chkapv2a.Checked = False
        '    'Call set_app_buttons()
        'End If



        'If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Then
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~"
        'End If
        'If Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Or rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~") Then
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~"
        'End If

        ''flag_keypress_1a = True
        If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
            txt_cmt_a.Enabled = True
            txt_cmt_a.ScrollBars = RichTextBoxScrollBars.ForcedVertical
            txt_cmt_a.ReadOnly = False
        Else
            txt_cmt_a.Enabled = True
        End If





    End Sub

    Private Sub chkapv2a_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkapv2a.Click


        If chkapv2a.Checked = True Then
            If 1 = 1 Then
                '   flag_keypress_2a = False

                If MsgBox("Are you sure to change status to the APV2a?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    'If Split(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS"), " - ")(0) = "APV1a" Then
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_A") = "APV2a"
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "APRV"
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
                    txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
                    txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString

                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "APRV"
                    display_combo("APRV", cboClaimSts)
                    'End If

                    mmdAdd.Enabled = False
                    chkapv2a.Checked = True
                    Call set_app_buttons()
                    chkapv1a.Enabled = True
                    chkapv2a.Enabled = True
                    chkapv1b.Enabled = True
                    chkapv2b.Enabled = True
                    mmdSave.Enabled = True

                    'cmdSave_Click(sender, e)
                Else

                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_A") = "APV1a"
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
                    txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
                    txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "APRV"
                    display_combo("APRV", cboClaimSts)

                    chkapv1a.Checked = True
                    chkapv2a.Checked = False
                    Call set_app_buttons()
                    chkapv1a.Enabled = True
                    chkapv2a.Enabled = True
                    chkapv1b.Enabled = True
                    chkapv2b.Enabled = True
                    mmdSave.Enabled = True


                    Exit Sub
                End If
            End If
        Else

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_A") = "APV1a"
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
            txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
            txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "APRV"
            display_combo("APRV", cboClaimSts)
            chkapv1a.Checked = True
            chkapv2a.Checked = False
            Call set_app_buttons()
            'Call set_app_buttons()
            chkapv1a.Enabled = True
            chkapv2a.Enabled = True
            chkapv1b.Enabled = True
            chkapv2b.Enabled = True
            mmdSave.Enabled = True
        End If



        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~"
        End If
        If Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Or rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~") Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~"
        End If


        'flag_keypress_2a = True


        'If chkapv2a.Checked = True Then
        '    If 1 = 1 Then
        '        '   flag_keypress_2a = False

        '        If MsgBox("Are you sure to change status to the APV2a?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

        '            'If Split(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS"), " - ")(0) = "APV1a" Then
        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_A") = "APV2a"
        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "APRV"
        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
        '            txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
        '            txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
        '            display_combo("APRV", cboClaimSts)
        '            'End If

        '            cmdAdd.Enabled = False
        '            chkapv2a.Checked = True
        '            Call set_app_buttons()

        '            'cmdSave_Click(sender, e)
        '        Else

        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_A") = "APV1a"
        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
        '            txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
        '            txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
        '            display_combo("APRV", cboClaimSts)

        '            chkapv1a.Checked = True
        '            chkapv2a.Checked = False
        '            Call set_app_buttons()
        '            Call uncheck2()

        '            Exit Sub
        '        End If
        '    End If
        'Else

        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_A") = "APV1a"
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
        '    txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
        '    txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
        '    display_combo("APRV", cboClaimSts)
        '    chkapv1a.Checked = True
        '    chkapv2a.Checked = False
        '    Call set_app_buttons()
        '    Call uncheck2()
        '    'Call set_app_buttons()
        'End If



        'If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Then
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~"
        'End If
        'If Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Or rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~") Then
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~"
        'End If


        ''flag_keypress_2a = True
        If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
            txt_cmt_a.Enabled = True
            txt_cmt_a.ScrollBars = RichTextBoxScrollBars.ForcedVertical
            txt_cmt_a.ReadOnly = False
        Else
            txt_cmt_a.Enabled = True
        End If



        If chkapv2a.Checked = True Then
            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                txt_cmt_a.Enabled = True
                txt_cmt_a.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_cmt_a.ReadOnly = True
            Else
                txt_cmt_a.Enabled = True
            End If

        End If
        If chkapv2b.Checked = True Then
            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                txt_cmt_b.Enabled = True
                txt_cmt_b.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_cmt_b.ReadOnly = True
            Else
                txt_cmt_b.Enabled = True
            End If

        End If


    End Sub

    Private Sub chkapv3a_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkapv3a.Click

        If chkapv3a.Checked = True Then
            If 1 = 1 Then
                'flag_keypress_3a = False

                If MsgBox("Are you sure to change status to the APV3a?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_A") = "APV3a"
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
                    txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
                    txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString

                    ' display_combo("RELS", cboClaimSts)

                    mmdAdd.Enabled = False
                    chkapv3a.Checked = True
                    Call set_app_buttons()

                    'cmdSave_Click(sender, e)
                Else

                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_A") = "APV2a"
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
                    txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
                    txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
                    'display_combo("RELS", cboClaimSts)

                    chkapv3a.Checked = False
                    Call set_app_buttons()
                    Exit Sub
                End If
            End If
        Else

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_A") = "APV2a"
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
            txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
            txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
            'display_combo("RELS", cboClaimSts)

            chkapv3a.Checked = False
            Call set_app_buttons()
        End If



        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~"
        End If
        If Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Or rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~") Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~"
        End If


        'flag_keypress_3a = True
        Call set_app_buttons_3a3b()
    End Sub

    Private Sub chkapv1b_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkapv1b.Click

        If chkapv1b.Checked = True Then

            If check_amt() = False Then
                chkapv1a.Checked = False
                Exit Sub
            End If

            If chkwait.Checked = False Then
                MsgBox("The Claim must be ready for Approval!")
                chkapv1a.Checked = False
                Exit Sub
            End If


            If 1 = 1 Then
                'flag_keypress_1b = False

                If MsgBox("Are you sure to change status to the APV1b?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = "APV1b"
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "APRV"
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
                    txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
                    txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
                    display_combo("APRV", cboClaimSts)
                    chkapv1b.Enabled = False


                    mmdAdd.Enabled = False

                    cbo_Hdr_ClaimAmtCurrency.Enabled = False
                    cbo_Hdr_ClaimToInsAmtCurrency.Enabled = False
                    cbo_Hdr_ClaimToVNAmtCurrency.Enabled = False
                    cbo_Hdr_ClaimToHKOAmtCurrency.Enabled = False
                    txt_Hdr_OrgClaimAmt.Enabled = False
                    txt_Hdr_FinalClaimAmt.Enabled = False
                    txt_Hdr_ClaimToInsAmt.Enabled = False
                    txt_Hdr_ClaimToVNAmt.Enabled = False
                    txt_Hdr_ClaimToHKOAmt.Enabled = False
                    txt_Hdr_ClaimToInsAmt_ori.Enabled = False
                    txt_Hdr_ClaimToVNAmt_ori.Enabled = False
                    txt_Hdr_ClaimToHKOAmt_ori.Enabled = False


                    Call set_app_buttons_2a2b()

                Else
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = ""
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
                    txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
                    txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "WAIT"
                    display_combo("WAIT", cboClaimSts)
                    chkapv1b.Checked = False
                    chkapv2b.Checked = False
                    chkapv1a.Enabled = True
                    chkapv1b.Enabled = True
                    chkapv2b.Enabled = False
                    Call set_app_buttons()
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_B") = ""
                    chkapv2b.Checked = False

                    '            cmdSave_Click(sender, e)
                End If
            End If

        Else
            chkapv1b.Checked = False
            chkapv2b.Checked = False
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = ""
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
            txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
            txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "WAIT"
            display_combo("WAIT", cboClaimSts)
            chkapv1a.Enabled = True
            chkapv1b.Enabled = True
            chkapv2b.Enabled = False
            Call set_app_buttons()

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_B") = ""
            chkapv2b.Checked = False

        End If


        '     If chkapv1b.Checked = True Then
        '         If 1 = 1 Then
        '             'flag_keypress_1b = False

        '             If MsgBox("Are you sure to change status to the APV1b?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '                 rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = "APV1b"
        '                 rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "APRV"
        '                 rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
        '                 rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
        '                 txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
        '                 txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
        '                 display_combo("APRV", cboClaimSts)
        '                 chkapv1b.Enabled = False


        '                 cmdAdd.Enabled = False

        '                 cbo_Hdr_ClaimAmtCurrency.Enabled = False
        '                 cbo_Hdr_ClaimToInsAmtCurrency.Enabled = False
        '                 cbo_Hdr_ClaimToVNAmtCurrency.Enabled = False
        '                 cbo_Hdr_ClaimToHKOAmtCurrency.Enabled = False
        '                 txt_Hdr_OrgClaimAmt.Enabled = False
        '                 txt_Hdr_FinalClaimAmt.Enabled = False
        '                 txt_Hdr_ClaimToInsAmt.Enabled = False
        '                 txt_Hdr_ClaimToVNAmt.Enabled = False
        '                 txt_Hdr_ClaimToHKOAmt.Enabled = False
        '                 txt_Hdr_ClaimToInsAmt_ori.Enabled = False   
        'cbo_Hdr_ClaimToInsAmtCur.Enabled = False
        '                 txt_Hdr_ClaimToVNAmt_ori.Enabled = False 
        '     cbo_Hdr_ClaimToVNAmtCur.Enabled = False
        '                 txt_Hdr_ClaimToHKOAmt_ori.Enabled = False 
        '     cbo_Hdr_ClaimToHKOAmtCur.Enabled = False


        '                 Call set_app_buttons_2a2b()

        '             Else
        '                 rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = ""
        '                 rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
        '                 rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
        '                 txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
        '                 txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
        '                 display_combo("APRV", cboClaimSts)
        '                 chkapv1b.Checked = False
        '                 chkapv2b.Checked = False
        '                 chkapv1a.Enabled = True
        '                 chkapv1b.Enabled = True
        '                 chkapv2b.Enabled = False
        '                 Call set_app_buttons()

        '                 '            cmdSave_Click(sender, e)
        '             End If
        '         End If

        '     Else
        '         chkapv1b.Checked = False
        '         chkapv2b.Checked = False
        '         rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = ""
        '         rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
        '         rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
        '         txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
        '         txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
        '         display_combo("OPEN", cboClaimSts)
        '         chkapv1a.Enabled = True
        '         chkapv1b.Enabled = True
        '         chkapv2b.Enabled = False
        '         Call set_app_buttons()
        '     End If

        '     'flag_keypress_1b = True


        If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
            txt_cmt_b.Enabled = True
            txt_cmt_b.ScrollBars = RichTextBoxScrollBars.ForcedVertical
            txt_cmt_b.ReadOnly = False
        Else
            txt_cmt_b.Enabled = True
        End If


    End Sub

    Private Sub chkapv2b_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkapv2b.Click

        If chkapv2b.Checked = True Then
            If 1 = 1 Then
                'flag_keypress_2b = False

                If MsgBox("Are you sure to change status to the APV2b?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_B") = "APV2b"
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "APRV"
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
                    txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
                    txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "APRV"
                    display_combo("APRV", cboClaimSts)

                    mmdAdd.Enabled = False
                    chkapv2b.Checked = True
                    Call set_app_buttons()
                    chkapv1a.Enabled = True
                    chkapv2a.Enabled = True
                    chkapv1b.Enabled = True
                    chkapv2b.Enabled = True
                    mmdSave.Enabled = True


                Else

                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_B") = "APV1b"
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
                    txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
                    txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString

                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "APRV"
                    display_combo("APRV", cboClaimSts)

                    chkapv1b.Checked = True
                    chkapv2b.Checked = False
                    Call set_app_buttons()
                    chkapv1a.Enabled = True
                    chkapv2a.Enabled = True
                    chkapv1b.Enabled = True
                    chkapv2b.Enabled = True
                    mmdSave.Enabled = True


                    Exit Sub
                End If
            End If
        Else


            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_B") = "APV1b"
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
            txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
            txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "APRV"
            display_combo("APRV", cboClaimSts)

            chkapv1b.Checked = True
            chkapv2b.Checked = False
            Call set_app_buttons()
            chkapv1a.Enabled = True
            chkapv2a.Enabled = True
            chkapv1b.Enabled = True
            chkapv2b.Enabled = True
            mmdSave.Enabled = True
        End If

        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~"
        End If
        If Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Or rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~") Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~"
        End If


        'If chkapv2b.Checked = True Then
        '    If 1 = 1 Then
        '        'flag_keypress_2b = False

        '        If MsgBox("Are you sure to change status to the APV2b?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_B") = "APV2b"
        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "APRV"
        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
        '            txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
        '            txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
        '            display_combo("APRV", cboClaimSts)

        '            cmdAdd.Enabled = False
        '            chkapv2b.Checked = True
        '            Call set_app_buttons()


        '        Else

        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_B") = "APV1b"
        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
        '            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
        '            txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
        '            txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
        '            display_combo("APRV", cboClaimSts)

        '            chkapv1b.Checked = True
        '            chkapv2b.Checked = False
        '            Call set_app_buttons()
        '            Call uncheck2()

        '            Exit Sub
        '        End If
        '    End If
        'Else


        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_B") = "APV1b"
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
        '    txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
        '    txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
        '    display_combo("APRV", cboClaimSts)

        '    chkapv1b.Checked = True
        '    chkapv2b.Checked = False
        '    Call set_app_buttons()
        '    Call uncheck2()
        'End If

        'If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Then
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~"
        'End If
        'If Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Or rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~") Then
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~"
        'End If


        ''flag_keypress_2b = True


        If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
            txt_cmt_b.Enabled = True
            txt_cmt_b.ScrollBars = RichTextBoxScrollBars.ForcedVertical
            txt_cmt_b.ReadOnly = False
        Else
            txt_cmt_b.Enabled = True
        End If


        If chkapv2a.Checked = True Then
            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                txt_cmt_a.Enabled = True
                txt_cmt_a.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_cmt_a.ReadOnly = True
            Else
                txt_cmt_a.Enabled = True
            End If

        End If
        If chkapv2b.Checked = True Then
            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                txt_cmt_b.Enabled = True
                txt_cmt_b.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_cmt_b.ReadOnly = True
            Else
                txt_cmt_b.Enabled = True
            End If

        End If

    End Sub

    Private Sub chkapv3b_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkapv3b.Click

        If chkapv3b.Checked = True Then
            If 1 = 1 Then
                'flag_keypress_3b = False

                If MsgBox("Are you sure to change status to the APV3b?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_B") = "APV3b"
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
                    txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
                    txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
                    'display_combo("RELS", cboClaimSts)

                    mmdAdd.Enabled = False
                    chkapv3b.Checked = True
                    Call set_app_buttons()

                    'cmdSave_Click(sender, e)
                Else

                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_B") = "APV2b"
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
                    txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
                    txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
                    'display_combo("RELS", cboClaimSts)

                    chkapv3b.Checked = False
                    Call set_app_buttons()
                    Exit Sub
                End If
            End If
        Else

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS_B") = "APV2b"
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
            txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
            txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
            'display_combo("RELS", cboClaimSts)

            chkapv3b.Checked = False
            Call set_app_buttons()
        End If



        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~"
        End If
        If Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Or rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~") Then
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~"
        End If

        Call set_app_buttons_3a3b()

        'flag_keypress_3b = True
    End Sub

    Private Sub cboClaimType_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboClaimType.LostFocus

        txt_Hdr_CustComment.Focus()

        'txt_Hdr_Rmk.Focus()
    End Sub

    Private Sub cboClaimType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClaimType.SelectedIndexChanged

    End Sub

    Private Sub chkconfirmclm_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'If chkconfirmclm.Checked = True Then
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_confclm") = "Y"
        'Else
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_confclm") = "N"
        'End If

        'If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Then
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~"
        'End If
        'If Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Or rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~") Then
        '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~"
        'End If

        Call check_pot_val()
    End Sub

    Private Sub chkvalidclm_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Call check_pot_val()

    End Sub
    Public Sub check_pot_val()
        If chkconfirmclm.Checked = False And chkvalidclm.Checked = False Then
        Else
            If chkconfirmclm.Checked = True And chkvalidclm.Checked = True Then
            ElseIf chkconfirmclm.Checked = True Then
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pot_val") = "P"
            ElseIf chkvalidclm.Checked = True Then
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pot_val") = "V"
            End If
            If mode = cModeAdd Then
                If FLAG_FIRST_TIME_CHECK_CASE = True Then

                    gbClaimAmtPer.Enabled = True
                    rbClaimAmtPer_C.Enabled = True
                    rbClaimAmtPer_I.Enabled = True
                    rbClaimAmtPer_S.Enabled = True

                    ''???
                    ''rbClaimAmtPer_C.Checked = False

                    chkreplace.Enabled = True

                End If
            End If
        End If

    End Sub

    Private Sub cmd_attch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_attch.Click

        Dim formattch As New frmAttchUpload
        Dim tmep_doc_no As String

        formattch.setModule("CLM")
        '        CompanyName, "CLM#"
        tmep_doc_no = txtClaimNo.Text

        formattch.setDoc("UCP", tmep_doc_no)
        formattch.setDoc_sts(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS"))

        formattch.ShowDialog()
        formattch = Nothing


    End Sub

    Public Sub set_app_buttons_2a2b()
        '20140327
        'Approve Rights Table
        Dim temp_claim_type As String
        Dim temp_mgt_apprgt As Boolean

        Dim temp_claim_type_a As String
        Dim temp_claim_type_b As String

        temp_claim_type = Split(cboClaimType.Text, " - ")(0)

        temp_claim_type_a = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a")
        temp_claim_type_b = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b")

        Dim i As Integer
        For i = 0 To rs_CAORDHDR.Tables("RESULT").Columns.Count - 1
            rs_CAORDHDR.Tables("RESULT").Columns(i).ReadOnly = False
        Next i


        '''       rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a").

        '''usr-grp
        ''' usr-rank
        ''' which mgt
        gspStr = "sp_list_SYUSRPRF_1 '" & gsCompany & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_syusrpr, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If

        If rs_syusrpr.Tables("result").Rows.Count = 0 Then
            MsgBox("User group not found!")
            Exit Sub
        Else
            '''find out which user group
            'yup_usrid()
            'yup_usrgrp()
            For index4 As Integer = 0 To rs_syusrpr.Tables("result").Rows.Count - 1
                If gsUsrID = rs_syusrpr.Tables("RESULT").Rows(index4).Item("yup_usrid") Then
                    temp_yup_usrgrp = rs_syusrpr.Tables("RESULT").Rows(index4).Item("yup_usrgrp")
                End If
            Next
        End If

        temp_yup_usrgrp = gsUsrGrp


        ''' read table:  rights= y/n
        temp_mgt_apprgt = False
        For index5 As Integer = 0 To rs_SYCLMTYP.Tables("result").Rows.Count - 1
            If temp_claim_type = rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_cde") Then
                If temp_yup_usrgrp = "SAL-S" Then
                    If rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_SMApprgt") = "Y" Then
                        temp_mgt_apprgt = True
                    End If
                ElseIf temp_yup_usrgrp = "SAL-ZS" Then
                    If rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_SZApprgt") = "Y" Then
                        temp_mgt_apprgt = True
                    End If
                ElseIf temp_yup_usrgrp = "SHP-S" Then
                    If rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_ShpApprgt") = "Y" Then
                        temp_mgt_apprgt = True
                    End If
                Else
                    temp_mgt_apprgt = False
                End If

            End If
        Next

        '''AmtApp
        '''text amt final
        Dim temp_finalclmamt As Decimal
        temp_finalclmamt = Val(txt_Hdr_FinalClaimAmt.Text)
        If cbo_Hdr_ClaimAmtCurrency.Text.Trim <> "USD" Then
            temp_finalclmamt = temp_finalclmamt / gl_rate
        End If

        '''amt in the table
        ''comapre
        For index5 As Integer = 0 To rs_SYCLMTYP.Tables("result").Rows.Count - 1
            If temp_claim_type = rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_cde") Then
                If temp_finalclmamt <= IIf(IsDBNull(rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_appamt")), 0, rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_appamt")) Then
                    If temp_mgt_apprgt = True Then
                        temp_mgt_apprgt = True ''' second check for Approve right
                    End If
                Else
                    temp_mgt_apprgt = False
                End If

            End If
        Next


        ''''''''''''''''

        If temp_claim_type_a = "APV1a" Then

            If gsUsrRank < 3 Or temp_mgt_apprgt = True Then
                chkapv2a.Enabled = True
                chkapv2a.Checked = True
                temp_claim_type_a = "APV2a"
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a") = temp_claim_type_a
            Else
                chkapv2a.Checked = False
                chkapv2a.Enabled = False
                chkapv1a.Enabled = True
            End If
            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                txt_cmt_a.Enabled = True
                txt_cmt_a.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_cmt_a.ReadOnly = False
            Else
                txt_cmt_a.Enabled = True
            End If

        End If


        If temp_claim_type_b = "APV1b" Then

            If gsUsrRank < 3 Or temp_mgt_apprgt = True Then
                chkapv2b.Enabled = True
                chkapv2b.Checked = True
                temp_claim_type_b = "APV2b"
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = temp_claim_type_b
            Else
                chkapv2b.Checked = False
                chkapv2b.Enabled = False
                chkapv1b.Enabled = True
            End If
            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                txt_cmt_b.Enabled = True
                txt_cmt_b.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_cmt_b.ReadOnly = False
            Else
                txt_cmt_b.Enabled = True
            End If

        End If

        '''''''''''''
        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "APRV" Then
            If temp_claim_type_a = "APV2a" And temp_claim_type_b = "APV2b" Then
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS") = "RELS"
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
                txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
                txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString

                display_combo("RELS", cboClaimSts)
            End If
        End If

    End Sub
    Public Sub set_app_buttons_3a3b()
        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a") = "APV3a" And _
    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_b") = "APV3b" Then
            cmd_close.Enabled = True
            txt_Hdr_AcctClaimAmt.Enabled = True
        Else
            cmd_close.Enabled = False
            txt_Hdr_AcctClaimAmt.Enabled = False
        End If

    End Sub


    Private Sub chkCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCancel.Click

        If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") <> "CANL" Then
            orgclmsts = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts")
        End If

        If chkCancel.Checked = True Then

            If MsgBox("Are you sure to cancel this claim?", vbYesNo) = vbYes Then
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = "CANL"
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
                txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
                txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString

                '''panel
                gbPanelReason.Location = New Point(139, 77)
                bIsShowPanels = True
                gbPanelReason.Visible = True
                gbPanelReason.BringToFront()
                '''
                cmd_close.Enabled = False
            Else

                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = orgclmsts

                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
                txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
                txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
                display_combo(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts"), cboClaimSts)

                txtreason.Text = ""
                chkCancel.Checked = False
            End If

        Else

            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts") = orgclmsts

            If orgclmsts = "APV3b" Or orgclmsts = "CLOS" And Del_right_local = True Then
                cmd_close.Enabled = True
            End If
        End If

        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr") = gsUsrID
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat") = Format(Today.Date, "MM/dd/yyyy")
        txt_stschg_usr.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_usr")
        txt_stschg_date.Text = rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_stschg_dat").ToString
        display_combo(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts"), cboClaimSts)
        txtreason.Text = ""

        If Not rs_CAORDDTL.Tables("RESULT") Is Nothing Then
            If rs_CAORDDTL.Tables("RESULT").Rows.Count <> 0 Then
                If rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*ADD*~" Or rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~" Then
                    rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*NEW*~"
                Else
                    '''1122
                    rs_CAORDDTL.Tables("RESULT").Rows(sReadingIndexQ_ship).Item("cad_creusr") = "~*UPD*~"
                End If
            End If
        End If




    End Sub









    Private Sub txt_income_potamt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_income_potamt.TextChanged
        Dim tmpstr As String
        tmpstr = Val(txt_income_potamt.Text)
        If tmpstr <> rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_potamt") Then
            '''
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_upddat") = Format(Today.Date, "MM/dd/yyyy")
        End If
    End Sub






    Private Sub txt_pay_actamt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pay_actamt.TextChanged

        Dim tmpstr As String
        tmpstr = Val(txt_pay_actamt.Text)
        If tmpstr <> rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_actamt") Then
            '''
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_upddat") = Format(Today.Date, "MM/dd/yyyy")
        End If

    End Sub

    Private Sub txt_pay_potamt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pay_potamt.TextChanged
        Dim tmpstr As String
        tmpstr = Val(txt_pay_potamt.Text)
        If tmpstr <> rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_potamt") Then
            '''
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_upddat") = Format(Today.Date, "MM/dd/yyyy")
        End If
    End Sub







    Private Sub cboClaimPaySTS_SelectedIndexChanged_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim tmpstr As String
        tmpstr = cboClaimPaySTS.Text
        If tmpstr <> rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_PAYSTS") Then
            '''
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_upddat") = Format(Today.Date, "MM/dd/yyyy")
        End If

    End Sub






    Private Sub txt_income_actamt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_income_actamt.TextChanged
        Dim tmpstr As String
        tmpstr = Val(txt_income_actamt.Text)
        If tmpstr <> rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_actamt") Then
            '''
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_upddat") = Format(Today.Date, "MM/dd/yyyy")
        End If

    End Sub

    Private Sub txt_Hdr_ClaimToInsAmt_ori_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Hdr_ClaimToInsAmt_ori.Click

    End Sub

    Private Sub txt_Hdr_ClaimToInsAmt_ori_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Hdr_ClaimToInsAmt_ori.GotFocus
        '        flag_keypress_txt_Hdr_ClaimToInsAmt_ori = True

    End Sub

    Private Sub txt_Hdr_ClaimToInsAmt_ori_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Hdr_ClaimToInsAmt_ori.KeyPress
        flag_keypress_txt_Hdr_ClaimToInsAmt_ori = True

    End Sub

    Private Sub txt_Hdr_ClaimToInsAmt_ori_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Hdr_ClaimToInsAmt_ori.LostFocus


    End Sub


    Private Sub txt_Hdr_ClaimToInsAmt_ori_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Hdr_ClaimToInsAmt_ori.TextChanged
        If flag_keypress_txt_Hdr_ClaimToInsAmt_ori = True Then
            flag_keypress_txt_Hdr_ClaimToInsAmt_ori = False
            If Val(txt_Hdr_ClaimToInsAmt_ori.Text) < Val(txt_Hdr_OrgClaimAmt.Text) Then
                Call cal_office_amt_ori()
            End If

        End If

        show_org_dif()
    End Sub

    Private Sub txt_Hdr_ClaimToVNAmt_ori_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Hdr_ClaimToVNAmt_ori.GotFocus
        '        flag_keypress_txt_Hdr_ClaimToVNAmt_ori = True

    End Sub

    Private Sub txt_Hdr_ClaimToVNAmt_ori_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Hdr_ClaimToVNAmt_ori.KeyPress
        flag_keypress_txt_Hdr_ClaimToVNAmt_ori = True

        'Dim allowedChars As String = "0123456789."

        'If allowedChars.IndexOf(e.KeyChar) = -1 Then
        '    e.KeyChar = ""
        '    Exit Sub
        'End If

        'Dim currenttext As String

        'currenttext = txt_Hdr_ClaimToVNAmt_ori.Text & e.KeyChar

        'If e.KeyChar = "." Then
        '    If Mid(currenttext, 1, Len(currenttext) - 1).IndexOf(".") <> -1 Then
        '        e.KeyChar = ""
        '        Exit Sub
        '    End If
        'End If

    End Sub

    Private Sub txt_Hdr_ClaimToVNAmt_ori_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Hdr_ClaimToVNAmt_ori.KeyUp
        flag_keypress_txt_Hdr_ClaimToVNAmt_ori = True

        'If Not IsNumeric(txt_Hdr_ClaimToVNAmt_ori.Text) Then
        '    Exit Sub
        'End If

        If e.KeyCode <> Keys.Decimal Or txt_Hdr_ClaimToVNAmt_ori.Text.IndexOf(".") <> txt_Hdr_ClaimToVNAmt_ori.Text.Length - 1 Then
            '    Dim pos As Integer = txt_Hdr_ClaimToVNAmt_ori.SelectionStart
            '    If e.KeyCode = Keys.Back And txt_Hdr_ClaimToVNAmt_ori.Text.Length > 0 Then
            '        If pos = txt_Hdr_ClaimToVNAmt_ori.Text.Length Then
            '            txt_Hdr_ClaimToVNAmt_ori.Text = txt_Hdr_ClaimToVNAmt_ori.Text.Substring(0, txt_Hdr_ClaimToVNAmt_ori.Text.Length - 1)
            '            txt_Hdr_ClaimToVNAmt_ori.Select(pos, 0)
            '        ElseIf pos > 0 And pos < txt_Hdr_ClaimToVNAmt_ori.Text.Length Then
            '            txt_Hdr_ClaimToVNAmt_ori.Text = _
            '            txt_Hdr_ClaimToVNAmt_ori.Text.Substring(0, pos - 1) + _
            '            txt_Hdr_ClaimToVNAmt_ori.Text.Substring(pos, txt_Hdr_ClaimToVNAmt_ori.Text.Length - pos)
            '            txt_Hdr_ClaimToVNAmt_ori.Select(pos - 1, 0)
            '        End If
            '    End If

            '    If txt_Hdr_ClaimToVNAmt_ori.Text.Length = 0 Then
            '        txt_Hdr_ClaimToVNAmt_ori.Text = "0.00"
            '    Else
            '        txt_Hdr_ClaimToVNAmt_ori.Text = Decimal.Round(Convert.ToDecimal(txt_Hdr_ClaimToVNAmt_ori.Text), 2)
            '    End If

            '    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catovnamt_ori") = Val(txt_Hdr_ClaimToVNAmt_ori.Text)

            If Not (rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*ADD*~" Or _
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*NEW*~" Or _
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~" Or _
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*DEL*~") Then
                rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_creusr") = "~*UPD*~"
            End If

            ''calculate_HKOAmount("Header", 0, True)
            'calculate_HKOAmount(0)
            'txt_Hdr_ClaimToHKOAmt.Text = sReformatCurrency(Decimal.Round(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_catohkoamt"), 2))

            'cal_ClaimAmt_CAORDITM()
            'cal_ClaimAmt_CAORDDTL()

            'format_Approval(0)
        End If

    End Sub

    Private Sub txt_Hdr_ClaimToVNAmt_ori_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Hdr_ClaimToVNAmt_ori.LostFocus


    End Sub

    Private Sub txt_Hdr_ClaimToVNAmt_ori_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Hdr_ClaimToVNAmt_ori.TextChanged
        If flag_keypress_txt_Hdr_ClaimToVNAmt_ori = True Then
            flag_keypress_txt_Hdr_ClaimToVNAmt_ori = False
            If Val(txt_Hdr_ClaimToVNAmt_ori.Text) < Val(txt_Hdr_OrgClaimAmt.Text) Then
                Call cal_office_amt_ori()
            End If

        End If
        show_org_dif()

    End Sub

    Private Sub rbClaimAmtPer_C_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbClaimAmtPer_C.Click
        '   Call check_pot_val()

    End Sub

    Private Sub chkwait_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkwait.Click
        flag_chkwait_Click = True
        '''
        If chkwait.Checked = True Then
            If chkvalidclm.Checked <> True Then
                chkwait.Checked = False

                MsgBox("Only 'Valid Claim' could check for ready!")
                chkconfirmclm.Enabled = True
                chkvalidclm.Enabled = True

            End If

            If rs_CAORDDTL.Tables("result").Rows.Count = 0 _
            And (rbClaimAmtPer_I.Checked = True Or rbClaimAmtPer_S.Checked = True) Then
                chkwait.Checked = False
                MsgBox("There is no Item/Ship Reference, please click 'Quick Insert' to insert. ")
            End If

            If check_amt() = False Then
                chkwait.Checked = False
            End If

        End If
        '        chkconfirmclm.Enabled = True
    End Sub

    Private Sub dt_ref_date_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dt_ref_date.LostFocus
        'cbo_Hdr_ClaimAmtCurrency.Focus()
        txtReplaceClaimNo.Focus()

    End Sub

    Private Sub dt_ref_date_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dt_ref_date.ValueChanged

    End Sub
    Sub ori_lost_focus()
        Dim tmp_1i As Decimal
        Dim tmp_2i As Decimal
        Dim tmp_3i As Decimal
        Dim tmp_1o As Decimal
        Dim tmp_2o As Decimal
        Dim tmp_3o As Decimal
        Dim tmp_1c As String
        Dim tmp_2c As String
        Dim tmp_3c As String

        tmp_1i = Val(txt_Hdr_ClaimToInsAmt_ori.Text)
        tmp_2i = Val(txt_Hdr_ClaimToVNAmt_ori.Text)
        tmp_3i = Val(txt_Hdr_ClaimToHKOAmt_ori.Text)

        tmp_1c = cbo_Hdr_ClaimToInsAmtCur.Text
        tmp_2c = cbo_Hdr_ClaimToVNAmtCur.Text
        tmp_3c = cbo_Hdr_ClaimToHKOAmtCur.Text

        tmp_1o = cal_cur_rate(tmp_1i, tmp_1c)
        tmp_2o = cal_cur_rate(tmp_2i, tmp_2c)
        tmp_3o = cal_cur_rate(tmp_3i, tmp_3c)

        'If Val(txt_Hdr_ClaimToHKOAmt.Text) > Val(txt_Hdr_OrgClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text) Then
        If tmp_3o + (-1) * (Val(txt_Hdr_OrgClaimAmt.Text) - tmp_2o - tmp_1o) > 0.001 Then
            MsgBox("'Customer Amount' + 'Vendor Amount' + 'HK Office Amount'  >  'Proposed Claim Amount'.")
            not_allow_save = False
            '            txt_Hdr_ClaimToHKOAmt.Text = Val(txt_Hdr_OrgClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text)
            txt_Hdr_ClaimToHKOAmt_ori.ForeColor = Color.Red
            txt_Hdr_OrgClaimAmt.ForeColor = Color.Red
            txt_Hdr_ClaimToInsAmt_ori.ForeColor = Color.Red
            txt_Hdr_ClaimToVNAmt_ori.ForeColor = Color.Red
        End If

        'If Val(txt_Hdr_ClaimToHKOAmt.Text) < Val(txt_Hdr_OrgClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text) Then
        If tmp_3o < Val(txt_Hdr_OrgClaimAmt.Text) - tmp_2o - tmp_1o Then
            not_allow_save = True
            MsgBox("'Customer Amount' + 'Vendor Amount' + 'HK Office Amount'  <  'Proposed Claim Amount' !" & vbCrLf & "Please re-enter the amount.")
            '            txt_Hdr_ClaimToHKOAmt.Text = Val(txt_Hdr_OrgClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text)
            txt_Hdr_ClaimToHKOAmt_ori.Text = "0"
            txt_Hdr_ClaimToInsAmt_ori.Text = "0"
            txt_Hdr_ClaimToVNAmt_ori.Text = "0"

            txt_Hdr_OrgClaimAmt.ForeColor = Color.Black
            txt_Hdr_ClaimToHKOAmt_ori.ForeColor = Color.Black
            txt_Hdr_ClaimToInsAmt_ori.ForeColor = Color.Black
            txt_Hdr_ClaimToVNAmt_ori.ForeColor = Color.Black

        End If



        If tmp_3o = Val(txt_Hdr_OrgClaimAmt.Text) - tmp_2o - tmp_1o Then
            not_allow_save = False
        End If

        'If Val(txt_Hdr_ClaimToHKOAmt_ori.Text) > Val(txt_Hdr_OrgClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt_ori.Text) - Val(txt_Hdr_ClaimToVNAmt_ori.Text) Then
        '    MsgBox("'Customer Amount' + 'Vendor Amount' + 'HK Office Amount'  >  'Proposed Claim Amount'.")
        '    '            txt_Hdr_ClaimToHKOAmt_ori.Text = Val(txt_Hdr_OrgClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt_ori.Text) - Val(txt_Hdr_ClaimToVNAmt_ori.Text)
        '    txt_Hdr_ClaimToHKOAmt_ori.ForeColor = Color.Red
        '    txt_Hdr_OrgClaimAmt.ForeColor = Color.Red
        '    txt_Hdr_ClaimToInsAmt_ori.ForeColor = Color.Red
        '    txt_Hdr_ClaimToVNAmt_ori.ForeColor = Color.Red
        'End If

        'If Val(txt_Hdr_ClaimToHKOAmt_ori.Text) < Val(txt_Hdr_OrgClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt_ori.Text) - Val(txt_Hdr_ClaimToVNAmt_ori.Text) Then
        '    MsgBox("'Customer Amount' + 'Vendor Amount' + 'HK Office Amount'  <  'Proposed Claim Amount' !")
        '    '            txt_Hdr_ClaimToHKOAmt_ori.Text = Val(txt_Hdr_OrgClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt_ori.Text) - Val(txt_Hdr_ClaimToVNAmt_ori.Text)
        '    txt_Hdr_ClaimToHKOAmt_ori.Text = "0"
        '    txt_Hdr_ClaimToInsAmt_ori.Text = "0"
        '    txt_Hdr_ClaimToVNAmt_ori.Text = "0"
        'End If

    End Sub
    Sub ori_lost_focus12()
        Dim tmp_1i As Decimal
        Dim tmp_2i As Decimal
        Dim tmp_3i As Decimal
        Dim tmp_1o As Decimal
        Dim tmp_2o As Decimal
        Dim tmp_3o As Decimal
        Dim tmp_1c As String
        Dim tmp_2c As String
        Dim tmp_3c As String

        tmp_1i = Val(txt_Hdr_ClaimToInsAmt_ori.Text)
        tmp_2i = Val(txt_Hdr_ClaimToVNAmt_ori.Text)
        tmp_3i = Val(txt_Hdr_ClaimToHKOAmt_ori.Text)

        tmp_1c = cbo_Hdr_ClaimToInsAmtCur.Text
        tmp_2c = cbo_Hdr_ClaimToVNAmtCur.Text
        tmp_3c = cbo_Hdr_ClaimToHKOAmtCur.Text

        tmp_1o = cal_cur_rate(tmp_1i, tmp_1c)
        tmp_2o = cal_cur_rate(tmp_2i, tmp_2c)
        tmp_3o = cal_cur_rate(tmp_3i, tmp_3c)

        'If Val(txt_Hdr_ClaimToHKOAmt.Text) > Val(txt_Hdr_OrgClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text) Then
        If tmp_3o > Val(txt_Hdr_OrgClaimAmt.Text) - tmp_2o - tmp_1o Then
            MsgBox("'Customer Amount' + 'Vendor Amount' + 'HK Office Amount'  >  'Proposed Claim Amount'.")
            '            txt_Hdr_ClaimToHKOAmt.Text = Val(txt_Hdr_OrgClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text)
            txt_Hdr_ClaimToHKOAmt_ori.ForeColor = Color.Red
            txt_Hdr_OrgClaimAmt.ForeColor = Color.Red
            txt_Hdr_ClaimToInsAmt_ori.ForeColor = Color.Red
            txt_Hdr_ClaimToVNAmt_ori.ForeColor = Color.Red
        End If

        ''If Val(txt_Hdr_ClaimToHKOAmt.Text) < Val(txt_Hdr_OrgClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text) Then
        'If tmp_3o < Val(txt_Hdr_OrgClaimAmt.Text) - tmp_2o - tmp_1o Then
        '    MsgBox("'Customer Amount' + 'Vendor Amount' + 'HK Office Amount'  <  'Finalized Claim Amount' !")
        '    '            txt_Hdr_ClaimToHKOAmt.Text = Val(txt_Hdr_OrgClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text)
        '    txt_Hdr_ClaimToHKOAmt_ori.Text = "0"
        '    txt_Hdr_ClaimToInsAmt_ori.Text = "0"
        '    txt_Hdr_ClaimToVNAmt_ori.Text = "0"

        '    txt_Hdr_OrgClaimAmt.ForeColor = Color.Black
        '    txt_Hdr_ClaimToHKOAmt_ori.ForeColor = Color.Black
        '    txt_Hdr_ClaimToInsAmt_ori.ForeColor = Color.Black
        '    txt_Hdr_ClaimToVNAmt_ori.ForeColor = Color.Black

        'End If


        'If Val(txt_Hdr_ClaimToHKOAmt_ori.Text) > Val(txt_Hdr_OrgClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt_ori.Text) - Val(txt_Hdr_ClaimToVNAmt_ori.Text) Then
        '    MsgBox("'Customer Amount' + 'Vendor Amount' + 'HK Office Amount'  >  'Proposed Claim Amount'.")
        '    '            txt_Hdr_ClaimToHKOAmt_ori.Text = Val(txt_Hdr_OrgClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt_ori.Text) - Val(txt_Hdr_ClaimToVNAmt_ori.Text)
        '    txt_Hdr_ClaimToHKOAmt_ori.ForeColor = Color.Red
        '    txt_Hdr_OrgClaimAmt.ForeColor = Color.Red
        '    txt_Hdr_ClaimToInsAmt_ori.ForeColor = Color.Red
        '    txt_Hdr_ClaimToVNAmt_ori.ForeColor = Color.Red
        'End If
    End Sub

    Sub final_lost_focus()
        Dim tmp_1i As Decimal
        Dim tmp_2i As Decimal
        Dim tmp_3i As Decimal
        Dim tmp_1o As Decimal
        Dim tmp_2o As Decimal
        Dim tmp_3o As Decimal
        Dim tmp_1c As String
        Dim tmp_2c As String
        Dim tmp_3c As String
        Dim tmp_tor As Decimal


        tmp_1i = Val(txt_Hdr_ClaimToInsAmt.Text)
        tmp_2i = Val(txt_Hdr_ClaimToVNAmt.Text)
        tmp_3i = Val(txt_Hdr_ClaimToHKOAmt.Text)

        tmp_1c = cbo_Hdr_ClaimToInsAmtCur.Text
        tmp_2c = cbo_Hdr_ClaimToVNAmtCur.Text
        tmp_3c = cbo_Hdr_ClaimToHKOAmtCur.Text

        tmp_1o = cal_cur_rate(tmp_1i, tmp_1c)
        tmp_2o = cal_cur_rate(tmp_2i, tmp_2c)
        tmp_3o = cal_cur_rate(tmp_3i, tmp_3c)

        tmp_tor = cal_cur_rate3(gl_tor, "USD")

        txt_Hdr_FinalClaimAmt.ForeColor = Color.Black
        txt_Hdr_ClaimToHKOAmt.ForeColor = Color.Black
        txt_Hdr_ClaimToInsAmt.ForeColor = Color.Black
        txt_Hdr_ClaimToVNAmt.ForeColor = Color.Black

        not_allow_save = False

        'If Val(txt_Hdr_ClaimToHKOAmt.Text) > Val(txt_Hdr_FinalClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text) Then
        If tmp_3o + (-1) * (Val(txt_Hdr_FinalClaimAmt.Text) - tmp_2o - tmp_1o) > 0.001 Then
            not_allow_save = False
            ' MsgBox("'Finalized Customer Amount' + 'Finalized Vendor Amount' + 'Finalized HK Office Amount'  >  'Finalized Claim Amount'.")
            MsgBox("Total Claim To Amount (sum) > Finalized Claim Amount!")

            '            txt_Hdr_ClaimToHKOAmt.Text = Val(txt_Hdr_FinalClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text)
            txt_Hdr_ClaimToHKOAmt.ForeColor = Color.Red
            txt_Hdr_FinalClaimAmt.ForeColor = Color.Red
            txt_Hdr_ClaimToInsAmt.ForeColor = Color.Red
            txt_Hdr_ClaimToVNAmt.ForeColor = Color.Red
        End If

        'If Val(txt_Hdr_ClaimToHKOAmt.Text) < Val(txt_Hdr_FinalClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text) Then
        '        If tmp_3o < Val(txt_Hdr_FinalClaimAmt.Text) - tmp_2o - tmp_1o - tmp_tor Then
        If tmp_3o + (-1) * (Val(txt_Hdr_FinalClaimAmt.Text) - tmp_2o - tmp_1o - gl_tor) < -0.001 Then

            not_allow_save = True
            '            MsgBox("'Finalized Customer Amount' + 'Finalized Vendor Amount' + 'Finalized HK Office Amount'  <  'Finalized Claim Amount' !" & vbCrLf & "Please re-enter the amount.")
            MsgBox("Total Claim To Amount (sum) < Finalized Claim Amount!" & vbCrLf & "Please re-enter the amount.")

            '            txt_Hdr_ClaimToHKOAmt.Text = Val(txt_Hdr_FinalClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text)
            '20140610
            '            txt_Hdr_ClaimToHKOAmt.Text = "0"
            '           txt_Hdr_ClaimToInsAmt.Text = "0"
            '          txt_Hdr_ClaimToVNAmt.Text = "0"

            txt_Hdr_FinalClaimAmt.ForeColor = Color.Black
            txt_Hdr_ClaimToHKOAmt.ForeColor = Color.Black
            txt_Hdr_ClaimToInsAmt.ForeColor = Color.Black
            txt_Hdr_ClaimToVNAmt.ForeColor = Color.Black

        End If

        If tmp_3o = Val(txt_Hdr_FinalClaimAmt.Text) - tmp_2o - tmp_1o Then
            not_allow_save = False
        End If

    End Sub
    Sub final_lost_focus12()
        Dim tmp_1i As Decimal
        Dim tmp_2i As Decimal
        Dim tmp_3i As Decimal
        Dim tmp_1o As Decimal
        Dim tmp_2o As Decimal
        Dim tmp_3o As Decimal
        Dim tmp_1c As String
        Dim tmp_2c As String
        Dim tmp_3c As String

        tmp_1i = Val(txt_Hdr_ClaimToInsAmt.Text)
        tmp_2i = Val(txt_Hdr_ClaimToVNAmt.Text)
        tmp_3i = Val(txt_Hdr_ClaimToHKOAmt.Text)

        tmp_1c = cbo_Hdr_ClaimToInsAmtCur.Text
        tmp_2c = cbo_Hdr_ClaimToVNAmtCur.Text
        tmp_3c = cbo_Hdr_ClaimToHKOAmtCur.Text

        tmp_1o = cal_cur_rate(tmp_1i, tmp_1c)
        tmp_2o = cal_cur_rate(tmp_2i, tmp_2c)
        tmp_3o = cal_cur_rate(tmp_3i, tmp_3c)

        'If Val(txt_Hdr_ClaimToHKOAmt.Text) > Val(txt_Hdr_FinalClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text) Then
        If tmp_3o + (-1) * (Val(txt_Hdr_FinalClaimAmt.Text) - tmp_2o - tmp_1o) > 0.001 Then

            ''  If tmp_3o - (Val(txt_Hdr_FinalClaimAmt.Text) - tmp_2o - tmp_1o) > 0.0001 Then
            '            MsgBox("'Finalized Customer Amount' + 'Finalized Vendor Amount' + 'Finalized HK Office Amount'  >  'Finalized Claim Amount'.")
            MsgBox("Total Claim To Amount (sum) > Finalized Claim Amount!")

            '            txt_Hdr_ClaimToHKOAmt.Text = Val(txt_Hdr_FinalClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text)
            txt_Hdr_ClaimToHKOAmt.ForeColor = Color.Red
            txt_Hdr_FinalClaimAmt.ForeColor = Color.Red
            txt_Hdr_ClaimToInsAmt.ForeColor = Color.Red
            txt_Hdr_ClaimToVNAmt.ForeColor = Color.Red
        End If

        ''If Val(txt_Hdr_ClaimToHKOAmt.Text) < Val(txt_Hdr_FinalClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text) Then
        'If tmp_3o < Val(txt_Hdr_FinalClaimAmt.Text) - tmp_2o - tmp_1o Then
        '    MsgBox("'Customer Amount' + 'Vendor Amount' + 'HK Office Amount'  <  'Finalized Claim Amount' !")
        '    '            txt_Hdr_ClaimToHKOAmt.Text = Val(txt_Hdr_FinalClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text)
        '    txt_Hdr_ClaimToHKOAmt.Text = "0"
        '    txt_Hdr_ClaimToInsAmt.Text = "0"
        '    txt_Hdr_ClaimToVNAmt.Text = "0"

        '    txt_Hdr_FinalClaimAmt.ForeColor = Color.Black
        '    txt_Hdr_ClaimToHKOAmt.ForeColor = Color.Black
        '    txt_Hdr_ClaimToInsAmt.ForeColor = Color.Black
        '    txt_Hdr_ClaimToVNAmt.ForeColor = Color.Black

        'End If



    End Sub

    Sub final_lost_focus12_nomsg()
        Dim tmp_1i As Decimal
        Dim tmp_2i As Decimal
        Dim tmp_3i As Decimal
        Dim tmp_1o As Decimal
        Dim tmp_2o As Decimal
        Dim tmp_3o As Decimal
        Dim tmp_1c As String
        Dim tmp_2c As String
        Dim tmp_3c As String

        tmp_1i = Val(txt_Hdr_ClaimToInsAmt.Text)
        tmp_2i = Val(txt_Hdr_ClaimToVNAmt.Text)
        tmp_3i = Val(txt_Hdr_ClaimToHKOAmt.Text)

        tmp_1c = cbo_Hdr_ClaimToInsAmtCur.Text
        tmp_2c = cbo_Hdr_ClaimToVNAmtCur.Text
        tmp_3c = cbo_Hdr_ClaimToHKOAmtCur.Text

        tmp_1o = cal_cur_rate(tmp_1i, tmp_1c)
        tmp_2o = cal_cur_rate(tmp_2i, tmp_2c)
        tmp_3o = cal_cur_rate(tmp_3i, tmp_3c)

        If tmp_3o + (-1) * (Val(txt_Hdr_FinalClaimAmt.Text) - tmp_2o - tmp_1o) > 0.001 Then
            'If Val(txt_Hdr_ClaimToHKOAmt.Text) > Val(txt_Hdr_FinalClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text) Then
            ''    If tmp_3o - (Val(txt_Hdr_FinalClaimAmt.Text) - tmp_2o - tmp_1o) > 0.0001 Then
            'MsgBox("'Finalized Customer Amount' + 'Finalized Vendor Amount' + 'Finalized HK Office Amount'  >  'Finalized Claim Amount'.")
            '            txt_Hdr_ClaimToHKOAmt.Text = Val(txt_Hdr_FinalClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text)
            txt_Hdr_ClaimToHKOAmt.ForeColor = Color.Red
            txt_Hdr_FinalClaimAmt.ForeColor = Color.Red
            txt_Hdr_ClaimToInsAmt.ForeColor = Color.Red
            txt_Hdr_ClaimToVNAmt.ForeColor = Color.Red
        End If

        ''If Val(txt_Hdr_ClaimToHKOAmt.Text) < Val(txt_Hdr_FinalClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text) Then
        'If tmp_3o < Val(txt_Hdr_FinalClaimAmt.Text) - tmp_2o - tmp_1o Then
        '    MsgBox("'Customer Amount' + 'Vendor Amount' + 'HK Office Amount'  <  'Finalized Claim Amount' !")
        '    '            txt_Hdr_ClaimToHKOAmt.Text = Val(txt_Hdr_FinalClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text)
        '    txt_Hdr_ClaimToHKOAmt.Text = "0"
        '    txt_Hdr_ClaimToInsAmt.Text = "0"
        '    txt_Hdr_ClaimToVNAmt.Text = "0"

        '    txt_Hdr_FinalClaimAmt.ForeColor = Color.Black
        '    txt_Hdr_ClaimToHKOAmt.ForeColor = Color.Black
        '    txt_Hdr_ClaimToInsAmt.ForeColor = Color.Black
        '    txt_Hdr_ClaimToVNAmt.ForeColor = Color.Black

        'End If



    End Sub

    Private Sub txt_Hdr_ClaimToHKOAmt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Hdr_ClaimToHKOAmt.Validating

        If Val(txt_Hdr_ClaimToHKOAmt.Text) = 0 Then
            Exit Sub
        End If

        If Not IsNumeric(txt_Hdr_ClaimToHKOAmt.Text.Trim) Then
            MsgBox("Please Input Numeric Data.")
            txt_Hdr_ClaimToHKOAmt.Text = "0"
            txt_Hdr_ClaimToHKOAmt.Focus()
        End If

        Call final_lost_focus()
    End Sub

    Private Sub txt_Hdr_ClaimToHKOAmt_ori_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Hdr_ClaimToHKOAmt_ori.Validating

        If Val(txt_Hdr_ClaimToHKOAmt_ori.Text) = 0 Then
            Exit Sub
        End If

        If Not IsNumeric(txt_Hdr_ClaimToHKOAmt_ori.Text.Trim) Then
            MsgBox("Please Input Numeric Data.")
            txt_Hdr_ClaimToHKOAmt_ori.Text = "0"
            txt_Hdr_ClaimToHKOAmt_ori.Focus()
        End If


        'Call ori_lost_focus()
    End Sub

    Private Sub txt_Hdr_ClaimToInsAmt_ori_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Hdr_ClaimToInsAmt_ori.Validating
        If Val(txt_Hdr_ClaimToInsAmt_ori.Text) = 0 Then
            Exit Sub
        End If

        If Not IsNumeric(txt_Hdr_ClaimToInsAmt_ori.Text.Trim) Then
            MsgBox("Please Input Numeric Data.")
            txt_Hdr_ClaimToInsAmt_ori.Text = "0"
            txt_Hdr_ClaimToInsAmt_ori.Focus()
        End If

        'Call ori_lost_focus12()

    End Sub

    Private Sub txt_Hdr_ClaimToVNAmt_ori_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Hdr_ClaimToVNAmt_ori.Validating

        If Val(txt_Hdr_ClaimToVNAmt_ori.Text) = 0 Then
            Exit Sub
        End If

        If Not IsNumeric(txt_Hdr_ClaimToVNAmt_ori.Text.Trim) Then
            MsgBox("Please Input Numeric Data.")
            txt_Hdr_ClaimToVNAmt_ori.Text = "0"
            txt_Hdr_ClaimToVNAmt_ori.Focus()
        End If

        'Call ori_lost_focus12()
    End Sub

    Private Sub txt_Hdr_ClaimToInsAmt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Hdr_ClaimToInsAmt.Validating
        If Val(txt_Hdr_ClaimToInsAmt.Text) = 0 Then
            Exit Sub
        End If


        If Not IsNumeric(txt_Hdr_ClaimToInsAmt.Text.Trim) Then
            MsgBox("Please Input Numeric Data.")
            txt_Hdr_ClaimToInsAmt.Text = "0"
            txt_Hdr_ClaimToInsAmt.Focus()
        End If

        final_lost_focus12()
    End Sub

    Private Sub txt_Hdr_ClaimToVNAmt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Hdr_ClaimToVNAmt.Validating
        If Val(txt_Hdr_ClaimToVNAmt.Text) = 0 Then
            Exit Sub
        End If

        If Not IsNumeric(txt_Hdr_ClaimToVNAmt.Text.Trim) Then
            MsgBox("Please Input Numeric Data.")
            txt_Hdr_ClaimToVNAmt.Text = "0"
            txt_Hdr_ClaimToVNAmt.Focus()
        End If

        final_lost_focus12()
    End Sub

    Function cal_cur_rate(ByVal input_amt As Decimal, ByVal input_cur As String) As Decimal
        '''20131219 for same curcde
        Dim outputcur As String
        Dim rtn_amt As Decimal
        Dim cus1_rounding As Integer
        cus1_rounding = 4

        '''outputcur

        outputcur = cbo_Hdr_ClaimAmtCurrency.Text.Trim()

        If input_cur <> outputcur Then
            If outputcur = "USD" Then
                dr = rs_CUBASINF_CR.Tables("RESULT").Select("ysi_def = 'Y'")
                If outputcur = dr(0)("ysi_cde") Then
                    dr = rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " & "'" & input_cur & "'")
                    'rtn_amt = Format(roundup(input_amt * gl_rate), "########0.0000")
                    rtn_amt = Format(round(input_amt / gl_rate, cus1_rounding), "########0.0000")
                Else
                    dr = rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " & "'" & outputcur & "'")
                    'rtn_amt = Format(roundup(input_amt / gl_rate), "########0.0000")
                    If dr.Length > 0 Then
                        rtn_amt = Format(round(input_amt * gl_rate, cus1_rounding), "########0.0000")
                    End If
                End If
            Else ' not USD
                rtn_amt = Format(round(input_amt * gl_rate, cus1_rounding), "########0.0000")


            End If
        Else
            rtn_amt = Format(input_amt, "########0.0000")
        End If

        '        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_curcde") = outputcur

        cal_cur_rate = rtn_amt

    End Function
    Function cal_cur_rate2(ByVal input_amt As Decimal, ByVal input_cur As String) As Decimal
        '''20131219 for same curcde
        Dim FinalAmtcur As String
        Dim rtn_amt As Decimal
        Dim cus1_rounding As Integer
        cus1_rounding = 4

        '''FinalAmtcur
        FinalAmtcur = cbo_Hdr_ClaimAmtCurrency.Text.Trim()
        If input_cur = FinalAmtcur Then
            rtn_amt = input_amt
        Else
            If FinalAmtcur = "USD" Then
                'rtn_amt = input_cur * gl_rate
                rtn_amt = Format(round(input_amt * gl_rate, cus1_rounding), "########0.0000")
            Else ''
                rtn_amt = Format(round(input_amt / gl_rate, cus1_rounding), "########0.0000")

            End If
        End If

        cal_cur_rate2 = rtn_amt

    End Function

    Function cal_cur_rate3(ByVal input_amt As Decimal, ByVal input_cur As String) As Decimal
        '''20131219 for same curcde
        Dim FinalAmtcur As String
        Dim rtn_amt As Decimal
        Dim cus1_rounding As Integer
        cus1_rounding = 4

        '''FinalAmtcur
        FinalAmtcur = cbo_Hdr_ClaimAmtCurrency.Text.Trim()
        If input_cur = FinalAmtcur Then
            rtn_amt = input_amt
        Else
            rtn_amt = Format(round(input_amt * gl_rate, cus1_rounding), "########0.0000")
        End If

        cal_cur_rate3 = rtn_amt

    End Function

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

    Private Sub cbo_pay_cur_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_pay_cur.SelectedIndexChanged
        lbl_outamt_pay.Text = cbo_pay_cur.Text

        If rbClaimBy_U.Checked = True Then
            lbl_pay_amt.Text = "0"
        Else
            lbl_pay_amt.Text = cal_cur_rate(Val(txt_Hdr_FinalClaimAmt.Text), cbo_Hdr_ClaimAmtCurrency.Text.Trim)
            lbl_pay_amt.Text = round(cal_cur_rate2(Val(lbl_pay_amt.Text), cbo_pay_cur.Text), 2)
        End If
        lbl_income_amt.Text = cal_cur_rate(Val(txt_Hdr_ClaimToVNAmt.Text), cbo_Hdr_ClaimToVNAmtCur.Text.Trim) + cal_cur_rate(Val(txt_Hdr_ClaimToInsAmt.Text), cbo_Hdr_ClaimToInsAmtCur.Text.Trim)
        lbl_income_amt.Text = round(cal_cur_rate2(Val(lbl_income_amt.Text), cbo_income_cur.Text), 2)

    End Sub

    Private Sub cbo_income_cur_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_income_cur.SelectedIndexChanged
        lbl_outamt_income.Text = cbo_income_cur.Text

        If rbClaimBy_U.Checked = True Then
            lbl_pay_amt.Text = "0"
        Else
            lbl_pay_amt.Text = cal_cur_rate(Val(txt_Hdr_FinalClaimAmt.Text), cbo_Hdr_ClaimAmtCurrency.Text.Trim)
            lbl_pay_amt.Text = round(cal_cur_rate2(Val(lbl_pay_amt.Text), cbo_pay_cur.Text), 2)
        End If
        lbl_income_amt.Text = cal_cur_rate(Val(txt_Hdr_ClaimToVNAmt.Text), cbo_Hdr_ClaimToVNAmtCur.Text.Trim) + cal_cur_rate(Val(txt_Hdr_ClaimToInsAmt.Text), cbo_Hdr_ClaimToInsAmtCur.Text.Trim)
        lbl_income_amt.Text = round(cal_cur_rate2(Val(lbl_income_amt.Text), cbo_income_cur.Text), 2)



    End Sub

    Sub set_sal_mgt_cmt()


        '20140327
        'Approve Rights Table
        Dim temp_claim_type As String
        Dim temp_mgt_apprgt As Boolean

        Dim temp_claim_type_a As String
        Dim temp_claim_type_b As String

        temp_claim_type = Split(cboClaimType.Text, " - ")(0)


        Dim i As Integer
        For i = 0 To rs_CAORDHDR.Tables("RESULT").Columns.Count - 1
            rs_CAORDHDR.Tables("RESULT").Columns(i).ReadOnly = False
        Next i


        '''       rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a").

        '''usr-grp
        ''' usr-rank
        ''' which mgt
        gspStr = "sp_list_SYUSRPRF_1 '" & gsCompany & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_syusrpr, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If

        If rs_syusrpr.Tables("result").Rows.Count = 0 Then
            MsgBox("User group not found!")
            Exit Sub
        Else
            '''find out which user group
            'yup_usrid()
            'yup_usrgrp()
            For index4 As Integer = 0 To rs_syusrpr.Tables("result").Rows.Count - 1
                If gsUsrID = rs_syusrpr.Tables("RESULT").Rows(index4).Item("yup_usrid") Then
                    temp_yup_usrgrp = rs_syusrpr.Tables("RESULT").Rows(index4).Item("yup_usrgrp")
                End If
            Next
        End If

        temp_yup_usrgrp = gsUsrGrp


        ''' read table:  rights= y/n
        temp_mgt_apprgt = False
        For index5 As Integer = 0 To rs_SYCLMTYP.Tables("result").Rows.Count - 1
            If temp_claim_type = rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_cde") Then
                If temp_yup_usrgrp = "SAL-S" Then
                    If rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_SMApprgt") = "Y" Then
                        temp_mgt_apprgt = True
                    End If
                ElseIf temp_yup_usrgrp = "SAL-ZS" Then
                    If rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_SZApprgt") = "Y" Then
                        temp_mgt_apprgt = True
                    End If
                ElseIf temp_yup_usrgrp = "SHP-S" Then
                    If rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_ShpApprgt") = "Y" Then
                        temp_mgt_apprgt = True
                    End If
                Else
                    temp_mgt_apprgt = False
                End If

            End If
        Next

        '''AmtApp
        '''text amt final
        Dim temp_finalclmamt As Decimal
        temp_finalclmamt = Val(txt_Hdr_FinalClaimAmt.Text)
        If cbo_Hdr_ClaimAmtCurrency.Text.Trim <> "USD" Then
            temp_finalclmamt = temp_finalclmamt / gl_rate
        End If
        '''amt in the table
        ''comapre
        For index5 As Integer = 0 To rs_SYCLMTYP.Tables("result").Rows.Count - 1
            If temp_claim_type = rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_cde") Then
                If temp_finalclmamt <= IIf(IsDBNull(rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_appamt")), 0, rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_appamt")) Then
                    If temp_mgt_apprgt = True Then
                        temp_mgt_apprgt = True ''' second check for Approve right
                    End If
                Else
                    temp_mgt_apprgt = False
                End If

            End If
        Next


        ''check:
        If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "SAL" And gsUsrRank = 3 Then
            If sClaimStatus = "WAIT" Then
                If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                    txt_cmt_a.Enabled = True
                    txt_cmt_a.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                    txt_cmt_a.ReadOnly = False
                Else
                    txt_cmt_a.Enabled = True
                End If

                If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                    txt_cmt_b.Enabled = True
                    txt_cmt_b.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                    txt_cmt_b.ReadOnly = False
                Else
                    txt_cmt_b.Enabled = True
                End If

            ElseIf sClaimStatus = "APRV" Then
                If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                    txt_cmt_a.Enabled = True
                    txt_cmt_a.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                    txt_cmt_a.ReadOnly = False
                Else
                    txt_cmt_a.Enabled = True
                End If

                If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                    txt_cmt_b.Enabled = True
                    txt_cmt_b.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                    txt_cmt_b.ReadOnly = False
                Else
                    txt_cmt_b.Enabled = True
                End If


                If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a") = "APV2a" Then
                    If temp_mgt_apprgt <> True Then
                        If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                            txt_cmt_a.Enabled = True
                            txt_cmt_a.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                            txt_cmt_a.ReadOnly = True
                        Else
                            txt_cmt_a.Enabled = True
                        End If

                    End If
                End If
                If rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a") = "APV2b" Then
                    If temp_mgt_apprgt <> True Then
                        If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                            txt_cmt_b.Enabled = True
                            txt_cmt_b.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                            txt_cmt_b.ReadOnly = True
                        Else
                            txt_cmt_b.Enabled = True
                        End If

                    End If
                End If

            End If
        End If

        If sClaimStatus = "RELS" Then
            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                txt_cmt_a.Enabled = True
                txt_cmt_a.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_cmt_a.ReadOnly = True
            Else
                txt_cmt_a.Enabled = True
            End If

            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then
                txt_cmt_b.Enabled = True
                txt_cmt_b.ScrollBars = RichTextBoxScrollBars.ForcedVertical
                txt_cmt_b.ReadOnly = True
            Else
                txt_cmt_b.Enabled = True
            End If


        End If


    End Sub
    Sub setall_readmode()

        '20140327
        'Approve Rights Table
        Dim temp_claim_type As String
        Dim temp_mgt_apprgt As Boolean

        Dim temp_claim_type_a As String
        Dim temp_claim_type_b As String

        temp_claim_type = Split(cboClaimType.Text, " - ")(0)


        Dim i As Integer
        For i = 0 To rs_CAORDHDR.Tables("RESULT").Columns.Count - 1
            rs_CAORDHDR.Tables("RESULT").Columns(i).ReadOnly = False
        Next i


        '''       rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_caordsts_a").

        '''usr-grp
        ''' usr-rank
        ''' which mgt
        gspStr = "sp_list_SYUSRPRF_1 '" & gsCompany & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_syusrpr, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If

        If rs_syusrpr.Tables("result").Rows.Count = 0 Then
            MsgBox("User group not found!")
            Exit Sub
        Else
            '''find out which user group
            'yup_usrid()
            'yup_usrgrp()
            For index4 As Integer = 0 To rs_syusrpr.Tables("result").Rows.Count - 1
                If gsUsrID = rs_syusrpr.Tables("RESULT").Rows(index4).Item("yup_usrid") Then
                    temp_yup_usrgrp = rs_syusrpr.Tables("RESULT").Rows(index4).Item("yup_usrgrp")
                End If
            Next
        End If

        temp_yup_usrgrp = gsUsrGrp


        ''' read table:  rights= y/n
        temp_mgt_apprgt = False
        For index5 As Integer = 0 To rs_SYCLMTYP.Tables("result").Rows.Count - 1
            If temp_claim_type = rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_cde") Then
                If temp_yup_usrgrp = "SAL-S" Then
                    If rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_SMApprgt") = "Y" Then
                        temp_mgt_apprgt = True
                    End If
                ElseIf temp_yup_usrgrp = "SAL-ZS" Then
                    If rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_SZApprgt") = "Y" Then
                        temp_mgt_apprgt = True
                    End If
                ElseIf temp_yup_usrgrp = "SHP-S" Then
                    If rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_ShpApprgt") = "Y" Then
                        temp_mgt_apprgt = True
                    End If
                Else
                    temp_mgt_apprgt = False
                End If

            End If
        Next

        '''AmtApp
        '''text amt final
        Dim temp_finalclmamt As Decimal
        temp_finalclmamt = Val(txt_Hdr_FinalClaimAmt.Text)
        If cbo_Hdr_ClaimAmtCurrency.Text.Trim <> "USD" Then
            temp_finalclmamt = temp_finalclmamt / gl_rate
        End If
        '''amt in the table
        ''comapre
        For index5 As Integer = 0 To rs_SYCLMTYP.Tables("result").Rows.Count - 1
            If temp_claim_type = rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_cde") Then
                If temp_finalclmamt <= IIf(IsDBNull(rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_appamt")), 0, rs_SYCLMTYP.Tables("RESULT").Rows(index5).Item("yct_appamt")) Then
                    If temp_mgt_apprgt = True Then
                        temp_mgt_apprgt = True ''' second check for Approve right
                    End If
                Else
                    temp_mgt_apprgt = False
                End If

            End If
        Next

        ''check:
        If sClaimStatus = "RELS" Then
            If Microsoft.VisualBasic.Left(gsUsrGrp, 3) <> "ACT" Then
                Call setStatus(cModeRead)
                mode = cModeRead
                '''mgt right
                If gsUsrRank < 3 Or temp_mgt_apprgt = True Then
                    chkapv2a.Enabled = True
                    chkapv2b.Enabled = True

                     If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then  
                 txt_cmt_a.Enabled = True   
                   txt_cmt_a.ScrollBars = RichTextBoxScrollBars.ForcedVertical    
                    txt_cmt_a.ReadOnly = False  
               Else    
                   txt_cmt_a.Enabled = True  
              End If 
 
                     If Microsoft.VisualBasic.Left(gsUsrGrp, 3) = "ACT" Then  
                 txt_cmt_b.Enabled = True   
                   txt_cmt_b.ScrollBars = RichTextBoxScrollBars.ForcedVertical    
                    txt_cmt_b.ReadOnly = False  
               Else    
                   txt_cmt_b.Enabled = True  
              End If 
 

                End If
            End If
        ElseIf sClaimStatus = "APRV" Then

            If gsUsrRank > 3 Then
                Call setStatus(cModeRead)
                mode = cModeRead
            End If
        End If



        mode = cModeUpd


    End Sub
    Function check_amt() As Boolean
        check_amt = True
        If Not chkreplace.Checked = True Then
            If Val(txt_Hdr_OrgClaimAmt.Text) <= 0 Then
                MsgBox("The proposed amount should be > 0.")
                check_amt = False
                Exit Function
            End If
        End If

        '''''''
        Dim tmp_1i As Decimal
        Dim tmp_2i As Decimal
        Dim tmp_3i As Decimal
        Dim tmp_1o As Decimal
        Dim tmp_2o As Decimal
        Dim tmp_3o As Decimal
        Dim tmp_1c As String
        Dim tmp_2c As String
        Dim tmp_3c As String

        tmp_1i = Val(txt_Hdr_ClaimToInsAmt.Text)
        tmp_2i = Val(txt_Hdr_ClaimToVNAmt.Text)
        tmp_3i = Val(txt_Hdr_ClaimToHKOAmt.Text)

        tmp_1c = cbo_Hdr_ClaimToInsAmtCur.Text
        tmp_2c = cbo_Hdr_ClaimToVNAmtCur.Text
        tmp_3c = cbo_Hdr_ClaimToHKOAmtCur.Text

        tmp_1o = cal_cur_rate(tmp_1i, tmp_1c)
        tmp_2o = cal_cur_rate(tmp_2i, tmp_2c)
        tmp_3o = cal_cur_rate(tmp_3i, tmp_3c)


        'If Val(txt_Hdr_ClaimToHKOAmt.Text) < Val(txt_Hdr_FinalClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text) Then
        'If tmp_3o < Val(txt_Hdr_FinalClaimAmt.Text) - tmp_2o - tmp_1o - gl_tor Then
        If tmp_3o + (-1) * (Val(txt_Hdr_FinalClaimAmt.Text) - tmp_2o - tmp_1o - gl_tor) < -0.001 Then
            '            MsgBox("'Finalized Customer Amount' + 'Finalized Vendor Amount' + 'Finalized HK Office Amount'  <  'Finalized Claim Amount' !" & vbCrLf & "Please re-enter the amount.")
            MsgBox("Total Claim To Amount (sum) < Finalized Claim Amount!" & vbCrLf & "Please re-enter the amount.")

            '            txt_Hdr_ClaimToHKOAmt.Text = Val(txt_Hdr_FinalClaimAmt.Text) - Val(txt_Hdr_ClaimToInsAmt.Text) - Val(txt_Hdr_ClaimToVNAmt.Text)
            '            txt_Hdr_ClaimToHKOAmt.Text = "0"
            '           txt_Hdr_ClaimToInsAmt.Text = "0"
            '          txt_Hdr_ClaimToVNAmt.Text = "0"

            txt_Hdr_FinalClaimAmt.ForeColor = Color.Black
            txt_Hdr_ClaimToHKOAmt.ForeColor = Color.Black
            txt_Hdr_ClaimToInsAmt.ForeColor = Color.Black
            txt_Hdr_ClaimToVNAmt.ForeColor = Color.Black

            check_amt = False
            Exit Function

        End If
    End Function

    Sub show_final_dif()

        Dim tmp_1i As Decimal
        Dim tmp_2i As Decimal
        Dim tmp_3i As Decimal
        Dim tmp_1o As Decimal
        Dim tmp_2o As Decimal
        Dim tmp_3o As Decimal
        Dim tmp_1c As String
        Dim tmp_2c As String
        Dim tmp_3c As String

        tmp_1i = Val(txt_Hdr_ClaimToInsAmt.Text)
        tmp_2i = Val(txt_Hdr_ClaimToVNAmt.Text)
        tmp_3i = Val(txt_Hdr_ClaimToHKOAmt.Text)

        tmp_1c = cbo_Hdr_ClaimToInsAmtCur.Text
        tmp_2c = cbo_Hdr_ClaimToVNAmtCur.Text
        tmp_3c = cbo_Hdr_ClaimToHKOAmtCur.Text

        tmp_1o = cal_cur_rate(tmp_1i, tmp_1c)
        tmp_2o = cal_cur_rate(tmp_2i, tmp_2c)
        tmp_3o = cal_cur_rate(tmp_3i, tmp_3c)


        txt_final_dif.Text = Format(round(Val(txt_Hdr_FinalClaimAmt.Text) - tmp_2o - tmp_1o - tmp_3o, 4), "########0.0000")
    End Sub
    Sub show_org_dif()

        Dim tmp_1i As Decimal
        Dim tmp_2i As Decimal
        Dim tmp_3i As Decimal
        Dim tmp_1o As Decimal
        Dim tmp_2o As Decimal
        Dim tmp_3o As Decimal
        Dim tmp_1c As String
        Dim tmp_2c As String
        Dim tmp_3c As String

        tmp_1i = Val(txt_Hdr_ClaimToInsAmt_ori.Text)
        tmp_2i = Val(txt_Hdr_ClaimToVNAmt_ori.Text)
        tmp_3i = Val(txt_Hdr_ClaimToHKOAmt_ori.Text)

        tmp_1c = cbo_Hdr_ClaimToInsAmtCur.Text
        tmp_2c = cbo_Hdr_ClaimToVNAmtCur.Text
        tmp_3c = cbo_Hdr_ClaimToHKOAmtCur.Text

        tmp_1o = cal_cur_rate(tmp_1i, tmp_1c)
        tmp_2o = cal_cur_rate(tmp_2i, tmp_2c)
        tmp_3o = cal_cur_rate(tmp_3i, tmp_3c)

        txt_org_dif.Text = round(Val(txt_Hdr_OrgClaimAmt.Text) - tmp_2o - tmp_1o - tmp_3o, 4)

    End Sub

    Private Sub cbo_Hdr_ClaimToHKOAmtCur_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Hdr_ClaimToHKOAmtCur.SelectedIndexChanged
        show_org_dif()
        show_final_dif()
    End Sub

    Private Sub cbo_Hdr_ClaimToVNAmtCur_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Hdr_ClaimToVNAmtCur.SelectedIndexChanged
        show_org_dif()
        show_final_dif()
        If rbClaimBy_C.Checked = True Then
            cbo_Hdr_ClaimToHKOAmtCur.Text = cbo_Hdr_ClaimToVNAmtCur.Text
            txt_Hdr_ClaimToVNAmt.Text = ""
            txt_Hdr_ClaimToHKOAmt.Text = ""
            txt_Hdr_ClaimToVNAmt_ori.Text = ""
            txt_Hdr_ClaimToHKOAmt_ori.Text = ""
        End If



    End Sub

    Private Sub cbo_Hdr_ClaimToInsAmtCur_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Hdr_ClaimToInsAmtCur.SelectedIndexChanged
        show_org_dif()
        show_final_dif()
        If rbClaimBy_V.Checked = True Then
            cbo_Hdr_ClaimToHKOAmtCur.Text = cbo_Hdr_ClaimToInsAmtCur.Text
            txt_Hdr_ClaimToInsAmt.Text = ""
            txt_Hdr_ClaimToHKOAmt.Text = ""
            txt_Hdr_ClaimToInsAmt_ori.Text = ""
            txt_Hdr_ClaimToHKOAmt_ori.Text = ""
        End If

    End Sub
    Sub uncheck2()
        chkapv1a.Enabled = True
        chkapv1b.Enabled = True
        chkapv2a.Enabled = True
        chkapv2b.Enabled = True
    End Sub

    Private Sub chkconfirmclm_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkconfirmclm.Click
        Call check_pot_val()
    End Sub

    Private Sub chkvalidclm_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkvalidclm.Click
        Call check_pot_val()
    End Sub

    Private Sub txt_Hdr_CustComment_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Hdr_CustComment.LostFocus
        'txt_ref_no.Focus()
    End Sub

    Private Sub txt_Hdr_Rmk_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Hdr_Rmk.LostFocus
        txt_ref_no.Focus()
    End Sub

    Private Sub cbo_Hdr_ClaimToHKOAmtCur_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbo_Hdr_ClaimToHKOAmtCur.Validating
        Call final_lost_focus()
    End Sub

    Private Sub dtHDRPAIDDAT_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        Dim tmpstr As String
        If dtHDRPAIDDAT.Text.Trim() <> "" Then
            If Not IsDBNull(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_upddat")) Then

                tmpstr = Format(dtHDRPAIDDAT.Text, "MM/dd/yyyy")
                If tmpstr <> Format(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_upddat"), "MM/dd/yyyy") Then
                    '''
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_upddat") = Format(Today.Date, "MM/dd/yyyy")
                End If

            End If

        End If
    End Sub

    Private Sub dtHDRRCVDAT_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        Dim tmpstr As String

        If dtHDRRCVDAT.Text.Trim() <> "" Then
            If Not IsDBNull(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_RCVDAT")) Then
                tmpstr = Format(dtHDRRCVDAT.Text, "MM/dd/yyyy")
                If tmpstr <> Format(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_RCVDAT"), "MM/dd/yyyy") Then
                    '''
                    rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_upddat") = Format(Today.Date, "MM/dd/yyyy")
                End If
            End If
        End If

    End Sub

    Private Sub txt_Hdr_OrgClaimAmt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Hdr_OrgClaimAmt.Validating

        If Val(txt_Hdr_OrgClaimAmt.Text) = 0 Then
            Exit Sub
        End If

        If Not IsNumeric(txt_Hdr_OrgClaimAmt.Text.Trim) Then
            MsgBox("Please Input Numeric Data.")
            txt_Hdr_OrgClaimAmt.Text = "0"
            txt_Hdr_OrgClaimAmt.Focus()
        End If

    End Sub

    Private Sub txt_Hdr_FinalClaimAmt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Hdr_FinalClaimAmt.Validating
        If Val(txt_Hdr_FinalClaimAmt.Text) = 0 Then
            Exit Sub
        End If

        If Not IsNumeric(txt_Hdr_FinalClaimAmt.Text.Trim) Then
            MsgBox("Please Input Numeric Data.")
            txt_Hdr_FinalClaimAmt.Text = "0"
            txt_Hdr_FinalClaimAmt.Focus()
        End If

    End Sub

    Private Sub cboVendor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendor.SelectedIndexChanged
        'If rbClaimBy_V.Checked = True Or rbClaimBy_U.Checked = True Then
        '    If checkValidCombo(cboVendor, cboVendor.Text) Then
        '        Call format_cboSecCust(Split(cboPriCust.Text, " - ")(0).ToString)
        '    End If
        'End If

    End Sub

    Private Sub txt_pay_actamt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_pay_actamt.Validating

        If Val(txt_pay_actamt.Text) = 0 Then
            Exit Sub
        End If

        If Not IsNumeric(txt_pay_actamt.Text.Trim) Then
            MsgBox("Please Input Numeric Data.")
            txt_pay_actamt.Text = "0"
            txt_pay_actamt.Focus()
        End If

    End Sub

    Private Sub txt_pay_potamt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_pay_potamt.Validating

        If Val(txt_pay_potamt.Text) = 0 Then
            Exit Sub
        End If

        If Not IsNumeric(txt_pay_potamt.Text.Trim) Then
            MsgBox("Please Input Numeric Data.")
            txt_pay_potamt.Text = "0"
            txt_pay_potamt.Focus()
        End If

    End Sub

    Private Sub txt_income_actamt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_income_actamt.Validating
        If Val(txt_income_actamt.Text) = 0 Then
            Exit Sub
        End If


        If Not IsNumeric(txt_income_actamt.Text.Trim) Then
            MsgBox("Please Input Numeric Data.")
            txt_income_actamt.Text = "0"
            txt_income_actamt.Focus()
        End If

    End Sub

    Private Sub txt_income_potamt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_income_potamt.Validating
        If Val(txt_income_potamt.Text) = 0 Then
            Exit Sub
        End If

        If Not IsNumeric(txt_income_potamt.Text.Trim) Then
            MsgBox("Please Input Numeric Data.")
            txt_income_potamt.Text = "0"
            txt_income_potamt.Focus()
        End If

    End Sub


    Private Sub cboClaimPaySTS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboClaimPaySTS.Click
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_upddat") = Format(Today.Date, "MM/dd/yyyy")
    End Sub


    Private Sub cboClaimPaySTS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClaimPaySTS.SelectedIndexChanged
        Dim tmpstr As String
        tmpstr = cboClaimPaySTS.Text
        If tmpstr <> rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_PAYSTS") Then
            '''
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_upddat") = Format(Today.Date, "MM/dd/yyyy")
        End If

    End Sub

    Private Sub cboClaimIncomeSTS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboClaimIncomeSTS.Click
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_upddat") = Format(Today.Date, "MM/dd/yyyy")

    End Sub

    Private Sub cboClaimIncomeSTS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClaimIncomeSTS.SelectedIndexChanged
        Dim tmpstr As String
        tmpstr = cboClaimIncomeSTS.Text
        If tmpstr <> rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_INCOMESTS") Then
            '   rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_INCOMESTS") = tmpstr
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_upddat") = Format(Today.Date, "MM/dd/yyyy")
        End If
    End Sub

    Private Sub txt_income_rmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_income_rmk.TextChanged

    End Sub

    Private Sub txt_pay_rmk_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pay_rmk.TextChanged

    End Sub

    Private Sub cboSETTLE_CUS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSETTLE_CUS.Click
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_pay_upddat") = Format(Today.Date, "MM/dd/yyyy")

    End Sub


    Private Sub cboSETTLE_CUS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSETTLE_CUS.SelectedIndexChanged
        Dim tmpstr As String
        tmpstr = cboSETTLE_FTY.Text
        If tmpstr <> rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_SETTLE_FTY") Then
            '''
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_upddat") = Format(Today.Date, "MM/dd/yyyy")
        End If
    End Sub

    Private Sub cboSETTLE_FTY_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSETTLE_FTY.Click
        rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_upddat") = Format(Today.Date, "MM/dd/yyyy")

    End Sub

    Private Sub cboSETTLE_FTY_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSETTLE_FTY.SelectedIndexChanged
        Dim tmpstr As String
        tmpstr = cboSETTLE_FTY.Text
        If tmpstr <> rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_SETTLE_FTY") Then
            '''
            rs_CAORDHDR.Tables("RESULT").Rows(0).Item("cah_income_upddat") = Format(Today.Date, "MM/dd/yyyy")
        End If

    End Sub

    Private Sub cboPriCust_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboPriCust.Validating
        Dim i As Integer
        Dim Y As Integer
        Dim inCombo As Boolean

        i = cboPriCust.Items.Count
        If cboPriCust.Text <> "" And cboPriCust.Enabled = True And cboPriCust.Items.Count > 0 Then
            For Y = 0 To i - 1
                If Trim(cboPriCust.Text) = Trim(cboPriCust.Items(Y)) Then
                    inCombo = True
                End If
            Next

            If inCombo = False Then
                MsgBox("Primary Customer - Data is Invalid, please select in Drop Down List.")
                btcCLM00001.SelectedIndex = 0
                e.Cancel = True

                cboPriCust.Text = ""
                cboPriCust.Focus()

            Else

            End If
        End If
    End Sub


    Private Sub txtReplaceClaimNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReplaceClaimNo.LostFocus
        cbo_Hdr_ClaimAmtCurrency.Focus()
    End Sub

   

    Function check_save() As Boolean
        check_save = True
        If chkwait.Checked = True And chkconfirmclm.Checked = True Then

            check_save = False

            chkwait.Enabled = True
            chkconfirmclm.Enabled = True
            chkvalidclm.Enabled = True

            MsgBox("Only 'Valid Claim' could check for ready!")

        End If
    End Function

  
    Private Sub mmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdPrint.Click
        If checkFocus(Me) Then Exit Sub
        FrmCLR00001 = New CLR00001
        FrmCLR00001.txtdocno.Text = txtClaimNo.Text
        FrmCLR00001.txtdocno.Enabled = False


        FrmCLR00001.ShowDialog()
    End Sub


    Private Sub mmdAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAttach.Click
        If checkFocus(Me) Then Exit Sub

        Dim formattch As New frmAttchUpload
        Dim tmep_doc_no As String

        formattch.setModule("CLM")
        '        CompanyName, "CLM#"
        tmep_doc_no = txtClaimNo.Text

        formattch.setDoc("UCP", tmep_doc_no)
        formattch.setDoc_sts(rs_CAORDHDR.Tables("RESULT").Rows(0).Item("CAH_CAORDSTS"))

        formattch.ShowDialog()
        formattch = Nothing
    End Sub

    Private Sub mmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelete.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdCopy.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdFunction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFunction.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdLink.Click
        If checkFocus(Me) Then Exit Sub
    End Sub
End Class













