<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCLMQuickInsert
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txt_S_ShipNo = New System.Windows.Forms.TextBox
        Me.cmdShipNo = New System.Windows.Forms.Button
        Me.lblShipNo = New System.Windows.Forms.Label
        Me.tcfrmCLMQuickInsert = New ERPSystem.BaseTabControl
        Me.tcfrmCLMQuickInsert_1 = New System.Windows.Forms.TabPage
        Me.gbSearchBy = New System.Windows.Forms.GroupBox
        Me.rbSearchBy_S = New System.Windows.Forms.RadioButton
        Me.rbSearchBy_I = New System.Windows.Forms.RadioButton
        Me.cmdClaimPeriod = New System.Windows.Forms.Button
        Me.lblClaimPeriod = New System.Windows.Forms.Label
        Me.txt_S_ClaimPeriod = New System.Windows.Forms.TextBox
        Me.cmdExit1 = New System.Windows.Forms.Button
        Me.txt_S_CustStyleNo = New System.Windows.Forms.TextBox
        Me.lblCustStyleNo = New System.Windows.Forms.Label
        Me.cmdCustStyleNo = New System.Windows.Forms.Button
        Me.lblCustItmNo = New System.Windows.Forms.Label
        Me.txt_S_CustItmNo = New System.Windows.Forms.TextBox
        Me.cmdCustItmNo = New System.Windows.Forms.Button
        Me.txt_S_CustPONo = New System.Windows.Forms.TextBox
        Me.lblCustPONo = New System.Windows.Forms.Label
        Me.cmdCustPONo = New System.Windows.Forms.Button
        Me.lblInvNo = New System.Windows.Forms.Label
        Me.txt_S_InvNo = New System.Windows.Forms.TextBox
        Me.cmdInvNo = New System.Windows.Forms.Button
        Me.txt_S_JobNo = New System.Windows.Forms.TextBox
        Me.lblJobNo = New System.Windows.Forms.Label
        Me.cmdJobNo = New System.Windows.Forms.Button
        Me.txt_S_PONo = New System.Windows.Forms.TextBox
        Me.cmdPONo = New System.Windows.Forms.Button
        Me.lblPONo = New System.Windows.Forms.Label
        Me.txt_S_SCNo = New System.Windows.Forms.TextBox
        Me.cmdSCNo = New System.Windows.Forms.Button
        Me.lblSCNo = New System.Windows.Forms.Label
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.cmdPV = New System.Windows.Forms.Button
        Me.lblPV = New System.Windows.Forms.Label
        Me.txt_S_PV = New System.Windows.Forms.TextBox
        Me.cmdSecCust = New System.Windows.Forms.Button
        Me.txt_S_SecCust = New System.Windows.Forms.TextBox
        Me.lblSecCust = New System.Windows.Forms.Label
        Me.cmdItmNo = New System.Windows.Forms.Button
        Me.cmdPriCust = New System.Windows.Forms.Button
        Me.cmdCoCde = New System.Windows.Forms.Button
        Me.lblItmNo = New System.Windows.Forms.Label
        Me.txt_S_ItmNo = New System.Windows.Forms.TextBox
        Me.txt_S_PriCust = New System.Windows.Forms.TextBox
        Me.txt_S_CoCde = New System.Windows.Forms.TextBox
        Me.lblPriCust = New System.Windows.Forms.Label
        Me.lblCoCde = New System.Windows.Forms.Label
        Me.tcfrmCLMQuickInsert_2 = New System.Windows.Forms.TabPage
        Me.cmdExit2 = New System.Windows.Forms.Button
        Me.chkSelectAll = New System.Windows.Forms.CheckBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdInsert = New System.Windows.Forms.Button
        Me.dgResult = New System.Windows.Forms.DataGridView
        Me.tcfrmCLMQuickInsert.SuspendLayout()
        Me.tcfrmCLMQuickInsert_1.SuspendLayout()
        Me.gbSearchBy.SuspendLayout()
        Me.tcfrmCLMQuickInsert_2.SuspendLayout()
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_S_ShipNo
        '
        Me.txt_S_ShipNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_ShipNo.Location = New System.Drawing.Point(213, 429)
        Me.txt_S_ShipNo.MaxLength = 1000
        Me.txt_S_ShipNo.Name = "txt_S_ShipNo"
        Me.txt_S_ShipNo.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_ShipNo.TabIndex = 209
        Me.txt_S_ShipNo.Visible = False
        '
        'cmdShipNo
        '
        Me.cmdShipNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShipNo.Location = New System.Drawing.Point(141, 426)
        Me.cmdShipNo.Name = "cmdShipNo"
        Me.cmdShipNo.Size = New System.Drawing.Size(64, 24)
        Me.cmdShipNo.TabIndex = 208
        Me.cmdShipNo.Text = "＞＞"
        Me.cmdShipNo.Visible = False
        '
        'lblShipNo
        '
        Me.lblShipNo.AutoSize = True
        Me.lblShipNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShipNo.Location = New System.Drawing.Point(29, 431)
        Me.lblShipNo.Name = "lblShipNo"
        Me.lblShipNo.Size = New System.Drawing.Size(71, 15)
        Me.lblShipNo.TabIndex = 210
        Me.lblShipNo.Text = "Shipment No"
        Me.lblShipNo.Visible = False
        '
        'tcfrmCLMQuickInsert
        '
        Me.tcfrmCLMQuickInsert.Controls.Add(Me.tcfrmCLMQuickInsert_1)
        Me.tcfrmCLMQuickInsert.Controls.Add(Me.tcfrmCLMQuickInsert_2)
        Me.tcfrmCLMQuickInsert.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tcfrmCLMQuickInsert.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcfrmCLMQuickInsert.Location = New System.Drawing.Point(3, 3)
        Me.tcfrmCLMQuickInsert.Name = "tcfrmCLMQuickInsert"
        Me.tcfrmCLMQuickInsert.SelectedIndex = 0
        Me.tcfrmCLMQuickInsert.Size = New System.Drawing.Size(747, 404)
        Me.tcfrmCLMQuickInsert.TabIndex = 0
        '
        'tcfrmCLMQuickInsert_1
        '
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.gbSearchBy)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdClaimPeriod)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.lblClaimPeriod)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.txt_S_ClaimPeriod)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdExit1)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.txt_S_CustStyleNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.lblCustStyleNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdCustStyleNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.lblCustItmNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.txt_S_CustItmNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdCustItmNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.txt_S_CustPONo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.lblCustPONo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdCustPONo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.lblInvNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.txt_S_InvNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdInvNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.txt_S_JobNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.lblJobNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdJobNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.txt_S_PONo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdPONo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.lblPONo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.txt_S_SCNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdSCNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.lblSCNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdSearch)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdPV)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.lblPV)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.txt_S_PV)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdSecCust)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.txt_S_SecCust)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.lblSecCust)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdItmNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdPriCust)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdCoCde)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.lblItmNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.txt_S_ItmNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.txt_S_PriCust)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.txt_S_CoCde)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.lblPriCust)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.lblCoCde)
        Me.tcfrmCLMQuickInsert_1.Location = New System.Drawing.Point(4, 24)
        Me.tcfrmCLMQuickInsert_1.Name = "tcfrmCLMQuickInsert_1"
        Me.tcfrmCLMQuickInsert_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tcfrmCLMQuickInsert_1.Size = New System.Drawing.Size(739, 376)
        Me.tcfrmCLMQuickInsert_1.TabIndex = 0
        Me.tcfrmCLMQuickInsert_1.Text = "Search"
        Me.tcfrmCLMQuickInsert_1.UseVisualStyleBackColor = True
        '
        'gbSearchBy
        '
        Me.gbSearchBy.Controls.Add(Me.rbSearchBy_S)
        Me.gbSearchBy.Controls.Add(Me.rbSearchBy_I)
        Me.gbSearchBy.Location = New System.Drawing.Point(11, 324)
        Me.gbSearchBy.Name = "gbSearchBy"
        Me.gbSearchBy.Size = New System.Drawing.Size(173, 42)
        Me.gbSearchBy.TabIndex = 212
        Me.gbSearchBy.TabStop = False
        Me.gbSearchBy.Text = "Search By"
        Me.gbSearchBy.Visible = False
        '
        'rbSearchBy_S
        '
        Me.rbSearchBy_S.AutoSize = True
        Me.rbSearchBy_S.Location = New System.Drawing.Point(82, 19)
        Me.rbSearchBy_S.Name = "rbSearchBy_S"
        Me.rbSearchBy_S.Size = New System.Drawing.Size(71, 19)
        Me.rbSearchBy_S.TabIndex = 1
        Me.rbSearchBy_S.Text = "Shipment"
        Me.rbSearchBy_S.UseVisualStyleBackColor = True
        '
        'rbSearchBy_I
        '
        Me.rbSearchBy_I.AutoSize = True
        Me.rbSearchBy_I.Location = New System.Drawing.Point(10, 19)
        Me.rbSearchBy_I.Name = "rbSearchBy_I"
        Me.rbSearchBy_I.Size = New System.Drawing.Size(47, 19)
        Me.rbSearchBy_I.TabIndex = 0
        Me.rbSearchBy_I.Text = "Item"
        Me.rbSearchBy_I.UseVisualStyleBackColor = True
        '
        'cmdClaimPeriod
        '
        Me.cmdClaimPeriod.Enabled = False
        Me.cmdClaimPeriod.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClaimPeriod.Location = New System.Drawing.Point(120, 6)
        Me.cmdClaimPeriod.Name = "cmdClaimPeriod"
        Me.cmdClaimPeriod.Size = New System.Drawing.Size(64, 24)
        Me.cmdClaimPeriod.TabIndex = 205
        Me.cmdClaimPeriod.Text = "＞＞"
        '
        'lblClaimPeriod
        '
        Me.lblClaimPeriod.AutoSize = True
        Me.lblClaimPeriod.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaimPeriod.Location = New System.Drawing.Point(8, 11)
        Me.lblClaimPeriod.Name = "lblClaimPeriod"
        Me.lblClaimPeriod.Size = New System.Drawing.Size(87, 15)
        Me.lblClaimPeriod.TabIndex = 207
        Me.lblClaimPeriod.Text = "Shipment Period"
        '
        'txt_S_ClaimPeriod
        '
        Me.txt_S_ClaimPeriod.Enabled = False
        Me.txt_S_ClaimPeriod.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_ClaimPeriod.Location = New System.Drawing.Point(192, 8)
        Me.txt_S_ClaimPeriod.MaxLength = 1000
        Me.txt_S_ClaimPeriod.Name = "txt_S_ClaimPeriod"
        Me.txt_S_ClaimPeriod.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_ClaimPeriod.TabIndex = 206
        '
        'cmdExit1
        '
        Me.cmdExit1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit1.Location = New System.Drawing.Point(388, 332)
        Me.cmdExit1.Name = "cmdExit1"
        Me.cmdExit1.Size = New System.Drawing.Size(129, 34)
        Me.cmdExit1.TabIndex = 28
        Me.cmdExit1.Text = "E&xit"
        Me.cmdExit1.UseVisualStyleBackColor = True
        '
        'txt_S_CustStyleNo
        '
        Me.txt_S_CustStyleNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_CustStyleNo.Location = New System.Drawing.Point(192, 297)
        Me.txt_S_CustStyleNo.MaxLength = 1000
        Me.txt_S_CustStyleNo.Name = "txt_S_CustStyleNo"
        Me.txt_S_CustStyleNo.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_CustStyleNo.TabIndex = 24
        '
        'lblCustStyleNo
        '
        Me.lblCustStyleNo.AutoSize = True
        Me.lblCustStyleNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustStyleNo.Location = New System.Drawing.Point(8, 299)
        Me.lblCustStyleNo.Name = "lblCustStyleNo"
        Me.lblCustStyleNo.Size = New System.Drawing.Size(76, 15)
        Me.lblCustStyleNo.TabIndex = 204
        Me.lblCustStyleNo.Text = "Cust Style No"
        '
        'cmdCustStyleNo
        '
        Me.cmdCustStyleNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCustStyleNo.Location = New System.Drawing.Point(120, 294)
        Me.cmdCustStyleNo.Name = "cmdCustStyleNo"
        Me.cmdCustStyleNo.Size = New System.Drawing.Size(64, 24)
        Me.cmdCustStyleNo.TabIndex = 23
        Me.cmdCustStyleNo.Text = "＞＞"
        '
        'lblCustItmNo
        '
        Me.lblCustItmNo.AutoSize = True
        Me.lblCustItmNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustItmNo.Location = New System.Drawing.Point(8, 275)
        Me.lblCustItmNo.Name = "lblCustItmNo"
        Me.lblCustItmNo.Size = New System.Drawing.Size(73, 15)
        Me.lblCustItmNo.TabIndex = 202
        Me.lblCustItmNo.Text = "Cust Item No"
        '
        'txt_S_CustItmNo
        '
        Me.txt_S_CustItmNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_CustItmNo.Location = New System.Drawing.Point(192, 273)
        Me.txt_S_CustItmNo.MaxLength = 1000
        Me.txt_S_CustItmNo.Name = "txt_S_CustItmNo"
        Me.txt_S_CustItmNo.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_CustItmNo.TabIndex = 22
        '
        'cmdCustItmNo
        '
        Me.cmdCustItmNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCustItmNo.Location = New System.Drawing.Point(120, 270)
        Me.cmdCustItmNo.Name = "cmdCustItmNo"
        Me.cmdCustItmNo.Size = New System.Drawing.Size(64, 24)
        Me.cmdCustItmNo.TabIndex = 21
        Me.cmdCustItmNo.Text = "＞＞"
        '
        'txt_S_CustPONo
        '
        Me.txt_S_CustPONo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_CustPONo.Location = New System.Drawing.Point(192, 249)
        Me.txt_S_CustPONo.MaxLength = 1000
        Me.txt_S_CustPONo.Name = "txt_S_CustPONo"
        Me.txt_S_CustPONo.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_CustPONo.TabIndex = 20
        '
        'lblCustPONo
        '
        Me.lblCustPONo.AutoSize = True
        Me.lblCustPONo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustPONo.Location = New System.Drawing.Point(8, 251)
        Me.lblCustPONo.Name = "lblCustPONo"
        Me.lblCustPONo.Size = New System.Drawing.Size(67, 15)
        Me.lblCustPONo.TabIndex = 200
        Me.lblCustPONo.Text = "Cust PO No"
        '
        'cmdCustPONo
        '
        Me.cmdCustPONo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCustPONo.Location = New System.Drawing.Point(120, 246)
        Me.cmdCustPONo.Name = "cmdCustPONo"
        Me.cmdCustPONo.Size = New System.Drawing.Size(64, 24)
        Me.cmdCustPONo.TabIndex = 19
        Me.cmdCustPONo.Text = "＞＞"
        '
        'lblInvNo
        '
        Me.lblInvNo.AutoSize = True
        Me.lblInvNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvNo.Location = New System.Drawing.Point(8, 227)
        Me.lblInvNo.Name = "lblInvNo"
        Me.lblInvNo.Size = New System.Drawing.Size(60, 15)
        Me.lblInvNo.TabIndex = 198
        Me.lblInvNo.Text = "Invoice No"
        '
        'txt_S_InvNo
        '
        Me.txt_S_InvNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_InvNo.Location = New System.Drawing.Point(192, 225)
        Me.txt_S_InvNo.MaxLength = 1000
        Me.txt_S_InvNo.Name = "txt_S_InvNo"
        Me.txt_S_InvNo.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_InvNo.TabIndex = 18
        '
        'cmdInvNo
        '
        Me.cmdInvNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInvNo.Location = New System.Drawing.Point(120, 222)
        Me.cmdInvNo.Name = "cmdInvNo"
        Me.cmdInvNo.Size = New System.Drawing.Size(64, 24)
        Me.cmdInvNo.TabIndex = 17
        Me.cmdInvNo.Text = "＞＞"
        '
        'txt_S_JobNo
        '
        Me.txt_S_JobNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_JobNo.Location = New System.Drawing.Point(192, 201)
        Me.txt_S_JobNo.MaxLength = 1000
        Me.txt_S_JobNo.Name = "txt_S_JobNo"
        Me.txt_S_JobNo.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_JobNo.TabIndex = 16
        '
        'lblJobNo
        '
        Me.lblJobNo.AutoSize = True
        Me.lblJobNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobNo.Location = New System.Drawing.Point(8, 203)
        Me.lblJobNo.Name = "lblJobNo"
        Me.lblJobNo.Size = New System.Drawing.Size(42, 15)
        Me.lblJobNo.TabIndex = 195
        Me.lblJobNo.Text = "Job No"
        '
        'cmdJobNo
        '
        Me.cmdJobNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdJobNo.Location = New System.Drawing.Point(120, 198)
        Me.cmdJobNo.Name = "cmdJobNo"
        Me.cmdJobNo.Size = New System.Drawing.Size(64, 24)
        Me.cmdJobNo.TabIndex = 15
        Me.cmdJobNo.Text = "＞＞"
        '
        'txt_S_PONo
        '
        Me.txt_S_PONo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_PONo.Location = New System.Drawing.Point(192, 177)
        Me.txt_S_PONo.MaxLength = 1000
        Me.txt_S_PONo.Name = "txt_S_PONo"
        Me.txt_S_PONo.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_PONo.TabIndex = 14
        '
        'cmdPONo
        '
        Me.cmdPONo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPONo.Location = New System.Drawing.Point(120, 174)
        Me.cmdPONo.Name = "cmdPONo"
        Me.cmdPONo.Size = New System.Drawing.Size(64, 24)
        Me.cmdPONo.TabIndex = 13
        Me.cmdPONo.Text = "＞＞"
        '
        'lblPONo
        '
        Me.lblPONo.AutoSize = True
        Me.lblPONo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPONo.Location = New System.Drawing.Point(8, 179)
        Me.lblPONo.Name = "lblPONo"
        Me.lblPONo.Size = New System.Drawing.Size(41, 15)
        Me.lblPONo.TabIndex = 194
        Me.lblPONo.Text = "PO No"
        '
        'txt_S_SCNo
        '
        Me.txt_S_SCNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_SCNo.Location = New System.Drawing.Point(192, 153)
        Me.txt_S_SCNo.MaxLength = 1000
        Me.txt_S_SCNo.Name = "txt_S_SCNo"
        Me.txt_S_SCNo.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_SCNo.TabIndex = 12
        '
        'cmdSCNo
        '
        Me.cmdSCNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSCNo.Location = New System.Drawing.Point(120, 150)
        Me.cmdSCNo.Name = "cmdSCNo"
        Me.cmdSCNo.Size = New System.Drawing.Size(64, 24)
        Me.cmdSCNo.TabIndex = 11
        Me.cmdSCNo.Text = "＞＞"
        '
        'lblSCNo
        '
        Me.lblSCNo.AutoSize = True
        Me.lblSCNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSCNo.Location = New System.Drawing.Point(8, 155)
        Me.lblSCNo.Name = "lblSCNo"
        Me.lblSCNo.Size = New System.Drawing.Size(39, 15)
        Me.lblSCNo.TabIndex = 193
        Me.lblSCNo.Text = "SC No"
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(252, 332)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(129, 34)
        Me.cmdSearch.TabIndex = 27
        Me.cmdSearch.Text = "Searc&h"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'cmdPV
        '
        Me.cmdPV.Enabled = False
        Me.cmdPV.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPV.Location = New System.Drawing.Point(120, 102)
        Me.cmdPV.Name = "cmdPV"
        Me.cmdPV.Size = New System.Drawing.Size(64, 24)
        Me.cmdPV.TabIndex = 7
        Me.cmdPV.Text = "＞＞"
        '
        'lblPV
        '
        Me.lblPV.AutoSize = True
        Me.lblPV.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPV.Location = New System.Drawing.Point(8, 107)
        Me.lblPV.Name = "lblPV"
        Me.lblPV.Size = New System.Drawing.Size(98, 15)
        Me.lblPV.TabIndex = 191
        Me.lblPV.Text = "Production Vendor"
        '
        'txt_S_PV
        '
        Me.txt_S_PV.Enabled = False
        Me.txt_S_PV.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_PV.Location = New System.Drawing.Point(192, 104)
        Me.txt_S_PV.MaxLength = 1000
        Me.txt_S_PV.Name = "txt_S_PV"
        Me.txt_S_PV.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_PV.TabIndex = 8
        '
        'cmdSecCust
        '
        Me.cmdSecCust.Enabled = False
        Me.cmdSecCust.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSecCust.Location = New System.Drawing.Point(120, 78)
        Me.cmdSecCust.Name = "cmdSecCust"
        Me.cmdSecCust.Size = New System.Drawing.Size(64, 24)
        Me.cmdSecCust.TabIndex = 5
        Me.cmdSecCust.Text = "＞＞"
        '
        'txt_S_SecCust
        '
        Me.txt_S_SecCust.Enabled = False
        Me.txt_S_SecCust.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_SecCust.Location = New System.Drawing.Point(192, 80)
        Me.txt_S_SecCust.MaxLength = 1000
        Me.txt_S_SecCust.Name = "txt_S_SecCust"
        Me.txt_S_SecCust.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_SecCust.TabIndex = 6
        '
        'lblSecCust
        '
        Me.lblSecCust.AutoSize = True
        Me.lblSecCust.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSecCust.Location = New System.Drawing.Point(8, 83)
        Me.lblSecCust.Name = "lblSecCust"
        Me.lblSecCust.Size = New System.Drawing.Size(73, 15)
        Me.lblSecCust.TabIndex = 190
        Me.lblSecCust.Text = "Sec Customer"
        '
        'cmdItmNo
        '
        Me.cmdItmNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdItmNo.Location = New System.Drawing.Point(120, 126)
        Me.cmdItmNo.Name = "cmdItmNo"
        Me.cmdItmNo.Size = New System.Drawing.Size(64, 24)
        Me.cmdItmNo.TabIndex = 9
        Me.cmdItmNo.Text = "＞＞"
        Me.cmdItmNo.Visible = False
        '
        'cmdPriCust
        '
        Me.cmdPriCust.Enabled = False
        Me.cmdPriCust.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPriCust.Location = New System.Drawing.Point(120, 54)
        Me.cmdPriCust.Name = "cmdPriCust"
        Me.cmdPriCust.Size = New System.Drawing.Size(64, 24)
        Me.cmdPriCust.TabIndex = 3
        Me.cmdPriCust.Text = "＞＞"
        '
        'cmdCoCde
        '
        Me.cmdCoCde.Enabled = False
        Me.cmdCoCde.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCoCde.Location = New System.Drawing.Point(120, 30)
        Me.cmdCoCde.Name = "cmdCoCde"
        Me.cmdCoCde.Size = New System.Drawing.Size(64, 24)
        Me.cmdCoCde.TabIndex = 1
        Me.cmdCoCde.Text = "＞＞"
        '
        'lblItmNo
        '
        Me.lblItmNo.AutoSize = True
        Me.lblItmNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItmNo.Location = New System.Drawing.Point(8, 131)
        Me.lblItmNo.Name = "lblItmNo"
        Me.lblItmNo.Size = New System.Drawing.Size(47, 15)
        Me.lblItmNo.TabIndex = 189
        Me.lblItmNo.Text = "Item No"
        Me.lblItmNo.Visible = False
        '
        'txt_S_ItmNo
        '
        Me.txt_S_ItmNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_ItmNo.Location = New System.Drawing.Point(192, 128)
        Me.txt_S_ItmNo.MaxLength = 1000
        Me.txt_S_ItmNo.Name = "txt_S_ItmNo"
        Me.txt_S_ItmNo.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_ItmNo.TabIndex = 10
        Me.txt_S_ItmNo.Visible = False
        '
        'txt_S_PriCust
        '
        Me.txt_S_PriCust.Enabled = False
        Me.txt_S_PriCust.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_PriCust.Location = New System.Drawing.Point(192, 56)
        Me.txt_S_PriCust.MaxLength = 1000
        Me.txt_S_PriCust.Name = "txt_S_PriCust"
        Me.txt_S_PriCust.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_PriCust.TabIndex = 4
        '
        'txt_S_CoCde
        '
        Me.txt_S_CoCde.Enabled = False
        Me.txt_S_CoCde.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_CoCde.Location = New System.Drawing.Point(192, 32)
        Me.txt_S_CoCde.MaxLength = 1000
        Me.txt_S_CoCde.Name = "txt_S_CoCde"
        Me.txt_S_CoCde.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_CoCde.TabIndex = 2
        '
        'lblPriCust
        '
        Me.lblPriCust.AutoSize = True
        Me.lblPriCust.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPriCust.Location = New System.Drawing.Point(8, 59)
        Me.lblPriCust.Name = "lblPriCust"
        Me.lblPriCust.Size = New System.Drawing.Size(71, 15)
        Me.lblPriCust.TabIndex = 188
        Me.lblPriCust.Text = "Pri Customer"
        '
        'lblCoCde
        '
        Me.lblCoCde.AutoSize = True
        Me.lblCoCde.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoCde.Location = New System.Drawing.Point(8, 35)
        Me.lblCoCde.Name = "lblCoCde"
        Me.lblCoCde.Size = New System.Drawing.Size(83, 15)
        Me.lblCoCde.TabIndex = 187
        Me.lblCoCde.Text = "Company Code"
        '
        'tcfrmCLMQuickInsert_2
        '
        Me.tcfrmCLMQuickInsert_2.Controls.Add(Me.cmdExit2)
        Me.tcfrmCLMQuickInsert_2.Controls.Add(Me.chkSelectAll)
        Me.tcfrmCLMQuickInsert_2.Controls.Add(Me.cmdCancel)
        Me.tcfrmCLMQuickInsert_2.Controls.Add(Me.cmdInsert)
        Me.tcfrmCLMQuickInsert_2.Controls.Add(Me.dgResult)
        Me.tcfrmCLMQuickInsert_2.Location = New System.Drawing.Point(4, 24)
        Me.tcfrmCLMQuickInsert_2.Name = "tcfrmCLMQuickInsert_2"
        Me.tcfrmCLMQuickInsert_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tcfrmCLMQuickInsert_2.Size = New System.Drawing.Size(739, 376)
        Me.tcfrmCLMQuickInsert_2.TabIndex = 1
        Me.tcfrmCLMQuickInsert_2.Text = "Result"
        Me.tcfrmCLMQuickInsert_2.UseVisualStyleBackColor = True
        '
        'cmdExit2
        '
        Me.cmdExit2.Location = New System.Drawing.Point(671, 348)
        Me.cmdExit2.Name = "cmdExit2"
        Me.cmdExit2.Size = New System.Drawing.Size(61, 29)
        Me.cmdExit2.TabIndex = 4
        Me.cmdExit2.Text = "E&xit"
        Me.cmdExit2.UseVisualStyleBackColor = True
        '
        'chkSelectAll
        '
        Me.chkSelectAll.AutoSize = True
        Me.chkSelectAll.Location = New System.Drawing.Point(459, 354)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(72, 19)
        Me.chkSelectAll.TabIndex = 1
        Me.chkSelectAll.Text = "Select All"
        Me.chkSelectAll.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(604, 348)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(61, 29)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdInsert
        '
        Me.cmdInsert.Location = New System.Drawing.Point(537, 348)
        Me.cmdInsert.Name = "cmdInsert"
        Me.cmdInsert.Size = New System.Drawing.Size(61, 29)
        Me.cmdInsert.TabIndex = 2
        Me.cmdInsert.Text = "Insert"
        Me.cmdInsert.UseVisualStyleBackColor = True
        '
        'dgResult
        '
        Me.dgResult.AllowUserToAddRows = False
        Me.dgResult.AllowUserToDeleteRows = False
        Me.dgResult.AllowUserToResizeColumns = False
        Me.dgResult.AllowUserToResizeRows = False
        Me.dgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgResult.Location = New System.Drawing.Point(6, 6)
        Me.dgResult.Name = "dgResult"
        Me.dgResult.RowHeadersVisible = False
        Me.dgResult.Size = New System.Drawing.Size(726, 336)
        Me.dgResult.TabIndex = 0
        '
        'frmCLMQuickInsert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(755, 415)
        Me.Controls.Add(Me.tcfrmCLMQuickInsert)
        Me.Controls.Add(Me.txt_S_ShipNo)
        Me.Controls.Add(Me.cmdShipNo)
        Me.Controls.Add(Me.lblShipNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmCLMQuickInsert"
        Me.Text = "Claims Quick Insert Function"
        Me.tcfrmCLMQuickInsert.ResumeLayout(False)
        Me.tcfrmCLMQuickInsert_1.ResumeLayout(False)
        Me.tcfrmCLMQuickInsert_1.PerformLayout()
        Me.gbSearchBy.ResumeLayout(False)
        Me.gbSearchBy.PerformLayout()
        Me.tcfrmCLMQuickInsert_2.ResumeLayout(False)
        Me.tcfrmCLMQuickInsert_2.PerformLayout()
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tcfrmCLMQuickInsert As ERPSystem.BaseTabControl
    Friend WithEvents tcfrmCLMQuickInsert_1 As System.Windows.Forms.TabPage
    Friend WithEvents tcfrmCLMQuickInsert_2 As System.Windows.Forms.TabPage
    Friend WithEvents dgResult As System.Windows.Forms.DataGridView
    Friend WithEvents cmdPV As System.Windows.Forms.Button
    Friend WithEvents lblPV As System.Windows.Forms.Label
    Friend WithEvents txt_S_PV As System.Windows.Forms.TextBox
    Friend WithEvents cmdSecCust As System.Windows.Forms.Button
    Friend WithEvents txt_S_SecCust As System.Windows.Forms.TextBox
    Friend WithEvents lblSecCust As System.Windows.Forms.Label
    Friend WithEvents cmdItmNo As System.Windows.Forms.Button
    Friend WithEvents cmdPriCust As System.Windows.Forms.Button
    Friend WithEvents cmdCoCde As System.Windows.Forms.Button
    Friend WithEvents lblItmNo As System.Windows.Forms.Label
    Friend WithEvents txt_S_ItmNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_PriCust As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_CoCde As System.Windows.Forms.TextBox
    Friend WithEvents lblPriCust As System.Windows.Forms.Label
    Friend WithEvents lblCoCde As System.Windows.Forms.Label
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdInsert As System.Windows.Forms.Button
    Friend WithEvents txt_S_SCNo As System.Windows.Forms.TextBox
    Friend WithEvents cmdSCNo As System.Windows.Forms.Button
    Friend WithEvents lblSCNo As System.Windows.Forms.Label
    Friend WithEvents txt_S_PONo As System.Windows.Forms.TextBox
    Friend WithEvents cmdPONo As System.Windows.Forms.Button
    Friend WithEvents lblPONo As System.Windows.Forms.Label
    Friend WithEvents txt_S_JobNo As System.Windows.Forms.TextBox
    Friend WithEvents lblJobNo As System.Windows.Forms.Label
    Friend WithEvents cmdJobNo As System.Windows.Forms.Button
    Friend WithEvents lblInvNo As System.Windows.Forms.Label
    Friend WithEvents txt_S_InvNo As System.Windows.Forms.TextBox
    Friend WithEvents cmdInvNo As System.Windows.Forms.Button
    Friend WithEvents txt_S_CustPONo As System.Windows.Forms.TextBox
    Friend WithEvents lblCustPONo As System.Windows.Forms.Label
    Friend WithEvents cmdCustPONo As System.Windows.Forms.Button
    Friend WithEvents lblCustItmNo As System.Windows.Forms.Label
    Friend WithEvents txt_S_CustItmNo As System.Windows.Forms.TextBox
    Friend WithEvents cmdCustItmNo As System.Windows.Forms.Button
    Friend WithEvents txt_S_CustStyleNo As System.Windows.Forms.TextBox
    Friend WithEvents lblCustStyleNo As System.Windows.Forms.Label
    Friend WithEvents cmdCustStyleNo As System.Windows.Forms.Button
    Friend WithEvents cmdExit1 As System.Windows.Forms.Button
    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents cmdExit2 As System.Windows.Forms.Button
    Friend WithEvents cmdClaimPeriod As System.Windows.Forms.Button
    Friend WithEvents lblClaimPeriod As System.Windows.Forms.Label
    Friend WithEvents txt_S_ClaimPeriod As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_ShipNo As System.Windows.Forms.TextBox
    Friend WithEvents cmdShipNo As System.Windows.Forms.Button
    Friend WithEvents lblShipNo As System.Windows.Forms.Label
    Friend WithEvents gbSearchBy As System.Windows.Forms.GroupBox
    Friend WithEvents rbSearchBy_S As System.Windows.Forms.RadioButton
    Friend WithEvents rbSearchBy_I As System.Windows.Forms.RadioButton
End Class
