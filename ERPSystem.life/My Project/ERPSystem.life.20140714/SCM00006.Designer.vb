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
        Me.txt_S_SecCust = New System.Windows.Forms.TextBox
        Me.cmd_S_SecCust = New System.Windows.Forms.Button
        Me.txt_S_PriCust = New System.Windows.Forms.TextBox
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
        Me.grpHdrAprv = New System.Windows.Forms.GroupBox
        Me.cmdHdrApply = New System.Windows.Forms.Button
        Me.cmdHdrSelectAll = New System.Windows.Forms.Button
        Me.optHdrAprvY = New System.Windows.Forms.RadioButton
        Me.optHdrAprvW = New System.Windows.Forms.RadioButton
        Me.optHdrAprvN = New System.Windows.Forms.RadioButton
        Me.dgHeader = New System.Windows.Forms.DataGridView
        Me.tabFrame_Detail = New System.Windows.Forms.TabPage
        Me.grpDetail = New System.Windows.Forms.GroupBox
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
        Me.grpHdrAprv.SuspendLayout()
        CType(Me.dgHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabFrame_Detail.SuspendLayout()
        Me.grpDetail.SuspendLayout()
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 610)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(952, 16)
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
        Me.tabFrame.Size = New System.Drawing.Size(952, 573)
        Me.tabFrame.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabFrame.TabIndex = 294
        '
        'tabFrame_Search
        '
        Me.tabFrame_Search.Controls.Add(Me.grpSearch)
        Me.tabFrame_Search.Location = New System.Drawing.Point(4, 24)
        Me.tabFrame_Search.Name = "tabFrame_Search"
        Me.tabFrame_Search.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFrame_Search.Size = New System.Drawing.Size(944, 545)
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
        Me.grpSearch.Controls.Add(Me.txt_S_SecCust)
        Me.grpSearch.Controls.Add(Me.cmd_S_SecCust)
        Me.grpSearch.Controls.Add(Me.txt_S_PriCust)
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
        Me.grpSearch.Size = New System.Drawing.Size(940, 542)
        Me.grpSearch.TabIndex = 0
        Me.grpSearch.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(390, 266)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 13)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "MM/DD/YYYY"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(188, 266)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 13)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "MM/DD/YYYY"
        '
        'txtSCRvsdatTo
        '
        Me.txtSCRvsdatTo.Location = New System.Drawing.Point(391, 243)
        Me.txtSCRvsdatTo.Mask = "00/00/0000"
        Me.txtSCRvsdatTo.Name = "txtSCRvsdatTo"
        Me.txtSCRvsdatTo.Size = New System.Drawing.Size(100, 20)
        Me.txtSCRvsdatTo.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(358, 246)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "To"
        '
        'txtSCRvsdatFm
        '
        Me.txtSCRvsdatFm.Location = New System.Drawing.Point(189, 243)
        Me.txtSCRvsdatFm.Mask = "00/00/0000"
        Me.txtSCRvsdatFm.Name = "txtSCRvsdatFm"
        Me.txtSCRvsdatFm.Size = New System.Drawing.Size(100, 20)
        Me.txtSCRvsdatFm.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(143, 246)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "From"
        '
        'txt_S_ItmNo
        '
        Me.txt_S_ItmNo.Location = New System.Drawing.Point(189, 208)
        Me.txt_S_ItmNo.Name = "txt_S_ItmNo"
        Me.txt_S_ItmNo.Size = New System.Drawing.Size(726, 20)
        Me.txt_S_ItmNo.TabIndex = 15
        '
        'cmd_S_ItmNo
        '
        Me.cmd_S_ItmNo.Location = New System.Drawing.Point(120, 206)
        Me.cmd_S_ItmNo.Name = "cmd_S_ItmNo"
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(53, 23)
        Me.cmd_S_ItmNo.TabIndex = 14
        Me.cmd_S_ItmNo.Text = ">>"
        Me.cmd_S_ItmNo.UseVisualStyleBackColor = True
        '
        'txt_S_SCNo
        '
        Me.txt_S_SCNo.Location = New System.Drawing.Point(189, 173)
        Me.txt_S_SCNo.Name = "txt_S_SCNo"
        Me.txt_S_SCNo.Size = New System.Drawing.Size(726, 20)
        Me.txt_S_SCNo.TabIndex = 13
        '
        'cmd_S_SCNo
        '
        Me.cmd_S_SCNo.Location = New System.Drawing.Point(120, 171)
        Me.cmd_S_SCNo.Name = "cmd_S_SCNo"
        Me.cmd_S_SCNo.Size = New System.Drawing.Size(53, 23)
        Me.cmd_S_SCNo.TabIndex = 12
        Me.cmd_S_SCNo.Text = ">>"
        Me.cmd_S_SCNo.UseVisualStyleBackColor = True
        '
        'txt_S_SecCust
        '
        Me.txt_S_SecCust.Location = New System.Drawing.Point(189, 138)
        Me.txt_S_SecCust.Name = "txt_S_SecCust"
        Me.txt_S_SecCust.Size = New System.Drawing.Size(726, 20)
        Me.txt_S_SecCust.TabIndex = 11
        '
        'cmd_S_SecCust
        '
        Me.cmd_S_SecCust.Location = New System.Drawing.Point(120, 136)
        Me.cmd_S_SecCust.Name = "cmd_S_SecCust"
        Me.cmd_S_SecCust.Size = New System.Drawing.Size(53, 23)
        Me.cmd_S_SecCust.TabIndex = 10
        Me.cmd_S_SecCust.Text = ">>"
        Me.cmd_S_SecCust.UseVisualStyleBackColor = True
        '
        'txt_S_PriCust
        '
        Me.txt_S_PriCust.Location = New System.Drawing.Point(189, 103)
        Me.txt_S_PriCust.Name = "txt_S_PriCust"
        Me.txt_S_PriCust.Size = New System.Drawing.Size(726, 20)
        Me.txt_S_PriCust.TabIndex = 9
        '
        'cmd_S_PriCust
        '
        Me.cmd_S_PriCust.Location = New System.Drawing.Point(120, 101)
        Me.cmd_S_PriCust.Name = "cmd_S_PriCust"
        Me.cmd_S_PriCust.Size = New System.Drawing.Size(53, 23)
        Me.cmd_S_PriCust.TabIndex = 8
        Me.cmd_S_PriCust.Text = ">>"
        Me.cmd_S_PriCust.UseVisualStyleBackColor = True
        '
        'txt_S_CoCde
        '
        Me.txt_S_CoCde.Location = New System.Drawing.Point(189, 68)
        Me.txt_S_CoCde.Name = "txt_S_CoCde"
        Me.txt_S_CoCde.Size = New System.Drawing.Size(726, 20)
        Me.txt_S_CoCde.TabIndex = 7
        '
        'cmd_S_CoCde
        '
        Me.cmd_S_CoCde.Location = New System.Drawing.Point(120, 66)
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
        Me.Label6.Location = New System.Drawing.Point(19, 246)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "SC Revised Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 211)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Item No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "SC No."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Sec. Customer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Pri. Customer"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 71)
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
        Me.tabFrame_Header.Size = New System.Drawing.Size(944, 545)
        Me.tabFrame_Header.TabIndex = 1
        Me.tabFrame_Header.Text = "(2) Header"
        Me.tabFrame_Header.UseVisualStyleBackColor = True
        '
        'grpHeader
        '
        Me.grpHeader.Controls.Add(Me.grpHdrAprv)
        Me.grpHeader.Controls.Add(Me.dgHeader)
        Me.grpHeader.Location = New System.Drawing.Point(1, -3)
        Me.grpHeader.Name = "grpHeader"
        Me.grpHeader.Size = New System.Drawing.Size(940, 552)
        Me.grpHeader.TabIndex = 1
        Me.grpHeader.TabStop = False
        '
        'grpHdrAprv
        '
        Me.grpHdrAprv.Controls.Add(Me.cmdHdrApply)
        Me.grpHdrAprv.Controls.Add(Me.cmdHdrSelectAll)
        Me.grpHdrAprv.Controls.Add(Me.optHdrAprvY)
        Me.grpHdrAprv.Controls.Add(Me.optHdrAprvW)
        Me.grpHdrAprv.Controls.Add(Me.optHdrAprvN)
        Me.grpHdrAprv.Location = New System.Drawing.Point(5, 478)
        Me.grpHdrAprv.Name = "grpHdrAprv"
        Me.grpHdrAprv.Size = New System.Drawing.Size(599, 64)
        Me.grpHdrAprv.TabIndex = 1
        Me.grpHdrAprv.TabStop = False
        Me.grpHdrAprv.Text = "Approval Type"
        '
        'cmdHdrApply
        '
        Me.cmdHdrApply.Location = New System.Drawing.Point(487, 37)
        Me.cmdHdrApply.Name = "cmdHdrApply"
        Me.cmdHdrApply.Size = New System.Drawing.Size(100, 23)
        Me.cmdHdrApply.TabIndex = 4
        Me.cmdHdrApply.Text = "Apply"
        Me.cmdHdrApply.UseVisualStyleBackColor = True
        '
        'cmdHdrSelectAll
        '
        Me.cmdHdrSelectAll.Location = New System.Drawing.Point(487, 11)
        Me.cmdHdrSelectAll.Name = "cmdHdrSelectAll"
        Me.cmdHdrSelectAll.Size = New System.Drawing.Size(100, 23)
        Me.cmdHdrSelectAll.TabIndex = 3
        Me.cmdHdrSelectAll.Text = "Select All"
        Me.cmdHdrSelectAll.UseVisualStyleBackColor = True
        '
        'optHdrAprvY
        '
        Me.optHdrAprvY.AutoSize = True
        Me.optHdrAprvY.Location = New System.Drawing.Point(334, 29)
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
        Me.optHdrAprvW.Location = New System.Drawing.Point(178, 29)
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
        Me.optHdrAprvN.Location = New System.Drawing.Point(15, 29)
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
        Me.dgHeader.Location = New System.Drawing.Point(6, 13)
        Me.dgHeader.Name = "dgHeader"
        Me.dgHeader.ReadOnly = True
        Me.dgHeader.RowHeadersWidth = 21
        Me.dgHeader.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgHeader.RowTemplate.Height = 20
        Me.dgHeader.Size = New System.Drawing.Size(925, 459)
        Me.dgHeader.TabIndex = 0
        '
        'tabFrame_Detail
        '
        Me.tabFrame_Detail.Controls.Add(Me.grpDetail)
        Me.tabFrame_Detail.Location = New System.Drawing.Point(4, 24)
        Me.tabFrame_Detail.Name = "tabFrame_Detail"
        Me.tabFrame_Detail.Size = New System.Drawing.Size(944, 545)
        Me.tabFrame_Detail.TabIndex = 2
        Me.tabFrame_Detail.Text = "(3) Detail"
        Me.tabFrame_Detail.UseVisualStyleBackColor = True
        '
        'grpDetail
        '
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
        Me.grpDetail.Size = New System.Drawing.Size(940, 545)
        Me.grpDetail.TabIndex = 1
        Me.grpDetail.TabStop = False
        '
        'dgDetail
        '
        Me.dgDetail.AllowUserToAddRows = False
        Me.dgDetail.AllowUserToDeleteRows = False
        Me.dgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetail.Location = New System.Drawing.Point(6, 71)
        Me.dgDetail.Name = "dgDetail"
        Me.dgDetail.ReadOnly = True
        Me.dgDetail.RowHeadersWidth = 21
        Me.dgDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgDetail.RowTemplate.Height = 20
        Me.dgDetail.Size = New System.Drawing.Size(928, 398)
        Me.dgDetail.TabIndex = 15
        '
        'txtRvsDat
        '
        Me.txtRvsDat.BackColor = System.Drawing.Color.White
        Me.txtRvsDat.ForeColor = System.Drawing.Color.Black
        Me.txtRvsDat.Location = New System.Drawing.Point(646, 19)
        Me.txtRvsDat.Name = "txtRvsDat"
        Me.txtRvsDat.Size = New System.Drawing.Size(78, 20)
        Me.txtRvsDat.TabIndex = 14
        Me.txtRvsDat.Text = "00/00/0000"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(556, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 13)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "SC Revised Date"
        '
        'txtSecCus
        '
        Me.txtSecCus.BackColor = System.Drawing.Color.White
        Me.txtSecCus.ForeColor = System.Drawing.Color.Black
        Me.txtSecCus.Location = New System.Drawing.Point(484, 45)
        Me.txtSecCus.Name = "txtSecCus"
        Me.txtSecCus.Size = New System.Drawing.Size(240, 20)
        Me.txtSecCus.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(373, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(105, 13)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Secondary Customer"
        '
        'txtPriCus
        '
        Me.txtPriCus.BackColor = System.Drawing.Color.White
        Me.txtPriCus.ForeColor = System.Drawing.Color.Black
        Me.txtPriCus.Location = New System.Drawing.Point(105, 45)
        Me.txtPriCus.Name = "txtPriCus"
        Me.txtPriCus.Size = New System.Drawing.Size(240, 20)
        Me.txtPriCus.TabIndex = 10
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(11, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 13)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "Primary Customer"
        '
        'txtOrdSts
        '
        Me.txtOrdSts.BackColor = System.Drawing.Color.White
        Me.txtOrdSts.ForeColor = System.Drawing.Color.Black
        Me.txtOrdSts.Location = New System.Drawing.Point(376, 19)
        Me.txtOrdSts.Name = "txtOrdSts"
        Me.txtOrdSts.Size = New System.Drawing.Size(169, 20)
        Me.txtOrdSts.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(316, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "SC Status"
        '
        'txtSCNo
        '
        Me.txtSCNo.BackColor = System.Drawing.Color.White
        Me.txtSCNo.ForeColor = System.Drawing.Color.Black
        Me.txtSCNo.Location = New System.Drawing.Point(205, 19)
        Me.txtSCNo.Name = "txtSCNo"
        Me.txtSCNo.Size = New System.Drawing.Size(91, 20)
        Me.txtSCNo.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(156, 22)
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
        Me.GroupBox1.Location = New System.Drawing.Point(6, 475)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(599, 64)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Approval Type"
        '
        'cmdDtlApply
        '
        Me.cmdDtlApply.Location = New System.Drawing.Point(487, 37)
        Me.cmdDtlApply.Name = "cmdDtlApply"
        Me.cmdDtlApply.Size = New System.Drawing.Size(100, 23)
        Me.cmdDtlApply.TabIndex = 4
        Me.cmdDtlApply.Text = "Apply"
        Me.cmdDtlApply.UseVisualStyleBackColor = True
        '
        'cmdDtlSelectAll
        '
        Me.cmdDtlSelectAll.Location = New System.Drawing.Point(487, 11)
        Me.cmdDtlSelectAll.Name = "cmdDtlSelectAll"
        Me.cmdDtlSelectAll.Size = New System.Drawing.Size(100, 23)
        Me.cmdDtlSelectAll.TabIndex = 3
        Me.cmdDtlSelectAll.Text = "Select All"
        Me.cmdDtlSelectAll.UseVisualStyleBackColor = True
        '
        'optDtlAprvY
        '
        Me.optDtlAprvY.AutoSize = True
        Me.optDtlAprvY.Location = New System.Drawing.Point(334, 29)
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
        Me.optDtlAprvW.Location = New System.Drawing.Point(178, 29)
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
        Me.optDtlAprvN.Location = New System.Drawing.Point(15, 29)
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
        Me.txtCoCde.Location = New System.Drawing.Point(68, 19)
        Me.txtCoCde.Name = "txtCoCde"
        Me.txtCoCde.Size = New System.Drawing.Size(70, 20)
        Me.txtCoCde.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Company"
        '
        'SCM00006
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 626)
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
        Me.grpHdrAprv.ResumeLayout(False)
        Me.grpHdrAprv.PerformLayout()
        CType(Me.dgHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabFrame_Detail.ResumeLayout(False)
        Me.grpDetail.ResumeLayout(False)
        Me.grpDetail.PerformLayout()
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
    Friend WithEvents txt_S_SecCust As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SecCust As System.Windows.Forms.Button
    Friend WithEvents txt_S_PriCust As System.Windows.Forms.TextBox
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
End Class
