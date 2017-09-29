Public Class SHM00002
    Inherits System.Windows.Forms.Form

    Dim dsNewRow As DataRow
    Dim mode As String
    Private Const sMODULE As String = "SH"
    Public rs_SYUSRRIGHT_Check As New DataSet
    Public rs_SHCBNDTL_SUM As New DataSet
    Public rs_SYSETINF As New DataSet
    Public rs_SHCBNHDR As New DataSet

    Public rs_SHCBNDTL As New DataSet

    Public rs_SHINVHDR As New DataSet

    Public rs_SHDISPRM_D As New DataSet
    Public rs_SHDISPRM_P As New DataSet
    Public rs_SHSHPMRK As New DataSet
    Public rs_SHDTLCTN As New DataSet
    Public rs_SCDTLCTN As New DataSet
    Public rs_CUCNTINF As New DataSet
    Public rs_SHCI_SHIPGDTL As New DataSet
    Public rs_CUBASINF As New DataSet

    Public rs_SHPCDHDR As DataSet
    Public rs_SHIPGDTLO As DataSet
    Public rs_invoutqty As DataSet


    Dim dr() As DataRow

    Public flg_DisplayShipDetailData As Boolean
    Public flg_DisplayShipMarkData As Boolean


    Dim CanModify As Boolean ' Check for access right

    Dim Add_flag As Boolean     '*** Check for Add Record
    Dim sMode As String
    Private Const cModeInit As String = "Init"
    Private Const cModeAdd As String = "Add"
    Private Const cModeCopy As String = "Copy"
    Private Const cModeUpd As String = "Updating"
    Private Const cModeSave As String = "Save"
    Private Const cModeDel As String = "Delete"
    Private Const cModeRead As String = "ReadOnly"
    Private Const cModeClear As String = "Clear"
    Dim shpno As String
    Dim gi_saved_items_count As Integer
    Public no_Display_Detail As Boolean
    Dim Insert_flag As Boolean
    Dim drNewRow As DataRow
    Dim PreviousTab As Integer = 0
    Public flg_DisplayInvoiceHeaderData As Boolean
    Dim TtlAmt As Double

    Dim IsUpdated As Boolean
    Dim save_ok As Boolean
    Dim Current_TimeStamp As Long
    Dim MaxSeq As Integer
    Dim start As Boolean
    Dim Recordstatus As Boolean
    Dim flag_exit As Boolean
    Dim TmpItmNo As String

#Region " Windows Form Designer generated code"
    Friend WithEvents btcSHM00002 As ERPSystem.BaseTabControl
    Friend WithEvents tpSHM00002_1 As System.Windows.Forms.TabPage
    Friend WithEvents tpSHM00002_2 As System.Windows.Forms.TabPage
    Friend WithEvents cms_CopyNPaste As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents smi_Copy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smi_Paste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtNoteNo As System.Windows.Forms.TextBox
    Friend WithEvents lblQutNo As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblRvsDat As System.Windows.Forms.Label
    Friend WithEvents lblIssDat As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblQutSts As System.Windows.Forms.Label
    Friend WithEvents cboCDStatus As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gbPri As System.Windows.Forms.GroupBox
    Friend WithEvents txtPrmCus As System.Windows.Forms.TextBox
    Friend WithEvents txtSecCus As System.Windows.Forms.TextBox
    Friend WithEvents txtRefNo As System.Windows.Forms.TextBox
    Friend WithEvents txtTtlUnt As System.Windows.Forms.TextBox
    Friend WithEvents txtRmk As System.Windows.Forms.RichTextBox
    Friend WithEvents CmdDtlPre As System.Windows.Forms.Button
    Friend WithEvents CmdDtlNext As System.Windows.Forms.Button
    Friend WithEvents cboPayTrm As System.Windows.Forms.ComboBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents optDebit As System.Windows.Forms.RadioButton
    Friend WithEvents optCredit As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkSample As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboBCty As System.Windows.Forms.ComboBox
    Friend WithEvents txtBilstt As System.Windows.Forms.TextBox
    Friend WithEvents txtBilAdr As System.Windows.Forms.RichTextBox
    Friend WithEvents txtBilZip As System.Windows.Forms.TextBox
    Friend WithEvents txtTtlAmt As System.Windows.Forms.TextBox
    Friend WithEvents cboPrcTrm As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents fmeDetail As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCusItm As System.Windows.Forms.TextBox
    Friend WithEvents cboPckInf As System.Windows.Forms.ComboBox
    Friend WithEvents txtColDsc As System.Windows.Forms.TextBox
    Friend WithEvents txtItmDsc As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtCurCde4 As System.Windows.Forms.TextBox
    Friend WithEvents cboSCNo As System.Windows.Forms.ComboBox
    Friend WithEvents txtCurCde5 As System.Windows.Forms.TextBox
    Friend WithEvents txtDRmk As System.Windows.Forms.RichTextBox
    Friend WithEvents optMsc As System.Windows.Forms.RadioButton
    Friend WithEvents optItm As System.Windows.Forms.RadioButton
    Friend WithEvents txtSeq As System.Windows.Forms.TextBox
    Friend WithEvents txtItmNo As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtColCde As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtManAdr As System.Windows.Forms.RichTextBox
    Friend WithEvents txtManNam As System.Windows.Forms.TextBox
    Friend WithEvents txtCusSku As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtSCNo As System.Windows.Forms.TextBox
    Friend WithEvents txtAdjAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtAdjQty As System.Windows.Forms.TextBox
    Friend WithEvents txtAdjPrc As System.Windows.Forms.TextBox
    Friend WithEvents chkUpd As System.Windows.Forms.CheckBox
    Friend WithEvents chkDel As System.Windows.Forms.CheckBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtPO As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtInvLne As System.Windows.Forms.TextBox
    Friend WithEvents txtcre As System.Windows.Forms.TextBox
    Friend WithEvents txtShpQty As System.Windows.Forms.TextBox
    Friend WithEvents ordqty As System.Windows.Forms.TextBox
    Friend WithEvents shpqty As System.Windows.Forms.TextBox
    Friend WithEvents txtSelPrc As System.Windows.Forms.TextBox
    Friend WithEvents txtCurCde2 As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents DTIssDat As System.Windows.Forms.ComboBox
    Friend WithEvents DTRevDat As System.Windows.Forms.ComboBox
    Friend WithEvents txtShpAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtCurCde3 As System.Windows.Forms.TextBox
    Friend WithEvents txtout As System.Windows.Forms.TextBox
    Friend WithEvents txtdeb As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SHM00002))
        Me.StatusBar = New System.Windows.Forms.StatusBar
        Me.cms_CopyNPaste = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.smi_Copy = New System.Windows.Forms.ToolStripMenuItem
        Me.smi_Paste = New System.Windows.Forms.ToolStripMenuItem
        Me.txtNoteNo = New System.Windows.Forms.TextBox
        Me.lblQutNo = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblRvsDat = New System.Windows.Forms.Label
        Me.lblIssDat = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblQutSts = New System.Windows.Forms.Label
        Me.cboCDStatus = New System.Windows.Forms.ComboBox
        Me.Label57 = New System.Windows.Forms.Label
        Me.optDebit = New System.Windows.Forms.RadioButton
        Me.optCredit = New System.Windows.Forms.RadioButton
        Me.DTIssDat = New System.Windows.Forms.ComboBox
        Me.DTRevDat = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
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
        Me.btcSHM00002 = New ERPSystem.BaseTabControl
        Me.tpSHM00002_1 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtBilZip = New System.Windows.Forms.TextBox
        Me.cboBCty = New System.Windows.Forms.ComboBox
        Me.txtBilstt = New System.Windows.Forms.TextBox
        Me.txtBilAdr = New System.Windows.Forms.RichTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label58 = New System.Windows.Forms.Label
        Me.txtTtlAmt = New System.Windows.Forms.TextBox
        Me.cboPrcTrm = New System.Windows.Forms.ComboBox
        Me.cboPayTrm = New System.Windows.Forms.ComboBox
        Me.txtTtlUnt = New System.Windows.Forms.TextBox
        Me.txtRmk = New System.Windows.Forms.RichTextBox
        Me.gbPri = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkSample = New System.Windows.Forms.CheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtSecCus = New System.Windows.Forms.TextBox
        Me.txtRefNo = New System.Windows.Forms.TextBox
        Me.txtPrmCus = New System.Windows.Forms.TextBox
        Me.tpSHM00002_2 = New System.Windows.Forms.TabPage
        Me.fmeDetail = New System.Windows.Forms.GroupBox
        Me.txtShpAmt = New System.Windows.Forms.TextBox
        Me.txtCurCde3 = New System.Windows.Forms.TextBox
        Me.txtout = New System.Windows.Forms.TextBox
        Me.txtdeb = New System.Windows.Forms.TextBox
        Me.txtInvLne = New System.Windows.Forms.TextBox
        Me.txtcre = New System.Windows.Forms.TextBox
        Me.txtShpQty = New System.Windows.Forms.TextBox
        Me.ordqty = New System.Windows.Forms.TextBox
        Me.shpqty = New System.Windows.Forms.TextBox
        Me.txtSelPrc = New System.Windows.Forms.TextBox
        Me.txtCurCde2 = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.chkDel = New System.Windows.Forms.CheckBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtManAdr = New System.Windows.Forms.RichTextBox
        Me.txtManNam = New System.Windows.Forms.TextBox
        Me.txtCusSku = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtColCde = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtItmNo = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtSeq = New System.Windows.Forms.TextBox
        Me.optMsc = New System.Windows.Forms.RadioButton
        Me.optItm = New System.Windows.Forms.RadioButton
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txtPO = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.chkUpd = New System.Windows.Forms.CheckBox
        Me.txtAdjQty = New System.Windows.Forms.TextBox
        Me.txtAdjPrc = New System.Windows.Forms.TextBox
        Me.txtSCNo = New System.Windows.Forms.TextBox
        Me.txtAdjAmt = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtCurCde4 = New System.Windows.Forms.TextBox
        Me.cboSCNo = New System.Windows.Forms.ComboBox
        Me.txtCurCde5 = New System.Windows.Forms.TextBox
        Me.txtDRmk = New System.Windows.Forms.RichTextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.CmdDtlNext = New System.Windows.Forms.Button
        Me.CmdDtlPre = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtCusItm = New System.Windows.Forms.TextBox
        Me.cboPckInf = New System.Windows.Forms.ComboBox
        Me.txtColDsc = New System.Windows.Forms.TextBox
        Me.txtItmDsc = New System.Windows.Forms.RichTextBox
        Me.cms_CopyNPaste.SuspendLayout()
        Me.menuStrip.SuspendLayout()
        Me.btcSHM00002.SuspendLayout()
        Me.tpSHM00002_1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbPri.SuspendLayout()
        Me.tpSHM00002_2.SuspendLayout()
        Me.fmeDetail.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusBar
        '
        Me.StatusBar.Location = New System.Drawing.Point(0, 607)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(954, 24)
        Me.StatusBar.TabIndex = 1
        '
        'cms_CopyNPaste
        '
        Me.cms_CopyNPaste.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smi_Copy, Me.smi_Paste})
        Me.cms_CopyNPaste.Name = "cms_CopyNPaste"
        Me.cms_CopyNPaste.Size = New System.Drawing.Size(134, 48)
        '
        'smi_Copy
        '
        Me.smi_Copy.AutoSize = False
        Me.smi_Copy.Name = "smi_Copy"
        Me.smi_Copy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.smi_Copy.Size = New System.Drawing.Size(152, 22)
        Me.smi_Copy.Text = "Copy"
        Me.smi_Copy.ToolTipText = "Copy"
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
        'txtNoteNo
        '
        Me.txtNoteNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtNoteNo.Location = New System.Drawing.Point(115, 55)
        Me.txtNoteNo.MaxLength = 10
        Me.txtNoteNo.Name = "txtNoteNo"
        Me.txtNoteNo.Size = New System.Drawing.Size(87, 20)
        Me.txtNoteNo.TabIndex = 261
        '
        'lblQutNo
        '
        Me.lblQutNo.AutoSize = True
        Me.lblQutNo.ForeColor = System.Drawing.Color.Red
        Me.lblQutNo.Location = New System.Drawing.Point(15, 55)
        Me.lblQutNo.Name = "lblQutNo"
        Me.lblQutNo.Size = New System.Drawing.Size(42, 12)
        Me.lblQutNo.TabIndex = 263
        Me.lblQutNo.Text = "Note # :"
        '
        'cboCoCde
        '
        Me.cboCoCde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(116, 26)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(86, 21)
        Me.cboCoCde.TabIndex = 260
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label1.Location = New System.Drawing.Point(15, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 12)
        Me.Label1.TabIndex = 262
        Me.Label1.Text = "Company Code:"
        '
        'lblRvsDat
        '
        Me.lblRvsDat.AutoSize = True
        Me.lblRvsDat.Location = New System.Drawing.Point(663, 86)
        Me.lblRvsDat.Name = "lblRvsDat"
        Me.lblRvsDat.Size = New System.Drawing.Size(63, 12)
        Me.lblRvsDat.TabIndex = 267
        Me.lblRvsDat.Text = "Revise Date:"
        '
        'lblIssDat
        '
        Me.lblIssDat.AutoSize = True
        Me.lblIssDat.Location = New System.Drawing.Point(472, 85)
        Me.lblIssDat.Name = "lblIssDat"
        Me.lblIssDat.Size = New System.Drawing.Size(55, 12)
        Me.lblIssDat.TabIndex = 266
        Me.lblIssDat.Text = "Issue Date:"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(319, 27)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(350, 22)
        Me.txtCoNam.TabIndex = 273
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(226, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 12)
        Me.Label2.TabIndex = 272
        Me.Label2.Text = "Company Name:"
        '
        'lblQutSts
        '
        Me.lblQutSts.AutoSize = True
        Me.lblQutSts.Location = New System.Drawing.Point(471, 55)
        Me.lblQutSts.Name = "lblQutSts"
        Me.lblQutSts.Size = New System.Drawing.Size(35, 12)
        Me.lblQutSts.TabIndex = 275
        Me.lblQutSts.Text = "Status:"
        '
        'cboCDStatus
        '
        Me.cboCDStatus.Enabled = False
        Me.cboCDStatus.FormattingEnabled = True
        Me.cboCDStatus.Location = New System.Drawing.Point(539, 55)
        Me.cboCDStatus.Name = "cboCDStatus"
        Me.cboCDStatus.Size = New System.Drawing.Size(163, 20)
        Me.cboCDStatus.TabIndex = 276
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(15, 81)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(60, 12)
        Me.Label57.TabIndex = 277
        Me.Label57.Text = "Note Type :"
        '
        'optDebit
        '
        Me.optDebit.AutoSize = True
        Me.optDebit.Enabled = False
        Me.optDebit.Location = New System.Drawing.Point(201, 81)
        Me.optDebit.Name = "optDebit"
        Me.optDebit.Size = New System.Drawing.Size(48, 16)
        Me.optDebit.TabIndex = 330
        Me.optDebit.Text = "Debit"
        Me.optDebit.UseVisualStyleBackColor = True
        '
        'optCredit
        '
        Me.optCredit.AutoSize = True
        Me.optCredit.Checked = True
        Me.optCredit.Location = New System.Drawing.Point(103, 81)
        Me.optCredit.Name = "optCredit"
        Me.optCredit.Size = New System.Drawing.Size(52, 16)
        Me.optCredit.TabIndex = 329
        Me.optCredit.TabStop = True
        Me.optCredit.Text = "Credit"
        Me.optCredit.UseVisualStyleBackColor = True
        '
        'DTIssDat
        '
        Me.DTIssDat.Enabled = False
        Me.DTIssDat.FormattingEnabled = True
        Me.DTIssDat.Location = New System.Drawing.Point(539, 81)
        Me.DTIssDat.Name = "DTIssDat"
        Me.DTIssDat.Size = New System.Drawing.Size(105, 20)
        Me.DTIssDat.TabIndex = 331
        '
        'DTRevDat
        '
        Me.DTRevDat.Enabled = False
        Me.DTRevDat.FormattingEnabled = True
        Me.DTRevDat.Location = New System.Drawing.Point(736, 81)
        Me.DTRevDat.Name = "DTRevDat"
        Me.DTRevDat.Size = New System.Drawing.Size(105, 20)
        Me.DTRevDat.TabIndex = 332
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(-3, 37)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(1073, 12)
        Me.Label18.TabIndex = 333
        Me.Label18.Text = "_________________________________________________________________________________" & _
            "________________________________________________________________________________" & _
            "_________________"
        '
        'Timer1
        '
        '
        'menuStrip
        '
        Me.menuStrip.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdAdd, Me.mmdSave, Me.mmdDelete, Me.mmdCopy, Me.mmdFind, Me.t1, Me.mmdClear, Me.t2, Me.mmdSearch, Me.t3, Me.mmdInsRow, Me.mmdDelRow, Me.t4, Me.mmdPrint, Me.t5, Me.mmdAttach, Me.t6, Me.mmdFunction, Me.t7, Me.mmdLink, Me.t8, Me.mmdExit})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuStrip.Size = New System.Drawing.Size(954, 24)
        Me.menuStrip.TabIndex = 334
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
        'btcSHM00002
        '
        Me.btcSHM00002.Controls.Add(Me.tpSHM00002_1)
        Me.btcSHM00002.Controls.Add(Me.tpSHM00002_2)
        Me.btcSHM00002.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.btcSHM00002.Location = New System.Drawing.Point(0, 99)
        Me.btcSHM00002.Name = "btcSHM00002"
        Me.btcSHM00002.SelectedIndex = 0
        Me.btcSHM00002.Size = New System.Drawing.Size(954, 509)
        Me.btcSHM00002.TabIndex = 44
        '
        'tpSHM00002_1
        '
        Me.tpSHM00002_1.Controls.Add(Me.GroupBox2)
        Me.tpSHM00002_1.Location = New System.Drawing.Point(4, 22)
        Me.tpSHM00002_1.Name = "tpSHM00002_1"
        Me.tpSHM00002_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSHM00002_1.Size = New System.Drawing.Size(946, 483)
        Me.tpSHM00002_1.TabIndex = 0
        Me.tpSHM00002_1.Text = "(1)Header"
        Me.tpSHM00002_1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.gbPri)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(932, 482)
        Me.GroupBox2.TabIndex = 266
        Me.GroupBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtBilZip)
        Me.GroupBox3.Controls.Add(Me.cboBCty)
        Me.GroupBox3.Controls.Add(Me.txtBilstt)
        Me.GroupBox3.Controls.Add(Me.txtBilAdr)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox3.Location = New System.Drawing.Point(6, 139)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(478, 332)
        Me.GroupBox3.TabIndex = 268
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Information of Billing  "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 223)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 12)
        Me.Label8.TabIndex = 362
        Me.Label8.Text = "Zip/Postal Code:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 194)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 12)
        Me.Label7.TabIndex = 361
        Me.Label7.Text = "State/Province :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 162)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 12)
        Me.Label6.TabIndex = 360
        Me.Label6.Text = "Country :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 12)
        Me.Label5.TabIndex = 359
        Me.Label5.Text = "Bill to Address :"
        '
        'txtBilZip
        '
        Me.txtBilZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtBilZip.Location = New System.Drawing.Point(121, 220)
        Me.txtBilZip.MaxLength = 10
        Me.txtBilZip.Name = "txtBilZip"
        Me.txtBilZip.Size = New System.Drawing.Size(120, 20)
        Me.txtBilZip.TabIndex = 287
        '
        'cboBCty
        '
        Me.cboBCty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboBCty.FormattingEnabled = True
        Me.cboBCty.Location = New System.Drawing.Point(120, 157)
        Me.cboBCty.Name = "cboBCty"
        Me.cboBCty.Size = New System.Drawing.Size(342, 21)
        Me.cboBCty.TabIndex = 286
        '
        'txtBilstt
        '
        Me.txtBilstt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtBilstt.Location = New System.Drawing.Point(121, 189)
        Me.txtBilstt.MaxLength = 10
        Me.txtBilstt.Name = "txtBilstt"
        Me.txtBilstt.Size = New System.Drawing.Size(120, 20)
        Me.txtBilstt.TabIndex = 281
        '
        'txtBilAdr
        '
        Me.txtBilAdr.Location = New System.Drawing.Point(120, 20)
        Me.txtBilAdr.Name = "txtBilAdr"
        Me.txtBilAdr.Size = New System.Drawing.Size(342, 125)
        Me.txtBilAdr.TabIndex = 281
        Me.txtBilAdr.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label58)
        Me.GroupBox1.Controls.Add(Me.txtTtlAmt)
        Me.GroupBox1.Controls.Add(Me.cboPrcTrm)
        Me.GroupBox1.Controls.Add(Me.cboPayTrm)
        Me.GroupBox1.Controls.Add(Me.txtTtlUnt)
        Me.GroupBox1.Controls.Add(Me.txtRmk)
        Me.GroupBox1.Location = New System.Drawing.Point(490, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(436, 462)
        Me.GroupBox1.TabIndex = 267
        Me.GroupBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 12)
        Me.Label9.TabIndex = 366
        Me.Label9.Text = "Remarks :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 86)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 12)
        Me.Label11.TabIndex = 365
        Me.Label11.Text = "Total Amount :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 52)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 12)
        Me.Label12.TabIndex = 364
        Me.Label12.Text = "Payment Terms :"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(17, 22)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(66, 12)
        Me.Label58.TabIndex = 363
        Me.Label58.Text = "Price Terms :"
        '
        'txtTtlAmt
        '
        Me.txtTtlAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTtlAmt.Location = New System.Drawing.Point(186, 81)
        Me.txtTtlAmt.MaxLength = 10
        Me.txtTtlAmt.Name = "txtTtlAmt"
        Me.txtTtlAmt.Size = New System.Drawing.Size(64, 20)
        Me.txtTtlAmt.TabIndex = 288
        '
        'cboPrcTrm
        '
        Me.cboPrcTrm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboPrcTrm.FormattingEnabled = True
        Me.cboPrcTrm.Location = New System.Drawing.Point(116, 16)
        Me.cboPrcTrm.Name = "cboPrcTrm"
        Me.cboPrcTrm.Size = New System.Drawing.Size(314, 21)
        Me.cboPrcTrm.TabIndex = 287
        '
        'cboPayTrm
        '
        Me.cboPayTrm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboPayTrm.FormattingEnabled = True
        Me.cboPayTrm.Location = New System.Drawing.Point(116, 49)
        Me.cboPayTrm.Name = "cboPayTrm"
        Me.cboPayTrm.Size = New System.Drawing.Size(314, 21)
        Me.cboPayTrm.TabIndex = 286
        '
        'txtTtlUnt
        '
        Me.txtTtlUnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTtlUnt.Location = New System.Drawing.Point(116, 81)
        Me.txtTtlUnt.MaxLength = 10
        Me.txtTtlUnt.Name = "txtTtlUnt"
        Me.txtTtlUnt.Size = New System.Drawing.Size(64, 20)
        Me.txtTtlUnt.TabIndex = 281
        '
        'txtRmk
        '
        Me.txtRmk.Location = New System.Drawing.Point(116, 114)
        Me.txtRmk.Name = "txtRmk"
        Me.txtRmk.Size = New System.Drawing.Size(314, 192)
        Me.txtRmk.TabIndex = 281
        Me.txtRmk.Text = ""
        '
        'gbPri
        '
        Me.gbPri.Controls.Add(Me.Label4)
        Me.gbPri.Controls.Add(Me.Label3)
        Me.gbPri.Controls.Add(Me.chkSample)
        Me.gbPri.Controls.Add(Me.Label10)
        Me.gbPri.Controls.Add(Me.txtSecCus)
        Me.gbPri.Controls.Add(Me.txtRefNo)
        Me.gbPri.Controls.Add(Me.txtPrmCus)
        Me.gbPri.Location = New System.Drawing.Point(6, 14)
        Me.gbPri.Name = "gbPri"
        Me.gbPri.Size = New System.Drawing.Size(478, 124)
        Me.gbPri.TabIndex = 266
        Me.gbPri.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 12)
        Me.Label4.TabIndex = 358
        Me.Label4.Text = "Secondary Customer :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 12)
        Me.Label3.TabIndex = 357
        Me.Label3.Text = "Primary Customer :"
        '
        'chkSample
        '
        Me.chkSample.AutoSize = True
        Me.chkSample.Location = New System.Drawing.Point(307, 22)
        Me.chkSample.Name = "chkSample"
        Me.chkSample.Size = New System.Drawing.Size(58, 16)
        Me.chkSample.TabIndex = 356
        Me.chkSample.Text = "Sample"
        Me.chkSample.UseVisualStyleBackColor = True
        Me.chkSample.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Green
        Me.Label10.Location = New System.Drawing.Point(16, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 12)
        Me.Label10.TabIndex = 282
        Me.Label10.Text = "Invoice#"
        '
        'txtSecCus
        '
        Me.txtSecCus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSecCus.Location = New System.Drawing.Point(148, 82)
        Me.txtSecCus.MaxLength = 10
        Me.txtSecCus.Name = "txtSecCus"
        Me.txtSecCus.Size = New System.Drawing.Size(227, 20)
        Me.txtSecCus.TabIndex = 266
        '
        'txtRefNo
        '
        Me.txtRefNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtRefNo.Location = New System.Drawing.Point(148, 22)
        Me.txtRefNo.MaxLength = 10
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(123, 20)
        Me.txtRefNo.TabIndex = 265
        '
        'txtPrmCus
        '
        Me.txtPrmCus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPrmCus.Location = New System.Drawing.Point(148, 52)
        Me.txtPrmCus.MaxLength = 10
        Me.txtPrmCus.Name = "txtPrmCus"
        Me.txtPrmCus.Size = New System.Drawing.Size(228, 20)
        Me.txtPrmCus.TabIndex = 104
        '
        'tpSHM00002_2
        '
        Me.tpSHM00002_2.Controls.Add(Me.fmeDetail)
        Me.tpSHM00002_2.Location = New System.Drawing.Point(4, 22)
        Me.tpSHM00002_2.Name = "tpSHM00002_2"
        Me.tpSHM00002_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSHM00002_2.Size = New System.Drawing.Size(946, 483)
        Me.tpSHM00002_2.TabIndex = 1
        Me.tpSHM00002_2.Text = "(2)Details"
        Me.tpSHM00002_2.UseVisualStyleBackColor = True
        '
        'fmeDetail
        '
        Me.fmeDetail.Controls.Add(Me.txtShpAmt)
        Me.fmeDetail.Controls.Add(Me.txtCurCde3)
        Me.fmeDetail.Controls.Add(Me.txtout)
        Me.fmeDetail.Controls.Add(Me.txtdeb)
        Me.fmeDetail.Controls.Add(Me.txtInvLne)
        Me.fmeDetail.Controls.Add(Me.txtcre)
        Me.fmeDetail.Controls.Add(Me.txtShpQty)
        Me.fmeDetail.Controls.Add(Me.ordqty)
        Me.fmeDetail.Controls.Add(Me.shpqty)
        Me.fmeDetail.Controls.Add(Me.txtSelPrc)
        Me.fmeDetail.Controls.Add(Me.txtCurCde2)
        Me.fmeDetail.Controls.Add(Me.Label36)
        Me.fmeDetail.Controls.Add(Me.Label35)
        Me.fmeDetail.Controls.Add(Me.Label34)
        Me.fmeDetail.Controls.Add(Me.Label33)
        Me.fmeDetail.Controls.Add(Me.Label32)
        Me.fmeDetail.Controls.Add(Me.chkDel)
        Me.fmeDetail.Controls.Add(Me.Label28)
        Me.fmeDetail.Controls.Add(Me.Label27)
        Me.fmeDetail.Controls.Add(Me.Label26)
        Me.fmeDetail.Controls.Add(Me.Label25)
        Me.fmeDetail.Controls.Add(Me.Label24)
        Me.fmeDetail.Controls.Add(Me.txtManAdr)
        Me.fmeDetail.Controls.Add(Me.txtManNam)
        Me.fmeDetail.Controls.Add(Me.txtCusSku)
        Me.fmeDetail.Controls.Add(Me.Label23)
        Me.fmeDetail.Controls.Add(Me.txtColCde)
        Me.fmeDetail.Controls.Add(Me.Label22)
        Me.fmeDetail.Controls.Add(Me.txtItmNo)
        Me.fmeDetail.Controls.Add(Me.Label21)
        Me.fmeDetail.Controls.Add(Me.txtSeq)
        Me.fmeDetail.Controls.Add(Me.optMsc)
        Me.fmeDetail.Controls.Add(Me.optItm)
        Me.fmeDetail.Controls.Add(Me.GroupBox5)
        Me.fmeDetail.Controls.Add(Me.Label13)
        Me.fmeDetail.Controls.Add(Me.CmdDtlNext)
        Me.fmeDetail.Controls.Add(Me.CmdDtlPre)
        Me.fmeDetail.Controls.Add(Me.Label14)
        Me.fmeDetail.Controls.Add(Me.Label15)
        Me.fmeDetail.Controls.Add(Me.Label16)
        Me.fmeDetail.Controls.Add(Me.txtCusItm)
        Me.fmeDetail.Controls.Add(Me.cboPckInf)
        Me.fmeDetail.Controls.Add(Me.txtColDsc)
        Me.fmeDetail.Controls.Add(Me.txtItmDsc)
        Me.fmeDetail.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fmeDetail.Location = New System.Drawing.Point(8, 6)
        Me.fmeDetail.Name = "fmeDetail"
        Me.fmeDetail.Size = New System.Drawing.Size(932, 479)
        Me.fmeDetail.TabIndex = 321
        Me.fmeDetail.TabStop = False
        Me.fmeDetail.Text = "Detail Information"
        '
        'txtShpAmt
        '
        Me.txtShpAmt.Enabled = False
        Me.txtShpAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtShpAmt.Location = New System.Drawing.Point(618, 90)
        Me.txtShpAmt.MaxLength = 10
        Me.txtShpAmt.Name = "txtShpAmt"
        Me.txtShpAmt.Size = New System.Drawing.Size(96, 20)
        Me.txtShpAmt.TabIndex = 404
        '
        'txtCurCde3
        '
        Me.txtCurCde3.Enabled = False
        Me.txtCurCde3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCurCde3.Location = New System.Drawing.Point(570, 90)
        Me.txtCurCde3.MaxLength = 10
        Me.txtCurCde3.Name = "txtCurCde3"
        Me.txtCurCde3.Size = New System.Drawing.Size(43, 20)
        Me.txtCurCde3.TabIndex = 403
        '
        'txtout
        '
        Me.txtout.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtout.Location = New System.Drawing.Point(738, 26)
        Me.txtout.MaxLength = 10
        Me.txtout.Name = "txtout"
        Me.txtout.Size = New System.Drawing.Size(34, 20)
        Me.txtout.TabIndex = 402
        Me.txtout.Visible = False
        '
        'txtdeb
        '
        Me.txtdeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtdeb.Location = New System.Drawing.Point(695, 26)
        Me.txtdeb.MaxLength = 10
        Me.txtdeb.Name = "txtdeb"
        Me.txtdeb.Size = New System.Drawing.Size(34, 20)
        Me.txtdeb.TabIndex = 401
        Me.txtdeb.Visible = False
        '
        'txtInvLne
        '
        Me.txtInvLne.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtInvLne.Location = New System.Drawing.Point(795, 24)
        Me.txtInvLne.MaxLength = 10
        Me.txtInvLne.Name = "txtInvLne"
        Me.txtInvLne.Size = New System.Drawing.Size(56, 20)
        Me.txtInvLne.TabIndex = 400
        Me.txtInvLne.Visible = False
        '
        'txtcre
        '
        Me.txtcre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtcre.Location = New System.Drawing.Point(653, 26)
        Me.txtcre.MaxLength = 10
        Me.txtcre.Name = "txtcre"
        Me.txtcre.Size = New System.Drawing.Size(34, 20)
        Me.txtcre.TabIndex = 397
        Me.txtcre.Visible = False
        '
        'txtShpQty
        '
        Me.txtShpQty.Enabled = False
        Me.txtShpQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtShpQty.Location = New System.Drawing.Point(570, 31)
        Me.txtShpQty.MaxLength = 10
        Me.txtShpQty.Name = "txtShpQty"
        Me.txtShpQty.Size = New System.Drawing.Size(66, 20)
        Me.txtShpQty.TabIndex = 396
        '
        'ordqty
        '
        Me.ordqty.Enabled = False
        Me.ordqty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ordqty.Location = New System.Drawing.Point(795, 90)
        Me.ordqty.MaxLength = 10
        Me.ordqty.Name = "ordqty"
        Me.ordqty.Size = New System.Drawing.Size(66, 20)
        Me.ordqty.TabIndex = 395
        '
        'shpqty
        '
        Me.shpqty.Enabled = False
        Me.shpqty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.shpqty.Location = New System.Drawing.Point(795, 60)
        Me.shpqty.MaxLength = 10
        Me.shpqty.Name = "shpqty"
        Me.shpqty.Size = New System.Drawing.Size(66, 20)
        Me.shpqty.TabIndex = 394
        '
        'txtSelPrc
        '
        Me.txtSelPrc.Enabled = False
        Me.txtSelPrc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSelPrc.Location = New System.Drawing.Point(618, 60)
        Me.txtSelPrc.MaxLength = 10
        Me.txtSelPrc.Name = "txtSelPrc"
        Me.txtSelPrc.Size = New System.Drawing.Size(96, 20)
        Me.txtSelPrc.TabIndex = 393
        '
        'txtCurCde2
        '
        Me.txtCurCde2.Enabled = False
        Me.txtCurCde2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCurCde2.Location = New System.Drawing.Point(570, 60)
        Me.txtCurCde2.MaxLength = 10
        Me.txtCurCde2.Name = "txtCurCde2"
        Me.txtCurCde2.Size = New System.Drawing.Size(43, 20)
        Me.txtCurCde2.TabIndex = 391
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(746, 94)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(36, 12)
        Me.Label36.TabIndex = 389
        Me.Label36.Text = "ordqty"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(744, 65)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(36, 12)
        Me.Label35.TabIndex = 388
        Me.Label35.Text = "shpqty"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(470, 91)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(90, 12)
        Me.Label34.TabIndex = 387
        Me.Label34.Text = "Shipped Amount :"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(470, 61)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(69, 12)
        Me.Label33.TabIndex = 386
        Me.Label33.Text = "Selling Price :"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(470, 32)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(69, 12)
        Me.Label32.TabIndex = 385
        Me.Label32.Text = "Shipped Qty :"
        '
        'chkDel
        '
        Me.chkDel.AutoSize = True
        Me.chkDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkDel.Location = New System.Drawing.Point(714, 445)
        Me.chkDel.Name = "chkDel"
        Me.chkDel.Size = New System.Drawing.Size(149, 17)
        Me.chkDel.TabIndex = 384
        Me.chkDel.Text = "Delete (Checked if delete)"
        Me.chkDel.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(22, 334)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(114, 12)
        Me.Label28.TabIndex = 383
        Me.Label28.Text = "Manufacturer Address :"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(23, 288)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(90, 12)
        Me.Label27.TabIndex = 382
        Me.Label27.Text = "Customer SKU # :"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(23, 262)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(89, 12)
        Me.Label26.TabIndex = 381
        Me.Label26.Text = "Customer Item # :"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(23, 236)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(94, 12)
        Me.Label25.TabIndex = 380
        Me.Label25.Text = "Color Description :"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(23, 147)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(88, 12)
        Me.Label24.TabIndex = 379
        Me.Label24.Text = "Item Description :"
        '
        'txtManAdr
        '
        Me.txtManAdr.Enabled = False
        Me.txtManAdr.Location = New System.Drawing.Point(151, 330)
        Me.txtManAdr.Name = "txtManAdr"
        Me.txtManAdr.Size = New System.Drawing.Size(294, 98)
        Me.txtManAdr.TabIndex = 378
        Me.txtManAdr.Text = ""
        '
        'txtManNam
        '
        Me.txtManNam.Enabled = False
        Me.txtManNam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtManNam.Location = New System.Drawing.Point(151, 304)
        Me.txtManNam.MaxLength = 10
        Me.txtManNam.Name = "txtManNam"
        Me.txtManNam.Size = New System.Drawing.Size(294, 20)
        Me.txtManNam.TabIndex = 377
        '
        'txtCusSku
        '
        Me.txtCusSku.Enabled = False
        Me.txtCusSku.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCusSku.Location = New System.Drawing.Point(151, 279)
        Me.txtCusSku.MaxLength = 10
        Me.txtCusSku.Name = "txtCusSku"
        Me.txtCusSku.Size = New System.Drawing.Size(294, 20)
        Me.txtCusSku.TabIndex = 376
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(160, 98)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(132, 12)
        Me.Label23.TabIndex = 375
        Me.Label23.Text = "UM / Inner / Master / CBM"
        '
        'txtColCde
        '
        Me.txtColCde.Enabled = False
        Me.txtColCde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtColCde.Location = New System.Drawing.Point(333, 58)
        Me.txtColCde.MaxLength = 40
        Me.txtColCde.Name = "txtColCde"
        Me.txtColCde.Size = New System.Drawing.Size(75, 20)
        Me.txtColCde.TabIndex = 374
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(259, 61)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(66, 12)
        Me.Label22.TabIndex = 373
        Me.Label22.Text = "Color Code :"
        '
        'txtItmNo
        '
        Me.txtItmNo.Enabled = False
        Me.txtItmNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmNo.Location = New System.Drawing.Point(103, 57)
        Me.txtItmNo.MaxLength = 30
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(140, 20)
        Me.txtItmNo.TabIndex = 372
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(29, 58)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(41, 12)
        Me.Label21.TabIndex = 371
        Me.Label21.Text = "Item # :"
        '
        'txtSeq
        '
        Me.txtSeq.Enabled = False
        Me.txtSeq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSeq.Location = New System.Drawing.Point(103, 33)
        Me.txtSeq.MaxLength = 10
        Me.txtSeq.Name = "txtSeq"
        Me.txtSeq.Size = New System.Drawing.Size(56, 20)
        Me.txtSeq.TabIndex = 370
        '
        'optMsc
        '
        Me.optMsc.AutoSize = True
        Me.optMsc.Location = New System.Drawing.Point(348, 32)
        Me.optMsc.Name = "optMsc"
        Me.optMsc.Size = New System.Drawing.Size(45, 16)
        Me.optMsc.TabIndex = 369
        Me.optMsc.TabStop = True
        Me.optMsc.Text = "&Misc"
        Me.optMsc.UseVisualStyleBackColor = True
        '
        'optItm
        '
        Me.optItm.AutoSize = True
        Me.optItm.Location = New System.Drawing.Point(295, 32)
        Me.optItm.Name = "optItm"
        Me.optItm.Size = New System.Drawing.Size(44, 16)
        Me.optItm.TabIndex = 368
        Me.optItm.TabStop = True
        Me.optItm.Text = "&Item"
        Me.optItm.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtPO)
        Me.GroupBox5.Controls.Add(Me.Label31)
        Me.GroupBox5.Controls.Add(Me.chkUpd)
        Me.GroupBox5.Controls.Add(Me.txtAdjQty)
        Me.GroupBox5.Controls.Add(Me.txtAdjPrc)
        Me.GroupBox5.Controls.Add(Me.txtSCNo)
        Me.GroupBox5.Controls.Add(Me.txtAdjAmt)
        Me.GroupBox5.Controls.Add(Me.Label30)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.txtCurCde4)
        Me.GroupBox5.Controls.Add(Me.cboSCNo)
        Me.GroupBox5.Controls.Add(Me.txtCurCde5)
        Me.GroupBox5.Controls.Add(Me.txtDRmk)
        Me.GroupBox5.Location = New System.Drawing.Point(451, 134)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(412, 294)
        Me.GroupBox5.TabIndex = 367
        Me.GroupBox5.TabStop = False
        '
        'txtPO
        '
        Me.txtPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPO.Location = New System.Drawing.Point(337, 17)
        Me.txtPO.MaxLength = 10
        Me.txtPO.Name = "txtPO"
        Me.txtPO.Size = New System.Drawing.Size(66, 20)
        Me.txtPO.TabIndex = 376
        Me.txtPO.Visible = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(21, 19)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(67, 12)
        Me.Label31.TabIndex = 375
        Me.Label31.Text = "Updated SC :"
        '
        'chkUpd
        '
        Me.chkUpd.AutoSize = True
        Me.chkUpd.Enabled = False
        Me.chkUpd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkUpd.Location = New System.Drawing.Point(113, 19)
        Me.chkUpd.Name = "chkUpd"
        Me.chkUpd.Size = New System.Drawing.Size(15, 14)
        Me.chkUpd.TabIndex = 374
        Me.chkUpd.UseVisualStyleBackColor = True
        '
        'txtAdjQty
        '
        Me.txtAdjQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtAdjQty.Location = New System.Drawing.Point(123, 40)
        Me.txtAdjQty.MaxLength = 10
        Me.txtAdjQty.Name = "txtAdjQty"
        Me.txtAdjQty.Size = New System.Drawing.Size(66, 20)
        Me.txtAdjQty.TabIndex = 372
        '
        'txtAdjPrc
        '
        Me.txtAdjPrc.Enabled = False
        Me.txtAdjPrc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtAdjPrc.Location = New System.Drawing.Point(178, 67)
        Me.txtAdjPrc.MaxLength = 10
        Me.txtAdjPrc.Name = "txtAdjPrc"
        Me.txtAdjPrc.Size = New System.Drawing.Size(99, 20)
        Me.txtAdjPrc.TabIndex = 371
        '
        'txtSCNo
        '
        Me.txtSCNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSCNo.Location = New System.Drawing.Point(287, 95)
        Me.txtSCNo.MaxLength = 10
        Me.txtSCNo.Name = "txtSCNo"
        Me.txtSCNo.Size = New System.Drawing.Size(88, 20)
        Me.txtSCNo.TabIndex = 370
        Me.txtSCNo.Visible = False
        '
        'txtAdjAmt
        '
        Me.txtAdjAmt.Enabled = False
        Me.txtAdjAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtAdjAmt.Location = New System.Drawing.Point(179, 95)
        Me.txtAdjAmt.MaxLength = 10
        Me.txtAdjAmt.Name = "txtAdjAmt"
        Me.txtAdjAmt.Size = New System.Drawing.Size(99, 20)
        Me.txtAdjAmt.TabIndex = 369
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.ForeColor = System.Drawing.Color.Green
        Me.Label30.Location = New System.Drawing.Point(21, 42)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(72, 12)
        Me.Label30.TabIndex = 368
        Me.Label30.Text = "Adjusted Qty :"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.ForeColor = System.Drawing.Color.Green
        Me.Label29.Location = New System.Drawing.Point(21, 96)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(93, 12)
        Me.Label29.TabIndex = 367
        Me.Label29.Text = "Adjusted Amount :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(23, 131)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 12)
        Me.Label17.TabIndex = 366
        Me.Label17.Text = "Remarks :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(21, 70)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 12)
        Me.Label19.TabIndex = 364
        Me.Label19.Text = "Adjusted Price :"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(181, 21)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 12)
        Me.Label20.TabIndex = 363
        Me.Label20.Text = "SC No :"
        '
        'txtCurCde4
        '
        Me.txtCurCde4.Enabled = False
        Me.txtCurCde4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCurCde4.Location = New System.Drawing.Point(123, 67)
        Me.txtCurCde4.MaxLength = 10
        Me.txtCurCde4.Name = "txtCurCde4"
        Me.txtCurCde4.Size = New System.Drawing.Size(47, 20)
        Me.txtCurCde4.TabIndex = 288
        '
        'cboSCNo
        '
        Me.cboSCNo.Enabled = False
        Me.cboSCNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboSCNo.FormattingEnabled = True
        Me.cboSCNo.Location = New System.Drawing.Point(231, 18)
        Me.cboSCNo.Name = "cboSCNo"
        Me.cboSCNo.Size = New System.Drawing.Size(89, 21)
        Me.cboSCNo.TabIndex = 287
        '
        'txtCurCde5
        '
        Me.txtCurCde5.Enabled = False
        Me.txtCurCde5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCurCde5.Location = New System.Drawing.Point(123, 95)
        Me.txtCurCde5.MaxLength = 10
        Me.txtCurCde5.Name = "txtCurCde5"
        Me.txtCurCde5.Size = New System.Drawing.Size(47, 20)
        Me.txtCurCde5.TabIndex = 281
        '
        'txtDRmk
        '
        Me.txtDRmk.Location = New System.Drawing.Point(123, 130)
        Me.txtDRmk.Name = "txtDRmk"
        Me.txtDRmk.Size = New System.Drawing.Size(275, 144)
        Me.txtDRmk.TabIndex = 281
        Me.txtDRmk.Text = ""
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(23, 310)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 12)
        Me.Label13.TabIndex = 366
        Me.Label13.Text = "Manufacturer Name :"
        '
        'CmdDtlNext
        '
        Me.CmdDtlNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CmdDtlNext.Location = New System.Drawing.Point(554, 439)
        Me.CmdDtlNext.Name = "CmdDtlNext"
        Me.CmdDtlNext.Size = New System.Drawing.Size(48, 27)
        Me.CmdDtlNext.TabIndex = 320
        Me.CmdDtlNext.TabStop = False
        Me.CmdDtlNext.Text = "&Next"
        '
        'CmdDtlPre
        '
        Me.CmdDtlPre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CmdDtlPre.Location = New System.Drawing.Point(486, 439)
        Me.CmdDtlPre.Name = "CmdDtlPre"
        Me.CmdDtlPre.Size = New System.Drawing.Size(48, 27)
        Me.CmdDtlPre.TabIndex = 319
        Me.CmdDtlPre.TabStop = False
        Me.CmdDtlPre.Text = "&Back"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(23, 114)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 12)
        Me.Label14.TabIndex = 365
        Me.Label14.Text = "Packing Info. :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(214, 34)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 12)
        Me.Label15.TabIndex = 364
        Me.Label15.Text = "Line Type :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(29, 34)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 12)
        Me.Label16.TabIndex = 363
        Me.Label16.Text = "Seq No.:"
        '
        'txtCusItm
        '
        Me.txtCusItm.Enabled = False
        Me.txtCusItm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCusItm.Location = New System.Drawing.Point(151, 255)
        Me.txtCusItm.MaxLength = 10
        Me.txtCusItm.Name = "txtCusItm"
        Me.txtCusItm.Size = New System.Drawing.Size(294, 20)
        Me.txtCusItm.TabIndex = 288
        '
        'cboPckInf
        '
        Me.cboPckInf.Enabled = False
        Me.cboPckInf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboPckInf.FormattingEnabled = True
        Me.cboPckInf.Location = New System.Drawing.Point(151, 113)
        Me.cboPckInf.Name = "cboPckInf"
        Me.cboPckInf.Size = New System.Drawing.Size(294, 21)
        Me.cboPckInf.TabIndex = 287
        '
        'txtColDsc
        '
        Me.txtColDsc.Enabled = False
        Me.txtColDsc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtColDsc.Location = New System.Drawing.Point(151, 229)
        Me.txtColDsc.MaxLength = 10
        Me.txtColDsc.Name = "txtColDsc"
        Me.txtColDsc.Size = New System.Drawing.Size(294, 20)
        Me.txtColDsc.TabIndex = 281
        '
        'txtItmDsc
        '
        Me.txtItmDsc.Enabled = False
        Me.txtItmDsc.Location = New System.Drawing.Point(151, 139)
        Me.txtItmDsc.Name = "txtItmDsc"
        Me.txtItmDsc.Size = New System.Drawing.Size(294, 78)
        Me.txtItmDsc.TabIndex = 281
        Me.txtItmDsc.Text = ""
        '
        'SHM00002
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.DTRevDat)
        Me.Controls.Add(Me.DTIssDat)
        Me.Controls.Add(Me.cboCDStatus)
        Me.Controls.Add(Me.optDebit)
        Me.Controls.Add(Me.optCredit)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.lblQutSts)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNoteNo)
        Me.Controls.Add(Me.lblRvsDat)
        Me.Controls.Add(Me.lblIssDat)
        Me.Controls.Add(Me.lblQutNo)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btcSHM00002)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.Label18)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuStrip
        Me.MaximizeBox = False
        Me.Name = "SHM00002"
        Me.Text = "SHM00002- Credit / Debit Note Information (SHM02)"
        Me.cms_CopyNPaste.ResumeLayout(False)
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.btcSHM00002.ResumeLayout(False)
        Me.tpSHM00002_1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbPri.ResumeLayout(False)
        Me.gbPri.PerformLayout()
        Me.tpSHM00002_2.ResumeLayout(False)
        Me.fmeDetail.ResumeLayout(False)
        Me.fmeDetail.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Dim addition As String
    Dim UserEditCombo As Boolean
    Dim Recorddisplay As Boolean
    Dim sCheckedLevel As String = "C"

    Public rs_CUBASINF_P As New DataSet
    Public rs_CUBASINF_P_SALES As New DataSet
    Public rs_CUBASINF_S As New DataSet
    Public rs_CUBASINF_S_All As New DataSet
    Public rs_VNBASINF As New DataSet
    Public rs_SYUSRRIGHT_0 As New DataSet
    Public rs_SYUSRRIGHT_except_0 As New DataSet


    Public rs_Currency As New DataSet
    Public rs_SYCOMINF As New DataSet
    Public rs_DOC_GEN As New DataSet
    Public rs_SYCUREX As New DataSet

    Dim ApprovalLimitPer As Decimal = 1.0
    Dim ApprovalRights As Boolean
    Dim SuperApprovalRights As Boolean

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    'Check for update or read mode
    Dim nHdrSearchBy As Integer
    Dim readingindex As Integer


    Private Sub shm00002_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'on error resume next

        'call formstartup(me.name)

        '#if usemts then
        '        set objbsgate = createobject("ucpbs_gate.clsbsgate", servername)
        '#else
        '        objbsgate = createobject("ucpbs_gate.clsbsgate")
        '#end if

        'if gsconnstr = "" then
        '    gsconnstr = getconnectionstring()
        'end if
        Formstartup(Me.Name)
        Call FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        Call GetDefaultCompany(cboCoCde, txtCoNam)


        cboCDStatus.Items.Clear()

        cboCDStatus.Items.Add("OPE - OPEN")
        cboCDStatus.Items.Add("CLO - Closed")
        cboCDStatus.Items.Add("REL - RELEASE")
        cboCDStatus.Items.Add("HLD - HOLD")

        'me.cbococde.clear()

        'call fillcompcombo(gsusrid, me)         'get availble company
        'call getdefaultcompany(me)

        If Trim(Me.cboCoCde.Text) = "" Then
        End If


        'accessright_1(me.name) '*** for access right use, added by 'tommy on 5 'oct 2001 change by lewis on 2 jul 2003


        Call fillParameter()
        Timer1.Enabled = False

        'timer1.enabled = false

        Me.KeyPreview = True

        btcSHM00002.SelectedIndex = 0

        Call setStatus("init")


        'add current date and user by lewis on 26/03/2003 ******************
        'lester wu 2005-03-14 , amend the datetime format to "mm/dd/yyyy"
        'statusbar.panels(2).text = format(date, "dd/mm/yyyy") & " " & format(date, "dd/mm/yyyy") & _
        '                         " " & gsusrid
        ''''''''''''''''''''''''''''''    StatusBar.Panels(2).Text = Format(Date.Today, "mm/dd/yyyy").ToString & " " & Format(Date.Today, "mm/dd/yyyy").ToString & _
        '''''''''''''''''''                 " " & gsUsrID

        txtCoNam.BackColor = Color.White

        Cursor = Cursors.Default
    End Sub

    Private Sub ClearScreen()

        cboCDStatus.Text = ""
        '        Call DisplayCombo(cboCDStatus, "")

        DTIssDat.Text = Format(Date.Today, "mm/dd/yyyy").ToString
        DTRevDat.Text = Format(Date.Today, "mm/dd/yyyy").ToString

        optCredit.Checked = True
        optDebit.Checked = False

        txtRefNo.Text = ""

        txtPrmCus.Text = ""
        txtSecCus.Text = ""
        txtBilAdr.Text = ""
        cboBCty.Text = ""

        'Call DisplayCombo(cboBCty, "")


        txtBilStt.Text = ""
        txtBilZip.Text = ""
        cboPrcTrm.Text = ""
        '        Call DisplayCombo(cboPrcTrm, "")
        cboPayTrm.Text = ""
        '       Call DisplayCombo(cboPayTrm, "")

        txtTtlUnt.Text = ""
        txtTtlAmt.Text = ""

        txtRmk.Text = ""

        txtSeq.Text = ""

        txtItmNo.Text = ""
        txtColCde.Text = ""
        cboPckInf.Items.Clear()

        

        txtItmDsc.Text = ""
        txtColDsc.Text = ""
        txtCusItm.Text = ""
        txtCusSku.Text = ""
        txtManNam.Text = ""
        txtManAdr.Text = ""
        txtShpQty.Text = "0"
        txtCurCde2.Text = ""
        txtSelprc.Text = "0"
        txtCurCde3.Text = ""
        txtShpAmt.Text = "0"
        'txtAdjQty.Text = "0"
        txtCurCde4.Text = ""
        'txtAdjPrc.Text = "0"
        txtCurCde5.Text = ""
        txtAdjAmt.Text = "0"

        chkUpd.Checked = False
        txtSCNo.Text = ""
        txtPO.Text = ""
        txtDRmk.Text = ""
        txtRmk.MaxLength = 200
        txtDRmk.MaxLength = 200


    End Sub

    Private Sub Display()

        If rs_SHCBNHDR.Tables("result").Rows.Count = 0 Then
            Exit Sub
        End If
        Call display_combo(Trim(rs_SHCBNHDR.Tables("result").Rows(0)("hnh_notsts")), cboCDStatus)
        DTIssDat.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_credat")
        DTRevDat.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_issdat")
        If rs_SHCBNHDR.Tables("result").Rows(0)("hnh_nottyp") = "C" Then
            optCredit.Checked = True
            optDebit.Checked = False
        Else
            optDebit.Checked = True
            optCredit.Checked = False
        End If
        optCredit.Enabled = False
        optDebit.Enabled = False
        txtRefNo.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_refno")
        Call QueryShipInfo()
        rs_CUBASINF.Tables("result").DefaultView.rowFilter = "cbi_cusno ='" & rs_SHCBNHDR.Tables("result").Rows(0)("hnh_pricus") & "'"
        If rs_CUBASINF.Tables("result").Rows.Count <> 0 Then
            '  rs_CUBASINF.MoveFirst()
            txtPrmCus.Text = rs_CUBASINF.Tables("result").DefaultView(0)("cbi_cusno") & " - " & rs_CUBASINF.Tables("result").DefaultView(0)("cbi_cussna")
        End If

        rs_CUBASINF.Tables("result").DefaultView.rowFilter = "cbi_cusno ='" & rs_SHCBNHDR.Tables("result").Rows(0)("hnh_seccus") & "'"
        If rs_CUBASINF.Tables("result").DefaultView.Count <> 0 Then
            '     rs_CUBASINF.MoveFirst()
            txtSecCus.Text = rs_CUBASINF.Tables("result").DefaultView(0)("cbi_cusno") & " - " & rs_CUBASINF.Tables("result").DefaultView(0)("cbi_cussna")
        End If


        txtBilAdr.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_biladr")

        Call display_combo(Trim(rs_SHCBNHDR.Tables("result").Rows(0)("hnh_bilcty")), cboBCty)
        Call display_combo("US", cboBCty)
        txtBilstt.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_bilstt")
        txtBilZip.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_bilzip")

        'txtShpAdr.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_shpadr")
        'Call display_combo(cboSCty, rs_SHCBNHDR.Tables("result").Rows(0)("hnh_shpcty"))
        'txtShpStt.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_shpstt")
        'txtShpZip.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_shpzip")

        Call display_combo(Trim(rs_SHCBNHDR.Tables("result").Rows(0)("hnh_prctrm")), cboPrcTrm)
        Call display_combo(Trim(rs_SHCBNHDR.Tables("result").Rows(0)("hnh_paytrm")), cboPayTrm)

        txtTtlUnt.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_ttlunt")
        txtTtlAmt.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_ttlamt")


        txtRmk.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_rmk")

        If Not rs_SHCBNDTL.Tables("result") Is Nothing Then
            If rs_SHCBNDTL.Tables("result").Rows.Count > 0 Then
                MaxSeq = rs_SHCBNDTL.Tables("result").Rows(0)("max_seq")
                '         rs_SHCBNDTL.MoveFirst()

                Call DisplayDetail()

                optItm.Enabled = True
                optMsc.Enabled = True

                If readingindex > 0 Then
                    CmdDtlPre.Enabled = True

                Else
                    CmdDtlPre.Enabled = False
                End If

                If readingindex = rs_SHCBNDTL.Tables("result").Rows.Count - 1 Then
                    CmdDtlNext.Enabled = False
                Else
                    CmdDtlNext.Enabled = True
                End If
                ''''''''''''StatusBar.Panels(2).Text = Format(rs_SHCBNHDR.Tables("result").Rows(0)("hnh_credat"), "DD/MM/YYYY") & " " & Format(rs_SHCBNHDR.Tables("result").Rows(0)("hnh_upddat"), "DD/MM/YYYY") & _
                '                   " " & rs_SHCBNHDR.Tables("result").Rows(0)("hnh_updusr")


            Else
                MaxSeq = 0
            End If

        End If


    End Sub

    Private Sub SHM00002_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        Dim YesNoCancel As Integer
        If Recordstatus = True And txtNoteNo.Enabled = False Then

            YesNoCancel = MsgBox("Do you want to save before exit?", MsgBoxStyle.YesNoCancel)


            If YesNoCancel = vbYes Then
                If mmdSave.Enabled Then
                    flag_exit = True
                    Call cmdSaveClick()
                    If save_ok = True Then
                        Me.Close()
                    Else
                        flag_exit = False
                        '   Cancel = True
                        Exit Sub
                    End If
                Else
                    flag_exit = False
                    MsgBox("M00253")
                    'Cancel = True
                    Exit Sub
                End If

            ElseIf YesNoCancel = vbNo Then
                'Call ResetDefaultDisp
                Me.Close()

            ElseIf YesNoCancel = vbCancel Then
                flag_exit = False
                ' Cancel = True
                Exit Sub
            End If
        Else
            Me.Close()
        End If
        Recordstatus = False

    End Sub


    '    'Take out the filling process from form load to be a Sub-routine for for by change comany
    Private Sub fillParameter()
        Dim systype As String

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        systype = "02" '***  
        gspStr = "sp_select_SYSETINF '', '" & systype & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF, rtnStr)
        gspStr = ""

        '''''' Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading fillParameter sp_select_SYSETINFC :" & rtnStr)
            Exit Sub
        End If

        If rs_SYSETINF.Tables("RESULT").Rows.Count > 0 Then

            cboBCty.Items.Clear()
            cboBCty.Text = ""

            dr = rs_SYSETINF.Tables("RESULT").Select("ysi_cde <> 'test'")

            If Not dr Is Nothing Then
                If dr.Length > 0 Then
                    For index As Integer = 0 To dr.Length - 1
                        cboBCty.Items.Add(Trim(dr(index)("ysi_cde")) + " - " + Trim(dr(index)("ysi_dsc")))
                    Next index
                End If
            End If
        Else
            MsgBox("There is no function, please contact EDP or System Administrator.")
            Exit Sub
        End If



        systype = "03" '*** For Price Terms
        gspStr = "sp_select_SYSETINF '', '" & systype & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF, rtnStr)
        gspStr = ""

        '''''' Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading fillParameter sp_select_SYSETINFC :" & rtnStr)
            Exit Sub
        End If

        If rs_SYSETINF.Tables("RESULT").Rows.Count > 0 Then

            cboPrcTrm.Items.Clear()
            cboPrcTrm.Text = ""

            dr = rs_SYSETINF.Tables("RESULT").Select("ysi_cde <> 'test'")

            If Not dr Is Nothing Then
                If dr.Length > 0 Then
                    For index As Integer = 0 To dr.Length - 1
                        cboPrcTrm.Items.Add(Trim(dr(index)("ysi_cde")) + " - " + Trim(dr(index)("ysi_dsc")))
                    Next index
                End If
            End If
        Else
            MsgBox("There is no function, please contact EDP or System Administrator.")
            Exit Sub
        End If


        systype = "04" '*** 
        gspStr = "sp_select_SYSETINF '', '" & systype & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF, rtnStr)
        gspStr = ""

        '''''' Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading fillParameter sp_select_SYSETINFC :" & rtnStr)
            Exit Sub
        End If

        If rs_SYSETINF.Tables("RESULT").Rows.Count > 0 Then

            cboPayTrm.Items.Clear()
            cboPayTrm.Text = ""

            dr = rs_SYSETINF.Tables("RESULT").Select("ysi_cde <> 'test'")

            If Not dr Is Nothing Then
                If dr.Length > 0 Then
                    For index As Integer = 0 To dr.Length - 1
                        cboPayTrm.Items.Add(Trim(dr(index)("ysi_cde")) + " - " + Trim(dr(index)("ysi_dsc")))
                    Next index
                End If
            End If
        Else
            MsgBox("There is no function, please contact EDP or System Administrator.")
            Exit Sub
        End If



        systype = "11" '*** 
        gspStr = "sp_select_SYSETINF '', '" & systype & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF, rtnStr)
        gspStr = ""

        '''''' Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading fillParameter sp_select_SYSETINFC :" & rtnStr)
            Exit Sub
        End If

        ''
        gspStr = "sp_list_CUBASINF '', 'A'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        gspStr = ""

        '''''' Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading fillParameter sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If



        '**************************************************************
        '*** Fill Combo box End ***************************************
        '**************************************************************

        '**************************************************************
        '*** Fill List box      ***************************************
        '**************************************************************



        '**************************************************************
        '*** Fill List box END  ***************************************
        '**************************************************************


    End Sub


    '    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click


    '        Dim S As String
    '        Dim i As Integer


    '        '        Call setStatus("ADD")
    '        txtNoteNo.Text = ""
    '        txtNoteNo.Enabled = False
    '        '        If cboCus1No.Items.Count > 0 Then cboCus1No_Click()
    '        '        If cboCus1No.Enabled And cboCus1No.Visible Then cboCus1No.Focus()

    '        txtRvsDat.Text = Format(Date.Today, "MM/dd/yyyy").ToString
    '        txtIssDat.Text = Format(Date.Today, "MM/dd/yyyy").ToString

    '        txtRefNo.Text = ""

    '        txtLcStmt.Text = "      " & Chr(34) & "DRAWN UNDER HK + SHANGHAI BANKING CORPORATION LTD. LETTER OF CREDIT NUMBER" & vbNewLine
    '        txtLcStmt.Text = txtLcStmt.Text & "       DC HKH914936 DATED 22 JUN,2010." & Chr(34) & vbNewLine
    '        txtLcStmt.Text = txtLcStmt.Text & vbNewLine
    '        txtLcStmt.Text = txtLcStmt.Text & "       WE HEREBY CERTIFY THAT:" & vbNewLine
    '        txtLcStmt.Text = txtLcStmt.Text & vbNewLine
    '        txtLcStmt.Text = txtLcStmt.Text & " (A). THAT PRODUCT(S) FROM SUPPLIERS/FACTORIES WERE NOT MINED," & vbNewLine
    '        txtLcStmt.Text = txtLcStmt.Text & "        PRODUCED, MANUFACTURED, ASSEMBLED OR PACKAGED BY THE USE" & vbNewLine
    '        txtLcStmt.Text = txtLcStmt.Text & "        OF EITHER FORCED LABOR, PRISON LABOR, OR CHILD LABOR" & vbNewLine
    '        txtLcStmt.Text = txtLcStmt.Text & "        AS DEFINED BY U.S.A. LAWS OR AS DEFINED BY THE RESPECTIVE" & vbNewLine
    '        txtLcStmt.Text = txtLcStmt.Text & "        LAWS OF THAT COUNTRY" & vbNewLine
    '        txtLcStmt.Text = txtLcStmt.Text & vbNewLine
    '        txtLcStmt.Text = txtLcStmt.Text & " (B). THAT PRODUCT(S) FROM SUPPLIERS/FACTORIES DO NOT INVOLVE" & vbNewLine
    '        txtLcStmt.Text = txtLcStmt.Text & "        TRANSHIPMENTS OF MERCHANDISE FOR THE PURPOSE OF MISLABELING," & vbNewLine
    '        txtLcStmt.Text = txtLcStmt.Text & "        EVADING QUOTA, OR COUNTRY OF ORIGIN RESTRICTIONS OR AVOIDING" & vbNewLine
    '        txtLcStmt.Text = txtLcStmt.Text & "        COMPLIANCE WITH FORCED LABOR, PRISON LABOR OR CHILD LABOR LAWS." & vbNewLine
    '        txtLcStmt.Text = txtLcStmt.Text & vbNewLine
    '        txtLcStmt.Text = txtLcStmt.Text & " (C). THIS SHIPMENT CONTAINS NO REGULATED WOOD PACKAGING MATERIALS." & vbNewLine
    '        txtLcStmt.Text = txtLcStmt.Text & vbNewLine
    '        txtLcStmt.Text = txtLcStmt.Text & " (D). MERCHANDISE OF EACH PURCHASE ORDER IS SHIPPED COMPLETE." & vbNewLine



    '        Add_flag = True

    '        Call cmdAddClick()

    '        '        Call formInit(cModeAdd)

    '        Recordstatus = True

    '    End Sub

    '    Private Sub GroupBox7_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox7.Enter

    '    End Sub

    '    Private Sub txtCover_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCover.TextChanged


    '        If rs_SHINVHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHINVHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtCover.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtCover.Text

    '                If tmpstr <> rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_cover") Then
    '                    Recordstatus = True


    '                    If rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hsm_creusr") <> "~*ADD*~" And rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hsm_creusr") <> "~*NEW*~" Then
    '                        rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hsm_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_cover") = tmpstr
    '                End If
    '            End If
    '        End If

    '    End Sub

    '    Private Sub Label81_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    End Sub

    Private Sub mmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click

        '''save like Shipping  
        ''' test


        ''If btcSHM00002.SelectedIndex <> 1 Then
        ''    MsgBox("Please save item in Details Page (2)!")
        ''    Exit Sub
        ''End If


        Cursor = Cursors.WaitCursor
        Call cmdSaveClick()
        Cursor = Cursors.Default
        txtNoteNo.Focus()


        '''

        '''
    End Sub
    Private Sub cmdSaveClick()
        Dim rowFilter As String


        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------

        'SAVE
        TtlAmt = 0

        If Add_flag = False Then
            If Not ChecktimeStamp() Then
                MsgBox("M00064")
                Cursor = Cursors.Default
                save_ok = False
                Exit Sub
            End If
        End If

        Call fill_SHCBNDTL()


        'Add for delete vlank record by Lewis********
        'rs_SHCBNDTL.MoveLast()
        'If rs_SHCBNdtl.tables("result").rows(readingindex)("hnd_creusr") = "~*ADD*~" And rs_SHCBNdtl.tables("result").rows(readingindex)("hnd_itmno") = "" And _
        '   rs_SHCBNdtl.tables("result").rows(readingindex)("hnd_lnetyp") = "I" Then
        '    rs_SHCBNdtl.tables("result").rows(readingindex)("hnd_creusr") = "~*NEW*~"
        'End If


        ''

        If Not chkSave() Then
            save_ok = False
            Exit Sub
        End If


        Dim S As String
        Dim rs As DataSet

        Dim rs_AutoGenCDNo As DataSet
        Dim cmsg As String

        Dim nottyp As String
        ' The message may inform you What note you are saving, remarked the message by Lewis on 25/03/2003 **
        If optCredit.Checked = True Then
            nottyp = "C"
            '*****    cmsg = "Credit Note "********************************
        Else
            nottyp = "D"
            '*****    cmsg = "Debit Note "*******************************
        End If

        Dim SmpShp As String

        If chkSample.Checked = True Then
            SmpShp = "Y"
        Else
            SmpShp = "N"
        End If

        rowFilter = "hnd_upd = 'Y'"
        rs_SHCBNDTL.Tables("RESULT").DefaultView.rowFilter = rowFilter
        If rs_SHCBNDTL.Tables("RESULT").DefaultView.Count > 0 Then
            cmsg = cmsg & "Save with updated SC"
        End If
        If cmsg <> "" Then
            If MsgBox(cmsg, vbOKCancel) = vbCancel Then
                save_ok = False
                Exit Sub
            End If
        End If


        'useful?
        'Dim bookmark As Object


        'bookmark = rs_SHCBNDTL.bookmark

        'rs_SHCBNDTL.tables("result").defaultview.rowFilter = "hnd_upd = 'Y'"
        'If rs_SHCBNDTL.tables("result").rows.count > 0 Then
        '    cmsg = cmsg & "Save with updated SC"
        'End If

        'rs_SHCBNDTL.tables("result").defaultview.rowFilter = ""

        'rs_SHCBNDTL.bookmark = bookmark
        'Dim a As Integer
        'If cmsg <> "" Then
        '    If MsgBox(cmsg, vbOKCancel) = vbCancel Then

        '        save_ok = False
        '        Exit Sub
        '    End If
        'End If



        '************CAll total Amt ********** by Kenny
        Call CAL_AMT()
        txtTtlAmt.Text = TtlAmt
        '*************************************
        Dim prmcus As String
        Dim seccus As String
        Dim prctrm As String
        Dim PayTrm As String

        If Add_flag = True Then

            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            'gspStr = "sp_select_DOC_GEN '" & cboCoCde.Text & "','QO','" & gsUsrID & "'"
            If nottyp = "D" Then
                gspStr = "sp_select_DOC_GEN '" & cboCoCde.Text & "','DN','" & gsUsrID & "'"
            Else
                gspStr = "sp_select_DOC_GEN '" & cboCoCde.Text & "','CN','" & gsUsrID & "'"
                'S = "¡ÀDOC_GEN¡°S¡°CN¡°" & gsUsrID
            End If


            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            gspStr = ""

            '' Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdSaveClick sp_select_DOC_GEN :" & rtnStr)
                Cursor = Cursors.Default

                Exit Sub
            End If

            txtNoteNo.Text = rs.Tables("RESULT").Rows(0)(0).ToString

            If Trim(txtPrmCus.Text) <> "" Then
                prmcus = Split(txtPrmCus.Text, "-")(0)
            End If

            If Trim(txtSecCus.Text) <> "" Then
                seccus = Split(txtSecCus.Text, "-")(0)
            End If

        End If

        '*****************Kenny add on 09-10-2002*****************
        Dim TempCty As String

        If UBound(Split(cboBCty.Text, " - ")) > 0 Then
            TempCty = Split(cboBCty.Text, " - ")(0)
        Else
            TempCty = ""
        End If

        If Add_flag = True Then

            gspStr = "sp_insert_SHCBNHDR '" & _
                cboCoCde.Text & "','" & _
                UCase(txtNoteNo.Text) & "','" & _
                 nottyp & "','" & _
                 txtRefNo.Text & "','" & _
                 prmcus & "','" & _
                 seccus & "','" & _
                 "A" & "','" & _
                 txtBilAdr.Text & "','" & _
                 txtBilstt.Text & "','" & _
                 TempCty & "','" & _
                 txtBilZip.Text & "','" & _
                 "" & "','" & _
                 "" & "','" & _
                 "" & "','" & _
                 "" & "','" & _
                 "" & "','" & _
                 Split(cboPrcTrm.Text, "-")(0) & "','" & _
                 Split(cboPayTrm.Text, "-")(0) & "','" & _
                 txtTtlUnt.Text & "','" & _
                 CDbl(txtTtlAmt.Text) & "','" & _
                 SmpShp & "','" & _
                 txtRmk.Text & "','" & gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            gspStr = ""
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading sp_insert_SHCBNHDR:" & rtnStr)
                Cursor = Cursors.Default
                IsUpdated = False
                Exit Sub
            Else
                IsUpdated = True
            End If

        Else

            gspStr = "sp_update_SHCBNHDR '" & _
                cboCoCde.Text & "','" & _
                UCase(txtNoteNo.Text) & "','" & _
                CDbl(txtTtlAmt.Text) & "','" & _
                txtRmk.Text & "','" & gsUsrID & "'"
            '                MsgBox s
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            gspStr = ""
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading sp_update_SHCBNHDR:" & rtnStr)
                Cursor = Cursors.Default
                IsUpdated = False
                Exit Sub
            Else
                IsUpdated = True
            End If
        End If

        'If S <> "" Then  '*** if there is something to do with s ...
        '    rs = objBSGate.Modify(gsConnStr, "sp_general", S)

        '    If rs(0) <> "0" Then  '*** An error has occured
        '        Cursor = Cursors.Default
        '        MsgBox(rs(0) & "SHCBNHDR")
        '        IsUpdated = False
        '        Exit Sub
        '    Else
        '        IsUpdated = True
        '    End If
        'End If




        '************************ Update PO Detail ********************************************


        '
        '    rs_SHCBNDTL.tables("result").defaultview.rowFilter = "hnd_creusr <> '~*ADD*~' and hnd_creusr <> '~*NEW*~' and hnd_creusr <> '~*DEL*~'"
        '
        '
        '
        '    If rs_SHCBNDTL.tables("result").rows.count <> 0 Then
        '        rs_SHCBNDTL.MoveFirst
        '    End If
        '
        '
        '    While Not rs_SHCBNDTL.Tables("result").Rows.count = 0 
        '
        '
        '       S = "¡ÀSHCBNDTL¡°U¡°" & UCase(txtNoteNo.Text) & "','" & _
        '                    rs_SHCBNdtl.tables("result").rows(readingindex)("hnd_seq") & "','" & _
        '                    rs_SHCBNdtl.tables("result").rows(readingindex)("hnd_adjqty") & "','" & _
        '                    rs_SHCBNdtl.tables("result").rows(readingindex)("hnd_adjprc") & "','" & _
        '                    rs_SHCBNdtl.tables("result").rows(readingindex)("hnd_rmk") & "','" & _
        '                    rs_SHCBNdtl.tables("result").rows(readingindex)("hnd_upd") & "','" & gsUsrID
        '
        '        If S <> "" Then  '*** if there is something to do with s ...
        '            Set rs = objBSGate.Modify(gsConnStr, "sp_general", S)
        '            If rs(0) <> "0" Then  '*** An error has occured
        '                MsgBox rs(0) & "rs_SHCBNDTL"
        '                IsUpdated = False
        '            Else
        '                IsUpdated = True
        '            End If
        '        End If
        '
        '        rs_SHCBNDTL.MoveNext
        '
        '    Wend


        '''''''''''''''''''''''''''''DELETE Detail''''''''''''''''''''''''''''''''''''''

        'rowFilter = "hnd_creusr = '~*DEL*~'"

        'If rs_SHCBNDTL.tables("result").rows.count <> 0 Then
        '    rs_SHCBNDTL.MoveFirst()
        'End If

        'While Not rs_SHCBNDTL.Tables("result").Rows.count = 0 


        '    S = "¡ÀSHCBNDTL¡°P¡°" & UCase(txtNoteNo.Text) & "','" & _
        '                 rs_SHCBNdtl.tables("result").rows(readingindex)("hnd_seq")

        '    'MsgBox "delete  " & s
        '    If S <> "" Then  '*** if there is something to do with s ...
        '        rs = objBSGate.Modify(gsConnStr, "sp_general", S)
        '        If rs(0) <> "0" Then  '*** An error has occured
        '            MsgBox(rs(0) & "rs_SHCBNDTL")
        '            IsUpdated = False
        '        Else
        '            IsUpdated = True
        '        End If
        '    End If


        rowFilter = "hnd_creusr = '~*DEL*~'"
        rs_SHCBNDTL.Tables("RESULT").DefaultView.rowFilter = rowFilter

        For index2 As Integer = 0 To rs_SHCBNDTL.Tables("RESULT").DefaultView.Count - 1
            gspStr = "sp_Physical_Delete_SHCBNDTL '" & cboCoCde.Text & "','" & _
            UCase(txtNoteNo.Text) & "','" & _
            rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_seq") & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            gspStr = ""
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading sp_Physical_Delete_SHCBNDTL:" & rtnStr)
                Cursor = Cursors.Default
                IsUpdated = False
                Exit Sub
            Else
                IsUpdated = True
            End If

            'when deleting detail,updating SC PO
            '===================================================================
            'Lester Wu 2004/08/26
            'Add code to update SC and PO Status
            '===================================================================
            gspStr = "sp_update_SHSCSTS  '" & cboCoCde.Text & "','" & _
                rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hid_OrdNo") & "','" & _
                gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            gspStr = ""
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading sp_update_SHSCSTS:" & rtnStr)
                Cursor = Cursors.Default
                IsUpdated = False
                Exit Sub
            Else
                'IsUpdated = True
            End If

            gspStr = "sp_update_SHPOSTS  '" & cboCoCde.Text & "','" & _
    rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hid_PurOrd") & "','" & _
    gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            gspStr = ""
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading sp_update_SHPOSTS:" & rtnStr)
                Cursor = Cursors.Default
                IsUpdated = False
                Exit Sub
            Else
                'IsUpdated = True
            End If
            '===================================================================


        Next



        '''''''''''''''''''''''''''''ADD Detail''''''''''''''''''''''''''''''''''''''
        rowFilter = "hnd_creusr =  '~*ADD*~' or hnd_creusr =  '~*NEW*~' "
        rs_SHCBNDTL.Tables("RESULT").DefaultView.rowFilter = rowFilter

        For index2 As Integer = 0 To rs_SHCBNDTL.Tables("RESULT").DefaultView.Count - 1
            gspStr = "sp_insert_SHCBNDTL '" & cboCoCde.Text & "','" & _
             UCase(txtNoteNo.Text) & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_seq") & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_lnetyp") & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_invlne") & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_itmno") & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_itmdsc") & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_colcde") & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_coldsc") & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_cusitm") & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_cussku") & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_mannam") & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_manadr") & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_pckunt") & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_inrctn") & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_mtrctn") & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_cft") & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_curcde") & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_adjprc") & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_adjqty") & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_upd") & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hnd_rmk") & "','" & _
             rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hid_ordno") & "','" & gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            gspStr = ""
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading sp_insert_SHCBNDTL :" & rtnStr)
                Cursor = Cursors.Default
                IsUpdated = False
                Exit Sub
            Else
                IsUpdated = True
            End If


            'updating
            '===================================================================
            'Lester Wu 2004/08/26
            'Add code to update SC and PO Status
            '===================================================================
            gspStr = "sp_update_SHSCSTS  '" & cboCoCde.Text & "','" & _
                rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hid_OrdNo") & "','" & _
                gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            gspStr = ""
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading sp_update_SHSCSTS:" & rtnStr)
                Cursor = Cursors.Default
                IsUpdated = False
                Exit Sub
            Else
                'IsUpdated = True
            End If

            gspStr = "sp_update_SHPOSTS  '" & cboCoCde.Text & "','" & _
    rs_SHCBNDTL.Tables("RESULT").DefaultView(index2)("hid_PurOrd") & "','" & _
    gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            gspStr = ""
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading sp_update_SHPOSTS:" & rtnStr)
                Cursor = Cursors.Default
                IsUpdated = False
                Exit Sub
            Else
                'IsUpdated = True
            End If
            '===================================================================

        Next

        '        Dim prmcus As String
        '        Dim seccus As String
        '        Dim prctrm As String
        '        Dim PayTrm As String

        'Cursor = Cursors.Default

        If IsUpdated Then

            Call setStatus("Save")

        End If


    End Sub

    '    Private Function check_ShippingHeader() As Boolean
    '        check_ShippingHeader = False

    '        '    '''20140211
    '        '    Call set_qutsts()

    '        '    Dim i As Integer
    '        '    Dim Y As Integer
    '        '    Dim inCombo As Boolean

    '        '    '*** Primary Customer
    '        '    If cboCus1No.Text <> "" And cboCus1No.Enabled = True And cboCus1No.Items.Count > 0 Then
    '        '        inCombo = False
    '        '        i = cboCus1No.Items.Count
    '        '        For Y = 0 To i - 1
    '        '            If Trim(cboCus1No.Text) = Trim(cboCus1No.Items(Y)) Then
    '        '                inCombo = True
    '        '            End If
    '        '        Next

    '        '        If inCombo = False Then
    '        '            'If no_need_check_btcindex = False Then
    '        '            MsgBox("Primary Customer - Data is Invalid, please select in Drop Down List.")
    '        '            'End If
    '        '            ''btcSHM00002.SelectedIndex = 0
    '        '            'no_need_check_btcindex = True
    '        '            cboCus1No.Enabled = True
    '        '            If cboCus1No.Enabled And cboCus1No.Visible Then cboCus1No.Focus()
    '        '            Exit Function
    '        '        End If
    '        '    End If

    '        '    '*** Contact Person - Primary Customer
    '        '    If cboCus1Cp.Text <> "" And cboCus1Cp.Enabled = True And cboCus1Cp.Items.Count > 0 Then
    '        '        inCombo = False
    '        '        i = cboCus1Cp.Items.Count
    '        '        For Y = 0 To i - 1
    '        '            If Trim(cboCus1Cp.Text) = Trim(cboCus1Cp.Items(Y)) Then
    '        '                inCombo = True
    '        '            End If
    '        '        Next

    '        '        If inCombo = False Then
    '        '            MsgBox("Contact Person of Primary Customer - Data is Invalid, please select in Drop Down List.")
    '        '            ''btcSHM00002.SelectedIndex = 0
    '        '            cboCus1Cp.Enabled = True
    '        '            If cboCus1Cp.Enabled And cboCus1Cp.Visible Then cboCus1Cp.Focus()
    '        '            Exit Function
    '        '        End If
    '        '    End If

    '        '    '*** Secondary Customer
    '        '    If cboCus2No.Text <> "" And cboCus2No.Enabled = True And cboCus2No.Items.Count > 0 Then
    '        '        inCombo = False
    '        '        i = cboCus2No.Items.Count
    '        '        For Y = 0 To i - 1
    '        '            If Trim(cboCus2No.Text) = Trim(cboCus2No.Items(Y)) Then
    '        '                inCombo = True
    '        '            End If
    '        '        Next

    '        '        If inCombo = False Then
    '        '            MsgBox("Secondary Customer - Data is Invalid, please select in Drop Down List.")
    '        '            ''btcSHM00002.SelectedIndex = 0
    '        '            'no_need_check_btcindex = True
    '        '            cboCus2No.Enabled = True
    '        '            If cboCus2No.Enabled And cboCus2No.Visible Then cboCus2No.Focus()
    '        '            Exit Function
    '        '        End If
    '        '    End If

    '        '    '*** Contact Person - Secondary Customer
    '        '    If cboCus2Cp.Text <> "" And cboCus2Cp.Enabled = True And cboCus2Cp.Items.Count > 0 Then
    '        '        inCombo = False
    '        '        i = cboCus2Cp.Items.Count
    '        '        For Y = 0 To i - 1
    '        '            If Trim(cboCus2Cp.Text) = Trim(Replace(cboCus2Cp.Items(Y), vbCrLf, "")) Then
    '        '                '                If Trim(cboCus2Cp.Text) = Trim(cboCus2Cp.Items(Y)) Then
    '        '                inCombo = True
    '        '            End If
    '        '        Next

    '        '        If inCombo = False Then
    '        '            MsgBox("Contact Person of Secondary Customer - Data is Invalid, please select in Drop Down List.")
    '        '            ''btcSHM00002.SelectedIndex = 0
    '        '            'no_need_check_btcindex = True
    '        '            cboCus2Cp.Enabled = True
    '        '            If cboCus2Cp.Enabled And cboCus2Cp.Visible Then cboCus2Cp.Focus()
    '        '            Exit Function
    '        '        End If
    '        '    End If

    '        '    '*** Agent
    '        '    If cboCusAgt.Text <> "" And cboCusAgt.Enabled = True And cboCusAgt.Items.Count > 0 Then
    '        '        inCombo = False
    '        '        i = cboCusAgt.Items.Count
    '        '        For Y = 0 To i - 1
    '        '            If Trim(cboCusAgt.Text) = Trim(cboCusAgt.Items(Y)) Then
    '        '                inCombo = True
    '        '            End If
    '        '        Next

    '        '        If inCombo = False Then
    '        '            MsgBox("Agent - Data is Invalid, please select in Drop Down List.")
    '        '            ''btcSHM00002.SelectedIndex = 0
    '        '            'no_need_check_btcindex = True
    '        '            cboCusAgt.Enabled = True
    '        '            If cboCusAgt.Enabled And cboCusAgt.Visible Then cboCusAgt.Focus()
    '        '            Exit Function
    '        '        End If
    '        '    End If

    '        '    '*** Phase 2
    '        '    '*** Sales Division (Team)
    '        '    If cboSalDiv.Text <> "" And cboSalDiv.Enabled = True And cboSalDiv.Items.Count > 0 Then
    '        '        inCombo = False
    '        '        i = cboSalDiv.Items.Count
    '        '        For Y = 0 To i - 1
    '        '            If Trim(cboSalDiv.Text) = Trim(cboSalDiv.Items(Y)) Then
    '        '                inCombo = True
    '        '            End If
    '        '        Next

    '        '        If inCombo = False Then
    '        '            MsgBox("Sales Division (Team) - Data is Invalid, please select in Drop Down List.")
    '        '            ''btcSHM00002.SelectedIndex = 0
    '        '            'no_need_check_btcindex = True
    '        '            cboSalDiv.Enabled = True
    '        '            If cboSalDiv.Enabled And cboSalDiv.Visible Then cboSalDiv.Focus()
    '        '            Exit Function
    '        '        End If
    '        '    End If

    '        '    '*** Sales Rep
    '        '    If cboSalRep.Text = "" Then
    '        '        If Trim(cboCus1No.Text) <> "" Then

    '        '            MsgBox("Sales Rep - Data is Invalid, please select in Drop Down List.")
    '        '            cboSalRep.Enabled = True
    '        '        End If
    '        '        '   MsgBox("Sales Rep - Data is Invalid, please select in Drop Down List.")
    '        '        ''btcSHM00002.SelectedIndex = 0
    '        '        'no_need_check_btcindex = True
    '        '        'cboSalRep.Enabled = True
    '        '        If cboSalRep.Enabled And cboSalRep.Visible Then cboSalRep.Focus()
    '        '        Exit Function
    '        '    ElseIf cboSalRep.Text <> "" And cboSalRep.Enabled = True And cboSalRep.Items.Count > 0 Then
    '        '        inCombo = False
    '        '        i = cboSalRep.Items.Count
    '        '        For Y = 0 To i - 1
    '        '            If Trim(cboSalRep.Text) = Trim(cboSalRep.Items(Y)) Then
    '        '                inCombo = True
    '        '            End If
    '        '        Next

    '        '        If inCombo = False Then
    '        '            MsgBox("Sales Rep - Data is Invalid, please select in Drop Down List.")
    '        '            ''btcSHM00002.SelectedIndex = 0
    '        '            'no_need_check_btcindex = True
    '        '            cboSalRep.Enabled = True
    '        '            If cboSalRep.Enabled And cboSalRep.Visible Then cboSalRep.Focus()
    '        '            Exit Function
    '        '        End If
    '        '    End If


    '        '    '*** Phase 2
    '        '    If cboYear.Text = "" And cboYear.Enabled = True Then
    '        '        '''btcSHM00002.SelectedIndex = 0
    '        '        'no_need_check_btcindex = True

    '        '        MsgBox("Shipping Title - Year, must be assigned.")

    '        '        cboYear.Enabled = True

    '        '        If cboYear.Enabled And cboYear.Visible Then cboYear.Focus()
    '        '        Exit Function
    '        '    End If

    '        '    '*** Phase 2
    '        '    If cboSeason.Text = "" And cboSeason.Enabled = True Then
    '        '        ''btcSHM00002.SelectedIndex = 0
    '        '        'no_need_check_btcindex = True
    '        '        MsgBox("Shipping Title - Season, must be assigned.")
    '        '        cboSeason.Enabled = True
    '        '        If cboSeason.Enabled And cboSeason.Visible Then cboSeason.Focus()
    '        '        Exit Function
    '        '    End If

    '        '    '*** Phase 2
    '        '    If txtDesc.Text = "" And txtDesc.Enabled = True Then
    '        '        ''btcSHM00002.SelectedIndex = 0
    '        '        MsgBox("Shipping Title - Project, must be entered.")
    '        '        txtDesc.Enabled = True
    '        '        If txtDesc.Enabled And txtDesc.Visible Then txtDesc.Focus()
    '        '        Exit Function
    '        '    End If

    '        '    If cboSmpPrd.Text = "" And cboSmpPrd.Enabled = True Then
    '        '        ''btcSHM00002.SelectedIndex = 0
    '        '        'no_need_check_btcindex = True

    '        '        MsgBox("Sample Product Term must be assigned, please update Customer Master first.")
    '        '        cboSmpPrd.Enabled = True
    '        '        If cboSmpPrd.Enabled And cboSmpPrd.Visible Then cboSmpPrd.Focus()
    '        '        Exit Function
    '        '    End If

    '        '    If cboSmpFgt.Text = "" And cboSmpFgt.Enabled = True Then
    '        '        ''btcSHM00002.SelectedIndex = 0
    '        '        'no_need_check_btcindex = True

    '        '        MsgBox("Sample Freight Term must be assigned, please update Customer Master first.")
    '        '        cboSmpFgt.Enabled = True
    '        '        If cboSmpFgt.Enabled And cboSmpFgt.Visible Then cboSmpFgt.Focus()
    '        '        Exit Function
    '        '    End If

    '        check_ShippingHeader = True
    '    End Function




    '    'Public Sub fill_SHIPGDTL()
    '    '    Dim onetim As String
    '    '    Dim image As String
    '    '    Dim gmmu As String

    '    ''*** Check Combo in list or not ?
    '    'If not_in_Combo_HDR() = True Then
    '    '    Exit Sub
    '    'End If

    '    'If Not rs_SHCBNDTL.Tables("RESULT").Rows.Count > 0 Then
    '    '    Exit Sub
    '    'End If

    '    ''*** Check Item Exist ?
    '    ''*** Phase 2
    '    'If txtItmNoVen.Text = "" Then
    '    '    If txtItmNo.Text <> "" And (txtItmNoReal.Enabled = True Or txtItmNoTmp.Enabled = True) Then
    '    '        If not_exist_ITEM() = True Then
    '    '            MsgBox("Item cannot be quoted because :" + Chr(13) + Chr(10) + _
    '    '            " - Item not found" + Chr(13) + Chr(10) + _
    '    '            " - It is a BOM Item" + Chr(13) + Chr(10) + _
    '    '            " - It is a Discontinued / Inactive / Old Item / To be confirmed Item" + Chr(13) + Chr(10) + _
    '    '            " - It is held by the system" + Chr(13) + Chr(10) + _
    '    '            " - Vendor is not available", vbExclamation, "Warning fq")
    '    '            Exit Sub
    '    '        End If
    '    '    End If
    '    'End If

    '    ''*** Check Shipping Item Status
    '    'If txtItmNo.Text <> "" Then

    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_shpseq ") = IIf(IsNumeric(txtSeq.Text), txtSeq.Text, 0)

    '    '    If cboItmSts.Text.Trim <> "" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_itmsts") = Microsoft.VisualBasic.Left(cboItmSts.Text.Trim, InStr(cboItmSts.Text.Trim, " - ") - 1)
    '    '    Else
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_itmsts") = ""
    '    '    End If


    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_qutitmsts") = txtQutItmSts.Text.Trim
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_dept") = txtDept.Text.Trim
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftytmpitm") = IIf(chkFtyTmpItm.Checked = True, "Y", "")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftytmpitmno") = IIf(Trim(txtFtyTmpItmNo.Text.Trim) = "", "", Trim(txtFtyTmpItmNo.Text.Trim))

    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("Del") = IIf(chkDelete.Checked = True, "Y", "N")

    '    '    If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("upditmdtl").ToString() = "" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("upditmdtl") = "N"
    '    '    End If
    '    '    If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("updmoqmoa").ToString() = "" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("updmoqmoa") = "N"
    '    '    End If
    '    '    If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("updassbom").ToString() = "" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("updassbom") = "N"
    '    '    End If
    '    '    If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("converttopc").ToString() = "" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("converttopc") = "N"
    '    '    End If

    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_itmno") = txtItmNo.Text

    '    '    '*** Phase 2
    '    '    If txtItmNoReal.Text <> "" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_itmnotyp") = "R"
    '    '    ElseIf txtItmNoTmp.Text <> "" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_itmnotyp") = "T"
    '    '    Else
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_itmnotyp") = "V"
    '    '    End If

    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_itmnoreal") = txtItmNoReal.Text.Trim
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_itmnotmp") = txtItmNoTmp.Text.Trim
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_itmnoven") = txtItmNoVen.Text.Trim

    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_itmnovenno") = cboItmNoVen.Text.Trim()
    '    '    ''' reverse -
    '    '    If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_itmnovenno")) Then
    '    '        If InStr(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_itmnovenno"), " - ") > 1 Then
    '    '            If Val(Split(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_itmnovenno"), " - ")(0)) > 1000 And _
    '    '             Val(Split(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_itmnovenno"), " - ")(0)) < 9999 _
    '    '            Then
    '    '                display_combo_ven(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_itmnovenno").ToString, cboItmNoVen)
    '    '            Else
    '    '                display_combo(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_itmnovenno").ToString, cboItmNoVen)
    '    '            End If
    '    '        Else
    '    '            display_combo(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_itmnovenno").ToString, cboItmNoVen)
    '    '        End If
    '    '    End If


    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_itmnovenno") = cboItmNoVen.Text.Trim()

    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_itmdsc") = Trim(txtItmDsc.Text)
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cusstyno") = cboCusals.Text.Trim
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cusitm") = txtCusItm.Text.Trim
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_alsitmno") = txtAlias.Text.Trim
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_upc") = Trim(txtUPC.Text)

    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_imrmk") = IIf(Trim(txtIMRmk.Text) = "", "", Trim(txtIMRmk.Text))
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_note") = txtNote.Text

    '    '    If txtItmNoVen.Text <> "" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_colcde") = txtColCde.Text.Trim
    '    '    Else
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_colcde") = cboColCde.Text.Trim
    '    '    End If
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_coldsc") = Trim(txtColDsc.Text)
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_alscolcde") = txtAlscolcde.Text.Trim
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cuscol") = txtCusCol.Text.Trim

    '    '    '*** Phase 2
    '    '    If txtItmNoVen.Text = "" Then
    '    '        If cboPcking.Text <> "" Then
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_untcde") = cboUM.Text.Trim
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrqty") = IIf(txtInrQty.Text.Trim = "", 0, txtInrQty.Text.Trim)
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrqty") = IIf(txtMtrQty.Text.Trim = "", 0, txtMtrQty.Text.Trim)
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cft") = IIf(txtCft.Text.Trim = "", 0, Format(CDec(IIf(txtCft.Text.Trim = "", 0, txtCft.Text.Trim)), "######0.####"))
    '    '        Else
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_untcde") = ""
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrqty") = 0
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrqty") = 0
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cft") = 0
    '    '        End If
    '    '    Else
    '    '        If cboUM.Text <> "" And _
    '    '            cboFtyPrcTrm.Text <> "" And cboDtlPrcTrm.Text <> "" And cboTranTrm.Text <> "" Then
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_untcde") = cboUM.Text.Trim
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrqty") = IIf(txtInrQty.Text.Trim = "", 0, txtInrQty.Text.Trim)
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrqty") = IIf(txtMtrQty.Text.Trim = "", 0, txtMtrQty.Text.Trim)
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cft") = IIf(txtCft.Text.Trim = "", 0, Format(CDec(IIf(txtCft.Text.Trim = "", 0, txtCft.Text.Trim)), "######0.####"))
    '    '        Else
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_untcde") = ""
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrqty") = 0
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrqty") = 0
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cft") = 0
    '    '        End If
    '    '    End If
    '    '    If txtUMFtr.Text.Trim = "" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_conftr") = 1
    '    '    Else
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_conftr") = CInt(IIf(txtUMFtr.Text.Trim = "", 1, txtUMFtr.Text.Trim))
    '    '    End If
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cbm") = IIf(Trim(txtCBM.Text) = "", 0, Trim(txtCBM.Text))
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_prctrm") = cboDtlPrcTrm.Text.Trim
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyprctrm") = cboFtyPrcTrm.Text.Trim '*** factory price term
    '    '    '*** Phase 2
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_trantrm") = cboTranTrm.Text.Trim

    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrdin") = Format(CDec(IIf(txtInrdin.Text.Trim = "", 0, txtInrdin.Text.Trim)), "######0.####")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrwin") = Format(CDec(IIf(txtInrwin.Text.Trim = "", 0, txtInrwin.Text.Trim)), "######0.####")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrhin") = Format(CDec(IIf(txtInrhin.Text.Trim = "", 0, txtInrhin.Text.Trim)), "######0.####")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrdin") = Format(CDec(IIf(txtMtrdin.Text.Trim = "", 0, txtMtrdin.Text.Trim)), "######0.####")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrwin") = Format(CDec(IIf(txtMtrwin.Text.Trim = "", 0, txtMtrwin.Text.Trim)), "######0.####")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrhin") = Format(CDec(IIf(txtMtrhin.Text.Trim = "", 0, txtMtrhin.Text.Trim)), "######0.####")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrdcm") = Format(CDec(IIf(txtInrdcm.Text.Trim = "", 0, txtInrdcm.Text.Trim)), "######0.####")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrwcm") = Format(CDec(IIf(txtInrwcm.Text.Trim = "", 0, txtInrwcm.Text.Trim)), "######0.####")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrhcm") = Format(CDec(IIf(txtInrhcm.Text.Trim = "", 0, txtInrhcm.Text.Trim)), "######0.####")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrdcm") = Format(CDec(IIf(txtMtrdcm.Text.Trim = "", 0, txtMtrdcm.Text.Trim)), "######0.####")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrwcm") = Format(CDec(IIf(txtMtrwcm.Text.Trim = "", 0, txtMtrwcm.Text.Trim)), "######0.####")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrhcm") = Format(CDec(IIf(txtMtrhcm.Text.Trim = "", 0, txtMtrhcm.Text.Trim)), "######0.####")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("inner_in") = Format(CDec(IIf(txtInrdin.Text.Trim = "", 0, txtInrdin.Text.Trim)), "######0.####") + "x" + _
    '    '                                    Format(CDec(IIf(txtInrwin.Text.Trim = "", 0, txtInrwin.Text.Trim)), "######0.####") + "x" + _
    '    '                                    Format(CDec(IIf(txtInrhin.Text.Trim = "", 0, txtInrhin.Text.Trim)), "######0.####")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("master_in") = Format(CDec(IIf(txtMtrdin.Text.Trim = "", 0, txtMtrdin.Text.Trim)), "######0.####") + "x" + _
    '    '                                     Format(CDec(IIf(txtMtrwin.Text.Trim = "", 0, txtMtrwin.Text.Trim)), "######0.####") + "x" + _
    '    '                                     Format(CDec(IIf(txtMtrhin.Text.Trim = "", 0, txtMtrhin.Text.Trim)), "######0.####")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("inner_cm") = Format(CDec(IIf(txtInrdcm.Text.Trim = "", 0, txtInrdcm.Text.Trim)), "######0.####") + "x" + _
    '    '                                    Format(CDec(IIf(txtInrwcm.Text.Trim = "", 0, txtInrwcm.Text.Trim)), "######0.####") + "x" + _
    '    '                                    Format(CDec(IIf(txtInrhcm.Text.Trim = "", 0, txtInrhcm.Text.Trim)), "######0.####")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("master_cm") = Format(CDec(IIf(txtMtrdcm.Text.Trim = "", 0, txtMtrdcm.Text.Trim)), "######0.####") + "x" + _
    '    '                                     Format(CDec(IIf(txtMtrwcm.Text.Trim = "", 0, txtMtrwcm.Text.Trim)), "######0.####") + "x" + _
    '    '                                     Format(CDec(IIf(txtMtrhcm.Text.Trim = "", 0, txtMtrhcm.Text.Trim)), "######0.####")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_grswgt") = Format(CDec(IIf(txtGrsWgt.Text.Trim = "", 0, txtGrsWgt.Text.Trim)), "##0.###")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_netwgt") = Format(CDec(IIf(txtNetWgt.Text.Trim = "", 0, txtNetWgt.Text.Trim)), "##0.###")

    '    '    If Trim(txtPeriod.Text) <> "" Then

    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_qutdat") = txtPeriod.Text.Trim + "-01"
    '    '    Else
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_qutdat") = "1900-01-01"
    '    '    End If

    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_pckitr") = txtPckItr.Text.Trim

    '    '    If txtCosMth.Text.Trim = "-" Or txtCosMth.Text.Trim = "" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cosmth") = ""
    '    '    Else
    '    '        'rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cosmth") = Microsoft.VisualBasic.Left(txtCosMth.Text.Trim, InStr(txtCosMth.Text.Trim, " - ") - 1)
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cosmth") = txtCosMth.Text
    '    '    End If
    '    '    If txtCosMth.Text = " - " Then txtCosMth.Text = ""

    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_stkqty") = IIf(txtStkQty.Text.Trim = "", 0, txtStkQty.Text.Trim)
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cusqty") = IIf(txtCusQty.Text.Trim = "", 0, txtCusQty.Text.Trim)
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_smpqty") = IIf(txtSmpQty.Text.Trim = "", 0, txtSmpQty.Text.Trim)
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_smpunt") = txtSmpUnt.Text.Trim
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_smpprc") = IIf(txtSmpPrc.Text.Trim = "", 0, Format(CDec(IIf(txtSmpPrc.Text.Trim = "", 0, txtSmpPrc.Text.Trim)), "########0.0000"))

    '    '    '*** Update Record Set Value of Original MOQ/MOA
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_moflag") = IIf(optMOA.Checked = True, "A", IIf(optMOQ.Checked = True, "Q", ""))
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_orgmoq") = IIf(ORI_MOQ = "", 0, ORI_MOQ)
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_orgmoa") = IIf(ORI_MOA = "", 0, Format(CDec(IIf(ORI_MOA = "", 0, ORI_MOA)), "######0"))
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_moq") = IIf(txtMoq.Text.Trim = "", 0, txtMoq.Text.Trim)
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_moqunttyp") = Trim(Replace(lblCurrMOQ.Text.Trim, "=", ""))
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_moa") = IIf(txtMoa.Text.Trim = "", 0, Format(CDec(IIf(txtMoa.Text.Trim = "", 0, txtMoa.Text.Trim)), "######0"))
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_curcde") = txtCurCde1.Text.Trim

    '    '    If cboCus2No.Text.Trim <> "" Then
    '    '        If optGM.Checked = True Then
    '    '            gmmu = "GM"
    '    '        Else
    '    '            gmmu = "MU"
    '    '        End If
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_prcsec") = gmmu
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_grsmgn") = IIf(txtGrsMgn.Text.Trim = "", 0, Format(CDec(IIf(txtGrsMgn.Text.Trim = "", 0, txtGrsMgn.Text.Trim)), "##0.###"))
    '    '    End If

    '    '    If optOneTimY.Checked = True Then
    '    '        onetim = "Y"
    '    '    Else
    '    '        onetim = "N"
    '    '    End If
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_onetim") = onetim
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_discnt") = IIf(txtDiscnt.Text.Trim = "", 0, Format(CDec(IIf(txtDiscnt.Text.Trim = "", 0, txtDiscnt.Text.Trim)), "##0.###"))

    '    '    '*** Phase 2
    '    '    If txtBasPrc.Text.Trim <> "" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_basprc") = txtBasPrc.Text.Trim
    '    '    Else
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_basprc") = "0"
    '    '    End If

    '    '    '*** Update CIH value to record set
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("CIHCURR") = txtCIHcur.Text.Trim
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("CIHAMT") = txtCIHprc.Text.Trim

    '    '    '*** Phase 2
    '    '    If txtItmNoVen.Text = "" Then
    '    '        If cboPcking.Text <> "" Then
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cus1sp") = IIf(txtCus1Sp.Text.Trim = "", 0, Format(CDec(IIf(txtCus1Sp.Text.Trim = "", 0, txtCus1Sp.Text.Trim)), "########0.0000"))
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cus2sp") = IIf(txtCus2Sp.Text.Trim = "", 0, Format(CDec(IIf(txtCus2Sp.Text.Trim = "", 0, txtCus2Sp.Text.Trim)), "########0.0000"))

    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cus1dp") = IIf(txtCus1Dp.Text.Trim = "", 0, Format(CDec(IIf(txtCus1Dp.Text.Trim = "", 0, txtCus1Dp.Text.Trim)), "########0.0000"))
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cus2dp") = IIf(txtCus2Dp.Text.Trim = "", 0, Format(CDec(IIf(txtCus2Dp.Text.Trim = "", 0, txtCus2Dp.Text.Trim)), "########0.0000"))
    '    '        Else
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cus1sp") = 0
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cus2sp") = 0

    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cus1dp") = 0
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cus2dp") = 0
    '    '        End If
    '    '    Else
    '    '        If cboUM.Text <> "" And _
    '    '            cboFtyPrcTrm.Text <> "" And cboDtlPrcTrm.Text <> "" And cboTranTrm.Text <> "" Then
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cus1sp") = IIf(txtCus1Sp.Text.Trim = "", 0, Format(CDec(IIf(txtCus1Sp.Text.Trim = "", 0, txtCus1Sp.Text.Trim)), "########0.0000"))
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cus2sp") = IIf(txtCus2Sp.Text.Trim = "", 0, Format(CDec(IIf(txtCus2Sp.Text.Trim = "", 0, txtCus2Sp.Text.Trim)), "########0.0000"))

    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cus1dp") = IIf(txtCus1Dp.Text.Trim = "", 0, Format(CDec(IIf(txtCus1Dp.Text.Trim = "", 0, txtCus1Dp.Text.Trim)), "########0.0000"))
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cus2dp") = IIf(txtCus2Dp.Text.Trim = "", 0, Format(CDec(IIf(txtCus2Dp.Text.Trim = "", 0, txtCus2Dp.Text.Trim)), "########0.0000"))
    '    '        Else
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cus1sp") = 0
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cus2sp") = 0

    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cus1dp") = 0
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cus2dp") = 0
    '    '        End If
    '    '    End If

    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_pcprc") = txtPCPrc_Text_round_5
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_contopc") = IIf(chkPC.Checked = True, "Y", "")

    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_venno") = cboVenNo.Text.Trim
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_subcde") = txtSubCde.Text.Trim
    '    '    '*** fill custom vendor & sub code

    '    '    If Not (cboCusVen.Text.Trim = "" And _
    '    '                            cboDV.Text.Trim = "" And _
    '    '                            cboTV.Text.Trim = "" And _
    '    '                            cboFA.Text.Trim = "") Then

    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cusven") = cboCusVen.Text.Trim
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_DV") = cboDV.Text.Trim
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_TV") = cboTV.Text.Trim
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyaud") = cboFA.Text.Trim

    '    '    End If

    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cussub") = txtCusSub.Text.Trim

    '    '    '*** Phase 2
    '    '    If txtItmNoVen.Text <> "" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_fcurcde") = txtFCurCde.Text.Trim
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyprc") = IIf(txtFtyPrc.Text.Trim = "", 0, Format(CDec(IIf(txtFtyPrc.Text.Trim = "", 0, txtFtyPrc.Text.Trim)), "########0.0000"))
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftycst") = IIf(txtFtyCst.Text.Trim = "", 0, Format(CDec(IIf(txtFtyCst.Text.Trim = "", 0, txtFtyCst.Text.Trim)), "########0.0000"))

    '    '        'If cboUM.Text.Trim = "" Or txtCft.Text.Trim = "0" Or txtCBM.Text.Trim = "0" Or _
    '    '        '    cboDtlPrcTrm.Text.Trim = "" Or cboFtyPrcTrm.Text.Trim = "" Or cboTranTrm.Text.Trim = "" Then
    '    '        '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_fcurcde") = ""
    '    '        '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyprc") = 0
    '    '        '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftycst") = 0
    '    '        'Else
    '    '        '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_fcurcde") = txtFCurCde.Text.Trim
    '    '        '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyprc") = IIf(txtFtyPrc.Text.Trim = "", 0, Format(CDec(IIf(txtFtyPrc.Text.Trim = "", 0, txtFtyPrc.Text.Trim)), "########0.0000"))
    '    '        '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftycst") = IIf(txtFtyCst.Text.Trim = "", 0, Format(CDec(IIf(txtFtyCst.Text.Trim = "", 0, txtFtyCst.Text.Trim)), "########0.0000"))
    '    '        'End If
    '    '    Else
    '    '        '*** Phase 2
    '    '        If cboPcking.Text.Trim <> "" And cboPcking.Text.Trim <> " / 0 / 0 / 0 / 0 / / /" Then
    '    '            'If cboPcking.Text <> "" And cboPcking.Text <> " / 0 / 0" Then
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_fcurcde") = txtFCurCde.Text.Trim
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyprc") = IIf(txtFtyPrc.Text.Trim = "", 0, Format(CDec(IIf(txtFtyPrc.Text.Trim = "", 0, txtFtyPrc.Text.Trim)), "########0.0000"))
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftycst") = IIf(txtFtyCst.Text.Trim = "", 0, Format(CDec(IIf(txtFtyCst.Text.Trim = "", 0, txtFtyCst.Text.Trim)), "########0.0000"))
    '    '        Else
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_fcurcde") = ""
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyprc") = 0
    '    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftycst") = 0
    '    '        End If
    '    '    End If

    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_venitm") = txtVenItm.Text.Trim

    '    '    If InStr(cboHrmCde.Text, " - ") > 0 Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_hrmcde") = Microsoft.VisualBasic.Left(cboHrmCde.Text.Trim, InStr(cboHrmCde.Text.Trim, " - ") - 1)
    '    '    Else
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_hrmcde") = cboHrmCde.Text.Trim
    '    '    End If
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_dtyrat") = IIf(txtDtyRat.Text.Trim = "", 0, Format(CDec(IIf(txtDtyRat.Text.Trim = "", 0, txtDtyRat.Text.Trim)), "##0.###"))
    '    '    '*** Phase 2
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cususdcur") = cboCusUsdCurr.Text.Trim
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cuscadcur") = cboCusCadCurr.Text.Trim

    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cususd") = IIf(txtCusUsd.Text.Trim = "", 0, Format(CDec(IIf(txtCusUsd.Text.Trim = "", 0, txtCusUsd.Text.Trim)), "########0.0000"))
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cuscad") = IIf(txtCusCad.Text.Trim = "", 0, Format(CDec(IIf(txtCusCad.Text.Trim = "", 0, txtCusCad.Text.Trim)), "########0.0000"))


    '    '    '*** Check Shipping Item Status
    '    '    '*** Phase 2
    '    '    'If txtItmNoVen.Text = "" Then
    '    '    '    If cboPcking.Text <> "" And cboPcking.Text <> " / 0 / 0 / 0 / 0 / / /" And cboColCde.Text <> "" And _
    '    '    '        Val(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_basprc").ToString) > 0 And _
    '    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_qutitmsts").ToString <> "I - Inactive" Then
    '    '    '        txtQutItmSts.Text = "A - Active"
    '    '    '    Else
    '    '    '        'txtQutItmSts.Text = "INCOMPLETE"
    '    '    '        txtQutItmSts.Text = "I - Inactive"
    '    '    '    End If
    '    '    'Else
    '    '    '    If cboUM.Text <> "" And _
    '    '    '        cboFtyPrcTrm.Text <> "" And cboDtlPrcTrm.Text <> "" And cboTranTrm.Text <> "" And txtColCde.Text <> "" And _
    '    '    '        Val(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_basprc").ToString) > 0 And _
    '    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_qutitmsts").ToString <> "I - Inactive" Then
    '    '    '        txtQutItmSts.Text = "A - Active"
    '    '    '    Else
    '    '    '        txtQutItmSts.Text = "I - Inactive"
    '    '    '    End If
    '    '    'End If

    '    '    txtQutItmSts.Text = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_qutitmsts")
    '    '    If Split(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_qutitmsts"), " - ")(0) = "W" _
    '    '            And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_apprve") = "N" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_qutitmsts") = "W - Wait for Approval"
    '    '        txtQutItmSts.Text = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_qutitmsts")
    '    '    End If
    '    '    If Split(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_qutitmsts"), " - ")(0) = "E" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_qutitmsts") = "E - Expiry"
    '    '        txtQutItmSts.Text = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_qutitmsts")
    '    '    End If
    '    '    If Split(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_qutitmsts"), " - ")(0) = "A" _
    '    '            Or rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_apprve") = "Y" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_qutitmsts") = "A - Active"
    '    '        txtQutItmSts.Text = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_qutitmsts")
    '    '    End If

    '    '    '''20140127 
    '    '    If chkApproveDtl.Checked = True Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_apprve") = "Y"
    '    '    End If



    '    '    If optImageY.Checked = True Then
    '    '        image = "Y"
    '    '    Else
    '    '        image = "N"
    '    '    End If
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_image") = image
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_imgpth") = IIf(IsDBNull(pth), "", pth)
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_TOShipport") = txtTOShipport.Text

    '    '    If Not IsDate(txtDTLFtyShpDateStr.Text) Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyshpstr") = "01/01/1900"
    '    '    Else
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyshpstr") = txtDTLFtyShpDateStr.Text
    '    '    End If
    '    '    '''special handle 20140122
    '    '    If txtDTLFtyShpDateStr.Text.Trim = "11/19/00" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyshpstr") = "01/01/1900"
    '    '    End If
    '    '    If txtDTLFtyShpDateStr.Text.Trim = "11/19/2000" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyshpstr") = "01/01/1900"
    '    '    End If
    '    '    If DateDiff("d", rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyshpstr"), "11/19/2000") = 0 Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyshpstr") = "01/01/1900"
    '    '    End If


    '    '    If Not IsDate(txtDTLFtyShpDateEnd.Text) Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyshpend") = "01/01/1900"
    '    '    Else
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyshpend") = txtDTLFtyShpDateEnd.Text
    '    '    End If
    '    '    '''special handle 20140122
    '    '    If txtDTLFtyShpDateEnd.Text.Trim = "11/19/00" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyshpend") = "01/01/1900"
    '    '    End If
    '    '    If txtDTLFtyShpDateEnd.Text.Trim = "11/19/2000" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyshpend") = "01/01/1900"
    '    '    End If
    '    '    If DateDiff("d", rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyshpend"), "11/19/2000") = 0 Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyshpend") = "01/01/1900"
    '    '    End If


    '    '    If Not IsDate(txtDTLCustShpDateStr.Text) Then

    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cushpstr") = "01/01/1900"

    '    '    Else
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cushpstr") = txtDTLCustShpDateStr.Text
    '    '    End If
    '    '    '''special handle 20140122
    '    '    If txtDTLCustShpDateStr.Text.Trim = "11/19/00" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cushpstr") = "01/01/1900"
    '    '    End If
    '    '    If txtDTLCustShpDateStr.Text.Trim = "11/19/2000" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cushpstr") = "01/01/1900"
    '    '    End If
    '    '    If DateDiff("d", rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cushpstr"), "11/19/2000") = 0 Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cushpstr") = "01/01/1900"
    '    '    End If


    '    '    If Not IsDate(txtDTLCustShpDateEnd.Text) Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cushpend") = "01/01/1900"
    '    '    Else
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cushpend") = txtDTLCustShpDateEnd.Text
    '    '    End If
    '    '    '''special handle 20140122
    '    '    If txtDTLCustShpDateEnd.Text.Trim = "11/19/00" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cushpend") = "01/01/1900"
    '    '    End If
    '    '    If txtDTLCustShpDateEnd.Text.Trim = "11/19/2000" Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cushpend") = "01/01/1900"
    '    '    End If
    '    '    If DateDiff("d", rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cushpend"), "11/19/2000") = 0 Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cushpend") = "01/01/1900"
    '    '    End If


    '    '    'Fill QUPRCEMT
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_itmno") = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_itmno")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_untcde") = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_untcde")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrqty") = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrqty")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrqty") = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrqty")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cft") = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cft")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cbm") = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cbm")

    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyprctrm") = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyprctrm")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_prctrm") = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_prctrm")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_trantrm") = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_trantrm")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_fcurcde") = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_fcurcde")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftycst") = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftycst")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyprc") = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_ftyprc")

    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_mu") = IIf(txtMU.Text = "", 0, txtMU.Text)
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_pkgper") = IIf(txtPckCstAmt.Text = "", 0, txtPckCstAmt.Text)
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_icmper") = IIf(txtItmCommAmt.Text = "", 0, txtItmCommAmt.Text)

    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cus1sp") = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cus1sp")
    '    '    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cus1dp") = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cus1dp")

    '    '    If (rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("mode").ToString = "NEW" Or _
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("mode").ToString = "UPD") And _
    '    '        IIf(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_pckseq").ToString = "", 0, rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_pckseq")) = 0 Then
    '    '        '*** Phase 2
    '    '        If txtItmNoVen.Text = "" Then
    '    '            If cboPcking.Text <> "" And cboPcking.Text <> " / 0 / 0 / 0 / 0 / / /" Then
    '    '                'bug
    '    '                If Not rs_IMPCKINF.Tables("RESULT") Is Nothing Then
    '    '                    If (rs_IMPCKINF.Tables("RESULT").Rows.Count > 0) Then
    '    '                        If rs_IMPCKINF.Tables("RESULT").Rows.Count > 0 Then
    '    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_pckseq") = rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_pckseq")

    '    '                            '******************* Update vendor type and cat to SHIPGDTL **********
    '    '                            If rs_SHIPPING.Tables("RESULT").Rows.Count > 0 Then
    '    '                                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("vbi_ventyp") = rs_SHIPPING.Tables("RESULT").Rows(0)("vbi_ventyp")
    '    '                                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("ibi_catlvl3") = rs_SHIPPING.Tables("RESULT").Rows(0)("ibi_catlvl3")
    '    '                            End If
    '    '                        End If
    '    '                    End If
    '    '                End If

    '    '            Else
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_basprc") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrdin") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrwin") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrhin") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrdin") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrwin") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrhin") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrdcm") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrwcm") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrhcm") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrdcm") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrwcm") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrhcm") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("inner_in") = "0x0x0"
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("master_in") = "0x0x0"
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("inner_cm") = "0x0x0"
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("master_cm") = "0x0x0"
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_grswgt") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_netwgt") = 0
    '    '            End If
    '    '        Else
    '    '            If cboUM.Text <> "" And _
    '    '                cboFtyPrcTrm.Text <> "" And cboDtlPrcTrm.Text <> "" And cboTranTrm.Text <> "" Then
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_pckseq") = 1

    '    '                '******************* Update vendor type and cat to SHIPGDTL **********
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("vbi_ventyp") = "E"
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("ibi_catlvl3") = "Standard"
    '    '            Else
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_basprc") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrdin") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrwin") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrhin") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrdin") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrwin") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrhin") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrdcm") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrwcm") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrhcm") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrdcm") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrwcm") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrhcm") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("inner_in") = "0x0x0"
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("master_in") = "0x0x0"
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("inner_cm") = "0x0x0"
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("master_cm") = "0x0x0"
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_grswgt") = 0
    '    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_netwgt") = 0
    '    '            End If
    '    '        End If
    '    '    ElseIf rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("mode").ToString = "UPD" And _
    '    '        IIf(Not IsNumeric(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_pckseq").ToString), 0, rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_pckseq")) = 0 Then
    '    '        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_pckseq") = rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_pckseq")
    '    '    End If

    '    'End If




    '    'End Sub

    '    Private Function save_ShippingHeader() As Boolean
    '        save_ShippingHeader = False

    '        Dim hnh_cocde As String
    '        Dim hnh_shpno As String
    '        Dim hnh_issdat As String
    '        Dim hnh_rvsdat As String
    '        Dim hnh_cus1no As String
    '        Dim hnh_cus2no As String
    '        Dim hnh_smpshp As String
    '        Dim hnh_shpsts As String
    '        Dim hnh_ves As String
    '        Dim hnh_voy As String
    '        Dim hnh_slnonb As String
    '        Dim hnh_arrdat As String
    '        Dim hnh_potloa As String
    '        Dim hnh_dst As String
    '        Dim hnh_crr As String
    '        Dim hnh_crrso As String
    '        Dim hnh_goddsc As String

    '        Dim hnh_bilent As String
    '        Dim hnh_biladr As String
    '        Dim hnh_bilstt As String
    '        Dim hnh_bilcty As String
    '        Dim hnh_bilzip As String
    '        Dim hnh_bilrmk As String

    '        Dim hnh_ttlctn As String
    '        Dim hnh_ttlnwg As String
    '        Dim hnh_ttlgwg As String
    '        Dim hnh_untamt As String
    '        Dim hnh_ttlamt As String
    '        Dim hnh_lcno As String

    '        Dim hnh_lcbank As String
    '        Dim hnh_cntyorgn As String

    '        Dim hnh_updusr As String
    '        Dim hnh_creusr As String


    '        'hnh_COCDE = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cocde")
    '        'hnh_QUTNO = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_qutno")
    '        'hnh_ISSDAT = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_issdat")
    '        'hnh_RVSDAT = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_rvsdat")
    '        'hnh_CUS1NO = Split(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus1no"), " -")(0)


    '        'If Not IsDBNull(rs_SHCBNHDR.Tables("RESULT").Rows(0)("hnh_cus2no")) Then
    '        '    hnh_CUS2NO = IIf(IsDBNull(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus2no")) = True, "", Split(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus2no"), " -")(0))
    '        '    hnh_CUS2ST = Replace(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus2st"), "'", "''")
    '        '    hnh_CUS2CY = Replace(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus2cy"), "'", "''")
    '        '    hnh_CUS2ZP = Replace(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus2zp"), "'", "''")
    '        '    hnh_CUS2CP = Replace(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus2cp"), "'", "''")

    '        '    hnh_CUS2AD = Replace(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus2ad"), "'", "''")
    '        'Else
    '        '    hnh_CUS2NO = ""
    '        '    hnh_CUS2ST = ""
    '        '    hnh_CUS2CY = ""
    '        '    hnh_CUS2ZP = ""
    '        '    hnh_CUS2CP = ""

    '        '    hnh_CUS2AD = ""
    '        'End If



    '        ''hnh_CUS2NO = IIf(IsDBNull(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus2no")) = True, "", Split(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus2no"), " -")(0))

    '        'hnh_RELATN = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_relatn")
    '        'hnh_CUS1AD = Replace(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus1ad"), "'", "''")
    '        ''hnh_CUS2AD = Replace(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus2ad"), "'", "''")
    '        'hnh_CUS1ST = Replace(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus1st"), "'", "''")
    '        'hnh_CUS1CY = Replace(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus1cy"), "'", "''")
    '        'hnh_CUS1ZP = Replace(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus1zp"), "'", "''")
    '        ''hnh_CUS2ST = Replace(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus2st"), "'", "''")
    '        ''hnh_CUS2CY = Replace(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus2cy"), "'", "''")
    '        ''hnh_CUS2ZP = Replace(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus2zp"), "'", "''")
    '        'hnh_CUS1CP = Replace(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus1cp"), "'", "''")
    '        ''hnh_CUS2CP = Replace(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus2cp"), "'", "''")
    '        'hnh_SALREP = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_salrep")
    '        'If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cusagt") = "" Then
    '        '    hnh_CUSAGT = ""
    '        'Else
    '        '    hnh_CUSAGT = Split(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cusagt"), " -")(0)
    '        'End If
    '        'hnh_VALDAT = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_valdat")
    '        'If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_smpprd") = "" Then
    '        '    hnh_SMPPRD = ""
    '        'Else
    '        '    hnh_SMPPRD = Split(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_smpprd"), " -")(0)
    '        'End If
    '        'If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_smpfgt") = "" Then
    '        '    hnh_SMPFGT = ""
    '        'Else
    '        '    hnh_SMPFGT = Split(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_smpfgt"), " -")(0)
    '        'End If
    '        'If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_prctrm") = "" Then
    '        '    hnh_PRCTRM = ""
    '        'Else
    '        '    hnh_PRCTRM = Split(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_prctrm"), " -")(0)
    '        'End If
    '        'If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_paytrm") = "" Then
    '        '    hnh_PAYTRM = ""
    '        'Else
    '        '    hnh_PAYTRM = Split(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_paytrm"), " -")(0)
    '        'End If
    '        'If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_curcde") = "" Then
    '        '    hnh_CURCDE = ""
    '        'Else
    '        '    hnh_CURCDE = Split(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_curcde"), " -")(0)
    '        'End If
    '        'hnh_QUTSTS = IIf(IsDBNull(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_qutsts")) = True, "A", Split(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_qutsts"), " -")(0))
    '        'hnh_RMK = Replace(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_rmk"), "'", "''")
    '        'hnh_CONALLTOPC = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_conalltopc")
    '        'hnh_YEAR = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_Year")
    '        'hnh_SEASON = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_Season")
    '        'hnh_DESC = Replace(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_Desc"), "'", "''")
    '        'hnh_QUPLUS = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_quplus")
    '        'hnh_QUMINUS = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_quminus")
    '        'hnh_CUREXRAT = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_curexrat")
    '        'hnh_CUREXEFFDAT = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_curexeffdat")
    '        'hnh_CUGRPTYP_INT = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cugrptyp_int")
    '        'hnh_CUGRPTYP_EXT = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cugrptyp_ext")
    '        'hnh_DEPT = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_dept")
    '        'hnh_SALDIVTEM = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_saldivtem")
    '        ' ''bug
    '        'If Not IsDBNull(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_srname")) Then

    '        '    If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_srname") = "" Then
    '        '        hnh_SRNAME = ""
    '        '    Else
    '        '        hnh_SRNAME = Split(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_srname"), "(")(1)
    '        '        hnh_SRNAME = hnh_SRNAME.Substring(0, hnh_SRNAME.Length - 1)
    '        '    End If
    '        'End If

    '        'hnh_ftyshpstr = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ftyshpstr")
    '        'hnh_ftyshpend = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ftyshpend")
    '        'hnh_cushpstr = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cushpstr")
    '        'hnh_cushpend = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cushpend")

    '        'hnh_CREUSR = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr")

    '        If IsDBNull(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_shpno")) Then
    '            Exit Function
    '        End If
    '        hnh_cocde = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cocde")
    '        hnh_shpno = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_shpno")
    '        hnh_issdat = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_issdat")
    '        hnh_rvsdat = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_rvsdat")
    '        hnh_cus1no = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus1no")
    '        hnh_cus2no = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus2no")
    '        hnh_smpshp = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_smpshp")
    '        hnh_shpsts = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_shpsts")
    '        hnh_ves = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ves")
    '        hnh_voy = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_voy")
    '        hnh_slnonb = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_slnonb")
    '        hnh_arrdat = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_arrdat")
    '        hnh_potloa = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_potloa")
    '        hnh_dst = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_dst")
    '        hnh_crr = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_crr")
    '        hnh_crrso = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_crrso")
    '        hnh_goddsc = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_goddsc")

    '        hnh_bilent = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_bilent")
    '        hnh_biladr = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_biladr")
    '        hnh_bilstt = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_bilstt")
    '        hnh_bilcty = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_bilcty")
    '        hnh_bilzip = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_bilzip")
    '        hnh_bilrmk = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_bilrmk")

    '        hnh_ttlctn = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ttlctn")
    '        hnh_ttlnwg = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ttlnwg")
    '        hnh_ttlgwg = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ttlgwg")
    '        hnh_untamt = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_untamt")
    '        hnh_ttlamt = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ttlamt")
    '        hnh_lcno = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_lcno")

    '        hnh_lcbank = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_lcbank")
    '        hnh_cntyorgn = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cntyorgn")

    '        hnh_updusr = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_updusr")
    '        hnh_creusr = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr")

    '        If Add_flag = True Then

    '            '            If hnh_creusr = "~*ADD*~" Or hnh_creusr = "~*NEW*~" Then
    '            gspStr = "sp_insert_SHIPGHDR '" & _
    '                                                hnh_cocde & "','" & _
    '                                                hnh_shpno & "','" & _
    '                                                hnh_issdat & "','" & _
    '                                                hnh_rvsdat & "','" & _
    '                                                hnh_cus1no & "','" & _
    '                                                hnh_cus2no & "','" & _
    '                                                hnh_smpshp & "','" & _
    '                                                hnh_shpsts & "','" & _
    '                                                hnh_ves & "','" & _
    '                                                hnh_voy & "','" & _
    '                                                hnh_slnonb & "','" & _
    '                                                hnh_arrdat & "','" & _
    '                                                hnh_potloa & "','" & _
    '                                                hnh_dst & "','" & _
    '                                                hnh_crr & "','" & _
    '                                                hnh_crrso & "','" & _
    '                                                hnh_goddsc & "','" & _
    '                                                hnh_bilent & "','" & _
    '                                                hnh_biladr & "','" & _
    '                                                hnh_bilstt & "','" & _
    '                                                hnh_bilcty & "','" & _
    '                                                hnh_bilzip & "','" & _
    '                                                hnh_bilrmk & "','" & _
    '                                                hnh_ttlctn & "','" & _
    '                                                hnh_ttlnwg & "','" & _
    '                                                hnh_ttlgwg & "','" & _
    '                                                hnh_untamt & "','" & _
    '                                                hnh_ttlamt & "','" & _
    '                                                hnh_lcno & "','" & _
    '                                                hnh_lcbank & "','" & _
    '                                                hnh_cntyorgn & "','" & _
    '                                                gsUsrID & "'"

    '            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
    '            If rtnLong <> RC_SUCCESS Then
    '                MsgBox("Error on loading save_SHIPPING sp_insert_SHIPPING :" & rtnStr)
    '                save_ShippingHeader = False
    '                Exit Function
    '            End If
    '        ElseIf hnh_creusr = "~*UPD*~" Then
    '            gspStr = "sp_update_SHIPGHDR '" & _
    '                                                hnh_cocde & "','" & _
    '                                                hnh_shpno & "','" & _
    '                                                hnh_issdat & "','" & _
    '                                                hnh_rvsdat & "','" & _
    '                                                hnh_cus1no & "','" & _
    '                                                hnh_cus2no & "','" & _
    '                                                hnh_smpshp & "','" & _
    '                                                hnh_shpsts & "','" & _
    '                                                hnh_ves & "','" & _
    '                                                hnh_voy & "','" & _
    '                                                hnh_slnonb & "','" & _
    '                                                hnh_arrdat & "','" & _
    '                                                hnh_potloa & "','" & _
    '                                                hnh_dst & "','" & _
    '                                                hnh_crr & "','" & _
    '                                                hnh_crrso & "','" & _
    '                                                hnh_goddsc & "','" & _
    '                                                hnh_bilent & "','" & _
    '                                                hnh_biladr & "','" & _
    '                                                hnh_bilstt & "','" & _
    '                                                hnh_bilcty & "','" & _
    '                                                hnh_bilzip & "','" & _
    '                                                hnh_bilrmk & "','" & _
    '                                                hnh_ttlctn & "','" & _
    '                                                hnh_ttlnwg & "','" & _
    '                                                hnh_ttlgwg & "','" & _
    '                                                hnh_untamt & "','" & _
    '                                                hnh_ttlamt & "','" & _
    '                                                hnh_lcno & "','" & _
    '                                                hnh_lcbank & "','" & _
    '                                                hnh_cntyorgn & "','" & _
    '                                                gsUsrID & "'"

    '            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
    '            If rtnLong <> RC_SUCCESS Then
    '                MsgBox("Error on loading save_SHIPPING sp_update_SHIPPING :" & rtnStr)
    '                save_ShippingHeader = False
    '                Exit Function
    '            End If
    '        End If
    '        save_ShippingHeader = True
    '    End Function


    '    Private Function save_SHSHPMRK() As Boolean
    '        save_SHSHPMRK = False
    '        Dim hsm_creusr As String
    '        Dim hsm_cocde As String

    '        hsm_creusr = rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_creusr")
    '        hsm_cocde = rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_cocde")

    '        If Add_flag = True Then

    '        ElseIf hsm_creusr = "~*UPD*~" Then
    '            gspStr = "sp_Update_SHSHPMRK '" & _
    '                                                hsm_cocde & "','" & _
    '                rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_ShpNo") & "','" & _
    '                rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_invno") & "','" & rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_ordno") & "','" & _
    '                rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_shptyp") & "','" & rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_imgnam") & "','" & _
    '                rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_imgpth") & "','" & rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_engdsc") & "','" & _
    '                rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_engrmk") & "','" & gsUsrID & "'"


    '            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
    '            If rtnLong <> RC_SUCCESS Then
    '                MsgBox("Error on loading save_SHIPPING sp_update_SHIPPING :" & rtnStr)
    '                save_SHSHPMRK = False
    '                Exit Function
    '            End If
    '        End If
    '        save_SHSHPMRK = True
    '    End Function

    '    Private Function save_SHINVHDR() As Boolean
    '        save_SHINVHDR = False
    '        Dim hiv_creusr As String
    '        Dim hiv_cocde As String

    '        hiv_creusr = rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_creusr")
    '        hiv_cocde = rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_cocde")

    '        If Add_flag = True Then

    '        ElseIf hiv_creusr = "~*UPD*~" Then
    '            gspStr = "sp_update_SHINVHDR  '" & _
    '                rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_COCDE") & "','" & _
    '                rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_ShpNo") & "','" & _
    '                rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_invno") & "','" & rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_invdat") & "','" & _
    '                rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_prctrm") & "','" & rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_paytrm") & "','" & _
    '                rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_doctyp") & "','" & rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_doc") & "','" & _
    '                rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_cover") & "','" & rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_ftrrmk") & "','" & _
    '                rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_untamt") & "','" & rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_ttlamt") & "','" & _
    '                rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_ttlvol") & "','" & rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_ttlctn") & "','" & _
    '                rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_bank") & "','" & rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_aformat") & "','" & _
    '                rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_invamt") & "','" & rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_afamt") & "','" & _
    '                rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_invsts") & "','" & rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_lcstmt") & "','" & _
    '                gsUsrID


    '            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
    '            If rtnLong <> RC_SUCCESS Then
    '                MsgBox("Error on loading save_SHIPPING sp_update_SHIPPING :" & rtnStr)
    '                save_SHINVHDR = False
    '                Exit Function
    '            End If
    '        End If
    '        save_SHINVHDR = True
    '    End Function

    Private Function save_ShippingDetail() As Boolean
        save_ShippingDetail = False

        'If save_shippingDetail() = False Then
        '    Exit Function
        'End If
        Dim hnd_cocde As String
        Dim hnd_shpno As String
        Dim hnd_shpseq As String
        Dim hnd_ctrcfs As String
        Dim hnd_sealno As String
        Dim hnd_ctrsiz As String
        Dim hnd_pckrmk As String
        Dim hnd_jobno As String
        Dim hnd_ordno As String
        Dim hnd_ordseq As String
        Dim hnd_cuspo As String
        Dim hnd_cusitm As String
        Dim hnd_itmno As String
        Dim hnd_itmtyp As String
        Dim hnd_itmdsc As String
        Dim hnd_colcde As String
        Dim hnd_cuscol As String
        Dim hnd_coldsc As String
        Dim hnd_shpqty As String
        Dim hnd_untcde As String
        Dim hnd_ctnstr As String
        Dim hnd_ctnend As String
        Dim hnd_inrctn As String
        Dim hnd_mtrctn As String
        Dim hnd_vol As String
        Dim hnd_mtrdcm As String
        Dim hnd_mtrwcm As String
        Dim hnd_mtrhcm As String
        Dim hnd_actvol As String
        Dim hnd_grswgt As String
        Dim hnd_netwgt As String
        Dim hnd_itmshm As String
        Dim hnd_cmprmk As String
        Dim hnd_mannam As String
        Dim hnd_manadr As String
        Dim hnd_ttlvol As String
        Dim hnd_ttlnet As String
        Dim hnd_ttlgrs As String
        Dim hnd_ttlctn As String
        Dim hnd_untsel As String
        Dim hnd_selprc As String
        Dim hnd_untamt As String
        Dim hnd_ttlamt As String
        Dim hnd_invno As String
        Dim hnd_prctrm As String
        Dim hnd_paytrm As String
        Dim hnd_purord As String
        Dim hnd_purseq As String
        Dim hnd_venno As String
        Dim hnd_cusven As String
        Dim hnd_cusstyno As String
        Dim hnd_updusr As String
        Dim hnd_CREUSR As String
        Dim DEL_FLAG As String

        Dim i As Integer

        For i = 0 To rs_SHCBNDTL.Tables("RESULT").Rows.Count - 1
            DEL_FLAG = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("Del")

            hnd_cocde = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cocde")
            hnd_shpno = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_shpno")
            hnd_shpseq = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_shpseq")
            hnd_ctrcfs = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_ctrcfs")
            hnd_sealno = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_sealno")
            hnd_ctrsiz = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_ctrsiz")
            hnd_ctrsiz = Replace(hnd_ctrsiz, "'", "''")
            hnd_pckrmk = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_pckrmk")
            hnd_jobno = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_jobno")
            hnd_ordno = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_ordno")
            hnd_ordseq = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_ordseq")
            hnd_cuspo = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cuspo")
            hnd_cusitm = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cusitm")
            hnd_itmno = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_itmno")
            hnd_itmtyp = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_itmtyp")
            hnd_itmdsc = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_itmdsc")
            hnd_colcde = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_colcde")
            hnd_cuscol = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cuscol")
            hnd_coldsc = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_coldsc")
            hnd_shpqty = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_shpqty")
            hnd_untcde = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_untcde")
            hnd_ctnstr = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_ctnstr")
            hnd_ctnend = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_ctnend")
            hnd_inrctn = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_inrctn")
            hnd_mtrctn = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_mtrctn")
            hnd_vol = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_vol")
            hnd_mtrdcm = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_mtrdcm")
            hnd_mtrwcm = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_mtrwcm")
            hnd_mtrhcm = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_mtrhcm")
            hnd_actvol = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_actvol")
            hnd_grswgt = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_grswgt")
            hnd_netwgt = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_netwgt")
            hnd_itmshm = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_itmshm")
            hnd_cmprmk = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cmprmk")
            hnd_mannam = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_mannam")
            hnd_manadr = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_manadr")
            hnd_ttlvol = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_ttlvol")
            hnd_ttlnet = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_ttlnet")
            hnd_ttlgrs = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_ttlgrs")
            hnd_ttlctn = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_ttlctn")
            hnd_untsel = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_untsel")
            hnd_selprc = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_selprc")
            hnd_untamt = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_untamt")
            hnd_ttlamt = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_ttlamt")
            hnd_invno = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_invno")
            hnd_prctrm = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_prctrm")
            hnd_paytrm = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_paytrm")
            hnd_purord = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_purord")
            hnd_purseq = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_purseq")
            hnd_venno = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_venno")
            hnd_cusven = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cusven")
            hnd_cusstyno = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cusstyno")
            hnd_updusr = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_updusr")

            hnd_CREUSR = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_CREUSR")

            gspStr = ""


            If DEL_FLAG = "Y" Or hnd_CREUSR = "~*DEL*~" Then

                '''***)
                gspStr = "sp_physical_delete_shipgdtl '" & hnd_cocde & "','" & hnd_shpno & "','" & hnd_shpseq & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_shippingDetail sp_physical_delete_shipgdtl:" & rtnStr)
                    save_ShippingDetail = False
                    Exit Function
                End If


            ElseIf hnd_CREUSR = "~*ADD*~" Or hnd_CREUSR = "~*NEW*~" Then

                gspStr = "sp_insert_shipgdtl '" & _
                                                 hnd_cocde & "','" & _
                                                 hnd_shpno & "','" & _
                                                 hnd_shpseq & "','" & _
                                                 hnd_ctrcfs & "','" & _
                                                 hnd_sealno & "','" & _
                                                 hnd_ctrsiz & "','" & _
                                                 hnd_pckrmk & "','" & _
                                                 hnd_jobno & "','" & _
                                                 hnd_ordno & "','" & _
                                                 hnd_ordseq & "','" & _
                                                 hnd_cuspo & "','" & _
                                                 hnd_cusitm & "','" & _
                                                 hnd_itmno & "','" & _
                                                 hnd_itmtyp & "','" & _
                                                 hnd_itmdsc & "','" & _
                                                 hnd_colcde & "','" & _
                                                 hnd_cuscol & "','" & _
                                                 hnd_coldsc & "','" & _
                                                 hnd_shpqty & "','" & _
                                                 hnd_untcde & "','" & _
                                                 hnd_ctnstr & "','" & _
                                                 hnd_ctnend & "','" & _
                                                 hnd_inrctn & "','" & _
                                                 hnd_mtrctn & "','" & _
                                                 hnd_vol & "','" & _
                                                 hnd_mtrdcm & "','" & _
                                                 hnd_mtrwcm & "','" & _
                                                 hnd_mtrhcm & "','" & _
                                                 hnd_actvol & "','" & _
                                                 hnd_grswgt & "','" & _
                                                 hnd_netwgt & "','" & _
                                                 hnd_itmshm & "','" & _
                                                 hnd_cmprmk & "','" & _
                                                 hnd_mannam & "','" & _
                                                 hnd_manadr & "','" & _
                                                 hnd_ttlvol & "','" & _
                                                 hnd_ttlnet & "','" & _
                                                 hnd_ttlgrs & "','" & _
                                                 hnd_ttlctn & "','" & _
                                                 hnd_untsel & "','" & _
                                                 hnd_selprc & "','" & _
                                                 hnd_untamt & "','" & _
                                                 hnd_ttlamt & "','" & _
                                                 hnd_invno & "','" & _
                                                 hnd_prctrm & "','" & _
                                                 hnd_paytrm & "','" & _
                                                 hnd_purord & "','" & _
                                                 hnd_purseq & "','" & _
                                                 hnd_venno & "','" & _
                                                 hnd_cusven & "','" & _
                                                 hnd_cusstyno & "','" & _
                                                 gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_shippingDetail sp_insert_shipgdtl :" & rtnStr)
                    save_ShippingDetail = False
                    Exit Function
                End If
            ElseIf hnd_CREUSR = "~*UPD*~" Then

                gspStr = "sp_update_shipgdtl '" & _
                                                 hnd_cocde & "','" & _
                                                 hnd_shpno & "','" & _
                                                 hnd_shpseq & "','" & _
                                                 hnd_ctrcfs & "','" & _
                                                 hnd_sealno & "','" & _
                                                 hnd_ctrsiz & "','" & _
                                                 hnd_pckrmk & "','" & _
                                                 hnd_jobno & "','" & _
                                                 hnd_ordno & "','" & _
                                                 hnd_ordseq & "','" & _
                                                 hnd_cuspo & "','" & _
                                                 hnd_cusitm & "','" & _
                                                 hnd_itmno & "','" & _
                                                 hnd_itmtyp & "','" & _
                                                 hnd_itmdsc & "','" & _
                                                 hnd_colcde & "','" & _
                                                 "" & "','" & _
                                                 hnd_cuscol & "','" & _
                                                 hnd_coldsc & "','" & _
                                                 hnd_shpqty & "','" & _
                                                 hnd_untcde & "','" & _
                                                 hnd_ctnstr & "','" & _
                                                 hnd_ctnend & "','" & _
                                                 hnd_inrctn & "','" & _
                                                 hnd_mtrctn & "','" & _
                                                 hnd_vol & "','" & _
                                                 hnd_mtrdcm & "','" & _
                                                 hnd_mtrwcm & "','" & _
                                                 hnd_mtrhcm & "','" & _
                                                 hnd_actvol & "','" & _
                                                 hnd_grswgt & "','" & _
                                                 hnd_netwgt & "','" & _
                                                 hnd_itmshm & "','" & _
                                                 hnd_cmprmk & "','" & _
                                                 hnd_mannam & "','" & _
                                                 hnd_manadr & "','" & _
                                                 hnd_ttlvol & "','" & _
                                                 hnd_ttlnet & "','" & _
                                                 hnd_ttlgrs & "','" & _
                                                 hnd_ttlctn & "','" & _
                                                 hnd_untsel & "','" & _
                                                 hnd_selprc & "','" & _
                                                 hnd_untamt & "','" & _
                                                 hnd_ttlamt & "','" & _
                                                 hnd_invno & "','" & _
                                                 hnd_prctrm & "','" & _
                                                 hnd_paytrm & "','" & _
                                                 hnd_purord & "','" & _
                                                 hnd_purseq & "','" & _
                                                 hnd_venno & "','" & _
                                                 hnd_cusven & "','" & _
                                                 hnd_cusstyno & "','" & _
                                     gsUsrID & "'"

                'MsgBox(i)

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_shippingDetail sp_update_shipgdtl :" & rtnStr)
                    save_ShippingDetail = False
                    Exit Function
                End If
            End If
            gi_saved_items_count = gi_saved_items_count + 1

        Next i

        If gi_saved_items_count = 0 Then
            MsgBox("No item saved! Please Check the Shipping  and the item(s)!")
            save_ShippingDetail = False
            Exit Function
        End If
        save_ShippingDetail = True
    End Function

    Private Function save_SHIPGDTL() As Boolean
        save_SHIPGDTL = False
        '        gi_saved_items_count = 0

        '        Dim DEL_FLAG As String
        '        Dim hnd_COCDE As String
        '        Dim hnd_QUTNO As String
        '        Dim hnd_shpseq As String
        '        Dim hnd_ITMNO As String
        '        Dim hnd_ITMSTS As String
        '        Dim hnd_ITMDSC As String
        '        Dim hnd_ALSITMNO As String
        '        Dim hnd_ALSCOLCDE As String
        '        Dim hnd_CONFTR As String
        '        Dim hnd_CONTOPC As String
        '        Dim hnd_PCPRC As String
        '        Dim hnd_HSTREF As String
        '        Dim hnd_COLCDE As String
        '        Dim hnd_CUSCOL As String
        '        Dim hnd_COLDSC As String
        '        Dim hnd_PCKSEQ As String
        '        Dim hnd_UNTCDE As String
        '        Dim hnd_INRQTY As String
        '        Dim hnd_MTRQTY As String
        '        Dim hnd_CFT As String
        '        Dim hnd_CURCDE As String
        '        Dim hnd_CUS1SP As String
        '        Dim hnd_CUS2SP As String
        '        Dim hnd_CUS1DP As String
        '        Dim hnd_CUS2DP As String
        '        Dim hnd_ONETIM As String
        '        Dim hnd_DISCNT As String
        '        Dim hnd_MOFLAG As String
        '        Dim hnd_ORGMOQ As String
        '        Dim hnd_ORGMOA As String
        '        Dim hnd_MOQ As String
        '        Dim hnd_MOA As String
        '        Dim hnd_SMPQTY As String
        '        Dim hnd_HRMCDE As String
        '        Dim hnd_DTYRAT As String
        '        Dim hnd_DEPT As String
        '        Dim hnd_CUSUSD As String
        '        Dim hnd_CUSCAD As String
        '        Dim hnd_VENNO As String
        '        Dim hnd_SUBCDE As String
        '        Dim hnd_VENITM As String
        '        Dim hnd_FTYPRC As String
        '        Dim hnd_FTYCST As String
        '        Dim hnd_NOTE As String
        '        Dim hnd_IMAGE As String
        '        Dim hnd_INRDIN As String
        '        Dim hnd_INRWIN As String
        '        Dim hnd_INRHIN As String
        '        Dim hnd_MTRDIN As String
        '        Dim hnd_MTRWIN As String
        '        Dim hnd_MTRHIN As String
        '        Dim hnd_INRDCM As String
        '        Dim hnd_INRWCM As String
        '        Dim hnd_INRHCM As String
        '        Dim hnd_MTRDCM As String
        '        Dim hnd_MTRWCM As String
        '        Dim hnd_MTRHCM As String
        '        Dim hnd_GRSWGT As String
        '        Dim hnd_NETWGT As String
        '        Dim hnd_COSMTH As String
        '        Dim hnd_SMPPRC As String
        '        Dim hnd_CUSITM As String
        '        Dim CUS1NO As String
        '        Dim CUS1NA As String
        '        Dim CUS2NO As String
        '        Dim CUS2NA As String
        '        Dim hnd_PRCSEC As String
        '        Dim hnd_GRSMGN As String
        '        Dim hnd_BASPRC As String
        '        Dim hnd_TBM As String
        '        Dim hnd_TBMSTS As String
        '        Dim RVSDAT As String
        '        Dim hnd_APPRVE As String
        '        Dim hnd_PDABPDIFF As String
        '        Dim hnd_PCKITR As String
        '        Dim hnd_STKQTY As String
        '        Dim hnd_CUSQTY As String
        '        Dim hnd_SMPUNT As String
        '        Dim hnd_QUTITMSTS As String
        '        Dim hnd_FCURCDE As String
        '        Dim SMPPRD As String
        '        Dim hnd_ITMTYP As String
        '        Dim hnh_QUTSTS As String
        '        Dim hnd_PRCTRM As String
        '        Dim hnd_CUSVEN As String
        '        Dim hnd_CUSSUB As String
        '        Dim hnd_FTYPRCTRM As String
        '        Dim hnd_CUSSTYNO As String
        '        Dim hnd_CBM As String
        '        Dim hnd_UPC As String
        '        Dim hnd_SPECPCK As String
        '        Dim hnd_FTYTMPITM As String
        '        Dim hnd_FTYTMPITMNO As String
        '        Dim hnd_CUSTITMCAT As String
        '        Dim hnd_CUSTITMCATFML As String
        '        Dim hnd_CUSTITMCATAMT As String
        '        Dim hnd_PMU As String
        '        Dim hnd_IMRMK As String
        '        Dim hnd_RNDSTS As String
        '        Dim hnd_CALPMU As String
        '        Dim hnd_MOQUNTTYP As String
        '        Dim hnd_QUTDAT As String
        '        Dim hnd_CUS1NO As String
        '        Dim hnd_CUS2NO As String
        '        Dim hnd_TRANTRM As String
        '        Dim hnd_EFFDAT As String
        '        Dim hnd_EXPDAT As String
        '        Dim hnd_ITMNOTYP As String
        '        Dim hnd_ITMNOREAL As String
        '        Dim hnd_ITMNOTMP As String
        '        Dim hnd_ITMNOVEN As String
        '        Dim hnd_ITMNOVENNO As String
        '        Dim hnd_IMGPTH As String
        '        Dim hnd_CUSUSDCUR As String
        '        Dim hnd_CUSCADCUR As String
        '        Dim hnd_DV As String
        '        Dim hnd_TV As String
        '        Dim hnd_FTYAUD As String
        '        Dim hnd_BUYER As String
        '        Dim hnd_TOQTY As String
        '        Dim hnd_TOShipport As String
        '        Dim hnd_TORMK As String
        '        Dim hnd_FTYSHPSTR As String
        '        Dim hnd_FTYSHPEND As String
        '        Dim hnd_CUSHPSTR As String
        '        Dim hnd_CUSHPEND As String
        '        Dim hnd_CREUSR As String

        '        Dim i As Integer

        '        For i = 0 To rs_SHCBNDTL.Tables("RESULT").Rows.Count - 1
        '            DEL_FLAG = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("Del")
        '            hnd_COCDE = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cocde")
        '            hnd_QUTNO = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_qutno")
        '            hnd_shpseq = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_shpseq ")
        '            hnd_ITMNO = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_itmno")
        '            hnd_ITMSTS = Split(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_itmsts"), " - ")(0)
        '            hnd_ITMDSC = Replace(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_itmdsc"), "'", "''")
        '            '            hnd_ITMDSC = Replace(hnd_ITMDSC, """", "``")

        '            hnd_ALSITMNO = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_alsitmno")
        '            hnd_ALSCOLCDE = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_alscolcde")
        '            hnd_CONFTR = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_conftr")
        '            hnd_CONTOPC = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_contopc")
        '            hnd_PCPRC = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_pcprc")
        '            hnd_HSTREF = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_hstref")
        '            hnd_COLCDE = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_colcde")
        '            hnd_CUSCOL = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cuscol")
        '            hnd_COLDSC = Replace(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_coldsc"), "'", "''")
        '            hnd_PCKSEQ = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_pckseq")
        '            hnd_UNTCDE = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_untcde")
        '            hnd_INRQTY = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_inrqty")
        '            hnd_MTRQTY = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_mtrqty")
        '            hnd_CFT = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cft")
        '            hnd_CURCDE = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_curcde")
        '            hnd_CUS1SP = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cus1sp")
        '            hnd_CUS2SP = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cus2sp")
        '            hnd_CUS1DP = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cus1dp")
        '            hnd_CUS2DP = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cus2dp")
        '            hnd_ONETIM = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_onetim")
        '            hnd_DISCNT = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_discnt")
        '            hnd_MOFLAG = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_moflag")
        '            hnd_ORGMOQ = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_orgmoq")
        '            hnd_ORGMOA = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_orgmoa")
        '            hnd_MOQ = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_moq")
        '            hnd_MOA = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_moa")
        '            hnd_SMPQTY = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_smpqty")
        '            hnd_HRMCDE = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_hrmcde")
        '            hnd_DTYRAT = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_dtyrat")
        '            hnd_DEPT = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_dept")
        '            hnd_CUSUSD = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cususd")
        '            hnd_CUSCAD = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cuscad")
        '            If IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_venno")) Then
        '                hnd_VENNO = ""
        '            Else
        '                hnd_VENNO = Split(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_venno"), " - ")(0)
        '            End If
        '            hnd_SUBCDE = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_subcde")
        '            hnd_VENITM = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_venitm")
        '            hnd_FTYPRC = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_ftyprc")
        '            hnd_FTYCST = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_ftycst")
        '            hnd_NOTE = IIf(IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_note")), "", rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_note"))
        '            hnd_IMAGE = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_image")
        '            hnd_INRDIN = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_inrdin")
        '            hnd_INRWIN = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_inrwin")
        '            hnd_INRHIN = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_inrhin")
        '            hnd_MTRDIN = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_mtrdin")
        '            hnd_MTRWIN = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_mtrwin")
        '            hnd_MTRHIN = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_mtrhin")
        '            hnd_INRDCM = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_inrdcm")
        '            hnd_INRWCM = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_inrwcm")
        '            hnd_INRHCM = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_inrhcm")
        '            hnd_MTRDCM = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_mtrdcm")
        '            hnd_MTRWCM = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_mtrwcm")
        '            hnd_MTRHCM = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_mtrhcm")
        '            hnd_GRSWGT = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_grswgt")
        '            hnd_NETWGT = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_netwgt")
        '            hnd_COSMTH = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cosmth")
        '            hnd_SMPPRC = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_smpprc")
        '            hnd_CUSITM = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cusitm")
        '            CUS1NO = Microsoft.VisualBasic.Left(cboCus1No.Text, InStr(cboCus1No.Text, " - ") - 1)
        '            CUS1NA = Microsoft.VisualBasic.Right(cboCus1No.Text, Len(cboCus1No.Text) - InStr(cboCus1No.Text, " - ") - 2)
        '            CUS1NA = CUS1NA.Replace("'", "''")

        '            If cboCus2No.Text <> "" Then
        '                If InStr(cboCus2No.Text, " - ") - 1 >= 0 Then
        '                    CUS2NO = Microsoft.VisualBasic.Left(cboCus2No.Text, InStr(cboCus2No.Text, " - ") - 1)
        '                    CUS2NA = Replace(Microsoft.VisualBasic.Right(cboCus2No.Text, Len(cboCus2No.Text) - InStr(cboCus2No.Text, " - ") - 2), "'", "''")
        '                End If
        '            Else
        '                CUS2NO = ""
        '                CUS2NA = ""
        '            End If
        '            hnd_PRCSEC = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_prcsec")
        '            hnd_GRSMGN = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_grsmgn")
        '            hnd_BASPRC = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_basprc")
        '            hnd_TBM = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_tbm")
        '            hnd_TBMSTS = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_tbmsts")
        '            RVSDAT = Microsoft.VisualBasic.Left(txtRvsDat.Text, 10)
        '            hnd_APPRVE = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_apprve")
        '            'hnd_PDABPDIFF = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_pdabpdiff")
        '            hnd_PCKITR = IIf(IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_pckitr")), "", rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_pckitr"))
        '            hnd_PCKITR = Replace(hnd_PCKITR, "'", "''")

        '            hnd_STKQTY = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_stkqty")
        '            hnd_CUSQTY = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cusqty")
        '            hnd_SMPUNT = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_smpunt")
        '            hnd_QUTITMSTS = Split(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_qutitmsts"), " - ")(0)
        '            hnd_FCURCDE = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_fcurcde")
        '            'SMPPRD = "" 'rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("smpprd")
        '            hnd_ITMTYP = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_itmtyp")
        '            hnh_QUTSTS = IIf(IsDBNull(rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_qutsts")), "A", rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_qutsts"))
        '            hnd_PRCTRM = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_prctrm")
        '            hnd_CUSVEN = Split(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cusven"), " - ")(0)
        '            hnd_CUSSUB = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cussub")
        '            hnd_FTYPRCTRM = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_ftyprctrm")
        '            hnd_CUSSTYNO = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cusstyno")
        '            hnd_CBM = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cbm")
        '            hnd_UPC = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_upc")
        '            hnd_SPECPCK = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_specpck")
        '            hnd_FTYTMPITM = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_ftytmpitm")
        '            hnd_FTYTMPITMNO = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_ftytmpitmno")
        '            hnd_CUSTITMCAT = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_custitmcat")
        '            hnd_CUSTITMCATFML = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_custitmcatfml")
        '            hnd_CUSTITMCATAMT = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_custitmcatamt")
        '            hnd_PMU = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_pmu")
        '            hnd_IMRMK = IIf(IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_imrmk")), "", rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_imrmk"))
        '            hnd_IMRMK = hnd_IMRMK.Replace("'", "''")
        '            hnd_RNDSTS = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_rndsts")
        '            hnd_CALPMU = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_calpmu")
        '            hnd_MOQUNTTYP = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_moqunttyp")
        '            hnd_QUTDAT = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_qutdat")
        '            hnd_CUS1NO = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cus1no")
        '            hnd_CUS2NO = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cus2no")
        '            hnd_TRANTRM = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_trantrm")
        '            hnd_EFFDAT = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_effdat")
        '            hnd_EXPDAT = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_expdat")

        '            If Len(hnd_EXPDAT) <= 11 Then
        '                hnd_EXPDAT = hnd_EXPDAT & " 23:59:00.000"
        '            End If

        '            hnd_ITMNOTYP = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_itmnotyp")
        '            hnd_ITMNOREAL = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_itmnoreal")
        '            hnd_ITMNOTMP = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_itmnotmp")
        '            hnd_ITMNOVEN = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_itmnoven")

        '            '''III20140116
        '            If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_itmnovenno")) Then
        '                If InStr(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_itmnovenno"), " - ") > 1 Then


        '                    If Val(Split(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_itmnovenno"), " - ")(1)) > 1000 And _
        'Val(Split(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_itmnovenno"), " - ")(1)) < 9999 _
        'Then
        '                        hnd_ITMNOVENNO = Split(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_itmnovenno"), " - ")(1)
        '                    Else
        '                        hnd_ITMNOVENNO = Split(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_itmnovenno"), " - ")(0)
        '                    End If

        '                Else
        '                    hnd_ITMNOVENNO = ""
        '                End If
        '            End If



        '            hnd_IMGPTH = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_imgpth")
        '            hnd_CUSUSDCUR = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cususdcur")
        '            hnd_CUSCADCUR = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cuscadcur")
        '            hnd_DV = Split(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_dv"), " - ")(0)
        '            hnd_TV = Split(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_tv"), " - ")(0)
        '            hnd_FTYAUD = Split(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_ftyaud"), " - ")(0)
        '            hnd_BUYER = Split(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_buyer"), " - ")(0)
        '            hnd_TOQTY = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_toqty")
        '            hnd_TOShipport = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_TOShipport")

        '            hnd_TORMK = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_tormk")
        '            hnd_FTYSHPSTR = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_ftyshpstr")
        '            hnd_FTYSHPEND = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_ftyshpend")
        '            hnd_CUSHPSTR = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cushpstr")
        '            hnd_CUSHPEND = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_cushpend")
        '            hnd_CREUSR = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_creusr")

        '            gspStr = ""

        '            '''20130815  to avoid some missing insert,  just qpe  accrd to qud 
        '            ''If rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_creusr") = "~*NEW*~" Then
        '            ''    hnd_CREUSR = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_creusr")
        '            ''End If
        '            ''If rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_creusr") = "~*ADD*~" Then
        '            ''    hnd_CREUSR = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_creusr")
        '            ''End If



        '            If DEL_FLAG = "Y" Or hnd_CREUSR = "~*DEL*~" Then

        '                '''***)
        '                gspStr = "sp_physical_delete_SHIPGDTL '" & hnd_COCDE & "','" & hnd_QUTNO & "','" & hnd_shpseq & "'"
        '                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        '                If rtnLong <> RC_SUCCESS Then
        '                    MsgBox("Error on loading save_SHIPGDTL sp_physical_delete_SHIPGDTL:" & rtnStr)
        '                    save_SHIPGDTL = False
        '                    Exit Function
        '                End If

        '                '''20140321  set the To qty to zero
        '                ''update sp here
        '                gspStr = "sp_update_TOORDDTL_3 '" & hnd_COCDE & "','" & "T" & hnd_QUTNO & "','" & Val(flag_delete_to_seq(i)) & "',0,'" & gsUsrID & "'"
        '                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        '                If rtnLong <> RC_SUCCESS Then
        '                    MsgBox("Error on loading save_SHIPGDTL sp_physical_delete_SHIPGDTL:" & rtnStr)
        '                    save_SHIPGDTL = False
        '                    Exit Function
        '                End If

        '            ElseIf hnd_CREUSR = "~*ADD*~" Or hnd_CREUSR = "~*NEW*~" Then
        '                ''bug0802
        '                If hnd_ITMNO = "" Then
        '                    MsgBox("Please Input All Item Numbers!")
        '                    save_SHIPGDTL = False
        '                    Exit Function
        '                End If

        '                gspStr = "sp_insert_SHIPGDTL '" & hnd_COCDE & "','" & hnd_QUTNO & "','" & hnd_shpseq & "','" & hnd_ITMNO & "','" & hnd_ITMSTS & "','" & _
        '                                                    hnd_ITMDSC & "','" & hnd_ALSITMNO & "','" & hnd_ALSCOLCDE & "','" & hnd_CONFTR & "','" & hnd_CONTOPC & "','" & _
        '                                                    hnd_PCPRC & "','" & hnd_HSTREF & "','" & hnd_COLCDE & "','" & hnd_CUSCOL & "','" & hnd_COLDSC & "','" & _
        '                                                    hnd_PCKSEQ & "','" & hnd_UNTCDE & "','" & hnd_INRQTY & "','" & hnd_MTRQTY & "','" & hnd_CFT & "','" & _
        '                                                    hnd_CURCDE & "','" & hnd_CUS1SP & "','" & hnd_CUS2SP & "','" & hnd_CUS1DP & "','" & hnd_CUS2DP & "','" & _
        '                                                    hnd_ONETIM & "','" & hnd_DISCNT & "','" & hnd_MOFLAG & "','" & hnd_ORGMOQ & "','" & hnd_ORGMOA & "','" & _
        '                                                    hnd_MOQ & "','" & hnd_MOA & "','" & hnd_SMPQTY & "','" & hnd_HRMCDE & "','" & hnd_DTYRAT & "','" & _
        '                                                    hnd_DEPT & "','" & hnd_CUSUSD & "','" & hnd_CUSCAD & "','" & hnd_VENNO & "','" & hnd_SUBCDE & "','" & _
        '                                                    hnd_VENITM & "','" & hnd_FTYPRC & "','" & hnd_FTYCST & "','" & hnd_NOTE & "','" & hnd_IMAGE & "','" & _
        '                                                    hnd_INRDIN & "','" & hnd_INRWIN & "','" & hnd_INRHIN & "','" & hnd_MTRDIN & "','" & hnd_MTRWIN & "','" & _
        '                                                    hnd_MTRHIN & "','" & hnd_INRDCM & "','" & hnd_INRWCM & "','" & hnd_INRHCM & "','" & hnd_MTRDCM & "','" & _
        '                                                    hnd_MTRWCM & "','" & hnd_MTRHCM & "','" & hnd_GRSWGT & "','" & hnd_NETWGT & "','" & hnd_COSMTH & "','" & _
        '                                                    hnd_SMPPRC & "','" & hnd_CUSITM & "','" & CUS1NO & "','" & CUS1NA & "','" & CUS2NO & "','" & _
        '                                                    CUS2NA & "','" & hnd_PRCSEC & "','" & hnd_GRSMGN & "','" & hnd_BASPRC & "','" & hnd_TBM & "','" & _
        '                                                    hnd_TBMSTS & "','" & RVSDAT & "','" & hnd_APPRVE & "','" & hnd_PCKITR & "','" & _
        '                                                    hnd_STKQTY & "','" & hnd_CUSQTY & "','" & hnd_SMPUNT & "','" & hnd_QUTITMSTS & "','" & hnd_FCURCDE & "','" & _
        '                                                    hnd_ITMTYP & "','" & hnh_QUTSTS & "','" & hnd_PRCTRM & "','" & hnd_CUSVEN & "','" & _
        '                                                    hnd_CUSSUB & "','" & hnd_FTYPRCTRM & "','" & hnd_CUSSTYNO & "','" & hnd_CBM & "','" & hnd_UPC & "','" & _
        '                                                    hnd_SPECPCK & "','" & hnd_FTYTMPITM & "','" & hnd_FTYTMPITMNO & "','" & hnd_CUSTITMCAT & "','" & hnd_CUSTITMCATFML & "','" & _
        '                                                    hnd_CUSTITMCATAMT & "','" & hnd_PMU & "','" & hnd_IMRMK & "','" & hnd_RNDSTS & "','" & hnd_CALPMU & "','" & _
        '                                                    hnd_MOQUNTTYP & "','" & hnd_QUTDAT & "','" & hnd_CUS1NO & "','" & hnd_CUS2NO & "','" & hnd_TRANTRM & "','" & _
        '                                                    hnd_EFFDAT & "','" & hnd_EXPDAT & "','" & hnd_ITMNOTYP & "','" & hnd_ITMNOREAL & "','" & hnd_ITMNOTMP & "','" & _
        '                                                    hnd_ITMNOVEN & "','" & hnd_ITMNOVENNO & "','" & hnd_IMGPTH & "','" & hnd_CUSUSDCUR & "','" & hnd_CUSCADCUR & "','" & _
        '                                                    hnd_DV & "','" & hnd_TV & "','" & hnd_FTYAUD & "','" & hnd_BUYER & "','" & hnd_TOQTY & "','" & hnd_TORMK & "','" & _
        '                                                    hnd_FTYSHPSTR & "','" & hnd_FTYSHPEND & "','" & hnd_CUSHPSTR & "','" & hnd_CUSHPEND & "','" & hnd_TOShipport & "','" & gsUsrID & "'"
        '                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        '                If rtnLong <> RC_SUCCESS Then
        '                    MsgBox("Error on loading save_SHIPGDTL sp_insert_SHIPGDTL :" & rtnStr)
        '                    save_SHIPGDTL = False
        '                    Exit Function
        '                End If
        '            ElseIf hnd_CREUSR = "~*UPD*~" Then

        '                If hnd_ITMNO = "" Then
        '                    MsgBox("Item empty found,error on saving!")
        '                    save_SHIPGDTL = False
        '                    Exit Function
        '                End If

        '                gspStr = "sp_update_SHIPGDTL '" & hnd_COCDE & "','" & hnd_QUTNO & "','" & hnd_shpseq & "','" & hnd_ITMNO & "','" & hnd_ITMSTS & "','" & _
        '                                                    hnd_ITMDSC & "','" & hnd_ALSITMNO & "','" & hnd_ALSCOLCDE & "','" & hnd_CONFTR & "','" & hnd_CONTOPC & "','" & _
        '                                                    hnd_PCPRC & "','" & hnd_HSTREF & "','" & hnd_COLCDE & "','" & hnd_CUSCOL & "','" & hnd_COLDSC & "','" & _
        '                                                    hnd_PCKSEQ & "','" & hnd_UNTCDE & "','" & hnd_INRQTY & "','" & hnd_MTRQTY & "','" & hnd_CFT & "','" & _
        '                                                    hnd_CURCDE & "','" & hnd_CUS1SP & "','" & hnd_CUS2SP & "','" & hnd_CUS1DP & "','" & hnd_CUS2DP & "','" & _
        '                                                    hnd_ONETIM & "','" & hnd_DISCNT & "','" & hnd_MOFLAG & "','" & hnd_ORGMOQ & "','" & hnd_ORGMOA & "','" & _
        '                                                    hnd_MOQ & "','" & hnd_MOA & "','" & hnd_SMPQTY & "','" & hnd_HRMCDE & "','" & hnd_DTYRAT & "','" & _
        '                                                    hnd_DEPT & "','" & hnd_CUSUSD & "','" & hnd_CUSCAD & "','" & hnd_VENNO & "','" & hnd_SUBCDE & "','" & _
        '                                                    hnd_VENITM & "','" & hnd_FTYPRC & "','" & hnd_FTYCST & "','" & hnd_NOTE & "','" & hnd_IMAGE & "','" & _
        '                                                    hnd_INRDIN & "','" & hnd_INRWIN & "','" & hnd_INRHIN & "','" & hnd_MTRDIN & "','" & hnd_MTRWIN & "','" & _
        '                                                    hnd_MTRHIN & "','" & hnd_INRDCM & "','" & hnd_INRWCM & "','" & hnd_INRHCM & "','" & hnd_MTRDCM & "','" & _
        '                                                    hnd_MTRWCM & "','" & hnd_MTRHCM & "','" & hnd_GRSWGT & "','" & hnd_NETWGT & "','" & hnd_COSMTH & "','" & _
        '                                                    hnd_SMPPRC & "','" & hnd_CUSITM & "','" & CUS1NO & "','" & CUS1NA & "','" & CUS2NO & "','" & _
        '                                                    CUS2NA & "','" & hnd_PRCSEC & "','" & hnd_GRSMGN & "','" & hnd_BASPRC & "','" & hnd_TBM & "','" & _
        '                                                    hnd_TBMSTS & "','" & RVSDAT & "','" & hnd_APPRVE & "','" & hnd_PCKITR & "','" & _
        '                                                    hnd_STKQTY & "','" & hnd_CUSQTY & "','" & hnd_SMPUNT & "','" & hnd_QUTITMSTS & "','" & hnd_FCURCDE & "','" & _
        '                                                    hnd_ITMTYP & "','" & hnh_QUTSTS & "','" & hnd_PRCTRM & "','" & hnd_CUSVEN & "','" & _
        '                                                    hnd_CUSSUB & "','" & hnd_FTYPRCTRM & "','" & hnd_CUSSTYNO & "','" & hnd_CBM & "','" & hnd_UPC & "','" & _
        '                                                    hnd_SPECPCK & "','" & hnd_FTYTMPITM & "','" & hnd_FTYTMPITMNO & "','" & hnd_CUSTITMCAT & "','" & hnd_CUSTITMCATFML & "','" & _
        '                                                    hnd_CUSTITMCATAMT & "','" & hnd_PMU & "','" & hnd_IMRMK & "','" & hnd_RNDSTS & "','" & hnd_CALPMU & "','" & _
        '                                                    hnd_MOQUNTTYP & "','" & hnd_QUTDAT & "','" & hnd_CUS1NO & "','" & hnd_CUS2NO & "','" & hnd_TRANTRM & "','" & _
        '                                                    hnd_EFFDAT & "','" & hnd_EXPDAT & "','" & hnd_ITMNOTYP & "','" & hnd_ITMNOREAL & "','" & hnd_ITMNOTMP & "','" & _
        '                                                    hnd_ITMNOVEN & "','" & hnd_ITMNOVENNO & "','" & hnd_IMGPTH & "','" & hnd_CUSUSDCUR & "','" & hnd_CUSCADCUR & "','" & _
        '                                                    hnd_DV & "','" & hnd_TV & "','" & hnd_FTYAUD & "','" & hnd_BUYER & "','" & hnd_TOQTY & "','" & hnd_TORMK & "','" & _
        '                                                    hnd_FTYSHPSTR & "','" & hnd_FTYSHPEND & "','" & hnd_CUSHPSTR & "','" & hnd_CUSHPEND & "','" & hnd_TOShipport & "','" & gsUsrID & "'"

        '                'MsgBox(i)

        '                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        '                If rtnLong <> RC_SUCCESS Then
        '                    MsgBox("Error on loading save_SHIPGDTL sp_update_SHIPGDTL :" & rtnStr)
        '                    save_SHIPGDTL = False
        '                    Exit Function
        '                End If
        '            End If
        '            gi_saved_items_count = gi_saved_items_count + 1

        '        Next i

        '        If gi_saved_items_count = 0 Then
        '            MsgBox("No item saved! Please Check the Shipping and the item(s)!")
        '            save_SHIPGDTL = False
        '            Exit Function
        '        End If

        save_SHIPGDTL = True

    End Function

    '    Private Sub cmdAddClick()
    '        Add_flag = True
    '        txtNoteNo.Text = ""
    '        Dim rs As New DataSet

    '        sMode = cModeAdd
    '        If sMode = cModeAdd Then
    '            gsCompany = Trim(cboCoCde.Text)
    '            Call Update_gs_Value(gsCompany)

    '            gspStr = "sp_select_DOC_GEN '" & cboCoCde.Text & "','SH','" & gsUsrID & "'"
    '            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

    '            If rtnLong <> RC_SUCCESS Then
    '                MsgBox("Error on loading cmdSaveClick sp_select_DOC_GEN :" & rtnStr)
    '                Exit Sub
    '            End If

    '            shpno = rs.Tables("RESULT").Rows(0)(0).ToString
    '            txtNoteNo.Text = shpno
    '            'update all transaction with Shipping Number
    '        End If

    '        'Call fillParameter()

    '        Call setStatus(cModeAdd)
    '        sMode = cModeAdd

    '        'gspStr = "sp_select_CUBASINF_PRI '" & cboCoCde.Text & "','" & gsUsrID & "','" & "QU" & "'"
    '        ''Fixing global company code problem at 20100420
    '        'gsCompany = Trim(cboCoCde.Text)
    '        'Update_gs_Value(gsCompany)

    '        'Me.Cursor = Windows.Forms.Cursors.WaitCursor
    '        'rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
    '        'gspStr = ""
    '        'Me.Cursor = Windows.Forms.Cursors.Default

    '        'If rtnLong <> RC_SUCCESS Then  '*** An error has occured
    '        '    MsgBox("Error on loading QUM00001  sp_select_CUBASINF_PRI : " & rtnStr)
    '        '    Exit Sub
    '        'Else
    '        '    rs_CUBASINF_P = rs.Copy() '*** Cus for company
    '        'End If
    '        ''        Call fillcboPriCust() '

    '        'If cboCus1No.Enabled And cboCus1No.Visible Then cboCus1No.Focus()
    '        'cmdGenSmp.Enabled = False
    '        'cmdGenTent.Enabled = False

    '        gsCompany = Trim(cboCoCde.Text)
    '        Call Update_gs_Value(gsCompany)

    '        gspStr = "sp_select_SHIPGHDR '',''"
    '        rtnLong = execute_SQLStatement(gspStr, rs_SHCBNHDR, rtnStr)

    '        If rtnLong <> RC_SUCCESS Then
    '            MsgBox("Error on loading cmdAddClick sp_select_SHIPGHDR :" & rtnStr)
    '            Exit Sub
    '        End If

    '        For i As Integer = 0 To rs_SHCBNHDR.Tables("RESULT").Columns.Count - 1
    '            rs_SHCBNHDR.Tables("RESULT").Columns(i).ReadOnly = False
    '        Next i



    '        'Call insert_SHIPGHDR()
    '    End Sub



    Private Sub setStatus(ByVal Mode As String)
        If Mode = cModeInit Then
            btcSHM00002.SelectedIndex = 0
            btcSHM00002.Enabled = False

            Add_flag = False
            mmdAdd.Enabled = Enq_right_local 'True
            mmdAdd.Enabled = True

            mmdSave.Enabled = False
            cboCoCde.Enabled = True

            ''''''20130826   cmdReset.Enabled = True
            '*** Phase 2

            mmdDelete.Enabled = False
            mmdCopy.Enabled = Enq_right_local
            mmdFind.Enabled = True
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdExit.Enabled = True
            mmdClear.Enabled = True
            mmdSearch.Enabled = True
            mmdExit.Enabled = True
            mmdClear.Enabled = True
            mmdSearch.Enabled = True

            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False

            'CmdSpecial.Enabled = True
            'cmdbrowlist.Enabled = True

            Call SetStatusBar(Mode)

            readingindex = 0
            PreviousTab = 0

            'btcSHM00002.SelectedIndex = 0
            txtNoteNo.Enabled = True
            'Recordstatus = False
            'Call ShowFooterBar(False)
            ClearScreen()

            btcSHM00002.TabPages(0).Enabled = True
            btcSHM00002.TabPages(1).Enabled = False
            '''''''''''''''''''''''''   StatusBar.Panels(2).Text = Format(Date.Today, "mm/dd/yyyy").ToString & " " & Format(Date.Today, "mm/dd/yyyy").ToString & _
            '''''''''''''''''''''''              " " & gsUsrID


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ElseIf Mode = cModeAdd Then

            Dim rs_Add As DataSet

            Dim gspStr

            'Lester Wu 2005-05-02, update company code
            gsCompany = Trim(Me.cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_SHCBNHDR '" & "" & "','" & "" & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SHCBNHDR, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading txtNoteNoKeyPress sp_select_SHIPGHDR :" & rtnStr)
                Exit Sub
            End If
            For i As Integer = 0 To rs_SHCBNHDR.Tables("RESULT").Columns.Count - 1
                rs_SHCBNHDR.Tables("RESULT").Columns(i).ReadOnly = False
            Next i



            gspStr = "sp_list_SHCBNDTL '" & "" & "','" & "" & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SHCBNDTL, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading txtNoteNoKeyPress sp_select_SHIPGHDR :" & rtnStr)
                Exit Sub
            End If
            For i As Integer = 0 To rs_SHCBNDTL.Tables("RESULT").Columns.Count - 1
                rs_SHCBNDTL.Tables("RESULT").Columns(i).ReadOnly = False
            Next i


            Cursor = Cursors.WaitCursor

            MaxSeq = 0


            Call SetStatusBar(Mode)

            txtNoteNo.Text = ""

            txtNoteNo.Enabled = False
            ' txtNoteNo.BackColor = &H80000004

            mmdSave.Enabled = True
            mmdDelete.Enabled = False
            mmdInsRow.Enabled = True
            mmdDelRow.Enabled = True
            mmdAdd.Enabled = False
            mmdFind.Enabled = False

            btcSHM00002.Enabled = True

            txtRefNo.Enabled = True

            optCredit.Enabled = True
            'optDebit.Enabled = True
            optItm.Enabled = False
            optMsc.Enabled = False

            ClearScreen()


        ElseIf Mode = cModeUpd Then


            btcSHM00002.TabPages(0).Enabled = True
            btcSHM00002.TabPages(1).Enabled = True
            mmdSave.Enabled = True

            mmdAdd.Enabled = False
            btcSHM00002.Enabled = True
            optItm.Enabled = False
            optMsc.Enabled = False
            mmdSave.Enabled = True
            mmdFind.Enabled = False
            txtRefNo.Enabled = False
            mmdInsRow.Enabled = True
            mmdDelRow.Enabled = True

            txtItmNo.Enabled = False
            txtColCde.Enabled = False
            cboPckInf.Enabled = False
            Call SetStatusBar(Mode)

        ElseIf Mode = cModeSave Then

            Call setStatus("Init")
            'Msg ("M00025")
            MsgBox("Record Saved")
            txtNoteNo.Focus()

        ElseIf Mode = cModeDel Then
        ElseIf Mode = cModeClear Then
            Call setStatus(cModeInit)
        ElseIf Mode = cModeRead Then
        End If
    End Sub


    '    Private Sub fill_SHIPGHDR()

    '        If rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If

    '        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
    '            rs_SHCBNHDR.Tables("RESULT").Rows.Add()
    '            rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") = "~*ADD*~"
    '        End If

    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cocde") = cboCoCde.Text.Trim
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_shpno") = txtNoteNo.Text.Trim
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_issdat") = txtIssDat.Text.Trim
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_rvsdat") = txtRvsDat.Text.Trim
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus1no") = Split(cboCus1No.Text.Trim, " - ")(0)
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cus2no") = Split(cboCus2No.Text.Trim, " - ")(0)
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_smpshp") = IIf(chkSample.Checked = True, "Y", "N")
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_shpsts") = Split(cboCDStatus.Text.Trim, " - ")(0)
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ves") = txtPrmCus.Text.Trim
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_voy") = txtSecCus.Text.Trim

    '        If IsDate(txtRefNo.Text.Trim) Then
    '            rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_slnonb") = txtRefNo.Text.Trim
    '        Else
    '            rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_slnonb") = "01/01/1900"
    '        End If

    '        If IsDate(txtArrDat.Text.Trim) Then
    '            rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_arrdat") = txtArrDat.Text.Trim
    '        Else
    '            rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_arrdat") = "01/01/1900"
    '        End If

    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_potloa") = txtPotLoa.Text.Trim
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_dst") = txtDst.Text.Trim
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_crr") = txtCrr.Text.Trim
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_crrso") = txtCrrSo.Text.Trim
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_goddsc") = txtGodDsc.Text.Trim
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_bilent") = txtBilEnt.Text.Trim
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_biladr") = txtRmk.Text.Trim
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_bilstt") = txtTtlUnt.Text.Trim
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_bilcty") = Split(cboBilCty.Text.Trim, " - ")(0)
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_bilzip") = txtBilZip.Text.Trim
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_bilrmk") = txtBilRmk.Text.Trim

    '        If IsNumeric(txtTtlCtn.Text.Trim) Then
    '            rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ttlctn") = txtTtlCtn.Text.Trim
    '        Else
    '            rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ttlctn") = 0
    '        End If


    '        If IsNumeric(txtTtlNwg.Text.Trim) Then
    '            rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ttlnwg") = txtTtlNwg.Text.Trim
    '        Else
    '            rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ttlnwg") = 0
    '        End If

    '        If IsNumeric(txtTtlGwg.Text.Trim) Then
    '            rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ttlgwg") = txtTtlGwg.Text.Trim
    '        Else
    '            rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ttlgwg") = 0
    '        End If

    '        If IsNumeric(cboUntAmt.Text.Trim) Then
    '            rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_untamt") = cboUntAmt.Text.Trim
    '        Else
    '            rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_untamt") = 0
    '        End If

    '        If IsNumeric(txtTtlAmt.Text.Trim) Then
    '            rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ttlamt") = txtTtlAmt.Text.Trim
    '        Else
    '            rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ttlamt") = 0
    '        End If

    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_lcno") = txtLCNo.Text.Trim
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_lcbank") = txtLcBank.Text.Trim
    '        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_cntyorgn") = txtCntyOrgn.Text.Trim

    '        If Add_flag = True Then
    '            rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_updusr") = gsUsrID
    '            rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") = gsUsrID
    '        End If

    '    End Sub

    Public Sub fill_SHCBNDTL()

        ''*** Check Combo in list or not ?
        'If not_in_Combo_HDR() = True Then
        '    Exit Sub
        'End If
        If rs_SHCBNDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        If Not rs_SHCBNDTL.Tables("RESULT").Rows.Count > 0 Then
            Exit Sub
        End If

        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_cocde") = cboCoCde.Text.Trim
        'rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Tables("RESULT").Rows(ReadingIndex)("hnd_shpno") = txtNoteNo.Text.Trim
        'rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Tables("RESULT").Rows(ReadingIndex)("hnd_shpseq") = IIf(IsNumeric(txtShpSeq.Text.Trim), txtShpSeq.Text.Trim, 0)



        If optItm.Checked = True Then

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_lnetyp") = "I"

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_itmno") = txtItmNo.Text

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_itmdsc") = txtItmDsc.Text

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_colcde") = txtColCde.Text

            If Trim(cboPckInf.Text) <> "" Then

                rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_pckunt") = Split(cboPckInf.Text, "/")(0)
                rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_inrctn") = Split(cboPckInf.Text, "/")(1)
                rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_mtrctn") = Split(cboPckInf.Text, "/")(2)
                rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_cft") = IIf(Trim(Split(cboPckInf.Text, "/")(3)) = "", 0, Trim(Split(cboPckInf.Text, "/")(3)))

            Else

                rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_pckunt") = ""
                rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_inrctn") = ""
                rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_mtrctn") = ""
                rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_cft") = 0

            End If

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_coldsc") = txtColDsc.Text
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_cusitm") = txtCusItm.Text
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_cussku") = txtCusSku.Text
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_mannam") = txtManNam.Text
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_manadr") = txtManAdr.Text

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_curcde") = txtCurCde4.Text
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_curcde") = txtCurCde5.Text


        Else

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_lnetyp") = "M"

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_itmno") = ""

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_itmdsc") = ""

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_colcde") = ""

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_pckunt") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_inrctn") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_mtrctn") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_cft") = 0

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_coldsc") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_cusitm") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_cussku") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_mannam") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_manadr") = ""

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_curcde") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_curcde") = ""

        End If

        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_adjprc") = IIf((IsNumeric(txtAdjPrc.Text) And txtAdjPrc.Text <> ""), txtAdjPrc.Text, 0)

        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_adjqty") = IIf((IsNumeric(txtAdjQty.Text) And txtAdjQty.Text <> ""), CInt(txtAdjQty.Text), 0)


        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_rmk") = txtDRmk.Text


        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_shpqty") = txtShpQty.Text
        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_untsel") = txtCurCde2.Text

        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_untamt") = txtCurCde3.Text

        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_selprc") = txtSelPrc.Text
        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_ttlamt") = txtShpAmt.Text
        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_ordno") = cboSCNo.Text

        'Lester Wu 2004/08/26
        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_purord") = txtPO.Text
        '----------------------------------------------
        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("sod_ordqty") = ordqty.Text
        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("sod_shpqty") = shpqty.Text


        If chkUpd.Checked = True Then
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_upd") = "Y"
        Else
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_upd") = "N"
        End If

        If Trim(txtInvLne.Text) <> "" Then
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_invlne") = txtInvLne.Text
        End If

        'rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Update()

    End Sub

    '    Private Sub txtCntyOrgn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    End Sub
    '    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click

    '        'flag_cmdInsRow_Click = True

    '        If check_insert_SHIPGDTL() = True Then
    '            Dim newshpseq As Integer

    '            ''20140320 fill befor new
    '            Call fill_SHIPGDTL()

    '            newshpseq = insert_SHIPGDTL(True)

    '            no_Display_Detail = False

    '            Call display_Detail(newshpseq)
    '            Call reset_detail_control("Detail_Init")

    '            ''            Call reset_detail_data("Detail_Init", "All")
    '        Else
    '            Exit Sub
    '        End If


    '        'Exit Sub


    '        Insert_flag = True
    '        btcSHM00002.SelectedIndex = 1

    '        '*** Check Combo in list or not ?
    '        If not_in_Combo_HDR() = True Then
    '            Exit Sub
    '        End If

    '        If not_in_Combo_DTL() = True Then
    '            Exit Sub
    '        End If

    '        Call fill_SHIPGDTL()

    '        no_Display_Detail = True

    '        'dgOthDtl.DataSource = rs_SHCBNDTL.Tables("RESULT").DefaultView
    '        'rs_SHCBNDTL.Tables("RESULT").DefaultView.Sort() = "hnd_shpseq"
    '        'no_Display_Detail = False
    '        'txtSeq.Text = rs_SHCBNDTL.Tables("RESULT").Rows(rs_SHCBNDTL.Tables("RESULT").Rows.Count - 1)("hnd_shpseq") + 1

    '        'Call reverse_Detail()

    '        ''??
    '        no_Display_Detail = True
    '        drNewRow = rs_SHCBNDTL.Tables("RESULT").NewRow
    '        no_Display_Detail = False
    '        drNewRow("mode") = "NEW"
    '        drNewRow("hnd_shpseq") = rs_SHCBNDTL.Tables("RESULT").Rows.Count
    '        drNewRow("hnd_apprve") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows.Add(drNewRow)

    '        ReadingIndex = rs_SHCBNDTL.Tables("RESULT").Rows.Count - 1


    '        If rs_SHCBNDTL.Tables("RESULT").Rows.Count > 1 Then
    '            CmdDtlPre.Enabled = True
    '            CmdDtlNext.Enabled = False
    '        ElseIf rs_SHCBNDTL.Tables("RESULT").Rows.Count = 1 Then
    '            CmdDtlPre.Enabled = False
    '            CmdDtlNext.Enabled = False
    '        ElseIf ReadingIndex = rs_SHCBNDTL.Tables("RESULT").Rows.Count - 1 Then
    '            CmdDtlPre.Enabled = True
    '            CmdDtlNext.Enabled = False
    '        End If

    '        Call reset_detail_control("Detail_Init")


    '    End Sub

    '    Private Function check_insert_SHIPGDTL() As Boolean
    '        check_insert_SHIPGDTL = False

    '        If btcSHM00002.SelectedIndex = 1 Then 'Or btcSHM00002.SelectedIndex = 2 Then

    '            If rs_SHCBNDTL.Tables("RESULT").Rows.Count = 0 Then
    '                MsgBox("Shipping in initial mode, please check")
    '                check_insert_SHIPGDTL = False
    '                Exit Function
    '            Else


    '                If check_insert_SHIPGDTL = False Then
    '                    Call insert_SHIPGDTL(False)
    '                    Call display_Detail(txtShpSeq.Text)

    '                    Call reset_detail_control("Detail_Init")

    '                    btcSHM00002.SelectedIndex = 1
    '                    check_insert_SHIPGDTL = True
    '                    Exit Function
    '                End If
    '            End If
    '        Else
    '            MsgBox("Please insert row in Details Page!")
    '            check_insert_SHIPGDTL = False
    '        End If
    '        '''

    '        'If rs_SHCBNDTL.Tables("RESULT") Is Nothing Then
    '        '    Call insert_SHIPGDTL(True)
    '        'End If
    '        Call display_Detail(Val(txtShpSeq.Text))

    '        '        Call reset_detail_control("Detail_Init")


    '        check_insert_SHIPGDTL = True

    '    End Function



    '    Private Function insert_SHIPGDTL(ByVal addnew As Boolean) As Integer
    '        Dim shpseq As Integer
    '        Dim loc As Integer


    '        If rs_SHCBNDTL.Tables("RESULT") Is Nothing Then
    '            ''
    '            gspStr = "sp_select_SHIPGDTL_rs '',''"
    '            rtnLong = execute_SQLStatement(gspStr, rs_SHCBNDTL, rtnStr)

    '            If rtnLong <> RC_SUCCESS Then
    '                MsgBox("Error on loading cmdAddClick sp_select_SHIPGDTL :" & rtnStr)
    '                Exit Function
    '            End If

    '            For i As Integer = 0 To rs_SHCBNDTL.Tables("RESULT").Columns.Count - 1
    '                rs_SHCBNDTL.Tables("RESULT").Columns(i).ReadOnly = False
    '            Next i

    '        End If



    '        shpseq = 0

    '        If addnew = True Then
    '            Dim i As Integer
    '            For i = 0 To rs_SHCBNDTL.Tables("RESULT").Rows.Count - 1
    '                If rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_shpseq") > shpseq Then
    '                    shpseq = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_shpseq")
    '                End If
    '            Next i
    '            shpseq = shpseq + 1

    '            insert_SHIPGDTL = shpseq

    '            rs_SHCBNDTL.Tables("RESULT").Rows.Add()

    '            loc = rs_SHCBNDTL.Tables("RESULT").Rows.Count - 1
    '        Else
    '            ''should be the cur one, instead of last item
    '            shpseq = rs_SHCBNDTL.Tables("RESULT").Rows(loc).Item("hnd_shpseq")
    '            loc = loc
    '            ''shpseq = rs_SHCBNDTL.Tables("RESULT").Rows(rs_SHCBNDTL.Tables("RESULT").Rows.Count - 1).Item("hnd_shpseq")
    '        End If


    '        ''loc = loc
    '        ''loc = rs_SHCBNDTL.Tables("RESULT").Rows.Count - 1


    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc).Item("Del") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc).Item("mode") = "NEW"

    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_cocde") = cboCoCde.Text.Trim
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_shpno") = txtNoteNo.Text.Trim
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_shpseq") = shpseq


    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_ctrcfs") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_sealno") = ""

    '        ''replace ' when save
    '        If optCtrSiz0.Checked = True Then
    '            rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_ctrsiz") = ""
    '        ElseIf optCtrSiz1.Checked = True Then
    '            rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_ctrsiz") = ""
    '        ElseIf optCtrSiz2.Checked = True Then
    '            rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_ctrsiz") = ""
    '        ElseIf optCtrSiz3.Checked = True Then
    '            rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_ctrsiz") = ""
    '        ElseIf optCtrSiz4.Checked = True Then
    '            rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_ctrsiz") = ""
    '        Else
    '        End If
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_ctrsiz") = ""

    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_pckrmk") = ""

    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_ctrsiz") = ""

    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_jobno") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_ordno") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_ordseq") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_cuspo") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_cusitm") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_itmno") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_itmtyp") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_itmdsc") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_colcde") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_cuscol") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_coldsc") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_shpqty") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_untcde") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_ctnstr") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_ctnend") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_inrctn") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_mtrctn") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_vol") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_mtrdcm") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_mtrwcm") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_mtrhcm") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_actvol") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_grswgt") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_netwgt") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_itmshm") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_cmprmk") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_mannam") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_manadr") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_ttlvol") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_ttlnet") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_ttlgrs") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_ttlctn") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_untsel") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_selprc") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_untamt") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_ttlamt") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_invno") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_prctrm") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_paytrm") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_purord") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_purseq") = 0
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_venno") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_cusven") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_cusstyno") = ""
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_updusr") = gsUsrID
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc).Item("hnd_credat") = "01/01/1900"
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc).Item("hnd_upddat") = "01/01/1900"
    '        rs_SHCBNDTL.Tables("RESULT").Rows(loc)("hnd_creusr") = "~*ADD*~"


    '    End Function


    Public Sub display_Detail(ByVal shpseq As Integer)

        readingindex = 0

        Dim i As Integer

        '''bug20130729
        If rs_SHCBNDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        If rs_SHCBNDTL.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        For i = 0 To rs_SHCBNDTL.Tables("RESULT").Rows.Count - 1
            ''bug
            If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_seq")) Then

                If shpseq = rs_SHCBNDTL.Tables("RESULT").Rows(i).Item("hnd_seq") Then
                    readingindex = i
                End If
            End If

        Next i




        no_Display_Detail = False

        If no_Display_Detail = False Then
            If rs_SHCBNDTL.Tables("RESULT").Rows.Count > 0 Then
                If readingindex >= 0 And readingindex <= rs_SHCBNDTL.Tables("RESULT").Rows.Count - 1 And rs_SHCBNDTL.Tables("RESULT").Rows(readingindex).RowState <> "8" Then
                    ''bug
                    'If IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_itmno")) Then
                    '    'MsgBox("No record!")
                    '    Exit Sub
                    'End If


                    '  txtSeq.Text = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_seq")

                    cboCoCde.Text = rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_cocde")
                    '                    txtShpNo.Text = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_shpno")

                    txtSeq.Text = Val(rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_seq"))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '*******Kenny Add on 09-10-2002
                    cboPckInf.Items.Clear()

                    If rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_creusr") = "~*ADD*~" Or rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_creusr") = "~*NEW*~" Then
                        cboPckInf.Items.Add(rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_pckunt") & "/" & rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_inrctn") & "/" & rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_mtrctn") & "/" & rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_cft"))
                    Else
                        cboPckInf.Items.Add(rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_untcde") & "/" & rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_inrctn") & "/" & rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_mtrctn") & "/" & rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_vol"))
                    End If


                    cboPckInf.SelectedIndex = 0

                    cboSCNo.Items.Clear()

                    'Lester Wu 2004/08/26
                    txtPO.Text = rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_purord")
                    '-------------------------------------

                    If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_ordno")) Then
                        cboSCNo.Items.Add(rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_ordno"))
                        txtSCNo.Text = rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_ordno")
                        cboSCNo.Text = rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_ordno")
                    End If

                    txtSeq.Text = rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_seq")
                    If rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_lnetyp") = "I" Then
                        optItm.Checked = True
                        optMsc.Checked = False
                    Else
                        optItm.Checked = False
                        optMsc.Checked = True
                    End If

                    If optItm.Checked = True And (rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_creusr") = "~*ADD*~" Or rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_creusr") = "~*NEW*~") Then
                        txtItmNo.Enabled = True
                        txtColCde.Enabled = True
                        ' add for disable update
                        txtAdjQty.Enabled = True
                        txtAdjPrc.Enabled = True
                        txtDRmk.Enabled = True
                        optItm.Enabled = True
                        optMsc.Enabled = True
                        '''''''''
                    Else
                        txtItmNo.Enabled = False
                        txtColCde.Enabled = False
                        cboPckInf.Enabled = False
                        cboSCNo.Enabled = False
                        ' add for disable update
                        txtAdjQty.Enabled = False
                        txtAdjPrc.Enabled = False
                        txtDRmk.Enabled = False
                        optItm.Enabled = False
                        optMsc.Enabled = False
                        '''''''''
                    End If

                    txtItmNo.Text = rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_itmno")
                    txtItmDsc.Text = rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_itmdsc")
                    txtColCde.Text = rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_colcde")



                    txtColDsc.Text = rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_coldsc")
                    txtCusItm.Text = rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_cusitm")
                    txtCusSku.Text = rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_cussku")
                    txtManNam.Text = rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_mannam")
                    txtManAdr.Text = rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_manadr")

                    '    txtUM.Text = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_pckunt")
                    '    txtInr.Text = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_inrctn")
                    '    txtMtr.Text = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_mtrctn")
                    '    txtCBM.Text = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_cft")

                    If optItm.Checked = True Then

                        txtShpQty.Text = 0
                        For index9 As Integer = 0 To rs_SHCBNDTL.Tables("result").Rows.Count - 1
                            If UCase(rs_SHCBNDTL.Tables("result").Rows(index9)("hid_itmno").ToString.Trim) = UCase(txtItmNo.Text.Trim) Then
                                txtShpQty.Text = CInt(txtShpQty.Text) + IIf(IsDBNull(rs_SHCBNDTL.Tables("result").Rows(index9)("hid_shpqty")), 0, rs_SHCBNDTL.Tables("result").Rows(index9)("hid_shpqty"))
                            End If
                        Next
                        '20150720
                        '                        txtShpQty.Text = IIf(IsDBNull(rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_sumshpqty")), 0, rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_sumshpqty"))
                        'Ad By Lewis For Debug on 26/03/2003******

                        txtCurCde2.Text = IIf(IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_untsel")), "", rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_untsel"))
                        txtCurCde3.Text = IIf(IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_untamt")), "", rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_untamt"))

                        txtSelPrc.Text = IIf(IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_selprc")), 0, rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_selprc"))
                        txtShpAmt.Text = IIf(IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_ttlamt")), 0, rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_ttlamt"))

                    End If



                    txtCurCde4.Text = rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_curcde")
                    txtCurCde5.Text = rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_curcde")

                    txtAdjQty.Text = rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_adjqty")
                    txtAdjPrc.Text = rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_adjprc")
                    txtAdjAmt.Text = txtAdjQty.Text * txtAdjPrc.Text



                    ordqty.Text = IIf(IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("sod_ordqty")), "0", rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("sod_ordqty"))
                    shpqty.Text = IIf(IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("sod_shpqty")), "0", rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("sod_shpqty"))

                    If rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_upd") = "Y" Then
                        chkUpd.Checked = True
                    Else
                        chkUpd.Checked = False
                    End If

                    txtDRmk.Text = rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_rmk")

                    If rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_creusr") = "~*DEL*~" Or rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_creusr") = "~*NEW*~" Then
                        chkDel.Checked = True
                    Else
                        chkDel.Checked = False
                    End If

                    txtInvLne.Text = rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_invlne")
                    ''
                    'If Not rs_invoutqty Is Nothing Then
                    '    rs_invoutqty.tables("result").defaultview.tables("result").defaultview.rowFilter = "hnd_ordno ='" & txtSCNo.Text & "' and hnd_invlne = '" & txtInvLne.Text & "'"
                    '    If rs_invoutqty.tables("result").defaultview.tables("result").rows.count > 0 Then
                    '        txtout.Text = IIf(IsDBNull(rs_invoutqty.Tables("result").DefaultView(0)("outqty")), 0, rs_invoutqty.Tables("result").DefaultView(0)("outqty"))
                    '        txtdeb.Text = IIf(IsDBNull(rs_invoutqty.Tables("result").DefaultView(0)("debqty")), 0, rs_invoutqty.Tables("result").DefaultView(0)("debqty"))
                    '        txtcre.Text = IIf(IsDBNull(rs_invoutqty.Tables("result").DefaultView(0)("creqty")), 0, rs_invoutqty.Tables("result").DefaultView(0)("creqty"))
                    '    Else
                    '        txtout.Text = "0"
                    '        txtdeb.Text = "0"
                    '        txtcre.Text = "0"
                    '    End If
                End If
                ' Enable Delete Check Box ***** by Lewis on 25/03/2003
                chkDel.Enabled = True




            End If

        End If

        If readingindex = rs_SHCBNDTL.Tables("result").Rows.Count - 1 Then
            CmdDtlNext.Enabled = False
        Else
            CmdDtlNext.Enabled = True
        End If


    End Sub

    '    Private Sub reset_detail_control(ByVal action As String)
    '        Select Case action
    '            Case "Detail_Init", "Detail_Read"
    '                txtCtrCfs.Text = ""
    '                txtSealNo.Text = ""
    '                optCtrSiz0.Checked = True
    '                cboPckRmk.Text = ""
    '                txtJobNo.Text = ""
    '                txtOrdNo.Text = ""
    '                txtOrdSeq.Text = ""
    '                txtCusPo.Text = ""
    '                txtCusItm.Text = ""
    '                cboItmNo.Text = ""
    '                txtItmTyp.Text = ""
    '                txtItmDsc.Text = ""
    '                txtColCde.Text = ""
    '                txtCusCol.Text = ""
    '                txtColDsc.Text = ""
    '                txtShpQty.Text = ""
    '                txtUntCde.Text = ""
    '                txtInrCtn.Text = ""
    '                txtCtnEnd.Text = ""
    '                txtCtnStr.Text = ""
    '                txtMtrCtn.Text = ""
    '                txtVol.Text = ""
    '                txtMtrdcm.Text = ""
    '                txtMtrwcm.Text = ""
    '                txtMtrhcm.Text = ""
    '                txtActVol.Text = ""
    '                txtGrsWgt.Text = ""
    '                txtNetWgt.Text = ""
    '                txtItmShm.Text = ""
    '                txtCmpRmk.Text = ""
    '                txtManNam.Text = ""
    '                txtManAdr.Text = ""
    '                txtTtlVolD.Text = ""
    '                txtTtlNetD.Text = ""
    '                txtTtlGrsD.Text = ""
    '                txtTtlCtnD.Text = ""
    '                cboUntSelD.Text = ""
    '                txtSelPrcD.Text = ""
    '                cboUntAmtD.Text = ""
    '                txtTtlAmtD.Text = ""
    '                txtInvNo.Text = ""
    '                cboPrcTrm.Text = ""
    '                cboPayTrm.Text = ""
    '                txtPurOrd.Text = ""
    '                txtPurSeq.Text = ""
    '                txtVenNo.Text = ""
    '                txtCusVen.Text = ""
    '                txtCusStyNo.Text = ""




    '            Case "Detail_Update", "Detail_Update_Info"

    '        End Select
    '    End Sub

    '    Private Function not_in_Combo_DTL() As Boolean
    '        Dim i As Integer
    '        Dim Y As Integer
    '        Dim inCombo As Boolean
    '        not_in_Combo_DTL = True

    '    End Function

    '    Private Function not_in_Combo_HDR() As Boolean
    '        Dim i As Integer
    '        Dim Y As Integer
    '        Dim inCombo As Boolean

    '        '*** Primary Customer
    '        If cboCus1No.Text <> "" And cboCus1No.Enabled = True And cboCus1No.Items.Count > 0 Then
    '            inCombo = False
    '            i = cboCus1No.Items.Count
    '            For Y = 0 To i - 1
    '                If Trim(cboCus1No.Text) = Trim(cboCus1No.Items(Y)) Then
    '                    inCombo = True
    '                End If
    '            Next

    '            If inCombo = False Then
    '                MsgBox("Primary Customer - Data is Invalid, please select in Drop Down List.")
    '                btcSHM00002.SelectedIndex = 0
    '                cboCus1No.Enabled = True
    '                If cboCus1No.Enabled And cboCus1No.Visible Then cboCus1No.Focus()
    '                not_in_Combo_HDR = True
    '                Exit Function
    '            End If
    '        End If

    '        '*** Secondary Customer
    '        If cboCus2No.Text <> "" And cboCus2No.Enabled = True And cboCus2No.Items.Count > 0 Then
    '            inCombo = False
    '            i = cboCus2No.Items.Count
    '            For Y = 0 To i - 1
    '                If Trim(cboCus2No.Text) = Trim(cboCus2No.Items(Y)) Then
    '                    inCombo = True
    '                End If
    '            Next

    '            If inCombo = False Then
    '                MsgBox("Secondary Customer - Data is Invalid, please select in Drop Down List.")
    '                btcSHM00002.SelectedIndex = 0
    '                cboCus2No.Enabled = True
    '                If cboCus2No.Enabled And cboCus2No.Visible Then cboCus2No.Focus()
    '                not_in_Combo_HDR = True
    '                Exit Function
    '            End If
    '        End If

    '    End Function

    '    Private Sub btcSHM00002_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcSHM00002.SelectedIndexChanged

    '    End Sub

    '    Private Sub btcSHM00002_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles btcSHM00002.Selecting
    '        '''
    '        If rs_SHCBNDTL.Tables("RESULT") Is Nothing Then
    '            Call insert_SHIPGDTL(True)

    '        End If
    '        Call display_Detail(Val(txtShpSeq.Text))

    '        '     Call reset_detail_control("Detail_Init")


    '    End Sub

    '    Private Sub cmdNxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDtlNext.Click


    '        ' If sMode = cModeAdd Or sMode = cModeUpd Or Recordstatus = False Then
    '        '20130908 for anita
    '        If sMode = cModeAdd Or sMode = cModeUpd Or sMode = cModeRead Then

    '            If check_leave_ShippingDetail() = True Then
    '                Call fill_SHIPGDTL()
    '                '''0811
    '                ''avoid DBNULL
    '                If Not rs_SHCBNDTL.Tables("RESULT").Rows.Count > ReadingIndex Then
    '                    Exit Sub
    '                End If

    '                If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*ADD*~" Or rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*NEW*~" Then
    '                    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*NEW*~"
    '                End If

    '                If ReadingIndex = rs_SHCBNDTL.Tables("RESULT").Rows.Count - 1 Then
    '                    ReadingIndex = ReadingIndex
    '                Else
    '                    ReadingIndex = ReadingIndex + 1
    '                End If

    '                ''avoid DBNULL
    '                If Not rs_SHCBNDTL.Tables("RESULT").Rows.Count > ReadingIndex Then
    '                    Exit Sub
    '                End If


    '                Dim shpseq As Integer
    '                shpseq = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_shpseq")

    '                Call display_Detail(shpseq)
    '                If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("del") = "Y" Then
    '                    Exit Sub
    '                End If

    '                'Call ShowFooterBar(True)

    '            End If
    '        End If



    '    End Sub

    '    Private Function check_leave_ShippingDetail() As Boolean
    '        check_leave_ShippingDetail = False

    '        'If check_dup_Packing() = True Then
    '        '    MsgBox("Duplicate packing selected!")

    '        '    Call insert_SHIPGDTL(False)
    '        '    Call display_Detail(txtSeq.Text)

    '        '    Call reset_detail_control("Detail_Init", "All")
    '        '    Call reset_detail_data("Detail_Init", "All")

    '        '    check_leave_ShippingDetail = False
    '        '    Exit Function
    '        'ElseIf cboColCde.Text = "" And txtColCde.Text = "" Then
    '        '    MsgBox("Missing Color!")
    '        '    check_leave_ShippingDetail = False
    '        '    Exit Function
    '        'ElseIf cboPcking.Text = "" Then
    '        '    MsgBox("Missing Packing!")
    '        '    check_leave_ShippingDetail = False
    '        '    Exit Function
    '        'End If

    '        check_leave_ShippingDetail = True
    '    End Function


    '    Private Sub cmdBck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDtlPre.Click

    '        ' If sMode = cModeAdd Or sMode = cModeUpd Or Recordstatus = False Then
    '        '20130908 for anita
    '        If sMode = cModeAdd Or sMode = cModeUpd Or sMode = cModeRead Then

    '            If check_leave_ShippingDetail() = True Then
    '                Call fill_SHIPGDTL()
    '                ''avoid DBNULL
    '                If Not rs_SHCBNDTL.Tables("RESULT").Rows.Count > ReadingIndex Then
    '                    Exit Sub
    '                End If

    '                '''0811
    '                If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*ADD*~" Or rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*NEW*~" Then
    '                    rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*NEW*~"
    '                End If

    '                If ReadingIndex = 0 Then
    '                    ReadingIndex = 0
    '                Else
    '                    ReadingIndex = ReadingIndex - 1
    '                End If

    '                ''avoid DBNULL
    '                If Not rs_SHCBNDTL.Tables("RESULT").Rows.Count > ReadingIndex Then
    '                    Exit Sub
    '                End If

    '                Dim shpseq As Integer
    '                shpseq = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_shpseq")

    '                Call display_Detail(shpseq)
    '                If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("del") = "Y" Then
    '                    Exit Sub
    '                End If

    '                '                Call ShowFooterBar(True)
    '            End If
    '        End If

    '    End Sub

    '    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
    '        Dim tmpqutno As String
    '        Dim tmpcocde As String


    '        tmpqutno = txtNoteNo.Text
    '        tmpcocde = cboCoCde.Text

    '        Call cmdClearClick()


    '        txtNoteNo.Text = tmpqutno
    '        cboCoCde.Text = tmpcocde

    '        txtNoteNo.Focus()





    '    End Sub

    '    Private Sub cmdClearClick()
    '        Dim YesNoCancel As Integer

    '        If Recordstatus = True Then
    '            If Add_flag = True Or Insert_flag = True Then
    '                YesNoCancel = MsgBox("Do you want to save before clear the screen?", MsgBoxStyle.YesNoCancel)
    '            Else
    '                YesNoCancel = MsgBox("Record has been modified.  Do you want to save before clear the screen?", MsgBoxStyle.YesNoCancel)
    '            End If

    '            If YesNoCancel = vbYes Then

    '                '20131115 avoid ini for all cases    
    '                sMode = cModeInit
    '                '                Call formInit(cModeInit)

    '            ElseIf YesNoCancel = vbNo Then
    '                Call setStatus(cModeClear)
    '                sMode = cModeClear
    '            ElseIf YesNoCancel = vbCancel Then
    '                Exit Sub
    '            End If
    '        Else
    '            Call setStatus(cModeClear)
    '            sMode = cModeClear
    '            If txtNoteNo.Enabled And txtNoteNo.Visible Then
    '                txtNoteNo.Focus()
    '            End If
    '        End If
    '    End Sub

    Public Sub mmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click

        txtNoteNo.Text = UCase(Trim(txtNoteNo.Text))
        Call txtNoteNoKeyPress()
        Recordstatus = False
        fmeDetail.Enabled = True
        btcSHM00002.Enabled = True


        If Not rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
            For i As Integer = 0 To rs_SHCBNHDR.Tables("RESULT").Columns.Count - 1
                rs_SHCBNHDR.Tables("RESULT").Columns(i).ReadOnly = False
            Next i
        End If
        If Not rs_SHCBNDTL.Tables("RESULT") Is Nothing Then
            For i As Integer = 0 To rs_SHCBNDTL.Tables("RESULT").Columns.Count - 1
                rs_SHCBNDTL.Tables("RESULT").Columns(i).ReadOnly = False
            Next i
        End If

        'temp
        chkUpd.Enabled = False


    End Sub

    Public Function txtNoteNoKeyPress() As Boolean
        Dim srowFilter As String


        txtNoteNoKeyPress = False
        Add_flag = False


        '''20131017
        ''' 
        If (Trim(txtNoteNo.Text) = "" And txtNoteNo.Enabled = True) Then
            If txtNoteNo.Enabled And txtNoteNo.Visible Then
                txtNoteNo.Focus()
                MsgBox("Please input Note No.")
                Exit Function
            End If
        End If

        txtNoteNo.Text = txtNoteNo.Text.ToUpper()

        setStatus(cModeUpd)

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_SHCBNHDR '" & cboCoCde.Text & "','" & txtNoteNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SHCBNHDR, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtNoteNoKeyPress sp_select_SHIPGHDR :" & rtnStr)
            Exit Function
        End If

        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 And txtNoteNo.Enabled = True Then
            MsgBox("No Record Found!")
            If txtNoteNo.Enabled And txtNoteNo.Visible Then
                txtNoteNo.Focus()
                Exit Function
            End If
        Else
            '''''''''''            Current_TimeStamp = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_timstp")
            'temp
            '''''''            Call Display()

            Call setStatus("Updating")

            If cboCDStatus.SelectedIndex > 1 Then
                Me.mmdInsRow.Enabled = False
                Me.mmdDelRow.Enabled = False
                '----------------------------------
                mmdSave.Enabled = False
            End If
            txtNoteNo.Enabled = False
            btcSHM00002.SelectedIndex = 0
            btcSHM00002.Enabled = True
            btcSHM00002.Focus()

            Recordstatus = False

        End If

        For i As Integer = 0 To rs_SHCBNHDR.Tables("RESULT").Columns.Count - 1
            rs_SHCBNHDR.Tables("RESULT").Columns(i).ReadOnly = False
        Next i

        'gsCompany = Trim(cboCoCde.Text)
        'Call Update_gs_Value(gsCompany)

        'gspStr = "sp_select_SYUSRRIGHT_Check '" & cboCoCde.Text & "','" & gsUsrID & "','" & txtNoteNo.Text & "','" & sMODULE & "'"
        'rtnLong = execute_SQLStatement(gspStr, rs_SYUSRRIGHT_Check, rtnStr)

        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading txtNoteNoKeyPress sp_select_SYUSRRIGHT_Check :" & rtnStr)
        '    Exit Function
        'End If

        'If Not rs_SYUSRRIGHT_Check.Tables("RESULT") Is Nothing Then
        '    If rs_SYUSRRIGHT_Check.Tables("RESULT").Rows.Count = 0 Then
        '        MsgBox("You have no Right access this document.")
        '        Exit Function
        '    Else
        '        Call display_Header()
        '        Call setStatus(cModeUpd)
        '        sMode = cModeUpd
        '    End If

        'End If

        '''templ
        Call display_header()
        Call setStatus(cModeUpd)
        sMode = cModeUpd



        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_list_SHCBNDTL '" & cboCoCde.Text & "','" & txtNoteNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SHCBNDTL, rtnStr)
        gspStr = ""

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtNoteNoKeyPress sp_select_SHIPGDTL :" & rtnStr)
            Exit Function
        End If

        For i As Integer = 0 To rs_SHCBNDTL.Tables("RESULT").Columns.Count - 1
            rs_SHCBNDTL.Tables("RESULT").Columns(i).ReadOnly = False
        Next i


        Call Display()


        If rs_SHCBNDTL.Tables("RESULT").Rows.Count > 0 Then

            Dim curshpseq As Integer
            curshpseq = rs_SHCBNDTL.Tables("RESULT").Rows(0).Item("hnd_seq")
            Call display_Detail(curshpseq)

        End If


        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
            Exit Function
        End If

        If DateDiff("d", rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_credat"), "09/09/2003") > 0 Then
            sMode = cModeRead
            'Call formInit(cModeRead)
        Else
            If Enq_right_local = True Then
                sMode = cModeUpd
                'Call formInit(cModeUpd)
            Else
                sMode = cModeRead
                'Call formInit(cModeRead)
            End If

        End If


    End Function

    Private Sub display_header()
        Dim rs_result As New DataSet
        Dim maxseq As Integer

        'gscompany = trim(cbococde.text)
        'call update_gs_value(gscompany)

        'gspstr = "sp_select_shipgdtl_rs '" & cbococde.text & "','" & txtnoteno.text & "'"
        'rtnlong = execute_sqlstatement(gspstr, rs_result, rtnstr)
        'gspstr = ""

        'if rtnlong <> rc_success then
        '    msgbox("error on loading display_header sp_select_shipgdtl 1 :" & rtnstr)
        '    exit sub
        'end if

        ''''''''''''''''''''''''''
        If rs_SHCBNHDR.Tables("result").Rows.Count = 0 Then
            Exit Sub
        End If

        Call display_combo(Trim(rs_SHCBNHDR.Tables("result").Rows(0)("hnh_notsts")), cboCDStatus)

        DTIssDat.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_credat")
        DTRevDat.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_issdat")

        If rs_SHCBNHDR.Tables("result").Rows(0)("hnh_nottyp") = "c" Then
            optCredit.Checked = True
            optDebit.Checked = False
        Else
            optDebit.Checked = True
            optCredit.Checked = False
        End If
        optCredit.Enabled = False
        optDebit.Enabled = False

        txtRefNo.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_refno")

        ''        txtnoteno.text = rs_shcbnhdr.tables("result").rows(0)("hnh_noteno")
        'Call queryshipinfo()

        dr = rs_CUBASINF.Tables("RESULT").Select("cbi_cusno ='" & rs_SHCBNHDR.Tables("result").Rows(0)("hnh_pricus") & "'")
        If Not dr Is Nothing Then
            If dr.Length > 0 Then
                txtPrmCus.Text = dr(0)("cbi_cusno") + " - " + dr(0)("cbi_cussna")
            End If
        End If
        dr = rs_CUBASINF.Tables("RESULT").Select("cbi_cusno ='" & rs_SHCBNHDR.Tables("result").Rows(0)("hnh_seccus") & "'")
        If Not dr Is Nothing Then
            If dr.Length > 0 Then
                txtSecCus.Text = dr(0)("cbi_cusno") + " - " + dr(0)("cbi_cussna")
            End If
        End If

        txtBilAdr.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_biladr")

        Call display_combo(Trim(rs_SHCBNHDR.Tables("result").Rows(0)("hnh_bilcty")), cboBCty)
        Call display_combo("us", cboBCty)

        txtBilstt.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_bilstt")
        txtBilZip.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_bilzip")

        'txtshpadr.text = rs_shcbnhdr.tables("result").rows(0)("hnh_shpadr")
        'call displaycombo(cboscty, rs_shcbnhdr.tables("result").rows(0)("hnh_shpcty"))
        'txtshpstt.text = rs_shcbnhdr.tables("result").rows(0)("hnh_shpstt")
        'txtshpzip.text = rs_shcbnhdr.tables("result").rows(0)("hnh_shpzip")

        Call display_combo(Trim(rs_SHCBNHDR.Tables("result").Rows(0)("hnh_prctrm")), cboPrcTrm)
        Call display_combo(Trim(rs_SHCBNHDR.Tables("result").Rows(0)("hnh_paytrm")), cboPayTrm)

        txtTtlUnt.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_ttlunt")
        txtTtlAmt.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_ttlamt")


        txtRmk.Text = rs_SHCBNHDR.Tables("result").Rows(0)("hnh_rmk")

        If Not rs_SHCBNDTL.Tables("result") Is Nothing Then
            If rs_SHCBNDTL.Tables("result").Rows.Count > 0 Then
                If Not IsDBNull(rs_SHCBNDTL.Tables("result").Rows(0)("max_seq")) Then
                    maxseq = rs_SHCBNDTL.Tables("result").Rows(0)("max_seq")
                End If

                'Call displaydetail()

                optItm.Enabled = True
                optMsc.Enabled = True

                'if readingindex > 0 then
                '    cmddtlpre.enabled = true
                'else
                '    cmddtlpre.enabled = false
                'end if

                'If readingindex = rs_SHCBNDTL.Tables("result").Rows.Count -1 Then
                '    cmddtlnext.enabled = false
                'else
                '    cmddtlnext.enabled = true
                'end if

                'StatusBar.Panels(2).Text = Format(rs_SHCBNHDR.Tables("result").Rows(0)("hnh_credat"), "dd/mm/yyyy") & " " & Format(rs_SHCBNHDR.Tables("result").Rows(0)("hnh_upddat"), "dd/mm/yyyy") & _
                '                          " " & rs_SHCBNHDR.Tables("result").Rows(0)("hnh_updusr")


            Else
                maxseq = 0
            End If
        End If

        'If rs_SHPCDHDR.Tables("result").Rows(0)("hih_smpshp") = "Y" Then
        '    chkSample.Checked = True
        'Else
        '    chkSample.Checked = False
        'End If


    End Sub

    '    Private Sub formInit(ByVal m As String)
    '        If m = cModeInit Then
    '            Call clearAllDisplay(Me)
    '        End If

    '        'Call resetcmdButton(m)

    '        'Call resetDisplay(m)

    '        'Me.StatusBar.Text = m
    '        'Me.StatusBarPanel1.Text = m
    '        'SetStatusBar(m)
    '    End Sub

    '    Private Sub clearAllDisplay(ByVal fv As Control)
    '        Dim v As Control
    '        For Each v In fv.Controls

    '            If TypeOf v Is BaseTabControl Then
    '                Dim btc As BaseTabControl
    '                btc = v
    '                Dim i As Integer
    '                For i = 0 To btc.TabPages.Count - 1
    '                    Call clearAllDisplay(btc.TabPages(i))
    '                Next i
    '            ElseIf TypeOf v Is GroupBox Then
    '                Call clearAllDisplay(v)
    '                v.Enabled = False
    '            Else
    '                If TypeOf v Is TextBox Or TypeOf v Is MaskedTextBox Or TypeOf v Is ComboBox Or TypeOf v Is RichTextBox Then
    '                    v.Text = ""
    '                    v.Enabled = False
    '                ElseIf TypeOf v Is ListBox Then
    '                    Dim lb As ListBox
    '                    lb = v
    '                    lb.Items.Clear()
    '                    v.Enabled = False
    '                ElseIf TypeOf v Is CheckBox Then
    '                    Dim cb As CheckBox
    '                    cb = v
    '                    cb.Checked = False
    '                    v.Enabled = False
    '                ElseIf TypeOf v Is DataGridView Then
    '                    Dim dg As DataGridView
    '                    dg = v
    '                    dg.DataSource = Nothing
    '                End If
    '            End If
    '        Next v

    '    End Sub

    '    Private Sub txtBilRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtBilRmk.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtBilRmk.Text

    '                If tmpstr <> rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_BilRmk") Then
    '                    Recordstatus = True


    '                    If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*ADD*~" And rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*NEW*~" Then
    '                        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_BilRmk") = tmpstr
    '                End If
    '            End If
    '        End If

    '    End Sub

    '    Public Sub display_combo(ByVal val As String, ByVal combo As ComboBox)

    '        If val = "" Then
    '            combo.Text = val
    '            Exit Sub
    '        End If

    '        Dim i As Integer

    '        For i = 0 To combo.Items.Count - 1
    '            If val = Split(combo.Items(i), " - ")(0) Then
    '                combo.Text = combo.Items(i)
    '                Exit Sub
    '            End If
    '        Next i

    '        combo.Text = val
    '    End Sub

    '    Private Sub txtVes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrmCus.TextChanged
    '        If rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtPrmCus.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtPrmCus.Text

    '                If tmpstr <> rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ves") Then
    '                    Recordstatus = True


    '                    If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*ADD*~" And rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*NEW*~" Then
    '                        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ves") = tmpstr
    '                End If
    '            End If
    '        End If


    '    End Sub

    '    Private Sub txtVoy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSecCus.TextChanged
    '        If rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtSecCus.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtSecCus.Text

    '                If tmpstr <> rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_voy") Then
    '                    Recordstatus = True


    '                    If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*ADD*~" And rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*NEW*~" Then
    '                        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_voy") = tmpstr
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtPotLoa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtPotLoa.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtPotLoa.Text

    '                If tmpstr <> rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_potloa") Then
    '                    Recordstatus = True


    '                    If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*ADD*~" And rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*NEW*~" Then
    '                        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_potloa") = tmpstr
    '                End If
    '            End If
    '        End If


    '    End Sub

    '    Private Sub txtCrr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtCrr.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtCrr.Text

    '                If tmpstr <> rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_crr") Then
    '                    Recordstatus = True


    '                    If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*ADD*~" And rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*NEW*~" Then
    '                        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_crr") = tmpstr
    '                End If
    '            End If
    '        End If


    '    End Sub

    '    Private Sub txtDst_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtDst.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtDst.Text

    '                If tmpstr <> rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_dst") Then
    '                    Recordstatus = True


    '                    If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*ADD*~" And rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*NEW*~" Then
    '                        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_dst") = tmpstr
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtCrrSo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtCrrSo.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtCrrSo.Text

    '                If tmpstr <> rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_crrso") Then
    '                    Recordstatus = True


    '                    If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*ADD*~" And rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*NEW*~" Then
    '                        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_crrso") = tmpstr
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtGodDsc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGodDsc.TextChanged
    '        If rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtGodDsc.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtGodDsc.Text

    '                If tmpstr <> rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_goddsc") Then
    '                    Recordstatus = True


    '                    If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*ADD*~" And rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*NEW*~" Then
    '                        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_goddsc") = tmpstr
    '                End If
    '            End If
    '        End If


    '    End Sub

    '    Private Sub txtBilEnt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtBilEnt.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtBilEnt.Text

    '                If tmpstr <> rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_bilent") Then
    '                    Recordstatus = True


    '                    If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*ADD*~" And rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*NEW*~" Then
    '                        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_bilent") = tmpstr
    '                End If
    '            End If
    '        End If

    '    End Sub

    '    Private Sub txtBilAdr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRmk.TextChanged
    '        If rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtRmk.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtRmk.Text

    '                If tmpstr <> rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_biladr") Then
    '                    Recordstatus = True


    '                    If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*ADD*~" And rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*NEW*~" Then
    '                        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_biladr") = tmpstr
    '                End If
    '            End If
    '        End If


    '    End Sub

    '    Private Sub txtBilStt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTtlUnt.TextChanged
    '        If rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtTtlUnt.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtTtlUnt.Text

    '                If tmpstr <> rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_bilstt") Then
    '                    Recordstatus = True


    '                    If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*ADD*~" And rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*NEW*~" Then
    '                        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_bilstt") = tmpstr
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtBilZip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtBilZip.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtBilZip.Text

    '                If tmpstr <> rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_bilzip") Then
    '                    Recordstatus = True


    '                    If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*ADD*~" And rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*NEW*~" Then
    '                        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_bilzip") = tmpstr
    '                End If
    '            End If
    '        End If




    '    End Sub

    '    Private Sub txtLCNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtLCNo.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtLCNo.Text

    '                If tmpstr <> rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_lcno") Then
    '                    Recordstatus = True


    '                    If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*ADD*~" And rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*NEW*~" Then
    '                        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_lcno") = tmpstr
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtLcBank_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtLcBank.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtLcBank.Text

    '                If tmpstr <> rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_lcbank") Then
    '                    Recordstatus = True


    '                    If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*ADD*~" And rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*NEW*~" Then
    '                        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_lcbank") = tmpstr
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtTtlCtn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtTtlCtn.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtTtlCtn.Text

    '                If tmpstr <> rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ttlctn") Then
    '                    Recordstatus = True


    '                    If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*ADD*~" And rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*NEW*~" Then
    '                        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ttlctn") = tmpstr
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtTtlNwg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtTtlNwg.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtTtlNwg.Text

    '                If tmpstr <> rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ttlnwg") Then
    '                    Recordstatus = True


    '                    If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*ADD*~" And rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*NEW*~" Then
    '                        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ttlnwg") = tmpstr
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtTtlGwg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtTtlGwg.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtTtlGwg.Text

    '                If tmpstr <> rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ttlgwg") Then
    '                    Recordstatus = True


    '                    If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*ADD*~" And rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*NEW*~" Then
    '                        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ttlgwg") = tmpstr
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtTtlAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtTtlAmt.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtTtlAmt.Text

    '                If tmpstr <> rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ttlamt") Then
    '                    Recordstatus = True


    '                    If rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*ADD*~" And rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") <> "~*NEW*~" Then
    '                        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_ttlamt") = tmpstr
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub cboInvNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboInvNo.Click
    '        'If flg_DisplayInvoiceHeaderData = True Then Exit Sub
    '        'Dim rs As New ADOR.Recordset
    '        'Dim tmpTtlAmt As Double
    '        'Dim tmpTtlCtn As Double
    '        'Dim tmpTtlVol As Double

    '        'Dim disP As Double
    '        'Dim disA As Double
    '        'Dim PreP As Double
    '        'Dim PreA As Double

    '        'disP = 0
    '        'disA = 0
    '        'PreP = 0
    '        'PreA = 0


    '        'flg_DisplayInvoiceHeaderData = True
    '        'If FindINVHDR_RS() Then
    '        '    Call updateInvoiceDetail(Me.cboInvNo.Text)
    '        '    '-----------------------------------------
    '        '    Call DisplayShipInv()
    '        'End If

    '        'flg_DisplayInvoiceHeaderData = True


    '    End Sub

    '    Private Sub cboInvNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInvNo.SelectedIndexChanged

    '    End Sub


    '    'Private Sub DisplayShipInv()
    '    '    flg_DisplayInvoiceHeaderData = True
    '    '    Dim i As Integer

    '    '    Call display_combo(rs_SHINVhdr.tables("result").rows(0)("hiv_invno"), cboInvNo)

    '    '    txtInvDat.Text = rs_SHINVhdr.tables("result").rows(0)("hiv_invdat")

    '    '    Call display_combo(rs_SHINVhdr.tables("result").rows(0)("hiv_prctrm"), cboPrcTrm)
    '    '    'cboPrcTrm.Clear
    '    '    'cboPrcTrm.items.add rs_SHINVhdr.tables("result").rows(0)("hiv_0prctrm")
    '    '    'cboPrcTrm.selectedindex = 0

    '    '    Call display_combo(rs_SHINVhdr.tables("result").rows(0)("hiv_paytrm"), cboPayTrm)
    '    '    'cboPayTrm.Clear
    '    '    'cboPayTrm.items.add rs_SHINVhdr.tables("result").rows(0)("hiv_paytrm")
    '    '    'cboPayTrm.selectedindex = 0

    '    '    For i = 0 To optDocTyp.count - 1
    '    '        If optDocTyp.Item(i).Caption = rs_SHINVhdr.tables("result").rows(0)("hiv_doctyp") Then
    '    '            optDocTyp.Item(i) = True
    '    '        Else
    '    '            optDocTyp.Item(i) = False
    '    '        End If
    '    '    Next

    '    '    If rs_SHINVhdr.tables("result").rows(0)("hiv_aformat") = "1" Then
    '    '        optFOB.Item(1) = True
    '    '        optFOB.Item(2) = False
    '    '    Else
    '    '        optFOB.Item(1) = False
    '    '        optFOB.Item(2) = True
    '    '    End If

    '    '    txtDoc.Text = rs_SHINVhdr.tables("result").rows(0)("hiv_doc")
    '    '    cboBank.Text = rs_SHINVhdr.tables("result").rows(0)("hiv_bank")
    '    '    txtCover.Text = rs_SHINVhdr.tables("result").rows(0)("hiv_cover")
    '    '    txtFtrRmk.Text = rs_SHINVhdr.tables("result").rows(0)("hiv_ftrrmk")
    '    '    txtLcStmt.Text = rs_SHINVhdr.tables("result").rows(0)("hiv_lcstmt")
    '    '    cboUntAmt.Text = rs_SHINVhdr.tables("result").rows(0)("hiv_untamt")
    '    '    txtTtlAmtI.Text = rs_SHINVhdr.tables("result").rows(0)("hiv_ttlamt")
    '    '    txtInvAmt.Text = rs_SHINVhdr.tables("result").rows(0)("hiv_invamt")
    '    '    txtAFamt.Text = rs_SHINVhdr.tables("result").rows(0)("hiv_afamt")
    '    '    txtTtlVolI.Text = rs_SHINVhdr.tables("result").rows(0)("hiv_ttlvol")
    '    '    TxtTtlCtnI.Text = rs_SHINVhdr.tables("result").rows(0)("hiv_ttlctn")
    '    '    txtTtlHdpAmt.Text = 0
    '    '    txtTtlHdpAmt.Text = round(txtTtlAmtI.Text - txtInvAmt.Text - txtAFamt.Text, 2)

    '    '    If rs_SHINVhdr.tables("result").rows(0)("hiv_invsts") = "CLO" Then
    '    '        chkClose = 1
    '    '    Else
    '    '        chkClose = 0
    '    '    End If


    '    '    flg_DisplayInvoiceHeaderData = False

    '    'End Sub
    '    Private Sub DisplayShipInv()
    '        flg_DisplayInvoiceHeaderData = True
    '        Dim i As Integer


    '        If rs_SHINVHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHINVHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If

    '        Call display_combo(rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_invno"), cboInvNo)

    '        txtInvDat.Text = rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_invdat")

    '        Call display_combo(rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_prctrm"), cboPrcTrm)
    '        'cboPrcTrm.Clear
    '        'cboPrcTrm.items.add rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_0prctrm")
    '        'cboPrcTrm.selectedindex = 0

    '        Call display_combo(rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_paytrm"), cboPayTrm)
    '        'cboPayTrm.Clear
    '        'cboPayTrm.items.add rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_paytrm")
    '        'cboPayTrm.selectedindex = 0

    '        If optDocTyp0.Text = rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_doctyp") Then
    '            optDocTyp0.Checked = True
    '        End If
    '        If optDocTyp1.Text = rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_doctyp") Then
    '            optDocTyp1.Checked = True
    '        End If
    '        If optDocTyp2.Text = rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_doctyp") Then
    '            optDocTyp2.Checked = True
    '        End If

    '        If optFOB1.Text = rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_aformat") Then
    '            optFOB1.Checked = True
    '        End If
    '        If optFOB2.Text = rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_aformat") Then
    '            optFOB2.Checked = True
    '        End If


    '        txtDoc.Text = rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_doc")
    '        cbobank.Text = rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_bank")
    '        txtCover.Text = rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_cover")
    '        txtFtrRmk.Text = rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_ftrrmk")
    '        txtLcStmt.Text = rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_lcstmt")
    '        cboUntAmt.Text = rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_untamt")
    '        txtTtlAmtI.Text = rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_ttlamt")
    '        txtInvAmt.Text = rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_invamt")
    '        txtAFamt.Text = rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_afamt")
    '        txtTtlVolI.Text = rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_ttlvol")
    '        TxtTtlCtnI.Text = rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_ttlctn")
    '        txtTtlHdpAmt.Text = 0
    '        txtTtlHdpAmt.Text = round(txtTtlAmtI.Text - txtInvAmt.Text - txtAFamt.Text, 2)

    '        If rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_invsts") = "CLO" Then
    '            chkClose.Checked = True
    '        Else
    '            chkClose.Checked = False
    '        End If


    '        flg_DisplayInvoiceHeaderData = False

    '    End Sub

    '    Private Function round(ByVal a As Double, ByVal Value As Double) As Double
    '        Dim S As String

    '        S = "0"

    '        If Value = 0 Then S = "0"
    '        If Value = 1 Then S = "0.0"
    '        If Value = 2 Then S = "0.00"
    '        If Value = 3 Then S = "0.000"
    '        If Value = 4 Then S = "0.0000"
    '        If Value = 5 Then S = "0.00000"
    '        If Value = 6 Then S = "0.000000"
    '        If Value = 7 Then S = "0.0000000"
    '        If Value = 8 Then S = "0.00000000"
    '        If Value = 9 Then S = "0.000000000"
    '        If Value = 10 Then S = "0.0000000000"

    '        round = CDbl(Format(a, S))
    '    End Function


    '    Private Sub DisplayShipMark()
    '        flg_DisplayShipMarkData = True
    '        Call display_combo(rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_invno"), cboInvNoM)
    '        Call display_combo(rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_ordno"), cboOrdNo)

    '        txtImgNam.Text = rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_imgnam")
    '        txtImgPth.Text = rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_imgpth")
    '        txtEngDsc.Text = rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_engdsc")
    '        txtEngRmk.Text = rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_engrmk")

    '        'If rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_imgpth") = "" Then
    '        '    Picture1 = Nothing
    '        'Else
    '        '    On Error Resume Next
    '        '    Picture1.Picture = LoadPicture(rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_imgpth"))
    '        'End If
    '        flg_DisplayShipMarkData = False
    '    End Sub

    '    Private Sub txtImgNam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImgNam.TextChanged

    '        If rs_SHSHPMRK.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHSHPMRK.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtImgNam.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtImgNam.Text

    '                If tmpstr <> rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_imgnam") Then
    '                    Recordstatus = True


    '                    If rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_creusr") <> "~*ADD*~" And rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_creusr") <> "~*NEW*~" Then
    '                        rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_imgnam") = tmpstr
    '                End If
    '            End If
    '        End If

    '    End Sub

    '    Private Sub txtEngDsc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEngDsc.TextChanged

    '        If rs_SHSHPMRK.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHSHPMRK.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtEngDsc.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtEngDsc.Text

    '                If tmpstr <> rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_engrmk") Then
    '                    Recordstatus = True


    '                    If rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_creusr") <> "~*ADD*~" And rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_creusr") <> "~*NEW*~" Then
    '                        rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_engrmk") = tmpstr
    '                End If
    '            End If
    '        End If

    '    End Sub

    '    Private Sub txtImgPth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImgPth.TextChanged
    '        If rs_SHSHPMRK.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHSHPMRK.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtImgPth.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtImgPth.Text

    '                If tmpstr <> rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_imgpth") Then
    '                    Recordstatus = True


    '                    If rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_creusr") <> "~*ADD*~" And rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_creusr") <> "~*NEW*~" Then
    '                        rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_imgpth") = tmpstr
    '                End If
    '            End If
    '        End If


    '    End Sub

    '    Private Sub txtEngRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEngRmk.TextChanged
    '        If rs_SHSHPMRK.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHSHPMRK.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtEngRmk.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtEngRmk.Text

    '                If tmpstr <> rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_engrmk") Then
    '                    Recordstatus = True


    '                    If rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_creusr") <> "~*ADD*~" And rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_creusr") <> "~*NEW*~" Then
    '                        rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHSHPMRK.Tables("RESULT").Rows(0).Item("hsm_engrmk") = tmpstr
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtItmDsc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtItmDsc.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtItmDsc.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_itmdsc")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_itmdsc") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_itmdsc") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If

    '    End Sub

    '    Private Sub txtCtrCfs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtCtrCfs.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtCtrCfs.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ctrcfs")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ctrcfs") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ctrcfs") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If


    '    End Sub

    '    Private Sub txtSealNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtSealNo.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtSealNo.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_sealno")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_sealno") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_sealno") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtJobNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtJobNo.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtJobNo.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_jobno")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_jobno") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_jobno") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If


    '    End Sub

    '    Private Sub txtOrdNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtOrdNo.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtOrdNo.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ordno")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ordno") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ordno") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtCusPo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtCusPo.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtCusPo.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_cuspo")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_cuspo") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_cuspo") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If




    '    End Sub

    '    Private Sub txtCusStyNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtCusStyNo.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtCusStyNo.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_cusstyno")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_cusstyno") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_cusstyno") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If





    '    End Sub

    '    Private Sub txtCusItm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtCusItm.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtCusItm.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_cusitm")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_cusitm") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_cusitm") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If





    '    End Sub

    '    Private Sub txtCusCol_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtCusCol.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtCusCol.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_cuscol")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_cuscol") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_cuscol") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If





    '    End Sub

    '    Private Sub txtCustUM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtCustUM.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtCustUM.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_custum")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_custum") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_custum") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If






    '    End Sub

    '    Private Sub txtColDsc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtColDsc.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtColDsc.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_coldsc")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_coldsc") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_coldsc") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If






    '    End Sub

    '    Private Sub txtShpQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtShpQty.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtShpQty.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_shpqty")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_shpqty") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_shpqty") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If




    '    End Sub

    '    Private Sub txtConFtr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtConFtr.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtConFtr.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_conftr")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_conftr") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_conftr") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If





    '    End Sub

    '    Private Sub txtPC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    End Sub

    '    Private Sub txtCtnStr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtCtnStr.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtCtnStr.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ctnstr")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ctnstr") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ctnstr") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtCtnEnd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtCtnEnd.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtCtnEnd.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ctnend")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ctnend") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ctnend") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtTtlCtnD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtTtlCtnD.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtTtlCtnD.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ttlctn")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ttlctn") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ttlctn") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtUntCde_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtUntCde.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtUntCde.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_untcde")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_untcde") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_untcde") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtInrCtn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtInrCtn.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtInrCtn.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_inrctn")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_inrctn") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_inrctn") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If




    '    End Sub

    '    Private Sub txtMtrCtn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtMtrCtn.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtMtrCtn.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_mtrctn")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_mtrctn") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_mtrctn") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtVol_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtVol.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtVol.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_vol")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_vol") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_vol") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtMtrdcm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtMtrdcm.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtMtrdcm.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_mtrdcm")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_mtrdcm") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_mtrdcm") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If




    '    End Sub

    '    Private Sub txtMtrwcm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtMtrwcm.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtMtrwcm.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_mtrwcm")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_mtrwcm") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_mtrwcm") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If


    '    End Sub

    '    Private Sub txtMtrhcm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtMtrhcm.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtMtrhcm.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_mtrhcm")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_mtrhcm") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_mtrhcm") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If


    '    End Sub

    '    Private Sub txtActVol_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtActVol.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtActVol.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_actvol")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_actvol") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_actvol") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If


    '    End Sub

    '    Private Sub txtGrsWgt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtGrsWgt.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtGrsWgt.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_grswgt")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_grswgt") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_grswgt") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtNetWgt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtNetWgt.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtNetWgt.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_netwgt")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_netwgt") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_netwgt") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If


    '    End Sub

    '    Private Sub txtItmShm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtItmShm.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtItmShm.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_itmshm")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_itmshm") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_itmshm") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtTtlVolD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtTtlVolD.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtTtlVolD.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ttlvol")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ttlvol") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ttlvol") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If




    '    End Sub

    '    Private Sub txtTtlGrsD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtTtlGrsD.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtTtlGrsD.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ttlgrs")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ttlgrs") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ttlgrs") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtTtlNetD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtTtlNetD.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtTtlNetD.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ttlnet")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ttlnet") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ttlnet") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtCmpRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtCmpRmk.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtCmpRmk.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_cmprmk")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_cmprmk") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_cmprmk") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtManNam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtManNam.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtManNam.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_mannam")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_mannam") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_mannam") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If




    '    End Sub

    '    Private Sub txtManAdr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtManAdr.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtManAdr.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_manadr")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_manadr") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_manadr") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If




    '    End Sub

    '    Private Sub txtPCPrc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtPCPrc.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtPCPrc.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_pcprc")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_pcprc") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_pcprc") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If




    '    End Sub

    '    Private Sub txtSelPrcD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtSelPrcD.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtSelPrcD.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_selprc")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_selprc") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_selprc") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If





    '    End Sub

    '    Private Sub txtTtlAmtD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtTtlAmtD.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtTtlAmtD.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ttlamt")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ttlamt") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ttlamt") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If

    '    End Sub

    '    Private Sub txtInvNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txtInvNo.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtInvNo.Text

    '                ''bug
    '                If Not IsDBNull(rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_invno")) Then
    '                    If tmpstr <> rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_invno") Then
    '                        Recordstatus = True
    '                        If rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*ADD*~" And rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") <> "~*NEW*~" Then
    '                            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_creusr") = "~*UPD*~"
    '                        End If
    '                        rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_invno") = tmpstr
    '                    End If
    '                End If
    '            End If
    '        End If

    '    End Sub

    '    Private Sub txtDoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDoc.TextChanged



    '        If rs_SHINVHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHINVHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtDoc.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtDoc.Text

    '                If tmpstr <> rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_doc") Then
    '                    Recordstatus = True


    '                    If rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hsm_creusr") <> "~*ADD*~" And rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hsm_creusr") <> "~*NEW*~" Then
    '                        rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hsm_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_doc") = tmpstr
    '                End If
    '            End If
    '        End If

    '    End Sub

    '    Private Sub txtFtrRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFtrRmk.TextChanged


    '        If rs_SHINVHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHINVHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtFtrRmk.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtFtrRmk.Text

    '                If tmpstr <> rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_ftrrmk") Then
    '                    Recordstatus = True


    '                    If rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hsm_creusr") <> "~*ADD*~" And rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hsm_creusr") <> "~*NEW*~" Then
    '                        rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hsm_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_ftrrmk") = tmpstr
    '                End If
    '            End If
    '        End If


    '    End Sub

    '    Private Sub txtLcStmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLcStmt.TextChanged


    '        If rs_SHINVHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHINVHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtLcStmt.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtLcStmt.Text

    '                If tmpstr <> rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_lcstmt") Then
    '                    Recordstatus = True


    '                    If rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hsm_creusr") <> "~*ADD*~" And rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hsm_creusr") <> "~*NEW*~" Then
    '                        rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hsm_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_lcstmt") = tmpstr
    '                End If
    '            End If
    '        End If


    '    End Sub

    '    Private Sub txtTtlAmtI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTtlAmtI.TextChanged


    '        If rs_SHINVHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHINVHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtTtlAmtI.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtTtlAmtI.Text

    '                If tmpstr <> rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_ttlamt") Then
    '                    Recordstatus = True


    '                    If rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_creusr") <> "~*ADD*~" And rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_creusr") <> "~*NEW*~" Then
    '                        rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_ttlamt") = tmpstr
    '                End If
    '            End If
    '        End If


    '    End Sub

    '    Private Sub txtInvAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvAmt.TextChanged


    '        If rs_SHINVHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHINVHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtInvAmt.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtInvAmt.Text

    '                If tmpstr <> rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_invamt") Then
    '                    Recordstatus = True


    '                    If rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_creusr") <> "~*ADD*~" And rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_creusr") <> "~*NEW*~" Then
    '                        rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_invamt") = tmpstr
    '                End If
    '            End If
    '        End If


    '    End Sub

    '    Private Sub txtTtlVolI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTtlVolI.TextChanged

    '        If rs_SHINVHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHINVHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtTtlVolI.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtTtlVolI.Text

    '                If tmpstr <> rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_ttlvol") Then
    '                    Recordstatus = True


    '                    If rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_creusr") <> "~*ADD*~" And rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_creusr") <> "~*NEW*~" Then
    '                        rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_ttlvol") = tmpstr
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtAFamt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAFamt.TextChanged

    '        If rs_SHINVHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHINVHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If txtAFamt.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = txtAFamt.Text

    '                If tmpstr <> rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_afamt") Then
    '                    Recordstatus = True


    '                    If rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_creusr") <> "~*ADD*~" And rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_creusr") <> "~*NEW*~" Then
    '                        rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_afamt") = tmpstr
    '                End If
    '            End If
    '        End If




    '    End Sub

    '    Private Sub TxtTtlCtnI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTtlCtnI.TextChanged

    '        If rs_SHINVHDR.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If
    '        If rs_SHINVHDR.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        If TxtTtlCtnI.Text <> "" Then
    '            If sMode = cModeAdd Or sMode = cModeUpd Then
    '                Dim tmpstr As String
    '                tmpstr = TxtTtlCtnI.Text

    '                If tmpstr <> rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_ttlctn") Then
    '                    Recordstatus = True


    '                    If rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_creusr") <> "~*ADD*~" And rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_creusr") <> "~*NEW*~" Then
    '                        rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_creusr") = "~*UPD*~"
    '                    End If
    '                    rs_SHINVHDR.Tables("RESULT").Rows(0).Item("hiv_ttlctn") = tmpstr
    '                End If
    '            End If
    '        End If



    '    End Sub

    '    Private Sub txtTtlHdpAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTtlHdpAmt.TextChanged

    '    End Sub

    '    Private Function check_ShippingDetail() As Boolean
    '        Dim Err As String
    '        Dim isValid As Boolean
    '        isValid = True
    '        check_ShippingDetail = True

    '        '*** Folder1

    '        If chkDel.Checked = False Then

    '            '--------------------------------------------------------------------------------------
    '            'Lester Wu , check CTR # and Seal # Mandatory if "CFS" is not selected
    '            If Me.optCtrSiz4.Checked = False And Trim(Me.txtCtrCfs.Text) = "" Then

    '                btcSHM00002.SelectedIndex = 1

    '                MsgBox("Please input CTR #!")
    '                If Me.txtCtrCfs.Enabled And Me.txtCtrCfs.Visible Then Me.txtCtrCfs.Focus()
    '                isValid = False
    '            ElseIf Me.optCtrSiz4.Checked = False And Trim(Me.txtSealNo.Text) = "" Then
    '                btcSHM00002.SelectedIndex = 1
    '                MsgBox("Please input Seal #!")
    '                If Me.txtSealNo.Enabled And Me.txtSealNo.Visible Then Me.txtSealNo.Focus()
    '                isValid = False
    '                'If txtOrdNo.Text = "" Then
    '            ElseIf txtOrdNo.Text = "" Then
    '                '--------------------------------------------------------------------------------------
    '                btcSHM00002.SelectedIndex = 1
    '                If optItm.Checked = True Then
    '                    MsgBox("Invalid job No.")
    '                    If txtJobNo.Enabled And txtJobNo.Visible Then txtJobNo.Focus()
    '                Else
    '                    MsgBox("Invalid SC No.")
    '                    If txtOrdNo.Enabled And txtOrdNo.Visible Then txtOrdNo.Focus()
    '                End If
    '                isValid = False

    '            ElseIf cboItmNo.Enabled And cboItmNo.Text = "" Then
    '                btcSHM00002.SelectedIndex = 1
    '                MsgBox("Invalid Item No.")
    '                If cboItmNo.Enabled And cboItmNo.Visible Then cboItmNo.Focus()
    '                isValid = False

    '            ElseIf cboColPck.Enabled And cboColPck.Text = "" Then
    '                btcSHM00002.SelectedIndex = 1
    '                MsgBox("Invalid Color Packing")
    '                If cboColPck.Enabled And cboColPck.Visible Then cboColPck.Focus()
    '                isValid = False

    '            ElseIf txtShpQty.Text = "" Then
    '                btcSHM00002.SelectedIndex = 1
    '                MsgBox("Invalid Ship Qty")
    '                If txtShpQty.Enabled And txtShpQty.Visible Then txtShpQty.Focus()
    '                isValid = False

    '            ElseIf txtShpQty.Text = 0 Then
    '                btcSHM00002.SelectedIndex = 1
    '                MsgBox("Invalid Ship Qty")
    '                If txtShpQty.Enabled And txtShpQty.Visible Then txtShpQty.Focus()
    '                isValid = False

    '            ElseIf txtCtnStr.Text = 0 Then
    '                btcSHM00002.SelectedIndex = 1
    '                MsgBox("Invalid Carton No.")
    '                If cmdMore.Enabled And cmdMore.Visible Then cmdMore.Focus()
    '                isValid = False

    '            ElseIf txtCtnEnd.Text = 0 Then
    '                btcSHM00002.SelectedIndex = 1
    '                MsgBox("Invalid Carton No.")
    '                If cmdMore.Enabled And cmdMore.Visible Then cmdMore.Focus()
    '                isValid = False

    '            ElseIf CDbl(txtCtnStr.Text) > CDbl(txtCtnEnd.Text) Then
    '                btcSHM00002.SelectedIndex = 1
    '                MsgBox("Start carton no. > End carton no.")
    '                If txtCtnStr.Enabled And txtCtnStr.Visible Then txtCtnStr.Focus()
    '                isValid = False


    '            ElseIf txtMtrdcm.Text = 0 Then
    '                btcSHM00002.SelectedIndex = 1
    '                MsgBox("Invalid Carton Length")
    '                If txtMtrdcm.Enabled And txtMtrdcm.Visible Then txtMtrdcm.Focus()
    '                isValid = False

    '            ElseIf txtMtrwcm.Text = 0 Then
    '                btcSHM00002.SelectedIndex = 1
    '                MsgBox("Invalid Carton Width")
    '                If txtMtrwcm.Enabled And txtMtrwcm.Visible Then txtMtrwcm.Focus()
    '                isValid = False

    '            ElseIf txtMtrhcm.Text = 0 Then
    '                btcSHM00002.SelectedIndex = 1
    '                MsgBox("Invalid Carton Height")
    '                If txtMtrhcm.Enabled And txtMtrhcm.Visible Then txtMtrhcm.Focus()
    '                isValid = False

    '            ElseIf txtActVol.Text = 0 Then
    '                btcSHM00002.SelectedIndex = 1
    '                MsgBox("Invalid Actual CBM")
    '                If txtMtrdcm.Enabled And txtMtrdcm.Visible Then txtMtrdcm.Focus()
    '                isValid = False

    '            ElseIf txtGrsWgt.Text = 0 Then
    '                btcSHM00002.SelectedIndex = 1
    '                MsgBox("Invalid Gross Weight")
    '                If txtGrsWgt.Enabled And txtGrsWgt.Visible Then txtGrsWgt.Focus()
    '                isValid = False

    '            ElseIf txtNetWgt.Text = 0 Then
    '                btcSHM00002.SelectedIndex = 1
    '                MsgBox("Invalid Net Weight")
    '                If txtNetWgt.Enabled And txtNetWgt.Visible Then txtNetWgt.Focus()
    '                isValid = False

    '            ElseIf txtTtlNetD.Text = 0 Then
    '                btcSHM00002.SelectedIndex = 1
    '                MsgBox("Invalid Net Weight")
    '                If txtNetWgt.Enabled And txtNetWgt.Visible Then txtNetWgt.Focus()
    '                isValid = False

    '            ElseIf CDbl(txtGrsWgt.Text) < CDbl(txtNetWgt.Text) Then
    '                btcSHM00002.SelectedIndex = 1
    '                MsgBox("Gross weight should not smaller than net weight!")
    '                If txtGrsWgt.Enabled And txtGrsWgt.Visible Then txtGrsWgt.Focus()
    '                isValid = False

    '            ElseIf Not MultiLineTextIsValid(txtItmShm.Text, 25) Then
    '                btcSHM00002.SelectedIndex = 1
    '                MsgBox("Item Ship Mark should be 25 chars per line")
    '                If txtItmShm.Enabled And txtItmShm.Visible Then txtItmShm.Focus()
    '                isValid = False

    '            ElseIf Not MultiLineTextIsValid(txtCmpRmk.Text, 50) Then
    '                btcSHM00002.SelectedIndex = 1
    '                MsgBox("Component Remark should be 50 chars per line!")
    '                If txtCmpRmk.Enabled And txtCmpRmk.Visible Then txtCmpRmk.Focus()
    '                isValid = False

    '            End If

    '            If isValid = True Then
    '                If Me.chkPC.Checked = True Then
    '                    If IsNumeric(Me.txtPC.Text) And IsNumeric(Me.txtShpQty.Text) Then
    '                        If CLng(Me.txtPC.Text) <> CLng(Me.txtShpQty.Text) * CLng(Me.txtConFtr.Text) Then
    '                            btcSHM00002.SelectedIndex = 1
    '                            MsgBox("Ship Qty not match with Qty in PC!")
    '                            If txtPC.Enabled And txtPC.Visible Then txtPC.Focus()
    '                            isValid = False
    '                        ElseIf CDbl(txtShpQty.Text) Mod CInt(txtMtrCtn.Text) <> 0 Then
    '                            btcSHM00002.SelectedIndex = 1
    '                            MsgBox("Shipped Qty should be divided by Master Qty")
    '                            If txtShpQty.Enabled And txtShpQty.Visible Then txtShpQty.Focus()
    '                            isValid = False
    '                        End If

    '                    End If
    '                End If

    '            End If

    '            Dim srowFilter As String

    '            If isValid = True Then

    '                srowFilter = "hdc_shpseq = '" + txtShpSeq.Text + "'"
    '                rs_SHDTLCTN.Tables("RESULT").DefaultView.rowFilter = srowFilter

    '                If rs_SHDTLCTN.Tables("RESULT").DefaultView.Count <= 0 Then
    '                    'Lester Wu 2005-09-15, Cater Overflow Error
    '                    'If CInt(txtCtnEnd.Text) - CInt(txtCtnStr.Text) + 1 <> CInt(txtTtlCtnD.Text) Then
    '                    If CLng(txtCtnEnd.Text) - CLng(txtCtnStr.Text) + 1 <> CLng(txtTtlCtnD.Text) Then
    '                        btcSHM00002.SelectedIndex = 1
    '                        MsgBox("Total Carton does not match with carton sequence!")
    '                        If txtCtnStr.Enabled And txtCtnStr.Visible Then txtCtnStr.Focus()
    '                        isValid = False
    '                    End If
    '                End If
    '                rs_SHDTLCTN.Tables("RESULT").DefaultView.rowFilter = ""
    '            End If
    '        End If


    '        If isValid = True Then
    '            isValid = SHCartonSC()
    '        End If


    '        If isValid = True Then
    '            check_ShippingDetail = True
    '        Else
    '            check_ShippingDetail = False
    '        End If
    '    End Function

    '    Public Function MultiLineTextIsValid(ByVal S As String, ByVal maxChar As Integer) As Boolean

    '        MultiLineTextIsValid = True

    '        Dim v   '*** Variant
    '        Dim temp   '*** temp variable

    '        v = Split(S, Chr(13) + Chr(10))   '*** split string by "vbNewLine"

    '        For Each temp In v
    '            If Len(temp) > maxChar Then   '*** if length of each string > maxChar
    '                MultiLineTextIsValid = False   '***return false
    '            End If
    '        Next

    '    End Function


    '    Function SHCartonSC() As Boolean
    '        Dim rs As DataSet
    '        Dim S As String


    '        If rs_SHCBNDTL.Tables("RESULT").Rows.Count <= 0 Or rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ordno") = "" Or rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_ordseq") = 0 Then
    '            SHCartonSC = True
    '            Exit Function
    '        End If

    '        rs_SCDTLCTN = Nothing

    '        '***************************************************
    '        '*** Get SC Carton record     **********************
    '        '***************************************************

    '        'Marco Added for fixing global company code problem at 20040108
    '        gsCompany = Trim(cboCoCde.Text)
    '        Call Update_gs_Value(gsCompany)

    '        gspStr = "sp_list_SCDTLCTN_SHM00002 '" & cboCoCde.Text & "','" & txtOrdNo.Text & "','" & txtOrdSeq.Text & "'"
    '        rtnLong = execute_SQLStatement(gspStr, rs_SHDTLCTN, rtnStr)

    '        If rtnLong <> RC_SUCCESS Then
    '            MsgBox("Error on loading txtNoteNoKeyPress sp_select_SHIPGHDR :" & rtnStr)
    '            Exit Function
    '        End If

    '        'If 1 = 1 Then
    '        'End If

    '        If rs_SHDTLCTN.Tables("RESULT").Rows.Count <= 0 Then

    '            'Marco Added for fixing global company code problem at 20040108
    '            gsCompany = Trim(cboCoCde.Text)
    '            Call Update_gs_Value(gsCompany)

    '            gspStr = "sp_list_SCDTLCTN_SHM00002_2 '" & cboCoCde.Text & "','" & txtOrdNo.Text & "','" & txtOrdSeq.Text & "'"
    '            rtnLong = execute_SQLStatement(gspStr, rs_SHDTLCTN, rtnStr)

    '            If rtnLong <> RC_SUCCESS Then
    '                MsgBox("Error on loading txtNoteNoKeyPress sp_select_SHIPGHDR :" & rtnStr)
    '                Exit Function
    '            End If
    '        End If

    '        '***************************************************
    '        '***** Get Shipping Detail record End  *************
    '        '***************************************************


    '        Dim Flag_inRange As Boolean
    '        Dim Flag_EachRow As Boolean

    '        Dim msg As String

    '        Flag_EachRow = False
    '        Flag_inRange = False
    '        msg = ""

    '        If rs_SCDTLCTN.Tables("RESULT").Rows.Count <= 0 Then
    '            Flag_inRange = True
    '            SHCartonSC = True
    '            Exit Function
    '        End If

    '        For INDEX3 As Integer = 0 To rs_SCDTLCTN.Tables("RESULT").Rows.Count - 1
    '            If rs_SCDTLCTN.Tables("RESULT").Rows(INDEX3).Item("sdc_from") <= CLng(txtCtnStr.Text) And _
    '                rs_SCDTLCTN.Tables("RESULT").Rows(INDEX3).Item("sdc_to") >= CLng(txtCtnEnd.Text) Then
    '                Flag_inRange = True
    '            End If
    '        Next

    '        Flag_EachRow = Flag_inRange

    '        If Not Flag_EachRow Then
    '            msg = "Carton Seq. don't match with SC Carton Seq. OK?" + Chr(13) + "========================================" + Chr(13) + Chr(13)
    '            For INDEX3 As Integer = 0 To rs_SCDTLCTN.Tables("RESULT").Rows.Count - 1

    '                For index7 As Integer = 1 To 20 - Len(Str(rs_SCDTLCTN.Tables("RESULT").Rows(INDEX3).Item("sdc_from")))
    '                    msg = msg + " "
    '                Next
    '                msg = msg _
    '                   + Str(rs_SCDTLCTN.Tables("RESULT").Rows(INDEX3).Item("sdc_from")) _
    '                + "                   to "

    '                For index7 As Integer = 1 To 20 - Len(Str(rs_SCDTLCTN.Tables("RESULT").Rows(INDEX3).Item("sdc_to")))
    '                    msg = msg + " "
    '                Next

    '                msg = msg _
    '                + Str(rs_SCDTLCTN.Tables("RESULT").Rows(INDEX3).Item("sdc_to")) _
    '                + Chr(13)

    '            Next
    '        End If

    '        If Not Flag_EachRow Then
    '            If MsgBox(msg, vbYesNo, "System Message") = vbYes Then
    '                SHCartonSC = True
    '            Else
    '                SHCartonSC = False
    '            End If
    '        Else
    '            SHCartonSC = True
    '        End If
    '    End Function


    '    Private Sub cboCus1no_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCus1No.KeyUp
    '        Call auto_search_combo(cboCus1No, e.KeyCode)

    '    End Sub


    '    Private Sub cboCus1No_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus1No.SelectedIndexChanged
    '        Call cboCus1NoClick()
    '        Recordstatus = True

    '    End Sub

    '    Private Sub cboCus1NoClick()

    '        If cboCus1No.Text <> "" And Validate() = True Then
    '            cboCus2No.Items.Clear()
    '            cboCus2No.Text = ""
    '            If InStr(cboCus1No.Text, " - ") - 1 >= 0 Then
    '                dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno = " & "'" & Microsoft.VisualBasic.Left(cboCus1No.Text, InStr(cboCus1No.Text, " - ") - 1) & "'")
    '            End If

    '            '*** Secondary Customer for Primary Customer
    '            '' Cursor = Cursors.WaitCursor
    '            gsCompany = Trim(cboCoCde.Text)
    '            Call Update_gs_Value(gsCompany)


    '            gspStr = "sp_list_CUBASINF_SHM00002_1 '" & cboCoCde.Text & "','" & "S" & "'"
    '            rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_S, rtnStr)
    '            gspStr = ""

    '            '' Cursor = Cursors.Default
    '            If rtnLong <> RC_SUCCESS Then
    '                MsgBox("Error on loading cboCus1NoClick sp_select_CUBASINF_Q 2 :" & rtnStr)
    '                '' Cursor = Cursors.Default
    '                Exit Sub
    '            End If

    '            If rs_CUBASINF_S.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
    '                cboCus2No.Enabled = False
    '            Else
    '                cboCus2No.Enabled = True
    '                cboCus2No.Items.Clear()
    '                cboCus2No.Text = ""

    '                'dr = rs_CUBASINF_S.Tables("RESULT").Select("csc_seccus >= 60000")
    '                dr = rs_CUBASINF_S.Tables("RESULT").Select("csc_prmcus = '" + Split(cboCus1No.Text, " - ")(0) + "'")


    '                If Not dr Is Nothing Then
    '                    'possible bug ?
    '                    'If dr.Length > 1 Then
    '                    If dr.Length > 0 Then
    '                        For index As Integer = 0 To dr.Length - 1
    '                            cboCus2No.Items.Add(dr(index)("csc_seccus").ToString + " - " + dr(index)("cbi_cussna").ToString)
    '                        Next
    '                    End If
    '                End If
    '            End If
    '        End If

    '    End Sub

    '    Private Sub cboBilAdr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPayTrm.Click

    '        'If rs_CUCNTINF.Tables("RESULT") Is Nothing Then Exit Sub
    '        'If rs_CUCNTINF.Tables("RESULT").Rows.Count <= 0 Then Exit Sub

    '        'txtBilAdr.Text = cboBilAdr.Text

    '        'dr = rs_CUCNTINF.Tables("RESULT").Select("cci_cntadr = '" + Replace(txtBilAdr.Text, "'", "''") + "'")

    '        'If Not dr Is Nothing Then
    '        '    If dr.Length > 0 Then

    '        '        txtBilStt.Text = dr(0)("cci_cntstt")
    '        '        Call display_combo(dr(0)("cci_cntcty"), cboBilCty)
    '        '        txtBilZip.Text = dr(0)("cci_cntpst")
    '        '    Else
    '        '        txtBilStt.Text = ""
    '        '        cboBilCty.SelectedIndex = 0
    '        '        txtBilZip.Text = ""

    '        '    End If
    '        'Else
    '        '    MsgBox("There is no function, please contact EDP or System Administrator.")
    '        '    Exit Sub
    '        'End If

    '        ''rs_CUCNTINF.MoveFirst()
    '        ''rs_CUCNTINF.Find("cci_cntadr = '" + Replace(txtBilAdr.Text, "'", "''") + "'")
    '        ''If rs_CUCNTINF.EOF Then
    '        ''    txtBilStt.Text = ""
    '        ''    cboBilCty.selectedindex = 0
    '        ''    txtBilZip.Text = ""
    '        ''Else
    '        ''    txtBilStt.Text = rs_CUCNTINF("cci_cntstt")
    '        ''    Call DisplayCombo(cboBilCty, rs_CUCNTINF("cci_cntcty"))
    '        ''    txtBilZip.Text = rs_CUCNTINF("cci_cntpst")
    '        ''End If

    '    End Sub

    '    Private Sub cboBilAdr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPayTrm.GotFocus

    '        If cboCus1No.Text = "" Then Exit Sub

    '        gsCompany = Trim(cboCoCde.Text)
    '        Call Update_gs_Value(gsCompany)

    '        gspStr = "sp_list_CUCNTINF_SHM00002 '" & cboCoCde.Text & "','" & cboCus1No.Text & "','" & "B" & "'"
    '        rtnLong = execute_SQLStatement(gspStr, rs_CUCNTINF, rtnStr)
    '        gspStr = ""

    '        If rtnLong <> RC_SUCCESS Then
    '            MsgBox("Error on loading   cboBilAdr_GotFocus :" & rtnStr)
    '            Exit Sub
    '        End If

    '        cboPayTrm.Items.Clear()


    '        If rs_CUCNTINF.Tables("RESULT").Rows.Count > 0 Then
    '            For index As Integer = 0 To rs_CUCNTINF.Tables("RESULT").Rows.Count - 1
    '                cboPayTrm.Items.Add(rs_CUCNTINF.Tables("RESULT").Rows(index)("cci_cntadr"))
    '            Next
    '        End If

    '    End Sub

    '    Private Sub cboBilAdr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPayTrm.SelectedIndexChanged

    '        If rs_CUCNTINF.Tables("RESULT") Is Nothing Then Exit Sub
    '        If rs_CUCNTINF.Tables("RESULT").Rows.Count <= 0 Then Exit Sub

    '        txtRmk.Text = cboPayTrm.Text

    '        dr = rs_CUCNTINF.Tables("RESULT").Select("cci_cntadr = '" + Replace(txtRmk.Text, "'", "''") + "'")

    '        If Not dr Is Nothing Then
    '            If dr.Length > 0 Then

    '                txtTtlUnt.Text = dr(0)("cci_cntstt")
    '                Call display_combo(dr(0)("cci_cntcty"), cboBilCty)
    '                txtBilZip.Text = dr(0)("cci_cntpst")
    '            Else
    '                txtTtlUnt.Text = ""
    '                cboBilCty.SelectedIndex = 0
    '                txtBilZip.Text = ""

    '            End If
    '        Else
    '            MsgBox("There is no function, please contact EDP or System Administrator.")
    '            Exit Sub
    '        End If

    '        'rs_CUCNTINF.MoveFirst()
    '        'rs_CUCNTINF.Find("cci_cntadr = '" + Replace(txtBilAdr.Text, "'", "''") + "'")
    '        'If rs_CUCNTINF.EOF Then
    '        '    txtBilStt.Text = ""
    '        '    cboBilCty.selectedindex = 0
    '        '    txtBilZip.Text = ""
    '        'Else
    '        '    txtBilStt.Text = rs_CUCNTINF("cci_cntstt")
    '        '    Call DisplayCombo(cboBilCty, rs_CUCNTINF("cci_cntcty"))
    '        '    txtBilZip.Text = rs_CUCNTINF("cci_cntpst")
    '        'End If

    '    End Sub

    '    Private Sub cboCoCde_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCoCde.Click
    '        Call cboCoCdeClick()

    '    End Sub

    '    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
    '        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    '    End Sub

    '    Private Sub cboCoCdeClick()
    '        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    '    End Sub

    '    Private Sub chkApprove_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    End Sub

    '    Private Sub cboBilCty_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '        Call auto_search_combo(cboBilCty, e.KeyCode)

    '    End Sub

    '    Private Sub cboBilCty_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    End Sub

    '    Private Sub cmdPickDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPickDate.Click

    '        If GetCtrlValue(cboCDStatus) = "REL" Or GetCtrlValue(cboCDStatus) = "CLO" Then Exit Sub

    '        If Trim(txtRefNo.Text) = "" Then
    '            '            mvwSlnOnb = Format(Today.Date, "MM/dd/yyyy")
    '            mvwSlnOnb.SetDate(Format(Today.Date, "MM/dd/yyyy"))
    '        Else
    '            mvwSlnOnb.SetDate(txtSlnOnb.Text)
    '            '            mvwSlnOnb = txtSlnOnb.Text
    '        End If

    '        If mvwSlnOnb.Visible = False Then
    '            mvwSlnOnb.Visible = True
    '        Else
    '            mvwSlnOnb.Visible = False
    '        End If



    '    End Sub

    '    Private Function GetCtrlValue(ByVal Ctrl As Control) As String
    '        If TypeOf Ctrl Is ComboBox Then
    '            If Ctrl.Text <> "" Then
    '                If UBound(Split(Ctrl.Text, " - ")) > 0 Then
    '                    GetCtrlValue = Split(Ctrl.Text, " - ")(0)
    '                Else
    '                    GetCtrlValue = Ctrl.Text
    '                End If
    '            Else
    '                GetCtrlValue = ""
    '            End If
    '        End If
    '    End Function

    '    Private Sub mvwSlnOnb_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mvwSlnOnb.DateChanged
    '    End Sub

    '    Private Sub mvwSlnOnb_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mvwSlnOnb.DateSelected
    '        If txtIssDat.Text.Trim = "" Then
    '            txtIssDat.Text = Format(Date.Today, "MM/dd/yyyy").ToString
    '        End If

    '        If DateDiff("d", mvwSlnOnb.SelectionStart, txtIssDat.Text) > 15 Or DateDiff("d", mvwSlnOnb.SelectionStart, txtIssDat.Text) < -30 Then
    '            MsgBox("Invalid Sailing on/abt (ETD), valid date should within 15 days before issue date to 30 days after issue date.")
    '            If Add_flag = True Then
    '                txtRefNo.Text = ""
    '            Else
    '                If Not rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
    '                    If rs_SHCBNHDR.Tables("RESULT").Rows.Count > 0 Then
    '                        txtRefNo.Text = rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hnh_slnonb")
    '                    End If
    '                End If
    '            End If
    '        Else
    '            txtSlnOnb.Text = mvwSlnOnb.SelectionStart

    '        End If

    '        mvwSlnOnb.Visible = False


    '    End Sub

    '    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click

    '        Dim frmSYM00018 As New SYM00018


    '        '20130909  
    '        gsCompany = Trim(cboCoCde.Text)
    '        Call Update_gs_Value(gsCompany)


    '        frmSYM00018.keyName = txtNoteNo.Name
    '        frmSYM00018.strModule = "SH"

    '        frmSYM00018.show_frmSYM00018(Me)




    '    End Sub

    '    Private Sub chkDel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 
    '        '''
    '    End Sub

    '    Private Sub chkDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) 
    '        'If not_to_delete_All() = True Then
    '        '    MsgBox("Cannot delete all details line records.")
    '        '    Exit Sub
    '        'End If


    '        If rs_SHCBNDTL.Tables("RESULT").Rows.Count > 1 Then
    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("Del") = "Y"
    '        Else
    '            rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("Del") = "N"
    '        End If
    '        Recordstatus = True

    '        'Call DeleteClickCheck()

    '    End Sub

    '    Private Sub chkDel_ClientSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) 

    '    End Sub

    '    Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelRow.Click
    '        '''
    '        Dim newseq As Integer
    '        If btcSHM00002.SelectedIndex <> 1 Then
    '            MsgBox("Please delete row in detail/summary page!")
    '            Exit Sub
    '        End If

    '        If rs_SHCBNDTL.Tables("RESULT") Is Nothing Then
    '            Exit Sub
    '        End If

    '        If rs_SHCBNDTL.Tables("RESULT").Rows.Count = 0 Then
    '            Exit Sub
    '        End If

    '        If rs_SHCBNDTL.Tables("RESULT").Rows.Count = 1 Then
    '            MsgBox("This Claim  just has one detail line record only, cannot delete.")
    '            Exit Sub
    '        End If

    '        If rs_SHCBNDTL.Tables("RESULT").Rows.Count > ReadingIndex Then
    '            If chkDel.Checked = False Then
    '                chkDel.Checked = True
    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_Del") = "Y"
    '                '                Call Delete_itm_from_dtl(ReadingIndex)
    '            Else
    '                chkDel.Checked = False
    '                rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex)("hnd_Del") = "N"
    '                '               Call UNDelete_itm_from_dtl(ReadingIndex)
    '            End If
    '        End If
    '        Recordstatus = True
    '        '''Call DeleteClickCheck()
    '        newseq = rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Item("hnd_shpseq")
    '        Call display_Detail(newseq)


    '    End Sub

    '    Private Sub display_grdShpSum()

    '        'type
    '        'A - All
    '        'F - Functional
    '        'P - Pricing
    '        'T - Sample and TO
    '        'S - Summary

    '        If rs_SHCBNDTL.Tables.Count = 0 Then
    '            Exit Sub
    '        End If

    '        grdShpSum.RowHeadersWidth = 18
    '        grdShpSum.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
    '        grdShpSum.ColumnHeadersHeight = 18
    '        grdShpSum.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    '        grdShpSum.AllowUserToResizeColumns = True
    '        grdShpSum.AllowUserToResizeRows = False
    '        grdShpSum.RowTemplate.Height = 18

    '        grdShpSum.DataSource = rs_SHCBNDTL.Tables("RESULT").DefaultView



    '        Dim i As Integer
    '        '        grdShpSum.Columns(grdShpSum_Del).Frozen = False

    '        i = 0 '0
    '        grdShpSum_Del = i
    '        grdShpSum.Columns(i).HeaderText = "Del"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_mode = i
    '        grdShpSum.Columns(i).HeaderText = ""
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = False
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_cocde = i
    '        grdShpSum.Columns(i).HeaderText = "Co. "
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = False
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_shpno = i
    '        grdShpSum.Columns(i).HeaderText = "Ship No."
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = False
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_shpseq = i
    '        grdShpSum.Columns(i).HeaderText = "Seq"
    '        grdShpSum.Columns(i).Width = 375 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_ctrcfs = i
    '        grdShpSum.Columns(i).HeaderText = "Invoice NO."
    '        grdShpSum.Columns(i).Width = 1000 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_sealno = i
    '        grdShpSum.Columns(i).HeaderText = "Ctr Size"
    '        grdShpSum.Columns(i).Width = 650 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_ctrsiz = i
    '        grdShpSum.Columns(i).HeaderText = "Container No."
    '        grdShpSum.Columns(i).Width = 1250 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_pckrmk = i
    '        grdShpSum.Columns(i).HeaderText = "Pack Rmk"
    '        grdShpSum.Columns(i).Width = 1100 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_jobno = i
    '        grdShpSum.Columns(i).HeaderText = "Job No."
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_ordno = i
    '        grdShpSum.Columns(i).HeaderText = "Ord No."
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_ordseq = i
    '        grdShpSum.Columns(i).HeaderText = "Ord Seq"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_cuspo = i
    '        grdShpSum.Columns(i).HeaderText = "Cus PO"
    '        grdShpSum.Columns(i).Width = 1040 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_cusitm = i
    '        grdShpSum.Columns(i).HeaderText = "Cus Item No."
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_cussku = i
    '        grdShpSum.Columns(i).HeaderText = "Cus SKU"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_itmno = i
    '        grdShpSum.Columns(i).HeaderText = "Item No."
    '        grdShpSum.Columns(i).Width = 1350 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_itmtyp = i
    '        grdShpSum.Columns(i).HeaderText = "Item Type"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_itmdsc = i
    '        grdShpSum.Columns(i).HeaderText = "Item Dsc"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_colcde = i
    '        grdShpSum.Columns(i).HeaderText = "Color Code"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_cuscol = i
    '        grdShpSum.Columns(i).HeaderText = "Cus Col"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_coldsc = i
    '        grdShpSum.Columns(i).HeaderText = ""
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = False
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_alsitmno = i
    '        grdShpSum.Columns(i).HeaderText = "Alias Item No."
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_alscolcde = i
    '        grdShpSum.Columns(i).HeaderText = ""
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = False
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_shpqty = i
    '        grdShpSum.Columns(i).HeaderText = "Shipped QTY"
    '        grdShpSum.Columns(i).Width = 1130 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_untcde = i
    '        grdShpSum.Columns(i).HeaderText = "UM"
    '        grdShpSum.Columns(i).Width = 410 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_ctnstr = i
    '        grdShpSum.Columns(i).HeaderText = "Start Ctr"
    '        grdShpSum.Columns(i).Width = 700 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_ctnend = i
    '        grdShpSum.Columns(i).HeaderText = "End Ctr"
    '        grdShpSum.Columns(i).Width = 700 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_inrctn = i
    '        grdShpSum.Columns(i).HeaderText = "Inner Ctn"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_mtrctn = i
    '        grdShpSum.Columns(i).HeaderText = "Master Ctn"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_vol = i
    '        grdShpSum.Columns(i).HeaderText = "Vol"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_mtrdcm = i
    '        grdShpSum.Columns(i).HeaderText = "Master D cm"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_mtrwcm = i
    '        grdShpSum.Columns(i).HeaderText = "Master W cm"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_mtrhcm = i
    '        grdShpSum.Columns(i).HeaderText = "Master H cm"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_actvol = i
    '        grdShpSum.Columns(i).HeaderText = "Actual Vol"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_grswgt = i
    '        grdShpSum.Columns(i).HeaderText = "Gross Weight"
    '        grdShpSum.Columns(i).Width = 1010 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_netwgt = i
    '        grdShpSum.Columns(i).HeaderText = "Net Weight"
    '        grdShpSum.Columns(i).Width = 1005 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_itmshm = i
    '        grdShpSum.Columns(i).HeaderText = "Item SHM"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_cmprmk = i
    '        grdShpSum.Columns(i).HeaderText = "CMP RMK"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_mannam = i
    '        grdShpSum.Columns(i).HeaderText = "Name"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_manadr = i
    '        grdShpSum.Columns(i).HeaderText = "Address"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_ttlvol = i
    '        grdShpSum.Columns(i).HeaderText = "Total Vol"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_ttlnet = i
    '        grdShpSum.Columns(i).HeaderText = "Total Net"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_ttlgrs = i
    '        grdShpSum.Columns(i).HeaderText = "Total Gross Weight"
    '        grdShpSum.Columns(i).Width = 1500 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_ttlctn = i
    '        grdShpSum.Columns(i).HeaderText = "Ttl No of Ctr"
    '        grdShpSum.Columns(i).Width = 1000 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_untsel = i
    '        grdShpSum.Columns(i).HeaderText = "Currency"
    '        grdShpSum.Columns(i).Width = 1005 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_selprc = i
    '        grdShpSum.Columns(i).HeaderText = "Unit Price"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_untamt = i
    '        grdShpSum.Columns(i).HeaderText = "Amount Currency"
    '        grdShpSum.Columns(i).Width = 1400 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_ttlamt = i
    '        grdShpSum.Columns(i).HeaderText = "Total Amount"
    '        grdShpSum.Columns(i).Width = 1100 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_invno = i
    '        grdShpSum.Columns(i).HeaderText = "Invoice NO."
    '        grdShpSum.Columns(i).Width = 1000 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_prctrm = i
    '        grdShpSum.Columns(i).HeaderText = "Price Terms"
    '        grdShpSum.Columns(i).Width = 1005 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_paytrm = i
    '        grdShpSum.Columns(i).HeaderText = "Payment Terms"
    '        grdShpSum.Columns(i).Width = 2115 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_purord = i
    '        grdShpSum.Columns(i).HeaderText = "PO"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_purseq = i
    '        grdShpSum.Columns(i).HeaderText = "PO Seq"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_venno = i
    '        grdShpSum.Columns(i).HeaderText = "Ven No."
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_cusven = i
    '        grdShpSum.Columns(i).HeaderText = "Cus Ven"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_conftr = i
    '        grdShpSum.Columns(i).HeaderText = "Con. Factor"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_contopc = i
    '        grdShpSum.Columns(i).HeaderText = "Con. to PC"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_pcprc = i
    '        grdShpSum.Columns(i).HeaderText = "PC Price"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_custum = i
    '        grdShpSum.Columns(i).HeaderText = "Cus UM"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_cusstyno = i
    '        grdShpSum.Columns(i).HeaderText = "Cus Style No"
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = True
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_creusr = i
    '        grdShpSum.Columns(i).HeaderText = ""
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = False
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_updusr = i
    '        grdShpSum.Columns(i).HeaderText = ""
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = False
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_credat = i
    '        grdShpSum.Columns(i).HeaderText = ""
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = False
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_upddat = i
    '        grdShpSum.Columns(i).HeaderText = ""
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = False
    '        grdShpSum.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdShpSum_hnd_timstp = i
    '        grdShpSum.Columns(i).HeaderText = ""
    '        grdShpSum.Columns(i).Width = 900 / 13
    '        grdShpSum.Columns(i).Visible = False
    '        grdShpSum.Columns(i).ReadOnly = True

    '        ''))!reset readonly
    '        '        Call setStatus_grdShpSum(sMode)
    '    End Sub



    '    Private Sub display_grdPremium()

    '        'type
    '        'A - All
    '        'F - Functional
    '        'P - Pricing
    '        'T - Sample and TO
    '        'S - Summary

    '        If rs_SHDISPRM_P.Tables.Count = 0 Then
    '            Exit Sub
    '        End If

    '        grdPremium.RowHeadersWidth = 18
    '        grdPremium.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
    '        grdPremium.ColumnHeadersHeight = 18
    '        grdPremium.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    '        grdPremium.AllowUserToResizeColumns = True
    '        grdPremium.AllowUserToResizeRows = False
    '        grdPremium.RowTemplate.Height = 18

    '        grdPremium.DataSource = rs_SHDISPRM_P.Tables("RESULT").DefaultView



    '        Dim i As Integer
    '        '        grdPremium.Columns(grdPremium_Del).Frozen = False

    '        i = 0 '0
    '        grdPremium_DEL = i
    '        grdPremium.Columns(i).HeaderText = "DEL"
    '        grdPremium.Columns(i).Width = 400 / 13
    '        grdPremium.Columns(i).Visible = True
    '        grdPremium.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdPremium_hdp_cde = i
    '        grdPremium.Columns(i).HeaderText = "Code"
    '        grdPremium.Columns(i).Width = 4000 / 13
    '        grdPremium.Columns(i).Visible = True
    '        grdPremium.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdPremium_hdp_dsc = i
    '        grdPremium.Columns(i).HeaderText = "Description"
    '        grdPremium.Columns(i).Width = 4000 / 13
    '        grdPremium.Columns(i).Visible = True
    '        grdPremium.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdPremium_hdp_pctamt = i
    '        grdPremium.Columns(i).HeaderText = "Percentage/Amount"
    '        grdPremium.Columns(i).Width = 1800 / 13
    '        grdPremium.Columns(i).Visible = True
    '        grdPremium.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdPremium_hdp_pct = i
    '        grdPremium.Columns(i).HeaderText = "Percentage %"
    '        grdPremium.Columns(i).Width = 1300 / 13
    '        grdPremium.Columns(i).Visible = True
    '        grdPremium.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdPremium_hdp_amt = i
    '        grdPremium.Columns(i).HeaderText = "Amount"
    '        grdPremium.Columns(i).Width = 1300 / 13
    '        grdPremium.Columns(i).Visible = True
    '        grdPremium.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdPremium_hdp_cocde = i
    '        grdPremium.Columns(i).HeaderText = ""
    '        grdPremium.Columns(i).Width = 900 / 13
    '        grdPremium.Columns(i).Visible = False
    '        grdPremium.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdPremium_hdp_shpno = i
    '        grdPremium.Columns(i).HeaderText = ""
    '        grdPremium.Columns(i).Width = 900 / 13
    '        grdPremium.Columns(i).Visible = False
    '        grdPremium.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdPremium_hdp_invno = i
    '        grdPremium.Columns(i).HeaderText = ""
    '        grdPremium.Columns(i).Width = 900 / 13
    '        grdPremium.Columns(i).Visible = False
    '        grdPremium.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdPremium_hdp_type = i
    '        grdPremium.Columns(i).HeaderText = ""
    '        grdPremium.Columns(i).Width = 900 / 13
    '        grdPremium.Columns(i).Visible = False
    '        grdPremium.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdPremium_hdp_seqno = i
    '        grdPremium.Columns(i).HeaderText = ""
    '        grdPremium.Columns(i).Width = 900 / 13
    '        grdPremium.Columns(i).Visible = False
    '        grdPremium.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdPremium_hdp_creusr = i
    '        grdPremium.Columns(i).HeaderText = ""
    '        grdPremium.Columns(i).Width = 900 / 13
    '        grdPremium.Columns(i).Visible = False
    '        grdPremium.Columns(i).ReadOnly = True


    '        ''))!reset readonly
    '        '        Call setStatus_grdPremium(sMode)
    '    End Sub


    '    Private Sub display_grdDiscount()

    '        'type
    '        'A - All
    '        'F - Functional
    '        'P - Pricing
    '        'T - Sample and TO
    '        'S - Summary

    '        If rs_SHDISPRM_D.Tables.Count = 0 Then
    '            Exit Sub
    '        End If

    '        grdDiscount.RowHeadersWidth = 18
    '        grdDiscount.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
    '        grdDiscount.ColumnHeadersHeight = 18
    '        grdDiscount.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    '        grdDiscount.AllowUserToResizeColumns = True
    '        grdDiscount.AllowUserToResizeRows = False
    '        grdDiscount.RowTemplate.Height = 18

    '        grdDiscount.DataSource = rs_SHDISPRM_D.Tables("RESULT").DefaultView



    '        Dim i As Integer
    '        '        grdDiscount.Columns(grdDiscount_Del).Frozen = False

    '        i = 0 '0
    '        grdDiscount_DEL = i
    '        grdDiscount.Columns(i).HeaderText = "DEL"
    '        grdDiscount.Columns(i).Width = 400 / 13
    '        grdDiscount.Columns(i).Visible = True
    '        grdDiscount.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdDiscount_hdp_cde = i
    '        grdDiscount.Columns(i).HeaderText = "Code"
    '        grdDiscount.Columns(i).Width = 400 / 13
    '        grdDiscount.Columns(i).Visible = True
    '        grdDiscount.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdDiscount_hdp_dsc = i
    '        grdDiscount.Columns(i).HeaderText = "Description"
    '        grdDiscount.Columns(i).Width = 4000 / 13
    '        grdDiscount.Columns(i).Visible = True
    '        grdDiscount.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdDiscount_hdp_pctamt = i
    '        grdDiscount.Columns(i).HeaderText = "Percentage/Amount"
    '        grdDiscount.Columns(i).Width = 1800 / 13
    '        grdDiscount.Columns(i).Visible = True
    '        grdDiscount.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdDiscount_hdp_pct = i
    '        grdDiscount.Columns(i).HeaderText = "Percentage %"
    '        grdDiscount.Columns(i).Width = 1300 / 13
    '        grdDiscount.Columns(i).Visible = True
    '        grdDiscount.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdDiscount_hdp_amt = i
    '        grdDiscount.Columns(i).HeaderText = "Amount"
    '        grdDiscount.Columns(i).Width = 1300 / 13
    '        grdDiscount.Columns(i).Visible = True
    '        grdDiscount.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdDiscount_hdp_cocde = i
    '        grdDiscount.Columns(i).HeaderText = ""
    '        grdDiscount.Columns(i).Width = 900 / 13
    '        grdDiscount.Columns(i).Visible = False
    '        grdDiscount.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdDiscount_hdp_shpno = i
    '        grdDiscount.Columns(i).HeaderText = ""
    '        grdDiscount.Columns(i).Width = 900 / 13
    '        grdDiscount.Columns(i).Visible = False
    '        grdDiscount.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdDiscount_hdp_invno = i
    '        grdDiscount.Columns(i).HeaderText = ""
    '        grdDiscount.Columns(i).Width = 900 / 13
    '        grdDiscount.Columns(i).Visible = False
    '        grdDiscount.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdDiscount_hdp_type = i
    '        grdDiscount.Columns(i).HeaderText = ""
    '        grdDiscount.Columns(i).Width = 900 / 13
    '        grdDiscount.Columns(i).Visible = False
    '        grdDiscount.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdDiscount_hdp_seqno = i
    '        grdDiscount.Columns(i).HeaderText = ""
    '        grdDiscount.Columns(i).Width = 900 / 13
    '        grdDiscount.Columns(i).Visible = False
    '        grdDiscount.Columns(i).ReadOnly = True
    '        i = i + 1
    '        grdDiscount_hdp_creusr = i
    '        grdDiscount.Columns(i).HeaderText = ""
    '        grdDiscount.Columns(i).Width = 900 / 13
    '        grdDiscount.Columns(i).Visible = False
    '        grdDiscount.Columns(i).ReadOnly = True


    '        ''))!reset readonly
    '        '        Call setStatus_grdDiscount(sMode)
    '    End Sub


    '    Private Sub grdDiscount_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDiscount.CellContentClick

    '    End Sub

    '    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    '    End Sub

    Private Sub CmdDtlNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDtlNext.Click
        Call Update_Dtl()

        If rs_SHCBNDTL.Tables("result").Rows.Count = 0 Then
            Exit Sub
        End If

        If rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*ADD*~" Then

            If Not chkSave() Then
                Exit Sub
            End If

            'Call Update_Dtl
        End If

        readingindex = readingindex + 1

        If readingindex <= rs_SHCBNDTL.Tables("result").Rows.Count - 1 Then
            Call DisplayDetail()
        Else
            readingindex = rs_SHCBNDTL.Tables("result").Rows.Count - 1
        End If
        ''''''''''''''''''''''''''''''''''''''19988

        If rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*ADD*~" Then
            chkUpd.Enabled = True
        Else
            chkUpd.Enabled = False
        End If



    End Sub

    Private Sub mmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAdd.Click
        Add_flag = True
        Call setStatus("Add")
        Call SetStatusBar("Add")
        txtRefNo.Focus()
        Cursor = Cursors.Default


    End Sub


    Private Sub fill_SHCBNHDR()

        If rs_SHCBNHDR.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
            rs_SHCBNHDR.Tables("RESULT").Rows.Add()
            rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hih_creusr") = "~*ADD*~"
        End If

        rs_SHCBNHDR.Tables("RESULT").Rows(0).Item("hih_cocde") = cboCoCde.Text.Trim

    End Sub

    Private Sub CAL_AMT()
        Dim rowFilter As String

        If rs_SHCBNDTL.Tables("result").Rows.Count > 0 Then

            rowFilter = "hnd_creusr <> '~*NEW*~' and hnd_creusr <> '~*DEL*~'"
            rs_SHCBNDTL.Tables("RESULT").DefaultView.RowFilter = rowFilter

            For index2 As Integer = 0 To rs_SHCBNDTL.Tables("RESULT").DefaultView.Count - 1
                TtlAmt = TtlAmt + rs_SHCBNDTL.Tables("RESULT").Rows(index2)("hnd_adjqty") * rs_SHCBNDTL.Tables("RESULT").Rows(index2)("hnd_adjprc")
            Next

        End If

    End Sub

    Private Sub cboSCNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSCNo.SelectedIndexChanged
        Dim flt As String
        If txtItmNo.Text <> "" And txtColCde.Text <> "" And Trim(cboPckInf.Text) <> "///0" And Trim(cboPckInf.Text) <> "" Then
            If rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*ADD*~" Then
                'DTL.Tables("result").Rows(readingindex)("
                'rs_SHIPGDTLO.Tables("result").DefaultView.rowFilter = "rs_SHIPGDTLO('hid_itmno') = txtItmNo.Text And "
                'rs_SHIPGDTLO.Tables("result").DefaultView.rowFilter = rs_SHIPGDTLO.Tables("result").DefaultView.rowFilter & "rs_SHIPGDTLO('hid_colcde') = txtColCde And "
                'rs_SHIPGDTLO.Tables("result").DefaultView.rowFilter = rs_SHIPGDTLO.Tables("result").DefaultView.rowFilter & "rs_SHIPGDTLO('hid_untcde') = Split(cboPckInf.Text, '/)(0) And "
                'rs_SHIPGDTLO.Tables("result").DefaultView.rowFilter = rs_SHIPGDTLO.Tables("result").DefaultView.rowFilter & "rs_SHIPGDTLO('hid_inrctn') = Split(cboPckInf.Text, '/')(1) And "
                'rs_SHIPGDTLO.Tables("result").DefaultView.rowFilter = rs_SHIPGDTLO.Tables("result").DefaultView.rowFilter & "rs_SHIPGDTLO('hid_mtrctn') = Split(cboPckInf.Text, '/)(2)"
                flt = "hid_itmno = '" & Trim(txtItmNo.Text) & "' And "
                flt = flt & "hid_colcde = '" & Trim(txtColCde.Text) & "' And "
                flt = flt & "hid_untcde = '" & Split(cboPckInf.Text, "/")(0) & "' And "
                flt = flt & "hid_inrctn = " & Split(cboPckInf.Text, "/")(1) & " And "
                flt = flt & "hid_mtrctn = " & Split(cboPckInf.Text, "/")(2)
                rs_SHIPGDTLO.Tables("result").DefaultView.RowFilter = flt

                If (rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_itmno") = rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_itmno") And _
                    rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_pckunt") = rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_untcde") And _
                    CDbl(Val(rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_inrctn"))) = rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_inrctn") And _
                    CDbl(Val(rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_mtrctn"))) = rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_mtrctn")) Or _
                    rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_itmno") = "" Then

                    'rs_SHIPGDTLO.Move(cboSCNo.SelectedIndex, 1)

                    Call DisplayShipDetail()
                    'Add for Check with SC no. first ***** by Lewis on 26/03/2003
                    If optCredit.Checked = True Then
                        If Math.Abs(CInt(txtAdjQty.Text.Trim)) > shpqty.Text Then
                            MsgBox("Credit quantity must be smaller than shipped quantity", vbInformation, "Warning")
                            txtAdjQty.Focus()
                        End If
                    Else
                        If Math.Abs(CInt(txtAdjQty.Text.Trim)) > ordqty.Text - shpqty.Text Then
                            MsgBox("Debit quantity must be smaller than Outstanding quantity", vbInformation, "Warning")
                            txtAdjQty.Focus()
                        End If

                    End If

                End If
                rs_SHIPGDTLO.Tables("result").DefaultView.RowFilter = ""
            End If
        End If

    End Sub

    Private Sub txtItmNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItmNo.LostFocus
        If chkDel.Checked = False Then

            TmpItmNo = ""
            If Trim(txtItmNo.Text) <> "" Then
                'cboPckInf.Enabled = False
                'Msg "M00312"
                'txtItmNo.SetFocus
                'Else
                rs_SHIPGDTLO.Tables("result").DefaultView.RowFilter = "hid_invno = '" & Trim(txtRefNo.Text) & "' and hid_itmno ='" & Trim(txtItmNo.Text) & "'"
                If rs_SHIPGDTLO.Tables("result").DefaultView.Count = 0 Then
                    cboPckInf.Enabled = False
                    MsgBox("item not found!")
                    txtItmNo.Focus()
                Else
                    If rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*ADD*~" Then
                        cboPckInf.Enabled = True
                    End If
                    TmpItmNo = txtItmNo.Text.Trim
                    Call fillcboPckInf()
                End If
            End If
        End If

    End Sub

    Private Sub txtItmNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmNo.TextChanged

    End Sub

    Private Sub Label18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtNoteNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoteNo.GotFocus
        Call HighlightText(txtNoteNo)

    End Sub

    Private Sub txtNoteNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoteNo.KeyPress
        If e.KeyChar = Chr(13) Then
            Call mmdFind_Click(sender, e)

            '    Timer1.Enabled = True
        End If
    End Sub


    Public Sub HighlightText(ByVal t As TextBox)
        t.SelectionStart = 0
        t.SelectionLength = Len(t.Text)

    End Sub

    Private Sub Timer1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Disposed
        Timer1.Enabled = False
        '   Call cmdFind_Click(sender, e)


    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    End Sub


    Private Sub QueryShipInfo()
        Dim S As String
        Dim rs As DataSet

        txtRefNo.Text = UCase(txtRefNo.Text)

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_SHPCDHDR '" & gsCompany & "','" & Trim(txtRefNo.Text) & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SHPCDHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdAddClick sp_select_QUOTNHDR :" & rtnStr)
            Exit Sub
        End If
        For i As Integer = 0 To rs_SHPCDHDR.Tables("RESULT").Columns.Count - 1
            rs_SHPCDHDR.Tables("RESULT").Columns(i).ReadOnly = False
        Next i


        gspStr = "sp_list_SHIPGDTLO '" & cboCoCde.Text & "','" & Trim(txtRefNo.Text) & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SHIPGDTLO, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtQutNoKeyPress sp_select_QUOTNHDR :" & rtnStr)
            Exit Sub
        End If


        gspStr = "sp_select_invoutqty '" & cboCoCde.Text & "','" & Trim(txtRefNo.Text) & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_invoutqty, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtQutNoKeyPress sp_select_QUOTNHDR :" & rtnStr)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor

        '''''''  rs = objBSGate.Enquire(gsConnStr, "sp_general", S)
        'temp

        Cursor = Cursors.Default



        If rs_SHPCDHDR.Tables("result").Rows.Count = 0 Then
            Call clearHeader()
            If Not start Then
                MsgBox("record not found!")
            End If
            start = False
        ElseIf rs_SHPCDHDR.Tables("result").Rows(0)("hih_shpsts") <> "REL" Then
            MsgBox(Trim(txtRefNo.Text) + " Invoice no. not yet release!") 'Msg ("M00360") 'modified by Johnson on 4-2-02
        Else
            DisplayInvHeader()
        End If

    End Sub


    Private Sub clearHeader()

        chkSample.Checked = False

        txtPrmCus.Text = ""

        txtSecCus.Text = ""

        txtBilAdr.Text = ""

        Call display_combo("", cboBCty)

        txtBilstt.Text = ""
        txtBilZip.Text = ""


        Call display_combo("", cboPrcTrm)
        Call display_combo("", cboPayTrm)

        txtTtlUnt.Text = ""
        txtTtlAmt.Text = ""

        txtRmk.Text = ""


    End Sub


    Private Sub DisplayInvHeader()

        If rs_SHPCDHDR.Tables("result").Rows(0)("hih_smpshp") = "Y" Then
            chkSample.Checked = True
        Else
            chkSample.Checked = False
        End If

        rs_CUBASINF.Tables("result").DefaultView.RowFilter = "cbi_cusno ='" & rs_SHPCDHDR.Tables("result").Rows(0)("hih_cus1no") & "'"
        If rs_CUBASINF.Tables("result").DefaultView.Count <> 0 Then
            'rs_CUBASINF.MoveFirst()
            txtPrmCus.Text = rs_CUBASINF.Tables("result").DefaultView(0)("cbi_cusno") & " - " & rs_CUBASINF.Tables("result").DefaultView(0)("cbi_cussna")
        End If

        rs_CUBASINF.Tables("result").DefaultView.RowFilter = "cbi_cusno ='" & rs_SHPCDHDR.Tables("result").Rows(0)("hih_cus2no") & "'"
        If rs_CUBASINF.Tables("result").DefaultView.Count <> 0 Then
            '      rs_CUBASINF.MoveFirst()
            txtSecCus.Text = rs_CUBASINF.Tables("result").DefaultView(0)("cbi_cusno") & " - " & rs_CUBASINF.Tables("result").DefaultView(0)("cbi_cussna")
        End If


        txtBilAdr.Text = rs_SHPCDHDR.Tables("result").Rows(0)("hih_biladr")

        Call display_combo(rs_SHPCDHDR.Tables("result").Rows(0)("hih_bilcty"), cboBCty)

        txtBilstt.Text = rs_SHPCDHDR.Tables("result").Rows(0)("hih_bilstt")
        txtBilZip.Text = rs_SHPCDHDR.Tables("result").Rows(0)("hih_bilzip")


        Call display_combo(rs_SHPCDHDR.Tables("result").Rows(0)("hiv_prctrm"), cboPrcTrm)
        Call display_combo(rs_SHPCDHDR.Tables("result").Rows(0)("hiv_paytrm"), cboPayTrm)

        txtTtlUnt.Text = rs_SHPCDHDR.Tables("result").Rows(0)("hiv_untamt")
        If Add_flag Then
            txtTtlAmt.Text = rs_SHPCDHDR.Tables("result").Rows(0)("hiv_ttlamt")
        End If

        'txtRmk.Text = ""


    End Sub



    Private Sub DisplayDetail()
        If readingindex = -1 Then
            readingindex = 0
        End If
        '*******Kenny Add on 09-10-2002
        cboPckInf.Items.Clear()
        '        cboPckInf.Clear()
        If readingindex > rs_SHCBNDTL.Tables("result").Rows.Count - 1 Then
            Exit Sub
        End If
        If rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*ADD*~" Or rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*NEW*~" Then
            cboPckInf.Items.Add(rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_pckunt") & "/" & rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_inrctn") & "/" & rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_mtrctn") & "/" & rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_cft"))
        Else
            cboPckInf.Items.Add(rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_untcde") & "/" & rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_inrctn") & "/" & rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_mtrctn") & "/" & rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_vol"))
        End If


        cboPckInf.SelectedIndex = 0
        cboSCNo.Items.Clear()

        'Lester Wu 2004/08/26
        txtPO.Text = rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_purord")
        '-------------------------------------

        If Not IsDBNull(rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_ordno")) Then
            cboSCNo.Items.Add(rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_ordno"))
            txtSCNo.Text = rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_ordno")
            cboSCNo.Text = rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_ordno")
        End If

        txtSeq.Text = rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_seq")
        If rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_lnetyp") = "I" Then
            optItm.Checked = True
            optMsc.Checked = False
        Else
            optItm.Checked = False
            optMsc.Checked = True
        End If

        If optItm.Checked = True And (rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*ADD*~" Or rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*NEW*~") Then
            txtItmNo.Enabled = True
            txtColCde.Enabled = True
            ' add for disable update
            txtAdjQty.Enabled = True
            txtAdjPrc.Enabled = True
            txtDRmk.Enabled = True
            optItm.Enabled = True
            optMsc.Enabled = True
            '''''''''
        Else
            txtItmNo.Enabled = False
            txtColCde.Enabled = False
            cboPckInf.Enabled = False
            cboSCNo.Enabled = False
            ' add for disable update
            txtAdjQty.Enabled = False
            txtAdjPrc.Enabled = False
            txtDRmk.Enabled = False
            optItm.Enabled = False
            optMsc.Enabled = False
            '''''''''
        End If

        txtItmNo.Text = rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_itmno")
        txtItmDsc.Text = rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_itmdsc")
        txtColCde.Text = rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_colcde")



        txtColDsc.Text = rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_coldsc")
        txtCusItm.Text = rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_cusitm")
        txtCusSku.Text = rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_cussku")
        txtManNam.Text = rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_mannam")
        txtManAdr.Text = rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_manadr")

        '    txtUM.Text = rs_SHCBNdtl.tables("result").rows(readingindex)("hnd_pckunt")
        '    txtInr.Text = rs_SHCBNdtl.tables("result").rows(readingindex)("hnd_inrctn")
        '    txtMtr.Text = rs_SHCBNdtl.tables("result").rows(readingindex)("hnd_mtrctn")
        '    txtCBM.Text = rs_SHCBNdtl.tables("result").rows(readingindex)("hnd_cft")

        If optItm.Checked = True Then

            txtShpQty.Text = 0
            For index9 As Integer = 0 To rs_SHCBNDTL.Tables("result").Rows.Count - 1
                If UCase(rs_SHCBNDTL.Tables("result").Rows(index9)("hid_itmno").ToString.Trim) = UCase(txtItmNo.Text.Trim) Then
                    txtShpQty.Text = CInt(txtShpQty.Text) + IIf(IsDBNull(rs_SHCBNDTL.Tables("result").Rows(index9)("hid_shpqty")), 0, rs_SHCBNDTL.Tables("result").Rows(index9)("hid_shpqty"))
                End If
            Next
            '20150720
            'Ad By Lewis For Debug on 26/03/2003******

            txtCurCde2.Text = IIf(IsDBNull(rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_untsel")), "", rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_untsel"))
            txtCurCde3.Text = IIf(IsDBNull(rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_untamt")), "", rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_untamt"))

            txtSelPrc.Text = IIf(IsDBNull(rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_selprc")), 0, rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_selprc"))
            txtShpAmt.Text = IIf(IsDBNull(rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_ttlamt")), 0, rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_ttlamt"))

        End If



        txtCurCde4.Text = rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_curcde")
        txtCurCde5.Text = rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_curcde")

        txtAdjQty.Text = rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_adjqty")
        txtAdjPrc.Text = rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_adjprc")
        txtAdjAmt.Text = txtAdjQty.Text * txtAdjPrc.Text



        ordqty.Text = IIf(IsDBNull(rs_SHCBNDTL.Tables("result").Rows(readingindex)("sod_ordqty")), "0", rs_SHCBNDTL.Tables("result").Rows(readingindex)("sod_ordqty"))
        shpqty.Text = IIf(IsDBNull(rs_SHCBNDTL.Tables("result").Rows(readingindex)("sod_shpqty")), "0", rs_SHCBNDTL.Tables("result").Rows(readingindex)("sod_shpqty"))

        If rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_upd") = "Y" Then
            chkUpd.Checked = True
        Else
            chkUpd.Checked = False
        End If

        txtDRmk.Text = rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_rmk")

        If rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*DEL*~" Or rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*NEW*~" Then
            chkDel.Checked = True
        Else
            chkDel.Checked = False
        End If

        txtInvLne.Text = rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_invlne")

        If Not rs_invoutqty Is Nothing Then
            rs_invoutqty.Tables("result").DefaultView.RowFilter = "hnd_ordno ='" & txtSCNo.Text & "' and hnd_invlne = '" & txtInvLne.Text & "'"
            If rs_invoutqty.Tables("result").DefaultView.Count > 0 Then
                txtout.Text = IIf(IsDBNull(rs_invoutqty.Tables("result").DefaultView(0)("outqty")), 0, rs_invoutqty.Tables("result").DefaultView(0)("outqty"))
                txtdeb.Text = IIf(IsDBNull(rs_invoutqty.Tables("result").DefaultView(0)("debqty")), 0, rs_invoutqty.Tables("result").DefaultView(0)("debqty"))
                txtcre.Text = IIf(IsDBNull(rs_invoutqty.Tables("result").DefaultView(0)("creqty")), 0, rs_invoutqty.Tables("result").DefaultView(0)("creqty"))
            Else
                txtout.Text = "0"
                txtdeb.Text = "0"
                txtcre.Text = "0"
            End If
        End If
        ' Enable Delete Check Box ***** by Lewis on 25/03/2003
        chkDel.Enabled = True




        If readingindex = rs_SHCBNDTL.Tables("result").Rows.Count - 1 Then
            CmdDtlNext.Enabled = False
        Else
            CmdDtlNext.Enabled = True
        End If



        If readingindex = 0 Then
            CmdDtlPre.Enabled = False
        Else
            CmdDtlPre.Enabled = True
        End If



    End Sub


    Private Sub SetStatusBar(ByVal Mode As String)

        If Mode = "Init" Then
            '''''''''            StatusBar.Panels(1).Text = "Please Enter a Note No."
            'Add your codes here

        ElseIf Mode = "Add" Then
            ''''''''''''''''' StatusBar.Panels(1).Text = "Add New "
            'Add your codes here

        ElseIf Mode = "Updating" Then
            '''''''     StatusBar.Panels(1).Text = "Updating"
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


    Private Sub Update_Dtl()

        chkSave()

        If Not rs_SHCBNDTL.Tables("result").Rows.Count = 0 Then

            If optItm.Checked = True Then

                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_lnetyp") = "I"

                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_itmno") = txtItmNo.Text

                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_itmdsc") = txtItmDsc.Text

                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_colcde") = txtColCde.Text

                If Trim(cboPckInf.Text) <> "" Then

                    rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_pckunt") = Split(cboPckInf.Text, "/")(0)
                    rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_inrctn") = Split(cboPckInf.Text, "/")(1)
                    rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_mtrctn") = Split(cboPckInf.Text, "/")(2)
                    rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_cft") = IIf(Trim(Split(cboPckInf.Text, "/")(3)) = "", 0, Trim(Split(cboPckInf.Text, "/")(3)))

                Else

                    rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_pckunt") = ""
                    rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_inrctn") = ""
                    rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_mtrctn") = ""
                    rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_cft") = 0

                End If

                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_coldsc") = txtColDsc.Text
                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_cusitm") = txtCusItm.Text
                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_cussku") = txtCusSku.Text
                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_mannam") = txtManNam.Text
                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_manadr") = txtManAdr.Text

                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_curcde") = txtCurCde4.Text
                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_curcde") = txtCurCde5.Text


            Else

                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_lnetyp") = "M"

                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_itmno") = ""

                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_itmdsc") = ""

                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_colcde") = ""

                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_pckunt") = ""
                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_inrctn") = ""
                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_mtrctn") = ""
                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_cft") = 0

                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_coldsc") = ""
                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_cusitm") = ""
                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_cussku") = ""
                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_mannam") = ""
                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_manadr") = ""

                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_curcde") = ""
                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_curcde") = ""

            End If

            rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_adjprc") = IIf((IsNumeric(txtAdjPrc.Text) And txtAdjPrc.Text <> ""), txtAdjPrc.Text, 0)

            rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_adjqty") = IIf((IsNumeric(txtAdjQty.Text) And txtAdjQty.Text <> ""), CInt(txtAdjQty.Text), 0)


            rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_rmk") = txtDRmk.Text


            'rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_shpqty") = txtShpQty.Text
            '20150721

            rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_untsel") = txtCurCde2.Text

            rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_untamt") = txtCurCde3.Text

            rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_selprc") = txtSelPrc.Text
            rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_ttlamt") = txtShpAmt.Text
            rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_ordno") = cboSCNo.Text


            rs_SHCBNDTL.Tables("result").Rows(readingindex)("hid_purord") = txtPO.Text
            '----------------------------------------------
            rs_SHCBNDTL.Tables("result").Rows(readingindex)("sod_ordqty") = ordqty.Text
            rs_SHCBNDTL.Tables("result").Rows(readingindex)("sod_shpqty") = shpqty.Text


            If chkUpd.Checked = True Then
                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_upd") = "Y"
            Else
                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_upd") = "N"
            End If

            If Trim(txtInvLne.Text) <> "" Then
                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_invlne") = txtInvLne.Text
            End If

            ' rs_SHCBNDTL.Update()



        End If

    End Sub



    Private Sub DisplayShipDetail()

        If cboSCNo.Text <> "" Then

            txtItmDsc.Text = rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_itmdsc")

            txtColCde.Text = rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_colcde")

            txtColDsc.Text = rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_coldsc")
            txtCusItm.Text = rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_cusitm")
            txtCusSku.Text = rs_SHIPGDTLO.Tables("result").DefaultView(0)("sod_cussku")
            txtManNam.Text = rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_mannam")
            txtManAdr.Text = rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_manadr")

            txtShpQty.Text = rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_shpqty")
            txtCurCde2.Text = rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_untsel")
            txtCurCde3.Text = rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_untamt")

            txtCurCde4.Text = rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_untsel")
            txtCurCde5.Text = rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_untamt")

            txtSelPrc.Text = rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_selprc")
            txtShpAmt.Text = rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_ttlamt")
            'Lester Wu 2004/08/26
            '-------------------------------------------------
            txtAdjPrc.Text = txtSelPrc.Text
            txtPO.Text = rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_purord")
            '-------------------------------------------------

            txtSCNo.Text = rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_ordno")

            txtInvLne.Text = rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_ordseq")

            shpqty.Text = rs_SHIPGDTLO.Tables("result").DefaultView(0)("sod_shpqty")

            ordqty.Text = rs_SHIPGDTLO.Tables("result").DefaultView(0)("sod_ordqty")

            If Not rs_invoutqty Is Nothing Then
                rs_invoutqty.Tables("result").DefaultView.RowFilter = "hnd_ordno ='" & txtSCNo.Text & "' and hnd_invlne = '" & txtInvLne.Text & "'"
                If rs_invoutqty.Tables("result").DefaultView.Count > 0 Then
                    txtout.Text = IIf(IsDBNull(rs_invoutqty.Tables("result").DefaultView(0)("outqty")), 0, rs_invoutqty.Tables("result").DefaultView(0)("outqty"))
                    txtdeb.Text = IIf(IsDBNull(rs_invoutqty.Tables("result").DefaultView(0)("debqty")), 0, rs_invoutqty.Tables("result").DefaultView(0)("debqty"))
                    txtcre.Text = IIf(IsDBNull(rs_invoutqty.Tables("result").DefaultView(0)("creqty")), 0, rs_invoutqty.Tables("result").DefaultView(0)("creqty"))
                Else
                    txtout.Text = "0"
                    txtdeb.Text = "0"
                    txtcre.Text = "0"
                End If
            End If
        End If
    End Sub



    Private Sub cboCDStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCDStatus.SelectedIndexChanged
        '9819
        If cboCDStatus.SelectedIndex = 2 Or cboCDStatus.SelectedIndex = 3 Then
            txtRefNo.Enabled = False
            txtRmk.Enabled = False

            fmeDetail.Enabled = False
            mmdSave.Enabled = False

        Else
            txtRefNo.Enabled = True
            txtRmk.Enabled = True
            fmeDetail.Enabled = True
            mmdSave.Enabled = True

        End If

    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        'Enq_right_local = Enq_right '***Assign Local form rights
        'Del_right_local = Del_right
        Call fillParameter()  '***sub-routine for filling preload value statement from  formload
        Call setStatus("Init") '**** Reflash Screen

    End Sub



    Private Sub cboPckInf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPckInf.GotFocus
        If TmpItmNo <> "" Then
            rs_SHIPGDTLO.Tables("result").DefaultView.RowFilter = "hid_invno = '" & Trim(txtRefNo.Text) & "' and hid_itmno ='" & Trim(txtItmNo.Text) & "'"
            If rs_SHIPGDTLO.Tables("result").DefaultView.Count = 0 Then
                cboPckInf.Enabled = False
                MsgBox("M00312")
                txtItmNo.Focus()
            Else
                rs_SHIPGDTLO.Tables("result").DefaultView.RowFilter = "hid_invno = '" & Trim(txtRefNo.Text) & "' and hid_itmno ='" & Trim(txtItmNo.Text) & "' and hid_colcde = '" & Trim(txtColCde.Text) & "'"
                If rs_SHIPGDTLO.Tables("result").DefaultView.Count = 0 Then
                    cboPckInf.Enabled = False
                    MsgBox("Plesae input color code!")
                    txtColCde.Focus()
                Else

                    If rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*ADD*~" Then
                        cboPckInf.Enabled = True
                    End If
                    Call fillcboPckInf()
                    '''''''''''                    cboPckInf.Focus()
                    'temp

                End If
            End If
        Else
            MsgBox("Item No should not be empty")
            txtItmNo.Enabled = True
            txtItmNo.Focus()
        End If

    End Sub

    Private Sub cboPckInf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPckInf.LostFocus
        Dim X As String
        If cboPckInf.Text <> "" Then
            X = cboPckInf.Text
        Else
            X = cboPckInf.SelectedIndex



        End If
        cboPckInf.Enabled = True

    End Sub

    Private Sub cboPckInf_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPckInf.SelectedIndexChanged
        rs_SHIPGDTLO.Tables("result").DefaultView.RowFilter = ""

        If txtItmNo.Text <> "" And txtColCde.Text <> "" Then

            rs_SHIPGDTLO.Tables("result").DefaultView.RowFilter = "hid_invno = '" & Trim(txtRefNo.Text) & "' and hid_itmno ='" & Trim(txtItmNo.Text) & "' and hid_colcde = '" & Trim(txtColCde.Text) & "'"

            If rs_SHIPGDTLO.Tables("result").DefaultView.Count > 0 Then
                If rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*ADD*~" Then
                    If Trim(cboPckInf.Text) <> "///0" Then
                        'rs_SHIPGDTLO.tables("result").DefaultView.Move cboPckInf.selectedindex, 1

                        rs_SHIPGDTLO.Tables("result").DefaultView.RowFilter = rs_SHIPGDTLO.Tables("result").DefaultView.RowFilter & _
                        " and hid_untcde = '" & rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_untcde") & "' " & _
                        " and hid_inrctn = '" & rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_inrctn") & "' " & _
                        " and hid_mtrctn = '" & rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_mtrctn") & "' " & _
                        " and hid_vol = '" & rs_SHIPGDTLO.Tables("result").DefaultView(0)("hid_vol") & "' "

                        cboSCNo.Enabled = True

                        If rs_SHIPGDTLO.Tables("result").DefaultView.Count > 0 Then
                            Call fillSCNo()
                        Else
                            MsgBox("No record found in shipping detail!")
                        End If

                    End If
                End If
            End If
        End If

    End Sub



    Private Sub fillSCNo()

        rs_SHIPGDTLO.Tables("result").DefaultView.Sort = "hid_ordno"
        'rs_SHIPGDTLO.tables("result").DefaultView.MoveFirst()

        cboSCNo.Items.Clear()

        For index9 As Integer = 0 To rs_SHIPGDTLO.Tables("result").DefaultView.Count - 1
            'temp  defailt view  or row
            cboSCNo.Items.Add(rs_SHIPGDTLO.Tables("result").DefaultView(index9)("hid_ordno"))

        Next
        'While Not rs_SHIPGDTLO.tables("result").DefaultView.EOF

        '    cboSCNo.items.add(rs_SHIPGDTLO.tables("result").DefaultView(0)("hid_ordno"))
        '    rs_SHIPGDTLO.tables("result").DefaultView.MoveNext()

        'End While


    End Sub

    Private Sub chkDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDel.Click

        If rs_SHCBNDTL.Tables("result").Rows.Count > 0 Then
            If chkDel.Checked = True Xor (rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*DEL*~" Or rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*NEW*~") Then
                Recordstatus = True
                Call delTrg()
            End If
        End If

    End Sub

    Private Sub delTrg()

        Dim i As Integer
        Dim mark As Object

        If chkDel.Checked = True Then
            If optCredit.Checked = True Then

                i = CInt(txtcre.Text)

                '      mark = rs_SHCBNDTL.bookmark

                rs_SHCBNDTL.Tables("result").DefaultView.RowFilter = "hnd_creusr = '~*DEL*~' and hnd_upd = 'Y'"

                For index9 As Integer = 0 To rs_SHCBNDTL.Tables("result").DefaultView.Count - 1
                    i = i + rs_SHCBNDTL.Tables("result").DefaultView(index9)("hnd_adjqty")
                Next
                'While Not rs_SHCBNDTL.EOF
                '    i = i + rs_SHCBNdtl.tables("result").rows(readingindex)("hnd_adjqty")
                '    rs_SHCBNDTL.MoveNext()
                'End While

                rs_SHCBNDTL.Tables("result").DefaultView.RowFilter = ""
                'rs_SHCBNDTL.bookmark = mark

                i = i + CInt(txtAdjQty.Text) + CInt(txtdeb.Text)


                'If i > 0 Then
                '    MsgBox "Outstanding quantity cannot be greater than 0", vbInformation, "Warning"
                '    Exit Sub
                'End If

                'If CInt(txtAdjQty.Text) > CInt(ordqty.Text) - CInt(shpqty.Text) Then
                '    MsgBox "Adjusted quantity cannot be greater than outstanding quantity", vbInformation, "Warning"
                '    Exit Sub
                'End If

            Else

                i = CInt(txtdeb.Text)

                '     mark = rs_SHCBNDTL.bookmark
                rs_SHCBNDTL.Tables("result").DefaultView.RowFilter = "hnd_creusr = '~*DEL*~' and hnd_upd = 'Y'"


                For index9 As Integer = 0 To rs_SHCBNDTL.Tables("result").DefaultView.Count - 1
                    i = i - rs_SHCBNDTL.Tables("result").DefaultView(index9)("hnd_adjqty")
                Next
                'While Not rs_SHCBNDTL.EOF
                '    i = i - rs_SHCBNdtl.tables("result").rows(readingindex)("hnd_adjqty")
                '    rs_SHCBNDTL.MoveNext()
                'End While

                rs_SHCBNDTL.Tables("result").DefaultView.RowFilter = ""
                '       rs_SHCBNDTL.bookmark = mark


                i = i - CInt(txtAdjQty.Text) + CInt(txtcre.Text)


                ' If Math.Abs(i) > CInt(txtShpQty.Text) Then
                '     MsgBox "Outstanding quantity cannot greater than shipped quantity", vbInformation, "Warning"
                '     Exit Sub
                ' End If

                ' If CInt(txtAdjQty.Text) > CInt(shpqty.Text) Then
                '     MsgBox "Adjusted quantity cannot be greater than shipped quantity", vbInformation, "Warning"
                '     Exit Sub
                ' End If

            End If
        Else
            'Add by Lewis to handle undelete record by Lewis on 26/03/2003**************
            If optCredit.Checked = True Then

                i = CInt(txtcre.Text)

                '   mark = rs_SHCBNDTL.bookmark

                rs_SHCBNDTL.Tables("result").DefaultView.RowFilter = "hnd_creusr = '~*DEL*~' and hnd_upd = 'Y'"
                For index9 As Integer = 0 To rs_SHCBNDTL.Tables("result").DefaultView.Count - 1
                    i = i + rs_SHCBNDTL.Tables("result").DefaultView(index9)("hnd_adjqty")
                Next

                'While Not rs_SHCBNDTL.EOF
                '    i = i + rs_SHCBNdtl.tables("result").rows(readingindex)("hnd_adjqty")
                '    rs_SHCBNDTL.MoveNext()
                'End While

                rs_SHCBNDTL.Tables("result").DefaultView.RowFilter = ""
                'rs_SHCBNDTL.bookmark = mark

                i = i - CInt(txtAdjQty.Text) + CInt(txtdeb.Text)



            Else

                i = CInt(txtdeb.Text)

                '   mark = rs_SHCBNDTL.bookmark
                rs_SHCBNDTL.Tables("result").DefaultView.RowFilter = "hnd_creusr = '~*DEL*~' and hnd_upd = 'Y'"
                For index9 As Integer = 0 To rs_SHCBNDTL.Tables("result").DefaultView.Count - 1
                    i = i - rs_SHCBNDTL.Tables("result").DefaultView(index9)("hnd_adjqty")
                Next
                'While Not rs_SHCBNDTL.EOF
                '    i = i - rs_SHCBNdtl.tables("result").rows(readingindex)("hnd_adjqty")
                '    rs_SHCBNDTL.MoveNext()
                'End While

                rs_SHCBNDTL.Tables("result").DefaultView.RowFilter = ""
                '     rs_SHCBNDTL.bookmark = mark


                i = i + CInt(txtAdjQty.Text) + CInt(txtcre.Text)



            End If
        End If

        If btcSHM00002.SelectedIndex = 1 And cboCDStatus.SelectedIndex <> 2 Then

            If rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*ADD*~" Then
                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*NEW*~"
            ElseIf rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*DEL*~" Then
                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = ""
            ElseIf rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*NEW*~" Then
                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*ADD*~"
            Else
                rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*DEL*~"
            End If
            ' Handled in above If ... then  by Lewis on 26/03/2003 **************
            'If chkDel.Checked = true Then
            '    chkDel.Checked = false
            'Else
            '    chkDel.Checked = true
            'End If

        End If
    End Sub

    Private Sub chkUpd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUpd.CheckedChanged

    End Sub

    Private Sub chkUpd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkUpd.Click
        If chkUpd.Checked = True Then
            If optCredit.Checked = True Then
                If IsNumeric(txtAdjQty.Text.Trim) Then
                    txtcre.Text = -1 * txtAdjQty.Text.Trim
                Else
                    txtcre.Text = 0
                End If
            Else
                If IsNumeric(txtAdjQty.Text.Trim) Then
                    txtdeb.Text = txtAdjQty.Text.Trim
                Else
                    txtdeb.Text = 0
                End If
            End If
            txtout.Text = Val(txtcre.Text) + Val(txtdeb.Text)
        Else
            txtcre.Text = 0
            txtdeb.Text = 0
            txtout.Text = 0
        End If

    End Sub

    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click

        Dim YesNoCancel As Integer
        If Recordstatus = True Then

            YesNoCancel = MsgBox("Do you want to save before clear the screen?", MsgBoxStyle.YesNoCancel)


            If YesNoCancel = vbYes Then
                If mmdSave.Enabled Then
                    flag_exit = True
                    Call cmdSaveClick()
                    If save_ok = True Then
                        Call setStatus("Init")
                    Else
                        flag_exit = False
                        Exit Sub
                    End If
                Else
                    flag_exit = False
                    MsgBox("M00253")
                    Exit Sub
                End If

            ElseIf YesNoCancel = vbNo Then

                Call setStatus("Init")

            ElseIf YesNoCancel = vbCancel Then
                flag_exit = False
                Exit Sub
            End If
            'Else

            'Call SetStatus("Init")
        End If

        Call setStatus("Init")

        Recordstatus = False
        txtNoteNo.Enabled = True
        btcSHM00002.SelectedIndex = 0
        txtNoteNo.Focus()

    End Sub

    ''Private Sub cmdClear_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClear.GotFocus
    ''    Dim YesNoCancel As Integer
    ''    If Recordstatus = True Then

    ''        YesNoCancel = MsgBox("Do you want to save before clear the screen?", MsgBoxStyle.YesNoCancel)


    ''        If YesNoCancel = vbYes Then
    ''            If cmdSave.Enabled Then
    ''                flag_exit = True
    ''                Call cmdSaveClick()
    ''                If save_ok = True Then
    ''                    Call setStatus("Init")
    ''                Else
    ''                    flag_exit = False
    ''                    Exit Sub
    ''                End If
    ''            Else
    ''                flag_exit = False
    ''                MsgBox("M00253")
    ''                Exit Sub
    ''            End If

    ''        ElseIf YesNoCancel = vbNo Then

    ''            Call setStatus("Init")

    ''        ElseIf YesNoCancel = vbCancel Then
    ''            flag_exit = False
    ''            Exit Sub
    ''        End If
    ''        'Else

    ''        'Call SetStatus("Init")
    ''    End If

    ''    Call setStatus("Init")
    ''    Recordstatus = False
    ''    txtNoteNo.Enabled = True
    ''    btcSHM00002.SelectedIndex = 0
    ''    txtNoteNo.Focus()

    ''End Sub

    Private Sub mmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click
        If btcSHM00002.SelectedIndex = 1 Then

            If rs_SHCBNDTL.Tables("result").Rows.Count > 0 Then

                If chkDel.Checked = False Then
                    chkDel.Checked = True
                Else
                    chkDel.Checked = False
                End If
                If chkDel.Checked = True Xor (rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*DEL*~" Or rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*NEW*~") Then
                    Recordstatus = True
                    Call delTrg()
                End If

            End If
        End If

    End Sub

    Private Sub CmdDtlPre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDtlPre.Click
        Call Update_Dtl()
        If rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*ADD*~" Then



            If txtItmNo.Text <> "" And txtColCde.Text <> "" And cboPckInf.Text <> "" Then
                If Not chkSave() Then
                    Exit Sub
                End If

                'Call Update_Dtl
                'Else
                '    If txtItmNo.Text = "" And txtColCde.Text = "" And cboPckInf.Text = "" Then
                '    chkDel.Checked = true
                '    End If
            End If

        End If

        readingindex = readingindex - 1

        'If readingindex <> 0 Then
        '    CmdDtlNext.Enabled = True
        '    '   rs_SHCBNDTL.MovePrevious()
        'End If
        Call DisplayDetail()


        If rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*ADD*~" Then
            chkUpd.Enabled = True
        Else
            chkUpd.Enabled = False
        End If



    End Sub

    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        Me.Close()

    End Sub

    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        If rs_SHCBNDTL.Tables("result").Rows.Count > 0 Then
            If optItm.Checked = True And txtItmNo.Text = "" Then
                Exit Sub
            End If
        End If
        Recordstatus = True
        If btcSHM00002.SelectedIndex = 1 And cboCDStatus.SelectedIndex <> 2 Then
            fmeDetail.Enabled = True
            Me.optItm.Enabled = True
            Me.optMsc.Enabled = True


            If rs_SHCBNDTL.Tables("result").Rows.Count > 0 Then
                If rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*ADD*~" Then
                    If Not chkSave() Then
                        Exit Sub
                    End If

                    Call Update_Dtl()
                End If
            End If

            Call clearDetail()
            '    Call Display_dtl.tables("result").rows(readingindex)("ADD")
            '    Call SetDtlStatus("ADD")
            If rs_SHCBNDTL.Tables("result").Rows.Count <> 0 Then
                '  rs_SHCBNDTL.MoveLast()
            End If

            readingindex = rs_SHCBNDTL.Tables("result").Rows.Count
            If rs_SHCBNDTL.Tables("result").Rows.Count = 0 Then
                readingindex = 0
            End If
            Call add_SHCBNDTL()

            '19988
            'rs_SHCBNDTL.Tables("result").Rows.Add()

            MaxSeq = MaxSeq + 1
            txtSeq.Text = MaxSeq

            rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_seq") = MaxSeq
            rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*ADD*~"

            If rs_SHCBNDTL.Tables("result").Rows.Count > 1 Then
                CmdDtlPre.Enabled = True
            End If
            CmdDtlNext.Enabled = False
            chkUpd.Enabled = True
            txtItmNo.Enabled = True
            txtColCde.Enabled = True

            txtAdjQty.Enabled = True
            txtDRmk.Enabled = True
            '''''''''
            optItm.Checked = True
            chkDel.Enabled = True
            optItm.Enabled = True

            optItm.Focus()
            '  txtItmNo.SetFocus
        End If

    End Sub


    Private Sub fillcboPckInf()
        Dim ex_pck As String
        ex_pck = ""

        rs_SHIPGDTLO.Tables("result").DefaultView.Sort = "hid_untcde"
        '    rs_SHIPGDTLO.tables("result").DefaultView.MoveFirst()


        cboPckInf.Items.Clear()

        For index9 As Integer = 0 To rs_SHIPGDTLO.Tables("result").DefaultView.Count - 1
            If ex_pck <> rs_SHIPGDTLO.Tables("result").DefaultView(index9)("hid_untcde") & "/" & _
                            rs_SHIPGDTLO.Tables("result").DefaultView(index9)("hid_inrctn") & "/" & _
                            rs_SHIPGDTLO.Tables("result").DefaultView(index9)("hid_mtrctn") & "/" & _
                            rs_SHIPGDTLO.Tables("result").DefaultView(index9)("hid_vol") _
                            Then
                ex_pck = rs_SHIPGDTLO.Tables("result").DefaultView(index9)("hid_untcde") & "/" & _
                         rs_SHIPGDTLO.Tables("result").DefaultView(index9)("hid_inrctn") & "/" & _
                         rs_SHIPGDTLO.Tables("result").DefaultView(index9)("hid_mtrctn") & "/" & _
                         rs_SHIPGDTLO.Tables("result").DefaultView(index9)("hid_vol")
                cboPckInf.Items.Add(ex_pck)
            End If
        Next
        'While Not rs_SHIPGDTLO.tables("result").DefaultView.EOF
        '    If ex_pck <> rs_SHIPGDTLO.tables("result").DefaultView(0)("hid_untcde") & "/" & _
        '                rs_SHIPGDTLO.tables("result").DefaultView(0)("hid_inrctn") & "/" & _
        '                rs_SHIPGDTLO.tables("result").DefaultView(0)("hid_mtrctn") & "/" & _
        '                rs_SHIPGDTLO.tables("result").DefaultView(0)("hid_vol") _
        '                Then
        '        ex_pck = rs_SHIPGDTLO.tables("result").DefaultView(0)("hid_untcde") & "/" & _
        '                 rs_SHIPGDTLO.tables("result").DefaultView(0)("hid_inrctn") & "/" & _
        '                 rs_SHIPGDTLO.tables("result").DefaultView(0)("hid_mtrctn") & "/" & _
        '                 rs_SHIPGDTLO.tables("result").DefaultView(0)("hid_vol")
        '        cboPckInf.items.add(ex_pck)
        '    End If
        '    rs_SHIPGDTLO.tables("result").DefaultView.MoveNext()
        'End While


    End Sub





    Private Sub optItm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optItm.CheckedChanged

    End Sub

    Private Sub optItm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optItm.Click
        If optItm.Checked = True And rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*ADD*~" Then
            txtItmNo.Enabled = True
            txtColCde.Enabled = True
            chkUpd.Enabled = True

        Else
            Call clearDetail()
            txtItmNo.Enabled = False
            txtColCde.Enabled = False
            chkUpd.Enabled = False

        End If
    End Sub

    Private Sub optMsc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMsc.CheckedChanged

    End Sub

    Private Sub optMsc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optMsc.Click
        If optMsc.Checked = True Then
            Call clearDetail()
            txtItmNo.Enabled = False
            txtColCde.Enabled = False
            cboPckInf.Enabled = False
            chkUpd.Enabled = False
            cboSCNo.Enabled = False

        Else
            txtItmNo.Enabled = True
            txtColCde.Enabled = True
            cboPckInf.Enabled = True
            chkUpd.Enabled = True
            cboSCNo.Enabled = True

        End If

    End Sub

    Private Sub txtAdjPrc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAdjPrc.GotFocus
        Call HighlightText(txtAdjPrc)

    End Sub

    Private Sub txtAdjPrc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAdjPrc.LostFocus

    End Sub

    Private Sub txtAdjPrc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdjPrc.TextChanged

    End Sub

    Private Sub txtAdjQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAdjQty.LostFocus
    End Sub

    Private Sub txtAdjQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdjQty.TextChanged

    End Sub

    Private Sub txtColCde_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtColCde.LostFocus
        txtColCde.Text = UCase(txtColCde.Text)
        If rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*ADD*~" Then
            cboPckInf.Enabled = True
            cboPckInf.Focus()
        End If
        'End If
        rs_SHIPGDTLO.Tables("result").DefaultView.RowFilter = ""

    End Sub

    Private Sub txtColCde_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtColCde.TextChanged

    End Sub

    Private Sub txtDRmk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDRmk.GotFocus
        '   Call HighlightText(txtDRmk)

    End Sub

    Private Sub txtDRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDRmk.TextChanged

    End Sub

    Private Sub txtNoteNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoteNo.KeyUp

    End Sub

    Private Sub txtNoteNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoteNo.TextChanged

    End Sub

    Private Sub txtRefNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRefNo.KeyPress
        If e.KeyChar = Chr(13) Then

            If Trim(txtRefNo.Text) = "" Then
                MsgBox("M00316")
            Else

                Call QueryShipInfo()
                btcSHM00002.TabPages(0).Enabled = True
                btcSHM00002.TabPages(1).Enabled = True
            End If
        End If

        btcSHM00002.Enabled = True

        Cursor = Cursors.Default




    End Sub

    Private Sub txtRefNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRefNo.TextChanged

    End Sub


    Private Function ChecktimeStamp() As Boolean
        '***Add Codes here***
        'Compare the current record's timestamp and the DB timestamp
        Dim Save_TimeStamp As Long

        gspStr = "sp_select_SHCBNHDR '" & cboCoCde.Text & "','" & txtNoteNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SHCBNHDR, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtNoteNoKeyPress sp_select_SHIPGHDR :" & rtnStr)
            Exit Function
        End If
        If rs_SHCBNHDR.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found!")
            ChecktimeStamp = False
            Exit Function
        Else
            '            Save_TimeStamp = rs_SHCBNHDR.Tables("RESULT").Rows(0)("hnh_timstp")
        End If

        'Write your code for Compare
        If Current_TimeStamp <> Save_TimeStamp Then
            ChecktimeStamp = False
        Else
            ChecktimeStamp = True
        End If

    End Function

    Private Sub txtRmk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRmk.GotFocus
        If Trim(txtRefNo.Text) = "" Then
            If btcSHM00002.Enabled = True Then
                MsgBox("M00316")
                txtRefNo.Focus()
            End If
        Else

            Call QueryShipInfo()
            optCredit.Enabled = False
            optDebit.Enabled = False
        End If
        '  Call HighlightText(txtRmk)

    End Sub




    Private Sub txtRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRmk.TextChanged

    End Sub



    Private Function chkSave() As Boolean

        chkSave = False

        Dim i As Integer
        Dim mark As Object
        '**** Add Checking for Packing Info input by Lewis on 25/03/2003 ********
        If rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*NEW*~" Or rs_SHCBNDTL.Tables("result").Rows(readingindex)("hnd_creusr") = "~*DEL*~" Then
            chkSave = True
            Exit Function
        End If
        If Trim(txtItmNo.Text) <> "" And txtItmNo.Enabled = True Then

            If (Trim(txtItmNo.Text) <> "" And (cboPckInf.Text) = "") And chkDel.Checked = False Then
                MsgBox("Please Input the Packing Info .", vbInformation)
                If cboPckInf.Enabled = True Then
                    cboPckInf.Focus()
                End If
                Exit Function
            End If
            If (txtAdjQty.Text.Trim = "" Or txtAdjQty.Text.Trim <= "0" Or txtAdjPrc.Text = "" Or txtAdjPrc.Text <= "0") And chkDel.Checked = False Then
                MsgBox("Invalid Adjust Quantity and Price", vbInformation, "Warning")
                optItm.Focus()
                Exit Function
            End If
            ' Remark for debug delete record w/o any change ****************************
            'Else
            '   MsgBox "Please Input Item No.", vbInformation, "Warning"
            '   optItm.SetFocus
            '   Exit Function
            If Trim(cboSCNo.Text) = "" Then
                MsgBox("Please Input SC No.", vbInformation, "Warning")
                cboSCNo.Focus()
                Exit Function
            End If
        End If

        If txtItmNo.Text <> "" And txtColCde.Text <> "" And cboPckInf.Text <> "" Then
            If CInt(txtAdjQty.Text) Mod CInt(IIf(IsNumeric(Split(cboPckInf.Text, "/")(2)), Split(cboPckInf.Text, "/")(2), 1)) <> 0 Then
                MsgBox("Adjust Quantity must be multiple of Master", vbInformation, "Warning")
                txtAdjQty.Focus()
                Exit Function
            End If

            If optCredit.Checked = True Then

                'for invoice qty

                i = 0
                '            mark = readingindex
                rs_SHCBNDTL.Tables("result").DefaultView.RowFilter = "hnd_creusr = '~*ADD*~' and hnd_upd = 'Y' and hnd_seq = " & txtSeq.Text


                For index9 As Integer = 0 To rs_SHCBNDTL.Tables("result").DefaultView.Count - 1
                    i = i + rs_SHCBNDTL.Tables("result").DefaultView(index9)("hnd_adjqty")
                Next
                'While Not rs_SHCBNDTL.EOF
                '    i = i + rs_SHCBNdtl.tables("result").rows(readingindex)("hnd_adjqty")
                '    rs_SHCBNDTL.MoveNext()
                'End While

                rs_SHCBNDTL.Tables("result").DefaultView.RowFilter = ""
                '       readingindex = mark

                'If i + Math.Abs(CInt(txtcre.Text)) > CInt(txtShpQty.Text) Then
                If Math.Abs(i) > CInt(txtShpQty.Text) Then
                    MsgBox("Credit quantity must be smaller than ship quantity", vbInformation, "Warning")
                    ' txtAdjQty.text.SetFocus
                    Exit Function
                End If

                '        ' for sc shp qty
                '            If CInt(txtout.Text) - i > CInt(shpqty.Text) Then
                '                MsgBox "Adjusted Quantity must be smaller than ship quantity"
                '                txtAdjQty.text.SetFocus
                '                Exit Function
                '            End If

            Else

                'for invoice qty

                i = 0
                ' mark = readingindex
                rs_SHCBNDTL.Tables("result").DefaultView.RowFilter = "hnd_creusr = '~*ADD*~' and hnd_upd = 'Y'"

                For index9 As Integer = 0 To rs_SHCBNDTL.Tables("result").DefaultView.Count - 1
                    i = i + rs_SHCBNDTL.Tables("result").DefaultView(index9)("hnd_adjqty")
                Next
                'While Not rs_SHCBNDTL.EOF
                '    i = i + rs_SHCBNdtl.tables("result").rows(readingindex)("hnd_adjqty")
                '    rs_SHCBNDTL.MoveNext()
                'End While
                rs_SHCBNDTL.Tables("result").DefaultView.RowFilter = ""
                '     readingindex = mark

                If Math.Abs(CInt(txtcre.Text)) = 0 Then
                    MsgBox("No Credit is issued for this invoice", vbInformation, "Information")
                    txtAdjQty.Focus()
                    Exit Function
                End If

                If i + CInt(txtdeb.Text) > Math.Abs(CInt(txtcre.Text)) Then
                    MsgBox("Debit Qty cannot greater than Credit Qty", vbInformation, "Information")
                    txtAdjQty.Focus()
                    Exit Function
                End If

                If i + CInt(txtcre.Text) + CInt(txtdeb.Text) > CInt(ordqty.Text) - CInt(shpqty.Text) Then
                    MsgBox("M00321")
                    txtAdjQty.Focus()
                    Exit Function
                End If

                '            If CInt(txtout.Text) + i > CInt(ordqty.Text - shpqty.Text) Then
                '                MsgBox "Adjusted Quantity must be smaller than outstanding quantity"
                '                txtAdjQty.text.SetFocus
                '                Exit Function
                '            End If
            End If
            chkSave = True
        Else
            If optMsc.Checked = True Then
                If txtAdjQty.Text.Trim <> "" And txtAdjQty.Text.Trim > "0" And txtAdjPrc.Text <> "" And txtAdjPrc.Text.Trim > "0" Then
                    chkSave = True
                Else
                    chkSave = False
                End If
            Else
                chkSave = False
            End If
        End If



    End Function
    Private Sub clearDetail()

        txtItmNo.Text = ""
        txtColCde.Text = ""
        cboPckInf.Items.Clear()
        cboPckInf.Text = ""
        txtItmDsc.Text = ""
        txtColDsc.Text = ""
        txtCusItm.Text = ""
        txtCusSku.Text = ""
        txtManNam.Text = ""
        txtManAdr.Text = ""
        '    txtUM.Text = ""
        '    txtInr.Text = ""
        '    txtMtr.Text = ""
        '    txtCBM.Text = ""
        txtShpQty.Text = "0"

        '    txtCurCde2.Text = ""
        txtSelPrc.Text = "0"
        '   txtCurCde3.Text = ""
        txtShpAmt.Text = "0"

        txtAdjPrc.Text = 0
        txtAdjQty.Text = 0
        txtAdjAmt.Text = 0

        txtDRmk.Text = ""
        txtSCNo.Text = ""
        'txtPO.Text = ""
        chkUpd.Checked = False

        txtInvLne.Text = ""

        chkDel.Checked = False

        ordqty.Text = 0
        shpqty.Text = 0

        '** Added by Tommy on 20 Sept 2002
        txtcre.Text = 0
        txtdeb.Text = 0
        txtout.Text = 0
        cboSCNo.Items.Clear()
        cboSCNo.Text = ""
        'Lester Wu 2004/08/26


    End Sub



    Public Sub add_SHCBNDTL()

        ''*** Check Combo in list or not ?
        'If not_in_Combo_HDR() = True Then
        '    Exit Sub
        'End If
        If rs_SHCBNDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        'If Not rs_SHCBNDTL.Tables("RESULT").Rows.Count > 0 Then
        '    Exit Sub
        'End If

        rs_SHCBNDTL.Tables("RESULT").Rows.Add()
        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_cocde") = cboCoCde.Text.Trim
        'rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Tables("RESULT").Rows(ReadingIndex)("hnd_shpno") = txtNoteNo.Text.Trim
        'rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Tables("RESULT").Rows(ReadingIndex)("hnd_shpseq") = IIf(IsNumeric(txtShpSeq.Text.Trim), txtShpSeq.Text.Trim, 0)



        If optItm.Checked = True Then

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_lnetyp") = "I"

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_itmno") = ""

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_itmdsc") = ""

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_colcde") = ""

            If Trim(cboPckInf.Text) <> "" Then

                rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_pckunt") = ""
                rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_inrctn") = ""
                rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_mtrctn") = ""
                rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_cft") = 0

            Else

                rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_pckunt") = ""
                rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_inrctn") = ""
                rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_mtrctn") = ""
                rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_cft") = 0

            End If

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_coldsc") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_cusitm") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_cussku") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_mannam") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_manadr") = ""

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_curcde") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_curcde") = ""


        Else

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_lnetyp") = "M"

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_itmno") = ""

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_itmdsc") = ""

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_colcde") = ""

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_pckunt") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_inrctn") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_mtrctn") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_cft") = 0

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_coldsc") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_cusitm") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_cussku") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_mannam") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_manadr") = ""

            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_curcde") = ""
            rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_curcde") = ""

        End If

        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_adjprc") = 0

        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_adjqty") = 0


        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_rmk") = ""


        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_shpqty") = 0
        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_untsel") = ""

        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_untamt") = 0

        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_selprc") = 0
        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_ttlamt") = 0
        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_ordno") = ""

        'Lester Wu 2004/08/26
        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hid_purord") = ""
        '----------------------------------------------
        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("sod_ordqty") = 0
        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("sod_shpqty") = 0

        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_upd") = "N"

        rs_SHCBNDTL.Tables("RESULT").Rows(readingindex)("hnd_invlne") = 0

        'rs_SHCBNDTL.Tables("RESULT").Rows(ReadingIndex).Update()

    End Sub





    Private Sub chkSample_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSample.CheckedChanged

    End Sub

    Private Sub chkDel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDel.CheckedChanged

    End Sub

    Private Sub txtBilstt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBilstt.TextChanged

    End Sub

    Private Sub txtBilAdr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBilAdr.TextChanged

    End Sub

    Private Sub fmeDetail_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fmeDetail.Enter

    End Sub

    Private Sub GroupBox5_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox5.Enter

    End Sub

    Private Sub txtAdjQty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAdjQty.Validating
        Dim msged_count As Integer

        If msged_count >= 2 Then
            msged_count = 0
            Exit Sub
        End If

        ' *****Add by Lewis to Check numeric input and Valid Adj Qty by Lewis on 25/03/2003 ******
        Dim X As Integer

        '    If Trim(txtAdjQty.Text) <> "" And Trim(txtAdjPrc.Text) <> "" And _
        '        txtAdjQty.Text <> "0" And txtAdjPrc.Text <> "0" Then
        If Trim(txtAdjQty.Text.Trim) = "" Then
            txtAdjQty.Text = 0


        End If
        If Not IsNumeric(txtAdjQty.Text.Trim) Then
            MsgBox("Input is not numeric data", vbInformation, "Warnning")
            txtAdjQty.Focus()
            Exit Sub
        End If
        'If Trim(txtAdjQty.Text) <> "" And
        If txtAdjQty.Text > 0 Then
            If IsNumeric(txtAdjPrc.Text.Trim) And IsNumeric(txtAdjQty.Text.Trim) Then
                If txtSCNo.Text.Trim <> "" Then
                    If optCredit.Checked = True Then
                        If Math.Abs(CInt(txtAdjQty.Text.Trim)) > shpqty.Text Then
                            msged_count = msged_count + 1
                            MsgBox("Credit quantity must be smaller than shipped quantity", vbInformation, "Warning")
                            txtAdjQty.Focus()
                        End If
                    Else
                        If Math.Abs(CInt(txtAdjQty.Text.Trim)) > ordqty.Text.Trim - shpqty.Text.Trim Then
                            msged_count = msged_count + 1
                            MsgBox("Debit quantity must be smaller than Outstanding quantity", vbInformation, "Warning")
                            txtAdjQty.Focus()
                        End If
                    End If
                End If
                If optItm.Checked = True Then
                    If CInt(txtAdjQty.Text.Trim) Mod Split(cboPckInf.Text, "/")(2) <> 0 Then
                        msged_count = msged_count + 1
                        MsgBox("Adjust Quantity must be multiple of Master")
                        txtAdjQty.Focus()
                    Else
                        txtAdjQty.Text = CInt(txtAdjQty.Text)
                        txtAdjAmt.Text = txtAdjQty.Text * txtAdjPrc.Text
                    End If

                End If
                'Else
                '    MsgBox "Invalid Packing Info."
                'End If
            Else
                MsgBox("M00018")
                Call HighlightText(txtAdjQty)
                txtAdjQty.Focus()
            End If
            'Else
            '    txtAdjQty.text.SetFocus
        End If

    End Sub

    Private Sub StatusBar_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles StatusBar.PanelClick

    End Sub
End Class



















































































