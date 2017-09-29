<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SCM00006
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
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.cmdInsRow = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdLast = New System.Windows.Forms.Button
        Me.cmdPrevious = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdFind = New System.Windows.Forms.Button
        Me.cmdCopy = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdDelRow = New System.Windows.Forms.Button
        Me.cmdFirst = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.tabFrame = New ERPSystem.BaseTabControl
        Me.tabFrame_Search = New System.Windows.Forms.TabPage
        Me.grpSearch = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtSCRvsdatTo = New System.Windows.Forms.MaskedTextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtSCRvsdatFm = New System.Windows.Forms.MaskedTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_S_ItmNo = New System.Windows.Forms.TextBox
        Me.cmd_S_ItmNo = New System.Windows.Forms.Button
        Me.txt_S_SCNo = New System.Windows.Forms.TextBox
        Me.cmd_S_SCNo = New System.Windows.Forms.Button
        Me.txt_S_SecCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_SecCust = New System.Windows.Forms.Button
        Me.txt_S_PriCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_PriCust = New System.Windows.Forms.Button
        Me.txt_S_CoCde = New System.Windows.Forms.TextBox
        Me.cmd_S_CoCde = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tabFrame_Header = New System.Windows.Forms.TabPage
        Me.grpHeader = New System.Windows.Forms.GroupBox
        Me.cmdHdrApvApply = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbHdrApv_W = New System.Windows.Forms.RadioButton
        Me.rbHdrApv_Y = New System.Windows.Forms.RadioButton
        Me.lblPricing = New System.Windows.Forms.Label
        Me.gbPriceView = New System.Windows.Forms.GroupBox
        Me.rbHdrApvFilter_CloseOut = New System.Windows.Forms.RadioButton
        Me.rbHdrApvFilter_Replacement = New System.Windows.Forms.RadioButton
        Me.rbHdrApvFilter_PaymentTerm = New System.Windows.Forms.RadioButton
        Me.rbHdrApvFilter_PriceTerm = New System.Windows.Forms.RadioButton
        Me.rbHdrApvFilter_All = New System.Windows.Forms.RadioButton
        Me.grpHdrAprv = New System.Windows.Forms.GroupBox
        Me.cmdHdrApply = New System.Windows.Forms.Button
        Me.cmdHdrSelectAll = New System.Windows.Forms.Button
        Me.optHdrAprvY = New System.Windows.Forms.RadioButton
        Me.optHdrAprvW = New System.Windows.Forms.RadioButton
        Me.optHdrAprvN = New System.Windows.Forms.RadioButton
        Me.dgHeader = New System.Windows.Forms.DataGridView
        Me.tabFrame_Detail = New System.Windows.Forms.TabPage
        Me.grpDetail = New System.Windows.Forms.GroupBox
        Me.cmdDtlApvApply = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.rbDtlApv_W = New System.Windows.Forms.RadioButton
        Me.rbDtlApv_Y = New System.Windows.Forms.RadioButton
        Me.Label17 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbDtlApvFilter_ChgSelPrc = New System.Windows.Forms.RadioButton
        Me.rbDtlApvFilter_ChgDVPVFtyCst = New System.Windows.Forms.RadioButton
        Me.rbDtlApvFilter_OneTime = New System.Windows.Forms.RadioButton
        Me.rbDtlApvFilter_BelowMinMU = New System.Windows.Forms.RadioButton
        Me.rbDtlApvFilter_MOQ = New System.Windows.Forms.RadioButton
        Me.rbDtlApvFilter_All = New System.Windows.Forms.RadioButton
        Me.dgDetail = New System.Windows.Forms.DataGridView
        Me.txtRvsDat = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtSecCus = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtPriCus = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtOrdSts = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtSCNo = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdDtlApply = New System.Windows.Forms.Button
        Me.cmdDtlSelectAll = New System.Windows.Forms.Button
        Me.optDtlAprvY = New System.Windows.Forms.RadioButton
        Me.optDtlAprvW = New System.Windows.Forms.RadioButton
        Me.optDtlAprvN = New System.Windows.Forms.RadioButton
        Me.txtCoCde = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.tabFrame.SuspendLayout()
        Me.tabFrame_Search.SuspendLayout()
        Me.grpSearch.SuspendLayout()
        Me.tabFrame_Header.SuspendLayout()
        Me.grpHeader.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbPriceView.SuspendLayout()
        Me.grpHdrAprv.SuspendLayout()
        CType(Me.dgHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabFrame_Detail.SuspendLayout()
        Me.grpDetail.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 700)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(1072, 16)
        Me.StatusBar1.TabIndex = 295
        Me.StatusBar1.Text = "StatusBar1"
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsRow.Location = New System.Drawing.Point(520, 0)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(65, 25)
        Me.cmdInsRow.TabIndex = 303
        Me.cmdInsRow.TabStop = False
        Me.cmdInsRow.Text = "I&ns Row"
        Me.cmdInsRow.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(130, 0)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(65, 25)
        Me.cmdDelete.TabIndex = 298
        Me.cmdDelete.TabStop = False
        Me.cmdDelete.Text = "&Delete"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(65, 0)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(65, 25)
        Me.cmdSave.TabIndex = 297
        Me.cmdSave.TabStop = False
        Me.cmdSave.Text = "&Save"
        '
        'cmdLast
        '
        Me.cmdLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLast.Location = New System.Drawing.Point(820, 0)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(50, 25)
        Me.cmdLast.TabIndex = 308
        Me.cmdLast.TabStop = False
        Me.cmdLast.Text = ">>|"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.Location = New System.Drawing.Point(720, 0)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(50, 25)
        Me.cmdPrevious.TabIndex = 306
        Me.cmdPrevious.TabStop = False
        Me.cmdPrevious.Text = "<"
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(0, 0)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(65, 25)
        Me.cmdAdd.TabIndex = 296
        Me.cmdAdd.TabStop = False
        Me.cmdAdd.Text = "&Add"
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(770, 0)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(50, 25)
        Me.cmdNext.TabIndex = 307
        Me.cmdNext.TabStop = False
        Me.cmdNext.Text = ">"
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFind.Location = New System.Drawing.Point(260, 0)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(65, 25)
        Me.cmdFind.TabIndex = 300
        Me.cmdFind.TabStop = False
        Me.cmdFind.Text = "&Find"
        '
        'cmdCopy
        '
        Me.cmdCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(195, 0)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(65, 25)
        Me.cmdCopy.TabIndex = 299
        Me.cmdCopy.TabStop = False
        Me.cmdCopy.Text = "&Copy"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(325, 0)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(65, 25)
        Me.cmdClear.TabIndex = 301
        Me.cmdClear.TabStop = False
        Me.cmdClear.Text = "Cl&ear"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(887, 0)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(65, 25)
        Me.cmdExit.TabIndex = 309
        Me.cmdExit.TabStop = False
        Me.cmdExit.Text = "E&xit"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelRow.Location = New System.Drawing.Point(585, 0)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(65, 25)
        Me.cmdDelRow.TabIndex = 304
        Me.cmdDelRow.TabStop = False
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdFirst
        '
        Me.cmdFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFirst.Location = New System.Drawing.Point(670, 0)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(50, 25)
        Me.cmdFirst.TabIndex = 305
        Me.cmdFirst.TabStop = False
        Me.cmdFirst.Text = "|<<"
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(420, 0)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(65, 25)
        Me.cmdSearch.TabIndex = 302
        Me.cmdSearch.TabStop = False
        Me.cmdSearch.Text = "Searc&h"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(116, 10)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(127, 17)
        Me.RadioButton1.TabIndex = 64
        Me.RadioButton1.Text = "W - Wait for Approval"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(16, 9)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(83, 17)
        Me.RadioButton2.TabIndex = 63
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Y - Approval"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(116, 10)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(127, 17)
        Me.RadioButton3.TabIndex = 64
        Me.RadioButton3.Text = "W - Wait for Approval"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Checked = True
        Me.RadioButton4.Location = New System.Drawing.Point(16, 9)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(83, 17)
        Me.RadioButton4.TabIndex = 63
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Y - Approval"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'tabFrame
        '
        Me.tabFrame.Controls.Add(Me.tabFrame_Search)
        Me.tabFrame.Controls.Add(Me.tabFrame_Header)
        Me.tabFrame.Controls.Add(Me.tabFrame_Detail)
        Me.tabFrame.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tabFrame.ItemSize = New System.Drawing.Size(100, 20)
        Me.tabFrame.Location = New System.Drawing.Point(0, 31)
        Me.tabFrame.Name = "tabFrame"
        Me.tabFrame.SelectedIndex = 0
        Me.tabFrame.Size = New System.Drawing.Size(1072, 663)
        Me.tabFrame.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabFrame.TabIndex = 294
        '
        'tabFrame_Search
        '
        Me.tabFrame_Search.Controls.Add(Me.grpSearch)
        Me.tabFrame_Search.Location = New System.Drawing.Point(4, 24)
        Me.tabFrame_Search.Name = "tabFrame_Search"
        Me.tabFrame_Search.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFrame_Search.Size = New System.Drawing.Size(1064, 635)
        Me.tabFrame_Search.TabIndex = 0
        Me.tabFrame_Search.Text = "(1) Search"
        Me.tabFrame_Search.UseVisualStyleBackColor = True
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.Label16)
        Me.grpSearch.Controls.Add(Me.Label15)
        Me.grpSearch.Controls.Add(Me.txtSCRvsdatTo)
        Me.grpSearch.Controls.Add(Me.Label8)
        Me.grpSearch.Controls.Add(Me.txtSCRvsdatFm)
        Me.grpSearch.Controls.Add(Me.Label7)
        Me.grpSearch.Controls.Add(Me.txt_S_ItmNo)
        Me.grpSearch.Controls.Add(Me.cmd_S_ItmNo)
        Me.grpSearch.Controls.Add(Me.txt_S_SCNo)
        Me.grpSearch.Controls.Add(Me.cmd_S_SCNo)
        Me.grpSearch.Controls.Add(Me.txt_S_SecCustAll)
        Me.grpSearch.Controls.Add(Me.cmd_S_SecCust)
        Me.grpSearch.Controls.Add(Me.txt_S_PriCustAll)
        Me.grpSearch.Controls.Add(Me.cmd_S_PriCust)
        Me.grpSearch.Controls.Add(Me.txt_S_CoCde)
        Me.grpSearch.Controls.Add(Me.cmd_S_CoCde)
        Me.grpSearch.Controls.Add(Me.Label6)
        Me.grpSearch.Controls.Add(Me.Label5)
        Me.grpSearch.Controls.Add(Me.Label4)
        Me.grpSearch.Controls.Add(Me.Label3)
        Me.grpSearch.Controls.Add(Me.Label2)
        Me.grpSearch.Controls.Add(Me.Label1)
        Me.grpSearch.Location = New System.Drawing.Point(1, -3)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(1060, 635)
        Me.grpSearch.TabIndex = 0
        Me.grpSearch.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(443, 286)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 13)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "MM/DD/YYYY"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(241, 286)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 13)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "MM/DD/YYYY"
        '
        'txtSCRvsdatTo
        '
        Me.txtSCRvsdatTo.Location = New System.Drawing.Point(444, 263)
        Me.txtSCRvsdatTo.Mask = "00/00/0000"
        Me.txtSCRvsdatTo.Name = "txtSCRvsdatTo"
        Me.txtSCRvsdatTo.Size = New System.Drawing.Size(100, 20)
        Me.txtSCRvsdatTo.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(411, 266)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "To"
        '
        'txtSCRvsdatFm
        '
        Me.txtSCRvsdatFm.Location = New System.Drawing.Point(242, 263)
        Me.txtSCRvsdatFm.Mask = "00/00/0000"
        Me.txtSCRvsdatFm.Name = "txtSCRvsdatFm"
        Me.txtSCRvsdatFm.Size = New System.Drawing.Size(100, 20)
        Me.txtSCRvsdatFm.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(196, 266)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "From"
        '
        'txt_S_ItmNo
        '
        Me.txt_S_ItmNo.Location = New System.Drawing.Point(242, 228)
        Me.txt_S_ItmNo.Name = "txt_S_ItmNo"
        Me.txt_S_ItmNo.Size = New System.Drawing.Size(726, 20)
        Me.txt_S_ItmNo.TabIndex = 15
        '
        'cmd_S_ItmNo
        '
        Me.cmd_S_ItmNo.Location = New System.Drawing.Point(173, 226)
        Me.cmd_S_ItmNo.Name = "cmd_S_ItmNo"
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(53, 23)
        Me.cmd_S_ItmNo.TabIndex = 14
        Me.cmd_S_ItmNo.Text = ">>"
        Me.cmd_S_ItmNo.UseVisualStyleBackColor = True
        '
        'txt_S_SCNo
        '
        Me.txt_S_SCNo.Location = New System.Drawing.Point(242, 193)
        Me.txt_S_SCNo.Name = "txt_S_SCNo"
        Me.txt_S_SCNo.Size = New System.Drawing.Size(726, 20)
        Me.txt_S_SCNo.TabIndex = 13
        '
        'cmd_S_SCNo
        '
        Me.cmd_S_SCNo.Location = New System.Drawing.Point(173, 191)
        Me.cmd_S_SCNo.Name = "cmd_S_SCNo"
        Me.cmd_S_SCNo.Size = New System.Drawing.Size(53, 23)
        Me.cmd_S_SCNo.TabIndex = 12
        Me.cmd_S_SCNo.Text = ">>"
        Me.cmd_S_SCNo.UseVisualStyleBackColor = True
        '
        'txt_S_SecCustAll
        '
        Me.txt_S_SecCustAll.Location = New System.Drawing.Point(242, 158)
        Me.txt_S_SecCustAll.Name = "txt_S_SecCustAll"
        Me.txt_S_SecCustAll.Size = New System.Drawing.Size(726, 20)
        Me.txt_S_SecCustAll.TabIndex = 11
        '
        'cmd_S_SecCust
        '
        Me.cmd_S_SecCust.Location = New System.Drawing.Point(173, 156)
        Me.cmd_S_SecCust.Name = "cmd_S_SecCust"
        Me.cmd_S_SecCust.Size = New System.Drawing.Size(53, 23)
        Me.cmd_S_SecCust.TabIndex = 10
        Me.cmd_S_SecCust.Text = ">>"
        Me.cmd_S_SecCust.UseVisualStyleBackColor = True
        '
        'txt_S_PriCustAll
        '
        Me.txt_S_PriCustAll.Location = New System.Drawing.Point(242, 123)
        Me.txt_S_PriCustAll.Name = "txt_S_PriCustAll"
        Me.txt_S_PriCustAll.Size = New System.Drawing.Size(726, 20)
        Me.txt_S_PriCustAll.TabIndex = 9
        '
        'cmd_S_PriCust
        '
        Me.cmd_S_PriCust.Location = New System.Drawing.Point(173, 121)
        Me.cmd_S_PriCust.Name = "cmd_S_PriCust"
        Me.cmd_S_PriCust.Size = New System.Drawing.Size(53, 23)
        Me.cmd_S_PriCust.TabIndex = 8
        Me.cmd_S_PriCust.Text = ">>"
        Me.cmd_S_PriCust.UseVisualStyleBackColor = True
        '
        'txt_S_CoCde
        '
        Me.txt_S_CoCde.Location = New System.Drawing.Point(242, 88)
        Me.txt_S_CoCde.Name = "txt_S_CoCde"
        Me.txt_S_CoCde.Size = New System.Drawing.Size(726, 20)
        Me.txt_S_CoCde.TabIndex = 7
        '
        'cmd_S_CoCde
        '
        Me.cmd_S_CoCde.Location = New System.Drawing.Point(173, 86)
        Me.cmd_S_CoCde.Name = "cmd_S_CoCde"
        Me.cmd_S_CoCde.Size = New System.Drawing.Size(53, 23)
        Me.cmd_S_CoCde.TabIndex = 6
        Me.cmd_S_CoCde.Text = ">>"
        Me.cmd_S_CoCde.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(72, 266)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "SC Revised Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(72, 231)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Item No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(72, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "SC No."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(72, 161)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Sec. Customer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(72, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Pri. Customer"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(72, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Code"
        '
        'tabFrame_Header
        '
        Me.tabFrame_Header.Controls.Add(Me.grpHeader)
        Me.tabFrame_Header.Location = New System.Drawing.Point(4, 24)
        Me.tabFrame_Header.Name = "tabFrame_Header"
        Me.tabFrame_Header.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFrame_Header.Size = New System.Drawing.Size(1064, 635)
        Me.tabFrame_Header.TabIndex = 1
        Me.tabFrame_Header.Text = "(2) Header"
        Me.tabFrame_Header.UseVisualStyleBackColor = True
        '
        'grpHeader
        '
        Me.grpHeader.Controls.Add(Me.cmdHdrApvApply)
        Me.grpHeader.Controls.Add(Me.GroupBox3)
        Me.grpHeader.Controls.Add(Me.lblPricing)
        Me.grpHeader.Controls.Add(Me.gbPriceView)
        Me.grpHeader.Controls.Add(Me.grpHdrAprv)
        Me.grpHeader.Controls.Add(Me.dgHeader)
        Me.grpHeader.Location = New System.Drawing.Point(1, -3)
        Me.grpHeader.Name = "grpHeader"
        Me.grpHeader.Size = New System.Drawing.Size(1060, 635)
        Me.grpHeader.TabIndex = 1
        Me.grpHeader.TabStop = False
        '
        'cmdHdrApvApply
        '
        Me.cmdHdrApvApply.Location = New System.Drawing.Point(999, 16)
        Me.cmdHdrApvApply.Name = "cmdHdrApvApply"
        Me.cmdHdrApvApply.Size = New System.Drawing.Size(55, 24)
        Me.cmdHdrApvApply.TabIndex = 94
        Me.cmdHdrApvApply.Text = "Apply"
        Me.cmdHdrApvApply.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbHdrApv_W)
        Me.GroupBox3.Controls.Add(Me.rbHdrApv_Y)
        Me.GroupBox3.Location = New System.Drawing.Point(756, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(237, 35)
        Me.GroupBox3.TabIndex = 93
        Me.GroupBox3.TabStop = False
        '
        'rbHdrApv_W
        '
        Me.rbHdrApv_W.AutoSize = True
        Me.rbHdrApv_W.Location = New System.Drawing.Point(99, 11)
        Me.rbHdrApv_W.Name = "rbHdrApv_W"
        Me.rbHdrApv_W.Size = New System.Drawing.Size(127, 17)
        Me.rbHdrApv_W.TabIndex = 64
        Me.rbHdrApv_W.Text = "W - Wait for Approval"
        Me.rbHdrApv_W.UseVisualStyleBackColor = True
        '
        'rbHdrApv_Y
        '
        Me.rbHdrApv_Y.AutoSize = True
        Me.rbHdrApv_Y.Checked = True
        Me.rbHdrApv_Y.Location = New System.Drawing.Point(10, 11)
        Me.rbHdrApv_Y.Name = "rbHdrApv_Y"
        Me.rbHdrApv_Y.Size = New System.Drawing.Size(83, 17)
        Me.rbHdrApv_Y.TabIndex = 63
        Me.rbHdrApv_Y.TabStop = True
        Me.rbHdrApv_Y.Text = "Y - Approval"
        Me.rbHdrApv_Y.UseVisualStyleBackColor = True
        '
        'lblPricing
        '
        Me.lblPricing.AutoSize = True
        Me.lblPricing.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPricing.Location = New System.Drawing.Point(7, 19)
        Me.lblPricing.Name = "lblPricing"
        Me.lblPricing.Size = New System.Drawing.Size(77, 14)
        Me.lblPricing.TabIndex = 88
        Me.lblPricing.Text = "Approval Filter"
        '
        'gbPriceView
        '
        Me.gbPriceView.Controls.Add(Me.rbHdrApvFilter_CloseOut)
        Me.gbPriceView.Controls.Add(Me.rbHdrApvFilter_Replacement)
        Me.gbPriceView.Controls.Add(Me.rbHdrApvFilter_PaymentTerm)
        Me.gbPriceView.Controls.Add(Me.rbHdrApvFilter_PriceTerm)
        Me.gbPriceView.Controls.Add(Me.rbHdrApvFilter_All)
        Me.gbPriceView.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPriceView.Location = New System.Drawing.Point(98, 6)
        Me.gbPriceView.Name = "gbPriceView"
        Me.gbPriceView.Size = New System.Drawing.Size(547, 35)
        Me.gbPriceView.TabIndex = 87
        Me.gbPriceView.TabStop = False
        '
        'rbHdrApvFilter_CloseOut
        '
        Me.rbHdrApvFilter_CloseOut.AutoSize = True
        Me.rbHdrApvFilter_CloseOut.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbHdrApvFilter_CloseOut.Location = New System.Drawing.Point(417, 11)
        Me.rbHdrApvFilter_CloseOut.Name = "rbHdrApvFilter_CloseOut"
        Me.rbHdrApvFilter_CloseOut.Size = New System.Drawing.Size(103, 18)
        Me.rbHdrApvFilter_CloseOut.TabIndex = 505
        Me.rbHdrApvFilter_CloseOut.Text = "Close Out Order"
        Me.rbHdrApvFilter_CloseOut.UseVisualStyleBackColor = True
        '
        'rbHdrApvFilter_Replacement
        '
        Me.rbHdrApvFilter_Replacement.AutoSize = True
        Me.rbHdrApvFilter_Replacement.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbHdrApvFilter_Replacement.Location = New System.Drawing.Point(286, 11)
        Me.rbHdrApvFilter_Replacement.Name = "rbHdrApvFilter_Replacement"
        Me.rbHdrApvFilter_Replacement.Size = New System.Drawing.Size(118, 18)
        Me.rbHdrApvFilter_Replacement.TabIndex = 504
        Me.rbHdrApvFilter_Replacement.Text = "Replacement Order"
        Me.rbHdrApvFilter_Replacement.UseVisualStyleBackColor = True
        '
        'rbHdrApvFilter_PaymentTerm
        '
        Me.rbHdrApvFilter_PaymentTerm.AutoSize = True
        Me.rbHdrApvFilter_PaymentTerm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbHdrApvFilter_PaymentTerm.Location = New System.Drawing.Point(174, 11)
        Me.rbHdrApvFilter_PaymentTerm.Name = "rbHdrApvFilter_PaymentTerm"
        Me.rbHdrApvFilter_PaymentTerm.Size = New System.Drawing.Size(93, 18)
        Me.rbHdrApvFilter_PaymentTerm.TabIndex = 503
        Me.rbHdrApvFilter_PaymentTerm.Text = "Payment Term"
        Me.rbHdrApvFilter_PaymentTerm.UseVisualStyleBackColor = True
        '
        'rbHdrApvFilter_PriceTerm
        '
        Me.rbHdrApvFilter_PriceTerm.AutoSize = True
        Me.rbHdrApvFilter_PriceTerm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbHdrApvFilter_PriceTerm.Location = New System.Drawing.Point(81, 11)
        Me.rbHdrApvFilter_PriceTerm.Name = "rbHdrApvFilter_PriceTerm"
        Me.rbHdrApvFilter_PriceTerm.Size = New System.Drawing.Size(76, 18)
        Me.rbHdrApvFilter_PriceTerm.TabIndex = 502
        Me.rbHdrApvFilter_PriceTerm.Text = "Price Term"
        Me.rbHdrApvFilter_PriceTerm.UseVisualStyleBackColor = True
        '
        'rbHdrApvFilter_All
        '
        Me.rbHdrApvFilter_All.AutoSize = True
        Me.rbHdrApvFilter_All.Checked = True
        Me.rbHdrApvFilter_All.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbHdrApvFilter_All.Location = New System.Drawing.Point(6, 11)
        Me.rbHdrApvFilter_All.Name = "rbHdrApvFilter_All"
        Me.rbHdrApvFilter_All.Size = New System.Drawing.Size(37, 18)
        Me.rbHdrApvFilter_All.TabIndex = 501
        Me.rbHdrApvFilter_All.TabStop = True
        Me.rbHdrApvFilter_All.Text = "All"
        Me.rbHdrApvFilter_All.UseVisualStyleBackColor = True
        '
        'grpHdrAprv
        '
        Me.grpHdrAprv.Controls.Add(Me.cmdHdrApply)
        Me.grpHdrAprv.Controls.Add(Me.cmdHdrSelectAll)
        Me.grpHdrAprv.Controls.Add(Me.optHdrAprvY)
        Me.grpHdrAprv.Controls.Add(Me.optHdrAprvW)
        Me.grpHdrAprv.Controls.Add(Me.optHdrAprvN)
        Me.grpHdrAprv.Location = New System.Drawing.Point(5, 589)
        Me.grpHdrAprv.Name = "grpHdrAprv"
        Me.grpHdrAprv.Size = New System.Drawing.Size(696, 43)
        Me.grpHdrAprv.TabIndex = 1
        Me.grpHdrAprv.TabStop = False
        Me.grpHdrAprv.Text = "Approval Type"
        Me.grpHdrAprv.Visible = False
        '
        'cmdHdrApply
        '
        Me.cmdHdrApply.Location = New System.Drawing.Point(591, 13)
        Me.cmdHdrApply.Name = "cmdHdrApply"
        Me.cmdHdrApply.Size = New System.Drawing.Size(100, 23)
        Me.cmdHdrApply.TabIndex = 4
        Me.cmdHdrApply.Text = "Apply"
        Me.cmdHdrApply.UseVisualStyleBackColor = True
        '
        'cmdHdrSelectAll
        '
        Me.cmdHdrSelectAll.Location = New System.Drawing.Point(487, 13)
        Me.cmdHdrSelectAll.Name = "cmdHdrSelectAll"
        Me.cmdHdrSelectAll.Size = New System.Drawing.Size(100, 23)
        Me.cmdHdrSelectAll.TabIndex = 3
        Me.cmdHdrSelectAll.Text = "Select All"
        Me.cmdHdrSelectAll.UseVisualStyleBackColor = True
        '
        'optHdrAprvY
        '
        Me.optHdrAprvY.AutoSize = True
        Me.optHdrAprvY.Location = New System.Drawing.Point(334, 15)
        Me.optHdrAprvY.Name = "optHdrAprvY"
        Me.optHdrAprvY.Size = New System.Drawing.Size(124, 17)
        Me.optHdrAprvY.TabIndex = 2
        Me.optHdrAprvY.TabStop = True
        Me.optHdrAprvY.Text = "Y - Approval Granted"
        Me.optHdrAprvY.UseVisualStyleBackColor = True
        '
        'optHdrAprvW
        '
        Me.optHdrAprvW.AutoSize = True
        Me.optHdrAprvW.Location = New System.Drawing.Point(178, 15)
        Me.optHdrAprvW.Name = "optHdrAprvW"
        Me.optHdrAprvW.Size = New System.Drawing.Size(141, 17)
        Me.optHdrAprvW.TabIndex = 1
        Me.optHdrAprvW.TabStop = True
        Me.optHdrAprvW.Text = "W - Waiting for Approval"
        Me.optHdrAprvW.UseVisualStyleBackColor = True
        '
        'optHdrAprvN
        '
        Me.optHdrAprvN.AutoSize = True
        Me.optHdrAprvN.Location = New System.Drawing.Point(15, 15)
        Me.optHdrAprvN.Name = "optHdrAprvN"
        Me.optHdrAprvN.Size = New System.Drawing.Size(147, 17)
        Me.optHdrAprvN.TabIndex = 0
        Me.optHdrAprvN.TabStop = True
        Me.optHdrAprvN.Text = "N - No Approval Required"
        Me.optHdrAprvN.UseVisualStyleBackColor = True
        '
        'dgHeader
        '
        Me.dgHeader.AllowUserToAddRows = False
        Me.dgHeader.AllowUserToDeleteRows = False
        Me.dgHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgHeader.Location = New System.Drawing.Point(2, 44)
        Me.dgHeader.Name = "dgHeader"
        Me.dgHeader.ReadOnly = True
        Me.dgHeader.RowHeadersWidth = 21
        Me.dgHeader.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgHeader.RowTemplate.Height = 20
        Me.dgHeader.Size = New System.Drawing.Size(1058, 588)
        Me.dgHeader.TabIndex = 0
        '
        'tabFrame_Detail
        '
        Me.tabFrame_Detail.Controls.Add(Me.grpDetail)
        Me.tabFrame_Detail.Location = New System.Drawing.Point(4, 24)
        Me.tabFrame_Detail.Name = "tabFrame_Detail"
        Me.tabFrame_Detail.Size = New System.Drawing.Size(1064, 635)
        Me.tabFrame_Detail.TabIndex = 2
        Me.tabFrame_Detail.Text = "(3) Detail"
        Me.tabFrame_Detail.UseVisualStyleBackColor = True
        '
        'grpDetail
        '
        Me.grpDetail.Controls.Add(Me.cmdDtlApvApply)
        Me.grpDetail.Controls.Add(Me.GroupBox4)
        Me.grpDetail.Controls.Add(Me.Label17)
        Me.grpDetail.Controls.Add(Me.GroupBox2)
        Me.grpDetail.Controls.Add(Me.dgDetail)
        Me.grpDetail.Controls.Add(Me.txtRvsDat)
        Me.grpDetail.Controls.Add(Me.Label12)
        Me.grpDetail.Controls.Add(Me.txtSecCus)
        Me.grpDetail.Controls.Add(Me.Label13)
        Me.grpDetail.Controls.Add(Me.txtPriCus)
        Me.grpDetail.Controls.Add(Me.Label14)
        Me.grpDetail.Controls.Add(Me.txtOrdSts)
        Me.grpDetail.Controls.Add(Me.Label11)
        Me.grpDetail.Controls.Add(Me.txtSCNo)
        Me.grpDetail.Controls.Add(Me.Label10)
        Me.grpDetail.Controls.Add(Me.GroupBox1)
        Me.grpDetail.Controls.Add(Me.txtCoCde)
        Me.grpDetail.Controls.Add(Me.Label9)
        Me.grpDetail.Location = New System.Drawing.Point(1, -3)
        Me.grpDetail.Name = "grpDetail"
        Me.grpDetail.Size = New System.Drawing.Size(1060, 635)
        Me.grpDetail.TabIndex = 1
        Me.grpDetail.TabStop = False
        '
        'cmdDtlApvApply
        '
        Me.cmdDtlApvApply.Location = New System.Drawing.Point(999, 16)
        Me.cmdDtlApvApply.Name = "cmdDtlApvApply"
        Me.cmdDtlApvApply.Size = New System.Drawing.Size(55, 24)
        Me.cmdDtlApvApply.TabIndex = 92
        Me.cmdDtlApvApply.Text = "Apply"
        Me.cmdDtlApvApply.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbDtlApv_W)
        Me.GroupBox4.Controls.Add(Me.rbDtlApv_Y)
        Me.GroupBox4.Location = New System.Drawing.Point(756, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(237, 35)
        Me.GroupBox4.TabIndex = 91
        Me.GroupBox4.TabStop = False
        '
        'rbDtlApv_W
        '
        Me.rbDtlApv_W.AutoSize = True
        Me.rbDtlApv_W.Location = New System.Drawing.Point(99, 11)
        Me.rbDtlApv_W.Name = "rbDtlApv_W"
        Me.rbDtlApv_W.Size = New System.Drawing.Size(127, 17)
        Me.rbDtlApv_W.TabIndex = 64
        Me.rbDtlApv_W.Text = "W - Wait for Approval"
        Me.rbDtlApv_W.UseVisualStyleBackColor = True
        '
        'rbDtlApv_Y
        '
        Me.rbDtlApv_Y.AutoSize = True
        Me.rbDtlApv_Y.Checked = True
        Me.rbDtlApv_Y.Location = New System.Drawing.Point(10, 11)
        Me.rbDtlApv_Y.Name = "rbDtlApv_Y"
        Me.rbDtlApv_Y.Size = New System.Drawing.Size(83, 17)
        Me.rbDtlApv_Y.TabIndex = 63
        Me.rbDtlApv_Y.TabStop = True
        Me.rbDtlApv_Y.Text = "Y - Approval"
        Me.rbDtlApv_Y.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(7, 19)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(77, 14)
        Me.Label17.TabIndex = 90
        Me.Label17.Text = "Approval Filter"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbDtlApvFilter_ChgSelPrc)
        Me.GroupBox2.Controls.Add(Me.rbDtlApvFilter_ChgDVPVFtyCst)
        Me.GroupBox2.Controls.Add(Me.rbDtlApvFilter_OneTime)
        Me.GroupBox2.Controls.Add(Me.rbDtlApvFilter_BelowMinMU)
        Me.GroupBox2.Controls.Add(Me.rbDtlApvFilter_MOQ)
        Me.GroupBox2.Controls.Add(Me.rbDtlApvFilter_All)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(98, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(611, 35)
        Me.GroupBox2.TabIndex = 89
        Me.GroupBox2.TabStop = False
        '
        'rbDtlApvFilter_ChgSelPrc
        '
        Me.rbDtlApvFilter_ChgSelPrc.AutoSize = True
        Me.rbDtlApvFilter_ChgSelPrc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDtlApvFilter_ChgSelPrc.Location = New System.Drawing.Point(49, 11)
        Me.rbDtlApvFilter_ChgSelPrc.Name = "rbDtlApvFilter_ChgSelPrc"
        Me.rbDtlApvFilter_ChgSelPrc.Size = New System.Drawing.Size(123, 18)
        Me.rbDtlApvFilter_ChgSelPrc.TabIndex = 506
        Me.rbDtlApvFilter_ChgSelPrc.Text = "Change Selling Price"
        Me.rbDtlApvFilter_ChgSelPrc.UseVisualStyleBackColor = True
        '
        'rbDtlApvFilter_ChgDVPVFtyCst
        '
        Me.rbDtlApvFilter_ChgDVPVFtyCst.AutoSize = True
        Me.rbDtlApvFilter_ChgDVPVFtyCst.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDtlApvFilter_ChgDVPVFtyCst.Location = New System.Drawing.Point(464, 11)
        Me.rbDtlApvFilter_ChgDVPVFtyCst.Name = "rbDtlApvFilter_ChgDVPVFtyCst"
        Me.rbDtlApvFilter_ChgDVPVFtyCst.Size = New System.Drawing.Size(131, 18)
        Me.rbDtlApvFilter_ChgDVPVFtyCst.TabIndex = 505
        Me.rbDtlApvFilter_ChgDVPVFtyCst.Text = "Change DV/PV FtyCst"
        Me.rbDtlApvFilter_ChgDVPVFtyCst.UseVisualStyleBackColor = True
        '
        'rbDtlApvFilter_OneTime
        '
        Me.rbDtlApvFilter_OneTime.AutoSize = True
        Me.rbDtlApvFilter_OneTime.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDtlApvFilter_OneTime.Location = New System.Drawing.Point(366, 11)
        Me.rbDtlApvFilter_OneTime.Name = "rbDtlApvFilter_OneTime"
        Me.rbDtlApvFilter_OneTime.Size = New System.Drawing.Size(97, 18)
        Me.rbDtlApvFilter_OneTime.TabIndex = 504
        Me.rbDtlApvFilter_OneTime.Text = "One Time Price"
        Me.rbDtlApvFilter_OneTime.UseVisualStyleBackColor = True
        '
        'rbDtlApvFilter_BelowMinMU
        '
        Me.rbDtlApvFilter_BelowMinMU.AutoSize = True
        Me.rbDtlApvFilter_BelowMinMU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDtlApvFilter_BelowMinMU.Location = New System.Drawing.Point(267, 11)
        Me.rbDtlApvFilter_BelowMinMU.Name = "rbDtlApvFilter_BelowMinMU"
        Me.rbDtlApvFilter_BelowMinMU.Size = New System.Drawing.Size(93, 18)
        Me.rbDtlApvFilter_BelowMinMU.TabIndex = 503
        Me.rbDtlApvFilter_BelowMinMU.Text = "Below Min MU"
        Me.rbDtlApvFilter_BelowMinMU.UseVisualStyleBackColor = True
        '
        'rbDtlApvFilter_MOQ
        '
        Me.rbDtlApvFilter_MOQ.AutoSize = True
        Me.rbDtlApvFilter_MOQ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDtlApvFilter_MOQ.Location = New System.Drawing.Point(178, 11)
        Me.rbDtlApvFilter_MOQ.Name = "rbDtlApvFilter_MOQ"
        Me.rbDtlApvFilter_MOQ.Size = New System.Drawing.Size(83, 18)
        Me.rbDtlApvFilter_MOQ.TabIndex = 502
        Me.rbDtlApvFilter_MOQ.Text = "Below MOQ"
        Me.rbDtlApvFilter_MOQ.UseVisualStyleBackColor = True
        '
        'rbDtlApvFilter_All
        '
        Me.rbDtlApvFilter_All.AutoSize = True
        Me.rbDtlApvFilter_All.Checked = True
        Me.rbDtlApvFilter_All.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDtlApvFilter_All.Location = New System.Drawing.Point(6, 11)
        Me.rbDtlApvFilter_All.Name = "rbDtlApvFilter_All"
        Me.rbDtlApvFilter_All.Size = New System.Drawing.Size(37, 18)
        Me.rbDtlApvFilter_All.TabIndex = 501
        Me.rbDtlApvFilter_All.TabStop = True
        Me.rbDtlApvFilter_All.Text = "All"
        Me.rbDtlApvFilter_All.UseVisualStyleBackColor = True
        '
        'dgDetail
        '
        Me.dgDetail.AllowUserToAddRows = False
        Me.dgDetail.AllowUserToDeleteRows = False
        Me.dgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetail.Location = New System.Drawing.Point(2, 47)
        Me.dgDetail.Name = "dgDetail"
        Me.dgDetail.ReadOnly = True
        Me.dgDetail.RowHeadersWidth = 21
        Me.dgDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgDetail.RowTemplate.Height = 20
        Me.dgDetail.Size = New System.Drawing.Size(1058, 588)
        Me.dgDetail.TabIndex = 15
        '
        'txtRvsDat
        '
        Me.txtRvsDat.BackColor = System.Drawing.Color.White
        Me.txtRvsDat.ForeColor = System.Drawing.Color.Black
        Me.txtRvsDat.Location = New System.Drawing.Point(649, 119)
        Me.txtRvsDat.Name = "txtRvsDat"
        Me.txtRvsDat.Size = New System.Drawing.Size(78, 20)
        Me.txtRvsDat.TabIndex = 14
        Me.txtRvsDat.Text = "00/00/0000"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(559, 122)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 13)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "SC Revised Date"
        '
        'txtSecCus
        '
        Me.txtSecCus.BackColor = System.Drawing.Color.White
        Me.txtSecCus.ForeColor = System.Drawing.Color.Black
        Me.txtSecCus.Location = New System.Drawing.Point(487, 145)
        Me.txtSecCus.Name = "txtSecCus"
        Me.txtSecCus.Size = New System.Drawing.Size(240, 20)
        Me.txtSecCus.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(376, 148)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(105, 13)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Secondary Customer"
        '
        'txtPriCus
        '
        Me.txtPriCus.BackColor = System.Drawing.Color.White
        Me.txtPriCus.ForeColor = System.Drawing.Color.Black
        Me.txtPriCus.Location = New System.Drawing.Point(108, 145)
        Me.txtPriCus.Name = "txtPriCus"
        Me.txtPriCus.Size = New System.Drawing.Size(240, 20)
        Me.txtPriCus.TabIndex = 10
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 148)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 13)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "Primary Customer"
        '
        'txtOrdSts
        '
        Me.txtOrdSts.BackColor = System.Drawing.Color.White
        Me.txtOrdSts.ForeColor = System.Drawing.Color.Black
        Me.txtOrdSts.Location = New System.Drawing.Point(379, 119)
        Me.txtOrdSts.Name = "txtOrdSts"
        Me.txtOrdSts.Size = New System.Drawing.Size(169, 20)
        Me.txtOrdSts.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(319, 122)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "SC Status"
        '
        'txtSCNo
        '
        Me.txtSCNo.BackColor = System.Drawing.Color.White
        Me.txtSCNo.ForeColor = System.Drawing.Color.Black
        Me.txtSCNo.Location = New System.Drawing.Point(208, 119)
        Me.txtSCNo.Name = "txtSCNo"
        Me.txtSCNo.Size = New System.Drawing.Size(91, 20)
        Me.txtSCNo.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(159, 122)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "SC No"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdDtlApply)
        Me.GroupBox1.Controls.Add(Me.cmdDtlSelectAll)
        Me.GroupBox1.Controls.Add(Me.optDtlAprvY)
        Me.GroupBox1.Controls.Add(Me.optDtlAprvW)
        Me.GroupBox1.Controls.Add(Me.optDtlAprvN)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 587)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(709, 42)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Approval Type"
        Me.GroupBox1.Visible = False
        '
        'cmdDtlApply
        '
        Me.cmdDtlApply.Location = New System.Drawing.Point(603, 13)
        Me.cmdDtlApply.Name = "cmdDtlApply"
        Me.cmdDtlApply.Size = New System.Drawing.Size(100, 23)
        Me.cmdDtlApply.TabIndex = 4
        Me.cmdDtlApply.Text = "Apply"
        Me.cmdDtlApply.UseVisualStyleBackColor = True
        '
        'cmdDtlSelectAll
        '
        Me.cmdDtlSelectAll.Location = New System.Drawing.Point(502, 13)
        Me.cmdDtlSelectAll.Name = "cmdDtlSelectAll"
        Me.cmdDtlSelectAll.Size = New System.Drawing.Size(100, 23)
        Me.cmdDtlSelectAll.TabIndex = 3
        Me.cmdDtlSelectAll.Text = "Select All"
        Me.cmdDtlSelectAll.UseVisualStyleBackColor = True
        '
        'optDtlAprvY
        '
        Me.optDtlAprvY.AutoSize = True
        Me.optDtlAprvY.Location = New System.Drawing.Point(334, 16)
        Me.optDtlAprvY.Name = "optDtlAprvY"
        Me.optDtlAprvY.Size = New System.Drawing.Size(124, 17)
        Me.optDtlAprvY.TabIndex = 2
        Me.optDtlAprvY.TabStop = True
        Me.optDtlAprvY.Text = "Y - Approval Granted"
        Me.optDtlAprvY.UseVisualStyleBackColor = True
        '
        'optDtlAprvW
        '
        Me.optDtlAprvW.AutoSize = True
        Me.optDtlAprvW.Location = New System.Drawing.Point(178, 16)
        Me.optDtlAprvW.Name = "optDtlAprvW"
        Me.optDtlAprvW.Size = New System.Drawing.Size(141, 17)
        Me.optDtlAprvW.TabIndex = 1
        Me.optDtlAprvW.TabStop = True
        Me.optDtlAprvW.Text = "W - Waiting for Approval"
        Me.optDtlAprvW.UseVisualStyleBackColor = True
        '
        'optDtlAprvN
        '
        Me.optDtlAprvN.AutoSize = True
        Me.optDtlAprvN.Location = New System.Drawing.Point(15, 16)
        Me.optDtlAprvN.Name = "optDtlAprvN"
        Me.optDtlAprvN.Size = New System.Drawing.Size(147, 17)
        Me.optDtlAprvN.TabIndex = 0
        Me.optDtlAprvN.TabStop = True
        Me.optDtlAprvN.Text = "N - No Approval Required"
        Me.optDtlAprvN.UseVisualStyleBackColor = True
        '
        'txtCoCde
        '
        Me.txtCoCde.BackColor = System.Drawing.Color.White
        Me.txtCoCde.ForeColor = System.Drawing.Color.Black
        Me.txtCoCde.Location = New System.Drawing.Point(71, 119)
        Me.txtCoCde.Name = "txtCoCde"
        Me.txtCoCde.Size = New System.Drawing.Size(70, 20)
        Me.txtCoCde.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 122)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Company"
        '
        'SCM00006
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1072, 716)
        Me.Controls.Add(Me.cmdInsRow)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdLast)
        Me.Controls.Add(Me.cmdPrevious)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdDelRow)
        Me.Controls.Add(Me.cmdFirst)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.tabFrame)
        Me.Name = "SCM00006"
        Me.Text = "SCM00006 - Sales Confirmation Approval"
        Me.tabFrame.ResumeLayout(False)
        Me.tabFrame_Search.ResumeLayout(False)
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.tabFrame_Header.ResumeLayout(False)
        Me.grpHeader.ResumeLayout(False)
        Me.grpHeader.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gbPriceView.ResumeLayout(False)
        Me.gbPriceView.PerformLayout()
        Me.grpHdrAprv.ResumeLayout(False)
        Me.grpHdrAprv.PerformLayout()
        CType(Me.dgHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabFrame_Detail.ResumeLayout(False)
        Me.grpDetail.ResumeLayout(False)
        Me.grpDetail.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabFrame As ERPSystem.BaseTabControl
    Friend WithEvents tabFrame_Search As System.Windows.Forms.TabPage
    Friend WithEvents tabFrame_Header As System.Windows.Forms.TabPage
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents tabFrame_Detail As System.Windows.Forms.TabPage
    Friend WithEvents cmdInsRow As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdLast As System.Windows.Forms.Button
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdDelRow As System.Windows.Forms.Button
    Friend WithEvents cmdFirst As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents grpHeader As System.Windows.Forms.GroupBox
    Friend WithEvents grpDetail As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSCRvsdatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSCRvsdatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_S_ItmNo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_ItmNo As System.Windows.Forms.Button
    Friend WithEvents txt_S_SCNo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SCNo As System.Windows.Forms.Button
    Friend WithEvents txt_S_SecCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SecCust As System.Windows.Forms.Button
    Friend WithEvents txt_S_PriCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PriCust As System.Windows.Forms.Button
    Friend WithEvents txt_S_CoCde As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_CoCde As System.Windows.Forms.Button
    Friend WithEvents dgHeader As System.Windows.Forms.DataGridView
    Friend WithEvents grpHdrAprv As System.Windows.Forms.GroupBox
    Friend WithEvents cmdHdrApply As System.Windows.Forms.Button
    Friend WithEvents cmdHdrSelectAll As System.Windows.Forms.Button
    Friend WithEvents optHdrAprvY As System.Windows.Forms.RadioButton
    Friend WithEvents optHdrAprvW As System.Windows.Forms.RadioButton
    Friend WithEvents optHdrAprvN As System.Windows.Forms.RadioButton
    Friend WithEvents txtCoCde As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDtlApply As System.Windows.Forms.Button
    Friend WithEvents cmdDtlSelectAll As System.Windows.Forms.Button
    Friend WithEvents optDtlAprvY As System.Windows.Forms.RadioButton
    Friend WithEvents optDtlAprvW As System.Windows.Forms.RadioButton
    Friend WithEvents optDtlAprvN As System.Windows.Forms.RadioButton
    Friend WithEvents txtSCNo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtOrdSts As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtRvsDat As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSecCus As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPriCus As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dgDetail As System.Windows.Forms.DataGridView
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblPricing As System.Windows.Forms.Label
    Friend WithEvents gbPriceView As System.Windows.Forms.GroupBox
    Friend WithEvents rbHdrApvFilter_CloseOut As System.Windows.Forms.RadioButton
    Friend WithEvents rbHdrApvFilter_Replacement As System.Windows.Forms.RadioButton
    Friend WithEvents rbHdrApvFilter_PaymentTerm As System.Windows.Forms.RadioButton
    Friend WithEvents rbHdrApvFilter_PriceTerm As System.Windows.Forms.RadioButton
    Friend WithEvents rbHdrApvFilter_All As System.Windows.Forms.RadioButton
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbDtlApvFilter_ChgDVPVFtyCst As System.Windows.Forms.RadioButton
    Friend WithEvents rbDtlApvFilter_OneTime As System.Windows.Forms.RadioButton
    Friend WithEvents rbDtlApvFilter_BelowMinMU As System.Windows.Forms.RadioButton
    Friend WithEvents rbDtlApvFilter_MOQ As System.Windows.Forms.RadioButton
    Friend WithEvents rbDtlApvFilter_All As System.Windows.Forms.RadioButton
    Friend WithEvents rbDtlApvFilter_ChgSelPrc As System.Windows.Forms.RadioButton
    Friend WithEvents cmdDtlApvApply As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbDtlApv_W As System.Windows.Forms.RadioButton
    Friend WithEvents rbDtlApv_Y As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents cmdHdrApvApply As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbHdrApv_W As System.Windows.Forms.RadioButton
    Friend WithEvents rbHdrApv_Y As System.Windows.Forms.RadioButton
End Class
