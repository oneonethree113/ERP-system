Public Class CLM00002
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
    Friend WithEvents tcPOM00010_2 As System.Windows.Forms.TabPage
    Friend WithEvents cmdHDRShowAll As System.Windows.Forms.Button
    Friend WithEvents txtHDRResult As System.Windows.Forms.ListBox
    Friend WithEvents dgHDRApproved As System.Windows.Forms.DataGridView
    Friend WithEvents dgHeader As System.Windows.Forms.DataGridView
    Friend WithEvents cmdHDRApprove As System.Windows.Forms.Button
    Friend WithEvents gb_ApprovalType As System.Windows.Forms.GroupBox
    Friend WithEvents rbHDROPEN As System.Windows.Forms.RadioButton
    Friend WithEvents cmdHDRSelectAll As System.Windows.Forms.Button
    Friend WithEvents rbHDRCANL As System.Windows.Forms.RadioButton
    Friend WithEvents cmdHDRApply As System.Windows.Forms.Button
    Friend WithEvents rbHDRNoUpd As System.Windows.Forms.RadioButton
    Friend WithEvents rbHDRAPV1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbHDRCLOS As System.Windows.Forms.RadioButton
    Friend WithEvents rbHDRAPV2 As System.Windows.Forms.RadioButton
    Friend WithEvents tcPOM00010_1 As System.Windows.Forms.TabPage
    Friend WithEvents txt_S_CaCreDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_S_CaCreDateFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblCaCreDateFm As System.Windows.Forms.Label
    Friend WithEvents lblCaCreDateTo As System.Windows.Forms.Label
    Friend WithEvents lblCaCreDateToLbl As System.Windows.Forms.Label
    Friend WithEvents lblCaCreDateFmLbl As System.Windows.Forms.Label
    Friend WithEvents txt_S_CustStyleNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_CustItmNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_CaSts As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_CaOrdNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_InvNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_JobNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_PV As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_ItmNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_SCNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_PONo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_CustPONo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_SecCust As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_PriCust As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_CoCde As System.Windows.Forms.TextBox
    Friend WithEvents lblCustStyleNo As System.Windows.Forms.Label
    Friend WithEvents cmd_S_CustStyleNo As System.Windows.Forms.Button
    Friend WithEvents lblCustItmNo As System.Windows.Forms.Label
    Friend WithEvents cmd_S_CustItmNo As System.Windows.Forms.Button
    Friend WithEvents cmd_S_CaSts As System.Windows.Forms.Button
    Friend WithEvents lbl_S_CaSts As System.Windows.Forms.Label
    Friend WithEvents cmd_S_CaOrdNo As System.Windows.Forms.Button
    Friend WithEvents lbl_S_CaOrdNo As System.Windows.Forms.Label
    Friend WithEvents lbl_S_InvNo As System.Windows.Forms.Label
    Friend WithEvents cmd_S_InvNo As System.Windows.Forms.Button
    Friend WithEvents cmd_S_JobNo As System.Windows.Forms.Button
    Friend WithEvents lbl_S_JobNo As System.Windows.Forms.Label
    Friend WithEvents lbl_S_CaCreDate As System.Windows.Forms.Label
    Friend WithEvents cmd_S_PV As System.Windows.Forms.Button
    Friend WithEvents lbl_S_PV As System.Windows.Forms.Label
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
    Friend WithEvents lbl_S_SecCust As System.Windows.Forms.Label
    Friend WithEvents lbl_S_PriCust As System.Windows.Forms.Label
    Friend WithEvents lbl_S_CoCde As System.Windows.Forms.Label
    Friend WithEvents tcPOM00010 As ERPSystem.BaseTabControl
    Friend WithEvents rbDTLAPV2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbDTLAPV1 As System.Windows.Forms.RadioButton
    Friend WithEvents cmdDTLApply As System.Windows.Forms.Button
    Friend WithEvents cmdDTLSelectAll As System.Windows.Forms.Button
    Friend WithEvents rbDTLNoUpd As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
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
        Me.tcPOM00010_2 = New System.Windows.Forms.TabPage
        Me.cmdHDRShowAll = New System.Windows.Forms.Button
        Me.txtHDRResult = New System.Windows.Forms.ListBox
        Me.dgHDRApproved = New System.Windows.Forms.DataGridView
        Me.dgHeader = New System.Windows.Forms.DataGridView
        Me.cmdHDRApprove = New System.Windows.Forms.Button
        Me.gb_ApprovalType = New System.Windows.Forms.GroupBox
        Me.rbHDROPEN = New System.Windows.Forms.RadioButton
        Me.cmdHDRSelectAll = New System.Windows.Forms.Button
        Me.rbHDRCANL = New System.Windows.Forms.RadioButton
        Me.cmdHDRApply = New System.Windows.Forms.Button
        Me.rbHDRNoUpd = New System.Windows.Forms.RadioButton
        Me.rbHDRAPV1 = New System.Windows.Forms.RadioButton
        Me.rbHDRCLOS = New System.Windows.Forms.RadioButton
        Me.rbHDRAPV2 = New System.Windows.Forms.RadioButton
        Me.tcPOM00010_1 = New System.Windows.Forms.TabPage
        Me.txt_S_CaCreDateTo = New System.Windows.Forms.MaskedTextBox
        Me.txt_S_CaCreDateFm = New System.Windows.Forms.MaskedTextBox
        Me.lblCaCreDateFm = New System.Windows.Forms.Label
        Me.lblCaCreDateTo = New System.Windows.Forms.Label
        Me.lblCaCreDateToLbl = New System.Windows.Forms.Label
        Me.lblCaCreDateFmLbl = New System.Windows.Forms.Label
        Me.txt_S_CustStyleNo = New System.Windows.Forms.TextBox
        Me.txt_S_CustItmNo = New System.Windows.Forms.TextBox
        Me.txt_S_CaSts = New System.Windows.Forms.TextBox
        Me.txt_S_CaOrdNo = New System.Windows.Forms.TextBox
        Me.txt_S_InvNo = New System.Windows.Forms.TextBox
        Me.txt_S_JobNo = New System.Windows.Forms.TextBox
        Me.txt_S_PV = New System.Windows.Forms.TextBox
        Me.txt_S_ItmNo = New System.Windows.Forms.TextBox
        Me.txt_S_SCNo = New System.Windows.Forms.TextBox
        Me.txt_S_PONo = New System.Windows.Forms.TextBox
        Me.txt_S_CustPONo = New System.Windows.Forms.TextBox
        Me.txt_S_SecCust = New System.Windows.Forms.TextBox
        Me.txt_S_PriCust = New System.Windows.Forms.TextBox
        Me.txt_S_CoCde = New System.Windows.Forms.TextBox
        Me.lblCustStyleNo = New System.Windows.Forms.Label
        Me.cmd_S_CustStyleNo = New System.Windows.Forms.Button
        Me.lblCustItmNo = New System.Windows.Forms.Label
        Me.cmd_S_CustItmNo = New System.Windows.Forms.Button
        Me.cmd_S_CaSts = New System.Windows.Forms.Button
        Me.lbl_S_CaSts = New System.Windows.Forms.Label
        Me.cmd_S_CaOrdNo = New System.Windows.Forms.Button
        Me.lbl_S_CaOrdNo = New System.Windows.Forms.Label
        Me.lbl_S_InvNo = New System.Windows.Forms.Label
        Me.cmd_S_InvNo = New System.Windows.Forms.Button
        Me.cmd_S_JobNo = New System.Windows.Forms.Button
        Me.lbl_S_JobNo = New System.Windows.Forms.Label
        Me.lbl_S_CaCreDate = New System.Windows.Forms.Label
        Me.cmd_S_PV = New System.Windows.Forms.Button
        Me.lbl_S_PV = New System.Windows.Forms.Label
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
        Me.lbl_S_SecCust = New System.Windows.Forms.Label
        Me.lbl_S_PriCust = New System.Windows.Forms.Label
        Me.lbl_S_CoCde = New System.Windows.Forms.Label
        Me.tcPOM00010 = New ERPSystem.BaseTabControl
        Me.rbDTLAPV2 = New System.Windows.Forms.RadioButton
        Me.rbDTLAPV1 = New System.Windows.Forms.RadioButton
        Me.cmdDTLApply = New System.Windows.Forms.Button
        Me.cmdDTLSelectAll = New System.Windows.Forms.Button
        Me.rbDTLNoUpd = New System.Windows.Forms.RadioButton
        Me.tcPOM00010_2.SuspendLayout()
        CType(Me.dgHDRApproved, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_ApprovalType.SuspendLayout()
        Me.tcPOM00010_1.SuspendLayout()
        Me.tcPOM00010.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 480)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(752, 16)
        Me.StatusBar1.TabIndex = 1
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
        'tcPOM00010_2
        '
        Me.tcPOM00010_2.Controls.Add(Me.cmdHDRShowAll)
        Me.tcPOM00010_2.Controls.Add(Me.txtHDRResult)
        Me.tcPOM00010_2.Controls.Add(Me.dgHDRApproved)
        Me.tcPOM00010_2.Controls.Add(Me.dgHeader)
        Me.tcPOM00010_2.Controls.Add(Me.cmdHDRApprove)
        Me.tcPOM00010_2.Controls.Add(Me.gb_ApprovalType)
        Me.tcPOM00010_2.Location = New System.Drawing.Point(4, 24)
        Me.tcPOM00010_2.Name = "tcPOM00010_2"
        Me.tcPOM00010_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tcPOM00010_2.Size = New System.Drawing.Size(744, 405)
        Me.tcPOM00010_2.TabIndex = 1
        Me.tcPOM00010_2.Text = "(2) Claim List"
        Me.tcPOM00010_2.UseVisualStyleBackColor = True
        '
        'cmdHDRShowAll
        '
        Me.cmdHDRShowAll.Location = New System.Drawing.Point(646, 280)
        Me.cmdHDRShowAll.Name = "cmdHDRShowAll"
        Me.cmdHDRShowAll.Size = New System.Drawing.Size(90, 36)
        Me.cmdHDRShowAll.TabIndex = 11
        Me.cmdHDRShowAll.Text = "Show All"
        '
        'txtHDRResult
        '
        Me.txtHDRResult.ItemHeight = 15
        Me.txtHDRResult.Location = New System.Drawing.Point(4, 289)
        Me.txtHDRResult.Name = "txtHDRResult"
        Me.txtHDRResult.Size = New System.Drawing.Size(323, 109)
        Me.txtHDRResult.TabIndex = 2
        '
        'dgHDRApproved
        '
        Me.dgHDRApproved.AllowUserToAddRows = False
        Me.dgHDRApproved.AllowUserToDeleteRows = False
        Me.dgHDRApproved.AllowUserToResizeColumns = False
        Me.dgHDRApproved.AllowUserToResizeRows = False
        Me.dgHDRApproved.BackgroundColor = System.Drawing.SystemColors.InactiveBorder
        Me.dgHDRApproved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgHDRApproved.Location = New System.Drawing.Point(4, 280)
        Me.dgHDRApproved.Name = "dgHDRApproved"
        Me.dgHDRApproved.ReadOnly = True
        Me.dgHDRApproved.RowHeadersWidth = 30
        Me.dgHDRApproved.Size = New System.Drawing.Size(331, 119)
        Me.dgHDRApproved.TabIndex = 11
        Me.dgHDRApproved.Visible = False
        '
        'dgHeader
        '
        Me.dgHeader.AllowUserToAddRows = False
        Me.dgHeader.AllowUserToDeleteRows = False
        Me.dgHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgHeader.Location = New System.Drawing.Point(4, 6)
        Me.dgHeader.Name = "dgHeader"
        Me.dgHeader.RowHeadersWidth = 30
        Me.dgHeader.Size = New System.Drawing.Size(732, 268)
        Me.dgHeader.TabIndex = 1
        '
        'cmdHDRApprove
        '
        Me.cmdHDRApprove.Enabled = False
        Me.cmdHDRApprove.Location = New System.Drawing.Point(646, 322)
        Me.cmdHDRApprove.Name = "cmdHDRApprove"
        Me.cmdHDRApprove.Size = New System.Drawing.Size(90, 77)
        Me.cmdHDRApprove.TabIndex = 12
        Me.cmdHDRApprove.Text = "Approve"
        '
        'gb_ApprovalType
        '
        Me.gb_ApprovalType.Controls.Add(Me.rbHDROPEN)
        Me.gb_ApprovalType.Controls.Add(Me.cmdHDRSelectAll)
        Me.gb_ApprovalType.Controls.Add(Me.rbHDRCANL)
        Me.gb_ApprovalType.Controls.Add(Me.cmdHDRApply)
        Me.gb_ApprovalType.Controls.Add(Me.rbHDRNoUpd)
        Me.gb_ApprovalType.Controls.Add(Me.rbHDRAPV1)
        Me.gb_ApprovalType.Controls.Add(Me.rbHDRCLOS)
        Me.gb_ApprovalType.Controls.Add(Me.rbHDRAPV2)
        Me.gb_ApprovalType.Location = New System.Drawing.Point(333, 280)
        Me.gb_ApprovalType.Name = "gb_ApprovalType"
        Me.gb_ApprovalType.Size = New System.Drawing.Size(307, 119)
        Me.gb_ApprovalType.TabIndex = 55
        Me.gb_ApprovalType.TabStop = False
        Me.gb_ApprovalType.Text = "Approval Type"
        '
        'rbHDROPEN
        '
        Me.rbHDROPEN.Enabled = False
        Me.rbHDROPEN.Location = New System.Drawing.Point(16, 66)
        Me.rbHDROPEN.Name = "rbHDROPEN"
        Me.rbHDROPEN.Size = New System.Drawing.Size(104, 24)
        Me.rbHDROPEN.TabIndex = 5
        Me.rbHDROPEN.Text = "OPEN - Open"
        '
        'cmdHDRSelectAll
        '
        Me.cmdHDRSelectAll.Location = New System.Drawing.Point(236, 19)
        Me.cmdHDRSelectAll.Name = "cmdHDRSelectAll"
        Me.cmdHDRSelectAll.Size = New System.Drawing.Size(65, 44)
        Me.cmdHDRSelectAll.TabIndex = 9
        Me.cmdHDRSelectAll.Text = "Select All"
        '
        'rbHDRCANL
        '
        Me.rbHDRCANL.Enabled = False
        Me.rbHDRCANL.Location = New System.Drawing.Point(16, 90)
        Me.rbHDRCANL.Name = "rbHDRCANL"
        Me.rbHDRCANL.Size = New System.Drawing.Size(104, 24)
        Me.rbHDRCANL.TabIndex = 7
        Me.rbHDRCANL.Text = "CANL - Cancel"
        '
        'cmdHDRApply
        '
        Me.cmdHDRApply.Enabled = False
        Me.cmdHDRApply.Location = New System.Drawing.Point(236, 69)
        Me.cmdHDRApply.Name = "cmdHDRApply"
        Me.cmdHDRApply.Size = New System.Drawing.Size(65, 44)
        Me.cmdHDRApply.TabIndex = 10
        Me.cmdHDRApply.Text = "Apply"
        '
        'rbHDRNoUpd
        '
        Me.rbHDRNoUpd.Enabled = False
        Me.rbHDRNoUpd.Location = New System.Drawing.Point(126, 90)
        Me.rbHDRNoUpd.Name = "rbHDRNoUpd"
        Me.rbHDRNoUpd.Size = New System.Drawing.Size(104, 24)
        Me.rbHDRNoUpd.TabIndex = 8
        Me.rbHDRNoUpd.Text = "N - No Update"
        '
        'rbHDRAPV1
        '
        Me.rbHDRAPV1.Checked = True
        Me.rbHDRAPV1.Enabled = False
        Me.rbHDRAPV1.Location = New System.Drawing.Point(16, 18)
        Me.rbHDRAPV1.Name = "rbHDRAPV1"
        Me.rbHDRAPV1.Size = New System.Drawing.Size(179, 24)
        Me.rbHDRAPV1.TabIndex = 3
        Me.rbHDRAPV1.TabStop = True
        Me.rbHDRAPV1.Text = "APV1 - Claim to UCPPC Amt"
        '
        'rbHDRCLOS
        '
        Me.rbHDRCLOS.Enabled = False
        Me.rbHDRCLOS.Location = New System.Drawing.Point(126, 66)
        Me.rbHDRCLOS.Name = "rbHDRCLOS"
        Me.rbHDRCLOS.Size = New System.Drawing.Size(104, 24)
        Me.rbHDRCLOS.TabIndex = 6
        Me.rbHDRCLOS.Text = "CLOS - Close"
        '
        'rbHDRAPV2
        '
        Me.rbHDRAPV2.Enabled = False
        Me.rbHDRAPV2.Location = New System.Drawing.Point(16, 42)
        Me.rbHDRAPV2.Name = "rbHDRAPV2"
        Me.rbHDRAPV2.Size = New System.Drawing.Size(179, 24)
        Me.rbHDRAPV2.TabIndex = 4
        Me.rbHDRAPV2.Text = "APV2 - Claim to Vendor Amt"
        '
        'tcPOM00010_1
        '
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_CaCreDateTo)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_CaCreDateFm)
        Me.tcPOM00010_1.Controls.Add(Me.lblCaCreDateFm)
        Me.tcPOM00010_1.Controls.Add(Me.lblCaCreDateTo)
        Me.tcPOM00010_1.Controls.Add(Me.lblCaCreDateToLbl)
        Me.tcPOM00010_1.Controls.Add(Me.lblCaCreDateFmLbl)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_CustStyleNo)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_CustItmNo)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_CaSts)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_CaOrdNo)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_InvNo)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_JobNo)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_PV)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_ItmNo)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_SCNo)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_PONo)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_CustPONo)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_SecCust)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_PriCust)
        Me.tcPOM00010_1.Controls.Add(Me.txt_S_CoCde)
        Me.tcPOM00010_1.Controls.Add(Me.lblCustStyleNo)
        Me.tcPOM00010_1.Controls.Add(Me.cmd_S_CustStyleNo)
        Me.tcPOM00010_1.Controls.Add(Me.lblCustItmNo)
        Me.tcPOM00010_1.Controls.Add(Me.cmd_S_CustItmNo)
        Me.tcPOM00010_1.Controls.Add(Me.cmd_S_CaSts)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_CaSts)
        Me.tcPOM00010_1.Controls.Add(Me.cmd_S_CaOrdNo)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_CaOrdNo)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_InvNo)
        Me.tcPOM00010_1.Controls.Add(Me.cmd_S_InvNo)
        Me.tcPOM00010_1.Controls.Add(Me.cmd_S_JobNo)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_JobNo)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_CaCreDate)
        Me.tcPOM00010_1.Controls.Add(Me.cmd_S_PV)
        Me.tcPOM00010_1.Controls.Add(Me.lbl_S_PV)
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
        'txt_S_CaCreDateTo
        '
        Me.txt_S_CaCreDateTo.Location = New System.Drawing.Point(478, 375)
        Me.txt_S_CaCreDateTo.Mask = "00/00/0000"
        Me.txt_S_CaCreDateTo.Name = "txt_S_CaCreDateTo"
        Me.txt_S_CaCreDateTo.Size = New System.Drawing.Size(88, 21)
        Me.txt_S_CaCreDateTo.TabIndex = 213
        '
        'txt_S_CaCreDateFm
        '
        Me.txt_S_CaCreDateFm.Location = New System.Drawing.Point(193, 375)
        Me.txt_S_CaCreDateFm.Mask = "00/00/0000"
        Me.txt_S_CaCreDateFm.Name = "txt_S_CaCreDateFm"
        Me.txt_S_CaCreDateFm.Size = New System.Drawing.Size(88, 21)
        Me.txt_S_CaCreDateFm.TabIndex = 212
        '
        'lblCaCreDateFm
        '
        Me.lblCaCreDateFm.AutoSize = True
        Me.lblCaCreDateFm.Location = New System.Drawing.Point(154, 375)
        Me.lblCaCreDateFm.Name = "lblCaCreDateFm"
        Me.lblCaCreDateFm.Size = New System.Drawing.Size(33, 15)
        Me.lblCaCreDateFm.TabIndex = 217
        Me.lblCaCreDateFm.Text = "From"
        '
        'lblCaCreDateTo
        '
        Me.lblCaCreDateTo.AutoSize = True
        Me.lblCaCreDateTo.Location = New System.Drawing.Point(451, 375)
        Me.lblCaCreDateTo.Name = "lblCaCreDateTo"
        Me.lblCaCreDateTo.Size = New System.Drawing.Size(21, 15)
        Me.lblCaCreDateTo.TabIndex = 216
        Me.lblCaCreDateTo.Text = "To"
        '
        'lblCaCreDateToLbl
        '
        Me.lblCaCreDateToLbl.Location = New System.Drawing.Point(572, 378)
        Me.lblCaCreDateToLbl.Name = "lblCaCreDateToLbl"
        Me.lblCaCreDateToLbl.Size = New System.Drawing.Size(100, 16)
        Me.lblCaCreDateToLbl.TabIndex = 215
        Me.lblCaCreDateToLbl.Text = "(MM/DD/YYYY)"
        '
        'lblCaCreDateFmLbl
        '
        Me.lblCaCreDateFmLbl.Location = New System.Drawing.Point(287, 378)
        Me.lblCaCreDateFmLbl.Name = "lblCaCreDateFmLbl"
        Me.lblCaCreDateFmLbl.Size = New System.Drawing.Size(100, 16)
        Me.lblCaCreDateFmLbl.TabIndex = 214
        Me.lblCaCreDateFmLbl.Text = "(MM/DD/YYYY)"
        '
        'txt_S_CustStyleNo
        '
        Me.txt_S_CustStyleNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_CustStyleNo.Location = New System.Drawing.Point(193, 297)
        Me.txt_S_CustStyleNo.MaxLength = 5000
        Me.txt_S_CustStyleNo.Name = "txt_S_CustStyleNo"
        Me.txt_S_CustStyleNo.Size = New System.Drawing.Size(541, 21)
        Me.txt_S_CustStyleNo.TabIndex = 24
        '
        'txt_S_CustItmNo
        '
        Me.txt_S_CustItmNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_CustItmNo.Location = New System.Drawing.Point(193, 271)
        Me.txt_S_CustItmNo.MaxLength = 5000
        Me.txt_S_CustItmNo.Name = "txt_S_CustItmNo"
        Me.txt_S_CustItmNo.Size = New System.Drawing.Size(541, 21)
        Me.txt_S_CustItmNo.TabIndex = 22
        '
        'txt_S_CaSts
        '
        Me.txt_S_CaSts.Location = New System.Drawing.Point(193, 349)
        Me.txt_S_CaSts.MaxLength = 5000
        Me.txt_S_CaSts.Name = "txt_S_CaSts"
        Me.txt_S_CaSts.Size = New System.Drawing.Size(541, 21)
        Me.txt_S_CaSts.TabIndex = 28
        Me.txt_S_CaSts.UseWaitCursor = True
        '
        'txt_S_CaOrdNo
        '
        Me.txt_S_CaOrdNo.Location = New System.Drawing.Point(193, 323)
        Me.txt_S_CaOrdNo.MaxLength = 5000
        Me.txt_S_CaOrdNo.Name = "txt_S_CaOrdNo"
        Me.txt_S_CaOrdNo.Size = New System.Drawing.Size(541, 21)
        Me.txt_S_CaOrdNo.TabIndex = 26
        '
        'txt_S_InvNo
        '
        Me.txt_S_InvNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_InvNo.Location = New System.Drawing.Point(193, 219)
        Me.txt_S_InvNo.MaxLength = 5000
        Me.txt_S_InvNo.Name = "txt_S_InvNo"
        Me.txt_S_InvNo.Size = New System.Drawing.Size(541, 21)
        Me.txt_S_InvNo.TabIndex = 18
        '
        'txt_S_JobNo
        '
        Me.txt_S_JobNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_JobNo.Location = New System.Drawing.Point(193, 193)
        Me.txt_S_JobNo.MaxLength = 5000
        Me.txt_S_JobNo.Name = "txt_S_JobNo"
        Me.txt_S_JobNo.Size = New System.Drawing.Size(541, 21)
        Me.txt_S_JobNo.TabIndex = 16
        '
        'txt_S_PV
        '
        Me.txt_S_PV.Location = New System.Drawing.Point(193, 89)
        Me.txt_S_PV.MaxLength = 5000
        Me.txt_S_PV.Name = "txt_S_PV"
        Me.txt_S_PV.Size = New System.Drawing.Size(541, 21)
        Me.txt_S_PV.TabIndex = 8
        '
        'txt_S_ItmNo
        '
        Me.txt_S_ItmNo.Location = New System.Drawing.Point(193, 115)
        Me.txt_S_ItmNo.MaxLength = 5000
        Me.txt_S_ItmNo.Name = "txt_S_ItmNo"
        Me.txt_S_ItmNo.Size = New System.Drawing.Size(541, 21)
        Me.txt_S_ItmNo.TabIndex = 10
        '
        'txt_S_SCNo
        '
        Me.txt_S_SCNo.Location = New System.Drawing.Point(193, 141)
        Me.txt_S_SCNo.MaxLength = 5000
        Me.txt_S_SCNo.Name = "txt_S_SCNo"
        Me.txt_S_SCNo.Size = New System.Drawing.Size(541, 21)
        Me.txt_S_SCNo.TabIndex = 12
        '
        'txt_S_PONo
        '
        Me.txt_S_PONo.Location = New System.Drawing.Point(193, 167)
        Me.txt_S_PONo.MaxLength = 5000
        Me.txt_S_PONo.Name = "txt_S_PONo"
        Me.txt_S_PONo.Size = New System.Drawing.Size(541, 21)
        Me.txt_S_PONo.TabIndex = 14
        '
        'txt_S_CustPONo
        '
        Me.txt_S_CustPONo.Location = New System.Drawing.Point(193, 245)
        Me.txt_S_CustPONo.MaxLength = 5000
        Me.txt_S_CustPONo.Name = "txt_S_CustPONo"
        Me.txt_S_CustPONo.Size = New System.Drawing.Size(541, 21)
        Me.txt_S_CustPONo.TabIndex = 20
        '
        'txt_S_SecCust
        '
        Me.txt_S_SecCust.Location = New System.Drawing.Point(193, 63)
        Me.txt_S_SecCust.MaxLength = 5000
        Me.txt_S_SecCust.Name = "txt_S_SecCust"
        Me.txt_S_SecCust.Size = New System.Drawing.Size(541, 21)
        Me.txt_S_SecCust.TabIndex = 6
        '
        'txt_S_PriCust
        '
        Me.txt_S_PriCust.Location = New System.Drawing.Point(193, 37)
        Me.txt_S_PriCust.MaxLength = 5000
        Me.txt_S_PriCust.Name = "txt_S_PriCust"
        Me.txt_S_PriCust.Size = New System.Drawing.Size(541, 21)
        Me.txt_S_PriCust.TabIndex = 4
        '
        'txt_S_CoCde
        '
        Me.txt_S_CoCde.Location = New System.Drawing.Point(193, 11)
        Me.txt_S_CoCde.MaxLength = 5000
        Me.txt_S_CoCde.Name = "txt_S_CoCde"
        Me.txt_S_CoCde.Size = New System.Drawing.Size(541, 21)
        Me.txt_S_CoCde.TabIndex = 2
        '
        'lblCustStyleNo
        '
        Me.lblCustStyleNo.AutoSize = True
        Me.lblCustStyleNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustStyleNo.Location = New System.Drawing.Point(6, 300)
        Me.lblCustStyleNo.Name = "lblCustStyleNo"
        Me.lblCustStyleNo.Size = New System.Drawing.Size(76, 15)
        Me.lblCustStyleNo.TabIndex = 211
        Me.lblCustStyleNo.Text = "Cust Style No"
        '
        'cmd_S_CustStyleNo
        '
        Me.cmd_S_CustStyleNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_S_CustStyleNo.Location = New System.Drawing.Point(123, 295)
        Me.cmd_S_CustStyleNo.Name = "cmd_S_CustStyleNo"
        Me.cmd_S_CustStyleNo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_CustStyleNo.TabIndex = 23
        Me.cmd_S_CustStyleNo.Text = "「「"
        '
        'lblCustItmNo
        '
        Me.lblCustItmNo.AutoSize = True
        Me.lblCustItmNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustItmNo.Location = New System.Drawing.Point(6, 274)
        Me.lblCustItmNo.Name = "lblCustItmNo"
        Me.lblCustItmNo.Size = New System.Drawing.Size(73, 15)
        Me.lblCustItmNo.TabIndex = 210
        Me.lblCustItmNo.Text = "Cust Item No"
        '
        'cmd_S_CustItmNo
        '
        Me.cmd_S_CustItmNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_S_CustItmNo.Location = New System.Drawing.Point(123, 269)
        Me.cmd_S_CustItmNo.Name = "cmd_S_CustItmNo"
        Me.cmd_S_CustItmNo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_CustItmNo.TabIndex = 21
        Me.cmd_S_CustItmNo.Text = "「「"
        '
        'cmd_S_CaSts
        '
        Me.cmd_S_CaSts.Location = New System.Drawing.Point(123, 347)
        Me.cmd_S_CaSts.Name = "cmd_S_CaSts"
        Me.cmd_S_CaSts.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_CaSts.TabIndex = 27
        Me.cmd_S_CaSts.Text = "「「"
        '
        'lbl_S_CaSts
        '
        Me.lbl_S_CaSts.AutoSize = True
        Me.lbl_S_CaSts.Location = New System.Drawing.Point(6, 352)
        Me.lbl_S_CaSts.Name = "lbl_S_CaSts"
        Me.lbl_S_CaSts.Size = New System.Drawing.Size(87, 15)
        Me.lbl_S_CaSts.TabIndex = 205
        Me.lbl_S_CaSts.Text = "Approval Status"
        '
        'cmd_S_CaOrdNo
        '
        Me.cmd_S_CaOrdNo.Location = New System.Drawing.Point(123, 321)
        Me.cmd_S_CaOrdNo.Name = "cmd_S_CaOrdNo"
        Me.cmd_S_CaOrdNo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_CaOrdNo.TabIndex = 25
        Me.cmd_S_CaOrdNo.Text = "「「"
        '
        'lbl_S_CaOrdNo
        '
        Me.lbl_S_CaOrdNo.AutoSize = True
        Me.lbl_S_CaOrdNo.Location = New System.Drawing.Point(6, 326)
        Me.lbl_S_CaOrdNo.Name = "lbl_S_CaOrdNo"
        Me.lbl_S_CaOrdNo.Size = New System.Drawing.Size(53, 15)
        Me.lbl_S_CaOrdNo.TabIndex = 202
        Me.lbl_S_CaOrdNo.Text = "Claim No"
        '
        'lbl_S_InvNo
        '
        Me.lbl_S_InvNo.AutoSize = True
        Me.lbl_S_InvNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_S_InvNo.Location = New System.Drawing.Point(6, 222)
        Me.lbl_S_InvNo.Name = "lbl_S_InvNo"
        Me.lbl_S_InvNo.Size = New System.Drawing.Size(60, 15)
        Me.lbl_S_InvNo.TabIndex = 201
        Me.lbl_S_InvNo.Text = "Invoice No"
        '
        'cmd_S_InvNo
        '
        Me.cmd_S_InvNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_S_InvNo.Location = New System.Drawing.Point(123, 217)
        Me.cmd_S_InvNo.Name = "cmd_S_InvNo"
        Me.cmd_S_InvNo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_InvNo.TabIndex = 17
        Me.cmd_S_InvNo.Text = "「「"
        '
        'cmd_S_JobNo
        '
        Me.cmd_S_JobNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_S_JobNo.Location = New System.Drawing.Point(123, 191)
        Me.cmd_S_JobNo.Name = "cmd_S_JobNo"
        Me.cmd_S_JobNo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_JobNo.TabIndex = 15
        Me.cmd_S_JobNo.Text = "「「"
        '
        'lbl_S_JobNo
        '
        Me.lbl_S_JobNo.AutoSize = True
        Me.lbl_S_JobNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_S_JobNo.Location = New System.Drawing.Point(6, 196)
        Me.lbl_S_JobNo.Name = "lbl_S_JobNo"
        Me.lbl_S_JobNo.Size = New System.Drawing.Size(42, 15)
        Me.lbl_S_JobNo.TabIndex = 196
        Me.lbl_S_JobNo.Text = "Job No"
        '
        'lbl_S_CaCreDate
        '
        Me.lbl_S_CaCreDate.Location = New System.Drawing.Point(6, 378)
        Me.lbl_S_CaCreDate.Name = "lbl_S_CaCreDate"
        Me.lbl_S_CaCreDate.Size = New System.Drawing.Size(100, 23)
        Me.lbl_S_CaCreDate.TabIndex = 81
        Me.lbl_S_CaCreDate.Text = "Claim Create Date"
        '
        'cmd_S_PV
        '
        Me.cmd_S_PV.Location = New System.Drawing.Point(123, 87)
        Me.cmd_S_PV.Name = "cmd_S_PV"
        Me.cmd_S_PV.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_PV.TabIndex = 7
        Me.cmd_S_PV.Text = "「「"
        '
        'lbl_S_PV
        '
        Me.lbl_S_PV.AutoSize = True
        Me.lbl_S_PV.Location = New System.Drawing.Point(6, 92)
        Me.lbl_S_PV.Name = "lbl_S_PV"
        Me.lbl_S_PV.Size = New System.Drawing.Size(98, 15)
        Me.lbl_S_PV.TabIndex = 71
        Me.lbl_S_PV.Text = "Production Vendor"
        '
        'cmd_S_ItmNo
        '
        Me.cmd_S_ItmNo.Location = New System.Drawing.Point(123, 113)
        Me.cmd_S_ItmNo.Name = "cmd_S_ItmNo"
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_ItmNo.TabIndex = 9
        Me.cmd_S_ItmNo.Text = "「「"
        '
        'cmd_S_SCNo
        '
        Me.cmd_S_SCNo.Location = New System.Drawing.Point(123, 139)
        Me.cmd_S_SCNo.Name = "cmd_S_SCNo"
        Me.cmd_S_SCNo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_SCNo.TabIndex = 11
        Me.cmd_S_SCNo.Text = "「「"
        '
        'cmd_S_PONo
        '
        Me.cmd_S_PONo.Location = New System.Drawing.Point(123, 165)
        Me.cmd_S_PONo.Name = "cmd_S_PONo"
        Me.cmd_S_PONo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_PONo.TabIndex = 13
        Me.cmd_S_PONo.Text = "「「"
        '
        'cmd_S_CustPONo
        '
        Me.cmd_S_CustPONo.Location = New System.Drawing.Point(123, 243)
        Me.cmd_S_CustPONo.Name = "cmd_S_CustPONo"
        Me.cmd_S_CustPONo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_CustPONo.TabIndex = 19
        Me.cmd_S_CustPONo.Text = "「「"
        '
        'cmd_S_SecCust
        '
        Me.cmd_S_SecCust.Location = New System.Drawing.Point(123, 61)
        Me.cmd_S_SecCust.Name = "cmd_S_SecCust"
        Me.cmd_S_SecCust.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_SecCust.TabIndex = 5
        Me.cmd_S_SecCust.Text = "「「"
        '
        'cmd_S_PriCust
        '
        Me.cmd_S_PriCust.Location = New System.Drawing.Point(123, 35)
        Me.cmd_S_PriCust.Name = "cmd_S_PriCust"
        Me.cmd_S_PriCust.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_PriCust.TabIndex = 3
        Me.cmd_S_PriCust.Text = "「「"
        '
        'cmd_S_CoCde
        '
        Me.cmd_S_CoCde.Location = New System.Drawing.Point(123, 9)
        Me.cmd_S_CoCde.Name = "cmd_S_CoCde"
        Me.cmd_S_CoCde.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_CoCde.TabIndex = 1
        Me.cmd_S_CoCde.Text = "「「"
        '
        'lbl_S_ItmNo
        '
        Me.lbl_S_ItmNo.AutoSize = True
        Me.lbl_S_ItmNo.Location = New System.Drawing.Point(6, 118)
        Me.lbl_S_ItmNo.Name = "lbl_S_ItmNo"
        Me.lbl_S_ItmNo.Size = New System.Drawing.Size(47, 15)
        Me.lbl_S_ItmNo.TabIndex = 59
        Me.lbl_S_ItmNo.Text = "Item No"
        '
        'lbl_S_SCNo
        '
        Me.lbl_S_SCNo.AutoSize = True
        Me.lbl_S_SCNo.Location = New System.Drawing.Point(6, 144)
        Me.lbl_S_SCNo.Name = "lbl_S_SCNo"
        Me.lbl_S_SCNo.Size = New System.Drawing.Size(39, 15)
        Me.lbl_S_SCNo.TabIndex = 58
        Me.lbl_S_SCNo.Text = "SC No"
        '
        'lbl_S_PONo
        '
        Me.lbl_S_PONo.AutoSize = True
        Me.lbl_S_PONo.Location = New System.Drawing.Point(6, 170)
        Me.lbl_S_PONo.Name = "lbl_S_PONo"
        Me.lbl_S_PONo.Size = New System.Drawing.Size(41, 15)
        Me.lbl_S_PONo.TabIndex = 57
        Me.lbl_S_PONo.Text = "PO No"
        '
        'lbl_S_CustPO
        '
        Me.lbl_S_CustPO.AutoSize = True
        Me.lbl_S_CustPO.Location = New System.Drawing.Point(6, 248)
        Me.lbl_S_CustPO.Name = "lbl_S_CustPO"
        Me.lbl_S_CustPO.Size = New System.Drawing.Size(67, 15)
        Me.lbl_S_CustPO.TabIndex = 56
        Me.lbl_S_CustPO.Text = "Cust PO No"
        '
        'lbl_S_SecCust
        '
        Me.lbl_S_SecCust.AutoSize = True
        Me.lbl_S_SecCust.Location = New System.Drawing.Point(6, 66)
        Me.lbl_S_SecCust.Name = "lbl_S_SecCust"
        Me.lbl_S_SecCust.Size = New System.Drawing.Size(73, 15)
        Me.lbl_S_SecCust.TabIndex = 55
        Me.lbl_S_SecCust.Text = "Sec Customer"
        '
        'lbl_S_PriCust
        '
        Me.lbl_S_PriCust.AutoSize = True
        Me.lbl_S_PriCust.Location = New System.Drawing.Point(6, 40)
        Me.lbl_S_PriCust.Name = "lbl_S_PriCust"
        Me.lbl_S_PriCust.Size = New System.Drawing.Size(71, 15)
        Me.lbl_S_PriCust.TabIndex = 54
        Me.lbl_S_PriCust.Text = "Pri Customer"
        '
        'lbl_S_CoCde
        '
        Me.lbl_S_CoCde.AutoSize = True
        Me.lbl_S_CoCde.Location = New System.Drawing.Point(6, 14)
        Me.lbl_S_CoCde.Name = "lbl_S_CoCde"
        Me.lbl_S_CoCde.Size = New System.Drawing.Size(83, 15)
        Me.lbl_S_CoCde.TabIndex = 53
        Me.lbl_S_CoCde.Text = "Company Code"
        '
        'tcPOM00010
        '
        Me.tcPOM00010.Controls.Add(Me.tcPOM00010_1)
        Me.tcPOM00010.Controls.Add(Me.tcPOM00010_2)
        Me.tcPOM00010.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tcPOM00010.Location = New System.Drawing.Point(0, 41)
        Me.tcPOM00010.Name = "tcPOM00010"
        Me.tcPOM00010.SelectedIndex = 0
        Me.tcPOM00010.Size = New System.Drawing.Size(752, 433)
        Me.tcPOM00010.TabIndex = 0
        '
        'rbDTLAPV2
        '
        Me.rbDTLAPV2.Enabled = False
        Me.rbDTLAPV2.Location = New System.Drawing.Point(16, 42)
        Me.rbDTLAPV2.Name = "rbDTLAPV2"
        Me.rbDTLAPV2.Size = New System.Drawing.Size(175, 24)
        Me.rbDTLAPV2.TabIndex = 4
        Me.rbDTLAPV2.Text = "APV2 - Claim to Vendor Amt"
        '
        'rbDTLAPV1
        '
        Me.rbDTLAPV1.Checked = True
        Me.rbDTLAPV1.Enabled = False
        Me.rbDTLAPV1.Location = New System.Drawing.Point(16, 18)
        Me.rbDTLAPV1.Name = "rbDTLAPV1"
        Me.rbDTLAPV1.Size = New System.Drawing.Size(180, 24)
        Me.rbDTLAPV1.TabIndex = 3
        Me.rbDTLAPV1.TabStop = True
        Me.rbDTLAPV1.Text = "APV1 - Claim to UCPPC Amt"
        '
        'cmdDTLApply
        '
        Me.cmdDTLApply.Enabled = False
        Me.cmdDTLApply.Location = New System.Drawing.Point(236, 69)
        Me.cmdDTLApply.Name = "cmdDTLApply"
        Me.cmdDTLApply.Size = New System.Drawing.Size(65, 44)
        Me.cmdDTLApply.TabIndex = 7
        Me.cmdDTLApply.Text = "Apply"
        '
        'cmdDTLSelectAll
        '
        Me.cmdDTLSelectAll.Location = New System.Drawing.Point(236, 19)
        Me.cmdDTLSelectAll.Name = "cmdDTLSelectAll"
        Me.cmdDTLSelectAll.Size = New System.Drawing.Size(65, 44)
        Me.cmdDTLSelectAll.TabIndex = 6
        Me.cmdDTLSelectAll.Text = "Select All"
        '
        'rbDTLNoUpd
        '
        Me.rbDTLNoUpd.Enabled = False
        Me.rbDTLNoUpd.Location = New System.Drawing.Point(16, 66)
        Me.rbDTLNoUpd.Name = "rbDTLNoUpd"
        Me.rbDTLNoUpd.Size = New System.Drawing.Size(104, 24)
        Me.rbDTLNoUpd.TabIndex = 5
        Me.rbDTLNoUpd.Text = "N - No Update"
        '
        'CLM00002
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "CLM00002"
        Me.Text = "CLM00002 - Claims Approval Maintenance"
        Me.tcPOM00010_2.ResumeLayout(False)
        CType(Me.dgHDRApproved, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_ApprovalType.ResumeLayout(False)
        Me.tcPOM00010_1.ResumeLayout(False)
        Me.tcPOM00010_1.PerformLayout()
        Me.tcPOM00010.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public rs_SYMUSRCO As New DataSet
    'Public rs_SYUSRRIGHT As New DataSet
    Public rs_CLM00002_HDR As New DataSet
    Public rs_CLM00002_ITM As New DataSet
    Public rs_CLM00002_HDR_AppList As New DataSet
    Public rs_CLM00002_ITM_AppList As New DataSet

    'Dim sUsrGrp As String = "UCG"
    'Dim sDocTyp As String = "CA"
    'Dim isSuperUsr As Boolean = False
    Dim dsNewRow As DataRow
    Dim mode As String
    Dim bInDTL As Boolean = False

    Private Sub CLM00002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            gspStr = "sp_select_SYMUSRCO '','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYMUSRCO, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading CLM00002 #001 sp_select_SYMUSRCO : " & rtnStr)
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

            txt_S_CaCreDateFm.Text = Today.AddMonths(-1)
            txt_S_CaCreDateTo.Text = Today


            mode = "INIT"
            formInit(mode)

            'tcPOM00010.TabPages(2).Visible = False

            Formstartup(Me.Name)


        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub cmd_S_CoCde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CoCde.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CoCde.Name
        frmComSearch.callFmString = txt_S_CoCde.Text

        frmComSearch.show_frmS(Me.cmd_S_CoCde)
    End Sub

    Private Sub cmd_S_PriCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PriCust.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PriCust.Name
        frmComSearch.callFmString = txt_S_PriCust.Text

        frmComSearch.show_frmS(Me.cmd_S_PriCust)
    End Sub

    Private Sub cmd_S_SecCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SecCust.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SecCust.Name
        frmComSearch.callFmString = txt_S_SecCust.Text

        frmComSearch.show_frmS(Me.cmd_S_SecCust)
    End Sub

    'Private Sub cmd_S_PV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PV.Click
    '    Dim frmComSearch As New frmComSearch

    '    frmComSearch.callFmForm = Me.Name
    '    frmComSearch.callFmCriteria = txt_S_PV.Name
    '    frmComSearch.callFmString = txt_S_PV.Text

    '    frmComSearch.show_frmS(Me.cmd_S_PV)
    'End Sub

    Private Sub cmd_S_ItmNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_ItmNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_ItmNo.Name
        frmComSearch.callFmString = txt_S_ItmNo.Text

        frmComSearch.show_frmS(Me.cmd_S_ItmNo)
    End Sub

    'Private Sub cmd_S_SCNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SCNo.Click
    '    Dim frmComSearch As New frmComSearch

    '    frmComSearch.callFmForm = Me.Name
    '    frmComSearch.callFmCriteria = txt_S_SCNo.Name
    '    frmComSearch.callFmString = txt_S_SCNo.Text

    '    frmComSearch.show_frmS(Me.cmd_S_SCNo)
    'End Sub

    'Private Sub cmd_S_PONo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PONo.Click
    '    Dim frmComSearch As New frmComSearch

    '    frmComSearch.callFmForm = Me.Name
    '    frmComSearch.callFmCriteria = txt_S_PONo.Name
    '    frmComSearch.callFmString = txt_S_PONo.Text

    '    frmComSearch.show_frmS(Me.cmd_S_PONo)
    'End Sub

    'Private Sub cmd_S_JobNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_JobNo.Click
    '    Dim frmComSearch As New frmComSearch

    '    frmComSearch.callFmForm = Me.Name
    '    frmComSearch.callFmCriteria = txt_S_JobNo.Name
    '    frmComSearch.callFmString = txt_S_JobNo.Text

    '    frmComSearch.show_frmS(Me.cmd_S_JobNo)
    'End Sub

    'Private Sub cmd_S_InvNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_InvNo.Click
    '    Dim frmComSearch As New frmComSearch

    '    frmComSearch.callFmForm = Me.Name
    '    frmComSearch.callFmCriteria = txt_S_InvNo.Name
    '    frmComSearch.callFmString = txt_S_InvNo.Text

    '    frmComSearch.show_frmS(Me.cmd_S_InvNo)
    'End Sub

    'Private Sub cmd_S_CustPONo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CustPONo.Click
    '    Dim frmComSearch As New frmComSearch

    '    frmComSearch.callFmForm = Me.Name
    '    frmComSearch.callFmCriteria = txt_S_CustPONo.Name
    '    frmComSearch.callFmString = txt_S_CustPONo.Text

    '    frmComSearch.show_frmS(Me.cmd_S_CustPONo)
    'End Sub

    'Private Sub cmd_S_CustItmNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CustItmNo.Click
    '    Dim frmComSearch As New frmComSearch

    '    frmComSearch.callFmForm = Me.Name
    '    frmComSearch.callFmCriteria = txt_S_CustItmNo.Name
    '    frmComSearch.callFmString = txt_S_CustItmNo.Text

    '    frmComSearch.show_frmS(Me.cmd_S_CustItmNo)
    'End Sub

    'Private Sub cmd_S_CustStyleNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CustStyleNo.Click
    '    Dim frmComSearch As New frmComSearch

    '    frmComSearch.callFmForm = Me.Name
    '    frmComSearch.callFmCriteria = txt_S_CustStyleNo.Name
    '    frmComSearch.callFmString = txt_S_CustStyleNo.Text

    '    frmComSearch.show_frmS(Me.cmd_S_CustStyleNo)
    'End Sub

    Private Sub cmd_S_CaOrdNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CaOrdNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CaOrdNo.Name
        frmComSearch.callFmString = txt_S_CaOrdNo.Text

        frmComSearch.show_frmS(Me.cmd_S_CaOrdNo)
    End Sub

    Private Sub cmd_S_CaSts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CaSts.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CaSts.Name
        frmComSearch.callFmString = txt_S_CaSts.Text

        frmComSearch.show_frmS(Me.cmd_S_CaSts)
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
            Me.tcPOM00010.TabPages(1).Enabled = True
            Me.tcPOM00010.TabPages(1).Enabled = False
            '''Me.tcPOM00010.TabPages(2).Enabled = True
            'Me.tcPOM00010.TabPages(2).Enabled = False
            'Me.tcPOM00010.TabPages(2).Visible = False

            Me.tcPOM00010.SelectedIndex = 0

            Me.rs_CLM00002_HDR.Clear()
            Me.rs_CLM00002_ITM.Clear()
            Me.dgHeader.ClearSelection()

            Me.rs_CLM00002_HDR_AppList.Clear()
            Me.rs_CLM00002_ITM_AppList.Clear()
            Me.dgHDRApproved.ClearSelection()

            Me.txtHDRResult.Items.Clear()

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
            Me.tcPOM00010.TabPages(1).Enabled = False
            Me.tcPOM00010.TabPages(1).Enabled = True
            'Me.tcPOM00010.TabPages(2).Enabled = False
            'Me.tcPOM00010.TabPages(2).Visible = False


            '''Me.tcPOM00010.TabPages(2).Enabled = True

            Me.tcPOM00010.SelectedIndex = 1

            'Me.dgHeader.ClearSelection()
            'Me.dgDetail.ClearSelection()
        End If
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click

        Dim COCDELIST As String
        Dim CUS1NOLIST As String
        Dim CUS2NOLIST As String
        'Dim PVLIST As String
        Dim ITMNOLIST As String
        'Dim SCNOLIST As String
        'Dim PONOLIST As String
        'Dim JOBNOLIST As String
        'Dim INVNOLIST As String
        'Dim CUSPONOLIST As String
        'Dim CUSITMNOLIST As String
        'Dim CUSSTYLENOLIST As String
        Dim CLAIMNOLIST As String
        Dim CASTSLIST As String
        Dim CLAIMCREDATFM As String
        Dim CLAIMCREDATTO As String
        Dim PVLIST As String

        Dim SCNOLIST As String
        Dim PONOLIST As String
        Dim JOBNOLIST As String
        Dim INVNOLIST As String
        Dim CUSPONOLIST As String
        Dim CUSITMNOLIST As String
        Dim CUSSTYLENOLIST As String

        If Trim(Me.txt_S_CoCde.Text) = "" Then
            MsgBox("The Company Code List is empty!")
            Exit Sub
        Else
            If Len(Me.txt_S_CoCde.Text) > 1000 Then
                MsgBox("The Company Code List is too long (1000 char)")
                Exit Sub
            End If
            COCDELIST = Trim(Me.txt_S_CoCde.Text)
            COCDELIST = Replace(COCDELIST, "'", "''")
        End If

        If Trim(Me.txt_S_PriCust.Text) = "" Then
            CUS1NOLIST = ""
        Else
            If Len(Me.txt_S_PriCust.Text) > 1000 Then
                MsgBox("The Primary Customer List is too long (1000 char)")
                Exit Sub
            End If
            CUS1NOLIST = Trim(Me.txt_S_PriCust.Text)
            CUS1NOLIST = Replace(CUS1NOLIST, "'", "''")
        End If

        If Trim(Me.txt_S_SecCust.Text) = "" Then
            CUS2NOLIST = ""
        Else
            If Len(Me.txt_S_SecCust.Text) > 1000 Then
                MsgBox("The Secondary Customer List is too long (1000 char)")
                Exit Sub
            End If
            CUS2NOLIST = Trim(Me.txt_S_SecCust.Text)
            CUS2NOLIST = Replace(CUS2NOLIST, "'", "''")
        End If

        'If Trim(Me.txt_S_PV.Text) = "" Then
        '    PVLIST = ""
        'Else
        '    If Len(Me.txt_S_PV.Text) > 1000 Then
        '        MsgBox("The Production Vendor List is too long (1000 char)")
        '        Exit Sub
        '    End If
        '    PVLIST = Trim(Me.txt_S_PV.Text)
        '    PVLIST = Replace(PVLIST, "'", "''")
        'End If

        If Trim(Me.txt_S_ItmNo.Text) = "" Then
            ITMNOLIST = ""
        Else
            If Len(Me.txt_S_ItmNo.Text) > 1000 Then
                MsgBox("The Item No List is too long (1000 char)")
                Exit Sub
            End If
            ITMNOLIST = Trim(Me.txt_S_ItmNo.Text)
            ITMNOLIST = Replace(ITMNOLIST, "'", "''")
        End If

        'If Trim(Me.txt_S_SCNo.Text) = "" Then
        '    SCNOLIST = ""
        'Else
        '    If Len(Me.txt_S_SCNo.Text) > 1000 Then
        '        MsgBox("The SC No List is too long (1000 char)")
        '        Exit Sub
        '    End If
        '    SCNOLIST = Trim(Me.txt_S_SCNo.Text)
        '    SCNOLIST = Replace(SCNOLIST, "'", "''")
        'End If

        'If Trim(Me.txt_S_PONo.Text) = "" Then
        '    PONOLIST = ""
        'Else
        '    If Len(Me.txt_S_PONo.Text) > 1000 Then
        '        MsgBox("The PO No List is too long (1000 char)")
        '        Exit Sub
        '    End If
        '    PONOLIST = Trim(Me.txt_S_PONo.Text)
        '    PONOLIST = Replace(PONOLIST, "'", "''")
        'End If

        'If Trim(Me.txt_S_JobNo.Text) = "" Then
        '    JOBNOLIST = ""
        'Else
        '    If Len(Me.txt_S_JobNo.Text) > 1000 Then
        '        MsgBox("The Job No List is too long (1000 char)")
        '        Exit Sub
        '    End If
        '    JOBNOLIST = Trim(Me.txt_S_JobNo.Text)
        '    JOBNOLIST = Replace(JOBNOLIST, "'", "''")
        'End If

        'If Trim(Me.txt_S_InvNo.Text) = "" Then
        '    INVNOLIST = ""
        'Else
        '    If Len(Me.txt_S_InvNo.Text) > 1000 Then
        '        MsgBox("The Invoice No List is too long (1000 char)")
        '        Exit Sub
        '    End If
        '    INVNOLIST = Trim(Me.txt_S_InvNo.Text)
        '    INVNOLIST = Replace(INVNOLIST, "'", "''")
        'End If

        'If Trim(Me.txt_S_CustPONo.Text) = "" Then
        '    CUSPONOLIST = ""
        'Else
        '    If Len(Me.txt_S_CustPONo.Text) > 1000 Then
        '        MsgBox("The Customer PO No List is too long (1000 char)")
        '        Exit Sub
        '    End If
        '    CUSPONOLIST = Trim(Me.txt_S_CustPONo.Text)
        '    CUSPONOLIST = Replace(CUSPONOLIST, "'", "''")
        'End If

        'If Trim(Me.txt_S_CustItmNo.Text) = "" Then
        '    CUSITMNOLIST = ""
        'Else
        '    If Len(Me.txt_S_CustItmNo.Text) > 1000 Then
        '        MsgBox("The Custom Item No List is too long (1000 char)")
        '        Exit Sub
        '    End If
        '    CUSITMNOLIST = Trim(Me.txt_S_CustItmNo.Text)
        '    CUSITMNOLIST = Replace(CUSITMNOLIST, "'", "''")
        'End If

        'If Trim(Me.txt_S_CustStyleNo.Text) = "" Then
        '    CUSSTYLENOLIST = ""
        'Else
        '    If Len(Me.txt_S_CustStyleNo.Text) > 1000 Then
        '        MsgBox("Then Custom Style No List is too long (1000 char)")
        '        Exit Sub
        '    End If
        '    CUSSTYLENOLIST = Trim(Me.txt_S_CustStyleNo.Text)
        '    CUSSTYLENOLIST = Replace(CUSSTYLENOLIST, "'", "''")
        'End If

        If Trim(Me.txt_S_CaOrdNo.Text) = "" Then
            CLAIMNOLIST = ""
        Else
            If Len(Me.txt_S_CaOrdNo.Text) > 1000 Then
                MsgBox("Then Claim No List is too long (1000 char)")
                Exit Sub
            End If
            CLAIMNOLIST = Trim(Me.txt_S_CaOrdNo.Text)
            CLAIMNOLIST = Replace(CLAIMNOLIST, "'", "''")
        End If

        If Trim(Me.txt_S_CaSts.Text) = "" Then
            CASTSLIST = ""
        Else
            If Len(Me.txt_S_CaSts.Text) > 1000 Then
                MsgBox("Then Approval Status List is too long (1000 char)")
                Exit Sub
            End If
            CASTSLIST = Trim(Me.txt_S_CaSts.Text)
            CASTSLIST = Replace(CASTSLIST, "'", "''")
        End If

        If Me.txt_S_CaCreDateFm.Text <> "__/__/____" Then
            If Not IsDate(Me.txt_S_CaCreDateFm.Text) Then
                MsgBox("Invalid Date Format: Issue Date From")
                Me.txt_S_CaCreDateFm.Focus()
                Exit Sub
            End If
        End If

        If Me.txt_S_CaCreDateTo.Text <> "__/__/____" Then
            If Not IsDate(Me.txt_S_CaCreDateTo.Text) Then
                MsgBox("Invalid Date Format: Issue Date To")
                Me.txt_S_CaCreDateTo.Focus()
                Exit Sub
            End If
        End If

        If Mid(Me.txt_S_CaCreDateFm.Text, 7) > Mid(Me.txt_S_CaCreDateTo.Text, 7) Then
            MsgBox("Claim Create Date: End Date < Start Date (YY)")
            Me.txt_S_CaCreDateFm.Focus()
            Exit Sub
        ElseIf Mid(Me.txt_S_CaCreDateFm.Text, 7) = Mid(Me.txt_S_CaCreDateTo.Text, 7) Then
            If Me.txt_S_CaCreDateFm.Text.Substring(0, 2) > Me.txt_S_CaCreDateTo.Text.Substring(0, 2) Then
                MsgBox("Claim Create Date: End Date < Start Date (MM)")
                Me.txt_S_CaCreDateFm.Focus()
                Exit Sub
            ElseIf Me.txt_S_CaCreDateFm.Text.Substring(0, 2) = Me.txt_S_CaCreDateTo.Text.Substring(0, 2) Then
                If Me.txt_S_CaCreDateFm.Text.Substring(4, 2) > Me.txt_S_CaCreDateTo.Text.Substring(4, 2) Then
                    MsgBox("Claim Create Date: End Date < Start Date (DD)")
                    Me.txt_S_CaCreDateFm.Focus()
                    Exit Sub
                End If
            End If
        End If

        If Me.txt_S_CaCreDateFm.Text = "__/__/____" Then
            CLAIMCREDATFM = "01/01/1900"
        Else
            CLAIMCREDATFM = Me.txt_S_CaCreDateFm.Text
        End If

        If Me.txt_S_CaCreDateTo.Text = "__/__/____" Then
            CLAIMCREDATTO = "01/01/1900"
        Else
            CLAIMCREDATTO = Me.txt_S_CaCreDateTo.Text
        End If

        Try
            'For Claim Header Tab
            gspStr = "sp_list_CLM00002_HDR '" & _
                        COCDELIST & "','" & _
                        CUS1NOLIST & "','" & _
                        CUS2NOLIST & "','" & _
                    PVLIST & "','" & _
                        ITMNOLIST & "','" & _
                    SCNOLIST & "','" & _
                    PONOLIST & "','" & _
                    JOBNOLIST & "','" & _
                    INVNOLIST & "','" & _
                    CUSPONOLIST & "','" & _
                    CUSITMNOLIST & "','" & _
                    CUSSTYLENOLIST & "','" & _
                        CLAIMNOLIST & "','" & _
                        CASTSLIST & "','" & _
                        CLAIMCREDATFM & "','" & _
                        CLAIMCREDATTO & "','" & _
                        gsUsrID & "'"

            ''gspStr = "sp_list_CLM00002_HDR '" & _
            ''            COCDELIST & "','" & _
            ''            CUS1NOLIST & "','" & _
            ''            CUS2NOLIST & "','" & _
            ''            ITMNOLIST & "','" & _
            ''            CLAIMNOLIST & "','" & _
            ''            CASTSLIST & "','" & _
            ''            CLAIMCREDATFM & "','" & _
            ''            CLAIMCREDATTO & "','" & _
            ''            gsUsrID & "'"
            ' ''PVLIST & "','" & _
            ' ''SCNOLIST & "','" & _
            ' ''PONOLIST & "','" & _
            ' ''JOBNOLIST & "','" & _
            ' ''INVNOLIST & "','" & _
            ' ''CUSPONOLIST & "','" & _
            ' ''CUSITMNOLIST & "','" & _
            ' ''CUSSTYLENOLIST & "','" & _

            Me.Cursor = Cursors.WaitCursor

            rtnLong = execute_SQLStatement(gspStr, rs_CLM00002_HDR, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading CLM00002 #003 sp_list_CLM00002_HDR : " & rtnStr)
            Else
                If rs_CLM00002_HDR.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("No Record found!")

                    Me.Cursor = Cursors.Default
                Else
                    dgHeader.DataSource = rs_CLM00002_HDR.Tables("RESULT").DefaultView
                    dgHeader.Columns("Act").SortMode = DataGridViewColumnSortMode.NotSortable
                    format_dgHeader()


          


                    '''tmp 20131127
                    Me.Cursor = Cursors.Default
                    mode = "MODIFY"
                    formInit(mode)
                    '''20140219
                    rs_CLM00002_HDR.Tables("RESULT").DefaultView.RowFilter = ""
                    rs_CLM00002_HDR.Tables("RESULT").AcceptChanges()
                    dgHeader.DataSource = rs_CLM00002_HDR.Tables("RESULT").DefaultView
                    rs_CLM00002_HDR.Tables("RESULT").AcceptChanges()

                    Exit Sub



                    'For Claim Detail Tab

                    'change to ITM aprv

                    gspStr = "sp_list_CLM00002_ITM '" & _
                                COCDELIST & "','" & _
                                CUS1NOLIST & "','" & _
                                CUS2NOLIST & "','" & _
                                ITMNOLIST & "','" & _
                                CLAIMNOLIST & "','" & _
                                CASTSLIST & "','" & _
                                CLAIMCREDATFM & "','" & _
                                CLAIMCREDATTO & "','" & _
                                gsUsrID & "'"
                    'COCDELIST & "','" & _
                    'CUS1NOLIST & "','" & _
                    'CUS2NOLIST & "','" & _
                    'PVLIST & "','" & _
                    'ITMNOLIST & "','" & _
                    'SCNOLIST & "','" & _
                    'PONOLIST & "','" & _
                    'JOBNOLIST & "','" & _
                    'INVNOLIST & "','" & _
                    'CUSPONOLIST & "','" & _
                    'CUSITMNOLIST & "','" & _
                    'CUSSTYLENOLIST & "','" & _
                    'CLAIMNOLIST & "','" & _
                    'CASTSLIST & "','" & _
                    'CLAIMCREDATFM & "','" & _
                    'CLAIMCREDATTO & "','" & _
                    'gsUsrID & "'"

                    rtnLong = execute_SQLStatement(gspStr, rs_CLM00002_ITM, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading CLM00002 #004 sp_list_CLM00002_DTL : " & rtnStr)
                    Else
                        If rs_CLM00002_ITM.Tables("RESULT").Rows.Count > 0 Then
                            'dgDetail.DataSource = rs_CLM00002_ITM.Tables("RESULT").DefaultView
                            'dgDetail.Columns("Act").SortMode = DataGridViewColumnSortMode.NotSortable

                            format_dgDetail()
                        End If
                    End If

                    Me.Cursor = Cursors.Default

                    mode = "MODIFY"
                    formInit(mode)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub format_dgHeader()

        'For index As Integer = 0 To dgHeader.ColumnCount - 1
        '    dgHeader.Columns("Act").ReadOnly = False
        'Next

        Dim i As Integer
        With dgHeader
            i = 0
            .Columns(i).Width = 50
            i = i + 1
            .Columns(i).Width = 60
            i = i + 1
            .Columns(i).Width = 80
            i = i + 1
            .Columns(i).Width = 40
            i = i + 1
            .Columns(i).Width = 40
            i = i + 1
            .Columns(i).Width = 40
            i = i + 1
            .Columns(i).Width = 40
            i = i + 1
            .Columns(i).Width = 90
            i = i + 1
            .Columns(i).Width = 60
            i = i + 1
            .Columns(i).Width = 90
            i = i + 1
            .Columns(i).Width = 80
            i = i + 1
            .Columns(i).Width = 47

            i = i + 1
            .Columns(i).Width = 54
            i = i + 1
            .Columns(i).Width = 80
            i = i + 1
            .Columns(i).Width = 80
            i = i + 1
            .Columns(i).Width = 54
            i = i + 1
            .Columns(i).Width = 80
            i = i + 1
            .Columns(i).Width = 54
            i = i + 1
            .Columns(i).Width = 80

        End With


        'With dgHeader
        '    .Columns(i).Width = 30
        '    .Columns(i).HeaderText = "Act"
        '    i = i + 1
        '    .Columns(i).Width = 32
        '    .Columns(i).HeaderText = "App Sts"
        '    i = i + 1
        '    .Columns(i).Width = 32
        '    .Columns(i).HeaderText = "App Cnt"
        '    i = i + 1
        '    .Columns(i).Visible = False
        '    i = i + 1
        '    .Columns(i).Width = 42
        '    .Columns(i).HeaderText = "Comp"
        '    i = i + 1
        '    .Columns(i).Width = 68
        '    .Columns(i).HeaderText = "PO No"
        '    i = i + 1
        '    .Columns(i).Width = 35
        '    .Columns(i).HeaderText = "PO Sts"
        '    i = i + 1
        '    .Columns(i).Width = 42
        '    .Columns(i).HeaderText = "Pri Cust"
        '    i = i + 1
        '    .Columns(i).Width = 90
        '    .Columns(i).HeaderText = "Pri Cust Name"
        '    i = i + 1
        '    .Columns(i).Width = 42
        '    .Columns(i).HeaderText = "Sec Cust"
        '    i = i + 1
        '    .Columns(i).Width = 55
        '    .Columns(i).HeaderText = "Sec Cust Name"
        '    i = i + 1
        '    .Columns(i).Width = 80
        '    .Columns(i).HeaderText = "Cust PO No"
        '    i = i + 1
        '    .Columns(i).Width = 68
        '    .Columns(i).HeaderText = "SC No"
        '    i = i + 1
        '    .Columns(i).Width = 36
        '    .Columns(i).HeaderText = "CV"
        '    i = i + 1
        '    .Columns(i).Width = 65
        '    .Columns(i).HeaderText = "CV Name"

        'End With

        'For index As Integer = 0 To dgHeader.ColumnCount - 1
        '    dgHeader.Columns(index).Width = 80
        'Next
    End Sub

    Private Sub format_dgDetail()
        'Dim i As Integer
        'i = 0
        'With dgDetail
        '    '0
        '    .Columns(i).Width = 30
        '    .Columns(i).HeaderText = "Seq"
        '    i = i + 1
        '    '1
        '    .Columns(i).Width = 100
        '    .Columns(i).HeaderText = "Item"
        '    i = i + 1
        '    '2
        '    .Columns(i).Width = 100
        '    .Columns(i).HeaderText = "Job No"
        '    i = i + 1
        '    '3
        '    .Columns(i).Visible = False
        '    i = i + 1
        '    '4
        '    .Columns(i).Width = 100
        '    .Columns(i).HeaderText = "Ven Item No"
        '    i = i + 1
        '    '5
        '    .Columns(i).Width = 100
        '    .Columns(i).HeaderText = "Cust Item No"
        '    i = i + 1
        '    '6
        '    .Columns(i).Visible = False
        '    i = i + 1
        '    '7
        '    .Columns(i).Width = 100
        '    .Columns(i).HeaderText = "Vdr Color"
        '    i = i + 1
        '    '8
        '    .Columns(i).Width = 80
        '    .Columns(i).HeaderText = "Cust Color"
        '    i = i + 1
        '    '9
        '    .Columns(i).Visible = False
        '    i = i + 1
        '    '10
        '    .Columns(i).Width = 120
        '    .Columns(i).HeaderText = "Packing"
        '    i = i + 1
        '    '11
        '    .Columns(i).Visible = False
        '    i = i + 1
        '    '12
        '    .Columns(i).Width = 50
        '    .Columns(i).HeaderText = "Order Qty"
        '    i = i + 1
        '    '13
        '    .Columns(i).Visible = False
        '    i = i + 1
        '    '14
        '    .Columns(i).Width = 50
        '    .Columns(i).HeaderText = "Curr"
        '    i = i + 1
        '    '15
        '    .Columns(i).Width = 60
        '    .Columns(i).HeaderText = "FtyPrc"
        '    i = i + 1

        '    Dim j As Integer
        '    For j = i To dgDetail.Columns.Count - 1
        '        .Columns(j).Visible = False
        '    Next j
        'End With
 
    End Sub

    Private Sub cmdHDRSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHDRSelectAll.Click
        dgHeader.SelectAll()
    End Sub

    Private Sub cmdDTLSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDTLSelectAll.Click
        ''dgDetail.SelectAll()
    End Sub

    Private Sub cmdHDRShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHDRShowAll.Click

        rs_CLM00002_HDR.Tables("RESULT").DefaultView.RowFilter = ""
        rs_CLM00002_HDR.Tables("RESULT").AcceptChanges()

        dgHeader.DataSource = rs_CLM00002_HDR.Tables("RESULT").DefaultView
        rs_CLM00002_HDR.Tables("RESULT").AcceptChanges()

    End Sub

    Private Sub cmdDTLShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dgHeader.ClearSelection()
        rs_CLM00002_ITM.Tables("RESULT").DefaultView.RowFilter = ""
        ''dgDetail.DataSource = rs_CLM00002_ITM.Tables("RESULT").DefaultView
    End Sub

    Private Sub tcPOM00010_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcPOM00010.SelectedIndexChanged
        Dim sCaCocde As String = ""
        Dim sCaOrdNo As String = ""
        Dim sFilter As String = ""

        If Me.tcPOM00010.SelectedIndex = 0 Then
            formInit("INIT")
        ElseIf Me.tcPOM00010.SelectedIndex = 1 Then
            If mode = "MODIFY" Then
                '    If dgDetail.RowCount > 0 Then
                '        If dgDetail.SelectedRows.Count <> 1 Then
                '            sCaCocde = "''"
                '            sCaOrdNo = "''"
                '        Else
                '            sCaCocde = "'" + Trim(dgDetail.SelectedRows(0).Cells("Claim Comp").Value.ToString) + "'"
                '            sCaOrdNo = "'" + Trim(dgDetail.SelectedRows(0).Cells("Claim No").Value.ToString) + "'"
                '        End If

                '        sFilter = "[Claim Comp] = " + sCaCocde + " and [Claim No] = " + sCaOrdNo
                '        rs_CLM00002_HDR.Tables("RESULT").DefaultView.RowFilter = sFilter
                '        dgHeader.DataSource = rs_CLM00002_HDR.Tables("RESULT").DefaultView

                '        If dgHeader.SelectedRows.Count <> 1 Then
                '            Me.rbHDRAPV1.Enabled = False
                '            Me.rbHDRAPV2.Enabled = False
                '            Me.rbHDRCANL.Enabled = False
                '            Me.rbHDRCLOS.Enabled = False
                '            Me.rbHDRNoUpd.Enabled = False
                '            Me.rbHDROPEN.Enabled = False
                '        End If
                '    End If
                '    If dgDetail.SelectedRows.Count <> 1 Then
                '        cmdHDRShowAll_Click(sender, e)
                '    End If
            End If
        Else
            If mode = "MODIFY" Then
                If dgHeader.RowCount > 0 Then
                    If dgHeader.SelectedRows.Count <> 1 Then
                        sCaCocde = "''"
                        sCaOrdNo = "''"
                        'txt_D_CaOrdNo.Text = ""
                        'txt_D_CaSts.Text = ""
                        'txt_D_CoCde.Text = ""
                        'txt_D_CaPeriod.Text = ""
                        Me.rbDTLAPV1.Enabled = False
                        Me.rbDTLAPV2.Enabled = False
                        Me.rbDTLNoUpd.Enabled = False
                    Else
                        sCaCocde = "'" + Trim(dgHeader.SelectedRows(0).Cells("Claim Comp").Value.ToString) + "'"
                        sCaOrdNo = "'" + Trim(dgHeader.SelectedRows(0).Cells("Claim No").Value.ToString) + "'"
                        'txt_D_CaOrdNo.Text = Trim(dgHeader.SelectedRows(0).Cells("Claim No").Value.ToString)
                        'txt_D_CaSts.Text = Trim(dgHeader.SelectedRows(0).Cells("Approval Status").Value.ToString)
                        'txt_D_CoCde.Text = Trim(dgHeader.SelectedRows(0).Cells("Claim Comp").Value.ToString)
                        'txt_D_CaPeriod.Text = Trim(dgHeader.SelectedRows(0).Cells("Claim Period").Value.ToString)
                    End If
                    sFilter = "[Claim Comp] = " + sCaCocde + " and [Claim No] = " + sCaOrdNo
                    rs_CLM00002_ITM.Tables("RESULT").DefaultView.RowFilter = sFilter
                    'dgDetail.DataSource = rs_CLM00002_ITM.Tables("RESULT").DefaultView

                    If bInDTL Then
                        cmdDTLShowAll_Click(sender, e)
                    End If
                    bInDTL = False
                End If
            End If
        End If
    End Sub

    Private Sub dgHeader_CellClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgHeader.CellClick

        'dgHeader.Columns("Act").ReadOnly = False

        'If e.RowIndex >= 0 And e.ColumnIndex = 0 Then
        '    If dgHeader.Columns(e.ColumnIndex).ReadOnly = False Then
        '        If rs_CLM00002_HDR.Tables("RESULT").DefaultView(e.RowIndex)("Act").ToString = "Y" Then
        '            rs_CLM00002_HDR.Tables("RESULT").DefaultView(e.RowIndex)("Act") = "N"
        '            'chkDelete.Checked = False
        '        Else
        '            rs_CLM00002_HDR.Tables("RESULT").DefaultView(e.RowIndex)("Act") = "Y"
        '            'chkDelete.Checked = True
        '        End If
        '        rs_CLM00002_HDR.Tables("RESULT").AcceptChanges()
        '    End If

        '    'If rs_CLM00002_HDR.Tables("RESULT").Rows(e.RowIndex).Item("cah_creusr") <> "~*ADD*~" And rs_CLM00002_HDR.Tables("RESULT").Rows(e.RowIndex).Item("cah_creusr") <> "~*NEW*~" Then
        '    '    rs_CLM00002_HDR.Tables("RESULT").Rows(e.RowIndex).Item("cah_creusr") = "~*UPD*~"
        '    'End If
        'End If

    End Sub

    Private Sub dgHeader_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgHeader.CellMouseUp

        'rs_CLM00002_HDR.Tables("RESULT").Columns("Act").ReadOnly = False
        'dgHeader.Columns("Act").ReadOnly = False

        'If e.RowIndex >= 0 And e.ColumnIndex = 0 Then
        '    'dgHeader.Columns(e.ColumnIndex).ReadOnly = False
        '    'If dgHeader.Columns(e.ColumnIndex).ReadOnly = False Then
        '    If rs_CLM00002_HDR.Tables("RESULT").DefaultView(e.RowIndex)("Act").ToString = "Y" Then
        '        rs_CLM00002_HDR.Tables("RESULT").DefaultView(e.RowIndex)("Act") = "N"
        '        'chkDelete.Checked = False
        '    Else
        '        rs_CLM00002_HDR.Tables("RESULT").DefaultView(e.RowIndex)("Act") = "Y"
        '        'chkDelete.Checked = True
        '    End If
        '    rs_CLM00002_HDR.Tables("RESULT").AcceptChanges()
        '    'End If

        '    'If rs_CLM00002_HDR.Tables("RESULT").Rows(e.RowIndex).Item("cah_creusr") <> "~*ADD*~" And rs_CLM00002_HDR.Tables("RESULT").Rows(e.RowIndex).Item("cah_creusr") <> "~*NEW*~" Then
        '    '    rs_CLM00002_HDR.Tables("RESULT").Rows(e.RowIndex).Item("cah_creusr") = "~*UPD*~"
        '    'End If
        'End If


        rbHDRAPV1.Enabled = False
        rbHDRAPV2.Enabled = False
        rbHDROPEN.Enabled = False
        rbHDRCLOS.Enabled = False
        rbHDRCANL.Enabled = False
        rbHDRNoUpd.Enabled = False
        cmdHDRApply.Enabled = False
        cmdHDRApprove.Enabled = False

        rbHDRAPV1.Checked = True
        rbHDRAPV2.Checked = False
        rbHDRCANL.Checked = False
        rbHDRCLOS.Checked = False
        rbHDRNoUpd.Checked = False

        If dgHeader.SelectedRows.Count > 0 Then
            If dgHeader.SelectedRows.Count > 1 Then
                For i As Integer = 1 To dgHeader.SelectedRows.Count - 1
                    If dgHeader.SelectedRows(0).Cells("Approval Status").Value <> dgHeader.SelectedRows(i).Cells("Approval Status").Value Then
                        rbHDRAPV1.Enabled = False
                        rbHDRAPV2.Enabled = False
                        rbHDROPEN.Enabled = False
                        rbHDRCLOS.Enabled = False
                        rbHDRCANL.Enabled = True
                        rbHDRNoUpd.Enabled = True
                        cmdHDRApply.Enabled = True
                        rbHDRAPV1.Checked = False
                        rbHDRAPV2.Checked = False
                        rbHDRCLOS.Checked = False
                        rbHDRCANL.Checked = False
                        rbHDRNoUpd.Checked = True
                        Exit For
                    End If
                Next i
            End If

            If dgHeader.SelectedRows(0).Cells("Approval Status").Value = "OPEN" Then
                rbHDRAPV1.Enabled = True
                rbHDRAPV2.Enabled = False
                rbHDROPEN.Enabled = False
                rbHDRCLOS.Enabled = False
                rbHDRCANL.Enabled = True
                rbHDRNoUpd.Enabled = True
                cmdHDRApply.Enabled = True
                rbHDRAPV1.Checked = True
                rbHDRAPV2.Checked = False
                rbHDRCLOS.Checked = False
                rbHDRCANL.Checked = False
                rbHDRNoUpd.Checked = False
            ElseIf dgHeader.SelectedRows(0).Cells("Approval Status").Value = "APV1" Then
                rbHDRAPV1.Enabled = False
                rbHDRAPV2.Enabled = True
                rbHDROPEN.Enabled = True
                rbHDRCLOS.Enabled = False
                rbHDRCANL.Enabled = True
                rbHDRNoUpd.Enabled = True
                cmdHDRApply.Enabled = True
                rbHDRAPV1.Checked = False
                rbHDRAPV2.Checked = True
                rbHDRCLOS.Checked = False
                rbHDRCANL.Checked = False
                rbHDRNoUpd.Checked = False
            ElseIf dgHeader.SelectedRows(0).Cells("Approval Status").Value = "APV2" Then
                rbHDRAPV1.Enabled = False
                rbHDRAPV2.Enabled = False
                rbHDROPEN.Enabled = True
                rbHDRCLOS.Enabled = True
                rbHDRCANL.Enabled = True
                rbHDRNoUpd.Enabled = True
                cmdHDRApply.Enabled = True
                rbHDRAPV1.Checked = False
                rbHDRAPV2.Checked = False
                rbHDRCLOS.Checked = True
                rbHDRCANL.Checked = False
                rbHDRNoUpd.Checked = False
            ElseIf dgHeader.SelectedRows(0).Cells("Approval Status").Value = "CANL" Then
                rbHDRAPV1.Enabled = False
                rbHDRAPV2.Enabled = False
                rbHDROPEN.Enabled = False
                rbHDRCLOS.Enabled = False
                rbHDRCANL.Enabled = False
                rbHDRNoUpd.Enabled = True
                cmdHDRApply.Enabled = True
                rbHDRAPV1.Checked = False
                rbHDRAPV2.Checked = False
                rbHDRCLOS.Checked = False
                rbHDRCANL.Checked = False
                rbHDRNoUpd.Checked = True
            Else
                rbHDRAPV1.Enabled = False
                rbHDRAPV2.Enabled = False
                rbHDROPEN.Enabled = False
                rbHDRCANL.Enabled = False
                rbHDRCLOS.Enabled = False
                rbHDRNoUpd.Enabled = True
                cmdHDRApply.Enabled = False
                rbHDRAPV1.Checked = False
                rbHDRAPV2.Checked = False
                rbHDRCANL.Checked = False
                rbHDRCLOS.Checked = False
                rbHDRNoUpd.Checked = True
            End If


            '''20131213
            ''' for some case , now allow zero amount
            'For i As Integer = 0 To dgHeader.SelectedRows.Count - 1
            '    If dgHeader.SelectedRows(i).Cells("Claim Amount Finalized").Value = 0 Then
            '        rbHDRAPV1.Enabled = False
            '        rbHDRAPV2.Enabled = False
            '        rbHDROPEN.Enabled = False
            '        rbHDRCLOS.Enabled = False
            '        rbHDRCANL.Enabled = False
            '        rbHDRNoUpd.Enabled = True
            '        cmdHDRApply.Enabled = False
            '        rbHDRAPV1.Checked = False
            '        rbHDRAPV2.Checked = False
            '        rbHDRCLOS.Checked = False
            '        rbHDRCANL.Checked = False
            '        rbHDRNoUpd.Checked = True
            '        Exit For
            '    End If
            'Next i

            For j As Integer = 0 To dgHeader.SelectedRows.Count - 1
                If dgHeader.SelectedRows(j).Cells("Act").Value <> "N" Then
                    cmdHDRApprove.Enabled = True
                    Exit For
                End If
            Next j

        End If
    End Sub

    Private Sub dgDetail_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        ''rbDTLAPV1.Enabled = False
        ''rbDTLAPV2.Enabled = False
        ''rbDTLNoUpd.Enabled = False
        ''cmdDTLApply.Enabled = False
        '' ''cmdDTLApprove.Enabled = False
        ''rbDTLAPV1.Checked = True
        ''rbDTLAPV2.Checked = False
        ''rbDTLNoUpd.Checked = False

        ' ''If dgDetail.SelectedRows.Count > 0 Then
        ' ''    If dgDetail.SelectedRows.Count > 1 Then
        ' ''        For i As Integer = 1 To dgDetail.SelectedRows.Count - 1
        ' ''            If dgDetail.SelectedRows(0).Cells("Approval Status").Value <> dgDetail.SelectedRows(i).Cells("Approval Status").Value Then
        ' ''                rbDTLAPV1.Enabled = False
        ' ''                rbDTLAPV2.Enabled = False
        ' ''                rbDTLNoUpd.Enabled = True
        ' ''                cmdDTLApply.Enabled = True
        ' ''                rbDTLAPV1.Checked = False
        ' ''                rbDTLAPV2.Checked = False
        ' ''                rbDTLNoUpd.Checked = True
        ' ''                Exit For
        ' ''            End If
        ' ''        Next i
        ' ''    End If

        ''If dgDetail.SelectedRows(0).Cells("Approval Status").Value = "" Then
        ''    rbDTLAPV1.Enabled = True
        ''    rbDTLAPV2.Enabled = False
        ''    rbDTLNoUpd.Enabled = True
        ''    cmdDTLApply.Enabled = True
        ''    rbDTLAPV1.Checked = True
        ''    rbDTLAPV2.Checked = False
        ''    rbDTLNoUpd.Checked = False
        ''ElseIf dgDetail.SelectedRows(0).Cells("Approval Status").Value = "APV1" Then
        ''    rbDTLAPV1.Enabled = False
        ''    rbDTLAPV2.Enabled = True
        ''    rbDTLNoUpd.Enabled = True
        ''    cmdDTLApply.Enabled = True
        ''    rbDTLAPV1.Checked = False
        ''    rbDTLAPV2.Checked = True
        ''    rbDTLNoUpd.Checked = False
        ''Else
        ''    rbDTLAPV1.Enabled = False
        ''    rbDTLAPV2.Enabled = False
        ''    rbDTLNoUpd.Enabled = True
        ''    cmdDTLApply.Enabled = False
        ''    rbDTLAPV1.Checked = False
        ''    rbDTLAPV2.Checked = False
        ''    rbDTLNoUpd.Checked = True
        ''End If

        ' ''For j As Integer = 0 To dgDetail.SelectedRows.Count - 1
        ' ''    If dgDetail.SelectedRows(j).Cells("Act").Value <> "N" Then
        ' ''        cmdDTLApprove.Enabled = True
        ' ''        Exit For
        ' ''    End If
        ' ''Next j

        ' ''For i As Integer = 0 To dgDetail.SelectedRows.Count - 1
        ' ''    If dgDetail.SelectedRows(i).Cells("Claim Amount Finalized").Value = 0 Then
        ' ''        rbDTLAPV1.Enabled = False
        ' ''        rbDTLAPV2.Enabled = False
        ' ''        rbDTLNoUpd.Enabled = True
        ' ''        cmdDTLApply.Enabled = False
        ' ''        rbDTLAPV1.Checked = False
        ' ''        rbDTLAPV2.Checked = False
        ' ''        rbDTLNoUpd.Checked = True
        ' ''        Exit For
        ' ''    End If
        ' ''Next i

        ' ''If txt_D_CaSts.Text = "CANL" Or txt_D_CaSts.Text = "CLOS" Then
        ' ''    rbDTLAPV1.Enabled = False
        ' ''    rbDTLAPV2.Enabled = False
        ' ''    rbDTLNoUpd.Enabled = False
        ' ''    cmdDTLApply.Enabled = False
        ' ''    cmdDTLApprove.Enabled = False
        ' ''    rbDTLAPV1.Checked = True
        ' ''    rbDTLAPV2.Checked = False
        ' ''    rbDTLNoUpd.Checked = False
        ' ''End If
        ''End If
    End Sub

    Private Sub cmdHDRApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHDRApply.Click
        Dim i As Integer
        Dim cont As Boolean = True
        Dim status As String = "N"
        Dim reason As String = ""

        If dgHeader.SelectedRows.Count > 0 Then
            If dgHeader.SelectedRows.Count > 1 Then
                If Not rbHDRCANL.Checked Then
                    For i = 1 To dgHeader.SelectedRows.Count - 1
                        If dgHeader.SelectedRows(0).Cells("Approval Status").Value <> dgHeader.SelectedRows(i).Cells("Approval Status").Value And Not rbHDRNoUpd.Checked Then
                            cont = False
                            MsgBox("Cannot update different type of Claim Status at the same time")
                            Exit For
                        End If
                    Next i
                End If
            End If

            If cont Then
                If rbHDROPEN.Checked Then
                    status = "OPEN"
                ElseIf rbHDRAPV1.Checked Then
                    status = "APV1"
                ElseIf rbHDRAPV2.Checked Then
                    status = "APV2"
                ElseIf rbHDRCLOS.Checked Then
                    status = "CLOS"
                ElseIf rbHDRCANL.Checked Then
                    status = "CANL"
                    reason = InputBox("Please enter a reason", "Reason Entry Form", "Enter your messge here", 200, 200)
                    reason = "Claim Canceled at " & DateTime.Today.Year & "-" & DateTime.Today.Month & "-" & DateTime.Today.Day _
                            & vbCrLf & "Reason: " & reason & vbCrLf & vbCrLf
                Else
                    status = "N"
                End If

                rs_CLM00002_HDR.Tables("RESULT").Columns("Act").ReadOnly = False
                rs_CLM00002_HDR.Tables("RESULT").Columns("Remark").ReadOnly = False
                dgHeader.Columns("Act").ReadOnly = False
                dgHeader.Columns("Remark").ReadOnly = False
                For i = 0 To dgHeader.SelectedRows.Count - 1
                    dgHeader.SelectedRows(i).Cells("Act").Value = status
                    dgHeader.SelectedRows(i).Cells("Remark").Value = reason & dgHeader.SelectedRows(i).Cells("Remark").Value
                Next i
                rs_CLM00002_HDR.Tables("RESULT").Columns("Act").ReadOnly = True
                rs_CLM00002_HDR.Tables("RESULT").Columns("Remark").ReadOnly = True
                dgHeader.Columns("Act").ReadOnly = True
                dgHeader.Columns("Remark").ReadOnly = True
                cmdHDRApprove.Enabled = True
            End If
        End If
    End Sub

    Private Sub cmdDTLApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDTLApply.Click
        Dim i As Integer
        Dim cont As Boolean = True
        Dim status As String = "N"

        'If dgDetail.SelectedRows.Count > 0 Then
        '    If txt_D_CaSts.Text = "CANL" Or txt_D_CaSts.Text = "CLOS" Then
        '        MsgBox("The Claim Header is " & If(txt_D_CaSts.Text = "CANL", "canceled", "closed"))
        '    Else
        '        If dgDetail.SelectedRows.Count > 1 Then
        '            For i = 1 To dgDetail.SelectedRows.Count - 1
        '                If dgDetail.SelectedRows(0).Cells("Approval Status").Value <> dgDetail.SelectedRows(i).Cells("Approval Status").Value Then
        '                    cont = False
        '                    MsgBox("Cannot update different type of Claim Status at the same time")
        '                    Exit For
        '                End If
        '            Next i
        '        End If

        '        If cont Then
        '            If rbDTLAPV1.Checked Then
        '                status = "APV1"
        '            ElseIf rbDTLAPV2.Checked Then
        '                status = "APV2"
        '            End If

        '            rs_CLM00002_ITM.Tables("RESULT").Columns("Act").ReadOnly = False
        '            dgDetail.Columns("Act").ReadOnly = False
        '            For i = 0 To dgDetail.SelectedRows.Count - 1
        '                dgDetail.SelectedRows(i).Cells("Act").Value = status
        '            Next i
        '            rs_CLM00002_ITM.Tables("RESULT").Columns("Act").ReadOnly = False
        '            dgDetail.Columns("Act").ReadOnly = False
        '            cmdDTLApprove.Enabled = True
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub cmdHDRApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHDRApprove.Click
        Dim sCocde As String
        Dim sCaOrdNo As String
        Dim sCaOrdSeq As String = "0"
        Dim sAppFlg As String
        Dim sOriFlg As String
        Dim sRmk As String

        If dgHeader.SelectedRows.Count > 0 Then
            format_dgHDRApproved()
            format_dgDTLApproved()
            Me.txtHDRResult.Items.Clear()
            ''Me.txtDTLResult.Items.Clear()

            Try
                For indexA As Integer = 0 To dgHeader.SelectedRows.Count - 1
                    If dgHeader.SelectedRows(indexA).Cells("Act").Value <> "N" Then
                        sCocde = dgHeader.SelectedRows(indexA).Cells("Claim Comp").Value
                        sCaOrdNo = dgHeader.SelectedRows(indexA).Cells("Claim No").Value

                        sAppFlg = dgHeader.SelectedRows(indexA).Cells("Act").Value
                        sOriFlg = dgHeader.SelectedRows(indexA).Cells("Approval Status").Value
                        sRmk = dgHeader.SelectedRows(indexA).Cells("Remark").Value

                        gspStr = "sp_update_CLM00002_HDR '" & sCocde & "','" & sCaOrdNo & "','" & sAppFlg & "','" & sRmk & "','" & gsUsrID & "'"

                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            Me.txtHDRResult.Items.Add(sCaOrdNo & " : approval failure from " & sOriFlg & " to " & sAppFlg & " (" & rtnStr & ")")
                        Else
                            Me.txtHDRResult.Items.Add(sCaOrdNo & " : approval sucessful from " & sOriFlg & " to " & sAppFlg)
                            '                            Me.txtHDRResult.Items.Add(sCaOrdNo & " : approval sucessful from " & sOriFlg & " to " & sAppFlg & rtnStr)

                            dsNewRow = rs_CLM00002_HDR_AppList.Tables("RESULT").NewRow()

                            dsNewRow.Item("Act") = sAppFlg
                            dsNewRow.Item("Approval Status") = sOriFlg
                            dsNewRow.Item("Comp") = sCocde
                            dsNewRow.Item("Claim No") = sCaOrdNo

                            rs_CLM00002_HDR_AppList.Tables("RESULT").Rows.Add(dsNewRow)
                        End If

                        If dgHeader.SelectedRows(indexA).Cells("Act").Value = "CANL" Then
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
                            Dim CRH_CUREXRAT As String
                            Dim CRH_CUREXEFFDAT As String

                            CRH_COCDE = dgHeader.SelectedRows(indexA).Cells("Claim Comp").Value
                            CRH_CLAPERIOD = dgHeader.SelectedRows(indexA).Cells("Claim Period").Value
                            CRH_CUS1NO = dgHeader.SelectedRows(indexA).Cells("Pri Cust No").Value
                            CRH_CUS2NO = dgHeader.SelectedRows(indexA).Cells("Sec Cust No").Value
                            CRH_SALCUR = dgHeader.SelectedRows(indexA).Cells("Sales Currency").Value
                            CRH_SALTTLAMT = dgHeader.SelectedRows(indexA).Cells("Sales Amount").Value
                            CRH_GRSPFTAMT = "0"
                            CRH_CALMTAMT = dgHeader.SelectedRows(indexA).Cells("Claim Limit Amount").Value
                            CRH_CALMTPER = "1"
                            CRH_CAREMAMT = dgHeader.SelectedRows(indexA).Cells("Claim Remain Amount").Value
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
                                Exit Sub
                            End If
                        End If
                    End If
                Next

                Me.txtHDRResult.Sorted = True

                cmdFind_Click(sender, e) 'Refresh two datagridview (Header and Detail) for detail update

                Dim oldCocde As String = ""
                Dim oldCaordno As String = ""
                Dim newCocde As String = ""
                Dim newCaordno As String = ""
                Dim updAppFlg As String = ""
                Dim oriAppFlg As String = ""

                For indexB As Integer = 0 To rs_CLM00002_HDR_AppList.Tables("RESULT").Rows.Count - 1
                    newCocde = rs_CLM00002_HDR_AppList.Tables("RESULT").Rows(indexB).Item("Comp").ToString
                    newCaordno = rs_CLM00002_HDR_AppList.Tables("RESULT").Rows(indexB).Item("Claim No").ToString
                    updAppFlg = rs_CLM00002_HDR_AppList.Tables("RESULT").Rows(indexB).Item("Act").ToString
                    oriAppFlg = rs_CLM00002_HDR_AppList.Tables("RESULT").Rows(indexB).Item("Approval Status").ToString

                    If oldCocde <> newCocde Or oldCaordno <> newCaordno Then
                        If updAppFlg <> "N" And updAppFlg <> "CANL" And updAppFlg <> "CLOS" Then
                            gspStr = "sp_update_CLM00002_DTL '" & newCocde & "','" & newCaordno & "','" & sCaOrdSeq & "','" & updAppFlg & "','" & gsUsrID & "'"

                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            If rtnLong <> RC_SUCCESS Then
                                'Me.txtDTLResult.Items.Add(newCaordno & " : approval failure from " & oriAppFlg & " to " & updAppFlg & " (" & rtnStr & ")")
                            Else
                                'Me.txtDTLResult.Items.Add(newCaordno & " : approval sucessful from " & oriAppFlg & " to " & updAppFlg & rtnStr)

                                dsNewRow = rs_CLM00002_ITM_AppList.Tables("RESULT").NewRow()

                                dsNewRow.Item("Act") = updAppFlg
                                dsNewRow.Item("Approval Status") = oriAppFlg
                                dsNewRow.Item("Comp") = newCocde
                                dsNewRow.Item("Claim No") = newCaordno

                                rs_CLM00002_ITM_AppList.Tables("RESULT").Rows.Add(dsNewRow)
                            End If
                        End If
                        oldCocde = newCocde
                        oldCaordno = newCaordno
                        updAppFlg = ""
                    End If
                Next

                'Me.txtDTLResult.Sorted = True

                cmdFind_Click(sender, e)
                bInDTL = False
                tcPOM00010.SelectedIndex = 1
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub cmdDTLApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim sCocde As String
        'Dim sCaOrdNo As String
        'Dim sCaOrdSeq As String
        'Dim sAppFlg As String
        'Dim sOriFlg As String

        'If dgDetail.SelectedRows.Count > 0 Then
        '    format_dgHDRApproved()
        '    format_dgDTLApproved()
        '    Me.txtHDRResult.Items.Clear()
        '    Me.txtDTLResult.Items.Clear()

        '    Try
        '        For indexA As Integer = 0 To dgDetail.SelectedRows.Count - 1
        '            If dgDetail.SelectedRows(indexA).Cells("Act").Value <> "N" Then
        '                sCocde = dgDetail.SelectedRows(indexA).Cells("Claim Comp").Value
        '                sCaOrdNo = dgDetail.SelectedRows(indexA).Cells("Claim No").Value
        '                sCaOrdSeq = dgDetail.SelectedRows(indexA).Cells("Claim Seq").Value
        '                sAppFlg = dgDetail.SelectedRows(indexA).Cells("Act").Value
        '                sOriFlg = IIf(dgDetail.SelectedRows(indexA).Cells("Approval Status").Value = "", "OPEN", dgDetail.SelectedRows(indexA).Cells("Approval Status").Value)

        '                gspStr = "sp_update_CLM00002_DTL '" & sCocde & "','" & sCaOrdNo & "','" & sCaOrdSeq & "','" & sAppFlg & "','" & gsUsrID & "'"

        '                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        '                If rtnLong <> RC_SUCCESS Then
        '                    Me.txtDTLResult.Items.Add(sCaOrdNo & " - " & sCaOrdSeq.PadRight(2) & " : approval failure from " & sOriFlg & " to " & sAppFlg & " (" & rtnStr & ")")
        '                Else
        '                    Me.txtDTLResult.Items.Add(sCaOrdNo & " - " & sCaOrdSeq.PadRight(2) & " : approval sucessful from " & sOriFlg & " to " & sAppFlg & rtnStr)
        '                End If

        '                dsNewRow = rs_CLM00002_ITM_AppList.Tables("RESULT").NewRow()

        '                dsNewRow.Item("Act") = sAppFlg
        '                dsNewRow.Item("Approval Status") = sOriFlg
        '                dsNewRow.Item("Comp") = sCocde
        '                dsNewRow.Item("Claim No") = sCaOrdNo
        '                dsNewRow.Item("Claim Seq") = sCaOrdSeq

        '                rs_CLM00002_ITM_AppList.Tables("RESULT").Rows.Add(dsNewRow)
        '            End If
        '        Next

        '        Me.txtDTLResult.Sorted = True

        '        cmdFind_Click(sender, e) 'Refresh two datagridview (Header and Detail) for header update

        '        Dim oldCocde As String = ""
        '        Dim oldCaordno As String = ""
        '        Dim newCocde As String = ""
        '        Dim newCaordno As String = ""
        '        Dim updAppFlg As String = "APV2"
        '        Dim oriAppFlg As String = "APV1"

        '        For indexB As Integer = 0 To rs_CLM00002_ITM_AppList.Tables("RESULT").Rows.Count - 1
        '            newCocde = rs_CLM00002_ITM_AppList.Tables("RESULT").Rows(indexB).Item("Comp").ToString
        '            newCaordno = rs_CLM00002_ITM_AppList.Tables("RESULT").Rows(indexB).Item("Claim No").ToString

        '            If oldCocde <> newCocde Or oldCaordno <> newCaordno Then
        '                For indexC As Integer = 0 To dgDetail.Rows.Count - 1
        '                    If dgDetail.Rows(indexC).Cells("Claim Comp").Value.ToString = newCocde And dgDetail.Rows(indexC).Cells("Claim No").Value.ToString = newCaordno Then
        '                        If dgDetail.Rows(indexC).Cells("Approval Status").Value.ToString = "APV1" Then
        '                            updAppFlg = "APV1"
        '                            oriAppFlg = "OPEN"
        '                        ElseIf dgDetail.Rows(indexC).Cells("Approval Status").Value.ToString = "" Then
        '                            updAppFlg = "OPEN"
        '                            Exit For
        '                        End If
        '                    End If
        '                Next

        '                If updAppFlg <> "OPEN" Then
        '                    gspStr = "sp_update_CLM00002_HDR '" & newCocde & "','" & newCaordno & "','" & updAppFlg & "','','" & gsUsrID & "'"

        '                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        '                    If rtnLong <> RC_SUCCESS Then
        '                        Me.txtHDRResult.Items.Add(newCaordno & " : approval failure from " & oriAppFlg & " to " & updAppFlg & " (" & rtnStr & ")")
        '                    Else
        '                        Me.txtHDRResult.Items.Add(newCaordno & " : approval sucessful from " & oriAppFlg & " to " & updAppFlg & rtnStr)

        '                        dsNewRow = rs_CLM00002_HDR_AppList.Tables("RESULT").NewRow()

        '                        dsNewRow.Item("Act") = updAppFlg
        '                        dsNewRow.Item("Approval Status") = oriAppFlg
        '                        dsNewRow.Item("Comp") = newCocde
        '                        dsNewRow.Item("Claim No") = newCaordno

        '                        rs_CLM00002_HDR_AppList.Tables("RESULT").Rows.Add(dsNewRow)
        '                    End If
        '                End If
        '                oldCocde = newCocde
        '                oldCaordno = newCaordno
        '                updAppFlg = "APV2"
        '            End If
        '        Next

        '        Me.txtHDRResult.Sorted = True

        '        cmdFind_Click(sender, e)
        '        bInDTL = True
        '        tcPOM00010.SelectedIndex = 2
        '    Catch ex As Exception
        '        MsgBox(ex.Message.ToString)
        '    End Try
        'End If
    End Sub

    Private Sub format_dgDTLApproved()
        If rs_CLM00002_ITM_AppList.Tables.Count = 0 Then
            rs_CLM00002_ITM_AppList.Tables.Add("RESULT")
            rs_CLM00002_ITM_AppList.Tables("RESULT").Columns.Add("Act")
            rs_CLM00002_ITM_AppList.Tables("RESULT").Columns.Add("Approval Status")
            rs_CLM00002_ITM_AppList.Tables("RESULT").Columns.Add("Comp")
            rs_CLM00002_ITM_AppList.Tables("RESULT").Columns.Add("Claim No")
            rs_CLM00002_ITM_AppList.Tables("RESULT").Columns.Add("Claim Seq")

            ''dgDTLApproved.DataSource = rs_CLM00002_ITM_AppList.Tables("RESULT").DefaultView
        Else
            rs_CLM00002_ITM_AppList.Tables("RESULT").Rows.Clear()
        End If

        ''dgDTLApproved.Columns(0).Width = 80
        ''dgDTLApproved.Columns(0).HeaderText = "Act"

        ''dgDTLApproved.Columns(1).Width = 80
        ''dgDTLApproved.Columns(1).HeaderText = "Approval Status"

        ''dgDTLApproved.Columns(2).Width = 80
        ''dgDTLApproved.Columns(2).HeaderText = "Comp"

        ''dgDTLApproved.Columns(3).Width = 80
        ''dgDTLApproved.Columns(3).HeaderText = "Claim No"

        ''dgDTLApproved.Columns(4).Width = 80
        ''dgDTLApproved.Columns(4).HeaderText = "Claim Seq"
    End Sub

    Private Sub format_dgHDRApproved()
        If rs_CLM00002_HDR_AppList.Tables.Count = 0 Then
            rs_CLM00002_HDR_AppList.Tables.Add("RESULT")
            rs_CLM00002_HDR_AppList.Tables("RESULT").Columns.Add("Act")
            rs_CLM00002_HDR_AppList.Tables("RESULT").Columns.Add("Approval Status")
            rs_CLM00002_HDR_AppList.Tables("RESULT").Columns.Add("Comp")
            rs_CLM00002_HDR_AppList.Tables("RESULT").Columns.Add("Claim No")

            dgHDRApproved.DataSource = rs_CLM00002_HDR_AppList.Tables("RESULT").DefaultView
        Else
            rs_CLM00002_HDR_AppList.Tables("RESULT").Rows.Clear()
        End If

        dgHDRApproved.Columns(0).Width = 80
        dgHDRApproved.Columns(0).HeaderText = "Act"

        dgHDRApproved.Columns(1).Width = 80
        dgHDRApproved.Columns(1).HeaderText = "Approval Status"

        dgHDRApproved.Columns(2).Width = 80
        dgHDRApproved.Columns(2).HeaderText = "Comp"

        dgHDRApproved.Columns(3).Width = 80
        dgHDRApproved.Columns(3).HeaderText = "Claim No"
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        If tcPOM00010.SelectedIndex = 1 Then
            For indexA As Integer = 0 To dgHeader.SelectedRows.Count - 1
                If dgHeader.SelectedRows(indexA).Cells("Act").Value <> "N" Then
                    If MessageBox.Show("Record(s) is/are applied but not approved in the list, ignore the applied status?", "Important Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = DialogResult.Cancel Then
                        Exit Sub
                    Else
                        Exit For
                    End If
                End If
            Next
        ElseIf tcPOM00010.SelectedIndex = 2 Then
            'For indexA As Integer = 0 To dgDetail.SelectedRows.Count - 1
            '    If dgDetail.SelectedRows(indexA).Cells("Act").Value <> "N" Then
            '        If MessageBox.Show("Record(s) is/are applied but not approved in the list, ignore the applied status?", "Important Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = DialogResult.Cancel Then
            '            Exit Sub
            '        Else
            '            Exit For
            '        End If
            '    End If
            'Next
        End If
        mode = "INIT"
        formInit(mode)
    End Sub

    Private Sub txt_S_CaCreDateFm_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_S_CaCreDateFm.SelectAll()
    End Sub

    Private Sub txt_S_CaCreDateTo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_S_CaCreDateTo.SelectAll()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

    End Sub

    Private Sub cmd_S_SCNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SCNo.Click

    End Sub

    Private Sub dgHeader_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgHeader.CellContentClick

    End Sub

    Private Sub StatusBar1_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles StatusBar1.PanelClick

    End Sub

    Private Sub txt_S_SecCust_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_S_SecCust.TextChanged

    End Sub

    Private Sub cmd_S_PONo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PONo.Click

    End Sub

    Private Sub cmd_S_JobNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_JobNo.Click

    End Sub

    Private Sub cmd_S_CustStyleNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CustStyleNo.Click

    End Sub

    Private Sub txt_S_ItmNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_S_ItmNo.TextChanged

    End Sub

    Private Sub txt_S_PONo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_S_PONo.TextChanged

    End Sub

    Private Sub txt_S_JobNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_S_JobNo.TextChanged

    End Sub

    Private Sub txt_S_CustStyleNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_S_CustStyleNo.TextChanged

    End Sub
End Class

