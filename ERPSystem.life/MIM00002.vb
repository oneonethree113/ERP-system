Public Class MIM00002

    Inherits System.Windows.Forms.Form

    '    Dim objBSGate As Object    '*** an object of "ucpBS_Gate.clsBSGate"
    Dim Current_TimeStamp As Long 'For current record's time stamp
    Public Recordstatus As Boolean '***Check the Current record is modified or not
    '***This flag must used in each fields of the S
    Dim isSave As Boolean
    Dim save_ok As Boolean

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim readingindex As Integer


    Public rs_ZSITMDAT As DataSet
    Public rs_ZSITMDAT_dtl As DataSet
    Public rs_ZSITMDAT_ASS As DataSet
    Public rs_ZSITMDAT_REG As DataSet





#Region " Windows Form Designer generated code"
    Friend WithEvents SSTab1 As ERPSystem.BaseTabControl
    Friend WithEvents tpMIM00002_1 As System.Windows.Forms.TabPage
    Friend WithEvents tpMIM00002_2 As System.Windows.Forms.TabPage
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
    Friend WithEvents cmdLastD As System.Windows.Forms.Button
    Friend WithEvents cmdPrvD As System.Windows.Forms.Button
    Friend WithEvents cmdNextD As System.Windows.Forms.Button
    Friend WithEvents cmdFirstD As System.Windows.Forms.Button
    Friend WithEvents grdDetail As System.Windows.Forms.DataGridView
    Friend WithEvents frmApproveReject As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFromApply As System.Windows.Forms.TextBox
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents txtToApply As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtItmNo As System.Windows.Forms.TextBox
    Friend WithEvents optApproval As System.Windows.Forms.RadioButton
    Friend WithEvents optWait As System.Windows.Forms.RadioButton
    Friend WithEvents optRejection As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtVenItm_dtl As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEngDsc_dtl As System.Windows.Forms.TextBox
    Friend WithEvents chkReject_dtl As System.Windows.Forms.CheckBox
    Friend WithEvents chkApprove_dtl As System.Windows.Forms.CheckBox
    Friend WithEvents chkWait_dtl As System.Windows.Forms.CheckBox
    Friend WithEvents grdSummary As System.Windows.Forms.DataGridView
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MIM00002))
        Me.StatusBar = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.ComboBox6 = New System.Windows.Forms.ComboBox
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox
        Me.frmApproveReject = New System.Windows.Forms.GroupBox
        Me.optRejection = New System.Windows.Forms.RadioButton
        Me.optApproval = New System.Windows.Forms.RadioButton
        Me.optWait = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtFromApply = New System.Windows.Forms.TextBox
        Me.cmdApply = New System.Windows.Forms.Button
        Me.txtToApply = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtItmNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
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
        Me.SSTab1 = New ERPSystem.BaseTabControl
        Me.tpMIM00002_1 = New System.Windows.Forms.TabPage
        Me.grdSummary = New System.Windows.Forms.DataGridView
        Me.tpMIM00002_2 = New System.Windows.Forms.TabPage
        Me.chkWait_dtl = New System.Windows.Forms.CheckBox
        Me.chkReject_dtl = New System.Windows.Forms.CheckBox
        Me.chkApprove_dtl = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtEngDsc_dtl = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtVenItm_dtl = New System.Windows.Forms.TextBox
        Me.cmdLastD = New System.Windows.Forms.Button
        Me.cmdPrvD = New System.Windows.Forms.Button
        Me.cmdNextD = New System.Windows.Forms.Button
        Me.cmdFirstD = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.grdDetail = New System.Windows.Forms.DataGridView
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
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmApproveReject.SuspendLayout()
        Me.menuStrip.SuspendLayout()
        Me.SSTab1.SuspendLayout()
        Me.tpMIM00002_1.SuspendLayout()
        CType(Me.grdSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpMIM00002_2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
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
        'frmApproveReject
        '
        Me.frmApproveReject.Controls.Add(Me.optRejection)
        Me.frmApproveReject.Controls.Add(Me.optApproval)
        Me.frmApproveReject.Controls.Add(Me.optWait)
        Me.frmApproveReject.ForeColor = System.Drawing.Color.Black
        Me.frmApproveReject.Location = New System.Drawing.Point(237, 29)
        Me.frmApproveReject.Name = "frmApproveReject"
        Me.frmApproveReject.Size = New System.Drawing.Size(311, 36)
        Me.frmApproveReject.TabIndex = 371
        Me.frmApproveReject.TabStop = False
        '
        'optRejection
        '
        Me.optRejection.AutoSize = True
        Me.optRejection.Location = New System.Drawing.Point(97, 11)
        Me.optRejection.Name = "optRejection"
        Me.optRejection.Size = New System.Drawing.Size(67, 16)
        Me.optRejection.TabIndex = 2
        Me.optRejection.Text = "Rejection"
        Me.optRejection.UseVisualStyleBackColor = True
        '
        'optApproval
        '
        Me.optApproval.AutoSize = True
        Me.optApproval.Location = New System.Drawing.Point(6, 11)
        Me.optApproval.Name = "optApproval"
        Me.optApproval.Size = New System.Drawing.Size(67, 16)
        Me.optApproval.TabIndex = 1
        Me.optApproval.Text = "Approval"
        Me.optApproval.UseVisualStyleBackColor = True
        '
        'optWait
        '
        Me.optWait.AutoSize = True
        Me.optWait.Location = New System.Drawing.Point(180, 11)
        Me.optWait.Name = "optWait"
        Me.optWait.Size = New System.Drawing.Size(106, 16)
        Me.optWait.TabIndex = 3
        Me.optWait.Text = "Wait for Approve"
        Me.optWait.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(687, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(20, 13)
        Me.Label6.TabIndex = 277
        Me.Label6.Text = "To"
        '
        'txtFromApply
        '
        Me.txtFromApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFromApply.Location = New System.Drawing.Point(634, 39)
        Me.txtFromApply.MaxLength = 10
        Me.txtFromApply.Name = "txtFromApply"
        Me.txtFromApply.Size = New System.Drawing.Size(50, 20)
        Me.txtFromApply.TabIndex = 4
        '
        'cmdApply
        '
        Me.cmdApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdApply.Location = New System.Drawing.Point(763, 37)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(62, 23)
        Me.cmdApply.TabIndex = 0
        Me.cmdApply.TabStop = False
        Me.cmdApply.Text = "&Apply"
        '
        'txtToApply
        '
        Me.txtToApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtToApply.Location = New System.Drawing.Point(707, 39)
        Me.txtToApply.MaxLength = 10
        Me.txtToApply.Name = "txtToApply"
        Me.txtToApply.Size = New System.Drawing.Size(50, 20)
        Me.txtToApply.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 12)
        Me.Label1.TabIndex = 383
        Me.Label1.Text = "Item No:"
        '
        'txtItmNo
        '
        Me.txtItmNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmNo.Location = New System.Drawing.Point(65, 40)
        Me.txtItmNo.MaxLength = 30
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(114, 20)
        Me.txtItmNo.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(-285, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 391
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
        Me.menuStrip.TabIndex = 392
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
        'SSTab1
        '
        Me.SSTab1.Controls.Add(Me.tpMIM00002_1)
        Me.SSTab1.Controls.Add(Me.tpMIM00002_2)
        Me.SSTab1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.SSTab1.Location = New System.Drawing.Point(0, 76)
        Me.SSTab1.Name = "SSTab1"
        Me.SSTab1.SelectedIndex = 0
        Me.SSTab1.Size = New System.Drawing.Size(954, 523)
        Me.SSTab1.TabIndex = 44
        '
        'tpMIM00002_1
        '
        Me.tpMIM00002_1.Controls.Add(Me.grdSummary)
        Me.tpMIM00002_1.Location = New System.Drawing.Point(4, 22)
        Me.tpMIM00002_1.Name = "tpMIM00002_1"
        Me.tpMIM00002_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMIM00002_1.Size = New System.Drawing.Size(946, 497)
        Me.tpMIM00002_1.TabIndex = 0
        Me.tpMIM00002_1.Text = "(1) Summary"
        Me.tpMIM00002_1.UseVisualStyleBackColor = True
        '
        'grdSummary
        '
        Me.grdSummary.AllowUserToAddRows = False
        Me.grdSummary.AllowUserToDeleteRows = False
        Me.grdSummary.ColumnHeadersHeight = 20
        Me.grdSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdSummary.Location = New System.Drawing.Point(6, 6)
        Me.grdSummary.Name = "grdSummary"
        Me.grdSummary.RowHeadersWidth = 20
        Me.grdSummary.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdSummary.RowTemplate.Height = 16
        Me.grdSummary.Size = New System.Drawing.Size(937, 488)
        Me.grdSummary.TabIndex = 368
        '
        'tpMIM00002_2
        '
        Me.tpMIM00002_2.Controls.Add(Me.chkWait_dtl)
        Me.tpMIM00002_2.Controls.Add(Me.chkReject_dtl)
        Me.tpMIM00002_2.Controls.Add(Me.chkApprove_dtl)
        Me.tpMIM00002_2.Controls.Add(Me.Label4)
        Me.tpMIM00002_2.Controls.Add(Me.txtEngDsc_dtl)
        Me.tpMIM00002_2.Controls.Add(Me.Label3)
        Me.tpMIM00002_2.Controls.Add(Me.txtVenItm_dtl)
        Me.tpMIM00002_2.Controls.Add(Me.cmdLastD)
        Me.tpMIM00002_2.Controls.Add(Me.cmdPrvD)
        Me.tpMIM00002_2.Controls.Add(Me.cmdNextD)
        Me.tpMIM00002_2.Controls.Add(Me.cmdFirstD)
        Me.tpMIM00002_2.Controls.Add(Me.GroupBox3)
        Me.tpMIM00002_2.Controls.Add(Me.txtmodvol)
        Me.tpMIM00002_2.Controls.Add(Me.txtCusVen)
        Me.tpMIM00002_2.Controls.Add(Me.txtVenNo)
        Me.tpMIM00002_2.Controls.Add(Me.cboPCPrc)
        Me.tpMIM00002_2.Controls.Add(Me.optSearch1)
        Me.tpMIM00002_2.Controls.Add(Me.optSearch0)
        Me.tpMIM00002_2.Controls.Add(Me.Label30)
        Me.tpMIM00002_2.Controls.Add(Me.txtPurOrd)
        Me.tpMIM00002_2.Controls.Add(Me.txtVol)
        Me.tpMIM00002_2.Controls.Add(Me.txtColCde)
        Me.tpMIM00002_2.Controls.Add(Me.Label39)
        Me.tpMIM00002_2.Controls.Add(Me.txtMtrCtn)
        Me.tpMIM00002_2.Controls.Add(Me.Label40)
        Me.tpMIM00002_2.Controls.Add(Me.Label56)
        Me.tpMIM00002_2.Controls.Add(Me.GroupBox5)
        Me.tpMIM00002_2.Controls.Add(Me.optCtrSiz3)
        Me.tpMIM00002_2.Controls.Add(Me.optCtrSiz4)
        Me.tpMIM00002_2.Controls.Add(Me.optCtrSiz0)
        Me.tpMIM00002_2.Controls.Add(Me.optCtrSiz1)
        Me.tpMIM00002_2.Controls.Add(Me.optCtrSiz2)
        Me.tpMIM00002_2.Controls.Add(Me.txtCustUM)
        Me.tpMIM00002_2.Controls.Add(Me.Label27)
        Me.tpMIM00002_2.Location = New System.Drawing.Point(4, 22)
        Me.tpMIM00002_2.Name = "tpMIM00002_2"
        Me.tpMIM00002_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMIM00002_2.Size = New System.Drawing.Size(946, 497)
        Me.tpMIM00002_2.TabIndex = 1
        Me.tpMIM00002_2.Text = "(2) Detail"
        Me.tpMIM00002_2.UseVisualStyleBackColor = True
        '
        'chkWait_dtl
        '
        Me.chkWait_dtl.AutoSize = True
        Me.chkWait_dtl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkWait_dtl.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.chkWait_dtl.Location = New System.Drawing.Point(488, 8)
        Me.chkWait_dtl.Name = "chkWait_dtl"
        Me.chkWait_dtl.Size = New System.Drawing.Size(106, 17)
        Me.chkWait_dtl.TabIndex = 14
        Me.chkWait_dtl.Text = "Wait for Approve"
        Me.chkWait_dtl.UseVisualStyleBackColor = True
        '
        'chkReject_dtl
        '
        Me.chkReject_dtl.AutoSize = True
        Me.chkReject_dtl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkReject_dtl.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.chkReject_dtl.Location = New System.Drawing.Point(417, 7)
        Me.chkReject_dtl.Name = "chkReject_dtl"
        Me.chkReject_dtl.Size = New System.Drawing.Size(57, 17)
        Me.chkReject_dtl.TabIndex = 13
        Me.chkReject_dtl.Text = "Reject"
        Me.chkReject_dtl.UseVisualStyleBackColor = True
        '
        'chkApprove_dtl
        '
        Me.chkApprove_dtl.AutoSize = True
        Me.chkApprove_dtl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkApprove_dtl.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.chkApprove_dtl.Location = New System.Drawing.Point(334, 7)
        Me.chkApprove_dtl.Name = "chkApprove_dtl"
        Me.chkApprove_dtl.Size = New System.Drawing.Size(66, 17)
        Me.chkApprove_dtl.TabIndex = 12
        Me.chkApprove_dtl.Text = "Approve"
        Me.chkApprove_dtl.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(23, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 387
        Me.Label4.Text = "Item Name"
        '
        'txtEngDsc_dtl
        '
        Me.txtEngDsc_dtl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtEngDsc_dtl.Location = New System.Drawing.Point(91, 32)
        Me.txtEngDsc_dtl.MaxLength = 10
        Me.txtEngDsc_dtl.Name = "txtEngDsc_dtl"
        Me.txtEngDsc_dtl.Size = New System.Drawing.Size(514, 20)
        Me.txtEngDsc_dtl.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(23, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 385
        Me.Label3.Text = "Item No"
        '
        'txtVenItm_dtl
        '
        Me.txtVenItm_dtl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtVenItm_dtl.Location = New System.Drawing.Point(91, 6)
        Me.txtVenItm_dtl.MaxLength = 10
        Me.txtVenItm_dtl.Name = "txtVenItm_dtl"
        Me.txtVenItm_dtl.Size = New System.Drawing.Size(114, 20)
        Me.txtVenItm_dtl.TabIndex = 10
        '
        'cmdLastD
        '
        Me.cmdLastD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdLastD.Location = New System.Drawing.Point(814, 20)
        Me.cmdLastD.Name = "cmdLastD"
        Me.cmdLastD.Size = New System.Drawing.Size(54, 26)
        Me.cmdLastD.TabIndex = 18
        Me.cmdLastD.TabStop = False
        Me.cmdLastD.Text = ">>|"
        '
        'cmdPrvD
        '
        Me.cmdPrvD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdPrvD.Location = New System.Drawing.Point(702, 20)
        Me.cmdPrvD.Name = "cmdPrvD"
        Me.cmdPrvD.Size = New System.Drawing.Size(54, 26)
        Me.cmdPrvD.TabIndex = 16
        Me.cmdPrvD.TabStop = False
        Me.cmdPrvD.Text = "<"
        '
        'cmdNextD
        '
        Me.cmdNextD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdNextD.Location = New System.Drawing.Point(758, 20)
        Me.cmdNextD.Name = "cmdNextD"
        Me.cmdNextD.Size = New System.Drawing.Size(54, 26)
        Me.cmdNextD.TabIndex = 17
        Me.cmdNextD.TabStop = False
        Me.cmdNextD.Text = ">"
        '
        'cmdFirstD
        '
        Me.cmdFirstD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdFirstD.Location = New System.Drawing.Point(646, 20)
        Me.cmdFirstD.Name = "cmdFirstD"
        Me.cmdFirstD.Size = New System.Drawing.Size(54, 26)
        Me.cmdFirstD.TabIndex = 15
        Me.cmdFirstD.TabStop = False
        Me.cmdFirstD.Text = "|<<"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.grdDetail)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(8, 62)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(935, 435)
        Me.GroupBox3.TabIndex = 363
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Modified Information"
        '
        'grdDetail
        '
        Me.grdDetail.AllowUserToAddRows = False
        Me.grdDetail.AllowUserToDeleteRows = False
        Me.grdDetail.ColumnHeadersHeight = 20
        Me.grdDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdDetail.Location = New System.Drawing.Point(7, 19)
        Me.grdDetail.Name = "grdDetail"
        Me.grdDetail.RowHeadersWidth = 20
        Me.grdDetail.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDetail.RowTemplate.Height = 16
        Me.grdDetail.Size = New System.Drawing.Size(928, 413)
        Me.grdDetail.TabIndex = 369
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
        'MIM00002
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.frmApproveReject)
        Me.Controls.Add(Me.txtFromApply)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtToApply)
        Me.Controls.Add(Me.txtItmNo)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.SSTab1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MIM00002"
        Me.Text = "MIM00002 - Item Master Approval & Rejection (WT) (MIM02)"
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmApproveReject.ResumeLayout(False)
        Me.frmApproveReject.PerformLayout()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.SSTab1.ResumeLayout(False)
        Me.tpMIM00002_1.ResumeLayout(False)
        CType(Me.grdSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpMIM00002_2.ResumeLayout(False)
        Me.tpMIM00002_2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grdDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region




    Private Sub Check1_Click()

    End Sub

    Private Sub chkApprove_dtl_Click()

        If readingindex >= 0 And readingindex <= rs_ZSITMDAT.Tables("result").Rows.Count - 1 Then

            If isSave = False Then
                If chkApprove_dtl.Checked = True Then
                    chkReject_dtl.Checked = False
                    chkWait_dtl.Checked = False
                End If
                If chkApprove_dtl.Checked = True And chkReject_dtl.Checked = False And chkWait_dtl.Checked = False Then
                    chkReject_dtl.Checked = False
                    chkWait_dtl.Checked = False
                    rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage") = "A"
                ElseIf chkApprove_dtl.Checked = False And chkReject_dtl.Checked = True And chkWait_dtl.Checked = False Then
                    chkApprove_dtl.Checked = False
                    chkWait_dtl.Checked = False
                    rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage") = "R"
                ElseIf chkApprove_dtl.Checked = False And chkReject_dtl.Checked = False And chkWait_dtl.Checked = True Then
                    chkApprove_dtl.Checked = False
                    chkReject_dtl.Checked = False
                    rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage") = "W"
                End If
            End If
            If SSTab1.SelectedIndex = 1 Then
                Recordstatus = True
            End If

        End If


    End Sub

    Private Sub chkReject_dtl_Click()

        If readingindex >= 0 And readingindex <= rs_ZSITMDAT.Tables("result").Rows.Count - 1 Then
            If isSave = False Then
                If chkReject_dtl.Checked = True Then
                    chkApprove_dtl.Checked = False
                    chkWait_dtl.Checked = False
                End If
                If chkApprove_dtl.Checked = True And chkReject_dtl.Checked = False And chkWait_dtl.Checked = False Then
                    chkReject_dtl.Checked = False
                    chkWait_dtl.Checked = False
                    rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage") = "A"
                ElseIf chkApprove_dtl.Checked = False And chkReject_dtl.Checked = True And chkWait_dtl.Checked = False Then
                    chkApprove_dtl.Checked = False
                    chkWait_dtl.Checked = False
                    rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage") = "R"
                ElseIf chkApprove_dtl.Checked = False And chkReject_dtl.Checked = False And chkWait_dtl.Checked = True Then
                    chkApprove_dtl.Checked = False
                    chkReject_dtl.Checked = False
                    rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage") = "W"
                End If
            End If
            If SSTab1.SelectedIndex = 1 Then
                Recordstatus = True
            End If
        End If
    End Sub

    Private Sub chkWait_dtl_Click()
        If readingindex >= 0 And readingindex <= rs_ZSITMDAT.Tables("result").Rows.Count - 1 Then
            If isSave = False Then
                If chkWait_dtl.Checked = True Then
                    chkApprove_dtl.Checked = False
                    chkReject_dtl.Checked = False
                End If
                If chkApprove_dtl.Checked = True And chkReject_dtl.Checked = False And chkWait_dtl.Checked = False Then
                    chkReject_dtl.Checked = False
                    chkWait_dtl.Checked = False
                    rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage") = "A"
                ElseIf chkApprove_dtl.Checked = False And chkReject_dtl.Checked = True And chkWait_dtl.Checked = False Then
                    chkApprove_dtl.Checked = False
                    chkWait_dtl.Checked = False
                    rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage") = "R"
                ElseIf chkApprove_dtl.Checked = False And chkReject_dtl.Checked = False And chkWait_dtl.Checked = True Then
                    chkApprove_dtl.Checked = False
                    chkReject_dtl.Checked = False
                    rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage") = "W"
                End If
            End If
            If SSTab1.SelectedIndex = 1 Then
                Recordstatus = True
            End If
        End If
    End Sub

    Private Sub cmdApply_Click()
        Dim j As Integer

        If Val(txtFromApply.Text) = "0" Then
            MsgBox("The apply range cannot be 0")
            Call HighlightText(txtFromApply)
            Exit Sub
        End If

        If Val(txtToApply.Text) > rs_ZSITMDAT.Tables("RESULT").Rows.Count Then
            MsgBox("The apply range cannot larger than the total number of records.")
            Call HighlightText(txtToApply)
            Exit Sub
        End If

        If Val(txtFromApply.Text) > Val(txtToApply.Text) Then
            MsgBox("The apply range is invalid.")
            Call HighlightText(txtToApply)
            Exit Sub
        End If

        If optApproval.Checked = False And optRejection.Checked = False And optWait.Checked = False Then
            MsgBox("Please select options for Approval/Rejection/Wait for Approval !")
            optApproval.Focus()
            Exit Sub
        End If

        'Lester Wu 2004/07/09
        'Cater the First,Previous,Next ,Last Buttons function-- start
        SSTab1.SelectedIndex = 0
        'Cater the First,Previous,Next ,Last Buttons function-- end
        'xxxxxxxxxxxxxxxxxxxx

        ''
        For index9 As Integer = 0 To rs_ZSITMDAT.Tables("result").Rows.Count - 1
            If index9 >= Val(txtFromApply.Text) - 1 And index9 <= Val(txtToApply.Text) - 1 Then
                If optApproval.Checked = True Then
                    rs_ZSITMDAT.Tables("RESULT").Rows(index9)("zid_stage") = "A"
                    'Call ApproveReject(index9)

                ElseIf optRejection.Checked = True Then
                    rs_ZSITMDAT.Tables("RESULT").Rows(index9)("zid_stage") = "R"
                    'Call ApproveReject(index9)

                ElseIf optWait.Checked = True Then
                    rs_ZSITMDAT.Tables("RESULT").Rows(index9)("zid_stage") = "W"
                End If

            End If

        Next
        'goto

        'If grdSummary.SelBookmarks.count <= 0 Then
        '    rs_ZSITMDAT.MoveFirst()
        '    While rs_ZSITMDAT.EOF = False
        '        If index9 >= Val(txtFromApply.Text) And index9 <= Val(txtToApply.Text) Then
        '            If optApproval.Checked = True Then
        '                rs_ZSITMDAT.Tables("RESULT").Rows(index9)("zid_stage")= "A"

        '            ElseIf optRejection.Checked = True Then
        '                rs_ZSITMDAT.Tables("RESULT").Rows(index9)("zid_stage")= "R"

        '            ElseIf optWait.Checked = True Then
        '                rs_ZSITMDAT.Tables("RESULT").Rows(index9)("zid_stage")= "W"
        '            End If
        '        End If
        '        rs_ZSITMDAT.MoveNext()
        '    End While
        'Else
        '    For j = 0 To grdSummary.SelBookmarks.count - 1
        '        rs_ZSITMDAT.AbsolutePosition = grdSummary.SelBookmarks(j)
        '        With rs_ZSITMDAT
        '            If optApproval.Checked = True Then
        '                rs_ZSITMDAT.Tables("RESULT").Rows(index9)("zid_stage")= "A"
        '                Call ApproveReject()
        '            ElseIf optRejection.Checked = True Then
        '                rs_ZSITMDAT.Tables("RESULT").Rows(index9)("zid_stage")= "R"
        '                Call ApproveReject()
        '            ElseIf optWait.Checked = True Then
        '                rs_ZSITMDAT.Tables("RESULT").Rows(index9)("zid_stage")= "W"
        '            End If
        '        End With
        '    Next
        'End If
        'rs_ZSITMDAT.MoveFirst()
        'tempzzzzz

        chkApprove_dtl.Refresh()
        chkReject_dtl.Refresh()
        Recordstatus = True
    End Sub

    Private Sub cmdAssort_Click()
        'IMM00002_2.Show()
        '        IMM00002_2.Show(vbModal)
    End Sub



    Private Sub cmdClear_Click()
        Dim YesNoCancel As Integer

        If Recordstatus = True Then
            YesNoCancel = MsgBox("Record updated!" & vbCrLf & "Save before clear?", vbYesNoCancel + vbDefaultButton1 + vbQuestion, "")

            If YesNoCancel = vbYes Then
                If mmdSave.Enabled Then

                    Call CmdSave_Click()

                    If save_ok = True Then
                        Call setStatus("Clear")
                    Else
                        Exit Sub
                    End If
                Else
                    If Enq_right_local = False Then
                        MsgBox("Sorry! You do not right to save!")
                        Call setStatus("Clear")
                    End If
                End If
            ElseIf YesNoCancel = vbNo Then
                Call setStatus("Clear")
            ElseIf YesNoCancel = vbCancel Then
                Exit Sub
            End If
        Else
            Call setStatus("Clear")
            txtItmNo.Focus()
        End If

    End Sub

    Private Sub CmdExit_Click()
        Me.Close()

    End Sub

    Private Sub cmdFind_Click()

        'If txtCusVenFm.Text <> "" And txtCusVenTo.Text = "" Then
        '    txtCusVenTo.Text = txtCusVenFm.Text
        'End If


        Dim rs As DataSet
        Dim S As String
        Dim i As Integer
        Dim itmsts As String
        Dim Mode As String


        '    If chkApprove.checked = false And chkReject.checked = false And chkWait.checked = false Then
        '        chkWait.checked = true
        '    End If


        '    If chkWait.checked = true Then Mode = "W"
        '    If chkReject.checked = true Then Mode = "R"
        '    If chkApprove.checked = true Then Mode = "A"


        S = "SP_SELECT_ZSITMDAT '' ,'" & txtItmNo.Text & "','" & "W" & "'"
        Cursor = Cursors.WaitCursor
        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_ZSITMDAT, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
            Exit Sub
        Else
            With rs_ZSITMDAT
                For i2 As Integer = 0 To .Tables("RESULT").Columns.Count - 1
                    .Tables("RESULT").Columns(i2).ReadOnly = False
                Next i2
            End With

            If rs_ZSITMDAT.Tables("result").Rows.Count = 0 Then
                Call setStatus("Init")
                MsgBox("Record not found!")
            Else
                Call setStatus("Updating")
                Call Find_Detail()
                txtFromApply.Text = "1"
                txtToApply.Text = rs_ZSITMDAT.Tables("RESULT").Rows.Count
                Call fillCount()
                Call Display()
                grdSummary.Focus()

            End If
        End If
        Cursor = Cursors.Default
        SSTab1.SelectedIndex = 0


    End Sub



    Private Sub cmdFirstD_Click()
        readingindex = 0
        grdSummary.Focus()
        SSTab1.SelectedIndex = 0

        'If SSTab1.selectedindex = 0 Then
        'If Not rs_ZSITMDAT Is Nothing Then
        '    If Not rs_ZSITMDAT.BOF Then
        '        rs_ZSITMDAT.MoveFirst()
        '        grdSummary.Focus()
        '    End If

        '    Call SSTab1_Click(0)
        'End If
        'temp

        'Else
        '    If Not rs_ZSITMDAT_dtl.BOF Then
        '        rs_ZSITMDAT_dtl.MoveFirst
        '        grdDetail.SetFocus
        '    End If
        'End If
    End Sub

    Private Sub cmdIAR00001_Click()

        IAR00001.Show()
    End Sub



    Private Sub cmdLastD_Click()

        readingindex = rs_ZSITMDAT.Tables("result").Rows.Count - 1
        grdSummary.Focus()
        SSTab1.SelectedIndex = 0



        ''If SSTab1.selectedindex = 0 Then
        'If Not rs_ZSITMDAT Is Nothing Then
        '    If Not rs_ZSITMDAT.EOF Then
        '        rs_ZSITMDAT.MoveLast()
        '        grdSummary.Focus()
        '    End If

        '    Call SSTab1_Click(0)
        'End If
        'Else
        '    If Not rs_ZSITMDAT_dtl.EOF Then
        '        rs_ZSITMDAT_dtl.MoveLast
        '        grdDetail.SetFocus
        '    End If
        'End If
    End Sub




    Private Sub cmdNextD_Click()
        readingindex = readingindex + 1
        If readingindex > rs_ZSITMDAT.Tables("result").Rows.Count - 1 Then

            readingindex = rs_ZSITMDAT.Tables("result").Rows.Count - 1
        End If

        grdSummary.Focus()
        SSTab1.SelectedIndex = 0

        'If SSTab1.selectedindex = 0 Then
        'If Not rs_ZSITMDAT Is Nothing Then
        '    If rs_ZSITMDAT.Bookmark < rs_ZSITMDAT.Tables("RESULT").Rows.Count Then
        '        rs_ZSITMDAT.MoveNext()
        '        grdSummary.Focus()
        '    End If

        '    Call SSTab1_Click(0)
        'End If
        'Else
        '    If rs_ZSITMDAT_dtl.bookmark < rs_ZSITMDAT_dtl.Tables("RESULT").Rows.count Then
        '        rs_ZSITMDAT_dtl.MoveNext
        '        grdDetail.SetFocus
        '    End If
        'End If
    End Sub

    Private Sub cmdPrintList_Click()
        'PrintList = PrintList + IIf(PrintList = "", rs_ZSITMDAT.Tables("RESULT").Rows(index)("zid_venitm"), "*" + rs_ZSITMDAT.Tables("RESULT").Rows(index)("zid_venitm"))
        ''IAR00001.txtItmNo.Text = IAR00001.txtItmNo.Text + IIf(IAR00001.txtItmNo.Text = "", rs_ZSITMDAT.Tables("RESULT").Rows(index)("zid_venitm"), "*" + rs_ZSITMDAT.Tables("RESULT").Rows(index)("zid_venitm"))
        'temp?

    End Sub


    Private Sub cmdPrvD_Click()
        readingindex = readingindex - 1
        If readingindex < 0 Then
            readingindex = 0
        End If
        grdSummary.Focus()
        SSTab1.SelectedIndex = 0

        'If SSTab1.selectedindex = 0 Then
        'If Not rs_ZSITMDAT Is Nothing Then
        '    If rs_ZSITMDAT.Bookmark > 1 Then
        '        rs_ZSITMDAT.MovePrevious()
        '        grdSummary.Focus()
        '    End If

        '    Call SSTab1_Click(0)
        'End If
        'Else
        '    If rs_ZSITMDAT_dtl.bookmark > 1 Then
        '        rs_ZSITMDAT_dtl.MovePrevious
        '        grdDetail.SetFocus
        '    End If
        'End If

    End Sub

    Private Sub CmdSave_Click()
        'goto
        Cursor = Cursors.WaitCursor

        Dim S As String
        Dim typ As String
        Dim rs As DataSet
        Dim IsUpdated As Boolean

        IsUpdated = False
        isSave = True

        If Recordstatus = True Then

            '*** for Save record to SQL Server

            If Not rs_ZSITMDAT.Tables("RESULT").Rows.Count = 0 Then
                For index As Integer = 0 To rs_ZSITMDAT.Tables("RESULT").Rows.Count - 1
                    If rs_ZSITMDAT.Tables("RESULT").Rows(index)("zid_stage") <> rs_ZSITMDAT.Tables("RESULT").Rows(index)("old_stage") Then
                        If Not ChecktimeStamp(index) Then
                            MsgBox("The data has been modified by others, could not save!")
                            Cursor = Cursors.Default
                            save_ok = False
                            Exit Sub
                        Else

                            S = "SP_update_ZSITMDAT  ''  ,'" & rs_ZSITMDAT.Tables("RESULT").Rows(index)("zid_itmno") & "','" & rs_ZSITMDAT.Tables("RESULT").Rows(index)("zid_seqno") & "','" & _
                                rs_ZSITMDAT.Tables("RESULT").Rows(index)("zid_mpono") & "','" & Format(rs_ZSITMDAT.Tables("RESULT").Rows(index)("zid_credat"), "yyyy/MM/dd hh:mm:ss tt") & "','" & _
                                rs_ZSITMDAT.Tables("RESULT").Rows(index)("zid_stage") & "','" & gsUsrID & "'"

                            gspStr = S
                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            If rtnLong <> RC_SUCCESS Then
                                IsUpdated = False
                                MsgBox("Error on    saving  SP_update_ZSITMDAT:" & rtnStr)
                                Exit Sub
                            Else
                                IsUpdated = True
                            End If

                        End If

                    End If
                Next
            End If



            If IsUpdated Then
                save_ok = True
            Else
                save_ok = False
            End If

        End If



        Call setStatus("Save")
        isSave = False

        Cursor = Cursors.Default
    End Sub



    Private Sub Form_Load()
        AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        SSTab1.SelectedIndex = 0

        Dim v

        '#If useMTS Then
        '        Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If
        Cursor = Cursors.WaitCursor
        For Each v In Me.Controls
            If IsDataGrid(v) Then
                v.BackColor = &H80000004 ' Gray color
            End If
        Next

        '        gsConnStr = getConnectionString()

        Me.KeyPreview = True




        If gsCompanyGroup = "MSG" Then
            If gsCompany <> "MS" Then
                gsCompany = "MS"
                Call Update_gs_Value(gsCompany)
            End If
        Else
            '--- Update Company Code before execute ---
            If gsCompany = "ALL" Or gsCompany = "UC-G" Then
                '    gsCompany = SYM00001.cboCocde.Text
                gsCompany = gsDefaultCompany
                Call Update_gs_Value(gsCompany)
            End If
            '-----------------------------------------
        End If


        Call setStatus("Init")
        Call Formstartup(Me.Name)   'Set the form Starup position

        Cursor = Cursors.Default

    End Sub

    Private Sub setStatus(ByVal Mode As String)

        If Mode = "Init" Then
            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = True

            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdExit.Enabled = True
            mmdClear.Enabled = True
            mmdSearch.Enabled = False



            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False
            cmdFirstD.Enabled = False
            cmdLastD.Enabled = False
            cmdNextD.Enabled = False

            cmdPrvD.Enabled = False

            cmdApply.Enabled = False
            optApproval.Enabled = False
            optRejection.Enabled = False
            optWait.Enabled = False
            optApproval.Checked = False
            optRejection.Checked = False
            optWait.Checked = False
            txtFromApply.Enabled = False
            txtToApply.Enabled = False
            txtFromApply.Text = ""
            txtToApply.Text = ""

            '*** Summary
            txtItmNo.Text = ""
            grdSummary.Enabled = False
          
            '*** Detail
            txtVenItm_dtl.Text = ""
            txtEngDsc_dtl.Text = ""
            chkApprove_dtl.Checked = False
            chkReject_dtl.Checked = False
            chkApprove_dtl.Enabled = False
            chkReject_dtl.Enabled = False
            chkWait_dtl.Enabled = False

         
            txtItmNo.Enabled = True
           
            Call ResetDefaultDisp()
            Call SetStatusBar(Mode)

            '***Reset the flag
            Recordstatus = False

        ElseIf Mode = "Updating" Then
            mmdAdd.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdExit.Enabled = True
            mmdClear.Enabled = True

            cmdFirstD.Enabled = True
            cmdLastD.Enabled = True
            cmdNextD.Enabled = True
            cmdPrvD.Enabled = True

            cmdApply.Enabled = True
            optApproval.Enabled = True
            optRejection.Enabled = True
            optWait.Enabled = True
            txtFromApply.Enabled = True
            txtToApply.Enabled = True

         
            txtItmNo.Enabled = False
            chkApprove_dtl.Enabled = True
            chkReject_dtl.Enabled = True
            chkWait_dtl.Enabled = True
            grdSummary.Enabled = True
            grdDetail.Enabled = True

            '***Reset the flag
            Recordstatus = False

            Call SetStatusBar(Mode)
        ElseIf Mode = "Save" Then
            MsgBox("Record(s) Saved!")
            Call SetStatusBar(Mode)
            Call setStatus("Init")
            grdSummary.DataSource = Nothing
            grdDetail.DataSource = Nothing
        ElseIf Mode = "Delete" Then
            Call SetStatusBar(Mode)
        ElseIf Mode = "Clear" Then
            Call ResetDefaultDisp()
            Call setStatus("Init")
            Call SetStatusBar(Mode)
            grdSummary.DataSource = Nothing
            grdDetail.DataSource = Nothing
            rs_ZSITMDAT = Nothing
            rs_ZSITMDAT_dtl = Nothing
        End If


    End Sub

    Private Sub ResetDefaultDisp()


        StatusBar.Panels(0).Text = ""
        StatusBar.Panels(1).Text = ""


    End Sub

    Private Sub SetStatusBar(ByVal Mode As String)

        If Mode = "Init" Then
            StatusBar.Panels(0).Text = "Init"
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

    Private Sub Display_grdSummary()

        With grdSummary
            grdSummary.DataSource = rs_ZSITMDAT.Tables("RESULT")
            .Columns(0).HeaderText = "No."
            .Columns(0).ReadOnly = True
            .Columns(0).Width = 40

            .Columns(1).HeaderText = "Apv/Rej"
            '            .Columns(1).Button = True
            .Columns(1).ReadOnly = True
            .Columns(1).Width = 750 / 10

            .Columns(2).Visible = False 'Old Stage

            .Columns(3).HeaderText = "Item No"
            .Columns(3).ReadOnly = True
            .Columns(3).Width = 120

            .Columns(4).HeaderText = "Seq. No"
            .Columns(4).ReadOnly = True
            .Columns(4).Width = 750 / 10

            .Columns(5).HeaderText = "Item Name"
            .Columns(5).ReadOnly = True
            .Columns(5).Width = 180

            .Columns(6).HeaderText = "UM"
            .Columns(6).ReadOnly = True
            .Columns(6).Width = 750 / 10

            .Columns(7).HeaderText = "Curr"
            .Columns(7).ReadOnly = True
            .Columns(7).Width = 50

            .Columns(8).HeaderText = "Unit Price"
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(8).ReadOnly = True
            .Columns(8).Width = 80

            .Columns(9).HeaderText = "WT PO No."
            .Columns(9).ReadOnly = True
            .Columns(9).Width = 130

            .Columns(10).HeaderText = "Exception Message"
            .Columns(10).Width = 320
            .Columns(10).ReadOnly = True

            .Columns(11).HeaderText = "Create Date"
            .Columns(11).Width = 200
            .Columns(11).ReadOnly = True


            .Columns(12).Width = 0
            .Columns(12).Visible = False

            .Columns(13).Width = 0
            .Columns(13).Visible = False

            .Columns(14).Width = 0
            .Columns(14).Visible = False

            .Columns(15).Width = 0
            .Columns(15).Visible = False

        End With

    End Sub
    Private Sub fillCount()

        readingindex = 0

        For index As Integer = 0 To rs_ZSITMDAT.Tables("RESULT").Rows.Count - 1
            rs_ZSITMDAT.Tables("RESULT").Rows(index)("no") = index + 1
        Next

        'rs_ZSITMDAT.MoveFirst()
        'While rs_ZSITMDAT.EOF = False

        '    rs_ZSITMDAT.Tables("RESULT").Rows(index)("no") = rs_ZSITMDAT.Bookmark

        '    rs_ZSITMDAT.MoveNext()
        'End While
        'rs_ZSITMDAT.MoveFirst()
        'tempzz
    End Sub

    '*** display information on current item
    Private Sub Display()

        grdSummary.DataSource = rs_ZSITMDAT.Tables("RESULT")

        Call Display_grdSummary()

        '*** Set a default path for that image:
        On Error Resume Next

        'Display the RECORD information "Create Date" "Update Dare" "Last Update User"
        StatusBar.Panels(1).Text = Format(rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_credat"), "dd/MM/yyyy") & " " & Format(rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_upddat"), "dd/MM/yyyy") & _
                                  " " & rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_updusr")

        ' Write your code Display
        '
        ' >
        '   ...
        ' <
    End Sub
    Private Sub MIM00002_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        '    Private Sub Form_Unload(ByVal Cancel As Integer)
        'goto

        Dim YesNoCancel As Integer

        If Recordstatus = True Then
            YesNoCancel = MsgBox("Record updated!" & vbCrLf & "Save before clear?", vbYesNoCancel + vbDefaultButton1 + vbQuestion, "")

            If YesNoCancel = vbYes Then
                If mmdSave.Enabled Then

                    Call CmdSave_Click()

                    If save_ok = True Then
                        Me.Close()
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    If Enq_right_local = False Then
                        MsgBox("You do not have rights to save!")
                    End If
                End If
            ElseIf YesNoCancel = vbNo Then
                Call ResetDefaultDisp()
                '        Me.Close()
            ElseIf YesNoCancel = vbCancel Then
                e.Cancel = True
                Exit Sub
            End If
        Else
            '     Me.Close()
        End If
    End Sub



    Private Sub grdDetail_GotFocus()
        grdDetail.BackColor = Color.White

    End Sub

    Private Sub grdDetail_LostFocus()
        'grdDetail.BackColor = &H80000004 'gray color
    End Sub

    Private Sub grdSummary_ButtonClick(ByVal ColIndex As Integer)
        'Call grdSummary_DblClick()
    End Sub

    'Private Sub grdSummary_DblClick()
    '    'goto

    '    If grdSummary.col = 1 Then
    '        If Trim(rs_ZSITMDAT.Tables("RESULT").Rows(index)("zid_stage")) = "A" Then
    '            rs_ZSITMDAT.Tables("RESULT").Rows(index)("zid_stage")= "R"

    '        ElseIf Trim(rs_ZSITMDAT.Tables("RESULT").Rows(index)("zid_stage")) = "R" Then
    '            rs_ZSITMDAT.Tables("RESULT").Rows(index)("zid_stage")= "W"

    '        ElseIf Trim(rs_ZSITMDAT.Tables("RESULT").Rows(index)("zid_stage")) = "W" Then
    '            rs_ZSITMDAT.Tables("RESULT").Rows(index)("zid_stage")= "A"

    '        End If
    '        Recordstatus = True
    '    End If

    'End Sub

    Private Sub grdSummary_GotFocus()
        grdSummary.BackColor = Color.White
    End Sub

    Private Sub grdSummary_KeyPress(ByVal KeyAscii As Integer)
        'If KeyAscii = 32 Then
        '    If grdSummary.col = 0 Then
        '        Call grdSummary_DblClick()
        '    End If
        'End If
        'tempzzzzz

    End Sub

    Private Sub grdSummary_LostFocus()
        'grdSummary.BackColor = &H80000004 'gray color
    End Sub

    Private Function ChecktimeStamp(ByVal index99 As Integer) As Boolean

        Dim Save_TimeStamp As Long

        Dim S As String
        Dim rs As DataSet
        Dim rs_CheckTimeStamp As DataSet


        S = "SP_SELECT_ZSITMDAT_timstp   '','" & rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_itmno") & "','" & rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_seqno") & "','" & _
            rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_mpono") & "','" & Format(rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_credat"), "yyyy/MM/dd hh:mm:ss tt") & "'"

        gspStr = S
        Cursor = Cursors.WaitCursor

        rtnLong = execute_SQLStatement(gspStr, rs_CheckTimeStamp, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  SP_SELECT_ZSITMDAT_timstp  :" & rtnStr)
            Exit Function
        Else
            If rs_ZSITMDAT.Tables("RESULT").Rows.Count = 0 Then
                Save_TimeStamp = 9999
            Else
                Save_TimeStamp = rs_CheckTimeStamp.Tables("RESULT").Rows(0)("zid_timstp")
            End If

        End If

        'Write your code for Compare
        If rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_timstp") <> Save_TimeStamp Then
            ChecktimeStamp = False
        Else
            ChecktimeStamp = True
        End If

    End Function

    Private Sub grdSummary_RowColChange(ByVal LastRow As Object, ByVal LastCol As Integer)
    End Sub

    Private Sub Label5_Click()

    End Sub

    Private Sub lblVenItm_Click()

    End Sub

    Private Sub optRejection_Click()

    End Sub

    Private Sub SSTab1_Click(ByVal PreviousTab As Integer)
        'goto
        If SSTab1.SelectedIndex = 1 Then

            'Cater the First,Previous,Next ,Last Buttons function -- start
            If Not rs_ZSITMDAT Is Nothing Then
                If Not rs_ZSITMDAT.Tables("RESULT") Is Nothing Then
                    'none or one record
                    If rs_ZSITMDAT.Tables("RESULT").Rows.Count <= 1 Then
                        cmdFirstD.Enabled = False
                        cmdPrvD.Enabled = False
                        cmdNextD.Enabled = False
                        cmdLastD.Enabled = False
                    Else
                        'more than one record
                        cmdFirstD.Enabled = False
                        cmdPrvD.Enabled = False
                        cmdNextD.Enabled = False
                        cmdLastD.Enabled = False
                        If readingindex = 0 Then
                            cmdNextD.Enabled = True
                            cmdLastD.Enabled = True
                        ElseIf readingindex = rs_ZSITMDAT.Tables("RESULT").Rows.Count - 1 Then

                            cmdFirstD.Enabled = True
                            cmdPrvD.Enabled = True
                        Else
                            cmdFirstD.Enabled = True
                            cmdPrvD.Enabled = True
                            cmdNextD.Enabled = True
                            cmdLastD.Enabled = True
                        End If
                    End If
                End If
            End If
            'Cater the First,Previous,Next ,Last Buttons function -- end
            'xxxxxxxxxxxxxxxxxxxx

            If isSave = False Then
                If Not rs_ZSITMDAT Is Nothing Then
                    If Not rs_ZSITMDAT.Tables("RESULT") Is Nothing Then
                        If readingindex >= 0 And readingindex <= rs_ZSITMDAT.Tables("result").Rows.Count - 1 Then
                            StatusBar.Panels(1).Text = Format(rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_credat"), "dd/MM/yyyy") & " " & Format(rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_upddat"), "dd/MM/yyyy") & _
                                                       " " & rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_updusr")
                            Call Find_Detail()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub SSTab1_GotFocus()
    End Sub

    Private Sub txtCusVen_Change()

    End Sub

    'Private Sub txtCusVenFm_GotFocus()
    'Call HighlightText(txtCusVenFm)
    'End Sub

    'Private Sub txtCusVenTo_GotFocus()
    'Call HighlightText(txtCusVenTo)
    'End Sub

    Private Sub txtFromApply_GotFocus()
    End Sub

    'Private Sub txtFromDate_GotFocus()
    'Call HighlightText(txtFromDate)
    'End Sub

    'Private Sub txtFromLine_GotFocus()
    'Call HighlightText(txtFromLine)
    'End Sub

    'Private Sub txtToLine_GotFocus()
    'Call HighlightText(txtToLine)
    'End Sub

    'Private Sub txtToDate_GotFocus()
    'Call HighlightText(txtToDate)
    'End Sub

    'Private Sub txtFromVendor_GotFocus()
    'Call HighlightText(txtFromVendor)
    'End Sub

    'Private Sub txtToVendor_GotFocus()
    'Call HighlightText(txtToVendor)
    'End Sub

    'Private Sub txtFromPrdVen_GotFocus()
    'Call HighlightText(txtFromPrdVen)
    'End Sub

    'Private Sub txtToPrdVen_GotFocus()
    'Call HighlightText(txtToPrdVen)
    'End Sub
    Private Sub txtToApply_GotFocus()
    End Sub

    Private Sub txtToApply_KeyPress(ByVal KeyAscii As Integer)
        'goto

    End Sub

    Private Sub txtFromApply_KeyPress(ByVal KeyAscii As Integer)
    End Sub

    Private Sub txtFromDate_KeyPress(ByVal KeyAscii As Integer)
        'If KeyAscii <> 8 Then
        '    'If Len(txtFromDate.Text) = 2 Then
        '    '    txtFromDate.Text = txtFromDate.Text + "/"
        '    '    txtFromDate.SelStart = 3
        '    'ElseIf Len(txtFromDate.Text) = 5 Then
        '    '    txtFromDate.Text = txtFromDate.Text + "/"
        '    '    txtFromDate.SelStart = 6
        '    'End If
        'End If
        '
        'If (InStr("0123456789", Chr(KeyAscii)) = 0) And (KeyAscii > 31 Or KeyAscii < 0) Then
        '    KeyAscii = 0
        'ElseIf (Len(txtFromDate.Text) + 1 > 10) And (KeyAscii > 31 Or KeyAscii < 0) Then
        '    'Msg ("M00044")
        '    KeyAscii = 0
        '    txtToDate.SetFocus
        '    'txtFromDate.SetFocus
        'End If
    End Sub

    Private Sub txtFromDate_LostFocus()
        'If txtFromDate.Text <> "" Then
        '
        '    If Len(txtFromDate.Text) <> 10 Then
        '        msg ("M00206")
        '        Call HighlightText(txtFromDate)
        '        txtFromDate.SetFocus
        '        Exit Sub
        '    End If
        '
        '    If CheckDate(txtFromDate.Text) = False Then
        '        msg ("M00206")
        '        Call HighlightText(txtFromDate)
        '        txtFromDate.SetFocus
        '        Exit Sub
        '    End If
        'End If
    End Sub

    Private Sub txtToDate_KeyPress(ByVal KeyAscii As Integer)
        'If KeyAscii <> 8 Then
        '    If Len(txtToDate.Text) = 2 Then
        '        txtToDate.Text = txtToDate.Text + "/"
        '        txtToDate.SelStart = 3
        '    ElseIf Len(txtToDate.Text) = 5 Then
        '        txtToDate.Text = txtToDate.Text + "/"
        '        txtToDate.SelStart = 6
        '    End If
        'End If
        '
        'If (InStr("0123456789", Chr(KeyAscii)) = 0) And (KeyAscii > 31 Or KeyAscii < 0) Then
        '    KeyAscii = 0
        'ElseIf (Len(txtToDate.Text) + 1 > 10) And (KeyAscii > 31 Or KeyAscii < 0) Then
        '    'Msg ("M00044")
        '    KeyAscii = 0
        '    txtFromLine.SetFocus
        '    'txtToDate.SetFocus
        'End If
    End Sub

    Private Sub txtToDate_LostFocus()
        'If txtToDate.Text <> "" Then
        '
        '    If Len(txtToDate.Text) <> 10 Then
        '        msg ("M00206")
        '        Call HighlightText(txtToDate)
        '        txtToDate.SetFocus
        '        Exit Sub
        '    End If
        '
        '    If CheckDate(txtToDate.Text) = False Then
        '        msg ("M00206")
        '        Call HighlightText(txtToDate)
        '        txtToDate.SetFocus
        '        Exit Sub
        '    End If
        'End If
    End Sub

    Private Sub Find_Detail()


        Dim rs As DataSet
        Dim S As String
        Dim i As Integer

        S = "SP_SELECT_ZSITMDAT_DTL  '','" & rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_itmno") & "','" & rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_seqno") & "','" & _
                                    rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_mpono") & "','" & Format(rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_credat"), "yyyy/MM/dd hh:mm:ss tt") & "'"

        Cursor = Cursors.WaitCursor
        '        S = "SP_SELECT_ZSITMDAT '' ,'" & txtItmNo.Text & "','" & "W" & "'"
        Cursor = Cursors.WaitCursor
        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_ZSITMDAT_dtl, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
            Exit Sub
        Else
            With rs_ZSITMDAT_dtl
                For i2 As Integer = 0 To .Tables("RESULT").Columns.Count - 1
                    .Tables("RESULT").Columns(i2).ReadOnly = False
                Next i2
            End With

            If rs_ZSITMDAT.Tables("result").Rows.Count = 0 Then
                Call setStatus("Init")
                MsgBox("Record not found!")
            Else
                Call setStatus("Updating")
                Call Display_grdDetail()
            End If
        End If

    End Sub

    Private Sub Display_grdDetail()

        grdDetail.DataSource = rs_ZSITMDAT_dtl.Tables("RESULT")

        With grdDetail

            Me.txtVenItm_dtl.Text = rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_itmno")
            Me.txtEngDsc_dtl.Text = rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("Zil_ItmNam")

            .Columns(0).HeaderText = "Field Name"
            '.Columns(0).Locked = True
            .Columns(0).Width = 150

            .Columns(1).HeaderText = "Before"
            '.Columns(2).Locked = True
            .Columns(1).Width = 300

            .Columns(2).HeaderText = "After"
            '.Columns(3).Locked = True
            .Columns(2).Width = 300
        End With

    End Sub

    Private Sub txtVenitm_GotFocus()
        Call HighlightText(txtItmNo)
    End Sub

    Public Sub ApproveReject(ByVal index99 As Integer)
        Dim tmp_BK As Integer
        Dim rs As DataSet
        Dim S As String
        Dim ans As Boolean
        Dim asked As Boolean
        Dim norecord As Boolean

        If rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_stage") = "R" Then

            chkReject_dtl.Checked = True
            chkApprove_dtl.Checked = False
            chkWait_dtl.Checked = False

            If rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_itmtyp") = "ASS" Then

                Cursor = Cursors.WaitCursor

                S = "SP_SELECT_IMITMDAT_ASS '','" & rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_venitm") & "','" & rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_chkdat") & "','" & _
                     rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_xlsfil") & "','" & gsUsrID & "'"

                Cursor = Cursors.WaitCursor
                gspStr = S
                rtnLong = execute_SQLStatement(gspStr, rs_ZSITMDAT_ASS, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading  sp  :" & rtnStr)
                    Exit Sub
                Else
                    If rs_ZSITMDAT.Tables("result").Rows.Count = 0 Then
                    Else

                        For index9 As Integer = 0 To rs_ZSITMDAT_ASS.Tables("result").Rows.Count - 1
                            rs_ZSITMDAT.Tables("result").DefaultView.RowFilter = "zid_venitm = " & "'" & rs_ZSITMDAT_ASS.Tables("result").Rows(index9)("iad_acsno") & "'"
                            If rs_ZSITMDAT.Tables("result").DefaultView.Count > 0 And asked = False Then
                                If MsgBox("Confirm to approve ?", MsgBoxStyle.YesNo) = vbYes Then
                                    ans = True
                                    asked = True
                                Else
                                    ans = False
                                    asked = True
                                End If
                            End If

                            rs_ZSITMDAT.Tables("result").DefaultView.RowFilter = "zid_venitm = " & "'" & rs_ZSITMDAT_ASS.Tables("result").Rows(index9)("iad_acsno") & "'"
                            If rs_ZSITMDAT.Tables("result").DefaultView.Count > 0 Then
                                If ans = True Then
                                    rs_ZSITMDAT.Tables("RESULT").DefaultView(0)("zid_stage") = "R"
                                    'tempzzzzzzzzzzzzzzzzzzz
                                    'defaultview = 
                                End If
                            End If
                        Next

                    End If
                End If

                '                index99 = index99 - 1
                '2 index99 in this module??
                '???????????????????????????????
            End If


            '2
            Dim assort As String
            If rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_itmtyp") = "REG" Then

                Cursor = Cursors.WaitCursor

                S = "SP_SELECT_IMITMDAT_REG  '','" & rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_venitm") & "','" & rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_chkdat") & "','" & _
                     rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_xlsfil") & "','" & gsUsrID & "'"
                gspStr = S
                rtnLong = execute_SQLStatement(gspStr, rs_ZSITMDAT_REG, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading  sp  :" & rtnStr)
                    Exit Sub
                Else
                    If rs_ZSITMDAT.Tables("result").Rows.Count = 0 Then
                    Else

                        For index9 As Integer = 0 To rs_ZSITMDAT_REG.Tables("result").Rows.Count - 1
                            rs_ZSITMDAT.Tables("result").DefaultView.RowFilter = "zid_venitm = " & "'" & rs_ZSITMDAT_REG.Tables("result").Rows(index9)("iad_venitm") & "'"
                            If rs_ZSITMDAT.Tables("result").DefaultView.Count > 0 And asked = False Then
                                If MsgBox("Confirm to approve?", MsgBoxStyle.YesNo) = vbYes Then
                                    ans = True
                                    asked = True
                                Else
                                    ans = False
                                    asked = True
                                End If
                            End If

                            rs_ZSITMDAT.Tables("result").DefaultView.RowFilter = "zid_venitm = " & "'" & rs_ZSITMDAT_REG.Tables("result").Rows(index9)("iad_venitm") & "'"
                            If rs_ZSITMDAT.Tables("result").DefaultView.Count > 0 Then
                                If ans = True Then
                                    rs_ZSITMDAT.Tables("RESULT").DefaultView(0)("zid_stage") = "R"
                                    'tempzzzzzzzzzzzzzzzzzzz
                                    'defaultview = 
                                End If
                            End If
                        Next

                    End If
                End If







            ElseIf rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_stage") = "A" Then

                chkReject_dtl.Checked = False
                chkApprove_dtl.Checked = True
                chkWait_dtl.Checked = False



                If rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_itmtyp") = "ASS" Then

                    Cursor = Cursors.WaitCursor

                    S = "SP_SELECT_IMITMDAT_ASS  '','" & rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_venitm") & "','" & rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_chkdat") & "','" & _
                         rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_xlsfil") & "','" & gsUsrID & "'"

                    Cursor = Cursors.WaitCursor
                    gspStr = S
                    rtnLong = execute_SQLStatement(gspStr, rs_ZSITMDAT_ASS, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading  sp  :" & rtnStr)
                        Exit Sub
                    Else
                        If rs_ZSITMDAT.Tables("result").Rows.Count = 0 Then
                        Else

                            For index9 As Integer = 0 To rs_ZSITMDAT_ASS.Tables("result").Rows.Count - 1
                                rs_ZSITMDAT.Tables("result").DefaultView.RowFilter = "zid_venitm = " & "'" & rs_ZSITMDAT_ASS.Tables("result").Rows(index9)("iad_acsno") & "'"
                                If rs_ZSITMDAT.Tables("result").DefaultView.Count > 0 And asked = False Then
                                    If MsgBox("Confirm to approve ?", MsgBoxStyle.YesNo) = vbYes Then
                                        ans = True
                                        asked = True
                                    Else
                                        ans = False
                                        asked = True
                                    End If
                                End If

                                rs_ZSITMDAT.Tables("result").DefaultView.RowFilter = "zid_venitm = " & "'" & rs_ZSITMDAT_ASS.Tables("result").Rows(index9)("iad_acsno") & "'"
                                If rs_ZSITMDAT.Tables("result").DefaultView.Count > 0 Then
                                    asked = True
                                    If ans = True Then
                                        rs_ZSITMDAT.Tables("RESULT").DefaultView(0)("zid_stage") = "A"
                                        'tempzzzzzzzzzzzzzzzzzzz
                                        'defaultview = 
                                    Else
                                        If norecord = False Then
                                            norecord = True
                                        End If

                                    End If
                                End If
                            Next

                            If ans = False And norecord = False Then
                                rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_stage") = "W"
                            ElseIf norecord = True Then
                                rs_ZSITMDAT.Tables("RESULT").Rows(index99)("zid_stage") = "A"
                            End If

                        End If
                    End If

                End If
            End If

        End If
        Recordstatus = True

    End Sub

    'Private Sub Enable_IAR00001()
    '
    'If ERP00000.mnuIAR00001.Enabled = False Then
    '    cmdIAR00001.Enabled = False
    'Else
    '    cmdIAR00001.Enabled = True
    'End If
    'End Sub
    Private Sub txtVenItm_dtl_Change()

    End Sub

    'Private Sub MIM00002_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    'End Sub


    Private Sub MIM00002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Form_Load()

    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click
        Call cmdFind_Click()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        Call CmdSave_Click()
    End Sub

    Private Sub optApproval_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optApproval.CheckedChanged
        chkApprove_dtl_Click()
    End Sub

    Public Sub HighlightText(ByVal t As TextBox)
        t.SelectionStart = 0
        t.SelectionLength = Len(t.Text)

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        cmdClear_Click()
    End Sub
    Public Function IsDataGrid(ByVal v As Object) As Boolean
        If (TypeOf v Is DataGrid) Then
            IsDataGrid = True
        End If
    End Function


    Private Sub grdSummary_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSummary.CellClick
        readingindex = e.RowIndex
        If rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage") = "A" Then
            chkApprove_dtl.Checked = True
            chkReject_dtl.Checked = False
            chkWait_dtl.Checked = False


        ElseIf rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage") = "R" Then
            chkApprove_dtl.Checked = False
            chkReject_dtl.Checked = True
            chkWait_dtl.Checked = False

        Else
            chkApprove_dtl.Checked = False
            chkReject_dtl.Checked = False
            chkWait_dtl.Checked = True

        End If



    End Sub

    Private Sub grdSummary_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSummary.CellContentClick

    End Sub

    Private Sub grdSummary_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSummary.CellDoubleClick

        readingindex = e.RowIndex

        If e.ColumnIndex = 1 Then
            If Trim(rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage")) = "A" Then
                rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage") = "R"

            ElseIf Trim(rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage")) = "R" Then
                rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage") = "W"

            ElseIf Trim(rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage")) = "W" Then
                rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage") = "A"

            End If
            Recordstatus = True
        End If

    End Sub

    Private Sub grdSummary_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSummary.CurrentCellChanged

        If isSave = False Then
            If readingindex >= 0 And readingindex <= rs_ZSITMDAT.Tables("result").Rows.Count - 1 Then

                StatusBar.Panels(1).Text = Format(rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_credat"), "dd/MM/yyyy") & " " & Format(rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_upddat"), "dd/MM/yyyy") & _
                                           " " & rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_updusr")
            End If
        End If

    End Sub

    Private Sub grdSummary_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdSummary.EditingControlShowing

        If grdSummary.CurrentCell.ColumnIndex = 0 Then
            AddHandler e.Control.KeyPress, AddressOf CheckCell
        End If

    End Sub

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 32 Then

            If Trim(rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage")) = "A" Then
                rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage") = "R"

            ElseIf Trim(rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage")) = "R" Then
                rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage") = "W"

            ElseIf Trim(rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage")) = "W" Then
                rs_ZSITMDAT.Tables("RESULT").Rows(readingindex)("zid_stage") = "A"

            End If
            Recordstatus = True


            e.Handled = True

        End If

    End Sub

    Private Sub SSTab1_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles SSTab1.GotFocus
        grdSummary.BackColor = Color.White
        grdDetail.BackColor = Color.White

    End Sub

    Private Sub SSTab1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSTab1.SelectedIndexChanged

    End Sub

    Private Sub txtFromApply_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFromApply.GotFocus
        Call HighlightText(txtFromApply)

    End Sub

    Private Sub txtFromApply_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFromApply.KeyPress

        If (InStr("0123456789", Chr(Asc(e.KeyChar))) = 0) And (Asc(e.KeyChar) > 31 Or Asc(e.KeyChar) < 0) Then
            e.KeyChar = Chr(0)
        End If

    End Sub

    Private Sub txtFromApply_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromApply.TextChanged

    End Sub

    Private Sub txtToApply_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtToApply.GotFocus
        Call HighlightText(txtToApply)

    End Sub

    Private Sub txtToApply_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtToApply.KeyPress
        '        Asc(e.KeyChar)
        If (InStr("0123456789", e.KeyChar) = 0 And Asc(e.KeyChar) > 31 Or Asc(e.KeyChar) < 0) Then
            e.KeyChar = Chr(0)
        End If

    End Sub

    Private Sub txtToApply_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToApply.TextChanged

    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        cmdApply_Click()
    End Sub

    Private Sub chkApprove_dtl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkApprove_dtl.CheckedChanged
        chkApprove_dtl_Click()
    End Sub

    Private Sub optWait_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optWait.CheckedChanged

    End Sub

    Private Sub txtVenItm_dtl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVenItm_dtl.TextChanged

    End Sub
End Class


