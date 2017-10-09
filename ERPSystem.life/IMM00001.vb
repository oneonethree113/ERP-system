Imports System.IO

Public Class IMM00001
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
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdLast As System.Windows.Forms.Button
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdDelRow As System.Windows.Forms.Button
    Friend WithEvents cmdFirst As System.Windows.Forms.Button
    Friend WithEvents cmdInsRow As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents lblItmNo As System.Windows.Forms.Label
    Friend WithEvents txtItmNo As System.Windows.Forms.TextBox
    Friend WithEvents lblItmTyp As System.Windows.Forms.Label
    Friend WithEvents txtItmdsc As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents gbIMStatus As System.Windows.Forms.GroupBox
    Friend WithEvents rbIMStatus_History As System.Windows.Forms.RadioButton
    Friend WithEvents rbIMStatus_Current As System.Windows.Forms.RadioButton
    Friend WithEvents gbIMTyp As System.Windows.Forms.GroupBox
    Friend WithEvents rbIMTyp_PCIM As System.Windows.Forms.RadioButton
    Friend WithEvents rbIMTyp_IM As System.Windows.Forms.RadioButton
    Friend WithEvents cbTmpItm As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgPV As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPageMain As ERPSystem.BaseTabControl
    Friend WithEvents cboEV As System.Windows.Forms.ComboBox
    Friend WithEvents lblEV As System.Windows.Forms.Label
    Friend WithEvents cboTV As System.Windows.Forms.ComboBox
    Friend WithEvents lblTV As System.Windows.Forms.Label
    Friend WithEvents cboCV As System.Windows.Forms.ComboBox
    Friend WithEvents lblCV As System.Windows.Forms.Label
    Friend WithEvents cboDV As System.Windows.Forms.ComboBox
    Friend WithEvents lblDV As System.Windows.Forms.Label
    Friend WithEvents lblPV As System.Windows.Forms.Label
    Friend WithEvents lblEngDsc As System.Windows.Forms.Label
    Friend WithEvents lblChnDsc As System.Windows.Forms.Label
    Friend WithEvents dgCostPrice As System.Windows.Forms.DataGridView
    Friend WithEvents txtEngDsc As System.Windows.Forms.RichTextBox
    Friend WithEvents lblItmNature As System.Windows.Forms.Label
    Friend WithEvents cboItmNature As System.Windows.Forms.ComboBox
    Friend WithEvents lblMaterial As System.Windows.Forms.Label
    Friend WithEvents cboMaterial As System.Windows.Forms.ComboBox
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents txtChnDsc As System.Windows.Forms.RichTextBox
    Friend WithEvents cboPrdTyp As System.Windows.Forms.ComboBox
    Friend WithEvents lblPrdTyp As System.Windows.Forms.Label
    Friend WithEvents dgColor As System.Windows.Forms.DataGridView
    Friend WithEvents txtDsgItmNo As System.Windows.Forms.TextBox
    Friend WithEvents lblDsgItmNo As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboPrdGroup As System.Windows.Forms.ComboBox
    Friend WithEvents txtPrdSizeValue As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboPrdSizeTyp As System.Windows.Forms.ComboBox
    Friend WithEvents cboPrdSizeUnit As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cboPrdIcon As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cboDevTeam As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cboDesigner As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cboSeason As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblOEMCustomer As System.Windows.Forms.Label
    Friend WithEvents dgOEMCustomer As System.Windows.Forms.DataGridView
    Friend WithEvents lblExclCustomer As System.Windows.Forms.Label
    Friend WithEvents dgExclCustomer As System.Windows.Forms.DataGridView
    Friend WithEvents lblMatBreakdown As System.Windows.Forms.Label
    Friend WithEvents dgMatBreakdown As System.Windows.Forms.DataGridView
    Friend WithEvents lblCusStyle As System.Windows.Forms.Label
    Friend WithEvents dgCusStyle As System.Windows.Forms.DataGridView
    Friend WithEvents gbMOQMOA As System.Windows.Forms.GroupBox
    Friend WithEvents rbTier_CompDef As System.Windows.Forms.RadioButton
    Friend WithEvents rbTier_Standard As System.Windows.Forms.RadioButton
    Friend WithEvents txtMOAAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtMOQQty As System.Windows.Forms.TextBox
    Friend WithEvents cboMOACurr As System.Windows.Forms.ComboBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cboMOQUM As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtPerMultQty As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents dgBOMASS As System.Windows.Forms.DataGridView
    Friend WithEvents lblPacking As System.Windows.Forms.Label
    Friend WithEvents dgPacking As System.Windows.Forms.DataGridView
    Friend WithEvents cboItmVenTyp As System.Windows.Forms.ComboBox
    Friend WithEvents lblItmVenTyp As System.Windows.Forms.Label
    Friend WithEvents gbAddreq As System.Windows.Forms.GroupBox
    Friend WithEvents cbAddreq_ster As System.Windows.Forms.CheckBox
    Friend WithEvents cbAddreq_ccib As System.Windows.Forms.CheckBox
    Friend WithEvents cbAddreq_formA As System.Windows.Forms.CheckBox
    Friend WithEvents txtItmRmk As System.Windows.Forms.RichTextBox
    Friend WithEvents lblItmRmk As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboPrdLne As System.Windows.Forms.ComboBox
    Friend WithEvents txtAlsitmcol As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtAlsitmno As System.Windows.Forms.TextBox
    Friend WithEvents gbPriceView As System.Windows.Forms.GroupBox
    Friend WithEvents rbPriceView_S As System.Windows.Forms.RadioButton
    Friend WithEvents rbPriceView_F As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents rbBOMASS_BOM As System.Windows.Forms.RadioButton
    Friend WithEvents rbBOMASS_ASS As System.Windows.Forms.RadioButton
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents dgRelParentItem As System.Windows.Forms.DataGridView
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents IMTreeView As System.Windows.Forms.TreeView
    Friend WithEvents rbPriceView_P As System.Windows.Forms.RadioButton
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents lblCstRmk As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents txtCstExpDat As System.Windows.Forms.TextBox
    Friend WithEvents cboItmTyp As System.Windows.Forms.ComboBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cboConstrMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboHstuUSA As System.Windows.Forms.ComboBox
    Friend WithEvents cboHstuEur As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtHstuEURDuty As System.Windows.Forms.TextBox
    Friend WithEvents txtHstuUSADuty As System.Windows.Forms.TextBox
    Friend WithEvents txtCstRmk As System.Windows.Forms.RichTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtWastage As System.Windows.Forms.TextBox
    Friend WithEvents lblBOMASS As System.Windows.Forms.Label
    Friend WithEvents lblPricing As System.Windows.Forms.Label
    Friend WithEvents PanelPacking As System.Windows.Forms.Panel
    Friend WithEvents cmdPanPackUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdPanPackCancel As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackMaster As System.Windows.Forms.TextBox
    Friend WithEvents txtPanPackInner As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboPanPackUM As System.Windows.Forms.ComboBox
    Friend WithEvents txtPanPackInnerInchL As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackInnerInchH As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackInnerInchW As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackCBM As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackCFT As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackMasterCML As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackMasterCMH As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackMasterCMW As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackInnerCML As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackInnerCMH As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackInnerCMW As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackMasterInchL As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackMasterInchH As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackMasterInchW As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackNW As System.Windows.Forms.TextBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackGW As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackPackingInstruction As System.Windows.Forms.RichTextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents cmdPanPackInsert As System.Windows.Forms.Button
    Friend WithEvents lblPriceStatus As System.Windows.Forms.Label
    Friend WithEvents gbPriceStatus As System.Windows.Forms.GroupBox
    Friend WithEvents rbPriceStatus_INA As System.Windows.Forms.RadioButton
    Friend WithEvents rbPriceStatus_ACT As System.Windows.Forms.RadioButton
    Friend WithEvents rbPriceStatus_All As System.Windows.Forms.RadioButton
    Friend WithEvents PanelCostPrice As System.Windows.Forms.Panel
    Friend WithEvents lblPanCPPacking As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents txtPanCPMUPack As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPMUTran As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPMUD As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPMUC As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPMUB As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPMUA As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPMU As System.Windows.Forms.TextBox
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents txtPanCPFtyCstPack As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPFtyCstTran As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPFtyCstD As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPFtyCstC As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPFtyCstB As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPFtyCstA As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPFtyCst As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPFtyPrcPack As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPFtyPrcTran As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPFtyPrcD As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPFtyPrcC As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPFtyPrcB As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPFtyPrcA As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPFtyPrc As System.Windows.Forms.TextBox
    Friend WithEvents lblPanCPFCurcde1 As System.Windows.Forms.Label
    Friend WithEvents txtPanCPBOMCst As System.Windows.Forms.TextBox
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents txtPanCPTtlCst As System.Windows.Forms.TextBox
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents txtPanCPNegCst As System.Windows.Forms.TextBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents txtPanCPItmPrc As System.Windows.Forms.TextBox
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents txtPanCPAdjPer As System.Windows.Forms.TextBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents txtPanCPBasicPrc As System.Windows.Forms.TextBox
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents txtPanCPBOMPrc As System.Windows.Forms.TextBox
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents cmdPanCPInsert As System.Windows.Forms.Button
    Friend WithEvents cmdPanCPUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdPanCPCancel As System.Windows.Forms.Button
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents cboPanCPPrcTrmHK As System.Windows.Forms.ComboBox
    Friend WithEvents cboPanCPTranTrm As System.Windows.Forms.ComboBox
    Friend WithEvents cboPanCPPrcTrmFty As System.Windows.Forms.ComboBox
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents cboPanCPCus1no As System.Windows.Forms.ComboBox
    Friend WithEvents cboPanCPCus2no As System.Windows.Forms.ComboBox
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents cboPanCPStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtPanPackPeriod As System.Windows.Forms.MaskedTextBox
    Friend WithEvents PanelPV As System.Windows.Forms.Panel
    Friend WithEvents cmdPanPVInsert As System.Windows.Forms.Button
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents txtPanPVVenItm As System.Windows.Forms.TextBox
    Friend WithEvents cboPanPVPV As System.Windows.Forms.ComboBox
    Friend WithEvents Label99 As System.Windows.Forms.Label
    Friend WithEvents cmdPanPVCancel As System.Windows.Forms.Button
    Friend WithEvents PanelCopy As System.Windows.Forms.Panel
    Friend WithEvents cmdPanCopyCopy As System.Windows.Forms.Button
    Friend WithEvents txtPanCopyVenItmNo As System.Windows.Forms.TextBox
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents cmdPanCopyCancel As System.Windows.Forms.Button
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackConFtr As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPNegPrc As System.Windows.Forms.TextBox
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents lblPanCPFCurcde As System.Windows.Forms.Label
    Friend WithEvents lblPanCPBCurcde1 As System.Windows.Forms.Label
    Friend WithEvents lblPanCPBCurcde2 As System.Windows.Forms.Label
    Friend WithEvents lblPanCPFCurcde3 As System.Windows.Forms.Label
    Friend WithEvents lblPanCPFCurcde2 As System.Windows.Forms.Label
    Friend WithEvents lblPanCPBCurcde As System.Windows.Forms.Label
    Friend WithEvents lblPanCPFCurcde4 As System.Windows.Forms.Label
    Friend WithEvents rbPriceStatus_NA As System.Windows.Forms.RadioButton
    Friend WithEvents cboPanCPFmlHK As System.Windows.Forms.ComboBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackMaterial As System.Windows.Forms.RichTextBox
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackMasterSize As System.Windows.Forms.RichTextBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents txtPanPackInnerSize As System.Windows.Forms.RichTextBox
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents lbBOMColor As System.Windows.Forms.ListBox
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents cmdCombineImage As System.Windows.Forms.Button
    Friend WithEvents cbDiscontinue As System.Windows.Forms.CheckBox
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents PanelAdd As System.Windows.Forms.Panel
    Friend WithEvents rbPanelAdd_BOM As System.Windows.Forms.RadioButton
    Friend WithEvents rbPanelAdd_ASS As System.Windows.Forms.RadioButton
    Friend WithEvents rbPanelAdd_REG As System.Windows.Forms.RadioButton
    Friend WithEvents cmdPanelAddAdd As System.Windows.Forms.Button
    Friend WithEvents cmdPanelAddCancel As System.Windows.Forms.Button
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents cmdActivate As System.Windows.Forms.Button
    Friend WithEvents dgTempItem As System.Windows.Forms.DataGridView
    Friend WithEvents lblOrgCus1No As System.Windows.Forms.Label
    Friend WithEvents lblOrgTranTerm As System.Windows.Forms.Label
    Friend WithEvents lblOrgHKTerm As System.Windows.Forms.Label
    Friend WithEvents lblOrgFtyTerm As System.Windows.Forms.Label
    Friend WithEvents lblOrgCus2No As System.Windows.Forms.Label
    Friend WithEvents cboPanCopyPrdLne As System.Windows.Forms.ComboBox
    Friend WithEvents cboPanCopyCategory As System.Windows.Forms.ComboBox
    Friend WithEvents txtPanCPExpDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtPanCPEffDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtTmpItmNo As System.Windows.Forms.TextBox
    Friend WithEvents pbImage As System.Windows.Forms.PictureBox
    Friend WithEvents pbImage2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblOrgConftr As System.Windows.Forms.Label
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents cmdMapping As System.Windows.Forms.Button
    Friend WithEvents cmdBatchUpdate As System.Windows.Forms.Button
    Friend WithEvents dgMOQMOA As System.Windows.Forms.DataGridView
    Friend WithEvents PanelMOQMOA As System.Windows.Forms.Panel
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents cboPanMMCus1no As System.Windows.Forms.ComboBox
    Friend WithEvents cboPanMMCus2no As System.Windows.Forms.ComboBox
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents cboPanMMMOQMOA As System.Windows.Forms.ComboBox
    Friend WithEvents txtPanMMMOA As System.Windows.Forms.TextBox
    Friend WithEvents txtPanMMMOQQty As System.Windows.Forms.TextBox
    Friend WithEvents cboPanMMMOACur As System.Windows.Forms.ComboBox
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents cboPanMMMOQUM As System.Windows.Forms.ComboBox
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents rbPanMMTirtyp_Company As System.Windows.Forms.RadioButton
    Friend WithEvents rbPanMMTirtyp_Standard As System.Windows.Forms.RadioButton
    Friend WithEvents cmdPanMMInsert As System.Windows.Forms.Button
    Friend WithEvents cmdPanMMUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdPanMMCancel As System.Windows.Forms.Button
    Friend WithEvents txtPanCPEstPrcRef As System.Windows.Forms.TextBox
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents cboPanCPEstPrcFlg As System.Windows.Forms.ComboBox
    Friend WithEvents Label96 As System.Windows.Forms.Label
    Friend WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents cboPanPackCus1no As System.Windows.Forms.ComboBox
    Friend WithEvents cboPanPackCus2no As System.Windows.Forms.ComboBox
    Friend WithEvents txtPanCPFtyPrcE As System.Windows.Forms.TextBox
    Friend WithEvents txtPanCPMUE As System.Windows.Forms.TextBox
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents txtPanCPFtyCstE As System.Windows.Forms.TextBox
    Friend WithEvents cmdRelItm As System.Windows.Forms.Button
    Friend WithEvents cmdCopyPV As System.Windows.Forms.Button
    Friend WithEvents txtItmRmk2 As System.Windows.Forms.TextBox
    Friend WithEvents txtSChnDsc As System.Windows.Forms.TextBox
    Friend WithEvents txtFtrRmk As System.Windows.Forms.RichTextBox

    Friend WithEvents StatusBar As System.Windows.Forms.StatusBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMM00001))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("(BOM) 3710060500C PC/0/2")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("(REG) 12A001A001A01 PC/0/3", New System.Windows.Forms.TreeNode() {TreeNode1})
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.StatusBar = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel
        Me.cmdLast = New System.Windows.Forms.Button
        Me.cmdPrevious = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdFind = New System.Windows.Forms.Button
        Me.cmdCopy = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdDelRow = New System.Windows.Forms.Button
        Me.cmdFirst = New System.Windows.Forms.Button
        Me.cmdInsRow = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.lblItmNo = New System.Windows.Forms.Label
        Me.txtItmNo = New System.Windows.Forms.TextBox
        Me.lblItmTyp = New System.Windows.Forms.Label
        Me.txtItmdsc = New System.Windows.Forms.TextBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.gbIMStatus = New System.Windows.Forms.GroupBox
        Me.rbIMStatus_History = New System.Windows.Forms.RadioButton
        Me.rbIMStatus_Current = New System.Windows.Forms.RadioButton
        Me.gbIMTyp = New System.Windows.Forms.GroupBox
        Me.rbIMTyp_PCIM = New System.Windows.Forms.RadioButton
        Me.rbIMTyp_IM = New System.Windows.Forms.RadioButton
        Me.cbTmpItm = New System.Windows.Forms.CheckBox
        Me.cboItmTyp = New System.Windows.Forms.ComboBox
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdActivate = New System.Windows.Forms.Button
        Me.cbDiscontinue = New System.Windows.Forms.CheckBox
        Me.txtTmpItmNo = New System.Windows.Forms.TextBox
        Me.PanelCopy = New System.Windows.Forms.Panel
        Me.cboPanCopyCategory = New System.Windows.Forms.ComboBox
        Me.cboPanCopyPrdLne = New System.Windows.Forms.ComboBox
        Me.Label86 = New System.Windows.Forms.Label
        Me.Label85 = New System.Windows.Forms.Label
        Me.cmdPanCopyCopy = New System.Windows.Forms.Button
        Me.txtPanCopyVenItmNo = New System.Windows.Forms.TextBox
        Me.Label80 = New System.Windows.Forms.Label
        Me.cmdPanCopyCancel = New System.Windows.Forms.Button
        Me.PanelAdd = New System.Windows.Forms.Panel
        Me.Label87 = New System.Windows.Forms.Label
        Me.rbPanelAdd_BOM = New System.Windows.Forms.RadioButton
        Me.rbPanelAdd_ASS = New System.Windows.Forms.RadioButton
        Me.rbPanelAdd_REG = New System.Windows.Forms.RadioButton
        Me.cmdPanelAddAdd = New System.Windows.Forms.Button
        Me.cmdPanelAddCancel = New System.Windows.Forms.Button
        Me.cmdBrowse = New System.Windows.Forms.Button
        Me.cmdMapping = New System.Windows.Forms.Button
        Me.cmdRelItm = New System.Windows.Forms.Button
        Me.TabPageMain = New ERPSystem.BaseTabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.txtFtrRmk = New System.Windows.Forms.RichTextBox
        Me.txtSChnDsc = New System.Windows.Forms.TextBox
        Me.txtItmRmk2 = New System.Windows.Forms.TextBox
        Me.txtItmRmk = New System.Windows.Forms.RichTextBox
        Me.cmdBatchUpdate = New System.Windows.Forms.Button
        Me.PanelPacking = New System.Windows.Forms.Panel
        Me.Label97 = New System.Windows.Forms.Label
        Me.Label98 = New System.Windows.Forms.Label
        Me.cboPanPackCus1no = New System.Windows.Forms.ComboBox
        Me.cboPanPackCus2no = New System.Windows.Forms.ComboBox
        Me.txtPanPackMaterial = New System.Windows.Forms.RichTextBox
        Me.Label82 = New System.Windows.Forms.Label
        Me.txtPanPackMasterSize = New System.Windows.Forms.RichTextBox
        Me.Label63 = New System.Windows.Forms.Label
        Me.txtPanPackInnerSize = New System.Windows.Forms.RichTextBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label79 = New System.Windows.Forms.Label
        Me.txtPanPackConFtr = New System.Windows.Forms.TextBox
        Me.txtPanPackPeriod = New System.Windows.Forms.MaskedTextBox
        Me.cmdPanPackInsert = New System.Windows.Forms.Button
        Me.txtPanPackPackingInstruction = New System.Windows.Forms.RichTextBox
        Me.Label51 = New System.Windows.Forms.Label
        Me.txtPanPackNW = New System.Windows.Forms.TextBox
        Me.Label49 = New System.Windows.Forms.Label
        Me.txtPanPackGW = New System.Windows.Forms.TextBox
        Me.Label50 = New System.Windows.Forms.Label
        Me.txtPanPackMasterCML = New System.Windows.Forms.TextBox
        Me.Label46 = New System.Windows.Forms.Label
        Me.txtPanPackMasterCMH = New System.Windows.Forms.TextBox
        Me.Label47 = New System.Windows.Forms.Label
        Me.txtPanPackMasterCMW = New System.Windows.Forms.TextBox
        Me.Label48 = New System.Windows.Forms.Label
        Me.txtPanPackInnerCML = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.txtPanPackInnerCMH = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.txtPanPackInnerCMW = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.txtPanPackMasterInchL = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.txtPanPackMasterInchH = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.txtPanPackMasterInchW = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtPanPackInnerInchL = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtPanPackInnerInchH = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtPanPackInnerInchW = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtPanPackCBM = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtPanPackCFT = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtPanPackMaster = New System.Windows.Forms.TextBox
        Me.txtPanPackInner = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboPanPackUM = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdPanPackUpdate = New System.Windows.Forms.Button
        Me.cmdPanPackCancel = New System.Windows.Forms.Button
        Me.pbImage = New System.Windows.Forms.PictureBox
        Me.lblItmRmk = New System.Windows.Forms.Label
        Me.lblPacking = New System.Windows.Forms.Label
        Me.dgPacking = New System.Windows.Forms.DataGridView
        Me.dgColor = New System.Windows.Forms.DataGridView
        Me.txtChnDsc = New System.Windows.Forms.RichTextBox
        Me.lblColor = New System.Windows.Forms.Label
        Me.txtEngDsc = New System.Windows.Forms.RichTextBox
        Me.lblChnDsc = New System.Windows.Forms.Label
        Me.lblEngDsc = New System.Windows.Forms.Label
        Me.cmdCombineImage = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.cmdCopyPV = New System.Windows.Forms.Button
        Me.PanelPV = New System.Windows.Forms.Panel
        Me.cmdPanPVInsert = New System.Windows.Forms.Button
        Me.Label94 = New System.Windows.Forms.Label
        Me.txtPanPVVenItm = New System.Windows.Forms.TextBox
        Me.cboPanPVPV = New System.Windows.Forms.ComboBox
        Me.Label99 = New System.Windows.Forms.Label
        Me.cmdPanPVCancel = New System.Windows.Forms.Button
        Me.lblPV = New System.Windows.Forms.Label
        Me.cboEV = New System.Windows.Forms.ComboBox
        Me.lblEV = New System.Windows.Forms.Label
        Me.cboTV = New System.Windows.Forms.ComboBox
        Me.lblTV = New System.Windows.Forms.Label
        Me.cboCV = New System.Windows.Forms.ComboBox
        Me.lblCV = New System.Windows.Forms.Label
        Me.cboDV = New System.Windows.Forms.ComboBox
        Me.lblDV = New System.Windows.Forms.Label
        Me.dgPV = New System.Windows.Forms.DataGridView
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Label19 = New System.Windows.Forms.Label
        Me.pbImage2 = New System.Windows.Forms.PictureBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cboCategory = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboPrdLne = New System.Windows.Forms.ComboBox
        Me.cboItmVenTyp = New System.Windows.Forms.ComboBox
        Me.lblItmVenTyp = New System.Windows.Forms.Label
        Me.lblOEMCustomer = New System.Windows.Forms.Label
        Me.dgOEMCustomer = New System.Windows.Forms.DataGridView
        Me.cboYear = New System.Windows.Forms.ComboBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.cboType = New System.Windows.Forms.ComboBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.cboDevTeam = New System.Windows.Forms.ComboBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.cboDesigner = New System.Windows.Forms.ComboBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.cboSeason = New System.Windows.Forms.ComboBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.cboPrdSizeTyp = New System.Windows.Forms.ComboBox
        Me.cboPrdSizeUnit = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.cboPrdIcon = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.cboPrdGroup = New System.Windows.Forms.ComboBox
        Me.txtPrdSizeValue = New System.Windows.Forms.TextBox
        Me.txtDsgItmNo = New System.Windows.Forms.TextBox
        Me.lblDsgItmNo = New System.Windows.Forms.Label
        Me.cboPrdTyp = New System.Windows.Forms.ComboBox
        Me.lblPrdTyp = New System.Windows.Forms.Label
        Me.lblItmNature = New System.Windows.Forms.Label
        Me.cboItmNature = New System.Windows.Forms.ComboBox
        Me.lblMaterial = New System.Windows.Forms.Label
        Me.cboMaterial = New System.Windows.Forms.ComboBox
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.lbBOMColor = New System.Windows.Forms.ListBox
        Me.lblBOMASS = New System.Windows.Forms.Label
        Me.IMTreeView = New System.Windows.Forms.TreeView
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.dgRelParentItem = New System.Windows.Forms.DataGridView
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.rbBOMASS_BOM = New System.Windows.Forms.RadioButton
        Me.rbBOMASS_ASS = New System.Windows.Forms.RadioButton
        Me.Label40 = New System.Windows.Forms.Label
        Me.dgBOMASS = New System.Windows.Forms.DataGridView
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.PanelCostPrice = New System.Windows.Forms.Panel
        Me.txtPanCPFtyPrcE = New System.Windows.Forms.TextBox
        Me.txtPanCPMUE = New System.Windows.Forms.TextBox
        Me.Label100 = New System.Windows.Forms.Label
        Me.txtPanCPFtyCstE = New System.Windows.Forms.TextBox
        Me.txtPanCPEstPrcRef = New System.Windows.Forms.TextBox
        Me.Label96 = New System.Windows.Forms.Label
        Me.Label95 = New System.Windows.Forms.Label
        Me.cboPanCPEstPrcFlg = New System.Windows.Forms.ComboBox
        Me.lblOrgConftr = New System.Windows.Forms.Label
        Me.txtPanCPExpDate = New System.Windows.Forms.MaskedTextBox
        Me.txtPanCPEffDate = New System.Windows.Forms.MaskedTextBox
        Me.lblOrgTranTerm = New System.Windows.Forms.Label
        Me.lblOrgHKTerm = New System.Windows.Forms.Label
        Me.lblOrgFtyTerm = New System.Windows.Forms.Label
        Me.lblOrgCus2No = New System.Windows.Forms.Label
        Me.lblOrgCus1No = New System.Windows.Forms.Label
        Me.cboPanCPFmlHK = New System.Windows.Forms.ComboBox
        Me.lblPanCPFCurcde4 = New System.Windows.Forms.Label
        Me.lblPanCPBCurcde = New System.Windows.Forms.Label
        Me.lblPanCPBCurcde1 = New System.Windows.Forms.Label
        Me.lblPanCPBCurcde2 = New System.Windows.Forms.Label
        Me.lblPanCPFCurcde3 = New System.Windows.Forms.Label
        Me.lblPanCPFCurcde2 = New System.Windows.Forms.Label
        Me.Label83 = New System.Windows.Forms.Label
        Me.lblPanCPFCurcde = New System.Windows.Forms.Label
        Me.txtPanCPNegPrc = New System.Windows.Forms.TextBox
        Me.Label81 = New System.Windows.Forms.Label
        Me.Label78 = New System.Windows.Forms.Label
        Me.cboPanCPStatus = New System.Windows.Forms.ComboBox
        Me.Label76 = New System.Windows.Forms.Label
        Me.Label77 = New System.Windows.Forms.Label
        Me.cboPanCPCus1no = New System.Windows.Forms.ComboBox
        Me.cboPanCPCus2no = New System.Windows.Forms.ComboBox
        Me.Label75 = New System.Windows.Forms.Label
        Me.Label74 = New System.Windows.Forms.Label
        Me.cboPanCPPrcTrmFty = New System.Windows.Forms.ComboBox
        Me.Label73 = New System.Windows.Forms.Label
        Me.cboPanCPPrcTrmHK = New System.Windows.Forms.ComboBox
        Me.cboPanCPTranTrm = New System.Windows.Forms.ComboBox
        Me.Label72 = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.cmdPanCPInsert = New System.Windows.Forms.Button
        Me.cmdPanCPUpdate = New System.Windows.Forms.Button
        Me.cmdPanCPCancel = New System.Windows.Forms.Button
        Me.txtPanCPBasicPrc = New System.Windows.Forms.TextBox
        Me.Label71 = New System.Windows.Forms.Label
        Me.txtPanCPBOMPrc = New System.Windows.Forms.TextBox
        Me.Label70 = New System.Windows.Forms.Label
        Me.txtPanCPItmPrc = New System.Windows.Forms.TextBox
        Me.Label69 = New System.Windows.Forms.Label
        Me.txtPanCPAdjPer = New System.Windows.Forms.TextBox
        Me.Label68 = New System.Windows.Forms.Label
        Me.Label67 = New System.Windows.Forms.Label
        Me.txtPanCPNegCst = New System.Windows.Forms.TextBox
        Me.Label66 = New System.Windows.Forms.Label
        Me.txtPanCPTtlCst = New System.Windows.Forms.TextBox
        Me.Label65 = New System.Windows.Forms.Label
        Me.txtPanCPBOMCst = New System.Windows.Forms.TextBox
        Me.Label64 = New System.Windows.Forms.Label
        Me.txtPanCPFtyPrcPack = New System.Windows.Forms.TextBox
        Me.txtPanCPFtyPrcTran = New System.Windows.Forms.TextBox
        Me.txtPanCPFtyPrcD = New System.Windows.Forms.TextBox
        Me.txtPanCPFtyPrcC = New System.Windows.Forms.TextBox
        Me.txtPanCPFtyPrcB = New System.Windows.Forms.TextBox
        Me.txtPanCPFtyPrcA = New System.Windows.Forms.TextBox
        Me.txtPanCPFtyPrc = New System.Windows.Forms.TextBox
        Me.lblPanCPFCurcde1 = New System.Windows.Forms.Label
        Me.txtPanCPMUPack = New System.Windows.Forms.TextBox
        Me.txtPanCPMUTran = New System.Windows.Forms.TextBox
        Me.txtPanCPMUD = New System.Windows.Forms.TextBox
        Me.txtPanCPMUC = New System.Windows.Forms.TextBox
        Me.txtPanCPMUB = New System.Windows.Forms.TextBox
        Me.txtPanCPMUA = New System.Windows.Forms.TextBox
        Me.txtPanCPMU = New System.Windows.Forms.TextBox
        Me.Label62 = New System.Windows.Forms.Label
        Me.Label61 = New System.Windows.Forms.Label
        Me.Label60 = New System.Windows.Forms.Label
        Me.Label59 = New System.Windows.Forms.Label
        Me.Label58 = New System.Windows.Forms.Label
        Me.Label57 = New System.Windows.Forms.Label
        Me.Label56 = New System.Windows.Forms.Label
        Me.txtPanCPFtyCstPack = New System.Windows.Forms.TextBox
        Me.txtPanCPFtyCstTran = New System.Windows.Forms.TextBox
        Me.txtPanCPFtyCstD = New System.Windows.Forms.TextBox
        Me.txtPanCPFtyCstC = New System.Windows.Forms.TextBox
        Me.txtPanCPFtyCstB = New System.Windows.Forms.TextBox
        Me.txtPanCPFtyCstA = New System.Windows.Forms.TextBox
        Me.txtPanCPFtyCst = New System.Windows.Forms.TextBox
        Me.Label55 = New System.Windows.Forms.Label
        Me.Label54 = New System.Windows.Forms.Label
        Me.lblPanCPPacking = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.lblPriceStatus = New System.Windows.Forms.Label
        Me.gbPriceStatus = New System.Windows.Forms.GroupBox
        Me.rbPriceStatus_NA = New System.Windows.Forms.RadioButton
        Me.rbPriceStatus_INA = New System.Windows.Forms.RadioButton
        Me.rbPriceStatus_ACT = New System.Windows.Forms.RadioButton
        Me.rbPriceStatus_All = New System.Windows.Forms.RadioButton
        Me.lblPricing = New System.Windows.Forms.Label
        Me.Label89 = New System.Windows.Forms.Label
        Me.txtCstRmk = New System.Windows.Forms.RichTextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label88 = New System.Windows.Forms.Label
        Me.txtCstExpDat = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.lblCstRmk = New System.Windows.Forms.Label
        Me.gbPriceView = New System.Windows.Forms.GroupBox
        Me.rbPriceView_P = New System.Windows.Forms.RadioButton
        Me.rbPriceView_F = New System.Windows.Forms.RadioButton
        Me.rbPriceView_S = New System.Windows.Forms.RadioButton
        Me.dgCostPrice = New System.Windows.Forms.DataGridView
        Me.TabPage6 = New System.Windows.Forms.TabPage
        Me.PanelMOQMOA = New System.Windows.Forms.Panel
        Me.cmdPanMMInsert = New System.Windows.Forms.Button
        Me.cmdPanMMUpdate = New System.Windows.Forms.Button
        Me.cmdPanMMCancel = New System.Windows.Forms.Button
        Me.cboPanMMMOQMOA = New System.Windows.Forms.ComboBox
        Me.txtPanMMMOA = New System.Windows.Forms.TextBox
        Me.txtPanMMMOQQty = New System.Windows.Forms.TextBox
        Me.cboPanMMMOACur = New System.Windows.Forms.ComboBox
        Me.Label92 = New System.Windows.Forms.Label
        Me.cboPanMMMOQUM = New System.Windows.Forms.ComboBox
        Me.Label93 = New System.Windows.Forms.Label
        Me.rbPanMMTirtyp_Company = New System.Windows.Forms.RadioButton
        Me.rbPanMMTirtyp_Standard = New System.Windows.Forms.RadioButton
        Me.cboPanMMCus1no = New System.Windows.Forms.ComboBox
        Me.cboPanMMCus2no = New System.Windows.Forms.ComboBox
        Me.Label91 = New System.Windows.Forms.Label
        Me.Label90 = New System.Windows.Forms.Label
        Me.dgTempItem = New System.Windows.Forms.DataGridView
        Me.Label84 = New System.Windows.Forms.Label
        Me.txtHstuEURDuty = New System.Windows.Forms.TextBox
        Me.txtHstuUSADuty = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboHstuUSA = New System.Windows.Forms.ComboBox
        Me.cboHstuEur = New System.Windows.Forms.ComboBox
        Me.cboConstrMethod = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtAlsitmcol = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtAlsitmno = New System.Windows.Forms.TextBox
        Me.gbAddreq = New System.Windows.Forms.GroupBox
        Me.cbAddreq_ster = New System.Windows.Forms.CheckBox
        Me.cbAddreq_ccib = New System.Windows.Forms.CheckBox
        Me.cbAddreq_formA = New System.Windows.Forms.CheckBox
        Me.gbMOQMOA = New System.Windows.Forms.GroupBox
        Me.dgMOQMOA = New System.Windows.Forms.DataGridView
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtWastage = New System.Windows.Forms.TextBox
        Me.txtPerMultQty = New System.Windows.Forms.TextBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.txtMOAAmt = New System.Windows.Forms.TextBox
        Me.txtMOQQty = New System.Windows.Forms.TextBox
        Me.cboMOACurr = New System.Windows.Forms.ComboBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.cboMOQUM = New System.Windows.Forms.ComboBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.rbTier_CompDef = New System.Windows.Forms.RadioButton
        Me.rbTier_Standard = New System.Windows.Forms.RadioButton
        Me.lblCusStyle = New System.Windows.Forms.Label
        Me.dgCusStyle = New System.Windows.Forms.DataGridView
        Me.lblExclCustomer = New System.Windows.Forms.Label
        Me.dgExclCustomer = New System.Windows.Forms.DataGridView
        Me.lblMatBreakdown = New System.Windows.Forms.Label
        Me.dgMatBreakdown = New System.Windows.Forms.DataGridView
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbIMStatus.SuspendLayout()
        Me.gbIMTyp.SuspendLayout()
        Me.PanelCopy.SuspendLayout()
        Me.PanelAdd.SuspendLayout()
        Me.TabPageMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.PanelPacking.SuspendLayout()
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgPacking, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.PanelPV.SuspendLayout()
        CType(Me.dgPV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.pbImage2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgOEMCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgRelParentItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgBOMASS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        Me.PanelCostPrice.SuspendLayout()
        Me.gbPriceStatus.SuspendLayout()
        Me.gbPriceView.SuspendLayout()
        CType(Me.dgCostPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        Me.PanelMOQMOA.SuspendLayout()
        CType(Me.dgTempItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAddreq.SuspendLayout()
        Me.gbMOQMOA.SuspendLayout()
        CType(Me.dgMOQMOA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgCusStyle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgExclCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgMatBreakdown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(0, -2)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(60, 25)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.Text = "&Add"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(60, -2)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(60, 25)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "&Save"
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(360, -2)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(60, 25)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "Cancel"
        '
        'StatusBar
        '
        Me.StatusBar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusBar.Location = New System.Drawing.Point(0, 605)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2})
        Me.StatusBar.ShowPanels = True
        Me.StatusBar.Size = New System.Drawing.Size(944, 16)
        Me.StatusBar.TabIndex = 14
        Me.StatusBar.Text = "StatusBar"
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 463
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel2.Name = "StatusBarPanel2"
        Me.StatusBarPanel2.Width = 463
        '
        'cmdLast
        '
        Me.cmdLast.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLast.Location = New System.Drawing.Point(820, -2)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(50, 25)
        Me.cmdLast.TabIndex = 13
        Me.cmdLast.Text = ">>|"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.Location = New System.Drawing.Point(720, -2)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(50, 25)
        Me.cmdPrevious.TabIndex = 11
        Me.cmdPrevious.Text = "<"
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(770, -2)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(50, 25)
        Me.cmdNext.TabIndex = 12
        Me.cmdNext.Text = ">"
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFind.Location = New System.Drawing.Point(240, -2)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(60, 25)
        Me.cmdFind.TabIndex = 4
        Me.cmdFind.Text = "&Find"
        '
        'cmdCopy
        '
        Me.cmdCopy.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(180, -2)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(60, 25)
        Me.cmdCopy.TabIndex = 3
        Me.cmdCopy.Text = "&Copy"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(300, -2)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(60, 25)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.Text = "Cl&ear"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(894, -2)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(60, 25)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.Text = "E&xit"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelRow.Location = New System.Drawing.Point(580, -2)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(60, 25)
        Me.cmdDelRow.TabIndex = 9
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdFirst
        '
        Me.cmdFirst.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFirst.Location = New System.Drawing.Point(670, -2)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(50, 25)
        Me.cmdFirst.TabIndex = 10
        Me.cmdFirst.Text = "|<<"
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsRow.Location = New System.Drawing.Point(520, -2)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(60, 25)
        Me.cmdInsRow.TabIndex = 8
        Me.cmdInsRow.Text = "I&ns Row"
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(440, -3)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(60, 25)
        Me.cmdSearch.TabIndex = 7
        Me.cmdSearch.Text = "Searc&h"
        '
        'lblItmNo
        '
        Me.lblItmNo.AutoSize = True
        Me.lblItmNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItmNo.Location = New System.Drawing.Point(8, 31)
        Me.lblItmNo.Name = "lblItmNo"
        Me.lblItmNo.Size = New System.Drawing.Size(48, 14)
        Me.lblItmNo.TabIndex = 16
        Me.lblItmNo.Text = "Item No :"
        '
        'txtItmNo
        '
        Me.txtItmNo.BackColor = System.Drawing.Color.White
        Me.txtItmNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItmNo.ForeColor = System.Drawing.Color.Black
        Me.txtItmNo.Location = New System.Drawing.Point(60, 28)
        Me.txtItmNo.MaxLength = 30
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(141, 20)
        Me.txtItmNo.TabIndex = 15
        Me.txtItmNo.Text = "12A001A001A01"
        '
        'lblItmTyp
        '
        Me.lblItmTyp.AutoSize = True
        Me.lblItmTyp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItmTyp.Location = New System.Drawing.Point(710, 30)
        Me.lblItmTyp.Name = "lblItmTyp"
        Me.lblItmTyp.Size = New System.Drawing.Size(58, 14)
        Me.lblItmTyp.TabIndex = 18
        Me.lblItmTyp.Text = "Item Type :"
        '
        'txtItmdsc
        '
        Me.txtItmdsc.BackColor = System.Drawing.Color.White
        Me.txtItmdsc.Enabled = False
        Me.txtItmdsc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItmdsc.ForeColor = System.Drawing.Color.Black
        Me.txtItmdsc.Location = New System.Drawing.Point(268, 28)
        Me.txtItmdsc.MaxLength = 500
        Me.txtItmdsc.Name = "txtItmdsc"
        Me.txtItmdsc.Size = New System.Drawing.Size(430, 20)
        Me.txtItmdsc.TabIndex = 16
        Me.txtItmdsc.Text = "35""MOUNTAIN ASH STEM"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(710, 58)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(44, 14)
        Me.lblStatus.TabIndex = 53
        Me.lblStatus.Text = "Status :"
        '
        'gbIMStatus
        '
        Me.gbIMStatus.Controls.Add(Me.rbIMStatus_History)
        Me.gbIMStatus.Controls.Add(Me.rbIMStatus_Current)
        Me.gbIMStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbIMStatus.Location = New System.Drawing.Point(536, 48)
        Me.gbIMStatus.Name = "gbIMStatus"
        Me.gbIMStatus.Size = New System.Drawing.Size(151, 35)
        Me.gbIMStatus.TabIndex = 55
        Me.gbIMStatus.TabStop = False
        '
        'rbIMStatus_History
        '
        Me.rbIMStatus_History.AutoSize = True
        Me.rbIMStatus_History.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbIMStatus_History.Location = New System.Drawing.Point(85, 11)
        Me.rbIMStatus_History.Name = "rbIMStatus_History"
        Me.rbIMStatus_History.Size = New System.Drawing.Size(59, 18)
        Me.rbIMStatus_History.TabIndex = 22
        Me.rbIMStatus_History.Text = "History"
        Me.rbIMStatus_History.UseVisualStyleBackColor = True
        '
        'rbIMStatus_Current
        '
        Me.rbIMStatus_Current.AutoSize = True
        Me.rbIMStatus_Current.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbIMStatus_Current.Location = New System.Drawing.Point(6, 11)
        Me.rbIMStatus_Current.Name = "rbIMStatus_Current"
        Me.rbIMStatus_Current.Size = New System.Drawing.Size(61, 18)
        Me.rbIMStatus_Current.TabIndex = 21
        Me.rbIMStatus_Current.Text = "Current"
        Me.rbIMStatus_Current.UseVisualStyleBackColor = True
        '
        'gbIMTyp
        '
        Me.gbIMTyp.Controls.Add(Me.rbIMTyp_PCIM)
        Me.gbIMTyp.Controls.Add(Me.rbIMTyp_IM)
        Me.gbIMTyp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbIMTyp.Location = New System.Drawing.Point(2, 48)
        Me.gbIMTyp.Name = "gbIMTyp"
        Me.gbIMTyp.Size = New System.Drawing.Size(33, 24)
        Me.gbIMTyp.TabIndex = 56
        Me.gbIMTyp.TabStop = False
        Me.gbIMTyp.Visible = False
        '
        'rbIMTyp_PCIM
        '
        Me.rbIMTyp_PCIM.AutoSize = True
        Me.rbIMTyp_PCIM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbIMTyp_PCIM.Location = New System.Drawing.Point(96, 11)
        Me.rbIMTyp_PCIM.Name = "rbIMTyp_PCIM"
        Me.rbIMTyp_PCIM.Size = New System.Drawing.Size(104, 18)
        Me.rbIMTyp_PCIM.TabIndex = 56
        Me.rbIMTyp_PCIM.Text = "Price Calculation"
        Me.rbIMTyp_PCIM.UseVisualStyleBackColor = True
        '
        'rbIMTyp_IM
        '
        Me.rbIMTyp_IM.AutoSize = True
        Me.rbIMTyp_IM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbIMTyp_IM.Location = New System.Drawing.Point(6, 11)
        Me.rbIMTyp_IM.Name = "rbIMTyp_IM"
        Me.rbIMTyp_IM.Size = New System.Drawing.Size(80, 18)
        Me.rbIMTyp_IM.TabIndex = 55
        Me.rbIMTyp_IM.Text = "Item Master"
        Me.rbIMTyp_IM.UseVisualStyleBackColor = True
        '
        'cbTmpItm
        '
        Me.cbTmpItm.AutoSize = True
        Me.cbTmpItm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTmpItm.Location = New System.Drawing.Point(11, 59)
        Me.cbTmpItm.Name = "cbTmpItm"
        Me.cbTmpItm.Size = New System.Drawing.Size(73, 18)
        Me.cbTmpItm.TabIndex = 17
        Me.cbTmpItm.Text = "Temp Item"
        Me.cbTmpItm.UseVisualStyleBackColor = True
        '
        'cboItmTyp
        '
        Me.cboItmTyp.BackColor = System.Drawing.Color.White
        Me.cboItmTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItmTyp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboItmTyp.ForeColor = System.Drawing.Color.Black
        Me.cboItmTyp.FormattingEnabled = True
        Me.cboItmTyp.Location = New System.Drawing.Point(767, 27)
        Me.cboItmTyp.Name = "cboItmTyp"
        Me.cboItmTyp.Size = New System.Drawing.Size(175, 22)
        Me.cboItmTyp.TabIndex = 23
        '
        'cboStatus
        '
        Me.cboStatus.BackColor = System.Drawing.Color.White
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.ForeColor = System.Drawing.Color.Black
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(767, 55)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(175, 22)
        Me.cboStatus.TabIndex = 24
        '
        'cmdDelete
        '
        Me.cmdDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(120, -2)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(60, 25)
        Me.cmdDelete.TabIndex = 2
        Me.cmdDelete.Text = "&Delete"
        '
        'cmdActivate
        '
        Me.cmdActivate.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.cmdActivate.Location = New System.Drawing.Point(441, 58)
        Me.cmdActivate.Name = "cmdActivate"
        Me.cmdActivate.Size = New System.Drawing.Size(75, 21)
        Me.cmdActivate.TabIndex = 20
        Me.cmdActivate.Text = "Acti&vate"
        Me.cmdActivate.UseVisualStyleBackColor = True
        '
        'cbDiscontinue
        '
        Me.cbDiscontinue.AutoSize = True
        Me.cbDiscontinue.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDiscontinue.Location = New System.Drawing.Point(331, 60)
        Me.cbDiscontinue.Name = "cbDiscontinue"
        Me.cbDiscontinue.Size = New System.Drawing.Size(82, 18)
        Me.cbDiscontinue.TabIndex = 19
        Me.cbDiscontinue.Text = "Discontinue"
        Me.cbDiscontinue.UseVisualStyleBackColor = True
        '
        'txtTmpItmNo
        '
        Me.txtTmpItmNo.BackColor = System.Drawing.Color.White
        Me.txtTmpItmNo.Enabled = False
        Me.txtTmpItmNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTmpItmNo.ForeColor = System.Drawing.Color.Black
        Me.txtTmpItmNo.Location = New System.Drawing.Point(92, 57)
        Me.txtTmpItmNo.Name = "txtTmpItmNo"
        Me.txtTmpItmNo.Size = New System.Drawing.Size(146, 20)
        Me.txtTmpItmNo.TabIndex = 18
        Me.txtTmpItmNo.Text = "01A001A001A01"
        '
        'PanelCopy
        '
        Me.PanelCopy.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelCopy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelCopy.Controls.Add(Me.cboPanCopyCategory)
        Me.PanelCopy.Controls.Add(Me.cboPanCopyPrdLne)
        Me.PanelCopy.Controls.Add(Me.Label86)
        Me.PanelCopy.Controls.Add(Me.Label85)
        Me.PanelCopy.Controls.Add(Me.cmdPanCopyCopy)
        Me.PanelCopy.Controls.Add(Me.txtPanCopyVenItmNo)
        Me.PanelCopy.Controls.Add(Me.Label80)
        Me.PanelCopy.Controls.Add(Me.cmdPanCopyCancel)
        Me.PanelCopy.Location = New System.Drawing.Point(803, 76)
        Me.PanelCopy.Name = "PanelCopy"
        Me.PanelCopy.Size = New System.Drawing.Size(137, 51)
        Me.PanelCopy.TabIndex = 206
        Me.PanelCopy.Visible = False
        '
        'cboPanCopyCategory
        '
        Me.cboPanCopyCategory.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPanCopyCategory.FormattingEnabled = True
        Me.cboPanCopyCategory.Location = New System.Drawing.Point(125, 48)
        Me.cboPanCopyCategory.Name = "cboPanCopyCategory"
        Me.cboPanCopyCategory.Size = New System.Drawing.Size(119, 22)
        Me.cboPanCopyCategory.TabIndex = 130
        '
        'cboPanCopyPrdLne
        '
        Me.cboPanCopyPrdLne.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPanCopyPrdLne.FormattingEnabled = True
        Me.cboPanCopyPrdLne.Location = New System.Drawing.Point(125, 25)
        Me.cboPanCopyPrdLne.Name = "cboPanCopyPrdLne"
        Me.cboPanCopyPrdLne.Size = New System.Drawing.Size(119, 22)
        Me.cboPanCopyPrdLne.TabIndex = 129
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.Location = New System.Drawing.Point(7, 53)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(51, 14)
        Me.Label86.TabIndex = 127
        Me.Label86.Text = "Category"
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label85.Location = New System.Drawing.Point(7, 30)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(67, 14)
        Me.Label85.TabIndex = 125
        Me.Label85.Text = "Product Line"
        '
        'cmdPanCopyCopy
        '
        Me.cmdPanCopyCopy.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPanCopyCopy.Location = New System.Drawing.Point(125, 74)
        Me.cmdPanCopyCopy.Name = "cmdPanCopyCopy"
        Me.cmdPanCopyCopy.Size = New System.Drawing.Size(49, 21)
        Me.cmdPanCopyCopy.TabIndex = 122
        Me.cmdPanCopyCopy.Text = "Copy"
        Me.cmdPanCopyCopy.UseVisualStyleBackColor = True
        '
        'txtPanCopyVenItmNo
        '
        Me.txtPanCopyVenItmNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanCopyVenItmNo.Location = New System.Drawing.Point(125, 4)
        Me.txtPanCopyVenItmNo.Name = "txtPanCopyVenItmNo"
        Me.txtPanCopyVenItmNo.Size = New System.Drawing.Size(119, 20)
        Me.txtPanCopyVenItmNo.TabIndex = 102
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label80.Location = New System.Drawing.Point(7, 7)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(104, 14)
        Me.Label80.TabIndex = 3
        Me.Label80.Text = "Vendor Item Number"
        '
        'cmdPanCopyCancel
        '
        Me.cmdPanCopyCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPanCopyCancel.Location = New System.Drawing.Point(196, 73)
        Me.cmdPanCopyCancel.Name = "cmdPanCopyCancel"
        Me.cmdPanCopyCancel.Size = New System.Drawing.Size(48, 22)
        Me.cmdPanCopyCancel.TabIndex = 124
        Me.cmdPanCopyCancel.Text = "Cancel"
        Me.cmdPanCopyCancel.UseVisualStyleBackColor = True
        '
        'PanelAdd
        '
        Me.PanelAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelAdd.Controls.Add(Me.Label87)
        Me.PanelAdd.Controls.Add(Me.rbPanelAdd_BOM)
        Me.PanelAdd.Controls.Add(Me.rbPanelAdd_ASS)
        Me.PanelAdd.Controls.Add(Me.rbPanelAdd_REG)
        Me.PanelAdd.Controls.Add(Me.cmdPanelAddAdd)
        Me.PanelAdd.Controls.Add(Me.cmdPanelAddCancel)
        Me.PanelAdd.Location = New System.Drawing.Point(710, 76)
        Me.PanelAdd.Name = "PanelAdd"
        Me.PanelAdd.Size = New System.Drawing.Size(87, 51)
        Me.PanelAdd.TabIndex = 207
        Me.PanelAdd.Visible = False
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label87.Location = New System.Drawing.Point(4, 7)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(126, 14)
        Me.Label87.TabIndex = 128
        Me.Label87.Text = "Please Select Item Type :"
        '
        'rbPanelAdd_BOM
        '
        Me.rbPanelAdd_BOM.AutoSize = True
        Me.rbPanelAdd_BOM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPanelAdd_BOM.Location = New System.Drawing.Point(127, 28)
        Me.rbPanelAdd_BOM.Name = "rbPanelAdd_BOM"
        Me.rbPanelAdd_BOM.Size = New System.Drawing.Size(48, 18)
        Me.rbPanelAdd_BOM.TabIndex = 127
        Me.rbPanelAdd_BOM.Text = "BOM"
        Me.rbPanelAdd_BOM.UseVisualStyleBackColor = True
        '
        'rbPanelAdd_ASS
        '
        Me.rbPanelAdd_ASS.AutoSize = True
        Me.rbPanelAdd_ASS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPanelAdd_ASS.Location = New System.Drawing.Point(65, 28)
        Me.rbPanelAdd_ASS.Name = "rbPanelAdd_ASS"
        Me.rbPanelAdd_ASS.Size = New System.Drawing.Size(47, 18)
        Me.rbPanelAdd_ASS.TabIndex = 126
        Me.rbPanelAdd_ASS.Text = "ASS"
        Me.rbPanelAdd_ASS.UseVisualStyleBackColor = True
        '
        'rbPanelAdd_REG
        '
        Me.rbPanelAdd_REG.AutoSize = True
        Me.rbPanelAdd_REG.Checked = True
        Me.rbPanelAdd_REG.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPanelAdd_REG.Location = New System.Drawing.Point(4, 28)
        Me.rbPanelAdd_REG.Name = "rbPanelAdd_REG"
        Me.rbPanelAdd_REG.Size = New System.Drawing.Size(46, 18)
        Me.rbPanelAdd_REG.TabIndex = 125
        Me.rbPanelAdd_REG.TabStop = True
        Me.rbPanelAdd_REG.Text = "REG"
        Me.rbPanelAdd_REG.UseVisualStyleBackColor = True
        '
        'cmdPanelAddAdd
        '
        Me.cmdPanelAddAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPanelAddAdd.Location = New System.Drawing.Point(63, 56)
        Me.cmdPanelAddAdd.Name = "cmdPanelAddAdd"
        Me.cmdPanelAddAdd.Size = New System.Drawing.Size(49, 21)
        Me.cmdPanelAddAdd.TabIndex = 122
        Me.cmdPanelAddAdd.Text = "Add"
        Me.cmdPanelAddAdd.UseVisualStyleBackColor = True
        '
        'cmdPanelAddCancel
        '
        Me.cmdPanelAddCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPanelAddCancel.Location = New System.Drawing.Point(126, 55)
        Me.cmdPanelAddCancel.Name = "cmdPanelAddCancel"
        Me.cmdPanelAddCancel.Size = New System.Drawing.Size(48, 22)
        Me.cmdPanelAddCancel.TabIndex = 124
        Me.cmdPanelAddCancel.Text = "Cancel"
        Me.cmdPanelAddCancel.UseVisualStyleBackColor = True
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Image = CType(resources.GetObject("cmdBrowse.Image"), System.Drawing.Image)
        Me.cmdBrowse.Location = New System.Drawing.Point(202, 25)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(25, 25)
        Me.cmdBrowse.TabIndex = 208
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'cmdMapping
        '
        Me.cmdMapping.Image = CType(resources.GetObject("cmdMapping.Image"), System.Drawing.Image)
        Me.cmdMapping.Location = New System.Drawing.Point(229, 25)
        Me.cmdMapping.Name = "cmdMapping"
        Me.cmdMapping.Size = New System.Drawing.Size(25, 25)
        Me.cmdMapping.TabIndex = 209
        Me.cmdMapping.UseVisualStyleBackColor = True
        '
        'cmdRelItm
        '
        Me.cmdRelItm.Enabled = False
        Me.cmdRelItm.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.cmdRelItm.Location = New System.Drawing.Point(244, 58)
        Me.cmdRelItm.Name = "cmdRelItm"
        Me.cmdRelItm.Size = New System.Drawing.Size(75, 21)
        Me.cmdRelItm.TabIndex = 210
        Me.cmdRelItm.Text = "&Related Item"
        Me.cmdRelItm.UseVisualStyleBackColor = True
        '
        'TabPageMain
        '
        Me.TabPageMain.Controls.Add(Me.TabPage1)
        Me.TabPageMain.Controls.Add(Me.TabPage2)
        Me.TabPageMain.Controls.Add(Me.TabPage3)
        Me.TabPageMain.Controls.Add(Me.TabPage4)
        Me.TabPageMain.Controls.Add(Me.TabPage5)
        Me.TabPageMain.Controls.Add(Me.TabPage6)
        Me.TabPageMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabPageMain.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPageMain.ItemSize = New System.Drawing.Size(120, 19)
        Me.TabPageMain.Location = New System.Drawing.Point(2, 83)
        Me.TabPageMain.Name = "TabPageMain"
        Me.TabPageMain.SelectedIndex = 0
        Me.TabPageMain.Size = New System.Drawing.Size(950, 525)
        Me.TabPageMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabPageMain.TabIndex = 25
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtFtrRmk)
        Me.TabPage1.Controls.Add(Me.txtSChnDsc)
        Me.TabPage1.Controls.Add(Me.txtItmRmk2)
        Me.TabPage1.Controls.Add(Me.txtItmRmk)
        Me.TabPage1.Controls.Add(Me.cmdBatchUpdate)
        Me.TabPage1.Controls.Add(Me.PanelPacking)
        Me.TabPage1.Controls.Add(Me.pbImage)
        Me.TabPage1.Controls.Add(Me.lblItmRmk)
        Me.TabPage1.Controls.Add(Me.lblPacking)
        Me.TabPage1.Controls.Add(Me.dgPacking)
        Me.TabPage1.Controls.Add(Me.dgColor)
        Me.TabPage1.Controls.Add(Me.txtChnDsc)
        Me.TabPage1.Controls.Add(Me.lblColor)
        Me.TabPage1.Controls.Add(Me.txtEngDsc)
        Me.TabPage1.Controls.Add(Me.lblChnDsc)
        Me.TabPage1.Controls.Add(Me.lblEngDsc)
        Me.TabPage1.Controls.Add(Me.cmdCombineImage)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(942, 498)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "(1) Basic"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtFtrRmk
        '
        Me.txtFtrRmk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtFtrRmk.Location = New System.Drawing.Point(168, 13)
        Me.txtFtrRmk.Name = "txtFtrRmk"
        Me.txtFtrRmk.Size = New System.Drawing.Size(33, 35)
        Me.txtFtrRmk.TabIndex = 360
        Me.txtFtrRmk.Text = ""
        Me.txtFtrRmk.Visible = False
        '
        'txtSChnDsc
        '
        Me.txtSChnDsc.BackColor = System.Drawing.Color.White
        Me.txtSChnDsc.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSChnDsc.Location = New System.Drawing.Point(314, 250)
        Me.txtSChnDsc.Multiline = True
        Me.txtSChnDsc.Name = "txtSChnDsc"
        Me.txtSChnDsc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSChnDsc.Size = New System.Drawing.Size(277, 140)
        Me.txtSChnDsc.TabIndex = 85
        Me.txtSChnDsc.Visible = False
        '
        'txtItmRmk2
        '
        Me.txtItmRmk2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItmRmk2.Location = New System.Drawing.Point(597, 239)
        Me.txtItmRmk2.MaxLength = 800
        Me.txtItmRmk2.Multiline = True
        Me.txtItmRmk2.Name = "txtItmRmk2"
        Me.txtItmRmk2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtItmRmk2.Size = New System.Drawing.Size(238, 156)
        Me.txtItmRmk2.TabIndex = 84
        Me.txtItmRmk2.Visible = False
        '
        'txtItmRmk
        '
        Me.txtItmRmk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItmRmk.Location = New System.Drawing.Point(538, 26)
        Me.txtItmRmk.MaxLength = 800
        Me.txtItmRmk.Name = "txtItmRmk"
        Me.txtItmRmk.Size = New System.Drawing.Size(398, 156)
        Me.txtItmRmk.TabIndex = 53
        Me.txtItmRmk.Text = ""
        '
        'cmdBatchUpdate
        '
        Me.cmdBatchUpdate.Location = New System.Drawing.Point(606, 2)
        Me.cmdBatchUpdate.Name = "cmdBatchUpdate"
        Me.cmdBatchUpdate.Size = New System.Drawing.Size(92, 23)
        Me.cmdBatchUpdate.TabIndex = 83
        Me.cmdBatchUpdate.Text = "&Batch Update"
        Me.cmdBatchUpdate.UseVisualStyleBackColor = True
        '
        'PanelPacking
        '
        Me.PanelPacking.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelPacking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelPacking.Controls.Add(Me.Label97)
        Me.PanelPacking.Controls.Add(Me.Label98)
        Me.PanelPacking.Controls.Add(Me.cboPanPackCus1no)
        Me.PanelPacking.Controls.Add(Me.cboPanPackCus2no)
        Me.PanelPacking.Controls.Add(Me.txtPanPackMaterial)
        Me.PanelPacking.Controls.Add(Me.Label82)
        Me.PanelPacking.Controls.Add(Me.txtPanPackMasterSize)
        Me.PanelPacking.Controls.Add(Me.Label63)
        Me.PanelPacking.Controls.Add(Me.txtPanPackInnerSize)
        Me.PanelPacking.Controls.Add(Me.Label43)
        Me.PanelPacking.Controls.Add(Me.Label79)
        Me.PanelPacking.Controls.Add(Me.txtPanPackConFtr)
        Me.PanelPacking.Controls.Add(Me.txtPanPackPeriod)
        Me.PanelPacking.Controls.Add(Me.cmdPanPackInsert)
        Me.PanelPacking.Controls.Add(Me.txtPanPackPackingInstruction)
        Me.PanelPacking.Controls.Add(Me.Label51)
        Me.PanelPacking.Controls.Add(Me.txtPanPackNW)
        Me.PanelPacking.Controls.Add(Me.Label49)
        Me.PanelPacking.Controls.Add(Me.txtPanPackGW)
        Me.PanelPacking.Controls.Add(Me.Label50)
        Me.PanelPacking.Controls.Add(Me.txtPanPackMasterCML)
        Me.PanelPacking.Controls.Add(Me.Label46)
        Me.PanelPacking.Controls.Add(Me.txtPanPackMasterCMH)
        Me.PanelPacking.Controls.Add(Me.Label47)
        Me.PanelPacking.Controls.Add(Me.txtPanPackMasterCMW)
        Me.PanelPacking.Controls.Add(Me.Label48)
        Me.PanelPacking.Controls.Add(Me.txtPanPackInnerCML)
        Me.PanelPacking.Controls.Add(Me.Label34)
        Me.PanelPacking.Controls.Add(Me.txtPanPackInnerCMH)
        Me.PanelPacking.Controls.Add(Me.Label38)
        Me.PanelPacking.Controls.Add(Me.txtPanPackInnerCMW)
        Me.PanelPacking.Controls.Add(Me.Label39)
        Me.PanelPacking.Controls.Add(Me.txtPanPackMasterInchL)
        Me.PanelPacking.Controls.Add(Me.Label31)
        Me.PanelPacking.Controls.Add(Me.txtPanPackMasterInchH)
        Me.PanelPacking.Controls.Add(Me.Label32)
        Me.PanelPacking.Controls.Add(Me.txtPanPackMasterInchW)
        Me.PanelPacking.Controls.Add(Me.Label33)
        Me.PanelPacking.Controls.Add(Me.txtPanPackInnerInchL)
        Me.PanelPacking.Controls.Add(Me.Label17)
        Me.PanelPacking.Controls.Add(Me.txtPanPackInnerInchH)
        Me.PanelPacking.Controls.Add(Me.Label18)
        Me.PanelPacking.Controls.Add(Me.txtPanPackInnerInchW)
        Me.PanelPacking.Controls.Add(Me.Label20)
        Me.PanelPacking.Controls.Add(Me.Label16)
        Me.PanelPacking.Controls.Add(Me.txtPanPackCBM)
        Me.PanelPacking.Controls.Add(Me.Label15)
        Me.PanelPacking.Controls.Add(Me.txtPanPackCFT)
        Me.PanelPacking.Controls.Add(Me.Label13)
        Me.PanelPacking.Controls.Add(Me.txtPanPackMaster)
        Me.PanelPacking.Controls.Add(Me.txtPanPackInner)
        Me.PanelPacking.Controls.Add(Me.Label12)
        Me.PanelPacking.Controls.Add(Me.Label9)
        Me.PanelPacking.Controls.Add(Me.cboPanPackUM)
        Me.PanelPacking.Controls.Add(Me.Label8)
        Me.PanelPacking.Controls.Add(Me.cmdPanPackUpdate)
        Me.PanelPacking.Controls.Add(Me.cmdPanPackCancel)
        Me.PanelPacking.Location = New System.Drawing.Point(12, 116)
        Me.PanelPacking.Name = "PanelPacking"
        Me.PanelPacking.Size = New System.Drawing.Size(532, 369)
        Me.PanelPacking.TabIndex = 80
        Me.PanelPacking.Visible = False
        '
        'Label97
        '
        Me.Label97.AutoSize = True
        Me.Label97.Location = New System.Drawing.Point(2, 39)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(44, 14)
        Me.Label97.TabIndex = 553
        Me.Label97.Text = "Pri Cust"
        '
        'Label98
        '
        Me.Label98.AutoSize = True
        Me.Label98.Location = New System.Drawing.Point(2, 63)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(51, 14)
        Me.Label98.TabIndex = 552
        Me.Label98.Text = "Sec Cust"
        '
        'cboPanPackCus1no
        '
        Me.cboPanPackCus1no.FormattingEnabled = True
        Me.cboPanPackCus1no.Location = New System.Drawing.Point(56, 36)
        Me.cboPanPackCus1no.Name = "cboPanPackCus1no"
        Me.cboPanPackCus1no.Size = New System.Drawing.Size(222, 22)
        Me.cboPanPackCus1no.TabIndex = 104
        '
        'cboPanPackCus2no
        '
        Me.cboPanPackCus2no.FormattingEnabled = True
        Me.cboPanPackCus2no.Location = New System.Drawing.Point(56, 60)
        Me.cboPanPackCus2no.Name = "cboPanPackCus2no"
        Me.cboPanPackCus2no.Size = New System.Drawing.Size(222, 22)
        Me.cboPanPackCus2no.TabIndex = 104
        '
        'txtPanPackMaterial
        '
        Me.txtPanPackMaterial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackMaterial.Location = New System.Drawing.Point(284, 243)
        Me.txtPanPackMaterial.Name = "txtPanPackMaterial"
        Me.txtPanPackMaterial.Size = New System.Drawing.Size(240, 90)
        Me.txtPanPackMaterial.TabIndex = 125
        Me.txtPanPackMaterial.Text = ""
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.Location = New System.Drawing.Point(285, 226)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(55, 14)
        Me.Label82.TabIndex = 131
        Me.Label82.Text = "»²ÄÝ§÷®Æ"
        '
        'txtPanPackMasterSize
        '
        Me.txtPanPackMasterSize.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackMasterSize.Location = New System.Drawing.Point(284, 133)
        Me.txtPanPackMasterSize.Name = "txtPanPackMasterSize"
        Me.txtPanPackMasterSize.Size = New System.Drawing.Size(240, 90)
        Me.txtPanPackMasterSize.TabIndex = 124
        Me.txtPanPackMasterSize.Text = ""
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.Location = New System.Drawing.Point(285, 116)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(75, 14)
        Me.Label63.TabIndex = 129
        Me.Label63.Text = "¥~²°¤Ø½X(¤o)"
        '
        'txtPanPackInnerSize
        '
        Me.txtPanPackInnerSize.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackInnerSize.Location = New System.Drawing.Point(284, 23)
        Me.txtPanPackInnerSize.Name = "txtPanPackInnerSize"
        Me.txtPanPackInnerSize.Size = New System.Drawing.Size(240, 90)
        Me.txtPanPackInnerSize.TabIndex = 123
        Me.txtPanPackInnerSize.Text = "btnRelItm"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(285, 6)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(75, 14)
        Me.Label43.TabIndex = 127
        Me.Label43.Text = "¤º²°¤Ø½X(¤o)"
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.Location = New System.Drawing.Point(4, 94)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(38, 14)
        Me.Label79.TabIndex = 126
        Me.Label79.Text = "Factor"
        '
        'txtPanPackConFtr
        '
        Me.txtPanPackConFtr.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackConFtr.Location = New System.Drawing.Point(47, 92)
        Me.txtPanPackConFtr.Name = "txtPanPackConFtr"
        Me.txtPanPackConFtr.Size = New System.Drawing.Size(42, 20)
        Me.txtPanPackConFtr.TabIndex = 104
        '
        'txtPanPackPeriod
        '
        Me.txtPanPackPeriod.Location = New System.Drawing.Point(47, 118)
        Me.txtPanPackPeriod.Mask = "0000-00"
        Me.txtPanPackPeriod.Name = "txtPanPackPeriod"
        Me.txtPanPackPeriod.Size = New System.Drawing.Size(50, 20)
        Me.txtPanPackPeriod.TabIndex = 107
        '
        'cmdPanPackInsert
        '
        Me.cmdPanPackInsert.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPanPackInsert.Location = New System.Drawing.Point(317, 339)
        Me.cmdPanPackInsert.Name = "cmdPanPackInsert"
        Me.cmdPanPackInsert.Size = New System.Drawing.Size(65, 21)
        Me.cmdPanPackInsert.TabIndex = 126
        Me.cmdPanPackInsert.Text = "&Insert"
        Me.cmdPanPackInsert.UseVisualStyleBackColor = True
        '
        'txtPanPackPackingInstruction
        '
        Me.txtPanPackPackingInstruction.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackPackingInstruction.Location = New System.Drawing.Point(4, 258)
        Me.txtPanPackPackingInstruction.Name = "txtPanPackPackingInstruction"
        Me.txtPanPackPackingInstruction.Size = New System.Drawing.Size(274, 75)
        Me.txtPanPackPackingInstruction.TabIndex = 122
        Me.txtPanPackPackingInstruction.Text = ""
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(1, 241)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(97, 14)
        Me.Label51.TabIndex = 43
        Me.Label51.Text = "Packing Instruction"
        '
        'txtPanPackNW
        '
        Me.txtPanPackNW.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackNW.Location = New System.Drawing.Point(224, 118)
        Me.txtPanPackNW.Name = "txtPanPackNW"
        Me.txtPanPackNW.Size = New System.Drawing.Size(55, 20)
        Me.txtPanPackNW.TabIndex = 109
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(195, 121)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(24, 14)
        Me.Label49.TabIndex = 41
        Me.Label49.Text = "NW"
        '
        'txtPanPackGW
        '
        Me.txtPanPackGW.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackGW.Location = New System.Drawing.Point(134, 118)
        Me.txtPanPackGW.Name = "txtPanPackGW"
        Me.txtPanPackGW.Size = New System.Drawing.Size(55, 20)
        Me.txtPanPackGW.TabIndex = 108
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(103, 122)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(25, 14)
        Me.Label50.TabIndex = 39
        Me.Label50.Text = "GW"
        '
        'txtPanPackMasterCML
        '
        Me.txtPanPackMasterCML.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackMasterCML.Location = New System.Drawing.Point(116, 217)
        Me.txtPanPackMasterCML.Name = "txtPanPackMasterCML"
        Me.txtPanPackMasterCML.Size = New System.Drawing.Size(47, 20)
        Me.txtPanPackMasterCML.TabIndex = 119
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(2, 220)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(103, 14)
        Me.Label46.TabIndex = 37
        Me.Label46.Text = "Master (cm) LxWxH"
        '
        'txtPanPackMasterCMH
        '
        Me.txtPanPackMasterCMH.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackMasterCMH.Location = New System.Drawing.Point(234, 217)
        Me.txtPanPackMasterCMH.Name = "txtPanPackMasterCMH"
        Me.txtPanPackMasterCMH.Size = New System.Drawing.Size(47, 20)
        Me.txtPanPackMasterCMH.TabIndex = 121
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(222, 220)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(14, 14)
        Me.Label47.TabIndex = 35
        Me.Label47.Text = "X"
        '
        'txtPanPackMasterCMW
        '
        Me.txtPanPackMasterCMW.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackMasterCMW.Location = New System.Drawing.Point(175, 217)
        Me.txtPanPackMasterCMW.Name = "txtPanPackMasterCMW"
        Me.txtPanPackMasterCMW.Size = New System.Drawing.Size(47, 20)
        Me.txtPanPackMasterCMW.TabIndex = 120
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(163, 220)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(14, 14)
        Me.Label48.TabIndex = 33
        Me.Label48.Text = "X"
        '
        'txtPanPackInnerCML
        '
        Me.txtPanPackInnerCML.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackInnerCML.Location = New System.Drawing.Point(116, 194)
        Me.txtPanPackInnerCML.Name = "txtPanPackInnerCML"
        Me.txtPanPackInnerCML.Size = New System.Drawing.Size(47, 20)
        Me.txtPanPackInnerCML.TabIndex = 116
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(2, 197)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(94, 14)
        Me.Label34.TabIndex = 31
        Me.Label34.Text = "Inner (cm) LxWxH"
        '
        'txtPanPackInnerCMH
        '
        Me.txtPanPackInnerCMH.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackInnerCMH.Location = New System.Drawing.Point(234, 194)
        Me.txtPanPackInnerCMH.Name = "txtPanPackInnerCMH"
        Me.txtPanPackInnerCMH.Size = New System.Drawing.Size(47, 20)
        Me.txtPanPackInnerCMH.TabIndex = 118
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(222, 197)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(14, 14)
        Me.Label38.TabIndex = 29
        Me.Label38.Text = "X"
        '
        'txtPanPackInnerCMW
        '
        Me.txtPanPackInnerCMW.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackInnerCMW.Location = New System.Drawing.Point(175, 194)
        Me.txtPanPackInnerCMW.Name = "txtPanPackInnerCMW"
        Me.txtPanPackInnerCMW.Size = New System.Drawing.Size(47, 20)
        Me.txtPanPackInnerCMW.TabIndex = 117
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(163, 197)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(14, 14)
        Me.Label39.TabIndex = 27
        Me.Label39.Text = "X"
        '
        'txtPanPackMasterInchL
        '
        Me.txtPanPackMasterInchL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackMasterInchL.Location = New System.Drawing.Point(116, 171)
        Me.txtPanPackMasterInchL.Name = "txtPanPackMasterInchL"
        Me.txtPanPackMasterInchL.Size = New System.Drawing.Size(47, 20)
        Me.txtPanPackMasterInchL.TabIndex = 113
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(1, 174)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(109, 14)
        Me.Label31.TabIndex = 25
        Me.Label31.Text = "Master (inch) LxWxH"
        '
        'txtPanPackMasterInchH
        '
        Me.txtPanPackMasterInchH.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackMasterInchH.Location = New System.Drawing.Point(234, 171)
        Me.txtPanPackMasterInchH.Name = "txtPanPackMasterInchH"
        Me.txtPanPackMasterInchH.Size = New System.Drawing.Size(47, 20)
        Me.txtPanPackMasterInchH.TabIndex = 115
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(222, 174)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(14, 14)
        Me.Label32.TabIndex = 23
        Me.Label32.Text = "X"
        '
        'txtPanPackMasterInchW
        '
        Me.txtPanPackMasterInchW.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackMasterInchW.Location = New System.Drawing.Point(175, 171)
        Me.txtPanPackMasterInchW.Name = "txtPanPackMasterInchW"
        Me.txtPanPackMasterInchW.Size = New System.Drawing.Size(47, 20)
        Me.txtPanPackMasterInchW.TabIndex = 114
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(163, 174)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(14, 14)
        Me.Label33.TabIndex = 21
        Me.Label33.Text = "X"
        '
        'txtPanPackInnerInchL
        '
        Me.txtPanPackInnerInchL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackInnerInchL.Location = New System.Drawing.Point(116, 148)
        Me.txtPanPackInnerInchL.Name = "txtPanPackInnerInchL"
        Me.txtPanPackInnerInchL.Size = New System.Drawing.Size(47, 20)
        Me.txtPanPackInnerInchL.TabIndex = 110
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(2, 151)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 14)
        Me.Label17.TabIndex = 19
        Me.Label17.Text = "Inner (inch) LxWxH"
        '
        'txtPanPackInnerInchH
        '
        Me.txtPanPackInnerInchH.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackInnerInchH.Location = New System.Drawing.Point(234, 148)
        Me.txtPanPackInnerInchH.Name = "txtPanPackInnerInchH"
        Me.txtPanPackInnerInchH.Size = New System.Drawing.Size(47, 20)
        Me.txtPanPackInnerInchH.TabIndex = 112
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(222, 151)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(14, 14)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "X"
        '
        'txtPanPackInnerInchW
        '
        Me.txtPanPackInnerInchW.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackInnerInchW.Location = New System.Drawing.Point(175, 148)
        Me.txtPanPackInnerInchW.Name = "txtPanPackInnerInchW"
        Me.txtPanPackInnerInchW.Size = New System.Drawing.Size(47, 20)
        Me.txtPanPackInnerInchW.TabIndex = 111
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(163, 151)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(14, 14)
        Me.Label20.TabIndex = 15
        Me.Label20.Text = "X"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(4, 120)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(37, 14)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "Period"
        '
        'txtPanPackCBM
        '
        Me.txtPanPackCBM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackCBM.Location = New System.Drawing.Point(225, 91)
        Me.txtPanPackCBM.Name = "txtPanPackCBM"
        Me.txtPanPackCBM.Size = New System.Drawing.Size(55, 20)
        Me.txtPanPackCBM.TabIndex = 106
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(190, 94)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 14)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "CBM"
        '
        'txtPanPackCFT
        '
        Me.txtPanPackCFT.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackCFT.Location = New System.Drawing.Point(134, 92)
        Me.txtPanPackCFT.Name = "txtPanPackCFT"
        Me.txtPanPackCFT.Size = New System.Drawing.Size(55, 20)
        Me.txtPanPackCFT.TabIndex = 105
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(103, 95)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(26, 14)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "CFT"
        '
        'txtPanPackMaster
        '
        Me.txtPanPackMaster.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackMaster.Location = New System.Drawing.Point(237, 10)
        Me.txtPanPackMaster.Name = "txtPanPackMaster"
        Me.txtPanPackMaster.Size = New System.Drawing.Size(42, 20)
        Me.txtPanPackMaster.TabIndex = 103
        '
        'txtPanPackInner
        '
        Me.txtPanPackInner.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPackInner.Location = New System.Drawing.Point(146, 10)
        Me.txtPanPackInner.Name = "txtPanPackInner"
        Me.txtPanPackInner.Size = New System.Drawing.Size(42, 20)
        Me.txtPanPackInner.TabIndex = 102
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(191, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 14)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Master"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(109, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 14)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Inner"
        '
        'cboPanPackUM
        '
        Me.cboPanPackUM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPanPackUM.FormattingEnabled = True
        Me.cboPanPackUM.Location = New System.Drawing.Point(24, 9)
        Me.cboPanPackUM.Name = "cboPanPackUM"
        Me.cboPanPackUM.Size = New System.Drawing.Size(70, 22)
        Me.cboPanPackUM.TabIndex = 101
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 14)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "UM"
        '
        'cmdPanPackUpdate
        '
        Me.cmdPanPackUpdate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPanPackUpdate.Location = New System.Drawing.Point(388, 339)
        Me.cmdPanPackUpdate.Name = "cmdPanPackUpdate"
        Me.cmdPanPackUpdate.Size = New System.Drawing.Size(65, 21)
        Me.cmdPanPackUpdate.TabIndex = 127
        Me.cmdPanPackUpdate.Text = "&Update"
        Me.cmdPanPackUpdate.UseVisualStyleBackColor = True
        '
        'cmdPanPackCancel
        '
        Me.cmdPanPackCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPanPackCancel.Location = New System.Drawing.Point(459, 339)
        Me.cmdPanPackCancel.Name = "cmdPanPackCancel"
        Me.cmdPanPackCancel.Size = New System.Drawing.Size(65, 22)
        Me.cmdPanPackCancel.TabIndex = 128
        Me.cmdPanPackCancel.Text = "&Quit"
        Me.cmdPanPackCancel.UseVisualStyleBackColor = True
        '
        'pbImage
        '
        Me.pbImage.BackColor = System.Drawing.Color.White
        Me.pbImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbImage.InitialImage = Nothing
        Me.pbImage.Location = New System.Drawing.Point(687, 188)
        Me.pbImage.MaximumSize = New System.Drawing.Size(500, 500)
        Me.pbImage.Name = "pbImage"
        Me.pbImage.Size = New System.Drawing.Size(249, 304)
        Me.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImage.TabIndex = 82
        Me.pbImage.TabStop = False
        '
        'lblItmRmk
        '
        Me.lblItmRmk.AutoSize = True
        Me.lblItmRmk.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItmRmk.Location = New System.Drawing.Point(535, 6)
        Me.lblItmRmk.Name = "lblItmRmk"
        Me.lblItmRmk.Size = New System.Drawing.Size(71, 14)
        Me.lblItmRmk.TabIndex = 78
        Me.lblItmRmk.Text = "Item Remark :"
        '
        'lblPacking
        '
        Me.lblPacking.AutoSize = True
        Me.lblPacking.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPacking.ForeColor = System.Drawing.Color.Blue
        Me.lblPacking.Location = New System.Drawing.Point(6, 301)
        Me.lblPacking.Name = "lblPacking"
        Me.lblPacking.Size = New System.Drawing.Size(50, 14)
        Me.lblPacking.TabIndex = 77
        Me.lblPacking.Text = "Packing :"
        '
        'dgPacking
        '
        Me.dgPacking.AllowUserToAddRows = False
        Me.dgPacking.AllowUserToDeleteRows = False
        Me.dgPacking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.NullValue = """"""
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPacking.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgPacking.Location = New System.Drawing.Point(7, 317)
        Me.dgPacking.Name = "dgPacking"
        Me.dgPacking.RowHeadersWidth = 30
        Me.dgPacking.RowTemplate.Height = 18
        Me.dgPacking.Size = New System.Drawing.Size(674, 174)
        Me.dgPacking.TabIndex = 55
        '
        'dgColor
        '
        Me.dgColor.AllowUserToAddRows = False
        Me.dgColor.AllowUserToDeleteRows = False
        Me.dgColor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.NullValue = """"""
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgColor.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgColor.Location = New System.Drawing.Point(6, 205)
        Me.dgColor.Name = "dgColor"
        Me.dgColor.RowHeadersWidth = 30
        Me.dgColor.RowTemplate.Height = 24
        Me.dgColor.Size = New System.Drawing.Size(675, 93)
        Me.dgColor.TabIndex = 54
        '
        'txtChnDsc
        '
        Me.txtChnDsc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChnDsc.Location = New System.Drawing.Point(117, 94)
        Me.txtChnDsc.MaxLength = 800
        Me.txtChnDsc.Name = "txtChnDsc"
        Me.txtChnDsc.Size = New System.Drawing.Size(414, 88)
        Me.txtChnDsc.TabIndex = 52
        Me.txtChnDsc.Text = "35""/ªáÝßªG³æªK¥[¶ì½¦¯]/RDD175"
        '
        'lblColor
        '
        Me.lblColor.AutoSize = True
        Me.lblColor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColor.ForeColor = System.Drawing.Color.Blue
        Me.lblColor.Location = New System.Drawing.Point(6, 188)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(38, 14)
        Me.lblColor.TabIndex = 71
        Me.lblColor.Text = "Color :"
        '
        'txtEngDsc
        '
        Me.txtEngDsc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEngDsc.Location = New System.Drawing.Point(117, 3)
        Me.txtEngDsc.MaxLength = 800
        Me.txtEngDsc.Name = "txtEngDsc"
        Me.txtEngDsc.Size = New System.Drawing.Size(414, 85)
        Me.txtEngDsc.TabIndex = 51
        Me.txtEngDsc.Text = "35""MOUNTAIN ASH STEM"
        '
        'lblChnDsc
        '
        Me.lblChnDsc.AutoSize = True
        Me.lblChnDsc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChnDsc.Location = New System.Drawing.Point(1, 99)
        Me.lblChnDsc.Name = "lblChnDsc"
        Me.lblChnDsc.Size = New System.Drawing.Size(109, 14)
        Me.lblChnDsc.TabIndex = 18
        Me.lblChnDsc.Text = "Chinese Description :"
        '
        'lblEngDsc
        '
        Me.lblEngDsc.AutoSize = True
        Me.lblEngDsc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEngDsc.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblEngDsc.Location = New System.Drawing.Point(3, 6)
        Me.lblEngDsc.Name = "lblEngDsc"
        Me.lblEngDsc.Size = New System.Drawing.Size(104, 14)
        Me.lblEngDsc.TabIndex = 17
        Me.lblEngDsc.Text = "English Description :"
        '
        'cmdCombineImage
        '
        Me.cmdCombineImage.Location = New System.Drawing.Point(439, 298)
        Me.cmdCombineImage.Name = "cmdCombineImage"
        Me.cmdCombineImage.Size = New System.Drawing.Size(105, 20)
        Me.cmdCombineImage.TabIndex = 81
        Me.cmdCombineImage.Text = "Co&mbine Image"
        Me.cmdCombineImage.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.cmdCopyPV)
        Me.TabPage2.Controls.Add(Me.PanelPV)
        Me.TabPage2.Controls.Add(Me.lblPV)
        Me.TabPage2.Controls.Add(Me.cboEV)
        Me.TabPage2.Controls.Add(Me.lblEV)
        Me.TabPage2.Controls.Add(Me.cboTV)
        Me.TabPage2.Controls.Add(Me.lblTV)
        Me.TabPage2.Controls.Add(Me.cboCV)
        Me.TabPage2.Controls.Add(Me.lblCV)
        Me.TabPage2.Controls.Add(Me.cboDV)
        Me.TabPage2.Controls.Add(Me.lblDV)
        Me.TabPage2.Controls.Add(Me.dgPV)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(942, 498)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "(2) Vendor"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cmdCopyPV
        '
        Me.cmdCopyPV.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.cmdCopyPV.Location = New System.Drawing.Point(547, 11)
        Me.cmdCopyPV.Name = "cmdCopyPV"
        Me.cmdCopyPV.Size = New System.Drawing.Size(145, 21)
        Me.cmdCopyPV.TabIndex = 206
        Me.cmdCopyPV.Text = "Apply Def PV to CV,TV,FA"
        Me.cmdCopyPV.UseVisualStyleBackColor = True
        '
        'PanelPV
        '
        Me.PanelPV.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelPV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelPV.Controls.Add(Me.cmdPanPVInsert)
        Me.PanelPV.Controls.Add(Me.Label94)
        Me.PanelPV.Controls.Add(Me.txtPanPVVenItm)
        Me.PanelPV.Controls.Add(Me.cboPanPVPV)
        Me.PanelPV.Controls.Add(Me.Label99)
        Me.PanelPV.Controls.Add(Me.cmdPanPVCancel)
        Me.PanelPV.Location = New System.Drawing.Point(275, 298)
        Me.PanelPV.Name = "PanelPV"
        Me.PanelPV.Size = New System.Drawing.Size(299, 98)
        Me.PanelPV.TabIndex = 205
        Me.PanelPV.Visible = False
        '
        'cmdPanPVInsert
        '
        Me.cmdPanPVInsert.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPanPVInsert.Location = New System.Drawing.Point(187, 66)
        Me.cmdPanPVInsert.Name = "cmdPanPVInsert"
        Me.cmdPanPVInsert.Size = New System.Drawing.Size(49, 21)
        Me.cmdPanPVInsert.TabIndex = 212
        Me.cmdPanPVInsert.Text = "Insert"
        Me.cmdPanPVInsert.UseVisualStyleBackColor = True
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label94.Location = New System.Drawing.Point(6, 41)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(96, 14)
        Me.Label94.TabIndex = 13
        Me.Label94.Text = "Production Vendor"
        '
        'txtPanPVVenItm
        '
        Me.txtPanPVVenItm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanPVVenItm.Location = New System.Drawing.Point(125, 9)
        Me.txtPanPVVenItm.Name = "txtPanPVVenItm"
        Me.txtPanPVVenItm.Size = New System.Drawing.Size(161, 20)
        Me.txtPanPVVenItm.TabIndex = 210
        '
        'cboPanPVPV
        '
        Me.cboPanPVPV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPanPVPV.FormattingEnabled = True
        Me.cboPanPVPV.Location = New System.Drawing.Point(125, 38)
        Me.cboPanPVPV.Name = "cboPanPVPV"
        Me.cboPanPVPV.Size = New System.Drawing.Size(161, 22)
        Me.cboPanPVPV.TabIndex = 211
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label99.Location = New System.Drawing.Point(6, 12)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(104, 14)
        Me.Label99.TabIndex = 3
        Me.Label99.Text = "Vendor Item Number"
        '
        'cmdPanPVCancel
        '
        Me.cmdPanPVCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPanPVCancel.Location = New System.Drawing.Point(238, 66)
        Me.cmdPanPVCancel.Name = "cmdPanPVCancel"
        Me.cmdPanPVCancel.Size = New System.Drawing.Size(48, 22)
        Me.cmdPanPVCancel.TabIndex = 213
        Me.cmdPanPVCancel.Text = "Cancel"
        Me.cmdPanPVCancel.UseVisualStyleBackColor = True
        '
        'lblPV
        '
        Me.lblPV.AutoSize = True
        Me.lblPV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPV.ForeColor = System.Drawing.Color.Blue
        Me.lblPV.Location = New System.Drawing.Point(8, 145)
        Me.lblPV.Name = "lblPV"
        Me.lblPV.Size = New System.Drawing.Size(102, 14)
        Me.lblPV.TabIndex = 66
        Me.lblPV.Text = "Production Vendor :"
        '
        'cboEV
        '
        Me.cboEV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEV.FormattingEnabled = True
        Me.cboEV.Location = New System.Drawing.Point(96, 104)
        Me.cboEV.Name = "cboEV"
        Me.cboEV.Size = New System.Drawing.Size(445, 22)
        Me.cboEV.TabIndex = 204
        '
        'lblEV
        '
        Me.lblEV.AutoSize = True
        Me.lblEV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEV.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblEV.Location = New System.Drawing.Point(8, 107)
        Me.lblEV.Name = "lblEV"
        Me.lblEV.Size = New System.Drawing.Size(77, 14)
        Me.lblEV.TabIndex = 64
        Me.lblEV.Text = "Factory Audit :"
        '
        'cboTV
        '
        Me.cboTV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTV.FormattingEnabled = True
        Me.cboTV.Location = New System.Drawing.Point(96, 73)
        Me.cboTV.Name = "cboTV"
        Me.cboTV.Size = New System.Drawing.Size(445, 22)
        Me.cboTV.TabIndex = 203
        '
        'lblTV
        '
        Me.lblTV.AutoSize = True
        Me.lblTV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTV.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblTV.Location = New System.Drawing.Point(8, 76)
        Me.lblTV.Name = "lblTV"
        Me.lblTV.Size = New System.Drawing.Size(87, 14)
        Me.lblTV.TabIndex = 62
        Me.lblTV.Text = "Trading Vendor :"
        '
        'cboCV
        '
        Me.cboCV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCV.FormattingEnabled = True
        Me.cboCV.Location = New System.Drawing.Point(96, 42)
        Me.cboCV.Name = "cboCV"
        Me.cboCV.Size = New System.Drawing.Size(445, 22)
        Me.cboCV.TabIndex = 202
        '
        'lblCV
        '
        Me.lblCV.AutoSize = True
        Me.lblCV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCV.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblCV.Location = New System.Drawing.Point(8, 45)
        Me.lblCV.Name = "lblCV"
        Me.lblCV.Size = New System.Drawing.Size(87, 14)
        Me.lblCV.TabIndex = 60
        Me.lblCV.Text = "Custom Vendor :"
        '
        'cboDV
        '
        Me.cboDV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDV.FormattingEnabled = True
        Me.cboDV.Location = New System.Drawing.Point(96, 11)
        Me.cboDV.Name = "cboDV"
        Me.cboDV.Size = New System.Drawing.Size(445, 22)
        Me.cboDV.TabIndex = 201
        '
        'lblDV
        '
        Me.lblDV.AutoSize = True
        Me.lblDV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDV.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblDV.Location = New System.Drawing.Point(8, 14)
        Me.lblDV.Name = "lblDV"
        Me.lblDV.Size = New System.Drawing.Size(84, 14)
        Me.lblDV.TabIndex = 54
        Me.lblDV.Text = "Design Vendor :"
        '
        'dgPV
        '
        Me.dgPV.AllowUserToAddRows = False
        Me.dgPV.AllowUserToDeleteRows = False
        Me.dgPV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.NullValue = """"""
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPV.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgPV.Location = New System.Drawing.Point(8, 162)
        Me.dgPV.Name = "dgPV"
        Me.dgPV.RowHeadersWidth = 30
        Me.dgPV.RowTemplate.Height = 24
        Me.dgPV.Size = New System.Drawing.Size(926, 330)
        Me.dgPV.TabIndex = 205
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.pbImage2)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Controls.Add(Me.cboCategory)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.cboPrdLne)
        Me.TabPage3.Controls.Add(Me.cboItmVenTyp)
        Me.TabPage3.Controls.Add(Me.lblItmVenTyp)
        Me.TabPage3.Controls.Add(Me.lblOEMCustomer)
        Me.TabPage3.Controls.Add(Me.dgOEMCustomer)
        Me.TabPage3.Controls.Add(Me.cboYear)
        Me.TabPage3.Controls.Add(Me.Label30)
        Me.TabPage3.Controls.Add(Me.cboType)
        Me.TabPage3.Controls.Add(Me.Label29)
        Me.TabPage3.Controls.Add(Me.cboDevTeam)
        Me.TabPage3.Controls.Add(Me.Label28)
        Me.TabPage3.Controls.Add(Me.cboDesigner)
        Me.TabPage3.Controls.Add(Me.Label27)
        Me.TabPage3.Controls.Add(Me.cboSeason)
        Me.TabPage3.Controls.Add(Me.Label26)
        Me.TabPage3.Controls.Add(Me.Label25)
        Me.TabPage3.Controls.Add(Me.Label24)
        Me.TabPage3.Controls.Add(Me.Label23)
        Me.TabPage3.Controls.Add(Me.cboPrdSizeTyp)
        Me.TabPage3.Controls.Add(Me.cboPrdSizeUnit)
        Me.TabPage3.Controls.Add(Me.Label22)
        Me.TabPage3.Controls.Add(Me.cboPrdIcon)
        Me.TabPage3.Controls.Add(Me.Label21)
        Me.TabPage3.Controls.Add(Me.cboPrdGroup)
        Me.TabPage3.Controls.Add(Me.txtPrdSizeValue)
        Me.TabPage3.Controls.Add(Me.txtDsgItmNo)
        Me.TabPage3.Controls.Add(Me.lblDsgItmNo)
        Me.TabPage3.Controls.Add(Me.cboPrdTyp)
        Me.TabPage3.Controls.Add(Me.lblPrdTyp)
        Me.TabPage3.Controls.Add(Me.lblItmNature)
        Me.TabPage3.Controls.Add(Me.cboItmNature)
        Me.TabPage3.Controls.Add(Me.lblMaterial)
        Me.TabPage3.Controls.Add(Me.cboMaterial)
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(942, 498)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "(3) Classification"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(33, 186)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(74, 14)
        Me.Label19.TabIndex = 71
        Me.Label19.Text = "Product Size :"
        '
        'pbImage2
        '
        Me.pbImage2.BackColor = System.Drawing.Color.White
        Me.pbImage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbImage2.InitialImage = Nothing
        Me.pbImage2.Location = New System.Drawing.Point(740, 273)
        Me.pbImage2.MaximumSize = New System.Drawing.Size(500, 500)
        Me.pbImage2.Name = "pbImage2"
        Me.pbImage2.Size = New System.Drawing.Size(175, 219)
        Me.pbImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImage2.TabIndex = 319
        Me.pbImage2.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(37, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 14)
        Me.Label11.TabIndex = 98
        Me.Label11.Text = "Category :"
        '
        'cboCategory
        '
        Me.cboCategory.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(138, 53)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(777, 22)
        Me.cboCategory.TabIndex = 302
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(37, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 14)
        Me.Label10.TabIndex = 96
        Me.Label10.Text = "Product Line :"
        '
        'cboPrdLne
        '
        Me.cboPrdLne.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPrdLne.FormattingEnabled = True
        Me.cboPrdLne.Location = New System.Drawing.Point(138, 20)
        Me.cboPrdLne.Name = "cboPrdLne"
        Me.cboPrdLne.Size = New System.Drawing.Size(200, 22)
        Me.cboPrdLne.TabIndex = 301
        '
        'cboItmVenTyp
        '
        Me.cboItmVenTyp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboItmVenTyp.FormattingEnabled = True
        Me.cboItmVenTyp.Location = New System.Drawing.Point(615, 20)
        Me.cboItmVenTyp.Name = "cboItmVenTyp"
        Me.cboItmVenTyp.Size = New System.Drawing.Size(178, 22)
        Me.cboItmVenTyp.TabIndex = 303
        '
        'lblItmVenTyp
        '
        Me.lblItmVenTyp.AutoSize = True
        Me.lblItmVenTyp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItmVenTyp.Location = New System.Drawing.Point(498, 23)
        Me.lblItmVenTyp.Name = "lblItmVenTyp"
        Me.lblItmVenTyp.Size = New System.Drawing.Size(96, 14)
        Me.lblItmVenTyp.TabIndex = 93
        Me.lblItmVenTyp.Text = "Item Vendor Type :"
        '
        'lblOEMCustomer
        '
        Me.lblOEMCustomer.AutoSize = True
        Me.lblOEMCustomer.BackColor = System.Drawing.Color.Transparent
        Me.lblOEMCustomer.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOEMCustomer.Location = New System.Drawing.Point(498, 115)
        Me.lblOEMCustomer.Name = "lblOEMCustomer"
        Me.lblOEMCustomer.Size = New System.Drawing.Size(78, 14)
        Me.lblOEMCustomer.TabIndex = 92
        Me.lblOEMCustomer.Text = "OEM Customer"
        '
        'dgOEMCustomer
        '
        Me.dgOEMCustomer.AllowUserToAddRows = False
        Me.dgOEMCustomer.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.NullValue = """"""
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOEMCustomer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgOEMCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOEMCustomer.Location = New System.Drawing.Point(501, 132)
        Me.dgOEMCustomer.Name = "dgOEMCustomer"
        Me.dgOEMCustomer.RowHeadersWidth = 30
        Me.dgOEMCustomer.RowTemplate.Height = 24
        Me.dgOEMCustomer.Size = New System.Drawing.Size(414, 135)
        Me.dgOEMCustomer.TabIndex = 306
        '
        'cboYear
        '
        Me.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboYear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(137, 405)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(340, 22)
        Me.cboYear.TabIndex = 318
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(34, 407)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(36, 14)
        Me.Label30.TabIndex = 89
        Me.Label30.Text = "Year :"
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboType.FormattingEnabled = True
        Me.cboType.Location = New System.Drawing.Point(137, 373)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(340, 22)
        Me.cboType.TabIndex = 317
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(34, 375)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(36, 14)
        Me.Label29.TabIndex = 87
        Me.Label29.Text = "Type :"
        '
        'cboDevTeam
        '
        Me.cboDevTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDevTeam.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDevTeam.FormattingEnabled = True
        Me.cboDevTeam.Location = New System.Drawing.Point(137, 341)
        Me.cboDevTeam.Name = "cboDevTeam"
        Me.cboDevTeam.Size = New System.Drawing.Size(340, 22)
        Me.cboDevTeam.TabIndex = 316
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(34, 343)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(103, 14)
        Me.Label28.TabIndex = 85
        Me.Label28.Text = "Development Team :"
        '
        'cboDesigner
        '
        Me.cboDesigner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDesigner.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDesigner.FormattingEnabled = True
        Me.cboDesigner.Location = New System.Drawing.Point(137, 309)
        Me.cboDesigner.Name = "cboDesigner"
        Me.cboDesigner.Size = New System.Drawing.Size(340, 22)
        Me.cboDesigner.TabIndex = 315
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(34, 309)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(56, 14)
        Me.Label27.TabIndex = 83
        Me.Label27.Text = "Designer :"
        '
        'cboSeason
        '
        Me.cboSeason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSeason.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSeason.FormattingEnabled = True
        Me.cboSeason.Location = New System.Drawing.Point(137, 277)
        Me.cboSeason.Name = "cboSeason"
        Me.cboSeason.Size = New System.Drawing.Size(340, 22)
        Me.cboSeason.TabIndex = 314
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(34, 277)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(50, 14)
        Me.Label26.TabIndex = 81
        Me.Label26.Text = "Season :"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(388, 186)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(34, 14)
        Me.Label25.TabIndex = 80
        Me.Label25.Text = "Value"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(254, 188)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(25, 14)
        Me.Label24.TabIndex = 79
        Me.Label24.Text = "Unit"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(103, 186)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(30, 14)
        Me.Label23.TabIndex = 78
        Me.Label23.Text = "Type"
        '
        'cboPrdSizeTyp
        '
        Me.cboPrdSizeTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrdSizeTyp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPrdSizeTyp.FormattingEnabled = True
        Me.cboPrdSizeTyp.Location = New System.Drawing.Point(137, 183)
        Me.cboPrdSizeTyp.Name = "cboPrdSizeTyp"
        Me.cboPrdSizeTyp.Size = New System.Drawing.Size(109, 22)
        Me.cboPrdSizeTyp.TabIndex = 309
        '
        'cboPrdSizeUnit
        '
        Me.cboPrdSizeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrdSizeUnit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPrdSizeUnit.FormattingEnabled = True
        Me.cboPrdSizeUnit.Location = New System.Drawing.Point(280, 183)
        Me.cboPrdSizeUnit.Name = "cboPrdSizeUnit"
        Me.cboPrdSizeUnit.Size = New System.Drawing.Size(102, 22)
        Me.cboPrdSizeUnit.TabIndex = 310
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(34, 216)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(83, 14)
        Me.Label22.TabIndex = 75
        Me.Label22.Text = "Product Group :"
        '
        'cboPrdIcon
        '
        Me.cboPrdIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrdIcon.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPrdIcon.FormattingEnabled = True
        Me.cboPrdIcon.Location = New System.Drawing.Point(137, 245)
        Me.cboPrdIcon.Name = "cboPrdIcon"
        Me.cboPrdIcon.Size = New System.Drawing.Size(340, 22)
        Me.cboPrdIcon.TabIndex = 313
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(34, 245)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(73, 14)
        Me.Label21.TabIndex = 73
        Me.Label21.Text = "Product Icon :"
        '
        'cboPrdGroup
        '
        Me.cboPrdGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrdGroup.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPrdGroup.FormattingEnabled = True
        Me.cboPrdGroup.Location = New System.Drawing.Point(137, 213)
        Me.cboPrdGroup.Name = "cboPrdGroup"
        Me.cboPrdGroup.Size = New System.Drawing.Size(340, 22)
        Me.cboPrdGroup.TabIndex = 312
        '
        'txtPrdSizeValue
        '
        Me.txtPrdSizeValue.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrdSizeValue.Location = New System.Drawing.Point(423, 183)
        Me.txtPrdSizeValue.Name = "txtPrdSizeValue"
        Me.txtPrdSizeValue.Size = New System.Drawing.Size(54, 20)
        Me.txtPrdSizeValue.TabIndex = 311
        '
        'txtDsgItmNo
        '
        Me.txtDsgItmNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDsgItmNo.Location = New System.Drawing.Point(137, 85)
        Me.txtDsgItmNo.MaxLength = 50
        Me.txtDsgItmNo.Name = "txtDsgItmNo"
        Me.txtDsgItmNo.Size = New System.Drawing.Size(201, 20)
        Me.txtDsgItmNo.TabIndex = 304
        '
        'lblDsgItmNo
        '
        Me.lblDsgItmNo.AutoSize = True
        Me.lblDsgItmNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDsgItmNo.Location = New System.Drawing.Point(37, 88)
        Me.lblDsgItmNo.Name = "lblDsgItmNo"
        Me.lblDsgItmNo.Size = New System.Drawing.Size(84, 14)
        Me.lblDsgItmNo.TabIndex = 69
        Me.lblDsgItmNo.Text = "Design Item No :"
        '
        'cboPrdTyp
        '
        Me.cboPrdTyp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPrdTyp.FormattingEnabled = True
        Me.cboPrdTyp.Location = New System.Drawing.Point(615, 85)
        Me.cboPrdTyp.Name = "cboPrdTyp"
        Me.cboPrdTyp.Size = New System.Drawing.Size(178, 22)
        Me.cboPrdTyp.TabIndex = 305
        '
        'lblPrdTyp
        '
        Me.lblPrdTyp.AutoSize = True
        Me.lblPrdTyp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrdTyp.Location = New System.Drawing.Point(498, 88)
        Me.lblPrdTyp.Name = "lblPrdTyp"
        Me.lblPrdTyp.Size = New System.Drawing.Size(76, 14)
        Me.lblPrdTyp.TabIndex = 66
        Me.lblPrdTyp.Text = "Product Type :"
        '
        'lblItmNature
        '
        Me.lblItmNature.AutoSize = True
        Me.lblItmNature.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItmNature.Location = New System.Drawing.Point(37, 154)
        Me.lblItmNature.Name = "lblItmNature"
        Me.lblItmNature.Size = New System.Drawing.Size(67, 14)
        Me.lblItmNature.TabIndex = 64
        Me.lblItmNature.Text = "Item Nature :"
        '
        'cboItmNature
        '
        Me.cboItmNature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItmNature.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboItmNature.FormattingEnabled = True
        Me.cboItmNature.Location = New System.Drawing.Point(137, 151)
        Me.cboItmNature.Name = "cboItmNature"
        Me.cboItmNature.Size = New System.Drawing.Size(340, 22)
        Me.cboItmNature.TabIndex = 308
        '
        'lblMaterial
        '
        Me.lblMaterial.AutoSize = True
        Me.lblMaterial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaterial.Location = New System.Drawing.Point(37, 120)
        Me.lblMaterial.Name = "lblMaterial"
        Me.lblMaterial.Size = New System.Drawing.Size(75, 14)
        Me.lblMaterial.TabIndex = 62
        Me.lblMaterial.Text = "Key Material : "
        '
        'cboMaterial
        '
        Me.cboMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaterial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMaterial.FormattingEnabled = True
        Me.cboMaterial.Location = New System.Drawing.Point(137, 117)
        Me.cboMaterial.Name = "cboMaterial"
        Me.cboMaterial.Size = New System.Drawing.Size(340, 22)
        Me.cboMaterial.TabIndex = 307
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.lbBOMColor)
        Me.TabPage4.Controls.Add(Me.lblBOMASS)
        Me.TabPage4.Controls.Add(Me.IMTreeView)
        Me.TabPage4.Controls.Add(Me.Label42)
        Me.TabPage4.Controls.Add(Me.Label41)
        Me.TabPage4.Controls.Add(Me.dgRelParentItem)
        Me.TabPage4.Controls.Add(Me.GroupBox6)
        Me.TabPage4.Controls.Add(Me.Label40)
        Me.TabPage4.Controls.Add(Me.dgBOMASS)
        Me.TabPage4.Location = New System.Drawing.Point(4, 23)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(942, 498)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "(4) BOM/Assortment"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'lbBOMColor
        '
        Me.lbBOMColor.FormattingEnabled = True
        Me.lbBOMColor.ItemHeight = 14
        Me.lbBOMColor.Location = New System.Drawing.Point(19, 140)
        Me.lbBOMColor.Name = "lbBOMColor"
        Me.lbBOMColor.Size = New System.Drawing.Size(122, 46)
        Me.lbBOMColor.TabIndex = 64
        Me.lbBOMColor.Visible = False
        '
        'lblBOMASS
        '
        Me.lblBOMASS.AutoSize = True
        Me.lblBOMASS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBOMASS.Location = New System.Drawing.Point(8, 11)
        Me.lblBOMASS.Name = "lblBOMASS"
        Me.lblBOMASS.Size = New System.Drawing.Size(94, 14)
        Me.lblBOMASS.TabIndex = 63
        Me.lblBOMASS.Text = "BOM / Assortment"
        '
        'IMTreeView
        '
        Me.IMTreeView.Location = New System.Drawing.Point(6, 255)
        Me.IMTreeView.Name = "IMTreeView"
        TreeNode1.Name = "Node4"
        TreeNode1.Text = "(BOM) 3710060500C PC/0/2"
        TreeNode2.Name = "Node0"
        TreeNode2.Text = "(REG) 12A001A001A01 PC/0/3"
        Me.IMTreeView.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode2})
        Me.IMTreeView.Size = New System.Drawing.Size(265, 240)
        Me.IMTreeView.TabIndex = 404
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(274, 238)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(99, 14)
        Me.Label42.TabIndex = 61
        Me.Label42.Text = "Related Parent Item"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(8, 238)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(80, 14)
        Me.Label41.TabIndex = 60
        Me.Label41.Text = "Item Tree View"
        '
        'dgRelParentItem
        '
        Me.dgRelParentItem.AllowUserToAddRows = False
        Me.dgRelParentItem.AllowUserToDeleteRows = False
        Me.dgRelParentItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.NullValue = """"""
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgRelParentItem.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgRelParentItem.Location = New System.Drawing.Point(277, 255)
        Me.dgRelParentItem.Name = "dgRelParentItem"
        Me.dgRelParentItem.RowHeadersWidth = 30
        Me.dgRelParentItem.RowTemplate.Height = 24
        Me.dgRelParentItem.Size = New System.Drawing.Size(662, 240)
        Me.dgRelParentItem.TabIndex = 405
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.rbBOMASS_BOM)
        Me.GroupBox6.Controls.Add(Me.rbBOMASS_ASS)
        Me.GroupBox6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(128, 0)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(212, 30)
        Me.GroupBox6.TabIndex = 56
        Me.GroupBox6.TabStop = False
        '
        'rbBOMASS_BOM
        '
        Me.rbBOMASS_BOM.AutoSize = True
        Me.rbBOMASS_BOM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbBOMASS_BOM.Location = New System.Drawing.Point(110, 9)
        Me.rbBOMASS_BOM.Name = "rbBOMASS_BOM"
        Me.rbBOMASS_BOM.Size = New System.Drawing.Size(48, 18)
        Me.rbBOMASS_BOM.TabIndex = 402
        Me.rbBOMASS_BOM.Text = "BOM"
        Me.rbBOMASS_BOM.UseVisualStyleBackColor = True
        '
        'rbBOMASS_ASS
        '
        Me.rbBOMASS_ASS.AutoSize = True
        Me.rbBOMASS_ASS.Checked = True
        Me.rbBOMASS_ASS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbBOMASS_ASS.Location = New System.Drawing.Point(6, 9)
        Me.rbBOMASS_ASS.Name = "rbBOMASS_ASS"
        Me.rbBOMASS_ASS.Size = New System.Drawing.Size(81, 18)
        Me.rbBOMASS_ASS.TabIndex = 401
        Me.rbBOMASS_ASS.TabStop = True
        Me.rbBOMASS_ASS.Text = "Assortment"
        Me.rbBOMASS_ASS.UseVisualStyleBackColor = True
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(4, 183)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(0, 14)
        Me.Label40.TabIndex = 19
        '
        'dgBOMASS
        '
        Me.dgBOMASS.AllowUserToAddRows = False
        Me.dgBOMASS.AllowUserToDeleteRows = False
        Me.dgBOMASS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.NullValue = """"""
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgBOMASS.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgBOMASS.Location = New System.Drawing.Point(6, 33)
        Me.dgBOMASS.Name = "dgBOMASS"
        Me.dgBOMASS.RowHeadersWidth = 30
        Me.dgBOMASS.RowTemplate.Height = 24
        Me.dgBOMASS.Size = New System.Drawing.Size(933, 202)
        Me.dgBOMASS.TabIndex = 403
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.PanelCostPrice)
        Me.TabPage5.Controls.Add(Me.lblPriceStatus)
        Me.TabPage5.Controls.Add(Me.gbPriceStatus)
        Me.TabPage5.Controls.Add(Me.lblPricing)
        Me.TabPage5.Controls.Add(Me.Label89)
        Me.TabPage5.Controls.Add(Me.txtCstRmk)
        Me.TabPage5.Controls.Add(Me.TextBox1)
        Me.TabPage5.Controls.Add(Me.Label45)
        Me.TabPage5.Controls.Add(Me.Label88)
        Me.TabPage5.Controls.Add(Me.txtCstExpDat)
        Me.TabPage5.Controls.Add(Me.Label7)
        Me.TabPage5.Controls.Add(Me.Label44)
        Me.TabPage5.Controls.Add(Me.lblCstRmk)
        Me.TabPage5.Controls.Add(Me.gbPriceView)
        Me.TabPage5.Controls.Add(Me.dgCostPrice)
        Me.TabPage5.Location = New System.Drawing.Point(4, 23)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(942, 498)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "(5) Cost Price"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'PanelCostPrice
        '
        Me.PanelCostPrice.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelCostPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPFtyPrcE)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPMUE)
        Me.PanelCostPrice.Controls.Add(Me.Label100)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPFtyCstE)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPEstPrcRef)
        Me.PanelCostPrice.Controls.Add(Me.Label96)
        Me.PanelCostPrice.Controls.Add(Me.Label95)
        Me.PanelCostPrice.Controls.Add(Me.cboPanCPEstPrcFlg)
        Me.PanelCostPrice.Controls.Add(Me.lblOrgConftr)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPExpDate)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPEffDate)
        Me.PanelCostPrice.Controls.Add(Me.lblOrgTranTerm)
        Me.PanelCostPrice.Controls.Add(Me.lblOrgHKTerm)
        Me.PanelCostPrice.Controls.Add(Me.lblOrgFtyTerm)
        Me.PanelCostPrice.Controls.Add(Me.lblOrgCus2No)
        Me.PanelCostPrice.Controls.Add(Me.lblOrgCus1No)
        Me.PanelCostPrice.Controls.Add(Me.cboPanCPFmlHK)
        Me.PanelCostPrice.Controls.Add(Me.lblPanCPFCurcde4)
        Me.PanelCostPrice.Controls.Add(Me.lblPanCPBCurcde)
        Me.PanelCostPrice.Controls.Add(Me.lblPanCPBCurcde1)
        Me.PanelCostPrice.Controls.Add(Me.lblPanCPBCurcde2)
        Me.PanelCostPrice.Controls.Add(Me.lblPanCPFCurcde3)
        Me.PanelCostPrice.Controls.Add(Me.lblPanCPFCurcde2)
        Me.PanelCostPrice.Controls.Add(Me.Label83)
        Me.PanelCostPrice.Controls.Add(Me.lblPanCPFCurcde)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPNegPrc)
        Me.PanelCostPrice.Controls.Add(Me.Label81)
        Me.PanelCostPrice.Controls.Add(Me.Label78)
        Me.PanelCostPrice.Controls.Add(Me.cboPanCPStatus)
        Me.PanelCostPrice.Controls.Add(Me.Label76)
        Me.PanelCostPrice.Controls.Add(Me.Label77)
        Me.PanelCostPrice.Controls.Add(Me.cboPanCPCus1no)
        Me.PanelCostPrice.Controls.Add(Me.cboPanCPCus2no)
        Me.PanelCostPrice.Controls.Add(Me.Label75)
        Me.PanelCostPrice.Controls.Add(Me.Label74)
        Me.PanelCostPrice.Controls.Add(Me.cboPanCPPrcTrmFty)
        Me.PanelCostPrice.Controls.Add(Me.Label73)
        Me.PanelCostPrice.Controls.Add(Me.cboPanCPPrcTrmHK)
        Me.PanelCostPrice.Controls.Add(Me.cboPanCPTranTrm)
        Me.PanelCostPrice.Controls.Add(Me.Label72)
        Me.PanelCostPrice.Controls.Add(Me.Label53)
        Me.PanelCostPrice.Controls.Add(Me.cmdPanCPInsert)
        Me.PanelCostPrice.Controls.Add(Me.cmdPanCPUpdate)
        Me.PanelCostPrice.Controls.Add(Me.cmdPanCPCancel)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPBasicPrc)
        Me.PanelCostPrice.Controls.Add(Me.Label71)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPBOMPrc)
        Me.PanelCostPrice.Controls.Add(Me.Label70)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPItmPrc)
        Me.PanelCostPrice.Controls.Add(Me.Label69)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPAdjPer)
        Me.PanelCostPrice.Controls.Add(Me.Label68)
        Me.PanelCostPrice.Controls.Add(Me.Label67)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPNegCst)
        Me.PanelCostPrice.Controls.Add(Me.Label66)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPTtlCst)
        Me.PanelCostPrice.Controls.Add(Me.Label65)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPBOMCst)
        Me.PanelCostPrice.Controls.Add(Me.Label64)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPFtyPrcPack)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPFtyPrcTran)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPFtyPrcD)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPFtyPrcC)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPFtyPrcB)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPFtyPrcA)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPFtyPrc)
        Me.PanelCostPrice.Controls.Add(Me.lblPanCPFCurcde1)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPMUPack)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPMUTran)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPMUD)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPMUC)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPMUB)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPMUA)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPMU)
        Me.PanelCostPrice.Controls.Add(Me.Label62)
        Me.PanelCostPrice.Controls.Add(Me.Label61)
        Me.PanelCostPrice.Controls.Add(Me.Label60)
        Me.PanelCostPrice.Controls.Add(Me.Label59)
        Me.PanelCostPrice.Controls.Add(Me.Label58)
        Me.PanelCostPrice.Controls.Add(Me.Label57)
        Me.PanelCostPrice.Controls.Add(Me.Label56)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPFtyCstPack)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPFtyCstTran)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPFtyCstD)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPFtyCstC)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPFtyCstB)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPFtyCstA)
        Me.PanelCostPrice.Controls.Add(Me.txtPanCPFtyCst)
        Me.PanelCostPrice.Controls.Add(Me.Label55)
        Me.PanelCostPrice.Controls.Add(Me.Label54)
        Me.PanelCostPrice.Controls.Add(Me.lblPanCPPacking)
        Me.PanelCostPrice.Controls.Add(Me.Label52)
        Me.PanelCostPrice.Location = New System.Drawing.Point(144, 50)
        Me.PanelCostPrice.Name = "PanelCostPrice"
        Me.PanelCostPrice.Size = New System.Drawing.Size(553, 295)
        Me.PanelCostPrice.TabIndex = 89
        Me.PanelCostPrice.Visible = False
        '
        'txtPanCPFtyPrcE
        '
        Me.txtPanCPFtyPrcE.Location = New System.Drawing.Point(134, 228)
        Me.txtPanCPFtyPrcE.Name = "txtPanCPFtyPrcE"
        Me.txtPanCPFtyPrcE.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPFtyPrcE.TabIndex = 589
        Me.txtPanCPFtyPrcE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPanCPFtyPrcE.Visible = False
        '
        'txtPanCPMUE
        '
        Me.txtPanCPMUE.Location = New System.Drawing.Point(84, 228)
        Me.txtPanCPMUE.Name = "txtPanCPMUE"
        Me.txtPanCPMUE.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPMUE.TabIndex = 582
        Me.txtPanCPMUE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPanCPMUE.Visible = False
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.Location = New System.Drawing.Point(4, 231)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(13, 14)
        Me.Label100.TabIndex = 594
        Me.Label100.Text = "E"
        '
        'txtPanCPFtyCstE
        '
        Me.txtPanCPFtyCstE.Location = New System.Drawing.Point(34, 228)
        Me.txtPanCPFtyCstE.Name = "txtPanCPFtyCstE"
        Me.txtPanCPFtyCstE.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPFtyCstE.TabIndex = 575
        Me.txtPanCPFtyCstE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPanCPEstPrcRef
        '
        Me.txtPanCPEstPrcRef.Location = New System.Drawing.Point(293, 207)
        Me.txtPanCPEstPrcRef.MaxLength = 50
        Me.txtPanCPEstPrcRef.Name = "txtPanCPEstPrcRef"
        Me.txtPanCPEstPrcRef.Size = New System.Drawing.Size(105, 20)
        Me.txtPanCPEstPrcRef.TabIndex = 592
        Me.txtPanCPEstPrcRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label96
        '
        Me.Label96.AutoSize = True
        Me.Label96.Location = New System.Drawing.Point(296, 191)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(83, 14)
        Me.Label96.TabIndex = 593
        Me.Label96.Text = "Est. Prc Ref No."
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.Location = New System.Drawing.Point(296, 145)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(44, 14)
        Me.Label95.TabIndex = 591
        Me.Label95.Text = "Est. Prc"
        '
        'cboPanCPEstPrcFlg
        '
        Me.cboPanCPEstPrcFlg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPanCPEstPrcFlg.FormattingEnabled = True
        Me.cboPanCPEstPrcFlg.Location = New System.Drawing.Point(293, 162)
        Me.cboPanCPEstPrcFlg.Name = "cboPanCPEstPrcFlg"
        Me.cboPanCPEstPrcFlg.Size = New System.Drawing.Size(61, 22)
        Me.cboPanCPEstPrcFlg.TabIndex = 590
        '
        'lblOrgConftr
        '
        Me.lblOrgConftr.AutoSize = True
        Me.lblOrgConftr.Location = New System.Drawing.Point(66, 5)
        Me.lblOrgConftr.Name = "lblOrgConftr"
        Me.lblOrgConftr.Size = New System.Drawing.Size(65, 14)
        Me.lblOrgConftr.TabIndex = 589
        Me.lblOrgConftr.Text = "lblOrgConftr"
        Me.lblOrgConftr.Visible = False
        '
        'txtPanCPExpDate
        '
        Me.txtPanCPExpDate.Location = New System.Drawing.Point(482, 190)
        Me.txtPanCPExpDate.Mask = "00/00/0000"
        Me.txtPanCPExpDate.Name = "txtPanCPExpDate"
        Me.txtPanCPExpDate.Size = New System.Drawing.Size(66, 20)
        Me.txtPanCPExpDate.TabIndex = 567
        '
        'txtPanCPEffDate
        '
        Me.txtPanCPEffDate.Location = New System.Drawing.Point(482, 167)
        Me.txtPanCPEffDate.Mask = "00/00/0000"
        Me.txtPanCPEffDate.Name = "txtPanCPEffDate"
        Me.txtPanCPEffDate.Size = New System.Drawing.Size(65, 20)
        Me.txtPanCPEffDate.TabIndex = 566
        '
        'lblOrgTranTerm
        '
        Me.lblOrgTranTerm.AutoSize = True
        Me.lblOrgTranTerm.Location = New System.Drawing.Point(290, 53)
        Me.lblOrgTranTerm.Name = "lblOrgTranTerm"
        Me.lblOrgTranTerm.Size = New System.Drawing.Size(70, 14)
        Me.lblOrgTranTerm.TabIndex = 581
        Me.lblOrgTranTerm.Text = "OrgTranTerm"
        Me.lblOrgTranTerm.Visible = False
        '
        'lblOrgHKTerm
        '
        Me.lblOrgHKTerm.AutoSize = True
        Me.lblOrgHKTerm.Location = New System.Drawing.Point(221, 53)
        Me.lblOrgHKTerm.Name = "lblOrgHKTerm"
        Me.lblOrgHKTerm.Size = New System.Drawing.Size(62, 14)
        Me.lblOrgHKTerm.TabIndex = 580
        Me.lblOrgHKTerm.Text = "OrgHKTerm"
        Me.lblOrgHKTerm.Visible = False
        '
        'lblOrgFtyTerm
        '
        Me.lblOrgFtyTerm.AutoSize = True
        Me.lblOrgFtyTerm.Location = New System.Drawing.Point(147, 53)
        Me.lblOrgFtyTerm.Name = "lblOrgFtyTerm"
        Me.lblOrgFtyTerm.Size = New System.Drawing.Size(63, 14)
        Me.lblOrgFtyTerm.TabIndex = 579
        Me.lblOrgFtyTerm.Text = "OrgFtyTerm"
        Me.lblOrgFtyTerm.Visible = False
        '
        'lblOrgCus2No
        '
        Me.lblOrgCus2No.AutoSize = True
        Me.lblOrgCus2No.Location = New System.Drawing.Point(78, 53)
        Me.lblOrgCus2No.Name = "lblOrgCus2No"
        Me.lblOrgCus2No.Size = New System.Drawing.Size(63, 14)
        Me.lblOrgCus2No.TabIndex = 578
        Me.lblOrgCus2No.Text = "OrgCus2No"
        Me.lblOrgCus2No.Visible = False
        '
        'lblOrgCus1No
        '
        Me.lblOrgCus1No.AutoSize = True
        Me.lblOrgCus1No.Location = New System.Drawing.Point(6, 53)
        Me.lblOrgCus1No.Name = "lblOrgCus1No"
        Me.lblOrgCus1No.Size = New System.Drawing.Size(63, 14)
        Me.lblOrgCus1No.TabIndex = 577
        Me.lblOrgCus1No.Text = "OrgCus1No"
        Me.lblOrgCus1No.Visible = False
        '
        'cboPanCPFmlHK
        '
        Me.cboPanCPFmlHK.FormattingEnabled = True
        Me.cboPanCPFmlHK.Location = New System.Drawing.Point(284, 110)
        Me.cboPanCPFmlHK.Name = "cboPanCPFmlHK"
        Me.cboPanCPFmlHK.Size = New System.Drawing.Size(114, 22)
        Me.cboPanCPFmlHK.TabIndex = 561
        '
        'lblPanCPFCurcde4
        '
        Me.lblPanCPFCurcde4.AutoSize = True
        Me.lblPanCPFCurcde4.Location = New System.Drawing.Point(235, 147)
        Me.lblPanCPFCurcde4.Name = "lblPanCPFCurcde4"
        Me.lblPanCPFCurcde4.Size = New System.Drawing.Size(36, 14)
        Me.lblPanCPFCurcde4.TabIndex = 575
        Me.lblPanCPFCurcde4.Text = "(HKD)"
        '
        'lblPanCPBCurcde
        '
        Me.lblPanCPBCurcde.AutoSize = True
        Me.lblPanCPBCurcde.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPanCPBCurcde.Location = New System.Drawing.Point(499, 93)
        Me.lblPanCPBCurcde.Name = "lblPanCPBCurcde"
        Me.lblPanCPBCurcde.Size = New System.Drawing.Size(36, 14)
        Me.lblPanCPBCurcde.TabIndex = 574
        Me.lblPanCPBCurcde.Text = "(USD)"
        '
        'lblPanCPBCurcde1
        '
        Me.lblPanCPBCurcde1.AutoSize = True
        Me.lblPanCPBCurcde1.Location = New System.Drawing.Point(450, 93)
        Me.lblPanCPBCurcde1.Name = "lblPanCPBCurcde1"
        Me.lblPanCPBCurcde1.Size = New System.Drawing.Size(36, 14)
        Me.lblPanCPBCurcde1.TabIndex = 573
        Me.lblPanCPBCurcde1.Text = "(USD)"
        '
        'lblPanCPBCurcde2
        '
        Me.lblPanCPBCurcde2.AutoSize = True
        Me.lblPanCPBCurcde2.Location = New System.Drawing.Point(400, 93)
        Me.lblPanCPBCurcde2.Name = "lblPanCPBCurcde2"
        Me.lblPanCPBCurcde2.Size = New System.Drawing.Size(36, 14)
        Me.lblPanCPBCurcde2.TabIndex = 572
        Me.lblPanCPBCurcde2.Text = "(USD)"
        '
        'lblPanCPFCurcde3
        '
        Me.lblPanCPFCurcde3.AutoSize = True
        Me.lblPanCPFCurcde3.Location = New System.Drawing.Point(232, 93)
        Me.lblPanCPFCurcde3.Name = "lblPanCPFCurcde3"
        Me.lblPanCPFCurcde3.Size = New System.Drawing.Size(36, 14)
        Me.lblPanCPFCurcde3.TabIndex = 571
        Me.lblPanCPFCurcde3.Text = "(HKD)"
        '
        'lblPanCPFCurcde2
        '
        Me.lblPanCPFCurcde2.AutoSize = True
        Me.lblPanCPFCurcde2.Location = New System.Drawing.Point(181, 93)
        Me.lblPanCPFCurcde2.Name = "lblPanCPFCurcde2"
        Me.lblPanCPFCurcde2.Size = New System.Drawing.Size(36, 14)
        Me.lblPanCPFCurcde2.TabIndex = 570
        Me.lblPanCPFCurcde2.Text = "(HKD)"
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Location = New System.Drawing.Point(134, 78)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(38, 14)
        Me.Label83.TabIndex = 569
        Me.Label83.Text = "FtyPrc"
        '
        'lblPanCPFCurcde
        '
        Me.lblPanCPFCurcde.AutoSize = True
        Me.lblPanCPFCurcde.Location = New System.Drawing.Point(33, 93)
        Me.lblPanCPFCurcde.Name = "lblPanCPFCurcde"
        Me.lblPanCPFCurcde.Size = New System.Drawing.Size(36, 14)
        Me.lblPanCPFCurcde.TabIndex = 568
        Me.lblPanCPFCurcde.Text = "(HKD)"
        '
        'txtPanCPNegPrc
        '
        Me.txtPanCPNegPrc.Location = New System.Drawing.Point(235, 164)
        Me.txtPanCPNegPrc.Name = "txtPanCPNegPrc"
        Me.txtPanCPNegPrc.ReadOnly = True
        Me.txtPanCPNegPrc.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPNegPrc.TabIndex = 560
        Me.txtPanCPNegPrc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Location = New System.Drawing.Point(235, 133)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(45, 14)
        Me.Label81.TabIndex = 566
        Me.Label81.Text = "Neg Prc"
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Location = New System.Drawing.Point(422, 145)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(38, 14)
        Me.Label78.TabIndex = 143
        Me.Label78.Text = "Status"
        '
        'cboPanCPStatus
        '
        Me.cboPanCPStatus.FormattingEnabled = True
        Me.cboPanCPStatus.Location = New System.Drawing.Point(482, 142)
        Me.cboPanCPStatus.Name = "cboPanCPStatus"
        Me.cboPanCPStatus.Size = New System.Drawing.Size(65, 22)
        Me.cboPanCPStatus.TabIndex = 565
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(177, 8)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(44, 14)
        Me.Label76.TabIndex = 141
        Me.Label76.Text = "Pri Cust"
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Location = New System.Drawing.Point(177, 32)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(51, 14)
        Me.Label77.TabIndex = 140
        Me.Label77.Text = "Sec Cust"
        '
        'cboPanCPCus1no
        '
        Me.cboPanCPCus1no.FormattingEnabled = True
        Me.cboPanCPCus1no.Location = New System.Drawing.Point(234, 5)
        Me.cboPanCPCus1no.Name = "cboPanCPCus1no"
        Me.cboPanCPCus1no.Size = New System.Drawing.Size(185, 22)
        Me.cboPanCPCus1no.TabIndex = 550
        '
        'cboPanCPCus2no
        '
        Me.cboPanCPCus2no.FormattingEnabled = True
        Me.cboPanCPCus2no.Location = New System.Drawing.Point(234, 29)
        Me.cboPanCPCus2no.Name = "cboPanCPCus2no"
        Me.cboPanCPCus2no.Size = New System.Drawing.Size(185, 22)
        Me.cboPanCPCus2no.TabIndex = 551
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(425, 10)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(48, 14)
        Me.Label75.TabIndex = 137
        Me.Label75.Text = "Fty Term"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(425, 32)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(47, 14)
        Me.Label74.TabIndex = 136
        Me.Label74.Text = "HK Term"
        '
        'cboPanCPPrcTrmFty
        '
        Me.cboPanCPPrcTrmFty.FormattingEnabled = True
        Me.cboPanCPPrcTrmFty.Location = New System.Drawing.Point(483, 5)
        Me.cboPanCPPrcTrmFty.Name = "cboPanCPPrcTrmFty"
        Me.cboPanCPPrcTrmFty.Size = New System.Drawing.Size(65, 22)
        Me.cboPanCPPrcTrmFty.TabIndex = 552
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Location = New System.Drawing.Point(423, 56)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(55, 14)
        Me.Label73.TabIndex = 134
        Me.Label73.Text = "Tran Term"
        '
        'cboPanCPPrcTrmHK
        '
        Me.cboPanCPPrcTrmHK.FormattingEnabled = True
        Me.cboPanCPPrcTrmHK.Location = New System.Drawing.Point(483, 29)
        Me.cboPanCPPrcTrmHK.Name = "cboPanCPPrcTrmHK"
        Me.cboPanCPPrcTrmHK.Size = New System.Drawing.Size(65, 22)
        Me.cboPanCPPrcTrmHK.TabIndex = 553
        '
        'cboPanCPTranTrm
        '
        Me.cboPanCPTranTrm.FormattingEnabled = True
        Me.cboPanCPTranTrm.Location = New System.Drawing.Point(483, 53)
        Me.cboPanCPTranTrm.Name = "cboPanCPTranTrm"
        Me.cboPanCPTranTrm.Size = New System.Drawing.Size(64, 22)
        Me.cboPanCPTranTrm.TabIndex = 554
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(422, 193)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(50, 14)
        Me.Label72.TabIndex = 131
        Me.Label72.Text = "Exp Date"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(422, 170)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(46, 14)
        Me.Label53.TabIndex = 130
        Me.Label53.Text = "Eff Date"
        '
        'cmdPanCPInsert
        '
        Me.cmdPanCPInsert.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPanCPInsert.Location = New System.Drawing.Point(398, 268)
        Me.cmdPanCPInsert.Name = "cmdPanCPInsert"
        Me.cmdPanCPInsert.Size = New System.Drawing.Size(49, 21)
        Me.cmdPanCPInsert.TabIndex = 568
        Me.cmdPanCPInsert.Text = "&Insert"
        Me.cmdPanCPInsert.UseVisualStyleBackColor = True
        '
        'cmdPanCPUpdate
        '
        Me.cmdPanCPUpdate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPanCPUpdate.Location = New System.Drawing.Point(449, 268)
        Me.cmdPanCPUpdate.Name = "cmdPanCPUpdate"
        Me.cmdPanCPUpdate.Size = New System.Drawing.Size(49, 21)
        Me.cmdPanCPUpdate.TabIndex = 569
        Me.cmdPanCPUpdate.Text = "&Update"
        Me.cmdPanCPUpdate.UseVisualStyleBackColor = True
        '
        'cmdPanCPCancel
        '
        Me.cmdPanCPCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPanCPCancel.Location = New System.Drawing.Point(501, 268)
        Me.cmdPanCPCancel.Name = "cmdPanCPCancel"
        Me.cmdPanCPCancel.Size = New System.Drawing.Size(48, 22)
        Me.cmdPanCPCancel.TabIndex = 570
        Me.cmdPanCPCancel.Text = "&Quit"
        Me.cmdPanCPCancel.UseVisualStyleBackColor = True
        '
        'txtPanCPBasicPrc
        '
        Me.txtPanCPBasicPrc.Location = New System.Drawing.Point(500, 110)
        Me.txtPanCPBasicPrc.Name = "txtPanCPBasicPrc"
        Me.txtPanCPBasicPrc.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPBasicPrc.TabIndex = 564
        Me.txtPanCPBasicPrc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(494, 78)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(57, 14)
        Me.Label71.TabIndex = 47
        Me.Label71.Text = "Basic Prc"
        '
        'txtPanCPBOMPrc
        '
        Me.txtPanCPBOMPrc.Location = New System.Drawing.Point(450, 110)
        Me.txtPanCPBOMPrc.Name = "txtPanCPBOMPrc"
        Me.txtPanCPBOMPrc.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPBOMPrc.TabIndex = 563
        Me.txtPanCPBOMPrc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(450, 78)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(49, 14)
        Me.Label70.TabIndex = 45
        Me.Label70.Text = "BOM Prc"
        '
        'txtPanCPItmPrc
        '
        Me.txtPanCPItmPrc.Location = New System.Drawing.Point(400, 110)
        Me.txtPanCPItmPrc.Name = "txtPanCPItmPrc"
        Me.txtPanCPItmPrc.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPItmPrc.TabIndex = 562
        Me.txtPanCPItmPrc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(400, 78)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(39, 14)
        Me.Label69.TabIndex = 43
        Me.Label69.Text = "Itm Prc"
        '
        'txtPanCPAdjPer
        '
        Me.txtPanCPAdjPer.Location = New System.Drawing.Point(241, 228)
        Me.txtPanCPAdjPer.Name = "txtPanCPAdjPer"
        Me.txtPanCPAdjPer.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPAdjPer.TabIndex = 561
        Me.txtPanCPAdjPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPanCPAdjPer.Visible = False
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(246, 211)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(36, 14)
        Me.Label68.TabIndex = 41
        Me.Label68.Text = "Adj %"
        Me.Label68.Visible = False
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(286, 93)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(45, 14)
        Me.Label67.TabIndex = 39
        Me.Label67.Text = "Formula"
        '
        'txtPanCPNegCst
        '
        Me.txtPanCPNegCst.Location = New System.Drawing.Point(191, 228)
        Me.txtPanCPNegCst.Name = "txtPanCPNegCst"
        Me.txtPanCPNegCst.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPNegCst.TabIndex = 560
        Me.txtPanCPNegCst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPanCPNegCst.Visible = False
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(191, 213)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(45, 14)
        Me.Label66.TabIndex = 37
        Me.Label66.Text = "Neg Cst"
        Me.Label66.Visible = False
        '
        'txtPanCPTtlCst
        '
        Me.txtPanCPTtlCst.Location = New System.Drawing.Point(234, 110)
        Me.txtPanCPTtlCst.Name = "txtPanCPTtlCst"
        Me.txtPanCPTtlCst.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPTtlCst.TabIndex = 559
        Me.txtPanCPTtlCst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(232, 78)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(37, 14)
        Me.Label65.TabIndex = 35
        Me.Label65.Text = "Ttl Cst"
        '
        'txtPanCPBOMCst
        '
        Me.txtPanCPBOMCst.Location = New System.Drawing.Point(184, 110)
        Me.txtPanCPBOMCst.Name = "txtPanCPBOMCst"
        Me.txtPanCPBOMCst.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPBOMCst.TabIndex = 558
        Me.txtPanCPBOMCst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(181, 78)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(49, 14)
        Me.Label64.TabIndex = 33
        Me.Label64.Text = "BOM Cst"
        '
        'txtPanCPFtyPrcPack
        '
        Me.txtPanCPFtyPrcPack.Location = New System.Drawing.Point(134, 270)
        Me.txtPanCPFtyPrcPack.Name = "txtPanCPFtyPrcPack"
        Me.txtPanCPFtyPrcPack.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPFtyPrcPack.TabIndex = 591
        Me.txtPanCPFtyPrcPack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPanCPFtyPrcPack.Visible = False
        '
        'txtPanCPFtyPrcTran
        '
        Me.txtPanCPFtyPrcTran.Location = New System.Drawing.Point(134, 249)
        Me.txtPanCPFtyPrcTran.Name = "txtPanCPFtyPrcTran"
        Me.txtPanCPFtyPrcTran.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPFtyPrcTran.TabIndex = 590
        Me.txtPanCPFtyPrcTran.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPanCPFtyPrcTran.Visible = False
        '
        'txtPanCPFtyPrcD
        '
        Me.txtPanCPFtyPrcD.Location = New System.Drawing.Point(134, 207)
        Me.txtPanCPFtyPrcD.Name = "txtPanCPFtyPrcD"
        Me.txtPanCPFtyPrcD.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPFtyPrcD.TabIndex = 588
        Me.txtPanCPFtyPrcD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPanCPFtyPrcD.Visible = False
        '
        'txtPanCPFtyPrcC
        '
        Me.txtPanCPFtyPrcC.Location = New System.Drawing.Point(134, 186)
        Me.txtPanCPFtyPrcC.Name = "txtPanCPFtyPrcC"
        Me.txtPanCPFtyPrcC.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPFtyPrcC.TabIndex = 587
        Me.txtPanCPFtyPrcC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPanCPFtyPrcC.Visible = False
        '
        'txtPanCPFtyPrcB
        '
        Me.txtPanCPFtyPrcB.Location = New System.Drawing.Point(134, 165)
        Me.txtPanCPFtyPrcB.Name = "txtPanCPFtyPrcB"
        Me.txtPanCPFtyPrcB.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPFtyPrcB.TabIndex = 586
        Me.txtPanCPFtyPrcB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPanCPFtyPrcB.Visible = False
        '
        'txtPanCPFtyPrcA
        '
        Me.txtPanCPFtyPrcA.Location = New System.Drawing.Point(134, 144)
        Me.txtPanCPFtyPrcA.Name = "txtPanCPFtyPrcA"
        Me.txtPanCPFtyPrcA.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPFtyPrcA.TabIndex = 585
        Me.txtPanCPFtyPrcA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPanCPFtyPrcA.Visible = False
        '
        'txtPanCPFtyPrc
        '
        Me.txtPanCPFtyPrc.Location = New System.Drawing.Point(134, 110)
        Me.txtPanCPFtyPrc.Name = "txtPanCPFtyPrc"
        Me.txtPanCPFtyPrc.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPFtyPrc.TabIndex = 557
        Me.txtPanCPFtyPrc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPanCPFCurcde1
        '
        Me.lblPanCPFCurcde1.AutoSize = True
        Me.lblPanCPFCurcde1.Location = New System.Drawing.Point(134, 93)
        Me.lblPanCPFCurcde1.Name = "lblPanCPFCurcde1"
        Me.lblPanCPFCurcde1.Size = New System.Drawing.Size(36, 14)
        Me.lblPanCPFCurcde1.TabIndex = 25
        Me.lblPanCPFCurcde1.Text = "(HKD)"
        '
        'txtPanCPMUPack
        '
        Me.txtPanCPMUPack.Location = New System.Drawing.Point(84, 270)
        Me.txtPanCPMUPack.Name = "txtPanCPMUPack"
        Me.txtPanCPMUPack.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPMUPack.TabIndex = 584
        Me.txtPanCPMUPack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPanCPMUPack.Visible = False
        '
        'txtPanCPMUTran
        '
        Me.txtPanCPMUTran.Location = New System.Drawing.Point(84, 249)
        Me.txtPanCPMUTran.Name = "txtPanCPMUTran"
        Me.txtPanCPMUTran.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPMUTran.TabIndex = 583
        Me.txtPanCPMUTran.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPanCPMUTran.Visible = False
        '
        'txtPanCPMUD
        '
        Me.txtPanCPMUD.Location = New System.Drawing.Point(84, 207)
        Me.txtPanCPMUD.Name = "txtPanCPMUD"
        Me.txtPanCPMUD.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPMUD.TabIndex = 581
        Me.txtPanCPMUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPanCPMUD.Visible = False
        '
        'txtPanCPMUC
        '
        Me.txtPanCPMUC.Location = New System.Drawing.Point(84, 186)
        Me.txtPanCPMUC.Name = "txtPanCPMUC"
        Me.txtPanCPMUC.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPMUC.TabIndex = 580
        Me.txtPanCPMUC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPanCPMUC.Visible = False
        '
        'txtPanCPMUB
        '
        Me.txtPanCPMUB.Location = New System.Drawing.Point(84, 165)
        Me.txtPanCPMUB.Name = "txtPanCPMUB"
        Me.txtPanCPMUB.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPMUB.TabIndex = 579
        Me.txtPanCPMUB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPanCPMUB.Visible = False
        '
        'txtPanCPMUA
        '
        Me.txtPanCPMUA.Location = New System.Drawing.Point(84, 144)
        Me.txtPanCPMUA.Name = "txtPanCPMUA"
        Me.txtPanCPMUA.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPMUA.TabIndex = 578
        Me.txtPanCPMUA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPanCPMUA.Visible = False
        '
        'txtPanCPMU
        '
        Me.txtPanCPMU.Location = New System.Drawing.Point(84, 110)
        Me.txtPanCPMU.Name = "txtPanCPMU"
        Me.txtPanCPMU.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPMU.TabIndex = 556
        Me.txtPanCPMU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(84, 93)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(35, 14)
        Me.Label62.TabIndex = 17
        Me.Label62.Text = "MU %"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(4, 273)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(30, 14)
        Me.Label61.TabIndex = 16
        Me.Label61.Text = "Pack"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(4, 252)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(29, 14)
        Me.Label60.TabIndex = 15
        Me.Label60.Text = "Tran"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(4, 210)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(14, 14)
        Me.Label59.TabIndex = 14
        Me.Label59.Text = "D"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(4, 189)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(14, 14)
        Me.Label58.TabIndex = 13
        Me.Label58.Text = "C"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(4, 168)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(14, 14)
        Me.Label57.TabIndex = 12
        Me.Label57.Text = "B"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(4, 147)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(15, 14)
        Me.Label56.TabIndex = 11
        Me.Label56.Text = "A"
        '
        'txtPanCPFtyCstPack
        '
        Me.txtPanCPFtyCstPack.Location = New System.Drawing.Point(34, 270)
        Me.txtPanCPFtyCstPack.Name = "txtPanCPFtyCstPack"
        Me.txtPanCPFtyCstPack.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPFtyCstPack.TabIndex = 577
        Me.txtPanCPFtyCstPack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPanCPFtyCstTran
        '
        Me.txtPanCPFtyCstTran.Location = New System.Drawing.Point(34, 249)
        Me.txtPanCPFtyCstTran.Name = "txtPanCPFtyCstTran"
        Me.txtPanCPFtyCstTran.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPFtyCstTran.TabIndex = 576
        Me.txtPanCPFtyCstTran.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPanCPFtyCstD
        '
        Me.txtPanCPFtyCstD.Location = New System.Drawing.Point(34, 207)
        Me.txtPanCPFtyCstD.Name = "txtPanCPFtyCstD"
        Me.txtPanCPFtyCstD.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPFtyCstD.TabIndex = 574
        Me.txtPanCPFtyCstD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPanCPFtyCstC
        '
        Me.txtPanCPFtyCstC.Location = New System.Drawing.Point(34, 186)
        Me.txtPanCPFtyCstC.Name = "txtPanCPFtyCstC"
        Me.txtPanCPFtyCstC.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPFtyCstC.TabIndex = 573
        Me.txtPanCPFtyCstC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPanCPFtyCstB
        '
        Me.txtPanCPFtyCstB.Location = New System.Drawing.Point(34, 165)
        Me.txtPanCPFtyCstB.Name = "txtPanCPFtyCstB"
        Me.txtPanCPFtyCstB.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPFtyCstB.TabIndex = 572
        Me.txtPanCPFtyCstB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPanCPFtyCstA
        '
        Me.txtPanCPFtyCstA.Location = New System.Drawing.Point(34, 144)
        Me.txtPanCPFtyCstA.Name = "txtPanCPFtyCstA"
        Me.txtPanCPFtyCstA.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPFtyCstA.TabIndex = 571
        Me.txtPanCPFtyCstA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPanCPFtyCst
        '
        Me.txtPanCPFtyCst.Location = New System.Drawing.Point(34, 110)
        Me.txtPanCPFtyCst.Name = "txtPanCPFtyCst"
        Me.txtPanCPFtyCst.Size = New System.Drawing.Size(49, 20)
        Me.txtPanCPFtyCst.TabIndex = 555
        Me.txtPanCPFtyCst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(4, 113)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(18, 14)
        Me.Label55.TabIndex = 3
        Me.Label55.Text = "Ttl"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(33, 78)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(38, 14)
        Me.Label54.TabIndex = 2
        Me.Label54.Text = "FtyCst"
        '
        'lblPanCPPacking
        '
        Me.lblPanCPPacking.AutoSize = True
        Me.lblPanCPPacking.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPanCPPacking.Location = New System.Drawing.Point(4, 25)
        Me.lblPanCPPacking.Name = "lblPanCPPacking"
        Me.lblPanCPPacking.Size = New System.Drawing.Size(116, 14)
        Me.lblPanCPPacking.TabIndex = 1
        Me.lblPanCPPacking.Text = "A / A / PC / 0 / 1 / 1.22"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(4, 5)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(56, 14)
        Me.Label52.TabIndex = 0
        Me.Label52.Text = "Packing :"
        '
        'lblPriceStatus
        '
        Me.lblPriceStatus.AutoSize = True
        Me.lblPriceStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPriceStatus.Location = New System.Drawing.Point(654, 13)
        Me.lblPriceStatus.Name = "lblPriceStatus"
        Me.lblPriceStatus.Size = New System.Drawing.Size(73, 14)
        Me.lblPriceStatus.TabIndex = 88
        Me.lblPriceStatus.Text = "Pricing Status"
        '
        'gbPriceStatus
        '
        Me.gbPriceStatus.Controls.Add(Me.rbPriceStatus_NA)
        Me.gbPriceStatus.Controls.Add(Me.rbPriceStatus_INA)
        Me.gbPriceStatus.Controls.Add(Me.rbPriceStatus_ACT)
        Me.gbPriceStatus.Controls.Add(Me.rbPriceStatus_All)
        Me.gbPriceStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPriceStatus.Location = New System.Drawing.Point(733, 0)
        Me.gbPriceStatus.Name = "gbPriceStatus"
        Me.gbPriceStatus.Size = New System.Drawing.Size(196, 35)
        Me.gbPriceStatus.TabIndex = 87
        Me.gbPriceStatus.TabStop = False
        '
        'rbPriceStatus_NA
        '
        Me.rbPriceStatus_NA.AutoSize = True
        Me.rbPriceStatus_NA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPriceStatus_NA.Location = New System.Drawing.Point(148, 11)
        Me.rbPriceStatus_NA.Name = "rbPriceStatus_NA"
        Me.rbPriceStatus_NA.Size = New System.Drawing.Size(45, 18)
        Me.rbPriceStatus_NA.TabIndex = 507
        Me.rbPriceStatus_NA.Text = "TBC"
        Me.rbPriceStatus_NA.UseVisualStyleBackColor = True
        '
        'rbPriceStatus_INA
        '
        Me.rbPriceStatus_INA.AutoSize = True
        Me.rbPriceStatus_INA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPriceStatus_INA.Location = New System.Drawing.Point(101, 11)
        Me.rbPriceStatus_INA.Name = "rbPriceStatus_INA"
        Me.rbPriceStatus_INA.Size = New System.Drawing.Size(42, 18)
        Me.rbPriceStatus_INA.TabIndex = 506
        Me.rbPriceStatus_INA.Text = "INA"
        Me.rbPriceStatus_INA.UseVisualStyleBackColor = True
        '
        'rbPriceStatus_ACT
        '
        Me.rbPriceStatus_ACT.AutoSize = True
        Me.rbPriceStatus_ACT.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPriceStatus_ACT.Location = New System.Drawing.Point(49, 11)
        Me.rbPriceStatus_ACT.Name = "rbPriceStatus_ACT"
        Me.rbPriceStatus_ACT.Size = New System.Drawing.Size(46, 18)
        Me.rbPriceStatus_ACT.TabIndex = 505
        Me.rbPriceStatus_ACT.Text = "ACT"
        Me.rbPriceStatus_ACT.UseVisualStyleBackColor = True
        '
        'rbPriceStatus_All
        '
        Me.rbPriceStatus_All.AutoSize = True
        Me.rbPriceStatus_All.Checked = True
        Me.rbPriceStatus_All.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPriceStatus_All.Location = New System.Drawing.Point(6, 11)
        Me.rbPriceStatus_All.Name = "rbPriceStatus_All"
        Me.rbPriceStatus_All.Size = New System.Drawing.Size(37, 18)
        Me.rbPriceStatus_All.TabIndex = 504
        Me.rbPriceStatus_All.TabStop = True
        Me.rbPriceStatus_All.Text = "All"
        Me.rbPriceStatus_All.UseVisualStyleBackColor = True
        '
        'lblPricing
        '
        Me.lblPricing.AutoSize = True
        Me.lblPricing.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPricing.Location = New System.Drawing.Point(6, 13)
        Me.lblPricing.Name = "lblPricing"
        Me.lblPricing.Size = New System.Drawing.Size(61, 14)
        Me.lblPricing.TabIndex = 86
        Me.lblPricing.Text = "Item Pricing"
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label89.Location = New System.Drawing.Point(846, 452)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(83, 14)
        Me.Label89.TabIndex = 84
        Me.Label89.Text = "(MM/DD/YYYY)"
        Me.Label89.Visible = False
        '
        'txtCstRmk
        '
        Me.txtCstRmk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCstRmk.Location = New System.Drawing.Point(80, 409)
        Me.txtCstRmk.MaxLength = 2000
        Me.txtCstRmk.Name = "txtCstRmk"
        Me.txtCstRmk.Size = New System.Drawing.Size(756, 82)
        Me.txtCstRmk.TabIndex = 509
        Me.txtCstRmk.Text = ""
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(845, 429)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(68, 20)
        Me.TextBox1.TabIndex = 83
        Me.TextBox1.Text = "__/__/____"
        Me.TextBox1.Visible = False
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(846, 452)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(83, 14)
        Me.Label45.TabIndex = 84
        Me.Label45.Text = "(MM/DD/YYYY)"
        Me.Label45.Visible = False
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label88.Location = New System.Drawing.Point(842, 409)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(93, 14)
        Me.Label88.TabIndex = 82
        Me.Label88.Text = "Cost Expiry Date :"
        Me.Label88.Visible = False
        '
        'txtCstExpDat
        '
        Me.txtCstExpDat.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCstExpDat.Location = New System.Drawing.Point(845, 429)
        Me.txtCstExpDat.Name = "txtCstExpDat"
        Me.txtCstExpDat.Size = New System.Drawing.Size(68, 20)
        Me.txtCstExpDat.TabIndex = 83
        Me.txtCstExpDat.Text = "__/__/____"
        Me.txtCstExpDat.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(2, 414)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 14)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "Cost Remarks :"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(842, 409)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(93, 14)
        Me.Label44.TabIndex = 82
        Me.Label44.Text = "Cost Expiry Date :"
        Me.Label44.Visible = False
        '
        'lblCstRmk
        '
        Me.lblCstRmk.AutoSize = True
        Me.lblCstRmk.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCstRmk.Location = New System.Drawing.Point(0, 414)
        Me.lblCstRmk.Name = "lblCstRmk"
        Me.lblCstRmk.Size = New System.Drawing.Size(80, 14)
        Me.lblCstRmk.TabIndex = 81
        Me.lblCstRmk.Text = "Cost Remarks :"
        '
        'gbPriceView
        '
        Me.gbPriceView.Controls.Add(Me.rbPriceView_P)
        Me.gbPriceView.Controls.Add(Me.rbPriceView_F)
        Me.gbPriceView.Controls.Add(Me.rbPriceView_S)
        Me.gbPriceView.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPriceView.Location = New System.Drawing.Point(96, 0)
        Me.gbPriceView.Name = "gbPriceView"
        Me.gbPriceView.Size = New System.Drawing.Size(213, 35)
        Me.gbPriceView.TabIndex = 57
        Me.gbPriceView.TabStop = False
        '
        'rbPriceView_P
        '
        Me.rbPriceView_P.AutoSize = True
        Me.rbPriceView_P.Checked = True
        Me.rbPriceView_P.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPriceView_P.Location = New System.Drawing.Point(128, 11)
        Me.rbPriceView_P.Name = "rbPriceView_P"
        Me.rbPriceView_P.Size = New System.Drawing.Size(74, 18)
        Me.rbPriceView_P.TabIndex = 503
        Me.rbPriceView_P.TabStop = True
        Me.rbPriceView_P.Text = "Price Only"
        Me.rbPriceView_P.UseVisualStyleBackColor = True
        '
        'rbPriceView_F
        '
        Me.rbPriceView_F.AutoSize = True
        Me.rbPriceView_F.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPriceView_F.Location = New System.Drawing.Point(81, 11)
        Me.rbPriceView_F.Name = "rbPriceView_F"
        Me.rbPriceView_F.Size = New System.Drawing.Size(41, 18)
        Me.rbPriceView_F.TabIndex = 502
        Me.rbPriceView_F.Text = "Full"
        Me.rbPriceView_F.UseVisualStyleBackColor = True
        '
        'rbPriceView_S
        '
        Me.rbPriceView_S.AutoSize = True
        Me.rbPriceView_S.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPriceView_S.Location = New System.Drawing.Point(6, 11)
        Me.rbPriceView_S.Name = "rbPriceView_S"
        Me.rbPriceView_S.Size = New System.Drawing.Size(69, 18)
        Me.rbPriceView_S.TabIndex = 501
        Me.rbPriceView_S.Text = "Standard"
        Me.rbPriceView_S.UseVisualStyleBackColor = True
        '
        'dgCostPrice
        '
        Me.dgCostPrice.AllowUserToAddRows = False
        Me.dgCostPrice.AllowUserToDeleteRows = False
        Me.dgCostPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.NullValue = """"""
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCostPrice.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgCostPrice.Location = New System.Drawing.Point(3, 41)
        Me.dgCostPrice.Name = "dgCostPrice"
        Me.dgCostPrice.RowHeadersWidth = 30
        Me.dgCostPrice.RowTemplate.Height = 24
        Me.dgCostPrice.Size = New System.Drawing.Size(932, 362)
        Me.dgCostPrice.TabIndex = 508
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.PanelMOQMOA)
        Me.TabPage6.Controls.Add(Me.dgTempItem)
        Me.TabPage6.Controls.Add(Me.Label84)
        Me.TabPage6.Controls.Add(Me.txtHstuEURDuty)
        Me.TabPage6.Controls.Add(Me.txtHstuUSADuty)
        Me.TabPage6.Controls.Add(Me.Label5)
        Me.TabPage6.Controls.Add(Me.Label4)
        Me.TabPage6.Controls.Add(Me.Label3)
        Me.TabPage6.Controls.Add(Me.Label2)
        Me.TabPage6.Controls.Add(Me.cboHstuUSA)
        Me.TabPage6.Controls.Add(Me.cboHstuEur)
        Me.TabPage6.Controls.Add(Me.cboConstrMethod)
        Me.TabPage6.Controls.Add(Me.Label1)
        Me.TabPage6.Controls.Add(Me.txtAlsitmcol)
        Me.TabPage6.Controls.Add(Me.Label14)
        Me.TabPage6.Controls.Add(Me.txtAlsitmno)
        Me.TabPage6.Controls.Add(Me.gbAddreq)
        Me.TabPage6.Controls.Add(Me.gbMOQMOA)
        Me.TabPage6.Controls.Add(Me.lblCusStyle)
        Me.TabPage6.Controls.Add(Me.dgCusStyle)
        Me.TabPage6.Controls.Add(Me.lblExclCustomer)
        Me.TabPage6.Controls.Add(Me.dgExclCustomer)
        Me.TabPage6.Controls.Add(Me.lblMatBreakdown)
        Me.TabPage6.Controls.Add(Me.dgMatBreakdown)
        Me.TabPage6.Location = New System.Drawing.Point(4, 23)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(942, 498)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "(6) Additional Info"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'PanelMOQMOA
        '
        Me.PanelMOQMOA.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelMOQMOA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelMOQMOA.Controls.Add(Me.cmdPanMMInsert)
        Me.PanelMOQMOA.Controls.Add(Me.cmdPanMMUpdate)
        Me.PanelMOQMOA.Controls.Add(Me.cmdPanMMCancel)
        Me.PanelMOQMOA.Controls.Add(Me.cboPanMMMOQMOA)
        Me.PanelMOQMOA.Controls.Add(Me.txtPanMMMOA)
        Me.PanelMOQMOA.Controls.Add(Me.txtPanMMMOQQty)
        Me.PanelMOQMOA.Controls.Add(Me.cboPanMMMOACur)
        Me.PanelMOQMOA.Controls.Add(Me.Label92)
        Me.PanelMOQMOA.Controls.Add(Me.cboPanMMMOQUM)
        Me.PanelMOQMOA.Controls.Add(Me.Label93)
        Me.PanelMOQMOA.Controls.Add(Me.rbPanMMTirtyp_Company)
        Me.PanelMOQMOA.Controls.Add(Me.rbPanMMTirtyp_Standard)
        Me.PanelMOQMOA.Controls.Add(Me.cboPanMMCus1no)
        Me.PanelMOQMOA.Controls.Add(Me.cboPanMMCus2no)
        Me.PanelMOQMOA.Controls.Add(Me.Label91)
        Me.PanelMOQMOA.Controls.Add(Me.Label90)
        Me.PanelMOQMOA.Location = New System.Drawing.Point(463, 45)
        Me.PanelMOQMOA.Name = "PanelMOQMOA"
        Me.PanelMOQMOA.Size = New System.Drawing.Size(409, 162)
        Me.PanelMOQMOA.TabIndex = 623
        Me.PanelMOQMOA.Visible = False
        '
        'cmdPanMMInsert
        '
        Me.cmdPanMMInsert.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPanMMInsert.Location = New System.Drawing.Point(248, 130)
        Me.cmdPanMMInsert.Name = "cmdPanMMInsert"
        Me.cmdPanMMInsert.Size = New System.Drawing.Size(49, 21)
        Me.cmdPanMMInsert.TabIndex = 618
        Me.cmdPanMMInsert.Text = "&Insert"
        Me.cmdPanMMInsert.UseVisualStyleBackColor = True
        '
        'cmdPanMMUpdate
        '
        Me.cmdPanMMUpdate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPanMMUpdate.Location = New System.Drawing.Point(299, 130)
        Me.cmdPanMMUpdate.Name = "cmdPanMMUpdate"
        Me.cmdPanMMUpdate.Size = New System.Drawing.Size(49, 21)
        Me.cmdPanMMUpdate.TabIndex = 619
        Me.cmdPanMMUpdate.Text = "&Update"
        Me.cmdPanMMUpdate.UseVisualStyleBackColor = True
        '
        'cmdPanMMCancel
        '
        Me.cmdPanMMCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPanMMCancel.Location = New System.Drawing.Point(351, 130)
        Me.cmdPanMMCancel.Name = "cmdPanMMCancel"
        Me.cmdPanMMCancel.Size = New System.Drawing.Size(48, 22)
        Me.cmdPanMMCancel.TabIndex = 620
        Me.cmdPanMMCancel.Text = "&Quit"
        Me.cmdPanMMCancel.UseVisualStyleBackColor = True
        '
        'cboPanMMMOQMOA
        '
        Me.cboPanMMMOQMOA.BackColor = System.Drawing.Color.White
        Me.cboPanMMMOQMOA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPanMMMOQMOA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPanMMMOQMOA.ForeColor = System.Drawing.Color.Black
        Me.cboPanMMMOQMOA.FormattingEnabled = True
        Me.cboPanMMMOQMOA.Location = New System.Drawing.Point(20, 71)
        Me.cboPanMMMOQMOA.Name = "cboPanMMMOQMOA"
        Me.cboPanMMMOQMOA.Size = New System.Drawing.Size(69, 22)
        Me.cboPanMMMOQMOA.TabIndex = 617
        '
        'txtPanMMMOA
        '
        Me.txtPanMMMOA.BackColor = System.Drawing.Color.White
        Me.txtPanMMMOA.Enabled = False
        Me.txtPanMMMOA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanMMMOA.ForeColor = System.Drawing.Color.Black
        Me.txtPanMMMOA.Location = New System.Drawing.Point(316, 97)
        Me.txtPanMMMOA.Name = "txtPanMMMOA"
        Me.txtPanMMMOA.Size = New System.Drawing.Size(70, 20)
        Me.txtPanMMMOA.TabIndex = 616
        '
        'txtPanMMMOQQty
        '
        Me.txtPanMMMOQQty.BackColor = System.Drawing.Color.White
        Me.txtPanMMMOQQty.Enabled = False
        Me.txtPanMMMOQQty.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanMMMOQQty.ForeColor = System.Drawing.Color.Black
        Me.txtPanMMMOQQty.Location = New System.Drawing.Point(316, 71)
        Me.txtPanMMMOQQty.Name = "txtPanMMMOQQty"
        Me.txtPanMMMOQQty.Size = New System.Drawing.Size(70, 20)
        Me.txtPanMMMOQQty.TabIndex = 614
        '
        'cboPanMMMOACur
        '
        Me.cboPanMMMOACur.BackColor = System.Drawing.Color.White
        Me.cboPanMMMOACur.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPanMMMOACur.ForeColor = System.Drawing.Color.Black
        Me.cboPanMMMOACur.FormattingEnabled = True
        Me.cboPanMMMOACur.Location = New System.Drawing.Point(232, 97)
        Me.cboPanMMMOACur.Name = "cboPanMMMOACur"
        Me.cboPanMMMOACur.Size = New System.Drawing.Size(71, 22)
        Me.cboPanMMMOACur.TabIndex = 615
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label92.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label92.Location = New System.Drawing.Point(136, 100)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(31, 14)
        Me.Label92.TabIndex = 612
        Me.Label92.Text = "MOA"
        '
        'cboPanMMMOQUM
        '
        Me.cboPanMMMOQUM.BackColor = System.Drawing.Color.White
        Me.cboPanMMMOQUM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPanMMMOQUM.ForeColor = System.Drawing.Color.Black
        Me.cboPanMMMOQUM.FormattingEnabled = True
        Me.cboPanMMMOQUM.Location = New System.Drawing.Point(232, 71)
        Me.cboPanMMMOQUM.Name = "cboPanMMMOQUM"
        Me.cboPanMMMOQUM.Size = New System.Drawing.Size(71, 22)
        Me.cboPanMMMOQUM.TabIndex = 613
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label93.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label93.Location = New System.Drawing.Point(136, 74)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(84, 14)
        Me.Label93.TabIndex = 611
        Me.Label93.Text = "MOQ for Master"
        '
        'rbPanMMTirtyp_Company
        '
        Me.rbPanMMTirtyp_Company.AutoSize = True
        Me.rbPanMMTirtyp_Company.Location = New System.Drawing.Point(276, 35)
        Me.rbPanMMTirtyp_Company.Name = "rbPanMMTirtyp_Company"
        Me.rbPanMMTirtyp_Company.Size = New System.Drawing.Size(110, 18)
        Me.rbPanMMTirtyp_Company.TabIndex = 608
        Me.rbPanMMTirtyp_Company.Text = "Company Defined"
        Me.rbPanMMTirtyp_Company.UseVisualStyleBackColor = True
        '
        'rbPanMMTirtyp_Standard
        '
        Me.rbPanMMTirtyp_Standard.AutoSize = True
        Me.rbPanMMTirtyp_Standard.Checked = True
        Me.rbPanMMTirtyp_Standard.Location = New System.Drawing.Point(276, 14)
        Me.rbPanMMTirtyp_Standard.Name = "rbPanMMTirtyp_Standard"
        Me.rbPanMMTirtyp_Standard.Size = New System.Drawing.Size(90, 18)
        Me.rbPanMMTirtyp_Standard.TabIndex = 607
        Me.rbPanMMTirtyp_Standard.TabStop = True
        Me.rbPanMMTirtyp_Standard.Text = "Standard Tier"
        Me.rbPanMMTirtyp_Standard.UseVisualStyleBackColor = True
        '
        'cboPanMMCus1no
        '
        Me.cboPanMMCus1no.BackColor = System.Drawing.Color.White
        Me.cboPanMMCus1no.ForeColor = System.Drawing.Color.Black
        Me.cboPanMMCus1no.FormattingEnabled = True
        Me.cboPanMMCus1no.Location = New System.Drawing.Point(74, 10)
        Me.cboPanMMCus1no.Name = "cboPanMMCus1no"
        Me.cboPanMMCus1no.Size = New System.Drawing.Size(185, 22)
        Me.cboPanMMCus1no.TabIndex = 552
        '
        'cboPanMMCus2no
        '
        Me.cboPanMMCus2no.BackColor = System.Drawing.Color.White
        Me.cboPanMMCus2no.ForeColor = System.Drawing.Color.Black
        Me.cboPanMMCus2no.FormattingEnabled = True
        Me.cboPanMMCus2no.Location = New System.Drawing.Point(74, 34)
        Me.cboPanMMCus2no.Name = "cboPanMMCus2no"
        Me.cboPanMMCus2no.Size = New System.Drawing.Size(185, 22)
        Me.cboPanMMCus2no.TabIndex = 553
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.Location = New System.Drawing.Point(17, 37)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(51, 14)
        Me.Label91.TabIndex = 1
        Me.Label91.Text = "Sec Cust"
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Location = New System.Drawing.Point(17, 13)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(44, 14)
        Me.Label90.TabIndex = 0
        Me.Label90.Text = "Pri Cust"
        '
        'dgTempItem
        '
        Me.dgTempItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.NullValue = """"""
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTempItem.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgTempItem.Location = New System.Drawing.Point(19, 324)
        Me.dgTempItem.Name = "dgTempItem"
        Me.dgTempItem.RowHeadersWidth = 30
        Me.dgTempItem.RowTemplate.Height = 24
        Me.dgTempItem.Size = New System.Drawing.Size(380, 86)
        Me.dgTempItem.TabIndex = 616
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label84.Location = New System.Drawing.Point(19, 307)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(100, 14)
        Me.Label84.TabIndex = 116
        Me.Label84.Text = "Temp Item Number :"
        '
        'txtHstuEURDuty
        '
        Me.txtHstuEURDuty.BackColor = System.Drawing.Color.White
        Me.txtHstuEURDuty.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHstuEURDuty.ForeColor = System.Drawing.Color.Black
        Me.txtHstuEURDuty.Location = New System.Drawing.Point(815, 458)
        Me.txtHstuEURDuty.Name = "txtHstuEURDuty"
        Me.txtHstuEURDuty.Size = New System.Drawing.Size(89, 20)
        Me.txtHstuEURDuty.TabIndex = 622
        '
        'txtHstuUSADuty
        '
        Me.txtHstuUSADuty.BackColor = System.Drawing.Color.White
        Me.txtHstuUSADuty.Enabled = False
        Me.txtHstuUSADuty.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHstuUSADuty.ForeColor = System.Drawing.Color.Black
        Me.txtHstuUSADuty.Location = New System.Drawing.Point(815, 430)
        Me.txtHstuUSADuty.Name = "txtHstuUSADuty"
        Me.txtHstuUSADuty.Size = New System.Drawing.Size(89, 20)
        Me.txtHstuUSADuty.TabIndex = 620
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(782, 461)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 14)
        Me.Label5.TabIndex = 112
        Me.Label5.Text = "Duty:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(782, 433)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 14)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Duty:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 461)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 14)
        Me.Label3.TabIndex = 110
        Me.Label3.Text = "Tariff # for Europe :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 433)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 14)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "HSTU # for USA :"
        '
        'cboHstuUSA
        '
        Me.cboHstuUSA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHstuUSA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHstuUSA.FormattingEnabled = True
        Me.cboHstuUSA.Location = New System.Drawing.Point(120, 430)
        Me.cboHstuUSA.Name = "cboHstuUSA"
        Me.cboHstuUSA.Size = New System.Drawing.Size(644, 22)
        Me.cboHstuUSA.TabIndex = 619
        '
        'cboHstuEur
        '
        Me.cboHstuEur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHstuEur.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHstuEur.FormattingEnabled = True
        Me.cboHstuEur.Location = New System.Drawing.Point(120, 458)
        Me.cboHstuEur.Name = "cboHstuEur"
        Me.cboHstuEur.Size = New System.Drawing.Size(644, 22)
        Me.cboHstuEur.TabIndex = 621
        '
        'cboConstrMethod
        '
        Me.cboConstrMethod.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboConstrMethod.FormattingEnabled = True
        Me.cboConstrMethod.Location = New System.Drawing.Point(132, 145)
        Me.cboConstrMethod.Name = "cboConstrMethod"
        Me.cboConstrMethod.Size = New System.Drawing.Size(267, 22)
        Me.cboConstrMethod.TabIndex = 602
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 148)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 14)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Construction Method"
        '
        'txtAlsitmcol
        '
        Me.txtAlsitmcol.BackColor = System.Drawing.Color.White
        Me.txtAlsitmcol.Enabled = False
        Me.txtAlsitmcol.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlsitmcol.ForeColor = System.Drawing.Color.Black
        Me.txtAlsitmcol.Location = New System.Drawing.Point(269, 279)
        Me.txtAlsitmcol.Name = "txtAlsitmcol"
        Me.txtAlsitmcol.Size = New System.Drawing.Size(130, 20)
        Me.txtAlsitmcol.TabIndex = 618
        Me.txtAlsitmcol.Text = "N/A"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(16, 282)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(108, 14)
        Me.Label14.TabIndex = 103
        Me.Label14.Text = "Alias Item and Color :"
        '
        'txtAlsitmno
        '
        Me.txtAlsitmno.BackColor = System.Drawing.Color.White
        Me.txtAlsitmno.Enabled = False
        Me.txtAlsitmno.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlsitmno.ForeColor = System.Drawing.Color.Black
        Me.txtAlsitmno.Location = New System.Drawing.Point(143, 279)
        Me.txtAlsitmno.Name = "txtAlsitmno"
        Me.txtAlsitmno.Size = New System.Drawing.Size(120, 20)
        Me.txtAlsitmno.TabIndex = 617
        Me.txtAlsitmno.Text = "01A001A001A01"
        '
        'gbAddreq
        '
        Me.gbAddreq.Controls.Add(Me.cbAddreq_ster)
        Me.gbAddreq.Controls.Add(Me.cbAddreq_ccib)
        Me.gbAddreq.Controls.Add(Me.cbAddreq_formA)
        Me.gbAddreq.Location = New System.Drawing.Point(435, 259)
        Me.gbAddreq.Name = "gbAddreq"
        Me.gbAddreq.Size = New System.Drawing.Size(469, 40)
        Me.gbAddreq.TabIndex = 60
        Me.gbAddreq.TabStop = False
        Me.gbAddreq.Text = "Additional Process Requirement"
        '
        'cbAddreq_ster
        '
        Me.cbAddreq_ster.AutoSize = True
        Me.cbAddreq_ster.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAddreq_ster.Location = New System.Drawing.Point(339, 16)
        Me.cbAddreq_ster.Name = "cbAddreq_ster"
        Me.cbAddreq_ster.Size = New System.Drawing.Size(70, 18)
        Me.cbAddreq_ster.TabIndex = 614
        Me.cbAddreq_ster.Text = "Sterilized"
        Me.cbAddreq_ster.UseVisualStyleBackColor = True
        '
        'cbAddreq_ccib
        '
        Me.cbAddreq_ccib.AutoSize = True
        Me.cbAddreq_ccib.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAddreq_ccib.Location = New System.Drawing.Point(214, 16)
        Me.cbAddreq_ccib.Name = "cbAddreq_ccib"
        Me.cbAddreq_ccib.Size = New System.Drawing.Size(49, 18)
        Me.cbAddreq_ccib.TabIndex = 613
        Me.cbAddreq_ccib.Text = "CCIB"
        Me.cbAddreq_ccib.UseVisualStyleBackColor = True
        '
        'cbAddreq_formA
        '
        Me.cbAddreq_formA.AutoSize = True
        Me.cbAddreq_formA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAddreq_formA.Location = New System.Drawing.Point(71, 16)
        Me.cbAddreq_formA.Name = "cbAddreq_formA"
        Me.cbAddreq_formA.Size = New System.Drawing.Size(60, 18)
        Me.cbAddreq_formA.TabIndex = 612
        Me.cbAddreq_formA.Text = "Form A"
        Me.cbAddreq_formA.UseVisualStyleBackColor = True
        '
        'gbMOQMOA
        '
        Me.gbMOQMOA.Controls.Add(Me.dgMOQMOA)
        Me.gbMOQMOA.Controls.Add(Me.Label6)
        Me.gbMOQMOA.Controls.Add(Me.txtWastage)
        Me.gbMOQMOA.Controls.Add(Me.txtPerMultQty)
        Me.gbMOQMOA.Controls.Add(Me.Label37)
        Me.gbMOQMOA.Controls.Add(Me.txtMOAAmt)
        Me.gbMOQMOA.Controls.Add(Me.txtMOQQty)
        Me.gbMOQMOA.Controls.Add(Me.cboMOACurr)
        Me.gbMOQMOA.Controls.Add(Me.Label36)
        Me.gbMOQMOA.Controls.Add(Me.cboMOQUM)
        Me.gbMOQMOA.Controls.Add(Me.Label35)
        Me.gbMOQMOA.Controls.Add(Me.rbTier_CompDef)
        Me.gbMOQMOA.Controls.Add(Me.rbTier_Standard)
        Me.gbMOQMOA.Location = New System.Drawing.Point(434, 14)
        Me.gbMOQMOA.Name = "gbMOQMOA"
        Me.gbMOQMOA.Size = New System.Drawing.Size(470, 239)
        Me.gbMOQMOA.TabIndex = 604
        Me.gbMOQMOA.TabStop = False
        Me.gbMOQMOA.Text = "MOQ / MOA"
        '
        'dgMOQMOA
        '
        Me.dgMOQMOA.AllowUserToAddRows = False
        Me.dgMOQMOA.AllowUserToDeleteRows = False
        Me.dgMOQMOA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.NullValue = """"""
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMOQMOA.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgMOQMOA.Location = New System.Drawing.Point(13, 101)
        Me.dgMOQMOA.Name = "dgMOQMOA"
        Me.dgMOQMOA.RowHeadersWidth = 30
        Me.dgMOQMOA.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgMOQMOA.RowTemplate.Height = 24
        Me.dgMOQMOA.Size = New System.Drawing.Size(442, 132)
        Me.dgMOQMOA.TabIndex = 613
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label6.Location = New System.Drawing.Point(10, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 14)
        Me.Label6.TabIndex = 88
        Me.Label6.Text = "Wastage"
        '
        'txtWastage
        '
        Me.txtWastage.BackColor = System.Drawing.Color.White
        Me.txtWastage.Enabled = False
        Me.txtWastage.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWastage.ForeColor = System.Drawing.Color.Black
        Me.txtWastage.Location = New System.Drawing.Point(66, 71)
        Me.txtWastage.Name = "txtWastage"
        Me.txtWastage.Size = New System.Drawing.Size(50, 20)
        Me.txtWastage.TabIndex = 87
        '
        'txtPerMultQty
        '
        Me.txtPerMultQty.BackColor = System.Drawing.Color.White
        Me.txtPerMultQty.Enabled = False
        Me.txtPerMultQty.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPerMultQty.ForeColor = System.Drawing.Color.Black
        Me.txtPerMultQty.Location = New System.Drawing.Point(377, 71)
        Me.txtPerMultQty.Name = "txtPerMultQty"
        Me.txtPerMultQty.Size = New System.Drawing.Size(50, 20)
        Me.txtPerMultQty.TabIndex = 611
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label37.Location = New System.Drawing.Point(267, 74)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(81, 14)
        Me.Label37.TabIndex = 84
        Me.Label37.Text = "Per Multiple Qty"
        '
        'txtMOAAmt
        '
        Me.txtMOAAmt.BackColor = System.Drawing.Color.White
        Me.txtMOAAmt.Enabled = False
        Me.txtMOAAmt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOAAmt.ForeColor = System.Drawing.Color.Black
        Me.txtMOAAmt.Location = New System.Drawing.Point(377, 45)
        Me.txtMOAAmt.Name = "txtMOAAmt"
        Me.txtMOAAmt.Size = New System.Drawing.Size(50, 20)
        Me.txtMOAAmt.TabIndex = 610
        '
        'txtMOQQty
        '
        Me.txtMOQQty.BackColor = System.Drawing.Color.White
        Me.txtMOQQty.Enabled = False
        Me.txtMOQQty.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOQQty.ForeColor = System.Drawing.Color.Black
        Me.txtMOQQty.Location = New System.Drawing.Point(377, 19)
        Me.txtMOQQty.Name = "txtMOQQty"
        Me.txtMOQQty.Size = New System.Drawing.Size(50, 20)
        Me.txtMOQQty.TabIndex = 608
        '
        'cboMOACurr
        '
        Me.cboMOACurr.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMOACurr.FormattingEnabled = True
        Me.cboMOACurr.Location = New System.Drawing.Point(284, 45)
        Me.cboMOACurr.Name = "cboMOACurr"
        Me.cboMOACurr.Size = New System.Drawing.Size(60, 22)
        Me.cboMOACurr.TabIndex = 609
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label36.Location = New System.Drawing.Point(180, 48)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(31, 14)
        Me.Label36.TabIndex = 80
        Me.Label36.Text = "MOA"
        '
        'cboMOQUM
        '
        Me.cboMOQUM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMOQUM.FormattingEnabled = True
        Me.cboMOQUM.Location = New System.Drawing.Point(284, 19)
        Me.cboMOQUM.Name = "cboMOQUM"
        Me.cboMOQUM.Size = New System.Drawing.Size(60, 22)
        Me.cboMOQUM.TabIndex = 607
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label35.Location = New System.Drawing.Point(180, 22)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(84, 14)
        Me.Label35.TabIndex = 78
        Me.Label35.Text = "MOQ for Master"
        '
        'rbTier_CompDef
        '
        Me.rbTier_CompDef.AutoSize = True
        Me.rbTier_CompDef.Location = New System.Drawing.Point(13, 44)
        Me.rbTier_CompDef.Name = "rbTier_CompDef"
        Me.rbTier_CompDef.Size = New System.Drawing.Size(110, 18)
        Me.rbTier_CompDef.TabIndex = 606
        Me.rbTier_CompDef.TabStop = True
        Me.rbTier_CompDef.Text = "Company Defined"
        Me.rbTier_CompDef.UseVisualStyleBackColor = True
        '
        'rbTier_Standard
        '
        Me.rbTier_Standard.AutoSize = True
        Me.rbTier_Standard.Location = New System.Drawing.Point(13, 18)
        Me.rbTier_Standard.Name = "rbTier_Standard"
        Me.rbTier_Standard.Size = New System.Drawing.Size(90, 18)
        Me.rbTier_Standard.TabIndex = 605
        Me.rbTier_Standard.TabStop = True
        Me.rbTier_Standard.Text = "Standard Tier"
        Me.rbTier_Standard.UseVisualStyleBackColor = True
        '
        'lblCusStyle
        '
        Me.lblCusStyle.AutoSize = True
        Me.lblCusStyle.BackColor = System.Drawing.Color.Transparent
        Me.lblCusStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCusStyle.Location = New System.Drawing.Point(437, 307)
        Me.lblCusStyle.Name = "lblCusStyle"
        Me.lblCusStyle.Size = New System.Drawing.Size(120, 14)
        Me.lblCusStyle.TabIndex = 58
        Me.lblCusStyle.Text = "Customer Style Number"
        '
        'dgCusStyle
        '
        Me.dgCusStyle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.NullValue = """"""
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCusStyle.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgCusStyle.Location = New System.Drawing.Point(437, 324)
        Me.dgCusStyle.Name = "dgCusStyle"
        Me.dgCusStyle.RowHeadersWidth = 30
        Me.dgCusStyle.RowTemplate.Height = 24
        Me.dgCusStyle.Size = New System.Drawing.Size(467, 86)
        Me.dgCusStyle.TabIndex = 615
        '
        'lblExclCustomer
        '
        Me.lblExclCustomer.AutoSize = True
        Me.lblExclCustomer.BackColor = System.Drawing.Color.Transparent
        Me.lblExclCustomer.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExclCustomer.Location = New System.Drawing.Point(19, 14)
        Me.lblExclCustomer.Name = "lblExclCustomer"
        Me.lblExclCustomer.Size = New System.Drawing.Size(102, 14)
        Me.lblExclCustomer.TabIndex = 56
        Me.lblExclCustomer.Text = "Exclusive Customer"
        '
        'dgExclCustomer
        '
        Me.dgExclCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.NullValue = """"""
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgExclCustomer.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgExclCustomer.Location = New System.Drawing.Point(19, 31)
        Me.dgExclCustomer.Name = "dgExclCustomer"
        Me.dgExclCustomer.RowHeadersWidth = 30
        Me.dgExclCustomer.RowTemplate.Height = 24
        Me.dgExclCustomer.Size = New System.Drawing.Size(380, 91)
        Me.dgExclCustomer.TabIndex = 601
        '
        'lblMatBreakdown
        '
        Me.lblMatBreakdown.AutoSize = True
        Me.lblMatBreakdown.BackColor = System.Drawing.Color.Transparent
        Me.lblMatBreakdown.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatBreakdown.Location = New System.Drawing.Point(17, 131)
        Me.lblMatBreakdown.Name = "lblMatBreakdown"
        Me.lblMatBreakdown.Size = New System.Drawing.Size(103, 14)
        Me.lblMatBreakdown.TabIndex = 54
        Me.lblMatBreakdown.Text = "Material Breakdown"
        '
        'dgMatBreakdown
        '
        Me.dgMatBreakdown.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.NullValue = """"""
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMatBreakdown.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgMatBreakdown.Location = New System.Drawing.Point(19, 173)
        Me.dgMatBreakdown.Name = "dgMatBreakdown"
        Me.dgMatBreakdown.RowHeadersWidth = 30
        Me.dgMatBreakdown.RowTemplate.Height = 24
        Me.dgMatBreakdown.Size = New System.Drawing.Size(380, 95)
        Me.dgMatBreakdown.TabIndex = 603
        '
        'IMM00001
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(944, 621)
        Me.Controls.Add(Me.cmdRelItm)
        Me.Controls.Add(Me.PanelCopy)
        Me.Controls.Add(Me.PanelAdd)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.cmdMapping)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.cboItmTyp)
        Me.Controls.Add(Me.cbTmpItm)
        Me.Controls.Add(Me.gbIMTyp)
        Me.Controls.Add(Me.gbIMStatus)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.TabPageMain)
        Me.Controls.Add(Me.txtItmdsc)
        Me.Controls.Add(Me.lblItmTyp)
        Me.Controls.Add(Me.txtItmNo)
        Me.Controls.Add(Me.lblItmNo)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdLast)
        Me.Controls.Add(Me.cmdPrevious)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdDelRow)
        Me.Controls.Add(Me.cmdFirst)
        Me.Controls.Add(Me.cmdInsRow)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.cbDiscontinue)
        Me.Controls.Add(Me.cmdActivate)
        Me.Controls.Add(Me.txtTmpItmNo)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(960, 660)
        Me.MinimumSize = New System.Drawing.Size(960, 660)
        Me.Name = "IMM00001"
        Me.Text = "IMM00001 - Item Master Maintenance"
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbIMStatus.ResumeLayout(False)
        Me.gbIMStatus.PerformLayout()
        Me.gbIMTyp.ResumeLayout(False)
        Me.gbIMTyp.PerformLayout()
        Me.PanelCopy.ResumeLayout(False)
        Me.PanelCopy.PerformLayout()
        Me.PanelAdd.ResumeLayout(False)
        Me.PanelAdd.PerformLayout()
        Me.TabPageMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.PanelPacking.ResumeLayout(False)
        Me.PanelPacking.PerformLayout()
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgPacking, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.PanelPV.ResumeLayout(False)
        Me.PanelPV.PerformLayout()
        CType(Me.dgPV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.pbImage2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgOEMCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.dgRelParentItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.dgBOMASS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.PanelCostPrice.ResumeLayout(False)
        Me.PanelCostPrice.PerformLayout()
        Me.gbPriceStatus.ResumeLayout(False)
        Me.gbPriceStatus.PerformLayout()
        Me.gbPriceView.ResumeLayout(False)
        Me.gbPriceView.PerformLayout()
        CType(Me.dgCostPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        Me.PanelMOQMOA.ResumeLayout(False)
        Me.PanelMOQMOA.PerformLayout()
        CType(Me.dgTempItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAddreq.ResumeLayout(False)
        Me.gbAddreq.PerformLayout()
        Me.gbMOQMOA.ResumeLayout(False)
        Me.gbMOQMOA.PerformLayout()
        CType(Me.dgMOQMOA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgCusStyle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgExclCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgMatBreakdown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Const imm_status As Integer = 0
    Const imm_itmno As Integer = 1
    Const imm_cus1no As Integer = 2
    Const imm_cus2no As Integer = 3
    Const imm_tirtyp As Integer = 4
    Const imm_moqmoa As Integer = 5
    Const imm_moqunttyp As Integer = 6
    Const imm_moqctn As Integer = 7
    Const imm_curcde As Integer = 8
    Const imm_moa As Integer = 9

    Const tabCostPrice As Integer = 4

    Dim dsNewRow As DataRow

    Dim mode As String

    Dim Recordstatus As Boolean

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Dim Got_Focus_Grid As String

    Dim rs_VNBASINF As New DataSet
    Dim rs_CUBASINF As New DataSet
    Dim rs_CUGRPINF As New DataSet

    Dim rs_SYSETINF As New DataSet
    Dim rs_SYCONFTR As New DataSet
    Dim rs_SYCATCDE_level4 As New DataSet
    Dim rs_SYCATREL As New DataSet
    Dim rs_SYHRMCDE As New DataSet
    Dim rs_SYTIESTR As New DataSet
    Dim rs_SYLNEINF As New DataSet
    Dim rs_IMCALFML_ALL As New DataSet
    Dim rs_IMCALFML As New DataSet
    Dim tmp_calfml_hk As New ComboBox

    Dim rs_SYCUREX As New DataSet

    Dim rs_IMType As New DataSet
    Dim IMType_IM As String
    Dim IMType_PCIM As String


    'For Item Master use
    Dim rs_IMBASINF As New DataSet
    Dim rs_IMCOLINF As New DataSet
    Dim rs_IMVENINF As New DataSet
    Dim rs_IMPCKINF As New DataSet
    Dim rs_IMPRCINF As New DataSet
    Dim rs_IMBOMASS As New DataSet
    Dim rs_IMBOMASS_old As New DataSet
    Dim rs_IMOTHINF As New DataSet
    Dim rs_IMCUSNO As New DataSet
    Dim rs_IMCSTINF As New DataSet
    Dim rs_IMCTYINF As New DataSet 'Exclusive Customer
    Dim rs_IMCUSSTY As New DataSet
    Dim rs_IMMATBKD As New DataSet
    Dim rs_IMTMPREL As New DataSet
    Dim rs_IMMOQMOA As New DataSet
    Dim rs_IMMOQMOA_old As New DataSet
    'decision not to use at 2012-05-24 meeting for IM Book Sale and IM Summary

    Dim rs_IMR00021 As New DataSet
    Dim rs_itmno_generation As New DataSet

    Dim flag_panpack_keypress As Boolean
    Dim flag_dgBOMASS_mouseselect As Boolean
    Dim flag_pancostprice_keypress As Boolean
    Dim flag_dgOEMCustomer_mouseselect As Boolean
    Dim flag_dgExclCustomer_mouseselect As Boolean
    Dim flag_bomqty_keypress As Boolean
    Dim flag_dgPacking_keypress As Boolean
    Dim flag_dgCostPrice_keypress As Boolean

    Dim rs_IMCOLINF_BOMASS As New DataSet
    Dim rs_IMPCKINF_BOMASS As New DataSet
    Dim rs_IMPRCINF_BOMASS As New DataSet

    'For Price Calculation Item Master use
    Dim rs_IMPCBASINF As New DataSet
    Dim rs_IMPCCOLINF As New DataSet
    Dim rs_IMPCVENINF As New DataSet
    Dim rs_IMPCPCKINF As New DataSet
    Dim rs_IMPCPRCINF As New DataSet

#Region " Datagrid Variable "
    'dgBOMASS
    Dim dgBOMASS_iba_status As Integer
    Dim dgBOMASS_iba_cocde As Integer
    Dim dgBOMASS_iba_itmno As Integer
    Dim dgBOMASS_iba_assitm As Integer
    Dim dgBOMASS_iba_altitmno As Integer
    Dim dgBOMASS_iba_typ As Integer
    Dim dgBOMASS_iba_colcde As Integer
    Dim dgBOMASS_ibi_engdsc As Integer
    Dim dgBOMASS_vbi_vensna As Integer
    Dim dgBOMASS_iba_period As Integer
    Dim dgBOMASS_iba_pckunt As Integer
    Dim dgBOMASS_iba_bomqty As Integer
    Dim dgBOMASS_iba_inrqty As Integer
    Dim dgBOMASS_iba_mtrqty As Integer
    Dim dgBOMASS_iba_fcurcde As Integer
    Dim dgBOMASS_iba_ftycst As Integer
    Dim dgBOMASS_imu_ftyprc As Integer
    Dim dgBOMASS_iba_ftyfmlopt As Integer
    Dim dgBOMASS_iba_fmlopt As Integer
    Dim dgBOMASS_iba_bombasprc As Integer
    Dim dgBOMASS_iba_costing As Integer
    Dim dgBOMASS_iba_genpo As Integer
    Dim dgBOMASS_iba_curcde As Integer
    Dim dgBOMASS_iba_untcst As Integer
    Dim dgBOMASS_iba_creusr As Integer
    Dim dgBOMASS_iba_updusr As Integer
    Dim dgBOMASS_iba_credat As Integer
    Dim dgBOMASS_iba_upddat As Integer
    Dim dgBOMASS_iba_timstp As Integer
    Dim dgBOMASS_iba_assftyitm As Integer
    Dim dgBOMASS_iba_orgcolcde As Integer

    'dgCostPrice
    Dim dgCostPrice_imu_cocde As Integer
    Dim dgCostPrice_imu_itmno As Integer
    Dim dgCostPrice_imu_typ As Integer
    Dim dgCostPrice_imu_ventyp As Integer
    Dim dgCostPrice_imu_venno As Integer
    Dim dgCostPrice_imu_prdven As Integer
    Dim dgCostPrice_imu_packing As Integer
    Dim dgCostPrice_imu_pckunt As Integer
    Dim dgCostPrice_imu_conftr As Integer
    Dim dgCostPrice_imu_inrqty As Integer
    Dim dgCostPrice_imu_mtrqty As Integer
    Dim dgCostPrice_imu_cft As Integer
    Dim dgCostPrice_imu_cus1no As Integer
    Dim dgCostPrice_imu_cus2no As Integer
    Dim dgCostPrice_imu_ftyprctrm As Integer
    Dim dgCostPrice_imu_hkprctrm As Integer
    Dim dgCostPrice_imu_trantrm As Integer
    Dim dgCostPrice_imu_effdat As Integer
    Dim dgCostPrice_imu_expdat As Integer
    Dim dgCostPrice_imu_status As Integer
    Dim dgCostPrice_imu_curcde As Integer

    Dim dgCostPrice_imu_ftycstA As Integer
    Dim dgCostPrice_imu_ftycstB As Integer
    Dim dgCostPrice_imu_ftycstC As Integer
    Dim dgCostPrice_imu_ftycstD As Integer
    Dim dgCostPrice_imu_ftycstE As Integer
    Dim dgCostPrice_imu_ftycstTran As Integer
    Dim dgCostPrice_imu_ftycstPack As Integer
    Dim dgCostPrice_imu_ftycst As Integer
    Dim dgCostPrice_imu_fmlA As Integer
    Dim dgCostPrice_imu_fmlB As Integer
    Dim dgCostPrice_imu_fmlC As Integer
    Dim dgCostPrice_imu_fmlD As Integer
    Dim dgCostPrice_imu_fmlE As Integer
    Dim dgCostPrice_imu_fmlTran As Integer
    Dim dgCostPrice_imu_fmlPack As Integer
    Dim dgCostPrice_imu_fml As Integer
    Dim dgCostPrice_imu_chgfpA As Integer
    Dim dgCostPrice_imu_chgfpB As Integer
    Dim dgCostPrice_imu_chgfpC As Integer
    Dim dgCostPrice_imu_chgfpD As Integer
    Dim dgCostPrice_imu_chgfpE As Integer
    Dim dgCostPrice_imu_chgfpTran As Integer
    Dim dgCostPrice_imu_chgfpPack As Integer
    Dim dgCostPrice_imu_chgfp As Integer
    Dim dgCostPrice_imu_ftyprcA As Integer
    Dim dgCostPrice_imu_ftyprcB As Integer
    Dim dgCostPrice_imu_ftyprcC As Integer
    Dim dgCostPrice_imu_ftyprcD As Integer
    Dim dgCostPrice_imu_ftyprcE As Integer
    Dim dgCostPrice_imu_ftyprcTran As Integer
    Dim dgCostPrice_imu_ftyprcPack As Integer
    Dim dgCostPrice_imu_ftyprc As Integer
    Dim dgCostPrice_imu_bomcst As Integer
    Dim dgCostPrice_imu_ttlcst As Integer
    Dim dgCostPrice_imu_hkadjper As Integer
    Dim dgCostPrice_imu_negcst As Integer
    Dim dgCostPrice_imu_negprc As Integer
    Dim dgCostPrice_imu_fmlopt As Integer
    Dim dgCostPrice_imu_bcurcde As Integer
    Dim dgCostPrice_imu_itmprc As Integer
    Dim dgCostPrice_imu_bomprc As Integer
    Dim dgCostPrice_imu_basprc As Integer
    Dim dgCostPrice_imu_sysgen As Integer
    Dim dgCostPrice_imu_estprcflg As Integer
    Dim dgCostPrice_imu_estprcref As Integer
    Dim dgCostPrice_imu_period As Integer
    Dim dgCostPrice_imu_cstchgdat As Integer
    Dim dgCostPrice_imu_pckunt_org As Integer
    Dim dgCostPrice_imu_conftr_org As Integer
    Dim dgCostPrice_imu_inrqty_org As Integer
    Dim dgCostPrice_imu_mtrqty_org As Integer
    Dim dgCostPrice_imu_cft_org As Integer
    Dim dgCostPrice_imu_cus1no_org As Integer
    Dim dgCostPrice_imu_cus2no_org As Integer
    Dim dgCostPrice_imu_ftyprctrm_org As Integer
    Dim dgCostPrice_imu_hkprctrm_org As Integer
    Dim dgCostPrice_imu_trantrm_org As Integer
    Dim dgCostPrice_imu_creusr As Integer
    Dim dgCostPrice_imu_updusr As Integer
    Dim dgCostPrice_imu_credat As Integer
    Dim dgCostPrice_imu_upddat As Integer
    Dim dgCostPrice_imu_timstp As Integer

    'dgExclCustomer
    Dim dgExclCustomer_ici_status As Integer
    Dim dgExclCustomer_ici_cocde As Integer
    Dim dgExclCustomer_ici_itmno As Integer
    Dim dgExclCustomer_ici_ctyseq As Integer
    Dim dgExclCustomer_ici_cusno As Integer
    Dim dgExclCustomer_cbi_cusnam As Integer
    Dim dgExclCustomer_ici_ctycde As Integer
    Dim dgExclCustomer_ici_valdat As Integer
    Dim dgExclCustomer_ici_rmk As Integer
    Dim dgExclCustomer_ici_creusr As Integer
    Dim dgExclCustomer_ici_updusr As Integer
    Dim dgExclCustomer_ici_credat As Integer
    Dim dgExclCustomer_ici_upddat As Integer
    Dim dgExclCustomer_ici_timstp As Integer

    'dgColor
    Dim dgColor_icf_status As Integer
    Dim dgColor_icf_cocde As Integer
    Dim dgColor_icf_itmno As Integer
    Dim dgColor_icf_colcde As Integer
    Dim dgColor_icf_typ As Integer
    Dim dgColor_icf_coldsc As Integer
    Dim dgColor_icf_vencol As Integer
    Dim dgColor_icf_asscol As Integer
    Dim dgColor_icf_lnecde As Integer
    Dim dgColor_icf_ucpcde As Integer
    Dim dgColor_icf_eancde As Integer
    Dim dgColor_icf_swatchpath As Integer
    Dim dgColor_icf_imgpath As Integer
    Dim dgColor_icf_creusr As Integer
    Dim dgColor_icf_updusr As Integer
    Dim dgColor_icf_credat As Integer
    Dim dgColor_icf_upddat As Integer
    Dim dgColor_icf_timstp As Integer
    Dim dgColor_icf_colseq As Integer

    'dgPacking
    Dim dgPacking_ipi_status As Integer
    Dim dgPacking_ipi_relation As Integer
    Dim dgPacking_ipi_cocde As Integer
    Dim dgPacking_ipi_itmno As Integer
    Dim dgPacking_ipi_pckseq As Integer
    Dim dgPacking_ipi_qutdat As Integer
    Dim dgPacking_ipi_pckunt As Integer
    Dim dgPacking_ipi_inrqty As Integer
    Dim dgPacking_ipi_mtrqty As Integer
    Dim dgPacking_ipi_cus1no As Integer
    Dim dgPacking_ipi_cus2no As Integer
    Dim dgPacking_ipi_cft As Integer
    Dim dgPacking_ipi_cbm As Integer
    Dim dgPacking_inner_in As Integer
    Dim dgPacking_master_in As Integer
    Dim dgPacking_inner_cm As Integer
    Dim dgPacking_master_cm As Integer
    Dim dgPacking_ipi_grswgt As Integer
    Dim dgPacking_ipi_netwgt As Integer
    Dim dgPacking_ipi_pckitr As Integer
    Dim dgPacking_ipi_conftr As Integer
    Dim dgPacking_ipi_cusno As Integer
    Dim dgPacking_ipi_cussna As Integer
    Dim dgPacking_ipi_creusr As Integer
    Dim dgPacking_ipi_updusr As Integer
    Dim dgPacking_ipi_credat As Integer
    Dim dgPacking_ipi_upddat As Integer
    Dim dgPacking_ipi_timstp As Integer
    Dim dgPacking_max_seq As Integer
    Dim dgPacking_ipi_inrsze As Integer
    Dim dgPacking_ipi_mtrsze As Integer
    Dim dgPacking_ipi_mat As Integer


#End Region


    Private Sub IMM00001_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If (e.Alt) Then
            If e.KeyCode = Keys.D1 Then
                Me.TabPageMain.SelectedIndex = 0
            ElseIf e.KeyCode = Keys.D2 Then
                Me.TabPageMain.SelectedIndex = 1
            ElseIf e.KeyCode = Keys.D3 Then
                Me.TabPageMain.SelectedIndex = 2
            ElseIf e.KeyCode = Keys.D4 Then
                Me.TabPageMain.SelectedIndex = 3
            ElseIf e.KeyCode = Keys.D5 Then
                Me.TabPageMain.SelectedIndex = 4
            ElseIf e.KeyCode = Keys.D6 Then
                Me.TabPageMain.SelectedIndex = 5
            End If
        End If
    End Sub

    Private Sub IMM00101_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Formstartup(Me.Name)

        Call AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        format_cboItmTyp()
        format_cboStatus()

        gspStr = "sp_list_VNBASINF ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00001_Load sp_list_VNBASINF :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_CUBASINF '','A'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00001_Load sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_CUGRPINF '','A'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUGRPINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00001_Load sp_list_CUGRPINF :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_SYSETINF ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00001_Load sp_list_SYSETINF :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_SYCONFTR "
        rtnLong = execute_SQLStatement(gspStr, rs_SYCONFTR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00001_Load sp_select_SYCONFTR :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_SYCATCDE_level '',4"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCATCDE_level4, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00001_Load sp_select_SYCATCDE_level :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_SYCATREL"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCATREL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00001_Load sp_list_SYCATREL :" & rtnStr)
            Exit Sub
        End If


        gspStr = "sp_select_SYHRMCDE"
        rtnLong = execute_SQLStatement(gspStr, rs_SYHRMCDE, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00001_Load sp_select_SYHRMCDE :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_SYTIESTR_unttyp"
        rtnLong = execute_SQLStatement(gspStr, rs_SYTIESTR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00001_Load sp_list_SYTIESTR_unttyp :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_SYLNEINF"
        rtnLong = execute_SQLStatement(gspStr, rs_SYLNEINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00001_Load sp_list_SYLNEINF :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_IMBASINF '',''"
        rtnLong = execute_SQLStatement(gspStr, rs_IMBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00001_Load sp_select_IMBASINF :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_IMCOLINF '',''"
        rtnLong = execute_SQLStatement(gspStr, rs_IMCOLINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00001_Load sp_select_IMCOLINF :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_IMCALFML '',''"
        rtnLong = execute_SQLStatement(gspStr, rs_IMCALFML_ALL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00001_Load sp_select_IMCALFML :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_SYCUREX '','" & Format(Today.Date, "yyyy-MM-dd") & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCUREX, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00001_Load sp_list_SYCUREX :" & rtnStr)
            Exit Sub
        End If


        'gspStr = "sp_select_IMPCKINF '',''"
        'rtnLong = execute_SQLStatement(gspStr, rs_IMPCKINF, rtnStr)
        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading IMM00001_Load sp_select_IMPCKINF :" & rtnStr)
        '    Exit Sub
        'End If

        'gspStr = "sp_select_IMVENINF '',''"
        'rtnLong = execute_SQLStatement(gspStr, rs_IMVENINF, rtnStr)
        'If rtnLong <> RC_SUCCESS Then  
        '    MsgBox("Error on loading IMM00001_Load sp_select_IMVENINF :" & rtnStr)
        '    Exit Sub
        'End If

        'gspStr = "sp_select_IMCUSNO '',''"
        'rtnLong = execute_SQLStatement(gspStr, rs_IMCUSNO, rtnStr)
        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading IMM00001_Load sp_select_IMCUSNO :" & rtnStr)
        '    Exit Sub
        'End If

        'gspStr = "sp_select_IMPRCINF '',''"
        'rtnLong = execute_SQLStatement(gspStr, rs_IMPRCINF, rtnStr)
        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading IMM00001_Load sp_select_IMPRCINF :" & rtnStr)
        '    Exit Sub
        'End If

        'gspStr = "sp_select_IMCTYINF '',''"
        'rtnLong = execute_SQLStatement(gspStr, rs_IMCTYINF, rtnStr)
        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading IMM00001_Load sp_select_IMCTYINF :" & rtnStr)
        '    Exit Sub
        'End If

        'gspStr = "sp_select_IMCUSSTY '',''"
        'rtnLong = execute_SQLStatement(gspStr, rs_IMCUSSTY, rtnStr)
        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading IMM00001_Load sp_select_IMCUSSTY :" & rtnStr)
        '    Exit Sub
        'End If

        'gspStr = "sp_select_IMMATBKD '',''"
        'rtnLong = execute_SQLStatement(gspStr, rs_IMMATBKD, rtnStr)
        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading IMM00001_Load sp_select_IMMATBKD :" & rtnStr)
        '    Exit Sub
        'End If

        format_VendorCombo()

        display_dgColor("IM")
        display_dgPacking("IM")
        display_dgPV("IM")
        display_dgOEMCustomer("IM")
        display_dgCostPrice("IM", "PriceOnly")
        display_dgExclCustomer("IM")
        display_dgCusStyle("IM")
        display_dgMatBreakdown("IM")
        display_dgTempItem()

        format_cboItmTyp()
        format_cboStatus()
        format_cboItmVenTyp()
        format_cboPrdTyp()
        format_cboMaterial()
        format_cboItmNature()
        format_cboPrdSizeTyp()
        format_cboPrdSizeUnit()
        format_cboPrdGroup()
        format_cboPrdIcon()
        format_cboSeason()
        format_cboDesigner()
        format_cboCategory()
        format_cboPrdLne()
        format_cboConstrMethod()
        format_cboHstuUSA()
        format_cboHstuEUR()
        format_cboTierStr()
        format_cboMOACurr()


        format_cboUM()

        format_cboPanCus1no()
        format_cboPanCPStatus()
        format_cboPanCPPriceTerm()
        format_cboPanCPTranTerm()

        format_cboPanMMMOQMOA()
        format_cboPanMMMOQUM()
        format_cboPanMMMOACur()

        mode = "INIT"
        Call formInit(mode)
        txtItmNo.Select()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If Recordstatus = True Then
            cmdClear_Click(sender, e)
        End If
        Me.Close()
    End Sub

    Private Sub formInit(ByVal m As String)
        If m = "INIT" Then
            Call clearAllDisplay(Me)
        End If

        Call resetcmdButton(m)

        Call resetDisplay(m)

        'Me.StatusBar.Text = m
        Me.StatusBarPanel1.Text = m

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

        pbImage.Image = Nothing
        pbImage2.Image = Nothing
        IMTreeView.Nodes.Clear()

        PanelPacking.Visible = False
        PanelPV.Visible = False
        PanelCostPrice.Visible = False
        PanelCopy.Visible = False
    End Sub

    Private Sub resetcmdButton(ByVal m As String)
        If m = "INIT" Then
            If Enq_right_local = True Then
                Me.cmdAdd.Enabled = True
            Else
                Me.cmdAdd.Enabled = False
            End If
            Me.cmdSave.Enabled = False
            Me.cmdDelete.Enabled = False
            Me.cmdCancel.Enabled = False
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = True
            Me.cmdClear.Enabled = False

            Me.cmdSearch.Enabled = True

            Me.cmdInsRow.Enabled = False
            Me.cmdDelRow.Enabled = False
            Me.cmdFirst.Enabled = False
            Me.cmdPrevious.Enabled = False
            Me.cmdNext.Enabled = False
            Me.cmdLast.Enabled = False

            Me.cmdCombineImage.Enabled = False
            Me.cmdActivate.Enabled = False
            Me.cmdRelItm.Enabled = False
            Me.cbDiscontinue.Enabled = False
            Me.cmdBatchUpdate.Enabled = False

            Me.cmdBrowse.Enabled = True
            Me.cmdMapping.Enabled = False
            Me.cmdCopyPV.Enabled = True
            Me.cmdExit.Enabled = True

        ElseIf m = "ADD" Then
            Me.cmdAdd.Enabled = False
            Me.cmdSave.Enabled = True
            Me.cmdDelete.Enabled = False
            Me.cmdCancel.Enabled = False
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = False
            Me.cmdClear.Enabled = True

            Me.cmdSearch.Enabled = False

            Me.cmdInsRow.Enabled = True
            Me.cmdDelRow.Enabled = True
            Me.cmdFirst.Enabled = False
            Me.cmdPrevious.Enabled = False
            Me.cmdNext.Enabled = False
            Me.cmdLast.Enabled = False

            Me.cmdBrowse.Enabled = False
            Me.cmdMapping.Enabled = False
            Me.cmdBatchUpdate.Enabled = False
            Me.cmdCopyPV.Enabled = True

            Me.cmdExit.Enabled = True
        ElseIf m = "UPDATE" Then
            Me.cmdAdd.Enabled = False
            Me.cmdSave.Enabled = True
            Me.cmdDelete.Enabled = True
            Me.cmdCancel.Enabled = False
            Me.cmdCopy.Enabled = True
            Me.cmdFind.Enabled = False
            Me.cmdClear.Enabled = True

            Me.cmdSearch.Enabled = False

            Me.cmdInsRow.Enabled = True
            Me.cmdDelRow.Enabled = True
            Me.cmdFirst.Enabled = False
            Me.cmdPrevious.Enabled = False
            Me.cmdNext.Enabled = False
            Me.cmdLast.Enabled = False

            Me.cmdBrowse.Enabled = False
            Me.cmdMapping.Enabled = True

            Me.cmdBatchUpdate.Enabled = True
            Me.cmdCopyPV.Enabled = True

            Me.cmdExit.Enabled = True
        ElseIf m = "READ" Then
            Me.cmdAdd.Enabled = False
            Me.cmdSave.Enabled = False
            Me.cmdDelete.Enabled = False
            Me.cmdCancel.Enabled = False
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = False
            Me.cmdClear.Enabled = True

            Me.cmdSearch.Enabled = False

            Me.cmdInsRow.Enabled = False
            Me.cmdDelRow.Enabled = False
            Me.cmdFirst.Enabled = False
            Me.cmdPrevious.Enabled = False
            Me.cmdNext.Enabled = False
            Me.cmdLast.Enabled = False

            Me.cmdBrowse.Enabled = False
            Me.cmdMapping.Enabled = True
            Me.cmdCopyPV.Enabled = False

            Me.cmdBatchUpdate.Enabled = False


            Me.cmdExit.Enabled = True
        ElseIf m = "DisableAll" Then
            Me.cmdAdd.Enabled = False
            Me.cmdSave.Enabled = False
            Me.cmdDelete.Enabled = False
            Me.cmdCancel.Enabled = False
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = False
            Me.cmdClear.Enabled = False

            Me.cmdSearch.Enabled = False

            Me.cmdInsRow.Enabled = False
            Me.cmdDelRow.Enabled = False
            Me.cmdFirst.Enabled = False
            Me.cmdPrevious.Enabled = False
            Me.cmdNext.Enabled = False
            Me.cmdLast.Enabled = False
            Me.cmdCopyPV.Enabled = False

            Me.cmdBrowse.Enabled = False
            Me.cmdMapping.Enabled = False

            Me.cmdBatchUpdate.Enabled = False


            Me.cmdExit.Enabled = True
        End If

    End Sub

    Private Sub resetDisplay(ByVal m As String)
        If m = "INIT" Then
            txtItmNo.Enabled = True

            Got_Focus_Grid = ""
            Recordstatus = False

            flag_panpack_keypress = False
            flag_dgBOMASS_mouseselect = False
            flag_pancostprice_keypress = False
            flag_dgOEMCustomer_mouseselect = False
            flag_dgExclCustomer_mouseselect = False
            flag_dgPacking_keypress = False
            flag_dgCostPrice_keypress = False

            flag_bomqty_keypress = False

            freeze_TabControl(0)
            Me.TabPageMain.SelectedIndex = 0


        ElseIf m = "ADD" Then
            txtItmNo.Enabled = False

            txtEngDsc.Enabled = True
            txtEngDsc.ReadOnly = False

            txtChnDsc.Enabled = True
            txtChnDsc.ReadOnly = False

            txtItmRmk.Enabled = True
            txtItmRmk.ReadOnly = False

            txtItmRmk2.Enabled = True
            txtItmRmk2.ReadOnly = False

            txtFtrRmk.Enabled = True
            txtFtrRmk.ReadOnly = False

            txtSChnDsc.Enabled = True
            txtSChnDsc.ReadOnly = False

            txtCstRmk.Enabled = True
            txtCstRmk.ReadOnly = False
            txtCstExpDat.Enabled = True

            gbPriceView.Enabled = True
            gbPriceStatus.Enabled = True

            cbTmpItm.Enabled = False

            cboItmTyp.Enabled = False

            cboDV.Enabled = True
            cboCV.Enabled = True
            cboTV.Enabled = True
            cboEV.Enabled = True

            cboPrdTyp.Enabled = True
            txtDsgItmNo.Enabled = True
            cboMaterial.Enabled = True
            cboItmNature.Enabled = True
            cboPrdSizeTyp.Enabled = True
            cboPrdSizeUnit.Enabled = True
            txtPrdSizeValue.Enabled = True
            cboPrdGroup.Enabled = True
            cboPrdIcon.Enabled = True
            cboSeason.Enabled = True
            cboDesigner.Enabled = True
            cboDevTeam.Enabled = True
            cboType.Enabled = True
            cboYear.Enabled = True
            cboPrdLne.Enabled = True
            cboCategory.Enabled = True

            cboConstrMethod.Enabled = True
            rbTier_Standard.Enabled = True
            rbTier_CompDef.Enabled = True
            cboMOQUM.Enabled = True
            txtMOQQty.Enabled = True
            cboMOACurr.Enabled = True
            txtMOAAmt.Enabled = True
            txtPerMultQty.Enabled = True

            gbAddreq.Enabled = True
            cbAddreq_formA.Enabled = True
            cbAddreq_ccib.Enabled = True
            cbAddreq_ster.Enabled = True

            cboHstuUSA.Enabled = True
            cboHstuEur.Enabled = True


        ElseIf m = "UPDATE" Then
            txtItmNo.Enabled = False

            txtEngDsc.Enabled = True
            txtEngDsc.ReadOnly = False

            txtChnDsc.Enabled = True
            txtChnDsc.ReadOnly = False

            txtItmRmk.Enabled = True
            txtItmRmk.ReadOnly = False

            txtItmRmk2.Enabled = True
            txtItmRmk2.ReadOnly = False

            txtSChnDsc.Enabled = True
            txtSChnDsc.ReadOnly = False


            txtFtrRmk.Enabled = True
            txtFtrRmk.ReadOnly = False

            txtCstRmk.Enabled = True
            txtCstRmk.ReadOnly = False
            txtCstExpDat.Enabled = True

            gbPriceView.Enabled = True
            gbPriceStatus.Enabled = True

            cbTmpItm.Enabled = True

            cboCV.Enabled = True
            cboTV.Enabled = True
            cboEV.Enabled = True

            cboPrdTyp.Enabled = True
            txtDsgItmNo.Enabled = True
            cboMaterial.Enabled = True
            cboItmNature.Enabled = True
            cboPrdSizeTyp.Enabled = True
            cboPrdSizeUnit.Enabled = True
            txtPrdSizeValue.Enabled = True
            cboPrdGroup.Enabled = True
            cboPrdIcon.Enabled = True
            cboSeason.Enabled = True
            cboDesigner.Enabled = True
            cboDevTeam.Enabled = True
            cboType.Enabled = True
            cboYear.Enabled = True
            cboPrdLne.Enabled = True
            cboCategory.Enabled = True

            cboConstrMethod.Enabled = True

            If Split(cboItmVenTyp.Text, " - ")(0) = "EXT" Then
                rbTier_Standard.Enabled = False
                rbTier_CompDef.Enabled = False
                cboMOQUM.Enabled = False
                txtMOQQty.Enabled = False
                cboMOACurr.Enabled = False
                txtMOAAmt.Enabled = False
                txtWastage.Enabled = False
                txtPerMultQty.Enabled = False
                dgMOQMOA.Enabled = True
            Else
                rbTier_Standard.Enabled = True
                rbTier_CompDef.Enabled = True
                cboMOQUM.Enabled = True
                txtMOQQty.Enabled = True
                cboMOACurr.Enabled = True
                txtMOAAmt.Enabled = True
                txtWastage.Enabled = True
                txtPerMultQty.Enabled = True
                dgMOQMOA.Enabled = False
            End If

            gbAddreq.Enabled = True
            cbAddreq_formA.Enabled = True
            cbAddreq_ccib.Enabled = True
            cbAddreq_ster.Enabled = True

            cboHstuUSA.Enabled = True
            cboHstuEur.Enabled = True


        ElseIf m = "READ" Then
            txtItmNo.Enabled = False

            txtEngDsc.Enabled = True
            txtEngDsc.ReadOnly = True

            txtChnDsc.Enabled = True
            txtChnDsc.ReadOnly = True

            txtItmRmk.Enabled = True
            txtItmRmk.ReadOnly = True

            txtItmRmk2.Enabled = True
            txtItmRmk2.ReadOnly = True


            txtSChnDsc.Enabled = True
            txtSChnDsc.ReadOnly = True

            txtCstRmk.Enabled = True
            txtCstRmk.ReadOnly = True

            gbPriceView.Enabled = True
            gbPriceStatus.Enabled = True

            cbTmpItm.Enabled = False

            cboCV.Enabled = False
            cboTV.Enabled = False
            cboEV.Enabled = False

            cboPrdTyp.Enabled = False
            txtDsgItmNo.Enabled = False
            cboMaterial.Enabled = False
            cboItmNature.Enabled = False
            cboPrdSizeTyp.Enabled = False
            cboPrdSizeUnit.Enabled = False
            txtPrdSizeValue.Enabled = False
            cboPrdGroup.Enabled = False
            cboPrdIcon.Enabled = False
            cboSeason.Enabled = False
            cboDesigner.Enabled = False
            cboDevTeam.Enabled = False
            cboType.Enabled = False
            cboYear.Enabled = False
            cboPrdLne.Enabled = False
            cboCategory.Enabled = False

            cboConstrMethod.Enabled = False
            rbTier_Standard.Enabled = False
            rbTier_CompDef.Enabled = False
            cboMOQUM.Enabled = False
            txtMOQQty.Enabled = False
            cboMOACurr.Enabled = False
            txtMOAAmt.Enabled = False
            txtPerMultQty.Enabled = False

            gbAddreq.Enabled = False
            cbAddreq_formA.Enabled = False
            cbAddreq_ccib.Enabled = False
            cbAddreq_ster.Enabled = False

            cboHstuUSA.Enabled = False
            cboHstuEur.Enabled = False
        End If
    End Sub

    Private Sub format_TabControl(ByVal imtype As String, ByVal itmtype As String)
        If imtype = "PCIM" Then
            Me.TabPageMain.TabPages(0).Enabled = True
            Me.TabPageMain.TabPages(1).Enabled = False
            Me.TabPageMain.TabPages(2).Enabled = True
            Me.TabPageMain.TabPages(3).Enabled = True
            Me.TabPageMain.TabPages(4).Enabled = True
            Me.TabPageMain.TabPages(5).Enabled = True
        Else
            If itmtype = "BOM" Then
                Me.TabPageMain.TabPages(0).Enabled = True
                Me.TabPageMain.TabPages(1).Enabled = True
                Me.TabPageMain.TabPages(2).Enabled = False
                Me.TabPageMain.TabPages(3).Enabled = True
                Me.TabPageMain.TabPages(4).Enabled = True
                Me.TabPageMain.TabPages(5).Enabled = False
            Else
                Me.TabPageMain.TabPages(0).Enabled = True
                Me.TabPageMain.TabPages(1).Enabled = True
                Me.TabPageMain.TabPages(2).Enabled = True
                Me.TabPageMain.TabPages(3).Enabled = True
                Me.TabPageMain.TabPages(4).Enabled = True
                Me.TabPageMain.TabPages(5).Enabled = True
            End If
        End If

        If Mid(gsUsrGrp, 1, 3) = "PKG" Then
            TabPageMain.TabPages(tabCostPrice).Enabled = False
        Else
            TabPageMain.TabPages(tabCostPrice).Enabled = True
        End If
    End Sub

    Private Sub freeze_TabControl(ByVal tabpageno As Integer)
        Dim i As Integer
        For i = 0 To TabPageMain.TabPages.Count - 1
            If i = tabpageno Then
                Me.TabPageMain.TabPages(i).Enabled = True
            Else
                Me.TabPageMain.TabPages(i).Enabled = False
            End If
        Next i
    End Sub

    Private Sub release_TabControl()
        Dim i As Integer
        For i = 0 To TabPageMain.TabPages.Count - 1
            Me.TabPageMain.TabPages(i).Enabled = True
        Next i
    End Sub

    Private Sub format_cboItmTyp()
        cboItmTyp.Items.Clear()
        cboItmTyp.Items.Add("REG - Regular")
        'cboItmTyp.Items.Add("REGB - Regular with BOM")
        cboItmTyp.Items.Add("ASS - Assortment")
        'cboItmTyp.Items.Add("ASSB - Assortment with BOM")
        cboItmTyp.Items.Add("BOM - BOM")

        'cboItmTyp.Text = ""
    End Sub

    Private Sub format_cboStatus()
        cboStatus.Items.Clear()
        cboStatus.Items.Add("CMP - Complete Item")
        cboStatus.Items.Add("INC - Incomplete Item")
        cboStatus.Items.Add("HLD - Item on Hold")
        cboStatus.Items.Add("DIS - Discontinue Item")
        cboStatus.Items.Add("TBC - To Be Confirmed")
        cboStatus.Items.Add("INA - Inactive Item")
        cboStatus.Items.Add("CLO - Closed Item")
        cboStatus.Items.Add("OLD - Old Item")

        'cboStatus.Text = ""
    End Sub

    Private Sub format_cboItmVenTyp()
        cboItmVenTyp.Items.Clear()
        cboItmVenTyp.Items.Add("")
        cboItmVenTyp.Items.Add("INT - Internal")
        cboItmVenTyp.Items.Add("JV - Joint Venture")
        cboItmVenTyp.Items.Add("EXT - External")

        'cboItmVenTyp.Text = ""
    End Sub

    Private Sub format_cboPrdTyp()
        cboPrdTyp.Items.Clear()
        cboPrdTyp.Items.Add("")
        cboPrdTyp.Items.Add("SHOWROOM - SHOWROOM")
        cboPrdTyp.Items.Add("OEM - OEM")
        cboPrdTyp.Items.Add("MODIFY - MODIFY")
        cboPrdTyp.Items.Add("ODM - OEM + SHOWROOM")

        'cboPrdTyp.Text = ""
    End Sub


    Private Sub format_VendorCombo()
        Dim i As Integer
        Dim strList As String

        cboDV.Items.Clear()
        cboCV.Items.Clear()
        cboEV.Items.Clear()
        cboTV.Items.Clear()
        cboPanPVPV.Items.Clear()

        cboDV.Items.Add("")
        cboCV.Items.Add("")
        cboEV.Items.Add("")
        cboTV.Items.Add("")
        cboPanPVPV.Items.Add("")

        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                strList = rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensna")
                If strList <> "" Then
                    cboDV.Items.Add(strList)
                    cboCV.Items.Add(strList)
                    cboEV.Items.Add(strList)
                    cboTV.Items.Add(strList)
                    cboPanPVPV.Items.Add(strList)
                End If
            Next i
        End If
    End Sub

    Private Sub format_cboPanCus1no()
        Dim i As Integer
        Dim dr() As DataRow

        'cboPanCPCus1no.Items.Add("")
        'cboPanCPCus2no.Items.Add("")
        'cboPanMMCus1no.Items.Add("")
        'cboPanMMCus2no.Items.Add("")

        cboPanCPCus1no.Items.Clear()
        cboPanCPCus2no.Items.Clear()
        cboPanPackCus1no.Items.Clear()
        cboPanPackCus2no.Items.Clear()
        cboPanMMCus1no.Items.Clear()
        cboPanMMCus2no.Items.Clear()


        'For i = 0 To rs_CUGRPINF.Tables("RESULT").Rows.Count - 1
        '    cboPanCPCus1no.Items.Add(rs_CUGRPINF.Tables("RESULT").Rows(i)("cgi_cugrpcde").ToString & " - " & rs_CUGRPINF.Tables("RESULT").Rows(i)("cgi_cugrpdsc").ToString)
        '    cboPanMMCus1no.Items.Add(rs_CUGRPINF.Tables("RESULT").Rows(i)("cgi_cugrpcde").ToString & " - " & rs_CUGRPINF.Tables("RESULT").Rows(i)("cgi_cugrpdsc").ToString)
        'Next

        If Split(cboItmVenTyp.Text, " - ")(0) <> "" Then
            If Split(cboItmVenTyp.Text, " - ")(0) = "EXT" Then
                dr = Nothing
                dr = rs_CUGRPINF.Tables("RESULT").Select("cgi_grptyp = 'EXT' or cgi_grptyp = 'ALL'")
                If dr.Length > 0 Then
                    For i = 0 To dr.Length - 1
                        cboPanCPCus1no.Items.Add(dr(i)("cgi_cugrpcde").ToString & " - " & dr(i)("cgi_cugrpdsc").ToString)
                        cboPanMMCus1no.Items.Add(dr(i)("cgi_cugrpcde").ToString & " - " & dr(i)("cgi_cugrpdsc").ToString)
                        cboPanPackCus1no.Items.Add(dr(i)("cgi_cugrpcde").ToString & " - " & dr(i)("cgi_cugrpdsc").ToString)
                    Next
                End If
            Else
                dr = Nothing
                dr = rs_CUGRPINF.Tables("RESULT").Select("cgi_grptyp = 'INT' or cgi_grptyp = 'ALL'")
                If dr.Length > 0 Then
                    For i = 0 To dr.Length - 1
                        cboPanCPCus1no.Items.Add(dr(i)("cgi_cugrpcde").ToString & " - " & dr(i)("cgi_cugrpdsc").ToString)
                        cboPanMMCus1no.Items.Add(dr(i)("cgi_cugrpcde").ToString & " - " & dr(i)("cgi_cugrpdsc").ToString)
                        cboPanPackCus1no.Items.Add(dr(i)("cgi_cugrpcde").ToString & " - " & dr(i)("cgi_cugrpdsc").ToString)
                    Next
                End If
            End If
        Else
            dr = Nothing
            dr = rs_CUGRPINF.Tables("RESULT").Select("cgi_grptyp = 'INT' or cgi_grptyp = 'EXT' or cgi_grptyp = 'ALL'")
            If dr.Length > 0 Then
                For i = 0 To dr.Length - 1
                    cboPanCPCus1no.Items.Add(dr(i)("cgi_cugrpcde").ToString & " - " & dr(i)("cgi_cugrpdsc").ToString)
                    cboPanMMCus1no.Items.Add(dr(i)("cgi_cugrpcde").ToString & " - " & dr(i)("cgi_cugrpdsc").ToString)
                    cboPanPackCus1no.Items.Add(dr(i)("cgi_cugrpcde").ToString & " - " & dr(i)("cgi_cugrpdsc").ToString)
                Next
            End If
        End If

        Dim dr_p() As DataRow = rs_CUBASINF.Tables("RESULT").Select("cbi_cusno >= '50000' and cbi_custyp = 'P'")
        For i = 0 To dr_p.Length - 1
            If cboPanCPCus1no.Items.Contains(dr_p(i).Item("cbi_cusno").ToString & " - " & dr_p(i).Item("cbi_cussna").ToString) = False Then
                cboPanCPCus1no.Items.Add(dr_p(i).Item("cbi_cusno").ToString & " - " & dr_p(i).Item("cbi_cussna").ToString)
                cboPanMMCus1no.Items.Add(dr_p(i).Item("cbi_cusno").ToString & " - " & dr_p(i).Item("cbi_cussna").ToString)
                cboPanPackCus1no.Items.Add(dr_p(i).Item("cbi_cusno").ToString & " - " & dr_p(i).Item("cbi_cussna").ToString)
            End If
        Next i

        Dim dr_s() As DataRow = rs_CUBASINF.Tables("RESULT").Select("cbi_cusno >= '60000' and cbi_custyp = 'S'")
        For i = 0 To dr_s.Length - 1
            If cboPanCPCus2no.Items.Contains(dr_s(i).Item("cbi_cusno").ToString & " - " & dr_s(i).Item("cbi_cussna").ToString) = False Then
                cboPanCPCus2no.Items.Add(dr_s(i).Item("cbi_cusno").ToString & " - " & dr_s(i).Item("cbi_cussna").ToString)
                cboPanMMCus2no.Items.Add(dr_s(i).Item("cbi_cusno").ToString & " - " & dr_s(i).Item("cbi_cussna").ToString)
            End If
        Next i

    End Sub

    Private Sub format_cboPanCus2no(ByVal cus1no As String)
        cboPanCPCus2no.Items.Clear()
        'cboPanCPCus2no.Items.Add("")

        cboPanMMCus2no.Items.Clear()
        'cboPanMMCus2no.Items.Add("")

        cboPanPackCus2no.Items.Clear()

        gspStr = "sp_select_CUBASINF_Q ''," & cus1no & ",'Secondary'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading format_cboPanCus2no #001 sp_select_CUBASINF_Q :" & rtnStr)
            Exit Sub
        End If

        Dim i As Integer
        Dim strList As String

        If rs.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs.Tables("RESULT").Rows.Count - 1
                strList = ""
                strList = rs.Tables("RESULT").Rows(i).Item("csc_seccus") & " - " & rs.Tables("RESULT").Rows(i).Item("cbi_cussna")
                If strList <> "" Then
                    If cboPanCPCus2no.Items.Contains(strList) = False Then
                        cboPanCPCus2no.Items.Add(strList)
                        cboPanMMCus2no.Items.Add(strList)
                        cboPanPackCus2no.Items.Add(strList)
                    End If
                End If
            Next i
        End If
    End Sub

    Private Sub format_cboPanCPStatus()
        cboPanCPStatus.Items.Clear()
        cboPanCPStatus.Items.Add("INA")
        cboPanCPStatus.Items.Add("ACT")
        cboPanCPStatus.Items.Add("TBC")
    End Sub

    Private Sub format_cboPanCPPriceTerm()
        Dim i As Integer
        cboPanCPPrcTrmHK.Items.Clear()
        cboPanCPPrcTrmHK.Items.Clear()
        Dim dr() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ = '03'")
        For i = 0 To dr.Length - 1
            cboPanCPPrcTrmHK.Items.Add(dr(i).Item("ysi_cde").ToString)
            cboPanCPPrcTrmFty.Items.Add(dr(i).Item("ysi_cde").ToString)
        Next i
    End Sub

    Private Sub format_cboPanCPTranTerm()
        Dim i As Integer
        cboPanCPTranTrm.Items.Clear()
        cboPanCPTranTrm.Items.Add("")
        Dim dr() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ = '30'")
        For i = 0 To dr.Length - 1
            cboPanCPTranTrm.Items.Add(dr(i).Item("ysi_cde").ToString)
        Next i
    End Sub

    Private Sub format_cboMaterial()
        cboMaterial.Items.Clear()
        cboMaterial.Items.Add("")

        Dim i As Integer

        Dim dr() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ = '25'")
        For i = 0 To dr.Length - 1
            cboMaterial.Items.Add(dr(i).Item("ysi_cde").ToString & " - " & dr(i).Item("ysi_dsc").ToString)
        Next i
    End Sub

    Private Sub format_cboItmNature()
        cboItmNature.Items.Clear()
        cboItmNature.Items.Add("")

        Dim i As Integer

        Dim dr() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ in ('20','29')")
        For i = 0 To dr.Length - 1
            cboItmNature.Items.Add(dr(i).Item("ysi_cde").ToString & " - " & dr(i).Item("ysi_dsc").ToString)
        Next i
    End Sub


    Private Sub format_cboPrdSizeTyp()
        cboPrdSizeTyp.Items.Clear()
        cboPrdSizeTyp.Items.Add("")

        Dim i As Integer

        Dim dr() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ in ('26')")
        For i = 0 To dr.Length - 1
            cboPrdSizeTyp.Items.Add(dr(i).Item("ysi_cde").ToString & " - " & dr(i).Item("ysi_dsc").ToString)
        Next i
    End Sub

    Private Sub format_cboPrdSizeUnit()
        cboPrdSizeUnit.Items.Clear()
        cboPrdSizeUnit.Items.Add("")

        Dim i As Integer

        Dim dr() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ in ('27')")
        For i = 0 To dr.Length - 1
            cboPrdSizeUnit.Items.Add(dr(i).Item("ysi_cde").ToString & " - " & dr(i).Item("ysi_dsc").ToString)
        Next i
    End Sub

    Private Sub format_cboPrdGroup()
        cboPrdGroup.Items.Clear()
        cboPrdGroup.Items.Add("")

        Dim i As Integer

        Dim dr() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ in ('24')")
        For i = 0 To dr.Length - 1
            cboPrdGroup.Items.Add(dr(i).Item("ysi_cde").ToString & " - " & dr(i).Item("ysi_dsc").ToString)
        Next i
    End Sub

    Private Sub format_cboPrdIcon()
        cboPrdIcon.Items.Clear()
        cboPrdIcon.Items.Add("")

        Dim i As Integer

        Dim dr() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ in ('28')")
        For i = 0 To dr.Length - 1
            cboPrdIcon.Items.Add(dr(i).Item("ysi_cde").ToString & " - " & dr(i).Item("ysi_dsc").ToString)
        Next i
    End Sub

    Private Sub format_cboSeason()
        cboSeason.Items.Clear()
        cboSeason.Items.Add("")

        Dim i As Integer

        Dim dr() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ in ('19')")
        For i = 0 To dr.Length - 1
            cboSeason.Items.Add(dr(i).Item("ysi_cde").ToString & " - " & dr(i).Item("ysi_dsc").ToString)
        Next i
    End Sub

    Private Sub format_cboDesigner()
        cboDesigner.Items.Clear()
        cboDesigner.Items.Add("")

        Dim i As Integer

        Dim dr() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ in ('15')")
        For i = 0 To dr.Length - 1
            cboDesigner.Items.Add(dr(i).Item("ysi_cde").ToString & " - " & dr(i).Item("ysi_dsc").ToString)
        Next i
    End Sub

    Private Sub format_cboConstrMethod()
        cboConstrMethod.Items.Clear()
        cboConstrMethod.Items.Add("")

        Dim i As Integer

        Dim dr() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ in ('07')")
        For i = 0 To dr.Length - 1
            cboConstrMethod.Items.Add(dr(i).Item("ysi_cde").ToString & " - " & dr(i).Item("ysi_dsc").ToString)
        Next i
    End Sub

    Private Sub format_cboCategory()
        Dim i As Integer
        Dim strList As String

        cboCategory.Items.Clear()
        cboCategory.Items.Add("")
        cboPanCopyCategory.Items.Clear()
        cboPanCopyCategory.Items.Add("")

        If rs_SYCATCDE_level4.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYCATCDE_level4.Tables("RESULT").Rows.Count - 1
                strList = rs_SYCATCDE_level4.Tables("RESULT").Rows(i).Item("ycc_catcde") & " - " & rs_SYCATCDE_level4.Tables("RESULT").Rows(i).Item("ycc_catdsc")
                If strList <> "" Then
                    cboCategory.Items.Add(strList)
                    cboPanCopyCategory.Items.Add(Split(strList, " - ")(0))
                End If
            Next i
        End If
    End Sub

    Private Sub format_cboPrdLne()
        Dim i As Integer
        Dim strList As String

        cboPrdLne.Items.Clear()
        cboPrdLne.Items.Add("")

        cboPanCopyPrdLne.Items.Clear()
        cboPanCopyPrdLne.Items.Add("")

        If rs_SYLNEINF.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYLNEINF.Tables("RESULT").Rows.Count - 1
                strList = rs_SYLNEINF.Tables("RESULT").Rows(i).Item("yli_lnecde")
                If strList <> "" Then
                    cboPrdLne.Items.Add(strList)
                    cboPanCopyPrdLne.Items.Add(strList)
                End If
            Next i
        End If
    End Sub

    Private Sub format_cboHstuUSA()
        Dim i As Integer
        Dim strList As String

        cboHstuUSA.Items.Clear()
        cboHstuUSA.Items.Add("")

        If rs_SYHRMCDE.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYHRMCDE.Tables("RESULT").Rows.Count - 1
                strList = rs_SYHRMCDE.Tables("RESULT").Rows(i).Item("yhc_hrmcde") & " - " & rs_SYHRMCDE.Tables("RESULT").Rows(i).Item("yhc_hrmdsc")
                If strList <> "" Then
                    cboHstuUSA.Items.Add(strList)
                End If
            Next i
        End If
    End Sub

    Private Function gethrmrate(ByVal hrmcde As String) As String
        gethrmrate = "0.000"
        Dim dr() As DataRow = rs_SYHRMCDE.Tables("RESULT").Select("yhc_tarzon = 'USA' and yhc_hrmcde = '" & hrmcde & "'")
        If dr.Length = 1 Then
            gethrmrate = dr(0).Item("yhc_dtyrat").ToString
        End If
    End Function

    Private Sub format_cboHstuEUR()
        Dim i As Integer
        Dim strList As String

        cboHstuEur.Items.Clear()
        cboHstuEur.Items.Add("")

        'If rs_SYHRMCDE.Tables("RESULT").Rows.Count > 0 Then
        '    For i = 0 To rs_SYHRMCDE.Tables("RESULT").Rows.Count - 1
        '        strList = rs_SYHRMCDE.Tables("RESULT").Rows(i).Item("yhc_hrmcde") & " - " & rs_SYHRMCDE.Tables("RESULT").Rows(i).Item("yhc_hrmdsc")
        '        If strList <> "" Then
        '            cboHstuEur.Items.Add(strList)
        '        End If
        '    Next i
        'End If
    End Sub

    Private Sub format_cboTierStr()
        Dim i As Integer
        Dim strList As String

        cboMOQUM.Items.Clear()
        cboMOQUM.Items.Add("")

        If rs_SYTIESTR.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYTIESTR.Tables("RESULT").Rows.Count - 1
                strList = rs_SYTIESTR.Tables("RESULT").Rows(i).Item("ycf_code1")
                If strList <> "" Then
                    cboMOQUM.Items.Add(strList)
                End If
            Next i
        End If
    End Sub

    Private Sub format_cboMOACurr()
        cboMOACurr.Items.Clear()
        cboMOACurr.Items.Add("")
        cboMOACurr.Items.Add("HKD")
        cboMOACurr.Items.Add("USD")
        cboMOACurr.Items.Add("CNY")
    End Sub

    Private Sub display_dgColor(ByVal imtyp As String)
        If rs_IMCOLINF.Tables.Count = 0 Then
            Exit Sub
        End If

        If imtyp = "IM" Then
            dgColor.DataSource = rs_IMCOLINF.Tables("RESULT").DefaultView
        End If

        dgColor.RowHeadersWidth = 18
        dgColor.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgColor.ColumnHeadersHeight = 18
        dgColor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgColor.AllowUserToResizeColumns = False
        dgColor.AllowUserToResizeRows = False
        dgColor.RowTemplate.Height = 18

        Dim i As Integer

        If mode = "UPDATE" Or mode = "ADD" Then
            For i = 0 To rs_IMCOLINF.Tables("RESULT").Columns.Count - 1
                rs_IMCOLINF.Tables("RESULT").Columns(i).ReadOnly = False
            Next i
        End If

        i = 0
        dgColor_icf_status = i
        dgColor.Columns(i).Visible = False
        i = i + 1 '1
        dgColor_icf_cocde = i
        dgColor.Columns(i).HeaderText = "Del"
        dgColor.Columns(i).Width = 30
        'dgColor.Columns(i).Visible = False
        i = i + 1 '2
        dgColor_icf_itmno = i
        dgColor.Columns(i).Visible = False
        i = i + 1 '3
        dgColor_icf_colcde = i
        dgColor.Columns(i).HeaderText = "Color Code"
        dgColor.Columns(i).Width = 80
        If mode = "UPDATE" Or mode = "ADD" Then
            dgColor.Columns(i).ReadOnly = False
        Else
            dgColor.Columns(i).ReadOnly = True
        End If
        i = i + 1 '4
        dgColor_icf_typ = i
        dgColor.Columns(i).Visible = False
        i = i + 1 '5
        dgColor_icf_coldsc = i
        dgColor.Columns(i).HeaderText = "Color Description"
        dgColor.Columns(i).Width = 100
        If mode = "UPDATE" Or mode = "ADD" Then
            dgColor.Columns(i).ReadOnly = False
        Else
            dgColor.Columns(i).ReadOnly = True
        End If
        i = i + 1 '6
        dgColor_icf_vencol = i
        dgColor.Columns(i).HeaderText = "Vendor Color Code"
        dgColor.Columns(i).Width = 100
        If mode = "UPDATE" Or mode = "ADD" Then
            dgColor.Columns(i).ReadOnly = False
        Else
            dgColor.Columns(i).ReadOnly = True
        End If
        i = i + 1 '7
        dgColor_icf_asscol = i
        dgColor.Columns(i).Visible = False
        i = i + 1 '8
        dgColor_icf_lnecde = i
        dgColor.Columns(i).Visible = False
        i = i + 1 '9
        dgColor_icf_ucpcde = i
        dgColor.Columns(i).HeaderText = "UPC #"
        dgColor.Columns(i).Width = 100
        If mode = "UPDATE" Or mode = "ADD" Then
            dgColor.Columns(i).ReadOnly = False
        Else
            dgColor.Columns(i).ReadOnly = True
        End If
        i = i + 1 '10
        dgColor_icf_eancde = i
        dgColor.Columns(i).HeaderText = "EAN #"
        dgColor.Columns(i).Width = 100
        If mode = "UPDATE" Or mode = "ADD" Then
            dgColor.Columns(i).ReadOnly = False
        Else
            dgColor.Columns(i).ReadOnly = True
        End If
        i = i + 1 '11
        dgColor_icf_swatchpath = i
        dgColor.Columns(i).Visible = False
        i = i + 1 '12
        dgColor_icf_imgpath = i
        dgColor.Columns(i).Visible = False
        i = i + 1 '13
        dgColor_icf_creusr = i
        dgColor.Columns(i).Visible = False
        i = i + 1 '14
        dgColor_icf_updusr = i
        dgColor.Columns(i).Visible = False
        i = i + 1 '15
        dgColor_icf_credat = i
        dgColor.Columns(i).Visible = False
        i = i + 1 '16
        dgColor_icf_upddat = i
        dgColor.Columns(i).Visible = False
        i = i + 1 '17
        dgColor_icf_timstp = i
        dgColor.Columns(i).Visible = False
        i = i + 1 '18
        dgColor_icf_colseq = i
        dgColor.Columns(i).Visible = False
    End Sub


    Private Sub display_dgPacking(ByVal imtyp As String)
        If rs_IMPCKINF.Tables.Count = 0 Then
            Exit Sub
        End If

        If imtyp = "IM" Then
            dgPacking.DataSource = rs_IMPCKINF.Tables("RESULT").DefaultView
        End If

        dgPacking.RowHeadersWidth = 18
        dgPacking.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgPacking.ColumnHeadersHeight = 18
        dgPacking.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgPacking.AllowUserToResizeColumns = True
        dgPacking.AllowUserToResizeRows = False
        dgPacking.RowTemplate.Height = 18

        Dim i As Integer
        If mode = "UPDATE" Or mode = "ADD" Then
            For i = 0 To rs_IMPCKINF.Tables("RESULT").Columns.Count - 1
                rs_IMPCKINF.Tables("RESULT").Columns(i).ReadOnly = False
            Next i
        End If


        dgPacking.Columns(dgPacking_ipi_cbm).Frozen = False

        i = 0
        dgPacking_ipi_status = i
        dgPacking.Columns(i).Visible = False
        i = i + 1 '1
        dgPacking_ipi_relation = i
        dgPacking.Columns(i).Visible = False
        i = i + 1 '2
        dgPacking_ipi_cocde = i
        dgPacking.Columns(i).HeaderText = "Del"
        dgPacking.Columns(i).Width = 30
        dgPacking.Columns(i).ReadOnly = True
        i = i + 1 '3
        dgPacking_ipi_itmno = i
        dgPacking.Columns(i).Visible = False
        i = i + 1 '4
        dgPacking_ipi_pckseq = i
        dgPacking.Columns(i).Visible = False
        i = i + 1 '5
        dgPacking_ipi_qutdat = i
        dgPacking.Columns(i).HeaderText = "Period"
        dgPacking.Columns(i).Width = 50
        If mode = "UPDATE" Or mode = "ADD" Then
            dgPacking.Columns(i).ReadOnly = False
        Else
            dgPacking.Columns(i).ReadOnly = True
        End If
        i = i + 1 '6
        dgPacking_ipi_pckunt = i
        dgPacking.Columns(i).HeaderText = "UM"
        dgPacking.Columns(i).Width = 40
        dgPacking.Columns(i).ReadOnly = True
        i = i + 1 '7
        dgPacking_ipi_inrqty = i
        dgPacking.Columns(i).HeaderText = "Inner"
        dgPacking.Columns(i).Width = 40
        dgPacking.Columns(i).ReadOnly = True
        i = i + 1 '8
        dgPacking_ipi_mtrqty = i
        dgPacking.Columns(i).HeaderText = "Master"
        dgPacking.Columns(i).Width = 40
        dgPacking.Columns(i).ReadOnly = True
        i = i + 1
        dgPacking_ipi_cus1no = i
        dgPacking.Columns(i).HeaderText = "Pri Cust."
        dgPacking.Columns(i).Width = 40
        dgPacking.Columns(i).ReadOnly = True
        dgPacking.Columns(i).DisplayIndex = 6
        i = i + 1
        dgPacking_ipi_cus2no = i
        dgPacking.Columns(i).HeaderText = "Sec Cust."
        dgPacking.Columns(i).Width = 40
        dgPacking.Columns(i).ReadOnly = True
        dgPacking.Columns(i).DisplayIndex = 7
        i = i + 1 '9
        dgPacking_ipi_cft = i
        dgPacking.Columns(i).HeaderText = "CFT"
        dgPacking.Columns(i).Width = 45
        If mode = "UPDATE" Or mode = "ADD" Then
            dgPacking.Columns(i).ReadOnly = False
        Else
            dgPacking.Columns(i).ReadOnly = True
        End If
        i = i + 1 '10
        dgPacking_ipi_cbm = i
        dgPacking.Columns(i).HeaderText = "CBM"
        dgPacking.Columns(i).Width = 45
        If mode = "UPDATE" Or mode = "ADD" Then
            dgPacking.Columns(i).ReadOnly = False
        Else
            dgPacking.Columns(i).ReadOnly = True
        End If
        i = i + 1 '11
        dgPacking_inner_in = i
        dgPacking.Columns(i).HeaderText = "Inner (inch) LxWxH"
        dgPacking.Columns(i).Width = 120
        If mode = "UPDATE" Or mode = "ADD" Then
            dgPacking.Columns(i).ReadOnly = False
        Else
            dgPacking.Columns(i).ReadOnly = True
        End If
        i = i + 1 '12
        dgPacking_master_in = i
        dgPacking.Columns(i).HeaderText = "Master (inch) LxWxH"
        dgPacking.Columns(i).Width = 120
        If mode = "UPDATE" Or mode = "ADD" Then
            dgPacking.Columns(i).ReadOnly = False
        Else
            dgPacking.Columns(i).ReadOnly = True
        End If
        i = i + 1 '13
        dgPacking_inner_cm = i
        dgPacking.Columns(i).HeaderText = "Inner (cm) LxWxH"
        dgPacking.Columns(i).Width = 120
        If mode = "UPDATE" Or mode = "ADD" Then
            dgPacking.Columns(i).ReadOnly = False
        Else
            dgPacking.Columns(i).ReadOnly = True
        End If
        i = i + 1 '14
        dgPacking_master_cm = i
        dgPacking.Columns(i).HeaderText = "Master (cm) LxWxH"
        dgPacking.Columns(i).Width = 120
        If mode = "UPDATE" Or mode = "ADD" Then
            dgPacking.Columns(i).ReadOnly = False
        Else
            dgPacking.Columns(i).ReadOnly = True
        End If
        i = i + 1 '15
        dgPacking_ipi_grswgt = i
        dgPacking.Columns(i).HeaderText = "G.W."
        dgPacking.Columns(i).Width = 50
        dgPacking.Columns(i).DisplayIndex = 17
        If mode = "UPDATE" Or mode = "ADD" Then
            dgPacking.Columns(i).ReadOnly = False
        Else
            dgPacking.Columns(i).ReadOnly = True
        End If
        i = i + 1 '16
        dgPacking_ipi_netwgt = i
        dgPacking.Columns(i).HeaderText = "N.W."
        dgPacking.Columns(i).Width = 50
        dgPacking.Columns(i).DisplayIndex = 18
        If mode = "UPDATE" Or mode = "ADD" Then
            dgPacking.Columns(i).ReadOnly = False
        Else
            dgPacking.Columns(i).ReadOnly = True
        End If
        i = i + 1 '17
        dgPacking_ipi_pckitr = i
        dgPacking.Columns(i).HeaderText = "Pack Inst"
        dgPacking.Columns(i).Width = 150
        dgPacking.Columns(i).DisplayIndex = 13
        If mode = "UPDATE" Or mode = "ADD" Then
            dgPacking.Columns(i).ReadOnly = False
        Else
            dgPacking.Columns(i).ReadOnly = True
        End If
        i = i + 1 '18
        dgPacking_ipi_conftr = i
        dgPacking.Columns(i).HeaderText = "Ftr"
        dgPacking.Columns(i).Width = 30
        dgPacking.Columns(i).DisplayIndex = 9
        dgPacking.Columns(i).ReadOnly = True
        i = i + 1 '19
        dgPacking_ipi_cusno = i
        dgPacking.Columns(i).HeaderText = "Cus No"
        dgPacking.Columns(i).Width = 60
        If mode = "UPDATE" Then
            rs_IMPCKINF.Tables("RESULT").Columns(i).ReadOnly = False
            dgPacking.Columns(i).ReadOnly = False
        Else
            dgPacking.Columns(i).ReadOnly = True
        End If
        dgPacking.Columns(i).Visible = False
        i = i + 1 '20
        dgPacking_ipi_cussna = i
        dgPacking.Columns(i).HeaderText = "Cus Name"
        dgPacking.Columns(i).Width = 100
        dgPacking.Columns(i).Visible = False
        i = i + 1 '21
        dgPacking_ipi_creusr = i
        dgPacking.Columns(i).Visible = False
        If mode = "UPDATE" Or mode = "ADD" Then
            dgPacking.Columns(i).ReadOnly = False
        Else
            dgPacking.Columns(i).ReadOnly = True
        End If
        i = i + 1 '22
        dgPacking_ipi_updusr = i
        dgPacking.Columns(i).Visible = False
        i = i + 1 '23
        dgPacking_ipi_credat = i
        dgPacking.Columns(i).Visible = False
        i = i + 1 '24
        dgPacking_ipi_upddat = i
        dgPacking.Columns(i).Visible = False
        i = i + 1 '25
        dgPacking_ipi_timstp = i
        dgPacking.Columns(i).Visible = False
        i = i + 1 '26
        dgPacking_max_seq = i
        dgPacking.Columns(i).Visible = False
        i = i + 1 '27
        dgPacking_ipi_inrsze = i
        dgPacking.Columns(i).Visible = False
        i = i + 1 '28
        dgPacking_ipi_mtrsze = i
        dgPacking.Columns(i).Visible = False
        i = i + 1 '29
        dgPacking_ipi_mat = i
        dgPacking.Columns(i).Visible = False


        dgPacking.Columns(dgPacking_ipi_cbm).Frozen = True

    End Sub


    Private Sub display_dgPV(ByVal imtyp As String)
        If rs_IMVENINF.Tables.Count = 0 Then
            Exit Sub
        End If

        If imtyp = "IM" Then
            dgPV.DataSource = rs_IMVENINF.Tables("RESULT").DefaultView
        End If

        dgPV.RowHeadersWidth = 18
        dgPV.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgPV.ColumnHeadersHeight = 18
        dgPV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgPV.AllowUserToResizeColumns = True
        dgPV.AllowUserToResizeRows = False
        dgPV.RowTemplate.Height = 18


        Dim i As Integer
        If mode = "UPDATE" Or mode = "ADD" Then
            For i = 0 To rs_IMVENINF.Tables("RESULT").Columns.Count - 1
                rs_IMVENINF.Tables("RESULT").Columns(i).ReadOnly = False
            Next i
        End If

        i = 0
        dgPV.Columns(i).Visible = False
        i = i + 1 '1
        dgPV.Columns(i).HeaderText = "Del"
        dgPV.Columns(i).Width = 40
        dgPV.Columns(i).ReadOnly = True
        i = i + 1 '2
        dgPV.Columns(i).Visible = False
        i = i + 1 '3
        dgPV.Columns(i).HeaderText = "Vendor Item No"
        dgPV.Columns(i).Width = 200
        dgPV.Columns(i).ReadOnly = True
        i = i + 1 '4
        dgPV.Columns(i).HeaderText = "Vendor"
        dgPV.Columns(i).Width = 50
        dgPV.Columns(i).ReadOnly = True
        i = i + 1 '5
        dgPV.Columns(i).HeaderText = "Vendor Name"
        dgPV.Columns(i).Width = 150
        dgPV.Columns(i).ReadOnly = True
        i = i + 1 '6
        dgPV.Columns(i).Visible = False
        i = i + 1 '7
        dgPV.Columns(i).HeaderText = "Default"
        dgPV.Columns(i).Width = 50
        dgPV.Columns(i).ReadOnly = True
        i = i + 1 '8
        dgPV.Columns(i).Visible = False
        i = i + 1 '9
        dgPV.Columns(i).Visible = False
        i = i + 1 '10
        dgPV.Columns(i).Visible = False
        i = i + 1 '11
        dgPV.Columns(i).Visible = False
        i = i + 1 '12
        dgPV.Columns(i).Visible = False
        i = i + 1 '13
        dgPV.Columns(i).Visible = False
    End Sub


    Private Sub display_dgOEMCustomer(ByVal imtyp As String)
        If rs_IMCUSNO.Tables.Count = 0 Then
            Exit Sub
        End If

        If imtyp = "IM" Then
            dgOEMCustomer.DataSource = rs_IMCUSNO.Tables("RESULT").DefaultView
        End If

        dgOEMCustomer.RowHeadersWidth = 18
        dgOEMCustomer.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgOEMCustomer.ColumnHeadersHeight = 18
        dgOEMCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgOEMCustomer.AllowUserToResizeColumns = True
        dgOEMCustomer.AllowUserToResizeRows = False
        dgOEMCustomer.RowTemplate.Height = 18

        Dim i As Integer
        If mode = "UPDATE" Or mode = "ADD" Then
            For i = 0 To rs_IMCUSNO.Tables("RESULT").Columns.Count - 1
                rs_IMCUSNO.Tables("RESULT").Columns(i).ReadOnly = False
            Next i
        End If
        i = 0
        dgOEMCustomer.Columns(i).HeaderText = "Del"
        dgOEMCustomer.Columns(i).Width = 40
        'dgPV.Columns(i).Visible = False
        i = i + 1 '1
        dgOEMCustomer.Columns(i).Visible = False
        i = i + 1 '2
        dgOEMCustomer.Columns(i).HeaderText = "Customer Code"
        dgOEMCustomer.Columns(i).Width = 200
        i = i + 1 '3
        'dgOEMCustomer.Columns(i).HeaderText = "Customer Name"
        'dgOEMCustomer.Columns(i).Width = 100
        dgOEMCustomer.Columns(i).Visible = False
        i = i + 1 '4
        dgOEMCustomer.Columns(i).HeaderText = "Remarks"
        dgOEMCustomer.Columns(i).Width = 100
        If mode = "UPDATE" Or mode = "ADD" Then
            rs_IMCUSNO.Tables("RESULT").Columns(i).ReadOnly = False
            dgOEMCustomer.Columns(i).ReadOnly = False
        Else
            dgOEMCustomer.Columns(i).ReadOnly = True
        End If
        i = i + 1 '5
        dgOEMCustomer.Columns(i).Visible = False
        i = i + 1 '6
        dgOEMCustomer.Columns(i).Visible = False
        i = i + 1 '7
        dgOEMCustomer.Columns(i).Visible = False
        i = i + 1 '8
        dgOEMCustomer.Columns(i).Visible = False
        i = i + 1 '9
        dgOEMCustomer.Columns(i).Visible = False
    End Sub

    Private Sub display_dgExclCustomer(ByVal imtyp As String)
        If rs_IMCTYINF.Tables.Count = 0 Then
            Exit Sub
        End If

        If imtyp = "IM" Then
            dgExclCustomer.DataSource = rs_IMCTYINF.Tables("RESULT").DefaultView
        End If

        dgExclCustomer.RowHeadersWidth = 18
        dgExclCustomer.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgExclCustomer.ColumnHeadersHeight = 18
        dgExclCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgExclCustomer.AllowUserToResizeColumns = True
        dgExclCustomer.AllowUserToResizeRows = False
        dgExclCustomer.RowTemplate.Height = 18

        Dim i As Integer

        If mode = "UPDATE" Or mode = "ADD" Then
            For i = 0 To rs_IMCTYINF.Tables("RESULT").Columns.Count - 1
                rs_IMCTYINF.Tables("RESULT").Columns(i).ReadOnly = False
            Next i
        End If

        i = 0
        dgExclCustomer_ici_status = i
        'dgPV.Columns(i).Visible = False
        dgExclCustomer.Columns(i).Visible = False
        i = i + 1 '1
        dgExclCustomer_ici_cocde = i
        dgExclCustomer.Columns(i).HeaderText = "Del"
        dgExclCustomer.Columns(i).Width = 30
        i = i + 1 '2
        dgExclCustomer_ici_itmno = i
        dgExclCustomer.Columns(i).Visible = False
        i = i + 1 '3
        dgExclCustomer_ici_ctyseq = i
        dgExclCustomer.Columns(i).Visible = False
        i = i + 1 '4
        dgExclCustomer_ici_cusno = i
        dgExclCustomer.Columns(i).HeaderText = "Cust Code"
        dgExclCustomer.Columns(i).Width = 130
        dgExclCustomer.Columns(i).ReadOnly = True
        i = i + 1 '5
        dgExclCustomer_cbi_cusnam = i
        'dgExclCustomer.Columns(i).HeaderText = "Cust Name"
        'dgExclCustomer.Columns(i).Width = 80
        dgExclCustomer.Columns(i).Visible = False
        i = i + 1 '6
        dgExclCustomer_ici_ctycde = i
        dgExclCustomer.Columns(i).HeaderText = "Country"
        dgExclCustomer.Columns(i).Width = 60
        dgExclCustomer.Columns(i).ReadOnly = True
        i = i + 1 '7
        dgExclCustomer_ici_valdat = i
        dgExclCustomer.Columns(i).HeaderText = "Valid Date"
        dgExclCustomer.Columns(i).Width = 60
        If mode = "UPDATE" Or mode = "ADD" Then
            dgExclCustomer.Columns(i).ReadOnly = False
        Else
            dgExclCustomer.Columns(i).ReadOnly = True
        End If
        i = i + 1 '8
        dgExclCustomer_ici_rmk = i
        dgExclCustomer.Columns(i).HeaderText = "Remarks"
        dgExclCustomer.Columns(i).Width = 80
        If mode = "UPDATE" Or mode = "ADD" Then
            dgExclCustomer.Columns(i).ReadOnly = False
        Else
            dgExclCustomer.Columns(i).ReadOnly = True
        End If
        i = i + 1 '9
        dgExclCustomer_ici_creusr = i
        dgExclCustomer.Columns(i).Visible = False
        i = i + 1 '10
        dgExclCustomer_ici_updusr = i
        dgExclCustomer.Columns(i).Visible = False
        i = i + 1 '11
        dgExclCustomer_ici_credat = i
        dgExclCustomer.Columns(i).Visible = False
        i = i + 1 '12
        dgExclCustomer_ici_upddat = i
        dgExclCustomer.Columns(i).Visible = False
        i = i + 1 '13
        dgExclCustomer_ici_timstp = i
        dgExclCustomer.Columns(i).Visible = False

    End Sub


    Private Sub display_dgCusStyle(ByVal imtyp As String)
        If rs_IMCUSSTY.Tables.Count = 0 Then
            Exit Sub
        End If

        If imtyp = "IM" Then
            dgCusStyle.DataSource = rs_IMCUSSTY.Tables("RESULT").DefaultView
        End If

        dgCusStyle.RowHeadersWidth = 18
        dgCusStyle.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgCusStyle.ColumnHeadersHeight = 18
        dgCusStyle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgCusStyle.AllowUserToResizeColumns = True
        dgCusStyle.AllowUserToResizeRows = False
        dgCusStyle.RowTemplate.Height = 18


        Dim i As Integer

        i = 0
        dgCusStyle.Columns(i).HeaderText = "Cust Code"
        dgCusStyle.Columns(i).Width = 80
        i = i + 1 '1
        dgCusStyle.Columns(i).HeaderText = "Cust Name"
        dgCusStyle.Columns(i).Width = 100
        i = i + 1 '2
        dgCusStyle.Columns(i).HeaderText = "Cust Style"
        dgCusStyle.Columns(i).Width = 120
        i = i + 1 '3
        dgCusStyle.Columns(i).Visible = False
        i = i + 1 '4
        dgCusStyle.Columns(i).Visible = False
        i = i + 1 '5
        dgCusStyle.Columns(i).Visible = False
        i = i + 1 '6
        dgCusStyle.Columns(i).Visible = False
        i = i + 1 '7
        dgCusStyle.Columns(i).Visible = False
        i = i + 1 '8
        dgCusStyle.Columns(i).Visible = False
    End Sub

    Private Sub display_dgTempItem()
        If rs_IMTMPREL.Tables.Count = 0 Then
            Exit Sub
        End If
        If rs_IMTMPREL.Tables("RESULT").Rows.Count > 0 Then
            cmdRelItm.Enabled = True
        Else
            cmdRelItm.Enabled = False
        End If
        dgTempItem.DataSource = rs_IMTMPREL.Tables("RESULT").DefaultView

        dgTempItem.RowHeadersWidth = 18
        dgTempItem.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgTempItem.ColumnHeadersHeight = 18
        dgTempItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgTempItem.AllowUserToResizeColumns = True
        dgTempItem.AllowUserToResizeRows = False
        dgTempItem.RowTemplate.Height = 18


        Dim i As Integer

        i = 0
        dgTempItem.Columns(i).HeaderText = "Item Number"
        dgTempItem.Columns(i).Width = 150
        i = i + 1 '1
        dgTempItem.Columns(i).HeaderText = "Temp Item"
        dgTempItem.Columns(i).Width = 150




    End Sub

    Private Sub display_dgMOQMOA()
        If rs_IMMOQMOA.Tables.Count = 0 Then
            Exit Sub
        End If

        dgMOQMOA.DataSource = rs_IMMOQMOA.Tables("RESULT").DefaultView

        dgMOQMOA.RowHeadersWidth = 18
        dgMOQMOA.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgMOQMOA.ColumnHeadersHeight = 18
        dgMOQMOA.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgMOQMOA.AllowUserToResizeColumns = True
        dgMOQMOA.AllowUserToResizeRows = False
        dgMOQMOA.RowTemplate.Height = 20

        With dgMOQMOA
            For i As Integer = 0 To rs_IMMOQMOA.Tables("RESULT").Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = "Del"
                        .Columns(i).Width = 30
                    Case imm_cus1no
                        .Columns(i).HeaderText = "P. Cust"
                        .Columns(i).Width = 50
                    Case imm_cus2no
                        .Columns(i).HeaderText = "S. Cust"
                        .Columns(i).Width = 50
                    Case imm_tirtyp
                        .Columns(i).HeaderText = "Type"
                        .Columns(i).Width = 100
                    Case imm_moqmoa
                        .Columns(i).HeaderText = "MOQ/MOA"
                        .Columns(i).Width = 62
                    Case imm_moqunttyp
                        .Columns(i).HeaderText = "UM"
                        .Columns(i).Width = 50
                    Case imm_moqctn
                        .Columns(i).HeaderText = "Qty"
                        .Columns(i).Width = 50
                    Case imm_curcde
                        .Columns(i).HeaderText = "CCY"
                        .Columns(i).Width = 50
                    Case imm_moa
                        .Columns(i).HeaderText = "Amt"
                        .Columns(i).Width = 60
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
        End With

        For i As Integer = 0 To dgMOQMOA.Columns.Count - 1
            dgMOQMOA.Columns(i).ReadOnly = True
        Next
    End Sub

    Private Sub display_dgMatBreakdown(ByVal imtyp As String)
        If rs_IMMATBKD.Tables.Count = 0 Then
            Exit Sub
        End If

        If imtyp = "IM" Then
            dgMatBreakdown.DataSource = rs_IMMATBKD.Tables("RESULT").DefaultView
        End If

        dgMatBreakdown.RowHeadersWidth = 18
        dgMatBreakdown.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgMatBreakdown.ColumnHeadersHeight = 18
        dgMatBreakdown.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgMatBreakdown.AllowUserToResizeColumns = True
        dgMatBreakdown.AllowUserToResizeRows = False
        dgMatBreakdown.RowTemplate.Height = 18

        Dim i As Integer

        If mode = "UPDATE" Or mode = "ADD" Then
            For i = 0 To rs_IMMATBKD.Tables("RESULT").Columns.Count - 1
                rs_IMMATBKD.Tables("RESULT").Columns(i).ReadOnly = False
            Next i
        End If


        i = 0
        dgMatBreakdown.Columns(i).Visible = False
        i = i + 1 '1
        dgMatBreakdown.Columns(i).HeaderText = "Del"
        dgMatBreakdown.Columns(i).Width = 30
        i = i + 1 '2
        dgMatBreakdown.Columns(i).Visible = False
        i = i + 1 '3
        dgMatBreakdown.Columns(i).Visible = False
        i = i + 1 '4
        dgMatBreakdown.Columns(i).HeaderText = "Material"
        dgMatBreakdown.Columns(i).Width = 100
        If mode = "UPDATE" Or mode = "ADD" Then
            dgMatBreakdown.Columns(i).ReadOnly = False
        Else
            dgMatBreakdown.Columns(i).ReadOnly = True
        End If
        i = i + 1 '5
        dgMatBreakdown.Columns(i).HeaderText = "Curr"
        dgMatBreakdown.Columns(i).Width = 40
        If mode = "UPDATE" Or mode = "ADD" Then
            dgMatBreakdown.Columns(i).ReadOnly = False
        Else
            dgMatBreakdown.Columns(i).ReadOnly = True
        End If
        i = i + 1 '6
        dgMatBreakdown.Columns(i).HeaderText = "Cost Amt"
        dgMatBreakdown.Columns(i).Width = 60
        If mode = "UPDATE" Or mode = "ADD" Then
            dgMatBreakdown.Columns(i).ReadOnly = False
        Else
            dgMatBreakdown.Columns(i).ReadOnly = True
        End If
        i = i + 1 '7
        dgMatBreakdown.Columns(i).HeaderText = "Cost%"
        dgMatBreakdown.Columns(i).Width = 60
        If mode = "UPDATE" Or mode = "ADD" Then
            dgMatBreakdown.Columns(i).ReadOnly = False
        Else
            dgMatBreakdown.Columns(i).ReadOnly = True
        End If
        i = i + 1 '8
        dgMatBreakdown.Columns(i).HeaderText = "Wgt%"
        dgMatBreakdown.Columns(i).Width = 60
        If mode = "UPDATE" Or mode = "ADD" Then
            dgMatBreakdown.Columns(i).ReadOnly = False
        Else
            dgMatBreakdown.Columns(i).ReadOnly = True
        End If
        i = i + 1 '9
        dgMatBreakdown.Columns(i).Visible = False
        i = i + 1 '10
        dgMatBreakdown.Columns(i).Visible = False
        i = i + 1 '11
        dgMatBreakdown.Columns(i).Visible = False
        i = i + 1 '12
        dgMatBreakdown.Columns(i).Visible = False
        i = i + 1 '13
        dgMatBreakdown.Columns(i).Visible = False

    End Sub

    Private Sub display_dgBOMASS(ByVal imtyp As String, ByVal bomass As String)
        If rs_IMBOMASS.Tables.Count = 0 Then
            Exit Sub
        End If

        If imtyp = "IM" Then
            dgBOMASS.DataSource = rs_IMBOMASS.Tables("RESULT").DefaultView
        End If

        dgBOMASS.RowHeadersWidth = 18
        dgBOMASS.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgBOMASS.ColumnHeadersHeight = 18
        dgBOMASS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgBOMASS.AllowUserToResizeColumns = True
        dgBOMASS.AllowUserToResizeRows = False
        dgBOMASS.RowTemplate.Height = 18

        Dim i As Integer
        If mode = "UPDATE" Or mode = "ADD" Then
            For i = 0 To rs_IMBOMASS.Tables("RESULT").Columns.Count - 1
                rs_IMBOMASS.Tables("RESULT").Columns(i).ReadOnly = False
            Next i
        End If

        i = 0
        dgBOMASS_iba_status = i
        dgBOMASS.Columns(i).Visible = False
        i = i + 1 '1
        dgBOMASS_iba_cocde = i
        dgBOMASS.Columns(i).HeaderText = "Del"
        dgBOMASS.Columns(i).Width = 30
        i = i + 1 '2
        dgBOMASS_iba_itmno = i
        dgBOMASS.Columns(i).Visible = False
        i = i + 1 '3
        dgBOMASS_iba_assitm = i
        If bomass = "BOM" Then
            dgBOMASS.Columns(i).HeaderText = "BOM Item#"
        Else
            dgBOMASS.Columns(i).HeaderText = "Assorted Item#"
        End If
        dgBOMASS.Columns(i).Width = 100
        If mode = "UPDATE" Or mode = "ADD" Then
            dgBOMASS.Columns(i).ReadOnly = False
        Else
            dgBOMASS.Columns(i).ReadOnly = True
        End If
        i = i + 1 '4
        dgBOMASS_iba_altitmno = i
        If bomass = "BOM" Then
            dgBOMASS.Columns(i).HeaderText = "Alt BOM Item#"
        Else
            dgBOMASS.Columns(i).HeaderText = "Alt Assorted Item#"
        End If
        dgBOMASS.Columns(i).Width = 90
        i = i + 1 '5
        dgBOMASS_iba_typ = i
        dgBOMASS.Columns(i).Visible = False
        i = i + 1 '6
        dgBOMASS_iba_colcde = i
        dgBOMASS.Columns(i).HeaderText = "Color Code"
        dgBOMASS.Columns(i).Width = 60
        i = i + 1 '7
        dgBOMASS_ibi_engdsc = i
        dgBOMASS.Columns(i).HeaderText = "Item Description"
        dgBOMASS.Columns(i).Width = 130
        i = i + 1 '8
        dgBOMASS_vbi_vensna = i
        dgBOMASS.Columns(i).HeaderText = "Vendor"
        dgBOMASS.Columns(i).Width = 60
        i = i + 1 '9
        dgBOMASS_iba_period = i
        If bomass = "BOM" Then
            dgBOMASS.Columns(i).HeaderText = "BOM Period"
            If Split(cboItmVenTyp.Text, " - ")(0) = "INT" Then
                dgBOMASS.Columns(i).Visible = False
            Else
                dgBOMASS.Columns(i).Visible = True
            End If
        Else
            dgBOMASS.Columns(i).HeaderText = "ASS Period"
        End If
        dgBOMASS.Columns(i).Width = 80
        i = i + 1 '10
        dgBOMASS_iba_pckunt = i
        dgBOMASS.Columns(i).HeaderText = "UM"
        dgBOMASS.Columns(i).Width = 50
        If mode = "UPDATE" Or mode = "ADD" Then
            dgBOMASS.Columns(i).ReadOnly = False
        Else
            dgBOMASS.Columns(i).ReadOnly = True
        End If
        i = i + 1 '11
        dgBOMASS_iba_bomqty = i
        If bomass = "BOM" Then
            dgBOMASS.Columns(i).HeaderText = "BOM Qty"
            dgBOMASS.Columns(i).Width = 60
            If mode = "UPDATE" Or mode = "ADD" Then
                dgBOMASS.Columns(i).ReadOnly = False
            Else
                dgBOMASS.Columns(i).ReadOnly = True
            End If
        Else
            dgBOMASS.Columns(i).Visible = False
        End If
        i = i + 1 '12
        dgBOMASS_iba_inrqty = i
        If bomass = "BOM" Then
            dgBOMASS.Columns(i).Visible = False
        Else
            dgBOMASS.Columns(i).HeaderText = "Inner"
            dgBOMASS.Columns(i).Width = 50
            If mode = "UPDATE" Or mode = "ADD" Then
                dgBOMASS.Columns(i).ReadOnly = False
            Else
                dgBOMASS.Columns(i).ReadOnly = True
            End If

        End If
        i = i + 1 '13
        dgBOMASS_iba_mtrqty = i
        If bomass = "BOM" Then
            dgBOMASS.Columns(i).Visible = False
        Else
            dgBOMASS.Columns(i).HeaderText = "Master"
            dgBOMASS.Columns(i).Width = 50
            If mode = "UPDATE" Or mode = "ADD" Then
                dgBOMASS.Columns(i).ReadOnly = False
            Else
                dgBOMASS.Columns(i).ReadOnly = True
            End If

        End If
        i = i + 1 '14
        dgBOMASS_iba_fcurcde = i
        If bomass = "BOM" Then
            dgBOMASS.Columns(i).HeaderText = "Currency"
            dgBOMASS.Columns(i).Width = 60
            If Split(cboItmVenTyp.Text, " - ")(0) = "INT" Then
                dgBOMASS.Columns(i).Visible = False
            Else
                dgBOMASS.Columns(i).Visible = True
            End If
        Else
            dgBOMASS.Columns(i).Visible = False
        End If
        i = i + 1 '15
        dgBOMASS_iba_ftycst = i
        If bomass = "BOM" Then
            dgBOMASS.Columns(i).HeaderText = "BOM Cost(Fty)"
            dgBOMASS.Columns(i).Width = 50
            If Split(cboItmVenTyp.Text, " - ")(0) = "INT" Then
                dgBOMASS.Columns(i).Visible = False
            Else
                dgBOMASS.Columns(i).Visible = True
            End If
        Else
            dgBOMASS.Columns(i).Visible = False
        End If
        i = i + 1 '16
        dgBOMASS_imu_ftyprc = i
        dgBOMASS.Columns(i).Visible = False
        i = i + 1 '17
        dgBOMASS_iba_ftyfmlopt = i
        If bomass = "BOM" Then
            dgBOMASS.Columns(i).HeaderText = "Formula(Fty)"
            dgBOMASS.Columns(i).Width = 70
        Else
            dgBOMASS.Columns(i).Visible = False
        End If
        i = i + 1 '18
        dgBOMASS_iba_fmlopt = i
        If bomass = "BOM" Then
            dgBOMASS.Columns(i).HeaderText = "Formula(HK)"
            dgBOMASS.Columns(i).Width = 70
        Else
            dgBOMASS.Columns(i).Visible = False
        End If
        i = i + 1 '19
        dgBOMASS_iba_bombasprc = i
        If bomass = "BOM" Then
            dgBOMASS.Columns(i).HeaderText = "Basic Price"
            dgBOMASS.Columns(i).Width = 50
        Else
            dgBOMASS.Columns(i).Visible = False
        End If
        i = i + 1 '20
        dgBOMASS_iba_costing = i
        If bomass = "BOM" Then
            dgBOMASS.Columns(i).HeaderText = "Update To Cost/Price"
            dgBOMASS.Columns(i).Width = 80
        Else
            dgBOMASS.Columns(i).Visible = False
        End If
        i = i + 1 '21
        dgBOMASS_iba_genpo = i
        If bomass = "BOM" Then
            dgBOMASS.Columns(i).HeaderText = "PO"
            dgBOMASS.Columns(i).Width = 40
        Else
            dgBOMASS.Columns(i).Visible = False
        End If
        i = i + 1 '22
        dgBOMASS_iba_curcde = i
        dgBOMASS.Columns(i).Visible = False
        i = i + 1 '23
        dgBOMASS_iba_untcst = i
        dgBOMASS.Columns(i).Visible = False
        i = i + 1 '24
        dgBOMASS_iba_creusr = i
        dgBOMASS.Columns(i).Visible = False
        i = i + 1 '25
        dgBOMASS_iba_updusr = i
        dgBOMASS.Columns(i).Visible = False
        i = i + 1 '26
        dgBOMASS_iba_credat = i
        dgBOMASS.Columns(i).Visible = False
        i = i + 1 '27
        dgBOMASS_iba_upddat = i
        dgBOMASS.Columns(i).Visible = False
        i = i + 1 '28
        dgBOMASS_iba_timstp = i
        dgBOMASS.Columns(i).Visible = False
        i = i + 1 '29
        dgBOMASS_iba_assftyitm = i
        If bomass = "BOM" Then
            dgBOMASS.Columns(i).HeaderText = ""
            dgBOMASS.Columns(i).Visible = False
        Else
            dgBOMASS.Columns(i).HeaderText = "Assorted Factory Item#"
            dgBOMASS.Columns(i).Visible = True
        End If
        dgBOMASS.Columns(i).Width = 150
        dgBOMASS.Columns(i).DisplayIndex = 4
        i = i + 1 '30
        dgBOMASS_iba_orgcolcde = i
        dgBOMASS.Columns(i).Visible = False

        'Display IM Tree Node
        IMTreeView.Nodes.Clear()
        If rs_IMBOMASS.Tables("RESULT").Rows.Count > 0 Then
            Dim TNode As New TreeNode(rs_IMBOMASS.Tables("RESULT").Rows(0).Item("iba_itmno"))
            IMTreeView.Nodes.Add(TNode)

            If bomass = "BOM" Then
                For i = 0 To rs_IMBOMASS.Tables("RESULT").Rows.Count - 1
                    Dim CNode As New TreeNode(rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_assitm") & " x " & rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_bomqty") & " " & rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_pckunt"))
                    TNode.Nodes.Add(CNode)
                Next i
            Else
                For i = 0 To rs_IMBOMASS.Tables("RESULT").Rows.Count - 1
                    Dim CNode As New TreeNode(rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_assitm"))
                    TNode.Nodes.Add(CNode)
                Next i
            End If
        End If
        IMTreeView.ExpandAll()


    End Sub

    Private Sub display_dgRelParentItem()

        dgRelParentItem.DataSource = rs_IMR00021.Tables("RESULT").DefaultView

        dgRelParentItem.RowHeadersWidth = 18
        dgRelParentItem.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgRelParentItem.ColumnHeadersHeight = 18
        dgRelParentItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgRelParentItem.AllowUserToResizeColumns = True
        dgRelParentItem.AllowUserToResizeRows = False
        dgRelParentItem.RowTemplate.Height = 18

        Dim i As Integer

        i = 0
        dgRelParentItem.Columns(i).Visible = False
        i = i + 1 '1
        dgRelParentItem.Columns(i).Visible = False
        i = i + 1 '2
        dgRelParentItem.Columns(i).HeaderText = "Assortment"
        dgRelParentItem.Columns(i).Width = 95
        i = i + 1 '3
        dgRelParentItem.Columns(i).HeaderText = "Assorted"
        dgRelParentItem.Columns(i).Width = 95
        i = i + 1 '4
        dgRelParentItem.Columns(i).HeaderText = "Col"
        dgRelParentItem.Columns(i).Width = 40
        i = i + 1 '5
        dgRelParentItem.Columns(i).HeaderText = "BOM"
        dgRelParentItem.Columns(i).Width = 90
        i = i + 1 '6
        dgRelParentItem.Columns(i).Visible = False
        i = i + 1 '7
        dgRelParentItem.Columns(i).HeaderText = "Item Desc"
        dgRelParentItem.Columns(i).Width = 160

    End Sub

    Private Sub display_dgCostPrice(ByVal imtyp As String, ByVal view As String)
        If rs_IMPRCINF.Tables.Count = 0 Then
            Exit Sub
        End If

        If imtyp = "IM" Then
            dgCostPrice.DataSource = rs_IMPRCINF.Tables("RESULT").DefaultView
        End If

        dgCostPrice.RowHeadersWidth = 18
        dgCostPrice.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgCostPrice.ColumnHeadersHeight = 18
        dgCostPrice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgCostPrice.AllowUserToResizeColumns = True
        dgCostPrice.AllowUserToResizeRows = False
        dgCostPrice.RowTemplate.Height = 18
        dgCostPrice.AllowUserToOrderColumns = True


        Dim itmtyp As String
        '        If rs_IMPRCINF.Tables("RESULT").Rows.Count = 0 Then
        itmtyp = Split(cboItmTyp.Text, " - ")(0)
        'Else
        'itmtyp = rs_IMPRCINF.Tables("RESULT").Rows(0).Item("imu_typ")
        'End If

        Dim i As Integer
        If mode = "UPDATE" Or mode = "ADD" Then
            For i = 0 To rs_IMPRCINF.Tables("RESULT").Columns.Count - 1
                rs_IMPRCINF.Tables("RESULT").Columns(i).ReadOnly = False
            Next i
        End If


        i = 0
        dgCostPrice_imu_cocde = i
        If mode = "UPDATE" Or mode = "ADD" Then
            dgCostPrice.Columns(i).HeaderText = "Del"
            dgCostPrice.Columns(i).Width = 30
            dgCostPrice.Columns(i).Visible = True
            dgCostPrice.Columns(i).ReadOnly = True
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        i = i + 1 '1
        dgCostPrice_imu_itmno = i
        dgCostPrice.Columns(i).Visible = False
        i = i + 1 '2
        dgCostPrice_imu_typ = i
        dgCostPrice.Columns(i).Visible = False
        i = i + 1 '3
        dgCostPrice_imu_ventyp = i
        dgCostPrice.Columns(i).Visible = False
        i = i + 1 '4
        dgCostPrice_imu_venno = i
        dgCostPrice.Columns(i).HeaderText = "DV"
        dgCostPrice.Columns(i).Width = 35
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '5
        dgCostPrice_imu_prdven = i
        dgCostPrice.Columns(i).HeaderText = "PV"
        dgCostPrice.Columns(i).Width = 35
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '6
        dgCostPrice_imu_packing = i
        dgCostPrice.Columns(i).HeaderText = "Packing"
        dgCostPrice.Columns(i).Width = 105
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '7
        dgCostPrice_imu_pckunt = i
        dgCostPrice.Columns(i).Visible = False
        '        dgCostPrice.Columns(i).HeaderText = "UM"
        '        dgCostPrice.Columns(i).Width = 30
        i = i + 1 '8
        dgCostPrice_imu_conftr = i
        dgCostPrice.Columns(i).Visible = False
        '        dgCostPrice.Columns(i).HeaderText = "Ftr"
        '        dgCostPrice.Columns(i).Width = 30
        i = i + 1 '9
        dgCostPrice_imu_inrqty = i
        dgCostPrice.Columns(i).Visible = False
        '       dgCostPrice.Columns(i).HeaderText = "Inner"
        '       dgCostPrice.Columns(i).Width = 20
        i = i + 1 '10
        dgCostPrice_imu_mtrqty = i
        dgCostPrice.Columns(i).Visible = False
        '        dgCostPrice.Columns(i).HeaderText = "Master"
        '        dgCostPrice.Columns(i).Width = 20
        i = i + 1 '11
        dgCostPrice.Columns(i).Visible = True
        dgCostPrice_imu_period = i
        dgCostPrice.Columns(i).HeaderText = "Period"
        dgCostPrice.Columns(i).Width = 60
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '12
        dgCostPrice_imu_cus1no = i
        dgCostPrice.Columns(i).HeaderText = "Pri Cus"
        dgCostPrice.Columns(i).Width = 60
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '13
        dgCostPrice_imu_cus2no = i
        dgCostPrice.Columns(i).HeaderText = "Sec Cus"
        dgCostPrice.Columns(i).Width = 60
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '14
        dgCostPrice_imu_ftyprctrm = i
        dgCostPrice.Columns(i).HeaderText = "FtyPriceTerm"
        dgCostPrice.Columns(i).Width = 50
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '15
        dgCostPrice_imu_hkprctrm = i
        dgCostPrice.Columns(i).HeaderText = "HKPriceTerm"
        dgCostPrice.Columns(i).Width = 50
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '16
        dgCostPrice_imu_trantrm = i
        dgCostPrice.Columns(i).HeaderText = "TranTerm"
        dgCostPrice.Columns(i).Width = 35
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '17
        dgCostPrice_imu_effdat = i
        dgCostPrice.Columns(i).HeaderText = "Eff Date"
        dgCostPrice.Columns(i).Width = 65
        If mode = "UPDATE" Or mode = "ADD" Then
            dgCostPrice.Columns(i).ReadOnly = False
        Else
            dgCostPrice.Columns(i).ReadOnly = True
        End If
        i = i + 1 '18
        dgCostPrice_imu_expdat = i
        dgCostPrice.Columns(i).HeaderText = "Exp Date"
        dgCostPrice.Columns(i).Width = 65
        If mode = "UPDATE" Or mode = "ADD" Then
            dgCostPrice.Columns(i).ReadOnly = False
        Else
            dgCostPrice.Columns(i).ReadOnly = True
        End If
        i = i + 1 '19
        dgCostPrice_imu_status = i
        dgCostPrice.Columns(i).HeaderText = "Status"
        dgCostPrice.Columns(i).Width = 35
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '20
        dgCostPrice_imu_curcde = i
        If view = "Standard" Or view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "Curr"
            dgCostPrice.Columns(i).Width = 40
            dgCostPrice.Columns(i).Visible = True
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '21
        dgCostPrice_imu_ftycstA = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "FtyCstA"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = True
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        If mode = "UPDATE" Or mode = "ADD" Then
            dgCostPrice.Columns(i).ReadOnly = False
        Else
            dgCostPrice.Columns(i).ReadOnly = True
        End If
        i = i + 1 '22
        dgCostPrice_imu_ftycstB = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "FtyCstB"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = True
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        If mode = "UPDATE" Or mode = "ADD" Then
            dgCostPrice.Columns(i).ReadOnly = False
        Else
            dgCostPrice.Columns(i).ReadOnly = True
        End If
        i = i + 1 '23
        dgCostPrice_imu_ftycstC = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "FtyCstC"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = True
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        If mode = "UPDATE" Or mode = "ADD" Then
            dgCostPrice.Columns(i).ReadOnly = False
        Else
            dgCostPrice.Columns(i).ReadOnly = True
        End If
        i = i + 1 '24
        dgCostPrice_imu_ftycstD = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "FtyCstD"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = True
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        If mode = "UPDATE" Or mode = "ADD" Then
            dgCostPrice.Columns(i).ReadOnly = False
        Else
            dgCostPrice.Columns(i).ReadOnly = True
        End If
        i = i + 1 '25
        dgCostPrice_imu_ftycstE = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "FtyCstE"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = True
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        If mode = "UPDATE" Or mode = "ADD" Then
            dgCostPrice.Columns(i).ReadOnly = False
        Else
            dgCostPrice.Columns(i).ReadOnly = True
        End If
        i = i + 1 '26
        dgCostPrice_imu_ftycstTran = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "FtyCstT"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = True
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        If mode = "UPDATE" Or mode = "ADD" Then
            dgCostPrice.Columns(i).ReadOnly = False
        Else
            dgCostPrice.Columns(i).ReadOnly = True
        End If
        i = i + 1 '27
        dgCostPrice_imu_ftycstPack = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "FtyCstP"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = True
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        If mode = "UPDATE" Or mode = "ADD" Then
            dgCostPrice.Columns(i).ReadOnly = False
        Else
            dgCostPrice.Columns(i).ReadOnly = True
        End If
        i = i + 1 '28
        dgCostPrice_imu_ftycst = i
        If view = "Standard" Or view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "FtyCst"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = True
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        If mode = "UPDATE" Or mode = "ADD" Then
            dgCostPrice.Columns(i).ReadOnly = False
        Else
            dgCostPrice.Columns(i).ReadOnly = True
        End If
        i = i + 1 '29
        dgCostPrice_imu_fmlA = i
        dgCostPrice.Columns(i).Visible = False
        'If view = "Full" Then
        '    dgCostPrice.Columns(i).HeaderText = "FmlA"
        '    dgCostPrice.Columns(i).Width = 50
        '    dgCostPrice.Columns(i).Visible = True
        'Else
        '    dgCostPrice.Columns(i).Visible = False
        'End If
        i = i + 1 '30
        dgCostPrice_imu_fmlB = i
        dgCostPrice.Columns(i).Visible = False
        'If view = "Full" Then
        '    dgCostPrice.Columns(i).HeaderText = "FmlB"
        '    dgCostPrice.Columns(i).Width = 50
        '    dgCostPrice.Columns(i).Visible = True
        'Else
        '    dgCostPrice.Columns(i).Visible = False
        'End If
        i = i + 1 '31
        dgCostPrice_imu_fmlC = i
        dgCostPrice.Columns(i).Visible = False
        'If view = "Full" Then
        '    dgCostPrice.Columns(i).HeaderText = "FmlC"
        '    dgCostPrice.Columns(i).Width = 50
        '    dgCostPrice.Columns(i).Visible = True
        'Else
        '    dgCostPrice.Columns(i).Visible = False
        'End If
        i = i + 1 '32
        dgCostPrice_imu_fmlD = i
        dgCostPrice.Columns(i).Visible = False
        'If view = "Full" Then
        '    dgCostPrice.Columns(i).HeaderText = "FmlD"
        '    dgCostPrice.Columns(i).Width = 50
        '    dgCostPrice.Columns(i).Visible = True
        'Else
        '    dgCostPrice.Columns(i).Visible = False
        'End If
        i = i + 1 '33
        dgCostPrice_imu_fmlE = i
        dgCostPrice.Columns(i).Visible = False
        'If view = "Full" Then
        '    dgCostPrice.Columns(i).HeaderText = "FmlD"
        '    dgCostPrice.Columns(i).Width = 50
        '    dgCostPrice.Columns(i).Visible = True
        'Else
        '    dgCostPrice.Columns(i).Visible = False
        'End If
        i = i + 1 '34
        dgCostPrice_imu_fmlTran = i
        dgCostPrice.Columns(i).Visible = False
        'If view = "Full" Then
        '    dgCostPrice.Columns(i).HeaderText = "FmlT"
        '    dgCostPrice.Columns(i).Width = 50
        '    dgCostPrice.Columns(i).Visible = True
        'Else
        '    dgCostPrice.Columns(i).Visible = False
        'End If
        i = i + 1 '35
        dgCostPrice_imu_fmlPack = i
        dgCostPrice.Columns(i).Visible = False
        'If view = "Full" Then
        '    dgCostPrice.Columns(i).HeaderText = "FmlP"
        '    dgCostPrice.Columns(i).Width = 50
        '    dgCostPrice.Columns(i).Visible = True
        'Else
        '    dgCostPrice.Columns(i).Visible = False
        'End If
        i = i + 1 '36
        dgCostPrice_imu_fml = i
        dgCostPrice.Columns(i).Visible = False
        'If view = "Full" Then
        '    dgCostPrice.Columns(i).HeaderText = "Fml"
        '    dgCostPrice.Columns(i).Width = 50
        '    dgCostPrice.Columns(i).Visible = True
        'Else
        '    dgCostPrice.Columns(i).Visible = False
        'End If
        i = i + 1 '37
        dgCostPrice_imu_chgfpA = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "ChgA"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = False
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '38
        dgCostPrice_imu_chgfpB = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "ChgB"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = False
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '39
        dgCostPrice_imu_chgfpC = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "ChgC"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = False
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '40
        dgCostPrice_imu_chgfpD = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "ChgD"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = False
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '41
        dgCostPrice_imu_chgfpD = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "ChgE"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = False
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '42
        dgCostPrice_imu_chgfpTran = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "ChgT"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = False
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '43
        dgCostPrice_imu_chgfpPack = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "ChgP"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = False
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '44
        dgCostPrice_imu_chgfp = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "Chg"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = True
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '45
        dgCostPrice_imu_ftyprcA = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "FtyPrcA"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = False
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        If mode = "UPDATE" Or mode = "ADD" Then
            dgCostPrice.Columns(i).ReadOnly = False
        Else
            dgCostPrice.Columns(i).ReadOnly = True
        End If
        i = i + 1 '46
        dgCostPrice_imu_ftyprcB = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "FtyPrcB"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = False
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        If mode = "UPDATE" Or mode = "ADD" Then
            dgCostPrice.Columns(i).ReadOnly = False
        Else
            dgCostPrice.Columns(i).ReadOnly = True
        End If
        i = i + 1 '47
        dgCostPrice_imu_ftyprcC = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "FtyPrcC"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = False
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        If mode = "UPDATE" Or mode = "ADD" Then
            dgCostPrice.Columns(i).ReadOnly = False
        Else
            dgCostPrice.Columns(i).ReadOnly = True
        End If
        i = i + 1 '48
        dgCostPrice_imu_ftyprcD = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "FtyPrcD"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = False
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        If mode = "UPDATE" Or mode = "ADD" Then
            dgCostPrice.Columns(i).ReadOnly = False
        Else
            dgCostPrice.Columns(i).ReadOnly = True
        End If
        i = i + 1 '49
        dgCostPrice_imu_ftyprcE = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "FtyPrcE"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = False
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        If mode = "UPDATE" Or mode = "ADD" Then
            dgCostPrice.Columns(i).ReadOnly = False
        Else
            dgCostPrice.Columns(i).ReadOnly = True
        End If
        i = i + 1 '50
        dgCostPrice_imu_ftyprcTran = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "FtyPrcT"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = False
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        If mode = "UPDATE" Or mode = "ADD" Then
            dgCostPrice.Columns(i).ReadOnly = False
        Else
            dgCostPrice.Columns(i).ReadOnly = True
        End If
        i = i + 1 '51
        dgCostPrice_imu_ftyprcPack = i
        If view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "FtyPrcP"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = False
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        If mode = "UPDATE" Or mode = "ADD" Then
            dgCostPrice.Columns(i).ReadOnly = False
        Else
            dgCostPrice.Columns(i).ReadOnly = True
        End If
        i = i + 1 '52
        dgCostPrice_imu_ftyprc = i
        If view = "Full" Or view = "Standard" Then
            dgCostPrice.Columns(i).HeaderText = "FtyPrc"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = True
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        If mode = "UPDATE" Or mode = "ADD" Then
            dgCostPrice.Columns(i).ReadOnly = False
        Else
            dgCostPrice.Columns(i).ReadOnly = True
        End If
        i = i + 1 '53
        dgCostPrice_imu_bomcst = i
        If view = "Standard" Or view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "BOM Cst"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = True
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '54
        dgCostPrice_imu_ttlcst = i
        If view = "Standard" Or view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "Ttl Cst"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = True
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '55
        dgCostPrice_imu_hkadjper = i
        dgCostPrice.Columns(i).Visible = False
        'If view = "Standard" Or view = "Full" Then
        '    dgCostPrice.Columns(i).HeaderText = "HK Adj%"
        '    dgCostPrice.Columns(i).Width = 50
        '    dgCostPrice.Columns(i).Visible = True
        'Else
        '    dgCostPrice.Columns(i).Visible = False
        'End If
        i = i + 1 '56
        dgCostPrice_imu_negcst = i
        dgCostPrice.Columns(i).Visible = False
        'If view = "Standard" Or view = "Full" Then
        '    dgCostPrice.Columns(i).HeaderText = "Neg Cst"
        '    dgCostPrice.Columns(i).Width = 50
        '    dgCostPrice.Columns(i).Visible = True
        'Else
        '    dgCostPrice.Columns(i).Visible = False
        'End If
        i = i + 1 '57
        dgCostPrice_imu_negprc = i
        If view = "Standard" Or view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "Neg Prc"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = True
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '58
        dgCostPrice_imu_fmlopt = i
        If view = "Standard" Or view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "Fml"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = True
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '59
        dgCostPrice_imu_bcurcde = i
        dgCostPrice.Columns(i).HeaderText = "BCurr"
        dgCostPrice.Columns(i).Width = 40
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '60
        dgCostPrice_imu_itmprc = i
        If view = "Standard" Or view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "Item Prc"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = True
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '61
        dgCostPrice_imu_bomprc = i
        If view = "Standard" Or view = "Full" Then
            dgCostPrice.Columns(i).HeaderText = "BOM Prc"
            dgCostPrice.Columns(i).Width = 50
            dgCostPrice.Columns(i).Visible = True
            dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Else
            dgCostPrice.Columns(i).Visible = False
        End If
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '62
        dgCostPrice_imu_basprc = i
        dgCostPrice.Columns(i).HeaderText = "Basic Prc"
        dgCostPrice.Columns(i).Width = 50
        dgCostPrice.Columns(i).ReadOnly = True
        dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        i = i + 1 '63
        dgCostPrice_imu_sysgen = i
        dgCostPrice.Columns(i).HeaderText = "Sys Gen"
        dgCostPrice.Columns(i).Width = 25
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '64
        dgCostPrice_imu_estprcflg = i
        dgCostPrice.Columns(i).HeaderText = "Est. Prc"
        dgCostPrice.Columns(i).Width = 25
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '65
        dgCostPrice_imu_estprcref = i
        dgCostPrice.Columns(i).HeaderText = "Est. Prc Ref No."
        dgCostPrice.Columns(i).Width = 100
        dgCostPrice.Columns(i).ReadOnly = True
        i = i + 1 '66
        dgCostPrice_imu_cft = i
        dgCostPrice.Columns(i).Visible = False
        'dgCostPrice.Columns(i).HeaderText = "Period"
        'dgCostPrice.Columns(i).Width = 100
        dgCostPrice.Columns(i).HeaderText = "CFT"
        dgCostPrice.Columns(i).Width = 50
        i = i + 1 '67
        dgCostPrice_imu_cstchgdat = i
        dgCostPrice.Columns(i).Visible = False
        i = i + 1 '68
        dgCostPrice_imu_pckunt_org = i
        dgCostPrice.Columns(i).Visible = False
        i = i + 1 '69
        dgCostPrice_imu_conftr_org = i
        dgCostPrice.Columns(i).Visible = False
        i = i + 1 '70
        dgCostPrice_imu_inrqty_org = i
        dgCostPrice.Columns(i).Visible = False
        i = i + 1 '71
        dgCostPrice_imu_mtrqty_org = i
        dgCostPrice.Columns(i).Visible = False
        i = i + 1 '72
        dgCostPrice_imu_cft_org = i
        dgCostPrice.Columns(i).Visible = False
        i = i + 1 '73
        dgCostPrice_imu_cus1no_org = i
        dgCostPrice.Columns(i).Visible = False
        i = i + 1 '74
        dgCostPrice_imu_cus2no_org = i
        dgCostPrice.Columns(i).Visible = False
        i = i + 1 '75
        dgCostPrice_imu_ftyprctrm_org = i
        dgCostPrice.Columns(i).Visible = False
        i = i + 1 '76
        dgCostPrice_imu_hkprctrm_org = i
        dgCostPrice.Columns(i).Visible = False
        i = i + 1 '77
        dgCostPrice_imu_trantrm_org = i
        dgCostPrice.Columns(i).Visible = False
        i = i + 1 '78
        dgCostPrice_imu_creusr = i
        dgCostPrice.Columns(i).Visible = False
        i = i + 1 '79
        dgCostPrice_imu_updusr = i
        dgCostPrice.Columns(i).Visible = False
        i = i + 1 '80
        dgCostPrice_imu_credat = i
        dgCostPrice.Columns(i).Visible = False
        i = i + 1 '81
        dgCostPrice_imu_upddat = i
        dgCostPrice.Columns(i).Visible = False
        i = i + 1 '82
        dgCostPrice_imu_timstp = i
        dgCostPrice.Columns(i).Visible = False

        If itmtyp = "BOM" Then
            For i = 0 To rs_IMPRCINF.Tables("RESULT").Columns.Count - 1
                Select Case i
                    Case dgCostPrice_imu_curcde
                        dgCostPrice.Columns(i).HeaderText = "F. Curr"
                        dgCostPrice.Columns(i).Width = 100
                        dgCostPrice.Columns(i).Visible = True
                        dgCostPrice.Columns(i).ReadOnly = True
                    Case dgCostPrice_imu_ftycst
                        dgCostPrice.Columns(i).HeaderText = "Fty Cost"
                        dgCostPrice.Columns(i).Width = 100
                        dgCostPrice.Columns(i).Visible = True
                        dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        If mode = "UPDATE" Or mode = "ADD" Then
                            dgCostPrice.Columns(i).ReadOnly = False
                        Else
                            dgCostPrice.Columns(i).ReadOnly = True
                        End If
                    Case dgCostPrice_imu_bcurcde
                        dgCostPrice.Columns(i).HeaderText = "P. Curr"
                        dgCostPrice.Columns(i).Width = 100
                        dgCostPrice.Columns(i).Visible = True
                        dgCostPrice.Columns(i).DisplayIndex = 33
                        dgCostPrice.Columns(i).ReadOnly = True
                    Case dgCostPrice_imu_ftyprc
                        dgCostPrice.Columns(i).HeaderText = "Fty Price"
                        dgCostPrice.Columns(i).Width = 100
                        dgCostPrice.Columns(i).Visible = True
                        dgCostPrice.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        If mode = "UPDATE" Or mode = "ADD" Then
                            dgCostPrice.Columns(i).ReadOnly = False
                        Else
                            dgCostPrice.Columns(i).ReadOnly = True
                        End If
                    Case Else
                        dgCostPrice.Columns(i).Visible = False
                End Select
            Next i
        End If
    End Sub

    Private Sub format_cboUM()
        Dim i As Integer
        cboPanPackUM.Items.Clear()
        cboPanPackUM.Items.Add("")

        Dim dr() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ = '05'")
        For i = 0 To dr.Length - 1
            cboPanPackUM.Items.Add(dr(i).Item("ysi_cde").ToString)
        Next i
    End Sub

    Private Sub comboBoxCell(ByVal dgv As DataGridView, ByVal typ As String)
        Dim cboCell As New DataGridViewComboBoxCell
        Dim iCol As Integer = dgv.CurrentCell.ColumnIndex
        Dim iRow As Integer = dgv.CurrentCell.RowIndex

        Dim row As DataGridViewRow = dgv.CurrentRow

        'dgv.Rows(iRow).Cells(iCol).ReadOnly = True

        Dim i As Integer

        Select Case typ
            Case "UM"
                cboCell.Items.Add("")
                Dim dr() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ = '05'")
                For i = 0 To dr.Length - 1
                    cboCell.Items.Add(dr(i).Item("ysi_cde").ToString)
                Next i
            Case "Vendor"
                cboCell.Items.Add("")
                For i = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                    cboCell.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensna"))
                Next i
            Case "Currency"
                cboCell.Items.Add("HKD")
                cboCell.Items.Add("USD")
                cboCell.Items.Add("CNY")
            Case "PriceTerm"
                cboCell.Items.Add("")
                Dim dr() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ = '03'")
                For i = 0 To dr.Length - 1
                    cboCell.Items.Add(dr(i).Item("ysi_cde").ToString)
                Next i
            Case "TranTerm"
                cboCell.Items.Add("")
                Dim dr() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ = '30'")
                For i = 0 To dr.Length - 1
                    cboCell.Items.Add(dr(i).Item("ysi_cde").ToString)
                Next i
            Case "BPFml"
                cboCell.Items.Add("")
                For i = 0 To rs_IMCALFML.Tables("RESULT").Rows.Count - 1
                    cboCell.Items.Add(rs_IMCALFML.Tables("RESULT").Rows(i).Item("icf_fml_hk") & " - " & rs_IMCALFML.Tables("RESULT").Rows(i).Item("icf_fml_hk_dsc"))
                Next i
            Case "Cus1no"
                Dim dr_p() As DataRow = rs_CUBASINF.Tables("RESULT").Select("cbi_cusno >= '50000' and cbi_custyp = 'P'")
                For i = 0 To dr_p.Length - 1
                    cboCell.Items.Add(dr_p(i).Item("cbi_cusno").ToString & " - " & dr_p(i).Item("cbi_cussna").ToString)
                Next i
            Case "CusnoAll"
                Dim dr_p() As DataRow = rs_CUBASINF.Tables("RESULT").Select("cbi_cusno >= '50000'")
                For i = 0 To dr_p.Length - 1
                    cboCell.Items.Add(dr_p(i).Item("cbi_cusno").ToString & " - " & dr_p(i).Item("cbi_cussna").ToString)
                Next i
            Case "Country"
                cboCell.Items.Add("")
                Dim dr() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ = '02'")
                For i = 0 To dr.Length - 1
                    cboCell.Items.Add(dr(i).Item("ysi_cde").ToString & " - " & dr(i).Item("ysi_dsc").ToString)
                Next i
            Case "PriceStatus"
                cboCell.Items.Add("ACT")
                cboCell.Items.Add("INA")
                cboCell.Items.Add("TBC")
            Case "Formula"
                Dim fml_org As String
                fml_org = dgCostPrice.Item(dgCostPrice_imu_fmlopt, iRow).Value

                Dim fml_vencde As String
                Dim fml_ventyp As String
                Dim fml_cus1no As String
                Dim fml_cus2no As String
                Dim fml_catlvl4 As String
                Dim fml_imtyp As String

                fml_vencde = dgCostPrice.Item(dgCostPrice_imu_prdven, iRow).Value
                fml_ventyp = Split(cboItmVenTyp.Text, " - ")(0)
                fml_cus1no = dgCostPrice.Item(dgCostPrice_imu_cus1no, iRow).Value
                fml_cus2no = dgCostPrice.Item(dgCostPrice_imu_cus2no, iRow).Value
                fml_catlvl4 = Split(cboCategory.Text, " - ")(0)
                If rbIMTyp_PCIM.Checked = True Then
                    fml_imtyp = "PCIM"
                Else
                    fml_imtyp = "IM"
                End If
                getformula(fml_vencde, fml_ventyp, fml_cus1no, fml_cus2no, fml_catlvl4, fml_imtyp)

                For i = 0 To tmp_calfml_hk.Items.Count - 1
                    cboCell.Items.Add(tmp_calfml_hk.Items(i).ToString)
                Next
                If cboCell.Items.IndexOf(fml_org) = -1 Then
                    cboCell.Items.Add(fml_org)
                End If
            Case "EstimatedPrice"
                cboCell.Items.Add("Y")
                cboCell.Items.Add("N")
        End Select

        'cboCell.DropDownWidth = 150
        cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox

        dgv.Rows(iRow).Cells(iCol) = cboCell
        dgv.Rows(iRow).Cells(iCol).ReadOnly = False

    End Sub


    Public Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Me.Cursor = Cursors.WaitCursor
        txtItmNo.Text = UCase(txtItmNo.Text)

        If Enq_right_local Then
            mode = "UPDATE"
        Else
            mode = "READ"
        End If

        If Trim(txtItmNo.Text) = "" Then
            MsgBox("Please input Item No.")
            txtItmNo.Focus()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_select_IMType '','" & txtItmNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMType, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdFind_Click sp_select_IMBASINF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        If rs_IMType.Tables("RESULT").Rows.Count <> 1 Then
            MsgBox("Error on loading cmdFind_Click sp_select_IMBASINF 1 :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If rs_IMType.Tables("RESULT").Rows(0).Item("IM") = "N" And rs_IMType.Tables("RESULT").Rows(0).Item("IMH") = "N" And rs_IMType.Tables("RESULT").Rows(0).Item("PCIM") = "N" And rs_IMType.Tables("RESULT").Rows(0).Item("PCIMH") = "N" Then
            MsgBox("Item not Found!")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If rs_IMType.Tables("RESULT").Rows(0).Item("IM") = "Y" Then
            Call display_ItemMaster("IM")
        ElseIf rs_IMType.Tables("RESULT").Rows(0).Item("IMH") = "Y" Then
            Call display_ItemMaster("IMH")
            mode = "READ"
        ElseIf rs_IMType.Tables("RESULT").Rows(0).Item("PCIM") = "Y" Then
            Call display_ItemMaster("PCIM")
        ElseIf rs_IMType.Tables("RESULT").Rows(0).Item("PCIMH") = "Y" Then
            Call display_ItemMaster("PCIMH")
            mode = "READ"
        End If


        If Split(cboStatus.Text, " - ")(0) = "DIS" Or Split(cboStatus.Text, " - ")(0) = "CLO" Or Split(cboStatus.Text, " - ")(0) = "HLD" Or Split(cboStatus.Text, " - ")(0) = "OLD" Then
            mode = "READ"
        End If

        formInit(mode)






        If Mid(gsUsrGrp, 1, 3) = "CED" Or Mid(gsUsrGrp, 1, 3) = "EDP" Or Mid(gsUsrGrp, 1, 3) = "MIS" Or Mid(gsUsrGrp, 1, 4) = "ECST" Or Mid(gsUsrGrp, 1, 3) = "MGT" Then
            If ((Split(cboItmVenTyp.Text, " - ")(0) = "INT" Or Split(cboItmVenTyp.Text, " - ")(0) = "JV") And gsFlgCst = 1) Or (Split(cboItmVenTyp.Text, " - ")(0) = "EXT" And gsFlgCstExt = 1) Then
                rbPriceView_F.Enabled = True
                rbPriceView_S.Enabled = True
                rbPriceView_P.Enabled = True
                rbPriceView_S.Checked = True
            Else
                rbPriceView_F.Enabled = False
                rbPriceView_S.Enabled = False
                rbPriceView_P.Enabled = True
                rbPriceView_P.Checked = True
            End If

            If mode <> "READ" Then
                If Split(cboItmTyp.Text, " - ")(0) <> "BOM" Then
                    cbDiscontinue.Enabled = True
                    cbTmpItm.Enabled = True
                Else
                    cbDiscontinue.Enabled = False
                    cbTmpItm.Enabled = False
                End If
            Else
                If Split(cboStatus.Text, " - ")(0) = "DIS" Then
                    cbDiscontinue.Enabled = True
                Else
                    cbDiscontinue.Enabled = False
                End If
                cbTmpItm.Enabled = False
            End If

            If rs_IMType.Tables("RESULT").Rows(0).Item("IMH") = "Y" Then
                cmdActivate.Enabled = True
            End If

            'cmdBatchUpdate.Enabled = True

            lblCstRmk.Visible = True
            txtCstRmk.Visible = True
        Else
            If ((Split(cboItmVenTyp.Text, " - ")(0) = "INT" Or Split(cboItmVenTyp.Text, " - ")(0) = "JV") And gsFlgCst = 1) Then
                If Mid(gsUsrGrp, 1, 5) = "SAL-S" Or Mid(gsUsrGrp, 1, 5) = "SAL-E" Or Mid(gsUsrGrp, 1, 5) = "SAL-G" Then
                    rbPriceView_F.Enabled = True
                    rbPriceView_S.Enabled = True
                    rbPriceView_P.Enabled = True
                    rbPriceView_S.Checked = True
                Else
                    rbPriceView_F.Enabled = False
                    rbPriceView_S.Enabled = False
                    rbPriceView_P.Enabled = True
                    rbPriceView_P.Checked = True
                End If
            ElseIf (Split(cboItmVenTyp.Text, " - ")(0) = "EXT" And gsFlgCstExt = 1) Then
                rbPriceView_F.Enabled = True
                rbPriceView_S.Enabled = True
                rbPriceView_P.Enabled = True
                rbPriceView_S.Checked = True
            Else
                rbPriceView_F.Enabled = False
                rbPriceView_S.Enabled = False
                rbPriceView_P.Enabled = True
                rbPriceView_P.Checked = True
            End If

            If Mid(gsUsrGrp, 1, 3) = "PKG" Then
                TabPageMain.TabPages(tabCostPrice).Enabled = False
            Else
                TabPageMain.TabPages(tabCostPrice).Enabled = True
            End If

            lblCstRmk.Visible = False
            txtCstRmk.Visible = False

            cbDiscontinue.Enabled = False
        End If

        If Split(cboItmVenTyp.Text, " - ")(0) = "EXT" Then

        Else
            If rbTier_Standard.Checked Then
                format_MOQMOA("Standard", "All")
            Else
                format_MOQMOA("ComDef", "All")
            End If

            If Split(cboItmVenTyp.Text, " - ")(0) = "EXT" Then
                rbPriceStatus_ACT.Checked = True
            End If
        End If

        'Format Primary Customer combobox based on Item Vendor Type for Customer Group
        format_cboPanCus1no()

        cbDiscontinue.Select()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub display_ItemMaster(ByVal imtype As String)
        Dim i As Integer

        Select Case imtype
            Case "IM"
                gspStr = "sp_select_IMBASINF '','" & txtItmNo.Text & "'"
            Case "IMH"
                gspStr = "sp_select_IMBASINFH '','" & txtItmNo.Text & "'"
            Case "PCIM"
                gspStr = "sp_select_IMPCBASINF '','" & txtItmNo.Text & "'"
            Case "PCIMH"
                gspStr = "sp_select_IMPCBASINFH '','" & txtItmNo.Text & "'"
            Case Else
                gspStr = ""
        End Select
        If gspStr <> "" Then
            rtnLong = execute_SQLStatement(gspStr, rs_IMBASINF, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading display_ItemMaster sp_select_IMBASINF :" & rtnStr)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        Dim sItmTyp As String
        sItmTyp = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_typ")

        If sItmTyp = "ASS" And mode = "UPDATE" Then
            Me.cmdCombineImage.Enabled = True
        End If

        Call format_TabControl(imtype, sItmTyp)

        '***********************'
        '* TAB PAGE 0 - Header *'
        '***********************'
        Dim sStatus As String
        sStatus = Split(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmsts"), " - ")(0)
        display_combo(sStatus, cboStatus)

        If sStatus = "DIS" Then
            cbDiscontinue.Checked = True
            'cbDiscontinue.Enabled = True
        Else
            cbDiscontinue.Checked = False
            'cbDiscontinue.Enabled = False
        End If

        gbIMStatus.Enabled = True
        If imtype = "IM" Or imtype = "PCIM" Or imtype = "IM_CREATE" Then
            rbIMStatus_Current.Checked = True
            rbIMStatus_Current.Enabled = True
            rbIMStatus_Current.ForeColor = Color.Blue
            rbIMStatus_History.Checked = False
            rbIMStatus_History.Enabled = False
            rbIMStatus_History.ForeColor = Color.Black
        Else
            rbIMStatus_Current.Checked = False
            rbIMStatus_Current.Enabled = False
            rbIMStatus_Current.ForeColor = Color.Black
            rbIMStatus_History.Checked = True
            rbIMStatus_History.Enabled = True
            rbIMStatus_History.ForeColor = Color.Blue
        End If

        gbIMTyp.Enabled = True
        If imtype = "IM" Or imtype = "IMH" Or imtype = "IM_CREATE" Then
            rbIMTyp_IM.Checked = True
            rbIMTyp_IM.Enabled = True
            rbIMTyp_IM.ForeColor = Color.Blue
            rbIMTyp_PCIM.Checked = False
            rbIMTyp_PCIM.Enabled = False
            rbIMTyp_PCIM.ForeColor = Color.Black
        Else
            rbIMTyp_IM.Checked = False
            rbIMTyp_IM.Enabled = False
            rbIMTyp_IM.ForeColor = Color.Black
            rbIMTyp_PCIM.Checked = True
            rbIMTyp_PCIM.Enabled = True
            rbIMTyp_PCIM.ForeColor = Color.Blue
        End If

        If rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_ftytmp") = "Y" Then
            cbTmpItm.Checked = True
        Else
            cbTmpItm.Checked = False
        End If

        display_combo(sItmTyp, cboItmTyp)

        '**********************************'
        '* TAB PAGE 1 - Basic Information *'
        '**********************************'
        txtItmdsc.Text = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_engdsc")
        txtEngDsc.Text = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_engdsc")
        txtChnDsc.Text = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_chndsc")
        txtItmRmk.Text = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_rmk")

        Select Case imtype
            Case "IM"
                gspStr = "sp_select_IMCOLINF '','" & txtItmNo.Text & "'"
            Case "IMH"
                gspStr = "sp_select_IMCOLINFH '','" & txtItmNo.Text & "'"
            Case Else
                gspStr = ""
        End Select
        If gspStr <> "" Then
            rtnLong = execute_SQLStatement(gspStr, rs_IMCOLINF, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading display_ItemMaster sp_select_IMCOLINF :" & rtnStr)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If
        display_dgColor("IM")



        Select Case imtype
            Case "IM"
                gspStr = "sp_select_IMPCKINF '','" & txtItmNo.Text & "'"
            Case "IMH"
                gspStr = "sp_select_IMPCKINFH '','" & txtItmNo.Text & "'"
            Case "PCIM"
                gspStr = "sp_select_IMPCPCKINF '','" & txtItmNo.Text & "'"
            Case "PCIMH"
                gspStr = "sp_select_IMPCPCKINFH '','" & txtItmNo.Text & "'"
            Case Else
                gspStr = "sp_select_IMPCKINF '',''"
        End Select
        rtnLong = execute_SQLStatement(gspStr, rs_IMPCKINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading display_ItemMaster sp_select_IMPCKINF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        For i = 0 To rs_IMPCKINF.Tables("RESULT").Columns.Count - 1
            rs_IMPCKINF.Tables("RESULT").Columns(i).ReadOnly = False
        Next i

        Dim tmpString As String

        For i = 0 To rs_IMPCKINF.Tables("RESULT").Rows.Count - 1
            tmpString = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cft")
            rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cft") = Str(tmpString)
            tmpString = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cbm")
            rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cbm") = Str(tmpString)
            tmpString = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_grswgt")
            rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_grswgt") = Str(tmpString)
            tmpString = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_netwgt")
            rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_netwgt") = Str(tmpString)

            rs_IMPCKINF.Tables("RESULT").Rows(i).Item("inner_in") = Replace(Str(Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("inner_in"), "x")(0)) & "x" & _
                                                                        Str(Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("inner_in"), "x")(1)) & "x" & _
                                                                        Str(Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("inner_in"), "x")(2)), " ", "")
            rs_IMPCKINF.Tables("RESULT").Rows(i).Item("inner_cm") = Replace(Str(Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("inner_cm"), "x")(0)) & "x" & _
                                                                        Str(Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("inner_cm"), "x")(1)) & "x" & _
                                                                        Str(Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("inner_cm"), "x")(2)), " ", "")
            rs_IMPCKINF.Tables("RESULT").Rows(i).Item("master_in") = Replace(Str(Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("master_in"), "x")(0)) & "x" & _
                                                                        Str(Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("master_in"), "x")(1)) & "x" & _
                                                                        Str(Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("master_in"), "x")(2)), " ", "")
            rs_IMPCKINF.Tables("RESULT").Rows(i).Item("master_cm") = Replace(Str(Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("master_cm"), "x")(0)) & "x" & _
                                                                        Str(Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("master_cm"), "x")(1)) & "x" & _
                                                                        Str(Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("master_cm"), "x")(2)), " ", "")
        Next i
        display_dgPacking("IM")

        '***********************'
        '* TAB PAGE 2 - Vendor *'
        '***********************'
        Select Case imtype
            Case "IM"
                gspStr = "sp_select_IMVENINF '','" & txtItmNo.Text & "'"
            Case "IMH"
                gspStr = "sp_select_IMVENINFH '','" & txtItmNo.Text & "'"
            Case Else
                gspStr = "sp_select_IMVENINF '',''"
        End Select
        rtnLong = execute_SQLStatement(gspStr, rs_IMVENINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading display_ItemMaster sp_select_IMVENINF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        display_dgPV("IM")

        display_combo(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_venno"), cboDV)
        display_combo(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_cusven"), cboCV)
        display_combo(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_tradeven"), cboTV)
        display_combo(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_examven"), cboEV)


        ' Determine Image Path and display on Tab 1 - Basic Information
        Dim sImagePath As String
        sImagePath = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_imgpth")
        If sImagePath <> "" Then
            Try
                pbImage.Load(sImagePath)
                pbImage2.Load(sImagePath)
            Catch ex As Exception

            End Try
        Else
            Dim sDirectory As String

            Dim drIMBASINF() As DataRow = rs_IMBASINF.Tables("RESULT").Select("ibi_itmno = '" & Trim(txtItmNo.Text) & "'")
            If drIMBASINF.Length > 0 Then
                Dim drVNBASINF() As DataRow = rs_VNBASINF.Tables("RESULT").Select("vbi_venno = '" & drIMBASINF(0).Item("ibi_venno") & "'")

                If drVNBASINF.Length > 0 Then
                    If drVNBASINF(0).Item("vbi_ventyp").ToString = "I" Or drVNBASINF(0).Item("vbi_ventyp").ToString = "J" Then
                        ' Internal and Joint Venture
                        sDirectory = "\\Uchkimgsrv\guest-share\ucppc\itemimg\" & revisedItmno(drIMBASINF(0).Item("ibi_lnecde").ToString)
                        sImagePath = sDirectory & "\" & revisedItmno(Trim(txtItmNo.Text)) & ".JPG"
                    Else
                        ' External
                        Dim drIMVENINF() As DataRow = rs_IMVENINF.Tables("RESULT").Select("ivi_itmno = '" & Trim(txtItmNo.Text) & "' and ivi_def = 'Y'")
                        sDirectory = "\\Uchkimgsrv\guest-share\ucp\itemimg\" & revisedItmno(drIMVENINF(0).Item("ivi_venno").ToString)
                        sImagePath = sDirectory & "\" & revisedItmno(drIMVENINF(0).Item("ivi_venitm")) & "_" & drIMVENINF(0).Item("ivi_venno") & ".JPG"
                    End If

                    Try
                        pbImage.Load(sImagePath)
                        pbImage2.Load(sImagePath)
                    Catch ex As Exception

                    End Try
                End If
            End If
        End If

        '************************'
        '* TAB PAGE 3 - BOM ASS *'
        '************************'
        Select Case imtype
            Case "IM"
                gspStr = "sp_select_IMBOMASS '','" & txtItmNo.Text & "'"
            Case "IMH"
                gspStr = "sp_select_IMBOMASSH '','" & txtItmNo.Text & "'"
                '                Case "PCIM"
                '                    gspStr = "sp_select_IMPCBOMASS '','" & txtItmNo.Text & "'"
                '                Case "PCIMH"
                '                    gspStr = "sp_select_IMPCBOMASSH '','" & txtItmNo.Text & "'"
            Case Else
                gspStr = "sp_select_IMBOMASS '',''"
        End Select
        rtnLong = execute_SQLStatement(gspStr, rs_IMBOMASS, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading display_ItemMaster sp_select_IMBOMASS :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        rs_IMBOMASS_old = rs_IMBOMASS.Copy()

        If sItmTyp = "BOM" Or sItmTyp = "REG" Then
            Select Case imtype
                Case "IM"
                    gspStr = "sp_list_IMR00021 '','" & txtItmNo.Text & "','" & sItmTyp & "','BOTH'"
                Case "IMH"
                    gspStr = "sp_list_IMR00021 '','" & txtItmNo.Text & "','" & sItmTyp & "','BOTH'"
                Case "PCIM"
                    gspStr = "sp_list_IMR00021 '','" & txtItmNo.Text & "','" & sItmTyp & "','BOTH'"
                Case "PCIMH"
                    gspStr = "sp_list_IMR00021 '','" & txtItmNo.Text & "','" & sItmTyp & "','BOTH'"
                Case Else
                    gspStr = ""
            End Select
            If gspStr <> "" Then
                rtnLong = execute_SQLStatement(gspStr, rs_IMR00021, rtnStr)
                display_dgRelParentItem()
            End If
        End If


        '*******************************'
        '* TAB PAGE 4 - Classification *'
        '*******************************'
        display_cboItmVenTyp(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_venno"))
        display_combo(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_prdtyp"), cboPrdTyp)
        display_combo(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmnat"), cboItmNature)
        txtDsgItmNo.Text = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_dsgno")
        display_combo(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_material"), cboMaterial)
        display_combo(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_prdsizeTyp"), cboPrdSizeTyp)
        display_combo(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_prdsizeUnt"), cboPrdSizeUnit)
        txtPrdSizeValue.Text = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_prdsizeVal")
        display_combo(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_prdgrp"), cboPrdGroup)
        display_combo(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_prdicon"), cboPrdIcon)
        display_combo(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_season"), cboSeason)
        display_combo(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_devteam"), cboDevTeam)
        display_combo(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_designer"), cboDesigner)


        cboPrdLne.Text = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_lnecde")
        'display_combo(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_lnecde"), cboPrdLne)
        display_combo(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_catlvl4"), cboCategory)

        Select Case imtype
            Case "IM"
                gspStr = "sp_select_IMCUSNO '','" & txtItmNo.Text & "'"
            Case "IMH"
                gspStr = "sp_select_IMCUSNOH '','" & txtItmNo.Text & "'"
            Case Else
                gspStr = "sp_select_IMCUSNO '',''"
        End Select
        rtnLong = execute_SQLStatement(gspStr, rs_IMCUSNO, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading display_ItemMaster sp_select_IMCUSNO :" & rtnStr)
            Exit Sub
        End If
        display_dgOEMCustomer("IM")


        If sItmTyp = "ASS" Then
            rbBOMASS_ASS.Checked = True
            display_dgBOMASS("IM", "ASS")
        Else
            rbBOMASS_BOM.Checked = True
            display_dgBOMASS("IM", "BOM")
        End If

        '*******************************'
        '* TAB PAGE 5 - Price Cost *'
        '*******************************'
        Select Case imtype
            Case "IM"
                gspStr = "sp_select_IMCSTINF '','" & txtItmNo.Text & "'"
            Case "IMH"
                gspStr = "sp_select_IMCSTINFH '','" & txtItmNo.Text & "'"
            Case Else
                gspStr = "sp_select_IMCSTINF '',''"
        End Select
        If gspStr <> "" Then
            rtnLong = execute_SQLStatement(gspStr, rs_IMCSTINF, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading display_ItemMaster sp_select_IMCSTINF :" & rtnStr)
                Exit Sub
            End If
        End If

        If rs_IMCSTINF.Tables("RESULT").Rows.Count = 1 Then
            txtCstRmk.Text = rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_cstrmk")
            txtCstExpDat.Text = rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_expdat")
        End If


        Select Case imtype
            Case "IM"
                gspStr = "sp_select_IMPRCINF '','" & txtItmNo.Text & "'"
            Case "IMH"
                gspStr = "sp_select_IMPRCINFH '','" & txtItmNo.Text & "'"
            Case "PCIM"
                gspStr = "sp_select_IMPCPRCINF '','" & txtItmNo.Text & "'"
            Case "PCIMH"
                gspStr = "sp_select_IMPCPRCINFH '','" & txtItmNo.Text & "'"
            Case Else
                gspStr = "sp_select_IMPRCINF '',''"
        End Select
        rtnLong = execute_SQLStatement(gspStr, rs_IMPRCINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading display_ItemMaster sp_select_IMPRCINF :" & rtnStr)
            Exit Sub
        End If

        If sItmTyp = "BOM" Then
            gbPriceView.Visible = False
            rbPriceView_P.Checked = True
            lblPriceStatus.Visible = False
            gbPriceStatus.Visible = False
            rbPriceStatus_All.Checked = True
        Else
            gbPriceView.Visible = True
            rbPriceView_P.Checked = True
            lblPriceStatus.Visible = True
            gbPriceStatus.Visible = True
            rbPriceStatus_All.Checked = True
        End If

        For i = 0 To rs_IMPRCINF.Tables("RESULT").Columns.Count - 1
            rs_IMPRCINF.Tables("RESULT").Columns(i).ReadOnly = False
        Next i

        For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cft")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_packing") = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_pckunt") & " / " & _
                                                                        rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_inrqty") & " / " & _
                                                                        rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_mtrqty") & " / " & _
                                                                        Replace(Str(tmpString), " .", "0.")
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycst")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycst") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstA")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstA") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstB")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstB") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstC")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstC") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstD")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstD") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstE")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstE") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstTran")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstTran") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstPack")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstPack") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfp")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfp") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpA")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpA") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpB")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpB") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpC")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpC") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpD")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpD") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpE")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpE") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpTran")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpTran") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpPack")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpPack") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprc")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprc") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcA")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcA") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcB")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcB") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcC")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcC") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcD")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcD") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcE")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcE") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcTran")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcTran") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcPack")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcPack") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_bomcst")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_bomcst") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ttlcst")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ttlcst") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_negcst")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_negcst") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_negprc")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_negprc") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_itmprc")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_itmprc") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_bomprc")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_bomprc") = Str(tmpString)
            tmpString = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_basprc")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_basprc") = Str(tmpString)
            Dim tmpDate As DateTime
            tmpDate = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_effdat")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_effdat") = tmpDate.Date
            tmpDate = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_expdat")
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_expdat") = tmpDate.Date
        Next i

        display_dgCostPrice("IM", "PriceOnly")
        'display_dgCostPrice("IM", "Full")

        '***************************************'
        '* TAB PAGE 6 - Additional Information *'
        '***************************************'
        Select Case imtype
            Case "IM"
                gspStr = "sp_select_IMCTYINF '','" & txtItmNo.Text & "'"
            Case "IMH"
                gspStr = "sp_select_IMCTYINFH '','" & txtItmNo.Text & "'"
            Case Else
                gspStr = "sp_select_IMCTYINF '',''"
        End Select
        rtnLong = execute_SQLStatement(gspStr, rs_IMCTYINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading display_ItemMaster sp_select_IMCTYINF :" & rtnStr)
            Exit Sub
        End If
        display_dgExclCustomer("IM")


        Select Case imtype
            Case "IM"
                gspStr = "sp_select_IMCUSSTY '','" & txtItmNo.Text & "'"
            Case "IMH"
                gspStr = "sp_select_IMCUSSTY '','" & txtItmNo.Text & "'"
            Case Else
                gspStr = "sp_select_IMCUSSTY '',''"
        End Select
        rtnLong = execute_SQLStatement(gspStr, rs_IMCUSSTY, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading display_ItemMaster sp_select_IMCUSSTY :" & rtnStr)
            Exit Sub
        End If
        display_dgCusStyle("IM")

        Select Case imtype
            Case "IM"
                gspStr = "sp_select_IMMATBKD '','" & txtItmNo.Text & "'"
            Case "IMH"
                gspStr = "sp_select_IMMATBKDH '','" & txtItmNo.Text & "'"
            Case Else
                gspStr = "sp_select_IMMATBKD '',''"
        End Select
        rtnLong = execute_SQLStatement(gspStr, rs_IMMATBKD, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading display_ItemMaster sp_select_IMMATBKD :" & rtnStr)
            Exit Sub
        End If
        display_dgMatBreakdown("IM")

        display_combo(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_cosmth"), cboConstrMethod)

        gbMOQMOA.Enabled = True
        Dim tiertyp As String
        tiertyp = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_tirtyp")
        If tiertyp = 1 Then
            rbTier_Standard.Checked = True
            rbTier_Standard.Enabled = True
            rbTier_Standard.ForeColor = Color.Blue
            rbTier_CompDef.Checked = False
            rbTier_CompDef.Enabled = True
            rbTier_CompDef.ForeColor = Color.Black
        Else
            rbTier_Standard.Checked = False
            rbTier_Standard.Enabled = True
            rbTier_Standard.ForeColor = Color.Black
            rbTier_CompDef.Checked = True
            rbTier_CompDef.Enabled = True
            rbTier_CompDef.ForeColor = Color.Blue
        End If

        cboMOQUM.Text = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_moqunttyp")
        cboMOACurr.Enabled = False
        cboMOACurr.Text = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_curcde")

        txtMOQQty.Text = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_moqctn")
        txtMOAAmt.Text = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_moa")
        txtPerMultQty.Text = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_qty")

        txtAlsitmno.Text = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_alsitmno")
        txtAlsitmcol.Text = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_alscolcde")

        display_combo(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_hamusa"), cboHstuUSA)
        txtHstuUSADuty.Text = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_dtyusa")
        display_combo(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_hameur"), cboHstuEur)

        txtHstuUSADuty.Text = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_dtyusa")
        txtHstuEURDuty.Text = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_dtyeur")

        txtWastage.Text = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_wastage")

        If rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_addreq_forma") = "Y" Then
            cbAddreq_formA.Checked = True
        Else
            cbAddreq_formA.Checked = False
        End If

        If rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_addreq_ccbi") = "Y" Then
            cbAddreq_ccib.Checked = True
        Else
            cbAddreq_ccib.Checked = False
        End If

        If rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_addreq_ster") = "Y" Then
            cbAddreq_ster.Checked = True
        Else
            cbAddreq_ster.Checked = False
        End If

        gspStr = "sp_select_IMTMPREL '','" & txtItmNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMTMPREL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading display_ItemMaster sp_select_IMTMPREL :" & rtnStr)
            Exit Sub
        End If
        display_dgTempItem()

        If rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_ftytmp") <> "Y" And rs_IMTMPREL.Tables("RESULT").Rows.Count > 0 Then
            txtTmpItmNo.Text = rs_IMTMPREL.Tables("RESULT").Rows(0).Item("itr_tmpitm")

        End If

        rs_IMMOQMOA = Nothing
        gspStr = "sp_select_IMMOQMOA '','" & txtItmNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMMOQMOA, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading display_ItemMaster sp_select_IMMOQMOA :" & rtnStr)
            Exit Sub
        End If
        rs_IMMOQMOA_old = rs_IMMOQMOA.Copy()
        display_dgMOQMOA()

        If mode = "UPDATE" Or mode = "ADD" Then
            rs_IMBASINF.Tables("RESULT").Columns("ibi_creusr").ReadOnly = False
            rs_IMCOLINF.Tables("RESULT").Columns("icf_creusr").ReadOnly = False
            rs_IMPCKINF.Tables("RESULT").Columns("ipi_creusr").ReadOnly = False
            rs_IMVENINF.Tables("RESULT").Columns("ivi_creusr").ReadOnly = False
            rs_IMCUSNO.Tables("RESULT").Columns("icn_creusr").ReadOnly = False
            rs_IMBOMASS.Tables("RESULT").Columns("iba_creusr").ReadOnly = False
            rs_IMPRCINF.Tables("RESULT").Columns("imu_creusr").ReadOnly = False
            rs_IMCSTINF.Tables("RESULT").Columns("ici_creusr").ReadOnly = False
            rs_IMCTYINF.Tables("RESULT").Columns("ici_creusr").ReadOnly = False
            rs_IMMATBKD.Tables("RESULT").Columns("ibm_creusr").ReadOnly = False
            rs_IMCUSSTY.Tables("RESULT").Columns("ics_creusr").ReadOnly = False
            rs_IMMOQMOA.Tables("RESULT").Columns("imm_creusr").ReadOnly = False
        End If

        Dim tmpcredat As DateTime
        Dim tmpupddat As DateTime

        tmpcredat = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_credat")
        tmpupddat = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_upddat")

        Me.StatusBarPanel2.Text = tmpcredat.Date & " " & tmpupddat.Date & " " & rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_updusr")

    End Sub

    Private Sub display_cboItmVenTyp(ByVal ven As String)
        Dim dr() As DataRow = rs_VNBASINF.Tables("RESULT").Select("vbi_venno = '" & ven & "'")
        If dr.Length = 1 Then
            Dim ventyp As String
            ventyp = dr(0).Item("vbi_ventyp").ToString

            Select Case ventyp
                Case "I"
                    ventyp = "INT"
                Case "J"
                    ventyp = "JV"
                Case "E"
                    ventyp = "EXT"
            End Select

            display_combo(ventyp, cboItmVenTyp)
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Dim tmp_itmno As String

        If Recordstatus = True Then
            Select Case MsgBox("Record has been modified. Do you want to save before clear the screen?", MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    If Enq_right_local Then
                        Call cmdSave_Click(sender, e)
                    Else
                        MsgBox("You have no Save record rights!")
                    End If
                    Me.Cursor = Cursors.Default
                Case MsgBoxResult.No
                    tmp_itmno = txtItmNo.Text
                    formInit("INIT")
                    txtItmNo.Text = tmp_itmno
                    txtItmNo.Select()
                    Me.Cursor = Cursors.Default
            End Select
        Else
            tmp_itmno = txtItmNo.Text
            formInit("INIT")
            txtItmNo.Text = tmp_itmno
            txtItmNo.Select()
            Me.Cursor = Cursors.Default
        End If

    End Sub



    Private Sub txtItmNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItmNo.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            Call cmdFind_Click(sender, e)
        End If
    End Sub

    Private Sub rbPriceView_P_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPriceView_P.CheckedChanged
        If rbPriceView_P.Checked = True Then
            display_dgCostPrice("IM", "PriceOnly")
        End If
    End Sub

    Private Sub rbPriceView_F_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPriceView_F.CheckedChanged
        If rbPriceView_F.Checked = True Then
            display_dgCostPrice("IM", "Full")
        End If
    End Sub

    Private Sub rbPriceView_S_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPriceView_S.CheckedChanged
        If rbPriceView_S.Checked = True Then
            display_dgCostPrice("IM", "Standard")
        End If
    End Sub


    Private Sub cbTmpItm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTmpItm.CheckedChanged
        'If MsgBox("Are you sure to change TEMP ITEM type for this item?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            Dim ftytmpflag As String
            If cbTmpItm.Checked Then
                ftytmpflag = "Y"
            Else
                ftytmpflag = "N"
            End If

            If mode = "UPDATE" Then
                If ftytmpflag <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_ftytmp") Then
                    Recordstatus = True
                    rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                End If
            End If
        End If
        'End If
    End Sub

    Private Sub txtEngDsc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEngDsc.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
            rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
        End If
    End Sub

    Private Sub txtChnDsc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtChnDsc.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
            rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
        End If
    End Sub

    Private Sub txtItmRmk_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItmRmk.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
            rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
        End If
    End Sub

    Private Sub dgColor_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgColor.CellDoubleClick
        If mode = "READ" Then
            Exit Sub
        End If

        If dgColor.RowCount > 0 Then
            Dim iCol As Integer = dgColor.CurrentCell.ColumnIndex
            Dim iRow As Integer = dgColor.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = dgColor.CurrentCell.Value

            If dgColor.CurrentCell.ColumnIndex = dgColor_icf_cocde Then
                If Trim(curvalue) = "" Then
                    Dim i As Integer
                    Dim counter As Integer
                    counter = 0
                    For i = 0 To dgColor.RowCount - 1
                        If Trim(dgColor.Item(dgColor_icf_cocde, i).Value) = "" Then
                            counter = counter + 1
                        End If
                    Next i

                    If counter = 1 Then
                        MsgBox("At least one color must exist!")
                        Exit Sub
                    Else
                        dgColor.Item(dgColor_icf_cocde, iRow).Value = "Y"
                    End If
                Else
                    dgColor.Item(dgColor_icf_cocde, iRow).Value = ""
                End If

                If dgColor.Item(dgColor_icf_creusr, iRow).Value <> "~*ADD*~" Then
                    dgColor.Item(dgColor_icf_creusr, iRow).Value = "~*UPD*~"
                    Recordstatus = True
                End If

            End If
        End If

    End Sub

    Private Sub dgColor_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgColor.CellValidating
        Dim row As DataGridViewRow = dgColor.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then
            Select Case e.ColumnIndex
                Case dgColor_icf_colcde
                    For Each drr As DataGridViewRow In dgColor.Rows
                        If drr.Index <> e.RowIndex Then
                            If drr.Cells("icf_colcde").Value.ToString.ToUpper = strNewVal.ToUpper Then
                                MsgBox("Duplicated Color item!")
                                e.Cancel = True
                                Exit For
                            End If
                        End If
                    Next
                Case dgColor_icf_ucpcde
                    If Len(strNewVal) > 13 Then
                        MsgBox("UPC Code max length is 13 digits!")
                        e.Cancel = True
                    End If
                Case dgColor_icf_eancde
                    If Len(strNewVal) > 14 Then
                        MsgBox("EAN Code max length is 14 digits!")
                        e.Cancel = True
                    End If
            End Select

        End If
    End Sub

    Private Sub dgColor_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgColor.EditingControlShowing
        If dgColor.RowCount = 0 Then
            Exit Sub
        End If

        e.CellStyle.BackColor = Color.White

        Select Case dgColor.CurrentCell.ColumnIndex
            Case dgColor_icf_vencol
                Dim txtbox_dgColor As TextBox = CType(e.Control, TextBox)
                If Not (txtbox_dgColor Is Nothing) Then
                    AddHandler txtbox_dgColor.KeyUp, AddressOf txtbox_dgColor_KeyUp
                End If
            Case dgColor_icf_ucpcde, dgColor_icf_eancde
                Dim txtbox_dgColor As TextBox = CType(e.Control, TextBox)
                If Not (txtbox_dgColor Is Nothing) Then
                    AddHandler txtbox_dgColor.KeyPress, AddressOf txtbox_dgColor_KeyPress
                End If
        End Select

        If mode = "UPDATE" Or mode = "ADD" Then
            Recordstatus = True
            If dgColor.Item(dgColor_icf_creusr, dgColor.CurrentCell.RowIndex).Value <> "~*ADD*~" Then
                dgColor.Item(dgColor_icf_creusr, dgColor.CurrentCell.RowIndex).Value = "~*UPD*~"
            End If
        End If
    End Sub

    Private Sub txtbox_dgColor_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If dgColor.CurrentCell.ColumnIndex = dgColor_icf_vencol Then
            dgColor.Item(dgColor_icf_colcde, dgColor.CurrentCell.RowIndex).Value = dgColor.CurrentCell.EditedFormattedValue
        End If
    End Sub
    Private Sub txtbox_dgColor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim iRow As Integer = dgColor.CurrentCell.RowIndex
        Dim iCol As Integer = dgColor.CurrentCell.ColumnIndex

        Dim curvalue As String = dgColor.CurrentCell.EditedFormattedValue

        Select Case dgColor.CurrentCell.ColumnIndex
            Case dgColor_icf_ucpcde, dgColor_icf_eancde
                If Not (e.KeyChar = vbBack Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
                    e.KeyChar = ""
                End If
        End Select
    End Sub
    Private Function checkTimeStamp() As Boolean
        Dim save_timestamp As Long
        Dim curr_timestamp As Long

        gspStr = "sp_select_IMBASINF '','" & txtItmNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading checkTimeStamp sp_select_IMBASINF :" & rtnStr)
            Exit Function
        End If

        save_timestamp = rs.Tables("RESULT").Rows(0).Item("ibi_timstp")
        curr_timestamp = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_timstp")

        If save_timestamp <> curr_timestamp Then
            checkTimeStamp = False
        Else
            checkTimeStamp = True
        End If

    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If Recordstatus = False Then
            MsgBox("No update for the item, item not saved!")
            Exit Sub
        End If

        If PanelAdd.Visible = True Then
            MsgBox("Item in Add Panel Process, item not saved!")
            Exit Sub
        End If

        If PanelCopy.Visible = True Then
            MsgBox("Item in Copy Panel Process, item not saved!")
            Exit Sub
        End If

        If PanelPacking.Visible = True Then
            MsgBox("Item in Packing Panel Process, item not saved!")
            Exit Sub
        End If

        If PanelCostPrice.Visible = True Then
            MsgBox("Item in Cost Price Panel Process, item not saved!")
            Exit Sub
        End If

        If mode = "UPDATE" Then
            If checkTimeStamp() = False Then
                MsgBox("The record has been modified by other users, please clear and try again.")
                Exit Sub
            End If
        End If


        'check before save
        'Save IMBASINF
        If check_ItemMaster() = False Then
            Exit Sub
        End If

        Dim i As Integer

        If mode = "ADD" Then
            Dim dv As String
            dv = Split(cboDV.Text, " - ")(0)
            If dv = "" Then
                MsgBox("Design Vendor cannot empty!")
                Exit Sub
            End If
            'If Not (dv >= "0001" And dv <= "9999") Then
            '    MsgBox("Only for Design Vendor 0001 to 9999 can be created!")
            '    Exit Sub
            'End If

            'Assign Item Number
            If txtItmNo.Text = "" Then
                If Split(cboItmVenTyp.Text, " - ")(0) = "EXT" Then
                    gspStr = "sp_select_ITEMNO_UCP '','','','" & Split(cboDV.Text, " - ")(0) & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_itmno_generation, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading cmdSave_Click sp_select_ITEMNO_UCP :" & rtnStr)
                        Exit Sub
                    End If

                    txtItmNo.Text = rs_itmno_generation.Tables("RESULT").Rows(0).Item("Max_itmno")
                Else
                    txtItmNo.Text = rs_IMVENINF.Tables("RESULT").Rows(0).Item("ivi_venitm")
                End If
            End If

            rs_IMBASINF.Tables("RESULT").Columns("ibi_itmno").ReadOnly = False
            rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmno") = txtItmNo.Text

            rs_IMCOLINF.Tables("RESULT").Columns("icf_itmno").ReadOnly = False
            rs_IMCOLINF.Tables("RESULT").Rows(0).Item("icf_itmno") = txtItmNo.Text

            For i = 0 To rs_IMPCKINF.Tables("RESULT").Rows.Count - 1
                rs_IMPCKINF.Tables("RESULT").Columns("ipi_itmno").ReadOnly = False
                rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_itmno") = txtItmNo.Text
            Next i

            For i = 0 To rs_IMVENINF.Tables("RESULT").Rows.Count - 1
                rs_IMVENINF.Tables("RESULT").Columns("ivi_itmno").ReadOnly = False
                rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_itmno") = txtItmNo.Text
            Next i

            For i = 0 To rs_IMCUSNO.Tables("RESULT").Rows.Count - 1
                rs_IMCUSNO.Tables("RESULT").Columns("icn_itmno").ReadOnly = False
                rs_IMCUSNO.Tables("RESULT").Rows(i).Item("icn_itmno") = txtItmNo.Text
            Next i

            For i = 0 To rs_IMBOMASS.Tables("RESULT").Rows.Count - 1
                rs_IMBOMASS.Tables("RESULT").Columns("iba_itmno").ReadOnly = False
                rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_itmno") = txtItmNo.Text
            Next i

            For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
                rs_IMPRCINF.Tables("RESULT").Columns("imu_itmno").ReadOnly = False
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_itmno") = txtItmNo.Text
            Next i

            If rs_IMCSTINF.Tables("RESULT").Rows.Count = 1 Then
                rs_IMCSTINF.Tables("RESULT").Columns("ici_itmno").ReadOnly = False
                rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_itmno") = txtItmNo.Text
            End If

            For i = 0 To rs_IMCTYINF.Tables("RESULT").Rows.Count - 1
                rs_IMCTYINF.Tables("RESULT").Columns("ici_itmno").ReadOnly = False
                rs_IMCTYINF.Tables("RESULT").Rows(i).Item("ici_itmno") = txtItmNo.Text
            Next i

            For i = 0 To rs_IMMATBKD.Tables("RESULT").Rows.Count - 1
                rs_IMMATBKD.Tables("RESULT").Columns("ibm_itmno").ReadOnly = False
                rs_IMMATBKD.Tables("RESULT").Rows(i).Item("ibm_itmno") = txtItmNo.Text
            Next i

            For i = 0 To rs_IMMOQMOA.Tables("RESULT").Rows.Count - 1
                rs_IMMOQMOA.Tables("RESULT").Columns("imm_itmno").ReadOnly = False
                rs_IMMOQMOA.Tables("RESULT").Rows(i)("imm_itmno") = txtItmNo.Text
            Next
        End If

        'check for Item Status
        rs_IMBASINF.Tables("RESULT").Columns("ibi_itmsts").ReadOnly = False
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmsts") = Split(cboStatus.Text, " - ")(0)

        Dim sItmSts As String
        sItmSts = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmsts")


        If sItmSts = "INC" Or sItmSts = "CMP" Or sItmSts = "TBC" Then
            Dim sItmSts_new As String = check_ItemStatus(Split(cboItmTyp.Text, " - ")(0))
            If sItmSts <> sItmSts_new Then
                display_combo(sItmSts_new, cboStatus)
				rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmsts") = sItmSts_new
                If rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") <> "~*ADD*~" Then
                    rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                End If
            End If
        End If


        If Recordstatus = True Then
            If rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") <> "~*ADD*~" Then
                rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
            End If
        End If

        If save_ItemMaster() = True Then
            MsgBox("Record Saved!")
        Else
            MsgBox("Error during save, please check!")
            Exit Sub
        End If

        Dim tmp_itmno As String
        tmp_itmno = txtItmNo.Text
        mode = "INIT"
        formInit(mode)
        txtItmNo.Text = tmp_itmno
        txtItmNo.Select()
        Me.Cursor = Cursors.Default
    End Sub


    Private Function check_ItemStatus(ByVal itmtyp As String) As String
        check_ItemStatus = ""
        Dim i As Integer

        Dim check_Color As Boolean
        Dim check_Packing As Boolean
        Dim check_Price As Boolean
        Dim check_Tier As Boolean

        '1. Check Color
        If rs_IMCOLINF.Tables("RESULT").Rows.Count > 0 Then
            check_Color = False
            For i = 0 To rs_IMCOLINF.Tables("RESULT").Rows.Count - 1
                If rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_cocde") <> "Y" Then
                    check_Color = True
                    Exit For
                End If
            Next i
        Else
            check_Color = False
        End If

        '2. Check Packing
        If rs_IMPCKINF.Tables("RESULT").Rows.Count > 0 Then
            check_Packing = False
            For i = 0 To rs_IMPCKINF.Tables("RESULT").Rows.Count - 1
                If rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cocde") <> "Y" Then
                    check_Packing = True
                    Exit For
                End If
            Next i
        Else
            check_Packing = False
        End If

        '3. Check Price
        If itmtyp = "BOM" Then
            'BOM Item
            If rs_IMPRCINF.Tables("RESULT").Rows.Count = 1 Then
                If rs_IMPRCINF.Tables("RESULT").Rows(0).Item("imu_ftyprc") = 0 Then
                    check_Price = False
                Else
                    check_Price = True
                End If
            Else
                check_Price = False
            End If
        Else
            'REG, ASS Item
            If rs_IMPRCINF.Tables("RESULT").Rows.Count > 0 Then
                check_Price = False
                For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
                    If rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cocde") <> "Y" And _
                        rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_status") = "ACT" Then
                        check_Price = True
                        Exit For
                    End If
                Next i
            Else
                check_Price = False
            End If
        End If

        '4. Check Tier
        check_Tier = False
        Dim moqmoa As String
        Dim tmp As Decimal

        If Split(cboItmVenTyp.Text, " - ")(0) = "EXT" Then
            If itmtyp = "BOM" Then
                check_Tier = True
            Else
                Dim dr_MOQMOA() As DataRow
                Dim dr_IMPRCINF() As DataRow = rs_IMPRCINF.Tables("RESULT").Select("imu_cocde <> 'Y'")

                If dr_IMPRCINF.Length > 0 Then
                    check_Tier = True

                    For j As Integer = 0 To dr_IMPRCINF.Length - 1
                        dr_MOQMOA = Nothing
                        dr_MOQMOA = rs_IMMOQMOA.Tables("RESULT").Select("imm_itmno = '" & dr_IMPRCINF(j).Item("imu_itmno") & "' and " & _
                                                                        "imm_cus1no = '" & dr_IMPRCINF(j).Item("imu_cus1no") & "' and " & _
                                                                        "imm_cus2no = '" & dr_IMPRCINF(j).Item("imu_cus2no") & "' and " & _
                                                                        "imm_status <> 'Y'")
                        If dr_MOQMOA.Length = 0 Then
                            check_Tier = False
                            MsgBox("Missing MOQ / MOA", MsgBoxStyle.Information, "IMM00001 - Missing MOQ / MOA")
                            Exit For
                        End If
                    Next
                End If
            End If
        Else
            If rbTier_CompDef.Checked Then
                If IsNumeric(txtMOQQty.Text) Then
                    tmp = txtMOQQty.Text
                    If tmp <> 0 Then
                        moqmoa = "MOQ"
                    Else
                        moqmoa = "MOA"
                    End If
                Else
                    moqmoa = "MOA"
                End If

                If moqmoa = "MOQ" Then
                    If txtMOQQty.Text = 0 Or txtMOQQty.Text = "" Or cboMOQUM.Text = "" Then
                        check_Tier = False
                    Else
                        check_Tier = True
                    End If
                Else
                    If txtMOAAmt.Text = 0 Or txtMOAAmt.Text = "" Or cboMOACurr.Text = "" Or txtPerMultQty.Text = "" Then
                        check_Tier = False
                    Else
                        check_Tier = True
                    End If
                End If
            Else
                check_Tier = True
            End If
        End If

        If check_Color = True And check_Packing = True And check_Tier = True And check_Price = True Then
            check_ItemStatus = "CMP"
        Else
            check_ItemStatus = "INC"
        End If
    End Function

    Private Function check_ItemMaster() As Boolean
        check_ItemMaster = True
        Dim i As Integer

        'Tag Page 1

        'Check Manadatory fields
        If Trim(txtEngDsc.Text) = "" Then
            MsgBox("Item Description is empty!")
            Me.TabPageMain.SelectedIndex = 0
            txtEngDsc.Select()
            check_ItemMaster = False
            Exit Function
        End If

        'Check Color Grid
        For i = 0 To dgColor.RowCount - 1
            If dgColor.Item(dgColor_icf_colcde, i).Value = "" Then
                MsgBox("Item Color Code is empty!")
                Me.TabPageMain.SelectedIndex = 0
                dgColor.Select()
                check_ItemMaster = False
                Exit Function
            End If
        Next i

        'Check Packing Grid



        'Tag Page 2
        'Check Manadatory fields
        If cboDV.Text = "" Then
            MsgBox("Missing Design Vendor!")
            Me.TabPageMain.SelectedIndex = 1
            cboDV.Select()
            check_ItemMaster = False
            Exit Function
        End If

        If cboCV.Text = "" Then
            MsgBox("Missing Custom Vendor!")
            Me.TabPageMain.SelectedIndex = 1
            cboCV.Select()
            check_ItemMaster = False
            Exit Function
        End If

        If cboTV.Text = "" Then
            MsgBox("Missing Trading Vendor!")
            Me.TabPageMain.SelectedIndex = 1
            cboTV.Select()
            check_ItemMaster = False
            Exit Function
        End If

        If cboEV.Text = "" Then
            MsgBox("Missing Examine Vendor!")
            Me.TabPageMain.SelectedIndex = 1
            cboEV.Select()
            check_ItemMaster = False
            Exit Function
        End If

        ''For external item, check dupliate vendor item number
        Dim tmp_venitm As String
        Dim tmp_venno As String
        If Split(cboItmVenTyp.Text, " - ")(0) = "EXT" Then
            For i = 0 To rs_IMVENINF.Tables("RESULT").Rows.Count - 1
                If rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_creusr") = "~*ADD*~" Then
                    tmp_venitm = rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_venitm")
                    tmp_venno = rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_venno")

                    gspStr = "sp_select_IMVENINF_Check '','" & tmp_venitm & "','" & tmp_venno & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading check_ItemMaster sp_select_IMVENINF_Check :" & rtnStr)
                        check_ItemMaster = False
                        Exit Function
                    End If

                    If rs.Tables("RESULT").Rows.Count = 0 Then
                        gspStr = "sp_select_IMVENINFH_Check '','" & tmp_venitm & "','" & tmp_venno & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading check_ItemMaster sp_select_IMVENINFH_Check :" & rtnStr)
                            check_ItemMaster = False
                            Exit Function
                        End If

                        If rs.Tables("RESULT").Rows.Count > 0 Then
                            MsgBox("Vendor Item Number exist! [" & tmp_venitm & " : " & tmp_venno & "]")
                            check_ItemMaster = False
                            Exit Function
                        End If
                    Else
                        MsgBox("Vendor Item Number exist! [" & tmp_venitm & " : " & tmp_venno & "]")
                        check_ItemMaster = False
                        Exit Function
                    End If

                End If
            Next i
        Else
            If rs_IMVENINF.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("Missing PV!")
                check_ItemMaster = False
                Exit Function
            Else
                If rs_IMVENINF.Tables("RESULT").Rows(0).Item("ivi_venitm") = "" Then
                    MsgBox("Vendor Item Number is empty!")
                    check_ItemMaster = False
                    Exit Function
                End If
            End If
        End If

        'Page 3
        If Split(cboItmVenTyp.Text, " - ")(0) = "EXT" And Split(cboItmTyp.Text, " - ")(0) <> "BOM" Then
            If cboPrdTyp.Text = "" Then
                MsgBox("Missing Product Type!")
                check_ItemMaster = False
                Exit Function
            End If
        End If


        'Page 4
        If Split(cboItmTyp.Text, " - ")(0) = "ASS" Then
            Dim tmp_um As String
            Dim tmp_ftr As Integer
            Dim tmp_inr As Integer
            Dim tmp_mtr As Integer

            ' If rs_IMPCKINF.Tables("RESULT").Rows.Count <> 1 Then
            Dim dr_IMPCKINF() As DataRow = rs_IMPCKINF.Tables("RESULT").Select("ipi_creusr <> 'Y'")
            'If rs_IMPCKINF.Tables("RESULT").Rows.Count = 0 Then
            If dr_IMPCKINF.Length = 0 Then
                MsgBox("Assortment have no packing!")
                check_ItemMaster = False
                Exit Function
            End If

            tmp_um = rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_pckunt")
            tmp_ftr = rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_conftr")
            tmp_inr = rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_inrqty")
            tmp_mtr = rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_mtrqty")

            Dim tmp_assorted_um As String
            Dim tmp_assorted_ftr As Integer
            Dim tmp_assorted_inr As Integer
            Dim tmp_assorted_mtr As Integer
            Dim tmp_assorted_inr_ttl As Integer
            Dim tmp_assorted_mtr_ttl As Integer
            tmp_assorted_um = ""
            tmp_assorted_ftr = 0
            tmp_assorted_inr = 0
            tmp_assorted_mtr = 0
            tmp_assorted_inr_ttl = 0
            tmp_assorted_mtr_ttl = 0

            For i = 0 To rs_IMBOMASS.Tables("RESULT").Rows.Count - 1
                If rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_cocde") <> "Y" Then
                    tmp_assorted_um = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_pckunt")
                    tmp_assorted_ftr = getconftr(tmp_assorted_um)
                    If tmp_assorted_ftr <> 1 Then
                        MsgBox("Assorted UM invalid, please check! [Conversion Factor <> 1]")
                        check_ItemMaster = False
                        Exit Function
                    End If

                    If IsNumeric(rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_inrqty")) Then
                        tmp_assorted_inr = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_inrqty")
                        'If tmp_assorted_inr = 0 Then
                        '    MsgBox("Assorted Inner Qty invalid, please check! [zero]")
                        '    check_ItemMaster = False
                        '    Exit Function
                        'End If
                    Else
                        MsgBox("Assorted Inner Qty invalid, please check! [Not Numeric]")
                        check_ItemMaster = False
                        Exit Function
                    End If

                    If IsNumeric(rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_mtrqty")) Then
                        tmp_assorted_mtr = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_mtrqty")
                        If tmp_assorted_mtr = 0 Then
                            MsgBox("Assorted Master Qty invalid, please check! [zero]")
                            check_ItemMaster = False
                            Exit Function
                        End If
                    Else
                        MsgBox("Assorted Master Qty invalid, please check! [Not Numeric]")
                        check_ItemMaster = False
                        Exit Function
                    End If

                    tmp_assorted_inr_ttl = tmp_assorted_inr_ttl + tmp_assorted_inr
                    tmp_assorted_mtr_ttl = tmp_assorted_mtr_ttl + tmp_assorted_mtr
                End If
            Next i

            If tmp_ftr * tmp_inr <> tmp_assorted_inr_ttl Then
                MsgBox("Total Inner Qty of assorted items not equal to Assortment's Inner Qty!")
                check_ItemMaster = False
                Exit Function
            End If

            If tmp_ftr * tmp_mtr <> tmp_assorted_mtr_ttl Then
                MsgBox("Total Master Qty of assorted items not equal to Assortment's Master Qty!")
                check_ItemMaster = False
                Exit Function
            End If
        End If

    End Function


    Private Function save_ItemMaster() As Boolean
        save_ItemMaster = True

        If save_IMCOLINF() = False Then
            save_ItemMaster = False
            Exit Function
        End If

        If save_IMPCKINF() = False Then
            save_ItemMaster = False
            Exit Function
        End If

        If save_IMVENINF() = False Then
            save_ItemMaster = False
            Exit Function
        End If

        If save_IMCUSNO() = False Then
            save_ItemMaster = False
            Exit Function
        End If

        If save_IMBOMASS() = False Then
            save_ItemMaster = False
            Exit Function
        End If

        If save_IMPRCINF() = False Then
            save_ItemMaster = False
            Exit Function
        End If

        If save_IMCSTINF() = False Then
            save_ItemMaster = False
            Exit Function
        End If

        If save_IMCTYINF() = False Then
            save_ItemMaster = False
            Exit Function
        End If

        If save_IMMATBKD() = False Then
            save_ItemMaster = False
            Exit Function
        End If

        If save_IMMOQMOA() = False Then
            save_ItemMaster = False
            Exit Function
        End If

        If save_IMBASINF() = False Then
            save_ItemMaster = False
            Exit Function
        End If

    End Function

    Private Function save_IMBASINF() As Boolean
        Dim IBI_COCDE As String
        Dim IBI_ITMNO As String
        Dim IBI_ORGITM As String
        Dim IBI_LNECDE As String
        Dim IBI_PRDTYP As String
        Dim IBI_CURCDE As String
        Dim IBI_CATLVL0 As String
        Dim IBI_CATLVL1 As String
        Dim IBI_CATLVL2 As String
        Dim IBI_CATLVL3 As String
        Dim IBI_CATLVL4 As String
        Dim IBI_ITMSTS As String
        Dim IBI_TYP As String
        Dim IBI_ENGDSC As String
        Dim IBI_CHNDSC As String
        Dim IBI_VENNO As String
        Dim IBI_CUSVEN As String
        Dim IBI_TRADEVEN As String
        Dim IBI_EXAMVEN As String
        Dim IBI_IMGPTH As String
        Dim IBI_HAMUSA As String
        Dim IBI_HAMEUR As String
        Dim IBI_DTYUSA As String
        Dim IBI_DTYEUR As String
        Dim IBI_COSMTH As String
        Dim IBI_RMK As String
        Dim IBI_TIRTYP As String
        Dim IBI_MOQCTN As String
        Dim IBI_QTY As String
        Dim IBI_MOA As String
        Dim IBI_WASTAGE As String
        Dim IBI_ITMNAT As String
        Dim IBI_DSGNO As String
        Dim IBI_FINISHING As String
        Dim IBI_MATERIAL As String
        Dim IBI_PRDSIZETYP As String
        Dim IBI_PRDSIZEUNT As String
        Dim IBI_PRDSIZEVAL As String
        Dim IBI_MOQUNTTYP As String
        Dim IBI_PRDGRP As String
        Dim IBI_PRDICON As String
        Dim IBI_SEASON As String
        Dim IBI_DESIGNER As String
        Dim IBI_DEVTEAM As String
        Dim IBI_TYPE As String
        Dim IBI_YEAR As String
        Dim IBI_ADDREQ_FORMA As String
        Dim IBI_ADDREQ_CCIB As String
        Dim IBI_ADDREQ_STER As String
        Dim IBI_FTYTMP As String
        Dim IBI_CREUSR As String

        '        IBI_COCDE = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_cocde")
        IBI_COCDE = ""
        IBI_ITMNO = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmno")
        IBI_ORGITM = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_orgitm")
        IBI_LNECDE = cboPrdLne.Text
        IBI_PRDTYP = Split(cboPrdTyp.Text, " - ")(0)
        IBI_CURCDE = cboMOACurr.Text
        'rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_curcde")

        If cboCategory.Text = "" Then
            IBI_CATLVL0 = ""
            IBI_CATLVL1 = ""
            IBI_CATLVL2 = ""
            IBI_CATLVL3 = ""
            IBI_CATLVL4 = ""
        Else
            Dim dr() As DataRow = rs_SYCATREL.Tables("RESULT").Select("level4 = '" & Split(cboCategory.Text, " - ")(0) & "'")
            If dr.Length = 1 Then
                IBI_CATLVL0 = dr(0).Item("level0").ToString
                IBI_CATLVL1 = dr(0).Item("level1").ToString
                IBI_CATLVL2 = dr(0).Item("level2").ToString
                IBI_CATLVL3 = dr(0).Item("level3").ToString
                IBI_CATLVL4 = dr(0).Item("level4").ToString
            Else
                IBI_CATLVL0 = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_catlvl0")
                IBI_CATLVL1 = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_catlvl1")
                IBI_CATLVL2 = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_catlvl2")
                IBI_CATLVL3 = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_catlvl3")
                IBI_CATLVL4 = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_catlvl4")
            End If
        End If



        IBI_ITMSTS = Split(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmsts"), " - ")(0)

        IBI_TYP = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_typ")

        IBI_ENGDSC = Replace(UCase(txtEngDsc.Text), "'", "''")
        IBI_CHNDSC = Replace(txtChnDsc.Text, "'", "''")

        IBI_VENNO = Split(cboDV.Text, " - ")(0)
        IBI_CUSVEN = Split(cboCV.Text, " - ")(0)
        IBI_TRADEVEN = Split(cboTV.Text, " - ")(0)
        IBI_EXAMVEN = Split(cboEV.Text, " - ")(0)

        IBI_IMGPTH = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_imgpth")
        IBI_HAMUSA = Split(cboHstuUSA.Text, " - ")(0)
        IBI_HAMEUR = Split(cboHstuEur.Text, " - ")(0)
        IBI_DTYUSA = txtHstuUSADuty.Text
        IBI_DTYEUR = txtHstuEURDuty.Text
        IBI_COSMTH = Split(cboConstrMethod.Text, " - ")(0)

        IBI_RMK = Replace(txtItmRmk.Text, "'", "''")

        If rbTier_CompDef.Checked = True Then
            IBI_TIRTYP = 2
        Else
            IBI_TIRTYP = 1
        End If

        IBI_MOQCTN = txtMOQQty.Text
        IBI_QTY = txtPerMultQty.Text
        IBI_MOA = txtMOAAmt.Text
        If txtWastage.Text = "" Then
            IBI_WASTAGE = 0
        Else
            IBI_WASTAGE = txtWastage.Text
        End If


        IBI_ITMNAT = Split(cboItmNature.Text, " - ")(0)
        IBI_DSGNO = txtDsgItmNo.Text
        IBI_FINISHING = "" 'rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_finishing")
        IBI_MATERIAL = Split(cboMaterial.Text, " - ")(0)
        IBI_PRDSIZETYP = Split(cboPrdSizeTyp.Text, " - ")(0)
        IBI_PRDSIZEUNT = Split(cboPrdSizeUnit.Text, " - ")(0)
        IBI_PRDSIZEVAL = txtPrdSizeValue.Text
        IBI_MOQUNTTYP = cboMOQUM.Text
        IBI_PRDGRP = Split(cboPrdGroup.Text, " - ")(0)
        IBI_PRDICON = Split(cboPrdIcon.Text, " - ")(0)
        IBI_SEASON = Split(cboSeason.Text, " - ")(0)
        IBI_DESIGNER = Split(cboDesigner.Text, " - ")(0)
        IBI_DEVTEAM = Split(cboDevTeam.Text, " - ")(0)
        IBI_TYPE = Split(cboType.Text, " - ")(0)
        IBI_YEAR = cboYear.Text
        If cbAddreq_formA.Checked = True Then
            IBI_ADDREQ_FORMA = "Y"
        Else
            IBI_ADDREQ_FORMA = ""
        End If

        If cbAddreq_ccib.Checked = True Then
            IBI_ADDREQ_CCIB = "Y"
        Else
            IBI_ADDREQ_CCIB = ""
        End If

        If cbAddreq_ster.Checked = True Then
            IBI_ADDREQ_STER = "Y"
        Else
            IBI_ADDREQ_STER = ""
        End If

        If cbTmpItm.Checked = True Then
            IBI_FTYTMP = "Y"
        Else
            IBI_FTYTMP = "N"
        End If

        IBI_CREUSR = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr")
        If IBI_CREUSR <> "~*ADD*~" And IBI_CREUSR <> "~*UPD*~" And Recordstatus = True Then
            IBI_CREUSR = "~*UPD*~"
        End If

        If IBI_CREUSR = "~*ADD*~" Then
            gspStr = "sp_insert_IMBASINF '" & IBI_COCDE & "','" & IBI_ITMNO & "','" & IBI_ORGITM & "','" & IBI_LNECDE & "','" & IBI_PRDTYP & "','" & _
                                    IBI_CURCDE & "','" & IBI_CATLVL0 & "','" & IBI_CATLVL1 & "','" & IBI_CATLVL2 & "','" & IBI_CATLVL3 & "','" & _
                                    IBI_CATLVL4 & "','" & IBI_ITMSTS & "','" & IBI_TYP & "','" & IBI_ENGDSC & "','" & IBI_CHNDSC & "','" & IBI_VENNO & "','" & _
                                    IBI_CUSVEN & "','" & IBI_TRADEVEN & "','" & IBI_EXAMVEN & "','" & IBI_IMGPTH & "','" & IBI_HAMUSA & "','" & IBI_HAMEUR & "'," & _
                                    IBI_DTYUSA & "," & IBI_DTYEUR & ",'" & IBI_COSMTH & "','" & IBI_RMK & "','" & IBI_TIRTYP & "'," & IBI_MOQCTN & "," & _
                                    IBI_QTY & "," & IBI_MOA & "," & IBI_WASTAGE & ",'" & IBI_ITMNAT & "','" & IBI_DSGNO & "','" & IBI_FINISHING & "','" & _
                                    IBI_MATERIAL & "','" & IBI_PRDSIZETYP & "','" & IBI_PRDSIZEUNT & "'," & IBI_PRDSIZEVAL & ",'" & IBI_MOQUNTTYP & "','" & _
                                    IBI_PRDGRP & "','" & IBI_PRDICON & "','" & IBI_SEASON & "','" & IBI_DESIGNER & "','" & IBI_DEVTEAM & "','" & IBI_TYPE & "','" & _
                                    IBI_YEAR & "','" & IBI_ADDREQ_FORMA & "','" & IBI_ADDREQ_CCIB & "','" & IBI_ADDREQ_STER & "','" & IBI_FTYTMP & "','" & gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading save_IMBASINF sp_insert_IMBASINF :" & rtnStr)
                save_IMBASINF = False
                Exit Function
            End If
        ElseIf IBI_CREUSR = "~*UPD*~" Then
            gspStr = "sp_update_IMBASINF '" & IBI_COCDE & "','" & IBI_ITMNO & "','" & IBI_ORGITM & "','" & IBI_LNECDE & "','" & IBI_PRDTYP & "','" & _
                                                IBI_CURCDE & "','" & IBI_CATLVL0 & "','" & IBI_CATLVL1 & "','" & IBI_CATLVL2 & "','" & IBI_CATLVL3 & "','" & _
                                                IBI_CATLVL4 & "','" & IBI_ITMSTS & "','" & IBI_TYP & "','" & IBI_ENGDSC & "','" & IBI_CHNDSC & "','" & IBI_VENNO & "','" & _
                                                IBI_CUSVEN & "','" & IBI_TRADEVEN & "','" & IBI_EXAMVEN & "','" & IBI_IMGPTH & "','" & IBI_HAMUSA & "','" & IBI_HAMEUR & "'," & _
                                                IBI_DTYUSA & "," & IBI_DTYEUR & ",'" & IBI_COSMTH & "','" & IBI_RMK & "','" & IBI_TIRTYP & "'," & IBI_MOQCTN & "," & _
                                                IBI_QTY & "," & IBI_MOA & "," & IBI_WASTAGE & ",'" & IBI_ITMNAT & "','" & IBI_DSGNO & "','" & IBI_FINISHING & "','" & _
                                                IBI_MATERIAL & "','" & IBI_PRDSIZETYP & "','" & IBI_PRDSIZEUNT & "'," & IBI_PRDSIZEVAL & ",'" & IBI_MOQUNTTYP & "','" & _
                                                IBI_PRDGRP & "','" & IBI_PRDICON & "','" & IBI_SEASON & "','" & IBI_DESIGNER & "','" & IBI_DEVTEAM & "','" & IBI_TYPE & "','" & _
                                                IBI_YEAR & "','" & IBI_ADDREQ_FORMA & "','" & IBI_ADDREQ_CCIB & "','" & IBI_ADDREQ_STER & "','" & IBI_FTYTMP & "','" & gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading save_IMBASINF sp_update_IMBASINF :" & rtnStr)
                save_IMBASINF = False
                Exit Function
            End If
        ElseIf IBI_CREUSR = "~*DEL*~" Then
            gspStr = "sp_physical_delete_IMBASINF '" & IBI_COCDE & "','" & IBI_ITMNO & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading save_IMBASINF sp_physical_delete_IMBASINF :" & rtnStr)
                save_IMBASINF = False
                Exit Function
            End If

        End If
        save_IMBASINF = True
    End Function

    Private Function save_IMCOLINF() As Boolean
        If rs_IMCOLINF.Tables("RESULT").Rows.Count = 0 Then
            save_IMCOLINF = True
            Exit Function
        End If

        Dim ICF_COCDE As String
        Dim ICF_ITMNO As String
        Dim ICF_COLCDE As String
        Dim ICF_COLSEQ As String
        Dim ICF_VENCOL As String
        Dim ICF_COLDSC As String
        Dim ICF_TYP As String
        Dim ICF_UCPCDE As String
        Dim ICF_EANCDE As String
        Dim ICF_ASSCOL As String
        Dim ICF_SWATCHPATH As String
        Dim ICF_IMGPATH As String
        Dim ICF_LNECDE As String
        Dim ICF_CREUSR As String

        Dim i As Integer

        For i = 0 To rs_IMCOLINF.Tables("RESULT").Rows.Count - 1
            ICF_COCDE = rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_cocde")
            ICF_ITMNO = rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_itmno")
            If ICF_ITMNO = "" Then
                ICF_ITMNO = txtItmNo.Text
            End If
            ICF_COLCDE = rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_colcde")
            If mode = "ADD" Then
                ICF_COLSEQ = 0
            Else
                ICF_COLSEQ = rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_colseq")
            End If
            ICF_VENCOL = rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_vencol")
            ICF_COLDSC = rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_coldsc")
            ICF_TYP = "" 'rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_typ")
            ICF_UCPCDE = rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_ucpcde")
            ICF_EANCDE = rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_eancde")
            ICF_ASSCOL = "N" 'rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_asscol")
            ICF_SWATCHPATH = "" 'rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_swatchpath")
            ICF_IMGPATH = "" 'rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_imgpath")
            ICF_LNECDE = "" 'rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_lnecde")
            ICF_CREUSR = rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_creusr")

            gspStr = ""
            If ICF_COCDE = "Y" Then
                gspStr = "sp_physical_delete_IMCOLINF '','" & ICF_ITMNO & "','" & ICF_COLCDE & "'," & ICF_COLSEQ
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_IMCOLINF sp_physical_delete_IMCOLINF:" & rtnStr)
                    save_IMCOLINF = False
                    Exit Function
                End If
            ElseIf ICF_CREUSR = "~*ADD*~" Then
                If ICF_COLCDE <> "" Then
                    gspStr = "sp_insert_IMCOLINF '" & ICF_COCDE & "','" & ICF_ITMNO & "','" & ICF_COLCDE & "','" & ICF_VENCOL & "','" & _
                                                        ICF_COLDSC & "','" & ICF_TYP & "','" & ICF_UCPCDE & "','" & ICF_EANCDE & "','" & ICF_ASSCOL & "','" & _
                                                        ICF_SWATCHPATH & "','" & ICF_IMGPATH & "','" & ICF_LNECDE & "','" & gsUsrID & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_IMCOLINF sp_insert_IMCOLINF :" & rtnStr)
                        save_IMCOLINF = False
                        Exit Function
                    End If
                End If
            ElseIf ICF_CREUSR = "~*UPD*~" Then
                gspStr = "sp_update_IMCOLINF '" & ICF_COCDE & "','" & ICF_ITMNO & "','" & ICF_COLCDE & "','" & ICF_COLSEQ & "','" & ICF_VENCOL & "','" & _
                                                    ICF_COLDSC & "','" & ICF_TYP & "','" & ICF_UCPCDE & "','" & ICF_EANCDE & "','" & ICF_ASSCOL & "','" & _
                                                    ICF_SWATCHPATH & "','" & ICF_IMGPATH & "','" & ICF_LNECDE & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_IMCOLINF sp_update_IMCOLINF :" & rtnStr)
                    save_IMCOLINF = False
                    Exit Function
                End If
            End If
        Next i

        save_IMCOLINF = True
    End Function

    Private Function save_IMPCKINF() As Boolean
        If rs_IMPCKINF.Tables("RESULT").Rows.Count = 0 Then
            save_IMPCKINF = True
            Exit Function
        End If

        Dim IPI_COCDE As String
        Dim IPI_ITMNO As String
        Dim IPI_PCKUNT As String
        Dim IPI_PCKSEQ As String
        Dim IPI_MTRQTY As String
        Dim IPI_INRQTY As String
        Dim IPI_INRHIN As String
        Dim IPI_INRWIN As String
        Dim IPI_INRDIN As String
        Dim IPI_INRHCM As String
        Dim IPI_INRWCM As String
        Dim IPI_INRDCM As String
        Dim IPI_MTRHIN As String
        Dim IPI_MTRWIN As String
        Dim IPI_MTRDIN As String
        Dim IPI_MTRHCM As String
        Dim IPI_MTRWCM As String
        Dim IPI_MTRDCM As String
        Dim IPI_CFT As String
        Dim IPI_CBM As String
        Dim IPI_GRSWGT As String
        Dim IPI_NETWGT As String
        Dim IPI_PCKITR As String
        Dim IPI_CONFTR As String
        Dim IPI_CUSNO As String
        Dim IPI_QUTDAT As String
        Dim IPI_CREUSR As String
        Dim IPI_INRSZE As String
        Dim IPI_MTRSZE As String
        Dim IPI_MAT As String
        Dim IPI_CUS1NO As String
        Dim IPI_CUS2NO As String

        Dim i As Integer

        For i = 0 To rs_IMPCKINF.Tables("RESULT").Rows.Count - 1
            IPI_COCDE = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cocde")
            IPI_ITMNO = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_itmno")
            If IPI_ITMNO = "" Then
                IPI_ITMNO = txtItmNo.Text
            End If
            If Split(cboItmTyp.Text, " - ")(0) = "ASS" Then
                IPI_PCKUNT = "ST"
            Else
                IPI_PCKUNT = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_pckunt")
            End If
            IPI_PCKSEQ = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_pckseq")
            IPI_MTRQTY = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_mtrqty")
            IPI_INRQTY = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_inrqty")
            IPI_INRHIN = Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("inner_in"), "x")(2)
            IPI_INRWIN = Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("inner_in"), "x")(1)
            IPI_INRDIN = Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("inner_in"), "x")(0)
            IPI_INRHCM = Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("inner_cm"), "x")(2)
            IPI_INRWCM = Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("inner_cm"), "x")(1)
            IPI_INRDCM = Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("inner_cm"), "x")(0)
            IPI_MTRHIN = Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("master_in"), "x")(2)
            IPI_MTRWIN = Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("master_in"), "x")(1)
            IPI_MTRDIN = Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("master_in"), "x")(0)
            IPI_MTRHCM = Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("master_cm"), "x")(2)
            IPI_MTRWCM = Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("master_cm"), "x")(1)
            IPI_MTRDCM = Split(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("master_cm"), "x")(0)
            IPI_CUS1NO = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cus1no")
            IPI_CUS2NO = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cus2no")
            IPI_CFT = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cft")
            IPI_CBM = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cbm")
            IPI_GRSWGT = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_grswgt")
            IPI_NETWGT = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_netwgt")
            IPI_PCKITR = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_pckitr")
            IPI_CONFTR = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_conftr")
            IPI_CUSNO = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cusno")
            IPI_INRSZE = IIf(IsDBNull(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_inrsze")), "", rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_inrsze"))
            IPI_MTRSZE = IIf(IsDBNull(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_mtrsze")), "", rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_mtrsze"))
            IPI_MAT = IIf(IsDBNull(rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_mat")), "", rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_mat"))
            If rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_qutdat") = "" Then
                IPI_QUTDAT = "1900-01"
            Else
                IPI_QUTDAT = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_qutdat")
            End If
            IPI_CREUSR = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_creusr")

            gspStr = ""
            If IPI_COCDE = "Y" Then
                gspStr = "sp_physical_delete_IMPCKINF '','" & IPI_ITMNO & "'," & IPI_PCKSEQ
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_IMPCKINF sp_physical_delete_IMPCKINF:" & rtnStr)
                    save_IMPCKINF = False
                    Exit Function
                End If
            ElseIf IPI_CREUSR = "~*ADD*~" Or IPI_CREUSR = "~*NEW*~" Then
                If IPI_PCKUNT <> "" Then
                    gspStr = "sp_insert_IMPCKINF '','" & IPI_ITMNO & "','" & IPI_PCKUNT & "'," & IPI_MTRQTY & "," & IPI_INRQTY & "," & _
                                                IPI_INRHIN & "," & IPI_INRWIN & "," & IPI_INRDIN & "," & IPI_INRHCM & "," & IPI_INRWCM & "," & _
                                                IPI_INRDCM & "," & IPI_MTRHIN & "," & IPI_MTRWIN & "," & IPI_MTRDIN & "," & IPI_MTRHCM & "," & _
                                                IPI_MTRWCM & "," & IPI_MTRDCM & "," & IPI_CFT & "," & IPI_CBM & "," & IPI_GRSWGT & "," & _
                                                IPI_NETWGT & ",'" & IPI_PCKITR & "'," & IPI_CONFTR & ",'" & IPI_CUSNO & "','" & _
                                                IPI_QUTDAT & "-01','" & IPI_INRSZE & "','" & IPI_MTRSZE & "','" & IPI_MAT & "','" & _
                                                IPI_CUS1NO & "','" & IPI_CUS2NO & "','" & gsUsrID & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_IMPCKINF sp_insert_IMPCKINF :" & rtnStr)
                        save_IMPCKINF = False
                        Exit Function
                    End If
                End If
            ElseIf IPI_CREUSR = "~*UPD*~" Then
                gspStr = "sp_update_IMPCKINF '" & IPI_COCDE & "','" & IPI_ITMNO & "','" & IPI_PCKUNT & "'," & IPI_PCKSEQ & "," & IPI_MTRQTY & "," & _
                                                IPI_INRQTY & "," & IPI_INRHIN & "," & IPI_INRWIN & "," & IPI_INRDIN & "," & IPI_INRHCM & "," & _
                                                IPI_INRWCM & "," & IPI_INRDCM & "," & IPI_MTRHIN & "," & IPI_MTRWIN & "," & IPI_MTRDIN & "," & _
                                                IPI_MTRHCM & "," & IPI_MTRWCM & "," & IPI_MTRDCM & "," & IPI_CFT & "," & IPI_CBM & "," & _
                                                IPI_GRSWGT & "," & IPI_NETWGT & ",'" & IPI_PCKITR & "'," & IPI_CONFTR & ",'" & IPI_CUSNO & "','" & _
                                                IPI_QUTDAT & "-01','" & IPI_INRSZE & "','" & IPI_MTRSZE & "','" & IPI_MAT & "','" & _
                                                IPI_CUS1NO & "','" & IPI_CUS2NO & "','" & gsUsrID & "'"



                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_IMPCKINF sp_update_IMPCKINF :" & rtnStr)
                    save_IMPCKINF = False
                    Exit Function
                End If
            End If
        Next i

        save_IMPCKINF = True

    End Function

    Private Function save_IMCUSNO() As Boolean
        If rs_IMCUSNO.Tables("RESULT").Rows.Count = 0 Then
            save_IMCUSNO = True
            Exit Function
        End If

        Dim ICN_COCDE As String
        Dim ICN_ITMNO As String
        Dim ICN_CUSNO As String
        Dim ICN_RMK As String
        Dim ICN_CREUSR As String

        Dim i As Integer

        For i = 0 To rs_IMCUSNO.Tables("RESULT").Rows.Count - 1
            ICN_COCDE = rs_IMCUSNO.Tables("RESULT").Rows(i).Item("icn_status")
            ICN_ITMNO = rs_IMCUSNO.Tables("RESULT").Rows(i).Item("icn_itmno")
            ICN_CUSNO = Split(rs_IMCUSNO.Tables("RESULT").Rows(i).Item("icn_cusno"), " - ")(0)
            ICN_RMK = rs_IMCUSNO.Tables("RESULT").Rows(i).Item("icn_rmk")
            ICN_CREUSR = rs_IMCUSNO.Tables("RESULT").Rows(i).Item("icn_creusr")

            gspStr = ""
            If ICN_COCDE = "Y" Then
                'If ICN_CREUSR = "~*UPD*~" Or ICN_CREUSR = "~*DEL*~" Then
                gspStr = "sp_physical_delete_IMCUSNO '','" & ICN_ITMNO & "','" & ICN_CUSNO & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_IMCUSNO sp_physical_delete_IMCUSNO:" & rtnStr)
                    save_IMCUSNO = False
                    Exit Function
                End If
                'End If
            ElseIf ICN_CREUSR = "~*ADD*~" Or ICN_CREUSR = "~*NEW*~" Then
            If ICN_CUSNO <> "" Then
                gspStr = "sp_insert_IMCUSNO '','" & ICN_ITMNO & "','" & ICN_CUSNO & "','" & ICN_RMK & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_IMCUSNO sp_insert_IMCUSNO :" & rtnStr)
                    save_IMCUSNO = False
                    Exit Function
                End If
            End If
            ElseIf ICN_CREUSR = "~*UPD*~" Then
            gspStr = "sp_update_IMCUSNO '','" & ICN_ITMNO & "','" & ICN_CUSNO & "','" & ICN_RMK & "','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading save_IMCUSNO sp_update_IMCUSNO :" & rtnStr)
                save_IMCUSNO = False
                Exit Function
            End If
            End If
        Next i

        save_IMCUSNO = True
    End Function

    Private Function save_IMBOMASS() As Boolean
        If rs_IMBOMASS.Tables("RESULT").Rows.Count = 0 Then
            save_IMBOMASS = True
            Exit Function
        End If

        Dim IBA_COCDE As String
        Dim IBA_ITMNO As String
        Dim IBA_ASSITM As String
        Dim IBA_TYP As String
        Dim IBA_COLCDE As String
        Dim IBA_PCKUNT As String
        Dim IBA_BOMQTY As String
        Dim IBA_INRQTY As String
        Dim IBA_MTRQTY As String
        Dim IBA_ALTITMNO As String
        Dim IBA_COSTING As String
        Dim IBA_GENPO As String
        Dim IBA_UNTCST As String
        Dim IBA_CURCDE As String
        Dim IBA_FTYFMLOPT As String
        Dim IBA_FMLOPT As String
        Dim IBA_BOMBASPRC As String
        Dim IBA_FCURCDE As String
        Dim IBA_FTYCST As String
		Dim IBA_PERIOD As String
        Dim IBA_CREUSR As String
        Dim IBA_ORGCOLCDE As String


        Dim i As Integer

        For i = 0 To rs_IMBOMASS.Tables("RESULT").Rows.Count - 1
            IBA_COCDE = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_cocde")
            IBA_ITMNO = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_itmno")
            IBA_ASSITM = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_assitm")
            IBA_TYP = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_typ")
            IBA_COLCDE = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_colcde")
            IBA_PCKUNT = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_pckunt")
            IBA_BOMQTY = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_bomqty")
            IBA_INRQTY = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_inrqty")
            IBA_MTRQTY = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_mtrqty")
            IBA_ALTITMNO = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_altitmno")
            If rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_costing") = "Costing" Then
                IBA_COSTING = "Y"
            Else
                IBA_COSTING = "N"
            End If
            IBA_GENPO = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_genpo")
            IBA_UNTCST = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_untcst")
            IBA_CURCDE = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_curcde")
            IBA_FTYFMLOPT = Split(rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_ftyfmlopt"), " - ")(0)
            IBA_FMLOPT = Split(rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_fmlopt"), " - ")(0)
            IBA_BOMBASPRC = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_bombasprc")
            IBA_FCURCDE = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_fcurcde")
            IBA_FTYCST = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_ftycst")
            IBA_CREUSR = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_creusr")
            IBA_PERIOD = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_period") & "-01"

            If IBA_PERIOD = "-01" Then
                IBA_PERIOD = ""
            End If

            gspStr = ""
            If IBA_COCDE = "Y" Then
                gspStr = "sp_physical_delete_IMBOMASS '','" & IBA_ITMNO & "','" & IBA_ASSITM & "','" & IBA_TYP & "','" & IBA_COLCDE & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_IMBOMASS sp_physical_delete_IMBOMASS:" & rtnStr)
                    save_IMBOMASS = False
                    Exit Function
                End If
            ElseIf IBA_CREUSR = "~*ADD*~" Or IBA_CREUSR = "~*NEW*~" Then
                If IBA_ASSITM <> "" Then
                    gspStr = "sp_insert_IMBOMASS '','" & IBA_ITMNO & "','" & IBA_ASSITM & "','" & IBA_TYP & "','" & IBA_COLCDE & "','" & _
                                                IBA_PCKUNT & "','" & IBA_BOMQTY & "','" & IBA_INRQTY & "','" & IBA_MTRQTY & "','" & IBA_ALTITMNO & "'," & _
                                                IBA_UNTCST & ",'" & IBA_COSTING & "','" & IBA_GENPO & "','" & IBA_CURCDE & "','" & IBA_FTYFMLOPT & "','" & _
                                                IBA_FMLOPT & "'," & IBA_BOMBASPRC & ",'" & IBA_FCURCDE & "'," & IBA_FTYCST & ",'" & IBA_PERIOD & "','" & gsUsrID & "'"
					rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_IMBOMASS sp_insert_IMBOMASS :" & rtnStr)
                        save_IMBOMASS = False
                        Exit Function
                    End If
                End If
            ElseIf IBA_CREUSR = "~*UPD*~" Then
                IBA_ORGCOLCDE = rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_orgcolcde")
                'ElseIf check_update_BOMASS(i, IBA_ASSITM, IBA_COLCDE, IBA_PCKUNT, IBA_INRQTY, IBA_MTRQTY) = True Then
                gspStr = "sp_update_IMBOMASS '','" & IBA_ITMNO & "','" & IBA_ASSITM & "','" & IBA_TYP & "','" & IBA_COLCDE & "','" & _
                                                IBA_PCKUNT & "','" & IBA_BOMQTY & "','" & IBA_INRQTY & "','" & IBA_MTRQTY & "','" & IBA_ALTITMNO & "','" & _
                                                IBA_COSTING & "','" & IBA_GENPO & "'," & IBA_UNTCST & ",'" & IBA_CURCDE & "','" & IBA_FTYFMLOPT & "','" & _
                                                IBA_FMLOPT & "'," & IBA_BOMBASPRC & ",'" & IBA_FCURCDE & "'," & IBA_FTYCST & ",'" & IBA_PERIOD & "','" & IBA_ORGCOLCDE & "','" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_IMBOMASS sp_update_IMBOMASS :" & rtnStr)
                    save_IMBOMASS = False
                    Exit Function
                End If
            End If
        Next i

        save_IMBOMASS = True
    End Function


    Private Function save_IMPRCINF() As Boolean
        If rs_IMPRCINF.Tables("RESULT").Rows.Count = 0 Then
            save_IMPRCINF = True
            Exit Function
        End If

        Dim IMU_COCDE As String
        Dim IMU_ITMNO As String
        Dim IMU_TYP As String
        Dim IMU_VENTYP As String
        Dim IMU_VENNO As String
        Dim IMU_PRDVEN As String
        Dim IMU_PCKUNT As String
        Dim IMU_CONFTR As String
        Dim IMU_INRQTY As String
        Dim IMU_MTRQTY As String
        Dim IMU_CFT As String
        Dim IMU_CUS1NO As String
        Dim IMU_CUS2NO As String
        Dim IMU_FTYPRCTRM As String
        Dim IMU_HKPRCTRM As String
        Dim IMU_TRANTRM As String
        Dim IMU_EFFDAT As String
        Dim IMU_EXPDAT As String
        Dim IMU_STATUS As String
        Dim IMU_CURCDE As String
        Dim IMU_FTYCST As String
        Dim IMU_FTYCSTA As String
        Dim IMU_FTYCSTB As String
        Dim IMU_FTYCSTC As String
        Dim IMU_FTYCSTD As String
        Dim IMU_FTYCSTE As String
        Dim IMU_FTYCSTTRAN As String
        Dim IMU_FTYCSTPACK As String
        Dim IMU_FML As String
        Dim IMU_FMLA As String
        Dim IMU_FMLB As String
        Dim IMU_FMLC As String
        Dim IMU_FMLD As String
        Dim IMU_FMLE As String
        Dim IMU_FMLTRAN As String
        Dim IMU_FMLPACK As String
        Dim IMU_CHGFP As String
        Dim IMU_CHGFPA As String
        Dim IMU_CHGFPB As String
        Dim IMU_CHGFPC As String
        Dim IMU_CHGFPD As String
        Dim IMU_CHGFPE As String
        Dim IMU_CHGFPTRAN As String
        Dim IMU_CHGFPPACK As String
        Dim IMU_FTYPRC As String
        Dim IMU_FTYPRCA As String
        Dim IMU_FTYPRCB As String
        Dim IMU_FTYPRCC As String
        Dim IMU_FTYPRCD As String
        Dim IMU_FTYPRCE As String
        Dim IMU_FTYPRCTRAN As String
        Dim IMU_FTYPRCPACK As String
        Dim IMU_BOMCST As String
        Dim IMU_TTLCST As String
        Dim IMU_HKADJPER As String
        Dim IMU_NEGCST As String
        Dim IMU_NEGPRC As String
        Dim IMU_FMLOPT As String
        Dim IMU_BCURCDE As String
        Dim IMU_ITMPRC As String
        Dim IMU_BOMPRC As String
        Dim IMU_BASPRC As String
        Dim IMU_PERIOD As String
        Dim IMU_CSTCHGDAT As String
        Dim IMU_PCKUNT_ORG As String
        Dim IMU_CONFTR_ORG As String
        Dim IMU_INRQTY_ORG As String
        Dim IMU_MTRQTY_ORG As String
        Dim IMU_CFT_ORG As String
        Dim IMU_CUS1NO_ORG As String
        Dim IMU_CUS2NO_ORG As String
        Dim IMU_FTYPRCTRM_ORG As String
        Dim IMU_HKPRCTRM_ORG As String
        Dim IMU_TRANTRM_ORG As String
        Dim IMU_CREUSR As String
        Dim IMU_ESTPRCFLG As String
        Dim IMU_ESTPRCREF As String

        Dim i As Integer

        For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
            IMU_COCDE = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cocde")
            IMU_ITMNO = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_itmno")
            If IMU_ITMNO = "" Then
                IMU_ITMNO = txtItmNo.Text
            End If
            IMU_TYP = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_typ")
            IMU_VENTYP = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ventyp")
            IMU_VENNO = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_venno")
            IMU_PRDVEN = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_prdven")
            IMU_PCKUNT = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_pckunt")
            IMU_CONFTR = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_conftr")
            IMU_INRQTY = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_inrqty")
            IMU_MTRQTY = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_mtrqty")
            IMU_CFT = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cft")
            IMU_CUS1NO = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cus1no")
            IMU_CUS2NO = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cus2no")
            IMU_FTYPRCTRM = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprctrm")
            IMU_HKPRCTRM = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_hkprctrm")
            IMU_TRANTRM = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_trantrm")
            IMU_EFFDAT = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_effdat")
            IMU_EXPDAT = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_expdat")
            IMU_STATUS = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_status")
            IMU_CURCDE = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_curcde")
            IMU_FTYCST = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycst")
            IMU_FTYCSTA = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstA")
            IMU_FTYCSTB = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstB")
            IMU_FTYCSTC = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstC")
            IMU_FTYCSTD = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstD")
            IMU_FTYCSTE = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstE")
            IMU_FTYCSTTRAN = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstTran")
            IMU_FTYCSTPACK = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftycstPack")
            '            IMU_FML = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_fml")
            '            IMU_FMLA = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_fmlA")
            '            IMU_FMLB = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_fmlB")
            '            IMU_FMLC = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_fmlC")
            '            IMU_FMLD = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_fmlD")
            '            IMU_FMLE = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_fmlE")
            '            IMU_FMLTRAN = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_fmlTran")
            '            IMU_FMLPACK = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_fmlPack")
            IMU_FML = ""
            IMU_FMLA = ""
            IMU_FMLB = ""
            IMU_FMLC = ""
            IMU_FMLD = ""
            IMU_FMLE = ""
            IMU_FMLTRAN = ""
            IMU_FMLPACK = ""
            IMU_CHGFP = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfp")
            IMU_CHGFPA = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpA")
            IMU_CHGFPB = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpB")
            IMU_CHGFPC = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpC")
            IMU_CHGFPD = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpD")
            IMU_CHGFPE = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpE")
            IMU_CHGFPTRAN = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpTran")
            IMU_CHGFPPACK = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_chgfpPack")
            IMU_FTYPRC = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprc")
            IMU_FTYPRCA = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcA")
            IMU_FTYPRCB = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcB")
            IMU_FTYPRCC = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcC")
            IMU_FTYPRCD = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcD")
            IMU_FTYPRCE = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcE")
            IMU_FTYPRCTRAN = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcTran")
            IMU_FTYPRCPACK = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprcPack")
            IMU_BOMCST = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_bomcst")
            IMU_TTLCST = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ttlcst")
            IMU_HKADJPER = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_hkadjper")
            IMU_NEGCST = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_negcst")
            IMU_NEGPRC = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_negprc")
            IMU_FMLOPT = Split(rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_fmlopt"), " - ")(0)
            IMU_BCURCDE = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_bcurcde")
            IMU_ITMPRC = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_itmprc")
            IMU_BOMPRC = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_bomprc")
            IMU_BASPRC = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_basprc")
            If IsDBNull(rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_estprcflg")) Then
                IMU_ESTPRCFLG = "N"
            Else
                IMU_ESTPRCFLG = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_estprcflg")
            End If
            IMU_ESTPRCREF = Replace(rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_estprcref"), "'", "''")
            IMU_PERIOD = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_period")
            IMU_CSTCHGDAT = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cstchgdat")

            IMU_PCKUNT_ORG = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_pckunt_org")
            IMU_CONFTR_ORG = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_conftr_org")
            IMU_INRQTY_ORG = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_inrqty_org")
            IMU_MTRQTY_ORG = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_mtrqty_org")
            IMU_CFT_ORG = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cft_org")
            IMU_CUS1NO_ORG = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cus1no_org")
            IMU_CUS2NO_ORG = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cus2no_org")
            IMU_FTYPRCTRM_ORG = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprctrm_org")
            IMU_HKPRCTRM_ORG = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_hkprctrm_org")
            IMU_TRANTRM_ORG = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_trantrm_org")

            IMU_CREUSR = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_creusr")


            gspStr = ""
            If IMU_COCDE = "Y" Or IMU_CREUSR = "~*DEL*~" Then
                gspStr = "sp_physical_delete_IMPRCINF '','" & IMU_ITMNO & "','" & IMU_VENNO & "','" & IMU_PRDVEN & "','" & IMU_PCKUNT_ORG & "'," & IMU_INRQTY_ORG & "," & _
                                                                IMU_MTRQTY_ORG & ",'" & IMU_CUS1NO_ORG & "','" & IMU_CUS2NO_ORG & "','" & IMU_FTYPRCTRM_ORG & "','" & IMU_HKPRCTRM_ORG & "','" & _
                                                                IMU_TRANTRM_ORG & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_IMPRCINF sp_physical_delete_IMPRCINF:" & rtnStr)
                    save_IMPRCINF = False
                    Exit Function
                End If
            ElseIf IMU_CREUSR = "~*ADD*~" Or IMU_CREUSR = "~*NEW*~" Then
                gspStr = "sp_insert_IMPRCINF '" & IMU_COCDE & "','" & IMU_ITMNO & "','" & IMU_TYP & "','" & IMU_VENTYP & "','" & IMU_VENNO & "','" & _
                                                        IMU_PRDVEN & "','" & IMU_PCKUNT & "'," & IMU_CONFTR & "," & IMU_INRQTY & "," & IMU_MTRQTY & "," & _
                                                        IMU_CFT & ",'" & IMU_CUS1NO & "','" & IMU_CUS2NO & "','" & IMU_FTYPRCTRM & "','" & IMU_HKPRCTRM & "','" & _
                                                        IMU_TRANTRM & "','" & IMU_EFFDAT & "','" & IMU_EXPDAT & "','" & IMU_STATUS & "','" & IMU_CURCDE & "'," & _
                                                        IMU_FTYCST & "," & IMU_FTYCSTA & "," & IMU_FTYCSTB & "," & IMU_FTYCSTC & "," & IMU_FTYCSTD & "," & _
                                                        IMU_FTYCSTE & "," & _
                                                        IMU_FTYCSTTRAN & "," & IMU_FTYCSTPACK & ",'" & IMU_FML & "','" & IMU_FMLA & "','" & IMU_FMLB & "','" & _
                                                        IMU_FMLC & "','" & IMU_FMLD & "','" & _
                                                        IMU_FMLE & "','" & _
                                                        IMU_FMLTRAN & "','" & IMU_FMLPACK & "'," & IMU_CHGFP & "," & _
                                                        IMU_CHGFPA & "," & IMU_CHGFPB & "," & IMU_CHGFPC & "," & IMU_CHGFPD & "," & _
                                                        IMU_CHGFPE & "," & _
                                                        IMU_CHGFPTRAN & "," & _
                                                        IMU_CHGFPPACK & "," & IMU_FTYPRC & "," & IMU_FTYPRCA & "," & IMU_FTYPRCB & "," & IMU_FTYPRCC & "," & _
                                                        IMU_FTYPRCD & "," & _
                                                        IMU_FTYPRCE & "," & _
                                                        IMU_FTYPRCTRAN & "," & IMU_FTYPRCPACK & "," & IMU_BOMCST & "," & IMU_TTLCST & "," & _
                                                        IMU_HKADJPER & "," & IMU_NEGCST & "," & IMU_NEGPRC & ",'" & IMU_FMLOPT & "','" & IMU_BCURCDE & "'," & IMU_ITMPRC & "," & _
                                                        IMU_BOMPRC & "," & IMU_BASPRC & ",'" & IMU_ESTPRCFLG & "','" & IMU_ESTPRCREF & "','" & IMU_PERIOD & "','" & _
                                                        IMU_CSTCHGDAT & "','" & LCase(gsUsrID) & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_IMPRCINF sp_insert_IMPRCINF :" & rtnStr)
                    save_IMPRCINF = False
                    Exit Function
                End If
            ElseIf IMU_CREUSR = "~*UPD*~" Then
                gspStr = "sp_update_IMPRCINF '" & IMU_COCDE & "','" & IMU_ITMNO & "','" & IMU_TYP & "','" & IMU_VENTYP & "','" & IMU_VENNO & "','" & _
                                                        IMU_PRDVEN & "','" & IMU_PCKUNT & "'," & IMU_CONFTR & "," & IMU_INRQTY & "," & IMU_MTRQTY & "," & _
                                                        IMU_CFT & ",'" & IMU_CUS1NO & "','" & IMU_CUS2NO & "','" & IMU_FTYPRCTRM & "','" & IMU_HKPRCTRM & "','" & _
                                                        IMU_TRANTRM & "','" & IMU_EFFDAT & "','" & IMU_EXPDAT & "','" & IMU_STATUS & "','" & IMU_CURCDE & "'," & _
                                                        IMU_FTYCST & "," & IMU_FTYCSTA & "," & IMU_FTYCSTB & "," & IMU_FTYCSTC & "," & IMU_FTYCSTD & "," & _
                                                        IMU_FTYCSTE & "," & _
                                                        IMU_FTYCSTTRAN & "," & IMU_FTYCSTPACK & ",'" & IMU_FML & "','" & IMU_FMLA & "','" & IMU_FMLB & "','" & _
                                                        IMU_FMLC & "','" & IMU_FMLD & "','" & _
                                                        IMU_FMLE & "','" & _
                                                        IMU_FMLTRAN & "','" & IMU_FMLPACK & "'," & IMU_CHGFP & "," & _
                                                        IMU_CHGFPA & "," & IMU_CHGFPB & "," & IMU_CHGFPC & "," & IMU_CHGFPD & "," & _
                                                        IMU_CHGFPE & "," & _
                                                        IMU_CHGFPTRAN & "," & _
                                                        IMU_CHGFPPACK & "," & IMU_FTYPRC & "," & IMU_FTYPRCA & "," & IMU_FTYPRCB & "," & IMU_FTYPRCC & "," & _
                                                        IMU_FTYPRCD & "," & _
                                                        IMU_FTYPRCE & "," & _
                                                        IMU_FTYPRCTRAN & "," & IMU_FTYPRCPACK & "," & IMU_BOMCST & "," & IMU_TTLCST & "," & _
                                                        IMU_HKADJPER & "," & IMU_NEGCST & "," & IMU_NEGPRC & ",'" & IMU_FMLOPT & "','" & IMU_BCURCDE & "'," & IMU_ITMPRC & "," & _
                                                        IMU_BOMPRC & "," & IMU_BASPRC & ",'" & IMU_ESTPRCFLG & "','" & IMU_ESTPRCREF & "','" & IMU_PERIOD & "','" & IMU_CSTCHGDAT & "','" & _
                                                        IMU_PCKUNT_ORG & "'," & IMU_CONFTR_ORG & "," & IMU_INRQTY_ORG & "," & IMU_MTRQTY_ORG & "," & IMU_CFT_ORG & ",'" & _
                                                        IMU_CUS1NO_ORG & "','" & IMU_CUS2NO_ORG & "','" & IMU_FTYPRCTRM_ORG & "','" & IMU_HKPRCTRM_ORG & "','" & IMU_TRANTRM_ORG & "','" & LCase(gsUsrID) & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_IMPRCINF sp_update_IMPRCINF :" & rtnStr)
                    save_IMPRCINF = False
                    Exit Function
                End If
            End If
        Next i

        save_IMPRCINF = True
    End Function

    Private Function save_IMCSTINF() As Boolean
        If rs_IMCSTINF.Tables("RESULT").Rows.Count = 0 Then
            save_IMCSTINF = True
            Exit Function
        End If

        Dim ICI_COCDE As String
        Dim ICI_ITMNO As String
        Dim ICI_CSTRMK As String
        Dim ICI_EXPDAT As String
        Dim ICI_CREUSR As String

        ICI_COCDE = rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_cocde")
        ICI_ITMNO = rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_itmno")
        ICI_CSTRMK = Replace(txtCstRmk.Text, "'", "''") 'rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_cstrmk")
        ICI_EXPDAT = txtCstExpDat.Text 'rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_expdat")
        ICI_CREUSR = rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_creusr")

        gspStr = ""
        If ICI_CREUSR = "~*UPD*~" Then
            gspStr = "sp_update_IMCSTINF '" & ICI_COCDE & "','" & ICI_ITMNO & "','" & ICI_CSTRMK & "','" & ICI_EXPDAT & "','" & gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading save_IMCSTINF sp_update_IMCSTINF :" & rtnStr)
                save_IMCSTINF = False
                Exit Function
            End If
        ElseIf ICI_CREUSR = "~*ADD*~" Then
            gspStr = "sp_insert_IMCSTINF '" & ICI_COCDE & "','" & ICI_ITMNO & "','" & ICI_CSTRMK & "','" & ICI_EXPDAT & "','" & gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading save_IMCSTINF sp_insert_IMCSTINF :" & rtnStr)
                save_IMCSTINF = False
                Exit Function
            End If
        End If

        save_IMCSTINF = True
    End Function

    Private Function save_IMCTYINF() As Boolean
        If rs_IMCTYINF.Tables("RESULT").Rows.Count = 0 Then
            save_IMCTYINF = True
            Exit Function
        End If

        Dim ICI_COCDE As String
        Dim ICI_ITMNO As String
        Dim ICI_CTYSEQ As Integer
        Dim ICI_CUSNO As String
        Dim ICI_CTYCDE As String
        Dim ICI_VALDAT As String
        Dim ICI_RMK As String
        Dim ICI_CREUSR As String

        Dim i As Integer

        For i = 0 To rs_IMCTYINF.Tables("RESULT").Rows.Count - 1
            ICI_COCDE = rs_IMCTYINF.Tables("RESULT").Rows(i).Item("ici_cocde")
            ICI_ITMNO = rs_IMCTYINF.Tables("RESULT").Rows(i).Item("ici_itmno")
            ICI_CTYSEQ = rs_IMCTYINF.Tables("RESULT").Rows(i).Item("ici_ctyseq")
            ICI_CUSNO = Split(rs_IMCTYINF.Tables("RESULT").Rows(i).Item("ici_cusno"), " - ")(0)
            ICI_CTYCDE = Split(rs_IMCTYINF.Tables("RESULT").Rows(i).Item("ici_ctycde"), " - ")(0)
            ICI_VALDAT = rs_IMCTYINF.Tables("RESULT").Rows(i).Item("ici_valdat")
            ICI_RMK = rs_IMCTYINF.Tables("RESULT").Rows(i).Item("ici_rmk")
            ICI_CREUSR = rs_IMCTYINF.Tables("RESULT").Rows(i).Item("ici_creusr")

            gspStr = ""
            If ICI_COCDE = "Y" Then
                If ICI_CREUSR = "~*UPD*~" Then
                    gspStr = "sp_physical_delete_IMCTYINF '','" & ICI_ITMNO & "'," & ICI_CTYSEQ
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_IMCTYINF sp_physical_delete_IMCTYINF:" & rtnStr)
                        save_IMCTYINF = False
                        Exit Function
                    End If
                End If
            ElseIf ICI_CREUSR = "~*ADD*~" Or ICI_CREUSR = "~*NEW*~" Then
                If ICI_CUSNO <> "" Then
                    gspStr = "sp_insert_IMCTYINF '" & ICI_COCDE & "','" & ICI_ITMNO & "','" & ICI_CUSNO & "','" & ICI_CTYCDE & "','" & _
                                                        ICI_VALDAT & "','" & ICI_RMK & "','" & gsUsrID & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_IMCTYINF sp_insert_IMCTYINF :" & rtnStr)
                        save_IMCTYINF = False
                        Exit Function
                    End If
                End If
            ElseIf ICI_CREUSR = "~*UPD*~" Then
                gspStr = "sp_update_IMCTYINF '" & ICI_COCDE & "','" & ICI_ITMNO & "','" & ICI_CTYSEQ & "','" & ICI_CUSNO & "','" & ICI_CTYCDE & "','" & _
                                                   ICI_VALDAT & "','" & ICI_RMK & "','" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_IMCTYINF sp_update_IMCTYINF :" & rtnStr)
                    save_IMCTYINF = False
                    Exit Function
                End If
            End If
        Next i

        save_IMCTYINF = True
    End Function

    Private Function save_IMMATBKD() As Boolean
        If rs_IMMATBKD.Tables("RESULT").Rows.Count = 0 Then
            save_IMMATBKD = True
            Exit Function
        End If

        Dim IBM_COCDE As String
        Dim IBM_ITMNO As String
        Dim IBM_MATSEQ As String
        Dim IBM_MAT As String
        Dim IBM_CURCDE As String
        Dim IBM_CST As String
        Dim IBM_CSTPER As String
        Dim IBM_WGTPER As String
        Dim IBM_CREUSR As String


        Dim i As Integer

        For i = 0 To rs_IMMATBKD.Tables("RESULT").Rows.Count - 1
            IBM_COCDE = rs_IMMATBKD.Tables("RESULT").Rows(i).Item("ibm_cocde")
            IBM_ITMNO = rs_IMMATBKD.Tables("RESULT").Rows(i).Item("ibm_itmno")
            IBM_MATSEQ = rs_IMMATBKD.Tables("RESULT").Rows(i).Item("ibm_matseq")
            IBM_MAT = rs_IMMATBKD.Tables("RESULT").Rows(i).Item("ibm_mat")
            IBM_CURCDE = rs_IMMATBKD.Tables("RESULT").Rows(i).Item("ibm_curcde")
            IBM_CST = rs_IMMATBKD.Tables("RESULT").Rows(i).Item("ibm_cst")
            IBM_CSTPER = rs_IMMATBKD.Tables("RESULT").Rows(i).Item("ibm_cstper")
            IBM_WGTPER = rs_IMMATBKD.Tables("RESULT").Rows(i).Item("ibm_wgtper")
            IBM_CREUSR = rs_IMMATBKD.Tables("RESULT").Rows(i).Item("ibm_creusr")

            gspStr = ""
            If IBM_COCDE = "Y" Then
                If IBM_CREUSR = "~*UPD*~" Then
                    gspStr = "sp_physical_delete_IMMATBKD '','" & IBM_ITMNO & "'," & IBM_MATSEQ
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_IMMATBKD sp_physical_delete_IMMATBKD :" & rtnStr)
                        save_IMMATBKD = False
                        Exit Function
                    End If
                End If
            ElseIf IBM_CREUSR = "~*ADD*~" Or IBM_CREUSR = "~*NEW*~" Then
                If IBM_MAT <> "" Then
                    gspStr = "sp_insert_IMMATBKD '" & IBM_COCDE & "','" & IBM_ITMNO & "','" & IBM_MAT & "','" & IBM_CURCDE & "'," & _
                                                        IBM_CST & "," & IBM_CSTPER & "," & IBM_WGTPER & ",'" & gsUsrID & "'"

                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_IMMATBKD sp_insert_IMMATBKD :" & rtnStr)
                        save_IMMATBKD = False
                        Exit Function
                    End If
                End If
            ElseIf IBM_CREUSR = "~*UPD*~" Then
                gspStr = "sp_update_IMMATBKD '" & IBM_COCDE & "','" & IBM_ITMNO & "','" & IBM_MATSEQ & "','" & IBM_MAT & "','" & IBM_CURCDE & "'," & _
                                                    IBM_CST & "," & IBM_CSTPER & "," & IBM_WGTPER & ",'" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_IMMATBKD sp_update_IMMATBKD :" & rtnStr)
                    save_IMMATBKD = False
                    Exit Function
                End If
            End If
        Next i

        save_IMMATBKD = True
    End Function

    Private Function save_IMVENINF() As Boolean
        If rs_IMVENINF.Tables("RESULT").Rows.Count = 0 Then
            save_IMVENINF = True
            Exit Function
        End If

        Dim IVI_COCDE As String
        Dim IVI_ITMNO As String
        Dim IVI_VENITM As String
        Dim IVI_VENNO As String
        Dim IVI_SUBCDE As String
        Dim IVI_DEF As String
        Dim IVI_CREUSR As String

        Dim i As Integer

        For i = 0 To rs_IMVENINF.Tables("RESULT").Rows.Count - 1
            IVI_COCDE = rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_cocde")
            IVI_ITMNO = rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_itmno")
            If IVI_ITMNO = "" Then
                IVI_ITMNO = txtItmNo.Text
            End If
            IVI_VENITM = rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_venitm")
            IVI_VENNO = rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_venno")
            IVI_SUBCDE = rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_subcde")
            IVI_DEF = rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_def")
            IVI_CREUSR = rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_creusr")

            gspStr = ""
            If IVI_COCDE = "Y" Or IVI_CREUSR = "~*DEL*~" Then
                gspStr = "sp_physical_delete_IMVENINF '','" & IVI_ITMNO & "','" & IVI_VENNO & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_IMVENINF sp_physical_delete_IMVENINF :" & rtnStr)
                    save_IMVENINF = False
                    Exit Function
                End If
            ElseIf IVI_CREUSR = "~*ADD*~" Or IVI_CREUSR = "~*NEW*~" Then
                If IVI_VENNO <> "" Then
                    gspStr = "sp_insert_IMVENINF '" & IVI_COCDE & "','" & IVI_ITMNO & "','" & IVI_VENITM & "','" & IVI_VENNO & "','" & _
                                                        IVI_SUBCDE & "','" & IVI_DEF & "','" & gsUsrID & "'"

                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_IMVENINF sp_insert_IMVENINF :" & rtnStr)
                        save_IMVENINF = False
                        Exit Function
                    End If
                End If
            ElseIf IVI_CREUSR = "~*UPD*~" Then
                gspStr = "sp_update_IMVENINF '" & IVI_COCDE & "','" & IVI_ITMNO & "','" & IVI_VENITM & "','" & IVI_VENNO & "','" & IVI_SUBCDE & "','" & _
                                                    IVI_DEF & "','" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_IMVENINF sp_update_IMVENINF :" & rtnStr)
                    save_IMVENINF = False
                    Exit Function
                End If
            End If
        Next i
        save_IMVENINF = True
    End Function

    Private Sub cboDV_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDV.KeyUp
        auto_search_combo(cboDV, e.KeyCode)
    End Sub

    Private Sub cboDV_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDV.LostFocus
        If cboDV.SelectedIndex = -1 Then
            cboDV.Select()
        End If
    End Sub


    Private Sub cboDV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDV.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboDV.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim dv As String
                    dv = Split(cboDV.Text, " - ")(0)
                    If dv <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_venno") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboPrdTyp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrdTyp.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboPrdTyp.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim prdtyp As String
                    prdtyp = Split(cboPrdTyp.Text, " - ")(0)
                    If prdtyp <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_prdtyp") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboCV_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCV.KeyUp
        auto_search_combo(cboCV, e.KeyCode)
    End Sub

    Private Sub cboCV_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCV.LostFocus
        If cboCV.SelectedIndex = -1 Then
            cboCV.Select()
        End If
    End Sub

    Private Sub cboCV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCV.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboCV.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim cv As String
                    cv = Split(cboCV.Text, " - ")(0)
                    If cv <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_cusven") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboTV_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTV.KeyUp
        auto_search_combo(cboTV, e.KeyCode)
    End Sub

    Private Sub cboTV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTV.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboTV.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim tv As String
                    tv = Split(cboTV.Text, " - ")(0)
                    If tv <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_tradeven") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboEV_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEV.KeyUp
        auto_search_combo(cboEV, e.KeyCode)
    End Sub

    Private Sub cboEV_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEV.LostFocus
        If cboEV.SelectedIndex = -1 Then
            cboEV.Select()
        End If
    End Sub

    Private Sub cboEV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEV.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboEV.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim ev As String
                    ev = Split(cboEV.Text, " - ")(0)
                    If ev <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_examven") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgColor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgColor.GotFocus
        lblColor.ForeColor = Color.DarkCyan
        Got_Focus_Grid = "dgColor"
    End Sub

    Private Sub dgColor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgColor.LostFocus
        lblColor.ForeColor = Color.Blue
    End Sub

    Private Sub dgPacking_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPacking.CellClick
        Dim creusr As String = dgPacking.Item(dgPacking_ipi_creusr, dgPacking.CurrentCell.RowIndex).Value

        If dgPacking.CurrentCell.ColumnIndex = dgPacking_ipi_pckunt Then
            If creusr = "~*ADD*~" Then
                comboBoxCell(dgPacking, "UM")
            End If
        End If

    End Sub

    Private Sub dgPacking_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgPacking.EditingControlShowing
        If dgPacking.RowCount = 0 Then
            Exit Sub
        End If

        e.CellStyle.BackColor = Color.White

        Select Case dgPacking.CurrentCell.ColumnIndex
            'Case dgPacking_ipi_pckunt
            '    If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
            '        Dim cboBox As ComboBox = CType(e.Control, ComboBox)
            '        If Not cboBox Is Nothing Then
            '            RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbopckunt_dgPacking_SelectedIndexChanged
            '            AddHandler cboBox.SelectedIndexChanged, AddressOf cbopckunt_dgPacking_SelectedIndexChanged
            '        End If
            '    End If

            Case dgPacking_ipi_cbm, dgPacking_ipi_cft, dgPacking_inner_in, dgPacking_inner_cm, dgPacking_master_in, dgPacking_master_cm, dgPacking_ipi_grswgt, dgPacking_ipi_netwgt
                Dim txtbox As TextBox = CType(e.Control, TextBox)
                If Not (txtbox Is Nothing) Then
                    AddHandler txtbox.KeyPress, AddressOf txt_dgPacking_KeyPress
                    AddHandler txtbox.TextChanged, AddressOf txt_dgPacking_TextChanged
                End If
        End Select

        If mode = "UPDATE" Or mode = "ADD" Then
            Recordstatus = True
            Dim CREUSR As String = dgPacking.Item(dgPacking_ipi_creusr, dgPacking.CurrentCell.RowIndex).Value

            If CREUSR <> "~*ADD*~" Then
                dgPacking.Item(dgPacking_ipi_creusr, dgPacking.CurrentCell.RowIndex).Value = "~*UPD*~"
            End If
            'Dim CREUSR As String = rs_IMPCKINF.Tables("RESULT").Rows(dgPacking.CurrentCell.RowIndex).Item("ipi_creusr")
            'If CREUSR <> "~*ADD*~" And CREUSR <> "~*UPD*~" And CREUSR <> "~*DEL*~" And CREUSR <> "~*NEW*~" Then
            '    rs_IMPCKINF.Tables("RESULT").Rows(dgPacking.CurrentCell.RowIndex).Item("ipi_creusr") = "~*UPD*~"
            'End If
        End If
    End Sub

    Private Sub txt_dgPacking_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim iRow As Integer = dgPacking.CurrentCell.RowIndex
        Dim iCol As Integer = dgPacking.CurrentCell.ColumnIndex

        Dim curvalue As String = dgPacking.CurrentCell.EditedFormattedValue

        Select Case dgPacking.CurrentCell.ColumnIndex
            Case dgPacking_ipi_cft, dgPacking_ipi_cbm, dgPacking_ipi_grswgt, dgPacking_ipi_netwgt
                ' Check Numeric
                If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
                    e.KeyChar = ""
                Else
                    If curvalue.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                        e.KeyChar = ""
                    End If
                End If
                flag_dgPacking_keypress = True
            Case dgPacking_inner_in, dgPacking_inner_cm, dgPacking_master_in, dgPacking_master_cm
                If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "x" Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
                    e.KeyChar = ""
                End If
                flag_dgPacking_keypress = True
            Case dgPacking_ipi_grswgt, dgPacking_ipi_netwgt
                If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
                    e.KeyChar = ""
                    If curvalue.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                        e.KeyChar = ""
                    End If
                End If
        End Select


    End Sub


    Private Sub txt_dgPacking_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = dgPacking.CurrentCell.RowIndex
        Dim iCol As Integer = dgPacking.CurrentCell.ColumnIndex

        Dim curvalue As String = dgPacking.CurrentCell.EditedFormattedValue
        Dim i As Integer

        Select dgPacking.CurrentCell.ColumnIndex
            Case dgPacking_ipi_cft
                If flag_dgPacking_keypress = True Then
                    flag_dgPacking_keypress = False
                    Dim cbm_value As Decimal
                    If IsNumeric(curvalue) Then
                        cbm_value = curvalue * CFT_CBM
                        dgPacking.Item(dgPacking_ipi_cbm, iRow).Value = Decimal.Round(cbm_value, 4)
                    End If
                End If
            Case dgPacking_ipi_cbm
                If flag_dgPacking_keypress = True Then
                    flag_dgPacking_keypress = False
                    Dim cft_value As Decimal
                    If IsNumeric(curvalue) Then
                        cft_value = curvalue * CBM_CFT
                        dgPacking.Item(dgPacking_ipi_cft, iRow).Value = Decimal.Round(cft_value, 4)
                    End If
                End If
            Case dgPacking_ipi_grswgt, dgPacking_ipi_netwgt
                If flag_dgPacking_keypress = True Then
                    flag_dgPacking_keypress = False
                End If
            Case dgPacking_inner_in, dgPacking_inner_cm, dgPacking_master_in, dgPacking_master_cm
                If flag_dgPacking_keypress = True Then
                    flag_dgPacking_keypress = False

                    Dim tmpstrarry As String() = Split(curvalue, "x")
                    Dim validformat As Boolean
                    validformat = True
                    If tmpstrarry.Length <> 3 Then
                        validformat = False
                    End If
                    If validformat Then
                        For i = 0 To tmpstrarry.Length - 1
                            If Not IsNumeric(tmpstrarry(i)) Then
                                validformat = False
                            End If
                        Next i
                    End If

                    If validformat Then
                        Dim resultstr As String
                        Dim tmpvalL As Decimal
                        Dim tmpvalW As Decimal
                        Dim tmpvalH As Decimal

                        resultstr = ""
                        tmpvalL = 0.0
                        tmpvalW = 0.0
                        tmpvalH = 0.0

                        tmpvalL = Split(curvalue, "x")(0)
                        tmpvalW = Split(curvalue, "x")(1)
                        tmpvalH = Split(curvalue, "x")(2)

                        Select Case dgPacking.CurrentCell.ColumnIndex
                            Case dgPacking_inner_in
                                tmpvalL = Decimal.Round(tmpvalL * In_CM, 4)
                                tmpvalW = Decimal.Round(tmpvalW * In_CM, 4)
                                tmpvalH = Decimal.Round(tmpvalH * In_CM, 4)
                                resultstr = tmpvalL & "x" & tmpvalW & "x" & tmpvalH
                                dgPacking.Item(dgPacking_inner_cm, iRow).Value = resultstr
                            Case dgPacking_inner_cm
                                tmpvalL = Decimal.Round(tmpvalL * CM_In, 4)
                                tmpvalW = Decimal.Round(tmpvalW * CM_In, 4)
                                tmpvalH = Decimal.Round(tmpvalH * CM_In, 4)
                                resultstr = tmpvalL & "x" & tmpvalW & "x" & tmpvalH
                                dgPacking.Item(dgPacking_inner_in, iRow).Value = resultstr
                            Case dgPacking_master_in
                                tmpvalL = Decimal.Round(tmpvalL * In_CM, 4)
                                tmpvalW = Decimal.Round(tmpvalW * In_CM, 4)
                                tmpvalH = Decimal.Round(tmpvalH * In_CM, 4)
                                resultstr = tmpvalL & "x" & tmpvalW & "x" & tmpvalH
                                dgPacking.Item(dgPacking_master_cm, iRow).Value = resultstr

                                If IsNumeric(tmpvalL) And IsNumeric(tmpvalW) And IsNumeric(tmpvalH) Then
                                    Dim tmp_cbm As Decimal
                                    Dim tmp_cft As Decimal
                                    tmp_cbm = Decimal.Round(tmpvalL * tmpvalW * tmpvalH / 1000000, 4)
                                    tmp_cft = Decimal.Round(tmp_cbm * CBM_CFT, 4)
                                    dgPacking.Item(dgPacking_ipi_cbm, iRow).Value = tmp_cbm
                                    dgPacking.Item(dgPacking_ipi_cft, iRow).Value = tmp_cft
                                End If
                            Case dgPacking_master_cm
                                If IsNumeric(tmpvalL) And IsNumeric(tmpvalW) And IsNumeric(tmpvalH) Then
                                    Dim tmp_cbm As Decimal
                                    Dim tmp_cft As Decimal
                                    tmp_cbm = Decimal.Round(tmpvalL * tmpvalW * tmpvalH / 1000000, 4)
                                    tmp_cft = Decimal.Round(tmp_cbm * CBM_CFT, 4)
                                    dgPacking.Item(dgPacking_ipi_cbm, iRow).Value = tmp_cbm
                                    dgPacking.Item(dgPacking_ipi_cft, iRow).Value = tmp_cft
                                End If

                                tmpvalL = Decimal.Round(tmpvalL * CM_In, 4)
                                tmpvalW = Decimal.Round(tmpvalW * CM_In, 4)
                                tmpvalH = Decimal.Round(tmpvalH * CM_In, 4)
                                resultstr = tmpvalL & "x" & tmpvalW & "x" & tmpvalH
                                dgPacking.Item(dgPacking_master_in, iRow).Value = resultstr
                        End Select
                    End If
                End If
        End Select
    End Sub

    Private Sub dgPacking_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPacking.GotFocus
        lblPacking.ForeColor = Color.DarkCyan
        Got_Focus_Grid = "dgPacking"
    End Sub

    Private Sub dgPacking_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPacking.LostFocus
        lblPacking.ForeColor = Color.Blue
        'Got_Focus_Grid = ""
        'PanelPacking.Visible = False
    End Sub

    Private Sub dgPV_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPV.CellClick
        'If dgPV.Item(9, dgPV.CurrentCell.RowIndex).Value <> "~*ADD*~" Then
        '    Exit Sub
        'End If
        'If dgPV.CurrentCell.ColumnIndex = 4 Then
        '    Call comboBoxCell(dgPV, "Vendor")
        'End If
    End Sub

    Private Sub dgPV_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPV.CellDoubleClick
        If mode = "READ" Then
            Exit Sub
        End If

        If dgPV.SelectedRows.Count = 0 And dgPV.CurrentCell.ColumnIndex = 1 Then
            Dim iCol As Integer = dgPV.CurrentCell.ColumnIndex
            Dim iRow As Integer = dgPV.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = dgPV.CurrentCell.Value

            If Trim(curvalue) = "" Then
                delete_PV()
            Else
                undelete_PV()
            End If
        ElseIf dgPV.CurrentCell.ColumnIndex = 7 Then
            changeDefaultPV()
        End If
    End Sub

    Private Sub dgPV_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgPV.EditingControlShowing
        Recordstatus = True
        If mode = "UPDATE" Then
            Dim CREUSR As String = rs_IMVENINF.Tables("RESULT").Rows(dgPV.CurrentCell.RowIndex).Item("ivi_creusr")
            If CREUSR <> "~*ADD*~" And CREUSR <> "~*UPD*~" And CREUSR <> "~*DEL*~" And CREUSR <> "~*NEW*~" Then
                Recordstatus = True
                rs_IMVENINF.Tables("RESULT").Rows(dgPV.CurrentCell.RowIndex).Item("ivi_creusr") = "~*UPD*~"
            End If
        End If
    End Sub

    Private Sub dgPV_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPV.GotFocus
        lblPV.ForeColor = Color.DarkCyan
        Got_Focus_Grid = "dgPV"
    End Sub

    Private Sub dgPV_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPV.LostFocus
        lblPV.ForeColor = Color.Black
        ' Got_Focus_Grid = ""
    End Sub

    Private Sub dgOEMCustomer_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOEMCustomer.CellClick
        If dgOEMCustomer.RowCount = 0 Then
            Exit Sub
        End If
        If dgOEMCustomer.CurrentCell.ColumnIndex = 2 Then
            If dgOEMCustomer.Item(7, dgOEMCustomer.CurrentCell.RowIndex).Value = "~*NEW*~" Or dgOEMCustomer.Item(7, dgOEMCustomer.CurrentCell.RowIndex).Value = "~*ADD*~" Then
                flag_dgOEMCustomer_mouseselect = True
                Call comboBoxCell(dgOEMCustomer, "CusnoAll")
            End If
        End If
    End Sub

    Private Sub dgOEMCustomer_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOEMCustomer.CellDoubleClick
        If mode = "READ" Then
            Exit Sub
        End If


        If dgOEMCustomer.RowCount = 0 Then
            Exit Sub
        End If
        If dgOEMCustomer.CurrentCell.ColumnIndex = 0 And dgOEMCustomer.SelectedRows.Count = 0 Then

            Dim del_oemcust As String
            del_oemcust = dgOEMCustomer.Item(2, dgOEMCustomer.CurrentCell.RowIndex).Value
            Dim tmp_oemcust As String

            Dim i As Integer
            For i = 0 To rs_IMCUSNO.Tables("RESULT").Rows.Count - 1
                tmp_oemcust = rs_IMCUSNO.Tables("RESULT").Rows(i).Item("icn_cusno")

                If tmp_oemcust = del_oemcust Then
                    If rs_IMCUSNO.Tables("RESULT").Rows(i).Item("icn_status") = "Y" Then
                        rs_IMCUSNO.Tables("RESULT").Rows(i).Item("icn_status") = ""
                    Else
                        rs_IMCUSNO.Tables("RESULT").Rows(i).Item("icn_status") = "Y"
                    End If
                    'rs_IMCUSNO.Tables("RESULT").Rows(i).Item("icn_creusr") = "~*DEL*~"
                    'rs_IMCUSNO.Tables("RESULT").Rows(i).Item("icn_status") = "Y"
                    Recordstatus = True
                End If
            Next i

        End If
    End Sub

    Private Sub dgOEMCustomer_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgOEMCustomer.GotFocus
        lblOEMCustomer.ForeColor = Color.DarkCyan
        Got_Focus_Grid = "dgOEMCustomer"
    End Sub

    Private Sub dgOEMCustomer_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgOEMCustomer.LostFocus
        lblOEMCustomer.ForeColor = Color.Black
        '  Got_Focus_Grid = ""
    End Sub

    Private Sub dgBOMASS_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBOMASS.CellClick
        If dgBOMASS.RowCount > 0 Then
            If dgBOMASS.CurrentCell.ColumnIndex = dgBOMASS_iba_colcde Then
                If dgBOMASS.CurrentCell.Value <> "" Then
                    'Exit Sub
                End If

                Dim cboCell As New DataGridViewComboBoxCell
                Dim iCol As Integer = dgBOMASS.CurrentCell.ColumnIndex
                Dim iRow As Integer = dgBOMASS.CurrentCell.RowIndex

                Dim row As DataGridViewRow = dgBOMASS.CurrentRow

                Dim bomasstyp As String
                If rbBOMASS_ASS.Checked = True Then
                    bomasstyp = "ASS"
                Else
                    bomasstyp = "BOM"
                End If

                gspStr = "sp_select_IMCOLINF_BOMASS '','" & dgBOMASS.Item(3, dgBOMASS.CurrentCell.RowIndex).Value & "','" & bomasstyp & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_IMCOLINF_BOMASS, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading txtbox_dgBOMASS_KeyPress sp_select_IMCOLINF_BOMASS :" & rtnStr)
                    Exit Sub
                End If

                If rs_IMCOLINF_BOMASS.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("Assorted/BOM item not found!")
                    Exit Sub
                End If
                If rs_IMCOLINF_BOMASS.Tables("RESULT").Rows(0).Item("ibi_itmsts") <> "CMP" Then
                    MsgBox("Assorted/BOM item status not complete!")
                    Exit Sub
                End If

                gspStr = "sp_select_IMPCKINF_BOMASS '','" & dgBOMASS.Item(3, dgBOMASS.CurrentCell.RowIndex).Value & "','" & bomasstyp & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_IMPCKINF_BOMASS, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading txtbox_dgBOMASS_KeyPress sp_select_IMPCKINF_BOMASS :" & rtnStr)
                    Exit Sub
                End If

                If rs_IMPCKINF_BOMASS.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("Assorted/BOM Packing item not found!")
                    Exit Sub
                End If


                Dim i As Integer
                'lbBOMColor.Items.Clear()
                For i = 0 To rs_IMCOLINF_BOMASS.Tables("RESULT").Rows.Count - 1
                    'lbBOMColor.Items.Add(rs_IMCOLINF_BOMASS.Tables("RESULT").Rows(i).Item("icf_colcde"))
                    cboCell.Items.Add(rs_IMCOLINF_BOMASS.Tables("RESULT").Rows(i).Item("icf_colcde"))
                Next i
                dgBOMASS.Rows(iRow).Cells(iCol).Value = rs_IMCOLINF_BOMASS.Tables("RESULT").Rows(0).Item("icf_colcde")
                ' cboCell.Items.Add(dgBOMASS.Rows(iRow).Cells(iCol).Value)
                cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                'lbBOMColor.Visible = True
                'lbBOMColor.Enabled = True
                dgBOMASS.Rows(iRow).Cells(iCol) = cboCell
                dgBOMASS.Rows(iRow).Cells(iCol).ReadOnly = False
            End If
        End If
    End Sub

    Private Sub dgBOMASS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBOMASS.CellDoubleClick
        If mode = "READ" Then
            Exit Sub
        End If

        If dgBOMASS.RowCount > 0 Then
            Dim iCol As Integer = dgBOMASS.CurrentCell.ColumnIndex
            Dim iRow As Integer = dgBOMASS.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = dgBOMASS.CurrentCell.Value

            Dim i As Integer

            If dgBOMASS.CurrentCell.ColumnIndex = dgBOMASS_iba_costing Then
                For i = 0 To dgBOMASS.RowCount - 1
                    If curvalue = "Basic Price" Then
                        dgBOMASS.Item(dgBOMASS_iba_costing, i).Value = "Costing"
                    Else
                        dgBOMASS.Item(dgBOMASS_iba_costing, i).Value = "Basic Price"
                    End If

                    If dgBOMASS.Item(dgBOMASS_iba_creusr, i).Value <> "~*ADD*~" Then
                        dgBOMASS.Item(dgBOMASS_iba_creusr, i).Value = "~*UPD*~"
                    End If
                Next i
                If dgBOMASS.Item(dgBOMASS_iba_colcde, iRow).Value <> "" Then
                    Call calculate_BOM()
                End If
                Recordstatus = True
            ElseIf dgBOMASS.CurrentCell.ColumnIndex = dgBOMASS_iba_genpo Then
                For i = 0 To dgBOMASS.RowCount - 1
                    If curvalue = "Y" Then
                        dgBOMASS.Item(dgBOMASS_iba_genpo, i).Value = "N"
                    Else
                        dgBOMASS.Item(dgBOMASS_iba_genpo, i).Value = "Y"
                    End If

                    If dgBOMASS.Item(dgBOMASS_iba_creusr, i).Value <> "~*ADD*~" Then
                        dgBOMASS.Item(dgBOMASS_iba_creusr, i).Value = "~*UPD*~"
                    End If
                Next i
                Recordstatus = True
            ElseIf dgBOMASS.CurrentCell.ColumnIndex = dgBOMASS_iba_cocde Then
                If Trim(curvalue) = "" Then
                    dgBOMASS.Item(dgBOMASS_iba_cocde, iRow).Value = "Y"
                Else
                    dgBOMASS.Item(dgBOMASS_iba_cocde, iRow).Value = ""
                End If

                If dgBOMASS.Item(dgBOMASS_iba_creusr, iRow).Value <> "~*ADD*~" Then
                    dgBOMASS.Item(dgBOMASS_iba_creusr, iRow).Value = "~*UPD*~"
                End If
                Call calculate_BOM()
                Recordstatus = True
            End If
        End If
    End Sub

    Private Sub dgBOMASS_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgBOMASS.EditingControlShowing
        If dgBOMASS.RowCount = 0 Then
            Exit Sub
        End If

        If dgBOMASS.CurrentCell.ColumnIndex = 6 Then
            If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                If Not cboBox Is Nothing Then
                    RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbocolor_dgBOMASS_SelectedIndexChanged
                    AddHandler cboBox.SelectedIndexChanged, AddressOf cbocolor_dgBOMASS_SelectedIndexChanged
                End If
            End If
        ElseIf dgBOMASS.CurrentCell.ColumnIndex = 11 Then
            Dim txtbox As TextBox = CType(e.Control, TextBox)
            If Not (txtbox Is Nothing) Then
                AddHandler txtbox.KeyPress, AddressOf txtBOMQty_dgBOMASS_KeyPress
                AddHandler txtbox.TextChanged, AddressOf txtBOMQty_dgBOMASS_TextChanged
            End If
        ElseIf dgBOMASS.CurrentCell.ColumnIndex = 12 Or dgBOMASS.CurrentCell.ColumnIndex = 13 Then
            Recordstatus = True
        End If
    End Sub


    Private Sub txtBOMQty_dgBOMASS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = dgBOMASS.CurrentCell.RowIndex
        Dim iCol As Integer = dgBOMASS.CurrentCell.ColumnIndex

        If iCol = 11 Then
            If flag_bomqty_keypress = True Then
                flag_bomqty_keypress = False
                calculate_BOM()
            End If
        End If
    End Sub

    Private Sub txtBOMQty_dgBOMASS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim iRow As Integer = dgBOMASS.CurrentCell.RowIndex
        Dim iCol As Integer = dgBOMASS.CurrentCell.ColumnIndex

        If iCol = 11 Then
            If Not (e.KeyChar = vbBack Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
                e.KeyChar = ""
            End If
            flag_bomqty_keypress = True
        End If
    End Sub

    Private Sub calculate_BOM()
        Dim i As Integer
        Dim curcde As String
        Dim bomprc As Decimal
        Dim cstprc As String

        Dim dr() As DataRow = rs_IMPRCINF.Tables("RESULT").Select("imu_venno = imu_prdven")
        If dr.Length >= 1 Then
            curcde = dr(0).Item("imu_curcde")
        Else
            If Split(cboItmVenTyp.Text, " - ")(0) <> "EXT" Then
                curcde = "USD"
            Else
                curcde = "HKD"
            End If
        End If

        bomprc = 0.0
        cstprc = dgBOMASS.Item(dgBOMASS_iba_costing, 0).Value

        Dim tmpbomqty As Integer
        Dim tmpbomprc As Decimal
        tmpbomqty = 0
        tmpbomprc = 0.0

        Dim bomexrate As Decimal
        Dim fmlopt As String
        Dim exchangerate As Decimal
        Dim bcurcde As String
        bcurcde = "USD"

        If cstprc = "Costing" Then
            For i = 0 To dgBOMASS.RowCount - 1
                If dgBOMASS.Item(dgBOMASS_iba_cocde, i).Value <> "Y" Then
                    tmpbomprc = dgBOMASS.Item(dgBOMASS_iba_untcst, i).Value
                    tmpbomqty = dgBOMASS.Item(dgBOMASS_iba_bomqty, i).EditedFormattedValue
                    bomexrate = getexchangerate(dgBOMASS.Item(dgBOMASS_iba_curcde, i).Value, curcde, "SellRate")
                    bomprc = bomprc + (tmpbomprc * tmpbomqty * bomexrate)
                End If
            Next i

            For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_bomcst") = bomprc
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ttlcst") = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprc") + bomprc, 4)
                fmlopt = Split(rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_fmlopt"), " - ")(1)
                exchangerate = getexchangerate(curcde, bcurcde, "SellRate")
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_itmprc") = Decimal.Round(calculate_fmlopt(fmlopt, rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ttlcst")) * exchangerate, 4)
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_bomprc") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_basprc") = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_itmprc"), 4)
                If rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_creusr") <> "~*ADD*~" Then
                    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_creusr") = "~*UPD*~"
                End If
            Next i
        Else
            For i = 0 To dgBOMASS.RowCount - 1
                If dgBOMASS.Item(dgBOMASS_iba_cocde, i).Value <> "Y" Then
                    tmpbomprc = dgBOMASS.Item(dgBOMASS_iba_untcst, i).Value
                    tmpbomqty = dgBOMASS.Item(dgBOMASS_iba_bomqty, i).EditedFormattedValue
                    bomexrate = getexchangerate(dgBOMASS.Item(dgBOMASS_iba_curcde, i).Value, "USD", "SellRate")

                    bomprc = bomprc + (tmpbomprc * tmpbomqty * bomexrate)
                End If
            Next i

            For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_bomcst") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ttlcst") = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprc"), 4)
                fmlopt = Split(rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_fmlopt"), " - ")(1)
                exchangerate = getexchangerate(curcde, bcurcde, "SellRate")
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_itmprc") = Decimal.Round(calculate_fmlopt(fmlopt, rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ttlcst")) * exchangerate, 4)
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_bomprc") = bomprc
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_basprc") = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_itmprc") + bomprc, 4)
                If rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_creusr") <> "~*ADD*~" Then
                    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_creusr") = "~*UPD*~"
                End If
            Next i
        End If
    End Sub

    Private Sub cbocolor_dgBOMASS_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = dgBOMASS.CurrentCell.RowIndex
        Dim iCol As Integer = dgBOMASS.CurrentCell.ColumnIndex
        Dim strSelItem As String

        If TypeOf (Me.dgBOMASS.CurrentCell) Is DataGridViewComboBoxCell Then
            Dim cboBox As ComboBox = CType(sender, ComboBox)
            If Not cboBox Is Nothing AndAlso Not cboBox.SelectedItem Is Nothing Then

                strSelItem = cboBox.SelectedItem.ToString
                RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbocolor_dgBOMASS_SelectedIndexChanged

                If iCol = 6 Then
                    Dim tmpbomitm As String
                    Dim tmpcolcde As String
                    Dim tmplastcolcde As String
                    tmpbomitm = dgBOMASS.Item(3, dgBOMASS.CurrentCell.RowIndex).Value
                    tmplastcolcde = dgBOMASS.Item(dgBOMASS_iba_colcde, dgBOMASS.CurrentCell.RowIndex).Value
                    tmpcolcde = dgBOMASS.CurrentCell.EditedFormattedValue

                    If tmpbomitm = "" Or tmpcolcde = "" Then
                        Exit Sub
                    End If

                    Dim i As Integer
                    Dim updrow As Integer
                    i = -1
                    For i = 0 To rs_IMBOMASS.Tables("RESULT").Rows.Count - 1
                        If rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_assitm") = tmpbomitm And rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_cocde") <> "Y" And rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_colcde") = tmplastcolcde Then
                            updrow = i
                            Exit For
                        End If
                    Next i

                    Dim dr() As DataRow = rs_IMCOLINF_BOMASS.Tables("RESULT").Select("icf_colcde = '" & tmpcolcde & "'")
                    Dim dr2() As DataRow = rs_IMPCKINF_BOMASS.Tables("RESULT").Select("ipi_itmno = '" & tmpbomitm & "'")

                    'If dr.Length = 1 And dr2.Length = 1 And i <> -1 Then
                    If i <> -1 Then
                        rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_colcde") = tmpcolcde
                        rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("ibi_engdsc") = dr(0).Item("ibi_engdsc")
                        rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("vbi_vensna") = dr(0).Item("vbi_vensna")
                        rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_pckunt") = dr2(0).Item("ipi_pckunt")
                        rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_period") = dr2(0).Item("ipi_qutdat")
                        If rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_creusr") <> "~*ADD*~" Then
                            rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_creusr") = "~*UPD*~"
                        End If
                        Recordstatus = True

                        gspStr = "sp_select_IMPRCINF_BOMASS '','" & tmpbomitm & "','" & dr2(0).Item("ipi_pckunt") & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_IMPRCINF_BOMASS, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading dgBOMASS_CellValueChanged sp_select_IMPRCINF_IMBOMASS :" & rtnStr)
                            Exit Sub
                        End If

                        If rs_IMPRCINF_BOMASS.Tables("RESULT").Rows.Count = 1 Then

                            rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_curcde") = rs_IMPRCINF_BOMASS.Tables("RESULT").Rows(0).Item("imu_curcde")
                            rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_fcurcde") = rs_IMPRCINF_BOMASS.Tables("RESULT").Rows(0).Item("imu_bcurcde")


                            If Split(cboItmVenTyp.Text, " - ")(0) = "EXT" Then
                                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_untcst") = rs_IMPRCINF_BOMASS.Tables("RESULT").Rows(0).Item("imu_ftyprc")
                                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_bombasprc") = rs_IMPRCINF_BOMASS.Tables("RESULT").Rows(0).Item("imu_ftyprc")
                                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_ftycst") = rs_IMPRCINF_BOMASS.Tables("RESULT").Rows(0).Item("imu_ftycst")

                                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_ftyfmlopt") = "PDV - *1"
                                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_fmlopt") = "PDV - *1"

                                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_costing") = "Basic Price"
                                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_genpo") = "N"

                                calculate_BOM()
                            Else
                                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_untcst") = 0.0
                                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_bombasprc") = 0.0
                                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_ftycst") = 0.0

                                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_ftyfmlopt") = "PDV - *1"
                                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_fmlopt") = "PDV - *1"

                                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_costing") = "Basic Price"
                                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_genpo") = "N"
                            End If
                        End If
                    Else
                        rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_colcde") = ""
                        rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("ibi_engdsc") = ""
                        rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("vbi_vensna") = ""
                        rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_pckunt") = ""
                        rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_untcst") = 0.0
                        rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_curcde") = ""
                        rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_bombasprc") = 0.0
                        rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_fcurcde") = ""
                        rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_ftycst") = 0.0
                        rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_creusr") = "~*UPD*~"
                        Recordstatus = True
                    End If
                    'dgBOMASS.Refresh()
                End If
                AddHandler cboBox.SelectedIndexChanged, AddressOf cbocolor_dgBOMASS_SelectedIndexChanged

            End If
        End If
    End Sub

    Private Sub txtbox_dgBOMASS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar.Equals(Chr(13)) Then
            Dim bomasstyp As String
            If rbBOMASS_ASS.Checked = True Then
                bomasstyp = "ASS"
            Else
                bomasstyp = "BOM"
            End If

            gspStr = "sp_select_IMCOLINF_IMBOMASS '','" & dgBOMASS.CurrentCell.Value & "','" & bomasstyp & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_IMCOLINF_BOMASS, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading txtbox_dgBOMASS_KeyPress sp_select_IMCOLINF_IMBOMASS :" & rtnStr)
                Exit Sub
            End If

            gspStr = "sp_select_IMPCKINF_IMBOMASS '','" & dgBOMASS.CurrentCell.Value & "','" & bomasstyp & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_IMPCKINF_BOMASS, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading txtbox_dgBOMASS_KeyPress sp_select_IMPCKINF_IMBOMASS :" & rtnStr)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub dgBOMASS_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgBOMASS.GotFocus
        lblBOMASS.ForeColor = Color.DarkCyan
        Got_Focus_Grid = "dgBOMASS"
    End Sub

    Private Sub dgBOMASS_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgBOMASS.LostFocus
        lblBOMASS.ForeColor = Color.Black
        '   Got_Focus_Grid = ""
    End Sub

    Private Sub dgCostPrice_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCostPrice.CellClick
        If mode <> "ADD" And mode <> "UPDATE" Then
            Exit Sub
        End If

        Dim creusr As String = dgCostPrice.Item(dgCostPrice_imu_creusr, dgCostPrice.CurrentCell.RowIndex).Value.ToString

        Select Case dgCostPrice.CurrentCell.ColumnIndex
            Case dgCostPrice_imu_curcde
                comboBoxCell(dgCostPrice, "Currency")
            Case dgCostPrice_imu_bcurcde
                If Split(cboItmTyp.Text, " - ")(0) = "BOM" Then
                    comboBoxCell(dgCostPrice, "Currency")
                End If
            Case dgCostPrice_imu_status
                comboBoxCell(dgCostPrice, "PriceStatus")
            Case dgCostPrice_imu_hkprctrm, dgCostPrice_imu_ftyprctrm
                comboBoxCell(dgCostPrice, "PriceTerm")
            Case dgCostPrice_imu_trantrm
                comboBoxCell(dgCostPrice, "TranTerm")
            Case dgCostPrice_imu_fmlopt
                comboBoxCell(dgCostPrice, "Formula")
            Case dgCostPrice_imu_estprcflg
                comboBoxCell(dgCostPrice, "EstimatedPrice")
        End Select

    End Sub

    Private Sub dgCostPrice_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCostPrice.CellDoubleClick
        If mode = "READ" Then
            Exit Sub
        End If

        If dgCostPrice.RowCount = 0 Then
            Exit Sub
        End If

        If dgCostPrice.SelectedRows.Count = 0 Then
            If Not (e.ColumnIndex = 0 And e.RowIndex >= 0) Then
                Exit Sub
            End If
        End If

        If dgCostPrice.SelectedRows.Count > 1 Then
            Exit Sub
        End If

        If dgCostPrice.SelectedRows.Count = 1 And e.ColumnIndex = -1 Then
            'Row Header double click
            Exit Sub
        End If

        Dim iCol As Integer = dgCostPrice.CurrentCell.ColumnIndex
        Dim iRow As Integer = dgCostPrice.CurrentCell.RowIndex
        Dim curvalue As String
        curvalue = dgCostPrice.CurrentCell.Value

        Select Case dgCostPrice.CurrentCell.ColumnIndex
            Case dgCostPrice_imu_cocde
                If curvalue = "" Then
                    If MsgBox("Are you sure to delete pricing?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                Else
                    If MsgBox("Are you sure to undelete pricing?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If

                If curvalue = "" Then
                    If check_delete_CostPrice() Then
                        dgCostPrice.Item(dgCostPrice_imu_cocde, iRow).Value = "Y"
                    End If
                Else
                    'check for packing or pv is deleted or not
                    Dim pv As String
                    Dim pck_um As String
                    Dim pck_inr As String
                    Dim pck_mtr As String

                    pv = dgCostPrice.Item(dgCostPrice_imu_prdven, iRow).Value
                    pck_um = Split(dgCostPrice.Item(dgCostPrice_imu_packing, iRow).Value, " / ")(0)
                    pck_inr = Split(dgCostPrice.Item(dgCostPrice_imu_packing, iRow).Value, " / ")(1)
                    pck_mtr = Split(dgCostPrice.Item(dgCostPrice_imu_packing, iRow).Value, " / ")(2)

                    Dim packingdel As Boolean
                    Dim pvdel As Boolean
                    packingdel = False
                    pvdel = False

                    Dim i As Integer
                    For i = 0 To rs_IMPCKINF.Tables("RESULT").Rows.Count - 1
                        If (pck_um = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_pckunt") And _
                            pck_inr = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_inrqty") And _
                            pck_mtr = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_mtrqty")) Then
                            If rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cocde") = "Y" Then
                                packingdel = True
                            End If
                        End If
                    Next i

                    For i = 0 To rs_IMVENINF.Tables("RESULT").Rows.Count - 1
                        If pv = rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_venno") Then
                            If rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_cocde") = "Y" Then
                                pvdel = True
                            End If
                        End If
                    Next i

                    If packingdel Or pvdel Then
                        MsgBox("Packing or PV already deleted! Price cannot be activated!")
                        Exit Sub
                    Else
                        dgCostPrice.Item(dgCostPrice_imu_cocde, iRow).Value = ""
                    End If
                End If

                If dgCostPrice.Item(dgCostPrice_imu_creusr, iRow).Value <> "~*ADD*~" Then
                    dgCostPrice.Item(dgCostPrice_imu_creusr, iRow).Value = "~*UPD*~"
                    Recordstatus = True
                End If
        End Select



        'If dgCostPrice.CurrentCell.ColumnIndex = 0 And dgCostPrice.SelectedRows.Count = 0 And e.ColumnIndex = 0 And e.RowIndex >= 0 Then
        '    delete_CostPrice()
        'End If
    End Sub

    Private Sub dgCostPrice_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgCostPrice.CellValidating
        Dim row As DataGridViewRow = dgCostPrice.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then
            Select Case e.ColumnIndex
                Case dgCostPrice_imu_ftycst, dgCostPrice_imu_ftycstA, dgCostPrice_imu_ftycstB, dgCostPrice_imu_ftycstC, dgCostPrice_imu_ftycstD, dgCostPrice_imu_ftycstE, dgCostPrice_imu_ftycstTran, dgCostPrice_imu_ftycstPack
                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Invalid FtyCst [not numeric]!")
                        e.Cancel = True
                        Exit Sub
                    End If
                Case dgCostPrice_imu_ftyprc, dgCostPrice_imu_ftyprcA, dgCostPrice_imu_ftyprcB, dgCostPrice_imu_ftyprcC, dgCostPrice_imu_ftyprcD, dgCostPrice_imu_ftyprcE, dgCostPrice_imu_ftyprcTran, dgCostPrice_imu_ftyprcPack
                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Invalid FtyPrc [not numeric]!")
                        e.Cancel = True
                        Exit Sub
                    End If
                Case dgCostPrice_imu_effdat
                    If Not IsDate(strNewVal) Then
                        MsgBox("Invalid Effective Date [MM/dd/yyyy]!")
                        e.Cancel = True
                        Exit Sub
                    End If
                Case dgCostPrice_imu_expdat
                    If Not IsDate(strNewVal) Then
                        MsgBox("Invalid Expiry Date [MM/dd/yyyy]!")
                        e.Cancel = True
                        Exit Sub
                    End If
            End Select
        End If
    End Sub

    Private Sub dgCostPrice_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgCostPrice.EditingControlShowing
        If dgCostPrice.RowCount = 0 Then
            Exit Sub
        End If

        e.CellStyle.BackColor = Color.White

        Select Case dgCostPrice.CurrentCell.ColumnIndex
            Case dgCostPrice_imu_ftycst, dgCostPrice_imu_ftycstA, dgCostPrice_imu_ftycstB, dgCostPrice_imu_ftycstC, dgCostPrice_imu_ftycstD, dgCostPrice_imu_ftycstE, dgCostPrice_imu_ftycstTran, dgCostPrice_imu_ftycstPack, _
                 dgCostPrice_imu_ftyprc, dgCostPrice_imu_ftyprcA, dgCostPrice_imu_ftyprcB, dgCostPrice_imu_ftyprcC, dgCostPrice_imu_ftyprcD, dgCostPrice_imu_ftyprcE, dgCostPrice_imu_ftyprcTran, dgCostPrice_imu_ftyprcPack
                Dim txtbox As TextBox = CType(e.Control, TextBox)
                If Not (txtbox Is Nothing) Then
                    AddHandler txtbox.KeyPress, AddressOf txt_dgCostPrice_KeyPress
                    AddHandler txtbox.TextChanged, AddressOf txt_dgCostPrice_TextChanged
                End If
            Case dgCostPrice_imu_hkprctrm, dgCostPrice_imu_ftyprctrm
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                    End If
                End If
            Case dgCostPrice_imu_fmlopt
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                        AddHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                    End If
                End If
        End Select

        If mode = "UPDATE" Or mode = "ADD" Then
            Recordstatus = True
            Dim CREUSR As String = dgCostPrice.Item(dgCostPrice_imu_creusr, dgCostPrice.CurrentCell.RowIndex).Value
            If CREUSR <> "~*ADD*~" Then
                dgCostPrice.Item(dgCostPrice_imu_creusr, dgCostPrice.CurrentCell.RowIndex).Value = "~*UPD*~"
            End If
            'If rs_IMPRCINF.Tables("RESULT").Rows(dgCostPrice.CurrentCell.RowIndex).Item("imu_creusr") <> "~*ADD*~" Then
            '    rs_IMPRCINF.Tables("RESULT").Rows(dgCostPrice.CurrentCell.RowIndex).Item("imu_creusr") = "~*UPD*~"
            'End If
        End If
    End Sub

    Private Sub cbo_dgCostPrice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = dgCostPrice.CurrentCell.RowIndex
        Dim iCol As Integer = dgCostPrice.CurrentCell.ColumnIndex

        Dim curvalue As String = dgCostPrice.CurrentCell.EditedFormattedValue

        Select Case dgCostPrice.CurrentCell.ColumnIndex
            Case dgCostPrice_imu_fmlopt
                Dim tmpttlcst As Decimal
                tmpttlcst = dgCostPrice.Item(dgCostPrice_imu_ttlcst, iRow).Value

                Dim tmpfmlopt As String
                If curvalue <> "" Then
                    tmpfmlopt = Split(curvalue, " - ")(1)
                Else
                    tmpfmlopt = ""
                End If

                Dim exchangerate As Decimal
                Dim fcurcde As String
                Dim bcurcde As String
                fcurcde = dgCostPrice.Item(dgCostPrice_imu_curcde, iRow).Value
                bcurcde = dgCostPrice.Item(dgCostPrice_imu_bcurcde, iRow).Value
                exchangerate = getexchangerate(fcurcde, bcurcde, "SellRate")

                Dim tmpitmprc As Decimal
                If tmpfmlopt <> "" Then
                    tmpitmprc = calculate_fmlopt(tmpfmlopt, tmpttlcst) * exchangerate
                End If

                dgCostPrice.Item(dgCostPrice_imu_itmprc, iRow).Value = Decimal.Round(tmpitmprc, 4)

                Dim tmpbomprc As Decimal
                Dim tmpbasprc As Decimal
                If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_bomprc, iRow).Value) Then
                    tmpbomprc = dgCostPrice.Item(dgCostPrice_imu_bomprc, iRow).Value
                Else
                    tmpbomprc = 0.0
                End If

                tmpbasprc = Decimal.Round(tmpitmprc, 4) + Decimal.Round(tmpbomprc, 4)

                dgCostPrice.Item(dgCostPrice_imu_basprc, iRow).Value = Decimal.Round(tmpbasprc, 4)
        End Select
    End Sub

    Private Sub txt_dgCostPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim iRow As Integer = dgCostPrice.CurrentCell.RowIndex
        Dim iCol As Integer = dgCostPrice.CurrentCell.ColumnIndex

        Dim curvalue As String = dgCostPrice.CurrentCell.EditedFormattedValue

        Select Case dgCostPrice.CurrentCell.ColumnIndex
            Case dgCostPrice_imu_ftycstA, dgCostPrice_imu_ftycstB, dgCostPrice_imu_ftycstC, dgCostPrice_imu_ftycstD, dgCostPrice_imu_ftycstE, dgCostPrice_imu_ftycstTran, dgCostPrice_imu_ftycstPack, _
                    dgCostPrice_imu_ftyprcA, dgCostPrice_imu_ftyprcB, dgCostPrice_imu_ftyprcC, dgCostPrice_imu_ftyprcD, dgCostPrice_imu_ftyprcE, dgCostPrice_imu_ftyprcTran, dgCostPrice_imu_ftyprcPack

                ' Check Numeric
                If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
                    e.KeyChar = ""
                Else
                    If curvalue.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                        e.KeyChar = ""
                    End If
                End If
                flag_dgCostPrice_keypress = True
            Case dgCostPrice_imu_ftycst
                Dim tmpftycst_a As Decimal
                Dim tmpftycst_b As Decimal
                Dim tmpftycst_c As Decimal
                Dim tmpftycst_d As Decimal
                Dim tmpftycst_e As Decimal
                Dim tmpftycst_tran As Decimal
                Dim tmpftycst_pack As Decimal

                If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftycstA, iRow).Value) Then
                    tmpftycst_a = dgCostPrice.Item(dgCostPrice_imu_ftycstA, iRow).Value
                Else
                    tmpftycst_a = 0
                End If

                If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftycstB, iRow).Value) Then
                    tmpftycst_b = dgCostPrice.Item(dgCostPrice_imu_ftycstB, iRow).Value
                Else
                    tmpftycst_b = 0
                End If

                If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftycstC, iRow).Value) Then
                    tmpftycst_c = dgCostPrice.Item(dgCostPrice_imu_ftycstC, iRow).Value
                Else
                    tmpftycst_c = 0
                End If

                If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftycstD, iRow).Value) Then
                    tmpftycst_d = dgCostPrice.Item(dgCostPrice_imu_ftycstD, iRow).Value
                Else
                    tmpftycst_d = 0
                End If

                If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftycstE, iRow).Value) Then
                    tmpftycst_e = dgCostPrice.Item(dgCostPrice_imu_ftycstE, iRow).Value
                Else
                    tmpftycst_e = 0
                End If

                If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftycstTran, iRow).Value) Then
                    tmpftycst_tran = dgCostPrice.Item(dgCostPrice_imu_ftycstTran, iRow).Value
                Else
                    tmpftycst_tran = 0
                End If

                If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftycstPack, iRow).Value) Then
                    tmpftycst_pack = dgCostPrice.Item(dgCostPrice_imu_ftycstPack, iRow).Value
                Else
                    tmpftycst_pack = 0
                End If

                If tmpftycst_a = 0 And tmpftycst_b = 0 And tmpftycst_c = 0 And tmpftycst_d = 0 And tmpftycst_e = 0 And tmpftycst_tran = 0 And tmpftycst_pack = 0 Then
                    ' Check Numeric
                    If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
                        e.KeyChar = ""
                    Else
                        If curvalue.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                            e.KeyChar = ""
                        End If
                    End If
                Else
                    e.KeyChar = ""
                End If
                flag_dgCostPrice_keypress = True
            Case dgCostPrice_imu_ftyprc
                Dim tmpftyprc_a As Decimal
                Dim tmpftyprc_b As Decimal
                Dim tmpftyprc_c As Decimal
                Dim tmpftyprc_d As Decimal
                Dim tmpftyprc_e As Decimal
                Dim tmpftyprc_tran As Decimal
                Dim tmpftyprc_pack As Decimal

                If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftyprcA, iRow).Value) Then
                    tmpftyprc_a = dgCostPrice.Item(dgCostPrice_imu_ftyprcA, iRow).Value
                Else
                    tmpftyprc_a = 0
                End If

                If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftyprcB, iRow).Value) Then
                    tmpftyprc_b = dgCostPrice.Item(dgCostPrice_imu_ftyprcB, iRow).Value
                Else
                    tmpftyprc_b = 0
                End If

                If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftyprcC, iRow).Value) Then
                    tmpftyprc_c = dgCostPrice.Item(dgCostPrice_imu_ftyprcC, iRow).Value
                Else
                    tmpftyprc_c = 0
                End If

                If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftyprcD, iRow).Value) Then
                    tmpftyprc_d = dgCostPrice.Item(dgCostPrice_imu_ftyprcD, iRow).Value
                Else
                    tmpftyprc_d = 0
                End If

                If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftyprcE, iRow).Value) Then
                    tmpftyprc_e = dgCostPrice.Item(dgCostPrice_imu_ftyprcE, iRow).Value
                Else
                    tmpftyprc_e = 0
                End If

                If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftyprcTran, iRow).Value) Then
                    tmpftyprc_tran = dgCostPrice.Item(dgCostPrice_imu_ftyprcTran, iRow).Value
                Else
                    tmpftyprc_tran = 0
                End If

                If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftyprcPack, iRow).Value) Then
                    tmpftyprc_pack = dgCostPrice.Item(dgCostPrice_imu_ftyprcPack, iRow).Value
                Else
                    tmpftyprc_pack = 0
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'If tmpftyprc_a = 0 And tmpftyprc_b = 0 And tmpftyprc_c = 0 And tmpftyprc_d = 0 And tmpftyprc_e = 0 And tmpftyprc_tran = 0 And tmpftyprc_pack = 0 Then
                '    ' Check Numeric
                '    If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
                '        e.KeyChar = ""
                '    Else
                '        If curvalue.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                '            e.KeyChar = ""
                '        End If
                '    End If
                'Else
                '    e.KeyChar = ""
                'End If

                If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
                    e.KeyChar = ""
                Else
                    If curvalue.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                        e.KeyChar = ""
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                flag_dgCostPrice_keypress = True
        End Select


    End Sub


    Private Sub txt_dgCostPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = dgCostPrice.CurrentCell.RowIndex
        Dim iCol As Integer = dgCostPrice.CurrentCell.ColumnIndex

        Dim curvalue As String = dgCostPrice.CurrentCell.EditedFormattedValue
        Dim i As Integer

        Select Case dgCostPrice.CurrentCell.ColumnIndex
            Case dgCostPrice_imu_ftycst, dgCostPrice_imu_ftycstA, dgCostPrice_imu_ftycstB, dgCostPrice_imu_ftycstC, dgCostPrice_imu_ftycstD, dgCostPrice_imu_ftycstE, dgCostPrice_imu_ftycstTran, dgCostPrice_imu_ftycstPack, _
                    dgCostPrice_imu_ftyprc, dgCostPrice_imu_ftyprcA, dgCostPrice_imu_ftyprcB, dgCostPrice_imu_ftyprcC, dgCostPrice_imu_ftyprcD, dgCostPrice_imu_ftyprcE, dgCostPrice_imu_ftyprcTran, dgCostPrice_imu_ftyprcPack

                If flag_dgCostPrice_keypress = True Then
                    flag_dgCostPrice_keypress = False

                    Dim tmpftycst As Decimal
                    Dim tmpftycst_a As Decimal
                    Dim tmpftycst_b As Decimal
                    Dim tmpftycst_c As Decimal
                    Dim tmpftycst_d As Decimal
                    Dim tmpftycst_e As Decimal
                    Dim tmpftycst_tran As Decimal
                    Dim tmpftycst_pack As Decimal

                    Dim tmpftyprc As Decimal
                    Dim tmpftyprc_a As Decimal
                    Dim tmpftyprc_b As Decimal
                    Dim tmpftyprc_c As Decimal
                    Dim tmpftyprc_d As Decimal
                    Dim tmpftyprc_e As Decimal
                    Dim tmpftyprc_tran As Decimal
                    Dim tmpftyprc_pack As Decimal

                    Dim tmpMU As Decimal
                    Dim tmpMU_a As Decimal
                    Dim tmpMU_b As Decimal
                    Dim tmpMU_c As Decimal
                    Dim tmpMU_d As Decimal
                    Dim tmpMU_e As Decimal
                    Dim tmpMU_tran As Decimal
                    Dim tmpMU_pack As Decimal

                    If dgCostPrice.CurrentCell.ColumnIndex = dgCostPrice_imu_ftycstA Then
                        If IsNumeric(curvalue) Then
                            tmpftycst_a = curvalue
                        Else
                            tmpftycst_a = 0
                        End If
                    Else
                        If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftycstA, iRow).Value) Then
                            tmpftycst_a = dgCostPrice.Item(dgCostPrice_imu_ftycstA, iRow).Value
                        Else
                            tmpftycst_a = 0
                        End If
                    End If
                    tmpftycst_a = Decimal.Round(tmpftycst_a, 4)

                    If dgCostPrice.CurrentCell.ColumnIndex = dgCostPrice_imu_ftycstB Then
                        If IsNumeric(curvalue) Then
                            tmpftycst_b = curvalue
                        Else
                            tmpftycst_b = 0
                        End If
                    Else
                        If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftycstB, iRow).Value) Then
                            tmpftycst_b = dgCostPrice.Item(dgCostPrice_imu_ftycstB, iRow).Value
                        Else
                            tmpftycst_b = 0
                        End If
                    End If
                    tmpftycst_b = Decimal.Round(tmpftycst_b, 4)

                    If dgCostPrice.CurrentCell.ColumnIndex = dgCostPrice_imu_ftycstC Then
                        If IsNumeric(curvalue) Then
                            tmpftycst_c = curvalue
                        Else
                            tmpftycst_c = 0
                        End If
                    Else
                        If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftycstC, iRow).Value) Then
                            tmpftycst_c = dgCostPrice.Item(dgCostPrice_imu_ftycstC, iRow).Value
                        Else
                            tmpftycst_c = 0
                        End If
                    End If
                    tmpftycst_c = Decimal.Round(tmpftycst_c, 4)

                    If dgCostPrice.CurrentCell.ColumnIndex = dgCostPrice_imu_ftycstD Then
                        If IsNumeric(curvalue) Then
                            tmpftycst_d = curvalue
                        Else
                            tmpftycst_d = 0
                        End If
                    Else
                        If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftycstD, iRow).Value) Then
                            tmpftycst_d = dgCostPrice.Item(dgCostPrice_imu_ftycstD, iRow).Value
                        Else
                            tmpftycst_d = 0
                        End If
                    End If
                    tmpftycst_d = Decimal.Round(tmpftycst_d, 4)

                    If dgCostPrice.CurrentCell.ColumnIndex = dgCostPrice_imu_ftycstE Then
                        If IsNumeric(curvalue) Then
                            tmpftycst_e = curvalue
                        Else
                            tmpftycst_e = 0
                        End If
                    Else
                        If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftycstE, iRow).Value) Then
                            tmpftycst_e = dgCostPrice.Item(dgCostPrice_imu_ftycstE, iRow).Value
                        Else
                            tmpftycst_e = 0
                        End If
                    End If
                    tmpftycst_e = Decimal.Round(tmpftycst_e, 4)

                    If dgCostPrice.CurrentCell.ColumnIndex = dgCostPrice_imu_ftycstTran Then
                        If IsNumeric(curvalue) Then
                            tmpftycst_tran = curvalue
                        Else
                            tmpftycst_tran = 0
                        End If
                    Else
                        If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftycstTran, iRow).Value) Then
                            tmpftycst_tran = dgCostPrice.Item(dgCostPrice_imu_ftycstTran, iRow).Value
                        Else
                            tmpftycst_tran = 0
                        End If
                    End If
                    tmpftycst_tran = Decimal.Round(tmpftycst_tran, 4)

                    If dgCostPrice.CurrentCell.ColumnIndex = dgCostPrice_imu_ftycstPack Then
                        If IsNumeric(curvalue) Then
                            tmpftycst_pack = curvalue
                        Else
                            tmpftycst_pack = 0
                        End If
                    Else
                        If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftycstPack, iRow).Value) Then
                            tmpftycst_pack = dgCostPrice.Item(dgCostPrice_imu_ftycstPack, iRow).Value
                        Else
                            tmpftycst_pack = 0
                        End If
                    End If
                    tmpftycst_pack = Decimal.Round(tmpftycst_pack, 4)

                    If tmpftycst_a = 0 And tmpftycst_b = 0 And tmpftycst_c = 0 And tmpftycst_d = 0 And tmpftycst_e = 0 And tmpftycst_tran = 0 And tmpftycst_pack = 0 Then
                        If dgCostPrice.CurrentCell.ColumnIndex = dgCostPrice_imu_ftycst Then
                            If IsNumeric(curvalue) Then
                                tmpftycst = curvalue
                            Else
                                tmpftycst = 0
                            End If
                        Else
                            If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftycst, iRow).Value) Then
                                tmpftycst = dgCostPrice.Item(dgCostPrice_imu_ftycst, iRow).Value
                            Else
                                tmpftycst = 0
                            End If
                        End If
                    Else
                        tmpftycst = Decimal.Round(tmpftycst_a, 4) + Decimal.Round(tmpftycst_b, 4) + Decimal.Round(tmpftycst_c, 4) + Decimal.Round(tmpftycst_d, 4) + Decimal.Round(tmpftycst_e, 4) + Decimal.Round(tmpftycst_tran, 4) + Decimal.Round(tmpftycst_pack, 4)
                    End If

                    dgCostPrice.Item(dgCostPrice_imu_ftycst, iRow).Value = Decimal.Round(tmpftycst, 4)

                    If dgCostPrice.CurrentCell.ColumnIndex = dgCostPrice_imu_ftyprcA Then
                        If IsNumeric(curvalue) Then
                            tmpftyprc_a = curvalue
                        Else
                            tmpftyprc_a = 0
                        End If
                    Else
                        If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftyprcA, iRow).Value) Then
                            tmpftyprc_a = dgCostPrice.Item(dgCostPrice_imu_ftyprcA, iRow).Value
                        Else
                            tmpftyprc_a = 0
                        End If
                    End If
                    tmpftyprc_a = Decimal.Round(tmpftyprc_a, 4)

                    If dgCostPrice.CurrentCell.ColumnIndex = dgCostPrice_imu_ftyprcB Then
                        If IsNumeric(curvalue) Then
                            tmpftyprc_b = curvalue
                        Else
                            tmpftyprc_b = 0
                        End If
                    Else
                        If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftyprcB, iRow).Value) Then
                            tmpftyprc_b = dgCostPrice.Item(dgCostPrice_imu_ftyprcB, iRow).Value
                        Else
                            tmpftyprc_b = 0
                        End If
                    End If
                    tmpftyprc_b = Decimal.Round(tmpftyprc_b, 4)

                    If dgCostPrice.CurrentCell.ColumnIndex = dgCostPrice_imu_ftyprcC Then
                        If IsNumeric(curvalue) Then
                            tmpftyprc_c = curvalue
                        Else
                            tmpftyprc_c = 0
                        End If
                    Else
                        If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftyprcC, iRow).Value) Then
                            tmpftyprc_c = dgCostPrice.Item(dgCostPrice_imu_ftyprcC, iRow).Value
                        Else
                            tmpftyprc_c = 0
                        End If
                    End If
                    tmpftyprc_c = Decimal.Round(tmpftyprc_c, 4)

                    If dgCostPrice.CurrentCell.ColumnIndex = dgCostPrice_imu_ftyprcD Then
                        If IsNumeric(curvalue) Then
                            tmpftyprc_d = curvalue
                        Else
                            tmpftyprc_d = 0
                        End If
                    Else
                        If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftyprcD, iRow).Value) Then
                            tmpftyprc_d = dgCostPrice.Item(dgCostPrice_imu_ftyprcD, iRow).Value
                        Else
                            tmpftyprc_d = 0
                        End If
                    End If
                    tmpftyprc_d = Decimal.Round(tmpftyprc_d, 4)

                    If dgCostPrice.CurrentCell.ColumnIndex = dgCostPrice_imu_ftyprcE Then
                        If IsNumeric(curvalue) Then
                            tmpftyprc_e = curvalue
                        Else
                            tmpftyprc_e = 0
                        End If
                    Else
                        If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftyprcE, iRow).Value) Then
                            tmpftyprc_e = dgCostPrice.Item(dgCostPrice_imu_ftyprcE, iRow).Value
                        Else
                            tmpftyprc_e = 0
                        End If
                    End If
                    tmpftyprc_e = Decimal.Round(tmpftyprc_e, 4)

                    If dgCostPrice.CurrentCell.ColumnIndex = dgCostPrice_imu_ftyprcTran Then
                        If IsNumeric(curvalue) Then
                            tmpftyprc_tran = curvalue
                        Else
                            tmpftyprc_tran = 0
                        End If
                    Else
                        If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftyprcTran, iRow).Value) Then
                            tmpftyprc_tran = dgCostPrice.Item(dgCostPrice_imu_ftyprcTran, iRow).Value
                        Else
                            tmpftyprc_tran = 0
                        End If
                    End If
                    tmpftyprc_tran = Decimal.Round(tmpftyprc_tran, 4)

                    If dgCostPrice.CurrentCell.ColumnIndex = dgCostPrice_imu_ftyprcPack Then
                        If IsNumeric(curvalue) Then
                            tmpftyprc_pack = curvalue
                        Else
                            tmpftyprc_pack = 0
                        End If
                    Else
                        If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftyprcPack, iRow).Value) Then
                            tmpftyprc_pack = dgCostPrice.Item(dgCostPrice_imu_ftyprcPack, iRow).Value
                        Else
                            tmpftyprc_pack = 0
                        End If
                    End If
                    tmpftyprc_pack = Decimal.Round(tmpftyprc_pack, 4)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'If tmpftyprc_a = 0 And tmpftyprc_b = 0 And tmpftyprc_c = 0 And tmpftyprc_d = 0 And tmpftyprc_e = 0 And tmpftyprc_tran = 0 And tmpftyprc_pack = 0 Then
                    '    If dgCostPrice.CurrentCell.ColumnIndex = dgCostPrice_imu_ftyprc Then
                    '        If IsNumeric(curvalue) Then
                    '            tmpftyprc = curvalue
                    '        Else
                    '            tmpftyprc = 0
                    '        End If
                    '    Else
                    '        If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftyprc, iRow).Value) Then
                    '            tmpftyprc = dgCostPrice.Item(dgCostPrice_imu_ftyprc, iRow).Value
                    '        Else
                    '            tmpftyprc = 0
                    '        End If
                    '    End If
                    'Else
                    '    tmpftyprc = Decimal.Round(tmpftyprc_a, 4) + Decimal.Round(tmpftyprc_b, 4) + Decimal.Round(tmpftyprc_c, 4) + Decimal.Round(tmpftyprc_d, 4) + Decimal.Round(tmpftyprc_e, 4) + Decimal.Round(tmpftyprc_tran, 4) + Decimal.Round(tmpftyprc_pack, 4)
                    'End If

                    If dgCostPrice.CurrentCell.ColumnIndex = dgCostPrice_imu_ftyprc Then
                        If IsNumeric(curvalue) Then
                            tmpftyprc = curvalue
                        Else
                            tmpftyprc = 0
                        End If
                    Else
                        If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_ftyprc, iRow).Value) Then
                            tmpftyprc = dgCostPrice.Item(dgCostPrice_imu_ftyprc, iRow).Value
                        Else
                            tmpftyprc = 0
                        End If
                    End If


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    dgCostPrice.Item(dgCostPrice_imu_ftyprc, iRow).Value = Decimal.Round(tmpftyprc, 4)

                    If tmpftycst_a = 0 Or tmpftyprc_a = 0 Then
                        tmpMU_a = 0
                    Else
                        tmpMU_a = Decimal.Round((tmpftyprc_a - tmpftycst_a) * 100 / tmpftycst_a, 2)
                    End If
                    dgCostPrice.Item(dgCostPrice_imu_chgfpA, iRow).Value = tmpMU_a

                    If tmpftycst_b = 0 Or tmpftyprc_b = 0 Then
                        tmpMU_b = 0
                    Else
                        tmpMU_b = Decimal.Round((tmpftyprc_b - tmpftycst_b) * 100 / tmpftycst_b, 2)
                    End If
                    dgCostPrice.Item(dgCostPrice_imu_chgfpB, iRow).Value = tmpMU_b

                    If tmpftycst_c = 0 Or tmpftyprc_c = 0 Then
                        tmpMU_c = 0
                    Else
                        tmpMU_c = Decimal.Round((tmpftyprc_c - tmpftycst_c) * 100 / tmpftycst_c, 2)
                    End If
                    dgCostPrice.Item(dgCostPrice_imu_chgfpC, iRow).Value = tmpMU_c

                    If tmpftycst_d = 0 Or tmpftyprc_d = 0 Then
                        tmpMU_d = 0
                    Else
                        tmpMU_d = Decimal.Round((tmpftyprc_d - tmpftycst_d) * 100 / tmpftycst_d, 2)
                    End If
                    dgCostPrice.Item(dgCostPrice_imu_chgfpD, iRow).Value = tmpMU_d

                    If tmpftycst_e = 0 Or tmpftyprc_e = 0 Then
                        tmpMU_e = 0
                    Else
                        tmpMU_e = Decimal.Round((tmpftyprc_e - tmpftycst_e) * 100 / tmpftycst_e, 2)
                    End If
                    dgCostPrice.Item(dgCostPrice_imu_chgfpE, iRow).Value = tmpMU_e

                    If tmpftycst_tran = 0 Or tmpftyprc_tran = 0 Then
                        tmpMU_tran = 0
                    Else
                        tmpMU_tran = Decimal.Round((tmpftyprc_tran - tmpftycst_tran) * 100 / tmpftycst_tran, 2)
                    End If
                    dgCostPrice.Item(dgCostPrice_imu_chgfpTran, iRow).Value = tmpMU_tran

                    If tmpftycst_pack = 0 Or tmpftyprc_pack = 0 Then
                        tmpMU_pack = 0
                    Else
                        tmpMU_pack = Decimal.Round((tmpftyprc_pack - tmpftycst_pack) * 100 / tmpftycst_pack, 2)
                    End If
                    dgCostPrice.Item(dgCostPrice_imu_chgfpPack, iRow).Value = tmpMU_pack

                    If tmpftycst = 0 Or tmpftyprc = 0 Then
                        tmpMU = 0
                    Else
                        tmpMU = Decimal.Round((tmpftyprc - tmpftycst) * 100 / tmpftycst, 2)
                    End If
                    dgCostPrice.Item(dgCostPrice_imu_chgfp, iRow).Value = tmpMU


                    Dim tmpbomcst As Decimal
                    Dim tmpttlcst As Decimal


                    If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_bomcst, iRow).Value) Then
                        tmpbomcst = dgCostPrice.Item(dgCostPrice_imu_bomcst, iRow).Value
                    Else
                        tmpbomcst = 0
                    End If

                    tmpttlcst = tmpftyprc + tmpbomcst
                    dgCostPrice.Item(dgCostPrice_imu_ttlcst, iRow).Value = Decimal.Round(tmpttlcst, 4)

                    Dim tmpfmlopt As String
                    If dgCostPrice.Item(dgCostPrice_imu_fmlopt, iRow).Value <> "" Then
                        tmpfmlopt = Split(dgCostPrice.Item(dgCostPrice_imu_fmlopt, iRow).Value, " - ")(1)
                    Else
                        tmpfmlopt = ""
                    End If

                    Dim exchangerate As Decimal
                    Dim fcurcde As String
                    Dim bcurcde As String
                    fcurcde = dgCostPrice.Item(dgCostPrice_imu_curcde, iRow).Value
                    bcurcde = dgCostPrice.Item(dgCostPrice_imu_bcurcde, iRow).Value
                    exchangerate = getexchangerate(fcurcde, bcurcde, "SellRate")

                    Dim tmpitmprc As Decimal
                    If tmpfmlopt <> "" Then
                        tmpitmprc = calculate_fmlopt(tmpfmlopt, tmpttlcst) * exchangerate
                    End If

                    dgCostPrice.Item(dgCostPrice_imu_itmprc, iRow).Value = Decimal.Round(tmpitmprc, 4)

                    Dim tmpbomprc As Decimal
                    Dim tmpbasprc As Decimal
                    If IsNumeric(dgCostPrice.Item(dgCostPrice_imu_bomprc, iRow).Value) Then
                        tmpbomprc = dgCostPrice.Item(dgCostPrice_imu_bomprc, iRow).Value
                    Else
                        tmpbomprc = 0.0
                    End If

                    tmpbasprc = Decimal.Round(tmpitmprc, 4) + Decimal.Round(tmpbomprc, 4)

                    dgCostPrice.Item(dgCostPrice_imu_basprc, iRow).Value = Decimal.Round(tmpbasprc, 4)

                End If
        End Select
    End Sub





    Private Sub dgCostPrice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCostPrice.GotFocus
        lblPricing.ForeColor = Color.DarkCyan

        '    Got_Focus_Grid = "dgCostPrice"
    End Sub

    Private Sub dgCostPrice_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCostPrice.LostFocus
        lblPricing.ForeColor = Color.Black
        '     Got_Focus_Grid = ""
    End Sub

    Private Sub dgExclCustomer_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgExclCustomer.CellClick
        If dgExclCustomer.RowCount = 0 Then
            Exit Sub
        End If

        Select Case dgExclCustomer.CurrentCell.ColumnIndex
            Case dgExclCustomer_ici_cusno
                If dgExclCustomer.Item(dgExclCustomer_ici_creusr, dgExclCustomer.CurrentCell.RowIndex).Value = "~*ADD*~" Then
                    Call comboBoxCell(dgExclCustomer, "CusnoAll")
                End If
            Case dgExclCustomer_ici_ctycde
                Call comboBoxCell(dgExclCustomer, "Country")
                If dgExclCustomer.Item(dgExclCustomer_ici_creusr, dgExclCustomer.CurrentCell.RowIndex).Value <> "~*ADD*~" Then
                    dgExclCustomer.Item(dgExclCustomer_ici_creusr, dgExclCustomer.CurrentCell.RowIndex).Value = "~*UPD*~"
                End If
        End Select

    End Sub


    Private Sub dgExclCustomer_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgExclCustomer.EditingControlShowing
        If dgExclCustomer.RowCount = 0 Then
            Exit Sub
        End If

        If mode = "UPDATE" Or mode = "ADD" Then
            If dgExclCustomer.Item(dgExclCustomer_ici_creusr, dgExclCustomer.CurrentCell.RowIndex).Value <> "~*ADD*~" Then
                dgExclCustomer.Item(dgExclCustomer_ici_creusr, dgExclCustomer.CurrentCell.RowIndex).Value = "~*UPD*~"
                Recordstatus = True
            End If
        End If
    End Sub

    Private Sub dgExclCustomer_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgExclCustomer.GotFocus
        lblExclCustomer.ForeColor = Color.DarkCyan
        Got_Focus_Grid = "dgExclCustomer"
    End Sub

    Private Sub dgExclCustomer_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgExclCustomer.LostFocus
        lblExclCustomer.ForeColor = Color.Black
        '      Got_Focus_Grid = ""
    End Sub

    Private Sub dgMatBreakdown_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgMatBreakdown.DoubleClick
        If dgMatBreakdown.Rows.Count = 0 Then
            Exit Sub
        End If

        Select Case dgMatBreakdown.CurrentCell.ColumnIndex
            Case 1
                If mode = "UPDATE" Then
                    Recordstatus = True
                    If dgMatBreakdown.CurrentCell.Value = "" Then
                        dgMatBreakdown.CurrentCell.Value = "Y"
                    Else
                        dgMatBreakdown.CurrentCell.Value = ""
                    End If


                    Dim CREUSR As String = rs_IMMATBKD.Tables("RESULT").Rows(dgMatBreakdown.CurrentCell.RowIndex).Item("ibm_creusr")
                    If CREUSR <> "~*ADD*~" And CREUSR <> "~*UPD*~" And CREUSR <> "~*DEL*~" And CREUSR <> "~*NEW*~" Then
                        Recordstatus = True
                        rs_IMMATBKD.Tables("RESULT").Rows(dgMatBreakdown.CurrentCell.RowIndex).Item("ibm_creusr") = "~*UPD*~"
                    End If
                End If
        End Select
    End Sub

    Private Sub dgMatBreakdown_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgMatBreakdown.EditingControlShowing
        If mode = "UPDATE" Then
            Dim CREUSR As String = rs_IMMATBKD.Tables("RESULT").Rows(dgMatBreakdown.CurrentCell.RowIndex).Item("ibm_creusr")
            If CREUSR <> "~*ADD*~" And CREUSR <> "~*UPD*~" And CREUSR <> "~*DEL*~" And CREUSR <> "~*NEW*~" Then
                Recordstatus = True
                rs_IMMATBKD.Tables("RESULT").Rows(dgMatBreakdown.CurrentCell.RowIndex).Item("ibm_creusr") = "~*UPD*~"
            End If
        End If
    End Sub

    Private Sub dgMatBreakdown_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgMatBreakdown.GotFocus
        lblMatBreakdown.ForeColor = Color.DarkCyan
        Got_Focus_Grid = "dgMatBreakdown"
    End Sub

    Private Sub dgMatBreakdown_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgMatBreakdown.LostFocus
        lblMatBreakdown.ForeColor = Color.Black
        '       Got_Focus_Grid = ""
    End Sub

    Private Sub dgCusStyle_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgCusStyle.EditingControlShowing
        If mode = "UPDATE" Then
            Recordstatus = True
            rs_IMCUSSTY.Tables("RESULT").Rows(dgCusStyle.CurrentCell.RowIndex).Item("ics_creusr") = "~*UPD*~"
        End If
    End Sub

    Private Sub dgCusStyle_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCusStyle.GotFocus
        lblCusStyle.ForeColor = Color.DarkCyan
        Got_Focus_Grid = "dgCusStyle"
    End Sub

    Private Sub dgCusStyle_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCusStyle.LostFocus
        lblCusStyle.ForeColor = Color.Black
        '        Got_Focus_Grid = ""
    End Sub

    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click
        Select Case Got_Focus_Grid
            Case "dgPacking"
                TabPageMain.SelectedIndex = 0
                freeze_TabControl(0)
                Call add_Packing()
            Case "dgPV"
                TabPageMain.SelectedIndex = 1
                freeze_TabControl(1)
                Call add_PV()
            Case "dgOEMCustomer"
                TabPageMain.SelectedIndex = 2
                Call add_OEMCustomer()
            Case "dgBOMASS"
                TabPageMain.SelectedIndex = 3
                Call add_BOMASS()
            Case "dgExclCustomer"
                TabPageMain.SelectedIndex = 5
                Call add_ExclCustomer()
            Case "dgMatBreakdown"
                TabPageMain.SelectedIndex = 5
                Call add_MatBreakdown()
            Case "dgColor"
                TabPageMain.SelectedIndex = 0
                Call add_Color()
            Case "dgMOQMOA"
                If dgMOQMOA.Enabled = True Then
                    TabPageMain.SelectedIndex = 5
                    freeze_TabControl(5)
                    Call add_MOQMOA()
                End If
        End Select

        format_TabControl("IM", Split(cboItmTyp.Text, " - ")(0))
    End Sub

    Private Sub add_Color()
        Dim rowcount As Integer
        rowcount = rs_IMCOLINF.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_IMCOLINF.Tables("RESULT").Select("icf_colcde = ''")
        If dr.Length = 0 Then
            rs_IMCOLINF.Tables("RESULT").Rows.Add()
            rs_IMCOLINF.Tables("RESULT").Rows(rowcount).Item("icf_cocde") = ""
            rs_IMCOLINF.Tables("RESULT").Rows(rowcount).Item("icf_itmno") = txtItmNo.Text
            rs_IMCOLINF.Tables("RESULT").Rows(rowcount).Item("icf_colcde") = ""
            rs_IMCOLINF.Tables("RESULT").Rows(rowcount).Item("icf_colseq") = rowcount + 1
            rs_IMCOLINF.Tables("RESULT").Rows(rowcount).Item("icf_vencol") = ""
            rs_IMCOLINF.Tables("RESULT").Rows(rowcount).Item("icf_coldsc") = ""
            rs_IMCOLINF.Tables("RESULT").Rows(rowcount).Item("icf_ucpcde") = ""
            rs_IMCOLINF.Tables("RESULT").Rows(rowcount).Item("icf_eancde") = ""
            rs_IMCOLINF.Tables("RESULT").Rows(rowcount).Item("icf_creusr") = "~*ADD*~"

            Recordstatus = True
        End If
    End Sub

    Private Sub add_MatBreakdown()
        Dim rowcount As Integer
        rowcount = rs_IMMATBKD.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_IMMATBKD.Tables("RESULT").Select("ibm_mat = ''")
        If dr.Length = 0 Then
            rs_IMMATBKD.Tables("RESULT").Rows.Add()
            rs_IMMATBKD.Tables("RESULT").Rows(rowcount).Item("ibm_cocde") = ""
            rs_IMMATBKD.Tables("RESULT").Rows(rowcount).Item("ibm_itmno") = txtItmNo.Text
            rs_IMMATBKD.Tables("RESULT").Rows(rowcount).Item("ibm_matseq") = rowcount + 1
            rs_IMMATBKD.Tables("RESULT").Rows(rowcount).Item("ibm_mat") = ""
            rs_IMMATBKD.Tables("RESULT").Rows(rowcount).Item("ibm_curcde") = "USD"
            rs_IMMATBKD.Tables("RESULT").Rows(rowcount).Item("ibm_cst") = 0.0
            rs_IMMATBKD.Tables("RESULT").Rows(rowcount).Item("ibm_cstper") = 0.0
            rs_IMMATBKD.Tables("RESULT").Rows(rowcount).Item("ibm_wgtper") = 0.0
            rs_IMMATBKD.Tables("RESULT").Rows(rowcount).Item("ibm_creusr") = "~*ADD*~"
            Recordstatus = True
        End If
    End Sub

    Private Sub add_ExclCustomer()
        Dim rowcount As Integer
        rowcount = rs_IMCTYINF.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_IMCTYINF.Tables("RESULT").Select("ici_cusno = ''")
        If dr.Length = 0 Then
            rs_IMCTYINF.Tables("RESULT").Rows.Add()
            rs_IMCTYINF.Tables("RESULT").Rows(rowcount).Item("ici_cocde") = ""
            rs_IMCTYINF.Tables("RESULT").Rows(rowcount).Item("ici_itmno") = txtItmNo.Text
            rs_IMCTYINF.Tables("RESULT").Rows(rowcount).Item("ici_ctyseq") = rowcount + 1
            rs_IMCTYINF.Tables("RESULT").Rows(rowcount).Item("ici_cusno") = ""
            rs_IMCTYINF.Tables("RESULT").Rows(rowcount).Item("cbi_cusnam") = ""
            rs_IMCTYINF.Tables("RESULT").Rows(rowcount).Item("ici_ctycde") = ""
            rs_IMCTYINF.Tables("RESULT").Rows(rowcount).Item("ici_valdat") = Date.Now.Year().ToString() + "/" + Date.Now.Month().ToString() + "/" + Date.Now.Day().ToString()
            rs_IMCTYINF.Tables("RESULT").Rows(rowcount).Item("ici_rmk") = ""
            rs_IMCTYINF.Tables("RESULT").Rows(rowcount).Item("ici_creusr") = "~*ADD*~"
            Recordstatus = True
        End If
    End Sub

    Private Sub add_OEMCustomer()
        If Split(cboItmTyp.Text, " - ")(0) = "BOM" Then
            MsgBox("BOM item is not allowed to add OEM!")
            Exit Sub
        End If

        If Split(cboPrdTyp.Text, " - ")(0) <> "OEM" And Split(cboPrdTyp.Text, " - ")(0) <> "ODM" Then
            Exit Sub
        End If

        Dim rowcount As Integer
        rowcount = rs_IMCUSNO.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_IMCUSNO.Tables("RESULT").Select("icn_cusno = ''")
        If dr.Length = 0 Then
            rs_IMCUSNO.Tables("RESULT").Rows.Add()
            rs_IMCUSNO.Tables("RESULT").Rows(rowcount).Item("icn_status") = ""
            rs_IMCUSNO.Tables("RESULT").Rows(rowcount).Item("icn_itmno") = txtItmNo.Text
            rs_IMCUSNO.Tables("RESULT").Rows(rowcount).Item("icn_cusno") = ""
            rs_IMCUSNO.Tables("RESULT").Rows(rowcount).Item("cbi_cussna") = ""
            rs_IMCUSNO.Tables("RESULT").Rows(rowcount).Item("icn_rmk") = ""
            rs_IMCUSNO.Tables("RESULT").Rows(rowcount).Item("icn_creusr") = "~*ADD*~"
            Recordstatus = True
        End If
    End Sub

    Private Sub add_BOMASS()
        If Split(cboItmTyp.Text, " - ")(0) = "BOM" Then
            MsgBox("BOM item is not allowed to add assorted/bom!")
            Exit Sub
        End If

        Dim rowcount As Integer
        rowcount = rs_IMBOMASS.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_IMBOMASS.Tables("RESULT").Select("iba_assitm = ''")
        If dr.Length = 0 Then
            rs_IMBOMASS.Tables("RESULT").Rows.Add()
            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_cocde") = ""
            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_itmno") = txtItmNo.Text
            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_assitm") = ""
            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("ivi_venitm") = ""
            If rbBOMASS_ASS.Checked = True Then
                rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_typ") = "ASS"
                rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_pckunt") = ""
                rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_bomqty") = 0
            Else
                rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_typ") = "BOM"
                rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_pckunt") = "PC"
                rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_bomqty") = 1
            End If
            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_colcde") = ""
            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_inrqty") = 0
            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_mtrqty") = 0
            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_altitmno") = ""
            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_costing") = ""
            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_genpo") = "N"
            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_untcst") = 0.0
            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_curcde") = "HKD"
            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_ftyfmlopt") = ""
            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_fmlopt") = ""
            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_bombasprc") = 0.0
            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_fcurcde") = "HKD"
            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_ftycst") = 0.0
            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_period") = ""
            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("vbi_vensna") = ""
            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("ibi_engdsc") = ""


            rs_IMBOMASS.Tables("RESULT").Rows(rowcount).Item("iba_creusr") = "~*ADD*~"
            Recordstatus = True
        End If
    End Sub

    Private Sub add_Packing()
        If PanelPacking.Visible = True Then
            Exit Sub
        End If

        'If Split(cboItmTyp.Text, " - ")(0) = "ASS" Or Split(cboItmTyp.Text, " - ")(0) = "BOM" Then
        '    If mode = "UPDATE" Then
        '        MsgBox("Assortment/BOM item is not allowed to add packing!")
        '        Exit Sub
        '    ElseIf mode = "ADD" Then
        '        If rs_IMPCKINF.Tables("RESULT").Rows.Count >= 1 Then
        '            MsgBox("Assortment/BOM item is not allowed to add packing!")
        '            Exit Sub
        '        End If
        '    End If
        'End If

        PanelPacking.Visible = True
        If Split(cboItmTyp.Text, " - ")(0) = "ASS" Then
            If mode = "ADD" Then
                If rs_IMPCKINF.Tables("RESULT").Rows.Count = 0 Then
                    display_PanelPacking("PACK_INSERT")
                Else
                    display_PanelPacking("PACK_INSERT_ASS")
                End If
            ElseIf mode = "UPDATE" Then
                display_PanelPacking("PACK_INSERT_ASS")
            End If
        ElseIf Split(cboItmTyp.Text, " - ")(0) = "BOM" Then
            If mode = "UPDATE" Then
                PanelPacking.Visible = False
                MsgBox("BOM item is not allowed to add packing!")
                Exit Sub
            ElseIf mode = "ADD" Then
                If rs_IMPCKINF.Tables("RESULT").Rows.Count = 0 Then
                    display_PanelPacking("PACK_INSERT_BOM")
                Else
                    PanelPacking.Visible = False
                    MsgBox("Assortment/BOM item is not allowed to add packing!")
                    Exit Sub
                End If
            End If
        Else
            PanelPacking.Visible = True
            display_PanelPacking("PACK_INSERT")
        End If
    End Sub

    Private Sub dgPacking_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgPacking.RowHeaderMouseDoubleClick
        freeze_TabControl(0)
        PanelPacking.Visible = True
        If mode = "UPDATE" Or mode = "ADD" Then
            If mode = "ADD" And Split(cboItmTyp.Text, " - ")(0) = "ASS" Then
                Call display_PanelPacking("PACK_UPDATE2")
            Else
                Dim curvalue As String
                curvalue = dgPacking.Item(dgPacking_ipi_cocde, dgPacking.CurrentCell.RowIndex).Value

                If curvalue = "Y" Then
                    Call display_PanelPacking("PACK_READ")
                Else
                    Call display_PanelPacking("PACK_UPDATE")
                End If
            End If
        Else
            Call display_PanelPacking("PACK_READ")
        End If
    End Sub


    Private Sub display_PanelPacking(ByVal m As String)
        If rs_IMPCKINF.Tables.Count = 0 Then
            Exit Sub
        End If

        If m = "PACK_READ" Then
            cmdPanPackInsert.Enabled = False
            cmdPanPackUpdate.Enabled = False
            cmdPanPackCancel.Enabled = True

            cboPanPackUM.Enabled = False
            txtPanPackConFtr.Enabled = False
            txtPanPackInner.Enabled = False
            txtPanPackMaster.Enabled = False

            cboPanPackCus1no.Enabled = False
            cboPanPackCus2no.Enabled = False

            txtPanPackPeriod.Enabled = False
            txtPanPackCFT.Enabled = False
            txtPanPackCBM.Enabled = False
            txtPanPackGW.Enabled = False
            txtPanPackNW.Enabled = False

            txtPanPackInnerInchL.Enabled = False
            txtPanPackInnerInchW.Enabled = False
            txtPanPackInnerInchH.Enabled = False

            txtPanPackInnerCML.Enabled = False
            txtPanPackInnerCMW.Enabled = False
            txtPanPackInnerCMH.Enabled = False

            txtPanPackMasterInchL.Enabled = False
            txtPanPackMasterInchW.Enabled = False
            txtPanPackMasterInchH.Enabled = False

            txtPanPackMasterCML.Enabled = False
            txtPanPackMasterCMW.Enabled = False
            txtPanPackMasterCMH.Enabled = False

            txtPanPackPackingInstruction.Enabled = False

            txtPanPackInnerSize.Enabled = False
            txtPanPackMasterSize.Enabled = False
            txtPanPackMaterial.Enabled = False

        ElseIf m = "PACK_UPDATE" Or m = "PACK_UPDATE2" Then
            cmdPanPackInsert.Enabled = False
            cmdPanPackUpdate.Enabled = True
            cmdPanPackCancel.Enabled = True

            If m = "PACK_UPDATE" Then
                cboPanPackUM.Enabled = False
                txtPanPackConFtr.Enabled = False
                txtPanPackInner.Enabled = False
                txtPanPackMaster.Enabled = False
                cboPanPackCus1no.Enabled = False
                cboPanPackCus2no.Enabled = False
            Else
                cboPanPackUM.Enabled = True
                txtPanPackConFtr.Enabled = False
                txtPanPackInner.Enabled = True
                txtPanPackMaster.Enabled = True
                cboPanPackCus1no.Enabled = True
                cboPanPackCus2no.Enabled = True
            End If

            txtPanPackPeriod.Enabled = True
            txtPanPackCFT.Enabled = True
            txtPanPackCBM.Enabled = True
            txtPanPackGW.Enabled = True
            txtPanPackNW.Enabled = True

            txtPanPackInnerInchL.Enabled = True
            txtPanPackInnerInchW.Enabled = True
            txtPanPackInnerInchH.Enabled = True

            txtPanPackInnerCML.Enabled = True
            txtPanPackInnerCMW.Enabled = True
            txtPanPackInnerCMH.Enabled = True

            txtPanPackMasterInchL.Enabled = True
            txtPanPackMasterInchW.Enabled = True
            txtPanPackMasterInchH.Enabled = True

            txtPanPackMasterCML.Enabled = True
            txtPanPackMasterCMW.Enabled = True
            txtPanPackMasterCMH.Enabled = True

            txtPanPackPackingInstruction.Enabled = True

            txtPanPackInnerSize.Enabled = True
            txtPanPackMasterSize.Enabled = True
            txtPanPackMaterial.Enabled = True
        ElseIf m = "PACK_INSERT" Or m = "PACK_INSERT_ASS" Or m = "PACK_INSERT_BOM" Then
            cmdPanPackInsert.Enabled = True
            cmdPanPackUpdate.Enabled = False
            cmdPanPackCancel.Enabled = True

            If m = "PACK_INSERT" Then
                cboPanPackUM.Enabled = True
                txtPanPackConFtr.Enabled = False
                txtPanPackInner.Enabled = True
                txtPanPackMaster.Enabled = True
                cboPanPackCus1no.Enabled = True
                cboPanPackCus2no.Enabled = True
            ElseIf m = "PACK_INSERT_ASS" Then
                display_combo(rs_IMPCKINF.Tables("RESULT").Rows(0)("ipi_pckunt"), cboPanPackUM)
                txtPanPackConFtr.Text = rs_IMPCKINF.Tables("RESULT").Rows(0)("ipi_conftr")
                txtPanPackInner.Text = rs_IMPCKINF.Tables("RESULT").Rows(0)("ipi_inrqty")
                txtPanPackMaster.Text = rs_IMPCKINF.Tables("RESULT").Rows(0)("ipi_mtrqty")

                cboPanPackUM.Enabled = False
                txtPanPackConFtr.Enabled = False
                txtPanPackInner.Enabled = False
                txtPanPackMaster.Enabled = False
                cboPanPackCus1no.Enabled = True
                cboPanPackCus2no.Enabled = True
            ElseIf m = "PACK_INSERT_BOM" Then
                cboPanPackCus1no.Text = ""
                cboPanPackCus2no.Text = ""
                cboPanPackUM.Enabled = True
                txtPanPackConFtr.Enabled = False
                txtPanPackInner.Enabled = True
                txtPanPackMaster.Enabled = True
                cboPanPackCus1no.Enabled = False
                cboPanPackCus2no.Enabled = False
            End If
            

            txtPanPackPeriod.Enabled = True
            txtPanPackCFT.Enabled = True
            txtPanPackCBM.Enabled = True
            txtPanPackGW.Enabled = True
            txtPanPackNW.Enabled = True

            txtPanPackInnerInchL.Enabled = True
            txtPanPackInnerInchW.Enabled = True
            txtPanPackInnerInchH.Enabled = True

            txtPanPackInnerCML.Enabled = True
            txtPanPackInnerCMW.Enabled = True
            txtPanPackInnerCMH.Enabled = True

            txtPanPackMasterInchL.Enabled = True
            txtPanPackMasterInchW.Enabled = True
            txtPanPackMasterInchH.Enabled = True

            txtPanPackMasterCML.Enabled = True
            txtPanPackMasterCMW.Enabled = True
            txtPanPackMasterCMH.Enabled = True

            txtPanPackPackingInstruction.Enabled = True

            txtPanPackInnerSize.Enabled = True
            txtPanPackMasterSize.Enabled = True
            txtPanPackMaterial.Enabled = True
        End If

        If m = "PACK_READ" Or m = "PACK_UPDATE" Or m = "PACK_UPDATE2" Then

            Dim i As Integer
            Dim displayrow As Integer
            displayrow = -1

            Dim display_um As String
            Dim display_inr As String
            Dim display_mtr As String
            Dim display_cus1no As String
            Dim display_cus2no As String

            display_um = dgPacking.Item(6, dgPacking.CurrentCell.RowIndex).Value
            display_inr = dgPacking.Item(7, dgPacking.CurrentCell.RowIndex).Value
            display_mtr = dgPacking.Item(8, dgPacking.CurrentCell.RowIndex).Value
            display_cus1no = dgPacking.Item(dgPacking_ipi_cus1no, dgPacking.CurrentCell.RowIndex).Value
            display_cus2no = dgPacking.Item(dgPacking_ipi_cus2no, dgPacking.CurrentCell.RowIndex).Value

            For i = 0 To rs_IMPCKINF.Tables("RESULT").Rows.Count - 1
                If rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_pckunt") = display_um And _
                    rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_inrqty") = display_inr And _
                    rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_mtrqty") = display_mtr And _
                    rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cus1no") = display_cus1no And _
                    rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cus2no") = display_cus2no Then
                    displayrow = i
                End If
            Next i

            If displayrow <> -1 Then
                cboPanPackUM.Text = rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("ipi_pckunt")
                txtPanPackConFtr.Text = rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("ipi_conftr")
                txtPanPackInner.Text = rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("ipi_inrqty")
                txtPanPackMaster.Text = rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("ipi_mtrqty")

                display_combo(rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("ipi_cus1no"), cboPanPackCus1no)
                display_combo(rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("ipi_cus2no"), cboPanPackCus2no)

                txtPanPackPeriod.Text = rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("ipi_qutdat")
                txtPanPackCFT.Text = rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("ipi_cft")
                txtPanPackCBM.Text = rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("ipi_cbm")
                txtPanPackGW.Text = rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("ipi_grswgt")
                txtPanPackNW.Text = rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("ipi_netwgt")

                txtPanPackInnerInchL.Text = Split(rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("inner_in"), "x")(0)
                txtPanPackInnerInchW.Text = Split(rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("inner_in"), "x")(1)
                txtPanPackInnerInchH.Text = Split(rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("inner_in"), "x")(2)

                txtPanPackInnerCML.Text = Split(rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("inner_cm"), "x")(0)
                txtPanPackInnerCMW.Text = Split(rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("inner_cm"), "x")(1)
                txtPanPackInnerCMH.Text = Split(rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("inner_cm"), "x")(2)

                txtPanPackMasterInchL.Text = Split(rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("master_in"), "x")(0)
                txtPanPackMasterInchW.Text = Split(rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("master_in"), "x")(1)
                txtPanPackMasterInchH.Text = Split(rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("master_in"), "x")(2)

                txtPanPackMasterCML.Text = Split(rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("master_cm"), "x")(0)
                txtPanPackMasterCMW.Text = Split(rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("master_cm"), "x")(1)
                txtPanPackMasterCMH.Text = Split(rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("master_cm"), "x")(2)

                txtPanPackPackingInstruction.Text = IIf(IsDBNull(rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("ipi_pckitr")), "", rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("ipi_pckitr"))

                txtPanPackInnerSize.Text = IIf(IsDBNull(rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("ipi_inrsze")), "", rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("ipi_inrsze"))
                txtPanPackMasterSize.Text = IIf(IsDBNull(rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("ipi_mtrsze")), "", rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("ipi_mtrsze"))
                txtPanPackMaterial.Text = IIf(IsDBNull(rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("ipi_mat")), "", rs_IMPCKINF.Tables("RESULT").Rows(displayrow).Item("ipi_mat"))
            End If
            txtPanPackCFT.Select()
        ElseIf m = "PACK_INSERT" Then
            cboPanPackUM.Text = ""
            txtPanPackConFtr.Text = 1
            txtPanPackInner.Text = ""
            txtPanPackMaster.Text = ""
            cboPanPackCus1no.Text = ""
            cboPanPackCus2no.Text = ""

            If Len(Today.Month.ToString) = 1 Then
                txtPanPackPeriod.Text = Today.Year.ToString & "-0" & Today.Month.ToString
            Else
                txtPanPackPeriod.Text = Today.Year.ToString & "-" & Today.Month.ToString
            End If

            txtPanPackCFT.Text = "0"
            txtPanPackCBM.Text = "0"
            txtPanPackGW.Text = "0"
            txtPanPackNW.Text = "0"

            txtPanPackInnerInchL.Text = "0"
            txtPanPackInnerInchW.Text = "0"
            txtPanPackInnerInchH.Text = "0"

            txtPanPackInnerCML.Text = "0"
            txtPanPackInnerCMW.Text = "0"
            txtPanPackInnerCMH.Text = "0"

            txtPanPackMasterInchL.Text = "0"
            txtPanPackMasterInchW.Text = "0"
            txtPanPackMasterInchH.Text = "0"

            txtPanPackMasterCML.Text = "0"
            txtPanPackMasterCMW.Text = "0"
            txtPanPackMasterCMH.Text = "0"

            txtPanPackPackingInstruction.Text = ""

            txtPanPackInnerSize.Text = ""
            txtPanPackMasterSize.Text = ""
            txtPanPackMaterial.Text = ""

            cboPanPackUM.Select()
        End If

    End Sub

    Private Sub cmdPanPackCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanPackCancel.Click
        PanelPacking.Visible = False
        release_TabControl()
        format_TabControl("IM", Split(cboItmTyp.Text, " - ")(0))
    End Sub

    Private Function check_PanPack(ByVal m As String) As Boolean
        check_PanPack = True

        If cboPanPackUM.Text = "" Or txtPanPackInner.Text = "" Or txtPanPackMaster.Text = "" Or cboPanPackCus1no.Text = "" Then
            MsgBox("Packing incomplete, please check!")
            check_PanPack = False
            Exit Function
        End If
        If Not (IsNumeric(txtPanPackInner.Text) And IsNumeric(txtPanPackMaster.Text)) Then
            MsgBox("Invalid Packing inner or master quantity!")
            check_PanPack = False
            Exit Function
        End If

        If Not (IsNumeric(Mid(txtPanPackPeriod.Text, 1, 4)) And IsNumeric(Mid(txtPanPackPeriod.Text, 6, 2))) Then
            MsgBox("Invalid Packing Period!")
            check_PanPack = False
            Exit Function
        End If

        If Not (Mid(txtPanPackPeriod.Text, 1, 4) >= "1900" And Mid(txtPanPackPeriod.Text, 1, 4) <= "2099") Then
            MsgBox("Invalid Packing Period Year!")
            txtPanPackPeriod.SelectAll()
            check_PanPack = False
            Exit Function
        End If

        If Not (Mid(txtPanPackPeriod.Text, 6, 2) >= "01" And Mid(txtPanPackPeriod.Text, 6, 2) <= "12") Then
            MsgBox("Invalid Packing Period Month!")
            txtPanPackPeriod.SelectAll()
            check_PanPack = False
            Exit Function
        End If

        If Not IsNumeric(txtPanPackCFT.Text) Then
            MsgBox("Invalid Packing CFT!")
            txtPanPackCFT.SelectAll()
            check_PanPack = False
            Exit Function
        End If
        If Not IsNumeric(txtPanPackCBM.Text) Then
            MsgBox("Invalid Packing CBM!")
            txtPanPackCBM.SelectAll()
            check_PanPack = False
            Exit Function
        End If

        If Not IsNumeric(txtPanPackGW.Text) Then
            MsgBox("Invalid Packing GW!")
            txtPanPackGW.SelectAll()
            check_PanPack = False
            Exit Function
        End If
        If Not IsNumeric(txtPanPackNW.Text) Then
            MsgBox("Invalid Packing NW!")
            txtPanPackNW.SelectAll()
            check_PanPack = False
            Exit Function
        End If

        If Not IsNumeric(txtPanPackInnerInchL.Text) Then
            MsgBox("Invalid Packing Inner Inch L!")
            txtPanPackInnerInchL.SelectAll()
            check_PanPack = False
            Exit Function
        End If
        If Not IsNumeric(txtPanPackInnerInchW.Text) Then
            MsgBox("Invalid Packing Inner Inch W!")
            txtPanPackInnerInchW.SelectAll()
            check_PanPack = False
            Exit Function
        End If
        If Not IsNumeric(txtPanPackInnerInchH.Text) Then
            MsgBox("Invalid Packing Inner Inch H!")
            txtPanPackInnerInchH.SelectAll()
            check_PanPack = False
            Exit Function
        End If

        If Not IsNumeric(txtPanPackInnerCML.Text) Then
            MsgBox("Invalid Packing Inner cm L!")
            txtPanPackInnerCML.SelectAll()
            check_PanPack = False
            Exit Function
        End If
        If Not IsNumeric(txtPanPackInnerCMW.Text) Then
            MsgBox("Invalid Packing Inner cm W!")
            txtPanPackInnerCMW.SelectAll()
            check_PanPack = False
            Exit Function
        End If
        If Not IsNumeric(txtPanPackInnerCMH.Text) Then
            MsgBox("Invalid Packing Inner cm H!")
            txtPanPackInnerCMH.SelectAll()
            check_PanPack = False
            Exit Function
        End If

        If Not IsNumeric(txtPanPackMasterInchL.Text) Then
            MsgBox("Invalid Packing Master Inch L!")
            txtPanPackMasterInchL.SelectAll()
            check_PanPack = False
            Exit Function
        End If
        If Not IsNumeric(txtPanPackMasterInchW.Text) Then
            MsgBox("Invalid Packing Master Inch W!")
            txtPanPackMasterInchW.SelectAll()
            check_PanPack = False
            Exit Function
        End If
        If Not IsNumeric(txtPanPackMasterInchH.Text) Then
            MsgBox("Invalid Packing Master Inch H!")
            txtPanPackMasterInchH.SelectAll()
            check_PanPack = False
            Exit Function
        End If

        If Not IsNumeric(txtPanPackMasterCML.Text) Then
            MsgBox("Invalid Packing Master cm L!")
            txtPanPackMasterCML.SelectAll()
            check_PanPack = False
            Exit Function
        End If
        If Not IsNumeric(txtPanPackMasterCMW.Text) Then
            MsgBox("Invalid Packing Master cm W!")
            txtPanPackMasterCMW.SelectAll()
            check_PanPack = False
            Exit Function
        End If
        If Not IsNumeric(txtPanPackMasterCMH.Text) Then
            MsgBox("Invalid Packing Master cm H!")
            txtPanPackMasterCMH.SelectAll()
            check_PanPack = False
            Exit Function
        End If

        If m = "Insert" Then
            Dim pack_um As String
            Dim pack_ftr As String
            Dim pack_inr As String
            Dim pack_mtr As String
            Dim pack_cus1no As String
            Dim pack_cus2no As String

            pack_um = cboPanPackUM.Text
            pack_ftr = txtPanPackConFtr.Text
            pack_inr = txtPanPackInner.Text
            pack_mtr = txtPanPackMaster.Text
            pack_cus1no = Split(cboPanPackCus1no.Text, " - ")(0)
            pack_cus2no = Split(cboPanPackCus2no.Text, " - ")(0)

            Dim i As Integer
            For i = 0 To rs_IMPCKINF.Tables("RESULT").Rows.Count - 1
                If (pack_um = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_pckunt") And _
                    pack_ftr = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_conftr") And _
                    pack_inr = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_inrqty") And _
                    pack_mtr = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_mtrqty") And _
                    pack_cus1no = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cus1no") And _
                    pack_cus2no = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cus2no")) Then
                    MsgBox("Packing : " & pack_um & " / " & pack_inr & " / " & pack_mtr & " already exist!")
                    check_PanPack = False
                    Exit Function
                End If
            Next i
        End If
        'Check CFT vs Master CM 3% prompt alter
        If IsNumeric(txtPanPackMasterCML.Text) And IsNumeric(txtPanPackMasterCMW.Text) And IsNumeric(txtPanPackMasterCMH.Text) Then
            Dim tmp_mtrcmL As Decimal
            Dim tmp_mtrcmW As Decimal
            Dim tmp_mtrcmH As Decimal
            Dim cal_cbm As Decimal
            Dim tmp_cbm As Decimal
            tmp_mtrcmL = txtPanPackMasterCML.Text
            tmp_mtrcmW = txtPanPackMasterCMW.Text
            tmp_mtrcmH = txtPanPackMasterCMH.Text
            tmp_cbm = txtPanPackCBM.Text
            cal_cbm = Decimal.Round(tmp_mtrcmL * tmp_mtrcmW * tmp_mtrcmH / 1000000, 4)

            Dim variance As Decimal
            If tmp_cbm = 0 Then
                variance = 0
            Else
                variance = ((cal_cbm - tmp_cbm) / tmp_cbm) * 100
            End If

            If variance >= 3 Or variance <= -3 Then
                MsgBox("Master LxWxH with variance over 3 %!")
            End If
        End If
    End Function

    Private Sub cmdPanPackInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanPackInsert.Click

        If check_PanPack("Insert") = False Then
            Exit Sub
        End If
        'Exit Sub

        Dim rowcount As Integer
        rowcount = rs_IMPCKINF.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_IMPCKINF.Tables("RESULT").Select("ipi_pckunt = ''")
        If dr.Length = 0 And PanelPacking.Visible = True Then
            rs_IMPCKINF.Tables("RESULT").Rows.Add()

            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_cocde") = ""
            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_itmno") = txtItmNo.Text
            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_pckseq") = rowcount + 1

            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_pckunt") = cboPanPackUM.Text

            If Split(cboItmTyp.Text, " - ")(0) = "ASS" Then
                rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_conftr") = txtPanPackConFtr.Text
            Else
                rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_conftr") = 1
            End If
            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_inrqty") = txtPanPackInner.Text
            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_mtrqty") = txtPanPackMaster.Text
            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_cus1no") = Split(cboPanPackCus1no.Text, " - ")(0)
            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_cus2no") = Split(cboPanPackCus2no.Text, " - ")(0)

            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_qutdat") = txtPanPackPeriod.Text
            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_cft") = txtPanPackCFT.Text
            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_cbm") = txtPanPackCBM.Text
            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_grswgt") = txtPanPackGW.Text
            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_netwgt") = txtPanPackNW.Text

            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("inner_in") = txtPanPackInnerInchL.Text & "x" & txtPanPackInnerInchW.Text & "x" & txtPanPackInnerInchH.Text
            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("inner_cm") = txtPanPackInnerCML.Text & "x" & txtPanPackInnerCMW.Text & "x" & txtPanPackInnerCMH.Text
            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("master_in") = txtPanPackMasterInchL.Text & "x" & txtPanPackMasterInchW.Text & "x" & txtPanPackMasterInchH.Text
            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("master_cm") = txtPanPackMasterCML.Text & "x" & txtPanPackMasterCMW.Text & "x" & txtPanPackMasterCMH.Text

            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_pckitr") = IIf(txtPanPackPackingInstruction.Text.Length = 0, "", Replace(txtPanPackPackingInstruction.Text, "'", "''"))

            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_inrsze") = Replace(txtPanPackInnerSize.Text, "'", "''")
            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_mtrsze") = Replace(txtPanPackMasterSize.Text, "'", "''")
            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_mat") = Replace(txtPanPackMaterial.Text, "'", "''")

            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_cusno") = ""

            rs_IMPCKINF.Tables("RESULT").Rows(rowcount).Item("ipi_creusr") = "~*ADD*~"
            Recordstatus = True


            Dim dv As String
            dv = Split(cboDV.Text, " - ")(0)

            For i As Integer = 0 To rs_IMVENINF.Tables("RESULT").Rows.Count - 1
                rs_IMPRCINF.Tables("RESULT").Rows.Add()
                rowcount = rs_IMPRCINF.Tables("RESULT").Rows.Count - 1

                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cocde") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_itmno") = txtItmNo.Text
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_typ") = Split(cboItmTyp.Text, " - ")(0)

                If dv = rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_venno") Or Split(cboItmTyp.Text, " - ")(0) = "BOM" Then
                    rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ventyp") = "D"
                Else
                    rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ventyp") = "P"
                End If

                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_venno") = dv
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_prdven") = rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_venno")

                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_pckunt") = cboPanPackUM.Text
                If Split(cboItmTyp.Text, " - ")(0) = "ASS" Then
                    rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_conftr") = txtPanPackConFtr.Text
                Else
                    rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_conftr") = 1
                End If
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_inrqty") = txtPanPackInner.Text
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_mtrqty") = txtPanPackMaster.Text
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cft") = txtPanPackCFT.Text

                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_packing") = cboPanPackUM.Text & " / " & txtPanPackInner.Text & " / " & txtPanPackMaster.Text & " / " & txtPanPackCFT.Text

                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cus1no") = Split(cboPanPackCus1no.Text, " - ")(0)
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cus2no") = Split(cboPanPackCus2no.Text, " - ")(0)

                If Split(cboItmVenTyp.Text, " - ")(0) = "EXT" Then
                    rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprctrm") = "FOR HK"
                Else
                    rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprctrm") = "FOB HK"
                End If

                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_hkprctrm") = "FOB HK"
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_trantrm") = "FCL"
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_effdat") = Today.ToString
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_expdat") = Today.AddYears(1).ToString
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_status") = "INA"
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_curcde") = getdefaultCurrency(dv)
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycst") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstA") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstB") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstC") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstD") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstE") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstTran") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstPack") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fml") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlA") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlB") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlC") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlD") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlE") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlTran") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlPack") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfp") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpA") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpB") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpC") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpD") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpE") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpTran") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpPack") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprc") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcA") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcB") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcC") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcD") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcE") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcTran") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcPack") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_bomcst") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ttlcst") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_hkadjper") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_negcst") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_negprc") = 0.0

                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_estprcflg") = "N"
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_estprcref") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_sysgen") = "N"


                'rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlopt") = ""

                Dim fml_vencde As String
                Dim fml_ventyp As String
                Dim fml_cus1no As String
                Dim fml_cus2no As String
                Dim fml_catlvl4 As String
                Dim fml_imtyp As String

                fml_vencde = rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_venno")
                fml_ventyp = Split(cboItmVenTyp.Text, " - ")(0)
                fml_cus1no = ""
                fml_cus2no = ""
                fml_catlvl4 = Split(cboCategory.Text, " - ")(0)
                If rbIMTyp_PCIM.Checked = True Then
                    fml_imtyp = "PCIM"
                Else
                    fml_imtyp = "IM"
                End If
                getformula(fml_vencde, fml_ventyp, fml_cus1no, fml_cus2no, fml_catlvl4, fml_imtyp)

                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlopt") = tmp_calfml_hk.Text

                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_bcurcde") = "USD"
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_itmprc") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_bomprc") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_basprc") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_period") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cstchgdat") = Today.ToString

                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_pckunt_org") = cboPanPackUM.Text
                If Split(cboItmTyp.Text, " - ")(0) = "ASS" Then
                    rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_conftr_org") = txtPanPackConFtr.Text
                Else
                    rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_conftr_org") = 1
                End If

                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_inrqty_org") = txtPanPackInner.Text
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_mtrqty_org") = txtPanPackMaster.Text
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cft_org") = txtPanPackCFT.Text
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cus1no_org") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cus2no_org") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprctrm_org") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_hkprctrm_org") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_trantrm_org") = ""

                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_creusr") = "~*ADD*~"
                Recordstatus = True
            Next i

            PanelPacking.Visible = False
            release_TabControl()
            format_TabControl("IM", Split(cboItmTyp.Text, " - ")(0))
        End If
    End Sub

    Private Sub cmdPanPackUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanPackUpdate.Click
        If check_PanPack("Update") = False Then
            Exit Sub
        End If

        Dim updrow As Integer
        updrow = -1
        For i As Integer = 0 To rs_IMPCKINF.Tables("RESULT").Rows.Count - 1
            If rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_pckunt") = cboPanPackUM.Text And _
                rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_inrqty") = txtPanPackInner.Text And _
                rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_mtrqty") = txtPanPackMaster.Text And _
                rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cus1no") = Split(cboPanPackCus1no.Text, " - ")(0) And _
                rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cus2no") = Split(cboPanPackCus2no.Text, " - ")(0) Then
                updrow = i
            End If
        Next i

        'If mode = "ADD" And Split(cboItmTyp.Text, " - ")(0) = "ASS" Then
        '    updrow = 0
        '    rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("ipi_pckunt") = cboPanPackUM.Text
        '    rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("ipi_inrqty") = txtPanPackInner.Text
        '    rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("ipi_mtrqty") = txtPanPackMaster.Text
        '    rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("ipi_conftr") = txtPanPackConFtr.Text
        '    rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("ipi_cus1no") = Split(cboPanPackCus1no.Text, " - ")(0)
        '    rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("ipi_cus2no") = Split(cboPanPackCus2no.Text, " - ")(0)

        '    For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
        '        rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_pckunt") = cboPanPackUM.Text
        '        rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_inrqty") = txtPanPackInner.Text
        '        rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_mtrqty") = txtPanPackMaster.Text
        '        rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cft") = txtPanPackCFT.Text
        '        rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_packing") = cboPanPackUM.Text & " / " & txtPanPackInner.Text & " / " & txtPanPackMaster.Text & " / " & txtPanPackCFT.Text
        '    Next i

        'End If
        Dim dr_IMPRCINF() As DataRow = rs_IMPRCINF.Tables("RESULT").Select("imu_pckunt = '" & cboPanPackUM.Text & "' and " & _
                                                                           "imu_inrqty = '" & txtPanPackInner.Text & "' and " & _
                                                                           "imu_mtrqty = '" & txtPanPackMaster.Text & "' and " & _
                                                                           "imu_cus1no = '" & Split(cboPanPackCus1no.Text, " - ")(0) & "' and " & _
                                                                           "imu_cus2no = '" & Split(cboPanPackCus2no.Text, " - ")(0) & "'")
        If dr_IMPRCINF.Length > 0 Then
            For i As Integer = 0 To dr_IMPRCINF.Length - 1
                dr_IMPRCINF(i)("imu_cft") = txtPanPackCFT.Text
            Next
        End If

        If updrow <> -1 Then
            Dim flag_updateCFT As Boolean
            flag_updateCFT = False

            If rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("ipi_cft") <> txtPanPackCFT.Text Then
                flag_updateCFT = True

                'If MsgBox("Are you sure to change cft? All related cft info will be updated.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                '    flag_updateCFT = True
                'Else
                '    flag_updateCFT = False
                '    Exit Sub
                'End If
            End If



            rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("ipi_qutdat") = txtPanPackPeriod.Text
            rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("ipi_cft") = txtPanPackCFT.Text
            rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("ipi_cbm") = txtPanPackCBM.Text
            rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("ipi_grswgt") = txtPanPackGW.Text
            rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("ipi_netwgt") = txtPanPackNW.Text

            rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("inner_in") = txtPanPackInnerInchL.Text & "x" & txtPanPackInnerInchW.Text & "x" & txtPanPackInnerInchH.Text
            rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("inner_cm") = txtPanPackInnerCML.Text & "x" & txtPanPackInnerCMW.Text & "x" & txtPanPackInnerCMH.Text
            rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("master_in") = txtPanPackMasterInchL.Text & "x" & txtPanPackMasterInchW.Text & "x" & txtPanPackMasterInchH.Text
            rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("master_cm") = txtPanPackMasterCML.Text & "x" & txtPanPackMasterCMW.Text & "x" & txtPanPackMasterCMH.Text

            rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("ipi_pckitr") = IIf(txtPanPackPackingInstruction.Text.Length = 0, "", Replace(txtPanPackPackingInstruction.Text, "'", "''"))
            rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("ipi_inrsze") = Replace(txtPanPackInnerSize.Text, "'", "''")
            rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("ipi_mtrsze") = Replace(txtPanPackMasterSize.Text, "'", "''")
            rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("ipi_mat") = Replace(txtPanPackMaterial.Text, "'", "''")

            If rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("ipi_creusr") <> "~*ADD*~" Then
                rs_IMPCKINF.Tables("RESULT").Rows(updrow).Item("ipi_creusr") = "~*UPD*~"
            End If


            Recordstatus = True

            If flag_updateCFT = True Then
                For i As Integer = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
                    If rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_pckunt") = cboPanPackUM.Text And _
                        rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_inrqty") = txtPanPackInner.Text And _
                        rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_mtrqty") = txtPanPackMaster.Text Then

                        rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cft") = txtPanPackCFT.Text
                        rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_packing") = cboPanPackUM.Text & " / " & txtPanPackInner.Text & " / " & txtPanPackMaster.Text & " / " & txtPanPackCFT.Text

                        If rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_creusr") <> "~*ADD*~" Then
                            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_creusr") = "~*UPD*~"
                        End If
                        Recordstatus = True
                    End If
                Next i
            End If

            PanelPacking.Visible = False
            release_TabControl()
            format_TabControl("IM", Split(cboItmTyp.Text, " - ")(0))
        End If
    End Sub

    Private Sub add_PV()
        If PanelPV.Visible = True Then
            Exit Sub
        End If

        If Split(cboItmTyp.Text, " - ")(0) = "BOM" Then
            If mode = "UPDATE" Then
                MsgBox("BOM item is not allowed to add Production Vendor!")
                Exit Sub
            ElseIf mode = "ADD" Then
                If rs_IMVENINF.Tables("RESULT").Rows.Count >= 1 Then
                    MsgBox("BOM item is not allowed to add Production Vendor!")
                    Exit Sub
                End If
            End If
        End If

        PanelPV.Visible = True
        txtPanPVVenItm.Text = ""
        cboPanPVPV.Text = ""

        Dim i As Integer
        For i = 0 To rs_IMVENINF.Tables("RESULT").Rows.Count - 1
            If rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_def") = "Y" Then
                txtPanPVVenItm.Text = rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_venitm")
                Exit Sub
            End If
        Next i
    End Sub

    Private Sub cmdPanPVInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanPVInsert.Click
        If txtPanPVVenItm.Text = "" Then
            MsgBox("Vendor Item Number is empty!")
            Exit Sub
        End If

        If cboPanPVPV.Text = "" Then
            MsgBox("Production Vendor is empty!")
            Exit Sub
        End If

        Dim dv As String
        Dim pv As String
        pv = Split(cboPanPVPV.Text, " - ")(0)

        For i As Integer = 0 To rs_IMVENINF.Tables("RESULT").Rows.Count - 1
            If pv = rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_venno") Then
                MsgBox("Production Vendor " & cboPanPVPV.Text & " already exist!")
                Exit Sub
            End If
        Next

        Dim rowcount As Integer
        rowcount = rs_IMVENINF.Tables("RESULT").Rows.Count

        rs_IMVENINF.Tables("RESULT").Rows.Add()
        rs_IMVENINF.Tables("RESULT").Rows(rowcount).Item("ivi_cocde") = ""
        rs_IMVENINF.Tables("RESULT").Rows(rowcount).Item("ivi_itmno") = txtItmNo.Text
        rs_IMVENINF.Tables("RESULT").Rows(rowcount).Item("ivi_venitm") = txtPanPVVenItm.Text
        rs_IMVENINF.Tables("RESULT").Rows(rowcount).Item("ivi_venno") = Split(cboPanPVPV.Text, " - ")(0)
        rs_IMVENINF.Tables("RESULT").Rows(rowcount).Item("vbi_vensna") = Split(cboPanPVPV.Text, " - ")(1)
        rs_IMVENINF.Tables("RESULT").Rows(rowcount).Item("ivi_subcde") = ""
        If rowcount = 0 Then
            rs_IMVENINF.Tables("RESULT").Rows(rowcount).Item("ivi_def") = "Y"
        Else
            rs_IMVENINF.Tables("RESULT").Rows(rowcount).Item("ivi_def") = "N"
        End If
        rs_IMVENINF.Tables("RESULT").Rows(rowcount).Item("ivi_creusr") = "~*ADD*~"
        Recordstatus = True

        dv = Split(cboDV.Text, " - ")(0)
        pv = Split(cboPanPVPV.Text, " - ")(0)

        Dim pack_um As String
        Dim pack_ftr As String
        Dim pack_inr As String
        Dim pack_mtr As String
        Dim pack_cft As String

        Dim dr_IMPRCINF() As DataRow = rs_IMPRCINF.Tables("RESULT").Select("imu_prdven = '" & dv & "' and imu_cocde <> 'Y'")
        Dim dr_IMPCKINF() As DataRow = rs_IMPCKINF.Tables("RESULT").Select("ipi_cocde <> 'Y'")
        If dr_IMPRCINF.Length > 0 Then
            For i As Integer = 0 To dr_IMPRCINF.Length - 1
                rs_IMPRCINF.Tables("RESULT").Rows.Add()
                rowcount = rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cocde") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_itmno") = dr_IMPRCINF(i)("imu_itmno")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_typ") = dr_IMPRCINF(i)("imu_typ")
                If dv = pv Or Split(cboItmTyp.Text, " - ")(0) = "BOM" Then
                    rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ventyp") = "D"
                Else
                    rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ventyp") = "P"
                End If
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_venno") = dv
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_prdven") = pv
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_packing") = dr_IMPRCINF(i)("imu_packing")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_pckunt") = dr_IMPRCINF(i)("imu_pckunt")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_conftr") = dr_IMPRCINF(i)("imu_conftr")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_inrqty") = dr_IMPRCINF(i)("imu_inrqty")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_mtrqty") = dr_IMPRCINF(i)("imu_mtrqty")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cft") = dr_IMPRCINF(i)("imu_cft")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cus1no") = dr_IMPRCINF(i)("imu_cus1no")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cus2no") = dr_IMPRCINF(i)("imu_cus2no")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprctrm") = dr_IMPRCINF(i)("imu_ftyprctrm")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_hkprctrm") = dr_IMPRCINF(i)("imu_hkprctrm")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_trantrm") = dr_IMPRCINF(i)("imu_trantrm")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_effdat") = dr_IMPRCINF(i)("imu_effdat") 'Today.ToString
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_expdat") = dr_IMPRCINF(i)("imu_expdat") 'Today.AddYears(1).ToString
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_status") = dr_IMPRCINF(i)("imu_status") '"ACT"
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_curcde") = dr_IMPRCINF(i)("imu_curcde")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstA") = dr_IMPRCINF(i)("imu_ftycstA")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstB") = dr_IMPRCINF(i)("imu_ftycstB")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstC") = dr_IMPRCINF(i)("imu_ftycstC")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstD") = dr_IMPRCINF(i)("imu_ftycstD")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstE") = dr_IMPRCINF(i)("imu_ftycstE")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstTran") = dr_IMPRCINF(i)("imu_ftycstTran")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstPack") = dr_IMPRCINF(i)("imu_ftycstPack")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycst") = dr_IMPRCINF(i)("imu_ftycst")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlA") = dr_IMPRCINF(i)("imu_fmlA")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlB") = dr_IMPRCINF(i)("imu_fmlB")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlC") = dr_IMPRCINF(i)("imu_fmlC")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlD") = dr_IMPRCINF(i)("imu_fmlD")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlE") = dr_IMPRCINF(i)("imu_fmlE")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlTran") = dr_IMPRCINF(i)("imu_fmlTran")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlPack") = dr_IMPRCINF(i)("imu_fmlPack")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fml") = dr_IMPRCINF(i)("imu_fml")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpA") = dr_IMPRCINF(i)("imu_chgfpA")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpB") = dr_IMPRCINF(i)("imu_chgfpB")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpC") = dr_IMPRCINF(i)("imu_chgfpC")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpD") = dr_IMPRCINF(i)("imu_chgfpD")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpE") = dr_IMPRCINF(i)("imu_chgfpE")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpTran") = dr_IMPRCINF(i)("imu_chgfpTran")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpPack") = dr_IMPRCINF(i)("imu_chgfpPack")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfp") = dr_IMPRCINF(i)("imu_chgfp")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcA") = dr_IMPRCINF(i)("imu_ftyprcA")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcB") = dr_IMPRCINF(i)("imu_ftyprcB")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcC") = dr_IMPRCINF(i)("imu_ftyprcC")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcD") = dr_IMPRCINF(i)("imu_ftyprcD")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcE") = dr_IMPRCINF(i)("imu_ftyprcE")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcTran") = dr_IMPRCINF(i)("imu_ftyprcTran")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcPack") = dr_IMPRCINF(i)("imu_ftyprcPack")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprc") = dr_IMPRCINF(i)("imu_ftyprc")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_bomcst") = dr_IMPRCINF(i)("imu_bomcst")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ttlcst") = dr_IMPRCINF(i)("imu_ttlcst")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_hkadjper") = dr_IMPRCINF(i)("imu_hkadjper")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_negcst") = dr_IMPRCINF(i)("imu_negcst")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_negprc") = dr_IMPRCINF(i)("imu_negprc")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlopt") = dr_IMPRCINF(i)("imu_fmlopt")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_bcurcde") = dr_IMPRCINF(i)("imu_bcurcde")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_itmprc") = dr_IMPRCINF(i)("imu_itmprc")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_bomprc") = dr_IMPRCINF(i)("imu_bomprc")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_basprc") = dr_IMPRCINF(i)("imu_basprc")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_sysgen") = "N"
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_estprcflg") = dr_IMPRCINF(i)("imu_estprcflg")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_estprcref") = dr_IMPRCINF(i)("imu_estprcref")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ttlcst") = dr_IMPRCINF(i)("imu_ttlcst")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_period") = dr_IMPRCINF(i)("imu_period")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cstchgdat") = Today.ToString
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_pckunt_org") = dr_IMPRCINF(i)("imu_pckunt_org")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_conftr_org") = dr_IMPRCINF(i)("imu_conftr_org")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_inrqty_org") = dr_IMPRCINF(i)("imu_inrqty_org")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_mtrqty_org") = dr_IMPRCINF(i)("imu_mtrqty_org")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cft_org") = dr_IMPRCINF(i)("imu_cft_org")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cus1no_org") = dr_IMPRCINF(i)("imu_cus1no_org")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cus2no_org") = dr_IMPRCINF(i)("imu_cus2no_org")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprctrm_org") = dr_IMPRCINF(i)("imu_ftyprctrm_org")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_hkprctrm_org") = dr_IMPRCINF(i)("imu_hkprctrm_org")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_trantrm_org") = dr_IMPRCINF(i)("imu_trantrm_org")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_creusr") = "~*ADD*~"
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_updusr") = "~*ADD*~"
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_credat") = Today.Now.ToString
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_upddat") = Today.Now.ToString

                Recordstatus = True
            Next
        Else
            For i As Integer = 0 To dr_IMPCKINF.Length - 1
                rs_IMPRCINF.Tables("RESULT").Rows.Add()
                rowcount = rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cocde") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_itmno") = txtItmNo.Text
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_typ") = Split(cboItmTyp.Text, " - ")(0)
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_venno") = dv
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_prdven") = pv
                If dv = pv Or Split(cboItmTyp.Text, " - ")(0) = "BOM" Then
                    rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ventyp") = "D"
                Else
                    rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ventyp") = "P"
                End If

                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_pckunt") = dr_IMPCKINF(i)("ipi_pckunt")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_conftr") = dr_IMPCKINF(i)("ipi_conftr")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_inrqty") = dr_IMPCKINF(i)("ipi_inrqty")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_mtrqty") = dr_IMPCKINF(i)("ipi_mtrqty")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cft") = dr_IMPCKINF(i)("ipi_cft")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_packing") = dr_IMPCKINF(i)("ipi_pckunt") & " / " & dr_IMPCKINF(i)("ipi_inrqty") & " / " & dr_IMPCKINF(i)("ipi_mtrqty") & " / " & dr_IMPCKINF(i)("ipi_cft")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cus1no") = dr_IMPCKINF(i)("ipi_cus1no")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cus2no") = dr_IMPCKINF(i)("ipi_cus2no")
                If Split(cboItmVenTyp.Text, " - ")(0) = "EXT" Then
                    rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprctrm") = "FOR HK"
                Else
                    rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprctrm") = "FOB HK"
                End If
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_hkprctrm") = "FOB HK"
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_trantrm") = "FCL"
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_effdat") = Today.ToString
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_expdat") = Today.AddYears(1).ToString
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_status") = "INA"
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_curcde") = getdefaultCurrency(dv)
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycst") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstA") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstB") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstC") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstD") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstE") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstTran") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstPack") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fml") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlA") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlB") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlC") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlD") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlE") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlTran") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlPack") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfp") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpA") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpB") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpC") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpD") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpE") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpTran") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpPack") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprc") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcA") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcB") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcC") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcD") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcE") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcTran") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcPack") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_bomcst") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ttlcst") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_hkadjper") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_negcst") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_negprc") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_estprcflg") = "N"
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_estprcref") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_sysgen") = "N"

                Dim fml_vencde As String
                Dim fml_ventyp As String
                Dim fml_cus1no As String
                Dim fml_cus2no As String
                Dim fml_catlvl4 As String
                Dim fml_imtyp As String
                fml_vencde = pv
                fml_ventyp = Split(cboItmVenTyp.Text, " - ")(0)
                fml_cus1no = ""
                fml_cus2no = ""
                fml_catlvl4 = Split(cboCategory.Text, " - ")(0)
                If rbIMTyp_PCIM.Checked = True Then
                    fml_imtyp = "PCIM"
                Else
                    fml_imtyp = "IM"
                End If
                getformula(fml_vencde, fml_ventyp, fml_cus1no, fml_cus2no, fml_catlvl4, fml_imtyp)
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlopt") = tmp_calfml_hk.Text

                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_bcurcde") = "USD"
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_itmprc") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_bomprc") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_basprc") = 0.0
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_period") = ""
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cstchgdat") = Today.ToString
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_pckunt_org") = dr_IMPCKINF(i)("ipi_pckunt")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_conftr_org") = dr_IMPCKINF(i)("ipi_conftr")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_inrqty_org") = dr_IMPCKINF(i)("ipi_inrqty")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_mtrqty_org") = dr_IMPCKINF(i)("ipi_mtrqty")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cft_org") = dr_IMPCKINF(i)("ipi_cft")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cus1no_org") = dr_IMPCKINF(i)("ipi_cus1no")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cus2no_org") = dr_IMPCKINF(i)("ipi_cus2no")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprctrm_org") = rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprctrm")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_hkprctrm_org") = rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_hkprctrm")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_trantrm_org") = rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_trantrm")
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_creusr") = "~*ADD*~"
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_updusr") = "~*ADD*~"
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_credat") = Today.Now.ToString
                rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_upddat") = Today.Now.ToString
            Next
        End If

        PanelPV.Visible = False
        release_TabControl()
        format_TabControl("IM", Split(cboItmTyp.Text, " - ")(0))

    End Sub

    Private Sub cmdPanPVCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanPVCancel.Click
        PanelPV.Visible = False
        release_TabControl()
        format_TabControl("IM", Split(cboItmTyp.Text, " - ")(0))
    End Sub

    Private Sub txtDsgItmNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDsgItmNo.TextChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If txtDsgItmNo.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim dsgitmno As String
                    dsgitmno = txtDsgItmNo.Text
                    If dsgitmno <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_dsgno") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboMaterial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMaterial.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboMaterial.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim material As String
                    material = Split(cboMaterial.Text, " - ")(0)
                    If material <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_material") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboItmNature_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItmNature.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboItmNature.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim itmnat As String
                    itmnat = Split(cboItmNature.Text, " - ")(0)
                    If itmnat <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmnat") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboPrdSizeTyp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrdSizeTyp.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboPrdSizeTyp.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim prdsizetyp As String
                    prdsizetyp = Split(cboPrdSizeTyp.Text, " - ")(0)
                    If prdsizetyp <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_prdsizeTyp") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboPrdSizeUnit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrdSizeUnit.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboPrdSizeUnit.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim prdsizeunit As String
                    prdsizeunit = Split(cboPrdSizeUnit.Text, " - ")(0)
                    If prdsizeunit <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_prdsizeUnt") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtPrdSizeValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrdSizeValue.TextChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If txtPrdSizeValue.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim prdsizevalue As String
                    prdsizevalue = txtPrdSizeValue.Text
                    If prdsizevalue <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_prdsizeVal") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboPrdGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrdGroup.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboPrdGroup.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim prdgrp As String
                    prdgrp = Split(cboPrdGroup.Text, " - ")(0)
                    If prdgrp <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_prdgrp") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboPrdIcon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrdIcon.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboPrdIcon.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim prdicon As String
                    prdicon = Split(cboPrdIcon.Text, " - ")(0)
                    If prdicon <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_prdicon") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboSeason_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSeason.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboSeason.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim season As String
                    season = Split(cboSeason.Text, " - ")(0)
                    If season <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_season") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboDesigner_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDesigner.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboDesigner.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim dsgner As String
                    dsgner = Split(cboDesigner.Text, " - ")(0)
                    If dsgner <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_designer") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboDevTeam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDevTeam.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboDevTeam.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim devteam As String
                    devteam = Split(cboDevTeam.Text, " - ")(0)
                    If devteam <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_devteam") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboPrdTyp.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim t As String
                    t = Split(cboType.Text, " - ")(0)
                    If t <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_type") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYear.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboYear.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim y As String
                    y = Split(cboYear.Text, " - ")(0)
                    If y <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_year") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboPrdLne_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPrdLne.KeyUp
        auto_search_combo(cboPrdLne, e.KeyCode)
    End Sub

    Private Sub cboPrdLne_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrdLne.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboPrdLne.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim prdlne As String
                    prdlne = Split(cboPrdLne.Text, " - ")(0)
                    If prdlne <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_lnecde") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboCategory_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCategory.KeyUp
        auto_search_combo(cboCategory, e.KeyCode)
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategory.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboCategory.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim cat As String
                    cat = Split(cboCategory.Text, " - ")(0)
                    If cat <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_catlvl4") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgCostPrice_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgCostPrice.RowHeaderMouseDoubleClick
        If rbPriceView_P.Checked = True Then
            Exit Sub
        End If

        If Split(cboItmTyp.Text, " - ")(0) = "BOM" Then
            Exit Sub
        End If

        'If PanelCostPrice.Visible = True Then
        '    Exit Sub
        'End If

        freeze_TabControl(4)
        PanelCostPrice.Visible = True
        If mode = "UPDATE" Or mode = "ADD" Then
            Dim curvalue As String
            curvalue = dgCostPrice.Item(dgCostPrice_imu_cocde, dgCostPrice.CurrentCell.RowIndex).Value

            If curvalue = "Y" Then
                Call display_PanelCostPrice("COSTPRICE_READ")
            Else
                Call display_PanelCostPrice("COSTPRICE_UPDATE")
            End If

        Else
            Call display_PanelCostPrice("COSTPRICE_READ")
        End If
    End Sub

    Private Sub display_PanelCostPrice(ByVal m As String)
        If rs_IMPRCINF.Tables.Count = 0 Then
            Exit Sub
        End If


        txtPanCPFtyCst.Visible = True
        txtPanCPFtyCstA.Visible = True
        txtPanCPFtyCstB.Visible = True
        txtPanCPFtyCstC.Visible = True
        txtPanCPFtyCstD.Visible = True
        txtPanCPFtyCstE.Visible = True
        txtPanCPFtyCstTran.Visible = True
        txtPanCPFtyCstPack.Visible = True

        txtPanCPMU.Visible = True
        txtPanCPMUA.Visible = False
        txtPanCPMUB.Visible = False
        txtPanCPMUC.Visible = False
        txtPanCPMUD.Visible = False
        txtPanCPMUE.Visible = False
        txtPanCPMUTran.Visible = False
        txtPanCPMUPack.Visible = False

        txtPanCPFtyPrc.Visible = True
        txtPanCPFtyPrcA.Visible = False
        txtPanCPFtyPrcB.Visible = False
        txtPanCPFtyPrcC.Visible = False
        txtPanCPFtyPrcD.Visible = False
        txtPanCPFtyPrcE.Visible = False
        txtPanCPFtyPrcTran.Visible = False
        txtPanCPFtyPrcPack.Visible = False

        txtPanCPBOMCst.Visible = True
        txtPanCPTtlCst.Visible = True
        txtPanCPAdjPer.Visible = False
        txtPanCPNegCst.Visible = False
        txtPanCPNegPrc.Visible = True

        cboPanCPFmlHK.Visible = True
        txtPanCPItmPrc.Visible = True
        txtPanCPBOMPrc.Visible = True
        txtPanCPBasicPrc.Visible = True

        txtPanCPEffDate.Visible = True
        txtPanCPExpDate.Visible = True

        If m = "COSTPRICE_READ" Then
            cmdPanCPInsert.Enabled = False
            cmdPanCPUpdate.Enabled = False
            cmdPanCPCancel.Enabled = True

            txtPanCPFtyCst.Enabled = False
            txtPanCPFtyCstA.Enabled = False
            txtPanCPFtyCstB.Enabled = False
            txtPanCPFtyCstC.Enabled = False
            txtPanCPFtyCstD.Enabled = False
            txtPanCPFtyCstE.Enabled = False
            txtPanCPFtyCstTran.Enabled = False
            txtPanCPFtyCstPack.Enabled = False

            txtPanCPMU.Enabled = False
            txtPanCPMUA.Enabled = False
            txtPanCPMUB.Enabled = False
            txtPanCPMUC.Enabled = False
            txtPanCPMUD.Enabled = False
            txtPanCPMUE.Enabled = False
            txtPanCPMUTran.Enabled = False
            txtPanCPMUPack.Enabled = False

            txtPanCPFtyPrc.Enabled = False
            txtPanCPFtyPrcA.Enabled = False
            txtPanCPFtyPrcB.Enabled = False
            txtPanCPFtyPrcC.Enabled = False
            txtPanCPFtyPrcD.Enabled = False
            txtPanCPFtyPrcE.Enabled = False
            txtPanCPFtyPrcTran.Enabled = False
            txtPanCPFtyPrcPack.Enabled = False

            txtPanCPBOMCst.Enabled = False
            txtPanCPTtlCst.Enabled = False
            'txtPanCPAdjPer.Enabled = False
            'txtPanCPNegCst.Enabled = False
            txtPanCPNegPrc.Enabled = False

            cboPanCPFmlHK.Enabled = False
            txtPanCPItmPrc.Enabled = False
            txtPanCPBOMPrc.Enabled = False
            txtPanCPBasicPrc.Enabled = False

            txtPanCPEffDate.Enabled = False
            txtPanCPExpDate.Enabled = False
        ElseIf m = "COSTPRICE_UPDATE" Then
            cmdPanCPInsert.Enabled = True
            cmdPanCPUpdate.Enabled = True
            cmdPanCPCancel.Enabled = True

            txtPanCPFtyCst.Enabled = True
            txtPanCPFtyCstA.Enabled = True
            txtPanCPFtyCstB.Enabled = True
            txtPanCPFtyCstC.Enabled = True
            txtPanCPFtyCstD.Enabled = True
            txtPanCPFtyCstE.Enabled = True
            txtPanCPFtyCstTran.Enabled = True
            txtPanCPFtyCstPack.Enabled = True

            txtPanCPMU.Enabled = False
            txtPanCPMUA.Enabled = False
            txtPanCPMUB.Enabled = False
            txtPanCPMUC.Enabled = False
            txtPanCPMUD.Enabled = False
            txtPanCPMUE.Enabled = False
            txtPanCPMUTran.Enabled = False
            txtPanCPMUPack.Enabled = False

            txtPanCPFtyPrc.Enabled = True
            txtPanCPFtyPrcA.Enabled = True
            txtPanCPFtyPrcB.Enabled = True
            txtPanCPFtyPrcC.Enabled = True
            txtPanCPFtyPrcD.Enabled = True
            txtPanCPFtyPrcE.Enabled = True
            txtPanCPFtyPrcTran.Enabled = True
            txtPanCPFtyPrcPack.Enabled = True

            txtPanCPBOMCst.Enabled = False
            txtPanCPTtlCst.Enabled = False
            'txtPanCPAdjPer.Enabled = False
            'txtPanCPNegCst.Enabled = True
            txtPanCPNegPrc.Enabled = True

            cboPanCPFmlHK.Enabled = True
            txtPanCPItmPrc.Enabled = False
            txtPanCPBOMPrc.Enabled = False
            txtPanCPBasicPrc.Enabled = False

            txtPanCPEffDate.Enabled = True
            txtPanCPExpDate.Enabled = True
        ElseIf m = "COSTPRICE_INSERT" Then
            cmdPanCPInsert.Enabled = False
            cmdPanCPUpdate.Enabled = True
            cmdPanCPCancel.Enabled = True
        End If

        If m = "COSTPRICE_READ" Or m = "COSTPRICE_UPDATE" Then

            Dim i As Integer
            Dim displayrow As Integer
            displayrow = -1

            Dim display_pv As String
            Dim display_pckunt_org As String
            Dim display_inrqty_org As String
            Dim display_mtrqty_org As String
            Dim display_cus1no_org As String
            Dim display_cus2no_org As String
            Dim display_ftyprctrm_org As String
            Dim display_hkprctrm_org As String
            Dim display_trantrm_org As String
            display_pv = dgCostPrice.Item(dgCostPrice_imu_prdven, dgCostPrice.CurrentCell.RowIndex).Value
            display_pckunt_org = dgCostPrice.Item(dgCostPrice_imu_pckunt_org, dgCostPrice.CurrentCell.RowIndex).Value
            display_inrqty_org = dgCostPrice.Item(dgCostPrice_imu_inrqty_org, dgCostPrice.CurrentCell.RowIndex).Value
            display_mtrqty_org = dgCostPrice.Item(dgCostPrice_imu_mtrqty_org, dgCostPrice.CurrentCell.RowIndex).Value
            display_cus1no_org = dgCostPrice.Item(dgCostPrice_imu_cus1no_org, dgCostPrice.CurrentCell.RowIndex).Value
            display_cus2no_org = dgCostPrice.Item(dgCostPrice_imu_cus2no_org, dgCostPrice.CurrentCell.RowIndex).Value
            display_ftyprctrm_org = dgCostPrice.Item(dgCostPrice_imu_ftyprctrm_org, dgCostPrice.CurrentCell.RowIndex).Value
            display_hkprctrm_org = dgCostPrice.Item(dgCostPrice_imu_hkprctrm_org, dgCostPrice.CurrentCell.RowIndex).Value
            display_trantrm_org = dgCostPrice.Item(dgCostPrice_imu_trantrm_org, dgCostPrice.CurrentCell.RowIndex).Value

            For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
                If rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_prdven") = display_pv And _
                    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_pckunt_org") = display_pckunt_org And _
                    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_inrqty_org") = display_inrqty_org And _
                    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_mtrqty_org") = display_mtrqty_org And _
                    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cus1no_org") = display_cus1no_org And _
                    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cus2no_org") = display_cus2no_org And _
                    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprctrm_org") = display_ftyprctrm_org And _
                    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_hkprctrm_org") = display_hkprctrm_org And _
                    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_trantrm_org") = display_trantrm_org Then
                    displayrow = i
                End If
            Next i

            lblOrgCus1No.Text = display_cus1no_org
            lblOrgCus2No.Text = display_cus2no_org
            lblOrgFtyTerm.Text = display_ftyprctrm_org
            lblOrgHKTerm.Text = display_hkprctrm_org
            lblOrgTranTerm.Text = display_trantrm_org

            lblOrgConftr.Text = rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_conftr")

            lblPanCPBCurcde.Text = "(" & rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_bcurcde") & ")"
            lblPanCPBCurcde1.Text = "(" & rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_bcurcde") & ")"
            lblPanCPBCurcde2.Text = "(" & rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_bcurcde") & ")"

            lblPanCPFCurcde.Text = "(" & rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_curcde") & ")"
            lblPanCPFCurcde1.Text = "(" & rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_curcde") & ")"
            lblPanCPFCurcde2.Text = "(" & rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_curcde") & ")"
            lblPanCPFCurcde3.Text = "(" & rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_curcde") & ")"
            lblPanCPFCurcde4.Text = "(" & rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_curcde") & ")"

            Dim strcft As String
            strcft = rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_cft")
            lblPanCPPacking.Text = rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_venno") & " / " & _
                                    rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_prdven") & " / " & _
                                    rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_pckunt") & " / " & _
                                    rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_inrqty") & " / " & _
                                    rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_mtrqty") & " / " & _
                                    Replace(Str(strcft), " .", "0.")


            display_combo(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_cus1no"), cboPanCPCus1no)

            If cboPanCPCus1no.Text <> "" Then
                format_cboPanCus2no(Split(cboPanCPCus1no.Text, " - ")(0))
            End If

            display_combo(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_cus2no"), cboPanCPCus2no)
            cboPanCPPrcTrmHK.Text = rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_hkprctrm")
            cboPanCPPrcTrmFty.Text = rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftyprctrm")
            cboPanCPTranTrm.Text = rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_trantrm")

            'txtPanCPFtyCst.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftycst"), 2)
            'txtPanCPFtyCstA.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftycstA"), 2)
            'txtPanCPFtyCstB.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftycstB"), 2)
            'txtPanCPFtyCstC.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftycstC"), 2)
            'txtPanCPFtyCstD.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftycstD"), 2)
            'txtPanCPFtyCstTran.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftycstTran"), 2)
            'txtPanCPFtyCstPack.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftycstPack"), 2)
            txtPanCPFtyCst.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftycst"), 4)
            txtPanCPFtyCstA.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftycstA"), 4)
            txtPanCPFtyCstB.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftycstB"), 4)
            txtPanCPFtyCstC.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftycstC"), 4)
            txtPanCPFtyCstD.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftycstD"), 4)
            txtPanCPFtyCstE.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftycstE"), 4)
            txtPanCPFtyCstTran.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftycstTran"), 4)
            txtPanCPFtyCstPack.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftycstPack"), 4)

            txtPanCPMU.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_chgfp"), 2)
            txtPanCPMUA.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_chgfpA"), 2)
            txtPanCPMUB.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_chgfpB"), 2)
            txtPanCPMUC.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_chgfpC"), 2)
            txtPanCPMUD.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_chgfpD"), 2)
            txtPanCPMUE.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_chgfpE"), 2)
            txtPanCPMUTran.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_chgfpTran"), 2)
            txtPanCPMUPack.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_chgfpPack"), 2)

            'txtPanCPFtyPrc.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftyprc"), 2)
            txtPanCPFtyPrc.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftyprc"), 4)
            txtPanCPFtyPrcA.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftyprcA"), 4)
            txtPanCPFtyPrcB.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftyprcB"), 4)
            txtPanCPFtyPrcC.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftyprcC"), 4)
            txtPanCPFtyPrcD.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftyprcD"), 4)
            txtPanCPFtyPrcE.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftyprcE"), 4)
            txtPanCPFtyPrcTran.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftyprcTran"), 4)
            txtPanCPFtyPrcPack.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ftyprcPack"), 4)

            'txtPanCPBOMCst.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_bomcst"), 2)
            'txtPanCPTtlCst.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ttlcst"), 2)
            txtPanCPBOMCst.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_bomcst"), 4)
            txtPanCPTtlCst.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_ttlcst"), 4)
            txtPanCPAdjPer.Text = rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_hkadjper")
            txtPanCPNegCst.Text = rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_negcst")
            'txtPanCPNegPrc.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_negprc"), 2)
            txtPanCPNegPrc.Text = Decimal.Round(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_negprc"), 4)

            cboPanCPFmlHK.Items.Clear()
            cboPanCPFmlHK.Text = rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_fmlopt")
            Dim fml_vencde As String
            Dim fml_ventyp As String
            Dim fml_cus1no As String
            Dim fml_cus2no As String
            Dim fml_catlvl4 As String
            Dim fml_imtyp As String

            fml_vencde = Split(lblPanCPPacking.Text, " / ")(1)
            fml_ventyp = Split(cboItmVenTyp.Text, " - ")(0)
            fml_cus1no = Split(cboPanCPCus1no.Text, " - ")(0)
            fml_cus2no = Split(cboPanCPCus2no.Text, " - ")(0)
            fml_catlvl4 = Split(cboCategory.Text, " - ")(0)
            If rbIMTyp_PCIM.Checked = True Then
                fml_imtyp = "PCIM"
            Else
                fml_imtyp = "IM"
            End If
            getformula(fml_vencde, fml_ventyp, fml_cus1no, fml_cus2no, fml_catlvl4, fml_imtyp)

            For i = 0 To tmp_calfml_hk.Items.Count - 1
                cboPanCPFmlHK.Items.Add(tmp_calfml_hk.Items(i).ToString)
            Next

            If cboPanCPFmlHK.Text = "" Then
                cboPanCPFmlHK.Text = tmp_calfml_hk.Text
            End If

            txtPanCPItmPrc.Text = rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_itmprc")
            txtPanCPBOMPrc.Text = rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_bomprc")
            txtPanCPBasicPrc.Text = rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_basprc")

            cboPanCPStatus.Text = rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_status")
            Dim tempM As String = "0" & CDate(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_effdat")).Month.ToString
            Dim tempD As String = "0" & CDate(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_effdat")).Day.ToString
            txtPanCPEffDate.Text = tempM.Substring(tempM.Length - 2, 2) & "/" & tempD.Substring(tempD.Length - 2, 2) & "/" & CDate(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_effdat")).Year.ToString
            tempM = "0" & CDate(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_expdat")).Month.ToString
            tempD = "0" & CDate(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_expdat")).Day.ToString
            txtPanCPExpDate.Text = tempM.Substring(tempM.Length - 2, 2) & "/" & tempD.Substring(tempD.Length - 2, 2) & "/" & CDate(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_expdat")).Year.ToString

            cboPanCPEstPrcFlg.Items.Clear()
            cboPanCPEstPrcFlg.Items.Add("N")
            cboPanCPEstPrcFlg.Items.Add("Y")

            display_combo(rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_estprcflg").ToString, cboPanCPEstPrcFlg)
            txtPanCPEstPrcRef.Text = rs_IMPRCINF.Tables("RESULT").Rows(displayrow).Item("imu_estprcref").ToString

            If Split(cboItmVenTyp.Text, " - ")(0) = "EXT" Then
                cboPanCPEstPrcFlg.Enabled = True
                txtPanCPEstPrcRef.Enabled = True
            Else
                cboPanCPEstPrcFlg.Enabled = False
                txtPanCPEstPrcRef.Enabled = False
            End If
        ElseIf m = "COSTPRICE_INSERT" Then
        End If

        cboPanCPCus1no.Select()
    End Sub

    Private Sub cmdPanCPCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanCPCancel.Click
        PanelCostPrice.Visible = False
        release_TabControl()
        format_TabControl("IM", Split(cboItmTyp.Text, " - ")(0))

    End Sub

    Private Sub cmdPanCPInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanCPInsert.Click
        If check_insert_CostPrice() = False Then
            Exit Sub
        End If

        Dim ins_dv As String
        Dim ins_pv As String
        Dim ins_pckunt As String
        Dim ins_inrqty As String
        Dim ins_mtrqty As String
        Dim ins_cft As String

        Dim packstr As String
        packstr = lblPanCPPacking.Text

        ins_dv = Split(packstr, " / ")(0)
        ins_pv = Split(packstr, " / ")(1)
        ins_pckunt = Split(packstr, " / ")(2)
        ins_inrqty = Split(packstr, " / ")(3)
        ins_mtrqty = Split(packstr, " / ")(4)
        ins_cft = Split(packstr, " / ")(5)

        Dim rowcount As Integer

        rs_IMPRCINF.Tables("RESULT").Rows.Add()
        rowcount = rs_IMPRCINF.Tables("RESULT").Rows.Count - 1

        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cocde") = ""
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_itmno") = txtItmNo.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_typ") = Split(cboItmTyp.Text, " - ")(0)

        If ins_dv = ins_pv Then
            rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ventyp") = "D"
        Else
            rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ventyp") = "P"
        End If

        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_venno") = ins_dv
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_prdven") = ins_pv

        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_pckunt") = ins_pckunt
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_conftr") = lblOrgConftr.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_inrqty") = ins_inrqty
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_mtrqty") = ins_mtrqty
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cft") = ins_cft

        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_packing") = ins_pckunt & " / " & ins_inrqty & " / " & ins_mtrqty & " / " & ins_cft

        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cus1no") = Split(cboPanCPCus1no.Text, " - ")(0)
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cus2no") = Split(cboPanCPCus2no.Text, " - ")(0)
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprctrm") = cboPanCPPrcTrmFty.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_hkprctrm") = cboPanCPPrcTrmHK.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_trantrm") = cboPanCPTranTrm.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_effdat") = txtPanCPEffDate.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_expdat") = txtPanCPExpDate.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_status") = cboPanCPStatus.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_curcde") = lblPanCPFCurcde.Text.Substring(1, Len(lblPanCPFCurcde.Text) - 2)
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycst") = txtPanCPFtyCst.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstA") = txtPanCPFtyCstA.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstB") = txtPanCPFtyCstB.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstC") = txtPanCPFtyCstC.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstD") = txtPanCPFtyCstD.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstE") = txtPanCPFtyCstE.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstTran") = txtPanCPFtyCstTran.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftycstPack") = txtPanCPFtyCstPack.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fml") = ""
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlA") = ""
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlB") = ""
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlC") = ""
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlD") = ""
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlE") = ""
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlTran") = ""
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlPack") = ""
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfp") = txtPanCPMU.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpA") = txtPanCPMUA.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpB") = txtPanCPMUB.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpC") = txtPanCPMUC.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpD") = txtPanCPMUD.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpE") = txtPanCPMUE.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpTran") = txtPanCPMUTran.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_chgfpPack") = txtPanCPMUPack.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprc") = txtPanCPFtyPrc.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcA") = txtPanCPFtyPrcA.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcB") = txtPanCPFtyPrcB.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcC") = txtPanCPFtyPrcC.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcD") = txtPanCPFtyPrcD.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcE") = txtPanCPFtyPrcE.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcTran") = txtPanCPFtyPrcTran.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprcPack") = txtPanCPFtyPrcPack.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_bomcst") = txtPanCPBOMCst.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ttlcst") = txtPanCPTtlCst.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_hkadjper") = 0.0
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_negcst") = 0.0
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_negprc") = txtPanCPNegPrc.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_fmlopt") = cboPanCPFmlHK.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_bcurcde") = lblPanCPBCurcde.Text.Substring(1, Len(lblPanCPBCurcde.Text) - 2)
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_itmprc") = txtPanCPItmPrc.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_bomprc") = txtPanCPBOMPrc.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_basprc") = txtPanCPBasicPrc.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_period") = ""
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cstchgdat") = Today.ToString

        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_pckunt_org") = ins_pckunt
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_conftr_org") = lblOrgConftr.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_inrqty_org") = ins_inrqty
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_mtrqty_org") = ins_mtrqty
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cft_org") = ins_cft
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cus1no_org") = Split(cboPanCPCus1no.Text, " - ")(0)
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_cus2no_org") = Split(cboPanCPCus2no.Text, " - ")(0)
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_ftyprctrm_org") = cboPanCPPrcTrmFty.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_hkprctrm_org") = cboPanCPPrcTrmHK.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_trantrm_org") = cboPanCPTranTrm.Text

        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_estprcflg") = cboPanCPEstPrcFlg.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_estprcref") = txtPanCPEstPrcRef.Text
        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_sysgen") = "N"

        rs_IMPRCINF.Tables("RESULT").Rows(rowcount).Item("imu_creusr") = "~*ADD*~"
        Recordstatus = True

        If Split(cboItmVenTyp.Text, " - ")(0) = "INT" Then
            ' Update all prices with same packing / customer
            Dim dr() As DataRow = rs_IMPRCINF.Tables("RESULT").Select("imu_pckunt = '" & ins_pckunt & "' and " & _
                                                                      "imu_inrqty = '" & ins_inrqty & "' and " & _
                                                                      "imu_mtrqty = '" & ins_mtrqty & "' and " & _
                                                                      "imu_cus1no = '" & Split(cboPanCPCus1no.Text, " - ")(0) & "' and " & _
                                                                      "imu_cus2no = '" & Split(cboPanCPCus2no.Text, " - ")(0) & "' and " & _
                                                                      "imu_hkprctrm = '" & cboPanCPPrcTrmHK.Text & "' and " & _
                                                                      "imu_ftyprctrm = '" & cboPanCPPrcTrmFty.Text & "' and " & _
                                                                      "imu_trantrm = '" & cboPanCPTranTrm.Text & "'")
            If dr.Length > 0 Then
                For i As Integer = 0 To dr.Length - 1
                    dr(i)("imu_status") = cboPanCPStatus.Text
                    dr(i)("imu_effdat") = txtPanCPEffDate.Text
                    dr(i)("imu_expdat") = txtPanCPExpDate.Text
                    dr(i)("imu_curcde") = lblPanCPFCurcde.Text.Substring(1, Len(lblPanCPFCurcde.Text) - 2)
                    dr(i)("imu_ftycst") = txtPanCPFtyCst.Text
                    dr(i)("imu_ftycstA") = txtPanCPFtyCstA.Text
                    dr(i)("imu_ftycstB") = txtPanCPFtyCstB.Text
                    dr(i)("imu_ftycstC") = txtPanCPFtyCstC.Text
                    dr(i)("imu_ftycstD") = txtPanCPFtyCstD.Text
                    dr(i)("imu_ftycstE") = txtPanCPFtyCstE.Text
                    dr(i)("imu_ftycstTran") = txtPanCPFtyCstTran.Text
                    dr(i)("imu_ftycstPack") = txtPanCPFtyCstPack.Text
                    dr(i)("imu_fml") = ""
                    dr(i)("imu_fmlA") = ""
                    dr(i)("imu_fmlB") = ""
                    dr(i)("imu_fmlC") = ""
                    dr(i)("imu_fmlD") = ""
                    dr(i)("imu_fmlE") = ""
                    dr(i)("imu_fmlTran") = ""
                    dr(i)("imu_fmlPack") = ""
                    dr(i)("imu_chgfp") = txtPanCPMU.Text
                    dr(i)("imu_chgfpA") = txtPanCPMUA.Text
                    dr(i)("imu_chgfpB") = txtPanCPMUB.Text
                    dr(i)("imu_chgfpC") = txtPanCPMUC.Text
                    dr(i)("imu_chgfpD") = txtPanCPMUD.Text
                    dr(i)("imu_chgfpE") = txtPanCPMUE.Text
                    dr(i)("imu_chgfpTran") = txtPanCPMUTran.Text
                    dr(i)("imu_chgfpPack") = txtPanCPMUPack.Text
                    dr(i)("imu_ftyprc") = txtPanCPFtyPrc.Text
                    dr(i)("imu_ftyprcA") = txtPanCPFtyPrcA.Text
                    dr(i)("imu_ftyprcB") = txtPanCPFtyPrcB.Text
                    dr(i)("imu_ftyprcC") = txtPanCPFtyPrcC.Text
                    dr(i)("imu_ftyprcD") = txtPanCPFtyPrcD.Text
                    dr(i)("imu_ftyprcE") = txtPanCPFtyPrcE.Text
                    dr(i)("imu_ftyprcTran") = txtPanCPFtyPrcTran.Text
                    dr(i)("imu_ftyprcPack") = txtPanCPFtyPrcPack.Text
                    dr(i)("imu_bomcst") = txtPanCPBOMCst.Text
                    dr(i)("imu_ttlcst") = txtPanCPTtlCst.Text
                    dr(i)("imu_hkadjper") = 0.0
                    dr(i)("imu_negcst") = 0.0
                    dr(i)("imu_negprc") = txtPanCPNegPrc.Text
                    dr(i)("imu_fmlopt") = cboPanCPFmlHK.Text
                    dr(i)("imu_bcurcde") = lblPanCPBCurcde.Text.Substring(1, Len(lblPanCPBCurcde.Text) - 2)
                    dr(i)("imu_itmprc") = txtPanCPItmPrc.Text
                    dr(i)("imu_bomprc") = txtPanCPBOMPrc.Text
                    dr(i)("imu_basprc") = txtPanCPBasicPrc.Text
                    dr(i)("imu_period") = ""
                    dr(i)("imu_cstchgdat") = Today.ToString
                Next
            End If
        End If

        PanelCostPrice.Visible = False
        release_TabControl()
        format_TabControl("IM", Split(cboItmTyp.Text, " - ")(0))

    End Sub


    Private Function check_insert_CostPrice() As Boolean
        check_insert_CostPrice = False

        Dim ins_dv As String
        Dim ins_pv As String
        Dim ins_pckunt As String
        Dim ins_inrqty As String
        Dim ins_mtrqty As String
        Dim ins_cus1no As String
        Dim ins_cus2no As String
        Dim ins_ftyprctrm As String
        Dim ins_hkprctrm As String
        Dim ins_trantrm As String

        ins_dv = dgCostPrice.Item(4, dgCostPrice.CurrentCell.RowIndex).Value
        ins_pv = dgCostPrice.Item(5, dgCostPrice.CurrentCell.RowIndex).Value
        Dim packstr As String
        packstr = dgCostPrice.Item(6, dgCostPrice.CurrentCell.RowIndex).Value
        ins_pckunt = Split(packstr, " / ")(0)
        ins_inrqty = Split(packstr, " / ")(1)
        ins_mtrqty = Split(packstr, " / ")(2)
        ins_cus1no = Split(cboPanCPCus1no.Text, " - ")(0)
        ins_cus2no = Split(cboPanCPCus2no.Text, " - ")(0)
        ins_ftyprctrm = cboPanCPPrcTrmFty.Text
        ins_hkprctrm = cboPanCPPrcTrmHK.Text
        ins_trantrm = cboPanCPTranTrm.Text

        'Check Customer Active
        If cboPanCPCus1no.Text.IndexOf("(Inactive)") >= 0 Then
            MsgBox("Customer " & ins_cus1no & " is Inactive!")
            check_insert_CostPrice = False
            Exit Function
        End If
        If cboPanCPCus1no.Text.IndexOf("(Discontinue)") >= 0 Then
            MsgBox("Customer " & ins_cus1no & " is Discontinue!")
            check_insert_CostPrice = False
            Exit Function
        End If

        Dim dr_IMPCKINF() As DataRow = rs_IMPCKINF.Tables("RESULT").Select("ipi_pckunt = '" & ins_pckunt & "' and " & _
                                                                           "ipi_inrqty = '" & ins_inrqty & "' and " & _
                                                                           "ipi_mtrqty = '" & ins_mtrqty & "' and " & _
                                                                           "ipi_cus1no = '" & ins_cus1no & "' and " & _
                                                                           "ipi_cus2no = '" & ins_cus2no & "' and " & _
                                                                           "ipi_cocde <> 'Y'")
        If dr_IMPCKINF.Length = 0 Then
            MsgBox("Packing not found in Item Master: [" & ins_pckunt & " / " & ins_inrqty & " / " & ins_mtrqty & " / " & ins_cus1no & " / " & ins_cus2no & "]", MsgBoxStyle.Information, "IMM00001 - Insert Cost Price")
            Return False
        End If

        Dim i As Integer

        Dim tmp_dv As String
        Dim tmp_pv As String
        Dim tmp_pckunt As String
        Dim tmp_inrqty As String
        Dim tmp_mtrqty As String
        Dim tmp_cus1no As String
        Dim tmp_cus2no As String
        Dim tmp_ftyprctrm As String
        Dim tmp_hkprctrm As String
        Dim tmp_trantrm As String

        Dim tmp_creusr As String

        Dim existcounter As Integer
        existcounter = 0

        For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
            tmp_dv = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_venno")
            tmp_pv = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_prdven")
            tmp_pckunt = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_pckunt")
            tmp_inrqty = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_inrqty")
            tmp_mtrqty = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_mtrqty")
            tmp_cus1no = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cus1no")
            tmp_cus2no = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cus2no")
            tmp_ftyprctrm = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprctrm")
            tmp_hkprctrm = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_hkprctrm")
            tmp_trantrm = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_trantrm")
            tmp_creusr = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_creusr")

            'If tmp_creusr <> "~*DEL*~" And tmp_dv = ins_dv And tmp_pv = ins_pv And tmp_pckunt = ins_pckunt And tmp_inrqty = ins_inrqty And tmp_mtrqty = ins_mtrqty And tmp_cus1no = ins_cus1no And tmp_cus2no = ins_cus2no Then
            '    existcounter = existcounter + 1
            'End If

            'Key with PrcTrm
            If tmp_creusr <> "~*DEL*~" And tmp_dv = ins_dv And tmp_pv = ins_pv And tmp_pckunt = ins_pckunt And tmp_inrqty = ins_inrqty And tmp_mtrqty = ins_mtrqty And tmp_cus1no = ins_cus1no And tmp_cus2no = ins_cus2no And tmp_ftyprctrm = ins_ftyprctrm And tmp_hkprctrm = ins_hkprctrm And tmp_trantrm = ins_trantrm Then
                existcounter = existcounter + 1
            End If

        Next i

        If existcounter >= 1 Then
            'MsgBox("Packing [" & ins_dv & " / " & ins_pv & " / " & ins_pckunt & " / " & ins_inrqty & " / " & ins_mtrqty & " / " & ins_cus1no & " / " & ins_cus2no & "] already exist!")
            'Key with PrcTrm
            MsgBox("Packing [" & ins_dv & " / " & ins_pv & " / " & ins_pckunt & " / " & ins_inrqty & " / " & ins_mtrqty & " / " & ins_cus1no & " / " & ins_cus2no & " / " & ins_ftyprctrm & " / " & ins_hkprctrm & " / " & ins_trantrm & "] already exist!")
            check_insert_CostPrice = False
        Else
            check_insert_CostPrice = True
        End If
    End Function

    Private Function check_update_CostPrice() As Boolean
        Dim i As Integer
        Dim existcounter As Integer
        existcounter = 0

        Dim dv As String
        Dim pv As String
        Dim pack_um As String
        Dim pack_inr As String
        Dim pack_mtr As String
        Dim cus1no As String
        Dim cus2no As String
        Dim hkprctrm As String
        Dim ftyprctrm As String
        Dim trantrm As String

        dv = ""
        pv = ""
        pack_um = ""
        pack_inr = ""
        pack_mtr = ""
        cus1no = ""
        cus2no = ""

        dv = Split(lblPanCPPacking.Text, " / ")(0)
        pv = Split(lblPanCPPacking.Text, " / ")(1)
        pack_um = Split(lblPanCPPacking.Text, " / ")(2)
        pack_inr = Split(lblPanCPPacking.Text, " / ")(3)
        pack_mtr = Split(lblPanCPPacking.Text, " / ")(4)
        cus1no = Split(cboPanCPCus1no.Text, " - ")(0)
        cus2no = Split(cboPanCPCus2no.Text, " - ")(0)
        hkprctrm = cboPanCPPrcTrmHK.Text
        ftyprctrm = cboPanCPPrcTrmFty.Text
        trantrm = cboPanCPTranTrm.Text

        'Check Customer Active
        If cboPanCPCus1no.Text.IndexOf("(Inactive)") >= 0 Then
            MsgBox("Customer " & cus1no & " is Inactive!")
            check_update_CostPrice = False
            Exit Function
        End If
        If cboPanCPCus1no.Text.IndexOf("(Discontinue)") >= 0 Then
            MsgBox("Customer " & cus1no & " is Discontinue!")
            check_update_CostPrice = False
            Exit Function
        End If

        Dim dr_IMPCKINF() As DataRow = rs_IMPCKINF.Tables("RESULT").Select("ipi_pckunt = '" & pack_um & "' and " & _
                                                                           "ipi_inrqty = '" & pack_inr & "' and " & _
                                                                           "ipi_mtrqty = '" & pack_mtr & "' and " & _
                                                                           "ipi_cus1no = '" & cus1no & "' and " & _
                                                                           "ipi_cus2no = '" & cus2no & "' and " & _
                                                                           "ipi_cocde <> 'Y'")
        If dr_IMPCKINF.Length = 0 Then
            MsgBox("Packing not found in Item Master: [" & pack_um & " / " & pack_inr & " / " & pack_mtr & " / " & cus1no & " / " & cus2no & "]", MsgBoxStyle.Information, "IMM00001 - Insert Cost Price")
            Return False
        End If

        For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
            If rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_prdven") = pv And _
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_pckunt") = pack_um And _
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_inrqty") = pack_inr And _
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_mtrqty") = pack_mtr And _
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cus1no") = cus1no And _
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cus2no") = cus2no And _
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprctrm") = ftyprctrm And _
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_hkprctrm") = hkprctrm And _
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_trantrm") = trantrm Then
                existcounter = existcounter + 1
            End If
        Next i

        If existcounter > 1 Then
            MsgBox("Packing [" & dv & " / " & pv & " / " & pack_um & " / " & pack_inr & " / " & pack_mtr & " / " & cus1no & " / " & cus2no & " / " & ftyprctrm & " / " & hkprctrm & " / " & trantrm & "] already exist!")
            check_update_CostPrice = False
        Else
            check_update_CostPrice = True
        End If

    End Function

    Private Sub cmdPanCPUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanCPUpdate.Click
        If lblOrgCus1No.Text <> Split(cboPanCPCus1no.Text, " - ")(0) Or lblOrgCus2No.Text <> Split(cboPanCPCus2no.Text, " - ")(0) Then
            If check_update_CostPrice() = False Then
                Exit Sub
            End If
        End If

        Dim i As Integer

        Dim dv As String
        Dim pv As String
        Dim pack_um As String
        Dim pack_inr As String
        Dim pack_mtr As String
        Dim cus1no As String
        Dim cus2no As String
        Dim ftyprctrm As String
        Dim hkprctrm As String
        Dim trantrm As String

        Dim updrow As Integer
        updrow = -1


        For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
            dv = Split(lblPanCPPacking.Text, " / ")(0)
            pv = Split(lblPanCPPacking.Text, " / ")(1)
            pack_um = Split(lblPanCPPacking.Text, " / ")(2)
            pack_inr = Split(lblPanCPPacking.Text, " / ")(3)
            pack_mtr = Split(lblPanCPPacking.Text, " / ")(4)
            cus1no = lblOrgCus1No.Text
            cus2no = lblOrgCus2No.Text
            ftyprctrm = lblOrgFtyTerm.Text
            hkprctrm = lblOrgHKTerm.Text
            trantrm = lblOrgTranTerm.Text

            If rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_prdven") = pv And _
                    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_pckunt_org") = pack_um And _
                    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_inrqty_org") = pack_inr And _
                    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_mtrqty_org") = pack_mtr And _
                    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cus1no_org") = cus1no And _
                    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cus2no_org") = cus2no And _
                    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprctrm_org") = ftyprctrm And _
                    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_hkprctrm_org") = hkprctrm And _
                    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_trantrm_org") = trantrm Then
                updrow = i
            End If






            'If rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_venno") = dv And _
            '    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_prdven") = pv And _
            '    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_pckunt") = pack_um And _
            '    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_inrqty") = pack_inr And _
            '    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_mtrqty") = pack_mtr Then

            '    'Key with PrcTrm
            '    'If rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_venno") = dv And _
            '    '    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_prdven") = pv And _
            '    '    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_pckunt") = pack_um And _
            '    '    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_inrqty") = pack_inr And _
            '    '    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_mtrqty") = pack_mtr And _
            '    '    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cus1no") = cus1no And _
            '    '    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cus2no") = cus2no And _
            '    '    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprctrm") = ftyprctrm And _
            '    '    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_hkprctrm") = hkprctrm And _
            '    '    rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_trantrm") = trantrm Then

            '    updrow = i
            'End If
        Next i

        If updrow <> -1 Then
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_cus1no") = Split(cboPanCPCus1no.Text, " - ")(0)
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_cus2no") = Split(cboPanCPCus2no.Text, " - ")(0)
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_ftyprctrm") = cboPanCPPrcTrmFty.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_hkprctrm") = cboPanCPPrcTrmHK.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_trantrm") = cboPanCPTranTrm.Text

            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_effdat") = txtPanCPEffDate.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_expdat") = txtPanCPExpDate.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_status") = cboPanCPStatus.Text

            '            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_curcde") = ""
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_ftycst") = txtPanCPFtyCst.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_ftycstA") = txtPanCPFtyCstA.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_ftycstB") = txtPanCPFtyCstB.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_ftycstC") = txtPanCPFtyCstC.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_ftycstD") = txtPanCPFtyCstD.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_ftycstE") = txtPanCPFtyCstE.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_ftycstTran") = txtPanCPFtyCstTran.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_ftycstPack") = txtPanCPFtyCstPack.Text

            'rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_fml") = txtPanCPFml.Text
            'rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_fmlA") = txtPanCPFmlA.Text
            'rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_fmlB") = txtPanCPFmlB.Text
            'rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_fmlC") = txtPanCPFmlC.Text
            'rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_fmlD") = txtPanCPFmlD.Text
            'rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_fmlE") = txtPanCPFmlE.Text
            'rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_fmlTran") = txtPanCPFmlTran.Text
            'rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_fmlPack") = txtPanCPFmlPack.Text

            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_chgfp") = txtPanCPMU.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_chgfpA") = txtPanCPMUA.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_chgfpB") = txtPanCPMUB.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_chgfpC") = txtPanCPMUC.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_chgfpD") = txtPanCPMUD.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_chgfpE") = txtPanCPMUE.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_chgfpTran") = txtPanCPMUTran.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_chgfpPack") = txtPanCPMUPack.Text

            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_ftyprc") = txtPanCPFtyPrc.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_ftyprcA") = txtPanCPFtyPrcA.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_ftyprcB") = txtPanCPFtyPrcB.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_ftyprcC") = txtPanCPFtyPrcC.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_ftyprcD") = txtPanCPFtyPrcD.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_ftyprcE") = txtPanCPFtyPrcE.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_ftyprcTran") = txtPanCPFtyPrcTran.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_ftyprcPack") = txtPanCPFtyPrcPack.Text

            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_bomcst") = txtPanCPBOMCst.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_ttlcst") = txtPanCPTtlCst.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_hkadjper") = txtPanCPAdjPer.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_fmlopt") = cboPanCPFmlHK.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_negcst") = txtPanCPNegCst.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_negprc") = txtPanCPNegPrc.Text

            '            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_bcurcde") = ""
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_itmprc") = txtPanCPItmPrc.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_bomprc") = txtPanCPBOMPrc.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_basprc") = txtPanCPBasicPrc.Text

            '            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_period") = ""
            '            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_cstchgdat") = ""

            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_estprcflg") = cboPanCPEstPrcFlg.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_estprcref") = txtPanCPEstPrcRef.Text
            rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_sysgen") = "N"

            Recordstatus = True

            If rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_creusr") <> "~*ADD*~" Then
                rs_IMPRCINF.Tables("RESULT").Rows(updrow).Item("imu_creusr") = "~*UPD*~"
            End If

            If Split(cboItmVenTyp.Text, " - ")(0) = "INT" Then
                ' Update PV Price
                'Dim dr() As DataRow = rs_IMPRCINF.Tables("RESULT").Select("imu_pckunt = '" & pack_um & "' and " & _
                '                                                          "imu_inrqty = '" & pack_inr & "' and " & _
                '                                                          "imu_mtrqty = '" & pack_mtr & "' and " & _
                '                                                          "imu_prdven = '" & pv & "' and " & _
                '                                                          "imu_cus1no = '" & Split(cboPanCPCus1no.Text, " - ")(0) & "' and " & _
                '                                                          "imu_cus2no = '" & Split(cboPanCPCus2no.Text, " - ")(0) & "' and " & _
                '                                                          "imu_hkprctrm = '" & cboPanCPPrcTrmHK.Text & "' and " & _
                '                                                          "imu_ftyprctrm = '" & cboPanCPPrcTrmFty.Text & "' and " & _
                '                                                          "imu_trantrm = '" & cboPanCPTranTrm.Text & "'")
                Dim dr() As DataRow = rs_IMPRCINF.Tables("RESULT").Select("imu_pckunt = '" & pack_um & "' and " & _
                                                                          "imu_inrqty = '" & pack_inr & "' and " & _
                                                                          "imu_mtrqty = '" & pack_mtr & "' and " & _
                                                                          "imu_cus1no = '" & Split(cboPanCPCus1no.Text, " - ")(0) & "' and " & _
                                                                          "imu_cus2no = '" & Split(cboPanCPCus2no.Text, " - ")(0) & "' and " & _
                                                                          "imu_hkprctrm = '" & cboPanCPPrcTrmHK.Text & "' and " & _
                                                                          "imu_ftyprctrm = '" & cboPanCPPrcTrmFty.Text & "' and " & _
                                                                          "imu_trantrm = '" & cboPanCPTranTrm.Text & "'")
                If dr.Length > 0 Then
                    For j As Integer = 0 To dr.Length - 1
                        dr(j)("imu_status") = cboPanCPStatus.Text
                        dr(j)("imu_effdat") = txtPanCPEffDate.Text
                        dr(j)("imu_expdat") = txtPanCPExpDate.Text
                        dr(j)("imu_curcde") = lblPanCPFCurcde.Text.Substring(1, Len(lblPanCPFCurcde.Text) - 2)
                        dr(j)("imu_ftycst") = txtPanCPFtyCst.Text
                        dr(j)("imu_ftycstA") = txtPanCPFtyCstA.Text
                        dr(j)("imu_ftycstB") = txtPanCPFtyCstB.Text
                        dr(j)("imu_ftycstC") = txtPanCPFtyCstC.Text
                        dr(j)("imu_ftycstD") = txtPanCPFtyCstD.Text
                        dr(j)("imu_ftycstE") = txtPanCPFtyCstE.Text
                        dr(j)("imu_ftycstTran") = txtPanCPFtyCstTran.Text
                        dr(j)("imu_ftycstPack") = txtPanCPFtyCstPack.Text
                        dr(j)("imu_fml") = ""
                        dr(j)("imu_fmlA") = ""
                        dr(j)("imu_fmlB") = ""
                        dr(j)("imu_fmlC") = ""
                        dr(j)("imu_fmlD") = ""
                        dr(j)("imu_fmlE") = ""
                        dr(j)("imu_fmlTran") = ""
                        dr(j)("imu_fmlPack") = ""
                        dr(j)("imu_chgfp") = txtPanCPMU.Text
                        dr(j)("imu_chgfpA") = txtPanCPMUA.Text
                        dr(j)("imu_chgfpB") = txtPanCPMUB.Text
                        dr(j)("imu_chgfpC") = txtPanCPMUC.Text
                        dr(j)("imu_chgfpD") = txtPanCPMUD.Text
                        dr(j)("imu_chgfpE") = txtPanCPMUE.Text
                        dr(j)("imu_chgfpTran") = txtPanCPMUTran.Text
                        dr(j)("imu_chgfpPack") = txtPanCPMUPack.Text
                        dr(j)("imu_ftyprc") = txtPanCPFtyPrc.Text
                        dr(j)("imu_ftyprcA") = txtPanCPFtyPrcA.Text
                        dr(j)("imu_ftyprcB") = txtPanCPFtyPrcB.Text
                        dr(j)("imu_ftyprcC") = txtPanCPFtyPrcC.Text
                        dr(j)("imu_ftyprcD") = txtPanCPFtyPrcD.Text
                        dr(j)("imu_ftyprcE") = txtPanCPFtyPrcE.Text
                        dr(j)("imu_ftyprcTran") = txtPanCPFtyPrcTran.Text
                        dr(j)("imu_ftyprcPack") = txtPanCPFtyPrcPack.Text
                        dr(j)("imu_bomcst") = txtPanCPBOMCst.Text
                        dr(j)("imu_ttlcst") = txtPanCPTtlCst.Text
                        dr(j)("imu_hkadjper") = 0.0
                        dr(j)("imu_negcst") = 0.0
                        dr(j)("imu_negprc") = txtPanCPNegPrc.Text
                        dr(j)("imu_fmlopt") = cboPanCPFmlHK.Text
                        dr(j)("imu_bcurcde") = lblPanCPBCurcde.Text.Substring(1, Len(lblPanCPBCurcde.Text) - 2)
                        dr(j)("imu_itmprc") = txtPanCPItmPrc.Text
                        dr(j)("imu_bomprc") = txtPanCPBOMPrc.Text
                        dr(j)("imu_basprc") = txtPanCPBasicPrc.Text
                        dr(j)("imu_period") = ""
                        dr(j)("imu_cstchgdat") = Today.ToString
                    Next
                End If
            End If

            PanelCostPrice.Visible = False
            release_TabControl()
            format_TabControl("IM", Split(cboItmTyp.Text, " - ")(0))

        End If
    End Sub

    Private Sub txtPanPackInner_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanPackInner.KeyPress
        If Not (e.KeyChar = vbBack Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtPanPackMaster_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanPackMaster.KeyPress
        If Not (e.KeyChar = vbBack Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtPanPackCFT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanPackCFT.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanPackCFT.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_panpack_keypress = True
    End Sub

    Private Sub txtPanPackCBM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanPackCBM.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanPackCBM.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_panpack_keypress = True
    End Sub

    Private Sub txtPanPackGW_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanPackGW.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanPackGW.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub txtPanPackNW_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanPackNW.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanPackNW.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub txtPanPackInnerInchL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanPackInnerInchL.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanPackInnerInchL.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_panpack_keypress = True
    End Sub

    Private Sub txtPanPackInnerInchW_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanPackInnerInchW.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanPackInnerInchW.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_panpack_keypress = True
    End Sub

    Private Sub txtPanPackInnerInchH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanPackInnerInchH.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanPackInnerInchH.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_panpack_keypress = True
    End Sub

    Private Sub txtPanPackMasterInchL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanPackMasterInchL.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanPackMasterInchL.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_panpack_keypress = True
    End Sub

    Private Sub txtPanPackMasterInchW_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanPackMasterInchW.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanPackMasterInchW.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_panpack_keypress = True
    End Sub

    Private Sub txtPanPackMasterInchH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanPackMasterInchH.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanPackMasterInchH.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_panpack_keypress = True
    End Sub

    Private Sub txtPanPackInnerCML_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanPackInnerCML.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanPackInnerCML.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_panpack_keypress = True
    End Sub

    Private Sub txtPanPackInnerCMW_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanPackInnerCMW.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanPackInnerCMW.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_panpack_keypress = True
    End Sub

    Private Sub txtPanPackInnerCMH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanPackInnerCMH.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanPackInnerCMH.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_panpack_keypress = True
    End Sub

    Private Sub txtPanPackMasterCML_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanPackMasterCML.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanPackMasterCML.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_panpack_keypress = True
    End Sub

    Private Sub txtPanPackMasterCMW_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanPackMasterCMW.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanPackMasterCMW.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_panpack_keypress = True
    End Sub

    Private Sub txtPanPackMasterCMH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanPackMasterCMH.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanPackMasterCMH.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_panpack_keypress = True
    End Sub

    Private Sub rbPriceStatus_All_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPriceStatus_All.CheckedChanged
        If rs_IMPRCINF.Tables.Count = 0 Then
            Exit Sub
        End If

        If rbPriceStatus_All.Checked = True Then
            Dim sFilter As String
            sFilter = ""
            rs_IMPRCINF.Tables("RESULT").DefaultView.RowFilter = sFilter
            dgCostPrice.DataSource = rs_IMPRCINF.Tables("RESULT").DefaultView
        End If
    End Sub

    Private Sub rbPriceStatus_ACT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPriceStatus_ACT.CheckedChanged
        If rs_IMPRCINF.Tables.Count = 0 Then
            Exit Sub
        End If

        If rbPriceStatus_ACT.Checked = True Then
            Dim sFilter As String
            sFilter = "imu_status = 'ACT'"
            rs_IMPRCINF.Tables("RESULT").DefaultView.RowFilter = sFilter
            dgCostPrice.DataSource = rs_IMPRCINF.Tables("RESULT").DefaultView
        End If
    End Sub

    Private Sub rbPriceStatus_INA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPriceStatus_INA.CheckedChanged
        If rs_IMPRCINF.Tables.Count = 0 Then
            Exit Sub
        End If

        If rbPriceStatus_INA.Checked = True Then
            Dim sFilter As String
            sFilter = "imu_status = 'INA'"
            rs_IMPRCINF.Tables("RESULT").DefaultView.RowFilter = sFilter
            dgCostPrice.DataSource = rs_IMPRCINF.Tables("RESULT").DefaultView
        End If
    End Sub

    Private Sub rbPriceStatus_NA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPriceStatus_NA.CheckedChanged
        If rs_IMPRCINF.Tables.Count = 0 Then
            Exit Sub
        End If

        If rbPriceStatus_NA.Checked = True Then
            Dim sFilter As String
            sFilter = "imu_status = 'TBC'"
            rs_IMPRCINF.Tables("RESULT").DefaultView.RowFilter = sFilter
            dgCostPrice.DataSource = rs_IMPRCINF.Tables("RESULT").DefaultView
        End If
    End Sub

    Private Sub delete_Packing()
        Dim i As Integer
        Dim counter As Integer
        counter = 0
        For i = 0 To dgPacking.RowCount - 1
            If Trim(dgPacking.Item(dgPacking_ipi_cocde, i).Value) = "" Then
                counter = counter + 1
            End If
        Next i

        If counter = 1 Then
            MsgBox("At least one packing must exist!")
            Exit Sub
        End If


        If MsgBox("All Cost Price related to this packing will be deleted!", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim del_pack_um As String
        Dim del_pack_inr As String
        Dim del_pack_mtr As String
        Dim del_pack_cus1no As String
        Dim del_pack_cus2no As String

        del_pack_um = dgPacking.Item(6, dgPacking.CurrentCell.RowIndex).Value
        del_pack_inr = dgPacking.Item(7, dgPacking.CurrentCell.RowIndex).Value
        del_pack_mtr = dgPacking.Item(8, dgPacking.CurrentCell.RowIndex).Value
        del_pack_cus1no = dgPacking.Item(dgPacking_ipi_cus1no, dgPacking.CurrentCell.RowIndex).Value
        del_pack_cus2no = dgPacking.Item(dgPacking_ipi_cus2no, dgPacking.CurrentCell.RowIndex).Value

        Dim tmp_pack_um As String
        Dim tmp_pack_inr As String
        Dim tmp_pack_mtr As String
        Dim tmp_pack_cus1no As String
        Dim tmp_pack_cus2no As String

        For i = 0 To rs_IMPCKINF.Tables("RESULT").Rows.Count - 1
            tmp_pack_um = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_pckunt")
            tmp_pack_inr = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_inrqty")
            tmp_pack_mtr = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_mtrqty")
            tmp_pack_cus1no = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cus1no")
            tmp_pack_cus2no = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cus2no")

            If del_pack_um = tmp_pack_um And del_pack_inr = tmp_pack_inr And del_pack_mtr = tmp_pack_mtr And del_pack_cus1no = tmp_pack_cus1no And del_pack_cus2no = tmp_pack_cus2no Then
                'rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_creusr") = "~*DEL*~"
                rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cocde") = "Y"
                Recordstatus = True
            End If
        Next i

        For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
            tmp_pack_um = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_pckunt")
            tmp_pack_inr = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_inrqty")
            tmp_pack_mtr = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_mtrqty")
            tmp_pack_cus1no = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cus1no")
            tmp_pack_cus2no = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cus2no")

            If del_pack_um = tmp_pack_um And del_pack_inr = tmp_pack_inr And del_pack_mtr = tmp_pack_mtr And del_pack_cus1no = tmp_pack_cus1no And del_pack_cus2no = tmp_pack_cus2no Then
                'rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_creusr") = "~*DEL*~"
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cocde") = "Y"
                Recordstatus = True
            End If
        Next i
    End Sub

    Private Sub undelete_Packing()
        Dim del_pack_um As String
        Dim del_pack_inr As String
        Dim del_pack_mtr As String
        Dim del_pack_cus1no As String
        Dim del_pack_cus2no As String

        del_pack_um = dgPacking.Item(6, dgPacking.CurrentCell.RowIndex).Value
        del_pack_inr = dgPacking.Item(7, dgPacking.CurrentCell.RowIndex).Value
        del_pack_mtr = dgPacking.Item(8, dgPacking.CurrentCell.RowIndex).Value
        del_pack_cus1no = dgPacking.Item(dgPacking_ipi_cus1no, dgPacking.CurrentCell.RowIndex).Value
        del_pack_cus2no = dgPacking.Item(dgPacking_ipi_cus2no, dgPacking.CurrentCell.RowIndex).Value

        Dim tmp_pack_um As String
        Dim tmp_pack_inr As String
        Dim tmp_pack_mtr As String
        Dim tmp_pack_cus1no As String
        Dim tmp_pack_cus2no As String

        Dim i As Integer

        For i = 0 To rs_IMPCKINF.Tables("RESULT").Rows.Count - 1
            tmp_pack_um = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_pckunt")
            tmp_pack_inr = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_inrqty")
            tmp_pack_mtr = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_mtrqty")
            tmp_pack_cus1no = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cus1no")
            tmp_pack_cus2no = rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cus2no")

            If del_pack_um = tmp_pack_um And del_pack_inr = tmp_pack_inr And del_pack_mtr = tmp_pack_mtr And del_pack_cus1no = tmp_pack_cus1no And del_pack_cus2no = tmp_pack_cus2no Then
                'rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_creusr") = "~*DEL*~"
                rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_cocde") = ""
                Recordstatus = True
            End If
        Next i

        For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
            tmp_pack_um = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_pckunt")
            tmp_pack_inr = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_inrqty")
            tmp_pack_mtr = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_mtrqty")
            tmp_pack_cus1no = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cus1no")
            tmp_pack_cus2no = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cus2no")

            If del_pack_um = tmp_pack_um And del_pack_inr = tmp_pack_inr And del_pack_mtr = tmp_pack_mtr And del_pack_cus1no = tmp_pack_cus1no And del_pack_cus2no = tmp_pack_cus2no Then
                'rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_creusr") = "~*DEL*~"
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cocde") = ""
                Recordstatus = True
            End If
        Next i

    End Sub


    Private Sub delete_CostPrice()
        If check_delete_CostPrice() = False Then
            Exit Sub
        End If

        Dim del_dv As String
        Dim del_pv As String
        Dim del_pckunt As String
        Dim del_inrqty As String
        Dim del_mtrqty As String
        Dim del_cus1no As String
        Dim del_cus2no As String
        Dim del_ftyprctrm As String
        Dim del_hkprctrm As String
        Dim del_trantrm As String

        del_dv = dgCostPrice.Item(4, dgCostPrice.CurrentCell.RowIndex).Value
        del_pv = dgCostPrice.Item(5, dgCostPrice.CurrentCell.RowIndex).Value
        Dim packstr As String
        packstr = dgCostPrice.Item(6, dgCostPrice.CurrentCell.RowIndex).Value
        del_pckunt = Split(packstr, " / ")(0)
        del_inrqty = Split(packstr, " / ")(1)
        del_mtrqty = Split(packstr, " / ")(2)
        del_cus1no = dgCostPrice.Item(12, dgCostPrice.CurrentCell.RowIndex).Value
        del_cus2no = dgCostPrice.Item(13, dgCostPrice.CurrentCell.RowIndex).Value
        del_ftyprctrm = dgCostPrice.Item(14, dgCostPrice.CurrentCell.RowIndex).Value
        del_hkprctrm = dgCostPrice.Item(15, dgCostPrice.CurrentCell.RowIndex).Value
        del_trantrm = dgCostPrice.Item(16, dgCostPrice.CurrentCell.RowIndex).Value

        Dim i As Integer

        Dim tmp_dv As String
        Dim tmp_pv As String
        Dim tmp_pckunt As String
        Dim tmp_inrqty As String
        Dim tmp_mtrqty As String
        Dim tmp_cus1no As String
        Dim tmp_cus2no As String
        Dim tmp_ftyprctrm As String
        Dim tmp_hkprctrm As String
        Dim tmp_trantrm As String

        Dim tmp_creusr As String

        For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
            tmp_dv = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_venno")
            tmp_pv = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_prdven")
            tmp_pckunt = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_pckunt")
            tmp_inrqty = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_inrqty")
            tmp_mtrqty = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_mtrqty")
            tmp_cus1no = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cus1no")
            tmp_cus2no = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cus2no")
            tmp_ftyprctrm = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_ftyprctrm")
            tmp_hkprctrm = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_hkprctrm")
            tmp_trantrm = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_trantrm")
            tmp_creusr = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_creusr")

            If tmp_dv = del_dv And tmp_pv = del_pv And tmp_pckunt = del_pckunt And tmp_inrqty = del_inrqty And tmp_mtrqty = del_mtrqty And tmp_cus1no = del_cus1no And tmp_cus2no = del_cus2no And tmp_ftyprctrm = del_ftyprctrm And tmp_hkprctrm = del_hkprctrm And tmp_trantrm = del_trantrm Then
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_creusr") = "~*DEL*~"
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cocde") = "Y"
                Recordstatus = True
            End If
        Next
    End Sub

    Private Function check_delete_CostPrice() As Boolean
        check_delete_CostPrice = False

        Dim del_dv As String
        Dim del_pv As String
        Dim del_pckunt As String
        Dim del_inrqty As String
        Dim del_mtrqty As String

        del_dv = dgCostPrice.Item(4, dgCostPrice.CurrentCell.RowIndex).Value
        del_pv = dgCostPrice.Item(5, dgCostPrice.CurrentCell.RowIndex).Value
        Dim packstr As String
        packstr = dgCostPrice.Item(6, dgCostPrice.CurrentCell.RowIndex).Value
        del_pckunt = Split(packstr, " / ")(0)
        del_inrqty = Split(packstr, " / ")(1)
        del_mtrqty = Split(packstr, " / ")(2)

        Dim i As Integer

        Dim tmp_cocde As String
        Dim tmp_dv As String
        Dim tmp_pv As String
        Dim tmp_pckunt As String
        Dim tmp_inrqty As String
        Dim tmp_mtrqty As String
        Dim tmp_creusr As String

        Dim existcounter As Integer
        existcounter = 0

        For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
            tmp_cocde = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cocde")
            tmp_dv = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_venno")
            tmp_pv = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_prdven")
            tmp_pckunt = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_pckunt")
            tmp_inrqty = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_inrqty")
            tmp_mtrqty = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_mtrqty")
            tmp_creusr = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_creusr")

            If tmp_cocde <> "Y" And tmp_dv = del_dv And tmp_pv = del_pv And tmp_pckunt = del_pckunt And tmp_inrqty = del_inrqty And tmp_mtrqty = del_mtrqty Then
                existcounter = existcounter + 1
            End If
        Next i

        If existcounter > 1 Then
            check_delete_CostPrice = True
        Else
            MsgBox("At least one packing [" & del_dv & " / " & del_pv & " / " & del_pckunt & " / " & del_inrqty & " / " & del_mtrqty & "] must exist!")
            check_delete_CostPrice = False
        End If
    End Function


    Private Sub delete_PV()
        If dgPV.Item(7, dgPV.CurrentCell.RowIndex).Value = "Y" Then
            MsgBox("Default PV cannot be deleted!")
            Exit Sub
        End If

        Dim strDV As String
        strDV = Split(cboDV.Text, " - ")(0)

        Dim del_pv As String
        del_pv = dgPV.Item(4, dgPV.CurrentCell.RowIndex).Value

        If strDV = del_pv Then
            MsgBox("Design Vendor PV cannot be deleted!")
            Exit Sub
        End If

        If MsgBox("All Cost Price related to this Production Vendor will be deleted!", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If


        Dim tmp_pv As String

        Dim i As Integer
        For i = 0 To rs_IMVENINF.Tables("RESULT").Rows.Count - 1
            tmp_pv = rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_venno")

            If del_pv = tmp_pv Then
                'rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_creusr") = "~*DEL*~"
                rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_cocde") = "Y"
                Recordstatus = True
            End If
        Next i

        For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
            tmp_pv = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_prdven")

            If del_pv = tmp_pv Then
                Recordstatus = True
                'rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_creusr") = "~*DEL*~"
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cocde") = "Y"
            End If
        Next i
    End Sub

    Private Sub undelete_PV()
        Dim del_pv As String
        del_pv = dgPV.Item(4, dgPV.CurrentCell.RowIndex).Value

        Dim tmp_pv As String

        Dim i As Integer
        For i = 0 To rs_IMVENINF.Tables("RESULT").Rows.Count - 1
            tmp_pv = rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_venno")

            If del_pv = tmp_pv Then
                'rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_creusr") = "~*DEL*~"
                rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_cocde") = ""
                Recordstatus = True
            End If
        Next i

        For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
            tmp_pv = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_prdven")

            If del_pv = tmp_pv Then
                Recordstatus = True
                'rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_creusr") = "~*DEL*~"
                rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cocde") = ""
            End If
        Next i
    End Sub


    Private Sub changeDefaultPV()
        If dgPV.Item(7, dgPV.CurrentCell.RowIndex).Value = "Y" Then
            Exit Sub
        End If

        Dim default_pv As String
        default_pv = dgPV.Item(4, dgPV.CurrentCell.RowIndex).Value

        Dim tmp_pv As String

        Dim i As Integer
        For i = 0 To rs_IMVENINF.Tables("RESULT").Rows.Count - 1
            tmp_pv = rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_venno")

            If default_pv = tmp_pv Then
                If rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_creusr") <> "~*ADD*~" Then
                    rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_creusr") = "~*UPD*~"
                End If
                rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_def") = "Y"
                Recordstatus = True
            ElseIf rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_def") = "Y" Then
                If rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_creusr") <> "~*ADD*~" Then
                    rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_creusr") = "~*UPD*~"
                End If
                rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_def") = "N"
                Recordstatus = True
            End If
        Next i
    End Sub

    Private Sub dgPacking_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPacking.CellDoubleClick
        If mode = "READ" Then
            Exit Sub
        End If

        If dgPacking.CurrentCell.ColumnIndex = 2 And dgPacking.SelectedRows.Count = 0 And e.ColumnIndex = 2 And e.RowIndex >= 0 Then
            If Split(cboItmTyp.Text, " - ")(0) = "REG" Or Split(cboItmTyp.Text, " - ")(0) = "ASS" Then
                Dim iCol As Integer = dgPacking.CurrentCell.ColumnIndex
                Dim iRow As Integer = dgPacking.CurrentCell.RowIndex
                Dim curvalue As String
                curvalue = dgPacking.CurrentCell.Value

                If Trim(curvalue) = "" Then
                    delete_Packing()
                Else
                    undelete_Packing()
                End If
            End If
        End If
    End Sub

    Private Sub cmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopy.Click
        If Recordstatus = True Then
            MsgBox("Item has been modified, please save it before Copy")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If PanelAdd.Visible = True Then
            MsgBox("Item in Add Panel Process, item not copy!")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If PanelCopy.Visible = True Then
            MsgBox("Item in Copy Panel Process, item not copy!")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If PanelPacking.Visible = True Then
            MsgBox("Item in Packing Panel Process, item not copy!")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If PanelCostPrice.Visible = True Then
            MsgBox("Item in Cost Price Panel Process, item not copy!")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        freeze_TabControl(-1)
        resetcmdButton("DisableAll")
        txtPanCopyVenItmNo.Text = ""
        display_combo(cboPrdLne.Text, cboPanCopyPrdLne)
        display_combo(Split(cboCategory.Text, " - ")(0), cboPanCopyCategory)
        PanelCopy.Height = 97
        PanelCopy.Width = 257
        PanelCopy.Top = 12
        PanelCopy.Left = 167

        PanelCopy.Visible = True
    End Sub

    Private Sub cmdPanCopyCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanCopyCancel.Click
        release_TabControl()
        PanelCopy.Visible = False
        mode = "UPDATE"
        formInit(mode)
    End Sub

    Private Sub cmdPanCopyCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanCopyCopy.Click
        If txtPanCopyVenItmNo.Text = "" Then
            MsgBox("Vendor Item Number cannot empty!")
            txtPanCopyVenItmNo.Select()
            Exit Sub
        End If

        If txtPanCopyVenItmNo.Text = txtItmNo.Text Then
            MsgBox("Vendor Item Number same as Item Number Copy")
            txtPanCopyVenItmNo.Select()
            Exit Sub
        End If

        'For external item, check dupliate vendor item number
        If Split(cboItmVenTyp.Text, " - ")(0) = "EXT" Then
            gspStr = "sp_select_IMVENINF_Check '','" & txtPanCopyVenItmNo.Text & "','" & Split(cboDV.Text, " - ")(0) & "'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdPanCopyCopy_Click sp_select_IMVENINF_Check :" & rtnStr)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If rs.Tables("RESULT").Rows.Count = 0 Then
                gspStr = "sp_select_IMVENINFH_Check '','" & txtPanCopyVenItmNo.Text & "','" & Split(cboDV.Text, " - ")(0) & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cmdPanCopyCopy_Click sp_select_IMVENINFH_Check :" & rtnStr)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                If rs.Tables("RESULT").Rows.Count > 0 Then
                    MsgBox("Vendor Item Number exist!")
                    txtPanCopyVenItmNo.Select()
                    Exit Sub
                End If
            Else
                MsgBox("Vendor Item Number exist!")
                txtPanCopyVenItmNo.Select()
                Exit Sub
            End If
        End If


        gspStr = "sp_select_IMType '','" & txtPanCopyVenItmNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMType, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdPanCopyCopy_Click sp_select_IMType :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        If rs_IMType.Tables("RESULT").Rows.Count <> 1 Then
            MsgBox("Error on loading cmdPanCopyCopy_Click sp_select_IMType 1 :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If rs_IMType.Tables("RESULT").Rows(0).Item("IM") = "N" And rs_IMType.Tables("RESULT").Rows(0).Item("IMH") = "N" And rs_IMType.Tables("RESULT").Rows(0).Item("PCIM") = "N" And rs_IMType.Tables("RESULT").Rows(0).Item("PCIMH") = "N" Then
            create_ItemMaster()
        Else
            MsgBox("Vendor Item Number exist, Item cannot Copy")
            txtPanCopyVenItmNo.Select()
            Exit Sub
        End If

        mode = "ADD"
        formInit(mode)
    End Sub

    Private Sub create_ItemMaster()
        'txtItmNo.Text = txtPanCopyVenItmNo.Text

        Dim dv As String
        dv = Split(cboDV.Text, " - ")(0)
        If dv = "" Then
            MsgBox("Design Vendor cannot empty!")
            Exit Sub
        End If
        'If Not (dv >= "0001" And dv <= "9999") Then
        '    MsgBox("Only for Design Vendor 0001 to 9999 can be copied!")
        '    Exit Sub
        'End If

        'Assign Item Number
        If Split(cboItmVenTyp.Text, " - ")(0) = "EXT" Then
            gspStr = "sp_select_ITEMNO_UCP '','','','" & Split(cboDV.Text, " - ")(0) & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_itmno_generation, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdSave_Click sp_select_ITEMNO_UCP :" & rtnStr)
                Exit Sub
            End If

            txtItmNo.Text = rs_itmno_generation.Tables("RESULT").Rows(0).Item("Max_itmno")
        Else
            txtItmNo.Text = txtPanCopyVenItmNo.Text
        End If
        Dim i As Integer

        'IMBASINF
        For i = 0 To rs_IMBASINF.Tables("RESULT").Columns.Count - 1
            rs_IMBASINF.Tables("RESULT").Columns(i).ReadOnly = False
        Next i

        txtItmRmk.Text = ""
        txtCstRmk.Text = ""


        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmno") = txtItmNo.Text
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_imgpth") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_rmk") = ""
        pbImage.Image = Nothing
        pbImage2.Image = Nothing
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_lnecde") = cboPanCopyPrdLne.Text
        display_combo(cboPanCopyPrdLne.Text, cboPrdLne)
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_catlvl4") = cboPanCopyCategory.Text
        display_combo(cboPanCopyCategory.Text, cboCategory)
        'rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_imgpthhr") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*ADD*~"

        'IMCOLINF
        For i = 0 To rs_IMCOLINF.Tables("RESULT").Rows.Count - 1
            rs_IMCOLINF.Tables("RESULT").Columns("icf_itmno").ReadOnly = False
            rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_itmno") = txtItmNo.Text
            rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_creusr") = "~*ADD*~"
        Next i

        If rs_IMCOLINF.Tables("RESULT").Rows.Count = 0 Then
            rs_IMCOLINF.Tables("RESULT").Rows.Add()
            rs_IMCOLINF.Tables("RESULT").Rows(0).Item("icf_itmno") = txtItmNo.Text
            rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_colcde") = ""
            rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_colseq") = 1
            rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_vencol") = ""
            rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_coldsc") = ""
            rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_ucpcde") = ""
            rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_eancde") = ""
            rs_IMCOLINF.Tables("RESULT").Rows(i).Item("icf_creusr") = "~*ADD*~"
        End If


        'IMPCKINF
        For i = 0 To rs_IMPCKINF.Tables("RESULT").Rows.Count - 1
            rs_IMPCKINF.Tables("RESULT").Columns("ipi_itmno").ReadOnly = False
            rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_itmno") = txtItmNo.Text
            rs_IMPCKINF.Tables("RESULT").Rows(i).Item("ipi_creusr") = "~*ADD*~"
        Next i

        'IMVENINF
        For i = 0 To rs_IMVENINF.Tables("RESULT").Rows.Count - 1
            rs_IMVENINF.Tables("RESULT").Columns("ivi_itmno").ReadOnly = False
            rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_itmno") = txtItmNo.Text
            rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_venitm") = txtPanCopyVenItmNo.Text
            rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_creusr") = "~*ADD*~"
        Next i

        'IMBOMASS
        For i = 0 To rs_IMBOMASS.Tables("RESULT").Rows.Count - 1
            rs_IMBOMASS.Tables("RESULT").Columns("iba_itmno").ReadOnly = False
            rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_itmno") = txtItmNo.Text
            rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_creusr") = "~*ADD*~"
        Next i

        'IMPRCINF
        For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
            rs_IMPRCINF.Tables("RESULT").Columns("imu_itmno").ReadOnly = False
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_itmno") = txtItmNo.Text
            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_creusr") = "~*ADD*~"
        Next i

        'IMMOQMOA
        For i = 0 To rs_IMMOQMOA.Tables("RESULT").Rows.Count - 1
            rs_IMMOQMOA.Tables("RESULT").Columns("imm_itmno").ReadOnly = False
            rs_IMMOQMOA.Tables("RESULT").Rows(i)("imm_itmno") = txtItmNo.Text
            rs_IMMOQMOA.Tables("RESULT").Rows(i)("imm_creusr") = "~*ADD*~"
        Next

        rs_IMCSTINF.Tables("RESULT").Rows.Clear()
        rs_IMCTYINF.Tables("RESULT").Rows.Clear()
        rs_IMCUSNO.Tables("RESULT").Rows.Clear()
        rs_IMMATBKD.Tables("RESULT").Rows.Clear()

        Recordstatus = True

        release_TabControl()
        format_TabControl("IM", Split(cboItmTyp.Text, " - ")(0))

        PanelCopy.Visible = False
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Me.Cursor = Cursors.WaitCursor


        If PanelAdd.Visible = True Then
            MsgBox("Item in Add Panel Process, item not deleted!")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If PanelCopy.Visible = True Then
            MsgBox("Item in Copy Panel Process, item not deleted!")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If PanelPacking.Visible = True Then
            MsgBox("Item in Packing Panel Process, item not deleted!")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If PanelCostPrice.Visible = True Then
            MsgBox("Item in Cost Price Panel Process, item not deleted!")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If Split(cboItmTyp.Text, " - ")(0) = "REG" Or Split(cboItmTyp.Text, " - ")(0) = "BOM" Then
            If rs_IMR00021.Tables("RESULT").Rows.Count > 0 Then
                MsgBox("Item linked with other Assortment or Regular item!")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        If rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_latrdat") <> "1900/01/01" Then
            Dim qu_count As Integer
            Dim sc_count As Integer

            qu_count = 0
            sc_count = 0

            gspStr = "sp_list_IMM00001_Delete '','" & txtItmNo.Text & "','QU'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdDelete_Click sp_list_IM00001_Delete QU :" & rtnStr)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            qu_count = rs.Tables("RESULT").Rows.Count

            gspStr = "sp_list_IMM00001_Delete '','" & txtItmNo.Text & "','SC'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdDelete_Click sp_list_IM00001_Delete SC :" & rtnStr)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            sc_count = rs.Tables("RESULT").Rows.Count

            If qu_count > 0 Or sc_count > 0 Then
                MsgBox("Item cannot be deleted due to item quoted before!")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If


        If MsgBox("Are you sure to delete item " & txtItmNo.Text & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_physical_delete_IMBASINF '','(''" & txtItmNo.Text & "'')'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdPanCopyCopy_Click sp_physical_delete_IMBASINF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        MsgBox("Record Deleted!")

        mode = "INIT"
        formInit(mode)
        txtItmNo.Select()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        freeze_TabControl(-1)
        resetcmdButton("DisableAll")

        PanelAdd.Height = 88
        PanelAdd.Width = 182
        PanelAdd.Top = 12
        PanelAdd.Left = 31

        PanelAdd.Visible = True
    End Sub

    Private Sub cmdPanelAddCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanelAddCancel.Click
        release_TabControl()
        PanelAdd.Visible = False
        mode = "INIT"
        formInit(mode)
    End Sub

    Private Sub cmdPanelAddAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanelAddAdd.Click
        mode = "ADD"
        txtItmNo.Text = ""
        PanelAdd.Visible = False

        rs_IMBASINF.Tables("RESULT").Rows.Clear()
        rs_IMBASINF.Tables("RESULT").Rows.Add()

        Dim i As Integer
        For i = 0 To rs_IMBASINF.Tables("RESULT").Columns.Count - 1
            rs_IMBASINF.Tables("RESULT").Columns(i).ReadOnly = False
        Next i

        If rbPanelAdd_ASS.Checked = True Then
            rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_typ") = "ASS"
            rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmsts") = "INC"
        ElseIf rbPanelAdd_BOM.Checked = True Then
            rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_typ") = "BOM"
            rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmsts") = "CMP"
        Else
            rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_typ") = "REG"
            rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmsts") = "INC"
        End If


        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_ftytmp") = "N"

        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_engdsc") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_chndsc") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_rmk") = ""

        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_imgpth") = ""

        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_venno") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_cusven") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_tradeven") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_examven") = ""

        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_prdtyp") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmnat") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_dsgno") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_material") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_prdsizeTyp") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_prdsizeUnt") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_prdsizeVal") = 0
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_prdgrp") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_prdicon") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_season") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_designer") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_devteam") = ""

        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_lnecde") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_catlvl4") = ""

        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_cosmth") = ""

        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_tirtyp") = "2"

        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_moqunttyp") = "CTN"

        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_curcde") = "USD"

        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_moqctn") = 0
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_moa") = 0
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_qty") = 0

        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_alsitmno") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_alscolcde") = ""

        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_hamusa") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_hameur") = ""

        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_dtyusa") = 0
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_dtyeur") = 0

        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_wastage") = 0

        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_orgitm") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_addreq_forma") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_addreq_ccbi") = ""
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_addreq_ster") = ""

        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*ADD*~"
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_credat") = Date.Today
        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_upddat") = Date.Today

        rs_IMCOLINF.Tables("RESULT").Rows.Clear()
        rs_IMCOLINF.Tables("RESULT").Rows.Add()
        For i = 0 To rs_IMCOLINF.Tables("RESULT").Columns.Count - 1
            rs_IMCOLINF.Tables("RESULT").Columns(i).ReadOnly = False
        Next i
        rs_IMCOLINF.Tables("RESULT").Rows(0).Item("icf_cocde") = ""
        rs_IMCOLINF.Tables("RESULT").Rows(0).Item("icf_itmno") = ""
        rs_IMCOLINF.Tables("RESULT").Rows(0).Item("icf_colcde") = "N/A"
        rs_IMCOLINF.Tables("RESULT").Rows(0).Item("icf_coldsc") = ""
        rs_IMCOLINF.Tables("RESULT").Rows(0).Item("icf_vencol") = "N/A"
        rs_IMCOLINF.Tables("RESULT").Rows(0).Item("icf_creusr") = "~*ADD*~"
        rs_IMCOLINF.Tables("RESULT").Rows(0).Item("icf_ucpcde") = ""
        rs_IMCOLINF.Tables("RESULT").Rows(0).Item("icf_eancde") = ""

        Recordstatus = True

        display_ItemMaster("IM_CREATE")

        If rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_typ") = "BOM" Then

            rs_IMPCKINF.Tables("RESULT").Rows.Add()
            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_cocde") = ""
            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_itmno") = ""
            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_pckseq") = 1

            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_pckunt") = "PC"
            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_conftr") = 1
            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_inrqty") = 1
            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_mtrqty") = 1
            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_cus1no") = ""
            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_cus2no") = ""

            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_qutdat") = ""
            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_cft") = 0
            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_cbm") = 0
            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_grswgt") = 0
            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_netwgt") = 0

            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("inner_in") = "0x0x0"
            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("inner_cm") = "0x0x0"
            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("master_in") = "0x0x0"
            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("master_cm") = "0x0x0"
            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_pckitr") = ""
            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_cusno") = ""
            rs_IMPCKINF.Tables("RESULT").Rows(0).Item("ipi_creusr") = "~*ADD*~"

        End If

        formInit(mode)

        rbPriceView_F.Enabled = True
        rbPriceView_S.Enabled = True
        rbPriceView_P.Enabled = True
        rbPriceView_S.Checked = True

    End Sub

    Private Sub cboPanPVPV_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPanPVPV.KeyUp
        auto_search_combo(cboPanPVPV, e.KeyCode)
    End Sub

    Private Sub cboPanPVPV_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPanPVPV.LostFocus
        If cboPanPVPV.SelectedIndex = -1 Then
            cboPanPVPV.Select()
        End If
    End Sub

    Private Sub txtPanPackCFT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanPackCFT.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim cbm_value As Decimal
            If IsNumeric(txtPanPackCFT.Text) Then
                cbm_value = txtPanPackCFT.Text * CFT_CBM
                txtPanPackCBM.Text = cbm_value
            End If
        End If
    End Sub

    Private Sub txtPanPackCBM_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPanPackCBM.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim cft_value As Decimal
            If IsNumeric(txtPanPackCBM.Text) Then
                cft_value = txtPanPackCBM.Text * CBM_CFT
                txtPanPackCFT.Text = cft_value
            End If
        End If
    End Sub

    Private Sub txtPanPackInnerInchL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanPackInnerInchL.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim innercmL As Decimal
            If IsNumeric(txtPanPackInnerInchL.Text) Then
                innercmL = txtPanPackInnerInchL.Text * In_CM
                txtPanPackInnerCML.Text = innercmL
            End If
        End If
    End Sub

    Private Sub txtPanPackInnerInchW_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPanPackInnerInchW.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim innercmW As Decimal
            If IsNumeric(txtPanPackInnerInchW.Text) Then
                innercmW = txtPanPackInnerInchW.Text * In_CM
                txtPanPackInnerCMW.Text = innercmW
            End If
        End If
    End Sub

    Private Sub txtPanPackInnerInchH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanPackInnerInchH.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim innercmH As Decimal
            If IsNumeric(txtPanPackInnerInchH.Text) Then
                innercmH = txtPanPackInnerInchH.Text * In_CM
                txtPanPackInnerCMH.Text = innercmH
            End If
        End If
    End Sub

    Private Sub txtPanPackMasterInchL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanPackMasterInchL.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim mastercmL As Decimal
            If IsNumeric(txtPanPackMasterInchL.Text) Then
                mastercmL = txtPanPackMasterInchL.Text * In_CM
                txtPanPackMasterCML.Text = mastercmL
                calculate_cbm()
            End If
        End If
    End Sub

    Private Sub txtPanPackMasterInchW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanPackMasterInchW.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim mastercmW As Decimal
            If IsNumeric(txtPanPackMasterInchW.Text) Then
                mastercmW = txtPanPackMasterInchW.Text * In_CM
                txtPanPackMasterCMW.Text = mastercmW
                calculate_cbm()
            End If
        End If
    End Sub

    Private Sub txtPanPackMasterInchH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanPackMasterInchH.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim mastercmH As Decimal
            If IsNumeric(txtPanPackMasterInchH.Text) Then
                mastercmH = txtPanPackMasterInchH.Text * In_CM
                txtPanPackMasterCMH.Text = mastercmH
                calculate_cbm()
            End If
        End If
    End Sub

    Private Sub txtPanPackInnerCML_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanPackInnerCML.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim innerinchL As Decimal
            If IsNumeric(txtPanPackInnerCML.Text) Then
                innerinchL = txtPanPackInnerCML.Text * CM_In
                txtPanPackInnerInchL.Text = innerinchL
            End If
        End If
    End Sub

    Private Sub txtPanPackInnerCMW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanPackInnerCMW.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim innerinchW As Decimal
            If IsNumeric(txtPanPackInnerCMW.Text) Then
                innerinchW = txtPanPackInnerCMW.Text * CM_In
                txtPanPackInnerInchW.Text = innerinchW
            End If
        End If
    End Sub

    Private Sub txtPanPackInnerCMH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanPackInnerCMH.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim innerinchH As Decimal
            If IsNumeric(txtPanPackInnerCMH.Text) Then
                innerinchH = txtPanPackInnerCMH.Text * CM_In
                txtPanPackInnerInchH.Text = innerinchH
            End If
        End If
    End Sub

    Private Sub txtPanPackMasterCML_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanPackMasterCML.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim masterinchL As Decimal
            If IsNumeric(txtPanPackMasterCML.Text) Then
                masterinchL = txtPanPackMasterCML.Text * CM_In
                txtPanPackMasterInchL.Text = masterinchL
                calculate_cbm()
            End If
        End If
    End Sub

    Private Sub txtPanPackMasterCMW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanPackMasterCMW.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim masterinchW As Decimal
            If IsNumeric(txtPanPackMasterCMW.Text) Then
                masterinchW = txtPanPackMasterCMW.Text * CM_In
                txtPanPackMasterInchW.Text = masterinchW
                calculate_cbm()
            End If
        End If
    End Sub

    Private Sub txtPanPackMasterCMH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanPackMasterCMH.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim masterinchH As Decimal
            If IsNumeric(txtPanPackMasterCMH.Text) Then
                masterinchH = txtPanPackMasterCMH.Text * CM_In
                txtPanPackMasterInchH.Text = masterinchH
                calculate_cbm()
            End If
        End If
    End Sub

    Private Sub txtPanCPFtyCst_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanCPFtyCst.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanCPFtyCst.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_pancostprice_keypress = True
    End Sub

    Private Sub calculate_cbm()
        If IsNumeric(txtPanPackMasterCML.Text) And IsNumeric(txtPanPackMasterCMW.Text) And IsNumeric(txtPanPackMasterCMH.Text) Then
            Dim tmp_mtrcmL As Decimal
            Dim tmp_mtrcmW As Decimal
            Dim tmp_mtrcmH As Decimal
            Dim tmp_cbm As Decimal
            Dim tmp_cft As Decimal
            tmp_mtrcmL = txtPanPackMasterCML.Text
            tmp_mtrcmW = txtPanPackMasterCMW.Text
            tmp_mtrcmH = txtPanPackMasterCMH.Text
            tmp_cbm = Decimal.Round(tmp_mtrcmL * tmp_mtrcmW * tmp_mtrcmH / 1000000, 4)
            tmp_cft = Decimal.Round(tmp_cbm * CBM_CFT, 4)
            txtPanPackCBM.Text = tmp_cbm
            txtPanPackCFT.Text = tmp_cft
        End If

    End Sub


    Private Sub txtPanCPFtyCst_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPanCPFtyCst.KeyUp
        'If e.KeyCode <> Keys.Decimal Or txtPanCPFtyCst.Text.IndexOf(".") <> txtPanCPFtyCst.Text.Length - 1 Then
        '    Dim pos As Integer = txtPanCPFtyCst.SelectionStart
        '    If e.KeyCode = Keys.Back And txtPanCPFtyCst.Text.Length > 0 Then
        '        If pos = txtPanCPFtyCst.Text.Length Then
        '            txtPanCPFtyCst.Text = txtPanCPFtyCst.Text.Substring(0, txtPanCPFtyCst.Text.Length - 1)
        '            txtPanCPFtyCst.Select(pos, 0)
        '        ElseIf pos > 0 And pos < txtPanCPFtyCst.Text.Length Then
        '            txtPanCPFtyCst.Text = _
        '            txtPanCPFtyCst.Text.Substring(0, pos - 1) + _
        '            txtPanCPFtyCst.Text.Substring(pos, txtPanCPFtyCst.Text.Length - pos)
        '            txtPanCPFtyCst.Select(pos - 1, 0)
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub txtPanCPFtyCst_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanCPFtyCst.TextChanged
        If flag_pancostprice_keypress = True Then
            flag_pancostprice_keypress = False
            calculate_CostPrice()
        End If
    End Sub

    Private Sub txtPanCPFtyPrc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanCPFtyPrc.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanCPFtyPrc.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_pancostprice_keypress = True
    End Sub

    Private Sub txtPanCPNegCst_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanCPNegCst.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanCPNegCst.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_pancostprice_keypress = True
    End Sub

    Private Sub txtPanCPFtyPrc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPanCPFtyPrc.KeyUp
        'If e.KeyCode <> Keys.Decimal Or txtPanCPFtyPrc.Text.IndexOf(".") <> txtPanCPFtyPrc.Text.Length - 1 Then
        '    Dim pos As Integer = txtPanCPFtyPrc.SelectionStart
        '    If e.KeyCode = Keys.Back And txtPanCPFtyPrc.Text.Length > 0 Then
        '        If pos = txtPanCPFtyPrc.Text.Length Then
        '            txtPanCPFtyPrc.Text = txtPanCPFtyPrc.Text.Substring(0, txtPanCPFtyPrc.Text.Length - 1)
        '            txtPanCPFtyPrc.Select(pos, 0)
        '        ElseIf pos > 0 And pos < txtPanCPFtyPrc.Text.Length Then
        '            txtPanCPFtyPrc.Text = _
        '            txtPanCPFtyPrc.Text.Substring(0, pos - 1) + _
        '            txtPanCPFtyPrc.Text.Substring(pos, txtPanCPFtyPrc.Text.Length - pos)
        '            txtPanCPFtyPrc.Select(pos - 1, 0)
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub txtPanCPFtyPrc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanCPFtyPrc.TextChanged
        If flag_pancostprice_keypress = True Then
            flag_pancostprice_keypress = False
            calculate_CostPrice()
        End If
    End Sub

    Private Sub calculate_CostPrice()
        Dim tmpftycst As Decimal
        Dim tmpftycst_a As Decimal
        Dim tmpftycst_b As Decimal
        Dim tmpftycst_c As Decimal
        Dim tmpftycst_d As Decimal
        Dim tmpftycst_e As Decimal
        Dim tmpftycst_tran As Decimal
        Dim tmpftycst_pack As Decimal

        Dim tmpftyprc As Decimal
        Dim tmpftyprc_a As Decimal
        Dim tmpftyprc_b As Decimal
        Dim tmpftyprc_c As Decimal
        Dim tmpftyprc_d As Decimal
        Dim tmpftyprc_e As Decimal
        Dim tmpftyprc_tran As Decimal
        Dim tmpftyprc_pack As Decimal

        Dim tmpMU As Decimal
        Dim tmpMU_a As Decimal
        Dim tmpMU_b As Decimal
        Dim tmpMU_c As Decimal
        Dim tmpMU_d As Decimal
        Dim tmpMU_e As Decimal
        Dim tmpMU_tran As Decimal
        Dim tmpMU_pack As Decimal



        If IsNumeric(txtPanCPFtyCstA.Text) Then
            tmpftycst_a = txtPanCPFtyCstA.Text
        Else
            tmpftycst_a = 0
        End If

        If IsNumeric(txtPanCPFtyCstB.Text) Then
            tmpftycst_b = txtPanCPFtyCstB.Text
        Else
            tmpftycst_b = 0
        End If

        If IsNumeric(txtPanCPFtyCstC.Text) Then
            tmpftycst_c = txtPanCPFtyCstC.Text
        Else
            tmpftycst_c = 0
        End If

        If IsNumeric(txtPanCPFtyCstD.Text) Then
            tmpftycst_d = txtPanCPFtyCstD.Text
        Else
            tmpftycst_d = 0
        End If

        If IsNumeric(txtPanCPFtyCstE.Text) Then
            tmpftycst_e = txtPanCPFtyCstE.Text
        Else
            tmpftycst_e = 0
        End If

        If IsNumeric(txtPanCPFtyCstTran.Text) Then
            tmpftycst_tran = txtPanCPFtyCstTran.Text
        Else
            tmpftycst_tran = 0
        End If

        If IsNumeric(txtPanCPFtyCstPack.Text) Then
            tmpftycst_pack = txtPanCPFtyCstPack.Text
        Else
            tmpftycst_pack = 0
        End If

        If tmpftycst_a = 0 And tmpftycst_b = 0 And tmpftycst_c = 0 And tmpftycst_d = 0 And tmpftycst_e = 0 And tmpftycst_tran = 0 And tmpftycst_pack = 0 Then
            If IsNumeric(txtPanCPFtyCst.Text) Then
                tmpftycst = txtPanCPFtyCst.Text
            Else
                tmpftycst = 0
            End If
        Else
            'tmpftycst = Decimal.Round(tmpftycst_a, 2) + Decimal.Round(tmpftycst_b, 2) + Decimal.Round(tmpftycst_c, 2) + Decimal.Round(tmpftycst_d, 2) + Decimal.Round(tmpftycst_tran, 2) + Decimal.Round(tmpftycst_pack, 2)
            tmpftycst = Decimal.Round(tmpftycst_a, 4) + Decimal.Round(tmpftycst_b, 4) + Decimal.Round(tmpftycst_c, 4) + Decimal.Round(tmpftycst_d, 4) + Decimal.Round(tmpftycst_e, 4) + Decimal.Round(tmpftycst_tran, 4) + Decimal.Round(tmpftycst_pack, 4)
        End If

        If Not (txtPanCPFtyCst.Text.IndexOf(".") = Len(txtPanCPFtyCst.Text) - 1) Then
            'txtPanCPFtyCst.Text = Decimal.Round(tmpftycst, 2)
            txtPanCPFtyCst.Text = Decimal.Round(tmpftycst, 4)
        End If


        If IsNumeric(txtPanCPFtyPrcA.Text) Then
            tmpftyprc_a = txtPanCPFtyPrcA.Text
        Else
            tmpftyprc_a = 0
        End If
        tmpftyprc_a = Decimal.Round(tmpftyprc_a, 4)

        If IsNumeric(txtPanCPFtyPrcB.Text) Then
            tmpftyprc_b = txtPanCPFtyPrcB.Text
        Else
            tmpftyprc_b = 0
        End If
        tmpftyprc_b = Decimal.Round(tmpftyprc_b, 4)

        If IsNumeric(txtPanCPFtyPrcC.Text) Then
            tmpftyprc_c = txtPanCPFtyPrcC.Text
        Else
            tmpftyprc_c = 0
        End If
        tmpftyprc_c = Decimal.Round(tmpftyprc_c, 4)

        If IsNumeric(txtPanCPFtyPrcD.Text) Then
            tmpftyprc_d = txtPanCPFtyPrcD.Text
        Else
            tmpftyprc_d = 0
        End If
        tmpftyprc_d = Decimal.Round(tmpftyprc_d, 4)

        If IsNumeric(txtPanCPFtyPrcE.Text) Then
            tmpftyprc_e = txtPanCPFtyPrcE.Text
        Else
            tmpftyprc_e = 0
        End If
        tmpftyprc_e = Decimal.Round(tmpftyprc_e, 4)

        If IsNumeric(txtPanCPFtyPrcTran.Text) Then
            tmpftyprc_tran = txtPanCPFtyPrcTran.Text
        Else
            tmpftyprc_tran = 0
        End If
        tmpftyprc_tran = Decimal.Round(tmpftyprc_tran, 4)

        If IsNumeric(txtPanCPFtyPrcPack.Text) Then
            tmpftyprc_pack = txtPanCPFtyPrcPack.Text
        Else
            tmpftyprc_pack = 0
        End If
        tmpftyprc_pack = Decimal.Round(tmpftyprc_pack, 4)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'If tmpftyprc_a = 0 And tmpftyprc_b = 0 And tmpftyprc_c = 0 And tmpftyprc_d = 0 And tmpftyprc_e = 0 And tmpftyprc_tran = 0 And tmpftyprc_pack = 0 Then
        '    If IsNumeric(txtPanCPFtyPrc.Text) Then
        '        tmpftyprc = txtPanCPFtyPrc.Text
        '    Else
        '        tmpftyprc = 0
        '    End If
        'Else
        '    tmpftyprc = Decimal.Round(tmpftyprc_a, 4) + Decimal.Round(tmpftyprc_b, 4) + Decimal.Round(tmpftyprc_c, 4) + Decimal.Round(tmpftyprc_d, 4) + Decimal.Round(tmpftyprc_e, 4) + Decimal.Round(tmpftyprc_tran, 4) + Decimal.Round(tmpftyprc_pack, 4)
        'End If

        If IsNumeric(txtPanCPFtyPrc.Text) Then
            tmpftyprc = txtPanCPFtyPrc.Text
        Else
            tmpftyprc = 0
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'tmpftyprc = Decimal.Round(tmpftyprc, 2)
        tmpftyprc = Decimal.Round(tmpftyprc, 4)

        If Not (txtPanCPFtyPrc.Text.IndexOf(".") = Len(txtPanCPFtyPrc.Text) - 1) Then
            'txtPanCPFtyPrc.Text = Decimal.Round(tmpftyprc, 2)
            txtPanCPFtyPrc.Text = Decimal.Round(tmpftyprc, 4)
        End If

        If tmpftycst_a = 0 Or tmpftyprc_a = 0 Then
            tmpMU_a = 0
        Else
            tmpMU_a = Decimal.Round((tmpftyprc_a - tmpftycst_a) * 100 / tmpftycst_a, 2)
        End If
        txtPanCPMUA.Text = tmpMU_a

        If tmpftycst_b = 0 Or tmpftyprc_b = 0 Then
            tmpMU_b = 0
        Else
            tmpMU_b = Decimal.Round((tmpftyprc_b - tmpftycst_b) * 100 / tmpftycst_b, 2)
        End If
        txtPanCPMUB.Text = tmpMU_b

        If tmpftycst_c = 0 Or tmpftyprc_c = 0 Then
            tmpMU_c = 0
        Else
            tmpMU_c = Decimal.Round((tmpftyprc_c - tmpftycst_c) * 100 / tmpftycst_c, 2)
        End If
        txtPanCPMUC.Text = tmpMU_c

        If tmpftycst_d = 0 Or tmpftyprc_d = 0 Then
            tmpMU_d = 0
        Else
            tmpMU_d = Decimal.Round((tmpftyprc_d - tmpftycst_d) * 100 / tmpftycst_d, 2)
        End If
        txtPanCPMUD.Text = tmpMU_d

        If tmpftycst_e = 0 Or tmpftyprc_e = 0 Then
            tmpMU_e = 0
        Else
            tmpMU_e = Decimal.Round((tmpftyprc_e - tmpftycst_e) * 100 / tmpftycst_e, 2)
        End If
        txtPanCPMUE.Text = tmpMU_e

        If tmpftycst_tran = 0 Or tmpftyprc_tran = 0 Then
            tmpMU_tran = 0
        Else
            tmpMU_tran = Decimal.Round((tmpftyprc_tran - tmpftycst_tran) * 100 / tmpftycst_tran, 2)
        End If
        txtPanCPMUTran.Text = tmpMU_tran

        If tmpftycst_pack = 0 Or tmpftyprc_pack = 0 Then
            tmpMU_pack = 0
        Else
            tmpMU_pack = Decimal.Round((tmpftyprc_pack - tmpftycst_pack) * 100 / tmpftycst_pack, 2)
        End If
        txtPanCPMUPack.Text = tmpMU_pack

        If tmpftycst = 0 Or tmpftyprc = 0 Then
            tmpMU = 0
        Else
            tmpMU = Decimal.Round((tmpftyprc - tmpftycst) * 100 / tmpftycst, 2)
        End If
        txtPanCPMU.Text = tmpMU


        Dim tmpbomcst As Decimal
        Dim tmpttlcst As Decimal

        If IsNumeric(txtPanCPBOMCst.Text) Then
            tmpbomcst = txtPanCPBOMCst.Text
        Else
            tmpbomcst = 0
        End If

        tmpttlcst = tmpftyprc + tmpbomcst
        'txtPanCPTtlCst.Text = Decimal.Round(tmpttlcst, 2)
        txtPanCPTtlCst.Text = Decimal.Round(tmpttlcst, 4)


        Dim tmpfmlopt As String
        If cboPanCPFmlHK.Text <> "" Then
            tmpfmlopt = Split(cboPanCPFmlHK.Text, " - ")(1)
        Else
            tmpfmlopt = ""
        End If

        Dim exchangerate As Decimal
        Dim fcurcde As String
        Dim bcurcde As String
        fcurcde = Mid(lblPanCPFCurcde.Text, 2, 3)
        bcurcde = Mid(lblPanCPBCurcde.Text, 2, 3)
        exchangerate = getexchangerate(fcurcde, bcurcde, "SellRate")

        Dim tmpitmprc As Decimal
        If tmpfmlopt <> "" Then
            tmpitmprc = calculate_fmlopt(tmpfmlopt, tmpttlcst) * exchangerate
        End If

        txtPanCPItmPrc.Text = Decimal.Round(tmpitmprc, 4)


        Dim tmpbomprc As Decimal
        Dim tmpbasprc As Decimal
        If IsNumeric(txtPanCPBOMPrc.Text) Then
            tmpbomprc = txtPanCPBOMPrc.Text
        Else
            tmpbomprc = 0.0
        End If
        'tmpbomprc = txtPanCPBOMPrc.Text
        tmpbasprc = Decimal.Round(tmpitmprc, 4) + Decimal.Round(tmpbomprc, 4)

        txtPanCPBasicPrc.Text = Decimal.Round(tmpbasprc, 4)

    End Sub


    Private Function calculate_fmlopt(ByVal fmlopt As String, ByVal value As Decimal) As Decimal
        Dim fml As String
        Dim opt As String
        Dim i As Integer
        Dim charstr As String
        Dim finalvalue As Decimal

        fml = ""
        opt = ""
        charstr = ""
        finalvalue = value

        For i = 0 To Len(fmlopt) - 1
            charstr = fmlopt.Substring(i, 1)
            If charstr = "*" Or charstr = "/" Then
                If fml = "" Then
                    fml = charstr
                Else
                    If IsNumeric(opt) Then
                        If charstr = "*" Then
                            finalvalue = finalvalue * opt
                        Else
                            finalvalue = finalvalue / opt
                        End If
                    Else
                        calculate_fmlopt = 0
                        Exit Function
                    End If
                End If
            Else
                opt = opt & charstr
            End If
        Next i

        If IsNumeric(opt) Then
            If fml = "*" Then
                finalvalue = finalvalue * opt
            Else
                finalvalue = finalvalue / opt
            End If
        Else
            calculate_fmlopt = 0
            Exit Function
        End If

        calculate_fmlopt = finalvalue

    End Function

    Private Sub cboPanCPCus1no_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPanCPCus1no.KeyUp
        auto_search_combo(cboPanCPCus1no, e.KeyCode)
    End Sub

    Private Sub cboPanCPCus1no_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPanCPCus1no.LostFocus
        If cboPanCPCus1no.Text <> "" Then
            format_cboPanCus2no(Split(cboPanCPCus1no.Text, " - ")(0))
        End If
    End Sub

    Private Sub cboPanPackUM_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPanPackUM.KeyUp
        auto_search_combo(cboPanPackUM, e.KeyCode)
    End Sub

    Private Function getexchangerate(ByVal fmcur As String, ByVal tocur As String, ByVal rate As String) As Decimal
        If fmcur = tocur Then
            getexchangerate = 1.0
            Exit Function
        End If


        Dim dr() As DataRow = rs_SYCUREX.Tables("RESULT").Select("yce_frmcur = '" & fmcur & "' and yce_tocur = '" & tocur & "'")

        If dr.Length = 1 Then
            If rate = "BuyRate" Then
                getexchangerate = dr(0).Item("yce_buyrat")
            Else
                getexchangerate = dr(0).Item("yce_selrat")
            End If
        Else
            getexchangerate = 0.0
        End If

    End Function

    Private Function getdefaultCurrency(ByVal vendor As String) As String
        Dim dr() As DataRow = rs_VNBASINF.Tables("RESULT").Select("vbi_venno = '" & vendor & "'")

        If dr.Length = 1 Then
            getdefaultCurrency = dr(0).Item("vbi_curcde")
        Else
            If vendor >= "0001" And vendor <= "9999" Then
                getdefaultCurrency = "USD"
            Else
                getdefaultCurrency = "HKD"
            End If
        End If

    End Function


    Private Function getconftr(ByVal um As String) As Integer
        getconftr = 0
        Dim i As Integer
        For i = 0 To rs_SYCONFTR.Tables("RESULT").Rows.Count - 1
            If um = rs_SYCONFTR.Tables("RESULT").Rows(i).Item("ycf_code1") Then
                getconftr = rs_SYCONFTR.Tables("RESULT").Rows(i).Item("ycf_value")
                Exit Function
            End If
        Next i
    End Function

    Private Sub getformula(ByVal vencde As String, ByVal ventyp As String, ByVal cus1no As String, ByVal cus2no As String, ByVal catlvl4 As String, ByVal caltar As String)
        tmp_calfml_hk.Items.Clear()
        '        tmp_calfml_hk.Items.Add("")
        Dim i As Integer

        '1. Vendor + Customer + Category
        If tmp_calfml_hk.Items.Count = 0 Then
            Dim dr11() As DataRow = rs_IMCALFML_ALL.Tables("RESULT").Select("icf_vencde = '" & vencde & "' and icf_cus1no = '" & cus1no & "' and icf_cus2no = '" & cus2no & "' and icf_catlvl4 = '" & catlvl4 & "' and icf_caltar = '" & caltar & "'")
            For i = 0 To dr11.Length - 1
                tmp_calfml_hk.Items.Add(dr11(i).Item("icf_fml_hk").ToString & " - " & dr11(i).Item("icf_fml_hk_dsc").ToString)
                If dr11(i).Item("icf_def") = "Y" Then
                    tmp_calfml_hk.Text = dr11(i).Item("icf_fml_hk").ToString & " - " & dr11(i).Item("icf_fml_hk_dsc").ToString
                End If
            Next i
        End If

        If tmp_calfml_hk.Items.Count = 0 Then
            Dim dr12() As DataRow = rs_IMCALFML_ALL.Tables("RESULT").Select("icf_vencde = '" & vencde & "' and icf_cus1no = '" & cus1no & "' and icf_cus2no = '' and icf_catlvl4 = '" & catlvl4 & "' and icf_caltar = '" & caltar & "'")
            For i = 0 To dr12.Length - 1
                tmp_calfml_hk.Items.Add(dr12(i).Item("icf_fml_hk").ToString & " - " & dr12(i).Item("icf_fml_hk_dsc").ToString)
                If dr12(i).Item("icf_def") = "Y" Then
                    tmp_calfml_hk.Text = dr12(i).Item("icf_fml_hk").ToString & " - " & dr12(i).Item("icf_fml_hk_dsc").ToString
                End If
            Next i
        End If

        If tmp_calfml_hk.Items.Count = 0 Then
            Dim dr13() As DataRow = rs_IMCALFML_ALL.Tables("RESULT").Select("icf_vencde = '" & ventyp & "' and icf_cus1no = '" & cus1no & "' and icf_cus2no = '" & cus2no & "' and icf_catlvl4 = '" & catlvl4 & "' and icf_caltar = '" & caltar & "'")
            For i = 0 To dr13.Length - 1
                tmp_calfml_hk.Items.Add(dr13(i).Item("icf_fml_hk").ToString & " - " & dr13(i).Item("icf_fml_hk_dsc").ToString)
                If dr13(i).Item("icf_def") = "Y" Then
                    tmp_calfml_hk.Text = dr13(i).Item("icf_fml_hk").ToString & " - " & dr13(i).Item("icf_fml_hk_dsc").ToString
                End If
            Next i
        End If

        If tmp_calfml_hk.Items.Count = 0 Then
            Dim dr14() As DataRow = rs_IMCALFML_ALL.Tables("RESULT").Select("icf_vencde = '" & ventyp & "' and icf_cus1no = '" & cus1no & "' and icf_cus2no = '' and icf_catlvl4 = '" & catlvl4 & "' and icf_caltar = '" & caltar & "'")
            For i = 0 To dr14.Length - 1
                tmp_calfml_hk.Items.Add(dr14(i).Item("icf_fml_hk").ToString & " - " & dr14(i).Item("icf_fml_hk_dsc").ToString)
                If dr14(i).Item("icf_def") = "Y" Then
                    tmp_calfml_hk.Text = dr14(i).Item("icf_fml_hk").ToString & " - " & dr14(i).Item("icf_fml_hk_dsc").ToString
                End If
            Next i
        End If

        '2. Vendor + Category
        If tmp_calfml_hk.Items.Count = 0 Then
            Dim dr21() As DataRow = rs_IMCALFML_ALL.Tables("RESULT").Select("icf_vencde = '" & vencde & "' and icf_cus1no = '' and icf_cus2no = '' and icf_catlvl4 = '" & catlvl4 & "' and icf_caltar = '" & caltar & "'")
            For i = 0 To dr21.Length - 1
                tmp_calfml_hk.Items.Add(dr21(i).Item("icf_fml_hk").ToString & " - " & dr21(i).Item("icf_fml_hk_dsc").ToString)
                If dr21(i).Item("icf_def") = "Y" Then
                    tmp_calfml_hk.Text = dr21(i).Item("icf_fml_hk").ToString & " - " & dr21(i).Item("icf_fml_hk_dsc").ToString
                End If
            Next i
        End If

        If tmp_calfml_hk.Items.Count = 0 Then
            Dim dr22() As DataRow = rs_IMCALFML_ALL.Tables("RESULT").Select("icf_vencde = '" & ventyp & "' and icf_cus1no = '' and icf_cus2no = '' and icf_catlvl4 = '" & catlvl4 & "' and icf_caltar = '" & caltar & "'")
            For i = 0 To dr22.Length - 1
                tmp_calfml_hk.Items.Add(dr22(i).Item("icf_fml_hk").ToString & " - " & dr22(i).Item("icf_fml_hk_dsc").ToString)
                If dr22(i).Item("icf_def") = "Y" Then
                    tmp_calfml_hk.Text = dr22(i).Item("icf_fml_hk").ToString & " - " & dr22(i).Item("icf_fml_hk_dsc").ToString
                End If
            Next i
        End If

        '3. Vendor + Customer
        If tmp_calfml_hk.Items.Count = 0 Then
            Dim dr31() As DataRow = rs_IMCALFML_ALL.Tables("RESULT").Select("icf_vencde = '" & vencde & "' and icf_cus1no = '" & cus1no & "' and icf_cus2no = '" & cus2no & "' and icf_catlvl4 = '' and icf_caltar = '" & caltar & "'")
            For i = 0 To dr31.Length - 1
                tmp_calfml_hk.Items.Add(dr31(i).Item("icf_fml_hk").ToString & " - " & dr31(i).Item("icf_fml_hk_dsc").ToString)
                If dr31(i).Item("icf_def") = "Y" Then
                    tmp_calfml_hk.Text = dr31(i).Item("icf_fml_hk").ToString & " - " & dr31(i).Item("icf_fml_hk_dsc").ToString
                End If
            Next i
        End If

        If tmp_calfml_hk.Items.Count = 0 Then
            Dim dr32() As DataRow = rs_IMCALFML_ALL.Tables("RESULT").Select("icf_vencde = '" & ventyp & "' and icf_cus1no = '" & cus1no & "' and icf_cus2no = '" & cus2no & "' and icf_catlvl4 = '' and icf_caltar = '" & caltar & "'")
            For i = 0 To dr32.Length - 1
                tmp_calfml_hk.Items.Add(dr32(i).Item("icf_fml_hk").ToString & " - " & dr32(i).Item("icf_fml_hk_dsc").ToString)
                If dr32(i).Item("icf_def") = "Y" Then
                    tmp_calfml_hk.Text = dr32(i).Item("icf_fml_hk").ToString & " - " & dr32(i).Item("icf_fml_hk_dsc").ToString
                End If
            Next i
        End If

        If tmp_calfml_hk.Items.Count = 0 Then
            Dim dr33() As DataRow = rs_IMCALFML_ALL.Tables("RESULT").Select("icf_vencde = '" & vencde & "' and icf_cus1no = '" & cus1no & "' and icf_cus2no = '' and icf_catlvl4 = '' and icf_caltar = '" & caltar & "'")
            For i = 0 To dr33.Length - 1
                tmp_calfml_hk.Items.Add(dr33(i).Item("icf_fml_hk").ToString & " - " & dr33(i).Item("icf_fml_hk_dsc").ToString)
                If dr33(i).Item("icf_def") = "Y" Then
                    tmp_calfml_hk.Text = dr33(i).Item("icf_fml_hk").ToString & " - " & dr33(i).Item("icf_fml_hk_dsc").ToString
                End If
            Next i
        End If

        If tmp_calfml_hk.Items.Count = 0 Then
            Dim dr34() As DataRow = rs_IMCALFML_ALL.Tables("RESULT").Select("icf_vencde = '" & ventyp & "' and icf_cus1no = '" & cus1no & "' and icf_cus2no = '' and icf_catlvl4 = '' and icf_caltar = '" & caltar & "'")
            For i = 0 To dr34.Length - 1
                tmp_calfml_hk.Items.Add(dr34(i).Item("icf_fml_hk").ToString & " - " & dr34(i).Item("icf_fml_hk_dsc").ToString)
                If dr34(i).Item("icf_def") = "Y" Then
                    tmp_calfml_hk.Text = dr34(i).Item("icf_fml_hk").ToString & " - " & dr34(i).Item("icf_fml_hk_dsc").ToString
                End If
            Next i
        End If

        '4. Vendor
        If tmp_calfml_hk.Items.Count = 0 Then
            Dim dr41() As DataRow = rs_IMCALFML_ALL.Tables("RESULT").Select("icf_vencde = '" & vencde & "' and icf_cus1no = '' and icf_cus2no = '' and icf_catlvl4 = '' and icf_caltar = '" & caltar & "'")
            For i = 0 To dr41.Length - 1
                tmp_calfml_hk.Items.Add(dr41(i).Item("icf_fml_hk").ToString & " - " & dr41(i).Item("icf_fml_hk_dsc").ToString)
                If dr41(i).Item("icf_def") = "Y" Then
                    tmp_calfml_hk.Text = dr41(i).Item("icf_fml_hk").ToString & " - " & dr41(i).Item("icf_fml_hk_dsc").ToString
                End If
            Next i
        End If

        If tmp_calfml_hk.Items.Count = 0 Then
            Dim dr42() As DataRow = rs_IMCALFML_ALL.Tables("RESULT").Select("icf_vencde = '" & ventyp & "' and icf_cus1no = '' and icf_cus2no = '' and icf_catlvl4 = '' and icf_caltar = '" & caltar & "'")
            For i = 0 To dr42.Length - 1
                tmp_calfml_hk.Items.Add(dr42(i).Item("icf_fml_hk").ToString & " - " & dr42(i).Item("icf_fml_hk_dsc").ToString)
                If dr42(i).Item("icf_def") = "Y" Then
                    tmp_calfml_hk.Text = dr42(i).Item("icf_fml_hk").ToString & " - " & dr42(i).Item("icf_fml_hk_dsc").ToString
                End If
            Next i
        End If
    End Sub

    Private Sub txtPanCPNegPrc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanCPNegPrc.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanCPNegPrc.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_pancostprice_keypress = True
    End Sub


    Private Sub txtPanCPNegPrc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanCPNegPrc.TextChanged

    End Sub

    Private Sub txtPanCPFtyCstA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanCPFtyCstA.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanCPFtyCstA.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_pancostprice_keypress = True
    End Sub

    Private Sub txtPanCPFtyCstA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanCPFtyCstA.TextChanged
        If flag_pancostprice_keypress = True Then
            flag_pancostprice_keypress = False
            calculate_CostPrice()
        End If
    End Sub

    Private Sub txtPanCPFtyCstB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanCPFtyCstB.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanCPFtyCstB.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_pancostprice_keypress = True
    End Sub

    Private Sub txtPanCPFtyCstB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanCPFtyCstB.TextChanged
        If flag_pancostprice_keypress = True Then
            flag_pancostprice_keypress = False
            calculate_CostPrice()
        End If
    End Sub

    Private Sub txtPanCPFtyCstC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanCPFtyCstC.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanCPFtyCstC.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_pancostprice_keypress = True
    End Sub

    Private Sub txtPanCPFtyCstC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanCPFtyCstC.TextChanged
        If flag_pancostprice_keypress = True Then
            flag_pancostprice_keypress = False
            calculate_CostPrice()
        End If
    End Sub

    Private Sub txtPanCPFtyCstD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanCPFtyCstD.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanCPFtyCstD.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_pancostprice_keypress = True
    End Sub

    Private Sub txtPanCPFtyCstD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanCPFtyCstD.TextChanged
        If flag_pancostprice_keypress = True Then
            flag_pancostprice_keypress = False
            calculate_CostPrice()
        End If
    End Sub

    Private Sub txtPanCPFtyCstTran_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanCPFtyCstTran.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanCPFtyCstTran.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_pancostprice_keypress = True
    End Sub

    Private Sub txtPanCPFtyCstTran_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanCPFtyCstTran.TextChanged
        If flag_pancostprice_keypress = True Then
            flag_pancostprice_keypress = False
            calculate_CostPrice()
        End If
    End Sub

    Private Sub txtPanCPFtyCstPack_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanCPFtyCstPack.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanCPFtyCstPack.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_pancostprice_keypress = True
    End Sub

    Private Sub txtPanCPFtyCstPack_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanCPFtyCstPack.TextChanged
        If flag_pancostprice_keypress = True Then
            flag_pancostprice_keypress = False
            calculate_CostPrice()
        End If
    End Sub

    Private Sub txtPanCPFtyPrcA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanCPFtyPrcA.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanCPFtyPrcA.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_pancostprice_keypress = True
    End Sub

    Private Sub txtPanCPFtyPrcA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanCPFtyPrcA.TextChanged
        If flag_pancostprice_keypress = True Then
            flag_pancostprice_keypress = False
            calculate_CostPrice()
        End If
    End Sub

    Private Sub txtPanCPFtyPrcB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanCPFtyPrcB.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanCPFtyPrcB.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_pancostprice_keypress = True
    End Sub

    Private Sub txtPanCPFtyPrcB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanCPFtyPrcB.TextChanged
        If flag_pancostprice_keypress = True Then
            flag_pancostprice_keypress = False
            calculate_CostPrice()
        End If
    End Sub

    Private Sub txtPanCPFtyPrcC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanCPFtyPrcC.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanCPFtyPrcC.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_pancostprice_keypress = True
    End Sub

    Private Sub txtPanCPFtyPrcC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanCPFtyPrcC.TextChanged
        If flag_pancostprice_keypress = True Then
            flag_pancostprice_keypress = False
            calculate_CostPrice()
        End If
    End Sub

    Private Sub txtPanCPFtyPrcD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanCPFtyPrcD.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanCPFtyPrcD.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_pancostprice_keypress = True
    End Sub

    Private Sub txtPanCPFtyPrcD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanCPFtyPrcD.TextChanged
        If flag_pancostprice_keypress = True Then
            flag_pancostprice_keypress = False
            calculate_CostPrice()
        End If
    End Sub

    Private Sub txtPanCPFtyPrcTran_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanCPFtyPrcTran.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanCPFtyPrcTran.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_pancostprice_keypress = True
    End Sub

    Private Sub txtPanCPFtyPrcTran_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanCPFtyPrcTran.TextChanged
        If flag_pancostprice_keypress = True Then
            flag_pancostprice_keypress = False
            calculate_CostPrice()
        End If
    End Sub

    Private Sub txtPanCPFtyPrcPack_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanCPFtyPrcPack.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanCPFtyPrcPack.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_pancostprice_keypress = True
    End Sub

    Private Sub txtPanCPFtyPrcPack_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanCPFtyPrcPack.TextChanged
        If flag_pancostprice_keypress = True Then
            flag_pancostprice_keypress = False
            calculate_CostPrice()
        End If
    End Sub

    Private Sub cboPanCPFmlHK_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPanCPFmlHK.SelectedIndexChanged
        If flag_pancostprice_keypress = True Then
            flag_pancostprice_keypress = False
            calculate_CostPrice()
        End If
    End Sub

    Private Sub cboPanCPFmlHK_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPanCPFmlHK.TextChanged
        flag_pancostprice_keypress = True
    End Sub

    Private Sub dgOEMCustomer_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOEMCustomer.CellValueChanged
        If flag_dgOEMCustomer_mouseselect = True Then
            flag_dgOEMCustomer_mouseselect = False
            If dgOEMCustomer.CurrentCell.ColumnIndex = 2 Then
                If dgOEMCustomer.RowCount > 1 Then
                    Dim i As Integer
                    For i = 0 To dgOEMCustomer.RowCount - 2
                        If Split(dgOEMCustomer.CurrentCell.Value, " - ")(0) = Split(dgOEMCustomer.Item(2, i).Value, " - ")(0) Then
                            MsgBox("OEM Customer already exist!")
                            dgOEMCustomer.CurrentCell.Value = ""
                        End If
                    Next i
                End If
            End If
        End If
    End Sub

    Private Sub TabPageMain_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabPageMain.KeyUp
        If (e.Alt) Then
            If e.KeyCode = Keys.D1 Then
                Me.TabPageMain.SelectedIndex = 0
            ElseIf e.KeyCode = Keys.D2 Then
                Me.TabPageMain.SelectedIndex = 1
            ElseIf e.KeyCode = Keys.D3 Then
                Me.TabPageMain.SelectedIndex = 2
            ElseIf e.KeyCode = Keys.D4 Then
                Me.TabPageMain.SelectedIndex = 3
            ElseIf e.KeyCode = Keys.D5 Then
                Me.TabPageMain.SelectedIndex = 4
            ElseIf e.KeyCode = Keys.D6 Then
                Me.TabPageMain.SelectedIndex = 5
            End If
        End If
    End Sub

    Private Sub lbBOMColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbBOMColor.SelectedIndexChanged
        lbBOMColor.Visible = False
        lbBOMColor.Enabled = False

        If dgBOMASS.RowCount > 0 Then
            If dgBOMASS.CurrentCell.ColumnIndex = 6 Then
                Dim tmpbomitm As String
                Dim tmpcolcde As String

                tmpbomitm = dgBOMASS.Item(3, dgBOMASS.CurrentCell.RowIndex).Value

                tmpcolcde = lbBOMColor.SelectedItem

                If tmpbomitm = "" Or tmpcolcde = "" Then
                    Exit Sub
                End If

                Dim i As Integer
                Dim updrow As Integer
                i = -1
                For i = 0 To rs_IMBOMASS.Tables("RESULT").Rows.Count - 1
                    If rs_IMBOMASS.Tables("RESULT").Rows(i).Item("iba_assitm") = tmpbomitm Then
                        updrow = i
                        Exit For
                    End If
                Next i

                Dim dr() As DataRow = rs_IMCOLINF_BOMASS.Tables("RESULT").Select("icf_colcde = '" & tmpcolcde & "'")
                Dim dr2() As DataRow = rs_IMPCKINF_BOMASS.Tables("RESULT").Select("ipi_itmno = '" & tmpbomitm & "'")

                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_colcde") = ""
                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("ibi_engdsc") = ""
                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("vbi_vensna") = ""
                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_pckunt") = ""
                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_untcst") = 0.0
                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_curcde") = ""
                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_bombasprc") = 0.0
                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_fcurcde") = ""
                rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_ftycst") = 0.0

                If dr.Length = 1 And dr2.Length = 1 And i <> -1 Then
                    rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_colcde") = lbBOMColor.SelectedItem
                    rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("ibi_engdsc") = dr(0).Item("ibi_engdsc")
                    rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("vbi_vensna") = dr(0).Item("vbi_vensna")
                    rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_pckunt") = dr2(0).Item("ipi_pckunt")

                    gspStr = "sp_select_IMPRCINF_BOMASS '','" & tmpbomitm & "','" & dr2(0).Item("ipi_pckunt") & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_IMPRCINF_BOMASS, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading dgBOMASS_CellValueChanged sp_select_IMPRCINF_IMBOMASS :" & rtnStr)
                        Exit Sub
                    End If

                    If rs_IMPRCINF_BOMASS.Tables("RESULT").Rows.Count = 1 Then

                        rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_curcde") = rs_IMPRCINF_BOMASS.Tables("RESULT").Rows(0).Item("imu_curcde")
                        rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_fcurcde") = rs_IMPRCINF_BOMASS.Tables("RESULT").Rows(0).Item("imu_bcurcde")

                        If Split(cboItmVenTyp.Text, " - ")(0) = "EXT" Then
                            rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_untcst") = rs_IMPRCINF_BOMASS.Tables("RESULT").Rows(0).Item("imu_ttlcst")
                            rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_bombasprc") = rs_IMPRCINF_BOMASS.Tables("RESULT").Rows(0).Item("imu_ttlcst")
                            rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_ftycst") = rs_IMPRCINF_BOMASS.Tables("RESULT").Rows(0).Item("imu_ftycst")
                        Else
                            rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_untcst") = 0.0
                            rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_bombasprc") = 0.0
                            rs_IMBOMASS.Tables("RESULT").Rows(updrow).Item("iba_ftycst") = 0.0
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtCstRmk_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCstRmk.KeyPress
        If mode = "UPDATE" Or mode = "ADD" Then
            Recordstatus = True
            If rs_IMCSTINF.Tables("RESULT").Rows.Count = 0 Then
                Dim i As Integer
                For i = 0 To rs_IMCSTINF.Tables("RESULT").Columns.Count - 1
                    rs_IMCSTINF.Tables("RESULT").Columns(i).ReadOnly = False
                Next i

                rs_IMCSTINF.Tables("RESULT").Rows.Add()
                rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_creusr") = "~*ADD*~"
                rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_cocde") = ""
                rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_itmno") = txtItmNo.Text
                rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_cstrmk") = ""
                rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_expdat") = "1900-01-01"
            Else
                If rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_creusr") <> "~*ADD*~" Then
                    rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_creusr") = "~*UPD*~"
                End If
            End If
        End If
    End Sub

    Private Sub dgBOMASS_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgBOMASS.CellValidating
        Dim row As DataGridViewRow = dgBOMASS.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then
            If e.ColumnIndex = dgBOMASS_iba_assitm Then
                If Split(cboItmTyp.Text, " - ")(0) = "ASS" And Split(cboItmVenTyp.Text, " - ")(0) = "EXT" Then
                    Exit Sub
                End If

                For Each drr As DataGridViewRow In dgBOMASS.Rows
                    If drr.Index <> e.RowIndex Then
                        If drr.Cells("iba_assitm").Value.ToString.ToUpper = strNewVal.ToUpper And drr.Cells(dgBOMASS_iba_cocde).Value.ToString <> "Y" Then
                            MsgBox("Duplicated Assortment/BOM item!")
                            e.Cancel = True
                            Exit For
                        End If
                    End If
                Next
            ElseIf e.ColumnIndex = dgBOMASS_iba_colcde Then
                If Not (Split(cboItmTyp.Text, " - ")(0) = "ASS" And Split(cboItmVenTyp.Text, " - ")(0) = "EXT") Then
                    Exit Sub
                End If
                Dim tmp_assitm As String
                Dim tmp_asscol As String

                tmp_assitm = dgBOMASS.Item(dgBOMASS_iba_assitm, dgBOMASS.CurrentCell.RowIndex).Value
                tmp_asscol = strNewVal

                For Each drr As DataGridViewRow In dgBOMASS.Rows
                    If drr.Index <> e.RowIndex Then
                        If drr.Cells("iba_assitm").Value.ToString.ToUpper = tmp_assitm.ToUpper And drr.Cells("iba_colcde").Value.ToString.ToUpper = tmp_asscol.ToUpper Then
                            MsgBox("Duplicated Assortment And Color item!")
                            e.Cancel = True
                            Exit For
                        End If
                        If drr.Cells("iba_assitm").Value.ToString.ToUpper = tmp_assitm.ToUpper And drr.Cells("iba_orgcolcde").Value.ToString.ToUpper = tmp_asscol.ToUpper Then
                            MsgBox("Duplicated Assortment And Color item with unsaved item!")
                            e.Cancel = True
                            Exit For
                        End If
                    End If
                Next
            End If

        End If
    End Sub


    Private Sub cbDiscontinue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbDiscontinue.Click
        If cbDiscontinue.Checked = True Then
            If MsgBox("Are you sure to discontinue this item?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                cbDiscontinue.Checked = True
                display_combo("DIS", cboStatus)
                rs_IMBASINF.Tables("RESULT").Columns("ibi_creusr").ReadOnly = False
                rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                Recordstatus = True
                mode = "READ"
                formInit(mode)
                display_dgColor("IM")
                display_dgPacking("IM")
                display_dgBOMASS("IM", Split(cboItmTyp.Text, " - ")(0))
                display_dgOEMCustomer("IM")
                display_dgCusStyle("IM")
                display_dgCostPrice("IM", "PriceOnly")
                display_dgExclCustomer("IM")
                display_dgMatBreakdown("IM")
                display_dgPV("IM")
                display_dgTempItem()
                cmdSave.Enabled = True
            Else
                cbDiscontinue.Checked = False
            End If
        Else
            If MsgBox("Are you sure to activate this item?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                cbDiscontinue.Checked = False
                display_combo("CMP", cboStatus)
                rs_IMBASINF.Tables("RESULT").Columns("ibi_creusr").ReadOnly = False
                rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                Recordstatus = True
                mode = "UPDATE"
                formInit(mode)
            Else
                cbDiscontinue.Checked = True
            End If
        End If

    End Sub

    Private Sub pbImage_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbImage.DoubleClick
        If rs_IMBASINF.Tables.Count = 0 Then
            Exit Sub
        End If
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        Dim sImagePath As String
        sImagePath = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_imgpth")
        If sImagePath = "" Then
            Dim sDirectory As String

            Dim drIMBASINF() As DataRow = rs_IMBASINF.Tables("RESULT").Select("ibi_itmno = '" & Trim(txtItmNo.Text) & "'")
            If drIMBASINF.Length > 0 Then
                Dim drVNBASINF() As DataRow = rs_VNBASINF.Tables("RESULT").Select("vbi_venno = '" & drIMBASINF(0).Item("ibi_venno") & "'")

                If drVNBASINF.Length > 0 Then
                    If drVNBASINF(0).Item("vbi_ventyp").ToString = "I" Or drVNBASINF(0).Item("vbi_ventyp").ToString = "J" Then
                        ' Internal and Joint Venture
                        sDirectory = "\\Uchkimgsrv\guest-share\ucppc\itemimg\" & revisedItmno(drIMBASINF(0).Item("ibi_lnecde").ToString)
                        sImagePath = sDirectory & "\" & revisedItmno(Trim(txtItmNo.Text)) & ".JPG"
                    Else
                        ' External
                        Dim drIMVENINF() As DataRow = rs_IMVENINF.Tables("RESULT").Select("ivi_itmno = '" & Trim(txtItmNo.Text) & "' and ivi_def = 'Y'")
                        sDirectory = "\\Uchkimgsrv\guest-share\ucp\itemimg\" & revisedItmno(drIMVENINF(0).Item("ivi_venno").ToString)
                        sImagePath = sDirectory & "\" & revisedItmno(drIMVENINF(0).Item("ivi_venitm")) & "_" & drIMVENINF(0).Item("ivi_venno") & ".JPG"
                    End If
                End If
            End If
        End If
        'For the programmers IN THE FUTURE who are fixing the frmImage problem in QUM01, PGM01, PGM02, IMG01 and PGM02:
        'How to break the photo form:
        '1:open the photo
        '2:ZoomIn the photo until a scroll was shown 
        '3:move the scroll bar
        '4:close the photo form and re-open again
        '5:The photo form breaks
        '
        'Reason of the bug:
        'The problem of the wrong location of imagebox(pbImage) is caused by the coding style.
        'In the past, the code in here( and the code you are going to fix) control the frmImage form class DIRECTLY.
        'A better coding style (and the method to fix ) is create a object with frmImage class but not control the class directly.
        '
        'More detail about this bug:
        'Firstly, when user moves the scoll bar of panel, the true opertion is the panel move all objects
        'in the panel on the opposite direction
        'Then the image box location of the form CLASS is changed
        'So after closing the form, the iamge box position is still moved.
        'Finnally, when the user open the form again, the image box posiotion is wrong.
        Dim frnamImage As New frmImage
        Try
            frnamImage.pbImage.Load(sImagePath)
        Catch ex As Exception
            'This try catch is used for preventing 4 kinds of exception caused by corrupted image path/
            'network problem. So there is no code in this exception catch
            '
            'For more reference about those 4 kinds of exception, 
            'please read https://msdn.microsoft.com/en-us/library/f6ak7was(v=vs.110).aspx
            'or search 'PictureBox.Load'
        End Try
        frnamImage.ShowDialog()
    End Sub

    Private Sub pbImage2_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbImage2.DoubleClick
        If rs_IMBASINF.Tables.Count = 0 Then
            Exit Sub
        End If
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        Dim sImagePath As String
        sImagePath = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_imgpth")
        If sImagePath = "" Then
            Dim sDirectory As String

            Dim drIMBASINF() As DataRow = rs_IMBASINF.Tables("RESULT").Select("ibi_itmno = '" & Trim(txtItmNo.Text) & "'")
            If drIMBASINF.Length > 0 Then
                Dim drVNBASINF() As DataRow = rs_VNBASINF.Tables("RESULT").Select("vbi_venno = '" & drIMBASINF(0).Item("ibi_venno") & "'")

                If drVNBASINF.Length > 0 Then
                    If drVNBASINF(0).Item("vbi_ventyp").ToString = "I" Or drVNBASINF(0).Item("vbi_ventyp").ToString = "J" Then
                        ' Internal and Joint Venture
                        sDirectory = "\\Uchkimgsrv\guest-share\ucppc\itemimg\" & revisedItmno(drIMBASINF(0).Item("ibi_lnecde").ToString)
                        sImagePath = sDirectory & "\" & revisedItmno(Trim(txtItmNo.Text)) & ".JPG"
                    Else
                        ' External
                        Dim drIMVENINF() As DataRow = rs_IMVENINF.Tables("RESULT").Select("ivi_itmno = '" & Trim(txtItmNo.Text) & "' and ivi_def = 'Y'")
                        sDirectory = "\\Uchkimgsrv\guest-share\ucp\itemimg\" & revisedItmno(drIMVENINF(0).Item("ivi_venno").ToString)
                        sImagePath = sDirectory & "\" & revisedItmno(drIMVENINF(0).Item("ivi_venitm")) & "_" & drIMVENINF(0).Item("ivi_venno") & ".JPG"
                    End If
                End If
            End If
        End If


        'If rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_imgpth") = "" Then
        '    Exit Sub
        'End If

        Try
            'frmImage.pbImage.Load(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_imgpth"))
            frmImage.pbImage.Load(sImagePath)
        Catch ex As Exception

        End Try


        frmImage.ShowDialog()
    End Sub

    Private Sub cmdCombineImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCombineImage.Click
        frmCombineImage.txtItmNo.Text = Me.txtItmNo.Text
        frmCombineImage.ShowDialog()
    End Sub


    Private Sub dgExclCustomer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgExclCustomer.CellContentClick

    End Sub

    Private Sub dgExclCustomer_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgExclCustomer.CellValidating
        Dim row As DataGridViewRow = dgExclCustomer.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then
            If e.ColumnIndex = dgExclCustomer_ici_cusno Then
                For Each drr As DataGridViewRow In dgExclCustomer.Rows
                    If drr.Index <> e.RowIndex Then
                        If Split(drr.Cells("ici_cusno").Value.ToString.ToUpper, " - ")(0) = Split(strNewVal.ToUpper, " - ")(0) Then
                            MsgBox("Duplicated Customer!")
                            e.Cancel = True
                            Exit For
                        End If
                    End If
                Next
            End If

        End If
    End Sub

    Private Sub dgExclCustomer_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgExclCustomer.CellDoubleClick
        If dgExclCustomer.RowCount = 0 Then
            Exit Sub
        End If

        Dim iCol As Integer = dgExclCustomer.CurrentCell.ColumnIndex
        Dim iRow As Integer = dgExclCustomer.CurrentCell.RowIndex

        Dim curvalue As String
        curvalue = dgExclCustomer.CurrentCell.Value

        If dgExclCustomer.CurrentCell.ColumnIndex = dgExclCustomer_ici_cocde Then
            If curvalue = "" Then
                dgExclCustomer.Item(dgExclCustomer_ici_cocde, iRow).Value = "Y"
            Else
                dgExclCustomer.Item(dgExclCustomer_ici_cocde, iRow).Value = ""
            End If

            If dgExclCustomer.Item(dgExclCustomer_ici_creusr, iRow).Value <> "~*ADD*~" Then
                dgExclCustomer.Item(dgExclCustomer_ici_creusr, iRow).Value = "~*UPD*~"
            End If

        End If
    End Sub

    Private Sub cboConstrMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboConstrMethod.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboConstrMethod.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim constrmethod As String
                    constrmethod = Split(cboConstrMethod.Text, " - ")(0)
                    If constrmethod <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_cosmth") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboMOQUM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMOQUM.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboMOQUM.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim tmpstr As String
                    tmpstr = cboMOQUM.Text
                    If tmpstr <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_moqunttyp") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboMOACurr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMOACurr.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboMOACurr.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim tmpstr As String
                    tmpstr = cboMOACurr.Text
                    If tmpstr <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_curcde") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtWastage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWastage.TextChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If txtWastage.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim tmpstr As String
                    tmpstr = txtWastage.Text
                    If tmpstr <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_wastage") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    'Private Sub txtMOQQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMOQQty.KeyPress
    '    ' Check Numeric
    '    If Not (e.KeyChar = vbBack Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
    '        e.KeyChar = ""
    '    End If
    'End Sub

    Private Sub txtMOQQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMOQQty.TextChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If txtMOQQty.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim tmpstr As String
                    tmpstr = txtMOQQty.Text
                    If tmpstr <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_moqctn") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    'Private Sub txtMOAAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMOAAmt.KeyPress
    '    ' Check Numeric
    '    If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
    '        e.KeyChar = ""
    '    End If
    'End Sub

    Private Sub txtMOAAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMOAAmt.TextChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If txtMOAAmt.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim tmpstr As String
                    tmpstr = txtMOAAmt.Text
                    If IsNumeric(tmpstr) Then
                        If tmpstr <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_moa") Then
                            Recordstatus = True
                            rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtPerMultQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPerMultQty.TextChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If txtPerMultQty.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim tmpstr As String
                    tmpstr = txtPerMultQty.Text
                    If tmpstr <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_qty") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub rbTier_Standard_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTier_Standard.CheckedChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If mode = "UPDATE" Or mode = "ADD" Then
                Dim tmpstr As String
                If rbTier_Standard.Checked = True Then
                    tmpstr = "1"
                Else
                    tmpstr = "2"
                End If
                If tmpstr <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_tirtyp") Then
                    Recordstatus = True
                    rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                End If
                format_MOQMOA("Standard", "All")
            End If
        End If
    End Sub

    Private Sub rbTier_CompDef_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTier_CompDef.CheckedChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If mode = "UPDATE" Or mode = "ADD" Then
                Dim tmpstr As String
                If rbTier_Standard.Checked = True Then
                    tmpstr = "1"
                Else
                    tmpstr = "2"
                End If
                If tmpstr <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_tirtyp") Then
                    Recordstatus = True
                    rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                End If
                format_MOQMOA("ComDef", "All")
            End If
        End If
    End Sub


    Private Sub format_MOQMOA(ByVal typ As String, ByVal moqmoa As String)
        If typ = "ComDef" Then
            rbTier_Standard.ForeColor = Color.Black
            rbTier_CompDef.ForeColor = Color.Blue

            If moqmoa = "MOQ" Then
                cboMOQUM.Enabled = True
                txtMOQQty.Enabled = True
                cboMOACurr.Enabled = False
                txtMOAAmt.Enabled = False
                txtPerMultQty.Enabled = False
            ElseIf moqmoa = "MOA" Then
                cboMOQUM.Enabled = False
                txtMOQQty.Enabled = False
                cboMOACurr.Enabled = True
                txtMOAAmt.Enabled = True
                txtPerMultQty.Enabled = True
            Else
                cboMOQUM.Enabled = True
                txtMOQQty.Enabled = True
                cboMOACurr.Enabled = True
                txtMOAAmt.Enabled = True
                txtPerMultQty.Enabled = True
            End If
        Else
            rbTier_Standard.ForeColor = Color.Blue
            rbTier_CompDef.ForeColor = Color.Black

            cboMOQUM.Enabled = False
            txtMOQQty.Enabled = False
            cboMOACurr.Enabled = False
            txtMOAAmt.Enabled = False
            txtPerMultQty.Enabled = False
        End If
    End Sub

    Private Sub cbAddreq_formA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAddreq_formA.CheckedChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If mode = "UPDATE" Then
                Dim tmpstr As String
                If cbAddreq_formA.Checked = True Then
                    tmpstr = "Y"
                Else
                    tmpstr = ""
                End If
                If tmpstr <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_addreq_forma") Then
                    Recordstatus = True
                    rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                End If
            End If
        End If
    End Sub

    Private Sub cbAddreq_ccib_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAddreq_ccib.CheckedChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If mode = "UPDATE" Then
                Dim tmpstr As String
                If cbAddreq_ccib.Checked = True Then
                    tmpstr = "Y"
                Else
                    tmpstr = ""
                End If
                If tmpstr <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_addreq_ccbi") Then
                    Recordstatus = True
                    rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                End If
            End If
        End If
    End Sub



    Private Sub cbAddreq_ster_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAddreq_ster.CheckedChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If mode = "UPDATE" Then
                Dim tmpstr As String
                If cbAddreq_ster.Checked = True Then
                    tmpstr = "Y"
                Else
                    tmpstr = ""
                End If
                If tmpstr <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_addreq_ster") Then
                    Recordstatus = True
                    rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                End If
            End If
        End If
    End Sub

    Private Sub cboHstuUSA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHstuUSA.SelectedIndexChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If cboHstuUSA.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim tmpstr As String
                    tmpstr = Split(cboHstuUSA.Text, " - ")(0)
                    If tmpstr <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_hamusa") Then
                        txtHstuUSADuty.Text = gethrmrate(Split(cboHstuUSA.Text, " - ")(0))
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtHstuUSADuty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHstuUSADuty.TextChanged
        If rs_IMBASINF.Tables("RESULT").Rows.Count = 1 Then
            If txtHstuUSADuty.Text <> "" Then
                If mode = "UPDATE" Then
                    Dim tmpstr As String
                    tmpstr = txtHstuUSADuty.Text
                    If tmpstr <> rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_dtyusa") Then
                        Recordstatus = True
                        rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmdActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdActivate.Click
        Dim itmno As String
        itmno = txtItmNo.Text
        gspStr = "sp_select_CopyItemMaster '', '" & itmno & "','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdActivate_Click sp_select_CopyItemMaster :" & rtnStr)
            Exit Sub
        End If

        MsgBox("Item Activated!")
        cmdClear_Click(sender, e)
        txtItmNo.Text = itmno
        cmdFind_Click(sender, e)
    End Sub

    Private Sub dgPacking_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgPacking.CellValidating
        Dim iRow As Integer = dgPacking.CurrentCell.RowIndex

        Dim row As DataGridViewRow = dgPacking.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        Dim tmpstrarry As String()
        Dim i As Integer

        Dim flag_updateCFT As Boolean
        flag_updateCFT = False

        If row.Cells(e.ColumnIndex).IsInEditMode Then
            Select Case e.ColumnIndex
                Case dgPacking_ipi_qutdat
                    If Len(strNewVal) <> 7 Or Mid(strNewVal, 5, 1) <> "-" Then
                        MsgBox("Invalid Packing Period [YYYY-MM]!")
                        e.Cancel = True
                        Exit Sub
                    End If
                    If Not (IsNumeric(Mid(strNewVal, 1, 4)) And IsNumeric(Mid(strNewVal, 6, 2))) Then
                        MsgBox("Invalid Packing Period [YYYY-MM]!")
                        e.Cancel = True
                        Exit Sub
                    End If
                    If Not (Mid(strNewVal, 1, 4) >= "1900" And Mid(strNewVal, 1, 4) <= "2099") Then
                        MsgBox("Invalid Packing Period [YYYY-MM]!")
                        e.Cancel = True
                        Exit Sub
                    End If
                    If Not (Mid(strNewVal, 6, 2) >= "01" And Mid(strNewVal, 6, 2) <= "12") Then
                        MsgBox("Invalid Packing Period [YYYY-MM]!")
                        e.Cancel = True
                        Exit Sub
                    End If
                Case dgPacking_ipi_cft
                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Invalid CFT [not numeric]!")
                        e.Cancel = True
                        Exit Sub
                    End If

                    flag_updateCFT = True

                    'If MsgBox("Are you sure to change cft? All related pricing cft info will be updated.", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    '    e.Cancel = True
                    '    Exit Sub
                    'Else
                    '    flag_updateCFT = True
                    'End If
                Case dgPacking_ipi_cbm
                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Invalid CBM [not numeric]!")
                        e.Cancel = True
                        Exit Sub
                    End If

                    flag_updateCFT = True

                    'If MsgBox("Are you sure to change cbm? All related pricing cft info will be updated.", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    '    e.Cancel = True
                    '    Exit Sub
                    'Else
                    '    flag_updateCFT = True
                    'End If
                Case dgPacking_ipi_grswgt
                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Invalid G.W. [not numeric]!")
                        e.Cancel = True
                        Exit Sub
                    End If
                Case dgPacking_ipi_netwgt
                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Invalid N.W. [not numeric]!")
                        e.Cancel = True
                        Exit Sub
                    End If
                Case dgPacking_inner_in
                    tmpstrarry = Split(strNewVal, "x")

                    If tmpstrarry.Length <> 3 Then
                        MsgBox("Invalid Inner Inch [LxWxH]!")
                        e.Cancel = True
                        Exit Sub
                    End If

                    For i = 0 To tmpstrarry.Length - 1
                        If Not IsNumeric(tmpstrarry(i)) Then
                            MsgBox("Invalid Inner Inch [LxWxH]!")
                            e.Cancel = True
                            Exit Sub
                        End If
                    Next i
                Case dgPacking_inner_cm
                    tmpstrarry = Split(strNewVal, "x")

                    If tmpstrarry.Length <> 3 Then
                        MsgBox("Invalid Inner cm [LxWxH]!")
                        e.Cancel = True
                        Exit Sub
                    End If

                    For i = 0 To tmpstrarry.Length - 1
                        If Not IsNumeric(tmpstrarry(i)) Then
                            MsgBox("Invalid Inner cm [LxWxH]!")
                            e.Cancel = True
                            Exit Sub
                        End If
                    Next i
                Case dgPacking_master_in
                    tmpstrarry = Split(strNewVal, "x")

                    If tmpstrarry.Length <> 3 Then
                        MsgBox("Invalid Master Inch [LxWxH]!")
                        e.Cancel = True
                        Exit Sub
                    End If

                    For i = 0 To tmpstrarry.Length - 1
                        If Not IsNumeric(tmpstrarry(i)) Then
                            MsgBox("Invalid Master Inch [LxWxH]!")
                            e.Cancel = True
                            Exit Sub
                        End If
                    Next i

                    flag_updateCFT = True

                    'If MsgBox("Are you sure to change master inch? All related pricing cft info will be updated.", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    '    e.Cancel = True
                    '    Exit Sub
                    'Else
                    '    flag_updateCFT = True
                    'End If

                Case dgPacking_master_cm
                    tmpstrarry = Split(strNewVal, "x")

                    If tmpstrarry.Length <> 3 Then
                        MsgBox("Invalid Master cm [LxWxH]!")
                        e.Cancel = True
                        Exit Sub
                    End If

                    For i = 0 To tmpstrarry.Length - 1
                        If Not IsNumeric(tmpstrarry(i)) Then
                            MsgBox("Invalid Master cm[LxWxH]!")
                            e.Cancel = True
                            Exit Sub
                        End If
                    Next i

                    flag_updateCFT = True
                Case dgPacking_ipi_pckunt
                    If Split(cboItmTyp.Text, " - ")(0) = "ASS" Then
                        If Mid(strNewVal, 1, 2) = "ST" Then
                            dgPacking.Item(dgPacking_ipi_conftr, dgPacking.CurrentCell.RowIndex).Value = getconftr(strNewVal)
                            'dgPacking.Item(dgPacking_ipi_pckunt, dgPacking.CurrentCell.RowIndex).Value = "ST"
                        End If

                        For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
                            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_pckunt") = "ST"
                            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_conftr") = getconftr(strNewVal)
                        Next i

                    End If

                    flag_updateCFT = False



                    'If MsgBox("Are you sure to change master cm? All related pricing cft info will be updated.", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    '    e.Cancel = True
                    '    Exit Sub
                    'Else
                    '    flag_updateCFT = True
                    'End If
            End Select

            If flag_updateCFT = True Then
                Dim upd_um As String
                Dim upd_inr As String
                Dim upd_mtr As String
                Dim upd_cft As String

                upd_um = dgPacking.Item(dgPacking_ipi_pckunt, iRow).Value
                upd_inr = dgPacking.Item(dgPacking_ipi_inrqty, iRow).Value
                upd_mtr = dgPacking.Item(dgPacking_ipi_mtrqty, iRow).Value
                If e.ColumnIndex = dgPacking_ipi_cft Then
                    upd_cft = dgPacking.Item(dgPacking_ipi_cft, iRow).EditedFormattedValue
                Else
                    upd_cft = dgPacking.Item(dgPacking_ipi_cft, iRow).Value
                End If

                For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
                    If rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_pckunt") = upd_um And _
                        rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_inrqty") = upd_inr And _
                        rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_mtrqty") = upd_mtr Then

                        rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cft") = upd_cft
                        rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_packing") = upd_um & " / " & upd_inr & " / " & upd_mtr & " / " & upd_cft

                        If rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_creusr") <> "~*ADD*~" Then
                            rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_creusr") = "~*UPD*~"
                        End If
                        Recordstatus = True
                    End If
                Next i
            End If
        End If
    End Sub

    Private Sub txtMOQQty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMOQQty.Validating
        Dim tmp As Decimal
        If IsNumeric(txtMOQQty.Text) Then
            tmp = txtMOQQty.Text
            If tmp <> 0 Then
                If IsNumeric(txtMOAAmt.Text) Then
                    tmp = txtMOAAmt.Text
                    If tmp <> 0 Then
                        MsgBox("MOA already assigned!")
                        e.Cancel = True
                    End If
                End If
            End If
        Else
            If Not (mode = "INIT" And txtMOAAmt.Text = "") Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub txtMOAAmt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMOAAmt.Validating
        Dim tmp As Decimal
        If IsNumeric(txtMOAAmt.Text) Then
            tmp = txtMOAAmt.Text
            If tmp <> 0 Then
                If IsNumeric(txtMOQQty.Text) Then
                    tmp = txtMOQQty.Text
                    If tmp <> 0 Then
                        MsgBox("MOQ already assigned!")
                        e.Cancel = True
                    End If
                End If
            End If
        Else
            If Not (mode = "INIT" And txtMOQQty.Text = "") Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub cboPanPVPV_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboPanPVPV.Validating
        Dim tmpstr As String
        tmpstr = cboPanPVPV.Text

        If cboPanPVPV.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Production Vendor!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboDV_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboDV.Validating
        Dim tmpstr As String
        tmpstr = cboDV.Text

        If cboDV.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Design Vendor!")
            e.Cancel = True
        Else
            If mode = "ADD" Then
                cboCV.Text = tmpstr
                cboEV.Text = tmpstr
                cboTV.Text = tmpstr
                display_cboItmVenTyp(Split(tmpstr, " - ")(0))

            End If
        End If
    End Sub

    Private Sub cboCV_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCV.Validating
        Dim tmpstr As String
        tmpstr = cboCV.Text

        If cboCV.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Custom Vendor!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboTV_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboTV.Validating
        Dim tmpstr As String
        tmpstr = cboTV.Text

        If cboTV.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Trading Vendor!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboEV_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboEV.Validating
        Dim tmpstr As String
        tmpstr = cboEV.Text

        If cboEV.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Examine Vendor!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboPanCopyPrdLne_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboPanCopyPrdLne.Validating
        Dim tmpstr As String
        tmpstr = cboPanCopyPrdLne.Text

        If cboPanCopyPrdLne.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Product Line!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboPanCopyCategory_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboPanCopyCategory.Validating
        Dim tmpstr As String
        tmpstr = cboPanCopyCategory.Text

        If cboPanCopyCategory.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Category!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboPrdLne_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboPrdLne.Validating
        Dim tmpstr As String
        tmpstr = cboPrdLne.Text

        If cboPrdLne.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Product Line!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboItmVenTyp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboItmVenTyp.Validating
        Dim tmpstr As String
        tmpstr = cboItmVenTyp.Text

        If cboItmVenTyp.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Item Type!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboCategory_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCategory.Validating
        Dim tmpstr As String
        tmpstr = cboCategory.Text

        If cboCategory.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Category!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboPrdTyp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboPrdTyp.Validating
        Dim tmpstr As String
        tmpstr = cboPrdTyp.Text

        If cboPrdTyp.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Product Type!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboMaterial_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboMaterial.Validating
        Dim tmpstr As String
        tmpstr = cboMaterial.Text

        If cboMaterial.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Key Material!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboItmNature_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboItmNature.Validating
        Dim tmpstr As String
        tmpstr = cboItmNature.Text

        If cboItmNature.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Item Nature!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboPrdSizeTyp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboPrdSizeTyp.Validating
        Dim tmpstr As String
        tmpstr = cboPrdSizeTyp.Text

        If cboPrdSizeTyp.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Product Size Type!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboPrdSizeUnit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboPrdSizeUnit.Validating
        Dim tmpstr As String
        tmpstr = cboPrdSizeUnit.Text

        If cboPrdSizeUnit.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Product Size Unit!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboPrdGroup_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboPrdGroup.Validating
        Dim tmpstr As String
        tmpstr = cboPrdGroup.Text

        If cboPrdGroup.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Product Group!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboPrdIcon_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboPrdIcon.Validating
        Dim tmpstr As String
        tmpstr = cboPrdIcon.Text

        If cboPrdIcon.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Product Icon!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboSeason_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboSeason.Validating
        Dim tmpstr As String
        tmpstr = cboSeason.Text

        If cboSeason.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Season!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboDesigner_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboDesigner.Validating
        Dim tmpstr As String
        tmpstr = cboDesigner.Text

        If cboDesigner.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Designer!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboDevTeam_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboDevTeam.Validating
        'Dim tmpstr As String
        'tmpstr = cboDevTeam.Text

        'If cboDevTeam.Items.IndexOf(tmpstr) = -1 Then
        '    MsgBox("Invalid Development Team!")
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub cboType_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboType.Validating
        'Dim tmpstr As String
        'tmpstr = cboType.Text

        'If cboType.Items.IndexOf(tmpstr) = -1 Then
        '    MsgBox("Invalid Type!")
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub cboYear_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboYear.Validating
        'Dim tmpstr As String
        'tmpstr = cboYear.Text

        'If cboYear.Items.IndexOf(tmpstr) = -1 Then
        '    MsgBox("Invalid Year!")
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub cboHstuUSA_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboHstuUSA.Validating
        Dim tmpstr As String
        tmpstr = cboHstuUSA.Text

        If cboHstuUSA.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Hstu USA!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboMOQUM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboMOQUM.Validating
        Dim tmpstr As String
        tmpstr = cboMOQUM.Text

        If cboMOQUM.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid MOQ UM!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboMOACurr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboMOACurr.Validating
        Dim tmpstr As String
        tmpstr = cboMOACurr.Text

        If cboMOACurr.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid MOA Currency!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboPanPackUM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPanPackUM.Validated
        If Split(cboItmTyp.Text, " - ")(0) = "ASS" Then
            If Mid(cboPanPackUM.Text, 1, 2) = "ST" Then
                txtPanPackConFtr.Text = getconftr(cboPanPackUM.Text)
                cboPanPackUM.Text = "ST"
            End If
        End If

    End Sub

    Private Sub cboPanPackUM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboPanPackUM.Validating
        Dim tmpstr As String
        tmpstr = cboPanPackUM.Text

        If cboPanPackUM.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid UM!")
            e.Cancel = True
        Else
            If Split(cboItmTyp.Text, " - ")(0) = "ASS" Then
                If Mid(cboPanPackUM.Text, 1, 2) <> "ST" Then
                    MsgBox("Invalid Assortment UM!")
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub txtPanCPEffDate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPanCPEffDate.GotFocus
        txtPanCPEffDate.Select(0, Len(txtPanCPEffDate.Text))
    End Sub

    Private Sub txtPanCPEffDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPanCPEffDate.Validating
        If IsDate(txtPanCPEffDate.Text) = False Then
            MsgBox("Invalid Date format!")
            e.Cancel = True
        End If
    End Sub

    Private Sub txtPanCPExpDate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPanCPExpDate.GotFocus
        txtPanCPExpDate.Select(0, Len(txtPanCPExpDate.Text))
    End Sub

    Private Sub txtPanCPExpDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPanCPExpDate.Validating
        If IsDate(txtPanCPExpDate.Text) = False Then
            MsgBox("Invalid Date format!")
            e.Cancel = True
        Else
            If IsDate(txtPanCPEffDate.Text) And IsDate(txtPanCPExpDate.Text) Then
                Dim effdate As DateTime
                Dim expdate As DateTime
                effdate = txtPanCPEffDate.Text
                expdate = txtPanCPExpDate.Text
                If effdate > expdate Then
                    MsgBox("Effective Date greater than Expiry Date!")
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub TabPageMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPageMain.SelectedIndexChanged
        If TabPageMain.SelectedIndex = 0 Then
            cmdBatchUpdate.Focus()
        ElseIf TabPageMain.SelectedIndex = 4 Then
            If Split(cboItmTyp.Text, " - ")(0) <> "BOM" Then
                dgCostPrice.Columns(dgCostPrice_imu_packing).Frozen = True
            Else
                dgCostPrice.Columns(dgCostPrice_imu_packing).Frozen = False
            End If
        End If
    End Sub

    Private Sub txtPanCPExpDate_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtPanCPExpDate.MaskInputRejected

    End Sub

    Private Sub txtPanCPEffDate_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtPanCPEffDate.MaskInputRejected

    End Sub

    Private Sub dgColor_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgColor.CellContentClick

    End Sub

    Private Sub dgCostPrice_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCostPrice.CellContentClick

    End Sub

    Private Sub dgPacking_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPacking.CellContentClick

    End Sub

    Private Sub cbDiscontinue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDiscontinue.CheckedChanged

    End Sub

    Private Sub txtCstRmk_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCstRmk.KeyUp
        If mode = "UPDATE" Or mode = "ADD" Then
            Recordstatus = True
            If rs_IMCSTINF.Tables("RESULT").Rows.Count = 0 Then
                Dim i As Integer
                For i = 0 To rs_IMCSTINF.Tables("RESULT").Columns.Count - 1
                    rs_IMCSTINF.Tables("RESULT").Columns(i).ReadOnly = False
                Next i

                rs_IMCSTINF.Tables("RESULT").Rows.Add()
                rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_creusr") = "~*ADD*~"
                rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_cocde") = ""
                rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_itmno") = txtItmNo.Text
                rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_cstrmk") = ""
                rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_expdat") = "1900-01-01"
            Else
                If rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_creusr") <> "~*ADD*~" Then
                    rs_IMCSTINF.Tables("RESULT").Rows(0).Item("ici_creusr") = "~*UPD*~"
                End If
            End If
        End If
    End Sub

    Private Sub txtCstRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCstRmk.TextChanged

    End Sub

    Private Sub txtItmRmk_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItmRmk.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
            rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
        End If
    End Sub

    Private Sub txtItmRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmRmk.TextChanged
        Dim textSelectionStart = txtItmRmk.SelectionStart

        txtItmRmk.Focus()
        txtItmRmk.SelectAll()
        txtItmRmk.SelectionFont = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'Me.txtItmRmk.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtItmRmk.Select(textSelectionStart, 0)
    End Sub

    Private Sub txtEngDsc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEngDsc.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
            rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
        End If
    End Sub

    Private Sub txtEngDsc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEngDsc.TextChanged

    End Sub

    Private Sub txtChnDsc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChnDsc.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
            rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_creusr") = "~*UPD*~"
        End If
    End Sub

    Public Function revisedItmno(ByVal itmNo As String) As String
        '*** converting format of item no:
        itmNo = Replace(itmNo, " /", "_")
        itmNo = Replace(itmNo, "/", "_")
        itmNo = Replace(itmNo, "-", "_")
        itmNo = Replace(itmNo, " ", "")
        revisedItmno = itmNo
    End Function

    Private Sub txtChnDsc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChnDsc.TextChanged

    End Sub

    Private Sub cboPanPackUM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPanPackUM.SelectedIndexChanged

    End Sub

    Private Sub dgBOMASS_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBOMASS.CellContentClick

    End Sub

    Private Sub dgPV_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPV.CellContentClick

    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim frmSYM00018 As New SYM00018

        frmSYM00018.keyName = txtItmNo.Name
        frmSYM00018.strModule = "IM"

        frmSYM00018.show_frmSYM00018(Me)

    End Sub

    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        gsSearchKey = ""
        If txtItmNo.Text <> "" Then
            'Dim frm_SYM00021 As New SYM00021(txtItmNo.Text)

            'frm_SYM00021.MdiParent = Me.MdiParent

            'If SYM00021_Value = 1 Then
            '    frm_SYM00021.Show()
            '    AddHandler frm_SYM00021.returnSelectedRecords, AddressOf returnSelectedRecordsHandler
            '    Call cmdFind_Click(sender, e)

            'End If

            Dim frm_SYM00021 As New SYM00021(txtItmNo.Text)
            frm_SYM00021.callBy = Me.Name
            frm_SYM00021.show_frmSYM00021(Me)

        End If
    End Sub

    Private Sub returnSelectedRecordsHandler(ByVal sender As Object)
        If Len(gsSearchKey) > 0 And txtItmNo.Enabled = True Then
            txtItmNo.Text = gsSearchKey
            txtItmNo.Refresh()
        End If
    End Sub

    Private Sub cmdMapping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMapping.Click
        gsSearchKey = ""
        If txtItmNo.Text <> "" Then
            Dim frm_SYM00022 As New SYM00022(txtItmNo.Text)

            frm_SYM00022.MdiParent = Me.MdiParent

            If domapping_value = 1 Then
                frm_SYM00022.Show()
                '                AddHandler frm_SYM00022.returnSelectedRecords, AddressOf returnSelectedRecordsHandler
                'Call cmdFind_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub cmdBatchUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBatchUpdate.Click
        SYM00024.strITEMNO = txtItmNo.Text
        SYM00024.ShowDialog()
    End Sub

    Private Sub dgMOQMOA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgMOQMOA.GotFocus
        gbMOQMOA.ForeColor = Color.DarkCyan
        Got_Focus_Grid = "dgMOQMOA"
    End Sub

    Private Sub dgMOQMOA_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgMOQMOA.LostFocus
        gbMOQMOA.ForeColor = Color.Black
    End Sub

    Private Sub cboPanCPCus1no_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPanCPCus1no.TextChanged
        Dim dr_p() As DataRow = rs_CUBASINF.Tables("RESULT").Select("cbi_cusno = '" & Split(cboPanCPCus1no.Text, " - ")(0) & "' and cbi_custyp = 'P'")

        If dr_p.Length = 0 Then
            cboPanCPCus2no.SelectedIndex = -1
            cboPanCPCus2no.Enabled = False
        Else
            cboPanCPCus2no.Enabled = True
        End If
    End Sub

    Private Sub dgMOQMOA_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMOQMOA.CellClick
        If cmdSave.Enabled = False Then
            Exit Sub
        End If

        If e.RowIndex >= 0 Then
            If dgMOQMOA.SelectedCells.Count = 1 Then
                If dgMOQMOA.CurrentCell.ColumnIndex = 0 Then
                    rs_IMMOQMOA.Tables("RESULT").Columns("imm_status").ReadOnly = False
                    rs_IMMOQMOA.Tables("RESULT").Columns("imm_creusr").ReadOnly = False
                    If rs_IMMOQMOA.Tables("RESULT").Rows(dgMOQMOA.CurrentCell.RowIndex)("imm_status").ToString = " " Then
                        If rs_IMMOQMOA.Tables("RESULT").Rows(dgMOQMOA.CurrentCell.RowIndex)("imm_creusr").ToString <> "~*ADD*~" Then
                            rs_IMMOQMOA.Tables("RESULT").Rows(dgMOQMOA.CurrentCell.RowIndex)("imm_creusr") = "~*DEL*~"
                            rs_IMMOQMOA.Tables("RESULT").Rows(dgMOQMOA.CurrentCell.RowIndex)("imm_status") = "Y"
                        ElseIf rs_IMMOQMOA.Tables("RESULT").Rows(dgMOQMOA.CurrentCell.RowIndex)("imm_creusr").ToString = "~*ADD*~" Then
                            rs_IMMOQMOA.Tables("RESULT").Rows(dgMOQMOA.CurrentCell.RowIndex)("imm_creusr") = "~*NEW*~"
                            rs_IMMOQMOA.Tables("RESULT").Rows(dgMOQMOA.CurrentCell.RowIndex)("imm_status") = "Y"
                        End If
                    Else
                        If rs_IMMOQMOA.Tables("RESULT").Rows(dgMOQMOA.CurrentCell.RowIndex)("imm_creusr").ToString = "~*NEW*~" Then
                            rs_IMMOQMOA.Tables("RESULT").Rows(dgMOQMOA.CurrentCell.RowIndex)("imm_creusr") = "~*ADD*~"
                        Else
                            rs_IMMOQMOA.Tables("RESULT").Rows(dgMOQMOA.CurrentCell.RowIndex)("imm_creusr") = "~*UPD*~"
                        End If
                        rs_IMMOQMOA.Tables("RESULT").Rows(dgMOQMOA.CurrentCell.RowIndex)("imm_status") = " "
                    End If
                    rs_IMMOQMOA.Tables("RESULT").Columns("imm_status").ReadOnly = True
                    rs_IMMOQMOA.Tables("RESULT").Columns("imm_creusr").ReadOnly = True
                    Recordstatus = True
                End If
            End If
        End If
    End Sub

    Private Sub add_MOQMOA()
        If PanelMOQMOA.Visible = True Then
            Exit Sub
        End If

        If Split(cboItmTyp.Text, " - ")(0) = "BOM" Then
            MsgBox("BOM item is not allowed to add MOQMOA")
            Exit Sub
        End If

        PanelMOQMOA.Visible = True
        display_PanelMOQMOA("MOQMOA_INSERT")
    End Sub

    Private Sub display_PanelMOQMOA(ByVal m As String)
        If m = "MOQMOA_INSERT" Then
            cboPanMMCus1no.SelectedIndex = -1
            cboPanMMCus2no.SelectedIndex = -1
            'cboPanMMCus2no.Enabled = False
            SetComboStatus(cboPanMMCus2no, "Disable")
            rbPanMMTirtyp_Company.Enabled = True
            rbPanMMTirtyp_Standard.Enabled = True
            rbPanMMTirtyp_Standard.Checked = True
            cboPanMMMOQMOA.SelectedIndex = -1
            cboPanMMMOQMOA.Enabled = False
            cboPanMMMOQUM.SelectedIndex = -1
            'cboPanMMMOQUM.Enabled = False
            SetComboStatus(cboPanMMMOQUM, "Disable")
            txtPanMMMOQQty.Text = 0
            txtPanMMMOQQty.Enabled = False
            cboPanMMMOACur.SelectedIndex = -1
            'cboPanMMMOACur.Enabled = False
            SetComboStatus(cboPanMMMOACur, "Disable")
            txtPanMMMOA.Text = 0
            txtPanMMMOA.Enabled = False
            cmdPanMMInsert.Enabled = True
            cmdPanMMUpdate.Enabled = False
        ElseIf m = "MOQMOA_UPDATE" Then
            'cboPanMMCus1no.Enabled = True
            SetComboStatus(cboPanMMCus1no, "Enable")
            'cboPanMMCus2no.Enabled = True
            SetComboStatus(cboPanMMCus2no, "Enable")
            rbPanMMTirtyp_Standard.Checked = False
            rbPanMMTirtyp_Company.Checked = False
            rbPanMMTirtyp_Company.Enabled = True
            rbPanMMTirtyp_Standard.Enabled = True
            cboPanMMMOQMOA.Enabled = True
            'cboPanMMMOQUM.Enabled = True
            SetComboStatus(cboPanMMMOQUM, "Enable")
            txtPanMMMOQQty.Enabled = True
            'cboPanMMMOACur.Enabled = True
            SetComboStatus(cboPanMMMOACur, "Enable")
            txtPanMMMOA.Enabled = True
            cmdPanMMInsert.Enabled = True
            cmdPanMMUpdate.Enabled = True
            cmdPanMMCancel.Enabled = True

            display_combo(dgMOQMOA.CurrentRow.Cells(imm_cus1no).Value, cboPanMMCus1no)
            display_combo(dgMOQMOA.CurrentRow.Cells(imm_cus2no).Value, cboPanMMCus2no)
            If dgMOQMOA.CurrentRow.Cells(imm_tirtyp).Value = "Standard Tier" Then
                rbPanMMTirtyp_Standard.Checked = True
            Else
                rbPanMMTirtyp_Company.Checked = True
            End If
            display_combo(dgMOQMOA.CurrentRow.Cells(imm_moqmoa).Value, cboPanMMMOQMOA)
            display_combo(dgMOQMOA.CurrentRow.Cells(imm_moqunttyp).Value, cboPanMMMOQUM)
            txtPanMMMOQQty.Text = dgMOQMOA.CurrentRow.Cells(imm_moqctn).Value
            display_combo(dgMOQMOA.CurrentRow.Cells(imm_curcde).Value, cboPanMMMOACur)
            txtPanMMMOA.Text = dgMOQMOA.CurrentRow.Cells(imm_moa).Value
        ElseIf m = "MOQMOA_READ" Then
            display_combo(dgMOQMOA.CurrentRow.Cells(imm_cus1no).Value, cboPanMMCus1no)
            display_combo(dgMOQMOA.CurrentRow.Cells(imm_cus2no).Value, cboPanMMCus2no)
            If dgMOQMOA.CurrentRow.Cells(imm_tirtyp).Value = "Standard Tier" Then
                rbPanMMTirtyp_Standard.Checked = True
            Else
                rbPanMMTirtyp_Company.Checked = True
            End If
            display_combo(dgMOQMOA.CurrentRow.Cells(imm_moqmoa).Value, cboPanMMMOQMOA)
            display_combo(dgMOQMOA.CurrentRow.Cells(imm_moqunttyp).Value, cboPanMMMOQUM)
            txtPanMMMOQQty.Text = dgMOQMOA.CurrentRow.Cells(imm_moqctn).Value
            display_combo(dgMOQMOA.CurrentRow.Cells(imm_curcde).Value, cboPanMMMOACur)
            txtPanMMMOA.Text = dgMOQMOA.CurrentRow.Cells(imm_moa).Value

            'cboPanMMCus1no.Enabled = False
            SetComboStatus(cboPanMMCus1no, "Disable")
            'cboPanMMCus2no.Enabled = False
            SetComboStatus(cboPanMMCus2no, "Disable")
            rbPanMMTirtyp_Company.Enabled = False
            rbPanMMTirtyp_Standard.Enabled = False
            cboPanMMMOQMOA.Enabled = False
            'cboPanMMMOQUM.Enabled = False
            SetComboStatus(cboPanMMMOQUM, "Disable")
            txtPanMMMOQQty.Enabled = False
            'cboPanMMMOACur.Enabled = False
            SetComboStatus(cboPanMMMOACur, "Disable")
            txtPanMMMOA.Enabled = False
            cmdPanMMInsert.Enabled = False
            cmdPanMMUpdate.Enabled = False
            cmdPanMMCancel.Enabled = True
        End If
    End Sub

    Private Function save_IMMOQMOA() As Boolean
        If rs_IMMOQMOA.Tables("RESULT").Rows.Count = 0 Then
            Return True
        End If

        Dim IMM_COCDE As String
        Dim IMM_ITMNO As String
        Dim IMM_CUS1NO As String
        Dim IMM_CUS2NO As String
        Dim IMM_TIRTYP As String
        Dim IMM_MOQMOA As String
        Dim IMM_MOQUNTTYP As String
        Dim IMM_MOQCTN As String
        Dim IMM_CURCDE As String
        Dim IMM_MOA As String
        Dim IMM_CREUSR As String

        For i As Integer = 0 To rs_IMMOQMOA.Tables("RESULT").Rows.Count - 1
            IMM_COCDE = rs_IMMOQMOA.Tables("RESULT").Rows(i).Item("imm_status")
            IMM_ITMNO = rs_IMMOQMOA.Tables("RESULT").Rows(i).Item("imm_itmno")
            IMM_CUS1NO = Split(rs_IMMOQMOA.Tables("RESULT").Rows(i).Item("imm_cus1no"), " - ")(0)
            IMM_CUS2NO = Split(rs_IMMOQMOA.Tables("RESULT").Rows(i).Item("imm_cus2no"), " - ")(0)
            'IMM_TIRTYP = rs_IMMOQMOA.Tables("RESULT").Rows(i).Item("imm_tirtyp")
            If rs_IMMOQMOA.Tables("RESULT").Rows(i).Item("imm_tirtyp") = "Standard Tier" Then
                IMM_TIRTYP = "1"
            ElseIf rs_IMMOQMOA.Tables("RESULT").Rows(i).Item("imm_tirtyp") = "Company Defined" Then
                IMM_TIRTYP = "2"
            End If
            IMM_MOQMOA = rs_IMMOQMOA.Tables("RESULT").Rows(i).Item("imm_moqmoa")
            IMM_MOQUNTTYP = rs_IMMOQMOA.Tables("RESULT").Rows(i).Item("imm_moqunttyp")
            IMM_MOQCTN = rs_IMMOQMOA.Tables("RESULT").Rows(i).Item("imm_moqctn")
            IMM_CURCDE = rs_IMMOQMOA.Tables("RESULT").Rows(i).Item("imm_curcde")
            IMM_MOA = rs_IMMOQMOA.Tables("RESULT").Rows(i).Item("imm_moa")
            IMM_CREUSR = rs_IMMOQMOA.Tables("RESULT").Rows(i).Item("imm_creusr")

            gspStr = ""
            If IMM_COCDE = "Y" Then
                gspStr = "sp_physical_delete_IMMOQMOA '','" & IMM_ITMNO & "','" & IMM_CUS1NO & "','" & IMM_CUS2NO & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_IMMOQMOA sp_physical_delete_IMCUSNO:" & rtnStr)
                    Return False
                End If
            ElseIf IMM_CREUSR = "~*ADD*~" Or IMM_CREUSR = "~*NEW*~" Then
                If IMM_CUS1NO <> "" Then
                    gspStr = "sp_insert_IMMOQMOA '','" & IMM_ITMNO & "','" & IMM_CUS1NO & "','" & IMM_CUS2NO & _
                             "','" & IMM_TIRTYP & "','" & IMM_MOQMOA & "','" & IMM_MOQUNTTYP & "','" & IMM_MOQCTN & _
                             "','" & IMM_CURCDE & "','" & IMM_MOA & "','" & gsUsrID & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_IMMOQMOA sp_insert_IMCUSNO :" & rtnStr)
                        Return False
                    End If
                End If
            ElseIf check_update_MOQMOA(i, IMM_CUS1NO, IMM_CUS2NO) = True Then
                gspStr = "sp_update_IMMOQMOA '','" & IMM_ITMNO & "','" & IMM_CUS1NO & "','" & IMM_CUS2NO & _
                             "','" & IMM_TIRTYP & "','" & IMM_MOQMOA & "','" & IMM_MOQUNTTYP & "','" & IMM_MOQCTN & _
                             "','" & IMM_CURCDE & "','" & IMM_MOA & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_IMMOQMOA sp_update_IMCUSNO :" & rtnStr)
                    Return False
                End If
            End If
        Next

        Return True
    End Function

    Private Function check_update_MOQMOA(ByVal index As Integer, ByVal cus1no As String, ByVal cus2no As String) As Boolean
        Dim dr() As DataRow = rs_IMMOQMOA_old.Tables("RESULT").Select("imm_cus1no = '" & cus1no & "' and imm_cus2no = '" & cus2no & "' and imm_status <> 'Y'")
        If dr.Length <> 1 Then
            Return False
        Else
            For i As Integer = 0 To rs_IMMOQMOA_old.Tables("RESULT").Columns.Count - 1
                If i >= imm_tirtyp And i <= imm_moa Then
                    If rs_IMMOQMOA.Tables("RESULT").Rows(index)(i).ToString <> dr(0).Item(i).ToString Then
                        Return True
                    End If
                End If
            Next
            Return False
        End If
    End Function

    Private Sub cmdPanMMCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanMMCancel.Click
        PanelMOQMOA.Visible = False
        release_TabControl()
        format_TabControl("IM", Split(cboItmTyp.Text, " - ")(0))
    End Sub

    Private Sub cmdPanMMInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanMMInsert.Click
        If check_PanMM("INSERT") = False Then
            Exit Sub
        End If

        Dim rowcount As Integer = rs_IMMOQMOA.Tables("RESULT").Rows.Count

        For i As Integer = 0 To imm_moa
            rs_IMMOQMOA.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        rs_IMMOQMOA.Tables("RESULT").Rows.Add()
        rs_IMMOQMOA.Tables("RESULT").Rows(rowcount).Item("imm_status") = " "
        rs_IMMOQMOA.Tables("RESULT").Rows(rowcount).Item("imm_itmno") = txtItmNo.Text
        rs_IMMOQMOA.Tables("RESULT").Rows(rowcount).Item("imm_cus1no") = Split(cboPanMMCus1no.Text, " - ")(0)
        rs_IMMOQMOA.Tables("RESULT").Rows(rowcount).Item("imm_cus2no") = Split(cboPanMMCus2no.Text, " - ")(0)
        If rbPanMMTirtyp_Standard.Checked = True Then
            rs_IMMOQMOA.Tables("RESULT").Rows(rowcount).Item("imm_tirtyp") = "Standard Tier"
        Else
            rs_IMMOQMOA.Tables("RESULT").Rows(rowcount).Item("imm_tirtyp") = "Company Defined"
        End If
        rs_IMMOQMOA.Tables("RESULT").Rows(rowcount).Item("imm_moqmoa") = cboPanMMMOQMOA.Text
        rs_IMMOQMOA.Tables("RESULT").Rows(rowcount).Item("imm_moqunttyp") = cboPanMMMOQUM.Text
        rs_IMMOQMOA.Tables("RESULT").Rows(rowcount).Item("imm_moqctn") = txtPanMMMOQQty.Text
        rs_IMMOQMOA.Tables("RESULT").Rows(rowcount).Item("imm_curcde") = cboPanMMMOACur.Text
        rs_IMMOQMOA.Tables("RESULT").Rows(rowcount).Item("imm_moa") = txtPanMMMOA.Text
        rs_IMMOQMOA.Tables("RESULT").Rows(rowcount).Item("imm_creusr") = "~*ADD*~"

        For i As Integer = 0 To imm_moa
            rs_IMMOQMOA.Tables("RESULT").Columns(i).ReadOnly = True
        Next

        Recordstatus = True
        cmdPanMMCancel.PerformClick()
    End Sub

    Private Sub cmdPanMMUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanMMUpdate.Click
        If check_PanMM("UPDATE") = False Then
            Exit Sub
        End If

        For i As Integer = 0 To imm_moa
            rs_IMMOQMOA.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        Dim dr() As DataRow = rs_IMMOQMOA.Tables("RESULT").Select("imm_cus1no = '" & Split(cboPanMMCus1no.Text, " - ")(0) & "' and imm_cus2no = '" & Split(cboPanMMCus2no.Text, " - ")(0) & "'")
        If dr.Length > 0 Then
            If rbPanMMTirtyp_Standard.Checked = True Then
                dr(0).Item(imm_tirtyp) = "Standard Tier"
            Else
                dr(0).Item(imm_tirtyp) = "Company Defined"
            End If
            dr(0).Item(imm_moqmoa) = cboPanMMMOQMOA.Text
            dr(0).Item(imm_moqunttyp) = cboPanMMMOQUM.Text
            dr(0).Item(imm_moqctn) = txtPanMMMOQQty.Text
            dr(0).Item(imm_curcde) = cboPanMMMOACur.Text
            dr(0).Item(imm_moa) = txtPanMMMOA.Text
        End If

        For i As Integer = 0 To imm_moa
            rs_IMMOQMOA.Tables("RESULT").Columns(i).ReadOnly = True
        Next

        Recordstatus = True
        cmdPanMMCancel.PerformClick()
    End Sub

    Private Sub format_cboPanMMMOQMOA()
        cboPanMMMOQMOA.Items.Clear()
        cboPanMMMOQMOA.Items.Add("MOQ")
        cboPanMMMOQMOA.Items.Add("MOA")
    End Sub

    Private Sub format_cboPanMMMOQUM()
        cboPanMMMOQUM.Items.Clear()
        cboPanMMMOQUM.Items.Add("PC")
        cboPanMMMOQUM.Items.Add("CTN")
    End Sub

    Private Sub format_cboPanMMMOACur()
        cboPanMMMOACur.Items.Clear()
        cboPanMMMOACur.Items.Add("HKD")
        cboPanMMMOACur.Items.Add("USD")
        cboPanMMMOACur.Items.Add("CNY")
    End Sub

    Private Sub cboPanMMCus1no_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPanMMCus1no.SelectedIndexChanged
        Dim dr_p() As DataRow = rs_CUBASINF.Tables("RESULT").Select("cbi_cusno = '" & Split(cboPanMMCus1no.Text, " - ")(0) & "' and cbi_custyp = 'P'")

        If dr_p.Length = 0 Then
            cboPanMMCus2no.SelectedIndex = -1
            'cboPanMMCus2no.Enabled = False
            SetComboStatus(cboPanMMCus2no, "Disable")
        Else
            'cboPanMMCus2no.Enabled = True
            SetComboStatus(cboPanMMCus2no, "Enable")
            cboPanMMCus2no.SelectedIndex = -1
            format_cboPanCus2no(Split(cboPanMMCus1no.Text, " - ")(0))
        End If
    End Sub

    Private Sub cbo_AutoSearch(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPanMMCus1no.KeyUp, cboPanMMCus2no.KeyUp
        auto_search_combo(sender, e.KeyCode)
    End Sub

    Private Sub cbo_VerifyData(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboPanMMCus1no.Validating, cboPanMMCus2no.Validating, cboPanMMMOACur.Validating, cboPanMMMOQMOA.Validating, cboPanMMMOQUM.Validating, cboPanMMMOACur.Validating
        If sender.Items.Contains(sender.Text) = False Then
            e.Cancel = True
            Select Case sender.Name.ToString
                Case "cboPanMMCus1no"
                    MsgBox("Primary Customer does not exist from Customer List")
                Case "cboPanMMCus2no"
                    MsgBox("Secondary Customer does not exist from Customer List")
                Case "cboPanMMMOQUM"
                    MsgBox("MOQ UM does not exist from UM List")
                Case "cboPanMMMOACur"
                    MsgBox("MOA Currency does not exist from Currency List")
            End Select
            Exit Sub
        End If
    End Sub

    Private Sub cboPanMMTirTyp_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPanMMTirtyp_Standard.CheckedChanged, rbPanMMTirtyp_Company.CheckedChanged
        If rbPanMMTirtyp_Standard.Checked = True Then
            cboPanMMMOQMOA.SelectedIndex = -1
            cboPanMMMOQMOA.Enabled = False
            cboPanMMMOQUM.SelectedIndex = -1
            'cboPanMMMOQUM.Enabled = False
            SetComboStatus(cboPanMMMOQUM, "Disable")
            txtPanMMMOQQty.Text = 0
            txtPanMMMOQQty.Enabled = False
            cboPanMMMOACur.SelectedIndex = -1
            'cboPanMMMOACur.Enabled = False
            SetComboStatus(cboPanMMMOACur, "Disable")
            txtPanMMMOA.Text = 0
            txtPanMMMOA.Enabled = False
        Else
            cboPanMMMOQMOA.SelectedIndex = 0
            cboPanMMMOQMOA.Enabled = True
            cboPanMMMOQUM.SelectedIndex = 0
            'cboPanMMMOQUM.Enabled = True
            SetComboStatus(cboPanMMMOQUM, "Enable")
            txtPanMMMOQQty.Text = 0
            txtPanMMMOQQty.Enabled = True
            cboPanMMMOACur.SelectedIndex = -1
            'cboPanMMMOACur.Enabled = False
            SetComboStatus(cboPanMMMOACur, "Disable")
            txtPanMMMOA.Text = 0
            txtPanMMMOA.Enabled = False
        End If
    End Sub

    Private Sub cboPanCPMMMOQMOA_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPanMMMOQMOA.SelectedIndexChanged
        If sender.Text = "MOQ" Then
            cboPanMMMOQUM.SelectedIndex = 0
            'cboPanMMMOQUM.Enabled = True
            SetComboStatus(cboPanMMMOQUM, "Enable")
            txtPanMMMOQQty.Text = 0
            txtPanMMMOQQty.Enabled = True
            cboPanMMMOACur.SelectedIndex = -1
            'cboPanMMMOACur.Enabled = False
            SetComboStatus(cboPanMMMOACur, "Disable")
            txtPanMMMOA.Text = 0
            txtPanMMMOA.Enabled = False
        ElseIf sender.Text = "MOA" Then
            cboPanMMMOQUM.SelectedIndex = -1
            'cboPanMMMOQUM.Enabled = False
            SetComboStatus(cboPanMMMOQUM, "Disable")
            txtPanMMMOQQty.Text = 0
            txtPanMMMOQQty.Enabled = False
            cboPanMMMOACur.SelectedIndex = 0
            'cboPanMMMOACur.Enabled = True
            SetComboStatus(cboPanMMMOACur, "Enable")
            txtPanMMMOA.Text = 0
            txtPanMMMOA.Enabled = True
        End If
    End Sub

    Private Function check_PanMM(ByVal m As String) As Boolean
        Dim dr() As DataRow
        If m = "INSERT" Then
            If Split(cboPanMMCus1no.Text, " - ")(0) = "" Then
                MsgBox("Primary Customer is missing")
                Return False
            End If

            dr = rs_IMMOQMOA.Tables("RESULT").Select("imm_cus1no = '" & Split(cboPanMMCus1no.Text, " - ")(0) & "' and imm_cus2no = '" & Split(cboPanMMCus2no.Text, " - ")(0) & "'")
            If dr.Length > 0 Then
                MsgBox("Primary and Secondary MOQ/MOA already exists!")
                Return False
            End If
        ElseIf m = "UPDATE" Then
            If Split(cboPanMMCus1no.Text, " - ")(0) = "" Then
                MsgBox("Primary Customer is missing")
                Return False
            End If

            dr = rs_IMMOQMOA.Tables("RESULT").Select("imm_cus1no = '" & Split(cboPanMMCus1no.Text, " - ")(0) & "' and imm_cus2no = '" & Split(cboPanMMCus2no.Text, " - ")(0) & "'")
            If dr.Length = 0 Then
                MsgBox("Primary and Secondary MOQ/MOA does not exist!")
                Return False
            End If
        Else
            Return False
        End If

        Return True
    End Function

    Private Sub txtPanMMMOQQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanMMMOQQty.KeyPress
        If Asc(e.KeyChar) = 46 Then
            e.KeyChar = Chr(0)
        ElseIf Asc(e.KeyChar) = 8 Then
            Return
        ElseIf Not IsNumeric(e.KeyChar) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtPanMMMOA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanMMMOA.KeyPress
        If Asc(e.KeyChar) = 46 Then
            If sender.Text.Contains(".") Then
                e.KeyChar = Chr(0)
            End If
        ElseIf Asc(e.KeyChar) = 8 Then
            Return
        ElseIf Not IsNumeric(e.KeyChar) Then
            e.KeyChar = Chr(0)
        Else
            If InStr(sender.Text, ".") > 0 Then
                If sender.Text.Substring(sender.Text.Length - (sender.Text.Length - InStr(sender.Text, ".")), sender.Text.Length - InStr(sender.Text, ".")).Length >= 4 And sender.SelectionStart >= InStr(sender.Text, ".") Then
                    If sender.SelectionLength = 0 Then
                        e.KeyChar = Chr(0)
                    End If
                ElseIf sender.Text.Substring(0, InStr(sender.Text, ".")).Length > 9 And sender.SelectionStart < InStr(sender.Text, ".") Then
                    If sender.SelectionLength = 0 Then
                        e.KeyChar = Chr(0)
                    End If
                End If
            Else
                If sender.Text.Length >= 9 Then
                    e.KeyChar = Chr(0)
                End If
            End If

        End If
    End Sub

    Private Sub dgMOQMOA_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgMOQMOA.RowHeaderMouseDoubleClick
        If Split(cboItmTyp.Text, " - ")(0) = "BOM" Then
            Exit Sub
        End If

        freeze_TabControl(5)
        PanelMOQMOA.Visible = True
        If mode = "UPDATE" Or mode = "ADD" Then
            Dim curvalue As String = dgMOQMOA.CurrentRow.Cells(imm_status).Value

            If curvalue = "Y" Then
                display_PanelMOQMOA("MOQMOA_READ")
            Else
                display_PanelMOQMOA("MOQMOA_UPDATE")
            End If

        Else
            display_PanelMOQMOA("MOQMOA_READ")
        End If
    End Sub

    Private Sub SetComboStatus(ByVal combo As ComboBox, ByVal mode As String)
        If mode = "Enable" Then
            combo.Enabled = True
            combo.DropDownStyle = ComboBoxStyle.DropDown
        Else
            combo.DropDownStyle = ComboBoxStyle.DropDownList
            combo.Enabled = False
        End If
    End Sub

    Private Function check_update_BOMASS(ByVal index As Integer, ByVal assitm As String, ByVal colcde As String, ByVal pckunt As String, ByVal inrqty As String, ByVal mtrqty As String) As Boolean
        Dim dr() As DataRow = rs_IMBOMASS_old.Tables("RESULT").Select("iba_assitm = '" & assitm & "' and iba_colcde = '" & colcde & "' and iba_pckunt = '" & pckunt & "' and iba_inrqty = " & inrqty & " and iba_mtrqty = " & mtrqty & " and iba_status <> 'Y'")

        If dr.Length <> 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub cboItmVenTyp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItmVenTyp.TextChanged
        If Split(cboItmVenTyp.Text, " - ")(0) = "EXT" Then
            rbTier_Standard.Enabled = False
            rbTier_CompDef.Enabled = False
            cboMOQUM.Enabled = False
            txtMOQQty.Enabled = False
            cboMOACurr.Enabled = False
            txtMOAAmt.Enabled = False
            txtWastage.Enabled = False
            txtPerMultQty.Enabled = False
            dgMOQMOA.Enabled = True
        ElseIf Split(cboItmVenTyp.Text, " - ")(0) = "INT" Then
            rbTier_Standard.Enabled = True
            rbTier_CompDef.Enabled = True
            cboMOQUM.Enabled = True
            txtMOQQty.Enabled = True
            cboMOACurr.Enabled = True
            txtMOAAmt.Enabled = True
            txtWastage.Enabled = True
            txtPerMultQty.Enabled = True
            dgMOQMOA.Enabled = False
        Else
            rbTier_Standard.Enabled = False
            rbTier_CompDef.Enabled = False
            cboMOQUM.Enabled = False
            txtMOQQty.Enabled = False
            cboMOACurr.Enabled = False
            txtMOAAmt.Enabled = False
            txtWastage.Enabled = False
            txtPerMultQty.Enabled = False
            dgMOQMOA.Enabled = False
        End If
    End Sub

    Private Sub txtItmNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmNo.TextChanged

    End Sub

    Private Sub cboPanPackCus1no_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPanPackCus1no.KeyUp
        auto_search_combo(cboPanPackCus1no, e.KeyCode)
    End Sub

    Private Sub cboPanPackCus1no_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPanPackCus1no.TextChanged
        Dim dr_p() As DataRow = rs_CUBASINF.Tables("RESULT").Select("cbi_cusno = '" & Split(cboPanPackCus1no.Text, " - ")(0) & "' and cbi_custyp = 'P'")

        If dr_p.Length = 0 Then
            cboPanPackCus2no.SelectedIndex = -1
            cboPanPackCus2no.Enabled = False
        Else
            cboPanPackCus2no.Enabled = True
        End If
    End Sub

    Private Sub cboPanPackCus2no_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPanPackCus2no.KeyUp
        auto_search_combo(cboPanPackCus2no, e.KeyCode)
    End Sub

    Private Sub cboPanPackCus1no_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPanPackCus1no.SelectedIndexChanged
        If cboPanPackCus1no.Text <> "" Then
            format_cboPanCus2no(Split(cboPanPackCus1no.Text, " - ")(0))
        End If
    End Sub

    Private Sub dgCostPrice_RowValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCostPrice.RowValidated
        If TabPageMain.SelectedIndex = 4 And dgCostPrice.SelectedCells.Count > 0 Then
            ' Internal IM PV Change Price - Remove Comments when Implement
            If Split(cboItmVenTyp.Text, " - ")(0) = "INT" Then
                Dim dr() As DataRow = rs_IMPRCINF.Tables("RESULT").Select("imu_pckunt = '" & dgCostPrice.Rows(e.RowIndex).Cells("imu_pckunt").Value & "' and " & _
                                                                  "imu_inrqty = '" & dgCostPrice.Rows(e.RowIndex).Cells("imu_inrqty").Value & "' and " & _
                                                                  "imu_mtrqty = '" & dgCostPrice.Rows(e.RowIndex).Cells("imu_mtrqty").Value & "' and " & _
                                                                  "imu_cus1no = '" & dgCostPrice.Rows(e.RowIndex).Cells("imu_cus1no").Value & "' and " & _
                                                                  "imu_cus2no = '" & dgCostPrice.Rows(e.RowIndex).Cells("imu_cus2no").Value & "' and " & _
                                                                  "imu_ftyprctrm = '" & dgCostPrice.Rows(e.RowIndex).Cells("imu_ftyprctrm").Value & "' and " & _
                                                                  "imu_hkprctrm = '" & dgCostPrice.Rows(e.RowIndex).Cells("imu_hkprctrm").Value & "' and " & _
                                                                  "imu_trantrm = '" & dgCostPrice.Rows(e.RowIndex).Cells("imu_trantrm").Value & "' and " & _
                                                                  "imu_prdven <> '" & dgCostPrice.Rows(e.RowIndex).Cells("imu_prdven").Value & "'")
                If dr.Length > 0 Then
                    For i As Integer = 0 To dr.Length - 1
                        dr(i)("imu_status") = dgCostPrice.Rows(e.RowIndex).Cells("imu_status").Value
                        dr(i)("imu_effdat") = dgCostPrice.Rows(e.RowIndex).Cells("imu_effdat").Value
                        dr(i)("imu_expdat") = dgCostPrice.Rows(e.RowIndex).Cells("imu_expdat").Value
                        dr(i)("imu_curcde") = dgCostPrice.Rows(e.RowIndex).Cells("imu_curcde").Value
                        dr(i)("imu_ftycst") = dgCostPrice.Rows(e.RowIndex).Cells("imu_ftycst").Value
                        dr(i)("imu_ftycstA") = dgCostPrice.Rows(e.RowIndex).Cells("imu_ftycstA").Value
                        dr(i)("imu_ftycstB") = dgCostPrice.Rows(e.RowIndex).Cells("imu_ftycstB").Value
                        dr(i)("imu_ftycstC") = dgCostPrice.Rows(e.RowIndex).Cells("imu_ftycstC").Value
                        dr(i)("imu_ftycstD") = dgCostPrice.Rows(e.RowIndex).Cells("imu_ftycstD").Value
                        dr(i)("imu_ftycstE") = dgCostPrice.Rows(e.RowIndex).Cells("imu_ftycstE").Value
                        dr(i)("imu_ftycstTran") = dgCostPrice.Rows(e.RowIndex).Cells("imu_ftycstTran").Value
                        dr(i)("imu_ftycstPack") = dgCostPrice.Rows(e.RowIndex).Cells("imu_ftycstPack").Value
                        dr(i)("imu_fml") = dgCostPrice.Rows(e.RowIndex).Cells("imu_fml").Value
                        dr(i)("imu_fmlA") = dgCostPrice.Rows(e.RowIndex).Cells("imu_fmlA").Value
                        dr(i)("imu_fmlB") = dgCostPrice.Rows(e.RowIndex).Cells("imu_fmlB").Value
                        dr(i)("imu_fmlC") = dgCostPrice.Rows(e.RowIndex).Cells("imu_fmlC").Value
                        dr(i)("imu_fmlD") = dgCostPrice.Rows(e.RowIndex).Cells("imu_fmlD").Value
                        dr(i)("imu_fmlE") = dgCostPrice.Rows(e.RowIndex).Cells("imu_fmlE").Value
                        dr(i)("imu_fmlTran") = dgCostPrice.Rows(e.RowIndex).Cells("imu_fmlTran").Value
                        dr(i)("imu_fmlPack") = dgCostPrice.Rows(e.RowIndex).Cells("imu_fmlPack").Value
                        dr(i)("imu_chgfp") = dgCostPrice.Rows(e.RowIndex).Cells("imu_chgfp").Value
                        dr(i)("imu_chgfpA") = dgCostPrice.Rows(e.RowIndex).Cells("imu_chgfpA").Value
                        dr(i)("imu_chgfpB") = dgCostPrice.Rows(e.RowIndex).Cells("imu_chgfpB").Value
                        dr(i)("imu_chgfpC") = dgCostPrice.Rows(e.RowIndex).Cells("imu_chgfpC").Value
                        dr(i)("imu_chgfpD") = dgCostPrice.Rows(e.RowIndex).Cells("imu_chgfpD").Value
                        dr(i)("imu_chgfpE") = dgCostPrice.Rows(e.RowIndex).Cells("imu_chgfpE").Value
                        dr(i)("imu_chgfpTran") = dgCostPrice.Rows(e.RowIndex).Cells("imu_chgfpTran").Value
                        dr(i)("imu_chgfpPack") = dgCostPrice.Rows(e.RowIndex).Cells("imu_chgfpPack").Value
                        dr(i)("imu_ftyprc") = dgCostPrice.Rows(e.RowIndex).Cells("imu_ftyprc").Value
                        dr(i)("imu_ftyprcA") = dgCostPrice.Rows(e.RowIndex).Cells("imu_ftyprcA").Value
                        dr(i)("imu_ftyprcB") = dgCostPrice.Rows(e.RowIndex).Cells("imu_ftyprcB").Value
                        dr(i)("imu_ftyprcC") = dgCostPrice.Rows(e.RowIndex).Cells("imu_ftyprcC").Value
                        dr(i)("imu_ftyprcD") = dgCostPrice.Rows(e.RowIndex).Cells("imu_ftyprcD").Value
                        dr(i)("imu_ftyprcE") = dgCostPrice.Rows(e.RowIndex).Cells("imu_ftyprcE").Value
                        dr(i)("imu_ftyprcTran") = dgCostPrice.Rows(e.RowIndex).Cells("imu_ftyprcTran").Value
                        dr(i)("imu_ftyprcPack") = dgCostPrice.Rows(e.RowIndex).Cells("imu_ftyprcPack").Value
                        dr(i)("imu_bomcst") = dgCostPrice.Rows(e.RowIndex).Cells("imu_bomcst").Value
                        dr(i)("imu_ttlcst") = dgCostPrice.Rows(e.RowIndex).Cells("imu_ttlcst").Value
                        dr(i)("imu_hkadjper") = dgCostPrice.Rows(e.RowIndex).Cells("imu_hkadjper").Value
                        dr(i)("imu_negcst") = dgCostPrice.Rows(e.RowIndex).Cells("imu_negcst").Value
                        dr(i)("imu_negprc") = dgCostPrice.Rows(e.RowIndex).Cells("imu_negprc").Value
                        dr(i)("imu_fmlopt") = dgCostPrice.Rows(e.RowIndex).Cells("imu_fmlopt").Value
                        dr(i)("imu_bcurcde") = dgCostPrice.Rows(e.RowIndex).Cells("imu_bcurcde").Value
                        dr(i)("imu_itmprc") = dgCostPrice.Rows(e.RowIndex).Cells("imu_itmprc").Value
                        dr(i)("imu_bomprc") = dgCostPrice.Rows(e.RowIndex).Cells("imu_bomprc").Value
                        dr(i)("imu_basprc") = dgCostPrice.Rows(e.RowIndex).Cells("imu_basprc").Value
                        dr(i)("imu_period") = dgCostPrice.Rows(e.RowIndex).Cells("imu_period").Value
                        dr(i)("imu_creusr") = dgCostPrice.Rows(e.RowIndex).Cells("imu_creusr").Value
                        dr(i)("imu_cstchgdat") = Today.ToString

                        Recordstatus = True
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub txtPanCPFtyCstE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanCPFtyCstE.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanCPFtyCstE.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_pancostprice_keypress = True
    End Sub

    Private Sub txtPanCPFtyCstE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanCPFtyCstE.TextChanged
        If flag_pancostprice_keypress = True Then
            flag_pancostprice_keypress = False
            calculate_CostPrice()
        End If
    End Sub

    Private Sub txtPanCPFtyPrcE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPanCPFtyPrcE.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtPanCPFtyPrcE.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If
        flag_pancostprice_keypress = True
    End Sub

    Private Sub txtPanCPFtyPrcE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanCPFtyPrcE.TextChanged
        If flag_pancostprice_keypress = True Then
            flag_pancostprice_keypress = False
            calculate_CostPrice()
        End If
    End Sub

    Private Sub cmdRelItm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRelItm.Click
        Me.TabPageMain.SelectedIndex = 5
    End Sub

    Private Sub cmdCopyPV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopyPV.Click
        If rs_IMVENINF Is Nothing Then
            Exit Sub
        End If
        Dim default_pv As String
        default_pv = ""

        Dim i As Integer
        For i = 0 To rs_IMVENINF.Tables("RESULT").Rows.Count - 1

            If rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_def") = "Y" Then
                default_pv = rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_venno") + " - " + rs_IMVENINF.Tables("RESULT").Rows(i).Item("vbi_vensna")
            End If

        Next i
        If cboCV.Items.IndexOf(default_pv) <> -1 Then
            cboCV.Text = default_pv
        End If
        If cboTV.Items.IndexOf(default_pv) <> -1 Then
            cboTV.Text = default_pv
        End If
        If cboEV.Items.IndexOf(default_pv) <> -1 Then
            cboEV.Text = default_pv
        End If

    End Sub

    Dim flag_grdcontrol As String
End Class
