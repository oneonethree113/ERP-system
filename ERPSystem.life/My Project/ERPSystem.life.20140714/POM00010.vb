




Public Class POM00010
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
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
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
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents tcPOM00010 As ERPSystem.BaseTabControl
    Friend WithEvents tcPOM00010_1 As System.Windows.Forms.TabPage
    Friend WithEvents tcPOM00010_2 As System.Windows.Forms.TabPage
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_S_CustPODateTo As AxMSMask.AxMaskEdBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lbl_S_CustPODate As System.Windows.Forms.Label
    Friend WithEvents txt_S_CustPODateFm As AxMSMask.AxMaskEdBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_S_ShipDateTo As AxMSMask.AxMaskEdBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbl_S_ShipDate As System.Windows.Forms.Label
    Friend WithEvents txt_S_ShipDateFm As AxMSMask.AxMaskEdBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_S_SCIssDateTo As AxMSMask.AxMaskEdBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_S_SCIssDate As System.Windows.Forms.Label
    Friend WithEvents txt_S_SCIssDateFm As AxMSMask.AxMaskEdBox
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
    Friend WithEvents tcPOM00010_3 As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POM00010))
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
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
        Me.TabPage6 = New System.Windows.Forms.TabPage
        Me.TabPage7 = New System.Windows.Forms.TabPage
        Me.tcPOM00010 = New ERPSystem.BaseTabControl
        Me.tcPOM00010_1 = New System.Windows.Forms.TabPage
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txt_S_CustPODateTo = New AxMSMask.AxMaskEdBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.lbl_S_CustPODate = New System.Windows.Forms.Label
        Me.txt_S_CustPODateFm = New AxMSMask.AxMaskEdBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_S_ShipDateTo = New AxMSMask.AxMaskEdBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.lbl_S_ShipDate = New System.Windows.Forms.Label
        Me.txt_S_ShipDateFm = New AxMSMask.AxMaskEdBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_S_SCIssDateTo = New AxMSMask.AxMaskEdBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_S_SCIssDate = New System.Windows.Forms.Label
        Me.txt_S_SCIssDateFm = New AxMSMask.AxMaskEdBox
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
        Me.txtResult = New System.Windows.Forms.ListBox
        Me.dgApproved = New System.Windows.Forms.DataGridView
        Me.dgHeader = New System.Windows.Forms.DataGridView
        Me.cmdApprove = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.cmdApply = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtSeqTo = New System.Windows.Forms.TextBox
        Me.txtSeqFm = New System.Windows.Forms.TextBox
        Me.rbNoUpdate = New System.Windows.Forms.RadioButton
        Me.rbSignature = New System.Windows.Forms.RadioButton
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
        Me.tcPOM00010.SuspendLayout()
        Me.tcPOM00010_1.SuspendLayout()
        CType(Me.txt_S_CustPODateTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_S_CustPODateFm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_S_ShipDateTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_S_ShipDateFm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_S_SCIssDateTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_S_SCIssDateFm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcPOM00010_2.SuspendLayout()
        CType(Me.dgApproved, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tcPOM00010_3.SuspendLayout()
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 480)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(752, 16)
        Me.StatusBar1.TabIndex = 1
        Me.StatusBar1.Text = "StatusBar1"
        '
        'cmdDelete
        '
        Me.cmdDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(112, 0)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(56, 40)
        Me.cmdDelete.TabIndex = 2
        Me.cmdDelete.TabStop = False
        Me.cmdDelete.Text = "&Delete"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(56, 0)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(56, 40)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.TabStop = False
        Me.cmdSave.Text = "&Save"
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(0, 0)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(56, 40)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.TabStop = False
        Me.cmdAdd.Text = "&Add"
        '
        'cmdLast
        '
        Me.cmdLast.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLast.Location = New System.Drawing.Point(650, 0)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(40, 40)
        Me.cmdLast.TabIndex = 12
        Me.cmdLast.TabStop = False
        Me.cmdLast.Text = ">>|"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.Location = New System.Drawing.Point(570, 0)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(40, 40)
        Me.cmdPrevious.TabIndex = 10
        Me.cmdPrevious.TabStop = False
        Me.cmdPrevious.Text = "<"
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(610, 0)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(40, 40)
        Me.cmdNext.TabIndex = 11
        Me.cmdNext.TabStop = False
        Me.cmdNext.Text = ">"
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFind.Location = New System.Drawing.Point(224, 0)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(56, 40)
        Me.cmdFind.TabIndex = 4
        Me.cmdFind.TabStop = False
        Me.cmdFind.Text = "&Find"
        '
        'cmdCopy
        '
        Me.cmdCopy.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(168, 0)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(56, 40)
        Me.cmdCopy.TabIndex = 3
        Me.cmdCopy.TabStop = False
        Me.cmdCopy.Text = "&Copy"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(280, 0)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(56, 40)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.TabStop = False
        Me.cmdClear.Text = "Cl&ear"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(696, 0)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(56, 40)
        Me.cmdExit.TabIndex = 13
        Me.cmdExit.TabStop = False
        Me.cmdExit.Text = "E&xit"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelRow.Location = New System.Drawing.Point(468, 0)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(56, 40)
        Me.cmdDelRow.TabIndex = 8
        Me.cmdDelRow.TabStop = False
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdFirst
        '
        Me.cmdFirst.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFirst.Location = New System.Drawing.Point(530, 0)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(40, 40)
        Me.cmdFirst.TabIndex = 9
        Me.cmdFirst.TabStop = False
        Me.cmdFirst.Text = "|<<"
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsRow.Location = New System.Drawing.Point(412, 0)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(56, 40)
        Me.cmdInsRow.TabIndex = 7
        Me.cmdInsRow.TabStop = False
        Me.cmdInsRow.Text = "I&ns Row"
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(342, 0)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(64, 40)
        Me.cmdSearch.TabIndex = 6
        Me.cmdSearch.TabStop = False
        Me.cmdSearch.Text = "Searc&h"
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
        'tcPOM00010
        '
        Me.tcPOM00010.Controls.Add(Me.tcPOM00010_1)
        Me.tcPOM00010.Controls.Add(Me.tcPOM00010_2)
        Me.tcPOM00010.Controls.Add(Me.tcPOM00010_3)
        Me.tcPOM00010.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tcPOM00010.Location = New System.Drawing.Point(0, 41)
        Me.tcPOM00010.Name = "tcPOM00010"
        Me.tcPOM00010.SelectedIndex = 0
        Me.tcPOM00010.Size = New System.Drawing.Size(752, 433)
        Me.tcPOM00010.TabIndex = 15
        '
        'tcPOM00010_1
        '
        Me.tcPOM00010_1.Controls.Add(Me.Label11)
        Me.tcPOM00010_1.Controls.Add(Me.Label12)
        Me.tcPOM00010_1.Controls.Add(Me.Label13)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_CustPODateTo)
        Me.tcPOM00010_1.Controls.Add(Me.Label14)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_CustPODate)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_CustPODateFm)
        Me.tcPOM00010_1.Controls.Add(Me.Label6)
        Me.tcPOM00010_1.Controls.Add(Me.Label7)
        Me.tcPOM00010_1.Controls.Add(Me.Label8)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_ShipDateTo)
        Me.tcPOM00010_1.Controls.Add(Me.Label9)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_ShipDate)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_ShipDateFm)
        Me.tcPOM00010_1.Controls.Add(Me.Label5)
        Me.tcPOM00010_1.Controls.Add(Me.Label4)
        Me.tcPOM00010_1.Controls.Add(Me.Label3)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_SCIssDateTo)
        Me.tcPOM00010_1.Controls.Add(Me.Label1)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_SCIssDate)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_SCIssDateFm)
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
        Me.tcPOM00010_1.Location = New System.Drawing.Point(4, 24)
        Me.tcPOM00010_1.Name = "tcPOM00010_1"
        Me.tcPOM00010_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tcPOM00010_1.Size = New System.Drawing.Size(744, 405)
        Me.tcPOM00010_1.TabIndex = 0
        Me.tcPOM00010_1.Text = "(1) Search"
        Me.tcPOM00010_1.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(159, 312)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 15)
        Me.Label11.TabIndex = 103
        Me.Label11.Text = "From"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(447, 312)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(21, 15)
        Me.Label12.TabIndex = 102
        Me.Label12.Text = "To"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(575, 320)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 16)
        Me.Label13.TabIndex = 101
        Me.Label13.Text = "(MM/DD/YYYY)"
        '
        'txt_S_CustPODateTo
        '
        Me.txt_S_CustPODateTo.Location = New System.Drawing.Point(479, 312)
        Me.txt_S_CustPODateTo.Name = "txt_S_CustPODateTo"
        Me.txt_S_CustPODateTo.OcxState = CType(resources.GetObject("txt_S_CustPODateTo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txt_S_CustPODateTo.Size = New System.Drawing.Size(88, 23)
        Me.txt_S_CustPODateTo.TabIndex = 93
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(295, 320)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 16)
        Me.Label14.TabIndex = 100
        Me.Label14.Text = "(MM/DD/YYYY)"
        '
        'lbl_S_CustPODate
        '
        Me.lbl_S_CustPODate.Location = New System.Drawing.Point(15, 312)
        Me.lbl_S_CustPODate.Name = "lbl_S_CustPODate"
        Me.lbl_S_CustPODate.Size = New System.Drawing.Size(100, 23)
        Me.lbl_S_CustPODate.TabIndex = 99
        Me.lbl_S_CustPODate.Text = "Cust PO Date"
        '
        'txt_S_CustPODateFm
        '
        Me.txt_S_CustPODateFm.Location = New System.Drawing.Point(199, 312)
        Me.txt_S_CustPODateFm.Name = "txt_S_CustPODateFm"
        Me.txt_S_CustPODateFm.OcxState = CType(resources.GetObject("txt_S_CustPODateFm.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txt_S_CustPODateFm.Size = New System.Drawing.Size(88, 23)
        Me.txt_S_CustPODateFm.TabIndex = 92
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(159, 288)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 15)
        Me.Label6.TabIndex = 98
        Me.Label6.Text = "From"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(447, 288)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 15)
        Me.Label7.TabIndex = 97
        Me.Label7.Text = "To"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(575, 296)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 16)
        Me.Label8.TabIndex = 96
        Me.Label8.Text = "(MM/DD/YYYY)"
        '
        'txt_S_ShipDateTo
        '
        Me.txt_S_ShipDateTo.Location = New System.Drawing.Point(479, 288)
        Me.txt_S_ShipDateTo.Name = "txt_S_ShipDateTo"
        Me.txt_S_ShipDateTo.OcxState = CType(resources.GetObject("txt_S_ShipDateTo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txt_S_ShipDateTo.Size = New System.Drawing.Size(88, 23)
        Me.txt_S_ShipDateTo.TabIndex = 91
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(295, 296)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 16)
        Me.Label9.TabIndex = 95
        Me.Label9.Text = "(MM/DD/YYYY)"
        '
        'lbl_S_ShipDate
        '
        Me.lbl_S_ShipDate.Location = New System.Drawing.Point(15, 288)
        Me.lbl_S_ShipDate.Name = "lbl_S_ShipDate"
        Me.lbl_S_ShipDate.Size = New System.Drawing.Size(100, 23)
        Me.lbl_S_ShipDate.TabIndex = 94
        Me.lbl_S_ShipDate.Text = "Ship Date"
        '
        'txt_S_ShipDateFm
        '
        Me.txt_S_ShipDateFm.Location = New System.Drawing.Point(199, 288)
        Me.txt_S_ShipDateFm.Name = "txt_S_ShipDateFm"
        Me.txt_S_ShipDateFm.OcxState = CType(resources.GetObject("txt_S_ShipDateFm.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txt_S_ShipDateFm.Size = New System.Drawing.Size(88, 23)
        Me.txt_S_ShipDateFm.TabIndex = 88
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(159, 264)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 15)
        Me.Label5.TabIndex = 90
        Me.Label5.Text = "From"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(447, 264)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(21, 15)
        Me.Label4.TabIndex = 89
        Me.Label4.Text = "To"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(575, 272)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "(MM/DD/YYYY)"
        '
        'txt_S_SCIssDateTo
        '
        Me.txt_S_SCIssDateTo.Location = New System.Drawing.Point(479, 264)
        Me.txt_S_SCIssDateTo.Name = "txt_S_SCIssDateTo"
        Me.txt_S_SCIssDateTo.OcxState = CType(resources.GetObject("txt_S_SCIssDateTo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txt_S_SCIssDateTo.Size = New System.Drawing.Size(88, 23)
        Me.txt_S_SCIssDateTo.TabIndex = 86
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(295, 272)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "(MM/DD/YYYY)"
        '
        'lbl_S_SCIssDate
        '
        Me.lbl_S_SCIssDate.Location = New System.Drawing.Point(15, 264)
        Me.lbl_S_SCIssDate.Name = "lbl_S_SCIssDate"
        Me.lbl_S_SCIssDate.Size = New System.Drawing.Size(100, 23)
        Me.lbl_S_SCIssDate.TabIndex = 81
        Me.lbl_S_SCIssDate.Text = "SC Issue Date"
        '
        'txt_S_SCIssDateFm
        '
        Me.txt_S_SCIssDateFm.Location = New System.Drawing.Point(199, 264)
        Me.txt_S_SCIssDateFm.Name = "txt_S_SCIssDateFm"
        Me.txt_S_SCIssDateFm.OcxState = CType(resources.GetObject("txt_S_SCIssDateFm.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txt_S_SCIssDateFm.Size = New System.Drawing.Size(88, 23)
        Me.txt_S_SCIssDateFm.TabIndex = 85
        '
        'cmd_S_SalTem
        '
        Me.cmd_S_SalTem.Location = New System.Drawing.Point(127, 232)
        Me.cmd_S_SalTem.Name = "cmd_S_SalTem"
        Me.cmd_S_SalTem.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_SalTem.TabIndex = 82
        Me.cmd_S_SalTem.Text = "「「"
        '
        'lbl_S_SalTem
        '
        Me.lbl_S_SalTem.AutoSize = True
        Me.lbl_S_SalTem.Location = New System.Drawing.Point(15, 240)
        Me.lbl_S_SalTem.Name = "lbl_S_SalTem"
        Me.lbl_S_SalTem.Size = New System.Drawing.Size(61, 15)
        Me.lbl_S_SalTem.TabIndex = 77
        Me.lbl_S_SalTem.Text = "Sales Team"
        '
        'txt_S_SalTem
        '
        Me.txt_S_SalTem.Location = New System.Drawing.Point(199, 232)
        Me.txt_S_SalTem.MaxLength = 5000
        Me.txt_S_SalTem.Name = "txt_S_SalTem"
        Me.txt_S_SalTem.Size = New System.Drawing.Size(537, 21)
        Me.txt_S_SalTem.TabIndex = 83
        '
        'cmd_S_PV
        '
        Me.cmd_S_PV.Location = New System.Drawing.Point(127, 208)
        Me.cmd_S_PV.Name = "cmd_S_PV"
        Me.cmd_S_PV.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_PV.TabIndex = 79
        Me.cmd_S_PV.Text = "「「"
        '
        'lbl_S_PV
        '
        Me.lbl_S_PV.AutoSize = True
        Me.lbl_S_PV.Location = New System.Drawing.Point(15, 216)
        Me.lbl_S_PV.Name = "lbl_S_PV"
        Me.lbl_S_PV.Size = New System.Drawing.Size(98, 15)
        Me.lbl_S_PV.TabIndex = 71
        Me.lbl_S_PV.Text = "Production Vendor"
        '
        'txt_S_PV
        '
        Me.txt_S_PV.Location = New System.Drawing.Point(199, 208)
        Me.txt_S_PV.MaxLength = 5000
        Me.txt_S_PV.Name = "txt_S_PV"
        Me.txt_S_PV.Size = New System.Drawing.Size(537, 21)
        Me.txt_S_PV.TabIndex = 80
        '
        'cmd_S_CV
        '
        Me.cmd_S_CV.Location = New System.Drawing.Point(127, 184)
        Me.cmd_S_CV.Name = "cmd_S_CV"
        Me.cmd_S_CV.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_CV.TabIndex = 76
        Me.cmd_S_CV.Text = "「「"
        '
        'lbl_S_CV
        '
        Me.lbl_S_CV.AutoSize = True
        Me.lbl_S_CV.Location = New System.Drawing.Point(15, 192)
        Me.lbl_S_CV.Name = "lbl_S_CV"
        Me.lbl_S_CV.Size = New System.Drawing.Size(83, 15)
        Me.lbl_S_CV.TabIndex = 67
        Me.lbl_S_CV.Text = "Custom Vendor"
        '
        'txt_S_CV
        '
        Me.txt_S_CV.Location = New System.Drawing.Point(199, 184)
        Me.txt_S_CV.MaxLength = 5000
        Me.txt_S_CV.Name = "txt_S_CV"
        Me.txt_S_CV.Size = New System.Drawing.Size(537, 21)
        Me.txt_S_CV.TabIndex = 78
        '
        'cmd_S_ItmNo
        '
        Me.cmd_S_ItmNo.Location = New System.Drawing.Point(127, 160)
        Me.cmd_S_ItmNo.Name = "cmd_S_ItmNo"
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_ItmNo.TabIndex = 74
        Me.cmd_S_ItmNo.Text = "「「"
        '
        'cmd_S_SCNo
        '
        Me.cmd_S_SCNo.Location = New System.Drawing.Point(127, 136)
        Me.cmd_S_SCNo.Name = "cmd_S_SCNo"
        Me.cmd_S_SCNo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_SCNo.TabIndex = 72
        Me.cmd_S_SCNo.Text = "「「"
        '
        'cmd_S_PONo
        '
        Me.cmd_S_PONo.Location = New System.Drawing.Point(127, 112)
        Me.cmd_S_PONo.Name = "cmd_S_PONo"
        Me.cmd_S_PONo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_PONo.TabIndex = 69
        Me.cmd_S_PONo.Text = "「「"
        '
        'cmd_S_CustPONo
        '
        Me.cmd_S_CustPONo.Location = New System.Drawing.Point(127, 88)
        Me.cmd_S_CustPONo.Name = "cmd_S_CustPONo"
        Me.cmd_S_CustPONo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_CustPONo.TabIndex = 66
        Me.cmd_S_CustPONo.Text = "「「"
        '
        'cmd_S_SecCust
        '
        Me.cmd_S_SecCust.Location = New System.Drawing.Point(127, 64)
        Me.cmd_S_SecCust.Name = "cmd_S_SecCust"
        Me.cmd_S_SecCust.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_SecCust.TabIndex = 64
        Me.cmd_S_SecCust.Text = "「「"
        '
        'cmd_S_PriCust
        '
        Me.cmd_S_PriCust.Location = New System.Drawing.Point(127, 40)
        Me.cmd_S_PriCust.Name = "cmd_S_PriCust"
        Me.cmd_S_PriCust.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_PriCust.TabIndex = 62
        Me.cmd_S_PriCust.Text = "「「"
        '
        'cmd_S_CoCde
        '
        Me.cmd_S_CoCde.Location = New System.Drawing.Point(127, 16)
        Me.cmd_S_CoCde.Name = "cmd_S_CoCde"
        Me.cmd_S_CoCde.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_CoCde.TabIndex = 60
        Me.cmd_S_CoCde.Text = "「「"
        '
        'lbl_S_ItmNo
        '
        Me.lbl_S_ItmNo.AutoSize = True
        Me.lbl_S_ItmNo.Location = New System.Drawing.Point(15, 168)
        Me.lbl_S_ItmNo.Name = "lbl_S_ItmNo"
        Me.lbl_S_ItmNo.Size = New System.Drawing.Size(47, 15)
        Me.lbl_S_ItmNo.TabIndex = 59
        Me.lbl_S_ItmNo.Text = "Item No"
        '
        'lbl_S_SCNo
        '
        Me.lbl_S_SCNo.AutoSize = True
        Me.lbl_S_SCNo.Location = New System.Drawing.Point(15, 144)
        Me.lbl_S_SCNo.Name = "lbl_S_SCNo"
        Me.lbl_S_SCNo.Size = New System.Drawing.Size(39, 15)
        Me.lbl_S_SCNo.TabIndex = 58
        Me.lbl_S_SCNo.Text = "SC No"
        '
        'lbl_S_PONo
        '
        Me.lbl_S_PONo.AutoSize = True
        Me.lbl_S_PONo.Location = New System.Drawing.Point(15, 120)
        Me.lbl_S_PONo.Name = "lbl_S_PONo"
        Me.lbl_S_PONo.Size = New System.Drawing.Size(41, 15)
        Me.lbl_S_PONo.TabIndex = 57
        Me.lbl_S_PONo.Text = "PO No"
        '
        'lbl_S_CustPO
        '
        Me.lbl_S_CustPO.AutoSize = True
        Me.lbl_S_CustPO.Location = New System.Drawing.Point(15, 96)
        Me.lbl_S_CustPO.Name = "lbl_S_CustPO"
        Me.lbl_S_CustPO.Size = New System.Drawing.Size(67, 15)
        Me.lbl_S_CustPO.TabIndex = 56
        Me.lbl_S_CustPO.Text = "Cust PO No"
        '
        'txt_S_ItmNo
        '
        Me.txt_S_ItmNo.Location = New System.Drawing.Point(199, 160)
        Me.txt_S_ItmNo.MaxLength = 5000
        Me.txt_S_ItmNo.Name = "txt_S_ItmNo"
        Me.txt_S_ItmNo.Size = New System.Drawing.Size(537, 21)
        Me.txt_S_ItmNo.TabIndex = 75
        '
        'txt_S_SCNo
        '
        Me.txt_S_SCNo.Location = New System.Drawing.Point(199, 136)
        Me.txt_S_SCNo.MaxLength = 5000
        Me.txt_S_SCNo.Name = "txt_S_SCNo"
        Me.txt_S_SCNo.Size = New System.Drawing.Size(537, 21)
        Me.txt_S_SCNo.TabIndex = 73
        '
        'txt_S_PONo
        '
        Me.txt_S_PONo.Location = New System.Drawing.Point(199, 112)
        Me.txt_S_PONo.MaxLength = 5000
        Me.txt_S_PONo.Name = "txt_S_PONo"
        Me.txt_S_PONo.Size = New System.Drawing.Size(537, 21)
        Me.txt_S_PONo.TabIndex = 70
        '
        'txt_S_CustPONo
        '
        Me.txt_S_CustPONo.Location = New System.Drawing.Point(199, 88)
        Me.txt_S_CustPONo.MaxLength = 5000
        Me.txt_S_CustPONo.Name = "txt_S_CustPONo"
        Me.txt_S_CustPONo.Size = New System.Drawing.Size(537, 21)
        Me.txt_S_CustPONo.TabIndex = 68
        '
        'txt_S_SecCust
        '
        Me.txt_S_SecCust.Location = New System.Drawing.Point(199, 64)
        Me.txt_S_SecCust.MaxLength = 5000
        Me.txt_S_SecCust.Name = "txt_S_SecCust"
        Me.txt_S_SecCust.Size = New System.Drawing.Size(537, 21)
        Me.txt_S_SecCust.TabIndex = 65
        '
        'txt_S_PriCust
        '
        Me.txt_S_PriCust.Location = New System.Drawing.Point(199, 40)
        Me.txt_S_PriCust.MaxLength = 5000
        Me.txt_S_PriCust.Name = "txt_S_PriCust"
        Me.txt_S_PriCust.Size = New System.Drawing.Size(537, 21)
        Me.txt_S_PriCust.TabIndex = 63
        '
        'txt_S_CoCde
        '
        Me.txt_S_CoCde.Enabled = False
        Me.txt_S_CoCde.Location = New System.Drawing.Point(199, 16)
        Me.txt_S_CoCde.MaxLength = 5000
        Me.txt_S_CoCde.Name = "txt_S_CoCde"
        Me.txt_S_CoCde.Size = New System.Drawing.Size(537, 21)
        Me.txt_S_CoCde.TabIndex = 61
        '
        'lbl_S_SecCust
        '
        Me.lbl_S_SecCust.AutoSize = True
        Me.lbl_S_SecCust.Location = New System.Drawing.Point(15, 72)
        Me.lbl_S_SecCust.Name = "lbl_S_SecCust"
        Me.lbl_S_SecCust.Size = New System.Drawing.Size(73, 15)
        Me.lbl_S_SecCust.TabIndex = 55
        Me.lbl_S_SecCust.Text = "Sec Customer"
        '
        'lbl_S_PriCust
        '
        Me.lbl_S_PriCust.AutoSize = True
        Me.lbl_S_PriCust.Location = New System.Drawing.Point(15, 48)
        Me.lbl_S_PriCust.Name = "lbl_S_PriCust"
        Me.lbl_S_PriCust.Size = New System.Drawing.Size(71, 15)
        Me.lbl_S_PriCust.TabIndex = 54
        Me.lbl_S_PriCust.Text = "Pri Customer"
        '
        'lbl_S_CoCde
        '
        Me.lbl_S_CoCde.AutoSize = True
        Me.lbl_S_CoCde.Location = New System.Drawing.Point(15, 24)
        Me.lbl_S_CoCde.Name = "lbl_S_CoCde"
        Me.lbl_S_CoCde.Size = New System.Drawing.Size(83, 15)
        Me.lbl_S_CoCde.TabIndex = 53
        Me.lbl_S_CoCde.Text = "Company Code"
        '
        'tcPOM00010_2
        '
        Me.tcPOM00010_2.Controls.Add(Me.txtResult)
        Me.tcPOM00010_2.Controls.Add(Me.dgApproved)
        Me.tcPOM00010_2.Controls.Add(Me.dgHeader)
        Me.tcPOM00010_2.Controls.Add(Me.cmdApprove)
        Me.tcPOM00010_2.Controls.Add(Me.GroupBox1)
        Me.tcPOM00010_2.Location = New System.Drawing.Point(4, 24)
        Me.tcPOM00010_2.Name = "tcPOM00010_2"
        Me.tcPOM00010_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tcPOM00010_2.Size = New System.Drawing.Size(744, 405)
        Me.tcPOM00010_2.TabIndex = 1
        Me.tcPOM00010_2.Text = "(2) Header"
        Me.tcPOM00010_2.UseVisualStyleBackColor = True
        '
        'txtResult
        '
        Me.txtResult.ItemHeight = 15
        Me.txtResult.Location = New System.Drawing.Point(413, 299)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(325, 94)
        Me.txtResult.TabIndex = 61
        '
        'dgApproved
        '
        Me.dgApproved.AllowUserToAddRows = False
        Me.dgApproved.AllowUserToDeleteRows = False
        Me.dgApproved.AllowUserToResizeColumns = False
        Me.dgApproved.AllowUserToResizeRows = False
        Me.dgApproved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgApproved.Location = New System.Drawing.Point(6, 299)
        Me.dgApproved.Name = "dgApproved"
        Me.dgApproved.ReadOnly = True
        Me.dgApproved.RowHeadersWidth = 30
        Me.dgApproved.Size = New System.Drawing.Size(402, 94)
        Me.dgApproved.TabIndex = 60
        '
        'dgHeader
        '
        Me.dgHeader.AllowUserToAddRows = False
        Me.dgHeader.AllowUserToDeleteRows = False
        Me.dgHeader.AllowUserToResizeRows = False
        Me.dgHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgHeader.Location = New System.Drawing.Point(4, 6)
        Me.dgHeader.Name = "dgHeader"
        Me.dgHeader.RowHeadersWidth = 30
        Me.dgHeader.Size = New System.Drawing.Size(732, 209)
        Me.dgHeader.TabIndex = 59
        '
        'cmdApprove
        '
        Me.cmdApprove.Location = New System.Drawing.Point(606, 237)
        Me.cmdApprove.Name = "cmdApprove"
        Me.cmdApprove.Size = New System.Drawing.Size(128, 48)
        Me.cmdApprove.TabIndex = 56
        Me.cmdApprove.Text = "Approve"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSelectAll)
        Me.GroupBox1.Controls.Add(Me.cmdApply)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtSeqTo)
        Me.GroupBox1.Controls.Add(Me.txtSeqFm)
        Me.GroupBox1.Controls.Add(Me.rbNoUpdate)
        Me.GroupBox1.Controls.Add(Me.rbSignature)
        Me.GroupBox1.Controls.Add(Me.rb_BelowBasicPrice)
        Me.GroupBox1.Controls.Add(Me.rbMOQMOA)
        Me.GroupBox1.Controls.Add(Me.rbOneTimePrice)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 221)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(576, 72)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Approval Type"
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Location = New System.Drawing.Point(440, 16)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(120, 24)
        Me.cmdSelectAll.TabIndex = 50
        Me.cmdSelectAll.Text = "Select All"
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(440, 40)
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
        Me.Label17.Size = New System.Drawing.Size(21, 15)
        Me.Label17.TabIndex = 44
        Me.Label17.Text = "To"
        Me.Label17.Visible = False
        '
        'txtSeqTo
        '
        Me.txtSeqTo.Location = New System.Drawing.Point(528, 16)
        Me.txtSeqTo.Name = "txtSeqTo"
        Me.txtSeqTo.Size = New System.Drawing.Size(32, 21)
        Me.txtSeqTo.TabIndex = 48
        Me.txtSeqTo.Visible = False
        '
        'txtSeqFm
        '
        Me.txtSeqFm.Location = New System.Drawing.Point(464, 16)
        Me.txtSeqFm.Name = "txtSeqFm"
        Me.txtSeqFm.Size = New System.Drawing.Size(32, 21)
        Me.txtSeqFm.TabIndex = 47
        Me.txtSeqFm.Visible = False
        '
        'rbNoUpdate
        '
        Me.rbNoUpdate.Location = New System.Drawing.Point(136, 40)
        Me.rbNoUpdate.Name = "rbNoUpdate"
        Me.rbNoUpdate.Size = New System.Drawing.Size(104, 24)
        Me.rbNoUpdate.TabIndex = 46
        Me.rbNoUpdate.Text = "N - No Update"
        '
        'rbSignature
        '
        Me.rbSignature.Checked = True
        Me.rbSignature.Location = New System.Drawing.Point(8, 40)
        Me.rbSignature.Name = "rbSignature"
        Me.rbSignature.Size = New System.Drawing.Size(104, 24)
        Me.rbSignature.TabIndex = 45
        Me.rbSignature.TabStop = True
        Me.rbSignature.Text = "S - Signature"
        '
        'rb_BelowBasicPrice
        '
        Me.rb_BelowBasicPrice.Enabled = False
        Me.rb_BelowBasicPrice.Location = New System.Drawing.Point(136, 16)
        Me.rb_BelowBasicPrice.Name = "rb_BelowBasicPrice"
        Me.rb_BelowBasicPrice.Size = New System.Drawing.Size(136, 24)
        Me.rb_BelowBasicPrice.TabIndex = 43
        Me.rb_BelowBasicPrice.Text = "B - Below Basic Price"
        '
        'rbMOQMOA
        '
        Me.rbMOQMOA.Enabled = False
        Me.rbMOQMOA.Location = New System.Drawing.Point(288, 16)
        Me.rbMOQMOA.Name = "rbMOQMOA"
        Me.rbMOQMOA.Size = New System.Drawing.Size(120, 24)
        Me.rbMOQMOA.TabIndex = 44
        Me.rbMOQMOA.Text = "M - MOQ/MOA"
        '
        'rbOneTimePrice
        '
        Me.rbOneTimePrice.Enabled = False
        Me.rbOneTimePrice.Location = New System.Drawing.Point(8, 16)
        Me.rbOneTimePrice.Name = "rbOneTimePrice"
        Me.rbOneTimePrice.Size = New System.Drawing.Size(120, 24)
        Me.rbOneTimePrice.TabIndex = 42
        Me.rbOneTimePrice.Text = "P - One Time Price"
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
        Me.tcPOM00010_3.Location = New System.Drawing.Point(4, 24)
        Me.tcPOM00010_3.Name = "tcPOM00010_3"
        Me.tcPOM00010_3.Padding = New System.Windows.Forms.Padding(3)
        Me.tcPOM00010_3.Size = New System.Drawing.Size(744, 405)
        Me.tcPOM00010_3.TabIndex = 2
        Me.tcPOM00010_3.Text = "(3) Detail"
        Me.tcPOM00010_3.UseVisualStyleBackColor = True
        '
        'txtAppDat
        '
        Me.txtAppDat.Location = New System.Drawing.Point(480, 62)
        Me.txtAppDat.Name = "txtAppDat"
        Me.txtAppDat.ReadOnly = True
        Me.txtAppDat.Size = New System.Drawing.Size(134, 21)
        Me.txtAppDat.TabIndex = 85
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(365, 62)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(104, 15)
        Me.Label22.TabIndex = 84
        Me.Label22.Text = "Last Approval Date"
        '
        'txtAppCount
        '
        Me.txtAppCount.Location = New System.Drawing.Point(480, 38)
        Me.txtAppCount.Name = "txtAppCount"
        Me.txtAppCount.ReadOnly = True
        Me.txtAppCount.Size = New System.Drawing.Size(134, 21)
        Me.txtAppCount.TabIndex = 83
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(365, 38)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(87, 15)
        Me.Label21.TabIndex = 82
        Me.Label21.Text = "Approval Count"
        '
        'txtSignAppFlg
        '
        Me.txtSignAppFlg.Location = New System.Drawing.Point(480, 11)
        Me.txtSignAppFlg.Name = "txtSignAppFlg"
        Me.txtSignAppFlg.ReadOnly = True
        Me.txtSignAppFlg.Size = New System.Drawing.Size(134, 21)
        Me.txtSignAppFlg.TabIndex = 81
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(365, 14)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(87, 15)
        Me.Label16.TabIndex = 80
        Me.Label16.Text = "Approval Status"
        '
        'dgDetail
        '
        Me.dgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetail.Location = New System.Drawing.Point(6, 158)
        Me.dgDetail.Name = "dgDetail"
        Me.dgDetail.RowHeadersWidth = 30
        Me.dgDetail.Size = New System.Drawing.Size(730, 241)
        Me.dgDetail.TabIndex = 79
        '
        'txtSCNo
        '
        Me.txtSCNo.Location = New System.Drawing.Point(120, 131)
        Me.txtSCNo.Name = "txtSCNo"
        Me.txtSCNo.ReadOnly = True
        Me.txtSCNo.Size = New System.Drawing.Size(208, 21)
        Me.txtSCNo.TabIndex = 78
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 131)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(63, 15)
        Me.Label20.TabIndex = 77
        Me.Label20.Text = "SC Number"
        '
        'txtSecCus
        '
        Me.txtSecCus.Location = New System.Drawing.Point(120, 107)
        Me.txtSecCus.Name = "txtSecCus"
        Me.txtSecCus.ReadOnly = True
        Me.txtSecCus.Size = New System.Drawing.Size(208, 21)
        Me.txtSecCus.TabIndex = 76
        '
        'txtPriCus
        '
        Me.txtPriCus.Location = New System.Drawing.Point(120, 83)
        Me.txtPriCus.Name = "txtPriCus"
        Me.txtPriCus.ReadOnly = True
        Me.txtPriCus.Size = New System.Drawing.Size(208, 21)
        Me.txtPriCus.TabIndex = 75
        '
        'txtPOSts
        '
        Me.txtPOSts.Location = New System.Drawing.Point(120, 59)
        Me.txtPOSts.Name = "txtPOSts"
        Me.txtPOSts.ReadOnly = True
        Me.txtPOSts.Size = New System.Drawing.Size(208, 21)
        Me.txtPOSts.TabIndex = 74
        '
        'txtPONo
        '
        Me.txtPONo.Location = New System.Drawing.Point(120, 35)
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.ReadOnly = True
        Me.txtPONo.Size = New System.Drawing.Size(208, 21)
        Me.txtPONo.TabIndex = 73
        '
        'txtCocde
        '
        Me.txtCocde.Location = New System.Drawing.Point(120, 11)
        Me.txtCocde.Name = "txtCocde"
        Me.txtCocde.ReadOnly = True
        Me.txtCocde.Size = New System.Drawing.Size(208, 21)
        Me.txtCocde.TabIndex = 72
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(8, 107)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(107, 15)
        Me.Label19.TabIndex = 71
        Me.Label19.Text = "Secondary Customer"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 83)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(96, 15)
        Me.Label18.TabIndex = 70
        Me.Label18.Text = "Primary Customer"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 59)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 15)
        Me.Label15.TabIndex = 69
        Me.Label15.Text = "PO Status"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 15)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "PO Number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Company"
        '
        'POM00010
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(752, 496)
        Me.Controls.Add(Me.cmdDelete)
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
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.tcPOM00010)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "POM00010"
        Me.Text = "POM00010 - Purchase Order Approval Maintenance"
        Me.tcPOM00010.ResumeLayout(False)
        Me.tcPOM00010_1.ResumeLayout(False)
        Me.tcPOM00010_1.PerformLayout()
        CType(Me.txt_S_CustPODateTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_S_CustPODateFm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_S_ShipDateTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_S_ShipDateFm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_S_SCIssDateTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_S_SCIssDateFm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcPOM00010_2.ResumeLayout(False)
        CType(Me.dgApproved, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tcPOM00010_3.ResumeLayout(False)
        Me.tcPOM00010_3.PerformLayout()
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public rs_SYMUSRCO As New DataSet
    Public rs_POM00010 As New DataSet
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

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
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
        Dim SCISSDATFM As String
        Dim SCISSDATTO As String
        Dim SHPDATFM As String
        Dim SHPDATTO As String
        Dim CUSPODATFM As String
        Dim CUSPODATTO As String

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


        If Me.txt_S_SCIssDateFm.CtlText <> "__/__/____" Then
            If Not IsDate(Me.txt_S_SCIssDateFm.CtlText) Then
                MsgBox("Invalid Date Format: Issue Date From")
                Me.txt_S_SCIssDateFm.Focus()
                Exit Sub
            End If
        End If

        If Me.txt_S_SCIssDateTo.CtlText <> "__/__/____" Then
            If Not IsDate(Me.txt_S_SCIssDateTo.CtlText) Then
                MsgBox("Invalid Date Format: Issue Date To")
                Me.txt_S_SCIssDateTo.Focus()
                Exit Sub
            End If
        End If

        If Mid(Me.txt_S_SCIssDateFm.CtlText, 7) > Mid(Me.txt_S_SCIssDateTo.CtlText, 7) Then
            MsgBox("Issue Date: End Date < Start Date (YY)")
            Me.txt_S_SCIssDateFm.Focus()
            Exit Sub
        ElseIf Mid(Me.txt_S_SCIssDateFm.CtlText, 7) = Mid(Me.txt_S_SCIssDateTo.CtlText, 7) Then
            If Me.txt_S_SCIssDateFm.CtlText.Substring(0, 2) > Me.txt_S_SCIssDateTo.CtlText.Substring(0, 2) Then
                MsgBox("Issue Date: End Date < Start Date (MM)")
                Me.txt_S_SCIssDateFm.Focus()
                Exit Sub
            ElseIf Me.txt_S_SCIssDateFm.CtlText.Substring(0, 2) = Me.txt_S_SCIssDateTo.CtlText.Substring(0, 2) Then
                If Me.txt_S_SCIssDateFm.CtlText.Substring(3, 2) > Me.txt_S_SCIssDateTo.CtlText.Substring(3, 2) Then
                    MsgBox("Issue Date: End Date < Start Date (DD)")
                    Me.txt_S_SCIssDateFm.Focus()
                    Exit Sub
                End If
            End If
        End If

        If Me.txt_S_SCIssDateFm.CtlText = "__/__/____" Then
            SCISSDATFM = "01/01/1900"
        Else
            SCISSDATFM = Me.txt_S_SCIssDateFm.CtlText
        End If

        If Me.txt_S_SCIssDateTo.CtlText = "__/__/____" Then
            SCISSDATTO = "01/01/1900"
        Else
            SCISSDATTO = Me.txt_S_SCIssDateTo.CtlText
        End If



        If Me.txt_S_ShipDateFm.CtlText <> "__/__/____" Then
            If Not IsDate(Me.txt_S_ShipDateFm.CtlText) Then
                MsgBox("Invalid Date Format: Ship Date From")
                Me.txt_S_ShipDateFm.Focus()
                Exit Sub
            End If
        End If

        If Me.txt_S_ShipDateTo.CtlText <> "__/__/____" Then
            If Not IsDate(Me.txt_S_ShipDateTo.CtlText) Then
                MsgBox("Invalid Date Format: Ship Date To")
                Me.txt_S_ShipDateTo.Focus()
                Exit Sub
            End If
        End If

        If Mid(Me.txt_S_ShipDateFm.CtlText, 7) > Mid(Me.txt_S_ShipDateTo.CtlText, 7) Then
            MsgBox("Ship Date: End Date < Start Date (YY)")
            Me.txt_S_ShipDateFm.Focus()
            Exit Sub
        ElseIf Mid(Me.txt_S_ShipDateFm.CtlText, 7) = Mid(Me.txt_S_ShipDateTo.CtlText, 7) Then
            If Me.txt_S_ShipDateFm.CtlText.Substring(0, 2) > Me.txt_S_ShipDateTo.CtlText.Substring(0, 2) Then
                MsgBox("Ship Date: End Date < Start Date (MM)")
                Me.txt_S_ShipDateFm.Focus()
                Exit Sub
            ElseIf Me.txt_S_ShipDateFm.CtlText.Substring(0, 2) = Me.txt_S_ShipDateTo.CtlText.Substring(0, 2) Then
                If Me.txt_S_ShipDateFm.CtlText.Substring(3, 2) > Me.txt_S_ShipDateTo.CtlText.Substring(3, 2) Then
                    MsgBox("Ship Date: End Date < Start Date (DD)")
                    Me.txt_S_ShipDateFm.Focus()
                    Exit Sub
                End If
            End If
        End If

        If Me.txt_S_ShipDateFm.CtlText = "__/__/____" Then
            SHPDATFM = "01/01/1900"
        Else
            SHPDATFM = Me.txt_S_ShipDateFm.CtlText
        End If

        If Me.txt_S_ShipDateTo.CtlText = "__/__/____" Then
            SHPDATTO = "01/01/1900"
        Else
            SHPDATTO = Me.txt_S_ShipDateTo.CtlText
        End If



        If Me.txt_S_CustPODateFm.CtlText <> "__/__/____" Then
            If IsDate(Me.txt_S_CustPODateFm.CtlText) Then
                MsgBox("Invalid Date Format: Customer PO Date From")
                Me.txt_S_CustPODateFm.Focus()
                Exit Sub
            End If
        End If

        If Me.txt_S_CustPODateTo.CtlText <> "__/__/____" Then
            If IsDate(Me.txt_S_CustPODateTo.CtlText) Then
                MsgBox("Invalid Date Format: Customer PO Date To")
                Me.txt_S_CustPODateTo.Focus()
                Exit Sub
            End If
        End If

        If Mid(Me.txt_S_CustPODateFm.CtlText, 7) > Mid(Me.txt_S_CustPODateTo.CtlText, 7) Then
            MsgBox("Customer PO Date: End Date < Start Date (YY)")
            Me.txt_S_CustPODateFm.Focus()
            Exit Sub
        ElseIf Mid(Me.txt_S_CustPODateFm.CtlText, 7) = Mid(Me.txt_S_CustPODateTo.CtlText, 7) Then
            If Me.txt_S_CustPODateFm.CtlText.Substring(0, 2) > Me.txt_S_CustPODateTo.CtlText.Substring(0, 2) Then
                MsgBox("Customer PO Date: End Date < Start Date (MM)")
                Me.txt_S_CustPODateFm.Focus()
                Exit Sub
            ElseIf Me.txt_S_CustPODateFm.CtlText.Substring(0, 2) = Me.txt_S_CustPODateTo.CtlText.Substring(0, 2) Then
                If Me.txt_S_CustPODateFm.CtlText.Substring(3, 2) > Me.txt_S_CustPODateTo.CtlText.Substring(3, 2) Then
                    MsgBox("Customer PO Date: End Date < Start Date (DD)")
                    Me.txt_S_CustPODateFm.Focus()
                    Exit Sub
                End If
            End If
        End If

        If Me.txt_S_CustPODateFm.CtlText = "__/__/____" Then
            CUSPODATFM = "01/01/1900"
        Else
            CUSPODATFM = Me.txt_S_CustPODateFm.CtlText
        End If

        If Me.txt_S_CustPODateTo.CtlText = "__/__/____" Then
            CUSPODATTO = "01/01/1900"
        Else
            CUSPODATTO = Me.txt_S_CustPODateTo.CtlText
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
                    SCISSDATFM & "','" & _
                    SCISSDATTO & "','" & _
                    SHPDATFM & "','" & _
                    SHPDATTO & "','" & _
                    CUSPODATFM & "','" & _
                    CUSPODATTO & "','" & _
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
            If dgHeader.SelectedRows(i).Cells("Act").Value <> "" Then
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
        Call cmdFind_Click(sender, e)


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
            Me.cmdAdd.Enabled = False
            Me.cmdSave.Enabled = False
            Me.cmdDelete.Enabled = False
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = True
            Me.cmdClear.Enabled = True

            Me.cmdSearch.Enabled = False

            Me.cmdInsRow.Enabled = False
            Me.cmdDelRow.Enabled = False
            Me.cmdFirst.Enabled = False
            Me.cmdPrevious.Enabled = False
            Me.cmdNext.Enabled = False
            Me.cmdLast.Enabled = False

            Me.cmdExit.Enabled = True

            Me.tcPOM00010.TabPages(0).Enabled = True
            Me.tcPOM00010.TabPages(1).Enabled = False
            Me.tcPOM00010.TabPages(2).Enabled = False

            Me.tcPOM00010.SelectedIndex = 0

            Me.txtResult.Items.Clear()
            rs_POM00010_AppList.Clear()

        ElseIf m = "MODIFY" Then
            Me.cmdAdd.Enabled = False
            Me.cmdSave.Enabled = False
            Me.cmdDelete.Enabled = False
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = False
            Me.cmdClear.Enabled = True

            Me.cmdSearch.Enabled = False

            Me.cmdInsRow.Enabled = False
            Me.cmdDelRow.Enabled = False
            Me.cmdFirst.Enabled = True
            Me.cmdPrevious.Enabled = True
            Me.cmdNext.Enabled = True
            Me.cmdLast.Enabled = True

            Me.cmdExit.Enabled = True

            Me.tcPOM00010.TabPages(0).Enabled = False
            Me.tcPOM00010.TabPages(1).Enabled = True
            Me.tcPOM00010.TabPages(2).Enabled = True

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
            sPriCus = dgHeader.SelectedRows(0).Cells("Pri Cust").Value & " - " & dgHeader.SelectedRows(0).Cells("Pri Cust Name").Value
            sSecCus = dgHeader.SelectedRows(0).Cells("Sec Cust").Value & " - " & dgHeader.SelectedRows(0).Cells("Sec Cust Name").Value
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
            .Columns(i).Width = 30
            .Columns(i).HeaderText = "Act"
            i = i + 1
            .Columns(i).Width = 32
            .Columns(i).HeaderText = "App Sts"
            i = i + 1
            .Columns(i).Width = 32
            .Columns(i).HeaderText = "App Cnt"
            i = i + 1
            .Columns(i).Visible = False
            i = i + 1
            .Columns(i).Width = 42
            .Columns(i).HeaderText = "Comp"
            i = i + 1
            .Columns(i).Width = 68
            .Columns(i).HeaderText = "PO No"
            i = i + 1
            .Columns(i).Width = 35
            .Columns(i).HeaderText = "PO Sts"
            i = i + 1
            .Columns(i).Width = 42
            .Columns(i).HeaderText = "Pri Cust"
            i = i + 1
            .Columns(i).Width = 90
            .Columns(i).HeaderText = "Pri Cust Name"
            i = i + 1
            .Columns(i).Width = 42
            .Columns(i).HeaderText = "Sec Cust"
            i = i + 1
            .Columns(i).Width = 55
            .Columns(i).HeaderText = "Sec Cust Name"
            i = i + 1
            .Columns(i).Width = 80
            .Columns(i).HeaderText = "Cust PO No"
            i = i + 1
            .Columns(i).Width = 68
            .Columns(i).HeaderText = "SC No"
            i = i + 1
            .Columns(i).Width = 36
            .Columns(i).HeaderText = "CV"
            i = i + 1
            .Columns(i).Width = 65
            .Columns(i).HeaderText = "CV Name"

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

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
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

    Private Sub cmdPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.Click
        'TabControl1.TabPages(1).Enabled = True
        'Me.BaseTabControl1.tabpages(1).enabled = True
    End Sub

    Private Sub dgHeader_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Call Me.formInit("INIT")
    End Sub
End Class
