Public Class MPO00002

    Inherits System.Windows.Forms.Form


    Dim rs_MPOXLSHDR As New DataSet
    Dim rs_MPOXLSDTL As New DataSet
    Dim rs_MPO00002 As New DataSet

    'Dim rs_MPOXLSHDR_Blk  As New DataSet
    Dim rs_MPOXLSDTL_Blk As New DataSet
    Dim colVen As Integer
    Dim colPONo As Integer
    Dim colVenNo As Integer
    Dim colGen As Integer

    Dim currentTab As Integer
    Dim save_ok As Boolean
    Const tabHeader As Integer = 0
    Const tabDetail As Integer = 1
    Const tabMPO As Integer = 2

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Dim intMax As Integer
    Dim readingindex As Integer





#Region " Windows Form Designer generated code"
    Friend WithEvents SSTab1 As ERPSystem.BaseTabControl
    Friend WithEvents tpMPO00002_1 As System.Windows.Forms.TabPage
    Friend WithEvents tpMPO00002_2 As System.Windows.Forms.TabPage
    Friend WithEvents txtPOTo As System.Windows.Forms.TextBox
    Friend WithEvents txtUplDatTo As System.Windows.Forms.TextBox
    Friend WithEvents lblRvsDat As System.Windows.Forms.Label
    Friend WithEvents txtUplDatFm As System.Windows.Forms.TextBox
    Friend WithEvents lblIssDat As System.Windows.Forms.Label
    Friend WithEvents tpMPO00002_3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
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
    Friend WithEvents grdMergePO As System.Windows.Forms.DataGridView
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
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents grdMPOHdr As System.Windows.Forms.DataGridView
    Friend WithEvents grdMPODtl As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMsg As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdLastD As System.Windows.Forms.Button
    Friend WithEvents cmdPrevD As System.Windows.Forms.Button
    Friend WithEvents cmdNextD As System.Windows.Forms.Button
    Friend WithEvents cmdFirstD As System.Windows.Forms.Button
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPOFm As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtApplyFm As System.Windows.Forms.TextBox
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents txtApplyTo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkGen As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdInsert As System.Windows.Forms.Button
    Friend WithEvents cmdGen As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSupplier As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtImortVen As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtShipPlc As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCurr As System.Windows.Forms.TextBox

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
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtPOTo = New System.Windows.Forms.TextBox
        Me.txtUplDatTo = New System.Windows.Forms.TextBox
        Me.lblRvsDat = New System.Windows.Forms.Label
        Me.txtUplDatFm = New System.Windows.Forms.TextBox
        Me.lblIssDat = New System.Windows.Forms.Label
        Me.StatusBar = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.ComboBox6 = New System.Windows.Forms.ComboBox
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPOFm = New System.Windows.Forms.TextBox
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.chkGen = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtApplyFm = New System.Windows.Forms.TextBox
        Me.cmdApply = New System.Windows.Forms.Button
        Me.txtApplyTo = New System.Windows.Forms.TextBox
        Me.cmdInsert = New System.Windows.Forms.Button
        Me.cmdGen = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtMsg = New System.Windows.Forms.RichTextBox
        Me.SSTab1 = New ERPSystem.BaseTabControl
        Me.tpMPO00002_1 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.grdMPOHdr = New System.Windows.Forms.DataGridView
        Me.cmdCopy = New System.Windows.Forms.Button
        Me.tpMPO00002_2 = New System.Windows.Forms.TabPage
        Me.cmdLastD = New System.Windows.Forms.Button
        Me.cmdPrevD = New System.Windows.Forms.Button
        Me.cmdNextD = New System.Windows.Forms.Button
        Me.cmdFirstD = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtCurr = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtShipPlc = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtImortVen = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtSupplier = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.grdMPODtl = New System.Windows.Forms.DataGridView
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
        Me.tpMPO00002_3 = New System.Windows.Forms.TabPage
        Me.grdMergePO = New System.Windows.Forms.DataGridView
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SSTab1.SuspendLayout()
        Me.tpMPO00002_1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdMPOHdr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpMPO00002_2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdMPODtl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.tpMPO00002_3.SuspendLayout()
        CType(Me.grdMergePO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPOTo
        '
        Me.txtPOTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPOTo.Location = New System.Drawing.Point(289, 16)
        Me.txtPOTo.MaxLength = 10
        Me.txtPOTo.Name = "txtPOTo"
        Me.txtPOTo.Size = New System.Drawing.Size(114, 20)
        Me.txtPOTo.TabIndex = 1
        '
        'txtUplDatTo
        '
        Me.txtUplDatTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtUplDatTo.Location = New System.Drawing.Point(289, 41)
        Me.txtUplDatTo.MaxLength = 10
        Me.txtUplDatTo.Name = "txtUplDatTo"
        Me.txtUplDatTo.Size = New System.Drawing.Size(114, 20)
        Me.txtUplDatTo.TabIndex = 3
        '
        'lblRvsDat
        '
        Me.lblRvsDat.AutoSize = True
        Me.lblRvsDat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblRvsDat.Location = New System.Drawing.Point(260, 41)
        Me.lblRvsDat.Name = "lblRvsDat"
        Me.lblRvsDat.Size = New System.Drawing.Size(23, 13)
        Me.lblRvsDat.TabIndex = 267
        Me.lblRvsDat.Text = "To:"
        '
        'txtUplDatFm
        '
        Me.txtUplDatFm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtUplDatFm.Location = New System.Drawing.Point(131, 41)
        Me.txtUplDatFm.MaxLength = 10
        Me.txtUplDatFm.Name = "txtUplDatFm"
        Me.txtUplDatFm.Size = New System.Drawing.Size(114, 20)
        Me.txtUplDatFm.TabIndex = 2
        '
        'lblIssDat
        '
        Me.lblIssDat.AutoSize = True
        Me.lblIssDat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblIssDat.Location = New System.Drawing.Point(85, 41)
        Me.lblIssDat.Name = "lblIssDat"
        Me.lblIssDat.Size = New System.Drawing.Size(33, 13)
        Me.lblIssDat.TabIndex = 266
        Me.lblIssDat.Text = "From:"
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
        'cmdShow
        '
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdShow.Location = New System.Drawing.Point(420, 16)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(66, 28)
        Me.cmdShow.TabIndex = 4
        Me.cmdShow.TabStop = False
        Me.cmdShow.Text = "&Show"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label1)
        Me.GroupBox8.Controls.Add(Me.Label4)
        Me.GroupBox8.Controls.Add(Me.Label2)
        Me.GroupBox8.Controls.Add(Me.Label3)
        Me.GroupBox8.Controls.Add(Me.txtPOFm)
        Me.GroupBox8.Controls.Add(Me.txtUplDatTo)
        Me.GroupBox8.Controls.Add(Me.lblIssDat)
        Me.GroupBox8.Controls.Add(Me.txtUplDatFm)
        Me.GroupBox8.Controls.Add(Me.lblRvsDat)
        Me.GroupBox8.Controls.Add(Me.cmdShow)
        Me.GroupBox8.Controls.Add(Me.txtPOTo)
        Me.GroupBox8.Location = New System.Drawing.Point(11, -4)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(502, 68)
        Me.GroupBox8.TabIndex = 365
        Me.GroupBox8.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(85, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 280
        Me.Label1.Text = "From:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(260, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 281
        Me.Label4.Text = "To:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(9, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 278
        Me.Label2.Text = "Upload Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(10, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 279
        Me.Label3.Text = "ZS PO No."
        '
        'txtPOFm
        '
        Me.txtPOFm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPOFm.Location = New System.Drawing.Point(131, 16)
        Me.txtPOFm.MaxLength = 10
        Me.txtPOFm.Name = "txtPOFm"
        Me.txtPOFm.Size = New System.Drawing.Size(114, 20)
        Me.txtPOFm.TabIndex = 0
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.chkGen)
        Me.GroupBox9.Controls.Add(Me.Label6)
        Me.GroupBox9.Controls.Add(Me.txtApplyFm)
        Me.GroupBox9.Controls.Add(Me.cmdApply)
        Me.GroupBox9.Controls.Add(Me.txtApplyTo)
        Me.GroupBox9.Location = New System.Drawing.Point(528, -4)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(315, 34)
        Me.GroupBox9.TabIndex = 366
        Me.GroupBox9.TabStop = False
        '
        'chkGen
        '
        Me.chkGen.AutoSize = True
        Me.chkGen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkGen.Location = New System.Drawing.Point(159, 10)
        Me.chkGen.Name = "chkGen"
        Me.chkGen.Size = New System.Drawing.Size(73, 17)
        Me.chkGen.TabIndex = 7
        Me.chkGen.Text = "Mark Gen"
        Me.chkGen.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(69, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(20, 13)
        Me.Label6.TabIndex = 277
        Me.Label6.Text = "To"
        '
        'txtApplyFm
        '
        Me.txtApplyFm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtApplyFm.Location = New System.Drawing.Point(10, 10)
        Me.txtApplyFm.MaxLength = 10
        Me.txtApplyFm.Name = "txtApplyFm"
        Me.txtApplyFm.Size = New System.Drawing.Size(50, 20)
        Me.txtApplyFm.TabIndex = 5
        '
        'cmdApply
        '
        Me.cmdApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdApply.Location = New System.Drawing.Point(241, 10)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(62, 23)
        Me.cmdApply.TabIndex = 8
        Me.cmdApply.TabStop = False
        Me.cmdApply.Text = "&Apply"
        '
        'txtApplyTo
        '
        Me.txtApplyTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtApplyTo.Location = New System.Drawing.Point(92, 10)
        Me.txtApplyTo.MaxLength = 10
        Me.txtApplyTo.Name = "txtApplyTo"
        Me.txtApplyTo.Size = New System.Drawing.Size(50, 20)
        Me.txtApplyTo.TabIndex = 6
        '
        'cmdInsert
        '
        Me.cmdInsert.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdInsert.Location = New System.Drawing.Point(530, 39)
        Me.cmdInsert.Name = "cmdInsert"
        Me.cmdInsert.Size = New System.Drawing.Size(64, 25)
        Me.cmdInsert.TabIndex = 9
        Me.cmdInsert.TabStop = False
        Me.cmdInsert.Text = "&Insert"
        '
        'cmdGen
        '
        Me.cmdGen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdGen.Location = New System.Drawing.Point(603, 39)
        Me.cmdGen.Name = "cmdGen"
        Me.cmdGen.Size = New System.Drawing.Size(67, 25)
        Me.cmdGen.TabIndex = 10
        Me.cmdGen.TabStop = False
        Me.cmdGen.Text = "&Generate"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdClear.Location = New System.Drawing.Point(679, 39)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(64, 25)
        Me.cmdClear.TabIndex = 11
        Me.cmdClear.TabStop = False
        Me.cmdClear.Text = "Cl&ear"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtMsg)
        Me.GroupBox4.Location = New System.Drawing.Point(11, 433)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(870, 71)
        Me.GroupBox4.TabIndex = 365
        Me.GroupBox4.TabStop = False
        '
        'txtMsg
        '
        Me.txtMsg.Location = New System.Drawing.Point(1, 10)
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.Size = New System.Drawing.Size(882, 58)
        Me.txtMsg.TabIndex = 18
        Me.txtMsg.Text = ""
        '
        'SSTab1
        '
        Me.SSTab1.Controls.Add(Me.tpMPO00002_1)
        Me.SSTab1.Controls.Add(Me.tpMPO00002_2)
        Me.SSTab1.Controls.Add(Me.tpMPO00002_3)
        Me.SSTab1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.SSTab1.Location = New System.Drawing.Point(11, 66)
        Me.SSTab1.Name = "SSTab1"
        Me.SSTab1.SelectedIndex = 0
        Me.SSTab1.Size = New System.Drawing.Size(993, 368)
        Me.SSTab1.TabIndex = 44
        '
        'tpMPO00002_1
        '
        Me.tpMPO00002_1.Controls.Add(Me.GroupBox2)
        Me.tpMPO00002_1.Location = New System.Drawing.Point(4, 24)
        Me.tpMPO00002_1.Name = "tpMPO00002_1"
        Me.tpMPO00002_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMPO00002_1.Size = New System.Drawing.Size(985, 340)
        Me.tpMPO00002_1.TabIndex = 0
        Me.tpMPO00002_1.Text = "(1) Header"
        Me.tpMPO00002_1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.grdMPOHdr)
        Me.GroupBox2.Controls.Add(Me.cmdCopy)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(869, 344)
        Me.GroupBox2.TabIndex = 266
        Me.GroupBox2.TabStop = False
        '
        'grdMPOHdr
        '
        Me.grdMPOHdr.AllowUserToAddRows = False
        Me.grdMPOHdr.AllowUserToDeleteRows = False
        Me.grdMPOHdr.ColumnHeadersHeight = 20
        Me.grdMPOHdr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdMPOHdr.Location = New System.Drawing.Point(1, 6)
        Me.grdMPOHdr.Name = "grdMPOHdr"
        Me.grdMPOHdr.RowHeadersWidth = 20
        Me.grdMPOHdr.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdMPOHdr.RowTemplate.Height = 16
        Me.grdMPOHdr.Size = New System.Drawing.Size(863, 322)
        Me.grdMPOHdr.TabIndex = 368
        '
        'cmdCopy
        '
        Me.cmdCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdCopy.Location = New System.Drawing.Point(508, 84)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(48, 10)
        Me.cmdCopy.TabIndex = 3
        Me.cmdCopy.TabStop = False
        Me.cmdCopy.Text = "&Copy"
        '
        'tpMPO00002_2
        '
        Me.tpMPO00002_2.Controls.Add(Me.cmdLastD)
        Me.tpMPO00002_2.Controls.Add(Me.cmdPrevD)
        Me.tpMPO00002_2.Controls.Add(Me.cmdNextD)
        Me.tpMPO00002_2.Controls.Add(Me.cmdFirstD)
        Me.tpMPO00002_2.Controls.Add(Me.GroupBox1)
        Me.tpMPO00002_2.Controls.Add(Me.GroupBox3)
        Me.tpMPO00002_2.Controls.Add(Me.txtmodvol)
        Me.tpMPO00002_2.Controls.Add(Me.txtCusVen)
        Me.tpMPO00002_2.Controls.Add(Me.txtVenNo)
        Me.tpMPO00002_2.Controls.Add(Me.cboPCPrc)
        Me.tpMPO00002_2.Controls.Add(Me.optSearch1)
        Me.tpMPO00002_2.Controls.Add(Me.optSearch0)
        Me.tpMPO00002_2.Controls.Add(Me.Label30)
        Me.tpMPO00002_2.Controls.Add(Me.txtPurOrd)
        Me.tpMPO00002_2.Controls.Add(Me.txtVol)
        Me.tpMPO00002_2.Controls.Add(Me.txtColCde)
        Me.tpMPO00002_2.Controls.Add(Me.Label39)
        Me.tpMPO00002_2.Controls.Add(Me.txtMtrCtn)
        Me.tpMPO00002_2.Controls.Add(Me.Label40)
        Me.tpMPO00002_2.Controls.Add(Me.Label56)
        Me.tpMPO00002_2.Controls.Add(Me.GroupBox5)
        Me.tpMPO00002_2.Controls.Add(Me.optCtrSiz3)
        Me.tpMPO00002_2.Controls.Add(Me.optCtrSiz4)
        Me.tpMPO00002_2.Controls.Add(Me.optCtrSiz0)
        Me.tpMPO00002_2.Controls.Add(Me.optCtrSiz1)
        Me.tpMPO00002_2.Controls.Add(Me.optCtrSiz2)
        Me.tpMPO00002_2.Controls.Add(Me.txtCustUM)
        Me.tpMPO00002_2.Controls.Add(Me.Label27)
        Me.tpMPO00002_2.Location = New System.Drawing.Point(4, 22)
        Me.tpMPO00002_2.Name = "tpMPO00002_2"
        Me.tpMPO00002_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMPO00002_2.Size = New System.Drawing.Size(985, 342)
        Me.tpMPO00002_2.TabIndex = 1
        Me.tpMPO00002_2.Text = "(2) Details"
        Me.tpMPO00002_2.UseVisualStyleBackColor = True
        '
        'cmdLastD
        '
        Me.cmdLastD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdLastD.Location = New System.Drawing.Point(814, 16)
        Me.cmdLastD.Name = "cmdLastD"
        Me.cmdLastD.Size = New System.Drawing.Size(54, 26)
        Me.cmdLastD.TabIndex = 370
        Me.cmdLastD.TabStop = False
        Me.cmdLastD.Text = ">>|"
        '
        'cmdPrevD
        '
        Me.cmdPrevD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdPrevD.Location = New System.Drawing.Point(702, 16)
        Me.cmdPrevD.Name = "cmdPrevD"
        Me.cmdPrevD.Size = New System.Drawing.Size(54, 26)
        Me.cmdPrevD.TabIndex = 368
        Me.cmdPrevD.TabStop = False
        Me.cmdPrevD.Text = "<"
        '
        'cmdNextD
        '
        Me.cmdNextD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdNextD.Location = New System.Drawing.Point(758, 16)
        Me.cmdNextD.Name = "cmdNextD"
        Me.cmdNextD.Size = New System.Drawing.Size(54, 26)
        Me.cmdNextD.TabIndex = 369
        Me.cmdNextD.TabStop = False
        Me.cmdNextD.Text = ">"
        '
        'cmdFirstD
        '
        Me.cmdFirstD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdFirstD.Location = New System.Drawing.Point(646, 16)
        Me.cmdFirstD.Name = "cmdFirstD"
        Me.cmdFirstD.Size = New System.Drawing.Size(54, 26)
        Me.cmdFirstD.TabIndex = 367
        Me.cmdFirstD.TabStop = False
        Me.cmdFirstD.Text = "|<<"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtCurr)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtShipPlc)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtImortVen)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtSupplier)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(617, 49)
        Me.GroupBox1.TabIndex = 364
        Me.GroupBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label9.Location = New System.Drawing.Point(502, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 285
        Me.Label9.Text = "Curr :"
        '
        'txtCurr
        '
        Me.txtCurr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCurr.Location = New System.Drawing.Point(545, 16)
        Me.txtCurr.MaxLength = 10
        Me.txtCurr.Name = "txtCurr"
        Me.txtCurr.Size = New System.Drawing.Size(53, 20)
        Me.txtCurr.TabIndex = 284
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label8.Location = New System.Drawing.Point(336, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 283
        Me.Label8.Text = "Shp Plc :"
        '
        'txtShipPlc
        '
        Me.txtShipPlc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtShipPlc.Location = New System.Drawing.Point(390, 16)
        Me.txtShipPlc.MaxLength = 10
        Me.txtShipPlc.Name = "txtShipPlc"
        Me.txtShipPlc.Size = New System.Drawing.Size(96, 20)
        Me.txtShipPlc.TabIndex = 282
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label7.Location = New System.Drawing.Point(172, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 281
        Me.Label7.Text = "Impt Ven :"
        '
        'txtImortVen
        '
        Me.txtImortVen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtImortVen.Location = New System.Drawing.Point(231, 16)
        Me.txtImortVen.MaxLength = 10
        Me.txtImortVen.Name = "txtImortVen"
        Me.txtImortVen.Size = New System.Drawing.Size(96, 20)
        Me.txtImortVen.TabIndex = 280
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(13, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 279
        Me.Label5.Text = "Supplier :"
        '
        'txtSupplier
        '
        Me.txtSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSupplier.Location = New System.Drawing.Point(66, 16)
        Me.txtSupplier.MaxLength = 10
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.Size = New System.Drawing.Size(96, 20)
        Me.txtSupplier.TabIndex = 278
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.grdMPODtl)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 48)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(871, 302)
        Me.GroupBox3.TabIndex = 363
        Me.GroupBox3.TabStop = False
        '
        'grdMPODtl
        '
        Me.grdMPODtl.AllowUserToAddRows = False
        Me.grdMPODtl.AllowUserToDeleteRows = False
        Me.grdMPODtl.ColumnHeadersHeight = 20
        Me.grdMPODtl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdMPODtl.Location = New System.Drawing.Point(2, 9)
        Me.grdMPODtl.Name = "grdMPODtl"
        Me.grdMPODtl.RowHeadersWidth = 20
        Me.grdMPODtl.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdMPODtl.RowTemplate.Height = 16
        Me.grdMPODtl.Size = New System.Drawing.Size(864, 276)
        Me.grdMPODtl.TabIndex = 368
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
        'tpMPO00002_3
        '
        Me.tpMPO00002_3.Controls.Add(Me.grdMergePO)
        Me.tpMPO00002_3.Location = New System.Drawing.Point(4, 22)
        Me.tpMPO00002_3.Name = "tpMPO00002_3"
        Me.tpMPO00002_3.Size = New System.Drawing.Size(985, 342)
        Me.tpMPO00002_3.TabIndex = 2
        Me.tpMPO00002_3.Text = "(3) Merge PO"
        Me.tpMPO00002_3.UseVisualStyleBackColor = True
        '
        'grdMergePO
        '
        Me.grdMergePO.AllowUserToAddRows = False
        Me.grdMergePO.AllowUserToDeleteRows = False
        Me.grdMergePO.ColumnHeadersHeight = 20
        Me.grdMergePO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdMergePO.Location = New System.Drawing.Point(10, 14)
        Me.grdMergePO.Name = "grdMergePO"
        Me.grdMergePO.RowHeadersWidth = 20
        Me.grdMergePO.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdMergePO.RowTemplate.Height = 16
        Me.grdMergePO.Size = New System.Drawing.Size(862, 325)
        Me.grdMergePO.TabIndex = 367
        '
        'MPO00002
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(892, 536)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdGen)
        Me.Controls.Add(Me.cmdInsert)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.SSTab1)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MPO00002"
        Me.Text = "MPO00002 - Manufacturing Purchase Order Maintenance"
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.SSTab1.ResumeLayout(False)
        Me.tpMPO00002_1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grdMPOHdr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpMPO00002_2.ResumeLayout(False)
        Me.tpMPO00002_2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grdMPODtl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.tpMPO00002_3.ResumeLayout(False)
        CType(Me.grdMergePO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region

    Private Sub Match_Hdr_Dtl()
        Dim pos As Integer
        Dim tmpCount As Integer
        Dim gen As String

        If rs_MPOXLSHDR Is Nothing Then Exit Sub
        If rs_MPOXLSDTL Is Nothing Then Exit Sub

        If rs_MPOXLSHDR.Tables("result") Is Nothing Then Exit Sub
        If rs_MPOXLSDTL.Tables("result") Is Nothing Then Exit Sub

        If rs_MPOXLSHDR.Tables("result").Rows.Count <= 0 Then Exit Sub

        With rs_MPOXLSHDR
            For index9 As Integer = 0 To .Tables("RESULT").Rows.Count - 1
                rs_MPOXLSDTL.Tables("result").DefaultView.RowFilter = "Mxd_PONo = '" & .Tables("RESULT").Rows(index9)("Mxh_PONo") & "' and Gen <> 'X'"
                tmpCount = rs_MPOXLSDTL.Tables("result").DefaultView.Count
                If tmpCount > 0 Then
                    '                gen = rs_MPOXLSDTL("Gen")
                    '                If gen = "Y" Then
                    rs_MPOXLSDTL.Tables("result").DefaultView.RowFilter = "Mxd_PONo = '" & .Tables("RESULT").Rows(index9)("Mxh_PONo") & "' and Gen='Y'"
                    If rs_MPOXLSDTL.Tables("result").DefaultView.Count = tmpCount Then
                        If .Tables("RESULT").Rows(index9)("Gen") <> "X" Then .Tables("RESULT").Rows(index9)("Gen") = "Y"
                        '                    Else
                        '                        If.Tables("RESULT").Rows(index9)("Gen") <> "X" Then.Tables("RESULT").Rows(index9)("Gen") = " "
                    End If
                    'End If
                End If

            Next

        End With
    End Sub

    Private Sub Match_Dtl_Hdr(ByVal MpoNo As String, ByVal gen As String)
        Dim pos As Integer
        Dim tmpCount As Integer

        If rs_MPOXLSHDR Is Nothing Then Exit Sub
        If rs_MPOXLSDTL Is Nothing Then Exit Sub
        If rs_MPOXLSHDR.Tables("result") Is Nothing Then Exit Sub
        If rs_MPOXLSDTL.Tables("result") Is Nothing Then Exit Sub
        If rs_MPOXLSHDR.Tables("result").Rows.Count <= 0 Then Exit Sub

        With rs_MPOXLSDTL
            For index9 As Integer = 0 To .Tables("RESULT").Rows.Count - 1
                .Tables("result").DefaultView.RowFilter = "Mxd_PONo = '" & MpoNo & "' and Gen <> 'X'"
                tmpCount = .Tables("result").DefaultView.Count
                If tmpCount > 0 Then
                    .Tables("result").DefaultView.RowFilter = "Mxd_PONo = '" & MpoNo & "' and Gen='" & gen & "'"
                    If .Tables("result").DefaultView.Count = tmpCount Then
                        If rs_MPOXLSHDR.Tables("RESULT").Rows(readingindex)("Gen") <> "X" Then rs_MPOXLSHDR.Tables("RESULT").Rows(readingindex)("Gen") = gen
                    Else
                        If rs_MPOXLSHDR.Tables("RESULT").Rows(readingindex)("Gen") <> "X" Then rs_MPOXLSHDR.Tables("RESULT").Rows(readingindex)("Gen") = " "
                    End If
                End If
                .Tables("result").DefaultView.RowFilter = "Mxd_PONo = '" & MpoNo & "'"

            Next
        End With
    End Sub

    Private Sub cmdApply_Click()
        Dim gen As String
        Dim i As Integer
        Dim intFm As Integer
        Dim intTo As Integer
        Dim pos As Integer

        If Me.txtApplyFm.Text = "" Then
            MsgBox("Please input Apply From value!")
            Me.txtApplyFm.Focus()
            Exit Sub
        End If

        If Me.txtApplyTo.Text = "" Then
            MsgBox("Please input Apply To value!")
            Me.txtApplyTo.Focus()
            Exit Sub
        End If


        If SSTab1.SelectedIndex = 0 Then
            If rs_MPOXLSHDR Is Nothing Then Exit Sub
            If rs_MPOXLSHDR.Tables("result").Rows.Count <= 0 Then Exit Sub
        ElseIf SSTab1.SelectedIndex = 1 Then
            If rs_MPOXLSDTL Is Nothing Then Exit Sub
            If rs_MPOXLSDTL.Tables("result").Rows.Count <= 0 Then Exit Sub
        Else
            Exit Sub
        End If

        gen = "Y"
        If Me.chkGen.Checked = False Then gen = " "




        intFm = CInt(Me.txtApplyFm.Text)
        intTo = CInt(Me.txtApplyTo.Text)


        If SSTab1.SelectedIndex = 0 Then

            If intFm <= 1 Then
                intFm = 1
            End If
            If intFm > rs_MPOXLSHDR.Tables("result").Rows.Count Then Exit Sub
            If intTo <= 1 Then
                intTo = 1
            End If
            If intTo > rs_MPOXLSHDR.Tables("result").Rows.Count Then intTo = rs_MPOXLSHDR.Tables("result").Rows.Count

            'pos = rs_MPOXLSHDR.AbsolutePosition
            'rs_MPOXLSHDR.MoveFirst()
            'If intFm > 1 Then rs_MPOXLSHDR.Move(intFm - 1)
            For i = intFm To intTo
                If rs_MPOXLSHDR.Tables("result").Rows(i - 1)("Gen") <> "X" Then
                    rs_MPOXLSHDR.Tables("result").Rows(i - 1)("Gen") = gen
                End If
                'rs_MPOXLSHDR.MoveNext()
            Next

            'If pos > 0 Then readingindex -1= pos
        Else
            If intFm <= 1 Then
                intFm = 1
            End If
            If intTo <= 1 Then
                intTo = 1
            End If
            If intFm > rs_MPOXLSDTL.Tables("result").Rows.Count Then Exit Sub
            If intTo > rs_MPOXLSDTL.Tables("result").Rows.Count Then intTo = rs_MPOXLSDTL.Tables("result").Rows.Count

            For i = intFm To intTo
                If rs_MPOXLSDTL.Tables("result").Rows(i - 1)("Gen") <> "X" Then
                    rs_MPOXLSDTL.Tables("result").Rows(i - 1)("Gen") = gen
                End If
                'rs_MPOXLSHDR.MoveNext()
            Next
        End If

    End Sub

    '*** Folder 1

    '*** Folder 2

    '*** Folder 2


    Private Sub cmdClear_Click()
        Dim YNC As Integer
        If Not rs_MPO00002 Is Nothing Then
            If Not rs_MPO00002.Tables("result") Is Nothing Then
                If rs_MPO00002.Tables("result").Rows.Count > 0 Then
                    SSTab1.SelectedIndex = 2
                    YNC = MsgBox("There is changed record!" & vbCrLf & "Do you want to generate Manufacturing PO?", vbYesNoCancel + vbDefaultButton2 + vbQuestion, "")
                    If YNC = vbCancel Then
                        Exit Sub
                    ElseIf YNC = vbYes Then
                        If Enq_right_local Then
                            Call cmdGenClick()
                            Exit Sub
                        Else
                            MsgBox("You do not have rights to save!" & vbCrLf & "Program will clear without save!", vbInformation + vbOKOnly)
                        End If


                    End If
                End If
            End If
        End If
        Call setStatus("Clear")
    End Sub


    Private Sub CmdExit_Click()
        Me.Close()
    End Sub

    Private Sub cmdFirstD_Click()
        Call moveHeaderRecord("F")
    End Sub

    Private Sub moveHeaderRecord(ByVal strAct As String)
        Me.cmdFirstD.Enabled = False
        Me.cmdPrevD.Enabled = False
        Me.cmdNextD.Enabled = False
        Me.cmdLastD.Enabled = False
        If rs_MPOXLSHDR Is Nothing Then Exit Sub
        If rs_MPOXLSHDR.Tables("result").Rows.Count <= 0 Then Exit Sub

        Select Case strAct
            Case "F"
                readingindex = 0
            Case "P"
                readingindex = readingindex - 1
                If readingindex < 0 Then
                    readingindex = 0
                End If
            Case "N"
                readingindex = readingindex + 1
                If readingindex > rs_MPOXLSHDR.Tables("result").Rows.Count - 1 Then
                    readingindex = rs_MPOXLSHDR.Tables("result").Rows.Count - 1
                End If
            Case "L"
                readingindex = rs_MPOXLSHDR.Tables("result").Rows.Count - 1
        End Select

        '    Select Case strAct
        '        Case "F", "P"
        '            If readingindex -1> 1 Then
        '                Me.cmdFirstD.Enabled = True
        '                Me.cmdPrevD.Enabled = True
        '            End If
        '            If rs_MPOXLSHDR.Tables("result").Rows.Count > 1 Then
        '                Me.cmdNextD.Enabled = True
        '                Me.cmdLastD.Enabled = True
        '            End If
        '        Case "N", "L"
        '            If readingindex -1< rs_MPOXLSHDR.Tables("result").Rows.Count Then
        '                Me.cmdNextD.Enabled = True
        '                Me.cmdLastD.Enabled = True
        '            End If
        '            If rs_MPOXLSHDR.Tables("result").Rows.Count > 1 Then
        '                Me.cmdFirstD.Enabled = True
        '                Me.cmdPrevD.Enabled = True
        '            End If
        '        Case Else
        If rs_MPOXLSHDR.Tables("result").Rows.Count > 1 Then
            If readingindex - 1 > 1 Then
                Me.cmdFirstD.Enabled = True
                Me.cmdPrevD.Enabled = True
            End If
            If readingindex < rs_MPOXLSHDR.Tables("result").Rows.Count - 1 Then
                Me.cmdNextD.Enabled = True
                Me.cmdLastD.Enabled = True
            End If
        End If
        '    End Select

        If Me.SSTab1.SelectedIndex = 1 Then
            Call DisplayDetail()
        End If
    End Sub

    Private Sub cmdGenClick()
        save_ok = True
        If SSTab1.SelectedIndex <> 2 Then Exit Sub
        If rs_MPO00002 Is Nothing Then Exit Sub
        If rs_MPO00002.Tables("result") Is Nothing Then Exit Sub
        If rs_MPO00002.Tables("result").Rows.Count <= 0 Then Exit Sub

        Dim tmp_mpo As String
        Dim Doc_No As String
        Dim S As String


        Dim i As Integer
        Dim rs_tmp As New DataSet
        Dim rs As New DataSet
        Dim rs_ttl As New DataSet

        save_ok = False
        tmp_mpo = ""
        Doc_No = ""


        With rs_MPO00002
            For index9 As Integer = 0 To .Tables("RESULT").Rows.Count - 1
                If tmp_mpo <> rs_MPO00002.Tables("RESULT").Rows(index9)("Mph_MPONO") Then
                    tmp_mpo = rs_MPO00002.Tables("RESULT").Rows(index9)("Mph_MPONO")
                    Doc_No = ""
                    gspStr = "sp_select_DOC_GEN '" & "UCPP" & "','MP','" & gsUsrID & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading cmdSaveClick sp_select_DOC_GEN :" & rtnStr)
                        Cursor = Cursors.Default
                        Exit Sub
                    Else
                        Doc_No = rs_tmp.Tables("RESULT").Rows(0)(0).ToString
                    End If

                    If Doc_No <> "" Then
                        gspStr = "sp_insert_MPORDHDR '" & _
                        "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mph_MPONO") & "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mph_VenNo") & _
                        "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mph_ImpFty") & "','" & Replace(rs_MPO00002.Tables("RESULT").Rows(index9)("Mph_ShpPlc"), "'", "''") & _
                        "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mph_Curr") & _
                        "','" & Doc_No & "','" & gsUsrID & "'"

                        '                Debug.Print S
                        gsCompany = IIf(gsCompanyGroup = "UCG", "UCPP", "MS")
                        Call Update_gs_Value(gsCompany)
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading cmdSaveClick sp_select_DOC_GEN :" & rtnStr)
                            Cursor = Cursors.Default
                            Exit Sub
                        Else
                            Me.txtMsg.Text = Me.txtMsg.Text & IIf(Me.txtMsg.Text <> "", vbCrLf, "") & "MPO # : " & Doc_No & " for " & tmp_mpo
                        End If

                    End If
                    '-------------------
                End If
                If Doc_No <> "" Then
                    gspStr = "sp_insert_MPORDDTL '" & _
                "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_PONo") & "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_POSeq") & _
                "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_PODat") & "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_ShpDat") & "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_ItmNo") & _
                "','" & Replace(rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_ItmNam"), "'", "''") & "','" & Replace(rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_ItmDsc"), "'", "''") & _
                "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_ColCde") & "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_UM") & _
                "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_Qty") & _
                "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_UntPrc") & "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_PckMth") & _
                "','" & Replace(rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_HdrRmk"), "'", "''") & "','" & Replace(rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_Rmk"), "'", "''") & _
                "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_ReqNo") & "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_PrdNo") & _
                "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_Dept") & _
                "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_FilNamH") & "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_FilSeqH") & _
                "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_FilNam") & "','" & rs_MPO00002.Tables("RESULT").Rows(index9)("Mpd_Filseq") & _
                "','" & Doc_No & "','" & gsUsrID & "'"

                    gsCompany = IIf(gsCompanyGroup = "UCG", "UCPP", "MS")
                    Call Update_gs_Value(gsCompany)
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading cmdSaveClick sp_select_DOC_GEN :" & rtnStr)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If

                End If

                '''''''''''''''''''''''''''
                If index9 = rs_MPO00002.Tables("RESULT").Rows.Count - 1 Then
                    S = "sp_select_MPO00002_min  '','" & Doc_No & "','" & gsUsrID & "'"
                ElseIf tmp_mpo <> rs_MPO00002.Tables("RESULT").Rows(index9 + 1)("Mph_MPONO") Then
                    S = "sp_select_MPO00002_min  '','" & Doc_No & "','" & gsUsrID & "'"
                End If

                If S <> "" Then
                    gspStr = S
                    rtnLong = execute_SQLStatement(gspStr, rs_ttl, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox(rs_ttl.Tables("RESULT").Rows(0)(0))
                        Exit Sub
                    Else
                        If rs_ttl.Tables("RESULT").Rows(0)(0) = "Update sucess" Then
                            Me.txtMsg.Text = Me.txtMsg.Text & IIf(Me.txtMsg.Text <> "", vbCrLf, "") & rs_ttl.Tables("RESULT").Rows(0)(0)
                        End If

                    End If
                End If

                '''''''''''''''''''''''''''
            Next
        End With

        MsgBox("Manufacturing Purchase Order Generation Complete.")
        Call setStatus("Clear")
        save_ok = True
    End Sub

    Private Sub cmdInsert_Click()
        If Me.SSTab1.SelectedIndex = 0 Then
            Call insertHeader()
            Call DisplayHeader()
        ElseIf Me.SSTab1.SelectedIndex = 1 Then
            Call insertDetail(readingindex)
            'tempzzzzzzzzzzzzzzzzzz
            Call DisplayDetail()
        End If
    End Sub

    Private Sub insertHeader()
        Dim pos As Integer
        Dim tmp_po As String
        Dim i As Integer
        Dim strFilter As String
        Dim book As Integer

        If rs_MPOXLSHDR Is Nothing Then Exit Sub
        If rs_MPOXLSHDR.Tables("result") Is Nothing Then Exit Sub
        If rs_MPOXLSHDR.Tables("result").Rows.Count <= 0 Then Exit Sub

        strFilter = rs_MPOXLSHDR.Tables("result").DefaultView.RowFilter

        'pos = rs_MPOXLSHDR.AbsolutePosition
        'book = rs_MPOXLSHDR.bookmark

        rs_MPOXLSHDR.Tables("result").DefaultView.RowFilter = "GEN = 'Y'"
        If rs_MPOXLSHDR.Tables("result").DefaultView.Count > 0 Then
            If rs_MPOXLSDTL Is Nothing Then Exit Sub
            'temp

            For index As Integer = 0 To rs_MPOXLSHDR.Tables("result").DefaultView.Count - 1
                tmp_po = rs_MPOXLSHDR.Tables("result").DefaultView(index)("Mxh_PoNo")
                rs_MPOXLSDTL.Tables("result").DefaultView.RowFilter = "Mxd_MPOFlg = 'N' and Mxd_PONo = '" & tmp_po & "'"
                If rs_MPOXLSDTL.Tables("result").DefaultView.Count > 0 Then

                    For i = 0 To rs_MPOXLSDTL.Tables("result").DefaultView.Count - 1
                        If rs_MPOXLSDTL.Tables("result").DefaultView(i)("GEN") <> "X" Then
                            rs_MPOXLSDTL.Tables("result").DefaultView(i)("GEN") = "Y"
                            'temp
                        End If
                    Next

                    Call insertDetail(index)
                    rs_MPOXLSHDR.Tables("result").DefaultView(index)("GEN") = "X"
                    'tempzzzzzzzzz
                End If

            Next

        End If

        rs_MPOXLSHDR.Tables("result").DefaultView.RowFilter = ""

        '   If pos > 0 Then readingindex(-1 = pos)
        'If book > 0 Then rs_MPOXLSHDR.bookmark = book

    End Sub

    Private Sub insertDetail(ByVal index)
        Dim pos As Integer
        Dim HdrPos As Integer
        Dim HdrBook As Integer

        Dim tmp_mpo As String
        Dim tmp_po As String

        Dim strVenNo As String
        Dim strImpFty As String
        Dim strCurr As String
        Dim strShpPlc As String
        Dim strPODat As String
        Dim strRmk As String
        Dim strFilNam As String
        Dim intFilSeq As Integer


        If rs_MPOXLSDTL Is Nothing Then Exit Sub
        If rs_MPOXLSHDR Is Nothing Then Exit Sub
        If rs_MPOXLSDTL.Tables("result") Is Nothing Then Exit Sub
        If rs_MPOXLSHDR.Tables("result") Is Nothing Then Exit Sub
        If rs_MPOXLSDTL.Tables("result").Rows.Count <= 0 Then Exit Sub
        If rs_MPOXLSHDR.Tables("result").Rows.Count <= 0 Then Exit Sub

        tmp_po = rs_MPOXLSHDR.Tables("result").DefaultView(index)("Mxh_PoNo")
        'HdrPos = rs_MPOXLSHDR.AbsolutePosition
        'HdrBook = rs_MPOXLSHDR.bookmark
        'pos = rs_MPOXLSDTL.AbsolutePosition
        rs_MPOXLSDTL.Tables("result").DefaultView.RowFilter = ""
        rs_MPOXLSDTL.Tables("result").AcceptChanges()

        rs_MPOXLSDTL.Tables("result").DefaultView.RowFilter = "GEN='Y' and Mxd_PoNo='" & tmp_po & "'"
        rs_MPOXLSDTL.Tables("result").AcceptChanges()

        If rs_MPOXLSDTL.Tables("result").DefaultView.Count > 0 Then
            '==============================================================================================
            strVenNo = Trim(rs_MPOXLSHDR.Tables("result").DefaultView(index)("Mxh_VenNo"))
            strImpFty = Trim(IIf(IsDBNull(rs_MPOXLSHDR.Tables("result").DefaultView(index)("Mxh_ImpFty")), rs_MPOXLSHDR.Tables("result").DefaultView(index)("Mxh_ShpPlc"), rs_MPOXLSHDR.Tables("result").DefaultView(index)("Mxh_ImpFty")))
            strCurr = Trim(rs_MPOXLSHDR.Tables("result").DefaultView(index)("Mxh_Curr"))
            strShpPlc = Trim(rs_MPOXLSHDR.Tables("result").DefaultView(index)("Mxh_ShpPlc"))
            strPODat = IIf(rs_MPOXLSHDR.Tables("result").DefaultView(index)("Mxh_PODat") = "", "01/01/1900", rs_MPOXLSHDR.Tables("result").DefaultView(index)("Mxh_PODat"))
            strRmk = Trim(rs_MPOXLSHDR.Tables("result").DefaultView(index)("Mxh_Rmk"))
            strFilNam = rs_MPOXLSHDR.Tables("result").DefaultView(index)("Mxh_FilNam")
            intFilSeq = rs_MPOXLSHDR.Tables("result").DefaultView(index)("Mxh_seq")
            '***************************************
            'Generate Temp Manufacturing PO No
            '***************************************
            If rs_MPO00002.Tables("result").Rows.Count > 0 Then
                rs_MPO00002.Tables("result").DefaultView.RowFilter = "Mph_VenNo='" & strVenNo & "' and Mph_ImpFty='" & strImpFty & "' and Mph_ShpPlc = '" & strShpPlc & "' and Mph_Curr='" & strCurr & "'"
                If rs_MPO00002.Tables("result").DefaultView.Count > 0 Then
                    tmp_mpo = rs_MPO00002.Tables("RESULT").DefaultView(0)("Mph_MPONO")
                    'tempz
                Else
                    tmp_mpo = "Tmp_" & Microsoft.VisualBasic.Right("0000" & Trim(Str(intMax)), 5)
                    intMax = intMax + 1
                End If
                rs_MPO00002.Tables("result").DefaultView.RowFilter = ""
            Else
                tmp_mpo = "Tmp_" & Microsoft.VisualBasic.Right("0000" & Trim(Str(intMax)), 5)
                intMax = intMax + 1
            End If

            '***************************************

            For index99 As Integer = 0 To rs_MPOXLSDTL.Tables("result").DefaultView.Count - 1 Step 1
                If index99 <= rs_MPOXLSDTL.Tables("result").DefaultView.Count - 1 Then

                    rs_MPO00002.Tables("RESULT").Rows.Add()
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mph_MPONO") = tmp_mpo
                    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mph_VenNo") = strVenNo
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mph_ImpFty") = strImpFty
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mph_Curr") = strCurr
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mph_ShpPlc") = strShpPlc
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_ShpDat") = rs_MPOXLSDTL.Tables("result").DefaultView(index99)("Mxd_ShpDat")
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_FilNamH") = strFilNam
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_FilSeqH") = intFilSeq
                    'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_MPONO") = ""
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_MPOseq") = 0
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_HdrRmk") = strRmk
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_PODat") = strPODat

                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_PONo") = rs_MPOXLSDTL.Tables("result").DefaultView(index99)("Mxd_PONo")

                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_POSeq") = rs_MPOXLSDTL.Tables("result").DefaultView(index99)("Mxd_POSeq")
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_ReqNo") = rs_MPOXLSDTL.Tables("result").DefaultView(index99)("Mxd_ReqNo")
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_ItmNo") = rs_MPOXLSDTL.Tables("result").DefaultView(index99)("Mxd_ItmNo")
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_ItmNam") = rs_MPOXLSDTL.Tables("result").DefaultView(index99)("Mxd_ItmNam")
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_ItmDsc") = rs_MPOXLSDTL.Tables("result").DefaultView(index99)("Mxd_ItmDsc")
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_ColCde") = rs_MPOXLSDTL.Tables("result").DefaultView(index99)("Mxd_ColCde")
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_UM") = rs_MPOXLSDTL.Tables("result").DefaultView(index99)("Mxd_UM")
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_Qty") = rs_MPOXLSDTL.Tables("result").DefaultView(index99)("Mxd_Qty")
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_ShpQty") = 0
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_UntPrc") = rs_MPOXLSDTL.Tables("result").DefaultView(index99)("Mxd_UntPrc")
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_PckMth") = rs_MPOXLSDTL.Tables("result").DefaultView(index99)("Mxd_PckMth")
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_Dept") = rs_MPOXLSDTL.Tables("result").DefaultView(index99)("Mxd_Dept")
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_PrdNo") = rs_MPOXLSDTL.Tables("result").DefaultView(index99)("Mxd_PrdNo")
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_FilNam") = rs_MPOXLSDTL.Tables("result").DefaultView(index99)("Mxd_FilNam")
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_Filseq") = rs_MPOXLSDTL.Tables("result").DefaultView(index99)("Mxd_seq")
                    rs_MPO00002.Tables("RESULT").Rows(rs_MPO00002.Tables("RESULT").Rows.Count - 1)("Mpd_Rmk") = rs_MPOXLSDTL.Tables("result").DefaultView(index99)("Mxd_Rmk")

                    '        rs_MPOXLSDTL.Tables("result").DefaultView(index99)("Gen") = "X"

                End If
            Next


            For index999 As Integer = 0 To rs_MPOXLSDTL.Tables("result").Rows.Count - 1
                If rs_MPOXLSDTL.Tables("result").Rows(index999)("GEN") = "Y" And _
                    rs_MPOXLSDTL.Tables("result").Rows(index999)("Mxd_PoNo") = tmp_po Then

                    rs_MPOXLSDTL.Tables("result").Rows(index999)("Gen") = "X"
                End If
            Next


            '==============================================================================================
        End If

        rs_MPOXLSDTL.Tables("result").DefaultView.RowFilter = "Mxd_PoNo='" & tmp_po & "'"

        'If HdrPos > 0 Then index -1= HdrPos
        'If HdrBook > 0 Then rs_MPOXLSHDR.bookmark = HdrBook
        ''If pos > 0 Then rs_MPOXLSDTL.AbsolutePosition = pos
        rs_MPO00002.Tables("result").DefaultView.Sort = "Mph_MPONO,Mpd_ItmNo,Mpd_PONo,Mpd_POSeq"
        'Set grdMergePO.DataSource = rs_MPO00002
        'grdMergePO.Refresh

    End Sub

    Private Sub cmdLastD_Click()
        Call moveHeaderRecord("L")
    End Sub

    Private Sub cmdNextD_Click()
        Call moveHeaderRecord("N")
    End Sub

    Private Sub cmdPrevD_Click()
        Call moveHeaderRecord("P")
    End Sub

    Private Sub cmdShowClick()
        Dim strStatus As String

        '    If Trim(Me.txtFilNamFm.Text) = "" And Trim(Me.txtFilNamTo.Text) <> "" Then
        '       Me.txtFilNamFm.Text = Me.txtFilNamTo.Text
        '    ElseIf Trim(Me.txtFilNamFm.Text) <> "" And Trim(Me.txtFilNamTo.Text) = "" Then
        '        Me.txtFilNamTo.Text = Me.txtFilNamFm.Text
        '    ElseIf Trim(Me.txtFilNamFm.Text) > Trim(Me.txtFilNamTo.Text) Then
        '        MsgBox "File Name From > File Name To!"
        '        Me.txtFilNamFm.Focus
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

        Dim rs As DataSet

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

        strStatus = "N"
        Cursor = Cursors.WaitCursor

        '*** query Primary Customer
        gspStr = "sp_select_MPOXLSHDR '" & "','" & strStatus & "','" & _
            Trim(Me.txtPOFm.Text) & "','" & Trim(Me.txtPOTo.Text) & "','" & _
            dtFm & "','" & dtTo & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_MPOXLSHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_MPOXLSHDR  :" & rtnStr)
            Cursor = Cursors.Default
            Exit Sub
        End If
        If rs_MPOXLSHDR.Tables("result").Rows.Count <= 0 Then
            MsgBox("No Record Found!")
            Exit Sub
        End If
        With rs_MPOXLSHDR
            For i2 As Integer = 0 To .Tables("RESULT").Columns.Count - 1
                .Tables("RESULT").Columns(i2).ReadOnly = False
            Next i2
        End With


        gspStr = "sp_select_MPOXLSDTL '" & "','" & strStatus & "','" & _
        Trim(Me.txtPOFm.Text) & "','" & Trim(Me.txtPOTo.Text) & "','" & _
        dtFm & "','" & dtTo & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_MPOXLSDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdSaveClick sp_select_DOC_GEN :" & rtnStr)
            Cursor = Cursors.Default
            Exit Sub
        End If
        With rs_MPOXLSDTL
            For i2 As Integer = 0 To .Tables("RESULT").Columns.Count - 1
                .Tables("RESULT").Columns(i2).ReadOnly = False
            Next i2
        End With

        gspStr = "sp_select_MPO00002 ''"
        rtnLong = execute_SQLStatement(gspStr, rs_MPO00002, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdSaveClick sp_select_DOC_GEN :" & rtnStr)
            Cursor = Cursors.Default
            Exit Sub
        Else
            With rs_MPO00002
                For i2 As Integer = 0 To .Tables("RESULT").Columns.Count - 1
                    .Tables("RESULT").Columns(i2).ReadOnly = False
                Next i2
            End With

        End If


        Cursor = Cursors.Default
        rs_MPOXLSDTL_Blk = rs_MPOXLSDTL.Copy


        Me.SSTab1.SelectedIndex = 0
        Call displayGenerate()
        Call DisplayHeader()

        Call setStatus("Update")

        '***************************************
        intMax = 1
        '***************************************

    End Sub


    Private Sub displayGenerate()
        Dim intCol As Integer
        If rs_MPO00002 Is Nothing Then Exit Sub
        '    If rs_MPO00002.Tables("result").Rows.Count <= 0 Then Exit Sub

        Me.txtApplyFm.Text = ""
        Me.txtApplyTo.Text = ""

        Me.txtApplyFm.Enabled = False
        Me.txtApplyTo.Enabled = False
        Me.cmdApply.Enabled = False

        'rs_MPO00002.MoveFirst
        Me.grdMergePO.DataSource = rs_MPO00002.Tables("RESULT")
        Call buttonCell(grdMergePO)

        With Me.grdMergePO
            intCol = 0

            .Columns(intCol).HeaderText = "Temp M.PO #"
            '''''            .Columns(intCol).Button = True
            'tempzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz
            .Columns(intCol).Width = 1400 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Supplier #"
            .Columns(intCol).Width = 1200 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Import Fty"
            .Columns(intCol).Width = 1200 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ship Place"
            .Columns(intCol).Width = 1200 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ship Date"
            .Columns(intCol).Width = 1200 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "PO # (ZS)"
            .Columns(intCol).Width = 1200 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "PO Seq (ZS)"
            .Columns(intCol).Width = 400 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "PO Date"
            .Columns(intCol).Width = 1200 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Item #"
            .Columns(intCol).Width = 1600 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Item Name"
            .Columns(intCol).Width = 3200 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Item Desc."
            .Columns(intCol).Width = 2000 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Color"
            .Columns(intCol).Width = 1200 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "UM"
            .Columns(intCol).Width = 400 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Qty"
            .Columns(intCol).Width = 600 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Curr."
            .Columns(intCol).Width = 800 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Unit Price"
            .Columns(intCol).Width = 800 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Pck Method"
            .Columns(intCol).Width = 2000 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Remark (Hdr)"
            .Columns(intCol).Width = 2000 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Remark (Dtl)"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Req #"
            .Columns(intCol).Width = 1200 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Prd #"
            .Columns(intCol).Visible = False
            .Columns(intCol).Width = 0

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Dept"
            .Columns(intCol).Width = 800 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ship Qty"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "M.PO # (Dtl)"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "M.PO Seq (Dtl)"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "File Name"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "File Seq"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "File Name"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "File Seq"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

        End With

    End Sub

    Private Sub Form_Load()

    End Sub

    Private Sub setStatus(ByVal Mode As String)
        'Private Sub setStatus(Mode As String, Optional byval rs  As DataSet)

        Select Case Mode
            Case "Init"
                readingindex = 0
                cmdShow.Enabled = True
                cmdClear.Enabled = False


                '==+++++++++++++++++++++++==

                '==+++++++++++++++++++++++==
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
                Me.txtMsg.Text = ""
                Me.txtMsg.Enabled = True
                Me.txtMsg.ReadOnly = True
                Me.SSTab1.SelectedIndex = 0
                Me.SSTab1.Enabled = False

                cmdGen.Enabled = False
                cmdInsert.Enabled = False
            Case "Update"

                Me.cmdShow.Enabled = False
                Me.cmdClear.Enabled = True


                '        Me.txtFilNamFm.Enabled = False
                '        Me.txtFilNamTo.Enabled = False
                Me.txtPOFm.Enabled = False
                Me.txtPOTo.Enabled = False
                Me.txtUplDatFm.Enabled = False
                Me.txtUplDatTo.Enabled = False
                Me.txtMsg.Text = ""
                Me.SSTab1.Enabled = True
                Me.SSTab1.SelectedIndex = 0
                cmdGen.Enabled = False
                cmdInsert.Enabled = True

            Case "Clear"

                grdMPOHdr.DataSource = Nothing
                grdMPODtl.DataSource = Nothing
                grdMergePO.DataSource = Nothing

                rs_MPOXLSHDR = Nothing
                rs_MPOXLSDTL = Nothing
                rs_MPO00002 = Nothing

                cmdShow.Enabled = True
                cmdClear.Enabled = False



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
                'Me.txtUplDatFm.Text = Format(Now, "MM/dd/yyyy")
                'Me.txtUplDatTo.Text = Format(Now, "MM/dd/yyyy")
                'Me.txtMsg.Text = ""
                Me.SSTab1.SelectedIndex = 0
                Me.SSTab1.Enabled = False
                cmdGen.Enabled = False
                cmdInsert.Enabled = False

            Case "Exit"
                grdMPOHdr.DataSource = Nothing
                grdMPODtl.DataSource = Nothing

                rs_MPOXLSHDR = Nothing
                rs_MPOXLSDTL = Nothing

                Call setStatus("Clear")
        End Select
    End Sub

    Private Sub SetStatusBar(ByVal Mode As String)
        If Me.SSTab1.SelectedIndex = 0 Then
            If Not rs_MPOXLSHDR Is Nothing Then
                If rs_MPOXLSHDR.Tables("result").Rows.Count > 0 Then

                    'If rs_MPOXLSHDR.BOF = False Then
                    '    If rs_MPOXLSHDR.EOF = False Then
                    Me.StatusBar.Panels(1).Text = rs_MPOXLSHDR.Tables("result").Rows(readingindex)("Mxh_UpdUsr") & "  " & Format(rs_MPOXLSHDR.Tables("result").Rows(readingindex)("Mxh_CreDat"), "MM/dd/yyyy") & "  " & Format(rs_MPOXLSHDR.Tables("result").Rows(readingindex)("Mxh_UpdDat"), "MM/dd/yyyy")

                    '    End If
                    'End If
                End If
            End If
        ElseIf Me.SSTab1.SelectedIndex = 1 Then
            If Not rs_MPOXLSDTL Is Nothing Then
                If Not rs_MPOXLSDTL.Tables("result") Is Nothing Then
                    If rs_MPOXLSDTL.Tables("result").Rows.Count > 0 Then
                        'If rs_MPOXLSDTL.BOF = False Then
                        '    If rs_MPOXLSDTL.EOF = False Then
                        '''''''                        Me.StatusBar.Panels(1).Text = rs_MPOXLSDTL("Mxd_UpdUsr") & "  " & Format(rs_MPOXLSDTL("Mxd_CreDat"), "MM/dd/yyyy") & "  " & Format(rs_MPOXLSDTL("Mxd_UpdDat"), "MM/dd/yyyy")
                        '    End If
                        'End If
                    End If
                End If
            End If
        End If


    End Sub

    Private Sub DisplayHeader()
        Dim intCol As Integer
        Dim i As Integer

        Me.grdMPOHdr.DataSource = Nothing
        Me.grdMPODtl.DataSource = Nothing

        If rs_MPOXLSHDR Is Nothing Then Exit Sub
        If rs_MPOXLSHDR.Tables("result") Is Nothing Then Exit Sub
        If rs_MPOXLSHDR.Tables("result").Rows.Count <= 0 Then Exit Sub

        Me.txtApplyFm.Text = "1"
        Me.txtApplyTo.Text = Trim(Str(rs_MPOXLSHDR.Tables("result").Rows.Count))
        Me.txtApplyFm.Enabled = True
        Me.txtApplyTo.Enabled = True
        Me.cmdApply.Enabled = True

        For i = 0 To rs_MPOXLSHDR.Tables("result").Rows.Count - 1
            rs_MPOXLSHDR.Tables("result").Rows(i)("SEQ") = i + 1
        Next

        '''''''''       Dim buttonColumn As New DataGridViewButtonColumn()
        'temp

        Me.grdMPOHdr.DataSource = rs_MPOXLSHDR.Tables("result")

        ''''''''''       Call buttonCell(grdMPOHdr)
        'temp

        With Me.grdMPOHdr
            intCol = 0
            colGen = intCol
            .Columns(intCol).HeaderText = "Gen"

            '         .Columns(intCol).DefaultCellStyle = buttonColumn.CellType

            'Columns(intCol)
            '.Columns(intCol).Button = True
            'tempzzzzzzzzzzzzzzz
            .Columns(intCol).Width = 400 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Seq"
            .Columns(intCol).Width = 400 / 13

            intCol = intCol + 1
            colPONo = intCol
            .Columns(intCol).HeaderText = "PO # (ZS)"
            .Columns(intCol).Width = 1000 / 13

            intCol = intCol + 1
            colVenNo = intCol
            .Columns(intCol).HeaderText = "Vendor #"
            .Columns(intCol).Width = 800 / 13

            intCol = intCol + 1
            colVen = intCol
            .Columns(intCol).HeaderText = "Vendor Name"
            .Columns(intCol).Width = 2200 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Import Vendor"
            .Columns(intCol).Width = 1200 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ship To Dest."
            .Columns(intCol).Width = 1200 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Curr"
            .Columns(intCol).Width = 500 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Remark"
            .Columns(intCol).Width = 3000 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "MPO Flag (HK)"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "MPO # (HK)"
            .Columns(intCol).Width = 1400 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Exception Msg"
            .Columns(intCol).Width = 3000 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Update Flag (ZS)"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "PO Date"
            .Columns(intCol).Width = 1000 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "PO User"
            .Columns(intCol).Width = 1000 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Confirm User"
            .Columns(intCol).Width = 1000 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Confirm Date"
            .Columns(intCol).Width = 1000 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Contact Person"
            .Columns(intCol).Width = 1200 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "File Name"
            .Columns(intCol).Width = 2000 / 13

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

    Private Sub DisplayDetail()

        Dim intCol As Integer
        Dim i As Integer
        Dim gen As String

        If rs_MPOXLSHDR Is Nothing Then Exit Sub
        If rs_MPOXLSHDR.Tables("result") Is Nothing Then Exit Sub
        If rs_MPOXLSHDR.Tables("result").Rows.Count <= 0 Then Exit Sub
        '        If rs_MPOXLSHDR.BOF Or rs_MPOXLSHDR.EOF Then Exit Sub


        Me.txtSupplier.Text = ""
        Me.txtImortVen.Text = ""
        Me.txtShipPlc.Text = ""
        Me.txtCurr.Text = ""

        If Not rs_MPOXLSDTL Is Nothing Then
            If rs_MPOXLSDTL.Tables("result") Is Nothing Then

                Me.grdMPODtl.DataSource = rs_MPOXLSDTL_Blk.Tables("result")

                '         Call buttonCell(grdMPODtl)
                Me.txtApplyFm.Text = ""
                Me.txtApplyTo.Text = ""
                Me.txtApplyFm.Enabled = False
                Me.txtApplyTo.Enabled = False
                Me.cmdApply.Enabled = False
            Else

                rs_MPOXLSDTL.Tables("result").DefaultView.RowFilter = "Mxd_PONo = '" & rs_MPOXLSHDR.Tables("result").Rows(readingindex)("Mxh_PONo") & "'"
                If rs_MPOXLSDTL.Tables("result").DefaultView.Count <= 0 Then
                    Me.grdMPODtl.DataSource = rs_MPOXLSDTL_Blk.Tables("result")
                    'tempzzzzzzz
                    Me.txtApplyFm.Text = ""
                    Me.txtApplyTo.Text = ""
                    Me.txtApplyFm.Enabled = False
                    Me.txtApplyTo.Enabled = False
                    Me.cmdApply.Enabled = False
                Else
                    gen = rs_MPOXLSHDR.Tables("result").Rows(readingindex)("Gen")
                    Me.txtApplyFm.Text = "1"
                    Me.txtApplyTo.Text = Trim(Str(rs_MPOXLSDTL.Tables("result").Rows.Count))
                    Me.txtApplyFm.Enabled = True
                    Me.txtApplyTo.Enabled = True
                    Me.cmdApply.Enabled = True
                    Me.txtSupplier.Text = rs_MPOXLSHDR.Tables("result").Rows(readingindex)("Mxh_VenNo")
                    Me.txtImortVen.Text = IIf(IsDBNull(rs_MPOXLSHDR.Tables("result").Rows(readingindex)("Mxh_ImpFty")), rs_MPOXLSHDR.Tables("result").Rows(readingindex)("Mxh_ShpPlc"), rs_MPOXLSHDR.Tables("result").Rows(readingindex)("Mxh_ImpFty"))
                    Me.txtShipPlc.Text = rs_MPOXLSHDR.Tables("result").Rows(readingindex)("Mxh_ShpPlc")
                    Me.txtCurr.Text = rs_MPOXLSHDR.Tables("result").Rows(readingindex)("Mxh_Curr")
                    Me.grdMPODtl.DataSource = rs_MPOXLSDTL.Tables("result").DefaultView


                    For i = 0 To rs_MPOXLSDTL.Tables("result").DefaultView.Count - 1
                        rs_MPOXLSDTL.Tables("result").DefaultView(i)("SEQ") = i + 1
                        'rs_MPOXLSDTL.Tables("result").DefaultView(i)("Gen") = gen
                        If Trim(rs_MPOXLSDTL.Tables("result").DefaultView(i)("Gen")) = "" Then rs_MPOXLSDTL.Tables("result").DefaultView(i)("Gen") = gen

                        'bug ?  tempzzzzzzzzzz
                    Next

                End If

            End If
        End If



        With Me.grdMPODtl

            intCol = 0
            .Columns(intCol).HeaderText = "Gen"

            '    .Columns(intCol).Button = True
            .Columns(intCol).Width = 400 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Seq"
            .Columns(intCol).Width = 400 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "PO # (ZS)"
            .Columns(intCol).Width = 1200 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Seq (ZS)"
            .Columns(intCol).Width = 800 / 13



            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Item No"
            .Columns(intCol).Width = 1200 / 13


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Item Name"
            .Columns(intCol).Width = 3300 / 13


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Item Description"
            .Columns(intCol).Width = 2000 / 13


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Color"
            .Columns(intCol).Width = 1000 / 13


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "UM"
            .Columns(intCol).Width = 800 / 13


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Qty"
            .Columns(intCol).Width = 800 / 13


            intCol = intCol + 1
            '            .Columns(intCol).Alignment = dbgRight
            .Columns(intCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns(intCol).HeaderText = "Unit Price"
            .Columns(intCol).Width = 1000 / 13


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Packing Method"
            .Columns(intCol).Width = 1500 / 13


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Department"
            .Columns(intCol).Width = 1200 / 13


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Request #"
            .Columns(intCol).Width = 1200 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ship Date"
            .Columns(intCol).Width = 1200 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Production #"
            .Columns(intCol).Width = 1200 / 13


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Remark"
            .Columns(intCol).Width = 2000 / 13


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Exception"
            .Columns(intCol).Width = 2000 / 13


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
            .Columns(intCol).Width = 1600 / 13


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "File Name"
            .Columns(intCol).Width = 1800 / 13


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
    'goto
    Private Sub Form_Unload(ByVal Cancel As Integer)
    End Sub

    Private Sub grdMPODtl_ButtonClick(ByVal ColIndex As Integer)

    End Sub

    Private Sub grdMPODtl_RowColChange(ByVal LastRow As Object, ByVal LastCol As Integer)
        Call SetStatusBar("Update")
    End Sub





    Private Sub grdMPOHdr_ButtonClick(ByVal ColIndex As Integer)

    End Sub

    Private Sub grdMPOHdr_HeadClick(ByVal ColIndex As Integer)
    End Sub

    Private Sub grdMPOHdr_RowColChange(ByVal LastRow As Object, ByVal LastCol As Integer)
        'If grdMPOHdr.Row > 0 Then grdMPOHdr.RowBookmark (grdMPOHdr.Row)
        Call SetStatusBar("Update")
        If Not rs_MPOXLSHDR Is Nothing Then
            If rs_MPOXLSHDR.Tables("result").Rows.Count > 0 Then
                'Me.StatusBar.Panels(1).Text = "Record(s) " & rs_MPOXLSHDR("SEQ") & " / " & rs_MPOXLSHDR.Tables("result").Rows.Count
                Me.StatusBar.Panels(0).Text = "Record(s) " & (readingindex - 1).ToString & " / " & rs_MPOXLSHDR.Tables("result").Rows.Count.ToString

            End If
        End If
    End Sub


    Private Sub Label5_Click()

    End Sub

    Private Sub SSTab1_Click(ByVal PreviousTab As Integer)

    End Sub


    Private Sub txtApplyFm_GotFocus()
        Me.txtApplyFm.SelectionStart = 0
        Me.txtApplyFm.SelectionLength = Len(txtApplyFm.Text)
    End Sub

    Private Sub txtApplyFm_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApplyFm.KeyPress
        If e.KeyChar = Chr(8) Or InStr("1234567890", e.KeyChar) > 0 Then Exit Sub
        e.KeyChar = Chr(0)
    End Sub

    Private Sub txtApplyFm_KeyPress(ByVal KeyAscii As Integer)
    End Sub
    Private Sub txtApplyTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApplyTo.TextChanged
        Me.txtApplyTo.SelectionStart = 0
        Me.txtApplyTo.SelectionLength = Len(txtApplyTo.Text)
    End Sub

    Private Sub txtApplyTo_GotFocus()
    End Sub

    Private Sub txtApplyTo_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApplyTo.KeyPress
        If e.KeyChar = Chr(8) Or InStr("1234567890", e.KeyChar) > 0 Then Exit Sub
        e.KeyChar = Chr(0)
    End Sub

    Private Sub txtApplyTo_KeyPress(ByVal KeyAscii As Integer)
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


    Private Sub txtApplyFm_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApplyFm.GotFocus
    End Sub

    Private Sub txtPOFm_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPOFm.LostFocus
        Me.txtPOTo.Text = Me.txtPOFm.Text

    End Sub

    Private Sub txtApplyFm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApplyFm.LostFocus
    End Sub


    Private Sub txtApplyTo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApplyTo.GotFocus

    End Sub
    Private Sub txtPOTo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPOTo.GotFocus
        Me.txtPOTo.SelectionStart = 0
        Me.txtPOTo.SelectionLength = Len(Me.txtPOTo.Text)

    End Sub

    Private Sub txtUplDatFm_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUplDatFm.GotFocus
        Me.txtUplDatFm.SelectionStart = 0
        Me.txtUplDatFm.SelectionLength = Me.txtUplDatFm.MaxLength
    End Sub


    Private Sub txtUplDatFm_GotFocus()
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

    Private Sub txtUplDatFm_LostFocus()
    End Sub
    Private Sub txtUplDatTo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUplDatTo.GotFocus
        Me.txtUplDatTo.SelectionStart = 0
        Me.txtUplDatTo.SelectionLength = Me.txtUplDatTo.MaxLength
    End Sub
    Private Sub txtUplDatTo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUplDatTo.LostFocus
        If Me.txtUplDatTo.Text = "  /  /    " Then Exit Sub
        If IsDate(Me.txtUplDatTo.Text) = False Then
            MsgBox("Invalid Date Value!")
            Me.txtUplDatTo.Focus()
            Exit Sub
        End If
    End Sub


    Private Sub MPO00002_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim YNC As Integer
        If Not rs_MPO00002 Is Nothing Then
            If Not rs_MPO00002.Tables("result") Is Nothing Then
                If rs_MPO00002.Tables("result").Rows.Count > 0 Then
                    SSTab1.SelectedIndex = 2
                    YNC = MsgBox("There is changed record!" & vbCrLf & "Do you want to generate Manufacturing PO?", vbYesNoCancel + vbDefaultButton2 + vbQuestion, "")
                    If YNC = vbCancel Then
                        e.Cancel = True
                    ElseIf YNC = vbYes Then
                        If Enq_right_local Then
                            Call cmdGenClick()
                            e.Cancel = True
                        Else
                            MsgBox("You do not have rights to save!" & vbCrLf & "Program will clear without save!", vbInformation + vbOKOnly)
                        End If

                    End If
                End If
            End If
        End If

    End Sub


    Private Sub MPO00002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call AccessRight(Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001

        Enq_right_local = Enq_right
        Del_right_local = Del_right

        '#If useMTS Then
        '        Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If

        Cursor = Cursors.WaitCursor
        'gsConnStr = getConnectionString()
        Me.KeyPreview = True
        Call setStatus("Init")
        Call Formstartup(Me.Name)   'Set the form Sartup position
        Cursor = Cursors.Default

    End Sub

    Private Sub cmdGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGen.Click
        Call cmdGenClick()
    End Sub


    Private Sub txtApplyFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApplyFm.TextChanged

    End Sub



    Private Sub txtPOTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPOTo.TextChanged

    End Sub



    Private Sub txtPOFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPOFm.TextChanged

    End Sub



    Private Sub txtUplDatFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUplDatFm.TextChanged

    End Sub



    Private Sub txtUplDatTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUplDatTo.TextChanged

    End Sub

    Private Sub buttonCell(ByVal dgv As DataGridView)
        Dim btnCell As New DataGridViewButtonCell

        Dim iCol As Integer = 0
        Dim iRow As Integer
        '        Dim row As DataGridViewRow = dgv.CurrentRow
        'dgv.Rows(iRow).Cells(iCol).ReadOnly = True
        'Dim i As Integer
        For iRow = 0 To dgv.RowCount - 1
            '  dgv.Rows(iRow).Cells(iCol) = btnCell
            'btnCell.Value = "Gen"
            dgv.Rows(iRow).Cells(iCol).ReadOnly = False
        Next
    End Sub

    Private Sub grdMPOHdr_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdMPOHdr.CellClick
        ''''''''''untempzzzzzzzzzzzzzzzzzzzz
        Dim ColIndex As Integer
        ColIndex = e.ColumnIndex
        readingindex = e.RowIndex


        Dim gen As String
        If rs_MPOXLSHDR Is Nothing Then Exit Sub
        If rs_MPOXLSHDR.Tables("result").Rows.Count <= 0 Then Exit Sub
        If ColIndex = 0 Then
            gen = "X"

            If grdMPOHdr.Item(ColIndex, grdMPOHdr.CurrentCell.RowIndex).Value() = "Y" Then
                gen = " "
            ElseIf grdMPOHdr.Item(ColIndex, grdMPOHdr.CurrentCell.RowIndex).Value() = " " Then
                gen = "Y"

            End If
            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            If gen <> "X" Then
                grdMPOHdr.Item(ColIndex, grdMPOHdr.CurrentCell.RowIndex).Value() = gen
                If Not rs_MPOXLSDTL Is Nothing Then
                    If Not rs_MPOXLSDTL.Tables("result") Is Nothing Then
                        With rs_MPOXLSDTL
                            .Tables("result").DefaultView.RowFilter = "Mxd_PONo = '" & rs_MPOXLSHDR.Tables("RESULT").Rows(readingindex)("Mxh_PONo") & "'"
                            If .Tables("result").DefaultView.Count > 0 Then
                                For index9 As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                                    If .Tables("RESULT").DefaultView(index9)("Gen") <> "X" Then .Tables("RESULT").DefaultView(index9)("Gen") = gen
                                Next

                            End If
                        End With
                    End If
                End If
            End If
            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        End If
    End Sub

    Private Sub grdMPOHdr_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdMPOHdr.CellContentClick

    End Sub

    Private Sub grdMPODtl_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdMPODtl.CellClick
        Dim gen As String
        Dim pos As Long
        Dim ColIndex As Integer
        ColIndex = e.ColumnIndex


        If rs_MPOXLSDTL Is Nothing Then Exit Sub
        If rs_MPOXLSDTL.Tables("result").Rows.Count <= 0 Then Exit Sub
        If ColIndex = 0 Then
            gen = "X"
            If grdMPODtl.Item(ColIndex, grdMPODtl.CurrentCell.RowIndex).Value() = "Y" Then
                gen = " "
            ElseIf grdMPODtl.Item(ColIndex, grdMPODtl.CurrentCell.RowIndex).Value() = " " Then
                gen = "Y"
            End If
            If gen <> "X" Then
                grdMPODtl.Item(ColIndex, grdMPODtl.CurrentCell.RowIndex).Value() = gen

                Call Match_Dtl_Hdr(grdMPODtl.Item(2, grdMPODtl.CurrentCell.RowIndex).Value(), gen)
                'Call Match_Dtl_Hdr(rs_MPOXLSDTL.Tables("result").Rows(grdMPODtl.CurrentCell.RowIndex)("Mxd_PONo"), gen)
                'tempzzzzzzz
            End If
        End If

    End Sub

    Private Sub grdMPODtl_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdMPODtl.CellContentClick

    End Sub

    Private Sub grdMPOHdr_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdMPOHdr.ColumnHeaderMouseClick
        ''''''''''untempzzzzzzzzzzzzzzzzzzzz
        If rs_MPOXLSHDR Is Nothing Then Exit Sub
        If rs_MPOXLSHDR.Tables("result") Is Nothing Then Exit Sub
        If rs_MPOXLSHDR.Tables("result").Rows.Count <= 0 Then Exit Sub
        '    If e.ColumnIndex = colGen Then
        '        rs_MPOXLSHDR.Tables("result").DefaultView.Sort  = "gen desc,Mxh_VenNo,Mxh_ImpFty,Mxh_ShpPlc,Mxh_Curr,Mxh_PONo,Mxh_CreDat"
        '    Else
        If e.ColumnIndex = colVenNo Then
            rs_MPOXLSHDR.Tables("result").DefaultView.Sort = "Mxh_VenNo,Mxh_ImpFty,Mxh_ShpPlc,Mxh_Curr,Mxh_PONo,Mxh_CreDat"
        ElseIf e.ColumnIndex = colPONo Then
            rs_MPOXLSHDR.Tables("result").DefaultView.Sort = "Mxh_PONo,Mxh_VenNo,Mxh_ImpFty,Mxh_ShpPlc,Mxh_Curr,Mxh_CreDat"
        ElseIf e.ColumnIndex = colVen Then
            rs_MPOXLSHDR.Tables("result").DefaultView.Sort = "Vbi_VenNam,Mxh_ImpFty,Mxh_ShpPlc,Mxh_Curr,Mxh_PONo,Mxh_CreDat"
        End If


    End Sub

    Private Sub grdMPOHdr_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdMPOHdr.RowHeaderMouseDoubleClick
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Call cmdShowClick()

    End Sub

    Private Sub cmdFirstD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFirstD.Click

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub txtShpAdr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMsg.TextChanged

    End Sub

    Private Sub grdMergePO_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdMergePO.CellContentClick

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Call cmdClear_Click()

    End Sub

    Private Sub SSTab1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSTab1.SelectedIndexChanged
        If rs_MPOXLSHDR Is Nothing Then Exit Sub
        If rs_MPOXLSDTL Is Nothing Then Exit Sub
        If rs_MPOXLSHDR.Tables("result") Is Nothing Then Exit Sub
        If rs_MPOXLSDTL.Tables("result") Is Nothing Then Exit Sub


        If SSTab1.SelectedIndex = 0 Then
            Call Match_Hdr_Dtl()
            Me.txtApplyFm.Text = "1"
            Me.txtApplyTo.Text = Trim(Str(rs_MPOXLSHDR.Tables("result").Rows.Count))
            Me.txtApplyFm.Enabled = True
            Me.txtApplyTo.Enabled = True
            Me.cmdApply.Enabled = True
        ElseIf SSTab1.SelectedIndex = 1 Then
            'Call DisplayDetail
            Call moveHeaderRecord("X")
        End If
        If SSTab1.SelectedIndex = 0 Or SSTab1.SelectedIndex = 1 Then
            Me.cmdGen.Enabled = False
            Me.cmdInsert.Enabled = True
        Else
            'Me.cmdGen.Enabled = True
            Me.cmdGen.Enabled = Enq_right_local
            Me.cmdInsert.Enabled = False
        End If



    End Sub

    Private Sub cmdInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsert.Click


        Call cmdInsert_Click()

    End Sub
End Class














































































